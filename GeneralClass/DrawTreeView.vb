Imports System.Text
Imports System.Windows.Forms

Public Class DrawTreeView

    Private m_TreeView As TreeView
    Private m_TableName, m_ParentFieldName, m_FieldName, m_QueryStatement As String
    Private sb As StringBuilder
    Private m_DataTable As DataTable
    Private m_ShowId As Boolean
    Public gNodeSelected As TreeNode

    Public Sub Initialize(ByVal pTreeView As TreeView, _
                            ByVal pTableName As String, _
                            ByVal pFieldName As String, _
                            ByVal pParentFieldName As String, _
                            Optional ByVal pShowId As Boolean = False, _
                            Optional ByVal pStatement As String = "")

        m_TreeView = pTreeView
        m_TableName = pTableName
        m_ParentFieldName = pParentFieldName
        m_FieldName = pFieldName
        m_QueryStatement = pStatement
        m_ShowId = pShowId

        sb = New StringBuilder

        sb.Append(" SELECT " & m_FieldName & " AS ID, " & m_ParentFieldName & " AS PARENT_ID, nama AS NAMA FROM " & m_TableName & " WHERE 1 = 1 " & m_QueryStatement)

        m_DataTable = MySQL.Instance.ExecuteQuery(sb.ToString)

    End Sub

    Public Sub BuildTreeNode(ByVal pFromNode As TreeNode, ByVal pParentId As String, Optional ByVal pIdFind As String = "")

        Dim pNewNode As TreeNode
        Dim pJustTheSubNode As String


        Dim dr() As DataRow

        dr = m_DataTable.Select("PARENT_ID = '" & pParentId & "'")

        For i As Integer = 0 To dr.Length - 1

            'fixed
            If m_ShowId = True Then
                pJustTheSubNode = "(" & dr(i)!ID.ToString & ") - " & dr(i)!NAMA.ToString
            Else
                pJustTheSubNode = dr(i)!NAMA.ToString
            End If

            If (pFromNode Is Nothing) Then
                ' ----- Add a top-level node.
                pNewNode = m_TreeView.Nodes.Add(pJustTheSubNode)
                pNewNode.Tag = dr(i)!ID.ToString
            Else
                ' ----- Add a subordinate node.
                pNewNode = pFromNode.Nodes.Add(pJustTheSubNode)
                pNewNode.Tag = dr(i)!ID.ToString
            End If

            If pNewNode.Tag = pIdFind Then
                gNodeSelected = pNewNode
            End If

            Application.DoEvents()

            'recurse
            BuildTreeNode(pNewNode, dr(i)!ID.ToString, pIdFind)

        Next


    End Sub

End Class
