Imports System.Data.Odbc
Module Module1
    Public Conn As OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public Rd As OdbcDataReader
    Public Cmd As OdbcCommand
    Public Sub koneksi()
        Conn = New OdbcConnection("dsn=dsn_perpustakaan")
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub

End Module
