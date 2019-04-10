<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Titulacion</h2>

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
     	<li>
					<a href="#">
						<i class="fa fa-shopping-cart"></i>
						<span class="title">
							Modulos de Asesores
						</span>
						<span class="arrow ">
						</span>
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
					<a href="<%:ViewBag.Ruta_app%>Titulacion/BuscarCliente">
						<i class="fa fa-search"></i>
						<span class="title">
							Buscar Cliente
						</span>
						<span class="arrow ">
						</span>
					</a>				
				</li>		
      <li>
          <a href="#">
						<i class="fa fa-ban"></i>
						<span class="title">
							Cancelaciones
						</span>
						<span class="arrow ">
						</span>
					</a>
          <ul class="sub-menu">
                <li>
					<a href="<%:ViewBag.Ruta_app%>Titulacion/Cancelaciones">
						<i class="fa fa-ban"></i>
						<span class="title">
							Cancelar Cliente
						</span>
						<span class="arrow ">
						</span>
					</a>		
             		
				</li>		
               <li>
					<a href="<%:ViewBag.Ruta_app%>Titulacion/CancelacionesDetalles">
						<i class="fa fa-ban"></i>
						<span class="title">
							Reporte cancelaciones
						</span>
						<span class="arrow ">
						</span>
					</a>		
             		
				</li>	
               
              </ul>
             
     <li>
					<a href="#">
						<i class="fa fa-money"></i>
						<span class="title">
							Comisiones
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li>
							<a href="<%:ViewBag.Ruta_app%>Titulacion/ReporteComisiones">
								<i class="fa fa-money"></i>
								Reporte Comisiones
							</a>
						</li>	                      				
						<li>
							<a href="http://192.168.1.17/DevProconsul/Comisiones/ReporteFracc.aspx">
								<i class="fa fa-money"></i>
								Resumen Fraccionamiento
							</a>
						</li>	
						<li>
							<a href="http://192.168.1.17/DevProconsul/Comisiones/ResumenAsesor.aspx">
								<i class="fa fa-money"></i>
								Resumen Asesores
							</a>
						</li>	
					</ul>

				</li>	
     <li>
					<a href="http://192.168.1.17/DevProconsul/Comisiones/ProgramacionEntrega.aspx">
						<i class="fa fa-home"></i>
						<span class="title">
							Entrega de vivienda
						</span>
						
					</a>				
				</li>		
      <li>
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
