Imports System.Data.SqlClient
Public Class ConVentaPorvendedor
    Private Sub ConVentaPorvendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand("carga_usuario", cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        ds.Clear()
        da.Fill(ds, "usuario")
        Me.CboBuscar.DataSource = ds.Tables("usuario")
        CboBuscar.DisplayMember = "nombres"
        Label1.Text = ds.Tables("usuario").Rows(0)("cod_usu")
        DataGridView1.Columns(0).Width = "50"


        Button1_Click(Button1, Nothing)
    End Sub
    Sub consulta()
        Dim cmd As New SqlCommand("lista_venta_vendedor", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@usu", SqlDbType.Char, 10).Value = Label1.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Me.DataGridView1.DataSource = dt
        totales()
    End Sub
    Sub totales()
        'sumar columna datagridview
        Dim total As Single
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += CDbl(DataGridView1.Item("total".ToLower, i).Value)

            'Exit For
        Next
        LblTotal.Text = Format(total, "currency")

        ' Me.TextBox7.Text = Total()
        'Return total
        ' LblTotal.Text = total
        Return
    End Sub
    Private Sub CboBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBuscar.SelectedIndexChanged
        consulta()

        If CboBuscar.Focused Then
            Label1.Text = CboBuscar.SelectedItem.row("cod_usu")
        Else
            Label1.Text = ""
        End If
        Button1_Click(Button1, Nothing)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        consulta()
    End Sub
End Class