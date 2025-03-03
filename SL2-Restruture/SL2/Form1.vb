Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Net.Mail

Public Class SL2

#Region "----- Fields / Variables -----"

    ' Language and UI state
    Dim thailanguage As Integer = 1          ' 1 = Thai, otherwise English
    Dim closeok As String = "1"              ' "0" means the form should not close yet
    Dim flashtime As Integer = 0             ' Used in timers for flashing buttons

    ' Batch & Clean Management
    Dim nextnumyy As Integer = 0
    Dim fgitemkey As String = ""
    Dim sieveing As Integer = 2              ' 1 = Yes, 2 = No (original)
    Dim finished As Integer = 0              ' 1 = a certain production stage finished
    Dim cleanCount As Integer = 0            ' counts how many times 999999 has been entered
    Dim cleanseq As Integer = 0              ' new sequence when entering 999999
    Private lastNormalBatch As String = ""

    ' Working flags
    Dim productionStageInProgress As Boolean = False
    Dim cleaningStageInProgress As Boolean = False

    ' Clean timing flags
    Dim cleantime As Integer = 0
    Dim cleantime2 As Integer = 0
    Dim cleantime3 As Integer = 0
    Dim cleanflashtime1 As Integer = 0
    Dim cleanflashtime2 As Integer = 0
    Dim cleanflashtime3 As Integer = 0


    ' Database connection string
    Public strconnectionstring As String = "Data Source=TH-BP-DB\MSSQL2017;User ID=dvl;Password=Pr0gr@mm1ng;database=TFCPILOT;Application name=SL2Timerecording"

#End Region

#Region "----- Form Load / Closing -----"

    Private Sub SL2_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Hide/disable Clean Stage buttons initially
        Butstartclean1.Enabled = False : Butstartclean1.Visible = False
        Butstartclean2.Enabled = False : Butstartclean2.Visible = False
        Butstartclean3.Enabled = False : Butstartclean3.Visible = False
        txtrmbin.Enabled = False
        ButFinishCleanContinue.Enabled = False
        ButFinishCleanContinue.Visible = False

        ' If language is Thai, set text on UI
        If thailanguage = 1 Then
            lblbatch.Text = "เลขแบทช์"
            lblheading.Text = "การผสมเครื่องปรุงรส"
            lblbin.Text = "รหัสถังวัตถุดิบ"
            Butstip.Text = "เริ่มการเทส่วนผสม"
            Butftip.Text = "สิ้นสุดการเทส่วนผสม"
            Butsblend.Text = "เริ่มการผสม"
            Butfblend.Text = "สิ้นสุดการผสม"
            lblfgbinid.Text = "รหัสถังสินค้าสำเร็จรูป"
            ButComplete.Text = "การผสมเสร็จสมบูรณ์"
            ButFinishCleanContinue.Text = "สิ้นสุดการทำความสะอาด"
        End If
    End Sub

    Private Sub SL2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' Do not allow form to close if closeok="0" or any process is in progress
        If closeok = "0" OrElse productionStageInProgress OrElse cleaningStageInProgress Then
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "----- UI Events: Batch KeyDown / TextChanged -----"

    ''' <summary>
    ''' Validate numeric input in txtBatch
    ''' </summary>
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Txtbatch.TextChanged
        If IsNumeric(Txtbatch.Text) OrElse Txtbatch.Text = "" Then
            ' OK
        Else
            Txtbatch.Clear()
            Txtbatch.Focus()
            ' Show error in dialog box (2 languages)
            ShowCustomMessage(
                "You can only use numerical values to fill in this text box",
                "กรุณากรอกได้เฉพาะตัวเลขเท่านั้น",
                Color.Red,
                "error"
            )
        End If

    End Sub

    ''' <summary>
    ''' Handle Enter or Tab key in txtBatch
    ''' </summary>
    Private Sub Txtbatch_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtbatch.KeyDown
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            ValidateAndPrepareBatch()
        End If
    End Sub

    ''' <summary>
    ''' Perform validation checks and switch UI accordingly
    ''' </summary>
    Private Sub ValidateAndPrepareBatch()
        Dim invalidbatch As Boolean = False
        Lblfgdesc.ForeColor = Color.Black

        ' 1) Check if batch is in pnitem/INMAST
        Using objcon1 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                SELECT TOP 1 a.itemkey, b.Desc1 
                  FROM pnitem a 
                  INNER JOIN INMAST b ON a.ItemKey = b.itemkey 
                  LEFT JOIN TFC_PTiming c ON a.BatchNo = c.BatchNo 
                 WHERE a.linetyp = 'FG' 
                   AND a.batchno = @batchno
            "
            Using objcmd1 As New SqlCommand(sql, objcon1)
                objcmd1.Parameters.AddWithValue("@batchno", Txtbatch.Text)
                Try
                    objcon1.Open()
                    Dim objReader = objcmd1.ExecuteReader()

                    ' If batch=999999 => do not treat as invalid even if not in DB
                    If Txtbatch.Text = "999999" Then
                        invalidbatch = False
                    Else
                        If Not objReader.HasRows Then
                            ' No rows => invalid
                            If thailanguage = 1 Then
                                Lblfgdesc.Text = "แบทช์ไม่ถูกต้อง"
                            Else
                                Lblfgdesc.Text = "Invalid batch"
                            End If
                            Lblfgdesc.ForeColor = Color.Red

                            ShowCustomMessage(
                                "Invalid batch number!",
                                "แบทช์ไม่ถูกต้อง!",
                                Color.Red,
                                "error"
                            )

                            invalidbatch = True
                            Txtbatch.Select()
                            Txtbatch.SelectAll()
                        End If
                    End If

                    ' 2) If still not invalid, check TFC_PTiming2 existence if needed
                    If invalidbatch = False Then
                        Dim hasTiming2 As Boolean = CheckBatchExistsInPTiming2(Txtbatch.Text)

                    End If

                    ' 3) Check if the batch is already blended
                    If invalidbatch = False Then
                        Dim isBlended = IsAlreadyBlended(Txtbatch.Text)
                        If isBlended Then
                            invalidbatch = True
                        End If
                    End If

                    ' 4) If valid, read itemkey and description
                    If invalidbatch = False Then
                        While objReader.Read()
                            fgitemkey = objReader("itemkey").ToString()
                            Dim desc1 As String = objReader("Desc1").ToString()
                            Lblfgdesc.ForeColor = Color.Black
                            Lblfgdesc.Text = fgitemkey & " - " & desc1
                        End While
                    End If

                Catch ex As Exception
                    ShowCustomMessage(
                        "Exception occurred: " & ex.Message,
                        "เกิดข้อผิดพลาด: " & ex.Message,
                        Color.Red,
                        "error"
                    )
                End Try
            End Using
        End Using

        ' If invalid => clear batch field, focus
        If invalidbatch Then
            Txtbatch.Text = ""
            Txtbatch.Focus()
            Return
        Else
            ' If valid => check if 999999 => Clean mode
            If Txtbatch.Text = "999999" Then
                EnterCleanMode()
            Else
                ' Normal batch mode
                Txtbatch.Enabled = False
                txtrmbin.Enabled = True
                ' Show bin selection
                Butbin1.Visible = True : Butbin2.Visible = True : Butbin3.Visible = True
                Butbin4.Visible = True : Butbin5.Visible = True : Butbin6.Visible = True
                Butbin00.Visible = True


                lblstip.Text = ""
                Lblftip.Text = ""
                Lblsblend.Text = ""
                lblfblend.Text = ""
                Lblbatch2.Text = ""
            End If
        End If
    End Sub

#End Region

#Region "----- UI Events: Start/Finish Tip/Blend -----"

    ''' <summary>
    ''' Start Tip (Butstip) - after selecting RM bin
    ''' Also disable changing the bin until finishing the blend
    ''' </summary>
    Private Sub Butstip_Click(sender As Object, e As EventArgs) Handles Butstip.Click
        ' 1) Insert record in TFC_PTiming2 if not exist
        Dim hasTiming2 As Boolean = CheckBatchExistsInPTiming2(Txtbatch.Text)
        If Not hasTiming2 Then
            getnextnumyy()
            InsertTFCPTiming2(Txtbatch.Text, fgitemkey, nextnumyy)
        End If

        ' 2) Update STARTTIP in DB
        Using objcon4 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                UPDATE TFC_PTiming2 
                   SET STARTTIP = GETDATE(),
                       fgtipbinid = @fgtipbinid 
                 WHERE BATCHNO = @batchno
            "
            Using objcmd4 As New SqlCommand(sql, objcon4)
                objcmd4.Parameters.AddWithValue("@batchno", Txtbatch.Text)
                objcmd4.Parameters.AddWithValue("@fgtipbinid", txtrmbin.Text)
                objcon4.Open()
                objcmd4.ExecuteNonQuery()
            End Using
        End Using

        ' 3) Mark production in progress
        closeok = "0"
        lblstip.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

        ' 4) Change button to green and disable it
        Butstip.BackColor = Color.Green
        Butstip.Enabled = False

        ' 5) Enable the next step (Finish Tip)
        Butftip.Enabled = True
        Butftip.Focus()

        Txtbatch.Enabled = False
        productionStageInProgress = True

        ' *** Disable bin selection so we cannot change RM bin after starting tip ***
        Butbin1.Enabled = False
        Butbin2.Enabled = False
        Butbin3.Enabled = False
        Butbin4.Enabled = False
        Butbin5.Enabled = False
        Butbin6.Enabled = False
        Butbin00.Enabled = False
    End Sub

    ''' <summary>
    ''' Finish Tip (Butftip)
    ''' </summary>
    Private Sub Butftip_Click(sender As Object, e As EventArgs) Handles Butftip.Click
        ' Update FINISHTIP
        Using objcon5 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                UPDATE TFC_PTiming2 
                   SET FINISHTIP = GETDATE() 
                 WHERE BATCHNO = @batchno
            "
            Using objcmd5 As New SqlCommand(sql, objcon5)
                objcmd5.Parameters.AddWithValue("@batchno", Txtbatch.Text)
                objcon5.Open()
                objcmd5.ExecuteNonQuery()
            End Using
        End Using

        Lblftip.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Butftip.BackColor = Color.Green
        Butftip.Enabled = False

        ' Enable Start Blend
        Butsblend.Enabled = True
        Butsblend.Focus()
    End Sub

    ''' <summary>
    ''' Start Blend (Butsblend)
    ''' </summary>
    Private Sub Butsblend_Click(sender As Object, e As EventArgs) Handles Butsblend.Click
        ' Update STARTBLEND
        Using objcon6 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                UPDATE TFC_PTiming2 
                   SET STARTBLEND = GETDATE() 
                 WHERE BATCHNO = @batchno
            "
            Using objcmd6 As New SqlCommand(sql, objcon6)
                objcmd6.Parameters.AddWithValue("@batchno", Txtbatch.Text)
                objcon6.Open()
                objcmd6.ExecuteNonQuery()
            End Using
        End Using

        Lblsblend.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Butsblend.BackColor = Color.Green
        Butsblend.Enabled = False

        ' Enable Finish Blend
        Butfblend.Enabled = True
        Butfblend.Focus()
    End Sub

    ''' <summary>
    ''' Finish Blend (Butfblend)
    ''' </summary>
    Private Sub Butfblend_Click(sender As Object, e As EventArgs) Handles Butfblend.Click
        ' Update FINISHBLEND
        Using objcon7 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                UPDATE TFC_PTiming2 
                   SET FINISHBLEND = GETDATE() 
                 WHERE BATCHNO = @batchno
            "
            Using objcmd7 As New SqlCommand(sql, objcon7)
                objcmd7.Parameters.AddWithValue("@batchno", Txtbatch.Text)
                objcon7.Open()
                objcmd7.ExecuteNonQuery()
            End Using
        End Using

        lblfblend.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Butfblend.BackColor = Color.Green
        Butfblend.Enabled = False

        ' Now enable FG bin entry
        Butbin00.Visible = False
        txtfgbin.Enabled = True
        txtfgbin.Focus()
        finished = 1

        ' *** After finishing blend => re-enable bin selection
        Butbin1.Enabled = True
        Butbin2.Enabled = True
        Butbin3.Enabled = True
        Butbin4.Enabled = True
        Butbin5.Enabled = True
        Butbin6.Enabled = True
        Butbin00.Enabled = True
    End Sub

    ''' <summary>
    ''' Blend Complete (ButComplete)
    ''' </summary>
    Private Sub ButComplete_Click(sender As Object, e As EventArgs) Handles ButComplete.Click
        ' Update FGPACKBINID, IBCFINISHED
        Using objcon8 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                UPDATE TFC_PTiming2 
                   SET FGPACKBINID = @FGPACKBINID, 
                       IBCFINISHED = GETDATE() 
                 WHERE BATCHNO = @batchno
            "
            Using objcmd8 As New SqlCommand(sql, objcon8)
                objcmd8.Parameters.AddWithValue("@batchno", Txtbatch.Text)
                objcmd8.Parameters.AddWithValue("@FGPACKBINID", txtfgbin.Text)
                objcon8.Open()
                objcmd8.ExecuteNonQuery()
            End Using
        End Using

        ' Store last normal batch if not 999999
        Lblbatch2.Text = Txtbatch.Text
        If Txtbatch.Text <> "999999" Then
            lastNormalBatch = Txtbatch.Text
        End If

        ' Clear screen for next batch
        clearscreen()
    End Sub

#End Region

#Region "----- UI Events: Bin Selection Buttons -----"

    Private Sub Butbin1_Click(sender As Object, e As EventArgs) Handles Butbin1.Click
        HandleBinSelection("01")
    End Sub
    Private Sub Butbin2_Click(sender As Object, e As EventArgs) Handles Butbin2.Click
        HandleBinSelection("02")
    End Sub
    Private Sub Butbin3_Click(sender As Object, e As EventArgs) Handles Butbin3.Click
        HandleBinSelection("03")
    End Sub
    Private Sub Butbin4_Click(sender As Object, e As EventArgs) Handles Butbin4.Click
        HandleBinSelection("04")
    End Sub
    Private Sub Butbin5_Click(sender As Object, e As EventArgs) Handles Butbin5.Click
        HandleBinSelection("05")
    End Sub
    Private Sub Butbin6_Click(sender As Object, e As EventArgs) Handles Butbin6.Click
        HandleBinSelection("06")
    End Sub
    Private Sub Butbin00_Click(sender As Object, e As EventArgs) Handles Butbin00.Click
        HandleBinSelection("00")
    End Sub

    ''' <summary>
    ''' Shared method for selecting bin
    ''' </summary>
    Private Sub HandleBinSelection(binNo As String)
        If finished = 1 Then
            ' If finishing mode => set fg bin
            txtfgbin.Text = binNo
            ButComplete.Enabled = True
        Else
            ' If normal RM bin selection
            txtrmbin.Text = binNo
            txtrmbin.Enabled = False

            ' If we haven't started tip => enable Butstip
            If lblstip.Text = "" Then
                ' พร้อมให้ Start Tip
                Butstip.Enabled = True
                stipflash.Enabled = True ' เริ่มกระพริบ
                Butstip.Focus()
            End If
        End If
    End Sub

#End Region

#Region "----- Timers -----"

    ''' <summary>
    ''' Timer for flashing Butstip
    ''' </summary>
    Private Sub stipflash_Tick(sender As Object, e As EventArgs) Handles stipflash.Tick
        If Butstip.Enabled = True Then
            flashtime = flashtime + 1
            If flashtime = 1 Then
                Butstip.BackColor = Color.Green
            Else
                Butstip.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing Butftip
    ''' </summary>
    Private Sub ftipflash_Tick(sender As Object, e As EventArgs) Handles ftipflash.Tick
        If Butftip.Enabled = True Then
            flashtime = flashtime + 1
            If flashtime = 1 Then
                Butftip.BackColor = Color.Green
            Else
                Butftip.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing Butsblend
    ''' </summary>
    Private Sub sblendflash_Tick(sender As Object, e As EventArgs) Handles sblendflash.Tick
        If Butsblend.Enabled = True Then
            flashtime = flashtime + 1
            If flashtime = 1 Then
                Butsblend.BackColor = Color.Green
            Else
                Butsblend.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing Butfblend
    ''' </summary>
    Private Sub fblendflash_Tick(sender As Object, e As EventArgs) Handles fblendflash.Tick
        If Butfblend.Enabled = True Then
            flashtime = flashtime + 1
            If flashtime = 1 Then
                Butfblend.BackColor = Color.Green
            Else
                Butfblend.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing Clean1 button
    ''' </summary>
    Private Sub Clean1flash_Tick(sender As Object, e As EventArgs) Handles Clean1flash.Tick
        If cleantime = 1 Then
            cleanflashtime1 += 1
            If cleanflashtime1 = 1 Then
                Butstartclean1.BackColor = Color.Blue
            Else
                Butstartclean1.BackColor = Color.Gray
                cleanflashtime1 = 0
            End If
        Else
            Clean1flash.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing Clean2 button
    ''' </summary>
    Private Sub Clean2flash_Tick(sender As Object, e As EventArgs) Handles Clean2flash.Tick
        If cleantime2 = 1 Then
            cleanflashtime2 += 1
            If cleanflashtime2 = 1 Then
                Butstartclean2.BackColor = Color.Blue
            Else
                Butstartclean2.BackColor = Color.Gray
                cleanflashtime2 = 0
            End If
        Else
            Clean2flash.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing Clean3 button
    ''' </summary>
    Private Sub Clean3flash_Tick(sender As Object, e As EventArgs) Handles Clean3flash.Tick
        If cleantime3 = 1 Then
            cleanflashtime3 += 1
            If cleanflashtime3 = 1 Then
                Butstartclean3.BackColor = Color.Blue
            Else
                Butstartclean3.BackColor = Color.Gray
                cleanflashtime3 = 0
            End If
        Else
            Clean3flash.Enabled = False
        End If
    End Sub

#End Region

#Region "----- UI Events: Clean Stage Buttons -----"

    Private Sub Butstartclean1_Click(sender As Object, e As EventArgs) Handles Butstartclean1.Click
        If Txtbatch.Text <> "999999" Then
            ShowCustomMessage(
                "Clean Stage 1 is valid only when Batch = 999999",
                "ขั้นตอนทำความสะอาด 1 ใช้ได้เฉพาะเมื่อ Batch = 999999",
                Color.Red,
                "error"
            )
            Return
        End If

        If cleanseq = 0 Then
            PrepareClean999999()
        End If

        If cleantime = 0 Then
            ' START CLEAN1
            cleantime = 1
            Butstartclean1.BackColor = Color.Blue
            Clean1flash.Enabled = True
            cleaningStageInProgress = True

            UpdateCleanStageStart(1)
            lblsclean1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

            Butstartclean2.Enabled = False
            Butstartclean3.Enabled = False
            ButFinishCleanContinue.Enabled = False
        Else
            ' FINISH CLEAN1
            cleantime = 0
            Clean1flash.Enabled = False
            UpdateCleanStageFinish(1)

            Butstartclean1.BackColor = Color.Gray
            lblfclean1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

            Butstartclean1.Enabled = False
            Butstartclean2.Enabled = True
            Butstartclean3.Enabled = True
            ButFinishCleanContinue.Enabled = True
        End If
    End Sub

    Private Sub Butstartclean2_Click(sender As Object, e As EventArgs) Handles Butstartclean2.Click
        If Txtbatch.Text <> "999999" Then
            ShowCustomMessage(
                "Clean Stage 2 is valid only when Batch = 999999",
                "ขั้นตอนทำความสะอาด 2 ใช้ได้เฉพาะเมื่อ Batch = 999999",
                Color.Red,
                "error"
            )
            Return
        End If

        If cleanseq = 0 Then
            PrepareClean999999()
        End If

        If cleantime2 = 0 Then
            ' START CLEAN2
            cleantime2 = 1
            Butstartclean2.BackColor = Color.Blue
            Clean2flash.Enabled = True
            cleaningStageInProgress = True

            Butstartclean1.Enabled = False
            Butstartclean3.Enabled = False
            ButFinishCleanContinue.Enabled = False

            UpdateCleanStageStart(2)
            lblsclean2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Else
            ' FINISH CLEAN2
            cleantime2 = 0
            Clean2flash.Enabled = False

            UpdateCleanStageFinish(2)
            Butstartclean2.BackColor = Color.Gray
            Butstartclean2.Enabled = False

            lblfclean2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

            Butstartclean3.Enabled = True
            ButFinishCleanContinue.Enabled = True
        End If
    End Sub

    Private Sub Butstartclean3_Click(sender As Object, e As EventArgs) Handles Butstartclean3.Click
        If Txtbatch.Text <> "999999" Then
            ShowCustomMessage(
                "Clean Stage 3 is valid only when Batch = 999999",
                "ขั้นตอนทำความสะอาด 3 ใช้ได้เฉพาะเมื่อ Batch = 999999",
                Color.Red,
                "error"
            )
            Return
        End If

        If cleanseq = 0 Then
            PrepareClean999999()
        End If

        If cleantime3 = 0 Then
            ' START CLEAN3
            cleantime3 = 1
            Butstartclean3.BackColor = Color.Blue
            Clean3flash.Enabled = True
            cleaningStageInProgress = True

            Butstartclean1.Enabled = False
            Butstartclean2.Enabled = False
            ButFinishCleanContinue.Enabled = False

            UpdateCleanStageStart(3)
            lblsclean3.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Else
            ' FINISH CLEAN3
            cleantime3 = 0
            Clean3flash.Enabled = False

            UpdateCleanStageFinish(3)
            Butstartclean3.BackColor = Color.Gray
            Butstartclean3.Enabled = False

            lblfclean3.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            cleaningStageInProgress = False

            ButFinishCleanContinue.Enabled = True

            ShowCustomMessage(
                "Cleaning process completed!",
                "ทำความสะอาดเสร็จสมบูรณ์!",
                Color.Green,
                "info"
            )

            ResetUIAfterFullClean()
        End If
    End Sub

    Private Sub ButFinishCleanContinue_Click(sender As Object, e As EventArgs) Handles ButFinishCleanContinue.Click
        ' Wrap any unfinished clean stages
        If cleantime = 1 Then
            cleantime = 0
            Clean1flash.Enabled = False
            UpdateCleanStageFinish(1)
            lblfclean1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        End If

        If cleantime2 = 1 Then
            cleantime2 = 0
            Clean2flash.Enabled = False
            UpdateCleanStageFinish(2)
            lblfclean2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        End If

        If cleantime3 = 1 Then
            cleantime3 = 0
            Clean3flash.Enabled = False
            UpdateCleanStageFinish(3)
            lblfclean3.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        End If

        ShowCustomMessage(
            "Cleaning process completed!",
            "ทำความสะอาดเสร็จสมบูรณ์!",
            Color.Green,
            "info"
        )

        ResetUIAfterFullClean()
    End Sub

#End Region

#Region "----- Helper Methods for Clean Mode -----"

    Private Sub EnterCleanMode()
        ' Hide bin selection
        Butbin1.Visible = False : Butbin2.Visible = False : Butbin3.Visible = False
        Butbin4.Visible = False : Butbin5.Visible = False : Butbin6.Visible = False
        Butbin00.Visible = False

        ' Clear RM bin
        txtrmbin.Text = ""
        txtrmbin.Enabled = False

        ' Clear timestamps
        lblstip.Text = ""
        Lblftip.Text = ""
        Lblsblend.Text = ""
        lblfblend.Text = ""
        Lblbatch2.Text = ""

        ' Increase clean count
        cleanCount += 1

        ' Show/enable clean stage buttons
        Butstartclean1.Visible = True : Butstartclean1.Enabled = True
        Butstartclean2.Visible = True : Butstartclean2.Enabled = True
        Butstartclean3.Visible = True : Butstartclean3.Enabled = True

        lblsclean1.Visible = True : lblfclean1.Visible = True
        lblsclean2.Visible = True : lblfclean2.Visible = True
        lblsclean3.Visible = True : lblfclean3.Visible = True

        lblsclean1.Text = "" : lblfclean1.Text = ""
        lblsclean2.Text = "" : lblfclean2.Text = ""
        lblsclean3.Text = "" : lblfclean3.Text = ""

        Butstartclean1.BackColor = Color.Gray
        Butstartclean2.BackColor = Color.Gray
        Butstartclean3.BackColor = Color.Gray

        If thailanguage = 1 Then
            Lblfgdesc.Text = "โหมดทำความสะอาด"
            Lblfgdesc.ForeColor = Color.Green
        Else
            Lblfgdesc.Text = "Clean Mode"
            Lblfgdesc.ForeColor = Color.Green
        End If

        ' Cannot use the batch field
        Txtbatch.Enabled = False

        ' Show finish clean button
        ButFinishCleanContinue.Visible = True
        ButFinishCleanContinue.Enabled = False
    End Sub

    Private Sub PrepareClean999999()
        getnextnumyy()
        cleanseq = nextnumyy

        Dim sqlInsert As String = "
            INSERT INTO TFC_PTiming2
            (
                [Sequence],
                [BatchNo],
                [RefLastBatchNo],
                [CLEAN1START],
                [CLEAN1FINISH],
                [CLEAN2START],
                [CLEAN2FINISH],
                [CLEAN3START],
                [CLEAN3FINISH],
                [ProcessCell]
            )
            VALUES(
                @seq,
                999999,
                @RefLastBatchNo,
                NULL,NULL,
                NULL,NULL,
                NULL,NULL,
                @ProcessCell
            );
        "
        Using conn As New SqlConnection(strconnectionstring)
            Using cmd As New SqlCommand(sqlInsert, conn)
                cmd.Parameters.AddWithValue("@seq", cleanseq)
                cmd.Parameters.AddWithValue("@RefLastBatchNo", lastNormalBatch)
                cmd.Parameters.AddWithValue("@ProcessCell", "Seasoning")
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateCleanStageStart(stageNum As Integer)
        Dim sqlUpdate As String = String.Format("
            UPDATE TFC_PTiming2
               SET CLEAN{0}START = GETDATE()
             WHERE BATCHNO = 999999
               AND [Sequence] = @seq
        ", stageNum)
        Using conn As New SqlConnection(strconnectionstring)
            Using cmd As New SqlCommand(sqlUpdate, conn)
                cmd.Parameters.AddWithValue("@seq", cleanseq)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateCleanStageFinish(stageNum As Integer)
        Dim sqlUpdate As String = String.Format("
            UPDATE TFC_PTiming2
               SET CLEAN{0}FINISH = GETDATE()
             WHERE BATCHNO = 999999
               AND [Sequence] = @seq
        ", stageNum)
        Using conn As New SqlConnection(strconnectionstring)
            Using cmd As New SqlCommand(sqlUpdate, conn)
                cmd.Parameters.AddWithValue("@seq", cleanseq)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ResetUIAfterFullClean()
        Lblfgdesc.Text = ""
        Txtbatch.Text = ""
        Txtbatch.Enabled = True
        Txtbatch.Focus()

        Butstartclean1.Visible = False : Butstartclean1.Enabled = False
        Butstartclean2.Visible = False : Butstartclean2.Enabled = False
        Butstartclean3.Visible = False : Butstartclean3.Enabled = False

        Butbin00.Enabled = True

        lblsclean1.Visible = False : lblfclean1.Visible = False
        lblsclean2.Visible = False : lblfclean2.Visible = False
        lblsclean3.Visible = False : lblfclean3.Visible = False

        cleanseq = 0
        cleantime = 0
        cleantime2 = 0
        cleantime3 = 0
        cleanflashtime1 = 0
        cleanflashtime2 = 0
        cleanflashtime3 = 0

        cleaningStageInProgress = False

        ButFinishCleanContinue.Visible = False
        ButFinishCleanContinue.Enabled = False
        txtrmbin.Enabled = True
    End Sub

#End Region

#Region "----- Helper Functions: Data Access + Others -----"

    ''' <summary>
    ''' Retrieve and increment 'Running' number in tfc_psequence2 (phase=5)
    ''' </summary>
    Sub getnextnumyy()
        Dim currentRunning As Integer = 0

        ' 1) Select current running
        Using conn As New SqlConnection(strconnectionstring)
            conn.Open()
            Using cmd As New SqlCommand("SELECT Running FROM tfc_psequence2 WHERE phase=5", conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    currentRunning = CInt(result)
                End If
            End Using
        End Using

        ' 2) Increment
        currentRunning += 1
        nextnumyy = currentRunning

        ' 3) Update
        Using conn As New SqlConnection(strconnectionstring)
            conn.Open()
            Using cmd As New SqlCommand("
                UPDATE tfc_psequence2 
                   SET RUNNING = @run 
                 WHERE phase = 5
            ", conn)
                cmd.Parameters.AddWithValue("@run", currentRunning)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Insert a new TFC_PTiming2 record when starting a normal batch for the first time
    ''' </summary>
    Private Sub InsertTFCPTiming2(batchNo As String, itemKey As String, seq As Integer)
        Dim sql As String = "
            INSERT INTO TFC_PTiming2 (
                [Sequence],[BatchNo],[StartSieve],[FinishSieve],[RMSieveBinID],
                [SieveComplete],[RMTipBinID],[StartTip],[FinishTip],[StartBlend],
                [FinishBlend],[FGTipBinID],[FGPackBinID],[StartPack],[FinishPack],
                [IBCKG],[BagSize],[FullBags],[PartBags],[PackComplete],
                [StartSieve2],[FinishSieve2],[IBCFinished],[Clean1start],[Clean1finish],
                [Clean2start],[Clean2finish],[Clean3start],[Clean3finish],[RefLastBatchNo],
                [ProcessCell],[FGItemkey]
            )
            VALUES(
                @seq,@batchNo,
                NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                @processCell,@fgItemKey
            )
        "
        Using conn As New SqlConnection(strconnectionstring)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@seq", seq)
                cmd.Parameters.AddWithValue("@batchNo", batchNo)
                cmd.Parameters.AddWithValue("@fgItemKey", itemKey)
                cmd.Parameters.AddWithValue("@processCell", "Seasoning")
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Check if a certain BatchNo exists in TFC_PTiming2
    ''' </summary>
    Private Function CheckBatchExistsInPTiming2(batchNo As String) As Boolean
        Dim exists As Boolean = False
        Using conn As New SqlConnection(strconnectionstring)
            Dim sql As String = "SELECT TOP 1 1 FROM TFC_PTiming2 WHERE BatchNo=@batchNo"
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@batchNo", batchNo)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    exists = True
                End If
            End Using
        End Using
        Return exists
    End Function

    ''' <summary>
    ''' Check if the batch is already blended (FinishBlend or FGPackBinID not null)
    ''' </summary>
    Private Function IsAlreadyBlended(batchNo As String) As Boolean
        Dim isBlended As Boolean = False
        Using conn As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                SELECT FinishBlend, FGPackBinID 
                  FROM TFC_PTiming2 
                 WHERE BatchNo=@batchNo
            "
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@batchNo", batchNo)
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        ' If either FinishBlend or FGPackBinID is not NULL => already blended
                        If Not IsDBNull(reader("FinishBlend")) OrElse
                           Not IsDBNull(reader("FGPackBinID")) Then
                            'If thailanguage = 1 Then
                            '    Lblfgdesc.Text = "แบทช์นี้ผสมลงถัง " & reader("FGPackBinID").ToString() & " เรียบร้อยแล้ว"
                            'Else
                            '    Lblfgdesc.Text = "Already blended into bin " & reader("FGPackBinID").ToString()
                            'End If
                            'Lblfgdesc.ForeColor = Color.Red


                            ShowCustomMessage(
                            "This batch has already blended into bin " & reader("FGPackBinID").ToString() & "!",
                            "แบทช์นี้ได้ผสมลงถัง " & reader("FGPackBinID").ToString() & " เรียบร้อยแล้ว!",
                            Color.Red,
                            "error")

                            isBlended = True
                            Exit While
                        End If
                    End While
                End Using
            End Using
        End Using
        Return isBlended
    End Function

    ''' <summary>
    ''' Show a 2-language dialog box with optional icon (error/info/warning).
    ''' </summary>
    Private Sub ShowCustomMessage(
        englishMessage As String,
        thaiMessage As String,
        Optional textColor As Color = Nothing,
        Optional iconType As String = "info"
    )
        Dim messageText As String = If(thailanguage = 1, thaiMessage, englishMessage)
        Dim msgBox As New FormMessage(messageText)

        If textColor <> Nothing Then
            msgBox.LabelMessage.ForeColor = textColor
        End If

        Select Case iconType.ToLower()
            Case "error"
                msgBox.SetIconError()
            Case "warning"
                msgBox.SetIconWarning()
            Case Else
                msgBox.SetIconInfo()
        End Select

        msgBox.ShowDialog()
    End Sub

    ''' <summary>
    ''' Clears and resets the UI to the initial state
    ''' </summary>
    Private Sub clearscreen()
        ' Reset textboxes
        Txtbatch.Text = ""
        txtrmbin.Text = ""
        txtfgbin.Text = ""
        Lblfgdesc.Text = ""
        'Lblbatch2.Text = ""

        ' Reset button states
        Butstip.Enabled = False
        Butftip.Enabled = False
        Butsblend.Enabled = False
        Butfblend.Enabled = False
        ButComplete.Enabled = False
        txtfgbin.Enabled = False

        Butstip.BackColor = Color.LightGray
        Butftip.BackColor = Color.LightGray
        Butsblend.BackColor = Color.LightGray
        Butfblend.BackColor = Color.LightGray
        ButComplete.BackColor = Color.LightGray

        Butbin1.Visible = False : Butbin2.Visible = False : Butbin3.Visible = False
        Butbin4.Visible = False : Butbin5.Visible = False : Butbin6.Visible = False
        Butbin00.Visible = False

        '' Reset labels for timestamps
        'lblstip.Text = ""
        'Lblftip.Text = ""
        'Lblsblend.Text = ""
        'lblfblend.Text = ""

        ' Stop timers / reset counters
        flashtime = 0
        'stipflash.Enabled = False
        'ftipflash.Enabled = False
        'sblendflash.Enabled = False
        'fblendflash.Enabled = False

        ' Allow new batch entry
        Txtbatch.Enabled = True
        Txtbatch.Focus()
        txtrmbin.Enabled = True

        ' Reset flags
        productionStageInProgress = False
        cleaningStageInProgress = False

        closeok = "1"
        finished = 0
        sieveing = 2
        fgitemkey = ""

        cleanCount = 0
    End Sub

#End Region

End Class
