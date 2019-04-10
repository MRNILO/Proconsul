<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Aux Dirección</h2>

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
    <li>
					<a href="#">
						<i class="fa fa-file"></i>
						<span class="title">
							Reportes
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li>
							<a href="http://192.168.1.17/DevproConsul/Reportes/Acumulados.aspx">
								<i class="fa fa-file"></i>
								Acumulado de asesores y Lider por Fraccionamiento
							</a>
						</li>	                      
                        <li>
							<a href="http://192.168.1.17/ReportesDX/DS.aspx?SQL=SELECT%20Empleado,%20Nom_Empleado,%20Ap_Paterno_Empleado,%20Ap_Materno_Empleado,%20Direccion_Archivo%20AS%20Lider,%20Tel_Casa,%20Tel_Otros%20as%20Celular,%20Dir_Casa%20AS%20Email,%20CP%20AS%20Extension%20FROM%20dba.sm_agente%20WHERE%20status_agente%20=%20%27A%27%20AND%20Direccion_Archivo%20!=%20%27ADMINISTRATIVO%27%20AND%20Empleado%20!=%209999%20ORDER%20BY%20Lider;">
								<i class="fa fa-file"></i>
								Asesores Activos
							</a>
						</li>		                     
                         <li>
							<a href="<%:ViewBag.Ruta_app%>Administrativo/ReporteAutorizaEtapa">
								<i class="fa fa-file"></i>
								Reporte Autorización Etapa
							</a>
						</li>		    
                         <li>
							<a href="<%:ViewBag.Ruta_app%>Administrativo/ReporteDinero">
								<i class="fa fa-file"></i>
								Dinero pagado de asesores y Lider
							</a>
						</li>		   
                                                                                                            		
					</ul>
				</li>	      
    <li>
         <li>
					<a href="http://192.168.1.17/DevProconsul/ExtensionesProConsul/FormatoComunidad.aspx">
						<i class="fa fa-book"></i>
						<span class="title">
							Formato Comunidad Edificasa
						</span>
						<span class="arrow ">
						</span>
					</a>
             </li>
			  <li>
					<a href="http://192.168.1.17/DevProConsul/ExtensionesProconsul/Encuesta.aspx">
						<i class="fa fa-file"></i>
						<span class="title">
							Cuestionarios
						</span>
						<span class="arrow ">
						</span>
					</a>
             </li>
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
