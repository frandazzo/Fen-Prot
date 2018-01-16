Public Class LazyLoadDocumentBody
    Implements DOMAIN.IDocumentBody

    Dim m_persistenceFacade As IPersistenceFacade
    Dim _id As Int32

    Friend Sub New(ByVal parentId As Int32, ByVal persistentService As IPersistenceFacade)
        _id = parentId
        m_persistenceFacade = persistentService
    End Sub





    Private body As Byte()


    Private Function GetBody() As Byte()
        If body Is Nothing Then
            RetrieveFromDB()
        End If
        Return body
    End Function


    Private Sub RetrieveFromDB()
        Dim o As Object = m_persistenceFacade.ExecuteScalar(String.Format("Select DocBody from App_Documents where ID = {0}", _id.ToString))
        Try
            body = DirectCast(o, Byte())
        Catch ex As Exception
            body = Nothing
        End Try
    End Sub


    Public Property Document() As Byte() Implements DOMAIN.IDocumentBody.Document
        Get
            Return GetBody()
        End Get
        Set(ByVal value As Byte())
            body = value
        End Set
    End Property
End Class
