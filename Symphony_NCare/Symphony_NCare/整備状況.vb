Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 整備状況
    Private DGV1Table As DataTable
    Private frmAsemoni As アセモニ
    Private frmKannfarennsu As カンファレンス
    Private frmSukuri As スクリーニング書
    Private frmKeikakusyo As 計画書
    Private Birth As String
    Private Jyuusyo As String
    Private Sub 整備状況_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Util.EnableDoubleBuffering(DataGridView1)

        With DataGridView1
            .RowTemplate.Height = 18
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With

        DGV1Table = New DataTable()
        '列作成
        For col As Integer = 0 To 11
            DGV1Table.Columns.Add("a" & col, Type.GetType("System.String"))
        Next
        '行作成
        For row As Integer = 0 To 199
            DGV1Table.Rows.Add(DGV1Table.NewRow())
        Next
        '空を表示
        DataGridView1.DataSource = DGV1Table

        For col As Integer = 0 To DataGridView1.ColumnCount - 1
            If col = 0 Then
                DataGridView1.Columns(col).Width = 25
            ElseIf col = 1 Then
                DataGridView1.Columns(col).Width = 85
            Else
                DataGridView1.Columns(col).Width = 70
            End If
        Next
        With DataGridView1
            .Columns(0).HeaderText = ""
            .Columns(1).HeaderText = "利用者"
            .Columns(2).HeaderText = "ｽｸﾘｰﾆﾝｸﾞ"
            .Columns(3).HeaderText = "ｱｾｽﾒﾝﾄⅠ"
            .Columns(3).Visible = False
            .Columns(4).HeaderText = "ｱｾｽﾒﾝﾄⅡ"
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "計画書"
            .Columns(6).HeaderText = "ﾘｽｸ判定"
            .Columns(7).HeaderText = "同意書"
            .Columns(7).DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 252)
            .Columns(8).HeaderText = "ｶﾝﾌｧﾚﾝｽ"
            .Columns(9).HeaderText = "初回ﾁｪｯｸ"
            .Columns(9).DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 252)
            .Columns(10).HeaderText = "ﾌﾟﾛｸﾞﾚｽ"
            .Columns(10).Visible = False
            .Columns(11).HeaderText = "ｱｾﾓﾆ"
        End With

        For i As Integer = 0 To 11
            If i <> 7 AndAlso i <> 9 Then
                DataGridView1.Columns(i).ReadOnly = True
            End If
            If i <> 1 Then
                DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        For num As Integer = 0 To 199
            DataGridView1(0, num).Value = num + 1
        Next

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable

        SQLCm2.CommandText = "select Nam, Kana, Birth, Jyu from UsrM WHERE Unit <> '海' and Hyo = '1' order by Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

    End Sub

    Private Sub btnHyouji_Click(sender As System.Object, e As System.EventArgs) Handles btnHyouji.Click
        ProgressBar1.Visible = True
        Label2.Visible = True
        ProgressBar1.Maximum = 10
        ProgressBar1.Minimum = 0

        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        ProgressBar1.Value = 1
        '名前セット
        Dim sql As String = "select Nam, Kana, Unit, Hyo from UsrM WHERE Unit <> '海' AND Hyo = '1' order by Kana"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        Dim row As Integer = 0
        While Not rs.EOF
            DGV1Table.Rows(row).Item("a1") = rs.Fields("Nam").Value
            rs.MoveNext()
            row = row + 1
        End While
        cnn.Close()
        ProgressBar1.Value = 2
        '利用者の人数確認
        Dim PersonCount As Integer = 0
        For i As Integer = 0 To 199
            If Util.checkDBNullValue(DataGridView1(1, i).Value) <> "" Then
                PersonCount = PersonCount + 1
            End If
        Next
        ProgressBar1.Value = 3
        'スクリーニングセット
        sql = "select Nam, max(Ymd) as YmdMax from Dat0 group by Nam"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            For i As Integer = 0 To PersonCount - 1
                If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
                    DGV1Table.Rows(i).Item("a2") = rs.Fields("YmdMax").Value
                End If
            Next
            rs.MoveNext()
        End While
        cnn.Close()
        ''ｱｾｽﾒﾝﾄ書Ⅰセット
        'sql = "select Nam, max(Ymd) as YmdMax, YmdJ from Dat6 group by Nam"
        'cnn.Open(topform.DB_NCare)
        'rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        'While Not rs.EOF
        '    For i As Integer = 0 To PersonCount - 1
        '        If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
        '            DGV1Table.Rows(i).Item("a3") = rs.Fields("YmdJ").Value
        '        End If
        '    Next
        '    rs.MoveNext()
        'End While
        'cnn.Close()
        ''ｱｾｽﾒﾝﾄ書Ⅱセット
        'sql = "select Nam, max(Ymd) as YmdMax from Dat6 group by Nam"
        'cnn.Open(topform.DB_NCare)
        'rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        'While Not rs.EOF
        '    For i As Integer = 0 To PersonCount - 1
        '        If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
        '            DGV1Table.Rows(i).Item("a4") = rs.Fields("YmdMax").Value
        '        End If
        '    Next
        '    rs.MoveNext()
        'End While
        'cnn.Close()
        ProgressBar1.Value = 4
        '計画書セット
        sql = "select Nam, max(Ymd) as YmdMax from Dat2 group by Nam"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            For i As Integer = 0 To PersonCount - 1
                If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
                    DGV1Table.Rows(i).Item("a5") = rs.Fields("YmdMax").Value
                End If
            Next
            rs.MoveNext()
        End While
        cnn.Close()
        ProgressBar1.Value = 5
        'ﾘｽｸ判定セット
        For r As Integer = 0 To PersonCount - 1
            sql = "select Nam, Ymd, YmdJ, Risk from Dat0 WHERE Nam = '" & DataGridView1(1, r).Value & "' Order by Ymd DESC, YmdJ DESC"
            cnn.Open(topform.DB_NCare)
            rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            DGV1Table.Rows(r).Item("a6") = rs.Fields("Risk").Value
            cnn.Close()

            If r = PersonCount / 2 Then
                ProgressBar1.Value = 6
            End If
            'If r = PersonCount * 1 / 5 Then
            '    ProgressBar1.Value = 2
            'ElseIf r = PersonCount * 2 / 5 Then
            '    ProgressBar1.Value = 3
            'ElseIf r = PersonCount * 3 / 5 Then
            '    ProgressBar1.Value = 4
            'ElseIf r = PersonCount * 4 / 5 Then
            '    ProgressBar1.Value = 5
            'ElseIf r = PersonCount Then
            '    ProgressBar1.Value = 6
            'End If
        Next
        ProgressBar1.Value = 7
        '同意書セット
        sql = "select * from Dat14"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            For i As Integer = 0 To PersonCount - 1
                If DataGridView1(1, i).Value = rs.Fields("Nam").Value AndAlso rs.Fields("Apt").Value = 1 Then
                    DGV1Table.Rows(i).Item("a7") = "○"
                ElseIf DataGridView1(1, i).Value = rs.Fields("Nam").Value AndAlso rs.Fields("Apt").Value = 0 Then
                    DGV1Table.Rows(i).Item("a7") = ""
                End If
            Next
            rs.MoveNext()
        End While
        cnn.Close()
        ProgressBar1.Value = 8
        'ｶﾝﾌｧﾚﾝｽセット
        sql = "select Nam, max(Kai) as KaiMax from Dat5 group by Nam"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            For i As Integer = 0 To PersonCount - 1
                If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
                    DGV1Table.Rows(i).Item("a8") = rs.Fields("KaiMax").Value
                End If
            Next
            rs.MoveNext()
        End While
        cnn.Close()
        ProgressBar1.Value = 9
        '初回ﾁｪｯｸセット
        sql = "select * from Dat14"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            For i As Integer = 0 To PersonCount - 1
                If DataGridView1(1, i).Value = rs.Fields("Nam").Value AndAlso rs.Fields("Fst").Value = 1 Then
                    DGV1Table.Rows(i).Item("a9") = "○"
                ElseIf DataGridView1(1, i).Value = rs.Fields("Nam").Value AndAlso rs.Fields("Fst").Value = 0 Then
                    DGV1Table.Rows(i).Item("a9") = ""
                End If
            Next
            rs.MoveNext()
        End While
        cnn.Close()
        ''ﾌﾟﾛｸﾞﾚｽセット
        'sql = "select Nam, max(Ymd) as YmdMax from Dat7 group by Nam"
        'cnn.Open(topform.DB_NCare)
        'rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        'While Not rs.EOF
        '    For i As Integer = 0 To PersonCount - 1
        '        If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
        '            DGV1Table.Rows(i).Item("a10") = rs.Fields("YmdMax").Value
        '        End If
        '    Next
        '    rs.MoveNext()
        'End While
        'cnn.Close()
        ProgressBar1.Value = 10
        'ｱｾﾓﾆセット
        sql = "select Nam, max(Ymd) as YmdMax from Asses group by Nam"
        cnn.Open(topform.DB_NCare)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            For i As Integer = 0 To PersonCount - 1
                If DataGridView1(1, i).Value = rs.Fields("Nam").Value Then
                    DGV1Table.Rows(i).Item("a11") = rs.Fields("YmdMax").Value
                End If
            Next
            rs.MoveNext()
        End While
        cnn.Close()

        ProgressBar1.Visible = False
        Label2.Visible = False

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = 2 OrElse e.ColumnIndex = 3 OrElse e.ColumnIndex = 4 OrElse e.ColumnIndex = 5 OrElse e.ColumnIndex = 11 Then
            e.Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(e.Value))
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim cell As DataGridViewCell = DataGridView1.CurrentCell

        Dim nam As String = Util.checkDBNullValue(DataGridView1(1, cell.RowIndex).Value)
        Dim DGV2rowcount As Integer = DataGridView2.Rows.Count
        For i As Integer = 0 To DGV2rowcount - 1
            If nam = DataGridView2(1, i).Value Then
                Dim Birth As String = Util.checkDBNullValue(DataGridView1(3, i).Value)
                Dim Jyuusyo As String = Util.checkDBNullValue(DataGridView1(4, i).Value)
            End If
        Next

        If cell.ColumnIndex = 2 Then
            If nam = "" Then

            Else
                If IsNothing(frmSukuri) OrElse frmSukuri.IsDisposed Then
                    frmSukuri = New スクリーニング書()
                    frmSukuri.Owner = Me
                    frmSukuri.Show()
                End If
            End If
        ElseIf cell.ColumnIndex = 5 Then
            If nam = "" Then

            Else
                If IsNothing(frmKeikakusyo) OrElse frmKeikakusyo.IsDisposed Then
                    frmKeikakusyo = New 計画書(nam, Birth, Jyuusyo)
                    frmKeikakusyo.Owner = Me
                    frmKeikakusyo.Show()
                End If
            End If
        ElseIf cell.ColumnIndex = 6 Then
            If nam = "" Then

            Else
                If IsNothing(frmSukuri) OrElse frmSukuri.IsDisposed Then
                    frmSukuri = New スクリーニング書()
                    frmSukuri.Owner = Me
                    frmSukuri.Show()
                End If
            End If
        ElseIf cell.ColumnIndex = 8 Then
            If nam = "" Then

            Else
                If IsNothing(frmKannfarennsu) OrElse frmKannfarennsu.IsDisposed Then
                    frmKannfarennsu = New カンファレンス(nam)
                    frmKannfarennsu.Owner = Me
                    frmKannfarennsu.Show()
                End If
            End If
        ElseIf cell.ColumnIndex = 11 Then
            If nam = "" Then

            Else
                If IsNothing(frmSukuri) OrElse frmSukuri.IsDisposed Then
                    frmAsemoni = New アセモニ()
                    frmAsemoni.Owner = Me
                    frmAsemoni.Show()
                End If
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

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        cnn.Open(topform.DB_NCare)

        Dim SQL As String = ""
        SQL = "DELETE FROM Dat14"
        cnn.Execute(SQL)

        rs.Open("Dat14", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        Dim personcount As Integer = 0
        For i As Integer = 0 To 199
            If Util.checkDBNullValue(DataGridView1(1, i).Value) <> "" Then
                personcount = personcount + 1
            Else
                Exit For
            End If
        Next

        For i As Integer = 0 To personcount - 1
            rs.AddNew()
            rs.Fields("Nam").Value = Util.checkDBNullValue(DataGridView1(1, i).Value)
            If Util.checkDBNullValue(DataGridView1(7, i).Value) = "○" Then
                rs.Fields("Apt").Value = 1
            ElseIf Util.checkDBNullValue(DataGridView1(7, i).Value) = "" Then
                rs.Fields("Apt").Value = 0
            End If
            If Util.checkDBNullValue(DataGridView1(9, i).Value) = "○" Then
                rs.Fields("Fst").Value = 1
            ElseIf Util.checkDBNullValue(DataGridView1(9, i).Value) = "" Then
                rs.Fields("Fst").Value = 0
            End If
        Next
        rs.Update()

        cnn.Close()

    End Sub

    Private Sub btnInnsatu_Click(sender As System.Object, e As System.EventArgs) Handles btnInnsatu.Click
        Dim DGV1rowscount As Integer = DataGridView1.Rows.Count
        Dim personcount As Integer = 0
        For i As Integer = 0 To 199
            If Util.checkDBNullValue(DataGridView1(1, i).Value) <> "" Then
                personcount = personcount + 1
            Else
                Exit For
            End If
        Next
        If personcount = 0 Then
            MsgBox("データを表示してください")
            Return
        End If


        Dim objExcel As Object
        Dim objWorkBooks As Object
        Dim objWorkBook As Object
        Dim oSheet As Object
        Dim day As DateTime = DateTime.Today

        objExcel = CreateObject("Excel.Application")
        objWorkBooks = objExcel.Workbooks
        objWorkBook = objWorkBooks.Open(topform.excelFilePass)
        oSheet = objWorkBook.Worksheets("整備状況")

        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        Dim cell(34, 11) As String   '貼り付け用配列

        If 35 < personcount AndAlso personcount <= 70 Then  '2枚目
            Dim xlPasteRange As Excel.Range = oSheet.Range("A40") 'ペースト先
            oSheet.rows("1:39").copy(xlPasteRange)
            oSheet.Range("N78").Value = "2"
        End If
        If 70 < personcount AndAlso personcount <= 105 Then  '3枚目
            Dim xlPasteRange As Excel.Range = oSheet.Range("A40") 'ペースト先
            oSheet.rows("1:39").copy(xlPasteRange)
            Dim xlPasteRange2 As Excel.Range = oSheet.Range("A79") 'ペースト先
            oSheet.rows("1:39").copy(xlPasteRange2)
            oSheet.Range("N78").Value = "2"
            oSheet.Range("N117").Value = "3"
        End If
        If 105 < personcount Then  '4枚目
            Dim xlPasteRange As Excel.Range = oSheet.Range("A40") 'ペースト先
            oSheet.rows("1:39").copy(xlPasteRange)
            Dim xlPasteRange2 As Excel.Range = oSheet.Range("A79") 'ペースト先
            oSheet.rows("1:39").copy(xlPasteRange2)
            Dim xlPasteRange3 As Excel.Range = oSheet.Range("A118") 'ペースト先
            oSheet.rows("1:39").copy(xlPasteRange3)
            oSheet.Range("N78").Value = "2"
            oSheet.Range("N117").Value = "3"
            oSheet.Range("N156").Value = "4"
        End If

        For row As Integer = 0 To 34    '1枚目
            For col As Integer = 0 To 11
                cell(row, col) = Util.checkDBNullValue(DataGridView1(col, row).Value)
            Next
            If row = personcount - 1 OrElse row = 34 Then
                oSheet.Range("B4", "M38").Value = cell
            End If
        Next
        oSheet.Range("N39").Value = "1"
        If 35 < personcount AndAlso personcount <= 70 Then    '2枚目
            Dim cell2(34, 11) As String
            For row As Integer = 0 To 34
                For col As Integer = 0 To 11
                    cell2(row, col) = Util.checkDBNullValue(DataGridView1(col, row + 35).Value)
                Next
                If row = personcount - 1 OrElse row = 34 Then
                    oSheet.Range("B43", "M77").Value = cell2
                End If
            Next
        End If
        If 70 < personcount AndAlso personcount <= 105 Then    '3枚目
            Dim cell2(34, 11) As String
            For row As Integer = 0 To 34
                For col As Integer = 0 To 11
                    cell2(row, col) = Util.checkDBNullValue(DataGridView1(col, row + 35).Value)
                Next
                If row = personcount - 1 OrElse row = 34 Then
                    oSheet.Range("B43", "M77").Value = cell2
                End If
            Next
            Dim cell3(34, 11) As String
            For row As Integer = 0 To 34
                For col As Integer = 0 To 11
                    cell3(row, col) = Util.checkDBNullValue(DataGridView1(col, row + 70).Value)
                Next
                If row = personcount - 1 OrElse row = 34 Then
                    oSheet.Range("B82", "M116").Value = cell3
                End If
            Next
        End If
        If 105 < personcount Then    '4枚目
            Dim cell2(34, 11) As String
            For row As Integer = 0 To 34
                For col As Integer = 0 To 11
                    cell2(row, col) = Util.checkDBNullValue(DataGridView1(col, row + 35).Value)
                Next
                If row = personcount - 1 OrElse row = 34 Then
                    oSheet.Range("B43", "M77").Value = cell2
                End If
            Next
            Dim cell3(34, 11) As String
            For row As Integer = 0 To 34
                For col As Integer = 0 To 11
                    cell3(row, col) = Util.checkDBNullValue(DataGridView1(col, row + 70).Value)
                Next
                If row = personcount - 1 OrElse row = 34 Then
                    oSheet.Range("B82", "M116").Value = cell3
                End If
            Next
            Dim cell4(34, 11) As String
            For row As Integer = 0 To 34
                For col As Integer = 0 To 11
                    cell4(row, col) = Util.checkDBNullValue(DataGridView1(col, row + 105).Value)
                Next
                If row = personcount - 1 OrElse row = 34 Then
                    oSheet.Range("B121", "M155").Value = cell4
                End If
            Next
        End If

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

    Private Sub datagridview1_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If dgv.Columns(e.ColumnIndex).Name = "a7" OrElse dgv.Columns(e.ColumnIndex).Name = "a9" Then
            If Util.checkDBNullValue(dgv(e.ColumnIndex, e.RowIndex).Value) = "1" Then
                dgv(e.ColumnIndex, e.RowIndex).Value = "○"
            End If
        End If
    End Sub

    Private Sub datagridview1_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        '新しい行のセルでなく、セルの内容が変更されている時だけ検証する 
        If e.RowIndex = dgv.NewRowIndex OrElse Not dgv.IsCurrentCellDirty Then
            Exit Sub
        End If

        If dgv.Columns(e.ColumnIndex).Name = "a7" OrElse dgv.Columns(e.ColumnIndex).Name = "a9" Then
            If e.FormattedValue.ToString() <> "" AndAlso e.FormattedValue.ToString() <> "1" Then
                MsgBox("正しく入力してください")
                e.Cancel = True
                DataGridView1.EndEdit()
                dgv(e.ColumnIndex, e.RowIndex).Value = ""
            End If
        End If
    End Sub

End Class