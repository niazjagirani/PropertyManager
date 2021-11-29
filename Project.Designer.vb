<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Project
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
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.ProjectText = New System.Windows.Forms.TextBox
        Me.Rrent = New System.Windows.Forms.RadioButton
        Me.Rland = New System.Windows.Forms.RadioButton
        Me.Runit = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.ProjectCombo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProjectLocation = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.DeleteAll = New System.Windows.Forms.Button
        Me.DeleteSelected = New System.Windows.Forms.Button
        Me.Pic4 = New System.Windows.Forms.PictureBox
        Me.Pic3 = New System.Windows.Forms.PictureBox
        Me.Pic2 = New System.Windows.Forms.PictureBox
        Me.Pic1 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ImgButton4 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.ImgButton3 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ImgButton2 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.ImgButton1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ProjectMainImage = New System.Windows.Forms.TextBox
        Me.ProjectExtraImage3 = New System.Windows.Forms.TextBox
        Me.ProjectExtraImage1 = New System.Windows.Forms.TextBox
        Me.ProjectExtraImage2 = New System.Windows.Forms.TextBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.ProjectHiddenNotes = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProjectPublishNotes = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Pic4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFile
        '
        Me.OpenFile.DefaultExt = "*.jpg"
        Me.OpenFile.Filter = "JPG Images|*.jpg|GIF Images|*.gif"
        Me.OpenFile.InitialDirectory = "c:\propertymanager\images"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 476)
        Me.Panel1.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ProjectText)
        Me.Panel4.Controls.Add(Me.Rrent)
        Me.Panel4.Controls.Add(Me.Rland)
        Me.Panel4.Controls.Add(Me.Runit)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.ProjectCombo)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.ProjectLocation)
        Me.Panel4.Location = New System.Drawing.Point(14, 13)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(436, 75)
        Me.Panel4.TabIndex = 32
        '
        'ProjectText
        '
        Me.ProjectText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectText.Location = New System.Drawing.Point(4, 49)
        Me.ProjectText.Name = "ProjectText"
        Me.ProjectText.Size = New System.Drawing.Size(194, 20)
        Me.ProjectText.TabIndex = 58
        '
        'Rrent
        '
        Me.Rrent.AutoSize = True
        Me.Rrent.BackColor = System.Drawing.SystemColors.Control
        Me.Rrent.Location = New System.Drawing.Point(367, 3)
        Me.Rrent.Name = "Rrent"
        Me.Rrent.Size = New System.Drawing.Size(48, 17)
        Me.Rrent.TabIndex = 57
        Me.Rrent.TabStop = True
        Me.Rrent.Text = "Rent"
        Me.Rrent.UseVisualStyleBackColor = False
        '
        'Rland
        '
        Me.Rland.AutoSize = True
        Me.Rland.BackColor = System.Drawing.SystemColors.Control
        Me.Rland.Location = New System.Drawing.Point(291, 3)
        Me.Rland.Name = "Rland"
        Me.Rland.Size = New System.Drawing.Size(49, 17)
        Me.Rland.TabIndex = 56
        Me.Rland.TabStop = True
        Me.Rland.Text = "Land"
        Me.Rland.UseVisualStyleBackColor = False
        '
        'Runit
        '
        Me.Runit.AutoSize = True
        Me.Runit.BackColor = System.Drawing.SystemColors.Control
        Me.Runit.Location = New System.Drawing.Point(221, 3)
        Me.Runit.Name = "Runit"
        Me.Runit.Size = New System.Drawing.Size(49, 17)
        Me.Runit.TabIndex = 55
        Me.Runit.TabStop = True
        Me.Runit.Text = "Units"
        Me.Runit.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, -1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 14)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Project Details:"
        '
        'ProjectCombo
        '
        Me.ProjectCombo.FormattingEnabled = True
        Me.ProjectCombo.Location = New System.Drawing.Point(3, 49)
        Me.ProjectCombo.Name = "ProjectCombo"
        Me.ProjectCombo.Size = New System.Drawing.Size(194, 21)
        Me.ProjectCombo.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Project Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Location"
        '
        'ProjectLocation
        '
        Me.ProjectLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectLocation.Location = New System.Drawing.Point(221, 50)
        Me.ProjectLocation.Name = "ProjectLocation"
        Me.ProjectLocation.Size = New System.Drawing.Size(194, 20)
        Me.ProjectLocation.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.DeleteAll)
        Me.Panel2.Controls.Add(Me.DeleteSelected)
        Me.Panel2.Controls.Add(Me.Pic4)
        Me.Panel2.Controls.Add(Me.Pic3)
        Me.Panel2.Controls.Add(Me.Pic2)
        Me.Panel2.Controls.Add(Me.Pic1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.ImgButton4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ImgButton3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.ImgButton2)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.ImgButton1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ProjectMainImage)
        Me.Panel2.Controls.Add(Me.ProjectExtraImage3)
        Me.Panel2.Controls.Add(Me.ProjectExtraImage1)
        Me.Panel2.Controls.Add(Me.ProjectExtraImage2)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(13, 275)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(437, 195)
        Me.Panel2.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 14)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Project Images:"
        '
        'DeleteAll
        '
        Me.DeleteAll.Location = New System.Drawing.Point(213, 167)
        Me.DeleteAll.Name = "DeleteAll"
        Me.DeleteAll.Size = New System.Drawing.Size(100, 23)
        Me.DeleteAll.TabIndex = 50
        Me.DeleteAll.Text = "Delete all"
        Me.DeleteAll.UseVisualStyleBackColor = True
        '
        'DeleteSelected
        '
        Me.DeleteSelected.Location = New System.Drawing.Point(108, 167)
        Me.DeleteSelected.Name = "DeleteSelected"
        Me.DeleteSelected.Size = New System.Drawing.Size(100, 23)
        Me.DeleteSelected.TabIndex = 49
        Me.DeleteSelected.Text = "Delete current"
        Me.DeleteSelected.UseVisualStyleBackColor = True
        '
        'Pic4
        '
        Me.Pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic4.Location = New System.Drawing.Point(323, 47)
        Me.Pic4.Name = "Pic4"
        Me.Pic4.Size = New System.Drawing.Size(100, 50)
        Me.Pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic4.TabIndex = 48
        Me.Pic4.TabStop = False
        '
        'Pic3
        '
        Me.Pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic3.Location = New System.Drawing.Point(217, 47)
        Me.Pic3.Name = "Pic3"
        Me.Pic3.Size = New System.Drawing.Size(100, 50)
        Me.Pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic3.TabIndex = 47
        Me.Pic3.TabStop = False
        '
        'Pic2
        '
        Me.Pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic2.Location = New System.Drawing.Point(111, 47)
        Me.Pic2.Name = "Pic2"
        Me.Pic2.Size = New System.Drawing.Size(100, 50)
        Me.Pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic2.TabIndex = 46
        Me.Pic2.TabStop = False
        '
        'Pic1
        '
        Me.Pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic1.Location = New System.Drawing.Point(5, 47)
        Me.Pic1.Name = "Pic1"
        Me.Pic1.Size = New System.Drawing.Size(100, 50)
        Me.Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic1.TabIndex = 45
        Me.Pic1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Main Image"
        '
        'ImgButton4
        '
        Me.ImgButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImgButton4.Location = New System.Drawing.Point(323, 129)
        Me.ImgButton4.Name = "ImgButton4"
        Me.ImgButton4.Size = New System.Drawing.Size(99, 23)
        Me.ImgButton4.TabIndex = 44
        Me.ImgButton4.Text = "Browse"
        Me.ImgButton4.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(110, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Extra Image"
        '
        'ImgButton3
        '
        Me.ImgButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImgButton3.Location = New System.Drawing.Point(217, 129)
        Me.ImgButton3.Name = "ImgButton3"
        Me.ImgButton3.Size = New System.Drawing.Size(99, 23)
        Me.ImgButton3.TabIndex = 43
        Me.ImgButton3.Text = "Browse"
        Me.ImgButton3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(215, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Extra Image"
        '
        'ImgButton2
        '
        Me.ImgButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImgButton2.Location = New System.Drawing.Point(111, 129)
        Me.ImgButton2.Name = "ImgButton2"
        Me.ImgButton2.Size = New System.Drawing.Size(99, 23)
        Me.ImgButton2.TabIndex = 42
        Me.ImgButton2.Text = "Browse"
        Me.ImgButton2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(321, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Extra Image"
        '
        'ImgButton1
        '
        Me.ImgButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImgButton1.Location = New System.Drawing.Point(5, 129)
        Me.ImgButton1.Name = "ImgButton1"
        Me.ImgButton1.Size = New System.Drawing.Size(100, 23)
        Me.ImgButton1.TabIndex = 41
        Me.ImgButton1.Text = "Browse"
        Me.ImgButton1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(4, 167)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 23)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "Clear / Add new"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(319, 167)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Update / Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProjectMainImage
        '
        Me.ProjectMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectMainImage.Location = New System.Drawing.Point(5, 103)
        Me.ProjectMainImage.Name = "ProjectMainImage"
        Me.ProjectMainImage.Size = New System.Drawing.Size(100, 20)
        Me.ProjectMainImage.TabIndex = 35
        '
        'ProjectExtraImage3
        '
        Me.ProjectExtraImage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectExtraImage3.Location = New System.Drawing.Point(323, 103)
        Me.ProjectExtraImage3.Name = "ProjectExtraImage3"
        Me.ProjectExtraImage3.Size = New System.Drawing.Size(100, 20)
        Me.ProjectExtraImage3.TabIndex = 38
        '
        'ProjectExtraImage1
        '
        Me.ProjectExtraImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectExtraImage1.Location = New System.Drawing.Point(111, 103)
        Me.ProjectExtraImage1.Name = "ProjectExtraImage1"
        Me.ProjectExtraImage1.Size = New System.Drawing.Size(100, 20)
        Me.ProjectExtraImage1.TabIndex = 36
        '
        'ProjectExtraImage2
        '
        Me.ProjectExtraImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectExtraImage2.Location = New System.Drawing.Point(217, 103)
        Me.ProjectExtraImage2.Name = "ProjectExtraImage2"
        Me.ProjectExtraImage2.Size = New System.Drawing.Size(100, 20)
        Me.ProjectExtraImage2.TabIndex = 37
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(435, 193)
        Me.ShapeContainer1.TabIndex = 51
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -2
        Me.LineShape1.X2 = 451
        Me.LineShape1.Y1 = 161
        Me.LineShape1.Y2 = 161
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.ProjectHiddenNotes)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.ProjectPublishNotes)
        Me.Panel3.Location = New System.Drawing.Point(13, 94)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(437, 175)
        Me.Panel3.TabIndex = 31
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 14)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Project Notes:"
        '
        'ProjectHiddenNotes
        '
        Me.ProjectHiddenNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectHiddenNotes.Location = New System.Drawing.Point(7, 120)
        Me.ProjectHiddenNotes.Multiline = True
        Me.ProjectHiddenNotes.Name = "ProjectHiddenNotes"
        Me.ProjectHiddenNotes.Size = New System.Drawing.Size(417, 50)
        Me.ProjectHiddenNotes.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Publish Notes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Hidden Notes"
        '
        'ProjectPublishNotes
        '
        Me.ProjectPublishNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectPublishNotes.Location = New System.Drawing.Point(6, 48)
        Me.ProjectPublishNotes.Multiline = True
        Me.ProjectPublishNotes.Name = "ProjectPublishNotes"
        Me.ProjectPublishNotes.Size = New System.Drawing.Size(417, 50)
        Me.ProjectPublishNotes.TabIndex = 14
        '
        'Project
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 494)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Project"
        Me.Text = "Manage Projects"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pic4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DeleteAll As System.Windows.Forms.Button
    Friend WithEvents DeleteSelected As System.Windows.Forms.Button
    Friend WithEvents Pic4 As System.Windows.Forms.PictureBox
    Friend WithEvents Pic3 As System.Windows.Forms.PictureBox
    Friend WithEvents Pic2 As System.Windows.Forms.PictureBox
    Friend WithEvents Pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ImgButton4 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ImgButton3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ImgButton2 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ImgButton1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ProjectMainImage As System.Windows.Forms.TextBox
    Friend WithEvents ProjectExtraImage3 As System.Windows.Forms.TextBox
    Friend WithEvents ProjectExtraImage1 As System.Windows.Forms.TextBox
    Friend WithEvents ProjectExtraImage2 As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ProjectHiddenNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProjectPublishNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ProjectCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProjectLocation As System.Windows.Forms.TextBox
    Friend WithEvents Rrent As System.Windows.Forms.RadioButton
    Friend WithEvents Rland As System.Windows.Forms.RadioButton
    Friend WithEvents Runit As System.Windows.Forms.RadioButton
    Friend WithEvents ProjectText As System.Windows.Forms.TextBox
End Class
