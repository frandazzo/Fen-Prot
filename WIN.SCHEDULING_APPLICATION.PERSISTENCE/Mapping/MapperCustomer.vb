Public Class MapperCustomer
    Inherits AbstractRDBMapper

    Public Sub New()
        m_IsAutoIncrementID = True
    End Sub

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_Customers"
    End Function
    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from App_Customers where Id = @Id"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into App_Customers (COGNOME, ID_TB_PROVINCIE_RESIDENZA, ID_TB_COMUNI_RESIDENZA, INDIRIZZO, CAP,  " _
        & "CODICE_FISCALE, CreatedBy, CreatedOn, " _
        & " MAIL, CELL1, CELL2, FAX, TEL_UF, NOME, Is_Privato, Notes, ResourceID,Marca, Modello, Matricola, Abbonato,   SESSO, DATA_NASCITA, ID_TB_NAZIONI, ID_TB_PROVINCIE_NASCITA, ID_TB_COMUNI_NASCITA, ID_TB_NAZIONI_RESIDENZA)  values ( @Desc, @Pro, @Com, @Ind, @Cap, @IPI, " _
        & " @CRby, @CRon, @Mai, @Ce1, @Ce2, @Fax, @Tuf, @Respo, @IsP, @Notes, @resid, @marca, @modello, @matr, @abb, @Ses, @Dat, @Naz, @RegN, @ComN, @NazR)"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_Customers SET Cognome = @Desc, ID_TB_PROVINCIE_RESIDENZA = @Pro, ID_TB_COMUNI_RESIDENZA = @Com, INDIRIZZO = @Ind, CAP = @Cap," _
        & "CODICE_FISCALE = @IPI, ModifiedBy = @MOby, ModifiedOn = @MOon, " _
        & " Mail = @Mai, Cell1 = @Ce1, Cell2 = @Ce2, Fax = @Fax, Tel_uf = @Tuf, NOME = @Respo, Is_Privato = @IsP, Notes = @Notes, ResourceID = @resid, Marca = @marca, modello = @modello, matricola = @matr, abbonato = @abb,Sesso= @Ses, Data_Nascita = @Dat, ID_TB_NAZIONI = @Naz, " _
         & "ID_TB_PROVINCIE_NASCITA = @RegN, ID_TB_COMUNI_NASCITA = @ComN, ID_TB_NAZIONI_RESIDENZA = @NazR  WHERE (Id =@Id )"
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_Customers where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand
    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)

    'End Function

#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"



    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), Customer)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Customer)


    End Function

#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim avv As Customer = DirectCast(Item, Customer)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Desc"
            param.Value = avv.Cognome
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Pro"
            If avv.Residenza.Provincia.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Provincia.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Com"
            If avv.Residenza.Comune.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Comune.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Ind"
            If avv.Residenza.Via = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Via
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Cap"
            If avv.Residenza.Cap = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Cap
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@IPI"
            If avv.CodiceFiscale = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.CodiceFiscale
            End If
            Cmd.Parameters.Add(param)



            JournalingDataLoader.LoadJournalingInsertCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)




            param = Cmd.CreateParameter
            param.ParameterName = "@Mai"
            If avv.Comunicazione.Mail = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Mail
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Ce1"
            If avv.Comunicazione.Cellulare1 = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Cellulare1
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Ce2"
            If avv.Comunicazione.Cellulare2 = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Cellulare2
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Fax"
            If avv.Comunicazione.Fax = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Fax
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Tuf"
            If avv.Comunicazione.TelefonoUfficio = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.TelefonoUfficio
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Respo"
            If avv.Nome = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Nome
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@IsP"
            param.Value = avv.Is_Private
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Notes"
            param.Value = avv.Note
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@resid"
            If avv.Resource Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Resource.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@marca"
            param.Value = avv.Marca
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@modello"
            param.Value = avv.Modello
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@matr"
            param.Value = avv.Matricola
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@abb"
            param.Value = avv.IsAbbonato
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Ses"
            param.Value = CInt(avv.Sesso)
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Dat"
            If avv.DataNascita = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.DataNascita.Date
            End If
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Naz"
            If avv.Nazionalita.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Nazionalita.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@RegN"
            If avv.ProvinciaNascita.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.ProvinciaNascita.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@ComN"
            If avv.ComuneNascita.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.ComuneNascita.Id
            End If
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@NazR"
            If avv.Residenza.Nazione.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Nazione.Id
            End If
            Cmd.Parameters.Add(param)




        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di inserimento dell'oggetto Cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try

            Dim avv As Customer = DirectCast(Item, Customer)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Desc"
            param.Value = avv.Cognome
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Pro"
            If avv.Residenza.Provincia.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Provincia.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Com"
            If avv.Residenza.Comune.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Comune.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Ind"
            If avv.Residenza.Via = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Via
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Cap"
            If avv.Residenza.Cap = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Cap
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@IPI"
            If avv.CodiceFiscale = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.CodiceFiscale
            End If
            Cmd.Parameters.Add(param)



            JournalingDataLoader.LoadJournalingUpdateCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)




            param = Cmd.CreateParameter
            param.ParameterName = "@Mai"
            If avv.Comunicazione.Mail = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Mail
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Ce1"
            If avv.Comunicazione.Cellulare1 = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Cellulare1
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Ce2"
            If avv.Comunicazione.Cellulare2 = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Cellulare2
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Fax"
            If avv.Comunicazione.Fax = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.Fax
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Tuf"
            If avv.Comunicazione.TelefonoUfficio = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Comunicazione.TelefonoUfficio
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Respo"
            If avv.Nome = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Nome
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@IsP"
            param.Value = avv.Is_Private
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Notes"
            param.Value = avv.Note
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@resid"
            If avv.Resource Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Resource.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@marca"
            param.Value = avv.Marca
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@modello"
            param.Value = avv.Modello
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@matr"
            param.Value = avv.Matricola
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@abb"
            param.Value = avv.IsAbbonato
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Ses"
            param.Value = CInt(avv.Sesso)
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Dat"
            If avv.DataNascita = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.DataNascita.Date
            End If
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Naz"
            If avv.Nazionalita.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Nazionalita.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@RegN"
            If avv.ProvinciaNascita.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.ProvinciaNascita.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@ComN"
            If avv.ComuneNascita.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.ComuneNascita.Id
            End If
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@NazR"
            If avv.Residenza.Nazione.Id = -1 Then
                param.Value = DBNull.Value
            Else
                param.Value = avv.Residenza.Nazione.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = avv.Id
            Cmd.Parameters.Add(param)


        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim Desc As String = IIf(rs.Item("COGNOME") IsNot Nothing, rs.Item("COGNOME"), "")



        Dim VIA As String = IIf(rs.Item("INDIRIZZO") IsNot Nothing, rs.Item("INDIRIZZO"), "")
        Dim CAP As String = IIf(rs.Item("CAP") IsNot Nothing, rs.Item("CAP"), "")
        Dim MapperProvincia As MapperProvincia = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProvincia")
        Dim MapperComune As MapperComune = PersistenceMapperRegistry.Instance.GetMapperByName("MapperComune")
        Dim MapperNazione As MapperNazione = PersistenceMapperRegistry.Instance.GetMapperByName("MapperNazione")

        Dim ID_NAZIONEn As Int32 = IIf(rs.Item("ID_TB_NAZIONI") IsNot Nothing, rs.Item("ID_TB_NAZIONI"), -1)
        Dim NAZIONEn As Nazione = IIf(ID_NAZIONEn = -1, New NazioneNulla, MapperNazione.FindObjectById(ID_NAZIONEn))

        Dim ID_PROVINCIAn As Int32 = IIf(rs.Item("ID_TB_PROVINCIE_NASCITA") IsNot Nothing, rs.Item("ID_TB_PROVINCIE_NASCITA"), -1)
        Dim PROVINCIAn As Provincia = IIf(ID_PROVINCIAn = -1, New ProvinciaNulla, MapperProvincia.FindObjectById(ID_PROVINCIAn))

        Dim ID_COMUNEn As Int32 = IIf(rs.Item("ID_TB_COMUNI_NASCITA") IsNot Nothing, rs.Item("ID_TB_COMUNI_NASCITA"), -1)
        Dim COMUNEn As Comune = IIf(ID_COMUNEn = -1, New ComuneNullo, MapperComune.FindObjectById(ID_COMUNEn))

        Dim DATA_N As Date = IIf(rs.Item("DATA_NASCITA") IsNot Nothing, rs.Item("DATA_NASCITA"), DateTime.MinValue)
        Dim SESSO As Int32 = IIf(rs.Item("SESSO") IsNot Nothing, rs.Item("SESSO"), 0)

        Dim ID_NAZIONEr As Int32 = IIf(rs.Item("ID_TB_NAZIONI_RESIDENZA") IsNot Nothing, rs.Item("ID_TB_NAZIONI_RESIDENZA"), -1)
        Dim NAZIONEr As Nazione = IIf(ID_NAZIONEr = -1, New NazioneNulla, MapperNazione.FindObjectById(ID_NAZIONEr))


        Dim ID_PROVINCIA As Int32 = IIf(rs.Item("ID_TB_PROVINCIE_RESIDENZA") IsNot Nothing, rs.Item("ID_TB_PROVINCIE_RESIDENZA"), -1)
        Dim PROVINCIA As Provincia = IIf(ID_PROVINCIA = -1, New ProvinciaNulla, MapperProvincia.FindObjectById(ID_PROVINCIA))

        Dim ID_COMUNE As Int32 = IIf(rs.Item("ID_TB_COMUNI_RESIDENZA") IsNot Nothing, rs.Item("ID_TB_COMUNI_RESIDENZA"), -1)
        Dim COMUNE As Comune = IIf(ID_COMUNE = -1, New ComuneNullo, MapperComune.FindObjectById(ID_COMUNE))

        Dim PI As String = IIf(rs.Item("CODICE_FISCALE") IsNot Nothing, rs.Item("CODICE_FISCALE"), "")
        Dim TEL_UF As String = IIf(rs.Item("TEL_UF") IsNot Nothing, rs.Item("TEL_UF"), "")
        Dim MAIL As String = IIf(rs.Item("MAIL") IsNot Nothing, rs.Item("MAIL"), "")
        Dim FAX As String = IIf(rs.Item("FAX") IsNot Nothing, rs.Item("FAX"), "")
        Dim CELL1 As String = IIf(rs.Item("CELL1") IsNot Nothing, rs.Item("CELL1"), "")
        Dim CELL2 As String = IIf(rs.Item("CELL2") IsNot Nothing, rs.Item("CELL2"), "")
        Dim RESPONSABLE As String = IIf(rs.Item("NOME") IsNot Nothing, rs.Item("NOME"), "")
        Dim privato As Boolean = IIf(rs.Item("IS_PRIVATO") IsNot Nothing, rs.Item("IS_PRIVATO"), False)

        Dim abbonato As Boolean = IIf(rs.Item("Abbonato") IsNot Nothing, rs.Item("Abbonato"), False)
        Dim marca As String = IIf(rs.Item("Marca") IsNot Nothing, rs.Item("Marca"), "")
        Dim modello As String = IIf(rs.Item("Modello") IsNot Nothing, rs.Item("Modello"), "")
        Dim matricola As String = IIf(rs.Item("Matricola") IsNot Nothing, rs.Item("Matricola"), "")



        Dim notes As String = IIf(rs.Item("NOTES") IsNot Nothing, rs.Item("NOTES"), "")


        Dim ID_Res As Int32 = IIf(rs.Item("ResourceID") IsNot Nothing, rs.Item("ResourceID"), -1)
        Dim MapperResource As MapperResource = PersistenceMapperRegistry.Instance.GetMapperByName("MapperResource")
        Dim resource As Resource = MapperResource.FindObjectById(ID_Res)

        Dim avv As Customer = New Customer
        avv.Key = Key


        avv.Cognome = Desc
        avv.Nome = RESPONSABLE

        avv.Residenza.Comune = COMUNE
        avv.Residenza.Provincia = PROVINCIA
        avv.Residenza.Cap = CAP
        avv.Residenza.Via = VIA
        avv.Residenza.Nazione = NAZIONEr

        avv.ComuneNascita = COMUNEn
        avv.ProvinciaNascita = PROVINCIAn
        avv.Nazionalita = NAZIONEn
        avv.Sesso = SESSO
        avv.DataNascita = DATA_N

        avv.CodiceFiscale = PI
        avv.Comunicazione = New Comunicazioni
        avv.Comunicazione.Cellulare1 = CELL1
        avv.Comunicazione.Cellulare2 = CELL2
        avv.Comunicazione.Fax = FAX

        avv.Comunicazione.TelefonoUfficio = TEL_UF
        avv.Comunicazione.Mail = MAIL
        avv.Is_Private = privato
        avv.Note = notes
        avv.Resource = resource

        avv.Marca = marca
        avv.Modello = modello
        avv.Matricola = matricola
        avv.IsAbbonato = abbonato


        JournalingDataLoader.ReadJournalingParameters(avv, rs)

        Return avv
    End Function
End Class
