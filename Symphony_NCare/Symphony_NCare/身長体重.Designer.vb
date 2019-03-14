<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 身長体重
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
        Me.YmdBox1 = New ymdBox.ymdBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTouroku = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.DataGridView6 = New System.Windows.Forms.DataGridView()
        Me.DataGridView7 = New System.Windows.Forms.DataGridView()
        Me.DataGridView8 = New System.Windows.Forms.DataGridView()
        Me.DataGridView9 = New System.Windows.Forms.DataGridView()
        Me.DataGridView10 = New System.Windows.Forms.DataGridView()
        Me.lblDGV1PSC = New System.Windows.Forms.Label()
        Me.lblDGV2PSC = New System.Windows.Forms.Label()
        Me.lblDGV3PSC = New System.Windows.Forms.Label()
        Me.lblDGV4PSC = New System.Windows.Forms.Label()
        Me.lblDGV5PSC = New System.Windows.Forms.Label()
        Me.lblDGV6PSC = New System.Windows.Forms.Label()
        Me.lblDGV7PSC = New System.Windows.Forms.Label()
        Me.lblDGV8PSC = New System.Windows.Forms.Label()
        Me.lblDGV9PSC = New System.Windows.Forms.Label()
        Me.lblDGV10PSC = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridViewHeight = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YmdBox1
        '
        Me.YmdBox1.boxType = 7
        Me.YmdBox1.DateText = ""
        Me.YmdBox1.EraLabelText = "H31"
        Me.YmdBox1.EraText = ""
        Me.YmdBox1.Location = New System.Drawing.Point(29, 12)
        Me.YmdBox1.MonthLabelText = "03"
        Me.YmdBox1.MonthText = ""
        Me.YmdBox1.Name = "YmdBox1"
        Me.YmdBox1.Size = New System.Drawing.Size(120, 46)
        Me.YmdBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "※身長の保存/呼出元は一箇所、各月から変更可能"
        '
        'btnTouroku
        '
        Me.btnTouroku.Location = New System.Drawing.Point(549, 20)
        Me.btnTouroku.Name = "btnTouroku"
        Me.btnTouroku.Size = New System.Drawing.Size(57, 31)
        Me.btnTouroku.TabIndex = 2
        Me.btnTouroku.Text = "登録"
        Me.btnTouroku.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 75)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView1.TabIndex = 3
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(222, 75)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 21
        Me.DataGridView2.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView2.TabIndex = 4
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(432, 75)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowTemplate.Height = 21
        Me.DataGridView3.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView3.TabIndex = 5
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(642, 75)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.RowTemplate.Height = 21
        Me.DataGridView4.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView4.TabIndex = 6
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(852, 75)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.RowTemplate.Height = 21
        Me.DataGridView5.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView5.TabIndex = 7
        '
        'DataGridView6
        '
        Me.DataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView6.Location = New System.Drawing.Point(12, 316)
        Me.DataGridView6.Name = "DataGridView6"
        Me.DataGridView6.RowTemplate.Height = 21
        Me.DataGridView6.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView6.TabIndex = 8
        '
        'DataGridView7
        '
        Me.DataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView7.Location = New System.Drawing.Point(222, 316)
        Me.DataGridView7.Name = "DataGridView7"
        Me.DataGridView7.RowTemplate.Height = 21
        Me.DataGridView7.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView7.TabIndex = 9
        '
        'DataGridView8
        '
        Me.DataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView8.Location = New System.Drawing.Point(432, 316)
        Me.DataGridView8.Name = "DataGridView8"
        Me.DataGridView8.RowTemplate.Height = 21
        Me.DataGridView8.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView8.TabIndex = 10
        '
        'DataGridView9
        '
        Me.DataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView9.Location = New System.Drawing.Point(642, 316)
        Me.DataGridView9.Name = "DataGridView9"
        Me.DataGridView9.RowTemplate.Height = 21
        Me.DataGridView9.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView9.TabIndex = 11
        '
        'DataGridView10
        '
        Me.DataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView10.Location = New System.Drawing.Point(852, 316)
        Me.DataGridView10.Name = "DataGridView10"
        Me.DataGridView10.RowTemplate.Height = 21
        Me.DataGridView10.Size = New System.Drawing.Size(210, 205)
        Me.DataGridView10.TabIndex = 12
        '
        'lblDGV1PSC
        '
        Me.lblDGV1PSC.AutoSize = True
        Me.lblDGV1PSC.Location = New System.Drawing.Point(37, 288)
        Me.lblDGV1PSC.Name = "lblDGV1PSC"
        Me.lblDGV1PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV1PSC.TabIndex = 13
        Me.lblDGV1PSC.Text = "-名"
        '
        'lblDGV2PSC
        '
        Me.lblDGV2PSC.AutoSize = True
        Me.lblDGV2PSC.Location = New System.Drawing.Point(248, 288)
        Me.lblDGV2PSC.Name = "lblDGV2PSC"
        Me.lblDGV2PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV2PSC.TabIndex = 14
        Me.lblDGV2PSC.Text = "-名"
        '
        'lblDGV3PSC
        '
        Me.lblDGV3PSC.AutoSize = True
        Me.lblDGV3PSC.Location = New System.Drawing.Point(459, 288)
        Me.lblDGV3PSC.Name = "lblDGV3PSC"
        Me.lblDGV3PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV3PSC.TabIndex = 15
        Me.lblDGV3PSC.Text = "-名"
        '
        'lblDGV4PSC
        '
        Me.lblDGV4PSC.AutoSize = True
        Me.lblDGV4PSC.Location = New System.Drawing.Point(670, 288)
        Me.lblDGV4PSC.Name = "lblDGV4PSC"
        Me.lblDGV4PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV4PSC.TabIndex = 16
        Me.lblDGV4PSC.Text = "-名"
        '
        'lblDGV5PSC
        '
        Me.lblDGV5PSC.AutoSize = True
        Me.lblDGV5PSC.Location = New System.Drawing.Point(881, 288)
        Me.lblDGV5PSC.Name = "lblDGV5PSC"
        Me.lblDGV5PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV5PSC.TabIndex = 17
        Me.lblDGV5PSC.Text = "-名"
        '
        'lblDGV6PSC
        '
        Me.lblDGV6PSC.AutoSize = True
        Me.lblDGV6PSC.Location = New System.Drawing.Point(37, 531)
        Me.lblDGV6PSC.Name = "lblDGV6PSC"
        Me.lblDGV6PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV6PSC.TabIndex = 18
        Me.lblDGV6PSC.Text = "-名"
        '
        'lblDGV7PSC
        '
        Me.lblDGV7PSC.AutoSize = True
        Me.lblDGV7PSC.Location = New System.Drawing.Point(248, 531)
        Me.lblDGV7PSC.Name = "lblDGV7PSC"
        Me.lblDGV7PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV7PSC.TabIndex = 19
        Me.lblDGV7PSC.Text = "-名"
        '
        'lblDGV8PSC
        '
        Me.lblDGV8PSC.AutoSize = True
        Me.lblDGV8PSC.Location = New System.Drawing.Point(459, 531)
        Me.lblDGV8PSC.Name = "lblDGV8PSC"
        Me.lblDGV8PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV8PSC.TabIndex = 20
        Me.lblDGV8PSC.Text = "-名"
        '
        'lblDGV9PSC
        '
        Me.lblDGV9PSC.AutoSize = True
        Me.lblDGV9PSC.Location = New System.Drawing.Point(670, 531)
        Me.lblDGV9PSC.Name = "lblDGV9PSC"
        Me.lblDGV9PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV9PSC.TabIndex = 21
        Me.lblDGV9PSC.Text = "-名"
        '
        'lblDGV10PSC
        '
        Me.lblDGV10PSC.AutoSize = True
        Me.lblDGV10PSC.Location = New System.Drawing.Point(881, 531)
        Me.lblDGV10PSC.Name = "lblDGV10PSC"
        Me.lblDGV10PSC.Size = New System.Drawing.Size(23, 12)
        Me.lblDGV10PSC.TabIndex = 22
        Me.lblDGV10PSC.Text = "-名"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(895, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 24)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'DataGridViewHeight
        '
        Me.DataGridViewHeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewHeight.Location = New System.Drawing.Point(580, 39)
        Me.DataGridViewHeight.Name = "DataGridViewHeight"
        Me.DataGridViewHeight.RowTemplate.Height = 21
        Me.DataGridViewHeight.Size = New System.Drawing.Size(10, 10)
        Me.DataGridViewHeight.TabIndex = 24
        '
        '身長体重
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1361, 761)
        Me.Controls.Add(Me.btnTouroku)
        Me.Controls.Add(Me.DataGridViewHeight)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblDGV10PSC)
        Me.Controls.Add(Me.lblDGV9PSC)
        Me.Controls.Add(Me.lblDGV8PSC)
        Me.Controls.Add(Me.lblDGV7PSC)
        Me.Controls.Add(Me.lblDGV6PSC)
        Me.Controls.Add(Me.lblDGV5PSC)
        Me.Controls.Add(Me.lblDGV4PSC)
        Me.Controls.Add(Me.lblDGV3PSC)
        Me.Controls.Add(Me.lblDGV2PSC)
        Me.Controls.Add(Me.lblDGV1PSC)
        Me.Controls.Add(Me.DataGridView10)
        Me.Controls.Add(Me.DataGridView9)
        Me.Controls.Add(Me.DataGridView8)
        Me.Controls.Add(Me.DataGridView7)
        Me.Controls.Add(Me.DataGridView6)
        Me.Controls.Add(Me.DataGridView5)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.YmdBox1)
        Me.Name = "身長体重"
        Me.Text = "身長体重"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents YmdBox1 As ymdBox.ymdBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTouroku As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView6 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView7 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView8 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView9 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView10 As System.Windows.Forms.DataGridView
    Friend WithEvents lblDGV1PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV2PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV3PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV4PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV5PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV6PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV7PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV8PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV9PSC As System.Windows.Forms.Label
    Friend WithEvents lblDGV10PSC As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewHeight As System.Windows.Forms.DataGridView
End Class
