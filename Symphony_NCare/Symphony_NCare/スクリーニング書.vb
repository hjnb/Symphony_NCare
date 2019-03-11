Imports System.Data.OleDb

Public Class スクリーニング書

    '選択されている入居者名
    Private selectedResidentName As String

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
            .RowTemplate.Height = 16
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
    ''' 入居者情報表示(ユニット、名前、性別、生年月日、年齢)
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
            Dim birthWareki As String = Util.convADStrToWarekiStr(Util.checkDBNullValue(rs.Fields("Birth").Value))
            Dim sex As String = Util.checkDBNullValue(rs.Fields("Sex").Value)
            Dim age As String = calcAge(Util.checkDBNullValue(rs.Fields("Birth").Value))

            '値セット
            unitLabel.Text = unit & "の家"
            namLabel.Text = selectedResidentName
            kanaLabel.Text = kana
            birthLabel.Text = birthWareki
            ageLabel.Text = age
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
    Private Function calcAge(birthYmd As String) As Integer
        Dim todayYmd As String = Today.ToString("yyyy/MM/dd")
        Dim doDate As DateTime = New DateTime(CInt(todayYmd.Split("/")(0)), CInt(todayYmd.Split("/")(1)), CInt(todayYmd.Split("/")(2)))
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
                e.CellStyle.Font, _
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


        End If
        rs.Close()
        cn.Close()
    End Sub
End Class