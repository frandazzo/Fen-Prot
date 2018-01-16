Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione

Public Class RiepilogoTesseramentoMapper

    Inherits AbstractRDBMapper

    Public Sub New()
        Me.UseDefaultCacheMechanism = False
        Me.Cache = New PersistentObjectCache(0)
    End Sub

    Protected m_table As String

    Protected Overrides Function FindAllStatement() As String
        Return ""

    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return ""
    End Function
    Protected Overrides Function InsertStatement() As String
        Return ""
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return " "
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return ""
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function


    Public Function RiepilogoTesseramentoAnno(anno As Int32) As String

        Dim query As String = "select i.Id_provincia as ID, " _
                & "i.Id_provincia, i.NomeProvincia, i.Id_Regione, " _
                & "i.NomeRegione, i.TessereRichieste, i.Totale, " _
                & "g.Importo, g.NumeroQuote, i.totale - g.importo as DaVersare " _
                & "from Amm_ImpegniTesseramento i left outer join " _
                & "( " _
                    & " select  p.Id as Id_Provincia, " _
                    & "p.Descrizione as NomeProvincia, " _
                    & "d.Importo, d.numeroQuote  from tb_provincie p inner join " _
                        & " ( " _
                        & "SELECT     q.Id_Provincia, sum(q.Importo) as Importo, count(*) as numeroQuote " _
                        & "FROM        Amm_QuoteTesseramento q where q.Anno = {0} " _
                        & " GROUP BY q.Id_Provincia " _
                        & " ) d on p.Id = d.Id_Provincia  " _
                & " ) g  " _
                & " on i.id_provincia = g.id_provincia " _
                & " where i.anno = {0}"



        'Dim query As String = "select i.Id_provincia as ID, " _
        '      & "i.Id_provincia, i.NomeProvincia, i.Id_Regione, " _
        '      & "i.NomeRegione, i.TessereRichieste, i.Totale, " _
        '      & "g.Importo, g.NumeroQuote, i.totale - g.importo as DaVersare " _
        '      & "from Amm_ImpegniTesseramento i left outer join " _
        '      & "( " _
        '          & " select  p.Id as Id_Provincia, " _
        '          & "p.Descrizione as NomeProvincia, " _
        '          & "d.Importo, d.numeroQuote  from tb_provincie p inner join " _
        '              & " ( " _
        '              & "SELECT     q.Id_Provincia, sum(q.Importo) as Importo, count(*) as numeroQuote " _
        '              & "FROM        Amm_QuoteTesseramento q where year(q.Data) = {0} " _
        '              & " GROUP BY q.Id_Provincia " _
        '              & " ) d on p.Id = d.Id_Provincia  " _
        '      & " ) g  " _
        '      & " on i.id_provincia = g.id_provincia " _
        '      & " where i.anno = {0}"

        Return String.Format(query, anno)


    End Function

    Public Function RiepilogoTesseramentoAnnoProvincia(anno As Int32, idprovincia As Int32) As String

        Dim query As String = "select i.Id_provincia as ID, " _
                & "i.Id_provincia, i.NomeProvincia, i.Id_Regione, " _
                & "i.NomeRegione, i.TessereRichieste, i.Totale, " _
                & "g.Importo, g.NumeroQuote, i.totale - g.importo as DaVersare " _
                & "from Amm_ImpegniTesseramento i left outer join " _
                & "( " _
                    & " select  p.Id as Id_Provincia, " _
                    & "p.Descrizione as NomeProvincia, " _
                    & "d.Importo, d.numeroQuote  from tb_provincie p inner join " _
                        & " ( " _
                        & "SELECT     q.Id_Provincia, sum(q.Importo) as Importo, count(*) as numeroQuote " _
                        & "FROM        Amm_QuoteTesseramento q where q.Anno = {0} " _
                        & " GROUP BY q.Id_Provincia " _
                        & " ) d on p.Id = d.Id_Provincia  " _
                & " ) g  " _
                & " on i.id_provincia = g.id_provincia " _
                & " where i.anno = {0} and i.id_provincia = {1}"

        Return String.Format(query, anno, idprovincia)


    End Function

    Public Function FindListaRiepiloghiPerAnno(ByVal anno As Int32) As IList
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
            Dim cmd As IDbCommand = GetCommand(RiepilogoTesseramentoAnno(anno))
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
    Public Function FindListaRiepiloghiPerAnnoProvincia(ByVal anno As Int32, idProvincia As Int32) As IList
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
            Dim cmd As IDbCommand = GetCommand(RiepilogoTesseramentoAnnoProvincia(anno, idProvincia))
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


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), RiepilogoTesseramento)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), RiepilogoTesseramento)


    End Function

#End Region






    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)


    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)

    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject



        Dim MapperProvincia As MapperProvincia = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProvincia")
        Dim MapperRegione As MapperRegione = PersistenceMapperRegistry.Instance.GetMapperByName("MapperRegione")

        Dim ID_PROVINCIA As Int32 = IIf(rs.Item("Id_provincia") IsNot Nothing, rs.Item("Id_provincia"), -1)
        Dim PROVINCIA As Provincia = IIf(ID_PROVINCIA = -1, Nothing, MapperProvincia.FindObjectById(ID_PROVINCIA))


        Dim ID_REGIONE As Int32 = IIf(rs.Item("Id_Regione") IsNot Nothing, rs.Item("Id_Regione"), -1)
        Dim REGIONE As Regione = IIf(ID_REGIONE = -1, Nothing, MapperRegione.FindObjectById(ID_REGIONE))



        Dim Importo As Double = IIf(rs.Item("Importo") IsNot Nothing, rs.Item("Importo"), 0)
        Dim numQuote As Int32 = IIf(rs.Item("NumeroQuote") IsNot Nothing, rs.Item("NumeroQuote"), 0)
        Dim TessereRichieste As Double = IIf(rs.Item("TessereRichieste") IsNot Nothing, rs.Item("TessereRichieste"), 0)
        Dim Totale As Double = IIf(rs.Item("Totale") IsNot Nothing, rs.Item("Totale"), 0)
        'se è nulla metto direttamente il totale
        Dim DaVersare As Double = IIf(rs.Item("DaVersare") IsNot Nothing, rs.Item("DaVersare"), Totale)








        Dim app As RiepilogoTesseramento = New RiepilogoTesseramento
        app.Key = Key


        app.ImportoVersato = Importo
        app.Totale = Totale
        app.DaVersare = DaVersare
        app.NumeroQuote = numQuote
        app.TessereRichieste = TessereRichieste


        app.Regione = REGIONE
        app.Provincia = PROVINCIA







        Return app
    End Function






End Class




