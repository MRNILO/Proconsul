<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<!-- 
Template Name: Metronic - Responsive Admin Dashboard Template build with Twitter Bootstrap 3.1.1
Version: 2.0.2
Author: KeenThemes
Website: http://www.keenthemes.com/
Contact: support@keenthemes.com
Purchase: http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes
License: You must have a valid license purchased only from themeforest(the above link) in order to legally use the theme for your project.
-->
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>ProConsul | Iniciar Sesión</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <!-- BEGIN GLOBAL MANDATORY STYLES -->

    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2-metronic.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/pages/css/login-soft.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="<%:ViewBag.Ruta_app%>assets/global/css/components.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/themes/grey.css" rel="stylesheet" type="text/css" />
    <link href="<%:ViewBag.Ruta_app%>assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="<%:ViewBag.Ruta_app%>favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="login">
    <!-- BEGIN LOGO -->
    <div class="logo">
        <a href="<%:ViewBag.Ruta_app%>index.html">
            <img src="<%:ViewBag.Ruta_app%>Img/Logo.png" alt="" width="300" />
        </a>
    </div>
    <!-- END LOGO -->
    <!-- BEGIN LOGIN -->
    <div class="content">
        <!-- BEGIN LOGIN FORM -->
        <form class="login-form" method="post">
            <h3 class="form-title">Ingresa en ProConsul </h3>
            <br />
            <h4><%:ViewBag.Mensaje%></h4>
            <div class="alert alert-danger display-hide">
                <button class="close" data-close="alert"></button>
                <span>Ingresa tu numero de asesor y contraseña.
                </span>
            </div>
            <div class="form-group">
                <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                <label class="control-label visible-ie8 visible-ie9">N.Asesor</label>
                <div class="input-icon">
                    <i class="fa fa-user"></i>
                    <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="N.Asesor" name="username" />
                </div>
            </div>
            <div class="form-group">
                <label class="control-label visible-ie8 visible-ie9">Contraseña</label>
                <div class="input-icon">
                    <i class="fa fa-lock"></i>
                    <input class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Contraseña" name="password" />
                </div>
            </div>
            <div class="form-actions">
                <button type="submit" class="btn blue pull-right">
                    Entrar <i class="m-icon-swapright m-icon-white"></i>
                </button>
            </div>


        </form>
        <!-- END LOGIN FORM -->


    </div>
    <!-- END LOGIN -->
    <!-- BEGIN COPYRIGHT -->
    <div class="copyright">
        2014 &copy; ProConsul - Sistema Administrativo de Vivienda Edificasa.
    </div>
    <!-- END COPYRIGHT -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
	<script src="<%:ViewBag.Ruta_app%>assets/plugins/respond.min.js"></script>
	<script src="<%:ViewBag.Ruta_app%>assets/plugins/excanvas.min.js"></script> 
	<![endif]-->
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
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%:ViewBag.Ruta_app%>assets/global/plugins/select2/select2.min.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="<%:ViewBag.Ruta_app%>assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script src="<%:ViewBag.Ruta_app%>assets/admin/pages/scripts/login-soft.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Login.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
