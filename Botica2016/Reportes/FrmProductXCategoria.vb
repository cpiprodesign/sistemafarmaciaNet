Imports System.Data.SqlClient
Public Class FrmProductXCategoria
    Private Sub FrmProductXCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'ProductXCategory.Productos' Puede moverla o quitarla según sea necesario.

        Dim da As New SqlDataAdapter("select*from categoria", cn)
        Dim ds As New DataSet
        da.Fill(ds, "categoria")
        ComboBox1.DataSource = ds.Tables("categoria")
        ComboBox1.DisplayMember = "descripcion"
        Label2.Text = ds.Tables("categoria").Rows(0)("cod_cate")

        Button1_Click(Button1, Nothing)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Focused = True Then
            Label2.Text = ComboBox1.SelectedItem.Row("cod_cate")
        Else
            Label2.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
        Me.ProductosTableAdapter.Fill(Me.ProductXCategory.Productos, Label2.Text)

        Me.ReportViewer1.RefreshReport()
        Button1_Click(Button1, Nothing)
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.ProductosTableAdapter.Fill(Me.ProductXCategory.Productos, Label2.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class