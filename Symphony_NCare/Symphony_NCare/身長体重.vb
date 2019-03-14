Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class 身長体重
    Private DGV1Table As DataTable
    Private DGV2Table As DataTable
    Private DGV3Table As DataTable
    Private DGV4Table As DataTable
    Private DGV5Table As DataTable
    Private DGV6Table As DataTable
    Private DGV7Table As DataTable
    Private DGV8Table As DataTable
    Private DGV9Table As DataTable
    Private DGV10Table As DataTable
    Private Sub 身長体重_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        For i As Integer = 1 To 10
            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            Util.EnableDoubleBuffering(DGVType)
            With DGVType
                .RowTemplate.Height = 18
                .AllowUserToAddRows = False '行追加禁止
                .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
                .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
                .AllowUserToDeleteRows = False
                .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .RowHeadersVisible = False
                .DefaultCellStyle.SelectionForeColor = Color.Black
            End With
        Next

        Dim DGVFirstTimeTable As DataTable
        For i As Integer = 1 To 10
            DGVFirstTimeTable = New DataTable()
            '列作成
            For col As Integer = 0 To 3
                DGVFirstTimeTable.Columns.Add("a" & col, Type.GetType("System.String"))
            Next
            '行作成
            For row As Integer = 0 To 14
                DGVFirstTimeTable.Rows.Add(DGVFirstTimeTable.NewRow())
            Next

            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            DGVType.DataSource = DGVFirstTimeTable
            For col As Integer = 0 To 3
                If col = 0 Then
                    DGVType.Columns(col).Width = 25
                ElseIf col = 1 Then
                    DGVType.Columns(col).Width = 85
                Else
                    DGVType.Columns(col).Width = 40
                End If
                DGVType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            With DGVType
                .Columns(1).HeaderText = "氏　名"
                .Columns(2).HeaderText = "体重"
                .Columns(3).HeaderText = "身長"
            End With
            For num As Integer = 0 To 14
                DGVType(0, num).Value = num + 1
            Next
        Next

        DataGridView1.Columns(0).HeaderText = "森"
        DataGridView2.Columns(0).HeaderText = "星"
        DataGridView3.Columns(0).HeaderText = "空"
        DataGridView4.Columns(0).HeaderText = "月"
        DataGridView5.Columns(0).HeaderText = "花"
        DataGridView6.Columns(0).HeaderText = "丘"
        DataGridView7.Columns(0).HeaderText = "虹"
        DataGridView8.Columns(0).HeaderText = "光"
        DataGridView9.Columns(0).HeaderText = "雪"
        DataGridView10.Columns(0).HeaderText = "風"

        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        cnn.Open(topform.DB_NCare)
        For i As Integer = 1 To 10
            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            Dim unit As String = DGVType.Columns(0).HeaderText
            '名前セット
            Dim sql As String = "select Nam, Kana, Unit, Hyo from UsrM WHERE Unit = '" & unit & "' AND Hyo = '1' order by Kana"
            rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            Dim row As Integer = 0
            While Not rs.EOF
                DGVType(1, row).Value = rs.Fields("Nam").Value
                rs.MoveNext()
                row = row + 1
            End While
            rs.Close()

            '各DataGridVIewに表示されている人数のカウント・表示
            Dim personcount As Integer = 0
            For count As Integer = 0 To 14
                If Util.checkDBNullValue(DGVType(1, count).Value) <> "" Then
                    personcount = personcount + 1
                Else
                    Exit For
                End If
            Next
            Controls("lblDGV" & i & "PSC").Text = personcount & "名"
        Next
        cnn.Close()

        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))


        Dim Cn As New OleDbConnection(topform.DB_NCare)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable
        SQLCm.CommandText = "select * from Dat10"
        Adapter.Fill(Table)
        DataGridViewHeight.DataSource = Table

    End Sub

    Private Sub DGVWaku_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting, DataGridView2.CellPainting, DataGridView3.CellPainting, DataGridView4.CellPainting, DataGridView5.CellPainting, DataGridView6.CellPainting, DataGridView7.CellPainting, DataGridView8.CellPainting, DataGridView9.CellPainting, DataGridView10.CellPainting
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

    Private Sub YmdBox1_YmdTextChange(sender As Object, e As System.EventArgs) Handles YmdBox1.YmdTextChange
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        cnn.Open(topform.DB_NCare)

        '体重セット
        For i As Integer = 1 To 10
            Dim sqlWeight As String = "select * from Dat9 WHERE Ym = '" & YmdBox1.getADYmStr() & "'"
            rs.Open(sqlWeight, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            Dim mojisuu As Integer = Controls("lblDGV" & i & "PSC").Text.Length
            Dim Str As String = Controls("lblDGV" & i & "PSC").Text.Remove(mojisuu - 1, 1)
            Dim personcount As Integer = Val(Str)
            If rs.RecordCount > 1 Then
                While Not rs.EOF
                    For row As Integer = 0 To personcount - 1
                        If Util.checkDBNullValue(DGVType(1, row).Value) = rs.Fields("Nam").Value Then
                            DGVType(2, row).Value = rs.Fields("Weight").Value
                        End If
                    Next
                    rs.MoveNext()
                End While
                rs.Close()
            Else
                For row As Integer = 0 To personcount - 1
                    DGVType(2, row).Value = ""
                Next
                rs.Close()
            End If
        Next
        cnn.Close()

        '身長セット
        cnn.Open(topform.DB_NCare)
        For i As Integer = 1 To 10
            Dim sqlWeight As String = "select * from Dat10"
            rs.Open(sqlWeight, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            Dim mojisuu As Integer = Controls("lblDGV" & i & "PSC").Text.Length
            Dim Str As String = Controls("lblDGV" & i & "PSC").Text.Remove(mojisuu - 1, 1)
            Dim personcount As Integer = Val(Str)
            If rs.RecordCount > 1 Then
                While Not rs.EOF
                    For row As Integer = 0 To personcount - 1
                        If Util.checkDBNullValue(DGVType(1, row).Value) = rs.Fields("Nam").Value Then
                            DGVType(3, row).Value = rs.Fields("Height").Value
                        End If
                    Next
                    rs.MoveNext()
                End While
                rs.Close()
            Else
                For row As Integer = 0 To personcount - 1
                    DGVType(3, row).Value = ""
                Next
                rs.Close()
            End If
        Next
        cnn.Close()

    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        cnn.Open(topform.DB_NCare)
        'その月のデータがあるかないか
        Dim sqlWeight As String = "select * from Dat9 WHERE Ym = '" & YmdBox1.getADYmStr() & "'"
        rs.Open(sqlWeight, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If rs.RecordCount > 1 Then  'その月にデータがあれば更新
            Dim Weightsql As String = "DELETE FROM Dat9 WHERE Ym = '" & YmdBox1.getADYmStr() & "'"
            cnn.Execute(Weightsql)
            WeightTuika()

        Else    'なければ新規登録
            WeightTuika()

        End If

        HeightTuika()

    End Sub

    Private Sub WeightTuika()
        Dim cnn As New ADODB.Connection
        Dim SQL As String = ""
        cnn.Open(topform.DB_NCare)
        Dim nam, ym, weight As String

        For i As Integer = 1 To 10
            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            Dim mojisuu As Integer = Controls("lblDGV" & i & "PSC").Text.Length
            Dim Str As String = Controls("lblDGV" & i & "PSC").Text.Remove(mojisuu - 1, 1)
            Dim personcount As Integer = Val(Str)
            For row As Integer = 0 To personcount - 1
                nam = DGVType(1, row).Value
                ym = YmdBox1.getADYmStr()
                weight = DGVType(2, row).Value
                SQL = "INSERT INTO Dat9 VALUES ('" & nam & "', '" & ym & "', '" & weight & "')"
                cnn.Execute(SQL)
            Next
        Next
        cnn.Close()
    End Sub

    Private Sub HeightTuika()
        Dim cnn As New ADODB.Connection
        Dim SQL As String = ""
        cnn.Open(topform.DB_NCare)

        Dim DGVHeightrowcount As Integer = DataGridViewHeight.Rows.Count

        For DGVHighetindex As Integer = 0 To DGVHeightrowcount - 1   'Dat10にデータがあるか
            'その人のデータがあるかないか
            For i As Integer = 1 To 10
                Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
                Dim mojisuu As Integer = Controls("lblDGV" & i & "PSC").Text.Length
                Dim Str As String = Controls("lblDGV" & i & "PSC").Text.Remove(mojisuu - 1, 1)
                Dim personcount As Integer = Val(Str)
                For row As Integer = 0 To personcount - 1
                    If DGVType(1, row).Value = DataGridViewHeight(0, DGVHighetindex).Value Then
                        'ある場合
                        SQL = "UPDATE Dat10 SET Height = '" & Util.checkDBNullValue(DGVType(3, row).Value) & "' WHERE Nam = '" & DGVType(1, row).Value & "'"
                        cnn.Execute(SQL)

                    End If
                Next
            Next
        Next


        'ない場合
        Dim nam, height As String

        For i As Integer = 1 To 10
            Dim DGVType As DataGridView = CType(Controls("DataGridView" & i), DataGridView)
            Dim mojisuu As Integer = Controls("lblDGV" & i & "PSC").Text.Length
            Dim Str As String = Controls("lblDGV" & i & "PSC").Text.Remove(mojisuu - 1, 1)
            Dim personcount As Integer = Val(Str)
            For row As Integer = 0 To personcount - 1
                nam = Util.checkDBNullValue(DGVType(1, row).Value)
                height = Util.checkDBNullValue(DGVType(3, row).Value)
                SQL = "INSERT INTO Dat10 VALUES ('" & nam & "', '" & height & "')"
                cnn.Execute(SQL)
            Next
        Next
        cnn.Close()
    End Sub
End Class