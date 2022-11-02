Imports Datos

Public Class cls_ConfiguracionSistema
	Public Function AgregarConfiguracionSistema(ByVal valor As String, ByVal configuracion As Integer) As String
		' strFonos: Contiene los fonos separados por ||
		'//hay que agregar person_id
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("AgregarConfiguracionSistema")
		NomParam.Add("@Valor") : ValParam.Add(valor)
		NomParam.Add("@ConfiguracionCentralId") : ValParam.Add(configuracion)

		consulta.ExecuteSQL("IE_CONFIGURACION_SISTEMA", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function GetData() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = ""

		NomParam.Add("@Bloque") : ValParam.Add("GetData")

		ds = consulta.ExecuteSQL("IE_CONFIGURACION_SISTEMA", NomParam, ValParam)
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
	Public Function EditarConfiguracionSistema(ByVal valor As String, ByVal configuracion As Integer,
												ByVal ConfiguracionSistemaId As Integer) As String
		' strFonos: Contiene los fonos separados por ||
		'//hay que agregar person_id
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("EditarConfiguracionSistema")
		NomParam.Add("@Valor") : ValParam.Add(valor)
		NomParam.Add("@ConfiguracionCentralId") : ValParam.Add(configuracion)
		NomParam.Add("@ConfiguracionSistemaId") : ValParam.Add(ConfiguracionSistemaId)
		consulta.ExecuteSQL("IE_CONFIGURACION_SISTEMA", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function EliminarConfiguracionSistema(ByVal ConfiguracionSistemaId As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		NomParam.Add("@Bloque") : ValParam.Add("EliminarConfiguracionSistema")
		NomParam.Add("@ConfiguracionLocalId") : ValParam.Add(ConfiguracionSistemaId)
		ds = consulta.ExecuteSQL("IE_CONFIGURACION_SISTEMA", NomParam, ValParam)
		Return "El comando N° 155 fue ejecutado con éxito."
	End Function
End Class
