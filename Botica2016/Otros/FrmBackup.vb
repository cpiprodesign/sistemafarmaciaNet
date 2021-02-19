Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Data.Sql
Imports Vb = Microsoft.VisualBasic
Public Class FrmBackup


    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MySQL As String = "sp_databases"
        '  Dim MyConn As New SqlClient.SqlConnection(cn)
        Dim ds As DataSet = New DataSet()
        Dim Cmd As New SqlClient.SqlDataAdapter(MySQL, cn)
        Cmd.Fill(ds, "bd")
        Dim dt As New DataTable
        dt = ds.Tables("bd")
        Me.ComboBox1.DataSource = dt
        Me.ComboBox1.DisplayMember = dt.Columns(0).ToString
        Me.ComboBox1.ValueMember = dt.Columns(0).ToString
    End Sub

    Private Sub btnexaminar_Click(sender As Object, e As EventArgs) Handles btnexaminar.Click
        Dim Directorio As New FolderBrowserDialog

        If Directorio.ShowDialog = DialogResult.OK Then
            Me.txtdirectorio.Text = Directorio.SelectedPath
            txtnombackup.Enabled = True
            txtnombackup.Focus()
        End If
    End Sub
    Private Function crear_backup() As Boolean

        'Dim conecsb As New SqlConnectionStringBuilder
        ' conecsb.DataSource = cn
        'conecsb.InitialCatalog = "master"
        'conecsb.IntegratedSecurity = True

        If txtdirectorio.Text.Length <> 3 Then
            txtdirectorio.Text = txtdirectorio.Text + "\" + txtnombackup.Text + ".bak"
        Else
            txtdirectorio.Text = txtdirectorio.Text + txtnombackup.Text + ".bak"
        End If

        ' Using con As New SqlConnection(conecsb.ConnectionString)
        Try
            cn.Open()
            Dim sCmd As String = "BACKUP DATABASE [" + ComboBox1.Text + "] TO  DISK = N'" + txtdirectorio.Text + "' " &
            "WITH  NOFORMAT, NOINIT, " &
            "NAME = N'" + txtnombackup.Text + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
            Dim cmd As New SqlCommand(sCmd, cn)
            cmd.ExecuteNonQuery()
            crear_backup = True
        Catch ex As Exception
            crear_backup = False
            MessageBox.Show(ex.Message)
        Finally
            cn.Close()
        End Try
        ' End Using
        '"WITH DESCRIPTION = N'" + txtobs.Text + "', NOFORMAT, NOINIT, " & _''' si deseas con desc antes de with
    End Function

    Private Sub btncrear_Click(sender As Object, e As EventArgs) Handles btncrear.Click
        If Me.ComboBox1.Text <> "" Then
            If txtdirectorio.Text <> "" Then
                If txtnombackup.Text <> "" Then
                    '  If txtobs.Text <> "" Then

                    If crear_backup() = True Then
                        MessageBox.Show("Backup creado satisfactoriamnete", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al crear el Backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    'Else
                    '   MessageBox.Show("Ingrese una descripcion del Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End If
                Else
                    MessageBox.Show("Ingrese el nombre del Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione la ruta donde se creara el Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Seleccione la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
End Class