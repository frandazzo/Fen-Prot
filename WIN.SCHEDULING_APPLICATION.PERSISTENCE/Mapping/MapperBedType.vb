Public Class MapperBedType
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"
    
    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Book_BookingBedTypes"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Book_BookingBedTypes where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Book_BookingBedTypes (Descrizione, NumeroLetti,  CreatedBy, CreatedOn) values (@Desc, @Num, @CRby, @CRon)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Book_BookingBedTypes SET Descrizione = @Desc, NumeroLetti = @Num, ModifiedBy = @MOby, ModifiedOn = @MOon  WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Book_BookingBedTypes where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function
#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"



    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType)


    End Function

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType)

    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType

        element.Descrizione = rs.Item("Descrizione")
        element.NumeroLetti = rs.Item("NumeroLetti")

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
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Num"
        param.Value = elemento.NumeroLetti
        Cmd.Parameters.Add(param)

        JournalingDataLoader.LoadJournalingInsertCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)


    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Desc"
        param.Value = elemento.Descrizione
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Num"
        param.Value = elemento.NumeroLetti
        Cmd.Parameters.Add(param)


        JournalingDataLoader.LoadJournalingUpdateCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)

      

        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub

End Class


