Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class 職員食
    Private DGV1Table As DataTable
    Private DGV3Table As DataTable
    Private DGV4Table As DataTable
    Private frmPrint As 職員食印刷
    Private Sub 職員食_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'DataGridView1の設定
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        DGV1Table = New DataTable()
        Util.EnableDoubleBuffering(DataGridView1)

        With DataGridView1
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
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 9)
        End With

        'DataGridView1列作成
        For col As Integer = 0 To 24
            DGV1Table.Columns.Add("a" & col, Type.GetType("System.String"))
        Next

        'DataGridView1行作成
        For row As Integer = 1 To 60
            DGV1Table.Rows.Add(DGV1Table.NewRow())
        Next

        'DataGridView1空を表示
        DataGridView1.DataSource = DGV1Table

        'DataGridView1列の設定
        For c As Integer = 0 To 24
            If c = 0 Then
                DataGridView1.Columns(c).Width = 20
                DataGridView1.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns(c).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf c = 1 Then
                DataGridView1.Columns(c).Width = 70
            ElseIf c = 24 Then
                DataGridView1.Columns(c).Width = 70
                DataGridView1.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ElseIf c = 2 Then
                DataGridView1.Columns(c).Width = 90
            Else
                DataGridView1.Columns(c).Width = 25
                DataGridView1.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        'DataGridView1の行の設定
        For r As Integer = 0 To 59
            DataGridView1.Rows(r).Height = 18
        Next
        'セル内文字設定
        For num As Integer = 1 To 60
            DataGridView1(0, num - 1).Value = num
        Next

        'DataGridView1(1, 0).Value = "所属"
        'DataGridView1(1, 1).Value = "所属"
        'DataGridView1(2, 0).Value = "職員名"
        'DataGridView1(2, 1).Value = "職員名"

        DGV3Table = New DataTable()

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
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 9)
        End With

        'DataGridView3列作成
        For col As Integer = 0 To 21
            DGV3Table.Columns.Add("a" & col, Type.GetType("System.String"))
        Next

        'DataGridView3行作成
        For row As Integer = 1 To 2
            DGV3Table.Rows.Add(DGV3Table.NewRow())
        Next

        'DataGridView3空を表示
        DataGridView3.DataSource = DGV3Table

        'DataGridView3列の設定
        For c As Integer = 0 To 21
            If c = 21 Then
                DataGridView3.Columns(c).Width = 70
                DataGridView3.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                DataGridView3.Columns(c).Width = 25
                DataGridView3.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        DGV4Table = New DataTable()

        With DataGridView4
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
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 9)
        End With

        'DataGridView4列作成
        For col As Integer = 0 To 24
            DGV4Table.Columns.Add("a" & col, Type.GetType("System.String"))
        Next

        'DataGridView4行作成
        For row As Integer = 1 To 2
            DGV4Table.Rows.Add(DGV4Table.NewRow())
        Next

        'DataGridView4空を表示
        DataGridView4.DataSource = DGV4Table

        'DataGridView4列の設定
        For c As Integer = 0 To 24
            If c = 0 Then
                DataGridView4.Columns(c).Width = 20
                DataGridView4.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView4.Columns(c).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf c = 1 Then
                DataGridView4.Columns(c).Width = 70
            ElseIf c = 24 Then
                DataGridView4.Columns(c).Width = 70
                DataGridView4.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ElseIf c = 2 Then
                DataGridView4.Columns(c).Width = 90
            Else
                DataGridView4.Columns(c).Width = 25
                DataGridView4.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        DataGridView4.Rows(1).DefaultCellStyle.ForeColor = Color.Blue

        For c As Integer = 3 To 23
            Dim a As Integer = c Mod 3
            If a = 0 Then
                DataGridView4(c, 1).Value = "朝"
            ElseIf a = 1 Then
                DataGridView4(c, 1).Value = "昼"
            ElseIf a = 2 Then
                DataGridView4(c, 1).Value = "夕"
            End If
        Next


        DataGridView4(5, 0).Style.ForeColor = Color.Blue
        DataGridView4(8, 0).Style.ForeColor = Color.Blue
        DataGridView4(11, 0).Style.ForeColor = Color.Blue
        DataGridView4(14, 0).Style.ForeColor = Color.Blue
        DataGridView4(17, 0).Style.ForeColor = Color.Blue
        DataGridView4(20, 0).Style.ForeColor = Color.Blue
        DataGridView4(23, 0).Style.ForeColor = Color.Blue
        DataGridView4(5, 0).Value = "月"
        DataGridView4(8, 0).Value = "火"
        DataGridView4(11, 0).Value = "水"
        DataGridView4(14, 0).Value = "木"
        DataGridView4(17, 0).Value = "金"
        DataGridView4(20, 0).Value = "土"
        DataGridView4(23, 0).Value = "日"

        'DataGridView4の行の設定
        DataGridView4.Rows(0).Height = 24
        DataGridView4.Rows(1).Height = 18

        '日付の設定
        Dim ymd As Date = Today.ToString("yyyy/MM/dd")
        Dim weekNumber As DayOfWeek = Today.DayOfWeek
        If weekNumber = 1 Then
            ymd = ymd.AddDays(0)
        ElseIf weekNumber = 2 Then
            ymd = ymd.AddDays(-1)
        ElseIf weekNumber = 3 Then
            ymd = ymd.AddDays(-2)
        ElseIf weekNumber = 4 Then
            ymd = ymd.AddDays(-3)
        ElseIf weekNumber = 5 Then
            ymd = ymd.AddDays(-4)
        ElseIf weekNumber = 6 Then
            ymd = ymd.AddDays(-5)
        ElseIf weekNumber = 0 Then
            ymd = ymd.AddDays(-6)
        End If
        lblYmd.Text = Util.convADStrToWarekiStr(Strings.Left(ymd, 10)) & "（月）"

        Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
        Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
        Dim Table5 As New DataTable
        SQLCm5.CommandText = "select * from EtcM WHERE dsp = 1 order by SyuN, YakN, Kana"
        Adapter5.Fill(Table5)
        DataGridView5.DataSource = Table5

        Dim DGV5rowcount As Integer = DataGridView5.Rows.Count
        For i As Integer = 0 To DGV5rowcount - 1
            DataGridView1(1, i).Value = DataGridView5(2, i).FormattedValue
            DataGridView1(2, i).Value = DataGridView5(5, i).Value
        Next

        DataGridView3(0, 0).Selected = False
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        If DataGridView2.Columns(e.ColumnIndex).Name = "SyuR" Then
            If e.RowIndex > 0 AndAlso DataGridView2(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
    End Sub
    Private Sub DataGridView5_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView5.CellFormatting
        If DataGridView5.Columns(e.ColumnIndex).Name = "SyuR" Then
            If e.RowIndex > 0 AndAlso DataGridView5(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
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

    Private Sub DataGridView4_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView4.CellPainting
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

        MergeCell(e, New Point(0, 0), New Point(0, 1))
        MergeCell(e, New Point(1, 0), New Point(1, 1))
        MergeCell(e, New Point(2, 0), New Point(2, 1))
        MergeCell(e, New Point(24, 0), New Point(24, 1))
    End Sub

    Private Sub MergeCell(ByRef e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, Cell1 As Point, Cell2 As Point)

        If (e.RowIndex >= Cell1.Y AndAlso e.RowIndex <= Cell2.Y) AndAlso (e.ColumnIndex >= Cell1.X AndAlso e.ColumnIndex <= Cell2.X) Then

            Dim rect As New Rectangle With {.X = 0, .Y = 0, .Width = 0, .Height = 0}
            Dim i As Integer

            '開始セルの位置
            '結合セルが画面外にあるときの位置を考慮
            For i = Cell1.Y + 1 To DataGridView4.FirstDisplayedScrollingRowIndex
                rect.Y -= DataGridView4(Cell1.X, i - 1).Size.Height
            Next
            For i = DataGridView4.FirstDisplayedScrollingRowIndex + 1 To Cell1.Y
                rect.Y += DataGridView4(Cell1.X, i - 1).Size.Height
            Next
            '結合セルが画面外にあるときの位置を考慮
            For i = Cell1.X + 1 To DataGridView1.FirstDisplayedScrollingColumnIndex
                rect.X -= DataGridView4(i - 1, Cell1.Y).Size.Width
            Next
            For i = DataGridView1.FirstDisplayedScrollingColumnIndex + 1 To Cell1.X
                rect.X += DataGridView4(i - 1, Cell1.Y).Size.Width
            Next

            '終了セルの幅
            For i = Cell1.Y To Cell2.Y
                rect.Height += DataGridView4(Cell2.X, i).Size.Height
            Next
            For i = Cell1.X To Cell2.X
                rect.Width += DataGridView4(i, Cell2.Y).Size.Width
            Next

            'セル位置の補正
            rect.X += 1
            rect.Y += 1

            'グラデーションをかけてヘッダーぽく見せる
            Dim gb As New System.Drawing.Drawing2D.LinearGradientBrush(rect, SystemColors.ControlLightLight, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            gb.GammaCorrection = True

            '通常の塗りつぶし
            'e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), rect)
            e.Graphics.FillRectangle(gb, rect)
            e.Graphics.DrawRectangle(New Pen(DataGridView4.GridColor), rect)

            gb.Dispose()

            '描画するセル位置の文字をヘッダーテキストとして表示
            'Dim headerText As String = DataGridView1(e.ColumnIndex, e.RowIndex).Value
            'TextRenderer.DrawText(e.Graphics, headerText, e.CellStyle.Font, rect, e.CellStyle.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

            e.Handled = True

        End If

    End Sub

    Private Sub btnUp_Click(sender As System.Object, e As System.EventArgs) Handles btnUp.Click
        Dim ymd As Date = Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 3) & "/" & Strings.Mid(lblYmd.Text, 5, 2) & "/" & Strings.Mid(lblYmd.Text, 8, 2))
        ymd = ymd.AddDays(7)
        lblYmd.Text = Util.convADStrToWarekiStr(ymd) & "（月）"
    End Sub

    Private Sub btnDown_Click(sender As System.Object, e As System.EventArgs) Handles btnDown.Click
        Dim ymd As Date = Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 3) & "/" & Strings.Mid(lblYmd.Text, 5, 2) & "/" & Strings.Mid(lblYmd.Text, 8, 2))
        ymd = ymd.AddDays(-7)
        lblYmd.Text = Util.convADStrToWarekiStr(ymd) & "（月）"
    End Sub

    Private Sub lblYmd_TextChanged(sender As Object, e As System.EventArgs) Handles lblYmd.TextChanged
        If Strings.Left(lblYmd.Text, 9) = "H30.12.31" Then
            Return
        End If
        '日付の表示
        For i As Integer = 0 To 6
            DataGridView4(3 * i + 4, 0).Value = Val(Strings.Mid(lblYmd.Text, 8, 2)) + i
        Next

        Dim Getumatu As Integer = Date.DaysInMonth(Strings.Left(Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 9)), 4), Val(Strings.Mid(lblYmd.Text, 5, 2)))

        For i As Integer = 0 To 6
            If Val(DataGridView4(3 * i + 4, 0).Value) > Getumatu Then
                DataGridView4(3 * i + 4, 0).Value = Val(DataGridView4(3 * i + 4, 0).Value) - Getumatu
            End If
        Next

        DataIndication()
    End Sub

    Private Sub clear()
        For row As Integer = 0 To 59
            For col As Integer = 1 To 24
                DataGridView1(col, row).Value = ""
            Next
        Next
        For row As Integer = 0 To 1
            For col As Integer = 1 To 21
                DataGridView3(col, row).Value = ""
            Next
        Next
    End Sub

    Private Sub DataIndication()
        clear()

        Dim Ymd As Date = Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 9))
        Dim YmdAdd7 As Date = Ymd.AddDays(6)
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select * from Dat13 WHERE #" & Ymd & "# <= Ymd and Ymd <= #" & YmdAdd7 & "# order by Gyo, SyuN, YakN, Kana, Ymd"
        Adapter.Fill(Table)
        DataGridView2.DataSource = Table

        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
        'データがない時はEtcM（職員データ）のDspが1になってるものを表示する
        If DGV2rowcount = 1 Then
            Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
            Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
            Dim Table5 As New DataTable
            SQLCm5.CommandText = "select * from EtcM WHERE dsp = 1 order by SyuN, YakN, Kana"
            Adapter5.Fill(Table5)
            DataGridView5.DataSource = Table5
            Dim DGV5rowcount As Integer = DataGridView5.Rows.Count
            For i As Integer = 0 To DGV5rowcount - 1
                DataGridView1(1, i).Value = DataGridView5(2, i).FormattedValue
                DataGridView1(2, i).Value = DataGridView5(5, i).Value
            Next
            Return
        End If
        '以下、データがある場合
        For i As Integer = 0 To DGV2rowcount - 1 Step 7
            DataGridView1(1, (i \ 7)).Value = DataGridView2(4, i).FormattedValue
            DataGridView1(2, (i \ 7)).Value = DataGridView2(1, i).Value
        Next

        Dim DGV1rowcount As Integer = 0
        For c As Integer = 0 To 59
            If Util.checkDBNullValue(DataGridView1(2, c).Value) <> "" Then
                DGV1rowcount = DGV1rowcount + 1
            End If
        Next

        For DB2slct As Integer = 0 To DGV2rowcount - 1
            For DB1slct As Integer = 0 To DGV1rowcount
                If Util.checkDBNullValue(DataGridView1(2, DB1slct).Value) = Util.checkDBNullValue(DataGridView2(1, DB2slct).Value) Then '名前が一致
                    For i As Integer = 0 To 6
                        If Util.checkDBNullValue(DataGridView4(i * 3 + 4, 0).Value) = Val(Strings.Right(DataGridView2(0, DB2slct).Value, 2)) Then '該当日付検索
                            If DataGridView2(7, DB2slct).Value = "0" Then
                                DataGridView1(i * 3 + 3, DB1slct).Value = ""
                            ElseIf DataGridView2(7, DB2slct).Value = "1" Then
                                DataGridView1(i * 3 + 3, DB1slct).Value = "○"
                            ElseIf DataGridView2(7, DB2slct).Value = "2" Then
                                DataGridView1(i * 3 + 3, DB1slct).Value = "✕"
                            ElseIf DataGridView2(7, DB2slct).Value = "3" Then
                                DataGridView1(i * 3 + 3, DB1slct).Value = "検"
                            End If
                            If DataGridView2(8, DB2slct).Value = "0" Then
                                DataGridView1(i * 3 + 4, DB1slct).Value = ""
                            ElseIf DataGridView2(8, DB2slct).Value = "1" Then
                                DataGridView1(i * 3 + 4, DB1slct).Value = "○"
                            ElseIf DataGridView2(8, DB2slct).Value = "2" Then
                                DataGridView1(i * 3 + 4, DB1slct).Value = "✕"
                            ElseIf DataGridView2(8, DB2slct).Value = "3" Then
                                DataGridView1(i * 3 + 4, DB1slct).Value = "検"
                            End If
                            If DataGridView2(9, DB2slct).Value = "0" Then
                                DataGridView1(i * 3 + 5, DB1slct).Value = ""
                            ElseIf DataGridView2(9, DB2slct).Value = "1" Then
                                DataGridView1(i * 3 + 5, DB1slct).Value = "○"
                            ElseIf DataGridView2(9, DB2slct).Value = "2" Then
                                DataGridView1(i * 3 + 5, DB1slct).Value = "✕"
                            ElseIf DataGridView2(9, DB2slct).Value = "3" Then
                                DataGridView1(i * 3 + 5, DB1slct).Value = "検"
                            End If
                        End If
                    Next

                End If
            Next
        Next

        If Util.checkDBNullValue(DataGridView1(2, 2).Value) <> "" Then
            Goukei()
        End If


    End Sub

    Private Sub Goukei()
        Dim DGV1rowcount As Integer = 0
        For c As Integer = 0 To 59
            If Util.checkDBNullValue(DataGridView1(2, c).Value) <> "" Then
                DGV1rowcount = DGV1rowcount + 1
            End If
        Next
        Dim Keicount As Integer = 0
        For row As Integer = 0 To DGV1rowcount - 1
            For col As Integer = 3 To 23
                If Util.checkDBNullValue(DataGridView1(col, row).Value) = "○" Then
                    Keicount = Keicount + 1
                End If
            Next
            DataGridView1(24, row).Value = Keicount
            Keicount = 0
        Next

        For col As Integer = 3 To 23
            For row As Integer = 0 To DGV1rowcount
                If Util.checkDBNullValue(DataGridView1(col, row).Value) = "○" Then
                    Keicount = Keicount + 1
                End If
            Next
            DataGridView3(col - 3, 0).Value = Keicount
            Keicount = 0
        Next

        For i As Integer = 1 To 7
            DataGridView3(3 * i - 2, 1).Value = Val(DataGridView3(3 * i - 3, 0).Value) + Val(DataGridView3(3 * i - 2, 0).Value) + Val(DataGridView3(3 * i - 1, 0).Value)
        Next
        DataGridView3(21, 1).Value = Val(DataGridView3(1, 1).Value) + Val(DataGridView3(4, 1).Value) + Val(DataGridView3(7, 1).Value) + Val(DataGridView3(10, 1).Value) + Val(DataGridView3(13, 1).Value) + Val(DataGridView3(16, 1).Value) + Val(DataGridView3(19, 1).Value)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        lblYmd.Text = "H30/03/12" & "（月）"
    End Sub

    Private Sub lstSyuN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstSyuN.SelectedIndexChanged
        'lstName
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
        Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
        Dim Table5 As New DataTable
        SQLCm5.CommandText = "select * from EtcM WHERE Syu = '" & lstSyuN.Text & "' order by SyuN, YakN, Kana"
        Adapter5.Fill(Table5)
        DataGridView5.DataSource = Table5

        Dim DGV5rowcount As Integer = DataGridView5.Rows.Count

        If lstSyuN.Text = "管理系" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "事務" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "特別養護老人ホーム" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "栄養課" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "居宅介護支援事業所" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "ヘルパーステーション" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "デイサービス" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "生活支援ハウス" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "宿直" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        ElseIf lstSyuN.Text = "その他" Then
            lstName.Items.Clear()
            For i As Integer = 0 To DGV5rowcount - 1
                lstName.Items.Add(DataGridView5(5, i).Value)
            Next
        End If
    End Sub

    Private Sub btnTuika_Click(sender As System.Object, e As System.EventArgs) Handles btnTuika.Click
        Dim DGV1rowcount As Integer = 0
        For c As Integer = 0 To 59
            If Util.checkDBNullValue(DataGridView1(2, c).Value) <> "" Then
                DGV1rowcount = DGV1rowcount + 1
            End If
        Next

        For i As Integer = 0 To DGV1rowcount - 1
            If DataGridView1(2, i).Value = lstName.Text Then
                MsgBox("重複ｴﾗｰ：すでに表示された氏名です")
                Return
            End If
        Next

        If lstSyuN.Text = "管理系" Then
            DataGridView1(1, DGV1rowcount).Value = "管理系"
        ElseIf lstSyuN.Text = "事務" Then
            DataGridView1(1, DGV1rowcount).Value = "事務"
        ElseIf lstSyuN.Text = "特別養護老人ホーム" Then
            DataGridView1(1, DGV1rowcount).Value = "特養"
        ElseIf lstSyuN.Text = "栄養課" Then
            DataGridView1(1, DGV1rowcount).Value = "栄養"
        ElseIf lstSyuN.Text = "居宅介護支援事業所" Then
            DataGridView1(1, DGV1rowcount).Value = "居宅"
        ElseIf lstSyuN.Text = "ヘルパーステーション" Then
            DataGridView1(1, DGV1rowcount).Value = "ヘルパ"
        ElseIf lstSyuN.Text = "デイサービス" Then
            DataGridView1(1, DGV1rowcount).Value = "デイ"
        ElseIf lstSyuN.Text = "生活支援ハウス" Then
            DataGridView1(1, DGV1rowcount).Value = "生活"
        ElseIf lstSyuN.Text = "宿直" Then
            DataGridView1(1, DGV1rowcount).Value = "宿直"
        ElseIf lstSyuN.Text = "その他" Then
            DataGridView1(1, DGV1rowcount).Value = "その他"
        End If
        DataGridView1(2, DGV1rowcount).Value = lstName.Text
    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
        If DGV2rowcount <> 1 Then
            Hennkou()

        Else
            If MsgBox("新規登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
                Tuika()

            End If
        End If
    End Sub

    Private Sub Hennkou()
        If MsgBox("変更登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(topform.DB_NCare)

            Dim Ymd As Date = Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 9))
            Dim YmdAdd7 As Date = Ymd.AddDays(6)

            Dim SQL As String = ""
            SQL = "DELETE FROM Dat13 WHERE #" & Ymd & "# <= Ymd and Ymd <= #" & YmdAdd7 & "#"

            cnn.Execute(SQL)
            cnn.Close()

            Tuika()


        End If
    End Sub

    Private Sub Tuika()
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
        Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
        Dim Table5 As New DataTable
        SQLCm5.CommandText = "select * from EtcM order by SyuN, YakN, Kana"
        Adapter5.Fill(Table5)
        DataGridView5.DataSource = Table5

        Dim SQL As String = ""
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim Honjitu As Date = Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 3) & "/" & Strings.Mid(lblYmd.Text, 5, 2) & "/" & Strings.Mid(lblYmd.Text, 8, 2))

        Dim ymd, nam, gyo, f1, f2, f3 As String
        Dim kana As String = ""
        Dim syun As String = ""
        Dim yaKn As String = ""
        Dim syur As String = ""

        Dim DGV1rowcount As Integer = 0
        For c As Integer = 0 To 59
            If Util.checkDBNullValue(DataGridView1(2, c).Value) <> "" Then
                DGV1rowcount = DGV1rowcount + 1
            End If
        Next

        Dim DGV5rowcount As Integer = DataGridView5.Rows.Count

        For DGV1row As Integer = 0 To DGV1rowcount - 1
            nam = Util.checkDBNullValue(DataGridView1(2, DGV1row).Value)
            For c As Integer = 0 To DGV5rowcount - 1
                If nam = DataGridView5(5, c).Value Then
                    kana = DataGridView5(6, c).Value
                    syun = DataGridView5(0, c).Value
                    yaKn = DataGridView5(3, c).Value
                    syur = DataGridView5(2, c).Value
                    Exit For
                End If
            Next
            gyo = DGV1row + 1
            For dd As Integer = 0 To 6
                If dd = 0 Then
                    ymd = Honjitu
                Else
                    ymd = Honjitu.AddDays(dd)
                End If
                If Util.checkDBNullValue(DataGridView1(dd * 3 + 3, DGV1row).Value) = "○" Then
                    f1 = 1
                ElseIf Util.checkDBNullValue(DataGridView1(dd * 3 + 3, DGV1row).Value) = "✕" Then
                    f1 = 2
                ElseIf Util.checkDBNullValue(DataGridView1(dd * 3 + 3, DGV1row).Value) = "検" Then
                    f1 = 3
                Else
                    f1 = 0
                End If
                If Util.checkDBNullValue(DataGridView1(dd * 3 + 4, DGV1row).Value) = "○" Then
                    f2 = 1
                ElseIf Util.checkDBNullValue(DataGridView1(dd * 3 + 4, DGV1row).Value) = "✕" Then
                    f2 = 2
                ElseIf Util.checkDBNullValue(DataGridView1(dd * 3 + 4, DGV1row).Value) = "検" Then
                    f2 = 3
                Else
                    f2 = 0
                End If
                If Util.checkDBNullValue(DataGridView1(dd * 3 + 5, DGV1row).Value) = "○" Then
                    f3 = 1
                ElseIf Util.checkDBNullValue(DataGridView1(dd * 3 + 5, DGV1row).Value) = "✕" Then
                    f3 = 2
                ElseIf Util.checkDBNullValue(DataGridView1(dd * 3 + 5, DGV1row).Value) = "検" Then
                    f3 = 3
                Else
                    f3 = 0
                End If


                SQL = "INSERT INTO Dat13 VALUES ('" & ymd & "', '" & nam & "', '" & kana & "', " & gyo & ", '" & syur & "', " & syun & ", " & yaKn & ", " & f1 & ", " & f2 & ", " & f3 & ")"
                cnn.Execute(SQL)
            Next
        Next

        DataIndication()


    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(topform.DB_NCare)

            Dim Ymd As Date = Util.convWarekiStrToADStr(Strings.Left(lblYmd.Text, 9))
            Dim YmdAdd7 As Date = Ymd.AddDays(6)

            Dim SQL As String = ""
            SQL = "DELETE FROM Dat13 WHERE #" & Ymd & "# <= Ymd and Ymd <= #" & YmdAdd7 & "#"

            cnn.Execute(SQL)
            cnn.Close()

            DataIndication()
        End If
    End Sub

    Private Sub btnInnsatu_Click(sender As System.Object, e As System.EventArgs) Handles btnInnsatu.Click
        If IsNothing(frmPrint) OrElse frmPrint.IsDisposed Then
            frmPrint = New 職員食印刷()
            frmPrint.Owner = Me
            frmPrint.Show()
        End If
    End Sub

    
End Class