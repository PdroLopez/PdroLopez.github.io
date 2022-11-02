Imports System.ComponentModel
Imports System.Web.Services
Imports Negocios
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Organzacion
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function IngresarCurso(ByVal letra As String, ByVal tipo_organizacion As Integer) As String
        Dim curso As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = curso.GuardarCurso(letra, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarCursos(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarCursos(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarAsignatura(ByVal asignatura As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarAsignatura(asignatura, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarAsignatura(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarAsignatura(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarJornada(ByVal jornada As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarJornada(jornada, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarJornada(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarJornada(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarTipoEnseñanza(ByVal tipoEnseñanza As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarTipoEnseñanza(tipoEnseñanza, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarTipoEnseñanza(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarTipoEnseñanza(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarEspecialidad(ByVal especialidad As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarEspecialidad(especialidad, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarEspecialidad(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarEspecialidad(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarModalidad(ByVal modalidad As String, ByVal nombre_corto As String) As String
        Dim modalidad_ As cls_Organizacion = New cls_Organizacion()
        'Dim idColegio As Integer
        Dim Datos As String
        Dim vall As String
        'vall = Session("ID_Colegio")
        'vall.ToString()
        Datos = "dfjkdlf"
        'idColegio = Session("ID_Colegio")
        'Datos = modalidad_.IngresarModalidad(modalidad, nombre_corto, idColegio)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarModalidad() As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarModalidad()
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarNivelEducacion(ByVal nivelEducacion As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarNivelEducacion(nivelEducacion, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarNivelEducacion(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarNivelEducacion(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarRamaEspecialidad(ByVal rama As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarRamaEspecialidad(rama, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarRamaEspecialidad(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarRamaEspecialidad(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarSector(ByVal sector As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarSector(sector, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarSector(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarSector(tipo_organizacion)
        Return tabla

    End Function
    <WebMethod()>
    Public Function IngresarTipoCurso(ByVal tipoCurso As String, ByVal tipo_organizacion As Integer) As String
        Dim asignatura_ As cls_Organizacion = New cls_Organizacion()
        Dim Datos As String
        Datos = asignatura_.IngresarTipoCurso(tipoCurso, tipo_organizacion)
        Return Datos
    End Function
    <WebMethod()>
    Public Function MostrarTipoCurso(ByVal tipo_organizacion As Integer) As String
        Dim org As cls_Organizacion = New cls_Organizacion()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = org.MostrarTipoCurso(tipo_organizacion)
        Return tabla

    End Function
End Class