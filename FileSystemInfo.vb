﻿Imports System.IO
Module FileSystemInfo


    'CurrentDir()

    Sub main()
        ChangeDir()
        Console.Read()
    End Sub

    Sub CurrentDir()
        Dim path As String
        path = CurDir()
        Console.WriteLine(path)
        Try
            Console.WriteLine(CurDir("C"c))
            Console.WriteLine(CurDir("D"c))

        Catch badDir As IOException

        End Try
    End Sub

    Sub ChangeDir()
        Console.WriteLine(CurDir())
        ChDir("..") 'up one level
        Console.WriteLine(CurDir())
    End Sub


End Module
