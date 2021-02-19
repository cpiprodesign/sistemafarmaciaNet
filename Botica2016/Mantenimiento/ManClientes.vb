Imports System.Data.SqlClient

Public Class ManClientes
    Dim dacliente As SqlDataAdapter
    Dim dataset As DataSet
    Dim p As Integer
    Dim resultado As Integer
    Dim strCodigo As String
    Private Sub ManClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargar_distrito()
        cargarData()
        DesHabilitar()

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
    Sub cargarData()

        dacliente = New SqlDataAdapter("mostrarcliente", cn)
        'cmd = New SqlCommand("listar_productos", cn)
        '  daproducto = New SqlDataAdapter(cmd)
        dataset = New DataSet()
        dacliente.Fill(dataset, "cliente")
        Me.dataGridView1.DataSource = dataset.Tables("cliente")
        '' cn.Close()
        'Me.TextBox1.DataBindings.Add("Text", dataset, "cliente.cod_cli")
        'Me.TxtNombre.DataBindings.Add("text", dataset, "cliente.Nom_cli")
        'Me.txtdir.DataBindings.Add("Text", dataset, "cliente.dir_cli")
        'Me.mddni.DataBindings.Add("Text", dataset, "cliente.dni")
        'Me.mtruc.DataBindings.Add("Text", dataset, "cliente.ruc")
        'Me.mttelefono.DataBindings.Add("Text", dataset, "cliente.tel")
        ''Me.Label8.DataBindings.Add("text", Dataset, "PRODUCTOS.descripcion")
        ''Me.Label12.DataBindings.Add("text", Dataset, "productos.cod_prov")
        ''Me.Label10.DataBindings.Add("text", Dataset, "productos.cod_unidad")
        ''' Me.TextBox6.DataBindings.Add("text", Dataset, "producto.nomusu")
        ''Me.cboestado.DataBindings.Add("Text", Dataset, "Asunto.estado")
        '''Me.txtencargado.DataBindings.Add("Text", Dataset, "Asunto.encargado")
        'Me.DataGridView1.DataSource = dataset
        'Me.DataGridView1.DataMember = "cliente"
        'Label9.Text = dataset.Tables("cliente").Rows.Count
        ''Data.Columns(0).Visible = False

        'DataGridView1.Columns(3).HeaderText = "D.N.I"
        'DataGridView1.Columns(4).HeaderText = "R.U.C"
        'DataGridView1.Columns(5).HeaderText = "Telefono"
        'DataGridView1.Columns(6).HeaderText = "Codigo_Distrito"
        '' DataGridView1.Columns(5).HeaderText = "Codigo"
        'DataGridView1.Columns(0).Width = "60"
        'DataGridView1.Columns(1).Width = "60"
        ' DataGridView1.Columns(3).Width = "60"
        dataGridView1.Columns(4).Visible = False
        dataGridView1.Columns(0).HeaderText = "Codigo"
        dataGridView1.Columns(1).HeaderText = "Nombres"
        dataGridView1.Columns(2).HeaderText = "Direccion"
        Label9.Text = dataset.Tables("cliente").Rows.Count

    End Sub

    Sub cargar_distrito()
        Try
            Dim DA As New SqlDataAdapter("Select * From distrito", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "distrito")
            cbodistrito.DataSource = DS.Tables("distrito")
            cbodistrito.DisplayMember = ("descripcion")
            'cbocate.ValueMember = "nom_des"
            lblcoddis.Text = DS.Tables("distrito").Rows(0)("cod_dis")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodistrito.SelectedIndexChanged
        If cbodistrito.Focused = True Then
            lblcoddis.Text = cbodistrito.SelectedItem.Row("cod_dis")
        Else
            lblcoddis.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If


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
    Private Sub Actualizar()
        'Para actualizar el DataSet
        dataset.Clear()
        dacliente.Fill(dataset, "cliente")
        Label9.Text = dataset.Tables("cliente").Rows.Count
    End Sub
    Private Sub LimpiaControles()
        TextBox1.Text = ""
        txtdir.Text = ""
        mddni.Text = ""
        mtruc.Text = ""
        TxtNombre.Text = ""
        cbodistrito.Text = ""
        mttelefono.Text = ""
        TxtNombre.Focus()
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(cod_cli)from cliente", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        TextBox1.Text = Format(Val(strCodigo) + 1, "0000000")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_distrito()
        p = 1
        DataGridView1.Enabled = False
        cargar_distrito()
        cbodistrito.Text = ""
        lblcoddis.Text = ""
        Habilitar()
        Call HabilitarBotones(True)
        LimpiaControles()
        Button5.Enabled = True
        GENERACODIGO()
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        ' Button2.Enabled = False
        '  Button5.Enabled = False
        Call HabilitarBotones(True)
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        LimpiaControles()
        cn.Close()
        DataGridView1.Enabled = True
        Actualizar()
        DesHabilitar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'cargar_distrito()
        If TextBox1.Text = "" Then
            MsgBox("Debes selecionar cliente a Modificar")
        Else
            p = 2
            HabilitarBotones(True)
            Habilitar()
            Button3.Enabled = False
            Button2.Enabled = True
            Button5.Enabled = True
            Button1.Enabled = False
            Button4.Enabled = False
            dataGridView1.Enabled = False
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql3 As String
        sql3 = "delete from Cliente where cod_cli=@Cod_cli"
        Dim objComando As New SqlCommand(sql3, cn)
        Try
            objComando.Parameters.Add(New SqlParameter("@Cod_cli", SqlDbType.VarChar))
            objComando.Parameters("@Cod_cli").Value = InputBox("Ingrese el código del Cliente a eliminar: ")
            cn.Open()
            resultado = objComando.ExecuteNonQuery
            cn.Close()
            Call Actualizar()
            '  btnAnterior.PerformClick() ' Para que muestre el registro anterior luego de eliminar
            MessageBox.Show("Registros Eliminados: " & resultado, "", 0, MessageBoxIcon.Information)
            DesHabilitar()
        Catch exc As Exception
            MessageBox.Show(exc.Message)
        End Try
        HabilitarBotones(True)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Try
            Dim sqlguardar As String
            If p = 1 Then
                If TxtNombre.Text = "" Then MsgBox("Ingresa datos necesarios", vbOKOnly + vbInformation, "Información al usuario...!") : Exit Sub
                If cbodistrito.Text = "" Then MsgBox("Debe seleccionar el distrito", vbOKOnly + vbInformation, "Información al usuario...!") : cbodistrito.Focus() : Exit Sub
                'guardar nuevo cliente

                sqlguardar = "insert into cliente values('" & TextBox1.Text & "', '" & TxtNombre.Text & "','" & txtdir.Text & "','" & CStr(mddni.Text) & "','" & CStr(mtruc.Text) & "','" & CStr(mttelefono.Text) & "','" & lblcoddis.Text & "')"

                Dim cmd As New SqlCommand(sqlguardar, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                MsgBox("Cliente guardado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "SISTEMAS Izquierdo")
                Actualizar()
                DesHabilitar()
                Call HabilitarBotones(True)
                Label9.Text = dataset.Tables("cliente").Rows.Count
                Button1.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                DataGridView1.Enabled = True
                ' BT BTNELEMINAR.Enabled = True
                cn.Close()

            Else
                'actualiza cliente
                Try
                    sqlguardar = "update cliente set nom_cli='" & TxtNombre.Text & "',dir_cli='" & txtdir.Text & "',dni='" & mddni.Text & "',ruc='" & mtruc.Text & "',tel='" & CStr(mttelefono.Text) & "',cod_dis='" & lblcoddis.Text & "'where cod_cli='" & TextBox1.Text & "'"
                    Dim cmd As New SqlCommand(sqlguardar, cn)
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Cliente Modificado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "Sistema")
                    Actualizar()
                    DesHabilitar()
                    Call HabilitarBotones(True)
                    Button1.Enabled = True
                    Button3.Enabled = True
                    Button4.Enabled = True
                    DataGridView1.Enabled = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error Controlado")
                    'Call HabilitarBotones(True)

                End Try

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        ConClientes.ShowDialog()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.dataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("cod_cli").Value.ToString()
            TxtNombre.Text = row.Cells("Nom_cli").Value.ToString()
            txtdir.Text = row.Cells("dir_cli").Value.ToString()
            mddni.Text = row.Cells("dni").Value.ToString()
            mtruc.Text = row.Cells("ruc").Value.ToString()
            cbodistrito.Text = row.Cells("distrito").Value.ToString()
            mttelefono.Text = row.Cells("tel").Value.ToString()
            lblcoddis.Text = row.Cells("Cod_dis").Value.ToString()




            'textBox3.Text = row.Cells("Descripcion").Value.ToString()
        End If
    End Sub

    Private Sub dataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dataGridView1.KeyPress

    End Sub

    Private Sub dataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub
End Class