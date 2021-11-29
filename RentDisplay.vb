Imports System.Data.OleDb
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Drawing
Imports System.IO
Imports System.Diagnostics.Process
Public Class RentDisplay
    Dim img1, img2, img3, img4 As String
    Dim imgtf1, imgtf2, imgtf3, imgtf4 As Boolean


    Private Sub RentDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AttachFrom = "Rent"
            Call FillTree()
            Dim pf As New ExtraFuntions
            pf.ProjectFuction(ProjectName, AttachFrom)
            UnitEnteredBy.Text = UserPass
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Private Sub FillTree()
        Try
            If Con.State = ConnectionState.Open Then
            Else
                Con.Open()
            End If
            Dim str As String
            TreeView1.Nodes.Clear()
            Dim daProjects As New OleDbDataAdapter("Select * from Projects where (projecttype='Rent' or projecttype='Rent') order by [project name] asc", Con)
            Dim daUnits As New OleDbDataAdapter("Select * from RentTable", Con)
            Dim daUnitsEmpty As New OleDbDataAdapter("Select * from RentTable where [Project ID]<1", Con)
            Dim dS As New DataSet
            Dim dr, dr2 As DataRow
            daProjects.Fill(dS, "Projects")
            daUnits.Fill(dS, "RentTable")
            daUnitsEmpty.Fill(dS, "Empty")

            Dim Onod As TreeNode
            For Each dr In dS.Tables("Projects").Rows
                Onod = TreeView1.Nodes.Add(dr("Project ID"), dr("Project Name").ToString)
                For Each dr2 In dS.Tables("RentTable").Rows
                    If dr("Project ID") = dr2("Project ID") Then
                        If dr2("Property ID").ToString.Length < 1 Then
                            str = "NA"
                        Else

                            str = dr2("Property ID").ToString
                        End If
                        Onod.Nodes.Add(str).Tag = dr2("Property ID")

                    End If
                Next
            Next
            Onod = TreeView1.Nodes.Add("Others")
            For Each dr2 In dS.Tables("empty").Rows
                If dr2("Property ID").ToString.Length < 1 Then
                    str = "NA"
                Else

                    str = dr2("Property ID").ToString
                End If
                Onod.Nodes.Add(str).Tag = dr2("Property ID")

            Next
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub DatainView_Unit()
        Try
            Dim daUnits As New OleDbDataAdapter("Select * from RentTable", Con)
            Dim dS As New DataSet
            Dim dr As DataRow
            daUnits.Fill(dS, "RentTable")
            For Each dr In dS.Tables("RentTable").Rows
                If dr("Property ID") = TreeView1.SelectedNode.Tag Then

                    UnitUnitType.Text = dr("Unit Type").ToString

                    UnitView.Text = dr("View").ToString
                    UnitPropertyType.Text = dr("Property type").ToString
                    UnitRooms.Text = dr("No of bedRooms").ToString
                   
                    UnitCompletionDate.Text = dr("Completion Date").ToString
                    UnitVacancyStatus.Text = dr("Status").ToString
                    UnitSellingPrice.Text = dr("Annual Price").ToString
                    UnitOriginalPrice.Text = dr("Additional Price").ToString
                    UnitCountryCurrency.Text = dr("Currency").ToString
                    UnitEnteredBy.Text = dr("Entered By").ToString
                    UnitNameOfSource.Text = dr("Name Of Source").ToString
                    AgentSeller.Text = dr("Agent/Seller").ToString
                    UnitContactNo.Text = dr("Contact No").ToString
                    UnitEmailId.Text = dr("Email").ToString
                    UnitCountry.Text = dr("Country").ToString
                    UnitCity.Text = dr("City").ToString
                    UnitBlockBuilding.Text = dr("Block/Building").ToString
                    UnitPhase.Text = dr("Phase").ToString
                    UnitsAddress.Text = dr("Address").ToString
                    UnitCommunity.Text = dr("Master Project").ToString
                    ProjectName.Text = dr("Community/Project").ToString
                    UnitBalcony.Text = dr("Balcony").ToString
                    UnitNotes1.Text = dr("Publish Notes").ToString

                    UnitNotes2.Text = dr("Hidden Notes").ToString
                    If dr("Property Map").ToString.Length > 1 Then
                        MapUrl = dr("Property Map").ToString
                    End If
                    UnitImage1.Text = dr("Main Image").ToString
                    'MessageBox.Show(TreeView1.SelectedNode.Tag)
                    If Len(UnitImage1.Text) > 2 Then
                        Pic1.Load("C:\PropertyManager\Images\" & UnitImage1.Text)
                    Else
                        Pic1.Image = Nothing
                    End If

                    UnitImage2.Text = dr("Extra Image1").ToString
                    If Len(UnitImage2.Text) > 2 Then
                        Pic2.Load("C:\PropertyManager\Images\" & UnitImage2.Text)
                    Else
                        Pic2.Image = Nothing
                    End If
                    UnitImage3.Text = dr("Extra Image2").ToString
                    If Len(UnitImage3.Text) > 2 Then
                        Pic3.Load("C:\PropertyManager\Images\" & UnitImage3.Text)
                    Else
                        Pic3.Image = Nothing
                    End If
                    UnitImage4.Text = dr("Extra Image3").ToString
                    If Len(UnitImage4.Text) > 2 Then
                        Pic4.Load("C:\PropertyManager\Images\" & UnitImage4.Text)
                    Else
                        Pic4.Image = Nothing
                    End If
                    MapUrl = dr("Property Map").ToString
                    Exit For
                Else
                    Call ClearUnits()
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("The image for this property on the address 'C:\PropertyManager\Images' not found", "Image", MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub ClearUnits()
        FileList.Items.Clear()
        Pic1.Image = Nothing
        Pic2.Image = Nothing
        Pic3.Image = Nothing
        Pic4.Image = Nothing
        UnitUnitType.Text = ""

        UnitView.Text = ""
        UnitPropertyType.Text = ""
        UnitRooms.Text = ""

        UnitCompletionDate.Text = ""
        UnitSellingPrice.Text = ""
        UnitOriginalPrice.Text = ""
        UnitCountryCurrency.Text = "AED"
        UnitEnteredBy.Text = ""
        UnitNameOfSource.Text = ""
        AgentSeller.Text = "Seller"
        UnitContactNo.Text = ""
        UnitCountry.Text = "United Arab Emirates"
        UnitCity.Text = "Dubai"
        UnitBlockBuilding.Text = ""
        UnitPhase.Text = ""
        UnitsAddress.Text = ""
        UnitCommunity.Text = ""
        UnitBalcony.Text = "Yes"
        UnitNotes1.Text = ""
        UnitEmailId.Text = ""
        UnitNotes2.Text = ""

        UnitImage1.Text = ""
        UnitImage2.Text = ""
        UnitImage3.Text = ""
        UnitImage4.Text = ""
        
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            Call FileRet()
            'MessageBox.Show(TreeView1.SelectedNode.Text)
            DatainView_Unit()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Manage_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manage_Button.Click
        Me.Close()
        UnitsToRent.Show()
    End Sub

    Private Sub Update_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Button.Click
        Try


            If UnitPropertyType.Text = Nothing Or UnitSellingPrice.Text = Nothing Or UnitNameOfSource.Text = Nothing Then
                System.Windows.Forms.MessageBox.Show("Please fill the required fields.", "Validation Problem", MessageBoxButtons.OK)
            Else
                Dim objCmd As New OleDbCommand


                ' Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
                'Dim Path As String
                Dim dt1, dt2 As String
                dt1 = FormatDateTime(Now, DateFormat.ShortDate)
                dt2 = FormatDateTime(SelDate.Value, DateFormat.ShortDate)

                'Con.Open()

                If imgtf1 = False Then
                    img1 = UnitImage1.Text
                End If
                If imgtf2 = False Then
                    img2 = UnitImage2.Text
                End If
                If imgtf3 = False Then
                    img3 = UnitImage3.Text
                End If
                If imgtf4 = False Then
                    img4 = UnitImage4.Text
                End If

                'If UnitImage1.Text.Length < 1 Then
                'img1 = "PictureisnotavailableSmall.jpg"
                ' End If
                'If UnitImage2.Text.Length < 1 Then
                'img2 = "PictureisnotavailableSmall.jpg"
                'End If
                'If UnitImage3.Text.Length < 1 Then
                'img3 = "PictureisnotavailableSmall.jpg"
                ' End If
                If UnitImage4.Text.Length < 1 Then
                    img4 = "PictureisnotavailableSmall.jpg"
                End If

                Dim pathFile As String
                pathFile = UnitImage1.Text

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
                Dim ProjID As Integer = 0
                If ProjectName.Text.ToString.Length > 0 Then
                    ProjID = CType(ProjectName.SelectedItem, ComboPair).Value
                Else
                    ProjID = 0
                End If

                Dim SQL As String
                SQL = "update RentTable set " _
                & " [Project ID]         =" & ProjID _
                 & ", [Master Project]         ='" & UnitCommunity.Text _
                 & "', [Community/project]   ='" & ProjectName.Text _
                 & "', [Property Type]       ='" & UnitPropertyType.Text _
                 & "', [Block/Building]      ='" & UnitBlockBuilding.Text _
                 & "', [Phase]               ='" & UnitPhase.Text _
                 & "', [Address]             ='" & UnitsAddress.Text _
                 & "', [Country]             ='" & UnitCountry.Text _
                & "', [City]                ='" & UnitCity.Text _
                 & "', [Unit Type]           ='" & UnitUnitType.Text _
                 & "', [No of Bedrooms]      ='" & UnitRooms.Text _
                 & "', [view]                ='" & UnitView.Text _
                 & "', [Balcony]             ='" & UnitBalcony.Text _
                 & "', [Annual Price]      ='" & UnitOriginalPrice.Text _
                 & "', [Additional Price]       ='" & UnitSellingPrice.Text _
                 & "', [Currency]            ='" & UnitCountryCurrency.Text _
                 & "', [Status]              ='" & UnitVacancyStatus.Text _
                 & "', [Completion Date]     ='" & UnitCompletionDate.Text _
                 & "', [Entered By]          ='" & UnitEnteredBy.Text _
                 & "', [agent/seller]        ='" & AgentSeller.Text _
                 & "', [Name of Source]      ='" & UnitNameOfSource.Text _
                 & "', [Contact No]          ='" & UnitContactNo.Text _
                 & "', [Email]               ='" & UnitEmailId.Text _
                 & "', [Updated Date]        ='" & Now.Date.ToShortDateString _
                 & "', [Publish Notes]       ='" & UnitNotes1.Text _
                 & "', [Hidden Notes]        ='" & UnitNotes2.Text _
                 & "', [Main Image]          ='" & img1 _
                 & "', [Extra Image1]        ='" & img2 _
                 & "', [Extra Image2]        ='" & img3 _
                 & "', [Extra Image3]        ='" & img4 _
                 & "', [Property Map]        ='" & MapUrl & "' where [Property ID]=" & TreeView1.SelectedNode.Tag
                Dim cmd As New OleDbCommand(SQL, Con)
                'MessageBox.Show(SQL)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Property updated successfully", "Update", MessageBoxButtons.OK)
                cmd.Dispose()
                Call FillTree()
            End If
            img1 = ""
            img2 = ""
            img3 = ""
            img4 = ""
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProjectAdd = True
        Project.Show()
    End Sub

    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click
        Try
            Dim propId As Long
            If UnitPropertyType.Text = Nothing Or UnitSellingPrice.Text = Nothing Or UnitNameOfSource.Text = Nothing Then
                System.Windows.Forms.MessageBox.Show("Please fill the required fields.", "Validation Problem", MessageBoxButtons.OK)
            Else
                Dim SQL As String
                Dim objCmd As New OleDbCommand

                Dim Path As String
                'Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)

                Dim dt1, dt2 As String
                dt1 = FormatDateTime(Now, DateFormat.ShortDate)
                dt2 = FormatDateTime(SelDate.Value, DateFormat.ShortDate)

                ' Con.Open()

                If imgtf1 = False Then
                    img1 = UnitImage1.Text
                End If
                If imgtf2 = False Then
                    img2 = UnitImage2.Text
                End If
                If imgtf3 = False Then
                    img3 = UnitImage3.Text
                End If
                If imgtf4 = False Then
                    img4 = UnitImage4.Text
                End If

                'If UnitImage1.Text.Length < 1 Then
                'img1 = "PictureisnotavailableSmall.jpg"
                ' End If
                'If UnitImage2.Text.Length < 1 Then
                'img2 = "PictureisnotavailableSmall.jpg"
                ' End If
                'If UnitImage3.Text.Length < 1 Then
                'img3 = "PictureisnotavailableSmall.jpg"
                '  End If
                'If UnitImage4.Text.Length < 1 Then
                'img4 = "PictureisnotavailableSmall.jpg"
                ' End If
                Dim PersonalId As Integer
                Dim vl As Integer

                SQL = "select count([Property ID])  from [RentTable]"
                objCmd = New OleDbCommand(SQL, Con)
                vl = objCmd.ExecuteScalar
                If vl > 0 Then
                    SQL = "select max([Property ID])  from [RentTable]"
                    objCmd = New OleDbCommand(SQL, Con)
                    PersonalId = CInt(objCmd.ExecuteScalar) + 1
                Else
                    PersonalId = 1
                End If
                UnitImage1.Text = img1
                UnitImage2.Text = img2
                UnitImage3.Text = img3
                UnitImage4.Text = img4

                Path = UnitImage1.Text

                If Len(Path.Trim) > 1 And imgtf1 = True Then
                    imgtf1 = False
                    imageSize(Pic1, Path, img1)
                End If
                'Image2
                Path = UnitImage2.Text
                If Len(Path.Trim) > 1 And imgtf2 = True Then
                    imgtf2 = False
                    imageSize(Pic2, Path, img2)
                End If
                'Image3
                Path = UnitImage3.Text
                If Len(Path.Trim) > 1 And imgtf3 = True Then
                    imgtf3 = False
                    imageSize(Pic3, Path, img3)
                End If
                'Image4
                Path = UnitImage4.Text
                If Len(Path.Trim) > 1 And imgtf4 = True Then
                    imgtf4 = False
                    imageSize(Pic4, Path, img4)

                End If
                Dim ProjName As Integer

                If ProjectName.Text.ToString.Length > 0 Then
                    ProjName = CType(ProjectName.SelectedItem, ComboPair).Value
                Else
                    ProjName = 0
                End If

                If PersonalId > 1 Then
                    propId = PersonalId + 1
                Else
                    propId = 10000000
                End If
                SQL = "insert into RentTable ([Project ID],[Property ID], [User ID], [Master Project], [Community/project], [Property Type], [Block/Building] " _
                                      & ", [Phase],[Address], [Country], [City], [Unit Type], [No of Bedrooms],[view] " _
                                      & ", [Balcony],[Annual Price], [Additional Price], [Currency], [Status],[Completion Date],[Entered By]" _
                                      & ", [agent/seller], [Name of Source],[Contact No], [Email], [Updated Date],[Entered Date],[Publish Notes],[Hidden Notes], [Main Image] " _
                                      & ", [Extra Image1], [Extra Image2], [Extra Image3], [Property Map])  values (" & ProjName & "," & propId & "," & PersonalId & ",'" & UnitCommunity.Text & "','" & ProjectName.Text & "','" _
                                      & UnitPropertyType.Text & "','" & UnitBlockBuilding.Text & "','" & UnitPhase.Text & "','" & UnitsAddress.Text & "','" & UnitCountry.Text & "','" & UnitCity.Text & "','" & _
                                       UnitUnitType.Text & "','" & UnitRooms.Text & "','" & UnitView.Text & "','" & _
                                       UnitBalcony.Text & "','" & UnitOriginalPrice.Text & "','" & UnitSellingPrice.Text & "','" & UnitCountryCurrency.Text & "','" & _
                                       UnitVacancyStatus.Text & "','" & UnitCompletionDate.Text & "','" & UnitEnteredBy.Text & "','" & AgentSeller.Text & "','" & UnitNameOfSource.Text & "','" & _
                                       UnitContactNo.Text & "','" & UnitEmailId.Text & "','" & Now.Date.ToShortDateString & "','" & Now.Date.ToShortDateString & "','" & UnitNotes1.Text & "','" & UnitNotes2.Text & "','" & UnitImage1.Text & "','" & _
                                       UnitImage2.Text & "','" & UnitImage3.Text & "','" & UnitImage4.Text & "','" & MapUrl & "')"

                Dim cmd As New OleDbCommand(SQL, Con)
                'MessageBox.Show(SQL)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Property successfully added to database.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
                'Con.Close()
                Call FillTree()
            End If
            img1 = ""
            img2 = ""
            img3 = ""
            img4 = ""
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub imageSize(ByVal img As PictureBox, ByVal fileName As String, ByVal OnlyName As String)
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


    Private Sub AddNew_Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNew_Map.Click

        WebMapRent.Show()
    End Sub

    Private Sub IMGbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMGbutton1.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img1 = Path.GetFileName(OpenFile.FileName.ToString)
                UnitImage1.Text = OpenFile.FileName.ToString
                Pic1.Load(OpenFile.FileName.ToString)
                imgtf1 = True
            Else
                img1 = Path.GetFileName(UnitImage1.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IMGbutton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMGbutton2.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img2 = Path.GetFileName(OpenFile.FileName.ToString)
                UnitImage2.Text = OpenFile.FileName.ToString
                Pic2.Load(OpenFile.FileName.ToString)
                imgtf2 = True
            Else
                img2 = Path.GetFileName(UnitImage2.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub IMGbutton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMGbutton3.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img3 = Path.GetFileName(OpenFile.FileName.ToString)
                UnitImage3.Text = OpenFile.FileName.ToString
                Pic3.Load(OpenFile.FileName.ToString)
                imgtf3 = True
            Else
                img3 = Path.GetFileName(UnitImage3.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub IMGbutton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMGbutton4.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img4 = Path.GetFileName(OpenFile.FileName.ToString)
                UnitImage4.Text = OpenFile.FileName.ToString
                Pic4.Load(OpenFile.FileName.ToString)
                imgtf4 = True
            Else
                img4 = Path.GetFileName(UnitImage4.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DeleteProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteProperty.Click
        Try
            Dim cmd As New OleDbCommand("delete * from RentTable where [Property ID]=" & TreeView1.SelectedNode.Tag, Con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Current Property removed", "Remove", MessageBoxButtons.OK, MessageBoxIcon.None)
            Call FillTree()
        Catch ex As Exception
            MessageBox.Show("No Property selected to delete.", "Property Delete.", MessageBoxButtons.OK)
        End Try

    End Sub



    Private Sub MousePos()
        MessageShow.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub TypeMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeMessage.Click
        MessageShow.TextBox1.Text = " Enter the unit type if provided by the developer, Example: Type II, or Type Jasmin, these types would indicate the style or layout of a unit for large developments"

        MousePos()
        MessageShow.Show()
    End Sub


    Private Sub ViewMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewMessage.Click
        MessageShow.TextBox1.Text = " Enter the view of the unit (if applicable), Example: Sea View, Park View, Road View, Golf Course View. However this field can be left empty if the unit does not have a considerable view"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub PropertyMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyMessage.Click
        MessageShow.TextBox1.Text = " Enter the type of the property, Example (Residential apartment, Office, Retail Shop ..etc.)"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub RoomsMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomsMessage.Click
        MessageShow.TextBox1.Text = "Example: 2, or 2 + Study , or 2Bed +Study+Maid room"

        MousePos()
        MessageShow.Show()
    End Sub


    Private Sub CompletionMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompletionMessage.Click
        MessageShow.TextBox1.Text = "Enter the date of completion of the property weather it is forwcasted for a future date, or is completed, you can choose this date from the provided calendar"

        MousePos()
        MessageShow.Show()
    End Sub


    Private Sub SellingMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SellingMessage.Click
        MessageShow.TextBox1.Text = "(Compulsory Field)Enter the price of the property including any outstanding installments, and excluding the transfer charges (if any) and the Commission fees (if any), Example: apartment for sale at USD 500,000, however only USD300,000 has been paid, and the outstanding is USD 200,000. additional transfer charges and commission will apply upon transferring this unit equivilent to USD 20,000. The Selling Price would be listed USD 500,000"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub OriginalMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalMessage.Click
        MessageShow.TextBox1.Text = "Enter the original price of the property here, this is only necessary if the property hasn't been fully paid for and is purchased on a payment plan (not finance), this will help the Buyer understand how much should be paid to the Seller, and how much is remaining to be paid to the Developer when the property is being sold in secondary market where a purchaser had bought the property from a developer and is re-selling to a new Buyer."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub CurrencyMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyMessage.Click
        MessageShow.TextBox1.Text = "Choose the currency you wish to enter the value in, the price will be viewed in any currency as the viewer will choose the reading currency and the system will automatically convert this value to its value in any other currency"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub EnteredBy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnteredByMessage.Click
        MessageShow.TextBox1.Text = "(compulsory Field) choose your name from the list, this wil help others refer to you when they need assistence on this property"

        MousePos()
        MessageShow.Show()
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

    Private Sub CountryMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountryMessage.Click
        MessageShow.TextBox1.Text = "Choose the country in which the property is located"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub CityMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CityMessage.Click
        MessageShow.TextBox1.Text = "Choose the City in which the property is located"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub BlockMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlockMessage.Click
        MessageShow.TextBox1.Text = "(if applicable), Enter the building or Block name, Example: SunSet Tower, or, Tower III"

        MousePos()
        MessageShow.Show()

    End Sub

    Private Sub PhaseMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhaseMessage.Click
        MessageShow.TextBox1.Text = "(if applicable), Enter the phase in which the block/unit is located in, Example: Phase II"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub CommunityMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommunityMessage.Click
        MessageShow.TextBox1.Text = "Ener the name of the suburb or community in which the property is located in, Example: Marina Complex"

        MousePos()
        MessageShow.Show()
    End Sub

   


    Private Sub NotesMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotesMessage.Click
        MessageShow.TextBox1.Text = "Enter any helpful notes on this property that will assist you and the viewer in relation to the Property, the notes in this field will be published online if you are subscribed to the (POF) Publish Online Facility. Example: finance is approved from MAK Bank, or; this units has a large garden and balcony ...etc."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub Notes2Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Notes2Message.Click
        MessageShow.TextBox1.Text = "Enter confidential notes for your reference only, these notes can only be viewed by you and the people in your company (if applicable), this data will not be published online or saved on any online servers."

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

    Private Sub Image4Message_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Image4Message.Click
        MessageShow.TextBox1.Text = "You may only upload JPG, GIF and BMP format, and the image will be automatically resized to become compatible with online browsing."

        MousePos()
        MessageShow.Show()
    End Sub


    'new messages
    Private Sub ProjectMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectMessage.Click
        MessageShow.TextBox1.Text = "specify the area name, or assigned community name the property is located in (Ex: Royal Housing Complex)"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub SourceTypeMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceTypeMessage.Click
        MessageShow.TextBox1.Text = "specify whether your source is someone who represents the Seller/Developer (i.e.: Broker, representative, secretary) or the Seller in person"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub AddressMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressMessage.Click
        MessageShow.TextBox1.Text = "specify the address of the property; Ex: 17K St. - next to Club Supermarket, Diamond Park"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub CompleteListMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompleteListMessage.Click
        MessageShow.TextBox1.Text = "click here to manage the complete list of records, this provides additional option to make group actions and publication."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub LocationMapMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationMapMessage.Click
        MessageShow.TextBox1.Text = "click here to specify the location of the property on the world map, this location will be saved on the property record, and will also allow users to view location on the published property record on estabase.com "

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub ClearFieldsMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFieldsMessage.Click
        MessageShow.TextBox1.Text = "this function will empty/clear all the text fields already filled on this page, however it will not delete this property record."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub FileListMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileListMessage.Click
        MessageShow.TextBox1.Text = "this is the list of files attached for this property record, these files are kept in a directory tagged for this property record to help you access all related documents"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub AttachListMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttachListMessage.Click
        MessageShow.TextBox1.Text = "click here to browse for files you wish to include in the Property Record Directory, this function copies files into the Property Record Directory, therefore; you may delete the original source file(s) as they are already duplicated in this directory."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub DeleteListMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteListMessage.Click
        MessageShow.TextBox1.Text = "Click here to remove a file from your (Property File List) for this (Property Record), this will permanently delete the file from the file list"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub OpenListMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenListMessage.Click
        MessageShow.TextBox1.Text = "click here to open the selected file from the (Property File List), this is a shortcut allowing you to access files related to the Property-Record."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub SaveAsMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsMessage.Click
        MessageShow.TextBox1.Text = "click here to save the information you have entered under a new property ID"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub UpdateCurrentMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCurrentMessage.Click
        MessageShow.TextBox1.Text = "click here to save the changes you have acquired on this property record, or to update the date of entry/revision of this property."

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub DeleteCurrentMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCurrentMessage.Click
        MessageShow.TextBox1.Text = "click here to permanently delete this property record from your list"

        MousePos()
        MessageShow.Show()
    End Sub

    Private Sub VacancyMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VacancyMessage.Click
        MessageShow.TextBox1.Text = "Vacant, Occupied or Underconstruction"

        MousePos()
        MessageShow.Show()

    End Sub

    Private Sub SelDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelDate.TextChanged
        Dim dt As Date = SelDate.Value
        UnitCompletionDate.Text = dt.ToShortDateString   'Format(SelDate.Text, DateFormat.ShortDate)
    End Sub


    Private Sub RefreshMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshMe.Click
        ProjectName.Items.Clear()
        Call FillTree()
        ProjectName.Text = "Please Select"
        Dim pf As New ExtraFuntions
        pf.ProjectFuction(ProjectName, AttachFrom)
    End Sub

    Private Sub Clear_Unit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear_Unit.Click
        Call ClearUnits()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ProjectAdd = False
        Project.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Dim ocom As New OleDbCommand
        Try
            If CheckBox1.Checked = True Then
                ocom.Connection = Con
                ocom.CommandText = "Select * from Projects where [Project ID]=" & CType(ProjectName.SelectedItem, ComboPair).Value

                Dim rd As OleDbDataReader = ocom.ExecuteReader
                While rd.Read()





                    If rd("Main Image") & "" <> "" Then
                        UnitImage1.Text = rd("Main Image").ToString
                        Pic1.Load("C:\PropertyManager\Images\" + rd("Main Image").ToString)
                    Else
                        ' UnitImage1.Text = "PictureisnotavailableSmall.jpg"
                        ' Pic1.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                    End If
                    If rd("Extra Image1") & "" <> "" Then
                        UnitImage2.Text = rd("Extra Image1").ToString
                        Pic2.Load("C:\PropertyManager\Images\" + rd("Extra Image1").ToString)
                    Else
                        '  UnitImage2.Text = "PictureisnotavailableSmall.jpg"
                        '  Pic2.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                    End If
                    If rd("Extra Image2") & "" <> "" Then
                        UnitImage3.Text = rd("Extra Image2").ToString
                        Pic3.Load("C:\PropertyManager\Images\" + rd("Extra Image2").ToString)
                    Else
                        'UnitImage3.Text = "PictureisnotavailableSmall.jpg"
                        ' Pic3.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                    End If
                    If rd("extra Image3") & "" <> "" Then
                        UnitImage4.Text = rd("Extra Image3").ToString
                        Pic4.Load("C:\PropertyManager\Images\" + rd("extra Image3").ToString)
                    Else
                        ' UnitImage4.Text = "PictureisnotavailableSmall.jpg"
                        ' Pic4.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                    End If
                End While
            Else


                'Pic1.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                ' UnitImage1.Text = "PictureisnotavailableSmall.jpg"

                'Pic2.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                ' UnitImage2.Text = "PictureisnotavailableSmall.jpg"

                'Pic3.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                'UnitImage3.Text = "PictureisnotavailableSmall.jpg"

                ' Pic4.Load("C:\PropertyManager\Images\" + "PictureisnotavailableSmall.jpg")
                ' UnitImage4.Text = "PictureisnotavailableSmall.jpg"
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.ToString())
            MessageBox.Show("Please select Project Name.", "Select", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub Image2Project_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Image2Project.Click
        MessageShow.TextBox1.Text = "Check this box if you wish to publish project profile & images with this property, this feature is applicable if a profile for the project has been created previousely"

        MousePos()
        MessageShow.Show()
    End Sub



    Private Sub Attach_File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If CInt(TreeView1.SelectedNode.Tag) > 0 Then
                AttachFile.Show()
                AttachFrom = "Rent"
            Else
                MessageBox.Show("Please select property for attachment", "Select File", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
        End Try
    End Sub





    Public Sub FileRet()
        Try
            Dim dr As OleDbDataReader
            Dim cmdList As New OleDbCommand("Select * from filesTable where [property id]=" & TreeView1.SelectedNode.Tag & " and [File Source] = 'Rent' ", Con)
            dr = cmdList.ExecuteReader()
            FileList.Items.Clear()
            While dr.Read
                FileList.Items.Add(dr("File Name").ToString)
            End While
            dr.Close()
            cmdList = Nothing
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub OpenAttached_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAttached.Click
        Try
            Start("c:\PropertyManager\Files\" & FileList.SelectedItem.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteAttached_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAttached.Click
        Try
            If FileList.SelectedItem.ToString.Length >= 1 Then
                File.Delete("c:\PropertyManager\Files\" & FileList.SelectedItem.ToString)
                Dim cmdList As New OleDbCommand("delete from filesTable where [property id]=" & TreeView1.SelectedNode.Tag & " and [File Source] = 'Rent' and [File Name]='" & FileList.SelectedItem.ToString & "'", Con)
                Dim int As Integer = cmdList.ExecuteNonQuery()
                MessageBox.Show(int & " File is deleted.", "Delete", MessageBoxButtons.OK)
            Else
                MessageBox.Show(" Please select atleast one file for delete.", "Delete", MessageBoxButtons.OK)
            End If
            Call FileRet()
        Catch ex As Exception
            'messagebox.Show(" 
        End Try
    End Sub

   
End Class