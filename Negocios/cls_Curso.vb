Imports Datos
Public Class cls_Curso
	Private CourseId As Integer
	Private OrganizationId As Integer
	Private Description As String
	Private SubjectAbbreviation As String
	Private SCEDSequenceOfCourse As String
	Private InstructionalMinutes As Integer
	Private RefCourseLevelCharacteristicsId As Integer
	Private RefCourseCreditUnitId As Integer
	Private CreditValue As Decimal
	Private RefInstructionLanguage As Integer
	Private CertificationDescription As String
	Private RefCourseApplicableEducationLevelId As Integer
	Private RepeatabilityMaximumNumber As Integer
	Public Property _CourseId As Integer
	Public Property _OrganizationId As Integer
	Public Property _Description As String
	Public Property _SubjectAbbreviation As String
	Public Property _SCEDSequenceOfCourse As String
	Public Property _InstructionalMinutes As Integer
	Public Property _RefCourseLevelCharacteristicsId As Integer
	Public Property _RefCourseCreditUnitId As Integer
	Public Property _CreditValue As Decimal
	Public Property _RefInstructionLanguage As Integer
	Public Property _CertificationDescription As String
	Public Property _RefCourseApplicableEducationLevelId As Integer
	Public Property _RepeatabilityMaximumNumber As Integer
	Public Function Validacion(ByVal Letra As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Letra") : ValParam.Add(Letra)
		NomParam.Add("@Bloque") : ValParam.Add("Course Validacion")

		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla = ds.Tables(0).Rows(i)("existe").ToString()
				Next
			End If

		End If

		Return tabla
	End Function
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
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@idCurso") : ValParam.Add(idCurso)
		NomParam.Add("@idModalidad") : ValParam.Add(idModalidad)
		NomParam.Add("@idJornada") : ValParam.Add(idJornada)
		NomParam.Add("@idNivel") : ValParam.Add(idNivel)

		NomParam.Add("@idRama") : ValParam.Add(idRama)
		NomParam.Add("@idSector") : ValParam.Add(idSector)
		NomParam.Add("@idEspecialidad") : ValParam.Add(idEspecialidad)
		NomParam.Add("@idTipoEnseñanza") : ValParam.Add(idTipoEnseñanza)
		NomParam.Add("@idTipoCurso") : ValParam.Add(idTipoCurso)
		NomParam.Add("@idGrado") : ValParam.Add(idGrado)
		NomParam.Add("@Letra") : ValParam.Add(Letra)

		NomParam.Add("@Modalidad") : ValParam.Add(modalidad)
		NomParam.Add("@Jornada") : ValParam.Add(Jornada)
		NomParam.Add("@Nivel") : ValParam.Add(Nivel)
		NomParam.Add("@Rama") : ValParam.Add(Rama)
		NomParam.Add("@Sector") : ValParam.Add(Sector)
		NomParam.Add("@Especialidad") : ValParam.Add(Especialidad)
		NomParam.Add("@Enseñanza") : ValParam.Add(Enseñanza)
		NomParam.Add("@TipoCurso") : ValParam.Add(TipoCurso)
		NomParam.Add("@Grado") : ValParam.Add(Grado)
		NomParam.Add("@Bloque") : ValParam.Add("Course Update")




		consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function




	Public Function IngresarCurso(ByVal modalidad As Integer, ByVal Jornada As Integer,
								 ByVal Nivel As String, ByVal Rama As Integer,
								   ByVal Sector As String, ByVal Especialidad As String,
								  ByVal Enseñanza As String, ByVal TipoCurso As Integer,
								  ByVal Grado As Integer, ByVal id_colegio As Integer, ByVal Letra As String
								) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Modalidad") : ValParam.Add(modalidad)
		NomParam.Add("@Jornada") : ValParam.Add(Jornada)
		NomParam.Add("@Nivel") : ValParam.Add(Nivel)
		NomParam.Add("@Rama") : ValParam.Add(Rama)
		NomParam.Add("@Sector") : ValParam.Add(Sector)
		NomParam.Add("@Especialidad") : ValParam.Add(Especialidad)
		NomParam.Add("@Enseñanza") : ValParam.Add(Enseñanza)
		NomParam.Add("@TipoCurso") : ValParam.Add(TipoCurso)
		NomParam.Add("@Grado") : ValParam.Add(Grado)
		NomParam.Add("@id_colegio") : ValParam.Add(id_colegio)
		NomParam.Add("@Letra") : ValParam.Add(Letra)
		NomParam.Add("@Bloque") : ValParam.Add("Course Insert")
		consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function EliminarCurso(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta
		Dim tabla As String = "No hay datos para mostrar"





		NomParam.Add("@Bloque") : ValParam.Add("Eliminar Curso")

		NomParam.Add("@select_curso") : ValParam.Add(curso)
		consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		Return mensaje.GetTextCode(155)
	End Function

	Public Function MostrarCursos(ByVal colegio As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Course Select all")
		NomParam.Add("@id_colegio") : ValParam.Add(colegio)


		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					Dim idCurso As String = ds.Tables(0).Rows(i)("IDCurso").ToString()
					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "" &
										"<button  class='btn btn-sm btn-icon btn-secundary  btn_asignar_asignatura' id='" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & "<i class='fas fa-book-reader'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_calendario' id='" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & "<i class='fa fa-calendar'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "</td>" &
										"<td id='course" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Curso").ToString() & "</td>" &
										"<td id='TipoEnsenanza" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("TipoEnsenanza").ToString() & "</td>" &
										"<td id='TipoCurso" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("TipoCurso").ToString() & "</td>" &
										"<td id='Letra" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Letra").ToString() & "</td>" &
										"<td id='Especialidad" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Especialidad").ToString() & "</td>" &
										"<td id='Sector" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Sector").ToString() & "</td>" &
										"<td id='Rama" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Rama").ToString() & "</td>" &
										"<td id='Nivel" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Nivel").ToString() & "</td>" &
										"<td id='Jornada" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Jornada").ToString() & "</td>" &
										"<td id='Modalidad" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Modalidad").ToString() & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_modalidad" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' value='" & ds.Tables(0).Rows(i)("name_modalidad").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'  style='display:none;'>" & "<input type='hidden' id='name_jornada" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' value='" & ds.Tables(0).Rows(i)("Jornada").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_nivel" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' value='" & ds.Tables(0).Rows(i)("Nivel").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_rama" & idCurso & "' value='" & ds.Tables(0).Rows(i)("Rama").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_sector" & idCurso & "'  value='" & ds.Tables(0).Rows(i)("Sector").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_especialidad" & idCurso & "'  value='" & ds.Tables(0).Rows(i)("Especialidad").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_tipo_curso" & idCurso & "'  value='" & ds.Tables(0).Rows(i)("TipoCurso").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_enseñanza" & idCurso & "'  value='" & ds.Tables(0).Rows(i)("TipoEnsenanza").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_grado" & idCurso & "'  value='" & ds.Tables(0).Rows(i)("name_grado").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='name_letra'" & idCurso & "' value='" & ds.Tables(0).Rows(i)("Letra").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idModalidad_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idModalidad").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idJornada_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idJornada").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idNivel_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idNivel").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'  style='display:none;' >" & "<input type='hidden' id='idRama_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idRama").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;' >" & "<input type='hidden' id='idSector_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idSector").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idEspecialidad_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idEspecialidad").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idTipoCurso_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idTipoCurso").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idTipoEnseñanza_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idTipoEnsenanza").ToString() & "'</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='idGrado_" & idCurso & "' value='" & ds.Tables(0).Rows(i)("idGrado").ToString() & "'</td>" &
					"</tr>"

					'"<td id='Profesor" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>" &
					'"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'>" & ds.Tables(0).Rows(i)("Profesor").ToString() & "</td>" &
					'"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='PersonId' value='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'</td>" &

					'"<td id='Modalidad" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateModalidad").ToString() & "</td>" &
					'					"<td id='Jornada" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateJornada").ToString() & "</td>" &
					'					"<td id='Nivel" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateNivel").ToString() & "</td>" &
					'					"<td id='Rama" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateRama").ToString() & "</td>" &
					'					"<td id='Sector" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateSector").ToString() & "</td>" &
					'					"<td id='Especialidad" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateEspecialidad").ToString() & "</td>" &
					'					"<td id='TipoCurso" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateTipoCurso").ToString() & "</td>" &
					'					"<td id='Enseñanza" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateEnseñanza").ToString() & "</td>" &
					'					"<td id='Grado" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("updateGrado").ToString() & "</td>" &
					'					"<td id='Letra" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Letra").ToString() & "</td>" &
					'					"<td id='aux_sector" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='hidden_sector' value='" & ds.Tables(0).Rows(i)("updateSector").ToString() & "'/>" & "</td>" &
					'					"<td id='aux_enseñanza" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "' style='display:none;'>" & "<input type='hidden' id='hidden_enseñanza' value='" & ds.Tables(0).Rows(i)("updateEnseñanza").ToString() & "'/>" & "</td>" &

				Next
			End If
		End If

		Return tabla
	End Function
	Public Function SelectProfesor(ByVal ColegioID As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Profesor Select")
		NomParam.Add("@id_colegio") : ValParam.Add(ColegioID)
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</option>"
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function SelectAsignatura(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@select_curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Asignatura Select")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'> " & ds.Tables(0).Rows(i)("Asignatura").ToString() & "</option>"
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetModalidadEdit(ByVal modalidad As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@modalidad_edit") : ValParam.Add(modalidad)
		NomParam.Add("@Bloque") : ValParam.Add("GetModalidadEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idModalidad").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetJornadaEdit(ByVal jornada As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@jornada_edit") : ValParam.Add(jornada)
		NomParam.Add("@Bloque") : ValParam.Add("GetJornadaEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idJornada").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetTipoCursoEdit(ByVal tipo_curso As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@tipo_curso_edit") : ValParam.Add(tipo_curso)
		NomParam.Add("@Bloque") : ValParam.Add("GetTipoCursoEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idTipoCurso").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetNivelEdit(ByVal nivel As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@nivel_edit") : ValParam.Add(nivel)
		NomParam.Add("@Bloque") : ValParam.Add("GetNivelEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idNivel").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function TablaHorario(ByVal CursoId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		'NomParam.Add("@CursoId") : ValParam.Add(CursoId)
		'NomParam.Add("@Bloque") : ValParam.Add("TablaHorario")
		'ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		'If ds.Tables.Count > 0 Then
		'	If ds.Tables(0).Rows.Count > 0 Then
		'		For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
		'			tabla &= ds.Tables(0).Rows(i)("idNivel").ToString()
		'		Next
		'	End If

		'End If
		For i As Integer = 1 To 12 - 1


			tabla &= "<tr id='col_tr_'" & Convert.ToString(i) & " >
							<td style='width:8%;'>
								<div class='row'>
									<div class='col-6'>
										<button type='button' id='id_" & Convert.ToString(i) & "' class='btn btn-sm btn-icon btn-secundary btn_agregarFila'>
											<i class='fas fa-plus-circle'></i>
										</button>
									</div>
									<div class='col-3'>
										<button type='button' id='id_" & Convert.ToString(i) & "'  class='btn btn-sm btn-icon btn-secundary btn_eliminarFila'>
											<i class='fas fa-trash-alt'></i>
										</button>
									</div>
								</div>
							</td>
							<td style='height:30px; width:1200px;'>
								<div class='row'>
									<div class='col-12'>
										<label>Inicio</label>
										<input class='form-control' id='inicio_" + Convert.ToString(i) + "' type='time' required='' />
									</div>
									<div class='col-12'>
										<label>Fin</label>
										<input class='form-control' id='fin_" + Convert.ToString(i) + "' type='time' required='' />
									</div>
								</div>
							</td>
							<td>
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_lunes_" + Convert.ToString(i) + "'  name='td_lunes' multiple required=''>
									</select>
							</td>
							<td >
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_martes" + Convert.ToString(i) + "'  name='td_lunes' multiple required=''>
									</select>
							</td>
							<td >
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_miercoles_" + Convert.ToString(i) + "'  name='td_lunes' multiple required=''>
									</select>
							</td>
							<td>
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_jueves_" + Convert.ToString(i) + "'  name='td_lunes' multiple required=''>
									</select>
							</td>
							<td >
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_viernes_" + Convert.ToString(i) + "'  name='td_viernes' multiple required=''>
									</select>
							</td>
							<td>
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_sabado_" + Convert.ToString(i) + "'  name='td_sabado' multiple required=''>
									</select>
							</td>		
							<td>
									<label>Asignatura</label>
								   <select class='custom-select d-block w-100'  id='td_domingo_" + Convert.ToString(i) + "'  name='td_domingo' multiple required=''>
									</select>
							</td>	

							
						</tr>"


		Next
		'<td style='width:10%;'>
		'						<label>Asignatura</label>
		'						<select  id='td_martes_" + Convert.ToString(i) + "' name='td_martes' title='Nada Seleccionado' multiple class='selectpicker'>
		'						</select>
		'				</td>
		'				<td style='width:10%;'>
		'						<label>Asignatura</label>
		'						<select  id='td_miercoles_" + Convert.ToString(i) + "' name='td_miercoles' title='Nada Seleccionado' multiple class='selectpicker'>
		'						</select>
		'				</td>
		'				<td style='width:10%;'>
		'						<label>Asignatura</label>
		'						<select  id='td_jueves_" + Convert.ToString(i) + "' name='td_jueves' title='Nada Seleccionado' multiple class='selectpicker'>
		'						</select>
		'				</td>
		'				<td style='width:10%;'>
		'						<label>Asignatura</label>
		'						<select  id='td_viernes_" + Convert.ToString(i) + "' name='td_viernes' title='Nada Seleccionado' multiple class='selectpicker'>
		'						</select>
		'				</td>
		'				<td style='width:10%;'>
		'						<label>Asignatura</label>
		'						<select  id='td_sabado_" + Convert.ToString(i) + "' name='td_sabado' title='Nada Seleccionado' multiple class='selectpicker'>
		'						</select>
		'				</td>
		'				<td style='width:10%;'>
		'						<label>Asignatura</label>
		'						<select  id='td_domingo_" + Convert.ToString(i) + "' name='td_domingo' title='Nada Seleccionado' multiple class='selectpicker'>
		'						</select>
		'				</td>						
		Return tabla
	End Function
	Public Function ChangeSector(ByVal rama_input As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@cod_rama") : ValParam.Add(rama_input)
		NomParam.Add("@Bloque") : ValParam.Add("ChangeSector")

		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("name").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function ChangeEspecialidad(ByVal sector_input As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@cod_sector") : ValParam.Add(sector_input)
		NomParam.Add("@Bloque") : ValParam.Add("ChangeEspecialidad")

		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("name").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function ChangeGrado(ByVal input_t_enseñanza As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@tipo_enseñanza_edit") : ValParam.Add(input_t_enseñanza)
		NomParam.Add("@Bloque") : ValParam.Add("ChangeGrado")

		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("name").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetRamaEdit(ByVal rama As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@rama_edit") : ValParam.Add(rama)
		NomParam.Add("@Bloque") : ValParam.Add("GetRamaEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idRama").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetSectorEdit(ByVal sector As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@sector_edit") : ValParam.Add(sector)
		NomParam.Add("@Bloque") : ValParam.Add("GetSectorEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idSector").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetGRadoEdit(ByVal grado As String, ByVal input_t_enseñanza As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@grado_edit") : ValParam.Add(grado)
		NomParam.Add("@tipo_enseñanza_edit") : ValParam.Add(input_t_enseñanza)

		NomParam.Add("@Bloque") : ValParam.Add("GetGRadoEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idGrado").ToString()
				Next
			End If

		End If
		Return tabla
	End Function

	Public Function GetTipoEnseñanzaEdit(ByVal tipo_enseñanza As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@tipo_enseñanza_edit") : ValParam.Add(tipo_enseñanza)
		NomParam.Add("@Bloque") : ValParam.Add("GetTipoEnseñanzaEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("IdTipoEnseñanza").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function GetEspecialidadEdit(ByVal especialidad As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim tabla As String
		NomParam.Add("@especialidad_edit") : ValParam.Add(especialidad)
		NomParam.Add("@Bloque") : ValParam.Add("GetEspecialidadEdit")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("idEspecialidad").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function ChangeTipoEnseñanza(ByVal nivel_input As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim tabla As String
		NomParam.Add("@tipo_enseñanza_edit") : ValParam.Add(nivel_input)
		NomParam.Add("@Bloque") : ValParam.Add("ChangeTipoEnseñanza")
		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("name").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function SelectAsignaturaK(ByVal curso_id As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Curso") : ValParam.Add(curso_id)
		NomParam.Add("@Bloque") : ValParam.Add("Select Asignatura Asignada")
		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then

				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'> " & ds.Tables(0).Rows(i)("Asignatura").ToString() & " " & "(" & ds.Tables(0).Rows(i)("Profesor").ToString() & ")" & "</option>"

				Next
			End If

		End If
		Return tabla
	End Function
	Public Function ExisteHorario(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String =
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("ExisteHorario")
		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("Existe").ToString()
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function MostrarHorario(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("MostrarHorario")
		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla = "<input type='hidden'  id='datos' value='" & ds.Tables(0).Rows(i)("datos").ToString() & "||'/>"
				Next
			End If

		End If
		Return tabla
	End Function
	Public Function AsignarProfesorAsignatura(ByVal curso As Integer, ByVal asignatura As Integer,
											  ByVal profesor As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
		NomParam.Add("@Profesor") : ValParam.Add(profesor)

		NomParam.Add("@Bloque") : ValParam.Add("Insert Profesor Asignatura")

		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)

		Return "Datos ingresado"
	End Function

	Public Function MostrarAsignaturaProfesor(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Show Profesor Asignatura")

		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
							"<td class='align-middle text-left' > " &
							"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
							"" &
							"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'>" & ds.Tables(0).Rows(i)("Asignatura").ToString() & "</td>" &
							"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'>" & ds.Tables(0).Rows(i)("Profesor").ToString() & "</td>" &
					"</tr>"
				Next
			End If

		End If

		Return tabla
	End Function


	Public Function IngresarCalendario(ByVal inicio As DateTime, ByVal fin As DateTime,
								   ByVal asignatura As Integer, ByVal dias As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@InicioC") : ValParam.Add(inicio)
		NomParam.Add("@FinC") : ValParam.Add(fin)
		NomParam.Add("@AsignaturaC") : ValParam.Add(asignatura)
		NomParam.Add("@DiasC") : ValParam.Add(dias)
		NomParam.Add("@Bloque") : ValParam.Add("Insert Calendary")
		consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		Return ""
	End Function


End Class
