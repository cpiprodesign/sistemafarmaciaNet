Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Public Class LoginForm1

    Dim DsUsu As New DataSet, DaUsu As New SqlDataAdapter
    Dim Cant As Integer, K As Integer, JK As Long
    Dim Activo As Integer
    Dim opcion As Integer = 1

    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        ingresarlogin()
        'Ingresar()
        'Try
        '    DaUsu = New SqlDataAdapter("sesion", cn)
        '    DaUsu.SelectCommand.Parameters.Add("@usu", SqlDbType.VarChar).Value = UsernameTextBox.Text
        '    DaUsu.SelectCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = PasswordTextBox.Text
        '    DsUsu.Clear()
        '    'DaUsu.Fill(DsUsu, "Usuario")
        '    If DsUsu.Tables("Usuario").Rows.Count = 0 Then
        '        If Cant = 3 Then
        '            MessageBox.Show("A Perdido la Oportunidad de Ingresar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.Close()
        '        End If
        '        MessageBox.Show("Usuario o Contraseña Incorrecta", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Me.UsernameTextBox.Text = ""
        '        Me.PasswordTextBox.Text = ""
        '        Me.UsernameTextBox.Focus()

        '        'Agrega uno mas a la opcion de ingresar
        '        Cant += 1
        '    Else
        '        Activo = DsUsu.Tables("usuario").Rows(0).Item(4).ToString

        '        If Activo <> 1 Then
        '            MessageBox.Show("Usuario Inactivo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            UsernameTextBox.Clear()
        '            PasswordTextBox.Clear()
        '            UsernameTextBox.Focus()
        '        Else
        '            ' If DsUsu.Tables("Usuario").Rows.Count = 1 Then
        '            For JK = 1 To Val(PgbAumento.Maximum)
        '                PgbAumento.Value = JK
        '            Next

        '            Nivel = DsUsu.Tables("usuario").Rows(0).Item(1).ToString
        '            Nombre = DsUsu.Tables("Usuario").Rows(0).Item(2).ToString
        '            ' & " " & DsUsu.Tables("Usuario").Rows(0).Item(2).ToString
        '            CodUsu = DsUsu.Tables("Usuario").Rows(0).Item(0).ToString
        '            Activo = DsUsu.Tables("usuario").Rows(0).Item(4).ToString
        '            'cod = DsUsu.Tables("usuario").Rows(0).Item(5).ToString

        '            MessageBox.Show("Bienvenido" + "..." + Nombre, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            '  FrmBienvenida.Show()
        '            MDIParent1.Show()
        '            Me.Hide()
        '            ' End If
        '        End If
        '    End If

        '    '  End If


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)

        'End Try
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = CLng((PgbAumento.Value * 100) / PgbAumento.Maximum) & "%"

    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PgbAumento_Click(sender As Object, e As EventArgs) Handles PgbAumento.Click

    End Sub

    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Sub Ingresar()
        'DaUsu = New SqlDataAdapter("Select * From Usuario Where nom_usU = @Nuser And Password = @Con", cn)
        'DaUsu.SelectCommand.Parameters.Add("@Nuser", SqlDbType.Char).Value = UsernameTextBox.Text
        'DaUsu.SelectCommand.Parameters.Add("@Con", SqlDbType.VarChar).Value = PasswordTextBox.Text
        'DsUsu.Clear()
        'DaUsu.Fill(DsUsu, "Usuario")


        'If DsUsu.Tables("Usuario").Rows.Count = 1 Then
        '    PgbAumento.Value = PgbAumento.Value+1
        '    For JK = 1 To Val(PgbAumento.Maximum)
        '        PgbAumento.Value = JK
        '        Label1.Text = CLng((PgbAumento.Value * 100) / PgbAumento.Maximum) & "%"

        '    Next


        '    Nombre = DsUsu.Tables("Usuario").Rows(0).Item(2).ToString
        '    ' & " " & DsUsu.Tables("Usuario").Rows(0).Item(2).ToString
        '    CodUsu = DsUsu.Tables("Usuario").Rows(0).Item(0).ToString
        '    Activo = DsUsu.Tables("usuario").Rows(0).Item(4).ToString
        '    'cod = DsUsu.Tables("usuario").Rows(0).Item(5).ToString

        '    MsgBox("Bienvenido" + "..." + Nombre)
        '    '  FrmBienvenida.Show()
        '    MDIParent1.Show()
        '    Me.Hide()
        '    ' End If
        'Else
        '    Cant += 1
        '    If Cant = 3 Then
        '        MsgBox("Se terminaron tus oportunidades")
        '        Me.Close()

        '    End If

        '    MsgBox("Tu usuario o contraseña son incorrectos" & vbLf & "Ud. tiene " & Cant & " oportunidades", , "Error no existe")
        '    UsernameTextBox.Clear()
        '    PasswordTextBox.Clear()
        '    UsernameTextBox.Focus()
        '    'Cant -= 1
        'End If
    End Sub

    Sub ingresarlogin()
        Try
            Dim cmd As New SqlCommand("sesion", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@usu", SqlDbType.VarChar, 24).Value = UsernameTextBox.Text
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 30).Value = PasswordTextBox.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            ds.Clear()
            da.Fill(ds, "usuario")
            'Cuenta los registros del datatable si es igual a 0
            If ds.Tables("usuario").Rows.Count() = 0 Then
                If opcion = 3 Then
                    MessageBox.Show("A Perdido la Oportunidad de Ingresar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                End If
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.UsernameTextBox.Text = ""
                Me.PasswordTextBox.Text = ""
                Me.UsernameTextBox.Focus()
                'Agrega uno mas a la opcion de ingresar
                opcion += 1

            Else
                'ver si el usuario esta activo, busca datos en el datatable
                Activo = ds.Tables("usuario").Rows(0)(3)
                If Activo <> 1 Then
                    MessageBox.Show("Usuario Inactivo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    For JK = 1 To Val(PgbAumento.Maximum)
                        PgbAumento.Value = JK
                        Label1.Text = CLng((PgbAumento.Value * 100) / PgbAumento.Maximum) & "%"

                    Next
                    'pasa los valores del datatable, el usuario y nivel de usuario
                    Nivel = ds.Tables("usuario").Rows(0)(4)
                    CodUsu = ds.Tables("usuario").Rows(0)(0)
                    Activo = ds.Tables("usuario").Rows(0).Item(3).ToString
                    Nombre = ds.Tables("Usuario").Rows(0).Item(5).ToString
                    cargo = ds.Tables("usuario").Rows(0).Item(6).ToString
                    '        
                    MessageBox.Show("Bienvenido" + "..." + Nombre, "SystFarma", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim f1 As New MDIParent1
                    Me.Hide()
                    f1.Show()
                    'Abre el formulario producto sin sotck'
                    Dim f2 As New FrmProductosSinStock
                    Me.Hide()
                    f2.Show()


                End If
            End If





            'End If
            'If UsernameTextBox.Text = "" And PasswordTextBox.Text = "" Then
            '    MsgBox("Debes ingresar tus Datos para ingresar", MsgBoxStyle.Information, "Sistema")
            'Else
            '    Dim cmd As New SqlCommand("sesion", cn)
            '    cmd.CommandType = CommandType.StoredProcedure
            '    cmd.Parameters.Add("@usu", SqlDbType.VarChar, 30).Value = UsernameTextBox.Text
            '    cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 30).Value = UsernameTextBox.Text
            '    Dim da As New SqlDataAdapter(cmd)
            '    Dim ds As New DataSet
            '    ds.Clear()
            '    da.Fill(ds, "usuario")
            '    ' DataGridView1.DataSource = ds
            '    If ds.Tables("usuario").Rows.Count = 1 Then
            '        For JK = 1 To Val(PgbAumento.Maximum)
            '            PgbAumento.Value = JK
            '        Next

            '        Nivel = DsUsu.Tables("usuario").Rows(0).Item(4).ToString
            '        Nombre = DsUsu.Tables("Usuario").Rows(0).Item(5).ToString
            '        ' & " " & DsUsu.Tables("Usuario").Rows(0).Item(2).ToString
            '        CodUsu = DsUsu.Tables("Usuario").Rows(0).Item(0).ToString
            '        Activo = DsUsu.Tables("usuario").Rows(0).Item(3).ToString
            '        'cod = DsUsu.Tables("usuario").Rows(0).Item(5).ToString

            '        MessageBox.Show("Bienvenido" + "..." + Nombre, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        '  FrmBienvenida.Show()
            '        MDIParent1.Show()
            '        Me.Hide()

            '    End If
            'End If
        Catch ex As Exception
            MsgBox("No se conecto con la base de datos" + ex.Message)
        End Try
    End Sub
    Private Sub PasswordTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = Chr(13) Then
            ingresarlogin()
            'Try

            '    Dim cmd As New SqlCommand("sesion", cn)

            '    ''DaUsu.SelectCommand.Parameters.Add("@usu", SqlDbType.VarChar).Value = UsernameTextBox.Text
            '    ''DaUsu.SelectCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = PasswordTextBox.Text
            '    ''DsUsu.Clear()

            '    cmd.CommandType = CommandType.StoredProcedure
            '    cmd.Parameters.Add("@usu", SqlDbType.VarChar, 30).Value = UsernameTextBox.Text
            '    cmd.Parameters.Add("@pass", SqlDbType.VarChar, 24).Value = PasswordTextBox.Text
            '    Dim Da As New SqlDataAdapter(cmd)
            '    Da.Fill(DsUsu, "Usuario")
            '    If DsUsu.Tables("Usuario").Rows.Count = 0 Then
            '        If Cant = 3 Then
            '            MessageBox.Show("A Perdido la Oportunidad de Ingresar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '            Me.Close()
            '        End If
            '        MessageBox.Show("Usuario o Contraseña Incorrecta", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Me.UsernameTextBox.Text = ""
            '        Me.PasswordTextBox.Text = ""
            '        Me.UsernameTextBox.Focus()

            '        'Agrega uno mas a la opcion de ingresar
            '        Cant += 1
            '    Else
            '        Activo = DsUsu.Tables("usuario").Rows(0).Item(3).ToString

            '        If Activo <> 1 Then
            '            MessageBox.Show("Usuario Inactivo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            UsernameTextBox.Clear()
            '            PasswordTextBox.Clear()
            '            UsernameTextBox.Focus()
            '        Else
            '            ' If DsUsu.Tables("Usuario").Rows.Count = 1 Then
            '            For JK = 1 To Val(PgbAumento.Maximum)
            '                PgbAumento.Value = JK
            '            Next

            '            Nivel = DsUsu.Tables("usuario").Rows(0).Item(4).ToString
            '            Nombre = DsUsu.Tables("Usuario").Rows(0).Item(5).ToString
            '            ' & " " & DsUsu.Tables("Usuario").Rows(0).Item(2).ToString
            '            CodUsu = DsUsu.Tables("Usuario").Rows(0).Item(0).ToString
            '            Activo = DsUsu.Tables("usuario").Rows(0).Item(3).ToString
            '            'cod = DsUsu.Tables("usuario").Rows(0).Item(5).ToString

            '            MessageBox.Show("Bienvenido" + "..." + Nombre, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            '  FrmBienvenida.Show()
            '            MDIParent1.Show()
            '            Me.Hide()
            '            ' End If
            '        End If
            '    End If

            '    ' End If


            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)

            'End Try
        End If
    End Sub
End Class
