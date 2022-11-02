Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Sector1
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function ChangeSector(ByVal rama As String) As String
        Dim sector As cls_Sector = New cls_Sector()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = sector.ChangeSector(rama)
        Return ds
    End Function
    <WebMethod()>
    Public Function BuscarRut(ByVal rut As String) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim Datos As String
        Datos = persona.BuscarRut(rut)
        Return Datos
    End Function
      <WebMethod()>
    Public Function GetSector(ByVal sector As String) As String
        Dim sector_ As cls_Sector = New cls_Sector()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = sector_.GetSector(sector)
        Return ds
    End Function
End Class