Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports Negocios
Imports System.Text.Json.Serialization
Imports System.Xml
Imports System.Drawing
Imports System.IO
Imports System.Net
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Colegio1
    Inherits System.Web.Services.WebService
    Dim person As New Persona
    Dim respuesta As New cls_CodigosRespuesta

    <WebMethod()>
    Public Function MostrarImagen(ByVal ColegioId As Integer, ByVal type As String
                                    ) As String
        Dim colegio As cls_Colegio = New cls_Colegio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim Img As Image
        Dim i As Integer
        i = 0
        Dim folderPath As String = HttpContext.Current.Server.MapPath("~/Uploads/")

        Img = colegio.MostrarImagen(ColegioId)
        Dim rnd As Random = New Random()
        Dim a As Integer
        a = rnd.Next(1, 1000000000)
        Dim aString = Convert.ToString(a)
        Dim b As Byte()
        Dim String64 As String
        'Dim name As String = Random(99999).tostring() & "_" & Random(99999).tostring()
        'Validar estas extensiones: p ng gif jpg

        Img.Save(folderPath & aString & type)

        Dim fileName As String = folderPath & aString & type

        'FileName = Path.Combine(insignia)
        Using Imagen As Image = Image.FromFile(fileName)
            Using m As MemoryStream = New MemoryStream()
                Imagen.Save(m, Imagen.RawFormat)

                b = m.ToArray()
                'retorna binario
                String64 = Convert.ToBase64String(b)
            End Using
        End Using
        Dim data As String = "data:image/png;base64,"
        tabla = "<img id='imag' width='300' height='200' src='" & data & "" & String64 & "' />"
        Return tabla
    End Function
    '<WebMethod()>
    'Public Function IngresarColegio(ByVal nombre As String,
    '                                ByVal nombre_corto As String, ByVal ColegioId As Integer,
    '                                ByVal insignia As String
    '                                ) As String
    '    Dim colegio As cls_Colegio = New cls_Colegio()
    '    Dim tabla As String
    '    Dim ds As String
    '    Dim i As Integer
    '    i = 0

    '    tabla = colegio.IngresarColegio(nombre, nombre_corto, ColegioId, insignia)
    '    Return tabla
    'End Function
    <WebMethod()>
    Public Function SearchType(ByVal ColegioId As Integer) As String
        Dim colegio As cls_Colegio = New cls_Colegio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = colegio.SearchType(ColegioId)




        Return tabla
    End Function
    <WebMethod()>
    Public Function MostrarTabla() As String
        Dim colegio As cls_Colegio = New cls_Colegio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = colegio.MostrarTabla()




        Return tabla
    End Function
    <WebMethod()>
    Public Function UploadImage() As String
        Dim folderPath As String = HttpContext.Current.Server.MapPath("~/Uploads/")
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        'Fetch the File.
        Dim postedFile As HttpPostedFile = HttpContext.Current.Request.Files(0)

        'Fetch the File Name.
        Dim fileName As String = HttpContext.Current.Request.Form("fileName") + Path.GetExtension(postedFile.FileName)
        'Save the File.
        postedFile.SaveAs(folderPath & fileName)
        Dim ruta As String = folderPath & fileName

        Dim ext As String = Path.GetExtension(postedFile.FileName)
        HttpContext.Current.Response.StatusCode = CInt(HttpStatusCode.OK)
        HttpContext.Current.Response.Write(fileName)
        HttpContext.Current.Response.Flush()

        Dim filePath As String = Server.MapPath("/Uploads/" & fileName)

        '  Dim filename As String = Path.GetFileName(filePath)
        'C:\Users\Pedro\Downloads\rep2\librodigitaliEduca\iEdeucaLCD\Uploads
        'C:/Users/Pedro/Downloads/rep2/librodigitaliEduca/iEdeucaLCD/Uploads/EV15WsQXgAIEdDW.jpg.jpg' 

        Dim fs As FileStream = New FileStream(ruta, FileMode.Open, FileAccess.Read)

        Dim br As BinaryReader = New BinaryReader(fs)

        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

        br.Close()

        fs.Close()

        Dim colegio As cls_Colegio = New cls_Colegio()
        Dim tabla As String
        Dim ds As String
        Dim i As Integer
        i = 0
        Dim ColegioId As Integer = HttpContext.Current.Request.Form("ColegioID")
        Dim nombre As String = HttpContext.Current.Request.Form("nombre")
        Dim nombre_corto As String = HttpContext.Current.Request.Form("nombre_corto")

        tabla = colegio.IngresarColegio(nombre, nombre_corto, ColegioId, bytes, ext)
        ' tabla = colegio.GuardarImagen(ColegioId, bytes, ext)
        Return "ok"
    End Function
    <WebMethod()>
    Public Function GuardarImagen(ByVal ColegioId As Integer, ByVal nombre_archivo As String) As String
        Dim colegio As cls_Colegio = New cls_Colegio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        '' tabla = colegio.GuardarImagen(ColegioId, bytes)
        Return tabla



    End Function

    <WebMethod()>
    Public Function EliminarColegio(ByVal ColegioId As Integer) As String
        Dim colegio As cls_Colegio = New cls_Colegio()
        Dim tabla As String
        tabla = "NADA!"
        Dim ds As String
        Dim i As Integer
        i = 0

        tabla = colegio.EliminarColegio(ColegioId)
        Return tabla
    End Function

End Class