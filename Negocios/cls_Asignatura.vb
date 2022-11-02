Imports Datos
Public Class cls_Asignatura
	Public Function IngresarAsignatura(ByVal incide As Integer, ByVal curso As Integer,
									   ByVal tipo_asignatura As Integer, ByVal tipo_calificacion As Integer,
									  ByVal nombre As String, ByVal cod_m As String, ByVal id As Integer,
									   ByVal max_capacidad As Integer, ByVal token As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim tabla As String = "No hay datos para mostrar"
		If (id > 0) Then
			NomParam.Add("@Bloque") : ValParam.Add("Update Asignatura")
			NomParam.Add("@AsignaturaId") : ValParam.Add(id)
		Else
			NomParam.Add("@Bloque") : ValParam.Add("Insert Asignatura")
		End If
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Cod_Ministerial") : ValParam.Add(cod_m)
		NomParam.Add("@nombre_asignatura") : ValParam.Add(nombre)
		NomParam.Add("@Tipo_Asignatura") : ValParam.Add(tipo_asignatura)
		NomParam.Add("@Tipo_Calificacion") : ValParam.Add(tipo_calificacion)
		NomParam.Add("@MaximumCapacity") : ValParam.Add(max_capacidad)
		NomParam.Add("@Token") : ValParam.Add(token)

		NomParam.Add("@Incide") : ValParam.Add(incide)
		consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function SelectCurso(ByVal ColegioID As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Bloque") : ValParam.Add("Course Select HTML")
		NomParam.Add("@id_colegio") : ValParam.Add(ColegioID)

		ds = consulta.ExecuteSQL("IE_COURSE", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("IDCurso").ToString() & "'> " & ds.Tables(0).Rows(i)("Curso").ToString() & "°" & "</option>"
				Next
			End If
		End If
		Return tabla
	End Function
	Public Function GetAsignatura(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Get Asignatura")

		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'>" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "</td>" &
										"<td id='Asignatura" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'>" & ds.Tables(0).Rows(i)("Asignatura").ToString() & "</td>" &
										"<td id='Tipo_asignatura" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("tipo_asignatura_id").ToString() & "</td>" &
										"<td id='Tipo_calificacion" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("tipo_calificacion_id").ToString() & "</td>" &
										"<td id='Codigo_Ministerial" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "' style='display:none;'>" & ds.Tables(0).Rows(i)("Codigo_Ministerial").ToString() & "</td>" &
					"</tr>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function ExisteAsignatura(ByVal curso As Integer,
									   ByVal nombre As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@nombre_asignatura") : ValParam.Add(nombre)
		NomParam.Add("@Bloque") : ValParam.Add("ExisteAsignatura")
		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= ds.Tables(0).Rows(i)("existe").ToString()
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function EliminarAsignatura(ByVal AsignaturaId As Integer, ByVal token As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@AsignaturaId") : ValParam.Add(AsignaturaId)
		NomParam.Add("@Token") : ValParam.Add(token)
		NomParam.Add("@Bloque") : ValParam.Add("Delete Asignatura")
		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		Return "El comando N° 155 fue ejecutado con éxito."
	End Function
End Class
