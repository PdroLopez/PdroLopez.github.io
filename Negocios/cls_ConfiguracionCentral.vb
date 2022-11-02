Imports Datos
Public Class cls_ConfiguracionCentral
    Public Function AgregarConfiguracionCentral(ByVal codigo As String, ByVal nombre As String) As String
        ' strFonos: Contiene los fonos separados por ||
        '//hay que agregar person_id
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        NomParam.Add("@Bloque") : ValParam.Add("AgregarConfiguracionCentral")
        NomParam.Add("@Nombre") : ValParam.Add(nombre)
        NomParam.Add("@Codigo") : ValParam.Add(codigo)

        consulta.ExecuteSQL("IE_CONFIGURACION_CENTRAL", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function GetData() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = ""

        NomParam.Add("@Bloque") : ValParam.Add("GetData")

        ds = consulta.ExecuteSQL("IE_CONFIGURACION_CENTRAL", NomParam, ValParam)
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
                                  "<td id='FirstName_" & ds.Tables(0).Rows(i)("codigo").ToString() & "'> <input id='codigo_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("codigo").ToString() & "' />" & ds.Tables(0).Rows(i)("codigo").ToString() & "</td>" &
                                   "<td id='FirstName_" & ds.Tables(0).Rows(i)("nombre").ToString() & "'> <input id='nombre_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("nombre").ToString() & "' />" & ds.Tables(0).Rows(i)("nombre").ToString() & "</td>" &
                                "</tr>"

                Next
            End If

        End If

        Return tabla
    End Function

    Public Function EditarConfiguracionCentral(ByVal nombre As String, ByVal codigo As String, ByVal ConfiguracionCentralId As Integer) As String
        ' strFonos: Contiene los fonos separados por ||
        '//hay que agregar person_id
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        NomParam.Add("@Bloque") : ValParam.Add("EditarConfiguracionCentral")
        NomParam.Add("@nombre") : ValParam.Add(nombre)
        NomParam.Add("@Codigo") : ValParam.Add(codigo)
        NomParam.Add("@ConfiguracionCentralId") : ValParam.Add(ConfiguracionCentralId)
        consulta.ExecuteSQL("IE_CONFIGURACION_CENTRAL", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function EliminarConfiguracionCentral(ByVal ConfiguracionCentralId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        NomParam.Add("@Bloque") : ValParam.Add("EliminarConfiguracionCentral")
        NomParam.Add("@ConfiguracionCentralId") : ValParam.Add(ConfiguracionCentralId)
        ds = consulta.ExecuteSQL("IE_CONFIGURACION_CENTRAL", NomParam, ValParam)
        Return "El comando N° 155 fue ejecutado con éxito."



    End Function
End Class
