Imports System.Windows
Public Class Form1
    Public U As Univers
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        U = New Univers
        U.Add(New Vector(100, 100), New Vector(0, -0.5), 100)
        U.Add(New Vector(50, 100), New Vector(0, 5), 10)
        U.Add(New Vector(55, 100), New Vector(0, 4), 0.001)
        U.Present()
        PictureBox1.Image = U.Bitmap
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        U.Update()
        U.Present()
        PictureBox1.Image = U.Bitmap
    End Sub
End Class
