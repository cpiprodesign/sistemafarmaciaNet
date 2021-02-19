Imports System.Data.SqlClient
Public Class conProductos
    Dim bus As String
    Private Sub CboBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBuscar.SelectedIndexChanged
        If CboBuscar.SelectedIndex = 0 Then
            bus = "Cod_Pro"
            ComboBox1.Visible = False
        ElseIf CboBuscar.SelectedIndex = 1 Then
            bus = "Descripcion"
            ComboBox1.Visible = False
        ElseIf CboBuscar.SelectedIndex = 2 Then
            bus = "Categoria"
            ComboBox1.Visible = True
            cargar_categoria()
        End If
       
        TxtValor.Focus()
    End Sub
    Sub buscar_nombre()
        Try
            Dim cmd As New SqlCommand("buscar_productoxnombre", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 11).Value = TxtValor.Text
            Dim data As New SqlDataAdapter(cmd)
            Dim dtab As New DataTable
            data.Fill(dtab)
            Me.DgvProductos.DataSource = dtab

        Catch exc As Exception
            MessageBox.Show(exc.Message, "Error controlado")

        End Try
    End Sub
    Sub busca_x_codigo()
        Try
            Dim cmd As New SqlCommand("buscar_productoxcodigo", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@cod_pro", SqlDbType.VarChar, 11).Value = TxtValor.Text
            Dim data As New SqlDataAdapter(cmd)
            Dim dtab As New DataTable
            data.Fill(dtab)
            Me.DgvProductos.DataSource = dtab

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error controlado")

        End Try
    End Sub
    Sub buscar_x_categoria()
        Try
            Dim cmd1 As New SqlCommand("buscar_productoxcategoria", cn)
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.Add("@cod_cate", SqlDbType.VarChar, 11).Value = Label5.Text
            Dim data1 As New SqlDataAdapter(cmd1)
            Dim dtab1 As New DataTable
            data1.Fill(dtab1)
            Me.DgvProductos.DataSource = dtab1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error controlado")

        End Try
    End Sub
    Sub cargadata()
        Dim cmd As New SqlCommand : Dim daproducto As New SqlDataAdapter : Dim dataset As New DataSet
        cmd = New SqlCommand("listar_productos", cn)
        daproducto = New SqlDataAdapter(cmd)
        dataset = New DataSet()
        daproducto.Fill(dataset, "productoS")
        cn.Close()
        DgvProductos.DataSource = dataset.Tables("productos")

    End Sub

    Private Sub conProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Visible = False
        CboBuscar.Items.Add("Código")
        CboBuscar.Items.Add("Descripción")
        CboBuscar.Items.Add("Categoria")
        cargadata()
          'carga categoria
        ' cargar_categoria()

    End Sub
    Sub cargar_categoria()
        Try
            Dim DA As New SqlDataAdapter("Select * From categoria", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "categoria")
            ComboBox1.DataSource = DS.Tables("categoria")
            ComboBox1.DisplayMember = ("descripcion")
            'cbocate.ValueMember = "nom_des"
            Label5.Text = DS.Tables("categoria").Rows(0)("cod_cate")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress
        If CboBuscar.SelectedIndex = 0 Then
            busca_x_codigo()

        ElseIf CboBuscar.SelectedIndex = 1 Then
            buscar_nombre()

        ElseIf CboBuscar.SelectedIndex = 2 Then
            cargar_categoria()
        Else
            cargadata()
        End If
        If TxtValor.TextLength = 0 Then
            cargadata()
        End If

       
    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'cargar_categoria()
        'Label5.Text = ""
          If ComboBox1.Focused = True Then
            Label5.Text = ComboBox1.SelectedItem.Row("cod_cate")
        Else
            'Label5.Text = ""
            'txtcodigo.Text = CBOCLIENTE.SelectedItem.row("cod_emp")

        End If
        buscar_x_categoria()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call GridAExcel(DgvProductos)
    End Sub
    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
        Return True
    End Function

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class