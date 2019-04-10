<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CSSContent" runat="server">
    <!-- BEGIN GLOBAL MANDATORY STYLES -->

    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="<%:ViewBag.Ruta_app%>assets/global/css/components.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/themes/grey.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
</asp:Content>
<asp:Content ContentPlaceHolderID="NombreUsuario" runat="server">
    <%:ViewBag.NombreUsuario%>
</asp:Content>

<asp:Content ContentPlaceHolderID="Menu" runat="server">
    <li>
        <a href="javascript:;">
            <i class="fa fa-money"></i>
            <span class="title">Comisiones
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/EstadoCuenta">
                    <i class="fa fa-file"></i>
                    Estado de Cuenta (Historico de Pagos)
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/Genera_ReporteSemanal">
                    <i class="fa fa-check-square"></i>
                    Reporte Semanal de pagos
                </a>
            </li>
        </ul>
    </li>
    <li>
        <a href="javascript:;">
            <i class="fa fa-users"></i>
            <span class="title">Clientes
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="#">
                    <i class="fa fa-user"></i>
                    Buscar Cliente (información general de un cliente en especifico)
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/Activos">
                    <i class="fa fa-suitcase"></i>
                    Clientes activos
                </a>
            </li>
        </ul>
    </li>
    <li>
        <a href="<%:ViewBag.Ruta_app%>Asesor/Contratos">
            <i class="fa fa-file"></i>
            <span class="title">Contratos
            </span>
        </a>
    </li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inicio>Asesores>Contratos</h2>
    <br />
    <form method="post" id="forma">
        <input type="text" name="nombrecliente" placeholder="Nombre del Cliente (O vacío)" id="nombrecliente" class="form-control" />
        <br />
        <%Response.Write(ViewBag.selFracc)%>
        <div id="DivCarga" style="display: none">
            <img src="<%:ViewBag.Ruta_app%>assets/admin/layout/img/loading-spinner-blue.gif" />Cargando datos espere...
        </div>
        <br />
        <div id="DivSelManzana">
        </div>
        <br />
        <div id="DivSelTerreno">
        </div>
        <div id="DivCantidadAhorro">
        </div>
        <div id="DivPromocion">
        </div>
        <br />
        <div id="DivPromocionContra">
        </div>
        <br />
        <div id="DivBonos" name="DivBonos">
        </div>
        <%Response.Write(ViewBag.Bono)%>
        <br />
        <%Response.Write(ViewBag.TipoCredito)%>
        <br />
        <div id="DivTraje" style="display: none">
            <strong>¿El cliente es sorteado? (traje a la medida):</strong>
            <br />
            <select name="cb_sorteado" id="cb_sorteado" required="required" class="form-control">
                <option value="1" selected="selected">Sí</option>
                <option value="2">No</option>
            </select>
        </div>

        <br />
        <%Response.Write(ViewBag.admopc)%>
        <br />
        <input type="text" name="mAdicional" placeholder="Cantidad Metros adicional o de Terreno" class="form-control" required="required" />
        <div id="camposContado">
        </div>
        <br />
        <input type="button" value="Generar Contrato" onclick="CargarContrato()" class="btn btn-xl green" />
        <div id="DivCargaContrato" style="display: none">
            <img src="<%:ViewBag.Ruta_app%>assets/admin/layout/img/loading-spinner-blue.gif" />Generando su contrato espere (1min apx)...
        </div>
    </form>
</asp:Content>
<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="JavaScriptContent">
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="<%:ViewBag.Ruta_app%>assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/pages/scripts/charts.js"></script>

    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Layout.init(); // init current layout

        });
    </script>
    <script src="<%:ViewBag.Ruta_app%>assets/scripts/core/app.js"></script>
    <script type="text/javascript">
        function CargarContrato() {

            if (ValidaFormulario() == true) {
                document.getElementById("DivCargaContrato").style.display = "initial";
                document.getElementById("forma").submit();

            } else {
                alert("Estimado asesor, te recordamos que todos los contratos de contado deben tener nombre del cliente, y lo has dejado vacío, por favor captura el nombre completo de tu cliente para para continuar. ");

            }



        }
        function ValidaFormulario() {
            var TCredito = document.getElementById("selCredito").value;
            var nombreCliente = document.getElementById("nombrecliente").value;
            if (TCredito == 6) {
                if (nombreCliente == "" || nombreCliente == "undefined") {
                    return false
                } else {
                    return true
                }
            };

            return true
        };

        function FovissteCredito() {
            var TCredito = document.getElementById("selCredito").value;

            if (TCredito == 2) {
                $("#DivTraje").show();

            } else {
                $("#DivTraje").hide();
            };

        };

        function CambioSeleccionFracc() {
            ActivaBonos();
            DesactivaTipoPago();
            ActivaAhorro();
            cargaselManzana();
            //ActivaPromociones();


        };
        function CambioSeleccionSmza() {
            DesactivaTipoPago();
            cargaTerreno();
            ActivaPromociones();
            ActualizaComboTipoCredito();
            // ActivaPromociones_contrato();
        };
        function DesactivaTipoPago() {
            var e = $("#selFracc").val();

            if (e == '890') {
                $("#selCredito").hide();
                $("#selPromocion").hide();
                $('#selBono').hide();
            } else {
                $("#selCredito").show();
                $("#selPromocion").show();
                $('#selBono').show();
            };

        }

        <%-- function ActivaPromociones() {
            var Fracc = document.getElementById("selFracc").value;
            var supermza;
               
            if (Fracc == '465' || Fracc == '730' || Fracc=='716') {
                
                supermza = document.getElementById("selManzana").value;               

            } else {
                supermza='Sin Escoger'
            };

            if (Fracc == '730') {
                supermza = 'VENET';
            };
         
            var options =
         {
             type: "post",
             url: "<%:Url.Action("Crea_Promocion")%>",
             data: { CC: Fracc, smza: supermza },
             success: function (msg) {
                 $("#DivPromocion").html(msg);
             }
         };
            $.ajax(options);
        };--%>
        function ActivaPromociones() {
            var Fracc = document.getElementById("selFracc").value;
            var supermza = document.getElementById("selManzana").value;
            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_Promocion")%>",
                data: { CC: Fracc, smza: supermza },
                success: function (msg) {
                    $("#DivPromocion").html(msg);
                }
            };
            $.ajax(options);
        };

        function ActivaBonos() {
            var Fracc = document.getElementById("selFracc").value;
            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_comboBono")%>",
                data: { CC: Fracc },
                success: function (msg) {
                    $("#DivBonos").html(msg);
                }
            };
            $.ajax(options);
        };


        function ActivaPromociones_contrato() {
            var Fracc = document.getElementById("selFracc").value;
            var supermza = document.getElementById("selManzana").value;
            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_Promocion_contrato")%>",
                data: { CC: Fracc, smza: supermza },
                success: function (msg) {
                    $("#DivPromocionContra").html(msg);
                }
            };
            $.ajax(options);
        };

        function ActualizaComboTipoCredito() {
            var CC = document.getElementById("selFracc").value;
            var SM = document.getElementById("selManzana").value;

            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_selTipoCredito")%>",
                data: { CC: CC, SM: SM },
                success: function (msg) {
                    $("#selCredito").html('');
                    $("#selCredito").html(msg);
                }
            };
            $.ajax(options);
        };

        function ActivaAhorro() {
            var Fracc = document.getElementById("selFracc").value;
            var TCredito = document.getElementById("selCredito").value;


            switch (Fracc) {
                case '680':
                case '690':
                    if (TCredito == 1) {
                        cargaCampoAhorro();
                    } else {
                        $("#DivCantidadAhorro").html('');
                    };

                    break;
                default:
                    $("#DivCantidadAhorro").html('');
            }

            if (TCredito == 6) {
                //Contrato de contado Activar Casillas de contados

                var options =
                {
                    type: "post",
                    url: "<%:Url.Action("Crea_campos_contado")%>",
                    //data: { CC: Fracc, smza: supermza },
                    success: function (msg) {
                        $("#camposContado").html(msg);
                    }
                };
                $.ajax(options);
            }


            FovissteCredito();
        };

        function cargaselManzana() {

            document.getElementById("DivCarga").style.display = "initial";
            var id_fracc = document.getElementById("selFracc").value;
            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_selManzana")%>",
                data: { CC: id_fracc },
                success: function (msg) {
                    Termina(msg);
                }
            };
            $.ajax(options);
        };

        function Termina(msg) {
            $("#DivSelManzana").html(msg);
            var sMza = document.getElementById("selManzana").value;
            if (sMza == "CEDHV") {
                cargaTerreno();

            } else {
                $("#DivSelTerreno").html("");
            };
            document.getElementById("DivCarga").style.display = "none";
        };

        function cargaTerreno() {

            document.getElementById("DivCarga").style.display = "initial";
            var id_fracc = document.getElementById("selManzana").value;
            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_selTerreno")%>",
                data: { sMza: id_fracc },
                success: function (msg) {
                    $("#DivSelTerreno").html(msg);
                    document.getElementById("DivCarga").style.display = "none";
                }
            };
            $.ajax(options);
        };

        function cargaCampoAhorro() {

            document.getElementById("DivCarga").style.display = "initial";

            var options =
            {
                type: "post",
                url: "<%:Url.Action("Crea_campoAhorro")%>",
                //data: { sMza: id_fracc },
                success: function (msg) {
                    $("#DivCantidadAhorro").html(msg);
                    document.getElementById("DivCarga").style.display = "none";
                }
            };
            $.ajax(options);
        };
    </script>
</asp:Content>
