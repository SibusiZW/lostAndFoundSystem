Public Class main
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Application.Exit()
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            conn.Open()

            cmd = New SqlClient.SqlCommand("SELECT * FROM items;", conn)
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            DataGridView1.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        Guna2TextBox1.Clear()
        item.Clear()
        Guna2TextBox2.Clear()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            conn.Open()
            cmd = New SqlClient.SqlCommand("INSERT INTO items (item, itemDescription, dateRec) VALUES(@item, @desc, @date);", conn)
            cmd.Parameters.AddWithValue("@item", item.Text)
            cmd.Parameters.AddWithValue("@desc", Guna2TextBox2.Text)
            cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value)

            Dim count = cmd.ExecuteNonQuery()

            If count > 0 Then
                MessageBox.Show("Added succesfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Guna2TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        item.Text = DataGridView1.CurrentRow.Cells(1).Value
        Guna2TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value
        DateTimePicker1.Value = DataGridView1.CurrentRow.Cells(3).Value
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Try
            conn.Open()

            cmd = New SqlClient.SqlCommand("DELETE FROM items WHERE Id=@id;", conn)
            cmd.Parameters.AddWithValue("@id", Guna2TextBox1.Text)

            Dim count = cmd.ExecuteNonQuery()

            If count > 0 Then
                MessageBox.Show("Deleted succesfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Try
            conn.Open()

            cmd = New SqlClient.SqlCommand("UPDATE items SET item=@item, itemDescription=@desc, dateRec=@date WHERE Id=@id;", conn)

            cmd.Parameters.AddWithValue("@id", Guna2TextBox1.Text)
            cmd.Parameters.AddWithValue("@item", item.Text)
            cmd.Parameters.AddWithValue("@desc", Guna2TextBox2.Text)
            cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value)

            Dim count = cmd.ExecuteNonQuery

            If count > 0 Then
                MessageBox.Show("Updated succesfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub Guna2TextBox3_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox3.TextChanged
        TryCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter = $"item like '%{Guna2TextBox3.Text}%'"
    End Sub
End Class