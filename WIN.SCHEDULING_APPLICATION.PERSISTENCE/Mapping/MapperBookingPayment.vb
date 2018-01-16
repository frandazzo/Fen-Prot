Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class MapperBookingPayment
    Inherits AbstractRDBMapper


    Public Sub New()

        Me.m_IsAutoIncrementID = True

    End Sub


    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Book_BookingPayment"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "SELECT * FROM Book_BookingPayment WHERE (ID = @Id)"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into Book_BookingPayment (Id_Booking, DataAcconto, Acconto, Id_MezzoPagamentoAcconto, " _
             & "DataSaldo, Saldo, Id_MezzoPagamentoSaldo, TassaSoggiorno ,Totale) values (" _
             & "@idb, @dta, @acc, @ida, @dts,  @sal, @ids, @tas, @tot)"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Book_BookingPayment SET " _
              & "Id_Booking = @idb, " _
              & "DataAcconto = @dta, " _
              & "Acconto = @acc, " _
              & "Id_MezzoPagamentoAcconto = @ida, " _
              & "DataSaldo = @dts, " _
              & "Saldo = @sal, " _
              & "Id_MezzoPagamentoSaldo = @ids, " _
              & "TassaSoggiorno = @tas, " _
              & "Totale = @tot " _
              & "WHERE (Id = @Id) "
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Book_BookingPayment where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

    Protected Function FindAllByTargetStatement() As String
        Return "Select * from Book_BookingPayment where Id_Booking = @docid"
    End Function

    Protected Function DeleteByBookingIdStatement() As String
        Return "Delete from Book_BookingPayment where Id_Booking = @docid"
    End Function

    Public Sub DeletePayment(bookingId As Int32)

        Dim connectionExternallyOpened As Boolean = False
        Try
            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
                'DBConnectionManager.Instance.GetCurrentConnection.Close()
            Else
                m_PersistentService.CurrentConnection.Open()
            End If

            Dim cmd As IDbCommand = GetCommand(DeleteByBookingIdStatement)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@docid"
            param.Value = bookingId
            cmd.Parameters.Add(param)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw
        Finally
            
            If connectionExternallyOpened = False Then
                If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then m_PersistentService.CurrentConnection.Close()
            End If
        End Try
    End Sub


    Public Function FindPayment(bookingId As Int32) As BookingPayment
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

            Dim cmd As IDbCommand = GetCommand(FindAllByTargetStatement)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@docid"
            param.Value = bookingId
            cmd.Parameters.Add(param)
            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadAll(Datalist)

            If connectionExternallyOpened = False Then
                m_PersistentService.CurrentConnection.Close()
            End If

            If Lista.Count = 0 Then
                Return Nothing
            End If
            Return Lista(0)
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


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), BookingPayment)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), BookingPayment)


    End Function

#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim app As BookingPayment = DirectCast(Item, BookingPayment)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@idb"
            param.Value = app.Booking.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@dta"
            If app.AccontData = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                param.Value = app.AccontData
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@acc"
            param.Value = app.Accont
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ida"
            If app.AccountPaymentType Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.AccountPaymentType.Id
            End If

            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@dts"
            If app.RestOfPaymentData = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                param.Value = app.RestOfPaymentData
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@sal"
            param.Value = app.RestOfPayment
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ids"
            If app.RestOfPaymentPaymentType Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.RestOfPaymentPaymentType.Id
            End If

            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@tas"
            param.Value = app.StayTax
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@tot"
            param.Value = app.Total
            Cmd.Parameters.Add(param)

            


        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto BookingPayment." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try

            Dim app As BookingPayment = DirectCast(Item, BookingPayment)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@idb"
            param.Value = app.Booking.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@dta"
            If app.AccontData = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                param.Value = app.AccontData
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@acc"
            param.Value = app.Accont
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ida"
            If app.AccountPaymentType Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.AccountPaymentType.Id
            End If

            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@dts"
            If app.RestOfPaymentData = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                param.Value = app.RestOfPaymentData
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@sal"
            param.Value = app.RestOfPayment
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ids"
            If app.RestOfPaymentPaymentType Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.RestOfPaymentPaymentType.Id
            End If

            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@tas"
            param.Value = app.StayTax
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@tot"
            param.Value = app.Total
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = app.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto BookingPayment." & vbCrLf & ex.Message)
        End Try
    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject


        'Dim Note As String = IIf(rs.Item("Description") IsNot Nothing, rs.Item("Description"), "")

        Dim DataAcconto As DateTime = IIf(rs.Item("DataAcconto") IsNot Nothing, rs.Item("DataAcconto"), DateTime.MinValue)
        Dim DataSaldo As DateTime = IIf(rs.Item("DataSaldo") IsNot Nothing, rs.Item("DataSaldo"), DateTime.MinValue)

        Dim Acconto As Int32 = rs.Item("Acconto")
        Dim Saldo As Int32 = rs.Item("Saldo")

        Dim TassaSoggiorno As Int32 = rs.Item("TassaSoggiorno")
        Dim Totale As Int32 = rs.Item("Totale")

        Dim Id_MezzoPagamentoAcconto As Int32 = IIf(rs.Item("Id_MezzoPagamentoAcconto") IsNot Nothing, rs.Item("Id_MezzoPagamentoAcconto"), -1)
        Dim Id_MezzoPagamentoSaldo As Int32 = IIf(rs.Item("Id_MezzoPagamentoSaldo") IsNot Nothing, rs.Item("Id_MezzoPagamentoSaldo"), -1)


        Dim mezzoSaldo As PaymentType = Nothing
        Dim mezzoAcconto As PaymentType = Nothing


        Dim MapperPaymentType As MapperPaymentType = PersistenceMapperRegistry.Instance.GetMapperByName("MapperPaymentType")


        If Id_MezzoPagamentoAcconto > -1 Then
            mezzoAcconto = MapperPaymentType.FindObjectById(Id_MezzoPagamentoAcconto)
        End If


        If Id_MezzoPagamentoSaldo > -1 Then
            mezzoSaldo = MapperPaymentType.FindObjectById(Id_MezzoPagamentoSaldo)
        End If


        Dim BookId As Int32 = rs.Item("Id_Booking")

        Dim app As BookingPayment = New BookingPayment
        app.Key = Key
        app.Booking = New BookingProxy(BookId, PersistenceMapperRegistry.Instance)
        'app.AccontData = DataAcconto
        'app.Accont = Acconto
        'app.AccountPaymentType = mezzoAcconto
        app.SetAccount(DataAcconto, Acconto, mezzoAcconto)
        app.SetRestOfTypePayment(DataSaldo, Saldo, mezzoSaldo)
        app.StayTax = TassaSoggiorno
        app.Total = Totale





        Return app
    End Function
End Class









