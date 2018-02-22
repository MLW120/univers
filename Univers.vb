Imports System.Windows
Public Class Univers
    Public Bitmap
    Public Bodies As Planets()

    Public Sub New()

        Me.Bitmap = New Bitmap(200, 200)
        For x As Integer = 0 To Bitmap.Width - 1
            For y As Integer = 0 To Bitmap.Height - 1
                Bitmap.SetPixel(x, y, Color.Black)
            Next
        Next

    End Sub
    Public Sub Add(Pos As Vector, Vel As Vector, M As Double)
        Dim i As Integer = 0
        If Bodies IsNot Nothing Then
            i = Bodies.Length
        End If
        ReDim Preserve Bodies(i)
        Bodies(i) = New Planets(M, Vel, Pos)
    End Sub

    Public Sub Update()
        Dim G As Double = 5
        Dim LF As New List(Of Vector())
        For i As Integer = 0 To Bodies.Length - 1
            Dim F() As Vector = Nothing
            Dim count As Integer = 0
            For j As Integer = 0 To Bodies.Length - 1
                If j <> i Then
                    ReDim Preserve F(count)
                    Dim d As Double = Math.Sqrt((Me.Bodies(i).Position.X - Me.Bodies(j).Position.X) ^ 2 + (Me.Bodies(i).Position.Y - Me.Bodies(j).Position.Y) ^ 2)
                    If d < 5 Then d = 5
                    Dim Modul As Double = G * (Me.Bodies(i).Mass * Me.Bodies(j).Mass) / d ^ 2
                    Dim FY As Double = (Me.Bodies(j).Position.Y - Me.Bodies(i).Position.Y) * Modul / d
                    Dim FX As Double = (Me.Bodies(j).Position.X - Me.Bodies(i).Position.X) * Modul / d
                    F(count) = New Vector(FX, FY)
                    count += 1
                End If
            Next
            LF.Add(F)
        Next
        For i As Integer = 0 To Bodies.Length - 1
            Me.Bodies(i).Update(LF(i))
        Next
    End Sub

    Public Sub Present()


        For i As Integer = 0 To Bodies.Length - 1
            If (Bodies(i).Position.X >= 0) And (Bodies(i).Position.Y >= 0) Then
                Try
                    Bitmap.SetPixel(Bodies(i).Position.X, Bodies(i).Position.Y, Color.White)
                Catch

                End Try
            End If
        Next

    End Sub

End Class
