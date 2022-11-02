Imports Datos

Public Class cls_Leccionario
	Public Function GetAsignatura(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get Asignatura")
		NomParam.Add("@Curso") : ValParam.Add(curso)
		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("idAsignatura").ToString() & "'> " & ds.Tables(0).Rows(i)("Asignatura").ToString() & "</option>"
				Next
			End If
		End If
		Return tabla
	End Function
	Public Function Ingresar(ByVal unidad As Integer, ByVal habilidad As Integer,
							  ByVal objetivo As Integer, ByVal fecha As Date, ByVal curso As Integer,
							 ByVal asignatura As Integer, ByVal LeccionarioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Insert Leccionario")
		NomParam.Add("@unidad") : ValParam.Add(unidad)
		NomParam.Add("@objetivo") : ValParam.Add(objetivo)
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		NomParam.Add("@habilidad") : ValParam.Add(habilidad)
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)

		consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)

		Return mensaje.GetTextCode(150)
	End Function
	Public Function EditarLeccionario(ByVal unidad As Integer, ByVal habilidad As Integer,
							  ByVal objetivo As Integer, ByVal fecha As Date, ByVal LeccionarioId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Update Leccionario")
		NomParam.Add("@unidad") : ValParam.Add(unidad)
		NomParam.Add("@objetivo") : ValParam.Add(objetivo)
		NomParam.Add("@fecha") : ValParam.Add(fecha)
		NomParam.Add("@habilidad") : ValParam.Add(habilidad)
		NomParam.Add("@idLeccionario") : ValParam.Add(LeccionarioId)


		consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)

		Return mensaje.GetTextCode(150)
	End Function
	Public Function IngresarUnidad(ByVal nombre_unidad As String,
							 ByVal descripcion_unidad As String,
								   ByVal curso As Integer, ByVal asignatura As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Insert Unidad")
		NomParam.Add("@nombre_unidad") : ValParam.Add(nombre_unidad)
		NomParam.Add("@descripcion_unidad") : ValParam.Add(descripcion_unidad)
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)

		consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		Return mensaje.GetTextCode(150)
	End Function
	Public Function IngresarObjetivo(ByVal nombre_unidad As String,
							 ByVal descripcion_unidad As String, ByVal unidad As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Insert Objetivo")
		NomParam.Add("@nombre_unidad") : ValParam.Add(nombre_unidad)
		NomParam.Add("@unidad") : ValParam.Add(unidad)
		NomParam.Add("@descripcion_unidad") : ValParam.Add(descripcion_unidad)
		consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		Return mensaje.GetTextCode(150)
	End Function
	Public Function IngresarHabilidad(ByVal nombre_unidad As String,
							 ByVal descripcion_unidad As String, ByVal objetivo As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Insert Habilidad")
		NomParam.Add("@nombre_unidad") : ValParam.Add(nombre_unidad)
		NomParam.Add("@objetivo") : ValParam.Add(objetivo)
		NomParam.Add("@descripcion_unidad") : ValParam.Add(descripcion_unidad)
		consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		Return mensaje.GetTextCode(150)
	End Function
	Public Function ActualizarDescripcion(ByVal descripcion As String, ByVal idLeccionario As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim mensaje As New cls_CodigosRespuesta

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Update Descripcion")
		NomParam.Add("@descripcion_leccionario") : ValParam.Add(descripcion)
		NomParam.Add("@idLeccionario") : ValParam.Add(idLeccionario)


		consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)

		Return mensaje.GetTextCode(160)
	End Function
	Public Function selectUnidad(ByVal curso As Integer, ByVal asignatura As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Select Unidad")
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)

		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("IDUnidad").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function selectObjetivo() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Select Objetivo")

		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("ObjetivoID").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function

	Public Function GetHabilidadSelect(ByVal objetivo_input As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@objetivo") : ValParam.Add(objetivo_input)
		NomParam.Add("@Bloque") : ValParam.Add("GetHabilidadSelect")

		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("Habilidad_ID").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function getTabla(ByVal curso As Integer, ByVal asignatura As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get tabla")
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					Dim descripcion As String = ds.Tables(0).Rows(i)("descripcion").ToString()
					Dim mes As String = ds.Tables(0).Rows(i)("mes").ToString()
					If mes = "JANUARY" Then
						mes = "ENERO"
					End If
					If mes = "FEBRUARY" Then
						mes = "FEBRERO"
					End If
					If mes = "MARCH" Then
						mes = "MARZO"
					End If
					If mes = "APRIL" Then
						mes = "ABRIL"
					End If
					If mes = "MAY" Then
						mes = "MAYO"
					End If
					If mes = "JUNE" Then
						mes = "JUNIO"
					End If
					If mes = "JULY" Then
						mes = "JULIO"
					End If
					If mes = "AUGUST" Then
						mes = "AGOSTO"
					End If
					If mes = "SEPTEMBER" Then
						mes = "Septiembre"
					End If
					If mes = "OCTOBER" Then
						mes = "Octubre"
					End If
					If mes = "NOVEMBER" Then
						mes = "Noviembre"
					End If
					If mes = "DECEMBER" Then
						mes = "Diciembre"
					End If

					If descripcion = "NULL" Then
						descripcion = ""
					End If
					tabla &= "<tr style=''>" &
						"<td> " & ds.Tables(0).Rows(i)("dia").ToString() &
						"<br>" & mes & "</td>" &
						"<td>
							<div class='card' style='width: 1000px; height:110px;'>
								<div class='card-body'  id='" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "'>
									 <p> Unidad:    " & ds.Tables(0).Rows(i)("Unidad").ToString() & "</p>
									 <p> Objetivo:  " & ds.Tables(0).Rows(i)("Objetivo").ToString() & "</p>
									 <p> Habilidad:   " & ds.Tables(0).Rows(i)("Habilidad").ToString() & "</p>
									 <input type='hidden' id='BirthDate" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "' value='" & ds.Tables(0).Rows(i)("FechaC").ToString() & "' />
									 <input type='hidden' id='Unidad" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "' value='" & ds.Tables(0).Rows(i)("idUnidad").ToString() & "' />
									 <input type='hidden' id='Objetivo" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "' value='" & ds.Tables(0).Rows(i)("ObjetivoID").ToString() & "' />
									 <input type='hidden' id='Habilidad" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "' value='" & ds.Tables(0).Rows(i)("HabilidadID").ToString() & "' />
								</div>
							</div>
							<div class='row'>
								 <div class='col-6'>
									 			<textarea placeholder='Actividades...'  class='form-control' rows='2'  id= 'txtDescripcion_" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "' style='width:400px;'>" & descripcion & "</textarea>
								</div>
							  <div class='col-3'>
									<button class='btn btn-outline-primary btn-icon-sm btn_actualizar' type='button' id='" & ds.Tables(0).Rows(i)("LeccionarioId").ToString() & "'> Actualizar
									 </button>
								</div>
							</div>
						</td>" &
						"</tr>"
					'tabla &= "<option value='" & ds.Tables(0).Rows(i)("ObjetivoID").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetHabilidad(ByVal objetivo As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get Habilidad")
		NomParam.Add("@objetivo") : ValParam.Add(objetivo)
		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("Habilidad_ID").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetObjetivoSelect(ByVal unidad As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get GetObjetivoSelect")
		NomParam.Add("@unidad") : ValParam.Add(unidad)
		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("ObjetivoID").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetObjetivo(ByVal unidad As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Get Objetivo")
		NomParam.Add("@unidad") : ValParam.Add(unidad)
		ds = consulta.ExecuteSQL("IE_LECCIONARIOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("ObjetivoID").ToString() & "'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function

End Class
