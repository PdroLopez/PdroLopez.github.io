Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Menu1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SelectIcon() As String
        Dim persona As cls_Menu = New cls_Menu()
        Dim Datos As String
        Datos = ""
        Datos = persona.SelectIcon()
        Return Datos
    End Function
    <WebMethod()>
    Public Function SelectPadre(ByVal ColegioID As Integer) As String
        Dim persona As cls_Menu = New cls_Menu()
        Dim Datos As String
        Datos = ""
        Datos = persona.SelectPadre(ColegioID)
        Return Datos
    End Function

    <WebMethod()>
    Public Function AgregarPadre(ByVal nombre As String, ByVal icons As Integer,
                                 ByVal orden As Integer, ByVal ColegioID As Integer) As String
        Dim persona As cls_Menu = New cls_Menu()
        Dim Datos As String
        Datos = ""
        Datos = persona.AgregarPadre(nombre, icons, orden, ColegioID)
        Return Datos
    End Function
    <WebMethod()>
    Public Function AgregarSubMenu(ByVal nombre As String,
                                   ByVal icons As Integer,
                               ByVal padre As Integer,
                                   ByVal url As String,
                                    ByVal orden As Integer,
                                    ByVal contacto_emergencia As Integer,
                                   ByVal ColegioID As Integer) As String
        Dim persona As cls_Menu = New cls_Menu()
        Dim Datos As String
        Datos = ""
        Datos = persona.AgregarSubMenu(nombre, icons, padre, url, orden, contacto_emergencia, ColegioID)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarSubMenu() As String
        Dim persona As cls_Menu = New cls_Menu()
        Dim Datos As String
        Datos = ""
        Datos = persona.MostrarSubMenu()
        Return Datos
    End Function
End Class