Public Class LazyLoadUserForRole
    Inherits VirtualLazyList

    Private ListLoader As MapperRole = PersistenceMapperRegistry.Instance.GetMapperByName("MapperRole")
    Private m_role As Role
    Private query As Query

    Public Sub New(ByVal role As Role)
        m_role = role
    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = ListLoader.FindUsers(m_role)
        End If
        Return Source
    End Function
End Class
