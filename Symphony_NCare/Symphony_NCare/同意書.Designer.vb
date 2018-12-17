<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 同意書
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPrintout = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPrintout
        '
        Me.btnPrintout.Location = New System.Drawing.Point(42, 21)
        Me.btnPrintout.Name = "btnPrintout"
        Me.btnPrintout.Size = New System.Drawing.Size(104, 33)
        Me.btnPrintout.TabIndex = 0
        Me.btnPrintout.Text = "印刷"
        Me.btnPrintout.UseVisualStyleBackColor = True
        '
        '同意書
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(189, 80)
        Me.Controls.Add(Me.btnPrintout)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "同意書"
        Me.Text = "同意書"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrintout As System.Windows.Forms.Button
End Class
