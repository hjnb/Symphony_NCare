<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 職員
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSyu = New System.Windows.Forms.ComboBox()
        Me.cmbYak = New System.Windows.Forms.ComboBox()
        Me.txtNam = New System.Windows.Forms.TextBox()
        Me.txtKana = New System.Windows.Forms.TextBox()
        Me.txtDsp = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Location = New System.Drawing.Point(24, 210)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 26
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(581, 337)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "種　別"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "職　名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "氏　名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "ﾌﾘｶﾞﾅ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "表　示"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(123, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "(１：表示　２：非表示)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(85, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "ﾀﾞﾌﾞﾙｸﾘｯｸした項目で並べます。"
        '
        'cmbSyu
        '
        Me.cmbSyu.FormattingEnabled = True
        Me.cmbSyu.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.cmbSyu.Items.AddRange(New Object() {"管理系", "事務", "特別養護老人ホーム", "栄養課", "居宅介護支援事業所", "ヘルパーステーション", "デイサービス", "生活支援ハウス", "ボランティア", "宿直", "その他"})
        Me.cmbSyu.Location = New System.Drawing.Point(87, 23)
        Me.cmbSyu.Name = "cmbSyu"
        Me.cmbSyu.Size = New System.Drawing.Size(134, 20)
        Me.cmbSyu.TabIndex = 8
        '
        'cmbYak
        '
        Me.cmbYak.FormattingEnabled = True
        Me.cmbYak.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.cmbYak.Location = New System.Drawing.Point(87, 53)
        Me.cmbYak.Name = "cmbYak"
        Me.cmbYak.Size = New System.Drawing.Size(134, 20)
        Me.cmbYak.TabIndex = 9
        '
        'txtNam
        '
        Me.txtNam.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtNam.Location = New System.Drawing.Point(87, 83)
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(134, 19)
        Me.txtNam.TabIndex = 10
        '
        'txtKana
        '
        Me.txtKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtKana.Location = New System.Drawing.Point(87, 113)
        Me.txtKana.Name = "txtKana"
        Me.txtKana.Size = New System.Drawing.Size(134, 19)
        Me.txtKana.TabIndex = 11
        '
        'txtDsp
        '
        Me.txtDsp.Location = New System.Drawing.Point(87, 143)
        Me.txtDsp.Name = "txtDsp"
        Me.txtDsp.Size = New System.Drawing.Size(27, 19)
        Me.txtDsp.TabIndex = 12
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(344, 137)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(67, 31)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.Text = "登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(427, 137)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(67, 31)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        '職員
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 564)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtDsp)
        Me.Controls.Add(Me.txtKana)
        Me.Controls.Add(Me.txtNam)
        Me.Controls.Add(Me.cmbYak)
        Me.Controls.Add(Me.cmbSyu)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "職員"
        Me.Text = "職員"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbSyu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYak As System.Windows.Forms.ComboBox
    Friend WithEvents txtNam As System.Windows.Forms.TextBox
    Friend WithEvents txtKana As System.Windows.Forms.TextBox
    Friend WithEvents txtDsp As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
