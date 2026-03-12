Imports System.Data.SqlClient
Module Module1
    Public conn As New SqlConnection(My.Settings.dbConnectionString)
    Public cmd As SqlCommand
End Module
