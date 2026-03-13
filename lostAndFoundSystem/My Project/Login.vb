Public Class Login
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            conn.Open()

            cmd = New SqlClient.SqlCommand($"SELECT COUNT(*) FROM users WHERE username=@usr AND password=@pwd;", conn)
            cmd.Parameters.AddWithValue("@usr", Guna2TextBox1.Text)
            cmd.Parameters.AddWithValue("@pwd", Guna2TextBox2.Text)
            Dim count = Convert.ToInt32(cmd.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("Logged In", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                main.Show()
                Me.Close()
                Return
            Else
                MessageBox.Show("Wrong credentials", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        Guna2TextBox1.Clear()
        Guna2TextBox2.Clear()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Application.Exit()
    End Sub
End Class