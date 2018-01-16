Public Class MapperDocumentScope
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_DocScope"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from App_DocScope where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into App_DocScope (DocScopeName, CreatedBy, CreatedOn, Color, ProtocolCode, Responsable, RespProtocolCode,DefaultPath, Visibility) values ( @Desc, @CRby, @CRon, @col,@prcode, @resp, @repc, @def, @vis)"
    End Function


    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_DocScope SET DocScopeName = @Desc, ModifiedBy = @MOby, ModifiedOn = @MOon, Color = @col, ProtocolCode=@prcode, Responsable = @resp, RespProtocolCode = @repc, DefaultPath=@def, Visibility = @vis  WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_DocScope where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope)

    End Function

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope
        element.Descrizione = rs.Item("DocScopeName")
        element.Color = rs.Item("Color")
        element.ProtocolCode = IIf(rs.Item("ProtocolCode") IsNot Nothing, rs.Item("ProtocolCode"), "")
        element.DefaultPath = IIf(rs.Item("DefaultPath") IsNot Nothing, rs.Item("DefaultPath"), "")

        element.Responsable = IIf(rs.Item("Responsable") IsNot Nothing, rs.Item("Responsable"), "")
        element.ResponsableProtocolCode = IIf(rs.Item("RespProtocolCode") IsNot Nothing, rs.Item("RespProtocolCode"), "")
        element.Visibility = IIf(rs.Item("Visibility") IsNot Nothing, rs.Item("Visibility"), "")
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
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope)

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
        param.ParameterName = "@prcode"
        If String.IsNullOrEmpty(elemento.ProtocolCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ProtocolCode
        End If
        Cmd.Parameters.Add(param)




        param = Cmd.CreateParameter
        param.ParameterName = "@resp"
        If String.IsNullOrEmpty(elemento.Responsable) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Responsable
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@repc"
        If String.IsNullOrEmpty(elemento.ResponsableProtocolCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ResponsableProtocolCode
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@def"
        If String.IsNullOrEmpty(elemento.DefaultPath) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.DefaultPath
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@vis"
        If String.IsNullOrEmpty(elemento.Visibility) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Visibility
        End If
        Cmd.Parameters.Add(param)

    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope)

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
        param.ParameterName = "@prcode"
        If String.IsNullOrEmpty(elemento.ProtocolCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ProtocolCode
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@resp"
        If String.IsNullOrEmpty(elemento.Responsable) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Responsable
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@repc"
        If String.IsNullOrEmpty(elemento.ResponsableProtocolCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ResponsableProtocolCode
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@def"
        If String.IsNullOrEmpty(elemento.DefaultPath) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.DefaultPath
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@vis"
        If String.IsNullOrEmpty(elemento.Visibility) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Visibility
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub

End Class
