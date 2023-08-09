Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'в принципе структуры не особо-то и нужны для постобработки, но на всякий случай пока сохраним
        'скорее всего по мере написания буду от них избавляться
        'Задаем размеры массивов для выравнивания длинны заголовка файла
        With File_Head
            ReDim .NuCh(2)
            ReDim .NuI32(12)
        End With
        With Settings_FreeForm
            ReDim .Val(39)
            ReDim .TimeGoTo(39)
            ReDim .TimeKeep(39)
        End With

        'Заполняем строки ChckLstBox чтобы сразу можно было оценить какие данные доступны, 
        'потом это можно будет воспользоваться для заголовков при экспорте
        Dim strEnabledData As String() = {"Time", "Force", "Stoke", "Strain_1", "Strain_2", "VoltagePD", "Temperature"}
        ChckLstBoxEnableResults.Items.AddRange(strEnabledData)

        Chart.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray
        Chart.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray

        Chart.ChartAreas(0).CursorX.IsUserEnabled = True
        Chart.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        Chart.ChartAreas(0).AxisX.ScaleView.Zoomable = True

        Chart.ChartAreas(0).CursorY.IsUserEnabled = True
        Chart.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        Chart.ChartAreas(0).AxisY.ScaleView.Zoomable = True

        Chart.ChartAreas(0).AxisX.LabelStyle.Format = "####.####"
        Chart.ChartAreas(0).AxisY.LabelStyle.Format = ".####"

        Chart.ChartAreas(0).CursorX.Interval = 0
        Chart.ChartAreas(0).CursorY.Interval = 0


    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
       
        OpenFileDialog.ShowDialog(Me)

        FileName = OpenFileDialog.FileName
        lblFileName.Text = FileName
        'Считывание заголовка и визуализация данных о файле
        Dim FI As New IO.FileInfo(FileName)
        If FI.Extension = ".bin" Then
            FileOpen(1, FileName, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGet(1, File_Head, 1)

            Select Case File_Head.TypeTest
                Case STATE_ENUM.STATE_UNKNOWN
                    lblTestType.Text = "Test type: Unknown test type"
                Case STATE_ENUM.TEST_TENSION
                    lblTestType.Text = "Test type: Uniaxial tension"
                Case STATE_ENUM.TEST_COMPRESSION
                    lblTestType.Text = "Test type: Uniaxial compression"
                Case STATE_ENUM.TEST_CONTROL
                    lblTestType.Text = "Test type: Parameter control"
                    FileGet(1, Settings_Contr, 65)
                    'гребаный VB не читает UInt придется городить побитное чтение переменной
                    Dim tmpBit() = System.BitConverter.GetBytes(Settings_Contr.TimeVal)
                    Dim tmpUInt = System.BitConverter.ToUInt32(tmpBit, 0)
                    lblTestAbout.Text = "Parameter  - " & Str(Settings_Contr.TYPE_CONTROL_ENUM) _
                        & vbNewLine & "Value  - " & Str(Settings_Contr.CtrlVal * 0.1) _
                        & vbNewLine & "Time   - " & Str(tmpUInt)

                Case STATE_ENUM.TEST_CYCLING_SINE
                    lblTestType.Text = "Test type: Harmonic (SINE)"
                    FileGet(1, Settings_Cyc, 65)
                    lblTestAbout.Text = "Parameter  - " & Str(Settings_Cyc.TYPE_CONTROL_ENUM) _
                        & vbNewLine & "Mean value   - " & Str(Settings_Cyc.MeanVal) _
                        & vbNewLine & "Alt value    - " & Str(Settings_Cyc.AltVal) _
                        & vbNewLine & "Period       - " & Str(Settings_Cyc.Period)
                Case STATE_ENUM.TEST_CYCLING_MEANDER
                    lblTestType.Text = "Test type: Harmonic (MEANDER)"
                Case STATE_ENUM.TEST_CYCLING_TRIANGLE
                    lblTestType.Text = "Test type: Harmonic (TRIANGLE)"
                Case STATE_ENUM.TEST_CYCLING_FREE_FORM
                    lblTestType.Text = "Test type: Free form"
            End Select
            FileClose()
            Dim tmpb As New BitArray(7)

            'Отмечаем данные, которые есть в файле.

            For i = 0 To 6

                ChckLstBoxEnableResults.SetItemChecked(i, fGetBit(File_Head.FormatExportPoint, i))
                tmpb(i) = fGetBit(File_Head.FormatExportPoint, i)
                Select Case i
                    Case 0
                        FORMAT_EXP_POINT_Flags.IsTimeRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 1
                        FORMAT_EXP_POINT_Flags.IsForceRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 2
                        FORMAT_EXP_POINT_Flags.IsMovingRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 3
                        FORMAT_EXP_POINT_Flags.IsDeformationRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 4
                        FORMAT_EXP_POINT_Flags.IsExtDeformationRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 5
                        FORMAT_EXP_POINT_Flags.IsVoltageRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 6
                        FORMAT_EXP_POINT_Flags.IsTemperatureRecorded = fGetBit(File_Head.FormatExportPoint, i)
                    Case 7
                        FORMAT_EXP_POINT_Flags.RESERVED = fGetBit(File_Head.FormatExportPoint, i)
                End Select

            Next
            RecordLength = 0
            For i = 0 To 6

                If tmpb(i) Then
                    RecordLength = RecordLength + 4
                End If
            Next
                'RecordLength=RecordLength+4
                lbltest.Text = RecordLength
                lblRecordsInFile.Text = "File length- " & CUInt(FI.Length / 1024) & " kB" & vbNewLine _
                    & "Points in file - " & Str((FI.Length - 1024) / RecordLength)
        End If

        ComboBoxXAxis.Items.Clear()
        If FORMAT_EXP_POINT_Flags.IsTimeRecorded Then ComboBoxXAxis.Items.Add("Time")
        If FORMAT_EXP_POINT_Flags.IsForceRecorded Then ComboBoxXAxis.Items.Add("Force")
        If FORMAT_EXP_POINT_Flags.IsMovingRecorded Then ComboBoxXAxis.Items.Add("Stoke")
        If FORMAT_EXP_POINT_Flags.IsDeformationRecorded Then ComboBoxXAxis.Items.Add("Strain")
        If FORMAT_EXP_POINT_Flags.IsExtDeformationRecorded Then ComboBoxXAxis.Items.Add("StrainExt")
        If FORMAT_EXP_POINT_Flags.IsVoltageRecorded Then ComboBoxXAxis.Items.Add("Volt")
        If FORMAT_EXP_POINT_Flags.IsTemperatureRecorded Then ComboBoxXAxis.Items.Add("Temp")
        ComboBoxYAxis.Items.Clear()
        If FORMAT_EXP_POINT_Flags.IsTimeRecorded Then ComboBoxYAxis.Items.Add("Time")
        If FORMAT_EXP_POINT_Flags.IsForceRecorded Then ComboBoxYAxis.Items.Add("Force")
        If FORMAT_EXP_POINT_Flags.IsMovingRecorded Then ComboBoxYAxis.Items.Add("Stoke")
        If FORMAT_EXP_POINT_Flags.IsDeformationRecorded Then ComboBoxYAxis.Items.Add("Strain")
        If FORMAT_EXP_POINT_Flags.IsExtDeformationRecorded Then ComboBoxYAxis.Items.Add("StrainExt")
        If FORMAT_EXP_POINT_Flags.IsVoltageRecorded Then ComboBoxYAxis.Items.Add("Volt")
        If FORMAT_EXP_POINT_Flags.IsTemperatureRecorded Then ComboBoxYAxis.Items.Add("Temp")


    End Sub

    Public Sub sRedraw(ByVal XAxis As String, ByVal Yaxis As String, ByVal FirstPoint As Integer, ByVal LastPoint As Integer)

        ReDim RecordsArray(LastPoint - FirstPoint)
        FileOpen(1, FileName, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        Dim startbit As Long = 1024 + RecordLength * (FirstPoint - 1)
        For i = 0 To (LastPoint - FirstPoint)

            FileGet(1, RecordsArray(i).Time, (startbit + i * RecordLength))
            FileGet(1, RecordsArray(i).Force, (startbit + i * RecordLength) + 4)
            FileGet(1, RecordsArray(i).Strain, (startbit + i * RecordLength) + 8)
        Next





        FileClose()
        Try
            Chart.Series.Clear()
            Chart.Series.Add(0)
            For i = 0 To (LastPoint - FirstPoint)
                Select Case ComboBoxXAxis.Text
                    Case "X axis"
                        MsgBox("You must select X-axis value")
                        Exit Sub
                    Case "Time"
                        Select Case ComboBoxYAxis.Text
                            Case "Strain"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Time, RecordsArray(i).Strain)
                            Case "Force"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Time, RecordsArray(i).Force)
                            Case "Stoke"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Time, RecordsArray(i).Stoke)
                            Case "Volt"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Time, RecordsArray(i).Voltage)
                            Case Else
                                MsgBox("Wrong Y-axis values!")
                                Exit Sub
                        End Select
                    Case "Force"
                        Select Case ComboBoxYAxis.Text
                            Case "Strain"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Force, RecordsArray(i).Strain)
                            Case "Force"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Force, RecordsArray(i).Force)
                            Case "Stoke"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Force, RecordsArray(i).Stoke)
                            Case "Volt"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Force, RecordsArray(i).Voltage)
                            Case Else
                                MsgBox("Wrong Y-axis values!")
                                Exit Sub
                        End Select
                    Case "Stoke"
                        Select Case ComboBoxYAxis.Text
                            Case "Strain"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Stoke, RecordsArray(i).Strain)
                            Case "Force"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Stoke, RecordsArray(i).Force)
                            Case "Stoke"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Stoke, RecordsArray(i).Stoke)
                            Case "Volt"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Stoke, RecordsArray(i).Voltage)
                            Case Else
                                MsgBox("Wrong Y-axis values!")
                                Exit Sub
                        End Select
                    Case "Strain"
                        Select Case ComboBoxYAxis.Text
                            Case "Strain"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Strain, RecordsArray(i).Strain)
                            Case "Force"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Strain, RecordsArray(i).Force)
                            Case "Stoke"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Strain, RecordsArray(i).Stoke)
                            Case "Volt"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Strain, RecordsArray(i).Voltage)
                            Case Else
                                MsgBox("Wrong Y-axis values!")
                                Exit Sub
                        End Select
                    Case "Volt"
                        Select Case ComboBoxYAxis.Text
                            Case "Strain"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Voltage, RecordsArray(i).Strain)
                            Case "Force"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Voltage, RecordsArray(i).Force)
                            Case "Stoke"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Voltage, RecordsArray(i).Stoke)
                            Case "Volt"
                                Chart.Series(0).Points.AddXY(RecordsArray(i).Voltage, RecordsArray(i).Voltage)
                            Case Else
                                MsgBox("Wrong Y-axis values!")
                                Exit Sub
                        End Select
                    Case Else
                End Select

            Next
            Chart.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Point
            Chart.ChartAreas(0).AxisX.Title = ComboBoxXAxis.Text
            Chart.ChartAreas(0).AxisY.Title = ComboBoxYAxis.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdRedraw_Click(sender As Object, e As EventArgs) Handles cmdRedraw.Click
        sRedraw(ComboBoxXAxis.Text, ComboBoxYAxis.Text, Val(txtFirstPoint.Text), Val(txtLastPoint.Text))
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcelToolStripMenuItem.Click
        ExportToExcel()
    End Sub
End Class
