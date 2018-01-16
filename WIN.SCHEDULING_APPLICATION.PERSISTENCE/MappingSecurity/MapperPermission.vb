Public Class MapperPermission
    Inherits AbstractRDBMapper

    Public Sub New()
        MyBase.Cache = New PersistentObjectCache(True)
    End Sub

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Permissions"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Permissions where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Permissions (ID, ProfileID,  FullMethodName) values (@Id, @Idp,  @ful)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Permissions SET ProfileID = @Idp,  FullMethodName = @ful WHERE (ID =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Permissions where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return "Select Max(Id) from Permissions"
    End Function
#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Permission)


    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Try
            Dim Permission As New Permission
            Permission.Key = Key
            Permission.FullMethodName = rs.Item("FullMethodName")


            Dim MapperProfile As MapperProfile = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProfile")



            Dim Profile As Profile = MapperProfile.FindObjectById(rs.Item("ProfileID"))
            Permission.Profile = Profile



            Return Permission
        Catch ex As Exception
            Throw New Exception("Impossibile caricare l'oggetto Permesso con Id = " & Key.LongValue & ". " & vbCrLf & ex.Message)
        End Try
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#End Region



    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim Permission As Permission = DirectCast(Item, Permission)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Idp"
            param.Value = Permission.Profile.ID
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ful"
            param.Value = Permission.FullMethodName
            Cmd.Parameters.Add(param)






        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di inserimento dell'oggetto Permesso." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim Permission As Permission = DirectCast(Item, Permission)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Idp"
            param.Value = Permission.Profile.ID
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ful"
            param.Value = Permission.FullMethodName
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = Permission.Key.Value(0)
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Permesso." & vbCrLf & ex.Message)
        End Try
    End Sub


End Class

