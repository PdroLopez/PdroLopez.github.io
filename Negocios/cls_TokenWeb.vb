Public Class cls_TokenWeb
	Public Function TokenOk(ByVal Username As String) As String
		Dim token = TokenGenerado.Controllers.GenerateTokenJwt(Username)
		Dim tabla As String
		tabla = token
		Return tabla
	End Function
End Class
