Public Class Modalidad
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim vall As String
        vall = Session("ID_Colegio")
        midato.Value = vall.ToString







    End Sub
End Class