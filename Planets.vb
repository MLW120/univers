Imports System.Windows
Public Class Mass
    Public Mass As Double
    Public Acceleration As Vector
    Public Velocity As Vector
    Public Position As Vector

    Public Sub Update(ByVal F As Vector(), Optional ByVal t As Double = 0.3)
        If F IsNot Nothing Then
            Dim FRes As New Vector(0, 0)
            For i As Integer = 0 To F.Length - 1
                FRes = FRes + F(i)
            Next
            Me.Acceleration = FRes / Me.Mass
            Me.Velocity = Me.Velocity + Me.Acceleration * t * 3
        End If
        Me.Position = Me.Position + Me.Velocity * t
    End Sub

    Public Sub New(ByVal M As Double, ByVal V As Vector, ByVal P As Vector, Optional ByVal A As Vector = Nothing)
        Me.Mass = M
        If A = Nothing Then
            Me.Acceleration = New Vector(0, 0)
        Else
            Me.Acceleration = A
        End If
        Me.Velocity = V
        Me.Position = P
    End Sub

End Class
