<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttachFile
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
        Me.File_button = New System.Windows.Forms.Button
        Me.FileText = New System.Windows.Forms.TextBox
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.Save_Button = New System.Windows.Forms.Button
        Me.Close_button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'File_button
        '
        Me.File_button.Location = New System.Drawing.Point(374, 22)
        Me.File_button.Name = "File_button"
        Me.File_button.Size = New System.Drawing.Size(75, 23)
        Me.File_button.TabIndex = 0
        Me.File_button.Text = "Browse"
        Me.File_button.UseVisualStyleBackColor = True
        '
        'FileText
        '
        Me.FileText.Location = New System.Drawing.Point(20, 24)
        Me.FileText.Name = "FileText"
        Me.FileText.Size = New System.Drawing.Size(348, 20)
        Me.FileText.TabIndex = 1
        '
        'OpenFile
        '
        Me.OpenFile.DefaultExt = "*.*"
        Me.OpenFile.InitialDirectory = "c:\propertymanager\images"
        '
        'Save_Button
        '
        Me.Save_Button.Location = New System.Drawing.Point(293, 86)
        Me.Save_Button.Name = "Save_Button"
        Me.Save_Button.Size = New System.Drawing.Size(75, 23)
        Me.Save_Button.TabIndex = 2
        Me.Save_Button.Text = "Save"
        Me.Save_Button.UseVisualStyleBackColor = True
        '
        'Close_button
        '
        Me.Close_button.Location = New System.Drawing.Point(374, 86)
        Me.Close_button.Name = "Close_button"
        Me.Close_button.Size = New System.Drawing.Size(75, 23)
        Me.Close_button.TabIndex = 3
        Me.Close_button.Text = "Close"
        Me.Close_button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(17, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Please wait..."
        Me.Label1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FileText)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.File_button)
        Me.Panel1.Controls.Add(Me.Close_button)
        Me.Panel1.Controls.Add(Me.Save_Button)
        Me.Panel1.Location = New System.Drawing.Point(22, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 115)
        Me.Panel1.TabIndex = 5
        '
        'AttachFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 146)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AttachFile"
        Me.Text = "Attach File"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents File_button As System.Windows.Forms.Button
    Friend WithEvents FileText As System.Windows.Forms.TextBox
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Save_Button As System.Windows.Forms.Button
    Friend WithEvents Close_button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
