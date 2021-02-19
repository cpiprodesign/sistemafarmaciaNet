Imports System.Data.SqlClient
Imports System.Text
Public Class FrmRestore
    Private Sub txtDirPathBackup_TextChanged(sender As Object, e As EventArgs) Handles txtDirPathBackup.TextChanged

    End Sub

    Private Sub FrmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim MySQL As String = "sp_databases"
        ''  Dim MyConn As New SqlClient.SqlConnection(cn)
        'Dim ds As DataSet = New DataSet()
        'Dim Cmd As New SqlClient.SqlDataAdapter(MySQL, cn)
        'Cmd.Fill(ds, "bd")
        'Dim dt As New DataTable
        'dt = ds.Tables("bd")
        'Me.Combobox1.DataSource = dt
        'Me.Combobox1.DisplayMember = dt.Columns(0).ToString
        'Me.Combobox1.ValueMember = dt.Columns(0).ToString
    End Sub
    Private Sub cargar_listadb(ByVal cmb As ComboBox, ByVal cmb_server As ComboBox)
        Try
            Dim cn As String
            Dim selectSql As String
            cn = "data source=" & Combobox1.Text & ";integrated security=true;initial catalog=master"
            Using con As New SqlConnection(cn)
                con.Open()
                selectSql = "select name from sys.databases;"
                Dim com As SqlCommand = New SqlCommand(selectSql, con)
                Dim dr As SqlDataReader = com.ExecuteReader
                While (dr.Read())
                    cmb.Items.Add(dr(0).ToString)

                End While

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function restaurar_basededatos() As Boolean

        Dim sBackup As String = "RESTORE DATABASE " & Me.Combobox1.Text & " FROM DISK = '" & Me.txtDirPathBackup.Text & "'" & " WITH REPLACE"
        Dim conecsb As New SqlConnectionStringBuilder
        conecsb.DataSource = Me.ComboBox2.Text
        conecsb.InitialCatalog = "master"
        conecsb.IntegratedSecurity = True

        Using con As New SqlConnection(conecsb.ConnectionString)
            Try
                con.Open()
                Dim cmdRestore As New SqlCommand(sBackup, con)
                cmdRestore.ExecuteNonQuery()
                restaurar_basededatos = True
            Catch ex As Exception
                restaurar_basededatos = False
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim openFD As New OpenFileDialog()

        With openFD
            .Title = "Seleccionar archivos de Backup"
            .Filter = "Todos los archivos (*.bak)|*.bak"
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                Me.txtDirPathBackup.Text = .FileName
            End If

        End With
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If Combobox1.Text <> "" Then
            If Me.Combobox1.Text <> "" Then
                If txtDirPathBackup.Text <> "" Then
                    If restaurar_basededatos() = True Then
                        MessageBox.Show("Base de Datos Restaurada satisfactoriamnete", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al Restaurar la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Seleccione la ruta donde se creara el Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Ingrese el Nombre del Servidor de Datos SQL", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combobox1.SelectedIndexChanged
        'cargar_listadb(Combobox1, sender)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        'cargar_listadb(Combobox1, sender)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        cargar_listadb(Combobox1, sender)
    End Sub
End Class