<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Anotacion.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Anotacion" %>
<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
<script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="sweetalert2.min.js"></script>
<link rel="stylesheet" href="sweetalert2.min.css">
<script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>


    <script  type="text/javascript">
        $(document).ready(function () {
            //Tabla 
            function limpiar() {

                $('#ambito').prop('selectedIndex', 0)
                $('#caracter').prop('selectedIndex', 0)
                $('#momento_incidente').prop('selectedIndex', 0)
                $('#tipo_incidente').prop('selectedIndex', 0)
                $('#rol_incidente').prop('selectedIndex', 0)
                $('#concencuencias_disciplinarias').prop('selectedIndex', 0)
                $("#fecha").val("");
                $("#puntaje").val("");
                $("#detalle").val("");
                $("#AnotacionId").val(0);
                $("#hora").val("");
                $("#fecha_inicial_d").val("");
                $("#fecha_fin_d").val("");
                document.getElementById("exampleModalLabel").innerHTML = "Agregar Anotación";

            }
            function listar() {

                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/SelectRefDisciplinaryActionTaken',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#concencuencias_disciplinarias").html(data.d);
                      

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/SelectRefIncidentBehavior',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#tipo_incidente").html(data.d);
                     
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                var ColegioID = sessionStorage.getItem('Colegio');
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/SelectRefIncidentTimeDescriptionCode',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#momento_incidente").html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
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
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/SelectRefIncidentPersonRoleType',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#rol_incidente').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/Puntaje',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        
                        if (data.d == '0') {
                            $("#puntaje_div").show();
                            $("#puntaje_tabla").show();

                        }
                        else  if(data.d == '1'){

                        }
                        $("#PuntajeID").val(data.d);

                       
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/Ambito',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {

                        if (data.d == '0') {
                            $("#ambito_div").show();
                            $("#ambito_tabla").show();

                        }
                        else if (data.d == '1') {

                        }
                        $("#AmbitoID").val(data.d);


                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/SelectAmbito',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#ambito').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/SelectCaracter',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#caracter').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                //$.ajax({
                //    type: "POST",
                //    url: 'Anotacion.asmx/GetAnotacion',
                //    data: "{}",
                //    contentType: "application/json",
                //    datatype: "json",
                //    success: function (data) {
                //        //alert(data.d);
                //        $('#mostrar').html(data.d);

                //    },
                //    error: function (err) {
                //        console.log("Error:" + err);
                //    },
                //});



            }
            listar();
            $('#curso').on('change', function () {
                var curso = $('#curso').val();
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/GetAsignatura',
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

                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/GetEstudiante',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_estudiante').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                document.getElementById("div_estudiante").style.display = "block";


            });
            $('#btn_Crear_MomentoIncidente').on('click', function () {
                $("#btnCancelar").click();
            });
            $('#btn_Crear_TipoIncidenteUno').on('click', function () {
                $("#btnCancelar").click();


            });
            $('#btn_consecuencias').on('click', function () {
                $("#btnCancelar").click();


            });
            $('#btnAgregarUno').on('click', function () {
                $("#btnCancelarUno").click();
                var nombre = $("#nombreUno").val();
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/InsertRefIncidentTimeDescriptionCode',
                    data: "{nombre:'" + nombre +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        console.log("" + data.d);
                        $("#nombreUno").val("");
                        $.ajax({
                            type: "POST",
                            url: 'Anotacion.asmx/SelectRefIncidentTimeDescriptionCode',
                            data: "{}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#momento_incidente").html(data.d);
                                $("#btnCancelarUno").click();
                                $("#btnAbrirModal").click();

                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            });
            $('#btnAgregarDos').on('click', function () {
                $("#btnCancelarDos").click();
                var nombre = $("#nombreDos").val();
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/InsertRefIncidentBehavior',
                    data: "{nombre:'" + nombre +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        console.log("" + data.d);
                        $("#nombreUno").val("");
                        $.ajax({
                            type: "POST",
                            url: 'Anotacion.asmx/SelectRefIncidentBehavior',
                            data: "{}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#tipo_incidente").html(data.d);
                                $("#btnCancelarDos").click();
                                $("#btnAbrirModal").click();

                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            });
            $('#btnAgregarTres').on('click', function () {
                $("#btnCancelarTres").click();
                var nombre = $("#nombreTres").val();
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/InsertRefDisciplinaryActionTaken',
                    data: "{nombre:'" + nombre +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        console.log("" + data.d);
                        $("#nombreTres").val("");
                        $.ajax({
                            type: "POST",
                            url: 'Anotacion.asmx/SelectRefDisciplinaryActionTaken',
                            data: "{}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#concencuencias_disciplinarias").html(data.d);
                                $("#btnCancelarTres").click();
                                $("#btnAbrirModal").click();

                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            });
            $('#asignatura').on('change', function () {
                var asignatura = $('#asignatura').val();
                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/GetDocente',
                    data: "{asignatura:'" + asignatura +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#docente').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#docente').on('change', function () {
            });
            $('#btnAbrirModal').on('click', function () {
                limpiar();
            });
            $('#btnAgregar').click(function () {
                var arreglo = new Array();


                $('input:checkbox[name=nombre_estudiante]:checked').each(function (element) {
                    var item = {};
                    item.valor = this.value;
                    arreglo.push(item);
                });


                const momentoComida = arreglo.map(function (comida) {
                    var data = comida.valor;
                    return data + "||";



                });


                var EstudianteId = momentoComida.toString();
                var curso = $("#curso").val();
                var asignatura = $("#asignatura").val();
                var docente = $("#docente").val();
                var ambito = $("#ambito").val();

                if (ambito == '') {
                    ambito = 0;
                }
              
                var caracter = $("#caracter").val();
                var fecha = $("#fecha").val();
                var puntaje = $("#puntaje").val();
                if (puntaje == '') {
                    puntaje = 0;
                }
                var hora = $("#hora").val();
                var momento_incidente = $("#momento_incidente").val();
                var tipo_incidente = $("#tipo_incidente").val();
                var rol_incidente = $("#rol_incidente").val();
                var concencuencias_disciplinarias = $("#concencuencias_disciplinarias").val();
                var fecha_inicial_d = $("#fecha_inicial_d").val();
                var fecha_fin_d = $("#fecha_fin_d").val();

                
                
                var costo_asociado = "";
                var uso_arma = "";
                var explusacion_anio_completo = "";
                var expulsacion_medio_anio = "";

                if ($('[name="costo_asociado"]').is(':checked')) {
                    costo_asociado = 0;
                }
                else {
                    costo_asociado = 1;
                }

                if ($('[name="uso_arma"]').is(':checked')) {
                    uso_arma = 0;
                }
                else {
                    uso_arma = 1;
                }


                if ($('[name="explusacion_anio_completo"]').is(':checked')) {
                    explusacion_anio_completo = 0;
                }
                else {
                    explusacion_anio_completo = 1;
                }


                if ($('[name="expulsacion_medio_anio"]').is(':checked')) {
                    expulsacion_medio_anio = 0;
                }
                else {
                    expulsacion_medio_anio = 1;
                }

                
                //momento_incidente

                var detalle = $("#detalle").val();
                var AnotacionesId = $("#AnotacionId").val();
                if (AnotacionesId > 0) {
                    $.ajax({
                        type: "POST",
                        url: '/Anotacion.asmx/EditarIncident',
                        data: "{EstudianteId:'" + EstudianteId +
                            "',hora:'" + hora +
                            "',momento_incidente:'" + momento_incidente +
                            "',detalle:'" + detalle +
                            "',tipo_incidente:'" + tipo_incidente +
                            "',rol_incidente:'" + rol_incidente +
                            "',uso_arma:'" + uso_arma +
                            "',costo_asociado:'" + costo_asociado +
                            "',fecha_inicial_d:'" + fecha_inicial_d +
                            "',fecha_fin_d:'" + fecha_fin_d +
                            "',explusacion_anio_completo:'" + explusacion_anio_completo +
                            "',expulsacion_medio_anio:'" + expulsacion_medio_anio +
                            "',ambito:'" + ambito +
                            "',caracter:'" + caracter +
                            "',fecha:'" + fecha +
                            "',puntaje:'" + puntaje +
                            "',concencuencias_disciplinarias:'" + concencuencias_disciplinarias +
                            "',AnotacionesId:'" + AnotacionesId +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (responseFromServer) {
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: responseFromServer.d,
                                showConfirmButton: false,
                                timer: 1500
                            })
                            var pt = $("#PuntajeID").val();
                            var pt2 = $("#AmbitoID").val();

                            $.ajax({
                                type: "POST",
                                url: 'Anotacion.asmx/GetAnotacion',
                                data: "{EstudianteId:'" + EstudianteId +
                                    "',pt:'" + pt +
                                    "',pt2:'" + pt2 +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {
                                    document.getElementById("tabla_datos").style.display = "block";
                                    $('#mostrar').html(data.d);
                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
                            });
                            $("#btnCancelar").click();
                            limpiar();
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }
                else {
                    $.ajax({
                        type: "POST",
                        url: '/Anotacion.asmx/IngresarIncident',
                        data: "{EstudianteId:'" + EstudianteId +
                            "',hora:'" + hora +
                            "',momento_incidente:'" + momento_incidente +
                            "',detalle:'" + detalle +
                            "',tipo_incidente:'" + tipo_incidente +
                            "',rol_incidente:'" + rol_incidente +
                            "',uso_arma:'" + uso_arma +
                            "',costo_asociado:'" + costo_asociado +
                            "',fecha_inicial_d:'" + fecha_inicial_d +
                            "',fecha_fin_d:'" + fecha_fin_d +
                            "',explusacion_anio_completo:'" + explusacion_anio_completo +
                            "',expulsacion_medio_anio:'" + expulsacion_medio_anio +
                            "',ambito:'" + ambito +
                            "',caracter:'" + caracter +
                            "',fecha:'" + fecha +
                            "',puntaje:'" + puntaje +
                            "',concencuencias_disciplinarias:'" + concencuencias_disciplinarias +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (responseFromServer) {
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: responseFromServer.d,
                                showConfirmButton: false,
                                timer: 1500
                            })
                            var pt = $("#PuntajeID").val();
                            var pt2 = $("#AmbitoID").val();

                            $.ajax({
                                type: "POST",
                                url: 'Anotacion.asmx/GetAnotacion',
                                data: "{EstudianteId:'" + EstudianteId +
                                    "',pt:'" + pt +
                                    "',pt2:'" + pt2 +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {
                                    document.getElementById("tabla_datos").style.display = "block";
                                    $('#mostrar').html(data.d);
                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
                            });
                            $("#btnCancelar").click();
                            limpiar();
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }
               


                //if (AnotacionesId > 0) {
                //    $.ajax({
                //        type: "POST",
                //        url: '/Anotacion.asmx/EditarAnotacion',
                //        data: "{EstudianteId:'" + EstudianteId +
                //            "',curso:'" + curso +
                //            "',asignatura:'" + asignatura +
                //            "',docente:'" + docente +
                //            "',ambito:'" + ambito +
                //            "',caracter:'" + caracter +
                //            "',fecha:'" + fecha +
                //            "',puntaje:'" + puntaje +
                //            "',detalle:'" + detalle +
                //            "',AnotacionesId:'" + AnotacionesId +
                //            "'}",
                //        contentType: "application/json",
                //        datatype: "json",
                //        success: function (responseFromServer) {
                //            Swal.fire({
                //                position: 'top-center',
                //                icon: 'success',
                //                title: responseFromServer.d,
                //                showConfirmButton: false,
                //                timer: 1500
                //            })
                //            var pt = $("#PuntajeID").val();
                //            var pt2 = $("#AmbitoID").val();

                //            $.ajax({
                //                type: "POST",
                //                url: 'Anotacion.asmx/GetAnotacion',
                //                data: "{EstudianteId:'" + EstudianteId +
                //                    "',pt:'" + pt +
                //                    "',pt2:'" + pt2 +
                //                    "'}",
                //                contentType: "application/json",
                //                datatype: "json",
                //                success: function (data) {
                //                    document.getElementById("tabla_datos").style.display = "block";
                //                    $('#mostrar').html(data.d);
                //                },
                //                error: function (err) {
                //                    console.log("Error:" + err);
                //                },
                //            });
                            
                //            $("#btnCancelar").click();

                //        },
                //        error: function (err) { console.log("Error:" + err); },
                //    });

                //}
                //else {
                //    $.ajax({
                //        type: "POST",
                //        url: '/Anotacion.asmx/IngresarAnotacion',
                //        data: "{EstudianteId:'" + EstudianteId +
                //            "',curso:'" + curso +
                //            "',asignatura:'" + asignatura +
                //            "',docente:'" + docente +
                //            "',ambito:'" + ambito +
                //            "',caracter:'" + caracter +
                //            "',fecha:'" + fecha +
                //            "',puntaje:'" + puntaje +
                //            "',detalle:'" + detalle +
                //            "'}",
                //        contentType: "application/json",
                //        datatype: "json",
                //        success: function (responseFromServer) {
                //            Swal.fire({
                //                position: 'top-center',
                //                icon: 'success',
                //                title: responseFromServer.d,
                //                showConfirmButton: false,
                //                timer: 1500
                //            })
                //            var pt = $("#PuntajeID").val();
                //            var pt2 = $("#AmbitoID").val();

                //            $.ajax({
                //                type: "POST",
                //                url: 'Anotacion.asmx/GetAnotacion',
                //                data: "{EstudianteId:'" + EstudianteId +
                //                    "',pt:'" + pt +
                //                    "',pt2:'" + pt2 +
                //                    "'}",
                //                contentType: "application/json",
                //                datatype: "json",
                //                success: function (data) {
                //                    document.getElementById("tabla_datos").style.display = "block";
                //                    $('#mostrar').html(data.d);
                //                },
                //                error: function (err) {
                //                    console.log("Error:" + err);
                //                },
                //            });
                //            $("#btnCancelar").click();
                //            limpiar();
                //        },
                //        error: function (err) { console.log("Error:" + err); },
                //    });
                //}
            
                 });

            
            $('#btnTodoPresente').click(function () {
                document.querySelectorAll('#div_estudiante input[type=checkbox]').forEach(function (checkElement) {
                    checkElement.checked = true;
                });



            });

            $(document).on('click', '.btn_editar', function () {
               


                document.getElementById("exampleModalLabel").innerHTML = "Editar Anotación";

                var PersonId = $(this).attr("id");
                var PersonId = document.getElementById("AnotacionId").value = PersonId;
                var fecha = $("#IncidentDate_" + PersonId).val();
                var fechaStart = $("#DisciplinaryActionStartDate_" + PersonId).val();
                var fechaEnd = $("#DisciplinaryActionEndDate_" + PersonId).val();

                var fecha2 = fecha.toString();
                var fechaStart2 = fechaStart.toString();
                var fechaEnd2 = fechaEnd.toString();

                var hora = $("#IncidentTime_" + PersonId).val();
                var momento = $("#RefIncidentTimeDescriptionCodeId_" + PersonId).val();
                var detalle = $("#IncidentDescription_" + PersonId).val();
                var tipo_incidente = $("#RefIncidentBehaviorId_" + PersonId).val();
                var rol = $("#RefIncidentPersonRoleTypeId_" + PersonId).val();
                var consencuancias = $("#RefDisciplinaryActionTakenId_" + PersonId).val();
                var ambito = $("#ambitoId_" + PersonId).val();
                var caracter = $("#CaracterId_" + PersonId).val();
                var puntaje = $("#Puntaje_" + PersonId).val();

                
                const [month, day, year] = fecha2.split('-');
                const [month2, day2, year2] = fechaStart2.split('-');
                const [month3, day3, year3] = fechaEnd2.split('-');

                var anio = year.substring(0, 4);
                var anio2 = year2.substring(0, 4);
                var anio3 = year3.substring(0, 4);

                var fecha_completa = anio + "-" + day + "-" + month;
                var fecha_completa2 = anio2 + "-" + day2 + "-" + month2;
                var fecha_completa3 = anio3 + "-" + day3 + "-" + month3;

                $("#fecha").val(fecha_completa).html();
                $("#puntaje").val(puntaje).html();

                $("#fecha_inicial_d").val(fecha_completa2).html();
                $("#fecha_fin_d").val(fecha_completa3).html();
                $("#ambito").val(ambito).html();
                $("#caracter").val(caracter).html();

                


                $("#hora").val(hora).html();
                $("#momento_incidente").val(momento).html();
                $("#detalle").val(detalle).html();
                $("#tipo_incidente").val(tipo_incidente).html();
                $("#rol_incidente").val(rol).html();
                $("#concencuencias_disciplinarias").val(consencuancias).html();

                
                //var nombre = $("#alumno_" + PersonId).val();
                //$("#nombre_" + nombre).attr("checked", "checked");
                //var ambito = $("#ambbito_" + PersonId).val();

                //var nombre = $("#nombre_" + PersonId).val();
                //$("#ambito").val(ambito).html();

                //var caracter = $("#caracter_" + PersonId).val();
                //$("#caracter").val(caracter).html();


                //var puntaje = $("#puntaje_" + PersonId).val();
                //$("#puntaje").val(puntaje).html();

                //var detalle = $("#detalle_" + PersonId).val();
                //$("#detalle").val(detalle).html();

              /*  2022 - 08 - 17*/


                $('#create').modal({
                    keyboard: true
                });

            });

            $(document).on('click', '.btn_eliminar', function () {



                var AmbitoId = $(this).attr("id");
                const swalWithBootstrapButtons = Swal.mixin({
                    customClass: {
                        confirmButton: 'btn btn-success',
                        cancelButton: 'btn btn-danger'
                    },
                    buttonsStyling: false
                })

                swalWithBootstrapButtons.fire({
                    title: '¿Está seguro de eliminar este registro?',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Eliminar',
                    cancelButtonText: 'Cancelar',
                    reverseButtons: true
                }).then((result) => {
                    if (result.isConfirmed) {
                        swalWithBootstrapButtons.fire(
                            $.ajax({
                                type: "POST",
                                url: '/Anotacion.asmx/EliminarAnotacion',
                                data: "{AmbitoId:'" + AmbitoId +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                cache: false,
                                success: function (response) {
                                    swal.fire(
                                        "¡Exito!",
                                        response.d,
                                        "success"
                                    )
                                    //  $('#tipo_persona').prop('selectedIndex', 0);
                                    listar();


                                },
                                failure: function (response) {
                                    swal.fire(
                                        "Internal Error",
                                        "Oops, your note was not saved.", // had a missing comma
                                        "error"
                                    )
                                }
                            })
                        )
                    } else if (
                        /* Read more about handling dismissals below */
                        result.dismiss === Swal.DismissReason.cancel
                    ) {
                        swalWithBootstrapButtons.fire(
                            'Cancelada',
                            'Operación no realizada :)',
                            'error'
                        )
                    }
                })


            });

            $(document).on('click', '.btn_prueba', function () {
               
                var arreglo = new Array();


                $('input:checkbox[name=nombre_estudiante]:checked').each(function (element) {
                    var item = {};
                    item.valor = this.value;
                    arreglo.push(item);
                });


                const momentoComida = arreglo.map(function (comida) {
                    var data = comida.valor;
                    return data + "||";



                });

                var EstudianteId = momentoComida.toString();
               var pt = $("#PuntajeID").val();
                var pt2 = $("#AmbitoID").val();

                $.ajax({
                    type: "POST",
                    url: 'Anotacion.asmx/GetAnotacion',
                    data: "{EstudianteId:'" + EstudianteId +
                        "',pt:'" + pt +
                        "',pt2:'" + pt2 +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        document.getElementById("tabla_datos").style.display = "block";
                        $('#mostrar').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            });


        });
    </script>
    <input type="hidden" value="0"  id="AnotacionId"/>
        <input type="hidden" value="0"  id="PuntajeID"/>
            <input type="hidden" value="0"  id="AmbitoID"/>

        <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Anotación</h3>
                            </div>
                        </div>
                            <div class="col-md-6 mb-3">
                                            <label>Curso</label>
                                            <select class="custom-select d-block w-100" id="curso"  required="">
                                            </select>
                            </div>
                           <div class="col-md-6 mb-3">
                                            <label>Asignatura</label>
                                            <select class="custom-select d-block w-100" id="asignatura"  required="">
                                            </select>
                            </div>
                          <div class="col-md-6 mb-3">
                                            <label>Docente</label>
                                            <select class="custom-select d-block w-100" id="docente"  required="">
                                            </select>
                            </div>
                         
                             <div class="col-md-12" >
                               <div class="row">
                         
                                     <div class="col-md-3 mb-3" style="margin:4px"  >
                                              <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnAbrirModal">
                                                <i class="flaticon2-plus"></i>
                                                Nuevo Detalle de Anotación
                                            </button>
                                       </div>
                         
                               </div>

                           </div>
                 
                          
                       
                    </div>
                </div>
            </div>
          
        </div></div>
        <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Seleccione Alumno</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-lg"  type="button" id="btnTodoPresente">
                                    Seleccionar Todo
                                </button>
                            </div>
                        </div>
                        <div class="col-md-12">
                              <div >
                                  <form   id="div_estudiante" style="display:none;" >

                                  </form>
                        

                               </div>

            </div>                        
                    </div>
                </div>
            </div>
           
        </div>
            </div>






            <div class="card card-custom" id="tabla_datos" style="display:none;">
        <div class="row">
            <div class="col-md-12">
                             <div class="card-body">
            <div class="container" style="overflow-x: auto;">
                <table class="table table-striped- table-bordered table-hover table-checkable" id="tabla_id">
                    <thead>
                        <tr>
                          <th>Acción</th>
                             <th>Id</th>
                            <th>Estudiante</th>   
                              <th>Fecha </th>   
                            <th>Hora </th>   
                           <th >Detalle</th>     
                           <th   id="puntaje_tabla" style="display:none;">Puntaje</th>      
                           <th id="ambito_tabla" style="display:none;">Ambito</th>   

                            <th  style="display:none;">Alumno</th>   
                            <th  style="display:none;">Docente</th>    
                             <th  style="display:none;">Caracter</th>  
                        </tr>
                    </thead>
                    <tbody id="mostrar">
                     
                    </tbody>
                </table>
            </div>
        </div>
    </div>

            </div>
           
        </div>













   
<%--           Modal para crear una nueva anotacion--%>

             <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align:left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nuevo Detalle de Anotación
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                             <div class="col-md-6 mb-3">
                                <label>Hora de Inidente</label>
                                 <input class='form-control' id='hora' type='time' required=''/>
                             </div>
                              <div class="col-md-6 mb-3">
                                  <div class="row">
                                      <div class="col-md-6 mb-3">
                                          <label>Momento del incidente</label>
                                          <select class="custom-select d-block w-100" id="momento_incidente"  required=""></select>
                                      </div>
                                       <div class="col-md-6 mb-3">
                                         <button class="btn btn-outline-primary btn-icon-sm" data-target="#Crear_MomentoIncidente" data-toggle="modal" type="button" id="btn_Crear_MomentoIncidente"  style="margin:30px;"  >
                                                <i class="flaticon2-plus"></i>
                                                     +
                                         </button>
                                      </div>

                                  </div>
                             </div>
                              <div class="col-md-6 mb-3"  >
                                               <label>Detalle de Anotación</label>
                                                 <textarea class="form-control" id="detalle" rows="3" required=""></textarea>
                              </div>
                            <div class="col-md-6 mb-3">
                                  <div class="row">
                                      <div class="col-md-6 mb-3">
                                          <label>Tipo del incidente</label>
                                          <select class="custom-select d-block w-100" id="tipo_incidente"  required=""></select>
                                      </div>
                                       <div class="col-md-6 mb-3">
                                         <button class="btn btn-outline-primary btn-icon-sm" data-target="#Crear_TipoIncidente" data-toggle="modal" type="button" id="btn_Crear_TipoIncidenteUno"  style="margin:30px;"  >
                                                <i class="flaticon2-plus"></i>
                                                     +
                                         </button>
                                      </div>

                                  </div>
                             </div>

                              <div class="col-md-6 mb-3"  >
                                               <label>Rol dentro del Incidente</label>
                                            <select class="custom-select d-block w-100" id="rol_incidente"  required="">
                                            </select>
                             </div>
                               <div class="col-md-6 mb-3">
                                  <label>Uso de Armas</label>
                                   <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox" id="uso_arma" name="uso_arma"   class="switcher-input"  checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="HispanaSi()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="HispanaNo()" value="0">No</span>
                                  </label>   
                                </div>  
                               </div>


                               <div class="col-md-6 mb-3">
                                  <label>Costo asociado</label>
                                   <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox" id="costo_asociado" name="costo_asociado"   class="switcher-input"  checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="HispanaSi()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="HispanaNo()" value="0">No</span>
                                  </label>   
                                </div>  
                               </div>

                                 <div class="col-md-6 mb-3">
                                  <div class="row">
                                      <div class="col-md-6 mb-3">
                                          <label>Concecuencias Disciplinarias</label>
                                          <select class="custom-select d-block w-100" id="concencuencias_disciplinarias"  required=""></select>
                                      </div>
                                       <div class="col-md-6 mb-3">
                                         <button class="btn btn-outline-primary btn-icon-sm" data-target="#Crear_Concecuencias" data-toggle="modal" type="button" id="btn_consecuencias"  style="margin:30px;"  > >
                                                <i class="flaticon2-plus"></i>
                                                     +
                                         </button>
                                      </div>

                                  </div>
                             </div>


                                     <div class="col-md-6 mb-3"  >
                                               <label>Fecha Inicial Disciplinaria </label>
                                             <input type="date" class="form-control" id="fecha_inicial_d" name="fecha" required="" >

                                       </div>

                            <div class="col-md-6 mb-3"  >
                                               <label>Fecha Final Disciplinaria </label>
                                             <input type="date" class="form-control" id="fecha_fin_d" name="fecha" required="" >

                                       </div>
                                  


                                <div class="col-md-6 mb-3">
                                  <label>Expulsación por año completo</label>
                                   <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox" id="explusacion_anio_completo" name="explusacion_anio_completo"   class="switcher-input"  checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="HispanaSi()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="HispanaNo()" value="0">No</span>
                                  </label>   
                                </div>  
                               </div>

                             <div class="col-md-6 mb-3">
                                  <label>Expulsación por medio año</label>
                                   <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox" id="expulsacion_medio_anio" name="expulsacion_medio_anio"   class="switcher-input"  checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="HispanaSi()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="HispanaNo()" value="0">No</span>
                                  </label>   
                                </div>  
                               </div>

                                <div class="col-md-6 mb-3" id="ambito_div" style="display:none;">
                                               <label>Ambito</label>
                                            <select class="custom-select d-block w-100" id="ambito"  required="">
                                            </select>
                                       </div>
                                      <div class="col-md-6 mb-3"  >
                                               <label>Caracter</label>
                                            <select class="custom-select d-block w-100" id="caracter"  required="">
                                            </select>
                                       </div>
                                     <div class="col-md-6 mb-3"  >
                                               <label>Fecha</label>
                                             <input type="date" class="form-control" id="fecha" name="fecha" required="" >

                                       </div>
                                    <div class="col-md-6 mb-3"  id="puntaje_div" style="display:none;"  >
                                               <label>Puntaje</label>
                                             <input class="form-control" type="text"  id="puntaje" required=""/>
                                       </div>
                          
                            

                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelar"  data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>
       </div>

<%--    Modal para crear opcion del select Crear Momento Incidente--%>

        <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="Crear_MomentoIncidente" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align:left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="">Nuevo Momento Incidente
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="" name="form_valid">
                        <div class="row">
                              <div class="col-md-6 mb-3">
                                <label >Nombre </label>
                                <input class="form-control" type="text"  id="nombreUno" required=""/>
                            </div>
                            

                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelarUno"  data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary" type="button" id="btnAgregarUno">Guardar</button>


                </div>

            </div>
        </div>
       </div>


<%--        Modal para crear opcion del select Crear TIPO DE INCIDENTE--%>

       <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="Crear_TipoIncidente" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align:left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="">Nuevo Tipo de Incidente
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="" name="form_valid">
                        <div class="row">
                              <div class="col-md-6 mb-3">
                                <label >Nombre </label>
                                <input class="form-control" type="text"  id="nombreDos" required=""/>
                            </div>
                            

                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelarDos"  data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary" type="button" id="btnAgregarDos">Guardar</button>


                </div>

            </div>
        </div>
       </div>


<%--    modal para crear concecuencia del incidente--%>

           <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="Crear_Concecuencias" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align:left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="">Nueva Concecuencias Disciplinarias
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="" name="form_valid">
                        <div class="row">
                              <div class="col-md-6 mb-3">
                                <label >Nombre </label>
                                <input class="form-control" type="text"  id="nombreTres" required=""/>
                            </div>
                            

                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelarTres"  data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary" type="button" id="btnAgregarTres">Guardar</button>


                </div>

            </div>
        </div>
       </div>


</asp:Content>