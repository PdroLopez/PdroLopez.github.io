Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Especialidad1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function ChangeEspecialidad(ByVal sector As String) As String
        Dim especialidad As cls_Especialidad = New cls_Especialidad()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = especialidad.ChangeEspecialidad(sector)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetEspecialidad(ByVal especialidad As String) As String
        Dim especialidad_ As cls_Especialidad = New cls_Especialidad()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = especialidad_.GetEspecialidad(especialidad)
        Return ds
    End Function

End Class