Public Class FrmImput
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmImput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        ' cantidad = TextBox1.Text

    End Sub






    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cantidad = TextBox1.Text
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e

        If tmp.KeyChar = ChrW(Keys.Enter) Then

            cantidad = TextBox1.Text
            Me.Close()
            ' FrmAddPro.Close()
        Else
            cantidad = "1"
        End If
    End Sub
End Class