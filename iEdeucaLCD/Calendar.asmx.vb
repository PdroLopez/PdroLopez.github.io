Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Calendar
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function IngresarCalendario(ByVal strAsignaturas As String) As String
        Dim calendar As cls_Calendar = New cls_Calendar()
        Dim ds As String
        ds = ""
        ds = calendar.IngresarCalendario(strAsignaturas)
        Return ds
    End Function

End Class