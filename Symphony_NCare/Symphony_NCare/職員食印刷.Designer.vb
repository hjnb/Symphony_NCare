<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 職員食印刷
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
        Me.rbnSyokuinn = New System.Windows.Forms.RadioButton()
        Me.rbnSyuukann = New System.Windows.Forms.RadioButton()
        Me.rbnSeikyuu = New System.Windows.Forms.RadioButton()
        Me.YmdBox1 = New ymdBox.ymdBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnNO = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbnSyokuinn
        '
        Me.rbnSyokuinn.AutoSize = True
        Me.rbnSyokuinn.Location = New System.Drawing.Point(24, 26)
        Me.rbnSyokuinn.Name = "rbnSyokuinn"
        Me.rbnSyokuinn.Size = New System.Drawing.Size(95, 16)
        Me.rbnSyokuinn.TabIndex = 0
        Me.rbnSyokuinn.TabStop = True
        Me.rbnSyokuinn.Text = "職員食申込表"
        Me.rbnSyokuinn.UseVisualStyleBackColor = True
        '
        'rbnSyuukann
        '
        Me.rbnSyuukann.AutoSize = True
        Me.rbnSyuukann.Location = New System.Drawing.Point(150, 26)
        Me.rbnSyuukann.Name = "rbnSyuukann"
        Me.rbnSyuukann.Size = New System.Drawing.Size(83, 16)
        Me.rbnSyuukann.TabIndex = 1
        Me.rbnSyuukann.TabStop = True
        Me.rbnSyuukann.Text = "週間集計表"
        Me.rbnSyuukann.UseVisualStyleBackColor = True
        '
        'rbnSeikyuu
        '
        Me.rbnSeikyuu.AutoSize = True
        Me.rbnSeikyuu.Location = New System.Drawing.Point(272, 26)
        Me.rbnSeikyuu.Name = "rbnSeikyuu"
        Me.rbnSeikyuu.Size = New System.Drawing.Size(71, 16)
        Me.rbnSeikyuu.TabIndex = 2
        Me.rbnSeikyuu.TabStop = True
        Me.rbnSeikyuu.Text = "請求一覧"
        Me.rbnSeikyuu.UseVisualStyleBackColor = True
        '
        'YmdBox1
        '
        Me.YmdBox1.boxType = 5
        Me.YmdBox1.DateText = ""
        Me.YmdBox1.EraLabelText = "H31"
        Me.YmdBox1.EraText = ""
        Me.YmdBox1.Location = New System.Drawing.Point(59, 70)
        Me.YmdBox1.MonthLabelText = "03"
        Me.YmdBox1.MonthText = ""
        Me.YmdBox1.Name = "YmdBox1"
        Me.YmdBox1.Size = New System.Drawing.Size(95, 40)
        Me.YmdBox1.TabIndex = 3
        Me.YmdBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(205, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "朝食"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "昼食"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(205, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "夕食"
        Me.Label3.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(259, 66)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(51, 19)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "164"
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(259, 94)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(51, 19)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Text = "329"
        Me.TextBox2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(259, 123)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(51, 19)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.Text = "329"
        Me.TextBox3.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(94, 160)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(60, 32)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "実行"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnNO
        '
        Me.btnNO.Location = New System.Drawing.Point(195, 160)
        Me.btnNO.Name = "btnNO"
        Me.btnNO.Size = New System.Drawing.Size(60, 32)
        Me.btnNO.TabIndex = 11
        Me.btnNO.Text = "ｷｬﾝｾﾙ"
        Me.btnNO.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(94, 160)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView1.TabIndex = 12
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(144, 182)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView2.TabIndex = 14
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(94, 176)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.RowTemplate.Height = 21
        Me.DataGridView5.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView5.TabIndex = 15
        '
        '職員食印刷
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 214)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.DataGridView5)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnNO)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.YmdBox1)
        Me.Controls.Add(Me.rbnSeikyuu)
        Me.Controls.Add(Me.rbnSyuukann)
        Me.Controls.Add(Me.rbnSyokuinn)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "職員食印刷"
        Me.Text = "職員食印刷"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbnSyokuinn As System.Windows.Forms.RadioButton
    Friend WithEvents rbnSyuukann As System.Windows.Forms.RadioButton
    Friend WithEvents rbnSeikyuu As System.Windows.Forms.RadioButton
    Friend WithEvents YmdBox1 As ymdBox.ymdBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnNO As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
End Class
