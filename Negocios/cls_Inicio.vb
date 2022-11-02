Imports Datos
Public Class cls_Inicio
    Public Function CountColegio(ByVal user As String, ByVal contra As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String
        NomParam.Add("@Username") : ValParam.Add(user)
        NomParam.Add("@Password") : ValParam.Add(contra)

        NomParam.Add("@Bloque") : ValParam.Add("CountColegio")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= ds.Tables(0).Rows(i)("c").ToString()
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function GetColegio(ByVal user As String, ByVal contra As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String
        NomParam.Add("@Username") : ValParam.Add(user)
        NomParam.Add("@Password") : ValParam.Add(contra)

        NomParam.Add("@Bloque") : ValParam.Add("GetColegio")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<div class='card-title'>
                               <button  class='btn btn-outline-primary btn-icon-sm btnColegio' type='button' id='" & ds.Tables(0).Rows(i)("ColegioId").ToString() & "'>
                                    " & ds.Tables(0).Rows(i)("Nombre").ToString() & "
                                </button>
                              </div>"
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function GetRol(ByVal user As String, ByVal contra As String, ByVal id As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String
        NomParam.Add("@Username") : ValParam.Add(user)
        NomParam.Add("@Password") : ValParam.Add(contra)
        NomParam.Add("@ColegioId") : ValParam.Add(id)

        NomParam.Add("@Bloque") : ValParam.Add("GetRol")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<div class='card-title'>
                               <button  class='btn btn-outline-primary btn-icon-sm btnRol' type='button' id='" & ds.Tables(0).Rows(i)("RolId").ToString() & "'>
                                    " & ds.Tables(0).Rows(i)("Nombre").ToString() & "
                                </button>
                              </div>"
                Next
            End If

        End If

        Return tabla
    End Function
End Class
