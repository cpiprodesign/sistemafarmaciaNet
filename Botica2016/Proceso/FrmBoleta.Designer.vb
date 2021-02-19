<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBoleta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBoleta))
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.nuddescuento = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtidproducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.btnbuscarproducto = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.Lbstock = New System.Windows.Forms.Label()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.LBPRECIO = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lblcod = New System.Windows.Forms.Label()
        Me.LblRuc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnExaminar = New System.Windows.Forms.Button()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.lbcodigo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.LblSub = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pdg = New System.Windows.Forms.PrintDialog()
        Me.pdt = New System.Drawing.Printing.PrintDocument()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.psdpagina = New System.Windows.Forms.PageSetupDialog()
        CType(Me.nuddescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltotal
        '
        Me.lbltotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotal.Location = New System.Drawing.Point(394, 550)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(68, 18)
        Me.lbltotal.TabIndex = 150
        Me.lbltotal.Text = "0.00"
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(334, 555)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "Total:"
        '
        'nuddescuento
        '
        Me.nuddescuento.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nuddescuento.Location = New System.Drawing.Point(394, 525)
        Me.nuddescuento.Name = "nuddescuento"
        Me.nuddescuento.Size = New System.Drawing.Size(56, 20)
        Me.nuddescuento.TabIndex = 148
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(334, 532)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 147
        Me.Label13.Text = "Decuento:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtidproducto)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtdescripcion)
        Me.GroupBox4.Controls.Add(Me.txtcantidad)
        Me.GroupBox4.Controls.Add(Me.btnbuscarproducto)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.btneliminar)
        Me.GroupBox4.Controls.Add(Me.Lbstock)
        Me.GroupBox4.Controls.Add(Me.btnagregar)
        Me.GroupBox4.Controls.Add(Me.LBPRECIO)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(12, 217)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(450, 135)
        Me.GroupBox4.TabIndex = 146
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Producto"
        '
        'txtidproducto
        '
        Me.txtidproducto.Location = New System.Drawing.Point(72, 32)
        Me.txtidproducto.Name = "txtidproducto"
        Me.txtidproducto.Size = New System.Drawing.Size(87, 20)
        Me.txtidproducto.TabIndex = 133
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Codigo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 130
        Me.Label7.Text = "Descripcion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(225, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Precio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Cantidad"
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Location = New System.Drawing.Point(72, 58)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(131, 20)
        Me.txtdescripcion.TabIndex = 134
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(273, 58)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(54, 20)
        Me.txtcantidad.TabIndex = 135
        Me.txtcantidad.Text = "0"
        '
        'btnbuscarproducto
        '
        Me.btnbuscarproducto.Image = CType(resources.GetObject("btnbuscarproducto.Image"), System.Drawing.Image)
        Me.btnbuscarproducto.Location = New System.Drawing.Point(165, 10)
        Me.btnbuscarproducto.Name = "btnbuscarproducto"
        Me.btnbuscarproducto.Size = New System.Drawing.Size(55, 46)
        Me.btnbuscarproducto.TabIndex = 136
        Me.btnbuscarproducto.Text = "...."
        Me.btnbuscarproducto.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(390, 84)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 45)
        Me.Button3.TabIndex = 106
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "Stock"
        '
        'btneliminar
        '
        Me.btneliminar.Image = CType(resources.GetObject("btneliminar.Image"), System.Drawing.Image)
        Me.btneliminar.Location = New System.Drawing.Point(329, 85)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(55, 45)
        Me.btneliminar.TabIndex = 105
        Me.btneliminar.Text = "&"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'Lbstock
        '
        Me.Lbstock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbstock.Location = New System.Drawing.Point(72, 81)
        Me.Lbstock.Name = "Lbstock"
        Me.Lbstock.Size = New System.Drawing.Size(80, 18)
        Me.Lbstock.TabIndex = 138
        '
        'btnagregar
        '
        Me.btnagregar.Image = CType(resources.GetObject("btnagregar.Image"), System.Drawing.Image)
        Me.btnagregar.Location = New System.Drawing.Point(268, 85)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(55, 45)
        Me.btnagregar.TabIndex = 104
        Me.btnagregar.Text = "&"
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'LBPRECIO
        '
        Me.LBPRECIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBPRECIO.Location = New System.Drawing.Point(273, 34)
        Me.LBPRECIO.Name = "LBPRECIO"
        Me.LBPRECIO.Size = New System.Drawing.Size(54, 18)
        Me.LBPRECIO.TabIndex = 139
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lblcod)
        Me.GroupBox2.Controls.Add(Me.LblRuc)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.BtnExaminar)
        Me.GroupBox2.Controls.Add(Me.LblCliente)
        Me.GroupBox2.Controls.Add(Me.lbcodigo)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(12, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(450, 110)
        Me.GroupBox2.TabIndex = 145
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Cliente:"
        '
        'Lblcod
        '
        Me.Lblcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblcod.Location = New System.Drawing.Point(87, 30)
        Me.Lblcod.Name = "Lblcod"
        Me.Lblcod.Size = New System.Drawing.Size(100, 18)
        Me.Lblcod.TabIndex = 124
        '
        'LblRuc
        '
        Me.LblRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRuc.Location = New System.Drawing.Point(88, 82)
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Size = New System.Drawing.Size(120, 18)
        Me.LblRuc.TabIndex = 121
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "N° RUC:"
        '
        'BtnExaminar
        '
        Me.BtnExaminar.Image = CType(resources.GetObject("BtnExaminar.Image"), System.Drawing.Image)
        Me.BtnExaminar.Location = New System.Drawing.Point(215, 11)
        Me.BtnExaminar.Name = "BtnExaminar"
        Me.BtnExaminar.Size = New System.Drawing.Size(52, 41)
        Me.BtnExaminar.TabIndex = 120
        Me.BtnExaminar.Text = "..."
        Me.BtnExaminar.UseVisualStyleBackColor = True
        '
        'LblCliente
        '
        Me.LblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCliente.Location = New System.Drawing.Point(87, 58)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(223, 18)
        Me.LblCliente.TabIndex = 122
        '
        'lbcodigo
        '
        Me.lbcodigo.AutoSize = True
        Me.lbcodigo.Location = New System.Drawing.Point(19, 30)
        Me.lbcodigo.Name = "lbcodigo"
        Me.lbcodigo.Size = New System.Drawing.Size(43, 13)
        Me.lbcodigo.TabIndex = 123
        Me.lbcodigo.Text = "Codigo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Calle Sta Lucia 169 URB Sto Domingo."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(310, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 66)
        Me.GroupBox1.TabIndex = 144
        Me.GroupBox1.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(67, 37)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(78, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nrº Boleta"
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(67, 11)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(78, 20)
        Me.TextBox3.TabIndex = 0
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(42, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(150, 13)
        Me.Label16.TabIndex = 137
        Me.Label16.Text = "Le ofrece atencion profesional"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(49, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(143, 13)
        Me.Label18.TabIndex = 136
        Me.Label18.Text = "De: Aylas Ricse LIZ YEENIA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(38, 602)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 139
        Me.Label15.Text = "Label15"
        Me.Label15.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(26, 7)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 25)
        Me.Label19.TabIndex = 135
        Me.Label19.Text = """Botica Javier"""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.btnguardar)
        Me.GroupBox3.Controls.Add(Me.btnnuevo)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 510)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(267, 73)
        Me.GroupBox3.TabIndex = 143
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OPERACIONES"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(172, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 42)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "&"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.Enabled = False
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.Location = New System.Drawing.Point(94, 22)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(72, 44)
        Me.btnguardar.TabIndex = 1
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = CType(resources.GetObject("btnnuevo.Image"), System.Drawing.Image)
        Me.btnnuevo.Location = New System.Drawing.Point(33, 24)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(62, 42)
        Me.btnnuevo.TabIndex = 0
        Me.btnnuevo.Text = "&"
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'LblSub
        '
        Me.LblSub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSub.Location = New System.Drawing.Point(394, 500)
        Me.LblSub.Name = "LblSub"
        Me.LblSub.Size = New System.Drawing.Size(68, 18)
        Me.LblSub.TabIndex = 142
        Me.LblSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(334, 505)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 141
        Me.Label12.Text = "Sub Total:"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.DodgerBlue
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.Coral
        Me.DataGridView1.Location = New System.Drawing.Point(12, 361)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(450, 136)
        Me.DataGridView1.TabIndex = 140
        '
        'pdg
        '
        Me.pdg.UseEXDialog = True
        '
        'pdt
        '
        '
        'ppd
        '
        Me.ppd.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd.Enabled = True
        Me.ppd.Icon = CType(resources.GetObject("ppd.Icon"), System.Drawing.Icon)
        Me.ppd.Name = "ppd"
        Me.ppd.Visible = False
        '
        'FrmBoleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 581)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.nuddescuento)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblSub)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmBoleta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBoleta"
        CType(Me.nuddescuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltotal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents nuddescuento As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtidproducto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtdescripcion As TextBox
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents btnbuscarproducto As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents btneliminar As Button
    Friend WithEvents Lbstock As Label
    Friend WithEvents btnagregar As Button
    Friend WithEvents LBPRECIO As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Lblcod As Label
    Friend WithEvents LblRuc As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnExaminar As Button
    Friend WithEvents LblCliente As Label
    Friend WithEvents lbcodigo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents btnnuevo As Button
    Friend WithEvents LblSub As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents pdg As PrintDialog
    Friend WithEvents pdt As Printing.PrintDocument
    Friend WithEvents ppd As PrintPreviewDialog
    Friend WithEvents psdpagina As PageSetupDialog
End Class
