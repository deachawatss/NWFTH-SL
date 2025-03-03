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
        ' PictureBoxIcon
        '
        ' The PictureBox used to display an icon (info, error, warning).
        Me.PictureBoxIcon.Name = "PictureBoxIcon"
        Me.PictureBoxIcon.Size = New System.Drawing.Size(40, 40)
        Me.PictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxIcon.TabStop = False
        '
        ' LabelMessage
        '
        ' AutoSize = True allows the label to resize vertically for multi-line text.
        ' MaximumSize ensures the text wraps at a certain width.
        Me.LabelMessage.AutoSize = True
        Me.LabelMessage.MaximumSize = New System.Drawing.Size(240, 0)
        ' Increase the font size to make it more prominent (e.g., 14 pt).
        Me.LabelMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' ButtonOK
        '
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonOK.Size = New System.Drawing.Size(90, 40)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        ' FormMessage
        '
        ' Reduce the overall form width to minimize left/right empty space.
        Me.ClientSize = New System.Drawing.Size(280, 180)
        Me.ShowIcon = False
        Me.Text = ""
        Me.ControlBox = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        Me.Controls.Add(Me.PictureBoxIcon)
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.ButtonOK)

        Me.Name = "FormMessage"
        CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
