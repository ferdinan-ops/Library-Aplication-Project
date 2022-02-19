<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register))
        Me.GunaTransfarantPictureBox1 = New Guna.UI.WinForms.GunaTransfarantPictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.username = New Guna.UI.WinForms.GunaTextBox()
        Me.password = New Guna.UI.WinForms.GunaTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nama = New Guna.UI.WinForms.GunaTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.level = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.BtRegister = New Guna.UI.WinForms.GunaButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.GunaTransfarantPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaTransfarantPictureBox1
        '
        Me.GunaTransfarantPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaTransfarantPictureBox1.BaseColor = System.Drawing.Color.Black
        Me.GunaTransfarantPictureBox1.Image = CType(resources.GetObject("GunaTransfarantPictureBox1.Image"), System.Drawing.Image)
        Me.GunaTransfarantPictureBox1.Location = New System.Drawing.Point(96, -25)
        Me.GunaTransfarantPictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GunaTransfarantPictureBox1.Name = "GunaTransfarantPictureBox1"
        Me.GunaTransfarantPictureBox1.Size = New System.Drawing.Size(261, 183)
        Me.GunaTransfarantPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaTransfarantPictureBox1.TabIndex = 10
        Me.GunaTransfarantPictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Poppins", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(232, 141)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 30)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Username"
        '
        'username
        '
        Me.username.BackColor = System.Drawing.Color.Transparent
        Me.username.BaseColor = System.Drawing.Color.Gainsboro
        Me.username.BorderColor = System.Drawing.Color.Gainsboro
        Me.username.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.username.FocusedBaseColor = System.Drawing.Color.Gainsboro
        Me.username.FocusedBorderColor = System.Drawing.Color.Gainsboro
        Me.username.FocusedForeColor = System.Drawing.Color.Gray
        Me.username.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.ForeColor = System.Drawing.Color.Gray
        Me.username.Location = New System.Drawing.Point(236, 171)
        Me.username.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.username.Name = "username"
        Me.username.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.username.Radius = 6
        Me.username.SelectedText = ""
        Me.username.Size = New System.Drawing.Size(176, 33)
        Me.username.TabIndex = 103
        '
        'password
        '
        Me.password.BackColor = System.Drawing.Color.Transparent
        Me.password.BaseColor = System.Drawing.Color.Gainsboro
        Me.password.BorderColor = System.Drawing.Color.Gainsboro
        Me.password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.password.FocusedBaseColor = System.Drawing.Color.Gainsboro
        Me.password.FocusedBorderColor = System.Drawing.Color.Gainsboro
        Me.password.FocusedForeColor = System.Drawing.Color.Gray
        Me.password.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.ForeColor = System.Drawing.Color.Gray
        Me.password.Location = New System.Drawing.Point(46, 240)
        Me.password.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.password.Radius = 6
        Me.password.SelectedText = ""
        Me.password.Size = New System.Drawing.Size(367, 33)
        Me.password.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Poppins", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(41, 210)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Password"
        '
        'nama
        '
        Me.nama.BackColor = System.Drawing.Color.Transparent
        Me.nama.BaseColor = System.Drawing.Color.Gainsboro
        Me.nama.BorderColor = System.Drawing.Color.Gainsboro
        Me.nama.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nama.FocusedBaseColor = System.Drawing.Color.Gainsboro
        Me.nama.FocusedBorderColor = System.Drawing.Color.Gainsboro
        Me.nama.FocusedForeColor = System.Drawing.Color.Gray
        Me.nama.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nama.ForeColor = System.Drawing.Color.Gray
        Me.nama.Location = New System.Drawing.Point(46, 171)
        Me.nama.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.nama.Name = "nama"
        Me.nama.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.nama.Radius = 6
        Me.nama.SelectedText = ""
        Me.nama.Size = New System.Drawing.Size(176, 33)
        Me.nama.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Poppins", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(41, 141)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 30)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Poppins", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(41, 287)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 30)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Level"
        '
        'level
        '
        Me.level.BackColor = System.Drawing.Color.Transparent
        Me.level.BaseColor = System.Drawing.Color.Gainsboro
        Me.level.BorderColor = System.Drawing.Color.Gainsboro
        Me.level.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.level.FocusedColor = System.Drawing.Color.White
        Me.level.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.level.ForeColor = System.Drawing.Color.Gray
        Me.level.FormattingEnabled = True
        Me.level.Items.AddRange(New Object() {"Admin", "Officer"})
        Me.level.Location = New System.Drawing.Point(46, 314)
        Me.level.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.level.Name = "level"
        Me.level.OnHoverItemBaseColor = System.Drawing.Color.White
        Me.level.OnHoverItemForeColor = System.Drawing.Color.Gray
        Me.level.Radius = 6
        Me.level.Size = New System.Drawing.Size(368, 29)
        Me.level.TabIndex = 110
        '
        'GunaElipse1
        '
        Me.GunaElipse1.Radius = 29
        Me.GunaElipse1.TargetControl = Me
        '
        'BtRegister
        '
        Me.BtRegister.Animated = True
        Me.BtRegister.AnimationHoverSpeed = 0.07!
        Me.BtRegister.AnimationSpeed = 0.03!
        Me.BtRegister.BackColor = System.Drawing.Color.Transparent
        Me.BtRegister.BaseColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtRegister.BorderColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtRegister.BorderSize = 2
        Me.BtRegister.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtRegister.DialogResult = System.Windows.Forms.DialogResult.None
        Me.BtRegister.FocusedColor = System.Drawing.Color.Empty
        Me.BtRegister.Font = New System.Drawing.Font("Poppins", 11.89565!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtRegister.ForeColor = System.Drawing.Color.White
        Me.BtRegister.Image = Nothing
        Me.BtRegister.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtRegister.Location = New System.Drawing.Point(46, 374)
        Me.BtRegister.Name = "BtRegister"
        Me.BtRegister.OnHoverBaseColor = System.Drawing.Color.White
        Me.BtRegister.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtRegister.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtRegister.OnHoverImage = Nothing
        Me.BtRegister.OnPressedColor = System.Drawing.Color.Black
        Me.BtRegister.Radius = 15
        Me.BtRegister.Size = New System.Drawing.Size(367, 37)
        Me.BtRegister.TabIndex = 111
        Me.BtRegister.Text = "Register"
        Me.BtRegister.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(308, 432)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 28)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Login"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(84, 432)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(232, 28)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Already have an account ?"
        '
        'Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(454, 494)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtRegister)
        Me.Controls.Add(Me.level)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nama)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GunaTransfarantPictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register"
        CType(Me.GunaTransfarantPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaTransfarantPictureBox1 As Guna.UI.WinForms.GunaTransfarantPictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents username As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents password As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nama As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents level As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents BtRegister As Guna.UI.WinForms.GunaButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
