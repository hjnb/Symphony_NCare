Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class カンファレンス
    Private Nam As String
    Public Sub New(frmnam As String)
        InitializeComponent()

        Me.Nam = frmnam
    End Sub
    Private Sub カンファレンス_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblName.Text = Nam

        KeyPreview = True

        Util.EnableDoubleBuffering(DataGridView1)

        DataGridView1.RowTemplate.Height = 15

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select * from Dat5 WHERE Nam = '" & lblName.Text & "' order by Ymd DESC"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 0 To 41
            If i <> 2 Then
                DataGridView1.Columns(i).Visible = False
            End If
        Next
        DataGridView1.Columns(2).Width = 70

        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))

        Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
        lblKaisuu.Text = DGV1rowcount + 1

        TimeBox1.HourText = "00"
        TimeBox1.MinuteText = "00"

    End Sub

    Private Sub カンファレンス_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub FormUpdate()
        btnClear.PerformClick()

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select * from Dat5 WHERE Nam = '" & lblName.Text & "' order by Ymd DESC"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 0 To 41
            If i <> 2 Then
                DataGridView1.Columns(i).Visible = False
            End If
        Next
        DataGridView1.Columns(2).Width = 70

        Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
        lblKaisuu.Text = DGV1rowcount + 1
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = 2 Then
            e.Value = Util.convADStrToWarekiStr(e.Value)
        End If
    End Sub

    Private Sub lstSyokusyu_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstSyokusyu.SelectedIndexChanged
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable
        SQLCm2.CommandText = "select * from EtcM WHERE Yak = '" & lstSyokusyu.Text & "' order by Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count

        lstName.Items.Clear()
        For i As Integer = 0 To DGV2rowcount - 1
            lstName.Items.Add(DataGridView2(5, i).Value)
        Next

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        cmbSakuseisya.Text = ""
        Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
        lblKaisuu.Text = DGV1rowcount + 1
        TimeBox1.HourText = "00"
        TimeBox1.MinuteText = "00"
        For i As Integer = 1 To 8
            Controls("txtSyozoku" & i).Text = ""
            Controls("txtName" & i).Text = ""
            If i < 6 Then
                Controls("txtKou" & i).Text = ""
                Controls("txtNai" & i).Text = ""
                Controls("txtKet" & i).Text = ""
                Controls("txtKad" & i).Text = ""
            End If
        Next
        lblPosition.Text = "0"
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim selectedrow As Integer = DataGridView1.CurrentRow.Index
        lblKaisuu.Text = Util.checkDBNullValue(DataGridView1(1, selectedrow).Value)
        YmdBox1.setADStr(Util.checkDBNullValue(DataGridView1(2, selectedrow).Value))
        Dim time() As String = (Util.checkDBNullValue(DataGridView1(3, selectedrow).Value)).ToString.Split(":")
        If time(0).Length = 1 Then
            TimeBox1.HourText = "0" & time(0)
        Else
            TimeBox1.HourText = time(0)
        End If
        TimeBox1.MinuteText = time(1)
        cmbSakuseisya.Text = Util.checkDBNullValue(DataGridView1(5, selectedrow).Value)
        txtSyozoku1.Text = Util.checkDBNullValue(DataGridView1(6, selectedrow).Value)
        txtName1.Text = Util.checkDBNullValue(DataGridView1(7, selectedrow).Value)
        txtSyozoku2.Text = Util.checkDBNullValue(DataGridView1(8, selectedrow).Value)
        txtName2.Text = Util.checkDBNullValue(DataGridView1(9, selectedrow).Value)
        txtSyozoku3.Text = Util.checkDBNullValue(DataGridView1(10, selectedrow).Value)
        txtName3.Text = Util.checkDBNullValue(DataGridView1(11, selectedrow).Value)
        txtSyozoku4.Text = Util.checkDBNullValue(DataGridView1(12, selectedrow).Value)
        txtName4.Text = Util.checkDBNullValue(DataGridView1(13, selectedrow).Value)
        txtSyozoku5.Text = Util.checkDBNullValue(DataGridView1(14, selectedrow).Value)
        txtName5.Text = Util.checkDBNullValue(DataGridView1(15, selectedrow).Value)
        txtSyozoku6.Text = Util.checkDBNullValue(DataGridView1(16, selectedrow).Value)
        txtName6.Text = Util.checkDBNullValue(DataGridView1(17, selectedrow).Value)
        txtSyozoku7.Text = Util.checkDBNullValue(DataGridView1(18, selectedrow).Value)
        txtName7.Text = Util.checkDBNullValue(DataGridView1(19, selectedrow).Value)
        txtSyozoku8.Text = Util.checkDBNullValue(DataGridView1(20, selectedrow).Value)
        txtName8.Text = Util.checkDBNullValue(DataGridView1(21, selectedrow).Value)
        txtKou1.Text = Util.checkDBNullValue(DataGridView1(22, selectedrow).Value)
        txtKou2.Text = Util.checkDBNullValue(DataGridView1(23, selectedrow).Value)
        txtKou3.Text = Util.checkDBNullValue(DataGridView1(24, selectedrow).Value)
        txtKou4.Text = Util.checkDBNullValue(DataGridView1(25, selectedrow).Value)
        txtKou5.Text = Util.checkDBNullValue(DataGridView1(26, selectedrow).Value)
        txtNai1.Text = Util.checkDBNullValue(DataGridView1(27, selectedrow).Value)
        txtNai2.Text = Util.checkDBNullValue(DataGridView1(28, selectedrow).Value)
        txtNai3.Text = Util.checkDBNullValue(DataGridView1(29, selectedrow).Value)
        txtNai4.Text = Util.checkDBNullValue(DataGridView1(30, selectedrow).Value)
        txtNai5.Text = Util.checkDBNullValue(DataGridView1(31, selectedrow).Value)
        txtket1.Text = Util.checkDBNullValue(DataGridView1(32, selectedrow).Value)
        txtket2.Text = Util.checkDBNullValue(DataGridView1(33, selectedrow).Value)
        txtket3.Text = Util.checkDBNullValue(DataGridView1(34, selectedrow).Value)
        txtket4.Text = Util.checkDBNullValue(DataGridView1(35, selectedrow).Value)
        txtket5.Text = Util.checkDBNullValue(DataGridView1(36, selectedrow).Value)
        txtKad1.Text = Util.checkDBNullValue(DataGridView1(37, selectedrow).Value)
        txtKad2.Text = Util.checkDBNullValue(DataGridView1(38, selectedrow).Value)
        txtKad3.Text = Util.checkDBNullValue(DataGridView1(39, selectedrow).Value)
        txtKad4.Text = Util.checkDBNullValue(DataGridView1(40, selectedrow).Value)
        txtKad5.Text = Util.checkDBNullValue(DataGridView1(41, selectedrow).Value)

    End Sub

    Private Sub txtSyozokuName1_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku1.Enter, txtName1.Enter
        lblPosition.Text = "1"
    End Sub
    Private Sub txtSyozokuName2_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku2.Enter, txtName2.Enter
        lblPosition.Text = "2"
    End Sub
    Private Sub txtSyozokuName3_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku3.Enter, txtName3.Enter
        lblPosition.Text = "3"
    End Sub
    Private Sub txtSyozokuName4_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku4.Enter, txtName4.Enter
        lblPosition.Text = "4"
    End Sub
    Private Sub txtSyozokuName5_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku5.Enter, txtName5.Enter
        lblPosition.Text = "5"
    End Sub
    Private Sub txtSyozokuName6_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku6.Enter, txtName6.Enter
        lblPosition.Text = "6"
    End Sub
    Private Sub txtSyozokuName7_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku7.Enter, txtName7.Enter
        lblPosition.Text = "7"
    End Sub
    Private Sub txtSyozokuName8_Enter(sender As Object, e As System.EventArgs) Handles txtSyozoku8.Enter, txtName8.Enter
        lblPosition.Text = "8"
    End Sub

    Private Sub lstName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstName.SelectedIndexChanged
        For i As Integer = 1 To 8
            If lblPosition.Text = i Then
                Controls("txtSyozoku" & i).Text = lstSyokusyu.Text
                Controls("txtName" & i).Text = lstName.Text
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1(2, i).Value = YmdBox1.getADStr() Then
                Kousin()
                Exit Sub
            End If
        Next
        Tuika()
    End Sub

    Private Sub Kousin()
        Dim nam, kai, ymd, bgnt, endt, tanto, mbrs1, mbrn1, mbrs2, mbrn2, mbrs3, mbrn3, mbrs4, mbrn4, mbrs5, mbrn5, mbrs6, mbrn6, mbrs7, mbrn7, mbrs8, mbrn8, kou1, kou2, kou3, kou4, kou5, nai1, nai2, nai3, nai4, nai5, ket1, ket2, ket3, ket4, ket5, kad1, kad2, kad3, kad4, kad5 As String
        nam = lblName.Text
        kai = Val(lblKaisuu.Text)
        ymd = YmdBox1.getADStr()
        bgnt = TimeBox1.HourText & ":" & TimeBox1.MinuteText & ":00"
        endt = "17:00:00"
        If cmbSakuseisya.Text = "" Then
            MsgBox("作成者を入力してください")
            cmbSakuseisya.Focus()
            Return
        Else
            tanto = cmbSakuseisya.Text
        End If
        mbrs1 = txtSyozoku1.Text
        mbrn1 = txtName1.Text
        mbrs2 = txtSyozoku2.Text
        mbrn2 = txtName2.Text
        mbrs3 = txtSyozoku3.Text
        mbrn3 = txtName3.Text
        mbrs4 = txtSyozoku4.Text
        mbrn4 = txtName4.Text
        mbrs5 = txtSyozoku5.Text
        mbrn5 = txtName5.Text
        mbrs6 = txtSyozoku6.Text
        mbrn6 = txtName6.Text
        mbrs7 = txtSyozoku7.Text
        mbrn7 = txtName7.Text
        mbrs8 = txtSyozoku8.Text
        mbrn8 = txtName8.Text
        kou1 = txtKou1.Text
        kou2 = txtKou2.Text
        kou3 = txtKou3.Text
        kou4 = txtKou4.Text
        kou5 = txtKou5.Text
        nai1 = txtNai1.Text
        nai2 = txtNai2.Text
        nai3 = txtNai3.Text
        nai4 = txtNai4.Text
        nai5 = txtNai5.Text
        ket1 = txtket1.Text
        ket2 = txtket2.Text
        ket3 = txtket3.Text
        ket4 = txtket4.Text
        ket5 = txtket5.Text
        kad1 = txtKad1.Text
        kad2 = txtKad2.Text
        kad3 = txtKad3.Text
        kad4 = txtKad4.Text
        kad5 = txtKad5.Text

        If MsgBox("変更登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(topform.DB_NCare)

            Dim SQL As String = ""
            SQL = "DELETE FROM Dat5 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBox1.getADStr() & "'"
            cnn.Execute(SQL)

            SQL = "INSERT INTO Dat5 VALUES ('" & nam & "', " & kai & ", '" & ymd & "', '" & bgnt & "', '" & endt & "', '" & tanto & "', '" & mbrs1 & "', '" & mbrn1 & "', '" & mbrs2 & "', '" & mbrn2 & "', '" & mbrs3 & "', '" & mbrn3 & "', '" & mbrs4 & "', '" & mbrn4 & "', '" & mbrs5 & "', '" & mbrn5 & "', '" & mbrs6 & "', '" & mbrn6 & "', '" & mbrs7 & "', '" & mbrn7 & "', '" & mbrs8 & "', '" & mbrn8 & "', '" & kou1 & "', '" & kou2 & "', '" & kou3 & "', '" & kou4 & "', '" & kou5 & "', '" & nai1 & "', '" & nai2 & "', '" & nai3 & "', '" & nai4 & "', '" & nai5 & "', '" & ket1 & "', '" & ket2 & "', '" & ket3 & "', '" & ket4 & "', '" & ket5 & "', '" & kad1 & "', '" & kad2 & "', '" & kad3 & "', '" & kad4 & "', '" & kad5 & "')"
            cnn.Execute(SQL)

            cnn.Close()

            FormUpdate()
        End If


    End Sub

    Private Sub Tuika()
        Dim nam, kai, ymd, bgnt, endt, tanto, mbrs1, mbrn1, mbrs2, mbrn2, mbrs3, mbrn3, mbrs4, mbrn4, mbrs5, mbrn5, mbrs6, mbrn6, mbrs7, mbrn7, mbrs8, mbrn8, kou1, kou2, kou3, kou4, kou5, nai1, nai2, nai3, nai4, nai5, ket1, ket2, ket3, ket4, ket5, kad1, kad2, kad3, kad4, kad5 As String
        nam = lblName.Text
        kai = Val(lblKaisuu.Text)
        ymd = YmdBox1.getADStr()
        bgnt = TimeBox1.HourText & ":" & TimeBox1.MinuteText & ":00"
        endt = "17:00:00"
        If cmbSakuseisya.Text = "" Then
            MsgBox("作成者を入力してください")
            cmbSakuseisya.Focus()
            Return
        Else
            tanto = cmbSakuseisya.Text
        End If
        mbrs1 = txtSyozoku1.Text
        mbrn1 = txtName1.Text
        mbrs2 = txtSyozoku2.Text
        mbrn2 = txtName2.Text
        mbrs3 = txtSyozoku3.Text
        mbrn3 = txtName3.Text
        mbrs4 = txtSyozoku4.Text
        mbrn4 = txtName4.Text
        mbrs5 = txtSyozoku5.Text
        mbrn5 = txtName5.Text
        mbrs6 = txtSyozoku6.Text
        mbrn6 = txtName6.Text
        mbrs7 = txtSyozoku7.Text
        mbrn7 = txtName7.Text
        mbrs8 = txtSyozoku8.Text
        mbrn8 = txtName8.Text
        kou1 = txtKou1.Text
        kou2 = txtKou2.Text
        kou3 = txtKou3.Text
        kou4 = txtKou4.Text
        kou5 = txtKou5.Text
        nai1 = txtNai1.Text
        nai2 = txtNai2.Text
        nai3 = txtNai3.Text
        nai4 = txtNai4.Text
        nai5 = txtNai5.Text
        ket1 = txtket1.Text
        ket2 = txtket2.Text
        ket3 = txtket3.Text
        ket4 = txtket4.Text
        ket5 = txtket5.Text
        kad1 = txtKad1.Text
        kad2 = txtKad2.Text
        kad3 = txtKad3.Text
        kad4 = txtKad4.Text
        kad5 = txtKad5.Text

        If MsgBox("新規登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.No Then
            Return
        End If
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim SQL As String = ""
        SQL = "INSERT INTO Dat5 VALUES ('" & nam & "', " & kai & ", '" & ymd & "', '" & bgnt & "', '" & endt & "', '" & tanto & "', '" & mbrs1 & "', '" & mbrn1 & "', '" & mbrs2 & "', '" & mbrn2 & "', '" & mbrs3 & "', '" & mbrn3 & "', '" & mbrs4 & "', '" & mbrn4 & "', '" & mbrs5 & "', '" & mbrn5 & "', '" & mbrs6 & "', '" & mbrn6 & "', '" & mbrs7 & "', '" & mbrn7 & "', '" & mbrs8 & "', '" & mbrn8 & "', '" & kou1 & "', '" & kou2 & "', '" & kou3 & "', '" & kou4 & "', '" & kou5 & "', '" & nai1 & "', '" & nai2 & "', '" & nai3 & "', '" & nai4 & "', '" & nai5 & "', '" & ket1 & "', '" & ket2 & "', '" & ket3 & "', '" & ket4 & "', '" & ket5 & "', '" & kad1 & "', '" & kad2 & "', '" & kad3 & "', '" & kad4 & "', '" & kad5 & "')"
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

        If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(topform.DB_NCare)

            Dim SQL As String = ""

            SQL = "DELETE FROM Dat5 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBox1.getADStr() & "'"

            cnn.Execute(SQL)
            cnn.Close()

            FormUpdate()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim selectedRow As Integer = If(IsNothing(DataGridView1.CurrentRow), -1, DataGridView1.CurrentRow.Index)
        If selectedRow = -1 Then
            MsgBox("印刷するデータを選択してください。")
            Return
        End If

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
        oSheet = objWorkBook.Worksheets("カンファレンス医療改")

        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        Dim Hiduke As String = Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(2, selectedRow).Value))
        Dim time() As String = (Util.checkDBNullValue(DataGridView1(3, selectedRow).Value)).ToString.Split(":")
        oSheet.Range("C4").Value = Util.checkDBNullValue(DataGridView1(0, selectedRow).Value)
        oSheet.Range("C6").Value = Strings.Left(Hiduke, 3) & "年" & Strings.Mid(Hiduke, 5, 2) & "月" & Strings.Right(Hiduke, 2) & "日"
        oSheet.Range("F6").Value = time(0) & ":" & time(1) & "～"
        oSheet.Range("H6").Value = "開催回数　" & Util.checkDBNullValue(DataGridView1(1, selectedRow).Value)
        Dim cell1(3, 1) As String
        For row As Integer = 0 To 3
            For col As Integer = 0 To 1
                cell1(row, col) = Util.checkDBNullValue(DataGridView1((row * 2) + 6 + col, selectedRow).Value)
            Next
        Next
        oSheet.Range("D9", "F12").Value = cell1
        Dim cell2(3, 1) As String
        For row As Integer = 0 To 3
            For col As Integer = 0 To 1
                cell2(row, col) = Util.checkDBNullValue(DataGridView1((row * 2) + 14 + col, selectedRow).Value)
            Next
        Next
        oSheet.Range("G9", "H12").Value = cell2
        Dim cell3(19, 0) As String
        For row As Integer = 0 To 19
            cell3(row, 0) = Util.checkDBNullValue(DataGridView1(row + 22, selectedRow).Value)
        Next
        oSheet.Range("D13", "D32").Value = cell3
        oSheet.Range("H34").Value = Util.checkDBNullValue(DataGridView1(5, selectedRow).Value)

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
    End Sub
End Class