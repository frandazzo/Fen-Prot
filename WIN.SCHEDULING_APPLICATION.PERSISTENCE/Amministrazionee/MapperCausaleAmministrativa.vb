Public Class MapperCausaleAmministrativa
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Amm_CausaliAmministrazione"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Amm_CausaliAmministrazione where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Amm_CausaliAmministrazione (Descrizione, TipoCausale) values ( @Desc, @Tic)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Amm_CausaliAmministrazione SET Descrizione = @Desc, TipoCausale = @Tic  WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Amm_CausaliAmministrazione where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa)

    End Function
    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa
        element.Descrizione = rs.Item("Descrizione")
        element.Tipo = rs.Item("TipoCausale")
        element.Key = Key

        Return element
    End Function


#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

      
        param = Cmd.CreateParameter
        param.ParameterName = "@Tic"
        param.Value = elemento.Tipo
        Cmd.Parameters.Add(param)

    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.CausaleAmministrativa)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Tic"
        param.Value = elemento.Tipo
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub
End Class
