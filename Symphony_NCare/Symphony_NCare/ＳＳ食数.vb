Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class ＳＳ食数
    Private DGV3Table As DataTable
    Private whiteCellStyle As DataGridViewCellStyle
    Private clearCellStyle As DataGridViewCellStyle
    Private SatCellStyle As DataGridViewCellStyle
    Private SunCellStyle As DataGridViewCellStyle
    Private DGV2CellStyle As DataGridViewCellStyle
    Private Sub MadeStyle()
        '各曜日のセルスタイル設定
        whiteCellStyle = New DataGridViewCellStyle()
        clearCellStyle = New DataGridViewCellStyle()
        SatCellStyle = New DataGridViewCellStyle()
        SunCellStyle = New DataGridViewCellStyle()
        DGV2CellStyle = New DataGridViewCellStyle()
        whiteCellStyle.BackColor = Color.FromArgb(255, 255, 255)
        whiteCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        clearCellStyle.BackColor = Color.FromArgb(234, 234, 234)
        SatCellStyle.BackColor = Color.FromArgb(200, 200, 255)
        SunCellStyle.BackColor = Color.FromArgb(255, 200, 200)
        DGV2CellStyle.BackColor = Color.FromArgb(192, 192, 255)
    End Sub

    Private Sub ＳＳ食数_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        KeyPreview = True
        MadeStyle()

        lblName.Text = ""

        Util.EnableDoubleBuffering(DataGridView1)
        DataGridView1.RowTemplate.Height = 15

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select Nam, Kana, Unit, Hyo from UsrM WHERE Unit = '海' AND Hyo = '1' order by Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 1 To 3
            DataGridView1.Columns(i).Visible = False
        Next

        Util.EnableDoubleBuffering(DataGridView2)

        DataGridView2.RowTemplate.Height = 18

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable
        SQLCm2.CommandText = "select distinct Nam, Kana, Ym from Dat12 WHERE Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "' ORDER BY Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
        For i As Integer = 0 To DGV2rowcount - 1
            DataGridView2.Columns(0).DefaultCellStyle = DGV2CellStyle
        Next

        DataGridView2.Columns(1).Visible = False
        DataGridView2.Columns(2).Visible = False

        Util.EnableDoubleBuffering(DataGridView3)

        With DataGridView3
            .RowTemplate.Height = 20
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With

        DGV3Table = New DataTable()
        '列作成
        For i As Integer = 0 To 31
            DGV3Table.Columns.Add("a" & i, Type.GetType("System.String"))
        Next
        '行作成
        For i As Integer = 0 To 4
            DGV3Table.Rows.Add(DGV3Table.NewRow())
        Next
        '空を表示
        DataGridView3.DataSource = DGV3Table
        'データグリッドビューの各セルの設定
        DataGridView3.Columns(0).Width = 40
        For i As Integer = 1 To 31
            With DataGridView3.Columns(i)
                .Width = 25
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Next
        For r As Integer = 0 To 4
            If r = 0 OrElse r = 1 Then
                DataGridView3.Rows(r).Height = 18
            Else
                DataGridView3.Rows(r).Height = 25
            End If
        Next

        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))

        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        Dim Week() As String = {"", "日", "月", "火", "水", "木", "金", "土"}
        Dim oldDate As Date
        Dim oldWeekDay As Integer

        For dd As Integer = 1 To Getumatu
            DataGridView3(dd, 0).Value = dd
            oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/" & dd
            oldWeekDay = Weekday(oldDate)
            DataGridView3(dd, 1).Value = Week(oldWeekDay)
            DataGridView3.Columns(dd).ReadOnly = False
            DataGridView3.Columns(dd).DefaultCellStyle = whiteCellStyle
        Next
        With DataGridView3
            .Columns(0).ReadOnly = True
            .Columns(0).DefaultCellStyle = whiteCellStyle
            .Rows(0).ReadOnly = True
            .Rows(1).ReadOnly = True
        End With
        DataGridView3(0, 2).Value = "朝"
        DataGridView3(0, 3).Value = "昼"
        DataGridView3(0, 4).Value = "夕"
        For c As Integer = 1 To 31
            For r As Integer = 2 To 4
                DataGridView3(c, r).Style.Font = New Font("Gothic", 14)
            Next
        Next

        WeekColor()

        DataGridView1(0, 0).Selected = False
        DataGridView2(0, 0).Selected = False

    End Sub

    Private Sub FormUpdate()
        KeyPreview = True

        MadeStyle()

        lblName.Text = ""

        Util.EnableDoubleBuffering(DataGridView1)
        DataGridView1.RowTemplate.Height = 15

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select Nam, Kana, Unit, Hyo from UsrM WHERE Unit = '海' AND Hyo = '1' order by Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 1 To 3
            DataGridView1.Columns(i).Visible = False
        Next

        Util.EnableDoubleBuffering(DataGridView2)

        DataGridView2.RowTemplate.Height = 18

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable
        SQLCm2.CommandText = "select distinct Nam, Kana, Ym from Dat12 WHERE Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "' ORDER BY Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
        For i As Integer = 0 To DGV2rowcount - 1
            DataGridView2.Columns(0).DefaultCellStyle = DGV2CellStyle
        Next

        DataGridView2.Columns(1).Visible = False
        DataGridView2.Columns(2).Visible = False

        Util.EnableDoubleBuffering(DataGridView3)

        With DataGridView3
            .RowTemplate.Height = 20
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With

        DGV3Table = New DataTable()
        '列作成
        For i As Integer = 0 To 31
            DGV3Table.Columns.Add("a" & i, Type.GetType("System.String"))
        Next
        '行作成
        For i As Integer = 0 To 4
            DGV3Table.Rows.Add(DGV3Table.NewRow())
        Next
        '空を表示
        DataGridView3.DataSource = DGV3Table
        'データグリッドビューの各セルの設定
        DataGridView3.Columns(0).Width = 40
        For i As Integer = 1 To 31
            With DataGridView3.Columns(i)
                .Width = 25
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Next
        For r As Integer = 0 To 4
            If r = 0 OrElse r = 1 Then
                DataGridView3.Rows(r).Height = 18
            Else
                DataGridView3.Rows(r).Height = 25
            End If
        Next

        'YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))

        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        Dim Week() As String = {"", "日", "月", "火", "水", "木", "金", "土"}
        Dim oldDate As Date
        Dim oldWeekDay As Integer

        For dd As Integer = 1 To Getumatu
            DataGridView3(dd, 0).Value = dd
            oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/" & dd
            oldWeekDay = Weekday(oldDate)
            DataGridView3(dd, 1).Value = Week(oldWeekDay)
            DataGridView3.Columns(dd).ReadOnly = False
            DataGridView3.Columns(dd).DefaultCellStyle = whiteCellStyle
        Next
        With DataGridView3
            .Columns(0).ReadOnly = True
            .Columns(0).DefaultCellStyle = whiteCellStyle
            .Rows(0).ReadOnly = True
            .Rows(1).ReadOnly = True
        End With
        DataGridView3(0, 2).Value = "朝"
        DataGridView3(0, 3).Value = "昼"
        DataGridView3(0, 4).Value = "夕"
        For c As Integer = 1 To 31
            For r As Integer = 2 To 4
                DataGridView3(c, r).Style.Font = New Font("Gothic", 14)
            Next
        Next

        WeekColor()

    End Sub

    Private Sub DataGridView3_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView3.CellPainting
        '選択したセルに枠を付ける
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    Private Sub ClearCell()
        For r As Integer = 0 To 4
            For c As Integer = 0 To 31
                DataGridView3(c, r).Value = ""
            Next
        Next

        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        Dim Week() As String = {"", "日", "月", "火", "水", "木", "金", "土"}
        Dim oldDate As Date
        Dim oldWeekDay As Integer

        For dd As Integer = 1 To Getumatu
            DataGridView3(dd, 0).Value = dd
            oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/" & dd
            oldWeekDay = Weekday(oldDate)
            DataGridView3(dd, 1).Value = Week(oldWeekDay)
            DataGridView3.Columns(dd).ReadOnly = False
            DataGridView3.Columns(dd).DefaultCellStyle = whiteCellStyle
        Next
        With DataGridView3
            .Columns(0).ReadOnly = True
            .Columns(0).DefaultCellStyle = whiteCellStyle
            .Rows(0).ReadOnly = True
            .Rows(1).ReadOnly = True
        End With
        DataGridView3(0, 2).Value = "朝"
        DataGridView3(0, 3).Value = "昼"
        DataGridView3(0, 4).Value = "夕"
    End Sub

    Private Sub WeekColor()
        '土曜日曜の色付け
        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))

        For dd As Integer = 1 To 31
            If Util.checkDBNullValue(DataGridView3(dd, 1).Value) = "土" Then
                DataGridView3(dd, 1).Style = SatCellStyle
            ElseIf Util.checkDBNullValue(DataGridView3(dd, 1).Value) = "日" Then
                DataGridView3(dd, 1).Style = SunCellStyle
            Else
                DataGridView3(dd, 1).Style = whiteCellStyle
            End If
        Next
    End Sub

    Private Sub YmdBox1_YmdTextChange(sender As Object, e As System.EventArgs) Handles YmdBox1.YmdTextChange
        '各月の曜日を設定していく
        ClearCell()
        lblName.Text = ""
        'Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        'Dim Week() As String = {"", "日", "月", "火", "水", "木", "金", "土"}
        'Dim oldDate As Date
        'Dim oldWeekDay As Integer

        'For dd As Integer = 1 To Getumatu
        '    DataGridView3(dd, 0).Value = dd
        '    oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/" & dd
        '    oldWeekDay = Weekday(oldDate)
        '    DataGridView3(dd, 1).Value = Week(oldWeekDay)
        '    DataGridView3.Columns(dd).ReadOnly = False
        '    DataGridView3.Columns(dd).DefaultCellStyle = whiteCellStyle
        'Next
        'With DataGridView3
        '    .Columns(0).ReadOnly = True
        '    .Columns(0).DefaultCellStyle = whiteCellStyle
        '    .Rows(0).ReadOnly = True
        '    .Rows(1).ReadOnly = True
        'End With
        'DataGridView3(0, 2).Value = "朝"
        'DataGridView3(0, 3).Value = "昼"
        'DataGridView3(0, 4).Value = "夕"

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable
        SQLCm2.CommandText = "select distinct Nam, Kana, Ym from Dat12 WHERE Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "' ORDER BY Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
        For i As Integer = 0 To DGV2rowcount - 1
            DataGridView2.Columns(0).DefaultCellStyle = DGV2CellStyle
        Next

        DataGridView2.Columns(1).Visible = False
        DataGridView2.Columns(2).Visible = False

        WeekColor()

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        ClearCell()

        Dim SelectedRows As Integer = DataGridView1.CurrentRow.Index
        lblName.Text = DataGridView1(0, SelectedRows).Value
    End Sub

    Private Sub DataGridView2_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        ClearCell()

        Dim SelectedRows As Integer = DataGridView2.CurrentRow.Index
        lblName.Text = DataGridView2(0, SelectedRows).Value

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm4 As OleDbCommand = Cn.CreateCommand
        Dim Adapter4 As New OleDbDataAdapter(SQLCm4)
        Dim Table4 As New DataTable
        SQLCm4.CommandText = "select * from Dat12 WHERE Nam = '" & lblName.Text & "' AND Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "' ORDER BY Gyo"
        Adapter4.Fill(Table4)
        DataGridView4.DataSource = Table4

        Dim DGV4RowCount As Integer = DataGridView4.Rows.Count
        For dd As Integer = 0 To DGV4RowCount - 1
            For f1f2f3 As Integer = 4 To 6
                If Util.checkDBNullValue(DataGridView4(f1f2f3, dd).Value) = "1" Then
                    DataGridView3(dd + 1, f1f2f3 - 2).Value = "■"
                Else
                    DataGridView3(dd + 1, f1f2f3 - 2).Value = ""
                End If
            Next
        Next
    End Sub

    Private Sub btnAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAll.Click
        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        For dd As Integer = 1 To getumatu
            For row As Integer = 2 To 4
                DataGridView3(dd, row).Value = "■"
            Next
        Next
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択して下さい")
            Return
        End If

        Dim DGV2NameList As Integer = DataGridView2.Rows.Count
        For i As Integer = 0 To DGV2NameList - 1
            If lblName.Text = DataGridView2(0, i).Value Then
                Hennkou()
                Exit Sub
            End If
        Next

        Tuika()

    End Sub

    Private Sub Tuika()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim ym, nam As String
        Dim kana As String = ""
        Dim f1 As String = "0"
        Dim f2 As String = "0"
        Dim f3 As String = "0"

        ym = Strings.Mid(YmdBox1.getADStr(), 3, 5)
        nam = lblName.Text
        For nameNumber As Integer = 0 To DataGridView1.Rows.Count - 1
            If lblName.Text = DataGridView1(0, nameNumber).Value Then
                kana = DataGridView1(1, nameNumber).Value
                Exit For
            End If
        Next

        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        For gyo As Integer = 1 To Getumatu
            For f1f2f3 As Integer = 2 To 4
                If f1f2f3 = 2 Then
                    If DataGridView3(gyo, f1f2f3).Value = "■" Then
                        f1 = "1"
                    Else
                        f1 = "0"
                    End If
                ElseIf f1f2f3 = 3 Then
                    If DataGridView3(gyo, f1f2f3).Value = "■" Then
                        f2 = "1"
                    Else
                        f2 = "0"
                    End If
                ElseIf f1f2f3 = 4 Then
                    If DataGridView3(gyo, f1f2f3).Value = "■" Then
                        f3 = "1"
                    Else
                        f3 = "0"
                    End If
                End If
            Next
            Dim SQL As String = ""
            SQL = "INSERT INTO Dat12 VALUES ('" & ym & "', '" & nam & "', '" & kana & "', " & gyo & ", '" & f1 & "', '" & f2 & "', '" & f3 & "')"
            cnn.Execute(SQL)
        Next

        cnn.Close()

        FormUpdate()
    End Sub

    Private Sub Hennkou()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim SQL As String = ""
        SQL = "DELETE FROM Dat12 WHERE Nam = '" & lblName.Text & "' AND Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "'"
        cnn.Execute(SQL)

        Dim ym, nam As String
        Dim kana As String = ""
        Dim f1 As String = "0"
        Dim f2 As String = "0"
        Dim f3 As String = "0"

        ym = Strings.Mid(YmdBox1.getADStr(), 3, 5)
        nam = lblName.Text
        For nameNumber As Integer = 0 To DataGridView1.Rows.Count - 1
            If lblName.Text = DataGridView1(0, nameNumber).Value Then
                kana = DataGridView1(1, nameNumber).Value
                Exit For
            End If
        Next

        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        For gyo As Integer = 1 To Getumatu
            For f1f2f3 As Integer = 2 To 4
                If f1f2f3 = 2 Then
                    If DataGridView3(gyo, f1f2f3).Value = "■" Then
                        f1 = "1"
                    Else
                        f1 = "0"
                    End If
                ElseIf f1f2f3 = 3 Then
                    If DataGridView3(gyo, f1f2f3).Value = "■" Then
                        f2 = "1"
                    Else
                        f2 = "0"
                    End If
                ElseIf f1f2f3 = 4 Then
                    If DataGridView3(gyo, f1f2f3).Value = "■" Then
                        f3 = "1"
                    Else
                        f3 = "0"
                    End If
                End If
            Next
            SQL = "INSERT INTO Dat12 VALUES ('" & ym & "', '" & nam & "', '" & kana & "', " & gyo & ", '" & f1 & "', '" & f2 & "', '" & f3 & "')"
            cnn.Execute(SQL)
        Next

        cnn.Close()

        FormUpdate()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択して下さい")
            Return
        End If

        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If lblName.Text = DataGridView2(0, i).Value Then
                If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
                    Dim cnn As New ADODB.Connection
                    cnn.Open(topform.DB_NCare)

                    Dim SQL As String = ""
                    SQL = "DELETE FROM Dat12 WHERE Nam = '" & lblName.Text & "' AND Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "'"

                    cnn.Execute(SQL)
                    cnn.Close()

                    FormUpdate()

                    Exit Sub
                End If
            End If
        Next

        MsgBox("登録されていません")

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm4 As OleDbCommand = Cn.CreateCommand
        Dim Adapter4 As New OleDbDataAdapter(SQLCm4)
        Dim Table4 As New DataTable

        Dim objExcel As Object
        Dim objWorkBooks As Object
        Dim objWorkBook As Object
        Dim oSheet As Object

        Dim Value As String = ""
        Dim cell(3, 31) As String
        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))

        objExcel = CreateObject("Excel.Application")
        objWorkBooks = objExcel.Workbooks
        objWorkBook = objWorkBooks.Open(topform.excelFilePass)
        oSheet = objWorkBook.Worksheets("SS食数")

        oSheet.Range("B2").Value = YmdBox1.getWarekiKanji() & " " & Strings.Mid(Util.convADStrToWarekiStr(YmdBox1.getADStr()), 2, 2) & " 年 " & Strings.Mid(YmdBox1.getADStr(), 6, 2) & " 月 "

        Dim DGV2RowCount As Integer = DataGridView2.Rows.Count
        '印刷枚数調整
        If DGV2RowCount <= 10 Then
            '1枚
        ElseIf 10 < DGV2RowCount AndAlso DGV2RowCount <= 20 Then
            '2枚
            Dim xlPasteRange As Excel.Range = oSheet.Range("A65") 'ペースト先
            oSheet.rows("1:64").copy(xlPasteRange)
            oSheet.Range("B66").Value = YmdBox1.getWarekiKanji() & " " & Strings.Mid(Util.convADStrToWarekiStr(YmdBox1.getADStr()), 2, 2) & " 年 " & Strings.Mid(YmdBox1.getADStr(), 6, 2) & " 月 "
        ElseIf DGV2RowCount > 20 Then
            '3枚
            Dim xlPasteRange As Excel.Range = oSheet.Range("A65") 'ペースト先
            oSheet.rows("1:64").copy(xlPasteRange)
            Dim xlPasteRange2 As Excel.Range = oSheet.Range("A129") 'ペースト先
            oSheet.rows("1:64").copy(xlPasteRange2)
            oSheet.Range("B66").Value = YmdBox1.getWarekiKanji() & " " & Strings.Mid(Util.convADStrToWarekiStr(YmdBox1.getADStr()), 2, 2) & " 年 " & Strings.Mid(YmdBox1.getADStr(), 6, 2) & " 月 "
            oSheet.Range("B130").Value = YmdBox1.getWarekiKanji() & " " & Strings.Mid(Util.convADStrToWarekiStr(YmdBox1.getADStr()), 2, 2) & " 年 " & Strings.Mid(YmdBox1.getADStr(), 6, 2) & " 月 "
        End If

        For NameNumber As Integer = 0 To DGV2RowCount - 1
            Dim nam As String = DataGridView2(0, NameNumber).Value
            SQLCm4.CommandText = "select * from Dat12 WHERE Nam = '" & nam & "' AND Ym =  '" & Strings.Mid(YmdBox1.getADStr(), 3, 5) & "' ORDER BY Gyo"
            Adapter4.Fill(Table4)
            DataGridView4.DataSource = Table4

            If NameNumber < 10 Then
                oSheet.Range("B" & NameNumber * 6 + 4).Value = nam
                For row As Integer = 0 To 3
                    For col As Integer = 1 To Getumatu
                        If row = 0 Then
                            cell(row, col - 1) = col
                        Else
                            For i As Integer = 0 To DataGridView4.Rows.Count - 1
                                If DataGridView4(3, i).Value = col Then
                                    Value = DataGridView4(row + 3, i).Value
                                    If Value = "1" Then
                                        Value = "■"
                                    Else
                                        Value = ""
                                    End If
                                    cell(row, col - 1) = Value
                                End If
                            Next
                        End If
                    Next
                Next
                oSheet.Range("C" & NameNumber * 6 + 5, "AG" & NameNumber * 6 + 8).Value = cell

            ElseIf NameNumber >= 10 AndAlso NameNumber < 20 Then
                oSheet.Range("B" & NameNumber * 6 + 8).Value = nam
                For row As Integer = 0 To 3
                    For col As Integer = 1 To Getumatu
                        If row = 0 Then
                            cell(row, col - 1) = col
                        Else
                            For i As Integer = 0 To DataGridView4.Rows.Count - 1
                                If DataGridView4(3, i).Value = col Then
                                    Value = DataGridView4(row + 3, i).Value
                                    If Value = "1" Then
                                        Value = "■"
                                    Else
                                        Value = ""
                                    End If
                                    cell(row, col - 1) = Value
                                End If
                            Next
                        End If
                    Next
                Next
                oSheet.Range("C" & NameNumber * 6 + 9, "AG" & NameNumber * 6 + 12).Value = cell

            ElseIf NameNumber >= 20 Then
                oSheet.Range("B" & NameNumber * 6 + 10).Value = nam
                For row As Integer = 0 To 3
                    For col As Integer = 1 To Getumatu
                        If row = 0 Then
                            cell(row, col - 1) = col
                        Else
                            For i As Integer = 0 To DataGridView4.Rows.Count - 1
                                If DataGridView4(3, i).Value = col Then
                                    Value = DataGridView4(row + 3, i).Value
                                    If Value = "1" Then
                                        Value = "■"
                                    Else
                                        Value = ""
                                    End If
                                    cell(row, col - 1) = Value
                                End If
                            Next
                        End If
                    Next
                Next
                oSheet.Range("C" & NameNumber * 6 + 13, "AG" & NameNumber * 6 + 16).Value = cell
            End If

        Next

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
    End Sub
End Class