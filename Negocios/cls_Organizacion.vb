Imports Datos
Public Class cls_Organizacion
	Private OrganizationId As Integer
	Private Name As String
	Private RefOrganizationTypeId As Integer
	Private ShorName As String
	Public Property _OrganizationId As Integer
	Public Property _Name As String
	Public Property _RefOrganizationTypeId As Integer
	Public Property _ShorName As String

	Public Function GuardarCurso(ByVal letra As String, ByVal tipo_organizacion As Integer
								  ) As String


		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(letra)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarCursos(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Cursos Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarAsignatura(ByVal asignatura As String, ByVal tipo_organizacion As Integer
							  ) As String


		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(asignatura)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarAsignatura(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Asignatura Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarJornada(ByVal jornada As String, ByVal tipo_organizacion As Integer
						  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(jornada)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarJornada(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Jornada Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarTipoEnseñanza(ByVal tipo As String, ByVal tipo_organizacion As Integer
					  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(tipo)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarTipoEnseñanza(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Tipo Enseñanza Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarEspecialidad(ByVal especialidad As String, ByVal tipo_organizacion As Integer
				  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(especialidad)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarEspecialidad(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Especialidad Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarModalidad(ByVal modalidad As String, ByVal nombre_corto As String, ByVal idColegio As Integer
			  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Modalidad Insert")
		NomParam.Add("@Name") : ValParam.Add(modalidad)
		NomParam.Add("@ShortName") : ValParam.Add(nombre_corto)
		NomParam.Add("@idColegio") : ValParam.Add(idColegio)
		consulta.ExecuteSQL("IE_MODALIDAD", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarModalidad() As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Modalidad Select")
		ds = consulta.ExecuteSQL("IE_MODALIDAD", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarNivelEducacion(ByVal nivelEducacion As String, ByVal tipo_organizacion As Integer
			  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(nivelEducacion)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarNivelEducacion(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Nivel Educacion Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarRamaEspecialidad(ByVal rama As String, ByVal tipo_organizacion As Integer
			  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(rama)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarRamaEspecialidad(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Rama Especialidad Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarSector(ByVal sector As String, ByVal tipo_organizacion As Integer
		  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(sector)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarSector(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Sector Economico Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function
	Public Function IngresarTipoCurso(ByVal tipoCurso As String, ByVal tipo_organizacion As Integer
		  ) As String
		Dim consulta As New clsConsulta
		Dim NomParam, ValParam As New ArrayList
		Dim prueba As String
		prueba = ""
		NomParam.Add("@Bloque") : ValParam.Add("Organization Insert")
		NomParam.Add("@Name") : ValParam.Add(tipoCurso)
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		Return "El comando N° 150 fue ejecutado con éxito."
	End Function
	Public Function MostrarTipoCurso(ByVal tipo_organizacion As Integer) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet


		Dim tabla As String = "No hay datos para mostrar"

		NomParam.Add("@Bloque") : ValParam.Add("Tipo Curso Select")
		NomParam.Add("@RefOrganizationTypeId") : ValParam.Add(tipo_organizacion)
		ds = consulta.ExecuteSQL("IE_ORGANIZATION", NomParam, ValParam)
		If ds.Tables.Count > 0 Then
			If ds.Tables(0).Rows.Count > 0 Then
				tabla = ""
				For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

					tabla &= "<tr>" &
									  "<td class='align-middle text-left' > " &
									  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
										"<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
										"<td id='OrganizationId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
									   "<td id='Name" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
									  "<td id='RefOrganizationTypeId" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("RefOrganizationTypeId").ToString() & "</td>" &
									"</tr>"
				Next
			End If

		End If

		Return tabla



	End Function

End Class
