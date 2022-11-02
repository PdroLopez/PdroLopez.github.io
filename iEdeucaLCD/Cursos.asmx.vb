Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Negocios
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Cursos
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function IngresarCurso(ByVal modalidad As Integer, ByVal Jornada As Integer,
                                 ByVal Nivel As String, ByVal Rama As Integer,
                                   ByVal Sector As String, ByVal Especialidad As String,
                                  ByVal Enseñanza As String, ByVal TipoCurso As Integer,
                                  ByVal Grado As Integer, ByVal id_colegio As Integer, ByVal Letra As String
                                  ) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = curso.IngresarCurso(modalidad, Jornada, Nivel, Rama, Sector, Especialidad, Enseñanza, TipoCurso, Grado, id_colegio, Letra)
        Return ds
    End Function
    <WebMethod()>
    Public Function TablaHorario(ByVal CursoId As Integer) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = curso.TablaHorario(CursoId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EditarCurso(ByVal idCurso As Integer, ByVal idModalidad As Integer,
                                 ByVal idJornada As Integer, ByVal idNivel As Integer,
                                   ByVal idRama As Integer, ByVal idSector As Integer,
                                  ByVal idEspecialidad As Integer, ByVal idTipoEnseñanza As Integer,
                                  ByVal idTipoCurso As Integer, ByVal idGrado As Integer, ByVal Letra As String,
                                ByVal modalidad As Integer, ByVal Jornada As Integer,
                                 ByVal Nivel As String, ByVal Rama As Integer,
                                   ByVal Sector As String, ByVal Especialidad As String,
                                  ByVal Enseñanza As String, ByVal TipoCurso As Integer,
                                  ByVal Grado As Integer
                                ) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = curso.EditarCurso(idCurso, idModalidad,
                               idJornada, idNivel,
                               idRama, idSector,
                               idEspecialidad, idTipoEnseñanza,
                               idTipoCurso, idGrado,
                               Letra, modalidad,
                               Jornada, Nivel,
                               Rama, Sector,
                               Especialidad, Enseñanza,
                               TipoCurso, Grado)
        Return ds
    End Function
    <WebMethod()>
    Public Function IngresarCalendario(ByVal inicio As DateTime, ByVal fin As DateTime,
                                   ByVal asignatura As Integer, ByVal dias As Integer) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso.IngresarCalendario(inicio, fin, asignatura, dias)
        Return ds
    End Function
    <WebMethod()>
    Public Function MostrarCursos(ByVal colegio As Integer) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso.MostrarCursos(colegio)
        Return ds
    End Function
    <WebMethod()>
    Public Function Validacion(ByVal Letra As String) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso.Validacion(Letra)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectProfesor(ByVal ColegioID As Integer) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso.SelectProfesor(ColegioID)
        Return ds
    End Function
    <WebMethod()>
    Public Function MostrarHorario(ByVal curso As Integer) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.MostrarHorario(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function ExisteHorario(ByVal curso As Integer) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.ExisteHorario(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectAsignatura(ByVal curso As Integer) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.SelectAsignatura(curso)
        Return ds
    End Function
    <WebMethod()>
    Public Function SelectAsignaturaK(ByVal curso_id As Integer) As String
        Dim curso As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = curso.SelectAsignaturaK(curso_id)
        Return ds
    End Function
    <WebMethod()>
    Public Function AsignarProfesorAsignatura(ByVal curso As Integer,
                                              ByVal asignatura As Integer,
                                              ByVal profesor As Integer) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.AsignarProfesorAsignatura(curso, asignatura, profesor)
        Return ds
    End Function

    <WebMethod()>
    Public Function MostrarAsignaturaProfesor(ByVal curso As Integer
                                            ) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.MostrarAsignaturaProfesor(curso)
        Return ds
    End Function

    <WebMethod()>
    Public Function IngresarCalendario() As String
        'Dim calendar As cls_Calendar = New cls_Calendar()
        Dim ds As String
        ds = ""
        'ds = calendar.IngresarCalendario(strAsignaturas)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetModalidadEdit(ByVal modalidad As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetModalidadEdit(modalidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetJornadaEdit(ByVal jornada As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetJornadaEdit(jornada)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetNivelEdit(ByVal nivel As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetNivelEdit(nivel)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetTipoCursoEdit(ByVal tipo_curso As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetTipoCursoEdit(tipo_curso)
        Return ds
    End Function


    <WebMethod()>
    Public Function GetTipoEnseñanzaEdit(ByVal tipo_enseñanza As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetTipoEnseñanzaEdit(tipo_enseñanza)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetGRadoEdit(ByVal grado As String, ByVal input_t_enseñanza As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetGRadoEdit(grado, input_t_enseñanza)
        Return ds
    End Function

    <WebMethod()>
    Public Function ChangeTipoEnseñanza(ByVal nivel_input As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.ChangeTipoEnseñanza(nivel_input)
        Return ds
    End Function
    <WebMethod()>
    Public Function ChangeGrado(ByVal input_t_enseñanza As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.ChangeGrado(input_t_enseñanza)
        Return ds
    End Function




    <WebMethod()>
    Public Function GetRamaEdit(ByVal rama As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetRamaEdit(rama)
        Return ds
    End Function

    <WebMethod()>
    Public Function GetSectorEdit(ByVal sector As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetSectorEdit(sector)
        Return ds
    End Function
    <WebMethod()>
    Public Function GetEspecialidadEdit(ByVal especialidad As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.GetEspecialidadEdit(especialidad)
        Return ds
    End Function
    <WebMethod()>
    Public Function ChangeSector(ByVal rama_input As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.ChangeSector(rama_input)
        Return ds
    End Function
    <WebMethod()>
    Public Function ChangeEspecialidad(ByVal sector_input As String) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.ChangeEspecialidad(sector_input)
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarCurso(ByVal curso As Integer) As String
        Dim curso_ As cls_Curso = New cls_Curso()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = curso_.EliminarCurso(curso)
        Return ds
    End Function


End Class