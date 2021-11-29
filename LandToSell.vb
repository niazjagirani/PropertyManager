Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop
Imports System.Net.Mail



Public Class LandToSell
    Public Addnew As Boolean = False
    Dim UpdatePending As Boolean = False
    Dim UpdateDate As String
    Dim SelectAll As Boolean
    Dim message As String
    Dim da As New OleDbDataAdapter("Select * from LandTable", Con)
    Dim drb As New OleDbCommandBuilder(da)
    Dim ds As New DataSet

    Private Sub LandToSell_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        LandDisplay.Show()
    End Sub

    Private Sub LandToSell_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.LandTableTableAdapter.Update(Me.MerecDataSet.LandTable)
        Catch es As Exception
            MessageBox.Show("Selection is not correct.please Try Again.")
        End Try
    End Sub


    Private Sub LandToSell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LandTableTableAdapter.Fill(Me.MerecDataSet.LandTable)
        Me.ProjectsTableAdapter.Fill(Me.MerecDataSet.Projects)

        Try
            DataGrid1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            DataGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White

            Call ColumnsName()

        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try



    End Sub

    Private Sub ColumnsName()
        Try
            Dim Arr As New ArrayList

            Arr.Add(New ComboPair("[Parcel No]", "Parcel No"))
            Arr.Add(New ComboPair("[Property Type]", "Property Type"))
            Arr.Add(New ComboPair("[enteredby]", "Entered By"))
            Arr.Add(New ComboPair("[Name of Source]", "Owner Name"))
            Arr.Add(New ComboPair("[Country]", "Country"))
            Arr.Add(New ComboPair("[City]", "City"))
            Arr.Add(New ComboPair("[Master Project]", "Master Project"))
            Arr.Add(New ComboPair("[Community/project]", "Project"))
            With SearchCombo
                .DisplayMember = "Description"
                .ValueMember = "Value"
                .DataSource = Arr
            End With
        Catch ex As Exception
        End Try
    End Sub





    Private Sub ImportExcel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportExcel_Button.Click
        Try
            If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim pro As New DesktopWork

                PathLand = OFD.FileName.ToString
                If Mid(OFD.FileName, OFD.FileName.Length - 2, 3) = "xls" Then
                    If pro.LandFormat = 1 Then
                        OverWriteFrom = 2
                        OverWriteMessage.Show()
                    Else
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("The file you have selected does not have proper format", "Format message", MessageBoxButtons.OK)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ExportExcel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcel_Button.Click
        Try
            Dim eP As New DesktopWork
            eP.LandToExcel(PathLand)
        Catch es As Exception
        End Try
    End Sub

    Private Sub UpdateSheet_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSheet_button.Click
        Dim n As Integer
        Try
            For n = 0 To DataGrid1.Rows.Count - 2

                If CBool(DataGrid1.Rows(n).Cells("chkid").Value) = False Then

                ElseIf CBool(DataGrid1.Rows(n).Cells("chkid").Value) = True Then
                    DataGrid1.Rows(n).Cells("updated date").Value = Now.Month & "/" & Now.Day & "/" & Now.Year
                End If
            Next
            da.Update(ds)
        Catch es As Exception
        End Try
    End Sub



    Private Sub FTP_UNITS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FTP_UNITS.Click
        If Len(UserPass) < 2 Then
            LoginFrom = "LandAll"
            LoginMerec.Show()
        Else
            Dim msg As Integer = MessageBox.Show("Action will delete any published properties from the online server and publish the properties you have selected.", "Publish Message", MessageBoxButtons.OKCancel)
            LoginMerec.PublishLand()
        End If
    End Sub



    Private Sub DelSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelSelected.Click
        Try
            SelectAll = False
            Dim n As Integer = 0
            Dim ddnt As Integer = 0
            Dim yn As Integer
            'Verify to Selection
            For n = DataGrid1.Rows.Count - 1 To 0 Step -1 '- 2
                If DataGrid1.Rows(n).Cells("chkid").Value = True Then
                    yn = yn + 1
                Else
                End If
            Next
            If yn > 0 Then
            Else
                MessageBox.Show("You have not selected any property for delete, please select at least one property.", "Selection Message", MessageBoxButtons.OK)
                Exit Sub
            End If
            yn = 0
            n = 0
            'End Verification

            yn = MessageBox.Show("Are you sure you want to delete the selected properties?(Yes/No)", "Deletion Message", MessageBoxButtons.YesNo)
            If yn = 6 Then
                For n = DataGrid1.Rows.Count - 2 To 0 Step -1 '- 2
                    If SelectAll = True Then
                        DataGrid1.Rows.RemoveAt(n)
                    Else
                        If DataGrid1.Rows(n).Cells("chkid").Value = True Then
                            DataGrid1.Rows.RemoveAt(n)

                            ddnt = ddnt + 1
                        End If
                    End If
                Next
                If ddnt < 1 Then
                    MessageBox.Show("You did not select any properties", "Selection Message")
                End If
            Else
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Try
            Dim sql As String = "Select * from LandTable where " & SearchCombo.SelectedValue & " like '%" & searchText.Text & "%'"
            Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
            Dim cmd As New OleDbCommand(sql, Con)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "LandTable")
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.Refresh()
            da.Update(ds)

        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub PublishSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PublishSelected.Click
        Try
            If Len(UserPass) < 2 Then
                LoginFrom = "LandSelected"
                LoginMerec.Show()
            Else

                Dim msg As Integer = MessageBox.Show("Action will delete any published properties from the online server and publish the properties you have selected.", "Publish Message", MessageBoxButtons.OKCancel)

                If msg = 1 Then
                    LoginMerec.PublishSelectedLand()
                Else
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            'Clear All
            Dim n As Integer
            For Each dgvRow As DataGridViewRow In DataGrid1.Rows

                DataGrid1.Rows(n).Cells("chkid").Value = False
                n += 1
            Next
            SelectAll = False
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try

    End Sub




    Private Sub EmailSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailSelected.Click
        Try
            Dim mail As New MailMessage()

            Dim Path, path2 As String
            Dim oOutlook As New Outlook.Application()
            ' Create an instance of the MailItem 
            Dim oMailitem As Outlook.MailItem
            ' Create an instance of the Attachment 
            ' Dim oAttach As Outlook.Attachment

            oMailitem = oOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            oMailitem.To = ""
            oMailitem.CC = ""
            oMailitem.Subject = "Requested properties"
            oMailitem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML


            message = ""
            Dim n, bb As Integer
            For n = 0 To DataGrid1.Rows.Count - 2

                If CBool(DataGrid1.Rows(n).Cells("chkid").Value) = False Then

                ElseIf CBool(DataGrid1.Rows(n).Cells("chkid").Value) = True Then
                    bb += 1

                    message = message & "<br><br><b>" & bb & "#</b><br>"
                    With DataGrid1.Rows(n)
                        If .Cells(7).Value.ToString.Length >= 1 Then message = message + "<br> <b> Property Type: </b>" & .Cells(7).Value.ToString() & "<br> "
                        If .Cells(5).Value.ToString.Length >= 1 Then message = message + " <b>Master Project:</b> " & .Cells(5).Value.ToString() & "<br> "
                        If .Cells(6).Value.ToString.Length >= 1 Then message = message + " <b>Community/Project:</b> " & .Cells(6).Value.ToString() & "<br> "
                        If .Cells(8).Value.ToString.Length >= 1 Then message = message + "<b>Phase:</b> " & .Cells(8).Value.ToString() & "<br> "
                        If .Cells(11).Value.ToString.Length >= 1 Then message = message + "<b> Location: </b>" & .Cells(11).Value.ToString() & ", " & .Cells(10).Value.ToString() & "<br> "
                        If .Cells(12).Value.ToString.Length >= 1 Then message = message + " <b>Parcel No: </b>" & .Cells(12).Value.ToString() & "<br>  "
                        If .Cells(14).Value.ToString.Length >= 1 Then message = message + " <b>Allowed Height: </b>" & .Cells(14).Value.ToString() & "<br>"
                        If .Cells(16).Value.ToString.Length >= 1 Then message = message + " <b>Allowed Builtup Area: </b>" & .Cells(16).Value.ToString() & "<br> "
                        If .Cells(17).Value.ToString.Length >= 1 Then message = message + " <b>FAR: </b> " & .Cells(17).Value.ToString() & "<br> "
                        If .Cells(13).Value.ToString.Length >= 1 Then message = message + " <b>Land Area/Size: </b>" & .Cells(13).Value.ToString() & " " & .Cells(16).Value.ToString() & "<br> "
                        If .Cells(19).Value.ToString.Length >= 1 Then message = message + " <b>Original Price:</b> " & .Cells(19).Value.ToString() & " " & .Cells(20).Value.ToString() & "<br> "
                        If .Cells(18).Value.ToString.Length >= 1 Then message = message + " <b>Selling Price:</b> " & .Cells(18).Value.ToString() & " " & .Cells(20).Value.ToString() & "<br>"
                        If .Cells(28).Value.ToString.Length >= 1 Then message = message + " <b> Notes: </b>" & .Cells(28).Value.ToString() & "<br>"

                        path2 = .Cells(30).Value.ToString()
                    End With
                    Path = "C:\PropertyManager\images\" & path2


                    If path2.Length > 1 And path2 <> "PictureisnotavailableSmall.jpg" Then oMailitem.Attachments.Add(Path) ', , , "pic" + CStr(bb) + ".jpg")


                End If
            Next
            oMailitem.HTMLBody = message

            oOutlook.ActiveWindow() ' = True
            oMailitem.Display()
        Catch ex As Exception
            MessageBox.Show("MS Outlook could not detected on your computer.")
        End Try
    End Sub




    Private Sub QSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullList.Click
        Try
            ds.Clear()
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim da22 As New OleDbDataAdapter("select * from LandTable where [Community/Project] like '%" _
            & QSearchText.Text & "%' or [Master Project] like '%" & QSearchText.Text _
            & "%' or [Parcel No] = '" & QSearchText.Text & "' or [Property Type] like '%" _
            & QSearchText.Text & "%'", Con)
            da22.Fill(ds)

            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.Refresh()

        Catch ex As Exception
        End Try
    End Sub

   


   

    Private Sub DataGrid1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid1.EditingControlShowing
        On Error Resume Next
        Dim editingComboBox As ComboBox = CType(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            AddHandler editingComboBox.SelectedIndexChanged, AddressOf editingComboBox_SelectedIndexChanged
        End If

    End Sub
    Private Sub editingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
        DataGrid1.CurrentRow.Cells(6).Value = comboBox1.Text.ToString
    End Sub


    Private Sub SelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelAll.Click
        Try
            'Clear All
            Dim n As Integer = 0
            Dim tot As Integer = DataGrid1.Rows.Count - 2
            For n = 0 To tot 'Each dgvRow As DataGridViewRow In DataGrid1.Rows
                DataGrid1.Rows(n).Cells("chkid").Value = True
                'n += 1
            Next
            SelectAll = False
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try

    End Sub


    Private Sub FullListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullListButton.Click
        Try
            DataGrid1.DataSource = LandTableTableAdapter.GetData
            DataGrid1.Refresh()
        Catch es As Exception
        End Try
    End Sub

    Private Sub AddMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            WebMap.Show()
        Catch es As Exception
        End Try
    End Sub

    Private Sub ShowMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            WebMap.Save_Map.Visible = False
            WebMap.Show()
        Catch es As Exception
        End Try
    End Sub

   
    Private Sub Undo10mnts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Undo10mnts.Click
        Try
            Dim Con2 As OleDbConnection
            If BackupRet.SelectedIndex = 0 Then
                Con2 = New OleDbConnection(My.Settings.BackupTMB)
            ElseIf BackupRet.SelectedIndex = 1 Then
                Con2 = New OleDbConnection(My.Settings.BackupSS)
            ElseIf BackupRet.SelectedIndex = 2 Then
                Con2 = New OleDbConnection(My.Settings.BackupY)
            End If
            Dim cmd2 As New OleDbCommand("Select * from LandTable", Con2)
            Dim da2 As New OleDbDataAdapter(cmd2)
            Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
            Con.open()
            Dim cmd As New OleDbCommand("Select * from LandTable", Con)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds, ds2 As New DataSet
            da.Fill(ds, "LandTable")
            da2.Fill(ds2, "LandTable")

            ds.Tables.Remove(ds.Tables("LandTable"))
            ds.Tables.Add(ds2.Tables("LandTable").Copy)
            Dim cb As New OleDbCommandBuilder(da)
            
            DataGrid1.DataSource = ds.Tables("LandTable")
            DataGrid1.Refresh()
            Dim dt As DataTable = ds.Tables("LandTable")
            da.Update(ds.Tables(0))
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
End Class

