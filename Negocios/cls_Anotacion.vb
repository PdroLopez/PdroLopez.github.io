Imports System.Drawing
Imports System.IO
Imports Datos
Public Class cls_Anotacion
    Public Function GetAsignatura(ByVal curso As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Bloque") : ValParam.Add("Get Asignatura")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function IngresarAnotacion(ByVal EstudianteId As String, ByVal fecha As String, ByVal puntaje As String, ByVal detalle As String,
                                       ByVal curso As Integer, ByVal asignatura As Integer, ByVal docente As Integer,
                                       ByVal ambito As Integer, ByVal caracter As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String = "No hay datos para mostrar"
        'If (id > 0) Then
        '	NomParam.Add("@Bloque") : ValPara1m.Add("Update Asignatura")
        '	NomParam.Add("@AsignaturaId") : ValParam.Add(id)
        'Else
        '	NomParam.Add("@Bloque") : ValParam.Add("Insert Asignatura")
        'End If
        NomParam.Add("@Bloque") : ValParam.Add("IngresarAnotacion")
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        NomParam.Add("@Docente") : ValParam.Add(docente)
        NomParam.Add("@EstudianteId") : ValParam.Add(EstudianteId)
        NomParam.Add("@Fecha") : ValParam.Add(fecha)
        NomParam.Add("@AmbitoId") : ValParam.Add(ambito)
        NomParam.Add("@CaracterId") : ValParam.Add(caracter)
        NomParam.Add("@Puntaje") : ValParam.Add(puntaje)
        NomParam.Add("@Detalle") : ValParam.Add(detalle)
        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function IngresarIncident(ByVal EstudianteId As String, ByVal hora As String, ByVal momento_incidente As Integer,
                                      ByVal detalle As String, ByVal tipo_incidente As Integer, ByVal rol_incidente As Integer,
                                     ByVal uso_arma As Integer, ByVal costo_asociado As Integer, ByVal fecha_inicial_d As Date,
                                     ByVal fecha_fin_d As Date, ByVal explusacion_anio_completo As Integer, ByVal expulsacion_medio_anio As Integer,
                                    ByVal ambito As Integer,
                                     ByVal caracter As Integer, ByVal fecha As Date, ByVal puntaje As String, ByVal concencuencias_disciplinarias As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String = "No hay datos para mostrar"
        'If (id > 0) Then
        '	NomParam.Add("@Bloque") : ValPara1m.Add("Update Asignatura")
        '	NomParam.Add("@AsignaturaId") : ValParam.Add(id)
        'Else
        '	NomParam.Add("@Bloque") : ValParam.Add("Insert Asignatura")
        'End If
        'INSERT Incident(IncidentDate, IncidentTime, RefIncidentTimeDescriptionCodeId,
        '		RefIncidentBehaviorId, RefWeaponTypeId, IncidentCost, IncidentDescription) 
        '		VALUES(@IncidentDate,@IncidentTime,@RefIncidentTimeDescriptionCodeId,@RefIncidentBehaviorId,@RefWeaponTypeId,
        '		@IncidentCost,@IncidentDescription)
        NomParam.Add("@Bloque") : ValParam.Add("IngresarAnotacion")
        NomParam.Add("@EstudianteId") : ValParam.Add(EstudianteId)
        NomParam.Add("@IncidentTime") : ValParam.Add(hora)
        NomParam.Add("@RefIncidentTimeDescriptionCodeId") : ValParam.Add(momento_incidente)
        NomParam.Add("@IncidentDescription") : ValParam.Add(detalle)
        NomParam.Add("@RefIncidentBehaviorId") : ValParam.Add(tipo_incidente)
        NomParam.Add("@RefIncidentPersonRoleTypeId") : ValParam.Add(rol_incidente)
        NomParam.Add("@RefWeaponTypeId") : ValParam.Add(uso_arma)
        NomParam.Add("@IncidentCost") : ValParam.Add(costo_asociado)
        NomParam.Add("@RefDisciplinaryActionTakenId") : ValParam.Add(concencuencias_disciplinarias)

        NomParam.Add("@DisciplinaryActionStartDate") : ValParam.Add(fecha_inicial_d)
        NomParam.Add("@DisciplinaryActionEndDate") : ValParam.Add(fecha_fin_d)
        NomParam.Add("@FullYearExpulsion") : ValParam.Add(explusacion_anio_completo)
        NomParam.Add("@ShortenedExpulsion") : ValParam.Add(expulsacion_medio_anio)
        NomParam.Add("@AmbitoId") : ValParam.Add(ambito)
        NomParam.Add("@CaracterId") : ValParam.Add(caracter)
        NomParam.Add("@IncidentDate") : ValParam.Add(fecha)
        NomParam.Add("@Puntaje") : ValParam.Add(puntaje)

        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function EditarIncident(ByVal EstudianteId As String, ByVal hora As String, ByVal momento_incidente As Integer,
                                      ByVal detalle As String, ByVal tipo_incidente As Integer, ByVal rol_incidente As Integer,
                                     ByVal uso_arma As Integer, ByVal costo_asociado As Integer, ByVal fecha_inicial_d As Date,
                                     ByVal fecha_fin_d As Date, ByVal explusacion_anio_completo As Integer, ByVal expulsacion_medio_anio As Integer,
                                    ByVal ambito As Integer,
                                     ByVal caracter As Integer, ByVal fecha As Date, ByVal puntaje As String, ByVal concencuencias_disciplinarias As Integer,
                                   ByVal AnotacionesId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String = "No hay datos para mostrar"
        'If (id > 0) Then
        '	NomParam.Add("@Bloque") : ValPara1m.Add("Update Asignatura")
        '	NomParam.Add("@AsignaturaId") : ValParam.Add(id)
        'Else
        '	NomParam.Add("@Bloque") : ValParam.Add("Insert Asignatura")
        'End If
        'INSERT Incident(IncidentDate, IncidentTime, RefIncidentTimeDescriptionCodeId,
        '		RefIncidentBehaviorId, RefWeaponTypeId, IncidentCost, IncidentDescription) 
        '		VALUES(@IncidentDate,@IncidentTime,@RefIncidentTimeDescriptionCodeId,@RefIncidentBehaviorId,@RefWeaponTypeId,
        '		@IncidentCost,@IncidentDescription)
        NomParam.Add("@Bloque") : ValParam.Add("EditarIncident")
        NomParam.Add("@EstudianteId") : ValParam.Add(EstudianteId)
        NomParam.Add("@IncidentTime") : ValParam.Add(hora)
        NomParam.Add("@RefIncidentTimeDescriptionCodeId") : ValParam.Add(momento_incidente)
        NomParam.Add("@IncidentDescription") : ValParam.Add(detalle)
        NomParam.Add("@RefIncidentBehaviorId") : ValParam.Add(tipo_incidente)
        NomParam.Add("@RefIncidentPersonRoleTypeId") : ValParam.Add(rol_incidente)
        NomParam.Add("@RefWeaponTypeId") : ValParam.Add(uso_arma)
        NomParam.Add("@IncidentCost") : ValParam.Add(costo_asociado)
        NomParam.Add("@RefDisciplinaryActionTakenId") : ValParam.Add(concencuencias_disciplinarias)

        NomParam.Add("@DisciplinaryActionStartDate") : ValParam.Add(fecha_inicial_d)
        NomParam.Add("@DisciplinaryActionEndDate") : ValParam.Add(fecha_fin_d)
        NomParam.Add("@FullYearExpulsion") : ValParam.Add(explusacion_anio_completo)
        NomParam.Add("@ShortenedExpulsion") : ValParam.Add(expulsacion_medio_anio)
        NomParam.Add("@AmbitoId") : ValParam.Add(ambito)
        NomParam.Add("@CaracterId") : ValParam.Add(caracter)
        NomParam.Add("@IncidentDate") : ValParam.Add(fecha)
        NomParam.Add("@Puntaje") : ValParam.Add(puntaje)
        NomParam.Add("@IncidentId") : ValParam.Add(AnotacionesId)

        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function


    Public Function EditarAnotacion(ByVal EstudianteId As String, ByVal fecha As Date, ByVal puntaje As String, ByVal detalle As String,
                                      ByVal curso As Integer, ByVal asignatura As Integer, ByVal docente As Integer,
                                      ByVal ambito As Integer, ByVal caracter As Integer, ByVal AnotacionesId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String = "No hay datos para mostrar"
        'If (id > 0) Then
        '	NomParam.Add("@Bloque") : ValPara1m.Add("Update Asignatura")
        '	NomParam.Add("@AsignaturaId") : ValParam.Add(id)
        'Else
        '	NomParam.Add("@Bloque") : ValParam.Add("Insert Asignatura")
        'End If
        NomParam.Add("@Bloque") : ValParam.Add("EditarAnotacion")
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        NomParam.Add("@Docente") : ValParam.Add(docente)
        NomParam.Add("@EstudianteId") : ValParam.Add(EstudianteId)
        NomParam.Add("@Fecha2") : ValParam.Add(fecha)
        NomParam.Add("@AmbitoId") : ValParam.Add(ambito)
        NomParam.Add("@CaracterId") : ValParam.Add(caracter)
        NomParam.Add("@Puntaje") : ValParam.Add(puntaje)
        NomParam.Add("@Detalle") : ValParam.Add(detalle)
        NomParam.Add("@AnotacionesId") : ValParam.Add(AnotacionesId)
        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function

    Public Function SelectAmbito() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("SelectAmbito")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function Puntaje() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("Puntaje")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= ds.Tables(0).Rows(i)("valor").ToString()
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function Ambito() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("Ambito")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= ds.Tables(0).Rows(i)("valor").ToString()
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function InsertRefIncidentTimeDescriptionCode(ByVal nombre As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Nombre") : ValParam.Add(nombre)
        NomParam.Add("@Bloque") : ValParam.Add("Insert RefIncidentTimeDescriptionCode")

        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."

    End Function
    Public Function SelectRefIncidentTimeDescriptionCode() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("SelectRefIncidentTimeDescriptionCode")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function InsertRefIncidentBehavior(ByVal nombre As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Nombre") : ValParam.Add(nombre)
        NomParam.Add("@Bloque") : ValParam.Add("InsertRefIncidentBehavior")

        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."

    End Function
    Public Function SelectRefIncidentBehavior() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("SelectRefIncidentBehavior")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function InsertRefDisciplinaryActionTaken(ByVal nombre As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Nombre") : ValParam.Add(nombre)
        NomParam.Add("@Bloque") : ValParam.Add("InsertRefDisciplinaryActionTaken")

        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."

    End Function
    Public Function SelectRefDisciplinaryActionTaken() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("SelectRefDisciplinaryActionTaken")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function SelectRefIncidentPersonRoleType() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("SelectRefIncidentPersonRoleType")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function GetAnotacion(ByVal EstudianteId As String, ByVal pt As Integer, ByVal pt2 As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = ""
        NomParam.Add("@EstudianteId") : ValParam.Add(EstudianteId)
        NomParam.Add("@Bloque") : ValParam.Add("GetAnotacion")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    'If pt = 0 And pt2 = 0 Then



                    If pt = 0 And pt2 = 0 Then
                        tabla &= "<tr>" &
                              "<td class='align-middle text-left' > " &
                                      "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "'>
																				   " & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
                                        "<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "'>
																					" & "<i class='fa fa-trash-alt'> </i>" & "</button>" &
                                "</td>" &
                               "<td id='perid" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "'>" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "</td>" &
                             "<td > " & ds.Tables(0).Rows(i)("Estudiante").ToString() & "</td>" &
                               "<td > " & ds.Tables(0).Rows(i)("IncidentDate").ToString() & "</td>" &
                              "<td > " & ds.Tables(0).Rows(i)("IncidentTime").ToString() & "</td>" &
                                "<td > " & ds.Tables(0).Rows(i)("IncidentDescription").ToString() & "</td>" &
                        "<td style='display:none;' > <input id='IncidentDate_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("IncidentDate").ToString() & "' />" & ds.Tables(0).Rows(i)("IncidentDate").ToString() & "</td>" &
                            "<td style='display:none;'>  <input id='RefIncidentTimeDescriptionCodeId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefIncidentTimeDescriptionCodeId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefIncidentTimeDescriptionCodeId").ToString() & "</td>" &
                               "<td style='display:none;' > <input id='IncidentDescription_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("IncidentDescription").ToString() & "' />" & ds.Tables(0).Rows(i)("IncidentDescription").ToString() & "</td>" &
                               "<td  style='display:none;'> <input id='RefIncidentBehaviorId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefIncidentBehaviorId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefIncidentBehaviorId").ToString() & "</td>" &
                            "<td style='display:none;' > <input id='RefIncidentPersonRoleTypeId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefIncidentPersonRoleTypeId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefIncidentPersonRoleTypeId").ToString() & "</td>" &
                            "<td > <input id='Puntaje_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("Puntaje").ToString() & "' />" & ds.Tables(0).Rows(i)("Puntaje").ToString() & "</td>" &
                            "<td style='display:none;'> <input id='RefDisciplinaryActionTakenId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefDisciplinaryActionTakenId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefDisciplinaryActionTakenId").ToString() & "</td>" &
                            "<td style='display:none;'> <input id='IncidentTime_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("IncidentTime").ToString() & "' />" & ds.Tables(0).Rows(i)("IncidentTime").ToString() & "</td>" &
                            "<td style='display:none;'> <input id='DisciplinaryActionStartDate_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("DisciplinaryActionStartDate").ToString() & "' />" & ds.Tables(0).Rows(i)("DisciplinaryActionStartDate").ToString() & "</td>" &
                            "<td style='display:none;'> <input id='DisciplinaryActionEndDate_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("DisciplinaryActionEndDate").ToString() & "' />" & ds.Tables(0).Rows(i)("DisciplinaryActionEndDate").ToString() & "</td>" &
                            "<td > <input id='ambitoId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("ambitoId").ToString() & "' />" & ds.Tables(0).Rows(i)("AmbitoString").ToString() & "</td>" &
                            "<td style='display:none;'> <input id='CaracterId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("CaracterId").ToString() & "' />" & ds.Tables(0).Rows(i)("CaracterId").ToString() & "</td>" &
                        "</tr>"
                    ElseIf pt = 1 And pt2 = 1 Then
                        tabla &= "<tr>" &
                          "<td class='align-middle text-left' > " &
                                  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "'>
																				   " & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
                                    "<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "'>
																					" & "<i class='fa fa-trash-alt'> </i>" & "</button>" &
                            "</td>" &
                           "<td id='perid" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "'>" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "</td>" &
                         "<td > " & ds.Tables(0).Rows(i)("Estudiante").ToString() & "</td>" &
                           "<td > " & ds.Tables(0).Rows(i)("IncidentDate").ToString() & "</td>" &
                          "<td > " & ds.Tables(0).Rows(i)("IncidentTime").ToString() & "</td>" &
                            "<td > " & ds.Tables(0).Rows(i)("IncidentDescription").ToString() & "</td>" &
                    "<td style='display:none;' > <input id='IncidentDate_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("IncidentDate").ToString() & "' />" & ds.Tables(0).Rows(i)("IncidentDate").ToString() & "</td>" &
                        "<td style='display:none;'>  <input id='RefIncidentTimeDescriptionCodeId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefIncidentTimeDescriptionCodeId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefIncidentTimeDescriptionCodeId").ToString() & "</td>" &
                           "<td style='display:none;' > <input id='IncidentDescription_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("IncidentDescription").ToString() & "' />" & ds.Tables(0).Rows(i)("IncidentDescription").ToString() & "</td>" &
                           "<td  style='display:none;'> <input id='RefIncidentBehaviorId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefIncidentBehaviorId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefIncidentBehaviorId").ToString() & "</td>" &
                        "<td style='display:none;' > <input id='RefIncidentPersonRoleTypeId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefIncidentPersonRoleTypeId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefIncidentPersonRoleTypeId").ToString() & "</td>" &
                        "<td   style='display:none;'> <input id='Puntaje_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("Puntaje").ToString() & "' />" & ds.Tables(0).Rows(i)("Puntaje").ToString() & "</td>" &
                        "<td style='display:none;'> <input id='RefDisciplinaryActionTakenId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("RefDisciplinaryActionTakenId").ToString() & "' />" & ds.Tables(0).Rows(i)("RefDisciplinaryActionTakenId").ToString() & "</td>" &
                        "<td style='display:none;'> <input id='IncidentTime_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("IncidentTime").ToString() & "' />" & ds.Tables(0).Rows(i)("IncidentTime").ToString() & "</td>" &
                        "<td style='display:none;'> <input id='DisciplinaryActionStartDate_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("DisciplinaryActionStartDate").ToString() & "' />" & ds.Tables(0).Rows(i)("DisciplinaryActionStartDate").ToString() & "</td>" &
                        "<td style='display:none;'> <input id='DisciplinaryActionEndDate_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("DisciplinaryActionEndDate").ToString() & "' />" & ds.Tables(0).Rows(i)("DisciplinaryActionEndDate").ToString() & "</td>" &
                        "<td  style='display:none;' > <input id='ambitoId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("ambitoId").ToString() & "' />" & ds.Tables(0).Rows(i)("ambitoId").ToString() & "</td>" &
                        "<td style='display:none;'> <input id='CaracterId_" & ds.Tables(0).Rows(i)("IncidentId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("CaracterId").ToString() & "' />" & ds.Tables(0).Rows(i)("CaracterId").ToString() & "</td>" &
                    "</tr>"
                    End If

                    'ElseIf pt = 1 And pt2 = 1 Then
                    '	tabla &= "<tr>" &
                    '		  "<td class='align-middle text-left' > " &
                    '				  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>
                    '                                           " & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
                    '					"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>
                    '                                            " & "<i class='fa fa-trash-alt'> </i>" & "</button>" &
                    '			"</td>" &
                    '		   "<td id='perid" & ds.Tables(0).Rows(i)("id").ToString() & "'>" & ds.Tables(0).Rows(i)("id").ToString() & "</td>" &
                    '		  "<td id='Fecha_" & ds.Tables(0).Rows(i)("id").ToString() & "'> <input id='fecha_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("fecha").ToString() & "' />" & ds.Tables(0).Rows(i)("fecha").ToString() & "</td>" &
                    '		   "<td id='Estudiante_" & ds.Tables(0).Rows(i)("id").ToString() & "'> <input id='alumno_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("AlumnoId").ToString() & "' />" & ds.Tables(0).Rows(i)("Estudiante").ToString() & "</td>" &
                    '		   "<td id='Docente_" & ds.Tables(0).Rows(i)("id").ToString() & "'> <input id='docente_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("DocenteId").ToString() & "' />" & ds.Tables(0).Rows(i)("Docente").ToString() & "</td>" &
                    '		"<td id='Caracter_" & ds.Tables(0).Rows(i)("id").ToString() & "'> <input id='caracter_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("caracterId").ToString() & "' />" & ds.Tables(0).Rows(i)("Caracter").ToString() & "</td>" &
                    '		"<td id='Detalle_" & ds.Tables(0).Rows(i)("id").ToString() & "'> <input id='detalle_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("detalle").ToString() & "' />" & ds.Tables(0).Rows(i)("detalle").ToString() & "</td>" &
                    '		"</tr>"

                    'End If


                Next
            End If

        End If

        Return tabla
    End Function
    Public Function EliminarAmbito(ByVal AmbitoId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        NomParam.Add("@Bloque") : ValParam.Add("EliminarIncident")
        NomParam.Add("@IncidentId") : ValParam.Add(AmbitoId)
        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 155 fue ejecutado con éxito."



    End Function
    Public Function SelectCaracter() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Bloque") : ValParam.Add("SelectCaracter")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function GetDocente(ByVal asignatura As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        NomParam.Add("@Bloque") : ValParam.Add("GetDocente")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'> " & ds.Tables(0).Rows(i)("Profesor").ToString() & "" & "</option>"
                Next
            End If

        End If

        Return tabla

    End Function
    Public Function GetEstudiante(ByVal curso As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        Dim tabla As String = ""
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Bloque") : ValParam.Add("GetEstudiante")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<div class='form-check'> " &
                    "<input type='checkbox' name='nombre_estudiante'  data='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' class='form-check-input btn_prueba' id='nombre_" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' value='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'>" &
                    "<label class='form-check-label'>" & ds.Tables(0).Rows(i)("estudiante").ToString() &
                    "</label> " & "</div><br>"
                Next
            End If

        End If

        Return tabla
    End Function
End Class


