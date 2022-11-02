<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Rol.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Rol" %>
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
    <script>
        $(document).ready(function () {
            function listar() {
                var ColegioID = sessionStorage.getItem('Colegio');
                $.ajax({
                    type: "POST",
                    url: '/Rol.asmx/LlenarTabla',
                    data: "{ColegioID:'" + ColegioID +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#mostrar").html(data.d);
                    },
                    error: function (err) { console.log("Error:" + err); },
                });
            }
            listar();

            $('#btnAgregar').click(function () {




                //if ($("#form_valid").valid() === false) {
                //    event.preventDefault();
                //    event.stopPropagation();
                //}
              
                var nombre = $('#rol').val();
                var ColegioID = sessionStorage.getItem('Colegio');
                var RolId = $("#PersonId").val();
                if (RolId >0 ) {
                    $.ajax({
                        type: "POST",
                        url: '/Rol.asmx/EditarRol',
                        data: "{nombre:'" + nombre +
                            "',ColegioID:'" + ColegioID +
                            "',RolId:'" + RolId +
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

                            $("#btnCancelar").click();
                            $('#rol').val("");
                            listar();
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }
                else {
                    $.ajax({
                        type: "POST",
                        url: '/Rol.asmx/IngresarRol',
                        data: "{nombre:'" + nombre +
                            "',ColegioID:'" + ColegioID +
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

                            $("#btnCancelar").click();
                            $('#rol').val("");
                            listar();
                        },
                        error: function (err) { console.log("Error:" + err); },
                    });

                }





            });


            $('#btnOpciones').click(function () {
                var arreglo = new Array();

                $('input:checkbox[name=opciones]:checked').each(function (element) {
                    var item = {};
                    item.valor = this.id;
                    arreglo.push(item);
                });


                const momentoComida = arreglo.map(function (comida) {
                    var data = comida.valor;
                    return data+"||";



                });


                var RolMenu = momentoComida.toString();

               var ID_ROL =  $("#RolId").val();

                        $.ajax({
                        type: "POST",
                        url: '/Rol.asmx/IngresarRolMenu',
                            data: "{RolMenu:'" + RolMenu +
                                "',ID_ROL:'" + ID_ROL +
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

                        },
                        error: function (err) { console.log("Error:" + err); },
                    });
              



            });

            $(document).on('click', '.btn_editar', function () {
         
                document.getElementById("exampleModalLabel").innerHTML = "Editar Rol";
                var PersonId = $(this).attr("id");
                //$("#rol").val($("#Nombre" + PersonId).html());
                var PersonId = document.getElementById("PersonId").value = PersonId;
                var values_d = $("#nombre_" + PersonId).val();
                $("#rol").val(values_d).html();



             
                $('#create').modal({
                    keyboard: true
                });


            });
            $(document).on('click', '.btn_eliminar', function () {
                var RolId = $(this).attr("id");
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
                                url: '/Rol.asmx/EliminarRol',
                                data: "{RolId:'" + RolId +
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

            $(document).on('click', '.btn_asignar', function () {
                var id = $(this).attr("id");
                $("#RolId").val(id);
                $.ajax({
                    type: "POST",
                    url: '/Rol.asmx/OpcionesMenu',
                    data: "{id:'" + id +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        
                        $("#row_asignar").html(data.d);
                        $.ajax({
                            type: "POST",
                            url: '/Rol.asmx/GetID',
                            data: "{id:'" + id +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                var rolID = data.d;
                                var rolStr = rolID.toString();
                                var rolSplit = rolStr.split("||");
                                for (var i = 0; i < rolSplit.length; i++) {
                                    $("#" + rolSplit[i]).attr("checked","checked");

                                }
                            },
                            error: function (err) { console.log("Error:" + err); },
                        });

                    },
                    error: function (err) { console.log("Error:" + err); },
                });



            });


        });
    </script><br /><br />                                <input type="hidden" value="0" id="PersonId" />
       <input type="hidden" value="0" id="RolId" />

        <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Rol</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-lg" data-target="#create" data-toggle="modal" type="button" id="btnIngresar">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo Rol
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
                    <h5 class="modal-title" id="exampleModalLabel">Nuevo Rol
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                           
                            <div class="col-md-6 mb-6">
                                <label>Nombre</label>
                                <input type="text" class="form-control" id="rol" name="tipo" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Prefijo. </div>--%>
                            </div>
                            
              
                        </div>
                        <div style="display:none;" id="asd"></div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal" type="button" id="btnCancelar">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>
       </div>
            <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="modal_asignar" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Opciones
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid2" name="form_valid">
                      <div class="row" id="row_asignar">
                       <%--     <div class="col-md-6 mb-3">
                                <label> Nombre</label>
                                <input type="text" class="form-control" id="nombre2" name="segundoNombre" required="">
                             </div>

                            <div class="col-md-6 mb-3">
                                <label>Icono</label>
                                <select class="custom-select d-block w-100" id="icono2" name="sexo_referencia_id" required="">
                                </select>
                            </div>--%>
                           
                          
                      </div>
                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelarOpciones" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnOpciones">Guardar</button>


                </div>

            </div>
        </div>

    </div>
   

</asp:Content>