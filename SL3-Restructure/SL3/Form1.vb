Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Net.Mail

Public Class SL3

#Region "----- Fields / Variables -----"

    ' --- Language flag (1 = Thai, otherwise English)
    Dim thailanguage As Integer = 1

    ' --- Common counters / flags ---
    Dim flashtime As Integer = 0      ' Used in timers for flashing
    Dim finished As Integer = 0       ' Indicates if finishing a step
    Dim inbagsize As Integer = 0      ' Flag to see which textbox is currently active for numeric input
    Dim infgbin As Integer = 0
    Dim inpartbags As Integer = 0
    Dim inibckg As Integer = 0
    Dim infullbags As Integer = 0
    Dim roundqty As Decimal = 0
    Dim fgoqty As Integer = 1
    Dim fullbags As Integer = 0
    Dim maxqty As Decimal
    Dim minqty As Decimal
    Dim fgbags As Decimal
    Dim complete As Integer = 0


    ' Working flags
    Dim cleaningStageInProgress As Boolean = False
    Public allowclose As Integer = 1

    ' --- Database connection string ---
    Public strconnectionstring As String = "Data Source=th-bp-db\mssql2017;User ID=ict;Password=NwfTh@Sql;database=TFCPILOT;Application name=SL3Timerecording"

    ' --- Clean stage variables ---
    Dim cleanMode As Boolean = False       ' True if batch = 999999 => Clean mode
    Dim cleanseq As Integer = 0
    Dim cleantime As Integer = 0           ' Timer control for Stage 1
    Dim cleantime2 As Integer = 0          ' Timer control for Stage 2
    Dim cleantime3 As Integer = 0          ' Timer control for Stage 3
    Dim cleanflashtime1 As Integer = 0     ' Flashing effect for Stage1
    Dim cleanflashtime2 As Integer = 0     ' Flashing effect for Stage2
    Dim cleanflashtime3 As Integer = 0     ' Flashing effect for Stage3
    Dim nextnumyy As Integer = 0
    Private lastNormalBatch As String = ""

#End Region

#Region "----- Form Load / Closing -----"

    ''' <summary>
    ''' SL3 form load event
    ''' </summary>
    Private Sub SL3_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Initialize UI if Thai language
        If thailanguage = 1 Then
            lblheading.Text = "บรรจุภัณฑ์เครื่องปรุงรส"
            lblbatch.Text = "เลขแบทช์"
            lblbin.Text = "รหัสถังสินค้าสำเร็จรูป"
            butstart.Text = "เริ่มต้นการบรรจุ"
            butfinish.Text = "สิ้นสุดการบรรจุ"
            lblbagsize.Text = "ขนาดบรรจุถุง/กล่อง"
            Lblbagsize2.Text = "กิโลกรัม"
            lblfullbags.Text = "จำนวนถุง/กล่อง"
            lblfullbags2.Text = "ถุง/กล่อง"
            lblpartbags.Text = "จำนวนไม่เต็มถุง"
            lblpartbags2.Text = "กิโลกรัม"
            lblibckg.Text = "รวมน้ำหนัก"
            lblibckg2.Text = "กิโลกรัม"
            Butbatchcomp.Text = "บรรจุเสร็จสมบูรณ์"
            Butbackspace.Text = "ลบ 1 ตัวอักษร"

            ButFinishCleanContinue.Text = "สิ้นสุดการทำความสะอาด"
        End If

        ' Hide/disable the 3-stage clean buttons initially
        Butstartclean1.Enabled = False : Butstartclean1.Visible = False
        Butstartclean2.Enabled = False : Butstartclean2.Visible = False
        Butstartclean3.Enabled = False : Butstartclean3.Visible = False
        ButFinishCleanContinue.Enabled = False : ButFinishCleanContinue.Visible = False

    End Sub

    ''' <summary>
    ''' Prevent closing the form if processes are not completed
    ''' </summary>
    Private Sub SL3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' If allowclose=0 => do not allow form to close
        If allowclose = 0 Then
            e.Cancel = True
        End If
        If cleaningStageInProgress = True Then
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "----- Timers (Production Buttons Flash) -----"

    ''' <summary>
    ''' Timer for flashing the 'Start' button
    ''' </summary>
    Private Sub Startflash_Tick(sender As Object, e As EventArgs) Handles Startflash.Tick
        If butstart.Enabled = True Then
            flashtime += 1
            If flashtime = 1 Then
                butstart.BackColor = Color.Green
            Else
                butstart.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Timer for flashing the 'Finish' button
    ''' </summary>
    Private Sub Finishflash_Tick(sender As Object, e As EventArgs) Handles Finishflash.Tick
        If butfinish.Enabled = True Then
            flashtime += 1
            If flashtime = 1 Then
                butfinish.BackColor = Color.Green
            Else
                butfinish.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

#End Region

#Region "----- Timers (Clean Stages Flash) -----"

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

#Region "----- UI Events: Batch Textbox -----"

    ''' <summary>
    ''' Validate numeric input in txtbatch
    ''' </summary>
    Private Sub txtbatch_TextChanged(sender As Object, e As EventArgs) Handles txtbatch.TextChanged
        If IsNumeric(txtbatch.Text) Or txtbatch.Text = "" Then
            ' Acceptable
        Else
            txtbatch.Clear()
            txtbatch.Focus()
            ShowCustomMessage(
                "You can only use numerical values in this text box",
                "กรุณากรอกได้เฉพาะตัวเลขเท่านั้น",
                Color.Red,
                "error"
            )
        End If
    End Sub

    ''' <summary>
    ''' Handle Enter or Tab key in txtbatch
    ''' </summary>
    Private Sub txtbatch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbatch.KeyDown
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            ValidateBatchAndSetup()
        End If
    End Sub

    ''' <summary>
    ''' Validate batch, check if 999999 => Clean Mode, otherwise do production checks
    ''' </summary>
    Private Sub ValidateBatchAndSetup()
        Dim invalidbatch As Integer = 0
        lblfgdesc.ForeColor = Color.Black

        ' If batch = 999999 => Enter Clean Mode
        If txtbatch.Text = "999999" Then
            cleanMode = True
            EnterCleanMode()
            Return
        Else
            cleanMode = False
        End If

        ' Normal batch => check from database
        Using objcon1 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                Select TOP 1 a.itemkey, Desc1, StartBatch, StartBlend, StartPack, Finish, totalbags 
                  from pnitem a 
                  INNER JOIN INMAST b ON a.ItemKey = b.itemkey 
                  LEFT JOIN TFC_PTiming c ON a.BatchNo = c.BatchNo 
                 where linetyp = 'FG' 
                   and a.batchno = @batchno
            "
            Dim objcmd1 As New SqlCommand(sql, objcon1)
            objcmd1.Parameters.AddWithValue("@batchno", txtbatch.Text)

            Try
                objcon1.Open()
                Dim objReader As SqlDataReader = objcmd1.ExecuteReader()

                If objReader.HasRows = False Then
                    If thailanguage = 1 Then
                        lblfgdesc.Text = "เลขแบทซ์ไม่ถูกต้อง !"
                        lblfgdesc.ForeColor = Color.Red
                    Else
                        lblfgdesc.Text = "Invalid batch"
                        lblfgdesc.ForeColor = Color.Red
                    End If


                    ShowCustomMessage("Invalid batch number!", "เลขแบทช์ไม่ถูกต้อง!", Color.Red, "error")
                    invalidbatch = 1
                    txtbatch.Select()
                    txtbatch.SelectAll()

                Else
                    ' If valid => we do subsequent checks in TFC_PTiming2
                    objReader.Close()

                    ' Check TFC_PTiming2 record existence and states
                    If invalidbatch = 0 Then
                        ' 1) Must have a record in TFC_PTiming2
                        If Not CheckBatchExistsInPTiming2(txtbatch.Text) Then
                            If thailanguage = 1 Then
                                lblfgdesc.Text = "โปรดดำเนินการขั้นตอน SL2 ให้เสร็จสิ้นก่อน !"
                                lblfgdesc.ForeColor = Color.Red
                            Else
                                lblfgdesc.Text = "The SL2 Process has not started yet!"
                                lblfgdesc.ForeColor = Color.Red



                            End If
                            ShowCustomMessage("The SL2 Process has not started yet!", "โปรดดำเนินการขั้นตอน SL2 ให้เสร็จสิ้นก่อน !", Color.Red, "error")

                            txtbatch.Select()
                            txtbatch.SelectAll()

                            invalidbatch = 1
                        End If
                    End If

                    ' 2) Check if already assigned FGPackBinID => means it was done
                    If invalidbatch = 0 Then
                        Using objconcbatch2 As New SqlConnection(strconnectionstring)
                            objconcbatch2.Open()
                            Dim cmdcbatch2 As New SqlCommand("
                                select * from tfc_ptiming2 where batchno = @batch
                            ", objconcbatch2)
                            cmdcbatch2.Parameters.AddWithValue("@batch", txtbatch.Text)
                            Dim readercbatch2 As SqlDataReader = cmdcbatch2.ExecuteReader()
                            While readercbatch2.Read()
                                If Not IsDBNull(readercbatch2.Item("FINISHPACK")) Then

                                    If thailanguage = 1 Then
                                        lblfgdesc.Text = "แบทช์นี้มีการบรรจุลงถัง " & readercbatch2("FGPackBinID").ToString() & " เรียบร้อยแล้ว"
                                    Else
                                        lblfgdesc.Text = "Already packed into bin " & readercbatch2.Item("fgpackbinid")
                                    End If
                                    lblfgdesc.ForeColor = Color.Red

                                    ShowCustomMessage(
                                        "Already packed into bin: " & readercbatch2.Item("fgpackbinid"),
                                        "แบทช์นี้มีการบรรจุลงถัง " & readercbatch2.Item("fgpackbinid").ToString() & "ไปแล้ว",
                                        Color.Red,
                                        "error"
                                    )
                                    invalidbatch = 1
                                    Exit While
                                End If
                            End While
                            readercbatch2.Close()
                        End Using
                    End If

                    ' If invalid => clear text
                    If invalidbatch = 1 Then
                        txtbatch.Text = ""
                        txtbatch.Focus()
                    Else
                        ' If still valid => read item desc
                        objReader = objcmd1.ExecuteReader()
                        While objReader.Read()
                            lblfgdesc.ForeColor = Color.Black
                            lblfgdesc.Text = objReader("ItemKey").ToString() & " - " & objReader("Desc1").ToString()

                        End While
                    End If
                End If
            Catch ex As Exception
                ShowCustomMessage(ex.Message, "เกิดข้อผิดพลาด: " & ex.Message, Color.Red, "error")
            Finally
                objcmd1.Dispose()
                objcon1.Close()
            End Try
        End Using

        If invalidbatch = 1 Then
            ' do nothing extra
        Else
            ' If batch is valid => enable bin selection
            txtbatch.Enabled = False
            Butbin1.Enabled = True : Butbin2.Enabled = True : Butbin3.Enabled = True
            Butbin4.Enabled = True : Butbin5.Enabled = True : Butbin6.Enabled = True
            txtfgbin.Enabled = True
            txtfgbin.Focus()

            Butbin1.Visible = True
            Butbin2.Visible = True
            Butbin3.Visible = True
            Butbin4.Visible = True
            Butbin5.Visible = True
            Butbin6.Visible = True

            lblstart.Text = ""
            lblfinish.Text = ""
            Lblbatch2.Text = ""
        End If

    End Sub

#End Region

#Region "----- UI Events: Production Buttons (Start, Finish, etc.) -----"

    ''' <summary>
    ''' Start button click - Begin packing
    ''' </summary>
    Private Sub butstart_Click(sender As Object, e As EventArgs) Handles butstart.Click
        butstart.Enabled = False
        allowclose = 0

        Using objcon2 As New SqlConnection(strconnectionstring)
            Dim objcmd2 As New SqlCommand("
                UPDATE TFC_PTiming2 
                   SET STARTPACK = GETDATE(), fgpackbinid = @fgpackbinid 
                 WHERE BATCHNO = @batchno
            ", objcon2)
            objcmd2.Parameters.AddWithValue("@batchno", txtbatch.Text)
            objcmd2.Parameters.AddWithValue("@fgpackbinid", txtfgbin.Text)

            Try
                objcon2.Open()
                objcmd2.ExecuteNonQuery()
            Catch ex As Exception
                ShowCustomMessage(ex.Message, "เกิดข้อผิดพลาด: " & ex.Message, Color.Red, "error")
            End Try
        End Using

        lblstart.Text = (DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
        butstart.BackColor = Color.Green
        butfinish.Enabled = True
        butfinish.Focus()

        txtbatch.Enabled = False

        ' Hide bin buttons
        Butbin1.Enabled = False : Butbin1.Visible = False
        Butbin2.Enabled = False : Butbin2.Visible = False
        Butbin3.Enabled = False : Butbin3.Visible = False
        Butbin4.Enabled = False : Butbin4.Visible = False
        Butbin5.Enabled = False : Butbin5.Visible = False
        Butbin6.Enabled = False : Butbin6.Visible = False

    End Sub

    ''' <summary>
    ''' Finish button click - End packing
    ''' </summary>
    Private Sub butfinish_Click(sender As Object, e As EventArgs) Handles butfinish.Click
        butfinish.Enabled = False
        finished = 1

        Using objcon3 As New SqlConnection(strconnectionstring)
            Dim objcmd3 As New SqlCommand("
                UPDATE TFC_PTiming2 
                   SET FINISHPACK = GETDATE() 
                 WHERE BATCHNO = @batchno
            ", objcon3)
            objcmd3.Parameters.AddWithValue("@batchno", txtbatch.Text)
            Try
                objcon3.Open()
                objcmd3.ExecuteNonQuery()
            Catch ex As Exception
                ShowCustomMessage(ex.Message, "เกิดข้อผิดพลาด: " & ex.Message, Color.Red, "error")
            End Try
        End Using

        lblfinish.Text = (DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
        butfinish.BackColor = Color.Green

        txtbatch.Enabled = False
        txtbagsize.Enabled = True
        txtbagsize.Focus()
        txtfullbags.Enabled = True
        txtpartbags.Enabled = True

        ' Enable numeric keypad for bag inputs
        Butbin1.Enabled = True : Butbin1.Visible = True
        Butbin2.Enabled = True : Butbin2.Visible = True
        Butbin3.Enabled = True : Butbin3.Visible = True
        Butbin4.Enabled = True : Butbin4.Visible = True
        Butbin5.Enabled = True : Butbin5.Visible = True
        Butbin6.Enabled = True : Butbin6.Visible = True
        Butbin7.Enabled = True : Butbin7.Visible = True
        Butbin8.Enabled = True : Butbin8.Visible = True
        Butbin9.Enabled = True : Butbin9.Visible = True
        Butbin0.Enabled = True : Butbin0.Visible = True
        Butbinpoint.Enabled = True : Butbinpoint.Visible = True
        Butbackspace.Enabled = True : Butbackspace.Visible = True

        Butbatchcomp.Enabled = True
    End Sub

    ''' <summary>
    ''' Mark packing complete and update DB
    ''' </summary>
    Private Sub Butbatchcomp_Click(sender As Object, e As EventArgs) Handles Butbatchcomp.Click
        complete = 1

        ' Validate required fields
        If String.IsNullOrEmpty(txtfullbags.Text) Then
            ShowCustomMessage(
                "Please enter Total No. Full Bags",
                "กรุณากรอกจำนวนถุงเต็ม",
                Color.Red,
                "error"
            )
            complete = 0
        Else
            If Val(txtfullbags.Text) <= 0 Then
                ShowCustomMessage(
                    "Please enter Total No. Full Bags",
                    "กรุณากรอกจำนวนถุงเต็ม",
                    Color.Red,
                    "error"
                )
                complete = 0
            End If
        End If

        If complete = 1 Then
            If String.IsNullOrEmpty(txtbagsize.Text) Then
                ShowCustomMessage(
                    "Please enter bag size",
                    "กรุณากรอกขนาดบรรจุต่อถุง",
                    Color.Red,
                    "error"
                )
                complete = 0
            Else
                If Val(txtbagsize.Text) <= 0 Then
                    ShowCustomMessage(
                        "Please enter bag size",
                        "กรุณากรอกขนาดบรรจุต่อถุง",
                        Color.Red,
                        "error"
                    )
                    complete = 0
                End If
            End If
        End If

        If complete = 1 Then
            ' All validations pass => do final update
            allowclose = 1
            finalupdate()
            clearscreendown()
        End If
    End Sub

#End Region

#Region "----- UI Events: Numeric Keypad -----"

    ''' <summary>
    ''' Handle numeric pad buttons for Bin selection or text input
    ''' </summary>
    Private Sub Butbin1_Click(sender As Object, e As EventArgs) Handles Butbin1.Click
        HandleNumericKeypad("1")
    End Sub
    Private Sub Butbin2_Click(sender As Object, e As EventArgs) Handles Butbin2.Click
        HandleNumericKeypad("2")
    End Sub
    Private Sub Butbin3_Click(sender As Object, e As EventArgs) Handles Butbin3.Click
        HandleNumericKeypad("3")
    End Sub
    Private Sub Butbin4_Click(sender As Object, e As EventArgs) Handles Butbin4.Click
        HandleNumericKeypad("4")
    End Sub
    Private Sub Butbin5_Click(sender As Object, e As EventArgs) Handles Butbin5.Click
        HandleNumericKeypad("5")
    End Sub
    Private Sub Butbin6_Click(sender As Object, e As EventArgs) Handles Butbin6.Click
        HandleNumericKeypad("6")
    End Sub
    Private Sub Butbin7_Click(sender As Object, e As EventArgs) Handles Butbin7.Click
        HandleNumericKeypad("7")
    End Sub
    Private Sub Butbin8_Click(sender As Object, e As EventArgs) Handles Butbin8.Click
        HandleNumericKeypad("8")
    End Sub
    Private Sub Butbin9_Click(sender As Object, e As EventArgs) Handles Butbin9.Click
        HandleNumericKeypad("9")
    End Sub
    Private Sub Butbin0_Click(sender As Object, e As EventArgs) Handles Butbin0.Click
        HandleNumericKeypad("0")
    End Sub
    Private Sub Butbinpoint_Click(sender As Object, e As EventArgs) Handles Butbinpoint.Click
        HandleNumericKeypad(".")
    End Sub

    ''' <summary>
    ''' Backspace button
    ''' </summary>
    Private Sub Butbackspace_Click(sender As Object, e As EventArgs) Handles Butbackspace.Click
        If infullbags = 1 Then
            If txtfullbags.Text.Length > 0 Then
                txtfullbags.Text = txtfullbags.Text.Substring(0, txtfullbags.Text.Length - 1)
            End If
        End If
        If inpartbags = 1 Then
            If txtpartbags.Text.Length > 0 Then
                txtpartbags.Text = txtpartbags.Text.Substring(0, txtpartbags.Text.Length - 1)
            End If
        End If
        If inbagsize = 1 Then
            If txtbagsize.Text.Length > 0 Then
                txtbagsize.Text = txtbagsize.Text.Substring(0, txtbagsize.Text.Length - 1)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Decide which textbox to append the pressed digit
    ''' </summary>
    Private Sub HandleNumericKeypad(digit As String)
        If infgbin = 1 Then
            txtfgbin.Text = digit.PadLeft(2, "0"c)  ' In SL3 code, it sets "01" or "02" etc. 
            txtfgbin.Enabled = False
            butstart.Enabled = True
            Return
        End If

        If inbagsize = 1 Then
            txtbagsize.Text &= digit
        ElseIf infullbags = 1 Then
            txtfullbags.Text &= digit
        ElseIf inpartbags = 1 Then
            txtpartbags.Text &= digit
        End If
    End Sub

#End Region

#Region "----- UI Events: Textboxes GotFocus & TextChanged -----"

    ''' <summary>
    ''' When txtfgbin gets focus => numeric keypad is for fgbin
    ''' </summary>
    Private Sub txtfgbin_GotFocus(sender As Object, e As EventArgs) Handles txtfgbin.GotFocus
        infgbin = 1
        inbagsize = 0
        inpartbags = 0
        inibckg = 0
        infullbags = 0
    End Sub

    ''' <summary>
    ''' When txtbagsize gets focus => numeric keypad for bag size
    ''' </summary>
    Private Sub txtbagsize_GotFocus(sender As Object, e As EventArgs) Handles txtbagsize.GotFocus
        inbagsize = 1
        infgbin = 0
        inpartbags = 0
        inibckg = 0
        infullbags = 0
    End Sub

    ''' <summary>
    ''' When txtfullbags gets focus => numeric keypad for full bags
    ''' </summary>
    Private Sub txtfullbags_GotFocus(sender As Object, e As EventArgs) Handles txtfullbags.GotFocus
        inbagsize = 0
        infgbin = 0
        inpartbags = 0
        inibckg = 0
        infullbags = 1
    End Sub

    ''' <summary>
    ''' When txtpartbags gets focus => numeric keypad for part bags
    ''' </summary>
    Private Sub txtpartbags_GotFocus(sender As Object, e As EventArgs) Handles txtpartbags.GotFocus
        inbagsize = 0
        infgbin = 0
        inpartbags = 1
        inibckg = 0
        infullbags = 0
    End Sub

    ''' <summary>
    ''' When txtibckg gets focus => numeric keypad for IBC (but in this code, not fully used)
    ''' </summary>
    Private Sub txtibckg_GotFocus(sender As Object, e As EventArgs) Handles txtibckg.GotFocus
        inbagsize = 0
        infgbin = 0
        inpartbags = 0
        inibckg = 1
        infullbags = 0
    End Sub

    ''' <summary>
    ''' Recalculate total when txtbagsize changes
    ''' </summary>
    Private Sub txtbagsize_TextChanged(sender As Object, e As EventArgs) Handles txtbagsize.TextChanged
        If Not String.IsNullOrEmpty(txtbagsize.Text) Then
            If Not IsNumeric(txtbagsize.Text) Then
                txtbagsize.Clear()
                txtbagsize.Focus()
                ShowCustomMessage(
                    "You can only use numerical values in this text box",
                    "กรุณากรอกได้เฉพาะตัวเลขเท่านั้น",
                    Color.Red,
                    "error"
                )
                Return
            Else
                fgbags = Val(txtbagsize.Text)
            End If
        End If

        ' Recalculate total
        Dim fgnumber1 As Decimal = If(String.IsNullOrEmpty(txtfullbags.Text), 0, Val(txtfullbags.Text))
        Dim fgnumber2 As Decimal = If(String.IsNullOrEmpty(txtpartbags.Text), 0, Val(txtpartbags.Text))
        Dim sumKg As Decimal = fgnumber1 * fgbags + fgnumber2
        txtibckg.Text = If(sumKg = 0, "", sumKg.ToString())

        ' For tolerance check
        If Not String.IsNullOrEmpty(txtbagsize.Text) Then
            fullbags = fgoqty / Val(txtbagsize.Text)
            roundqty = fullbags * Val(txtbagsize.Text)
            maxqty = roundqty + Val(txtbagsize.Text)
            minqty = roundqty - Val(txtbagsize.Text)
        End If
    End Sub

    ''' <summary>
    ''' Recalculate total when txtfullbags changes
    ''' </summary>
    Private Sub txtfullbags_TextChanged(sender As Object, e As EventArgs) Handles txtfullbags.TextChanged
        If Not String.IsNullOrEmpty(txtfullbags.Text) Then
            If Not IsNumeric(txtfullbags.Text) Then
                txtfullbags.Clear()
                txtfullbags.Focus()
                ShowCustomMessage(
                    "You can only use numerical values in this text box",
                    "กรุณากรอกได้เฉพาะตัวเลขเท่านั้น",
                    Color.Red,
                    "error"
                )
                Return
            End If
        End If

        Dim number1 As Decimal = If(String.IsNullOrEmpty(txtfullbags.Text), 0, Val(txtfullbags.Text))
        Dim number2 As Decimal = If(String.IsNullOrEmpty(txtpartbags.Text), 0, Val(txtpartbags.Text))
        Dim totalKg As Decimal = number1 * fgbags + number2
        txtibckg.Text = If(totalKg = 0, "", totalKg.ToString())
    End Sub

    ''' <summary>
    ''' Recalculate total when txtpartbags changes
    ''' </summary>
    Private Sub txtpartbags_TextChanged(sender As Object, e As EventArgs) Handles txtpartbags.TextChanged
        If Not String.IsNullOrEmpty(txtpartbags.Text) Then
            If Not IsNumeric(txtpartbags.Text) Then
                txtpartbags.Clear()
                txtpartbags.Focus()
                ShowCustomMessage(
                    "You can only use numerical values in this text box",
                    "กรุณากรอกได้เฉพาะตัวเลขเท่านั้น",
                    Color.Red,
                    "error"
                )
                Return
            End If

            ' Check 2 decimal places
            If txtpartbags.Text Like "*.*" Then
                Dim part = txtpartbags.Text.Split("."c)(1)
                If part.Length > 2 Then
                    txtpartbags.Text = txtpartbags.Text.Substring(0, txtpartbags.Text.Length - 1)
                    ShowCustomMessage(
                        "Cannot exceed 2 decimals",
                        "ไม่สามารถเกิน 2 ตำแหน่งทศนิยม",
                        Color.Red,
                        "error"
                    )
                    Return
                End If
            End If
        End If

        Dim number1 As Decimal = If(String.IsNullOrEmpty(txtfullbags.Text), 0, Val(txtfullbags.Text))
        Dim number2 As Decimal = If(String.IsNullOrEmpty(txtpartbags.Text), 0, Val(txtpartbags.Text))
        Dim totalKg As Decimal = number1 * fgbags + number2
        txtibckg.Text = If(totalKg = 0, "", totalKg.ToString())
    End Sub

#End Region

#Region "----- UI Events: Clean Stage Buttons -----"

    Private Sub Butstartclean1_Click(sender As Object, e As EventArgs) Handles Butstartclean1.Click
        If txtbatch.Text <> "999999" Then
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
        If txtbatch.Text <> "999999" Then
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
        If txtbatch.Text <> "999999" Then
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
        'Butbatchcomp.Visible = False



        ' Clear RM bin
        txtfgbin.Text = ""
        txtfgbin.Enabled = False

        ' Clear timestamps
        lblstart.Text = ""
        lblfinish.Text = ""
        Lblbatch2.Text = ""


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
            lblfgdesc.Text = "โหมดทำความสะอาด"
            lblfgdesc.ForeColor = Color.Green
        Else
            lblfgdesc.Text = "Clean Mode"
            lblfgdesc.ForeColor = Color.Green
        End If

        ' Cannot use the batch field
        txtbatch.Enabled = False

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
        lblfgdesc.Text = ""
        txtbatch.Text = ""
        txtbatch.Enabled = True
        txtbatch.Focus()

        Butstartclean1.Visible = False : Butstartclean1.Enabled = False
        Butstartclean2.Visible = False : Butstartclean2.Enabled = False
        Butstartclean3.Visible = False : Butstartclean3.Enabled = False



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

    End Sub

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

#End Region

#Region "----- Helper Methods: Final Update & Clear Screen -----"

    ''' <summary>
    ''' Write final data to TFC_PTiming2 (bagsize, fullbags, etc.)
    ''' </summary>
    Private Sub finalupdate()
        Using objconcomp As New SqlConnection(strconnectionstring)
            Dim objcmdcomp As New SqlCommand("
                UPDATE TFC_PTiming2 
                   SET ibckg = @ibckg, 
                       fullbags = @fullbags, 
                       PARTBAGS = @partbags, 
                       bagsize = @bagsize, 
                       packcomplete = GETDATE() 
                 WHERE BATCHNO = @batchno
            ", objconcomp)

            objcmdcomp.Parameters.AddWithValue("@batchno", txtbatch.Text)
            objcmdcomp.Parameters.AddWithValue("@bagsize", txtbagsize.Text)
            objcmdcomp.Parameters.AddWithValue("@fullbags", txtfullbags.Text)
            objcmdcomp.Parameters.AddWithValue("@partbags", txtpartbags.Text)
            objcmdcomp.Parameters.AddWithValue("@ibckg", txtibckg.Text)

            Try
                objconcomp.Open()
                objcmdcomp.ExecuteNonQuery()
            Catch ex As Exception
                ShowCustomMessage(ex.Message, "เกิดข้อผิดพลาด: " & ex.Message, Color.Red, "error")
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Clear screen for next batch
    ''' </summary>
    Private Sub clearscreendown()
        ' Disable numeric pad
        Butbin1.Enabled = False : Butbin1.Visible = False
        Butbin2.Enabled = False : Butbin2.Visible = False
        Butbin3.Enabled = False : Butbin3.Visible = False
        Butbin4.Enabled = False : Butbin4.Visible = False
        Butbin5.Enabled = False : Butbin5.Visible = False
        Butbin6.Enabled = False : Butbin6.Visible = False
        Butbin7.Enabled = False : Butbin7.Visible = False
        Butbin8.Enabled = False : Butbin8.Visible = False
        Butbin9.Enabled = False : Butbin9.Visible = False
        Butbin0.Enabled = False : Butbin0.Visible = False
        Butbinpoint.Enabled = False : Butbinpoint.Visible = False
        Butbackspace.Enabled = False : Butbackspace.Visible = False

        Butbatchcomp.Enabled = False

        ' Store last normal batch if not 999999
        Lblbatch2.Text = txtbatch.Text
        If txtbatch.Text <> "999999" Then
            lastNormalBatch = txtbatch.Text
        End If

        ' Reset textboxes
        txtfgbin.Enabled = False
        txtfgbin.Text = ""
        txtbagsize.Text = "" : txtbagsize.Enabled = False
        txtfullbags.Text = "" : txtfullbags.Enabled = False
        txtpartbags.Text = "" : txtpartbags.Enabled = False
        txtibckg.Text = "" : txtibckg.Enabled = False

        ' Clear info
        lblfgdesc.Text = ""
        'Lblbatch2.Text = ""

        ' Reset flags
        flashtime = 0
        finished = 0
        inbagsize = 0
        infgbin = 0
        inpartbags = 0
        inibckg = 0
        infullbags = 0
        roundqty = 0
        fgoqty = 1
        fullbags = 0
        complete = 0

        ' Re-enable batch
        txtbatch.Text = ""
        txtbatch.Enabled = True
        txtbatch.Focus()

        butstart.BackColor = Color.Gray
        butfinish.BackColor = Color.Gray


    End Sub

#End Region

#Region "----- Helper Methods: Data Checking -----"

    ''' <summary>
    ''' Check if TFC_PTiming2 record exists for the given batch
    ''' </summary>
    Private Function CheckBatchExistsInPTiming2(batchNo As String) As Boolean
        Dim result As Boolean = False
        Using objcon As New SqlConnection(strconnectionstring)
            Dim cmd As New SqlCommand("
                select top 1 1 
                  from tfc_ptiming2 
                 where batchno = @batch
            ", objcon)
            cmd.Parameters.AddWithValue("@batch", batchNo)
            objcon.Open()
            Dim scalar = cmd.ExecuteScalar()
            If scalar IsNot Nothing Then
                result = True
            End If
        End Using
        Return result
    End Function

#End Region

#Region "----- Helper Methods: Custom 2-Language MsgBox -----"

    ''' <summary>
    ''' Display a 2-language message box (with optional color/icon).
    ''' </summary>
    Private Sub ShowCustomMessage(englishMessage As String,
                                  thaiMessage As String,
                                  Optional textColor As Color = Nothing,
                                  Optional iconType As String = "info")
        Dim msgText As String = If(thailanguage = 1, thaiMessage, englishMessage)
        Dim fm As New FormMessage(msgText)
        If textColor <> Nothing Then
            fm.LabelMessage.ForeColor = textColor
        End If

        Select Case iconType.ToLower()
            Case "error"
                fm.SetIconError()
            Case "warning"
                fm.SetIconWarning()
            Case Else
                fm.SetIconInfo()
        End Select

        fm.ShowDialog()
    End Sub

#End Region

End Class
