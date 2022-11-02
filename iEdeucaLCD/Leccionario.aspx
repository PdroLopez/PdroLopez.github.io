<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Leccionario.aspx.vb"  MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Leccionario" %>
<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="jquery-3.6.0.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%--<script src="sweetalert2.min.js"></script>--%>
    <%--<link rel="stylesheet" href="sweetalert2.min.css">--%>
    <script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
<script  type="text/javascript">
    $(document).ready(function () {
        function mitabla(curso, asignatura) {
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/getTabla',
                data: "{curso:'" + curso +
                    "',asignatura:'" + asignatura +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    //alert(data.d);
                    $('#tabla_id').html(data.d);
                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });

            var curso = $("#curso").val();
            var asignatura = $("#asignatura").val();

            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/selectUnidad',
                data: "{curso:'" + curso +
                    "',asignatura:'" + asignatura +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    //alert(data.d);
                    $('#unidad').html(data.d);

                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        }
        function llenarData() {

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
            var curso = $("#curso").val();
            var asginatura = $("#asginatura").val();

            //$.ajax({
            //    type: "POST",
            //    url: 'Leccionario.asmx/selectUnidad',
            //    data: "{}",
            //    contentType: "application/json",
            //    datatype: "json",
            //    success: function (data) {
            //        //alert(data.d);
            //        $('#unidad').html(data.d);

            //    },
            //    error: function (err) {
            //        console.log("Error:" + err);
            //    },
            //});


            //$.ajax({
            //    type: "POST",
            //    url: 'Leccionario.asmx/selectObjetivo',
            //    data: "{}",
            //    contentType: "application/json",
            //    datatype: "json",
            //    success: function (data) {
            //        //alert(data.d);
            //        $('#objetivo').html(data.d);

            //    },
            //    error: function (err) {
            //        console.log("Error:" + err);
            //    },
            //});


        }
        llenarData();
        function llenarData2() {
            //var curso = $("#curso").val();
            //var asignatura = $("#asignatura").val();

            //$.ajax({
            //    type: "POST",
            //    url: 'Leccionario.asmx/selectUnidad',
            //    data: "{curso:'" + curso +
            //        "',asignatura:'" + asignatura +
            //        "'}",
            //    contentType: "application/json",
            //    datatype: "json",
            //    success: function (data) {
            //        //alert(data.d);
            //        $('#unidad').html(data.d);

            //    },
            //    error: function (err) {
            //        console.log("Error:" + err);
            //    },
            //});


            //$.ajax({
            //    type: "POST",
            //    url: 'Leccionario.asmx/selectObjetivo',
            //    data: "{}",
            //    contentType: "application/json",
            //    datatype: "json",
            //    success: function (data) {
            //        //alert(data.d);
            //        $('#objetivo').html(data.d);

            //    },
            //    error: function (err) {
            //        console.log("Error:" + err);
            //    },
            //});


        }

        $(document).on('click', '.card-body', function () {

            var idx = $(this).attr("id");


            $("#unidad").val($("#Unidad" + idx).val());
            $("#fecha").val($("#BirthDate" + idx).val());


            $("#LeccionarioId").val(idx);

            //Buscar el objetivo de la unidad
            var unidad = $("#unidad").val();
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/GetObjetivoSelect',
                data: "{unidad:'" + unidad +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    $('#objetivo').html(data.d);
                    $('#objetivo').val($("#Objetivo" + idx).val());

                    var objetivo_input = $('#objetivo').val();
                    $.ajax({
                        type: "POST",
                        url: 'Leccionario.asmx/GetHabilidadSelect',
                        data: "{objetivo_input:'" + objetivo_input +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (data) {
                            $('#habilidad').html(data.d);
                            $('#habilidad').val($("#Habilidad" + idx).val());



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


            $('#create').modal({
                keyboard: true
            });


        });

        $('#curso').on('change', function () {
            var curso = $('#curso').val();
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/GetAsignatura',
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
        function inicio() {
            $("#div_fecha").show();
            $("#select_unidad").show();
            $("#select_objetivo").show();
            $("#select_habilidad").show();
            $("#btnAgregar").show();
            $("#div_nombre_unidad").hide();
            $("#div_descripcion_unidad").hide();
            $("#btnModalUnidad").show();
            $("#btnAgregarUnidad").hide();
            $("#btnAgregarObjetivo").hide();
            $("#btnAgregarHabilidad").hide();
            $("#btnModalObjetivo").show();

            $("#exampleModalLabel").html("Agregar Leccionario");
        }
        $('#btnIngresar').on('click', function () {
            inicio();
            myfunction();
        });
        $('#btnAgregarUnidad').click(function () {

            var nombre_unidad = $("#nombre_unidad").val();
            var descripcion_unidad = $("#descripcion_unidad").val();
            var curso = $("#curso").val();
            var asignatura = $("#asignatura").val();

            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/IngresarUnidad',
                data: "{nombre_unidad:'" + nombre_unidad +
                    "',descripcion_unidad:'" + descripcion_unidad +
                    "',curso:'" + curso +
                    "',asignatura:'" + asignatura +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: data.d,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    mitabla(curso, asignatura);
                    inicio();
                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });

        });


        $('#btnAgregarHabilidad').on('click', function () {
            var clicando = false;
            if (clicando) {

            }
            else {
                clicando = true;
                var nombre_unidad = $("#nombre_unidad").val();
                var descripcion_unidad = $("#descripcion_unidad").val();
                var objetivo = $("#objetivo").val();
                $.ajax({
                    type: "POST",
                    url: 'Leccionario.asmx/IngresarHabilidad',
                    data: "{nombre_unidad:'" + nombre_unidad +
                        "',descripcion_unidad:'" + descripcion_unidad +
                        "',objetivo:'" + objetivo +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        Swal.fire({
                            position: 'top-center',
                            icon: 'success',
                            title: data.d,
                            showConfirmButton: false,
                            timer: 1500
                        })
                        llenarData2();
                        inicio();
                        limpiar();
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            }
 

        });





        $('#btnAgregarObjetivo').on('click', function () {
            var nombre_unidad = $("#nombre_unidad").val();
            var unidad = $("#unidad").val();
            var descripcion_unidad = $("#descripcion_unidad").val();
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/IngresarObjetivo',
                data: "{nombre_unidad:'" + nombre_unidad +
                    "',descripcion_unidad:'" + descripcion_unidad +
                    "',unidad:'" + unidad +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: data.d,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    llenarData2();
                    inicio();
                    limpiar();
                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });

        });
        $('#btnAgregarHabilidad').on('click', function () {
            var nombre_unidad = $("#nombre_unidad").val();
            var objetivo = $("#objetivo").val();
            var descripcion_unidad = $("#descripcion_unidad").val();
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/IngresarHabilidad',
                data: "{nombre_unidad:'" + nombre_unidad +
                    "',descripcion_unidad:'" + descripcion_unidad +
                    "',objetivo:'" + objetivo +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: data.d,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    llenarData2();
                    inicio();
                    limpiar();
                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });

        });

        $('#btnAgregar').on('click', function () {
            var unidad = $("#unidad").val();
            var objetivo = $("#objetivo").val();
            var fecha = $("#fecha").val();
            var habilidad = $("#habilidad").val();
            var curso = $("#curso").val();
            var asignatura = $("#asignatura").val();
            var LeccionarioId = $("#LeccionarioId").val();



            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/Ingresar',
                data: "{unidad:'" + unidad +
                    "',objetivo:'" + objetivo +
                    "',fecha:'" + fecha +
                    "',habilidad:'" + habilidad +
                    "',curso:'" + curso +
                    "',asignatura:'" + asignatura +
                    "',LeccionarioId:'" + LeccionarioId +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: data.d,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    inicio();
                    mitabla(curso, asignatura);
                    limpiar();
                    $("#btnCancelar").click();
                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
            //if (LeccionarioId > 0) {
            //    $.ajax({
            //        type: "POST",
            //        url: 'Leccionario.asmx/EditarLeccionario',
            //        data: "{unidad:'" + unidad +
            //            "',objetivo:'" + objetivo +
            //            "',fecha:'" + fecha +
            //            "',habilidad:'" + habilidad +
            //            "',curso:'" + curso +
            //            "',asignatura:'" + asignatura +
            //            "',LeccionarioId:'" + LeccionarioId +
            //            "'}",
            //        contentType: "application/json",
            //        datatype: "json",
            //        success: function (data) {
            //            Swal.fire({
            //                position: 'top-center',
            //                icon: 'success',
            //                title: data.d,
            //                showConfirmButton: false,
            //                timer: 1500
            //            })
            //            inicio();
            //            mitabla(curso, asignatura);
            //            limpiar();
            //        },
            //        error: function (err) {
            //            console.log("Error:" + err);
            //        },
            //    });
            //}
            //else {


            //}


        });

        $('#btnModalHabilidad').on('click', function () {

            $("#div_fecha").hide();
            $("#select_unidad").hide();
            $("#select_habilidad").hide();
            $("#divGuardarLeccionarios").hide();
            $("#divGuardarHabilidad").show();
            $("#btnAgregar").hide();
            $("#btnAgregarUnidad").hide();
            $("#btnAgregarObjetivo").hide();
            $("#btnAgregarHabilidad").show();

            $("#btnModalObjetivo").hide();
            $("#select_objetivo").hide();
            $("#div_nombre_unidad").show();
            $("#div_descripcion_unidad").show();
            $("#exampleModalLabel").html("Ingresar Habilidades");

        });

        $('#btnModalUnidad').on('click', function () {

            $("#div_fecha").hide();
            $("#select_unidad").hide();
            $("#div_nombre_unidad").show();
            $("#div_descripcion_unidad").show();
            $("#select_objetivo").hide();
            $("#select_habilidad").hide();
            $("#btnAgregar").hide();
            $("#btnAgregarUnidad").show();
            $("#exampleModalLabel").html("Ingresar Unidad");

        });
        function txtDescripcion(idLeccionario) {
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/GetHabilidad',
                data: "{objetivo:'" + objetivo +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    $('#' + idLeccionario).html(data.d);

                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        }

        $('#btnModalObjetivo').on('click', function () {

            $("#div_fecha").hide();
            $("#select_unidad").hide();
            $("#select_objetivo").hide();
            $("#select_habilidad").hide();
            $("#btnAgregar").hide();
            $("#btnAgregarUnidad").hide();
            $("#div_nombre_unidad").show();
            $("#div_descripcion_unidad").show();
            $("#exampleModalLabel").html("Ingresar Objetivo");
            $("#btnAgregarObjetivo").show();
            $("#btnModalUnidad").hide();


        });

        function limpiar() {
            $("#nombre_unidad").val("");
            $("#descripcion_unidad").val("");
            $('#unidad').val("");
            $('#objetivo').val("");
            $('#habilidad').val("");
            $('#unidad').prop('selectedIndex', 0);
            $('#objetivo').prop('selectedIndex', 0);
            $('#habilidad').prop('selectedIndex', 0);
        }

        function myfunction() {
            //$("#div_wea").animate({ scrollTop: $('#div_wea').prop("scrollHeight") }, 1000);
            var e = document.getElementsByClassName('table table-striped');
            //Le añado otro mensaje
            //Llevo el scroll al fondo
            var objDiv = document.getElementsByClassName("table table-striped");
            objDiv.scrollTop = objDiv.scrollHeight;


        }
        myfunction();
        $('#asignatura').on('change', function () {
            document.getElementById("div_agregar").style = "block";
            var curso = $("#curso").val();
            var asignatura = $("#asignatura").val();
            mitabla(curso, asignatura);
        });

        $('#objetivo').on('change', function () {
            var objetivo = $('#objetivo').val();
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/GetHabilidad',
                data: "{objetivo:'" + objetivo +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    $('#habilidad').html(data.d);

                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        });

        $('#unidad').on('change', function () {
            var unidad = $('#unidad').val();
            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/GetObjetivo',
                data: "{unidad:'" + unidad +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    $('#objetivo').html(data.d);

                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        });

        $(document).on('click', '.btn_actualizar', function () {

            var idLeccionario = $(this).attr("id");
            var descripcion = $("#txtDescripcion_" + idLeccionario).val();
            var curso = $("#curso").val();
            var asignatura = $("#asignatura").val();

            $.ajax({
                type: "POST",
                url: 'Leccionario.asmx/ActualizarDescripcion',
                data: "{descripcion:'" + descripcion +
                    "',idLeccionario:'" + idLeccionario +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: data.d,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    mitabla(curso, asignatura)
                    txtDescripcion(idLeccionario);
                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });


        });

    });
</script>
  <style>
      .container {
              height: 300px;
              overflow: auto;
              display: flex;
              flex-direction: column-reverse;
            }
  </style>
 <h2 style="text-align:center;">Leccionario</h2>

    <div class="container-fluid-lg">
        <div class="row">
             <div class="col-md-6 mb-3">
                   <label>Curso</label>
                   <select class="custom-select d-block w-100" id="curso"  required="">
                   </select>
             </div>
               <div class="col-md-6 mb-3">
                   <label>Asignatura</label>
                   <select class="custom-select d-block w-100" id="asignatura" required="">
                   </select>
            </div>
        </div>
    </div>  
        <div class="section-block">
            <div id="div_agregar" style="display:none;"> 
                <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnIngresar" style="margin: 15px;">
                    <i class="flaticon2-plus"></i>
                    Agregar 
                </button>
                <input id="op" type="hidden" value="0"/>
            </div>
         </div>

        <div id="div_wea">
       <div class="container" id="a"  >

        <div class="card card-fluid" >
            <!-- .card-header -->

            <div class="table-responsive" >
                <!-- .table -->
                <table class="table table-striped" id="tabla_id">
                    <!-- thead --
<%--                    <tr style="background-color: white;">
                        <td>
                            Enero<br />14
                        </td>
                        <td>
                            <div class="card" style="width: 1000px; height:110px;">
                              <div class="card-body">
                                  <p>Unidad: La Celula</p>
                                  <p>Objetivo: Conocer las funciones de cada parte</p>
                                  <p>Habilidad: Identificar partes de un todo</p>
                              </div>
                            </div>
                            <div class="row">
                                <div class="col-9">
                                        <div class="card">
                                          <div class="card-body">
                              
                                          </div>
                                        </div>
                                </div>
                                <div class="col-3">
                                       <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="">
                                        <i class="flaticon2-plus"></i>
                                        Actualizar
                                    </button>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                    <!-- /tbody -->
                </table>
                <!-- /.table -->
            </div>
            <!-- /.table-responsive -->
        </div>
        <!-- /.card -->

    </div>
    </div>
       <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar Leccionario
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>
                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                     
                        <div class="row">
                             <div class="col-md-6 mb-3" id="div_fecha" style="display:block;" >
                              <label class="control-label" for="flatpickr01">Fecha</label> 
                            <input type="date" class="form-control" id="fecha" name="fecha" required="">

                             </div>
                          <div class="col-md-6 mb-3" id="select_unidad" >
                              <div class="row">
                                      <div class="col-3">
                                            <label>Unidad</label>
                                             <select class="custom-select d-block w-100" id="unidad" name="" required="">
                                             </select>
                                      </div>
                                       <div class="col-3">
                                                <button class="btn btn-outline-primary btn-icon-sm" type="button" id="btnModalUnidad" style="margin:30px;">
                                                    <i class="flaticon2-plus"></i>
                                                    +
                                                               </button>
                                      </div>
                              </div>
                              
                        </div>
                      




                              <div class="col-md-6 mb-3" id="select_objetivo" >
                              <div class="row">
                                      <div class="col-3">
                                            <label>Objetivo</label>
                                             <select class="custom-select d-block w-100" id="objetivo" name="" required="">
                                             </select>
                                      </div>
                                       <div class="col-3">
                                                <button class="btn btn-outline-primary btn-icon-sm" type="button" id="btnModalObjetivo" style="margin:30px;">
                                                    <i class="flaticon2-plus"></i>
                                                    +
                                                               </button>
                                      </div>
                              </div>
                              
                        </div>
                          
                      


                            <div class="col-md-6 mb-3" id="select_habilidad" >
                              <div class="row">
                                      <div class="col-3">
                                            <label>Habilidad</label>
                                             <select class="custom-select d-block w-100" id="habilidad" name="" required="">
                                             </select>
                                      </div>
                                       <div class="col-3">
                                                <button class="btn btn-outline-primary btn-icon-sm" type="button" id="btnModalHabilidad" style="margin:30px;">
                                                    <i class="flaticon2-plus"></i>
                                                    +
                                                               </button>
                                      </div>
                              </div>
                              
                        </div>
                                  <div class="col-md-6 mb-3" id="div_nombre_unidad" style="display:none;">
                                <label>Nombre</label>
                                <input type="text" class="form-control" id="nombre_unidad" name="nombre" required="">
                            </div>
                              <div class="col-md-6 mb-3"  id="div_descripcion_unidad" style="display:none;" >
                                  <label>Descripción</label>
                                  <textarea class="form-control" id="descripcion_unidad" rows="3" required=""></textarea>                             
                              </div>

                                <input type="hidden" id="LeccionarioId" value="0"/>


                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary " id="btnCancelar" data-dismiss="modal" type="button">
                        Cancelar
                    </button>
                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregar">Guardar</button>
                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregarUnidad" style="display:none;">Guardar</button>
                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregarObjetivo" style="display:none;">Guardar</button>
                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregarHabilidad" style="display:none;">Guardar</button>

                </div>

            </div>
        </div>

    </div>


</asp:Content>

