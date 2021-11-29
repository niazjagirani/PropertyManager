Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography

Public Class LoginMerec

    Dim UserName, UserPassword, Companynam As String
    Dim saleVal, saleVal2 As Integer
    Public RemoteSQLCon As New SqlConnection
    Dim LocalSQLcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\PropertyManager\Database\Merec.mdb")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LoginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Try
            Dim oCon = New OleDbConnection(My.Settings.MerecConnectionString)
            Dim oCom As New OleDbCommand
            oCon.open()
            oCom.Connection = oCon
            If SaveDetail.Checked = True Then
                oCom.CommandText = "Delete * from savedetail"
                oCom.ExecuteNonQuery()
                oCom.CommandText = "insert into savedetail (loginto,loginas,companyid,username,userpassword) values('" & WebServer.Text & "','" & Loginas.Text & "','" & CompanyUser.Text & "','" & LoginUser.Text & "','" & LoginPassword.Text & "')" ' from SettingInfo"
                oCom.ExecuteNonQuery()
            Else
                oCom.CommandText = "Delete * from savedetail"
                oCom.ExecuteNonQuery()
            End If

            If CompanyUser.Text.Length < 2 And LoginPassword.Text.Length < 2 Then
                Exit Sub
            Else
                If RemoteSQLCon.State = ConnectionState.Open Then
                    RemoteSQLCon.Close()
                End If
                UserName = LoginUser.Text
                UserPassword = LoginPassword.Text
                Companynam = CompanyUser.Text
                Logas = Loginas.SelectedItem
                loginme()
            End If
        Catch ex As Exception
            MessageBox.Show("There is no connection with internet or internet speed problem")
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Sub loginme()
        Try
            Dim UserCreate_Cmd As New SqlCommand
            Dim countMe, CompanyCountMe As Integer
            ServerName = "Estabase" 'WebServer.Text


            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If
            If RemoteSQLCon.State = ConnectionState.Closed Then

                RemoteSQLCon.Open()
            End If
            UserCreate_Cmd.Connection = RemoteSQLCon

            If Logas = "Administrator" Then
                ' MessageBox.Show(Logas)
                UserCreate_Cmd.CommandText = "select [User ID] from userinfo where [user name]='" & CompanyUser.Text & "' and [user password] = '" & LoginPassword.Text & "'"
                countMe = UserCreate_Cmd.ExecuteScalar
                PID_no = countMe
                'Getting COMPANY ID
                UserCreate_Cmd.CommandText = "select [Company ID] from settinginfo where [CompanyUserName]='" & CompanyUser.Text & "' and [CompanyUserPassword] = '" & LoginPassword.Text & "'"
                CompanyCountMe = UserCreate_Cmd.ExecuteScalar
                CompanyID = CompanyCountMe
                UserPass = CompanyUser.Text
            ElseIf Logas = "User" Then
                'Getting USER ID
                UserCreate_Cmd.CommandText = "select [User ID] from userinfo where [user name]='" & LoginUser.Text & "' and [user password] = '" & LoginPassword.Text & "'"
                countMe = UserCreate_Cmd.ExecuteScalar
                PID_no = countMe
                'Getting COMPANY ID
                UserCreate_Cmd.CommandText = "select [Company ID] from settinginfo where [CompanyUserName]='" & CompanyUser.Text & "'"
                CompanyCountMe = UserCreate_Cmd.ExecuteScalar
                CompanyID = CompanyCountMe
                UserPass = LoginUser.Text
            End If
            If PID_no < 1 Then
                System.Windows.Forms.MessageBox.Show("The Company ID, User Name or Password you have entered is incorrect, please try again.", "Incorrect Information", MessageBoxButtons.OK)
                Exit Sub
            Else
                System.Windows.Forms.MessageBox.Show("You are currently logged in..", "Login", MessageBoxButtons.OK)
                Me.Hide()
                Form1.Login.Text = "Logout"

                ' PublishData()
            End If
            Dim oCon = New OleDbConnection(My.Settings.MerecConnectionString)
            Dim oCom As New OleDbCommand
            oCon.open()
            oCom.Connection = oCon
            oCom.CommandText = "update settinginfo set [User ID] = " & countMe ' from SettingInfo"
            oCom.ExecuteNonQuery()

            oCom.Connection = oCon
            oCom.CommandText = "update unitstable set [User ID] = " & countMe ' from SettingInfo"
            oCom.ExecuteNonQuery()
            RemoteSQLCon.Close()
            If LoginFrom = "UnitsAll" Then
                PublishUnits()
            ElseIf LoginFrom = "UnitsSelected" Then
                PublishSelected()
            ElseIf LoginFrom = "LandAll" Then
                PublishLand()
            ElseIf LoginFrom = "LandSelected" Then
                PublishSelectedLand()
            ElseIf LoginFrom = "RentAll" Then
                PublishRent()
            ElseIf LoginFrom = "RentSelected" Then
                PublishSelectedRent()
            ElseIf LoginFrom = "OtherAll" Then
                PublishOther()
            ElseIf LoginFrom = "OtherSelected" Then
                PublishSelectedOther()
            End If
            'MessageBox.Show("Company ID: " & CompanyID & " and User ID: " & PID_no)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            'MessageBox.Show("The System is facing problems connecting to the Internet, please check you connection and try again later.", "Internet Connection", MessageBoxButtons.OK)
        End Try
    End Sub
    Sub ConMe()
        Try
            'Getting USER ID
            RemoteSQLCon.Close()

            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            Else
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If
            If RemoteSQLCon.State = ConnectionState.Closed Then
                RemoteSQLCon.Open()
            End If

            Dim Cmd As New SqlCommand
            Cmd.Connection = RemoteSQLCon
            Cmd.CommandText = "select [User ID] from userinfo where [user Name]='" & UserName & "' and [user password] = '" & UserPassword & "'"
            PID_no = Cmd.ExecuteScalar

            'Getting COMPANY ID
            Cmd.CommandText = "select [Company ID] from settinginfo where [CompanyUserName]='" & Companynam & "'"
            CompanyID = Cmd.ExecuteScalar
            RemoteSQLCon.Close()
        Catch es As Exception
        End Try
    End Sub
    Sub PublishProjects()
        Try
            RemoteSQLCon.Close()
            LocalSQLcon.Close()
            ProgressData.ListBox1.Items.Add("Connecting with Server...")
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If

            RemoteSQLCon.Open()
            LocalSQLcon.Open()
            ProgressData.ListBox1.Items.Add("Connected.")

            Dim Cmd As New SqlCommand

            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd2.Connection = LocalSQLcon
            ProgressData.ListBox1.Items.Add("Collecting Projects data from computer...")
            Cmd2.CommandText = "select * from Projects"

            Cmd.CommandText = "delete from projects where [user id]=" & PID_no & " and [company id]=" & CompanyID
            Cmd.ExecuteNonQuery()
            Dim rd As OleDbDataReader = Cmd2.ExecuteReader()
            ProgressData.ListBox1.Items.Add("Sending Projects data to the Server...")
            While rd.Read()

                Cmd.CommandText = "Insert into projects ([company id],[user id]," _
                & "[project id],[project name],[location],[publish notes]," _
                & "[main image],[extra image1],[extra image2],[extra image3]) values(" _
                & CompanyID & "," & PID_no & "," & rd("Project ID") & ",'" & rd("Project Name") & "','" & rd("Location") & "','" _
                & rd("Publish Notes") & "','" & rd("Main Image") & "','" & rd("Extra Image1") & "','" _
                & rd("Extra Image2") & "','" & rd("Extra Image2") & "')"
                Cmd.ExecuteNonQuery()

            End While
            rd.Close()
            ProgressData.Label1.Text = "Finish"
            ProgressData.ListBox1.Items.Add("Finish")
        Catch es As Exception
        End Try
    End Sub
    Public Sub PublishSelected()

        Try
            Call PublishProjects()
            RemoteSQLCon.Close()
            If RemoteSQLCon.State = ConnectionState.Closed Then
                If ServerName = "Estabase" Then
                    RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
                ElseIf ServerName = "MEREC" Then
                    RemoteSQLCon.ConnectionString = My.Settings.MerecServer
                End If
            End If
            ProgressData.ListBox1.Items.Add("Connecting with Server...")
            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected!")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd.CommandText = "delete from unitstable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            sqL = " select * from UnitsTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from UnitsTable"
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            Rda.Fill(ds, "RemoteUnitsTable")
            Dim Rtable As DataTable = ds.Tables("RemoteUnitsTable")
            Dim rRow As DataRow = Rtable.NewRow


            Dim countMe As Integer = 0
            ProgressData.Show()
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.Label1.Text = "Property Records uploading..."
            Dim n As Integer


            For n = 0 To UnitsToSell.DataGrid1.Rows.Count - 1
                If UnitsToSell.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If UnitsToSell.DataGrid1.Rows(n).Cells("pub").Value = 1 Then
                        countMe = countMe + 1
                    End If
                End If
            Next
            ProgressData.ProgressBar1.Maximum = countMe ' Rc
            countMe = 1
            'Cmd2.Connection = LocalSQLcon
            n = 0
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            For n = 0 To UnitsToSell.DataGrid1.Rows.Count - 1 'Each row As DataRow In DataGrid1.Rows 'Ltable.Rows
                My.Application.DoEvents()


                If UnitsToSell.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If UnitsToSell.DataGrid1.Rows(n).Cells("pub").Value = 1 Then

                        My.Application.DoEvents()
                        ProgressData.ProgressBar1.Value = countMe
                        rRow("Company ID") = CompanyID
                        rRow("User ID") = PID_no
                        rRow("Project ID") = UnitsToSell.DataGrid1.Rows(n).Cells(2).Value.ToString
                        rRow("Property ID") = CompanyID & PID_no & UnitsToSell.DataGrid1.Rows(n).Cells(3).Value
                        rRow("Master Project") = UnitsToSell.DataGrid1.Rows(n).Cells(5).Value
                        rRow("Community/Project") = UnitsToSell.DataGrid1.Rows(n).Cells(6).Value
                        rRow("Property Type") = UnitsToSell.DataGrid1.Rows(n).Cells(7).Value
                        rRow("Block/Building") = UnitsToSell.DataGrid1.Rows(n).Cells(8).Value
                        rRow("Phase") = UnitsToSell.DataGrid1.Rows(n).Cells(9).Value
                        rRow("Address") = UnitsToSell.DataGrid1.Rows(n).Cells(10).Value
                        rRow("Country") = UnitsToSell.DataGrid1.Rows(n).Cells(11).Value
                        rRow("City") = UnitsToSell.DataGrid1.Rows(n).Cells(12).Value
                        ' rRow("Unit No") = UnitsToSell.DataGrid1.Rows(n).Cells(13).Value
                        rRow("Unit Type") = UnitsToSell.DataGrid1.Rows(n).Cells(14).Value
                        rRow("No Of BedRooms") = UnitsToSell.DataGrid1.Rows(n).Cells(15).Value
                        rRow("Floor") = UnitsToSell.DataGrid1.Rows(n).Cells(16).Value
                        rRow("View") = UnitsToSell.DataGrid1.Rows(n).Cells(17).Value
                        rRow("Area") = UnitsToSell.DataGrid1.Rows(n).Cells(18).Value
                        rRow("Land Area") = UnitsToSell.DataGrid1.Rows(n).Cells(19).Value
                        rRow("SqrFT/SqrMt") = UnitsToSell.DataGrid1.Rows(n).Cells(20).Value
                        rRow("Balcony") = UnitsToSell.DataGrid1.Rows(n).Cells(21).Value
                        If UnitsToSell.DataGrid1.Rows(n).Cells(23).Value.ToString = "" Then
                            saleVal = 0
                        Else
                            saleVal = Math.Round(CDbl(UnitsToSell.DataGrid1.Rows(n).Cells(23).Value.ToString))
                        End If
                        If UnitsToSell.DataGrid1.Rows(n).Cells(22).Value.ToString = "" Then
                            saleVal2 = 0
                        Else
                            saleVal2 = Math.Round(CDbl(UnitsToSell.DataGrid1.Rows(n).Cells(22).Value.ToString))
                        End If
                        rRow("Selling Price") = saleVal
                        rRow("Original Price") = saleVal2

                        rRow("Currency") = UnitsToSell.DataGrid1.Rows(n).Cells(24).Value
                        rRow("Status") = UnitsToSell.DataGrid1.Rows(n).Cells(25).Value
                        rRow("Completion Date") = UnitsToSell.DataGrid1.Rows(n).Cells(26).Value
                        rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                        rRow("Agent/Seller") = UnitsToSell.DataGrid1.Rows(n).Cells(28).Value
                        rRow("Updated Date") = Now.ToShortDateString 'UnitsToSell.DataGrid1.Rows(n).Cells(32).Value.ToString
                        rRow("Entered Date") = UnitsToSell.DataGrid1.Rows(n).Cells(33).Value.ToString
                        rRow("Publish Notes") = UnitsToSell.DataGrid1.Rows(n).Cells(34).Value
                        rRow("Main Image") = "\UserImages\" & UserPass & "\" & UnitsToSell.DataGrid1.Rows(n).Cells(36).Value
                        rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & UnitsToSell.DataGrid1.Rows(n).Cells(37).Value
                        rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & UnitsToSell.DataGrid1.Rows(n).Cells(38).Value
                        rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & UnitsToSell.DataGrid1.Rows(n).Cells(39).Value
                        rRow("Property Map") = UnitsToSell.DataGrid1.Rows(n).Cells(41).Value

                        Rtable.Rows.Add(rRow)
                        Rda.Update(ds, "RemoteUnitsTable")
                        rRow = Rtable.NewRow()
                        countMe = countMe + 1
                    End If
                End If

            Next
            ProgressData.Label1.Text = "Property Records completed..."
            ProgressData.ListBox1.Items.Add("Uploading Completed...")
            ProgressData.ListBox1.Items.Add(countMe & " Properties Uploaded...")
            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            ' System.Windows.Forms.MessageBox.Show(countMe & "Property Added")
            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"

                ConMe()
                PublishSelected()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
   
    Public Sub PublishUnits()
        Try
            '  If RemoteSQLCon.State = ConnectionState.Closed Then
            Call PublishProjects()
            RemoteSQLCon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If
            ' End If
            ProgressData.Show()
            ProgressData.ListBox1.Items.Add("Connection with Server...")
            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected.")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd2.Connection = LocalSQLcon
            If Logas = "Administrator" Then
                ProgressData.Label1.Text = "Company Information uploading..."
                ProgressData.ListBox1.Items.Add("Company Information Uploading...")
                Cmd2.CommandText = "select * from settinginfo"
                Dim rd As OleDbDataReader = Cmd2.ExecuteReader()
                While rd.Read()

                    Cmd.CommandText = "update settinginfo set PersonalTitle ='" & rd("PersonalTitle") & "', PersonalFirstName='" & rd("PersonalFirstName") _
                    & "', PersonalMiddleName='" & rd("PersonalMiddleName") & "', PersonalLastName='" & rd("PersonalLastName") _
                    & "',  PersonalTelephoneNo='" & rd("PersonalTelephoneNo") & "', PersonalEmail ='" & rd("PersonalEmail") _
                    & "', CompanyName='" & rd("CompanyName") & "', CompanyBusinessType='" & rd("companybusinesstype") _
                    & "', CompanyAddress='" & rd("CompanyAddress") & "', CompanyAddress2='" & rd("CompanyAddress2") _
                    & "', CompanyTelephoneNo='" & rd("CompanyTelephoneNo") & "', CompanyFaxNo='" & rd("CompanyFaxNo") _
                    & "', CompanyWebSite='" & rd("Companywebsite") & "', CompanyEmail='" & rd("CompanyEmail") _
                    & "', CompanyLogo='" & rd("CompanyLogo") & "', RegionalCountry='" & rd("RegionalCountry") _
                    & "', RegionalCity='" & rd("RegionalCity") & "', RegionalLanguage='" & rd("RegionalLanguage") _
                    & "', RegionalCurrency='" & rd("RegionalCurrency") & "', RegionalUnitFormats='" & rd("RegionalUnitFormats") _
                    & "', RegionalPostalCode='" & rd("RegionalPostalCode") & "',RegionalListedCountry='" & rd("RegionalListedCountry") _
                    & "', RegionalListedCity='" & rd("RegionalListedCity") & "', ServiceCommission='" & rd("ServiceCommission") & "' where [company id]=" & CompanyID

                    Cmd.ExecuteNonQuery()
                End While
                rd.Close()
                ProgressData.Label1.Text = "Finish"
                ProgressData.ListBox1.Items.Add("Finish")
            End If
            Cmd.CommandText = "delete from unitstable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            ' End If
            sqL = " select * from UnitsTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from UnitsTable"
            Dim Lda As New OleDb.OleDbDataAdapter(sqL2, LocalSQLcon)
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            ' Dim cb As New SqlCommandBuilder
            'cb.DataAdapter = Rda

            Rda.Fill(ds, "RemoteUnitsTable")
            Lda.Fill(ds, "LocalUnitsTable")
            Dim Rtable As DataTable = ds.Tables("RemoteUnitsTable")
            Dim Ltable As DataTable = ds.Tables("LocalUnitsTable")
            Dim rRow As DataRow = Rtable.NewRow
            Dim Rc As Integer = Ltable.Rows.Count
            Dim countMe As Integer = 1
            ProgressData.Show()
            ProgressData.ProgressBar1.Maximum = Rc
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            ProgressData.Label1.Text = "Properties uploading..."

            Cmd2.Connection = LocalSQLcon
            For Each row As DataRow In Ltable.Rows
                My.Application.DoEvents()
                ProgressData.ProgressBar1.Value = countMe
                rRow("Company ID") = CompanyID
                rRow("User ID") = PID_no
                rRow("Project ID") = CInt(row("Project ID").ToString)
                rRow("Property ID") = CompanyID & PID_no & CInt(row("Property ID").ToString)
                rRow("Master Project") = row("Master Project").ToString
                rRow("Community/Project") = row("Community/Project").ToString
                rRow("Property Type") = row("Property Type").ToString
                rRow("Block/Building") = row("Block/Building").ToString
                rRow("Phase") = row("Phase").ToString
                rRow("Address") = row("Address").ToString
                rRow("Country") = row("Country").ToString
                rRow("City") = row("City").ToString
                ' rRow("Unit No") = row("Unit No").ToString
                rRow("Unit Type") = row("Unit Type").ToString
                rRow("No Of BedRooms") = row("No Of BedRooms").ToString
                rRow("Floor") = row("Floor").ToString
                rRow("View") = row("View").ToString
                rRow("Area") = row("Area").ToString
                rRow("Land Area") = row("Land Area").ToString
                rRow("SqrFT/SqrMt") = row("SqrFt/SqrMt").ToString
                rRow("Balcony") = row("Balcony").ToString
                If row("Selling Price").ToString = "" Then
                    saleVal = 0
                Else
                    saleVal = Math.Round(CDbl(row("Selling Price")))
                End If
                If row("Original Price").ToString = "" Then
                    saleVal2 = 0
                Else
                    saleVal2 = Math.Round(CDbl(row("Original Price")))
                End If
                rRow("Selling Price") = saleVal
                rRow("Original Price") = saleVal2
                rRow("Currency") = row("Currency").ToString
                rRow("Status") = row("Status").ToString
                rRow("Completion Date") = row("completion date").ToString
                rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                rRow("Agent/Seller") = row("Agent/Seller").ToString
                rRow("Updated Date") = Now.ToShortDateString 'CDate(row("updated date").ToString)
                rRow("Entered Date") = row("Entered date").ToString
                rRow("Publish Notes") = row("Publish Notes").ToString
                rRow("Main Image") = "\UserImages\" & UserPass & "\" & row("Main Image").ToString
                rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & row("Extra Image1").ToString
                rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & row("Extra Image2").ToString
                rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & row("Extra Image3").ToString
                rRow("Property Map") = row("Property Map").ToString
                Rtable.Rows.Add(rRow)
                Rda.Update(ds, "RemoteUnitsTable")
                rRow = Rtable.NewRow()
                countMe = countMe + 1

            Next
            ProgressData.Label1.Text = "Finish..."
            ProgressData.ListBox1.Items.Add("Finish")

            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishUnits()
            End If

        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub PublishSelectedLand()

        Try

            Call PublishProjects()
            RemoteSQLCon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If
            ProgressData.ListBox1.Items.Add("Connection with Server...")

            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected!")

            Dim sqL As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd.CommandText = "delete from Landtable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            sqL = " select * from LandTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            ' sqL2 = "select * from LandTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            Rda.Fill(ds, "RemoteLandTable")
            Dim Rtable As DataTable = ds.Tables("RemoteLandTable")
            Dim rRow As DataRow = Rtable.NewRow


            Dim countMe As Integer = 0
            ProgressData.Show()
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.Label1.Text = "Property Records uploading..."
            Dim n As Integer
            ProgressData.ProgressBar1.Minimum = 0

            For n = 0 To LandToSell.DataGrid1.Rows.Count - 1
                If LandToSell.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If LandToSell.DataGrid1.Rows(n).Cells("pub").Value = 1 Then
                        countMe = countMe + 1
                    End If
                End If
            Next

            ProgressData.ProgressBar1.Maximum = countMe ' Rc
            countMe = 0
            n = 0

            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            For n = 0 To LandToSell.DataGrid1.Rows.Count - 1 'Each row As DataRow In DataGrid1.Rows 'Ltable.Rows
                My.Application.DoEvents()
                'ProgressData.ProgressBar1.Value = countMe
                If LandToSell.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If LandToSell.DataGrid1.Rows(n).Cells("pub").Value = 1 Then

                        My.Application.DoEvents()
                        ProgressData.ProgressBar1.Value = countMe
                        rRow("Company ID") = CompanyID
                        rRow("User ID") = PID_no
                        rRow("Project ID") = LandToSell.DataGrid1.Rows(n).Cells(3).Value.ToString
                        rRow("Property ID") = CompanyID & PID_no & LandToSell.DataGrid1.Rows(n).Cells(2).Value
                        rRow("Master Project") = LandToSell.DataGrid1.Rows(n).Cells(5).Value
                        rRow("Community/Project") = LandToSell.DataGrid1.Rows(n).Cells(6).Value
                        rRow("Property Type") = LandToSell.DataGrid1.Rows(n).Cells(7).Value
                        rRow("Phase") = LandToSell.DataGrid1.Rows(n).Cells(8).Value
                        rRow("Address") = LandToSell.DataGrid1.Rows(n).Cells(9).Value
                        rRow("Country") = LandToSell.DataGrid1.Rows(n).Cells(10).Value
                        rRow("City") = LandToSell.DataGrid1.Rows(n).Cells(11).Value
                        rRow("Allowed Height") = LandToSell.DataGrid1.Rows(n).Cells(14).Value
                        rRow("Allowed Builtup Area") = LandToSell.DataGrid1.Rows(n).Cells(15).Value
                        rRow("Land size") = LandToSell.DataGrid1.Rows(n).Cells(13).Value
                        rRow("SqrFT/SqrMt") = LandToSell.DataGrid1.Rows(n).Cells(16).Value
                        rRow("Far") = LandToSell.DataGrid1.Rows(n).Cells(17).Value
                        If LandToSell.DataGrid1.Rows(n).Cells(18).Value.ToString = "" Then
                            saleVal = 0
                        Else
                            saleVal = Math.Round(CDbl(LandToSell.DataGrid1.Rows(n).Cells(18).Value.ToString))
                        End If
                        If LandToSell.DataGrid1.Rows(n).Cells(19).Value.ToString = "" Then
                            saleVal2 = 0
                        Else
                            saleVal2 = Math.Round(CDbl(LandToSell.DataGrid1.Rows(n).Cells(19).Value.ToString))
                        End If
                        rRow("Selling Price") = saleVal
                        rRow("Original Price") = saleVal2

                        rRow("Currency") = LandToSell.DataGrid1.Rows(n).Cells(20).Value
                        rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                        rRow("Agent/Seller") = LandToSell.DataGrid1.Rows(n).Cells(22).Value
                        rRow("Updated Date") = Now.ToShortDateString 'CDate(LandToSell.DataGrid1.Rows(n).Cells(26).Value.ToString)
                        rRow("Entered Date") = LandToSell.DataGrid1.Rows(n).Cells(27).Value.ToString
                        rRow("Publish Notes") = LandToSell.DataGrid1.Rows(n).Cells(28).Value
                        rRow("Main Image") = "\UserImages\" & UserPass & "\" & LandToSell.DataGrid1.Rows(n).Cells(30).Value
                        rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & LandToSell.DataGrid1.Rows(n).Cells(31).Value
                        rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & LandToSell.DataGrid1.Rows(n).Cells(32).Value
                        rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & LandToSell.DataGrid1.Rows(n).Cells(33).Value
                        rRow("Property Map") = LandToSell.DataGrid1.Rows(n).Cells(35).Value

                        Rtable.Rows.Add(rRow)
                        Rda.Update(ds, "RemoteLandTable")
                        rRow = Rtable.NewRow()
                        countMe = countMe + 1
                    End If
                End If

            Next
            Dim str As String
            str = countMe & " Properties Uploaded..."
            ProgressData.Label1.Text = "Property Records completed..."
            ProgressData.ListBox1.Items.Add("Uploading Completed...")
            ProgressData.ListBox1.Items.Add(str)
            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishSelectedLand()
            End If
        Catch ex As Exception
            MessageBox.Show("Please select atleast one property to publish.", "Publish Status", MessageBoxButtons.OK)
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub PublishLand()
        Try
            Call PublishProjects()
            RemoteSQLCon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If

            ProgressData.Show()
            ProgressData.ListBox1.Items.Add("Connection with Server...")
            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected.")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd2.Connection = LocalSQLcon
            If Logas = "Administrator" Then
                ProgressData.Label1.Text = "Company Information uploading..."
                ProgressData.ListBox1.Items.Add("Company Information Uploading...")
                Cmd2.CommandText = "select * from settinginfo"
                Dim rd As OleDbDataReader = Cmd2.ExecuteReader()
                While rd.Read()

                    Cmd.CommandText = "update settinginfo set PersonalTitle ='" & rd("PersonalTitle") & "', PersonalFirstName='" & rd("PersonalFirstName") _
                    & "', PersonalMiddleName='" & rd("PersonalMiddleName") & "', PersonalLastName='" & rd("PersonalLastName") _
                    & "',  PersonalTelephoneNo='" & rd("PersonalTelephoneNo") & "', PersonalEmail ='" & rd("PersonalEmail") _
                    & "', CompanyName='" & rd("CompanyName") & "', CompanyBusinessType='" & rd("companybusinesstype") _
                    & "', CompanyAddress='" & rd("CompanyAddress") & "', CompanyAddress2='" & rd("CompanyAddress2") _
                    & "', CompanyTelephoneNo='" & rd("CompanyTelephoneNo") & "', CompanyFaxNo='" & rd("CompanyFaxNo") _
                    & "', CompanyWebSite='" & rd("Companywebsite") & "', CompanyEmail='" & rd("CompanyEmail") _
                    & "', CompanyLogo='" & rd("CompanyLogo") & "', RegionalCountry='" & rd("RegionalCountry") _
                    & "', RegionalCity='" & rd("RegionalCity") & "', RegionalLanguage='" & rd("RegionalLanguage") _
                    & "', RegionalCurrency='" & rd("RegionalCurrency") & "', RegionalUnitFormats='" & rd("RegionalUnitFormats") _
                    & "', RegionalPostalCode='" & rd("RegionalPostalCode") & "',RegionalListedCountry='" & rd("RegionalListedCountry") _
                    & "', RegionalListedCity='" & rd("RegionalListedCity") & "', ServiceCommission='" & rd("ServiceCommission") & "' where [company id]=" & CompanyID

                    Cmd.ExecuteNonQuery()
                End While
                rd.Close()
                ProgressData.Label1.Text = "Finish"
                ProgressData.ListBox1.Items.Add("Finish")
            End If
            Cmd.CommandText = "delete from landtable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            ' End If
            sqL = " select * from landTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from landTable where [user id]=" & PID_no & " and [Company ID]=" & CompanyID
            Dim Lda As New OleDb.OleDbDataAdapter(sqL2, LocalSQLcon)
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)


            Rda.Fill(ds, "RemotelandTable")
            Lda.Fill(ds, "LocallandTable")
            Dim Rtable As DataTable = ds.Tables("RemotelandTable")
            Dim Ltable As DataTable = ds.Tables("LocallandTable")
            Dim rRow As DataRow = Rtable.NewRow
            Dim Rc As Integer = Ltable.Rows.Count
            Dim countMe As Integer = 1
            ProgressData.Show()
            ProgressData.ProgressBar1.Maximum = Rc
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            ProgressData.Label1.Text = "Properties uploading..."

            Cmd2.Connection = LocalSQLcon
            For Each row As DataRow In Ltable.Rows
                My.Application.DoEvents()
                ProgressData.ProgressBar1.Value = countMe
                rRow("Company ID") = CompanyID
                rRow("User ID") = PID_no
                rRow("Project ID") = CInt(row("Project ID").ToString)
                rRow("Property ID") = CompanyID & PID_no & CInt(row("Property ID").ToString)
                rRow("Master Project") = row("Master Project")
                rRow("Community/Project") = row("Community/Project")
                rRow("Property Type") = row("Property Type")

                rRow("Phase") = row("Phase")
                rRow("Address") = row("Address")
                rRow("Country") = row("Country")
                rRow("City") = row("City")
                '  rRow("Parcel No") = row("Parcel No")
                rRow("Land size") = row("Land size")
                rRow("Allowed Height") = row("Allowed Height")
                rRow("Allowed Builtup Area") = row("Allowed Builtup Area")
                rRow("SqrFT/SqrMt") = row("SqrFt/SqrMt")
                rRow("far") = row("far")
                If row("Selling Price").ToString = "" Then
                    saleVal = 0
                Else
                    saleVal = Math.Round(CDbl(row("Selling Price")))
                End If
                If row("Original Price").ToString = "" Then
                    saleVal2 = 0
                Else
                    saleVal2 = Math.Round(CDbl(row("Original Price")))
                End If
                rRow("Selling Price") = saleVal
                rRow("Original Price") = saleVal2
                rRow("Currency") = row("Currency")
                rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                rRow("Agent/Seller") = row("Agent/Seller")
                rRow("Updated Date") = Now.ToShortDateString 'CDate(row("updated date"))
                rRow("Entered Date") = row("Entered date")
                rRow("Publish Notes") = row("Publish Notes")
                rRow("Main Image") = "\UserImages\" & UserPass & "\" & row("Main Image")
                rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & row("Extra Image1")
                rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & row("Extra Image2")
                rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & row("Extra Image3")

                rRow("Property Map") = row("Property Map")
                Rtable.Rows.Add(rRow)
                Rda.Update(ds, "RemoteLandTable")
                rRow = Rtable.NewRow()
                countMe = countMe + 1

            Next
            ProgressData.Label1.Text = "Finish..."
            ProgressData.ListBox1.Items.Add("Finish")

            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishLand()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    ' Other Table
    Public Sub PublishSelectedOther()


        Try
            RemoteSQLCon.Close()
            Call PublishProjects()
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            Else
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If

            ProgressData.ListBox1.Items.Add("Connection with Server...")

            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected!")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd.CommandText = "delete from Othertable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            sqL = " select * from Othertable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from Othertable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            Rda.Fill(ds, "RemoteOthertable")
            Dim Rtable As DataTable = ds.Tables("RemoteOthertable")
            Dim rRow As DataRow = Rtable.NewRow


            Dim countMe As Integer = 0
            ProgressData.Show()
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.Label1.Text = "Property Records uploading..."
            Dim n As Integer


            For n = 0 To OthersToSell.DataGrid1.Rows.Count - 2
                If OthersToSell.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If OthersToSell.DataGrid1.Rows(n).Cells("pub").Value = 1 Then
                        countMe = countMe + 1
                    End If
                End If
            Next
            ProgressData.ProgressBar1.Maximum = countMe ' Rc
            countMe = 1
            n = 0
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            For n = 0 To OthersToSell.DataGrid1.Rows.Count - 2 'Each row As DataRow In DataGrid1.Rows 'Ltable.Rows
                My.Application.DoEvents()

                If OthersToSell.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If OthersToSell.DataGrid1.Rows(n).Cells("pub").Value = 1 Then

                        My.Application.DoEvents()
                        ProgressData.ProgressBar1.Value = countMe
                        rRow("Company ID") = CompanyID
                        rRow("User ID") = PID_no

                        rRow("Property ID") = CompanyID & PID_no & OthersToSell.DataGrid1.Rows(n).Cells(2).Value
                        rRow("Property Type") = OthersToSell.DataGrid1.Rows(n).Cells(4).Value
                        rRow("Address") = OthersToSell.DataGrid1.Rows(n).Cells(5).Value
                        rRow("Country") = OthersToSell.DataGrid1.Rows(n).Cells(6).Value
                        rRow("City") = OthersToSell.DataGrid1.Rows(n).Cells(7).Value
                        rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                        rRow("Agent/Seller") = OthersToSell.DataGrid1.Rows(n).Cells(10).Value
                        rRow("Updated Date") = Now.ToShortDateString 'CDate(OthersToSell.DataGrid1.Rows(n).Cells(13).Value.ToString)
                        rRow("Entered Date") = OthersToSell.DataGrid1.Rows(n).Cells(14).Value.ToString
                        rRow("Publish Notes") = OthersToSell.DataGrid1.Rows(n).Cells(15).Value
                        rRow("Main Image") = "\UserImages\" & UserPass & "\" & OthersToSell.DataGrid1.Rows(n).Cells(17).Value
                        rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & OthersToSell.DataGrid1.Rows(n).Cells(18).Value
                        rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & OthersToSell.DataGrid1.Rows(n).Cells(19).Value
                        rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & OthersToSell.DataGrid1.Rows(n).Cells(20).Value
                        rRow("Property Map") = OthersToSell.DataGrid1.Rows(n).Cells(22).Value

                        Rtable.Rows.Add(rRow)
                        Rda.Update(ds, "RemoteOthertable")
                        rRow = Rtable.NewRow()
                        countMe = countMe + 1
                    End If
                End If

            Next
            ProgressData.Label1.Text = "Property Records completed..."
            ProgressData.ListBox1.Items.Add("Uploading Completed...")
            ProgressData.ListBox1.Items.Add(countMe & " Properties Uploaded...")
            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishSelectedOther()
            End If
        Catch ex As Exception
            '  MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub PublishOther()
        Try
            RemoteSQLCon.Close()
            Call PublishProjects()
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If

            ProgressData.Show()
            ProgressData.ListBox1.Items.Add("Connection with Server...")
            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected.")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand

            Cmd.Connection = RemoteSQLCon
            Cmd2.Connection = LocalSQLcon
            If Logas = "Administrator" Then
                ProgressData.Label1.Text = "Company Information uploading..."
                ProgressData.ListBox1.Items.Add("Company Information Uploading...")
                Cmd2.CommandText = "select * from settinginfo"
                Dim rd As OleDbDataReader = Cmd2.ExecuteReader()
                While rd.Read()

                    Cmd.CommandText = "update settinginfo set PersonalTitle ='" & rd("PersonalTitle") & "', PersonalFirstName='" & rd("PersonalFirstName") _
                    & "', PersonalMiddleName='" & rd("PersonalMiddleName") & "', PersonalLastName='" & rd("PersonalLastName") _
                    & "',  PersonalTelephoneNo='" & rd("PersonalTelephoneNo") & "', PersonalEmail ='" & rd("PersonalEmail") _
                    & "', CompanyName='" & rd("CompanyName") & "', CompanyBusinessType='" & rd("companybusinesstype") _
                    & "', CompanyAddress='" & rd("CompanyAddress") & "', CompanyAddress2='" & rd("CompanyAddress2") _
                    & "', CompanyTelephoneNo='" & rd("CompanyTelephoneNo") & "', CompanyFaxNo='" & rd("CompanyFaxNo") _
                    & "', CompanyWebSite='" & rd("Companywebsite") & "', CompanyEmail='" & rd("CompanyEmail") _
                    & "', CompanyLogo='" & rd("CompanyLogo") & "', RegionalCountry='" & rd("RegionalCountry") _
                    & "', RegionalCity='" & rd("RegionalCity") & "', RegionalLanguage='" & rd("RegionalLanguage") _
                    & "', RegionalCurrency='" & rd("RegionalCurrency") & "', RegionalUnitFormats='" & rd("RegionalUnitFormats") _
                    & "', RegionalPostalCode='" & rd("RegionalPostalCode") & "',RegionalListedCountry='" & rd("RegionalListedCountry") _
                    & "', RegionalListedCity='" & rd("RegionalListedCity") & "', ServiceCommission='" & rd("ServiceCommission") & "' where [company id]=" & CompanyID

                    Cmd.ExecuteNonQuery()
                End While
                rd.Close()
                ProgressData.Label1.Text = "Finish"
                ProgressData.ListBox1.Items.Add("Finish")
            End If
            Cmd.CommandText = "delete from OtherTable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            ' End If
            sqL = " select * from OtherTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from OtherTable where [user id]=" & PID_no & " and [Company ID]=" & CompanyID
            Dim Lda As New OleDb.OleDbDataAdapter(sqL2, LocalSQLcon)
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            Rda.Fill(ds, "RemoteOtherTable")
            Lda.Fill(ds, "LocalOtherTable")
            Dim Rtable As DataTable = ds.Tables("RemoteOtherTable")
            Dim Ltable As DataTable = ds.Tables("LocalOtherTable")
            Dim rRow As DataRow = Rtable.NewRow
            Dim Rc As Integer = Ltable.Rows.Count
            Dim countMe As Integer = 1
            ProgressData.Show()
            ProgressData.ProgressBar1.Maximum = Rc
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            ProgressData.Label1.Text = "Properties uploading..."

            Cmd2.Connection = LocalSQLcon
            For Each row As DataRow In Ltable.Rows
                My.Application.DoEvents()
                ProgressData.ProgressBar1.Value = countMe
                rRow("Company ID") = CompanyID
                rRow("User ID") = PID_no
                rRow("Property ID") = CompanyID & PID_no & CInt(row("Property ID").ToString)
                rRow("Property Type") = row("Property Type")
                rRow("Address") = row("Address")
                rRow("Country") = row("Country")
                rRow("City") = row("City")
                rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                rRow("Agent/Seller") = row("Agent/Seller")
                rRow("Updated Date") = Now.ToShortDateString 'CDate(row("updated date"))
                rRow("Entered Date") = row("Entered date")
                rRow("Publish Notes") = row("Publish Notes")
                rRow("Main Image") = "\UserImages\" & UserPass & "\" & row("Main Image")
                rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & row("Extra Image1")
                rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & row("Extra Image2")
                rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & row("Extra Image3")
                rRow("Property Map") = row("Property Map")
                Rtable.Rows.Add(rRow)
                Rda.Update(ds, "RemoteOtherTable")
                rRow = Rtable.NewRow()
                countMe = countMe + 1

            Next
            ProgressData.Label1.Text = "Finish..."
            ProgressData.ListBox1.Items.Add("Finish")

            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishOther()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub PublishSelectedRent()


        Try
            Call PublishProjects()
            RemoteSQLCon.Close()

            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If

            ProgressData.ListBox1.Items.Add("Connection with Server...")

            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected!")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd.CommandText = "delete from renttable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            sqL = " select * from renttable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from renttable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            Rda.Fill(ds, "Remoterenttable")
            Dim Rtable As DataTable = ds.Tables("Remoterenttable")
            Dim rRow As DataRow = Rtable.NewRow


            Dim countMe As Integer = 0
            ProgressData.Show()
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.Label1.Text = "Property Records uploading..."
            Dim n As Integer


            For n = 0 To UnitsToRent.DataGrid1.Rows.Count - 1
                If UnitsToRent.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If UnitsToRent.DataGrid1.Rows(n).Cells("pub").Value = 1 Then
                        countMe = countMe + 1
                    End If
                End If
            Next
            ProgressData.ProgressBar1.Maximum = countMe ' Rc
            countMe = 0
            'Cmd2.Connection = LocalSQLcon
            n = 0
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            For n = 0 To UnitsToRent.DataGrid1.Rows.Count - 1 'Each row As DataRow In DataGrid1.Rows 'Ltable.Rows
                My.Application.DoEvents()

                '-Rtable.ImportRow(row)
                '- Rtable.Rows().SetAdded()
                If UnitsToRent.DataGrid1.Rows(n).Cells("pub").Value Is DBNull.Value Then
                Else
                    If UnitsToRent.DataGrid1.Rows(n).Cells("pub").Value = 1 Then

                        My.Application.DoEvents()
                        ProgressData.ProgressBar1.Value = countMe
                        rRow("Company ID") = CompanyID
                        rRow("User ID") = PID_no
                        rRow("Project ID") = UnitsToRent.DataGrid1.Rows(n).Cells(2).Value.ToString
                        rRow("Property ID") = CompanyID & PID_no & UnitsToRent.DataGrid1.Rows(n).Cells(3).Value
                        rRow("Master Project") = UnitsToRent.DataGrid1.Rows(n).Cells(5).Value
                        rRow("Community/Project") = UnitsToRent.DataGrid1.Rows(n).Cells(6).Value
                        rRow("Property Type") = UnitsToRent.DataGrid1.Rows(n).Cells(7).Value
                        rRow("Block/Building") = UnitsToRent.DataGrid1.Rows(n).Cells(8).Value
                        rRow("Phase") = UnitsToRent.DataGrid1.Rows(n).Cells(9).Value
                        rRow("Address") = UnitsToRent.DataGrid1.Rows(n).Cells(10).Value
                        rRow("Country") = UnitsToRent.DataGrid1.Rows(n).Cells(11).Value
                        rRow("City") = UnitsToRent.DataGrid1.Rows(n).Cells(12).Value
                        rRow("Unit Type") = UnitsToRent.DataGrid1.Rows(n).Cells(13).Value
                        rRow("No Of BedRooms") = UnitsToRent.DataGrid1.Rows(n).Cells(14).Value
                        rRow("View") = UnitsToRent.DataGrid1.Rows(n).Cells(15).Value
                        rRow("Balcony") = UnitsToRent.DataGrid1.Rows(n).Cells(16).Value
                        If UnitsToRent.DataGrid1.Rows(n).Cells(17).Value.ToString = "" Then
                            saleVal = 0
                        Else
                            saleVal = Math.Round(CDbl(UnitsToRent.DataGrid1.Rows(n).Cells(17).Value.ToString))
                        End If
                        If UnitsToRent.DataGrid1.Rows(n).Cells(18).Value.ToString = "" Then
                            saleVal2 = 0
                        Else
                            saleVal2 = Math.Round(CDbl(UnitsToRent.DataGrid1.Rows(n).Cells(18).Value.ToString))
                        End If

                        rRow("Annual Price") = saleVal
                        rRow("Additional Price") = saleVal2
                        rRow("Currency") = UnitsToRent.DataGrid1.Rows(n).Cells(19).Value
                        rRow("Status") = UnitsToRent.DataGrid1.Rows(n).Cells(20).Value
                        rRow("Completion Date") = UnitsToRent.DataGrid1.Rows(n).Cells(21).Value
                        rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                        rRow("Agent/Seller") = UnitsToRent.DataGrid1.Rows(n).Cells(23).Value
                        rRow("Updated Date") = Now.ToShortDateString 'CDate(UnitsToRent.DataGrid1.Rows(n).Cells(27).Value.ToString)
                        rRow("Entered Date") = UnitsToRent.DataGrid1.Rows(n).Cells(28).Value.ToString
                        rRow("Publish Notes") = UnitsToRent.DataGrid1.Rows(n).Cells(29).Value
                        rRow("Main Image") = "\UserImages\" & UserPass & "\" & UnitsToRent.DataGrid1.Rows(n).Cells(31).Value
                        rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & UnitsToRent.DataGrid1.Rows(n).Cells(32).Value
                        rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & UnitsToRent.DataGrid1.Rows(n).Cells(33).Value
                        rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & UnitsToRent.DataGrid1.Rows(n).Cells(34).Value
                        rRow("Property Map") = UnitsToRent.DataGrid1.Rows(n).Cells(36).Value
                        Rtable.Rows.Add(rRow)
                        Rda.Update(ds, "RemoteRentTable")
                        rRow = Rtable.NewRow()
                        countMe = countMe + 1
                    End If
                End If

            Next
            ProgressData.Label1.Text = "Property Records completed..."
            ProgressData.ListBox1.Items.Add("Uploading Completed...")
            ProgressData.ListBox1.Items.Add(countMe & " Properties Uploaded...")
            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishSelectedRent()
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub PublishRent()
        Try
            Call PublishProjects()
            RemoteSQLCon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecPortal
            ElseIf ServerName = "MEREC" Then
                RemoteSQLCon.ConnectionString = My.Settings.MerecServer
            End If

            ProgressData.Show()
            ProgressData.ListBox1.Items.Add("Connection with Server...")
            'Connection open
            If RemoteSQLCon.State = ConnectionState.Closed Then RemoteSQLCon.Open()
            If LocalSQLcon.State = ConnectionState.Closed Then LocalSQLcon.Open()

            ProgressData.ListBox1.Items.Add("Connected.")

            Dim sqL, sqL2 As String
            Dim Cmd As New SqlCommand
            Dim Cmd2 As New OleDbCommand
            Cmd.Connection = RemoteSQLCon
            Cmd2.Connection = LocalSQLcon

            If Logas = "Administrator" Then
                ProgressData.Label1.Text = "Company Information uploading..."
                ProgressData.ListBox1.Items.Add("Company Information Uploading...")
                Cmd2.CommandText = "select * from settinginfo"
                Dim rd As OleDbDataReader = Cmd2.ExecuteReader()
                While rd.Read()

                    Cmd.CommandText = "update settinginfo set PersonalTitle ='" & rd("PersonalTitle") & "', PersonalFirstName='" & rd("PersonalFirstName") _
                    & "', PersonalMiddleName='" & rd("PersonalMiddleName") & "', PersonalLastName='" & rd("PersonalLastName") _
                    & "',  PersonalTelephoneNo='" & rd("PersonalTelephoneNo") & "', PersonalEmail ='" & rd("PersonalEmail") _
                    & "', CompanyName='" & rd("CompanyName") & "', CompanyBusinessType='" & rd("companybusinesstype") _
                    & "', CompanyAddress='" & rd("CompanyAddress") & "', CompanyAddress2='" & rd("CompanyAddress2") _
                    & "', CompanyTelephoneNo='" & rd("CompanyTelephoneNo") & "', CompanyFaxNo='" & rd("CompanyFaxNo") _
                    & "', CompanyWebSite='" & rd("Companywebsite") & "', CompanyEmail='" & rd("CompanyEmail") _
                    & "', CompanyLogo='" & rd("CompanyLogo") & "', RegionalCountry='" & rd("RegionalCountry") _
                    & "', RegionalCity='" & rd("RegionalCity") & "', RegionalLanguage='" & rd("RegionalLanguage") _
                    & "', RegionalCurrency='" & rd("RegionalCurrency") & "', RegionalUnitFormats='" & rd("RegionalUnitFormats") _
                    & "', RegionalPostalCode='" & rd("RegionalPostalCode") & "',RegionalListedCountry='" & rd("RegionalListedCountry") _
                    & "', RegionalListedCity='" & rd("RegionalListedCity") & "', ServiceCommission='" & rd("ServiceCommission") & "' where [company id]=" & CompanyID

                    Cmd.ExecuteNonQuery()
                End While
                rd.Close()
                ProgressData.Label1.Text = "Finish"
                ProgressData.ListBox1.Items.Add("Finish")
            End If
            Cmd.CommandText = "delete from renttable where [User ID]= " & PID_no & " and [Company ID]=" & CompanyID
            Cmd.ExecuteNonQuery()
            ' End If
            sqL = " select * from rentTable where [User ID]=" & PID_no & " and [Company ID]=" & CompanyID
            Cmd.CommandText = sqL
            Dim Rda As New SqlDataAdapter(Cmd)
            sqL2 = "select * from rentTable where [user id]=" & PID_no & " and [Company ID]=" & CompanyID
            Dim Lda As New OleDb.OleDbDataAdapter(sqL2, LocalSQLcon)
            Dim ds As New DataSet
            Dim McB As New SqlCommandBuilder(Rda)

            Rda.Fill(ds, "RemoteRentTable")
            Lda.Fill(ds, "LocalRentTable")
            Dim Rtable As DataTable = ds.Tables("RemoteRentTable")
            Dim Ltable As DataTable = ds.Tables("LocalRentTable")
            Dim rRow As DataRow = Rtable.NewRow
            Dim Rc As Integer = Ltable.Rows.Count
            Dim countMe As Integer = 1
            ProgressData.Show()
            ProgressData.ProgressBar1.Maximum = Rc
            ProgressData.Button1.Visible = False
            ProgressData.Button2.Visible = True
            ProgressData.ListBox1.Items.Add("Properties Uploading...")
            ProgressData.Label1.Text = "Properties uploading..."

            Cmd2.Connection = LocalSQLcon
            For Each row As DataRow In Ltable.Rows
                My.Application.DoEvents()
                ProgressData.ProgressBar1.Value = countMe
                rRow("Company ID") = CompanyID
                rRow("User ID") = PID_no
                rRow("Project ID") = CInt(row("Project ID").ToString)
                rRow("Property ID") = CompanyID & PID_no & CInt(row("Property ID").ToString)
                rRow("Master Project") = row("Master Project")
                rRow("Community/Project") = row("Community/Project")
                rRow("Property Type") = row("Property Type")
                rRow("Phase") = row("Phase")
                rRow("Address") = row("Address")
                rRow("Country") = row("Country")
                rRow("City") = row("City")
                rRow("Unit Type") = row("Unit Type")
                rRow("No Of BedRooms") = row("No Of BedRooms")
                rRow("View") = row("View")
                rRow("Balcony") = row("Balcony")
                If row("Annual Price").ToString = "" Then
                    saleVal = 0
                Else
                    saleVal = Math.Round(CDbl(row("Annual Price").ToString))
                End If
                If row("Additional Price") = "" Then
                    saleVal2 = 0
                Else
                    saleVal2 = Math.Round(CDbl(row("Additional Price")))
                End If

                rRow("Annual Price") = saleVal
                rRow("Additional Price") = saleVal2
                rRow("Currency") = row("Currency")
                rRow("Status") = row("Status")
                rRow("Completion Date") = row("completion date")
                rRow("Entered By") = UserPass.ToString 'row("EnteredBy")
                rRow("Agent/Seller") = row("Agent/Seller")
                rRow("Updated Date") = Now.ToShortDateString 'CDate(row("updated date"))
                rRow("Entered Date") = row("Entered date")
                rRow("Publish Notes") = row("Publish Notes")
                rRow("Main Image") = "\UserImages\" & UserPass & "\" & row("Main Image")
                rRow("Extra Image1") = "\UserImages\" & UserPass & "\" & row("Extra Image1")
                rRow("Extra Image2") = "\UserImages\" & UserPass & "\" & row("Extra Image2")
                rRow("Extra Image3") = "\UserImages\" & UserPass & "\" & row("Extra Image3")
                rRow("Property Map") = row("Property Map")
                Rtable.Rows.Add(rRow)
                Rda.Update(ds, "RemoteRentTable")
                rRow = Rtable.NewRow()
                countMe = countMe + 1

            Next
            ProgressData.Label1.Text = "Finish..."
            ProgressData.ListBox1.Items.Add("Finish")

            ProgressData.Button1.Visible = True
            ProgressData.Button2.Visible = False
            filelist()
            ProgressData.Close()

            If ServerName = "Estabase" Then
                ServerName = ""
                Exit Sub
            Else
                ServerName = "Estabase"
                WebServer.Text = "Estabase"
                ConMe()
                PublishRent()
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub
    'End Rent Table
    Public Sub ListinDir()

        Dim remoteLOC As String = "ftp://ftp.estabase.com/" & UserPass & "Images/" & System.IO.Path.GetFileName("C:\PropertyManager\commercialproperty.jpg")
        My.Computer.Network.UploadFile("C:\PropertyManager\Images\", remoteLOC, uName, uPass, True, 500)

    End Sub


    Public Sub filelist()
        Try
            If LocalSQLcon.State = ConnectionState.Open Then
            Else
                LocalSQLcon.Open()

            End If
            Dim Cm As New OleDbCommand
            Cm.Connection = LocalSQLcon
            Cm.CommandText = "Select * from insertedimages"
            Cm.ExecuteNonQuery()
            Dim pattern As String = "*.*"
            If pattern.IndexOf("(") >= 0 Then
                pattern = pattern.Substring(0, pattern.IndexOf("("))
            End If

            Dim dir_info As New DirectoryInfo("C:\PropertyManager\Images")
            Dim file_infos() As FileInfo
            Dim Fname As String
            Dim RecNos As Integer
            file_infos = dir_info.GetFiles(pattern)
            Dim fc As Integer
            Dim countMe As Integer
            For Each file_info As FileInfo In file_infos
                fc = fc + 1
            Next
            ProgressData.Label1.Text = "Property images uploading..."
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = fc
            For Each file_info As FileInfo In file_infos
                My.Application.DoEvents()
                Cm.CommandText = "Select id from insertedimages where images='" & file_info.Name & "' and username='" & UserPass & "'"
                RecNos = Cm.ExecuteScalar
                If RecNos > 0 Then
                Else
                    countMe = countMe + 1
                    'Cm.CommandText = "insert into insertedimages(images,username) values('" & file_info.Name & "','" & UserPass & "')"
                    'Cm.ExecuteNonQuery()
                    If ServerName = "Estabase" Then
                        Dim remoteLOC As String = "ftp://ftp.estabase.com/" & "UserImages/" & UserPass & "/" & file_info.Name 'System.IO.Path.GetFileName("C:\PropertyManager\commercialproperty.jpg")
                        Fname = "C:\PropertyManager\Images\" & file_info.Name
                        My.Computer.Network.UploadFile(Fname, remoteLOC, uName, uPass, False, 50000)
                    Else
                        Dim remoteLOC As String = "ftp://ftp.merecae0000.web151.discountasp.net/" & "UserImages/" & UserPass & "/" & file_info.Name 'System.IO.Path.GetFileName("C:\PropertyManager\commercialproperty.jpg")
                        Fname = "C:\PropertyManager\Images\" & file_info.Name
                        My.Computer.Network.UploadFile(Fname, remoteLOC, "merecae0000", "niazalam", False, 50000)
                        'ProgressData.ProgressBar1.Value = countMe
                    End If
                    ProgressData.ProgressBar1.Value = countMe

                End If
                ProgressData.Label1.Text = "Now File Uploading: " + file_info.Name 'ListBox1.Items.Add(file_info.Name)
            Next file_info
            ProgressData.Close()
            ProgressData.Label1.Text = "Property images completed..."

        Catch es As Exception
            MessageBox.Show("Still you are not full member of Estabase.com, Please contact with the IT Department of Estabase.com.", "Estabase", MessageBoxButtons.OK)
        End Try
    End Sub

    Public Function Encrypt(ByVal stringToEncrypt As String, _
        ByVal SEncryptionKey As String) As String
        Dim key() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes( _
                stringToEncrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), _
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return "Error: Unexpected Error found."

        End Try
    End Function



    Private Sub LL_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL.LinkClicked
        Try
            Process.Start("iexplore.exe", "http://www.estabase.com/Register.aspx")
        Catch ex As Exception
            MessageBox.Show("Please check internet connection, either it is not connected or very slow access.", "Connection Error", MessageBoxButtons.OK)
        End Try

    End Sub


    Private Sub Loginas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Loginas.SelectedIndexChanged
        Try
            If Loginas.SelectedItem = "Administrator" Then
                Label4.Visible = False
                LoginUser.Visible = False
                LoginUser.Text = CompanyUser.Text
            Else
                LoginUser.Text = ""
                Label4.Visible = True
                LoginUser.Visible = True

            End If
        Catch es As Exception
        End Try
    End Sub

    Private Sub LoginMerec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim oCon = New OleDbConnection(My.Settings.MerecConnectionString)
            Dim oCom As New OleDbCommand
            Dim Rd As OleDbDataReader
            oCon.open()
            oCom.Connection = oCon
            oCom.CommandText = "Select * from savedetail"
            Rd = oCom.ExecuteReader
            While Rd.Read
                If Rd("companyid").ToString.Length > 1 Or Rd("username").ToString.Length Then
                    WebServer.Text = Rd("loginto").ToString
                    Loginas.Text = Rd("loginas").ToString
                    CompanyUser.Text = Rd("companyid")
                    LoginUser.Text = Rd("username")
                    LoginPassword.Text = Rd("userpassword")
                    SaveDetail.Checked = True
                End If
            End While
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class


