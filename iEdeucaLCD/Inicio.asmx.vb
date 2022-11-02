Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Inicio1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Menu(ByVal rol As Integer) As String
        Dim login As cls_Login = New cls_Login()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.Menu(rol)
        Return ds
    End Function
    <WebMethod()>
    Public Function CountColegio(ByVal user As String, ByVal contra As String) As String
        Dim login As cls_Inicio = New cls_Inicio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.CountColegio(user, contra)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetColegio(ByVal user As String, ByVal contra As String) As String
        Dim login As cls_Inicio = New cls_Inicio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.GetColegio(user, contra)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetRol(ByVal user As String, ByVal contra As String, ByVal id As Integer) As String
        Dim login As cls_Inicio = New cls_Inicio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = login.GetRol(user, contra, id)
        Return ds
    End Function

End Class