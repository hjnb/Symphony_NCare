<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 入居者
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtNam = New System.Windows.Forms.TextBox()
        Me.txtKana = New System.Windows.Forms.TextBox()
        Me.txtSex = New System.Windows.Forms.TextBox()
        Me.ymdboxBirth = New ymdBox.ymdBox()
        Me.txtJyu = New System.Windows.Forms.TextBox()
        Me.ymdboxYmd = New ymdBox.ymdBox()
        Me.rbnMori = New System.Windows.Forms.RadioButton()
        Me.rbnHosi = New System.Windows.Forms.RadioButton()
        Me.rbnSora = New System.Windows.Forms.RadioButton()
        Me.rbnHana = New System.Windows.Forms.RadioButton()
        Me.rbnTuki = New System.Windows.Forms.RadioButton()
        Me.rbnUmi = New System.Windows.Forms.RadioButton()
        Me.rbnNiji = New System.Windows.Forms.RadioButton()
        Me.rbnHikari = New System.Windows.Forms.RadioButton()
        Me.rbnOka = New System.Windows.Forms.RadioButton()
        Me.rbnKaze = New System.Windows.Forms.RadioButton()
        Me.rbnYuki = New System.Windows.Forms.RadioButton()
        Me.txtHyo = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "利用者氏名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ふりがな"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "性別"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "（１：男　２：女）"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "生年月日"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "住所"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "登録日"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "ユニット"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "表示"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(139, 220)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "（１：表示　２：非表示〔退所等〕）"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Location = New System.Drawing.Point(110, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(161, 12)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "ﾀﾞﾌﾞﾙｸﾘｯｸした項目名で並べます"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeight = 22
        Me.DataGridView1.Location = New System.Drawing.Point(34, 273)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(614, 247)
        Me.DataGridView1.TabIndex = 11
        '
        'txtNam
        '
        Me.txtNam.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtNam.Location = New System.Drawing.Point(112, 21)
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(129, 19)
        Me.txtNam.TabIndex = 12
        '
        'txtKana
        '
        Me.txtKana.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKana.Location = New System.Drawing.Point(112, 49)
        Me.txtKana.Name = "txtKana"
        Me.txtKana.Size = New System.Drawing.Size(129, 19)
        Me.txtKana.TabIndex = 13
        '
        'txtSex
        '
        Me.txtSex.Location = New System.Drawing.Point(112, 76)
        Me.txtSex.Name = "txtSex"
        Me.txtSex.Size = New System.Drawing.Size(21, 19)
        Me.txtSex.TabIndex = 14
        '
        'ymdboxBirth
        '
        Me.ymdboxBirth.boxType = 0
        Me.ymdboxBirth.DateText = ""
        Me.ymdboxBirth.EraLabelText = "H31"
        Me.ymdboxBirth.EraText = ""
        Me.ymdboxBirth.Location = New System.Drawing.Point(111, 102)
        Me.ymdboxBirth.MonthLabelText = "01"
        Me.ymdboxBirth.MonthText = ""
        Me.ymdboxBirth.Name = "ymdboxBirth"
        Me.ymdboxBirth.Size = New System.Drawing.Size(101, 29)
        Me.ymdboxBirth.TabIndex = 15
        '
        'txtJyu
        '
        Me.txtJyu.Location = New System.Drawing.Point(112, 133)
        Me.txtJyu.Name = "txtJyu"
        Me.txtJyu.ReadOnly = True
        Me.txtJyu.Size = New System.Drawing.Size(129, 19)
        Me.txtJyu.TabIndex = 16
        Me.txtJyu.Text = "シンフォニー"
        '
        'ymdboxYmd
        '
        Me.ymdboxYmd.boxType = 0
        Me.ymdboxYmd.DateText = ""
        Me.ymdboxYmd.EraLabelText = "H31"
        Me.ymdboxYmd.EraText = ""
        Me.ymdboxYmd.Location = New System.Drawing.Point(111, 159)
        Me.ymdboxYmd.MonthLabelText = "01"
        Me.ymdboxYmd.MonthText = ""
        Me.ymdboxYmd.Name = "ymdboxYmd"
        Me.ymdboxYmd.Size = New System.Drawing.Size(86, 20)
        Me.ymdboxYmd.TabIndex = 17
        '
        'rbnMori
        '
        Me.rbnMori.AutoSize = True
        Me.rbnMori.Location = New System.Drawing.Point(112, 190)
        Me.rbnMori.Name = "rbnMori"
        Me.rbnMori.Size = New System.Drawing.Size(35, 16)
        Me.rbnMori.TabIndex = 18
        Me.rbnMori.TabStop = True
        Me.rbnMori.Text = "森"
        Me.rbnMori.UseVisualStyleBackColor = True
        '
        'rbnHosi
        '
        Me.rbnHosi.AutoSize = True
        Me.rbnHosi.Location = New System.Drawing.Point(153, 190)
        Me.rbnHosi.Name = "rbnHosi"
        Me.rbnHosi.Size = New System.Drawing.Size(35, 16)
        Me.rbnHosi.TabIndex = 19
        Me.rbnHosi.TabStop = True
        Me.rbnHosi.Text = "星"
        Me.rbnHosi.UseVisualStyleBackColor = True
        '
        'rbnSora
        '
        Me.rbnSora.AutoSize = True
        Me.rbnSora.Location = New System.Drawing.Point(194, 190)
        Me.rbnSora.Name = "rbnSora"
        Me.rbnSora.Size = New System.Drawing.Size(35, 16)
        Me.rbnSora.TabIndex = 20
        Me.rbnSora.TabStop = True
        Me.rbnSora.Text = "空"
        Me.rbnSora.UseVisualStyleBackColor = True
        '
        'rbnHana
        '
        Me.rbnHana.AutoSize = True
        Me.rbnHana.Location = New System.Drawing.Point(236, 190)
        Me.rbnHana.Name = "rbnHana"
        Me.rbnHana.Size = New System.Drawing.Size(35, 16)
        Me.rbnHana.TabIndex = 21
        Me.rbnHana.TabStop = True
        Me.rbnHana.Text = "花"
        Me.rbnHana.UseVisualStyleBackColor = True
        '
        'rbnTuki
        '
        Me.rbnTuki.AutoSize = True
        Me.rbnTuki.Location = New System.Drawing.Point(277, 190)
        Me.rbnTuki.Name = "rbnTuki"
        Me.rbnTuki.Size = New System.Drawing.Size(35, 16)
        Me.rbnTuki.TabIndex = 22
        Me.rbnTuki.TabStop = True
        Me.rbnTuki.Text = "月"
        Me.rbnTuki.UseVisualStyleBackColor = True
        '
        'rbnUmi
        '
        Me.rbnUmi.AutoSize = True
        Me.rbnUmi.Location = New System.Drawing.Point(318, 190)
        Me.rbnUmi.Name = "rbnUmi"
        Me.rbnUmi.Size = New System.Drawing.Size(35, 16)
        Me.rbnUmi.TabIndex = 23
        Me.rbnUmi.TabStop = True
        Me.rbnUmi.Text = "海"
        Me.rbnUmi.UseVisualStyleBackColor = True
        '
        'rbnNiji
        '
        Me.rbnNiji.AutoSize = True
        Me.rbnNiji.Location = New System.Drawing.Point(359, 190)
        Me.rbnNiji.Name = "rbnNiji"
        Me.rbnNiji.Size = New System.Drawing.Size(35, 16)
        Me.rbnNiji.TabIndex = 24
        Me.rbnNiji.TabStop = True
        Me.rbnNiji.Text = "虹"
        Me.rbnNiji.UseVisualStyleBackColor = True
        '
        'rbnHikari
        '
        Me.rbnHikari.AutoSize = True
        Me.rbnHikari.Location = New System.Drawing.Point(400, 190)
        Me.rbnHikari.Name = "rbnHikari"
        Me.rbnHikari.Size = New System.Drawing.Size(35, 16)
        Me.rbnHikari.TabIndex = 25
        Me.rbnHikari.TabStop = True
        Me.rbnHikari.Text = "光"
        Me.rbnHikari.UseVisualStyleBackColor = True
        '
        'rbnOka
        '
        Me.rbnOka.AutoSize = True
        Me.rbnOka.Location = New System.Drawing.Point(441, 190)
        Me.rbnOka.Name = "rbnOka"
        Me.rbnOka.Size = New System.Drawing.Size(35, 16)
        Me.rbnOka.TabIndex = 26
        Me.rbnOka.TabStop = True
        Me.rbnOka.Text = "丘"
        Me.rbnOka.UseVisualStyleBackColor = True
        '
        'rbnKaze
        '
        Me.rbnKaze.AutoSize = True
        Me.rbnKaze.Location = New System.Drawing.Point(482, 190)
        Me.rbnKaze.Name = "rbnKaze"
        Me.rbnKaze.Size = New System.Drawing.Size(35, 16)
        Me.rbnKaze.TabIndex = 27
        Me.rbnKaze.TabStop = True
        Me.rbnKaze.Text = "風"
        Me.rbnKaze.UseVisualStyleBackColor = True
        '
        'rbnYuki
        '
        Me.rbnYuki.AutoSize = True
        Me.rbnYuki.Location = New System.Drawing.Point(523, 190)
        Me.rbnYuki.Name = "rbnYuki"
        Me.rbnYuki.Size = New System.Drawing.Size(35, 16)
        Me.rbnYuki.TabIndex = 28
        Me.rbnYuki.TabStop = True
        Me.rbnYuki.Text = "雪"
        Me.rbnYuki.UseVisualStyleBackColor = True
        '
        'txtHyo
        '
        Me.txtHyo.Location = New System.Drawing.Point(112, 216)
        Me.txtHyo.Name = "txtHyo"
        Me.txtHyo.Size = New System.Drawing.Size(21, 19)
        Me.txtHyo.TabIndex = 29
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(466, 221)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 28)
        Me.btnAdd.TabIndex = 30
        Me.btnAdd.Text = "登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(549, 221)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 28)
        Me.btnDelete.TabIndex = 31
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        '入居者
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 541)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtHyo)
        Me.Controls.Add(Me.rbnYuki)
        Me.Controls.Add(Me.rbnKaze)
        Me.Controls.Add(Me.rbnOka)
        Me.Controls.Add(Me.rbnHikari)
        Me.Controls.Add(Me.rbnNiji)
        Me.Controls.Add(Me.rbnUmi)
        Me.Controls.Add(Me.rbnTuki)
        Me.Controls.Add(Me.rbnHana)
        Me.Controls.Add(Me.rbnSora)
        Me.Controls.Add(Me.rbnHosi)
        Me.Controls.Add(Me.rbnMori)
        Me.Controls.Add(Me.ymdboxYmd)
        Me.Controls.Add(Me.txtJyu)
        Me.Controls.Add(Me.ymdboxBirth)
        Me.Controls.Add(Me.txtSex)
        Me.Controls.Add(Me.txtKana)
        Me.Controls.Add(Me.txtNam)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "入居者"
        Me.Text = "利用者マスタ"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtNam As System.Windows.Forms.TextBox
    Friend WithEvents txtKana As System.Windows.Forms.TextBox
    Friend WithEvents txtSex As System.Windows.Forms.TextBox
    Friend WithEvents ymdboxBirth As ymdBox.ymdBox
    Friend WithEvents txtJyu As System.Windows.Forms.TextBox
    Friend WithEvents ymdboxYmd As ymdBox.ymdBox
    Friend WithEvents rbnMori As System.Windows.Forms.RadioButton
    Friend WithEvents rbnHosi As System.Windows.Forms.RadioButton
    Friend WithEvents rbnSora As System.Windows.Forms.RadioButton
    Friend WithEvents rbnHana As System.Windows.Forms.RadioButton
    Friend WithEvents rbnTuki As System.Windows.Forms.RadioButton
    Friend WithEvents rbnUmi As System.Windows.Forms.RadioButton
    Friend WithEvents rbnNiji As System.Windows.Forms.RadioButton
    Friend WithEvents rbnHikari As System.Windows.Forms.RadioButton
    Friend WithEvents rbnOka As System.Windows.Forms.RadioButton
    Friend WithEvents rbnKaze As System.Windows.Forms.RadioButton
    Friend WithEvents rbnYuki As System.Windows.Forms.RadioButton
    Friend WithEvents txtHyo As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
