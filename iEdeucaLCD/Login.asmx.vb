Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Login2
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Ingresar(ByVal user As String, ByVal contra As String) As String
        Dim token As cls_TokenWeb = New cls_TokenWeb()
        Dim login As cls_Login = New cls_Login()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        If login.ValidarUsuario(user, contra) = True Then
            ds = token.TokenOk(user)
        End If
        'ds = asignatura.IngresarAsignatura(incide, Curso, tipo_asignatura, tipo_calificacion, nombre, cod_m, id, max_capacidad)
        Return ds
    End Function

    <WebMethod()>
    Public Function DiferentesRoles(ByVal token As String) As String
        Dim login As cls_Login = New cls_Login()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.DiferentesRoles(token)
        Return ds
    End Function
    <WebMethod()>
    Public Function TraerDatos(ByVal user As String, ByVal contra As String) As String
        Dim token As cls_TokenWeb = New cls_TokenWeb()
        Dim login As cls_Login = New cls_Login()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = login.TraerDatos(user, contra)
        'ds = asignatura.IngresarAsignatura(incide, Curso, tipo_asignatura, tipo_calificacion, nombre, cod_m, id, max_capacidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function InsertToken(ByVal user As String, ByVal contra As String, ByVal token As String, ByVal fecha As String) As String
        Dim login As cls_Login = New cls_Login()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.InsertToken(user, contra, token, fecha)
        Return ds
    End Function
    <WebMethod()>
    Public Function DeleteToken(ByVal token As String) As String
        Dim login As cls_Login = New cls_Login()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.DeleteToken(token)
        Return ds
    End Function
End Class