Imports Datos
Public Class cls_Ambito
	Public Function IngresarAmbito(ByVal nombre As String) As String
		Dim NomParam, ValParam As New ArrayList
		Dim consulta As New clsConsulta
		Dim ds As New DataSet
		Dim tabla As String = "No hay datos para mostrar"
        'If (id > 0) Then
        '	NomParam.Add("@Bloque") : ValParam.Add("Update Asignatura")
        '	NomParam.Add("@AsignaturaId") : ValParam.Add(id)
        'Else
        '	NomParam.Add("@Bloque") : ValParam.Add("Insert Asignatura")
        'End If
        NomParam.Add("@Bloque") : ValParam.Add("IngresarAmbito")
        NomParam.Add("@Nombre") : ValParam.Add(nombre)
        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
	End Function
    Public Function EliminarAmbito(ByVal AmbitoId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        NomParam.Add("@Bloque") : ValParam.Add("EliminarAmbito")
        NomParam.Add("@AmbitoId") : ValParam.Add(AmbitoId)
        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 155 fue ejecutado con éxito."



    End Function
    Public Function EditarAmbito(ByVal nombre As String, ByVal AmbitoId As Integer) As String
        ' strFonos: Contiene los fonos separados por ||
        '//hay que agregar person_id
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        NomParam.Add("@Bloque") : ValParam.Add("EditarAmbito")
        NomParam.Add("@nombre") : ValParam.Add(nombre)
        NomParam.Add("@AmbitoId") : ValParam.Add(AmbitoId)
        consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function GetData() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = ""

        NomParam.Add("@Bloque") : ValParam.Add("GetData")

        ds = consulta.ExecuteSQL("IE_ANOTACION", NomParam, ValParam)
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
                                  "<td id='FirstName_" & ds.Tables(0).Rows(i)("nombre").ToString() & "'> <input id='nombre_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("nombre").ToString() & "' />" & ds.Tables(0).Rows(i)("nombre").ToString() & "</td>" &
                                "</tr>"

                Next
            End If

        End If

        Return tabla
    End Function
End Class
