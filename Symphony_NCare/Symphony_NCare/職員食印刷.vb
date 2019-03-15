Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 職員食印刷

    Private Sub rbnSyokuinn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnSyokuinn.CheckedChanged
        YmdBox1.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
    End Sub

    Private Sub rbnSyuukann_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnSyuukann.CheckedChanged
        YmdBox1.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
    End Sub

    Private Sub rbnSeikyuu_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnSeikyuu.CheckedChanged
        YmdBox1.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If rbnSyokuinn.Checked = True Then
            Dim objExcel As Object
            Dim objWorkBooks As Object
            Dim objWorkBook As Object
            Dim oSheets As Object
            Dim oSheet As Object
            Dim day As DateTime = DateTime.Today

            objExcel = CreateObject("Excel.Application")
            objWorkBooks = objExcel.Workbooks
            objWorkBook = objWorkBooks.Open(topform.excelFilePass)
            oSheets = objWorkBook.Worksheets
            oSheet = objWorkBook.Worksheets("職員食申込表改")

            objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
            objExcel.ScreenUpdating = False

            oSheet.Range("H2").Value = Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 5, 2)
            Dim Honjitu As Date = Util.convWarekiStrToADStr(Strings.Left(CType(Me.Owner, 職員食).lblYmd.Text, 3) & "/" & Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 5, 2) & "/" & Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 8, 2))

            Dim Youbi() As String = {"E", "H", "K", "N", "Q", "T", "W"}
            For dd As Integer = 0 To 6
                oSheet.Range(Youbi(dd) & "4").Value = Val(Strings.Mid(Honjitu.AddDays(dd), 6, 2)) & "月" & Val(Strings.Mid(Honjitu.AddDays(dd), 9, 2)) & "日"
            Next

            Dim cell(59, 22) As String

            Dim DGV1 As DataGridView = CType(Me.Owner, 職員食).DataGridView1

            For row As Integer = 0 To 59
                For col As Integer = 0 To 22
                    cell(row, col) = Util.checkDBNullValue(DGV1(col + 1, row).Value)
                Next
            Next

            oSheet.Range("C6", "Y65").Value = cell

            objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
            objExcel.ScreenUpdating = True

            '保存
            objExcel.DisplayAlerts = False

            ' エクセル表示
            objExcel.Visible = True

            '印刷
            If topform.rbnPreview.Checked = True Then
                oSheet.PrintPreview(1)
            ElseIf topform.rbnPrintout.Checked = True Then
                oSheet.Printout(1)
            End If

            ' EXCEL解放
            objExcel.Quit()
            Marshal.ReleaseComObject(oSheet)
            Marshal.ReleaseComObject(objWorkBook)
            Marshal.ReleaseComObject(objExcel)
            oSheet = Nothing
            objWorkBook = Nothing
            objExcel = Nothing



        ElseIf rbnSyuukann.Checked = True Then



            Dim objExcel As Object
            Dim objWorkBooks As Object
            Dim objWorkBook As Object
            Dim oSheets As Object
            Dim oSheet As Object
            Dim day As DateTime = DateTime.Today

            objExcel = CreateObject("Excel.Application")
            objWorkBooks = objExcel.Workbooks
            objWorkBook = objWorkBooks.Open(topform.excelFilePass)
            oSheets = objWorkBook.Worksheets
            oSheet = objWorkBook.Worksheets("職員食集計改")

            objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
            objExcel.ScreenUpdating = False

            Dim DGV1rowcount As Integer = 0
            For c As Integer = 0 To 59
                If Util.checkDBNullValue(CType(Me.Owner, 職員食).DataGridView1(2, c).Value) <> "" Then
                    DGV1rowcount = DGV1rowcount + 1
                End If
            Next

            If DGV1rowcount > 30 Then
                Dim xlPasteRange As Excel.Range = oSheet.Range("A40") 'ペースト先
                oSheet.rows("1:39").copy(xlPasteRange)
            End If

            Dim Honjitu As Date = Util.convWarekiStrToADStr(Strings.Left(CType(Me.Owner, 職員食).lblYmd.Text, 3) & "/" & Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 5, 2) & "/" & Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 8, 2))
            '1枚目
            oSheet.Range("B2").Value = Util.getKanji(CType(Me.Owner, 職員食).lblYmd.Text) & Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 2, 2) & "年" & Strings.Mid(Honjitu, 6, 2) & "月" & Strings.Mid(Honjitu, 9, 2) & "日 - " & Strings.Mid(Honjitu.AddDays(6), 6, 2) & "月" & Strings.Mid(Honjitu.AddDays(6), 9, 2) & "日"

            Dim Youbi() As String = {"E", "H", "K", "N", "Q", "T", "W"}
            For dd As Integer = 0 To 6
                oSheet.Range(Youbi(dd) & "4").Value = Val(Strings.Mid(Honjitu.AddDays(dd), 6, 2)) & "月" & Val(Strings.Mid(Honjitu.AddDays(dd), 9, 2)) & "日"
            Next

            Dim cell(29, 24) As String

            Dim DGV1 As DataGridView = CType(Me.Owner, 職員食).DataGridView1

            For row As Integer = 0 To 29
                For col As Integer = 0 To 24
                    cell(row, col) = Util.checkDBNullValue(DGV1(col, row).Value)
                Next
            Next

            oSheet.Range("B6", "Z35").Value = cell

            Dim DGV3 As DataGridView = CType(Me.Owner, 職員食).DataGridView3

            Dim DGV3cell(1, 21) As String
            For row As Integer = 0 To 1
                For col As Integer = 0 To 20
                    DGV3cell(row, col) = Util.checkDBNullValue(DGV3(col, row).Value)
                Next
            Next

            If DGV1rowcount < 31 Then
                oSheet.Range("E36", "Y37").Value = DGV3cell
                oSheet.Range("Z36").Value = DGV3(21, 1).Value
            End If

            '2枚目
            If DGV1rowcount > 30 Then
                oSheet.Range("B41").Value = Util.getKanji(CType(Me.Owner, 職員食).lblYmd.Text) & Strings.Mid(CType(Me.Owner, 職員食).lblYmd.Text, 2, 2) & "年" & Strings.Mid(Honjitu, 6, 2) & "月" & Strings.Mid(Honjitu, 9, 2) & "日 - " & Strings.Mid(Honjitu.AddDays(6), 6, 2) & "月" & Strings.Mid(Honjitu.AddDays(6), 9, 2) & "日"
                For dd As Integer = 0 To 6
                    oSheet.Range(Youbi(dd) & "43").Value = Val(Strings.Mid(Honjitu.AddDays(dd), 6, 2)) & "月" & Val(Strings.Mid(Honjitu.AddDays(dd), 9, 2)) & "日"
                Next

                For row As Integer = 0 To 29
                    For col As Integer = 0 To 24
                        cell(row, col) = ""
                    Next
                Next

                For row As Integer = 0 To 29
                    For col As Integer = 0 To 24
                        cell(row, col) = Util.checkDBNullValue(DGV1(col, row + 30).Value)
                    Next
                Next

                oSheet.Range("B45", "Z74").Value = cell

                oSheet.Range("E75", "Y76").Value = DGV3cell
                oSheet.Range("Z75").Value = DGV3(21, 1).Value
            End If



            objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
            objExcel.ScreenUpdating = True

            '保存
            objExcel.DisplayAlerts = False

            ' エクセル表示
            objExcel.Visible = True

            '印刷
            If topform.rbnPreview.Checked = True Then
                oSheet.PrintPreview(1)
            ElseIf topform.rbnPrintout.Checked = True Then
                oSheet.Printout(1)
            End If

            ' EXCEL解放
            objExcel.Quit()
            Marshal.ReleaseComObject(oSheet)
            Marshal.ReleaseComObject(objWorkBook)
            Marshal.ReleaseComObject(objExcel)
            oSheet = Nothing
            objWorkBook = Nothing
            objExcel = Nothing



        ElseIf rbnSeikyuu.Checked = True Then


            Dim Ymd As Date = YmdBox1.getADStr4Ym()
            Dim Getumatu As Integer = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr4Ym(), 4), Val(Strings.Mid(YmdBox1.getADStr4Ym(), 6, 2)))
            Dim Cn As New OleDbConnection(topform.DB_NCare)
            Dim SQLCm As OleDbCommand = Cn.CreateCommand
            Dim Adapter As New OleDbDataAdapter(SQLCm)
            Dim Table As New DataTable
            SQLCm.CommandText = "select * from Dat13 WHERE #" & Ymd & "# <= Ymd and Ymd <= #" & Strings.Left(Ymd, 8) & Getumatu & "# order by SyuN, YakN, Kana, Ymd, Gyo"
            Adapter.Fill(Table)
            DataGridView1.DataSource = Table

            Dim DGV2Table As DataTable
            DGV2Table = New DataTable()

            Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
            Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
            Dim Table5 As New DataTable
            SQLCm5.CommandText = "select * from EtcM order by SyuN, YakN, Kana"
            Adapter5.Fill(Table5)
            DataGridView5.DataSource = Table5

            'DataGridView2列作成
            For col As Integer = 0 To 7
                DGV2Table.Columns.Add("a" & col, Type.GetType("System.String"))
            Next

            'DataGridView2行作成
            For row As Integer = 1 To 60
                DGV2Table.Rows.Add(DGV2Table.NewRow())
            Next

            'DataGridView2空を表示
            DataGridView2.DataSource = DGV2Table

            Dim nam As String = "Name"
            Dim syur As String = "Syur"

            Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
            Dim personcount As Integer = 0

            For count As Integer = 0 To DGV1rowcount - 1
                If nam <> DataGridView1(1, count).Value Then
                    nam = DataGridView1(1, count).Value
                    syur = DataGridView1(4, count).FormattedValue
                    personcount = personcount + 1
                    For i As Integer = 0 To 59
                        If Util.checkDBNullValue(DataGridView2(2, i).Value) = "" Then
                            DataGridView2(1, i).Value = syur
                            DataGridView2(2, i).Value = nam
                            Exit For
                        End If
                    Next
                End If
            Next

            '貼り付ける用のデータグリッドビューを用意
            Dim f1, f2, f3 As Integer
            Dim n As Integer = 0
            For DGV2slctrow As Integer = 0 To personcount - 1
                For count As Integer = n To DGV1rowcount - 1
                    If DataGridView2(2, DGV2slctrow).Value <> DataGridView1(1, count).Value Then

                        DataGridView2(3, DGV2slctrow).Value = f1
                        DataGridView2(4, DGV2slctrow).Value = f2
                        DataGridView2(5, DGV2slctrow).Value = f3

                        f1 = 0
                        f2 = 0
                        f3 = 0

                        n = count

                        Exit For
                    ElseIf DataGridView2(2, DGV2slctrow).Value = DataGridView1(1, count).Value Then
                        If DataGridView1(7, count).Value = 1 Then
                            f1 = f1 + 1
                        End If
                        If DataGridView1(8, count).Value = 1 Then
                            f2 = f2 + 1
                        End If
                        If DataGridView1(9, count).Value = 1 Then
                            f3 = f3 + 1
                        End If

                        If count = DGV1rowcount - 1 Then
                            DataGridView2(3, DGV2slctrow).Value = f1
                            DataGridView2(4, DGV2slctrow).Value = f2
                            DataGridView2(5, DGV2slctrow).Value = f3
                        End If
                    End If
                Next
            Next

            'いる人いない人判定()
            For i As Integer = 0 To personcount - 1
                For c As Integer = 0 To DataGridView5.Rows.Count - 1
                    If Util.checkDBNullValue(DataGridView2(2, i).Value) = DataGridView5(5, c).Value Then
                        GoTo line1
                    End If
                Next
                DataGridView2.Rows.RemoveAt(i)

                personcount = 0
                For count As Integer = 0 To DataGridView2.Rows.Count - 1
                    If Util.checkDBNullValue(DataGridView2(2, count).Value) <> "" Then
                        personcount = personcount + 1
                    End If
                Next
line1:
            Next
            '再度人数確認
            personcount = 0
            Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
            For i As Integer = 0 To DGV2rowcount - 1
                If Util.checkDBNullValue(DataGridView2(2, i).Value) <> "" Then
                    personcount = personcount + 1
                    DataGridView2(0, i).Value = personcount
                End If
            Next

            For i As Integer = 0 To personcount - 1
                DataGridView2(6, i).Value = Val(DataGridView2(3, i).Value) + Val(DataGridView2(4, i).Value) + Val(DataGridView2(5, i).Value)
                DataGridView2(7, i).Value = Val(DataGridView2(3, i).Value) * Val(TextBox1.Text) + Val(DataGridView2(4, i).Value) * Val(TextBox2.Text) + Val(DataGridView2(5, i).Value) * Val(TextBox3.Text)
            Next



            'Excel起動からデータ貼り付けまで
            Dim objExcel As Object
            Dim objWorkBooks As Object
            Dim objWorkBook As Object
            Dim oSheets As Object
            Dim oSheet As Object
            Dim day As DateTime = DateTime.Today

            objExcel = CreateObject("Excel.Application")
            objWorkBooks = objExcel.Workbooks
            objWorkBook = objWorkBooks.Open(topform.excelFilePass)
            oSheets = objWorkBook.Worksheets
            oSheet = objWorkBook.Worksheets("職員食月末請求改")

            objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
            objExcel.ScreenUpdating = False

            oSheet.Range("E2").Value = Strings.Left(Util.convADStrToWarekiStr(YmdBox1.getADStr4Ym() & "/01"), 6)

            If personcount <= 45 Then
                '1枚目の貼り付けデータ
                Dim cell(44, 7) As String
                For row As Integer = 0 To 44
                    For col As Integer = 0 To 7
                        If Util.checkDBNullValue(DataGridView2(col, row).Value) <> "0" Then
                            cell(row, col) = Util.checkDBNullValue(DataGridView2(col, row).Value)
                        ElseIf Util.checkDBNullValue(DataGridView2(col, row).Value) = "0" Then
                            cell(row, col) = ""
                        End If
                    Next
                Next

                oSheet.Range("B5", "I49").Value = cell

                Dim Keicell(4) As String
                Dim kei1, kei2, kei3, kei4, kei5 As Integer
                For row As Integer = 0 To 44
                    kei1 = kei1 + Val(Util.checkDBNullValue(DataGridView2(3, row).Value))
                    kei2 = kei2 + Val(Util.checkDBNullValue(DataGridView2(4, row).Value))
                    kei3 = kei3 + Val(Util.checkDBNullValue(DataGridView2(5, row).Value))
                    kei4 = kei4 + Val(Util.checkDBNullValue(DataGridView2(6, row).Value))
                    kei5 = kei5 + Val(Util.checkDBNullValue(DataGridView2(7, row).Value))
                Next
                Keicell = {kei1, kei2, kei3, kei4, kei5}
                oSheet.Range("E50", "I50").Value = Keicell

            Else
                Dim xlPasteRange As Excel.Range = oSheet.Range("A52") 'ペースト先
                oSheet.rows("1:51").copy(xlPasteRange)

                '1枚目の貼り付けデータ
                Dim cell(44, 7) As String
                For row As Integer = 0 To 44
                    For col As Integer = 0 To 7
                        If Util.checkDBNullValue(DataGridView2(col, row).Value) <> "0" Then
                            cell(row, col) = Util.checkDBNullValue(DataGridView2(col, row).Value)
                        ElseIf Util.checkDBNullValue(DataGridView2(col, row).Value) = "0" Then
                            cell(row, col) = ""
                        End If
                    Next
                Next

                oSheet.Range("B5", "I49").Value = cell

                '2枚目の貼り付けデータ
                oSheet.Range("B53").Value = Strings.Left(Util.convADStrToWarekiStr(YmdBox1.getADStr4Ym() & "/01"), 6)

                For i As Integer = 0 To personcount - 1
                    DataGridView2(6, i).Value = Val(DataGridView2(3, i).Value) + Val(DataGridView2(4, i).Value) + Val(DataGridView2(5, i).Value)
                    DataGridView2(7, i).Value = Val(DataGridView2(3, i).Value) * Val(TextBox1.Text) + Val(DataGridView2(4, i).Value) * Val(TextBox2.Text) + Val(DataGridView2(5, i).Value) * Val(TextBox3.Text)
                Next

                Dim page2cell(14, 7) As String
                For row As Integer = 0 To 14
                    For col As Integer = 0 To 7
                        If Util.checkDBNullValue(DataGridView2(col, row + 45).Value) <> "0" Then
                            page2cell(row, col) = Util.checkDBNullValue(DataGridView2(col, row + 45).Value)
                        ElseIf Util.checkDBNullValue(DataGridView2(col, row + 45).Value) = "0" Then
                            page2cell(row, col) = ""
                        End If
                    Next
                Next

                oSheet.Range("B56", "I70").Value = page2cell

                Dim Keicell(4) As String
                Dim kei1, kei2, kei3, kei4, kei5 As Integer
                For row As Integer = 0 To 59
                    kei1 = kei1 + Val(Util.checkDBNullValue(DataGridView2(3, row).Value))
                    kei2 = kei2 + Val(Util.checkDBNullValue(DataGridView2(4, row).Value))
                    kei3 = kei3 + Val(Util.checkDBNullValue(DataGridView2(5, row).Value))
                    kei4 = kei4 + Val(Util.checkDBNullValue(DataGridView2(6, row).Value))
                    kei5 = kei5 + Val(Util.checkDBNullValue(DataGridView2(7, row).Value))
                Next
                Keicell = {kei1, kei2, kei3, kei4, kei5}
                oSheet.Range("E101", "I101").Value = Keicell
            End If


            objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
            objExcel.ScreenUpdating = True

            '保存
            objExcel.DisplayAlerts = False

            ' エクセル表示
            objExcel.Visible = True

            '印刷
            If topform.rbnPreview.Checked = True Then
                oSheet.PrintPreview(1)
            ElseIf topform.rbnPrintout.Checked = True Then
                oSheet.Printout(1)
            End If

            ' EXCEL解放
            objExcel.Quit()
            Marshal.ReleaseComObject(oSheet)
            Marshal.ReleaseComObject(objWorkBook)
            Marshal.ReleaseComObject(objExcel)
            oSheet = Nothing
            objWorkBook = Nothing
            objExcel = Nothing


        End If
    End Sub

    Private Sub btnNO_Click(sender As System.Object, e As System.EventArgs) Handles btnNO.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "SyuR" Then
            If e.RowIndex > 0 AndAlso DataGridView1(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
    End Sub

End Class