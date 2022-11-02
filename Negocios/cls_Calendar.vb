Imports Datos
Public Class cls_Calendar
    Public Function IngresarCalendario(ByVal strAsignaturas As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@DtsHorario") : ValParam.Add(strAsignaturas)
		NomParam.Add("@titulo") : ValParam.Add("Insert Calendar")
		consulta.ExecuteSQL("IE_CALENDAR", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
End Class
