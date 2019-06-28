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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rbnPreview = New System.Windows.Forms.RadioButton()
        Me.rbnPrintout = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSukuri
        '
        Me.btnSukuri.BackColor = System.Drawing.Color.Pink
        Me.btnSukuri.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSukuri.Location = New System.Drawing.Point(299, 49)
        Me.btnSukuri.Name = "btnSukuri"
        Me.btnSukuri.Size = New System.Drawing.Size(200, 122)
        Me.btnSukuri.TabIndex = 1
        Me.btnSukuri.Text = "スクリーニング書"
        Me.btnSukuri.UseVisualStyleBackColor = False
        '
        'btnKeikakusyo
        '
        Me.btnKeikakusyo.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnKeikakusyo.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnKeikakusyo.Location = New System.Drawing.Point(299, 178)
        Me.btnKeikakusyo.Name = "btnKeikakusyo"
        Me.btnKeikakusyo.Size = New System.Drawing.Size(200, 122)
        Me.btnKeikakusyo.TabIndex = 2
        Me.btnKeikakusyo.Text = "計画書"
        Me.btnKeikakusyo.UseVisualStyleBackColor = False
        '
        'btnKannfarennsu
        '
        Me.btnKannfarennsu.BackColor = System.Drawing.Color.LimeGreen
        Me.btnKannfarennsu.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnKannfarennsu.Location = New System.Drawing.Point(505, 178)
        Me.btnKannfarennsu.Name = "btnKannfarennsu"
        Me.btnKannfarennsu.Size = New System.Drawing.Size(200, 122)
        Me.btnKannfarennsu.TabIndex = 3
        Me.btnKannfarennsu.Text = "カンファレンス"
        Me.btnKannfarennsu.UseVisualStyleBackColor = False
        '
        'btnNyuukyosya
        '
        Me.btnNyuukyosya.BackColor = System.Drawing.Color.Khaki
        Me.btnNyuukyosya.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnNyuukyosya.Location = New System.Drawing.Point(299, 306)
        Me.btnNyuukyosya.Name = "btnNyuukyosya"
        Me.btnNyuukyosya.Size = New System.Drawing.Size(97, 58)
        Me.btnNyuukyosya.TabIndex = 4
        Me.btnNyuukyosya.Text = "入居者"
        Me.btnNyuukyosya.UseVisualStyleBackColor = False
        '
        'btnSyokusatu
        '
        Me.btnSyokusatu.BackColor = System.Drawing.Color.Pink
        Me.btnSyokusatu.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSyokusatu.Location = New System.Drawing.Point(401, 306)
        Me.btnSyokusatu.Name = "btnSyokusatu"
        Me.btnSyokusatu.Size = New System.Drawing.Size(97, 58)
        Me.btnSyokusatu.TabIndex = 5
        Me.btnSyokusatu.Text = "食札"
        Me.btnSyokusatu.UseVisualStyleBackColor = False
        '
        'btnSeibijoukyou
        '
        Me.btnSeibijoukyou.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnSeibijoukyou.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSeibijoukyou.Location = New System.Drawing.Point(505, 306)
        Me.btnSeibijoukyou.Name = "btnSeibijoukyou"
        Me.btnSeibijoukyou.Size = New System.Drawing.Size(97, 58)
        Me.btnSeibijoukyou.TabIndex = 6
        Me.btnSeibijoukyou.Text = "整備状況"
        Me.btnSeibijoukyou.UseVisualStyleBackColor = False
        '
        'btnAsemoni
        '
        Me.btnAsemoni.BackColor = System.Drawing.Color.Pink
        Me.btnAsemoni.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAsemoni.Location = New System.Drawing.Point(608, 306)
        Me.btnAsemoni.Name = "btnAsemoni"
        Me.btnAsemoni.Size = New System.Drawing.Size(97, 58)
        Me.btnAsemoni.TabIndex = 7
        Me.btnAsemoni.Text = "アセモニ"
        Me.btnAsemoni.UseVisualStyleBackColor = False
        '
        'btnDouisyo
        '
        Me.btnDouisyo.BackColor = System.Drawing.Color.Coral
        Me.btnDouisyo.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDouisyo.Location = New System.Drawing.Point(299, 370)
        Me.btnDouisyo.Name = "btnDouisyo"
        Me.btnDouisyo.Size = New System.Drawing.Size(97, 58)
        Me.btnDouisyo.TabIndex = 8
        Me.btnDouisyo.Text = "同意書"
        Me.btnDouisyo.UseVisualStyleBackColor = False
        '
        'btnSyokuinn
        '
        Me.btnSyokuinn.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSyokuinn.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSyokuinn.Location = New System.Drawing.Point(402, 370)
        Me.btnSyokuinn.Name = "btnSyokuinn"
        Me.btnSyokuinn.Size = New System.Drawing.Size(97, 58)
        Me.btnSyokuinn.TabIndex = 9
        Me.btnSyokuinn.Text = "職員"
        Me.btnSyokuinn.UseVisualStyleBackColor = False
        '
        'btnSinntyouTaijuu
        '
        Me.btnSinntyouTaijuu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSinntyouTaijuu.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSinntyouTaijuu.Location = New System.Drawing.Point(505, 370)
        Me.btnSinntyouTaijuu.Name = "btnSinntyouTaijuu"
        Me.btnSinntyouTaijuu.Size = New System.Drawing.Size(97, 58)
        Me.btnSinntyouTaijuu.TabIndex = 10
        Me.btnSinntyouTaijuu.Text = "身長/体重"
        Me.btnSinntyouTaijuu.UseVisualStyleBackColor = False
        '
        'btnSyokusuu
        '
        Me.btnSyokusuu.BackColor = System.Drawing.Color.Magenta
        Me.btnSyokusuu.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSyokusuu.Location = New System.Drawing.Point(299, 434)
        Me.btnSyokusuu.Name = "btnSyokusuu"
        Me.btnSyokusuu.Size = New System.Drawing.Size(97, 58)
        Me.btnSyokusuu.TabIndex = 11
        Me.btnSyokusuu.Text = "ＳＳ食数"
        Me.btnSyokusuu.UseVisualStyleBackColor = False
        '
        'btnSyokuinnsyoku
        '
        Me.btnSyokuinnsyoku.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnSyokuinnsyoku.Font = New System.Drawing.Font("UD デジタル 教科書体 NP-B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSyokuinnsyoku.Location = New System.Drawing.Point(402, 434)
        Me.btnSyokuinnsyoku.Name = "btnSyokuinnsyoku"
        Me.btnSyokuinnsyoku.Size = New System.Drawing.Size(97, 58)
        Me.btnSyokuinnsyoku.TabIndex = 12
        Me.btnSyokuinnsyoku.Text = "職員食"
        Me.btnSyokuinnsyoku.UseVisualStyleBackColor = False
        '
        'btnA
        '
        Me.btnA.Location = New System.Drawing.Point(69, 59)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(23, 23)
        Me.btnA.TabIndex = 13
        Me.btnA.Text = "あ"
        Me.btnA.UseVisualStyleBackColor = True
        '
        'btnK
        '
        Me.btnK.Location = New System.Drawing.Point(69, 81)
        Me.btnK.Name = "btnK"
        Me.btnK.Size = New System.Drawing.Size(23, 23)
        Me.btnK.TabIndex = 14
        Me.btnK.Text = "か"
        Me.btnK.UseVisualStyleBackColor = True
        '
        'btnS
        '
        Me.btnS.Location = New System.Drawing.Point(69, 103)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(23, 23)
        Me.btnS.TabIndex = 15
        Me.btnS.Text = "さ"
        Me.btnS.UseVisualStyleBackColor = True
        '
        'btbT
        '
        Me.btbT.Location = New System.Drawing.Point(69, 125)
        Me.btbT.Name = "btbT"
        Me.btbT.Size = New System.Drawing.Size(23, 23)
        Me.btbT.TabIndex = 16
        Me.btbT.Text = "た"
        Me.btbT.UseVisualStyleBackColor = True
        '
        'btnN
        '
        Me.btnN.Location = New System.Drawing.Point(69, 147)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(23, 23)
        Me.btnN.TabIndex = 17
        Me.btnN.Text = "な"
        Me.btnN.UseVisualStyleBackColor = True
        '
        'btnH
        '
        Me.btnH.Location = New System.Drawing.Point(69, 169)
        Me.btnH.Name = "btnH"
        Me.btnH.Size = New System.Drawing.Size(23, 23)
        Me.btnH.TabIndex = 18
        Me.btnH.Text = "は"
        Me.btnH.UseVisualStyleBackColor = True
        '
        'btnM
        '
        Me.btnM.Location = New System.Drawing.Point(69, 191)
        Me.btnM.Name = "btnM"
        Me.btnM.Size = New System.Drawing.Size(23, 23)
        Me.btnM.TabIndex = 19
        Me.btnM.Text = "ま"
        Me.btnM.UseVisualStyleBackColor = True
        '
        'btnY
        '
        Me.btnY.Location = New System.Drawing.Point(69, 213)
        Me.btnY.Name = "btnY"
        Me.btnY.Size = New System.Drawing.Size(23, 23)
        Me.btnY.TabIndex = 20
        Me.btnY.Text = "や"
        Me.btnY.UseVisualStyleBackColor = True
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(69, 235)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(23, 23)
        Me.btnR.TabIndex = 21
        Me.btnR.Text = "ら"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'btnW
        '
        Me.btnW.Location = New System.Drawing.Point(69, 257)
        Me.btnW.Name = "btnW"
        Me.btnW.Size = New System.Drawing.Size(23, 23)
        Me.btnW.TabIndex = 22
        Me.btnW.Text = "わ"
        Me.btnW.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Blue
        Me.lblName.Location = New System.Drawing.Point(105, 19)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(47, 19)
        Me.lblName.TabIndex = 23
        Me.lblName.Text = "氏名"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(100, 63)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(140, 212)
        Me.DataGridView1.TabIndex = 24
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(720, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(197, 187)
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'rbnPreview
        '
        Me.rbnPreview.AutoSize = True
        Me.rbnPreview.Location = New System.Drawing.Point(741, 306)
        Me.rbnPreview.Name = "rbnPreview"
        Me.rbnPreview.Size = New System.Drawing.Size(63, 16)
        Me.rbnPreview.TabIndex = 26
        Me.rbnPreview.Text = "ﾌﾟﾚﾋﾞｭｰ"
        Me.rbnPreview.UseVisualStyleBackColor = True
        '
        'rbnPrintout
        '
        Me.rbnPrintout.AutoSize = True
        Me.rbnPrintout.Location = New System.Drawing.Point(741, 329)
        Me.rbnPrintout.Name = "rbnPrintout"
        Me.rbnPrintout.Size = New System.Drawing.Size(47, 16)
        Me.rbnPrintout.TabIndex = 27
        Me.rbnPrintout.Text = "印刷"
        Me.rbnPrintout.UseVisualStyleBackColor = True
        '
        'topform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 674)
        Me.Controls.Add(Me.rbnPrintout)
        Me.Controls.Add(Me.rbnPreview)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblName)
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
        Me.Name = "topform"
        Me.Text = "NCare"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rbnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbnPrintout As System.Windows.Forms.RadioButton

End Class
