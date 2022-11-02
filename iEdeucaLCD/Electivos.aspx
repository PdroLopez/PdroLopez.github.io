<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Electivos.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Persona" %>

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
            function llenarTablas(curso,asignatura)
            {
                $.ajax({
                    type: "POST",
                    url: 'Electivos.asmx/GetEstudiantes',
                    data: "{asignatura:'" + asignatura +
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
                $.ajax({
                    type: "POST",
                    url: 'Electivos.asmx/AsignaturaElectivas',
                    data: "{asignatura:'" + asignatura +
                        "',curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                      $('#tabla_dos').html(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },

                });
            }
            function llenarCmb() {
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
            llenarCmb();
            $('#curso').on('change', function () {
                var curso = $('#curso').val();
                //getEstudiante(curso);
                $.ajax({
                    type: "POST",
                    url: 'Electivos.asmx/GetAsignatura',
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
            $('#asignatura').on('change', function () {
                var curso = $('#curso').val();
                var asignatura = $('#asignatura').val();
                llenarTablas(curso, asignatura);
                //getEstudiante(curso);
              
            });
            function limpiar() {
                $('input:checkbox').removeAttr('checked');

            }
            $('#btnAgregar').on('click', function () {

                //alert($('#id_estudiantes_hidden').val());
                var arrTodo = new Array();
                /*Agrupamos todos los input con name=cbxEstudiante*/
                $('input[name="nombre_estudiante"]').each(function (element) {
                    var item = {};
                    item.id = this.value;
                    item.status = this.checked;
                    if (item.status == true) {
                        arrTodo.push(item);

                    }
                });
            

                const momentoComida = arrTodo.map(function (comida) {
                    return comida.id;
                });
                var id_e = momentoComida.toString();

                $('#id_estudiantes_hidden').val(id_e +',');

                var estudiantes = $('#id_estudiantes_hidden').val() +"||";
                var asignatura = $('#asignatura').val();
                var curso = $('#curso').val();

                $.ajax({
                    type: "POST",
                    url: '/Electivos.asmx/IngresarElectivos',
                    data: "{estudiantes:'" + estudiantes +
                        "',asignatura:'" + asignatura +
                        "',curso:'" + curso +
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
                        llenarTablas(curso,asignatura);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });



                



            

            });
            $('#btnQuitar').on('click', function () {

                var arrTodo = new Array();
                $('input[name="nombre_estudiante"]').each(function (element) {
                    var item = {};
                    item.id = this.value;
                    item.status = this.checked;
                    if (item.status == true) {
                        arrTodo.push(item);

                    }
                });


                const momentoComida = arrTodo.map(function (comida) {
                    return comida.id;
                });
                var id_e = momentoComida.toString();

                $('#id_estudiantes_hidden').val(id_e + ',');

                var estudiantes = $('#id_estudiantes_hidden').val()+"||";
                var asignatura = $('#asignatura').val();
                var curso = $('#curso').val();

                $.ajax({
                    type: "POST",
                    url: '/Electivos.asmx/QuitarElectivos',
                    data: "{estudiantes:'" + estudiantes +
                        "',asignatura:'" + asignatura +
                        "',curso:'" + curso +
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
                        llenarTablas(curso, asignatura);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });









            });

        });
    </script>
    <br />
                <h2 style="text-align:center;">Asignación Electivos y Diferenciados</h2>

    <div class="container-fluid-lg">
        <div class="row">
             <div class="col-md-6 mb-3">
                   <label>Curso</label>
                   <select class="custom-select d-block w-100" id="curso" name="" required="">
                   </select>
             </div>
               <div class="col-md-6 mb-3">
                   <label>Asignatura</label>
                   <select class="custom-select d-block w-100" id="asignatura" name="" required="">
                   </select>
            </div>
        </div>
    </div>  


    <div class="container-fluid-lg">
        <div class="row">
             <div class="col-md-4 mb-3">
               <table class="table table-dark" id="tabla_id" style="float:left;">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                        </tr>
                    </thead>
                    <tbody id="mostrar" >
                        <%--    <tr>
                             <td>
                                   
								Pedro Jose Ricardo Lopez Ayala
                             </td>
                         </tr>--%>
                    </tbody>
                </table>
             </div>
               <div class="col-md-2 mb-3">
                   <br /><br />
                 	<button type="button" id="btnAgregar" class="btn btn-secondary"> <i  type="button" class="fas fa-arrow-right"> </i>  Agregar </button>
                   <br />  <br />
				   <button type="button"id="btnQuitar" class="btn btn-secondary"> <i class="fas fa-arrow-left"></i> Quitar </button> 
                   <input type="hidden" id="id_estudiantes_hidden"  value=""/>
              </div>
              <div class="col-md-4 mb-3">
                    <table class="table table-dark"  style="float:right;" id="">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                        </tr>
                    </thead>
                    <tbody id="tabla_dos">
                   
                    </tbody>
                </table>
              </div>
        </div>
    </div>  




</asp:Content>
