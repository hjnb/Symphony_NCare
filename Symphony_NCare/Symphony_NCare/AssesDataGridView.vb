Public Class AssesDataGridView
    Inherits DataGridView

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

            '外側の枠線
            'If e.ColumnIndex = 0 Then
            '    With e.CellBounds
            '        .Offset(0, 0)
            '        e.Graphics.DrawLine(New Pen(SystemColors.ControlDark), .Left, .Top, .Left, .Bottom)
            '    End With
            '    If e.RowIndex = 0 Then
            '        With e.CellBounds
            '            .Offset(0, 0)
            '            e.Graphics.DrawLine(New Pen(SystemColors.ControlDark), .Left, .Top, .Right, .Top)
            '        End With
            '    ElseIf e.RowIndex = 46 Then
            '        With e.CellBounds
            '            .Offset(0, -1)
            '            e.Graphics.DrawLine(New Pen(SystemColors.ControlDark), .Left, .Bottom, .Right, .Bottom)
            '        End With
            '    End If
            'End If

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
