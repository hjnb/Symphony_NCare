Imports System
Imports System.Windows.Forms
Public Class 計画書Class
    Inherits DataGridView

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
