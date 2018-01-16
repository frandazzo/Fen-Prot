Public Class LazyLoadPermissionForProfile
    Inherits VirtualLazyList

    Private ListLoader As MapperProfile = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProfile")
    Private m_Profile As Profile
    Private query As Query

    Public Sub New(ByVal profile As Profile)
        m_Profile = profile
    End Sub



    Protected Overrides Function GetList() As System.Collections.ArrayList
        If Source Is Nothing Then
            Source = ListLoader.FindPermissions(m_Profile)
        End If
        Return Source
    End Function
End Class
