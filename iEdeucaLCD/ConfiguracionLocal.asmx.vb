Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ConfiguracionLocal1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectConfiguracion() As String
        Dim asignatura As cls_ConfiguracionLocal = New cls_ConfiguracionLocal()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.SelectConfiguracion()
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarConfiguracionLocal(ByVal ConfiguracionLocalId As Integer) As String
        Dim asignatura As cls_ConfiguracionLocal = New cls_ConfiguracionLocal()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EliminarConfiguracionLocal(ConfiguracionLocalId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarConfiguracionLocal(ByVal valor As String, ByVal configuracion As Integer, ByVal ConfiguracionLocalId As Integer) As String
        Dim asignatura As cls_ConfiguracionLocal = New cls_ConfiguracionLocal()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EditarConfiguracionLocal(valor, configuracion, ConfiguracionLocalId)
        Return ds
    End Function
    <WebMethod()>
    Public Function AgregarConfiguracionLocal(ByVal valor As String, ByVal configuracion As Integer, ByVal ColegioID As Integer) As String
        Dim asignatura As cls_ConfiguracionLocal = New cls_ConfiguracionLocal()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.AgregarConfiguracionLocal(valor, configuracion, ColegioID)
        Return ds
    End Function

    <WebMethod()>
    Public Function GetData(ByVal ColegioID As Integer) As String
        Dim asignatura As cls_ConfiguracionLocal = New cls_ConfiguracionLocal()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.GetData(ColegioID)
        Return ds
    End Function
End Class