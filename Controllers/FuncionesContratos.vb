Imports System.IO
Imports iTextSharp.text.pdf
Imports DocumentFormat.OpenXml.Packaging
Imports Spire.Doc

Module FuncionesContratos
    Public Function Generar_Contrato_Web(ByVal selCredito As Integer, ByVal selFracc As String, ByVal selManzana As String, Optional ByVal selTerreno As Double = 0, Optional ByVal nombrecliente As String = "", Optional ByVal mAdicional As Double = 0, Optional ByVal CantidadApartado As Integer = 0, Optional ByVal id_promocion As Integer = 0, Optional ByVal id_promocionContrato As Integer = 0, Optional ByVal Ahorro As Integer = 0, Optional AdAdmin As String = "", Optional adCanAdmin As Integer = 0, Optional ByVal NLote As String = "", Optional ByVal NManzana As String = "", Optional DirCasa As String = "",
                       Optional ByVal fechaDTU As Date = #1/1/2000#, Optional ByVal DirActual As String = "", Optional ByVal DirCompra As String = "", Optional ByVal plazoTerr As Integer = 0, Optional ByVal cb_sorteado As Integer = 0) As String
        System.Threading.Thread.CurrentThread.CurrentUICulture =
      System.Globalization.CultureInfo.GetCultureInfo("es-MX")
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("es-MX")

        Dim TextoAdicionales1 As String = ""
        Dim TextoAdicionales2 As String = ""
        Dim TextoAdicionales3 As String = ""
        Dim TextoAdicionales4 As String = ""

        Dim DatosEquipamiento = Bl.Obtener_Equipamiento(id_promocion)
        Dim DatosPromocion = Bl.Obtener_promocione(id_promocionContrato)

        Dim Nombredearchivo As String = ""
        Try
            EliminaArchivos()
        Catch ex As Exception

        End Try

        Dim Infonavit As Integer = 0
        Dim Fovisste As Integer = 0
        Dim ISSEG As Integer = 0

        Dim CC As String = selFracc
        Dim SM As String = selManzana
        Dim TC As Integer = selCredito
        Dim MtrAdicional As Double = mAdicional
        Dim TextoPrecio As String = ""

        Select Case selCredito
            Case 1
                Infonavit = 1
                Fovisste = 0
            Case 2
                Infonavit = 0
                Fovisste = 1
            Case 3
                ISSEG = 1
                Infonavit = 0
                Fovisste = 0
            Case 6
                Infonavit = 1
                Fovisste = 0
            Case Else
                Infonavit = 0
                Fovisste = 0
        End Select

        Dim Datos As New Servicio.CDatosContratoNuevo
        Try
            If CC = "839" Or CC = "900" Or CC = "914" Then
                Datos = Bl.Obtener_Datos_Contrato_Nuevo(CC, Trim(SM), TC, Infonavit, Fovisste, ISSEG, 18)
            Else
                Datos = Bl.Obtener_Datos_Contrato_Nuevo(CC, Trim(SM), TC, Infonavit, Fovisste, ISSEG, 11)
            End If

            'Datos = Bl.Obtener_Datos_Contrato_Nuevo(CC, Trim(SM), TC, Infonavit, Fovisste, ISSEG)

            Datos.Superficie = MtrAdicional + Datos.Mtrs_Casa


            Select Case SM
                Case "P05P2", "P05P1", "P05PB", "T01P2", "T01P1", "T01PB"
                    Datos.Bono = 0
            End Select
            Datos.Precio_Casa += Datos.Bono


            Select Case selFracc
                Case "680", "690"
                    Datos.Precio_Casa = Datos.Precio_Casa + RoundUpCientos(CantidadApartado)
            End Select

            'TextoPrecio = Crea_Texto_Precio(Datos.Precio_Casa + (Datos.Bono - Ahorro), MtrAdicional, Datos.Precio_Adicional, selTerreno)
            Dim PrecioAdicionales = RoundUp(Datos.Precio_Adicional * mAdicional)
            Dim PrecioEquipamientoOmuro As Integer = selTerreno + DatosEquipamiento.Precio

            If IsNothing(DatosPromocion) Then
                DatosPromocion = New Servicio.CPromocionesContrato
                DatosPromocion.Costo = 0
            End If

            'Modificación traje a la mediada 01/02/2018
            If selCredito = 2 Then
                If cb_sorteado = 1 Then
                    Datos.Precio_Casa += 46400
                End If
            End If

            Dim PrecioTodo As Integer = 0

            Select Case SM
                Case "P05P2", "P05P1", "P05PB", "T01P2", "T01P1", "T01PB"
                    PrecioTodo = Datos.Precio_Casa
                Case Else
                    PrecioTodo = ((Datos.Precio_Casa - (Datos.Bono - Ahorro)) + PrecioAdicionales + PrecioEquipamientoOmuro + DatosPromocion.Costo) + adCanAdmin
            End Select

            TextoPrecio = PrecioTodo.ToString("c") + " (" + cantidad_Letras(PrecioTodo) + " PESOS 00/100 M.N.) "

            Select Case SM
                Case "P05P2", "P05P1", "P05PB", "T01P2", "T01P1", "T01PB"
                    TextoAdicionales1 = ""
                Case Else
                    'Agrega el texto de la promoción de los closet inventada
                    If DatosEquipamiento.TextoCombo <> "" Then

                        'TextoAdicionales1 = "c) " + Crea_Texto_promocion(selFracc, SM, DatosEquipamiento.Precio) + Environment.NewLine
                        TextoAdicionales1 = "b) " + If(DatosEquipamiento.Precio < 0, "Menos ", If(DatosEquipamiento.Precio = 0, "", "Más ")) + DatosEquipamiento.Precio.ToString("c") + " (" + cantidad_Letras(DatosEquipamiento.Precio) + "PESOS 00/100 M.N.). " + DatosEquipamiento.TextoContrato
                    Else
                        TextoAdicionales1 = "b) SIN CONTRATACIÓN DE EQUIPAMIENTOS"
                    End If

            End Select

            ''Agrega el texto de la promoción de los closet inventada
            'Select Case SM
            '    Case "P05P2", "P05P1", "P05PB", "T01P2", "T01P1", "T01PB"
            '        TextoAdicionales4 = ""
            '    Case Else
            '        If DatosPromocion.textoCombo <> "" Then

            '            'TextoAdicionales1 = "c) " + Crea_Texto_promocion(selFracc, SM, DatosEquipamiento.Precio) + Environment.NewLine
            '            TextoAdicionales4 = "b) " + If(DatosPromocion.Costo < 0, "Menos ", If(DatosPromocion.Costo = 0, "", "Más ")) + DatosPromocion.Costo.ToString("c") + " (" + cantidad_Letras(DatosPromocion.Costo) + "PESOS 00/100 M.N.). " + DatosPromocion.textContrato
            '        Else
            '            TextoAdicionales4 = "b) SIN CONTRATACIÓN DE EQUIPAMIENTOS  "
            '        End If
            'End Select

            'Agrega Texto de adicional al contrato 

            If adCanAdmin > 0 And AdAdmin <> "" Then
                TextoAdicionales3 = "e) " + AdAdmin.ToUpper + " " + adCanAdmin.ToString("c") + " (" + cantidad_Letras(adCanAdmin) + " PESOS 00/100 M.N.). "
            Else
                TextoAdicionales3 = " "
            End If

            If mAdicional > 0 Then
                TextoAdicionales2 = Crea_Texto_Precio(mAdicional, Datos.Precio_Adicional, selTerreno)
            Else
                TextoAdicionales2 = " "
            End If
            'Datos.Precio_Total = Crea_Texto_Precio(Datos.Precio_Casa, MtrAdicional, Datos.Precio_Adicional, selTerreno)
            Datos.Precio_Total = TextoPrecio

            If Now.AddDays(30) > Datos.Fecha_DTU Then
                Datos.Fecha_DTU = Now.AddDays(30)
            End If

            If selCredito = 6 Then
                'Contado
                If CC = "839" Or CC = "900" Or CC = "914" Or CC = "254" Then
                    ' FileCopy("C:\Contratos\Contado_GPV.docx", "C:\Contratos\Download\Contrato.docx")
                    FileCopy("C:\Contratos\Contado.docx", "C:\Contratos\Download\Contrato.docx")
                Else
                    FileCopy("C:\Contratos\Contado.docx", "C:\Contratos\Download\Contrato.docx")
                End If
                'FileCopy("C:\Contratos\Contado.docx", "C:\Contratos\Download\Contrato.docx")

                'Dim TextoDetallesCasa As String = Datos.Precio_Casa.ToString("c") + " (" + cantidad_Letras(Datos.Precio_Casa + 10000) + " PESOS 00/100 M.N.) de casa tipo menos $10,000 (DIEZ MIEL PESOS 00/100 M.N.) Por promoción de preventa " + "</w:t> <w:br/><w:t>" + TextoAdicionales1 + "</w:t> <w:br/><w:t>" + TextoAdicionales2 + "</w:t> <w:br/><w:t>" + TextoAdicionales3

                'Dim TextoDetallesCasa As String = Datos.Precio_Casa.ToString("c") + " (" + cantidad_Letras(Datos.Precio_Casa) + " PESOS 00/100 M.N.) de casa tipo menos " + Datos.Bono.ToString("c") + " (" + cantidad_Letras(Datos.Bono) + " PESOS 00/100 M.N.) por promoción de preventa. " + "</w:t> <w:br/><w:t>" + TextoAdicionales1 + "</w:t> <w:br/><w:t>" + TextoAdicionales2 + "</w:t> <w:br/><w:t>" + TextoAdicionales3 ANTES DE MODIFICACION CONTRATO

                Dim BonoDetalleCasa As Integer = Datos.Bono
                Dim TextoDetallesCasa As String = Datos.Precio_Casa.ToString("c") + " (" + cantidad_Letras(Datos.Precio_Casa) + " PESOS 00/100 M.N.) de casa tipo menos " + BonoDetalleCasa.ToString("c") + " (" + cantidad_Letras(BonoDetalleCasa) + " PESOS 00/100 M.N.) de promoción por pre-venta. " + "</w:t> <w:br/><w:t>" + TextoAdicionales1 + "</w:t> <w:br/><w:t>" + TextoAdicionales2 + "</w:t> <w:br/><w:t>" + TextoAdicionales3
                Dim TextoPrecioTotal As String = PrecioTodo.ToString("c") + " (" + cantidad_Letras(PrecioTodo) + "PESOS 00/100 M.N.)"
                Datos.Bono = (PrecioTodo * 0.2)
                Dim DesglocePago As String = "La cantidad de " + Datos.Bono.ToString("c") + " (" + cantidad_Letras(Datos.Bono) + " Pesos  00/100 M.N.) por concepto de apartado, al momento de la firma del presente contrato. "

                If (fechaDTU - Now).Days > 30 Then
                    DesglocePago += " más " + ((PrecioTodo - Datos.Bono) / 2).ToString("c") + " (" + cantidad_Letras((PrecioTodo - Datos.Bono) / 2) + " PESOS 00/100 M.N.) el día " + Now.AddDays(15).ToLongDateString
                    DesglocePago += " más " + ((PrecioTodo - Datos.Bono) / 2).ToString("c") + " (" + cantidad_Letras((PrecioTodo - Datos.Bono) / 2) + " PESOS 00/100 M.N.) el día " + fechaDTU.ToLongDateString
                Else
                    DesglocePago += " más " + (PrecioTodo - Datos.Bono).ToString("c") + " (" + cantidad_Letras(PrecioTodo - Datos.Bono) + " PESOS 00/100 M.N.) el día " + fechaDTU.ToLongDateString
                End If

                If nombrecliente = "" Then
                    'SearchAndReplaceCONTADO("C:\Contratos\Download\Contrato.docx", "________________________________________________________", NLote, NManzana, Datos.Nombre_CC, DirCasa, DesglocePago, TextoDetallesCasa, TextoPrecioTotal, TextoDetallesCasa) Mostraban duplicidad en los contratos
                    SearchAndReplaceCONTADO("C:\Contratos\Download\Contrato.docx", "________________________________________________________", NLote, NManzana, Datos.Nombre_CC, DirCasa, DesglocePago, TextoDetallesCasa, TextoPrecioTotal, BonoDetalleCasa)
                Else
                    'SearchAndReplaceCONTADO("C:\Contratos\Download\Contrato.docx", nombrecliente, NLote, NManzana, Datos.Nombre_CC, DirCasa, DesglocePago, TextoDetallesCasa, TextoPrecioTotal, TextoDetallesCasa) Mostraban duplicidad en los contratos
                    SearchAndReplaceCONTADO("C:\Contratos\Download\Contrato.docx", nombrecliente, NLote, NManzana, Datos.Nombre_CC, DirCasa, DesglocePago, TextoDetallesCasa, TextoPrecioTotal, BonoDetalleCasa)
                End If
            Else
                'Cambios Contratos terrenos 19/01/2017
                If Bl.ObtenerTerreno(CC) Then
                    'Es terreno debe usar el contrato diferente
                    If CC = "839" Or CC = "900" Or CC = "914" Or CC = "254" Then
                        'FileCopy("C:\Contratos\CONTRATOTERR_GPV.docx", "C:\Contratos\Download\Contrato.docx")
                        FileCopy("C:\Contratos\CONTRATOTERR.docx", "C:\Contratos\Download\Contrato.docx")
                    Else
                        FileCopy("C:\Contratos\CONTRATOTERR.docx", "C:\Contratos\Download\Contrato.docx")
                    End If
                    'FileCopy("C:\Contratos\CONTRATOTERR.docx", "C:\Contratos\Download\Contrato.docx")
                Else
                    'SM corrección del 03/08/2016
                    Select Case Bl.ObtenerPCRU(SM)
                        Case "PCRU27"
                            'Super manzanas magicas sensacionales
                            If CC = "839" Or CC = "900" Or CC = "914" Or CC = "254" Then
                                'FileCopy("C:\Contratos\CONTRATOPCRU_GPV.docx", "C:\Contratos\Download\Contrato.docx")
                                FileCopy("C:\Contratos\CONTRATOPCRU.docx", "C:\Contratos\Download\Contrato.docx")
                            Else
                                FileCopy("C:\Contratos\CONTRATOPCRU.docx", "C:\Contratos\Download\Contrato.docx")
                            End If

                            'FileCopy("C:\Contratos\CONTRATOPCRU.docx", "C:\Contratos\Download\Contrato.docx")
                        Case "PCRU25"
                            'pcru $25,000
                            If CC = "839" Or CC = "900" Or CC = "914" Or CC = "254" Then
                                'FileCopy("C:\Contratos\CONTRATOPCRU25_GPV.docx", "C:\Contratos\Download\Contrato.docx")
                                FileCopy("C:\Contratos\CONTRATOPCRU25.docx", "C:\Contratos\Download\Contrato.docx")
                            Else
                                FileCopy("C:\Contratos\CONTRATOPCRU25.docx", "C:\Contratos\Download\Contrato.docx")
                            End If

                            'FileCopy("C:\Contratos\CONTRATOPCRU25.docx", "C:\Contratos\Download\Contrato.docx")
                        Case Else
                            'NORMAL
                            If CC = "839" Or CC = "900" Or CC = "914" Or CC = "254" Then
                                'FileCopy("C:\Contratos\CONTRATO_GPV.docx", "C:\Contratos\Download\Contrato.docx")
                                FileCopy("C:\Contratos\CONTRATO.docx", "C:\Contratos\Download\Contrato.docx")
                            Else
                                FileCopy("C:\Contratos\CONTRATO.docx", "C:\Contratos\Download\Contrato.docx")
                            End If

                            'FileCopy("C:\Contratos\CONTRATO.docx", "C:\Contratos\Download\Contrato.docx")
                    End Select
                End If

                If Bl.ObtenerTerreno(CC) Then
                    'Si es terreno
                    Dim DatosTerreno As New CDatosterreno
                    Dim Plazo = Bl.Obtener_plazoTerreno(plazoTerr)

                    DatosTerreno.DireccionDeCompra = DirCompra
                    DatosTerreno.DireccionActual = DirActual

                    DatosTerreno.CantidadVenta = Plazo.precioMetro * mAdicional
                    DatosTerreno.CantidadVenta = Math.Round(DatosTerreno.CantidadVenta, 0)
                    DatosTerreno.CantidadEnganche = DatosTerreno.CantidadVenta * 0.1 'Cantidad Enganche

                    DatosTerreno.CantidadEnganche = Math.Round(DatosTerreno.CantidadEnganche, 0)
                    DatosTerreno.NombreCompletoCliente = nombrecliente
                    DatosTerreno.MetrosCompra = mAdicional

                    BuscarYRemplazarTerrenos("C:\Contratos\Download\Contrato.docx", DatosTerreno, Plazo)
                Else

                    If nombrecliente = "" Then
                        SearchAndReplace("C:\Contratos\Download\Contrato.docx", Datos, "_________________________________________________________", Ahorro, TextoAdicionales1, TextoAdicionales2, TextoAdicionales3, TextoAdicionales4)
                    Else
                        SearchAndReplace("C:\Contratos\Download\Contrato.docx", Datos, nombrecliente, Ahorro, TextoAdicionales1, TextoAdicionales2, TextoAdicionales3, TextoAdicionales4)
                    End If
                End If
            End If

            Dim document As New Spire.Doc.Document

            Try
                document.LoadFromFile("C:\Contratos\Download\Contrato.docx")
            Catch exs As Exception
                'lbl_mensaje.Text = "Error: " + exs.Message
            End Try

            Try
                document.SaveToFile("C:\Contratos\Download\DoctoPDF.PDF", FileFormat.PDF)
                unir(Datos, selCredito, CC)
            Catch exs As Exception
                Console.Write(exs.Message)
            End Try

            document.Close()
            Nombredearchivo = PaginarPDF("C:\Contratos\Download\Final.PDF")

            Return Nombredearchivo
            'Response.Redirect("http://192.168.1.17/Contratos/Download/Final2.pdf")

        Catch ex As Exception
            'lbl_mensaje.Text = "No hay registro de esta casa."
            Nombredearchivo = "ErrorContrato.html?err=" + ex.Message
            Return Nombredearchivo
        End Try
        Return Nombredearchivo
    End Function
    Function Crea_Texto_promocion(ByVal CC As String, ByVal SM As String, ByVal CantidadPromocion As Integer) As String
        Dim TextoPrecio = ""
        Select Case CC
            Case "690", "710", "716"
                If SM = "2015" Then
                    Select Case CantidadPromocion
                        Case 5200
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en Closet según casa muestra"
                        Case 10000
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 2 Closet según casa muestra"
                        Case 22500
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 1 cocina con estufa y campana"
                        Case 26000
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 1 cocina con estufa, campana y un closet"
                        Case 30000
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 1 cocina con estufa y campana y dos closet"
                        Case 2400
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico"
                        Case 7600
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico y un closet"
                        Case 12400
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico y dos closet"
                        Case 24900
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico y cocina con estufa y campana"
                        Case 32400
                            TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico y cocina con estufa y campana y 2 closet"
                    End Select
                Else
                    Select Case CantidadPromocion
                        Case 5200
                            TextoPrecio += " MAS $5,200.00 (" + cantidad_Letras(5200) + " PESOS 00/100 M.N.).) de equipamiento consistente en un closet"
                        Case 10000
                            TextoPrecio += " MAS $10,000.00 (" + cantidad_Letras(10000) + " PESOS 00/100 M.N.).) de equipamiento consistente en dos closet"
                        Case 22500
                            TextoPrecio += " MAS $22,500.00 (" + cantidad_Letras(22500) + " PESOS 00/100 M.N.).) de equipamiento consistente en cocina integral con estufa y campana"
                        Case 26000
                            TextoPrecio += " MAS $26,000.00 (" + cantidad_Letras(26000) + " PESOS 00/100 M.N.).) de equipamiento consistente en cocina integral con estufa y campana y 1 closet"
                        Case 30000
                            TextoPrecio += " MAS $30,000.00 (" + cantidad_Letras(30000) + " PESOS 00/100 M.N.).) de equipamiento consistente en cocina integral con estufa y campana y 2 closet"
                        Case 2400
                            TextoPrecio += " MAS $2,400.00 (" + cantidad_Letras(2400) + " PESOS 00/100 M.N.).) de equipamiento consistente en un cancel con acrílico en el baño"
                    End Select
                End If

            Case "402"
                Select Case CantidadPromocion
                    Case 4200
                        TextoPrecio += " MAS $4,200.00 (" + cantidad_Letras(4200) + " PESOS 00/100 M.N.).) de equipamiento consistente en un closet"
                    Case 14000
                        TextoPrecio += " MAS $14,000.00 (" + cantidad_Letras(14000) + " PESOS 00/100 M.N.).) de equipamiento consistente en cocina integral"
                    Case 18000
                        TextoPrecio += " MAS $18,000.00 (" + cantidad_Letras(18000) + " PESOS 00/100 M.N.).) de equipamiento consistente en cocina integral y un closet"
                End Select
            Case "465", "730"
                If SM = "VENET" Then
                    Select Case CantidadPromocion
                        Case 4200
                            TextoPrecio += " MAS $4,200.00 (" + cantidad_Letras(4200) + " PESOS 00/100 M.N.).) de equipamiento consistente en un closet en recamara secundaria"
                        Case 7900
                            TextoPrecio += " MAS $7,900.00 (" + cantidad_Letras(7900) + " PESOS 00/100 M.N.).) de equipamiento consistente en un closet en recamara principal 3.50mts"
                        Case 12000
                            TextoPrecio += " MAS $12,000.00 (" + cantidad_Letras(12000) + " PESOS 00/100 M.N.).) de equipamiento consistente en dos closet, uno en recamara principal y otro en recamara secundaria"
                    End Select
                End If
            Case "740"
                Select Case CantidadPromocion
                    Case 5000
                        TextoPrecio += " MAS $5,000.00 (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en un closet según casa muestra"
                    Case 10000
                        TextoPrecio += " MAS $10,000.00 (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en dos closet según casa muestra"
                    Case 17000
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 1 cocina de 2.10m con parrilla"
                    Case 22000
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 1 cocina de 2.10m con parrilla, campana y 1 closet"
                    Case 27000
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en 1 cocina de 2.10m con parrilla, campana y 2 closet"
                    Case 2400
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico"
                    Case 7400
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico y closet"
                    Case 12400
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico y 2 closet"
                    Case 19400
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico, cocina de 2.10m y campana"
                    Case 29400
                        TextoPrecio += " MAS " + CantidadPromocion.ToString("c") + " (" + cantidad_Letras(CantidadPromocion) + " PESOS 00/100 M.N.).) de equipamiento consistente en cancel para baño en acrílico,2 closet, cocina de 2.10m con parrilla y campana"

                End Select
        End Select
        Return TextoPrecio
    End Function
    Private Function PaginarPDF(ByVal RutaArchivo As String) As String
        Dim outputFilePath As String = "C:\Contratos\Download\"
        Dim NumeroAleatorio As New Random
        Dim nombrearchivo As String = "Contrato-" + NumeroAleatorio.Next(1, 5000).ToString + "-" + Now.ToString("yyMMddhhmm") + ".pdf"
        outputFilePath += nombrearchivo
        'Path to where the pdf you want to modify is
        Dim inputFilePath As String = RutaArchivo
        Try
            Using inputPdfStream As Stream = New FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                Using outputPdfStream As Stream = New FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
                    Using outputPdfStream2 As Stream = New FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                        'Opens the unmodified PDF for reading
                        Dim reader = New PdfReader(inputPdfStream)
                        'Creates a stamper to put an image on the original pdf
                        Dim stamper = New PdfStamper(reader, outputPdfStream)
                        Dim FONTbase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

                        Dim X As Integer = 0
                        Dim Y As Integer = 0

                        X = 530
                        Y = 4

                        Dim cb As PdfContentByte
                        'Adds the image to the output pdf

                        For I = 1 To reader.NumberOfPages
                            cb = stamper.GetOverContent(I)
                            cb.BeginText()
                            cb.SetFontAndSize(FONTbase, 10)
                            cb.SetTextMatrix(X, Y)
                            'Primer valor es horizontal segundo vertical
                            cb.ShowText("Página " + I.ToString + " de " + reader.NumberOfPages.ToString)
                            cb.EndText()
                        Next

                        'Creates the first copy of the outputted pdf
                        stamper.Close()

                        'Opens our outputted file for reading
                        Dim reader2 = New PdfReader(outputPdfStream2)

                        'Encrypts the outputted PDF to make it not allow Copy or Pasting
                        PdfEncryptor.Encrypt(reader2, outputPdfStream2, Nothing, Encoding.UTF8.GetBytes("test"), PdfWriter.ALLOW_PRINTING, True)
                        'Creates the outputted final file
                        reader2.Close()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Dim hola As String = ""
            Return nombrearchivo
        End Try
        Return nombrearchivo
    End Function

    Private Sub unir(ByVal Datos As Servicio.CDatosContratoNuevo, ByVal SelCredito As Integer, ByVal CC As String)
        'PDF Document List
        Dim Documento1 As New Spire.Pdf.PdfDocument("C:\Contratos\Download\DoctoPDF.PDF")
        Dim SIC2 As New Spire.Pdf.PdfDocument("C:\Contratos\SIC2.pdf")


        'Descripcion
        If Datos.Formato_adicional = "-" Then
            Documento1.SaveToFile("C:\Contratos\Download\DoctoPDF.PDF")
            ExtraerPaginasPDF("C:\Contratos\Download\DoctoPDF.PDF", "C:\Contratos\Download\Final.PDF", 2, 99999)
        Else

            'Formato de autorización
            If Bl.ObtenerTerreno(CC) Then
            Else

                If SelCredito = 1 Then
                    Documento1.AppendPage(SIC2)
                End If
            End If

            Dim Documento2 As New Spire.Pdf.PdfDocument(Trim(Datos.Formato_adicional))
            Documento1.AppendPage(Documento2)

            'Adicionales
            If Datos.Formato_adicional2 = "-Sin Adicional-" Then
            Else
                Dim Documento3 As New Spire.Pdf.PdfDocument(Trim(Datos.Formato_adicional2))
                Documento1.AppendPage(Documento3)
            End If
            Documento1.SaveToFile("C:\Contratos\Download\DoctoPDF.PDF")
            Eliminar_marca_agua(SelCredito, CC)
            ExtraerPaginasPDF("C:\Contratos\Download\DoctoPDF2.PDF", "C:\Contratos\Download\Final.PDF", 2, 99999)

        End If
    End Sub

    Private Sub Eliminar_marca_agua(ByVal TipoCredito As Integer, Optional ByVal SelFrac As String = "")
        'Path to where you want the file to output
        Dim outputFilePath As String = "C:\Contratos\Download\DoctoPDF2.PDF"
        'Path to where the pdf you want to modify is
        Dim inputFilePath As String = "C:\Contratos\Download\DoctoPDF.PDF"
        Try
            Using inputPdfStream As Stream = New FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                Using outputPdfStream As Stream = New FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
                    Using outputPdfStream2 As Stream = New FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                        'Opens the unmodified PDF for reading
                        Dim reader = New PdfReader(inputPdfStream)
                        'Creates a stamper to put an image on the original pdf
                        Dim stamper = New PdfStamper(reader, outputPdfStream)

                        'Creates an image that is the size i need to hide the text i'm interested in removing
                        Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(New System.Drawing.Bitmap(340, 10), iTextSharp.text.BaseColor.WHITE)
                        'Sets the position that the image needs to be placed (ie the location of the text to be removed)
                        'image.SetAbsolutePosition(0, 781)

                        'Adds the image to the output pdf

                        If SelFrac = "840" And TipoCredito = 5 Then
                            image.SetAbsolutePosition(0, 830)
                        ElseIf SelFrac = "840" And TipoCredito = 6 Then
                            image.SetAbsolutePosition(0, 830)
                        Else
                            image.SetAbsolutePosition(0, 781)
                        End If

                        If TipoCredito = 6 Then
                            'stamper.GetOverContent(5).AddImage(image, True)
                        Else
                            stamper.GetOverContent(4).AddImage(image, True)
                        End If

                        stamper.GetOverContent(5).AddImage(image, True)

                        ' stamper.GetOverContent(3).AddImage(image, True)
                        'Creates the first copy of the outputted pdf
                        stamper.Close()

                        'Opens our outputted file for reading
                        Dim reader2 = New PdfReader(outputPdfStream2)

                        'Encrypts the outputted PDF to make it not allow Copy or Pasting
                        'PdfEncryptor.Encrypt(reader2, outputPdfStream2, Nothing, Encoding.UTF8.GetBytes("test"), PdfWriter.ALLOW_PRINTING, True)
                        'Creates the outputted final file
                        reader2.Close()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Dim hola As String = ""
        End Try


    End Sub
    Private Sub SearchAndReplaceCONTADO(ByVal document As String, ByVal NombreCliente As String, ByVal Nlote As String, ByVal NManzana As String, ByVal NomFraccStr As String, ByVal DirCasa As String,
                                        ByVal TextoDesglosePago As String, ByVal TextoDesglocePrecio As String, ByVal TextoPrecioCasa As String, ByVal TextoDetallesPrecioCasa As String)
        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(document, True)

        Using (wordDoc)
            Dim docText As String = Nothing
            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

            Using (sr)
                docText = sr.ReadToEnd
            End Using

            Dim NombreClienteReg As Regex = New Regex("XXNOMBRECLIENTEXX")
            Dim NLoteReg As Regex = New Regex("XXNUMEROLOTEXX")
            Dim NManzanaReg As Regex = New Regex("XXNUMEROMANZANAXX")
            Dim NomFracc As Regex = New Regex("XXFRACCIONAMIENTOXX")
            Dim DirCasaReg As Regex = New Regex("XXDIRCASAXX")
            Dim DetallesPrecioReg As Regex = New Regex("XXDETALLESPRECIOXX")
            Dim PrecioCasareg As Regex = New Regex("XXPRECIOCASAXX")
            Dim DetallesPagoreg As Regex = New Regex("XXDETALLESPRECIOXX")
            Dim DesglosePagoReg As Regex = New Regex("XXDETALLESPAGOXX")
            Dim FechaHoy As Regex = New Regex("XXFECHAHOYXX")
            Dim FechaImpresion As Regex = New Regex("XXIMPRESIONFECHAXX")

            docText = NombreClienteReg.Replace(docText, NombreCliente)
            docText = NLoteReg.Replace(docText, Nlote)
            docText = NManzanaReg.Replace(docText, NManzana)
            docText = NomFracc.Replace(docText, NomFraccStr)
            docText = DirCasaReg.Replace(docText, DirCasa)
            docText = DetallesPrecioReg.Replace(docText, TextoDesglocePrecio)
            docText = PrecioCasareg.Replace(docText, TextoPrecioCasa)
            docText = DetallesPagoreg.Replace(docText, TextoDetallesPrecioCasa)
            docText = DesglosePagoReg.Replace(docText, TextoDesglosePago)
            docText = FechaHoy.Replace(docText, Now.ToLongDateString)
            docText = FechaImpresion.Replace(docText, "León, Gto. a " & Now.ToLongDateString)

            Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
            Using (sw)
                sw.Write(docText)
            End Using
        End Using
    End Sub
    Function CreaTablaAmort(ByVal precioVenta As Decimal, ByVal Meses As Integer) As String
        Dim Resultado As String = ""
        Dim aux As String = ""
        Dim LineaChar As Integer = 122
        '       <w:r>
        '           <w:t>Hello</w:t>
        '           <w:br/>
        '           <w:t>world</w:t>
        '       </w:r>
        'Select Case Meses
        '    Case 1
        '        LineaChar = 115
        '    Case 12
        '        LineaChar = 115
        '    Case 24
        '        LineaChar = 115
        'End Select

        Dim Amortizacion As Decimal = 0.0

        Amortizacion = (precioVenta - (precioVenta * 0.1)) / Meses 'Cantida enganche

        For I = 0 To Meses - 1
            Amortizacion = Math.Round(Amortizacion, 0)
            aux = (I + 1).ToString + ".- " + Amortizacion.ToString("c") + " (" + cantidad_Letras(Amortizacion) + " pesos 00/100 m.n.) con fecha límite de pago el " + Now.AddMonths(I + 1).ToLongDateString + " "

            Dim Caracteres As Integer = 0

            Caracteres = aux.Count

            If Not Caracteres > LineaChar Then
                Caracteres = aux.Count - LineaChar
            End If

            For J = Caracteres To LineaChar - 1
                aux += " "
            Next
            Resultado += aux

            aux = ""
            Resultado += aux
        Next

        Return Resultado
    End Function
    Private Sub BuscarYRemplazarTerrenos(ByVal document As String, ByVal Datos As CDatosterreno, ByVal Plazo As Servicio.CPlazosTerreno)
        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(document, True)

        Using (wordDoc)
            Dim docText As String = Nothing
            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

            Using (sr)
                docText = sr.ReadToEnd
            End Using

            Datos.TablaAmort = CreaTablaAmort(Datos.CantidadVenta, Plazo.plazo)

            docText = docText.Replace("XXDIAXX", Now.ToString("dd"))
            docText = docText.Replace("XXMESXX", Now.ToString("MMMM"))
            docText = docText.Replace("XXAÑOXX", Now.ToString("yyyy"))

            docText = docText.Replace("XXNOMBRECLIENTEXX", Datos.NombreCompletoCliente)
            docText = docText.Replace("XXDIRECCIONCOMPRAXX", Datos.DireccionDeCompra)
            docText = docText.Replace("XXMETROXX", Datos.MetrosCompra.ToString)
            docText = docText.Replace("XXCANTIDADVENTAXX", Datos.CantidadVenta.ToString("c") + " (" + cantidad_Letras(Datos.CantidadVenta) + " pesos 00/100 m.n.)")
            docText = docText.Replace("XXENGANCHEXX", Datos.CantidadEnganche.ToString("c") + " (" + cantidad_Letras(Datos.CantidadEnganche) + " pesos 00/100 m.n.)")
            docText = docText.Replace("XXPAGOSXX", Datos.TablaAmort)
            docText = docText.Replace("XXDIRACTUALXX", Datos.DireccionActual)


            Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
            Using (sw)
                sw.Write(docText)
            End Using
        End Using

    End Sub
    Private Sub SearchAndReplace(ByVal document As String, ByVal Datos As Servicio.CDatosContratoNuevo, ByVal NombreCliente As String,
                                 ByVal Ahorro As Integer, ByVal TextoAdicionales1 As String, ByVal TextoAdicionales2 As String, ByVal TextoAdicionales3 As String, ByVal TextoAdicionales4 As String)
        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(document, True)

        Using (wordDoc)
            Dim docText As String = Nothing
            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

            Using (sr)
                docText = sr.ReadToEnd
            End Using
            Dim NombreClienteReg As Regex = New Regex("XXNOMBRECLIENTEXX")
            Dim TC_Abrev As Regex = New Regex("XXCREDITOXX")
            Dim Nombre_CC As Regex = New Regex("XXNOMBREFRACCXX")
            Dim NomTCredito As Regex = New Regex("XXNOMBRETIPOCREDXX")
            Dim ModCasa As Regex = New Regex("XXTIPOCASAXX")
            Dim Superfice As Regex = New Regex("XXSUPERFICIEXX")
            Dim MConstruccion As Regex = New Regex("XXCONSTRUCCIONXX")
            Dim fdtu As Regex = New Regex("XXFECHALIMITEXX")
            Dim PPREVIO As Regex = New Regex("XXCANTIDADINICIOXX")
            Dim PFINAL As Regex = New Regex("XXCANTIDADFINALXX")
            Dim CTOTAL As Regex = New Regex("XXCANTIDADTOTALXX")
            Dim CENGANCHE As Regex = New Regex("XXENGANCHEXX")


            Dim CTOTALLETRAS As Regex = New Regex("XXCANTIDADTOTALXX")
            Dim CCANTITADLETRASBASE As Regex = New Regex("XXCANTIDADLETRASBASEXX")
            Dim CBONOLETRAS As Regex = New Regex("XXBONOLETRASXX")
            Dim CADICONALES As Regex = New Regex("XXADICIONAL1XX")
            Dim CADICONALES2 As Regex = New Regex("XXADICIONAL2XX")
            Dim CADICONALES3 As Regex = New Regex("XXADICIONAL3XX")
            Dim CADICONALES4 As Regex = New Regex("XXADICIONAL4XX")
            Dim FechaImpresion As Regex = New Regex("XXIMPRESIONFECHAXX")


            docText = CTOTALLETRAS.Replace(docText, Datos.Precio_Total)
            docText = CCANTITADLETRASBASE.Replace(docText, Datos.Precio_Casa.ToString("c") + " (" + cantidad_Letras(Datos.Precio_Casa) + " PESOS 00/100 M.N.)")

            Dim CantidadBono As Integer = Datos.Bono - Ahorro
            Dim TextoPromocionBono As String = (CantidadBono).ToString("c") & " (" & cantidad_Letras(CantidadBono) & " PESOS 00/100 M.N.)"

            'docText = CBONOLETRAS.Replace(docText, TextoPromocionBono)
            docText = docText.Replace("XXBONOLETRASXX", TextoPromocionBono)

            docText = CADICONALES.Replace(docText, TextoAdicionales1)
            docText = CADICONALES2.Replace(docText, TextoAdicionales2)
            docText = docText.Replace("XXADICIONAL3XX", TextoAdicionales3)
            docText = docText.Replace("XXADICIONAL4XX", TextoAdicionales4)

            docText = NombreClienteReg.Replace(docText, NombreCliente)
            docText = TC_Abrev.Replace(docText, Datos.TC_Abreviatura)
            docText = Nombre_CC.Replace(docText, Datos.Nombre_CC)
            docText = NomTCredito.Replace(docText, Datos.TC_Nombre)
            docText = ModCasa.Replace(docText, Datos.Modelo_casa)

            docText = Superfice.Replace(docText, FormatNumber(Datos.Superficie, 2).ToString)
            docText = MConstruccion.Replace(docText, Datos.Mtrs_Construccion.ToString)
            docText = fdtu.Replace(docText, Datos.Fecha_DTU.ToLongDateString)
            docText = PPREVIO.Replace(docText, Datos.Pen_Previo.ToString("c"))
            docText = PFINAL.Replace(docText, Datos.Pen_Final.ToString("c"))
            docText = CTOTAL.Replace(docText, Datos.Precio_Total)
            docText = CENGANCHE.Replace(docText, Datos.Cantidad_Enganche.ToString("c") +
                                        " (" + cantidad_Letras(Datos.Cantidad_Enganche) + "pesos M.N.)")

            docText = docText.Replace("XXADICIONAL1XX.00", "0.00")
            docText = FechaImpresion.Replace(docText, Now.ToLongDateString)

            Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
            Using (sw)
                sw.Write(docText)
            End Using
        End Using
    End Sub
    Private Sub BuscaYReemplaza(ByVal document As String)
        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(document, True)

        Using (wordDoc)
            Dim docText As String = Nothing
            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

            Using (sr)
                docText = sr.ReadToEnd
            End Using
            Dim NombreClienteReg As Regex = New Regex("XXNOMBRECLIENTEXX")

            ' docText = CTOTALLETRAS.Replace(docText, Datos.Precio_Total)

            Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
            Using (sw)
                sw.Write(docText)
            End Using
        End Using
    End Sub
    Private Sub ExtraerPaginasPDF(inputFile As String, outputFile As String, start As Integer, [end] As Integer)
        ' get input document
        Dim inputPdf As New PdfReader(inputFile)

        ' retrieve the total number of pages
        Dim pageCount As Integer = inputPdf.NumberOfPages

        If [end] < start OrElse [end] > pageCount Then
            [end] = pageCount
        End If

        ' load the input document
        Dim inputDoc As New iTextSharp.text.Document(inputPdf.GetPageSizeWithRotation(1))

        ' create the filestream
        Using fs As New FileStream(outputFile, FileMode.Create)
            ' create the output writer 
            Dim outputWriter As PdfWriter = PdfWriter.GetInstance(inputDoc, fs)
            inputDoc.Open()
            Dim cb1 As PdfContentByte = outputWriter.DirectContent

            ' copy pages from input to output document
            For i As Integer = start To [end]
                inputDoc.SetPageSize(inputPdf.GetPageSizeWithRotation(i))
                inputDoc.NewPage()

                Dim page As PdfImportedPage = outputWriter.GetImportedPage(inputPdf, i)
                Dim rotation As Integer = inputPdf.GetPageRotation(i)

                If rotation = 90 OrElse rotation = 270 Then
                    cb1.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0,
                        inputPdf.GetPageSizeWithRotation(i).Height)
                Else
                    cb1.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0,
                        0)
                End If
            Next

            inputDoc.Close()
        End Using
    End Sub

    Function Crea_Texto_Precio(ByVal Mtrs As Double, ByVal Precio_mtr As Integer, ByVal PrecioMuro As Double) As String
        System.Threading.Thread.CurrentThread.CurrentUICulture =
        System.Globalization.CultureInfo.GetCultureInfo("es-MX")
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("es-MX")
        Dim a As Integer = RoundUp((Mtrs * Precio_mtr))

        a += PrecioMuro

        Dim res As String = ""
        'res = vbCrLf
        'res += Precio_Casa.ToString("c")
        'res += "(" + cantidad_Letras(Precio_Casa) + " PESOS 00/100 M.N.)."
        If Mtrs > 0 Or PrecioMuro > 0 Then
            res += "c) MAS " + (a).ToString("c")
            res += "(" + cantidad_Letras(a) + " PESOS 00/100 M.N.)."
            If PrecioMuro > 0 Then
                res += " CORRESPONDIENTES A TERRENO ADICIONAL. "
            Else
                res += " CORRESPONDIENTES A " + Mtrs.ToString + " M2 DE TERRENO EXCEDENTE."
            End If

        End If
        res += vbCrLf
        Return res
    End Function
    Private Function RoundUp(ByVal Cantidad As Double) As Integer
        Dim Aux As Double = Cantidad / 1000
        Aux = Math.Round(Aux, 1)
        Return Aux * 1000
    End Function
    Private Function RoundUpCientos(ByVal Cantidad As Integer) As Integer
        Dim Aux As Double = Cantidad / 100
        Aux = Math.Round(Aux, 1)
        Return Aux * 100
    End Function
    Private Sub EliminaArchivos()
        File.Delete("C:\Contratos\Download\DoctoPDF.PDF")
        File.Delete("C:\Contratos\Download\DoctoPDF2.PDF")
        File.Delete("C:\Contratos\Download\Contrato.docx")
        File.Delete("C:\Contratos\Download\Final.pdf")
        File.Delete("C:\Contratos\Download\Final2.pdf")
    End Sub

    'Private Function dsad(ByVal numero As String) As String
    '    '********Declara variables de tipo cadena************
    '    Dim palabras As String = ""
    '    Dim entero As String = ""
    '    Dim dec As String = ""
    '    Dim flag As String = ""

    '    '********Declara variables de tipo entero***********
    '    Dim num, x, y As Integer

    '    flag = "N"

    '    '**********Número Negativo***********
    '    If Mid(numero, 1, 1) = "-" Then
    '        numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
    '        palabras = "menos "
    '    End If

    '    '**********Si tiene ceros a la izquierda*************
    '    For x = 1 To numero.ToString.Length
    '        If Mid(numero, 1, 1) = "0" Then
    '            numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
    '            If Trim(numero.ToString.Length) = 0 Then palabras = ""
    '        Else
    '            Exit For
    '        End If
    '    Next

    '    '*********Dividir parte entera y decimal************
    '    For y = 1 To Len(numero)
    '        If Mid(numero, y, 1) = "." Then
    '            flag = "S"
    '        Else
    '            If flag = "N" Then
    '                entero = entero + Mid(numero, y, 1)
    '            Else
    '                dec = dec + Mid(numero, y, 1)
    '            End If
    '        End If
    '    Next y

    '    If Len(dec) = 1 Then dec = dec & "0"

    '    '**********proceso de conversión***********
    '    flag = "N"

    '    If Val(numero) <= 999999999 Then
    '        For y = Len(entero) To 1 Step -1
    '            num = Len(entero) - (y - 1)
    '            Select Case y
    '                Case 3, 6, 9
    '                    '**********Asigna las palabras para las centenas***********
    '                    Select Case Mid(entero, num, 1)
    '                        Case "1"
    '                            If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
    '                                palabras = palabras & "cien "
    '                            Else
    '                                palabras = palabras & "ciento "
    '                            End If
    '                        Case "2"
    '                            palabras = palabras & "doscientos "
    '                        Case "3"
    '                            palabras = palabras & "trescientos "
    '                        Case "4"
    '                            palabras = palabras & "cuatrocientos "
    '                        Case "5"
    '                            palabras = palabras & "quinientos "
    '                        Case "6"
    '                            palabras = palabras & "seiscientos "
    '                        Case "7"
    '                            palabras = palabras & "setecientos "
    '                        Case "8"
    '                            palabras = palabras & "ochocientos "
    '                        Case "9"
    '                            palabras = palabras & "novecientos "
    '                    End Select
    '                Case 2, 5, 8
    '                    '*********Asigna las palabras para las decenas************
    '                    Select Case Mid(entero, num, 1)
    '                        Case "1"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                flag = "S"
    '                                palabras = palabras & "diez "
    '                            End If
    '                            If Mid(entero, num + 1, 1) = "1" Then
    '                                flag = "S"
    '                                palabras = palabras & "once "
    '                            End If
    '                            If Mid(entero, num + 1, 1) = "2" Then
    '                                flag = "S"
    '                                palabras = palabras & "doce "
    '                            End If
    '                            If Mid(entero, num + 1, 1) = "3" Then
    '                                flag = "S"
    '                                palabras = palabras & "trece "
    '                            End If
    '                            If Mid(entero, num + 1, 1) = "4" Then
    '                                flag = "S"
    '                                palabras = palabras & "catorce "
    '                            End If
    '                            If Mid(entero, num + 1, 1) = "5" Then
    '                                flag = "S"
    '                                palabras = palabras & "quince "
    '                            End If
    '                            If Mid(entero, num + 1, 1) > "5" Then
    '                                flag = "N"
    '                                palabras = palabras & "dieci"
    '                            End If
    '                        Case "2"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "veinte "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "veinti"
    '                                flag = "N"
    '                            End If
    '                        Case "3"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "treinta "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "treinta y "
    '                                flag = "N"
    '                            End If
    '                        Case "4"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "cuarenta "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "cuarenta y "
    '                                flag = "N"
    '                            End If
    '                        Case "5"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "cincuenta "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "cincuenta y "
    '                                flag = "N"
    '                            End If
    '                        Case "6"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "sesenta "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "sesenta y "
    '                                flag = "N"
    '                            End If
    '                        Case "7"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "setenta "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "setenta y "
    '                                flag = "N"
    '                            End If
    '                        Case "8"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "ochenta "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "ochenta y "
    '                                flag = "N"
    '                            End If
    '                        Case "9"
    '                            If Mid(entero, num + 1, 1) = "0" Then
    '                                palabras = palabras & "noventa "
    '                                flag = "S"
    '                            Else
    '                                palabras = palabras & "noventa y "
    '                                flag = "N"
    '                            End If
    '                    End Select
    '                Case 1, 4, 7
    '                    '*********Asigna las palabras para las unidades*********
    '                    Select Case Mid(entero, num, 1)
    '                        Case "1"
    '                            If flag = "N" Then
    '                                If y = 1 Then
    '                                    palabras = palabras & "uno "
    '                                Else
    '                                    palabras = palabras & "un "
    '                                End If
    '                            End If
    '                        Case "2"
    '                            If flag = "N" Then palabras = palabras & "dos "
    '                        Case "3"
    '                            If flag = "N" Then palabras = palabras & "tres "
    '                        Case "4"
    '                            If flag = "N" Then palabras = palabras & "cuatro "
    '                        Case "5"
    '                            If flag = "N" Then palabras = palabras & "cinco "
    '                        Case "6"
    '                            If flag = "N" Then palabras = palabras & "seis "
    '                        Case "7"
    '                            If flag = "N" Then palabras = palabras & "siete "
    '                        Case "8"
    '                            If flag = "N" Then palabras = palabras & "ocho "
    '                        Case "9"
    '                            If flag = "N" Then palabras = palabras & "nueve "
    '                    End Select
    '            End Select

    '            '***********Asigna la palabra mil***************
    '            If y = 4 Then
    '                If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
    '                (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
    '                Len(entero) <= 6) Then palabras = palabras & "mil "
    '            End If

    '            '**********Asigna la palabra millón*************
    '            If y = 7 Then
    '                If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
    '                    palabras = palabras & "millón "
    '                Else
    '                    palabras = palabras & "millones "
    '                End If
    '            End If
    '        Next y

    '        '**********Une la parte entera y la parte decimal*************
    '        If dec <> "" Then
    '            cantidad_Letras = palabras & "con " & dec
    '        Else
    '            cantidad_Letras = palabras
    '        End If
    '    Else
    '        cantidad_Letras = ""
    '    End If
    'End Function
    Public Function cantidad_Letras(ByVal value As Double) As String
        If value < 0 Then
            value = value * -1
        End If

        Select Case value
            Case 0 : cantidad_Letras = "CERO"
            Case 1 : cantidad_Letras = "UN"
            Case 2 : cantidad_Letras = "DOS"
            Case 3 : cantidad_Letras = "TRES"
            Case 4 : cantidad_Letras = "CUATRO"
            Case 5 : cantidad_Letras = "CINCO"
            Case 6 : cantidad_Letras = "SEIS"
            Case 7 : cantidad_Letras = "SIETE"
            Case 8 : cantidad_Letras = "OCHO"
            Case 9 : cantidad_Letras = "NUEVE"
            Case 10 : cantidad_Letras = "DIEZ"
            Case 11 : cantidad_Letras = "ONCE"
            Case 12 : cantidad_Letras = "DOCE"
            Case 13 : cantidad_Letras = "TRECE"
            Case 14 : cantidad_Letras = "CATORCE"
            Case 15 : cantidad_Letras = "QUINCE"
            Case Is < 20 : cantidad_Letras = "DIECI" & cantidad_Letras(value - 10)
            Case 20 : cantidad_Letras = "VEINTE"
            Case Is < 30 : cantidad_Letras = "VEINTI" & cantidad_Letras(value - 20)
            Case 30 : cantidad_Letras = "TREINTA"
            Case 40 : cantidad_Letras = "CUARENTA"
            Case 50 : cantidad_Letras = "CINCUENTA"
            Case 60 : cantidad_Letras = "SESENTA"
            Case 70 : cantidad_Letras = "SETENTA"
            Case 80 : cantidad_Letras = "OCHENTA"
            Case 90 : cantidad_Letras = "NOVENTA"
            Case Is < 100 : cantidad_Letras = cantidad_Letras(Int(value \ 10) * 10) & " Y " & cantidad_Letras(value Mod 10)
            Case 100 : cantidad_Letras = "CIEN"
            Case Is < 200 : cantidad_Letras = "CIENTO " & cantidad_Letras(value - 100)
            Case 200, 300, 400, 600, 800 : cantidad_Letras = cantidad_Letras(Int(value \ 100)) & "CIENTOS"
            Case 500 : cantidad_Letras = "QUINIENTOS"
            Case 700 : cantidad_Letras = "SETECIENTOS"
            Case 900 : cantidad_Letras = "NOVECIENTOS"
            Case Is < 1000 : cantidad_Letras = cantidad_Letras(Int(value \ 100) * 100) & " " & cantidad_Letras(value Mod 100)
            Case 1000 : cantidad_Letras = "MIL"
            Case Is < 2000 : cantidad_Letras = "MIL " & cantidad_Letras(value Mod 1000)
            Case Is < 1000000 : cantidad_Letras = cantidad_Letras(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then cantidad_Letras = cantidad_Letras & " " & cantidad_Letras(value Mod 1000)
            Case 1000000 : cantidad_Letras = "UN MILLON"
            Case Is < 2000000 : cantidad_Letras = "UN MILLON " & cantidad_Letras(value Mod 1000000)
            Case Is < 1000000000000.0# : cantidad_Letras = cantidad_Letras(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then cantidad_Letras = cantidad_Letras & " " & cantidad_Letras(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : cantidad_Letras = "UN BILLON"
            Case Is < 2000000000000.0# : cantidad_Letras = "UN BILLON " & cantidad_Letras(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : cantidad_Letras = cantidad_Letras(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then cantidad_Letras = cantidad_Letras & " " & cantidad_Letras(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select

    End Function

    Public Function FovisssteContrato(ByVal numcte As Integer) As String
        System.Threading.Thread.CurrentThread.CurrentUICulture =
      System.Globalization.CultureInfo.GetCultureInfo("es-MX")
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("es-MX")

        Dim NumeroAleatorio As New Random
        Dim datosCliente = Bl.Obtener_datos_cliente_contrato_fovissste(numcte)
        Dim document As String = "C:\Contratos\CONTRATOFOVISSSTE.docx"
        Dim Destino As String = "C:\Contratos\Download\"
        Dim nombreArchivo As String = "ContratoFovissste-" + NumeroAleatorio.Next(0, 500).ToString + "-" + Now.ToString("yyyy-MM-dd") + "-" + numcte.ToString + ".docx"
        Destino += nombreArchivo
        FileCopy(document, Destino)
        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(Destino, True)

        Using (wordDoc)
            Dim docText As String = Nothing
            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

            Using (sr)
                docText = sr.ReadToEnd
            End Using
            Dim NombreCliente As Regex = New Regex("XXNOMBRECLIENTEXX")
            Dim FNacimeinto As Regex = New Regex("XXFECHANACIMIENTOXX")
            Dim XXESTADOCIVILXX As Regex = New Regex("XXESTADOCIVILXX")
            Dim XXOCUPACIONXX As Regex = New Regex("XXOCUPACIONXX")
            Dim XXDIRCASAXX As Regex = New Regex("XXDIRCASAXX")
            Dim XXRFCXX As Regex = New Regex("XXRFCXX")
            Dim XXESQUEMAXX As Regex = New Regex("XXESQUEMAXX")
            Dim XXPRECIOCASAXX As Regex = New Regex("XXPRECIOCASAXX")
            Dim XXCANTIDADLETRASXX As Regex = New Regex("XXCANTIDADLETRASXX")
            Dim XXFECHALARGAXX As Regex = New Regex("XXFECHALARGAXX")
            Dim XXMETRO2XX As Regex = New Regex("XXMETRO2XX")

            Dim XXCOLINDANCIASXX As Regex = New Regex("XXCOLINDANCIASXX")

            Dim XXLOTEXX As Regex = New Regex("XXLOTEXX")
            Dim XXMZAXX As Regex = New Regex("XXMZAXX")
            Dim XXNOMFRACCXX As Regex = New Regex("XXNOMFRACCXX")
            Dim XXNUMEROXX As Regex = New Regex("XXNUMEROXX")

            If datosCliente.Edo_civil = "S" Then
                datosCliente.Edo_civil = "SOLTERO"
            Else
                datosCliente.Edo_civil = "CASADO"
            End If

            docText = NombreCliente.Replace(docText, datosCliente.NombreCliente)
            docText = FNacimeinto.Replace(docText, datosCliente.Fec_Nac.ToLongDateString)
            docText = XXESTADOCIVILXX.Replace(docText, datosCliente.Edo_civil)
            docText = XXOCUPACIONXX.Replace(docText, datosCliente.puesto)
            docText = XXDIRCASAXX.Replace(docText, datosCliente.Dir_Casa)
            docText = XXRFCXX.Replace(docText, datosCliente.RFC_cte)
            docText = XXESQUEMAXX.Replace(docText, datosCliente.id_num_relacion.ToString)
            docText = XXPRECIOCASAXX.Replace(docText, datosCliente.valor_total.ToString("c"))
            docText = XXCANTIDADLETRASXX.Replace(docText, cantidad_Letras(datosCliente.valor_total))
            docText = XXFECHALARGAXX.Replace(docText, Now.ToLongDateString)

            docText = XXMETRO2XX.Replace(docText, datosCliente.Cant_superficie.ToString)
            docText = XXCOLINDANCIASXX.Replace(docText, datosCliente.Desc_Colindancia)

            docText = XXLOTEXX.Replace(docText, datosCliente.id_num_lote.ToString)
            docText = XXMZAXX.Replace(docText, datosCliente.id_num_mza.ToString)
            docText = XXNOMFRACCXX.Replace(docText, datosCliente.nom_fracc)

            docText = XXNUMEROXX.Replace(docText, datosCliente.id_num_interior.ToString)

            Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
            Using (sw)
                sw.Write(docText)
            End Using
        End Using

        Return nombreArchivo
    End Function
    Class CDatosterreno
        Public Property NombreCompletoCliente As String = "-"
        Public Property DireccionDeCompra As String = "-"
        Public Property MetrosCompra As Decimal = 0.0
        Public Property CantidadVenta As Decimal = 0.0
        Public Property CantidadEnganche As Decimal = 0.0
        Public Property TablaAmort As String = "-"
        Public Property DireccionActual As String = "-"
    End Class
End Module
