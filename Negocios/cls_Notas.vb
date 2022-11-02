Imports Datos
Public Class cls_Notas
    Public Function GetAsignaturaAll(ByVal curso As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Bloque") : ValParam.Add("Get Asignatura All")
        ds = consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = "<option value=''>Selecione...</option>"
                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla &= "<option value='" & ds.Tables(0).Rows(i)("IDAsignatura").ToString() & "'>" & ds.Tables(0).Rows(i)("Asignatura").ToString() & "</option>"
                Next
            End If

        End If

        Return tabla


    End Function
    Public Function Tabla() As String

        Dim tablaxd As String
        tablaxd = "<th style='width:10px; border-right: 2px  solid black;'>N°</th><th style='width:100px;border-right: 2px  solid black;'>Nombre</th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th>"
        Return tablaxd


    End Function

    Public Function IngresarEvaluacion(ByVal nombre As String,
                                  ByVal curso As Integer, ByVal EvaluacionId As Integer,
                                  ByVal asignatura As Integer, ByVal ìdNotaStr As String,
                                       ByVal h_inicial As DateTime, ByVal h_fin As DateTime, ByVal fecha As Date
                                   ) As String
        Dim consulta As New clsConsulta
        Dim ms As New cls_CodigosRespuesta
        Dim NomParam, ValParam As New ArrayList

        If EvaluacionId > 0 Then
            NomParam.Add("@Bloque") : ValParam.Add("Evaluacion Update")
            NomParam.Add("@EvaluacionId") : ValParam.Add(EvaluacionId)
        Else
            NomParam.Add("@Bloque") : ValParam.Add("Evaluacion Insert")
        End If
        NomParam.Add("@Nombre") : ValParam.Add(nombre)
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        NomParam.Add("@Estudiantes") : ValParam.Add(ìdNotaStr)
        NomParam.Add("@Hora_Inicial") : ValParam.Add(h_inicial)
        NomParam.Add("@Hora_Fin") : ValParam.Add(h_fin)
        NomParam.Add("@Fecha") : ValParam.Add(fecha)

        consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)
        Return ms.GetTextCode(150)
    End Function
    'Public Function Promedio(ByVal asignatura As Integer, ByVal curso As Integer, ByVal ìdNotaStr As String) As String
    '    Dim NomParam, ValParam As New ArrayList
    '    Dim consulta As New clsConsulta
    '    Dim ds As New DataSet


    '    Dim tabla As String = "No hay datos para mostrar"
    '    Dim a, xd As String
    '    NomParam.Add("@Curso") : ValParam.Add(curso)
    '    NomParam.Add("@Asignatura") : ValParam.Add(asignatura)

    '    NomParam.Add("@Bloque") : ValParam.Add("Promedio")
    '    ds = consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)
    '    If ds.Tables.Count > 0 Then
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            tabla = ""
    '            For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
    '                tabla &= "<tr id='td_tbody " & i & "'>" &
    '                    "<td id='n_lista' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " style='border-right: 2px  solid black;border-bottom: 2px  solid black;'> " & i + 1 & "</td>" &
    '                    "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " style='width:50px;border-right: 2px  solid black;border-bottom: 2px  solid black;'> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</td>"


    '                For x As Integer = 3 To ds.Tables(0).Columns.Count() - 1
    '                    Dim idAlumno As Integer = ds.Tables(0).Rows(i)("PersonId")
    '                    Dim idNota As String = ds.Tables(0).Columns(x).ColumnName
    '                    'Dim Nota As String = If(IsDBNull(ds.Tables(0).Rows(i)(x)), String.Empty, ds.Tables(0).Rows(i)(x).ToString)
    '                    Dim Nota As String = ds.Tables(0).Rows(i)(x)
    '                    Dim Fila As Integer = i
    '                    Dim Columna As Integer = x
    '                    Dim Estilo As String = "color: red;"
    '                    Dim nada As String = ""
    '                    Dim Hilera As String
    '                    If IsDBNull(Nota) Then
    '                        Hilera = ""
    '                    Else
    '                        Hilera = Nota
    '                    End If
    '                    If (Nota > 39) Then
    '                        Estilo = "color:blue;"
    '                    End If
    '                    If (Nota = 0) Then
    '                        tabla += "<td  style='width:20px;border-right: 2px  solid black;border-bottom: 2px  solid black;'>" & "
    '                                <input name='notas_i' oldValue='" & Nota & "' cont='" & Fila & "' id='" & Fila & "_" & Columna & "' idalumno='" & idAlumno & "' idnota='" & idNota & "' fila='" & Fila & "' columna='" & Columna & "' oldvalue='" & Convert.ToString(Nota) & "' style='width:30px;  float:center;border:0; " & Estilo & "' type='text' value='0' min='10' max='70' /><input type='hidden' id='hidden_filas' value='" & x & "'/>
    '                            </td>"
    '                    Else
    '                        tabla += "<td  style='width:20px;border-right: 2px  solid black;border-bottom: 2px  solid black;'>" & " 
    '                                <input name='notas_i' oldValue='" & Nota & "' cont='" & Fila & "' id='" & Fila & "_" & Columna & "' idalumno='" & idAlumno & "' idnota='" & idNota & "' fila='" & Fila & "' columna='" & Columna & "' oldvalue='" & Nota & "' style='width:30px;  float:center;border:0; " & Estilo & "' type='text' value='" & Convert.ToString(Nota) & "' min='10' max='70' /><input type='hidden' id='hidden_filas' value='" & x & "'/>
    '                            </td>"

    '                    End If




    '                    'El textbox debe tener cuatro referencia : idAlumno, idNota, numeroFila(i),numeroColumna(x-2)'
    '                Next

    '                tabla += "</tr>"



    '            Next




    '        End If

    '    End If

    '    Return tabla
    'End Function

    Public Function IngresarNotas(ByVal asignatura As Integer, ByVal ìdNotaStr As String) As String
        Dim consulta As New clsConsulta
        Dim ms As New cls_CodigosRespuesta
        Dim NomParam, ValParam As New ArrayList
        NomParam.Add("@Bloque") : ValParam.Add("Notas Insert")
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        NomParam.Add("@Estudiantes") : ValParam.Add(ìdNotaStr)

        consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)
        Return ms.GetTextCode(150)
    End Function
    Public Function GetEstudiante(ByVal curso As Integer, ByVal asignatura As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String
        NomParam.Add("@Bloque") : ValParam.Add("Prueba")

        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)

        ds = consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                tabla = ""

                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1


                    tabla &= "<tr id='td_tbody " & i & "'>" &
                        "<td id='n_lista' " & ds.Tables(0).Rows(i)("PersonId").ToString() & "'> " & i + 1 & "</td>" &
                        "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " > " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</td>"

                    'tabla &= "<tr id='td_tbody " & i & "'>" &
                    '    "<td id='n_lista' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " > <div style='text-align:center;'>" & i + 1 & "</div></td>" &
                    '    "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " ><div  style='text-align:center;'> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</div></td>"



                    For x As Integer = 3 To ds.Tables(0).Columns.Count() - 1
                        Dim idAlumno As Integer = ds.Tables(0).Rows(i)("PersonId")
                        'Dim Promedio As String = ds.Tables(0).Rows(i)("Promedio")
                        Dim idNota As String = ds.Tables(0).Columns(x).ColumnName
                        'Dim Nota As String = If(IsDBNull(ds.Tables(0).Rows(i)(x)), String.Empty, ds.Tables(0).Rows(i)(x).ToString)
                        Dim Nota As String = ds.Tables(0).Rows(i)(x)
                        Dim Fila As Integer = i
                        Dim Columna As Integer = x
                        Dim Estilo As String = "color: red;"
                        Dim nada As String = ""
                        Dim Hilera As String
                        If IsDBNull(Nota) Then
                            Hilera = ""
                        Else
                            Hilera = Nota
                        End If
                        If (Nota > 39) Then
                            Estilo = "color:blue;"
                        End If
                        If ds.Tables(0).Columns(x).ColumnName = "Promedio" Then
                            'tabla &= "<td style='background-color: rgba(192, 189, 190, 0.8);'  >" & " 
                            '      <div style='text-align:center;'>
                            '                <b><label style='" & Estilo & "'> " & Nota & "</label><b>
                            '        </div> 
                            '      </td>"
                            tabla &= "<td  >" & " 
                                  <div style='text-align:center;'>  <input name='notas_i' maxlength='2' onkeydown='avanzarText(this)' oldValue='" & Nota & "' cont='" & Fila & "' id='" & Fila & "_" & Columna - 3 & "' idalumno='" & idAlumno & "' idnota='" & idNota & "' fila='" & Fila & "' columna='" & Columna & "' oldvalue='" & Nota & "' style='width:30px;  float:center;border:0; " & Estilo & "' type='text' value='" & Nota & "' min='10' max='70' /><input type='hidden' id='hidden_filas' value='" & x & "'/>
                               </div> </td>"


                        Else
                            tabla &= "<td  >" & " 
                                  <div style='text-align:center;'>  <input name='notas_i'  maxlength='2' onkeydown='avanzarText(this)' onblur='cambiarColor(this.id)' oldValue='" & Nota & "' cont='" & Fila & "' id='" & Fila & "_" & Columna - 3 & "' class='" & Fila & "_" & Columna - 3 & "' idalumno='" & idAlumno & "' idnota='" & idNota & "' fila='" & Fila & "' columna='" & Columna & "' oldvalue='" & Nota & "' style='width:30px;  float:center;border:0; " & Estilo & "' type='text' value='" & Nota & "' min='10' max='70' /><input type='hidden' id='hidden_filas' value='" & x & "'/>
                               </div> </td>"

                        End If


                        'tabla &= "<td style='background-color: rgba(192, 189, 190, 0.8);'  >" & " 
                        '          <div style='text-align:center;'>  <b><label style='" & Estilo & "'> " & Nota & "</label><b>
                        '       </div> </td>"

                        'tabla += "<td  style='width:20px;border-right: 2px  solid black;border-bottom: 2px  solid black;'>" & " 
                        '            <input name='notas_i' onkeydown='avanzarText(this)' oldValue='" & Nota & "' cont='" & Fila & "' id='" & Fila & "_" & Columna - 3 & "' idalumno='" & idAlumno & "' idnota='" & idNota & "' fila='" & Fila & "' columna='" & Columna & "' oldvalue='" & Nota & "' style='width:30px;  float:center;border:0; " & Estilo & "' type='text' value='" & Convert.ToString(Nota) & "' min='10' max='70' /><input type='hidden' id='hidden_filas' value='" & x & "'/>
                        '        </td>"








                        'El textbox debe tener cuatro referencia : idAlumno, idNota, numeroFila(i),numeroColumna(x-2)'
                    Next

                    tabla &= "</tr>"



                Next




            End If

        End If
        Return tabla

        'Dim NomParam, ValParam As New ArrayList
        'Dim consulta As New clsConsulta
        'Dim ds As New DataSet


        'Dim tabla As String
        'NomParam.Add("@Bloque") : ValParam.Add("Prueba")
        'NomParam.Add("@Curso") : ValParam.Add(curso)
        'NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        'ds = consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)
        'If ds.Tables.Count > 0 Then
        '    If ds.Tables(0).Rows.Count > 0 Then

        '        For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
        '            'tabla &= "<tr id='td_tbody " & i & "'>" &
        '            '    "<td id='n_lista' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " style='border-right: 2px  solid black;border-bottom: 2px  solid black;'> " & i + 1 & "</td>" &
        '            '    "<td id='nombre' " & ds.Tables(0).Rows(i)("PersonId").ToString() & " style='width:50px;border-right: 2px  solid black;border-bottom: 2px  solid black;'> " & ds.Tables(0).Rows(i)("Nombre").ToString() & "</td>"
        '            tabla &= "H"
        '        Next


        '    End If

        'End If

        'Return tabla

    End Function

    Public Function tablaData(ByVal curso As Integer, ByVal asignatura As Integer) As String
        Dim NomParam, ValParam As New ArrayList
        Dim consulta As New clsConsulta
        Dim ds As New DataSet


        Dim tabla As String = "No hay datos para mostrar"
        NomParam.Add("@Curso") : ValParam.Add(curso)
        NomParam.Add("@Asignatura") : ValParam.Add(asignatura)
        NomParam.Add("@Bloque") : ValParam.Add("Get nombre Notas")
        ds = consulta.ExecuteSQL("IE_NOTAS", NomParam, ValParam)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                'tabla += "<th style='width:20px; border-right: 2px  solid black; text-align:center;'>N°</th>" &
                '         "<th style='width:50%;border-right: 2px  solid black; float:center'>Nombre</th>"


                'For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                '    tabla += "<th style='width:20px;border-right: 2px  solid black;writing-mode: vertical-lr;transform: rotate(180deg);text-align:center;'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</th>"


                'Next
                'tabla += "<th style='width:50%;border-right: 2px  solid black; float:center'>Promedio</th>"

                tabla += "<th style='text-align:center;' >N°</th>" &
                         "<th >Nombre</th>"


                For i As Integer = 0 To ds.Tables(0).Rows.Count() - 1
                    tabla += "<th class='notas_class'  id='" & ds.Tables(0).Rows(i)("AssessmentId").ToString() & "'   style='text-align:center;'>" & ds.Tables(0).Rows(i)("nombre").ToString() & "</th>"

                Next
                tabla += "<th id='promedio'  style='text-align:center;'>Promedio</th>"


            End If

        End If

        Return tabla


    End Function

End Class
