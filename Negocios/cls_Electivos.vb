Imports Datos
Public Class cls_Electivos
	Public Function GetAsignatura(ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Get Asignatura v2")

		ds = consulta.ExecuteSQL("IE_ASIGNATURA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''>Selecione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option value='" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'>" & ds.Tables(0).Rows(i)("Asignatura").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function GetEstudiantes(ByVal asignatura As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
		NomParam.Add("@Bloque") : ValParam.Add("Get Estudiante")

		ds = consulta.ExecuteSQL("IE_ELECTIVOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<tr> " &
					"<td>" &
					"<div class='form-check'> " &
					"<input type='checkbox' name='nombre_estudiante'  data='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' class='form-check-input btn_prueba' id='nombre" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' value='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'>" &
					"<label class='form-check-label'>" & ds.Tables(0).Rows(i)("Nombre").ToString() &
					"</label></td> " & "</tr>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function AsignaturaElectivas(ByVal asignatura As Integer, ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Get Asignatura Electivas")

		ds = consulta.ExecuteSQL("IE_ELECTIVOS", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<tr> " &
					"<td>" &
					"<div class='form-check'> " &
					"<input type='checkbox' name='nombre_estudiante'  data='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' class='form-check-input btn_prueba' id='nombre" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "' value='" & ds.Tables(0).Rows(i)("OrganizationPersonRoleId").ToString() & "'>" &
					"<label class='form-check-label'>" & ds.Tables(0).Rows(i)("Nombre").ToString() &
					"</label></td> " & "</tr>"
				Next
			End If

		End If

		Return tabla
	End Function

	Public Function IngresarElectivos(ByVal estudiantes As String, ByVal asignatura As Integer, ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim mensaje As New cls_CodigosRespuesta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Estudiantes") : ValParam.Add(estudiantes)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
		NomParam.Add("@Curso") : ValParam.Add(curso)

		NomParam.Add("@Bloque") : ValParam.Add("Insert Electivos")

		ds = consulta.ExecuteSQL("IE_ELECTIVOS", NomParam, ValParam)

		Return mensaje.GetTextCode(150)
	End Function
	Public Function QuitarElectivos(ByVal estudiantes As String, ByVal asignatura As Integer, ByVal curso As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim mensaje As New cls_CodigosRespuesta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Estudiantes") : ValParam.Add(estudiantes)
		NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
		NomParam.Add("@Curso") : ValParam.Add(curso)
		NomParam.Add("@Bloque") : ValParam.Add("Quitar Electivos")

		ds = consulta.ExecuteSQL("IE_ELECTIVOS", NomParam, ValParam)

		Return mensaje.GetTextCode(150)
	End Function

	Public Function MostrarElectivos(ByVal estudiantes As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim mensaje As New cls_CodigosRespuesta
		Dim ds As New DataSet

		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Estudiantes") : ValParam.Add(estudiantes)
		NomParam.Add("@Bloque") : ValParam.Add("Show Electivos")

		ds = consulta.ExecuteSQL("IE_ELECTIVOS", NomParam, ValParam)

		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<tr> " &
					"<td>" &
					"<div class='form-check'> " &
					"<input type='checkbox' name='nombre_estudiante'  data='" & ds.Tables(0).Rows(i)("EstudianteId").ToString() & "' class='form-check-input btn_prueba' id='nombre" & ds.Tables(0).Rows(i)("EstudianteId").ToString() & "' value='" & ds.Tables(0).Rows(i)("EstudianteId").ToString() & "'>" &
					"<label class='form-check-label'>" & ds.Tables(0).Rows(i)("Nombre").ToString() &
					"</label></td> " & "</tr>"
				Next
			End If

		End If

		Return tabla
	End Function
End Class
