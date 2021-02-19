Imports System.Data.SqlClient
Imports System.IO
Public Class FrmBoletaAbenNoe
    Dim Strcodigo As String
    Private fil As Byte
    Private carrito As New DataTable()
    Private totales As Single
    Private dr As DataRow
    Public descuento As Double
    Dim r As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub FrmBoletaAbenNoe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        GENERACODIGO()

        TextBox5.Focus()
        Label9.Text = Format(Now, "dd-MM-yyyy")
        ConfiguraTablas()
        limpiar_venta()
        btnnuevo_Click(btnnuevo, Nothing)


        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If tmp.KeyChar = ChrW(Keys.F1) Then
        '    ' MessageBox.Show("Enter key")
        '    FrmAddPro.ShowDialog()
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)

        'End If
        ''para guardar producto'
        ''If tmp.KeyChar = ChrW(Keys.F5) Then
        ''    ' MessageBox.Show("Enter key")
        ''    btnguardar_Click(btnguardar, Nothing)
        ''Else
        ''    ' MessageBox.Show(tmp.KeyChar)

        ''End If



    End Sub
    Sub limpiar_venta()
        Label10.Text = ""
        ' TextBox2.Text = ""
        ' TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox5.Focus()
        LblSub.Text = ""

        lbltotal.Text = ""
        '  nuddescuento.Value.
        ' nuddescuento.Value = 0

        carrito.Clear()
        btnguardar.Enabled = True


    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(num_boleta)from boleta", cn)
        cn.Open()
        Strcodigo = cmd.ExecuteScalar
        cn.Close()
        Label8.Text = Format(Val(Strcodigo) + 1, "0000000")
    End Sub
    Sub carga_cliente()
        Try
            TextBox5.Focus()
            If TextBox5.Text = "" Then
                MsgBox("Ingrese su DNI " & Chr(13), MsgBoxStyle.Exclamation, "Sistema")
                TextBox5.Text = ""
                TextBox5.Focus()
            Else
                Dim cmd As New SqlCommand("Mostrar_cliente", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@dni", SqlDbType.Char, 10).Value = TextBox5.Text
                'cmd.Parameters.Add("@dia", SqlDbType.VarChar, 11).Value = dia
                'cmd.Parameters.Add("@horaini", SqlDbType.VarChar, 11).Value = Button1.Text

                Dim dr As SqlDataReader
                cn.Open()
                dr = cmd.ExecuteReader

                If dr.Read Then
                    Label10.Text = dr(0)
                    TextBox4.Text = dr(1)
                    'cn.Close()
                    dr.Close()
                    ' FrmAddPro.ShowDialog()
                    Call btnbuscarproducto_Click(btnbuscarproducto, Nothing)
                Else
                    MsgBox("No esta registrado el cliente " & Chr(13), MsgBoxStyle.Exclamation, "Sistema")
                    MsgBox("Se procedera a Registrarlo " & Chr(13), MsgBoxStyle.Exclamation, "Sistema")
                    dr.Close()
                    ManClientes.Show()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        'carga_cliente()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        'If Asc(e.KeyChar) = 13 Then

        '    TextBox4.Focus()
        ' End If

        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            ' MessageBox.Show("Enter key")
            carga_cliente()
            Label10.Focus()
        Else
            ' MessageBox.Show(tmp.KeyChar)
            TextBox4.Text = ""
            Label10.Text = ""
        End If

    End Sub

    Private Sub BtnExaminar_Click(sender As Object, e As EventArgs) Handles BtnExaminar.Click
        carga_cliente()
    End Sub

    Private Sub TextBox5_Enter(sender As Object, e As EventArgs) Handles TextBox5.Enter
        ' carga_cliente()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ConfiguraTablas()
        Dim dc0 As New DataColumn("Codigo", System.Type.GetType("System.String"))
        Dim dc1 As New DataColumn("Descripcion", System.Type.GetType("System.String"))
        Dim dc2 As New DataColumn("Cantidad", System.Type.GetType("System.Int16"))
        Dim dc3 As New DataColumn("PrecioUnitario", System.Type.GetType("System.Decimal"))
        Dim dc4 As New DataColumn("SubTotal", System.Type.GetType("System.Decimal"))

        'Dim dc5 As New DataColumn("Total", System.Type.GetType("System.Decimal"))

        dc0.Unique = True
        dc4.Expression = "Cantidad*PrecioUnitario"
        With carrito.Columns
            .Add(dc0)
            .Add(dc1)
            .Add(dc2)
            .Add(dc3)
            .Add(dc4)
            '.Add(dc5)
            total()
            DataGridView1.DataSource = carrito
            DataGridView1.Columns(0).Width = "60"
            DataGridView1.Columns(2).Width = "50"
        End With
        'DataGridView1.Columns(0).Width = "60"

    End Sub
    Private Sub total()
        Dim i As Integer
        Dim total, igv, totalp As Single
        For i = 0 To carrito.Rows.Count - 1
            total += carrito.Rows(i)(4)

        Next
        Me.LblSub.Text = Format(total, "###0.00")
        Me.lbltotal.Text = Format(total, "###0.00")

        'igv = total * 19 / 100
        'txtigv.Text = igv.ToString("n1")
        'totalp = total + igv
        'Me.txtfinal.Text = totalp.ToString("n1")
    End Sub
    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Try
            fil = DataGridView1.CurrentCell.RowIndex
            If fil > -1 And carrito.Rows.Count > 0 Then
                totales -= Single.Parse(DataGridView1.Item(4, fil).Value)
                carrito.Rows.RemoveAt(fil)
                Dim i As Integer
                For i = 0 To carrito.Rows.Count - 1
                    carrito.Rows(i).BeginEdit()
                    carrito.Rows(i)(0) = i + 1
                    carrito.Rows(i).EndEdit()
                Next
                total()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If tmp.KeyChar = ChrW(Keys.Enter) Then
        '    ' MessageBox.Show("Enter key")
        '    ' FrmAddPro.ShowDialog()
        '    btnbuscarproducto_Click(btnbuscarproducto, Nothing)
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)
        '    ' TextBox4.Text = ""
        '    ' Label10.Text = ""
        'End If

        '' Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If tmp.KeyChar = ChrW(Keys.F1) Then
        '    ' MessageBox.Show("Enter key")
        '    FrmAddPro.ShowDialog()
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)

        'End If
        ''para guardar producto'
        'If tmp.KeyChar = ChrW(Keys.F5) Then
        '    ' MessageBox.Show("Enter key")
        '    btnguardar_Click(btnguardar, Nothing)
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)

        'End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        total()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub nuddescuento_ValueChanged(sender As Object, e As EventArgs) Handles nuddescuento.ValueChanged
        'Dim descuento
        descuento = (LblSub.Text) * (nuddescuento.Text) / 100
        total()
        If nuddescuento.Value = 0 Then
            total()
            '  lbltotal.Text = LblSub.Text
        Else

            Me.lbltotal.Text = Format((LblSub.Text) - (descuento), "##0.0")

            'lbltotal.Text = LblSub.Text
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Desea Cancelar los Productos Ingresados", 4 + 32, "Cancelando Productos") = MsgBoxResult.Yes Then
            carrito.Clear()
            ' limpiar_producto()
            Me.total()
        Else
            MsgBox("Descartando Elimacion de Registros")
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        Dim buscar As New frmAgregarProductos
        Dim i As Integer
        'Dim r As String
        'For i = 0 To carrito.Rows.Count - 1
        '    r = carrito.Rows(i)(0)
        'Next
        Try
            If FrmAddPro.ShowDialog() = DialogResult.Cancel Then
                'carrito.Clear()
                dr = carrito.NewRow()
                dr(0) = codigo_produco
                dr(1) = descripcion
                dr(2) = cantidad
                dr(3) = precio
                carrito.Rows.Add(dr)
                total()


                ''
                '
                'carrito.Clear()


                'codigo_produco = ""
                'descripcion = ""
                'cantidad = 0
                'precio = ""

            Else
                carrito.Clear()
                'dr = carrito.Clear
                'dr(0) = ""
                'dr(1) = ""
                'dr(2) = ""
                'dr(3) = ""
                'carrito.Rows.Add(dr)
                'total()
            End If
        Catch ex As Exception
            MsgBox("Producto ya fue Agregado al Pedido ")
        End Try

    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        GUARDAR()
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        btnguardar.Enabled = True
        GENERACODIGO()
        limpiar_venta()

        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pdg 'Dialogo de Print
            .Document = pdt
            .AllowPrintToFile = False
            .AllowSelection = True
            .AllowSomePages = True
            If .ShowDialog() = DialogResult.OK Then
                pdt.PrinterSettings = .PrinterSettings
                pdt.Print()
            End If
        End With
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
    Private Sub pdt_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdt.PrintPage
        Dim i As Integer
        Dim stb, stbsalto, stbpago, stbDetalle As New System.Text.StringBuilder()
        Dim Texto, SaltoDeLinea, txtpago, txtdetalle As String
        '/// Se establece el tipo de Fuente        
        Dim Fuente As New Font("Verdana", 11)
        '/// Se establece el Color de Fuente
        Dim Brocha As Brush = Brushes.Blue
        '/// Se establece las cordenadas
        Dim X As Integer = e.MarginBounds.Left
        Dim Y As Integer = e.MarginBounds.Top
        '/// Se Genera toda la cadena de impresion en blanco
        '/// Se Genera toda la cadena de impresion en blanco
        stbsalto.Append("")
        SaltoDeLinea = stbsalto.ToString
        e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbsalto.Length = 0
        '------------
        stbDetalle.Append("--BOTICA ABENNOE--")
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, 100, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbDetalle.Append(Label1.Text)
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, 100, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbDetalle.Append("BOLETA ELECTRONICA")
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, 100, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbDetalle.Append("Nº " & Label8.Text)
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, 100, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbDetalle.Append("----------------------------------------------------------------------------")
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight

        stbDetalle.Length = 0
        stbDetalle.Append("FECHA DE EMISION:  " & Now)
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbDetalle.Length = 0
        stbDetalle.Append("VENDEDOR:  " & Nombre)
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0


        stbDetalle.Append("SENOR(A):  " & Me.TextBox4.Text)
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        'stbsalto.Append("")
        'SaltoDeLinea = stbsalto.ToString
        'e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, X, Y)
        'Y = Y + Fuente.GetHeight
        'stbsalto.Length = 0
        '----------------------
        stbDetalle.Append("D.N.I: " & Me.TextBox5.Text)
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbsalto.Append("")
        SaltoDeLinea = stbsalto.ToString
        e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbsalto.Length = 0

        '/// Se Genera toda la cadena de impresion
        stbDetalle.Append("DETALLE DEL PEDIDO")
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbDetalle.Length = 0

        stbsalto.Append("")
        SaltoDeLinea = stbsalto.ToString
        e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbsalto.Length = 0



        stbDetalle.Append("Codigo    Descripcion     Cantidad         PrecioUnitario    ")
        txtdetalle = stbDetalle.ToString
        e.Graphics.DrawString(txtdetalle, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight



        'Se genera un bucle, dicho bucle reproduce y obtiene los valores del DataTable
        'Ademas se imprime en la Hoja
        For i = 0 To carrito.Rows.Count - 1
            stb.Append(carrito.Rows(i)(0).ToString.PadRight(10))
            stb.Append(carrito.Rows(i)(1).ToString.PadRight(15))
            stb.Append(carrito.Rows(i)(2).ToString.PadRight(20))
            stb.Append(carrito.Rows(i)(3).ToString.PadRight(10))
            stb.Append(carrito.Rows(i)(4).ToString.PadRight(10))
            ' stb.Append(carrito.Rows(i)(5).ToString.PadRight(10))
            Texto = stb.ToString
            e.Graphics.DrawString(Texto, Fuente, Brocha, X, Y)
            Y = Y + Fuente.GetHeight
            stb.Length = 0
        Next




        '/// Se Genera toda la cadena de impresion en blanco
        stbsalto.Append("----------------------------------------------------------------------------")
        SaltoDeLinea = stbsalto.ToString
        e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbsalto.Length = 0

        ''/// Se Genera toda la cad666ena de impresion en blanco
        stbsalto.Append("Subtotal:S/" & LblSub.Text)
        SaltoDeLinea = stbsalto.ToString
        e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, 450, Y)
        Y = Y + Fuente.GetHeight
        stbsalto.Length = 0

        stbsalto.Append("Descuento:S/" & descuento)
        SaltoDeLinea = stbsalto.ToString
        e.Graphics.DrawString(SaltoDeLinea, Fuente, Brocha, 450, Y)
        Y = Y + Fuente.GetHeight
        stbsalto.Length = 0

        '/// Se imprime el valor del Total
        stbpago.Append("Total :S/ " & Me.lbltotal.Text)
        txtpago = stbpago.ToString
        e.Graphics.DrawString(txtpago, Fuente, Brocha, 450, Y)
        Y = Y + Fuente.GetHeight
        stbpago.Length = 0

        stbpago.Append("GRACIAS POR SU PREFERENCIA")
        txtpago = stbpago.ToString
        e.Graphics.DrawString(txtpago, Fuente, Brocha, X, Y)
        Y = Y + Fuente.GetHeight
        stbpago.Length = 0

        ''/// Se imprime el valor del IGV
        'stbpago.Append("IGV : " & Me.txtigv.Text)
        'txtpago = stbpago.ToString
        'e.Graphics.DrawString(txtpago, Fuente, Brocha, 350, Y)
        'Y = Y + Fuente.GetHeight
        'stbpago.Length = 0

        ''/// Se imprime el valor del Total a Pagar
        'stbpago.Append("Total a Pagar : " & Me.txtfinal.Text)
        'txtpago = stbpago.ToString
        'e.Graphics.DrawString(txtpago, Fuente, Brocha, 350, Y)
        'Y = Y + Fuente.GetHeight
        'stbpago.Length = 0
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

    End Sub

    Private Sub FrmBoletaAbenNoe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If tmp.KeyChar = ChrW(Keys.A) Then
        '    ' MessageBox.Show("Enter key")
        '    FrmAddPro.ShowDialog()
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)

        'End If
        ''para guardar producto'
        'If tmp.KeyChar = ChrW(Keys.F5) Then
        '    ' MessageBox.Show("Enter key")
        '    btnguardar_Click(btnguardar, Nothing)
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)

        'End If
    End Sub

    Private Sub FrmBoletaAbenNoe_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.G Then

            GUARDAR()
        ElseIf e.KeyData = Keys.B
            btnbuscarproducto_Click(btnbuscarproducto, Nothing)
        ElseIf e.KeyData = Keys.P
            With pdg 'Dialogo de Print
                .Document = pdt
                .AllowPrintToFile = False
                .AllowSelection = True
                .AllowSomePages = True
                If .ShowDialog() = DialogResult.OK Then
                    pdt.PrinterSettings = .PrinterSettings
                    pdt.Print()

                End If


            End With
        Else
            ' MsgBox("No se Guardo la Venta", MsgBoxStyle.Exclamation)
        End If
    End Sub



    Sub GUARDAR()
        If TextBox4.Text = "" Then
            MsgBox("Debes ingresar el Cliente", MsgBoxStyle.Exclamation, "Sistema")
        ElseIf carrito.Rows.Count > 0 Then
            Try
                Dim XGs As New SqlCommand("grabar_boleta", cn)
                XGs.CommandType = CommandType.StoredProcedure
                XGs.Parameters.Add(New SqlParameter("@num_boleta", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label8.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@fecha", SqlDbType.DateTime, ParameterDirection.Input)).Value = (Label9.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@cod_cli", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label10.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@cod_usu", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (CodUsu).ToUpper
                XGs.Parameters.Add(New SqlParameter("@subtotal", SqlDbType.Decimal, ParameterDirection.Input)).Value = (LblSub.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@descuento", SqlDbType.Decimal, ParameterDirection.Input)).Value = (nuddescuento.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@total", SqlDbType.Decimal, ParameterDirection.Input)).Value = (lbltotal.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@NOP", SqlDbType.Char, 10, ParameterDirection.Input)).Value = ("").ToUpper
                cn.Open()
                XGs.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Boleta Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            'MessageBox.Show("Debe agregar al menos un Producto a Comprar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End If
        ' guardar detalle________________________________
        Dim i As Integer
        Dim idproducto, descripcion, precio, cantidad, importe, sql2 As String

        ' cn.Open()|

        For i = 0 To carrito.Rows.Count - 1
            idproducto = carrito.Rows(i)(0)
            descripcion = carrito.Rows(i)(1)
            precio = carrito.Rows(i)(3)
            cantidad = carrito.Rows(i)(2)
            importe = carrito.Rows(i)(4)
            sql2 = "insert into Detalle_boleta values('" & (Me.Label8.Text) & "','" & carrito.Rows(i)(0) & "','" & carrito.Rows(i)(2) & "','" & precio & "','" & (importe) & "')"
            Dim cmd2 As New SqlCommand(sql2, cn)
            cn.Open()
            cmd2.ExecuteNonQuery()
            cn.Close()
            ' nuevo_venta()
            btnguardar.Enabled = False
            Button1.Enabled = False
            'nuddescuento.Value = 0
            'IMPRIMIR

        Next

        If MsgBox("Desea Imprimir Boleta", 4 + 32, "Boleta") = MsgBoxResult.Yes Then
            With pdg 'Dialogo de Print
                .Document = pdt
                .AllowPrintToFile = False
                .AllowSelection = True
                .AllowSomePages = True
                If .ShowDialog() = DialogResult.OK Then
                    pdt.PrinterSettings = .PrinterSettings
                    pdt.Print()
                End If
            End With
            'Me.TotalValores()
        Else
            'MsgBox("Descartando Elimacion de Registros")
        End If
        'limpiar_venta()
        ' GENERACODIGO()
        btnnuevo_Click(btnnuevo, Nothing)
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown

    End Sub
End Class