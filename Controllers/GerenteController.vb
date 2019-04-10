Public Class GerenteController
    Inherits System.Web.Mvc.Controller

    ' GET: /Gerente

    Private Nivel_Seccion As Integer = 3
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
End Class