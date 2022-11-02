Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Ambito1
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function IngresarAmbito(ByVal nombre As String) As String
        Dim asignatura As cls_Ambito = New cls_Ambito()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.IngresarAmbito(nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarCaracter(ByVal nombre As String) As String
        Dim asignatura As cls_Caracter = New cls_Caracter()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.IngresarCaracter(nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarAmbito(ByVal nombre As String, ByVal AmbitoId As Integer) As String
        Dim asignatura As cls_Ambito = New cls_Ambito()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EditarAmbito(nombre, AmbitoId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarCaracter(ByVal nombre As String, ByVal CaracterId As Integer) As String
        Dim asignatura As cls_Caracter = New cls_Caracter()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EditarCaracter(nombre, CaracterId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarAmbito(ByVal AmbitoId As Integer) As String
        Dim asignatura As cls_Ambito = New cls_Ambito()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EliminarAmbito(AmbitoId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarCaracter(ByVal CaracterId As Integer) As String
        Dim asignatura As cls_Caracter = New cls_Caracter()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EliminarCaracter(CaracterId)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetData() As String
        Dim asignatura As cls_Ambito = New cls_Ambito()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.GetData()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetData2() As String
        Dim asignatura As cls_Caracter = New cls_Caracter()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.GetData2()
        Return ds
    End Function
End Class