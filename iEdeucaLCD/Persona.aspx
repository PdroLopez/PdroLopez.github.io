<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Persona.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Persona" %>

<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="jquery-3.6.0.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%--<script src="sweetalert2.min.js"></script>--%>
    <%--<link rel="stylesheet" href="sweetalert2.min.css">--%>
    <script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
    <style>
        label.error {
            width: 100%;
            margin-top: .25rem;
            font-size: 80%;
            color: #b76ba3;
        }
    </style>
    <script type="text/javascript">

     

        $(document).ready(function () {

            //$('#tabla_id').DataTable();
           
            $("#sorting").hide();
            function agregarTelefono(idFono, fFono) {
                var idx = parseInt($('#idxTelefono').val()) + 1;
                $("#col_telefono").append("<br><div class='row' id='row_fono" + idx + "'> <div class='col-6'><input type='text' class='form-control bt' id='telefono" + idx + "' data='" + idFono + "' dataold='" + fFono + "' value='" + fFono + "' name='telefonoxd' required=''/> </div> <div class='col-6'><button type='button' class='btn btn-xl btn-icon btn-secundary btn_eliminar_telefono'id='" + idx + "'><i class='fas fa-minus-circle'></i></button></div></div> ");
                $('#idxTelefono').val(idx);
            }
            function agregarCorreo(idCorreo, CCorreo) {
                var idx = parseInt($('#idxCorreo').val()) + 1;
                $("#col_correo").append("<br><div class='row' id='row_correo" + idx + "'> <div class='col-6'><input type='email' class='form-control bt' id='correo" + idx + "' data='" + idCorreo + "' dataold='" + CCorreo + "' value='" + CCorreo + "' required=''/> </div> <div class='col-6'><button type='button' class='btn btn-xl btn-icon btn-secundary btn_eliminar_correo'id='" + idx + "'><i class='fas fa-minus-circle'></i></button></div></div> ");
                $('#idxCorreo').val(idx);
            }
            var Fn = {
                // Valida el rut con su cadena completa "XXXXXXXX-X"
                validaRut: function (rutCompleto) {
                    rutCompleto = rutCompleto.replace("‐", "-");
                    if (!/^[0-9]+[-|‐]{1}[0-9kK]{1}$/.test(rutCompleto))
                        return false;
                    var tmp = rutCompleto.split('-');
                    var digv = tmp[1];
                    var rut = tmp[0];
                    if (digv == 'K') digv = 'k';

                    return (Fn.dv(rut) == digv);
                },
                dv: function (T) {
                    var M = 0, S = 1;
                    for (; T; T = Math.floor(T / 10))
                        S = (S + T % 10 * (9 - M++ % 6)) % 11;
                    return S ? S - 1 : 'k';
                }
            }
            
            function listar() {
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
                $.ajax({
                    type: "POST",
                    url: 'Persona.asmx/SelectTipoPersona',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#tipo_persona').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Persona.asmx/SelectSex',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#sexo_referencia_id').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Persona.asmx/SelectUS',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#estado_ciudania_us_id').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Persona.asmx/SelectTipoVisa',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#tipo_visa_id').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: '/Persona.asmx/SelectEstadoResidencia',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#estado_residencia').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: '/Persona.asmx/SelectComprobanteResidencia',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#comprobante_residencia_id').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: '/Persona.asmx/NivelEducacion',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#nivel_educacion_id').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: '/Persona.asmx/VerificacionPersonal',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#verificacion_personal_id').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: '/Persona.asmx/AfiliacionTribal',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#afiliacion_tribal_id').html(data.d);



                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            }
            listar();
            $.ajax({
                type: "POST",
                url: 'Persona.asmx/RefPersonRelationShip',
                data: "{}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    $('#PersonRelation').html(data.d);
                },
                error: function (err) {
                    console.log("Error:" + err);
                }
            });
            $('#tipo_persona').on('change', function () {
                var tipo_persona = $("#tipo_persona").val();
                var ColegioId = sessionStorage.getItem('Colegio');

                $.ajax({
                    type: "POST",
                    url: 'Persona.asmx/SeleccionarPersona',
                    data: "{tipo_persona:'" + tipo_persona +
                        "',ColegioId:'" + ColegioId +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#curso').prop('selectedIndex', 0);
                        if (tipo_persona == 5) {

                            $('#mostrar').html(data.d);
                            document.getElementById("div_curso").style.display = 'none';
                            document.getElementById("div_estudiante").style.display = 'none';
                            document.getElementById("div_rut").style.display = 'none';
                            document.getElementById("class_tipo_relacion").style.display = 'none';

                        }

                        if (tipo_persona == 6) {
                            document.getElementById("div_curso").style.display = 'block';
                            document.getElementById("div_estudiante").style.display = 'none';
                            document.getElementById("div_rut").style.display = 'none';
                            document.getElementById("class_tipo_relacion").style.display = 'none';

                            $.ajax({
                                type: "POST",
                                url: 'Asignatura.asmx/SelectCurso',
                                data: "{}",
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
                        if (tipo_persona == 11) {
                            document.getElementById("div_curso").style.display = 'none';
                            document.getElementById("div_estudiante").style.display = 'none';
                            document.getElementById("div_rut").style.display = 'none';
                            document.getElementById("class_tipo_relacion").style.display = 'none';



                        }
                        if (tipo_persona == 12) {
                            console.log("AA12");
                            document.getElementById("class_tipo_relacion").style.display = 'block';

                            //document.getElementById("div_estudiante").style.display = 'block';
                            document.getElementById("div_curso").style.display = 'block';
                            document.getElementById("div_estudiante").style.display = 'block';
                            document.getElementById("div_rut").style.display = 'block';
                            $('#btnIngresar').hide();
                            document.getElementById("div_curso").style.display = 'block';
                            document.getElementById("class_tipo_relacion").style.display = 'block';

                        }
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#curso').on('change', function () {
                var curso = $("#curso").val();
                var tipo_persona = $("#tipo_persona").val();
                var ColegioId = sessionStorage.getItem('Colegio');

                if (tipo_persona == 6) {
                    $.ajax({
                        type: "POST",
                        url: 'Persona.asmx/SearchCurso',
                        data: "{curso:'" + curso +
                            "',ColegioId:'" + ColegioId +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (data) {
                            $('#mostrar').html(data.d);


                        },
                        error: function (err) {
                            console.log("Error:" + err);
                        },
                    });


                }
                if (tipo_persona == 12) {
                    $.ajax({
                        type: "POST",
                        url: 'Persona.asmx/SelectEstudiante',
                        data: "{curso:'" + curso +
                            "',ColegioId:'" + ColegioId +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (data) {
                            //alert(data.d);
                            $('#estudiante').html(data.d);

                        },
                        error: function (err) {
                            console.log("Error:" + err);
                        },
                    });


                }
            

            });

            $('#estudiante').on('change', function () {
               // $('#btnIngresar').show();
                var estudiante = $("#estudiante").val();
                var ColegioId = sessionStorage.getItem('Colegio');

                $.ajax({
                    type: "POST",
                    url: 'Persona.asmx/getApoderado',
                    data: "{estudiante:'" + estudiante +
                        "',ColegioId:'" + ColegioId +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#mostrar').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });


            });

            $('#agregarCorreo').click(function () {
                agregarCorreo(0, "");
            });

            $('#AgregarTelefono').click(function () {
                agregarTelefono(0, "");
            });
            $('#btnAgregar').click(function () {
                var idx = $('#idxTelefono').val();
                var idxCorreo = $('#idxCorreo').val();

                $("#strEditado").val('');
                $("#strNuevoFonos").val('');
                $("#strEditadoCorreo").val('');
                $("#strNuevoCorreo").val('');

                for (var i = 1; i <= idx; i++) {
                    if ($('#telefono' + i).attr('data') == 0) {
                        $("#strNuevoFonos").val($("#strNuevoFonos").val() + $('#telefono' + i).val() + "||");
                        console.log("if:" + $('#telefono' + i).val());
                    }
                    else {

                        var FonosNuevos = $('#telefono' + i).val();
                        var FonosAntiguos = $('#telefono' + i).attr('dataold');
                        if (FonosNuevos != FonosAntiguos) {
                            console.log("else:" + $('#telefono' + i).val());
                         //   $("#strEditado").val($("#strEditado").val() + $('#telefono' + i).attr('data') + ";" + $('#telefono' + i).val() + "||");

                            $("#strEditado").val($('#telefono' + i).val() + ";" + $("#strEditado").val() + $('#telefono' + i).attr('data') + "||");


                        }

                    }
                }


                for (var i = 1; i <= idxCorreo; i++) {
                    if ($('#correo' + i).attr('data') == 0) {
                        $("#strNuevoCorreo").val($("#strNuevoCorreo").val() + $('#correo' + i).val() + "||");
                        console.log("if:" + $('#correo' + i).val());

                    }
                    else {

                        var CorreoNuevos = $('#correo' + i).val();
                        var CorreoAntiguos = $('#correo' + i).attr('dataold');
                        if (CorreoNuevos != CorreoAntiguos) {
                            console.log("else:" + $('#correo' + i).val());

                            $("#strEditadoCorreo").val($('#correo' + i).val() + ";" + $("#strEditadoCorreo").val() + $('#correo' + i).attr('data')  + "||");


                        }

                    }
                }


                if ($("#form_valid").valid() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
               

                var PersonaID = $('#PersonaID').val();
                var PersonId = $('#PersonId').val();
                var primerNombre = $('#primerNombre').val();
                var segundoNombre = $('#segundoNombre').val();
                var ApellidoMaterno = $('#ApellidoMaterno').val();
                var ApellidoPaterno = $('#ApellidoPaterno').val();
                var codigo_generacion = $('#codigo_generacion').val();
                var prefijo = $('#prefijo').val();
                var f_nacimiento = $('#f_nacimiento').val();
                var sexo_referencia_id = $('#sexo_referencia_id').val();
                var estado_ciudania_us_id = '';
                var tipo_visa_id = $('#tipo_visa_id').val();
                var hispana_latina_id = '';
                var estado_residencia = $('#estado_residencia').val();
                var comprobante_residencia_id = $('#comprobante_residencia_id').val();
                var nivel_educacion_id = $('#nivel_educacion_id').val();
                var verificacion_personal_id = $('#verificacion_personal_id').val();
                var verificacion_f_nacimiento = $('#verificacion_f_nacimiento').val();
                var afiliacion_tribal_id = $('#afiliacion_tribal_id').val();
                var strEditado = $("#strEditado").val();
                var strEliminado = $("#strEliminado").val();
                var strFonos = $("#strNuevoFonos").val();
                var estudiante = $("#estudiante").val();
                var strCorreoEditado = $("#strEditadoCorreo").val();
                var strCorreoEliminado = $("#strEliminadoCorreo").val();
                var strCorreos = $("#strNuevoCorreo").val();
                var rol = $("#tipo_persona").val();
                if (rol == '') {
                    rol = 0;
                }
             
                var variable = $('input:radio[name=pertenece]:checked').val();
                var curso = $("#curso").val();
                if (curso == '') {
                    curso = 0;
                }
                var rut = $("#BuscarRut").val();
                var custodia = '';
                var contacto_emergencia = '';
                var orden_alejamiento = '';
                var vive = '';
                var autorizacion = '';
                if ($('[name="hispana_latina_id"]').is(':checked')) {
                    hispana_latina_id = 0;
                }
                else {
                    hispana_latina_id = 1;
                }
                if ($('[name="estado_ciudania_us_id"]').is(':checked')) {
                    estado_ciudania_us_id = 0;
                }
                else {
                    estado_ciudania_us_id = 1;
                }
                if ($('[name="custodia_id"]').is(':checked')) {
                    custodia = 0;
                }
                else {
                    custodia = 1;
                }
                if ($('[name="custodia_id"]').is(':checked')) {
                    custodia = 0;
                }
                else {
                    custodia = 1;
                }
                if ($('[name="contacto_emergencia"]').is(':checked')) {
                    contacto_emergencia = 0;
                }
                else {
                    contacto_emergencia = 1;
                }
                if ($('[name="orden_alejamiento"]').is(':checked')) {
                    orden_alejamiento = 0;
                }
                else {
                    orden_alejamiento = 1;
                }
                if ($('[name="orden_alejamiento"]').is(':checked')) {
                    orden_alejamiento = 0;
                }
                else {
                    orden_alejamiento = 1;

                }
                if ($('[name="vive"]').is(':checked')) {
                    vive = 0;
                }
                else {
                    vive = 1;

                }
                if ($('[name="autorizacion"]').is(':checked')) {
                    autorizacion = 0;
                }
                else {
                    autorizacion = 1;
                }
                if (estudiante == null) {
                    estudiante = 0;
                }
                console.log(estudiante);
                //if (Fn.validaRut(rut)) {
                   
                //} else {
                //    alert("El rut es incorrecto");
                //    return;

                //}
                if (PersonId > 0) {
                    $.ajax({
                        type: "POST",
                        url: '/Persona.asmx/EditarPersona',
                        data: "{PersonId:'" + PersonId +
                            "',strEditado:'" + strEditado +
                            "',rut:'" + rut +
                            "',strEliminado:'" + strEliminado +
                            "',strFonos:'" + strFonos +
                            "',strCorreoEditado:'" + strCorreoEditado +
                            "',strCorreoEliminado:'" + strCorreoEliminado +
                            "',strCorreos:'" + strCorreos +
                            "',primerNombre:'" + primerNombre +
                            "',segundoNombre:'" + segundoNombre +
                            "',ApellidoMaterno:'" + ApellidoMaterno +
                            "',ApellidoPaterno:'" + ApellidoPaterno +
                            "',f_nacimiento:'" + f_nacimiento +
                            "',sexo_referencia_id:'" + sexo_referencia_id +
                            "',rol:'" + rol +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (responseFromServer) {
                            $('#btnCancelar').click();
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: responseFromServer.d,
                                showConfirmButton: false,
                                timer: 1500
                            })
                            var tipo_persona = $("#tipo_persona").val();
                            if (tipo_persona == 5) {

                                var tipo_persona = $("#tipo_persona").val();
                                var ColegioId = sessionStorage.getItem('Colegio');

                                $.ajax({
                                    type: "POST",
                                    url: 'Persona.asmx/SeleccionarPersona',
                                    data: "{tipo_persona:'" + tipo_persona +
                                        "',ColegioId:'" + ColegioId +
                                        "'}",
                                    contentType: "application/json",
                                    datatype: "json",
                                    success: function (data) {
                                        $('#mostrar').html(data.d);

                                    },
                                    error: function (err) {
                                        console.log("Error:" + err);
                                    },
                                });
                            }
                            if (tipo_persona == 6) {
                                var curso = $("#curso").val();
                                var tipo_persona = $("#tipo_persona").val();
                                var ColegioId = sessionStorage.getItem('Colegio');

                                if (tipo_persona == 6) {
                                    $.ajax({
                                        type: "POST",
                                        url: 'Persona.asmx/SearchCurso',
                                        data: "{curso:'" + curso +
                                            "',ColegioId:'" + ColegioId +
                                            "'}",
                                        contentType: "application/json",
                                        datatype: "json",
                                        success: function (data) {
                                            $('#mostrar').html(data.d);


                                        },
                                        error: function (err) {
                                            console.log("Error:" + err);
                                        },
                                    });


                                }

                            }

                            if (tipo_persona == 12) {

                                var estudiante = $("#estudiante").val();
                                var ColegioId = sessionStorage.getItem('Colegio');

                                $.ajax({
                                    type: "POST",
                                    url: 'Persona.asmx/getApoderado',
                                    data: "{estudiante:'" + estudiante +
                                        "',ColegioId:'" + ColegioId +
                                        "'}",
                                    contentType: "application/json",
                                    datatype: "json",
                                    success: function (data) {
                                        //alert(data.d);
                                        $('#mostrar').html(data.d);

                                    },
                                    error: function (err) {
                                        console.log("Error:" + err);
                                    },
                                });


                            }






                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }
                else {
                    var ColegioId = sessionStorage.getItem('Colegio');
                    $.ajax({
                        type: "POST",
                        url: '/Persona.asmx/IngresarPersona',
                        data: "{PersonId:'" + PersonId +
                            "',strEditado:'" + strEditado +
                            "',rut:'" + rut +
                            "',strEliminado:'" + strEliminado +
                            "',strFonos:'" + strFonos +
                            "',strCorreoEditado:'" + strCorreoEditado +
                            "',strCorreoEliminado:'" + strCorreoEliminado +
                            "',strCorreos:'" + strCorreos +
                            "',primerNombre:'" + primerNombre +
                            "',segundoNombre:'" + segundoNombre +
                            "',ApellidoMaterno:'" + ApellidoMaterno +
                            "',ApellidoPaterno:'" + ApellidoPaterno +
                            "',f_nacimiento:'" + f_nacimiento +
                            "',sexo_referencia_id:'" + sexo_referencia_id +
                            "',rol:'" + rol +
                            "',curso:'" + curso +
                            "',estudiante:'" + estudiante +
                            "',ColegioId:'" + ColegioId +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (responseFromServer) {
                            $('#btnCancelar').click();
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: responseFromServer.d,
                                showConfirmButton: false,
                                timer: 1500
                            })
                            var tipo_persona = $("#tipo_persona").val();
                            if (tipo_persona == 5) {

                                var tipo_persona = $("#tipo_persona").val();
                                var ColegioId = sessionStorage.getItem('Colegio');

                                $.ajax({
                                    type: "POST",
                                    url: 'Persona.asmx/SeleccionarPersona',
                                    data: "{tipo_persona:'" + tipo_persona +
                                        "',ColegioId:'" + ColegioId +
                                        "'}",
                                    contentType: "application/json",
                                    datatype: "json",
                                    success: function (data) {
                                        $('#mostrar').html(data.d);

                                    },
                                    error: function (err) {
                                        console.log("Error:" + err);
                                    },
                                });
                            }
                            if (tipo_persona == 6) {
                                var curso = $("#curso").val();
                                var tipo_persona = $("#tipo_persona").val();
                                var ColegioId = sessionStorage.getItem('Colegio');

                                if (tipo_persona == 6) {
                                    $.ajax({
                                        type: "POST",
                                        url: 'Persona.asmx/SearchCurso',
                                        data: "{curso:'" + curso +
                                            "',ColegioId:'" + ColegioId +
                                            "'}",
                                        contentType: "application/json",
                                        datatype: "json",
                                        success: function (data) {
                                            $('#mostrar').html(data.d);


                                        },
                                        error: function (err) {
                                            console.log("Error:" + err);
                                        },
                                    });


                                }

                            }

                            if (tipo_persona == 12) {

                                var estudiante = $("#estudiante").val();
                                var ColegioId = sessionStorage.getItem('Colegio');

                                $.ajax({
                                    type: "POST",
                                    url: 'Persona.asmx/getApoderado',
                                    data: "{estudiante:'" + estudiante +
                                        "',ColegioId:'" + ColegioId +
                                        "'}",
                                    contentType: "application/json",
                                    datatype: "json",
                                    success: function (data) {
                                        //alert(data.d);
                                        $('#mostrar').html(data.d);

                                    },
                                    error: function (err) {
                                        console.log("Error:" + err);
                                    },
                                });


                            }

                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }
            
               // listar();

            });
            //Abrir Modal de Editar
            $(document).on('click', '.btn_editar', function () {
                limpiarCampos();
                $("#primer_datos").hide();
                $("#otros_datos").show();
                document.getElementById("exampleModalLabel").innerHTML = "Editar Persona";
                var PersonId = $(this).attr("id");

                var PersonId = document.getElementById("PersonId").value = PersonId;
                $("#primerNombre").val($("#FirstName" + PersonId).html());
                $("#segundoNombre").val($("#MiddleName" + PersonId).html());
                $("#ApellidoMaterno").val($("#LastName" + PersonId).html());
                $("#ApellidoPaterno").val($("#SecondLastName" + PersonId).html());
                $("#codigo_generacion").val($("#GenerationCode" + PersonId).html());
                $("#prefijo").val($("#Prefix" + PersonId).html());
                $("#f_nacimiento").val($("#BirthDate" + PersonId).html());
                $("#sexo_referencia_id").val($("#RefSexId" + PersonId).html());
                $("hispana_latina_id").val($("#HispanicLatinoEthnicity" + PersonId).html());
                $("#estado_ciudania_us_id").val($("#RefUSCitizenshipStatusId" + PersonId).html());
                $("#tipo_visa_id").val($("#RefVisaTypeId" + PersonId).html());
                $("#estado_residencia").val($("#RefStateOfResidenceId" + PersonId).html());
                $("#comprobante_residencia_id").val($("#RefProofOfResidencyTypeId" + PersonId).html());
                $("#nivel_educacion_id").val($("#RefHighestEducationLevelCompletedId" + PersonId).html());
                $("#verificacion_personal_id").val($("#RefPersonalInformationVerificationId" + PersonId).html());
                $("#verificacion_f_nacimiento").val($("#BirthdateVerification" + PersonId).html());
                $("#afiliacion_tribal_id").val($("#RefTribalAffiliationId" + PersonId).html());
                $("#rut_ingresar").val($("#Rut" + PersonId).html());

                console.log($("#StrFonos" + PersonId).val());
                console.log($("#StrCorreo" + PersonId).val());
                var arrFonos = $("#StrFonos" + PersonId).val().split("||");
                var arrCorreos = $("#StrCorreo" + PersonId).val().split("||");
                

                if (arrFonos == "") {
                    agregarTelefono("", "");

                }
                for (var i = 0; i < arrFonos.length - 1; i++) {
                    var arrFono = arrFonos[i].split(";");
                    var idFono = arrFono[0];
                    var fFono = arrFono[1];
                    agregarTelefono(idFono, fFono);
                }

                if (arrCorreos == "") {
                    agregarCorreo("", "");

                }
                for (var i = 0; i < arrCorreos.length - 1; i++) {
                    var arrEmail = arrCorreos[i].split(";");
                    var idCorreo = arrEmail[0];
                    var CCorreo = arrEmail[2];
                    agregarCorreo(idCorreo, CCorreo);
                }
                $('#create').modal({
                    keyboard: true
                });


            });
            function convertDate(inputFormat) {
                function pad(s) { return (s < 10) ? '0' + s : s; }
                var d = new Date(inputFormat)
                return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
            }
            $(document).on('click', '.btn_eliminar', function () {
                var PersonId = $(this).attr("id");
                var curso = $("#curso").val();
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
                                url: '/Persona.asmx/EliminarPersona',
                                data: "{PersonId:'" + PersonId +
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
                                    var tipo_persona = $("#tipo_persona").val();

                                    $.ajax({
                                        type: "POST",
                                        url: 'Persona.asmx/SeleccionarPersona',
                                        data: "{tipo_persona:'" + tipo_persona +
                                            "'}",
                                        contentType: "application/json",
                                        datatype: "json",
                                        success: function (data) {
                                            $('#mostrar').html(data.d);

                                        },
                                        error: function (err) {
                                            console.log("Error:" + err);
                                        },
                                    });


                                   
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
            $('#btnBuscarRut').click(function () {
                var rut = $('#BuscarRut').val();

                $.ajax({
                    type: "POST",
                    url: '/Persona.asmx/BuscarRut',
                    data: "{rut:'" + rut +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //$('#asd').html(data.d);
                        //var d = $('#hidden_existe').val();
                        if (data.d == 1) {
                            $("#exampleModalLabel").html("Editar Persona");
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: 'Persona Encontrada...',
                                showConfirmButton: false,
                                timer: 3000
                            })
                            $("#primer_datos").hide();
                            $("#otros_datos").show();
                            $('#create').modal({
                                keyboard: true
                            });
                            $('#btnAgregar').show();
                            $.ajax({
                                type: "POST",
                                url: '/Persona.asmx/BuscarIdPerson',
                                data: "{rut:'" + rut +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {
                                    var PersonId = data.d;
                                    limpiarCampos();
                                    var PersonId = document.getElementById("PersonId").value = PersonId;
                                    $("#primerNombre").val($("#FirstName" + PersonId).html());
                                    $("#segundoNombre").val($("#MiddleName" + PersonId).html());
                                    $("#ApellidoMaterno").val($("#LastName" + PersonId).html());
                                    $("#ApellidoPaterno").val($("#SecondLastName" + PersonId).html());
                                    $("#codigo_generacion").val($("#GenerationCode" + PersonId).html());
                                    $("#prefijo").val($("#Prefix" + PersonId).html());
                                    $("#f_nacimiento").val($("#BirthDate" + PersonId).html());
                                    $("#sexo_referencia_id").val($("#RefSexId" + PersonId).html());
                                    $("hispana_latina_id").val($("#HispanicLatinoEthnicity" + PersonId).html());
                                    $("#estado_ciudania_us_id").val($("#RefUSCitizenshipStatusId" + PersonId).html());
                                    $("#tipo_visa_id").val($("#RefVisaTypeId" + PersonId).html());
                                    $("#estado_residencia").val($("#RefStateOfResidenceId" + PersonId).html());
                                    $("#comprobante_residencia_id").val($("#RefProofOfResidencyTypeId" + PersonId).html());
                                    $("#nivel_educacion_id").val($("#RefHighestEducationLevelCompletedId" + PersonId).html());
                                    $("#verificacion_personal_id").val($("#RefPersonalInformationVerificationId" + PersonId).html());
                                    $("#verificacion_f_nacimiento").val($("#BirthdateVerification" + PersonId).html());
                                    $("#afiliacion_tribal_id").val($("#RefTribalAffiliationId" + PersonId).html());
                                    $("#rut_ingresar").val($("#Rut" + PersonId).html());
                                    var arrFonos = $("#StrFonos" + PersonId).val().split("||");
                                    var arrCorreos = $("#StrCorreo" + PersonId).val().split("||");


                                    if (arrFonos == "") {
                                        agregarTelefono("", "");

                                    }
                                    for (var i = 0; i < arrFonos.length - 1; i++) {
                                        var arrFono = arrFonos[i].split(";");
                                        var idFono = arrFono[0];
                                        var fFono = arrFono[1];
                                        agregarTelefono(idFono, fFono);
                                    }

                                    if (arrCorreos == "") {
                                        agregarCorreo("", "");

                                    }
                                    for (var i = 0; i < arrCorreos.length - 1; i++) {
                                        var arrEmail = arrCorreos[i].split(";");
                                        var idCorreo = arrEmail[0];
                                        var CCorreo = arrEmail[2];
                                        agregarCorreo(idCorreo, CCorreo);
                                    }
                                },
                                error: function (err) { console.log("Error:" + err); },
                            });





                        }
                        if (data.d == 2) {
                            $("#exampleModalLabel").html("Crear Persona");
                            Swal.fire({
                                position: 'top-center',
                                icon: 'error',
                                title: 'La persona que desea ingresar no existe en el sistema',
                                showConfirmButton: false,
                                timer: 3000
                            })

                           
                            $("#primer_datos").hide();
                            $("#otros_datos").show();
                            $('#create').modal({
                                keyboard: true
                            });
                            var rut1 = $("#BuscarRut").val();

                            //agregarTelefono(0, "");
                            //agregarCorreo(0, "");
                            $('#btnAgregar').show();


                        }
                    },
                    error: function (err) { console.log("Error:" + err); },
                });


            });
            function limpiarCampos() {
                $('#PersonId').val('0');
                $('#primerNombre').val('');
                $('#segundoNombre').val('');
                $('#ApellidoMaterno').val('');
                $('#ApellidoPaterno').val('');
                $('#codigo_generacion').val('');
                $('#rut_ingresar').val('');
                $('#f_nacimiento').val('');
                $('#prefijo').val('');
                $('#hispana_latina_id').val('');
                $('#BuscarRut').val('');
                $('#verificacion_personal_id').val('');
                $('#verificacion_f_nacimiento').val('');
                $('#f_nacimiento').prop('selectedIndex', 0);
                $('#sexo_referencia_id').prop('selectedIndex', 0);
                $('#estado_ciudania_us_id').prop('selectedIndex', 0);
                $('#tipo_visa_id').prop('selectedIndex', 0);
                $('#estado_residencia').prop('selectedIndex', 0);
                $('#comprobante_residencia_id').prop('selectedIndex', 0);
                $('#nivel_educacion_id').prop('selectedIndex', 0);
                $('#afiliacion_tribal_id').prop('selectedIndex', 0);

                $('#telefono').val('');
                $("#col_telefono").html('');
                $("#col_correo").html('');

            }
            $(document).on('click', '.btn_eliminar_telefono', function () {

                var idx = $(this).attr("id");

                $("#strEliminado").val($("#strEliminado").val() + $('#telefono' + idx).attr('data') + "||");

                //alert(PersonTelephoneId.split(",")[0]);
                $("#row_fono" + idx).remove();





            });
            $(document).on('click', '.btn_eliminar_correo', function () {

                var idx = $(this).attr("id");

                $("#strEliminadoCorreo").val($("#strEliminadoCorreo").val() + $('#correo' + idx).attr('data') + "||");

                //alert(PersonTelephoneId.split(",")[0]);
                $("#row_correo" + idx).remove();





            });
        
            $('#btnIngresar').click(function () {
                limpiarCampos();
                agregarTelefono(0, "");
                agregarCorreo(0, "");
                $("#primer_datos").show();
                $("#otros_datos").hide();
                $('#btnAgregar').hide();
                $("#exampleModalLabel").html("Agregar Persona");


            });

        });
    </script>
       <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Persona</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnIngresar">
                                    <i class="flaticon2-plus"></i>
                                    Nueva Persona
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="container" style="overflow-x: auto;">
                <div class="row">
                       <div class="col-md-6 mb-3">
                                <label>Tipo de Persona</label>
                                <select class="custom-select d-block w-100" id="tipo_persona">
                                </select>
                         </div>

                         <div class="col-md-6 mb-3" id="div_curso" style="display:none">
                                <label>Curso</label>
                                <select class="custom-select d-block w-100" id="curso">
                                </select>
                            </div>
                     <div class="col-md-6  mb-3" id="div_estudiante" style="display:none">
                                <label>Estudiante</label>
                                <select class="custom-select d-block w-100" id="estudiante" name="" required=""></select>
                     </div>
                    

                </div>
              
            
                <table class="table table-striped- table-bordered table-hover table-checkable" id="tabla_id">
                    <thead>
                        <tr>
                            <th>Acción</th>
                            <th>Id</th>
                            <th>Primer Nombre</th>
                            <th>Segundo Nombre</th>
                            <th>Apellido Materno</th>
                            <th>Apellido Paterno</th>
                           <%-- %> <th>Código  Generación</th>
<%--                           <th>Prefijo</th>--%>
                            <th>Fecha Nacimiento</th>
                            <th>Genero</th>
                            <%--<th>Hispana Latina</th>--%>
                           <%-- <th>Estado Ciudanía US</th>
                            <th>Tipo de Visa</th>
                            <th>Estado de Residencia</th>
                            <th>Comprobante de Residencia</th>--%>
                          <%--  <th>Nivel de Educación</th>
                            <th>Verificación Personal</th>
                            <th>Verificacion de Fecha de Nacimiento </th>
                            <th>Afilación Tribal</th>--%>
                        </tr>
                    </thead>
                    <tbody id="mostrar">
                        <%--    <tr>
                             <td>
                                   
								<a ><i class='fa fa-pencil-alt'> </i></a>
							    <a><i class='fa fa-trash-alt'> </i>  </a> 
                             </td>
                         </tr>--%>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!--Modal Create-->
    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Persona
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row" id="primer_datos">
                            <div class="col-md-6 mb-3">
                                <div class="form-group">
                                      <label class="d-block">Cedula de Identidad Chilena</label>
                                      <div class="custom-control custom-control-inline custom-radio">
                                        <input type="radio" class="custom-control-input"  name="pertenece" id="rd1"  value="Yes" onChange="perteneceValue(this)" checked> <label class="custom-control-label" for="rd1">Si</label>
                                      </div>
                                      <div class="custom-control custom-control-inline custom-radio">
                                        <input type="radio" class="custom-control-input"  name="pertenece"  id="rd2" value="No" onChange="perteneceValue(this)"  > <label class="custom-control-label" for="rd2">No</label>
                                      </div>
                              
                                   </div>
                            </div>

                             <div class="col-md-6  mb-3">
                          <div class="row">
                               <div class="col-6">
                                   <label>Rut</label>
                                    <input type="text" class="form-control" id="BuscarRut" name="primerNombre" required="">
                              </div>
                               <div class="col-3">
                                            <button type="button" class="btn btn-xl btn-icon btn-secundary" style="margin-top: 25px;" id="btnBuscarRut"><i class="fa fa-search"></i></button>
                              </div>
                               
                          </div>
                         
                         </div>
            
                         <%--     <div class="col-md-6 mb-3" id="rut_ingresar" style="display:none;" >
                                <label>Rut</label>
                                <input type="text" class="form-control" id="rut" placeholder="ej: XXXXXXXX-X" name="rut" required="">
                            </div>--%>
          
                        </div>
                        <div class="row"  id="otros_datos" style="display:none;">

                                
                              <div class="col-md-6 mb-3" style="display:none;">
                                <label>Rut</label>
                                <input type="text" class="form-control" id="rut_ingresar" placeholder="ej: XXXXXXXX-X" name="rut" required="">
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Primer Nombre</label>
                                <input type="hidden" value="0" id="PersonId" />
                                <input type="hidden" value="hid" id="PersonaID" />
                                <input type="hidden" value="" id="strEditado" />
                                <input type="hidden" value="" id="strEliminado" />
                                <input type="hidden" value="" id="strNuevoFonos" />
                                <input type="hidden" value="0" id="idxTelefono" />
                                <input type="hidden" value="0" id="idxCorreo" />
                                <input type="hidden" value="" id="strEditadoCorreo" />
                                <input type="hidden" value="" id="strEliminadoCorreo" />
                                <input type="hidden" value="" id="strNuevoCorreo" />
                                <input type="text" class="form-control" id="primerNombre" name="primerNombre" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Primer Nombre. </div>--%>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Segundo Nombre</label>
                                <input type="text" class="form-control" id="segundoNombre" name="segundoNombre" required="">
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Apellido Paterno</label>
                                <input type="text" class="form-control" id="ApellidoPaterno" name="ApellidoPaterno" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Apellido Paterno. </div>--%>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Apellido Materno</label>
                                <input type="text" class="form-control" id="ApellidoMaterno" name="ApellidoMaterno" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Apellido Materno. </div>--%>
                            </div>
                         
                         <%--   <div class="col-md-6 mb-3">
                                <label>Código de Generación</label>
                                <input type="text" class="form-control" id="codigo_generacion" name="codigo_generacion" required="">
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Prefijo</label>
                                <input type="text" class="form-control" id="prefijo" name="prefijo" required="">
                            </div>--%>
                            <div class="col-md-6 mb-3">
                                <label>Fecha de Nacimiento</label>
                                <input type="date" class="form-control" id="f_nacimiento" name="f_nacimiento" required="">
                            </div>

                        <%--    <div class="col-md-6 mb-3">
                                <label>Ciudad de Nacimiento</label>
                                <input type="text" class="form-control" id="ciudad_nacimiento" name="f_nacimiento" required="">
                            </div>--%>
                            <div class="col-md-6 mb-3">
                                <label>Genero</label>
                                <select class="custom-select d-block w-100" id="sexo_referencia_id" name="sexo_referencia_id" required="">
                                </select>
                            </div>

                       <%--     <div class="col-md-6 mb-3">
                                <label>Hispana Latina</label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox" id="hispana_latina_id" name="hispana_latina_id"   class="switcher-input"  checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="HispanaSi()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="HispanaNo()" value="0">No</span>
                                  </label>   
                                </div>  
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Estado de ciudanía de Estados Unidense </label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox"  name="estado_ciudania_us_id"   class="switcher-input" value="0" checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="us_si()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="us_no()" value="0">No</span>
                                  </label> <!-- /.switcher-control -->
                                </div>              
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Tipo de Visa</label>
                                <select class="custom-select d-block w-100" id="tipo_visa_id" name="tipo_visa_id" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Estado de Residencia</label>

                                <select class="custom-select d-block w-100" id="estado_residencia" name="estado_residencia" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Comprobante de Residencia</label>

                                <select class="custom-select d-block w-100" id="comprobante_residencia_id" name="comprobante_residencia_id" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Nivel de educación</label>

                                <select class="custom-select d-block w-100" id="nivel_educacion_id" name="nivel_educacion_id" required="">
                                </select>
                            </div>
                            <div id="asd" style="display:none;"></div>
                            <div class="col-md-6 mb-3">
                                <label>Verificación Personal</label>
                                <select class="custom-select d-block w-100" id="verificacion_personal_id" name="verificacion_personal_id" required="">
                                    <option value="">Seleccione... </option>
                                    <option vale="1">1 </option>
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Verificación de Fecha de Nacimiento</label>

                                <input type="text" class="form-control" id="verificacion_f_nacimiento" name="verificacion_f_nacimiento" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Verificacion de Fecha de Nacimiento. </div>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Afilación tribual</label>
                                <select class="custom-select d-block w-100" id="afiliacion_tribal_id" name="afiliacion_tribal_id" required="">
                                    <option value="">Seleccione... </option>
                                    <option vale="1">1 </option>
                                </select>
                            </div>
                            <br />  <br />
                            <div class="col-md-6 mb-3">
                                <label>Custodía del niño</label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox"  name="custodia_id"   class="switcher-input" value="0" checked="">

                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" class="switcher-label-on" onclick="cutodiaSi()"  value="1">Si</span> 
                                      <span type="button" class="switcher-label-off"  onclick="custodiaNo()" value="0">No</span>
                                  </label> <!-- /.switcher-control -->
                               
                                </div>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Asignar como contacto de emergencia</label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                    <label class="switcher-control switcher-control-lg">
                                        <input type="checkbox" id="contacto_emergencia"  name="contacto_emergencia"   class="switcher-input" value="0" checked="">

                                        <span class="switcher-indicator">
                                        </span> 
                                        <span type="button" class="switcher-label-on" onclick="cutodiaSi()"  value="1">Si</span> 
                                        <span type="button" class="switcher-label-off"  onclick="custodiaNo()" value="0">No</span>
                                    </label> <!-- /.switcher-control -->
                                </div>
                            </div>
                             <div class="col-md-6 mb-3">
                                <label>Orden de Alejamiento</label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                        <input type="checkbox" id="orden_alejamiento"  name="orden_alejamiento"   class="switcher-input" value="0" checked="">
                                        <span class="switcher-indicator">
                                        </span> 
                                        <span type="button" class="switcher-label-on" onclick="cutodiaSi()"  value="1">Si</span> 
                                        <span type="button" class="switcher-label-off"  onclick="custodiaNo()" value="0">No</span>
                                    </label> <!-- /.switcher-control -->
                                </div>

                            
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>¿Vive con el estudiante?</label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                    <label class="switcher-control switcher-control-lg">
                                        <input type="checkbox"   name="vive"   class="switcher-input" value="0" checked="">

                                        <span class="switcher-indicator">
                                        </span> 
                                        <span type="button" class="switcher-label-on" onclick="cutodiaSi()"  value="1">Si</span> 
                                        <span type="button" class="switcher-label-off"  onclick="custodiaNo()" value="0">No</span>
                                    </label> <!-- /.switcher-control -->
                                </div>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label>Autorización para retirar al estudiante</label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                    <label class="switcher-control switcher-control-lg">
                                        <input type="checkbox" id="autorizacion"  name="autorizacion"   class="switcher-input" value="0" checked="">

                                        <span class="switcher-indicator">
                                        </span> 
                                        <span type="button" class="switcher-label-on" onclick="cutodiaSi()"  value="1">Si</span> 
                                        <span type="button" class="switcher-label-off"  onclick="custodiaNo()" value="0">No</span>
                                    </label> <!-- /.switcher-control -->
                                </div>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label>Tipo de Relación</label>
                                <select class="custom-select d-block w-100" id="PersonRelation" name="tipo_relacion"  required="">
                                </select>
                            </div>
                            
                          
                            

                     <%--       <div class="col-md-6 mb-3">
                                <div class="form-group">
                                      <label class="d-block">¿Posee un Titulo de Nivel Superior?</label>
                                      <div class="custom-control custom-control-inline custom-radio">
                                        <input type="radio" class="custom-control-input"  name="titulo" id="r1"  value="Yes" onChange="tituloValue(this)"> <label class="custom-control-label" for="r1">Si</label>
                                      </div>
                                      <div class="custom-control custom-control-inline custom-radio">
                                        <input type="radio" class="custom-control-input"  name="titulo" id="r2" value="No" onChange="tituloValue(this)" > <label class="custom-control-label" for="r2">No</label>
                                      </div>
                              
                                 </div>
                                   <script type="text/javascript">
                                       function tituloValue(x) {
                                           if (x.value == 'No') {
                                               document.getElementById("nombre_ingresar").style.display = 'none';
                                               document.getElementById("tipo_titulo").style.display = 'none';
                                               document.getElementById("egreso").style.display = 'none';
                                               document.getElementById("institucion").style.display = 'none';
                                           }
                                           else {
                                               document.getElementById("nombre_ingresar").style.display = 'block';
                                               document.getElementById("tipo_titulo").style.display = 'block';
                                               document.getElementById("egreso").style.display = 'block';
                                               document.getElementById("institucion").style.display = 'block';

                                           }
                                       }
                                   </script>

                            </div>


                             <div class="col-md-6 mb-3" id="nombre_ingresar" style="display:none;" >
                                <label>Nombre de Titulo </label>
                                <input type="text" class="form-control" id="nombre_titulo"  required="">
                            </div>
                            <div class="col-md-6 mb-3" id="tipo_titulo" style="display:none;" >
                                <label>Tipo de Titulo </label>
                                <select id="tipo_titulo_id" class="custom-select d-block w-100" required="">
                                    <option value="">Seleccione...</option>
                                    <option value="superior"> Tecnico Nivel Superior</option>
                                    <option value="profesional"> Profesional</option>

                                </select>
                            </div>
                                <div class="col-md-6 mb-3" id="egreso" style="display:none;" >
                                            <label>Fecha de Egreso </label>
                                        <input type="date" class="form-control" id="f_egreso" name="f_egreso" required="">
                                        </div>
                                        <div class="col-md-6 mb-3" id="institucion" style="display:none;" >
                                            <label>Nombre de la Insitución </label>
                                        <input type="text" class="form-control" id="n_institucion" name="n_institucion" required="">
                                        </div>

                                    </div>--%>
                            <br />
                              <div class="col-md-6 mb-3">
                                <div class="row">
                                    
                                    <div class="col-12">

                                        <div name="col_data">
                                            <label>Telefono</label>
                                            <button type="button" class="btn btn-xl btn-icon btn-secundary" style="margin-left: 15px;" id="AgregarTelefono"><i class="fas fa-plus-circle"></i></button>
                                        </div>
                                        <div id="col_telefono">
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-6 mb-3">
                                <div class="row">
                                    <div class="col-12">

                                        <div>
                                            <label>Correo</label>
                                            <button type="button" class="btn btn-xl btn-icon btn-secundary" style="margin-left: 15px;" id="agregarCorreo"><i class="fas fa-plus-circle"></i></button>
                                        </div>
                                        <div id="col_correo">
                                        </div>
                                    </div>
                                </div>

                            </div>

                               <div class="col-md-6 mb-3" id="class_tipo_relacion" style="display:none;">
                                    <label>Tipo de Relación</label>
                                    <select class="custom-select d-block w-100" id="PersonRelation" name="tipo_relacion"  required="">
                                    </select>
                            </div>
                        </div>
                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelar" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>

    </div>



</asp:Content>