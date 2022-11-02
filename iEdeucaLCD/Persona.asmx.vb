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
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Persona1
    Inherits System.Web.Services.WebService
    Dim person As New Persona
    Dim respuesta As New cls_CodigosRespuesta
    <WebMethod()>
    Public Function IngresarPersona(ByVal strEditado As String,
                                    ByVal rut As String, ByVal strEliminado As String, ByVal strFonos As String,
                                    ByVal strCorreoEditado As String,
                                    ByVal strCorreoEliminado As String, ByVal strCorreos As String,
                                    ByVal primerNombre As String, ByVal segundoNombre As String,
                                     ByVal ApellidoMaterno As String, ByVal ApellidoPaterno As String,
                                    ByVal f_nacimiento As Date, ByVal sexo_referencia_id As Integer, ByVal rol As Integer, ByVal curso As Integer,
                                     ByVal estudiante As Integer, ByVal ColegioId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim Datos As String
        Datos = ""
        Datos = persona.GuardarPersona(strEditado, rut, strEliminado,
                                       strFonos, strCorreoEditado, strCorreoEliminado,
                                       strCorreos, primerNombre, segundoNombre,
                                       ApellidoMaterno, ApellidoPaterno, f_nacimiento,
                                       sexo_referencia_id, rol, curso, estudiante, ColegioId)

        Return Datos


    End Function
    <WebMethod()>
    Public Function BuscarRut(ByVal rut As String) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim Datos As String
        Datos = ""
        Datos = persona.BuscarRut(rut)
        Return Datos


    End Function
    <WebMethod()>
    Public Function BuscarIdPerson(ByVal rut As String) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim Datos As String
        Datos = ""
        Datos = persona.BuscarIdPerson(rut)
        Return Datos


    End Function
    <WebMethod()>
    Public Function RefPersonRelationShip() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = persona.RefPersonRelationShip()
        Return ds

    End Function
    <WebMethod()>
    Public Function GetCurso() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.GetCurso()
        Return ds
    End Function
    <WebMethod()>
    Public Function SeleccionarPersona(ByVal tipo_persona As Integer, ByVal ColegioId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.SeleccionarPersona(tipo_persona, ColegioId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function SeleccionarPersonaTipo(ByVal tipo_persona As Integer, ByVal ColegioId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.SeleccionarPersonaTipo(tipo_persona, ColegioId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function getApoderado(ByVal estudiante As Integer, ByVal ColegioId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.getApoderado(estudiante, ColegioId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function SeleccionarPersonaApoderado(ByVal estudiante As Integer, ByVal tipo_persona As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.SeleccionarPersonaApoderado(estudiante, tipo_persona)
        Return tabla
    End Function
    <WebMethod()>
    Public Function SelectEstudiante(ByVal curso As Integer, ByVal ColegioId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.SelectEstudiante(curso, ColegioId)
        Return tabla
    End Function
    <WebMethod()>
    Public Function SearchCurso(ByVal curso As Integer, ByVal ColegioId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = persona.SearchCurso(curso, ColegioId)
        Return tabla
    End Function
    '<WebMethod()>
    'Public Function BuscarPersona(ByVal PersonId As Integer) As String
    '    Dim persona As cls_Persona = New cls_Persona()
    '    Dim tabla As String

    '    Dim i As Integer
    '    i = 0

    '    tabla = persona.BuscarPersona(PersonId)
    '    Return tabla
    'End Function
    <WebMethod()>
    Public Function EditarPersona(ByVal PersonId As Integer, ByVal strEditado As String,
                                    ByVal rut As String, ByVal strEliminado As String, ByVal strFonos As String,
                                    ByVal strCorreoEditado As String,
                                    ByVal strCorreoEliminado As String, ByVal strCorreos As String,
                                    ByVal primerNombre As String, ByVal segundoNombre As String,
                                     ByVal ApellidoMaterno As String, ByVal ApellidoPaterno As String,
                                    ByVal f_nacimiento As Date, ByVal sexo_referencia_id As Integer, ByVal rol As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim Datos As String
        Datos = persona.EditarPersona(PersonId, strEditado, rut, strEliminado,
                                       strFonos, strCorreoEditado, strCorreoEliminado,
                                       strCorreos, primerNombre, segundoNombre,
                                       ApellidoMaterno, ApellidoPaterno, f_nacimiento,
                                       sexo_referencia_id, rol)






        Return Datos
    End Function
    <WebMethod()>
    Public Function EliminarPersona(ByVal PersonId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String

        ds = persona.EliminarPersona(PersonId)
        Return ds
    End Function
    <WebMethod()>
    Public Function EliminarTelefono(ByVal PersonTelephoneId As Integer) As String
        'Dim persona As cls_Persona = New cls_Persona()
        'Dim tabla As String
        'tabla = "NADA!"
        'Dim ds As String
        'ds = persona.EliminarTelefono(PersonId)
        'Return ds
        Return PersonTelephoneId.ToString()
    End Function
    <WebMethod()>
    Public Function SelectSex() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = persona.SelectSex()
        Return ds


    End Function
    <WebMethod()>
    Public Function SelectTipoPersona() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = persona.SelectTipoPersona()
        Return ds


    End Function
    <WebMethod()>
    Public Function SelectUS() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        ds = persona.SelectUS()
        Return ds


    End Function
    <WebMethod()>
    Public Function SelectTipoVisa() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.SelectTipoVisa()
        Return ds


    End Function
    <WebMethod()>
    Public Function SelectEstadoResidencia() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.SelectEstadoResidencia()
        Return ds


    End Function
    <WebMethod()>
    Public Function SelectComprobanteResidencia() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.SelectComprobanteResidencia()
        Return ds


    End Function
    <WebMethod()>
    Public Function NivelEducacion() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.NivelEducacion()
        Return ds


    End Function
    <WebMethod()>
    Public Function VerificacionPersonal() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.VerificacionPersonal()
        Return ds


    End Function
    <WebMethod()>
    Public Function AfiliacionTribal() As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.AfiliacionTribal()
        Return ds


    End Function
    <WebMethod()>
    Public Function GetLastID() As String

        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.GetLastID()
        Return ds
    End Function
    <WebMethod()>
    Public Function GuardarTelefono(strFono As String) As String

        Dim a As String
        a = "strFono " + ": " + strFono
        'Dim persona As cls_Persona = New cls_Persona()
        'Dim tabla As String
        'tabla = "NADA!"
        'Dim ds As String
        'Dim i As Integer
        'i = 0
        'ds = persona.GuardarTelefono(PersonId, Data, tipo_numero, IndicadorNumero)
        'Return ds
        Return a
    End Function
    <WebMethod()>
    Public Function EditarTelefono(ByVal PersonId As Integer, ByVal data As String, ByVal tipo_numero As Integer, ByVal IndicadorNumero As Integer) As String

        Dim persona As cls_Persona = New cls_Persona()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0
        ds = persona.EditarTelefono(PersonId, data, tipo_numero, IndicadorNumero)
        Return ds
    End Function
    <WebMethod()>
    Public Function BuscarTelefono(ByVal PersonId As Integer) As String
        Dim persona As cls_Persona = New cls_Persona()
        Dim ds As String
        ds = persona.BuscarTelefono(PersonId)
        Return ds


    End Function
End Class