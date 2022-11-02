Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ConfiguracionSistema
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
    Public Function EliminarConfiguracionSistema(ByVal ConfiguracionSistemaId As Integer) As String
        Dim asignatura As cls_ConfiguracionSistema = New cls_ConfiguracionSistema()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EliminarConfiguracionSistema(ConfiguracionSistemaId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarConfiguracionSistema(ByVal valor As String, ByVal configuracion As Integer,
                                                ByVal ConfiguracionSistemaId As Integer) As String
        Dim asignatura As cls_ConfiguracionSistema = New cls_ConfiguracionSistema()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EditarConfiguracionSistema(valor, configuracion, ConfiguracionSistemaId)
        Return ds
    End Function
    <WebMethod()>
    Public Function AgregarConfiguracionSistema(ByVal valor As String, ByVal configuracion As Integer) As String
        Dim asignatura As cls_ConfiguracionSistema = New cls_ConfiguracionSistema()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.AgregarConfiguracionSistema(valor, configuracion)
        Return ds
    End Function

    <WebMethod()>
    Public Function GetData() As String
        Dim asignatura As cls_ConfiguracionSistema = New cls_ConfiguracionSistema()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.GetData()
        Return ds
    End Function

End Class