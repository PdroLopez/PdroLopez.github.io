<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Colegio.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Persona" %>

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
            let base64String = "";
            $('input[type="file"]').change(function (e) {
                var path = (window.URL || window.webkitURL).createObjectURL($(this).prop("files")[0]);
                console.log('path', path);

            });
            //
            function listar() {
                $.ajax({
                    type: "POST",
                    url: 'Colegio.asmx/MostrarTabla',
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
            function limpiarCampos() {
                 $("#nombre").val('');
                 $("#nombre_corto").val('');
            }
            $(document).on('click', '.btn_editar', function () {
                limpiarCampos();
                document.getElementById("exampleModalLabel").innerHTML = "Editar Colegio";//Pendiente
                var Colegio = $(this).attr("id");
                var ColegioId = document.getElementById("ColegioId").value = Colegio;
                $("#nombre").val($("#FirstName" + ColegioId).html());
                $("#nombre_corto").val($("#LastName" + ColegioId).html());
                $.ajax({
                    type: "POST",
                    url: '/Colegio.asmx/SearchType',
                    data: "{ColegioId:'" + ColegioId +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    beforeSend: function () {
                        //aki usas el id de tus elementos para bloquearlos antes de hacer submit
                        document.getElementById("div_img").style.display = "block";
                        var div = document.getElementById("div_img")
                        div.innerHTML = "<h6>Espere un momento...</h6>";
                    },
                    success: function (data) {

                        var type = data.d;
                           $.ajax({
                                type: "POST",
                                url: '/Colegio.asmx/MostrarImagen',
                                data: "{ColegioId:'" + ColegioId +
                                    "',type:'" + type +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {
                                    document.getElementById("div_img").style.display = "block";
                                    $("#div_img").html(data.d);
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
            $('#btnIngresar').click(function () {
                limpiarCampos();
              
   
            });
     
        

            $('#btnAgregar').click(function () {
                if ($("#form_valid").valid() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                var insignia = "1c962b80-2e21-4ec6-8c35-7f1b927c5f67"   //$("#imagen").prop("files")[0].name;
                       var nombre = $("#nombre").val();
                    var nombre_corto = $("#nombre_corto").val();
                    var ColegioId = $("#ColegioId").val();
                   



                var formData = new FormData();
                var nombre_archivo = $("#imagen")[0].files[0].name;

                formData.append("fileName", $("#imagen")[0].files[0].name);
                formData.append("file", $("#imagen")[0].files[0]);
                formData.append("ColegioID", ColegioId);
                formData.append("nombre", nombre);
                formData.append("nombre_corto", nombre_corto);

                $.ajax({
                    type: "POST",
                    url: '/Colegio.asmx/UploadImage',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (responseFromServer) {
                        $("#btnCancelar").click();
                        listar();
                           //$.ajax({
                      //  type: "POST",
                      //  url: '/Colegio.asmx/IngresarColegio',
                      //  data: "{nombre:'" + nombre +
                      //      "',nombre_corto:'" + nombre_corto +
                      //      "',ColegioId:'" + ColegioId +
                      //      "',insignia:'" + insignia +
                      //      "'}",
                      //  contentType: "application/json",
                      //  datatype: "json",
                      //  success: function (responseFromServer) {
                      //      Swal.fire({
                      //          position: 'top-center',
                      //          icon: 'success',
                      //          title: responseFromServer.d,
                      //          showConfirmButton: false,
                      //          timer: 1500
                      //      })
                      //      $("#btnCancelar").click();
                      //      listar();

                      //  },
                      //  error: function (err) {
                      //      console.log("Error:" + err);
                      //  },
                      //});
                        //$.ajax({
                        //    type: "POST",
                        //    url: '/Colegio.asmx/GuardarImagen',
                        //    data: "{nombre_archivo:'" + nombre_archivo +
                        //        "',ColegioId:'" + ColegioId +
                        //        "'}",
                        //    contentType: "application/json",
                        //    datatype: "json",
                        //    success: function (responseFromServer) {
                              
                        //     //   $("#btnCancelar").click();
                        //        listar();

                        //    },
                        //    error: function (err) {
                        //        console.log("Error:" + err);
                        //    },
                        //});

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });



                //var insignia = document.getElementById("imagen").value;
                //var file = document.querySelector(
                //    'input[type=file]')['files'][0];
                //var reader = new FileReader();
                //reader.onload = function () {
                //    base64String = reader.result.replace("data:", "")
                //        .replace(/^.+,/, "");

                //    imageBase64Stringsep = base64String;

                //    // alert(imageBase64Stringsep);
                //    //console.log(base64String);
                //    var nombre = $("#nombre").val();
                //    var nombre_corto = $("#nombre_corto").val();
                //    var ColegioId = $("#ColegioId").val();
                //    var insignia = base64String;
                //    $("#imag").attr("src", "data:image/png;base64," + base64String)
                //    var imagen = $("#imagen").prop("files")[0];
                //    //var dataForm = new FormData();
                //    //dataForm.append("imagen", imagen);
                //    var insignia = $("#ruta").val();
                //    let formData = new FormData();
                //    var d = $('#imagen')[0].files[0];

                //    formData.append('imagen', d);
                //    console.log(formData);
              
                //    //$.ajax({
                //    //    type: "POST",
                //    //    url: '/Colegio.asmx/IngresarColegio',
                //    //    data: "{nombre:'" + nombre +
                //    //        "',nombre_corto:'" + nombre_corto +
                //    //        "',ColegioId:'" + ColegioId +
                //    //        "',insignia:'" + insignia +
                //    //        "'}",
                //    //    contentType: "application/json",
                //    //    datatype: "json",
                //    //    success: function (responseFromServer) {
                //    //        Swal.fire({
                //    //            position: 'top-center',
                //    //            icon: 'success',
                //    //            title: responseFromServer.d,
                //    //            showConfirmButton: false,
                //    //            timer: 1500
                //    //        })
                //    //        $("#btnCancelar").click();
                //    //        listar();

                //    //    },
                //    //    error: function (err) {
                //    //        console.log("Error:" + err);
                //    //    },
                //    //});

                //}
                //reader.readAsDataURL(file);








                //$.ajax({
                //        type: "POST",
                //        url: '/Colegio.asmx/IngresarColegio',
                //        data: "{ColegioId:'" + ColegioId +
                //            "',nombre:'" + nombre +
                //            "',nombre_corto:'" + nombre_corto +
                //            "',tipo_escuela:'" + tipo_escuela +
                //            "',administrativo_f:'" + administrativo_f +
                //            "',fines_lucro:'" + fines_lucro +
                //            "',tiempo_aprendizaje:'" + tiempo_aprendizaje +
                //            "',designacion_p:'" + designacion_p +
                //            "',anio_reconocimiento:'" + anio_reconocimiento +
                //            "',nombre_agencia:'" + nombre_agencia +
                //            "',inscripcion_abierta:'" + inscripcion_abierta +
                //            "',internet:'" + internet +
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
                //            listar();
                //        },
                //    error: function (err) {
                //        console.log("Error:" + err);
                //    },
                //});

                
           








            });


            $(document).on('click', '.btn_eliminar', function () {
                var ColegioId = $(this).attr("id");

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
                                url: '/Colegio.asmx/EliminarColegio',
                                data: "{ColegioId:'" + ColegioId +
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

       

        });
    </script>
    <div class="card card-custom"> <input type="hidden" id="ruta" value="0" />
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Colegio</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnIngresar">
                                    <i class="flaticon2-plus"></i>
                                    Nueva Colegio
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
                            <th>Nombre</th>
                             <th>Nombre en Corto</th>
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
                    <h5 class="modal-title" id="exampleModalLabel">Nuevo Colegio
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">

                    <form class="needs-validation was-validated" method="post"  runat="server"  novalidate="" action="Colegio.asmx/IngresarColegio" id="form_valid" name="form_valid" enctype="multipart/form-data">
                        <div class="row">
                             <div class="col-md-6 mb-3">
                                <label>Nombre</label>
                                <input type="text" class="form-control" id="nombre" name="primerNombre" required="">
                            </div>

                             <div class="col-md-6 mb-3">
                                <label>Nombre corto  </label>
                                <input type="text" placeholder="ej:RBD1234567" class="form-control" id="nombre_corto" name="primerNombre" required="">
                            </div>
                            <div class="col-md-6 mb-3">
                                <div class="form-group">
                                      <label class="form-control-label" for="tfInvalid">Insignía del Colegio</label>
                                      <div class="custom-file">
                                        <input type="file"  class="custom-file-input is-invalid" name="imagen" id="imagen" accept=".jpg, .png, .gif"> <label class="custom-file-label" for="tfInvalid">Choose file</label>
                                  </div>  
                               </div>

                            </div>
                              <div class="col-md-6 mb-3" id="div_img" style="display:none;">
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
