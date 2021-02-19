Imports System.Data.SqlClient
Public Class ManEmpleado
    Public daempleado As SqlDataAdapter
    Public dataset As DataSet
    Public strcodigo As Integer
    Public p As Integer
    Public Resultado As Integer

    Private Sub ManEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarData()
        DesHabilitar()
       
        cargar_distrito()
        ' cargar_usuario()
        '  ComboBox2.Text = ""
        ComboBox1.Text = ""
    End Sub
    Sub cargarData()

        daempleado = New SqlDataAdapter("select*from empleado", cn)
        'cmd = New SqlCommand("listar_productos", cn)
        '  daproducto = New SqlDataAdapter(cmd)
        DataSet = New DataSet()
        daempleado.Fill(dataset, "empleado")
        cn.Close()
        Me.TextBox1.DataBindings.Add("Text", dataset, "empleado.cod_emp")
        Me.TxtNombre.DataBindings.Add("text", dataset, "empleado.Nombres")
        Me.TextBox2.DataBindings.Add("Text", dataset, "empleado.direccion")
        Me.TextBox3.DataBindings.Add("Text", dataset, "empleado.cargo")
        ' Me.Label7.DataBindings.Add("Text", dataset, "empleado.cod_dis")
        'Me.Label10.DataBindings.Add("Text", dataset, "empleado.cod_usu")
        Me.MaskedTextBox1.DataBindings.Add("Text", dataset, "empleado.tel")
        Me.TextBox4.DataBindings.Add("Text", dataset, "empleado.sueldo")
        Me.DataGridView1.DataSource = DataSet
        Me.DataGridView1.DataMember = "empleado"

        'Data.Columns(0).Visible = False
        DataGridView1.Columns(0).HeaderText = "Codigo"
        DataGridView1.Columns(1).HeaderText = "Nombres"
        DataGridView1.Columns(2).HeaderText = "Direccion"
        DataGridView1.Columns(3).HeaderText = "Distrito"
        DataGridView1.Columns(4).HeaderText = "Cargo"
        DataGridView1.Columns(5).HeaderText = "Telefono"
        'DataGridView1.Columns(6).HeaderText = "Cod_usuario"
        'DataGridView1.Columns(6).HeaderText = "Codigo_Distrito"
        ' DataGridView1.Columns(5).HeaderText = "Codigo"
        DataGridView1.Columns(0).Width = "60"
        'DataGridView1.Columns(1).Width = "60"
        ' DataGridView1.Columns(3).Width = "60"
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
    Private Sub Actualizar()
        'Para actualizar el DataSet
        Dataset.Clear()
        daempleado.Fill(dataset, "empleado")
    End Sub
    Private Sub LimpiaControles()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        'TextBox4.Text = ""
        TxtNombre.Text = ""
        ComboBox1.Text = ""

        MaskedTextBox1.Text = ""
        TxtNombre.Focus()
        TextBox4.Text = ""
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(cod_emp)from empleado", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        TextBox1.Text = Format(Val(strcodigo) + 1, "00000")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        p = 1
        DataGridView1.Enabled = False
        cargar_distrito()
        'cargar_usuario()
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
        ' cargar_distrito()
        'cargar_usuario()
        p = 2
        HabilitarBotones(True)
        Habilitar()
        Button3.Enabled = False
        Button2.Enabled = True
        Button5.Enabled = True
        Button1.Enabled = False
        Button4.Enabled = False
        DataGridView1.Enabled = False
    End Sub
    Sub cargar_distrito()
        Try
            Dim DA As New SqlDataAdapter("Select * From distrito", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "distrito")
            ComboBox1.DataSource = DS.Tables("distrito")
            ComboBox1.DisplayMember = ("descripcion")
            'cbocate.ValueMember = "nom_des"
            Label7.Text = DS.Tables("distrito").Rows(0)("cod_dis")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sqlguardar As String
        If p = 1 Then
            If TxtNombre.Text = "" Then MsgBox("Ingresa el Nombre", vbOKOnly + vbInformation, "Información al usuario...!") : TxtNombre.Focus() : Exit Sub
            If TextBox2.Text = "" Then MsgBox("Ingresa Direccion", vbOKOnly + vbInformation, "Información al usuario...!") : TextBox2.Focus() : Exit Sub
            If MaskedTextBox1.Text = "" Then MsgBox("Ingrese un Telefono", vbOKOnly + vbInformation, "Información al usuario...!") : MaskedTextBox1.Focus() : Exit Sub
            If TextBox3.Text = "" Then MsgBox("Ingresa Cargo", vbOKOnly + vbInformation, "Información al usuario...!") : TextBox3.Focus() : Exit Sub

            'guardar nuevo cliente

            sqlguardar = "insert into empleado values('" & TextBox1.Text & "', '" & TxtNombre.Text & "','" & TextBox2.Text & "','" & Label7.Text & "','" & TextBox3.Text & "','" & (MaskedTextBox1.Text) & "','" & TextBox4.Text & "')"

            Dim cmd As New SqlCommand(sqlguardar, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MsgBox("Empleado guardado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "SISTEMAS Izquierdo")
            Actualizar()
            DesHabilitar()

            ComboBox1.Text = ""

            Call HabilitarBotones(True)
            Button1.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            DataGridView1.Enabled = True
            ' BTNELEMINAR.Enabled = True
            cn.Close()

        Else

            'actualiza cliente
            Try
                sqlguardar = "update empleado set nombres='" & TxtNombre.Text & "',direccion='" & TextBox2.Text & "',cod_dis='" & Label7.Text & "',cargo='" & TextBox3.Text & "',tel='" & MaskedTextBox1.Text & "',sueldo='" & TextBox4.Text & "'where cod_emp='" & TextBox1.Text & "'"
                Dim cmd As New SqlCommand(sqlguardar, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Cliente Modificado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "CPISOFT")
                Actualizar()
                DesHabilitar()
                Call HabilitarBotones(True)
                Button1.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                DataGridView1.Enabled = True
                ComboBox1.Text = ""
                'ComboBox2.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Controlado")
                'Call HabilitarBotones(True)

            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql3 As String
        sql3 = "delete from empleado where cod_emp=@Cod_emp"
        Dim objComando As New SqlCommand(sql3, cn)
        Try
            objComando.Parameters.Add(New SqlParameter("@Cod_emp", SqlDbType.VarChar))
            objComando.Parameters("@Cod_emp").Value = InputBox("Ingrese el código de Empleado a eliminar: ", "SistFarma")
            cn.Open()
            Resultado = objComando.ExecuteNonQuery
            cn.Close()
            Call Actualizar()
            '  btnAnterior.PerformClick() ' Para que muestre el registro anterior luego de eliminar
            MessageBox.Show("Registros Eliminados: " & Resultado, "", 0, MessageBoxIcon.Information)
            DesHabilitar()
        Catch exc As Exception
            MessageBox.Show(exc.Message)
        End Try
        HabilitarBotones(True)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cargar_distrito()
        If ComboBox1.Focused = True Then
            Label7.Text = ComboBox1.SelectedItem.Row("cod_dis")
        Else
            Label7.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
    End Sub

   
End Class