Public Class AssesDataGridView
    Inherits DataGridView

    Private iyokuDic As New Dictionary(Of String, String) From {{"1", "よい"}, {"2", "まあよい"}, {"3", "ふつう"}, {"4", "あまりよくない"}, {"5", "よくない"}}
    Private ynDic As New Dictionary(Of String, String) From {{"1", "有"}, {"2", "無"}}
    Private manzokuDic As New Dictionary(Of String, String) From {{"1", "大いにある"}, {"2", "ややある"}, {"3", "ふつう"}, {"4", "ややない"}, {"5", "全くない"}}
    Private maruDic As New Dictionary(Of String, String) From {{"1", "①"}, {"2", "②"}, {"3", "③"}, {"4", "④"}}
    Private assessmentDic As New Dictionary(Of String, String) From {{"1", "改善"}, {"2", "改善傾向"}, {"3", "維持"}, {"4", "改善が認められない"}}

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Dim inputStr As String = If(Not IsNothing(Me.EditingControl), CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text, "") '入力文字
        If keyData = Keys.Enter Then
            If Me.CurrentCell.RowIndex = 0 Then '本人の意欲
                If iyokuDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = iyokuDic(inputStr)
                End If
            ElseIf Me.CurrentCell.RowIndex = 4 OrElse Me.CurrentCell.RowIndex = 19 OrElse Me.CurrentCell.RowIndex = 27 OrElse Me.CurrentCell.RowIndex = 35 Then
                If ynDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = ynDic(inputStr)
                End If
            ElseIf Me.CurrentCell.RowIndex = 9 Then '食欲・食事の満足度
                If manzokuDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = manzokuDic(inputStr)
                End If
            ElseIf Me.CurrentCell.RowIndex = 36 Then
                If maruDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = maruDic(inputStr)
                End If
            ElseIf Me.CurrentCell.RowIndex = 46 Then '総合評価
                If assessmentDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = assessmentDic(inputStr)
                End If
            End If
            Return MyBase.ProcessDialogKey(keyData)
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
        If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
            Return False
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function

    Private Sub AssesDataGridView_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            Dim pParts As DataGridViewPaintParts

            If e.ColumnIndex = 0 Then
                pParts = e.PaintParts And (Not DataGridViewPaintParts.Background And Not DataGridViewPaintParts.Border)
            Else
                pParts = e.PaintParts And Not DataGridViewPaintParts.Background
            End If

            '区切りの横青線
            If e.RowIndex = 1 OrElse e.RowIndex = 2 OrElse e.RowIndex = 3 OrElse e.RowIndex = 6 OrElse e.RowIndex = 7 OrElse e.RowIndex = 8 OrElse e.RowIndex = 9 OrElse e.RowIndex = 14 OrElse e.RowIndex = 18 OrElse e.RowIndex = 22 OrElse e.RowIndex = 26 OrElse e.RowIndex = 34 OrElse e.RowIndex = 45 Then
                With e.CellBounds
                    .Offset(0, -2)
                    e.Graphics.DrawLine(New Pen(Color.Blue), .Left, .Bottom, .Right, .Bottom)
                End With
            End If

            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub
End Class
