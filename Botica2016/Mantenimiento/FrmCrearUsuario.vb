Imports System.Data.SqlClient
Public Class FrmCrearUsuario
    Public strcodigo As String
    Public nivel, s As String
    Public nombres As String
    Dim ds As DataSet
    Dim da As SqlDataAdapter

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        generar_codigo()
        Button2.Enabled = True
        'cargar_empleado()
    End Sub
    Sub generar_codigo()
        Dim cmd As New SqlCommand("select max(cod_usu)from usuario", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        LblCod.Text = Format(Val(strCodigo) + 1, "00000")
    End Sub
    Sub cargadata()
        da = New SqlDataAdapter("select cod_usu,nom_usu,cod_empl from usuario order by cod_usu desc", cn)
        ' Dim ds As New DataSet
        ds = New DataSet
        da.Fill(ds, "usuario")
        Me.DataGridView1.DataSource = ds.Tables("usuario")

    End Sub
    Private Sub LimpiaControles()

        TxtUsu.Text = ""
        TxtCon.Text = ""
        TxtUsu.Focus()
        'MaskedTextBox1.Text = ""
        Label6.Text = ""
        ComboBox1.Text = ""

    End Sub
    Private Sub Actualizar()
        'Para actualizar el DataSet
        ds.Clear()
        da.Fill(ds, "usuario")
    End Sub
    Private Sub FrmCrearUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargadata()
        generar_codigo()
        cargar_empleado()
        ComboBox1.SelectedIndex = -1
    End Sub
    Sub cargar_empleado()
        Try
            Dim DA As New SqlDataAdapter("Select * From empleado order by cod_emp desc", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "empleado")
            ComboBox1.DataSource = DS.Tables("empleado")
            ComboBox1.DisplayMember = ("nombres")
            ' ComboBox1.SelectedIndex = 0
            'cbocate.ValueMember = "nom_des"
            'If ComboBox1.SelectedIndex = -1 Then
            '    '    Label6.Text = ""
            '    'Else
            '    '    'Label6.Text = DS.Tables("empleado").Rows(0)("cod_emp")

            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'validar
        'cargar_empleado()

        If ComboBox1.Focused = True Then
            Label6.Text = ComboBox1.SelectedItem.Row("cod_emp")
        Else
            Label6.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If

    End Sub
    Sub validar()
        Try
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                nombres = DataGridView1.Rows(i).Cells(2).Value
            Next
            If Label6.Text = nombres Then
                MessageBox.Show("Usuario creado para este empleado", "Aviso")
                'ComboBox1.SelectedItem = 0
                'Else
                ' MessageBox.Show("usario aun no tiene..cuenta", "Aviso")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            validar()
            If TxtUsu.Text = "" Then MsgBox("Ingresa un nombre de usuario", vbOKOnly + vbInformation, "Información al usuario...!") : TxtUsu.Focus() : Exit Sub
            If TxtCon.Text = "" Then MsgBox("Ingresa Contraseña ", vbOKOnly + vbInformation, "Información al usuario...!") : TxtCon.Focus() : Exit Sub
            If ComboBox1.Text = "" Then MsgBox("Seleciona Empleado ", vbOKOnly + vbInformation, "Información al usuario...!") : ComboBox1.Focus() : Exit Sub
            If nivel = 0 Then MsgBox("Seleciona nivel de usuario ", vbOKOnly + vbInformation, "Información al usuario...!") : Exit Sub
            'validar()
            Dim sqlguardar As String
            sqlguardar = "insert into usuario values('" & LblCod.Text & "', '" & nivel & "','" & TxtUsu.Text & "','" & TxtCon.Text & "','" & s & "','" & Label6.Text & "')"
            'cn.Open()
            Dim cmd As New SqlCommand(sqlguardar, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            Actualizar()
            cn.Close()

            MsgBox("Usuario Creado" & Chr(13) & "Codigo" & (LblCod.Text), MsgBoxStyle.Information, "SISTEMAS Izquierdo")
            LimpiaControles()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            nivel = 1
        Else
            nivel = 0
        End If
        'Label8.Text = nivel
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            nivel = 2
        Else
            nivel = 0
        End If
        ' Label8.Text = nivel
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            nivel = 3
        Else
            nivel = 0
        End If
        ' Label8.Text = nivel
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            s = 1
        Else
            s = 0
        End If
    End Sub

    Private Sub ComboBox1_Enter(sender As Object, e As EventArgs) Handles ComboBox1.Enter
        cargar_empleado()
    End Sub
End Class