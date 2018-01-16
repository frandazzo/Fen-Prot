Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione


Public Class MapperTesseramentoIncasso
    Inherits AbstraactMovimentoContabile



    Protected Overrides Function CastToObject(item As DOMAIN.Amministrazione.AbstractMovimentoContabile) As DOMAIN.Amministrazione.AbstractMovimentoContabile
        If item Is Nothing Then
            Return New TesseramentoIncasso
        End If
        Return DirectCast(item, TesseramentoIncasso)
    End Function

    Public Sub New()
        m_table = "Amm_IncassiTesseramento"
    End Sub




End Class




