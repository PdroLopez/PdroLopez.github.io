Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Modalidad1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectModalidad() As String
        Dim modalidad As cls_Modalidad = New cls_Modalidad()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = modalidad.SelectModalidad()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetModalidad(ByVal modalidad As Integer) As String
        Dim modalidad_ As cls_Modalidad = New cls_Modalidad()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = modalidad_.GetModalidad(modalidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function ValidacionModalidad(ByVal modalidad As Integer) As String
        Dim modalidad_ As cls_Modalidad = New cls_Modalidad()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = modalidad_.ValidacionModalidad(modalidad)
        Return ds
    End Function

End Class