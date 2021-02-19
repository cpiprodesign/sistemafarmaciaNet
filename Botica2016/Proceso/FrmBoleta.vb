Imports System.Data.SqlClient
Imports System.IO
Public Class FrmBoleta
    Dim strcodigo As Integer
    Private carrito As New DataTable("DATALLE")
    Private dr As DataRow
    Public descuento As String
    ' Dim strCodigo As String
    Dim fila As Integer = 0
    Private fil As Byte
    Private totales As Single
    Dim tbldet As New DataTable("detalle") ' creamos una tabla dinamica
    Dim rw As DataRow
    Dim Objorden As New DataTable
    Public Nombre As String, Pro As String


    Private Sub FrmBoletaDirecta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConfiguraTablas()


        GENERACODIGO()
        TextBox2.Text = Format(Now, "dd-MM-yyyy")
        'Dim Ds As New DataSet()
        'tbldet = Ds.Tables.Add
        'With tbldet.Columns
        ''    .Add("Codigo", Type.GetType("System.String"))
        '    .Add("Producto", Type.GetType("System.String"))
        '    .Add("Precio", Type.GetType("System.Single"))
        '    .Add("Cantidad", Type.GetType("System.Int32"))
        '    .Add("Total", Type.GetType("System.Single"))
        'End With
        ''Agregamos una Clave Principal a la Tabla Dinamica 
        ''para que no se repìtan los registros 
        'With Ds.Tables(0)
        '    .PrimaryKey = New DataColumn() {.Columns("Codigo")}
        'End With
        'DataGridView1.DataSource = tbldet
        'DataGridView1.Columns(0).Width = "60"
        ' ''''''''''''''''''''''FormatearGrid()
    End Sub
    Sub nuevo_venta()
        Lblcod.Text = ""
        LblCliente.Text = ""
        LblRuc.Text = ""
        txtidproducto.Text = ""
        txtdescripcion.Text = ""
        Lbstock.Text = ""
        LBPRECIO.Text = ""
        txtcantidad.Text = ""
        LblSub.Text = ""
        ' nuddescuento.Value = 0
        lbltotal.Text = ""
        carrito.Clear()

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
    Private Sub ConfiguraTablas()
        Dim dc0 As New DataColumn("Codigo", System.Type.GetType("System.String"))
        Dim dc1 As New DataColumn("Descripcion", System.Type.GetType("System.String"))
        Dim dc2 As New DataColumn("Cantidad", System.Type.GetType("System.Int16"))
        Dim dc3 As New DataColumn("PrecioUnitario", System.Type.GetType("System.Decimal"))
        Dim dc4 As New DataColumn("SubTotal", System.Type.GetType("System.Decimal"))

        'Dim dc5 As New DataColumn("Total", System.Type.GetType("System.Decimal"))
        dc1.Unique = True
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
            DataGridView1.Columns(2).Width = "60"
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

    Private Sub ConfiguraTabla()
        Dim DsCRIS As New DataSet()
        tbldet = DsCRIS.Tables.Add
        With tbldet.Columns
            .Add("Codigo", Type.GetType("System.String"))
            .Add("Producto", Type.GetType("System.String"))
            .Add("Precio", Type.GetType("System.Single"))
            .Add("Cantidad", Type.GetType("System.Int16"))
            .Add("Total", Type.GetType("System.single"))
        End With
        'Agregamos una Clave Principal a la Tabla Dinamica 
        'para que no se repìtan los registros 
        With DsCRIS.Tables(0)
            .PrimaryKey = New DataColumn() { .Columns("Codigo")}
        End With
        DataGridView1.DataSource = tbldet


    End Sub


    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(num_boleta)from boleta", cn)
        cn.Open()
        strcodigo = cmd.ExecuteScalar
        cn.Close()
        TextBox3.Text = Format(Val(strcodigo) + 1, "0000000")
    End Sub


    Private Sub BtnExaminar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pproducto_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtbuscarproductoxnombre_TextChanged(sender As Object, e As EventArgs)


    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        nuevo_venta()
        btnguardar.Enabled = True
        Button1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox4.Enabled = True
        DataGridView1.Enabled = True
        Try
            GENERACODIGO()
            TextBox2.Text = Format(Now, "dd-MM-yyyy")

            '.Text = generar("Boleta", "num_boleta")
            'habilitar()
            'limpiar()
            'Me.txtidproveedor.Focus()
        Catch ex As Exception
            MsgBox("Revisar")
        End Try
        '
    End Sub

    Private Sub BtnExaminar_Click_1(sender As Object, e As EventArgs)
        ' carga_Cliente()
        'Panel1.Visible = True
        'FrmBoletaDirecta.Size.Width = 791
    End Sub

    Private Sub btnbuscarproducto_Click_1(sender As Object, e As EventArgs)
        '()
        ' pproducto.Visible = True
    End Sub


    Private Sub btnbuscarproducto_Click_2(sender As Object, e As EventArgs)
        'carga_producto()
        ' pproducto.Visible = True
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub dgvbuscarproducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnbuscarproducto_Click_3(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        Dim buscar As New frmAgregarProductos
        If frmAgregarProductos.ShowDialog() = DialogResult.Cancel Then
            'frmAgregarProductos.ShowDialog()



            txtidproducto.Text = codigo_produco
            txtdescripcion.Text = descripcion
            LBPRECIO.Text = precio
            Lbstock.Text = crisstock
            'txtpais.Text = strpais
            'txttelefono.Text = strtelefono
        End If 'Panel1.Visible = True
        'carga_Cliente()
        ' FRMdetalle_cliente.ShowDialog()
        'carga_producto()
        '  pproducto.Visible = True
        'FrmBoletaDirecta.Width = 790

        ' FrmBoletaDirecta.Size = New System.Drawing.Size(790, 606)
        'FrmBoletaDirecta.Width = 790

        'Form1.Width = 790
        ' Form1.Height = 606
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub BtnExaminar_Click_2(sender As Object, e As EventArgs) Handles BtnExaminar.Click
        Dim buscar As New frmAgregarCliente
        If frmAgregarCliente.ShowDialog() = DialogResult.Cancel Then
            ' frmAgregarCliente.ShowDialog()
            Lblcod.Text = codcli
            LblCliente.Text = nombre_cli
            LblRuc.Text = ruc
            'txtpais.Text = strpais
            'txttelefono.Text = strtelefono
        End If 'Panel1.Visible = True
        'carga_Cliente()
        ' FRMdetalle_cliente.ShowDialog()
    End Sub


    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
    Sub TotalValores()
        Dim Xtotal As Single
        Xtotal = IIf(carrito.Compute("Sum(subTotal)", Nothing) Is DBNull.Value, 0, tbldet.Compute("Sum(Total)", Nothing))
        Me.LblSub.Text = Format(Xtotal, "###0.00")
        lbltotal.Text = LblSub.Text
        'Me.LblIgv.Text = Format(Xtotal * 0.18, "###0.00")
        'Me.LblTotal.Text = Format(Xtotal + (Xtotal * 0.18), "##0.00")
    End Sub


    Private Sub txtbuscarproductoxnombre_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Dim a As Integer
        Dim b As Integer : Dim CODPRO As String : Dim R As String
        Dim i As Integer
        a = (txtcantidad.Text)
        b = Lbstock.Text
        CODPRO = txtidproducto.Text
        For i = 0 To carrito.Rows.Count - 1
            R = carrito.Rows(i)(0)
        Next
        Try

            If Me.txtcantidad.Text = "" Then
                MessageBox.Show("Falta llenar la cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            ElseIf a > b Then
                MessageBox.Show("La cantidad supera el stock", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txtcantidad.Text = "1"
            ElseIf CODPRO = R Then
                MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")

            Else
                dr = carrito.NewRow()
                ' dr(0) = carrito.Rows.Count + 1
                dr(0) = txtidproducto.Text
                ' dr(1) = ComboBox2.SelectedValue.ToString
                dr(1) = txtdescripcion.Text

                'dr(2) = cboproducto.Text
                dr(2) = txtcantidad.Text
                dr(3) = LBPRECIO.Text
                carrito.Rows.Add(dr)
                total()
                limpiar_producto()

            End If

            'Catch ex1 As System.Data.ConstraintException
            limpiar_producto()
        Catch ex1 As System.Data.ConstraintException
            MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")

            ' MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        'If txtidproducto.Text <> "" Then
        '    If LBPRECIO.Text <> "" Then
        '        If txtcantidad.Text <> "" Then
        '            If Val(Lbstock.Text) < Val(txtcantidad.Text) Then
        '                MsgBox("La cantidad comprada sobrepasa la cantidad en stock", MsgBoxStyle.Critical, "Error de ingreso de datos!!!")
        '            End If
        '            rw = tbldet.NewRow()
        '            rw(0) = Me.txtidproducto.Text
        '            rw(1) = Me.txtdescripcion.Text
        '            rw(2) = Me.LBPRECIO.Text
        '            rw(3) = Me.txtcantidad.Text
        '            rw(4) = CDbl(rw(2)) * CDbl(rw(3))
        '            Try
        '                tbldet.Rows.Add(rw)
        '                tbldet.AcceptChanges()
        '                Me.TotalValores()

        '                limpiar_producto()

        '            Catch ex1 As System.Data.ConstraintException
        '                MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")

        '                'Catch Ex As Exception
        '                '''''MsgBox(Ex.Message)
        '                'Actualizar codigo 
        '                MsgBox("Se Procedera a Actualizar el Producto" & Space(2) & Me.txtdescripcion.Text)
        '                rw = tbldet.Rows.Find(Me.txtidproducto.Text)
        '                rw.BeginEdit()
        '                rw(3) += CInt(Me.txtcantidad.Text)
        '                rw(4) = CDec(rw(2)) * CDec(rw(3))
        '                rw.EndEdit()
        '                tbldet.AcceptChanges()
        '                Me.TotalValores()
        '                limpiar_producto()
        '            End Try
        '        Else
        '            MessageBox.Show("Ingrese la Cantidad a Comprar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        End If
        '    Else
        '        MessageBox.Show("Ingrese el precio a Comprar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    End If
        'Else
        '    MessageBox.Show("Elija un producto a Comprar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        'End If
    End Sub
    Sub limpiar_producto()
        txtidproducto.Text = ""
        txtdescripcion.Text = ""
        LBPRECIO.Text = ""
        Lbstock.Text = ""
        txtcantidad.Text = ""
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
        'If tbldet.Rows.Count > 0 Then
        '    'Se Procedera a la Busqueda del Producto para Eliminar 
        '    Dim fila As Int32 = CInt(Me.DataGridView1.CurrentRow.Index)
        '    Dim textos As String = carrito.Rows(fila)(1).ToString()
        '    If MsgBox("Desea Eliminar el Producto" & Space(2) & textos, 4 + 32, "ELIMINANDO PRODUCTO DETALLE") = MsgBoxResult.Yes Then
        '        rw = carrito.Rows.Find(tbldet.Rows(fila)(0))
        '        rw.Delete()
        '        tbldet.AcceptChanges()
        '        Me.total()
        '    Else
        '        MsgBox("Descartando Eliminacion")
        '    End If
        'Else
        '    MessageBox.Show("No hay Productos a Eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        'End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Desea Cancelar los Productos Ingresados", 4 + 32, "Cancelando Productos") = MsgBoxResult.Yes Then
            carrito.Clear()
            limpiar_producto()
            Me.total()
        Else
            MsgBox("Descartando Elimacion de Registros")
        End If

    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click


        If Lblcod.Text = "" Then
            MsgBox("Debes ingresar el Cliente", MsgBoxStyle.Exclamation, "Sistema")
        ElseIf carrito.Rows.Count > 0 Then
            Try
                Dim XGs As New SqlCommand("grabar_boleta", cn)
                XGs.CommandType = CommandType.StoredProcedure
                XGs.Parameters.Add(New SqlParameter("@num_boleta", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (TextBox3.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@fecha", SqlDbType.DateTime, ParameterDirection.Input)).Value = (TextBox2.Text).ToUpper
                XGs.Parameters.Add(New SqlParameter("@cod_cli", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Lblcod.Text).ToUpper
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
            precio = carrito.Rows(i)(2)
            cantidad = carrito.Rows(i)(3)
            importe = carrito.Rows(i)(4)
            sql2 = "insert into Detalle_boleta values('" & (Me.TextBox3.Text) & "','" & carrito.Rows(i)(0) & "','" & carrito.Rows(i)(2) & "','" & precio & "','" & (importe) & "')"
            Dim cmd2 As New SqlCommand(sql2, cn)
            cn.Open()
            cmd2.ExecuteNonQuery()
            cn.Close()
            ' nuevo_venta()
            btnguardar.Enabled = False
            Button1.Enabled = False
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
        nuevo_venta()
        GENERACODIGO()
        '  cmd2.Dispose()cn
        '  MessageBox.Show("detalle boleta Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        'Next
        ' Catch ex As Exception
        'MsgBox(ex.Message)

        cn.Close()

        ''sql2 =      End Try"insert into Detalle_boleta(num_boleta,cod_pro,nom_pro,cantidad,precio_venta,importe) values('" + CStr("0000002") + "','" + CStr(idproducto) + "','" + CStr(descripcion) + "','" + ChrW(cantidad) + "','" + CDec(precio) + "','" + CDec(importe) + "')"
        ' Dim cmd2 As New SqlCommand(sql2, cn)
        '    For i = 0 To DataGridView1.RowCount - 1
        '        idproducto = DataGridView1.Rows(i).Cells(0).Value
        '        descripcion = DataGridView1.Rows(i).Cells(1).Value
        '        precio = DataGridView1.Rows(i).Cells(2).Value
        '        cantidad = DataGridView1.Rows(i).Cells(3).Value
        '        importe = DataGridView1.Rows(i).Cells(4).Value
        '        Dim XG As New SqlCommand("grabar_detalle_boleta", cn)
        '        XG.CommandType = CommandType.StoredProcedure
        '        XG.Parameters.Add(New SqlParameter("@num_boleta", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (TextBox3.Text).ToUpper
        '        XG.Parameters.Add(New SqlParameter("@cod_pro", SqlDbType.Char, 10, ParameterDirection.Input)).Value = "0000001"
        '        XG.Parameters.Add(New SqlParameter("@nom_pro", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = DataGridView1.Rows(i).Cells(1).Value
        '        XG.Parameters.Add(New SqlParameter("@cantidad", SqlDbType.Char, 4, ParameterDirection.Input)).Value = DataGridView1.Rows(i).Cells(2).Value
        '        XG.Parameters.Add(New SqlParameter("@precio_venta", SqlDbType.Decimal, ParameterDirection.Input)).Value = "10"
        '        XG.Parameters.Add(New SqlParameter("@importe", SqlDbType.Decimal, ParameterDirection.Input)).Value = "23"
        '        ' XGs.Parameters.Add(New SqlParameter("@total", SqlDbType.Decimal, ParameterDirection.Input)).Value = (lbltotal.Text).ToUpper
        '        ' XGs.Parameters.Add(New SqlParameter("@NOP", SqlDbType.Char, 10, ParameterDirection.Input)).Value = ("").ToUpper
        '        cn.Open()
        '        XG.ExecuteNonQuery()
        '        cn.Close()
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        ''End If

        '        ''Try
        '        ''    If Lblcod.Text <> "" Then
        ''        If tbldet.Rows.Count > 0 Then
        ''            'Grabando la cabecera de la Orde
        ''            Dim XG As New SqlCommand("grabar_boleta", cn)
        ''            XG.CommandType = CommandType.StoredProcedure
        ''            'XG.Parameters.Add(New SqlParameter("@cod_factura", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (LblFactura.Text).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@num_boleta", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (TextBox3.Text).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@fecha", SqlDbType.DateTime, ParameterDirection.Input)).Value = (TextBox2.Text).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@cod_cli", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (LblCliente.Text).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@cod_usu", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (CodUsu).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@descuento", SqlDbType.Money, ParameterDirection.Input)).Value = (nuddescuento.Text).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@total", SqlDbType.Money, ParameterDirection.Input)).Value = (lbltotal.Text).ToUpper
        ''            XG.Parameters.Add(New SqlParameter("@NOP", SqlDbType.Money, ParameterDirection.Input)).Value = ("0000000").ToUpper
        ''            cn.Open()
        ''            XG.ExecuteNonQuery()
        ''            cn.Close()
        ''            MessageBox.Show("Boleta Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ''        Else
        ''            MessageBox.Show("Debe agregar al menos un Producto a Comprar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        ''        End If

        '    ''guardar detalle________________________________
        '    Dim i As Integer
        '    Dim idproducto, descripcion, precio, cantidad, importe, sql2 As String
        '    bd.Open()
        '    For i = 0 To DataGridView1.RowCount - 1
        '        idproducto = DataGridView1.Rows(i).Cells(0).Value
        '        descripcion = DataGridView1.Rows(i).Cells(1).Value
        '        precio = DataGridView1.Rows(i).Cells(2).Value
        '        cantidad = DataGridView1.Rows(i).Cells(3).Value
        '        importe = DataGridView1.Rows(i).Cells(4).Value
        '        sql2 = "insert into detalle(id_fac,cod_producto,cantidad,precio,total) values('" + Me.LblFactura.Text + "','" + idproducto + "','" + cantidad + "','" + precio + "','" + importe + "')"
        '        Dim cmd2 As New SqlCommand(sql2, bd)
        '        cmd2.ExecuteNonQuery()
        '        cmd2.Dispose()
        '    Next
        'Else
        '    MessageBox.Show("Elija el cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    End If
        'Catch ex As Exception
        '    Throw ex
        '    'MsgBox(ex.Message)
        'End Try
        'limpiar_producto()
        'cn.Close()

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Try
            Dim XGs As New SqlCommand("grabar_boleta", cn)
            XGs.CommandType = CommandType.StoredProcedure
            XGs.Parameters.Add(New SqlParameter("@num_boleta", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (TextBox3.Text).ToUpper
            XGs.Parameters.Add(New SqlParameter("@fecha", SqlDbType.DateTime, ParameterDirection.Input)).Value = (TextBox2.Text).ToUpper
            XGs.Parameters.Add(New SqlParameter("@cod_cli", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Lblcod.Text).ToUpper
            XGs.Parameters.Add(New SqlParameter("@cod_usu", SqlDbType.Char, 10, ParameterDirection.Input)).Value = ("00001").ToUpper
            XGs.Parameters.Add(New SqlParameter("@subtotal", SqlDbType.Decimal, ParameterDirection.Input)).Value = (LblSub.Text).ToUpper
            XGs.Parameters.Add(New SqlParameter("@descuento", SqlDbType.Decimal, ParameterDirection.Input)).Value = (nuddescuento.Text).ToUpper
            XGs.Parameters.Add(New SqlParameter("@total", SqlDbType.Decimal, ParameterDirection.Input)).Value = (lbltotal.Text).ToUpper
            XGs.Parameters.Add(New SqlParameter("@NOP", SqlDbType.Char, 10, ParameterDirection.Input)).Value = ("").ToUpper
            cn.Open()
            XGs.ExecuteNonQuery()
            cn.Close()
            MessageBox.Show("Boleta Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


        Catch exc As Exception
            ' Throw exc
            MsgBox(exc.Message)
        End Try
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
    Private Sub pdt_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdt.PrintPage

    End Sub
    Private Sub LblSub_Click(sender As Object, e As EventArgs) Handles LblSub.Click

    End Sub
End Class