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
        Me.namArea = New System.Windows.Forms.GroupBox()
        Me.historyListBox = New System.Windows.Forms.ListBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.clearComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.createYmdBox = New ymdBox.ymdBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.writerComboBox = New System.Windows.Forms.ComboBox()
        Me.dgvSub = New System.Windows.Forms.DataGridView()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnPaste = New System.Windows.Forms.Button()
        Me.dgvAssess = New System.Windows.Forms.DataGridView()
        Me.namArea.SuspendLayout()
        CType(Me.dgvSub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssess, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'historyListBox
        '
        Me.historyListBox.BackColor = System.Drawing.SystemColors.Control
        Me.historyListBox.FormattingEnabled = True
        Me.historyListBox.Location = New System.Drawing.Point(12, 27)
        Me.historyListBox.Name = "historyListBox"
        Me.historyListBox.Size = New System.Drawing.Size(97, 82)
        Me.historyListBox.TabIndex = 0
        '
        'btnRegist
        '
        Me.btnRegist.ForeColor = System.Drawing.Color.Black
        Me.btnRegist.Location = New System.Drawing.Point(12, 120)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(75, 31)
        Me.btnRegist.TabIndex = 1
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(12, 157)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 31)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.Location = New System.Drawing.Point(12, 194)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 31)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Location = New System.Drawing.Point(12, 231)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 31)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'clearComboBox
        '
        Me.clearComboBox.FormattingEnabled = True
        Me.clearComboBox.Location = New System.Drawing.Point(92, 162)
        Me.clearComboBox.Name = "clearComboBox"
        Me.clearComboBox.Size = New System.Drawing.Size(38, 21)
        Me.clearComboBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(165, 21)
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
        Me.createYmdBox.Location = New System.Drawing.Point(238, 3)
        Me.createYmdBox.MonthLabelText = "02"
        Me.createYmdBox.MonthText = ""
        Me.createYmdBox.Name = "createYmdBox"
        Me.createYmdBox.Size = New System.Drawing.Size(145, 46)
        Me.createYmdBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(387, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "記入者氏名"
        '
        'writerComboBox
        '
        Me.writerComboBox.FormattingEnabled = True
        Me.writerComboBox.Location = New System.Drawing.Point(459, 17)
        Me.writerComboBox.Name = "writerComboBox"
        Me.writerComboBox.Size = New System.Drawing.Size(100, 20)
        Me.writerComboBox.TabIndex = 4
        '
        'dgvSub
        '
        Me.dgvSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSub.Location = New System.Drawing.Point(566, 17)
        Me.dgvSub.Name = "dgvSub"
        Me.dgvSub.RowTemplate.Height = 21
        Me.dgvSub.Size = New System.Drawing.Size(515, 47)
        Me.dgvSub.TabIndex = 5
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(610, 70)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(60, 23)
        Me.btnCopy.TabIndex = 6
        Me.btnCopy.Text = "コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Location = New System.Drawing.Point(678, 70)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(60, 23)
        Me.btnPaste.TabIndex = 7
        Me.btnPaste.Text = "貼付け"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'dgvAssess
        '
        Me.dgvAssess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssess.Location = New System.Drawing.Point(177, 105)
        Me.dgvAssess.Name = "dgvAssess"
        Me.dgvAssess.RowTemplate.Height = 21
        Me.dgvAssess.Size = New System.Drawing.Size(904, 552)
        Me.dgvAssess.TabIndex = 8
        '
        'アセモニ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 682)
        Me.Controls.Add(Me.dgvAssess)
        Me.Controls.Add(Me.btnPaste)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.dgvSub)
        Me.Controls.Add(Me.writerComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.createYmdBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.namArea)
        Me.Name = "アセモニ"
        Me.Text = "アセモニ"
        Me.namArea.ResumeLayout(False)
        CType(Me.dgvSub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssess, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents writerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSub As System.Windows.Forms.DataGridView
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents dgvAssess As System.Windows.Forms.DataGridView
End Class
