<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SL1))
        Me.Butsbatch = New System.Windows.Forms.Button()
        Me.Butfbatch = New System.Windows.Forms.Button()
        Me.txtbatch = New System.Windows.Forms.TextBox()
        Me.lblbatch = New System.Windows.Forms.Label()
        Me.Txtbin = New System.Windows.Forms.TextBox()
        Me.lblbin = New System.Windows.Forms.Label()
        Me.lblsbatch = New System.Windows.Forms.Label()
        Me.Lblfbatch = New System.Windows.Forms.Label()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.Butbatchcomplete = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lblfgdesc = New System.Windows.Forms.Label()
        Me.sbatchflash = New System.Windows.Forms.Timer(Me.components)
        Me.Butbin1 = New System.Windows.Forms.Button()
        Me.Butbin2 = New System.Windows.Forms.Button()
        Me.Butbin3 = New System.Windows.Forms.Button()
        Me.Butbin4 = New System.Windows.Forms.Button()
        Me.Butbin5 = New System.Windows.Forms.Button()
        Me.Butbin6 = New System.Windows.Forms.Button()
        Me.fbatchflash = New System.Windows.Forms.Timer(Me.components)
        Me.Lblversion = New System.Windows.Forms.Label()
        Me.Lblbatch2 = New System.Windows.Forms.Label()
        Me.ButFinishCleanContinue = New System.Windows.Forms.Button()
        Me.lblfclean3 = New System.Windows.Forms.Label()
        Me.lblsclean3 = New System.Windows.Forms.Label()
        Me.lblfclean2 = New System.Windows.Forms.Label()
        Me.lblsclean2 = New System.Windows.Forms.Label()
        Me.lblfclean1 = New System.Windows.Forms.Label()
        Me.lblsclean1 = New System.Windows.Forms.Label()
        Me.Butstartclean3 = New System.Windows.Forms.Button()
        Me.Butstartclean2 = New System.Windows.Forms.Button()
        Me.Butstartclean1 = New System.Windows.Forms.Button()
        Me.LblFSieve2 = New System.Windows.Forms.Label()
        Me.Clean3flash = New System.Windows.Forms.Timer(Me.components)
        Me.Clean2flash = New System.Windows.Forms.Timer(Me.components)
        Me.Clean1flash = New System.Windows.Forms.Timer(Me.components)
        Me.lbw = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Butsbatch
        '
        Me.Butsbatch.Enabled = False
        Me.Butsbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butsbatch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Butsbatch.Location = New System.Drawing.Point(585, 252)
        Me.Butsbatch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Butsbatch.Name = "Butsbatch"
        Me.Butsbatch.Size = New System.Drawing.Size(513, 358)
        Me.Butsbatch.TabIndex = 0
        Me.Butsbatch.Text = "Start Tip"
        Me.Butsbatch.UseVisualStyleBackColor = True
        '
        'Butfbatch
        '
        Me.Butfbatch.Enabled = False
        Me.Butfbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butfbatch.Location = New System.Drawing.Point(585, 642)
        Me.Butfbatch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Butfbatch.Name = "Butfbatch"
        Me.Butfbatch.Size = New System.Drawing.Size(513, 348)
        Me.Butfbatch.TabIndex = 1
        Me.Butfbatch.Text = "Finish Tip"
        Me.Butfbatch.UseVisualStyleBackColor = True
        '
        'txtbatch
        '
        Me.txtbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbatch.Location = New System.Drawing.Point(663, 46)
        Me.txtbatch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtbatch.Name = "txtbatch"
        Me.txtbatch.Size = New System.Drawing.Size(258, 43)
        Me.txtbatch.TabIndex = 2
        '
        'lblbatch
        '
        Me.lblbatch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblbatch.AutoSize = True
        Me.lblbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbatch.Location = New System.Drawing.Point(364, 51)
        Me.lblbatch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblbatch.Name = "lblbatch"
        Me.lblbatch.Size = New System.Drawing.Size(193, 37)
        Me.lblbatch.TabIndex = 3
        Me.lblbatch.Text = "Batch Ticket"
        '
        'Txtbin
        '
        Me.Txtbin.Enabled = False
        Me.Txtbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtbin.Location = New System.Drawing.Point(402, 1036)
        Me.Txtbin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txtbin.Name = "Txtbin"
        Me.Txtbin.Size = New System.Drawing.Size(120, 43)
        Me.Txtbin.TabIndex = 5
        Me.Txtbin.Visible = False
        '
        'lblbin
        '
        Me.lblbin.AutoSize = True
        Me.lblbin.Enabled = False
        Me.lblbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbin.Location = New System.Drawing.Point(291, 1042)
        Me.lblbin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblbin.Name = "lblbin"
        Me.lblbin.Size = New System.Drawing.Size(103, 37)
        Me.lblbin.TabIndex = 6
        Me.lblbin.Text = "Bin ID"
        Me.lblbin.Visible = False
        '
        'lblsbatch
        '
        Me.lblsbatch.AutoSize = True
        Me.lblsbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsbatch.Location = New System.Drawing.Point(1206, 398)
        Me.lblsbatch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsbatch.Name = "lblsbatch"
        Me.lblsbatch.Size = New System.Drawing.Size(0, 64)
        Me.lblsbatch.TabIndex = 7
        '
        'Lblfbatch
        '
        Me.Lblfbatch.AutoSize = True
        Me.Lblfbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblfbatch.Location = New System.Drawing.Point(1206, 780)
        Me.Lblfbatch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblfbatch.Name = "Lblfbatch"
        Me.Lblfbatch.Size = New System.Drawing.Size(0, 64)
        Me.Lblfbatch.TabIndex = 8
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.Location = New System.Drawing.Point(52, 158)
        Me.lblheading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(217, 29)
        Me.lblheading.TabIndex = 9
        Me.lblheading.Text = "Seasoning Tipping"
        '
        'Butbatchcomplete
        '
        Me.Butbatchcomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbatchcomplete.Location = New System.Drawing.Point(585, 1036)
        Me.Butbatchcomplete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Butbatchcomplete.Name = "Butbatchcomplete"
        Me.Butbatchcomplete.Size = New System.Drawing.Size(513, 348)
        Me.Butbatchcomplete.TabIndex = 10
        Me.Butbatchcomplete.Text = "Tip Complete"
        Me.Butbatchcomplete.UseVisualStyleBackColor = True
        Me.Butbatchcomplete.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(52, 20)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(201, 134)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Lblfgdesc
        '
        Me.Lblfgdesc.AutoSize = True
        Me.Lblfgdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblfgdesc.Location = New System.Drawing.Point(1269, 252)
        Me.Lblfgdesc.Name = "Lblfgdesc"
        Me.Lblfgdesc.Size = New System.Drawing.Size(0, 37)
        Me.Lblfgdesc.TabIndex = 11
        '
        'sbatchflash
        '
        Me.sbatchflash.Enabled = True
        Me.sbatchflash.Interval = 300
        '
        'Butbin1
        '
        Me.Butbin1.Enabled = False
        Me.Butbin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin1.Location = New System.Drawing.Point(52, 252)
        Me.Butbin1.Name = "Butbin1"
        Me.Butbin1.Size = New System.Drawing.Size(225, 231)
        Me.Butbin1.TabIndex = 12
        Me.Butbin1.Text = "01"
        Me.Butbin1.UseVisualStyleBackColor = True
        Me.Butbin1.Visible = False
        '
        'Butbin2
        '
        Me.Butbin2.Enabled = False
        Me.Butbin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin2.Location = New System.Drawing.Point(298, 252)
        Me.Butbin2.Name = "Butbin2"
        Me.Butbin2.Size = New System.Drawing.Size(225, 231)
        Me.Butbin2.TabIndex = 13
        Me.Butbin2.Text = "02"
        Me.Butbin2.UseVisualStyleBackColor = True
        Me.Butbin2.Visible = False
        '
        'Butbin3
        '
        Me.Butbin3.Enabled = False
        Me.Butbin3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin3.Location = New System.Drawing.Point(52, 506)
        Me.Butbin3.Name = "Butbin3"
        Me.Butbin3.Size = New System.Drawing.Size(225, 231)
        Me.Butbin3.TabIndex = 14
        Me.Butbin3.Text = "03"
        Me.Butbin3.UseVisualStyleBackColor = True
        Me.Butbin3.Visible = False
        '
        'Butbin4
        '
        Me.Butbin4.Enabled = False
        Me.Butbin4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin4.Location = New System.Drawing.Point(298, 506)
        Me.Butbin4.Name = "Butbin4"
        Me.Butbin4.Size = New System.Drawing.Size(225, 231)
        Me.Butbin4.TabIndex = 15
        Me.Butbin4.Text = "04"
        Me.Butbin4.UseVisualStyleBackColor = True
        Me.Butbin4.Visible = False
        '
        'Butbin5
        '
        Me.Butbin5.Enabled = False
        Me.Butbin5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin5.Location = New System.Drawing.Point(52, 758)
        Me.Butbin5.Name = "Butbin5"
        Me.Butbin5.Size = New System.Drawing.Size(225, 231)
        Me.Butbin5.TabIndex = 16
        Me.Butbin5.Text = "05"
        Me.Butbin5.UseVisualStyleBackColor = True
        Me.Butbin5.Visible = False
        '
        'Butbin6
        '
        Me.Butbin6.Enabled = False
        Me.Butbin6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin6.Location = New System.Drawing.Point(298, 758)
        Me.Butbin6.Name = "Butbin6"
        Me.Butbin6.Size = New System.Drawing.Size(225, 231)
        Me.Butbin6.TabIndex = 17
        Me.Butbin6.Text = "06"
        Me.Butbin6.UseVisualStyleBackColor = True
        Me.Butbin6.Visible = False
        '
        'fbatchflash
        '
        Me.fbatchflash.Enabled = True
        Me.fbatchflash.Interval = 300
        '
        'Lblversion
        '
        Me.Lblversion.AutoSize = True
        Me.Lblversion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblversion.Location = New System.Drawing.Point(321, 154)
        Me.Lblversion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblversion.Name = "Lblversion"
        Me.Lblversion.Size = New System.Drawing.Size(55, 32)
        Me.Lblversion.TabIndex = 18
        Me.Lblversion.Text = "1.0"
        '
        'Lblbatch2
        '
        Me.Lblbatch2.AutoSize = True
        Me.Lblbatch2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbatch2.Location = New System.Drawing.Point(1315, 237)
        Me.Lblbatch2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblbatch2.Name = "Lblbatch2"
        Me.Lblbatch2.Size = New System.Drawing.Size(0, 55)
        Me.Lblbatch2.TabIndex = 19
        '
        'ButFinishCleanContinue
        '
        Me.ButFinishCleanContinue.AutoSize = True
        Me.ButFinishCleanContinue.Enabled = False
        Me.ButFinishCleanContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButFinishCleanContinue.Location = New System.Drawing.Point(1170, 758)
        Me.ButFinishCleanContinue.Name = "ButFinishCleanContinue"
        Me.ButFinishCleanContinue.Size = New System.Drawing.Size(488, 114)
        Me.ButFinishCleanContinue.TabIndex = 56
        Me.ButFinishCleanContinue.Text = "Finish Clean"
        Me.ButFinishCleanContinue.UseVisualStyleBackColor = True
        '
        'lblfclean3
        '
        Me.lblfclean3.AutoSize = True
        Me.lblfclean3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean3.Location = New System.Drawing.Point(1592, 645)
        Me.lblfclean3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfclean3.Name = "lblfclean3"
        Me.lblfclean3.Size = New System.Drawing.Size(0, 46)
        Me.lblfclean3.TabIndex = 55
        '
        'lblsclean3
        '
        Me.lblsclean3.AutoSize = True
        Me.lblsclean3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean3.Location = New System.Drawing.Point(1592, 598)
        Me.lblsclean3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsclean3.Name = "lblsclean3"
        Me.lblsclean3.Size = New System.Drawing.Size(0, 46)
        Me.lblsclean3.TabIndex = 54
        '
        'lblfclean2
        '
        Me.lblfclean2.AutoSize = True
        Me.lblfclean2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean2.Location = New System.Drawing.Point(1592, 510)
        Me.lblfclean2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfclean2.Name = "lblfclean2"
        Me.lblfclean2.Size = New System.Drawing.Size(0, 46)
        Me.lblfclean2.TabIndex = 53
        '
        'lblsclean2
        '
        Me.lblsclean2.AutoSize = True
        Me.lblsclean2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean2.Location = New System.Drawing.Point(1592, 466)
        Me.lblsclean2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsclean2.Name = "lblsclean2"
        Me.lblsclean2.Size = New System.Drawing.Size(0, 46)
        Me.lblsclean2.TabIndex = 52
        '
        'lblfclean1
        '
        Me.lblfclean1.AutoSize = True
        Me.lblfclean1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean1.Location = New System.Drawing.Point(1592, 394)
        Me.lblfclean1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfclean1.Name = "lblfclean1"
        Me.lblfclean1.Size = New System.Drawing.Size(0, 46)
        Me.lblfclean1.TabIndex = 51
        '
        'lblsclean1
        '
        Me.lblsclean1.AutoSize = True
        Me.lblsclean1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean1.Location = New System.Drawing.Point(1592, 344)
        Me.lblsclean1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsclean1.Name = "lblsclean1"
        Me.lblsclean1.Size = New System.Drawing.Size(0, 46)
        Me.lblsclean1.TabIndex = 50
        '
        'Butstartclean3
        '
        Me.Butstartclean3.Image = CType(resources.GetObject("Butstartclean3.Image"), System.Drawing.Image)
        Me.Butstartclean3.Location = New System.Drawing.Point(1252, 576)
        Me.Butstartclean3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Butstartclean3.Name = "Butstartclean3"
        Me.Butstartclean3.Size = New System.Drawing.Size(300, 135)
        Me.Butstartclean3.TabIndex = 49
        Me.Butstartclean3.UseVisualStyleBackColor = True
        '
        'Butstartclean2
        '
        Me.Butstartclean2.Image = CType(resources.GetObject("Butstartclean2.Image"), System.Drawing.Image)
        Me.Butstartclean2.Location = New System.Drawing.Point(1252, 447)
        Me.Butstartclean2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Butstartclean2.Name = "Butstartclean2"
        Me.Butstartclean2.Size = New System.Drawing.Size(300, 135)
        Me.Butstartclean2.TabIndex = 48
        Me.Butstartclean2.UseVisualStyleBackColor = True
        '
        'Butstartclean1
        '
        Me.Butstartclean1.Image = CType(resources.GetObject("Butstartclean1.Image"), System.Drawing.Image)
        Me.Butstartclean1.Location = New System.Drawing.Point(1252, 322)
        Me.Butstartclean1.Name = "Butstartclean1"
        Me.Butstartclean1.Size = New System.Drawing.Size(300, 135)
        Me.Butstartclean1.TabIndex = 47
        Me.Butstartclean1.UseVisualStyleBackColor = True
        '
        'LblFSieve2
        '
        Me.LblFSieve2.AutoSize = True
        Me.LblFSieve2.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFSieve2.Location = New System.Drawing.Point(1264, 344)
        Me.LblFSieve2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFSieve2.Name = "LblFSieve2"
        Me.LblFSieve2.Size = New System.Drawing.Size(0, 64)
        Me.LblFSieve2.TabIndex = 46
        '
        'Clean3flash
        '
        '
        'Clean2flash
        '
        '
        'Clean1flash
        '
        '
        'lbw
        '
        Me.lbw.AutoSize = True
        Me.lbw.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbw.Location = New System.Drawing.Point(1175, 99)
        Me.lbw.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbw.Name = "lbw"
        Me.lbw.Size = New System.Drawing.Size(0, 55)
        Me.lbw.TabIndex = 57
        '
        'SL1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1914, 1040)
        Me.Controls.Add(Me.lbw)
        Me.Controls.Add(Me.ButFinishCleanContinue)
        Me.Controls.Add(Me.lblfclean3)
        Me.Controls.Add(Me.lblsclean3)
        Me.Controls.Add(Me.lblfclean2)
        Me.Controls.Add(Me.lblsclean2)
        Me.Controls.Add(Me.lblfclean1)
        Me.Controls.Add(Me.lblsclean1)
        Me.Controls.Add(Me.Butstartclean3)
        Me.Controls.Add(Me.Butstartclean2)
        Me.Controls.Add(Me.Butstartclean1)
        Me.Controls.Add(Me.LblFSieve2)
        Me.Controls.Add(Me.Lblbatch2)
        Me.Controls.Add(Me.Lblversion)
        Me.Controls.Add(Me.Butbin6)
        Me.Controls.Add(Me.Butbin5)
        Me.Controls.Add(Me.Butbin4)
        Me.Controls.Add(Me.Butbin3)
        Me.Controls.Add(Me.Butbin2)
        Me.Controls.Add(Me.Butbin1)
        Me.Controls.Add(Me.Lblfgdesc)
        Me.Controls.Add(Me.Butbatchcomplete)
        Me.Controls.Add(Me.lblheading)
        Me.Controls.Add(Me.Lblfbatch)
        Me.Controls.Add(Me.lblsbatch)
        Me.Controls.Add(Me.lblbin)
        Me.Controls.Add(Me.Txtbin)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblbatch)
        Me.Controls.Add(Me.txtbatch)
        Me.Controls.Add(Me.Butfbatch)
        Me.Controls.Add(Me.Butsbatch)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SL1"
        Me.Text = "SL1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Butsbatch As Button
    Friend WithEvents Butfbatch As Button
    Friend WithEvents txtbatch As TextBox
    Friend WithEvents lblbatch As Label
    Friend WithEvents Txtbin As TextBox
    Friend WithEvents lblbin As Label
    Friend WithEvents lblsbatch As Label
    Friend WithEvents Lblfbatch As Label
    Friend WithEvents lblheading As Label
    Friend WithEvents Butbatchcomplete As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Lblfgdesc As Label
    Friend WithEvents sbatchflash As Timer
    Friend WithEvents Butbin1 As Button
    Friend WithEvents Butbin2 As Button
    Friend WithEvents Butbin3 As Button
    Friend WithEvents Butbin4 As Button
    Friend WithEvents Butbin5 As Button
    Friend WithEvents Butbin6 As Button
    Friend WithEvents fbatchflash As Timer
    Friend WithEvents Lblversion As Label
    Friend WithEvents Lblbatch2 As Label
    Friend WithEvents ButFinishCleanContinue As Button
    Friend WithEvents lblfclean3 As Label
    Friend WithEvents lblsclean3 As Label
    Friend WithEvents lblfclean2 As Label
    Friend WithEvents lblsclean2 As Label
    Friend WithEvents lblfclean1 As Label
    Friend WithEvents lblsclean1 As Label
    Friend WithEvents Butstartclean3 As Button
    Friend WithEvents Butstartclean2 As Button
    Friend WithEvents Butstartclean1 As Button
    Friend WithEvents LblFSieve2 As Label
    Friend WithEvents Clean3flash As Timer
    Friend WithEvents Clean2flash As Timer
    Friend WithEvents Clean1flash As Timer
    Friend WithEvents lbw As Label
End Class
