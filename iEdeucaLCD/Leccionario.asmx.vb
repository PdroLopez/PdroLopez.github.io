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
Public Class Leccionario1
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function GetAsignatura(ByVal curso As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.GetAsignatura(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function Ingresar(ByVal unidad As Integer, ByVal habilidad As Integer,
                              ByVal objetivo As Integer, ByVal fecha As Date, ByVal curso As Integer, ByVal asignatura As Integer, ByVal LeccionarioId As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.Ingresar(unidad, habilidad, objetivo, fecha, curso, asignatura, LeccionarioId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarLeccionario(ByVal unidad As Integer, ByVal habilidad As Integer,
                              ByVal objetivo As Integer, ByVal fecha As Date, ByVal LeccionarioId As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.EditarLeccionario(unidad, habilidad, objetivo, fecha, LeccionarioId)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarUnidad(ByVal nombre_unidad As String,
                             ByVal descripcion_unidad As String, ByVal curso As Integer, ByVal asignatura As String) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.IngresarUnidad(nombre_unidad, descripcion_unidad, curso, asignatura)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarHabilidad(ByVal nombre_unidad As String,
                             ByVal descripcion_unidad As String, ByVal objetivo As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.IngresarHabilidad(nombre_unidad, descripcion_unidad, objetivo)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetObjetivoSelect(ByVal unidad As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.GetObjetivoSelect(unidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetHabilidadSelect(ByVal objetivo_input As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.GetHabilidadSelect(objetivo_input)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarObjetivo(ByVal nombre_unidad As String,
                             ByVal descripcion_unidad As String, ByVal unidad As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.IngresarObjetivo(nombre_unidad, descripcion_unidad, unidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function getTabla(ByVal curso As Integer, ByVal asignatura As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.getTabla(curso, asignatura)
        Return ds
    End Function
    <WebMethod()>
    Public Function selectUnidad(ByVal curso As Integer, ByVal asignatura As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.selectUnidad(curso, asignatura)
        Return ds
    End Function
    <WebMethod()>
    Public Function selectObjetivo() As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.selectObjetivo()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetObjetivo(ByVal unidad As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.GetObjetivo(unidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function ActualizarDescripcion(ByVal descripcion As String, ByVal idLeccionario As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.ActualizarDescripcion(descripcion, idLeccionario)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetHabilidad(ByVal objetivo As Integer) As String
        Dim leccionario As cls_Leccionario = New cls_Leccionario()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = leccionario.GetHabilidad(objetivo)
        Return ds
    End Function
End Class