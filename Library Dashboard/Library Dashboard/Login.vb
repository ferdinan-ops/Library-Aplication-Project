Imports System.Data.Odbc
Public Class Login

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Register.Show()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Clear()
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        TextBox2.Clear()
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub TextBox1_MouseLeave_1(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        If TextBox1.Text = "Username" Or TextBox1.Text = "" Then
            TextBox1.Text = "Username"
            TextBox1.ForeColor = Color.DarkGray
        Else
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox2_MouseLeave_1(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If TextBox2.Text = "Password" Or TextBox2.Text = "" Then
            TextBox2.Text = "Password"
            TextBox2.ForeColor = Color.DarkGray
        Else
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Username atau Password Anda Masih Kosong")
        Else
            Call koneksi()
            Cmd = New OdbcCommand("select * from tbl_user where username = '" & TextBox1.Text & "' and pwd = '" & TextBox2.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                Menu_Utama.lbl_status.Text = Rd.Item("lvl")
                Menu_Utama.lbl_nama_user.Text = Rd.Item("nama_user")
                Hello.GunaLabel_username.Text = Rd.Item("nama_user")
                Hello.GunaLabel_lvl.Text = Rd.Item("lvl")
                Me.Hide()
                Menu_Utama.Show()
                Hello.Show()
            Else
                MessageBox.Show("Password atau Username Anda Salah")
            End If
        End If
    End Sub
End Class
