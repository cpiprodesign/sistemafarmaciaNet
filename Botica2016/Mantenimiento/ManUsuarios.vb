Imports System.Data.SqlClient
Public Class ManUsuarios
    Dim dausuario As SqlDataAdapter
    Dim dataset As DataSet
    Dim p As Integer
    Dim resultado As Integer
    Dim strCodigo As String
    Dim s As Integer
    Dim nivel As Integer
    Dim nombres As String
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
    Private Sub Actualizar()
        'Para actualizar el DataSet
        Dataset.Clear()
        dausuario.Fill(dataset, "usuario")
    End Sub
    Private Sub LimpiaControles()

        TxtUsu.Text = ""
        TxtCon.Text = ""
        TxtUsu.Focus()
        'MaskedTextBox1.Text = ""
        Label6.Text = ""
        ComboBox1.Text = ""

    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(cod_usu)from usuario", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        LblCod.Text = Format(Val(strCodigo) + 1, "00000")
    End Sub
    Sub cargar_empleado()
        Try
            Dim DA As New SqlDataAdapter("Select * From empleado", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "empleado")
            ComboBox1.DataSource = DS.Tables("empleado")
            ComboBox1.DisplayMember = ("nombres")
            'cbocate.ValueMember = "nom_des"
            Label6.Text = DS.Tables("empleado").Rows(0)("cod_emp")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargarData()

        dausuario = New SqlDataAdapter("select*from usuario", cn)
        'cmd = New SqlCommand("listar_productos", cn)
        '  daproducto = New SqlDataAdapter(cmd)
        Dataset = New DataSet()
        dausuario.Fill(dataset, "usuario")
        cn.Close()
        Me.TxtUsu.DataBindings.Add("Text", dataset, "usuario.nom_usu")
        Me.TxtCon.DataBindings.Add("text", dataset, "usuario.password")
        Me.LblCod.DataBindings.Add("Text", dataset, "usuario.cod_usu")
        'Me.MaskedTextBox1.DataBindings.Add("Text", dataset, "usuario.nivel_usu")
        ' Me.ComboBox1.DataBindings.Add("Text", dataset, "usuario.cod_empl")

        Me.DataGridView1.DataSource = Dataset
        Me.DataGridView1.DataMember = "usuario"

        'Data.Columns(0).Visible = False
        DataGridView1.Columns(0).HeaderText = "Codigo"
        'DataGridView1.Columns(1).HeaderText = "Nombres"
        'DataGridView1.Columns(2).HeaderText = "Direccion"
        'DataGridView1.Columns(3).HeaderText = "D.N.I"
        'DataGridView1.Columns(4).HeaderText = "R.U.C"
        'DataGridView1.Columns(5).HeaderText = "Telefono"
        'DataGridView1.Columns(6).HeaderText = "Codigo_Distrito"
        ' DataGridView1.Columns(5).HeaderText = "Codigo"
        DataGridView1.Columns(0).Width = "60"
        'DataGridView1.Columns(1).Width = "60"
        ' DataGridView1.Columns(3).Width = "60"
    End Sub
    Private Sub ManUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarData()
        DesHabilitar()

        '
        'cargar_empleado()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' cargar_empleado()
        validar()
        'cargar_empleado()
        If ComboBox1.Focused = True Then
            Label6.Text = ComboBox1.SelectedItem.Row("cod_emp")
        Else
            Label6.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
        ' validar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '  Label6.Text = 0
        p = 1
        DataGridView1.Enabled = False

        'cargar_empleado()
        Habilitar()
        'ComboBox1.Text = ""
        'Label6.Text = ""
        Call HabilitarBotones(True)
        LimpiaControles()
        Button5.Enabled = True
        GENERACODIGO()
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
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
        ComboBox1.Text = ""
        Label6.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
    Sub validar()
        'Dim nombres As String
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            nombres = DataGridView1.Rows(i).Cells(5).Value
        Next
        If Label6.Text = nombres Then
                MessageBox.Show("Usuario creado para este empleado", "Aviso")
                ComboBox1.SelectedItem = 0
            Else
                ' MessageB
            End If


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sqlguardar As String

        'For i As Integer = 0 To Me.DataGridView1.RowCount - 1
        '    nombres = DataGridView1.Rows(i).Cells(5).Value
        'Next
        ' validar()

        If p = 1 Then
            'validar()
            If TxtUsu.Text = "" Then MsgBox("Ingresa un nombre de usuario", vbOKOnly + vbInformation, "Información al usuario...!") : TxtUsu.Focus() : Exit Sub
            If TxtCon.Text = "" Then MsgBox("Ingresa Contraseña ", vbOKOnly + vbInformation, "Información al usuario...!") : TxtCon.Focus() : Exit Sub
            If ComboBox1.Text = "" Then MsgBox("Seleciona Empleado ", vbOKOnly + vbInformation, "Información al usuario...!") : ComboBox1.Focus() : Exit Sub
            ' If nombres = Label6.Text Then MsgBox("usuario creado para este empleado", vbOKOnly + vbInformation, "Informacion al usuario..!") : ComboBox1.Focus() : Exit Sub
            'guardar nuevo cliente

            sqlguardar = "insert into usuario values('" & LblCod.Text & "', '" & nivel & "','" & TxtUsu.Text & "','" & TxtCon.Text & "','" & s & "','" & Label6.Text & "')"

            Dim cmd As New SqlCommand(sqlguardar, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MsgBox("Usuario Creado" & Chr(13) & "Codigo" & (LblCod.Text), MsgBoxStyle.Information, "SISTEMAS Izquierdo")
            Actualizar()
            DesHabilitar()
            Call HabilitarBotones(True)
            Button1.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            DataGridView1.Enabled = True
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            ' BTBTNELEMINAR.Enabled = True
            cn.Close()

        Else
            'actualiza cliente
            Try
                sqlguardar = "update usuario set nivel_usu='" & nivel & "',nom_usu='" & TxtUsu.Text & "',password='" & TxtUsu.Text & "',activo='" & s & "'where cod_usu='" & LblCod.Text & "'"
                Dim cmd As New SqlCommand(sqlguardar, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Usuario Modificado" & Chr(13) & "Codigo" & (LblCod.Text), MsgBoxStyle.Information, "CPISOFT")
                Actualizar()
                DesHabilitar()
                Call HabilitarBotones(True)
                Button1.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                DataGridView1.Enabled = True
                ' BT
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Controlado")
                'Call HabilitarBotones(True)

            End Try

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            s = 1
        Else
            s = 0
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            nivel = 1
        End If
        'Label8.Text = nivel
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            nivel = 2
        End If
        ' Label8.Text = nivel
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            nivel = 3
        End If
        ' Label8.Text = nivel
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress

    End Sub

    Private Sub ComboBox1_Enter(sender As Object, e As EventArgs) Handles ComboBox1.Enter
        'cargar_empleado()
    End Sub
End Class