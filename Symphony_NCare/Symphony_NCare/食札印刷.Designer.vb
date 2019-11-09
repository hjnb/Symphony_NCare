<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 食札印刷
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
        Me.rbnKojinn = New System.Windows.Forms.RadioButton()
        Me.chkHukusuu = New System.Windows.Forms.CheckBox()
        Me.rbnAll = New System.Windows.Forms.RadioButton()
        Me.rbnItirann = New System.Windows.Forms.RadioButton()
        Me.rbnTokki = New System.Windows.Forms.RadioButton()
        Me.btnJikkou = New System.Windows.Forms.Button()
        Me.btnKyannseru = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbnKojinn
        '
        Me.rbnKojinn.AutoSize = True
        Me.rbnKojinn.Checked = True
        Me.rbnKojinn.Location = New System.Drawing.Point(50, 45)
        Me.rbnKojinn.Name = "rbnKojinn"
        Me.rbnKojinn.Size = New System.Drawing.Size(47, 16)
        Me.rbnKojinn.TabIndex = 1
        Me.rbnKojinn.TabStop = True
        Me.rbnKojinn.Text = "個人"
        Me.rbnKojinn.UseVisualStyleBackColor = True
        '
        'chkHukusuu
        '
        Me.chkHukusuu.AutoSize = True
        Me.chkHukusuu.Location = New System.Drawing.Point(103, 45)
        Me.chkHukusuu.Name = "chkHukusuu"
        Me.chkHukusuu.Size = New System.Drawing.Size(56, 16)
        Me.chkHukusuu.TabIndex = 2
        Me.chkHukusuu.Text = "(複数)"
        Me.chkHukusuu.UseVisualStyleBackColor = True
        '
        'rbnAll
        '
        Me.rbnAll.AutoSize = True
        Me.rbnAll.Location = New System.Drawing.Point(180, 45)
        Me.rbnAll.Name = "rbnAll"
        Me.rbnAll.Size = New System.Drawing.Size(59, 16)
        Me.rbnAll.TabIndex = 3
        Me.rbnAll.TabStop = True
        Me.rbnAll.Text = "全食札"
        Me.rbnAll.UseVisualStyleBackColor = True
        '
        'rbnItirann
        '
        Me.rbnItirann.AutoSize = True
        Me.rbnItirann.Location = New System.Drawing.Point(260, 45)
        Me.rbnItirann.Name = "rbnItirann"
        Me.rbnItirann.Size = New System.Drawing.Size(59, 16)
        Me.rbnItirann.TabIndex = 4
        Me.rbnItirann.TabStop = True
        Me.rbnItirann.Text = "一覧表"
        Me.rbnItirann.UseVisualStyleBackColor = True
        '
        'rbnTokki
        '
        Me.rbnTokki.AutoSize = True
        Me.rbnTokki.Location = New System.Drawing.Point(346, 45)
        Me.rbnTokki.Name = "rbnTokki"
        Me.rbnTokki.Size = New System.Drawing.Size(71, 16)
        Me.rbnTokki.TabIndex = 5
        Me.rbnTokki.TabStop = True
        Me.rbnTokki.Text = "特記事項"
        Me.rbnTokki.UseVisualStyleBackColor = True
        '
        'btnJikkou
        '
        Me.btnJikkou.Location = New System.Drawing.Point(117, 86)
        Me.btnJikkou.Name = "btnJikkou"
        Me.btnJikkou.Size = New System.Drawing.Size(71, 29)
        Me.btnJikkou.TabIndex = 6
        Me.btnJikkou.Text = "実行"
        Me.btnJikkou.UseVisualStyleBackColor = True
        '
        'btnKyannseru
        '
        Me.btnKyannseru.Location = New System.Drawing.Point(245, 86)
        Me.btnKyannseru.Name = "btnKyannseru"
        Me.btnKyannseru.Size = New System.Drawing.Size(71, 29)
        Me.btnKyannseru.TabIndex = 7
        Me.btnKyannseru.Text = "キャンセル"
        Me.btnKyannseru.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(178, 105)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView1.TabIndex = 8
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(138, 95)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView2.TabIndex = 9
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(34, 32)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(1, 41)
        Me.Label23.TabIndex = 128
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(35, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(398, 1)
        Me.Label21.TabIndex = 127
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(432, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1, 41)
        Me.Label1.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(398, 1)
        Me.Label2.TabIndex = 129
        '
        '食札印刷
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 136)
        Me.Controls.Add(Me.btnJikkou)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnKyannseru)
        Me.Controls.Add(Me.rbnTokki)
        Me.Controls.Add(Me.rbnItirann)
        Me.Controls.Add(Me.rbnAll)
        Me.Controls.Add(Me.chkHukusuu)
        Me.Controls.Add(Me.rbnKojinn)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "食札印刷"
        Me.Text = "食札印刷"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbnKojinn As System.Windows.Forms.RadioButton
    Friend WithEvents chkHukusuu As System.Windows.Forms.CheckBox
    Friend WithEvents rbnAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbnItirann As System.Windows.Forms.RadioButton
    Friend WithEvents rbnTokki As System.Windows.Forms.RadioButton
    Friend WithEvents btnJikkou As System.Windows.Forms.Button
    Friend WithEvents btnKyannseru As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
