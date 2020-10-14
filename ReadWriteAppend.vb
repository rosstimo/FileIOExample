Imports System

Module ReadWriteAppend
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub

    '<Remarks>
    'ReadFile() allows user to choose text file then reads file into TempArray
    '</Remarks>
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
        Catch ex As Exception
            'TODO: user select file if it doesn't exist
            Console.WriteLine(ex.Message)
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
        Finally
            FileClose(fileNumber)
        End Try

    End Sub

End Module
