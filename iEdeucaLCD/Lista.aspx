<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Lista.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Lista" %>

<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <meta http-equiv="content-type" content="text/plain; charset=UTF-8"/>

    <script src="jquery-3.6.0.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%--<script src="sweetalert2.min.js"></script>--%>
    <%--<link rel="stylesheet" href="sweetalert2.min.css">--%>
    <script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
     <script src="https://unpkg.com/xlsx@0.16.9/dist/xlsx.full.min.js"></script>
    <script src="https://unpkg.com/file-saverjs@latest/FileSaver.min.js"></script>
    <script src="https://unpkg.com/tableexport@latest/dist/js/tableexport.min.js"></script>
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
            var ColegioID = sessionStorage.getItem('Colegio');

            //Tabla 
            //function llenarTablaInicial(){
            //       $.ajax({
            //        type: "POST",
            //        url: 'Notas.asmx/Tabla',
            //        data: "{}",
            //        contentType: "application/json",
            //        datatype: "json",
            //        success: function (data) {
            //            //alert(data.d);
            //            $('#cabecera_tabla').html(data.d);

            //        },
            //        error: function (err) {
            //            console.log("Error:" + err);
            //        },
            //    });
                  
            //}
            //llenarTablaInicial();
            $('#btnOrdenar').click(function () {
             
                var curso = $('#curso').val();
                 const swalWithBootstrapButtons = Swal.mixin({
                    customClass: {
                        confirmButton: 'btn btn-success',
                        cancelButton: 'btn btn-danger'
                    },
                    buttonsStyling: false
                })

                swalWithBootstrapButtons.fire({
                    title: '¿Está seguro de reasignar el número de lista a cada estudiante?',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Aceptar',
                    cancelButtonText: 'Cancelar',
                    reverseButtons: true
                }).then((result) => {
                    if (result.isConfirmed) {
                        swalWithBootstrapButtons.fire(
                            $.ajax({
                                type: "POST",
                                url: 'Lista.asmx/Ordenar',
                                data: "{curso:'" + curso +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {
                                    $('#mostrar').html(data.d);
                                      swal.fire(
                                        "¡Exito!",
                                        "La Acción fue realizada con exito",
                                        "success"
                                    )
                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
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

            //$('#btnExportar').click(function () {
             


            //});


            function llenarcmb() {
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
            llenarcmb();
            //function tablaData(curso, asignatura) {
            //    var h = "<th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;' ></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th><th style='border-right: 2px  solid black;'></th>"

            //       $.ajax({
            //        type: "POST",
            //        url: '/Notas.asmx/tablaData',
            //        data: "{curso:'" + curso +
            //            "',asignatura:'" + asignatura +
            //            "'}",
            //        contentType: "application/json",
            //        datatype: "json",
            //        success: function (data) {
            //          $('#cabecera_tabla').html(data.d + h);
            //        },
            //        error: function (err) { console.log("Error:" + err); },
            //    });
            //}
            //function getEstudiante(curso) {

            //    $.ajax({
            //        type: "POST",
            //        url: 'Notas.asmx/GetEstudiante',
            //        data: "{curso:'" + curso +
            //            "'}",
            //        contentType: "application/json",
            //        datatype: "json",
            //        success: function (data) {
                      
            //            var htm = data.d;
            //             for (var i = 0; i < 2; i++) {
            //                   //htm += "<td>Test Row Append <BR> </td>"
            //                   $('#mostrar').html(htm);
            //             }
                      
            //         ////////$("<tr><td>Test Row Append</td></tr>").appendTo("#tabla_id>tbody")
            //       },
            //        error: function (err) {
            //            console.log("Error:" + err);
            //        },
                    
            //    });
 
             
            //}
              $(document).on("click", ".arriba,.abajo", function(){
      
                  var row = $(this).parents("tr:last");
                    if ($(this).is(".arriba")) {
                        row.insertBefore(row.prev());
                    }
                    else {
                        row.insertAfter(row.next());
                    }
            });
        
            $('#curso').on('change', function () {
                var curso = $('#curso').val();
                $.ajax({
                    type: "POST",
                    url: 'Lista.asmx/GetProfesor',
                    data: "{curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        //$('#proe').html(data.d);
                        //document.getElementById("proe").style.display = "block";
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: 'Lista.asmx/GetEstudiante',
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
            //function agh()
            //{
            //      document.getElementById("tabla_id").insertRow(-1).innerHTML = '<td></td>';
            //}
          

            //$('#asignatura').on('change', function () {
            //    var curso = $('#curso').val();
            //    var asignatura = $('#asignatura').val();
            //    getEstudiante(curso);
            //    tablaData(curso, asignatura);

             
            //});
          

        });
    </script>
    <br /><br />
    <div class="container">
        <div class="row">
               <div class="col-md-6 mb-3">
                     <label>Curso</label>
                     <select class="custom-select d-block w-100" id="curso">
                     </select>
               </div>
            <div class="col-md-6 mb-3" id="proe" style="display: none;">
            </div>
           
        </div>
    </div>
        <br /><br />
    <br /><br />
     <div class="container">
         <div class="row">
             <div class="col-3">
                    <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnOrdenar">  
                      Ordenar Alfabéticamente 
                    </button>
             </div>
               <div class="col-3">
                    <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" onclick="tableToExcel('tabla','datos');" type="button" id="btnExportar">  
                      Exportar Excel 
                    </button>
                    <script>
                        var tableToExcel = (function () {
                            var uri = 'data:application/vnd.ms-excel;base64,'
                                , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><meta http-equiv="content-type" content="application/vnd.ms-excel; charset=UTF-8"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
                                , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
                                , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
                            return function (table, name) {
                                if (!table.nodeType) table = document.getElementById(table)
                                var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
                                window.location.href = uri + base64(format(template, ctx))
                            }
                        })()
                    </script>
             </div>
         </div>
      
    </div>
       <br /><br />
    <br /><br />
    <div class="container" style="overflow-x: auto;">
        <table class="table table-dark " id="tabla" style="border:1px solid black;" border="1">
            <thead>
                <tr>
                    <th style="width:20px;" >N°</th>
                    <th >Nombre Completo</th>
                    <th >Acci&oacute;n</th>


                </tr>
<%--                <tr>
                    <th style="width:20px; border-right: 2px  solid black;" >N°</th>
                    <th style="border-right: 2px  solid black;">Nombre</th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th  style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;" ></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                    <th style="border-right: 2px  solid black;"></th>
                </tr>--%>
            </thead>
            <tbody id="mostrar">
            </tbody>
        </table>
    </div>
 







</asp:Content>
