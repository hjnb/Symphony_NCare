Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.Text

Public Class 食札
    Private DGV3Table As DataTable
    Private frmPrint As 食札印刷
    Private Sub 食札_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Util.EnableDoubleBuffering(DataGridView1)

        lblUnit.Text = ""
        lblName.Text = ""
        lblHurigana.Text = ""

        DataGridView1.RowTemplate.Height = 18

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select Unit, Kana, Nam, Hyo from UsrM Where Unit <> '海' AND Hyo = '1' order by Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        Dim TextColumn As New DataGridViewTextBoxColumn
        DataGridView1.Columns.Insert(4, TextColumn)
        TextColumn.Name = "Print"
        TextColumn.HeaderText = "印刷対象"

        DataGridView1.Columns(0).Visible = False    'Unit
        DataGridView1.Columns(1).Visible = False    'Kana
        DataGridView1.Columns(2).Width = 85         'Nam
        DataGridView1.Columns(3).Visible = False    'Hyo
        DataGridView1.Columns(4).Width = 18         'Print

        DataGridView2.RowTemplate.Height = 18

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable
        SQLCm2.CommandText = "select Unit, Kana, Nam, Hyo from UsrM Where Unit = '海' AND Hyo = '1' order by Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        Dim TextColumn2 As New DataGridViewTextBoxColumn
        DataGridView2.Columns.Insert(4, TextColumn2)
        TextColumn2.Name = "Print"
        TextColumn2.HeaderText = "印刷対象"

        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).Visible = False
        DataGridView2.Columns(2).Width = 85
        DataGridView2.Columns(3).Visible = False
        DataGridView2.Columns(4).Width = 18

        Util.EnableDoubleBuffering(DataGridView3)

        DGV3Table = New DataTable()

        With DataGridView3
            .RowTemplate.Height = 16
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
            .EditMode = DataGridViewEditMode.EditOnEnter 'フォーカスが当たったら編集モード
        End With

        '列作成
        DGV3Table.Columns.Add("a", Type.GetType("System.String"))
        '行作成
        For i As Integer = 1 To 10
            DGV3Table.Rows.Add(DGV3Table.NewRow())
        Next
        '空を表示
        DataGridView3.DataSource = DGV3Table

        DataGridView3.Columns(0).Width = 300

        DataGridView3(0, 0).Selected = False

        Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
        Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
        Dim Table5 As New DataTable
        SQLCm5.CommandText = "select * from Dat15Prnt"
        Adapter5.Fill(Table5)
        DataGridView5.DataSource = Table5

        Dim DGV1rowscount As Integer = DataGridView1.Rows.Count
        Dim DGV2rowscount As Integer = DataGridView2.Rows.Count
        Dim DGV5rowscount As Integer = DataGridView5.Rows.Count
        For DGV1index As Integer = 0 To DGV1rowscount - 1
            For DGV5index As Integer = 0 To DGV5rowscount - 1
                If DataGridView1(2, DGV1index).Value = DataGridView5(0, DGV5index).Value AndAlso DataGridView1(1, DGV1index).Value = DataGridView5(2, DGV5index).Value AndAlso DataGridView5(1, DGV5index).Value = 1 Then
                    DataGridView1(4, DGV1index).Value = "◆"
                End If
            Next
        Next
        For DGV2index As Integer = 0 To DGV2rowscount - 1
            For DGV5index As Integer = 0 To DGV5rowscount - 1
                If DataGridView2(2, DGV2index).Value = DataGridView5(0, DGV5index).Value AndAlso DataGridView2(1, DGV2index).Value = DataGridView5(2, DGV5index).Value AndAlso DataGridView5(1, DGV5index).Value = 1 Then
                    DataGridView2(4, DGV2index).Value = "◆"
                End If
            Next
        Next

        Dim SQLCm7 As OleDbCommand = Cn.CreateCommand
        Dim Adapter7 As New OleDbDataAdapter(SQLCm7)
        Dim Table7 As New DataTable
        SQLCm7.CommandText = "select * from Dat15Unt"
        Adapter7.Fill(Table7)
        DataGridView7.DataSource = Table7


        DataGridView1.Focus()
        DataGridView1.CurrentCell = DataGridView1(2, 0)
        DataGridView1(2, 0).Selected = False

        DataGridView2.Focus()
        DataGridView2.CurrentCell = DataGridView2(2, 0)
        DataGridView2(2, 0).Selected = False

        YmdBoxStart.setADStr(Today.ToString("yyyy/MM/dd"))

        KeyPreview = True
    End Sub

    Private Sub FormUpdate()
        DataGridView4.Columns.Clear()

        Util.EnableDoubleBuffering(DataGridView4)

        DataGridView4.RowTemplate.Height = 18

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select distinct Ymd, Nam from Dat15 WHERE Nam = '" & lblName.Text & "' ORDER BY Ymd DESC"
        Adapter.Fill(Table)
        DataGridView4.DataSource = Table

        DataGridView4.Columns(0).Width = 66
        DataGridView4.Columns(1).Visible = False

        Dim TextColumn As New DataGridViewTextBoxColumn
        DataGridView4.Columns.Insert(2, TextColumn)
        TextColumn.Name = "Cng"
        TextColumn.HeaderText = "変更"
        DataGridView4.Columns(2).Width = 20

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable

        SQLCm2.CommandText = "select * from Dat15 Where Nam = '" & lblName.Text & "' AND Gyo = 1 ORDER BY Ymd DESC"
        Adapter2.Fill(Table2)
        DataGridView6.DataSource = Table2

        For i As Integer = 0 To DataGridView4.Rows.Count - 1
            If Util.checkDBNullValue(DataGridView6(17, i).Value) = "1" Then
                DataGridView4(2, i).Value = "☆"
            End If
        Next

        If DataGridView4.Rows.Count > 0 Then
            DataGridView4(0, 0).Selected = False
        End If

    End Sub

    Private Sub 食札_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView3_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellEnter

    End Sub

    Private Sub datagridview3_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView3.EditingControlShowing
        Dim editTextBox As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)

        'イベントハンドラを削除、追加
        RemoveHandler editTextBox.KeyPress, AddressOf datagrid3_KeyPress
        AddHandler editTextBox.KeyPress, AddressOf datagrid3_KeyPress
    End Sub

    Private Sub datagrid3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim text As String = CType(sender, DataGridViewTextBoxEditingControl).Text
        Dim lengthByte As Integer = Encoding.GetEncoding("Shift_JIS").GetByteCount(text)

        If lengthByte >= 46 Then '設定されているバイト数以上の時
            If e.KeyChar = ChrW(Keys.Back) Then
                'Backspaceは入力可能
                e.Handled = False
            Else
                '入力できなくする
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        clear()
        DataGridView4.Columns.Clear()

        Dim selectedrow As Integer = DataGridView1.CurrentRow.Index
        lblUnit.Text = DataGridView1(0, selectedrow).Value
        lblHurigana.Text = DataGridView1(1, selectedrow).Value
        lblName.Text = DataGridView1(2, selectedrow).Value

        Util.EnableDoubleBuffering(DataGridView4)

        DataGridView4.RowTemplate.Height = 18

        DataGridView2.Focus()
        DataGridView2.CurrentCell = DataGridView2(2, 0)
        DataGridView2(2, 0).Selected = False

        If DataGridView1(4, selectedrow).Value = "◆" Then
            chkInsatutaisyou.Checked = True
        Else
            chkInsatutaisyou.Checked = False
        End If

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select distinct Ymd, Nam from Dat15 WHERE Nam = '" & lblName.Text & "' ORDER BY Ymd DESC"
        Adapter.Fill(Table)
        DataGridView4.DataSource = Table

        DataGridView4.Columns(0).Width = 66
        DataGridView4.Columns(1).Visible = False

        Dim TextColumn As New DataGridViewTextBoxColumn
        DataGridView4.Columns.Insert(2, TextColumn)
        TextColumn.Name = "Cng"
        TextColumn.HeaderText = "変更"
        DataGridView4.Columns(2).Width = 20

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable

        SQLCm2.CommandText = "select * from Dat15 Where Nam = '" & lblName.Text & "' AND Gyo = 1 ORDER BY Ymd DESC"
        Adapter2.Fill(Table2)
        DataGridView6.DataSource = Table2

        For i As Integer = 0 To DataGridView4.Rows.Count - 1
            If Util.checkDBNullValue(DataGridView6(17, i).Value) = "1" Then
                DataGridView4(2, i).Value = "☆"
            End If
        Next

        If DataGridView4.Rows.Count > 0 Then
            DataGridView4(0, 0).Selected = False
        End If


    End Sub
    Private Sub DataGridView2_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        clear()
        DataGridView4.Columns.Clear()

        Dim selectedrow As Integer = DataGridView2.CurrentRow.Index
        lblUnit.Text = DataGridView2(0, selectedrow).Value
        lblHurigana.Text = DataGridView2(1, selectedrow).Value
        lblName.Text = DataGridView2(2, selectedrow).Value

        Util.EnableDoubleBuffering(DataGridView4)

        DataGridView4.RowTemplate.Height = 18

        DataGridView1.Focus()
        DataGridView1.CurrentCell = DataGridView1(2, 0)
        DataGridView1(2, 0).Selected = False

        If DataGridView2(4, selectedrow).Value = "◆" Then
            chkInsatutaisyou.Checked = True
        Else
            chkInsatutaisyou.Checked = False
        End If

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select distinct Ymd, Nam from Dat15 WHERE Nam = '" & lblName.Text & "' ORDER BY Ymd DESC"
        Adapter.Fill(Table)
        DataGridView4.DataSource = Table

        DataGridView4.Columns(0).Width = 66
        DataGridView4.Columns(1).Visible = False

        Dim TextColumn As New DataGridViewTextBoxColumn
        DataGridView4.Columns.Insert(2, TextColumn)
        TextColumn.Name = "Cng"
        TextColumn.HeaderText = "変更"
        DataGridView4.Columns(2).Width = 20

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable

        SQLCm2.CommandText = "select * from Dat15 Where Nam = '" & lblName.Text & "' AND Gyo = 1 ORDER BY Ymd DESC"
        Adapter2.Fill(Table2)
        DataGridView6.DataSource = Table2

        For i As Integer = 0 To DataGridView4.Rows.Count - 1
            If Util.checkDBNullValue(DataGridView6(17, i).Value) = "1" Then
                DataGridView4(2, i).Value = "☆"
            End If
        Next

        If DataGridView4.Rows.Count > 0 Then
            DataGridView4(0, 0).Selected = False
        End If


    End Sub

    Private Sub chkInsatutaisyou_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkInsatutaisyou.CheckedChanged
        If lblName.Text = "" Then
            Return
        End If

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm5 As OleDbCommand = Cn.CreateCommand
        Dim Adapter5 As New OleDbDataAdapter(SQLCm5)
        Dim Table5 As New DataTable
        SQLCm5.CommandText = "select * from Dat15Prnt"
        Adapter5.Fill(Table5)
        DataGridView5.DataSource = Table5

        Dat15unit()

        Dim SQLCm7 As OleDbCommand = Cn.CreateCommand
        Dim Adapter7 As New OleDbDataAdapter(SQLCm7)
        Dim Table7 As New DataTable
        SQLCm7.CommandText = "select * from Dat15Unt"
        Adapter7.Fill(Table7)
        DataGridView7.DataSource = Table7

        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)
        Dim SQL As String = ""
        Dim DGV1selectedrow As Integer = DataGridView1.CurrentRow.Index
        Dim DGV1rowscount As Integer = DataGridView1.Rows.Count
        Dim DGV2selectedrow As Integer = DataGridView2.CurrentRow.Index
        Dim DGV2rowscount As Integer = DataGridView2.Rows.Count
        Dim DGV5rowscount As Integer = DataGridView5.Rows.Count
        Dim DGV7rowscount As Integer = DataGridView7.Rows.Count

        For DGV5index As Integer = 0 To DGV5rowscount - 1   'Dat15prntにデータがあるか
            'その人のデータがあるかないか
            If lblName.Text = DataGridView5(0, DGV5index).Value AndAlso lblHurigana.Text = DataGridView5(2, DGV5index).Value Then
                'ある場合
                If chkInsatutaisyou.Checked = True Then
                    SQL = "UPDATE Dat15Prnt SET Prnt = 1 WHERE Nam = '" & lblName.Text & "' AND Kana = '" & lblHurigana.Text & "'"
                    cnn.Execute(SQL)
                    cnn.Close()
                    For i As Integer = 0 To DGV1rowscount - 1
                        If DataGridView1(2, i).Selected = True Then
                            DataGridView1(4, DGV1selectedrow).Value = "◆"
                            Exit Sub
                        End If
                    Next
                    For i As Integer = 0 To DGV2rowscount - 1
                        If DataGridView2(2, i).Selected = True Then
                            DataGridView2(4, DGV2selectedrow).Value = "◆"
                            Exit Sub
                        End If
                    Next

                ElseIf chkInsatutaisyou.Checked = False Then
                    SQL = "UPDATE Dat15Prnt SET Prnt = 0 WHERE Nam = '" & lblName.Text & "' AND Kana = '" & lblHurigana.Text & "'"
                    cnn.Execute(SQL)
                    cnn.Close()
                    For i As Integer = 0 To DGV1rowscount - 1
                        If DataGridView1(2, i).Selected = True Then
                            DataGridView1(4, DGV1selectedrow).Value = ""
                            Exit Sub
                        End If
                    Next
                    For i As Integer = 0 To DGV2rowscount - 1
                        If DataGridView2(2, i).Selected = True Then
                            DataGridView2(4, DGV2selectedrow).Value = ""
                            Exit Sub
                        End If
                    Next
                End If
            End If
        Next

        'ない場合
        Dim nam As String = lblName.Text
        Dim prnt As Integer
        Dim kana As String = lblHurigana.Text

        If chkInsatutaisyou.Checked = True Then
            prnt = 1
        ElseIf chkInsatutaisyou.Checked = False Then
            prnt = 0
        End If

        SQL = "INSERT INTO Dat15Prnt VALUES ('" & nam & "', " & prnt & ", '" & kana & "')"
        cnn.Execute(SQL)
        cnn.Close()

        If chkInsatutaisyou.Checked = True Then
            For i As Integer = 0 To DGV1rowscount - 1
                If DataGridView1(2, i).Selected = True Then
                    DataGridView1(4, DGV1selectedrow).Value = "◆"
                    Exit Sub
                End If
            Next
            For i As Integer = 0 To DGV2rowscount - 1
                If DataGridView2(2, i).Selected = True Then
                    DataGridView2(4, DGV2selectedrow).Value = "◆"
                    Exit Sub
                End If
            Next
        ElseIf chkInsatutaisyou.Checked = False Then
            For i As Integer = 0 To DGV1rowscount - 1
                If DataGridView1(2, i).Selected = True Then
                    DataGridView1(4, DGV1selectedrow).Value = ""
                    Exit Sub
                End If
            Next
            For i As Integer = 0 To DGV2rowscount - 1
                If DataGridView2(2, i).Selected = True Then
                    DataGridView2(4, DGV2selectedrow).Value = ""
                    Exit Sub
                End If
            Next
        End If

        
    End Sub

    Private Sub Dat15unit()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)
        Dim SQL As String = ""
        Dim DGV7rowscount As Integer = DataGridView7.Rows.Count

        For DGV7index As Integer = 0 To DGV7rowscount - 1   'Dat15Untにデータがあるか
            'その人のデータがあるかないか
            If lblName.Text = DataGridView7(0, DGV7index).Value AndAlso lblHurigana.Text = DataGridView7(1, DGV7index).Value Then
                'ある場合
                If chkInsatutaisyou.Checked = True Then
                    'SQL = "UPDATE Dat15Prnt SET Prnt = 1 WHERE Nam = '" & lblName.Text & "' AND Kana = '" & lblHurigana.Text & "'"
                    'cnn.Execute(SQL)
                    'cnn.Close()
                    Exit Sub
                ElseIf chkInsatutaisyou.Checked = False Then
                    SQL = "DELETE FROM Dat15Unt WHERE Nam = '" & lblName.Text & "' AND Kana = '" & lblHurigana.Text & "' AND Unit = '" & lblUnit.Text & "'"
                    cnn.Execute(SQL)
                    cnn.Close()
                    Exit Sub
                End If
            End If
        Next

        If chkInsatutaisyou.Checked = True Then
            Dim nam As String = lblName.Text
            Dim kana As String = lblHurigana.Text
            Dim unit As String = lblUnit.Text
            Dim syu As String = ""

            If unit = "星" Then
                syu = "1"
            ElseIf unit = "森" Then
                syu = "2"
            ElseIf unit = "空" Then
                syu = "3"
            ElseIf unit = "花" Then
                syu = "4"
            ElseIf unit = "月" Then
                syu = "5"
            ElseIf unit = "海" Then
                syu = "6"
            ElseIf unit = "虹" Then
                syu = "7"
            ElseIf unit = "光" Then
                syu = "8"
            ElseIf unit = "丘" Then
                syu = "9"
            ElseIf unit = "風" Then
                syu = "A"
            ElseIf unit = "雪" Then
                syu = "B"
            End If

            SQL = "INSERT INTO Dat15Unt VALUES ('" & nam & "', '" & kana & "', '" & unit & "', '" & syu & "')"
            cnn.Execute(SQL)
            cnn.Close()
        End If

    End Sub

    Private Sub DataGridView4_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView4.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then
            e.Value = Util.convADStrToWarekiStr(e.Value)
        End If
    End Sub

    Private Sub DataGridView4_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView4.CellMouseClick
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Dim DGV4selectedrow As Integer = DataGridView4.CurrentRow.Index

        SQLCm.CommandText = "select * from Dat15 Where Nam = '" & lblName.Text & "' AND Ymd = '" & DataGridView4(0, DGV4selectedrow).Value & "' ORDER BY Gyo"
        Adapter.Fill(Table)
        DataGridView6.DataSource = Table

        For i As Integer = 0 To DataGridView6.Rows.Count - 1
            If DataGridView6(3, i).Value = i + 1 Then
                Controls("txtTyuui" & i + 1).Text = Util.checkDBNullValue(DataGridView6(4, i).Value)
            End If
            If i < 10 Then
                DataGridView3(0, i).Value = DataGridView6(13, i).Value
            End If
        Next
        cmbSyokusyu.Text = DataGridView6(15, 0).Value
        If DataGridView6(5, 0).Value = "1" Then
            rbnTyousyoku1.Checked = True
        ElseIf DataGridView6(5, 0).Value = "2" Then
            rbnTyousyoku2.Checked = True
        ElseIf DataGridView6(5, 0).Value = "3" Then
            rbnTyousyoku3.Checked = True
        ElseIf DataGridView6(5, 0).Value = "0" Then
            rbnTyousyoku0.Checked = True
        End If
        If DataGridView6(14, 0).Value = "1" Then
            rbnSiru1.Checked = True
            chkSiru3.Checked = False
        ElseIf DataGridView6(14, 0).Value = "2" Then
            rbnSiru2.Checked = True
            chkSiru3.Checked = False
        ElseIf DataGridView6(14, 0).Value = "3" Then
            chkSiru3.Checked = True
            txtSiruName.Text = DataGridView6(16, 0).Value
        ElseIf DataGridView6(14, 0).Value = "0" Then
            rbnSiru0.Checked = True
            chkSiru3.Checked = False
        End If
        txtKei1.Text = DataGridView6(6, 0).Value
        txtKei2.Text = DataGridView6(7, 0).Value
        txtKei3.Text = DataGridView6(8, 0).Value
        If Util.checkDBNullValue(DataGridView6(18, 0).Value) = "1" Then
            rbnTomo1.Checked = True
        ElseIf Util.checkDBNullValue(DataGridView6(18, 0).Value) = "0" Then
            rbnTomo0.Checked = True
        End If
        YmdBoxStart.setADStr(DataGridView6(2, 0).Value)
        cmbStrt.Text = DataGridView6(11, 0).Value
        If Util.checkDBNullValue(DataGridView6(9, 0).Value) = "1" Then
            chkEndCK.Checked = True
        ElseIf Util.checkDBNullValue(DataGridView6(9, 0).Value) = "" Then
            chkEndCK.Checked = False
        End If
        YmdBoxEND.setADStr(Util.checkDBNullValue(DataGridView6(10, 0).Value))
        cmbEnd.Text = Util.checkDBNullValue(DataGridView6(12, 0).Value)
        If Util.checkDBNullValue(DataGridView6(17, 0).Value) = "1" Then
            chkCng.Checked = True
        ElseIf Util.checkDBNullValue(DataGridView6(17, 0).Value) = "0" Then
            chkCng.Checked = False
        End If

    End Sub

    Private Sub chkEndCK_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEndCK.CheckedChanged
        If chkEndCK.Checked = True Then
            YmdBoxEND.Visible = True
            cmbEnd.Visible = True
            YmdBoxEND.setADStr(Today.ToString("yyyy/MM/dd"))
        ElseIf chkEndCK.Checked = False Then
            YmdBoxEND.Visible = False
            cmbEnd.Visible = False
        End If
    End Sub

    Private Sub rbnSiru1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnSiru1.CheckedChanged
        chkSiru3.Checked = False
        txtSiruName.Visible = False
    End Sub

    Private Sub rbnSiru2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnSiru2.CheckedChanged
        chkSiru3.Checked = False
        txtSiruName.Visible = False
    End Sub

    Private Sub chkSiru3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSiru3.CheckedChanged
        If chkSiru3.Checked = True Then
            txtSiruName.Visible = True
            rbnSiru0.Checked = True
        ElseIf chkSiru3.Checked = False Then
            txtSiruName.Visible = False
        End If
    End Sub

    Private Sub clear()
        For i As Integer = 1 To 12
            Controls("txtTyuui" & i).Text = ""
        Next
        cmbSyokusyu.Text = ""
        rbnTyousyoku0.Checked = False
        rbnTyousyoku1.Checked = False
        rbnTyousyoku2.Checked = False
        rbnTyousyoku3.Checked = False
        rbnSiru0.Checked = False
        rbnSiru1.Checked = False
        rbnSiru2.Checked = False
        chkSiru3.Checked = False
        txtSiruName.Text = ""
        txtKei1.Text = ""
        txtKei2.Text = ""
        txtKei3.Text = ""
        rbnTomo0.Checked = False
        rbnTomo1.Checked = False
        YmdBoxStart.setADStr(Today.ToString("yyyy/MM/dd"))
        cmbStrt.Text = ""
        chkEndCK.Checked = False
        cmbEnd.Text = ""
        chkCng.Checked = False
        For row As Integer = 0 To 9
            DataGridView3(0, row).Value = ""
        Next


    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択して下さい")
            Return
        End If

        For i As Integer = 0 To DataGridView4.Rows.Count - 1
            If YmdBoxStart.getADStr() = DataGridView4(0, i).Value Then
                Hennkou()

                Exit Sub
            End If
        Next

        Tuika()

    End Sub

    Private Sub Tuika()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim nam, kana, ymd, kin, asa, kei1, kei2, kei3, ck, ymde, strtnum, endnum, tokki, siru, syu, sirun, cng, tomo As String
        Dim gyo As Integer

        nam = lblName.Text
        kana = lblHurigana.Text
        ymd = YmdBoxStart.getADStr()
        For i As Integer = 1 To 12
            gyo = i
            kin = Controls("txtTyuui" & i).Text
            asa = ""
            kei1 = ""
            kei2 = ""
            kei3 = ""
            ck = ""
            If chkEndCK.Checked = True Then
                ymde = YmdBoxEND.getADStr()
            Else
                ck = ""
                ymde = ""
            End If
            strtnum = ""
            endnum = ""
            tokki = ""
            siru = ""
            syu = ""
            sirun = ""
            cng = ""
            tomo = ""

            If i = 1 Then
                If rbnTyousyoku1.Checked = True Then
                    asa = "1"
                ElseIf rbnTyousyoku2.Checked = True Then
                    asa = "2"
                ElseIf rbnTyousyoku3.Checked = True Then
                    asa = "3"
                ElseIf rbnTyousyoku0.Checked = True Then
                    asa = "0"
                End If
                kei1 = txtKei1.Text
                kei2 = txtKei2.Text
                kei3 = txtKei3.Text
                If chkEndCK.Checked = True Then
                    ck = "1"
                    ymde = YmdBoxEND.getADStr()
                Else
                    ck = ""
                    ymde = ""
                End If
                strtnum = cmbStrt.Text
                endnum = cmbEnd.Text
                If rbnSiru1.Checked = True Then
                    siru = "1"
                    sirun = ""
                ElseIf rbnSiru2.Checked = True Then
                    siru = "2"
                    sirun = ""
                ElseIf chkSiru3.Checked = True Then
                    siru = "3"
                    sirun = txtSiruName.Text
                ElseIf rbnSiru0.Checked = True Then
                    siru = "0"
                    sirun = ""
                End If
                syu = cmbSyokusyu.Text
                If chkCng.Checked = True Then
                    cng = 1
                ElseIf chkCng.Checked = False Then
                    cng = 0
                End If
                If rbnTomo1.Checked = True Then
                    tomo = 1
                ElseIf rbnTomo0.Checked = True Then
                    tomo = 0
                End If
            End If
            If i <= 10 Then
                tokki = Util.checkDBNullValue(DataGridView3(0, i - 1).Value)
            End If

            Dim SQL As String = ""
            SQL = "INSERT INTO Dat15 VALUES ('" & nam & "', '" & kana & "', '" & ymd & "', " & gyo & ", '" & kin & "', '" & asa & "', '" & kei1 & "', '" & kei2 & "', '" & kei3 & "', '" & ck & "', '" & ymde & "', '" & strtnum & "', '" & endnum & "', '" & tokki & "', '" & siru & "', '" & syu & "', '" & sirun & "', '" & cng & "', '" & tomo & "')"
            cnn.Execute(SQL)
        Next
        cnn.Close()

        FormUpdate()

    End Sub

    Private Sub Hennkou()
        If MsgBox("この更新日のデータを更新しますか？", MsgBoxStyle.YesNo + vbExclamation, "更新確認") = MsgBoxResult.Yes Then
            For i As Integer = 0 To DataGridView4.Rows.Count - 1
                If YmdBoxStart.getADStr() = DataGridView4(0, i).Value Then
                    Dim cnn As New ADODB.Connection
                    cnn.Open(topform.DB_NCare)

                    Dim SQL As String = ""

                    SQL = "DELETE FROM Dat15 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBoxStart.getADStr() & "'"

                    cnn.Execute(SQL)
                    cnn.Close()

                    Tuika()

                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択して下さい")
            Return
        End If

        Dim selectedRow As Integer = If(IsNothing(DataGridView4.CurrentRow), -1, DataGridView4.CurrentRow.Index)
        If selectedRow = -1 Then
            MsgBox("削除対象の行が選択されていません。")
            Return
        End If

        If MsgBox("この更新日のデータを削除しますか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            For i As Integer = 0 To DataGridView4.Rows.Count - 1
                If YmdBoxStart.getADStr() = DataGridView4(0, i).Value Then
                    Dim cnn As New ADODB.Connection
                    cnn.Open(topform.DB_NCare)

                    Dim SQL As String = ""

                    SQL = "DELETE FROM Dat15 WHERE Nam = '" & lblName.Text & "' AND Ymd = '" & YmdBoxStart.getADStr() & "'"

                    cnn.Execute(SQL)
                    cnn.Close()

                    FormUpdate()

                    Exit Sub
                End If
            Next

            MsgBox("対象データが存在しません")
            Exit Sub
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If IsNothing(frmPrint) OrElse frmPrint.IsDisposed Then
            frmPrint = New 食札印刷()
            frmPrint.Owner = Me
            frmPrint.Show()
        End If
    End Sub

    
End Class