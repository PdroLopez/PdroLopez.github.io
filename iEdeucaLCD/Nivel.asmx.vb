Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Nivel1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectNivel() As String
        Dim nivel As cls_Nivel = New cls_Nivel()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = nivel.SelectNivel()
        Return ds
    End Function

    <WebMethod()>
    Public Function GetNivel(ByVal nivel As String) As String
        Dim nivel_ As cls_Nivel = New cls_Nivel()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = nivel_.GetNivel(nivel)
        Return ds
    End Function
    <WebMethod()>
    Public Function ValidacionNivel(ByVal nivel As Integer) As String
        Dim nivel_ As cls_Nivel = New cls_Nivel()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = nivel_.ValidacionNivel(nivel)
        Return ds
    End Function


End Class