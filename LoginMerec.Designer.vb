<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginMerec
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SaveDetail = New System.Windows.Forms.CheckBox
        Me.Loginas = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CompanyUser = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.WebServer = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LoginButton = New System.Windows.Forms.Button
        Me.LoginPassword = New System.Windows.Forms.TextBox
        Me.LoginUser = New System.Windows.Forms.TextBox
        Me.LL = New System.Windows.Forms.LinkLabel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.SaveDetail)
        Me.Panel1.Controls.Add(Me.Loginas)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CompanyUser)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.WebServer)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LoginButton)
        Me.Panel1.Controls.Add(Me.LoginPassword)
        Me.Panel1.Controls.Add(Me.LoginUser)
        Me.Panel1.Location = New System.Drawing.Point(18, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 216)
        Me.Panel1.TabIndex = 0
        '
        'SaveDetail
        '
        Me.SaveDetail.AutoSize = True
        Me.SaveDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveDetail.Location = New System.Drawing.Point(10, 193)
        Me.SaveDetail.Name = "SaveDetail"
        Me.SaveDetail.Size = New System.Drawing.Size(146, 17)
        Me.SaveDetail.TabIndex = 26
        Me.SaveDetail.Text = "Remember my login detail"
        Me.SaveDetail.UseVisualStyleBackColor = True
        '
        'Loginas
        '
        Me.Loginas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Loginas.FormattingEnabled = True
        Me.Loginas.Items.AddRange(New Object() {"Administrator", "User"})
        Me.Loginas.Location = New System.Drawing.Point(103, 53)
        Me.Loginas.Name = "Loginas"
        Me.Loginas.Size = New System.Drawing.Size(194, 21)
        Me.Loginas.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Login as"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Company ID:"
        '
        'CompanyUser
        '
        Me.CompanyUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompanyUser.Location = New System.Drawing.Point(103, 80)
        Me.CompanyUser.Name = "CompanyUser"
        Me.CompanyUser.Size = New System.Drawing.Size(194, 20)
        Me.CompanyUser.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Publish to Server:"
        Me.Label1.Visible = False
        '
        'WebServer
        '
        Me.WebServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WebServer.FormattingEnabled = True
        Me.WebServer.Items.AddRange(New Object() {"MEREC", "Estabase"})
        Me.WebServer.Location = New System.Drawing.Point(103, 26)
        Me.WebServer.Name = "WebServer"
        Me.WebServer.Size = New System.Drawing.Size(194, 21)
        Me.WebServer.TabIndex = 0
        Me.WebServer.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(229, 170)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Login"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "User Name:"
        '
        'LoginButton
        '
        Me.LoginButton.Location = New System.Drawing.Point(157, 170)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(68, 23)
        Me.LoginButton.TabIndex = 6
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = True
        '
        'LoginPassword
        '
        Me.LoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LoginPassword.Location = New System.Drawing.Point(103, 132)
        Me.LoginPassword.Name = "LoginPassword"
        Me.LoginPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.LoginPassword.Size = New System.Drawing.Size(194, 20)
        Me.LoginPassword.TabIndex = 5
        '
        'LoginUser
        '
        Me.LoginUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LoginUser.Location = New System.Drawing.Point(103, 106)
        Me.LoginUser.Name = "LoginUser"
        Me.LoginUser.Size = New System.Drawing.Size(194, 20)
        Me.LoginUser.TabIndex = 4
        '
        'LL
        '
        Me.LL.AutoSize = True
        Me.LL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LL.LinkColor = System.Drawing.Color.Maroon
        Me.LL.Location = New System.Drawing.Point(270, 231)
        Me.LL.Name = "LL"
        Me.LL.Size = New System.Drawing.Size(59, 16)
        Me.LL.TabIndex = 20
        Me.LL.TabStop = True
        Me.LL.Text = "Register"
        '
        'LoginMerec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 253)
        Me.Controls.Add(Me.LL)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "LoginMerec"
        Me.Text = "Login to Server"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LoginButton As System.Windows.Forms.Button
    Friend WithEvents LoginPassword As System.Windows.Forms.TextBox
    Friend WithEvents LoginUser As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LL As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WebServer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CompanyUser As System.Windows.Forms.TextBox
    Friend WithEvents Loginas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveDetail As System.Windows.Forms.CheckBox
End Class
