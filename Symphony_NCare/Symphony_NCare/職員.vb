Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class 職員

    Private Sub 職員_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Util.EnableDoubleBuffering(DataGridView1)

        DataGridView1.RowTemplate.Height = 18

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select SyuN, Syu As 種別, SyuR, YakN, Yak As 職名, Nam As 職員氏名, Kana As ﾌﾘｶﾞﾅ, Dsp As 表示 from EtcM order by SyuN, YakN, Kana"
        Adapter.Fill(Table)
        With DataGridView1
            .DataSource = Table
            .Columns(0).Visible = False
            .Columns(1).Width = 150
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Width = 140
            .Columns(5).Width = 100
            .Columns(6).Width = 110
            .Columns(7).Width = 36
        End With

        DataGridView1(0, 0).Selected = False

        KeyPreview = True

    End Sub

    Private Sub FormUpdate()
        Clear()

        DataGridView1.RowTemplate.Height = 18

        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select SyuN, Syu As 種別, SyuR, YakN, Yak As 職名, Nam As 職員氏名, Kana As ﾌﾘｶﾞﾅ, Dsp As 表示 from EtcM order by SyuN, YakN, Kana"
        Adapter.Fill(Table)
        With DataGridView1
            .DataSource = Table
            .Columns(0).Visible = False
            .Columns(1).Width = 150
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Width = 140
            .Columns(5).Width = 100
            .Columns(6).Width = 110
            .Columns(7).Width = 36
        End With

        DataGridView1(0, 0).Selected = False

        KeyPreview = True
    End Sub

    Private Sub 職員_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim SelectedRow As Integer = DataGridView1.CurrentRow.Index
        cmbSyu.Text = Util.checkDBNullValue(DataGridView1(1, SelectedRow).Value)
        cmbYak.Text = Util.checkDBNullValue(DataGridView1(4, SelectedRow).Value)
        txtNam.Text = Util.checkDBNullValue(DataGridView1(5, SelectedRow).Value)
        txtKana.Text = Util.checkDBNullValue(DataGridView1(6, SelectedRow).Value)
        txtDsp.Text = Util.checkDBNullValue(DataGridView1(7, SelectedRow).Value)
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

    Private Sub cmbSyu_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSyu.SelectedIndexChanged
        cmbYak.Items.Clear()
        cmbYak.Text = ""
        Dim Yak As String()
        If cmbSyu.Text = "管理系" Then
            Yak = {"施設長", "副施設長", "事務長", "介護部長", "介護主任"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "事務" Then
            Yak = {"経理事務"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "特別養護老人ホーム" Then
            Yak = {"看護師", "生活相談員", "介護支援専門員", "介護員", "パート介護員"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "栄養課" Then
            Yak = {"管理栄養士", "栄養士"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "居宅介護支援事業所" Then
            Yak = {"介護支援専門員"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "ヘルパーステーション" Then
            Yak = {"サービス提供責任者", "訪問介護員"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "デイサービス" Then
            Yak = {"生活相談員", "看護師", "介護員", "パート介護員"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "生活支援ハウス" Then
            Yak = {"生活援助員"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "ボランティア" Then
            Yak = {"ボランティア"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "宿直" Then
            Yak = {"宿直"}
            cmbYak.Items.AddRange(Yak)
        ElseIf cmbSyu.Text = "その他" Then
            Yak = {"その他"}
            cmbYak.Items.AddRange(Yak)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim DGV1Rowcount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To DGV1Rowcount - 1
            If txtNam.Text = DataGridView1(5, i).Value OrElse txtKana.Text = DataGridView1(6, i).Value Then
                If MsgBox("種別：" & DataGridView1(1, i).Value & "　職名：" & DataGridView1(4, i).Value & "　で" & vbCr & "名前：" & txtNam.Text & "　もしくは、ｶﾅ：" & txtKana.Text & " が同じ人が登録されています。" & vbCr & "登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
                    Exit For
                Else
                    Return
                End If
            End If
        Next

        For i As Integer = 0 To DGV1Rowcount - 1
            If cmbSyu.Text = DataGridView1(1, i).Value AndAlso cmbYak.Text = DataGridView1(4, i).Value AndAlso txtNam.Text = DataGridView1(5, i).Value Then
                Hennkou()
                Exit Sub
            End If
        Next

        Tuika()

    End Sub

    Private Sub Hennkou()
        Dim syun, yak, dsp
        Dim syu, syur, yakn, nam, kana As String
        If cmbSyu.Text = "" Then
            MsgBox("種別を選択してください")
            cmbSyu.Focus()
            Return
        Else
            syun = cmbSyu.Items.IndexOf(cmbSyu.Text) + 1

            syu = cmbSyu.Text

            If cmbSyu.Text = "特別養護老人ホーム" Then
                syur = "特養"
            ElseIf cmbSyu.Text = "栄養課" Then
                syur = "栄養"
            ElseIf cmbSyu.Text = "居宅介護支援事業所" Then
                syur = "居宅"
            ElseIf cmbSyu.Text = "ヘルパーステーション" Then
                syur = "ヘルパ"
            ElseIf cmbSyu.Text = "デイサービス" Then
                syur = "デイ"
            ElseIf cmbSyu.Text = "生活支援ハウス" Then
                syur = "生活"
            ElseIf cmbSyu.Text = "ボランティア" Then
                syur = "ボラン"
            Else
                syur = cmbSyu.Text
            End If
        End If

        If cmbYak.Text = "" Then
            MsgBox("職名を選択してください")
            cmbYak.Focus()
            Return
        Else
            If cmbSyu.Text = "管理系" Then
                If cmbYak.Text = "介護主任" Then
                    yakn = 5
                Else
                    yakn = 1
                End If
            Else
                yakn = cmbYak.Items.IndexOf(cmbYak.Text) + 1
            End If

            yak = cmbYak.Text
        End If

        If txtNam.Text = "" Then
            MsgBox("氏名を入力してください")
            txtNam.Focus()
            Return
        Else
            nam = txtNam.Text
        End If

        If txtKana.Text = "" Then
            MsgBox("ﾌﾘｶﾞﾅを入力してください")
            txtKana.Focus()
            Return
        Else
            kana = txtKana.Text
        End If

        If txtDsp.Text = "1" OrElse txtDsp.Text = "2" Then
            dsp = txtDsp.Text
        Else
            MsgBox("表示を正しく入力してください")
            txtDsp.Focus()
            Return
        End If

        Dim cnn As New ADODB.Connection
        Dim SQL As String = ""
        If MsgBox("変更登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
            cnn.Open(topform.DB_NCare)
            SQL = "DELETE FROM EtcM WHERE Nam = '" & txtNam.Text & "' AND Kana = '" & txtKana.Text & "' AND Syu = '" & cmbSyu.Text & "' AND Yak = '" & cmbYak.Text & "'"
            cnn.Execute(SQL)

            SQL = "INSERT INTO EtcM VALUES (" & syun & ", '" & syu & "', '" & syur & "', " & yakn & ", '" & yak & "', '" & nam & "', '" & kana & "', " & dsp & ")"
            cnn.Execute(SQL)
            cnn.Close()
            FormUpdate()
        End If

    End Sub

    Private Sub Tuika()
        Dim cnn As New ADODB.Connection
        cnn.Open(topform.DB_NCare)
        Dim syun, yak, dsp
        Dim syu, syur, yakn, nam, kana As String
        If cmbSyu.Text = "" Then
            MsgBox("種別を選択してください")
            cmbSyu.Focus()
            Return
        Else
            syun = cmbSyu.Items.IndexOf(cmbSyu.Text) + 1

            syu = cmbSyu.Text

            If cmbSyu.Text = "特別養護老人ホーム" Then
                syur = "特養"
            ElseIf cmbSyu.Text = "栄養課" Then
                syur = "栄養"
            ElseIf cmbSyu.Text = "居宅介護支援事業所" Then
                syur = "居宅"
            ElseIf cmbSyu.Text = "ヘルパーステーション" Then
                syur = "ヘルパ"
            ElseIf cmbSyu.Text = "デイサービス" Then
                syur = "デイ"
            ElseIf cmbSyu.Text = "生活支援ハウス" Then
                syur = "生活"
            ElseIf cmbSyu.Text = "ボランティア" Then
                syur = "ボラン"
            Else
                syur = cmbSyu.Text
            End If
        End If
        
        If cmbYak.Text = "" Then
            MsgBox("職名を選択してください")
            cmbYak.Focus()
            Return
        Else
            If cmbSyu.Text = "管理系" Then
                If cmbYak.Text = "介護主任" Then
                    yakn = 5
                Else
                    yakn = 1
                End If
            Else
                yakn = cmbYak.Items.IndexOf(cmbYak.Text) + 1
            End If

            yak = cmbYak.Text
        End If

        If txtNam.Text = "" Then
            MsgBox("氏名を入力してください")
            txtNam.Focus()
            Return
        Else
            nam = txtNam.Text
        End If

        If txtKana.Text = "" Then
            MsgBox("ﾌﾘｶﾞﾅを入力してください")
            txtKana.Focus()
            Return
        Else
            kana = txtKana.Text
        End If

        If txtDsp.Text = "1" OrElse txtDsp.Text = "2" Then
            dsp = txtDsp.Text
        Else
            MsgBox("表示を正しく入力してください")
            txtDsp.Focus()
            Return
        End If

        If MsgBox("新規登録してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "登録確認") = MsgBoxResult.Yes Then
            Dim SQL As String = ""
            SQL = "INSERT INTO EtcM VALUES (" & syun & ", '" & syu & "', '" & syur & "', " & yakn & ", '" & yak & "', '" & nam & "', '" & kana & "', " & dsp & ")"
            cnn.Execute(SQL)
        End If

        cnn.Close()

        FormUpdate()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim selectedRow As Integer = If(IsNothing(DataGridView1.CurrentRow), -1, DataGridView1.CurrentRow.Index)
        If selectedRow = -1 Then
            MsgBox("選択して下さい")
            Return
        End If

        Dim DGV1Rowcount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To DGV1Rowcount - 1
            If cmbSyu.Text = DataGridView1(1, i).Value AndAlso cmbYak.Text = DataGridView1(4, i).Value AndAlso txtNam.Text = DataGridView1(5, i).Value Then
                If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
                    Dim cnn As New ADODB.Connection
                    cnn.Open(topform.DB_NCare)

                    Dim SQL As String = ""
                    SQL = "DELETE FROM EtcM WHERE Nam = '" & txtNam.Text & "' AND Kana = '" & txtKana.Text & "' AND Syu = '" & cmbSyu.Text & "' AND Yak = '" & cmbYak.Text & "'"

                    cnn.Execute(SQL)
                    cnn.Close()

                    FormUpdate()
                End If
                Exit Sub
            End If
        Next
        MsgBox("選択して下さい")
    End Sub

    Private Sub Clear()
        cmbSyu.Text = ""
        cmbYak.Text = ""
        txtNam.Text = ""
        txtKana.Text = ""
        txtDsp.Text = ""
    End Sub

End Class