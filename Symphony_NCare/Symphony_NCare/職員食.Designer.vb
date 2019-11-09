<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 職員食
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTouroku = New System.Windows.Forms.Button()
        Me.btnSakujo = New System.Windows.Forms.Button()
        Me.btnInnsatu = New System.Windows.Forms.Button()
        Me.lstSyuN = New System.Windows.Forms.ListBox()
        Me.lstName = New System.Windows.Forms.ListBox()
        Me.btnTuika = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.lblYmd = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New Symphony_NCare.職員食Class()
        Me.btnGyoSakujo = New System.Windows.Forms.Button()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "月曜"
        '
        'btnTouroku
        '
        Me.btnTouroku.Location = New System.Drawing.Point(549, 24)
        Me.btnTouroku.Name = "btnTouroku"
        Me.btnTouroku.Size = New System.Drawing.Size(69, 30)
        Me.btnTouroku.TabIndex = 3
        Me.btnTouroku.Text = "登録"
        Me.btnTouroku.UseVisualStyleBackColor = True
        '
        'btnSakujo
        '
        Me.btnSakujo.Location = New System.Drawing.Point(645, 24)
        Me.btnSakujo.Name = "btnSakujo"
        Me.btnSakujo.Size = New System.Drawing.Size(69, 30)
        Me.btnSakujo.TabIndex = 4
        Me.btnSakujo.Text = "削除"
        Me.btnSakujo.UseVisualStyleBackColor = True
        '
        'btnInnsatu
        '
        Me.btnInnsatu.Location = New System.Drawing.Point(741, 25)
        Me.btnInnsatu.Name = "btnInnsatu"
        Me.btnInnsatu.Size = New System.Drawing.Size(69, 30)
        Me.btnInnsatu.TabIndex = 5
        Me.btnInnsatu.Text = "印刷"
        Me.btnInnsatu.UseVisualStyleBackColor = True
        '
        'lstSyuN
        '
        Me.lstSyuN.FormattingEnabled = True
        Me.lstSyuN.ItemHeight = 12
        Me.lstSyuN.Items.AddRange(New Object() {"管理系", "事務", "特別養護老人ホーム", "栄養課", "居宅介護支援事業所", "ヘルパーステーション", "デイサービス", "生活支援ハウス", "宿直", "その他"})
        Me.lstSyuN.Location = New System.Drawing.Point(864, 96)
        Me.lstSyuN.Name = "lstSyuN"
        Me.lstSyuN.Size = New System.Drawing.Size(146, 148)
        Me.lstSyuN.TabIndex = 6
        '
        'lstName
        '
        Me.lstName.FormattingEnabled = True
        Me.lstName.ItemHeight = 12
        Me.lstName.Location = New System.Drawing.Point(864, 260)
        Me.lstName.Name = "lstName"
        Me.lstName.Size = New System.Drawing.Size(146, 268)
        Me.lstName.TabIndex = 7
        '
        'btnTuika
        '
        Me.btnTuika.Location = New System.Drawing.Point(899, 548)
        Me.btnTuika.Name = "btnTuika"
        Me.btnTuika.Size = New System.Drawing.Size(80, 29)
        Me.btnTuika.TabIndex = 8
        Me.btnTuika.Text = "追加"
        Me.btnTuika.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(225, 31)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(17, 19)
        Me.btnDown.TabIndex = 11
        Me.btnDown.Text = "▼"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(225, 13)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(17, 19)
        Me.btnUp.TabIndex = 10
        Me.btnUp.Text = "▲"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'lblYmd
        '
        Me.lblYmd.AutoSize = True
        Me.lblYmd.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYmd.Location = New System.Drawing.Point(89, 23)
        Me.lblYmd.Name = "lblYmd"
        Me.lblYmd.Size = New System.Drawing.Size(126, 19)
        Me.lblYmd.TabIndex = 9
        Me.lblYmd.Text = "H30.12.31 (月)"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(549, 31)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView2.TabIndex = 12
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label52.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label52.Location = New System.Drawing.Point(42, 116)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(775, 2)
        Me.Label52.TabIndex = 399
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label11.Location = New System.Drawing.Point(222, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(2, 585)
        Me.Label11.TabIndex = 410
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(298, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(2, 628)
        Me.Label2.TabIndex = 411
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(373, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(2, 628)
        Me.Label3.TabIndex = 412
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(448, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(2, 628)
        Me.Label4.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(523, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(2, 628)
        Me.Label5.TabIndex = 414
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(598, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(2, 628)
        Me.Label6.TabIndex = 415
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label7.Location = New System.Drawing.Point(673, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(2, 628)
        Me.Label7.TabIndex = 416
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label8.Location = New System.Drawing.Point(748, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(2, 628)
        Me.Label8.TabIndex = 417
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(63, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(2, 44)
        Me.Label9.TabIndex = 418
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label10.Location = New System.Drawing.Point(133, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(2, 44)
        Me.Label10.TabIndex = 419
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label12.Location = New System.Drawing.Point(224, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(524, 2)
        Me.Label12.TabIndex = 420
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeColumns = False
        Me.DataGridView3.AllowUserToResizeRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(222, 658)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowTemplate.Height = 21
        Me.DataGridView3.Size = New System.Drawing.Size(598, 43)
        Me.DataGridView3.TabIndex = 421
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(322, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 25)
        Me.Button1.TabIndex = 422
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(42, 72)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.RowTemplate.Height = 21
        Me.DataGridView4.Size = New System.Drawing.Size(778, 45)
        Me.DataGridView4.TabIndex = 423
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label13.Location = New System.Drawing.Point(224, 679)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(524, 2)
        Me.Label13.TabIndex = 424
        '
        'DataGridView5
        '
        Me.DataGridView5.AllowUserToAddRows = False
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(590, 40)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.RowTemplate.Height = 21
        Me.DataGridView5.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView5.TabIndex = 425
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(42, 116)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(795, 543)
        Me.DataGridView1.TabIndex = 426
        '
        'btnGyoSakujo
        '
        Me.btnGyoSakujo.Location = New System.Drawing.Point(899, 600)
        Me.btnGyoSakujo.Name = "btnGyoSakujo"
        Me.btnGyoSakujo.Size = New System.Drawing.Size(80, 29)
        Me.btnGyoSakujo.TabIndex = 427
        Me.btnGyoSakujo.Text = "行削除"
        Me.btnGyoSakujo.UseVisualStyleBackColor = True
        '
        '職員食
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1181, 784)
        Me.Controls.Add(Me.btnGyoSakujo)
        Me.Controls.Add(Me.btnTouroku)
        Me.Controls.Add(Me.DataGridView5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.lblYmd)
        Me.Controls.Add(Me.btnTuika)
        Me.Controls.Add(Me.lstName)
        Me.Controls.Add(Me.lstSyuN)
        Me.Controls.Add(Me.btnInnsatu)
        Me.Controls.Add(Me.btnSakujo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "職員食"
        Me.Text = "職員食"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTouroku As System.Windows.Forms.Button
    Friend WithEvents btnSakujo As System.Windows.Forms.Button
    Friend WithEvents btnInnsatu As System.Windows.Forms.Button
    Friend WithEvents lstSyuN As System.Windows.Forms.ListBox
    Friend WithEvents lstName As System.Windows.Forms.ListBox
    Friend WithEvents btnTuika As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents lblYmd As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As Symphony_NCare.職員食Class
    Friend WithEvents btnGyoSakujo As System.Windows.Forms.Button
End Class
