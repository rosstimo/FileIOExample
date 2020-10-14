Imports System
Imports System.IO

Module ReadWriteAppend
    Sub Main()
        Dim fileName As String = "testfile.txt"
        Dim dataArray() As String
        ReadFile(fileName, dataArray)
        'AppendFile(fileName, "Hello")
        'WriteFile(fileName, "Goodbye")
        Console.WriteLine(dataArray)
        Console.ReadLine()
    End Sub


    'ReadFile() allows user to choose text file then reads file into TempArray
    Public Sub ReadFile(ByVal fileName As String, ByRef recordData() As String)
        Dim currentRecord As String
        Dim fileData As String
        Dim fileNumber As Integer = FreeFile()

        Try
            FileOpen(fileNumber, fileName, OpenMode.Input)
            Do While Not EOF(fileNumber)
                Input(fileNumber, currentRecord)
                fileData &= currentRecord
            Loop
        Catch ex As IOException
            Console.WriteLine("Oops file not found....")
            Console.WriteLine($"{vbNewLine}File Name: '{fileName}'")
        Catch ex As Exception
            'TODO: user select file if it doesn't exist
            Console.WriteLine(GeneralExceptionInfo(ex, fileName))
        Finally
            FileClose(fileNumber)
        End Try

        recordData = Split(fileData, "$$")

    End Sub


    Private Sub AppendFile(ByVal filename As String, newRecord As String)
        Dim fileNumber As Integer = FreeFile()

        Try
            FileOpen(fileNumber, filename, OpenMode.Append)
            Write(fileNumber, newRecord)
            WriteLine(fileNumber)

        Catch ex As Exception
            'TODO: user select file if it doesn't exist
            'handle file in use exception
            'verify other possible exceptions     
            Console.WriteLine(GeneralExceptionInfo(ex, filename))
        Finally
            FileClose(fileNumber)
        End Try

    End Sub

    Private Sub WriteFile(ByVal filename As String, newRecord As String)
        Dim fileNumber As Integer = FreeFile()

        Try
            FileOpen(fileNumber, filename, OpenMode.Output)
            Write(fileNumber, newRecord)

        Catch ex As Exception
            'TODO: user select file if it doesn't exist
            'handle file in use exception
            'verify other possible exceptions
            Console.WriteLine(GeneralExceptionInfo(ex, filename))
        Finally
            FileClose(fileNumber)
        End Try

    End Sub

    Function GeneralExceptionInfo(ex As Exception, fileName As String) As String
        Dim message As String = $"access to read file resulted in:{vbNewLine}{vbNewLine}" &
        $"{ex.ToString}:{vbNewLine}{vbNewLine}" &
        $"File Name{vbNewLine}'{fileName}'"
        Return message$
    End Function

End Module
