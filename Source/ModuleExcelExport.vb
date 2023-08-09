
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Module ModuleExcelExport
    Public Sub ExportToExcel()
        Dim oXL As Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim oShape As Excel.Shape
        Dim oChart As Excel.Chart
        Dim oSeriesCollection As Excel.SeriesCollection
        Dim oSeries As Excel.Series
        ' Start Excel and get Application object.
        oXL = CreateObject("Excel.Application")
        ' Get a new workbook.
        oWB = oXL.Workbooks.Add
        'Get first sheet
        oSheet = oWB.Sheets(1)
        oSheet.Name = "Imported data"
        'add chart
        oShape = oSheet.Shapes.AddChart 'oWB.Charts.Add()
        oShape.Chart.ChartType = Excel.XlChartType.xlXYScatterLinesNoMarkers
        oChart = oShape.Chart
        oSeriesCollection = oChart.SeriesCollection
        Dim j As Integer
        j = 0
        For Each series In frmMain.Chart.Series
            j = j + 2
            oSheet.Cells(1, j - 1).value = "X axis"
            oSheet.Cells(1, j).value = series.Name
            For i = 1 To series.Points.Count
                oSheet.Cells(i + 1, j - 1).Value = series.Points(i - 1).XValue
                oSheet.Cells(i + 1, j).Value = series.Points(i - 1).YValues
            Next
            oSeries = oSeriesCollection.NewSeries
            With oSeries
                .Name = series.Name
                .XValues = oSheet.Range(oSheet.Cells(2, j - 1), oSheet.Cells(series.Points.Count + 1, j - 1))
                .Values = oSheet.Range(oSheet.Cells(2, j), oSheet.Cells(series.Points.Count + 1, j))
            End With
        Next
        For Each a In oChart.Axes
            a.HasMajorGridlines = True
            a.HasMinorGridlines = False
            a.Format.Line.Weight = 2
            'a.ForeColor.ObjectThemeColor = MsoThemeColorIndex.msoThemeColorText1
        Next (a)
        'With oChart.Axes(1)
        '    .CrossesAt = -180
        '    .MinimumScale = -180
        '    .MaximumScale = 180
        '    .MajorUnit = 60
        'End With
        oXL.Visible = True
    End Sub
End Module
