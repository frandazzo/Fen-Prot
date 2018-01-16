Public Class LazyLoadRolesByProfile
    Inherits VirtualLazyList

    Private ListLoader As MapperRole = PersistenceMapperRegistry.Instance.GetMapperByName("MapperRole")
    Private m_profile As Profile
    Private query As Query

    Public Sub New(ByVal profile As Profile)
        m_profile = profile
    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = ListLoader.FindRoleByProfile(m_profile)
        End If
        Return Source
    End Function
End Class
