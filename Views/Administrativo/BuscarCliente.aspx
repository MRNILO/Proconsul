<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Ingrese parte del nombre del cliente:</h2>
  <form method="get" >
  <input type="text" id="typeahead_example_3" name="numcte" class="form-control"/>
    <br />
    <input type="submit" class="btn btn-lg green" value="Buscar"/>
      </form>
    <br />

   <%Response.Write(ViewBag.TablaGenerales)%>
    <%Response.Write(ViewBag.TablaEtapas)%>
    <%Response.Write(ViewBag.TablaComisiones)%>

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
    <!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css"/>
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"/>
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-tags-input/jquery.tagsinput.css"/>
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/typeahead/typeahead.css">
<!-- END PAGE LEVEL STYLES -->  
        <!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.css"/>
<link rel="stylesheet" href="<%:ViewBag.Ruta_app%>assets/global/plugins/data-tables/DT_bootstrap.css"/>
<!-- END PAGE LEVEL STYLES -->
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
<script src="<%:ViewBag.Ruta_app%>assets/admin/pages/scripts/components-form-tools.js"></script>

    <!-- BEGIN PAGE LEVEL PLUGINS -->
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/fuelux/js/spinner.min.js"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery.input-ip-address-control-1.0.min.js"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-pwstrength/pwstrength-bootstrap.min.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-tags-input/jquery.tagsinput.min.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap-touchspin/bootstrap.touchspin.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/typeahead/handlebars.min.js" type="text/javascript"></script>
<script src="<%:ViewBag.Ruta_app%>assets/global/plugins/typeahead/typeahead.bundle.min.js" type="text/javascript"></script>
<script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/ckeditor/ckeditor.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
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
   
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Layout.init(); // init current layout
            iniciarAutoCompletar();
            IniciaTablaEtapas();
            IniciaTablaComisiones();
        });
        
        function iniciarAutoCompletar() {
            // En esta sección no se debe modificar mas que el URL del REMOTE, lo demas como:return d.tokens Debe mantenerse.
            var custom = new Bloodhound({
                datumTokenizer: function (d) { return d.tokens; },
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                remote: '/ProConsul/Administrativo/Obtener_Clientes_por_Nombre?nombre=%QUERY'
            });

            custom.initialize();

            if (Metronic.isRTL()) {
                $('#typeahead_example_3').attr("dir", "rtl");
            }
            $('#typeahead_example_3').typeahead(null, {
                name: 'datypeahead_example_3',
                //Nombre de la propiedad que se mostrara
                displayKey: 'Numcte',
                source: custom.ttAdapter(),
                hint: (Metronic.isRTL() ? false : true),
                templates: {
                    suggestion: Handlebars.compile([
                      '<div class="media">',
                            //'<div class="pull-left">',
                            //    '<div class="media-object">',
                            //        '<img src="{{img}}" width="50" height="50"/>',
                            //    '</div>',
                            //'</div>',
                            '<div class="media-body">',
                            //NombreCliente asi se llama la propiedad
                                '<h4 class="media-heading">{{NombreCliente}}</h4>',
                                //numcte asi se llama la propiedad.
                                '<p><strong>{{Numcte}}</strong></p>',
                            '</div>',
                      '</div>',
                    ].join(''))
                }
            }).on('typeahead:autocompleted', onSelected);
           
        };

        function onSelected($e, datum) {
            //console.log('selected');
            alert(datum);
        }
        function IniciaTablaEtapas() {
            $('#Etapas').dataTable({
                "aLengthMenu": [
                   [5, 15, 20, -1],
                   [5, 15, 20, "Todos"] // change per page values here
                ],
                "iDisplayLength": 10
            });
        };
        function IniciaTablaComisiones() {
            $('#Comisiones').dataTable({
                "aLengthMenu": [
                   [5, 15, 20, -1],
                   [5, 15, 20, "Todos"] // change per page values here
                ],
                "iDisplayLength": 10
            });
        };
</script>

</asp:Content>
