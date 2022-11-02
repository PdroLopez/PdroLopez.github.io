Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Grado
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectGrado(ByVal tipo_enseñanza As String) As String
        Dim grado As cls_Grado = New cls_Grado()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = grado.SelectGrado(tipo_enseñanza)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetGrado(ByVal grado As String) As String
        Dim grado_ As cls_Grado = New cls_Grado()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = grado_.GetGrado(grado)
        Return ds
    End Function

End Class