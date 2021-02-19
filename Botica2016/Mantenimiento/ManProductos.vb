Imports System.Data.SqlClient
Public Class ManProductos
    Dim daproducto As SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim flag As Integer
    Dim resultado As Integer
    Dim strCodigo As String
    Dim p As Integer
    Sub cargarData()

        'daproducto = New SqlDataAdapter("Productos.cod_pro,Productos.Descripcion,Productos.pre_compra,Productos.pre_venta,Productos.fecha_vencimiento,categoria.descripcion as Categoria inner join Categoria on Categoria.cod_cate=Productos.cod_cate", cn)
        cmd = New SqlCommand("listar_productos", cn)
        daproducto = New SqlDataAdapter(cmd)
        Dataset = New DataSet()
        daproducto.Fill(Dataset, "productos")
        cn.Close()
        'Me.TextBox1.DataBindings.Add("Text", Dataset, "productoS.cod_pro")
        'Me.TextBox2.DataBindings.Add("text", Dataset, "productos.descripcion")
        'Me.TextBox3.DataBindings.Add("text", Dataset, "productos.pre_venta")
        'Me.TextBox4.DataBindings.Add("text", Dataset, "productos.pre_compra")
        'Me.DateTimePicker1.DataBindings.Add("text", Dataset, "productos.fecha_vencimiento")
        'Me.TextBox5.DataBindings.Add("text", Dataset, "productos.stock")

        Me.DataGridView1.DataSource = Dataset
        Me.DataGridView1.DataMember = "productos"
        Me.DataGridView1.Columns(6).Visible = False
        Me.DataGridView1.Columns(9).Visible = False
        Me.DataGridView1.Columns(11).Visible = False

        'Data.Columns(0).Visible = False
        DataGridView1.Columns(0).Width = "60"
        DataGridView1.Columns(2).Width = "60"
        DataGridView1.Columns(3).Width = "60"
        DataGridView1.Columns(0).HeaderText = "Codigo"
        Label13.Text = Dataset.Tables("productos").Rows.Count
    End Sub
    Private Sub Actualizar()
        'Para actualizar el DataSet
        Dataset.Clear()
        daproducto.Fill(Dataset, "productos")
    End Sub
    Private Sub LimpiaControles()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox2.Focus()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        DateTimePicker1.Text = ""
        Label8.Text = ""
        Label10.Text = ""
        Label12.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        'ComboBox1.SelectedIndex = 0
        'ComboBox2.SelectedIndex = 0

    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(cod_pro)from productos", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        TextBox1.Text = Format(Val(strCodigo) + 1, "0000000")
    End Sub
    Sub cargar_categoria()
        Try
            Dim DA As New SqlDataAdapter("Select * From categoria", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "categoria")
            ComboBox1.DataSource = DS.Tables("categoria")
            ComboBox1.DisplayMember = ("descripcion")
            ' cbocate.ValueMember = "nom_des"
            Label8.Text = DS.Tables("categoria").Rows(0)("cod_cate")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_medida()
        Try
            Dim DA As New SqlDataAdapter("Select * From presentacion", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "presentacion")
            ComboBox2.DataSource = DS.Tables("presentacion")
            ComboBox2.DisplayMember = ("descripcion")
            Label10.Text = DS.Tables("presentacion").Rows(0)("cod_presentacion")

            'cbocate.ValueMember = "nom_des"
            ' dis.Text = DS.Tables("distrito").Rows(0)("cod_dis")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_Proveedor()
        Try
            Dim DA As New SqlDataAdapter("Select * From proveedor", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "proveedor")
            ComboBox3.DataSource = DS.Tables("proveedor")
            ComboBox3.DisplayMember = ("nombre")
            'cbocate.ValueMember = "nom_des"
            Label12.Text = DS.Tables("proveedor").Rows(0)("cod_proveedor")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try

    End Sub
    Private Sub ManProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Enabled = True


        'Label10.Visible = True
        'Label12.Visible = True
        'Label8.Visible = True
        Call HabilitarBotones(True)
        cargarData()
        cargar_categoria()
        cargar_medida()
        cargar_Proveedor()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

        Call DesHabilitar()
        ' Button6.Enabled = True
        'LimpiaControles()

    End Sub
    Private Sub HabilitarBotones(ByVal est As Boolean)
        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button Then ctrl.Enabled = est
        Next
        Button2.Enabled = Not est
        Button5.Enabled = Not est
        ' Button3.Enabled = Not est
        'Button4.Enabled = Not est
    End Sub
    Sub DesHabilitar()
        For Each Con In Controls
            If TypeOf Con Is TextBox Then Con.enabled = False
            If TypeOf Con Is NumericUpDown Then Con.enabled = False
            If TypeOf Con Is ComboBox Then Con.enabled = False
            If TypeOf Con Is DateTimePicker Then Con.enabled = False
            If TypeOf Con Is MaskedTextBox Then Con.enabled = False

        Next
    End Sub
    Sub Habilitar()
        For Each Con In Controls
            If TypeOf Con Is TextBox Then Con.enabled = True
            If TypeOf Con Is NumericUpDown Then Con.enabled = True
            If TypeOf Con Is ComboBox Then Con.enabled = True
            If TypeOf Con Is DateTimePicker Then Con.enabled = True
            If TypeOf Con Is MaskedTextBox Then Con.enabled = True


        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        p = 1
        DataGridView1.Enabled = False

        Habilitar()
        Call HabilitarBotones(True)
        LimpiaControles()
        Button5.Enabled = True
        GENERACODIGO()
        Button2.Enabled = True
        Button3.Enabled = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True

        GENERACODIGO()
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        ' Habilitar()
        '  LimpiaControles()




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Focused = True Then
            Label8.Text = ComboBox1.SelectedItem.Row("cod_cate")
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Focused = True Then
            Label10.Text = ComboBox2.SelectedItem.Row("cod_presentacion")
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Focused = True Then
            Label12.Text = ComboBox3.SelectedItem.Row("cod_proveedor")
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DesHabilitar()
        ' Button2.Enabled = False
        '  Button5.Enabled = False
        Call HabilitarBotones(True)
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        LimpiaControles()
        cn.Close()
        Actualizar()
        DataGridView1.Enabled = True
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        Label10.Text = ""
        Label8.Text = ""
        Label12.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If p = 1 Then
                Try
                    If TextBox2.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
                        MsgBox("Debes ingrsar Datos Necesarios..", MsgBoxStyle.Exclamation, "Sistema")
                    Else
                        'Grabando la cabecera de la Orden 
                        Dim XG As New SqlCommand("grabarproducto", cn)
                        XG.CommandType = CommandType.StoredProcedure
                        XG.Parameters.Add(New SqlParameter("@cod_pro", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (TextBox1.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (TextBox2.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@pre_venta", SqlDbType.Decimal, ParameterDirection.Input)).Value = (TextBox3.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@pre_compra", SqlDbType.Decimal, ParameterDirection.Input)).Value = (TextBox4.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@fecha_vencimiento", SqlDbType.DateTime, ParameterDirection.Input)).Value = (DateTimePicker1.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@stock", SqlDbType.Int, ParameterDirection.Input)).Value = (TextBox5.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@cod_cate", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label8.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@cod_unidad", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label10.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@cod_prov", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label12.Text).ToUpper

                        cn.Open()
                        XG.ExecuteNonQuery()
                        cn.Close()
                        MessageBox.Show("Producto Registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Actualizar()
                        Call HabilitarBotones(True)
                        Button1.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        DataGridView1.Enabled = True
                        Call LimpiaControles()
                        DesHabilitar()

                        'Else
                        '    MessageBox.Show("Debe ingresar datos necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                Catch exc As Exception
                    MessageBox.Show(exc.Message)
                Finally
                    cn.Close()
                End Try

                'SQLGuardar = "insert into Productos values('" & TextBox1.Text & "', '" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & (TextBox1.Text) & "','" & TextBox5.Text & "','" & Label8.Text & "','" & Label10.Text & "','" & Label12.Text & "')"

                'Dim cmd As New SqlCommand(SQLGuardar, cn)
                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()

                'MsgBox("Producto guardado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "SISTEMAS Izquierdo")
                'Actualizar()
                '' BTNELEMINAR.Enabled = True
                'cn.Close()


            Else
                Try
                    If TextBox1.Text = "" Then
                        MsgBox("Debes ingresar Datos Necesarios..", MsgBoxStyle.Exclamation, "Sistema")
                    Else


                        'Grabando la cabecera de la Orden 
                        Dim XG As New SqlCommand("actualizar_producto", cn)
                        XG.CommandType = CommandType.StoredProcedure
                        XG.Parameters.Add(New SqlParameter("@cod_pro", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (TextBox1.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (TextBox2.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@pre_venta", SqlDbType.Decimal, ParameterDirection.Input)).Value = (TextBox3.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@pre_compra", SqlDbType.Decimal, ParameterDirection.Input)).Value = (TextBox4.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@fecha_vencimiento", SqlDbType.DateTime, ParameterDirection.Input)).Value = (DateTimePicker1.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@stock", SqlDbType.Int, ParameterDirection.Input)).Value = (TextBox5.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@cod_cate", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label8.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@cod_unidad", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label10.Text).ToUpper
                        XG.Parameters.Add(New SqlParameter("@cod_prov", SqlDbType.Char, 10, ParameterDirection.Input)).Value = (Label12.Text).ToUpper

                        cn.Open()
                        XG.ExecuteNonQuery()
                        cn.Close()
                        MessageBox.Show("Producto Actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Actualizar()
                        Call HabilitarBotones(True)
                        Button1.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        DataGridView1.Enabled = True
                        Call LimpiaControles()
                        DesHabilitar()
                        '    Else
                        '    MessageBox.Show("Debe ingresar datos necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Catch exc As Exception
                    MessageBox.Show(exc.Message)
                Finally
                    cn.Close()
                End Try
                'Try
                '    SQLGuardar = "update productos set descripcion='" & TextBox2.Text & "',pre_venta='" & CInt(TextBox3.Text) & "',pre_compra='" & CInt(TextBox4.Text) & "',fecha_vencimiento='" & fecha.Text & "',stock=stock +('" & CInt(TextBox5.Text) & "'),cod_cate='" & Label8.Text & "',cod_unidad='" & Label10.Text & "',cod_prov='" & Label12.Text & "'where cod_pro='" & TextBox1.Text & "'"
                '    Dim cmd As New SqlCommand(SQLGuardar, cn)
                '    cn.Open()
                '    cmd.ExecuteNonQuery()
                '    cn.Close()
                '    MsgBox("Producto Modificado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "CPISOFT")
                '    Actualizar()
                '    DesHabilitar()
                '    Call HabilitarBotones(True)
                '    Button1.Enabled = True
                '    Button3.Enabled = True
                '    DataGridView1.Enabled = True
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message, "Error Controlado")
                '    'Call HabilitarBotones(True)

                'End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' cn.Close()
        Finally
            cn.Close()
        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Debes selecionar un Producto a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            p = 2
            HabilitarBotones(True)
            Habilitar()
            Button3.Enabled = False
            Button2.Enabled = True
            Button5.Enabled = True
            Button1.Enabled = False
            Button4.Enabled = False
            DataGridView1.Enabled = False
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql3 As String
        sql3 = "delete from productos where cod_pro=@Cod_pro"
        Dim objComando As New SqlCommand(sql3, cn)
        Try
            objComando.Parameters.Add(New SqlParameter("@Cod_pro", SqlDbType.VarChar))
            objComando.Parameters("@Cod_pro").Value = InputBox("Ingrese el código del Producto a eliminar: ")
            cn.Open()
            resultado = objComando.ExecuteNonQuery
            cn.Close()
            Call Actualizar()
            '  btnAnterior.PerformClick() ' Para que muestre el registro anterior luego de eliminar
            MessageBox.Show("Registros Eliminados: " & resultado, "", 0, MessageBoxIcon.Information)
        Catch exc As Exception
            MessageBox.Show(exc.Message)
        End Try
        HabilitarBotones(True)

    End Sub
    Sub pasar_datos()
        Try
            Dim Pos As Integer
            Pos = DataGridView1.CurrentRow.Index
            DataGridView1.Rows(Pos).Selected = True
            Me.ComboBox1.Text = DataGridView1.Rows(Pos).Cells(7).Value
            'Me.txtrazonsocial.Text = dgvbusquedaxruc.Rows(Pos).Cells(1).Value
            'Me.txtruc.Text = dgvbusquedaxruc.Rows(Pos).Cells(2).Value
            'Me.txtdireccion.Text = dgvbusquedaxruc.Rows(Pos).Cells(3).Value
            'pproveedor.Visible = False
        Catch EX As Exception
            MessageBox.Show("Tabla proveedor vacia,ingresar datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'conProductos.ShowDialog()
        Dim input As String = InputBox("Ingrese su codigo del Producto ")

        'Dim cm As New SqlCommand("select * from productos where cod_pro ='" & input & "'", cn)
        Dim cmd As New SqlCommand("buscar_producto_cod", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@cod", SqlDbType.Char, 10).Value = input
        Dim dr As SqlDataReader
        cn.Open()
        dr = cmd.ExecuteReader
        If dr.Read Then
            TextBox1.Text = dr(0)
            TextBox2.Text = dr(1)
            TextBox3.Text = dr(3)
            TextBox4.Text = dr(2)
            DateTimePicker1.Text = dr(4)
            TextBox5.Text = dr(6)
            ComboBox1.Text = dr(7)
            ComboBox2.Text = dr(5)
            ComboBox3.Text = dr(8)
        Else
            MsgBox("Producto No Encontrado")

        End If
        cn.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("cod_pro").Value.ToString()
            TextBox2.Text = row.Cells("descripcion").Value.ToString()
            TextBox4.Text = row.Cells("pre_compra").Value.ToString()
            TextBox3.Text = row.Cells("pre_venta").Value.ToString()
            DateTimePicker1.Text = row.Cells("fecha_vencimiento").Value.ToString()
            TextBox5.Text = row.Cells("stock").Value.ToString()
            ComboBox1.Text = row.Cells("categoria").Value.ToString()
            Label8.Text = row.Cells("cod_cate").Value.ToString()
            ComboBox2.Text = row.Cells("presentacion").Value.ToString()
            Label10.Text = row.Cells("cod_presentacion").Value.ToString()
            ComboBox3.Text = row.Cells("proveedor").Value.ToString()
            Label12.Text = row.Cells("cod_prov").Value.ToString()





        End If

    End Sub
End Class