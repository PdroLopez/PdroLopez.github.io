Imports Datos
Public Class cls_ConfiguracionLocal
	Public Function SelectConfiguracion() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("SelectConfiguracion")

		ds = consulta.ExecuteSQL("IE_CONFIGURACION_LOCAL", NomParam, ValParam)
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
	Public Function AgregarConfiguracionLocal(ByVal valor As String, ByVal configuracion As Integer, ByVal ColegioID As Integer) As String
		' strFonos: Contiene los fonos separados por ||
		'//hay que agregar person_id
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("AgregarConfiguracionLocal")
		NomParam.Add("@Valor") : ValParam.Add(valor)
		NomParam.Add("@ConfiguracionCentralId") : ValParam.Add(configuracion)
		NomParam.Add("@ColegioId") : ValParam.Add(ColegioID)

		consulta.ExecuteSQL("IE_CONFIGURACION_LOCAL", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function GetData(ByVal ColegioID As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""

		NomParam.Add("@Bloque") : ValParam.Add("GetData")
		NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)

		ds = consulta.ExecuteSQL("IE_CONFIGURACION_LOCAL", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
								  "<td class='align-middle text-left' > " &
										  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>
                                                " & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
											"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>
                                                 " & "<i class='fa fa-trash-alt'> </i>" & "</button>" &
									"</td>" &
								   "<td id='perid" & ds.Tables(0).Rows(i)("id").ToString() & "'>" & ds.Tables(0).Rows(i)("id").ToString() & "</td>" &
								  "<td id='FirstName_" & ds.Tables(0).Rows(i)("valor").ToString() & "'> <input id='valor_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("valor").ToString() & "' />" & ds.Tables(0).Rows(i)("valor").ToString() & "</td>" &
								   "<td id='FirstName_" & ds.Tables(0).Rows(i)("configuracion").ToString() & "'> <input id='configuracion_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("ConfiguracionID").ToString() & "' />" & ds.Tables(0).Rows(i)("configuracion").ToString() & "</td>" &
								"</tr>"

				Next
			End If

		End If

		Return tabla
	End Function
	Public Function EditarConfiguracionLocal(ByVal valor As String, ByVal configuracion As Integer, ByVal ConfiguracionLocalId As Integer) As String
		' strFonos: Contiene los fonos separados por ||
		'//hay que agregar person_id
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("EditarConfiguracionLocal")
		NomParam.Add("@Valor") : ValParam.Add(valor)
		NomParam.Add("@ConfiguracionCentralId") : ValParam.Add(configuracion)
		NomParam.Add("@ConfiguracionLocalId") : ValParam.Add(ConfiguracionLocalId)
		consulta.ExecuteSQL("IE_CONFIGURACION_LOCAL", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function EliminarConfiguracionLocal(ByVal ConfiguracionLocalId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet

		NomParam.Add("@Bloque") : ValParam.Add("EliminarConfiguracionLocal")
		NomParam.Add("@ConfiguracionLocalId") : ValParam.Add(ConfiguracionLocalId)
		ds = consulta.ExecuteSQL("IE_CONFIGURACION_LOCAL", NomParam, ValParam)
		Return "El comando N° 155 fue ejecutado con éxito."



	End Function
End Class
