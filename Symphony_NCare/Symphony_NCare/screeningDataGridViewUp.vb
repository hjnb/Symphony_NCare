Public Class screeningDataGridViewUp
    Inherits DataGridView

    Public targetYmdBox1 As ymdBox.ymdBox
    Public targetYmdBox2 As ymdBox.ymdBox
    Public targetYmdBox3 As ymdBox.ymdBox
    Public targetYmdBox4 As ymdBox.ymdBox

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)

        If Me.CurrentCell.ColumnIndex >= 2 AndAlso Me.CurrentCell.RowIndex = 0 AndAlso e.KeyCode = Keys.Up Then
            If Me.CurrentCell.ColumnIndex = 2 Then
                targetYmdBox1.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 3 Then
                targetYmdBox2.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 4 Then
                targetYmdBox3.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 5 Then
                targetYmdBox4.Focus()
            End If
            Me.CurrentCell.Selected = False
        End If

        If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
            Return False
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function
End Class
