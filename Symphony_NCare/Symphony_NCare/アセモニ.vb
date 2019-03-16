Imports System.Text
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop

Public Class アセモニ

    '選択されている入居者名
    Private selectedResidentName As String

    'クリア番号
    Private clearNumArray() As String = {"1", "2", "3", "4"}

    '記入者氏名
    Private tantoArray() As String = {"澤田　美佳"}

    '文字数制限用
    Private Const ASSES_LIMIT_LENGTH_BYTE As Integer = 26
    Private Const SUB_LIMIT_LENGTH_BYTE As Integer = 72

    '履歴リスト値変更制御用フラグ
    Private canSelectChage As Boolean = False

    '項目列セルスタイル
    Private itemColumnCellStyle As DataGridViewCellStyle

    '単位列セルスタイル
    Private unitColumnCellStyle As DataGridViewCellStyle

    '左よせ入力セルスタイル
    Private leftInputCellStyle As DataGridViewCellStyle

    'dateYmdBoxエンターイベント制御用
    Private canYmdBoxEnter As Boolean = False

    '選択列index保持用
    Private selectedColumnIndex As Integer = -1

    'コピーデータ保持用
    Private copyData(47) As String

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
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        '単位列
        unitColumnCellStyle = New DataGridViewCellStyle()
        With unitColumnCellStyle
            .BackColor = Color.FromArgb(194, 194, 252)
            .SelectionBackColor = Color.FromArgb(194, 194, 252)
            .SelectionForeColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        '左よせ文章入力セル
        leftInputCellStyle = New DataGridViewCellStyle()
        With leftInputCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
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
            .Font = New Font("ＭＳ Ｐゴシック", 9)
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
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            .Font = New Font("ＭＳ Ｐゴシック", 9)
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
                .Width = 188
                .ReadOnly = True
                .DefaultCellStyle = itemColumnCellStyle
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Unit")
                .Width = 53
                .ReadOnly = True
                .DefaultCellStyle = unitColumnCellStyle
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            For i As Integer = 1 To 4
                With .Columns("Date" & i)
                    .Width = 168
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
            Next

            '個別にセルスタイル設定
            For i As Integer = 20 To 45
                If i = 27 OrElse i = 35 OrElse i = 36 Then
                    Continue For
                End If
                With .Rows(i)
                    .Cells("Date1").Style = leftInputCellStyle
                    .Cells("Date2").Style = leftInputCellStyle
                    .Cells("Date3").Style = leftInputCellStyle
                    .Cells("Date4").Style = leftInputCellStyle
                End With
            Next
        End With

        '対象設定
        dgvAsses.targetYmdBox1 = date1YmdBox
        dgvAsses.targetYmdBox2 = date2YmdBox
        dgvAsses.targetYmdBox3 = date3YmdBox
        dgvAsses.targetYmdBox4 = date4YmdBox
    End Sub

    ''' <summary>
    ''' アセモニデータ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvAsses(selectedYmd As String)
        canYmdBoxEnter = False

        dgvAsses.CurrentCell = dgvAsses(0, 0)

        'クリア
        clearInput()

        'データ取得、表示
        Dim ymd As String = Util.convWarekiStrToADStr(selectedYmd) '西暦ymd
        createYmdBox.setADStr(ymd) '作成日セット
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
            '意欲
            dgvAsses(gyo - 1 + 2, 0).Value = Util.checkDBNullValue(rs.Fields("Iyoku1").Value)
            dgvAsses(gyo - 1 + 2, 1).Value = Util.checkDBNullValue(rs.Fields("Iyoku2").Value)
            '体重
            dgvAsses(gyo - 1 + 2, 2).Value = convDecimalStr(Util.checkDBNullValue(rs.Fields("Tai").Value))
            'BMI
            dgvAsses(gyo - 1 + 2, 3).Value = convDecimalStr(Util.checkDBNullValue(rs.Fields("Bmi").Value))
            '体重減少
            dgvAsses(gyo - 1 + 2, 4).Value = Util.checkDBNullValue(rs.Fields("Gen1").Value)
            dgvAsses(gyo - 1 + 2, 5).Value = convDecimalStr(Util.checkDBNullValue(rs.Fields("Gen2").Value))
            dgvAsses(gyo - 1 + 2, 6).Value = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Gen3").Value))
            'ｱﾙﾌﾞﾐﾝ
            dgvAsses(gyo - 1 + 2, 7).Value = convDecimalStr(Util.checkDBNullValue(rs.Fields("ALB").Value))
            'その他
            dgvAsses(gyo - 1 + 2, 8).Value = Util.checkDBNullValue(rs.Fields("Hok1").Value)
            '満足度
            dgvAsses(gyo - 1 + 2, 9).Value = Util.checkDBNullValue(rs.Fields("Man").Value)
            '摂取量
            dgvAsses(gyo - 1 + 2, 10).Value = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Ryo1").Value))
            dgvAsses(gyo - 1 + 2, 11).Value = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Ryo2").Value))
            dgvAsses(gyo - 1 + 2, 12).Value = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Ryo3").Value))
            dgvAsses(gyo - 1 + 2, 13).Value = Util.checkDBNullValue(rs.Fields("Hok21").Value)
            dgvAsses(gyo - 1 + 2, 14).Value = Util.checkDBNullValue(rs.Fields("Hok22").Value)
            '栄養量
            dgvAsses(gyo - 1 + 2, 15).Value = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Engy1").Value))
            dgvAsses(gyo - 1 + 2, 16).Value = convDecimalStr(Util.checkDBNullValue(rs.Fields("Engy2").Value))
            dgvAsses(gyo - 1 + 2, 17).Value = Util.checkDBNullValue(rs.Fields("Engy3").Value)
            dgvAsses(gyo - 1 + 2, 18).Value = Util.checkDBNullValue(rs.Fields("Engy4").Value)
            '留意事項
            dgvAsses(gyo - 1 + 2, 19).Value = Util.checkDBNullValue(rs.Fields("Ryui1").Value)
            dgvAsses(gyo - 1 + 2, 20).Value = Util.checkDBNullValue(rs.Fields("Ryui2").Value)
            dgvAsses(gyo - 1 + 2, 21).Value = Util.checkDBNullValue(rs.Fields("Ryui3").Value)
            dgvAsses(gyo - 1 + 2, 22).Value = Util.checkDBNullValue(rs.Fields("Ryui4").Value)
            'その他(食習慣、・・・)
            dgvAsses(gyo - 1 + 2, 23).Value = Util.checkDBNullValue(rs.Fields("Hok31").Value)
            dgvAsses(gyo - 1 + 2, 24).Value = Util.checkDBNullValue(rs.Fields("Hok32").Value)
            dgvAsses(gyo - 1 + 2, 25).Value = Util.checkDBNullValue(rs.Fields("Hok33").Value)
            dgvAsses(gyo - 1 + 2, 26).Value = Util.checkDBNullValue(rs.Fields("Hok34").Value)
            '栄養ケア
            dgvAsses(gyo - 1 + 2, 27).Value = Util.checkDBNullValue(rs.Fields("Care1").Value)
            dgvAsses(gyo - 1 + 2, 28).Value = Util.checkDBNullValue(rs.Fields("Care2").Value)
            dgvAsses(gyo - 1 + 2, 29).Value = Util.checkDBNullValue(rs.Fields("Care3").Value)
            dgvAsses(gyo - 1 + 2, 30).Value = Util.checkDBNullValue(rs.Fields("Care4").Value)
            dgvAsses(gyo - 1 + 2, 31).Value = Util.checkDBNullValue(rs.Fields("Care5").Value)
            dgvAsses(gyo - 1 + 2, 32).Value = Util.checkDBNullValue(rs.Fields("Care6").Value)
            dgvAsses(gyo - 1 + 2, 33).Value = Util.checkDBNullValue(rs.Fields("Care7").Value)
            dgvAsses(gyo - 1 + 2, 34).Value = Util.checkDBNullValue(rs.Fields("Tokki").Value)
            '問題点
            dgvAsses(gyo - 1 + 2, 35).Value = Util.checkDBNullValue(rs.Fields("Mon1").Value)
            dgvAsses(gyo - 1 + 2, 36).Value = Util.checkDBNullValue(rs.Fields("Mon2").Value)
            dgvAsses(gyo - 1 + 2, 37).Value = Util.checkDBNullValue(rs.Fields("Mon3").Value)
            dgvAsses(gyo - 1 + 2, 38).Value = Util.checkDBNullValue(rs.Fields("Mon4").Value)
            dgvAsses(gyo - 1 + 2, 39).Value = Util.checkDBNullValue(rs.Fields("Mon5").Value)
            dgvAsses(gyo - 1 + 2, 40).Value = Util.checkDBNullValue(rs.Fields("Mon6").Value)
            dgvAsses(gyo - 1 + 2, 41).Value = Util.checkDBNullValue(rs.Fields("Mon7").Value)
            dgvAsses(gyo - 1 + 2, 42).Value = Util.checkDBNullValue(rs.Fields("Mon8").Value)
            dgvAsses(gyo - 1 + 2, 43).Value = Util.checkDBNullValue(rs.Fields("Mon9").Value)
            dgvAsses(gyo - 1 + 2, 44).Value = Util.checkDBNullValue(rs.Fields("Mon10").Value)
            dgvAsses(gyo - 1 + 2, 45).Value = Util.checkDBNullValue(rs.Fields("Mon11").Value)
            '総合評価
            dgvAsses(gyo - 1 + 2, 46).Value = Util.checkDBNullValue(rs.Fields("Result").Value)

            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()

        canYmdBoxEnter = True
    End Sub

    Private Function convDecimalStr(numStr As String) As String
        If numStr.IndexOf(".") >= 0 Then
            Return numStr
        Else
            If numStr = "" OrElse numStr = "0" Then
                Return ""
            Else
                Return numStr & ".0"
            End If
        End If
    End Function

    Private Function convZeroToEmpty(numStr As String) As String
        If numStr = "0" Then
            Return ""
        Else
            Return numStr
        End If
    End Function

    Private Function convEmptyToZero(str As String) As String
        If str = "" Then
            Return "0"
        Else
            Return str
        End If
    End Function

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
    ''' 列データクリア
    ''' </summary>
    ''' <param name="columnNum">クリア対象列index</param>
    ''' <remarks></remarks>
    Private Sub clearColumnData(columnNum As Integer)
        DirectCast(datePanel.Controls("date" & columnNum & "YmdBox"), ymdBox.ymdBox).clearText()
        For Each row As DataGridViewRow In dgvAsses.Rows
            row.Cells("Date" & columnNum).Value = ""
        Next
    End Sub

    ''' <summary>
    ''' クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        dgvAsses.CurrentCell = dgvAsses(0, 0)
        Dim targetNum As String = clearComboBox.Text
        If "1" <= targetNum AndAlso targetNum <= "4" Then
            clearColumnData(targetNum)
        Else
            Return
        End If
    End Sub

    ''' <summary>
    ''' コピーボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        dgvAsses.CurrentCell = dgvAsses(0, 0)
        If selectedColumnIndex < 2 Then
            Return
        End If

        'コピー配列内容クリア
        Array.Clear(copyData, 0, copyData.Length)

        '選択列のデータ内容コピー
        copyData(0) = DirectCast(datePanel.Controls("date" & (selectedColumnIndex - 1) & "YmdBox"), ymdBox.ymdBox).getADStr()
        For i As Integer = 0 To 46
            copyData(i + 1) = Util.checkDBNullValue(dgvAsses(selectedColumnIndex, i).Value)
        Next
    End Sub

    ''' <summary>
    ''' 貼り付けボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPaste_Click(sender As System.Object, e As System.EventArgs) Handles btnPaste.Click
        dgvAsses.CurrentCell = dgvAsses(0, 0)
        If selectedColumnIndex < 2 Then
            Return
        End If

        'データクリア
        clearColumnData(selectedColumnIndex - 1)

        'データ貼り付け
        DirectCast(datePanel.Controls("date" & (selectedColumnIndex - 1) & "YmdBox"), ymdBox.ymdBox).setADStr(copyData(0))
        For i As Integer = 0 To 46
            dgvAsses(selectedColumnIndex, i).Value = copyData(i + 1)
        Next
    End Sub

    ''' <summary>
    ''' 実施日ボックスエンターイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dateYmdBox_Enter(sender As Object, e As System.EventArgs) Handles date1YmdBox.Enter, date2YmdBox.Enter, date3YmdBox.Enter, date4YmdBox.Enter
        If canYmdBoxEnter Then
            Dim yb As ymdBox.ymdBox = DirectCast(sender, ymdBox.ymdBox)
            Dim num As Integer = CInt(yb.Name.Substring(4, 1)) + 1
            selectedColumnIndex = num
        End If
    End Sub

    Private Sub dgvAsses_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAsses.CellBeginEdit
        If e.ColumnIndex >= 2 AndAlso (e.RowIndex = 2 OrElse e.RowIndex = 3 OrElse e.RowIndex = 5 OrElse e.RowIndex = 6 OrElse e.RowIndex = 7 OrElse e.RowIndex = 10 OrElse e.RowIndex = 11 OrElse e.RowIndex = 12 OrElse e.RowIndex = 15 OrElse e.RowIndex = 16) Then
            dgvAsses(e.ColumnIndex, e.RowIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub dgvAsses_CellLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsses.CellLeave
        If e.ColumnIndex >= 2 AndAlso (e.RowIndex = 2 OrElse e.RowIndex = 3 OrElse e.RowIndex = 5 OrElse e.RowIndex = 6 OrElse e.RowIndex = 7 OrElse e.RowIndex = 10 OrElse e.RowIndex = 11 OrElse e.RowIndex = 12 OrElse e.RowIndex = 15 OrElse e.RowIndex = 16) Then
            dgvAsses(e.ColumnIndex, e.RowIndex).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    ''' <summary>
    ''' dgvアセモニセルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvAsses_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAsses.CellMouseClick
        selectedColumnIndex = e.ColumnIndex
    End Sub

    ''' <summary>
    ''' dgvSubのセル編集の時のイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSub_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvSub.EditingControlShowing
        Dim editTextBox As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)

        'イベントハンドラを削除、追加
        RemoveHandler editTextBox.KeyPress, AddressOf dgvSubTextBox_KeyPress
        AddHandler editTextBox.KeyPress, AddressOf dgvSubTextBox_KeyPress
    End Sub

    ''' <summary>
    ''' dgvアセモニのセル編集の時のイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvAsses_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvAsses.EditingControlShowing
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            '選択行index
            Dim selectedRowIndex As Integer = dgv.CurrentCell.RowIndex

            '編集のために表示されているテキストボックス取得、設定
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            tb.ImeMode = Windows.Forms.ImeMode.Hiragana
            If selectedRowIndex = 2 OrElse selectedRowIndex = 3 OrElse selectedRowIndex = 5 OrElse selectedRowIndex = 7 OrElse selectedRowIndex = 16 Then
                'kg等のテキストボックス用
                tb.ImeMode = Windows.Forms.ImeMode.Disable
                tb.ContextMenu = New ContextMenu()
                If tb.Text = "" Then
                    tb.Text = "0.0"
                End If
            ElseIf selectedRowIndex = 6 Then
                'ヶ月テキストボックス用
                tb.ImeMode = Windows.Forms.ImeMode.Disable
                tb.ContextMenu = New ContextMenu()
                If tb.Text = "" Then
                    tb.Text = "0"
                End If
            ElseIf selectedRowIndex = 10 OrElse selectedRowIndex = 11 OrElse selectedRowIndex = 12 Then
                '%テキストボックス用
                tb.ImeMode = Windows.Forms.ImeMode.Disable
                tb.ContextMenu = New ContextMenu()
                If tb.Text = "" Then
                    tb.Text = "0"
                End If
            ElseIf selectedRowIndex = 15 Then
                'Kcalテキストボックス用
                tb.ImeMode = Windows.Forms.ImeMode.Disable
                tb.ContextMenu = New ContextMenu()
                If tb.Text = "" Then
                    tb.Text = "0"
                End If
            ElseIf selectedRowIndex = 0 OrElse selectedRowIndex = 4 OrElse selectedRowIndex = 19 OrElse selectedRowIndex = 27 OrElse selectedRowIndex = 35 OrElse selectedRowIndex = 9 OrElse selectedRowIndex = 36 OrElse selectedRowIndex = 46 Then
                tb.ImeMode = Windows.Forms.ImeMode.Off
            End If

            'イベントハンドラを削除
            RemoveHandler tb.KeyDown, AddressOf decimalTextBox_KeyDown
            RemoveHandler tb.KeyDown, AddressOf monthTextBox_KeyDown
            RemoveHandler tb.KeyDown, AddressOf percentTextBox_KeyDown
            RemoveHandler tb.KeyDown, AddressOf kcalTextBox_KeyDown
            RemoveHandler tb.KeyPress, AddressOf dgvAssesTextBox_KeyPress

            '該当行
            If selectedRowIndex = 2 OrElse selectedRowIndex = 3 OrElse selectedRowIndex = 5 OrElse selectedRowIndex = 7 OrElse selectedRowIndex = 16 Then
                'kg等のテキストボックス用
                AddHandler tb.KeyDown, AddressOf decimalTextBox_KeyDown
            ElseIf selectedRowIndex = 6 Then
                'ヶ月テキストボックス用
                AddHandler tb.KeyDown, AddressOf monthTextBox_KeyDown
            ElseIf selectedRowIndex = 10 OrElse selectedRowIndex = 11 OrElse selectedRowIndex = 12 Then
                'パーセントテキストボックス用
                AddHandler tb.KeyDown, AddressOf percentTextBox_KeyDown
            ElseIf selectedRowIndex = 15 Then
                'カロリーテキストボックス用
                AddHandler tb.KeyDown, AddressOf kcalTextBox_KeyDown
            Else
                '通常文章入力テキストボックス用
                AddHandler tb.KeyPress, AddressOf dgvAssesTextBox_KeyPress
            End If
        End If
    End Sub

    ''' <summary>
    ''' kg等のテキストボックス用keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub decimalTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim inputIntStr As String = tb.Text.Split(".")(0) '整数部
        Dim inputDecimalStr As String = tb.Text.Split(".")(1) '小数部
        Dim maxSelectionStart As Integer = tb.Text.Length '最大値
        Dim currentSelectionStart As Integer = tb.SelectionStart '現在選択位置
        Dim decimalPointSelectionStart As Integer = maxSelectionStart - 2 ' 小数点の位置

        If e.KeyCode = Windows.Forms.Keys.Left Then
            'カーソルを左に動かす
            If currentSelectionStart <> 0 Then
                tb.SelectionStart -= 1
                If currentSelectionStart = maxSelectionStart - 1 OrElse currentSelectionStart = maxSelectionStart Then
                    tb.SelectionStart = maxSelectionStart - 2
                    tb.SelectionLength = 0
                Else
                    tb.SelectionLength = 0
                End If
            Else
                If tb.SelectionLength > 0 Then
                    tb.SelectionStart = decimalPointSelectionStart - 1
                    tb.SelectionLength = 0
                End If
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Windows.Forms.Keys.Right Then
            'カーソルを右に動かす
            If tb.SelectionLength > 0 Then
                tb.SelectionStart = decimalPointSelectionStart + 1
                tb.Select(tb.SelectionStart, 1)
            ElseIf currentSelectionStart <> maxSelectionStart Then
                tb.SelectionStart += 1
                If currentSelectionStart = decimalPointSelectionStart Then
                    tb.Select(tb.SelectionStart, 1)
                ElseIf currentSelectionStart = maxSelectionStart - 2 OrElse currentSelectionStart = maxSelectionStart - 1 Then
                    tb.Select(maxSelectionStart - 1, 1)
                End If
            End If
            e.SuppressKeyPress = True
        ElseIf (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) Then
            Dim keyDownChar As String = If(Keys.NumPad0 <= e.KeyCode, Chr(e.KeyCode - 48), Chr(e.KeyCode))
            '数字の入力

            If tb.SelectionLength = tb.Text.Length Then
                '全選択の場合
                tb.Text = keyDownChar & ".0"
                tb.SelectionLength = 0
                tb.SelectionStart = 1
            Else
                If currentSelectionStart > decimalPointSelectionStart Then
                    '小数部の入力
                    If currentSelectionStart = maxSelectionStart - 1 OrElse currentSelectionStart = maxSelectionStart Then
                        '小数第一位
                        tb.Text = inputIntStr & "." & keyDownChar
                        tb.SelectionStart = maxSelectionStart - 1
                        tb.Select(tb.SelectionStart, 1)
                    End If
                Else
                    '整数部の入力
                    If inputIntStr.Length < 3 Then
                        If inputIntStr = "0" Then
                            tb.Text = keyDownChar & "." & inputDecimalStr
                            tb.SelectionStart = 1
                        Else
                            If Not (currentSelectionStart = 0 AndAlso keyDownChar = "0") Then
                                tb.Text = inputIntStr.Insert(currentSelectionStart, keyDownChar) & "." & inputDecimalStr
                                tb.SelectionStart = currentSelectionStart + 1
                            End If
                        End If
                    End If
                End If
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Decimal OrElse e.KeyCode = Keys.OemPeriod Then
            '小数点の入力
            If currentSelectionStart = decimalPointSelectionStart Then
                tb.SelectionStart += 1
                tb.Select(tb.SelectionStart, 1)
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Back Then
            Dim selectionLength As Integer = tb.SelectionLength
            Dim selectionEnd As Integer = currentSelectionStart + selectionLength

            If selectionLength = tb.Text.Length Then
                '全選択の場合
                tb.Text = "0.0"
                tb.SelectionStart = 1
                tb.SelectionLength = 0
            ElseIf selectionEnd > decimalPointSelectionStart + 1 Then
                '小数部分も選択している状態
                tb.Text = inputIntStr & "." & "0"
                tb.SelectionStart = decimalPointSelectionStart
                tb.SelectionLength = 0
            Else
                '小数部分が選ばれていない場合
                If selectionLength = 0 Then
                    '選択部分がない場合
                    If currentSelectionStart <> 0 Then
                        If inputIntStr.Length = 1 AndAlso currentSelectionStart = decimalPointSelectionStart Then
                            tb.Text = "0." & inputDecimalStr
                            tb.SelectionStart = currentSelectionStart
                        ElseIf currentSelectionStart = decimalPointSelectionStart + 1 Then
                            tb.SelectionStart = currentSelectionStart - 1
                            tb.SelectionLength = 0
                        Else
                            tb.Text = inputIntStr.Remove(currentSelectionStart - 1, 1) & "." & inputDecimalStr
                            tb.SelectionStart = currentSelectionStart - 1
                        End If
                    End If
                Else
                    '選択されている場合

                    '小数点も選択されている場合
                    If selectionEnd > decimalPointSelectionStart Then
                        selectionLength -= 1
                    End If

                    If selectionLength = inputIntStr.Length Then
                        '整数部が全選択の場合
                        tb.Text = "0." & inputDecimalStr
                        tb.SelectionStart = 1
                    Else
                        tb.Text = inputIntStr.Remove(currentSelectionStart, selectionLength) & "." & inputDecimalStr
                        tb.SelectionStart = currentSelectionStart
                    End If
                End If
            End If
            e.SuppressKeyPress = True
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' ヶ月テキストボックス用keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub monthTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim maxSelectionStart As Integer = tb.Text.Length '最大値
        Dim currentSelectionStart As Integer = tb.SelectionStart '現在選択位置
        Dim firstStr As String = tb.Text.Substring(0, 1)
        Dim secondStr As String = ""
        If maxSelectionStart = 2 Then
            secondStr = tb.Text.Substring(1, 1)
        End If

        If e.KeyCode = Windows.Forms.Keys.Left Then
            'カーソルを左に動かす
            If tb.SelectionStart <> 0 Then
                tb.SelectionStart -= 1
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Windows.Forms.Keys.Right Then
            'カーソルを右に動かす
            If tb.SelectionStart <> maxSelectionStart Then
                tb.SelectionStart += 1
            End If
            e.SuppressKeyPress = True
        ElseIf (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) Then
            Dim keyDownChar As String = If(Keys.NumPad0 <= e.KeyCode, Chr(e.KeyCode - 48), Chr(e.KeyCode))
            If tb.SelectionLength > 0 Then
                '選択有りの場合
                If tb.SelectionLength = maxSelectionStart Then
                    '全選択の場合
                    tb.Text = keyDownChar
                    tb.SelectionStart = 1
                    tb.SelectionLength = 0
                Else
                    '１文字選択の場合
                    If tb.SelectionStart = 0 Then
                        '１文字目選択時
                        If keyDownChar = "0" Then
                            tb.Text = secondStr
                            tb.SelectionStart = 0
                            tb.SelectionLength = 0
                        ElseIf keyDownChar = "1" Then
                            If secondStr <= 2 Then
                                tb.Text = "1" & secondStr
                                tb.SelectionStart = 1
                                tb.SelectionLength = 0
                            End If
                        End If
                    Else
                        '２文字目選択時
                        If keyDownChar <= 2 Then
                            tb.Text = firstStr & keyDownChar
                            tb.SelectionStart = 2
                            tb.SelectionLength = 0
                        End If
                    End If
                End If
            Else
                '選択無しの場合
                If maxSelectionStart = 1 Then
                    '１文字入力されている
                    If tb.SelectionStart = 0 Then
                        If keyDownChar = "1" AndAlso firstStr <= 2 Then
                            tb.Text = keyDownChar & firstStr
                            tb.SelectionStart = 1
                        End If
                    Else
                        If firstStr = "1" AndAlso keyDownChar <= 2 Then
                            tb.Text = firstStr & keyDownChar
                            tb.SelectionStart = 2
                        ElseIf firstStr = "0" Then
                            tb.Text = keyDownChar
                            tb.SelectionStart = 1
                        End If
                    End If
                End If
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Back Then
            If tb.SelectionLength = maxSelectionStart Then
                '全選択の場合
                tb.Text = "0"
                tb.SelectionStart = 1
                tb.SelectionLength = 0
            Else
                If maxSelectionStart = 1 Then
                    '入力文字が１文字
                    If currentSelectionStart = 1 Then
                        tb.Text = "0"
                        tb.SelectionStart = 1
                        tb.SelectionLength = 0
                    End If
                Else
                    '入力されている文字が２文字
                    If currentSelectionStart = 1 Then
                        tb.Text = tb.Text.Remove(0, 1)
                        tb.SelectionStart = 0
                        tb.SelectionLength = 0
                    ElseIf currentSelectionStart = 2 Then
                        tb.Text = tb.Text.Substring(0, 1)
                        tb.SelectionStart = 1
                        tb.SelectionLength = 0
                    End If
                End If
            End If

            e.SuppressKeyPress = True
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' パーセントテキストボックス用keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub percentTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim maxSelectionStart As Integer = tb.Text.Length '最大値
        Dim currentSelectionStart As Integer = tb.SelectionStart '現在選択位置
        Dim firstStr As String = tb.Text.Substring(0, 1)
        Dim secondStr As String = ""
        Dim thirdStr As String = ""
        If maxSelectionStart = 2 Then
            secondStr = tb.Text.Substring(1, 1)
        ElseIf maxSelectionStart = 3 Then
            secondStr = tb.Text.Substring(1, 1)
            thirdStr = tb.Text.Substring(2, 1)
        End If

        If e.KeyCode = Windows.Forms.Keys.Left Then
            'カーソルを左に動かす
            If tb.SelectionStart <> 0 Then
                tb.SelectionStart -= 1
            End If
            tb.SelectionLength = 0
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Windows.Forms.Keys.Right Then
            'カーソルを右に動かす
            If tb.SelectionStart <> maxSelectionStart Then
                tb.SelectionStart += 1
            End If
            tb.SelectionLength = 0
            e.SuppressKeyPress = True
        ElseIf (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) Then
            Dim keyDownChar As String = If(Keys.NumPad0 <= e.KeyCode, Chr(e.KeyCode - 48), Chr(e.KeyCode))
            If tb.SelectionLength > 0 Then
                '選択されている場合
                If tb.SelectionLength = maxSelectionStart Then
                    '全選択
                    tb.Text = keyDownChar
                    tb.SelectionStart = 1
                    tb.SelectionLength = 0
                End If
            Else
                '選択されていない場合
                If currentSelectionStart = 0 Then
                    If maxSelectionStart = 1 Then
                        If keyDownChar <> "0" Then
                            tb.Text = keyDownChar & firstStr
                            tb.SelectionStart = 1
                        End If
                    ElseIf maxSelectionStart = 2 Then
                        If firstStr & secondStr = "00" AndAlso keyDownChar = "1" Then
                            tb.Text = "100"
                            tb.SelectionStart = 1
                        End If
                    End If
                ElseIf currentSelectionStart = 1 Then
                    If maxSelectionStart = 1 Then
                        If firstStr = "0" Then
                            tb.Text = keyDownChar
                            tb.SelectionStart = 1
                        Else
                            tb.Text = firstStr & keyDownChar
                            tb.SelectionStart = 2
                        End If
                    ElseIf maxSelectionStart = 2 Then
                        If firstStr & secondStr = "10" AndAlso keyDownChar = "0" Then
                            tb.Text = "100"
                            tb.SelectionStart = 2
                        End If
                    End If
                ElseIf currentSelectionStart = 2 Then
                    If maxSelectionStart = 2 Then
                        If firstStr & secondStr = "10" AndAlso keyDownChar = "0" Then
                            tb.Text = "100"
                            tb.SelectionStart = 3
                        End If
                    End If
                End If
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Back Then
            If tb.SelectionLength > 0 Then
                '選択されている場合
                If tb.SelectionLength = maxSelectionStart Then
                    '全選択
                    tb.Text = "0"
                    tb.SelectionStart = 1
                    tb.SelectionLength = 0
                End If
            Else
                '選択されていない場合
                If currentSelectionStart = 1 Then
                    If maxSelectionStart = 1 Then
                        tb.Text = "0"
                        tb.SelectionStart = 1
                    ElseIf maxSelectionStart = 2 Then
                        tb.Text = secondStr
                        tb.SelectionStart = 0
                    ElseIf maxSelectionStart = 3 Then
                        tb.Text = "0"
                        tb.SelectionStart = 0
                    End If
                ElseIf currentSelectionStart = 2 Then
                    If maxSelectionStart = 2 Then
                        tb.Text = firstStr
                        tb.SelectionStart = 1
                    ElseIf maxSelectionStart = 3 Then
                        tb.Text = firstStr & thirdStr
                        tb.SelectionStart = 1
                    End If
                ElseIf currentSelectionStart = 3 Then
                    If maxSelectionStart = 3 Then
                        tb.Text = firstStr & secondStr
                        tb.SelectionStart = 2
                    End If
                End If
            End If
            e.SuppressKeyPress = True
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' カロリーテキストボックス用keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub kcalTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim maxSelectionStart As Integer = tb.Text.Length '最大値
        Dim currentSelectionStart As Integer = tb.SelectionStart '現在選択位置

        If e.KeyCode = Windows.Forms.Keys.Left Then
            'カーソルを左に動かす
            If tb.SelectionStart <> 0 Then
                tb.SelectionStart -= 1
            End If
            tb.SelectionLength = 0
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Windows.Forms.Keys.Right Then
            'カーソルを右に動かす
            If tb.SelectionStart <> maxSelectionStart Then
                tb.SelectionStart += 1
            End If
            tb.SelectionLength = 0
            e.SuppressKeyPress = True
        ElseIf (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) Then
            Dim keyDownChar As String = If(Keys.NumPad0 <= e.KeyCode, Chr(e.KeyCode - 48), Chr(e.KeyCode))
            If maxSelectionStart = 8 OrElse (keyDownChar = "0" AndAlso currentSelectionStart = 0) Then
                e.SuppressKeyPress = True
            ElseIf tb.Text = "0" AndAlso tb.SelectionStart = 1 Then
                tb.Text = keyDownChar
                tb.SelectionStart = 1
                e.SuppressKeyPress = True
            End If
        ElseIf e.KeyCode = Keys.Back Then
            If tb.SelectionLength = maxSelectionStart Then
                '全選択
                tb.Text = "0"
                tb.SelectionStart = 1
                e.SuppressKeyPress = True
            ElseIf tb.Text.Length = 1 AndAlso tb.SelectionStart = 1 Then
                tb.Text = "0"
                tb.SelectionStart = 1
                e.SuppressKeyPress = True
            ElseIf tb.Text.Length >= 2 AndAlso tb.SelectionStart = 1 Then
                tb.Text = CInt(tb.Text.Substring(1, tb.TextLength - 1))
                tb.SelectionStart = 0
                e.SuppressKeyPress = True
            End If
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' 通常文章入力テキストボックス用KeyPressイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvAssesTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim text As String = CType(sender, DataGridViewTextBoxEditingControl).Text
        Dim lengthByte As Integer = Encoding.GetEncoding("Shift_JIS").GetByteCount(text)

        If lengthByte >= ASSES_LIMIT_LENGTH_BYTE Then '設定されているバイト数以上の時
            If e.KeyChar = ChrW(Keys.Back) Then
                'Backspaceは入力可能
                e.Handled = False
            Else
                '入力できなくする
                e.Handled = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' dgvSub用テキストボックスKeyPress
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSubTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim text As String = CType(sender, DataGridViewTextBoxEditingControl).Text
        Dim lengthByte As Integer = Encoding.GetEncoding("Shift_JIS").GetByteCount(text)

        If lengthByte >= SUB_LIMIT_LENGTH_BYTE Then '設定されているバイト数以上の時
            If e.KeyChar = ChrW(Keys.Back) Then
                'Backspaceは入力可能
                e.Handled = False
            Else
                '入力できなくする
                e.Handled = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' 実施日用和暦変換
    ''' </summary>
    ''' <param name="adStr">西暦</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function formatWarekiStr(adStr As String) As String
        If adStr = "" Then
            Return ""
        End If

        Dim wareki As String = Util.convADStrToWarekiStr(adStr)
        Dim era As String = wareki.Substring(0, 3)
        Dim month As String = CInt(wareki.Substring(4, 2)).ToString()
        Dim day As String = CInt(wareki.Substring(7, 2)).ToString()

        Return era & " 年 " & month & " 月 " & day & " 日"
    End Function

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        dgvAsses.CurrentCell = dgvAsses(0, 0)
        '実施日1
        Dim jYmd1 As String = date1YmdBox.getADStr()

        If jYmd1 = "" Then
            MsgBox("実施日１ がありません。", MsgBoxStyle.Exclamation)
            Return
        End If

        '作成日
        Dim ymd As String = createYmdBox.getADStr()
        '記入者
        Dim tanto As String = tantoComboBox.Text
        'Sub
        Dim subText As String = Util.checkDBNullValue(dgvSub(0, 0).Value)

        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Asses where Nam='" & selectedResidentName & "' and Ymd='" & ymd & "' order by Gyo"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            '変更登録
            Dim result As DialogResult = MessageBox.Show("該当日にデータが存在します。上書き保存しますか？", "登録", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                While Not rs.EOF
                    Dim gyo As Integer = rs.Fields("Gyo").Value
                    If gyo = 1 Then
                        rs.Fields("Tanto").Value = tanto
                        rs.Fields("Sub").Value = subText
                        rs.Fields("Fa").Value = ""
                    End If
                    rs.Fields("JYmd").Value = DirectCast(datePanel.Controls("date" & gyo & "YmdBox"), ymdBox.ymdBox).getADStr()
                    rs.Fields("Iyoku1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 0).Value)
                    rs.Fields("Iyoku2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 1).Value)
                    rs.Fields("Tai").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 2).Value))
                    rs.Fields("Bmi").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 3).Value))
                    rs.Fields("Gen1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 4).Value)
                    rs.Fields("Gen2").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 5).Value))
                    rs.Fields("Gen3").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 6).Value))
                    rs.Fields("ALB").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 7).Value))
                    rs.Fields("Hok1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 8).Value)
                    rs.Fields("Man").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 9).Value)
                    rs.Fields("Ryo1").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 10).Value))
                    rs.Fields("Ryo2").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 11).Value))
                    rs.Fields("Ryo3").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 12).Value))
                    rs.Fields("Hok21").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 13).Value)
                    rs.Fields("Hok22").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 14).Value)
                    rs.Fields("Engy1").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 15).Value))
                    rs.Fields("Engy2").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 16).Value))
                    rs.Fields("Engy3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 17).Value)
                    rs.Fields("Engy4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 18).Value)
                    rs.Fields("Ryui1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 19).Value)
                    rs.Fields("Ryui2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 20).Value)
                    rs.Fields("Ryui3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 21).Value)
                    rs.Fields("Ryui4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 22).Value)
                    rs.Fields("Hok31").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 23).Value)
                    rs.Fields("Hok32").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 24).Value)
                    rs.Fields("Hok33").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 25).Value)
                    rs.Fields("Hok34").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 26).Value)
                    rs.Fields("Care1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 27).Value)
                    rs.Fields("Care2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 28).Value)
                    rs.Fields("Care3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 29).Value)
                    rs.Fields("Care4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 30).Value)
                    rs.Fields("Care5").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 31).Value)
                    rs.Fields("Care6").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 32).Value)
                    rs.Fields("Care7").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 33).Value)
                    rs.Fields("Tokki").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 34).Value)
                    rs.Fields("Mon1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 35).Value)
                    rs.Fields("Mon2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 36).Value)
                    rs.Fields("Mon3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 37).Value)
                    rs.Fields("Mon4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 38).Value)
                    rs.Fields("Mon5").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 39).Value)
                    rs.Fields("Mon6").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 40).Value)
                    rs.Fields("Mon7").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 41).Value)
                    rs.Fields("Mon8").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 42).Value)
                    rs.Fields("Mon9").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 43).Value)
                    rs.Fields("Mon10").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 44).Value)
                    rs.Fields("Mon11").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 45).Value)
                    rs.Fields("Result").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 46).Value)

                    rs.MoveNext()
                End While
                rs.MovePrevious()

                rs.Update()
                rs.Close()
                cn.Close()

                '表示クリア
                clearInput()
                setHistoryList()

            Else
                rs.Close()
                cn.Close()
            End If
        Else
            '新規登録
            For gyo As Integer = 1 To 4
                rs.AddNew()
                rs.Fields("Nam").Value = selectedResidentName
                rs.Fields("Ymd").Value = ymd
                rs.Fields("Gyo").Value = gyo
                If gyo = 1 Then
                    rs.Fields("Tanto").Value = tanto
                    rs.Fields("Sub").Value = subText
                    rs.Fields("Fa").Value = ""
                End If
                rs.Fields("JYmd").Value = DirectCast(datePanel.Controls("date" & gyo & "YmdBox"), ymdBox.ymdBox).getADStr()
                rs.Fields("Iyoku1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 0).Value)
                rs.Fields("Iyoku2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 1).Value)
                rs.Fields("Tai").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 2).Value))
                rs.Fields("Bmi").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 3).Value))
                rs.Fields("Gen1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 4).Value)
                rs.Fields("Gen2").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 5).Value))
                rs.Fields("Gen3").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 6).Value))
                rs.Fields("ALB").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 7).Value))
                rs.Fields("Hok1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 8).Value)
                rs.Fields("Man").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 9).Value)
                rs.Fields("Ryo1").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 10).Value))
                rs.Fields("Ryo2").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 11).Value))
                rs.Fields("Ryo3").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 12).Value))
                rs.Fields("Hok21").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 13).Value)
                rs.Fields("Hok22").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 14).Value)
                rs.Fields("Engy1").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 15).Value))
                rs.Fields("Engy2").Value = convEmptyToZero(Util.checkDBNullValue(dgvAsses(gyo + 1, 16).Value))
                rs.Fields("Engy3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 17).Value)
                rs.Fields("Engy4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 18).Value)
                rs.Fields("Ryui1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 19).Value)
                rs.Fields("Ryui2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 20).Value)
                rs.Fields("Ryui3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 21).Value)
                rs.Fields("Ryui4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 22).Value)
                rs.Fields("Hok31").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 23).Value)
                rs.Fields("Hok32").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 24).Value)
                rs.Fields("Hok33").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 25).Value)
                rs.Fields("Hok34").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 26).Value)
                rs.Fields("Care1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 27).Value)
                rs.Fields("Care2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 28).Value)
                rs.Fields("Care3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 29).Value)
                rs.Fields("Care4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 30).Value)
                rs.Fields("Care5").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 31).Value)
                rs.Fields("Care6").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 32).Value)
                rs.Fields("Care7").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 33).Value)
                rs.Fields("Tokki").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 34).Value)
                rs.Fields("Mon1").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 35).Value)
                rs.Fields("Mon2").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 36).Value)
                rs.Fields("Mon3").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 37).Value)
                rs.Fields("Mon4").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 38).Value)
                rs.Fields("Mon5").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 39).Value)
                rs.Fields("Mon6").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 40).Value)
                rs.Fields("Mon7").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 41).Value)
                rs.Fields("Mon8").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 42).Value)
                rs.Fields("Mon9").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 43).Value)
                rs.Fields("Mon10").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 44).Value)
                rs.Fields("Mon11").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 45).Value)
                rs.Fields("Result").Value = Util.checkDBNullValue(dgvAsses(gyo + 1, 46).Value)
            Next
            rs.Update()
            rs.Close()
            cn.Close()

            '表示クリア
            clearInput()
            setHistoryList()
        End If
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        dgvAsses.CurrentCell = dgvAsses(0, 0)
        '作成日
        Dim ymd As String = createYmdBox.getADStr()

        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Asses where Nam='" & selectedResidentName & "' and Ymd='" & ymd & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '該当なし
            MsgBox("該当がありません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        Else
            'データが存在している場合
            Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                Dim cmd As New ADODB.Command()
                cmd.ActiveConnection = cn
                cmd.CommandText = "delete from Asses where Nam='" & selectedResidentName & "' and Ymd='" & ymd & "'"
                cmd.Execute()
                rs.Close()
                cn.Close()

                '表示クリア
                clearInput()
                setHistoryList()
            Else
                rs.Close()
                cn.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        dgvAsses.CurrentCell = dgvAsses(0, 0)
        '日付
        Dim ymd As String = createYmdBox.getADStr()

        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(topform.DB_NCare)
        Dim sql As String = "select * from Asses where Nam='" & selectedResidentName & "' and Ymd='" & ymd & "' order by Gyo"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("対象データが存在しません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        End If

        '書き込みデータ作成
        Dim dataArray(44, 55) As String
        Dim tanto As String = ""
        Dim subText As String = ""
        Dim plusBaseNum As Integer = 14
        While Not rs.EOF
            Dim gyo As Integer = rs.Fields("Gyo").Value
            If gyo = 1 Then
                tanto = Util.checkDBNullValue(rs.Fields("Tanto").Value)
                subText = Util.checkDBNullValue(rs.Fields("Sub").Value)
            End If

            '配列へ代入
            dataArray(0, 0 + ((gyo - 1) * plusBaseNum)) = formatWarekiStr(Util.checkDBNullValue(rs.Fields("JYmd").Value)) '実施日
            dataArray(1, 1 + ((gyo - 1) * plusBaseNum)) = "["
            dataArray(1, 2 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Iyoku1").Value) '本人の意欲(1)
            dataArray(1, 12 + ((gyo - 1) * plusBaseNum)) = "]"
            dataArray(2, 1 + ((gyo - 1) * plusBaseNum)) = "("
            dataArray(2, 2 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Iyoku2").Value) '(健康感、生活機能、身体機能等)
            dataArray(2, 12 + ((gyo - 1) * plusBaseNum)) = ")"
            dataArray(3, 4 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Tai").Value) '体重
            dataArray(3, 10 + ((gyo - 1) * plusBaseNum)) = "(kg)"
            dataArray(4, 4 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Bmi").Value) 'BMI
            dataArray(4, 10 + ((gyo - 1) * plusBaseNum)) = "(kg/㎡)"
            dataArray(5, 1 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Gen1").Value) = "無", "■", "□")
            dataArray(5, 2 + ((gyo - 1) * plusBaseNum)) = "無"
            dataArray(5, 4 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Gen1").Value) = "有", "■", "□")
            dataArray(5, 5 + ((gyo - 1) * plusBaseNum)) = "有"
            dataArray(5, 7 + ((gyo - 1) * plusBaseNum)) = "("
            dataArray(5, 10 + ((gyo - 1) * plusBaseNum)) = "kg/"
            dataArray(5, 12 + ((gyo - 1) * plusBaseNum)) = "ヶ月"
            dataArray(5, 13 + ((gyo - 1) * plusBaseNum)) = ")"
            If Util.checkDBNullValue(rs.Fields("Gen1").Value) = "有" Then
                dataArray(5, 8 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Gen2").Value)
                dataArray(5, 11 + ((gyo - 1) * plusBaseNum)) = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Gen3").Value))
            End If
            dataArray(6, 1 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("ALB").Value) <> 0, "□", "■")
            dataArray(6, 2 + ((gyo - 1) * plusBaseNum)) = "無"
            dataArray(6, 4 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("ALB").Value) <> 0, "■", "□")
            dataArray(6, 5 + ((gyo - 1) * plusBaseNum)) = "有"
            dataArray(6, 7 + ((gyo - 1) * plusBaseNum)) = "("
            If Util.checkDBNullValue(rs.Fields("ALB").Value) <> 0 Then
                dataArray(6, 8 + ((gyo - 1) * plusBaseNum)) = convDecimalStr(Util.checkDBNullValue(rs.Fields("ALB").Value))
            End If
            dataArray(6, 11 + ((gyo - 1) * plusBaseNum)) = "(g/dl)"
            dataArray(6, 13 + ((gyo - 1) * plusBaseNum)) = ")"
            dataArray(7, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok1").Value)
            dataArray(8, 1 + ((gyo - 1) * plusBaseNum)) = "["
            dataArray(8, 2 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Man").Value)
            dataArray(8, 12 + ((gyo - 1) * plusBaseNum)) = "]"
            dataArray(9, 5 + ((gyo - 1) * plusBaseNum)) = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Ryo1").Value))
            dataArray(9, 10 + ((gyo - 1) * plusBaseNum)) = "%"
            dataArray(10, 5 + ((gyo - 1) * plusBaseNum)) = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Ryo2").Value))
            dataArray(10, 10 + ((gyo - 1) * plusBaseNum)) = "%"
            dataArray(11, 5 + ((gyo - 1) * plusBaseNum)) = convZeroToEmpty(Util.checkDBNullValue(rs.Fields("Ryo3").Value))
            dataArray(11, 10 + ((gyo - 1) * plusBaseNum)) = "%"
            dataArray(12, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok21").Value)
            dataArray(13, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok22").Value)
            dataArray(14, 2 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Engy1").Value)
            dataArray(14, 6 + ((gyo - 1) * plusBaseNum)) = "kcal"
            dataArray(14, 10 + ((gyo - 1) * plusBaseNum)) = convDecimalStr(Util.checkDBNullValue(rs.Fields("Engy2").Value))
            dataArray(14, 12 + ((gyo - 1) * plusBaseNum)) = "g"
            dataArray(15, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Engy3").Value)
            dataArray(16, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Engy4").Value)
            dataArray(17, 1 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Ryui1").Value) = "無", "■", "□")
            dataArray(17, 2 + ((gyo - 1) * plusBaseNum)) = "無"
            dataArray(17, 4 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Ryui1").Value) = "有", "■", "□")
            dataArray(17, 5 + ((gyo - 1) * plusBaseNum)) = "有"
            If Util.checkDBNullValue(rs.Fields("Ryui1").Value) = "有" Then
                dataArray(18, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Ryui2").Value)
                dataArray(19, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Ryui3").Value)
                dataArray(20, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Ryui4").Value)
            End If
            dataArray(21, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok31").Value)
            dataArray(22, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok32").Value)
            dataArray(23, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok33").Value)
            dataArray(24, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Hok34").Value)
            dataArray(26, 1 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Care1").Value) = "無", "■", "□")
            dataArray(26, 2 + ((gyo - 1) * plusBaseNum)) = "無"
            dataArray(26, 4 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Care1").Value) = "有", "■", "□")
            dataArray(26, 5 + ((gyo - 1) * plusBaseNum)) = "有"
            If Util.checkDBNullValue(rs.Fields("Care1").Value) = "有" Then
                dataArray(27, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Care2").Value)
                dataArray(28, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Care3").Value)
                dataArray(29, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Care4").Value)
                dataArray(30, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Care5").Value)
                dataArray(31, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Care6").Value)
                dataArray(32, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Care7").Value)
                dataArray(33, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Tokki").Value)
            End If
            dataArray(34, 1 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Mon1").Value) = "無", "■", "□")
            dataArray(34, 2 + ((gyo - 1) * plusBaseNum)) = "無"
            dataArray(34, 4 + ((gyo - 1) * plusBaseNum)) = If(Util.checkDBNullValue(rs.Fields("Mon1").Value) = "有", "■", "□")
            dataArray(34, 5 + ((gyo - 1) * plusBaseNum)) = "有"
            dataArray(34, 8 + ((gyo - 1) * plusBaseNum)) = "["
            dataArray(34, 12 + ((gyo - 1) * plusBaseNum)) = "]"
            If Util.checkDBNullValue(rs.Fields("Mon1").Value) = "有" Then
                dataArray(34, 9 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon2").Value)
                dataArray(35, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon3").Value)
                dataArray(36, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon4").Value)
                dataArray(37, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon5").Value)
                dataArray(38, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon6").Value)
                dataArray(39, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon7").Value)
                dataArray(40, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon8").Value)
                dataArray(41, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon9").Value)
                dataArray(42, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon10").Value)
                dataArray(43, 1 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Mon11").Value)
            End If
            dataArray(44, 0 + ((gyo - 1) * plusBaseNum)) = Util.checkDBNullValue(rs.Fields("Result").Value)
            
            rs.MoveNext()
        End While

        'エクセル準備
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(topform.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("アセモニ改")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '作成年月日
        oSheet.Range("AW2").Value = createYmdBox.getWarekiStr()
        '利用者名
        oSheet.Range("E6").Value = selectedResidentName
        '記入者
        oSheet.Range("AV6").Value = tanto
        'Sub
        oSheet.Range("E7").Value = subText
        'アセモニデータ
        oSheet.Range("F10", "BI54").Value = dataArray

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If topform.rbnPrintout.Checked = True Then
            oSheet.PrintOut()
        ElseIf topform.rbnPreview.Checked = True Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub

    Private Sub dateYmdBox_keyDownEnterOrDown(sender As Object, e As System.EventArgs) Handles date1YmdBox.keyDownEnterOrDown, date2YmdBox.keyDownEnterOrDown, date3YmdBox.keyDownEnterOrDown, date4YmdBox.keyDownEnterOrDown
        Dim number As Integer = CInt(CType(sender, ymdBox.ymdBox).Name.Substring(4, 1))
        dgvAsses.CurrentCell = dgvAsses(number + 1, 0)
        dgvAsses.BeginEdit(True)
    End Sub
End Class