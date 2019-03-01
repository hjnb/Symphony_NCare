<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class アセモニ
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.createYmdBox = New ymdBox.ymdBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tantoComboBox = New System.Windows.Forms.ComboBox()
        Me.dgvSub = New System.Windows.Forms.DataGridView()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnPaste = New System.Windows.Forms.Button()
        Me.datePanel = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.date4YmdBox = New ymdBox.ymdBox()
        Me.date3YmdBox = New ymdBox.ymdBox()
        Me.date2YmdBox = New ymdBox.ymdBox()
        Me.date1YmdBox = New ymdBox.ymdBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvAsses = New Symphony_NCare.AssesDataGridView(Me.components)
        Me.namArea.SuspendLayout()
        CType(Me.dgvSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.datePanel.SuspendLayout()
        CType(Me.dgvAsses, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.namArea.Location = New System.Drawing.Point(15, 55)
        Me.namArea.Name = "namArea"
        Me.namArea.Size = New System.Drawing.Size(141, 294)
        Me.namArea.TabIndex = 0
        Me.namArea.TabStop = False
        Me.namArea.Text = "浅井　幸子"
        '
        'clearComboBox
        '
        Me.clearComboBox.FormattingEnabled = True
        Me.clearComboBox.Location = New System.Drawing.Point(90, 162)
        Me.clearComboBox.Name = "clearComboBox"
        Me.clearComboBox.Size = New System.Drawing.Size(36, 21)
        Me.clearComboBox.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Location = New System.Drawing.Point(17, 231)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(68, 31)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.Location = New System.Drawing.Point(17, 194)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(68, 31)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(17, 157)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 31)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRegist
        '
        Me.btnRegist.ForeColor = System.Drawing.Color.Black
        Me.btnRegist.Location = New System.Drawing.Point(17, 120)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(173, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "作成年月日"
        '
        'createYmdBox
        '
        Me.createYmdBox.boxType = 3
        Me.createYmdBox.DateText = ""
        Me.createYmdBox.EraLabelText = "H31"
        Me.createYmdBox.EraText = ""
        Me.createYmdBox.Location = New System.Drawing.Point(246, 2)
        Me.createYmdBox.MonthLabelText = "03"
        Me.createYmdBox.MonthText = ""
        Me.createYmdBox.Name = "createYmdBox"
        Me.createYmdBox.Size = New System.Drawing.Size(145, 46)
        Me.createYmdBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(401, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "記入者氏名"
        '
        'tantoComboBox
        '
        Me.tantoComboBox.FormattingEnabled = True
        Me.tantoComboBox.Location = New System.Drawing.Point(473, 16)
        Me.tantoComboBox.Name = "tantoComboBox"
        Me.tantoComboBox.Size = New System.Drawing.Size(100, 20)
        Me.tantoComboBox.TabIndex = 4
        '
        'dgvSub
        '
        Me.dgvSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSub.Location = New System.Drawing.Point(588, 16)
        Me.dgvSub.Name = "dgvSub"
        Me.dgvSub.RowTemplate.Height = 21
        Me.dgvSub.Size = New System.Drawing.Size(515, 40)
        Me.dgvSub.TabIndex = 5
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(632, 62)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(60, 23)
        Me.btnCopy.TabIndex = 6
        Me.btnCopy.Text = "コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Location = New System.Drawing.Point(700, 62)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(60, 23)
        Me.btnPaste.TabIndex = 7
        Me.btnPaste.Text = "貼付け"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'datePanel
        '
        Me.datePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.datePanel.Controls.Add(Me.Label7)
        Me.datePanel.Controls.Add(Me.Label6)
        Me.datePanel.Controls.Add(Me.Label5)
        Me.datePanel.Controls.Add(Me.Label4)
        Me.datePanel.Controls.Add(Me.date4YmdBox)
        Me.datePanel.Controls.Add(Me.date3YmdBox)
        Me.datePanel.Controls.Add(Me.date2YmdBox)
        Me.datePanel.Controls.Add(Me.date1YmdBox)
        Me.datePanel.Controls.Add(Me.Label3)
        Me.datePanel.Location = New System.Drawing.Point(177, 89)
        Me.datePanel.Name = "datePanel"
        Me.datePanel.Size = New System.Drawing.Size(949, 26)
        Me.datePanel.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(241, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1, 24)
        Me.Label7.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(757, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1, 24)
        Me.Label6.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(585, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1, 24)
        Me.Label5.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(413, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1, 24)
        Me.Label4.TabIndex = 10
        '
        'date4YmdBox
        '
        Me.date4YmdBox.boxType = 9
        Me.date4YmdBox.DateText = ""
        Me.date4YmdBox.EraLabelText = "H31"
        Me.date4YmdBox.EraText = ""
        Me.date4YmdBox.Location = New System.Drawing.Point(801, 2)
        Me.date4YmdBox.MonthLabelText = "03"
        Me.date4YmdBox.MonthText = ""
        Me.date4YmdBox.Name = "date4YmdBox"
        Me.date4YmdBox.Size = New System.Drawing.Size(86, 20)
        Me.date4YmdBox.TabIndex = 13
        '
        'date3YmdBox
        '
        Me.date3YmdBox.boxType = 9
        Me.date3YmdBox.DateText = ""
        Me.date3YmdBox.EraLabelText = "H31"
        Me.date3YmdBox.EraText = ""
        Me.date3YmdBox.Location = New System.Drawing.Point(629, 2)
        Me.date3YmdBox.MonthLabelText = "03"
        Me.date3YmdBox.MonthText = ""
        Me.date3YmdBox.Name = "date3YmdBox"
        Me.date3YmdBox.Size = New System.Drawing.Size(86, 20)
        Me.date3YmdBox.TabIndex = 12
        '
        'date2YmdBox
        '
        Me.date2YmdBox.boxType = 9
        Me.date2YmdBox.DateText = ""
        Me.date2YmdBox.EraLabelText = "H31"
        Me.date2YmdBox.EraText = ""
        Me.date2YmdBox.Location = New System.Drawing.Point(457, 2)
        Me.date2YmdBox.MonthLabelText = "03"
        Me.date2YmdBox.MonthText = ""
        Me.date2YmdBox.Name = "date2YmdBox"
        Me.date2YmdBox.Size = New System.Drawing.Size(86, 20)
        Me.date2YmdBox.TabIndex = 11
        '
        'date1YmdBox
        '
        Me.date1YmdBox.boxType = 9
        Me.date1YmdBox.DateText = ""
        Me.date1YmdBox.EraLabelText = "H31"
        Me.date1YmdBox.EraText = ""
        Me.date1YmdBox.Location = New System.Drawing.Point(285, 2)
        Me.date1YmdBox.MonthLabelText = "03"
        Me.date1YmdBox.MonthText = ""
        Me.date1YmdBox.Name = "date1YmdBox"
        Me.date1YmdBox.Size = New System.Drawing.Size(86, 20)
        Me.date1YmdBox.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "実　施　日"
        '
        'dgvAsses
        '
        Me.dgvAsses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAsses.Location = New System.Drawing.Point(177, 115)
        Me.dgvAsses.Name = "dgvAsses"
        Me.dgvAsses.RowTemplate.Height = 21
        Me.dgvAsses.Size = New System.Drawing.Size(949, 528)
        Me.dgvAsses.TabIndex = 8
        '
        'アセモニ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 682)
        Me.Controls.Add(Me.datePanel)
        Me.Controls.Add(Me.dgvAsses)
        Me.Controls.Add(Me.btnPaste)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.dgvSub)
        Me.Controls.Add(Me.tantoComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.createYmdBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.namArea)
        Me.Name = "アセモニ"
        Me.Text = "アセスメント・モニタリング"
        Me.namArea.ResumeLayout(False)
        CType(Me.dgvSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.datePanel.ResumeLayout(False)
        Me.datePanel.PerformLayout()
        CType(Me.dgvAsses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents namArea As System.Windows.Forms.GroupBox
    Friend WithEvents historyListBox As System.Windows.Forms.ListBox
    Friend WithEvents clearComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents createYmdBox As ymdBox.ymdBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tantoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSub As System.Windows.Forms.DataGridView
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents dgvAsses As Symphony_NCare.AssesDataGridView
    Friend WithEvents datePanel As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents date1YmdBox As ymdBox.ymdBox
    Friend WithEvents date4YmdBox As ymdBox.ymdBox
    Friend WithEvents date3YmdBox As ymdBox.ymdBox
    Friend WithEvents date2YmdBox As ymdBox.ymdBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
