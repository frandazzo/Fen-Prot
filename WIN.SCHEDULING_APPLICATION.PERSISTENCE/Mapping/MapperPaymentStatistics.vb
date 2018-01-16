Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class MapperPaymentStatistics
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
        Me.UseDefaultCacheMechanism = False
        Me.Cache = New PersistentObjectCache(0)
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return ""
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return ""
    End Function

    Protected Overrides Function InsertStatement() As String
        Return ""
    End Function


    Protected Overrides Function UpdateStatement() As String
        Return ""
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return ""
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region




    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), PaymentStatistics)

    End Function

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), PaymentStatistics)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New PaymentStatistics
        element.Incasso = IIf(rs.Item("Incasso") Is Nothing, 0, rs.Item("Incasso"))
        element.DaIncassare = IIf(rs.Item("DaIncassare") Is Nothing, 0, rs.Item("DaIncassare"))
        element.Mese = rs.Item("Mese")
        element.Anno = rs.Item("Anno")
        element.Booking = New BookingProxy(rs.Item("Id_Booking"), PersistenceMapperRegistry.Instance)

        element.Key = Key

        Return element
    End Function

    Protected Overloads Overrides Function CreateKey(ByVal rs As Hashtable) As Key

        Dim id As Int32 = 1
        Dim k As Key = New Key(id)
        Return k


    End Function

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)


    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)


    End Sub
End Class
