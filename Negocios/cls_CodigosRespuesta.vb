Public Class cls_CodigosRespuesta


    Public Function GetTextCode(ByVal Code As String) As String

        Dim Respuesta As String = ""
        Select Case Code
            Case 150
                Respuesta = "Datos guardados correctamente"
            Case 155
                Respuesta = "Datos eliminados correctamente"
            Case 160
                Respuesta = "Datos actualizados correctamente "
            Case 901
                Respuesta = "No es posible guardar los datos"
            Case Else
                Respuesta = ""

        End Select

        Return Respuesta
    End Function

End Class
