<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Nivel.aspx.vb" MasterPageFile="~/Inicio.Master"  Inherits="iEdeucaLCD.Nivel" %>
<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
<script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="sweetalert2.min.js"></script>
<link rel="stylesheet" href="sweetalert2.min.css">
<script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
<script>
    $(document).ready(function () {
        //Tabla 
        $('#tabla_id').DataTable(
        );
        $('#btnAgregar').click(function () {




            //if ($("#form_valid").valid() === false) {
            //    event.preventDefault();
            //    event.stopPropagation();
            //}

            var nivelEducacion = $('#nivel').val();
            var tipo_organizacion = 40;
            $.ajax({
                type: "POST", 
                url: '/Organizacion.asmx/IngresarNivelEducacion',
                data: "{nivelEducacion:'" + nivelEducacion +
                    "',tipo_organizacion:'" + tipo_organizacion +
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
                    listar();
                },
                error: function (err) { console.log("Error:" + err); },
            });





        });
        function listar() {
            var tipo_organizacion = 40;
            $.ajax({
                type: "POST",
                url: 'Organizacion.asmx/MostrarNivelEducacion',
                data: "{tipo_organizacion:'" + tipo_organizacion +
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
        listar();
    });
</script>
    <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Nivel de Educación</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-lg" data-target="#create" data-toggle="modal" type="button" id="btnIngresar">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo Nivel de Educación
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
                            <th>Modalidad</th>
                            <th>Tipo de Organización</th>                               
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
                    <h5 class="modal-title" id="exampleModalLabel">Nuevo Nivel de Educación
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                           
                            <div class="col-md-12 mb-12">
                                <label>Nivel de Educación</label>
                                <input type="text" class="form-control" id="nivel" name="tipo" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Prefijo. </div>--%>
                            </div>
                            
                
                        -
                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>
       </div>

</asp:Content>

