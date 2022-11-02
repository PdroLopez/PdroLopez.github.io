Imports Datos
Public Class cls_Listas
    Public Function GetProfesor(ByVal curso As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Bloque") : ValParam.Add("Get Profesor")
        ds = consulta.ExecuteSQL("IE_LISTA", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = ""
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<h5>Profesor Jefe</h6><h5>" & ds.Tables(0).Rows(i)("Nombre").ToString() & "</h5>"
                Next
            End If

        End If
        Return tabla
    End Function
    Public Function GetEstudiante(ByVal curso As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Bloque") : ValParam.Add("Get Estudiante")
        ds = consulta.ExecuteSQL("IE_LISTA", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = ""
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    Dim aumento As Integer = i + 1
                    tabla &= "<tr id='td_tbody'>" &
                        "<td id='n_lista' style='position:absolute; float:left;'" & ds.Tables(0).Rows(i)("PersonId").ToString() & " > <p> " & aumento & "</p></td>" &
                        "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " > <p id='nombre_p'>" & ds.Tables(0).Rows(i)("Nombre").ToString() & "</p></td>" &
                        "<td class='align-middle text-left'> <button  class='btn btn-sm btn-icon btn-secundary arriba'><i class='fas fa-arrow-up' style='color:white'> </i>  </button> <br> <button  class='btn btn-sm btn-icon btn-secundary abajo'><i class='fas fa-arrow-down' style='color:white';> </i>  </button> </td>" &
                        "</tr>"
                Next




            End If

        End If

        Return tabla


    End Function
    Public Function Ordenar(ByVal curso As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Bloque") : ValParam.Add("Ordenar Estudiante")
        ds = consulta.ExecuteSQL("IE_LISTA", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = ""
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    Dim aumento As Integer = i + 1

                    'tabla &= "<tr id='td_tbody'>" &
                    '    "<td id='n_lista' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " > " & aumento & "</td>" &
                    '    "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " > " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</td>" &
                    '    "<td class='align-middle text-left'> <button  class='btn btn-sm btn-icon btn-secundary arriba'><i class='fas fa-arrow-up'> </i>  </button> </td>" &
                    '    "</tr>"
                    tabla &= "<tr id='td_tbody'>" &
                      "<td id='n_lista' style='position:absolute; float:left;'" & ds.Tables(0).Rows(i)("PersonId").ToString() & " > <p> " & aumento & "</p></td>" &
                      "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " > <p id='nombre_p'>" & ds.Tables(0).Rows(i)("Nombre").ToString() & "</p></td>" &
                      "<td class='align-middle text-left'> <button  class='btn btn-sm btn-icon btn-secundary arriba'><i class='fas fa-arrow-up' style='color:white'> </i>  </button> <br> <button  class='btn btn-sm btn-icon btn-secundary abajo'><i class='fas fa-arrow-down' style='color:white';> </i>  </button> </td>" &
                      "</tr>"
                Next




            End If

        End If

        Return tabla


    End Function

End Class
