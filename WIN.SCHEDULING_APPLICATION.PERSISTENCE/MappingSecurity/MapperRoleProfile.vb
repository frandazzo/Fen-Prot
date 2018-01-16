Public Class MapperRoleProfile
    Inherits AbstractRDBMapper

    Public Sub New()
        MyBase.Cache = New PersistentObjectCache(True)
    End Sub

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Throw New NotImplementedException
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Throw New NotImplementedException
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into RoleProfile (RoleID, ProfileID) values (@Idr, @Idp)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Throw New NotImplementedException
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from RoleProfile where RoleID = @Idr and ProfileID = @Idp"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Throw New NotImplementedException
    End Function



#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Throw New NotImplementedException


    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Throw New NotImplementedException
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim RoleProfile As RoleProfile = DirectCast(Item, RoleProfile)
        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Idr"
        param.Value = RoleProfile.Role.ID
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Idp"
        param.Value = RoleProfile.Profile.ID
        Cmd.Parameters.Add(param)

    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Throw New NotImplementedException
    End Sub



    Public Overrides Function Insert(ByVal item As AbstractPersistenceObject) As Key
        Dim cmd As IDbCommand = Nothing
        Try
            cmd = GetCommand(InsertStatement)
            LoadInsertCommandParameters(item, cmd)
            cmd.ExecuteNonQuery()
            Return New Key(0)
        Catch ex As Exception
            Throw
        End Try
    End Function






    Protected Overrides Sub LoadDeleteCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As IDbCommand)

        Dim RoleProfile As RoleProfile = DirectCast(Item, RoleProfile)
        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Idr"
        param.Value = RoleProfile.Role.ID
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Idp"
        param.Value = RoleProfile.Profile.ID
        Cmd.Parameters.Add(param)

    End Sub



End Class

