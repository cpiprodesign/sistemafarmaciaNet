<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBackup
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtdirectorio = New System.Windows.Forms.TextBox()
        Me.txtnombackup = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnexaminar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btncrear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(105, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(180, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtdirectorio)
        Me.GroupBox1.Controls.Add(Me.txtnombackup)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnexaminar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 130)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'txtdirectorio
        '
        Me.txtdirectorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdirectorio.Location = New System.Drawing.Point(105, 53)
        Me.txtdirectorio.Name = "txtdirectorio"
        Me.txtdirectorio.Size = New System.Drawing.Size(180, 20)
        Me.txtdirectorio.TabIndex = 14
        '
        'txtnombackup
        '
        Me.txtnombackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnombackup.Location = New System.Drawing.Point(105, 83)
        Me.txtnombackup.Name = "txtnombackup"
        Me.txtnombackup.Size = New System.Drawing.Size(278, 20)
        Me.txtnombackup.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Base datos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Directorio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Nombre Backup"
        '
        'btnexaminar
        '
        Me.btnexaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexaminar.Location = New System.Drawing.Point(291, 43)
        Me.btnexaminar.Name = "btnexaminar"
        Me.btnexaminar.Size = New System.Drawing.Size(66, 30)
        Me.btnexaminar.TabIndex = 18
        Me.btnexaminar.Text = "Examinar"
        Me.btnexaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnexaminar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.Location = New System.Drawing.Point(187, 148)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(112, 30)
        Me.btnsalir.TabIndex = 26
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btncrear
        '
        Me.btncrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncrear.Location = New System.Drawing.Point(102, 148)
        Me.btncrear.Name = "btncrear"
        Me.btncrear.Size = New System.Drawing.Size(79, 30)
        Me.btncrear.TabIndex = 25
        Me.btncrear.Text = "Crear backup"
        Me.btncrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncrear.UseVisualStyleBackColor = True
        '
        'FrmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 204)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.btncrear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FrmBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COPIA DE SEGURIDAD"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtdirectorio As TextBox
    Friend WithEvents txtnombackup As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnexaminar As Button
    Friend WithEvents btnsalir As Button
    Friend WithEvents btncrear As Button
End Class
