Public Class WebMapRent

    Private Sub Save_Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Map.Click
        Try
            MapUrl = WebBrowser1.Url.ToString
            Dim SQL As String = "update renttable set [Property Map] ='" & MapUrl & "' where [Property ID]=" & RentDisplay.TreeView1.SelectedNode.Tag
            Dim cmd As New OleDb.OleDbCommand(SQL, Con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Map saved successfully", "Message")
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub WebMap_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        WebBrowser1.Navigate(MapUrl)

    End Sub

    ' Private Sub WebMap_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
    '    MessageBox.Show(LandToSell.DataGrid1.CurrentRow.Index)
    '    OthersToSell.DataGrid1.Rows(OthersToSell.DataGrid1.CurrentRow.Index).Cells(33).Value = MapUrl
    ' End Sub

    Private Sub WebMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        WebBrowser1.Navigate("http://wikimapia.org/#lat=24.7642905&lon=55.2667236&z=9&l=0&m=t&v=1")
    End Sub
End Class