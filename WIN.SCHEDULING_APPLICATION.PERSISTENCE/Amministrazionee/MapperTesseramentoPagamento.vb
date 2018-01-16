
Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione


Public Class MapperTesseramentoPagamento
    Inherits AbstraactMovimentoContabile



    Protected Overrides Function CastToObject(item As DOMAIN.Amministrazione.AbstractMovimentoContabile) As DOMAIN.Amministrazione.AbstractMovimentoContabile
        If item Is Nothing Then
            Return New TesseramentoPagamento
        End If
        Return DirectCast(item, TesseramentoPagamento)
    End Function

    Public Sub New()
        m_table = "Amm_PagamentiTesseramento"
    End Sub




End Class
