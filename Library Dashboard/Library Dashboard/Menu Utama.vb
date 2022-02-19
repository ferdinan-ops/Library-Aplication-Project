Imports System.Data.Odbc
Imports System.Windows.Forms.DataVisualization.Charting
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Menu_Utama
    Sub refresh_dashboard()
        panel_load.Refresh()
        Chart2.Update()
        Call koneksi()
        Call grafik_pinjam()
        Call tampil_total_kembali()
        Call pengaturan()
        Call id_pinjam_otomatis()
        Call clear_pinjam()
        txt_tanggal.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        dgv1.ReadOnly = True
        dgv1.Rows.Clear()
        'Panel Kembali'
        Call pengaturan_kembali()
        Call bersih_transaksi_kembali()
        txt_anggota_kembali.Clear()
        txt_nama_kembali.Clear()
        txt_anggota_kembali.Focus()
        Call id_kembali_otomatis()
        txt_tanggal_kembali.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Call bersih_anggota()
        Call hitung_total_denda()
        txt_dibayar.Text = 0
        txt_kembalian.Text = 0
        'Panel History'
        Call grafik_pinjam()
        Call tampil_history()
        dgv_history.Visible = True
        'Panel Load'
        Call clear()
        Call tampil_data_user()
        Call koneksi()
        Call jlh_kembali()
        Call bersih_input_data_buku()
        Call tampil_input_buku()
        Call tampil_input_anggota()
        Call jlh_anggota()
        Call jlh_buku()
        Call jlh_pinjam()
        Call tampil_diagram()
        Call tampil_hilang()
        Call tampil_utuh()
        Call total_diagram()
        Call tampil_grafik_lingkaran()
    End Sub

    Sub button()
        lblselected1.Visible = False
        lblselected2.Visible = False
        lblselected3.Visible = False
        lblselected4.Visible = False
        lblselected5.Visible = False
        lblselected6.Visible = False
        lblselected7.Visible = False
        panel_data_master.Visible = False
        panel_transaksi.Visible = False
        panel_laporan.Visible = False
        panel_lainnya.Visible = False
        panel_user.Visible = False
        panel_katalog.Visible = False
        panel_data_buku.Visible = False
        Panel_input_data_buku.Visible = False
        panel_data_anggota.Visible = False
        panel_input_anggota.Visible = False
        panel_tentang_aplikasi.Visible = False
        panel_peminjaman.Visible = False
        panel_pengembalian.Visible = False
        panel_history_kembali.Visible = False
        panel_load.Visible = False
        panel_rusak_kembali.Visible = False
        panel_lap_pinjam_hari.Visible = False
        panel_lap_kembali.Visible = False
    End Sub

    Sub grafik_pinjam()
        Call koneksi()
        Da = New OdbcDataAdapter("select * from jlh_peminjaman", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "jlh_peminjaman")
        Chart1.Series("Jumlah Pinjam").XValueMember = "id_buku"
        Chart1.Series("Jumlah Pinjam").YValueMembers = "jlh_pinjam"
        Chart1.DataSource = Ds.Tables("jlh_peminjaman")
    End Sub

    Sub tampil_grafik_lingkaran()
        With Me.Chart2
            .Legends.Clear()
            .Series.Clear()
            .ChartAreas.Clear()
        End With

        Dim areas2 As ChartArea = Me.Chart2.ChartAreas.Add("Areas1")

        With areas2
        End With

        Dim series2 As Series = Me.Chart2.Series.Add("Series1")
        With series2
            .ChartArea = areas2.Name
            .ChartType = SeriesChartType.Pie
            .Points.AddXY("Utuh", Val(lbl_utuh.Text))
            .Points.AddXY("Rusak", Val(lbl_rusak.Text))
            .Points.AddXY("Hilang", Val(lbl_hilang.Text))
            .Font = New Font("Poppins", 12, FontStyle.Bold)
            .LegendText = "#VALX (#PERCENT)"
            .LabelForeColor = Color.White
        End With
        Dim legends2 As Legend = Me.Chart2.Legends.Add("Legends1")
    End Sub

    Sub jlh_buku()
        Dim jumlah_data As Integer = 0
        For t As Integer = 0 To dgv_data_buku.RowCount - 1
            jumlah_data = jumlah_data + Val(dgv_data_buku.Rows(t).Cells(6).Value)
        Next
        label_jlh_buku.Text = jumlah_data
    End Sub

    Sub jlh_anggota()
        Dim jumlah_data2 As Integer
        jumlah_data2 = dgv_data_anggota.RowCount
        label_anggota_load.Text = jumlah_data2 - 1
    End Sub

    Sub jlh_pinjam()
        Dim jumlah_data3 As Integer
        jumlah_data3 = dgv_history.RowCount
        label_pinjam_load.Text = jumlah_data3 - 1
    End Sub

    Sub jlh_kembali()
        Dim jumlah As Integer
        jumlah = dgv_total_kembali.RowCount
        label_kembali_load.Text = jumlah - 1
    End Sub

    Sub total_diagram()
        Dim utuh As Integer
        utuh = dgv_utuh.RowCount
        lbl_utuh.Text = utuh - 1

        Dim rusak As Integer
        rusak = dgv_diagram.RowCount
        lbl_rusak.Text = rusak - 1

        Dim hilang As Integer
        hilang = dgv_hilang.RowCount
        lbl_hilang.Text = hilang - 1

        Dim total As Integer
        Dim jlh_utuh As Double
        Dim jlh_rusak As Double
        Dim jlh_hilang As Double
        total = Val(lbl_hilang.Text) + Val(lbl_rusak.Text) + Val(lbl_utuh.Text)
        jlh_utuh = (100 * Val(lbl_utuh.Text)) / total
        lbl_utuh.Text = jlh_utuh
        jlh_rusak = (100 * Val(lbl_rusak.Text)) / total
        lbl_rusak.Text = jlh_rusak
        jlh_hilang = (100 * Val(lbl_hilang.Text)) / total
        lbl_hilang.Text = jlh_hilang
    End Sub

    Private Sub Menu_Utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call refresh_dashboard()
        Call button()
        panel_load.Visible = True
        lbl_tgl.Text = Format(Now, "hh:mm tt")
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
    End Sub

    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        lblselected1.Visible = False
        lblselected2.Visible = False
        lblselected3.Visible = False
        lblselected4.Visible = False
        lblselected5.Visible = False
        lblselected6.Visible = True
        lblselected7.Visible = False
        Dim tanya
        tanya = MessageBox.Show("Anda Yakin Ingin Logout ??", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tanya = vbYes Then
            End
        End If
    End Sub

    Private Sub btndatamaster_Click(sender As Object, e As EventArgs) Handles btndatamaster.Click
        Call button()
        Call refresh_dashboard()
        panel_data_master.Visible = True
        lblselected1.Visible = True
    End Sub

    Private Sub Label84_Click(sender As Object, e As EventArgs) Handles Label84.Click
        Call button()
        Call refresh_dashboard()
        panel_load.Visible = True
        lblselected7.Visible = True
    End Sub

    Private Sub btntransaksi_Click(sender As Object, e As EventArgs) Handles btntransaksi.Click
        Call button()
        Call refresh_dashboard()
        panel_transaksi.Visible = True
        lblselected2.Visible = True
    End Sub

    Private Sub btnlaporan_Click(sender As Object, e As EventArgs) Handles btnlaporan.Click
        Call button()
        Call refresh_dashboard()
        panel_laporan.Visible = True
        lblselected3.Visible = True
    End Sub

    Private Sub btnlainnya_Click(sender As Object, e As EventArgs) Handles btnlainnya.Click
        Call button()
        Call refresh_dashboard()
        lblselected4.Visible = True
        panel_lainnya.Visible = True
    End Sub

    Private Sub btnabout_Click(sender As Object, e As EventArgs) Handles btnabout.Click
        Call button()
        Call refresh_dashboard()
        lblselected5.Visible = True
        panel_tentang_aplikasi.Visible = True
    End Sub

    Private Sub btn_user_Click(sender As Object, e As EventArgs) Handles btn_user.Click
        Call button()
        Call refresh_dashboard()
        panel_user.Visible = True
        lblselected1.Visible = True
    End Sub

    Private Sub btn_buku_Click(sender As Object, e As EventArgs) Handles btn_buku.Click
        Call button()
        Call refresh_dashboard()
        lblselected1.Visible = True
        Panel_input_data_buku.Visible = True
    End Sub

    Private Sub btn_anggota_Click(sender As Object, e As EventArgs) Handles btn_anggota.Click
        Call button()
        lblselected1.Visible = True
        panel_input_anggota.Visible = True
    End Sub

    Private Sub btn_katalog_Click(sender As Object, e As EventArgs) Handles btn_katalog.Click
        Call button()
        lblselected1.Visible = True
        panel_katalog.Visible = True
    End Sub

    Private Sub btn_pinjam_Click(sender As Object, e As EventArgs) Handles btn_pinjam.Click
        Call button()
        lblselected2.Visible = True
        panel_peminjaman.Visible = True
    End Sub

    Private Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Call button()
        lblselected2.Visible = True
        panel_pengembalian.Visible = True
    End Sub

    Private Sub btn_history_Click(sender As Object, e As EventArgs) Handles btn_history.Click
        Call button()
        lblselected2.Visible = True
        panel_history_kembali.Visible = True
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        Call button()
        lblselected3.Visible = True
        panel_lap_pinjam_hari.Visible = True
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        Call button()
        lblselected3.Visible = True
        panel_lap_kembali.Visible = True
    End Sub

    Private Sub btn_cari_buku_Click(sender As Object, e As EventArgs) Handles btn_cari_buku.Click
        Call button()
        lblselected4.Visible = True
        panel_data_buku.Visible = True
    End Sub

    Private Sub btn_cari_anggota_Click(sender As Object, e As EventArgs) Handles btn_cari_anggota.Click
        Call button()
        lblselected4.Visible = True
        panel_data_anggota.Visible = True
    End Sub

    'DATA MASTER USER
    Private Sub btn_id_buku_Click(sender As Object, e As EventArgs) Handles btn_id_buku.Click
        If Not TextBox1_id_user.Text = "" Then
            MessageBox.Show("Create ID hanya untuk mendaftar")
        Else
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
            TextBox1_id_user.Text = urutan
            TextBox1_id_user.ReadOnly = True
        End If
    End Sub

    Sub tampil_data_user()
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_user", Conn)
        Rd = Cmd.ExecuteReader
        dgv_data_user.Rows.Clear()
        Do While Rd.Read = True
            dgv_data_user.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4))
        Loop
    End Sub
    Sub clear()
        TextBox1_id_user.Clear()
        TextBox2_nama_user.Clear()
        TextBox3_username.Clear()
        TextBox4_password.Clear()
        ComboBox1_level.Text = ""
        TextBox1_id_user.ReadOnly = False
        TextBox1_id_user.Focus()
    End Sub
    Private Sub save_data_user_Click(sender As Object, e As EventArgs) Handles save_data_user.Click
        If TextBox1_id_user.Text = "" Or TextBox2_nama_user.Text = "" Or TextBox3_username.Text = "" Or TextBox4_password.Text = "" Or ComboBox1_level.Text = "" Then
            MsgBox("Pastikan Semua Data Terisi !!")
        Else
            Call koneksi()
            Cmd = New OdbcCommand("select * from tbl_user where id_user='" & TextBox1_id_user.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = False Then
                Cmd = New OdbcCommand("insert into tbl_user values('" & TextBox1_id_user.Text & _
                                       "','" & TextBox2_nama_user.Text & _
                                       "','" & TextBox3_username.Text & _
                                       "','" & TextBox4_password.Text & _
                                       "','" & ComboBox1_level.Text & _
                                       "')", Conn)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Di Tambahkan")
                Call clear()
                Call tampil_data_user()
            Else
                Cmd = New OdbcCommand("update tbl_user set nama_user = '" & TextBox2_nama_user.Text & _
                                       "', username = '" & TextBox3_username.Text & _
                                       "', pwd = '" & TextBox4_password.Text & _
                                       "', lvl = '" & ComboBox1_level.Text & _
                                       "' where id_user = '" & TextBox1_id_user.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Di Edit")
                Call clear()
                Call tampil_data_user()
            End If
        End If
    End Sub

    Private Sub btn_delete_user_Click(sender As Object, e As EventArgs) Handles btn_delete_user.Click
        Call koneksi()
        If MessageBox.Show("Apakah Anda Ingin Menghapus Data..??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Cmd = New OdbcCommand("delete from tbl_user where id_user= '" & TextBox1_id_user.Text & "'", Conn)
            Cmd.ExecuteNonQuery()
            Cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Di Hapus")
            Call koneksi()
            Call clear()
            Call tampil_data_user()
        End If
    End Sub

    Private Sub TextBox1_id_user_TextChanged(sender As Object, e As EventArgs) Handles TextBox1_id_user.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_user where id_user = '" & TextBox1_id_user.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            TextBox2_nama_user.Text = Rd(1)
            TextBox3_username.Text = Rd(2)
            TextBox4_password.Text = Rd(3)
            ComboBox1_level.Text = Rd(4)
        Else
            TextBox2_nama_user.Clear()
            TextBox3_username.Clear()
            TextBox4_password.Clear()
            ComboBox1_level.Text = ""
        End If
    End Sub

    'DATA MASTER BUKU
    Private Sub btn_id_user_Click(sender As Object, e As EventArgs) Handles btn_id_user.Click
        If Not textbox_id_buku.Text = "" Then
            MessageBox.Show("Create ID hanya untuk mendaftar")
        Else
            Call koneksi()
            Dim hitung2 As Long
            Dim urutan2 As String
            Cmd = New OdbcCommand("select id_buku from tbl_buku order by id_buku desc", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows = True Then
                urutan2 = "B" + "001"
            Else
                hitung2 = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                urutan2 = "B" + Microsoft.VisualBasic.Right("000" & hitung2, 3)
            End If
            textbox_id_buku.Text = urutan2
            textbox_id_buku.ReadOnly = True
        End If
    End Sub

    Sub tampil_input_buku()
        Cmd = New OdbcCommand("select * from tbl_buku", Conn)
        Rd = Cmd.ExecuteReader
        dgv_input_buku.Rows.Clear()
        dgv_data_buku.Rows.Clear()
        Do While Rd.Read = True
            dgv_input_buku.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6), Rd(7), Rd(8), Rd(9))
            dgv_data_buku.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6), Rd(7), Rd(8), Rd(9))
        Loop
    End Sub
    Sub bersih_input_data_buku()
        textbox_id_buku.Clear()
        textbox_judul_buku.Clear()
        textbox_pengarang.Clear()
        textbox_penerbit.Clear()
        textbox_kategori.Clear()
        textbox_stok.Clear()
        textbox_harga_buku.Clear()
        combobox_tahun.Text = ""
        combobox_lokasi.Text = ""
        datetimepicker_tanggal_masuk.Text = ""
        textbox_id_buku.ReadOnly = False
        textbox_id_buku.Focus()
    End Sub

    Private Sub btn_save_input_data_buku_Click(sender As Object, e As EventArgs) Handles btn_save_input_data_buku.Click
        If textbox_id_buku.Text = "" Or textbox_judul_buku.Text = "" Or textbox_pengarang.Text = "" Or textbox_penerbit.Text = "" Or textbox_kategori.Text = "" Or textbox_stok.Text = "" Or textbox_harga_buku.Text = "" Or combobox_tahun.Text = "" Or combobox_lokasi.Text = "" Or datetimepicker_tanggal_masuk.Text = "" Then

            MessageBox.Show("Data Anda Belum Lengkap !!")
        Else
            Cmd = New OdbcCommand("select*from tbl_buku where id_buku='" & textbox_id_buku.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = False Then
                Cmd = New OdbcCommand("insert into tbl_buku values('" & textbox_id_buku.Text & _
                                       "','" & textbox_judul_buku.Text & _
                                       "','" & textbox_pengarang.Text & _
                                       "','" & textbox_penerbit.Text & _
                                       "','" & textbox_kategori.Text & _
                                       "','" & combobox_tahun.Text & _
                                       "','" & textbox_stok.Text & _
                                       "','" & combobox_lokasi.Text & _
                                       "','" & datetimepicker_tanggal_masuk.Text & _
                                       "','" & textbox_harga_buku.Text & _
                                       "')", Conn)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Di Simpan !!")
                Call bersih_input_data_buku()
                Call tampil_input_buku()
            Else
                Cmd = New OdbcCommand("update tbl_buku set judul = '" & textbox_judul_buku.Text & _
                                      "', pengarang = '" & textbox_pengarang.Text & _
                                      "', penerbit = '" & textbox_penerbit.Text & _
                                      "', kategori = '" & textbox_kategori.Text & _
                                      "', tahun = '" & combobox_tahun.Text & _
                                      "', stok = '" & textbox_stok.Text & _
                                      "', lokasi = '" & combobox_lokasi.Text & _
                                      "', tanggal_masuk = '" & datetimepicker_tanggal_masuk.Text & _
                                      "', harga_buku = '" & textbox_harga_buku.Text & _
                                      "' where id_buku = '" & textbox_id_buku.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Di Edit")
                Call bersih_input_data_buku()
                Call tampil_input_buku()
            End If
        End If
    End Sub

    Private Sub btn_delete_input_data_buku_Click(sender As Object, e As EventArgs) Handles btn_delete_input_data_buku.Click
        If MessageBox.Show("Apakah Anda Ingin Menghapus Data..??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Cmd = New OdbcCommand("delete from tbl_buku where id_buku= '" & textbox_id_buku.Text & "'", Conn)
            Cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Di Hapus")
            Call bersih_input_data_buku()
            Call tampil_input_buku()
        End If
    End Sub

    Private Sub textbox_id_buku_TextChanged(sender As Object, e As EventArgs) Handles textbox_id_buku.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_buku where id_buku = '" & textbox_id_buku.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            textbox_judul_buku.Text = Rd(1)
            textbox_pengarang.Text = Rd(2)
            textbox_penerbit.Text = Rd(3)
            textbox_kategori.Text = Rd(4)
            combobox_tahun.Text = Rd(5)
            textbox_stok.Text = Rd(6)
            combobox_lokasi.Text = Rd(7)
            datetimepicker_tanggal_masuk.Text = Rd(8)
            textbox_harga_buku.Text = Rd(9)
        Else
            textbox_judul_buku.Clear()
            textbox_pengarang.Clear()
            textbox_penerbit.Clear()
            textbox_kategori.Clear()
            textbox_stok.Clear()
            textbox_harga_buku.Clear()
            combobox_tahun.Text = ""
            combobox_lokasi.Text = ""
            datetimepicker_tanggal_masuk.Text = ""
        End If
    End Sub

    'DATA MASTER ANGGOTA
    Sub tampil_input_anggota()
        Cmd = New OdbcCommand("select * from tbl_anggota", Conn)
        Rd = Cmd.ExecuteReader
        dgv_input_anggota.Rows.Clear()
        dgv_data_anggota.Rows.Clear()
        Do While Rd.Read = True
            dgv_input_anggota.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4))
            dgv_data_anggota.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4))
        Loop
    End Sub
    Sub bersih_input_data_anggota()
        textbox_id_anggota.Clear()
        textbox_nama.Clear()
        textbox_alamat.Clear()
        textbox_telepon.Clear()
        textbox_email.Clear()
        textbox_id_anggota.ReadOnly = False
        textbox_id_anggota.Focus()
    End Sub
    Private Sub btn_id_anggota_Click(sender As Object, e As EventArgs) Handles btn_id_anggota.Click
        If Not textbox_id_buku.Text = "" Then
            MessageBox.Show("Create ID hanya untuk mendaftar")
        Else
            Call koneksi()
            Dim hitung2 As Long
            Dim urutan2 As String
            Cmd = New OdbcCommand("select id_buku from tbl_buku order by id_buku desc", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows = True Then
                urutan2 = "B" + "001"
            Else
                hitung2 = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                urutan2 = "B" + Microsoft.VisualBasic.Right("000" & hitung2, 3)
            End If
            textbox_id_buku.Text = urutan2
            textbox_id_buku.ReadOnly = True
        End If
    End Sub

    Private Sub btn_save_input_data_anggota_Click(sender As Object, e As EventArgs) Handles btn_save_input_data_anggota.Click
        If textbox_id_anggota.Text = "" Or textbox_nama.Text = "" Or textbox_alamat.Text = "" Or textbox_telepon.Text = "" Or textbox_email.Text = "" Then
            MessageBox.Show("Data Anda Belum Lengkap !!")
        Else
            Cmd = New OdbcCommand("select*from tbl_anggota where id_anggota='" & textbox_id_anggota.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = False Then
                Cmd = New OdbcCommand("insert into tbl_anggota values('" & textbox_id_anggota.Text & _
                                       "','" & textbox_nama.Text & _
                                       "','" & textbox_alamat.Text & _
                                       "','" & textbox_telepon.Text & _
                                       "','" & textbox_email.Text & _
                                       "')", Conn)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Di Simpan !!")
                Call bersih_input_data_anggota()
                Call tampil_input_anggota()
            Else
                Cmd = New OdbcCommand("update tbl_anggota set nama_anggota = '" & textbox_nama.Text & _
                                      "', alamat = '" & textbox_alamat.Text & _
                                      "', telepon = '" & textbox_telepon.Text & _
                                      "', email = '" & textbox_email.Text & _
                                      "' where id_anggota = '" & textbox_id_anggota.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Di Edit")
                Call bersih_input_data_anggota()
                Call tampil_input_anggota()
            End If
        End If
    End Sub

    Private Sub btn_delete_input_data_anggota_Click(sender As Object, e As EventArgs) Handles btn_delete_input_data_anggota.Click
        If MessageBox.Show("Apakah Anda Ingin Menghapus Data..??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Cmd = New OdbcCommand("delete from tbl_anggota where id_anggota= '" & textbox_id_anggota.Text & "'", Conn)
            Cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Di Hapus")
            Call bersih_input_data_anggota()
            Call tampil_input_anggota()
        End If
    End Sub

    Private Sub textbox_id_anggota_TextChanged(sender As Object, e As EventArgs) Handles textbox_id_anggota.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_anggota where id_anggota = '" & textbox_id_anggota.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            textbox_nama.Text = Rd(1)
            textbox_alamat.Text = Rd(2)
            textbox_telepon.Text = Rd(3)
            textbox_email.Text = Rd(4)
        Else
            textbox_nama.Clear()
            textbox_alamat.Clear()
            textbox_telepon.Clear()
            textbox_email.Clear()
        End If
    End Sub

    'DATA MASTER KATALOG
    Sub tampil_katalog()
        Cmd = New OdbcCommand("select * from tbl_buku", Conn)
        Rd = Cmd.ExecuteReader
        dgv_katalog.Rows.Clear()
        Do While Rd.Read = True
            dgv_katalog.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6), Rd(7), Rd(8), Rd(9))
        Loop
    End Sub

    Private Sub TextBox_katalog_TextChanged(sender As Object, e As EventArgs) Handles TextBox_katalog.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_buku where judul like '%" & TextBox_katalog.Text & "%' or pengarang like '%" & TextBox_katalog.Text & "%' or penerbit like '%" & TextBox_katalog.Text & "%' ", Conn)
        Rd = Cmd.ExecuteReader
        dgv_katalog.Rows.Clear()
        Do While Rd.Read = True
            dgv_katalog.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6), Rd(7), Rd(8), Rd(9))
        Loop
    End Sub

    'TRANSAKSI PEMINJAMAN
    Sub id_pinjam_otomatis()
        Call koneksi()
        Cmd = New OdbcCommand("select id_pinjam from tbl_pinjam order by id_pinjam desc", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows = True Then
            txt_idpinjam.Text = "PJ" + Format(Today, "yyMMdd") + "01"
        Else
            If Microsoft.VisualBasic.Mid(Rd.Item("id_pinjam"), 3, 6) = Format(Today, "yyMMdd") Then
                txt_idpinjam.Text = "PJ" + Format(Microsoft.VisualBasic.Right(Rd.Item("id_pinjam"), 8) + 1, "0")
            Else
                txt_idpinjam.Text = "PJ" + Format(Today, "yyMMdd") + "01"
            End If
        End If
    End Sub
    Sub clear_pinjam()
        txt_anggota.Clear()
        txt_nama.Clear()
        txt_pernahpinjam.Text = "0"
        txt_jumlah.Clear()
        txt_totalpinjam.Text = "0"
        txt_pinjamansekarang.Text = "0"
        txt_idbuku.Clear()
        txt_judul.Clear()
        txt_pengarang.Clear()
        txt_penerbit.Clear()
        txt_tahun.Clear()
        txt_kategori.Clear()
        txt_anggota.Focus()
        dgv1.Rows.Clear()

    End Sub
    Sub clear_transaksi()
        txt_idbuku.Clear()
        txt_judul.Clear()
        txt_pengarang.Clear()
        txt_jumlah.Clear()
        txt_tahun.Clear()
        txt_penerbit.Clear()
        txt_kategori.Clear()
        txt_idbuku.Focus()
    End Sub
    Sub pengaturan()
        Cmd = New OdbcCommand("select* from tbl_pengaturan where id='1'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            txt_bataspinjaman.Text = Rd.Item("batas_buku")
        End If
    End Sub

    Private Sub txt_anggota_TextChanged(sender As Object, e As EventArgs) Handles txt_anggota.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select*from tbl_anggota where id_anggota= '" & txt_anggota.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            txt_nama.Text = Rd.Item("nama_anggota")
            Da = New OdbcDataAdapter("select tbl_pinjam_detail.id_pinjam,tbl_pinjam_detail.id_buku,tbl_buku.judul,pengarang,penerbit from tbl_pinjam_detail,tbl_pinjam,tbl_buku where tbl_pinjam_detail.id_pinjam=tbl_pinjam.id_pinjam and tbl_buku.id_buku=tbl_pinjam_detail.id_buku and tbl_pinjam.id_anggota='" & txt_anggota.Text & "'and tbl_pinjam_detail.keterangan='dipinjam'", Conn)
            Ds = New DataSet
            Da.Fill(Ds)
            dgv2.DataSource = Ds.Tables(0)
            dgv2.ReadOnly = True
            dgv2.Columns(0).HeaderText = "ID Pinjam"
            dgv2.Columns(1).HeaderText = "ID Buku"
            dgv2.Columns(2).HeaderText = "Judul Buku"
            txt_pernahpinjam.Text = dgv2.RowCount - 1
            If Val(txt_pernahpinjam.Text) >= Val(txt_bataspinjaman.Text) Then
                MessageBox.Show("PINJAMAN SUDAH MAKSIMAL, ANGGOTA INI TIDAK DIPERBOLEHKAN LAGI MEMINJAM BUKU !!")
                dgv1.Rows.Clear()
                Call clear_pinjam()
                Call clear_transaksi()
                txt_anggota.Focus()
            End If
        Else
            txt_nama.Clear()
            txt_pernahpinjam.Text = "0"
            txt_jumlah.Clear()
            txt_pinjamansekarang.Text = "0"
        End If
    End Sub

    Private Sub txt_idbuku_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_idbuku.KeyPress
        If e.KeyChar = Chr(13) Then
            Cmd = New OdbcCommand("select * from tbl_buku where id_buku='" & txt_idbuku.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                txt_judul.Text = Rd.Item("judul")
                txt_pengarang.Text = Rd.Item("pengarang")
                txt_penerbit.Text = Rd.Item("penerbit")
                txt_kategori.Text = Rd.Item("kategori")
                txt_tahun.Text = Rd.Item("tahun")
                txt_jumlah.Text = 1
                txt_jumlah.Focus()
                If Val(Rd.Item("stok")) = 0 Then
                    MessageBox.Show("Stok Buku Kosong")
                    Call clear_transaksi()
                End If
            Else
                MessageBox.Show("Kode Buku Anda Belum Terdaftar")
                Call clear_transaksi()
            End If
        End If
    End Sub

    Private Sub txt_jumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_jumlah.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txt_jumlah.Text) < 1 Then
                MessageBox.Show("Anggota Hanya Dapat Meminjam Satu Buah Buku")
                txt_jumlah.Text = 1
                Exit Sub
            End If
            If txt_anggota.Text = "" Or txt_nama.Text = "" Then
                MessageBox.Show("Isi Data Anggota Terlebih Dahulu...!!")
                Exit Sub
            End If
            If Val(txt_totalpinjam.Text) >= Val(txt_bataspinjaman.Text) Then
                MessageBox.Show("Pinjaman Anda Sudah Melebihi Batas")
                Call clear_transaksi()
                Exit Sub
            End If

            Dim baris1 As Integer = dgv1.RowCount - 1
            Dim id_buku As String = txt_idbuku.Text

            Cmd = New OdbcCommand("select id_buku from tbl_pinjam_detail,tbl_pinjam,tbl_anggota where tbl_pinjam.id_pinjam=tbl_pinjam_detail.id_pinjam and tbl_pinjam.id_anggota=tbl_anggota.id_anggota and tbl_pinjam_detail.id_buku='" & id_buku & "'and tbl_pinjam.id_anggota='" & txt_anggota.Text & "'and tbl_pinjam_detail.keterangan='Dipinjam'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                MessageBox.Show("Buku Ini Sedang Dipinjam..!!")
                Exit Sub
            End If
            Cmd = New OdbcCommand("select*from tbl_buku where id_buku='" & txt_idbuku.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                dgv1.Rows.Add(txt_idbuku.Text, txt_judul.Text, txt_pengarang.Text, txt_penerbit.Text, txt_kategori.Text, txt_tahun.Text, txt_jumlah.Text)
                Call clear_transaksi()

                For barisatas As Integer = 0 To dgv1.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To dgv1.RowCount - 1
                        If dgv1.Rows(barisbawah).Cells(0).Value = dgv1.Rows(barisatas).Cells(0).Value Then
                            MessageBox.Show("Buku Ini Sudah ada DI transaksi")
                            dgv1.Rows.RemoveAt(barisbawah)
                            Exit Sub
                        End If
                    Next
                Next
            End If

            txt_pinjamansekarang.Text = dgv1.RowCount - 1
            txt_totalpinjam.Text = Val(txt_pernahpinjam.Text) + Val(txt_pernahpinjam.Text)

        End If
    End Sub

    Private Sub txt_jumlah_TextChanged(sender As Object, e As EventArgs) Handles txt_jumlah.TextChanged
        If Val(txt_jumlah.Text) > 1 Then
            MessageBox.Show("Anggota Hanya Dapat Meminjam Satu Buah Buku !!")
            txt_jumlah.Text = 1
        End If
    End Sub


    Private Sub btn_save_pinjam_Click(sender As Object, e As EventArgs) Handles btn_save_pinjam.Click
        If txt_anggota.Text = "" Or txt_nama.Text = "" Or txt_pinjamansekarang.Text = 0 Then
            MessageBox.Show("Data Transaksi Belum Lengkap, Periksa Kembali...!!")
            Exit Sub
        End If
        Cmd = New OdbcCommand("insert into tbl_pinjam values('" & txt_idpinjam.Text & "','" & txt_tanggal.Text & "','" & txt_anggota.Text & "')", Conn)
        Cmd.ExecuteNonQuery()

        For baris As Integer = 0 To dgv1.RowCount - 2
            Cmd = New OdbcCommand("insert into tbl_pinjam_detail values('" & txt_idpinjam.Text & "','" & dgv1.Rows(baris).Cells(0).Value & "','Dipinjam',1)", Conn)
            Cmd.ExecuteNonQuery()

            Cmd = New OdbcCommand("select*from tbl_buku where id_buku='" & dgv1.Rows(baris).Cells(0).Value & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                Cmd = New OdbcCommand("update tbl_buku set stok='" & Rd.Item("stok") - 1 & "' where id_buku='" & dgv1.Rows(baris).Cells(0).Value & "'", Conn)
                Cmd.ExecuteNonQuery()
            End If
        Next


        MessageBox.Show("Transaksi Peminjaman Berhasil Disimpan")
        Dim tanya
        tanya = MessageBox.Show("Lihat Nota Peminjaman Buku ?", "Tidak", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tanya = vbYes Then
            Try
                Dim crypt As New ReportDocument
                Dim crtablelogoninfos As New TableLogOnInfos
                Dim crtablelogoninfo As New TableLogOnInfo
                Dim crconnectioninfo As New ConnectionInfo
                Dim crtables As Tables
                Dim crtable As Table
                Dim laporan As New struk_pinjam

                crypt = laporan

                With crconnectioninfo
                    .ServerName = "dsn_perpustakaan"
                    .DatabaseName = "db_perpustakaan"
                    .UserID = ""
                    .Password = ""
                End With
                crtables = crypt.Database.Tables
                For Each crtable In crtables
                    crtablelogoninfo = crtable.LogOnInfo
                    crtablelogoninfo.ConnectionInfo = crconnectioninfo
                    crtable.ApplyLogOnInfo(crtablelogoninfo)
                Next
                struk_peminjaman.CrystalReportViewer1.SelectionFormula = "({tbl_anggota1.id_anggota})='" & txt_anggota.Text & "' and ({tbl_pinjam_detail1.keterangan})='Dipinjam'"
                struk_peminjaman.CrystalReportViewer1.ReportSource = crypt
                struk_peminjaman.CrystalReportViewer1.Refresh()
                struk_peminjaman.CrystalReportViewer1.RefreshReport()
            Catch ex As Exception
            End Try
            struk_peminjaman.ShowDialog()
        Else
            Call clear_pinjam()
            Call clear_transaksi()
            Call id_pinjam_otomatis()
            dgv1.Rows.Clear()
            dgv2.Columns.Clear()
            Call grafik_pinjam()
        End If
    End Sub

    'TRANSAKSI PENGEMBALIAN
    Sub bersih_transaksi_kembali()
        txt_idbuku_kembali.Clear()
        txt_judul_kembali.Clear()
        txt_tglpinjam.Clear()
        txt_idpinjam_kembali.Clear()
        txt_denda.Clear()
        txt_lamapinjam.Clear()
        txt_terlambat.Clear()
        cb_hilang.Text = ""
        cb_rusak.Text = ""
        txt_idbuku.Focus()
    End Sub
    Sub id_kembali_otomatis()
        Call koneksi()
        Cmd = New OdbcCommand("select id_kembali from tbl_kembali order by id_kembali desc", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows = True Then
            txt_idkembali.Text = "KB" + Format(Today, "yyMMdd") + "01"
        Else
            If Microsoft.VisualBasic.Mid(Rd.Item("id_kembali"), 3, 6) = Format(Today, "yyMMdd") Then
                txt_idkembali.Text = "KB" + Format(Microsoft.VisualBasic.Right(Rd.Item("id_kembali"), 8) + 1, "0")
            Else
                txt_idkembali.Text = "KB" + Format(Today, "yyMMdd") + "01"
            End If
        End If
    End Sub
    Sub bersih_anggota()
        txt_anggota_kembali.Clear()
        txt_nama_kembali.Clear()
        txt_alamat.Clear()
        txt_notelpon.Clear()
        txt_anggota_kembali.Focus()
    End Sub
    Sub pengaturan_kembali()
        Cmd = New OdbcCommand("select* from tbl_pengaturan where id='1'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            txt_bataspinjaman_kembali.Text = Rd.Item("batas_buku")
            txt_dendaperhari.Text = Rd.Item("denda_hari")
            txt_dendarusak.Text = Rd.Item("denda_rusak")
        End If
    End Sub
    Sub hitung_total_denda()
        Dim hitung As Integer
        For baris As Integer = 0 To dgv1_kembali.RowCount - 1
            hitung = hitung + dgv1_kembali.Rows(baris).Cells(8).Value
        Next
        txt_totaldenda.Text = hitung

    End Sub

    Private Sub txt_anggota_kembali_TextChanged(sender As Object, e As EventArgs) Handles txt_anggota_kembali.TextChanged
        Cmd = New OdbcCommand("select*from tbl_anggota where id_anggota='" & txt_anggota_kembali.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            txt_nama_kembali.Text = Rd.Item("nama_anggota")
            txt_alamat.Text = Rd.Item("alamat")
            txt_notelpon.Text = Rd.Item("telepon")
        Else
            txt_nama_kembali.Clear()
            txt_alamat.Clear()
            txt_notelpon.Clear()
        End If
    End Sub

    Private Sub btn_clear_kembali_Click(sender As Object, e As EventArgs)
        Call bersih_anggota()
        Call bersih_transaksi_kembali()
        dgv1_kembali.Rows.Clear()
        Call hitung_total_denda()
        txt_dibayar.Clear()
        txt_kembalian.Clear()
    End Sub

    Private Sub txt_idbuku_kembali_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_idbuku_kembali.KeyPress
        If e.KeyChar = Chr(13) Then

            Cmd = New OdbcCommand("select distinct tbl_buku.id_buku,judul,tbl_pinjam_detail.id_pinjam,keterangan,tbl_pinjam.tanggal_pinjam from tbl_anggota,tbl_pinjam,tbl_buku,tbl_pinjam_detail where tbl_buku.id_buku=tbl_pinjam_detail.id_buku and tbl_pinjam.id_pinjam=tbl_pinjam_detail.id_pinjam and tbl_anggota.id_anggota=tbl_pinjam.id_anggota and tbl_anggota.id_anggota='" & txt_anggota_kembali.Text & "' and tbl_pinjam_detail.id_buku='" & txt_idbuku_kembali.Text & "' and tbl_pinjam_detail.keterangan='Dipinjam'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                txt_judul_kembali.Text = Rd.Item("judul")
                txt_tglpinjam.Text = Format(DateValue(Rd.Item("tanggal_pinjam")), "yyyy/MM/dd")

                Dim tgl1 As Date
                tgl1 = Format(DateValue(Rd.Item("tanggal_pinjam")), "yyyy/MM/dd")
                If txt_tglpinjam.Text = Format(Now, "yyyy/MM/dd HH:mm:ss") Then
                    txt_lamapinjam.Text = 1
                Else
                    txt_lamapinjam.Text = DateAndTime.DateDiff(DateInterval.Day, tgl1, Now())
                End If

                If Val(txt_lamapinjam.Text) <= Val(txt_bataspinjaman.Text) Then
                    txt_terlambat.Text = 0
                    txt_denda.Text = 0
                Else
                    txt_terlambat.Text = Val(txt_lamapinjam.Text) - Val(txt_bataspinjaman.Text)
                    txt_denda.Text = Val(txt_dendaperhari.Text) * Val(txt_terlambat.Text)
                End If
                txt_idpinjam_kembali.Text = Rd.Item("id_pinjam")
                cb_hilang.Text = "Tidak"
                cb_rusak.Text = "Tidak"
                cb_rusak.Focus()
            Else
                MessageBox.Show("Anggota Ini Tidak Pernah Meminjam Buku Ini")
                Call bersih_transaksi_kembali()
            End If
        End If
    End Sub

    Private Sub cb_rusak_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_rusak.SelectedIndexChanged
        If cb_rusak.Text = "Ya" Then
            cb_hilang.Text = "Tidak"
            txt_denda.Text = (Val(txt_dendaperhari.Text) * Val(txt_terlambat.Text)) + Val(txt_dendarusak.Text)
        Else
            txt_denda.Text = Val(txt_dendaperhari.Text) * Val(txt_terlambat.Text)

        End If
    End Sub

    Private Sub cb_hilang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_hilang.SelectedIndexChanged
        If cb_hilang.Text = "Ya" Then
            cb_rusak.Text = "Tidak"
            Cmd = New OdbcCommand("select*from tbl_buku where id_buku='" & txt_idbuku_kembali.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows = True Then
                txt_denda.Text = (Val(txt_dendaperhari.Text) * Val(txt_terlambat.Text)) + Val(Rd.Item("harga_buku"))
            End If
        Else
            txt_denda.Text = Val(txt_dendaperhari.Text) * Val(txt_terlambat.Text)
        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        If txt_anggota_kembali.Text = "" Or txt_nama_kembali.Text = "" Or txt_alamat.Text = "" Then
            MessageBox.Show("Data Anggota Belum Diisi")
        ElseIf txt_idbuku_kembali.Text = "" Or txt_judul_kembali.Text = "" Then
            MessageBox.Show("Data Buku Belum Diisi")
        Else
            dgv1_kembali.Rows.Add(txt_idbuku_kembali.Text, txt_judul_kembali.Text, txt_tglpinjam.Text, txt_idpinjam_kembali.Text, txt_lamapinjam.Text, txt_terlambat.Text, cb_rusak.Text, cb_hilang.Text, txt_denda.Text)
            For baris_atas As Integer = 0 To dgv1_kembali.RowCount - 1
                For baris_bawah As Integer = baris_atas + 1 To dgv1_kembali.RowCount - 1
                    If dgv1_kembali.Rows(baris_bawah).Cells(0).Value = dgv1_kembali.Rows(baris_atas).Cells(0).Value Then
                        MessageBox.Show("Buku Sedang Dalam Proses Pengembalian !!!")
                        dgv1_kembali.Rows.RemoveAt(baris_bawah)
                        Call bersih_transaksi_kembali()
                        Exit Sub
                    End If
                Next
            Next
            Call bersih_transaksi_kembali()
            Call hitung_total_denda()
            txt_idbuku_kembali.ReadOnly = True
            Button8.Enabled = False
            btn_save_kembali.Focus()
        End If
    End Sub

    Private Sub txt_dibayar_TextChanged(sender As Object, e As EventArgs) Handles txt_dibayar.TextChanged
        Try
            txt_kembalian.Text = Val(txt_dibayar.Text) - Val(txt_totaldenda.Text)
        Catch ex As Exception
            txt_kembalian.Text = 0
        End Try
    End Sub

    Private Sub btn_save_kembali_Click_1(sender As Object, e As EventArgs) Handles btn_save_kembali.Click
        If txt_anggota_kembali.Text = "" Or txt_nama_kembali.Text = "" Or dgv1_kembali.RowCount - 1 = 0 Then
            MessageBox.Show("Transaksi Belum Lengkap ,Cek Kembali")
        ElseIf Val(txt_dibayar.Text) < Val(txt_totaldenda.Text) Then
            MessageBox.Show("Pembayaran Masih Kurang")
        ElseIf txt_dibayar.Text = "" Then
            MessageBox.Show("Transaksi Dibayar Masih Kosong")
        Else
            Cmd = New OdbcCommand("insert into tbl_kembali values('" & txt_idkembali.Text & "','" & txt_tanggal_kembali.Text & "','" & txt_anggota_kembali.Text & "','" & txt_totaldenda.Text & "','" & txt_dibayar.Text & "','" & txt_kembalian.Text & "')", Conn)
            Cmd.ExecuteNonQuery()


            For baris As Integer = 0 To dgv1.RowCount - 1
                Cmd = New OdbcCommand("insert into tbl_kembali_detail values('" & txt_idkembali.Text & "','" & dgv1_kembali.Rows(baris).Cells(0).Value & "','" & dgv1_kembali.Rows(baris).Cells(4).Value & "','" & dgv1_kembali.Rows(baris).Cells(5).Value & "','" & dgv1_kembali.Rows(baris).Cells(6).Value & "','" & dgv1_kembali.Rows(baris).Cells(7).Value & "','" & dgv1_kembali.Rows(baris).Cells(8).Value & "','1')", Conn)
                Cmd.ExecuteNonQuery()
                Cmd = New OdbcCommand("select*from tbl_buku where id_buku='" & dgv1_kembali.Rows(baris).Cells(0).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows = True Then
                    If dgv1_kembali.Rows(baris).Cells(6).Value = "Tidak" Then
                        Cmd = New OdbcCommand("update tbl_buku set stok='" & Rd.Item("stok") + 1 & "' where id_buku='" & dgv1_kembali.Rows(baris).Cells(0).Value & "'", Conn)
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd = New OdbcCommand("update tbl_buku set stok='" & Rd.Item("stok") + 1 & "' where id_buku='" & dgv1_kembali.Rows(baris).Cells(0).Value & "'", Conn)
                        Cmd.ExecuteNonQuery()
                    End If
                    Cmd = New OdbcCommand("select*from tbl_pinjam_detail where id_buku='" & dgv1_kembali.Rows(baris).Cells(0).Value & "' and id_pinjam='" & dgv1_kembali.Rows(baris).Cells(3).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows = True Then
                        If dgv1_kembali.Rows(baris).Cells(7).Value = "Ya" Then
                            Cmd = New OdbcCommand("update tbl_pinjam_detail set keterangan='Hilang' where id_buku='" & dgv1_kembali.Rows(baris).Cells(0).Value & "' and id_pinjam='" & dgv1_kembali.Rows(baris).Cells(3).Value & "'", Conn)
                            Cmd.ExecuteNonQuery()
                        Else
                            Cmd = New OdbcCommand("update tbl_pinjam_detail set keterangan='Dikembalikan' where id_buku='" & dgv1_kembali.Rows(baris).Cells(0).Value & "' and id_pinjam='" & dgv1_kembali.Rows(baris).Cells(3).Value & "'", Conn)
                            Cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
            Next
            Dim tanya2
            tanya2 = MessageBox.Show("Data Pengembalian Berhasil Disimpan, Lihat Nota Pengembalian? ", "Tidak", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanya2 = vbYes Then
                Try
                    Dim crypt As New ReportDocument
                    Dim crtablelogoninfos As New TableLogOnInfos
                    Dim crtablelogoninfo As New TableLogOnInfo
                    Dim crconnectioninfo As New ConnectionInfo
                    Dim crtables As Tables
                    Dim crtable As Table
                    Dim laporan As New nota_kembali

                    crypt = laporan

                    With crconnectioninfo
                        .ServerName = "dsn_perpustakaan"
                        .DatabaseName = "db_perpustakaan"
                        .UserID = ""
                        .Password = ""
                    End With
                    crtables = crypt.Database.Tables
                    For Each crtable In crtables
                        crtablelogoninfo = crtable.LogOnInfo
                        crtablelogoninfo.ConnectionInfo = crconnectioninfo
                        crtable.ApplyLogOnInfo(crtablelogoninfo)
                    Next
                    Struk_Pengembalian.CrystalReportViewer1.SelectionFormula = "({tbl_anggota1.id_anggota})='" & txt_anggota_kembali.Text & "' and ({tbl_kembali1.id_kembali})='" & txt_idkembali.Text & "'"
                    Struk_Pengembalian.CrystalReportViewer1.ReportSource = crypt
                    Struk_Pengembalian.CrystalReportViewer1.Refresh()
                    Struk_Pengembalian.CrystalReportViewer1.RefreshReport()
                Catch ex As Exception
                End Try
                Struk_Pengembalian.ShowDialog()
            Else
                Dim tanya
                tanya = MessageBox.Show("Anda Ingin Mengembalikan Buku lagi " + txt_nama_kembali.Text + " ??", "Tidak", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If tanya = vbYes Then
                    Call bersih_transaksi_kembali()
                    dgv1_kembali.Rows.Clear()
                    Call hitung_total_denda()
                    txt_dibayar.Clear()
                    txt_kembalian.Clear()
                    Call id_kembali_otomatis()
                    txt_idbuku_kembali.ReadOnly = False
                    Button8.Enabled = True

                Else
                    Call bersih_anggota()
                    dgv1_kembali.Rows.Clear()
                    Call hitung_total_denda()
                    txt_dibayar.Clear()
                    txt_kembalian.Clear()
                    Call id_kembali_otomatis()
                    txt_idbuku_kembali.ReadOnly = False
                    Button8.Enabled = True
                End If
            End If
        End If
    End Sub
    Sub tampil_history()
        Call koneksi()
        Cmd = New OdbcCommand("select distinct tbl_buku.id_buku,judul,tbl_pinjam_detail.id_pinjam,jumlah_pinjam,tbl_pinjam.tanggal_pinjam,tbl_anggota.id_anggota,nama_anggota from tbl_anggota,tbl_pinjam,tbl_buku,tbl_pinjam_detail where tbl_buku.id_buku=tbl_pinjam_detail.id_buku and tbl_pinjam.id_pinjam=tbl_pinjam_detail.id_pinjam and tbl_anggota.id_anggota=tbl_pinjam.id_anggota and tbl_pinjam_detail.keterangan='Dipinjam'", Conn)
        Rd = Cmd.ExecuteReader
        dgv_history.Rows.Clear()
        Do While Rd.Read = True
            dgv_history.Rows.Add(Rd.Item("id_pinjam"), Rd.Item("tanggal_pinjam"), Rd.Item("id_anggota"), Rd.Item("nama_anggota"), Rd.Item("id_buku"), Rd.Item("judul"), Rd.Item("jumlah_pinjam"))
        Loop
    End Sub

    'TRANSAKSI HISTORI
    Sub tampil_total_kembali()
        Call koneksi()
        Cmd = New OdbcCommand("select distinct tbl_buku.id_buku,judul,tbl_kembali_detail.id_kembali,jumlah_kembali,tbl_kembali.tanggal_kembali,tbl_anggota.id_anggota,nama_anggota from tbl_anggota,tbl_kembali,tbl_buku,tbl_kembali_detail where tbl_buku.id_buku=tbl_kembali_detail.id_buku and tbl_kembali.id_kembali=tbl_kembali_detail.id_kembali and tbl_anggota.id_anggota=tbl_kembali.id_anggota", Conn)
        Rd = Cmd.ExecuteReader
        dgv_total_kembali.Rows.Clear()
        Do While Rd.Read = True
            dgv_total_kembali.Rows.Add(Rd.Item("id_kembali"), Rd.Item("tanggal_kembali"), Rd.Item("id_anggota"), Rd.Item("nama_anggota"), Rd.Item("id_buku"), Rd.Item("judul"), Rd.Item("jumlah_kembali"))
        Loop
    End Sub
    Sub tampil_dgv_hilang()

    End Sub
    Sub tampil_diagram()
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_kembali_detail where rusak='Ya'", Conn)
        Rd = Cmd.ExecuteReader
        dgv_diagram.Rows.Clear()
        Do While Rd.Read = True
            dgv_diagram.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6))
        Loop
    End Sub
    Sub tampil_hilang()
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_kembali_detail where hilang='Ya'", Conn)
        Rd = Cmd.ExecuteReader
        dgv_hilang.Rows.Clear()
        Do While Rd.Read = True
            dgv_hilang.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6))
        Loop
    End Sub
    Sub tampil_utuh()
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_kembali_detail where rusak='Tidak' and hilang='Tidak'", Conn)
        Rd = Cmd.ExecuteReader
        dgv_utuh.Rows.Clear()
        Do While Rd.Read = True
            dgv_utuh.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6))
        Loop
    End Sub

    'LAPORAN PEMINJAMAN
    Private Sub view_pinjam_hari_Click(sender As Object, e As EventArgs) Handles view_pinjam_hari.Click
        Try
            Dim crypt As New ReportDocument
            Dim crtablelogoninfos As New TableLogOnInfos
            Dim crtablelogoninfo As New TableLogOnInfo
            Dim crconnectioninfo As New ConnectionInfo
            Dim crtables As Tables
            Dim crtable As Table
            Dim laporan As New lap_pinjam

            crypt = laporan

            With crconnectioninfo
                .ServerName = "dsn_perpustakaan"
                .DatabaseName = "db_perpustakaan"
                .UserID = ""
                .Password = ""
            End With
            crtables = crypt.Database.Tables
            For Each crtable In crtables
                crtablelogoninfo = crtable.LogOnInfo
                crtablelogoninfo.ConnectionInfo = crconnectioninfo
                crtable.ApplyLogOnInfo(crtablelogoninfo)
            Next
            CrystalReportViewer1.SelectionFormula = "({tbl_pinjam_detail1.keterangan})='Dipinjam'"
            CrystalReportViewer1.ReportSource = crypt
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    'LAPORAN PENGEMBALIAN
    Private Sub lap_kembali_btn_Click(sender As Object, e As EventArgs) Handles lap_kembali_btn.Click
        Try
            Dim crypt As New ReportDocument
            Dim crtablelogoninfos As New TableLogOnInfos
            Dim crtablelogoninfo As New TableLogOnInfo
            Dim crconnectioninfo As New ConnectionInfo
            Dim crtables As Tables
            Dim crtable As Table
            Dim laporan As New lap_kembali

            crypt = laporan

            With crconnectioninfo
                .ServerName = "dsn_perpustakaan"
                .DatabaseName = "db_perpustakaan"
                .UserID = ""
                .Password = ""
            End With
            crtables = crypt.Database.Tables
            For Each crtable In crtables
                crtablelogoninfo = crtable.LogOnInfo
                crtablelogoninfo.ConnectionInfo = crconnectioninfo
                crtable.ApplyLogOnInfo(crtablelogoninfo)
            Next
            CrystalReportViewer2.ReportSource = crypt
            CrystalReportViewer2.Refresh()
            CrystalReportViewer2.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    'LAINNYA BUKU
    Private Sub txt_data_buku_TextChanged(sender As Object, e As EventArgs) Handles txt_data_buku.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_buku where judul like '%" & txt_data_buku.Text & "%'", Conn)
        Rd = Cmd.ExecuteReader
        dgv_data_buku.Rows.Clear()
        Do While Rd.Read = True
            dgv_data_buku.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4), Rd(5), Rd(6), Rd(7), Rd(8), Rd(9))
        Loop
    End Sub

    'LAINNYA ANGGOTA
    Private Sub textbox_data_anggota_TextChanged(sender As Object, e As EventArgs) Handles textbox_data_anggota.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand("select * from tbl_anggota where nama_anggota like '%" & textbox_data_anggota.Text & "%'", Conn)
        Rd = Cmd.ExecuteReader
        dgv_data_anggota.Rows.Clear()
        Do While Rd.Read = True
            dgv_data_anggota.Rows.Add(Rd(0), Rd(1), Rd(2), Rd(3), Rd(4))
        Loop
    End Sub
End Class