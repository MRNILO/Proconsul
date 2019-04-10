Imports System.Net
Imports System.Web.Http

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Public Function index() As ActionResult
        ViewBag.Ruta_app = Ruta_Archivo
        Dim Usuario As New Servicio.CUsuario
        If IsNothing(Session("Usuario")) Then
            Return RedirectToAction("Login", "Account")
        Else
            Usuario = Session("Usuario")
            If Usuario.Nivel < 1 Then
                Return RedirectToAction("Login", "Account")
            Else
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
            End If
        End If

        Return View()
    End Function
    <HttpPost()>
    Function verifica_notificaciones(ByVal Empleado As Integer) As String
        Dim notificacion = Bl.Comprobar_Notificaciones(Empleado)
        If notificacion.Mensaje = "Sin Mensajes" Then
        Else
            Bl.Cambiar_a_Visto_notificacion(notificacion.id_notificacion)
            Return notificacion.Mensaje
        End If
        Return "Sin Mensajes"
    End Function
End Class
