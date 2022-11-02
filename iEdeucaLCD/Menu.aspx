<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb"  MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Menu" %>
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
                    url: '/Menu.asmx/SelectIcon',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#icono").html(data.d);
                        $("#icono2").html(data.d);

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

                $.ajax({
                    type: "POST",
                    url: '/Menu.asmx/SelectPadre',
                    data: "{ColegioID:'" + ColegioID +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#padre").html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });


                $.ajax({
                    type: "POST",
                    url: '/Menu.asmx/MostrarSubMenu',
                    data: "{}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#mostrar").html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
               
            }
            listar();
            function limpiar() {
                $('#nombre').val("");
                $('#icono').val("");
                ('#orden').val("");
                $('#url').val("");
               
            }
            $('#btnAgregarSubMenu').click(function () {
                var padre = $("#padre").val();
                var nombre = $('#nombre').val();
                var icons = $('#icono').val();
                var url = $('#url').val();
                var orden = $('#orden').val();
                var contacto_emergencia = "";
                var ColegioID = sessionStorage.getItem('Colegio');
           
                if ($('[name="estado_ciudania_us_id"]').is(':checked')) {
                    contacto_emergencia = 0;
                }
                else {
                    contacto_emergencia = 1;
                }
                if (padre == "") {
                    padre = 0;
                }

                $.ajax({
                    type: "POST",
                    url: '/Menu.asmx/AgregarSubMenu',
                    data: "{nombre:'" + nombre +
                        "',icons:'" + icons +
                        "',padre:'" + padre +
                        "',url:'" + url +
                        "',orden:'" + orden +
                        "',contacto_emergencia:'" + contacto_emergencia +
                        "',ColegioID:'" + ColegioID +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //btnCancelarNivelUno
                        $('#nombre').val("");
                        $('#icono').val("");
                       $ ('#orden').val("");
                        $('#url').val("");
                        $.ajax({
                            type: "POST",
                            url: '/Menu.asmx/MostrarSubMenu',
                            data: "{}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#mostrar").html(data.d);
                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });

                        var ColegioID = sessionStorage.getItem('Colegio');

                        $.ajax({
                            type: "POST",
                            url: '/Menu.asmx/SelectPadre',
                            data: "{ColegioID:'" + ColegioID +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#padre").html(data.d);
                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });


                        swal.fire(
                            "¡Exito!",
                            data.d,
                            "success"
                        )
                        $("#btnCancelarSubMenu").click();
                        limpiar();
                        contacto_emergencia = "";

                    },
                    error: function (err) { console.log("Error:" + err); },
                });


                //$.ajax({
                //    type: "POST",
                //    url: '/Menu.asmx/MostrarSubMenu',
                //    data: "{padre:'" + padre +
                //        "'}",
                //    contentType: "application/json",
                //    datatype: "json",
                //    success: function (data) {
                //        $("#mostrar").html(data.d);
                //        $("#btnCancelarSubMenu").click();
                //        limpiar();
                //        listar();
                //    },
                //    error: function (err) {
                //        console.log("Error:" + err);
                //    },
                //});


            });


            $('#select_padre').on('change', function () {
                var padre = $("#select_padre").val();
                $.ajax({
                    type: "POST",
                    url: '/Menu.asmx/MostrarSubMenu',
                    data: "{padre:'" + padre +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#mostrar").html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                document.getElementById("subMenus").style.display = "block";

            });


        });
    </script>                            


        <div class="card card-custom"  id="subMenus">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Menú</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-lg" data-target="#AgregarSubMenu" data-toggle="modal" type="button" id="btnIngresarSubMenu">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo  Menú
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


           <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="AgregarSubMenu" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Nuevo  Menú
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid2" name="form_valid">
                      <div class="row">
                           <div class="col-md-6 mb-3">
                                <label> Padre</label>
                                <select class="custom-select d-block w-100" id="padre" name="" required="">
                                </select>
                             </div>
                            <div class="col-md-6 mb-3">
                                <label> Nombre</label>
                                <input type="text" class="form-control" id="nombre" name="segundoNombre" required="">
                             </div>

                            <div class="col-md-6 mb-3">
                                <label>Icono</label>
                                <select class="custom-select d-block w-100" id="icono" name="sexo_referencia_id" required="">
                                </select>
                            </div>
                          <div class="col-md-6 mb-3">
                                <label> URL</label>
                                <input type="text" class="form-control" id="url" name="segundoNombre" required="">
                             </div>
                             <div class="col-md-6 mb-3">
                                <label> Orden</label>
                                <input type="number" class="form-control" id="orden" name="segundoNombre" required="">
                             </div>
                            <div class="col-md-6 mb-3">
                                 <label>Vigencia </label>
                                <div class="list-group-item d-flex justify-content-between align-items-center">
                                  <label class="switcher-control switcher-control-lg">
                                      <input type="checkbox"  name="estado_ciudania_us_id"   class="switcher-input" value="0" checked="">
                                      <span class="switcher-indicator">
                                      </span> 
                                      <span type="button" name="si_no" class="switcher-label-on" onclick="us_si()"  value="1">Si</span> 
                                      <span type="button" name="si_no" class="switcher-label-off"  onclick="us_no()" value="0">No</span>
                                  </label> <!-- /.switcher-control -->
                                </div>         
                             </div>

                           
                          
                      </div>
                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" id="btnCancelarSubMenu" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregarSubMenu">Guardar</button>


                </div>

            </div>
        </div>

    </div>


</asp:Content>