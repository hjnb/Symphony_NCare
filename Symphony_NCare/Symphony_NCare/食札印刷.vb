Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 食札印刷

    Private Sub btnJikkou_Click(sender As System.Object, e As System.EventArgs) Handles btnJikkou.Click
        If rbnKojinn.Checked = True Then
            If CType(Me.Owner, 食札).chkInsatutaisyou.Checked = False Then
                MsgBox("印刷対象者ではありません")
                Return
            End If

            Dim DGV4rowcount As Integer = CType(Me.Owner, 食札).DataGridView4.Rows.Count
            For i As Integer = 0 To DGV4rowcount - 1
                If CType(Me.Owner, 食札).DataGridView4(0, i).Value = CType(Me.Owner, 食札).YmdBoxStart.getADStr() Then
                    Dim Cn As New OleDbConnection(topform.DB_NCare)
                    Dim SQLCm As OleDbCommand = Cn.CreateCommand
                    Dim Adapter As New OleDbDataAdapter(SQLCm)
                    Dim Table As New DataTable

                    SQLCm.CommandText = "select * from Dat15 Where Nam = '" & CType(Me.Owner, 食札).lblName.Text & "' AND Ymd = '" & CType(Me.Owner, 食札).DataGridView4(0, i).Value & "' ORDER BY Gyo"
                    Adapter.Fill(Table)
                    CType(Me.Owner, 食札).DataGridView6.DataSource = Table
                    Exit For
                End If
                If i = DGV4rowcount - 1 Then
                    MsgBox("印刷対象データがありません。")
                    Return
                End If
            Next
           
            If chkHukusuu.Checked = True Then
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
                oSheet = objWorkBook.Worksheets("個人複数")

                objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
                objExcel.ScreenUpdating = False

                '左上
                oSheet.Range("B4").Interior.Color = getCellBackgroundColor(CType(Me.Owner, 食札).lblUnit.Text)
                oSheet.Range("B15").Value = CType(Me.Owner, 食札).lblUnit.Text
                oSheet.Range("E10").Value = CType(Me.Owner, 食札).DataGridView6(0, 0).Value
                Dim D5 As String = ""
                Dim D6 As String = ""
                Dim D7 As String = ""
                For i As Integer = 0 To CType(Me.Owner, 食札).DataGridView6.Rows.Count - 1
                    If i < 4 Then
                        If CType(Me.Owner, 食札).DataGridView6(4, i).Value <> "" Then
                            If D5 = "" Then
                                D5 = CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            Else
                                D5 = D5 & "/" & CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            End If
                        End If
                    ElseIf i < 8 Then
                        If CType(Me.Owner, 食札).DataGridView6(4, i).Value <> "" Then
                            If D6 = "" Then
                                D6 = CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            Else
                                D6 = D6 & "/" & CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            End If
                        End If
                    Else
                        If CType(Me.Owner, 食札).DataGridView6(4, i).Value <> "" Then
                            If D7 = "" Then
                                D7 = CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            Else
                                D7 = D7 & "/" & CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            End If
                        End If
                    End If
                Next
                oSheet.Range("D5").Value = D5
                oSheet.Range("D6").Value = D6
                oSheet.Range("D7").Value = D7
                Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                Dim asaPicture As Excel.Picture
                Dim asapath As String = ""
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "1" Then
                    asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "2" Then
                    asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "3" Then
                    asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                End If
                If System.IO.File.Exists(asapath) Then
                    asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                    asaPicture.Left = DirectCast(oSheet.Cells(10, "K"), Excel.Range).Left
                    asaPicture.Top = DirectCast(oSheet.Cells(10, "K"), Excel.Range).Top
                End If
                oSheet.Range("D15").Value = CType(Me.Owner, 食札).DataGridView6(6, 0).Value
                oSheet.Range("D14").Value = CType(Me.Owner, 食札).DataGridView6(7, 0).Value
                oSheet.Range("D13").Value = CType(Me.Owner, 食札).DataGridView6(8, 0).Value
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(9, 0).Value) = "1" Then
                    oSheet.Range("F12").Value = Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(2, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(11, 0).Value & " ～ " & Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(10, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(12, 0).Value & " まで"
                Else
                    oSheet.Range("F12").Value = Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(2, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(11, 0).Value & " より"
                End If
                Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                Dim siruPicture As Excel.Picture
                Dim sirupath As String = ""
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(14, 0).Value) = "1" Then
                    sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(14, 0).Value) = "2" Then
                    sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(14, 0).Value) = "3" Then
                    oSheet.Range("K5").Value = CType(Me.Owner, 食札).DataGridView6(16, 0).Value
                End If
                If System.IO.File.Exists(sirupath) Then
                    siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                    siruPicture.Left = DirectCast(oSheet.Cells(5, "K"), Excel.Range).Left
                    siruPicture.Top = DirectCast(oSheet.Cells(5, "K"), Excel.Range).Top
                End If
                Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                Dim tomoPicture As Excel.Picture
                Dim tomopath As String = ""
                If CType(Me.Owner, 食札).DataGridView6(18, 0).Value = "1" Then
                    tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                End If
                If System.IO.File.Exists(tomopath) Then
                    tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                    tomoPicture.Left = DirectCast(oSheet.Cells(8, "K"), Excel.Range).Left
                    tomoPicture.Top = DirectCast(oSheet.Cells(8, "K"), Excel.Range).Top
                End If
                '右上
                oSheet.Range("M4").Interior.Color = getCellBackgroundColor(CType(Me.Owner, 食札).lblUnit.Text)
                oSheet.Range("M15").Value = CType(Me.Owner, 食札).lblUnit.Text
                oSheet.Range("P10").Value = CType(Me.Owner, 食札).DataGridView6(0, 0).Value
                oSheet.Range("O5").Value = D5
                oSheet.Range("O6").Value = D6
                oSheet.Range("O7").Value = D7
                If System.IO.File.Exists(asapath) Then
                    asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                    asaPicture.Left = DirectCast(oSheet.Cells(10, "V"), Excel.Range).Left
                    asaPicture.Top = DirectCast(oSheet.Cells(10, "V"), Excel.Range).Top
                End If
                oSheet.Range("O15").Value = CType(Me.Owner, 食札).DataGridView6(6, 0).Value
                oSheet.Range("O14").Value = CType(Me.Owner, 食札).DataGridView6(7, 0).Value
                oSheet.Range("O13").Value = CType(Me.Owner, 食札).DataGridView6(8, 0).Value
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(9, 0).Value) = "1" Then
                    oSheet.Range("Q12").Value = Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(2, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(11, 0).Value & " ～ " & Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(10, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(12, 0).Value & " まで"
                Else
                    oSheet.Range("Q12").Value = Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(2, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(11, 0).Value & " より"
                End If
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "3" Then
                    oSheet.Range("V5").Value = CType(Me.Owner, 食札).DataGridView6(16, 0).Value
                End If
                If System.IO.File.Exists(sirupath) Then
                    siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                    siruPicture.Left = DirectCast(oSheet.Cells(5, "V"), Excel.Range).Left
                    siruPicture.Top = DirectCast(oSheet.Cells(5, "V"), Excel.Range).Top
                End If
                If System.IO.File.Exists(tomopath) Then
                    tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                    tomoPicture.Left = DirectCast(oSheet.Cells(8, "V"), Excel.Range).Left
                    tomoPicture.Top = DirectCast(oSheet.Cells(8, "V"), Excel.Range).Top
                End If
                'コピペ
                Dim xlRange As Excel.Range = oSheet.Cells.Range("A4:W17")
                xlRange.Copy()
                Dim xlPasteRange As Excel.Range = oSheet.Range("A18") 'ペースト先
                Dim xlPasteRange2 As Excel.Range = oSheet.Range("A32") 'ペースト先
                Dim xlPasteRange3 As Excel.Range = oSheet.Range("A46") 'ペースト先
                Dim xlPasteRange4 As Excel.Range = oSheet.Range("A60") 'ペースト先
                oSheet.rows("4:17").copy(xlPasteRange)
                oSheet.rows("4:17").copy(xlPasteRange2)
                oSheet.rows("4:17").copy(xlPasteRange3)
                oSheet.rows("4:17").copy(xlPasteRange4)

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

            Else
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
                oSheet = objWorkBook.Worksheets("個人食札")

                objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
                objExcel.ScreenUpdating = False

                oSheet.Range("B2").Interior.Color = getCellBackgroundColor(CType(Me.Owner, 食札).lblUnit.Text)
                oSheet.Range("B13").Value = CType(Me.Owner, 食札).lblUnit.Text
                oSheet.Range("E8").Value = CType(Me.Owner, 食札).DataGridView6(0, 0).Value
                Dim D3 As String = ""
                Dim D4 As String = ""
                Dim D5 As String = ""
                For i As Integer = 0 To CType(Me.Owner, 食札).DataGridView6.Rows.Count - 1
                    If i < 4 Then
                        If CType(Me.Owner, 食札).DataGridView6(4, i).Value <> "" Then
                            If D3 = "" Then
                                D3 = CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            Else
                                D3 = D3 & "/" & CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            End If
                        End If
                    ElseIf i < 8 Then
                        If CType(Me.Owner, 食札).DataGridView6(4, i).Value <> "" Then
                            If D4 = "" Then
                                D4 = CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            Else
                                D4 = D4 & "/" & CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            End If
                        End If
                    Else
                        If CType(Me.Owner, 食札).DataGridView6(4, i).Value <> "" Then
                            If D5 = "" Then
                                D5 = CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            Else
                                D5 = D5 & "/" & CType(Me.Owner, 食札).DataGridView6(4, i).Value
                            End If
                        End If
                    End If
                Next
                oSheet.Range("D3").Value = D3
                oSheet.Range("D4").Value = D4
                oSheet.Range("D5").Value = D5
                Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                Dim asaPicture As Excel.Picture
                Dim asapath As String = ""
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "1" Then
                    asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "2" Then
                    asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "3" Then
                    asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                End If
                If System.IO.File.Exists(asapath) Then
                    asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                    asaPicture.Left = DirectCast(oSheet.Cells(8, "K"), Excel.Range).Left
                    asaPicture.Top = DirectCast(oSheet.Cells(8, "K"), Excel.Range).Top
                End If
                oSheet.Range("D13").Value = CType(Me.Owner, 食札).DataGridView6(6, 0).Value
                oSheet.Range("D12").Value = CType(Me.Owner, 食札).DataGridView6(7, 0).Value
                oSheet.Range("D11").Value = CType(Me.Owner, 食札).DataGridView6(8, 0).Value
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(9, 0).Value) = "1" Then
                    oSheet.Range("F10").Value = Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(2, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(11, 0).Value & " ～ " & Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(10, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(12, 0).Value & " まで"
                Else
                    oSheet.Range("F10").Value = Util.convADStrToWarekiStr(CType(Me.Owner, 食札).DataGridView6(2, 0).Value) & " " & CType(Me.Owner, 食札).DataGridView6(11, 0).Value & " より"
                End If
                Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                Dim siruPicture As Excel.Picture
                Dim sirupath As String = ""
                If Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(14, 0).Value) = "1" Then
                    sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(14, 0).Value) = "2" Then
                    sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(14, 0).Value) = "3" Then
                    oSheet.Range("K3").Value = CType(Me.Owner, 食札).DataGridView6(16, 0).Value
                End If
                If System.IO.File.Exists(sirupath) Then
                    siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                    siruPicture.Left = DirectCast(oSheet.Cells(3, "K"), Excel.Range).Left
                    siruPicture.Top = DirectCast(oSheet.Cells(3, "K"), Excel.Range).Top
                End If

                Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                Dim tomoPicture As Excel.Picture
                Dim tomopath As String = ""
                If CType(Me.Owner, 食札).DataGridView6(18, 0).Value = "1" Then
                    tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                End If
                If System.IO.File.Exists(tomopath) Then
                    tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                    tomoPicture.Left = DirectCast(oSheet.Cells(6, "K"), Excel.Range).Left
                    tomoPicture.Top = DirectCast(oSheet.Cells(6, "K"), Excel.Range).Top
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

        ElseIf rbnAll.Checked = True Then
            Dim Cn As New OleDbConnection(topform.DB_NCare)
            Dim SQLCm As OleDbCommand = Cn.CreateCommand
            Dim Adapter As New OleDbDataAdapter(SQLCm)
            Dim Table As New DataTable
            SQLCm.CommandText = "select * from (Dat15 inner join (select Nam from Dat15Prnt where Prnt=1) as b on Dat15.Nam = b.Nam) inner join (select Nam, max(Ymd) as A from Dat15 group by Nam) as [max] on Dat15.Nam = [max].Nam and Dat15.Ymd = [max].A order by Kana, Gyo"
            Adapter.Fill(Table)
            DataGridView1.DataSource = Table

            Dim objExcel As Object
            Dim objWorkBooks As Object
            Dim objWorkBook As Object
            Dim oSheet As Object
            Dim day As DateTime = DateTime.Today

            objExcel = CreateObject("Excel.Application")
            objWorkBooks = objExcel.Workbooks
            objWorkBook = objWorkBooks.Open(topform.excelFilePass)
            oSheet = objWorkBook.Worksheets("食札")

            objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
            objExcel.ScreenUpdating = False

            Dim DGV1rowscount As Integer = DataGridView1.Rows.Count
            Dim Personcount As Integer = DGV1rowscount \ 12

            For i As Integer = 0 To Personcount \ 10
                If i <> 0 Then
                    Dim xlPasteRange As Excel.Range = oSheet.Range("A" & i * 73 + 1) 'ペースト先
                    oSheet.rows("1:73").copy(xlPasteRange)
                End If
            Next

            Dim cell(10, 2) As String   '貼り付け用配列

            Dim D5 As String
            Dim D6 As String
            Dim D7 As String

            Dim DGVfindname As DataGridView = CType(Me.Owner, 食札).DataGridView1
            Dim DGVfindnamerowcount As Integer = DGVfindname.Rows.Count
            Dim DGVfindname2 As DataGridView = CType(Me.Owner, 食札).DataGridView2
            Dim DGVfindnamerowcount2 As Integer = DGVfindname2.Rows.Count
            '左列
            
            For c As Integer = 0 To DGV1rowscount - 1

                If (c \ 60) Mod 2 = 0 Then  '左列

                    Dim a As Integer = c \ 12   '何番目の人のデータか
                    Dim b As Integer = c Mod 12
                    If b = 0 Then
                        D5 = ""
                        D6 = ""
                        D7 = ""
                        If a < 10 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 + 15).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 + 4).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line1
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 + 15).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 + 4).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line1:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(Util.checkDBNullValue(DataGridView1(8, c).Value))  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 + 10, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 + 10, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 + 5).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 + 5, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 + 5, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 + 8, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 + 8, "K"), Excel.Range).Top
                            End If

                            oSheet.Range("D" & a * 14 + 5, "F" & a * 14 + 15).Value = cell

                        ElseIf a < 20 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 52).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 63).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line2
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 52).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 63).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line2:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 57, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 57, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 62).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 62, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 62, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 59, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 59, "K"), Excel.Range).Top
                            End If

                            oSheet.Range("D" & a * 14 - 62, "F" & a * 14 - 52).Value = cell

                        ElseIf a < 30 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 119).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 130).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line3
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 119).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 130).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line3:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12

                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(11, c).Value)) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(12, c).Value)) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(11, c).Value)) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 124, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 124, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 129).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 129, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 129, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 126, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 126, "K"), Excel.Range).Top
                            End If

                            oSheet.Range("D" & a * 14 - 129, "F" & a * 14 - 119).Value = cell
                        ElseIf a < 40 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 186).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 197).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line4
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 186).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 197).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line4:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 191, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 191, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 196).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 196, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 196, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 193, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 193, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 196, "F" & a * 14 - 186).Value = cell

                        ElseIf a < 50 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 253).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 264).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line5
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 253).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 264).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line5:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 258, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 258, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 263).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 263, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 263, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 260, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 260, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 263, "F" & a * 14 - 253).Value = cell

                        ElseIf a < 60 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 320).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 331).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line6
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 320).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 331).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line6:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 325, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 325, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 330).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 330, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 330, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 327, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 327, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 330, "F" & a * 14 - 320).Value = cell

                        ElseIf a < 70 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 387).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 398).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line7
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 387).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 398).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line7:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 392, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 392, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 397).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 397, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 397, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 394, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 394, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 397, "F" & a * 14 - 387).Value = cell

                        ElseIf a < 80 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 454).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 465).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line8
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 454).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 465).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line8:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 459, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 459, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 464).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 464, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 464, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 461, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 461, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 464, "F" & a * 14 - 454).Value = cell

                        ElseIf a < 90 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 521).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 532).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line9
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 521).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 532).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line9:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 526, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 526, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 531).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 531, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 531, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 528, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 528, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 531, "F" & a * 14 - 521).Value = cell

                        ElseIf a < 100 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 588).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 599).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line10
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 588).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 599).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line10:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 593, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 593, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 598).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 598, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 598, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 595, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 595, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 598, "F" & a * 14 - 588).Value = cell

                        ElseIf a < 110 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 655).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 666).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line11
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("B" & a * 14 - 655).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("B" & a * 14 - 666).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line11:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 660, "K"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 660, "K"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 665).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 665, "K"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 665, "K"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 662, "K"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 662, "K"), Excel.Range).Top
                            End If
                            oSheet.Range("D" & a * 14 - 665, "F" & a * 14 - 655).Value = cell

                        End If

                    End If



                ElseIf (c \ 60) Mod 2 = 1 Then  '右列
                    Dim a As Integer = (c - 60) \ 12
                    Dim b As Integer = c Mod 12
                    If b = 0 Then
                        D5 = ""
                        D6 = ""
                        D7 = ""
                        If a < 10 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 + 15).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 + 4).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line12
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 + 15).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 + 4).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line12:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 + 10, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 + 10, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 + 5).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 + 5, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 + 5, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 + 8, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 + 8, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 + 5, "Q" & a * 14 + 15).Value = cell

                        ElseIf a < 20 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 52).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 63).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line13
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 52).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 63).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line13:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 57, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 57, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 62).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 62, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 62, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 59, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 59, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 62, "Q" & a * 14 - 52).Value = cell

                        ElseIf a < 30 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 119).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 130).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line14
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 119).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 130).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line14:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 124, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 124, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 129).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 129, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 129, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 126, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 126, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 129, "Q" & a * 14 - 119).Value = cell

                        ElseIf a < 40 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 186).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 197).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line15
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 186).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 197).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line15:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 191, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 191, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 196).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 196, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 196, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 193, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 193, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 196, "Q" & a * 14 - 186).Value = cell

                        ElseIf a < 50 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 253).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 264).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line16
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 253).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 264).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line16:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 258, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 258, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 263).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 263, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 263, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 260, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 260, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 263, "Q" & a * 14 - 253).Value = cell

                        ElseIf a < 60 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 320).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 331).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line17
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 320).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 331).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line17:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 325, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 325, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 330).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 330, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 330, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 327, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 327, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 330, "Q" & a * 14 - 320).Value = cell

                        ElseIf a < 70 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 387).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 398).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line18
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 387).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 398).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line18:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 392, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 392, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 397).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 397, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 397, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 394, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 394, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 397, "Q" & a * 14 - 387).Value = cell

                        ElseIf a < 80 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 454).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 465).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line19
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 454).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 465).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line19:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 459, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 459, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 464).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 464, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 464, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 461, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 461, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 464, "Q" & a * 14 - 454).Value = cell

                        ElseIf a < 90 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 521).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 532).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line20
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 521).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 532).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line20:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 526, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 526, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 531).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 531, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 531, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 528, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 528, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 531, "Q" & a * 14 - 521).Value = cell

                        ElseIf a < 100 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 588).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 599).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line21
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 588).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 599).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line21:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 593, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 593, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 598).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 598, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 598, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 595, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 595, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 598, "Q" & a * 14 - 593).Value = cell

                        ElseIf a < 110 Then
                            For i As Integer = 0 To 11
                                If i < 4 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D5 = "" Then
                                            D5 = DataGridView1(4, c + i).Value
                                        Else
                                            D5 = D5 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 8 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                ElseIf i < 12 Then
                                    If DataGridView1(4, c + i).Value <> "" Then
                                        If D6 = "" Then
                                            D6 = DataGridView1(4, c + i).Value
                                        Else
                                            D6 = D6 & "/" & DataGridView1(4, c + i).Value
                                        End If
                                    End If
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount - 1
                                If DataGridView1(0, c).Value = DGVfindname(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 655).Value = DGVfindname(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 666).Interior.Color = getCellBackgroundColor(DGVfindname(0, unit).Value)
                                    GoTo line22
                                End If
                            Next
                            For unit As Integer = 0 To DGVfindnamerowcount2 - 1
                                If DataGridView1(0, c).Value = DGVfindname2(2, unit).Value Then
                                    oSheet.Range("M" & a * 14 - 655).Value = DGVfindname2(0, unit).Value
                                    oSheet.Range("M" & a * 14 - 666).Interior.Color = getCellBackgroundColor(DGVfindname2(0, unit).Value)
                                    Exit For
                                End If
                            Next
line22:
                            cell(0, 0) = D5  '禁1～4
                            cell(1, 0) = D6  '禁5～8
                            cell(2, 0) = D7  '禁9～12
                            cell(5, 1) = DataGridView1(0, c).Value  '名前
                            If Util.checkDBNullValue(DataGridView1(9, c).Value) = "1" Then
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, c).Value) & " " & Util.checkDBNullValue(DataGridView1(12, c).Value) & " まで"
                            Else
                                cell(7, 2) = Util.convADStrToWarekiStr(DataGridView1(2, c).Value) & " " & Util.checkDBNullValue(DataGridView1(11, c).Value) & " より"
                            End If
                            cell(8, 0) = Util.checkDBNullValue(DataGridView1(8, c).Value)  '形態3
                            cell(9, 0) = Util.checkDBNullValue(DataGridView1(7, c).Value)  '形態2
                            cell(10, 0) = Util.checkDBNullValue(DataGridView1(6, c).Value)  '形態1
                            Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim asaPicture As Excel.Picture
                            Dim asapath As String = ""
                            If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                                asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                            End If
                            If System.IO.File.Exists(asapath) Then
                                asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                                asaPicture.Left = DirectCast(oSheet.Cells(a * 14 - 660, "V"), Excel.Range).Left
                                asaPicture.Top = DirectCast(oSheet.Cells(a * 14 - 660, "V"), Excel.Range).Top
                            End If
                            Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim siruPicture As Excel.Picture
                            Dim sirupath As String = ""
                            If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                                sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                            ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                                oSheet.Range("K" & a * 14 - 665).Value = DataGridView1(16, c).Value
                            End If
                            If System.IO.File.Exists(sirupath) Then
                                siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                                siruPicture.Left = DirectCast(oSheet.Cells(a * 14 - 665, "V"), Excel.Range).Left
                                siruPicture.Top = DirectCast(oSheet.Cells(a * 14 - 665, "V"), Excel.Range).Top
                            End If
                            Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                            Dim tomoPicture As Excel.Picture
                            Dim tomopath As String = ""
                            If Util.checkDBNullValue(DataGridView1(18, c).Value) = "1" Then
                                tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                            End If
                            If System.IO.File.Exists(tomopath) Then
                                tomoPicture = DirectCast(tomoPictures.Insert(tomopath), Excel.Picture)
                                tomoPicture.Left = DirectCast(oSheet.Cells(a * 14 - 662, "V"), Excel.Range).Left
                                tomoPicture.Top = DirectCast(oSheet.Cells(a * 14 - 662, "V"), Excel.Range).Top
                            End If
                            oSheet.Range("O" & a * 14 - 665, "Q" & a * 14 - 655).Value = cell
                        End If
                    End If
                End If
            Next

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


        ElseIf rbnItirann.Checked = True Then
            Dim Cn As New OleDbConnection(topform.DB_NCare)
            Dim SQLCm As OleDbCommand = Cn.CreateCommand
            Dim Adapter As New OleDbDataAdapter(SQLCm)
            Dim Table As New DataTable
            SQLCm.CommandText = "select * from ((Dat15 inner join (select Nam from Dat15Prnt where Prnt=1) as b on Dat15.Nam = b.Nam) inner join (select Nam, max(Ymd) as A from Dat15 group by Nam) as [max] on Dat15.Nam = [max].Nam and Dat15.Ymd = [max].A) inner join Dat15Unt on Dat15.Nam=Dat15Unt.Nam order by Dat15Unt.Syu, Dat15.Kana, Gyo"
            Adapter.Fill(Table)
            DataGridView1.DataSource = Table

            Dim objExcel As Object
            Dim objWorkBooks As Object
            Dim objWorkBook As Object
            Dim oSheet As Object
            Dim day As DateTime = DateTime.Today

            objExcel = CreateObject("Excel.Application")
            objWorkBooks = objExcel.Workbooks
            objWorkBook = objWorkBooks.Open(topform.excelFilePass)
            oSheet = objWorkBook.Worksheets("食札一覧")

            objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
            objExcel.ScreenUpdating = False

            Dim DGV1rowscount As Integer = DataGridView1.Rows.Count
            Dim Personcount As Integer = DGV1rowscount \ 12

            For i As Integer = 0 To Personcount \ 25
                If i <> 0 Then
                    Dim xlPasteRange As Excel.Range = oSheet.Range("A" & i * 31 + 1) 'ペースト先
                    oSheet.rows("1:31").copy(xlPasteRange)
                End If
            Next

            Dim cell(24, 9) As String   '貼り付け用配列

            Dim K5 As String
            Dim floor As String = ""
            Dim nowfloor As String = ""
            For c As Integer = 0 To DGV1rowscount - 1
                Dim a As Integer = c \ 12   '何番目の人のデータか
                Dim b As Integer = c Mod 12
                If b = 0 Then
                    K5 = ""
                    If a < 25 Then
                        For i As Integer = 0 To 11
                            If Util.checkDBNullValue(DataGridView1(4, c + i).Value) <> "" Then
                                If K5 = "" Then
                                    K5 = Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                Else
                                    K5 = K5 & "/" & Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                End If
                            End If
                        Next

                        If DataGridView1(25, c).Value = "1" OrElse DataGridView1(25, c).Value = "2" OrElse DataGridView1(25, c).Value = "3" OrElse DataGridView1(25, c).Value = "7" OrElse DataGridView1(25, c).Value = "8" OrElse DataGridView1(25, c).Value = "9" OrElse DataGridView1(25, c).Value = "10" Then
                            nowfloor = "2階"
                            If floor = nowfloor Then
                                cell(a, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a, 0) = nowfloor
                                floor = nowfloor
                            End If
                        ElseIf DataGridView1(25, c).Value = "4" OrElse DataGridView1(25, c).Value = "5" OrElse DataGridView1(25, c).Value = "6" OrElse DataGridView1(25, c).Value = "A" OrElse DataGridView1(25, c).Value = "B" Then
                            nowfloor = "3階"
                            If floor = nowfloor Then
                                cell(a, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a, 0) = nowfloor
                                floor = nowfloor
                            End If
                        End If
                        cell(a, 1) = Util.checkDBNullValue(DataGridView1(24, c).Value)
                        cell(a, 2) = Util.checkDBNullValue(DataGridView1(0, c).Value)
                        cell(a, 3) = Util.checkDBNullValue(DataGridView1(15, c).Value)
                        cell(a, 4) = Util.checkDBNullValue(DataGridView1(6, c).Value)
                        cell(a, 5) = Util.checkDBNullValue(DataGridView1(7, c).Value)
                        cell(a, 6) = Util.checkDBNullValue(DataGridView1(8, c).Value)
                        If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                            cell(a, 7) = "１/２"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                            cell(a, 7) = "なし"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                            cell(a, 7) = DataGridView1(16, c).Value
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "0" Then
                            cell(a, 7) = ""
                        End If
                        If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                            cell(a, 8) = "牛乳"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                            cell(a, 8) = "ヨーグルト"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                            cell(a, 8) = "エリー"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "0" Then
                            cell(a, 8) = ""
                        End If
                        cell(a, 9) = K5

                        If a = Personcount - 1 OrElse a = 24 Then
                            oSheet.Range("B5", "K29").Value = cell
                            For row As Integer = 0 To 24
                                For col As Integer = 0 To 9
                                    cell(row, col) = ""
                                Next
                            Next
                        End If
                        oSheet.Range("K30").Value = "1"
                    ElseIf a < 50 Then
                        For i As Integer = 0 To 11
                            If Util.checkDBNullValue(DataGridView1(4, c + i).Value) <> "" Then
                                If K5 = "" Then
                                    K5 = Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                Else
                                    K5 = K5 & "/" & Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                End If
                            End If
                        Next

                        If DataGridView1(25, c).Value = "1" OrElse DataGridView1(25, c).Value = "2" OrElse DataGridView1(25, c).Value = "3" OrElse DataGridView1(25, c).Value = "7" OrElse DataGridView1(25, c).Value = "8" OrElse DataGridView1(25, c).Value = "9" OrElse DataGridView1(25, c).Value = "10" Then
                            nowfloor = "2階"
                            If floor = nowfloor Then
                                cell(a - 25, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 25, 0) = nowfloor
                                floor = nowfloor
                            End If
                        ElseIf DataGridView1(25, c).Value = "4" OrElse DataGridView1(25, c).Value = "5" OrElse DataGridView1(25, c).Value = "6" OrElse DataGridView1(25, c).Value = "A" OrElse DataGridView1(25, c).Value = "B" Then
                            nowfloor = "3階"
                            If floor = nowfloor Then
                                cell(a - 25, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 25, 0) = nowfloor
                                floor = nowfloor
                            End If
                        End If
                        cell(a - 25, 1) = Util.checkDBNullValue(DataGridView1(24, c).Value)
                        cell(a - 25, 2) = Util.checkDBNullValue(DataGridView1(0, c).Value)
                        cell(a - 25, 3) = Util.checkDBNullValue(DataGridView1(15, c).Value)
                        cell(a - 25, 4) = Util.checkDBNullValue(DataGridView1(6, c).Value)
                        cell(a - 25, 5) = Util.checkDBNullValue(DataGridView1(7, c).Value)
                        cell(a - 25, 6) = Util.checkDBNullValue(DataGridView1(8, c).Value)
                        If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                            cell(a - 25, 7) = "１/２"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                            cell(a - 25, 7) = "なし"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                            cell(a - 25, 7) = DataGridView1(16, c).Value
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "0" Then
                            cell(a - 25, 7) = ""
                        End If
                        If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                            cell(a - 25, 8) = "牛乳"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                            cell(a - 25, 8) = "ヨーグルト"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                            cell(a - 25, 8) = "エリー"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "0" Then
                            cell(a - 25, 8) = ""
                        End If
                        cell(a - 25, 9) = K5

                        If a = Personcount - 1 OrElse a = 49 Then
                            oSheet.Range("B36", "K60").Value = cell
                            For row As Integer = 0 To 24
                                For col As Integer = 0 To 9
                                    cell(row, col) = ""
                                Next
                            Next
                        End If
                        oSheet.Range("K61").Value = "2"
                    ElseIf a < 75 Then
                       For i As Integer = 0 To 11
                            If Util.checkDBNullValue(DataGridView1(4, c + i).Value) <> "" Then
                                If K5 = "" Then
                                    K5 = Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                Else
                                    K5 = K5 & "/" & Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                End If
                            End If
                        Next

                        If DataGridView1(25, c).Value = "1" OrElse DataGridView1(25, c).Value = "2" OrElse DataGridView1(25, c).Value = "3" OrElse DataGridView1(25, c).Value = "7" OrElse DataGridView1(25, c).Value = "8" OrElse DataGridView1(25, c).Value = "9" OrElse DataGridView1(25, c).Value = "10" Then
                            nowfloor = "2階"
                            If floor = nowfloor Then
                                cell(a - 50, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 50, 0) = nowfloor
                                floor = nowfloor
                            End If
                        ElseIf DataGridView1(25, c).Value = "4" OrElse DataGridView1(25, c).Value = "5" OrElse DataGridView1(25, c).Value = "6" OrElse DataGridView1(25, c).Value = "A" OrElse DataGridView1(25, c).Value = "B" Then
                            nowfloor = "3階"
                            If floor = nowfloor Then
                                cell(a - 50, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 50, 0) = nowfloor
                                floor = nowfloor
                            End If
                        End If
                        cell(a - 50, 1) = Util.checkDBNullValue(DataGridView1(24, c).Value)
                        cell(a - 50, 2) = Util.checkDBNullValue(DataGridView1(0, c).Value)
                        cell(a - 50, 3) = Util.checkDBNullValue(DataGridView1(15, c).Value)
                        cell(a - 50, 4) = Util.checkDBNullValue(DataGridView1(6, c).Value)
                        cell(a - 50, 5) = Util.checkDBNullValue(DataGridView1(7, c).Value)
                        cell(a - 50, 6) = Util.checkDBNullValue(DataGridView1(8, c).Value)
                        If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                            cell(a - 50, 7) = "１/２"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                            cell(a - 50, 7) = "なし"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                            cell(a - 50, 7) = DataGridView1(16, c).Value
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "0" Then
                            cell(a - 50, 7) = ""
                        End If
                        If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                            cell(a - 50, 8) = "牛乳"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                            cell(a - 50, 8) = "ヨーグルト"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                            cell(a - 50, 8) = "エリー"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "0" Then
                            cell(a - 50, 8) = ""
                        End If
                        cell(a - 50, 9) = K5

                        If a = Personcount - 1 OrElse a = 74 Then
                            oSheet.Range("B67", "K91").Value = cell
                            For row As Integer = 0 To 24
                                For col As Integer = 0 To 9
                                    cell(row, col) = ""
                                Next
                            Next
                        End If
                        oSheet.Range("K92").Value = "3"
                    ElseIf a < 100 Then
                       For i As Integer = 0 To 11
                            If Util.checkDBNullValue(DataGridView1(4, c + i).Value) <> "" Then
                                If K5 = "" Then
                                    K5 = Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                Else
                                    K5 = K5 & "/" & Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                End If
                            End If
                        Next

                        If DataGridView1(25, c).Value = "1" OrElse DataGridView1(25, c).Value = "2" OrElse DataGridView1(25, c).Value = "3" OrElse DataGridView1(25, c).Value = "7" OrElse DataGridView1(25, c).Value = "8" OrElse DataGridView1(25, c).Value = "9" OrElse DataGridView1(25, c).Value = "10" Then
                            nowfloor = "2階"
                            If floor = nowfloor Then
                                cell(a - 75, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 75, 0) = nowfloor
                                floor = nowfloor
                            End If
                        ElseIf DataGridView1(25, c).Value = "4" OrElse DataGridView1(25, c).Value = "5" OrElse DataGridView1(25, c).Value = "6" OrElse DataGridView1(25, c).Value = "A" OrElse DataGridView1(25, c).Value = "B" Then
                            nowfloor = "3階"
                            If floor = nowfloor Then
                                cell(a - 75, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 75, 0) = nowfloor
                                floor = nowfloor
                            End If
                        End If
                        cell(a - 75, 1) = Util.checkDBNullValue(DataGridView1(24, c).Value)
                        cell(a - 75, 2) = Util.checkDBNullValue(DataGridView1(0, c).Value)
                        cell(a - 75, 3) = Util.checkDBNullValue(DataGridView1(15, c).Value)
                        cell(a - 75, 4) = Util.checkDBNullValue(DataGridView1(6, c).Value)
                        cell(a - 75, 5) = Util.checkDBNullValue(DataGridView1(7, c).Value)
                        cell(a - 75, 6) = Util.checkDBNullValue(DataGridView1(8, c).Value)
                        If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                            cell(a - 75, 7) = "１/２"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                            cell(a - 75, 7) = "なし"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                            cell(a - 75, 7) = DataGridView1(16, c).Value
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "0" Then
                            cell(a - 75, 7) = ""
                        End If
                        If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                            cell(a - 75, 8) = "牛乳"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                            cell(a - 75, 8) = "ヨーグルト"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                            cell(a - 75, 8) = "エリー"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "0" Then
                            cell(a - 75, 8) = ""
                        End If
                        cell(a - 75, 9) = K5

                        If a = Personcount - 1 OrElse a = 99 Then
                            oSheet.Range("B98", "K122").Value = cell
                            For row As Integer = 0 To 24
                                For col As Integer = 0 To 9
                                    cell(row, col) = ""
                                Next
                            Next
                        End If
                        oSheet.Range("K123").Value = "4"
                    ElseIf a < 125 Then
                        For i As Integer = 0 To 11
                            If Util.checkDBNullValue(DataGridView1(4, c + i).Value) <> "" Then
                                If K5 = "" Then
                                    K5 = Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                Else
                                    K5 = K5 & "/" & Util.checkDBNullValue(DataGridView1(4, c + i).Value)
                                End If
                            End If
                        Next

                        If DataGridView1(25, c).Value = "1" OrElse DataGridView1(25, c).Value = "2" OrElse DataGridView1(25, c).Value = "3" OrElse DataGridView1(25, c).Value = "7" OrElse DataGridView1(25, c).Value = "8" OrElse DataGridView1(25, c).Value = "9" OrElse DataGridView1(25, c).Value = "10" Then
                            nowfloor = "2階"
                            If floor = nowfloor Then
                                cell(a - 100, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 100, 0) = nowfloor
                                floor = nowfloor
                            End If
                        ElseIf DataGridView1(25, c).Value = "4" OrElse DataGridView1(25, c).Value = "5" OrElse DataGridView1(25, c).Value = "6" OrElse DataGridView1(25, c).Value = "A" OrElse DataGridView1(25, c).Value = "B" Then
                            nowfloor = "3階"
                            If floor = nowfloor Then
                                cell(a - 100, 0) = ""
                            ElseIf floor <> nowfloor Then
                                cell(a - 100, 0) = nowfloor
                                floor = nowfloor
                            End If
                        End If
                        cell(a - 100, 1) = Util.checkDBNullValue(DataGridView1(24, c).Value)
                        cell(a - 100, 2) = Util.checkDBNullValue(DataGridView1(0, c).Value)
                        cell(a - 100, 3) = Util.checkDBNullValue(DataGridView1(15, c).Value)
                        cell(a - 100, 4) = Util.checkDBNullValue(DataGridView1(6, c).Value)
                        cell(a - 100, 5) = Util.checkDBNullValue(DataGridView1(7, c).Value)
                        cell(a - 100, 6) = Util.checkDBNullValue(DataGridView1(8, c).Value)
                        If Util.checkDBNullValue(DataGridView1(14, c).Value) = "1" Then
                            cell(a - 100, 7) = "１/２"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "2" Then
                            cell(a - 100, 7) = "なし"
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "3" Then
                            cell(a - 100, 7) = DataGridView1(16, c).Value
                        ElseIf Util.checkDBNullValue(DataGridView1(14, c).Value) = "0" Then
                            cell(a - 100, 7) = ""
                        End If
                        If Util.checkDBNullValue(DataGridView1(5, c).Value) = "1" Then
                            cell(a - 100, 8) = "牛乳"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "2" Then
                            cell(a - 100, 8) = "ヨーグルト"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "3" Then
                            cell(a - 100, 8) = "エリー"
                        ElseIf Util.checkDBNullValue(DataGridView1(5, c).Value) = "0" Then
                            cell(a - 100, 8) = ""
                        End If
                        cell(a - 100, 9) = K5

                        If a = Personcount - 1 OrElse a = 124 Then
                            oSheet.Range("B129", "K153").Value = cell
                            For row As Integer = 0 To 24
                                For col As Integer = 0 To 9
                                    cell(row, col) = ""
                                Next
                            Next
                        End If
                        oSheet.Range("K154").Value = "5"
                    End If
                End If

            Next




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

        ElseIf rbnTokki.Checked = True Then
            If CType(Me.Owner, 食札).lblName.Text = "" Then
                MsgBox("印刷対象者を選択してください。")
                Return
            End If

            Dim Cn As New OleDbConnection(topform.DB_NCare)
            Dim SQLCm As OleDbCommand = Cn.CreateCommand
            Dim Adapter As New OleDbDataAdapter(SQLCm)
            Dim Table As New DataTable

            SQLCm.CommandText = "select * from Dat15 WHERE Nam = '" & CType(Me.Owner, 食札).lblName.Text & "' AND Gyo < 11 ORDER BY Ymd, Gyo"

            Adapter.Fill(Table)
            DataGridView2.DataSource = Table
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
            oSheet = objWorkBook.Worksheets("特記事項")

            objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
            objExcel.ScreenUpdating = False

            If DataGridView2.Rows.Count = 0 Then
                MsgBox("印刷対象データがありません")
                Return
            End If
            '必要データのみ残す
            For i As Integer = 0 To DataGridView2.Rows.Count - 1
                If i = DataGridView2.Rows.Count Then
                    Exit For
                End If
                If DataGridView2(13, i).Value = "" OrElse DataGridView2(13, i).Value = " " OrElse DataGridView2(13, i).Value = "　" Then
                    DataGridView2.Rows.RemoveAt(i)
                    i = 0
                End If
            Next

            If DataGridView2(3, 0).Value = 2 Then
                DataGridView2.Rows.RemoveAt(0)
            End If

            oSheet.Range("F2").Value = DataGridView2(0, 0).Value

            Dim DGV2rowcount As Integer = DataGridView2.Rows.Count

            Dim cellleft(57, 2) As String
            Dim cellright(57, 2) As String
            If DGV2rowcount \ 58 = 0 Then
                For row As Integer = 0 To DGV2rowcount - 1
                    For col As Integer = 0 To 2
                        If col = 0 Then
                            cellleft(row, col) = DataGridView2(2, row).FormattedValue
                        ElseIf col = 2 Then
                            cellleft(row, col) = DataGridView2(13, row).Value
                        End If
                    Next
                Next

                oSheet.Range("C5", "E62").Value = cellleft

            ElseIf DGV2rowcount \ 58 = 1 Then
                For row As Integer = 0 To 57
                    For col As Integer = 0 To 2
                        If col = 0 Then
                            cellleft(row, col) = DataGridView2(2, row).FormattedValue
                        ElseIf col = 2 Then
                            cellleft(row, col) = DataGridView2(13, row).Value
                        End If

                    Next
                Next
                oSheet.Range("C5", "E62").Value = cellleft
                For row As Integer = 58 To DGV2rowcount - 1
                    For col As Integer = 0 To 2
                        If col = 0 Then
                            cellright(row - 58, col) = DataGridView2(2, row).FormattedValue
                        ElseIf col = 2 Then
                            cellright(row - 58, col) = DataGridView2(13, row).Value
                        End If
                    Next
                Next
                oSheet.Range("H5", "J62").Value = cellright
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

    Private Sub btnKyannseru_Click(sender As System.Object, e As System.EventArgs) Handles btnKyannseru.Click
        Me.Close()
    End Sub

    Private Function getCellBackgroundColor(cellText As String) As Color
        If cellText = "光" Then
            Return Color.FromArgb(240, 210, 150)
        ElseIf cellText = "空" Then
            Return Color.FromArgb(255, 153, 0)
        ElseIf cellText = "丘" Then
            Return Color.FromArgb(160, 200, 100)
        ElseIf cellText = "森" Then
            Return Color.FromArgb(102, 255, 0)
        ElseIf cellText = "雪" Then
            Return Color.FromArgb(255, 255, 255)
        ElseIf cellText = "風" Then
            Return Color.FromArgb(180, 150, 200)
        ElseIf cellText = "月" Then
            Return Color.FromArgb(255, 255, 0)
        ElseIf cellText = "花" Then
            Return Color.FromArgb(255, 153, 153)
        ElseIf cellText = "星" Then
            Return Color.FromArgb(0, 153, 255)
        ElseIf cellText = "虹" Then
            Return Color.FromArgb(250, 70, 70)
        ElseIf cellText = "海" Then
            Return Color.FromArgb(153, 204, 255)
        Else
            Return Color.FromArgb(255, 255, 255)
        End If
    End Function

    Private Sub DataGridView2_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        
        If DataGridView2.Columns(e.ColumnIndex).Name = "Ymd" Then
            If e.RowIndex > 0 AndAlso DataGridView2(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 2 Then
            e.Value = Util.convADStrToWarekiStr(e.Value)
        End If
    End Sub
End Class