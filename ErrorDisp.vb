Imports System.Windows.Forms

Public Class ErrorDisp

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        '     Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '   Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
