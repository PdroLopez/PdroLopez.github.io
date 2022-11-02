Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Jornada1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectJornada() As String
        Dim jornada As cls_Jornada = New cls_Jornada()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = jornada.SelectJornada()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetJornada(ByVal jornada As Integer) As String
        Dim jornada_ As cls_Jornada = New cls_Jornada()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = jornada_.GetJornada(jornada)
        Return ds
    End Function


End Class