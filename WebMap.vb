Public Class WebMap

    Private Sub Save_Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Map.Click
        Try
            MapUrl = WebBrowser1.Url.ToString
            Dim SQL As String = "update Unitstable set [Property Map] ='" & MapUrl & "' where [Property ID]=" & UnitsDisplay.TreeView1.SelectedNode.Tag
            Dim cmd As New OleDb.OleDbCommand(SQL, Con)
            '        UnitsToSell.DataGrid1.Rows(UnitsDisplay.DataGrid1.CurrentRow.Index).Cells(41).Value = MapUrl
            cmd.ExecuteNonQuery()
            MessageBox.Show("Map saved successfully", "Message")
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            WebBrowser1.Navigate("http://wikimapia.org/#lat=24.7642905&lon=55.2667236&z=9&l=0&m=t&v=1")
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
    Private Sub WebMap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If MapUrl.Length > 1 Then
                WebBrowser1.Navigate(MapUrl)
            Else
                WebBrowser1.Navigate("http://wikimapia.org/#lat=24.7642905&lon=55.2667236&z=9&l=0&m=t&v=1")
            End If
        Catch ex As Exception
            MessageBox.Show("No Property selected to Map.", "Property Map.", MessageBoxButtons.OK)
            Me.Close()
        End Try
    End Sub
End Class