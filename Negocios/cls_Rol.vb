Imports Datos
Imports Microsoft.IdentityModel
Imports Newtonsoft
Imports Newtonsoft.Json.Linq

Public Class cls_Rol
    Public Function GetRol() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = "No hay datos para mostrar"

        NomParam.Add("@Bloque") : ValParam.Add("GetRol")

        ds = consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''> Seleccione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option  value='" & ds.Tables(0).Rows(i)("id").ToString() & "'> " & ds.Tables(0).Rows(i)("Name").ToString() & "</option>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function EliminarRol(ByVal RolId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        NomParam.Add("@Bloque") : ValParam.Add("EliminarRol")
        NomParam.Add("@Rol") : ValParam.Add(RolId)
        ds = consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        Return "El comando N° 155 fue ejecutado con éxito."



    End Function
    Public Function LlenarTabla(ByVal ColegioID As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = ""

        NomParam.Add("@Bloque") : ValParam.Add("LlenarTabla")
        NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)

        ds = consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

                    tabla &= "<tr>" &
                                  "<td class='align-middle text-left' > " &
                                  "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
                                    "<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "
									 " & "<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_asignar' data-target='#modal_asignar' data-toggle='modal' id='" & ds.Tables(0).Rows(i)("id").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button></td>" &
                                   "<td id='perid" & ds.Tables(0).Rows(i)("id").ToString() & "'>" & ds.Tables(0).Rows(i)("id").ToString() & "</td>" &
                                  "<td id='FirstName_" & ds.Tables(0).Rows(i)("nombre").ToString() & "'> <input id='nombre_" & ds.Tables(0).Rows(i)("id").ToString() & "' type='hidden' value='" & ds.Tables(0).Rows(i)("nombre").ToString() & "' />" & ds.Tables(0).Rows(i)("nombre").ToString() & "</td>" &
                                "</tr>"

                Next
            End If

        End If

        Return tabla
    End Function
    Public Function OpcionesMenu(ByVal id As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = ""

        NomParam.Add("@Bloque") : ValParam.Add("OpcionesMenu")
        NomParam.Add("@Rol") : ValParam.Add(id)

        ds = consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<div class='col-md-12 mb-6'>
									 <div class='form-check'>
										<input type='checkbox' name='opciones'  id='" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'  class='form-check-input btn_prueba' value='" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'/>
										<label > " & ds.Tables(0).Rows(i)("nombre").ToString() & "</label>
									 </div>
								  </div>"

                Next
            End If

        End If

        Return tabla
    End Function
    Public Function GetID(ByVal id As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = ""

        NomParam.Add("@Bloque") : ValParam.Add("GetID")
        NomParam.Add("@Rol") : ValParam.Add(id)

        ds = consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= ds.Tables(0).Rows(i)("datos").ToString()
                Next
            End If

        End If

        Return tabla
    End Function

    Public Function IngresarRol(ByVal nombre As String, ByVal ColegioID As Integer) As String
        ' strFonos: Contiene los fonos separados por ||
        '//hay que agregar person_id
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        NomParam.Add("@Bloque") : ValParam.Add("IngresarRol")
        NomParam.Add("@nombre") : ValParam.Add(nombre)
        NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)
        consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function IngresarRolMenu(ByVal RolMenu As String, ByVal ID_ROL As String) As String
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        NomParam.Add("@Bloque") : ValParam.Add("IngresarRolMenu")
        NomParam.Add("@RolMenu") : ValParam.Add(RolMenu)
        NomParam.Add("@Rol") : ValParam.Add(ID_ROL)
        consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
    Public Function EditarRol(ByVal nombre As String, ByVal ColegioID As Integer, ByVal RolId As Integer) As String
        ' strFonos: Contiene los fonos separados por ||
        '//hay que agregar person_id
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        NomParam.Add("@Bloque") : ValParam.Add("EditarRol")
        NomParam.Add("@nombre") : ValParam.Add(nombre)
        NomParam.Add("@ColegioID") : ValParam.Add(ColegioID)
        NomParam.Add("@Rol") : ValParam.Add(RolId)
        consulta.ExecuteSQL("IE_ROL", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."
    End Function
End Class
