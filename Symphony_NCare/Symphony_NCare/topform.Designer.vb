<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class topform
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
        Me.lstName = New System.Windows.Forms.ListBox()
        Me.btnSukuri = New System.Windows.Forms.Button()
        Me.btnKeikakusyo = New System.Windows.Forms.Button()
        Me.btnKannfarennsu = New System.Windows.Forms.Button()
        Me.btnNyuukyosya = New System.Windows.Forms.Button()
        Me.btnSyokusatu = New System.Windows.Forms.Button()
        Me.btnSeibijoukyou = New System.Windows.Forms.Button()
        Me.btnAsemoni = New System.Windows.Forms.Button()
        Me.btnDouisyo = New System.Windows.Forms.Button()
        Me.btnSyokuinn = New System.Windows.Forms.Button()
        Me.btnSinntyouTaijuu = New System.Windows.Forms.Button()
        Me.btnSyokusuu = New System.Windows.Forms.Button()
        Me.btnSyokuinnsyoku = New System.Windows.Forms.Button()
        Me.btnA = New System.Windows.Forms.Button()
        Me.btnK = New System.Windows.Forms.Button()
        Me.btnS = New System.Windows.Forms.Button()
        Me.btbT = New System.Windows.Forms.Button()
        Me.btnN = New System.Windows.Forms.Button()
        Me.btnH = New System.Windows.Forms.Button()
        Me.btnM = New System.Windows.Forms.Button()
        Me.btnY = New System.Windows.Forms.Button()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnW = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstName
        '
        Me.lstName.FormattingEnabled = True
        Me.lstName.ItemHeight = 12
        Me.lstName.Location = New System.Drawing.Point(98, 45)
        Me.lstName.Name = "lstName"
        Me.lstName.Size = New System.Drawing.Size(140, 220)
        Me.lstName.TabIndex = 0
        '
        'btnSukuri
        '
        Me.btnSukuri.BackColor = System.Drawing.Color.Pink
        Me.btnSukuri.Location = New System.Drawing.Point(299, 42)
        Me.btnSukuri.Name = "btnSukuri"
        Me.btnSukuri.Size = New System.Drawing.Size(156, 84)
        Me.btnSukuri.TabIndex = 1
        Me.btnSukuri.Text = "スクリーニング書"
        Me.btnSukuri.UseVisualStyleBackColor = False
        '
        'btnKeikakusyo
        '
        Me.btnKeikakusyo.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnKeikakusyo.Location = New System.Drawing.Point(299, 132)
        Me.btnKeikakusyo.Name = "btnKeikakusyo"
        Me.btnKeikakusyo.Size = New System.Drawing.Size(156, 84)
        Me.btnKeikakusyo.TabIndex = 2
        Me.btnKeikakusyo.Text = "計画書"
        Me.btnKeikakusyo.UseVisualStyleBackColor = False
        '
        'btnKannfarennsu
        '
        Me.btnKannfarennsu.BackColor = System.Drawing.Color.LimeGreen
        Me.btnKannfarennsu.Location = New System.Drawing.Point(461, 132)
        Me.btnKannfarennsu.Name = "btnKannfarennsu"
        Me.btnKannfarennsu.Size = New System.Drawing.Size(156, 84)
        Me.btnKannfarennsu.TabIndex = 3
        Me.btnKannfarennsu.Text = "カンファレンス"
        Me.btnKannfarennsu.UseVisualStyleBackColor = False
        '
        'btnNyuukyosya
        '
        Me.btnNyuukyosya.BackColor = System.Drawing.Color.Khaki
        Me.btnNyuukyosya.Location = New System.Drawing.Point(299, 222)
        Me.btnNyuukyosya.Name = "btnNyuukyosya"
        Me.btnNyuukyosya.Size = New System.Drawing.Size(75, 58)
        Me.btnNyuukyosya.TabIndex = 4
        Me.btnNyuukyosya.Text = "入居者"
        Me.btnNyuukyosya.UseVisualStyleBackColor = False
        '
        'btnSyokusatu
        '
        Me.btnSyokusatu.BackColor = System.Drawing.Color.Pink
        Me.btnSyokusatu.Location = New System.Drawing.Point(380, 222)
        Me.btnSyokusatu.Name = "btnSyokusatu"
        Me.btnSyokusatu.Size = New System.Drawing.Size(75, 58)
        Me.btnSyokusatu.TabIndex = 5
        Me.btnSyokusatu.Text = "食札"
        Me.btnSyokusatu.UseVisualStyleBackColor = False
        '
        'btnSeibijoukyou
        '
        Me.btnSeibijoukyou.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnSeibijoukyou.Location = New System.Drawing.Point(461, 222)
        Me.btnSeibijoukyou.Name = "btnSeibijoukyou"
        Me.btnSeibijoukyou.Size = New System.Drawing.Size(75, 58)
        Me.btnSeibijoukyou.TabIndex = 6
        Me.btnSeibijoukyou.Text = "整備状況"
        Me.btnSeibijoukyou.UseVisualStyleBackColor = False
        '
        'btnAsemoni
        '
        Me.btnAsemoni.BackColor = System.Drawing.Color.Pink
        Me.btnAsemoni.Location = New System.Drawing.Point(542, 222)
        Me.btnAsemoni.Name = "btnAsemoni"
        Me.btnAsemoni.Size = New System.Drawing.Size(75, 58)
        Me.btnAsemoni.TabIndex = 7
        Me.btnAsemoni.Text = "アセモニ"
        Me.btnAsemoni.UseVisualStyleBackColor = False
        '
        'btnDouisyo
        '
        Me.btnDouisyo.BackColor = System.Drawing.Color.Coral
        Me.btnDouisyo.Location = New System.Drawing.Point(299, 286)
        Me.btnDouisyo.Name = "btnDouisyo"
        Me.btnDouisyo.Size = New System.Drawing.Size(75, 58)
        Me.btnDouisyo.TabIndex = 8
        Me.btnDouisyo.Text = "同意書"
        Me.btnDouisyo.UseVisualStyleBackColor = False
        '
        'btnSyokuinn
        '
        Me.btnSyokuinn.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSyokuinn.Location = New System.Drawing.Point(380, 286)
        Me.btnSyokuinn.Name = "btnSyokuinn"
        Me.btnSyokuinn.Size = New System.Drawing.Size(75, 58)
        Me.btnSyokuinn.TabIndex = 9
        Me.btnSyokuinn.Text = "職員"
        Me.btnSyokuinn.UseVisualStyleBackColor = False
        '
        'btnSinntyouTaijuu
        '
        Me.btnSinntyouTaijuu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSinntyouTaijuu.Location = New System.Drawing.Point(461, 286)
        Me.btnSinntyouTaijuu.Name = "btnSinntyouTaijuu"
        Me.btnSinntyouTaijuu.Size = New System.Drawing.Size(75, 58)
        Me.btnSinntyouTaijuu.TabIndex = 10
        Me.btnSinntyouTaijuu.Text = "身長/体重"
        Me.btnSinntyouTaijuu.UseVisualStyleBackColor = False
        '
        'btnSyokusuu
        '
        Me.btnSyokusuu.BackColor = System.Drawing.Color.Magenta
        Me.btnSyokusuu.Location = New System.Drawing.Point(299, 350)
        Me.btnSyokusuu.Name = "btnSyokusuu"
        Me.btnSyokusuu.Size = New System.Drawing.Size(75, 58)
        Me.btnSyokusuu.TabIndex = 11
        Me.btnSyokusuu.Text = "ＳＳ職数"
        Me.btnSyokusuu.UseVisualStyleBackColor = False
        '
        'btnSyokuinnsyoku
        '
        Me.btnSyokuinnsyoku.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnSyokuinnsyoku.Location = New System.Drawing.Point(380, 350)
        Me.btnSyokuinnsyoku.Name = "btnSyokuinnsyoku"
        Me.btnSyokuinnsyoku.Size = New System.Drawing.Size(75, 58)
        Me.btnSyokuinnsyoku.TabIndex = 12
        Me.btnSyokuinnsyoku.Text = "職員食"
        Me.btnSyokuinnsyoku.UseVisualStyleBackColor = False
        '
        'btnA
        '
        Me.btnA.Location = New System.Drawing.Point(69, 45)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(23, 23)
        Me.btnA.TabIndex = 13
        Me.btnA.Text = "あ"
        Me.btnA.UseVisualStyleBackColor = True
        '
        'btnK
        '
        Me.btnK.Location = New System.Drawing.Point(69, 67)
        Me.btnK.Name = "btnK"
        Me.btnK.Size = New System.Drawing.Size(23, 23)
        Me.btnK.TabIndex = 14
        Me.btnK.Text = "か"
        Me.btnK.UseVisualStyleBackColor = True
        '
        'btnS
        '
        Me.btnS.Location = New System.Drawing.Point(69, 89)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(23, 23)
        Me.btnS.TabIndex = 15
        Me.btnS.Text = "さ"
        Me.btnS.UseVisualStyleBackColor = True
        '
        'btbT
        '
        Me.btbT.Location = New System.Drawing.Point(69, 111)
        Me.btbT.Name = "btbT"
        Me.btbT.Size = New System.Drawing.Size(23, 23)
        Me.btbT.TabIndex = 16
        Me.btbT.Text = "た"
        Me.btbT.UseVisualStyleBackColor = True
        '
        'btnN
        '
        Me.btnN.Location = New System.Drawing.Point(69, 133)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(23, 23)
        Me.btnN.TabIndex = 17
        Me.btnN.Text = "な"
        Me.btnN.UseVisualStyleBackColor = True
        '
        'btnH
        '
        Me.btnH.Location = New System.Drawing.Point(69, 155)
        Me.btnH.Name = "btnH"
        Me.btnH.Size = New System.Drawing.Size(23, 23)
        Me.btnH.TabIndex = 18
        Me.btnH.Text = "は"
        Me.btnH.UseVisualStyleBackColor = True
        '
        'btnM
        '
        Me.btnM.Location = New System.Drawing.Point(69, 177)
        Me.btnM.Name = "btnM"
        Me.btnM.Size = New System.Drawing.Size(23, 23)
        Me.btnM.TabIndex = 19
        Me.btnM.Text = "ま"
        Me.btnM.UseVisualStyleBackColor = True
        '
        'btnY
        '
        Me.btnY.Location = New System.Drawing.Point(69, 199)
        Me.btnY.Name = "btnY"
        Me.btnY.Size = New System.Drawing.Size(23, 23)
        Me.btnY.TabIndex = 20
        Me.btnY.Text = "や"
        Me.btnY.UseVisualStyleBackColor = True
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(69, 221)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(23, 23)
        Me.btnR.TabIndex = 21
        Me.btnR.Text = "ら"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'btnW
        '
        Me.btnW.Location = New System.Drawing.Point(69, 243)
        Me.btnW.Name = "btnW"
        Me.btnW.Size = New System.Drawing.Size(23, 23)
        Me.btnW.TabIndex = 22
        Me.btnW.Text = "わ"
        Me.btnW.UseVisualStyleBackColor = True
        '
        'topform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 674)
        Me.Controls.Add(Me.btnW)
        Me.Controls.Add(Me.btnR)
        Me.Controls.Add(Me.btnY)
        Me.Controls.Add(Me.btnM)
        Me.Controls.Add(Me.btnH)
        Me.Controls.Add(Me.btnN)
        Me.Controls.Add(Me.btbT)
        Me.Controls.Add(Me.btnS)
        Me.Controls.Add(Me.btnK)
        Me.Controls.Add(Me.btnA)
        Me.Controls.Add(Me.btnSyokuinnsyoku)
        Me.Controls.Add(Me.btnSyokusuu)
        Me.Controls.Add(Me.btnSinntyouTaijuu)
        Me.Controls.Add(Me.btnSyokuinn)
        Me.Controls.Add(Me.btnDouisyo)
        Me.Controls.Add(Me.btnAsemoni)
        Me.Controls.Add(Me.btnSeibijoukyou)
        Me.Controls.Add(Me.btnSyokusatu)
        Me.Controls.Add(Me.btnNyuukyosya)
        Me.Controls.Add(Me.btnKannfarennsu)
        Me.Controls.Add(Me.btnKeikakusyo)
        Me.Controls.Add(Me.btnSukuri)
        Me.Controls.Add(Me.lstName)
        Me.Name = "topform"
        Me.Text = "NCare"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstName As System.Windows.Forms.ListBox
    Friend WithEvents btnSukuri As System.Windows.Forms.Button
    Friend WithEvents btnKeikakusyo As System.Windows.Forms.Button
    Friend WithEvents btnKannfarennsu As System.Windows.Forms.Button
    Friend WithEvents btnNyuukyosya As System.Windows.Forms.Button
    Friend WithEvents btnSyokusatu As System.Windows.Forms.Button
    Friend WithEvents btnSeibijoukyou As System.Windows.Forms.Button
    Friend WithEvents btnAsemoni As System.Windows.Forms.Button
    Friend WithEvents btnDouisyo As System.Windows.Forms.Button
    Friend WithEvents btnSyokuinn As System.Windows.Forms.Button
    Friend WithEvents btnSinntyouTaijuu As System.Windows.Forms.Button
    Friend WithEvents btnSyokusuu As System.Windows.Forms.Button
    Friend WithEvents btnSyokuinnsyoku As System.Windows.Forms.Button
    Friend WithEvents btnA As System.Windows.Forms.Button
    Friend WithEvents btnK As System.Windows.Forms.Button
    Friend WithEvents btnS As System.Windows.Forms.Button
    Friend WithEvents btbT As System.Windows.Forms.Button
    Friend WithEvents btnN As System.Windows.Forms.Button
    Friend WithEvents btnH As System.Windows.Forms.Button
    Friend WithEvents btnM As System.Windows.Forms.Button
    Friend WithEvents btnY As System.Windows.Forms.Button
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents btnW As System.Windows.Forms.Button

End Class
