Imports Datos
Public Class cls_Modalidad
	Public Function SelectModalidad() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Modalidad Select Input")

		ds = consulta.ExecuteSQL("IE_MODALIDAD", NomParam, ValParam)
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
	Public Function GetModalidad(ByVal modalidad As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@id_modalidad") : ValParam.Add(modalidad)
		NomParam.Add("@Bloque") : ValParam.Add("Get Modalidad")

		ds = consulta.ExecuteSQL("IE_MODALIDAD", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<input type='hidden' id='modalidad_hidden' value='" & ds.Tables(0).Rows(i)("Name").ToString() & "'/> "
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function ValidacionModalidad(ByVal modalidad As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@Modalidad") : ValParam.Add(modalidad)
		NomParam.Add("@Bloque") : ValParam.Add("Modalidad Validacion")
		ds = consulta.ExecuteSQL("IE_MODALIDAD", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla = ds.Tables(0).Rows(i)("modalidad").ToString()
				Next
			End If

		End If

		Return tabla
	End Function

End Class
