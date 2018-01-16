Public Class MapperResource
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_Resources"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from App_Resources where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into App_Resources (ResourceName, CreatedBy, CreatedOn, Color, NotDeletable) values ( @Desc, @CRby, @CRon, @col, @not)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_Resources SET ResourceName = @Desc, ModifiedBy = @MOby, ModifiedOn = @MOon, Color = @col, NotDeletable = @not   WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_Resources where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource)

    End Function

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource
        element.Descrizione = rs.Item("ResourceName")
        element.Color = rs.Item("Color")
        element.NonCancellabile = rs.Item("NotDeletable")
        element.Key = Key
        JournalingDataLoader.ReadJournalingParameters(element, rs)
        Return element
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)

    'End Function

#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

        JournalingDataLoader.LoadJournalingInsertCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)

        param = Cmd.CreateParameter
        param.ParameterName = "@Col"
        param.Value = elemento.Color
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@not"
        param.Value = elemento.NonCancellabile
        Cmd.Parameters.Add(param)


    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

        JournalingDataLoader.LoadJournalingUpdateCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)

        param = Cmd.CreateParameter
        param.ParameterName = "@Col"
        param.Value = elemento.Color
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@not"
        param.Value = elemento.NonCancellabile
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub

End Class

