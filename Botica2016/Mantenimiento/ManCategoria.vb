Imports System.Data.SqlClient
Public Class ManCategoria
    Dim daproducto As SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim Dataset As DataSet

    Dim resultado As Integer
    Dim strCodigo As String
    Dim p As Integer
    Private Sub ManCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarData()
        DesHabilitar()
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
    Sub cargarData()

        daproducto = New SqlDataAdapter("select*from categoria order by cod_cate desc", cn)
        'cmd = New SqlCommand("listar_productos", cn)
        '  daproducto = New SqlDataAdapter(cmd)
        Dataset = New DataSet()
        daproducto.Fill(Dataset, "categoria")
        cn.Close()
        Me.TextBox1.DataBindings.Add("Text", Dataset, "categoria.cod_cate")
        Me.TextBox2.DataBindings.Add("text", Dataset, "categoria.descripcion")
       
        'Me.Label8.DataBindings.Add("text", Dataset, "PRODUCTOS.descripcion")
        'Me.Label12.DataBindings.Add("text", Dataset, "productos.cod_prov")
        'Me.Label10.DataBindings.Add("text", Dataset, "productos.cod_unidad")
        '' Me.TextBox6.DataBindings.Add("text", Dataset, "producto.nomusu")
        'Me.cboestado.DataBindings.Add("Text", Dataset, "Asunto.estado")
        ''Me.txtencargado.DataBindings.Add("Text", Dataset, "Asunto.encargado")
        Me.DataGridView1.DataSource = Dataset
        Me.DataGridView1.DataMember = "categoria"

        'Data.Columns(0).Visible = False
        DataGridView1.Columns(0).Width = "60"
        'DataGridView1.Columns(1).Width = "60"
        ' DataGridView1.Columns(3).Width = "60"
    End Sub
    Private Sub Actualizar()
        'Para actualizar el DataSet
        Dataset.Clear()
        daproducto.Fill(Dataset, "categoria")
    End Sub
    Private Sub LimpiaControles()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox2.Focus()
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(cod_cate)from categoria", cn)
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
        Button3.Enabled = False
        p = 2
        HabilitarBotones(True)
        Habilitar()
        Button2.Enabled = True
        Button5.Enabled = True
        Button1.Enabled = False
        DataGridView1.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql3 As String
        sql3 = "delete from Categoria where cod_cate=@Cod_cate"
        Dim objComando As New SqlCommand(sql3, cn)
        Try
            objComando.Parameters.Add(New SqlParameter("@Cod_cate", SqlDbType.VarChar))
            objComando.Parameters("@Cod_cate").Value = InputBox("Ingrese el código de Categoria a eliminar: ")
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
            If TextBox2.Text = "" Then
                MsgBox("Ingresa la descripcion.", MsgBoxStyle.Exclamation, "Sistema")
            Else
                sqlguardar = "insert into categoria values('" & TextBox1.Text & "', '" & TextBox2.Text & "')"

                Dim cmd As New SqlCommand(SQLGuardar, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                MsgBox("Categoria guardado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "SISTEMAS Izquierdo")
                Actualizar()
                DesHabilitar()
                Call HabilitarBotones(True)
                Button1.Enabled = True
                Button3.Enabled = True
                DataGridView1.Enabled = True
                ' BTNELEMINAR.Enabled = True
                cn.Close()
            End If
        Else
            Try
                sqlguardar = "update categoria set descripcion='" & TextBox2.Text & "'where cod_cate='" & TextBox1.Text & "'"
                Dim cmd As New SqlCommand(sqlguardar, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Categoria Modificado" & Chr(13) & "Codigo" & (TextBox1.Text), MsgBoxStyle.Information, "SystFarma")
                Actualizar()
                DesHabilitar()
                Call HabilitarBotones(True)
                Button1.Enabled = True
                Button3.Enabled = True
                DataGridView1.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Controlado")
                'Call HabilitarBotones(True)

            End Try

        End If
    End Sub
End Class