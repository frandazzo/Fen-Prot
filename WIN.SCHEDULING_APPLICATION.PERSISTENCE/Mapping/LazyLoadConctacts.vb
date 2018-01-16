Public Class LazyLoadConctacts
    Inherits VirtualLazyList



    'Private ListLoader As MapperQuestionContent
    Private m_Id As String
    Private m_service As MapperDocument

    Public Sub New(ByVal Id As String, ByVal service As MapperDocument)
        m_Id = Id
        m_service = service

    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = GetElementList()
        End If
        Return Source
    End Function

    Private Function GetElementList() As IList
       
        Return m_service.FindListaUtenti(m_Id)

       
    End Function
End Class
