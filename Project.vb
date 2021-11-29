Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Drawing
Imports System.IO
Imports System.Data.OleDb
Public Class Project
    Dim UpdateKey As Integer
    Dim img1, img2, img3, img4 As String
    Dim imgtf1, imgtf2, imgtf3, imgtf4 As Boolean
    Private Sub Project_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If ProjectAdd = True Then
                ProjectText.Visible = True
                ProjectCombo.Visible = False
            Else
                ProjectText.Visible = False
                ProjectCombo.Visible = True
            End If
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim pf As New ExtraFuntions
            pf.ProjectFuction(ProjectCombo, AttachFrom)
        Catch es As Exception
        End Try
    End Sub
    Private Sub ProjectCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectCombo.SelectedIndexChanged
        Try
            'catching Key of Projects
            UpdateKey = CType(ProjectCombo.SelectedItem, ComboPair).Value

            Dim daProjects As New OleDbDataAdapter("Select * from Projects where [Project ID]=" & CType(ProjectCombo.SelectedItem, ComboPair).Value & " and ProjectType='" & AttachFrom & "'", Con)
            Dim ds As New DataSet
            Dim dr As DataRow
            'ProjectCombo.Items.Clear()
            daProjects.Fill(ds, "Projects")
            For Each dr In ds.Tables(0).Rows

                ProjectLocation.Text = dr("Location").ToString
                ProjectPublishNotes.Text = dr("Publish Notes").ToString
                ProjectHiddenNotes.Text = dr("Hidden Notes").ToString
                ProjectMainImage.Text = dr("Main Image").ToString
                ProjectExtraImage1.Text = dr("Extra Image1").ToString
                ProjectExtraImage2.Text = dr("Extra Image2").ToString
                ProjectExtraImage3.Text = dr("extra Image3").ToString
                If dr("Main Image").ToString.Length > 1 Then
                    Pic1.Visible = True
                    Pic1.Load("C:\PropertyManager\Images\" + dr("Main Image").ToString)
                Else
                    'Pic1.Visible = False
                End If
                If dr("Extra Image1").ToString.Length > 1 Then
                    Pic2.Visible = True
                    Pic2.Load("C:\PropertyManager\Images\" + dr("Extra Image1").ToString)
                Else
                    'Pic2.Visible = False
                End If
                If dr("Extra Image2").ToString.Length > 1 Then
                    Pic3.Visible = True
                    Pic3.Load("C:\PropertyManager\Images\" + dr("Extra Image2").ToString)
                Else
                    'Pic3.Visible = False
                End If
                If dr("extra Image3").ToString.Length > 1 Then
                    Pic4.Visible = True
                    Pic4.Load("C:\PropertyManager\Images\" + dr("extra Image3").ToString)
                Else
                    ' Pic4.Visible = False
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            'Redio Button Project from
            If Runit.Checked = True Then
                AttachFrom = "Units"
            ElseIf Rland.Checked = True Then
                AttachFrom = "Land"
            ElseIf Rrent.Checked = True Then
                AttachFrom = "Rent"
            Else
                MessageBox.Show("Please select project for 'Units', 'Land' or 'Rent'.", "Selection", MessageBoxButtons.OK)
                Exit Sub
            End If
            If imgtf1 = False Then
                img1 = ProjectMainImage.Text
            End If
            If imgtf2 = False Then
                img2 = ProjectExtraImage1.Text
            End If
            If imgtf3 = False Then
                img3 = ProjectExtraImage2.Text
            End If
            If imgtf4 = False Then
                img4 = ProjectExtraImage3.Text
            End If


            ProjectMainImage.Text = img1
            ProjectExtraImage1.Text = img2
            ProjectExtraImage2.Text = img3
            ProjectExtraImage3.Text = img4
            Dim path As String
            path = ProjectMainImage.Text

            If Len(path.Trim) > 1 And imgtf1 = True Then
                imgtf1 = False
                UnitsDisplay.imageSize(Pic1, path, img1)
            End If
            'Image2
            path = ProjectExtraImage1.Text
            If Len(path.Trim) > 1 And imgtf2 = True Then
                imgtf2 = False
                UnitsDisplay.imageSize(Pic2, path, img2)
            End If
            'Image3
            path = ProjectExtraImage2.Text
            If Len(path.Trim) > 1 And imgtf3 = True Then
                imgtf3 = False
                UnitsDisplay.imageSize(Pic3, path, img3)
            End If
            'Image4
            path = ProjectExtraImage3.Text
            If Len(path.Trim) > 1 And imgtf4 = True Then
                imgtf4 = False
                UnitsDisplay.imageSize(Pic4, path, img4)

            End If
            If ProjectText.Text.Length < 1 Then
                Dim cmd As New OleDbCommand("Update Projects set Location='" & ProjectLocation.Text _
                & "', [Publish Notes]='" & ProjectPublishNotes.Text & "', [Project Name]='" & ProjectCombo.Text & "', [Hidden Notes]='" _
                & ProjectHiddenNotes.Text & "', [Main Image]='" & ProjectMainImage.Text _
                & "', [Extra Image1]='" & ProjectExtraImage1.Text & "', [Extra Image2] ='" _
                & ProjectExtraImage2.Text & "', [Extra Image3]='" & ProjectExtraImage3.Text & "' where [Project ID]=" & UpdateKey & " and ProjectType='" & AttachFrom & "'", Con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Project data updated.", "Update", MessageBoxButtons.OK)
            Else
                Dim cmd As New OleDbCommand("insert into Projects ([Project Name],Location,[Publish Notes],[Hidden Notes],[Main Image],[Extra Image1],[Extra Image2],[Extra Image3],[ProjectType]) values('" & ProjectText.Text & "','" & ProjectLocation.Text _
                & "','" & ProjectPublishNotes.Text & "','" _
                & ProjectHiddenNotes.Text & "','" & ProjectMainImage.Text _
                & "','" & ProjectExtraImage1.Text & "','" _
                & ProjectExtraImage2.Text & "','" & ProjectExtraImage3.Text & "','" & AttachFrom & "')", Con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("New project added.", "Update/Save", MessageBoxButtons.OK)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ProjectCombo.Text = ""
        ProjectLocation.Text = ""
        ProjectPublishNotes.Text = ""
        ProjectHiddenNotes.Text = ""
        ProjectMainImage.Text = ""
        ProjectExtraImage1.Text = ""
        ProjectExtraImage2.Text = ""
        ProjectExtraImage3.Text = ""
    End Sub
    Private Sub ImgButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgButton1.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img1 = Path.GetFileName(OpenFile.FileName.ToString)
                ProjectMainImage.Text = OpenFile.FileName.ToString
                Pic1.Load(OpenFile.FileName.ToString)
                imgtf1 = True
            Else
                img1 = Path.GetFileName(ProjectMainImage.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ImgButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgButton2.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img2 = Path.GetFileName(OpenFile.FileName.ToString)
                ProjectExtraImage1.Text = OpenFile.FileName.ToString
                Pic2.Load(OpenFile.FileName.ToString)
                imgtf2 = True
            Else
                img2 = Path.GetFileName(ProjectExtraImage1.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ImgButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgButton3.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img3 = Path.GetFileName(OpenFile.FileName.ToString)
                ProjectExtraImage2.Text = OpenFile.FileName.ToString
                Pic3.Load(OpenFile.FileName.ToString)
                imgtf3 = True
            Else
                img3 = Path.GetFileName(ProjectExtraImage2.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ImgButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgButton4.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img4 = Path.GetFileName(OpenFile.FileName.ToString)
                ProjectExtraImage3.Text = OpenFile.FileName.ToString
                Pic4.Load(OpenFile.FileName.ToString)
                imgtf4 = True
            Else
                img4 = Path.GetFileName(ProjectExtraImage3.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAll.Click
        Dim yn As String = MessageBox.Show("Would you like to delete all projects?", "Delete", MessageBoxButtons.YesNo)
        Try

            If yn = 6 Then

                ' Dim cmd As New OleDbCommand("Delete from unitstable where [Project ID]=" & CType(ProjectCombo.SelectedItem, ComboPair).Value, Con)
                ' cmd.ExecuteNonQuery()
                Dim cmd2 As New OleDbCommand("Delete from Projects where ProjectType='" & AttachFrom & "'", Con)
                cmd2.ExecuteNonQuery()
                Dim cmd3 As New OleDbCommand("Delete from " & AttachFrom & "Table", Con)
                cmd3.ExecuteNonQuery()
                MessageBox.Show("All projects and properties have been deleted.", "Projects", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Private Sub DeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelected.Click
        Dim yn As String = MessageBox.Show("Would you like to delete current Project with all related properties?", "Delete", MessageBoxButtons.YesNo)
        Try
            If yn = 6 Then
                If AttachFrom = "Units" Then
                    Dim cmd As New OleDbCommand("Delete from unitstable where [Project ID]=" & CType(ProjectCombo.SelectedItem, ComboPair).Value, Con)
                    cmd.ExecuteNonQuery()
                ElseIf AttachFrom = "Land" Then
                    Dim cmd As New OleDbCommand("Delete from Landtable where [Project ID]=" & CType(ProjectCombo.SelectedItem, ComboPair).Value, Con)
                    cmd.ExecuteNonQuery()
                ElseIf AttachFrom = "Rent" Then
                    Dim cmd As New OleDbCommand("Delete from Renttable where [Project ID]=" & CType(ProjectCombo.SelectedItem, ComboPair).Value, Con)
                    cmd.ExecuteNonQuery()
                End If

                Dim cmd2 As New OleDbCommand("Delete from Projects where [Project ID]=" & CType(ProjectCombo.SelectedItem, ComboPair).Value & " and ProjectType='" & AttachFrom & "'", Con)
                cmd2.ExecuteNonQuery()

                ProjectCombo.Text = ""
                ProjectLocation.Text = ""
                ProjectPublishNotes.Text = ""
                ProjectHiddenNotes.Text = ""
                ProjectMainImage.Text = ""
                ProjectExtraImage1.Text = ""
                ProjectExtraImage2.Text = ""
                ProjectExtraImage3.Text = ""
                MessageBox.Show("Project and all related properties Deleted.", "Delete", MessageBoxButtons.OK)
                ProjectCombo.Items.Clear()
                Dim pf As New ExtraFuntions
                pf.ProjectFuction(ProjectCombo, AttachFrom)
            Else

            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub





End Class