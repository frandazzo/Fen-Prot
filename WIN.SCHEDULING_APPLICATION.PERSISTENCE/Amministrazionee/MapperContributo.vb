Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione

Public Class MapperContributo
    Inherits AbstraactMovimentoContabile



    Protected Overrides Function CastToObject(item As DOMAIN.Amministrazione.AbstractMovimentoContabile) As DOMAIN.Amministrazione.AbstractMovimentoContabile
        If item Is Nothing Then
            Return New Contributo
        End If
        Return DirectCast(item, Contributo)
    End Function

    Public Sub New()
        m_table = "Amm_Contributi"
    End Sub

End Class
