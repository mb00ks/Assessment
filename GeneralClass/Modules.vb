Public Module Modules

    Public gPathConfigMySQL As String = My.Application.Info.DirectoryPath & "\Server.config.xml" ' "\Client.config.xml"
    Public gPathConfigMySQLClient As String = My.Application.Info.DirectoryPath & "\Client.config.xml"


    Public gUsernameDB As String
    Public gPasswordDB As String
    Public gServerDB As String
    Public gDB As String

    Public gUsernameFTP As String
    Public gPasswordFTP As String
    Public gHostFTP As String

    Public gDirectory As String

    Public gUsernameLogin As String
    Public gUserIDLogin As String = "1"
    Public gUserNIP As String
    Public gUserType As String
    Public gUserLevelLogin As String

    Public gAllPath As String = My.Application.Info.DirectoryPath
    Public gUserLevel, gUserName As String

    Public gBln As Integer = Now.Month
    Public gThn As Integer = Now.Year

  

End Module
