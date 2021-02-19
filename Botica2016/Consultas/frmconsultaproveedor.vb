Imports System.Data.SqlClient
Public Class frmconsultaproveedor
    Dim bus As String
    Private Sub frmconsultaproveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtValor.Focus()
        CboBuscar.Items.Add("Codigo")
        CboBuscar.Items.Add("Nombre")
        CboBuscar.Items.Add("RUC")
        'carga Data
        Dim da As New SqlDataAdapter("select *from proveedor order by cod_proveedor desc", cn)
        Dim dt As New DataTable
        da.Fill(dt)
        Me.DataGridView1.DataSource = dt
    End Sub

    Private Sub CboBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBuscar.SelectedIndexChanged
        If CboBuscar.SelectedIndex = 0 Then
            bus = "cod_proveedor"
        ElseIf CboBuscar.SelectedIndex = 1 Then
            bus = "Nombre"
        ElseIf CboBuscar.SelectedIndex = 2 Then

            bus = "RUC"

        End If

        TxtValor.Focus()
    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress
        Try
            Dim Query As String
            Query = "Select Cod_proveedor As 'Codigo', nombre, "
            Query += "Direccion, telefono, otros,ruc from proveedor "
            Query += "Where " & bus & " Like '" & TxtValor.Text & "%'"
            Dim da As New SqlDataAdapter(Query, cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Me.DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class