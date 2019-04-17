Imports System
Imports System.Windows.Forms

Public Class 食数Class
    Inherits DataGridView
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        '編集時Enterを押したらTabキーが押されたようにする
        If TypeOf Me.EditingControl Is DataGridViewTextBoxEditingControl = True Then
            Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
            Dim cell As DataGridViewCell = Me.CurrentCell
            Dim cellcolumn As Integer = cell.ColumnIndex
            If (keyData And Keys.KeyCode) = Keys.Enter Then

                Dim Count As String
                Count = tb.Text

                If Count = "1" Then
                    Count = Count.Replace("1", "■")
                    tb.Text = Count
                ElseIf Util.checkDBNullValue(Count) = "" Then

                Else
                    MsgBox("正しく入力してください")
                    tb.Text = ""
                    EndEdit()
                    Return False
                End If

                If cell.RowIndex = 4 Then
                    If cellcolumn <> 31 Then
                        Me.CurrentCell = Me(cellcolumn + 1, 1)
                    Else

                    End If
                End If

            ElseIf keyData = Keys.Back Then
                cell.Value = ""
            End If

            If Not IsNothing(tb) AndAlso ((keyData = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (keyData = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
                Return False
            Else
                Return MyBase.ProcessDialogKey(keyData)
            End If
        Else
            Dim cell As DataGridViewCell = Me.CurrentCell
            Dim cellcolumn As Integer = cell.ColumnIndex
            If keyData = Keys.Back Then
                cell.Value = ""
            ElseIf (keyData And Keys.KeyCode) = Keys.Enter Then
                If cell.RowIndex = 4 Then
                    If cellcolumn <> 31 Then
                        Me.CurrentCell = Me(cellcolumn + 1, 1)
                    Else

                    End If
                End If
            End If

            Return MyBase.ProcessDialogKey(keyData)
        End If


    End Function

    Protected Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
        '編集時以外でEnterを押したらTabキーが押されたようにする
        Dim cell As DataGridViewCell = Me.CurrentCell
        Dim cellcolumn As Integer = cell.ColumnIndex
        If e.KeyCode = Keys.Enter Then
            If cell.RowIndex = 4 Then
                If cellcolumn <> 31 Then
                    Me.CurrentCell = Me(cellcolumn + 1, 1)
                Else

                End If
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            cell.Value = ""
        End If

        Return MyBase.ProcessDataGridViewKey(e)
    End Function

    Public Overrides Function GetClipboardContent() As DataObject
        '元のDataObjectを取得する
        Dim oldData As DataObject = MyBase.GetClipboardContent()

        '新しいDataObjectを作成する
        Dim newData As New DataObject()

        'テキスト形式のデータをセットする（UnicodeTextもセットされる）
        newData.SetData(DataFormats.Text, oldData.GetData(DataFormats.Text))

        Return newData
    End Function

    Private Sub ExDataGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'ctrl + x で選択セル内容切り取り
        If e.Control AndAlso e.KeyCode = Keys.X Then
            '選択セルの内容コピー
            Clipboard.SetDataObject(GetClipboardContent())

            '選択セルの内容削除
            For Each cell As DataGridViewCell In SelectedCells
                cell.Value = ""
            Next
        End If
    End Sub
End Class