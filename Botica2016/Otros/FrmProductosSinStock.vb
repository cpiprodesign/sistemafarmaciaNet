Public Class FrmProductosSinStock
    Private Sub FrmProductosSinStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'listadoProducStock0.ProductosSinStock' Puede moverla o quitarla según sea necesario.
        Me.ProductosSinStockTableAdapter.Fill(Me.listadoProducStock0.ProductosSinStock)
        'TODO: esta línea de código carga datos en la tabla 'productosTodos.Productos' Puede moverla o quitarla según sea necesario.
        '  Me.ProductosTableAdapter.Fill(Me.productosTodos.Productos)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmProductosSinStock_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Button1_Click(Button1, Nothing)
        Else

            MsgBox("Eor")
        End If
    End Sub
End Class