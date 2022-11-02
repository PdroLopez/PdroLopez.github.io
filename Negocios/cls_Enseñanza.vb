Imports Datos
Public Class cls_Enseñanza
	Public Function SelectEnseñanza(ByVal nivel As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@id_nivel") : ValParam.Add(nivel)
		NomParam.Add("@Bloque") : ValParam.Add("Enseñanza Select2")

		ds = consulta.ExecuteSQL("IE_COD_ENSEÑANZA", NomParam, ValParam)
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
	Public Function GetEnseñanza(ByVal tipo_enseñanza As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@id_enseñanza") : ValParam.Add(tipo_enseñanza)
		NomParam.Add("@Bloque") : ValParam.Add("Get TipoEnseñanza")

		ds = consulta.ExecuteSQL("IE_COD_ENSEÑANZA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<input type='hidden' id='enseñanza_hidden' value='" & ds.Tables(0).Rows(i)("Name").ToString() & "'/> "
				Next
			End If

		End If

		Return tabla
	End Function
End Class
