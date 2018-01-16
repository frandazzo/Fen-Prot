Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione


Public Class MapperTesseramentoRimessa
    Inherits AbstractRDBMapper

    Public Sub New()
        'MyBase.Cache = New PersistentObjectCache(True)
        Me.m_IsAutoIncrementID = True
    End Sub

    'Protected m_table As String

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Amm_QuoteTesseramento"

    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "SELECT * FROM Amm_QuoteTesseramento WHERE (ID = @Id)"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into Amm_QuoteTesseramento (Data, Importo, Id_Provincia, " _
             & "NomeProvincia, Id_Regione, NomeRegione, Note, Id_CausaleAmministrazione, Anno) values (" _
             & "@dat, @imp, @idp, @nmp, @idr, @nmr, @not, @idc, @ann)"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Amm_QuoteTesseramento SET " _
              & "Data = @dat, " _
              & "Importo = @imp, " _
              & "Id_Provincia = @idp, " _
              & "NomeProvincia = @nmp, " _
              & "Id_Regione = @idr, " _
              & "NomeRegione = @nmr, " _
              & "Note = @not, " _
              & "Id_CausaleAmministrazione = @idc, Anno = @ann where (Id =@Id) "
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Amm_QuoteTesseramento where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), TesseramentoRimessa)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), TesseramentoRimessa)


    End Function

#End Region


    'Protected Overridable Function CastToObject(item As AbstractMovimentoContabile) As AbstractMovimentoContabile
    '    If item Is Nothing Then
    '        Return New AbstractMovimentoContabile
    '    End If
    '    Return DirectCast(item, AbstractMovimentoContabile)
    'End Function



    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim app As AbstractMovimentoContabile = DirectCast(Item, AbstractMovimentoContabile)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@dat"
            param.Value = app.Data
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@imp"
            param.Value = app.Importo
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idp"
            If app.Provincia.Descrizione = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Provincia.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@nmp"
            If app.Provincia.Descrizione = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Provincia.Descrizione
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@idr"
            If app.Regione.Descrizione = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Regione.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@nmr"
            If app.Regione.Descrizione = "" Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Regione.Descrizione
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@not"
            If String.IsNullOrEmpty(app.Note) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Note
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idc"
            If app.Causale Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Causale.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ann"
            param.Value = app.Competenza
            Cmd.Parameters.Add(param)


        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Movimento Contabile." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim app As AbstractMovimentoContabile = DirectCast(Item, AbstractMovimentoContabile)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@dat"
            param.Value = app.Data
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@imp"
            param.Value = app.Importo
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idp"
            If app.Provincia Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Provincia.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@nmp"
            If app.Provincia Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Provincia.Descrizione
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@idr"
            If app.Regione Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Regione.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@nmr"
            If app.Regione Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Regione.Descrizione
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@not"
            If String.IsNullOrEmpty(app.Note) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Note
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idc"
            If app.Causale Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Causale.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@ann"
            param.Value = app.Competenza
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = app.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Movimento Contabile." & vbCrLf & ex.Message)
        End Try
    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject



        Dim MapperProvincia As MapperProvincia = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProvincia")
        Dim MapperRegione As MapperRegione = PersistenceMapperRegistry.Instance.GetMapperByName("MapperRegione")

        Dim ID_PROVINCIA As Int32 = IIf(rs.Item("Id_Provincia") IsNot Nothing, rs.Item("Id_Provincia"), -1)
        Dim PROVINCIA As Provincia = IIf(ID_PROVINCIA = -1, Nothing, MapperProvincia.FindObjectById(ID_PROVINCIA))


        Dim Anno As Int32 = IIf(rs.Item("Anno") IsNot Nothing, rs.Item("Anno"), 0)

        Dim ID_REGIONE As Int32 = IIf(rs.Item("Id_Regione") IsNot Nothing, rs.Item("Id_Regione"), -1)
        Dim REGIONE As Regione = IIf(ID_REGIONE = -1, Nothing, MapperRegione.FindObjectById(ID_REGIONE))


        Dim Data As DateTime = IIf(rs.Item("Data") IsNot Nothing, rs.Item("Data"), DateTime.MinValue)
        Dim Importo As Double = IIf(rs.Item("Importo") IsNot Nothing, rs.Item("Importo"), 0)
        ''valore di convenienza nella gestione dei report
        'Dim numQuote As Int32 = IIf(rs.Item("numQuote") IsNot Nothing, rs.Item("numQuote"), 1)


        Dim Id_CausaleAmministrazione As Int32 = IIf(rs.Item("Id_CausaleAmministrazione") IsNot Nothing, rs.Item("Id_CausaleAmministrazione"), -1)
        Dim MapperCausaleAmministrativa As MapperCausaleAmministrativa = PersistenceMapperRegistry.Instance.GetMapperByName("MapperCausaleAmministrativa")
        Dim Causale As CausaleAmministrativa = Nothing
        If Id_CausaleAmministrazione > -1 Then
            Causale = MapperCausaleAmministrativa.FindObjectById(Id_CausaleAmministrazione)
        End If

        Dim Note As String = IIf(rs.Item("Note") IsNot Nothing, rs.Item("Note"), "")


        Dim app As AbstractMovimentoContabile = New TesseramentoRimessa

        app.Key = Key


        app.Data = Data
        app.Importo = Importo
        If REGIONE IsNot Nothing Then
            app.Regione = REGIONE
        Else
            app.Regione = New RegioneNulla

        End If
        If PROVINCIA IsNot Nothing Then
            app.Provincia = PROVINCIA
        Else

            app.Provincia = New ProvinciaNulla

        End If

        app.Note = Note
        app.Causale = Causale


        app.Competenza = Anno


        Return app
    End Function






End Class




'End Class
'    Inherits AbstraactMovimentoContabile



'    Protected Overrides Function CastToObject(item As DOMAIN.Amministrazione.AbstractMovimentoContabile) As DOMAIN.Amministrazione.AbstractMovimentoContabile
'        If item Is Nothing Then
'            Return New TesseramentoRimessa
'        End If
'        Return DirectCast(item, TesseramentoRimessa)
'    End Function

'    Public Sub New()
'        m_table = "Amm_QuoteTesseramento"
'    End Sub




'End Class
