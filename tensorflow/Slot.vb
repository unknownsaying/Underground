Imports System

Public Class SlotMachine
    Private ReadOnly random As New Random()
    Private credits As Integer = 100
    Private Const symbols As Integer = 5 ' Number of different symbols
    Private Const reelCount As Integer = 3 ' Number of reels

    Public Sub Spin()
        If credits <= 0 Then
            Console.WriteLine("Insufficient credits!")
            Return
        End If

        credits -= 1 ' Deduct cost per spin
        Dim reels(reelCount - 1) As Integer

        ' Generate random values for each reel
        For i As Integer = 0 To reelCount - 1
            reels(i) = random.Next(0, symbols)
        Next

        DisplayReels(reels)
        CalculatePayout(reels)
        Console.WriteLine($"Credits remaining: {credits}")
    End Sub

    Private Sub DisplayReels(reels() As Integer)
        Dim symbolsChar As Char() = {"🍒"c, "🍋"c, "🍊"c, "🍇"c, "7"c}
        Console.Write("Reels: ")
        For Each reel In reels
            Console.Write(symbolsChar(reel) & " ")
        Next
        Console.WriteLine()
    End Sub

    Private Sub CalculatePayout(reels() As Integer)
        Dim frequency(symbols - 1) As Integer

        ' Count occurrences of each symbol
        For Each reel In reels
            frequency(reel) += 1
        Next

        ' Check for wins
        Dim payout As Integer = 0

        ' Three of a kind
        For i As Integer = 0 To symbols - 1
            If frequency(i) = 3 Then
                payout = If(i = 4, 100, 10) ' Jackpot for '7', regular for others
                Exit For
            End If
        Next

        ' Two of a kind (if no three of a kind)
        If payout = 0 Then
            For i As Integer = 0 To symbols - 1
                If frequency(i) = 2 Then
                    payout = If(i = 4, 5, 2) ' Higher payout for two '7's
                    Exit For
                End If
            Next
        End If

        If payout > 0 Then
            credits += payout
            Console.WriteLine($"You won {payout} credits!")
        Else
            Console.WriteLine("No win. Try again!")
        End If
    End Sub

    Public Sub ShowCredits()
        Console.WriteLine($"Current credits: {credits}")
    End Sub
End Class

Module Program
    Sub Main()
        Dim machine As New SlotMachine()
        Console.WriteLine("Welcome to the Slot Machine!")
        Console.WriteLine("Symbols: 🍒(0) 🍋(1) 🍊(2) 🍇(3) 7(4)")
        Console.WriteLine("Press any key to spin or 'q' to quit")

        While True
            machine.ShowCredits()
            Console.Write("Spin? (press any key/'q' to quit): ")
            Dim input As String = Console.ReadLine()

            If input.ToLower() = "q" Then Exit While

            machine.Spin()
            Console.WriteLine()
        End While
    End Sub
End Module