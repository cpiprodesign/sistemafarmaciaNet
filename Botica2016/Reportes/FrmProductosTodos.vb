Public Class FrmProductosTodos
    Private Sub FrmProductosTodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'productosTodos.Productos' Puede moverla o quitarla según sea necesario.
        Me.ProductosTableAdapter.Fill(Me.productosTodos.Productos)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class