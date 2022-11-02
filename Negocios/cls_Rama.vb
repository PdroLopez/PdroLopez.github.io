Imports Datos
Public Class cls_Rama
	Public Function SelectRamaEspecialidad() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Rama Select Input")

		ds = consulta.ExecuteSQL("IE_RAMA", NomParam, ValParam)
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
	Public Function GetRama(ByVal rama As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@id_rama") : ValParam.Add(rama)
		NomParam.Add("@Bloque") : ValParam.Add("Get Rama")

		ds = consulta.ExecuteSQL("IE_RAMA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<input type='hidden' id='rama_hidden' value='" & ds.Tables(0).Rows(i)("Name").ToString() & "'/> "
				Next
			End If

		End If

		Return tabla

	End Function
End Class
