Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Enseñanza1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectEnseñanza(ByVal nivel As String) As String
        Dim enseñanza As cls_Enseñanza = New cls_Enseñanza()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = enseñanza.SelectEnseñanza(nivel)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetEnseñanza(ByVal tipo_enseñanza As String) As String
        Dim enseñanza As cls_Enseñanza = New cls_Enseñanza()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = enseñanza.GetEnseñanza(tipo_enseñanza)
        Return ds
    End Function

End Class