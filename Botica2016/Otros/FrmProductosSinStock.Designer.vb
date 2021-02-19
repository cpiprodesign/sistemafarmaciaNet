<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductosSinStock
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ProductosSinStockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.listadoProducStock0 = New Botica2016.listadoProducStock0()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.BoticaJavierDataSet = New Botica2016.BoticaJavierDataSet()
        Me.ClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClienteTableAdapter = New Botica2016.BoticaJavierDataSetTableAdapters.ClienteTableAdapter()
        Me.ProductosSinStockTableAdapter = New Botica2016.listadoProducStock0TableAdapters.ProductosSinStockTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.ProductosSinStockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listadoProducStock0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BoticaJavierDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProductosSinStockBindingSource
        '
        Me.ProductosSinStockBindingSource.DataMember = "ProductosSinStock"
        Me.ProductosSinStockBindingSource.DataSource = Me.listadoProducStock0
        '
        'listadoProducStock0
        '
        Me.listadoProducStock0.DataSetName = "listadoProducStock0"
        Me.listadoProducStock0.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(56, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado de Productos sin Stock"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.ProductosSinStockBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Botica2016.Report7.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 47)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(791, 467)
        Me.ReportViewer1.TabIndex = 1
        '
        'BoticaJavierDataSet
        '
        Me.BoticaJavierDataSet.DataSetName = "BoticaJavierDataSet"
        Me.BoticaJavierDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClienteBindingSource
        '
        Me.ClienteBindingSource.DataMember = "Cliente"
        Me.ClienteBindingSource.DataSource = Me.BoticaJavierDataSet
        '
        'ClienteTableAdapter
        '
        Me.ClienteTableAdapter.ClearBeforeFill = True
        '
        'ProductosSinStockTableAdapter
        '
        Me.ProductosSinStockTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(487, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(406, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 31)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmProductosSinStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(815, 526)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmProductosSinStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Productos Sin Stock"
        CType(Me.ProductosSinStockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listadoProducStock0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BoticaJavierDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ClienteBindingSource As BindingSource
    Friend WithEvents BoticaJavierDataSet As BoticaJavierDataSet
    Friend WithEvents ClienteTableAdapter As BoticaJavierDataSetTableAdapters.ClienteTableAdapter
    Friend WithEvents ProductosSinStockBindingSource As BindingSource
    Friend WithEvents listadoProducStock0 As listadoProducStock0
    Friend WithEvents ProductosSinStockTableAdapter As listadoProducStock0TableAdapters.ProductosSinStockTableAdapter
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
