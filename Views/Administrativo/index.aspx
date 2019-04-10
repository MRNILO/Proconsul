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
    <%-- Empieza Estilos de PickerDate --%>
    <link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.css" id="theme_base">
    <link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.date.css" id="theme_date">
    <link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.time.css" id="theme_time">
    <%-- Termina Estilos de PickerDate --%>
</asp:Content>
<asp:Content ContentPlaceHolderID="NombreUsuario" runat="server">
    <%:ViewBag.NombreUsuario%>
</asp:Content>
<asp:Content ContentPlaceHolderID="Menu" runat="server">
    <li>
        <a href="#">
            <i class="fa fa-shopping-cart"></i>
            <span class="title">Modulos de Asesores
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/Contratos">
                    <i class="fa fa-file"></i>
                    Contratos
                </a>
            </li>
        </ul>
    </li>
    <li>
        <a href="#">
            <i class="fa fa-file"></i>
            <span class="title">Reportes
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="/DevproConsul/Reportes/Acumulados.aspx">
                    <i class="fa fa-file"></i>
                    Acumulado de asesores y Lider por Fraccionamiento
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/ReporteMovimientos">
                    <i class="fa fa-file"></i>
                    Reporte Movimientos
                </a>
            </li>
            <li>
                <a href="/ReportesDX/DS.aspx?SQL=SELECT%20Empleado,%20Nom_Empleado,%20Ap_Paterno_Empleado,%20Ap_Materno_Empleado,%20Direccion_Archivo%20AS%20Lider,%20Tel_Casa,%20Tel_Otros%20as%20Celular,%20Dir_Casa%20AS%20Email,%20CP%20AS%20Extension%20FROM%20dba.sm_agente%20WHERE%20status_agente%20=%20%27A%27%20AND%20Direccion_Archivo%20!=%20%27ADMINISTRATIVO%27%20AND%20Empleado%20!=%209999%20ORDER%20BY%20Lider;">
                    <i class="fa fa-file"></i>
                    Asesores Activos
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/ReporteDinero">
                    <i class="fa fa-file"></i>
                    Dinero pagado de asesores y Lider
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/ReporteAutorizaEtapa">
                    <i class="fa fa-file"></i>
                    Reporte Autorización Etapa
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/ReportePenalizaciones">
                    <i class="fa fa-file"></i>
                    Reporte Penalizaciones
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/ContratoFovissste">
                    <i class="fa fa-file"></i>
                    Contrato Fovissste
                </a>
            </li>
            <li>
                <a href="/DevProconsul/Comisiones/integradoras.aspx">
                    <i class="fa fa-file"></i>
                    Reporte Integración
                </a>
            </li>
            <li>
                <a href="/DevProconsul/Reportes/ListaDeEspera.aspx">
                    <i class="fa fa-file"></i>
                    Reporte de Lista de Espera
                </a>
            </li>
            <li>
                <a href="/DevProconsul/Reportes/Estadisticas.aspx">
                    <i class="fa fa-file"></i>
                    Estadisticas
                </a>
            </li>
            <li>
                <a href="/DevProconsul/SAC/reportes.aspx">
                    <i class="fa fa-file"></i>
                    Estadisticas SAC
                </a>
            </li>
            <li>
                <a href="/DevProconsul/Reportes/convocatoria.aspx" target="_blank">
                    <i class="fa fa-file"></i>
                    Reporte convocatoria
                </a>
            </li>
            <li>
                <a href="/DevProCOnsul/Reportes/capacidadCompra.aspx" target="_blank">
                    <i class="fa fa-file"></i>
                    Reporte Capacidad de compra
                </a>
            </li>
        </ul>
    </li>
    <li>
        <a href="<%:ViewBag.Ruta_app%>Administrativo/BuscarCliente">
            <i class="fa fa-search"></i>
            <span class="title">Buscar Cliente
            </span>
            <span class="arrow "></span>
        </a>
    </li>
    <li>
        <a href="#">
            <i class="fa fa-ban"></i>
            <span class="title">Cancelaciones
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/Cancelaciones">
                    <i class="fa fa-ban"></i>
                    <span class="title">Cancelar Cliente
                    </span>
                    <span class="arrow "></span>
                </a>

            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/CancelacionesDetalles">
                    <i class="fa fa-ban"></i>
                    <span class="title">Reporte cancelaciones
                    </span>
                    <span class="arrow "></span>
                </a>

            </li>
        </ul>

        <li>
            <a href="#">
                <i class="fa fa-gear"></i>
                <span class="title">Configuraciones
                </span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="<%:ViewBag.Ruta_app%>Administrativo/ContratosConfig">
                        <i class="fa fa-gear"></i>
                        Precio, Contratos
                    </a>
                </li>
                <li>
                    <a href="/DevProconsul/ExtensionesProConsul/Plazos.aspx" target="_blank">
                        <i class="fa fa-gear"></i>
                        Plazos Terrenos
                    </a>
                </li>
                <li>
                    <a href="<%:ViewBag.Ruta_app%>Administrativo/Equipamientos">
                        <i class="fa fa-gear"></i>
                        Equipamientos
                    </a>
                </li>
                <li>
                    <a href="/DevproConsul/ExtensionesProconsul/PromocionesContratos.aspx" target="_blank">
                        <i class="fa fa-gear"></i>
                        Promociones
                    </a>
                </li>
                <li>
                    <a href="/DevproConsul/ExtensionesProconsul/pcru.aspx">
                        <i class="fa fa-gear"></i>
                        PCRU's
                    </a>
                </li>
                <li>
                    <a href="<%:ViewBag.Ruta_app%>Administrativo/ConfiguraAdministrativos">
                        <i class="fa fa-gear"></i>
                        Administrativos
                    </a>
                </li>
                <li>
                    <a href="<%:ViewBag.Ruta_app%>Administrativo/ConfiguraRutas">
                        <i class="fa fa-gear"></i>
                        Rutas
                    </a>
                </li>
            </ul>

        </li>
    <li>
        <a href="#">
            <i class="fa fa-money"></i>
            <span class="title">Comisiones
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="/devproConsul/ExtensionesProconsul/promocionMeta.aspx">
                    <i class="fa fa-money"></i>
                    Pagos meta
                </a>
            </li>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Administrativo/ReporteComisiones">
                    <i class="fa fa-money"></i>
                    Reporte Comisiones
                </a>
            </li>
            <li>
                <a href="/DevProconsul/Comisiones/ReporteFracc.aspx">
                    <i class="fa fa-money"></i>
                    Resumen Fraccionamiento
                </a>
            </li>
            <li>
                <a href="/DevProconsul/Comisiones/ResumenAsesor.aspx">
                    <i class="fa fa-money"></i>
                    Resumen Asesores
                </a>
            </li>
            <li>
                <a href="/DevProconsul/ExtensionesProConsul/Ahorros.aspx">
                    <i class="fa fa-money"></i>
                    Ahorros
                </a>
            </li>
            <li>
                <a href="/DevProconsul/ExtensionesProConsul/TodosClientesSinUbicacion.aspx">
                    <i class="fa fa-money"></i>
                    Clientes sin ubicación pagados
                </a>
            </li>
        </ul>

    </li>
    <li>
        <a href="/DevProconsul/Comisiones/ProgramacionEntrega.aspx">
            <i class="fa fa-home"></i>
            <span class="title">Entrega de vivienda
            </span>

        </a>
    </li>
    <li>
    <li>
        <a href="http://192.168.1.13/crm/">
            <i class="fa fa-cog"></i>
            CRM
        </a>
    </li>
    <li>
        <a href="/DevProconsul/ExtensionesProConsul/FormatoComunidad.aspx">
            <i class="fa fa-book"></i>
            <span class="title">Formato Comunidad Edificasa
            </span>

        </a>
    </li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inicio>Administrativo</h2>
    <br />
    <a class="btn default" data-toggle="modal" href="#aviso">Abrir aviso ProConsul Anterior
    </a>
    <br />
    <a class="btn default yellow" data-toggle="modal" href="#F_Reporte">Cambiar fechas
    </a>
    <br />
    <a class="btn blue" onclick="printDiv('Imprimir')" href="javascript:;">Imprimir</a>
    <br />
    <br />
    <%-- Empiezan Status --%>
    <%-- Empieza Cargando --%>
    <div id="DivCargando" style="display: none">
        <img src="<%:ViewBag.Ruta_app%>assets/admin/layout/img/loading-spinner-blue.gif" /><strong>Cargando datos...</strong>
    </div>
    <%-- Termina cARgando --%>
    <!-- BEGIN DASHBOARD STATS -->

    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat blue-madison">
                <div class="visual">
                    <i class="fa fa-home"></i>
                </div>
                <div class="details">
                    <div class="number" id="vendidasUbicadas">
                        -
                    </div>
                    <div class="desc">
                        Ventas Totales (Ubicadas)
                    </div>
                </div>
                <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat red-intense">
                <div class="visual">
                    <i class="fa fa-bar-chart-o"></i>
                </div>
                <div class="details">
                    <div class="number" id="cantHabitable">
                        -
                    </div>
                    <div class="desc">
                        Cantidad de Casas con Habitabilidad
                    </div>
                </div>
                <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat green-haze">
                <div class="visual">
                    <i class="fa fa-exclamation"></i>
                </div>
                <div class="details">
                    <div class="number" id="CancelaNum">
                        -
                    </div>
                    <div class="desc">
                        Clientes Cancelados o sin Ubicación
                    </div>
                </div>
                <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat purple-plum">
                <div class="visual">
                    <i class="fa fa-globe"></i>
                </div>
                <div class="details">
                    <div class="number" id="NumPor">
                        -%
                    </div>
                    <div class="desc">
                        Porcentaje contra Meta
                    </div>
                </div>
                <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
    </div>
    <!-- END DASHBOARD STATS -->
    <%-- Termina Stats --%>

    <%-- Div impresion --%>
    <div id="Imprimir">
        <%-- Div Impresion --%>
        <%-- Empieza Grafico Ventas --%>
        <div class="portlet box red">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-home"></i>Acumulado por semana
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <div id="chart_2" class="chart" style="height: 470px !important">
                </div>
            </div>
        </div>
        <%-- Termina Grafico ventas --%>


        <!-- BEGIN BASIC CHART PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-money"></i>Ventas por Semana
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <div id="chart_1_1_legendPlaceholder">
                </div>
                <div id="chart_1_1" class="chart" style="height: 600px !important">
                </div>
            </div>
        </div>
        <!-- END BASIC CHART PORTLET-->
        <%-- empieza Grafico Firmas X Semana --%>
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-check"></i>Firmas Por semana
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <div id="chartFirmas" class="chart">
                </div>
            </div>
        </div>
        <%-- termina Grafico Firmas X Semana --%>

        <%-- Div impresion --%>
    </div>
    <%-- Div Impresion --%>

    <%-- Inicia Modal --%>
    <div class="modal fade in" id="F_Reporte" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Fechas Reporte</h4>
                </div>
                <div class="modal-body">
                    <br />
                    <strong>Seleccione una Fecha Inicial</strong>
                    <br />
                    <input type="text" placeholder="Fecha Inicial" id="FechaInicio" class="form-control" name="FInicio" required="required" value="<%:Now.ToString("01/01/yyyy")%>" />
                    <strong>Seleccione una Fecha Final</strong>
                    <br />
                    <input type="text" placeholder="Fecha Final" id="FechaFinal" class="form-control" name="FFinal" required="required" value="<%:Now.ToShortDateString%>" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn blue" data-dismiss="modal" onclick="IniciaBoard()">Cambiar Fechas</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%-- termina modal --%>

    <%-- Inicia Modal --%>
    <div class="modal fade" id="aviso" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Bienvenido a ProConsul 2.0</h4>
                </div>
                <div class="modal-body">
                    ProConsul 2.0 Es una versión mejorada y actualizada del sistema que ya conoces, solo que aun esta en fase de desarrollo, si necesitas el ProConsul Anterior podras entrar desde el enlace aqui incluido.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn default" data-dismiss="modal">Cerrar</button>
                    <a href="http://192.168.1.17/ProConsulOld/" class="btn blue">Ir al viejo ProConsul</a>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%-- termina modal --%>
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
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/flot/jquery.flot.min.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/flot/jquery.flot.resize.min.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/flot/jquery.flot.pie.min.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/flot/jquery.flot.stack.min.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/flot/jquery.flot.crosshair.min.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/flot/jquery.flot.categories.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="<%:ViewBag.Ruta_app%>assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/pages/scripts/charts.js"></script>

    <%-- Empieza JS Datepicker --%>
    <script src="<%:ViewBag.Ruta_app%>assets/dtp/picker.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/dtp/picker.date.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/dtp/picker.time.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/dtp/legacy.js"></script>
    <script type="text/javascript">
        jQuery.extend(jQuery.fn.pickadate.defaults, {
            monthsFull: ['enero', 'febrero', 'marzo', 'abril', 'mayo', 'junio', 'julio', 'agosto', 'septiembre', 'octubre', 'noviembre', 'diciembre'],
            monthsShort: ['ene', 'feb', 'mar', 'abr', 'may', 'jun', 'jul', 'ago', 'sep', 'oct', 'nov', 'dic'],
            weekdaysFull: ['domingo', 'lunes', 'martes', 'miércoles', 'jueves', 'viernes', 'sábado'],
            weekdaysShort: ['dom', 'lun', 'mar', 'mié', 'jue', 'vie', 'sáb'],
            today: 'hoy',
            clear: 'borrar',
            firstDay: 1,
            format: 'dddd d !de mmmm !de yyyy',
            formatSubmit: 'yyyy/mm/dd'
        });

    </script>

    <%-- Termina JS Datepicker --%>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Layout.init(); // init current layout

        });
    </script>
    <!-- END PAGE LEVEL SCRIPTS -->

    <script type="text/javascript">
        $(window).ready(function () {
            $('#FechaInicio').pickadate({ format: 'yyyy/mm/dd' });
            $('#FechaFinal').pickadate({ format: 'yyyy/mm/dd' });
            IniciaBoard();
        });
        function IniciaBoard() {
            document.getElementById("DivCargando").style.display = "initial";
            //Obtener_Datos_X_Semana();
            Obtener_VendidasUbicadas();
            Obtener_Habitables();
            Obtener_VentasXSemanaLM();
            Obtener_FirmasXSemana();
            Obtener_total_Cancelados();
            Crea_Grafico_habitabilidad_Venta();

        };

        function Obtener_VendidasUbicadas() {
            var F_inicio = document.getElementById("FechaInicio").value;
            var F_final = document.getElementById("FechaFinal").value;
            $.ajax({
                type: "GET",
                url: '<%:Url.Action("Obtener_VentasUbicadas", "Administrativo")%>',
                //dataType: "json",
                data: { finicio: F_inicio, ffinal: F_final }
            })
                .done(function (msg) {

                    $("#vendidasUbicadas").html(msg);
                })
                .fail(function () {
                    //alert("Error al procesar la solicitud.");
                });
        };

        function Obtener_total_Cancelados() {
            var F_inicio = document.getElementById("FechaInicio").value;
            var F_final = document.getElementById("FechaFinal").value;
            $.ajax({
                type: "GET",
                url: '<%:Url.Action("Obtener_Cancelados", "Administrativo")%>',
                //dataType: "json",
                data: { finicio: F_inicio, ffinal: F_final }
            })
                .done(function (msg) {

                    $("#CancelaNum").html(msg);
                })
                .fail(function () {
                    // alert("Error al procesar la solicitud.");
                });
        };

        function Obtener_Habitables() {
            var F_inicio = document.getElementById("FechaInicio").value;
            var F_final = document.getElementById("FechaFinal").value;
            $.ajax({
                type: "GET",
                url: '<%:Url.Action("Obtener_Habitables", "Administrativo")%>',
                //dataType: "json",
                data: { finicio: F_inicio, ffinal: F_final }
            })
                .done(function (msg) {
                    $("#cantHabitable").html(msg);
                    document.getElementById("DivCargando").style.display = "none";
                })
                .fail(function () {
                    //alert("Error al procesar la solicitud.");
                });
        };
        function Crea_barras(Datos) {
            var options = {
                series: {
                    bars: { show: true }
                },
                bars: {
                    barWidth: 0.8,
                    lineWidth: 0, // in pixels
                    shadowSize: 0,
                    align: 'left'
                },

                grid: {
                    tickColor: "#eee",
                    borderColor: "#eee",
                    borderWidth: 1
                }
            };

            $.plot($("#chart_1_1"),
                [{
                    data: Datos,
                    lines: {
                        lineWidth: 1,
                    },
                    shadowSize: 0
                }]
                , options);
        }
        function GetData(ArrVentas) {
            var Arreglo = [];
            for (i = 0; i < (ArrVentas.length); i++) {
                Arreglo[i] = [ArrVentas[i].NSemana, ArrVentas[i].CantidadVentas];
            };
            return Arreglo;
        };
        function chart2(ArrVentas, Habita, Escriturados, ingresados) {
            var plot = $.plot($("#chart_2"), [{
                data: ArrVentas,
                label: "Ventas",
                lines: {
                    lineWidth: 1,
                },
                shadowSize: 0

            },
            {
                data: Habita,
                label: "Habitabilidad",
                lines: {
                    lineWidth: 1,
                },
                shadowSize: 0
            },
            {
                data: Escriturados,
                label: "Escriturados",
                lines: {
                    lineWidth: 1,
                },
                shadowSize: 0
            }, {
                data: ingresados,
                label: "Ingresados",
                lines: {
                    lineWidth: 1,
                },
                shadowSize: 0
            }
            ], {
                    series: {
                        lines: {
                            show: true,
                            lineWidth: 2,
                            fill: true,
                            fillColor: {
                                colors: [{
                                    opacity: 0.05
                                }, {
                                    opacity: 0.01
                                }
                                ]
                            }
                        },
                        points: {
                            show: true,
                            radius: 3,
                            lineWidth: 1
                        },
                        shadowSize: 2
                    },
                    grid: {
                        hoverable: true,
                        clickable: true,
                        tickColor: "#eee",
                        borderColor: "#eee",
                        borderWidth: 1
                    },
                    colors: ["#d12610", "#37b7f3", "#52e136", "#D7DF01"],
                    xaxis: {
                        ticks: 11,
                        tickDecimals: 0,
                        tickColor: "#eee",
                    },
                    yaxis: {
                        ticks: 11,
                        tickDecimals: 0,
                        tickColor: "#eee",
                    }
                });


            function showTooltip(x, y, contents) {
                $('<div id="tooltip">' + contents + '</div>').css({
                    position: 'absolute',
                    display: 'none',
                    top: y + 5,
                    left: x + 15,
                    border: '1px solid #333',
                    padding: '4px',
                    color: '#fff',
                    'border-radius': '3px',
                    'background-color': '#333',
                    opacity: 0.80
                }).appendTo("body").fadeIn(200);
            }

            var previousPoint = null;
            $("#chart_2").bind("plothover", function (event, pos, item) {
                $("#x").text(pos.x.toFixed(2));
                $("#y").text(pos.y.toFixed(2));

                if (item) {
                    if (previousPoint != item.dataIndex) {
                        previousPoint = item.dataIndex;

                        $("#tooltip").remove();
                        var x = item.datapoint[0].toFixed(2),
                            y = item.datapoint[1].toFixed(2);

                        showTooltip(item.pageX, item.pageY, item.series.label + " of " + x + " = " + y);
                    }
                } else {
                    $("#tooltip").remove();
                    previousPoint = null;
                }
            });
        }
        function Crea_Grafico_habitabilidad_Venta() {
            var ventas;
            var habitabilidad;
            var Escriturados;
            var ingresados;

            Obtener_Datos_X_Semana();
            Obtener_Habitabilidad_X_Semana();
            Obtener_Escriturados_X_Semana();
            Obtener_Ingresados_X_Semana();

            function Obtener_Datos_X_Semana() {
                var F_inicio = document.getElementById("FechaInicio").value;
                var F_final = document.getElementById("FechaFinal").value;
                $.ajax({
                    type: "GET",
                    url: '<%:Url.Action("Obtener_Datos_Ventas_X_Semana", "Administrativo")%>',
                    dataType: "json",
                    data: { finicio: F_inicio, ffinal: F_final }
                })
                    .done(function (msg) {
                        ventas = GetData(msg);
                    })
                    .fail(function () {
                        // alert("Error al procesar la solicitud.");
                    });
            };

            function Obtener_Ingresados_X_Semana() {
                var F_inicio = document.getElementById("FechaInicio").value;
                var F_final = document.getElementById("FechaFinal").value;
                $.ajax({
                    type: "GET",
                    url: '<%:Url.Action("Obtener_Datos_Ingresados_X_Semana", "Administrativo")%>',
                    dataType: "json",
                    data: { finicio: F_inicio, ffinal: F_final }
                })
                    .done(function (msg) {
                        ingresados = GetData(msg);
                    })
                    .fail(function () {
                        // alert("Error al procesar la solicitud.");
                    });
            };


            function Obtener_Habitabilidad_X_Semana() {
                var F_inicio = document.getElementById("FechaInicio").value;
                var F_final = document.getElementById("FechaFinal").value;
                $.ajax({
                    type: "GET",
                    url: '<%:Url.Action("Obtener_Habitabilidad_X_Semana", "Administrativo")%>',
                    dataType: "json",
                    data: { finicio: F_inicio, ffinal: F_final }
                })
                    .done(function (msg) {
                        habitabilidad = GetData(msg);
                    })
                    .fail(function () {
                        //alert("Error al procesar la solicitud.");
                    });
            };
            function Obtener_Escriturados_X_Semana() {
                var F_inicio = document.getElementById("FechaInicio").value;
                $.ajax({
                    type: "GET",
                    url: '<%:Url.Action("Obtener_AcumuladoEscrituradoLM", "Administrativo")%>',
                    dataType: "json",
                    data: { finicio: F_inicio }
                })
                    .done(function (msg) {
                        Escriturados = GetData(msg);
                    })
                    .fail(function () {
                        // alert("Error al procesar la solicitud.");
                    });
            };

            var delay = 4000;//4 seconds
            setTimeout(function () {
                chart2(ventas, habitabilidad, Escriturados, ingresados);
            }, delay);

        };


        function Obtener_FirmasXSemana() {
            var F_inicio = document.getElementById("FechaInicio").value;
            var F_final = document.getElementById("FechaFinal").value;
            $.ajax({
                type: "GET",
                url: '<%:Url.Action("Obtener_Firmas_X_Semana", "Administrativo")%>',
                dataType: "json",
                data: { finicio: F_inicio, ffinal: F_final }
            })
                .done(function (msg) {
                    GraficoFirmas(GetData(msg));
                })
                .fail(function () {
                    // alert("Error al procesar la solicitud.");
                });
        };

        function Obtener_VentasXSemanaLM() {
            var F_inicio = document.getElementById("FechaInicio").value;

            $.ajax({
                type: "GET",
                url: '<%:Url.Action("Obtener_VentasXSemanaLM", "Administrativo")%>',
                dataType: "json",
                data: { finicio: F_inicio }
            })
                .done(function (msg) {
                    Crea_barras(GetData(msg));
                })
                .fail(function () {
                    // alert("Error al procesar la solicitud.");
                });
        };

        function GraficoFirmas(Firmas) {
            var plot = $.plot($("#chartFirmas"), [{
                data: Firmas,
                label: "Firmas",
                lines: {
                    lineWidth: 1,
                },
                shadowSize: 0

            },
            ], {
                    series: {
                        lines: {
                            show: true,
                            lineWidth: 2,
                            fill: true,
                            fillColor: {
                                colors: [{
                                    opacity: 0.05
                                }, {
                                    opacity: 0.01
                                }
                                ]
                            }
                        },
                        points: {
                            show: true,
                            radius: 3,
                            lineWidth: 1
                        },
                        shadowSize: 2
                    },
                    grid: {
                        hoverable: true,
                        clickable: true,
                        tickColor: "#eee",
                        borderColor: "#eee",
                        borderWidth: 1
                    },
                    colors: ["#d12610", "#37b7f3", "#52e136"],
                    xaxis: {
                        ticks: 11,
                        tickDecimals: 0,
                        tickColor: "#eee",
                    },
                    yaxis: {
                        ticks: 11,
                        tickDecimals: 0,
                        tickColor: "#eee",
                    }
                });


            function showTooltip(x, y, contents) {
                $('<div id="tooltip">' + contents + '</div>').css({
                    position: 'absolute',
                    display: 'none',
                    top: y + 5,
                    left: x + 15,
                    border: '1px solid #333',
                    padding: '4px',
                    color: '#fff',
                    'border-radius': '3px',
                    'background-color': '#333',
                    opacity: 0.80
                }).appendTo("body").fadeIn(200);
            }

            var previousPoint = null;
            $("#chartFirmas").bind("plothover", function (event, pos, item) {
                $("#x").text(pos.x.toFixed(2));
                $("#y").text(pos.y.toFixed(2));

                if (item) {
                    if (previousPoint != item.dataIndex) {
                        previousPoint = item.dataIndex;

                        $("#tooltip").remove();
                        var x = item.datapoint[0].toFixed(2),
                            y = item.datapoint[1].toFixed(2);

                        showTooltip(item.pageX, item.pageY, item.series.label + " of " + x + " = " + y);
                    }
                } else {
                    $("#tooltip").remove();
                    previousPoint = null;
                }
            });
        }
    </script>
    <script type="text/javascript">
        function printDiv(divID) {

            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            var original = document.getElementById(divID).innerHTML;

            divElements = "<div style='width:900px !important' id='divpresion'>" + divElements + "</div>";

            $("#" + divID).html(divElements);
            ////Get the HTML of whole page
            //var oldPage = document.body.innerHTML;

            ////Reset the page's HTML with div's HTML only
            //document.body.innerHTML =
            //  "<html><head><title>Reporte</title></head><body><div style='width:500px !important'>" +
            //  divElements + "</div></body>";

            IniciaBoard();

            var delay = 4000;//4 seconds
            setTimeout(function () {
                Imprimir(divID, original);
            }, delay);






        }
        function Imprimir(divID, Original) {


            window.print();

            $("#" + divID).html(Original);

            IniciaBoard();
        }
    </script>
</asp:Content>
