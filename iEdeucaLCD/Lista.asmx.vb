Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Lista1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetProfesor(ByVal curso As Integer) As String
        Dim lista As cls_Listas = New cls_Listas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = lista.GetProfesor(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetEstudiante(ByVal curso As Integer) As String
        Dim lista As cls_Listas = New cls_Listas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = lista.GetEstudiante(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function Ordenar(ByVal curso As Integer) As String
        Dim lista As cls_Listas = New cls_Listas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = lista.Ordenar(curso)
        Return ds
    End Function
End Class