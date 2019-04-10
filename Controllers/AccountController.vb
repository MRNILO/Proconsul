Public Class AccountController
    Inherits System.Web.Mvc.Controller

    ' GET: /Account

    Function Login() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Return View()
    End Function
    <HttpPost()>
    Function Login(ByVal username As String, Password As String) As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        Try
            Usuario = Bl.LogIn(username, Password)
            Session("Usuario") = Usuario

            'If Usuario.Empleado = 9998 Then
            '    Response.Redirect("http://www.que.es/archivos/201003/calabacin_n-640x640x80.jpg")
            'End If
            'If username = "EXTERNOS" And Password = "Edificasa2013.A" Then
            '    Return RedirectToAction("Contratos", "Asesor")
            'End If
            Select Case Usuario.Nivel
                Case 1
                    Return RedirectToAction("index", "Asesor")
                Case 2
                    Return RedirectToAction("index", "Lider")
                Case 3
                    Return RedirectToAction("index", "Gerente")
                Case 4
                    Return RedirectToAction("index", "Administrativo")
                Case 5
                    Return RedirectToAction("index", "Contabilidad")
                Case 6
                    Return RedirectToAction("index", "Titulacion")
                Case 7
                    Return RedirectToAction("index", "AuxDir")
                Case Else
                    ViewBag.Mensaje = "Error, verifique sus datos"
                    Return View()
            End Select
        Catch ex As Exception
            ViewBag.Mensaje = "Error: " + ex.Message
        End Try
        Return View()
    End Function
    Public Function LogOff() As ActionResult
        Session.Clear()
        Return RedirectToAction("Login", "Account")
    End Function
End Class