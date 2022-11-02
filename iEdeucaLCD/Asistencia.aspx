<%@ Page Language="vb" AutoEventWireup="true" MasterPageFile="~/Inicio.Master" CodeBehind="Asistencia.aspx.vb" Inherits="iEdeucaLCD.Asistencia" %>

<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%--<script src="sweetalert2.min.js"></script>--%>
    <%--<link rel="stylesheet" href="sweetalert2.min.css">--%>
    <script src="jquery-3.6.0.js"></script>
    <script src="//cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
    <script>
  

        function PresenteIndividual(id) {
            //var id = $(this).attr("id");
            let i = +$("#" + id).data("count");
            var fecha = $("#fecha").val();
            var orp = $("#" + id).attr("orp");
            var cordenadas = $("#" + id).attr("id");
            var AsistenciaEstado = 1;
            var RoleAttenceId = $("#" + id).attr("RoleEventId");



            $("#" + id).text("+ " + (++i));
            $("#" + id).data("count", i);
            if (i == 1) {
            
                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/InsertAsistencia',
                    data: "{fecha:'" + fecha +
                        "',orp:'" + orp +
                        "',AsistenciaEstado:'" + AsistenciaEstado +
                        "',cordenadas:'" + cordenadas +
                        "',RoleAttenceId:'" + RoleAttenceId +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {

                        console.log(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                $("#" + id).html("<p style='text-align:center;'>P</p>");
                $("#" + id).css("background-color", "rgba(78, 223, 59, 0.8)");
            }
            if (i == 2) {
                AsistenciaEstado = 2;
                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/UpdateAsistencia',
                    data: "{fecha:'" + fecha +
                        "',orp:'" + orp +
                        "',AsistenciaEstado:'" + AsistenciaEstado +
                        "',cordenadas:'" + cordenadas +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {

                        console.log(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                })
                $("#" + id).html("<p  style='text-align:center;'>A</p>");
                $("#" + id).css("background-color", "rgba(242, 53, 53, 0.8)");
            }
            if (i == 3) {
                AsistenciaEstado = 3;

                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/UpdateAsistencia',
                    data: "{fecha:'" + fecha +
                        "',orp:'" + orp +
                        "',AsistenciaEstado:'" + AsistenciaEstado +
                        "',cordenadas:'" + cordenadas +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {

                        console.log(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                })
                $("#" + id).html("<p  style='text-align:center;'>R</p>");
                $("#" + id).css("background-color", "rgba(236, 245, 68, 0.8)");
            }
            if (i >= 3) {
                $("#" + id).data("count", 0);
            }
          
            id = 0;

        }

      
        $(document).ready(function () {
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

       
            $.ajax({
                type: "POST",
                url: 'Asignatura.asmx/SelectCurso',
                data: "{ColegioID:'" + ColegioID +
                    "'}",
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    //alert(data.d);
                    $('#curso_dos').html(data.d);

                },
                error: function (err) {
                    console.log("Error:" + err);
                },
            });
            $(document).on('click', '.btnPresente', function () {
                var nFilas = $("#tabla_id tr").length - 1;
                //var nColumnas = $("#tabla_id tr:last td").length;
                var columna = $(this).attr("columna");
                var nColumnas = $("#tabla_id tr:last td").length - 1;
                var arreglo = new Array();
                var arreglo2 = new Array();
                var orp = $(".btn_td_" + columna).attr("orp");
                var AsistenciaEstado = 1;
              
              

                $(".btn_td_" + columna).each(function (element) {
                    var item = {};
                    item.id = this.id;
                    item.RoleEvent1 = $(this).attr("RoleEventId");
                    item.orp = $(this).attr("orp");
                    item.PersonId = $(this).attr("PersonId");

                    arreglo.push(item);
                });


                const momentoComida = arreglo.map(function (comida) {
                    var cord = comida.id;
                    var role = comida.RoleEvent1;
                    var orp1 = comida.orp;
                    var p = comida.PersonId;


                    return cord+":@"+role+":@"+orp1+":@"+p+":@||";

                  

                });
                var cordenadas = momentoComida.toString();

                $(".btn_td_" + columna).html("<p style='text-align:center;'>P</p>");

                $(".btn_td_" + columna).css("background-color", "rgba(78, 223, 59, 0.8)");



      
                var fecha = $("#fecha").val();
                var AsistenciaEstado = 1;
                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/InsertAsistenciaAll',
                    data: "{fecha:'" + fecha +
                        "',AsistenciaEstado:'" + AsistenciaEstado +
                        "',cordenadas:'" + cordenadas +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        console.log(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
            });
            $(document).on('click', '.btnValidarCod', function () {

                const otp = $("#otp").val();
                var ORP = $(this).attr("data");
                var a = otp.toString();
                const rut = "19100388-8";
                var roleEventId = $("#btnFirmaEdit").val();
                const toISOStringWithTimezone = date => {
                    const tzOffset = -date.getTimezoneOffset();
                    const diff = tzOffset >= 0 ? '+' : '-';
                    const pad = n => `${Math.floor(Math.abs(n))}`.padStart(2, '0');
                    return date.getFullYear() +
                        '-' + pad(date.getMonth() + 1) +
                        '-' + pad(date.getDate()) +
                        'T' + pad(date.getHours()) +
                        ':' + pad(date.getMinutes()) +
                        ':' + pad(date.getSeconds()) +
                        diff + pad(tzOffset / 60) +
                        ':' + pad(tzOffset % 60);
                };


                var fecha = toISOStringWithTimezone(new Date());
                const url = 'https://claveunicagobcl.firebaseapp.com/verifyOTPFromSimple?rut='+rut+'&otp='+a+'&DateWithTimeZone='+fecha+'';


              
                fetch(url)
                    .then((resp) => resp.json())
                    .then(function (data) {
                        var cond = data[0].OTPVERIFY;
                        if (cond == true ) {
                            var CourseSectionScheduleId = $("#CourseSectionScheduleId").val();
                            var curso = $("#curso").val();
                           var firma_ok =  $("#Firma_Ok").val();

                            var fecha = $("#fecha").val();
                            var otp2 =   otp.toString();
                            $.ajax({
                                type: "POST",
                                url: 'Asistencia.asmx/InsertFirma',
                                data: "{roleEventId:'" + roleEventId +
                                    "',fecha:'" + fecha +
                                    "',otp2:'" + otp2 +
                                    "',ORP:'" + ORP +
                                    "',CourseSectionScheduleId:'" + CourseSectionScheduleId +
                                    "',firma_ok:'" + firma_ok +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {

                                    $("#otp").val("");

                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
                            })
                        }
                        else {
                            alert("La Clave alettoria es incorrecta");
                        }

                    })
                    .catch(function (error) {
                        console.log(error);
                    });












            });



            $(document).on('click', '.btnAusente', function () {


                var nFilas = $("#tabla_id tr").length - 1;
                //var nColumnas = $("#tabla_id tr:last td").length;
                var columna = $(this).attr("columna");
                var nColumnas = $("#tabla_id tr:last td").length - 1;
                var arreglo = new Array();
                var arreglo2 = new Array();
                var orp = $(".btn_td_" + columna).attr("orp");
                var AsistenciaEstado = 2;



                $(".btn_td_" + columna).each(function (element) {
                    var item = {};
                    item.id = this.id;
                    item.RoleEvent1 = $(this).attr("RoleEventId");
                    item.orp = $(this).attr("orp");
                    item.PersonId = $(this).attr("PersonId");

                    arreglo.push(item);
                });


                const momentoComida = arreglo.map(function (comida) {
                    var cord = comida.id;
                    var role = comida.RoleEvent1;
                    var orp1 = comida.orp;
                    var p = comida.PersonId;


                    return cord + ":@" + role + ":@" + orp1 + ":@" + p + ":@||";



                });
                var cordenadas = momentoComida.toString();


                $(".btn_td_" + columna).html("<p  style='text-align:center;'>A</p>");

                $(".btn_td_" + columna).css("background-color", "rgba(242, 53, 53, 0.8)");


             
                var fecha = $("#fecha").val();
                var AsistenciaEstado = 2;
          


                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/InsertAsistenciaAll',
                    data: "{fecha:'" + fecha +
                        "',AsistenciaEstado:'" + AsistenciaEstado +
                        "',cordenadas:'" + cordenadas +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        console.log(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });






              
            });

            $(document).on('click', '.btnR', function () {

                var nFilas = $("#tabla_id tr").length - 1;
                //var nColumnas = $("#tabla_id tr:last td").length;
                var columna = $(this).attr("columna");
                var nColumnas = $("#tabla_id tr:last td").length - 1;
                var arreglo = new Array();
                var arreglo2 = new Array();
                var orp = $(".btn_td_" + columna).attr("orp");
                var AsistenciaEstado = 3;



                $(".btn_td_" + columna).each(function (element) {
                    var item = {};
                    item.id = this.id;
                    item.RoleEvent1 = $(this).attr("RoleEventId");
                    item.orp = $(this).attr("orp");
                    item.PersonId = $(this).attr("PersonId");

                    arreglo.push(item);
                });


                const momentoComida = arreglo.map(function (comida) {
                    var cord = comida.id;
                    var role = comida.RoleEvent1;
                    var orp1 = comida.orp;
                    var p = comida.PersonId;


                    return cord + ":@" + role + ":@" + orp1 + ":@" + p + ":@||";



                });
                var cordenadas = momentoComida.toString();


                $(".btn_td_" + columna).html("<p  style='text-align:center;'>R</p>");

                $(".btn_td_" + columna).css("background-color", "rgba(236, 245, 68, 0.8)");


             
                var fecha = $("#fecha").val();
                var AsistenciaEstado = 3;
                //var nFilas = $("#tabla_id tr").length - 1;
                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/InsertAsistenciaAll',
                    data: "{fecha:'" + fecha +
                        "',AsistenciaEstado:'" + AsistenciaEstado +
                        "',cordenadas:'" + cordenadas +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        console.log(data.d);
                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });


           
              
            });

            $(document).on('click', '.btn_td', function () {


                var id = $(this).attr("id");
                console.log(id);
                //let i = +$("#" + id).data("count");
                //$(this).text("+ " + (++i));
                //$(this).data("count", i);
                //if (i == 1) {
                //    $("#" + id).html("<p style='text-align:center;'>P</p>");
                //    $("#" + id).css("background-color", "rgba(78, 223, 59, 0.8)");
                //}
                //if (i == 2) {
                //    $("#" + id).html("<p  style='text-align:center;'>A</p>");
                //    $("#" + id).css("background-color", "rgba(242, 53, 53, 0.8)");
                //}
                //if (i == 3) {
                //    $("#" + id).html("<p  style='text-align:center;'>R</p>");
                //    $("#" + id).css("background-color", "rgba(236, 245, 68, 0.8)");
                //}
                //if (i >= 3) {
                //    $(this).data("count", 0);
                //}
                //var fecha = $("#fecha").val();
                //var orp = $(this).attr("orp");

                //$.ajax({
                //    type: "POST",
                //    url: 'Asistencia.asmx/InsertAsistencia',
                //    data: "{fecha:'" + fecha +
                //        "',orp:'" + orp +
                //        "'}",
                //    contentType: "application/json",
                //    datatype: "json",
                //    success: function (data) {

                //        console.log(data.d);
                //    },
                //    error: function (err) {
                //        console.log("Error:" + err);
                //    },
                //});

            });

            $(document).on('click', '.btnFirma', function () {
                var id = $(this).attr("data");
                var arr = new Array();
                var columna = $(this).attr("columna");
                var btn_td = $(".btn_td_" + columna).attr("RoleEventId");
                var CSS = $(this).attr("CSS");
                var firma_ok = $(this).attr("firmado_ok");
                $("#CourseSectionScheduleId").val(CSS);

                $(".btn_td_"+columna).each(function (element) {
                    var item = {};
                    item.roleEvent1 = $(this).attr("RoleEventId");
                    arr.push(item);
               

                });
                if (firma_ok == 0 ) {
                    $("#guardarXD").html("Guardar");
                    $("#guardarXD").css("background-color", 'blue');
                }
                if (firma_ok == 1) {
                    
                    $("#guardarXD").html("Anular Firma");
                    $("#guardarXD").css("background-color",'red');

                }

                const momentoComida = arr.map(function (comida) {
                    var id = comida.roleEvent1;
                    
                    return id;

                    //    id + "," + cond + ";";
                });
                var momentoComidastr = momentoComida.toString()+"||";
                
                $("#btnFirmaEdit").val(momentoComidastr);
                var firma_a = $("#btnFirmaEdit").val();
                         $.ajax({
                                type: "POST",
                                url: 'Asistencia.asmx/FirmaDocente',
                                data: "{id:'" + id +
                                 "',firma_ok:'" + firma_ok +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (data) {
                                    $("#datos_docente").html(data.d);
                                    $('#create').modal({
                                        keyboard: true
                                    });

                                },
                                error: function (err) {
                                    console.log("Error:" + err);
                                },
                         });
                firma_ok = 0;

            });
            $('#fecha_mes').on('change', function () {
                var mes = $("#fecha_mes").val();

                var mes_final = mes + "-3";
                var mes_string = mes.toString();
                var mes_split = mes_string.split("-");
                var mes_number = mes_split[1];
                var curso_dos = $("#curso_dos").val();
                $.ajax({
                    type: "POST",
                    url: '/Asistencia.asmx/CabeceraMensual',
                    data: "{mes_final:'" + mes_final +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#cabecera_dos").html(data.d);
                        //var nColumnas = $("#tabla_mensual tr:last th").length - 2;
                 
                        var n = $("#cont_dias").val();
                        var cont = $("#cont_cabebeceraMensual").val();
                        var n2 = n - 1;
                        var arrfilaColumna = mes_final.split("-");
                        var año = arrfilaColumna[0];
                        var mes = arrfilaColumna[1];
                        var diasMes = new Date(año, mes, 0).getDate();
                        var fechaArray = new Array();
                        var diasSemana = ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'];
                        for (var dia = 1; dia <= diasMes; dia++) {
                            var indice = new Date(año, mes -1 , dia ).getDay();
                            $("#" + dia).html(diasSemana[indice] + "<br/>" + dia);
                        }

                        $.ajax({
                            type: "POST",
                            url: '/Asistencia.asmx/GetNameMensual',
                            data: "{curso_dos:'" + curso_dos +
                                "',mes_final:'" + mes_final +
                                "',mes_number:'" + mes_number +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#tbody_dos").html(data.d);
                                a(curso_dos, mes_number);
                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });

                    },
                    error: function (err) { console.log("Error:" + err); },
                });
                var nColumnas = $("#cabecera_dos td:last td").length;

              


            });


            $('#fecha').on('change', function () {
                var fecha = $("#fecha").val();
                var curso = $("#curso").val();
                $.ajax({
                    type: "POST",
                    url: 'Asistencia.asmx/Cabecera',
                    data: "{fecha:'" + fecha +
                        "',curso:'" + curso +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        if (data.d == '') {
                            $("#arriba_tabla").html("Sin Datos...");
                        }
                        else {
                            $("#cabecera").html(data.d);
                            $("#fecha").html($("#diaNumber").val());

                            $("#arriba_tabla").html($("#dia").val() + "  " + $("#diaNumber").val() + "  " + "de " + " " + $("#mes").val() + " " + "del año  " + $("#anio").val());
                            var cont = $("#cont_cabebecera").val();

                            $.ajax({
                                type: "POST",
                                url: 'Asistencia.asmx/GetNameEstudiante',
                                data: "{cont:'" + cont +
                                    "',curso:'" + curso +
                                    "'}",
                                contentType: "application/json",
                                datatype: "json",
                                success: function (da) {
                                    $("#mostrar").html(da.d);
                                    $.ajax({
                                        type: "POST",
                                        url: 'Asistencia.asmx/ObtenerCordenadas',
                                        data: "{curso:'" + curso +
                                            "',fecha:'" + fecha +
                                            "'}",
                                        contentType: "application/json",
                                        datatype: "json",
                                        success: function (data) {

                                            //console.log(data.d);

                                            $("#div_guardarCordenadas").html(data.d);
                                            var arr43 = new Array();


                                            $(".btn_cordenadas").each(function (element) {
                                                var item = {};
                                                item.RoleStatusId = $(this).attr("condicion");
                                                item.coordenadas = $(this).attr("coordenadas");
                                                item.id = this.value;
                                                arr43.push(item);




                                            });
                                            const momentoComida = arr43.map(function (comida) {
                                                var id1 = comida.RoleStatusId;
                                                var id2 = comida.coordenadas;
                                                var id3 = comida.id;
                                                return id3 + "@@" + id2 + "@@" + id1 + "||";

                                                //    id + "," + cond + ";";
                                            });

                                            var arrString = momentoComida.toString();

                                            var arrSplit = arrString.split("||");
                                            for (var i = 0; i < arrSplit.length; i++) {
                                                var text = arrSplit[i];
                                                var result = text.replace(",", "");
                                                var arrSplit2 = result.split("@@");

                                                for (var j = 0; j < arrSplit2.length; j++) {
                                                    if (arrSplit2[2] == 1) {
                                                        $("#" + arrSplit2[1]).html("<p style='text-align:center;'>P</p>");
                                                        $("#" + arrSplit2[1]).css("background-color", "rgba(78, 223, 59, 0.8)");
                                                    }
                                                    if (arrSplit2[2] == 2) {


                                                        $("#" + arrSplit2[1]).html("<p  style='text-align:center;'>A</p>");
                                                        $("#" + arrSplit2[1]).css("background-color", "rgba(242, 53, 53, 0.8)");
                                                    }
                                                    if (arrSplit2[2] == 3) {
                                                        $("#" + arrSplit2[1]).html("<p  style='text-align:center;'>R</p>");
                                                        $("#" + arrSplit2[1]).css("background-color", "rgba(236, 245, 68, 0.8)");
                                                    }
                                                    $("#" + arrSplit2[1]).attr("RoleEventId", arrSplit2[0]);
                                                }
                                            }
                                      



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

                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });
                var mes_final = $("#fecha").val();
                var curso_dos = $("#curso").val();

                $("#curso_dos").val(curso_dos);
                var mes_string = mes_final.toString();
                var mes_split = mes_string.split("-");

                var mes_number = mes_split[1];
              
                var asd = mes_split[0];
            //   var b = mes_split[1];
                var ds = asd + "-" + mes_number;
                $("#fecha_mes").val(ds);

                $.ajax({
                    type: "POST",
                    url: '/Asistencia.asmx/CabeceraMensual',
                    data: "{mes_final:'" + mes_final +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                        $("#cabecera_dos").html(data.d);
                        //var nColumnas = $("#tabla_mensual tr:last th").length - 2;

                        var n = $("#cont_dias").val();
                        var cont = $("#cont_cabebeceraMensual").val();
                        var n2 = n - 1;
                        var arrfilaColumna = mes_final.split("-");
                        var año = arrfilaColumna[0];
                        var mes = arrfilaColumna[1];
                        var diasMes = new Date(año, mes, 0).getDate();
                        var fechaArray = new Array();
                        var diasSemana = ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'];
                        for (var dia = 1; dia <= diasMes; dia++) {
                            var indice = new Date(año, mes - 1, dia).getDay();
                            $("#" + dia).html(diasSemana[indice] + "<br/>" + dia);
                        }

                        $.ajax({
                            type: "POST",
                            url: '/Asistencia.asmx/GetNameMensual',
                            data: "{curso_dos:'" + curso_dos +
                                "',mes_final:'" + mes_final +
                                "',mes_number:'" + mes_number +
                                "'}",
                            contentType: "application/json",
                            datatype: "json",
                            success: function (data) {
                                $("#tbody_dos").html(data.d);
                                
                                a(curso_dos, mes_number);
                            },
                            error: function (err) {
                                console.log("Error:" + err);
                            },
                        });

                    },
                    error: function (err) { console.log("Error:" + err); },
                });

                //$("#tbody_dos").html("");
                //$("#cabecera_dos").html("");
                //$("#curso_dos").val("");
                //$("#fecha_mes").val("");



            });

            $('#curso_dos').on('change', function () {
         
                
                //$("#fecha_mes").val("");
                //$("#cabecera_dos").html("");
              //  $("#tbody_dos").html("");

                
                

            });
            function a(curso_dos, mes_number) {
                $.ajax({
                    type: "POST",
                    url: '/Asistencia.asmx/AsistenciaMensualDos',
                    data: "{curso_dos:'" + curso_dos +
                        "',mes_number:'" + mes_number +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {

                        if (data.d == 2 ) {
                            $("#tbody_dos").html("No hay Registro para esa fecha...");
                        }
                        else {
                            var arr = new Array();
                            var arr2 = new Array();
                            $("#asdc").html(data.d);
                            $(".input_blade").each(function (element) {
                                var item = {};
                                var item2 = {};
                                item.idInput = this.value;
                                item.condicion2 = $(this).attr("condicion");
                                item.roleEvent1 = $(this).attr("RoleEventId");
                                item.fecha = $(this).attr("fecha");
                                item.ORP1 = $(this).attr("ORP");
                                arr.push(item);



                                item2.idInput = this.value;
                                item2.condicion2 = $(this).attr("condicion");

                                arr2.push(item2);

                            });
                            const momentoComida = arr.map(function (comida) {
                                var id = comida.idInput;
                                var cond = comida.condicion2;
                                var roleEvent2 = comida.roleEvent1;
                                var fechaxd = comida.fecha;
                                var orp3 = comida.ORP1;
                                return id + ";" + cond + ";" + roleEvent2 + ";" + fechaxd + ";" + orp3 + "||";

                                //    id + "," + cond + ";";
                            });


                            const momentoComida2 = arr2.map(function (comida) {


                                var id = comida.idInput;
                                var cond = comida.condicion2;
                                var fechaxd = comida.fecha;
                                return id + "@@" + cond + "@@" + fechaxd + "@@||";                                    //    id + "," + cond + ";";
                            });


                            var ìdNotaStr = momentoComida.toString();
                            var arrSplit = ìdNotaStr.split("||");
                            var momento2 = momentoComida2.toString();
                            var momentoxd = momento2.split("||");

                            for (var i = 0; i < arrSplit.length; i++) {

                                let text = arrSplit[i];
                                let result = text.replace(",", "");
                                let result2 = result.split(";");
                                for (var j = 0; j < result2.length; j++) {
                                    let text = result2[3];
                                    let fecha = text.substring(0, 10);
                                    if (result2[1] == 1) {
                                        $("#icon_" + result2[0]).html("<i class='fa fa-circle' style='font-size:10px;'>");

                                    }
                                    if (result2[1] == 2) {
                                        $("#icon_" + result2[0]).html("<i class='fa fa-times' style='font-size:10px;'>");

                                    }
                                    $('#' + result2[0]).attr('RoleEventId', result2[2]);
                                    $('#' + result2[0]).attr('fecha', fecha);


                                }

                            }

                        }
                  







                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                });

            }


            $('#curso').on('change', function () {

            

                $("#cabecera").html("");
                $("#mostrar").html("");
                $("#arriba_tabla").html("");
                

            });


            $(document).on('click', '.btn_td_mensual', function () {

                var id = $(this).attr("id");
                var RoleEventId = $(this).attr("roleeventid");
                let i = +$("#" + id).data("count");
                console.log($(this).text("+ " + (++i)));
                console.log($(this).data("count", i));
                var strString = id.toString();
                var strSPlit = strString.split("_");
                var dia = strSPlit[0];
                var orp = strSPlit[1];
                var mes = $("#fecha_mes").val();
                if (i == 1) {
                    var condicion = 1;
                    $("#" + id).html("<i class='fa fa-circle' style='font-size:10px;'>");
                    if (RoleEventId == 'undefined') {
                        RoleEventId = 0;

                    }
                    $.ajax({
                        type: "POST",
                        url: 'Asistencia.asmx/UpdateAsistenciaMensual',
                        data: "{dia:'" + dia +
                            "',orp:'" + orp +
                            "',condicion:'" + condicion +
                            "',mes:'" + mes +
                            "',RoleEventId:'" + RoleEventId +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (data) {
                            console.log(data.d);

                


                        },
                        error: function (err) {
                            console.log("Error:" + err);
                        },
                    });


                }
                else if (i == 2) {
                    var condicion = 2;
                    $("#" + id).html("<i class='fa fa-times' style='font-size:10px;'>");
                    if (RoleEventId == undefined) {
                        RoleEventId = 0;

                    }
                    $.ajax({
                        type: "POST",
                        url: 'Asistencia.asmx/UpdateAsistenciaMensual',
                        data: "{dia:'" + dia +
                            "',orp:'" + orp +
                            "',condicion:'" + condicion +
                            "',mes:'" + mes +
                            "',RoleEventId:'" + RoleEventId +
                            "'}",
                        contentType: "application/json",
                        datatype: "json",
                        success: function (data) {

                            console.log(data.d);


                        },
                        error: function (err) {
                            console.log("Error:" + err);
                        },
                    });
                    RoleEventId = 0;


                }
             //else    if (i == 3) {
             //       $("#" + id).html("<i class='fa fa-times' style='font-size:10px;'>");
             //       var condicion = 2;
             //       $.ajax({
             //           type: "POST",
             //           url: 'Asistencia.asmx/UpdateAsistenciaMensual',
             //           data: "{dia:'" + dia +
             //               "',orp:'" + orp +
             //               "',condicion:'" + condicion +
             //               "',mes:'" + mes +
             //               "'}",
             //           contentType: "application/json",
             //           datatype: "json",
             //           success: function (data) {

             //               console.log(data.d);


             //           },
             //           error: function (err) {
             //               console.log("Error:" + err);
             //           },
             //       });
             //   }

                if (i > 2) {
                    $(this).data("count", 0);
                }
                if (i >= 2) {
                    console.log($(this).data("count", 0));

                }


            });

            $(document).on('click', '.btn_agregar', function () {
               
                var CourseSectionScheduleId = $("#CourseSectionScheduleId").val();
              // alert(CSS);
                $.ajax({
                    type: "POST",
                    url: '/Asistencia.asmx/AnularFirma',
                     data: "{CourseSectionScheduleId:'" + CourseSectionScheduleId +
                        "'}",
                    contentType: "application/json",
                    datatype: "json",
                    success: function (data) {
                       


                    },
                    error: function (err) {
                        console.log("Error:" + err);
                    },
                })
        

            });

            //function cerrarSeccion() {
            //    var token = sessionStorage.getItem('UsuarioLogueado');
            //    $.ajax({
            //        type: "POST",
            //        url: '/Login.asmx/DeleteToken',
            //        data: "{token:'" + token +
            //            "'}",
            //        contentType: "application/json",
            //        datatype: "json",
            //        success: function (data) {
            //            sessionStorage.removeItem('UsuarioLogueado');
            //            window.location.reload();


            //        },
            //        error: function (err) {
            //            console.log("Error:" + err);
            //        },
            //    })
            //};
        });
    </script>

    <%-- <style>
        p>i{ 
           font-size:5px;
           height:100PX;
        }
        #nombres{
           width:100%;
        }
        cabecera_nombre{
           color:red;
        }
    </style>


    --%>
    <div id="principal" class="col-lg-12">
        <!-- .card -->
        <div class="card" style="height: 600px;">
            <!-- .card-header -->
            <div class="card-header">
                <ul class="nav nav-tabs card-header-tabs">
                    <li class="nav-item">
                        <a class="nav-link show active" data-toggle="tab" href="#card-home">Asistencia Diaria</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " data-toggle="tab" href="#card-profile">Asistencia Mensual</a>
                    </li>

                </ul>
            </div>
            <div style="display:none;" id="div_h"></div>
            <!-- /.card-header -->
            <!-- .card-body -->
            <input   type="hidden" id="fecha_todos" value="0" />
            <div class="card-body" style="overflow-x: auto;">
                <!-- .tab-content -->
                <div id="myTabCard" class="tab-content">
                    <div class="tab-pane fade active show" id="card-home">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label>Curso</label>
                                    <select class="custom-select d-block w-100" id="curso">
                                    </select>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label>Fecha</label>
                                    <input type="date" class="form-control" id="fecha" name="fecha" required="" >
                                </div>
                            </div>

                        </div>
                        <br />
                        <div id="container_tabla" class="container">
                            <div class="card card-fluid">
                                <div class="table-responsive">
                                    <h3 id="arriba_tabla"></h3>
                                    <div id="div_tabla">
                                    </div>
                                    <table class="table table-striped" id="tabla_id">
                                        <tr style="background-color: rgba(142, 142, 142, 0.8);" id="cabecera">
                                        </tr>
                                        <tbody id="mostrar">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="tab-pane fade " id="card-profile">

                        <div class="container">
                            <div class="row">
                                <div class="col-2 col-md-2">
                                    <br>
                                    <h2><i class="fas fa-book"></i></h2>
                                </div>
                                <div class="col-3 col-md-3">
                                    <label>Curso</label>
                                    <select class="custom-select d-block w-100" id="curso_dos" required="">
                                        <option value="">Seleccione...</option>
                                        <option value="0">8° Basico A</option>
                                        <option value="1">7° Basico A</option>
                                    </select>
                                </div>
                                <div class="col-3 col-md-3">
                                    <label>Consultar Mes</label>
                                    <input type="month" class="form-control" id="fecha_mes" name="fecha" required="">
                                    <input type="hidden" id="CourseSectionScheduleId" value="0" />
                                </div>
                            </div>
                        </div>
                        <br>
                        <%--    <div class="container" style="overflow-x: auto;">
 
        <table  class="table table-striped"  id="tabla_mensual">
                <tr id="cabecera_dos">
               
                </tr>
            <tbody id="tbody_dos">
            </tbody>
        </table>
              
                     



       
    </div>--%>

                            <!-- .card-header -->

                                <!-- .table -->
                        <div class="col-md-12 col-xl-12">
                                                            <div class="table-responsive-xl">
                                  <table class="table" id="tabla_mensual">
                                    <!-- thead -->
                                    <thead>
                                        <tr id="cabecera_dos">
                                        </tr>
                                    </thead>
                                  
                                    <tbody id="tbody_dos">
                                    </tbody>
                                    <!-- /tbody -->
                                </table>
                                </div>

                            <div  id="asdc"></div>
                            <div style="display:none;" id="asdc2"></div>
                            <input type="hidden" id="btnFirmaEdit" value="0" />
                               <input type="hidden" id="Firma_Ok" value="0" />

                            
                        </div>
                             
                                <!-- /.table -->
                            <!-- /.table-responsive -->



                    </div>
                </div>
                <!-- /.tab-content -->
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
        <!-- .card -->
    </div>

    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Nota
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>

                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">

                        <%--                        <div id="datos_docente">--%>
                            <table class="table table-striped- table-bordered table-hover table-checkable">
                                <thead>
                                    <tr>
                                    <th>Nombre
                                    </th>
                                    <th>Cargo
                                    </th>
                                    <th>Estado
                                    </th>
                                    <th>Fecha
                                    </th>
                                    <th>Firma
                                    </th>
                                      </tr>
                                </thead>
                                <tbody id="datos_docente">
                                </tbody>
                            </table>





                        <%--                        </div>--%>
                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>

                    <div id="div_guardarCordenadas" style="display:none;">

                    </div>
                    <button class="btn btn-primary btn_agregar" type="button" id="guardarXD">Guardar</button>


                </div>

            </div>
        </div>

    </div>



</asp:Content>
