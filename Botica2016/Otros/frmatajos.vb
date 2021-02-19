Public Class frmatajos
    Private Sub frmatajos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub frmatajos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Space Then
            ManClientes.ShowDialog()
        Else
            MsgBox("no vale")
        End If
    End Sub
End Class