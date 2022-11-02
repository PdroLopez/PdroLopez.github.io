<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConfiguracionCentral.aspx.vb" MasterPageFile="~/Inicio.Master"  Inherits="iEdeucaLCD.ConfiguracionCentral1" %>

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
        <script type="text/javascript">
     
            $(document).ready(function () {
                function listar() {
                    $.ajax({
                        type: "POST",
                        url: 'ConfiguracionCentral.asmx/GetData',
                        data: "{}",
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
                $(document).on('click', '.btn_editar', function () {

                    document.getElementById("exampleModalLabel").innerHTML = "Editar Configuración Central";
                    var PersonId = $(this).attr("id");
                    //$("#rol").val($("#Nombre" + PersonId).html());
                    var PersonId = document.getElementById("ConfiguracionCentralId").value = PersonId;
                    var nombre = $("#nombre_" + PersonId).val();
                    var codigo = $("#codigo_" + PersonId).val();

                    $("#nombre").val(nombre).html();
                    $("#codigo").val(codigo).html();




                    $('#create').modal({
                        keyboard: true
                    });


                });
                $('#btnAgregar').click(function () {

                    var codigo = $("#codigo").val();
                    var nombre = $("#nombre").val();
                    var ConfiguracionCentralId = $("#ConfiguracionCentralId").val();
                    if (ConfiguracionCentralId > 0) {
                        $.ajax({
                            type: "POST",
                            url: 'ConfiguracionCentral.asmx/EditarConfiguracionCentral',
                            data: "{codigo:'" + codigo +
                                "',nombre:'" + nombre +
                                "',ConfiguracionCentralId:'" + ConfiguracionCentralId +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                //alert(data.d);
                                Swal.fire({
                                    position: 'top-center',
                                    icon: 'success',
                                    title: data.d,
                                    showConfirmButton: false,
                                    timer: 1500
                                });
                                //$('#create').modal('hide');
                                $("#btnCancelar").click();

                                $("#nombre").val("");
                                $("#codigo").val("");
                                $("#ConfiguracionCentralId").val(0);
                                $.ajax({
                                    type: "POST",
                                    url: 'ConfiguracionCentral.asmx/GetData',
                                    data: "{}",
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
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });

                    }
                    else {
                        $.ajax({
                            type: "POST",
                            url: 'ConfiguracionCentral.asmx/AgregarConfiguracionCentral',
                            data: "{codigo:'" + codigo +
                                "',nombre:'" + nombre +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                //alert(data.d);
                                Swal.fire({
                                    position: 'top-center',
                                    icon: 'success',
                                    title: data.d,
                                    showConfirmButton: false,
                                    timer: 1500
                                });
                                //$('#create').modal('hide');
                                $("#btnCancelar").click();

                                $("#nombre").val("");
                                $("#codigo").val("");

                                $.ajax({
                                    type: "POST",
                                    url: 'ConfiguracionCentral.asmx/GetData',
                                    data: "{}",
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
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });

                    }



                  

                });


                $(document).on('click', '.btn_eliminar', function () {
                    var ConfiguracionCentralId = $(this).attr("id");
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
                                    url: '/ConfiguracionCentral.asmx/EliminarConfiguracionCentral',
                                    data: "{ConfiguracionCentralId:'" + ConfiguracionCentralId +
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


            });
        </script>
        <input type="hidden"  id="ConfiguracionCentralId" value="0"/>
        <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Configuración Central</h3>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-xl" data-target="#create" data-toggle="modal" type="button" id="btnIngresar">
                                    <i class="flaticon2-plus"></i>
                                    Nueva Configuración Central
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
                            <th>ID</th>
                            <th>Código</th>
                             <th>Nombre</th>
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
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Configuración Local
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                             <div class="col-md-6 mb-3">
                                <label>Código</label>
                                <input type="text" class="form-control" id="codigo" name="primerNombre" required="">
                            </div>
                             <div class="col-md-6 mb-3">
                                <label>Nombre  </label>
                                <input type="text"  class="form-control" id="nombre" name="primerNombre" required="">
                            </div>
                            <input type="hidden" value="0" id="ColegioId"/>
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
