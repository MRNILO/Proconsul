<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CSSContent" runat="server">
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-toastr/toastr.min.css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="<%:ViewBag.Ruta_app%>assets/global/css/components.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/themes/grey.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/wts/wts.css" rel="stylesheet" />
    <!-- END THEME STYLES -->

</asp:Content>
<asp:Content ContentPlaceHolderID="Notificaciones" runat="server">
    <%Response.Write(ViewBag.UltimasNotificaciones) %>
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
                <a href="<%:ViewBag.Ruta_app%>Asesor/Historico">
                    <i class="fa fa-file"></i>
                    Estado de Cuenta (Historico de Pagos)
                </a>
            </li>
            <%If Now.DayOfWeek = DayOfWeek.Friday Or Now.DayOfWeek = DayOfWeek.Saturday Or Now.DayOfWeek = DayOfWeek.Sunday Then
                    Dim HTML = "  <li>"
                    HTML += " <a href=""/ProConsul/Asesor/Genera_ReporteSemanal"">"
                    HTML += "<i class=""fa fa-check-square""></i>"
                    HTML += "Reporte Semanal de pagos"
                    HTML += "  </a>"
                    HTML += " </li>"
                    Response.Write(HTML)
                End If%>
            <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/PosiblePenalizar">
                    <i class="fa fa-file"></i>
                    Posibles penalizaciones
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
            <%-- <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/AltaPersona">
                    <i class="fa fa-user"></i>
                   Personas en vivienda
                </a>
            </li>--%>
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
    <li>
        <a href="#">
            <i class="fa fa-file"></i>
            <span class="title">Asesores Activos
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="/devproconsul/ExtensionesProconsul/AsesoresActivos.aspx">
                    <i class="fa fa-file"></i>
                    Asesores Activos
                </a>
            </li>
        </ul>
    </li>
    <li>
        <a href="javascript:;">
            <i class="fa fa-cog"></i>
            <span class="title">Herramientas
            </span>
            <span class="arrow "></span>
        </a>
        <ul class="sub-menu">
            <li>
                <a href="<%:ViewBag.Ruta_app%>Asesor/Archivos">
                    <i class="fa fa-cog"></i>
                    Carpeta de archivos
                </a>
            </li>
            <li>
                <a href="http://192.168.1.13/crm/">
                    <i class="fa fa-cog"></i>
                    CRM
                </a>
            </li>
        </ul>
    </li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h2>Inicio>Asesores</h2>
    <br />

    <iframe src="/devproconsul/ExtensionesProconsul/AsesoresActivos.aspx" width="100%" height="800"></iframe>
</asp:Content>
<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="JavaScriptContent">
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-toastr/toastr.min.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script src="<%:ViewBag.Ruta_app%>assets/admin/pages/scripts/ui-toastr.js"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/layout/scripts/quick-sidebar.js" type="text/javascript"></script>
    <script type="text/javascript">

        function Notificaciones() {

            toastr.options = {
                "closeButton": false,
                "debug": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "showDuration": "1000",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };




            $.ajax({
                type: "POST",
                url: "/ProConsul/Home/verifica_notificaciones",
                //dataType: "json",
                data: { Empleado: <%:ViewBag.Empleado%>}
            })
                .done(function (msg) {

                    if (msg == 'Sin Mensajes') {

                    } else {
                        toastr.info(msg);
                    };

                    Notificaciones();
                })
                .fail(function () {
                    toastr.error('Error al procesar la solicitud');
                });
        };
    </script>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            //QuickSidebar.init() // init quick sidebar
            UIToastr.init();
            Notificaciones();
            IniciaTabla();
        });
    </script>
    <script type="text/javascript">
        $(window).ready(function () {
            $('#aviso').modal('show');

        });
    </script>

    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/tabletools/js/dataTables.tableTools.min.js"></script>
    <script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/DT_bootstrap.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->

    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/DT_bootstrap.css" />
    <!-- END PAGE LEVEL STYLES -->

    <script>       
        function IniciaTabla() {
            $('#Asesores').dataTable({
                "aLengthMenu": [
                    [5, 15, 20, -1],
                    [5, 15, 20, "Todos"] // change per page values here
                ],
                "iDisplayLength": 10
            });
        };
    </script>
</asp:Content>
