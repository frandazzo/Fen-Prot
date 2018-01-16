Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
Public Class LazyLoadCheckin
    Inherits VirtualLazyList

    Private ListLoader As MapperCheckin
    Private m_doc As Assignment


    Public Sub New(ByVal doc As Assignment, ByVal service As MapperCheckin)
        m_doc = doc
        ListLoader = service

    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = ListLoader.FindCheckins(m_doc)
        End If
        Return Source
    End Function
End Class
