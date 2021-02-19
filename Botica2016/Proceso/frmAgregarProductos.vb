Imports System.Data.SqlClient
Public Class frmAgregarProductos
    Private Sub txtbuscarproductoxnombre_TextChanged(sender As Object, e As EventArgs) Handles txtbuscarproductoxnombre.TextChanged
        Try
            Dim cmd2 As New SqlCommand("buscar_productoxnombre", cn)
            cmd2.CommandType = CommandType.StoredProcedure
            cmd2.Parameters.Add("@descripcion", SqlDbType.VarChar, 11).Value = Me.txtbuscarproductoxnombre.Text
            Dim data As New SqlDataAdapter(cmd2)
            Dim dtab2 As New DataTable
            data.Fill(dtab2)
            Me.Data.DataSource = dtab2

        Catch ex As Exception
            MsgBox("Error al buscar proveedor")
        End Try
    End Sub
    Sub carga_producto()
        Try
            Dim cmd As SqlCommand : Dim daproducto As New SqlDataAdapter : Dim dataset As New DataSet
            cmd = New SqlCommand("listar_productos", cn)
            daproducto = New SqlDataAdapter(cmd)
            dataset = New DataSet()
            daproducto.Fill(dataset, "producto")
            cn.Close()
            Me.Data.DataSource = dataset.Tables("producto")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")


        End Try
    End Sub


    Private Sub dgvbuscarproducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellContentClick
        '   precio = Data.Rows(e.RowIndex).Cells(3).Value
        '  pproducto.Visible = False

    End Sub

    Private Sub Data_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellDoubleClick
        codigo_produco = Data.Rows(e.RowIndex).Cells(0).Value
        descripcion = Data.Rows(e.RowIndex).Cells(1).Value
        precio = Data.Rows(e.RowIndex).Cells(3).Value
        crisstock = Data.Rows(e.RowIndex).Cells(6).Value
        Me.Close()

    End Sub

    Private Sub frmAgregarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_producto()
        pproducto.Visible = True
        txtbuscarproductoxnombre.Focus()
    End Sub

    Private Sub pproducto_Paint(sender As Object, e As PaintEventArgs) Handles pproducto.Paint

    End Sub
End Class