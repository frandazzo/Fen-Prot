Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class MapperBookingResource
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True

    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Book_Resources"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Book_Resources where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Book_Resources (Description, ImagePath, CreatedBy, CreatedOn, Color) values ( @Desc, @Imp,  @CRby, @CRon, @col)"
    End Function


    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Book_Resources SET Description = @Desc, ImagePath = @Imp, ModifiedBy = @MOby, ModifiedOn = @MOon, Color = @col  WHERE (Id = @Id)"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Book_Resources where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region




    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), BookingResource)

    End Function

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), BookingResource)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New BookingResource
        element.Descrizione = rs.Item("Description")
        element.ImagePath = IIf(rs.Item("ImagePath") IsNot Nothing, rs.Item("ImagePath"), "")
        element.NonCancellabile = rs.Item("NotDeletable")
        element.Color = rs.Item("Color")
        element.Key = Key
        JournalingDataLoader.ReadJournalingParameters(element, rs)
        Return element
    End Function

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As BookingResource = DirectCast(Item, BookingResource)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

        '

        param = Cmd.CreateParameter
        param.ParameterName = "@Imp"
        If String.IsNullOrEmpty(elemento.ImagePath) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ImagePath
        End If
        Cmd.Parameters.Add(param)

        JournalingDataLoader.LoadJournalingInsertCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)

        param = Cmd.CreateParameter
        param.ParameterName = "@Col"
        param.Value = elemento.Color
        Cmd.Parameters.Add(param)

    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As BookingResource = DirectCast(Item, BookingResource)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

        '

        param = Cmd.CreateParameter
        param.ParameterName = "@Imp"
        If String.IsNullOrEmpty(elemento.ImagePath) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.ImagePath
        End If
        Cmd.Parameters.Add(param)

        JournalingDataLoader.LoadJournalingUpdateCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)

        param = Cmd.CreateParameter
        param.ParameterName = "@Col"
        param.Value = elemento.Color
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub
End Class