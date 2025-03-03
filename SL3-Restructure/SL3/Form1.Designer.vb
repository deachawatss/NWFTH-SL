<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SL3))
        Me.butstart = New System.Windows.Forms.Button()
        Me.butfinish = New System.Windows.Forms.Button()
        Me.txtbatch = New System.Windows.Forms.TextBox()
        Me.txtfgbin = New System.Windows.Forms.TextBox()
        Me.lblbatch = New System.Windows.Forms.Label()
        Me.lblbin = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblstart = New System.Windows.Forms.Label()
        Me.lblfinish = New System.Windows.Forms.Label()
        Me.txtbagsize = New System.Windows.Forms.TextBox()
        Me.txtfullbags = New System.Windows.Forms.TextBox()
        Me.txtpartbags = New System.Windows.Forms.TextBox()
        Me.lblbagsize = New System.Windows.Forms.Label()
        Me.lblfullbags = New System.Windows.Forms.Label()
        Me.lblpartbags = New System.Windows.Forms.Label()
        Me.Butbatchcomp = New System.Windows.Forms.Button()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.lblibckg = New System.Windows.Forms.Label()
        Me.txtibckg = New System.Windows.Forms.TextBox()
        Me.lblfgdesc = New System.Windows.Forms.Label()
        Me.Butbin1 = New System.Windows.Forms.Button()
        Me.Butbin2 = New System.Windows.Forms.Button()
        Me.Butbin3 = New System.Windows.Forms.Button()
        Me.Butbin4 = New System.Windows.Forms.Button()
        Me.Butbin5 = New System.Windows.Forms.Button()
        Me.Butbin6 = New System.Windows.Forms.Button()
        Me.Startflash = New System.Windows.Forms.Timer(Me.components)
        Me.Finishflash = New System.Windows.Forms.Timer(Me.components)
        Me.Butbin7 = New System.Windows.Forms.Button()
        Me.Butbin8 = New System.Windows.Forms.Button()
        Me.Butbin9 = New System.Windows.Forms.Button()
        Me.Butbin0 = New System.Windows.Forms.Button()
        Me.Butbinpoint = New System.Windows.Forms.Button()
        Me.Butbackspace = New System.Windows.Forms.Button()
        Me.Lblbatch2 = New System.Windows.Forms.Label()
        Me.Lblbagsize2 = New System.Windows.Forms.Label()
        Me.lblfullbags2 = New System.Windows.Forms.Label()
        Me.lblpartbags2 = New System.Windows.Forms.Label()
        Me.lblibckg2 = New System.Windows.Forms.Label()
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
        Me.Lblfbatch = New System.Windows.Forms.Label()
        Me.lblsbatch = New System.Windows.Forms.Label()
        Me.Clean1flash = New System.Windows.Forms.Timer(Me.components)
        Me.Clean2flash = New System.Windows.Forms.Timer(Me.components)
        Me.Clean3flash = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butstart
        '
        Me.butstart.Enabled = False
        Me.butstart.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butstart.Location = New System.Drawing.Point(353, 145)
        Me.butstart.Name = "butstart"
        Me.butstart.Size = New System.Drawing.Size(288, 204)
        Me.butstart.TabIndex = 0
        Me.butstart.Text = "Start Pack"
        Me.butstart.UseVisualStyleBackColor = True
        '
        'butfinish
        '
        Me.butfinish.Enabled = False
        Me.butfinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfinish.Location = New System.Drawing.Point(353, 352)
        Me.butfinish.Name = "butfinish"
        Me.butfinish.Size = New System.Drawing.Size(288, 200)
        Me.butfinish.TabIndex = 1
        Me.butfinish.Text = "Finish Pack"
        Me.butfinish.UseVisualStyleBackColor = True
        '
        'txtbatch
        '
        Me.txtbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbatch.Location = New System.Drawing.Point(398, 56)
        Me.txtbatch.Name = "txtbatch"
        Me.txtbatch.Size = New System.Drawing.Size(243, 43)
        Me.txtbatch.TabIndex = 2
        '
        'txtfgbin
        '
        Me.txtfgbin.Enabled = False
        Me.txtfgbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfgbin.Location = New System.Drawing.Point(398, 98)
        Me.txtfgbin.Name = "txtfgbin"
        Me.txtfgbin.Size = New System.Drawing.Size(243, 43)
        Me.txtfgbin.TabIndex = 3
        '
        'lblbatch
        '
        Me.lblbatch.AutoSize = True
        Me.lblbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbatch.Location = New System.Drawing.Point(210, 62)
        Me.lblbatch.Name = "lblbatch"
        Me.lblbatch.Size = New System.Drawing.Size(193, 37)
        Me.lblbatch.TabIndex = 4
        Me.lblbatch.Text = "Batch Ticket"
        '
        'lblbin
        '
        Me.lblbin.AutoSize = True
        Me.lblbin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbin.Location = New System.Drawing.Point(210, 102)
        Me.lblbin.Name = "lblbin"
        Me.lblbin.Size = New System.Drawing.Size(157, 37)
        Me.lblbin.TabIndex = 5
        Me.lblbin.Text = "FG Bin ID"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(23, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(135, 90)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'lblstart
        '
        Me.lblstart.AutoSize = True
        Me.lblstart.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstart.Location = New System.Drawing.Point(673, 220)
        Me.lblstart.Name = "lblstart"
        Me.lblstart.Size = New System.Drawing.Size(0, 55)
        Me.lblstart.TabIndex = 7
        '
        'lblfinish
        '
        Me.lblfinish.AutoSize = True
        Me.lblfinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinish.Location = New System.Drawing.Point(674, 418)
        Me.lblfinish.Name = "lblfinish"
        Me.lblfinish.Size = New System.Drawing.Size(0, 55)
        Me.lblfinish.TabIndex = 8
        '
        'txtbagsize
        '
        Me.txtbagsize.Enabled = False
        Me.txtbagsize.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbagsize.Location = New System.Drawing.Point(549, 569)
        Me.txtbagsize.Name = "txtbagsize"
        Me.txtbagsize.Size = New System.Drawing.Size(92, 43)
        Me.txtbagsize.TabIndex = 9
        '
        'txtfullbags
        '
        Me.txtfullbags.Enabled = False
        Me.txtfullbags.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfullbags.Location = New System.Drawing.Point(549, 649)
        Me.txtfullbags.Name = "txtfullbags"
        Me.txtfullbags.Size = New System.Drawing.Size(92, 43)
        Me.txtfullbags.TabIndex = 10
        '
        'txtpartbags
        '
        Me.txtpartbags.Enabled = False
        Me.txtpartbags.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpartbags.Location = New System.Drawing.Point(549, 730)
        Me.txtpartbags.Name = "txtpartbags"
        Me.txtpartbags.Size = New System.Drawing.Size(92, 43)
        Me.txtpartbags.TabIndex = 11
        '
        'lblbagsize
        '
        Me.lblbagsize.AutoSize = True
        Me.lblbagsize.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbagsize.Location = New System.Drawing.Point(353, 575)
        Me.lblbagsize.Name = "lblbagsize"
        Me.lblbagsize.Size = New System.Drawing.Size(144, 37)
        Me.lblbagsize.TabIndex = 12
        Me.lblbagsize.Text = "Bag Size"
        '
        'lblfullbags
        '
        Me.lblfullbags.AutoSize = True
        Me.lblfullbags.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfullbags.Location = New System.Drawing.Point(353, 655)
        Me.lblfullbags.Name = "lblfullbags"
        Me.lblfullbags.Size = New System.Drawing.Size(151, 37)
        Me.lblfullbags.TabIndex = 13
        Me.lblfullbags.Text = "Full Bags"
        '
        'lblpartbags
        '
        Me.lblpartbags.AutoSize = True
        Me.lblpartbags.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpartbags.Location = New System.Drawing.Point(353, 733)
        Me.lblpartbags.Name = "lblpartbags"
        Me.lblpartbags.Size = New System.Drawing.Size(158, 37)
        Me.lblpartbags.TabIndex = 14
        Me.lblpartbags.Text = "Part Bags"
        '
        'Butbatchcomp
        '
        Me.Butbatchcomp.Enabled = False
        Me.Butbatchcomp.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butbatchcomp.Location = New System.Drawing.Point(783, 569)
        Me.Butbatchcomp.Name = "Butbatchcomp"
        Me.Butbatchcomp.Size = New System.Drawing.Size(372, 282)
        Me.Butbatchcomp.TabIndex = 15
        Me.Butbatchcomp.Text = "Pack Complete"
        Me.Butbatchcomp.UseVisualStyleBackColor = True
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.Location = New System.Drawing.Point(19, 107)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(220, 29)
        Me.lblheading.TabIndex = 16
        Me.lblheading.Text = "Seasoning Packing"
        '
        'lblibckg
        '
        Me.lblibckg.AutoSize = True
        Me.lblibckg.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblibckg.Location = New System.Drawing.Point(353, 811)
        Me.lblibckg.Name = "lblibckg"
        Me.lblibckg.Size = New System.Drawing.Size(124, 37)
        Me.lblibckg.TabIndex = 17
        Me.lblibckg.Text = "IBC KG"
        '
        'txtibckg
        '
        Me.txtibckg.Enabled = False
        Me.txtibckg.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtibckg.Location = New System.Drawing.Point(549, 808)
        Me.txtibckg.Name = "txtibckg"
        Me.txtibckg.Size = New System.Drawing.Size(92, 43)
        Me.txtibckg.TabIndex = 18
        '
        'lblfgdesc
        '
        Me.lblfgdesc.AutoSize = True
        Me.lblfgdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfgdesc.Location = New System.Drawing.Point(875, 63)
        Me.lblfgdesc.Name = "lblfgdesc"
        Me.lblfgdesc.Size = New System.Drawing.Size(0, 40)
        Me.lblfgdesc.TabIndex = 19
        '
        'Butbin1
        '
        Me.Butbin1.Enabled = False
        Me.Butbin1.Location = New System.Drawing.Point(23, 139)
        Me.Butbin1.Name = "Butbin1"
        Me.Butbin1.Size = New System.Drawing.Size(140, 140)
        Me.Butbin1.TabIndex = 20
        Me.Butbin1.Text = "1"
        Me.Butbin1.UseVisualStyleBackColor = True
        '
        'Butbin2
        '
        Me.Butbin2.Enabled = False
        Me.Butbin2.Location = New System.Drawing.Point(174, 139)
        Me.Butbin2.Name = "Butbin2"
        Me.Butbin2.Size = New System.Drawing.Size(140, 140)
        Me.Butbin2.TabIndex = 21
        Me.Butbin2.Text = "2"
        Me.Butbin2.UseVisualStyleBackColor = True
        '
        'Butbin3
        '
        Me.Butbin3.Enabled = False
        Me.Butbin3.Location = New System.Drawing.Point(24, 285)
        Me.Butbin3.Name = "Butbin3"
        Me.Butbin3.Size = New System.Drawing.Size(140, 140)
        Me.Butbin3.TabIndex = 22
        Me.Butbin3.Text = "3"
        Me.Butbin3.UseVisualStyleBackColor = True
        '
        'Butbin4
        '
        Me.Butbin4.Enabled = False
        Me.Butbin4.Location = New System.Drawing.Point(174, 285)
        Me.Butbin4.Name = "Butbin4"
        Me.Butbin4.Size = New System.Drawing.Size(140, 140)
        Me.Butbin4.TabIndex = 23
        Me.Butbin4.Text = "4"
        Me.Butbin4.UseVisualStyleBackColor = True
        '
        'Butbin5
        '
        Me.Butbin5.Enabled = False
        Me.Butbin5.Location = New System.Drawing.Point(24, 431)
        Me.Butbin5.Name = "Butbin5"
        Me.Butbin5.Size = New System.Drawing.Size(140, 140)
        Me.Butbin5.TabIndex = 24
        Me.Butbin5.Text = "5"
        Me.Butbin5.UseVisualStyleBackColor = True
        '
        'Butbin6
        '
        Me.Butbin6.Enabled = False
        Me.Butbin6.Location = New System.Drawing.Point(174, 431)
        Me.Butbin6.Name = "Butbin6"
        Me.Butbin6.Size = New System.Drawing.Size(140, 140)
        Me.Butbin6.TabIndex = 25
        Me.Butbin6.Text = "6"
        Me.Butbin6.UseVisualStyleBackColor = True
        '
        'Startflash
        '
        Me.Startflash.Enabled = True
        Me.Startflash.Interval = 300
        '
        'Finishflash
        '
        Me.Finishflash.Enabled = True
        Me.Finishflash.Interval = 300
        '
        'Butbin7
        '
        Me.Butbin7.Enabled = False
        Me.Butbin7.Location = New System.Drawing.Point(24, 577)
        Me.Butbin7.Name = "Butbin7"
        Me.Butbin7.Size = New System.Drawing.Size(140, 140)
        Me.Butbin7.TabIndex = 26
        Me.Butbin7.Text = "7"
        Me.Butbin7.UseVisualStyleBackColor = True
        Me.Butbin7.Visible = False
        '
        'Butbin8
        '
        Me.Butbin8.Enabled = False
        Me.Butbin8.Location = New System.Drawing.Point(174, 577)
        Me.Butbin8.Name = "Butbin8"
        Me.Butbin8.Size = New System.Drawing.Size(140, 140)
        Me.Butbin8.TabIndex = 27
        Me.Butbin8.Text = "8"
        Me.Butbin8.UseVisualStyleBackColor = True
        Me.Butbin8.Visible = False
        '
        'Butbin9
        '
        Me.Butbin9.Enabled = False
        Me.Butbin9.Location = New System.Drawing.Point(24, 723)
        Me.Butbin9.Name = "Butbin9"
        Me.Butbin9.Size = New System.Drawing.Size(140, 140)
        Me.Butbin9.TabIndex = 28
        Me.Butbin9.Text = "9"
        Me.Butbin9.UseVisualStyleBackColor = True
        Me.Butbin9.Visible = False
        '
        'Butbin0
        '
        Me.Butbin0.Enabled = False
        Me.Butbin0.Location = New System.Drawing.Point(174, 723)
        Me.Butbin0.Name = "Butbin0"
        Me.Butbin0.Size = New System.Drawing.Size(140, 140)
        Me.Butbin0.TabIndex = 29
        Me.Butbin0.Text = "0"
        Me.Butbin0.UseVisualStyleBackColor = True
        Me.Butbin0.Visible = False
        '
        'Butbinpoint
        '
        Me.Butbinpoint.Enabled = False
        Me.Butbinpoint.Location = New System.Drawing.Point(24, 869)
        Me.Butbinpoint.Name = "Butbinpoint"
        Me.Butbinpoint.Size = New System.Drawing.Size(140, 140)
        Me.Butbinpoint.TabIndex = 30
        Me.Butbinpoint.Text = "."
        Me.Butbinpoint.UseVisualStyleBackColor = True
        Me.Butbinpoint.Visible = False
        '
        'Butbackspace
        '
        Me.Butbackspace.Enabled = False
        Me.Butbackspace.Location = New System.Drawing.Point(174, 869)
        Me.Butbackspace.Name = "Butbackspace"
        Me.Butbackspace.Size = New System.Drawing.Size(140, 140)
        Me.Butbackspace.TabIndex = 31
        Me.Butbackspace.Text = "Backspace"
        Me.Butbackspace.UseVisualStyleBackColor = True
        Me.Butbackspace.Visible = False
        '
        'Lblbatch2
        '
        Me.Lblbatch2.AutoSize = True
        Me.Lblbatch2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbatch2.Location = New System.Drawing.Point(699, 119)
        Me.Lblbatch2.Name = "Lblbatch2"
        Me.Lblbatch2.Size = New System.Drawing.Size(0, 55)
        Me.Lblbatch2.TabIndex = 32
        '
        'Lblbagsize2
        '
        Me.Lblbagsize2.AutoSize = True
        Me.Lblbagsize2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbagsize2.Location = New System.Drawing.Point(666, 575)
        Me.Lblbagsize2.Name = "Lblbagsize2"
        Me.Lblbagsize2.Size = New System.Drawing.Size(111, 37)
        Me.Lblbagsize2.TabIndex = 33
        Me.Lblbagsize2.Text = "Label1"
        '
        'lblfullbags2
        '
        Me.lblfullbags2.AutoSize = True
        Me.lblfullbags2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfullbags2.Location = New System.Drawing.Point(666, 655)
        Me.lblfullbags2.Name = "lblfullbags2"
        Me.lblfullbags2.Size = New System.Drawing.Size(111, 37)
        Me.lblfullbags2.TabIndex = 34
        Me.lblfullbags2.Text = "Label1"
        '
        'lblpartbags2
        '
        Me.lblpartbags2.AutoSize = True
        Me.lblpartbags2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpartbags2.Location = New System.Drawing.Point(666, 733)
        Me.lblpartbags2.Name = "lblpartbags2"
        Me.lblpartbags2.Size = New System.Drawing.Size(111, 37)
        Me.lblpartbags2.TabIndex = 35
        Me.lblpartbags2.Text = "Label1"
        '
        'lblibckg2
        '
        Me.lblibckg2.AutoSize = True
        Me.lblibckg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblibckg2.Location = New System.Drawing.Point(666, 811)
        Me.lblibckg2.Name = "lblibckg2"
        Me.lblibckg2.Size = New System.Drawing.Size(111, 37)
        Me.lblibckg2.TabIndex = 36
        Me.lblibckg2.Text = "Label1"
        '
        'ButFinishCleanContinue
        '
        Me.ButFinishCleanContinue.AutoSize = True
        Me.ButFinishCleanContinue.Enabled = False
        Me.ButFinishCleanContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButFinishCleanContinue.Location = New System.Drawing.Point(830, 418)
        Me.ButFinishCleanContinue.Margin = New System.Windows.Forms.Padding(2)
        Me.ButFinishCleanContinue.Name = "ButFinishCleanContinue"
        Me.ButFinishCleanContinue.Size = New System.Drawing.Size(325, 76)
        Me.ButFinishCleanContinue.TabIndex = 72
        Me.ButFinishCleanContinue.Text = "Finish Clean"
        Me.ButFinishCleanContinue.UseVisualStyleBackColor = True
        '
        'lblfclean3
        '
        Me.lblfclean3.AutoSize = True
        Me.lblfclean3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean3.Location = New System.Drawing.Point(1085, 344)
        Me.lblfclean3.Name = "lblfclean3"
        Me.lblfclean3.Size = New System.Drawing.Size(0, 46)
        Me.lblfclean3.TabIndex = 71
        '
        'lblsclean3
        '
        Me.lblsclean3.AutoSize = True
        Me.lblsclean3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean3.Location = New System.Drawing.Point(1085, 313)
        Me.lblsclean3.Name = "lblsclean3"
        Me.lblsclean3.Size = New System.Drawing.Size(0, 46)
        Me.lblsclean3.TabIndex = 70
        '
        'lblfclean2
        '
        Me.lblfclean2.AutoSize = True
        Me.lblfclean2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean2.Location = New System.Drawing.Point(1085, 254)
        Me.lblfclean2.Name = "lblfclean2"
        Me.lblfclean2.Size = New System.Drawing.Size(0, 46)
        Me.lblfclean2.TabIndex = 69
        '
        'lblsclean2
        '
        Me.lblsclean2.AutoSize = True
        Me.lblsclean2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean2.Location = New System.Drawing.Point(1085, 225)
        Me.lblsclean2.Name = "lblsclean2"
        Me.lblsclean2.Size = New System.Drawing.Size(0, 46)
        Me.lblsclean2.TabIndex = 68
        '
        'lblfclean1
        '
        Me.lblfclean1.AutoSize = True
        Me.lblfclean1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfclean1.Location = New System.Drawing.Point(1085, 177)
        Me.lblfclean1.Name = "lblfclean1"
        Me.lblfclean1.Size = New System.Drawing.Size(0, 46)
        Me.lblfclean1.TabIndex = 67
        '
        'lblsclean1
        '
        Me.lblsclean1.AutoSize = True
        Me.lblsclean1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsclean1.Location = New System.Drawing.Point(1085, 143)
        Me.lblsclean1.Name = "lblsclean1"
        Me.lblsclean1.Size = New System.Drawing.Size(0, 46)
        Me.lblsclean1.TabIndex = 66
        '
        'Butstartclean3
        '
        Me.Butstartclean3.Image = CType(resources.GetObject("Butstartclean3.Image"), System.Drawing.Image)
        Me.Butstartclean3.Location = New System.Drawing.Point(868, 301)
        Me.Butstartclean3.Name = "Butstartclean3"
        Me.Butstartclean3.Size = New System.Drawing.Size(200, 90)
        Me.Butstartclean3.TabIndex = 65
        Me.Butstartclean3.UseVisualStyleBackColor = True
        '
        'Butstartclean2
        '
        Me.Butstartclean2.Image = CType(resources.GetObject("Butstartclean2.Image"), System.Drawing.Image)
        Me.Butstartclean2.Location = New System.Drawing.Point(868, 220)
        Me.Butstartclean2.Name = "Butstartclean2"
        Me.Butstartclean2.Size = New System.Drawing.Size(200, 90)
        Me.Butstartclean2.TabIndex = 64
        Me.Butstartclean2.UseVisualStyleBackColor = True
        '
        'Butstartclean1
        '
        Me.Butstartclean1.Image = CType(resources.GetObject("Butstartclean1.Image"), System.Drawing.Image)
        Me.Butstartclean1.Location = New System.Drawing.Point(868, 130)
        Me.Butstartclean1.Margin = New System.Windows.Forms.Padding(2)
        Me.Butstartclean1.Name = "Butstartclean1"
        Me.Butstartclean1.Size = New System.Drawing.Size(200, 90)
        Me.Butstartclean1.TabIndex = 63
        Me.Butstartclean1.UseVisualStyleBackColor = True
        '
        'Lblfbatch
        '
        Me.Lblfbatch.AutoSize = True
        Me.Lblfbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblfbatch.Location = New System.Drawing.Point(861, 483)
        Me.Lblfbatch.Name = "Lblfbatch"
        Me.Lblfbatch.Size = New System.Drawing.Size(0, 64)
        Me.Lblfbatch.TabIndex = 58
        '
        'lblsbatch
        '
        Me.lblsbatch.AutoSize = True
        Me.lblsbatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsbatch.Location = New System.Drawing.Point(837, 195)
        Me.lblsbatch.Name = "lblsbatch"
        Me.lblsbatch.Size = New System.Drawing.Size(0, 64)
        Me.lblsbatch.TabIndex = 57
        '
        'Clean1flash
        '
        '
        'Clean2flash
        '
        '
        'Clean3flash
        '
        '
        'SL3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1454, 903)
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
        Me.Controls.Add(Me.Lblfbatch)
        Me.Controls.Add(Me.lblsbatch)
        Me.Controls.Add(Me.lblibckg2)
        Me.Controls.Add(Me.lblpartbags2)
        Me.Controls.Add(Me.lblfullbags2)
        Me.Controls.Add(Me.Lblbagsize2)
        Me.Controls.Add(Me.Lblbatch2)
        Me.Controls.Add(Me.Butbackspace)
        Me.Controls.Add(Me.Butbinpoint)
        Me.Controls.Add(Me.Butbin0)
        Me.Controls.Add(Me.Butbin9)
        Me.Controls.Add(Me.Butbin8)
        Me.Controls.Add(Me.Butbin7)
        Me.Controls.Add(Me.Butbin6)
        Me.Controls.Add(Me.Butbin5)
        Me.Controls.Add(Me.Butbin4)
        Me.Controls.Add(Me.Butbin3)
        Me.Controls.Add(Me.Butbin2)
        Me.Controls.Add(Me.Butbin1)
        Me.Controls.Add(Me.lblfgdesc)
        Me.Controls.Add(Me.txtibckg)
        Me.Controls.Add(Me.lblibckg)
        Me.Controls.Add(Me.lblheading)
        Me.Controls.Add(Me.Butbatchcomp)
        Me.Controls.Add(Me.lblpartbags)
        Me.Controls.Add(Me.lblfullbags)
        Me.Controls.Add(Me.lblbagsize)
        Me.Controls.Add(Me.txtpartbags)
        Me.Controls.Add(Me.txtfullbags)
        Me.Controls.Add(Me.txtbagsize)
        Me.Controls.Add(Me.lblfinish)
        Me.Controls.Add(Me.lblstart)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblbin)
        Me.Controls.Add(Me.lblbatch)
        Me.Controls.Add(Me.txtfgbin)
        Me.Controls.Add(Me.txtbatch)
        Me.Controls.Add(Me.butfinish)
        Me.Controls.Add(Me.butstart)
        Me.Name = "SL3"
        Me.Text = "SL3"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents butstart As Button
    Friend WithEvents butfinish As Button
    Friend WithEvents txtbatch As TextBox
    Friend WithEvents txtfgbin As TextBox
    Friend WithEvents lblbatch As Label
    Friend WithEvents lblbin As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblstart As Label
    Friend WithEvents lblfinish As Label
    Friend WithEvents txtbagsize As TextBox
    Friend WithEvents txtfullbags As TextBox
    Friend WithEvents txtpartbags As TextBox
    Friend WithEvents lblbagsize As Label
    Friend WithEvents lblfullbags As Label
    Friend WithEvents lblpartbags As Label
    Friend WithEvents Butbatchcomp As Button
    Friend WithEvents lblheading As Label
    Friend WithEvents lblibckg As Label
    Friend WithEvents txtibckg As TextBox
    Friend WithEvents lblfgdesc As Label
    Friend WithEvents Butbin1 As Button
    Friend WithEvents Butbin2 As Button
    Friend WithEvents Butbin3 As Button
    Friend WithEvents Butbin4 As Button
    Friend WithEvents Butbin5 As Button
    Friend WithEvents Butbin6 As Button
    Friend WithEvents Startflash As Timer
    Friend WithEvents Finishflash As Timer
    Friend WithEvents Butbin7 As Button
    Friend WithEvents Butbin8 As Button
    Friend WithEvents Butbin9 As Button
    Friend WithEvents Butbin0 As Button
    Friend WithEvents Butbinpoint As Button
    Friend WithEvents Butbackspace As Button
    Friend WithEvents Lblbatch2 As Label
    Friend WithEvents Lblbagsize2 As Label
    Friend WithEvents lblfullbags2 As Label
    Friend WithEvents lblpartbags2 As Label
    Friend WithEvents lblibckg2 As Label
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
    Friend WithEvents Lblfbatch As Label
    Friend WithEvents lblsbatch As Label
    Friend WithEvents Clean1flash As Timer
    Friend WithEvents Clean2flash As Timer
    Friend WithEvents Clean3flash As Timer
End Class
