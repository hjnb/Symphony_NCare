Public Class アセモニ

    '選択されている入居者名
    Private selectedResidentName As String

    'クリア番号
    Private clearNumArray() As String = {"1", "2", "3", "4"}

    '記入者氏名
    Private tantoArray() As String = {"澤田　美佳"}

    '履歴リスト値変更制御用フラグ
    Private canSelectChage As Boolean = False

    '項目列セルスタイル
    Private itemColumnCellStyle As DataGridViewCellStyle

    '単位列セルスタイル
    Private unitColumnCellStyle As DataGridViewCellStyle

    '入力セルスタイル
    Private inputCellStyle As DataGridViewCellStyle

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="selectedName"></param>
    ''' <remarks></remarks>
    Public Sub New(selectedName As String)
        InitializeComponent()

        selectedResidentName = selectedName
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub アセモニ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'セルスタイル定義
        createCellStyles()

        'データグリッドビュー初期設定
        initDgvSub()
        initDgvAsses()

        '名前設定
        namArea.Text = selectedResidentName

        '履歴リストセット
        setHistoryList()

        'クリアコンボボックス項目セット
        clearComboBox.Items.AddRange(clearNumArray)

        '記入者コンボボックス項目セット
        tantoComboBox.Items.AddRange(tantoArray)
        tantoComboBox.ImeMode = Windows.Forms.ImeMode.Hiragana

        '現在日付設定
        createYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))
    End Sub

    ''' <summary>
    ''' セルスタイル定義
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createCellStyles()
        '項目列
        itemColumnCellStyle = New DataGridViewCellStyle()
        With itemColumnCellStyle
            .BackColor = Color.FromKnownColor(KnownColor.Control)
            .SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
            .SelectionForeColor = Color.Black
        End With

        '単位列
        unitColumnCellStyle = New DataGridViewCellStyle()
        With unitColumnCellStyle
            .BackColor = Color.FromArgb(194, 194, 252)
            .SelectionBackColor = Color.FromArgb(194, 194, 252)
            .SelectionForeColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        'inputCellStyle = New DataGridViewCellStyle()
    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        '記入者
        tantoComboBox.Text = ""

        'dgvSub
        dgvSub(0, 0).Value = ""

        'dgvAsses
        For Each row As DataGridViewRow In dgvAsses.Rows
            row.Cells("Date1").Value = ""
            row.Cells("Date2").Value = ""
            row.Cells("Date3").Value = ""
            row.Cells("Date4").Value = ""
        Next

        '実施日
        date1YmdBox.clearText()
        date2YmdBox.clearText()
        date3YmdBox.clearText()
        date4YmdBox.clearText()
    End Sub

    ''' <summary>
    ''' データグリッドビューSubの初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvSub()
        Util.EnableDoubleBuffering(dgvSub)

        With dgvSub
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.None
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'クリック時に行選択
            .RowHeadersVisible = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 18
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ImeMode = Windows.Forms.ImeMode.Hiragana
            .EditMode = DataGridViewEditMode.EditOnEnter
        End With

        '空行追加等
        Dim dt As New DataTable()
        dt.Columns.Add("Sub", Type.GetType("System.String"))
        dt.Columns.Add("Text", Type.GetType("System.String"))
        Dim row As DataRow = dt.NewRow()
        row(0) = ""
        row(1) = ""
        dt.Rows.Add(row)
        dgvSub.DataSource = dt

        '幅設定等
        With dgvSub
            With .Columns("Sub")
                .Width = 430
                .HeaderText = "身体状況、栄養・食事に関する意向"
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Text")
                .Width = 80
                .HeaderText = ""
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
    End Sub

    ''' <summary>
    ''' データグリッドビューアセモニの初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvAsses()
        Util.EnableDoubleBuffering(dgvAsses)

        With dgvAsses
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect 'クリック時に行選択
            .RowHeadersVisible = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowTemplate.Height = 15
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .EditMode = DataGridViewEditMode.EditOnEnter
        End With

        '空行追加等
        Dim dt As New DataTable()
        dt.Columns.Add("Item", Type.GetType("System.String"))
        dt.Columns.Add("Unit", Type.GetType("System.String"))
        dt.Columns.Add("Date1", Type.GetType("System.String"))
        dt.Columns.Add("Date2", Type.GetType("System.String"))
        dt.Columns.Add("Date3", Type.GetType("System.String"))
        dt.Columns.Add("Date4", Type.GetType("System.String"))
        For i As Integer = 0 To 46
            Dim row As DataRow = dt.NewRow()
            row(0) = ""
            row(1) = ""
            row(2) = ""
            row(3) = ""
            row(4) = ""
            row(5) = ""
            dt.Rows.Add(row)
        Next

        '項目列
        dt.Rows(0).Item("Item") = "本人の意欲(1)"
        dt.Rows(1).Item("Item") = "(健康感、生活機能、身体機能等)"
        dt.Rows(2).Item("Item") = "体重(Kg)"
        dt.Rows(3).Item("Item") = "BMI(Kg/㎡)"
        dt.Rows(4).Item("Item") = ""
        dt.Rows(5).Item("Item") = "3%以上の体重減少"
        dt.Rows(6).Item("Item") = ""
        dt.Rows(7).Item("Item") = "血清アルブミン値"
        dt.Rows(8).Item("Item") = "その他"
        dt.Rows(9).Item("Item") = "食欲・食事の満足度(2)"
        dt.Rows(10).Item("Item") = " 食事摂取量"
        dt.Rows(11).Item("Item") = " 主食の摂取量"
        dt.Rows(12).Item("Item") = " 副食の摂取量"
        dt.Rows(13).Item("Item") = " その他(補助食品、経腸・静脈"
        dt.Rows(14).Item("Item") = " 栄養など)"
        dt.Rows(15).Item("Item") = "必要栄養量(エネルギー・たんぱく"
        dt.Rows(16).Item("Item") = "質など)"
        dt.Rows(17).Item("Item") = ""
        dt.Rows(18).Item("Item") = ""
        dt.Rows(19).Item("Item") = "食事の留意事項の有無"
        dt.Rows(20).Item("Item") = "(療養食の指示、食事形態、嗜好、"
        dt.Rows(21).Item("Item") = "禁忌、アレルギーなど)"
        dt.Rows(22).Item("Item") = ""
        dt.Rows(23).Item("Item") = "その他(食習慣、生活習慣、食行"
        dt.Rows(24).Item("Item") = "動などの留意事項など)"
        dt.Rows(25).Item("Item") = ""
        dt.Rows(26).Item("Item") = ""
        dt.Rows(27).Item("Item") = "多職種による栄養ケアの課題(3)"
        dt.Rows(28).Item("Item") = "①褥瘡②口腔及び摂食・嚥下"
        dt.Rows(29).Item("Item") = "③吐気・嘔吐④下痢⑤便秘"
        dt.Rows(30).Item("Item") = "⑥浮腫⑦脱水⑧感染・発熱"
        dt.Rows(31).Item("Item") = "⑨経腸・静脈栄養⑩生活機能低下"
        dt.Rows(32).Item("Item") = "⑪閉じこもり⑫うつ⑬認知機能"
        dt.Rows(33).Item("Item") = "⑭医薬品⑮その他"
        dt.Rows(34).Item("Item") = "特記事項"
        dt.Rows(35).Item("Item") = "問題点(2)"
        dt.Rows(36).Item("Item") = ""
        dt.Rows(37).Item("Item") = "①食事摂取・栄養補給の状況"
        dt.Rows(38).Item("Item") = "(補助食品、経腸・静脈栄養など)"
        dt.Rows(39).Item("Item") = ""
        dt.Rows(40).Item("Item") = "②身体機能・臨床症状"
        dt.Rows(41).Item("Item") = "(体重、摂食・嚥下機能、検査"
        dt.Rows(42).Item("Item") = "データなど)"
        dt.Rows(43).Item("Item") = "③習慣・周辺環境(食・生活習慣、"
        dt.Rows(44).Item("Item") = "意欲、購買など"
        dt.Rows(45).Item("Item") = "④その他"
        dt.Rows(46).Item("Item") = "　　　　　　総　合　評　価"

        '単位列
        dt.Rows(0).Item("Unit") = "1-5"
        dt.Rows(1).Item("Unit") = ""
        dt.Rows(2).Item("Unit") = "Kg"
        dt.Rows(3).Item("Unit") = "Kg/㎡"
        dt.Rows(4).Item("Unit") = "1-2"
        dt.Rows(5).Item("Unit") = "Kg"
        dt.Rows(6).Item("Unit") = "ヶ月"
        dt.Rows(7).Item("Unit") = "g/dl"
        dt.Rows(8).Item("Unit") = ""
        dt.Rows(9).Item("Unit") = "1-5"
        dt.Rows(10).Item("Unit") = "%"
        dt.Rows(11).Item("Unit") = "%"
        dt.Rows(12).Item("Unit") = "%"
        dt.Rows(13).Item("Unit") = ""
        dt.Rows(14).Item("Unit") = ""
        dt.Rows(15).Item("Unit") = "Kcal"
        dt.Rows(16).Item("Unit") = "g"
        dt.Rows(17).Item("Unit") = ""
        dt.Rows(18).Item("Unit") = ""
        dt.Rows(19).Item("Unit") = "1-2"
        dt.Rows(20).Item("Unit") = ""
        dt.Rows(21).Item("Unit") = ""
        dt.Rows(22).Item("Unit") = ""
        dt.Rows(23).Item("Unit") = ""
        dt.Rows(24).Item("Unit") = ""
        dt.Rows(25).Item("Unit") = ""
        dt.Rows(26).Item("Unit") = ""
        dt.Rows(27).Item("Unit") = "1-2"
        dt.Rows(28).Item("Unit") = ""
        dt.Rows(29).Item("Unit") = ""
        dt.Rows(30).Item("Unit") = ""
        dt.Rows(31).Item("Unit") = ""
        dt.Rows(32).Item("Unit") = ""
        dt.Rows(33).Item("Unit") = ""
        dt.Rows(34).Item("Unit") = ""
        dt.Rows(35).Item("Unit") = "1-2"
        dt.Rows(36).Item("Unit") = "1-4"
        dt.Rows(37).Item("Unit") = ""
        dt.Rows(38).Item("Unit") = ""
        dt.Rows(39).Item("Unit") = ""
        dt.Rows(40).Item("Unit") = ""
        dt.Rows(41).Item("Unit") = ""
        dt.Rows(42).Item("Unit") = ""
        dt.Rows(43).Item("Unit") = ""
        dt.Rows(44).Item("Unit") = ""
        dt.Rows(45).Item("Unit") = ""
        dt.Rows(46).Item("Unit") = "1-4"

        dgvAsses.DataSource = dt

        '幅設定等
        With dgvAsses
            With .Columns("Item")
                .Width = 180
                .ReadOnly = True
                .DefaultCellStyle = itemColumnCellStyle
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Unit")
                .Width = 61
                .ReadOnly = True
                .DefaultCellStyle = unitColumnCellStyle
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            For i As Integer = 1 To 4
                With .Columns("Date" & i)
                    .Width = 172
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
            Next
        End With
    End Sub

    ''' <summary>
    ''' アセモニデータ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvAsses(selectedYmd As String)
        'クリア
        clearInput()

        'データ取得、表示
        Dim ymd As String = Util.convWarekiStrToADStr(selectedYmd) '西暦ymd
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Asses where Nam='" & selectedResidentName & "' and Ymd='" & ymd & "' order by Gyo"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim gyo As Integer = rs.Fields("Gyo").Value
            '実施日
            DirectCast(datePanel.Controls("date" & gyo & "YmdBox"), ymdBox.ymdBox).setADStr(Util.checkDBNullValue(rs.Fields("JYmd").Value))

            If gyo = 1 Then
                '記入者氏名
                tantoComboBox.Text = Util.checkDBNullValue(rs.Fields("Tanto").Value)

                'Sub
                dgvSub(0, 0).Value = Util.checkDBNullValue(rs.Fields("Sub").Value)
            End If
            '

            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' 履歴リストセット
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setHistoryList()
        canSelectChage = False
        historyListBox.Items.Clear()
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select distinct Ymd from Asses where Nam='" & selectedResidentName & "' order by Ymd Desc"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim adStr As String = Util.checkDBNullValue(rs.Fields("Ymd").Value)
            Dim warekiStr As String = Util.convADStrToWarekiStr(adStr)
            historyListBox.Items.Add(warekiStr)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
        canSelectChage = True
    End Sub

    ''' <summary>
    ''' 履歴リスト値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub historyListBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles historyListBox.SelectedValueChanged
        If canSelectChage Then
            displayDgvAsses(historyListBox.Text)
        End If
    End Sub

    ''' <summary>
    ''' クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Dim targetNum As String = clearComboBox.Text
        If "1" <= targetNum AndAlso targetNum <= "4" Then
            DirectCast(datePanel.Controls("date" & targetNum & "YmdBox"), ymdBox.ymdBox).clearText()
            For Each row As DataGridViewRow In dgvAsses.Rows
                row.Cells("Date" & targetNum).Value = ""
            Next
        Else
            Return
        End If
    End Sub
End Class