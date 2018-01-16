Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class BookingProxy
    Implements IBooking







    Private m_uniqueId As String = ""
    Private m_internal As IBooking
    Private m_queryExecuted As Boolean = False

    Private parentLoader As MapperBooking
    Private m_registry As PersistenceMapperRegistry

    Public Sub New(ByVal uniqueId As String, ByVal registry As PersistenceMapperRegistry)
        m_uniqueId = uniqueId
        m_registry = registry
        parentLoader = m_registry.GetMapperByName("MapperBooking")
    End Sub



    Private Function GetInternal() As IBooking

        If m_internal Is Nothing Then
            m_internal = GetFromDB()
        End If
        Return m_internal
    End Function


    Private Function GetFromDB() As IBooking
        If Not m_queryExecuted Then
            If m_uniqueId Is Nothing Then
                m_queryExecuted = True
                Return Nothing
            End If



            'imposto il flag che indica che la query è stata eseguita
            m_queryExecuted = True

            'eseguo la query
            Dim mapperBook As MapperBooking = m_registry.GetMapperByName("MapperBooking")

            Return mapperBook.FindObjectById(Convert.ToInt32(m_uniqueId))



        End If

        Return m_internal

    End Function




    Public Property Assignments As System.Collections.IList Implements DOMAIN.Booking.IBooking.Assignments
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Assignments
            End If
            Return New ArrayList
        End Get
        Set(value As System.Collections.IList)
            If GetInternal() IsNot Nothing Then
                GetInternal().Assignments = value
            End If
        End Set
    End Property

    Public Property [Date] As Date Implements DOMAIN.Booking.IBooking.Date
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().[Date]
            End If
            Return DateTime.MinValue
        End Get
        Set(value As Date)
            If GetInternal() IsNot Nothing Then
                GetInternal().Date = value
            End If
        End Set
    End Property

    Public ReadOnly Property Id As Integer Implements DOMAIN.Booking.IBooking.Id
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Id
            End If
            Return -1
        End Get
    End Property

    Public Property Notes As String Implements DOMAIN.Booking.IBooking.Notes
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Notes
            End If
            Return ""
        End Get
        Set(ByVal value As String)
            If GetInternal() IsNot Nothing Then
                GetInternal().Notes = value
            End If
        End Set
    End Property
    Public Property Notes1 As String Implements DOMAIN.Booking.IBooking.Notes1
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Notes1
            End If
            Return ""
        End Get
        Set(ByVal value As String)
            If GetInternal() IsNot Nothing Then
                GetInternal().Notes1 = value
            End If
        End Set
    End Property

    Public Sub AddAssignment(assignment As DOMAIN.Booking.Assignment) Implements DOMAIN.Booking.IBooking.AddAssignment
        If GetInternal() IsNot Nothing Then
            GetInternal().AddAssignment(assignment)
        End If
    End Sub



    Public Sub RemoveAssignment(assignment As DOMAIN.Booking.Assignment) Implements DOMAIN.Booking.IBooking.RemoveAssignment
        If GetInternal() IsNot Nothing Then
            GetInternal().RemoveAssignment(assignment)
        End If
    End Sub

    Public ReadOnly Property BaseObject As BASEREUSE.AbstractPersistenceObject Implements DOMAIN.Booking.IBooking.BaseObject
        Get
            If GetInternal() IsNot Nothing Then
                Return DirectCast(GetInternal(), AbstractPersistenceObject)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property BookingType As DOMAIN.Booking.BookingType Implements DOMAIN.Booking.IBooking.BookingType
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().BookingType
            End If
            Return Nothing
        End Get
        Set(value As DOMAIN.Booking.BookingType)
            If GetInternal() IsNot Nothing Then
                GetInternal().BookingType = value
            End If
        End Set
    End Property

    Public Property Color As Integer Implements DOMAIN.Booking.IBooking.Color
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Color
            End If
            Return 0
        End Get
        Set(value As Integer)
            If GetInternal() IsNot Nothing Then
                GetInternal().Color = value
            End If
        End Set
    End Property

    Public Property ColorBookings As Boolean Implements DOMAIN.Booking.IBooking.ColorBookings
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().ColorBookings
            End If
            Return False
        End Get
        Set(value As Boolean)
            If GetInternal() IsNot Nothing Then
                GetInternal().ColorBookings = value
            End If
        End Set
    End Property

    Public ReadOnly Property Confirmed As Boolean Implements DOMAIN.Booking.IBooking.Confirmed
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Confirmed
            End If
            Return False
        End Get

    End Property

    Public Property [Operator] As DOMAIN.ComboElements.Operator Implements DOMAIN.Booking.IBooking.Operator
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Operator
            End If
            Return Nothing
        End Get
        Set(value As DOMAIN.ComboElements.Operator)
            If GetInternal() IsNot Nothing Then
                GetInternal().Operator = value
            End If
        End Set
    End Property

    Public Property Payment As DOMAIN.Booking.BookingPayment Implements DOMAIN.Booking.IBooking.Payment
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().Payment
            End If
            Return Nothing

        End Get
        Set(value As DOMAIN.Booking.BookingPayment)
            If GetInternal() IsNot Nothing Then
                GetInternal().Payment = value
            End If
        End Set
    End Property

    Public ReadOnly Property State As DOMAIN.Booking.BookingState Implements DOMAIN.Booking.IBooking.State
        Get
            If GetInternal() IsNot Nothing Then
                Return GetInternal().State
            End If
            Return BookingState.NotConfirmed
        End Get
    End Property

    Public Sub ConfirmBooking() Implements DOMAIN.Booking.IBooking.ConfirmBooking
        If GetInternal() IsNot Nothing Then
            GetInternal().ConfirmBooking()
        End If
    End Sub

    Public Sub UnConfirmBooking() Implements DOMAIN.Booking.IBooking.UnConfirmBooking
        If GetInternal() IsNot Nothing Then
            GetInternal().UnConfirmBooking()
        End If
    End Sub

    Public Sub SetAccount([date] As Date, account As Single, type As DOMAIN.Booking.PaymentType) Implements DOMAIN.Booking.IBooking.SetAccount
        If GetInternal() IsNot Nothing Then
            GetInternal().SetAccount([date], account, type)
        End If
    End Sub

    Public Sub SetRestOfTypePayment([date] As Date, restOfPayment As Single, type As DOMAIN.Booking.PaymentType) Implements DOMAIN.Booking.IBooking.SetRestOfTypePayment
        If GetInternal() IsNot Nothing Then
            GetInternal().SetRestOfTypePayment([date], restOfPayment, type)
        End If
    End Sub

    Public Sub SetStayTax(tax As Single) Implements DOMAIN.Booking.IBooking.SetStayTax
        If GetInternal() IsNot Nothing Then
            GetInternal().SetStayTax(tax)
        End If
    End Sub

    Public Sub SetTotal(total As Single) Implements DOMAIN.Booking.IBooking.SetTotal
        If GetInternal() IsNot Nothing Then
            GetInternal().SetTotal(total)
        End If
    End Sub
End Class

