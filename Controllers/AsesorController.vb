Imports System.IO

Public Class AsesorController
    Inherits System.Web.Mvc.Controller

    ' GET: /Asesor
    Private Nivel_Seccion As Integer = 1
    Function Index() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Empleado = Usuario.Empleado
                ViewBag.TablaAsesores = Crea_tabla_asesores_activos()
                ViewBag.UltimasNotificaciones = GetUltimasNotificaciones(Usuario.Empleado)
                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If


    End Function
    Function PosiblePenalizar() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Empleado = Usuario.Empleado

                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If


    End Function
    Function Historico() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

                ViewBag.IFrame = "<iframe src=""http://192.168.1.17/DevProconsul/ExtensionesProConsul/HistoricoComisiones.aspx?empleado=" + Usuario.Empleado.ToString + """ width=""100%"" style=""border:none;height: 800px"" />    "

                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If


    End Function
    Public Function Crea_tabla_asesores_activos() As String
        Dim HTML As String = ""
        Dim Datos = Bl.Obtener_Asesores_Activos()
        Session("Asesores") = Datos
        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Tabla de Asesores Activos" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""Asesores"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Empleado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th>" + vbCrLf
        HTML += "Nom_Empleado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Ap_Paterno_Empleado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Ap_Materno_Empleado" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "Lider" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf
        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).Empleado.ToString + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td>" + vbCrLf
            HTML += " " + Datos(I).Nom_Empleado + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Ap_Paterno_Empleado + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Ap_Materno_Empleado + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "	<td class=""hidden-xs"">" + vbCrLf
            HTML += " " + Datos(I).Lider + "" + vbCrLf
            HTML += "	</td>" + vbCrLf
            HTML += "</tr>							" + vbCrLf
        Next
        HTML += "	</tbody>" + vbCrLf
        HTML += "	</table>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "</div>" + vbCrLf
        Return HTML
    End Function
    Function GetUltimasNotificaciones(ByVal Empleado As Integer) As String
        Dim HTML As String = ""
        Dim Notificaciones() As ProConsul_Metronic_2._01.Servicio.CUltimasNotificaciones
        Try
            Notificaciones = Bl.Obtener_ultimas_Notificaciones(Empleado)
        Catch ex As Exception

        End Try

        HTML += "    <li class=""dropdown dropdown-extended dropdown-notification"" id=""header_notification_bar"">"
        HTML += "	<a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" data-hover=""dropdown"" data-close-others=""true"">"
        HTML += "	<i class=""fa fa-globe""></i>					"
        HTML += "	</a>"
        HTML += "	<ul class=""dropdown-menu"">"
        HTML += "		<li>"
        HTML += "			<p>"
        HTML += "				 Ultimas notificaciones"
        HTML += "			</p>"
        HTML += "		</li>"
        If IsNothing(Notificaciones) Then
            HTML += "<li>-Sin notificaciones-</li>"
        Else
            If Notificaciones.Count = 0 Then
                HTML += "<li>-Sin notificaciones-</li>"
            Else
                For I = 0 To Notificaciones.Count - 1
                    HTML += "		<li>"
                    HTML += "			<ul class=""dropdown-menu-list scroller"" style=""height: 250px;"">"
                    HTML += "				<li>"
                    HTML += "					<a href=""#"">"
                    HTML += "					<span class=""label label-sm label-icon label-success"">"
                    HTML += "					<i class=""fa fa-globe""></i>"
                    HTML += "					</span>"
                    HTML += "					" + Notificaciones(I).Mensaje + " <span class=""time"">"
                    HTML += "					" + Notificaciones(I).FechaUltima.ToShortTimeString + "-" + Notificaciones(I).FechaUltima.ToShortDateString + " </span>"
                    HTML += "					</a>"
                    HTML += "				</li>								"
                    HTML += "			</ul>"
                    HTML += "		</li>"
                Next
            End If
        End If
        HTML += "		<li class=""external"">"
        HTML += "			<a href=""#"">"
        HTML += "			Ir a notificaciones <i class=""m-icon-swapright""></i>"
        HTML += "			</a>"
        HTML += "		</li>"
        HTML += "	</ul>"
        HTML += "</li>"
        Return HTML
    End Function
#Region "Notificaciones"
    Function CentroDeNotificaciones() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.UltimasNotificaciones = GetUltimasNotificaciones(Usuario.Empleado)



                ViewBag.Notificaciones = CreaListaNotificaciones(Usuario.Empleado)


                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If


    End Function
    Function CreaListaNotificaciones(ByVal Empleado As String) As String
        Dim Notificaciones = Bl.Obtener_ultimas_Notificaciones(Empleado)
        Dim HTML As String = ""
        HTML += "        	<div class=""col-md-6 col-sm-6"">"
        HTML += "					<!-- BEGIN PORTLET-->"
        HTML += "					<div class=""portlet light"">"
        HTML += "						<div class=""portlet-title tabbable-line"">"
        HTML += "							<div class=""caption"">"
        HTML += "								<i class=""icon-globe font-green-sharp""></i>"
        HTML += "								<span class=""caption-subject font-green-sharp bold uppercase"">Notificaciones</span>"
        HTML += "							</div>"
        HTML += "							<ul class=""nav nav-tabs"">"
        HTML += "								<li class=""active"">"
        HTML += "									<a href=""#tab_1_1"" data-toggle=""tab"">"
        HTML += "									Ultimas </a>"
        HTML += "								</li>								"
        HTML += "							</ul>"
        HTML += "						</div>"
        HTML += "						<div class=""portlet-body"">"
        HTML += "							<!--BEGIN TABS-->"
        HTML += "							<div class=""tab-content"">"
        HTML += "								<div class=""tab-pane active"" id=""tab_1_1"">"
        HTML += "									<div class=""scroller"" style=""height: 339px;"" data-always-visible=""1"" data-rail-visible=""0"">"
        HTML += "										<ul class=""feeds"">"



        If Notificaciones.Count = 0 Or IsNothing(Notificaciones) Then
            HTML += "SIN NOTIFICACIONES"
        Else
            For I = 0 To Notificaciones.Count - 1
                HTML += "											<li>"
                HTML += "												<div class=""col1"">"
                HTML += "													<div class=""cont"">"
                HTML += "														<div class=""cont-col1"">"
                HTML += "															<div class=""label label-sm label-success"">"
                HTML += "																<i class=""fa fa-bell-o""></i>"
                HTML += "															</div>"
                HTML += "														</div>"
                HTML += "														<div class=""cont-col2"">"
                HTML += "															<div class=""desc"">"
                HTML += Notificaciones(I).Mensaje
                HTML += "															</div>"
                HTML += "														</div>"
                HTML += "													</div>"
                HTML += "												</div>"
                HTML += "												<div class=""col2"">"
                HTML += "													<div class=""date"">"
                HTML += Notificaciones(I).FechaUltima.ToLongTimeString + "(" + Notificaciones(I).FechaUltima.ToShortDateString + ")"
                HTML += "													</div>"
                HTML += "												</div>"
                HTML += "											</li>      							"
            Next
        End If



        HTML += "										</ul>"
        HTML += "									</div>"
        HTML += "								</div>"
        HTML += "							</div>"
        HTML += "							<!--END TABS-->"
        HTML += "						</div>"
        HTML += "					</div>"
        HTML += "					<!-- END PORTLET-->"
        HTML += "				</div>"
        HTML += "			</div>"
        Return HTML
    End Function
#End Region
#Region "Clientes Activos"
    Function Activos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Empleado = Usuario.Empleado
                'ViewBag.tabla = Crea_TablaActivos()
                ViewBag.tabla = "<iframe src=""http://192.168.1.17/DevProconsul/ExtensionesProConsul/ClientesActivos.aspx?Emp=" + Usuario.Empleado.ToString + """ width=""100%"" style=""border:none;height: 800px"" />    "
                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

    End Function
    <HttpPost()>
    Sub Genera_PDF_Activos()
        Dim Html
        Try
            Html = ConvertDataTableToHTML(ConvertToDataTable(Session("DatosActivos")))
        Catch ex As Exception
            Html = "Sin Registros: " + ex.Message
        End Try

        Using myMemoryStream As New MemoryStream()
            Dim document As New iTextSharp.text.Document()
            Dim PDFWriter__1 As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, myMemoryStream)


            document.AddHeader("Content-Disposition", "attachment; filename=wissalReport.pdf")

            document.Open()
            Dim styles As New iTextSharp.text.html.simpleparser.StyleSheet()
            Dim hw As New iTextSharp.text.html.simpleparser.HTMLWorker(document)

            If IsNothing(Html) Then
                Html = "Sin Registros"
            End If

            hw.Parse(New IO.StringReader(Html))


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
    Function Crea_TablaActivos() As String
        Dim HTML As String = ""
        Dim Usuario As New Servicio.CUsuario
        Usuario = Session("Usuario")
        If Usuario.Nivel >= Nivel_Seccion Then
            Dim Datos = Bl.Obtener_Clientes_Activos(Usuario.Empleado)
            Session("DatosActivos") = Datos

            HTML = "<div class=""portlet box green-haze"">" + vbCrLf
            HTML += "	<div class=""portlet-title"">" + vbCrLf
            HTML += "		<div class=""caption"">" + vbCrLf
            HTML += "			<i class=""fa fa-globe""></i>Clientes activos de: " + Usuario.Nombre_Usuario + vbCrLf
            HTML += "		</div>" + vbCrLf
            HTML += "		<div class=""tools"">" + vbCrLf
            HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
            HTML += "			</a>" + vbCrLf
            HTML += "		</div>" + vbCrLf
            HTML += "	</div>" + vbCrLf
            HTML += "	<div class=""portlet-body"">" + vbCrLf
            HTML += " <table class=""table table-striped table-bordered table-hover"" id=""sample_2"">" + vbCrLf
            HTML += "<thead>" + vbCrLf
            HTML += "<tr>" + vbCrLf
            HTML += "	<th class=""hidden-xs"">" + vbCrLf
            HTML += "  Numcte" + vbCrLf
            HTML += "	</th>" + vbCrLf
            HTML += "<th>" + vbCrLf
            HTML += "	 Nombre del Cliente" + vbCrLf
            HTML += "	</th>" + vbCrLf
            HTML += "<th class=""hidden-xs"">" + vbCrLf
            HTML += "  #Lote" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "	<th class=""hidden-xs"">" + vbCrLf
            HTML += "	 Manzana" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "	<th class=""hidden-xs"">" + vbCrLf
            HTML += "	 CC" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "	<th class=""hidden-xs"">" + vbCrLf
            HTML += "	 Fracc" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "	<th class=""hidden-xs"">" + vbCrLf
            HTML += "	 Dir Casa" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "<th class=""hidden-xs"">" + vbCrLf
            HTML += "Numero de Etapa" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "<th>" + vbCrLf
            HTML += "Etapa" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "<th class=""hidden-xs"">" + vbCrLf
            HTML += "Valor Credito " + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "<th class=""hidden-xs"">" + vbCrLf
            HTML += "Valor Total" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "<th class=""hidden-xs"">" + vbCrLf
            HTML += "Cuenta Deposito" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "<th class=""hidden-xs"">" + vbCrLf
            HTML += "Numero oficial" + vbCrLf
            HTML += "</th>" + vbCrLf
            HTML += "</tr>" + vbCrLf
            HTML += "</thead>" + vbCrLf
            HTML += "<tbody>" + vbCrLf

            For I = 0 To Datos.Count - 1
                HTML += "<tr>" + vbCrLf
                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).numcte.ToString + vbCrLf
                HTML += "</td>" + vbCrLf
                HTML += "<td>" + vbCrLf
                HTML += Datos(I).NombreCliente + vbCrLf
                HTML += "</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).lote_id.ToString + vbCrLf
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).id_num_mza.ToString + vbCrLf
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                Try
                    HTML += Datos(I).CC.ToString + vbCrLf
                Catch ex As Exception
                    HTML += "" + vbCrLf
                End Try
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                Try
                    HTML += Datos(I).Fracc.ToString + vbCrLf
                Catch ex As Exception
                    HTML += "" + vbCrLf
                End Try
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                Try
                    HTML += Datos(I).DirCasa.ToString + vbCrLf
                Catch ex As Exception
                    HTML += "" + vbCrLf
                End Try
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).id_num_etapa.ToString + vbCrLf
                HTML += "			</td>" + vbCrLf

                HTML += "<td>" + vbCrLf
                HTML += Datos(I).nom_etapa + vbCrLf
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).Valor_credito.ToString + vbCrLf
                HTML += "			</td>" + vbCrLf

                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).Valor_Total.ToString + vbCrLf
                HTML += "			</td>" + vbCrLf
                Try
                    HTML += "<td class=""hidden-xs"">" + vbCrLf
                    HTML += Bl.Obtener_cuentaDepodito_Cte(Datos(I).numcte).ToString + vbCrLf
                    HTML += "			</td>" + vbCrLf
                Catch ex As Exception
                    HTML += "<td class=""hidden-xs"">" + vbCrLf
                    HTML += "-"
                    HTML += "			</td>" + vbCrLf
                End Try


                HTML += "<td class=""hidden-xs"">" + vbCrLf
                HTML += Datos(I).NumeroOficial.ToString + vbCrLf
                HTML += "			</td>" + vbCrLf

                HTML += "</tr>							" + vbCrLf
            Next



            HTML += "	</tbody>" + vbCrLf
            HTML += "	</table>" + vbCrLf


            HTML += "	</div>" + vbCrLf
            HTML += "</div>" + vbCrLf


            Return HTML

        Else
            Return "Sin Permisos"
        End If
    End Function
#End Region
#Region "Comisiones"
    Function EstadoCuenta() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If
    End Function
    Function ReporteSemanal() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If
    End Function
    <HttpPost()>
    Function EstadoCuenta(Optional ByVal FInicio As Date = Nothing, Optional ByVal FFinal As Date = Nothing) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        If IsNothing(FInicio) Or IsNothing(FFinal) Then
        Else
            Dim Usuario As New Servicio.CUsuario
            If IsNothing(Session("Usuario")) Then
                Return RedirectToAction("Login", "Account")
            Else
                Usuario = Session("Usuario")
                If Usuario.Nivel >= Nivel_Seccion Then

                    ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                    If Now.DayOfWeek = DayOfWeek.Friday Or Now.DayOfWeek = DayOfWeek.Saturday Or Now.DayOfWeek = DayOfWeek.Sunday Then
                        ViewBag.tabla = Crea_Tabla(FInicio, FFinal) + "<br />  <form action=""Genera_PDF"" method=""post""><input type=""submit"" value=""Imprimir"" class=""btn btn-lg red""/></form>"
                    Else
                        ViewBag.tabla = "<strong> Estimado asesor te recordamos que los reportes de comisiones solo se pueden consultar de VIERNES A DOMINGO para evitar que se vea información previa a los pagos. Gracias</strong>"
                    End If


                    Return View()
                Else
                    Session.Clear()
                    Return RedirectToAction("Login", "Account")
                End If
            End If
        End If
        Return RedirectToAction("EstadoCuenta", "Asesor")
    End Function
    <HttpPost()>
    Sub Genera_PDF()
        Dim Html
        Try
            Html = ConvertDataTableToHTML(ConvertToDataTable(Session("ReporteEstadoCuenta")))
        Catch ex As Exception
            Html = "Sin Registros: " + ex.Message
        End Try

        Using myMemoryStream As New MemoryStream()
            Dim document As New iTextSharp.text.Document()
            Dim PDFWriter__1 As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, myMemoryStream)


            document.AddHeader("Content-Disposition", "attachment; filename=wissalReport.pdf")

            document.Open()
            Dim styles As New iTextSharp.text.html.simpleparser.StyleSheet()
            Dim hw As New iTextSharp.text.html.simpleparser.HTMLWorker(document)

            If IsNothing(Html) Then
                Html = "Sin Registros"
            End If

            hw.Parse(New IO.StringReader(Html))


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
    Sub Genera_ReporteSemanal()
        Dim Html
        Dim Datos
        Dim Usuario As New Servicio.CUsuario
        Try
            Usuario = Session("Usuario")
            Datos = Bl.Obtener_reporte_semanal(Usuario.Empleado)
            If Now.DayOfWeek = DayOfWeek.Friday Or Now.DayOfWeek = DayOfWeek.Saturday Or Now.DayOfWeek = DayOfWeek.Sunday Then
                Html = ConvertDataTableToHTML(ConvertToDataTable(Datos))
            Else
                Html = "<strong>Estimado asesor te recordamos que los reportes de comisiones solo se pueden consultar de VIERNES A DOMINGO para evitar que se vea información previa a los pagos. Gracias</strong>"
            End If

        Catch ex As Exception
            Html = "Sin Registros"
        End Try

        Using myMemoryStream As New MemoryStream()
            Dim document As New iTextSharp.text.Document()
            Dim PDFWriter__1 As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, myMemoryStream)


            document.AddHeader("Content-Disposition", "attachment; filename=wissalReport.pdf")

            document.Open()
            Dim styles As New iTextSharp.text.html.simpleparser.StyleSheet()
            Dim hw As New iTextSharp.text.html.simpleparser.HTMLWorker(document)

            If IsNothing(Html) Then
                Html = "Sin Registros"
            End If

            hw.Parse(New IO.StringReader(Html))


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
    Public Function Crea_Tabla(ByVal FInicio As Date, ByVal FFinal As Date) As String
        Dim HTML As String = ""
        Dim Usuario As New Servicio.CUsuario
        Usuario = Session("Usuario")
        Dim Datos = Bl.Obtener_Estado_de_Cuenta(FInicio, FFinal, Usuario.Empleado)
        Session("ReporteEstadoCuenta") = Datos


        HTML = "<div class=""portlet box green-haze"">" + vbCrLf
        HTML += "	<div class=""portlet-title"">" + vbCrLf
        HTML += "		<div class=""caption"">" + vbCrLf
        HTML += "			<i class=""fa fa-globe""></i>Comisiones entre fechas: " + FInicio.ToShortDateString + " al " + FFinal.ToShortDateString + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "		<div class=""tools"">" + vbCrLf
        'HTML += "			<a href=""javascript:;"" class=""reload"">" + vbCrLf
        'HTML += "			</a>" + vbCrLf
        HTML += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        HTML += "			</a>" + vbCrLf
        HTML += "		</div>" + vbCrLf
        HTML += "	</div>" + vbCrLf
        HTML += "	<div class=""portlet-body"">" + vbCrLf
        HTML += " <table class=""table table-striped table-bordered table-hover"" id=""sample_2"">" + vbCrLf
        HTML += "<thead>" + vbCrLf
        HTML += "<tr>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "  Numcte" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "<th>" + vbCrLf
        HTML += "	 Nombre del Cliente" + vbCrLf
        HTML += "	</th>" + vbCrLf
        HTML += "<th class=""hidden-xs"">" + vbCrLf
        HTML += "  Fecha Pago" + vbCrLf
        HTML += "</th>" + vbCrLf
        HTML += "	<th class=""hidden-xs"">" + vbCrLf
        HTML += "	 Tipo de Pago" + vbCrLf
        HTML += "</th>" + vbCrLf
        HTML += "<th>" + vbCrLf
        HTML += "Cantidad Pagada" + vbCrLf
        HTML += "</th>" + vbCrLf
        HTML += "</tr>" + vbCrLf
        HTML += "</thead>" + vbCrLf
        HTML += "<tbody>" + vbCrLf

        For I = 0 To Datos.Count - 1
            HTML += "<tr>" + vbCrLf
            HTML += "<td class=""hidden-xs"">" + vbCrLf
            HTML += Datos(I).Numcte.ToString + vbCrLf
            HTML += "</td>" + vbCrLf
            HTML += "<td>" + vbCrLf
            HTML += Datos(I).NombreCliente + vbCrLf
            HTML += "</td>" + vbCrLf
            HTML += "<td class=""hidden-xs"">" + vbCrLf
            HTML += Datos(I).Fecha_pago.ToShortDateString + vbCrLf
            HTML += "			</td>" + vbCrLf
            HTML += "			<td class=""hidden-xs"">" + vbCrLf
            HTML += Datos(I).TipoPago + vbCrLf
            HTML += "		</td>" + vbCrLf
            HTML += "		<td>" + vbCrLf
            HTML += Datos(I).Cantidad_Pagada.ToString("c") + vbCrLf
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
#Region "Contratos"
    Function Contratos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        ' Dim Usuario As New Servicio.CUsuario
        'If IsNothing(Session("Usuario")) Then
        '    'Return RedirectToAction("Login", "Account")
        'Else
        ' Usuario = Session("Usuario")
        ' If Usuario.Nivel >= Nivel_Seccion Then
        'ViewBag.NombreUsuario = Usuario.Nombre_Usuario
        ViewBag.selFracc = Crea_selFracc()
        ViewBag.TipoCredito = Crea_selCreditos()
        'ViewBag.Bono = Crea_comboBono()
        'If Usuario.Nivel = 4 Then
        '    ViewBag.admopc = "<input type=""text"" name=""AdAdmin"" class=""form-control"" placeholder=""Texto de Adicional (Solo Admn)"" /><br /><input type=""number"" name=""adCanAdmin"" class=""form-control"" placeholder=""Cantidad que será sumada al precio (Solo admin)"" />"

        'End If
        Return View()
        'Else
        Session.Clear()
        Return RedirectToAction("Login", "Account")
        '   End If
        'End If
    End Function
    <HttpPost()>
    Function Contratos(ByVal selCredito As Integer, ByVal selFracc As String, ByVal selManzana As String, Optional ByVal selTerreno As Double = 0, Optional ByVal nombrecliente As String = "",
                       Optional ByVal mAdicional As Double = 0, Optional ByVal cantidadAhorro As Integer = 0, Optional ByVal selPromocion As Integer = 0, Optional ByVal selPromContra As Integer = 0, Optional selBono As Integer = 0,
                       Optional AdAdmin As String = "", Optional adCanAdmin As Integer = 0, Optional ByVal NLote As String = "", Optional ByVal NManzana As String = "", Optional DirCasa As String = "",
                       Optional ByVal fechaDTUX As Date = #1/1/2000#, Optional ByVal DirActual As String = "", Optional ByVal DirCompra As String = "", Optional ByVal plazoTerr As Integer = 0, Optional ByVal cb_sorteado As Integer = 0) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        Dim nombredearchivo As String = ""
        'If IsNothing(Session("Usuario")) Then
        '    Return RedirectToAction("Login", "Account")
        'Else
        '    Usuario = Session("Usuario")
        '    If Usuario.Nivel >= Nivel_Seccion Then

        nombredearchivo = Generar_Contrato_Web(selCredito, selFracc, selManzana, selTerreno, nombrecliente, mAdicional, cantidadAhorro, selPromocion, selPromContra, selBono, AdAdmin, adCanAdmin, NLote, NManzana, DirCasa, fechaDTUX, DirActual, DirCompra, plazoTerr, cb_sorteado)
        'Response.Write("<script>")
        'Response.Write("window.open('http://192.168.1.17/SolCred/Docs/SIC2.pdf','_blank')")
        'Response.Write("</script>")
        'Response.Write("<script>")
        'Response.Write("window.open('http://192.168.1.17/Contratos/Download/" + nombredearchivo + "','_blank')")
        'Response.Write("</script>")
        Response.Redirect("/Contratos/Download/" + nombredearchivo, False)

        ViewBag.NombreUsuario = Usuario.Nombre_Usuario
        'ViewBag.selFracc = Crea_selFracc()
        ViewBag.TipoCredito = Crea_selCreditos()
        Return View()
        '    Else
        'Session.Clear()
        'Return RedirectToAction("Login", "Account")
        '  End If
        ' End If
    End Function
    <HttpPost()>
    Function Crea_campos_contado() As String
        Dim HTML As String = ""
        HTML += "<input type=""text"" name=""NLote"" placeholder=""Numero de Lote"" class=""form-control"" required=""required""/>"
        HTML += "<br />"
        HTML += "  <br />"
        HTML += "<input type=""text"" name=""NManzana"" placeholder=""Numero de Manzana"" class=""form-control"" required=""required""/>"
        HTML += "<br />"
        HTML += "  <br />"
        HTML += "<input type=""text"" name=""DirCasa"" placeholder=""Dirección de la casa y Numero Oficial"" class=""form-control"" required=""required""/>"
        HTML += "<br />"
        HTML += "  <br />"
        HTML += "<input type=""date"" name=""fechaDTUX"" placeholder=""Fecha de Entrega"" class=""form-control"" required=""required""/>"
        Return HTML
    End Function
    <HttpPost()>
    Function Crea_Promocion(ByVal CC As String, Optional ByVal smza As String = "") As String
        Dim HTML As String = ""
        Dim Equipamientos = Bl.Obtener_Equipamientos(CC, smza)

        HTML = "<select name=""selPromocion"" required=""required"" id=""selPromocion"" class=""form-control"">" + vbCrLf
        HTML += "<option selected=""selected"" value=""0"">- Sin equipamientos -</option>"
        For I = 0 To Equipamientos.Count - 1
            HTML += "<option  value=""" + Equipamientos(I).id_promocion.ToString + """>" + Equipamientos(I).TextoCombo + "</option>"
        Next

        HTML += "</select>"
        Return HTML
    End Function
    <HttpPost()>
    Function Crea_Promocion_contrato(ByVal CC As String, Optional ByVal smza As String = "") As String
        Dim HTML As String = ""
        Dim Equipamientos = Bl.Obtener_promociones(CC, smza)

        HTML = "<select name=""selPromContra"" required=""required"" id=""selPromContra"" class=""form-control"">" + vbCrLf
        HTML += "<option selected=""selected"" value=""0"">- Sin Promocion -</option>"
        For I = 0 To Equipamientos.Count - 1
            HTML += "<option  value=""" + Equipamientos(I).id_promocion.ToString + """>" + Equipamientos(I).textoCombo + "</option>"
        Next

        HTML += "</select>"
        Return HTML
    End Function
    Function Crea_campoAhorro() As String
        Dim HTML As String = ""
        HTML = "<input type=""number"" required=""required"" class=""form-control"" name=""cantidadAhorro"" placeholder=""Cantidad Ahorro"" />  " + vbCrLf
        Return HTML
    End Function
    <HttpPost()>
    Function Crea_comboBono(ByVal CC As String) As String
        Dim HTML As String = ""
        Dim Creditos = Bl.Obtener_Tipos_de_Credito()
        Dim cantidad = 500
        Dim Maxima As Integer = 0

        Maxima = Bl.Obtener_limite_bonoContrato(CC)

        HTML = "<select name=""selBono"" required=""required"" id=""selBono"" class=""form-control"" >" + vbCrLf
        HTML += "<option value=""0"">- Sin Ahorro -</option>"
        While cantidad <= Maxima
            HTML += "<option value=""" + cantidad.ToString + """>" + cantidad.ToString("c") + " de Ahorro </option>"
            cantidad += 500
        End While
        HTML += "</select>"
        Return HTML
    End Function
    Function Crea_selCreditos() As String
        Dim HTML As String = ""
        Dim Creditos = Bl.Obtener_Tipos_de_Credito()

        HTML = "<select name=""selCredito"" required=""required"" id=""selCredito"" class=""form-control"" onchange=""ActivaAhorro()"" >" + vbCrLf
        For I = 0 To Creditos.Count - 1
            HTML += "<option value=""" + Creditos(I).TC.ToString + """>" + Creditos(I).Abreviatura + "</option>"
        Next
        HTML += "</select>"
        Return HTML
    End Function
    <HttpPost()>
    Function Crea_selTipoCredito(ByVal CC As String, ByVal SM As String) As String
        Dim HTML As String = ""
        Dim TipoCreditos = Bl.Obtener_Tipos_de_CreditoCC(CC, SM)

        HTML = "<select name=""selCredito"" required=""required"" id=""selCredito"" class=""form-control"" onchange=""ActivaAhorro()"" >" + vbCrLf
        For I = 0 To TipoCreditos.Count - 1
            HTML += "<option value=""" + TipoCreditos(I).TC.ToString + """>" + TipoCreditos(I).Abreviatura + "</option>"
        Next
        HTML += "</select>"

        Return HTML
    End Function
    Function Crea_selFracc() As String
        Dim HTML As String = ""
        Dim Fraccs = Bl.Obtener_datos_nom_fracc()

        HTML = "<select name=""selFracc"" required=""required"" id=""selFracc"" class=""form-control"" onchange=""CambioSeleccionFracc()"">" + vbCrLf
        For I = 0 To Fraccs.Count - 1
            HTML += "<option value=""" + Fraccs(I).id_cve_fracc.ToString + """>" + Fraccs(I).Nom_Fracc + "</option>"
        Next

        HTML += "</select>"
        Return HTML
    End Function
    <HttpPost()>
    Function Crea_selManzana(ByVal CC As String) As String
        Session("CC") = CC
        Dim HTML As String = ""
        Dim Manzanas = Bl.Obtener_Smza(CC)

        HTML = "<select name=""selManzana"" required=""required"" id=""selManzana"" class=""form-control"" onchange=""CambioSeleccionSmza()"">" + vbCrLf
        If Bl.ObtenerTerreno(CC) Then
            HTML += "<option value=""0"">-NO APLICA-</option>"
        Else
            HTML += "<option value=""0"">Por favor seleccione una súper manzana</option>"
        End If

        For I = 0 To Manzanas.Count - 1

            HTML += "<option value=""" + Manzanas(I) + """>" + Manzanas(I) + "</option>"
        Next

        HTML += "</select>"

        If Bl.ObtenerTerreno(CC) Then
            Dim Plazos = Bl.Obtener_plazosTerrenos

            HTML += "  <input type=""text"" name=""DirActual"" required=""required"" placeholder=""Dirección cliente (ACTUAL)"" id=""DirActual"" class=""form-control""/> <br /><br />"
            HTML += "  <input type=""text"" name=""DirCompra"" required=""required"" placeholder=""Dirección que esta comprando (COMPRA)"" id=""DirCompra"" class=""form-control""/> <br /><br />"


            HTML += "<select name=""plazoTerr"" required=""required"" id=""plazoTerr"" class=""form-control"" onchange=""CambioSeleccionSmza()"">" + vbCrLf

            For I = 0 To Plazos.Count - 1

                HTML += "<option value=""" + Plazos(I).id_plazo.ToString + """>" + Plazos(I).plazo.ToString + " Mes(es)</option>"
            Next

            HTML += "</select>"
        End If


        Return HTML
    End Function
    <HttpPost()>
    Function Crea_selTerreno(ByVal sMza As String) As String
        Dim HTML As String = ""
        Select Case sMza
            Case "CEDHV", "FREHV"
                HTML = "<select name=""selTerreno"" required=""required"" id=""selTerreno"" class=""form-control"" >" + vbCrLf

                HTML += "<option value=""0"" selected=""selected"">Sin Terreno</option>"
                HTML += "<option value=""60000"">Terreno de $60,000</option>"
                HTML += "<option value=""78000"">Terreno de $78,000</option>"
                HTML += "<option value=""20000"">Terreno de $20,000</option>"
                HTML += "<option value=""150000"">Terreno de $150,000</option>"

                HTML += "</select>"
        End Select

        Return HTML
    End Function
#End Region
#Region "Archivos"
    Function Archivos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        'If IsNothing(Session("Usuario")) Then
        '    Return RedirectToAction("Login", "Account")
        'Else
        Usuario = Session("Usuario")
        ' If Usuario.Nivel >= Nivel_Seccion Then
        ViewBag.TablaArchivos = crea_tablaArchivos("C:\inetpub\wwwroot\ProConsul\Archivos")
        Return View()
        'Else
        '    Session.Clear()
        '    Return RedirectToAction("Login", "Account")
        'End If
        ' End If
    End Function
    <HttpGet()>
    Function Archivos(ByVal Ruta As String) As ActionResult
        If IsNothing(Ruta) Then
            Ruta = "C:\Contratos\Archivos"
            'Ruta = "C:\Contratos\Archivos"
        End If
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        'If IsNothing(Session("Usuario")) Then
        '    Return RedirectToAction("Login", "Account")
        'Else
        Usuario = Session("Usuario")
        ' If Usuario.Nivel >= Nivel_Seccion Then
        If Ruta = "C:\Contratos\Archivos" Then
            ViewBag.TablaArchivos = crea_tablaArchivos(Ruta)
        Else
            ViewBag.TablaArchivos = "<button class=""btn btn-lg green-haze"" onclick="" window.history.back()"">Carpeta anterior...</button><br />" + crea_tablaArchivos(Ruta)
        End If
        Return View()
        'Else
        '    Session.Clear()
        '    Return RedirectToAction("Login", "Account")
        'End If
        ' End If


    End Function
    Function crea_tablaArchivos(ByVal RutaArchivos As String) As String
        Dim Carpetas = Directory.GetDirectories(RutaArchivos)
        Dim Archivos = Directory.GetFiles(RutaArchivos)
        Dim RutaRecortada As String = RutaArchivos.Remove(0, 21)
        'Dim RutaRecortada As String = RutaArchivos.Remove(0, 37)

        If RutaRecortada = "" Then
        Else
            RutaRecortada = RutaRecortada.Remove(0, 1)
            RutaRecortada = RutaRecortada.Replace("\", "/")
            RutaRecortada += "/"
        End If


        Dim HTML As String = ""

        HTML += "  	<div class=""todo-ui"">"
        HTML += "<div class=""todo-sidebar"">"
        HTML += "	<div class=""portlet light"">"
        HTML += "		<div class=""portlet-title"">"
        HTML += "			<div class=""caption"" data-toggle=""collapse"" data-target="".todo-project-list-content"">"
        HTML += "				<span class=""caption-subject font-green-sharp bold uppercase"">ProArchivos </span>"
        HTML += "				<span class=""caption-helper visible-sm-inline-block visible-xs-inline-block"">click to view project list</span>"
        HTML += "			</div>"

        HTML += "		</div>"
        HTML += "		<div class=""portlet-body todo-project-list-content"">"
        HTML += "			<div class=""todo-project-list"">"
        HTML += "				<ul class=""nav nav-pills nav-stacked"">"


        For I = 0 To Carpetas.Count - 1
            Dim NombreCarpeta As String = Path.GetFileName(Carpetas(I))
            HTML += "					<li>"
            HTML += "						<a href=""?Ruta=" + Carpetas(I) + """>"
            HTML += "                                              <i class=""fa fa-folder""></i>"
            HTML += "						" + NombreCarpeta + " </a>"
            HTML += "					</li>"

        Next


        For I = 0 To Archivos.Count - 1
            Dim NombreArchivo As String = Path.GetFileName(Archivos(I))

            HTML += "					<li>"
            HTML += "						<a href=""/Contratos/Archivos/" + RutaRecortada + NombreArchivo + """>"
            HTML += Obtener_tipoarchivo(Archivos(I))
            HTML += "						" + NombreArchivo + " </a>"
            HTML += "					</li>"

        Next



        HTML += "				</ul>"
        HTML += "			</div>"
        HTML += "		</div>"
        HTML += "	</div>"
        HTML += "</div>"
        HTML += "              </div>"


        Return HTML
    End Function
    Function Obtener_tipoarchivo(ByVal RutaArchivo As String) As String
        Dim Resultado As String = ""
        Dim Extension As String = Path.GetExtension(RutaArchivo)
        Select Case Extension
            Case ".xls", ".xlsx"
                Resultado = "  <i class=""fa fa-file-excel-o""></i>"
            Case ".doc", ".docx"
                Resultado = "  <i class=""fa fa-file-word-o""></i>"
            Case ".txt"
                Resultado = "  <i class=""fa fa-file-text-o""></i>"
            Case ".pdf"
                Resultado = "  <i class=""fa fa-file-pdf-o""></i>"
            Case ".mp3", ".wav", ".m4a", ".m4b", "ogg"
                Resultado = "  <i class=""fa fa-music""></i>"
            Case ".jpg", ".gif", ".bmp", ".png"
                Resultado = "  <i class=""fa fa-file-image-o""></i>"
            Case Else
                Resultado = "  <i class=""fa fa-file-o""></i>"
        End Select

        Return Resultado
    End Function
#End Region
#Region "Personas"
    Function AltaPersona() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Empleado = Usuario.Empleado

                Return View()
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

    End Function
#End Region
End Class