Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class 入居者

    Private Sub 入居者_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select Nam, Kana, Birth, Jyu from UsrM WHERE Unit <> '海' and Hyo = '1' order by Kana"
        Adapter.Fill(Table)
        With topform.DataGridView1
            .DataSource = Table
            .Columns(0).Width = 120
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With

        topform.DataGridView1(0, 0).Selected = False
    End Sub

    Private Sub 入居者_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Util.EnableDoubleBuffering(DataGridView1)

        DataGridView1.RowTemplate.Height = 18

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select Unit As ﾕﾆｯﾄ, Kana As ふりがな, Nam As 利用者氏名, Sex As 性別, Birth As 生年月日, Jyu As 住所, Hyo As 表示, Ymd As 登録日 from UsrM order by Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .Columns(0).Width = 20
            .Columns(1).Width = 130
            .Columns(2).Width = 100
            .Columns(3).Width = 35
            .Columns(4).Width = 70
            .Columns(5).Width = 180
            .Columns(6).Width = 35
            .Columns(7).Width = 70
        End With

        ymdboxYmd.setADStr(Today.ToString)

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1(4, i).Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(4, i).Value))
            DataGridView1(7, i).Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(7, i).Value))
        Next

        KeyPreview = True

        DataGridView1(0, 0).Selected = False
    End Sub

    Private Sub 入居者_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim SelectedRow As Integer = DataGridView1.CurrentRow.Index
        If DataGridView1(0, SelectedRow).Value = "森" Then
            rbnMori.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "星" Then
            rbnHosi.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "空" Then
            rbnSora.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "花" Then
            rbnHana.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "月" Then
            rbnTuki.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "海" Then
            rbnUmi.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "虹" Then
            rbnNiji.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "光" Then
            rbnHikari.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "丘" Then
            rbnOka.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "風" Then
            rbnKaze.Checked = True
        ElseIf DataGridView1(0, SelectedRow).Value = "雪" Then
            rbnYuki.Checked = True
        End If
        txtKana.Text = Util.checkDBNullValue(DataGridView1(1, SelectedRow).Value)
        txtNam.Text = Util.checkDBNullValue(DataGridView1(2, SelectedRow).Value)
        txtSex.Text = Util.checkDBNullValue(DataGridView1(3, SelectedRow).Value)
        ymdboxBirth.setWarekiStr(Util.checkDBNullValue(DataGridView1(4, SelectedRow).Value))
        txtJyu.Text = Util.checkDBNullValue(DataGridView1(5, SelectedRow).Value)
        txtHyo.Text = Util.checkDBNullValue(DataGridView1(6, SelectedRow).Value)
        ymdboxYmd.setWarekiStr(Util.checkDBNullValue(DataGridView1(7, SelectedRow).Value))
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '列ヘッダを対象外しておかないと列ヘッダにも番号を表示してしまう

        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then

            'セルを描画する

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する

            Dim idxRect As Rectangle = e.CellBounds

            'e.Padding(値を表示する境界線からの間隔)を考慮して描画位置を決める

            Dim rectHeight As Long = e.CellStyle.Padding.Top

            Dim rectLeft As Long = e.CellStyle.Padding.Left

            idxRect.Inflate(rectLeft, rectHeight)

            '行番号を描画する

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, idxRect, e.CellStyle.ForeColor, TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画完了の通知

            e.Handled = True

        End If

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim DGV1Rowcount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To DGV1Rowcount - 1
            If txtNam.Text = DataGridView1(2, i).Value AndAlso ymdboxBirth.getWarekiStr() = DataGridView1(4, i).Value Then
                If MsgBox("変更登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
                    Hennkou()
                End If
                Exit Sub
            End If
        Next
        If MsgBox("新規登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
            Tuika()
        End If

    End Sub

    Private Sub Hennkou()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim unit, kana, nam, sex, birth, jyu, hyo, ymd As String

        If rbnMori.Checked = True Then
            unit = "森"
        ElseIf rbnHosi.Checked = True Then
            unit = "星"
        ElseIf rbnSora.Checked = True Then
            unit = "空"
        ElseIf rbnHana.Checked = True Then
            unit = "花"
        ElseIf rbnTuki.Checked = True Then
            unit = "月"
        ElseIf rbnUmi.Checked = True Then
            unit = "海"
        ElseIf rbnNiji.Checked = True Then
            unit = "虹"
        ElseIf rbnHikari.Checked = True Then
            unit = "光"
        ElseIf rbnOka.Checked = True Then
            unit = "丘"
        ElseIf rbnKaze.Checked = True Then
            unit = "風"
        ElseIf rbnYuki.Checked = True Then
            unit = "雪"
        Else
            MsgBox("ユニットを選択してください")
            Return
        End If

        If txtKana.Text = "" Then
            MsgBox("ふりがなを入力してください")
            Return
        Else
            kana = txtKana.Text
        End If

        If txtNam.Text = "" Then
            MsgBox("氏名を入力してください")
            Return
        Else
            nam = txtNam.Text
        End If

        If txtSex.Text = "1" OrElse txtSex.Text = "2" Then
            sex = txtSex.Text
        Else
            MsgBox("性別を正しく入力してください")
            Return
        End If

        If ymdboxBirth.getADStr() = "" Then
            MsgBox("生年月日を正しく入力してください")
            Return
        Else
            birth = ymdboxBirth.getADStr()
        End If

        If txtJyu.Text = "" Then
            MsgBox("住所を入力してください")
            Return
        Else
            jyu = txtJyu.Text
        End If

        If txtHyo.Text = "1" OrElse txtHyo.Text = "2" Then
            hyo = txtHyo.Text
        Else
            MsgBox("表示を正しくを入力してください")
            Return
        End If

        If ymdboxYmd.getADStr() = "" Then
            MsgBox("登録日を入力してください")
            Return
        Else
            ymd = ymdboxYmd.getADStr()
        End If

        Dim SQL As String = ""
        SQL = "DELETE FROM UsrM WHERE Nam = '" & txtNam.Text & "' AND Birth = '" & ymdboxBirth.getADStr() & "'"
        cnn.Execute(SQL)

        SQL = "INSERT INTO UsrM VALUES ('" & nam & "', '" & kana & "', '" & birth & "', '" & sex & "', '" & jyu & "', '" & ymd & "', '" & unit & "', '" & hyo & "')"
        cnn.Execute(SQL)

        cnn.Close()

        FormUpdate()
    End Sub

    Private Sub Tuika()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)

        Dim unit, kana, nam, sex, birth, jyu, hyo, ymd As String

        If rbnMori.Checked = True Then
            unit = "森"
        ElseIf rbnHosi.Checked = True Then
            unit = "星"
        ElseIf rbnSora.Checked = True Then
            unit = "空"
        ElseIf rbnHana.Checked = True Then
            unit = "花"
        ElseIf rbnTuki.Checked = True Then
            unit = "月"
        ElseIf rbnUmi.Checked = True Then
            unit = "海"
        ElseIf rbnNiji.Checked = True Then
            unit = "虹"
        ElseIf rbnHikari.Checked = True Then
            unit = "光"
        ElseIf rbnOka.Checked = True Then
            unit = "丘"
        ElseIf rbnKaze.Checked = True Then
            unit = "風"
        ElseIf rbnYuki.Checked = True Then
            unit = "雪"
        Else
            MsgBox("ユニットを選択してください")
            Return
        End If

        If txtKana.Text = "" Then
            MsgBox("ふりがなを入力してください")
            Return
        Else
            kana = txtKana.Text
        End If

        If txtNam.Text = "" Then
            MsgBox("氏名を入力してください")
            Return
        Else
            nam = txtNam.Text
        End If

        If txtSex.Text = "1" OrElse txtSex.Text = "2" Then
            sex = txtSex.Text
        Else
            MsgBox("性別を正しく入力してください")
            Return
        End If

        If ymdboxBirth.getADStr() = "" Then
            MsgBox("生年月日を正しく入力してください")
            Return
        Else
            birth = ymdboxBirth.getADStr()
        End If

        If txtJyu.Text = "" Then
            MsgBox("住所を入力してください")
            Return
        Else
            jyu = txtJyu.Text
        End If

        If txtHyo.Text = "1" OrElse txtHyo.Text = "2" Then
            hyo = txtHyo.Text
        Else
            MsgBox("表示を正しくを入力してください")
            Return
        End If

        If ymdboxYmd.getADStr() = "" Then
            MsgBox("登録日を入力してください")
            Return
        Else
            ymd = ymdboxYmd.getADStr()
        End If

        Dim SQL As String = ""
        SQL = "INSERT INTO UsrM VALUES ('" & nam & "', '" & kana & "', '" & birth & "', '" & sex & "', '" & jyu & "', '" & ymd & "', '" & unit & "', '" & hyo & "')"
        cnn.Execute(SQL)

        cnn.Close()

        FormUpdate()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim unit, kana, nam, sex, birth, jyu, hyo, ymd As String

        If rbnMori.Checked = True Then
            unit = "森"
        ElseIf rbnHosi.Checked = True Then
            unit = "星"
        ElseIf rbnSora.Checked = True Then
            unit = "空"
        ElseIf rbnHana.Checked = True Then
            unit = "花"
        ElseIf rbnTuki.Checked = True Then
            unit = "月"
        ElseIf rbnUmi.Checked = True Then
            unit = "海"
        ElseIf rbnNiji.Checked = True Then
            unit = "虹"
        ElseIf rbnHikari.Checked = True Then
            unit = "光"
        ElseIf rbnOka.Checked = True Then
            unit = "丘"
        ElseIf rbnKaze.Checked = True Then
            unit = "風"
        ElseIf rbnYuki.Checked = True Then
            unit = "雪"
        Else
            MsgBox("ユニットを選択してください")
            Return
        End If

        If txtKana.Text = "" Then
            MsgBox("ふりがなを入力してください")
            Return
        Else
            kana = txtKana.Text
        End If

        If txtNam.Text = "" Then
            MsgBox("氏名を入力してください")
            Return
        Else
            nam = txtNam.Text
        End If

        If txtSex.Text = "1" OrElse txtSex.Text = "2" Then
            sex = txtSex.Text
        Else
            MsgBox("性別を正しく入力してください")
            Return
        End If

        If ymdboxBirth.getADStr() = "" Then
            MsgBox("生年月日を正しく入力してください")
            Return
        Else
            birth = ymdboxBirth.getADStr()
        End If

        If txtJyu.Text = "" Then
            MsgBox("住所を入力してください")
            Return
        Else
            jyu = txtJyu.Text
        End If

        If txtHyo.Text = "1" OrElse txtHyo.Text = "2" Then
            hyo = txtHyo.Text
        Else
            MsgBox("表示を正しくを入力してください")
            Return
        End If

        If ymdboxYmd.getADStr() = "" Then
            MsgBox("登録日を入力してください")
            Return
        Else
            ymd = ymdboxYmd.getADStr()
        End If

        Dim DGV1Rowcount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To DGV1Rowcount - 1
            If txtNam.Text = DataGridView1(2, i).Value AndAlso ymdboxBirth.getWarekiStr() = DataGridView1(4, i).Value Then
                If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
                    Dim cnn As New ADODB.Connection
                    cnn.Open(topform.DB_NCare)

                    Dim SQL As String = ""
                    SQL = "DELETE FROM UsrM WHERE Nam = '" & txtNam.Text & "' AND Birth = '" & ymdboxBirth.getADStr() & "'"

                    cnn.Execute(SQL)
                    cnn.Close()

                    FormUpdate()
                End If
                Exit Sub

            End If
        Next
        MsgBox("登録されていません")

    End Sub

    Private Sub Clear()
        txtNam.Text = ""
        txtKana.Text = ""
        txtSex.Text = ""
        ymdboxBirth.clearText()
        txtJyu.Text = ""
        ymdboxYmd.setADStr(Today.ToString)
        rbnMori.Checked = False
        rbnHosi.Checked = False
        rbnSora.Checked = False
        rbnHana.Checked = False
        rbnTuki.Checked = False
        rbnUmi.Checked = False
        rbnNiji.Checked = False
        rbnHikari.Checked = False
        rbnOka.Checked = False
        rbnKaze.Checked = False
        rbnYuki.Checked = False
        txtHyo.Text = ""
    End Sub

    Private Sub FormUpdate()
        Clear()
        Util.EnableDoubleBuffering(DataGridView1)

        DataGridView1.RowTemplate.Height = 18

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select Unit As ﾕﾆｯﾄ, Kana As ふりがな, Nam As 利用者氏名, Sex As 性別, Birth As 生年月日, Jyu As 住所, Hyo As 表示, Ymd As 登録日 from UsrM order by Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .Columns(0).Width = 20
            .Columns(1).Width = 130
            .Columns(2).Width = 100
            .Columns(3).Width = 35
            .Columns(4).Width = 70
            .Columns(5).Width = 180
            .Columns(6).Width = 35
            .Columns(7).Width = 70
        End With

        ymdboxYmd.setADStr(Today.ToString)

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1(4, i).Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(4, i).Value))
            DataGridView1(7, i).Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(DataGridView1(7, i).Value))
        Next
    End Sub

End Class