<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Asignatura.aspx.vb"  MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Asignatura" %>
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
       
        var token = sessionStorage.getItem('UsuarioLogueado');


        $(document).on('click', '.btn_editar', function () {
            var idx = $(this).attr("id");
            var Person = document.getElementById("AsignaturaId").value = idx;
            $("#nombre").val($("#Asignatura" + Person).html());
            $("#tipo_asignatura").val($("#Tipo_asignatura" + Person).html());
            $("#tipo_calificacion").val($("#Tipo_calificacion" + Person).html());
            $("#cod_m").val($("#Codigo_Ministerial" + Person).html());
            //$("#primerNombre").val($("#FirstName" + PersonId).html());
            $('#create').modal({
                keyboard: true
            });
        });
        $(document).on('click', '.btn_eliminar', function () {
  
            var AsignaturaId = $(this).attr("id");
            var curso = $('#curso').val();
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
                            url: '/Asignatura.asmx/EliminarAsignatura',
                            data: "{AsignaturaId:'" + AsignaturaId +
                                "',token:'" + token +
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
                                $.ajax({
                                    type: "POST",
                                    url: 'Asignatura.asmx/GetAsignatura',
                                    data: "{curso:'" + curso +
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
        $('#btnAbrirModal').click(function () {
         
            limpiarCampos();
        });

        $('#btnAgregar').click(function () {
            var id = $('#AsignaturaId').val();
            var incide = $('input:radio[name=rdGroup2]:checked').val();
            var curso = $('#curso').val();
            var tipo_asignatura = $('#tipo_asignatura').val();
            var tipo_calificacion = $('#tipo_calificacion').val();
            var nombre = $('#nombre').val();
            var cod_m = $("#cod_m").val();
            var max_capacidad = $("#max_capacidad").val();
            var token = sessionStorage.getItem('UsuarioLogueado');

            $this.attr('disabled', true);

            //if ($("#form_valid").valid() === false) {
            //    event.preventDefault();
            //    event.stopPropagation();
            //}

            $.ajax({
                type: "POST",
                url: '/Asignatura.asmx/ExisteAsignatura',
                data: "{curso:'" + curso +
                    "',nombre:'" + nombre +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    if (data.d == 1) {
                        //1= ya existe
             
                        alert("La asginatura ya existe...");


                    }
                    if (data.d == 2) {

                        $.ajax({
                            type: "POST",
                            url: '/Asignatura.asmx/IngresarAsignatura',
                            type: "POST",
                            data: "{incide:'" + incide +
                                "',curso:'" + curso +
                                "',tipo_asignatura:'" + tipo_asignatura +
                                "',tipo_calificacion:'" + tipo_calificacion +
                                "',nombre:'" + nombre +
                                "',cod_m:'" + cod_m +
                                "',id:'" + id +
                                "',max_capacidad:'" + max_capacidad +
                                "',token:'" + token +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            beforeSend: function () {
                                $this.attr('disabled', true).html("Processing...");

                            },
                            success: function (data) {
                                //Swal.fire({
                                //    position: 'top-center',
                                //    icon: 'success',
                                //    title: data.d,
                                //    showConfirmButton: false,
                                //    timer: 1500
                                //})
                                //$('#create').modal('hide');
                                $this.attr('disabled', false).html("Guardar");

                                $.ajax({
                                    type: "POST",
                                    url: 'Asignatura.asmx/GetAsignatura',
                                    data: "{curso:'" + curso +
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
                        });

                    //    $.ajax({
                    //        type: "POST",
                    //        url: '/Asignatura.asmx/IngresarAsignatura',
                    //        data: "{incide:'" + incide +
                    //            "',curso:'" + curso +
                    //            "',tipo_asignatura:'" + tipo_asignatura +
                    //            "',tipo_calificacion:'" + tipo_calificacion +
                    //            "',nombre:'" + nombre +
                    //            "',cod_m:'" + cod_m +
                    //            "',id:'" + id +
                    //            "',max_capacidad:'" + max_capacidad +
                    //            "',token:'" + token +
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
                    //            $('#create').modal('hide');

                    //            $.ajax({
                    //                type: "POST",
                    //                url: 'Asignatura.asmx/GetAsignatura',
                    //                data: "{curso:'" + curso +
                    //                    "'}",
                    //                contentType: "application/json",
                    //                datatype: "json",
                    //                success: function (data) {
                    //                    $('#mostrar').html(data.d);
                    //                },
                    //                error: function (err) {
                    //                    console.log("Error:" + err);
                    //                },
                    //            });
                    //            //  listar();
                    //        },
                    //        error: function (err) { console.log("Error:" + err); },
                    //    });
                    }
                    //  listar();
                },
                error: function (err) { console.log("Error:" + err); },
            });




        });
        function SelectInput() {
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
        SelectInput();
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
        $('#curso').on('change', function () {
            var curso = $('#curso').val();
            $.ajax({
                type: "POST",
                url: 'Asignatura.asmx/GetAsignatura',
                data: "{curso:'" + curso +
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
        });
        function SelecTresNivel() {
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
        }
        SelecTresNivel();
        function limpiarCampos() {
            $('#max_capacidad').val('');
            $('#tipo_asignatura').val('');
            $('#tipo_calificacion').val('');
            $('#nombre').val('');
            $("#cod_m").val('');
        }
        function cerrarSeccion() {
            var token = sessionStorage.getItem('UsuarioLogueado');
            $.ajax({
                type: "POST",
                url: '/Login.asmx/DeleteToken',
                data: "{token:'" + token +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    sessionStorage.removeItem('UsuarioLogueado');
                    window.location.reload();


                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        }
    });
</script>
    <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Asignatura</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnAbrirModal">
                                    <i class="flaticon2-plus"></i>
                                    Nueva Asignatura
                                </button>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-6 mb-3"> <br />
                                <label>Curso</label>
                                <select class="custom-select d-block w-100" id="curso"  required="">
                                </select>
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
                            <th>Asignatura</th>                            
                        </tr>
                    </thead>
                    <tbody id="mostrar">
                     
                    </tbody>
                </table>
            </div>
        </div>
    </div>

         <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document" style="text-align:left;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Asignatura
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                              <div class="col-md-6 mb-3">
                                <label >Maxima capacidad</label>
                                <input class="form-control" type="number" min="0" id="max_capacidad" required=""/>
                            </div>
                               <div class="col-md-6 mb-3">
                                <label>Tipo de Asignatura</label>
                                <select class="custom-select d-block w-100" id="tipo_asignatura"  required="">
                                    
                                    <option  value="">Seleccione</option>
                                    <option  value="1">Común</option>
                                    <option  value="2">Electivo</option>
                                    <option  value="3">Diferenciado</option>
                                    <option  value="4">Taller</option>
                                </select>
                                <input type="hidden"  id="AsignaturaId" value="0" />
                             </div>
                             <div class="col-md-6 mb-3">
                                <label>Tipo de Calificación</label>
                                <select class="custom-select d-block w-100" id="tipo_calificacion"  required="">
                                    <option  value="">Seleccione</option>
                                    <option  value="1">Númerica</option>
                                    <option  value="2">Conceptual</option>
                                </select>
                             </div>
                             <div class="col-md-6 mb-3">
                                <label>Nombre</label>
                                <input type="text" class="form-control" id="nombre" name="nombre" required="">
                             </div>
                             <div class="col-md-6 mb-3">
                                <label>Código Ministerial</label>
                                <input type="text" class="form-control" id="cod_m"  required="">
                             </div>
                             <div class="col-md-6 mb-3">
                                 <div class="form-group">
                                      <label>¿Incide en el promedio?</label>
                                     <br />
                                     <div class="row">
                                         <div class="col-3">
                                                  <div class="custom-control custom-radio">
                                                    <input type="radio" class="custom-control-input" name="rdGroup2"  value="0" id="rd4" checked=""> <label class="custom-control-label" for="rd4">Si</label>
                                                  </div>
                                         </div>
                                         <div class="col-3">
                                              <div class="custom-control custom-radio">
                                                <input type="radio" class="custom-control-input" name="rdGroup2" value="1" id="rd5"> <label class="custom-control-label" for="rd5">No</label>
                                              </div>
                                         </div>
                                     </div>
                                 
                                     
          
                                </div>

                             </div>



                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>
       </div>

</asp:Content>

