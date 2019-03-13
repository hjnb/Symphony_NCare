Imports System.Data.OleDb

Public Class スクリーニング書

    '選択されている入居者名
    Private selectedResidentName As String

    '選択入居者の生年月日
    Private selectedResidentBirth As String

    '選択入居者の性別(男："1",女："2")
    Private selectedResidentSex As String

    'W/Hマスタ選択年月
    Private selectedYm As String

    'コンボボックス用配列
    Private tantoArray() As String = {"澤田　美佳"} '記入者
    Private kaiArray() As String = {"１", "２", "３", "４", "５"} '介護度
    Private columnNumArray() As String = {"Ⅰ", "Ⅱ", "Ⅲ", "Ⅳ"}

    '行ヘッダーテキスト
    Private weightChangeRowHeaderText() As String = {"過去の体重", "体重差", "体重減少率", "測定日"}

    '項目列、単位列セルスタイル
    Private itemUnitColumnCellStyle As DataGridViewCellStyle

    '入力セルスタイル
    Private inputWhiteCellStyle As DataGridViewCellStyle
    Private inputGrayCellStyle As DataGridViewCellStyle

    'セルエンター制御用フラグ
    Private canCellEnter As Boolean = False

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(residentName As String)
        InitializeComponent()

        selectedResidentName = residentName

    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub スクリーニング書_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'セルスタイル作成
        createCellStyle()

        'コンボボックス設定
        tantoComboBox.Items.AddRange(tantoArray)
        kaiComboBox.Items.AddRange(kaiArray)
        clearComboBox.Items.AddRange(columnNumArray)
        insertNumComboBox.Items.AddRange(columnNumArray)

        '作成年月日
        createYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))

        '名前表示
        namArea.Text = selectedResidentName

        '履歴リスト表示
        loadHistoryList()

        'W/Hマスタ表示
        initDgvWeight()
        displayWHMaster()

        'dgv特記事項初期設定
        initDgvTokki()

        'dgvスクリーニング初期設定
        initDgvScreening()

        '入居者情報表示(ユニット、名前、性別、生年月日、年齢)
        displayResidentInfo()

        'dgv体重推移初期設定
        initDgvWeightChange()

        '実施年月日
        JYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))

        '右半分初期化
        btnClearRight.PerformClick()
    End Sub

    ''' <summary>
    ''' セルスタイル作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createCellStyle()
        '
        itemUnitColumnCellStyle = New DataGridViewCellStyle()
        itemUnitColumnCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)

        '
        inputWhiteCellStyle = New DataGridViewCellStyle()
        With inputWhiteCellStyle
            .BackColor = Color.White
            .ForeColor = Color.Black
            .SelectionBackColor = Color.White
            .SelectionForeColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        '
        inputGrayCellStyle = New DataGridViewCellStyle()
        With inputGrayCellStyle
            .BackColor = Color.FromKnownColor(KnownColor.Control)
            .ForeColor = Color.Black
            .SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
            .SelectionForeColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    ''' <summary>
    ''' dgv体重推移初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvWeightChange()
        Util.EnableDoubleBuffering(dgvWeightChange)

        With dgvWeightChange
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 18
            .RowHeadersWidth = 75
            .RowTemplate.Height = 15
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            .Font = New Font("ＭＳ Ｐゴシック", 9)
        End With

        '空行追加等
        Dim dt As New DataTable()
        dt.Columns.Add("prev1", Type.GetType("System.String"))
        dt.Columns.Add("prev2", Type.GetType("System.String"))
        dt.Columns.Add("prev3", Type.GetType("System.String"))
        dt.Columns.Add("prev4", Type.GetType("System.String"))
        dt.Columns.Add("prev5", Type.GetType("System.String"))
        dt.Columns.Add("prev6", Type.GetType("System.String"))
        For i As Integer = 0 To 3
            Dim row As DataRow = dt.NewRow()
            row(0) = ""
            row(1) = ""
            row(2) = ""
            row(3) = ""
            row(4) = ""
            row(5) = ""
            dt.Rows.Add(row)
        Next

        dgvWeightChange.DataSource = dt

        '幅設定等
        With dgvWeightChange
            With .Columns("prev1")
                .HeaderText = "前月"
                .Width = 57
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            For i As Integer = 2 To 6
                With .Columns("prev" & i)
                    .HeaderText = i & "ヶ月前"
                    .Width = 57
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
            Next
        End With
    End Sub

    ''' <summary>
    ''' dgv体重身長マスタ初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvWeight()
        Util.EnableDoubleBuffering(dgvWeight)

        With dgvWeight
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("ＭＳ Ｐゴシック", 7)
            .ColumnHeadersHeight = 16
            .RowHeadersVisible = False
            .RowTemplate.Height = 16
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.Black
            .DefaultCellStyle.SelectionForeColor = Color.White
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            .Font = New Font("ＭＳ Ｐゴシック", 7)
        End With
    End Sub

    ''' <summary>
    ''' dgv特記事項初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvTokki()
        Util.EnableDoubleBuffering(dgvTokki)

        With dgvTokki
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowTemplate.Height = 16
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
        End With

        Dim dt As New DataTable()
        dt.Columns.Add("Text", Type.GetType("System.String"))
        For i As Integer = 0 To 2
            Dim row As DataRow = dt.NewRow()
            row(0) = ""
            dt.Rows.Add(row)
        Next

        '表示
        dgvTokki.DataSource = dt

        '幅設定等
        With dgvTokki
            With .Columns("Text")
                .Width = 370
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With

        canCellEnter = True
    End Sub

    ''' <summary>
    ''' dgvスクリーニング初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvScreening()
        Util.EnableDoubleBuffering(dgvScreening)

        With dgvScreening
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersVisible = False
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersVisible = False
            .RowTemplate.Height = 19
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
        End With

        '空行追加等
        Dim itemArray() As String = {"リスク", "身長", "体重", "ＢＭＩ", "", "体重減少率", "", "", "", "血清ｱﾙﾌﾞﾐﾝ値", "", "　　　 (検査日)", "食事摂取量", "", "", "　　　 (内　容)", "栄養補給法", "褥瘡"}
        Dim unitArray() As String = {"低/中/高", "cm", "kg", "kg/㎡", "低/中", "ヶ月", "％", "増/減", "低/中/高", "g/dl", "低/中/高", "", "摂食割合(％)", "", "低/中", "", "経腸/静脈/無", "褥瘡/無"}
        Dim dt As New DataTable()
        dt.Columns.Add("Item", Type.GetType("System.String"))
        dt.Columns.Add("Unit", Type.GetType("System.String"))
        dt.Columns.Add("J1", Type.GetType("System.String"))
        dt.Columns.Add("J2", Type.GetType("System.String"))
        dt.Columns.Add("J3", Type.GetType("System.String"))
        dt.Columns.Add("J4", Type.GetType("System.String"))
        For i As Integer = 0 To 17
            Dim row As DataRow = dt.NewRow()
            row(0) = itemArray(i)
            row(1) = unitArray(i)
            row(2) = ""
            row(3) = ""
            row(4) = ""
            row(5) = ""
            dt.Rows.Add(row)
        Next

        '表示
        dgvScreening.DataSource = dt

        '幅設定等
        With dgvScreening
            With .Columns("Item")
                .DefaultCellStyle = itemUnitColumnCellStyle
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            With .Columns("Unit")
                .DefaultCellStyle = itemUnitColumnCellStyle
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            With .Columns("J1")
                .DefaultCellStyle = inputWhiteCellStyle
                .Width = 127
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("J2")
                .DefaultCellStyle = inputWhiteCellStyle
                .Width = 127
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("J3")
                .DefaultCellStyle = inputWhiteCellStyle
                .Width = 127
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("J4")
                .DefaultCellStyle = inputWhiteCellStyle
                .Width = 127
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            '個別にセルスタイル設定
            For i As Integer = 1 To 4
                dgvScreening("J" & i, 3).Style = inputGrayCellStyle
                dgvScreening("J" & i, 13).Style = inputGrayCellStyle
            Next
        End With

        '対象設定
        dgvScreening.targetYmdBox1 = J1YmdBox
        dgvScreening.targetYmdBox2 = J2YmdBox
        dgvScreening.targetYmdBox3 = J3YmdBox
        dgvScreening.targetYmdBox4 = J4YmdBox

        '
        clearScreening()
    End Sub

    ''' <summary>
    ''' スクリーニング部分のクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearScreening()
        '記入者氏名
        tantoComboBox.Text = ""
        '介護度
        kaiComboBox.Text = ""
        '特記事項
        For Each row As DataGridViewRow In dgvTokki.Rows
            row.Cells("Text").Value = ""
        Next
        'dgvスクリーニング
        J1YmdBox.clearText()
        J2YmdBox.clearText()
        J3YmdBox.clearText()
        J4YmdBox.clearText()
        For Each row As DataGridViewRow In dgvScreening.Rows
            row.Cells("J1").Value = ""
            row.Cells("J2").Value = ""
            row.Cells("J3").Value = ""
            row.Cells("J4").Value = ""
        Next
    End Sub

    ''' <summary>
    ''' W/Hマスタ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayWHMaster()
        '身長データ取得(Dat10)
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select Height from Dat10 where Nam='" & selectedResidentName & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            heightMLabel.Text = Util.checkDBNullValue(rs.Fields("Height").Value)
        End If
        rs.Close()

        '体重データ取得(Dat9)
        sql = "select Ym, Weight From Dat9 where Nam='" & selectedResidentName & "' order by Ym Desc"
        rs = New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Weight")
        dgvWeight.DataSource = ds.Tables("Weight")
        cn.Close()

        '体重データレコード数
        Dim weightRowCount As Integer = dgvWeight.Rows.Count

        '幅設定等
        With dgvWeight
            Dim plusWidth1 As Integer = If(weightRowCount > 6, 0, 9)
            Dim plusWidth2 As Integer = If(weightRowCount > 6, 0, 8)
            With .Columns("Ym")
                .HeaderText = "年月"
                .Width = 43 + plusWidth1
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Weight")
                .HeaderText = "体重"
                .Width = 35 + plusWidth2
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
    End Sub

    ''' <summary>
    ''' 入居者情報表示(ユニット、名前、性別、生年月日)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayResidentInfo()
        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from UsrM where Nam='" & selectedResidentName & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            Dim unit As String = Util.checkDBNullValue(rs.Fields("Unit").Value)
            Dim kana As String = Util.checkDBNullValue(rs.Fields("Kana").Value)
            selectedResidentBirth = Util.checkDBNullValue(rs.Fields("Birth").Value)
            Dim birthWareki As String = Util.convADStrToWarekiStr(Util.checkDBNullValue(rs.Fields("Birth").Value))
            Dim sex As String = Util.checkDBNullValue(rs.Fields("Sex").Value)
            selectedResidentSex = sex

            '値セット
            unitLabel.Text = unit & "の家"
            namLabel.Text = selectedResidentName
            kanaLabel.Text = kana
            birthLabel.Text = birthWareki
            sexLabel.Text = If(sex = "1", "♂", If(sex = "2", "♀", ""))
        End If
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' スクリーニングデータ表示
    ''' </summary>
    ''' <param name="ymd"></param>
    ''' <remarks></remarks>
    Private Sub displayScreening(ymd As String)
        'クリア
        clearScreening()

        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Dat0 where Nam='" & selectedResidentName & "' and Ymd='" & ymd & "' order by Gyo"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim gyo As Integer = rs.Fields("Gyo").Value
            If gyo = 1 Then
                '記入者氏名
                tantoComboBox.Text = Util.checkDBNullValue(rs.Fields("Tanto").Value)
                '作成年月日
                createYmdBox.setADStr(Util.checkDBNullValue(rs.Fields("Ymd").Value))
                '介護度
                kaiComboBox.Text = Util.checkDBNullValue(rs.Fields("Kai").Value)
                '特記事項
                dgvTokki(0, 0).Value = Util.checkDBNullValue(rs.Fields("Tokki1").Value)
                dgvTokki(0, 1).Value = Util.checkDBNullValue(rs.Fields("Tokki2").Value)
                dgvTokki(0, 2).Value = Util.checkDBNullValue(rs.Fields("Tokki3").Value)
            End If
            '実施日
            Dim ymdJ As String = Util.checkDBNullValue(rs.Fields("YmdJ").Value)
            If System.Text.RegularExpressions.Regex.IsMatch(ymdJ, "[12]\d\d\d/\d\d/\d\d") Then
                '西暦の場合
                DirectCast(JPanel.Controls("J" & gyo & "YmdBox"), ymdBox.ymdBox).setADStr(ymdJ)
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(ymdJ, "[A-Z]\d\d/\d\d/\d\d") Then
                '和暦の場合
                DirectCast(JPanel.Controls("J" & gyo & "YmdBox"), ymdBox.ymdBox).setWarekiStr(ymdJ)
            End If
            'リスク
            dgvScreening(gyo + 1, 0).Value = Util.checkDBNullValue(rs.Fields("Risk").Value)
            '身長
            dgvScreening(gyo + 1, 1).Value = Util.checkDBNullValue(rs.Fields("Hei").Value)
            '体重
            dgvScreening(gyo + 1, 2).Value = Util.checkDBNullValue(rs.Fields("Wei").Value)
            'BMI
            dgvScreening(gyo + 1, 3).Value = Util.checkDBNullValue(rs.Fields("Bmi1").Value)
            dgvScreening(gyo + 1, 4).Value = Util.checkDBNullValue(rs.Fields("Bmi2").Value)
            '体重減少率
            dgvScreening(gyo + 1, 5).Value = Util.checkDBNullValue(rs.Fields("Gen1").Value)
            dgvScreening(gyo + 1, 6).Value = Util.checkDBNullValue(rs.Fields("Gen2").Value)
            dgvScreening(gyo + 1, 7).Value = Util.checkDBNullValue(rs.Fields("Gen3").Value)
            dgvScreening(gyo + 1, 8).Value = Util.checkDBNullValue(rs.Fields("Gen4").Value)
            '血清ｱﾙﾌﾞﾐﾝ値
            dgvScreening(gyo + 1, 9).Value = Util.checkDBNullValue(rs.Fields("Alb1").Value)
            dgvScreening(gyo + 1, 10).Value = Util.checkDBNullValue(rs.Fields("Alb2").Value)
            dgvScreening(gyo + 1, 11).Value = Util.checkDBNullValue(rs.Fields("Alb3").Value)
            '食事摂取量
            dgvScreening(gyo + 1, 12).Value = Util.checkDBNullValue(rs.Fields("Syoku1").Value)
            dgvScreening(gyo + 1, 13).Value = Util.checkDBNullValue(rs.Fields("Syoku2").Value)
            dgvScreening(gyo + 1, 14).Value = Util.checkDBNullValue(rs.Fields("Syoku3").Value)
            dgvScreening(gyo + 1, 15).Value = Util.checkDBNullValue(rs.Fields("Syoku4").Value)
            '栄養補給法
            dgvScreening(gyo + 1, 16).Value = Util.checkDBNullValue(rs.Fields("Eiyo").Value)
            '褥瘡
            dgvScreening(gyo + 1, 17).Value = Util.checkDBNullValue(rs.Fields("Joku").Value)

            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' 現在年齢算出
    ''' </summary>
    ''' <param name="birthYmd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function calcAge(birthYmd As String, nowYmd As String) As Integer
        Dim doDate As DateTime = New DateTime(CInt(nowYmd.Split("/")(0)), CInt(nowYmd.Split("/")(1)), CInt(nowYmd.Split("/")(2)))
        Dim birthDate As DateTime = New DateTime(CInt(birthYmd.Split("/")(0)), CInt(birthYmd.Split("/")(1)), CInt(birthYmd.Split("/")(2)))
        Dim age As Integer = doDate.Year - birthDate.Year
        '誕生日がまだ来ていなければ、1引く
        If doDate.Month < birthDate.Month OrElse (doDate.Month = birthDate.Month AndAlso doDate.Day < birthDate.Day) Then
            age -= 1
        End If
        Return age
    End Function

    ''' <summary>
    ''' 履歴リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadHistoryList()
        historyListBox.Items.Clear()
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select distinct Ymd from Dat0 where Nam='" & selectedResidentName & "' order by Ymd Desc"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim wareki As String = Util.convADStrToWarekiStr(Util.checkDBNullValue(rs.Fields("Ymd").Value))
            historyListBox.Items.Add(wareki)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' dgv体重推移CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvWeightChange_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvWeightChange.CellPainting
        '行ヘッダーかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                weightChangeRowHeaderText(e.RowIndex), _
                New Font("ＭＳ Ｐゴシック", 8), _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' クリアボタン（右）クリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearRight_Click(sender As System.Object, e As System.EventArgs) Handles btnClearRight.Click
        heightLabel.Text = "0" '身長
        weightLabel.Text = "0" '体重
        bmiLabel.Text = "0" 'BMI
        bmiKanjiLabel.Text = ""
        keikotutyoLabel.Text = "0" '脛骨長
        keikotuTextBox.Text = ""
        hizatakaLabel.Text = "0" '膝高
        hizatakaTextBox.Text = ""
        idealWeightLabel.Text = "0" '理想体重
        goalBmiTextBox.Text = ""
        idealKcalLabel.Text = "0" 'エネルギー量（理想）
        bee1Label.Text = "0" 'BEE
        katudo1TextBox.Text = "1.2" '活動係数
        stress1TextBox.Text = "1" 'ｽﾄﾚｽ係数
        kaizen1TextBox.Text = "1" '改善係数
        idealProtein1Label.Text = "0" 'たん白質(理想)1
        idealProtein2Label.Text = "0" 'たん白質(理想)2
        necessaryKcalLabel.Text = "0" 'エネルギー量1
        bee2Label.Text = "0" 'BEE
        katudo2TextBox.Text = "1.2" '活動係数
        stress2TextBox.Text = "1" 'ストレス係数
        kaizen2TextBox.Text = "1" '改善係数
        necessaryProtein1Label.Text = "0" 'たん白質(必要)1
        necessaryProtein2Label.Text = "0" 'たん白質(必要)2
        sisituLabel.Text = "0" '脂質
        workedOutPercent1TextBox.Text = "20"
        tosituLabel.Text = "0" '糖質
        workedOutPercent2TextBox.Text = "60"
        seniLabel.Text = "0" '食物繊維
        waterLabel.Text = "0" '水分
        albTextBox.Text = "" '血清Alb
        nutritionTextBox.Text = "" '栄養補給法
        intakeTextBox.Text = "" '食事摂取量
        decubitusTextBox.Text = "" '褥瘡
        '体重推移
        For Each row As DataGridViewRow In dgvWeightChange.Rows
            For i As Integer = 0 To row.Cells.Count - 1
                row.Cells(i).Value = ""
            Next
        Next

    End Sub

    ''' <summary>
    ''' 履歴リスト値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub historyListBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles historyListBox.SelectedValueChanged
        If IsNothing(historyListBox.SelectedItem) Then
            Return
        End If
        Dim ymd As String = Util.convWarekiStrToADStr(historyListBox.Text)
        displayScreening(ymd)
    End Sub

    Private Sub dgvScreening_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvScreening.CellPainting
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

    Private Sub JYmdBox_keyDownEnterOrDown(sender As Object, e As System.EventArgs) Handles J1YmdBox.keyDownEnterOrDown, J2YmdBox.keyDownEnterOrDown, J3YmdBox.keyDownEnterOrDown, J4YmdBox.keyDownEnterOrDown
        Dim number As Integer = CInt(CType(sender, ymdBox.ymdBox).Name.Substring(1, 1))
        dgvScreening.CurrentCell = dgvScreening(number + 1, 0)
        dgvScreening.BeginEdit(True)
        dgvScreening.EndEdit()
        dgvScreening.CurrentCell.Selected = True
    End Sub

    Private Sub dgvTokki_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTokki.CellEnter
        If canCellEnter Then
            dgvTokki.BeginEdit(False)
        End If
    End Sub

    ''' <summary>
    ''' クリアボタン（左）クリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Dim selectedNumText As String = clearComboBox.Text
        Dim targetColumnIndex As Integer
        If selectedNumText = "Ⅰ" Then
            targetColumnIndex = 2
        ElseIf selectedNumText = "Ⅱ" Then
            targetColumnIndex = 3
        ElseIf selectedNumText = "Ⅲ" Then
            targetColumnIndex = 4
        ElseIf selectedNumText = "Ⅳ" Then
            targetColumnIndex = 5
        Else
            targetColumnIndex = 0
        End If

        If targetColumnIndex = 0 Then
            '全てクリア
            clearScreening()
        Else
            '対象の列のみクリア
            DirectCast(JPanel.Controls("J" & (targetColumnIndex - 1) & "YmdBox"), ymdBox.ymdBox).clearText()
            For Each row As DataGridViewRow In dgvScreening.Rows
                row.Cells(targetColumnIndex).Value = ""
            Next
        End If
    End Sub

    ''' <summary>
    ''' 呼び出しボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCall_Click(sender As System.Object, e As System.EventArgs) Handles btnCall.Click
        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Dat11 where Nam='" & selectedResidentName & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            '実施日
            Dim ymd As String = Util.checkDBNullValue(rs.Fields("Ymd").Value)
            ymd = ymd.Substring(0, 10)
            JYmdBox.setADStr(ymd)

            'ラベル部分
            '年齢
            ageLabel.Text = Util.checkDBNullValue(rs.Fields("Age").Value)
            '身長
            heightLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl0").Value)
            '体重
            weightLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl1").Value)
            'BMI
            bmiLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl2").Value)
            '脛骨長
            keikotutyoLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl3").Value)
            '膝高
            hizatakaLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl4").Value)
            '理想体重
            idealWeightLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl5").Value)
            'エネルギー量（理想）
            idealKcalLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl6").Value)
            'BEE（理想）
            bee1Label.Text = Util.checkDBNullValue(rs.Fields("Lbl7").Value)
            'たん白質（理想）
            idealProtein1Label.Text = Util.checkDBNullValue(rs.Fields("Lbl8").Value)
            idealProtein2Label.Text = Util.checkDBNullValue(rs.Fields("Lbl9").Value)
            'エネルギー量（必要）
            necessaryKcalLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl10").Value)
            'BEE（必要）
            bee2Label.Text = Util.checkDBNullValue(rs.Fields("Lbl11").Value)
            'たん白質（必要）
            necessaryProtein1Label.Text = Util.checkDBNullValue(rs.Fields("Lbl12").Value)
            necessaryProtein2Label.Text = Util.checkDBNullValue(rs.Fields("Lbl13").Value)
            '脂質
            sisituLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl14").Value)
            '糖質
            tosituLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl15").Value)
            '食物繊維
            seniLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl16").Value)
            '水分
            waterLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl17").Value)
            'BMI（漢字）
            bmiKanjiLabel.Text = Util.checkDBNullValue(rs.Fields("Lbl18").Value)

            'テキストボックス部分
            '脛骨長
            keikotuTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt0").Value)
            '膝高
            hizatakaTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt1").Value)
            '理想体重(目標BMI)
            goalBmiTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt2").Value)
            '活動係数（理想）
            katudo1TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt3").Value)
            'ｽﾄﾚｽ係数（理想）
            stress1TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt4").Value)
            '改善係数（理想）
            kaizen1TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt5").Value)
            '活動係数（必要）
            katudo2TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt6").Value)
            'ｽﾄﾚｽ係数（必要）
            stress2TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt7").Value)
            '改善係数（必要）
            kaizen2TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt8").Value)
            '算出率1
            workedOutPercent1TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt9").Value)
            '算出率2
            workedOutPercent2TextBox.Text = Util.checkDBNullValue(rs.Fields("Txt10").Value)
            '血清Alb
            albTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt11").Value)
            '食事摂取量
            intakeTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt12").Value)
            '栄養補給法
            nutritionTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt13").Value)
            '褥瘡
            decubitusTextBox.Text = Util.checkDBNullValue(rs.Fields("Txt14").Value)

            '体重推移部分
            '過去の体重
            dgvWeightChange(0, 0).Value = Util.checkDBNullValue(rs.Fields("Tai1").Value)
            dgvWeightChange(1, 0).Value = Util.checkDBNullValue(rs.Fields("Tai2").Value)
            dgvWeightChange(2, 0).Value = Util.checkDBNullValue(rs.Fields("Tai3").Value)
            dgvWeightChange(3, 0).Value = Util.checkDBNullValue(rs.Fields("Tai4").Value)
            dgvWeightChange(4, 0).Value = Util.checkDBNullValue(rs.Fields("Tai5").Value)
            dgvWeightChange(5, 0).Value = Util.checkDBNullValue(rs.Fields("Tai6").Value)
            '体重差
            dgvWeightChange(0, 1).Value = Util.checkDBNullValue(rs.Fields("Tai7").Value)
            dgvWeightChange(1, 1).Value = Util.checkDBNullValue(rs.Fields("Tai8").Value)
            dgvWeightChange(2, 1).Value = Util.checkDBNullValue(rs.Fields("Tai9").Value)
            dgvWeightChange(3, 1).Value = Util.checkDBNullValue(rs.Fields("Tai10").Value)
            dgvWeightChange(4, 1).Value = Util.checkDBNullValue(rs.Fields("Tai11").Value)
            dgvWeightChange(5, 1).Value = Util.checkDBNullValue(rs.Fields("Tai12").Value)
            '体重減少率
            dgvWeightChange(0, 2).Value = Util.checkDBNullValue(rs.Fields("Tai13").Value)
            dgvWeightChange(1, 2).Value = Util.checkDBNullValue(rs.Fields("Tai14").Value)
            dgvWeightChange(2, 2).Value = Util.checkDBNullValue(rs.Fields("Tai15").Value)
            dgvWeightChange(3, 2).Value = Util.checkDBNullValue(rs.Fields("Tai16").Value)
            dgvWeightChange(4, 2).Value = Util.checkDBNullValue(rs.Fields("Tai17").Value)
            dgvWeightChange(5, 2).Value = Util.checkDBNullValue(rs.Fields("Tai18").Value)
            '測定日
            dgvWeightChange(0, 3).Value = Util.checkDBNullValue(rs.Fields("Tai19").Value)
            dgvWeightChange(1, 3).Value = Util.checkDBNullValue(rs.Fields("Tai20").Value)
            dgvWeightChange(2, 3).Value = Util.checkDBNullValue(rs.Fields("Tai21").Value)
            dgvWeightChange(3, 3).Value = Util.checkDBNullValue(rs.Fields("Tai22").Value)
            dgvWeightChange(4, 3).Value = Util.checkDBNullValue(rs.Fields("Tai23").Value)
            dgvWeightChange(5, 3).Value = Util.checkDBNullValue(rs.Fields("Tai24").Value)

        Else
            MsgBox("保存情報がありません。", MsgBoxStyle.Information)
        End If
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' dgv体重CellFormattingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvWeight_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvWeight.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then
            Dim ymd As String = e.Value & "/01"
            Dim wareki As String = Util.convADStrToWarekiStr(ymd)
            e.Value = wareki.Substring(0, 6)
            e.FormattingApplied = True
        End If
    End Sub

    ''' <summary>
    ''' dgv体重セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvWeight_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvWeight.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim ym As String = Util.checkDBNullValue(dgvWeight("Ym", e.RowIndex).FormattedValue) '年月
            Dim weight As String = Util.checkDBNullValue(dgvWeight("Weight", e.RowIndex).Value) '体重
            If weight = "" Then
                MsgBox("体重が選択されていません。", MsgBoxStyle.Exclamation)
            End If

            selectedYm = Util.checkDBNullValue(dgvWeight("Ym", e.RowIndex).Value)

            'ラベルにセット
            heightLabel.Text = heightMLabel.Text '身長
            weightLabel.Text = weight '体重
            baseValueGroupBox.Text = "基準値　" & ym

            '実施日ボックスにフォーカス
            JYmdBox.Focus()
        End If
    End Sub

    ''' <summary>
    ''' 保存ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim height As String = heightLabel.Text '身長
        Dim weight As String = weightLabel.Text '体重

        '身長、体重入力チェック
        If height = "0" OrElse height = "" OrElse weight = "0" OrElse weight = "" Then
            MsgBox("基準値：身長＆体重を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        '登録処理
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Dat11 where Nam='" & selectedResidentName & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            rs.AddNew()
        Else
            Dim result As DialogResult = MessageBox.Show("上書き保存して宜しいですか？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result <> Windows.Forms.DialogResult.Yes Then
                rs.Close()
                cn.Close()
                Return
            End If
        End If
        '名前
        rs.Fields("Nam").Value = selectedResidentName
        '実施日
        rs.Fields("Ymd").Value = JYmdBox.getADStr()
        '年齢
        rs.Fields("Age").Value = ageLabel.Text

        'ラベル部分
        '身長
        rs.Fields("Lbl0").Value = heightLabel.Text
        '体重
        rs.Fields("Lbl1").Value = weightLabel.Text
        'BMI
        rs.Fields("Lbl2").Value = bmiLabel.Text
        '脛骨長
        rs.Fields("Lbl3").Value = keikotutyoLabel.Text
        '膝高
        rs.Fields("Lbl4").Value = hizatakaLabel.Text
        '理想体重
        rs.Fields("Lbl5").Value = idealWeightLabel.Text
        'エネルギー量（理想）
        rs.Fields("Lbl6").Value = idealKcalLabel.Text
        'BEE（理想）
        rs.Fields("Lbl7").Value = bee1Label.Text
        'たん白質（理想）
        rs.Fields("Lbl8").Value = idealProtein1Label.Text
        rs.Fields("Lbl9").Value = idealProtein2Label.Text
        'エネルギー量（必要）
        rs.Fields("Lbl10").Value = necessaryKcalLabel.Text
        'BEE（必要）
        rs.Fields("Lbl11").Value = bee2Label.Text
        'たん白質（必要）
        rs.Fields("Lbl12").Value = necessaryProtein1Label.Text
        rs.Fields("Lbl13").Value = necessaryProtein2Label.Text
        '脂質
        rs.Fields("Lbl14").Value = sisituLabel.Text
        '糖質
        rs.Fields("Lbl15").Value = tosituLabel.Text
        '食物繊維
        rs.Fields("Lbl16").Value = seniLabel.Text
        '水分
        rs.Fields("Lbl17").Value = waterLabel.Text
        'BMI（漢字）
        rs.Fields("Lbl18").Value = bmiKanjiLabel.Text

        'テキスト部分
        '脛骨長
        rs.Fields("Txt0").Value = keikotuTextBox.Text
        '膝高
        rs.Fields("Txt1").Value = hizatakaTextBox.Text
        '理想体重(目標BMI)
        rs.Fields("Txt2").Value = goalBmiTextBox.Text
        '活動係数（理想）
        rs.Fields("Txt3").Value = katudo1TextBox.Text
        'ｽﾄﾚｽ係数（理想）
        rs.Fields("Txt4").Value = stress1TextBox.Text
        '改善係数（理想）
        rs.Fields("Txt5").Value = kaizen1TextBox.Text
        '活動係数（必要）
        rs.Fields("Txt6").Value = katudo2TextBox.Text
        'ｽﾄﾚｽ係数（必要）
        rs.Fields("Txt7").Value = stress2TextBox.Text
        '改善係数（必要）
        rs.Fields("Txt8").Value = kaizen2TextBox.Text
        '算出率1
        rs.Fields("Txt9").Value = workedOutPercent1TextBox.Text
        '算出率2
        rs.Fields("Txt10").Value = workedOutPercent2TextBox.Text
        '血清Alb
        rs.Fields("Txt11").Value = albTextBox.Text
        '食事摂取量
        rs.Fields("Txt12").Value = intakeTextBox.Text
        '栄養補給法
        rs.Fields("Txt13").Value = nutritionTextBox.Text
        '褥瘡
        rs.Fields("Txt14").Value = decubitusTextBox.Text

        '体重推移部分
        '過去の体重
        rs.Fields("Tai1").Value = dgvWeightChange(0, 0).Value
        rs.Fields("Tai2").Value = dgvWeightChange(1, 0).Value
        rs.Fields("Tai3").Value = dgvWeightChange(2, 0).Value
        rs.Fields("Tai4").Value = dgvWeightChange(3, 0).Value
        rs.Fields("Tai5").Value = dgvWeightChange(4, 0).Value
        rs.Fields("Tai6").Value = dgvWeightChange(5, 0).Value
        '体重差
        rs.Fields("Tai7").Value = dgvWeightChange(0, 1).Value
        rs.Fields("Tai8").Value = dgvWeightChange(1, 1).Value
        rs.Fields("Tai9").Value = dgvWeightChange(2, 1).Value
        rs.Fields("Tai10").Value = dgvWeightChange(3, 1).Value
        rs.Fields("Tai11").Value = dgvWeightChange(4, 1).Value
        rs.Fields("Tai12").Value = dgvWeightChange(5, 1).Value
        '体重減少率
        rs.Fields("Tai13").Value = dgvWeightChange(0, 2).Value
        rs.Fields("Tai14").Value = dgvWeightChange(1, 2).Value
        rs.Fields("Tai15").Value = dgvWeightChange(2, 2).Value
        rs.Fields("Tai16").Value = dgvWeightChange(3, 2).Value
        rs.Fields("Tai17").Value = dgvWeightChange(4, 2).Value
        rs.Fields("Tai18").Value = dgvWeightChange(5, 2).Value
        '測定日
        rs.Fields("Tai19").Value = dgvWeightChange(0, 3).Value
        rs.Fields("Tai20").Value = dgvWeightChange(1, 3).Value
        rs.Fields("Tai21").Value = dgvWeightChange(2, 3).Value
        rs.Fields("Tai22").Value = dgvWeightChange(3, 3).Value
        rs.Fields("Tai23").Value = dgvWeightChange(4, 3).Value
        rs.Fields("Tai24").Value = dgvWeightChange(5, 3).Value

        rs.Update()
        rs.Close()
        cn.Close()

    End Sub

    ''' <summary>
    ''' 算出ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCalc_Click(sender As System.Object, e As System.EventArgs) Handles btnCalc.Click
        '身長、体重入力チェック
        If heightLabel.Text = "0" OrElse heightLabel.Text = "" OrElse weightLabel.Text = "0" OrElse weightLabel.Text = "" Then
            MsgBox("基準値：身長＆体重を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        '各テキストボックスチェック
        For Each tb As TextBox In {keikotuTextBox, hizatakaTextBox, goalBmiTextBox, katudo1TextBox, stress1TextBox, kaizen1TextBox, katudo2TextBox, stress2TextBox, kaizen2TextBox, albTextBox, intakeTextBox}
            If Not checkTextBoxInputNum(tb) Then
                tb.Focus()
                MsgBox("数値を入力して下さい", MsgBoxStyle.Exclamation)
                Return
            End If
        Next

        '身長(cm),身長(m),体重(kg)
        Dim heightCm As Double = heightLabel.Text
        Dim height As Double = heightLabel.Text / 100
        Dim weight As Double = weightLabel.Text

        '年齢
        Dim age As Double = calcAge(selectedResidentBirth, JYmdBox.getADStr())
        ageLabel.Text = age

        'BMI kg /(m * m)
        bmiLabel.Text = roundFormat(weight / (height * height), 1)
        If bmiLabel.Text < 18.5 Then
            bmiKanjiLabel.Text = "中"
        Else
            bmiKanjiLabel.Text = "低"
        End If

        '脛骨長 3.23 * 入力数値 + 49.6
        keikotutyoLabel.Text = roundFormat(3.23 * keikotuTextBox.Text + 49.6, 1)

        '膝高
        If selectedResidentSex = "1" Then
            '男 64.02 + (入力数値 * 2.12) - (年齢 * 0.07)
            hizatakaLabel.Text = roundFormat(64.02 + (hizatakaTextBox.Text * 2.12) - (age * 0.07), 1)
        ElseIf selectedResidentSex = "2" Then
            '女 77.88 + (入力数値 * 1.77) - (年齢 * 0.1)
            hizatakaLabel.Text = roundFormat(77.88 + (hizatakaTextBox.Text * 1.77) - (age * 0.1), 1)
        End If

        '理想体重
        idealWeightLabel.Text = roundFormat(goalBmiTextBox.Text * (height * height), 1)

        '標準体重当たり(理想)
        'BEE
        If selectedResidentSex = "1" Then
            '男 66.5 + (13.75 * 理想体重) + (5 * 身長) - (6.75 * 年齢)
            bee1Label.Text = Math.Round(66.5 + (13.75 * idealWeightLabel.Text) + (5 * heightCm) - (6.75 * age), 0)
        ElseIf selectedResidentSex = "2" Then
            '女 665.14 + (9.56 * 理想体重) + (1.85 * 身長) - (4.68 * 年齢)
            bee1Label.Text = Math.Round(665.14 + (9.56 * idealWeightLabel.Text) + (1.85 * heightCm) - (4.68 * age), 0)
        End If
        'エネルギー量
        idealKcalLabel.Text = Math.Round(bee1Label.Text * katudo1TextBox.Text * stress1TextBox.Text * kaizen1TextBox.Text, 0)
        'たん白質
        idealProtein1Label.Text = roundFormat(idealWeightLabel.Text * 1.3, 1)
        idealProtein2Label.Text = roundFormat(idealWeightLabel.Text * 1.13, 1)

        '現状体重当たり（必要）
        'BEE
        If selectedResidentSex = "1" Then
            '男 66.5 + (13.75 * 基準体重) + (5 * 身長) - (6.75 * 年齢)
            bee2Label.Text = Math.Round(66.5 + (13.75 * weightLabel.Text) + (5 * heightCm) - (6.75 * age), 0)
        ElseIf selectedResidentSex = "2" Then
            '女 665.14 + (9.56 * 基準体重) + (1.85 * 身長) - (4.68 * 年齢)
            bee2Label.Text = Math.Round(665.14 + (9.56 * weightLabel.Text) + (1.85 * heightCm) - (4.68 * age), 0)
        End If
        'エネルギー量
        necessaryKcalLabel.Text = Math.Round(bee2Label.Text * katudo2TextBox.Text * stress2TextBox.Text * kaizen2TextBox.Text, 0)
        'たん白質
        necessaryProtein1Label.Text = roundFormat(weight * 1.3, 1)
        necessaryProtein2Label.Text = roundFormat(weight * 1.13, 1)
        '脂質
        sisituLabel.Text = roundFormat(necessaryKcalLabel.Text * 0.2 / 9, 1)
        '糖質
        tosituLabel.Text = roundFormat(necessaryKcalLabel.Text * 0.65 / 4, 1)
        '食物繊維
        seniLabel.Text = roundFormat(necessaryKcalLabel.Text / 100, 1)
        '水分
        If age >= 66 Then
            waterLabel.Text = Math.Round(weight * 30, 1)
        ElseIf age >= 56 Then
            waterLabel.Text = Math.Round(weight * 30, 1)
        Else
            waterLabel.Text = Math.Round(weight * 35, 1)
        End If

        '体重推移部分
        For Each row As DataGridViewRow In dgvWeightChange.Rows '内容クリア
            For i As Integer = 0 To row.Cells.Count - 1
                row.Cells(i).Value = ""
            Next
        Next
        If selectedYm <> "" Then
            Dim y As Integer = CInt(selectedYm.Split("/")(0))
            Dim m As Integer = CInt(selectedYm.Split("/")(1))
            Dim d As Integer = 1
            Dim dt As New DateTime(y, m, 1)
            For i As Integer = 1 To 6
                Dim ymStr As String = dt.AddMonths(-i).ToString("yyyy/MM")
                For Each row As DataGridViewRow In dgvWeight.Rows
                    If Util.checkDBNullValue(row.Cells("Ym").Value) = ymStr Then
                        Dim prevWeight As Double = If(Util.checkDBNullValue(row.Cells("Weight").Value) = "", -1, Util.checkDBNullValue(row.Cells("Weight").Value))
                        If prevWeight <> -1 Then
                            dgvWeightChange(i - 1, 0).Value = roundFormat(prevWeight, 1) '過去の体重
                            dgvWeightChange(i - 1, 1).Value = roundFormat(prevWeight - weight, 1) '体重差
                            dgvWeightChange(i - 1, 2).Value = roundFormat((1 - (weight / prevWeight)) * 100, 1) '体重減少率
                            dgvWeightChange(i - 1, 3).Value = Util.checkDBNullValue(row.Cells("Ym").FormattedValue) '測定日
                        End If
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    ''' <summary>
    ''' 数値フォーマット
    ''' </summary>
    ''' <param name="calcVal"></param>
    ''' <param name="digits"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function roundFormat(calcVal As Double, digits As Integer) As String
        Dim result As String = Math.Round(calcVal, digits, MidpointRounding.AwayFromZero).ToString()
        If result.IndexOf(".") = -1 Then
            result = result & ".0"
        End If
        Return result
    End Function

    ''' <summary>
    ''' テキストが数値であるか判定
    ''' </summary>
    ''' <param name="tb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkTextBoxInputNum(tb As TextBox) As Boolean
        If tb.Text = "" Then
            tb.Text = "0"
        End If

        '整数または小数の場合はtrue
        If System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "^\d+$") OrElse System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "^\d+(\.\d+)?$") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class