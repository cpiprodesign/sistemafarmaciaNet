<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarProductos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pproducto = New System.Windows.Forms.Panel()
        Me.Data = New System.Windows.Forms.DataGridView()
        Me.txtbuscarproductoxnombre = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pproducto.SuspendLayout()
        CType(Me.Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pproducto
        '
        Me.pproducto.BackColor = System.Drawing.SystemColors.Control
        Me.pproducto.Controls.Add(Me.Data)
        Me.pproducto.Controls.Add(Me.txtbuscarproductoxnombre)
        Me.pproducto.Controls.Add(Me.Label17)
        Me.pproducto.Location = New System.Drawing.Point(12, 12)
        Me.pproducto.Name = "pproducto"
        Me.pproducto.Size = New System.Drawing.Size(553, 247)
        Me.pproducto.TabIndex = 113
        Me.pproducto.Visible = False
        '
        'Data
        '
        Me.Data.AllowUserToAddRows = False
        Me.Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Data.Location = New System.Drawing.Point(22, 30)
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Data.Size = New System.Drawing.Size(504, 207)
        Me.Data.TabIndex = 115
        '
        'txtbuscarproductoxnombre
        '
        Me.txtbuscarproductoxnombre.Location = New System.Drawing.Point(94, 6)
        Me.txtbuscarproductoxnombre.Name = "txtbuscarproductoxnombre"
        Me.txtbuscarproductoxnombre.Size = New System.Drawing.Size(229, 20)
        Me.txtbuscarproductoxnombre.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Nombre Producto"
        '
        'frmAgregarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 294)
        Me.Controls.Add(Me.pproducto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAgregarProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAgregarProductos"
        Me.pproducto.ResumeLayout(False)
        Me.pproducto.PerformLayout()
        CType(Me.Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pproducto As Panel
    Friend WithEvents Data As DataGridView
    Friend WithEvents txtbuscarproductoxnombre As TextBox
    Friend WithEvents Label17 As Label
End Class
