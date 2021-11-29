Imports System.Data.OleDb
Public Class PropertyReminder

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Visible = True
        Me.Close()
    End Sub


    Private Sub PropertyReminder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.Visible = True
    End Sub


    Private Sub PropertyReminder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim drows As DataGridViewRowCollection
        Dim i, aa As Int32
        Dim nowDate As Date = Now
        Try

            i = DataGridView1.SelectedRows.Count
            For aa = 0 To i - 1
                DataGridView1.SelectedRows(aa).Cells(1).Value = Format(nowDate, "M/dd/yyyy")
            Next
            Form1.da.Update(Form1.ds)

        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i, aa As Int32
        Dim nowDate As Date = Now
        Try

            i = DataGridView1.SelectedRows.Count
            For aa = i - 1 To 0 Step -1
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(aa)) ' = Format(nowDate, "dd/M/yyyy")
            Next
            Form1.da.Update(Form1.ds)

        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        UnitsToSell.Show()
    End Sub
End Class