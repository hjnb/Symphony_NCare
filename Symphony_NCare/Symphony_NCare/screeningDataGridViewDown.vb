Public Class screeningDataGridViewDown
    Inherits DataGridView

    Public targetYmdBoxK1 As ymdBox.ymdBox
    Public targetYmdBoxK2 As ymdBox.ymdBox
    Public targetYmdBoxK3 As ymdBox.ymdBox
    Public targetYmdBoxK4 As ymdBox.ymdBox

    Private intakeDic As New Dictionary(Of String, String) From {{"1", "低"}, {"2", "中"}}
    Private nutritionDic As New Dictionary(Of String, String) From {{"1", "経腸栄養法"}, {"2", "静脈栄養法"}, {"3", "該当なし"}}
    Private decubitusDic As New Dictionary(Of String, String) From {{"1", "褥瘡"}, {"2", "該当なし"}}

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Dim inputStr As String = If(Not IsNothing(Me.EditingControl), CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text, "") '入力文字
        If keyData = Keys.Enter Then
            If Me.CurrentCell.RowIndex = 2 Then '食事摂取量 低/中
                If intakeDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = intakeDic(inputStr)
                End If
            ElseIf Me.CurrentCell.RowIndex = 4 Then '栄養補給法
                If nutritionDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = nutritionDic(inputStr)
                End If
            ElseIf Me.CurrentCell.RowIndex = 5 Then '褥瘡
                If decubitusDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = decubitusDic(inputStr)
                End If
            End If
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)

        If Me.CurrentCell.ColumnIndex >= 2 AndAlso Me.CurrentCell.RowIndex = 0 AndAlso e.KeyCode = Keys.Up Then
            Me.CurrentCell.Selected = False
            If Me.CurrentCell.ColumnIndex = 2 Then
                targetYmdBoxK1.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 3 Then
                targetYmdBoxK2.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 4 Then
                targetYmdBoxK3.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 5 Then
                targetYmdBoxK4.Focus()
            End If
        End If

        If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
            Return False
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function
End Class
