Public Class TodosController
    Inherits System.Web.Mvc.Controller

    ' GET: /Todos
    Private Nivel_Seccion As Integer = 1
    Function MyDatos() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        Dim DatosUsuario As New Servicio.CDatosAsesorDetalle

        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                DatosUsuario = Bl.Obtener_DatosDetalle_Empleado(Usuario.Empleado)
                ViewBag.tablaDatos = CreaTablaDatos(Usuario, DatosUsuario)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function Notificaciones() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        Dim DatosUsuario As New Servicio.CDatosAsesorDetalle

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
    Function MyDatos(FNacimiento As Date, SSexo As String, SNacionalidad As String, Tnacionalidad As String, _
                     SCivil As String, tbCiudad As String, tbEstado As String, tbDir As String, tbCelular As String, _
                     tbTel As String, tbEmail As String, tbRefNom1 As String, tbRefParentesco1 As String, _
                     tbRefTel1 As String, tbRefNom2 As String, tbRefParentesco2 As String, tbRefTel2 As String, _
                     tbRFC As String, tbCURP As String, tbIFE As String, tbCIFE As String, tbManejo As String, _
                     FVenceManejo As Date, tbNSS As String, cbPrimaria As String, cbSecundaria As String, _
                     cbPreparatoria As String, cbLicenciatura As String, tbLicName As String, cbMaestria As String, _
                     tbMasName As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo

        Dim Usuario As New Servicio.CUsuario
        Dim DatosUsuario As New Servicio.CDatosAsesorDetalle

        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario

                Try
                    Bl.MyDatos(Usuario.Empleado, FNacimiento, SSexo, SNacionalidad, Tnacionalidad, SCivil, tbCiudad, tbEstado, tbDir, tbCelular, tbTel, tbEmail, tbRefNom1, tbRefParentesco1, tbRefTel1, tbRefNom2, tbRefParentesco2, tbRefTel2, tbRFC, tbCURP, tbIFE, tbCIFE, tbManejo, FVenceManejo, tbNSS, cbPrimaria, cbSecundaria, cbPreparatoria, cbLicenciatura, tbLicName, cbMaestria, tbMasName)
                Catch ex As Exception

                End Try
                DatosUsuario = Bl.Obtener_DatosDetalle_Empleado(Usuario.Empleado)
                ViewBag.tablaDatos = CreaTablaDatos(Usuario, DatosUsuario)
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function MyCalendario() As ActionResult
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
    Function MyInbox() As ActionResult
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
    Function MyTareas() As ActionResult
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
    Function CambiaFoto() As ActionResult
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
    Function CreaTablaDatos(ByVal Usuario As Servicio.CUsuario, ByVal DatosUsuario As Servicio.CDatosAsesorDetalle) As String
        Dim HTML As String = ""
        HTML = "  <table style=""width:100%"" >"
        HTML += "    <tr>"
        HTML += "        <td>N.Asesor(Enkontrol):</td>"
        HTML += "        <td><strong>" + Usuario.Empleado.ToString + "</strong></td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Nombres(s)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "            <strong>" + Usuario.Nombre_Usuario + "</strong> "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td colspan=""2"">"
        HTML += "            <strong>Datos Personales*</strong> Todos los datos son obligatorios en todas las secciones"
        HTML += "        </td>                "
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Fecha de nacimiento:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "            <input type=""text""  placeholder=""Fecha de Nacimiento"" id=""FNacimiento""  class=""form-control"" name=""FNacimiento"" required=""required"" value=""" + DatosUsuario.fecha_nacimiento.ToString("yyyy/MM/dd") + """/>"
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Sexo:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "            <select class=""form-control"" name=""SSexo"" required=""required"">"
        Select Case DatosUsuario.sexo
            Case "M"
                HTML += "                <option value=""M"" selected=""selected"">Masculino</option>"
                HTML += "                <option value=""F"">Femenino</option>"
            Case "F"
                HTML += "                <option value=""M"">Masculino</option>"
                HTML += "                <option value=""F"" selected=""selected"">Femenino</option>"
            Case Else
                HTML += "                <option value=""M"">Masculino</option>"
                HTML += "                <option value=""F"" >Femenino</option>"
        End Select
       
        HTML += "            </select>"
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Nacionalidad:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "            <select class=""form-control"" name=""SNacionalidad"" id=""SNacionalidad"" required=""required"">"
        Select Case DatosUsuario.nacionalidad
            Case "Mexicana"
                HTML += "                <option value=""Mexicana"" selected=""selected"">Mexicana</option>"
                HTML += "                <option value=""Otro"">Otro</option>"
            Case "F"
                HTML += "                <option value=""Mexicana"">Mexicana</option>"
                HTML += "                <option value=""Otro"" selected=""selected"">Otro</option>"
            Case Else
                HTML += "                <option value=""Mexicana"">Mexicana</option>"
                HTML += "                <option value=""Otro"" >Otro</option>"
        End Select
        HTML += "            </select>"
        HTML += "             Especifique:<input type=""text"" name=""Tnacionalidad"" value=""" + DatosUsuario.nacionalidad + """ class=""form-control"" />"
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "      <tr>"
        HTML += "        <td>"
        HTML += "            Estado Civil:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "            <select class=""form-control"" name=""SCivil"" id=""SCivil"" required=""required"">"
       
        Select Case DatosUsuario.estado_civil
            Case "Soltero"
                HTML += "                <option value=""Soltero"" selected=""selected"">Soltero</option>"
                HTML += "                <option value=""Casado"">Casado</option>"
                HTML += "                <option value=""Viudo"">Viud@</option>"
                HTML += "                <option value=""Union libre"">Union libre</option>"
                HTML += "                <option value=""Divorciado"">Divorciado</option>"
                HTML += "                <option value=""Separado"">Separado</option>"
            Case "Casado"
                HTML += "                <option value=""Soltero"">Soltero</option>"
                HTML += "                <option value=""Casado"" selected=""selected"">Casado</option>"
                HTML += "                <option value=""Viudo"">Viud@</option>"
                HTML += "                <option value=""Union libre"">Union libre</option>"
                HTML += "                <option value=""Divorciado"">Divorciado</option>"
                HTML += "                <option value=""Separado"">Separado</option>"
            Case "Viudo"
                HTML += "                <option value=""Soltero"">Soltero</option>"
                HTML += "                <option value=""Casado"" >Casado</option>"
                HTML += "                <option value=""Viudo"" selected=""selected"">Viud@</option>"
                HTML += "                <option value=""Union libre"">Union libre</option>"
                HTML += "                <option value=""Divorciado"">Divorciado</option>"
                HTML += "                <option value=""Separado"">Separado</option>"
            Case "Union libre"
                HTML += "                <option value=""Soltero"">Soltero</option>"
                HTML += "                <option value=""Casado"" >Casado</option>"
                HTML += "                <option value=""Viudo"" >Viud@</option>"
                HTML += "                <option value=""Union libre"" selected=""selected"">Union libre</option>"
                HTML += "                <option value=""Divorciado"">Divorciado</option>"
                HTML += "                <option value=""Separado"">Separado</option>"
            Case "Divorciado"
                HTML += "                <option value=""Soltero"">Soltero</option>"
                HTML += "                <option value=""Casado"" >Casado</option>"
                HTML += "                <option value=""Viudo"" >Viud@</option>"
                HTML += "                <option value=""Union libre"" >Union libre</option>"
                HTML += "                <option value=""Divorciado"" selected=""selected"">Divorciado</option>"
                HTML += "                <option value=""Separado"">Separado</option>"
            Case "Separado"
                HTML += "                <option value=""Soltero"">Soltero</option>"
                HTML += "                <option value=""Casado"" >Casado</option>"
                HTML += "                <option value=""Viudo"" >Viud@</option>"
                HTML += "                <option value=""Union libre"" >Union libre</option>"
                HTML += "                <option value=""Divorciado"" >Divorciado</option>"
                HTML += "                <option value=""Separado"" selected=""selected"">Separado</option>"
            Case Else
                HTML += "                <option value=""Soltero"">Soltero</option>"
                HTML += "                <option value=""Casado"" >Casado</option>"
                HTML += "                <option value=""Viudo"" >Viud@</option>"
                HTML += "                <option value=""Union libre"" >Union libre</option>"
                HTML += "                <option value=""Divorciado"" >Divorciado</option>"
                HTML += "                <option value=""Separado"">Separado</option>"
        End Select

        HTML += "            </select>                    "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Ciudad de nacimiento:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbCiudad"" value=""" + DatosUsuario.ciudad + """ name=""tbCiudad"" required=""required"" />             "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Estado de nacimiento:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbEstado"" value=""" + DatosUsuario.estado + """ name=""tbEstado"" required=""required"" />             "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Domicilio Particular:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <textarea name=""tbDir"" required=""required"" class=""form-control"">" + DatosUsuario.domicilio + "</textarea>"
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Celular ó Id radio:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""tel"" class=""form-control"" id=""tbCelular"" value=""" + DatosUsuario.celular.ToString + """ name=""tbCelular"" required=""required"" />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Telefono Particular:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""tel"" class=""form-control"" id=""tbTel"" name=""tbTel"" value=""" + DatosUsuario.telfijo.ToString + """ required=""required"" />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "      <tr>"
        HTML += "        <td>"
        HTML += "            Email (Usar uno valido aquí recibira sus notificaciónes Edificasa):"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""email"" class=""form-control"" id=""tbEmail"" name=""tbEmail"" value=""" + DatosUsuario.email + """ required=""required"" />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td colspan=""2"">"
        HTML += "            <strong>Referencias</strong>"
        HTML += "        </td>                "
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Nombre completo de su primer Referencia (Persona cercana a usted)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRefNom1"" name=""tbRefNom1"" value=""" + DatosUsuario.ref1nombre + """ required=""required"" />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Parentesco con su primer referencia (Persona cercana a usted)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRefParentesco1"" name=""tbRefParentesco1"" value=""" + DatosUsuario.red1parentesco + """ required=""required"" />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            telefono de su primer referencia (Persona cercana a usted)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRefTel1"" name=""tbRefTel1"" required=""required"" value=""" + DatosUsuario.red1tel.ToString + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Nombre completo de su segunda Referencia (Persona cercana a usted)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRefNom2"" name=""tbRefNom2"" required=""required"" value=""" + DatosUsuario.red2nombre + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Parentesco con su segunda referencia (Persona cercana a usted)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRefParentesco2"" name=""tbRefParentesco2"" required=""required"" value=""" + DatosUsuario.red2parentesco + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            telefono de su segunda referencia (Persona cercana a usted)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRefTel2"" name=""tbRefTel2"" required=""required"" value=""" + DatosUsuario.red2tel.ToString + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td colspan=""2"">"
        HTML += "           <strong>Datos Generales</strong>"
        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            R.F.C."
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbRFC"" name=""tbRFC"" required=""required"" value=""" + DatosUsuario.rfc + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            CURP"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbCURP"" name=""tbCURP"" required=""required"" value=""" + DatosUsuario.curp + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "      <tr>"
        HTML += "        <td>"
        HTML += "            No.IFE (Reverso)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbIFE"" name=""tbIFE"" required=""required"" value=""" + DatosUsuario.nife + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Clave Elector (IFE)"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbCIFE"" name=""tbCIFE"" required=""required"" value=""" + DatosUsuario.claveelector + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Licencia de Manejo"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbManejo"" name=""tbManejo"" required=""required"" value=""" + DatosUsuario.licmanejo + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Fecha vence Lic. Manejo:"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "            <input type=""text""  placeholder=""Fecha de Vencimiento"" id=""FVenceManejo""  class=""form-control"" name=""FVenceManejo"" required=""required"" value=""" + DatosUsuario.fechavence.ToString("yyyy/MM/dd") + """/>"
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            NSS"
        HTML += "        </td>"
        HTML += "        <td>"
        HTML += "           <input type=""text"" class=""form-control"" id=""tbNSS"" name=""tbNSS"" required=""required"" value=""" + DatosUsuario.nss + """ />     "
        HTML += "        </td>"
        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td colspan=""2"">"
        HTML += "            <strong>Estudios</strong>"
        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "     <tr>"
        HTML += "        <td>"
        HTML += "            Primaria"
        HTML += "        </td>"
        HTML += "        <td>"
        If DatosUsuario.primaria Then
            HTML += "           <input type=""checkbox"" checked=""checked"" name=""cbPrimaria""  class=""form-control"" value=""True""/>     "
        Else
            HTML += "           <input type=""checkbox"" name=""cbPrimaria""  class=""form-control"" value=""True""/>     "
        End If

        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "      <tr>"
        HTML += "        <td>"
        HTML += "            Secundaria"
        HTML += "        </td>"
        HTML += "        <td>"
        If DatosUsuario.secundaria Then
            HTML += "           <input type=""checkbox"" checked=""checked"" name=""cbSecundaria""  class=""form-control"" value=""True""/>     "
        Else
            HTML += "           <input type=""checkbox"" name=""cbSecundaria""  class=""form-control"" value=""True""/>     "
        End If
        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "      <tr>"
        HTML += "        <td>"
        HTML += "            Preparatoria"
        HTML += "        </td>"
        HTML += "        <td>"
        If DatosUsuario.preparatoria Then
            HTML += "           <input type=""checkbox"" checked=""checked"" name=""cbPreparatoria""  class=""form-control"" value=""True""/>     "
        Else
            HTML += "           <input type=""checkbox"" name=""cbPreparatoria""  class=""form-control"" value=""True""/>     "
        End If
        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Licenciatura"
        HTML += "        </td>"
        HTML += "        <td>"
        If DatosUsuario.licenciatura Then
            HTML += "           <input type=""checkbox"" checked=""checked"" name=""cbLicenciatura"" class=""form-control"" value=""True""/>Nombre de la Licenciatura:<input type=""text"" name=""tbLicName"" class=""form-control"" value=""" + DatosUsuario.nomlicenciatura + """ />     "
        Else
            HTML += "           <input type=""checkbox""  name=""cbLicenciatura"" class=""form-control"" value=""True""/>Nombre de la Licenciatura:<input type=""text"" name=""tbLicName"" class=""form-control"" value=""" + DatosUsuario.nomlicenciatura + """ />     "
        End If

        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "    <tr>"
        HTML += "        <td>"
        HTML += "            Maestria (Seguro)"
        HTML += "        </td>"
        HTML += "        <td>"
        If DatosUsuario.maestria Then
            HTML += "           <input type=""checkbox"" checked=""checked"" name=""cbMaestria"" class=""form-control"" value=""True""/>Nombre de la Maestria:<input type=""text"" name=""tbMasName"" class=""form-control"" value=""" + DatosUsuario.nommaestria + """ />     "
        Else
            HTML += "           <input type=""checkbox"" name=""cbMaestria"" class=""form-control"" value=""True""/>Nombre de la Maestria:<input type=""text"" name=""tbMasName"" class=""form-control"" value=""" + DatosUsuario.nommaestria + """ />     "
        End If

        HTML += "        </td>"

        HTML += "    </tr>"
        HTML += "</table>"

        Return HTML
    End Function
End Class