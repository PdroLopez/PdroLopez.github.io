Imports System.ComponentModel
Imports System.Web.Services
Imports Negocios
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Asistencia1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetNameEstudiante(ByVal cont As Integer, ByVal curso As Integer) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.GetNameEstudiante(cont, curso)
        Return tabla
    End Function
    <WebMethod()>
    Public Function InsertAsistenciaAll(ByVal fecha As String,
                                        ByVal AsistenciaEstado As Integer, ByVal cordenadas As String) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.InsertAsistenciaAll(fecha, AsistenciaEstado, cordenadas)
        Return tabla
    End Function
    <WebMethod()>
    Public Function ObtenerCordenadas(ByVal curso As Integer, ByVal fecha As String) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.ObtenerCordenadas(curso, fecha)
        Return tabla
    End Function
    <WebMethod()>
    Public Function AnularFirma(ByVal CourseSectionScheduleId As Integer) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.AnularFirma(CourseSectionScheduleId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function InsertFirma(ByVal roleEventId As String, ByVal fecha As String,
                               ByVal otp2 As String, ByVal ORP As Integer, ByVal CourseSectionScheduleId As Integer
                                ) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.InsertFirma(roleEventId, fecha, otp2, ORP, CourseSectionScheduleId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function ValidarFirma(ByVal firma_a As String) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.ValidarFirma(firma_a)
        Return tabla
    End Function
    <WebMethod()>
    Public Function UpdateAsistenciaMensual(ByVal dia As Integer, ByVal orp As Integer,
                                ByVal condicion As Integer, ByVal mes As String, ByVal RoleEventId As Integer) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.UpdateAsistenciaMensual(dia, orp, condicion, mes, RoleEventId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function FirmaDocente(ByVal id As Integer, ByVal firma_ok As Integer) As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.FirmaDocente(id, firma_ok)
        Return tabla
    End Function
    <WebMethod()>
    Public Function SeleccionarPersona() As String
        Dim persona As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.MostrarPersonas
        Return tabla
    End Function
    <WebMethod()>
    Public Function Cabecera(ByVal fecha As String, ByVal curso As Integer) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.Cabecera(fecha, curso)
        Return tabla
    End Function
    <WebMethod()>
    Public Function CabeceraMensual(ByVal mes_final As Date) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.CabeceraMensual(mes_final)
        Return tabla
    End Function
    <WebMethod()>
    Public Function GetNameMensual(ByVal curso_dos As Integer, ByVal mes_final As String, ByVal mes_number As Integer) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.GetNameMensual(curso_dos, mes_final, mes_number)
        Return tabla
    End Function
    <WebMethod()>
    Public Function AsistenciaMensualDos(ByVal curso_dos As Integer, ByVal mes_number As Integer) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.AsistenciaMensualDos(curso_dos, mes_number)
        Return tabla
    End Function
    <WebMethod()>
    Public Function GetCondicion(ByVal ORP As Integer, ByVal fecha As String) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.GetCondicion(ORP, fecha)
        Return tabla
    End Function
    <WebMethod()>
    Public Function ObtenerFecha(ByVal nColumnas As Integer, ByVal curso_dos As Integer, ByVal mes_final As Date) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.ObtenerFecha(nColumnas, curso_dos, mes_final)
        Return tabla
    End Function
    <WebMethod()>
    Public Function MostrarDe(ByVal nColumnas As Integer, ByVal curso_dos As Integer) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = asistencia.MostrarDe(nColumnas, curso_dos)
        Return tabla
    End Function

    <WebMethod()>
    Public Function InsertAsistencia(ByVal orp As Integer, ByVal fecha As Date,
                                     ByVal AsistenciaEstado As Integer, ByVal RoleAttenceId As Integer, ByVal cordenadas As String
                                    ) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = asistencia.InsertAsistencia(orp, fecha, AsistenciaEstado, RoleAttenceId, cordenadas)
        Return tabla
    End Function
    <WebMethod()>
    Public Function UpdateAsistencia(ByVal orp As Integer, ByVal fecha As Date, ByVal AsistenciaEstado As Integer, ByVal cordenadas As String) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = asistencia.UpdateAsistencia(orp, fecha, AsistenciaEstado, cordenadas)
        Return tabla
    End Function
    <WebMethod()>
    Public Function Condicion(ByVal cont2 As String) As String
        Dim asistencia As cls_Asistencia = New cls_Asistencia()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        tabla = asistencia.Condicion(cont2)
        Return tabla
    End Function
End Class