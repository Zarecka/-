Imports System.Data.OleDb
Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshGrid()

    End Sub

    Private Sub RefreshGrid()
        'Dim _c As New OleDbCommand
        '_c.Connection = _conn
        '_c.CommandText = "select * from Planets"

        'Dim _ds As New DataSet
        'Dim _da As New OleDbDataAdapter(c)
        '_da.Fill(_ds, "Planets")
        'DataGridView1.DataSource = _ds
        'DataGridView1.DataMember = "Planets"

        FillGridDA(DataGridView1, "select * from Planets", "Planets", DA1)
        DataGridView1.Columns("Код").Visible = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _conn = New OleDbConnection
        _conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Планеты\Planets.accdb;Persist Security Info=False"
        _conn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim _s1, _s2, _s3 As String
        Dim _r As DialogResult

        Form3.ShowDialog()
        _s1 = Form3.TextBox1.Text
        _s2 = Form3.TextBox2.Text
        _s3 = Form3.TextBox3.Text
        _r = Form3.DialogResult

        Form3.Close()

        If _r <> DialogResult.OK Then
            Exit Sub
        End If

        Dim _c As New OleDbCommand
        _c.Connection = _conn
        _c.CommandText = "insert into Planets(PlanetName, M, R) values ('" & _s1 & "','" & _s2 & "','" & _s3 & "')"
        _c.ExecuteNonQuery()

        RefreshGrid()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim _k As Integer
        Dim _c As New OleDbCommand
        _c.Connection = _conn
        _k = DataGridView1.CurrentRow.Cells("Код").Value
        _c.CommandText = "delete from Planets where Код = " & _k
        _c.ExecuteNonQuery()


        RefreshGrid()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim _s1, _s2, _s3 As String
        Dim _r As DialogResult
        Dim _k As Integer
        _k = DataGridView1.CurrentRow.Cells("Код").Value
        Form4.TextBox1.Text = DataGridView1.CurrentRow.Cells("PlanetName").Value
        Form4.TextBox2.Text = DataGridView1.CurrentRow.Cells("M").Value
        Form4.TextBox3.Text = DataGridView1.CurrentRow.Cells("R").Value

        Form4.ShowDialog()

        _s1 = Form4.TextBox1.Text
        _s2 = Form4.TextBox2.Text
        _s3 = Form4.TextBox3.Text
        _r = Form4.DialogResult

        Form4.Close()

        If _r <> DialogResult.OK Then
            Exit Sub
        End If

        Dim _c As New OleDbCommand
        _c.Connection = _conn
        _c.CommandText = "update [Planets] set [PlanetName]='" & _s1 & "', [M]='" & _s2 & "', [R]= '" & _s3 & "' where [Код]=" & _k
        _c.ExecuteNonQuery()

        RefreshGrid()
    End Sub
End Class