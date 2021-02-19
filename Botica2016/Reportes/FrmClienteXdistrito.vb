Imports System.Data.SqlClient
Public Class FrmClienteXdistrito

    Private Sub FrmClienteXdistrito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Clientexdistrito.DataTable1' Puede moverla o quitarla según sea necesario.
        ' Me.DataTable1TableAdapter.Fill(Me.Clientexdistrito.DataTable1)
        'TODO: esta línea de código carga datos en la tabla 'BoticaJavierDataSet.Cliente' Puede moverla o quitarla según sea necesario.
        Dim da As New SqlDataAdapter("select*from distrito", cn)
        Dim ds As New DataSet
        ds.Clear()
        da.Fill(ds, "Distrito")
        ComboBox1.DataSource = ds.Tables("distrito")
        ComboBox1.DisplayMember = ("descripcion")
        ' lblcodigo.ValueMember = "Cod_dis"
        lblcodigo.Text = ds.Tables("distrito").Rows(0)("cod_dis")

        Button1_Click(Button1, Nothing)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Focused = True Then
            lblcodigo.Text = ComboBox1.SelectedItem.Row("cod_dis")
        Else
            lblcodigo.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
        Button1_Click(Button1, Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DataTable1TableAdapter.Fill(Me.Clientexdistrito.DataTable1, lblcodigo.Text)

        Me.ReportViewer1.RefreshReport()


    End Sub


End Class