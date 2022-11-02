Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Anotacion1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function InsertRefIncidentTimeDescriptionCode(ByVal nombre As String) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.InsertRefIncidentTimeDescriptionCode(nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectRefIncidentTimeDescriptionCode() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.SelectRefIncidentTimeDescriptionCode()
        Return ds
    End Function
    <WebMethod()>
    Public Function InsertRefIncidentBehavior(ByVal nombre As String) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.InsertRefIncidentBehavior(nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectRefIncidentBehavior() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.SelectRefIncidentBehavior()
        Return ds
    End Function

    <WebMethod()>
    Public Function InsertRefDisciplinaryActionTaken(ByVal nombre As String) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.InsertRefDisciplinaryActionTaken(nombre)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectRefDisciplinaryActionTaken() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.SelectRefDisciplinaryActionTaken()
        Return ds
    End Function


    <WebMethod()>
    Public Function SelectRefIncidentPersonRoleType() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.SelectRefIncidentPersonRoleType()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetAsignatura(ByVal curso As Integer) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.GetAsignatura(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectAmbito() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.SelectAmbito()
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectCaracter() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.SelectCaracter()
        Return ds
    End Function
    <WebMethod()>
    Public Function GetAnotacion(ByVal EstudianteId As String, ByVal pt As Integer, ByVal pt2 As Integer) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.GetAnotacion(EstudianteId, pt, pt2)
        Return ds
    End Function
    <WebMethod()>
    Public Function Ambito() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.Ambito()
        Return ds
    End Function
    <WebMethod()>
    Public Function Puntaje() As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.Puntaje()
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarIncident(ByVal EstudianteId As String, ByVal hora As String, ByVal momento_incidente As Integer,
                                      ByVal detalle As String, ByVal tipo_incidente As Integer, ByVal rol_incidente As Integer,
                                     ByVal uso_arma As Integer, ByVal costo_asociado As Integer, ByVal fecha_inicial_d As Date,
                                     ByVal fecha_fin_d As Date, ByVal explusacion_anio_completo As Integer, ByVal expulsacion_medio_anio As Integer,
                                    ByVal ambito As Integer,
                                     ByVal caracter As Integer, ByVal fecha As Date, ByVal puntaje As String, ByVal concencuencias_disciplinarias As Integer) As String
        Dim asignatur As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatur.IngresarIncident(EstudianteId, hora, momento_incidente, detalle, tipo_incidente, rol_incidente, uso_arma, costo_asociado, fecha_inicial_d, fecha_fin_d, explusacion_anio_completo, expulsacion_medio_anio, ambito, caracter, fecha, puntaje, concencuencias_disciplinarias)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarIncident(ByVal EstudianteId As String, ByVal hora As String, ByVal momento_incidente As Integer,
                                      ByVal detalle As String, ByVal tipo_incidente As Integer, ByVal rol_incidente As Integer,
                                     ByVal uso_arma As Integer, ByVal costo_asociado As Integer, ByVal fecha_inicial_d As Date,
                                     ByVal fecha_fin_d As Date, ByVal explusacion_anio_completo As Integer, ByVal expulsacion_medio_anio As Integer,
                                    ByVal ambito As Integer,
                                     ByVal caracter As Integer, ByVal fecha As Date, ByVal puntaje As String, ByVal concencuencias_disciplinarias As Integer,
                                   ByVal AnotacionesId As Integer) As String
        Dim asignatur As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatur.EditarIncident(EstudianteId, hora, momento_incidente, detalle, tipo_incidente, rol_incidente, uso_arma, costo_asociado, fecha_inicial_d, fecha_fin_d, explusacion_anio_completo, expulsacion_medio_anio, ambito, caracter, fecha, puntaje, concencuencias_disciplinarias, AnotacionesId)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarAnotacion(ByVal EstudianteId As String, ByVal fecha As String, ByVal puntaje As String, ByVal detalle As String,
                                      ByVal curso As Integer, ByVal asignatura As Integer, ByVal docente As Integer,
                                      ByVal ambito As Integer, ByVal caracter As Integer) As String
        Dim asignatur As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatur.IngresarAnotacion(EstudianteId, fecha, puntaje, detalle, curso, asignatura, docente, ambito, caracter)
        Return ds
    End Function



    <WebMethod()>
    Public Function EditarAnotacion(ByVal EstudianteId As String, ByVal fecha As Date, ByVal puntaje As String, ByVal detalle As String,
                                      ByVal curso As Integer, ByVal asignatura As Integer, ByVal docente As Integer,
                                      ByVal ambito As Integer, ByVal caracter As Integer, ByVal AnotacionesId As Integer) As String
        Dim asignatur As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatur.EditarAnotacion(EstudianteId, fecha, puntaje, detalle, curso, asignatura, docente, ambito, caracter, AnotacionesId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarAmbito(ByVal AmbitoId As Integer) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = asignatura.EliminarAmbito(AmbitoId)
        Return ds
    End Function

    <WebMethod()>
    Public Function GetEstudiante(ByVal curso As Integer) As String
        Dim asignatura As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatura.GetEstudiante(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetDocente(ByVal asignatura As Integer) As String
        Dim asignatur As cls_Anotacion = New cls_Anotacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = asignatur.GetDocente(asignatura)
        Return ds
    End Function

End Class