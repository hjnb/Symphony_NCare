<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 計画書
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.YmdBox1 = New ymdBox.ymdBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.txtKei = New System.Windows.Forms.TextBox()
        Me.txtNin = New System.Windows.Forms.TextBox()
        Me.cmbAuthor = New System.Windows.Forms.ComboBox()
        Me.ymdboxNyuymd = New ymdBox.ymdBox()
        Me.ymdboxFstymd = New ymdBox.ymdBox()
        Me.txtTanto = New System.Windows.Forms.TextBox()
        Me.txtKai = New System.Windows.Forms.TextBox()
        Me.txtKaitxt = New System.Windows.Forms.TextBox()
        Me.txtIko1 = New System.Windows.Forms.TextBox()
        Me.txtIko2 = New System.Windows.Forms.TextBox()
        Me.txtRisk = New System.Windows.Forms.TextBox()
        Me.txtKad1 = New System.Windows.Forms.TextBox()
        Me.txtKad2 = New System.Windows.Forms.TextBox()
        Me.txtKad3 = New System.Windows.Forms.TextBox()
        Me.txtTyo1 = New System.Windows.Forms.TextBox()
        Me.txtTyo2 = New System.Windows.Forms.TextBox()
        Me.TextBox98 = New System.Windows.Forms.TextBox()
        Me.TextBox99 = New System.Windows.Forms.TextBox()
        Me.TextBox100 = New System.Windows.Forms.TextBox()
        Me.TextBox101 = New System.Windows.Forms.TextBox()
        Me.TextBox102 = New System.Windows.Forms.TextBox()
        Me.txtTok1 = New System.Windows.Forms.TextBox()
        Me.txtTok2 = New System.Windows.Forms.TextBox()
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New Symphony_NCare.計画書Class()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblName.Location = New System.Drawing.Point(35, 28)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(37, 15)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "氏名"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Location = New System.Drawing.Point(50, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(90, 80)
        Me.DataGridView1.TabIndex = 1
        '
        'YmdBox1
        '
        Me.YmdBox1.boxType = 2
        Me.YmdBox1.DateText = ""
        Me.YmdBox1.EraLabelText = "H31"
        Me.YmdBox1.EraText = ""
        Me.YmdBox1.Location = New System.Drawing.Point(39, 143)
        Me.YmdBox1.MonthLabelText = "04"
        Me.YmdBox1.MonthText = ""
        Me.YmdBox1.Name = "YmdBox1"
        Me.YmdBox1.Size = New System.Drawing.Size(110, 34)
        Me.YmdBox1.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(62, 183)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(66, 32)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(62, 219)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(66, 32)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(62, 255)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 32)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(62, 291)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(66, 32)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'txtKei
        '
        Me.txtKei.Location = New System.Drawing.Point(273, 21)
        Me.txtKei.Name = "txtKei"
        Me.txtKei.Size = New System.Drawing.Size(19, 19)
        Me.txtKei.TabIndex = 8
        '
        'txtNin
        '
        Me.txtNin.Location = New System.Drawing.Point(458, 21)
        Me.txtNin.Name = "txtNin"
        Me.txtNin.Size = New System.Drawing.Size(19, 19)
        Me.txtNin.TabIndex = 9
        '
        'cmbAuthor
        '
        Me.cmbAuthor.FormattingEnabled = True
        Me.cmbAuthor.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.cmbAuthor.Items.AddRange(New Object() {"澤田　美佳"})
        Me.cmbAuthor.Location = New System.Drawing.Point(273, 55)
        Me.cmbAuthor.Name = "cmbAuthor"
        Me.cmbAuthor.Size = New System.Drawing.Size(157, 20)
        Me.cmbAuthor.TabIndex = 10
        '
        'ymdboxNyuymd
        '
        Me.ymdboxNyuymd.boxType = 0
        Me.ymdboxNyuymd.DateText = ""
        Me.ymdboxNyuymd.EraLabelText = "H31"
        Me.ymdboxNyuymd.EraText = ""
        Me.ymdboxNyuymd.Location = New System.Drawing.Point(273, 81)
        Me.ymdboxNyuymd.MonthLabelText = "04"
        Me.ymdboxNyuymd.MonthText = ""
        Me.ymdboxNyuymd.Name = "ymdboxNyuymd"
        Me.ymdboxNyuymd.Size = New System.Drawing.Size(86, 20)
        Me.ymdboxNyuymd.TabIndex = 11
        '
        'ymdboxFstymd
        '
        Me.ymdboxFstymd.boxType = 0
        Me.ymdboxFstymd.DateText = ""
        Me.ymdboxFstymd.EraLabelText = "H31"
        Me.ymdboxFstymd.EraText = ""
        Me.ymdboxFstymd.Location = New System.Drawing.Point(273, 108)
        Me.ymdboxFstymd.MonthLabelText = "04"
        Me.ymdboxFstymd.MonthText = ""
        Me.ymdboxFstymd.Name = "ymdboxFstymd"
        Me.ymdboxFstymd.Size = New System.Drawing.Size(86, 20)
        Me.ymdboxFstymd.TabIndex = 12
        '
        'txtTanto
        '
        Me.txtTanto.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTanto.Location = New System.Drawing.Point(273, 134)
        Me.txtTanto.Name = "txtTanto"
        Me.txtTanto.Size = New System.Drawing.Size(130, 19)
        Me.txtTanto.TabIndex = 13
        '
        'txtKai
        '
        Me.txtKai.Location = New System.Drawing.Point(273, 159)
        Me.txtKai.Name = "txtKai"
        Me.txtKai.Size = New System.Drawing.Size(19, 19)
        Me.txtKai.TabIndex = 14
        '
        'txtKaitxt
        '
        Me.txtKaitxt.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKaitxt.Location = New System.Drawing.Point(353, 160)
        Me.txtKaitxt.Name = "txtKaitxt"
        Me.txtKaitxt.Size = New System.Drawing.Size(268, 19)
        Me.txtKaitxt.TabIndex = 15
        '
        'txtIko1
        '
        Me.txtIko1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtIko1.Location = New System.Drawing.Point(204, 212)
        Me.txtIko1.Name = "txtIko1"
        Me.txtIko1.Size = New System.Drawing.Size(775, 19)
        Me.txtIko1.TabIndex = 16
        '
        'txtIko2
        '
        Me.txtIko2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtIko2.Location = New System.Drawing.Point(204, 230)
        Me.txtIko2.Name = "txtIko2"
        Me.txtIko2.Size = New System.Drawing.Size(775, 19)
        Me.txtIko2.TabIndex = 17
        '
        'txtRisk
        '
        Me.txtRisk.Location = New System.Drawing.Point(315, 283)
        Me.txtRisk.Name = "txtRisk"
        Me.txtRisk.Size = New System.Drawing.Size(19, 19)
        Me.txtRisk.TabIndex = 18
        '
        'txtKad1
        '
        Me.txtKad1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKad1.Location = New System.Drawing.Point(204, 305)
        Me.txtKad1.Name = "txtKad1"
        Me.txtKad1.Size = New System.Drawing.Size(775, 19)
        Me.txtKad1.TabIndex = 19
        '
        'txtKad2
        '
        Me.txtKad2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKad2.Location = New System.Drawing.Point(204, 323)
        Me.txtKad2.Name = "txtKad2"
        Me.txtKad2.Size = New System.Drawing.Size(775, 19)
        Me.txtKad2.TabIndex = 20
        '
        'txtKad3
        '
        Me.txtKad3.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKad3.Location = New System.Drawing.Point(204, 341)
        Me.txtKad3.Name = "txtKad3"
        Me.txtKad3.Size = New System.Drawing.Size(775, 19)
        Me.txtKad3.TabIndex = 21
        '
        'txtTyo1
        '
        Me.txtTyo1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTyo1.Location = New System.Drawing.Point(204, 394)
        Me.txtTyo1.Name = "txtTyo1"
        Me.txtTyo1.Size = New System.Drawing.Size(775, 19)
        Me.txtTyo1.TabIndex = 22
        '
        'txtTyo2
        '
        Me.txtTyo2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTyo2.Location = New System.Drawing.Point(204, 412)
        Me.txtTyo2.Name = "txtTyo2"
        Me.txtTyo2.Size = New System.Drawing.Size(775, 19)
        Me.txtTyo2.TabIndex = 23
        '
        'TextBox98
        '
        Me.TextBox98.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox98.Location = New System.Drawing.Point(24, 446)
        Me.TextBox98.Name = "TextBox98"
        Me.TextBox98.ReadOnly = True
        Me.TextBox98.Size = New System.Drawing.Size(243, 19)
        Me.TextBox98.TabIndex = 25
        Me.TextBox98.Text = "短期目標と期間"
        Me.TextBox98.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox99
        '
        Me.TextBox99.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox99.Location = New System.Drawing.Point(266, 446)
        Me.TextBox99.Name = "TextBox99"
        Me.TextBox99.ReadOnly = True
        Me.TextBox99.Size = New System.Drawing.Size(522, 19)
        Me.TextBox99.TabIndex = 26
        Me.TextBox99.Text = "栄養ケア（栄養補助、食事の個別化、栄養食事指導、多職種による栄養ケアなど）"
        Me.TextBox99.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox100
        '
        Me.TextBox100.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox100.Location = New System.Drawing.Point(787, 446)
        Me.TextBox100.Name = "TextBox100"
        Me.TextBox100.ReadOnly = True
        Me.TextBox100.Size = New System.Drawing.Size(69, 19)
        Me.TextBox100.TabIndex = 27
        Me.TextBox100.Text = "担当者"
        Me.TextBox100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox101
        '
        Me.TextBox101.Location = New System.Drawing.Point(855, 446)
        Me.TextBox101.Name = "TextBox101"
        Me.TextBox101.ReadOnly = True
        Me.TextBox101.Size = New System.Drawing.Size(65, 19)
        Me.TextBox101.TabIndex = 28
        Me.TextBox101.Text = "頻度"
        Me.TextBox101.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox102
        '
        Me.TextBox102.Location = New System.Drawing.Point(919, 446)
        Me.TextBox102.Name = "TextBox102"
        Me.TextBox102.ReadOnly = True
        Me.TextBox102.Size = New System.Drawing.Size(65, 19)
        Me.TextBox102.TabIndex = 29
        Me.TextBox102.Text = "期間"
        Me.TextBox102.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTok1
        '
        Me.txtTok1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTok1.Location = New System.Drawing.Point(24, 608)
        Me.txtTok1.Name = "txtTok1"
        Me.txtTok1.Size = New System.Drawing.Size(903, 19)
        Me.txtTok1.TabIndex = 30
        '
        'txtTok2
        '
        Me.txtTok2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTok2.Location = New System.Drawing.Point(24, 626)
        Me.txtTok2.Name = "txtTok2"
        Me.txtTok2.Size = New System.Drawing.Size(903, 19)
        Me.txtTok2.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(297, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "（１：初回　２：紹介　３：継続）"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(480, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "（１：認定済　２：申請中）"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "作成者"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(202, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "入所（院）日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "初回作成日"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(202, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "担当者"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(202, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "要介護度"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(311, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 12)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "その他"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(202, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 12)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "利用者及び家族の意向"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(202, 267)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 12)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "解決すべき課題（ニーズ）"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(246, 287)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 12)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "栄養のリスク"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(340, 287)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 12)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "（１：低　２：中　３：高）"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(202, 378)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 12)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "長期目標（ゴール）と期間"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(28, 590)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "特記事項"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(23, 336)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(145, 1)
        Me.Label21.TabIndex = 47
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(23, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 1)
        Me.Label20.TabIndex = 48
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(140, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(28, 1)
        Me.Label22.TabIndex = 49
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(23, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(1, 300)
        Me.Label23.TabIndex = 50
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(167, 36)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(1, 300)
        Me.Label24.TabIndex = 51
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.Location = New System.Drawing.Point(24, 464)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 21
        Me.DataGridView2.Size = New System.Drawing.Size(978, 111)
        Me.DataGridView2.TabIndex = 94
        '
        '計画書
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1520, 994)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
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
        Me.Controls.Add(Me.txtTok2)
        Me.Controls.Add(Me.txtTok1)
        Me.Controls.Add(Me.TextBox102)
        Me.Controls.Add(Me.TextBox101)
        Me.Controls.Add(Me.TextBox100)
        Me.Controls.Add(Me.TextBox99)
        Me.Controls.Add(Me.TextBox98)
        Me.Controls.Add(Me.txtTyo2)
        Me.Controls.Add(Me.txtTyo1)
        Me.Controls.Add(Me.txtKad3)
        Me.Controls.Add(Me.txtKad2)
        Me.Controls.Add(Me.txtKad1)
        Me.Controls.Add(Me.txtRisk)
        Me.Controls.Add(Me.txtIko2)
        Me.Controls.Add(Me.txtIko1)
        Me.Controls.Add(Me.txtKai)
        Me.Controls.Add(Me.txtTanto)
        Me.Controls.Add(Me.ymdboxFstymd)
        Me.Controls.Add(Me.ymdboxNyuymd)
        Me.Controls.Add(Me.cmbAuthor)
        Me.Controls.Add(Me.txtNin)
        Me.Controls.Add(Me.txtKei)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.YmdBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtKaitxt)
        Me.Name = "計画書"
        Me.Text = "計画書"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents YmdBox1 As ymdBox.ymdBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents txtKei As System.Windows.Forms.TextBox
    Friend WithEvents txtNin As System.Windows.Forms.TextBox
    Friend WithEvents cmbAuthor As System.Windows.Forms.ComboBox
    Friend WithEvents ymdboxNyuymd As ymdBox.ymdBox
    Friend WithEvents ymdboxFstymd As ymdBox.ymdBox
    Friend WithEvents txtTanto As System.Windows.Forms.TextBox
    Friend WithEvents txtKai As System.Windows.Forms.TextBox
    Friend WithEvents txtKaitxt As System.Windows.Forms.TextBox
    Friend WithEvents txtIko1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIko2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRisk As System.Windows.Forms.TextBox
    Friend WithEvents txtKad1 As System.Windows.Forms.TextBox
    Friend WithEvents txtKad2 As System.Windows.Forms.TextBox
    Friend WithEvents txtKad3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTyo1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTyo2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox98 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox99 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox100 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox101 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox102 As System.Windows.Forms.TextBox
    Friend WithEvents txtTok1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTok2 As System.Windows.Forms.TextBox
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As Symphony_NCare.計画書Class
End Class
