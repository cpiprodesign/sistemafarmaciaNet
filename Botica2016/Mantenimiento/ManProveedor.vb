Imports System.Data.SqlClient
Public Class ManProveedor
    Public daproveedor As SqlDataAdapter
    Public dataset As DataSet
    Public strcodigo As Integer
    Public p As Integer
    Public Resultado As Integer
    Private Sub ManProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarData()
        DesHabilitar()
    End Sub
    Sub cargarData()

        daproveedor = New SqlDataAdapter("select*from Proveedor order by cod_proveedor desc ", cn)
        'cmd = New SqlCommand("listar_productos", cn)
        '  daproducto = New SqlDataAdapter(cmd)
        dataset = New DataSet()
        daproveedor.Fill(dataset, "proveedor")
        cn.Close()
        Me.TextBox1.DataBindings.Add("Text", dataset, "proveedor.cod_proveedor")
        Me.TxtNombre.DataBindings.Add("text", dataset, "proveedor.Nombre")
        Me.TextBox2.DataBindings.Add("Text", dataset, "proveedor.direccion")
        Me.MaskedTextBox1.DataBindings.Add("Text", dataset, "proveedor.telefono")
        Me.MaskedTextBox2.DataBindings.Add("Text", dataset, "proveedor.ruc")

        '
        Me.TextBox3.DataBindings.Add("Text", dataset, "proveedor.otros")

        Me.DataGridView1.DataSource = DataSet
        Me.DataGridView1.DataMember = "proveedor"

        'Data.Columns(0).Visible = False
        'DataGridView1.Columns(0).HeaderText = "Codigo"
        'DataGridView1.Columns(1).HeaderText = "Nombres"
        'DataGridView1.Columns(2).HeaderText = "Direccion"
        'DataGridView1.Columns(3).HeaderText = "Telefono"
        'DataGridView1.Columns(4).HeaderText = "RUC"
        'DataGridView1.Columns(5).HeaderText = "Otros"
        ' DataGridView1.Columns(6).HeaderText = "Codigo_Distrito"
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
        daproveedor.Fill(dataset, "proveedor")
    End Sub
    Private Sub LimpiaControles()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        MaskedTextBox2.Text = ""
        TxtNombre.Text = ""
        ' ComboBox1.Text = ""
        MaskedTextBox1.Text = ""
        TxtNombre.Focus()
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(cod_proveedor)from proveedor", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        TextBox1.Text = Format(Val(strCodigo) + 1, "0000000")
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
        Button4.Enabled = False
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
        DataGridView1.Enabled = True
        Actualizar()
        DesHabilitar()
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmconsultaproveedor.ShowDialog()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql3 As String
        sql3 = "delete from proveedor where cod_proveedor=@Cod_cli"
        Dim objComando As New SqlCommand(sql3, cn)
        Try
            objComando.Parameters.Add(New SqlParameter("@Cod_cli", SqlDbType.VarChar))
            objComando.Parameters("@Cod_cli").Value = InputBox("Ingrese el código de Proveeedor a eliminar: ", "SystFarma")
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
        Dim sqlguardar As String
        If p = 1 Then
            If TxtNombre.Text = "" Then MsgBox("Ingresa el Nombre", vbOKOnly + vbInformation, "Información al usuario...!") : TxtNombre.Focus() : Exit Sub
            If TextBox2.Text = "" Then MsgBox("Ingresa Direccion", vbOKOnly + vbInformation, "Información al usuario...!") : TextBox2.Focus() : Exit Sub
            If MaskedTextBox1.Text = "" Then MsgBox("Ingrese un Telefono", vbOKOnly + vbInformation, "Información al usuario...!") : MaskedTextBox1.Focus() : Exit Sub
            If Me.MaskedTextBox2.Text = "" Then MsgBox("Ingresa R.U.C", vbOKOnly + vbInformation, "Información al usuario...!") : MaskedTextBox2.Focus() : Exit Sub

            'guardar nuevo cliente

            sqlguardar = "insert into Proveedor values('" & TextBox1.Text & "', '" & TxtNombre.Text & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & TextBox3.Text & "','" & (MaskedTextBox2.Text) & "')"

            Dim cmd As New SqlCommand(sqlguardar, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MsgBox("Proveedor guardado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "SystFarma")
            Actualizar()
            DesHabilitar()
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
                sqlguardar = "update proveedor set nombre='" & TxtNombre.Text & "',direccion='" & TextBox2.Text & "',telefono='" & MaskedTextBox1.Text & "',otros='" & TextBox3.Text & "',RUC='" & MaskedTextBox2.Text & "'where cod_proveedor='" & TextBox1.Text & "'"
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
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Controlado")
                'Call HabilitarBotones(True)

            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class