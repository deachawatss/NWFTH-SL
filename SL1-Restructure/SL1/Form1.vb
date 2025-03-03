Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Net.Mail

Public Class SL1

#Region "----- Fields / Variables -----"

    ' Language and UI state
    Dim thailanguage As Integer = 1               ' 1 = Thai, otherwise English
    Dim flashtime As Integer = 0                  ' Used for timers to flash buttons

    ' Database connection string
    Public strconnectionstring As String = "Data Source=th-bp-db\mssql2017;User ID=ict;Password=NwfTh@Sql;database=TFCPILOT;Application name=SL1Timerecording"

    ' Batch & Items
    Dim fgitemkey As String = ""
    Dim fgcode As String = ""
    Dim nextnumyy As Integer = 0

    ' For controlling form closure (cannotclose=1 means do NOT allow close)
    Public cannotclose As Integer = 0

    ' Clean logic (similar to SL2)
    Dim cleanCount As Integer = 0
    Dim cleanseq As Integer = 0
    Dim cleantime As Integer = 0
    Dim cleantime2 As Integer = 0
    Dim cleantime3 As Integer = 0
    Dim cleanflashtime1 As Integer = 0
    Dim cleanflashtime2 As Integer = 0
    Dim cleanflashtime3 As Integer = 0
    Dim cleaningStageInProgress As Boolean = False

    ' Keep track of last normal batch
    Private lastNormalBatch As String = ""

#End Region

#Region "----- Form Load / Closing -----"

    Private Sub SL1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set UI text if Thai
        If thailanguage = 1 Then
            lblheading.Text = "การเทส่วนผสมเครื่องปรุงรส"
            lblbatch.Text = "เลขแบทช์"
            Butsbatch.Text = "เริ่มการเทส่วนผสม"          ' Start Sieve/Tip
            Butfbatch.Text = "สิ้นสุดการเทส่วนผสม"        ' Finish Sieve/Tip
            Butbatchcomplete.Text = "การเทส่วนผสมเสร็จสมบูรณ์" ' Tip complete
            lblbin.Text = "รหัสถัง"
            ButFinishCleanContinue.Text = "สิ้นสุดการทำความสะอาด"

        End If

        ' Hide/disable Clean Stage controls
        Butstartclean1.Visible = False : Butstartclean1.Enabled = False
        Butstartclean2.Visible = False : Butstartclean2.Enabled = False
        Butstartclean3.Visible = False : Butstartclean3.Enabled = False

        ButFinishCleanContinue.Visible = False
        ButFinishCleanContinue.Enabled = False
    End Sub

    Private Sub SL1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        ' If cannotclose=1 => disallow closing
        If cannotclose = 1 OrElse cleaningStageInProgress Then
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "----- UI Events: Batch KeyDown / TextChanged -----"

    Private Sub txtbatch_TextChanged(sender As Object, e As EventArgs) Handles txtbatch.TextChanged
        If IsNumeric(txtbatch.Text) OrElse txtbatch.Text = "" Then
            ' OK
        Else
            txtbatch.Clear()
            txtbatch.Focus()
            ShowCustomMessage("You can only use numerical values to fill in this text box",
                              "สามารถป้อนค่าได้เฉพาะตัวเลขเท่านั้น",
                              Color.Red,
                              "error") ' Show an error icon and red text
        End If
    End Sub

    Private Sub txtbatch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbatch.KeyDown
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            ValidateAndPrepareBatch()
        End If
    End Sub

    Private Sub ValidateAndPrepareBatch()
        Dim invalidbatch As Boolean = False
        Lblfgdesc.ForeColor = Color.Black

        ' 1) Check if batch is in pnitem/INMAST
        Using objcon1 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                SELECT TOP 1 a.itemkey, b.Desc1, 
                             c.StartSieve, c.StartBlend, c.StartPack, c.FinishPack, c.FullBags
                  FROM pnitem a
                  INNER JOIN INMAST b ON a.ItemKey = b.itemkey
                  LEFT JOIN TFC_PTiming2 c ON a.BatchNo = c.BatchNo
                 WHERE a.linetyp = 'FG'
                   AND a.batchno = @batchno
            "
            Using objcmd1 As New SqlCommand(sql, objcon1)
                objcmd1.Parameters.AddWithValue("@batchno", txtbatch.Text)
                Try
                    objcon1.Open()
                    Dim objReader = objcmd1.ExecuteReader()
                    If Not objReader.HasRows AndAlso txtbatch.Text <> "999999" Then

                        If thailanguage = 1 Then
                            lbw.Text = "เลขแบทช์ไม่ถูกต้อง!"
                            lbw.ForeColor = Color.Red
                        Else
                            lbw.Text = "Invalid batch number!"
                            lbw.ForeColor = Color.Red
                        End If
                        ShowCustomMessage("Invalid batch number!",
                                          "เลขแบทช์ไม่ถูกต้อง!",
                                          Color.Red,
                                          "error")
                        Lblfgdesc.ForeColor = Color.Red
                        invalidbatch = True
                        txtbatch.Select()
                        txtbatch.SelectAll()
                    End If

                    If invalidbatch Then
                        txtbatch.Text = ""
                        txtbatch.Focus()
                        Return
                    Else
                        If txtbatch.Text = "999999" Then
                            EnterCleanMode()
                        Else
                            If CheckIfAlreadySieved(txtbatch.Text) Then
                                txtbatch.Text = ""
                                txtbatch.Focus()
                                Return
                            Else

                                txtbatch.Enabled = False
                                Butsbatch.Enabled = True
                                Butsbatch.Focus()


                                lblsbatch.Text = ""
                                Lblfbatch.Text = ""
                                Lblbatch2.Text = ""
                                lbw.Text = ""
                            End If
                        End If
                    End If

                    If invalidbatch = False Then
                        While objReader.Read()
                            fgitemkey = objReader("ItemKey").ToString()
                            Dim desc1 As String = objReader("Desc1").ToString()
                            Lblfgdesc.Text = fgitemkey & " - " & desc1
                            Lblfgdesc.ForeColor = Color.Black
                        End While
                    End If

                Catch ex As Exception
                    ' Show error in a custom dialog with 2 languages
                    ShowCustomMessage("Exception occurred: " & ex.Message,
                                      "เกิดข้อผิดพลาด: " & ex.Message,
                                      Color.Red,
                                      "error")
                End Try
            End Using
        End Using


    End Sub

    ''' <summary>
    ''' Checks if the batch has already been sieved.
    ''' </summary>
    Private Function CheckIfAlreadySieved(batchNo As String) As Boolean
        Dim alreadySieved As Boolean = False
        Using objconcbatch As New SqlConnection(strconnectionstring)
            Dim checkbatch As String = "SELECT * FROM tfc_ptiming2 WHERE batchno = @batchno"
            Using cmdcbatch As New SqlCommand(checkbatch, objconcbatch)
                cmdcbatch.Parameters.AddWithValue("@batchno", batchNo)
                objconcbatch.Open()

                Using readercbatch As SqlDataReader = cmdcbatch.ExecuteReader()
                    While readercbatch.Read()
                        If Not IsDBNull(readercbatch.Item("StartSieve")) Then
                            Dim binNumber As String = readercbatch.Item("RMSieveBinID").ToString()

                            ' -- Choose label text based on language --
                            If thailanguage = 1 Then
                                lbw.Text = "แบทช์นี้ได้เทส่วนผสมลงถัง " & binNumber & " ไปแล้ว!"
                                lbw.ForeColor = Color.Red
                            Else
                                lbw.Text = "Already sieved into bin " & binNumber
                                lbw.ForeColor = Color.Red
                            End If
                            lbw.ForeColor = Color.Red

                            '-- Show dialog box also in two languages --
                            ShowCustomMessage(
                            "This batch has already been sieved into bin " & binNumber & "!",
                            "แบทช์นี้ได้เทส่วนผสมลงถัง " & binNumber & " ไปแล้ว!",
                            Color.Red,
                            "error"
                        )

                            alreadySieved = True
                            Exit While
                        End If
                    End While
                End Using
            End Using
        End Using
        Return alreadySieved
    End Function


    Private Sub InsertIfNotExistTFCPTiming2()
        getnextnumyy()
        Using objconnxx As New SqlConnection(strconnectionstring)
            Dim sqlInsert As String = "
                INSERT INTO TFC_PTiming2 (
                    [Sequence],[BatchNo],
                    [StartSieve],[FinishSieve],[RMSieveBinID],
                    [SieveComplete],[RMTipBinID],[StartTip],[FinishTip],[StartBlend],
                    [FinishBlend],[FGTipBinID],[FGPackBinID],[StartPack],[FinishPack],
                    [IBCKG],[BagSize],[FullBags],[PartBags],[PackComplete],
                    [StartSieve2],[FinishSieve2],[IBCFinished],
                    [Clean1start],[Clean1finish],[Clean2start],[Clean2finish],[Clean3start],
                    [Clean3finish],[RefLastBatchNo],[ProcessCell],[FGItemkey]
                )
                VALUES(
                    @seq,@batchNo,
                    NULL,NULL,NULL,
                    NULL,NULL,NULL,NULL,NULL,
                    NULL,NULL,NULL,NULL,NULL,
                    NULL,NULL,NULL,NULL,NULL,
                    NULL,NULL,NULL,NULL,NULL,
                    NULL,NULL,NULL,NULL,NULL,
                    'Seasoning',@fgItemkey
                )
            "
            Using objcmdxx As New SqlCommand(sqlInsert, objconnxx)
                objcmdxx.Parameters.AddWithValue("@seq", nextnumyy)
                objcmdxx.Parameters.AddWithValue("@batchNo", txtbatch.Text)
                objcmdxx.Parameters.AddWithValue("@fgItemkey", fgitemkey)
                objconnxx.Open()
                objcmdxx.ExecuteNonQuery()
            End Using
        End Using
    End Sub

#End Region

#Region "----- UI Events: Start/Finish Sieve -----"

    Private Sub Butsbatch_Click(sender As Object, e As EventArgs) Handles Butsbatch.Click

        InsertIfNotExistTFCPTiming2()
        Using objcon2 As New SqlConnection(strconnectionstring)
            Dim sql As String = "UPDATE TFC_PTiming2 SET STARTSIEVE = GETDATE() WHERE BATCHNO = @batchno"
            Using objcmd2 As New SqlCommand(sql, objcon2)
                objcmd2.Parameters.AddWithValue("@batchno", txtbatch.Text)
                objcon2.Open()
                objcmd2.ExecuteNonQuery()
            End Using
        End Using

        lblsbatch.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Butsbatch.BackColor = Color.Green
        Butsbatch.Enabled = False
        Butfbatch.Enabled = True
        Butfbatch.Focus()

        txtbatch.Enabled = False
        cannotclose = 1

        Using objcon4 As New SqlConnection(strconnectionstring)
            Dim sql2 As String = "UPDATE tfc_psequence2 SET SSIEVE = @stip WHERE phase = 5"
            Using objcmd4 As New SqlCommand(sql2, objcon4)
                objcmd4.Parameters.AddWithValue("@stip", DateTime.Now)
                objcon4.Open()
                objcmd4.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub Butfbatch_Click(sender As Object, e As EventArgs) Handles Butfbatch.Click
        If String.IsNullOrEmpty(lblsbatch.Text) Then
            ' Show an error that user must start batch first
            ShowCustomMessage(
                "You must start batch, blend, and finish pack first!",
                "กรุณาเริ่มแบทช์, บด และจบการแพ็คก่อน!",
                Color.Red,
                "error"
            )
        Else
            Using objcon8 As New SqlConnection(strconnectionstring)
                Dim sql As String = "UPDATE TFC_PTiming2 SET FINISHSIEVE = GETDATE() WHERE BATCHNO = @batchno"
                Using objcmd8 As New SqlCommand(sql, objcon8)
                    objcmd8.Parameters.AddWithValue("@batchno", txtbatch.Text)
                    objcon8.Open()
                    objcmd8.ExecuteNonQuery()
                    Lblfbatch.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                    Butfbatch.BackColor = Color.Green
                    Butfbatch.Enabled = False
                End Using
            End Using

            Using objcon6 As New SqlConnection(strconnectionstring)
                Dim sql6 As String = "UPDATE tfc_psequence2 SET FINISHED = 0 WHERE phase = 5"
                Using objcmd6 As New SqlCommand(sql6, objcon6)
                    objcon6.Open()
                    objcmd6.ExecuteNonQuery()
                End Using
            End Using

            Using objcon7 As New SqlConnection(strconnectionstring)
                Dim sql7 As String = "UPDATE tfc_psequence2 SET BATCH = NULL WHERE phase = 5"
                Using objcmd7 As New SqlCommand(sql7, objcon7)
                    objcon7.Open()
                    objcmd7.ExecuteNonQuery()
                End Using
            End Using

            Butbin1.Enabled = True : Butbin1.Visible = True
            Butbin2.Enabled = True : Butbin2.Visible = True
            Butbin3.Enabled = True : Butbin3.Visible = True
            Butbin4.Enabled = True : Butbin4.Visible = True
            Butbin5.Enabled = True : Butbin5.Visible = True
            Butbin6.Enabled = True : Butbin6.Visible = True

            lblbin.Enabled = True
            lblbin.Visible = True
            Txtbin.Enabled = True
            Txtbin.Visible = True
        End If
    End Sub

#End Region

#Region "----- UI Events: Bin Selection -----"

    Private Sub Butbin1_Click(sender As Object, e As EventArgs) Handles Butbin1.Click
        Txtbin.Text = "01"
        Butbatchcomplete.Enabled = True
        Butbatchcomplete.Visible = True
    End Sub
    Private Sub Butbin2_Click(sender As Object, e As EventArgs) Handles Butbin2.Click
        Txtbin.Text = "02"
        Butbatchcomplete.Enabled = True
        Butbatchcomplete.Visible = True
    End Sub
    Private Sub Butbin3_Click(sender As Object, e As EventArgs) Handles Butbin3.Click
        Txtbin.Text = "03"
        Butbatchcomplete.Enabled = True
        Butbatchcomplete.Visible = True
    End Sub
    Private Sub Butbin4_Click(sender As Object, e As EventArgs) Handles Butbin4.Click
        Txtbin.Text = "04"
        Butbatchcomplete.Enabled = True
        Butbatchcomplete.Visible = True
    End Sub
    Private Sub Butbin5_Click(sender As Object, e As EventArgs) Handles Butbin5.Click
        Txtbin.Text = "05"
        Butbatchcomplete.Enabled = True
        Butbatchcomplete.Visible = True
    End Sub
    Private Sub Butbin6_Click(sender As Object, e As EventArgs) Handles Butbin6.Click
        Txtbin.Text = "06"
        Butbatchcomplete.Enabled = True
        Butbatchcomplete.Visible = True
    End Sub

    Private Sub Txtbin_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtbin.KeyDown
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            If Txtbin.Text = "001" Then
                Butbatchcomplete.Focus()
            Else
                ShowCustomMessage("Bin number must be 001",
                                  "รหัสถังต้องเป็น 001",
                                  Color.Red,
                                  "error")
            End If
        End If
    End Sub

    Private Sub Butbatchcomplete_Click(sender As Object, e As EventArgs) Handles Butbatchcomplete.Click
        Using objcon9 As New SqlConnection(strconnectionstring)
            Dim sql As String = "
                UPDATE TFC_PTiming2
                   SET SIEVECOMPLETE = GETDATE(),
                       RMSIEVEBINID = @BINID
                 WHERE BATCHNO = @batchno
            "
            Using objcmd9 As New SqlCommand(sql, objcon9)
                objcmd9.Parameters.AddWithValue("@batchno", txtbatch.Text)
                objcmd9.Parameters.AddWithValue("@binid", Txtbin.Text)
                objcon9.Open()
                objcmd9.ExecuteNonQuery()
            End Using
        End Using
        If txtbatch.Text <> "999999" Then
            lastNormalBatch = txtbatch.Text
        End If
        clearscreen()
    End Sub

    Sub clearscreen()
        Butsbatch.Enabled = True : Butfbatch.Enabled = True
        Butsbatch.BackColor = Color.LightGray
        Butfbatch.BackColor = Color.LightGray
        Butsbatch.Enabled = False
        Butfbatch.Enabled = False
        Butsbatch.Visible = True
        Butfbatch.Visible = True

        Butbin1.Enabled = False : Butbin1.Visible = False
        Butbin2.Enabled = False : Butbin2.Visible = False
        Butbin3.Enabled = False : Butbin3.Visible = False
        Butbin4.Enabled = False : Butbin4.Visible = False
        Butbin5.Enabled = False : Butbin5.Visible = False
        Butbin6.Enabled = False : Butbin6.Visible = False

        Butbatchcomplete.Enabled = False
        Butbatchcomplete.Visible = False

        txtbatch.Enabled = True
        lblbin.Enabled = False : lblbin.Visible = False
        Txtbin.Enabled = False : Txtbin.Visible = False

        Lblbatch2.Text = txtbatch.Text
        txtbatch.Text = ""
        Txtbin.Text = ""
        Lblfgdesc.Text = ""

        flashtime = 0
        cannotclose = 0
        Me.Refresh()
        txtbatch.Focus()
    End Sub

#End Region

#Region "----- Clean Stage -----"

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
            cleantime3 = 0
            Clean3flash.Enabled = False

            UpdateCleanStageFinish(3)
            Butstartclean3.BackColor = Color.Gray
            Butstartclean3.Enabled = False

            lblfclean3.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            cleaningStageInProgress = False

            ShowCustomMessage("Cleaning process completed!",
                              "ทำความสะอาดเสร็จสมบูรณ์",
                              Color.Green,
                              "info")

            ResetUIAfterFullClean()
        End If
    End Sub

    Private Sub ButFinishCleanContinue_Click(sender As Object, e As EventArgs) Handles ButFinishCleanContinue.Click
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

        ShowCustomMessage("Cleaning process completed!",
                          "ทำความสะอาดเสร็จสมบูรณ์",
                          Color.Green,
                          "info")

        ResetUIAfterFullClean()
    End Sub

#End Region

#Region "----- Timers -----"

    Private Sub sbatchflash_Tick(sender As Object, e As EventArgs) Handles sbatchflash.Tick
        If Butsbatch.Enabled Then
            flashtime += 1
            If flashtime = 1 Then
                Butsbatch.BackColor = Color.Green
            Else
                Butsbatch.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    Private Sub fbatchflash_Tick(sender As Object, e As EventArgs) Handles fbatchflash.Tick
        If Butfbatch.Enabled Then
            flashtime += 1
            If flashtime = 1 Then
                Butfbatch.BackColor = Color.Green
            Else
                Butfbatch.BackColor = Color.Gray
                flashtime = 0
            End If
        End If
    End Sub

    Private Sub Clean1flash_Tick(sender As Object, e As EventArgs) Handles Clean1flash.Tick
        If cleantime = 1 Then
            cleanflashtime1 += 1
            If cleanflashtime1 = 1 Then
                Butstartclean1.BackColor = Color.Blue
            Else
                Butstartclean1.BackColor = Color.Gray
                cleanflashtime1 = 0
            End If
        End If
    End Sub

    Private Sub Clean2flash_Tick(sender As Object, e As EventArgs) Handles Clean2flash.Tick
        If cleantime2 = 1 Then
            cleanflashtime2 += 1
            If cleanflashtime2 = 1 Then
                Butstartclean2.BackColor = Color.Blue
            Else
                Butstartclean2.BackColor = Color.Gray
                cleanflashtime2 = 0
            End If
        End If
    End Sub

    Private Sub Clean3flash_Tick(sender As Object, e As EventArgs) Handles Clean3flash.Tick
        If cleantime3 = 1 Then
            cleanflashtime3 += 1
            If cleanflashtime3 = 1 Then
                Butstartclean3.BackColor = Color.Blue
            Else
                Butstartclean3.BackColor = Color.Gray
                cleanflashtime3 = 0
            End If
        End If
    End Sub

#End Region

#Region "----- Helper Methods for Clean Mode -----"

    Private Sub EnterCleanMode()
        Butbin1.Visible = False : Butbin2.Visible = False
        Butbin3.Visible = False : Butbin4.Visible = False
        Butbin5.Visible = False : Butbin6.Visible = False
        lblbin.Visible = False
        Txtbin.Visible = False

        txtbatch.Enabled = False
        lblsbatch.Text = ""
        Lblfbatch.Text = ""
        Lblbatch2.Text = ""
        lbw.Text = ""

        cleanCount += 1

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
                [CLEAN1START],[CLEAN1FINISH],
                [CLEAN2START],[CLEAN2FINISH],
                [CLEAN3START],[CLEAN3FINISH],
                [ProcessCell]
            )
            VALUES(
                @seq,
                999999,
                @RefLastBatchNo,
                NULL,NULL,
                NULL,NULL,
                NULL,NULL,
                'Seasoning'
            )
        "
        Using conn As New SqlConnection(strconnectionstring)
            Using cmd As New SqlCommand(sqlInsert, conn)
                cmd.Parameters.AddWithValue("@seq", cleanseq)
                cmd.Parameters.AddWithValue("@RefLastBatchNo", lastNormalBatch)
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
        txtbatch.Text = ""
        lbw.Text = ""
        txtbatch.Enabled = True
        txtbatch.Focus()

        Butstartclean1.Visible = False : Butstartclean1.Enabled = False
        Butstartclean2.Visible = False : Butstartclean2.Enabled = False
        Butstartclean3.Visible = False : Butstartclean3.Enabled = False

        lblsclean1.Visible = False : lblfclean1.Visible = False
        lblsclean2.Visible = False : lblfclean2.Visible = False
        lblsclean3.Visible = False : lblfclean3.Visible = False

        ButFinishCleanContinue.Visible = False
        ButFinishCleanContinue.Enabled = False

        cleanseq = 0
        cleantime = 0
        cleantime2 = 0
        cleantime3 = 0
        cleanflashtime1 = 0
        cleanflashtime2 = 0
        cleanflashtime3 = 0

        cleaningStageInProgress = False
    End Sub

#End Region

#Region "----- Helper Functions: Data Access + Others -----"

    Sub getnextnumyy()
        Dim currentRunning As Integer = 0
        Using conn As New SqlConnection(strconnectionstring)
            conn.Open()
            Using cmd As New SqlCommand("SELECT Running FROM tfc_psequence2 WHERE phase=5", conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    currentRunning = CInt(result)
                End If
            End Using
        End Using

        currentRunning += 1
        nextnumyy = currentRunning

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
    ''' Show a custom message with two languages, a color, and an icon type.
    ''' iconType (e.g. "error", "info", "warning") will tell FormMessage which icon to use.
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


#End Region

End Class
