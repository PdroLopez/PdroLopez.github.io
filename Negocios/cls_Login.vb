Imports System.ComponentModel.DataAnnotations
Imports Datos
Public Class cls_Login
    Public Function ValidarUsuario(ByVal Username As String, ByVal Password As String) As Boolean
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As Boolean
        NomParam.Add("@Username") : ValParam.Add(Username)
        NomParam.Add("@Password") : ValParam.Add(Password)

        NomParam.Add("@Bloque") : ValParam.Add("Validar Usuario")

        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    Dim condicion As String
                    condicion = ds.Tables(0).Rows(i)("condicion").ToString()
                    If condicion = "0" Then
                        tabla = True
                    ElseIf condicion = "1" Then
                        tabla = False
                    End If
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function TraerDatos(ByVal Username As String, ByVal Password As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String
        NomParam.Add("@Username") : ValParam.Add(Username)
        NomParam.Add("@Password") : ValParam.Add(Password)

        NomParam.Add("@Bloque") : ValParam.Add("Validar Usuario")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= ds.Tables(0).Rows(i)("id_colegio").ToString()
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function CargaMenu(ByVal menuId As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim nodesCollection As String = ""
        Dim ds As DataSet
        Dim tabla As String
        NomParam.Add("@Menuid") : ValParam.Add(menuId)

        NomParam.Add("@Bloque") : ValParam.Add("SubMMenu")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then

                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1


                    tabla &= ds.Tables(0).Rows(i)("PadreId").ToString()




                    '            If ds.Tables(0).Rows(i)("PadreId").ToString() = 0 Then
                    '                tabla &= "<a href='#' class='menu-link'>
                    '	<span class='" & ds.Tables(0).Rows(i)("icono").ToString() & "'>
                    '		<span class='menu-text'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "
                    '		</span>
                    '	</span>
                    '</a>"


                    '            End If

                Next
            End If

        End If

        Return tabla
    End Function

    Public Function CrearMenu(ByRef nodesCollection As String, ByVal table As DataTable, ByVal parentID As Integer)
        Dim node As String = ""
        For i As Integer = 0 To table.Rows.Count - 1
            If CInt(table.Rows(i)("PadreId")) = parentID Then


                If CInt(table.Rows(i)("PadreId")) = 0 Then
                    node = "
                        <li Class='menu-item'>
                            <a href ='" & table.Rows(i)("url").ToString() & "' class='menu-link'>
                                <span class='" & Trim(table.Rows(i)("icono").ToString()) & "'></span>
                                <span Class='menu-text'>" & table.Rows(i)("nombre").ToString() & "</span>
                            </a>
                            <ul>
                        "
                Else
                    node = "
                         <li Class='menu-item'  id='asignatura_li'>
                            <a runat = 'server' href='" & table.Rows(i)("url").ToString() & "' Class='menu-link'>" & table.Rows(i)("nombre").ToString() & "</a>
                        </li>
                    "
                End If


                CrearMenu(node, table, CInt(table.Rows(i)("MenuId")))
                'cierre papa </ul></li>
            End If
        Next
        nodesCollection &=  node & "</ul></li>"
        Return nodesCollection
    End Function


    'Private Sub CargaMenu(ByRef nodesCollection As TreeViewNodeCollection, ByVal table As DataTable, ByVal parentID As Integer)
    '    For i As Integer = 0 To table.Rows.Count - 1
    '        If CInt(table.Rows(i)("ID_PADRE")) = parentID Then
    '            Dim node As New TreeViewNode
    '            node.Text = table.Rows(i)("NOMBRE").ToString()
    '            If i = 0 Then
    '                Try
    '                    node.Name = Replace(Session("URL_USUARIO"), "~/", "")
    '                Catch ex As Exception
    '                    node.Name = Replace(Session("ID_USUARIO_IEDUCA"), "~/", "")

    '                End Try

    '            Else
    '                If table.Rows(i)("URL").ToString() = "http://www.ieduca.cl/" Then
    '                    Dim _Anterior As String() = Request.ServerVariables("HTTP_REFERER").ToString.Split("/")
    '                    node.Name = table.Rows(i)("URL").ToString() & _Anterior(3) & "/index_original.php"

    '                Else
    '                    node.Name = table.Rows(i)("URL").ToString()
    '                End If

    '            End If
    '            node.ToolTip = table.Rows(i)("NOMBRE").ToString()
    '            node.Image.Url = Trim(table.Rows(i)("IMAGEN").ToString())
    '            nodesCollection.Add(node)
    '            CargaMenu(node.Nodes, table, CInt(table.Rows(i)("ID_MENU")))
    '        End If
    '    Next i
    'End Sub
    Public Function Menu(ByVal rol As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim nodesCollection As String = ""

        Dim tabla As String
        NomParam.Add("@Rol") : ValParam.Add(rol)

        NomParam.Add("@Bloque") : ValParam.Add("Menu")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            CrearMenu(nodesCollection, ds.Tables(0), 0)
        End If


        'If ds.Tables.Count > 0 Then
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        tabla &= "<nav id='stacked-menu' class='stacked-menu'>
        '            <ul class='menu'>
        '             <li class='menu-item'>
        '              <a href='#' class='menu-link'>
        '               <span class='menu-icon fas fa-home'></span>
        '               <span class='menu-text'>Inicio</span>
        '              </a>
        '             </li>"
        '        For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
        '            Dim MenuId As Integer = Convert.ToInt32(ds.Tables(0).Rows(i)("MenuId").ToString())
        '            tabla &= "<li class='menu-item has-child'>"
        '            If ds.Tables(0).Rows(i)("PadreId").ToString() = 0 Then
        '                tabla &= "<a href='#' class='menu-link' id='Menu_" & ds.Tables(0).Rows(i)("MenuId").ToString() & "'>
        '                <span class='" & ds.Tables(0).Rows(i)("icono").ToString() & "'>
        '                	<span class='menu-text'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "
        '                	</span>
        '                </span>
        '                   '</a>"
        '            ElseIf ds.Tables(0).Rows(i)("PadreId").ToString() = CargaMenu(MenuId) Then
        '                tabla &= "<ul>
        '                         	<li class='menu-item'>
        '                         		<a runat='server' href='" & ds.Tables(0).Rows(i)("url").ToString() & "' class='menu-link'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</a>
        '                         	</li>
        '                         </ul>"
        '            End If








        '            '            If ds.Tables(0).Rows(i)("PadreId").ToString() = 0 Then
        '            '                tabla &= "<a href='#' class='menu-link'>
        '            '	<span class='" & ds.Tables(0).Rows(i)("icono").ToString() & "'>
        '            '		<span class='menu-text'> " & ds.Tables(0).Rows(i)("nombre").ToString() & "
        '            '		</span>
        '            '	</span>
        '            '</a>"


        '            '            End If
        '            'tabla &= "</li>"

        '        Next
        '        'tabla &= "</ul></nav>"

        '    End If

        'End If

        Return tabla
    End Function
    Public Function DiferentesRoles(ByVal token As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String
        NomParam.Add("@Token") : ValParam.Add(token)

        NomParam.Add("@Bloque") : ValParam.Add("DiferentesRoles")
        tabla = ""
        ds = consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= ds.Tables(0).Rows(i)("Rol").ToString()
                Next
            End If

        End If

        Return tabla
    End Function
    Public Function InsertToken(ByVal Username As String, ByVal Password As String, ByVal token As String, ByVal fecha As DateTime) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String
        NomParam.Add("@Username") : ValParam.Add(Username)
        NomParam.Add("@Password") : ValParam.Add(Password)
        NomParam.Add("@Token") : ValParam.Add(token)
        NomParam.Add("@Fecha_Token") : ValParam.Add(fecha)

        NomParam.Add("@Bloque") : ValParam.Add("Insert Token")

        consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        tabla = "ok"
        Return tabla
    End Function
    Public Function DeleteToken(ByVal token As String) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet
        Dim tabla As String
        NomParam.Add("@Token") : ValParam.Add(token)
        NomParam.Add("@Bloque") : ValParam.Add("Delete Token")

        consulta.ExecuteSQL("IE_LOGIN", NomParam, ValParam)
        tabla = "ok"
        Return tabla
    End Function
End Class
