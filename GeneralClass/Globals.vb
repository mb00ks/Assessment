Imports XmlHelper
Imports System.Security.Cryptography
Imports System.Data.Odbc
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
'Imports Microsoft.Office.Interop.Excel
Imports Npgsql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection 
Imports System.Data.OleDb
Imports System.Data.OracleClient 

Public Class Globals

    Private Shared [global] As Globals

    Public Shared ReadOnly Property Instance() As Globals
        Get
            If [global] Is Nothing Then
                [global] = New Globals
            End If
            Return [global]
        End Get
    End Property

    Public Function CheckNumber(ByVal pNumber As String) As Integer
        If IsNumeric(pNumber) And Not pNumber Is Nothing Then
            Return pNumber
        Else
            Return 0
        End If
    End Function

    Public Sub CopyText(ByVal pText As String)
        Clipboard.SetDataObject(pText, True)

        Dim data_object As IDataObject = Clipboard.GetDataObject
        data_object.GetDataPresent(pText)
    End Sub

    Public Function GetNamaBulan(ByVal pBulan As String, Optional ByVal pLongName As Boolean = True) As String
        If pLongName Then
            Select Case pBulan
                Case "1"
                    Return "Januari"
                Case "2"
                    Return "Februari"
                Case "3"
                    Return "Maret"
                Case "4"
                    Return "April"
                Case "5"
                    Return "Mei"
                Case "6"
                    Return "Juni"
                Case "7"
                    Return "Juli"
                Case "8"
                    Return "Agustus"
                Case "9"
                    Return "September"
                Case "10"
                    Return "Oktober"
                Case "11"
                    Return "November"
                Case "12"
                    Return "Desember"
                Case Else
                    Return ""
            End Select
        Else
            Select Case pBulan
                Case "1"
                    Return "Jan"
                Case "2"
                    Return "Feb"
                Case "3"
                    Return "Mar"
                Case "4"
                    Return "Apr"
                Case "5"
                    Return "Mei"
                Case "6"
                    Return "Jun"
                Case "7"
                    Return "Jul"
                Case "8"
                    Return "Agu"
                Case "9"
                    Return "Sep"
                Case "10"
                    Return "Okt"
                Case "11"
                    Return "Nov"
                Case "12"
                    Return "Des"
                Case Else
                    Return ""
            End Select
        End If
    End Function

    Public Function SaveTextToFile(ByVal strData As String, _
   ByVal FullPath As String, _
     Optional ByVal ErrInfo As String = "") As Boolean

        Dim Contents As String = ""
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try


            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message

        End Try
        Return bAns
    End Function

    Public Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If

    End Function

    Public Shared Function IsNumeric(ByVal obj As Object) As Boolean
        If obj Is Nothing Then obj = ""
        If obj Is DBNull.Value Then obj = ""
        If obj.ToString.Length > 0 Then
            Dim dummyOut As Double = New Double()
            Dim cultureInfo As System.Globalization.CultureInfo = _
                New System.Globalization.CultureInfo("en-US", True)

            Return Double.TryParse(obj, System.Globalization.NumberStyles.Any, _
                cultureInfo.NumberFormat, dummyOut)
        Else
            Return False
        End If
    End Function

    Public Function CString(ByVal MyObject As Object, Optional ByVal IsNumber As Boolean = False) As String
        Dim Output As String = ""
        Try
            If MyObject Is Nothing Then
                MyObject = New Object()
                MyObject = ""
            End If
            Output = CType(MyObject, String)
            If Output.Length > 0 Then
                Output = Replace(Output, "'", "", 1, -1)
                If IsNumber = True Then
                    Output = Replace(Output, ",", ".", 1, -1)
                End If
            End If
            If (Output.Trim.Length = 0 Or Output.Trim = "" Or Output = Nothing) And IsNumber = False Then
                Output = ""
            ElseIf (Output.Trim.Length = 0 Or Output.Trim = "" Or Output Is Nothing) And IsNumber = True Then
                Output = "0"
            End If
        Catch ex As Exception
            'ShowError(ex)
        End Try
        Return Output
    End Function

    Public Function CNull(ByVal obj As Object, Optional ByVal DefaultValue As String = "") As String
        If obj Is Nothing OrElse obj Is DBNull.Value Then Return DefaultValue
        Return obj.ToString
    End Function

    Public Function CNullNum(ByVal obj As Object, Optional ByVal DefaultValue As Double = 0) As Double
        If obj Is Nothing OrElse IsDBNull(obj) OrElse obj.ToString = "" OrElse Not IsNumeric(obj) Then Return DefaultValue
        Return obj
    End Function

    Public Function CNullDate(ByVal obj As Object) As Object
        If obj Is Nothing OrElse obj Is DBNull.Value Then Return New Date(1900, 1, 1)
        If obj Is "" Then Return "null"
        Return "'" & obj & "'"
    End Function

    Public Function CNullDate2(ByVal obj As Object) As String
        If obj Is Nothing OrElse obj Is DBNull.Value OrElse obj.ToString = "" Then Return "NULL"
        Return "to_date('" + Format(CDate(obj), "MM/dd/yyyy") + "','mm/dd/yyyy')"
    End Function

    'Public Function CheckDate(ByVal obj As Object, ByVal dtpk As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker) As Boolean
    '    If obj Is Nothing OrElse obj Is DBNull.Value Then
    '        dtpk.Checked = False
    '        Return False
    '    Else
    '        dtpk.Checked = True
    '        Return True
    '    End If
    'End Function

    

    Public Function Encrypt(ByVal pText As String, ByVal pEncrKey As String) As String

        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(pEncrKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(pText)
            Dim des As New DESCryptoServiceProvider
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    Public Function EncryptMycrpt(ByVal pText As String, ByVal pEncrKey As String) As String

        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(pEncrKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(pText)
            Dim des As New DESCryptoServiceProvider
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function Decrypt(ByVal pText As String, ByVal pDecrKey As String) As String

        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(pText.Length) As Byte
        Try
            Dim byKey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(pDecrKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(pText)
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function DecryptMycrpt(ByVal pText As String, ByVal pDecrKey As String) As String

        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(pText.Length) As Byte
        Try
            Dim byKey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(pDecrKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(pText)
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function DecryptRJ256(ByVal prm_key As String, ByVal prm_iv As String, ByVal prm_text_to_decrypt As String)

        Dim sEncryptedString As String = prm_text_to_decrypt

        Dim myRijndael As New RijndaelManaged
        myRijndael.Padding = PaddingMode.Zeros
        myRijndael.Mode = CipherMode.CBC
        myRijndael.KeySize = 256
        myRijndael.BlockSize = 256

        Dim key() As Byte
        Dim IV() As Byte
         
        key = System.Text.Encoding.ASCII.GetBytes(prm_key)
        IV = System.Text.Encoding.ASCII.GetBytes(prm_iv)

        Dim decryptor As ICryptoTransform = myRijndael.CreateDecryptor(key, IV)

 
        Dim sEncrypted As Byte() = Convert.FromBase64String(sEncryptedString)

        Dim fromEncrypt() As Byte = New Byte(sEncrypted.Length) {}

        Dim msDecrypt As New MemoryStream(sEncrypted)
        Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

        csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

        Return (System.Text.Encoding.ASCII.GetString(fromEncrypt))

    End Function


    Public Function EncryptRJ256(ByVal prm_key As String, ByVal prm_iv As String, ByVal prm_text_to_encrypt As String)

        Dim sToEncrypt As String = prm_text_to_encrypt

        Dim myRijndael As New RijndaelManaged
        myRijndael.Padding = PaddingMode.Zeros
        myRijndael.Mode = CipherMode.CBC
        myRijndael.KeySize = 256
        myRijndael.BlockSize = 256

        Dim encrypted() As Byte
        Dim toEncrypt() As Byte
        Dim key() As Byte
        Dim IV() As Byte

        key = System.Text.Encoding.ASCII.GetBytes(prm_key)
        IV = System.Text.Encoding.ASCII.GetBytes(prm_iv)

        Dim encryptor As ICryptoTransform = myRijndael.CreateEncryptor(key, IV)

        Dim msEncrypt As New MemoryStream()
        Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

        toEncrypt = System.Text.Encoding.ASCII.GetBytes(sToEncrypt)

        csEncrypt.Write(toEncrypt, 0, toEncrypt.Length)
        csEncrypt.FlushFinalBlock()

        encrypted = msEncrypt.ToArray()

        Return (Convert.ToBase64String(encrypted))

    End Function

    Public Function ConvertCurrency(ByVal pNilai As Object) As String
        Dim pHasil As String = ""
        Dim pAkhir As String = ""
        Dim pCount As Integer = 0
        pNilai = CStr(pNilai)

        For i As Integer = pNilai.Length - 1 To 0 Step -1
            If pCount Mod 3 = 0 And pCount <> 0 Then
                pHasil = pHasil & "." & pNilai(i)
                pCount = pCount + 1
                Continue For
            End If
            pHasil = pHasil & pNilai(i)
            pCount = pCount + 1
        Next

        For j As Integer = pHasil.Length - 1 To 0 Step -1
            pAkhir = pAkhir & pHasil(j)
        Next

        Return pAkhir & ",00"
    End Function

    Public Function ImportExcel(ByVal path As String) As DataTable
        Try
            Dim conn As System.Data.OleDb.OleDbConnection
            Dim btn As System.Data.OleDb.OleDbDataAdapter
            Dim ds As New System.Data.DataSet

            conn = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" & _
                "data source=" & path & ";Extended Properties=Excel 8.0;")
            btn = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", conn)
            conn.Open()
            ds = New System.Data.DataSet
            btn.Fill(ds)

            If ds.Tables(0).Rows.Count = 0 Then MsgBox("Nothing to display.", "Confirmation", MsgBoxStyle.Information) : Return Nothing : Exit Function

            Return ds.Tables(0)

        Catch ex As Exception
            MsgBox("Nothing to display.", "Confirmation", MsgBoxStyle.Information) : Return Nothing : Exit Function
        End Try
    End Function

    'Public Sub ExportExcel(ByVal path As String, ByVal fg As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
    '    Dim xlApp As Excel.Application
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim xlWorkSheet As Excel.Worksheet
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    Dim xVal As Object
    '    Dim i As Integer
    '    Dim j As Integer

    '    Try

    '        xlApp = New Excel.ApplicationClass
    '        xlWorkBook = xlApp.Workbooks.Add(misValue)
    '        xlWorkSheet = xlWorkBook.Sheets("Sheet1")

    '        For col As Integer = 0 To fg.ColumnCount - 1
    '            xlWorkSheet.Cells(1, col + 1) = fg.Columns(col).HeaderText
    '            Application.DoEvents()
    '        Next

    '        For i = 0 To fg.RowCount - 1
    '            For j = 0 To fg.ColumnCount - 1
    '                xVal = fg.Item(j, i).Value
    '                xlWorkSheet.Cells(2 + i, j + 1) = xVal
    '            Next
    '            Application.DoEvents()
    '        Next

    '        xlWorkSheet.SaveAs(path)
    '        xlWorkBook.Close()
    '        xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(xlWorkBook)
    '        releaseObject(xlWorkSheet)
    '        MsgBox("Proses ekspor excel berhasil, Lokasi File : " & path, MsgBoxStyle.Information, "Konfirmasi")

    '    Catch ex As Exception
    '        Try
    '            xlWorkBook.Close()
    '            xlApp.Quit()
    '        Catch ex2 As Exception
    '        End Try
    '        '   MsgBox("Ekspor Excel : " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    Public Function GetFileTitle(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "\" Then Exit For
            result = pFileName.Substring(i, 1) & result
        Next
        Return result
    End Function

    Public Function GetFileTitleWithoutExtension(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        Dim start As Boolean = False
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "\" Then Exit For
            If start Then result = pFileName.Substring(i, 1) & result
            If pFileName.Substring(i, 1) = "." Then start = True
        Next
        Return result
    End Function

    Public Function GetExtention(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "." Then Exit For
            result = pFileName.Substring(i, 1) & result
        Next
        Return result
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function FindURL(ByVal str As String) As String
        Dim result = ""
        For i As Integer = 0 To str.Length - 5
            If str.Substring(i, 5) = "src=""" Then
                For j As Integer = i + 6 To str.Length - 1
                    If str.Substring(j, 1) = """" Then
                        result = str.Substring(i + 5, j - i - 5)
                    End If
                Next
            End If
        Next
        Return result
    End Function

    Public Sub New()
        Dim oldCI As System.Globalization.CultureInfo = _
                           System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("en-US")
    End Sub

    Public Sub RegisterDll(ByVal filePath As String)
        Try
            ''/s' : Specifies regsvr32 to run silently and to not display any message boxes.
            Dim arg_fileinfo As String = ("/s" + (" " + ("\""" _
                        + (filePath + "\"""))))
            Dim reg As Process = New Process
            'This file registers .dll files as command components in the registry.
            reg.StartInfo.FileName = "regsvr32.exe"
            reg.StartInfo.Arguments = arg_fileinfo
            reg.StartInfo.UseShellExecute = False
            reg.StartInfo.CreateNoWindow = True
            reg.StartInfo.RedirectStandardOutput = True
            reg.Start()
            reg.WaitForExit()
            reg.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function GetAppSetting(ByVal pName As String, ByVal pDefaultValue As String) As String

        Try
            Dim m_ConfigHelper As ConfigFileHelper
            m_ConfigHelper = New ConfigFileHelper(gPathConfigMySQL)
            pDefaultValue = m_ConfigHelper.GetAppSetting(pName)
        Catch ex As Exception
            ChangeAppConfig(pName, pDefaultValue)
        End Try

        Return pDefaultValue

    End Function

    'Public Sub ChangeBackColor(ByVal host As Control, ByVal clr As Color)
    '    For Each ctrl As Control In host.Controls
    '        If TypeOf (ctrl) Is ComponentFactory.Krypton.Toolkit.KryptonTextBox Then
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonTextBox).StateActive.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonTextBox).StateDisabled.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonTextBox).StateDisabled.Content.Color1 = Color.Black
    '        ElseIf TypeOf (ctrl) Is ComponentFactory.Krypton.Toolkit.KryptonRichTextBox Then
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonRichTextBox).StateActive.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonRichTextBox).StateDisabled.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonRichTextBox).StateDisabled.Content.Color1 = Color.Black
    '        ElseIf TypeOf (ctrl) Is ComponentFactory.Krypton.Toolkit.KryptonComboBox Then
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonComboBox).StateActive.ComboBox.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonComboBox).StateDisabled.ComboBox.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonComboBox).StateDisabled.ComboBox.Content.Color1 = Color.Black
    '        ElseIf TypeOf (ctrl) Is ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Then
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker).StateActive.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker).StateDisabled.Back.Color1 = clr
    '            CType(ctrl, ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker).StateDisabled.Content.Color1 = Color.Black
    '        End If
    '        If ctrl.HasChildren Then ChangeBackColor(ctrl, clr)
    '    Next
    'End Sub

    Public Sub ChangeAppConfig(ByVal pName As String, ByVal pValue As String)

        Dim m_ConfigHelper As ConfigFileHelper
        m_ConfigHelper = New ConfigFileHelper(gPathConfigMySQL)

        Try
            m_ConfigHelper.ChangeAppSetting(pName, pValue)
        Catch ex As Exception
            Try
                m_ConfigHelper.AddAppSetting(pName, pValue)
            Catch ex2 As Exception

            End Try
        End Try

    End Sub

    
 
End Class

Public Class POSTGREMYSQL



    Private Shared [global] As POSTGREMYSQL
    Private sb As StringBuilder
    Public m_Server As String = "192.168.88.101" 'ReadConfigDecrypt("server_db_pg")
    'Public m_Server As String = "127.0.0.1" 'ReadConfigDecrypt("server_db_pg")
    Public m_Database As String = "db_cat_pelindo" 'ReadConfigDecrypt("db_pg")
    'Public m_Database As String = "db_cat_pelindo_2" 'ReadConfigDecrypt("db_pg")
    Public m_Username As String = "postgres" 'ReadConfigDecrypt("username_db_pg")
    Public m_Password As String = "root" 'ReadConfigDecrypt("password_db_pg")
    Private m_ConnectionString As String = "Server=" & m_Server & ";Port=5432;User Id=" & m_Username & ";Password=" & m_Password & ";Database=" & m_Database & ";"
    Private m_Conn As NpgsqlConnection
    Private m_Reader As NpgsqlDataReader
    Private m_Transaction As NpgsqlTransaction


    Public Function ReadConfigDecrypt(ByVal pConfigName As String) As String

        Dim m_ConfigHelper As ConfigFileHelper
        Dim pGetConfig As String
        m_ConfigHelper = New ConfigFileHelper(gPathConfigMySQL)
        pGetConfig = m_ConfigHelper.GetAppSetting(pConfigName)

        Return Globals.Instance.Decrypt(pGetConfig, "&%#@?,:*")

    End Function

    Public Sub OpenConnection()
        If m_Conn Is Nothing OrElse m_Conn.State = ConnectionState.Closed Then
            m_Conn = New NpgsqlConnection(m_ConnectionString)
            m_Conn.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If Not m_Conn Is Nothing AndAlso m_Conn.State = ConnectionState.Open Then
            m_Conn.Close()
        End If
    End Sub

    Public Shared ReadOnly Property Instance() As POSTGREMYSQL
        Get
            If [global] Is Nothing Then
                [global] = New POSTGREMYSQL
            End If
            Return [global]
        End Get
    End Property

    Public Function GetMaxId(ByVal pField As String, ByVal pTable As String, Optional ByVal pWhereClause As String = "") As Integer

        sb = New StringBuilder

        sb.Append(" SELECT MAX(" & pField & ") as maxValue FROM " & pTable)

        If Not pWhereClause = "" Then
            sb.Append(" WHERE " & pWhereClause)
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return 1

        Return Val(dt.Rows(0)!maxValue.ToString) + 1

    End Function

    Public Function CheckAvailable(ByVal pTable As String, Optional ByVal pColoumnID As String = "", Optional ByVal pID As String = "", _
                              Optional ByVal pColoumnKode As String = "", Optional ByVal pKode As String = "") As Boolean

        Dim sb As New StringBuilder

        sb.Append(" SELECT 1 FROM " & pTable & "")
        sb.Append(" WHERE 1=1")
        If pColoumnID <> "" And pID <> "" Then
            sb.Append(" AND " & pColoumnID & " = " & pID & " ")
        End If
        If pColoumnKode <> "" And pKode <> "" Then
            sb.Append(" AND " & pColoumnKode & " = '" & pKode & "'")
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt.Rows.Count <> 0 Then Return True
        Return False
    End Function

    Public Function ExecuteQuery(ByVal pSQL As String) As DataTable
        Dim dtResult As DataTable = Nothing
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn)
                Dim adapter = New NpgsqlDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Else
                Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn, m_Transaction)
                Dim adapter = New NpgsqlDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            End If

        Catch ex As Exception
        Finally
            CloseConnection()
        End Try
        Return dtResult
    End Function

    Public Function ExecuteQueryScalar(ByVal pSQL As String) As String
        Dim result As String = ""
        Dim dtResult As DataTable
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn)
                Dim adapter = New NpgsqlDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Else
                Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn, m_Transaction)
                Dim adapter = New NpgsqlDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            End If
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                result = dtResult.Rows(0)(0).ToString
            End If
        Catch ex As Exception
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQuery2(ByVal pSQL As String, _
            Optional ByVal ParamName As String = "", _
            Optional ByVal ParamValue As Byte() = Nothing, _
            Optional ByRef ErrMsg As String = "") As Boolean
        Dim result As Boolean = False
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn)

                If Not ParamName = "" AndAlso Not ParamValue Is Nothing Then
                    Dim blobParameter As New NpgsqlParameter()
                    blobParameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea
                    blobParameter.ParameterName = ParamName
                    blobParameter.Value = ParamValue
                    btn.Parameters.Add(blobParameter)
                End If

                btn.ExecuteNonQuery()
                btn.Parameters.Clear()
            Else
                Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn, m_Transaction)
                btn.ExecuteNonQuery()
            End If
            result = True

        Catch ex As Exception
            ErrMsg = ex.Message
        Finally
            CloseConnection()
        End Try
        Return result
    End Function



    Public Function GetBlobData(ByVal pSQL As String) As Byte()

        Dim result As Byte() = Nothing

        Try
            m_Conn.Close()
            m_Conn.Open()

            Dim btn As NpgsqlCommand = New NpgsqlCommand(pSQL, m_Conn)
            m_Reader = btn.ExecuteReader

            If m_Reader.Read Then
                result = m_Reader.Item(0)
            End If

            m_Reader.Close()

        Catch ex As Exception
            Return Nothing
        Finally
            m_Conn.Close()
        End Try

        Return result

    End Function

    Public Sub RefreshConnectionString()
        m_ConnectionString = "Server=" & m_Server & ";Port=5432;User Id=" & m_Username & ";Password=" & m_Password & ";Database=" & m_Database & ";"
    End Sub


End Class

Public Class MySQL

    Private Shared [global] As MySQL
    Private sb As StringBuilder
    Public m_Server As String = ReadConfigDecrypt("server_db")
    Public m_Database As String = ReadConfigDecrypt("db")
    Public m_Username As String = ReadConfigDecrypt("username_db")
    Public m_Password As String = ReadConfigDecrypt("password_db")
    Public m_ConnectionString As String = "Driver={MySQL ODBC 5.1 Driver};Server=" & m_Server & _
                                        ";Database=" & m_Database & _
                                        ";User=" & m_Username & ";Password=" & m_Password & ";Option=4;"
    Private m_Conn As New OdbcConnection(m_ConnectionString)

    Private m_Reader As OdbcDataReader

    Public Enum TypeLog
        Insert
        Update
        Delete
        Transaksi
    End Enum

    Public Shared ReadOnly Property Instance() As MySQL
        Get
            If [global] Is Nothing Then
                [global] = New MySQL
            End If
            Return [global]
        End Get
    End Property

    Public Function ReadConfigDecrypt(ByVal pConfigName As String) As String

        Dim m_ConfigHelper As ConfigFileHelper
        Dim pGetConfig As String
        m_ConfigHelper = New ConfigFileHelper(gPathConfigMySQL)

        Try
            pGetConfig = m_ConfigHelper.GetAppSetting(pConfigName)
            Return Globals.Instance.Decrypt(pGetConfig, "&%#@?,:*")
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function GetRegistryValue(ByVal key As String) As String
        Return Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", key, ""))
    End Function

    Public Sub SetRegistryValue(ByVal key As String, ByVal value As String)
        Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", key, value)
    End Sub

    Public Function GetMaxId(ByVal pField As String, ByVal pTable As String, Optional ByVal pWhereClause As String = "") As Double

        sb = New StringBuilder

        sb.Append(" SELECT MAX(" & pField & ") as maxValues FROM " & pTable)

        If Not pWhereClause = "" Then
            sb.Append(" WHERE " & pWhereClause)
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt Is Nothing Then Return 1
        If dt.Rows.Count = 0 Then Return 1

        Return Globals.Instance.CNullNum(dt.Rows(0)!maxValues.ToString) + 1

    End Function

    Public Function ExecuteQuery(ByVal pSQL As String) As DataTable

        Dim dtResult As New DataTable

        ' m_Database = "db_assessment"

        RefreshConnectionString()

        Try
            If m_Conn.State <> ConnectionState.Closed Then m_Conn.Close()
            If m_Conn.State <> ConnectionState.Open Then m_Conn.Open()

            Dim cmd As OdbcCommand

            cmd = New OdbcCommand(pSQL, m_Conn)
            Dim adapter As OdbcDataAdapter = New OdbcDataAdapter(cmd)

            adapter.Fill(dtResult)

            Return dtResult

        Catch ex As Exception
            'MessageBox.Show("Kesalahan : " & ex.Message, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            m_Conn.Close()
        End Try

    End Function

    Public Function ExecuteQueryScalar(ByVal pSQL As String) As String

        Dim dtResult As New DataTable

        Try
            If m_Conn.State <> ConnectionState.Closed Then m_Conn.Close()
            If m_Conn.State <> ConnectionState.Open Then m_Conn.Open()

            Dim cmd As OdbcCommand

            cmd = New OdbcCommand(pSQL, m_Conn)
            Dim adapter = New OdbcDataAdapter(cmd)

            adapter.Fill(dtResult)

            If dtResult.Rows.Count = 0 Then Return ""

            Return dtResult.Rows(0)(0).ToString

        Catch ex As Exception
            MessageBox.Show("Kesalahan : " & ex.Message, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            m_Conn.Close()
        End Try

    End Function

    Public Function ExecuteQuery2(ByVal pSQL As String, Optional ByVal ParamName As String = "", Optional ByVal ParamValue As Byte() = Nothing) As Boolean

        Try
            If m_Conn.State <> ConnectionState.Closed Then m_Conn.Close()
            If m_Conn.State <> ConnectionState.Open Then m_Conn.Open()

            Dim cmd As OdbcCommand

            cmd = New OdbcCommand(pSQL, m_Conn)
            Dim RecordsAffected As Integer = 0

            If Not ParamName = "" AndAlso Not ParamValue Is Nothing Then
                Dim param As New OdbcParameter(ParamName, OdbcType.Binary, ParamValue.Length)
                param.Value = ParamValue
                cmd.Parameters.Add(param)
            End If

            RecordsAffected = cmd.ExecuteNonQuery

            Return True

        Catch ex As Exception
            'MessageBox.Show("Kesalahan : " & ex.Message, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            m_Conn.Close()
        End Try

    End Function

    Public Function GetBlobData(ByVal pSQL As String) As Byte()

        Dim result As Byte() = Nothing

        Try
            m_Conn.Close()
            m_Conn.Open()

            Dim cmd As OdbcCommand = New OdbcCommand(pSQL, m_Conn)
            m_Reader = cmd.ExecuteReader

            If m_Reader.Read Then
                result = m_Reader.Item(0)
            End If

            m_Reader.Close()

        Catch ex As Exception
            Return Nothing
        Finally
            m_Conn.Close()
        End Try

        Return result

    End Function

    Public Sub LoadVariabelSetting()
        Dim sb As New StringBuilder

        sb.Append(" SELECT * FROM settingapp ")

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt.Rows.Count <> 0 Then
            gAllPath = dt.Rows(0)!all_file.ToString
        End If

    End Sub

    Public Function CheckAvailable(ByVal pTable As String, Optional ByVal pColoumnID As String = "", Optional ByVal pID As String = "", _
                                Optional ByVal pColoumnKode As String = "", Optional ByVal pKode As String = "") As Boolean

        Dim sb As New StringBuilder

        sb.Append(" SELECT 1 FROM " & pTable & "")
        sb.Append(" WHERE 1=1")
        If pColoumnID <> "" And pID <> "" Then
            sb.Append(" AND " & pColoumnID & " = " & pID & " ")
        End If
        If pColoumnKode <> "" And pKode <> "" Then
            sb.Append(" AND " & pColoumnKode & " = '" & pKode & "'")
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt.Rows.Count <> 0 Then Return True
        Return False
    End Function

    Public Function GetTableName(ByVal pSql As String, ByVal pTipe As Integer) As String
        If pSql = "" Then Return ""
        Dim result As String()
        Dim start As Boolean = False

        result = pSql.Split(" ")

        If result(0) = "" Then
            If pTipe = 1 Then
                Return result(3)
            ElseIf pTipe = 2 Then
                Return result(2)
            Else
                Return result(3)
            End If
        Else
            If pTipe = 1 Then
                Return result(2)
            ElseIf pTipe = 2 Then
                Return result(1)
            Else
                Return result(2)
            End If
        End If
    End Function

    Public Sub InsertLog(ByVal pTypeLog As TypeLog, ByVal pMessage As String)

        Select Case pTypeLog
            Case TypeLog.Insert
                pMessage = "Menambah " & pMessage
            Case TypeLog.Update
                pMessage = "Mengubah " & pMessage
            Case TypeLog.Delete
                pMessage = "Menghapus " & pMessage
            Case TypeLog.Transaksi
                pMessage = "Melakukan Transaksi " & pMessage
        End Select

        Dim pID As String = GetMaxId("log_id", "log_history")

        sb = New StringBuilder
        sb.Append(" INSERT INTO db_asset_tracking.log_history ")
        sb.Append(" (log_id, username, log_message, tgl_log)  ")
        sb.Append(" VALUES (" & pID & ", '" & gUsernameLogin & "', '" & pMessage & "', NOW()) ")

        ExecuteQuery2(sb.ToString, False)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub RefreshConnectionString()
        m_ConnectionString = "Driver={MySQL ODBC 5.1 Driver};Server=" & m_Server & _
                                        ";Database=" & m_Database & "" & _
                                        ";User=" & m_Username & ";Password=" & m_Password & ";Option=4;"
        m_Conn = New OdbcConnection(m_ConnectionString)
    End Sub

    Public Sub New()

    End Sub
End Class

Public Class ORA

    Private Shared [global] As ORA
    Private sb As StringBuilder
    Public m_Server As String = ReadConfigDecrypt("server_db")
    Public m_Database As String = ReadConfigDecrypt("db")
    Public m_Username As String = ReadConfigDecrypt("username_db")
    Public m_Password As String = ReadConfigDecrypt("password_db")
    Private m_ConnectionString As String = "Password=" & m_Password & _
                                            ";User ID=" & m_Username & _
                                            ";Data Source=(DESCRIPTION=" & _
                                            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                                            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"
    Private g_ConnectionString As String = "Provider=OraOLEDB.Oracle;" & "Password=" & m_Password & _
                                                ";User ID=" & m_Username & _
                                                ";Data Source=(DESCRIPTION=" & _
                                                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                                                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"

   
    Private m_Conn As OracleConnection
    Private gConn As OleDbConnection
    Private m_Reader As OracleDataReader
    Private m_Transaction As OracleTransaction
    Private g_Transaction As OleDbTransaction

    Public Function ReadConfigDecrypt(ByVal pConfigName As String) As String

        Dim m_ConfigHelper As ConfigFileHelper
        Dim pGetConfig As String
        m_ConfigHelper = New ConfigFileHelper(gPathConfigMySQL)
        pGetConfig = m_ConfigHelper.GetAppSetting(pConfigName)

        Return Globals.Instance.Decrypt(pGetConfig, "&%#@?,:*")

    End Function

   

    Public Sub OpenConnection()
        If m_Conn Is Nothing OrElse m_Conn.State = ConnectionState.Closed Then
            m_Conn = New OracleConnection(m_ConnectionString)
            m_Conn.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If Not m_Conn Is Nothing AndAlso m_Conn.State = ConnectionState.Open Then
            m_Conn.Close()
        End If
    End Sub


    Public Sub OpenConnection2()
        If gConn Is Nothing OrElse gConn.State = ConnectionState.Closed Then
            gConn = New OleDbConnection(g_ConnectionString)
            If gConn.State = ConnectionState.Closed Then
                gConn.Open()
            End If
        End If
    End Sub

    Public Sub CloseConnection2()
        If Not gConn Is Nothing AndAlso gConn.State = ConnectionState.Open Then
            gConn.Close()
        End If
    End Sub


    Public Shared ReadOnly Property Instance() As ORA
        Get
            If [global] Is Nothing Then
                Try
                    [global] = New ORA
                Catch ex As Exception

                End Try

            End If
            Return [global]
        End Get
    End Property

    Public Function GetMaxId(ByVal pField As String, ByVal pTable As String, Optional ByVal pWhereClause As String = "") As Integer

        sb = New StringBuilder

        sb.Append(" SELECT MAX(" & pField & ") as maxValue FROM " & pTable)

        If Not pWhereClause = "" Then
            sb.Append(" WHERE " & pWhereClause)
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return 1

        Return Val(dt.Rows(0)!maxValue.ToString) + 1

    End Function

    Public Function CheckAvailable(ByVal pTable As String, Optional ByVal pColoumnID As String = "", Optional ByVal pID As String = "", _
                              Optional ByVal pColoumnKode As String = "", Optional ByVal pKode As String = "") As Boolean

        Dim sb As New StringBuilder

        sb.Append(" SELECT 1 FROM " & pTable & "")
        sb.Append(" WHERE 1=1")
        If pColoumnID <> "" And pID <> "" Then
            sb.Append(" AND " & pColoumnID & " = " & pID & " ")
        End If
        If pColoumnKode <> "" And pKode <> "" Then
            sb.Append(" AND " & pColoumnKode & " = '" & pKode & "'")
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt.Rows.Count <> 0 Then Return True
        Return False
    End Function

    Public Function ExecuteQuery(ByVal pSQL As String) As DataTable
        Dim dtResult As DataTable = Nothing
        If m_Transaction Is Nothing Then
            Try
                OpenConnection()
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)

            Catch ex As Exception
                'MsgBox(pSQL)
                'MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        Else
            Try
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                'MsgBox(pSQL)
            Finally
            End Try
        End If
        Return dtResult
    End Function

    Public Function ExecuteQueryCommit(ByVal pSQL As String) As DataTable
        Dim dtResult As DataTable = Nothing
        If g_Transaction Is Nothing Then
            Try
                OpenConnection2()
                Dim btn As OleDbCommand = New OleDbCommand(pSQL, g_Connection)
                Dim adapter = New OleDbDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        Else
            Try
                Dim btn As OleDbCommand = New OleDbCommand(pSQL, g_Connection, g_Transaction)
                Dim adapter = New OleDbDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                ' MsgBox(ex.Message)
            Finally
            End Try
        End If
        Return dtResult
    End Function

    Public Function ExecuteQueryScalar(ByVal pSQL As String) As String
        Dim result As String = ""
        Dim dtResult As DataTable
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Else
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            End If
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                result = dtResult.Rows(0)(0).ToString
            End If
        Catch ex As Exception
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQuery2(ByVal pSQL As String, _
            Optional ByVal ParamName As String = "", _
            Optional ByVal ParamValue As Byte() = Nothing, _
            Optional ByRef ErrMsg As String = "") As Boolean
        Dim result As Boolean = False
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
               
                If Not ParamName = "" AndAlso Not ParamValue Is Nothing Then
                    Dim blobParameter As New OracleParameter()
                    blobParameter.OracleType = OracleType.Blob
                    blobParameter.ParameterName = ParamName
                    blobParameter.Value = ParamValue
                    btn.Parameters.Add(blobParameter)
                End If

                btn.ExecuteNonQuery()
                btn.Parameters.Clear()
            Else
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
                btn.ExecuteNonQuery()
            End If
            result = True

        Catch ex As Exception
            ErrMsg = ex.Message
            '   MsgBox(pSQL)
            'MsgBox(ErrMsg)
            ' MsgBox(pSQL)
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQuery2Proc(ByVal pSQL As String, _
           Optional ByVal ParamName As String = "", _
           Optional ByVal ParamValue As Byte() = Nothing, _
           Optional ByRef ErrMsg As String = "") As Boolean
        Dim result As Boolean = False
        Try
            OpenConnection()
            'If m_Transaction Is Nothing Then
            Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
            btn.CommandType = CommandType.StoredProcedure
            btn.CommandText = pSQL



            btn.ExecuteNonQuery()
            btn.Parameters.Clear()
            'Else
            'Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
            'btn.ExecuteNonQuery()
            'End If
            result = True

        Catch ex As Exception
            ErrMsg = ex.Message
            '   MsgBox(pSQL)
            'MsgBox(ErrMsg)
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQuery2ProcSinkron(ByVal pSQL As String, _
         Optional ByVal ParamName1 As String = "", _
         Optional ByVal ParamName2 As String = "", _
         Optional ByVal ParamValue1 As String = "", _
         Optional ByVal ParamValue2 As String = "", _
         Optional ByRef ErrMsg As String = "") As Boolean
        Dim result As Boolean = False
        Try
            OpenConnection()
            'If m_Transaction Is Nothing Then

            Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)

            btn.CommandType = CommandType.StoredProcedure
            btn.CommandText = pSQL
            btn.Parameters.Add(ParamName1, OracleType.VarChar)
            btn.Parameters(ParamName1).Value = ParamValue1
            btn.Parameters.Add(ParamName2, OracleType.VarChar)
            btn.Parameters(ParamName2).Value = ParamValue2

            btn.ExecuteNonQuery()
            btn.Parameters.Clear()
            'Else
            'Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
            'btn.ExecuteNonQuery()
            'End If
            result = True

        Catch ex As Exception
            ErrMsg = ex.Message
            '   MsgBox(pSQL)
            'MsgBox(ErrMsg)
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQueryCommit2(ByVal pSQL As String) As Boolean

        Try

            '    OpenConnection2()

            If g_Transaction Is Nothing Then
                Dim cmd As OleDbCommand = New OleDbCommand(pSQL, gConn)
                cmd.ExecuteNonQuery()
            Else
                Dim cmd As OleDbCommand = New OleDbCommand(pSQL, gConn, g_Transaction)
                cmd.ExecuteNonQuery()
            End If

            'CloseConnection2()

        Catch ex As Exception
            'Dim oFile As System.IO.File
            'Dim oWrite As System.IO.StreamWriter
            'oWrite.Write(ex.Message & vbCrLf)
            'oWrite.Write(ex.Message)
            'oWrite.Close()
            Return False
        End Try
        Return True
    End Function


    Public Function GetBlobData(ByVal pSQL As String) As Byte()

        Dim result As Byte() = Nothing

        Try
            m_Conn.Close()
            m_Conn.Open()

            Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
            m_Reader = btn.ExecuteReader

            If m_Reader.Read Then
                result = m_Reader.Item(0)
            End If

            m_Reader.Close()

        Catch ex As Exception
            Return Nothing
        Finally
            m_Conn.Close()
        End Try

        Return result

    End Function

    Public Sub RefreshConnectionString()
        m_ConnectionString = "Password=" & m_Password & _
                                ";User ID=" & m_Username & _
                                ";Data Source=(DESCRIPTION=" & _
                                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"

        g_ConnectionString = "Provider=OraOLEDB.Oracle;" & "Password=" & m_Password & _
                               ";User ID=" & m_Username & _
                               ";Data Source=(DESCRIPTION=" & _
                               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                               "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"

        ' MsgBox(g_ConnectionString)
    End Sub

    Public ReadOnly Property g_Connection() As OleDbConnection
        Get
            Return gConn
        End Get
    End Property

    Public Function StartEdit() As Boolean
        Dim IsStarted As Boolean
        If Not g_Transaction Is Nothing Then
            g_Transaction.Commit()
            g_Transaction = Nothing
            IsStarted = True
        Else
            IsStarted = False
            OpenConnection2()
            g_Transaction = gConn.BeginTransaction()

        End If
        Return IsStarted
    End Function

    Public Sub StopEdit(ByVal Commit As Boolean)
        If g_Transaction Is Nothing Then Exit Sub
        If Commit Then
            g_Transaction.Commit()
        Else
            g_Transaction.Rollback()
        End If
        g_Transaction = Nothing
        CloseConnection2()
    End Sub

    Public ReadOnly Property IsEditTekstualStarted()
        Get
            Return Not g_Transaction Is Nothing
        End Get
    End Property

End Class

Public Class ORAClient

    Private Shared [global] As ORA
    Private sb As StringBuilder
    Public m_Server As String = ReadConfigDecrypt("server_db")
    Public m_Database As String = ReadConfigDecrypt("db")
    Public m_Username As String = ReadConfigDecrypt("username_db")
    Public m_Password As String = ReadConfigDecrypt("password_db")
    Private m_ConnectionString As String = "Password=" & m_Password & _
                                            ";User ID=" & m_Username & _
                                            ";Data Source=(DESCRIPTION=" & _
                                            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                                            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"
    Private g_ConnectionString As String = "Provider=OraOLEDB.Oracle;" & "Password=" & m_Password & _
                                                ";User ID=" & m_Username & _
                                                ";Data Source=(DESCRIPTION=" & _
                                                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                                                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"


    Private m_Conn As OracleConnection
    Private gConn As OleDbConnection
    Private m_Reader As OracleDataReader
    Private m_Transaction As OracleTransaction
    Private g_Transaction As OleDbTransaction

    Public Function ReadConfigDecrypt(ByVal pConfigName As String) As String

        Dim m_ConfigHelper As ConfigFileHelper
        Dim pGetConfig As String
        m_ConfigHelper = New ConfigFileHelper(gPathConfigMySQL)
        pGetConfig = m_ConfigHelper.GetAppSetting(pConfigName)

        Return Globals.Instance.Decrypt(pGetConfig, "&%#@?,:*")

    End Function

    Public Sub OpenConnection()
        If m_Conn Is Nothing OrElse m_Conn.State = ConnectionState.Closed Then
            m_Conn = New OracleConnection(m_ConnectionString)
            m_Conn.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If Not m_Conn Is Nothing AndAlso m_Conn.State = ConnectionState.Open Then
            m_Conn.Close()
        End If
    End Sub


    Public Sub OpenConnection2()
        If gConn Is Nothing OrElse gConn.State = ConnectionState.Closed Then
            gConn = New OleDbConnection(g_ConnectionString)
            If gConn.State = ConnectionState.Closed Then
                gConn.Open()
            End If
        End If
    End Sub

    Public Sub CloseConnection2()
        If Not gConn Is Nothing AndAlso gConn.State = ConnectionState.Open Then
            gConn.Close()
        End If
    End Sub


    Public Shared ReadOnly Property Instance() As ORA
        Get
            If [global] Is Nothing Then
                Try
                    [global] = New ORA
                Catch ex As Exception

                End Try

            End If
            Return [global]
        End Get
    End Property

    Public Function GetMaxId(ByVal pField As String, ByVal pTable As String, Optional ByVal pWhereClause As String = "") As Integer

        sb = New StringBuilder

        sb.Append(" SELECT MAX(" & pField & ") as maxValue FROM " & pTable)

        If Not pWhereClause = "" Then
            sb.Append(" WHERE " & pWhereClause)
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return 1

        Return Val(dt.Rows(0)!maxValue.ToString) + 1

    End Function

    Public Function CheckAvailable(ByVal pTable As String, Optional ByVal pColoumnID As String = "", Optional ByVal pID As String = "", _
                              Optional ByVal pColoumnKode As String = "", Optional ByVal pKode As String = "") As Boolean

        Dim sb As New StringBuilder

        sb.Append(" SELECT 1 FROM " & pTable & "")
        sb.Append(" WHERE 1=1")
        If pColoumnID <> "" And pID <> "" Then
            sb.Append(" AND " & pColoumnID & " = " & pID & " ")
        End If
        If pColoumnKode <> "" And pKode <> "" Then
            sb.Append(" AND " & pColoumnKode & " = '" & pKode & "'")
        End If

        Dim dt As DataTable = ExecuteQuery(sb.ToString)

        If dt.Rows.Count <> 0 Then Return True
        Return False
    End Function

    Public Function ExecuteQuery(ByVal pSQL As String) As DataTable
        Dim dtResult As DataTable = Nothing
        If m_Transaction Is Nothing Then
            Try
                OpenConnection()
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                'MsgBox(pSQL)
                MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        Else
            Try
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try
        End If
        Return dtResult
    End Function

    Public Function ExecuteQueryCommit(ByVal pSQL As String) As DataTable
        Dim dtResult As DataTable = Nothing
        If g_Transaction Is Nothing Then
            Try
                OpenConnection2()
                Dim btn As OleDbCommand = New OleDbCommand(pSQL, g_Connection)
                Dim adapter = New OleDbDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        Else
            Try
                Dim btn As OleDbCommand = New OleDbCommand(pSQL, g_Connection, g_Transaction)
                Dim adapter = New OleDbDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try
        End If
        Return dtResult
    End Function

    Public Function ExecuteQueryScalar(ByVal pSQL As String) As String
        Dim result As String = ""
        Dim dtResult As DataTable
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            Else
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
                Dim adapter = New OracleDataAdapter(btn)
                Dim ds As New DataSet
                adapter.fill(ds, "table1")
                dtResult = ds.Tables(0)
            End If
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                result = dtResult.Rows(0)(0).ToString
            End If
        Catch ex As Exception
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQuery2(ByVal pSQL As String, _
            Optional ByVal ParamName As String = "", _
            Optional ByVal ParamValue As Byte() = Nothing, _
            Optional ByRef ErrMsg As String = "") As Boolean
        Dim result As Boolean = False
        Try
            OpenConnection()
            If m_Transaction Is Nothing Then
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)

                If Not ParamName = "" AndAlso Not ParamValue Is Nothing Then
                    Dim blobParameter As New OracleParameter()
                    blobParameter.OracleType = OracleType.Blob
                    blobParameter.ParameterName = ParamName
                    blobParameter.Value = ParamValue
                    btn.Parameters.Add(blobParameter)
                End If

                btn.ExecuteNonQuery()
                btn.Parameters.Clear()
            Else
                Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn, m_Transaction)
                btn.ExecuteNonQuery()
            End If
            result = True

        Catch ex As Exception
            ErrMsg = ex.Message
            'MsgBox(pSQL)
            MsgBox(ErrMsg)
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Public Function ExecuteQueryCommit2(ByVal pSQL As String) As Boolean

        Try

            '    OpenConnection2()

            If g_Transaction Is Nothing Then
                Dim cmd As OleDbCommand = New OleDbCommand(pSQL, gConn)
                cmd.ExecuteNonQuery()
            Else
                Dim cmd As OleDbCommand = New OleDbCommand(pSQL, gConn, g_Transaction)
                cmd.ExecuteNonQuery()
            End If

            'CloseConnection2()

        Catch ex As Exception
            'Dim oFile As System.IO.File
            'Dim oWrite As System.IO.StreamWriter
            'oWrite.Write(ex.Message & vbCrLf)
            'oWrite.Write(ex.Message)
            'oWrite.Close()
            Return False
        End Try
        Return True
    End Function


    Public Function GetBlobData(ByVal pSQL As String) As Byte()

        Dim result As Byte() = Nothing

        Try
            m_Conn.Close()
            m_Conn.Open()

            Dim btn As OracleCommand = New OracleCommand(pSQL, m_Conn)
            m_Reader = btn.ExecuteReader

            If m_Reader.Read Then
                result = m_Reader.Item(0)
            End If

            m_Reader.Close()

        Catch ex As Exception
            Return Nothing
        Finally
            m_Conn.Close()
        End Try

        Return result

    End Function

    Public Sub RefreshConnectionString()
        m_ConnectionString = "Password=" & m_Password & _
                                ";User ID=" & m_Username & _
                                ";Data Source=(DESCRIPTION=" & _
                                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"

        g_ConnectionString = "Provider=OraOLEDB.Oracle;" & "Password=" & m_Password & _
                               ";User ID=" & m_Username & _
                               ";Data Source=(DESCRIPTION=" & _
                               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & m_Server & ")(PORT=1521)))" & _
                               "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & m_Database & ")))"
    End Sub

    Public ReadOnly Property g_Connection() As OleDbConnection
        Get
            Return gConn
        End Get
    End Property

    Public Function StartEdit() As Boolean
        Dim IsStarted As Boolean
        If Not g_Transaction Is Nothing Then
            g_Transaction.Commit()
            g_Transaction = Nothing
            IsStarted = True
        Else
            IsStarted = False
            OpenConnection2()
            g_Transaction = gConn.BeginTransaction()

        End If
        Return IsStarted
    End Function

    Public Sub StopEdit(ByVal Commit As Boolean)
        If g_Transaction Is Nothing Then Exit Sub
        If Commit Then
            g_Transaction.Commit()
        Else
            g_Transaction.Rollback()
        End If
        g_Transaction = Nothing
        CloseConnection2()
    End Sub

    Public ReadOnly Property IsEditTekstualStarted()
        Get
            Return Not g_Transaction Is Nothing
        End Get
    End Property

End Class


Public Class Management_File

    Private Shared [global] As Management_File

    Public Shared ReadOnly Property Instance() As Management_File
        Get
            If [global] Is Nothing Then
                [global] = New Management_File
            End If
            Return [global]
        End Get
    End Property

    Public Function CopyDirectory(ByVal Src As String, ByVal Dest As String) As Boolean
        Dim Files As String()
        Dim element As String

        'add Directory Seperator Character (\) for the string concatenation shown later
        If Dest.Substring(Dest.Length - 1, 1) <> Path.DirectorySeparatorChar Then
            Dest += Path.DirectorySeparatorChar
        End If

        If Not Directory.Exists(Dest) Then Directory.CreateDirectory(Dest)

        Files = Directory.GetFileSystemEntries(Src)

        For Each element In Files
            If Directory.Exists(element) Then
                'if the current FileSystemEntry is a directory,
                'call this function recursively
                CopyDirectory(element, Dest & Path.GetFileName(element))
            Else
                'the current FileSystemEntry is a file so just copy it
                File.Copy(element, Dest & Path.GetFileName(element))
            End If
        Next
        Return True
    End Function

    Public Function GetFileTitle(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "\" Then Exit For
            result = pFileName.Substring(i, 1) & result
        Next
        Return result
    End Function

    Public Function GetFileTitleWithoutExtension(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        Dim start As Boolean = False
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "\" Then Exit For
            If start Then result = pFileName.Substring(i, 1) & result
            If pFileName.Substring(i, 1) = "." Then start = True
        Next
        Return result
    End Function

    Public Function ToTitleCase(ByVal str As String) As String
        Dim curCulture As New Globalization.CultureInfo("en-US")
        Dim tInfo As Globalization.TextInfo = curCulture.TextInfo()
        Return tInfo.ToTitleCase(str.ToLower)
    End Function

    Public Function GetFileTitleWithoutExtensionAndTitleCase(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        Dim start As Boolean = False
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "\" Then Exit For
            If start Then result = pFileName.Substring(i, 1) & result
            If pFileName.Substring(i, 1) = "." Then start = True
        Next
        Return ToTitleCase(result.Replace("_", " "))
    End Function

    Public Function GetExtention(ByVal pFileName As String) As String
        If pFileName = "" Then Return ""
        Dim result As String = ""
        For i As Integer = pFileName.Length - 1 To 0 Step -1
            If pFileName.Substring(i, 1) = "." Then Exit For
            result = pFileName.Substring(i, 1) & result
        Next
        Return result
    End Function

    Public Function CopyAllfiles(ByVal pID As String, ByVal pArrayList As ArrayList, ByVal pDestFolder As String) As Boolean
        Dim pFiles As String
        Dim pdestPath As String

        If System.IO.Directory.Exists(pDestFolder) = False Then Directory.CreateDirectory(pDestFolder)

        For Each pFiles In pArrayList
            If pFiles <> "" Then
                pdestPath = pDestFolder & "\" & pID & " - " & GetFileTitle(pFiles)
                Try
                    If System.IO.File.Exists(pdestPath) Then System.IO.File.Delete(pdestPath)
                Catch ex As Exception
                    Return False
                End Try
                System.IO.File.Copy(pFiles, pdestPath, True)
            End If
        Next
        Return True
    End Function
 
End Class