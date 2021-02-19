Public Class FrmClientestodos
    Private Sub FrmClientestodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BoticaJavierDataSet.Cliente' Puede moverla o quitarla según sea necesario.
        Me.ClienteTableAdapter.Fill(Me.BoticaJavierDataSet.Cliente)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class