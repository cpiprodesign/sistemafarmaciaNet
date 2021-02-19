Public Class FrmReporte_Empleados
    Private Sub FrmReporte_Empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'boletaxFecha.Boleta' Puede moverla o quitarla según sea necesario.
        ' Me.BoletaTableAdapter.Fill(Me.boletaxFecha.Boleta)
        'TODO: esta línea de código carga datos en la tabla 'BoticaJavierDataSet.Empleado' Puede moverla o quitarla según sea necesario.
        Me.EmpleadoTableAdapter.Fill(Me.BoticaJavierDataSet.Empleado)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class