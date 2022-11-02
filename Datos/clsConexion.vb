Imports System.Xml


Public Class clsConexion
    Private Property Servidor As String
    Private Property Base As String
    Private Property Usuario As String
    Private Property Pass As String

    Public Function StringConexion(ByVal NombreCN) As String

        Dim Xml As XmlDocument
        Dim NodeList As XmlNodeList
        Dim Node As XmlNode


        StringConexion = ""

        Try
            Xml = New XmlDocument()

            Xml.Load(System.AppDomain.CurrentDomain.BaseDirectory() & "Parametros.xml")
            NodeList = Xml.SelectNodes("/CNSource/Conexion")

            For Each Node In NodeList

                If Node.Attributes.GetNamedItem("Nombre").Value = NombreCN Then

                    Me.Servidor = Node.Attributes.GetNamedItem("Server").Value
                    Me.Base = Node.Attributes.GetNamedItem("Base").Value
                    Me.Usuario = Node.Attributes.GetNamedItem("Usuario").Value
                    Me.Pass = Node.Attributes.GetNamedItem("Clave").Value

                    Exit For
                End If

            Next

            StringConexion = "Server=" & Servidor & ";DataBase=" & Base & ";user id=" & Usuario & ";password=" & Pass & ";Max Pool Size=1000;Pooling=true"

        Catch ex As Exception
            Return StringConexion
        Finally

        End Try

        Return StringConexion
    End Function
End Class
