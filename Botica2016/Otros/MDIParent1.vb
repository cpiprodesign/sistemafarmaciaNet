Imports System.Windows.Forms
Imports System.Diagnostics.Process
Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Cree una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        If MsgBox("Estás seguro que desea salir", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del programa") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "  Bienvenido: " & Nombre
        ToolStripStatusLabel2.Text = "  Fecha: " & Format(DateValue(Now), "dddd - dd 'de' MMMM 'del' yyyy")
        ToolStripStatusLabel3.Text = "  Hora: " & TimeValue(Now)
        ToolStripStatusLabel6.Text = cargo
        ToolStripStatusLabel7.Text = Space(10)
        nivelingreso()

    End Sub
    Sub nivelingreso()
        If Nivel = 2 Then
            MantenimientoToolStripMenuItem.Enabled = False
        ElseIf Nivel = 3 Then
            MantenimientoToolStripMenuItem.Enabled = False


        End If
    End Sub

    Private Sub BlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockToolStripMenuItem.Click
        Try
            Start("Notepad")
        Catch ex As Exception
            MsgBox("El programa no esta instalado")
        End Try
    End Sub

    Private Sub CliengteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CliengteToolStripMenuItem.Click
        Dim frm As New ManClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = "  Bienvenido: " & Nombre
        ToolStripStatusLabel2.Text = "  Fecha: " & Format(DateValue(Now), "dddd - dd 'de' MMMM 'del' yyyy")
        ToolStripStatusLabel3.Text = "  Hora: " & TimeValue(Now)
        ToolStripStatusLabel6.Text = cargo
        ToolStripStatusLabel7.Text = Space(10)
        '  nivel()
    End Sub

    Private Sub ProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoToolStripMenuItem.Click
        Dim frm As New ManProductos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriaToolStripMenuItem.Click
        Dim frm As New ManCategoria
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub EmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadoToolStripMenuItem.Click
        Dim frm As New ManEmpleado
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub UnidadDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadDeMedidaToolStripMenuItem.Click
        Dim frm As New FrmPresentacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BoletaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BoletaToolStripMenuItem.Click
        Dim frm As New FrmBoletaAbenNoe
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim frm As New conProductos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim frm As New ConClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FacturaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FacturaToolStripMenuItem1.Click
        Dim frm As New ConVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ProductoConPocoSotckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoConPocoSotckToolStripMenuItem.Click
        Dim frm As New ConsStock
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ProductoXVencimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoXVencimientoToolStripMenuItem.Click
        Dim frm As New ConVencimiento
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ListadoClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoClientesToolStripMenuItem.Click
        Dim frm As New FrmClientestodos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ClienteXDistritoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteXDistritoToolStripMenuItem.Click
        Dim frm As New FrmClienteXdistrito
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub VentasPorFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasPorFechaToolStripMenuItem.Click
        Dim frm As New FrmReporteBoletaXFecha
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ListadoDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeProductosToolStripMenuItem.Click
        Dim frm As New FrmProductosTodos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ListadoDeProductosPorCategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeProductosPorCategoriaToolStripMenuItem.Click
        Dim frm As New FrmProductXCategoria
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AccesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccesoToolStripMenuItem.Click

    End Sub

    Private Sub MsWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MsWordToolStripMenuItem.Click
        Try
            Start("winword")
        Catch ex As Exception
            MsgBox("El programa no esta instalado")
        End Try
    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        Try
            Start("calc")
        Catch ex As Exception
            MsgBox("El programa no esta instalado")
        End Try
    End Sub

    Private Sub MsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MsToolStripMenuItem.Click
        Try
            Start("excel")
        Catch ex As Exception
            MsgBox("El programa no esta instalado")
        End Try
    End Sub

    Private Sub WindoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindoToolStripMenuItem.Click
        Try
            Start("wmplayer")
        Catch ex As Exception
            MsgBox("El programa no esta instalado")
        End Try
    End Sub

    Private Sub AcercaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaToolStripMenuItem.Click
        Dim frm As New AboutBox1
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MDIParent1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Me.ExitToolsStripMenuItem_Click(sender, e)
        'If MsgBox("Estás seguro que desea salir", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del programa") = MsgBoxResult.Yes Then
        '    Me.Close()
        'End If

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub MDIParent1_CausesValidationChanged(sender As Object, e As EventArgs) Handles Me.CausesValidationChanged

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim frm As New FrmCrearUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ListaDeVentaPorEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeVentaPorEmpleadoToolStripMenuItem.Click
        Dim frm As New ConVentaPorvendedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ToolBar1_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case ToolBar1.Buttons.IndexOf(e.Button)
            Case 0
                Me.ProductoToolStripMenuItem_Click(sender, e)
            Case 1
                Me.BoletaToolStripMenuItem_Click(sender, e)
            Case 2
                Me.CliengteToolStripMenuItem_Click(sender, e)
            Case 3
                Me.ProveeToolStripMenuItem_Click(sender, e)
            Case 4
                ' Me.MnuManContraseña_Click(sender, e)
            Case 5
                Me.CalculadoraToolStripMenuItem_Click(sender, e)
            Case 6
                Me.BlockToolStripMenuItem_Click(sender, e)
            Case 7
                Me.ExitToolsStripMenuItem_Click(sender, e)
        End Select
    End Sub

    Private Sub ProveeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveeToolStripMenuItem.Click
        Dim frm As New ManProveedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ToolStripStatusLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel7.Click

    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Dim frm As New FrmBackup
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Dim frm As New FrmRestore
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConsultaDeProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeProveedorToolStripMenuItem.Click
        Dim frm As New frmconsultaproveedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem.Click
        Dim frm As New Frmconsulta_empleados
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ListadoEmpeladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoEmpeladosToolStripMenuItem.Click
        Dim frm As New FrmReporte_Empleados
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub button5_Click(sender As Object, e As EventArgs) Handles button5.Click
        If MsgBox("Estás seguro que desea salir", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir del programa") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Dim frm As New FrmBoletaAbenNoe
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
