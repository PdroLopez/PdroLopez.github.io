Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlDbType
Imports System.Xml

Public Class clsConsulta
    Private _Error As Boolean
    Public _MsnError As String
    Dim _Conexion As New clsConexion
    Public Property Estado_Query() As Boolean
        Get
            Return Me._Error
        End Get
        Set(ByVal value As Boolean)
            Me._Error = value
        End Set
    End Property
    Public Property Msg_Error_Query() As String
        Get
            Return Me._MsnError
        End Get
        Set(ByVal value As String)
            Me._MsnError = value
        End Set
    End Property
    'Public Function strConn() As String
    '    Return My.Settings.strConn
    'End Function
    Public Function ExecuteSQL(ByVal NomSP As String, ByVal NomParam As ArrayList, ByVal ValParam As ArrayList) As DataSet
        Dim Dt As New DataSet
        Try
            Dim Conexion As New SqlClient.SqlConnection
            Dim SqlExec As New SqlClient.SqlCommand
            Dim ParamDept As SqlClient.SqlParameter()
            Dim i As Integer

            Dim myConnection As New SqlClient.SqlConnection
            myConnection.ConnectionString = _Conexion.StringConexion("ie")
            'myConnection.ConnectionString = strConn()

            SqlExec.Connection = myConnection
            SqlExec.CommandType = CommandType.StoredProcedure
            SqlExec.CommandText = NomSP
            SqlExec.CommandTimeout = 5900000

            If Not IsNothing(NomParam) And Not IsNothing(ValParam) Then
                If NomParam.Count <> 0 And ValParam.Count <> 0 Then
                    ParamDept = New SqlClient.SqlParameter(NomParam.Count - 1) {}
                    For i = 0 To NomParam.Count - 1
                        SqlExec.Parameters.AddWithValue(NomParam(i), ValParam(i))
                    Next
                End If
            End If
            myConnection.Open()

            Dim Csd As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter
            Csd.SelectCommand = SqlExec
            Dim Ds As DataSet = New DataSet
            Csd.Fill(Dt)
            myConnection.Close()
            _Error = True
            _MsnError = Nothing
            Return Dt
        Catch ex As Exception
            _Error = False
            _MsnError = ex.Message
            Return Dt
            Exit Function
        End Try
    End Function
    Public Sub writeLogInSQL(ByVal NomSP As String, ByVal NomParam As ArrayList, ByVal ValParam As ArrayList)
        Dim Dt As New DataSet
        Try
            Dim Conexion As New SqlClient.SqlConnection
            Dim SqlExec As New SqlClient.SqlCommand
            Dim ParamDept As SqlClient.SqlParameter()
            Dim i As Integer

            Dim myConnection As New SqlClient.SqlConnection
            'myConnection.ConnectionString = strConn()
            myConnection.ConnectionString = _Conexion.StringConexion("ie")

            SqlExec.Connection = myConnection
            SqlExec.CommandType = CommandType.StoredProcedure
            SqlExec.CommandText = NomSP
            SqlExec.CommandTimeout = 5900000

            If Not IsNothing(NomParam) And Not IsNothing(ValParam) Then
                If NomParam.Count <> 0 And ValParam.Count <> 0 Then
                    ParamDept = New SqlClient.SqlParameter(NomParam.Count - 1) {}
                    For i = 0 To NomParam.Count - 1
                        SqlExec.Parameters.AddWithValue(NomParam(i), ValParam(i))
                    Next
                End If
            End If
            myConnection.Open()

            Dim Csd As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter
            Csd.SelectCommand = SqlExec
            Dim Ds As DataSet = New DataSet
            Csd.Fill(Dt)
            myConnection.Close()
            _Error = True
            _MsnError = Nothing
            'Return True
        Catch ex As Exception
            _Error = False
            _MsnError = ex.Message

            'Return False
            Exit Sub
        End Try
    End Sub

End Class
