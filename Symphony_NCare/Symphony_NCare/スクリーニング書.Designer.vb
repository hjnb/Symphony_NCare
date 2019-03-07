<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class スクリーニング書
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
        Me.components = New System.ComponentModel.Container()
        Me.namArea = New System.Windows.Forms.GroupBox()
        Me.clearComboBox = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.historyListBox = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvWeight = New System.Windows.Forms.DataGridView()
        Me.heightMLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tantoComboBox = New System.Windows.Forms.ComboBox()
        Me.createYmdBox = New ymdBox.ymdBox()
        Me.kaiComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvTokki = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.unitLabel = New System.Windows.Forms.Label()
        Me.kanaLabel = New System.Windows.Forms.Label()
        Me.namLabel = New System.Windows.Forms.Label()
        Me.sexLabel = New System.Windows.Forms.Label()
        Me.birthLabel = New System.Windows.Forms.Label()
        Me.ageLabel = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.heigthLabel = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.JYmdBox = New ymdBox.ymdBox()
        Me.weightLabel = New System.Windows.Forms.Label()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.btnPrintRight = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnCall = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClearRight = New System.Windows.Forms.Button()
        Me.insertNumComboBox = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.bmiLabel = New System.Windows.Forms.Label()
        Me.bmiKanjiLabel = New System.Windows.Forms.Label()
        Me.keikotutyoLabel = New System.Windows.Forms.Label()
        Me.hizatakaLabel = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.idealWeightLabel = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.kcalLabel = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.ScreeningDataGridView = New Symphony_NCare.screeningDataGridView(Me.components)
        Me.namArea.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTokki, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ScreeningDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'namArea
        '
        Me.namArea.Controls.Add(Me.clearComboBox)
        Me.namArea.Controls.Add(Me.btnPrint)
        Me.namArea.Controls.Add(Me.btnDelete)
        Me.namArea.Controls.Add(Me.btnClear)
        Me.namArea.Controls.Add(Me.btnRegist)
        Me.namArea.Controls.Add(Me.historyListBox)
        Me.namArea.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namArea.ForeColor = System.Drawing.Color.Blue
        Me.namArea.Location = New System.Drawing.Point(12, 38)
        Me.namArea.Name = "namArea"
        Me.namArea.Size = New System.Drawing.Size(141, 259)
        Me.namArea.TabIndex = 1
        Me.namArea.TabStop = False
        Me.namArea.Text = "浅井　幸子"
        '
        'clearComboBox
        '
        Me.clearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.clearComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearComboBox.FormattingEnabled = True
        Me.clearComboBox.Location = New System.Drawing.Point(90, 155)
        Me.clearComboBox.Name = "clearComboBox"
        Me.clearComboBox.Size = New System.Drawing.Size(36, 21)
        Me.clearComboBox.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Location = New System.Drawing.Point(17, 214)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(68, 31)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.Location = New System.Drawing.Point(17, 182)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(68, 31)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(17, 150)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 31)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRegist
        '
        Me.btnRegist.ForeColor = System.Drawing.Color.Black
        Me.btnRegist.Location = New System.Drawing.Point(17, 118)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(68, 31)
        Me.btnRegist.TabIndex = 1
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'historyListBox
        '
        Me.historyListBox.BackColor = System.Drawing.SystemColors.Control
        Me.historyListBox.FormattingEnabled = True
        Me.historyListBox.Location = New System.Drawing.Point(17, 27)
        Me.historyListBox.Name = "historyListBox"
        Me.historyListBox.Size = New System.Drawing.Size(97, 82)
        Me.historyListBox.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.heightMLabel)
        Me.GroupBox1.Controls.Add(Me.dgvWeight)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 310)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(141, 166)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "W/Hﾏｽﾀ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "身長"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(97, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "cm"
        '
        'dgvWeight
        '
        Me.dgvWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWeight.Location = New System.Drawing.Point(25, 46)
        Me.dgvWeight.Name = "dgvWeight"
        Me.dgvWeight.RowTemplate.Height = 21
        Me.dgvWeight.Size = New System.Drawing.Size(94, 104)
        Me.dgvWeight.TabIndex = 3
        '
        'heightMLabel
        '
        Me.heightMLabel.AutoSize = True
        Me.heightMLabel.Location = New System.Drawing.Point(62, 24)
        Me.heightMLabel.Name = "heightMLabel"
        Me.heightMLabel.Size = New System.Drawing.Size(23, 12)
        Me.heightMLabel.TabIndex = 3
        Me.heightMLabel.Text = "140"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(176, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "記入者氏名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "作成年月日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(176, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "介護度"
        '
        'tantoComboBox
        '
        Me.tantoComboBox.FormattingEnabled = True
        Me.tantoComboBox.Location = New System.Drawing.Point(247, 19)
        Me.tantoComboBox.Name = "tantoComboBox"
        Me.tantoComboBox.Size = New System.Drawing.Size(105, 20)
        Me.tantoComboBox.TabIndex = 6
        '
        'createYmdBox
        '
        Me.createYmdBox.boxType = 2
        Me.createYmdBox.DateText = ""
        Me.createYmdBox.EraLabelText = "H31"
        Me.createYmdBox.EraText = ""
        Me.createYmdBox.Location = New System.Drawing.Point(247, 45)
        Me.createYmdBox.MonthLabelText = "03"
        Me.createYmdBox.MonthText = ""
        Me.createYmdBox.Name = "createYmdBox"
        Me.createYmdBox.Size = New System.Drawing.Size(110, 34)
        Me.createYmdBox.TabIndex = 7
        '
        'kaiComboBox
        '
        Me.kaiComboBox.FormattingEnabled = True
        Me.kaiComboBox.Location = New System.Drawing.Point(247, 85)
        Me.kaiComboBox.Name = "kaiComboBox"
        Me.kaiComboBox.Size = New System.Drawing.Size(59, 20)
        Me.kaiComboBox.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(375, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "特記事項"
        '
        'dgvTokki
        '
        Me.dgvTokki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTokki.Location = New System.Drawing.Point(377, 35)
        Me.dgvTokki.Name = "dgvTokki"
        Me.dgvTokki.RowTemplate.Height = 21
        Me.dgvTokki.Size = New System.Drawing.Size(373, 50)
        Me.dgvTokki.TabIndex = 10
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(860, 585)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(391, 80)
        Me.DataGridView1.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(858, 568)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "体重推移"
        '
        'unitLabel
        '
        Me.unitLabel.AutoSize = True
        Me.unitLabel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.unitLabel.Location = New System.Drawing.Point(858, 19)
        Me.unitLabel.Name = "unitLabel"
        Me.unitLabel.Size = New System.Drawing.Size(41, 12)
        Me.unitLabel.TabIndex = 14
        Me.unitLabel.Text = "空の家"
        '
        'kanaLabel
        '
        Me.kanaLabel.AutoSize = True
        Me.kanaLabel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kanaLabel.Location = New System.Drawing.Point(864, 59)
        Me.kanaLabel.Name = "kanaLabel"
        Me.kanaLabel.Size = New System.Drawing.Size(67, 11)
        Me.kanaLabel.TabIndex = 15
        Me.kanaLabel.Text = "あさい　さちこ"
        '
        'namLabel
        '
        Me.namLabel.AutoSize = True
        Me.namLabel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namLabel.ForeColor = System.Drawing.Color.Blue
        Me.namLabel.Location = New System.Drawing.Point(864, 42)
        Me.namLabel.Name = "namLabel"
        Me.namLabel.Size = New System.Drawing.Size(61, 12)
        Me.namLabel.TabIndex = 16
        Me.namLabel.Text = "浅井　幸子"
        '
        'sexLabel
        '
        Me.sexLabel.AutoSize = True
        Me.sexLabel.Location = New System.Drawing.Point(955, 42)
        Me.sexLabel.Name = "sexLabel"
        Me.sexLabel.Size = New System.Drawing.Size(17, 12)
        Me.sexLabel.TabIndex = 17
        Me.sexLabel.Text = "♀"
        '
        'birthLabel
        '
        Me.birthLabel.AutoSize = True
        Me.birthLabel.Location = New System.Drawing.Point(872, 82)
        Me.birthLabel.Name = "birthLabel"
        Me.birthLabel.Size = New System.Drawing.Size(60, 12)
        Me.birthLabel.TabIndex = 18
        Me.birthLabel.Text = "S15/09/27"
        '
        'ageLabel
        '
        Me.ageLabel.AutoSize = True
        Me.ageLabel.Location = New System.Drawing.Point(955, 82)
        Me.ageLabel.Name = "ageLabel"
        Me.ageLabel.Size = New System.Drawing.Size(17, 12)
        Me.ageLabel.TabIndex = 19
        Me.ageLabel.Text = "--"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(973, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 12)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "歳"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(858, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 12)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "BMI"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(858, 164)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 12)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "膝高"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(858, 192)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "理想体重"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(873, 234)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 12)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "ｴﾈﾙｷﾞｰ量"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(873, 285)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 12)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "たん白質"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(858, 328)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 12)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "現状体重当たり(必要)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(858, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "脛骨長"
        '
        'heigthLabel
        '
        Me.heigthLabel.ForeColor = System.Drawing.Color.Red
        Me.heigthLabel.Location = New System.Drawing.Point(61, 23)
        Me.heigthLabel.Name = "heigthLabel"
        Me.heigthLabel.Size = New System.Drawing.Size(52, 12)
        Me.heigthLabel.TabIndex = 28
        Me.heigthLabel.Text = "0"
        Me.heigthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(116, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(20, 12)
        Me.Label23.TabIndex = 29
        Me.Label23.Text = "cm"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.weightLabel)
        Me.GroupBox2.Controls.Add(Me.JYmdBox)
        Me.GroupBox2.Controls.Add(Me.heigthLabel)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(1002, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(165, 96)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "基準値"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "身長"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "体重"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "実施"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(116, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "kg"
        '
        'JYmdBox
        '
        Me.JYmdBox.boxType = 2
        Me.JYmdBox.DateText = ""
        Me.JYmdBox.EraLabelText = "H31"
        Me.JYmdBox.EraText = ""
        Me.JYmdBox.Location = New System.Drawing.Point(49, 56)
        Me.JYmdBox.MonthLabelText = "03"
        Me.JYmdBox.MonthText = ""
        Me.JYmdBox.Name = "JYmdBox"
        Me.JYmdBox.Size = New System.Drawing.Size(110, 34)
        Me.JYmdBox.TabIndex = 31
        '
        'weightLabel
        '
        Me.weightLabel.ForeColor = System.Drawing.Color.Red
        Me.weightLabel.Location = New System.Drawing.Point(61, 44)
        Me.weightLabel.Name = "weightLabel"
        Me.weightLabel.Size = New System.Drawing.Size(52, 12)
        Me.weightLabel.TabIndex = 34
        Me.weightLabel.Text = "0"
        Me.weightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(1183, 18)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(52, 27)
        Me.btnCalc.TabIndex = 31
        Me.btnCalc.Text = "算出"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'btnPrintRight
        '
        Me.btnPrintRight.Location = New System.Drawing.Point(1239, 18)
        Me.btnPrintRight.Name = "btnPrintRight"
        Me.btnPrintRight.Size = New System.Drawing.Size(52, 27)
        Me.btnPrintRight.TabIndex = 32
        Me.btnPrintRight.Text = "印刷"
        Me.btnPrintRight.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(1239, 47)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(52, 27)
        Me.btnInsert.TabIndex = 33
        Me.btnInsert.Text = "挿入"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnCall
        '
        Me.btnCall.Location = New System.Drawing.Point(1239, 76)
        Me.btnCall.Name = "btnCall"
        Me.btnCall.Size = New System.Drawing.Size(52, 27)
        Me.btnCall.TabIndex = 34
        Me.btnCall.Text = "呼出"
        Me.btnCall.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1183, 76)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 27)
        Me.btnSave.TabIndex = 35
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClearRight
        '
        Me.btnClearRight.Location = New System.Drawing.Point(1239, 106)
        Me.btnClearRight.Name = "btnClearRight"
        Me.btnClearRight.Size = New System.Drawing.Size(52, 27)
        Me.btnClearRight.TabIndex = 36
        Me.btnClearRight.Text = "クリア"
        Me.btnClearRight.UseVisualStyleBackColor = True
        '
        'insertNumComboBox
        '
        Me.insertNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.insertNumComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.insertNumComboBox.FormattingEnabled = True
        Me.insertNumComboBox.Location = New System.Drawing.Point(1297, 51)
        Me.insertNumComboBox.Name = "insertNumComboBox"
        Me.insertNumComboBox.Size = New System.Drawing.Size(35, 20)
        Me.insertNumComboBox.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(858, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 12)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "標準体重当たり(理想)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(872, 399)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 12)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "たん白質"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(872, 348)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 12)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "ｴﾈﾙｷﾞｰ量"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(872, 435)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(29, 12)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "脂質"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(872, 455)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 12)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "糖質"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(872, 475)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 12)
        Me.Label26.TabIndex = 43
        Me.Label26.Text = "食物繊維"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(873, 495)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 12)
        Me.Label27.TabIndex = 44
        Me.Label27.Text = "水分"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(858, 521)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 12)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "血清Alb"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(858, 542)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 12)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "食事摂取量"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(946, 116)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(35, 12)
        Me.Label30.TabIndex = 47
        Me.Label30.Text = "kg/㎡"
        '
        'bmiLabel
        '
        Me.bmiLabel.ForeColor = System.Drawing.Color.Red
        Me.bmiLabel.Location = New System.Drawing.Point(901, 116)
        Me.bmiLabel.Name = "bmiLabel"
        Me.bmiLabel.Size = New System.Drawing.Size(42, 12)
        Me.bmiLabel.TabIndex = 48
        Me.bmiLabel.Text = "0"
        Me.bmiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bmiKanjiLabel
        '
        Me.bmiKanjiLabel.AutoSize = True
        Me.bmiKanjiLabel.ForeColor = System.Drawing.Color.Red
        Me.bmiKanjiLabel.Location = New System.Drawing.Point(981, 116)
        Me.bmiKanjiLabel.Name = "bmiKanjiLabel"
        Me.bmiKanjiLabel.Size = New System.Drawing.Size(17, 12)
        Me.bmiKanjiLabel.TabIndex = 49
        Me.bmiKanjiLabel.Text = "低"
        '
        'keikotutyoLabel
        '
        Me.keikotutyoLabel.ForeColor = System.Drawing.Color.Red
        Me.keikotutyoLabel.Location = New System.Drawing.Point(901, 144)
        Me.keikotutyoLabel.Name = "keikotutyoLabel"
        Me.keikotutyoLabel.Size = New System.Drawing.Size(42, 12)
        Me.keikotutyoLabel.TabIndex = 50
        Me.keikotutyoLabel.Text = "0"
        Me.keikotutyoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'hizatakaLabel
        '
        Me.hizatakaLabel.ForeColor = System.Drawing.Color.Red
        Me.hizatakaLabel.Location = New System.Drawing.Point(901, 165)
        Me.hizatakaLabel.Name = "hizatakaLabel"
        Me.hizatakaLabel.Size = New System.Drawing.Size(42, 12)
        Me.hizatakaLabel.TabIndex = 51
        Me.hizatakaLabel.Text = "0"
        Me.hizatakaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(946, 144)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(20, 12)
        Me.Label31.TabIndex = 52
        Me.Label31.Text = "cm"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(946, 164)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(20, 12)
        Me.Label32.TabIndex = 53
        Me.Label32.Text = "cm"
        '
        'idealWeightLabel
        '
        Me.idealWeightLabel.ForeColor = System.Drawing.Color.Red
        Me.idealWeightLabel.Location = New System.Drawing.Point(912, 192)
        Me.idealWeightLabel.Name = "idealWeightLabel"
        Me.idealWeightLabel.Size = New System.Drawing.Size(41, 12)
        Me.idealWeightLabel.TabIndex = 54
        Me.idealWeightLabel.Text = "0"
        Me.idealWeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(955, 192)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(17, 12)
        Me.Label34.TabIndex = 55
        Me.Label34.Text = "kg"
        '
        'kcalLabel
        '
        Me.kcalLabel.ForeColor = System.Drawing.Color.Red
        Me.kcalLabel.Location = New System.Drawing.Point(934, 234)
        Me.kcalLabel.Name = "kcalLabel"
        Me.kcalLabel.Size = New System.Drawing.Size(37, 12)
        Me.kcalLabel.TabIndex = 56
        Me.kcalLabel.Text = "0"
        Me.kcalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(972, 234)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(27, 12)
        Me.Label35.TabIndex = 57
        Me.Label35.Text = "Kcal"
        '
        'ScreeningDataGridView
        '
        Me.ScreeningDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ScreeningDataGridView.Location = New System.Drawing.Point(178, 113)
        Me.ScreeningDataGridView.Name = "ScreeningDataGridView"
        Me.ScreeningDataGridView.RowTemplate.Height = 21
        Me.ScreeningDataGridView.Size = New System.Drawing.Size(658, 377)
        Me.ScreeningDataGridView.TabIndex = 11
        '
        'スクリーニング書
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1645, 684)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.kcalLabel)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.idealWeightLabel)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.hizatakaLabel)
        Me.Controls.Add(Me.keikotutyoLabel)
        Me.Controls.Add(Me.bmiKanjiLabel)
        Me.Controls.Add(Me.bmiLabel)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.insertNumComboBox)
        Me.Controls.Add(Me.btnClearRight)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCall)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.btnPrintRight)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ageLabel)
        Me.Controls.Add(Me.birthLabel)
        Me.Controls.Add(Me.sexLabel)
        Me.Controls.Add(Me.namLabel)
        Me.Controls.Add(Me.kanaLabel)
        Me.Controls.Add(Me.unitLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ScreeningDataGridView)
        Me.Controls.Add(Me.dgvTokki)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.kaiComboBox)
        Me.Controls.Add(Me.createYmdBox)
        Me.Controls.Add(Me.tantoComboBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.namArea)
        Me.Name = "スクリーニング書"
        Me.Text = "スクリーニング書"
        Me.namArea.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTokki, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ScreeningDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents namArea As System.Windows.Forms.GroupBox
    Friend WithEvents clearComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents historyListBox As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvWeight As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents heightMLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tantoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents createYmdBox As ymdBox.ymdBox
    Friend WithEvents kaiComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvTokki As System.Windows.Forms.DataGridView
    Friend WithEvents ScreeningDataGridView As Symphony_NCare.screeningDataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents unitLabel As System.Windows.Forms.Label
    Friend WithEvents kanaLabel As System.Windows.Forms.Label
    Friend WithEvents namLabel As System.Windows.Forms.Label
    Friend WithEvents sexLabel As System.Windows.Forms.Label
    Friend WithEvents birthLabel As System.Windows.Forms.Label
    Friend WithEvents ageLabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents heigthLabel As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents JYmdBox As ymdBox.ymdBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents weightLabel As System.Windows.Forms.Label
    Friend WithEvents btnCalc As System.Windows.Forms.Button
    Friend WithEvents btnPrintRight As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnCall As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClearRight As System.Windows.Forms.Button
    Friend WithEvents insertNumComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents bmiLabel As System.Windows.Forms.Label
    Friend WithEvents bmiKanjiLabel As System.Windows.Forms.Label
    Friend WithEvents keikotutyoLabel As System.Windows.Forms.Label
    Friend WithEvents hizatakaLabel As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents idealWeightLabel As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents kcalLabel As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
End Class
