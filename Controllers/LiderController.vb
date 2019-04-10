Public Class LiderController
    Inherits System.Web.Mvc.Controller

    ' GET: /Lider

    Private Nivel_Seccion As Integer = 2
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

    Function PagosSemana() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Empleado = Usuario.Empleado
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
    Function Faltantes() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel >= Nivel_Seccion Then
                ViewBag.NombreUsuario = Usuario.Nombre_Usuario
                ViewBag.Empleado = Usuario.Desc_Valor
                ViewBag.Iframe = "<iframe src='http://192.168.1.17/DevProconsul/Reportes/Faltantes.aspx?Lider=" + Usuario.Desc_Valor.ToString + "'  frameBorder=""0"" width=""100%"" height=""1024"">"
            Else
                Session.Clear()
                Return RedirectToAction("Login", "Account")
            End If
        End If

        Return View()
    End Function
End Class