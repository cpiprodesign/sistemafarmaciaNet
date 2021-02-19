Imports System.Data.SqlClient
Public Class Frmconsulta_empleados
    Dim bus As String
    Private Sub Frmconsulta_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CboBuscar.Items.Add("Codigo")
        CboBuscar.Items.Add("Nombre")
        TxtValor.Focus()
        Dim da As New SqlDataAdapter("select*from empleado order by cod_emp  desc", cn)
        Dim dt As New DataTable
        da.Fill(dt)
        Me.DgvCliente.DataSource = dt
        combo()


    End Sub
    Sub combo()

        If CboBuscar.Text = "" Then
            TxtValor.Enabled = False
        Else
            TxtValor.Enabled = True
        End If
    End Sub
    Private Sub CboBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBuscar.SelectedIndexChanged
        If CboBuscar.SelectedIndex = 0 Then
            bus = "Cod_emp"
            TxtValor.Focus()
            combo()
        ElseIf CboBuscar.SelectedIndex = 1 Then
            bus = "nombres"
            TxtValor.Focus()
            combo()
        Else
            TxtValor.Enabled = False
        End If
        TxtValor.Focus()
    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress
        Try
            Dim dscli As New DataSet : Dim cris As New SqlDataAdapter
            Dim Query As String
            Query = "Select Cod_emp As 'Codigo', nombres, "
            Query += "direccion,cod_dis,cargo,tel,sueldo from empleado "
            Query += "Where " & bus & " Like '" & TxtValor.Text & "%'"

            dscli.Clear()
            cris = New SqlDataAdapter(Query, cn)
            cris.Fill(dscli, "empleado")


            DgvCliente.DataSource = dscli.Tables("empleado")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
End Class