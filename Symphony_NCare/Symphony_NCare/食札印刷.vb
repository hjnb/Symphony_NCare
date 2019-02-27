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
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "3" Then
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
                    tomoPicture = DirectCast(asaPictures.Insert(tomopath), Excel.Picture)
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
                    tomoPicture = DirectCast(asaPictures.Insert(tomopath), Excel.Picture)
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
                ElseIf Util.checkDBNullValue(CType(Me.Owner, 食札).DataGridView6(5, 0).Value) = "3" Then
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
                    tomoPicture = DirectCast(asaPictures.Insert(tomopath), Excel.Picture)
                    tomoPicture.Left = DirectCast(oSheet.Cells(6, "K"), Excel.Range).Left
                    tomoPicture.Top = DirectCast(oSheet.Cells(6, "K"), Excel.Range).Top
                End If

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

            Dim DGV1rowscount As Integer = DataGridView1.Rows.Count
            Dim Personcount As Integer = DGV1rowscount \ 12

            Dim xlRange As Excel.Range = oSheet.Cells.Range("A1:W73")
            xlRange.Copy()

            For i As Integer = 0 To Personcount \ 10
                Dim xlPasteRange As Excel.Range = oSheet.Range("A" & i * 73 + 1) 'ペースト先
                oSheet.rows("1:73").copy(xlPasteRange)
            Next


            '左列
            'oSheet.Range("B4").Interior.Color = getCellBackgroundColor(CType(Me.Owner, 食札).lblUnit.Text)
            'oSheet.Range("B15").Value = CType(Me.Owner, 食札).lblUnit.Text

            For c As Integer = 0 To DGV1rowscount - 1
                If c Mod 12 = 0 Then
                    oSheet.Range("E10").Value = DataGridView1(0, 0).Value

                    Dim asaPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                    Dim asaPicture As Excel.Picture
                    Dim asapath As String = ""
                    If Util.checkDBNullValue(DataGridView1(5, 0).Value) = "1" Then
                        asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\milk.gif"
                    ElseIf Util.checkDBNullValue(DataGridView1(5, 0).Value) = "2" Then
                        asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yogu.gif"
                    ElseIf Util.checkDBNullValue(DataGridView1(5, 0).Value) = "3" Then
                        asapath = My.Application.Info.DirectoryPath & "\img_asa" & "\yaku.gif"
                    End If
                    If System.IO.File.Exists(asapath) Then
                        asaPicture = DirectCast(asaPictures.Insert(asapath), Excel.Picture)
                        asaPicture.Left = DirectCast(oSheet.Cells(10, "K"), Excel.Range).Left
                        asaPicture.Top = DirectCast(oSheet.Cells(10, "K"), Excel.Range).Top
                    End If

                    oSheet.Range("D15").Value = DataGridView1(6, 0).Value
                    oSheet.Range("D14").Value = DataGridView1(7, 0).Value
                    oSheet.Range("D13").Value = DataGridView1(8, 0).Value
                    If Util.checkDBNullValue(DataGridView1(9, 0).Value) = "1" Then
                        oSheet.Range("F12").Value = Util.convADStrToWarekiStr(DataGridView1(2, 0).Value) & " " & DataGridView1(11, 0).Value & " ～ " & Util.convADStrToWarekiStr(DataGridView1(10, 0).Value) & " " & DataGridView1(12, 0).Value & " まで"
                    Else
                        oSheet.Range("F12").Value = Util.convADStrToWarekiStr(DataGridView1(2, 0).Value) & " " & DataGridView1(11, 0).Value & " より"
                    End If
                    Dim siruPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                    Dim siruPicture As Excel.Picture
                    Dim sirupath As String = ""
                    If Util.checkDBNullValue(DataGridView1(14, 0).Value) = "1" Then
                        sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_12.gif"
                    ElseIf Util.checkDBNullValue(DataGridView1(14, 0).Value) = "2" Then
                        sirupath = My.Application.Info.DirectoryPath & "\img_asa" & "\siru_nasi.gif"
                    ElseIf Util.checkDBNullValue(DataGridView1(5, 0).Value) = "3" Then
                        oSheet.Range("K5").Value = DataGridView1(16, 0).Value
                    End If
                    If System.IO.File.Exists(sirupath) Then
                        siruPicture = DirectCast(siruPictures.Insert(sirupath), Excel.Picture)
                        siruPicture.Left = DirectCast(oSheet.Cells(5, "K"), Excel.Range).Left
                        siruPicture.Top = DirectCast(oSheet.Cells(5, "K"), Excel.Range).Top
                    End If
                    Dim tomoPictures As Excel.Pictures = DirectCast(oSheet.Pictures, Excel.Pictures)
                    Dim tomoPicture As Excel.Picture
                    Dim tomopath As String = ""
                    If DataGridView1(18, 0).Value = "1" Then
                        tomopath = My.Application.Info.DirectoryPath & "\img_asa" & "\tomo.gif"
                    End If
                    If System.IO.File.Exists(tomopath) Then
                        tomoPicture = DirectCast(asaPictures.Insert(tomopath), Excel.Picture)
                        tomoPicture.Left = DirectCast(oSheet.Cells(8, "K"), Excel.Range).Left
                        tomoPicture.Top = DirectCast(oSheet.Cells(8, "K"), Excel.Range).Top
                    End If


                    Dim D5 As String = ""
                    Dim D6 As String = ""
                    Dim D7 As String = ""
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If i < 4 Then
                            If DataGridView1(4, i).Value <> "" Then
                                If D5 = "" Then
                                    D5 = DataGridView1(4, i).Value
                                Else
                                    D5 = D5 & "/" & DataGridView1(4, i).Value
                                End If
                            End If
                        ElseIf i < 8 Then
                            If DataGridView1(4, i).Value <> "" Then
                                If D6 = "" Then
                                    D6 = DataGridView1(4, i).Value
                                Else
                                    D6 = D6 & "/" & DataGridView1(4, i).Value
                                End If
                            End If
                        Else
                            If DataGridView1(4, i).Value <> "" Then
                                If D7 = "" Then
                                    D7 = DataGridView1(4, i).Value
                                Else
                                    D7 = D7 & "/" & DataGridView1(4, i).Value
                                End If
                            End If
                        End If
                    Next
                    oSheet.Range("D5").Value = D5
                    oSheet.Range("D6").Value = D6
                    oSheet.Range("D7").Value = D7
                End If

            Next


           



            




            '右列


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

        ElseIf rbnTokki.Checked = True Then

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
End Class