Partial Class FormMessage
    Inherits System.Windows.Forms.Form

    Friend WithEvents LabelMessage As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents PictureBoxIcon As PictureBox

    Private Sub InitializeComponent()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.PictureBoxIcon = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelMessage
        '
        Me.LabelMessage.AutoSize = True
        Me.LabelMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelMessage.Location = New System.Drawing.Point(0, 0)
        Me.LabelMessage.MaximumSize = New System.Drawing.Size(240, 0)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(0, 24)
        Me.LabelMessage.TabIndex = 1
        Me.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonOK
        '
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonOK.Location = New System.Drawing.Point(0, 0)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(90, 40)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'PictureBoxIcon
        '
        Me.PictureBoxIcon.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxIcon.Name = "PictureBoxIcon"
        Me.PictureBoxIcon.Size = New System.Drawing.Size(40, 40)
        Me.PictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxIcon.TabIndex = 0
        Me.PictureBoxIcon.TabStop = False
        '
        'FormMessage
        '
        Me.ClientSize = New System.Drawing.Size(280, 180)
        Me.Controls.Add(Me.PictureBoxIcon)
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.ButtonOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMessage"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
