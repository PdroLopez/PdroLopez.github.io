<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Inicio.aspx.vb" MasterPageFile="~/Inicio.Master"  Inherits="iEdeucaLCD.Inicio" %>

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
    <script type="text/javascript">

  
        if (sessionStorage.getItem('UsuarioLogueado') != null) {


        }
        else {
            window.location.replace("Login.aspx");


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
        function myfunction() {
            var token = sessionStorage.getItem('UsuarioLogueado');

            $.ajax({
                type: "POST",
                url: '/Login.asmx/DiferentesRoles',
                data: "{token:'" + token +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {


                    if (data.d == '6') {
                        document.getElementById("asignatura_li").style.display = "none";
                        $("#anotacion_li").hide();
                        $("#colegio_li").hide();
                        $("#electivo_li").hide();
                        $("#curso_li").hide();
                        $("#anotacion_li").hide();
                        $("#asistencia_li").hide();
                        $("#atraso_li").hide();
                        $("#ev_conceptual_li").hide();
                        $("#notas_li").hide();
                        $("#lista_li").hide();
                        $("#leccionario_li").hide();
                    }
                    sessionStorage.setItem('Rol', data.d);


                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
        }
        myfunction();
        //Tabla 
        var rol = sessionStorage.getItem('Rol');
        var token = sessionStorage.getItem('UsuarioLogueado');
        $.ajax({
            type: "POST",
            url: '/Inicio.asmx/Menu',
            data: "{rol:'" + rol +
                "'}",
            contentType: "application/json",
            datatype: "json",
            success: function (data) {

                $("#nav_menu").html(data.d);


            },
            error: function (err) {
                console.log("Error:" + err);
            },
        });


                
   


    </script>
          

</asp:Content>
