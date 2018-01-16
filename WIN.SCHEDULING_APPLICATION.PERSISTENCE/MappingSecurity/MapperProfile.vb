Public Class MapperProfile
    Inherits AbstractRDBMapper

    Public Sub New()
        MyBase.Cache = New PersistentObjectCache(True)
    End Sub

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Profile"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Profile where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Profile (ID, DESCRIZIONE) values (@Id, @Desc)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Profile SET Descrizione = @Desc WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Profile where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return "Select Max(Id) from Profile"
    End Function

    Protected Function FindNextKeyAssociationStatement() As String
        Return "Select Max(Id) from RoleProfile where RoleID = @rol"
    End Function


    Protected Function FindPermissionsByProfileIDStatement() As String
        Return "Select * from Permissions  where ProfileID = @Idp"
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Profile)


    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Try
            Dim Profile As New Profile
            Profile.Key = Key
            Profile.Descrizione = rs.Item("DESCRIZIONE")

            Dim VirtualList1 As LazyLoadPermissionForProfile = New LazyLoadPermissionForProfile(Profile)
            Profile.SetPermissionsProxy(VirtualList1)

            Dim VirtualList2 As LazyLoadRolesByProfile = New LazyLoadRolesByProfile(Profile)
            Profile.SetRolesProxy(VirtualList2)




            Return Profile
        Catch ex As Exception
            Throw New Exception("Impossibile caricare l'oggetto Profilo con Id = " & Key.LongValue & ". " & vbCrLf & ex.Message)
        End Try
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#End Region

    Public Function FindPermissions(ByVal Profile As Profile) As IList
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



            Dim cmd As IDbCommand = GetCommand(FindPermissionsByProfileIDStatement)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@Idp"
            param.Value = Profile.Id
            cmd.Parameters.Add(param)
            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadPermissions(Datalist, Profile)

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


    Protected Function LoadPermissions(ByVal rs As IList, ByVal profile As Profile) As IList
        Dim List As New ArrayList
        Dim mapperUtenti As MapperPermission = PersistenceMapperRegistry.Instance.GetMapperByName("MapperPermission")
        For Each elem As Hashtable In rs
            List.Add(mapperUtenti.FindObjectById(elem.Item("ID")))
        Next
        Return List
    End Function



    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim Profile As Profile = DirectCast(Item, Profile)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Desc"
            param.Value = Profile.Descrizione
            Cmd.Parameters.Add(param)






        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di inserimento dell'oggetto Profilo." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim Profile As Profile = DirectCast(Item, Profile)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Desc"
            param.Value = Profile.Descrizione
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = Profile.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Profilo." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Overloads Function FindNextKeyAssociationKey(ByVal RoleId As Int32) As Key
        Dim rs As IDataReader = Nothing
        Dim cmd As IDbCommand
        Try
            'qui devo leggere l'oggetto in un datareader e caricarlo
            cmd = Me.GetCommand(Me.FindNextKeyAssociationStatement)

            Dim Param As IDataParameter = cmd.CreateParameter
            Param.ParameterName = "@rol"
            Param.Value = RoleId
            cmd.Parameters.Add(Param)

            rs = cmd.ExecuteReader
            rs.Read()
            'Assumo che l'id del pagamento sara il 
            'secondo valore nella lista delle chiavi identificative
            'e l'id della posizione sarà il primo
            If IsDBNull(rs(0)) Then
                rs.Close()
                Dim Newkey As Key = New Key(1, RoleId)
                Return Newkey
            Else
                Dim Id As Int32 = rs(0) + 1
                rs.Close()
                Dim Updatedkey As Key = New Key(Id, RoleId)
                Return Updatedkey
            End If
        Catch ex As Exception
            Throw New Exception("Impossibile trovare una nuova chiave identificativa per l'oggetto. " & vbCrLf & ex.Message)
        Finally
            ReleaseDBDatareader(rs)
        End Try
    End Function


End Class
