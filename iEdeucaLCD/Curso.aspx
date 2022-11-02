<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Curso.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Persona" %>

<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<%--    <script src="sweetalert2.min.js"></script>--%>
<%--    <link rel="stylesheet" href="sweetalert2.min.css">--%>
    <script src="jquery-3.6.0.js"></script>

<!-- Latest compiled and minified CSS -->
    <script type="text/javascript">
        $(document).ready(function () {
            //Tabla 
            var ColegioID = sessionStorage.getItem('Colegio');
            $.ajax({
                type: "POST",
                url: 'Cursos.asmx/SelectProfesor',
                data: "{ColegioID:'" + ColegioID +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    //alert(data.d);
                    $('#profesor').html(data.d);

                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        
            $("#form_valid").validate({
                rules: {
                    modalidad: {
                        required: true,
                    },

                    jornada: {
                        required: true,
                    },
                    nivel: {
                        required: true,
                    },
                    rama: {
                        required: true,
                    },
                    sector: {
                        required: true,
                    },
                    tipo_enseñanza: {
                        required: true,
                    },
                    especialidad: {
                        required: true,
                    },
                    tipo_curso: {
                        required: true,
                    },
                  
                    grado: {
                        required: true,
                    },
                    letra: {
                        required: true,
                    },
                    profesor_jefe: {
                        required: true,
                    }
                },
                messages: {
                    modalidad: {
                        required: "Seleccione una opción",
                    },
                    jornada: {
                        required: "Seleccione una opción",
                    },
                    nivel: {
                        required: "Seleccione una opción",
                    },
                    rama: {
                        required: "Seleccione una opción",
                    },
                    sector: {
                        required: "Seleccione una opción",
                    },
                    especialidad: {
                        required: "Seleccione una opción",
                    },
                    tipo_curso: {
                        required: "Seleccione una opción",
                    },
                    tipo_enseñanza: {
                        required: "Seleccione una opción",
                    },
                    grado: {
                        required: "Seleccione una opción",
                    },
                    profesor_jefe: {
                        required: "Seleccione una opción",
                    },
                    letra: {
                        required: "Dato requerido",
                    }
                }
            });
            
            $("#btnCalendario_id").click();
            function limpiarCampos() {
                //$('#CourseId').val('0');
                $('#modalidad').val('');
                $('#jornada').val('');
                $('#nivel').val('');
                $('#rama').val('');
                $('#sector').val('');
                $('#especialidad').val('');
                $('#tipo_curso').val('');
                $('#tipo_enseñanza').val('');
                $('#grado').val('');
                $('#letra').val('');
                $('#profesor').val('');
                $('#profesor').prop('selectedIndex', 0);
                $('#asignatura').prop('selectedIndex', 0);
            }

            $(document).on('click', '.btn_editar', function () {
                var idx = $(this).attr("id");
                var Course = document.getElementById("CourseId").value = idx;
                //alert($('#CourseId').val());
                //$("#modalidad").val($("#Modalidad" + Course).html());
                //$("#jornada").val($("#Jornada" + Course).html());
                //$("#nivel").val($("#Nivel" + Course).html());
                //$("#rama").val($("#Rama" + Course).html());
                $('#titulo').val($('#course' + idx).html());
                var as = $('#titulo').val();
                document.getElementById("titulo_modal").innerHTML = as;
                var modalidad = $("#name_modalidad" + idx).val();
                var jornada = $("#name_jornada" + idx).val();
                var nivel = $("#name_nivel" + idx).val();
                var rama = $("#name_rama" + idx).val();
                var sector = $("#name_sector" + idx).val();
                var especialidad = $("#name_especialidad" + idx).val();
                var tipo_curso = $("#name_tipo_curso" + idx).val();
                var tipo_enseñanza = $("#name_enseñanza" + idx).val();
                var grado = $("#name_grado" + idx).val();


                $("#aux_modalidad").val($("#idModalidad_" + idx).val());
                $("#aux_jornada").val($("#idJornada_" + idx).val());
                $("#aux_nivel").val($("#idNivel_" + idx).val());
                $("#aux_rama").val($("#idRama_" + idx).val());
                $("#aux_sector").val($("#idSector_" + idx).val());
                $("#aux_especialidad").val($("#idEspecialidad_" + idx).val());
                $("#aux_tipo_curso").val($("#idTipoCurso_" + idx).val());
                $("#aux_enseñanza").val($("#idTipoEnseñanza_" + idx).val());
                $("#aux_grado").val($("#idGrado_" + idx).val());


                console.log($("#idGrado_" + idx).val());
                

                $("#letra").val($("#Letra" + idx).html());
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/GetModalidadEdit',
                    data: "{modalidad:'" + modalidad +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#modalidad").val(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });


    

                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/GetJornadaEdit',
                    data: "{jornada:'" + jornada +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#jornada").val(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/GetNivelEdit',
                    data: "{nivel:'" + nivel +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#nivel").val(data.d);
                        var nivel_input = $("#nivel").val();
                        $.ajax({
                            type: "POST",
                            url: 'Cursos.asmx/ChangeTipoEnseñanza',
                            data: "{nivel_input:'" + nivel_input +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#tipo_enseñanza").html(data.d);
                                $.ajax({
                                    type: "POST",
                                    url: 'Cursos.asmx/GetTipoEnseñanzaEdit',
                                    data: "{tipo_enseñanza:'" + tipo_enseñanza +
                                        "'}",
                                    contentType: "application/json",
                                    datatype: "json",
                                    success: function (data) {
                                       
                                        $("#tipo_enseñanza").val(data.d);
                                        var input_t_enseñanza = $("#tipo_enseñanza").val();
                                        $.ajax({
                                            type: "POST",
                                            url: 'Cursos.asmx/ChangeGrado',
                                            data: "{input_t_enseñanza:'" + input_t_enseñanza +
                                                "'}",
                                            contentType: "application/json",
                                            datatype: "json",
                                            success: function (data) {
                                                $("#grado").html(data.d);
                                                $.ajax({
                                                    type: "POST",
                                                    url: 'Cursos.asmx/GetGradoEdit',
                                                    data: "{grado:'" + grado +
                                                        "',input_t_enseñanza:'" + input_t_enseñanza +
                                                        "'}",
                                                    contentType: "application/json",
                                                    datatype: "json",
                                                    success: function (data) {
                                                        $("#grado").val(data.d);

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
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/GetRamaEdit',
                    data: "{rama:'" + rama +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#rama").val(data.d);
                        var rama_input = $("#rama").val();
                        $.ajax({
                            type: "POST",
                            url: 'Cursos.asmx/ChangeSector',
                            data: "{rama_input:'" + rama_input +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                //$('#sector').html(data.d);
                                $("#sector").html(data.d);
                                $.ajax({
                                        type: "POST",
                                        url: 'Cursos.asmx/GetSectorEdit',
                                        data: "{sector:'" + sector +
                                            "'}",
                                        contentType: "application/json",
                                        datatype: "json",
                                        success: function (data) {
                                            $("#sector").val(data.d);
                                            var sector_input = $("#sector").val();
                                            $.ajax({
                                                type: "POST",
                                                url: 'Cursos.asmx/ChangeEspecialidad',
                                                data: "{sector_input:'" + sector_input +
                                                    "'}",
                                                contentType: "application/json",
                                                datatype: "json",
                                                success: function (data) {
                                                    //$('#sector').html(data.d);
                                                    $("#especialidad").html(data.d);
                                                    $.ajax({
                                                        type: "POST",
                                                        url: 'Cursos.asmx/GetEspecialidadEdit',
                                                        data: "{especialidad:'" + especialidad +
                                                            "'}",
                                                        contentType: "application/json",
                                                        datatype: "json",
                                                        success: function (data) {
                                                            $("#especialidad").val(data.d);
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
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/GetTipoCursoEdit',
                    data: "{tipo_curso:'" + tipo_curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#tipo_curso").val(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $('#create').modal({
                    keyboard: true
                });


            });
            $(document).on('click', '.btn_eliminar', function () {

                var curso = $(this).attr("id");

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
                                url: '/Cursos.asmx/EliminarCurso',
                                data: "{curso:'" + curso +
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
          
            $('#btnAbrirModal').click(function () {
                document.getElementById("titulo_modal").innerHTML = 'Crear Curso';
                limpiarCampos();
                $('#create').modal({
                    keyboard: true
                });

            });
            $('#btnCalendario_id').click(function () {
               // $("#tabla_horario>tbody tr").remove();
                agregarFila();

             
            });
            function listar() {
                var colegio = sessionStorage.getItem('Colegio');
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/MostrarCursos',
                    data: "{colegio:'" + colegio +
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
            listar();
            function SelecTresNivel() {
                var curso = $('curso_hidden').val();
                $.ajax({
                    type: "POST",
                    url: 'Modalidad.asmx/SelectModalidad',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#modalidad').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Nivel.asmx/SelectNivel',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#nivel').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Jornada.asmx/SelectJornada',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#jornada').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
          


                $.ajax({
                    type: "POST",
                    url: 'Rama.asmx/SelectRamaEspecialidad',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#rama').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'TipoCurso.asmx/SelectTipoCurso',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#tipo_curso').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            }
            SelecTresNivel();
            $('#nivel').on('change', function () {
                var nivel = $('#nivel').val();
                $.ajax({
                    type: "POST",
                    url: 'Enseñanza.asmx/SelectEnseñanza',
                    data: "{nivel:'" + nivel +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#tipo_enseñanza').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
      

            $('#tipo_enseñanza').on('change', function () {
                var tipo_enseñanza = $('#tipo_enseñanza').val();
                $.ajax({
                    type: "POST",
                    url: 'Grado.asmx/SelectGrado',
                    data: "{tipo_enseñanza:'" + tipo_enseñanza +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#grado').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#rama').on('change', function () {
                var rama = $('#rama').val();
                $.ajax({
                    type: "POST",
                    url: 'Sector.asmx/ChangeSector',
                    data: "{rama:'" + rama +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#sector').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#sector').on('change', function () {
                var sector = $('#sector').val();
                $.ajax({
                    type: "POST",
                    url: 'Especialidad.asmx/ChangeEspecialidad',
                    data: "{sector:'" + sector +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#especialidad').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            //Obtener el nombre de todos los datos modalidad,jornada,tipo de curso, etc
            $('#modalidad').on('change', function () {
                var modalidad = $('#modalidad').val();
                $.ajax({
                    type: "POST",
                    url: 'Modalidad.asmx/GetModalidad',
                    data: "{modalidad:'" + modalidad +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_modalidad').html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#jornada').on('change', function () {
                var jornada = $('#jornada').val();
                document.getElementById("jornada_error").style.display = "none";

                $.ajax({
                    type: "POST",
                    url: 'Jornada.asmx/GetJornada',
                    data: "{jornada:'" + jornada +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_jornada').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#nivel').on('change', function () {
                var nivel = $('#nivel').val();
                $.ajax({
                    type: "POST",
                    url: 'Nivel.asmx/GetNivel',
                    data: "{nivel:'" + nivel +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_nivel').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#rama').on('change', function () {
                var rama = $('#rama').val();
                $.ajax({
                    type: "POST",
                    url: 'Rama.asmx/GetRama',
                    data: "{rama:'" + rama +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_rama').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#sector').on('change', function () {
                var sector = $('#sector').val();
                $.ajax({
                    type: "POST",
                    url: 'Sector.asmx/GetSector',
                    data: "{sector:'" + sector +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_sector').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#especialidad').on('change', function () {
                var especialidad = $('#especialidad').val();
                $.ajax({
                    type: "POST",
                    url: 'Especialidad.asmx/GetEspecialidad',
                    data: "{especialidad:'" + especialidad +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_especialidad').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#tipo_curso').on('change', function () {
                var tipo_curso = $('#tipo_curso').val();
                $.ajax({
                    type: "POST",
                    url: 'TipoCurso.asmx/GetTipoCurso',
                    data: "{tipo_curso:'" + tipo_curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_TipoCurso').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#tipo_enseñanza').on('change', function () {
                var tipo_enseñanza = $('#tipo_enseñanza').val();
                $.ajax({
                    type: "POST",
                    url: 'Enseñanza.asmx/GetEnseñanza',
                    data: "{tipo_enseñanza:'" + tipo_enseñanza +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_enseñanza').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            function getAsignaturaProfe() {
                var curso = $('#hidden_curso').val();
                $.ajax({
                    type: "POST",
                    url: '/Cursos.asmx/MostrarAsignaturaProfesor',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (responseFromServer) {

                        $('#mostrar_datoss').html(responseFromServer.d);
                    },
                    error: function (err) { console.log("Error:" + err); },
                });
            }
            $('#grado').on('change', function () {
                var grado = $('#grado').val();
                $.ajax({
                    type: "POST",
                    url: 'Grado.asmx/GetGrado',
                    data: "{grado:'" + grado +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $('#div_grado').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $('#btnAgregarAsignatura').click(function () {
                var asignatura = $('#asignatura').val();
                var profesor = $('#profesor').val();
                var curso = $('#hidden_curso').val();


                $.ajax({
                    type: "POST",
                    url: '/Cursos.asmx/AsignarProfesorAsignatura',
                    data: "{curso:'" + curso +
                        "',asignatura:'" + asignatura +
                        "',profesor:'" + profesor +
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
                        getAsignaturaProfe();
                        limpiarCampos();
                        $.ajax({
                            type: "POST",
                            url: 'Cursos.asmx/SelectAsignatura',
                            data: "{curso:'" + curso +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                //alert(data.d);
                                $('#asignatura').html(data.d);
                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });
                        
                    },
                    error: function (err) { console.log("Error:" + err); },
                });


           



            });
            $('#btnAgregar').click(function () {

                var idCurso = $('#CourseId').val();
                var modalidad = $('#modalidad').val();
             
                var Jornada = $('#jornada').val();
                var Nivel = $('#nivel').val();
                var Rama = $('#rama').val();
                var Sector = $('#sector').val();
                var Especialidad = $('#especialidad').val();
                var TipoCurso = $('#tipo_curso').val();
                var Enseñanza = $('#tipo_enseñanza').val();
                var Grado = $('#grado').val();
                var Letra = $('#letra').val();
                var id_colegio = sessionStorage.getItem('Colegio');
                var idModalidad = $("#aux_modalidad").val();
                var idJornada = $("#aux_jornada").val();
                var idNivel = $('#aux_nivel').val();
                var idRama = $('#aux_rama').val();
                var idSector = $('#aux_sector').val();
                var idEspecialidad = $('#aux_especialidad').val();
                var idTipoCurso = $('#aux_tipo_curso').val();
                var idTipoEnseñanza = $('#aux_enseñanza').val();
                var idGrado = $('#aux_grado').val();
         
         
                if ($("#form_valid").valid() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                if (idCurso > 0) {
                    //Editar
                    $.ajax({
                        type: "POST",
                        url: '/Cursos.asmx/EditarCurso',
                        data: "{idCurso:'" + idCurso +
                            "',idModalidad:'" + idModalidad +
                            "',idJornada:'" + idJornada +
                            "',idNivel:'" + idNivel +
                            "',idRama:'" + idRama +
                            "',idSector:'" + idSector +
                            "',idEspecialidad:'" + idEspecialidad +
                            "',idTipoEnseñanza:'" + idTipoEnseñanza +
                            "',idTipoCurso:'" + idTipoCurso +
                            "',idGrado:'" + idGrado +
                            "',Letra:'" + Letra +
                            "',modalidad:'" + modalidad +
                            "',Jornada:'" + Jornada +
                            "',Nivel:'" + Nivel +
                            "',Rama:'" + Rama +
                            "',Sector:'" + Sector +
                            "',Especialidad:'" + Especialidad +
                            "',Enseñanza:'" + Enseñanza +
                            "',TipoCurso:'" + TipoCurso +
                            "',Grado:'" + Grado +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (responseFromServer) {
                            var idx = responseFromServer.d;
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: 'El comando N° 150 fue ejecutado con éxito.',
                                showConfirmButton: false,
                                timer: 1500
                            })
                            listar();

                            $('#btnCancelar').click();
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });


                }
                else {

                    $.ajax({
                        type: "POST",
                        url: '/Cursos.asmx/IngresarCurso',
                        data: "{modalidad:'" + modalidad +
                            "',Jornada:'" + Jornada +
                            "',Nivel:'" + Nivel +
                            "',Rama:'" + Rama +
                            "',Sector:'" + Sector +
                            "',Especialidad:'" + Especialidad +
                            "',Enseñanza:'" + Enseñanza +
                            "',TipoCurso:'" + TipoCurso +
                            "',Grado:'" + Grado +
                            "',Letra:'" + Letra +
                            "',id_colegio:'" + id_colegio +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (responseFromServer) {
                            var idx = responseFromServer.d;
                            Swal.fire({
                                position: 'top-center',
                                icon: 'success',
                                title: 'El comando N° 150 fue ejecutado con éxito.',
                                showConfirmButton: false,
                                timer: 1500
                            })

                            listar();
                            
                            $('#btnCancelar').click();
                            $("#aux_modalidad").val("");
                            $("#aux_jornada").val("");
                            $('#aux_nivel').val("");
                            $('#aux_rama').val("");
                            $('#aux_sector').val("");
                            $('#aux_especialidad').val("");
                            $('#aux_tipo_curso').val("");
                            $('#aux_enseñanza').val("");
                            $('#aux_grado').val("");
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }

            });

            $('#AgregarCalendario').click(function () {
                var idx = $('#variable_oculta').val();
                for (var i = 1; i <= idx; i++) {
                    var inicio = $('#inicio_' + i).val();
                    var fin = $('#fin_' + i).val();
                    var bloque = document.getElementById("bloque").value = "Bloque " + i;

                    var lunes = $('#td_lunes_' + i).val();
                    var orglunes = $('#td_lunes_' + i).attr("CourseSchounduleId");
                    if (orglunes == 'undefined') {
                        orglunes = 0;
                    }

                    var martes = $('#td_martes_' + i).val();
                    var orgMartes = $('#td_martes_' + i).attr("CourseSchounduleId");

                    if (orgMartes == 'undefined') {
                        orgMartes = 0;
                    }


                    var miercoles = $('#td_miercoles_' + i).val();
                    var orgMiercoles = $('#td_miercoles_' + i).attr("CourseSchounduleId");

                    if (orgMiercoles == 'undefined') {
                        orgMiercoles = 0;
                    }

                    var jueves = $('#td_jueves_' + i).val();
                    var orgJueves = $('#td_jueves_' + i).attr("CourseSchounduleId");

                    if (orgJueves == 'undefined') {
                        orgJueves = 0;
                    }

                    var viernes = $('#td_viernes_' + i).val();
                    var orgViernes = $('#td_viernes_' + i).attr("CourseSchounduleId");

                    if (orgViernes == 'undefined') {
                        orgViernes = 0;
                    }

                    var sabado = $('#td_sabado_' + i).val();
                    var orgSabado = $('#td_sabado_' + i).attr("CourseSchounduleId");

                    console.log("ORGSABADO: " + orgSabado);
                    if (orgSabado == 'undefined') {
                        orgSabado = 0;
                    }

                    var domingo = $('#td_domingo_' + i).val();
                    var orgDomingo = $('#td_domingo_' + i).attr("CourseSchounduleId");

                    if (orgDomingo == 'undefined') {
                        orgDomingo = 0;
                    }
                  
                    if (lunes == '') {
                        lunes = 0;
                    }
                    if (martes == '') {
                        martes = 0;
                    }
                    if (miercoles == '') {
                        miercoles = 0;
                    }
                    if (jueves == '') {
                        jueves = 0;
                    }
                    if (viernes == '') {
                        viernes = 0;
                    }
                    if (sabado == '') {
                        sabado = 0;
                    }
                    if (domingo == '') {
                        domingo = 0;
                    }
                   //$("#strLunes").val($("#strLunes").val() + inicio + "," + fin + "," + bloque + ",@" + lunes + ",;"+ martes + ",;" + miercoles + ",;" + jueves + ",;" + viernes + ",;" + sabado + ",;" + domingo + ",;@||");
                    $("#strLunes").val($("#strLunes").val() + inicio + "," + fin + "," + bloque + ",@" + orglunes + "," + lunes + ";" + orgMartes + "," + martes + ";" + orgMiercoles + "," + miercoles + ";" + orgJueves + "," + jueves + ";" + orgViernes + "," + viernes + ";" + orgSabado + "," + sabado + ";" + orgDomingo +","+ domingo+ ";@||");

                }
                var strAsignaturas = $("#strLunes").val();
                var curso = $('#curso_c').val();
                var f_inicio = $('#f_inicio').val();
                var f_fin = $('#f_fin').val();
                var tipo_session = $('#tipo_session').val();
                var minutos_instruccion = $('#minutos_instruccion').val();
                var descripcion = $('#descripcion').val();
                var termino_calificacion = $('#termino_calificacion').val();
                var p_programacion = $('#p_programacion').val();
                var termino_asistencia = $('#termino_asistencia').val();
                $.ajax({
                    type: "POST",
                    url: '/Calendar.asmx/IngresarCalendario',
                    data: "{strAsignaturas:'" + strAsignaturas +
                        "',f_inicio:'" + f_inicio +
                        "',f_fin:'" + f_fin +
                        "',tipo_session:'" + tipo_session +
                        "',minutos_instruccion:'" + minutos_instruccion +
                        "',termino_calificacion:'" + termino_calificacion +
                        "',curso:'" + curso +
                        "',p_programacion:'" + p_programacion +
                        "',termino_asistencia:'" + termino_asistencia +
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
                        mostrar();
                    },
                    error: function (err) { console.log("Error:" + err); },
                });


            });
         
            $(document).on('click', '.btn_asignar_asignatura', function () {

                var curso = $(this).attr("id");
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignatura',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //alert(data.d);
                        $('#asignatura').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $('#hidden_curso').val(curso);


                getAsignaturaProfe();
                $('#asignatura_form').modal({
                    keyboard: true
                });
            });
            $(document).on('click', '.btn_check', function () {
                var idx = $(this).attr("id");
                document.getElementById("div_oculto").style.display = 'block';
                $("#div_oculto").append('<input name"new_gallery" /><a href="#" id="create_new_gallery">Add</a><br><br><br><br><br>');
            });
            function agregarFila() {
               
        
            }
            $(document).on('click', '.btn_calendario', function () {
                //agregarFila();
                $('#calendario_form').modal({
                    keyboard: true
                });
                var idx = $(this).attr("id");
                var Course = document.getElementById("CourseId").value = idx;
                //alert($('#CourseId').val());
                $('#curso_c').val($('#course' + Course).html());

                var ssa = $('#curso_c').val();

                $("#id_calendario_id").val(idx);
                $("#tabla_horario>tbody tr").remove();
                $("#btnCalendario_id").click();

                var idx = parseInt($('#variable_oculta').val()) + 1;
                var curso = $("#id_calendario_id").val();
                $('#variable_oculta').val(idx);

                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/ExisteHorario',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        if (data.d == 1) {
                            //1= ya existe
                            $('#tr_table').html("<tr id='col_tr_" + idx + "'>'"
                                + "'<td style='width:8%;'> "
                                + "<div class='row'>"
                                + "<div class='col-6'>"
                                + "<button type='button'id='id_" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_agregarFila'> "
                                + " <i class='fas fa-plus-circle'></i> "
                                + "</button>"
                                + "</div>"
                                + "<div class='col-3'>"
                                + "<button type='button'id='" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_eliminarFila'>"
                                + " <i class='fas fa-trash-alt'></i>"
                                + "</button>"
                                + "</div>"
                                + "</div>"
                                + "</td> "
                                + " <td style='height:30px; width:1200px;'>"
                                + "<div class='row'>"
                                + "<div class='col-12'>"
                                + "<label>Inicio</label>"
                                + "<input type='hidden' id='bloque " + idx + "' value='" + idx + "'/> "
                                + "<input class='form-control' id='inicio_" + idx + "' type='time' required='' />  "
                                + "</div> "
                                + "<div class='col-12'>  "
                                + " <label>Fin</label> "
                                + "<input class='form-control' id='fin_" + idx + "' type='time' required=''/> "
                                + "</div> "
                                + "  </div> "
                                + "</td> "
                                + "<td  style='width:10%;'>"
                                + " <div> "
                                + "<label>Asignatura</label>"
                                + "<input type='hidden' id='aux_lunes' value='1'/>"
                                + "<select  id='td_lunes_" + idx + "' name='td_lunes' title='Nada Seleccionado' multiple class='selectpicker'></select>"
                                + "</div>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_martes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_miercoles_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_jueves_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker'  required ='' ></select >"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_viernes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_sabado_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_domingo_" + idx + "'multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "</tr>");



                            var id = $('#variable_oculta').val();
                            var curso_id = $("#id_calendario_id").val();


                            func_lunes(id, curso_id);

                            $.ajax({
                                type: "POST",
                                url: 'Cursos.asmx/MostrarHorario',
                                data: "{curso:'" + curso +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {

                                    $("#input_oculto").html(data.d);
                                    var input = $("#datos").val();

                                    var strString = input.toString();
                                    var sin = strString.replace(" ", "");
                                    var strSplit = sin.split("||");


                                    for (var i = 0; i < strSplit.length; i++) {
                                        var f_inicio = strSplit[i];
                                        var f_inicio_split = f_inicio.split("@@");
                                        for (var j = 1; j < f_inicio_split.length; j++) {
                                            var fecha_inicial = f_inicio_split[0];
                                            var fecha_fin = f_inicio_split[1];
                                            var bloque = f_inicio_split[2];
                                            var ORG = f_inicio_split[3];//OrganizationId
                                            var dias_letra = f_inicio_split[4];
                                            $("#inicio_" + bloque).val(fecha_inicial);
                                            $("#fin_" + bloque).val(fecha_fin);

                                            if (dias_letra == 'Lunes') {
                                                $("#td_lunes_" + bloque).val(ORG);
                                                $('#td_lunes_' + bloque).selectpicker('refresh');
                                                $("#td_lunes_" + bloque).attr('CourseSchounduleId', ORG);
                                            }
                                            if (dias_letra == 'Martes') {
                                                $("#td_martes_" + bloque).val(ORG);
                                                $('#td_martes_' + bloque).selectpicker('refresh');
                                                $('#td_martes_' + bloque).attr('CourseSchounduleId', ORG);



                                            }
                                            if (dias_letra == 'Miercoles') {
                                                $("#td_miercoles_" + bloque).val(ORG);
                                                $('#td_miercoles_' + bloque).selectpicker('refresh');
                                                $('#td_miercoles_' + bloque).attr('CourseSchounduleId', ORG);


                                            }
                                            if (dias_letra == 'Jueves') {


                                                $("#td_jueves_" + bloque).val(ORG);
                                                $('#td_jueves_' + bloque).selectpicker('refresh');
                                                $('#td_jueves_' + bloque).attr('CourseSchounduleId', ORG);



                                            }
                                            if (dias_letra == 'Viernes') {


                                                $("#td_viernes_" + bloque).val(ORG);
                                                $('#td_viernes_' + bloque).selectpicker('refresh');
                                                $('#td_viernes_' + bloque).attr('CourseSchounduleId', ORG);



                                            }
                                            if (dias_letra == 'Sabado') {

                                                $("#td_sabado_" + bloque).val(ORG);
                                                $('#td_sabado_' + bloque).selectpicker('refresh');
                                                $('#td_sabado_' + bloque).attr('CourseSchounduleId', ORG);





                                            }

                                            if (dias_letra == 'Domingo') {

                                                $("#td_domingo" + bloque).val(ORG);
                                                $('#td_domingo' + bloque).selectpicker('refresh');
                                                $('#td_domingo' + bloque).attr('CourseSchounduleId', ORG);


                                            }







                                        }
                                    }


                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
                            });

                          

                        }
                        if (data.d == 2) {
                            $('#tr_table').append("<tr id='col_tr_" + idx + "'>'"
                                + "'<td style='width:8%;'> "
                                + "<div class='row'>"
                                + "<div class='col-6'>"
                                + "<button type='button'id='" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_agregarFila'> "
                                + " <i class='fas fa-plus-circle'></i> "
                                + "</button>"
                                + "</div>"
                                + "<div class='col-3'>"
                                + "<button type='button'id='" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_eliminarFila'>"
                                + " <i class='fas fa-trash-alt'></i>"
                                + "</button>"
                                + "</div>"
                                + "</div>"
                                + "</td> "
                                + " <td style='height:30px; width:1200px;'>"
                                + "<div class='row'>"
                                + "<div class='col-12'>"
                                + "<label>Inicio</label>"
                                + "<input type='hidden' id='bloque " + idx + "' value='" + idx + "'/> "
                                + "<input class='form-control' id='inicio_" + idx + "' type='time' required='' />  "
                                + "</div> "
                                + "<div class='col-12'>  "
                                + " <label>Fin</label> "
                                + "<input class='form-control' id='fin_" + idx + "' type='time' required=''/> "
                                + "</div> "
                                + "  </div> "
                                + "</td> "
                                + "<td  style='width:10%;'>"
                                + " <div> "
                                + "<label>Asignatura</label>"
                                + "<input type='hidden' id='aux_lunes' value='1'/>"
                                + "<select  id='td_lunes_" + idx + "' name='td_lunes' title='Nada Seleccionado' multiple class='selectpicker'></select>"
                                + "</div>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_martes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_miercoles_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_jueves_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker'  required ='' ></select >"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_viernes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_sabado_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_domingo_" + idx + "'multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "</tr>");
                            $('#variable_oculta').val(idx);
                            var id = $('#variable_oculta').val();
                            var curso_id = $("#id_calendario_id").val();

                            func_lunes(id, curso_id);

                        }
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            });
            //agregarFila();
            $(document).on('click', '.btn_agregarFila', function () {

                var idx = parseInt($('#variable_oculta').val()) + 1;
                var curso = $("#id_calendario_id").val();
                $('#variable_oculta').val(idx);

                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/ExisteHorario',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        if (data.d == 1) {
                            //1= ya existe
                            $('#tr_table').append("<tr id='col_tr_" + idx + "'>'"
                                + "'<td style='width:8%;'> "
                                + "<div class='row'>"
                                + "<div class='col-6'>"
                                + "<button type='button'id='id_" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_agregarFila'> "
                                + " <i class='fas fa-plus-circle'></i> "
                                + "</button>"
                                + "</div>"
                                + "<div class='col-3'>"
                                + "<button type='button'id='" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_eliminarFila'>"
                                + " <i class='fas fa-trash-alt'></i>"
                                + "</button>"
                                + "</div>"
                                + "</div>"
                                + "</td> "
                                + " <td style='height:30px; width:1200px;'>"
                                + "<div class='row'>"
                                + "<div class='col-12'>"
                                + "<label>Inicio</label>"
                                + "<input type='hidden' id='bloque " + idx + "' value='" + idx + "'/> "
                                + "<input class='form-control' id='inicio_" + idx + "' type='time' required='' />  "
                                + "</div> "
                                + "<div class='col-12'>  "
                                + " <label>Fin</label> "
                                + "<input class='form-control' id='fin_" + idx + "' type='time' required=''/> "
                                + "</div> "
                                + "  </div> "
                                + "</td> "
                                + "<td  style='width:10%;'>"
                                + " <div> "
                                + "<label>Asignatura</label>"
                                + "<input type='hidden' id='aux_lunes' value='1'/>"
                                + "<select  id='td_lunes_" + idx + "' name='td_lunes' title='Nada Seleccionado' multiple class='selectpicker'></select>"
                                + "</div>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_martes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_miercoles_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_jueves_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker'  required ='' ></select >"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_viernes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_sabado_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_domingo_" + idx + "'multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "</tr>");



                            var id = $('#variable_oculta').val();
                            var curso_id = $("#id_calendario_id").val();


                            func_lunes(id, curso_id);

                            $.ajax({
                                type: "POST",
                                url: 'Cursos.asmx/MostrarHorario',
                                data: "{curso:'" + curso +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {

                                    $("#input_oculto").html(data.d);
                                    var input = $("#datos").val();

                                    var strString = input.toString();
                                    var sin = strString.replace(" ", "");
                                    var strSplit = sin.split("||");


                                    for (var i = 0; i < strSplit.length; i++) {
                                        var f_inicio = strSplit[i];
                                        var f_inicio_split = f_inicio.split("@@");
                                        for (var j = 1; j < f_inicio_split.length; j++) {
                                            var fecha_inicial = f_inicio_split[0];
                                            var fecha_fin = f_inicio_split[1];
                                            var bloque = f_inicio_split[2];
                                            var ORG = f_inicio_split[3];//OrganizationId
                                            var dias_letra = f_inicio_split[4];
                                            $("#inicio_" + bloque).val(fecha_inicial);
                                            $("#fin_" + bloque).val(fecha_fin);

                                            if (dias_letra == 'Lunes') {
                                                $("#td_lunes_" + bloque).val(ORG);
                                                $('#td_lunes_' + bloque).selectpicker('refresh');
                                                $("#td_lunes_" + bloque).attr('CourseSchounduleId', ORG);
                                            }
                                            if (dias_letra == 'Martes') {
                                                $("#td_martes_" + bloque).val(ORG);
                                                $('#td_martes_' + bloque).selectpicker('refresh');
                                                $('#td_martes_' + bloque).attr('CourseSchounduleId', ORG);



                                            }
                                            if (dias_letra == 'Miercoles') {
                                                $("#td_miercoles_" + bloque).val(ORG);
                                                $('#td_miercoles_' + bloque).selectpicker('refresh');
                                                $('#td_miercoles_' + bloque).attr('CourseSchounduleId', ORG);


                                            }
                                            if (dias_letra == 'Jueves') {


                                                $("#td_jueves_" + bloque).val(ORG);
                                                $('#td_jueves_' + bloque).selectpicker('refresh');
                                                $('#td_jueves_' + bloque).attr('CourseSchounduleId', ORG);



                                            }
                                            if (dias_letra == 'Viernes') {


                                                $("#td_viernes_" + bloque).val(ORG);
                                                $('#td_viernes_' + bloque).selectpicker('refresh');
                                                $('#td_viernes_' + bloque).attr('CourseSchounduleId', ORG);



                                            }
                                            if (dias_letra == 'Sabado') {

                                                $("#td_sabado_" + bloque).val(ORG);
                                                $('#td_sabado_' + bloque).selectpicker('refresh');
                                                $('#td_sabado_' + bloque).attr('CourseSchounduleId', ORG);





                                            }

                                            if (dias_letra == 'Domingo') {

                                                $("#td_domingo" + bloque).val(ORG);
                                                $('#td_domingo' + bloque).selectpicker('refresh');
                                                $('#td_domingo' + bloque).attr('CourseSchounduleId', ORG);


                                            }







                                        }
                                    }


                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
                            });
                       

                        }
                        if (data.d == 2) {
                            $('#tr_table').append("<tr id='col_tr_" + idx + "'>'"
                                + "'<td style='width:8%;'> "
                                + "<div class='row'>"
                                + "<div class='col-6'>"
                                + "<button type='button'id='" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_agregarFila'> "
                                + " <i class='fas fa-plus-circle'></i> "
                                + "</button>"
                                + "</div>"
                                + "<div class='col-3'>"
                                + "<button type='button'id='" + idx + "' class='btn btn-sm btn-icon btn-secundary btn_eliminarFila'>"
                                + " <i class='fas fa-trash-alt'></i>"
                                + "</button>"
                                + "</div>"
                                + "</div>"
                                + "</td> "
                                + " <td style='height:30px; width:1200px;'>"
                                + "<div class='row'>"
                                + "<div class='col-12'>"
                                + "<label>Inicio</label>"
                                + "<input type='hidden' id='bloque " + idx + "' value='" + idx + "'/> "
                                + "<input class='form-control' id='inicio_" + idx + "' type='time' required='' />  "
                                + "</div> "
                                + "<div class='col-12'>  "
                                + " <label>Fin</label> "
                                + "<input class='form-control' id='fin_" + idx + "' type='time' required=''/> "
                                + "</div> "
                                + "  </div> "
                                + "</td> "
                                + "<td  style='width:10%;'>"
                                + " <div> "
                                + "<label>Asignatura</label>"
                                + "<input type='hidden' id='aux_lunes' value='1'/>"
                                + "<select  id='td_lunes_" + idx + "' name='td_lunes' title='Nada Seleccionado' multiple class='selectpicker'></select>"
                                + "</div>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_martes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_miercoles_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_jueves_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker'  required ='' ></select >"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_viernes_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_sabado_" + idx + "' multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "<td style='width:10%;'>"
                                + "<label>Asignatura</label>"
                                + "<select id='td_domingo_" + idx + "'multiple  title='Nada Seleccionado' class='selectpicker' required=''></select>"
                                + "</td>"
                                + "</tr>");
                            $('#variable_oculta').val(idx);
                            var id = $('#variable_oculta').val();
                            var curso_id = $("#id_calendario_id").val();

                            func_lunes(id, curso_id);

                        }
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            });
            $(document).on('click', '.btn_eliminarFila', function () {
                var idx = $(this).attr("id");
                $("#col_tr" + idx).remove();
            });
            function func_lunes(id, curso_id) {

                
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_lunes_" + id).html(data.d);
                        $('#td_lunes_'+id).html(data.d).selectpicker('refresh');

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_martes_" + id).html(data.d);
                        $('#td_martes_' + id).html(data.d).selectpicker('refresh');
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_miercoles_" + id).html(data.d);
                        $('#td_miercoles_' + id).html(data.d).selectpicker('refresh');

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_jueves_" + id).html(data.d);
                        $('#td_jueves_' + id).html(data.d).selectpicker('refresh');
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_viernes_" + id).html(data.d);
                        $('#td_viernes_' + id).html(data.d).selectpicker('refresh');
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_sabado_" + id).html(data.d);
                        $('#td_sabado_' + id).html(data.d).selectpicker('refresh');
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Cursos.asmx/SelectAsignaturaK',
                    data: "{curso_id:'" + curso_id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#td_domingo_" + id).html(data.d);
                        $('#td_domingo_' + id).html(data.d).selectpicker('refresh');
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            }
        });
    </script>
    <input type="hidden"  id="id_calendario_notas" value="0"/>
    <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Curso</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm"  data-toggle="modal" type="button" id="btnAbrirModal">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo Curso
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="container" style="overflow-x: auto;">

                <table class="table table-striped- table-bordered table-hover table-checkable" id="tabla_id">
                    <thead>
                        <tr>
                            <th>Acción</th>
                            <th>Id</th>
                            <th>Curso</th>
                            <th>Tipo de Enseñanza</th>
                            <th>Tipo de Curso</th>
                            <th>Especialidad</th>
                            <th>Sector</th>
                            <th>Rama</th>
                            <th>Nivel</th>
                            <th>Jornada</th>
                            <th>Modalidad</th>
<%--                            <th>Profesor Jefe</th>--%>

                        </tr>
                    </thead>
                    <tbody id="mostrar">
                    </tbody>
                </table>
            </div>

            <br />


        </div>
    </div>
    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align: left;">
            <div class="modal-content">
                <div class="modal-header">                  
                          <h5 class="modal-title" id="titulo_modal"> Nuevo Curso
                          </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>    
                    <input type="hidden" id="id_calendario_id" value="0"/>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label>Modalidad</label>
                                <select  id="modalidad" name="modalidad"  class="custom-select d-block w-100" required="">
                                </select>
                                <div class="invalid-feedback" style="display: none;" id="modalidad_error">El dato  ya está ingresado. </div>
                                <input type="hidden" id="id_colegio" value="2" />
                                <input type="hidden" id="CourseId" value="0" />

                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Jornada</label>
                                <select class="custom-select d-block w-100" id="jornada" name="jornada" required="">
                                </select>
                                <div class="invalid-feedback" style="display: none;" id="jornada_error">El dato  ya está ingresado. </div>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Nivel de Educación</label>
                                <select class="custom-select d-block w-100" id="nivel" name="nivel" required="">
                                </select>
                                <div class="invalid-feedback" style="display: none;" id="nivel_error">El dato  ya está ingresado. </div>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Rama de Especialidad</label>
                                <select class="custom-select d-block w-100" id="rama" name="rama" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Sector Económico</label>
                                <select class="custom-select d-block w-100" id="sector" name="sector" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Especialidad</label>
                                <select class="custom-select d-block w-100" id="especialidad" name="especialidad" required="">
                                </select>
                                <input type="hidden" id="h_lunes" value="0" />
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Tipo de Curso</label>
                                <select class="custom-select d-block w-100" id="tipo_curso" name="tipo_curso" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Tipo de Enseñanza</label>
                                <select class="custom-select d-block w-100" id="tipo_enseñanza" name="tipo_enseñanza" required="">
                                </select>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Grado</label>
                                <select class="custom-select d-block w-100" id="grado"  name="grado" required="">
                                </select>
                            </div>
                            
                                          
                            <input type="hidden" value="" id="aux1" />
                            <input type="hidden" value="0" id="id_curso" />
                            <input type="hidden" value="" id="strLunes" />
                            <input type="hidden" value="" id="titulo" />



                            <div class="col-md-6 mb-3">
                                <label>Letra</label>
                                <input type="text" class="form-control" id="letra" name="letra" required="">
                                <div class="invalid-feedback" style="display: none;" id="letra_error">El dato  ya está ingresado. </div>
                            </div>
                         <%--   <div class="col-md-6 mb-3">
                                <label>Profesor Jefe</label>
                                <select class="custom-select d-block w-100" id="profesor_jefe" name="profesor_jefe" required="">
                                </select>
                            </div>--%>


                            <div style="display: none" id="div_modalidad"></div>
                            <div style="display: none" id="div_jornada"></div>
                            <div style="display: none" id="div_nivel"></div>
                            <div style="display: none" id="div_rama"></div>
                            <div style="display: none" id="div_sector"></div>
                            <div style="display: none" id="div_especialidad"></div>
                            <div style="display: none" id="div_TipoCurso"></div>
                            <div style="display: none" id="div_enseñanza"></div>
                            <div style="display: none" id="div_grado"></div>


                        </div>


                    </form>


                </div>
                <div class="modal-footer">
                    <button id="btnCancelar" class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary" type="button" id="btnAgregar">Guardar</button>

                    <input type="hidden"  id="aux_modalidad" value="0"/>
                    <input type="hidden"  id="aux_jornada" value="0"/>
                    <input type="hidden"  id="aux_nivel" value="0"/>
                    <input type="hidden"  id="aux_rama" value="0"/>
                    <input type="hidden"  id="aux_sector" value="0"/>
                    <input type="hidden"  id="aux_especialidad" value="0"/>
                    <input type="hidden"  id="aux_tipo_curso" value="0"/>
                    <input type="hidden"  id="aux_enseñanza" value="0"/>
                    <input type="hidden"  id="aux_grado" value="0"/>


                </div>

            </div>
        </div>
    </div>


    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="asignatura_form" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align: left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="asig">Asignar Profesor
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>
                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_asig_asignatura">
                        <div class="row">

                            <div class="col-md-3 mb-3">
                                <label>Asignatura</label>
                                <select class="custom-select d-block w-100" id="asignatura" required="">
                                </select>
                                <input type="hidden" value="" id="hidden_curso" />
                               <input type="hidden" value="0" id="strInsert" />

                            </div>
                            <div class="col-md-3 mb-3">
                                <label>Profesor</label>
                                <select class="custom-select d-block w-100" id="profesor" required="">
                                </select>
                            </div>

                            <div class="col-md-3 mb-3">


                                <button class="btn btn-primary" type="button" id="btnAgregarAsignatura" style="margin-top: 30px;">Agregar</button>

                            </div>
                        </div>
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="tabla_id">
                            <thead>
                                <tr>
                                    <th>Acción</th>
                                    <th>Asignatura</th>
                                    <th>Profesor</th>


                                </tr>
                            </thead>
                            <tbody id="mostrar_datoss">
                            </tbody>
                        </table>

                    </form>
                </div>
                <div class="modal-footer">
                    <button id="btnCancelarAsignarProfesorAsignatura" class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>
                </div>
            </div>
        </div>
    </div>


    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fullscreen-modal fade" id="calendario_form" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align: left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="calendario">Periodos - Horarios
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>
                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="calendario_c_form">
                    <div id="accordion">
                        <div class="card">
                            <div class="card-header" id="headingOne">
                            <h5 class="mb-0">
                                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne" style="color:blue; text-decoration:none;">
                                Ingreso de Periodos (Semestres, Trimestres) 1#
                                </button>
                            </h5>
                            </div>
                            <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-6 mb-3">
                                            <label>Fecha de Inicio</label>
                                            <input type="date" class="form-control" id="f_inicio"  required=""/>
                                        </div> 
                                          <div class="col-md-6 mb-3">
                                            <label>Fecha de Fin</label>
                                            <input type="date" class="form-control" id="f_fin"  required=""/>
                                        </div> 
                                        <div class="col-md-6 mb-3">
                                            <label>Tipo de sesión</label>
                                            <select  id="tipo_session" name="tipo_session"  class="custom-select d-block w-100" required="">
                                                <option value="">Seleccione... </option>
                                                <option value="">Año escolar completo </option>
                                            </select>
                                        </div>  
                                        <div class="col-md-6 mb-3">
                                            <label>Minutos de Instrucción</label>
                                            <input type="number"  min="0" class="form-control" id="minutos_instruccion"  required=""/>

                                        </div>  
                                         <div class="col-md-6 mb-3">
                                            <label>Descripción</label>
                                            <textarea class="form-control" id="descripcion" rows="3" required=""></textarea>
                                        </div>  
                                        <div class="col-md-6 mb-3">
                                            <label>Término de calificación.</label>
                                            <select  id="termino_calificacion" name=""  class="custom-select d-block w-100" required="">
                                                <option value="">Seleccione... </option>
                                                <option value="">Si </option>
                                                <option value="">No </option>
                                            </select>
                                        </div>  
                                        <div class="col-md-6 mb-3">
                                            <label>Período de programación</label>
                                            <select  id="p_programacion" name=""  class="custom-select d-block w-100" required="">
                                                <option value="">Seleccione... </option>
                                                <option value="">Si </option>
                                                <option value="">No </option>
                                            </select>
                                        </div>  
                                        <div class="col-md-6 mb-3">
                                            <label>Término de asistencia.</label>
                                            <select  id="termino_asistencia" name=""  class="custom-select d-block w-100" required="">
                                                <option value="">Seleccione... </option>
                                                <option value="">Si </option>
                                                <option value="">No </option>
                                            </select>
                                        </div>  

                                         
                        
                                    </div>
                                </div>    
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-header" id="headingTwo">
                            <h5 class="mb-0">
                                <button id="btnCalendario_id" class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" style="color:black; text-decoration:none;">
                                 Horario de Clases del Curso #2
                                </button>
                            </h5>
                            </div>
                            <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                            <div class="card-body">
                                <div class="container">
                            <div  class="table table-striped w-auto" style="overflow-x: auto; height:400px">
                                <table id="tabla_horario">
                                <thead>
                                    <tr>
                                        <th style="width: 100px;">Acción
                                        </th>
                                        <th style="width: 500px;">Hora
                                        </th>
                                        <th style="width: 200px;">Lun
                                        </th>
                                        <th style="width: 200px;">Mar

                                        </th>
                                        <th style="width: 200px;">Mie
                                        </th>
                                        <th style="width: 200px;">Jue
                                        </th>
                                        <th style="width: 200px;">Vi
                                        </th>
                                        <th style="width: 200px;">Sa
                                        </th>
                                        <th style="width: 200px;">Do
                                       <input type="hidden" value="0" id="variable_oculta" />
                                        <input type="hidden" value="0" id="bloque" />
                                       <input type="hidden" value="0" id="curso_c" />

                                        </th>

                                    </tr>
                                </thead>
                                <tbody id="tr_table">
                                </tbody>
                            </table>
                            </div>
                        </div>
                            </div>
                            </div>
                        </div>
                        <div style="display:none;" id="input_oculto"></div>
                    </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>
                    <button class="btn btn-primary" type="button" id="AgregarCalendario">Agregar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
