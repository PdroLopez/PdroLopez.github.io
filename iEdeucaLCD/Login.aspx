<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Login.aspx.vb"  MasterPageFile="~/Login.Master" Inherits="iEdeucaLCD.Login1" %>
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

             $('#btnIngresar').click(function () {
                 var user = $("#usuario").val();
                 var contra = $("#contra").val();

                 $.ajax({
                     type: "POST",
                     url: '/Login.asmx/Ingresar',
                     data: "{user:'" + user +
                         "',contra:'" + contra +
                         "'}",
                     contentType: "application/json",
                     datatype: "json",
                     success: function (responseFromServer) {

                         var token = responseFromServer.d;
                         
                         sessionStorage.setItem('UsuarioLogueado', token);
                  

                         let now = new Date();
                         var fecha = now.toLocaleString();

                         $.ajax({
                             type: "POST",
                             url: '/Inicio.asmx/CountColegio',
                             data: "{user:'" + user +
                                 "',contra:'" + contra +
                                 "'}",
                             contentType: "application/json",
                             datatype: "json",
                             success: function (data) {

                                 var colegioBackend = data.d;
                                 if (colegioBackend > 1) {
                                     document.getElementById("principal").style.display = "none";
                                     document.getElementById("div_colegio").style.display = "block";
                                     $.ajax({
                                         type: "POST",
                                         url: '/Inicio.asmx/GetColegio',
                                         data: "{user:'" + user +
                                             "',contra:'" + contra +
                                             "'}",
                                         contentType: "application/json",
                                         datatype: "json",
                                         success: function (data) {
                                             $("#mostrarColegio").html(data.d);
                                            
                                         },
                                         error: function (err) {
                                             console.log("Error:" + err);
                                         },
                                     });
                                 }
                                 else {

                                     $.ajax({
                                         type: "POST",
                                         url: '/Login.asmx/TraerDatos',
                                         data: "{user:'" + user +
                                             "',contra:'" + contra +
                                             "'}",
                                         contentType: "application/json",
                                         datatype: "json",
                                         success: function (data) {

                                             var colegioBackend = data.d;

                                             sessionStorage.setItem('Colegio', colegioBackend);
                                             window.location.replace("Inicio.aspx");






                                         },
                                         error: function (err) { console.log("Error:" + err); },
                                     });
                                 }






                             },
                             error: function (err) { console.log("Error:" + err); },
                         });

                         if (token != null) {
                               $.ajax({
                                         type: "POST",
                                         url: '/Login.asmx/InsertToken',
                                         data: "{user:'" + user +
                                             "',contra:'" + contra +
                                             "',token:'" + token +
                                             "',fecha:'" + fecha +
                                           "'}",
                                         contentType: "application/json",
                                         datatype: "json",
                                         success: function (data) {

                                         },
                                         error: function (err) {
                                             console.log("Error:" + err);
                                         },
                                     });
                         }
                         else {
                             alert("Usuario y Contraseña invalidos... Intente nuevamente");
                         }



                      
                       

                       

                     },
                     error: function (err) { console.log("Error:" + err); },
                 });



               

             });

             $(document).on('click', '.btnColegio', function () {
                 var user = $("#usuario").val();
                 var contra = $("#contra").val();
                 var id = $(this).attr("id");
                 sessionStorage.setItem('Colegio', id);
                 document.getElementById("div_colegio").style.display = "none";
                 document.getElementById("div_rol").style.display = "block";


                 $.ajax({
                     type: "POST",
                     url: '/Inicio.asmx/GetRol',
                     data: "{user:'" + user +
                         "',contra:'" + contra +
                         "',id:'" + id +
                         "'}",
                     contentType: "application/json",
                     datatype: "json",
                     success: function (data) {
                         $("#mostrarRol").html(data.d);

                     },
                     error: function (err) {
                         console.log("Error:" + err);
                     },
                 });

                // window.location.replace("Inicio.aspx");


                 //alert(PersonTelephoneId.split(",")[0]);
             });


             $(document).on('click', '.btnRol', function () {

                 var id = $(this).attr("id");
               
                 sessionStorage.setItem('Rol', id);

              

                  window.location.replace("Inicio.aspx");


                 //alert(PersonTelephoneId.split(",")[0]);
             });


         });

     </script>


            <main class="auth" id="principal">
          <header id="auth-header" class="auth-header" style="background-image: url(assets/images/illustration/fondoxd.jpg);">
              <h1>
                  <img src="assets/images/illustration/logo1.png" style="width: 200px; height:auto" />
                  <span class="sr-only">Sign In</span>
              </h1>
          </header>
         
        

          <form class="auth-form">
              <p style="text-align: center;"> ¿No tienes una cuenta? <a href="auth-signup.html">Crear una</a> </p>
              <div class="form-group">
                  <div class="form-label-group">
                      <input type="text" id="usuario" class="form-control" placeholder="Usuario" autofocus=""> <label for="inputUser">Usuario</label>
                  </div>
              </div>
              <input type="hidden" id="btn_E" value="0" />
              <div class="form-group">
                  <div class="form-label-group">
                      <input type="password" id="contra" class="form-control" placeholder="Contraseña"> <label for="inputPassword">Contraseña</label> </div>
              </div>
              <div class="form-group">
                  <input class="btn btn-lg btn-primary btn-block" id="btnIngresar" value="Ingresar" />
              </div>

              <div class="form-group text-center">
                  <div class="custom-control custom-control-inline custom-checkbox">
                      <input type="checkbox" class="custom-control-input" id="remember-me"> <label class="custom-control-label" for="remember-me">Recuerdame</label>
                  </div>
              </div>
              <!-- /.form-group -->
              <!-- recovery links -->
              <div class="text-center pt-3">
                  <a href="auth-recovery-username.html" class="link">¿Olvidaste tu Usuario?</a> <span class="mx-2">·</span> <a href="auth-recovery-password.html" class="link">¿Olvidaste tu contraseña?</a>
              </div>
              <!-- /recovery links -->
          </form>
          <footer class="auth-footer"> © 2021 Todos los derechos reservados. <a href="#">Privacidad</a> y <a href="#">Termino y Condiciones</a>
          </footer>
        </main>
                <div class="card card-custom" id="div_colegio" style="display:none;">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="card-title">
                                <h3 class="card-label">Seleccione un Colegio</h3>
                            </div>
                        </div>


                       
                    </div>
                </div>
            </div>
            </div>
                 <div class="col-md-6" id="mostrarColegio">
                          <%--  <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" type="button" id="btnAbrirModal">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo Ambito
                                </button>
                            </div>--%>
                        </div>
                </div>
                    <div class="card card-custom" id="div_rol" style="display:none;">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="card-title">
                                <h3 class="card-label">Seleccione un Rol</h3>
                            </div>
                        </div>


                       
                    </div>
                </div>
            </div>
            </div>
                 <div class="col-md-6" id="mostrarRol">
                          <%--  <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" type="button" id="btnAbrirModal">
                                    <i class="flaticon2-plus"></i>
                                    Nuevo Ambito
                                </button>
                            </div>--%>
                        </div>
                </div>

</asp:Content>