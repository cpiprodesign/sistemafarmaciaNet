Imports System.Data.SqlClient
Module conexion
    Public cn As New SqlConnection(My.Settings.cnBotica)
    Public Nombre As String, Pro As String, CodUsu As String, cargo As String, codigousu As String
    Public codigo_produco As String = "", descripcion As String, precio As Decimal, crisstock As Single
    Public codcli As String, nombre_cli As String, ruc As String
    Public Nivel As String
    Public cantidad As Single

    Public foco As String

    Public Function generar(ByVal nombretabla As String, ByVal campogenera As String)
        Dim dagenerar As New SqlDataAdapter
        Dim dsge As New DataSet
        Dim codigogenerado As String = ""
        dagenerar.SelectCommand = New SqlCommand
        With dagenerar.SelectCommand
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "select max(" & campogenera & ") from " & nombretabla.Trim
        End With
        Try
            cn.Open()
            dagenerar.Fill(dsge, "codigo")
            cn.Close()
            codigogenerado = (dsge.Tables("codigo").Rows(0)(0)).ToString
            If codigogenerado <> "" Then
                codigogenerado = dsge.Tables("codigo").Rows(0)(0)
                codigogenerado = Left(codigogenerado, 10 - CStr(Val(Right(codigogenerado, 10) + 1)).Length) & CStr(Val(Right(codigogenerado, 10)) + 1)
            Else
                codigogenerado = CStr(Left(nombretabla, 3).ToUpper) & "00000001"
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        Return codigogenerado
    End Function

End Module
