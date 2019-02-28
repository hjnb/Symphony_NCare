Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class topform
    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\NCare.mdb"
    Public DB_NCare As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\NCare.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\NCare.ini"

    '画像パス
    Public imageFilePath As String = My.Application.Info.DirectoryPath & "\NCare.bmp"

    'フォーム
    Private frmAsemoni As アセモニ
    Private frmKannfarennsu As カンファレンス
    Private frmSukuri As スクリーニング書
    Private frmKeikakusyo As 計画書
    Private frmSyokuinn As 職員
    Private frmSyokuinnsyoku As 職員食
    Private frmSyokusatu As 食札
    Private frmSinntyoutaijuu As 身長体重
    Private frmSeibijoukyou As 整備状況
    Private frmDouisyo As 同意書
    Private frmSyokusuu As ＳＳ食数
    Private frmNyuukyosya As 入居者
    Private Birth As String
    Private Jyuusyo As String

    Private Sub topform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(imageFilePath) Then
            MsgBox("画像ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        Me.WindowState = FormWindowState.Maximized

        Dim Cn As New OleDbConnection(DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Util.EnableDoubleBuffering(DataGridView1)

        SQLCm.CommandText = "select Nam, Kana, Birth, Jyu from UsrM WHERE Unit <> '海' and Hyo = '1' order by Kana"
        Adapter.Fill(Table)
        With DataGridView1
            .DataSource = Table
            .Columns(0).Width = 120
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With

        lblName.Text = ""

        '画像表示
        PictureBox1.ImageLocation = imageFilePath

        DataGridView1(0, 0).Selected = False
    End Sub

    Private Sub btnSukuri_Click(sender As System.Object, e As System.EventArgs) Handles btnSukuri.Click
        If IsNothing(frmSukuri) OrElse frmSukuri.IsDisposed Then
            frmSukuri = New スクリーニング書()
            frmSukuri.Owner = Me
            frmSukuri.Show()
        End If
    End Sub

    Private Sub btnKeikakusyo_Click(sender As System.Object, e As System.EventArgs) Handles btnKeikakusyo.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択してください。")
        Else
            If IsNothing(frmKeikakusyo) OrElse frmKeikakusyo.IsDisposed Then
                frmKeikakusyo = New 計画書(lblName.Text, Birth, Jyuusyo)
                frmKeikakusyo.Owner = Me
                frmKeikakusyo.Show()
            End If
        End If
    End Sub

    Private Sub btnKannfarennsu_Click(sender As System.Object, e As System.EventArgs) Handles btnKannfarennsu.Click
        If IsNothing(frmKannfarennsu) OrElse frmKannfarennsu.IsDisposed Then
            frmKannfarennsu = New カンファレンス()
            frmKannfarennsu.Owner = Me
            frmKannfarennsu.Show()
        End If
    End Sub

    Private Sub btnNyuukyosya_Click(sender As System.Object, e As System.EventArgs) Handles btnNyuukyosya.Click
        If IsNothing(frmNyuukyosya) OrElse frmNyuukyosya.IsDisposed Then
            frmNyuukyosya = New 入居者()
            frmNyuukyosya.Owner = Me
            frmNyuukyosya.Show()
        End If
    End Sub

    Private Sub btnSyokusatu_Click(sender As System.Object, e As System.EventArgs) Handles btnSyokusatu.Click
        If IsNothing(frmSyokusatu) OrElse frmSyokusatu.IsDisposed Then
            frmSyokusatu = New 食札()
            frmSyokusatu.Owner = Me
            frmSyokusatu.Show()
        End If
    End Sub

    Private Sub btnSeibijoukyou_Click(sender As System.Object, e As System.EventArgs) Handles btnSeibijoukyou.Click
        If IsNothing(frmSeibijoukyou) OrElse frmSeibijoukyou.IsDisposed Then
            frmSeibijoukyou = New 整備状況()
            frmSeibijoukyou.Owner = Me
            frmSeibijoukyou.Show()
        End If
    End Sub

    Private Sub btnAsemoni_Click(sender As System.Object, e As System.EventArgs) Handles btnAsemoni.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択してください。")
        Else
            If IsNothing(frmAsemoni) OrElse frmAsemoni.IsDisposed Then
                frmAsemoni = New アセモニ(lblName.Text)
                frmAsemoni.Owner = Me
                frmAsemoni.Show()
            End If
        End If
    End Sub

    Private Sub btnDouisyo_Click(sender As System.Object, e As System.EventArgs) Handles btnDouisyo.Click
        If IsNothing(frmDouisyo) OrElse frmDouisyo.IsDisposed Then
            frmDouisyo = New 同意書()
            frmDouisyo.Owner = Me
            frmDouisyo.Show()
        End If
    End Sub

    Private Sub btnSyokuinn_Click(sender As System.Object, e As System.EventArgs) Handles btnSyokuinn.Click
        If IsNothing(frmSyokuinn) OrElse frmSyokuinn.IsDisposed Then
            frmSyokuinn = New 職員()
            frmSyokuinn.Owner = Me
            frmSyokuinn.Show()
        End If
    End Sub

    Private Sub btnSinntyouTaijuu_Click(sender As System.Object, e As System.EventArgs) Handles btnSinntyouTaijuu.Click
        If IsNothing(frmSinntyoutaijuu) OrElse frmSinntyoutaijuu.IsDisposed Then
            frmSinntyoutaijuu = New 身長体重()
            frmSinntyoutaijuu.Owner = Me
            frmSinntyoutaijuu.Show()
        End If
    End Sub

    Private Sub btnSyokusuu_Click(sender As System.Object, e As System.EventArgs) Handles btnSyokusuu.Click
        If IsNothing(frmSyokusuu) OrElse frmSyokusuu.IsDisposed Then
            frmSyokusuu = New ＳＳ食数()
            frmSyokusuu.Owner = Me
            frmSyokusuu.Show()
        End If
    End Sub

    Private Sub btnSyokuinnsyoku_Click(sender As System.Object, e As System.EventArgs) Handles btnSyokuinnsyoku.Click
        If IsNothing(frmSyokuinnsyoku) OrElse frmSyokuinnsyoku.IsDisposed Then
            frmSyokuinnsyoku = New 職員食()
            frmSyokuinnsyoku.Owner = Me
            frmSyokuinnsyoku.Show()
        End If
    End Sub

    Private Sub btnA_Click(sender As System.Object, e As System.EventArgs) Handles btnA.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^あ") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnK_Click(sender As System.Object, e As System.EventArgs) Handles btnK.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^か") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnS_Click(sender As System.Object, e As System.EventArgs) Handles btnS.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^さ") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btbT_Click(sender As System.Object, e As System.EventArgs) Handles btbT.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^た") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnN_Click(sender As System.Object, e As System.EventArgs) Handles btnN.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^な") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnH_Click(sender As System.Object, e As System.EventArgs) Handles btnH.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^は") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnM_Click(sender As System.Object, e As System.EventArgs) Handles btnM.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^ま") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnY_Click(sender As System.Object, e As System.EventArgs) Handles btnY.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^や") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnR_Click(sender As System.Object, e As System.EventArgs) Handles btnR.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^ら") = True Or System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^り") = True Or System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^る") = True Or System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^れ") = True Or System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^ろ") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub btnW_Click(sender As System.Object, e As System.EventArgs) Handles btnW.Click
        Dim DB1rowcount As Integer = DataGridView1.Rows.Count
        For i = 0 To DB1rowcount - 1
            If System.Text.RegularExpressions.Regex.IsMatch(DataGridView1(1, i).Value.ToString, "^わ") = True Then
                '見つかった場合は、その行に移動します。
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = i
                '見つかった時点で繰り返し処理を中止します。
                Exit For
            End If
        Next
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim selectedrow As Integer = DataGridView1.CurrentRow.Index
        lblName.Text = DataGridView1(0, selectedrow).Value
        Birth = DataGridView1(2, selectedrow).Value
        Jyuusyo = DataGridView1(3, selectedrow).Value
    End Sub
    
    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


End Class
