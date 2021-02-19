Imports System.Data.SqlClient
Public Class ConClientes
    Dim dacli As New SqlDataAdapter : Dim dataset As New DataSet : Dim bus As String
    Private Sub ConClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CboBuscar.Items.Add("Codigo")
        CboBuscar.Items.Add("Nombre")
        'carga data 
        dacli = New SqlDataAdapter("select cod_cli As 'Codigo',nom_cli as'Nombres',dir_cli as 'Direccion',dni,ruc,tel as 'Telefono',cod_dis as 'Codigo_Distrito' from cliente", cn)
        dataset.Clear()
        dacli.Fill(dataset, "cliente")
        DgvCliente.DataSource = dataset.Tables("cliente")


    End Sub

    Private Sub CboBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBuscar.SelectedIndexChanged
        If CboBuscar.SelectedIndex = 0 Then
            bus = "Cod_Cli"
        ElseIf CboBuscar.SelectedIndex = 1 Then
            bus = "nom_cli"
        End If
        TxtValor.Focus()
    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress
        Try
            Dim dscli As New DataSet : Dim cris As New SqlDataAdapter
            Dim Query As String
            Query = "Select Cod_Cli As 'Codigo', nom_cli, "
            Query += "Dir_cli, dni, ruc,tel,cod_dis from Cliente "
            Query += "Where " & bus & " Like '" & TxtValor.Text & "%'"

            dscli.Clear()
            cris = New SqlDataAdapter(Query, cn)
            cris.Fill(dscli, "Cliente")


            DgvCliente.DataSource = dscli.Tables("Cliente")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
        End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

    End Sub
End Class