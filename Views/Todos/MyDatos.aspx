<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Inicio>My Datos</h2>

    
     <div class="portlet box purple" >
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-home"></i>My Datos
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse">
								</a>
								<a href="#portlet-config" data-toggle="modal" class="config">
								</a>
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
						</div>
						<div class="portlet-body" >
							<%-- Contenido del Recuadro --%>
                            <form method="post" >
                                <div style="text-align:end">
                                <img src="<%:ViewBag.Ruta_app%>assets/sinfoto.png" width="200" />
                                <br />
                                <a href="<%:ViewBag.Ruta_app%>Todos/CambiaFoto" class="btn btn-xs blue">Cambiar Imagen</a>
                                    </div>
      <%Response.Write(ViewBag.tablaDatos)%>
                                <br />
                                <input type="submit" class="btn red" value="Guardar"/>                 
    </form>
						
                        </div>
					</div>

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
       <%-- Empieza Estilos de PickerDate --%>
    <link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.css" id="theme_base">
<link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.date.css" id="theme_date">
<link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/dtp/themes/default.time.css" id="theme_time">
    <%-- Termina Estilos de PickerDate --%>

    <%-- Plupload --%>

    <script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/plu/plupload.full.min.js"></script>



    <script type="text/javascript">
        // Custom example logic

        var uploader = new plupload.Uploader({
            runtimes: 'html5,flash,silverlight,html4',
            browse_button: 'pickfiles', // you can pass in id...
            container: document.getElementById('container'), // ... or DOM Element itself
            url: '<%:ViewBag.Ruta_app%>Todos/MyDatos',
            flash_swf_url: '<%:ViewBag.Ruta_app%>assets/plu/Moxie.swf',
            silverlight_xap_url: '<%:ViewBag.Ruta_app%>assets/plu/Moxie.xap',

            filters: {
                max_file_size: '2mb',
                mime_types: [
                    { title: "Image files", extensions: "jpg,gif,png" },                   
                ]
            },

            init: {
                PostInit: function () {
                    document.getElementById('filelist').innerHTML = '';

                    document.getElementById('uploadfiles').onclick = function () {
                        uploader.start();
                        return false;
                    };
                },

                FilesAdded: function (up, files) {
                    plupload.each(files, function (file) {
                        document.getElementById('filelist').innerHTML += '<div id="' + file.id + '">' + file.name + ' (' + plupload.formatSize(file.size) + ') <b></b></div>';
                    });
                },

                UploadProgress: function (up, file) {
                    document.getElementById(file.id).getElementsByTagName('b')[0].innerHTML = '<span>' + file.percent + "%</span>";
                },

                Error: function (up, err) {
                    document.getElementById('console').innerHTML += "\nError #" + err.code + ": " + err.message;
                }
            }
        });

        uploader.init();

</script>






    <%-- Termina Plupload --%>


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
        $(window).ready(function () {
            $('#FNacimiento').pickadate()
            $('#FVenceManejo').pickadate()
        });
    </script>
    
    <%-- Termina JS Datepicker --%>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Layout.init(); // init current layout

        });
</script>
</asp:Content>
