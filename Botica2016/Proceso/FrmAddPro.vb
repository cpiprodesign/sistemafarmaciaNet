Imports System.Data.SqlClient
Public Class FrmAddPro
    Dim Codig As String
    Dim stock As Single
    Dim fila As Byte
    Private Sub txtbuscarproductoxnombre_TextChanged(sender As Object, e As EventArgs) Handles txtbuscarproductoxnombre.TextChanged

        Try
                Dim cmd2 As New SqlCommand("buscar_productoxnombre", cn)
                cmd2.CommandType = CommandType.StoredProcedure
                cmd2.Parameters.Add("@descripcion", SqlDbType.VarChar, 11).Value = Me.txtbuscarproductoxnombre.Text
                Dim data As New SqlDataAdapter(cmd2)
                Dim dtab2 As New DataTable
                data.Fill(dtab2)
                Me.Data.DataSource = dtab2

            Catch ex As Exception
                MsgBox("Error al buscar producto")
            End Try


        'MsgBox("Producto no encontrado", MsgBoxStyle.Information)



    End Sub

    Private Sub FrmAddPro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.KeyPreview = True
        carga_producto()
        pproducto.Visible = True
        'fila = Data.CurrentCell.RowIndex
        'codigo_produco = Data.Item(0, fila).Value
        'Label1.Text = codigo_produco
        txtbuscarproductoxnombre.Focus()
    End Sub
    Sub carga_producto()
        Try
            Dim cmd As SqlCommand : Dim daproducto As New SqlDataAdapter : Dim dataset As New DataSet
            cmd = New SqlCommand("[listar_productos_a vender]", cn)
            daproducto = New SqlDataAdapter(cmd)
            dataset = New DataSet()
            daproducto.Fill(dataset, "producto")
            cn.Close()
            Me.Data.DataSource = dataset.Tables("producto")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")


        End Try
    End Sub

    Private Sub Data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellContentClick

        '   
    End Sub

    Private Sub Data_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellContentDoubleClick

    End Sub

    Private Sub Data_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Data.KeyPress
        fila = Data.CurrentCell.RowIndex
        codigo_produco = Data.Item(0, fila).Value
        descripcion = Data.Item(1, fila).Value
        precio = Data.Item(3, fila).Value
        crisstock = Data.Item(6, fila).Value

        Label1.Text = codigo_produco
        Label2.Text = descripcion
        Label3.Text = precio
        Label4.Text = crisstock

        'FrmImput.ShowDialog()

        ''   btnbuscarproducto_Click(btnbuscarproducto, Nothing)
        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e

        'If tmp.KeyChar = ChrW(Keys.Space) Then
        '    Try
        '        Dim i As Integer

        '        ' Dim inpu As Single

        '        For i = 0 To Data.RowCount - 1
        '            ' stock = Data.Rows(i).Cells(6).Value
        '            ' Codig = Data.Rows(i).Cells(0).Value
        '            ' Label1.Text = stock

        '        Next

        '        If Label4.Text < cantidad Then
        '            MessageBox.Show("La cantidad supera el stock ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        '            ' FrmImput.ShowDialog()
        '            'cantidad = 1
        '            'ElseIf codigo_produco = Codig Then
        '            '    MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")
        '        ElseIf codigo_produco = Codig

        '            MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")

        '        Else
        '            'For i = 0 To Data.RowCount - 1
        '            '    codigo_produco = Data.Rows(i).Cells(0).Value
        '            '    descripcion = Data.Rows(i).Cells(1).Value
        '            '    precio = Data.Rows(i).Cells(3).Value
        '            '    crisstock = Data.Rows(i).Cells(6).Value
        '            '    cantidad = inpu
        '            '    Me.Close()
        '            'Next
        '            '  fila = Data.CurrentCell.RowIndex
        '            codigo_produco = Label1.Text
        '            descripcion = Label2.Text
        '            precio = Label3.Text
        '            crisstock = Label4.Text


        '            ' cantidad = inpu
        '            Me.Close()

        '            'fila = datos.CurrentCell.RowIndex
        '            'nombrepro = datos.Item(1, fila).Value
        '            'precio = datos.Item(3, fila).Value
        '            'codpro = datos.Item(0, fila).Value
        '            'DataGridView1.Rows(i).Cells(2).Value
        '        End If

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'Else
        '    ' MessageBox.Show(tmp.KeyChar)
        '    MsgBox("Selecciona el Producto y dale Space ", MsgBoxStyle.Information)
        'End If

        'Try

        '    ' Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        '    If tmp.KeyChar = ChrW(Keys.F1) Then
        '        ' MessageBox.Show("Enter key")
        '        Me.Close()
        '    Else
        '        ' MessageBox.Show(tmp.KeyChar)

        '    End If
        '    'para guardar producto'
        '    'If tmp.KeyChar = ChrW(Keys.F5) Then
        '    '    ' MessageBox.Show("Enter key")
        '    '    btnguardar_Click(btnguardar, Nothing)
        '    'Else
        '    '    ' MessageBox.Show(tmp.KeyChar)

        '    'End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub Data_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellEnter
        'FrmImput.ShowDialog()
        fila = Data.CurrentCell.RowIndex
        codigo_produco = Data.Item(0, fila).Value
        descripcion = Data.Item(1, fila).Value
        precio = Data.Item(3, fila).Value
        crisstock = Data.Item(6, fila).Value

        Label1.Text = codigo_produco
        Label2.Text = descripcion
        Label3.Text = precio
        Label4.Text = crisstock
    End Sub

    Private Sub Data_AllowUserToAddRowsChanged(sender As Object, e As EventArgs) Handles Data.AllowUserToAddRowsChanged

    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Data_DragLeave(sender As Object, e As EventArgs) Handles Data.DragLeave
        '   btnbuscarproducto_Click(btnbuscarproducto, Nothing)

    End Sub

    Private Sub Data_Enter(sender As Object, e As EventArgs) Handles Data.Enter
        'btnbuscarproducto_Click(btnbuscarproducto, Nothing)

    End Sub

    Private Sub Data_KeyDown(sender As Object, e As KeyEventArgs) Handles Data.KeyDown

        If e.KeyData = Keys.Space Then
            FrmImput.ShowDialog()
            Try
                Dim i As Integer

                ' Dim inpu As Single

                For i = 0 To Data.RowCount - 1
                    ' stock = Data.Rows(i).Cells(6).Value
                    ' Codig = Data.Rows(i).Cells(0).Value
                    ' Label1.Text = stock

                Next

                If Label4.Text < cantidad Then
                    MessageBox.Show("La cantidad supera el stock ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    ' FrmImput.ShowDialog()
                    'cantidad = 1
                    'ElseIf codigo_produco = Codig Then
                    '    MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")
                ElseIf codigo_produco = Codig

                    MsgBox("El producto ya ha sido seleccionado", MsgBoxStyle.Critical, "Verificar")

                Else

                    codigo_produco = Label1.Text
                    descripcion = Label2.Text
                    precio = Label3.Text
                    crisstock = Label4.Text
                    Me.Close()

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            'MsgBox("Selecciona el Producto y dale Space ", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Data_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellMouseEnter
        '  btnbuscarproducto_Click(btnbuscarproducto, Nothing)

    End Sub

    Private Sub Data_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Data.CellMouseDoubleClick
        '  btnbuscarproducto_Click(btnbuscarproducto, Nothing)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtbuscarproductoxnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscarproductoxnombre.KeyPress
        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If tmp.KeyChar = ChrW(Keys.Enter) Then
        '    Try
        '        Dim cmd2 As New SqlCommand("buscar_productoxnombre", cn)
        '        cmd2.CommandType = CommandType.StoredProcedure
        '        cmd2.Parameters.Add("@descripcion", SqlDbType.VarChar, 11).Value = Me.txtbuscarproductoxnombre.Text
        '        Dim data As New SqlDataAdapter(cmd2)
        '        Dim dtab2 As New DataTable
        '        data.Fill(dtab2)
        '        Me.Data.DataSource = dtab2

        '    Catch ex As Exception
        '        MsgBox("Error al buscar producto")
        '    End Try
        'Else

        '    MsgBox("Producto no encontrado", MsgBoxStyle.Information)

        'End If
    End Sub
End Class