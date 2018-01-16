Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione

Public Class MapperQuac
    Inherits AbstraactMovimentoContabile

    Public Sub New()
        m_table = "Amm_Quac"
        Me.UseDefaultCacheMechanism = False
        Me.Cache = New PersistentObjectCache(0)
    End Sub

    Public Function RiepilogoQuacProvincia(anno As Int32, idCausale As Int32, orderbyProvincia As Boolean) As String
        Dim causale As String = ""
        Dim orderby As String = ""

        If idCausale > 0 Then
            causale = "and id_causaleamministrazione = " + idCausale.ToString
        End If

        If orderbyProvincia Then
            orderby = " order by c.NomeProvincia"
        End If



        Dim query As String = "select c.*, r.descrizione as NomeRegione from " _
                            & " ( select  p.Id as ID, p.Id as Id_Provincia, p.Descrizione as NomeProvincia, p.Id_TB_Regioni as Id_Regione , d.Importo, d.numQuote  from tb_provincie p left outer join  " _
                                        & " ( " _
                                                & "	SELECT     q.Id_Provincia, sum(q.Importo) as Importo, count(*) as numQuote " _
                                                & " FROM        Amm_Quac q where year(q.Data) = {0} {1}  " _
                                                & " GROUP BY q.Id_Provincia " _
                                        & " ) d on p.Id = d.Id_Provincia  " _
                            & ") c left outer join  tb_regioni r on c.id_regione = r.id " & orderby





        Return String.Format(query, anno, causale)


    End Function

    Public Function RiepilogoQuacRegione(anno As Int32, idCausale As Int32) As String
        Dim causale As String = ""

        If idCausale > 0 Then
            causale = "and id_causaleamministrazione = " + idCausale.ToString
        End If



        Dim query1 As String = "select  p.Id as ID , p.Id as Id_Regione, p.descrizione as NomeRegione , d.Importo, d.numQuote  from tb_regioni p left outer join " _
                                    & " ( SELECT     q.Id_Regione, sum(q.Importo) as Importo, count(*) as numQuote " _
                                    & " FROM        Amm_Quac q where year(q.Data) = {0} {1}  " _
                                    & "GROUP BY q.Id_Regione " _
                                & " ) d on p.Id = d.Id_Regione "

        Return String.Format(query1, anno, causale)


    End Function

    Public Function FindListaRiepiloghiQuac(ByVal anno As Int32, idCausale As Int32, provinciali As Boolean, orderbyProvincia As Boolean) As IList
        Dim rs As IDataReader = Nothing
        Dim Datalist As IList
        Dim Lista As IList
        Dim connectionExternallyOpened As Boolean = False
        Try
            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
            Else
                m_PersistentService.CurrentConnection.Open()
            End If
            Dim cmd As IDbCommand
            If provinciali Then
                cmd = GetCommand(RiepilogoQuacProvincia(anno, idCausale, orderbyProvincia))
            Else
                cmd = GetCommand(RiepilogoQuacRegione(anno, idCausale))
            End If


            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadAll(Datalist)
            If connectionExternallyOpened = False Then
                m_PersistentService.CurrentConnection.Close()
            End If
            Return Lista
        Catch ex As Exception
            Throw
        Finally
            ReleaseDBDatareader(rs)
            Datalist = New ArrayList
            If connectionExternallyOpened = False Then
                If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then m_PersistentService.CurrentConnection.Close()
            End If
        End Try
    End Function


    Protected Overrides Function CastToObject(item As DOMAIN.Amministrazione.AbstractMovimentoContabile) As DOMAIN.Amministrazione.AbstractMovimentoContabile
        If item Is Nothing Then
            Return New Quac
        End If
        Return DirectCast(item, Quac)
    End Function

 

End Class



