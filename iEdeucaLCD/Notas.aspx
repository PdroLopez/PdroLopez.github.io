<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Notas.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Notas" %>

<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="jquery-3.6.0.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%--<script src="sweetalert2.min.js"></script>--%>
    <%--<link rel="stylesheet" href="sweetalert2.min.css">--%>
    <script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>

    <style>
        label.error {
            width: 100%;
            margin-top: .25rem;
            font-size: 80%;
            color: #b76ba3;
        }
    </style>

    <script type="text/javascript">

        function cambiarColor(id) {
            var valor = $("#" + id).val();
            if (valor <= 40) {
                $("#" + id).css("color", "red");
            }
            else {
                $("#" + id).css("color", "blue");

            }
        }

        function avanzarText(txtbx) {



            var textbx = document.getElementById(txtbx.id);

            if (textbx.getAttribute("oldvalue") == textbx.value) {
                return;
            }

            


            if (txtbx.value.length == 2) {
                console.log("Valor del text: " + txtbx.value);
                var filacolumna = txtbx.id
                var arrfilaColumna = filacolumna.split("_");


                var siguienteFila = parseInt(arrfilaColumna[0]) + 1;
                var siguienteColumna = parseInt(arrfilaColumna[1]) + 1;

                var newIDColumna = arrfilaColumna[0] + "_" + siguienteColumna;
                var newID = siguienteFila + "_" + arrfilaColumna[1];
                var NewID2 = "0_" + siguienteColumna;

                var nFilas = $("#tabla_id tr").length - 1;
                var nColumnas = $("#tabla_id tr:last td").length - 3;

                //if (nFilas == siguienteFila && nColumnas == siguienteColumna) {
                //    return;
                //}


                console.log("NuevoID: " + newID);
                console.log("NuevoID2: " + NewID2);
                console.log("siguienteFila: " + siguienteFila + " nFilas: " + nFilas);
                if (siguienteFila < nFilas) {
                    document.getElementById(newID).select();
                }
                else {
                    // console.log("Entre a else");
                    document.getElementById(NewID2).select();
                }
                //document.getElementById(newIDColumna).select();
                //document.getElementById(newID).select();
                //if (newIDColumna == nFilas) {
                //    document.getElementById(newIDColumna).select();
                //}

                //Avanza por las Filas

             

            }

        }

        $(document).ready(function () {
            //Tabla 
            $("#h_inicial").html("");
            $("#h_fin").html("");
            function llenarTablaInicial() {
                $.ajax({
                    type: "POST",
                    url: 'Notas.asmx/Tabla',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#cabecera_tabla').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            }
            //llenarTablaInicial();
            function llenarcmb() {

                var ColegioID = sessionStorage.getItem('Colegio');

                $.ajax({
                    type: "POST",
                    url: 'Asignatura.asmx/SelectCurso',
                    data: "{ColegioID:'" + ColegioID +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#curso').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            }
            llenarcmb();
            function tablaData(curso, asignatura) {
                var h = "<th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th>"

                $.ajax({
                    type: "POST",
                    url: '/Notas.asmx/tablaData',
                    data: "{curso:'" + curso +
                        "',asignatura:'" + asignatura +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        if (data.d == 'No hay datos para mostrar') {
                            $('#cabecera_tabla').html("Sin Datos...");
                            $("#condicion").val('1')
                        }
                        else {
                               $('#cabecera_tabla').html(data.d);
                              $("#condicion").val('2')

                        }
                    },
                    error: function (err) { console.log("Error:" + err); },
                });
            }
            //$(document).on('keydown', '.btn_editar', function () {

            //    alert('Hola');

            //});


            function getEstudiante(curso, asignatura) {
                $.ajax({
                    type: "POST",
                    url: 'Notas.asmx/GetEstudiante',
                    data: "{curso:'" + curso +
                        "',asignatura:'" + asignatura +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        var cond = $("#condicion").val()
                        if (cond == 1 ) {
                            $('#mostrar').html("");

                        }
                        if (cond == 2 ) {
                            $('#mostrar').html(data.d);

                        }
                        //htm += "<td>Test Row Append <BR> </td>"





                        ////////$("<tr><td>Test Row Append</td></tr>").appendTo("#tabla_id>tbody")
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },


                });


            }
            function getElement() {

            }
            $('#curso').on('change', function () {
                var curso = $('#curso').val();
                $.ajax({
                    type: "POST",
                    url: 'Notas.asmx/GetAsignaturaAll',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#asignatura').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });


            function limpiar() {
                 $('#nombre_campo').val("");
                $('#EvaluacionId').val(0);

            }

            $('#btnIngresar').on('click', function () {
                limpiarCampos();




            });

            $('#btnAgregar').on('click', function () {
                var nombre = $('#nombre_campo').val();
                var curso = $('#curso').val();
                var asignatura = $('#asignatura').val();
                var EstudianteId = new Array();
                /*Agrupamos todos los input con name=cbxEstudiante*/
                var idA = $('input[name="notas_i"]').val();
                parseInt(idA);
                var rowCount = $("#tabla_id tr").length - 1;
                var fila = $('input[name="notas_i"]').attr("fila");
                var columna = $('input[name="notas_i"]').attr("columna");
                var idNota = $('input[name="notas_i"]').attr("idnota");
                var idEstudiante = $('input[name="notas_i"]').attr("idalumno");
                var str = idEstudiante + "_" + idNota + "_" + fila + "_" + columna;
                var arrTodo = new Array();
                var EvaluacionId = $("#EvaluacionId").val();
                var h_inicial = $("#h_inicial").val();
                var h_fin = $("#h_fin").val();
                var fecha = $("#f_prueba").val();


                if ($("#form_valid").valid() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                else {
                    $('input[name="notas_i"]').each(function (element) {
                        var item = {};
                        item.idNota = this.id;
                        item.Nota = this.value;
                        arrTodo.push(item);
                    });

                    //console.log("hhh");


                    const momentoComida = arrTodo.map(function (comida) {
                        var nota = comida.Nota;
                        var str = comida.idNota;
                        var array = str.split("_");
                        var oldValue = array[4];
                        if (oldValue == nota) {
                            return array[0] + ":" + array[1] + ":" + 0 + "||";
                        }
                        else {
                            return array[0] + ":" + array[1] + ":" + 0 + "||";
                        }
                        return array[0] + ":" + array[1] + ":" + 0 + "||";

                    });

                    var ìdNotaStr = momentoComida.toString();

                    $.ajax({
                        type: "POST",
                        url: '/Notas.asmx/IngresarEvaluacion',
                        data: "{nombre:'" + nombre +
                            "',curso:'" + curso +
                            "',asignatura:'" + asignatura +
                            "',ìdNotaStr:'" + ìdNotaStr +
                            "',EvaluacionId:'" + EvaluacionId +
                            "',h_inicial:'" + h_inicial +
                            "',h_fin:'" + h_fin +
                            "',fecha:'" + fecha +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (data) {
                            limpiarCampos();
                            $("#btnCancelar").click();
                            swal.fire(
                                "¡Exito!",
                                data.d,
                                "success"
                            )
                            tablaData(curso, asignatura);
                            getEstudiante(curso, asignatura);
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }

                /*Agrupamos todos los input con name=cbxEstudiante*/
              




            //    $("#create .close").click();
            });
            $('#btnIngresarNotas').on('click', function () {
                var nombre = $('#nombre_campo').val();
                var curso = $('#curso').val();
                var asignatura = $('#asignatura').val();

                var EstudianteId = new Array();
                /*Agrupamos todos los input con name=cbxEstudiante*/
                var idA = $('input[name="notas_i"]').val();
                parseInt(idA);
                var rowCount = $("#tabla_id tr").length - 1;
                var fila = $('input[name="notas_i"]').attr("fila");
                var columna = $('input[name="notas_i"]').attr("columna");
                var idNota = $('input[name="notas_i"]').attr("idnota");
                var idEstudiante = $('input[name="notas_i"]').attr("idalumno");
                var str = idEstudiante + "_" + idNota + "_" + fila + "_" + columna;
                var arrTodo = new Array();
                $('input[name="notas_i"]').each(function (element) {

                    var textbx = document.getElementById(this.id);
                    var fila = textbx.getAttribute("fila");
                    var columna = textbx.getAttribute("columna");
                    var idNota = textbx.getAttribute("idnota");
                    var idAlumno = textbx.getAttribute("idalumno");
                    var oldVal = textbx.getAttribute("oldvalue");
                    var item = {};
                    item.idAlumno = idAlumno;
                    item.idNota = idNota;
                    item.Nota = textbx.value;
                    item.oldVal = oldVal;

                    arrTodo.push(item);
                    //console.log("fila: " + fila);
                    //console.log("columna: " + columna);
                    //console.log("idnota: " + idNota);
                    //console.log("idalumno: " + idAlumno);
                    //console.log("Valor: " + textbx.value);
                    //console.log("OldVal: " + oldVal);

                });
                console.log(arrTodo);

          



                const momentoComida = arrTodo.map(function (comida) {
                    var idAlumno = comida.idAlumno;
                    var idNota = comida.idNota;
                    var Nota = comida.Nota;
                    var oldVal = comida.oldVal;
                   
                    if (oldVal == Nota) {

                    }
                    else {
                        return idAlumno + ":" + idNota + ":" + Nota + "||";
                    }
                    //var nota = comida.Nota;
                    //var str = comida.idNota
                    //var array = str.split("_");
                    //var oldValue = array[4];
                    //if (oldValue == nota) {

                    //}
                    //else {

                    //    return array[0] + ":" + array[1] + ":" + comida.Nota + "||";
                    //}

                });

                var ìdNotaStr = momentoComida.toString();
                /*Agrupamos todos los input con name=cbxEstudiante*/
                //$('input[name="notas_i"]').each(function (element) {
                //    var item = {};
                //    item.idNota = this.id;
                //    item.Nota = this.value;
                //    arrTodo.push(item);
                //});

                //console.log(arrTodo);
                $.ajax({
                    type: "POST",
                    url: '/Notas.asmx/IngresarNotas',
                    data: "{asignatura:'" + asignatura +
                        "',ìdNotaStr:'" + ìdNotaStr +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        swal.fire(
                            "¡Exito!",
                            data.d,
                            "success"
                        )
                        tablaData(curso, asignatura);
                        getEstudiante(curso, asignatura);
                    },
                    error: function (err) { console.log("Error:" + err); },
                });





                $("#create .close").click();
            });
            $('#btnIngresarPromedios').on('click', function () {




                $('input[name="notas_i"]').each(function (element) {

                    var textbx = document.getElementById(this.id);
                    var fila = textbx.getAttribute("fila");
                    var columna = textbx.getAttribute("columna");
                    var idNota = textbx.getAttribute("idnota");
                    var idAlumno = textbx.getAttribute("idalumno");
                    var oldVal = textbx.getAttribute("oldvalue");

                    console.log("fila: " + fila);
                    console.log("columna: " + columna);
                    console.log("idnota: " + idNota);
                    console.log("idalumno: " + idAlumno);
                    console.log("Valor: " + textbx.value);
                    console.log("OldVal: " + oldVal);

                });








                //var nombre = $('#nombre_campo').val();
                //var curso = $('#curso').val();
                //var asignatura = $('#asignatura').val();

                //var EstudianteId = new Array();
                ///*Agrupamos todos los input con name=cbxEstudiante*/
                //var idA = $('input[name="notas_i"]').val();
                //parseInt(idA);
                //var rowCount = $("#tabla_id tr").length - 1;
                //var fila = $('input[name="notas_i"]').attr("fila");
                //var columna = $('input[name="notas_i"]').attr("columna");
                //var idNota = $('input[name="notas_i"]').attr("idnota");
                //var idEstudiante = $('input[name="notas_i"]').attr("idalumno");
                //var str = idEstudiante + "_" + idNota + "_" + fila + "_" + columna;
                //var arrTodo = new Array();
                ///*Agrupamos todos los input con name=cbxEstudiante*/
                //$('input[name="notas_i"]').each(function (element) {
                //    var item = {};
                //    item.idNota = this.id;
                //    item.Nota = this.value;
                //    arrTodo.push(item);
                //});

                //console.log(arrTodo);



                //const momentoComida = arrTodo.map(function (comida) {
                //    var nota = comida.Nota;
                //    var str = comida.idNota
                //    var array = str.split("_");
                //    var oldValue = array[4];
                //    if (oldValue == nota) {

                //    }
                //    else {

                //        return array[0] + ":" + array[1] + ":" + comida.Nota + "||";
                //    }


                //});

                //var ìdNotaStr = momentoComida.toString();
                //$.ajax({
                //    type: "POST",
                //    url: '/Notas.asmx/Promedio',
                //    data: "{asignatura:'" + asignatura +
                //        "',curso:'" + curso +
                //        "',ìdNotaStr:'" + ìdNotaStr +

                //        "'}",
                //    contentType: "application/json",
                //    datatype: "json",
                //    success: function (data) {
                //        $('#mostrar').html(data.d);
                //        //$("#promedio").html(data.d);
                //        //tablaData(curso, asignatura);
                //       // getEstudiante(curso, asignatura);
                //    },
                //    error: function (err) { console.log("Error:" + err); },
                //});





                //$("#create .close").click();
            });

            function limpiarCampos() {
                
                $('#EvaluacionId').val(0);
                $("#nombre_campo").val("");
                $("#f_prueba").val("");
                $("#h_inicial").val("");
                $("#h_fin").val("");
                $("#h_inicial").html("");
                $("#h_fin").html("");
            }

            $(document).on('click', '.notas_class', function () {
                //limpiarCampos();
                //document.getElementById("exampleModalLabel").innerHTML = "Editar Persona";
                var PersonId = $(this).attr("id");
                $("#EvaluacionId").val(PersonId);


                //var PersonId = document.getElementById("PersonId").value = PersonId;
                $("#nombre_campo").val($("#" + PersonId).html());
                //$("#btnIngresar").click();

                  $('#create').modal({
                    keyboard: true
                });
                //$("#segundoNombre").val($("#MiddleName" + PersonId).html());
                //$("#ApellidoMaterno").val($("#LastName" + PersonId).html());
                //$("#ApellidoPaterno").val($("#SecondLastName" + PersonId).html());
                //$("#codigo_generacion").val($("#GenerationCode" + PersonId).html());
                //$("#prefijo").val($("#Prefix" + PersonId).html());
                //$("#f_nacimiento").val($("#BirthDate" + PersonId).html());
                //$("#sexo_referencia_id").val($("#RefSexId" + PersonId).html());
                //$("hispana_latina_id").val($("#HispanicLatinoEthnicity" + PersonId).html());
                //$("#estado_ciudania_us_id").val($("#RefUSCitizenshipStatusId" + PersonId).html());
                //$("#tipo_visa_id").val($("#RefVisaTypeId" + PersonId).html());
                //$("#curso").val($("#Curso" + PersonId).html());

                //$("#estado_residencia").val($("#RefStateOfResidenceId" + PersonId).html());
                //$("#comprobante_residencia_id").val($("#RefProofOfResidencyTypeId" + PersonId).html());
                //$("#nivel_educacion_id").val($("#RefHighestEducationLevelCompletedId" + PersonId).html());
                //$("#verificacion_personal_id").val($("#RefPersonalInformationVerificationId" + PersonId).html());
                //$("#verificacion_f_nacimiento").val($("#BirthdateVerification" + PersonId).html());
                //$("#afiliacion_tribal_id").val($("#RefTribalAffiliationId" + PersonId).html());
                //console.log($("#StrFonos" + PersonId).val());
                //console.log($("#StrCorreo" + PersonId).val());
                //var arrFonos = $("#StrFonos" + PersonId).val().split("||");
                //var arrCorreos = $("#StrCorreo" + PersonId).val().split("||");


                //if (arrFonos == "") {
                //    agregarTelefono("", "");

                //}
                //for (var i = 0; i < arrFonos.length - 1; i++) {
                //    var arrFono = arrFonos[i].split(";");
                //    var idFono = arrFono[0];
                //    var fFono = arrFono[1];
                //    agregarTelefono(idFono, fFono);
                //}

                //if (arrCorreos == "") {
                //    agregarCorreo("", "");

                //}
                //for (var i = 0; i < arrCorreos.length - 1; i++) {
                //    var arrEmail = arrCorreos[i].split(";");
                //    var idCorreo = arrEmail[0];
                //    var CCorreo = arrEmail[2];
                //    agregarCorreo(idCorreo, CCorreo);
                //}
                //$('#create').modal({
                //    keyboard: true
                //});


            });


            $('#asignatura').on('change', function () {
                var curso = $('#curso').val();
                var asignatura = $('#asignatura').val();
                getEstudiante(curso, asignatura);
                tablaData(curso, asignatura);


            });
            $("#form_valid").validate({
                rules: {
                    nombre: {
                        required: true,
                        maxlength: 40

                    }
                  




                },
                messages: {
                    nombre: {
                        required: "Dato requerido",
                        maxlength: "No cumples con el limite de caracteres"

                    }
                }

            });


        });
    </script>
    <style>
        #nombre {
            width: 50%;
        }

        .notas_i {
            width: 20px;
            color: aqua;
        }
    </style>
    <header class="page-title-bar">
        <div class="d-flex flex-column flex-md-row">
            <h1 class="lead" style="text-align: center;">
                <span style="text-align: center;" class="font-weight-bold">Ingreso de Nota</span>
            </h1>
        </div>
    </header>
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 mb-3">
                <label>Curso</label>
                <select class="custom-select d-block w-100" id="curso">
                </select>
            </div>
            <div class="col-md-6 mb-3">
                <label>Asignatura</label>
                <select class="custom-select d-block w-100" id="asignatura">
                </select>
            </div>
        </div>
    </div>
    <br />
    <div class="section-block">

        <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnIngresar" style="margin: 15px;">
            <i class="flaticon2-plus"></i>
            Agregar Evaluación
        </button>

        <button class="btn btn-outline-primary btn-icon-sm" data-toggle="modal" type="button" id="btnIngresarNotas">
            <i class="flaticon2-plus"></i>
            Guardar
        </button>
        <input type="hidden" id="condicion" value="0" />

    </div>
 
    <br />
    <div class="container" style="overflow-x: auto;">
        <%--        <table class="table table-striped- table-bordered table-hover table-checkable" id="tabla_id" >
            <thead style="background-color:dimgray; border:2px solid black; color:black;">
                <tr id="cabecera_tabla" style="text-align:center;">

                </tr>
<%--                <tr>
                    <th style="width:20px; border-right: 2px  solid black;" >N°</th>
                    <th style="border-right: 2px  solid black;">Nombre</th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th  style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                </tr>
            </thead>
            <tbody id="mostrar" style="border:2px solid black; color:black; border-bottom: 2px solid black;">
            </tbody>
        </table>--%>
        <!-- .card -->
        <div class="card card-fluid">
            <!-- .card-header -->

            <div class="table-responsive">
                <!-- .table -->
                <table class="table table-striped" id="tabla_id">
                    <!-- thead -->
                    <thead class="thead-">
                        <tr id="cabecera_tabla">
                        </tr>
                    </thead>
                    <!-- /thead -->
                    <!-- tbody -->
                    <tbody id="mostrar">
                    </tbody>
                    <!-- /tbody -->
                </table>
                <!-- /.table -->
            </div>
            <!-- /.table-responsive -->
        </div>
        <!-- /.card -->

    </div>

    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Nota
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">

                        <div class="row">

                            <div class="col-md-6 mb-3">
                                <label>Nombre</label>
                                <input type="text" class="form-control" id="nombre_campo" name="nombre" required="">
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Fecha de Prueba</label>
                                <input type="date" class="form-control" id="f_prueba" name="f_prueba"  required="">
                            </div>
                            <div class="col-md-6 mb-3">     
                                <div class="form-group">
                                   <label class="control-label" for="flatpickr08">Hora Inicial</label> 
                                    <input id="h_inicial" type="text" class="form-control flatpickr-input" data-toggle="flatpickr" data-enable-time="true" data-no-calendar="true" data-date-format="H:i" readonly="readonly">
                                </div>  
                            </div>
                               <div class="col-md-6 mb-3">     
                                <div class="form-group">
                                   <label class="control-label" for="flatpickr08">Hora Final</label> 
                                    <input id="h_fin" type="text" class="form-control flatpickr-input" data-toggle="flatpickr" data-enable-time="true" data-no-calendar="true" data-date-format="H:i"  readonly="readonly">
                                </div>  
                            </div>


                            <input type="hidden" id="EvaluacionId" value="0" />

                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button id="btnCancelar" class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>

    </div>







</asp:Content>
