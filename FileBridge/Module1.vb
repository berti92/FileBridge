Module Module1

    Sub Main()
        Dim args = Environment.GetCommandLineArgs
        Dim checkkey = My.Computer.Registry.ClassesRoot.OpenSubKey("filebridge")
        If checkkey Is Nothing Then
            Dim rfb = My.Computer.Registry.ClassesRoot.CreateSubKey("filebridge")
            rfb.SetValue("", "URL:FileBridge Protocol")
            rfb.SetValue("URL Protocol", "")
            Dim rdefico = rfb.CreateSubKey("DefaultIcon")
            rdefico.SetValue("", "")
            rfb.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command").SetValue("", """" + args(0) + """" + " " + """" + "%1" + """")
            Environment.Exit(0)
        End If
        Try
            Dim path = Join(args, " ")
            path = Replace(Replace(path, "filebridge:", ""), args(0) + " ", "")
            path = """" + path + """"
            System.Diagnostics.Process.Start(path)
        Catch ex As Exception
            MsgBox("Unable to load file. Maybe it was deleted or no default program is defined?")
        End Try
    End Sub

End Module
