Imports System.Data.SqlClient
Public Class FrmProductos_sinstock

    Private Sub FrmProductos_sinstock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim total As String
        Dim cmd As New SqlCommand : Dim daproducto As New SqlDataAdapter : Dim dataset As New DataSet
        cmd = New SqlCommand("productosSTOCK", cn)
        daproducto = New SqlDataAdapter(cmd)
        dataset = New DataSet()
        daproducto.Fill(dataset, "productos")
        cn.Close()
        Data.DataSource = dataset
        Data.DataMember = "productos"
        total = dataset.Tables("productos").Rows.Count
        Me.Text = ("Total de productos  es: " + total)
        '''''''
        For i = 0 To Data.Rows.Count - 2
            If Data.Rows(i).Cells("stock").Value.ToString() = 0 Then
                Data.Rows(i).DefaultCellStyle.BackColor = Color.Red

            ElseIf Data.Rows(i).Cells("stock").Value.ToString() <= 5 Then
                Data.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            Else
                Data.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

        Next
    End Sub
    Sub contardatagridview()
        Dim i As Integer
        Dim res As String, stock As String
        Try
            For i = 0 To Data.RowCount - 2

                If Data.Rows(i).Cells("stock").Value.ToString() = "0" Then
                    res = Data.ColumnCount
                    'TextBox1.Text = (res)
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")


        End Try
        

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
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellContentClick

    End Sub

    Private Sub Data_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Data.CellEnter
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call GridAExcel(Data)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        contardatagridview()
    End Sub
End Class