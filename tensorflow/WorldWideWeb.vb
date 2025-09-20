Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class WorldWideWebSimulation
    Private ReadOnly random As New Random()
    Private web As List(Of WebPage)
    Private users As List(Of WebUser)
    Private Const initialPageCount As Integer = 50
    Private Const initialUserCount As Integer = 10
    
    Public Sub New()
        web = New List(Of WebPage)()
        users = New List(Of WebUser)()
        InitializeWeb()
        InitializeUsers()
    End Sub
    
    ' WebPage class representing a website
    Private Class WebPage
        Public Property Id As Integer
        Public Property Content As String
        Public Property Popularity As Double
        Public Property Links As List(Of Integer) ' Links to other pages
        Public Property Size As Double ' Size in KB
        
        Public Sub New(id As Integer, content As String)
            Me.Id = id
            Me.Content = content
            Me.Links = New List(Of Integer)()
            Me.Popularity = 0
            Me.Size = 0
        End Sub
        
        ' Calculate page rank using mathematical operations
        Public Function CalculatePageRank(allPages As List(Of WebPage)) As Double
            If Links.Count = 0 Then Return 0.1
            
            Dim rankSum As Double = 0
            For Each linkedPageId In Links
                If linkedPageId < allPages.Count Then
                    ' Using mathematical operations: division and addition
                    rankSum += allPages(linkedPageId).Popularity / allPages(linkedPageId).Links.Count
                End If
            Next
            
            ' Using mathematical operations: multiplication and subtraction
            Return 0.15 + 0.85 * rankSum
        End Function
    End Class
    
    ' WebUser class representing a user browsing the web
    Private Class WebUser
        Public Property Id As Integer
        Public Property CurrentPage As Integer
        Public Property Bandwidth As Double ' Mbps
        Public Property ActivityLevel As Double
        
        Public Sub New(id As Integer, bandwidth As Double)
            Me.Id = id
            Me.Bandwidth = bandwidth
            Me.CurrentPage = 0
            Me.ActivityLevel = 0
        End Sub
        
        ' Simulate browsing behavior using mathematical operations
        Public Sub Browse(web As List(Of WebPage))
            If web.Count = 0 Then Return
            
            ' Using mathematical operations: modulo and addition
            Dim nextPage As Integer = (CurrentPage + random.Next(1, 5)) Mod web.Count
            If nextPage < 0 Then nextPage = 0
            
            ' Calculate load time based on page size and bandwidth
            ' Using mathematical operations: division and multiplication
            Dim loadTime As Double = (web(nextPage).Size / Bandwidth) * (0.8 + 0.4 * random.NextDouble())
            
            ' Using mathematical operations: addition and multiplication
            ActivityLevel += 1.0 / (1.0 + loadTime)
            
            CurrentPage = nextPage
            Console.WriteLine($"User {Id} browsed to page {nextPage} (Load time: {loadTime:F2} ms)")
        End Sub
    End Class
    
    Private Sub InitializeWeb()
        Dim topics As String() = {"Science", "Technology", "Arts", "Mathematics", "History", "Geography", "Sports", "Entertainment"}
        
        For i As Integer = 0 To initialPageCount - 1
            ' Using mathematical operations: modulo and multiplication
            Dim topicIndex As Integer = CInt(Math.Floor(i * 1.0 / (initialPageCount / topics.Length))) Mod topics.Length
            Dim content As String = $"Welcome to {topics(topicIndex)} Page {i}"
            
            web.Add(New WebPage(i, content))
            
            ' Using mathematical operations: multiplication and exponentiation
            web(i).Size = 100 * Math.Pow(1.1, i Mod 10) ' Varying sizes
        Next
        
        ' Create links between pages
        For i As Integer = 0 To web.Count - 1
            Dim linkCount As Integer = random.Next(3, 10)
            
            For j As Integer = 0 To linkCount - 1
                ' Using mathematical operations: modulo and addition
                Dim linkedPage As Integer = (i + j * 7) Mod web.Count
                If linkedPage <> i AndAlso Not web(i).Links.Contains(linkedPage) Then
                    web(i).Links.Add(linkedPage)
                End If
            Next
        Next
        
        ' Calculate initial popularity using mathematical operations
        For i As Integer = 0 To web.Count - 1
            ' Using mathematical operations: division and sine function for variation
            web(i).Popularity = 0.1 + 0.05 * Math.Sin(i * Math.PI / 10)
        Next
    End Sub
    
    Private Sub InitializeUsers()
        For i As Integer = 0 To initialUserCount - 1
            ' Using mathematical operations: multiplication and exponentiation
            Dim bandwidth As Double = 10 * Math.Pow(1.5, i Mod 4)
            users.Add(New WebUser(i, bandwidth))
        Next
    End Sub
    
    ' Simulate network traffic using mathematical operations
    Public Function CalculateNetworkTraffic() As Double
        Dim totalTraffic As Double = 0
        
        For Each user In users
            ' Using mathematical operations: multiplication and addition
            totalTraffic += user.ActivityLevel * user.Bandwidth
        Next
        
        ' Using mathematical operations: division
        Return totalTraffic / users.Count
    End Function
    
    ' Update page rankings based on user activity
    Public Sub UpdateWebRankings()
        For Each page In web
            ' Using mathematical operations: multiplication and addition
            page.Popularity = 0.2 * page.Popularity + 0.8 * page.CalculatePageRank(web)
        Next
    End Sub
    
    ' Run simulation for a number of cycles
    Public Sub RunSimulation(cycles As Integer)
        For cycle As Integer = 1 To cycles
            Console.WriteLine($"=== Cycle {cycle} ===")
            
            For Each user In users
                user.Browse(web)
            Next
            
            UpdateWebRankings()
            
            ' Using mathematical operations: multiplication and subtraction
            Dim traffic As Double = CalculateNetworkTraffic()
            Console.WriteLine($"Average network traffic: {traffic:F2} Mbps")
            Console.WriteLine()
            
            ' Pause briefly to see output
            System.Threading.Thread.Sleep(500)
        Next
    End Sub
    
    ' Display information about the web
    Public Sub DisplayWebInfo()
        Console.WriteLine("=== World Wide Web Simulation ===")
        Console.WriteLine($"Total pages: {web.Count}")
        Console.WriteLine($"Total users: {users.Count}")
        
        Dim totalLinks As Integer = 0
        For Each page In web
            totalLinks += page.Links.Count
        Next
        
        Console.WriteLine($"Total links: {totalLinks}")
        Console.WriteLine($"Average links per page: {totalLinks / web.Count:F2}")
        Console.WriteLine()
        
        ' Show top 5 most popular pages
        web.Sort(Function(x, y) y.Popularity.CompareTo(x.Popularity))
        Console.WriteLine("Top 5 most popular pages:")
        For i As Integer = 0 To Math.Min(4, web.Count - 1)
            Console.WriteLine($"Page {web(i).Id}: {web(i).Content} (Popularity: {web(i).Popularity:F4})")
        Next
        Console.WriteLine()
    End Sub
End Class

Module Program
    Sub Main()
        Dim www As New WorldWideWebSimulation()
        www.DisplayWebInfo()
        www.RunSimulation(5)
        
        Console.WriteLine("Simulation completed. Press any key to exit.")
        Console.ReadKey()
    End Sub
End Module