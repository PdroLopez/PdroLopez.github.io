Imports Datos
Public Class cls_Jornada
	Public Function SelectJornada() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Jornada Select Input")

		ds = consulta.ExecuteSQL("IE_JORNADA", NomParam, ValParam)
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
	Public Function GetJornada(ByVal jornada As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@id_jornada") : ValParam.Add(jornada)
		NomParam.Add("@Bloque") : ValParam.Add("Get Jornada")

		ds = consulta.ExecuteSQL("IE_JORNADA", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<input type='hidden' id='jornada_hidden' value='" & ds.Tables(0).Rows(i)("name").ToString() & "'/> "
				Next
			End If

		End If

		Return tabla
	End Function
End Class
