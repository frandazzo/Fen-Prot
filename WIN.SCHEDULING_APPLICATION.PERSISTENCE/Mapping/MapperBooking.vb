Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class MapperBooking
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
        Me.UseDefaultCacheMechanism = False
        Me.Cache = New PersistentObjectCache(20000)
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Book_Booking"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Book_Booking where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Book_Booking (Date, Notes, Id_BookingType, Id_Operator, Color, Confirmed, ColorBookings, Notes1,State ) values (@Dat,  @Not, @book, @ido,@col,@con,@cbo, @not1, @st)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Book_Booking SET Date = @Dat, Notes = @Not, Id_BookingType = @book, Id_Operator = @ido, Color = @col, Confirmed = @con, ColorBookings = @cbo, Notes1 = @not1, State = @st  WHERE (Id = @Id)"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Book_Booking where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region






    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), Booking)


    End Function

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Booking)

    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New Booking

        Dim bookTypeid As Int32 = IIf(rs.Item("Id_BookingType") IsNot Nothing, rs.Item("Id_BookingType"), -1)
        Dim opid As Int32 = IIf(rs.Item("Id_Operator") IsNot Nothing, rs.Item("Id_Operator"), -1)

        Dim col As Int32 = IIf(rs.Item("Color") IsNot Nothing, rs.Item("Color"), 0)
        Dim colbook As Boolean = IIf(rs.Item("ColorBookings") IsNot Nothing, rs.Item("ColorBookings"), False)
        Dim confirmed As Boolean = IIf(rs.Item("Confirmed") IsNot Nothing, rs.Item("Confirmed"), False)

        Dim mappertype As MapperBookingType = PersistenceMapperRegistry.Instance.GetMapperByName("MapperBookingType")
        Dim type As BookingType = Nothing
        If bookTypeid > -1 Then
            type = mappertype.FindObjectByIdReloadingCache(bookTypeid)
        End If

        Dim mapperoperator As MapperOperator = PersistenceMapperRegistry.Instance.GetMapperByName("MapperOperator")
        Dim op As ComboElements.Operator = Nothing
        If opid > -1 Then
            op = mapperoperator.FindObjectByIdReloadingCache(opid)
        End If

        Dim MapperBookinPayment As MapperBookingPayment = PersistenceMapperRegistry.Instance.GetMapperByName("MapperBookingPayment")

        Dim payment As BookingPayment = MapperBookinPayment.FindPayment(Key.LongValue)


        element.BookingType = type
        element.Date = IIf(rs.Item("Date") IsNot Nothing, rs.Item("Date"), DateTime.MinValue)
        element.Notes = IIf(rs.Item("Notes") IsNot Nothing, rs.Item("Notes"), "")
        element.Notes1 = IIf(rs.Item("Notes1") IsNot Nothing, rs.Item("Notes1"), "")
        element.Assignments = New LazyLoadAssignments(element, PersistenceMapperRegistry.Instance.GetMapperByName("MapperAssignment"))
        element.Operator = op
        element.Color = col
        element.ColorBookings = colbook
        If confirmed Then
            element.ConfirmBooking()
            element.Payment = payment
        Else
            element.UnConfirmBooking()
        End If
        element.Key = Key

        JournalingDataLoader.ReadJournalingParameters(element, rs)
        Return element
    End Function

    Public Overrides Sub PostInsertAction(item As BASEREUSE.AbstractPersistenceObject)
        Dim booking As Booking = DirectCast(item, Booking)

        If Not booking.Payment Is Nothing Then

            Dim MapperBookinPayment As MapperBookingPayment = PersistenceMapperRegistry.Instance.GetMapperByName("MapperBookingPayment")
            MapperBookinPayment.Insert(booking.Payment)

        End If

    End Sub

    Public Overrides Sub PostUpdateAction(item As BASEREUSE.AbstractPersistenceObject)
        Dim booking As Booking = DirectCast(item, Booking)
        Dim MapperBookinPayment As MapperBookingPayment = PersistenceMapperRegistry.Instance.GetMapperByName("MapperBookingPayment")
        MapperBookinPayment.DeletePayment(item.Id)

        If Not booking.Payment Is Nothing Then

            MapperBookinPayment.Insert(booking.Payment)

        End If
    End Sub



    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As Booking = DirectCast(Item, Booking)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Dat"
        param.Value = elemento.Date
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Not"
        If String.IsNullOrEmpty(elemento.Notes) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Notes
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@book"
        param.Value = elemento.BookingType.Id
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@ido"
        If elemento.Operator Is Nothing Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Operator.Id
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@col"
        param.Value = elemento.Color
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@con"
        param.Value = elemento.Confirmed
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@cbo"
        param.Value = elemento.ColorBookings
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@not1"
        If String.IsNullOrEmpty(elemento.Notes1) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Notes1
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@st"
        param.Value = elemento.State
        Cmd.Parameters.Add(param)


    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As Booking = DirectCast(Item, Booking)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@Dat"
        param.Value = elemento.Date
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Not"
        If String.IsNullOrEmpty(elemento.Notes) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Notes
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@book"
        param.Value = elemento.BookingType.Id
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@ido"
        If elemento.Operator Is Nothing Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Operator.Id
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@col"
        param.Value = elemento.Color
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@con"
        param.Value = elemento.Confirmed
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@cbo"
        param.Value = elemento.ColorBookings
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@not1"
        If String.IsNullOrEmpty(elemento.Notes1) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.Notes1
        End If
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@st"
        param.Value = elemento.State
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub

End Class



