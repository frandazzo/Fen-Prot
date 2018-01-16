Public Class MapperImpegno
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Amm_ImpegniTesseramento"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Amm_ImpegniTesseramento where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Amm_ImpegniTesseramento (Anno, Id_Provincia, " _
             & "NomeProvincia, Id_Regione, NomeRegione, TessereRichieste, Gennaio, " _
             & "Febbraio, Marzo, Aprile, Maggio, Giugno, Luglio, Agosto, Settembre, Ottobre, Novembre, Dicembre, Altro, Totale, Primo, Secondo, Terzo, Quarto, Quinto, Sesto  ) values (@ann,  @idp, @nmp, @idr, @nmr, @tes, @gen, @feb, @mar, @apr, @mag, @giu, @lug, @ago, @set, @ott, @nov, @dic, @alt, @tot, @per1 , @per2 , @per3 , @per4 , @per5 , @per6)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Amm_ImpegniTesseramento SET " _
              & "Anno = @ann, " _
              & "Id_Provincia = @idp, " _
              & "NomeProvincia = @nmp, " _
              & "Id_Regione = @idr, " _
              & "NomeRegione = @nmr, " _
              & "TessereRichieste = @tes, " _
              & "Gennaio = @gen, " _
              & "Febbraio = @feb, " _
              & "Marzo = @mar, " _
              & "Aprile = @apr, " _
              & "Maggio = @mag, " _
              & "Giugno = @giu, " _
              & "Luglio = @lug, " _
              & "Agosto = @ago, " _
              & "Settembre = @set, " _
              & "Ottobre = @ott, " _
              & "Novembre = @nov, " _
              & "Dicembre = @dic, " _
              & "Altro = @alt, " _
              & "Primo = @per1, " _
              & "Secondo = @per2, " _
              & "Terzo = @per3, " _
              & "Quarto = @per4, " _
              & "Quinto = @per5, " _
              & "Sesto = @per6, " _
              & "Totale = @tot where (Id =@Id) "
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Amm_ImpegniTesseramento where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno)

    End Function
    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject






        Dim MapperProvincia As MapperProvincia = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProvincia")
        Dim MapperRegione As MapperRegione = PersistenceMapperRegistry.Instance.GetMapperByName("MapperRegione")

        Dim ID_PROVINCIA As Int32 = IIf(rs.Item("Id_Provincia") IsNot Nothing, rs.Item("Id_Provincia"), -1)
        Dim PROVINCIA As Provincia = IIf(ID_PROVINCIA = -1, Nothing, MapperProvincia.FindObjectById(ID_PROVINCIA))


        Dim ID_REGIONE As Int32 = IIf(rs.Item("Id_Regione") IsNot Nothing, rs.Item("Id_Regione"), -1)
        Dim REGIONE As Regione = IIf(ID_REGIONE = -1, Nothing, MapperRegione.FindObjectById(ID_REGIONE))

        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno

        
        element.Anno = rs.Item("Anno")
        element.Regione = REGIONE
        element.Provincia = PROVINCIA
        element.TessereRichieste = rs.Item("TessereRichieste")
        element.gen = rs.Item("Gennaio")
        element.feb = rs.Item("Febbraio")
        element.mar = rs.Item("Marzo")
        element.apr = rs.Item("Aprile")
        element.mag = rs.Item("Maggio")
        element.giu = rs.Item("Giugno")
        element.lug = rs.Item("Luglio")
        element.ago = rs.Item("Agosto")
        element.set = rs.Item("Settembre")
        element.ott = rs.Item("Ottobre")
        element.nov = rs.Item("Novembre")
        element.dic = rs.Item("Dicembre")
        element.genas = IIf(rs.Item("Primo") IsNot Nothing, rs.Item("Primo"), 0)
        element.febas = IIf(rs.Item("Secondo") IsNot Nothing, rs.Item("Secondo"), 0)
        element.maras = IIf(rs.Item("Terzo") IsNot Nothing, rs.Item("Terzo"), 0)
        element.apras = IIf(rs.Item("Quarto") IsNot Nothing, rs.Item("Quarto"), 0)
        element.magas = IIf(rs.Item("Quinto") IsNot Nothing, rs.Item("Quinto"), 0)
        element.giuas = IIf(rs.Item("Sesto") IsNot Nothing, rs.Item("Sesto"), 0)
        element.altreDate = rs.Item("Altro")
        element.ImpegnoTotale = rs.Item("Totale")
        element.Key = Key

        Return element
    End Function


#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@ann"
        param.Value = elemento.Anno
        Cmd.Parameters.Add(param)

       

        param = Cmd.CreateParameter
        param.ParameterName = "@idp"
        If elemento.Provincia.Descrizione = "" Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Provincia.Id
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@nmp"
        If elemento.Provincia.Descrizione = "" Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Provincia.Descrizione
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@idr"
        If elemento.Regione.Descrizione = "" Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Regione.Id
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@nmr"
        If elemento.Regione.Descrizione = "" Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Regione.Descrizione
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@tes"
        param.Value = elemento.TessereRichieste
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@gen"
        param.Value = elemento.gen
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@feb"
        param.Value = elemento.feb
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@mar"
        param.Value = elemento.mar
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@apr"
        param.Value = elemento.apr
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@mag"
        param.Value = elemento.mag
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@giu"
        param.Value = elemento.giu
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@lug"
        param.Value = elemento.lug
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@ago"
        param.Value = elemento.ago
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@set"
        param.Value = elemento.set
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@ott"
        param.Value = elemento.ott
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@nov"
        param.Value = elemento.nov
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@dic"
        param.Value = elemento.dic
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@alt"
        param.Value = elemento.altreDate
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@tot"
        param.Value = elemento.ImpegnoTotale
        Cmd.Parameters.Add(param)




        param = Cmd.CreateParameter
        param.ParameterName = "@per1"
        param.Value = elemento.genas
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@per2"
        param.Value = elemento.febas
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@per3"
        param.Value = elemento.maras
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@per4"
        param.Value = elemento.apras
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@per5"
        param.Value = elemento.magas
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@per6"
        param.Value = elemento.giuas
        Cmd.Parameters.Add(param)



    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@ann"
        param.Value = elemento.Anno
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@idp"
        If elemento.Provincia Is Nothing Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Provincia.Id
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@nmp"
        If elemento.Provincia Is Nothing Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Provincia.Descrizione
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@idr"
        If elemento.Regione Is Nothing Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Regione.Id
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@nmr"
        If elemento.Regione Is Nothing Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Regione.Descrizione
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@tes"
        param.Value = elemento.TessereRichieste
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@gen"
        param.Value = elemento.gen
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@feb"
        param.Value = elemento.feb
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@mar"
        param.Value = elemento.mar
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@apr"
        param.Value = elemento.apr
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@mag"
        param.Value = elemento.mag
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@giu"
        param.Value = elemento.giu
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@lug"
        param.Value = elemento.lug
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@ago"
        param.Value = elemento.ago
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@set"
        param.Value = elemento.set
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@ott"
        param.Value = elemento.ott
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@nov"
        param.Value = elemento.nov
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@dic"
        param.Value = elemento.dic
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@alt"
        param.Value = elemento.altreDate
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@tot"
        param.Value = elemento.ImpegnoTotale
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@per1"
        param.Value = elemento.genas
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@per2"
        param.Value = elemento.febas
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@per3"
        param.Value = elemento.maras
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@per4"
        param.Value = elemento.apras
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@per5"
        param.Value = elemento.magas
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@per6"
        param.Value = elemento.giuas
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub
End Class
