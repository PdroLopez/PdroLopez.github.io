Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports Negocios
Imports System.Text.Json.Serialization
Imports System.Xml

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Electivos
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetAsignatura(ByVal curso As Integer) As String
        Dim electivos As cls_Electivos = New cls_Electivos()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = electivos.GetAsignatura(curso)
        Return tabla
    End Function
    <WebMethod()>
    Public Function GetEstudiantes(ByVal asignatura As Integer) As String
        Dim electivos As cls_Electivos = New cls_Electivos()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = electivos.GetEstudiantes(asignatura)
        Return tabla
    End Function
    <WebMethod()>
    Public Function IngresarElectivos(ByVal estudiantes As String, ByVal asignatura As Integer, ByVal curso As Integer) As String
        Dim electivos As cls_Electivos = New cls_Electivos()

        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = electivos.IngresarElectivos(estudiantes, asignatura, curso)
        Return tabla
    End Function
    <WebMethod()>
    Public Function QuitarElectivos(ByVal estudiantes As String, ByVal asignatura As Integer, ByVal curso As Integer) As String
        Dim electivos As cls_Electivos = New cls_Electivos()

        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = electivos.QuitarElectivos(estudiantes, asignatura, curso)
        Return tabla
    End Function
    <WebMethod()>
    Public Function MostrarElectivos(ByVal estudiantes As String) As String
        Dim electivos As cls_Electivos = New cls_Electivos()

        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = electivos.MostrarElectivos(estudiantes)
        Return tabla
    End Function
    <WebMethod()>
    Public Function AsignaturaElectivas(ByVal asignatura As Integer, ByVal curso As Integer) As String
        Dim electivos As cls_Electivos = New cls_Electivos()

        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = electivos.AsignaturaElectivas(asignatura, curso)
        Return tabla
    End Function

End Class