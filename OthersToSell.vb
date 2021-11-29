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



Public Class OthersToSell
    Dim img1, img2, img3, img4 As String
    Dim imgtf1, imgtf2, imgtf3, imgtf4 As Boolean
    Dim int As Integer = 0
    Public Addnew As Boolean = False
    Dim UpdatePending As Boolean = False
    Dim UpdateDate As String
    Dim SelectAll As Boolean
    Dim message As String
    Dim da As New OleDbDataAdapter("Select * from OtherTable", Con)
    Dim drb As New OleDbCommandBuilder(da)
    Dim ds As New DataSet

    Private Sub OthersToSell_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.OtherTableTableAdapter.Update(Me.MerecDataSet.OtherTable)
        Catch es As Exception
            ' MessageBox.Show(es.ToString)
        End Try
    End Sub


    Private Sub OthersToSell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try    'TODO: This line of code loads data into the 'MerecDataSet.OtherTable' table. You can move, or remove it, as needed.
            Me.OtherTableTableAdapter.Fill(Me.MerecDataSet.OtherTable)


            'Back Color
            DataGrid1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            DataGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White


            Call ColumnsName()

        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub ColumnsName()
        Try
            Dim Arr As New ArrayList

            Arr.Add(New ComboPair("[Property Type]", "Property Type"))
            Arr.Add(New ComboPair("[entered by]", "Entered By"))
            Arr.Add(New ComboPair("[Name of Source]", "Owner Name"))
            Arr.Add(New ComboPair("[Country]", "Country"))
            Arr.Add(New ComboPair("[City]", "City"))
            With SearchCombo
                .DisplayMember = "Description"
                .ValueMember = "Value"
                .DataSource = Arr
            End With
        Catch es As Exception
        End Try
    End Sub

    Private Sub ImportExcel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportExcel_Button.Click
        Try
            If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim pro As New DesktopWork

                PathOther = OFD.FileName.ToString
                If Mid(OFD.FileName, OFD.FileName.Length - 2, 3) = "xls" Then
                    If pro.OtherFormat = 1 Then
                        OverWriteFrom = 3
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
            Me.OtherTableTableAdapter.Fill(Me.MerecDataSet.OtherTable)
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ExportExcel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcel_Button.Click
        Try
            Dim eP As New DesktopWork
            eP.OtherToExcel(PathOther)
        Catch es As Exception
        End Try
    End Sub

    Private Sub UpdateSheet_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSheet_button.Click
        Dim n As Integer
        Try
            For n = 0 To DataGrid1.Rows.Count - 2

                If CBool(DataGrid1.Rows(n).Cells("chkid").Value) = False Then

                ElseIf CBool(DataGrid1.Rows(n).Cells("chkid").Value) = True Then
                    DataGrid1.Rows(n).Cells(13).Value = Now.Month & "/" & Now.Day & "/" & Now.Year
                End If
            Next
            da.Update(ds)
        Catch es As Exception

        End Try
    End Sub



    Private Sub FTP_UNITS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FTP_UNITS.Click
        If Len(UserPass) < 2 Then
            LoginFrom = "OtherAll"
            LoginMerec.Show()
        Else
            Dim msg As Integer = MessageBox.Show("Action will delete any published properties from the online server and publish the properties you have selected.", "Publish Message", MessageBoxButtons.OKCancel)
            LoginMerec.PublishOther()
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
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Try
            Dim sql As String = "Select * from OtherTable where " & SearchCombo.SelectedValue & " like '%" & searchText.Text & "%'"
            Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
            Dim cmd As New OleDbCommand(sql, Con)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "OtherTable")
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.Refresh()
            da.Update(ds)

        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub PublishSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PublishSelected.Click
        Try
            If Len(UserPass) < 2 Then
                LoginFrom = "OtherSelected"
                LoginMerec.Show()
            Else

                Dim msg As Integer = MessageBox.Show("Action will delete any published properties from the online server and publish the properties you have selected.", "Publish Message", MessageBoxButtons.OKCancel)

                If msg = 1 Then
                    LoginMerec.PublishSelectedOther()
                Else
                End If
            End If
        Catch es As Exception
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
        Dim mail As New MailMessage()

        Dim Path, path2 As String
        Dim oOutlook As New Outlook.Application()
        Dim oMailitem As Outlook.MailItem

        oMailitem = oOutlook.CreateItem(Outlook.OlItemType.olMailItem)
        oMailitem.To = ""
        oMailitem.CC = ""
        oMailitem.Subject = "Requested properties"
        oMailitem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML

        Try
            message = ""
            Dim n, bb As Integer
            For n = 0 To DataGrid1.Rows.Count - 2

                If CBool(DataGrid1.Rows(n).Cells("chkid").Value) = False Then

                ElseIf CBool(DataGrid1.Rows(n).Cells("chkid").Value) = True Then
                    bb += 1

                    message = message & "<br><br><b>" & bb & "#</b><br>"

                    If DataGrid1.Rows(n).Cells(4).Value.ToString.Length >= 1 Then message = message + "<br> <b> Property Type: </b>" & DataGrid1.Rows(n).Cells(4).Value.ToString() & "<br> "
                    If DataGrid1.Rows(n).Cells(7).Value.ToString.Length >= 1 Then message = message + "<b> Location: </b>" & DataGrid1.Rows(n).Cells(7).Value.ToString() & ", " & DataGrid1.Rows(n).Cells(6).Value.ToString() & "<br> "
                    If DataGrid1.Rows(n).Cells(15).Value.ToString.Length >= 1 Then message = message + " <b> Notes: </b>" & DataGrid1.Rows(n).Cells(15).Value.ToString() & "<br>"

                    path2 = DataGrid1.Rows(n).Cells(17).Value.ToString()

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

            Dim da22 As New OleDbDataAdapter("select * from OtherTable where [Entered By] like '%" _
            & QSearchText.Text & "%' or [Agent/Seller] like '%" & QSearchText.Text _
            & "%' or [Name Of Source] = '" & QSearchText.Text & "' or [Property Type] like '%" _
            & QSearchText.Text & "%'", Con)
            da22.Fill(ds)

            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.Refresh()
        Catch es As Exception
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

   Private Sub DataGrid1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid1.CellClick
        int = DataGrid1.CurrentRow.Index
        Call DatainView_Other()
    End Sub

    Private Sub DatainView_Other()

        Try
            'FileList.Items.Clear()
            Pic1.Image = Nothing
            Pic2.Image = Nothing
            Pic3.Image = Nothing
            Pic4.Image = Nothing
            PropertyType.Text = DataGrid1.Rows(int).Cells(4).Value.ToString
            Address.Text = DataGrid1.Rows(int).Cells(5).Value.ToString
            Country.Text = DataGrid1.Rows(int).Cells(6).Value.ToString
            City.Text = DataGrid1.Rows(int).Cells(7).Value.ToString
            EnteredBy.Text = DataGrid1.Rows(int).Cells(8).Value.ToString
            NameOfSource.Text = DataGrid1.Rows(int).Cells(9).Value.ToString
            AgentSeller.Text = DataGrid1.Rows(int).Cells(10).Value.ToString
            ContactNo.Text = DataGrid1.Rows(int).Cells(11).Value.ToString
            EmailId.Text = DataGrid1.Rows(int).Cells(12).Value.ToString
            Notes1.Text = DataGrid1.Rows(int).Cells(15).Value.ToString
            Notes2.Text = DataGrid1.Rows(int).Cells(16).Value.ToString
            MapUrl = DataGrid1.Rows(int).Cells(22).Value.ToString

            Image1.Text = DataGrid1.Rows(int).Cells(17).Value.ToString
            'MessageBox.Show(TreeView1.SelectedNode.Tag)
            If Len(Image1.Text) > 2 Then
                Pic1.Load(CurrentDir + "\Images\" & Image1.Text)
            Else
                Pic1.Image = Nothing
            End If

            Image2.Text = DataGrid1.Rows(int).Cells(18).Value.ToString
            If Len(Image2.Text) > 2 Then
                Pic2.Load(CurrentDir + "\Images\" & Image2.Text)
            Else
                Pic2.Image = Nothing
            End If
            Image3.Text = DataGrid1.Rows(int).Cells(19).Value.ToString
            If Len(Image3.Text) > 2 Then
                Pic3.Load(CurrentDir + "\Images\" & Image3.Text)
            Else
                Pic3.Image = Nothing
            End If
            Image4.Text = DataGrid1.Rows(int).Cells(20).Value.ToString
            If Len(Image4.Text) > 2 Then
                Pic4.Load(CurrentDir + "\Images\" & Image4.Text)
            Else
                Pic4.Image = Nothing
            End If

        Catch ex As Exception
            ' MessageBox.Show(ex.ToString) '"The image for this property on the address 'C:\PropertyManager\Images' not found", "Image", MessageBoxButtons.OK)
        End Try
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
            DataGrid1.DataSource = OtherTableTableAdapter.GetData
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
            Dim cmd2 As New OleDbCommand("Select * from OtherTable", Con2)
            Dim da2 As New OleDbDataAdapter(cmd2)
            Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
            Con.open()
            Dim cmd As New OleDbCommand("Select * from OtherTable", Con)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds, ds2 As New DataSet
            da.Fill(ds, "OtherTable")
            da2.Fill(ds2, "OtherTable")

            ds.Tables.Remove(ds.Tables("OtherTable"))
            ds.Tables.Add(ds2.Tables("OtherTable").Copy)
            Dim cb As New OleDbCommandBuilder(da)

            DataGrid1.DataSource = ds.Tables("OtherTable")
            DataGrid1.Refresh()
            Dim dt As DataTable = ds.Tables("OtherTable")
           
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SaveOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveOther.Click
        Try
            If PropertyType.Text = Nothing Then
                System.Windows.Forms.MessageBox.Show("Please fill the required fields.", "Validation Problem", MessageBoxButtons.OK)
            Else
                Dim SQL As String
                Dim objCmd As New OleDbCommand
                If Con.State = ConnectionState.Open Then
                Else
                    Con.Open()
                End If
                Dim Path As String
                'Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)

                Dim dt1 As String
                dt1 = FormatDateTime(Now, DateFormat.ShortDate)

                ' Con.Open()

                If imgtf1 = False Then
                    img1 = Image1.Text
                End If
                If imgtf2 = False Then
                    img2 = Image2.Text
                End If
                If imgtf3 = False Then
                    img3 = Image3.Text
                End If
                If imgtf4 = False Then
                    img4 = Image4.Text
                End If

                'If Image1.Text.Length < 1 Then
                'img1 = "PictureisnotavailableSmall.jpg"
                'End If
                'If Image2.Text.Length < 1 Then
                'img2 = "PictureisnotavailableSmall.jpg"
                ' End If
                'If Image3.Text.Length < 1 Then
                'img3 = "PictureisnotavailableSmall.jpg"
                ' End If
                'If Image4.Text.Length < 1 Then
                'img4 = "PictureisnotavailableSmall.jpg"
                ' End If
                Dim PersonalId As Integer
                Dim vl As Integer

                SQL = "select count([Property ID])  from [OtherTable]"
                objCmd = New OleDbCommand(SQL, Con)
                vl = objCmd.ExecuteScalar
                If vl > 0 Then
                    SQL = "select max([Property ID])  from [OtherTable]"
                    objCmd = New OleDbCommand(SQL, Con)
                    PersonalId = CInt(objCmd.ExecuteScalar) + 1
                Else
                    PersonalId = 1
                End If
                Image1.Text = img1
                Image2.Text = img2
                Image3.Text = img3
                Image4.Text = img4

                Path = Image1.Text

                If Len(Path.Trim) > 1 And imgtf1 = True Then
                    imgtf1 = False
                    imageSize(Pic1, Path, img1)
                End If
                'Image2
                Path = Image2.Text
                If Len(Path.Trim) > 1 And imgtf2 = True Then
                    imgtf2 = False
                    imageSize(Pic2, Path, img2)
                End If
                'Image3
                Path = Image3.Text
                If Len(Path.Trim) > 1 And imgtf3 = True Then
                    imgtf3 = False
                    imageSize(Pic3, Path, img3)
                End If
                'Image4
                Path = Image4.Text
                If Len(Path.Trim) > 1 And imgtf4 = True Then
                    imgtf4 = False
                    imageSize(Pic4, Path, img4)

                End If

                SQL = "insert into Othertable ([Property ID], [User ID], [Property Type] " _
                                      & ", [Address], [Country], [City]  " _
                                      & ", [Entered By]" _
                                      & ", [agent/seller], [Name of Source],[Contact No], [Email], [Updated Date],[Entered Date],[Publish Notes],[Hidden Notes], [Main Image] " _
                                      & ", [Extra Image1], [Extra Image2], [Extra Image3], [Property Map])  values (" & PersonalId & "," & PersonalId _
                                      & ",'" & PropertyType.SelectedItem & "','" & Address.Text & "','" & Country.SelectedItem & "','" & City.Text & "','" & _
                                        EnteredBy.Text & "','" & AgentSeller.SelectedItem & "','" & NameOfSource.Text & "','" & _
                                       ContactNo.Text & "','" & EmailId.Text & "','" & Now.Date.ToShortDateString & "','" & Now.Date.ToShortDateString & "','" & Notes1.Text & "','" & Notes2.Text & "','" & Image1.Text & "','" & _
                                       Image2.Text & "','" & Image3.Text & "','" & Image4.Text & "','" & MapUrl & "')"

                Dim cmd As New OleDbCommand(SQL, Con)
                'MessageBox.Show(SQL)
                Me.OtherTableTableAdapter.Update(Me.MerecDataSet.OtherTable)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Property successfully added to database.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
                'Con.Close()
            End If
            Me.OtherTableTableAdapter.Fill(Me.MerecDataSet.OtherTable)
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub imageSize(ByVal img As PictureBox, ByVal fileName As String, ByVal OnlyName As String)
        Try
            img.Load(fileName)
            Dim bm As New Bitmap(img.Image) 'img.Image)
            Dim x As Int32 = 400 'variable for new width size
            Dim y As Int32 = 400 'variable for new height size
            Dim h, w, nh, nw As Int32

            h = bm.Height
            w = bm.Width
            If h > w Then
                nh = h - 400
                nh = nh * 100 / h

                nw = w - (nh * w / 100)
                nh = 400
            ElseIf w > h Then
                nw = w - 400
                nw = nw * 100 / w

                nh = h - (nw * h / 100)
                nw = 400
            End If
            x = nw
            y = nh
            Dim width As Integer = Val(x) 'image width. 

            Dim height As Integer = Val(y) 'image height

            Dim thumb As New Bitmap(width, height)

            Dim g As Graphics = Graphics.FromImage(thumb)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
    bm.Height), GraphicsUnit.Pixel)

            g.Dispose()


            'image path. better to make this dynamic. I am hardcoding a path just for example sake
            thumb.Save(CurrentDir + "\images\" & OnlyName, _
    System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

            bm.Dispose()

            thumb.Dispose()
        Catch es As Exception
            'MessageBox.Show(es.ToString)
        End Try
    End Sub

    Private Sub UpdateOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateOther.Click

        Try


            If PropertyType.Text = Nothing Then
                System.Windows.Forms.MessageBox.Show("Please fill the required fields.", "Validation Problem", MessageBoxButtons.OK)
            Else
                Dim objCmd As New OleDbCommand

                If Con.State = ConnectionState.Open Then
                Else
                    Con.Open()
                End If
                ' Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
                'Dim Path As String
                Dim dt1 As String
                dt1 = FormatDateTime(Now, DateFormat.ShortDate)

                'Con.Open()

                If imgtf1 = False Then
                    img1 = Image1.Text
                End If
                If imgtf2 = False Then
                    img2 = Image2.Text
                End If
                If imgtf3 = False Then
                    img3 = Image3.Text
                End If
                If imgtf4 = False Then
                    img4 = Image4.Text
                End If

                ' If Image1.Text.Length < 1 Then
                'img1 = "PictureisnotavailableSmall.jpg"
                'End If
                'If Image2.Text.Length < 1 Then
                'img2 = "PictureisnotavailableSmall.jpg"
                'End If
                'If Image3.Text.Length < 1 Then
                'img3 = "PictureisnotavailableSmall.jpg"
                'End If
                'If Image4.Text.Length < 1 Then
                'img4 = "PictureisnotavailableSmall.jpg"
                'End If

                Dim pathFile As String
                pathFile = Image1.Text

                If Len(pathFile.Trim) > 1 And imgtf1 = True Then
                    imgtf1 = False
                    imageSize(Pic1, pathFile, img1)
                End If
                If Len(pathFile.Trim) > 1 And imgtf2 = True Then
                    imgtf2 = False
                    imageSize(Pic2, pathFile, img2)
                End If
                If Len(pathFile.Trim) > 1 And imgtf3 = True Then
                    imgtf3 = False
                    imageSize(Pic3, pathFile, img3)
                End If
                If Len(pathFile.Trim) > 1 And imgtf4 = True Then
                    imgtf4 = False
                    imageSize(Pic4, pathFile, img4)
                End If

                Dim SQL As String
                SQL = "update OtherTable set " _
                 & " [Property Type]       ='" & PropertyType.SelectedItem _
                 & "', [Address]             ='" & Address.Text _
                 & "', [Country]             ='" & Country.SelectedItem _
                 & "', [City]                ='" & City.Text _
                 & "', [Entered By]          ='" & EnteredBy.Text _
                 & "', [agent/seller]        ='" & AgentSeller.SelectedItem _
                 & "', [Name of Source]      ='" & NameOfSource.Text _
                 & "', [Contact No]          ='" & ContactNo.Text _
                 & "', [Email]               ='" & EmailId.Text _
                 & "', [Updated Date]        ='" & Now.Date.ToShortDateString _
                 & "', [Publish Notes]       ='" & Notes1.Text _
                 & "', [Hidden Notes]        ='" & Notes2.Text _
                 & "', [Main Image]          ='" & img1 _
                 & "', [Extra Image1]        ='" & img2 _
                 & "', [Extra Image2]        ='" & img3 _
                 & "', [Extra Image3]        ='" & img4 _
                 & "', [Property Map]        ='" & MapUrl & "' where [Property ID]=" & DataGrid1.Rows(DataGrid1.CurrentRow.Index).Cells(2).Value
                Dim cmd As New OleDbCommand(SQL, Con)
                'MessageBox.Show(SQL)
                Me.OtherTableTableAdapter.Update(Me.MerecDataSet.OtherTable)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Property updated successfully", "Update", MessageBoxButtons.OK)

            End If
            Me.OtherTableTableAdapter.Fill(Me.MerecDataSet.OtherTable)
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub IMGbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMG_Button1.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img1 = Path.GetFileName(OpenFile.FileName.ToString)
                Image1.Text = OpenFile.FileName.ToString
                Pic1.Load(OpenFile.FileName.ToString)
                imgtf1 = True
            Else
                img1 = Path.GetFileName(Image1.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IMGbutton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMG_Button2.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img2 = Path.GetFileName(OpenFile.FileName.ToString)
                Image2.Text = OpenFile.FileName.ToString
                Pic2.Load(OpenFile.FileName.ToString)
                imgtf2 = True
            Else
                img2 = Path.GetFileName(Image2.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub IMGbutton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMG_Button3.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img3 = Path.GetFileName(OpenFile.FileName.ToString)
                Image3.Text = OpenFile.FileName.ToString
                Pic3.Load(OpenFile.FileName.ToString)
                imgtf3 = True
            Else
                img3 = Path.GetFileName(Image3.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub IMGbutton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMG_Button4.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img4 = Path.GetFileName(OpenFile.FileName.ToString)
                Image4.Text = OpenFile.FileName.ToString
                Pic4.Load(OpenFile.FileName.ToString)
                imgtf4 = True
            Else
                img4 = Path.GetFileName(Image4.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

   
    Private Sub PropertyMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyMap.Click
        Try
            WebMapOther.Show()
        Catch es As Exception
        End Try
    End Sub

    Private Sub OwnerMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OwnerMessage.Click
        MessageShow.TextBox1.Text = "Enter the Owner name (or your name if you are the owner), or in other cases enter a reference code that refers to the Owner to assist you refer back to that owner when needed"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub ContactMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactMessage.Click
        MessageShow.TextBox1.Text = "Enter the contact number of the Owner (Seller), Example: +44-231-232324, or 009626123456"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub EmailMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailMessage.Click
        MessageShow.TextBox1.Text = "Enter the email address of the Seller (optional), this may also triger an automated email to that address indicating that the property has been listed online or send updates to this email address on the property or number of viewers if you check the box next to the email field. "

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub Image1Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Image1Message.Click
        MessageShow.TextBox1.Text = "Upload the main image for the property, this image will be selected as the Thumbnail, you may only upload JPG, GIF and BMP format, and the image will be automatically resized to become compatible with online browsing."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub Image2Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Image2Message.Click
        MessageShow.TextBox1.Text = "You may only upload JPG, GIF and BMP format, and the image will be automatically resized to become compatible with online browsing."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub Image3Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Image3Message.Click
        MessageShow.TextBox1.Text = "You may only upload JPG, GIF and BMP format, and the image will be automatically resized to become compatible with online browsing."

        MousePos()
        MessageShow.Show()
    End Sub
    Private Sub MousePos()
        MessageShow.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub Image4Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Image4Message.Click
        MessageShow.TextBox1.Text = "You may only upload JPG, GIF and BMP format, and the image will be automatically resized to become compatible with online browsing."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub NotesMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotesMessage.Click
        MessageShow.TextBox1.Text = "Enter any helpful notes on this property that will assist you and the viewer in relation to the Property, the notes in this field will be published online if you are subscribed to the (POF) Publish Online Facility. Example: finance is approved from MAK Bank, or; this units has a large garden and balcony ...etc."

        MousePos()
        MessageShow.Show()
    End Sub
    Private Sub EnteredByMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnteredByMessage.Click
        MessageShow.TextBox1.Text = "(compulsory Field) choose your name from the list, this wil help others refer to you when they need assistence on this property"

        MousePos()
        MessageShow.Show()
    End Sub
    Private Sub Notes2Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Notes2Message.Click
        MessageShow.TextBox1.Text = "Enter confidential notes for your reference only, these notes can only be viewed by you and the people in your company (if applicable), this data will not be published online or saved on any online servers."

        MousePos()
        MessageShow.Show()
    End Sub
    Private Sub CityMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CityMessage.Click
        MessageShow.TextBox1.Text = "Choose the City in which the property is located"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub PropertyMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyMessage.Click
        MessageShow.TextBox1.Text = " Enter the type of the property, Example (Residential apartment, Office, Retail Shop ..etc.)"

        MousePos()
        MessageShow.Show()
    End Sub
    Private Sub CountryMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountryMessage.Click
        MessageShow.TextBox1.Text = "Choose the country in which the property is located"

        MousePos()
        MessageShow.Show()
    End Sub

    
End Class

