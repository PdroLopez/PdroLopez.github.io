Imports Datos
Public Class cls_Menu
	Public Function SelectIcon() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("SelectIcon")

		ds = consulta.ExecuteSQL("IE_MENU", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function
	Public Function SelectPadre(ByVal ColegioID As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)

		NomParam.Add("@Bloque") : ValParam.Add("SelectPadre")

		ds = consulta.ExecuteSQL("IE_MENU", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = "<option value=''> Seleccione...</option>"
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
					tabla &= "<option  value='" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "</option>"
				Next
			End If

		End If

		Return tabla
	End Function

	Public Function AgregarPadre(ByVal nombre As String, ByVal icons As Integer,
								  ByVal orden As Integer, ByVal ColegioID As Integer) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("AgregarPadre")
		NomParam.Add("@nombre") : ValParam.Add(nombre)
		NomParam.Add("@icons") : ValParam.Add(icons)
		NomParam.Add("@orden") : ValParam.Add(orden)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)

		consulta.ExecuteSQL("IE_MENU", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function

	Public Function AgregarSubMenu(ByVal nombre As String,
								   ByVal icons As Integer,
							   ByVal padre As Integer,
								   ByVal url As String,
									ByVal orden As Integer,
									ByVal contacto_emergencia As Integer,
								   ByVal ColegioID As Integer) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("AgregarSubMenu")
		NomParam.Add("@nombre") : ValParam.Add(nombre)
		NomParam.Add("@icons") : ValParam.Add(icons)
		NomParam.Add("@padre") : ValParam.Add(padre)
		NomParam.Add("@orden") : ValParam.Add(orden)
		NomParam.Add("@vigencia") : ValParam.Add(contacto_emergencia)
		NomParam.Add("@url") : ValParam.Add(url)
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)

		consulta.ExecuteSQL("IE_MENU", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function

	Public Function MostrarSubMenu() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""

		NomParam.Add("@Bloque") : ValParam.Add("MostrarSubMenu")
		'NomParam.Add("@padre") : ValParam.Add(padre)

		ds = consulta.ExecuteSQL("IE_MENU", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
								  "<td class='align-middle text-left' > " &
								  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
									"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
								   "<td id='perid" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'>" & ds.Tables(0).Rows(i)("MenuId").ToString() & "</td>" &
								  "<td id='FirstName_" & ds.Tables(0).Rows(i)("nombre").ToString() & "'> <input id='nombre_" & ds.Tables(0).Rows(i)("MenuId").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("nombre").ToString() & "' />" & ds.Tables(0).Rows(i)("nombre").ToString() & "</td>" &
								"</tr>"

				Next
			End If

		End If

		Return tabla
	End Function
End Class
