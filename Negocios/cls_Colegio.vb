
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Data
Imports Datos
Imports System.Text

Public Class cls_Colegio
    Public Function SearchType(ByVal ColegioId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String
        NomParam.Add("@ColegioId") : ValParam.Add(ColegioId)
        NomParam.Add("@Bloque") : ValParam.Add("SearchType")
        ds = consulta.ExecuteSQL("IE_COLEGIO", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

                    tabla &= ds.Tables(0).Rows(i)("extension").ToString()
                Next
            End If

        End If
        Return tabla




    End Function
    Public Function MostrarTabla() As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Bloque") : ValParam.Add("Colegio Select all")
        ds = consulta.ExecuteSQL("IE_COLEGIO", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = ""
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1

                    tabla &= "<tr>" &
                                      "<td class='align-middle text-left' > " &
                                      "<button  class='btn btn-sm btn-icon btn-secundary  btn_editar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-pencil-alt'> </i>" & "</button>" &
                                        "<button href ='#' class='btn btn-sm btn-icon btn-secundary  btn_eliminar' id='" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & "<i class='fa fa-trash-alt'> </i>" & "</button>" & "</td>" &
                                       "<td id='perid" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "</td>" &
                                      "<td id='FirstName" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("Name").ToString() & "</td>" &
                                     "<td id='LastName" & ds.Tables(0).Rows(i)("OrganizationId").ToString() & "'>" & ds.Tables(0).Rows(i)("ShortName").ToString() & "</td>" &
                                    "</tr>"
                Next
            End If

        End If
        Return tabla




    End Function
    Public Function MostrarImagen(ByVal ColegioId As Integer) As Image
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@ColegioId") : ValParam.Add(ColegioId)

        NomParam.Add("@Bloque") : ValParam.Add("MostrarImagen")
        ds = consulta.ExecuteSQL("IE_COLEGIO", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then

                Try
                    Dim ms As MemoryStream = New MemoryStream(CType(ds.Tables(0).Rows(0)("Imagen"), Byte()))
                    Dim Img As Image = Image.FromStream(ms)
                    Return Img

                Catch ex As Exception

                End Try









                tabla = ""

                Dim b As String
                'Dim tb As DataRow = ds.Tables("Imagen_Colegio").Rows(0)


                ''For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                ''b = ds.Tables(0).Rows(i)("Imagen").ToString()

                ''Dim hexString As String = BitConverter.ToString(ds.Tables(0).Rows(i)("Imagen")).Replace("-", String.Empty).ToLower()







                ''Next
            End If

        End If
        ' Return tabla




    End Function

    Protected Sub j()
        Dim filePath As String = HttpContext.Current.Server.MapPath("~/Uploads/")

        Dim filename2 As String = Path.GetFileName(filePath)



        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)

        Dim br As BinaryReader = New BinaryReader(fs)

        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

        br.Close()

        fs.Close()
    End Sub
    Public Sub UploadImage()


        'Dim filePath As String = Server.MapPath("APP_DATA/Testxls.xlsx")

        'Dim filename2 As String = Path.GetFileName(filePath)



        'Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)

        'Dim br As BinaryReader = New BinaryReader(fs)

        'Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

        'br.Close()

        'fs.Close()

    End Sub
    Public Function GuardarImagen(ByVal ColegioId As Integer, ByVal bytes As Byte(), ByVal ext As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim base64String As String
        'base64String = Convert.ToBase64String(bytes)

        NomParam.Add("@Bloque") : ValParam.Add("GuardarImagen")
        NomParam.Add("@ColegioId") : ValParam.Add(ColegioId)
        NomParam.Add("@Imagen") : ValParam.Add(bytes)
        NomParam.Add("@ext") : ValParam.Add(ext)


        ds = consulta.ExecuteSQL("IE_COLEGIO", NomParam, ValParam)
        Return "El comando N° 155 fue ejecutado con éxito."



    End Function
    Public Function EliminarColegio(ByVal ColegioId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet

        NomParam.Add("@Bloque") : ValParam.Add("Colegio Delete")
        NomParam.Add("@ColegioId") : ValParam.Add(ColegioId)
        ds = consulta.ExecuteSQL("IE_COLEGIO", NomParam, ValParam)
        Return "El comando N° 155 fue ejecutado con éxito."



    End Function
    Public Function IngresarColegio(ByVal nombre As String,
                                    ByVal nombre_corto As String, ByVal ColegioId As Integer,
                                    ByVal bytes As Byte(), ByVal ext As String
                                    ) As String
        Dim consulta As New clsConsulta
        Dim NomParam, ValParam As New ArrayList
        Dim prueba As String
        prueba = ""
        If (ColegioId > 0) Then
            NomParam.Add("@Bloque") : ValParam.Add("Colegio Update")
            NomParam.Add("@ColegioId") : ValParam.Add(ColegioId)
        Else
            NomParam.Add("@Bloque") : ValParam.Add("Colegio Insert")
        End If


        NomParam.Add("@nombre") : ValParam.Add(nombre)
        NomParam.Add("@nombre_corto") : ValParam.Add(nombre_corto)
        NomParam.Add("@Imagen") : ValParam.Add(bytes)
        NomParam.Add("@ext") : ValParam.Add(ext)

        consulta.ExecuteSQL("IE_COLEGIO", NomParam, ValParam)
        Return "El comando N° 150 fue ejecutado con éxito."

    End Function
End Class
