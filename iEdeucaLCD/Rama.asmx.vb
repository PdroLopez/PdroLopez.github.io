Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Rama1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectRamaEspecialidad() As String
        Dim rama_ As cls_Rama = New cls_Rama()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = rama_.SelectRamaEspecialidad()
        Return ds
    End Function

    <WebMethod()>
    Public Function GetRama(ByVal rama As String) As String
        Dim rama_ As cls_Rama = New cls_Rama()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = rama_.GetRama(rama)
        Return ds
    End Function

End Class