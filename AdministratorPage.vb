Imports System.Data.SqlClient
Imports System.Data
Public Class AdministratorPage

    Dim RemoteSQLcon As New SqlConnection
    Dim LocalSQLcon As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\PropertyManager\Database\Merec.mdb")

    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private Sub AdministratorPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim cmd As New SqlCommand
            Dim MaxId As Integer
            RemoteSQLcon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLcon.ConnectionString = My.Settings.MerecPortal
            Else
                RemoteSQLcon.ConnectionString = My.Settings.MerecServer
            End If

            If RemoteSQLcon.State = ConnectionState.Closed Then
                RemoteSQLcon.Open()
            End If
            If CompanyID > 0 And PID_no > 0 Then
                cmd.Connection = RemoteSQLcon
                'cmd.CommandText = " Select [Company ID] from settinginfo where [Company ID]=" & CompanyID & " and [companyusername]='" & UserPass & "'"
                ' If IsDBNull(cmd.ExecuteScalar) <> True Then
                'CompanyId2 = cmd.ExecuteScalar
                ' Else
                'CompanyId2 = 0
                'End If
                cmd.CommandText = " Select max([User ID]) from settinginfo where [Company ID]=" & CompanyID & " and [companyusername]='" & UserPass & "'"
                If IsDBNull(cmd.ExecuteScalar) <> True Then
                    MaxId = cmd.ExecuteScalar
                Else
                    MaxId = 0
                End If
                IDText.Text = MaxId
                If Logas = "Administrator" Then 'CompanyId2 > 0 Then
                    cmd.CommandText = "Select * from userinfo where [Company ID]=" & CompanyID
                    da.SelectCommand = cmd
                    ' Dim da As New SqlDataAdapter(cmd)
                    Dim comBuild As New SqlCommandBuilder(da)
                    'Dim ds As New DataSet
                    da.Fill(ds, "Settinginfo")
                    DataGridView1.DataSource = ds.Tables("SettingInfo")
                Else
                    MessageBox.Show("This facility is only available for users with Administrative privileges. Please ask for your Administrator’s assistance or contact Estabase.com", "Administrator Section", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                MessageBox.Show("Please first login and then click on users button.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString) ' "Please first enter the data in the setup then click on users.")
            Me.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        IDText.Text = DataGridView1.CurrentCell.OwningRow.Cells(1).Value
        NameText.Text = DataGridView1.CurrentCell.OwningRow.Cells(2).Value
        Passwordtext.Text = DataGridView1.CurrentCell.OwningRow.Cells(3).Value
        StatusText.Text = DataGridView1.CurrentCell.OwningRow.Cells(4).Value
    End Sub

   
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        IDText.Text = DataGridView1.CurrentCell.OwningRow.Cells(1).Value
        NameText.Text = DataGridView1.CurrentCell.OwningRow.Cells(2).Value
        Passwordtext.Text = DataGridView1.CurrentCell.OwningRow.Cells(3).Value
        StatusText.Text = DataGridView1.CurrentCell.OwningRow.Cells(4).Value

    End Sub

   
    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click
        Try
            Dim nid As String = "0" & CStr(PID_no)
            Dim dr As SqlDataReader
            Dim cmd, cmd2 As New SqlCommand
            Dim int As Integer
            RemoteSQLcon.Close()

            If ServerName = "Estabase" Then
                RemoteSQLcon.ConnectionString = My.Settings.MerecPortal
            Else
                RemoteSQLcon.ConnectionString = My.Settings.MerecServer
            End If
            If RemoteSQLcon.State = ConnectionState.Closed Then
                RemoteSQLcon.Open()
            End If

            'Verify User Name

            cmd2.Connection = RemoteSQLcon
            cmd2.CommandText = "Select count([user name]) from userinfo where [user name]='" & NameText.Text & "'"
            cmd2.ExecuteNonQuery()
            int = cmd2.ExecuteScalar
            If int > 0 Then
                MessageBox.Show("The User name you have entered is already taken. Please enter another username. ", "User Exist", MessageBoxButtons.OK)
                Exit Sub
            End If

            'end verify

            cmd.Connection = RemoteSQLcon
            cmd.CommandText = "Select * from userinfo where [company id] = " & CompanyID
            dr = cmd.ExecuteReader
            Dim n As Integer = 0
            While dr.Read
                n = n + 1
            End While
            dr.Close()
            If n > 19 Then
                MessageBox.Show("You have reached the limit of the number of allowed users. please contact with IT Administrator.", "Limit of Users", MessageBoxButtons.OK)
            Else
                Dim Sql As String = "insert into userinfo ([company id], [user id], [user name], [user password], [user status]) values (" _
                & CompanyID & "," & IDText.Text & ",'" & NameText.Text & "','" & Passwordtext.Text & "','" & StatusText.Text & "')"

                cmd.CommandText = Sql
                'MessageBox.Show(Sql)
                cmd.ExecuteNonQuery()
            End If

            WebBrowser1.Navigate("http://www.merecdubai.com/Welcome.aspx?usermid=" & NameText.Text)
            RefreshMe()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Update_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Button.Click
        Try
            Dim cmd As New SqlCommand
            RemoteSQLcon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLcon.ConnectionString = My.Settings.MerecPortal
            Else
                RemoteSQLcon.ConnectionString = My.Settings.MerecServer
            End If
            If RemoteSQLcon.State = ConnectionState.Closed Then

                RemoteSQLcon.Open()
            End If
            cmd.Connection = RemoteSQLcon
            cmd.CommandText = "update userinfo set [user name]='" & NameText.Text & "', [user password]='" & Passwordtext.Text & "' where [User ID]=" & DataGridView1.CurrentCell.OwningRow.Cells(1).Value & " and [company id] =" & companyID
            cmd.ExecuteNonQuery()
            MessageBox.Show("User Account has been updated.", "Update", MessageBoxButtons.OK)

            RefreshMe()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub Delete_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete_Button.Click
        Try
            Dim cmd As New SqlCommand

            Dim int As Integer
            RemoteSQLcon.Close()
            If ServerName = "Estabase" Then
                RemoteSQLcon.ConnectionString = My.Settings.MerecPortal
            Else
                RemoteSQLcon.ConnectionString = My.Settings.MerecServer
            End If
            If RemoteSQLcon.State = ConnectionState.Closed Then

                RemoteSQLcon.Open()
            End If
            cmd.Connection = RemoteSQLcon
            int = MessageBox.Show("Warning; if you delete a user you will lose all saved data uploaded by that user. Please make sure you have done proper back up for the data prior taking this action.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            'MessageBox.Show(int)
            If int = 6 Then
                cmd.CommandText = "delete from userinfo where [company id] = " & companyID & " and [user id] = " & DataGridView1.CurrentCell.OwningRow.Cells(1).Value
                cmd.ExecuteNonQuery()
                WebBrowser1.Navigate("http://www.merecdubai.com/Welcome2.aspx?usermid=" & NameText.Text)

            Else
                Exit Sub
            End If
            MessageBox.Show("Action Complete", "Delete", MessageBoxButtons.OK)
            RefreshMe()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub RefreshMe()
        Dim cmd As New SqlCommand
        ds.Clear()
        RemoteSQLcon.Close()
        If ServerName = "Estabase" Then
            RemoteSQLcon.ConnectionString = My.Settings.MerecPortal
        Else
            RemoteSQLcon.ConnectionString = My.Settings.MerecServer
        End If
        If RemoteSQLcon.State = ConnectionState.Closed Then

            RemoteSQLcon.Open()
        End If
        Dim dr As SqlDataReader
        Dim companyId2 As Integer
        cmd.Connection = RemoteSQLcon
        cmd.CommandText = "Select * from settinginfo where [Company ID]=" & PID_no
        dr = cmd.ExecuteReader
        While dr.Read
            companyID2 = dr("Company ID")
        End While
        dr.Close()
        If companyId2 > 0 Then

            cmd.CommandText = "Select * from userinfo where [Company ID]=" & CompanyID
            da.SelectCommand = cmd
            ' Dim da As New SqlDataAdapter(cmd)
            Dim comBuild As New SqlCommandBuilder(da)
            'Dim ds As New DataSet


            da.Fill(ds, "Settinginfo")
            DataGridView1.DataSource = ds.Tables("SettingInfo")

        Else
            MessageBox.Show("This facility is only available for users with Administrative privileges. Please ask for your Administrator’s assistance or contact Estabase.com", "Administrator Section", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    
End Class