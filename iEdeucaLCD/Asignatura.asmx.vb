Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Asignatura1
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function ExisteAsignatura(ByVal curso As Integer,
                                       ByVal nombre As String) As String
        Dim asignatura As cls_Asignatura = New cls_Asignatura()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.ExisteAsignatura(curso, nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarAsignatura(ByVal incide As Integer, ByVal curso As Integer,
                                       ByVal tipo_asignatura As Integer, ByVal tipo_calificacion As Integer,
                                      ByVal nombre As String, ByVal cod_m As String, ByVal id As Integer,
                                       ByVal max_capacidad As Integer, ByVal token As String) As String
        Dim asignatura As cls_Asignatura = New cls_Asignatura()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.IngresarAsignatura(incide, curso, tipo_asignatura, tipo_calificacion, nombre, cod_m, id, max_capacidad, token)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectCurso(ByVal ColegioID As Integer) As String
        Dim asignatura As cls_Asignatura = New cls_Asignatura()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.SelectCurso(ColegioID)
        Return ds
    End Function

    <WebMethod()>
    Public Function GetAsignatura(ByVal curso As Integer) As String
        Dim asignatura As cls_Asignatura = New cls_Asignatura()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.GetAsignatura(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarAsignatura(ByVal AsignaturaId As Integer, ByVal token As String) As String
        Dim asignatura As cls_Asignatura = New cls_Asignatura()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.EliminarAsignatura(AsignaturaId, token)
        Return ds
    End Function




End Class