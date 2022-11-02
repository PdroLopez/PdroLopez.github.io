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
Public Class Notas1
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function tablaData(ByVal curso As Integer, ByVal asignatura As Integer) As String
        Dim notas As cls_Notas = New cls_Notas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = notas.tablaData(curso, asignatura)
        Return tabla
    End Function
    <WebMethod()>
    Public Function Tabla() As String
        Dim notas As cls_Notas = New cls_Notas()
        Dim tablaxd As String
        tablaxd = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tablaxd = notas.Tabla()
        Return tablaxd
    End Function
    <WebMethod()>
    Public Function GetAsignaturaAll(ByVal curso As Integer) As String
        Dim notas As cls_Notas = New cls_Notas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = notas.GetAsignaturaAll(curso)
        Return tabla
    End Function
    <WebMethod()>
    Public Function IngresarEvaluacion(ByVal nombre As String,
                                  ByVal curso As Integer, ByVal EvaluacionId As Integer,
                                  ByVal asignatura As Integer, ByVal ìdNotaStr As String, ByVal h_inicial As DateTime, ByVal h_fin As DateTime, ByVal fecha As Date
                                    ) As String
        Dim notas As cls_Notas = New cls_Notas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = notas.IngresarEvaluacion(nombre, curso, EvaluacionId, asignatura, ìdNotaStr, h_inicial, h_fin, fecha)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarNotas(ByVal asignatura As Integer, ByVal ìdNotaStr As String) As String
        Dim notas As cls_Notas = New cls_Notas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = notas.IngresarNotas(asignatura, ìdNotaStr)
        Return ds
    End Function
    '<WebMethod()>
    'Public Function Promedio(ByVal asignatura As Integer, ByVal curso As Integer, ByVal ìdNotaStr As String) As String
    '    Dim notas As cls_Notas = New cls_Notas()
    '    Dim tabla As String
    '    tabla = "NADA!"
    '    Dim ds As String
    '    Dim i As Integer
    '    i = 0
    '    ds = notas.Promedio(asignatura, curso, ìdNotaStr)
    '    Return ds
    'End Function
    <WebMethod()>
    Public Function GetEstudiante(ByVal curso As Integer, ByVal asignatura As Integer) As String
        Dim notas As cls_Notas = New cls_Notas()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = notas.GetEstudiante(curso, asignatura)
        Return tabla
    End Function


End Class