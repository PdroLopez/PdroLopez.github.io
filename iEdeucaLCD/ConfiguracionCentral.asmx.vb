Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ConfiguracionCentral
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function AgregarConfiguracionCentral(ByVal codigo As String, ByVal nombre As String) As String
        Dim asignatura As cls_ConfiguracionCentral = New cls_ConfiguracionCentral()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.AgregarConfiguracionCentral(codigo, nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarConfiguracionCentral(ByVal nombre As String, ByVal codigo As String, ByVal ConfiguracionCentralId As Integer) As String
        Dim asignatura As cls_ConfiguracionCentral = New cls_ConfiguracionCentral()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EditarConfiguracionCentral(nombre, codigo, ConfiguracionCentralId)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetData() As String
        Dim asignatura As cls_ConfiguracionCentral = New cls_ConfiguracionCentral()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.GetData()
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarConfiguracionCentral(ByVal ConfiguracionCentralId As Integer) As String
        Dim asignatura As cls_ConfiguracionCentral = New cls_ConfiguracionCentral()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EliminarConfiguracionCentral(ConfiguracionCentralId)
        Return ds
    End Function
End Class