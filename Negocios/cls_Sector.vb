Imports Datos
Public Class cls_Sector
	Public Function ChangeSector(ByVal rama As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@cod_rama") : ValParam.Add(rama)
		NomParam.Add("@Bloque") : ValParam.Add("Sector Select2")

		ds = consulta.ExecuteSQL("IE_SECTOR", NomParam, ValParam)
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
	Public Function GetSector(ByVal sector As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@id_sector") : ValParam.Add(sector)
		NomParam.Add("@Bloque") : ValParam.Add("Get Sector")

		ds = consulta.ExecuteSQL("IE_SECTOR", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<input type='hidden' id='sector_hidden' value='" & ds.Tables(0).Rows(i)("Name").ToString() & "'/> "
				Next
			End If

		End If

		Return tabla
	End Function
End Class
