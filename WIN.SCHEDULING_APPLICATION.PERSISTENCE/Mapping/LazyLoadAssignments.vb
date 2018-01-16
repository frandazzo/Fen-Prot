Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class LazyLoadAssignments
    Inherits VirtualLazyList

    Private ListLoader As MapperAssignment
    Private m_doc As Booking


    Public Sub New(ByVal doc As Booking, ByVal service As MapperAssignment)
        m_doc = doc
        ListLoader = service

    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = ListLoader.FindAssignments(m_doc)
        End If
        Return Source
    End Function
End Class
