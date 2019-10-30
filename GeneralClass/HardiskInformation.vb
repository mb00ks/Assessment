Imports System.Management

Public Class HardiskInformation
    Public model, type, serialNo, volumeSerialNo, deviceId As String
    Public hdCollection As New ArrayList()

    Public Sub New()
        Me.model = ""
        Me.type = ""
        Me.serialNo = ""
        Me.deviceId = ""
        Me.volumeSerialNo = ""
    End Sub

    Public Sub initiate()
        Dim searcher As New ManagementObjectSearcher(("SELECT * FROM Win32_DiskDrive WHERE DeviceID = 'PHYSICALDRIVE0'")) ' WHERE DeviceID = 'C:\\'"))

        For Each wmi_HD As ManagementObject In searcher.Get()
            Me.model = wmi_HD("Model")
            Me.type = wmi_HD("InterfaceType")
            Me.deviceId = wmi_HD("DeviceID")
        Next
    End Sub

    Public Function extractPhysicalSerialNumber() As String
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
        Dim i As Integer = 0

        Try
            For Each wmi_HD As ManagementObject In searcher.Get
                Me.serialNo &= Strings.Trim(wmi_HD("SerialNumber").ToString) & vbCrLf
                Exit For
            Next
        Catch ex As Exception

        End Try

        'Try
        '    Dim disk As New ManagementObject("Win32_PhysicalMedia")
        '    'Me.serialNo = disk.Properties("SerialNumber").Value
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Return Me.serialNo
    End Function

    Public Function extractVolumeSerialNumber() As String
        'check harddisk's volume serial number
        Try
            Dim disk As New ManagementObject( _
                "Win32_LogicalDisk.DeviceID=""C:""")
            Me.volumeSerialNo = disk.Properties("VolumeSerialNumber").Value
        Catch ex As Exception

        End Try

        Return Me.volumeSerialNo
    End Function
End Class