Public Class アセモニ

    '選択されている入居者名
    Private selectedResidentName As String

    Private clearNumArray() As String = {"1", "2", "3", "4"}

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

        'データグリッドビュー初期設定
        initDgvSub()

        '名前設定
        namArea.Text = selectedResidentName

        'クリアコンボボックス初期設定
        clearComboBox.Items.AddRange(clearNumArray)

        '現在日付設定
        createYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))
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
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
    End Sub

    ''' <summary>
    ''' 履歴リストセット
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setHistoryList()

    End Sub


End Class