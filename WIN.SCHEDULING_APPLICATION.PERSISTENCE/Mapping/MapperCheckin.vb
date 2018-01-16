Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
Public Class MapperCheckin
    Inherits AbstractRDBMapper


    Public Sub New()

        Me.m_IsAutoIncrementID = True
        Me.UseDefaultCacheMechanism = False
        Me.Cache = New PersistentObjectCache(0)
    End Sub


    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Book_Checkin"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "SELECT * FROM Book_Checkin WHERE (ID = @Id)"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into Book_Checkin (Id_Assignment, " _
             & "Id_Contact, Checkin) values (" _
             & "@ida, @idc, @chk)"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return ""
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Book_Checkin where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

    Protected Function FindAllByAssignmentStatement() As String
        Return "Select * from Book_Checkin where Id_Assignment = @docid"
    End Function

    Protected Function DeleteByAssigmentIdStatement() As String
        Return "Delete from Book_Checkin where Id_Assignment = @docid"
    End Function

    Public Sub DeleteCheckin(assignmentId As Int32)

        Dim connectionExternallyOpened As Boolean = False
        Try
            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
                'DBConnectionManager.Instance.GetCurrentConnection.Close()
            Else
                m_PersistentService.CurrentConnection.Open()
            End If

            Dim cmd As IDbCommand = GetCommand(DeleteByAssigmentIdStatement)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@docid"
            param.Value = assignmentId
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


    Public Function FindCheckins(ByVal target As AbstractPersistenceObject) As IList
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

            Dim cmd As IDbCommand = GetCommand(FindAllByAssignmentStatement)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@docid"
            param.Value = target.Id
            cmd.Parameters.Add(param)
            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadAll(Datalist)

            If connectionExternallyOpened = False Then
                m_PersistentService.CurrentConnection.Close()
            End If

            'RipristinaRiferimentoCircolareCon(Utente, Lista)
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


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), Checkin)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Checkin)


    End Function

#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim app As Checkin = DirectCast(Item, Checkin)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@ida"
            param.Value = app.Assignment.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idc"
            param.Value = app.Customer.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@chk"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.Data.ToString
            Else
                param.Value = app.Data
            End If
            Cmd.Parameters.Add(param)



            

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto checkin." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try

            

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto checkin." & vbCrLf & ex.Message)
        End Try
    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject


        
        Dim StartDate As DateTime = IIf(rs.Item("Checkin") IsNot Nothing, rs.Item("Checkin"), DateTime.MinValue)
        

        Dim custID As Int32 = rs.Item("Id_Contact")
        Dim MapperCustomer As MapperCustomer = PersistenceMapperRegistry.Instance.GetMapperByName("MapperCustomer")
        Dim Customer As Customer = Nothing
        If custID > -1 Then
            Customer = MapperCustomer.FindObjectById(custID)
        End If



        Dim AssigmentID As Int32 = rs.Item("Id_Assignment")
        Dim MapperAssignment As MapperAssignment = PersistenceMapperRegistry.Instance.GetMapperByName("MapperAssignment")
        Dim Assignment As Assignment = Nothing
        If AssigmentID > -1 Then
            Assignment = MapperAssignment.FindObjectById(AssigmentID)
        End If


       




        Dim app As Checkin = New Checkin
        app.Key = Key

        app.Customer = Customer
        app.Data = StartDate
        app.Assignment = Assignment
      



        Return app
    End Function
End Class









