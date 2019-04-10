Imports System.ComponentModel

Module General
    'Public Ruta_Archivo As String = "/ProConsul/"
    Public Ruta_Archivo As String = "/"
    Public Bl As New Servicio.Service1Client
    Public Function ConvertToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim table As New DataTable()
        For Each prop As PropertyDescriptor In properties
            If prop.Name = "ExtensionData" Then
            Else
                table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
            End If
        Next
        For Each item As T In data
            Dim row As DataRow = table.NewRow()
            For Each prop As PropertyDescriptor In properties
                If prop.Name = "ExtensionData" Then
                Else
                    row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
                End If
            Next
            table.Rows.Add(row)
        Next
        Return table

    End Function
    Public Function ConvertDataTableToHTML(dt As DataTable) As String
        Dim html As String = "<table border=""1"">"
        'add header row
        html += "<tr>"
        For i As Integer = 0 To dt.Columns.Count - 1
            html += "<td>" + dt.Columns(i).ColumnName & "</td>"
        Next
        html += "</tr>"
        'add rows
        For i As Integer = 0 To dt.Rows.Count - 1
            html += "<tr>"
            For j As Integer = 0 To dt.Columns.Count - 1
                html += "<td>" & dt.Rows(i)(j).ToString() & "</td>"
            Next
            html += "</tr>"
        Next
        html += "</table>"
        Return html
    End Function
    Public Function CreaTablaMetronic(ByVal DT As DataTable) As String
        Dim html As String = ""
        'add header row
        html = "<div class=""portlet box green-haze"">" + vbCrLf
        html += "	<div class=""portlet-title"">" + vbCrLf
        html += "		<div class=""caption"">" + vbCrLf
        html += "			<i class=""fa fa-globe""></i>Tabla" + vbCrLf
        html += "		</div>" + vbCrLf
        html += "		<div class=""tools"">" + vbCrLf
        html += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        html += "			</a>" + vbCrLf
        html += "		</div>" + vbCrLf
        html += "	</div>" + vbCrLf
        html += "	<div class=""portlet-body"">" + vbCrLf
        html += " <table class=""table table-striped table-bordered table-hover"" id=""Tabla"">" + vbCrLf
        html += "<thead>" + vbCrLf
        html += "<tr>" + vbCrLf


        For i As Integer = 0 To DT.Columns.Count - 1
            html += "<th>" + DT.Columns(i).ColumnName & "</th>"
        Next

        html += "</tr>" + vbCrLf
        html += "</thead>" + vbCrLf
        html += "<tbody>" + vbCrLf
        'add rows
        For i As Integer = 0 To DT.Rows.Count - 1
            html += "<tr>"
            For j As Integer = 0 To DT.Columns.Count - 1
                html += "<td>" & DT.Rows(i)(j).ToString() & "</td>"
            Next
            html += "</tr>"
        Next
        html += "	</tbody>" + vbCrLf
        html += "	</table>" + vbCrLf
        html += "	</div>" + vbCrLf
        html += "</div>" + vbCrLf
        Return html
    End Function
    Public Function CreaTablaMetronic(ByVal DT As DataTable, ByVal TituloTabla As String) As String
        Dim html As String = ""
        'add header row
        html = "<div class=""portlet box green-haze"">" + vbCrLf
        html += "	<div class=""portlet-title"">" + vbCrLf
        html += "		<div class=""caption"">" + vbCrLf
        html += "			<i class=""fa fa-globe""></i>" + TituloTabla + "" + vbCrLf
        html += "		</div>" + vbCrLf
        html += "		<div class=""tools"">" + vbCrLf
        html += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        html += "			</a>" + vbCrLf
        html += "		</div>" + vbCrLf
        html += "	</div>" + vbCrLf
        html += "	<div class=""portlet-body"">" + vbCrLf
        html += " <table class=""table table-striped table-bordered table-hover"" id=""" + TituloTabla + """>" + vbCrLf
        html += "<thead>" + vbCrLf
        html += "<tr>" + vbCrLf


        For i As Integer = 0 To DT.Columns.Count - 1
            html += "<th>" + DT.Columns(i).ColumnName & "</th>"
        Next

        html += "</tr>" + vbCrLf
        html += "</thead>" + vbCrLf
        html += "<tbody>" + vbCrLf
        'add rows
        For i As Integer = 0 To DT.Rows.Count - 1
            html += "<tr>"
            For j As Integer = 0 To DT.Columns.Count - 1
                html += "<td>" & DT.Rows(i)(j).ToString() & "</td>"
            Next
            html += "</tr>"
        Next
        html += "	</tbody>" + vbCrLf
        html += "	</table>" + vbCrLf
        html += "	</div>" + vbCrLf
        html += "</div>" + vbCrLf
        Return html
    End Function
    Public Function CreaTablaMetronic(ByVal DT As DataTable, ByVal TituloTabla As String, ByVal URL_Cambios As String, ByVal URL_Eliminar As String, ByVal NombreCampoID As String) As String
        Dim html As String = ""
        'add header row
        html = "<div class=""portlet box green-haze"">" + vbCrLf
        html += "	<div class=""portlet-title"">" + vbCrLf
        html += "		<div class=""caption"">" + vbCrLf
        html += "			<i class=""fa fa-globe""></i>" + TituloTabla + "" + vbCrLf
        html += "		</div>" + vbCrLf
        html += "		<div class=""tools"">" + vbCrLf
        html += "			<a href=""javascript:;"" class=""remove"">" + vbCrLf
        html += "			</a>" + vbCrLf
        html += "		</div>" + vbCrLf
        html += "	</div>" + vbCrLf
        html += "	<div class=""portlet-body"">" + vbCrLf
        html += " <table class=""table table-striped table-bordered table-hover"" id=""" + TituloTabla + """>" + vbCrLf
        html += "<thead>" + vbCrLf
        html += "<tr>" + vbCrLf


        For i As Integer = 0 To DT.Columns.Count - 1
            html += "<th>" + DT.Columns(i).ColumnName & "</th>" + vbCrLf
        Next
        html += "<th>Opciones</th>" + vbCrLf

        html += "</tr>" + vbCrLf
        html += "</thead>" + vbCrLf
        html += "<tbody>" + vbCrLf
        'add rows
        For i As Integer = 0 To DT.Rows.Count - 1
            html += "<tr>" + vbCrLf
            For j As Integer = 0 To DT.Columns.Count - 1
                html += "<td>" & DT.Rows(i)(j).ToString() & "</td>" + vbCrLf
            Next
            html += "<td><a href=""" + URL_Eliminar + DT.Rows(i).Item(NombreCampoID).ToString + """ class=""btn btn-xs red"">Eliminar</a> " + vbCrLf
            html += "<a href=""" + URL_Cambios + DT.Rows(i).Item(NombreCampoID).ToString + """ class=""btn btn-xs blue"">Cambiar</a> </td>" + vbCrLf
            html += "</tr>" + vbCrLf
        Next

        html += "	</tbody>" + vbCrLf
        html += "	</table>" + vbCrLf
        html += "	</div>" + vbCrLf
        html += "</div>" + vbCrLf
        Return html
    End Function
End Module
