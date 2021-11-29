Public Class OverWriteMessage

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.Visible = False
            OwM = "Over"
            Dim pro As New DesktopWork
            If OverWriteFrom = 1 Then
                pro.UnitsToAccess(PathUnits)
                '            UnitsToSell.UnitsTableTableAdapter.Fill(UnitsToSell.MerecDataSet.UnitsTable)
            ElseIf OverWriteFrom = 2 Then
                pro.LandToAccess(PathLand)
                '  LandToSell.LandTableTableAdapter.Fill(LandToSell.MerecDataSet.LandTable)
            ElseIf OverWriteFrom = 3 Then
                pro.OtherToAccess(PathOther)
                ' OthersToSell.OtherTableTableAdapter.Fill(OthersToSell.MerecDataSet.OtherTable)

            ElseIf OverWriteFrom = 4 Then
                pro.RentToAccess(PathRent)
                'RentAProperty.RentTableTableAdapter.Fill(RentAProperty.MerecDataSet.RentTable)


            End If
            Me.Close()
        Catch es As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Visible = False
            Dim pro As New DesktopWork

            OwM = "Add"
            If OverWriteFrom = 1 Then
                pro.UnitsToAccess(PathUnits)
                'UnitsToSell.UnitsTableTableAdapter.Fill(UnitsToSell.MerecDataSet.UnitsTable)

            ElseIf OverWriteFrom = 2 Then
                pro.LandToAccess(PathLand)
                'LandToSell.LandTableTableAdapter.Fill(LandToSell.MerecDataSet.LandTable)
            ElseIf OverWriteFrom = 3 Then
                pro.OtherToAccess(PathOther)
                'OthersToSell.OtherTableTableAdapter.Fill(OthersToSell.MerecDataSet.OtherTable)

            ElseIf OverWriteFrom = 4 Then
                pro.RentToAccess(PathRent)
                'RentAProperty.RentTableTableAdapter.Fill(RentAProperty.MerecDataSet.RentTable)


            End If
            Me.Close()
        Catch es As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        OwM = "Cancel"
        Me.Close()
    End Sub
End Class