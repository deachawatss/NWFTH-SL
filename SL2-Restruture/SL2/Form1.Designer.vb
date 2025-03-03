<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SL2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SL2))
        Me.lblbatch = New System.Windows.Forms.Label()
        Me.lblbin = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Txtbatch = New System.Windows.Forms.TextBox()
        Me.txtrmbin = New System.Windows.Forms.TextBox()
        Me.Butstip = New System.Windows.Forms.Button()
        Me.Butftip = New System.Windows.Forms.Button()
        Me.Lblsblend = New System.Windows.Forms.Label()
        Me.lblfgbinid = New System.Windows.Forms.Label()
        Me.txtfgbin = New System.Windows.Forms.TextBox()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.Butsblend = New System.Windows.Forms.Button()
        Me.Lblftip = New System.Windows.Forms.Label()
        Me.Butfblend = New System.Windows.Forms.Button()
        Me.lblfblend = New System.Windows.Forms.Label()
        Me.Lblfgdesc = New System.Windows.Forms.Label()
        Me.Butbin1 = New System.Windows.Forms.Button()
        Me.Butbin2 = New System.Windows.Forms.Button()
        Me.Butbin3 = New System.Windows.Forms.Button()
        Me.Butbin4 = New System.Windows.Forms.Button()
        Me.Butbin5 = New System.Windows.Forms.Button()
        Me.Butbin6 = New System.Windows.Forms.Button()
        Me.stipflash = New System.Windows.Forms.Timer(Me.components)
        Me.LblFSieve2 = New System.Windows.Forms.Label()
        Me.ftipflash = New System.Windows.Forms.Timer(Me.components)
        Me.sblendflash = New System.Windows.Forms.Timer(Me.components)
        Me.fblendflash = New System.Windows.Forms.Timer(Me.components)
        Me.ButComplete = New System.Windows.Forms.Button()
        Me.Butbin00 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Butstartclean1 = New System.Windows.Forms.Button()
        Me.Butstartclean2 = New System.Windows.Forms.Button()
        Me.Butstartclean3 = New System.Windows.Forms.Button()
        Me.Clean1flash = New System.Windows.Forms.Timer(Me.components)
        Me.lblsclean1 = New System.Windows.Forms.Label()
        Me.lblfclean1 = New System.Windows.Forms.Label()
        Me.Lbldatabase = New System.Windows.Forms.Label()
        Me.Lblbatch2 = New System.Windows.Forms.Label()
        Me.Clean2flash = New System.Windows.Forms.Timer(Me.components)
        Me.Clean3flash = New System.Windows.Forms.Timer(Me.components)
        Me.lblsclean2 = New System.Windows.Forms.Label()
        Me.lblfclean2 = New System.Windows.Forms.Label()
        Me.lblsclean3 = New System.Windows.Forms.Label()
        Me.lblfclean3 = New System.Windows.Forms.Label()
        Me.ButFinishCleanContinue = New System.Windows.Forms.Button()
        Me.LblSSieve2 = New System.Windows.Forms.Label()
        Me.lblstip = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblbatch
        '
        Me.lblbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbatch.Location = New System.Drawing.Point(148, 12)
        Me.lblbatch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbatch.Name = "lblbatch"
        Me.lblbatch.Size = New System.Drawing.Size(129, 25)
        Me.lblbatch.TabIndex = 0
        Me.lblbatch.Text = "Batch Ticket"
        '
        'lblbin
        '
        Me.lblbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbin.Location = New System.Drawing.Point(148, 43)
        Me.lblbin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbin.Name = "lblbin"
        Me.lblbin.Size = New System.Drawing.Size(107, 25)
        Me.lblbin.TabIndex = 1
        Me.lblbin.Text = "RM Bin ID"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(19, 8)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(89, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Txtbatch
        '
        Me.Txtbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtbatch.Location = New System.Drawing.Point(281, 8)
        Me.Txtbatch.Margin = New System.Windows.Forms.Padding(2)
        Me.Txtbatch.Name = "Txtbatch"
        Me.Txtbatch.Size = New System.Drawing.Size(166, 31)
        Me.Txtbatch.TabIndex = 4
        '
        'txtrmbin
        '
        Me.txtrmbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrmbin.Location = New System.Drawing.Point(281, 41)
        Me.txtrmbin.Margin = New System.Windows.Forms.Padding(2)
        Me.txtrmbin.Name = "txtrmbin"
        Me.txtrmbin.Size = New System.Drawing.Size(166, 31)
        Me.txtrmbin.TabIndex = 5
        '
        'Butstip
        '
        Me.Butstip.Enabled = False
        Me.Butstip.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butstip.Location = New System.Drawing.Point(260, 95)
        Me.Butstip.Margin = New System.Windows.Forms.Padding(2)
        Me.Butstip.Name = "Butstip"
        Me.Butstip.Size = New System.Drawing.Size(189, 87)
        Me.Butstip.TabIndex = 6
        Me.Butstip.Text = "Start Tip"
        Me.Butstip.UseVisualStyleBackColor = True
        '
        'Butftip
        '
        Me.Butftip.Enabled = False
        Me.Butftip.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butftip.Location = New System.Drawing.Point(260, 192)
        Me.Butftip.Margin = New System.Windows.Forms.Padding(2)
        Me.Butftip.Name = "Butftip"
        Me.Butftip.Size = New System.Drawing.Size(189, 74)
        Me.Butftip.TabIndex = 7
        Me.Butftip.Text = "Finish Tip"
        Me.Butftip.UseVisualStyleBackColor = True
        '
        'Lblsblend
        '
        Me.Lblsblend.AutoSize = True
        Me.Lblsblend.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblsblend.Location = New System.Drawing.Point(485, 285)
        Me.Lblsblend.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lblsblend.Name = "Lblsblend"
        Me.Lblsblend.Size = New System.Drawing.Size(0, 42)
        Me.Lblsblend.TabIndex = 9
        '
        'lblfgbinid
        '
        Me.lblfgbinid.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfgbinid.Location = New System.Drawing.Point(233, 466)
        Me.lblfgbinid.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblfgbinid.Name = "lblfgbinid"
        Me.lblfgbinid.Size = New System.Drawing.Size(105, 25)
        Me.lblfgbinid.TabIndex = 10
        Me.lblfgbinid.Text = "FG Bin ID"
        '
        'txtfgbin
        '
        Me.txtfgbin.Enabled = False
        Me.txtfgbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfgbin.Location = New System.Drawing.Point(342, 463)
        Me.txtfgbin.Margin = New System.Windows.Forms.Padding(2)
        Me.txtfgbin.Name = "txtfgbin"
        Me.txtfgbin.Size = New System.Drawing.Size(89, 31)
        Me.txtfgbin.TabIndex = 11
        '
        'lblheading
        '
        Me.lblheading.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.Location = New System.Drawing.Point(15, 79)
        Me.lblheading.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(153, 19)
        Me.lblheading.TabIndex = 12
        Me.lblheading.Text = "Seasoning Blending"
        '
        'Butsblend
        '
        Me.Butsblend.Enabled = False
        Me.Butsblend.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butsblend.Location = New System.Drawing.Point(260, 273)
        Me.Butsblend.Margin = New System.Windows.Forms.Padding(2)
        Me.Butsblend.Name = "Butsblend"
        Me.Butsblend.Size = New System.Drawing.Size(189, 76)
        Me.Butsblend.TabIndex = 13
        Me.Butsblend.Text = "Start Blend"
        Me.Butsblend.UseVisualStyleBackColor = True
        '
        'Lblftip
        '
        Me.Lblftip.AutoSize = True
        Me.Lblftip.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblftip.Location = New System.Drawing.Point(484, 196)
        Me.Lblftip.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lblftip.Name = "Lblftip"
        Me.Lblftip.Size = New System.Drawing.Size(0, 42)
        Me.Lblftip.TabIndex = 14
        '
        'Butfblend
        '
        Me.Butfblend.Enabled = False
        Me.Butfblend.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butfblend.Location = New System.Drawing.Point(260, 367)
        Me.Butfblend.Margin = New System.Windows.Forms.Padding(1)
        Me.Butfblend.Name = "Butfblend"
        Me.Butfblend.Size = New System.Drawing.Size(189, 87)
        Me.Butfblend.TabIndex = 15
        Me.Butfblend.Text = "Finish Blend"
        Me.Butfblend.UseVisualStyleBackColor = True
        '
        'lblfblend
        '
        Me.lblfblend.AutoSize = True
        Me.lblfblend.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfblend.Location = New System.Drawing.Point(483, 384)
        Me.lblfblend.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblfblend.Name = "lblfblend"
        Me.lblfblend.Size = New System.Drawing.Size(0, 44)
        Me.lblfblend.TabIndex = 16
        '
        'Lblfgdesc
        '
        Me.Lblfgdesc.AutoSize = True
        Me.Lblfgdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblfgdesc.Location = New System.Drawing.Point(718, 59)
        Me.Lblfgdesc.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lblfgdesc.Name = "Lblfgdesc"
        Me.Lblfgdesc.Size = New System.Drawing.Size(0, 26)
        Me.Lblfgdesc.TabIndex = 17
        '
        'Butbin1
        '
        Me.Butbin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin1.Location = New System.Drawing.Point(21, 136)
        Me.Butbin1.Margin = New System.Windows.Forms.Padding(1)
        Me.Butbin1.Name = "Butbin1"
        Me.Butbin1.Size = New System.Drawing.Size(94, 79)
        Me.Butbin1.TabIndex = 18
        Me.Butbin1.Text = "01"
        Me.Butbin1.UseVisualStyleBackColor = True
        Me.Butbin1.Visible = False
        '
        'Butbin2
        '
        Me.Butbin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin2.Location = New System.Drawing.Point(127, 136)
        Me.Butbin2.Margin = New System.Windows.Forms.Padding(1)
        Me.Butbin2.Name = "Butbin2"
        Me.Butbin2.Size = New System.Drawing.Size(96, 79)
        Me.Butbin2.TabIndex = 19
        Me.Butbin2.Text = "02"
        Me.Butbin2.UseVisualStyleBackColor = True
        Me.Butbin2.Visible = False
        '
        'Butbin3
        '
        Me.Butbin3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin3.Location = New System.Drawing.Point(21, 220)
        Me.Butbin3.Margin = New System.Windows.Forms.Padding(1)
        Me.Butbin3.Name = "Butbin3"
        Me.Butbin3.Size = New System.Drawing.Size(94, 88)
        Me.Butbin3.TabIndex = 20
        Me.Butbin3.Text = "03"
        Me.Butbin3.UseVisualStyleBackColor = True
        Me.Butbin3.Visible = False
        '
        'Butbin4
        '
        Me.Butbin4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin4.Location = New System.Drawing.Point(127, 220)
        Me.Butbin4.Margin = New System.Windows.Forms.Padding(1)
        Me.Butbin4.Name = "Butbin4"
        Me.Butbin4.Size = New System.Drawing.Size(95, 88)
        Me.Butbin4.TabIndex = 21
        Me.Butbin4.Text = "04"
        Me.Butbin4.UseVisualStyleBackColor = True
        Me.Butbin4.Visible = False
        '
        'Butbin5
        '
        Me.Butbin5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin5.Location = New System.Drawing.Point(21, 313)
        Me.Butbin5.Margin = New System.Windows.Forms.Padding(1)
        Me.Butbin5.Name = "Butbin5"
        Me.Butbin5.Size = New System.Drawing.Size(95, 91)
        Me.Butbin5.TabIndex = 22
        Me.Butbin5.Text = "05"
        Me.Butbin5.UseVisualStyleBackColor = True
        Me.Butbin5.Visible = False
        '
        'Butbin6
        '
        Me.Butbin6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin6.Location = New System.Drawing.Point(126, 313)
        Me.Butbin6.Margin = New System.Windows.Forms.Padding(1)
        Me.Butbin6.Name = "Butbin6"
        Me.Butbin6.Size = New System.Drawing.Size(97, 91)
        Me.Butbin6.TabIndex = 23
        Me.Butbin6.Text = "06"
        Me.Butbin6.UseVisualStyleBackColor = True
        Me.Butbin6.Visible = False
        '
        'stipflash
        '
        Me.stipflash.Enabled = True
        Me.stipflash.Interval = 300
        '
        'LblFSieve2
        '
        Me.LblFSieve2.AutoSize = True
        Me.LblFSieve2.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFSieve2.Location = New System.Drawing.Point(785, 128)
        Me.LblFSieve2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblFSieve2.Name = "LblFSieve2"
        Me.LblFSieve2.Size = New System.Drawing.Size(0, 44)
        Me.LblFSieve2.TabIndex = 27
        '
        'ftipflash
        '
        Me.ftipflash.Enabled = True
        Me.ftipflash.Interval = 300
        '
        'sblendflash
        '
        Me.sblendflash.Enabled = True
        Me.sblendflash.Interval = 300
        '
        'fblendflash
        '
        Me.fblendflash.Enabled = True
        Me.fblendflash.Interval = 300
        '
        'ButComplete
        '
        Me.ButComplete.Enabled = False
        Me.ButComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButComplete.Location = New System.Drawing.Point(260, 529)
        Me.ButComplete.Margin = New System.Windows.Forms.Padding(2)
        Me.ButComplete.Name = "ButComplete"
        Me.ButComplete.Size = New System.Drawing.Size(189, 121)
        Me.ButComplete.TabIndex = 30
        Me.ButComplete.Text = "Blend Complete"
        Me.ButComplete.UseVisualStyleBackColor = True
        '
        'Butbin00
        '
        Me.Butbin00.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbin00.Location = New System.Drawing.Point(20, 409)
        Me.Butbin00.Margin = New System.Windows.Forms.Padding(2)
        Me.Butbin00.Name = "Butbin00"
        Me.Butbin00.Size = New System.Drawing.Size(202, 108)
        Me.Butbin00.TabIndex = 31
        Me.Butbin00.Text = "00"
        Me.Butbin00.UseVisualStyleBackColor = True
        Me.Butbin00.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(111, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "v1.4"
        Me.Label1.UseMnemonic = False
        '
        'Butstartclean1
        '
        Me.Butstartclean1.Image = CType(resources.GetObject("Butstartclean1.Image"), System.Drawing.Image)
        Me.Butstartclean1.Location = New System.Drawing.Point(703, 107)
        Me.Butstartclean1.Margin = New System.Windows.Forms.Padding(2)
        Me.Butstartclean1.Name = "Butstartclean1"
        Me.Butstartclean1.Size = New System.Drawing.Size(200, 90)
        Me.Butstartclean1.TabIndex = 33
        Me.Butstartclean1.UseVisualStyleBackColor = True
        '
        'Butstartclean2
        '
        Me.Butstartclean2.Image = CType(resources.GetObject("Butstartclean2.Image"), System.Drawing.Image)
        Me.Butstartclean2.Location = New System.Drawing.Point(703, 196)
        Me.Butstartclean2.Margin = New System.Windows.Forms.Padding(2)
        Me.Butstartclean2.Name = "Butstartclean2"
        Me.Butstartclean2.Size = New System.Drawing.Size(200, 90)
        Me.Butstartclean2.TabIndex = 34
        Me.Butstartclean2.UseVisualStyleBackColor = True
        '
        'Butstartclean3
        '
        Me.Butstartclean3.Image = CType(resources.GetObject("Butstartclean3.Image"), System.Drawing.Image)
        Me.Butstartclean3.Location = New System.Drawing.Point(703, 285)
        Me.Butstartclean3.Margin = New System.Windows.Forms.Padding(2)
        Me.Butstartclean3.Name = "Butstartclean3"
        Me.Butstartclean3.Size = New System.Drawing.Size(200, 90)
        Me.Butstartclean3.TabIndex = 35
        Me.Butstartclean3.UseVisualStyleBackColor = True
        '
        'Clean1flash
        '
        '
        'lblsclean1
        '
        Me.lblsclean1.AutoSize = True
        Me.lblsclean1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean1.Location = New System.Drawing.Point(928, 128)
        Me.lblsclean1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblsclean1.Name = "lblsclean1"
        Me.lblsclean1.Size = New System.Drawing.Size(0, 31)
        Me.lblsclean1.TabIndex = 36
        '
        'lblfclean1
        '
        Me.lblfclean1.AutoSize = True
        Me.lblfclean1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean1.Location = New System.Drawing.Point(928, 158)
        Me.lblfclean1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblfclean1.Name = "lblfclean1"
        Me.lblfclean1.Size = New System.Drawing.Size(0, 31)
        Me.lblfclean1.TabIndex = 37
        '
        'Lbldatabase
        '
        Me.Lbldatabase.AutoSize = True
        Me.Lbldatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbldatabase.Location = New System.Drawing.Point(17, 69)
        Me.Lbldatabase.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbldatabase.Name = "Lbldatabase"
        Me.Lbldatabase.Size = New System.Drawing.Size(0, 7)
        Me.Lbldatabase.TabIndex = 38
        '
        'Lblbatch2
        '
        Me.Lblbatch2.AutoSize = True
        Me.Lblbatch2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbatch2.Location = New System.Drawing.Point(504, 79)
        Me.Lblbatch2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lblbatch2.Name = "Lblbatch2"
        Me.Lblbatch2.Size = New System.Drawing.Size(0, 37)
        Me.Lblbatch2.TabIndex = 39
        '
        'Clean2flash
        '
        '
        'Clean3flash
        '
        '
        'lblsclean2
        '
        Me.lblsclean2.AutoSize = True
        Me.lblsclean2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean2.Location = New System.Drawing.Point(928, 211)
        Me.lblsclean2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblsclean2.Name = "lblsclean2"
        Me.lblsclean2.Size = New System.Drawing.Size(0, 31)
        Me.lblsclean2.TabIndex = 40
        '
        'lblfclean2
        '
        Me.lblfclean2.AutoSize = True
        Me.lblfclean2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean2.Location = New System.Drawing.Point(928, 242)
        Me.lblfclean2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblfclean2.Name = "lblfclean2"
        Me.lblfclean2.Size = New System.Drawing.Size(0, 31)
        Me.lblfclean2.TabIndex = 41
        '
        'lblsclean3
        '
        Me.lblsclean3.AutoSize = True
        Me.lblsclean3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean3.Location = New System.Drawing.Point(928, 296)
        Me.lblsclean3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblsclean3.Name = "lblsclean3"
        Me.lblsclean3.Size = New System.Drawing.Size(0, 31)
        Me.lblsclean3.TabIndex = 42
        '
        'lblfclean3
        '
        Me.lblfclean3.AutoSize = True
        Me.lblfclean3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean3.Location = New System.Drawing.Point(928, 328)
        Me.lblfclean3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblfclean3.Name = "lblfclean3"
        Me.lblfclean3.Size = New System.Drawing.Size(0, 31)
        Me.lblfclean3.TabIndex = 43
        '
        'ButFinishCleanContinue
        '
        Me.ButFinishCleanContinue.AutoSize = True
        Me.ButFinishCleanContinue.Enabled = False
        Me.ButFinishCleanContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButFinishCleanContinue.Location = New System.Drawing.Point(647, 382)
        Me.ButFinishCleanContinue.Margin = New System.Windows.Forms.Padding(1)
        Me.ButFinishCleanContinue.Name = "ButFinishCleanContinue"
        Me.ButFinishCleanContinue.Size = New System.Drawing.Size(325, 76)
        Me.ButFinishCleanContinue.TabIndex = 44
        Me.ButFinishCleanContinue.Text = "Finish Clean"
        Me.ButFinishCleanContinue.UseVisualStyleBackColor = True
        '
        'LblSSieve2
        '
        Me.LblSSieve2.AutoSize = True
        Me.LblSSieve2.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSSieve2.Location = New System.Drawing.Point(518, 511)
        Me.LblSSieve2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSSieve2.Name = "LblSSieve2"
        Me.LblSSieve2.Size = New System.Drawing.Size(0, 44)
        Me.LblSSieve2.TabIndex = 26
        '
        'lblstip
        '
        Me.lblstip.AutoSize = True
        Me.lblstip.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstip.Location = New System.Drawing.Point(485, 113)
        Me.lblstip.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblstip.Name = "lblstip"
        Me.lblstip.Size = New System.Drawing.Size(0, 42)
        Me.lblstip.TabIndex = 8
        '
        'SL2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1277, 761)
        Me.Controls.Add(Me.ButFinishCleanContinue)
        Me.Controls.Add(Me.lblfclean3)
        Me.Controls.Add(Me.lblsclean3)
        Me.Controls.Add(Me.lblfclean2)
        Me.Controls.Add(Me.lblsclean2)
        Me.Controls.Add(Me.Lblbatch2)
        Me.Controls.Add(Me.Lbldatabase)
        Me.Controls.Add(Me.lblfclean1)
        Me.Controls.Add(Me.lblsclean1)
        Me.Controls.Add(Me.Butstartclean3)
        Me.Controls.Add(Me.Butstartclean2)
        Me.Controls.Add(Me.Butstartclean1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Butbin00)
        Me.Controls.Add(Me.ButComplete)
        Me.Controls.Add(Me.LblFSieve2)
        Me.Controls.Add(Me.LblSSieve2)
        Me.Controls.Add(Me.Butbin6)
        Me.Controls.Add(Me.Butbin5)
        Me.Controls.Add(Me.Butbin4)
        Me.Controls.Add(Me.Butbin3)
        Me.Controls.Add(Me.Butbin2)
        Me.Controls.Add(Me.Butbin1)
        Me.Controls.Add(Me.Lblfgdesc)
        Me.Controls.Add(Me.lblfblend)
        Me.Controls.Add(Me.Butfblend)
        Me.Controls.Add(Me.Lblftip)
        Me.Controls.Add(Me.Butsblend)
        Me.Controls.Add(Me.lblheading)
        Me.Controls.Add(Me.txtfgbin)
        Me.Controls.Add(Me.lblfgbinid)
        Me.Controls.Add(Me.Lblsblend)
        Me.Controls.Add(Me.lblstip)
        Me.Controls.Add(Me.Butftip)
        Me.Controls.Add(Me.Butstip)
        Me.Controls.Add(Me.txtrmbin)
        Me.Controls.Add(Me.Txtbatch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblbin)
        Me.Controls.Add(Me.lblbatch)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SL2"
        Me.Text = "SL2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblbatch As Label
    Friend WithEvents lblbin As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Txtbatch As TextBox
    Friend WithEvents txtrmbin As TextBox
    Friend WithEvents Butstip As Button
    Friend WithEvents Butftip As Button
    Friend WithEvents Lblsblend As Label
    Friend WithEvents lblfgbinid As Label
    Friend WithEvents txtfgbin As TextBox
    Friend WithEvents lblheading As Label
    Friend WithEvents Butsblend As Button
    Friend WithEvents Lblftip As Label
    Friend WithEvents Butfblend As Button
    Friend WithEvents lblfblend As Label
    Friend WithEvents Lblfgdesc As Label
    Friend WithEvents Butbin1 As Button
    Friend WithEvents Butbin2 As Button
    Friend WithEvents Butbin3 As Button
    Friend WithEvents Butbin4 As Button
    Friend WithEvents Butbin5 As Button
    Friend WithEvents Butbin6 As Button
    Friend WithEvents stipflash As Timer
    Friend WithEvents LblFSieve2 As Label
    Friend WithEvents ftipflash As Timer
    Friend WithEvents sblendflash As Timer
    Friend WithEvents fblendflash As Timer
    Friend WithEvents ButComplete As Button
    Friend WithEvents Butbin00 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Butstartclean1 As Button
    Friend WithEvents Butstartclean2 As Button
    Friend WithEvents Butstartclean3 As Button
    Friend WithEvents Clean1flash As Timer
    Friend WithEvents lblsclean1 As Label
    Friend WithEvents lblfclean1 As Label
    Friend WithEvents Lbldatabase As Label
    Friend WithEvents Lblbatch2 As Label
    Friend WithEvents Clean2flash As Timer
    Friend WithEvents Clean3flash As Timer
    Friend WithEvents lblsclean2 As Label
    Friend WithEvents lblfclean2 As Label
    Friend WithEvents lblsclean3 As Label
    Friend WithEvents lblfclean3 As Label
    Friend WithEvents ButFinishCleanContinue As Button
    Friend WithEvents LblSSieve2 As Label
    Friend WithEvents lblstip As Label
End Class
