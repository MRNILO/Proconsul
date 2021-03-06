﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Nueva Persona</h2>
    <iframe src="http://192.168.1.17/DevProConsul/SAC/RegistroPersonas.aspx" width="100%" height="1000" style="border:none"></iframe>

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
