Imports System.IO
Public Class AttachFile



    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click
        Try
            Dim PropID As Integer = 0
            Dim filestr As String
            Label1.Visible = True
            If AttachFrom = "Units" Then
                PropID = UnitsDisplay.TreeView1.SelectedNode.Tag
            ElseIf AttachFrom = "Land" Then
                PropID = LandDisplay.TreeView1.SelectedNode.Tag
            ElseIf AttachFrom = "Rent" Then
                PropID = RentDisplay.TreeView1.SelectedNode.Tag
            End If
            filestr = Path.GetFileName(OpenFile.FileName.ToString)
            If PropID = 0 Then
                Label1.Text = "Please first select the property."
            Else
                Dim cmd As New OleDb.OleDbCommand("Insert into FilesTable([Property ID],[File Name],[File Source]) values(" & PropID & ",'" & filestr & "','" & AttachFrom & "')", Con)
                cmd.ExecuteNonQuery()

                File.Copy(OpenFile.FileName, "C:\PropertyManager\Files\" & _
                OpenFile.FileName.Substring(OpenFile.FileName.LastIndexOf("\")))
                'The above line of code uses OpenFileDialog control to open a dialog box where you
                'can select a file to copy into the newly created directory

                Label1.Text = "File saved successfully."
            End If
        Catch ex As Exception
            Label1.Text = "File already exist."
            ' MessageBox.Show(ex.ToString)
            ' MessageBox.Show("File Already exist.", "File", MessageBoxButtons.OK)

        End Try
    End Sub

    Private Sub File_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File_button.Click
        Try
            OpenFile.ShowDialog()
            FileText.Text = OpenFile.FileName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AttachFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Visible = False
    End Sub

    Private Sub Close_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_button.Click
        Me.Close()
    End Sub

    Private Sub AttachFile_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Try
            If AttachFrom = "Units" Then
                Call UnitsDisplay.FileRet()
            ElseIf AttachFrom = "Land" Then
                Call LandDisplay.FileRet()
            ElseIf AttachFrom = "Rent" Then
                Call RentDisplay.FileRet()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class