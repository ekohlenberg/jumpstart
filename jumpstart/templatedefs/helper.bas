Attribute VB_Name = "Module1"
Public Function GetFileNameFromPath(ByVal strPath As String) As String
    Dim pos As Long
    
    ' Find the position of the last backslash
    pos = InStrRev(strPath, "/")
    
    ' If a backslash was found, return the substring after it; otherwise, return the entire path
    If pos > 0 Then
        GetFileNameFromPath = Mid(strPath, pos + 1)
    Else
        GetFileNameFromPath = strPath
    End If
End Function

