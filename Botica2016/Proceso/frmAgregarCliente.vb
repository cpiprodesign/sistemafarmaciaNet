Imports System.Data.SqlClient
Public Class frmAgregarCliente


    Sub carga_Cliente()
        Dim da As New SqlDataAdapter("select*from cliente", cn)
        Dim ds As New DataSet
        ds.Clear()
        da.Fill(ds, "cliente")
        Data.DataSource = ds.Tables("Cliente")
    End Sub



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Try
            Dim dscli As New DataSet : Dim cris As New SqlDataAdapter
            Dim Query As String
            Dim Bus As String
            Bus = "nom_cli"

            Query = "Select Cod_Cli As 'Codigo', nom_cli, "
            Query += "Dir_cli, dni, ruc,tel,cod_dis from Cliente "
            Query += "Where " & Bus & " Like '" & TextBox1.Text & "%'"

            dscli.Clear()
            cris = New SqlDataAdapter(Query, cn)
            cris.Fill(dscli, "Cliente")


            Data.DataSource = dscli.Tables("Cliente")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellContentClick

    End Sub

    Private Sub Data_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellDoubleClick
        codcli = Data.Rows(e.RowIndex).Cells(0).Value
        nombre_cli = Data.Rows(e.RowIndex).Cells(1).Value
        ruc = Data.Rows(e.RowIndex).Cells(4).Value
        '   precio = Data.Rows(e.RowIndex).Cells(3).Value
        '  pproducto.Visible = False
        Me.Close()
    End Sub


    Private Sub Data_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Data.KeyPress

    End Sub

    Private Sub Data_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Data.RowEnter


    End Sub

    Private Sub frmAgregarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel1.Visible = True
        carga_Cliente()
    End Sub
End Class