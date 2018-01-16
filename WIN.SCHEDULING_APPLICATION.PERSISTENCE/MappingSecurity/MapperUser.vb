Public Class MapperUser
    Inherits AbstractRDBMapper

    Public Sub New()
        MyBase.Cache = New PersistentObjectCache(True)
    End Sub

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Users"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Users where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Users (ID, RoleID,  Username, Passwordd, Name, Surname) values (@Id, @Idr,  @usd, @pwd, @nam, @sur)"
    End Function

    'Protected Overrides Function UpdateStatement() As String
    '    Return "UPDATE Users SET Username = @usd, Password = @pwd, Name = @nam, Surname = @sur, RoleID = @Idr WHERE (ID = @Id )"
    'End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Users SET Username = @usd, Passwordd = @pwd, Name = @nam, Surname = @sur, RoleID = @Idr WHERE (ID = @Id )"
    End Function


    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Users where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return "Select Max(ID) from Users"
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), User)


    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Try
            Dim User As New User
            User.Key = Key
            User.Username = rs.Item("Username")
            User.Password = rs.Item("Passwordd")
            User.Name = rs.Item("Name")
            User.SurName = rs.Item("Surname")


            Dim MapperRuoli As MapperRole = PersistenceMapperRegistry.Instance.GetMapperByName("MapperRole")



            Dim Role As Role = MapperRuoli.FindObjectById(rs.Item("RoleID"))
            User.Role = Role



            Return User
        Catch ex As Exception
            Throw New Exception("Impossibile caricare l'oggetto Utente con Id = " & Key.LongValue & ". " & vbCrLf & ex.Message)
        End Try
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#End Region



    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim User As User = DirectCast(Item, User)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@Idr"
            param.Value = User.Role.ID
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@usd"
            param.Value = User.Username
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@pwd"
            param.Value = User.Password
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@nam"
            param.Value = User.Name
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@sur"
            param.Value = User.SurName
            Cmd.Parameters.Add(param)



        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di inserimento dell'oggetto Utente." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim User As User = DirectCast(Item, User)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@usd"
            param.Value = User.Username
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@pwd"
            param.Value = User.Password
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@nam"
            param.Value = User.Name
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@sur"
            param.Value = User.SurName
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Idr"
            param.Value = User.Role.ID
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = User.Key.Value(0)
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Utente." & vbCrLf & ex.Message)
        End Try
    End Sub

    'Protected Overloads Function FindNextKey(ByVal RoleId As Int32) As Key
    '   Dim rs As IDataReader = Nothing
    '   Dim cmd As IDbCommand
    '   Try
    '      'qui devo leggere l'oggetto in un datareader e caricarlo
    '      cmd = Me.GetCommand(Me.FindNextKeyStatement)

    '      Dim Param As IDataParameter = cmd.CreateParameter
    '      Param.ParameterName = "@rol"
    '      Param.Value = RoleId
    '      cmd.Parameters.Add(Param)

    '      rs = cmd.ExecuteReader
    '      rs.Read()
    '      'Assumo che l'id del pagamento sara il 
    '      'secondo valore nella lista delle chiavi identificative
    '      'e l'id della posizione sarà il primo
    '      If IsDBNull(rs(0)) Then
    '         rs.Close()
    '         Dim Newkey As Key = New Key(1, RoleId)
    '         Return Newkey
    '      Else
    '         Dim Id As Int32 = rs(0) + 1
    '         rs.Close()
    '         Dim Updatedkey As Key = New Key(Id, RoleId)
    '         Return Updatedkey
    '      End If
    '   Catch ex As Exception
    '      Throw New Exception("Impossibile trovare una nuova chiave identificativa per l'oggetto. " & vbCrLf & ex.Message)
    '   Finally
    '      ReleaseDBDatareader(rs)
    '   End Try
    'End Function
    'Public Overrides Function Insert(ByVal item As AbstractPersistenceObject) As Key

    '   If item.IsValid Then
    '      Return PerformInsert(item, FindNextKey(DirectCast(item, User).Role.ID))
    '   Else
    '      Dim errors As String = ""
    '      For Each elem As String In item.ValidationErrors
    '         errors = errors & elem & vbCrLf
    '      Next
    '      Throw New Exception("L'oggetto inserito non è valido. Controllare il valore dei valori immessi" & vbCrLf & errors)
    '   End If

    'End Function

End Class

