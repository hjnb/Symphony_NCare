Imports System.Runtime.InteropServices
Public Class 同意書

    Private Sub btnPrintout_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintout.Click
        Dim objExcel As Object
        Dim objWorkBooks As Object
        Dim objWorkBook As Object
        Dim oSheets As Object
        Dim oSheet As Object

        objExcel = CreateObject("Excel.Application")
        objWorkBooks = objExcel.Workbooks
        objWorkBook = objWorkBooks.Open(topform.excelFilePass)
        oSheets = objWorkBook.Worksheets
        oSheet = objWorkBook.Worksheets("同意書２改")


        objExcel.DisplayAlerts = False
        ' エクセル表示
        objExcel.Visible = True

        '印刷
        If topform.rbnPreview.Checked = True Then
            oSheet.PrintPreview(1)
        ElseIf topform.rbnPrintout.Checked = True Then
            oSheet.Printout(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(oSheet)
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub

    Private Sub 同意書_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class