Public Class MapperRole
    Inherits AbstractRDBMapper

    Public Sub New()
        MyBase.Cache = New PersistentObjectCache(True)
    End Sub

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Role"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Role where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Role (ID, DESCRIZIONE) values (@Id, @Desc)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Role SET Descrizione = @Desc WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Role where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return "Select Max(Id) from Role"
    End Function

    Private Function FindUserByRoleId() As String
        Return "Select * from Users WHERE RoleID = @IdRole"
    End Function

    Private Function FindProfileByRoleId() As String
        Return "SELECT    * " _
              & "FROM         Profile INNER JOIN " _
              & "RoleProfile ON Profile.ID = RoleProfile.ProfileID " _
              & "WHERE     (RoleProfile.RoleID = @IdRole)"
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Role)


    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Try
            Dim role As New Role
            role.Key = Key
            role.Descrizione = rs.Item("DESCRIZIONE")

            Dim VirtualList1 As LazyLoadUserForRole = New LazyLoadUserForRole(role)
            role.SetUserProxy(VirtualList1)

            Dim VirtualList2 As LazyLoadProfileForRole = New LazyLoadProfileForRole(role)
            role.SetProfileProxy(VirtualList2)


            Return role
        Catch ex As Exception
            Throw New Exception("Impossibile caricare l'oggetto ruolo con Id = " & Key.LongValue & ". " & vbCrLf & ex.Message)
        End Try
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim role As Role = DirectCast(Item, Role)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Desc"
            param.Value = role.Descrizione
            Cmd.Parameters.Add(param)






        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di inserimento dell'oggetto ruolo." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim role As Role = DirectCast(Item, Role)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Desc"
            param.Value = role.Descrizione
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = role.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto ruolo." & vbCrLf & ex.Message)
        End Try
    End Sub


    Friend Function FindRoleByProfile(ByVal Profile As Profile) As IList
        Dim connectionExternallyOpened As Boolean = False



        Try
            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
                'DBConnectionManager.Instance.GetCurrentConnection.Close()
            Else
                m_PersistentService.CurrentConnection.Open()
            End If
            Dim lista As IList = Me.FindByQuery("SELECT     Role.* " _
                                       & "FROM         RoleProfile INNER JOIN " _
                                       & "Role ON RoleProfile.RoleID = Role.ID " _
                                       & "WHERE     (RoleProfile.ProfileID = " & Profile.Id & ")")



            If connectionExternallyOpened = False Then
                m_PersistentService.CurrentConnection.Close()
            End If

            Return lista

        Catch ex As Exception
            Throw

        Finally
            If connectionExternallyOpened = False Then
                If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then m_PersistentService.CurrentConnection.Close()
            End If
        End Try


    End Function



    Public Function FindUsers(ByVal Role As Role) As IList
        Dim rs As IDataReader = Nothing
        Dim Datalist As IList
        Dim Lista As IList
        Dim connectionExternallyOpened As Boolean = False
        Try

            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
                'DBConnectionManager.Instance.GetCurrentConnection.Close()
            Else
                m_PersistentService.CurrentConnection.Open()
            End If



            Dim cmd As IDbCommand = GetCommand(FindUserByRoleId)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@IdRole"
            param.Value = Role.IDRole
            cmd.Parameters.Add(param)
            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadUsers(Datalist, Role)

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

    Public Function Findprofiles(ByVal Role As Role) As IList
        Dim rs As IDataReader = Nothing
        Dim Datalist As IList
        Dim Lista As IList
        Dim connectionExternallyOpened As Boolean = False
        Try

            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
                'DBConnectionManager.Instance.GetCurrentConnection.Close()
            Else
                m_PersistentService.CurrentConnection.Open()
            End If



            Dim cmd As IDbCommand = GetCommand(FindProfileByRoleId)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@IdRole"
            param.Value = Role.IDRole
            cmd.Parameters.Add(param)
            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadProfiles(Datalist, Role)

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
    Protected Function LoadUsers(ByVal rs As IList, ByVal Role As Role) As IList
        Dim List As New ArrayList
        Dim mapperUtenti As MapperUser = PersistenceMapperRegistry.Instance.GetMapperByName("MapperUser")
        For Each elem As Hashtable In rs
            List.Add(mapperUtenti.FindObjectById(elem.Item("ID")))
        Next
        Return List
    End Function

    Protected Function LoadProfiles(ByVal rs As IList, ByVal Role As Role) As IList
        Dim List As New ArrayList
        Dim mapperProfili As MapperProfile = PersistenceMapperRegistry.Instance.GetMapperByName("MapperProfile")
        For Each elem As Hashtable In rs
            List.Add(mapperProfili.FindObjectById(elem.Item("ID")))
        Next
        Return List
    End Function

End Class

