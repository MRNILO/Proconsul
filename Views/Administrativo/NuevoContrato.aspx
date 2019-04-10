<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Nuevo Contrato</h2>
    <form method="post">
        Ingrese Centro de Costos:
        <br />
        <input type="text" required="required" name="CC" maxlength="5"  class="form-control"/>
         Ingrese Super manzana (todo en mayusculas):
        <br />
        <input type="text" required="required" name="SM" maxlength="5"  class="form-control"/>
         Ingrese el tipo de credito (1= infonavit, 2= fovissste, 3= noinfonavit):
        <br />
        <input type="text" required="required" name="TC" maxlength="5"  class="form-control"/>
         INFONAVIT (0= NO ES INFONAVIT, 1= CREDITO INFONAVIT):
        <br />
        <input type="text" required="required" name="INFONAVIT" maxlength="5"  class="form-control"/>
         FOVISSSTE (0= NO ES FOVISSSTE, 1= CREDITO FOVISSSTE):
        <br />
        <input type="text" required="required" name="FOVISSSTE" maxlength="5"  class="form-control"/>
        ISSEG (0= NO ES ISSEG, 1= CREDITO ISSEG):
        <br />
        <input type="text" required="required" name="ISSEG" maxlength="5"  class="form-control"/>
         Fecha_ DTU:
        <br />
        <input type="date" required="required" name="Fecha_DTU"   class="form-control"/>
         Cantidad penalización previo al ingreso del expediente:
        <br />
        <input type="text" required="required" name="CPenalizaPrevio"   class="form-control"/>
        Cantidad de enganche:
        <br />
        <input type="text" required="required" name="CEnganche"   class="form-control"/>
        Cantidad penalización al ingreso del expediente:
        <br />
        <input type="text" required="required" name="CPenalizaIngresado"  class="form-control"/>
        Ruta el archivo donde se ubica el PDF de adiconales Numero 2 (C:\Contratos\Adicionales\Reglamentos\680-HV-R.pdf):
        <br />
        <input type="text" required="required" name="FormatoAdicional2"   class="form-control"/>
        Ruta el archivo donde se ubica el PDF de adiconales Numero 1 (C:\Contratos\Adicionales\Reglamentos\680-HV-R.pdf):
        <br />
        <input type="text" required="required" name="FormatoAdicional"   class="form-control"/>
         Precio de la casa:
        <br />
        <input type="text" required="required" name="PrecioCasa"   class="form-control"/>
          Precio por metro adicional:
        <br />
        <input type="text" required="required" name="PrecioAdicional"   class="form-control"/>
         Metros de superficie:
        <br />
        <input type="text" required="required" name="Mtr_Casa"   class="form-control"/>
         Bono:
        <br />
        <input type="text" required="required" name="Bono"   class="form-control"/>         
        <br />
        <input type="submit"  class="btn btn-lg green" value="Crear"/>
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
   
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Layout.init(); // init current layout

        });
</script>
</asp:Content>
