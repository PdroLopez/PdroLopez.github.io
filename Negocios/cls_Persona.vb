Imports Datos
Public Class cls_Persona
	Private PersonId As Integer
	Private FirstName As String
	Private MiddleName As String
	Private LastName As String
	Private SecondLastName As String
	Private GenerationCode As String
	Private Prefix As String
	Private BirthDate As Date
	Private RefSexId As Integer
	Private HispanicLatinoEthnicity As Integer
	Private RefUSCitizenshipStatusId As Integer
	Private RefVisaTypeId As Integer
	Private RefStateOfResidenceId As Integer
	Private RefProofOfResidencyTypeId As Integer
	Private RefHighestEducationLevelCompletedId As Integer
	Private RefPersonalInformationVerificationId As Integer
	Private BirthdateVerification As String
	Private RefTribalAffiliationId As Integer
	Public Property _PersonId As Integer
	Public Property _FirstName As String
	Public Property _MiddleName As String
	Public Property _LastName As String
	Public Property _SecondLastName As String
	Public Property _GenerationCode As String
	Public Property _Prefix As String
	Public Property _BirthDate As Date
	Public Property _RefStateOfResidenceId As Integer
	Public Property _RefSexId As Integer
	Public Property _HispanicLatinoEthnicity As Integer
	Public Property _RefUSCitizenshipStatusId As Integer
	Public Property _RefVisaTypeId As Integer
	Public Property _RefProofOfResidencyTypeId As Integer
	Public Property _RefHighestEducationLevelCompletedId As Integer
	Public Property _RefPersonalInformationVerificationId As Integer
	Public Property _BirthdateVerification As String
	Public Property _RefTribalAffiliationId As Integer
	Public Function BuscarRut(ByVal rut As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@rut") : ValParam.Add(rut)
		NomParam.Add("@Bloque") : ValParam.Add("Buscar por Rut")
		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					Dim fecha As Date
					Dim Existe As Integer = ds.Tables(0).Rows(i)("existe")
					If Existe = 1 Then
						'fecha = ds.Tables(0).Rows(i)("BirthDate").ToString()
						'tabla = "<div> <input  type='hidden' id='hidden_existe' value='" & ds.Tables(0).Rows(i)("existe").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_primerNombre' value='" & ds.Tables(0).Rows(i)("FirstName").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_segundoNombre' value='" & ds.Tables(0).Rows(i)("MiddleName").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_apellidoMaterno' value='" & ds.Tables(0).Rows(i)("LastName").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_apellidoPaterno' value='" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_codigo_generacion' value='" & ds.Tables(0).Rows(i)("GenerationCode").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_prefijo' value='" & ds.Tables(0).Rows(i)("Prefix").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_f_nacimiento' value='" & ds.Tables(0).Rows(i)("BirthDate").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_sexo_id' value='" & fecha & "'/>" &
						'"<input type='hidden' id='hidden_hispana_latina_id' value='" & ds.Tables(0).Rows(i)("HispanicLAtinoEthnicity").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_estado_ciudania_us_id' value='" & ds.Tables(0).Rows(i)("RefUSCitizenshipStatusId").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_tipo_visa_id' value='" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_estado_residencia' value='" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_comprobante_residencia_id' value='" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_nivel_educacion_id' value='" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_verificacion_personal_id' value='" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_verificacion_f_nacimiento' value='" & ds.Tables(0).Rows(i)("BirthdateVerification").ToString() & "'/>" &
						'"<input type='hidden' id='PersonaId' value='" & ds.Tables(0).Rows(i)("Persona").ToString() & "'/>" &
						'"<input type='hidden' id='hidden_afiliacion_tribal_id' value='" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "'/>" &
						'"</div>"
						tabla = Existe


					Else
						tabla = Existe
					End If
					'tabla = "<div> " &
					'	" <input  type='hidden' id='hidden_existe' value='" & ds.Tables(0).Rows(i)("existe").ToString() & "'/>" &
					'	"<input type='hidden' id='StrFonos" &
					'	ds.Tables(0).Rows(i)("Persona").ToString() & "' value = '" & ds.Tables(0).Rows(i)("StrFonos").ToString() & "'/>" &
					'	"<input type='hidden' id='StrCorreo" & ds.Tables(0).Rows(i)("Persona").ToString() & "' value = '" & ds.Tables(0).Rows(i)("StrCorreo").ToString() & "'/>" &
					'			"</div>"


				Next
			End If

		End If

		Return tabla


	End Function




	Public Function BuscarIdPerson(ByVal rut As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@rut") : ValParam.Add(rut)
		NomParam.Add("@Bloque") : ValParam.Add("BuscarIdPerson")
		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					'tabla = ....
					tabla = ds.Tables(0).Rows(i)("PersonId").ToString()
				Next
			End If

		End If

		Return tabla


	End Function

	Public Function GuardarPersona(ByVal strEditado As String,
									ByVal rut As String, ByVal strEliminado As String, ByVal strFonos As String,
									ByVal strCorreoEditado As String,
									ByVal strCorreoEliminado As String, ByVal strCorreos As String,
									ByVal primerNombre As String, ByVal segundoNombre As String,
									 ByVal ApellidoMaterno As String, ByVal ApellidoPaterno As String,
									ByVal f_nacimiento As Date, ByVal sexo_referencia_id As Integer,
								   ByVal rol As Integer, ByVal curso As Integer,
								   ByVal estudiante As Integer, ByVal ColegioId As Integer) As String
		' strFonos: Contiene los fonos separados por ||
		'//hay que agregar person_id
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Person Insert")
		NomParam.Add("@FirstName") : ValParam.Add(primerNombre)
		NomParam.Add("@MiddleName") : ValParam.Add(segundoNombre)
		NomParam.Add("@LastName") : ValParam.Add(ApellidoMaterno)
		NomParam.Add("@alumno") : ValParam.Add(estudiante)
		NomParam.Add("@SecondLastName") : ValParam.Add(ApellidoPaterno)

		'NomParam.Add("@GenerationCode") : ValParam.Add(codigo_generacion)
		'NomParam.Add("@Prefix") : ValParam.Add(prefijo)
		NomParam.Add("@BirthDate") : ValParam.Add(f_nacimiento)
		NomParam.Add("@RefSexId") : ValParam.Add(sexo_referencia_id)

		NomParam.Add("@StrFonos") : ValParam.Add(strFonos)
		NomParam.Add("@strEditado") : ValParam.Add(strEditado)
		NomParam.Add("@strEliminado") : ValParam.Add(strEliminado)
		NomParam.Add("@strCorreos") : ValParam.Add(strCorreos)
		NomParam.Add("@strCorreoEditado") : ValParam.Add(strCorreoEditado)
		NomParam.Add("@strCorreoEliminado") : ValParam.Add(strCorreoEliminado)
		NomParam.Add("@rol_id") : ValParam.Add(rol)
		NomParam.Add("@rut") : ValParam.Add(rut)
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioId)

		consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function

	Public Function SeleccionarPersona(ByVal tipo_persona As Integer, ByVal ColegioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Person Select all")
		NomParam.Add("@rol_id") : ValParam.Add(tipo_persona)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioId)

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
									   "<td id='perid" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>" &
									  "<td id='FirstName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("FirstName").ToString() & "</td>" &
									 "<td id='MiddleName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</td>" &
									 "<td id='LastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("LastName").ToString() & "</td>" &
									 "<td id='SecondLastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "</td>" &
									"<td id='GenerationCode" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("GenerationCode").ToString() & "</td>" &
									 "<td id='Prefix" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Prefix").ToString() & "</td>" &
									 "<td id='BirthDate" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("BirthDate").ToString() & "</td>" &
									"<td id=''>" & ds.Tables(0).Rows(i)("name_sexo").ToString() & "</td>" &
									"<td id='RefSexId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefSexId").ToString() & "</td>" &
									 "<td id='HispanicLatinoEthnicity" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("HispanicLatinoEthnicity").ToString() & "</td>" &
									 "<td id='RefUSCitizenshipStatusId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefUSCitizenshipStatusId").ToString() & "</td>" &
									 "<td id='RefVisaTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "</td>" &
									 "<td id='RefStateOfResidenceId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "</td>" &
									 "<td id='RefProofOfResidencyTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "</td>" &
									 "<td id='RefHighestEducationLevelCompletedId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "</td>" &
									 "<td id='RefPersonalInformationVerificationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "</td>" &
									 "<td id='BirthdateVerification" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("BirthdateVerification").ToString() & "</td>" &
									 "<td id='Rut" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("rut").ToString() & "</td>" &
									"<td id='RefTribalAffiliationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "</td>" &
									 "<input  id='StrFonos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrFonos").ToString() & "'>" &
									  "<input  id='StrCorreo" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrCorreo").ToString() & "'>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function SeleccionarPersonaTipo(ByVal tipo_persona As Integer, ByVal ColegioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("SeleccionarPersonaTipo")
		NomParam.Add("@rol_id") : ValParam.Add(tipo_persona)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioId)

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
									   "<td id='perid" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>" &
									  "<td id='FirstName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("FirstName").ToString() & "</td>" &
									 "<td id='MiddleName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</td>" &
									 "<td id='LastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("LastName").ToString() & "</td>" &
									 "<td id='SecondLastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "</td>" &
									"<td id='GenerationCode" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("GenerationCode").ToString() & "</td>" &
									 "<td id='Prefix" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Prefix").ToString() & "</td>" &
									 "<td id='BirthDate" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("BirthDate").ToString() & "</td>" &
									"<td id=''>" & ds.Tables(0).Rows(i)("name_sexo").ToString() & "</td>" &
									"<td id='RefSexId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefSexId").ToString() & "</td>" &
									 "<td id='HispanicLatinoEthnicity" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("HispanicLatinoEthnicity").ToString() & "</td>" &
									 "<td id='RefUSCitizenshipStatusId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefUSCitizenshipStatusId").ToString() & "</td>" &
									 "<td id='RefVisaTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "</td>" &
									 "<td id='RefStateOfResidenceId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "</td>" &
									 "<td id='RefProofOfResidencyTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "</td>" &
									 "<td id='RefHighestEducationLevelCompletedId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "</td>" &
									 "<td id='RefPersonalInformationVerificationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "</td>" &
									 "<td id='BirthdateVerification" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("BirthdateVerification").ToString() & "</td>" &
									 "<td id='Rut" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("rut").ToString() & "</td>" &
									"<td id='RefTribalAffiliationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "</td>" &
									 "<input  id='StrFonos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrFonos").ToString() & "'>" &
									  "<input  id='StrCorreo" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrCorreo").ToString() & "'>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function

	Public Function getApoderado(ByVal estudiante As Integer, ByVal ColegioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Get Apoderado")
		NomParam.Add("@PersonId") : ValParam.Add(estudiante)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioId)

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
									   "<td id='perid" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>" &
									  "<td id='FirstName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("FirstName").ToString() & "</td>" &
									 "<td id='MiddleName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</td>" &
									 "<td id='LastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("LastName").ToString() & "</td>" &
									 "<td id='SecondLastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "</td>" &
									"<td id='GenerationCode" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("GenerationCode").ToString() & "</td>" &
									 "<td id='Prefix" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Prefix").ToString() & "</td>" &
									 "<td id='BirthDate" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("BirthDate").ToString() & "</td>" &
									"<td id=''>" & ds.Tables(0).Rows(i)("name_sexo").ToString() & "</td>" &
									"<td id='RefSexId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefSexId").ToString() & "</td>" &
									 "<td id='HispanicLatinoEthnicity" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("HispanicLatinoEthnicity").ToString() & "</td>" &
									 "<td id='RefUSCitizenshipStatusId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefUSCitizenshipStatusId").ToString() & "</td>" &
									 "<td id='RefVisaTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "</td>" &
									 "<td id='RefStateOfResidenceId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "</td>" &
									 "<td id='RefProofOfResidencyTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "</td>" &
									 "<td id='RefHighestEducationLevelCompletedId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "</td>" &
									 "<td id='RefPersonalInformationVerificationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "</td>" &
									 "<td id='BirthdateVerification" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("BirthdateVerification").ToString() & "</td>" &
									 "<td id='Rut" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("rut").ToString() & "</td>" &
									"<td id='RefTribalAffiliationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "</td>" &
									 "<input  id='StrFonos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrFonos").ToString() & "'>" &
									  "<input  id='StrCorreo" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrCorreo").ToString() & "'>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function



	Public Function SeleccionarPersonaApoderado(ByVal estudiante As Integer, ByVal tipo_persona As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("SeleccionarPersonaApoderado")
		NomParam.Add("@PersonId") : ValParam.Add(estudiante)
		NomParam.Add("@rol_id") : ValParam.Add(tipo_persona)

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
									   "<td id='perid" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>" &
									  "<td id='FirstName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("FirstName").ToString() & "</td>" &
									 "<td id='MiddleName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</td>" &
									 "<td id='LastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("LastName").ToString() & "</td>" &
									 "<td id='SecondLastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "</td>" &
									"<td id='GenerationCode" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("GenerationCode").ToString() & "</td>" &
									 "<td id='Prefix" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Prefix").ToString() & "</td>" &
									 "<td id='BirthDate" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("BirthDate").ToString() & "</td>" &
									"<td id=''>" & ds.Tables(0).Rows(i)("name_sexo").ToString() & "</td>" &
									"<td id='RefSexId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefSexId").ToString() & "</td>" &
									 "<td id='HispanicLatinoEthnicity" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("HispanicLatinoEthnicity").ToString() & "</td>" &
									 "<td id='RefUSCitizenshipStatusId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefUSCitizenshipStatusId").ToString() & "</td>" &
									 "<td id='RefVisaTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "</td>" &
									 "<td id='RefStateOfResidenceId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "</td>" &
									 "<td id='RefProofOfResidencyTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "</td>" &
									 "<td id='RefHighestEducationLevelCompletedId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "</td>" &
									 "<td id='RefPersonalInformationVerificationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "</td>" &
									 "<td id='BirthdateVerification" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("BirthdateVerification").ToString() & "</td>" &
									 "<td id='Rut" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("rut").ToString() & "</td>" &
									"<td id='RefTribalAffiliationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "</td>" &
									 "<input  id='StrFonos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrFonos").ToString() & "'>" &
									  "<input  id='StrCorreo" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrCorreo").ToString() & "'>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function

	Public Function SearchCurso(ByVal curso As Integer, ByVal ColegioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioId)
		NomParam.Add("@Bloque") : ValParam.Add("Search Estudiante")

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
									   "<td id='perid" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>" &
									  "<td id='FirstName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("FirstName").ToString() & "</td>" &
									 "<td id='MiddleName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</td>" &
									 "<td id='LastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("LastName").ToString() & "</td>" &
									 "<td id='SecondLastName" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "</td>" &
									"<td id='GenerationCode" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("GenerationCode").ToString() & "</td>" &
									 "<td id='Prefix" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Prefix").ToString() & "</td>" &
									 "<td id='BirthDate" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>" & ds.Tables(0).Rows(i)("BirthDate").ToString() & "</td>" &
									"<td id=''>" & ds.Tables(0).Rows(i)("name_sexo").ToString() & "</td>" &
									"<td id='RefSexId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefSexId").ToString() & "</td>" &
									 "<td id='HispanicLatinoEthnicity" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("HispanicLatinoEthnicity").ToString() & "</td>" &
									 "<td id='RefUSCitizenshipStatusId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefUSCitizenshipStatusId").ToString() & "</td>" &
									 "<td id='RefVisaTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "</td>" &
									 "<td id='RefStateOfResidenceId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "</td>" &
									 "<td id='RefProofOfResidencyTypeId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "</td>" &
									 "<td id='RefHighestEducationLevelCompletedId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "</td>" &
									 "<td id='RefPersonalInformationVerificationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "</td>" &
									 "<td id='BirthdateVerification" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("BirthdateVerification").ToString() & "</td>" &
									 "<td id='Rut" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("rut").ToString() & "</td>" &
									"<td id='RefTribalAffiliationId" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' style='display:none;'>>" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "</td>" &
									 "<input  id='StrFonos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrFonos").ToString() & "'>" &
									  "<input  id='StrCorreo" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' type='hidden' value = '" & ds.Tables(0).Rows(i)("StrCorreo").ToString() & "'>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function

	Public Function BuscarTelefono(ByVal PersonId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		Dim pr As String
		pr = ""
		NomParam.Add("@Bloque") : ValParam.Add("Person Telephone")
		NomParam.Add("@PersonId") : ValParam.Add(PersonId)

		ds = consulta.ExecuteSQL("IE_PERSON_TELEPHONE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					pr = ds.Tables(0).Rows(i)("PersonTelephoneId").ToString()
					tabla &= "<div class='row'>" & "<div class='col-md-6 mb-3'>" &
							"<div class='row'>" & "<div class='col-6'>" &
							"<label> Teléfono </label> <input type='text' name='telefonoEdit[]' id='telefonoEdit[]' style='margin:0px; padding:0px;' class='form-control dataInputEdit' value='" & ds.Tables(0).Rows(i)("TelephoneNumber").ToString() & "'/> " &
							"</div>" &
							"<div class='col-6'>" &
							"<button  type= 'button' class='btn btn-xl btn-icon btn-secundary btn_eliminar_telefono' style='margin-top:30px;' id='" & pr & "'> <i class='fas fa-minus-circle'></i> </button>" &
							"</div>" &
							"</div>" &
							"</div>" &
							"</div>"
				Next
			End If

		End If

		Return tabla
	End Function
	''' <summary>
	''' Genera un string a partir de un ds dado y lo retorna...
	''' </summary>
	''' <param name="ds"> Datos de telefono de una persona.</param>
	''' <returns></returns>
	Public Function BuscarTelefono(dt As DataTable) As String

		Dim tabla As String = "No hay datos para mostrar"
		Dim pr As String = ""
		Dim br As String = ""

		If dt.Rows.Count > 0 Then
			tabla &= "<div class='row'><div class='col-md-6 mb-3'><label> Teléfono </label>"
			For i As Integer = 0 To dt.Rows.Count() - 1
				pr = dt.Rows(i)("PersonTelephoneId").ToString()
				tabla &= br & "<div class='row'>
							<div class='col-6'>
								<input type='text' name='telefonoEdit[]' id='telefonoEdit[]' style='margin:0px; padding:0px;' class='form-control dataInputEdit' value='" & dt.Rows(i)("TelephoneNumber").ToString() & "'/> " &
							"</div>" &
							"<div class='col-6'>" &
								"<button  type= 'button' class='btn btn-xl btn-icon btn-secundary btn_eliminar_telefono red' id='" & pr & "'> <i class='fas fa-minus-circle'></i> </button>" &
							"</div>" &
						"</div>"
				br = "<br>"
			Next
		End If


		Return tabla & "</div></div>"
	End Function
	Public Function EditarPersona(ByVal PersonId As Integer, ByVal strEditado As String,
									ByVal rut As String, ByVal strEliminado As String, ByVal strFonos As String,
									ByVal strCorreoEditado As String,
									ByVal strCorreoEliminado As String, ByVal strCorreos As String,
									ByVal primerNombre As String, ByVal segundoNombre As String,
									 ByVal ApellidoMaterno As String, ByVal ApellidoPaterno As String,
									ByVal f_nacimiento As Date, ByVal sexo_referencia_id As Integer, ByVal rol As Integer) As String
		' strFonos: Contiene los fonos separados por ||
		'//hay que agregar person_id
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Person Update")
		NomParam.Add("@FirstName") : ValParam.Add(primerNombre)
		NomParam.Add("@MiddleName") : ValParam.Add(segundoNombre)
		NomParam.Add("@LastName") : ValParam.Add(ApellidoMaterno)
		NomParam.Add("@SecondLastName") : ValParam.Add(ApellidoPaterno)
		NomParam.Add("@PersonId") : ValParam.Add(PersonId)
		'NomParam.Add("@Prefix") : ValParam.Add(prefijo)
		NomParam.Add("@BirthDate") : ValParam.Add(f_nacimiento)
		NomParam.Add("@RefSexId") : ValParam.Add(sexo_referencia_id)
		'NomParam.Add("@HispanicLatinoEthnicity") : ValParam.Add(hispana_latina_id)
		'NomParam.Add("@RefUSCitizenshipStatusId") : ValParam.Add(estado_ciudania_us_id)
		'NomParam.Add("@RefVisaTypeId") : ValParam.Add(tipo_visa_id)
		'NomParam.Add("@RefStateOfResidenceId") : ValParam.Add(estado_residencia)
		'NomParam.Add("@RefProofOfResidencyTypeId") : ValParam.Add(comprobante_residencia_id)
		'NomParam.Add("@RefHighestEducationLevelCompletedId") : ValParam.Add(nivel_educacion_id)
		'NomParam.Add("@RefPersonalInformationVerificationId") : ValParam.Add(verificacion_personal_id)
		'NomParam.Add("@BirthdateVerification") : ValParam.Add(verificacion_f_nacimiento)
		'NomParam.Add("@RefTribalAffiliationId") : ValParam.Add(afiliacion_tribal_id)
		NomParam.Add("@StrFonos") : ValParam.Add(strFonos)
		NomParam.Add("@strEditado") : ValParam.Add(strEditado)
		NomParam.Add("@strEliminado") : ValParam.Add(strEliminado)
		NomParam.Add("@strCorreos") : ValParam.Add(strCorreos)
		NomParam.Add("@strCorreoEditado") : ValParam.Add(strCorreoEditado)
		NomParam.Add("@strCorreoEliminado") : ValParam.Add(strCorreoEliminado)
		NomParam.Add("@rol_id") : ValParam.Add(rol)
		NomParam.Add("@rut") : ValParam.Add(rut)

		consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."


	End Function
	Public Function EliminarPersona(ByVal PersonId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		NomParam.Add("@Bloque") : ValParam.Add("Person Delete")
		NomParam.Add("@PersonId") : ValParam.Add(PersonId)
		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		Return "El comando N° 155 fue ejecutado con éxito."



	End Function
	Public Function EliminarTelefono(ByVal PersonId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		NomParam.Add("@Bloque") : ValParam.Add("Delete Person Telephone")
		NomParam.Add("@PersonId") : ValParam.Add(PersonId)
		ds = consulta.ExecuteSQL("IE_PERSON_TELEPHONE", NomParam, ValParam)
		Return "El comando N° 155 fue ejecutado con éxito."



	End Function
	Public Function SelectSex() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefSex Select")

		ds = consulta.ExecuteSQL("IE_REF_SEX", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefSexId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function SelectUS() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Get Select US")

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					'tabla &= "<option  value='" & ds.Tables(0).Rows(i)("").ToString() & "'> " & ds.Tables(0).Rows(i)("").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetCurso() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get Curso")
		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'> " & ds.Tables(0).Rows(i)("Curso").ToString() & "</option>"
				Next
			End If
		End If
		Return tabla






	End Function
	Public Function SelectEstudiante(ByVal curso As Integer, ByVal ColegioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get Estudiante")
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioId)

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
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
	Public Function RefPersonRelationShip() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Select RefPersonRelationShip")

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefPersonRelationshipId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla






	End Function

	Public Function SelectTipoPersona() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Role Select")

		ds = consulta.ExecuteSQL("IE_ROLE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("Name").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function SelectTipoVisa() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefVisaType Select")

		ds = consulta.ExecuteSQL("IE_RefVisaType", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefVisaTypeId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function SelectEstadoResidencia() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefStateOfResidence Select")

		ds = consulta.ExecuteSQL("IE_RefStateOfResidence", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefStateOfResidenceId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function SelectComprobanteResidencia() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefProofOfResidencyType Select")

		ds = consulta.ExecuteSQL("IE_RefProofOfResidencyType", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefProofOfResidencyTypeId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function NivelEducacion() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefHighestEducationLevelCompleted Select")

		ds = consulta.ExecuteSQL("IE_RefHighestEducationLevelCompletedId", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefHighestEducationLevelCompletedId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function VerificacionPersonal() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefPersonalInformationVerification Select")

		ds = consulta.ExecuteSQL("IE_RefPersonalInformationVerificationId", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefPersonalInformationVerificationId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function AfiliacionTribal() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("RefTribalAffiliation Select")

		ds = consulta.ExecuteSQL("IE_RefTribalAffiliation", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("RefTribalAffiliationId").ToString() & "'> " & ds.Tables(0).Rows(i)("Description").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetLastID() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""

		NomParam.Add("@Bloque") : ValParam.Add("UltimoID")

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= Convert.ToInt32(ds.Tables(0).Rows(i)("PersonId"))
				Next
			End If

		End If
		'NomParam.Add("@Bloque") : ValParam.Add("Person Telephone Insert")
		'NomParam.Add("@PersonId") : ValParam.Add(tabla)
		'NomParam.Add("@TelephoneNumber") : ValParam.Add(data)
		'NomParam.Add("@PrimaryTelephoneNumberIndicator") : ValParam.Add(IndicadorNumero)
		'NomParam.Add("@RefPersonTelephoneNumberTypeId") : ValParam.Add(tipo_numero)
		'consulta.ExecuteSQL("IE_PERSON_TELEPHONE", NomParam, ValParam)
		Return tabla





	End Function
	Public Function GuardarTelefono(strFono As String) As String
		'Dim consulta As New clsConsulta
		'Dim NomParam, ValParam As New ArrayList
		'NomParam.Add("@Bloque") : ValParam.Add("Person Telephone Insert")
		'NomParam.Add("@PersonId") : ValParam.Add(PersonId)
		'NomParam.Add("@TelephoneNumber") : ValParam.Add(Data)
		'NomParam.Add("@PrimaryTelephoneNumberIndicator") : ValParam.Add(IndicadorNumero)
		'NomParam.Add("@RefPersonTelephoneNumberTypeId") : ValParam.Add(tipo_numero)
		'consulta.ExecuteSQL("IE_PERSON_TELEPHONE", NomParam, ValParam)
		'Return "El comando N° 150 fue ejecutado con éxito."

	End Function
	Public Function EditarTelefono(ByVal PersonId As Integer, ByVal data As String, ByVal tipo_numero As Integer, ByVal IndicadorNumero As Integer) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		NomParam.Add("@Bloque") : ValParam.Add("Update Person Telephone")
		NomParam.Add("@PersonId") : ValParam.Add(PersonId)
		NomParam.Add("@TelephoneNumber") : ValParam.Add(data)
		NomParam.Add("@PrimaryTelephoneNumberIndicator") : ValParam.Add(IndicadorNumero)
		NomParam.Add("@RefPersonTelephoneNumberTypeId") : ValParam.Add(tipo_numero)
		consulta.ExecuteSQL("IE_PERSON_TELEPHONE", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."

	End Function
End Class