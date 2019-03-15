Public Class screeningDataGridViewUp
    Inherits DataGridView

    Public targetYmdBoxJ1 As ymdBox.ymdBox
    Public targetYmdBoxJ2 As ymdBox.ymdBox
    Public targetYmdBoxJ3 As ymdBox.ymdBox
    Public targetYmdBoxJ4 As ymdBox.ymdBox
    Public targetYmdBoxK1 As ymdBox.ymdBox
    Public targetYmdBoxK2 As ymdBox.ymdBox
    Public targetYmdBoxK3 As ymdBox.ymdBox
    Public targetYmdBoxK4 As ymdBox.ymdBox

    Private riskDic As New Dictionary(Of String, String) From {{"1", "低"}, {"2", "中"}, {"3", "高"}}
    Private bmiDic As New Dictionary(Of String, String) From {{"1", "低"}, {"2", "中"}}
    Private weightDown1Dic As New Dictionary(Of String, String) From {{"1", "増"}, {"2", "減"}}
    Private weightDown2Dic As New Dictionary(Of String, String) From {{"1", "低"}, {"2", "中"}, {"3", "高"}}
    Private albDic As New Dictionary(Of String, String) From {{"1", "低"}, {"2", "中"}, {"3", "高"}}

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Dim inputStr As String = If(Not IsNothing(Me.EditingControl), CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text, "") '入力文字
        If keyData = Keys.Enter Then
            If Me.CurrentCell.RowIndex = 0 Then 'リスク
                If riskDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = riskDic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 4 Then 'BMI 低/中
                If bmiDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = bmiDic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 7 Then '体重減少率 増/減
                If weightDown1Dic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = weightDown1Dic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 8 Then '体重減少率 低/中/高
                If weightDown2Dic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = weightDown2Dic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 10 Then '血清ｱﾙﾌﾞﾐﾝ値 低/中/高
                If albDic.ContainsKey(inputStr) Then
                    CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text = albDic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            End If
        ElseIf keyData = Keys.Back Then
            Me.CurrentCell.Value = ""
            Me.BeginEdit(False)
        ElseIf Not ((Keys.NumPad0 <= keyData AndAlso keyData <= Keys.NumPad9) OrElse (Keys.D0 <= keyData AndAlso keyData <= Keys.D9) OrElse keyData = Keys.Back OrElse keyData = Keys.Delete OrElse keyData = Keys.Decimal OrElse keyData = Keys.OemPeriod OrElse keyData = Keys.Up OrElse keyData = Keys.Down OrElse keyData = Keys.Left OrElse keyData = Keys.Right OrElse keyData = Keys.Subtract OrElse keyData = Keys.OemMinus) Then
            If Me.CurrentCell.RowIndex = 1 OrElse Me.CurrentCell.RowIndex = 2 OrElse Me.CurrentCell.RowIndex = 3 OrElse Me.CurrentCell.RowIndex = 5 OrElse Me.CurrentCell.RowIndex = 6 OrElse Me.CurrentCell.RowIndex = 9 Then
                Me.BeginEdit(True)
            End If
        End If

        If Me.CurrentCell.ColumnIndex >= 2 AndAlso Me.CurrentCell.RowIndex = 10 AndAlso (keyData = Keys.Enter) Then
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
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        Dim inputStr As String = Util.checkDBNullValue(Me.CurrentCell.Value)
        If e.KeyCode = Keys.Enter Then
            If Me.CurrentCell.RowIndex = 0 Then 'リスク
                If riskDic.ContainsKey(inputStr) Then
                    Me.CurrentCell.Value = riskDic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 4 Then 'BMI 低/中
                If bmiDic.ContainsKey(inputStr) Then
                    Me.CurrentCell.Value = bmiDic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 7 Then '体重減少率 増/減
                If weightDown1Dic.ContainsKey(inputStr) Then
                    Me.CurrentCell.Value = weightDown1Dic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 8 Then '体重減少率 低/中/高
                If weightDown2Dic.ContainsKey(inputStr) Then
                    Me.CurrentCell.Value = weightDown2Dic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            ElseIf Me.CurrentCell.RowIndex = 10 Then '血清ｱﾙﾌﾞﾐﾝ値 低/中/高
                If albDic.ContainsKey(inputStr) Then
                    Me.CurrentCell.Value = albDic(inputStr)
                ElseIf inputStr <> "" Then
                    MsgBox("正しく入力して下さい。", MsgBoxStyle.Exclamation)
                End If
            End If
        End If

        If Me.CurrentCell.ColumnIndex >= 2 AndAlso Me.CurrentCell.RowIndex = 0 AndAlso e.KeyCode = Keys.Up Then
            If Me.CurrentCell.ColumnIndex = 2 Then
                targetYmdBoxJ1.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 3 Then
                targetYmdBoxJ2.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 4 Then
                targetYmdBoxJ3.Focus()
            ElseIf Me.CurrentCell.ColumnIndex = 5 Then
                targetYmdBoxJ4.Focus()
            End If
        ElseIf Me.CurrentCell.ColumnIndex >= 2 AndAlso Me.CurrentCell.RowIndex = 10 AndAlso (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Enter) Then
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

        Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
        If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
            Return False
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function
End Class
