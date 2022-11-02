Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Rol1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function EliminarRol(ByVal RolId As Integer) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.EliminarRol(RolId)
        Return Datos
    End Function
    <WebMethod()>
    Public Function IngresarRol(ByVal nombre As String, ByVal ColegioID As Integer) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.IngresarRol(nombre, ColegioID)
        Return Datos
    End Function
    <WebMethod()>
    Public Function EditarRol(ByVal nombre As String, ByVal ColegioID As Integer, ByVal RolId As Integer) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.EditarRol(nombre, ColegioID, RolId)
        Return Datos
    End Function
    <WebMethod()>
    Public Function LlenarTabla(ByVal ColegioID As Integer) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.LlenarTabla(ColegioID)
        Return Datos
    End Function
    <WebMethod()>
    Public Function IngresarRolMenu(ByVal RolMenu As String, ByVal ID_ROL As String) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.IngresarRolMenu(RolMenu, ID_ROL)
        Return Datos
    End Function

    <WebMethod()>
    Public Function OpcionesMenu(ByVal id As Integer) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.OpcionesMenu(id)
        Return Datos
    End Function
    <WebMethod()>
    Public Function GetID(ByVal id As Integer) As String
        Dim persona As cls_Rol = New cls_Rol()
        Dim Datos As String
        Datos = ""
        Datos = persona.GetID(id)
        Return Datos
    End Function

End Class