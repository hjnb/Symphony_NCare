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
        Me.heightMLabel = New System.Windows.Forms.Label()
        Me.dgvWeight = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tantoComboBox = New System.Windows.Forms.ComboBox()
        Me.createYmdBox = New ymdBox.ymdBox()
        Me.kaiComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvTokki = New System.Windows.Forms.DataGridView()
        Me.dgvWeightChange = New System.Windows.Forms.DataGridView()
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
        Me.heightLabel = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.baseValueGroupBox = New System.Windows.Forms.GroupBox()
        Me.weightLabel = New System.Windows.Forms.Label()
        Me.JYmdBox = New ymdBox.ymdBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.idealKcalLabel = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.idealProtein1Label = New System.Windows.Forms.Label()
        Me.idealProtein2Label = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.necessaryKcalLabel = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.necessaryProtein2Label = New System.Windows.Forms.Label()
        Me.necessaryProtein1Label = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.tosituLabel = New System.Windows.Forms.Label()
        Me.sisituLabel = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.waterLabel = New System.Windows.Forms.Label()
        Me.seniLabel = New System.Windows.Forms.Label()
        Me.keikotuTextBox = New System.Windows.Forms.TextBox()
        Me.hizatakaTextBox = New System.Windows.Forms.TextBox()
        Me.goalBmiTextBox = New System.Windows.Forms.TextBox()
        Me.katudo1TextBox = New System.Windows.Forms.TextBox()
        Me.stress1TextBox = New System.Windows.Forms.TextBox()
        Me.kaizen1TextBox = New System.Windows.Forms.TextBox()
        Me.katudo2TextBox = New System.Windows.Forms.TextBox()
        Me.stress2TextBox = New System.Windows.Forms.TextBox()
        Me.kaizen2TextBox = New System.Windows.Forms.TextBox()
        Me.albTextBox = New System.Windows.Forms.TextBox()
        Me.nutritionTextBox = New System.Windows.Forms.TextBox()
        Me.intakeTextBox = New System.Windows.Forms.TextBox()
        Me.decubitusTextBox = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.workedOutPercent1TextBox = New System.Windows.Forms.TextBox()
        Me.workedOutPercent2TextBox = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.bee1Label = New System.Windows.Forms.Label()
        Me.bee2Label = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.JPanel = New System.Windows.Forms.Panel()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.J4YmdBox = New ymdBox.ymdBox()
        Me.J3YmdBox = New ymdBox.ymdBox()
        Me.J2YmdBox = New ymdBox.ymdBox()
        Me.J1YmdBox = New ymdBox.ymdBox()
        Me.dgvScreeningUp = New Symphony_NCare.screeningDataGridViewUp(Me.components)
        Me.namArea.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTokki, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWeightChange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.baseValueGroupBox.SuspendLayout()
        Me.JPanel.SuspendLayout()
        CType(Me.dgvScreeningUp, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.historyListBox.Size = New System.Drawing.Size(102, 82)
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
        Me.GroupBox1.Size = New System.Drawing.Size(141, 178)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "W/Hﾏｽﾀ"
        '
        'heightMLabel
        '
        Me.heightMLabel.AutoSize = True
        Me.heightMLabel.Location = New System.Drawing.Point(62, 24)
        Me.heightMLabel.Name = "heightMLabel"
        Me.heightMLabel.Size = New System.Drawing.Size(0, 12)
        Me.heightMLabel.TabIndex = 3
        '
        'dgvWeight
        '
        Me.dgvWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWeight.Location = New System.Drawing.Point(21, 46)
        Me.dgvWeight.Name = "dgvWeight"
        Me.dgvWeight.RowTemplate.Height = 21
        Me.dgvWeight.Size = New System.Drawing.Size(98, 114)
        Me.dgvWeight.TabIndex = 3
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "身長"
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
        Me.kaiComboBox.Size = New System.Drawing.Size(47, 20)
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
        Me.dgvTokki.Size = New System.Drawing.Size(373, 51)
        Me.dgvTokki.TabIndex = 10
        '
        'dgvWeightChange
        '
        Me.dgvWeightChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWeightChange.Location = New System.Drawing.Point(860, 577)
        Me.dgvWeightChange.Name = "dgvWeightChange"
        Me.dgvWeightChange.RowTemplate.Height = 21
        Me.dgvWeightChange.Size = New System.Drawing.Size(419, 80)
        Me.dgvWeightChange.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(858, 560)
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
        'heightLabel
        '
        Me.heightLabel.ForeColor = System.Drawing.Color.Red
        Me.heightLabel.Location = New System.Drawing.Point(61, 23)
        Me.heightLabel.Name = "heightLabel"
        Me.heightLabel.Size = New System.Drawing.Size(52, 12)
        Me.heightLabel.TabIndex = 28
        Me.heightLabel.Text = "0"
        Me.heightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'baseValueGroupBox
        '
        Me.baseValueGroupBox.Controls.Add(Me.weightLabel)
        Me.baseValueGroupBox.Controls.Add(Me.JYmdBox)
        Me.baseValueGroupBox.Controls.Add(Me.heightLabel)
        Me.baseValueGroupBox.Controls.Add(Me.Label11)
        Me.baseValueGroupBox.Controls.Add(Me.Label10)
        Me.baseValueGroupBox.Controls.Add(Me.Label23)
        Me.baseValueGroupBox.Controls.Add(Me.Label9)
        Me.baseValueGroupBox.Controls.Add(Me.Label8)
        Me.baseValueGroupBox.Location = New System.Drawing.Point(1002, 16)
        Me.baseValueGroupBox.Name = "baseValueGroupBox"
        Me.baseValueGroupBox.Size = New System.Drawing.Size(165, 96)
        Me.baseValueGroupBox.TabIndex = 30
        Me.baseValueGroupBox.TabStop = False
        Me.baseValueGroupBox.Text = "基準値"
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(116, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "kg"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "体重"
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
        Me.Label28.Location = New System.Drawing.Point(858, 520)
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
        'idealKcalLabel
        '
        Me.idealKcalLabel.ForeColor = System.Drawing.Color.Red
        Me.idealKcalLabel.Location = New System.Drawing.Point(934, 234)
        Me.idealKcalLabel.Name = "idealKcalLabel"
        Me.idealKcalLabel.Size = New System.Drawing.Size(37, 12)
        Me.idealKcalLabel.TabIndex = 56
        Me.idealKcalLabel.Text = "0"
        Me.idealKcalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'idealProtein1Label
        '
        Me.idealProtein1Label.ForeColor = System.Drawing.Color.Red
        Me.idealProtein1Label.Location = New System.Drawing.Point(934, 285)
        Me.idealProtein1Label.Name = "idealProtein1Label"
        Me.idealProtein1Label.Size = New System.Drawing.Size(37, 12)
        Me.idealProtein1Label.TabIndex = 58
        Me.idealProtein1Label.Text = "0"
        Me.idealProtein1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'idealProtein2Label
        '
        Me.idealProtein2Label.ForeColor = System.Drawing.Color.Red
        Me.idealProtein2Label.Location = New System.Drawing.Point(934, 303)
        Me.idealProtein2Label.Name = "idealProtein2Label"
        Me.idealProtein2Label.Size = New System.Drawing.Size(37, 12)
        Me.idealProtein2Label.TabIndex = 59
        Me.idealProtein2Label.Text = "0"
        Me.idealProtein2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(972, 285)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 12)
        Me.Label33.TabIndex = 60
        Me.Label33.Text = "g"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(972, 303)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 12)
        Me.Label36.TabIndex = 61
        Me.Label36.Text = "g"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(972, 348)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(27, 12)
        Me.Label37.TabIndex = 63
        Me.Label37.Text = "Kcal"
        '
        'necessaryKcalLabel
        '
        Me.necessaryKcalLabel.ForeColor = System.Drawing.Color.Red
        Me.necessaryKcalLabel.Location = New System.Drawing.Point(934, 348)
        Me.necessaryKcalLabel.Name = "necessaryKcalLabel"
        Me.necessaryKcalLabel.Size = New System.Drawing.Size(37, 12)
        Me.necessaryKcalLabel.TabIndex = 62
        Me.necessaryKcalLabel.Text = "0"
        Me.necessaryKcalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(972, 417)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 12)
        Me.Label38.TabIndex = 67
        Me.Label38.Text = "g"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(972, 399)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(11, 12)
        Me.Label39.TabIndex = 66
        Me.Label39.Text = "g"
        '
        'necessaryProtein2Label
        '
        Me.necessaryProtein2Label.ForeColor = System.Drawing.Color.Red
        Me.necessaryProtein2Label.Location = New System.Drawing.Point(934, 417)
        Me.necessaryProtein2Label.Name = "necessaryProtein2Label"
        Me.necessaryProtein2Label.Size = New System.Drawing.Size(37, 12)
        Me.necessaryProtein2Label.TabIndex = 65
        Me.necessaryProtein2Label.Text = "0"
        Me.necessaryProtein2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'necessaryProtein1Label
        '
        Me.necessaryProtein1Label.ForeColor = System.Drawing.Color.Red
        Me.necessaryProtein1Label.Location = New System.Drawing.Point(934, 399)
        Me.necessaryProtein1Label.Name = "necessaryProtein1Label"
        Me.necessaryProtein1Label.Size = New System.Drawing.Size(37, 12)
        Me.necessaryProtein1Label.TabIndex = 64
        Me.necessaryProtein1Label.Text = "0"
        Me.necessaryProtein1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(972, 455)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 12)
        Me.Label40.TabIndex = 71
        Me.Label40.Text = "g"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(972, 436)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(11, 12)
        Me.Label41.TabIndex = 70
        Me.Label41.Text = "g"
        '
        'tosituLabel
        '
        Me.tosituLabel.ForeColor = System.Drawing.Color.Red
        Me.tosituLabel.Location = New System.Drawing.Point(934, 455)
        Me.tosituLabel.Name = "tosituLabel"
        Me.tosituLabel.Size = New System.Drawing.Size(37, 12)
        Me.tosituLabel.TabIndex = 69
        Me.tosituLabel.Text = "0"
        Me.tosituLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sisituLabel
        '
        Me.sisituLabel.ForeColor = System.Drawing.Color.Red
        Me.sisituLabel.Location = New System.Drawing.Point(934, 436)
        Me.sisituLabel.Name = "sisituLabel"
        Me.sisituLabel.Size = New System.Drawing.Size(37, 12)
        Me.sisituLabel.TabIndex = 68
        Me.sisituLabel.Text = "0"
        Me.sisituLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(972, 493)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(17, 12)
        Me.Label44.TabIndex = 75
        Me.Label44.Text = "ml"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(972, 474)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(11, 12)
        Me.Label45.TabIndex = 74
        Me.Label45.Text = "g"
        '
        'waterLabel
        '
        Me.waterLabel.ForeColor = System.Drawing.Color.Red
        Me.waterLabel.Location = New System.Drawing.Point(934, 493)
        Me.waterLabel.Name = "waterLabel"
        Me.waterLabel.Size = New System.Drawing.Size(37, 12)
        Me.waterLabel.TabIndex = 73
        Me.waterLabel.Text = "0"
        Me.waterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'seniLabel
        '
        Me.seniLabel.ForeColor = System.Drawing.Color.Red
        Me.seniLabel.Location = New System.Drawing.Point(934, 474)
        Me.seniLabel.Name = "seniLabel"
        Me.seniLabel.Size = New System.Drawing.Size(37, 12)
        Me.seniLabel.TabIndex = 72
        Me.seniLabel.Text = "0"
        Me.seniLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'keikotuTextBox
        '
        Me.keikotuTextBox.Location = New System.Drawing.Point(979, 140)
        Me.keikotuTextBox.Name = "keikotuTextBox"
        Me.keikotuTextBox.Size = New System.Drawing.Size(53, 19)
        Me.keikotuTextBox.TabIndex = 76
        Me.keikotuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'hizatakaTextBox
        '
        Me.hizatakaTextBox.Location = New System.Drawing.Point(979, 162)
        Me.hizatakaTextBox.Name = "hizatakaTextBox"
        Me.hizatakaTextBox.Size = New System.Drawing.Size(53, 19)
        Me.hizatakaTextBox.TabIndex = 77
        Me.hizatakaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'goalBmiTextBox
        '
        Me.goalBmiTextBox.Location = New System.Drawing.Point(979, 189)
        Me.goalBmiTextBox.Name = "goalBmiTextBox"
        Me.goalBmiTextBox.Size = New System.Drawing.Size(53, 19)
        Me.goalBmiTextBox.TabIndex = 78
        Me.goalBmiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'katudo1TextBox
        '
        Me.katudo1TextBox.Location = New System.Drawing.Point(1062, 231)
        Me.katudo1TextBox.Name = "katudo1TextBox"
        Me.katudo1TextBox.Size = New System.Drawing.Size(48, 19)
        Me.katudo1TextBox.TabIndex = 79
        Me.katudo1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'stress1TextBox
        '
        Me.stress1TextBox.Location = New System.Drawing.Point(1132, 231)
        Me.stress1TextBox.Name = "stress1TextBox"
        Me.stress1TextBox.Size = New System.Drawing.Size(48, 19)
        Me.stress1TextBox.TabIndex = 80
        Me.stress1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'kaizen1TextBox
        '
        Me.kaizen1TextBox.Location = New System.Drawing.Point(1202, 231)
        Me.kaizen1TextBox.Name = "kaizen1TextBox"
        Me.kaizen1TextBox.Size = New System.Drawing.Size(48, 19)
        Me.kaizen1TextBox.TabIndex = 81
        Me.kaizen1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'katudo2TextBox
        '
        Me.katudo2TextBox.Location = New System.Drawing.Point(1062, 345)
        Me.katudo2TextBox.Name = "katudo2TextBox"
        Me.katudo2TextBox.Size = New System.Drawing.Size(48, 19)
        Me.katudo2TextBox.TabIndex = 82
        Me.katudo2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'stress2TextBox
        '
        Me.stress2TextBox.Location = New System.Drawing.Point(1132, 345)
        Me.stress2TextBox.Name = "stress2TextBox"
        Me.stress2TextBox.Size = New System.Drawing.Size(48, 19)
        Me.stress2TextBox.TabIndex = 83
        Me.stress2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'kaizen2TextBox
        '
        Me.kaizen2TextBox.Location = New System.Drawing.Point(1202, 345)
        Me.kaizen2TextBox.Name = "kaizen2TextBox"
        Me.kaizen2TextBox.Size = New System.Drawing.Size(48, 19)
        Me.kaizen2TextBox.TabIndex = 84
        Me.kaizen2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'albTextBox
        '
        Me.albTextBox.Location = New System.Drawing.Point(929, 516)
        Me.albTextBox.Name = "albTextBox"
        Me.albTextBox.Size = New System.Drawing.Size(41, 19)
        Me.albTextBox.TabIndex = 85
        Me.albTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nutritionTextBox
        '
        Me.nutritionTextBox.Location = New System.Drawing.Point(1092, 516)
        Me.nutritionTextBox.Name = "nutritionTextBox"
        Me.nutritionTextBox.Size = New System.Drawing.Size(41, 19)
        Me.nutritionTextBox.TabIndex = 86
        Me.nutritionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'intakeTextBox
        '
        Me.intakeTextBox.Location = New System.Drawing.Point(929, 538)
        Me.intakeTextBox.Name = "intakeTextBox"
        Me.intakeTextBox.Size = New System.Drawing.Size(41, 19)
        Me.intakeTextBox.TabIndex = 87
        Me.intakeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'decubitusTextBox
        '
        Me.decubitusTextBox.Location = New System.Drawing.Point(1092, 538)
        Me.decubitusTextBox.Name = "decubitusTextBox"
        Me.decubitusTextBox.Size = New System.Drawing.Size(41, 19)
        Me.decubitusTextBox.TabIndex = 88
        Me.decubitusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(972, 520)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(26, 12)
        Me.Label48.TabIndex = 89
        Me.Label48.Text = "g/dl"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(972, 541)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(11, 12)
        Me.Label49.TabIndex = 90
        Me.Label49.Text = "%"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(1021, 520)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(65, 12)
        Me.Label50.TabIndex = 91
        Me.Label50.Text = "栄養補給法"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.Location = New System.Drawing.Point(1136, 520)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(104, 11)
        Me.Label51.TabIndex = 92
        Me.Label51.Text = "(1:経腸　2:静脈　3:無)"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(1021, 542)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(29, 12)
        Me.Label52.TabIndex = 93
        Me.Label52.Text = "褥瘡"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.Location = New System.Drawing.Point(1136, 542)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(56, 11)
        Me.Label53.TabIndex = 94
        Me.Label53.Text = "(1:有　2:無)"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(1035, 193)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(57, 12)
        Me.Label42.TabIndex = 95
        Me.Label42.Text = "(目標BMI)"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.Location = New System.Drawing.Point(1010, 218)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(35, 11)
        Me.Label43.TabIndex = 96
        Me.Label43.Text = "※BEE"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.Location = New System.Drawing.Point(1062, 218)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(49, 11)
        Me.Label46.TabIndex = 97
        Me.Label46.Text = "活動係数"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.Location = New System.Drawing.Point(1132, 218)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(52, 11)
        Me.Label47.TabIndex = 98
        Me.Label47.Text = "ｽﾄﾚｽ係数"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.Location = New System.Drawing.Point(1202, 218)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(49, 11)
        Me.Label54.TabIndex = 99
        Me.Label54.Text = "改善係数"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.Location = New System.Drawing.Point(1202, 331)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(49, 11)
        Me.Label55.TabIndex = 103
        Me.Label55.Text = "改善係数"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.Location = New System.Drawing.Point(1132, 331)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(52, 11)
        Me.Label56.TabIndex = 102
        Me.Label56.Text = "ｽﾄﾚｽ係数"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label57.Location = New System.Drawing.Point(1062, 331)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(49, 11)
        Me.Label57.TabIndex = 101
        Me.Label57.Text = "活動係数"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label58.Location = New System.Drawing.Point(1010, 331)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(35, 11)
        Me.Label58.TabIndex = 100
        Me.Label58.Text = "※BEE"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label59.Location = New System.Drawing.Point(1000, 437)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(38, 11)
        Me.Label59.TabIndex = 104
        Me.Label59.Text = "算出率"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.Location = New System.Drawing.Point(1000, 456)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(38, 11)
        Me.Label60.TabIndex = 105
        Me.Label60.Text = "算出率"
        '
        'workedOutPercent1TextBox
        '
        Me.workedOutPercent1TextBox.Enabled = False
        Me.workedOutPercent1TextBox.Location = New System.Drawing.Point(1040, 431)
        Me.workedOutPercent1TextBox.Name = "workedOutPercent1TextBox"
        Me.workedOutPercent1TextBox.Size = New System.Drawing.Size(32, 19)
        Me.workedOutPercent1TextBox.TabIndex = 106
        Me.workedOutPercent1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'workedOutPercent2TextBox
        '
        Me.workedOutPercent2TextBox.Enabled = False
        Me.workedOutPercent2TextBox.Location = New System.Drawing.Point(1040, 452)
        Me.workedOutPercent2TextBox.Name = "workedOutPercent2TextBox"
        Me.workedOutPercent2TextBox.Size = New System.Drawing.Size(32, 19)
        Me.workedOutPercent2TextBox.TabIndex = 107
        Me.workedOutPercent2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label61.Location = New System.Drawing.Point(1114, 239)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(16, 11)
        Me.Label61.TabIndex = 108
        Me.Label61.Text = "×"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label62.Location = New System.Drawing.Point(1184, 239)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(16, 11)
        Me.Label62.TabIndex = 109
        Me.Label62.Text = "×"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.Location = New System.Drawing.Point(1044, 239)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(16, 11)
        Me.Label63.TabIndex = 110
        Me.Label63.Text = "×"
        '
        'bee1Label
        '
        Me.bee1Label.ForeColor = System.Drawing.Color.Red
        Me.bee1Label.Location = New System.Drawing.Point(1009, 234)
        Me.bee1Label.Name = "bee1Label"
        Me.bee1Label.Size = New System.Drawing.Size(37, 12)
        Me.bee1Label.TabIndex = 111
        Me.bee1Label.Text = "0"
        Me.bee1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bee2Label
        '
        Me.bee2Label.ForeColor = System.Drawing.Color.Red
        Me.bee2Label.Location = New System.Drawing.Point(1009, 348)
        Me.bee2Label.Name = "bee2Label"
        Me.bee2Label.Size = New System.Drawing.Size(37, 12)
        Me.bee2Label.TabIndex = 112
        Me.bee2Label.Text = "0"
        Me.bee2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.Location = New System.Drawing.Point(1044, 353)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(16, 11)
        Me.Label64.TabIndex = 113
        Me.Label64.Text = "×"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.Location = New System.Drawing.Point(1114, 353)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(16, 11)
        Me.Label65.TabIndex = 114
        Me.Label65.Text = "×"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.Location = New System.Drawing.Point(1184, 353)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(16, 11)
        Me.Label66.TabIndex = 115
        Me.Label66.Text = "×"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.Location = New System.Drawing.Point(1075, 435)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(11, 12)
        Me.Label67.TabIndex = 116
        Me.Label67.Text = "%"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.Location = New System.Drawing.Point(1075, 455)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(11, 12)
        Me.Label68.TabIndex = 117
        Me.Label68.Text = "%"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label69.Location = New System.Drawing.Point(1000, 477)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(74, 11)
        Me.Label69.TabIndex = 118
        Me.Label69.Text = "1,000Kcal=10g"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label70.Location = New System.Drawing.Point(1000, 492)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(269, 11)
        Me.Label70.TabIndex = 119
        Me.Label70.Text = "成人:35ml/kg　56歳以上:30ml/kg　66歳以上:25-30ml/kg"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label71.Location = New System.Drawing.Point(1000, 503)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(192, 11)
        Me.Label71.TabIndex = 120
        Me.Label71.Text = "66歳以上:25-30ml/kg　(最低値:1,300ml)"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.Blue
        Me.Label72.Location = New System.Drawing.Point(1039, 145)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(121, 11)
        Me.Label72.TabIndex = 121
        Me.Label72.Text = "3.23×(脛骨長)cm + 49.6"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Blue
        Me.Label73.Location = New System.Drawing.Point(1040, 161)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(180, 11)
        Me.Label73.TabIndex = 122
        Me.Label73.Text = "女77.88 + (膝高 * 1.77) - (年齢 * 0.1)"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Blue
        Me.Label74.Location = New System.Drawing.Point(1040, 174)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(186, 11)
        Me.Label74.TabIndex = 123
        Me.Label74.Text = "男64.02 + (膝高 * 2.12) - (年齢 * 0.07)"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Blue
        Me.Label75.Location = New System.Drawing.Point(962, 256)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(287, 11)
        Me.Label75.TabIndex = 124
        Me.Label75.Text = "※　♂ 66.5 + (13.75 * 理想体重) + (5 * 身長) - (6.75 * 年齢)"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Blue
        Me.Label76.Location = New System.Drawing.Point(980, 268)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(289, 11)
        Me.Label76.TabIndex = 125
        Me.Label76.Text = "♀ 665.14 + (9.56 * 理想体重) + (1.85 * 身長) - (4.68 * 年齢)"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Blue
        Me.Label77.Location = New System.Drawing.Point(1000, 287)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(75, 11)
        Me.Label77.TabIndex = 126
        Me.Label77.Text = "理想体重 * 1.3"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.Blue
        Me.Label78.Location = New System.Drawing.Point(1000, 304)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(81, 11)
        Me.Label78.TabIndex = 127
        Me.Label78.Text = "理想体重 * 1.13"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Blue
        Me.Label79.Location = New System.Drawing.Point(980, 382)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(289, 11)
        Me.Label79.TabIndex = 129
        Me.Label79.Text = "♀ 665.14 + (9.56 * 基準体重) + (1.85 * 身長) - (4.68 * 年齢)"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.Blue
        Me.Label80.Location = New System.Drawing.Point(962, 370)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(287, 11)
        Me.Label80.TabIndex = 128
        Me.Label80.Text = "※　♂ 66.5 + (13.75 * 基準体重) + (5 * 身長) - (6.75 * 年齢)"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Blue
        Me.Label81.Location = New System.Drawing.Point(1000, 418)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(81, 11)
        Me.Label81.TabIndex = 131
        Me.Label81.Text = "基準体重 * 1.13"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.Blue
        Me.Label82.Location = New System.Drawing.Point(1000, 401)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(75, 11)
        Me.Label82.TabIndex = 130
        Me.Label82.Text = "基準体重 * 1.3"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Blue
        Me.Label83.Location = New System.Drawing.Point(1092, 435)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(114, 11)
        Me.Label83.TabIndex = 132
        Me.Label83.Text = "現状ｴﾈﾙｷﾞｰ量 * 0.2/9"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Blue
        Me.Label84.Location = New System.Drawing.Point(1092, 456)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(120, 11)
        Me.Label84.TabIndex = 133
        Me.Label84.Text = "現状ｴﾈﾙｷﾞｰ量 * 0.65/4"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Location = New System.Drawing.Point(163, 117)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(82, 19)
        Me.TextBox1.TabIndex = 134
        Me.TextBox1.Text = "項目"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.Location = New System.Drawing.Point(244, 117)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(81, 19)
        Me.TextBox2.TabIndex = 135
        Me.TextBox2.Text = "単位等"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.Location = New System.Drawing.Point(324, 117)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(128, 19)
        Me.TextBox3.TabIndex = 136
        Me.TextBox3.Text = "Ⅰ"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.Location = New System.Drawing.Point(451, 117)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(128, 19)
        Me.TextBox4.TabIndex = 137
        Me.TextBox4.Text = "Ⅱ"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.Location = New System.Drawing.Point(578, 117)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(128, 19)
        Me.TextBox5.TabIndex = 138
        Me.TextBox5.Text = "Ⅲ"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox6.Location = New System.Drawing.Point(705, 117)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(129, 19)
        Me.TextBox6.TabIndex = 139
        Me.TextBox6.Text = "Ⅳ"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(1, 5)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(41, 12)
        Me.Label85.TabIndex = 140
        Me.Label85.Text = "実施日"
        '
        'JPanel
        '
        Me.JPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JPanel.Controls.Add(Me.Label90)
        Me.JPanel.Controls.Add(Me.Label89)
        Me.JPanel.Controls.Add(Me.Label88)
        Me.JPanel.Controls.Add(Me.Label87)
        Me.JPanel.Controls.Add(Me.Label86)
        Me.JPanel.Controls.Add(Me.J4YmdBox)
        Me.JPanel.Controls.Add(Me.J3YmdBox)
        Me.JPanel.Controls.Add(Me.J2YmdBox)
        Me.JPanel.Controls.Add(Me.J1YmdBox)
        Me.JPanel.Controls.Add(Me.Label85)
        Me.JPanel.Location = New System.Drawing.Point(163, 136)
        Me.JPanel.Name = "JPanel"
        Me.JPanel.Size = New System.Drawing.Size(671, 23)
        Me.JPanel.TabIndex = 141
        '
        'Label90
        '
        Me.Label90.BackColor = System.Drawing.SystemColors.Control
        Me.Label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label90.ForeColor = System.Drawing.SystemColors.Control
        Me.Label90.Location = New System.Drawing.Point(541, 0)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(1, 25)
        Me.Label90.TabIndex = 148
        '
        'Label89
        '
        Me.Label89.BackColor = System.Drawing.SystemColors.Control
        Me.Label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label89.ForeColor = System.Drawing.SystemColors.Control
        Me.Label89.Location = New System.Drawing.Point(414, 0)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(1, 25)
        Me.Label89.TabIndex = 147
        '
        'Label88
        '
        Me.Label88.BackColor = System.Drawing.SystemColors.Control
        Me.Label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label88.ForeColor = System.Drawing.SystemColors.Control
        Me.Label88.Location = New System.Drawing.Point(287, 0)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(1, 25)
        Me.Label88.TabIndex = 146
        '
        'Label87
        '
        Me.Label87.BackColor = System.Drawing.SystemColors.Control
        Me.Label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label87.ForeColor = System.Drawing.SystemColors.Control
        Me.Label87.Location = New System.Drawing.Point(160, 0)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(1, 25)
        Me.Label87.TabIndex = 143
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label86.ForeColor = System.Drawing.SystemColors.Control
        Me.Label86.Location = New System.Drawing.Point(80, 0)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(1, 25)
        Me.Label86.TabIndex = 142
        '
        'J4YmdBox
        '
        Me.J4YmdBox.boxType = 10
        Me.J4YmdBox.DateText = ""
        Me.J4YmdBox.EraLabelText = "H31"
        Me.J4YmdBox.EraText = ""
        Me.J4YmdBox.Location = New System.Drawing.Point(554, -1)
        Me.J4YmdBox.MonthLabelText = "03"
        Me.J4YmdBox.MonthText = ""
        Me.J4YmdBox.Name = "J4YmdBox"
        Me.J4YmdBox.Size = New System.Drawing.Size(106, 24)
        Me.J4YmdBox.TabIndex = 145
        '
        'J3YmdBox
        '
        Me.J3YmdBox.boxType = 10
        Me.J3YmdBox.DateText = ""
        Me.J3YmdBox.EraLabelText = "H31"
        Me.J3YmdBox.EraText = ""
        Me.J3YmdBox.Location = New System.Drawing.Point(427, -1)
        Me.J3YmdBox.MonthLabelText = "03"
        Me.J3YmdBox.MonthText = ""
        Me.J3YmdBox.Name = "J3YmdBox"
        Me.J3YmdBox.Size = New System.Drawing.Size(106, 24)
        Me.J3YmdBox.TabIndex = 144
        '
        'J2YmdBox
        '
        Me.J2YmdBox.boxType = 10
        Me.J2YmdBox.DateText = ""
        Me.J2YmdBox.EraLabelText = "H31"
        Me.J2YmdBox.EraText = ""
        Me.J2YmdBox.Location = New System.Drawing.Point(300, -1)
        Me.J2YmdBox.MonthLabelText = "03"
        Me.J2YmdBox.MonthText = ""
        Me.J2YmdBox.Name = "J2YmdBox"
        Me.J2YmdBox.Size = New System.Drawing.Size(106, 24)
        Me.J2YmdBox.TabIndex = 143
        '
        'J1YmdBox
        '
        Me.J1YmdBox.boxType = 10
        Me.J1YmdBox.DateText = ""
        Me.J1YmdBox.EraLabelText = "H31"
        Me.J1YmdBox.EraText = ""
        Me.J1YmdBox.Location = New System.Drawing.Point(173, -1)
        Me.J1YmdBox.MonthLabelText = "03"
        Me.J1YmdBox.MonthText = ""
        Me.J1YmdBox.Name = "J1YmdBox"
        Me.J1YmdBox.Size = New System.Drawing.Size(106, 24)
        Me.J1YmdBox.TabIndex = 142
        '
        'dgvScreeningUp
        '
        Me.dgvScreeningUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScreeningUp.Location = New System.Drawing.Point(163, 158)
        Me.dgvScreeningUp.Name = "dgvScreeningUp"
        Me.dgvScreeningUp.RowTemplate.Height = 21
        Me.dgvScreeningUp.Size = New System.Drawing.Size(671, 345)
        Me.dgvScreeningUp.TabIndex = 11
        '
        'スクリーニング書
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1645, 684)
        Me.Controls.Add(Me.JPanel)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label84)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.Label79)
        Me.Controls.Add(Me.Label80)
        Me.Controls.Add(Me.Label78)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.bee2Label)
        Me.Controls.Add(Me.bee1Label)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.workedOutPercent2TextBox)
        Me.Controls.Add(Me.workedOutPercent1TextBox)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.decubitusTextBox)
        Me.Controls.Add(Me.intakeTextBox)
        Me.Controls.Add(Me.nutritionTextBox)
        Me.Controls.Add(Me.albTextBox)
        Me.Controls.Add(Me.kaizen2TextBox)
        Me.Controls.Add(Me.stress2TextBox)
        Me.Controls.Add(Me.katudo2TextBox)
        Me.Controls.Add(Me.kaizen1TextBox)
        Me.Controls.Add(Me.stress1TextBox)
        Me.Controls.Add(Me.katudo1TextBox)
        Me.Controls.Add(Me.goalBmiTextBox)
        Me.Controls.Add(Me.hizatakaTextBox)
        Me.Controls.Add(Me.keikotuTextBox)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.waterLabel)
        Me.Controls.Add(Me.seniLabel)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.tosituLabel)
        Me.Controls.Add(Me.sisituLabel)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.necessaryProtein2Label)
        Me.Controls.Add(Me.necessaryProtein1Label)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.necessaryKcalLabel)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.idealProtein2Label)
        Me.Controls.Add(Me.idealProtein1Label)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.idealKcalLabel)
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
        Me.Controls.Add(Me.baseValueGroupBox)
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
        Me.Controls.Add(Me.dgvWeightChange)
        Me.Controls.Add(Me.dgvScreeningUp)
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
        CType(Me.dgvWeightChange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.baseValueGroupBox.ResumeLayout(False)
        Me.baseValueGroupBox.PerformLayout()
        Me.JPanel.ResumeLayout(False)
        Me.JPanel.PerformLayout()
        CType(Me.dgvScreeningUp, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvWeightChange As System.Windows.Forms.DataGridView
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
    Friend WithEvents heightLabel As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents baseValueGroupBox As System.Windows.Forms.GroupBox
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
    Friend WithEvents idealKcalLabel As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents idealProtein1Label As System.Windows.Forms.Label
    Friend WithEvents idealProtein2Label As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents necessaryKcalLabel As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents necessaryProtein2Label As System.Windows.Forms.Label
    Friend WithEvents necessaryProtein1Label As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents tosituLabel As System.Windows.Forms.Label
    Friend WithEvents sisituLabel As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents waterLabel As System.Windows.Forms.Label
    Friend WithEvents seniLabel As System.Windows.Forms.Label
    Friend WithEvents keikotuTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hizatakaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents goalBmiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents katudo1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents stress1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents kaizen1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents katudo2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents stress2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents kaizen2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents albTextBox As System.Windows.Forms.TextBox
    Friend WithEvents nutritionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents intakeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents decubitusTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents workedOutPercent1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents workedOutPercent2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents bee1Label As System.Windows.Forms.Label
    Friend WithEvents bee2Label As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents JPanel As System.Windows.Forms.Panel
    Friend WithEvents J1YmdBox As ymdBox.ymdBox
    Friend WithEvents J4YmdBox As ymdBox.ymdBox
    Friend WithEvents J3YmdBox As ymdBox.ymdBox
    Friend WithEvents J2YmdBox As ymdBox.ymdBox
    Friend WithEvents dgvScreeningUp As Symphony_NCare.screeningDataGridViewUp
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
End Class
