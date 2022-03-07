Imports System.Data.Odbc
Public Class Register
    Dim id As String
    Sub otomatis()
        Call koneksi()
        Dim hitung As Long
        Dim urutan As String
        Cmd = New OdbcCommand("select id_user from tbl_user order by id_user desc", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows = True Then
            urutan = "U" + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            urutan = "U" + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        id = urutan
    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call otomatis()
    End Sub

    Private Sub BtRegister_Click(sender As Object, e As EventArgs)
        If nama.Text = "" Or username.Text = "" Or password.Text = "" Or level.Text = "" Then
            MsgBox("Pastikan Semua Data Terisi !!")
        Else
            Call koneksi()
            Cmd = New OdbcCommand("select * from tbl_user where id_user='" & id & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = False Then
                Cmd = New OdbcCommand("insert into tbl_user values('" & id & _
                                       "','" & nama.Text & _
                                       "','" & username.Text & _
                                       "','" & password.Text & _
                                       "','" & level.Text & _
                                       "')", Conn)
                Cmd.ExecuteNonQuery()
            End If
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class