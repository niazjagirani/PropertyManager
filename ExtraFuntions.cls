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

Public Class ExtraFuntions
    Public Sub imageSize(ByVal img As PictureBox, ByVal fileName As String, ByVal OnlyName As String)
        Try
            img.Load(fileName)
            Dim bm As New Bitmap(img.Image) 'img.Image)
            Dim x As Int32 = 400 'variable for new width size
            Dim y As Int32 = 400 'variable for new height size

            Dim width As Integer = Val(x) 'image width. 

            Dim height As Integer = Val(y) 'image height

            Dim thumb As New Bitmap(width, height)

            Dim g As Graphics = Graphics.FromImage(thumb)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
    bm.Height), GraphicsUnit.Pixel)

            g.Dispose()


            'image path. better to make this dynamic. I am hardcoding a path just for example sake
            thumb.Save("C:\PropertyManager\Images\" & OnlyName, _
    System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

            bm.Dispose()

            thumb.Dispose()
        Catch es As Exception
        End Try
        ' Me.Close()  'exit app
    End Sub

    Public Function SearchClick(ByVal table As String, ByVal field As String, ByVal value As String) As DataTable
        Dim ds As New DataSet
        Try
            ' MessageBox.Show(SearchCombo.Text)
            Dim sql As String = "Select * from" & table & " where " & field & " like '%" & value & "%'"
            Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)

            Dim cmd As New OleDbCommand(sql, Con)
            Dim da As New OleDbDataAdapter(cmd)

            da.Fill(ds, "LandTable")
            'Me.MerecDataSet. = ds.Tables(0)
            '       DataGrid1.DataSource = ds.Tables(0)
            '      DataGrid1.Refresh()
            ' Me.UnitsTableTableAdapter.Fill(Me.MerecDataSet.UnitsTable)

            '        For Each clm As DataColumn In ds.Tables(0).Columns
            'SearchCombo.Items.Add(clm.ToString)
            'Next

            Return ds.Tables(0)
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
            Return ds.Tables(0)
        End Try

    End Function
    Public Sub UnitsForm()
        Try
            ' MessageBox.Show(SearchCombo.Text)
            Dim sql As String = "Select * from UnitsTable"
            Dim Con = New OleDbConnection(My.Settings.MerecConnectionString)
            Dim cmd As New OleDbCommand(sql, Con)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "LandTable")
            'Me.MerecDataSet. = ds.Tables(0)
            UnitsToSell.DataGrid1.DataSource = ds.Tables(0)
            UnitsToSell.DataGrid1.Refresh()
            ' Me.UnitsTableTableAdapter.Fill(Me.MerecDataSet.UnitsTable)

            '        For Each clm As DataColumn In ds.Tables(0).Columns
            'SearchCombo.Items.Add(clm.ToString)
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Public Sub ProjectFuction(ByVal Obj As ComboBox, ByVal type As String)
        Dim daProjects As New OleDbDataAdapter("Select * from Projects where projecttype='" & type & "' order by [project name] asc", Con)
        Dim ds As New DataSet
        daProjects.Fill(ds, "Projects")
        ' ProjectCombo.Items.Add(New ComboPair(0, "New Property"))

        For Each dr As DataRow In ds.Tables(0).Rows

            Obj.Items.Add(New ComboPair(dr("Project ID"), dr("Project Name")))
        Next

    End Sub

End Class
