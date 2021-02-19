Public Class FrmReporteBoletaXFecha
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'TODO: esta línea de código carga datos en la tabla 'boletaxFecha.Boleta' Puede moverla o quitarla según sea necesario.
        Me.BoletaTableAdapter.Fill(Me.boletaxFecha.Boleta, Me.DateTimePicker1.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub FrmReporteBoletaXFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BoletaTableAdapter.Fill(Me.boletaxFecha.Boleta, Me.DateTimePicker1.Text)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport
        'Me.ReportViewer2.RefreshReport()
    End Sub
End Class