<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Ambito.aspx.vb"  MasterPageFile="~/Inicio.Master"   Inherits="iEdeucaLCD.Ambito" %>
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
<script  type="text/javascript">
    $(document).ready(function () {
        //Tabla 
     
        function listar() {
            $.ajax({
                type: "POST",
                url: 'Ambito.asmx/GetData',
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

            document.getElementById("exampleModalLabel").innerHTML = "Editar Ambito";
            var PersonId = $(this).attr("id");
            //$("#rol").val($("#Nombre" + PersonId).html());
            var PersonId = document.getElementById("AmbitoId").value = PersonId;
            var nombre = $("#nombre_" + PersonId).val();
            $("#nombre").val(nombre).html();




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
                            url: '/Ambito.asmx/EliminarAmbito',
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

        $('#btnAgregar').click(function () {
       
            var nombre = $("#nombre").val();
            var AmbitoId = $("#AmbitoId").val();
            if (AmbitoId > 0) {
                $.ajax({
                    type: "POST",
                    url: 'Ambito.asmx/EditarAmbito',
                    data: "{nombre:'" + nombre +
                        "',AmbitoId:'" + AmbitoId +
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
                        $("#AmbitoId").val(0);
                        $.ajax({
                            type: "POST",
                            url: 'Ambito.asmx/GetData',
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
                    url: 'Ambito.asmx/IngresarAmbito',
                    data: "{nombre:'" + nombre +
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
                        $.ajax({
                            type: "POST",
                            url: 'Ambito.asmx/GetData',
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

    });
</script>
     <input type="hidden" value="0" id="AmbitoId" />
  <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Ambito</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnAbrirModal">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo Ambito
                                </button>
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
                            <th>Nombre</th>                            
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
                    <h5 class="modal-title" id="exampleModalLabel">Nuevo Ambito
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                              <div class="col-md-6 mb-3">
                                <label >Nombre </label>
                                <input class="form-control" type="text"  id="nombre" required=""/>
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

        </div>

</asp:Content>
