Imports System
Imports System.Reflection ' For Missing.Value and BindingFlags
'Imports System.Runtime.InteropServices ' For COMException
'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Data
Public Class Form1
    'Private Const ExcelPath As String = "C:\Niaz\Merec Software\Samples\TestExcel2\TestExcel2\Test.xls"
    Dim rm As Int32 = 0
    Dim Con As New OleDbConnection(AccessCon)

    Public da As New OleDbDataAdapter("Select [Property ID], [Updated Date],[Property Type],[Master Project],[Block/Building],[Unit Type], Floor from unitstable where datediff('d',format([updated date],'mm/dd/yyyy'),now)>20 ", Con) '& Now.AddDays(-10).Day & " and month(updateddate) <= " & Now.AddDays(-10).Month, Con) '& " '+  & " and (day(updateddate)+month(updateddate))<" & Now.Month + Now.Day, Con)

    Public ds As New DataSet
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Dim db As New OleDbCommandBuilder(da)
            Con.Open()
            'Dim cmDel As New OleDbCommand("delete * from unitstable where datediff('d',format(updateddate,'dd/mm/yyyy'),now)>30 ", Con)
            'cmDel.ExecuteNonQuery()

            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                PropertyReminder.DataGridView1.DataSource = ds.Tables(0)
                PropertyReminder.DataGridView1.Refresh()

                rm = 1

            End If
            Dim str As Date
            Dim cm As New OleDbCommand("Select backupdate from backupcheckup", Con)
            str = cm.ExecuteScalar()
            If str < Date.Today.ToShortDateString Then
                Call filebackupDaily()
                cm.CommandText = "update backupcheckup set backupdate=now"
                cm.ExecuteNonQuery()
            End If
            ' Heading.Parent = PictureBox2
            ' Heading.BackColor = Color.Transparent

            'Label1.Parent = PictureBox2
            'Label1.BackColor = Color.Transparent

            'Label2.Parent = PictureBox2
            'Label2.BackColor = Color.Transparent

            'Label3.Parent = PictureBox2
            'Label3.BackColor = Color.Transparent
            Call filebackupSoftwareStartUp()
            Call filebackupEvery10()
        Catch ex As Exception
            MessageBox.Show("Please create 'backup' directory in 'c:\propertymanager\database' to avoid this error.", "Startup Error", MessageBoxButtons.OK)
        End Try

    End Sub
    Private Sub getSetup()
        Dim Dr As OleDbDataReader
        Dim setup As New OleDbCommand("Select * from setup", Con)
        Dr = setup.ExecuteReader()
        While Dr.Read
            If Dr("RegionalListedCountry").ToString.Length < 1 Then
                MessageBox.Show("Please specify the default country, city and currency for your listing in the setup menu.", "Setup Detail", MessageBoxButtons.OK)
            Else
                defaultCountry = Dr("RegionalListedCountry").ToString()
                defaultCity = Dr("RegionalListedCity").ToString()
                defaultCurrency = Dr("RegionalCurrency").ToString()
            End If
        End While
    End Sub
    'Backups
    Private Sub filebackupSoftwareStartUp()
        System.IO.File.Copy("C:\propertymanager\database\merec.mdb", "C:\propertymanager\database\Backup\MerecSSB.mdb", True)
    End Sub
    Private Sub filebackupEvery10()
        System.IO.File.Copy("C:\propertymanager\database\merec.mdb", "C:\propertymanager\database\Backup\MerecTMB.mdb", True)
    End Sub
    Private Sub filebackupDaily()
        System.IO.File.Copy("C:\propertymanager\database\merec.mdb", "C:\propertymanager\database\Backup\MerecYB.mdb", True)
    End Sub
    'End Backups
   

   

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If rm = 1 Then
            rm = 0
            PropertyReminder.Show()
        End If
    End Sub

   
   
    'Private Sub ManageBuilding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BuildingToSell.Show()

    '    End Sub

    
   
    
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call filebackupEvery10()
    End Sub


    Private Sub AddProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddProjectButton.Click
        ProjectAdd = True
        AddProjectButton.BackgroundImage = My.Resources.add_new_project_click
        Project.Show()
    End Sub

    Private Sub AddProjectButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AddProjectButton.MouseDown
        AddProjectButton.BackgroundImage = My.Resources.add_new_project_click

    End Sub

    Private Sub AddProjectButton_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddProjectButton.MouseHover
        AddProjectButton.BackgroundImage = My.Resources.add_new_project_rollover
    End Sub

    Private Sub AddProjectButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddProjectButton.MouseLeave
        AddProjectButton.BackgroundImage = My.Resources.Add_new_project_standard
    End Sub

    Private Sub AddProjectButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AddProjectButton.MouseUp
        AddProjectButton.BackgroundImage = My.Resources.add_new_project_rollover
    End Sub


    Private Sub EditProject_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles EditProject.MouseDown
        EditProject.BackgroundImage = My.Resources.edit_delete_project_click
    End Sub

    Private Sub EditProject_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditProject.MouseHover
        EditProject.BackgroundImage = My.Resources.edit_delete_project_rollover
    End Sub

    Private Sub EditProject_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditProject.MouseLeave
        EditProject.BackgroundImage = My.Resources.edit_delete_project_standard
    End Sub

    Private Sub EditProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditProject.Click
        ProjectAdd = False
        Project.Show()
    End Sub

    
    Private Sub ManageUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageUnit.Click
        UnitsDisplay.Show()
    End Sub

    Private Sub ManageUnit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageUnit.MouseDown
        ManageUnit.BackgroundImage = My.Resources.units_for_sale_click

    End Sub

    Private Sub ManageUnit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageUnit.MouseHover
        ManageUnit.BackgroundImage = My.Resources.units_for_sale_rollover
    End Sub

    Private Sub ManageUnit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageUnit.MouseLeave
        ManageUnit.BackgroundImage = My.Resources.units_for_sale_standard

    End Sub

    Private Sub ManageUnit_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageUnit.MouseUp
        ManageUnit.BackgroundImage = My.Resources.units_for_sale_rollover
    End Sub

    
    Private Sub ManageLand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageLand.Click
        Try
            LandDisplay.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ManageLand_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageLand.MouseDown
        ManageLand.BackgroundImage = My.Resources.lands_for_sale_click

    End Sub

    Private Sub ManageLand_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageLand.MouseHover
        ManageLand.BackgroundImage = My.Resources.lands_for_sale_rollover

    End Sub

    Private Sub ManageLand_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageLand.MouseLeave
        ManageLand.BackgroundImage = My.Resources.lands_for_sale_standard

    End Sub

    Private Sub ManageLand_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageLand.MouseUp
        ManageLand.BackgroundImage = My.Resources.lands_for_sale_rollover

    End Sub

    
    Private Sub ManageOtherProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageOtherProperties.Click
        OthersToSell.Show()
    End Sub

    Private Sub ManageOtherProperties_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageOtherProperties.MouseDown
        ManageOtherProperties.BackgroundImage = My.Resources.other_for_sale_click

    End Sub

    Private Sub ManageOtherProperties_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageOtherProperties.MouseHover
        ManageOtherProperties.BackgroundImage = My.Resources.other_for_sale_rollover

    End Sub

    Private Sub ManageOtherProperties_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageOtherProperties.MouseLeave
        ManageOtherProperties.BackgroundImage = My.Resources.other_for_sale_standard

    End Sub

    Private Sub ManageOtherProperties_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageOtherProperties.MouseUp
        ManageOtherProperties.BackgroundImage = My.Resources.other_for_sale_rollover

    End Sub

    Private Sub ManageRent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageRent.Click
        RentDisplay.Show()
    End Sub

    Private Sub ManageRent_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageRent.MouseDown
        ManageRent.BackgroundImage = My.Resources.property_for_rent_click

    End Sub

    Private Sub ManageRent_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageRent.MouseHover
        ManageRent.BackgroundImage = My.Resources.property_for_rent_rollover

    End Sub

    Private Sub ManageRent_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ManageRent.MouseLeave
        ManageRent.BackgroundImage = My.Resources.property_for_rent_standard
    End Sub

    Private Sub ManageRent_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ManageRent.MouseUp
        ManageRent.BackgroundImage = My.Resources.property_for_rent_rollover

    End Sub
    ''' Network Properties

    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.Click
        If Login.Text.ToLower = "login" Then

            LoginMerec.Show()
        Else
            Login.Text = "Login"
            UserPass = ""
            CompanyID = 0
            PID_no = 0
        End If
    End Sub

    Private Sub AdministratorZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministratorZone.Click
        AdministratorPage.Show()
    End Sub

    Private Sub SetupInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupInfo.Click
        If logas = "Administrator" Then
            Setup.Show()

        Else
            MessageBox.Show("This facility is only available for users with Administrative privileges. Please ask for your Administrator’s assistance or contact Estabase.com", "Administrator Section", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub AboutUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUS.Click
        Team.Show()
    End Sub


    Private Sub AboutUS_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AboutUS.MouseDown
        AboutUS.BackgroundImage = My.Resources.about_us_click
    End Sub

    Private Sub AboutUS_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AboutUS.MouseHover
        AboutUS.BackgroundImage = My.Resources.about_us_rollover

    End Sub

    Private Sub AboutUS_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AboutUS.MouseLeave
        AboutUS.BackgroundImage = My.Resources.about_us_standard

    End Sub


    Private Sub HELP_Button_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HELP_Button.MouseDown
        HELP_Button.BackgroundImage = My.Resources.help_click
    End Sub

    Private Sub HELP_Button_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles HELP_Button.MouseHover
        HELP_Button.BackgroundImage = My.Resources.help_rollover
    End Sub

    Private Sub HELP_Button_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles HELP_Button.MouseLeave
        HELP_Button.BackgroundImage = My.Resources.help_standard
    End Sub

    Private Sub SetupInfo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SetupInfo.MouseDown
        SetupInfo.BackgroundImage = My.Resources.setup_click
    End Sub

    Private Sub SetupInfo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles SetupInfo.MouseHover
        SetupInfo.BackgroundImage = My.Resources.setup_rollover
    End Sub

    Private Sub SetupInfo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SetupInfo.MouseLeave
        SetupInfo.BackgroundImage = My.Resources.setup_standard
    End Sub

    Private Sub AdministratorZone_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AdministratorZone.MouseDown
        AdministratorZone.BackgroundImage = My.Resources.users_click
    End Sub

    Private Sub AdministratorZone_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdministratorZone.MouseHover
        AdministratorZone.BackgroundImage = My.Resources.users_rollover
    End Sub

    Private Sub AdministratorZone_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdministratorZone.MouseLeave
        AdministratorZone.BackgroundImage = My.Resources.users_standard
    End Sub

    Private Sub Login_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Login.MouseDown
        Login.BackgroundImage = My.Resources.login_click
    End Sub

    Private Sub Login_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login.MouseHover
        Login.BackgroundImage = My.Resources.login_rollover
    End Sub

    Private Sub Login_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login.MouseLeave
        Login.BackgroundImage = My.Resources.login_standard
    End Sub
End Class
