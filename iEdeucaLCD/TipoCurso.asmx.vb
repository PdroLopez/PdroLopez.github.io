Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class TipoCurso1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectTipoCurso() As String
        Dim tipo_curso As cls_TipoCurso = New cls_TipoCurso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = tipo_curso.SelectTipoCurso()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetTipoCurso(ByVal tipo_curso As Integer) As String
        Dim tipo_curso_ As cls_TipoCurso = New cls_TipoCurso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = tipo_curso_.GetTipoCurso(tipo_curso)
        Return ds
    End Function
End Class