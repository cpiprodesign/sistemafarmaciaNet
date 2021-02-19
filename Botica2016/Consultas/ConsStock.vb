Imports System.Data.SqlClient
Public Class ConsStock
    Dim daproducto As SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim Dataset As DataSet
    Dim DataAdapter As SqlDataAdapter
    'Dim DataSet As New DataSet
    Dim cad As String
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

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
    

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim total As String

        'daproducto = New SqlDataAdapter("Productos.cod_pro,Productos.Descripcion,Productos.pre_compra,Productos.pre_venta,Productos.fecha_vencimiento,categoria.descripcion as Categoria inner join Categoria on Categoria.cod_cate=Productos.cod_cate", cn)
        cmd = New SqlCommand("listar_productos", cn)
        daproducto = New SqlDataAdapter(cmd)
        Dataset = New DataSet()
        daproducto.Fill(Dataset, "productoS")
        cn.Close()
        'Me.Label8.DataBindings.Add("text", Dataset, "PRODUCTOS.descripcion")
        'Me.Label12.DataBindings.Add("text", Dataset, "productos.cod_prov")
        'Me.Label10.DataBindings.Add("text", Dataset, "productos.cod_unidad")
        '' Me.TextBox6.DataBindings.Add("text", Dataset, "producto.nomusu")
        'Me.cboestado.DataBindings.Add("Text", Dataset, "Asunto.estado")
        ''Me.txtencargado.DataBindings.Add("Text", Dataset, "Asunto.encargado")
        Me.datos.DataSource = Dataset
        Me.datos.DataMember = "productoS"

        'Data.Columns(0).Visible = False
        datos.Columns(0).Width = "60"
        datos.Columns(2).Width = "60"
        datos.Columns(3).Width = "60"
        total = Me.Dataset.Tables("productos").Rows.Count
        TextBox1.Text = total
        Dim sinstock As String
        For i = 0 To datos.Rows.Count - 1
            If datos.Rows(i).Cells("stock").Value.ToString() = "0" Then
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Red

            ElseIf datos.Rows(i).Cells("stock").Value.ToString() <= 5 Then
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            Else
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
           
        Next



    End Sub

    Private Sub ConsStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As String

        'daproducto = New SqlDataAdapter("Productos.cod_pro,Productos.Descripcion,Productos.pre_compra,Productos.pre_venta,Productos.fecha_vencimiento,categoria.descripcion as Categoria inner join Categoria on Categoria.cod_cate=Productos.cod_cate", cn)
        cmd = New SqlCommand("productosSTOCK", cn)
        daproducto = New SqlDataAdapter(cmd)
        Dataset = New DataSet()
        daproducto.Fill(Dataset, "productoS")
        cn.Close()
        'Me.Label8.DataBindings.Add("text", Dataset, "PRODUCTOS.descripcion")
        'Me.Label12.DataBindings.Add("text", Dataset, "productos.cod_prov")
        'Me.Label10.DataBindings.Add("text", Dataset, "productos.cod_unidad")
        '' Me.TextBox6.DataBindings.Add("text", Dataset, "producto.nomusu")
        'Me.cboestado.DataBindings.Add("Text", Dataset, "Asunto.estado")
        ''Me.txtencargado.DataBindings.Add("Text", Dataset, "Asunto.encargado")
        Me.datos.DataSource = Dataset
        Me.datos.DataMember = "productoS"
        For i = 0 To datos.Rows.Count - 1
            If datos.Rows(i).Cells("stock").Value.ToString() = "0" Then
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Red
            ElseIf datos.Rows(i).Cells("stock").Value.ToString() <= 5 Then
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            Else
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Green


            End If

        Next
        'Data.Columns(0).Visible = False
        datos.Columns(0).Width = "60"
        datos.Columns(2).Width = "60"
        datos.Columns(3).Width = "60"
        total = Me.Dataset.Tables("productos").Rows.Count
        TextBox1.Text = total
        Dim stock As String
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim total As String

        'daproducto = New SqlDataAdapter("Productos.cod_pro,Productos.Descripcion,Productos.pre_compra,Productos.pre_venta,Productos.fecha_vencimiento,categoria.descripcion as Categoria inner join Categoria on Categoria.cod_cate=Productos.cod_cate", cn)
        cmd = New SqlCommand("productosSTOCK", cn)
        daproducto = New SqlDataAdapter(cmd)
        Dataset = New DataSet()
        daproducto.Fill(Dataset, "productoS")
        cn.Close()
        'Me.Label8.DataBindings.Add("text", Dataset, "PRODUCTOS.descripcion")
        'Me.Label12.DataBindings.Add("text", Dataset, "productos.cod_prov")
        'Me.Label10.DataBindings.Add("text", Dataset, "productos.cod_unidad")
        '' Me.TextBox6.DataBindings.Add("text", Dataset, "producto.nomusu")
        'Me.cboestado.DataBindings.Add("Text", Dataset, "Asunto.estado")
        ''Me.txtencargado.DataBindings.Add("Text", Dataset, "Asunto.encargado")
        Me.datos.DataSource = Dataset
        Me.datos.DataMember = "productoS"

        'Data.Columns(0).Visible = False
        datos.Columns(0).Width = "60"
        datos.Columns(2).Width = "60"
        datos.Columns(3).Width = "60"
        total = Me.Dataset.Tables("productos").Rows.Count
        TextBox1.Text = total
        For i = 0 To datos.Rows.Count - 1
            If datos.Rows(i).Cells("stock").Value.ToString() = "0" Then
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Red
            ElseIf datos.Rows(i).Cells("stock").Value.ToString() <= 5 Then
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            Else
                datos.Rows(i).DefaultCellStyle.BackColor = Color.Green


            End If
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call GridAExcel(datos)
    End Sub
End Class