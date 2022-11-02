Imports Datos
Public Class cls_Asistencia
	Public Function MostrarPersonas() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim n_nombres As Integer
		n_nombres = 0
		Dim n_p As String


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Person Select All")

		ds = consulta.ExecuteSQL("IE_PERSON", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" & "<td > " & i + 1 & "</td>" & "<td id='nombres' > " & "<p data-toggle='tooltip' data-placement='top' title='" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "  " & ds.Tables(0).Rows(i)("LastName").ToString() & "   " & ds.Tables(0).Rows(i)("MiddleName").ToString() & " " & ds.Tables(0).Rows(i)("FirstName").ToString() & "'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "  " & ds.Tables(0).Rows(i)("SecondLastName").ToString() & "</p> " & "</td>" &
					  "<td>" & "<p id='icon" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='1'id='fecha_uno" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_ar' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_dos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='2'id='fecha_dos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_dos' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_tres" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='3'id='fecha_tres" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_tres' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_cuatro" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='4'id='fecha_cuatro" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_cuatro' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_cinco" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='5'id='fecha_cinco" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_cinco' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_seis" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='6'id='fecha_seis" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_seis' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_siete" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='7'id='fecha_siete" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_siete' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_ocho" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='8'id='fecha_ocho" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_ocho' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_nueve" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='9'id='fecha_nueve" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_nueve' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_diez" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='10'id='fecha_diez" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_diez' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_once" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='11'id='fecha_once" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_once' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_doce" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='12'id='fecha_doce" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_doce' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_trece" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='13'id='icon_trece" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_trece' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_catorce" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='14'id='icon_catorce" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_catorce' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_quince" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='15'id='fecha_quince" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_quince' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_deciseis" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='16'id='fecha_deciseis" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_deciseis' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_decisiete" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='17'id='fecha_decisiete" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_decisiete' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_decieocho" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='18'id='fecha_decieocho" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_decieocho' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_decienueve" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='19'id='fecha_decienueve" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_decienueve' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veinte" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='20'id='fecha_veinte" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veinte' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veinteuno" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='21'id='fecha_veinteuno" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veinteuno' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veintedos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='22'id='fecha_veintedos" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veintedos' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veintetres" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='23'id='fecha_veintetres" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veintetres' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veintecuatro" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='24'id='fecha_veintecuatro" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veintecuatro' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veintecinco" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='25'id='fecha_veintecinco" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veintecinco' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veinteseis" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='26'id='fecha_veinteseis" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veinteseis' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veintesiete" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='27'id='fecha_veintesiete" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veintesiete' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veinteocho" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='28'id='fecha_veinteocho" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veinteocho' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_veintenueve" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='29'id='fecha_veintenueve" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_veintenueve' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_treinta" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='30'id='fecha_treinta" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_treinta' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					  "<td>" & "<p id='icon_treintauno'" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> <input type='hidden' value='31'id='fecha_treintauno'" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>" & " <i Class='fa fa-circle icon_treintauno' id='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'></i></p></td>" &
					"</tr>"



				Next
			End If

		End If

		Return tabla



	End Function
	Public Function Cabecera(ByVal fecha As String, ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		

		Dim tabla As String = ""
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		NomParam.Add("@curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Get cabecera")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				tabla &= "<th style='text-align:center;margin-top:50px;'>Estudiantes</th>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					Dim mes As String = ds.Tables(0).Rows(i)("mes").ToString()
					'tabla &= "Hola mundo"

					If mes = "January" Then
						mes = "ENERO"
					End If
					If mes = "February" Then
						mes = "FEBRERO"
					End If
					If mes = "March" Then
						mes = "MARZO"
					End If
					If mes = "April" Then
						mes = "ABRIL"
					End If

					If mes = "May" Then
						mes = "MAYO"
					End If

					If mes = "June" Then
						mes = "JUNIO"
					End If

					If mes = "July" Then
						mes = "JULIO"
					End If

					If mes = "August" Then
						mes = "AGOSTO"
					End If


					If mes = "September" Then
						mes = "SEPTIEMBRE"
					End If


					If mes = "October" Then
						mes = "OCTUBRE"
					End If

					If mes = "November" Then
						mes = "NOVIEMBRE"
					End If

					If mes = "December" Then
						mes = "DICIEMBRE"
					End If
					If ds.Tables(0).Rows(i)("Firmado").ToString() = "1" Then
						tabla &= "<th id='td_" & i + 1 & "' columna='" & i + 1 & "' asignatura_" & i + 1 & "='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>  
											<button data-target='#create' data-toggle='modal'  columna='" & i + 1 & "'  class='btn btn-success btnFirma' id='Asignatura" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "' type='button' data='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "' CSS='" & ds.Tables(0).Rows(i)("CourseSectionScheduleId").ToString() & "' firmado_ok='" & ds.Tables(0).Rows(i)("Firmado").ToString() & "'>
												<i class='flaticon2-plus'></i> Firma
											</button>
											</br></br>
											<input type='hidden' id='cont_cabebecera' value='" & ds.Tables(0).Rows.Count() & "'/>
											" & ds.Tables(0).Rows(i)("Name").ToString() & "
											</br></br>" & ds.Tables(0).Rows(i)("HoraInicial").ToString() & " - " & ds.Tables(0).Rows(i)("HoraFinal").ToString() & "
											</br></br> 
											<div class='btn-group' role='group' aria-label='Basic example'>
												<button type='button' id='Presente_" & i + 1 & "' class='btn btn-success btnPresente' columna='" & i + 1 & "'>P</button>
												<button type='button  id='Ausente_" & i + 1 & "'  class='btn btn-danger btnAusente'  columna='" & i + 1 & "'>A</button>
												<button type='button'  id='Retrasado_" & i + 1 & "' class='btn btn-warning btnR' columna='" & i + 1 & "'>R</button>
											</div>
											<input id='dia' type='hidden' value='" & ds.Tables(0).Rows(i)("dia").ToString() & "' />
											<input id='diaNumber' type='hidden' value='" & ds.Tables(0).Rows(i)("diaNumber").ToString() & "' />
											<input id='mes' type='hidden' value='" & mes & "' />
											<input id='anio' type='hidden' value='" & ds.Tables(0).Rows(i)("anio").ToString() & "' />
									</th>
								"

					ElseIf ds.Tables(0).Rows(i)("Firmado").ToString() = "0" Then

						tabla &= "<th id='td_" & i + 1 & "' columna='" & i + 1 & "' asignatura_" & i + 1 & "='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>  
											<button data-target='#create' data-toggle='modal'  columna='" & i + 1 & "'  class='btn btn-primary btnFirma' id='Asignatura" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "' type='button' data='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "' CSS='" & ds.Tables(0).Rows(i)("CourseSectionScheduleId").ToString() & "' firmado_ok='0' >
												<i class='flaticon2-plus'></i> Firma
											</button>
											</br></br>
											<input type='hidden' id='cont_cabebecera' value='" & ds.Tables(0).Rows.Count() & "'/>
											" & ds.Tables(0).Rows(i)("Name").ToString() & "
											</br></br>" & ds.Tables(0).Rows(i)("HoraInicial").ToString() & " - " & ds.Tables(0).Rows(i)("HoraFinal").ToString() & "
											</br></br> 
											<div class='btn-group' role='group' aria-label='Basic example'>
												<button type='button' id='Presente_" & i + 1 & "' class='btn btn-success btnPresente' columna='" & i + 1 & "'>P</button>
												<button type='button  id='Ausente_" & i + 1 & "'  class='btn btn-danger btnAusente'  columna='" & i + 1 & "'>A</button>
												<button type='button'  id='Retrasado_" & i + 1 & "' class='btn btn-warning btnR' columna='" & i + 1 & "'>R</button>
											</div>
											<input id='dia' type='hidden' value='" & ds.Tables(0).Rows(i)("dia").ToString() & "' />
											<input id='diaNumber' type='hidden' value='" & ds.Tables(0).Rows(i)("diaNumber").ToString() & "' />
											<input id='mes' type='hidden' value='" & mes & "' />
											<input id='anio' type='hidden' value='" & ds.Tables(0).Rows(i)("anio").ToString() & "' />
									</th>
								"
					End If






				Next


			End If

		End If

		Return tabla


	End Function
	Public Function GetCondicion(ByVal ORP As Integer, ByVal fecha As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim dias As String = ""

		Dim tabla As String = ""
		NomParam.Add("@OrganizationPersonRole") : ValParam.Add(ORP)
		NomParam.Add("@fecha") : ValParam.Add(fecha)

		NomParam.Add("@Bloque") : ValParam.Add("GetCondicion12")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then



				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					'tabla &= "<input  class='condicion_principal' type='hidden' id='condicion_" & ds.Tables(0).Rows(i)("id").ToString() & "_" & i & "' value='" & ds.Tables(0).Rows(i)("id").ToString() & "' condicion='" & ds.Tables(0).Rows(i)("RefAttendanceStatusId").ToString() & "' RoleEventId='" & ds.Tables(0).Rows(i)("RoleAttendanceEventId").ToString() & "'  />"
					tabla &= ds.Tables(0).Rows(i)("estado").ToString()
				Next


			End If

		End If
		Return tabla



	End Function

	Public Function AsistenciaMensualDos(ByVal curso_dos As Integer, ByVal mes_number As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim dias As String = ""

		Dim tabla As String = ""
		NomParam.Add("@curso") : ValParam.Add(curso_dos)
		NomParam.Add("@mes_number") : ValParam.Add(mes_number)
		NomParam.Add("@Bloque") : ValParam.Add("AsistenciaMensualDos")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then



				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					If ds.Tables(0).Rows(i)("existe").ToString() = 1 Then
						tabla &= "<input  class='input_blade' type='hidden' id='Asistencia_" & ds.Tables(0).Rows(i)("id").ToString() & "' value='" & ds.Tables(0).Rows(i)("id").ToString() & "' fecha='" & ds.Tables(0).Rows(i)("Date").ToString() & "' condicion='" & ds.Tables(0).Rows(i)("condicion").ToString() & "' ORP='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' RoleEventId='" & ds.Tables(0).Rows(i)("RoleAttendanceEventId").ToString() & "'  />"


					ElseIf ds.Tables(0).Rows(i)("existe").ToString() = 2 Then
						tabla = ds.Tables(0).Rows(i)("existe").ToString()
					End If


				Next


			End If

		End If
		Return tabla



	End Function
	Public Function CabeceraMensual(ByVal mes_final As Date) As String

		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim dias As String = ""

		Dim tabla As String = ""
		NomParam.Add("@fecha_mensual") : ValParam.Add(mes_final)
		NomParam.Add("@Bloque") : ValParam.Add("Get cabecera Mensual")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				tabla &= "<th>N°</th>
						  <th>Nombres</th>
"
				Dim a As String = ds.Tables(0).Rows(0)("countDias").ToString()

				For i As Integer = 1 To a
					tabla &= " <th id='" & i & "'> <input type='hidden' id='cont_dias' value='" & a & "' /> " & dias & "<br/> " & i & "</th> 
					  <input type='hidden' id='cont_cabebeceraMensual' value='" & ds.Tables(0).Rows.Count() & "'/>
"



				Next


			End If

		End If

		Return tabla


	End Function
	Public Function GetNameEstudiante(ByVal cont As Integer, ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		NomParam.Add("@curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Get Estudiante")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<tr>
								<td style='background-color:white; font-size:20px;'> 
									<div  style='width:400px;'>" & ds.Tables(0).Rows(i)("SecondLastName").ToString() & " " & ds.Tables(0).Rows(i)("LastName").ToString() & " " & ds.Tables(0).Rows(i)("FirstName").ToString() & " " & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</div>
								</td>
								"
					For x As Integer = 0 To cont - 1
						Dim x2 As Integer = x + 1


						'tabla &= "<td class='btn_td_" & x2 & "' style='background-color:'rgba(249, 239, 239, 0.8);' id='cordenadas_" & i & "_" & x & "' data-count='0' fila='" & i & "'  col='" & x & "'  columna_" & x2 & "='" & x2 & "' dato='" & i & "_" & x & "' ORP='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' onclick='PresenteIndividual(this.id);'  RoleEventId='0' >
						'			</td> 
						'			"

						tabla &= "<td class='btn_td_" & x2 & "' style='background-color:'rgba(249, 239, 239, 0.8);' id='cordenadas_" & i & "_" & x & "' data-count='0' fila='" & i & "'  col='" & x & "'  columna='" & x2 & "' dato='" & i & "_" & x & "' ORP='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' onclick='PresenteIndividual(this.id);'  RoleEventId='0'  PersonId='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' >
									</td> 
									"

					Next






					tabla &= "</tr>"
				Next


			End If

		End If

		Return tabla


	End Function
	Public Function ObtenerCordenadas(ByVal curso As Integer, ByVal fecha As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		NomParam.Add("@curso") : ValParam.Add(curso)
		NomParam.Add("@fecha") : ValParam.Add(fecha)

		NomParam.Add("@Bloque") : ValParam.Add("Get Cordenadas")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<input class='btn_cordenadas' type='hidden' id='ORP_" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' condicion='" & ds.Tables(0).Rows(i)("RefAttendanceStatusId").ToString() & "' coordenadas='" & ds.Tables(0).Rows(i)("ied_cordenadas").ToString() & "' value='" & ds.Tables(0).Rows(i)("RoleAttendanceEventId").ToString() & "' />"

				Next


			End If

		End If

		Return tabla


	End Function
	Public Function Condicion(ByVal cont2 As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		NomParam.Add("@Cordenadas") : ValParam.Add(cont2)
		NomParam.Add("@Bloque") : ValParam.Add("Get Condicion")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("cordenadas").ToString()
				Next


			End If

		End If

		Return tabla


	End Function

	Public Function GetNameMensual(ByVal curso_dos As Integer, ByVal mes_final As String, ByVal mes_number As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		Dim tabla2 As String = ""
		Dim tabla1 As String = ""

		NomParam.Add("@curso") : ValParam.Add(curso_dos)
		'	NomParam.Add("@fecha_mensual") : ValParam.Add(mes_final)
		NomParam.Add("@mes_number") : ValParam.Add(mes_number)

		NomParam.Add("@Bloque") : ValParam.Add("Get Estudiante Mensual")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					'tabla2 = ds.Tables(0).Rows(i)("fecha").ToString() & "," & ds.Tables(0).Rows(i)("cordenadas").ToString() & "," & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "||"
					tabla &= "<tr>
								<td > " & ds.Tables(0).Rows(i)("PersonId").ToString() & "</td>
								<td  style='font-size:20px;'>
								<div style='width:400px;' >  " & ds.Tables(0).Rows(i)("SecondLastName").ToString() & " " & ds.Tables(0).Rows(i)("LastName").ToString() & " " & ds.Tables(0).Rows(i)("FirstName").ToString() & " " & ds.Tables(0).Rows(i)("MiddleName").ToString() & "</div>
									<input type='hidden' id='condicion' value='" & ds.Tables(0).Rows(i)("condicion").ToString() & "' />
									<input type='hidden' id='cordenadas' value='" & ds.Tables(0).Rows(i)("cordenadas").ToString() & "' />
									<input type='hidden' id='fecha_backend' value='" & ds.Tables(0).Rows(i)("fecha").ToString() & "' />
									<input type='hidden' id='orp' value='" & ds.Tables(0).Rows(i)("orp").ToString() & "' />
									<input type='hidden' id='fecha_cada_" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' value='" & ds.Tables(0).Rows(i)("fecha").ToString() & "' orp3='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'  condicion1='" & ds.Tables(0).Rows(i)("condicion").ToString() & "'>
								</td>"

					'	<p style='font-size: 1em;'> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</p>



					For x As Integer = 0 To 30
						Dim x2 As Integer = x + 1


						'tabla &= "<td class='btn_td_mensual' id='" & i & "_" & x & "_" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' dia='" & x & "'  data-count='0'> 
						'			<p id='icon_" & i & "_" & x & "_" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>
						'				<i   class='fa fa-times' style='font-size:10px;' >
						'					</i>
						'			</p>
						'			</td>"

						tabla &= "<td class='btn_td_mensual' id='" & x2 & "_" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'  data-count='0' fecha='0' > 
									<div  id='icon_" & x2 & "_" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'  >
										
									</div>
								</td>"
					Next



					tabla &= "</tr>"



				Next




			End If

		End If

		Return tabla


	End Function

	Public Function ObtenerFecha(ByVal nColumnas As Integer, ByVal curso_dos As Integer, ByVal mes_final As Date) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		NomParam.Add("@curso") : ValParam.Add(curso_dos)
		NomParam.Add("@fecha_mensual") : ValParam.Add(mes_final)
		NomParam.Add("@Bloque") : ValParam.Add("Get Estudiante Mensual")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					'tabla &= "<input type='hidden' id='fecha' value='" & ds.Tables(0).Rows(i)("fecha").ToString() & " '  />
					'			<input type='hidden' id='cordenadas' value='" & ds.Tables(0).Rows(i)("cordenadas").ToString() & " '  />
					'			<input type='hidden' id='orp' value='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & " '  />"
					tabla &= ds.Tables(0).Rows(i)("fecha").ToString() & "," & ds.Tables(0).Rows(i)("cordenadas").ToString() & "," & ds.Tables(0).Rows(i)("orp").ToString() & "||"






				Next




			End If

		End If

		Return tabla


	End Function

	Public Function MostrarDe(ByVal nColumnas As Integer, ByVal curso_dos As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		NomParam.Add("@curso") : ValParam.Add(curso_dos)
		NomParam.Add("@Bloque") : ValParam.Add("MostrarDe")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					For x As Integer = 1 To nColumnas
						tabla &= "<tr>
								<td width='3em;'> " & ds.Tables(0).Rows(i)("PersonId").ToString() & "
								<td> <div  style='width:300px;'> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</div>
								</td>
								"
						tabla &= "<td  class='btn_td_mensual' id='" & i & "_" & x & "_" & ds.Tables(0).Rows(i)("PersonId").ToString() & "' dia='" & x & "'>
									<input class='btnEdita' id='" & x & "' type='hidden' value='" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'/>
										<p  id='icon" & i & "_" & x & "_" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'>
											<i id='" & i & "_" & x & "_" & ds.Tables(0).Rows(i)("PersonId").ToString() & "'  class='fa fa-circle' style='font-size:10px;'>
											</i>
										</p>
								</td>"
					Next






					tabla &= "</tr>"
				Next




			End If

		End If

		Return tabla


	End Function

	Public Function FirmaDocente(ByVal id As Integer, ByVal firma_ok As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""
		NomParam.Add("@asignatura") : ValParam.Add(id)
		NomParam.Add("@Bloque") : ValParam.Add("FirmaDocente")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					Dim estado As String = ""

					If firma_ok = 0 Then

						tabla &= "<tr>
								<td> " & ds.Tables(0).Rows(0)("Nombre").ToString() & "</td>
								<td>  " & ds.Tables(0).Rows(0)("cargo").ToString() & " </td>
								<td> <div id='estado'> Sin Estado</div></td>
								<td> <div id='hora_firma'>" & ds.Tables(0).Rows(0)("digitalRandomKeyDate").ToString() & " </div></td>
								<td>
									<div class='col-md-12 mb-12'>
										<div class='row'>
											<div class='col-6'>
												<input type='number' id='otp' class='form-control ' required=''/>
											</div>
											<div class='col-6'>
												<button type='button' class='btn btn-primary btnValidarCod' id='" & ds.Tables(0).Rows(0)("rut").ToString() & "' data='" & ds.Tables(0).Rows(0)("OrganizationPersonRoleId").ToString() & "'  > Validar Código</button>
											</div>
										</div>
									</div>
								</td>
							</tr>"



					ElseIf firma_ok = 1 Then
						tabla &= "<tr>
								<td> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</td>
								<td>  " & ds.Tables(0).Rows(i)("cargo").ToString() & " </td>
								<td> <div id='estado'>Firmado</div></td>
								<td> <div id='hora_firma'>" & ds.Tables(0).Rows(0)("digitalRandomKeyDate").ToString() & " </div></td>
								<td>
									<div class='col-md-12 mb-12'>
										<div class='row'>
											<div class='col-6'>
												<input type='number' id='otp' class='form-control ' disabled required=''/>
											</div>
											<div class='col-6'>
												<button type='button' class='btn btn-success btnValidarCod' id='" & ds.Tables(0).Rows(0)("rut").ToString() & "' data='" & ds.Tables(0).Rows(0)("OrganizationPersonRoleId").ToString() & "'  disabled> Validar Código</button>
											</div>
										</div>
									</div>
								</td>
							</tr>"
					End If



					'tabla &= "<div class='table-responsive'>
					'				<table class='table table-striped'>
					'						<thead>
					'							<th>
					'								Nombre
					'							</th>
					'							<th>
					'								Cargo
					'							</th>
					'							<th>
					'								Estado
					'							</th>
					'							<th>
					'								Firma
					'							</th>
					'						</thead>
					'						<tbody>

					'						</tbody>
					'				</table>
					'			</div>"
				Next


			End If

		End If

		Return tabla


	End Function
	Public Function InsertAsistenciaAll(ByVal fecha As String,
										ByVal AsistenciaEstado As Integer, ByVal cordenadas As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta


		Dim tabla As String = ""
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		'NomParam.Add("@OrganizationPersonRole") : ValParam.Add(orp)
		NomParam.Add("@AsistenciaEstado") : ValParam.Add(AsistenciaEstado)
		NomParam.Add("@CordenadasAll") : ValParam.Add(cordenadas)
		NomParam.Add("@Bloque") : ValParam.Add("Insert Asistencia All")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)

		Return ms.GetTextCode(150)



	End Function
	Public Function UpdateAsistenciaMensual(ByVal dia As Integer, ByVal orp As Integer,
								ByVal condicion As Integer, ByVal mes As String, ByVal RoleEventId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta


		Dim tabla As String = ""
		NomParam.Add("@Dia_Mensual") : ValParam.Add(dia)
		'NomParam.Add("@OrganizationPersonRole") : ValParam.Add(orp)
		NomParam.Add("@OrganizationPersonRole") : ValParam.Add(orp)
		NomParam.Add("@AsistenciaEstado") : ValParam.Add(condicion)
		NomParam.Add("@RoleEventId") : ValParam.Add(RoleEventId)
		NomParam.Add("@Mes") : ValParam.Add(mes)
		NomParam.Add("@Bloque") : ValParam.Add("UpdateAsistenciaMensual")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)

		Return ms.GetTextCode(150)



	End Function
	Public Function InsertFirma(ByVal roleEventId As String, ByVal fecha As String,
							   ByVal otp2 As String, ByVal ORP As Integer, ByVal CourseSectionScheduleId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta


		Dim tabla As String = ""
		NomParam.Add("@RoleEventId2") : ValParam.Add(roleEventId)
		NomParam.Add("@OrganizationPersonRole") : ValParam.Add(ORP)
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		NomParam.Add("@otp2") : ValParam.Add(otp2)
		NomParam.Add("@CourseSectionScheduleId") : ValParam.Add(CourseSectionScheduleId)
		NomParam.Add("@Bloque") : ValParam.Add("InsertFirma")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		Return ms.GetTextCode(150)



	End Function
	Public Function AnularFirma(ByVal CourseSectionScheduleId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta


		Dim tabla As String = ""
		NomParam.Add("@CourseSectionScheduleId") : ValParam.Add(CourseSectionScheduleId)
		NomParam.Add("@Bloque") : ValParam.Add("AnularFirma")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		Return ms.GetTextCode(150)
	End Function
	Public Function ValidarFirma(ByVal firma_a As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta


		Dim tabla As String = ""
		NomParam.Add("@RoleEventId2") : ValParam.Add(firma_a)
		'NomParam.Add("@OrganizationPersonRole") : ValParam.Add(orp)
		NomParam.Add("@Bloque") : ValParam.Add("ValidarFirma")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then

			If ds.Tables(0).Rows.Count > 0 Then

				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("condicion").ToString()

				Next


			End If

		End If

		Return tabla



	End Function


	Public Function InsertAsistencia(ByVal orp As Integer, ByVal fecha As Date,
									 ByVal AsistenciaEstado As Integer, ByVal RoleAttenceId As Integer,
									 ByVal cordenadas As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta

		Dim tabla As String = ""

		NomParam.Add("@Bloque") : ValParam.Add("Insert Attendance Event")
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		NomParam.Add("@OrganizationPersonRole") : ValParam.Add(orp)
		NomParam.Add("@AsistenciaEstado") : ValParam.Add(AsistenciaEstado)
		NomParam.Add("@Cordenadas") : ValParam.Add(cordenadas)
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)
		Return ms.GetTextCode(150)



	End Function
	Public Function UpdateAsistencia(ByVal orp As Integer, ByVal fecha As Date, ByVal AsistenciaEstado As Integer, ByVal cordenadas As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim ms As New cls_CodigosRespuesta


		Dim tabla As String = ""
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		NomParam.Add("@OrganizationPersonRole") : ValParam.Add(orp)
		NomParam.Add("@AsistenciaEstado") : ValParam.Add(AsistenciaEstado)
		NomParam.Add("@Cordenadas") : ValParam.Add(cordenadas)
		NomParam.Add("@Bloque") : ValParam.Add("Update Attendance Event")
		ds = consulta.ExecuteSQL("IE_ASISTENCIA", NomParam, ValParam)

		Return ms.GetTextCode(150)



	End Function





End Class
