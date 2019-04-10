Imports System.Web.Script.Serialization
Imports System.IO
Imports DocumentFormat.OpenXml.Packaging

Public Class AdministrativoController
    Inherits System.Web.Mvc.Controller

    '
    'GET: /Administrativo
    Private Nivel_Seccion As Integer = 4

    Function Index() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ContratoFovissste() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function ContratoFovissste(ByVal numcte As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("http://192.168.1.17/Contratos/Download/" + FovisssteContrato(numcte), False)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function Cambia_Contrato(ByVal id_contrato As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Formulario = crea_formulario_configcontratos(id_contrato)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function Cambia_Contrato(ByVal id_contrato As Integer, ByVal CC As String, ByVal SM As String, ByVal TC As Integer, ByVal INFONAVIT As String, ByVal FOVISSSTE As String, ByVal ISSEG As String, ByVal Fecha_DTU As Date, ByVal CPenalizaPrevio As Decimal, ByVal CEnganche As Decimal, ByVal CPenalizaIngresado As Decimal, ByVal FormatoAdicional2 As String, ByVal FormatoAdicional As String, ByVal PrecioCasa As Integer, ByVal PrecioAdicional As Integer, ByVal Mtr_Casa As String, ByVal Bono As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                If Bl.Actualiza_pro_contratos_nuevo(id_contrato, CC, SM, TC, INFONAVIT, FOVISSSTE, ISSEG, Fecha_DTU, CPenalizaPrevio, CEnganche, CPenalizaIngresado, FormatoAdicional2, FormatoAdicional, PrecioCasa, PrecioAdicional, Mtr_Casa, 1, Bono) Then
                    Return RedirectToAction("ContratosConfig", "Administrativo")
                Else
                    ViewBag.Mensaje = "Error por favor verifique los datos."
                End If
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function CancelacionesDetalles() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function crea_formulario_configcontratos(ByVal id_contrato As Integer) As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_pro_contratos_nuevo(id_contrato)

        HTML += "         <form method=""post"">"
        HTML += "        <input type=""hidden"" value=""" + Datos.id_contrato.ToString + """/>"
        HTML += "        Ingrese Centro de Costos:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""CC"" maxlength=""5""  class=""form-control"" value=""" + Datos.CC.ToString + """/>"
        HTML += "         Ingrese Super manzana (todo en mayusculas):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""SM"" maxlength=""5""  class=""form-control"" value=""" + Datos.SM.ToString + """/>"
        HTML += "         Ingrese el tipo de credito (1= infonavit, 2= fovissste, 3= noinfonavit):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""TC"" maxlength=""5""  class=""form-control"" value=""" + Datos.TC.ToString + """/>"
        HTML += "         INFONAVIT (0= NO ES INFONAVIT, 1= CREDITO INFONAVIT):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""INFONAVIT"" maxlength=""5""  class=""form-control"" value=""" + If(Datos.INFONAVIT.ToString = True, "1", "0") + """/>"
        HTML += "         FOVISSSTE (0= NO ES FOVISSSTE, 1= CREDITO FOVISSSTE):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""FOVISSSTE"" maxlength=""5""  class=""form-control"" value=""" + If(Datos.FOVISSSTE.ToString = True, "1", "0") + """/>"
        HTML += "        ISSEG (0= NO ES ISSEG, 1= CREDITO ISSEG):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""ISSEG"" maxlength=""5""  class=""form-control"" value=""" + If(Datos.ISSEG.ToString = True, "1", "0") + """/>"
        HTML += "        Fecha_ DTU"
        HTML += "        <br />"
        HTML += "        <input type=""date"" required=""required"" name=""Fecha_DTU""   class=""form-control"" value=""" + Datos.Fecha_DTU.ToString("yyyy-MM-dd") + """/>"
        HTML += "         Cantidad penalización previo al ingreso del expediente:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""CPenalizaPrevio""   class=""form-control"" value=""" + Datos.CPenalizaPrevio.ToString + """/>"
        HTML += "        Cantidad de enganche:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""CEnganche""   class=""form-control"" value=""" + Datos.CEnganche.ToString + """/>"
        HTML += "        Cantidad penalización al ingreso del expediente:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""CPenalizaIngresado""  class=""form-control""  value=""" + Datos.CPenalizaIngresado.ToString + """/>"
        HTML += "        Ruta el archivo donde se ubica el PDF de adiconales Numero 2 (C:\Contratos\Adicionales\Reglamentos\680-HV-R.pdf):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""FormatoAdicional2""   class=""form-control"" value=""" + Datos.FormatoAdicional2.ToString + """/>"
        HTML += "        Ruta el archivo donde se ubica el PDF de adiconales Numero 1 (C:\Contratos\Adicionales\Reglamentos\680-HV-R.pdf):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""FormatoAdicional""   class=""form-control"" value=""" + Datos.FormatoAdicional.ToString + """/>"
        HTML += "         Precio de la casa:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""PrecioCasa""   class=""form-control"" value=""" + Datos.PrecioCasa.ToString + """/>"
        HTML += "          Precio por metro adicional:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""PrecioAdicional""   class=""form-control"" value=""" + Datos.PrecioAdicional.ToString + """/>"
        HTML += "         Metros de superficie:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""Mtr_Casa""   class=""form-control"" value=""" + Datos.Mtr_Casa.ToString + """/>"
        HTML += "        Bono:"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" name=""Bono""   class=""form-control"" value=""" + Datos.Bono.ToString + """/>         "
        HTML += "        <br />"
        HTML += "        <input type=""submit""  class=""btn btn-lg green"" value=""Guardar""/>"
        HTML += "    </form>"
        Return HTML
    End Function
#Region "Comisiones"
    Function ConfiguraRutas() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ReporteComisiones() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("http://192.168.1.17/DevProconsul/Comisiones/GridComisionesGerardo.aspx", False)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ModificaComision(ByVal id_comision As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.IdComision = id_comision.ToString
                ViewBag.formulario = Crea_FormularioCambiaComi(id_comision)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function ModificaComision(ByVal id_comision As Integer, ByVal Cantidad_Pagada_Total As Integer, ByVal Observaciones As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                If Bl.Modifica_Comision(id_comision, Cantidad_Pagada_Total, Observaciones) Then
                    Response.Redirect("http://192.168.1.17/DevProconsul/Comisiones/GridComisionesGerardo.aspx", False)
                Else
                    ViewBag.Mensaje = "Error al cambiar los datos, por favor verifique."
                End If
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function Crea_FormularioCambiaComi(ByVal id_comision As Integer) As String
        Dim HTML As String = ""
        Dim datoscomision = Bl.Obtener_Detalles_comisionID(id_comision)
        HTML = "    <h2>Datos de esta comisión:</h2>"
        HTML += "    <br />"
        HTML += "   numcte:" + datoscomision.numcte.ToString
        HTML += "    <br />"
        HTML += "   Nombre del Cliente:" + datoscomision.NombreCliente
        HTML += "    <br />"
        HTML += "   Agente:" + datoscomision.Empleado.ToString
        HTML += "    <br />"
        HTML += "   Nombre del lider:" + datoscomision.Lider
        HTML += "    <br />"
        HTML += "   Nombre del Gerente:" + datoscomision.Gerente
        HTML += "    <br />"
        HTML += "   Nombre del Administrativo:" + datoscomision.Administrativo
        HTML += "    <br />"
        HTML += "    <br />"

        HTML += "    <form method=""post"">"
        HTML += "    <input type=""hidden"" value=""" + datoscomision.id_comision.ToString + """ name=""id_comision"" />        "
        HTML += "    Cantidad pagada o penalizada"
        HTML += "    <br />"
        HTML += "    <input type=""text"" name=""Cantidad_Pagada_Total"" required=""required""  class=""form-control"" value=""" + datoscomision.Cantidad_Pagada_Total.ToString + """/>"
        HTML += "    <br />"
        HTML += "    Comentario de la comisión (ingrese por qué se está cambiando la comisión)"
        HTML += "    <br />"
        HTML += "    <input type=""text"" name=""Observaciones"" required=""required""  class=""form-control"" value=""" + datoscomision.Observacion + """/>"
        HTML += "    <br />"
        HTML += "    <input type=""submit"" value=""Guardar"" class=""btn btn-xl green""/>"
        HTML += "</form>"
        Return HTML
    End Function
#End Region
    Function ReporteDinero() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            ' If Usuario.Nivel >= Nivel_Seccion Then
            ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            ' Else
            ' Session.Clear()
            ' Return RedirectToAction("Login", "Account")
            ' End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function ReporteDinero(ByVal FechaInicio As Date, ByVal FechaFinal As Date) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            '  If Usuario.Nivel >= Nivel_Seccion Then
            ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("http://192.168.1.17/ReportesDX/ReporteDineros.aspx?fInicio=" + FechaInicio.ToString("yyyy/MM/dd") + "&fFinal=" + FechaFinal.ToString("yyyy/MM/dd") + "", False)
            '' Else
            'Session.Clear()
            '    Return RedirectToAction("Login", "Account")
            'End If
        End If

        Return View()
    End Function

    Function ReportePenalizaciones() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function ReportePenalizaciones(ByVal FechaInicio As Date, ByVal FechaFinal As Date) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("http://192.168.1.17/DevProconsul/Comisiones/reportePenaliza.aspx?FInicio=" + FechaInicio.ToString("yyyy/MM/dd") + "&FFinal=" + FechaFinal.ToString("yyyy/MM/dd") + "", False)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ReporteAutorizaEtapa() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Or Nivel_Seccion = 6 Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function ReporteAutorizaEtapa(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal Cancelados As String, ByVal Etapa As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Or Nivel_Seccion = 6 Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("http://192.168.1.17/DevProconsul/Comisiones/ReporteAutoriza.aspx?Finicio=" + FechaInicio.ToString("yyyy/MM/dd") + "&FFinal=" + FechaFinal.ToString("yyyy/MM/dd") + "&Etapa=" + Etapa + "&Cancelados=" + If(Cancelados = "on", "C", "N") + "", False)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
#Region "equipamientos"
    Function Equipamientos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.TablaEquipamientos = Crea_TablaEquipamientos()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function NuevoEquipamiento() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function NuevoEquipamiento(ByVal CC As String, ByVal SM As String, ByVal Precio As String, ByVal TextoCombo As String, ByVal TextoContrato As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Bl.Inserta_promociones(CC, SM, Precio, TextoCombo, TextoContrato)
                Return RedirectToAction("Equipamientos", "Administrativo")
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function EliminaEquipamiento(ByVal id_promocion As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                Bl.Elimina_promociones(id_promocion)
                Return RedirectToAction("Equipamientos", "Administrativo")
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function

    Public Function Cambia_Equipamiento(ByVal id_equipamiento As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Formulario = Crea_Formulario_Equipamiento(id_equipamiento)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Public Function Cambia_Equipamiento(ByVal idEquipamiento As Integer, ByVal CC As String, ByVal SM As String, ByVal Precio As String, ByVal TextoCombo As String, ByVal TextoContrato As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Bl.Actualiza_promociones(idEquipamiento, CC, SM, Precio, TextoCombo, TextoContrato)
                Return RedirectToAction("Equipamientos", "Administrativo")
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function Crea_Formulario_Equipamiento(ByVal id_equipamiento As Integer) As String
        Dim HTML As String = ""
        Dim DatosEquipamiento = Bl.Obtener_Equipamiento(id_equipamiento)

        HTML += "          <form method=""post"">"
        HTML += "        <input type=""hidden"" required=""required""  name=""idEquipamiento"" value=""" + DatosEquipamiento.id_promocion.ToString + """/>"
        HTML += "        Ingrese un centro de costos (Ejemplo: 740):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" maxlength=""5"" class=""form-control"" name=""CC"" value=""" + DatosEquipamiento.CC.ToString + """/>"
        HTML += "        Ingrese una super manzana (Ejemplo: FREHV , o ingrese TODAS para aplicar un equipamiento para todos las super manzanas de este fraccionamiento):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" maxlength=""10"" class=""form-control"" name=""SM"" value=""" + DatosEquipamiento.SM.ToString + """/>"
        HTML += "         Ingrese el precio de este equipamiento (Ejemplo: 5200):"
        HTML += "        <br />"
        HTML += "        <input type=""text"" required=""required"" maxlength=""10"" class=""form-control"" name=""Precio"" value=""" + DatosEquipamiento.Precio.ToString + """/>"
        HTML += "         Ingrese el texto descriptivo para el combo de la pantalla de contratos (Ejemplo: 1 Closet):"
        HTML += "        <br />"
        HTML += "        <textarea class=""form-control"" maxlength=""300"" required=""required"" name=""TextoCombo"">" + DatosEquipamiento.TextoCombo + "</textarea> "
        HTML += "          Ingrese el texto descriptivo para el contrato (Ejemplo:  de equipamiento consistente en dos closet"
        HTML += "según casa muestra):"
        HTML += "        <br />"
        HTML += "        <textarea class=""form-control"" maxlength=""300"" required=""required"" name=""TextoContrato"">" + DatosEquipamiento.TextoContrato + "</textarea>     "
        HTML += "        <br />"
        HTML += "        <input type=""submit""  class=""btn btn-lg green"" value=""Guardar""/> "
        HTML += "    </form>"


        Return HTML
    End Function
    Public Function Crea_TablaEquipamientos() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Listar_Equipamientos()
        Session("Equipamientos") = Datos
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Equipamientos" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Equipamientos"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_promocion" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "CC" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "SM" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Precio" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "TextoCombo" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "TextoContrato" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th >" + vbCrLf
        HTML += "Opciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_promocion.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).CC + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).SM + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Precio.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).TextoCombo + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).TextoContrato + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td >" + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/EliminaEquipamiento?id_promocion=" + Datos(I).id_promocion.ToString + """ class=""btn btn-xs red"">Eliminar</a>" + vbCrLf
            HTML += "	<br />" + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/Cambia_Equipamiento?id_equipamiento=" + Datos(I).id_promocion.ToString + """ class=""btn btn-xs green"">Cambiar</a>" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function

#End Region
    Function ContratosConfig() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.TablaContrataos = Crea_TablaDatos()                
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function NuevoContrato() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function NuevoContrato(ByVal CC As String, ByVal SM As String, ByVal TC As Integer, ByVal INFONAVIT As String, ByVal FOVISSSTE As String, ByVal ISSEG As String, ByVal Fecha_DTU As Date, ByVal CPenalizaPrevio As Decimal, ByVal CEnganche As Decimal, ByVal CPenalizaIngresado As Decimal, ByVal FormatoAdicional2 As String, ByVal FormatoAdicional As String, ByVal PrecioCasa As Integer, ByVal PrecioAdicional As Integer, ByVal Mtr_Casa As String, ByVal Bono As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Bl.Inserta_pro_contratos_nuevo(CC, SM, TC, INFONAVIT, FOVISSSTE, ISSEG, Fecha_DTU, CPenalizaPrevio, CEnganche, CPenalizaIngresado, FormatoAdicional2, FormatoAdicional, PrecioCasa, PrecioAdicional, Mtr_Casa, 0, Bono)
                Return RedirectToAction("ContratosConfig", "Administrativo")
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function EliminaContrato(ByVal idcontrato As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                Bl.Elimina_pro_contratos_nuevo(idcontrato)
                Return RedirectToAction("ContratosConfig", "Administrativo")
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Public Function Crea_TablaDatos() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Listar_ContratoDatos()
        '        Session("Contratos") = Datos
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Contratos" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Contratos"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_contrato" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "CC" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "SM" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "TC" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "INFONAVIT" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "FOVISSSTE" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "ISSEG" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Fecha_DTU" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "CPenalizaPrevio" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "CEnganche" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "CPenalizaIngresado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "FormatoAdicional2" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "FormatoAdicional" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "PrecioCasa" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "PrecioAdicional" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Mtr_Casa" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Activo" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Bono" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th >" + vbCrLf
        HTML += "Opciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_contrato.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).CC + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).SM + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).TC.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).INFONAVIT + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).FOVISSSTE + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).ISSEG + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Fecha_DTU.ToShortDateString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).CPenalizaPrevio.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).CEnganche.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).CPenalizaIngresado.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).FormatoAdicional2 + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).FormatoAdicional + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).PrecioCasa.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).PrecioAdicional.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Mtr_Casa + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            If Datos(I).Activo = False Then
                HTML += " <button class=""btn btn-xs green"" onClick=""estado(" + Datos(I).id_contrato.ToString + ",1)"">Activar</button>" + vbCrLf
            Else
                HTML += " <button class=""btn btn-xs red"" onClick=""estado(" + Datos(I).id_contrato.ToString + ",0)"">Desactivar</button>" + vbCrLf
            End If
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Bono.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/EliminaContrato?idcontrato=" + Datos(I).id_contrato.ToString + """ class=""btn btn-xs red"" >Eliminar</a>" + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/Cambia_Contrato?id_contrato=" + Datos(I).id_contrato.ToString + """ class=""btn btn-xs blue"" >Cambiar</a>" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function

    <HttpGet()>
    Function BuscarCliente(Optional ByVal numcte As Integer = 0) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Or Usuario.Nivel = 3 Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                If numcte = 0 Then
                Else
                    ViewBag.TablaGenerales = Crea_datos_generales_del_cliente(numcte)
                    ViewBag.TablaEtapas = Crea_tabla_Etapas(numcte)
                    ViewBag.TablaComisiones = Crea_Tabla_Comisiones(numcte)
                End If

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Public Function Crea_Tabla_Comisiones(ByVal Numcte As Integer) As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_comisiones_cliente(Numcte)
        'Session("Comisiones") = Datos
        HTML = "<div class=""portlet box blue"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Comisiones Pagadas" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Comisiones"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_comision" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Pagado_A" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "id_periodo" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Fecha_Pago" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Cantidad_Pagada_Total" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Tipo_pago" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Empleado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Lider" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Gerente" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "NombreCompleto" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Observaciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_comision.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).Pagado_A + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).id_periodo.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Fecha_Pago + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Cantidad_Pagada_Total.ToString("c") + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Tipo_pago + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Empleado.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Lider + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Gerente + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).NombreCompleto + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Observaciones + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function

    Function Cancelaciones() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Visibilidad = "none"

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Sub CambiaEstadusContrato(ByVal id_contrato As Integer, ByVal Estatus As Integer)
        Bl.Cambia_contratos(id_contrato, Estatus)
    End Sub
    <HttpPost()>
    Function Cancelaciones(ByVal numcte As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Dim Datos = Bl.CancelacionCliente(numcte)
                ReampleazaCancela(Datos)
                ViewBag.Visibilidad = "initial"
                ViewBag.URLExcel = "/Docs/Download.xlsx"
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Sub ReampleazaCancela(ByVal Datos As Servicio.CDatosCancelacion)

        FileCopy(Server.MapPath("\") + "Docs\FORMATO DEVOLUCION CONTABILIDAD.xlsx", Server.MapPath("\") + "Docs\Download.xlsx")

        Dim wordDoc As SpreadsheetDocument = SpreadsheetDocument.Open(Server.MapPath("\") + "Docs\Download.xlsx", True)


        Using (wordDoc)
            Dim docText As String = Nothing
            Dim sr As StreamReader = New StreamReader(wordDoc.WorkbookPart.SharedStringTablePart.GetStream)


            Using (sr)
                docText = sr.ReadToEnd
            End Using
            Dim Folio As Regex = New Regex("XXFOLIOXX")
            Dim Numcte As Regex = New Regex("XXNUMCTEXX")
            Dim NombreCliente As Regex = New Regex("XXNOMBRECLIENTEXX")
            Dim Frente As Regex = New Regex("XXFRENTEXX")
            Dim CC As Regex = New Regex("XXCCXX")
            Dim CantidadDevolucion As Regex = New Regex("XXCANTIDADDEVOLUCIONXX")
            Dim CantidadDevolucionPESOS As Regex = New Regex("XXCANTIDADDEVOLUCIONENPESOSXX")

            Dim Motivo As Regex = New Regex("XXMOTIVOXX")
            Dim SIONO As Regex = New Regex("XXSIONOXX")
            Dim RazonNoPenaliza As Regex = New Regex("XXRAZONNOPENALIZAXX")
            Dim PenalizacionCliente As Regex = New Regex("XXPCLIENTEXX")
            Dim Empleado As Regex = New Regex("XXEMPLEADOXX")
            Dim Nombreempleado As Regex = New Regex("XXNOMBREEMPLEADOXX")
            Dim FechaPagos As Regex = New Regex("XXFECHAPAGOEMPLEADOXX")
            Dim CantidadPagadaEmpleado As Regex = New Regex("XXCANTIDADEMPELADOXX")
            Dim PenalizacionAsesor As Regex = New Regex("XXPASESORXX")
            Dim NumLider As Regex = New Regex("XXNUMLIDERXX")
            Dim NombreLider As Regex = New Regex("XXNOMBRELIDERXX")
            Dim CantidadPagadaLider As Regex = New Regex("XXCANTIDADLIDERXX")
            Dim PenalizacionLider As Regex = New Regex("XXPLIDERXX")
            Dim NumeroGerente1 As Regex = New Regex("XXNUMGER1XX")
            Dim GerNom1 As Regex = New Regex("XXGERNOM1XX")
            Dim CantidadGerente1 As Regex = New Regex("XXCANTIDADGERENTE1XX")
            Dim PenalizacionGerente1 As Regex = New Regex("XXPGERENTE1XX")
            Dim NumGer2 As Regex = New Regex("XXNUMGER2XX")
            Dim GerNom2 As Regex = New Regex("XXGERNOM2XX")
            Dim CantidadGerente2 As Regex = New Regex("XXCANTIDADGERENTE2XX")
            Dim PenalizacionGerente2 As Regex = New Regex("XXPGERENTE2XX")


            docText = Folio.Replace(docText, Datos.Folio.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = Numcte.Replace(docText, Datos.Numcte.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = NombreCliente.Replace(docText, Datos.NombreCliente, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = Frente.Replace(docText, Datos.Frente, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CC.Replace(docText, Datos.CC, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CantidadDevolucion.Replace(docText, Datos.CantidadDeDevolucion.ToString(), RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CantidadDevolucionPESOS.Replace(docText, "(" + cantidad_Letras(Datos.CantidadDeDevolucion) + " PESOS 00/100 M.N.)", RegexOptions.Multiline, RegexOptions.IgnoreCase)

            docText = Motivo.Replace(docText, Datos.Motivo, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = SIONO.Replace(docText, If(Datos.PenalizacionCliente, "NO", "SI"), RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = RazonNoPenaliza.Replace(docText, Datos.RazonNoPenaliza, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = PenalizacionCliente.Replace(docText, Datos.PenalizacionCliente.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = Empleado.Replace(docText, Datos.Empleado.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = Nombreempleado.Replace(docText, Datos.NombreEmpleado, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = FechaPagos.Replace(docText, If(Datos.FechaPago = New Date, "-", Datos.FechaPago.ToShortDateString), RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CantidadPagadaEmpleado.Replace(docText, Datos.CantidadEmpleado.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = PenalizacionAsesor.Replace(docText, Datos.PenalizacionAsesor.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = NumLider.Replace(docText, Datos.NumLider.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = NombreLider.Replace(docText, Datos.NombreLider, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CantidadPagadaLider.Replace(docText, Datos.CantidadLider.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = PenalizacionLider.Replace(docText, Datos.PenalizacionLider.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = NumeroGerente1.Replace(docText, Datos.NumGer1.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = GerNom1.Replace(docText, Datos.NombreGerente1, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CantidadGerente1.Replace(docText, Datos.CantidadGerente1.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = PenalizacionGerente1.Replace(docText, Datos.PenalizacionGerente1.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = NumGer2.Replace(docText, Datos.NumGer2.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = GerNom2.Replace(docText, Datos.NombreGerente2, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = CantidadGerente2.Replace(docText, Datos.CantidadGerente2.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)
            docText = PenalizacionGerente2.Replace(docText, Datos.PenalizacionGerente2.ToString, RegexOptions.Multiline, RegexOptions.IgnoreCase)



            Dim sw As StreamWriter = New StreamWriter(wordDoc.WorkbookPart.SharedStringTablePart.GetStream(FileMode.Create))
            Using (sw)
                sw.Write(docText)
            End Using
        End Using
    End Sub
    Function Crea_datos_generales_del_cliente(ByVal Numcte As Integer) As String
        Dim HTML As String = ""
        Dim DatosCliente = Bl.Obtener_Datos_Generales_Cliente(Numcte)


        HTML += "   <div class=""portlet box purple "" > "
        HTML += "	<div class=""portlet-title"">"
        HTML += "		<div class=""caption"">"
        HTML += "			<i class=""fa fa-search""></i>Datos Generales del Cliente: " + DatosCliente.NombreCliente
        HTML += "		</div>							"
        HTML += "	</div>"
        HTML += "	<div class=""portlet-body util-btn-margin-bottom-5"">"
        HTML += "Numero del Cliente:" + DatosCliente.numcte.ToString
        HTML += "<br />"
        HTML += "Nombre completo del Cliente:" + DatosCliente.NombreCliente
        HTML += "<br />"
        HTML += "Numero de asesor que atiende a este cliente:" + DatosCliente.empleado.ToString
        HTML += "<br />"
        HTML += "Nombre completo del asesor que atiende a este cliente:" + DatosCliente.NombreEmpleado
        HTML += "<br />"
        HTML += "<img src=""http://192.168.1.17/Fotos%20Asesores/" + DatosCliente.empleado.ToString + ".jpg"" />"
        HTML += "<br />"
        HTML += "Lider del asesor:" + DatosCliente.LIDER
        HTML += "<br />"
        HTML += "Etapa Actual:" + DatosCliente.EtapaActual.ToString
        HTML += "<br />"
        HTML += "Estatus del Cliente:" + DatosCliente.status_cte
        HTML += "<br />"
        HTML += "Credito: " + Bl.Obtener_Credito_Porcentaje(DatosCliente.numcte)

        HTML += "<br />"
        HTML += "<br />"
        If DatosCliente.lote_id = 0 Then
            HTML += "-SIN Ubicación-"
        Else
            If IsNothing(DatosCliente.id_cve_fracc) Then
                HTML += "Clave de Fraccionamiento:-"
            Else
                HTML += "Clave de Fraccionamiento:" + DatosCliente.id_cve_fracc.ToString
            End If
            HTML += "<br />"
            HTML += "Numero interior:" + DatosCliente.id_num_lote.ToString
            HTML += "<br />"
            HTML += "Manzana:" + DatosCliente.id_num_mza
            HTML += "<br />"
            HTML += "Dirección de la casa:" + DatosCliente.dir_casa

        End If
        HTML += "<br />"

        HTML += "Valor Total(Casa+Terreno):" + DatosCliente.Valor_total.ToString("c")
        HTML += "<br />"
        HTML += "Valor Credito:" + DatosCliente.Valor_credito.ToString("c")
        HTML += "<br />"
        HTML += "	</div>"
        HTML += "</div>"
        Return HTML
    End Function
    Public Function Crea_tabla_Etapas(ByVal numcte As Integer) As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_Desgloce_Etapas_Cliente(numcte)

        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Desglose Etapas" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Etapas"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Nom_etapa" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_num_etapa" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Fec_inicio" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Fec_Liberacion" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Observaciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).Nom_etapa + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).id_num_etapa.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Fec_inicio.ToShortDateString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Fec_Liberacion.ToShortDateString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Observaciones + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function

    <HttpGet()>
    Function Obtener_Clientes_por_Nombre(ByVal nombre As String) As JsonResult
        Dim Clientes = Bl.buscarClienteAutoCompletar(nombre)
        Return Json(Clientes, JsonRequestBehavior.AllowGet)
    End Function
    Class CCliente
        Public Numcte As Integer
        Public name As String
    End Class
    Function AcumuladoAsesores() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Or Usuario.Nivel = 3 Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ReporteMovimientos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function ReporteMovimientos(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal Etapa As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("http://192.168.1.17/ReportesDX/ReporteMovimientos.aspx?Fini=" + FechaInicio.ToString("yyyy/MM/dd") + "&FFin=" + FechaFinal.ToString("yyyy/MM/dd") + "&Etapa=" + Etapa.ToString + "")
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function Crea_Reporte_Movimientos_HTML() As String
        Dim HTML As String = ""

        Return HTML
    End Function
    <HttpPost()>
    Function AcumuladoAsesores(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal Etapa As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Or Usuario.Nivel = 3 Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Response.Redirect("SELECT 	dba.sm_agente.empleado, 	dba.sm_agente.Abrev_agente, NombreCliente=(Nom_cte+' '+Ap_paterno_cte+' '+ap_materno_cte+' '), 	Direccion_Archivo AS Lider, 	dba.sm_cliente.id_cve_fracc, 	DATEPART(week,dba.sm_cliente_etapa.fec_liberacion)AS NSemana, 	COUNT(dba.sm_cliente.numcte) AS Cantidad FROM 	dba.sm_agente, 	dba.sm_cliente, 	dba.sm_cliente_etapa WHERE 	dba.sm_agente.empleado = dba.sm_cliente.empleado AND dba.sm_cliente.numcte = dba.sm_cliente_etapa.numcte AND dba.sm_cliente_etapa.id_num_etapa = " + Etapa.ToString + " AND dba.sm_cliente.status_cte != 'C' AND dba.sm_cliente_etapa.fec_liberacion BETWEEN '" + FechaInicio.ToString("yyyy/MM/dd") + "' AND '" + FechaFinal.ToString("yyyy/MM/dd") + "' GROUP BY 	dba.sm_cliente.id_cve_fracc, 	dba.sm_agente.empleado, 	dba.sm_agente.Abrev_agente, 	NSemana, NombreCliente, 	Direccion_Archivo;", False)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Sub Genera_PDF(ByVal HTML As String)

        Using myMemoryStream As New MemoryStream()
            Dim document As New iTextSharp.text.Document()
            Dim PDFWriter__1 As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, myMemoryStream)


            document.AddHeader("Content-Disposition", "attachment; filename=Reporte.pdf")

            document.Open()
            Dim styles As New iTextSharp.text.html.simpleparser.StyleSheet()
            Dim hw As New iTextSharp.text.html.simpleparser.HTMLWorker(document)

            If IsNothing(HTML) Then
                HTML = "Sin Registros"
            End If

            hw.Parse(New IO.StringReader(HTML))


            document.Close()
            Response.Buffer = False
            Response.Clear()
            Response.ClearContent()
            Response.ClearHeaders()

            Response.ContentType = "Application/pdf"
            Dim content As Byte() = myMemoryStream.ToArray()
            Response.BinaryWrite(content)
            Response.Flush()
            Response.End()
        End Using
    End Sub
#Region "BI"
    <HttpGet()>
    Function Obtener_Datos_Ingresados_X_Semana(ByVal finicio As String, ByVal ffinal As String) As JsonResult
        Dim Datos As Servicio.CGraficoBI()
        Datos = Bl.Obtener_Ingresados_por_semana(finicio, ffinal)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_Datos_Ventas_X_Semana(ByVal finicio As String, ByVal ffinal As String) As JsonResult
        Dim Datos As Servicio.CDatosVentaSemanal()
        Datos = Bl.Obtener_Ventas_Por_Semana_Entre_Fechas(finicio, ffinal)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_VentasUbicadas(ByVal finicio As String, ByVal ffinal As String) As Integer
        Try
            Return Bl.Obtener_Total_Vendido_Ubicado(finicio, ffinal)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    <HttpGet()>
    Function Obtener_Habitables(ByVal finicio As String, ByVal ffinal As String) As Integer
        Try
            Return Bl.Obtener_Total_habitabilidad(finicio, ffinal)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    <HttpGet()>
    Function Obtener_Habitabilidad_X_Semana(ByVal finicio As String, ByVal ffinal As String) As JsonResult
        Dim Datos As Servicio.CDatosVentaSemanal()
        Datos = Bl.Obtener_Habitabilidad_Por_Semana_Entre_Fechas(finicio, ffinal)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_Ventas_X_Semana(ByVal finicio As String, ByVal ffinal As String) As JsonResult
        Dim Datos As Servicio.CDatosVentaSemanal()
        Datos = Bl.Obtener_Ventas_Por_Semana_Entre_Fechas_Barras(finicio, ffinal)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_Firmas_X_Semana(ByVal finicio As String, ByVal ffinal As String) As JsonResult
        Dim Datos As Servicio.CDatosVentaSemanal()
        Datos = Bl.Obtener_Firmas_X_Semana_Entre_Fechas(finicio, ffinal)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_VentasXSemanaLM(ByVal finicio As String) As JsonResult
        Dim Datos As Servicio.CGraficoBI()
        Datos = Bl.Obtener_VentasLM_BI(finicio)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_AcumuladoEscrituradoLM(ByVal finicio As String) As JsonResult
        Dim Datos As Servicio.CGraficoBI()
        Datos = Bl.Obtener_EscrituradosAcumuladoLM_BI(finicio)
        Return Json(Datos, "", JsonRequestBehavior.AllowGet)
    End Function
    <HttpGet()>
    Function Obtener_Cancelados(ByVal finicio As String, ByVal ffinal As String) As Integer
        Try
            Return Bl.Obtener_Total_Cancelados_o_SinUbicacion(finicio, ffinal)
        Catch ex As Exception
            Return 0
        End Try
    End Function
#End Region

    Public Function ComisionesValores() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.tablaValores = Crea_TablaValores()
               
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Public Function CambiaValor(ByVal id_valor As Integer, ByVal valor As Double) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

                If Bl.Actualiza_comisiones_porcentajes(id_valor, valor) Then
                    Return RedirectToAction("ComisionesValores", "Administrativo")
                End If
            
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function

    Public Function CambiaValor(ByVal id_valor As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Dim Valores = Bl.Obtener_comisiones_porcentajes(id_valor)
                ViewBag.idValor = Valores(0).id_porcentaje.ToString
                ViewBag.Valor = Valores(0).Porcentaje.ToString
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Public Function Crea_TablaValores() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_Valores_Comisiones()
        Session("Valores") = Datos
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Valores" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Valores"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_porcentaje" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Descripcion_porcentaje" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Porcentaje" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Opciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_porcentaje.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).Descripcion_porcentaje + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Porcentaje + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/CambiaValor?id_valor=" + Datos(I).id_porcentaje.ToString + """ class=""btn btn-xs green"">Cambiar</a>   " + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function

    Function Clasificaciones() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.tablaclasificaciones = Crea_tabla_Clasificaciones()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function NuevaClasificacion() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function NuevaClasificacion(ByVal desc_clasificacion As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then

                If Bl.Inserta_comisiones_clasificaciones(desc_clasificacion) Then
                    Return RedirectToAction("Clasificaciones", "Administrativo")
                Else
                    ViewBag.Mensaje = "Error por favor verifique e intente nuevamente"
                End If

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function EliminaClasificacion(ByVal id_clasificacion As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                If Bl.Elimina_comisiones_clasificaciones(id_clasificacion) Then
                    Return RedirectToAction("Clasificaciones", "Administrativo")
                Else
                    ViewBag.Mensaje = "Error registro en uso"
                End If
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function CambiaClasificacion(ByVal id_clasificacion As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.TablaClasificaciones = Crea_tabla_Relacion(id_clasificacion)
                ViewBag.dbesquemas = crea_db_esquemas(id_clasificacion)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function Elimina_ComisionesClasificacion(ByVal id_registro As Integer) As Boolean
        Try
            Bl.Elimina_comisiones_esquemas(id_registro)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    <HttpPost()>
    Function Agregar_esquema(ByVal id_clasificacion As Integer, ByVal id_esquema As Integer) As Boolean
        Try
            Bl.Inserta_comisiones_esquemas(id_esquema, id_clasificacion)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Function Reglas() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.TablaReglas = Crea_Tabla_ReglasComisiones()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function NuevaRegla() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.Formulario = Crea_formulario()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ConfiguraAdministrativos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function ConfiguraGerencia() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then

            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function NuevaRegla(ByVal empleado As Integer, ByVal id_clasificacion As Integer, ByVal etapaFinal As Integer, ByVal Cantidad_PagoUnitario As Integer) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then

                If Bl.Inserta_comisiones_reglas(empleado, id_clasificacion, etapaFinal, Cantidad_PagoUnitario) Then
                    Return RedirectToAction("Reglas", "Administrativo")
                Else
                    ViewBag.Mensaje = "Error verifique los datos y reintente"
                End If
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function Elimina_Regla(ByVal id_regla As Integer) As Boolean
        Try
            Bl.Elimina_comisiones_reglas(id_regla)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Function Crea_formulario() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_comisiones_clasificaciones
        HTML += "      <form method=""post"">"
        HTML += "    ingrese el N. de Empleado que aplicara esta regla de comisión"
        HTML += "    <br />"
        HTML += "    <input type=""number"" required=""required"" name=""empleado"" />"
        HTML += "    <br />"
        HTML += "    Seleccione la Clasificacion para este asesor"
        HTML += "    <br />"
        HTML += "   <select name=""id_clasificacion"" required=""required"">"
        For I = 0 To Datos.Count - 1
            HTML += "       <option value=""" + Datos(I).id_clasificacion.ToString + """>" + Datos(I).DescripcionClasificacion + "</option>"
        Next
        HTML += "   </select>"
        HTML += "   <br /> "
        HTML += "    Ingrese la etapa que Final que actuara en esta regla"
        HTML += "   <br />"
        HTML += "    <input type=""number"" required=""required"" name=""etapaFinal"" />"
        HTML += "    <br />"
        HTML += "      Ingrese la cantiad unitaria del pago por cada cliente que pase la etapa FINAL"
        HTML += "   <br />"
        HTML += "    <input type=""number"" required=""required"" name=""Cantidad_PagoUnitario"" />"
        HTML += "   <br />"
        HTML += "    <input type=""submit"" value=""Guardar"" />"
        HTML += "    <br />"
        HTML += "</form>"
        Return HTML
    End Function
    Public Function Crea_tabla_Clasificaciones() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_comisiones_clasificaciones()
        'Session("Clasificaciones") = Datos
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Clasificaciones" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Clasificaciones"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_clasificacion" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "DescripcionClasificacion" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Opciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_clasificacion.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).DescripcionClasificacion + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/CambiaClasificacion?id_clasificacion=" + Datos(I).id_clasificacion.ToString + """ class=""btn btn-xs green"">Cambiar</a>   " + vbCrLf
            HTML += " <a href=""" + Ruta_Archivo + "Administrativo/EliminaClasificacion?id_clasificacion=" + Datos(I).id_clasificacion.ToString + """ class=""btn btn-xs red"">Eliminar</a>   " + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function
    Public Function Crea_tabla_Relacion(ByVal id_clasificacion As Integer) As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_comisiones_esquema(id_clasificacion)        
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Relación" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Relación"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_registro" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_esquema" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Eliminar" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_registro.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_esquema.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " <button class=""btn btn-xs red"" onclick=""Elimina(" + Datos(I).id_registro.ToString + ")"">Eliminar</button>" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function
    Function crea_db_esquemas(ByVal id_clasificacion As Integer) As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_esquemas_enkontrol

        HTML = "<input type=""hidden"" value=""" + id_clasificacion.ToString + """ id=""idclas""/>" + vbCrLf
        HTML += "   <select required=""required"" id=""esquema"" class=""form-control"" >"
        For I = 0 To Datos.Count - 1
            HTML += "<option value=""" + Datos(I).id_num_relacion.ToString + """>(" + Datos(I).id_num_relacion.ToString + ") " + Datos(I).Nom_Financinst + "</option>" + vbCrLf
        Next

        HTML += "</select>" + vbCrLf
        Return HTML
    End Function
    Public Function Crea_Tabla_ReglasComisiones() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_Reglas_Comisiones()
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>ReglasComisiones" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""ReglasComisiones"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "id_regla" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "empleado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "id_clasificacion" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "etapaFinal" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Cantidad_PagoUnitario" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Opciones" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).id_regla.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += "" + Datos(I).empleado.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).id_clasificacion.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).etapaFinal.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Cantidad_PagoUnitario.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " <button class=""btn btn-xs red"" onclick=""Elimina(" + Datos(I).id_regla.ToString + ")"">Eliminar</button>" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function
End Class
