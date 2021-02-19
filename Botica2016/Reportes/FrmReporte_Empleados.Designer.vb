<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte_Empleados
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
        Me.EmpleadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BoticaJavierDataSet = New Botica2016.BoticaJavierDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.EmpleadoTableAdapter = New Botica2016.BoticaJavierDataSetTableAdapters.EmpleadoTableAdapter()
        Me.boletaxFecha = New Botica2016.boletaxFecha()
        Me.BoletaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BoletaTableAdapter = New Botica2016.boletaxFechaTableAdapters.BoletaTableAdapter()
        CType(Me.EmpleadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BoticaJavierDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boletaxFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BoletaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpleadoBindingSource
        '
        Me.EmpleadoBindingSource.DataMember = "Empleado"
        Me.EmpleadoBindingSource.DataSource = Me.BoticaJavierDataSet
        '
        'BoticaJavierDataSet
        '
        Me.BoticaJavierDataSet.DataSetName = "BoticaJavierDataSet"
        Me.BoticaJavierDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.EmpleadoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Botica2016.Report6.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(749, 261)
        Me.ReportViewer1.TabIndex = 0
        '
        'EmpleadoTableAdapter
        '
        Me.EmpleadoTableAdapter.ClearBeforeFill = True
        '
        'boletaxFecha
        '
        Me.boletaxFecha.DataSetName = "boletaxFecha"
        Me.boletaxFecha.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BoletaBindingSource
        '
        Me.BoletaBindingSource.DataMember = "Boleta"
        Me.BoletaBindingSource.DataSource = Me.boletaxFecha
        '
        'BoletaTableAdapter
        '
        Me.BoletaTableAdapter.ClearBeforeFill = True
        '
        'FrmReporte_Empleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 261)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmReporte_Empleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Empleados"
        CType(Me.EmpleadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BoticaJavierDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boletaxFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BoletaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmpleadoBindingSource As BindingSource
    Friend WithEvents BoticaJavierDataSet As BoticaJavierDataSet
    Friend WithEvents EmpleadoTableAdapter As BoticaJavierDataSetTableAdapters.EmpleadoTableAdapter
    Friend WithEvents BoletaBindingSource As BindingSource
    Friend WithEvents boletaxFecha As boletaxFecha
    Friend WithEvents BoletaTableAdapter As boletaxFechaTableAdapters.BoletaTableAdapter
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
