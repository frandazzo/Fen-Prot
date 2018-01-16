Public Class LazyLoadAttachments
    Inherits VirtualLazyList

    Private ListLoader As MapperAttachmentForDocument
    Private m_doc As Document


    Public Sub New(ByVal doc As Document, ByVal service As MapperAttachmentForDocument)
        m_doc = doc
        ListLoader = service

    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = ListLoader.FindAttachmentsByDocument(m_doc)
        End If
        Return Source
    End Function
End Class
