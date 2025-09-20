Imports System.Math

Module Program
    ' Constants and structures
    Private Const n As Integer = 1

    Public Structure Matrix
        Public N(,) As Integer
    End Structure

    ' Matrix declarations
    Public leftK As New Matrix With {
        .N = New Integer(4, 4) {
            {n, 0, 0, n, 0},
            {n, 0, n, 0, 0},
            {n, n, 0, 0, 0},
            {n, 0, n, 0, 0},
            {n, 0, 0, n, 0}
        }
    }
    Public rightK As New Matrix With {
        .N = New Integer(4, 4) {
            {0, n, 0, 0, n},
            {0, n, 0, n, 0},
            {0, n, n, 0, 0},
            {0, n, 0, n, 0},
            {0, n, 0, 0, n}
        }
    }
    Public midK As New Matrix With {
        .N = New Integer(4, 4) {
            {n, 0, 0, 0, n},
            {n, 0, 0, n, 0},
            {n, n, n, 0, 0},
            {n, 0, 0, n, 0},
            {n, 0, 0, 0, n}
        }
    }
    Public sigma As New Matrix With {
        .N = New Integer(4, 4) {
            {n, n, n, n, n},
            {0, n, 0, 0, 0},
            {0, 0, n, 0, 0},
            {0, n, 0, 0, 0},
            {n, n, n, n, n}
        }
    }
    Public Pai As New Matrix With {
        .N = New Integer(4, 4) {
            {n, n, n, n, n},
            {0, n, 0, n, 0},
            {0, n, 0, n, 0},
            {0, n, 0, n, 0},
            {0, n, 0, n, 0}
        }
    }
    Public ulu As New Matrix With {
        .N = New Integer(4, 4) {
            {0, 0, n, 0, 0},
            {0, 0, n, 0, 0},
            {n, n, n, n, n},
            {0, 0, n, 0, 0},
            {0, 0, n, 0, 0}
        }
    }
    Public ozo As New Matrix With {
        .N = New Integer(4, 4) {
            {n, 0, n, 0, n},
            {0, n, n, n, 0},
            {0, 0, n, 0, 0},
            {0, n, n, n, 0},
            {n, 0, n, 0, n}
        }
    }
    ' Function implementations
    Public Sub xyznnn(x As Integer, y As Integer, z As Integer)
        Dim n5 As String = "'x+n,y+n,z+n', 'x+n,z+n,y+n', 'y+n,z+n,x+n', 'z+n,y+n,x+n'"
        Dim n4 As String = "'x+n,z+n,y-n', 'x+n,y+n,z-n', 'z+n,y+n,x-n', 'y+n,z+n,x-n'"
        Dim n3 As String = "'y+n,x-n,z+n', 'y+n,z-n,x+n', 'x+n,z-n,y+n', 'z+n,x-n,y+n'"
        Dim n2 As String = "'y-n,z+n,x-n', 'y-n,x+n,z-n', 'z-n,x+n,y-n', 'x-n,z+n,y-n'"
        Dim n1 As String = "'z-n,x-n,y+n', 'z-n,y-n,x+n', 'x-n,y-n,z+n', 'y-n,x-n,z+n'"
        Dim n0 As String = "'z-n,y-n,x-n', 'z-n,x-n,y-n', 'y-n,x-n,z-n', 'x-n,y-n,z-n'"
    End Sub

    Public Function fn(a As Single, b As Single, c As Single, d As Single, e As Single, f As Single) As Float
        Float a = 1/7,b = 2/7,c = 3/7, d = 4/7,e = 5/7,f = 6/7
        Dim n5 As Single = a * Pow(n, 5) + b * Pow(n, 4) + c * Pow(n, 3) + d * Pow(n, 2) + e * n + a
        Dim n4 As Single = a * Pow(n, 4) + b * Pow(n, 3) + c * Pow(n, 2) + d * n + e * Pow(n, -1) + b
        Dim n3 As Single = a * Pow(n, 3) + b * Pow(n, 2) + c * n + d * Pow(n, -1) + e * Pow(n, -2) + c
        Dim n2 As Single = a * Pow(n, 2) + b * n + c * Pow(n, -1) + d * Pow(n, -2) + e * Pow(n, -3) + d
        Dim n1 As Single = a * n + b * Pow(n, -1) + c * Pow(n, -2) + d * Pow(n, -3) + e * Pow(n, -4) + e
        Dim n0 As Single = a * Pow(n, -1) + b * Pow(n, -2) + c * Pow(n, -3) + d * Pow(n, -4) + e * Pow(n, -5) + f
    End Function

    Public Function gn(X As Double, Y As Double, Z As Double, N As Double) As bin
        Redim A as "00001011",Redim B as "00001100",Redim C as "00001101",Redim D as "00001110",Redim E as "00001111",Redim F as "00010000"
        Return A * Sin(X + N) + B * Cos(X - N) + C * Sin(Y + N) + D * Cos(Y - N) + E * Sin(Z + N) + F * Cos(Z - N)
        Return A * ASin(X + N) + B * ACos(X - N) + C * ASin(Y + N) + D * ACos(Y - N) + E * ASin(Z + N) + F * ACos(Z - N)
        Return A * Sinh(X + N) + B * Cosh(X - N) + C * Sinh(Y + N) + D * Cosh(Y - N) + E * Sinh(Z + N) + F * Cosh(Z - N)
        Return A * ASinh(X + N) + B * ACosh(X - N) + C * ASinh(Y + N) + D * ACosh(Y - N) + E * ASinh(Z + N) + F * ACosh(Z - N)
        Return A * atan(X + N) + B * atan2(X - N) + C * atan(Y + N) + D * atan2(Y - N) + E * atan(Z + N) + F * atan2(Z - N)
        Return A * exp(X + N) + B * log(X - N) + C * exp(Y + N) + D * log(Y - N) + E * exp(Z + N) + F * log(Z - N)
    End Function
End Module