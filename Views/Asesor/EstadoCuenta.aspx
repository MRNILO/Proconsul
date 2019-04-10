<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CSSContent" runat="server">

<!-- BEGIN GLOBAL MANDATORY STYLES -->

<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.css"/>
<link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/DT_bootstrap.css"/>
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="<%:ViewBag.Ruta_app%>assets/global/css/components.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link id="style_color" href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/themes/grey.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css"/>
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

<h2>Inicio>Asesores>Estado de Cuenta (Historico de pagos de comisiones)</h2>
  <form method="post" id="forma" name="forma" >
    <br />
   <strong>Seleccione una Fecha Inicial</strong>
    <br />
    <input type="text"  placeholder="Fecha Inicial" id="FechaInicio"  class="form-control" name="FInicio" required="required"/>
      <strong>Seleccione una Fecha Final</strong>
    <br />
    <input type="text"  placeholder="Fecha Final" id="FechaFinal"  class="form-control" name="FFinal" required="required"/>
      <br />

      <table>
          <tr>
              <td>
                  <input type="button" value="Generar" class="btn btn-lg blue" onclick="carga()" />
              </td>
              <td>
                  <div id="DivCarga" style="display:none">
                  <img src="<%:ViewBag.Ruta_app%>assets/global/img/loading-spinner-blue.gif" />Generando reporte espere...
                      </div>
                 
              </td>
          </tr>
      </table>
      
      </form>
    
    <br /> 
    <br />

    <%-- Inicia Tabla --%>
   <%Response.Write(ViewBag.tabla)%>
    
    <%-- Termina tabla --%>



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
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/tabletools/js/dataTables.tableTools.min.js"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/DT_bootstrap.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="<%:ViewBag.Ruta_app%>assets/global/scripts/metronic.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/admin/pages/scripts/table-advanced.js"></script>

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
        IniciaTabla();
    });
</script>
<!-- END PAGE LEVEL SCRIPTS -->
<script>    
    function carga() {
        document.getElementById("DivCarga").style.display = "initial";
        document.getElementById("forma").submit();
    };
    $(window).ready(function () {
        $('#FechaInicio').pickadate()
        $('#FechaFinal').pickadate()       
    });    
    function IniciaTabla() {
        $('#sample_2').dataTable({
            "aLengthMenu": [
               [5, 15, 20, -1],
               [5, 15, 20, "Todos"] // change per page values here
            ],
            "iDisplayLength": 10
        });
    };
</script>
</asp:Content>