Public Class MapperDocumentType
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_DocType"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from App_DocType where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into App_DocType (DocTypeName, CreatedBy, CreatedOn, Color, ProtocolCode) values ( @Desc, @CRby, @CRon, @col, @prot)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_DocType SET DocTypeName = @Desc, ModifiedBy = @MOby, ModifiedOn = @MOon, Color = @col, ProtocolCode = @prot  WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_DocType where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType)

    End Function
    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType
        element.Descrizione = rs.Item("DocTypeName")
        element.ProtocolCode = IIf(rs.Item("ProtocolCode") IsNot Nothing, rs.Item("ProtocolCode"), "")
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
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType)

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
        param.ParameterName = "@prot"
        If String.IsNullOrEmpty(elemento.ProtocolCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ProtocolCode
        End If

        Cmd.Parameters.Add(param)

    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType)

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
        param.ParameterName = "@prot"
        If String.IsNullOrEmpty(elemento.ProtocolCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ProtocolCode
        End If

        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub

End Class

