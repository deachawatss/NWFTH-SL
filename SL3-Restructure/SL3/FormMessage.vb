Public Class FormMessage

    ' This flag prevents closing the form via the "X" button unless canClose = True.
    Private canClose As Boolean = False

    ''' <summary>
    ''' Constructor that takes a message string and arranges controls in a vertically centered style.
    ''' </summary>
    Public Sub New(message As String)
        InitializeComponent()

        ' Place the icon at the top center
        PictureBoxIcon.Width = 40
        PictureBoxIcon.Height = 40
        PictureBoxIcon.Left = (Me.ClientSize.Width - PictureBoxIcon.Width) \ 2
        PictureBoxIcon.Top = 10

        ' Assign the text to LabelMessage
        LabelMessage.Text = message

        ' After the text is assigned, recalculate its position
        LabelMessage.Left = (Me.ClientSize.Width - LabelMessage.Width) \ 2
        LabelMessage.Top = PictureBoxIcon.Bottom + 10

        ' Place the OK button below the label, centered horizontally
        ButtonOK.Left = (Me.ClientSize.Width - ButtonOK.Width) \ 2
        ButtonOK.Top = LabelMessage.Bottom + 15
    End Sub

    ''' <summary>
    ''' Displays an information icon in the PictureBox.
    ''' </summary>
    Public Sub SetIconInfo()
        PictureBoxIcon.Image = SystemIcons.Information.ToBitmap()
    End Sub

    ''' <summary>
    ''' Displays an error icon in the PictureBox.
    ''' </summary>
    Public Sub SetIconError()
        PictureBoxIcon.Image = SystemIcons.Error.ToBitmap()
    End Sub

    ''' <summary>
    ''' Displays a warning icon in the PictureBox.
    ''' </summary>
    Public Sub SetIconWarning()
        PictureBoxIcon.Image = SystemIcons.Warning.ToBitmap()
    End Sub

    ''' <summary>
    ''' Event handler for the OK button.
    ''' </summary>
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        canClose = True
        Me.Close()
    End Sub

    ''' <summary>
    ''' If you want to prevent the user from closing via 'X', handle FormClosing here.
    ''' </summary>
    Private Sub FormMessage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not canClose AndAlso e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If
    End Sub

End Class
