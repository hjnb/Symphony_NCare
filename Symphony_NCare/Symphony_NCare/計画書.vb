Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class 計画書
    Private Nam, birth, jyuusyo As String
    Private DGV2Table As DataTable

    Public Sub New(frmnam As String, frmbirth As String, frmJyuusyo As String)
        InitializeComponent()

        Me.Nam = frmnam
        Me.birth = frmbirth
        Me.jyuusyo = frmJyuusyo

    End Sub

    Private Sub 計画書_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        lblName.Text = Nam

        KeyPreview = True

        Util.EnableDoubleBuffering(DataGridView1)

        DataGridView1.RowTemplate.Height = 15

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select * from Dat2 WHERE Nam = '" & lblName.Text & "' AND Birth =  '" & birth & "' order by Ymd DESC"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 0 To 110
            If i <> 1 Then
                DataGridView1.Columns(i).Visible = False
            End If
        Next
        DataGridView1.Columns(1).Width = 70

        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))

        With DataGridView2
            .RowTemplate.Height = 18
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
            .ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        End With

        DGV2Table = New DataTable()
        Util.EnableDoubleBuffering(DataGridView2)

        'DataGridView2列作成
        For col As Integer = 0 To 3
            DGV2Table.Columns.Add("a" & col, Type.GetType("System.String"))
        Next

        'DataGridView2行作成
        For row As Integer = 1 To 18
            DGV2Table.Rows.Add(DGV2Table.NewRow())
        Next

        'DataGridView2空を表示
        DataGridView2.DataSource = DGV2Table

        'DataGridView2列の設定
        DataGridView2.Columns(0).Width = 241
        DataGridView2.Columns(1).Width = 521
        DataGridView2.Columns(2).Width = 64
        DataGridView2.Columns(3).Width = 64

        DataGridView2(0, 0).Selected = False
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = 1 Then
            e.Value = Util.convADStrToWarekiStr(e.Value)
        End If
    End Sub

    Private Sub DataGridView2_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting
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

    Private Sub 計画書_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim selectedrow As Integer = DataGridView1.CurrentRow.Index
        YmdBox1.setADStr(DataGridView1("Ymd", selectedrow).Value)
        ymdboxFstymd.setADStr(DataGridView1("FstYmd", selectedrow).Value)
        ymdboxNyuymd.setADStr(DataGridView1("NyuYmd", selectedrow).Value)
        txtKei.Text = Util.checkDBNullValue(DataGridView1("Kei", selectedrow).Value)
        txtNin.Text = Util.checkDBNullValue(DataGridView1("Nin", selectedrow).Value)
        cmbAuthor.Text = Util.checkDBNullValue(DataGridView1("Author", selectedrow).Value)
        txtTanto.Text = Util.checkDBNullValue(DataGridView1("Tanto", selectedrow).Value)
        txtKai.Text = Util.checkDBNullValue(DataGridView1("Kai", selectedrow).Value)
        txtKaitxt.Text = Util.checkDBNullValue(DataGridView1("Kaitxt", selectedrow).Value)
        txtIko1.Text = Util.checkDBNullValue(DataGridView1("Iko1", selectedrow).Value)
        txtIko2.Text = Util.checkDBNullValue(DataGridView1("Iko2", selectedrow).Value)
        txtRisk.Text = Util.checkDBNullValue(DataGridView1("Risk", selectedrow).Value)
        txtKad1.Text = Util.checkDBNullValue(DataGridView1("Kad1", selectedrow).Value)
        txtKad2.Text = Util.checkDBNullValue(DataGridView1("Kad2", selectedrow).Value)
        txtKad3.Text = Util.checkDBNullValue(DataGridView1("Kad3", selectedrow).Value)
        txtTyo1.Text = Util.checkDBNullValue(DataGridView1("Tyo1", selectedrow).Value)
        txtTyo2.Text = Util.checkDBNullValue(DataGridView1("Tyo2", selectedrow).Value)
        For i As Integer = 1 To 18
            DataGridView2(0, i - 1).Value = Util.checkDBNullValue(DataGridView1("Txta" & i, selectedrow).Value)
            DataGridView2(1, i - 1).Value = Util.checkDBNullValue(DataGridView1("Txtb" & i, selectedrow).Value)
            DataGridView2(2, i - 1).Value = Util.checkDBNullValue(DataGridView1("Txtc" & i, selectedrow).Value)
            DataGridView2(3, i - 1).Value = Util.checkDBNullValue(DataGridView1("Txtd" & i, selectedrow).Value)

            'Panel1.Controls("txtTxta" & i).Text = Util.checkDBNullValue(DataGridView1("Txta" & i, selectedrow).Value)
            'Panel1.Controls("txtTxtb" & i).Text = Util.checkDBNullValue(DataGridView1("Txtb" & i, selectedrow).Value)
            'Panel1.Controls("txtTxtc" & i).Text = Util.checkDBNullValue(DataGridView1("Txtc" & i, selectedrow).Value)
            'Panel1.Controls("txtTxtd" & i).Text = Util.checkDBNullValue(DataGridView1("Txtd" & i, selectedrow).Value)
            If i = 1 OrElse i = 4 OrElse i = 7 OrElse i = 10 OrElse i = 13 OrElse i = 16 Then
                Panel1.Controls("cmbTxte" & i).Text = Util.checkDBNullValue(DataGridView1("Txte" & i, selectedrow).Value)
            Else
                Panel1.Controls("txtTxte" & i).Text = Util.checkDBNullValue(DataGridView1("Txte" & i, selectedrow).Value)
            End If
        Next
        txtTok1.Text = Util.checkDBNullValue(DataGridView1("Tok1", selectedrow).Value)
        txtTok2.Text = Util.checkDBNullValue(DataGridView1("Tok2", selectedrow).Value)

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtKei.Text = ""
        txtNin.Text = ""
        cmbAuthor.Text = ""
        ymdboxNyuymd.clearText()
        ymdboxFstymd.clearText()
        txtTanto.Text = ""
        txtKai.Text = ""
        txtKaitxt.Text = ""
        txtIko1.Text = ""
        txtIko2.Text = ""
        txtRisk.Text = ""
        txtKad1.Text = ""
        txtKad2.Text = ""
        txtKad3.Text = ""
        txtTyo1.Text = ""
        txtTyo2.Text = ""
        For i As Integer = 1 To 18
            DataGridView2(0, i).Value = ""
            DataGridView2(1, i).Value = ""
            DataGridView2(2, i).Value = ""
            DataGridView2(3, i).Value = ""
            'Panel1.Controls("txtTxta" & i).Text = ""
            'Panel1.Controls("txtTxtb" & i).Text = ""
            'Panel1.Controls("txtTxtc" & i).Text = ""
            'Panel1.Controls("txtTxtd" & i).Text = ""
            If i = 1 OrElse i = 4 OrElse i = 7 OrElse i = 10 OrElse i = 13 OrElse i = 16 Then
                Panel1.Controls("cmbTxte" & i).Text = ""
            Else
                Panel1.Controls("txtTxte" & i).Text = ""
            End If
        Next
        txtTok1.Text = ""
        txtTok2.Text = ""
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1(1, i).Value = YmdBox1.getADStr() Then
                Kousin()
                Exit Sub
            End If
        Next
        Tuika()
    End Sub

    Private Sub Kousin()
        Dim nam, ymd, fstymd, nyuymd, kei, nin, author, tanto, kai, kaitxt, iko1, iko2, risk, kad1, kad2, kad3, tyo1, tyo2, txta1, txtb1, txtc1, txtd1, txte1, txta2, txtb2, txtc2, txtd2, txte2, txta3, txtb3, txtc3, txtd3, txte3, txta4, txtb4, txtc4, txtd4, txte4, txta5, txtb5, txtc5, txtd5, txte5, txta6, txtb6, txtc6, txtd6, txte6, txta7, txtb7, txtc7, txtd7, txte7, txta8, txtb8, txtc8, txtd8, txte8, txta9, txtb9, txtc9, txtd9, txte9, txta10, txtb10, txtc10, txtd10, txte10, txta11, txtb11, txtc11, txtd11, txte11, txta12, txtb12, txtc12, txtd12, txte12, txta13, txtb13, txtc13, txtd13, txte13, txta14, txtb14, txtc14, txtd14, txte14, txta15, txtb15, txtc15, txtd15, txte15, txta16, txtb16, txtc16, txtd16, txte16, txta17, txtb17, txtc17, txtd17, txte17, txta18, txtb18, txtc18, txtd18, txte18, tok1, tok2, ymdbirth As String
        nam = lblName.Text
        ymd = Strings.Left(YmdBox1.getADStr(), 10)
        If txtKei.Text <> "1" AndAlso txtKei.Text <> "2" AndAlso txtKei.Text <> "3" Then
            MsgBox("初回・紹介・継続を正しく入力してください")
            txtKei.Focus()
            Return
        Else
            kei = txtKei.Text
        End If
        If txtNin.Text <> "1" AndAlso txtNin.Text <> "2" Then
            MsgBox("認定済・申請中を正しく入力してください")
            txtNin.Focus()
            Return
        Else
            nin = txtNin.Text
        End If
        If cmbAuthor.Text = "" Then
            MsgBox("作成者を入力してください")
            cmbAuthor.Focus()
            Return
        Else
            author = cmbAuthor.Text
        End If
        If ymdboxNyuymd.getADStr() = "" Then
            MsgBox("入所（院）日を正しく入力してください")
            ymdboxNyuymd.Focus()
            Return
        Else
            nyuymd = ymdboxNyuymd.getADStr()
        End If
        If ymdboxFstymd.getADStr() = "" Then
            MsgBox("初回作成日を正しく入力してください")
            ymdboxFstymd.Focus()
            Return
        Else
            fstymd = ymdboxFstymd.getADStr()
        End If
        If txtTanto.Text = "" Then
            MsgBox("担当者を入力してください")
            txtTanto.Focus()
            Return
        Else
            tanto = txtTanto.Text
        End If
        If txtKai.Text = "" Then
            kai = 0
        Else
            kai = txtKai.Text
        End If
        kaitxt = txtKaitxt.Text
        iko1 = txtIko1.Text
        iko2 = txtIko2.Text
        If txtRisk.Text = "" Then
            risk = 0
        Else
            risk = txtRisk.Text
        End If
        kad1 = txtKad1.Text
        kad2 = txtKad2.Text
        kad3 = txtKad3.Text
        tyo1 = txtTyo1.Text
        tyo2 = txtTyo2.Text
        txta1 = DataGridView2(0, 0).Value
        txtb1 = DataGridView2(1, 0).Value
        txtc1 = DataGridView2(2, 0).Value
        txtd1 = DataGridView2(3, 0).Value
        txte1 = cmbTxte1.Text
        txta2 = DataGridView2(0, 1).Value
        txtb2 = DataGridView2(1, 1).Value
        txtc2 = DataGridView2(2, 1).Value
        txtd2 = DataGridView2(3, 1).Value
        txte2 = txtTxte2.Text
        txta3 = DataGridView2(0, 2).Value
        txtb3 = DataGridView2(1, 2).Value
        txtc3 = DataGridView2(2, 2).Value
        txtd3 = DataGridView2(3, 2).Value
        txte3 = txtTxte3.Text
        txta4 = DataGridView2(0, 3).Value
        txtb4 = DataGridView2(1, 3).Value
        txtc4 = DataGridView2(2, 3).Value
        txtd4 = DataGridView2(3, 3).Value
        txte4 = cmbTxte4.Text
        txta5 = DataGridView2(0, 4).Value
        txtb5 = DataGridView2(1, 4).Value
        txtc5 = DataGridView2(2, 4).Value
        txtd5 = DataGridView2(3, 4).Value
        txte5 = txtTxte5.Text
        txta6 = DataGridView2(0, 5).Value
        txtb6 = DataGridView2(1, 5).Value
        txtc6 = DataGridView2(2, 5).Value
        txtd6 = DataGridView2(3, 5).Value
        txte6 = txtTxte6.Text
        txta7 = DataGridView2(0, 6).Value
        txtb7 = DataGridView2(1, 6).Value
        txtc7 = DataGridView2(2, 6).Value
        txtd7 = DataGridView2(3, 6).Value
        txte7 = cmbTxte7.Text
        txta8 = DataGridView2(0, 7).Value
        txtb8 = DataGridView2(1, 7).Value
        txtc8 = DataGridView2(2, 7).Value
        txtd8 = DataGridView2(3, 7).Value
        txte8 = txtTxte8.Text
        txta9 = DataGridView2(0, 8).Value
        txtb9 = DataGridView2(1, 8).Value
        txtc9 = DataGridView2(2, 8).Value
        txtd9 = DataGridView2(3, 8).Value
        txte9 = txtTxte9.Text
        txta10 = DataGridView2(0, 9).Value
        txtb10 = DataGridView2(1, 9).Value
        txtc10 = DataGridView2(2, 9).Value
        txtd10 = DataGridView2(3, 9).Value
        txte10 = cmbTxte10.Text
        txta11 = DataGridView2(0, 10).Value
        txtb11 = DataGridView2(1, 10).Value
        txtc11 = DataGridView2(2, 10).Value
        txtd11 = DataGridView2(3, 10).Value
        txte11 = txtTxte11.Text
        txta12 = DataGridView2(0, 11).Value
        txtb12 = DataGridView2(1, 11).Value
        txtc12 = DataGridView2(2, 11).Value
        txtd12 = DataGridView2(3, 11).Value
        txte12 = txtTxte12.Text
        txta13 = DataGridView2(0, 12).Value
        txtb13 = DataGridView2(1, 12).Value
        txtc13 = DataGridView2(2, 12).Value
        txtd13 = DataGridView2(3, 12).Value
        txte13 = cmbTxte13.Text
        txta14 = DataGridView2(0, 13).Value
        txtb14 = DataGridView2(1, 13).Value
        txtc14 = DataGridView2(2, 13).Value
        txtd14 = DataGridView2(3, 13).Value
        txte14 = txtTxte14.Text
        txta15 = DataGridView2(0, 14).Value
        txtb15 = DataGridView2(1, 14).Value
        txtc15 = DataGridView2(2, 14).Value
        txtd15 = DataGridView2(3, 14).Value
        txte15 = txtTxte15.Text
        txta16 = DataGridView2(0, 15).Value
        txtb16 = DataGridView2(1, 15).Value
        txtc16 = DataGridView2(2, 15).Value
        txtd16 = DataGridView2(3, 15).Value
        txte16 = cmbTxte16.Text
        txta17 = DataGridView2(0, 16).Value
        txtb17 = DataGridView2(1, 16).Value
        txtc17 = DataGridView2(2, 16).Value
        txtd17 = DataGridView2(3, 16).Value
        txte17 = txtTxte17.Text
        txta18 = DataGridView2(0, 17).Value
        txtb18 = DataGridView2(1, 17).Value
        txtc18 = DataGridView2(2, 17).Value
        txtd18 = DataGridView2(3, 17).Value
        txte18 = txtTxte18.Text
        tok1 = txtTok1.Text
        tok2 = txtTok2.Text
        ymdbirth = birth

        If MsgBox("変更登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.No Then
            Return
        End If

        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim SQL As String = ""
        SQL = "DELETE FROM Dat2 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBox1.getADStr() & "' AND NyuYmd = '" & ymdboxNyuymd.getADStr & "'"
        cnn.Execute(SQL)

        SQL = "INSERT INTO Dat2 VALUES ('" & nam & "', '" & ymd & "', '" & fstymd & "', '" & nyuymd & "', " & kei & ", " & nin & ", '" & author & "', '" & tanto & "', " & kai & ", '" & kaitxt & "', '" & iko1 & "', '" & iko2 & "', " & risk & ", '" & kad1 & "', '" & kad2 & "', '" & kad3 & "', '" & tyo1 & "', '" & tyo2 & "', '" & txta1 & "', '" & txtb1 & "', '" & txtc1 & "', '" & txtd1 & "', '" & txte1 & "', '" & txta2 & "', '" & txtb2 & "', '" & txtc2 & "', '" & txtd2 & "', '" & txte2 & "', '" & txta3 & "', '" & txtb3 & "', '" & txtc3 & "', '" & txtd3 & "', '" & txte3 & "', '" & txta4 & "', '" & txtb4 & "', '" & txtc4 & "', '" & txtd4 & "', '" & txte4 & "', '" & txta5 & "', '" & txtb5 & "', '" & txtc5 & "', '" & txtd5 & "', '" & txte5 & "', '" & txta6 & "', '" & txtb6 & "', '" & txtc6 & "', '" & txtd6 & "', '" & txte6 & "', '" & txta7 & "', '" & txtb7 & "', '" & txtc7 & "', '" & txtd7 & "', '" & txte7 & "', '" & txta8 & "', '" & txtb8 & "', '" & txtc8 & "', '" & txtd8 & "', '" & txte8 & "', '" & txta9 & "', '" & txtb9 & "', '" & txtc9 & "', '" & txtd9 & "', '" & txte9 & "', '" & txta10 & "', '" & txtb10 & "', '" & txtc10 & "', '" & txtd10 & "', '" & txte10 & "', '" & txta11 & "', '" & txtb11 & "', '" & txtc11 & "', '" & txtd11 & "', '" & txte11 & "', '" & txta12 & "', '" & txtb12 & "', '" & txtc12 & "', '" & txtd12 & "', '" & txte12 & "', '" & txta13 & "', '" & txtb13 & "', '" & txtc13 & "', '" & txtd13 & "', '" & txte13 & "', '" & txta14 & "', '" & txtb14 & "', '" & txtc14 & "', '" & txtd14 & "', '" & txte14 & "', '" & txta15 & "', '" & txtb15 & "', '" & txtc15 & "', '" & txtd15 & "', '" & txte15 & "', '" & txta16 & "', '" & txtb16 & "', '" & txtc16 & "', '" & txtd16 & "', '" & txte16 & "', '" & txta17 & "', '" & txtb17 & "', '" & txtc17 & "', '" & txtd17 & "', '" & txte17 & "', '" & txta18 & "', '" & txtb18 & "', '" & txtc18 & "', '" & txtd18 & "', '" & txte18 & "', '" & tok1 & "', '" & tok2 & "', '" & ymdbirth & "')"
        cnn.Execute(SQL)

        cnn.Close()

        FormUpdate()

    End Sub

    Private Sub Tuika()
        Dim nam, ymd, fstymd, nyuymd, kei, nin, author, tanto, kai, kaitxt, iko1, iko2, risk, kad1, kad2, kad3, tyo1, tyo2, txta1, txtb1, txtc1, txtd1, txte1, txta2, txtb2, txtc2, txtd2, txte2, txta3, txtb3, txtc3, txtd3, txte3, txta4, txtb4, txtc4, txtd4, txte4, txta5, txtb5, txtc5, txtd5, txte5, txta6, txtb6, txtc6, txtd6, txte6, txta7, txtb7, txtc7, txtd7, txte7, txta8, txtb8, txtc8, txtd8, txte8, txta9, txtb9, txtc9, txtd9, txte9, txta10, txtb10, txtc10, txtd10, txte10, txta11, txtb11, txtc11, txtd11, txte11, txta12, txtb12, txtc12, txtd12, txte12, txta13, txtb13, txtc13, txtd13, txte13, txta14, txtb14, txtc14, txtd14, txte14, txta15, txtb15, txtc15, txtd15, txte15, txta16, txtb16, txtc16, txtd16, txte16, txta17, txtb17, txtc17, txtd17, txte17, txta18, txtb18, txtc18, txtd18, txte18, tok1, tok2, ymdbirth As String
        nam = lblName.Text
        ymd = Strings.Left(YmdBox1.getADStr(), 10)
        If txtKei.Text <> "1" AndAlso txtKei.Text <> "2" AndAlso txtKei.Text <> "3" Then
            MsgBox("初回・紹介・継続を正しく入力してください")
            txtKei.Focus()
            Return
        Else
            kei = txtKei.Text
        End If
        If txtNin.Text <> "1" AndAlso txtNin.Text <> "2" Then
            MsgBox("認定済・申請中を正しく入力してください")
            txtNin.Focus()
            Return
        Else
            nin = txtNin.Text
        End If
        If cmbAuthor.Text = "" Then
            MsgBox("作成者を入力してください")
            cmbAuthor.Focus()
            Return
        Else
            author = cmbAuthor.Text
        End If
        If ymdboxNyuymd.getADStr() = "" Then
            MsgBox("入所（院）日を正しく入力してください")
            ymdboxNyuymd.Focus()
            Return
        Else
            nyuymd = ymdboxNyuymd.getADStr()
        End If
        If ymdboxFstymd.getADStr() = "" Then
            MsgBox("初回作成日を正しく入力してください")
            ymdboxFstymd.Focus()
            Return
        Else
            fstymd = ymdboxFstymd.getADStr()
        End If
        If txtTanto.Text = "" Then
            MsgBox("担当者を入力してください")
            txtTanto.Focus()
            Return
        Else
            tanto = txtTanto.Text
        End If
        If txtKai.Text = "" Then
            kai = 0
        Else
            kai = txtKai.Text
        End If
        kaitxt = txtKaitxt.Text
        iko1 = txtIko1.Text
        iko2 = txtIko2.Text
        If txtRisk.Text = "" Then
            risk = 0
        Else
            risk = txtRisk.Text
        End If
        kad1 = txtKad1.Text
        kad2 = txtKad2.Text
        kad3 = txtKad3.Text
        tyo1 = txtTyo1.Text
        tyo2 = txtTyo2.Text
        txta1 = DataGridView2(0, 0).Value
        txtb1 = DataGridView2(1, 0).Value
        txtc1 = DataGridView2(2, 0).Value
        txtd1 = DataGridView2(3, 0).Value
        txte1 = cmbTxte1.Text
        txta2 = DataGridView2(0, 1).Value
        txtb2 = DataGridView2(1, 1).Value
        txtc2 = DataGridView2(2, 1).Value
        txtd2 = DataGridView2(3, 1).Value
        txte2 = txtTxte2.Text
        txta3 = DataGridView2(0, 2).Value
        txtb3 = DataGridView2(1, 2).Value
        txtc3 = DataGridView2(2, 2).Value
        txtd3 = DataGridView2(3, 2).Value
        txte3 = txtTxte3.Text
        txta4 = DataGridView2(0, 3).Value
        txtb4 = DataGridView2(1, 3).Value
        txtc4 = DataGridView2(2, 3).Value
        txtd4 = DataGridView2(3, 3).Value
        txte4 = cmbTxte4.Text
        txta5 = DataGridView2(0, 4).Value
        txtb5 = DataGridView2(1, 4).Value
        txtc5 = DataGridView2(2, 4).Value
        txtd5 = DataGridView2(3, 4).Value
        txte5 = txtTxte5.Text
        txta6 = DataGridView2(0, 5).Value
        txtb6 = DataGridView2(1, 5).Value
        txtc6 = DataGridView2(2, 5).Value
        txtd6 = DataGridView2(3, 5).Value
        txte6 = txtTxte6.Text
        txta7 = DataGridView2(0, 6).Value
        txtb7 = DataGridView2(1, 6).Value
        txtc7 = DataGridView2(2, 6).Value
        txtd7 = DataGridView2(3, 6).Value
        txte7 = cmbTxte7.Text
        txta8 = DataGridView2(0, 7).Value
        txtb8 = DataGridView2(1, 7).Value
        txtc8 = DataGridView2(2, 7).Value
        txtd8 = DataGridView2(3, 7).Value
        txte8 = txtTxte8.Text
        txta9 = DataGridView2(0, 8).Value
        txtb9 = DataGridView2(1, 8).Value
        txtc9 = DataGridView2(2, 8).Value
        txtd9 = DataGridView2(3, 8).Value
        txte9 = txtTxte9.Text
        txta10 = DataGridView2(0, 9).Value
        txtb10 = DataGridView2(1, 9).Value
        txtc10 = DataGridView2(2, 9).Value
        txtd10 = DataGridView2(3, 9).Value
        txte10 = cmbTxte10.Text
        txta11 = DataGridView2(0, 10).Value
        txtb11 = DataGridView2(1, 10).Value
        txtc11 = DataGridView2(2, 10).Value
        txtd11 = DataGridView2(3, 10).Value
        txte11 = txtTxte11.Text
        txta12 = DataGridView2(0, 11).Value
        txtb12 = DataGridView2(1, 11).Value
        txtc12 = DataGridView2(2, 11).Value
        txtd12 = DataGridView2(3, 11).Value
        txte12 = txtTxte12.Text
        txta13 = DataGridView2(0, 12).Value
        txtb13 = DataGridView2(1, 12).Value
        txtc13 = DataGridView2(2, 12).Value
        txtd13 = DataGridView2(3, 12).Value
        txte13 = cmbTxte13.Text
        txta14 = DataGridView2(0, 13).Value
        txtb14 = DataGridView2(1, 13).Value
        txtc14 = DataGridView2(2, 13).Value
        txtd14 = DataGridView2(3, 13).Value
        txte14 = txtTxte14.Text
        txta15 = DataGridView2(0, 14).Value
        txtb15 = DataGridView2(1, 14).Value
        txtc15 = DataGridView2(2, 14).Value
        txtd15 = DataGridView2(3, 14).Value
        txte15 = txtTxte15.Text
        txta16 = DataGridView2(0, 15).Value
        txtb16 = DataGridView2(1, 15).Value
        txtc16 = DataGridView2(2, 15).Value
        txtd16 = DataGridView2(3, 15).Value
        txte16 = cmbTxte16.Text
        txta17 = DataGridView2(0, 16).Value
        txtb17 = DataGridView2(1, 16).Value
        txtc17 = DataGridView2(2, 16).Value
        txtd17 = DataGridView2(3, 16).Value
        txte17 = txtTxte17.Text
        txta18 = DataGridView2(0, 17).Value
        txtb18 = DataGridView2(1, 17).Value
        txtc18 = DataGridView2(2, 17).Value
        txtd18 = DataGridView2(3, 17).Value
        txte18 = txtTxte18.Text
        tok1 = txtTok1.Text
        tok2 = txtTok2.Text
        ymdbirth = birth

        If MsgBox("新規登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.No Then
            Return
        End If
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim SQL As String = ""
        SQL = "INSERT INTO Dat2 VALUES ('" & nam & "', '" & ymd & "', '" & fstymd & "', '" & nyuymd & "', " & kei & ", " & nin & ", '" & author & "', '" & tanto & "', " & kai & ", '" & kaitxt & "', '" & iko1 & "', '" & iko2 & "', " & risk & ", '" & kad1 & "', '" & kad2 & "', '" & kad3 & "', '" & tyo1 & "', '" & tyo2 & "', '" & txta1 & "', '" & txtb1 & "', '" & txtc1 & "', '" & txtd1 & "', '" & txte1 & "', '" & txta2 & "', '" & txtb2 & "', '" & txtc2 & "', '" & txtd2 & "', '" & txte2 & "', '" & txta3 & "', '" & txtb3 & "', '" & txtc3 & "', '" & txtd3 & "', '" & txte3 & "', '" & txta4 & "', '" & txtb4 & "', '" & txtc4 & "', '" & txtd4 & "', '" & txte4 & "', '" & txta5 & "', '" & txtb5 & "', '" & txtc5 & "', '" & txtd5 & "', '" & txte5 & "', '" & txta6 & "', '" & txtb6 & "', '" & txtc6 & "', '" & txtd6 & "', '" & txte6 & "', '" & txta7 & "', '" & txtb7 & "', '" & txtc7 & "', '" & txtd7 & "', '" & txte7 & "', '" & txta8 & "', '" & txtb8 & "', '" & txtc8 & "', '" & txtd8 & "', '" & txte8 & "', '" & txta9 & "', '" & txtb9 & "', '" & txtc9 & "', '" & txtd9 & "', '" & txte9 & "', '" & txta10 & "', '" & txtb10 & "', '" & txtc10 & "', '" & txtd10 & "', '" & txte10 & "', '" & txta11 & "', '" & txtb11 & "', '" & txtc11 & "', '" & txtd11 & "', '" & txte11 & "', '" & txta12 & "', '" & txtb12 & "', '" & txtc12 & "', '" & txtd12 & "', '" & txte12 & "', '" & txta13 & "', '" & txtb13 & "', '" & txtc13 & "', '" & txtd13 & "', '" & txte13 & "', '" & txta14 & "', '" & txtb14 & "', '" & txtc14 & "', '" & txtd14 & "', '" & txte14 & "', '" & txta15 & "', '" & txtb15 & "', '" & txtc15 & "', '" & txtd15 & "', '" & txte15 & "', '" & txta16 & "', '" & txtb16 & "', '" & txtc16 & "', '" & txtd16 & "', '" & txte16 & "', '" & txta17 & "', '" & txtb17 & "', '" & txtc17 & "', '" & txtd17 & "', '" & txte17 & "', '" & txta18 & "', '" & txtb18 & "', '" & txtc18 & "', '" & txtd18 & "', '" & txte18 & "', '" & tok1 & "', '" & tok2 & "', '" & ymdbirth & "')"
        cnn.Execute(SQL)

        cnn.Close()

        FormUpdate()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim selectedRow As Integer = If(IsNothing(DataGridView1.CurrentRow), -1, DataGridView1.CurrentRow.Index)
        If selectedRow = -1 Then
            MsgBox("削除対象の行が選択されていません。")
            Return
        End If

        Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To DGV1rowcount - 1
            If YmdBox1.getADStr() = DataGridView1(1, i).Value Then
                If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
                    Dim cnn As New ADODB.Connection
                    cnn.Open(topform.DB_NCare)

                    Dim SQL As String = ""

                    SQL = "DELETE FROM Dat2 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBox1.getADStr() & "'"

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
        Dim selectedRow As Integer = If(IsNothing(DataGridView1.CurrentRow), -1, DataGridView1.CurrentRow.Index)
        If selectedRow = -1 Then
            MsgBox("印刷するデータを選択してください。")
            Return
        End If

        Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
        For row As Integer = 0 To DGV1rowcount - 1
            If YmdBox1.getADStr() = DataGridView1(1, row).Value Then
                Dim cnn As New ADODB.Connection
                Dim rs As New ADODB.Recordset
                Dim sql As String = "select * from Dat2 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBox1.getADStr() & "' AND NyuYmd = '" & ymdboxNyuymd.getADStr() & "' AND Birth = '" & birth & "'"
                cnn.Open(topform.DB_NCare)
                rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)

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
                oSheet = objWorkBook.Worksheets("計画書２改")

                oSheet.Range("B7").Value = "利用者名 ;　 " & rs.Fields("Nam").Value
                oSheet.Range("I7").Value = "生年月日 ;　 " & Util.getKanji(Util.convADStrToWarekiStr(birth)) & Strings.Mid(Util.convADStrToWarekiStr(birth), 2, 2) & "年" & Strings.Mid(birth, 6, 2) & "月" & Strings.Right(birth, 2) & "日"
                oSheet.Range("Q7").Value = jyuusyo
                oSheet.Range("S10").Value = Util.getKanji(Util.convADStrToWarekiStr(rs.Fields("Ymd").Value)) & Strings.Mid(Util.convADStrToWarekiStr(rs.Fields("Ymd").Value), 2, 2) & "年" & Strings.Mid(rs.Fields("Ymd").Value, 6, 2) & "月" & Strings.Right(rs.Fields("Ymd").Value, 2) & "日"
                oSheet.Range("S9").Value = Util.getKanji(Util.convADStrToWarekiStr(rs.Fields("FstYmd").Value)) & Strings.Mid(Util.convADStrToWarekiStr(rs.Fields("FstYmd").Value), 2, 2) & "年" & Strings.Mid(rs.Fields("FstYmd").Value, 6, 2) & "月" & Strings.Right(rs.Fields("FstYmd").Value, 2) & "日"
                oSheet.Range("S8").Value = Util.getKanji(Util.convADStrToWarekiStr(rs.Fields("NyuYmd").Value)) & Strings.Mid(Util.convADStrToWarekiStr(rs.Fields("NyuYmd").Value), 2, 2) & "年" & Strings.Mid(rs.Fields("NyuYmd").Value, 6, 2) & "月" & Strings.Right(rs.Fields("NyuYmd").Value, 2) & "日"
                If rs.Fields("Kei").Value = 1 Then
                    oSheet.Range("O4").Value = "ﾚ"
                ElseIf rs.Fields("Kei").Value = 2 Then
                    oSheet.Range("Q4").Value = "ﾚ"
                ElseIf rs.Fields("Kei").Value = 3 Then
                    oSheet.Range("S4").Value = "ﾚ"
                Else

                End If
                If rs.Fields("Nin").Value = 1 Then
                    oSheet.Range("V4").Value = "ﾚ"
                ElseIf rs.Fields("Nin").Value = 2 Then
                    oSheet.Range("X4").Value = "ﾚ"
                Else

                End If
                oSheet.Range("D8").Value = rs.Fields("Author").Value
                oSheet.Range("D10").Value = rs.Fields("Tanto").Value
                If rs.Fields("kai").Value = 1 Then
                    oSheet.Range("D13").Value = "ﾚ"
                ElseIf rs.Fields("Kai").Value = 2 Then
                    oSheet.Range("F13").Value = "ﾚ"
                ElseIf rs.Fields("Kai").Value = 3 Then
                    oSheet.Range("H13").Value = "ﾚ"
                ElseIf rs.Fields("Kai").Value = 4 Then
                    oSheet.Range("J13").Value = "ﾚ"
                ElseIf rs.Fields("Kai").Value = 5 Then
                    oSheet.Range("L13").Value = "ﾚ"
                Else

                End If
                oSheet.Range("Q13").Value = rs.Fields("KaiTxt").Value
                oSheet.Range("D16").Value = rs.Fields("Iko1").Value
                oSheet.Range("D17").Value = rs.Fields("Iko2").Value
                If rs.Fields("Risk").Value = 1 Then
                    oSheet.Range("F19").Value = "ﾚ"
                ElseIf rs.Fields("Risk").Value = 2 Then
                    oSheet.Range("H19").Value = "ﾚ"
                ElseIf rs.Fields("Risk").Value = 3 Then
                    oSheet.Range("J19").Value = "ﾚ"
                Else

                End If
                For i As Integer = 13 To 17
                    oSheet.Range("D" & i + 8).Value = rs.Fields(i).Value
                Next
                For i As Integer = 1 To 18
                    oSheet.Range("B" & i + 27).Value = rs.Fields(i * 5 + 13).Value
                    oSheet.Range("F" & i + 27).Value = rs.Fields(i * 5 + 14).Value
                    oSheet.Range("S" & i + 27).Value = rs.Fields(i * 5 + 15).Value
                    oSheet.Range("V" & i + 27).Value = rs.Fields(i * 5 + 16).Value
                    oSheet.Range("X" & i + 27).Value = rs.Fields(i * 5 + 17).Value
                Next
                oSheet.Range("Q46").Value = rs.Fields("Tok1").Value
                oSheet.Range("Q47").Value = rs.Fields("Tok2").Value

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

                Exit Sub
            End If
        Next
        MsgBox("計画書は登録されていません")

        

    End Sub

    Private Sub FormUpdate()
        btnClear.PerformClick()

        KeyPreview = True

        Util.EnableDoubleBuffering(DataGridView1)

        DataGridView1.RowTemplate.Height = 15

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select * from Dat2 WHERE Nam = '" & lblName.Text & "' AND Birth =  '" & birth & "' order by Ymd DESC"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 0 To 110
            If i <> 1 Then
                DataGridView1.Columns(i).Visible = False
            End If
        Next
        DataGridView1.Columns(1).Width = 70

        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))
    End Sub

   
End Class