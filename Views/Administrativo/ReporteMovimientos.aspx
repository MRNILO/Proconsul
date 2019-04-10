<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Reporte de Movimientos</h2>

    <form method="post">
        Seleccione una fecha de inicio:
        <br />
        <input type="text" required="required" name="FechaInicio" id="FechaInicio" />      
        <br />
         Seleccione una fecha final:
        <br />
        <input type="text" required="required" name="FechaFinal" id="FechaFinal" />
        <br />
        Ingrese el numero de la etapa:
        <br />
        <input type="number" required="required" name="Etapa" id="Etapa" />
        <br />
        <input type="submit" class="btn blue" value="Generar" />
    </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CSSContent" runat="server">
    
<!-- BEGIN GLOBAL MANDATORY STYLES -->

<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
       <%-- Empieza Estilos de PickerDate --%>
    <link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.css" id="theme_base">
<link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.date.css" id="theme_date">
<link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.time.css" id="theme_time">
    <%-- Termina Estilos de PickerDate --%>
<!-- BEGIN THEME STYLES -->
<link href="<%:ViewBag.Ruta_app%>assets/global/css/components.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/global/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link id="style_color" href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/themes/grey.css" rel="stylesheet" type="text/css"/>
<link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
   
</asp:Content>

<asp:Content ContentPlaceHolderID="NombreUsuario" runat="server">
    <%:ViewBag.NombreUsuario%>
</asp:Content>

<asp:Content ContentPlaceHolderID="Menu" runat="server">
    
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
      <script type="text/javascript">
          $(window).ready(function () {
              $('#FechaInicio').pickadate({ format: 'yyyy/mm/dd' });
              $('#FechaFinal').pickadate({ format: 'yyyy/mm/dd' });
          });
    </script>
</asp:Content>
