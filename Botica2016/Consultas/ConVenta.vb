Imports System.Data.SqlClient
Public Class ConVenta
    Dim DataAdapter As SqlDataAdapter
    Dim DataSet As New DataSet
    Dim cad As String
    Dim resultado, resultado1 As Integer
    Private Sub ConVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CboBuscar.Items.Add("Código")
        CboBuscar.Items.Add("Fecha")

        DgvFactura.ReadOnly = True
        cargar_data()
        totales()
    End Sub
    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
        Return True
    End Function
    Sub cargar_data()
        Try
            Dim da As New SqlDataAdapter("select*from boleta order by num_boleta desc", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Me.DgvFactura.DataSource = dt

            'cn.Open()
            'DataAdapter = New SqlDataAdapter("SELECT * FROM boleta order by num_boleta desc", cn)
            'DataAdapter.Fill(DataSet, "Boleta")
            '' cn.Close()
            '' DgvFactura.Rows.Clear()
            'DgvFactura.DataSource = DataSet.Tables("boleta")
            totales()
        Catch exc As Exception
            MsgBox(exc.Message)
        End Try
    End Sub
    Sub Total()
        Dim Tot As Decimal
        Dim cmdfac As SqlCommand
        cmdfac = New SqlCommand("Select Sum(total) From Boleta", cn)
        cn.Open()
        Tot = CmdFac.ExecuteScalar()
        cn.Close()
        LblTotal.Text = Format(Tot, "currency")
    End Sub
    Private Sub CboBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBuscar.SelectedIndexChanged
        Select Case CboBuscar.SelectedIndex
            Case 0
                Label6.Visible = False : Label5.Visible = False : Label2.Visible = True
                DtpFecI.Visible = False : DtpFecF.Visible = False : TxtValor.Visible = True : Cad = "Cod_Cliente"
            Case 1
                Label6.Visible = True : Label5.Visible = True : Label2.Visible = False
                DtpFecI.Visible = True : DtpFecF.Visible = True : TxtValor.Visible = False : Cad = "Fecha_factura"
        End Select

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress
       
            Try
                Dim cmd1 As New SqlCommand("buscar_boletaxnumero", cn)
                cmd1.CommandType = CommandType.StoredProcedure
                cmd1.Parameters.Add("@num_boleta", SqlDbType.VarChar, 11).Value = TxtValor.Text
                Dim data1 As New SqlDataAdapter(cmd1)
                Dim dtab1 As New DataTable
                data1.Fill(dtab1)
                Me.DgvFactura.DataSource = dtab1
                totales()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error controlado")

            End Try

        

        'If TxtValor.TextLength = 0 Then
        '    cargar_data()
        '    totales()
        'End If

    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

    End Sub

    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        If CboBuscar.Text = "codigo" Then
            Try
                Dim cmd1 As New SqlCommand("buscar_boletaxnumero", cn)
                cmd1.CommandType = CommandType.StoredProcedure
                cmd1.Parameters.Add("@num_boleta", SqlDbType.VarChar, 11).Value = TxtValor.Text
                Dim data1 As New SqlDataAdapter(cmd1)
                Dim dtab1 As New DataTable
                data1.Fill(dtab1)
                Me.DgvFactura.DataSource = dtab1
                totales()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error controlado")

            End Try
        Else
            Try
                Dim DATOS As New SqlDataAdapter("buscar", cn)
                DATOS.SelectCommand.CommandType = CommandType.StoredProcedure
                DATOS.SelectCommand.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = Me.DtpFecI.Text
                DATOS.SelectCommand.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = Me.DtpFecF.Text
                Dim ds As New DataSet
                DATOS.Fill(ds, "t")
                Me.DgvFactura.DataSource = ds.Tables("t")
                totales()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If

       
    End Sub
    Sub totales()
        'sumar columna datagridview
        Dim total As Single
        For i As Integer = 0 To DgvFactura.RowCount - 1
            total += CDbl(DgvFactura.Item("total".ToLower, i).Value)

            'Exit For
        Next
        LblTotal.Text = Format(total, "currency")

        ' Me.TextBox7.Text = Total()
        'Return total
          ' LblTotal.Text = total
        Return


    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call GridAExcel(DgvFactura)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cargar_data()
    End Sub

    Private Sub DgvFactura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFactura.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql3 As String
        Dim imput As String
        imput = InputBox("Ingrese el código de Boleta a eliminar: ")
        '-------
        Try
            Dim query As String
            query = "delete from detalle_boleta where num_boleta=@num_boleta1"
            Dim cmd As New SqlCommand(query, cn)
            cmd.Parameters.Add(New SqlParameter("@num_boleta1", SqlDbType.VarChar))
            cmd.Parameters("@num_boleta1").Value = imput
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ' cargar_data()
            cn.Close()
        End Try
        '-------
        sql3 = "delete from boleta where num_boleta=@num_boleta"
        Dim objComando As New SqlCommand(sql3, cn)
        Try
            objComando.Parameters.Add(New SqlParameter("@num_boleta", SqlDbType.VarChar))
            objComando.Parameters("@num_boleta").Value = imput
            cn.Open()
            If objComando.ExecuteNonQuery Then

                MsgBox("Boleta Eleminado", MsgBoxStyle.Information)
            Else
                MsgBox("No se Elenimo ningun Boleta", MsgBoxStyle.Information)


            End If
            ' objComando.ExecuteNonQuery()
            ' resultado = objComando.ExecuteNonQuery
            'cn.Close()
            'Call Actualizar()
            '  btnAnterior.PerformClick() ' Para que muestre el registro anterior luego de eliminar
            'DesHabilitar()
            ' cargar_data()
            'cn.Close()
        Catch exc As Exception
            MessageBox.Show(exc.Message)
        Finally
            cargar_data()
            cn.Close()
        End Try

        ' HabilitarBotones(True)

    End Sub
End Class