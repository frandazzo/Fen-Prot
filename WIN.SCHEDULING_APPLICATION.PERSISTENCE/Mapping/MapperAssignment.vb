Imports WIN.SCHEDULING_APPLICATION.DOMAIN.Booking

Public Class MapperAssignment
    Inherits AbstractRDBMapper


    Public Sub New()

        Me.m_IsAutoIncrementID = True
        Me.UseDefaultCacheMechanism = False
        Me.Cache = New PersistentObjectCache(0)
    End Sub


    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Book_Assignment"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "SELECT * FROM Book_Assignment WHERE (ID = @Id)"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into Book_Assignment (StartDate, " _
             & "EndDate, Description, Id_Resource, Id_Booking,Id_BedType) values (" _
             & "@std, @end, @des, @resid, @idb, @btp)"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Book_Assignment SET " _
              & "StartDate = @std, " _
              & "EndDate = @end, " _
              & "Description = @des, " _
              & "Id_Resource = @resid, " _
              & "Id_Booking = @idb, " _
              & "Id_BedType = @btp " _
              & "WHERE (Id = @Id) "
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Book_Assignment where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

    Protected Function FindAllByTargetStatement() As String
        Return "Select * from Book_Assignment where Id_Booking = @docid"
    End Function


    Public Function FindAssignments(ByVal target As AbstractPersistenceObject) As IList
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

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), Assignment)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Assignment)


    End Function

#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim app As Assignment = DirectCast(Item, Assignment)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@std"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.StartDate.ToString
            Else
                param.Value = app.StartDate
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@end"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.EndDate.ToString
            Else
                param.Value = app.EndDate
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@des"
            If String.IsNullOrEmpty(app.Notes) Then
                param.Value = ""
            Else
                param.Value = app.Notes
            End If
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@resid"
            param.Value = app.Resource.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idb"
            param.Value = app.Booking.Id
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@btp"
            param.Value = app.BedType.Id
            Cmd.Parameters.Add(param)
            

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto assegnazione." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try

            Dim app As Assignment = DirectCast(Item, Assignment)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@std"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.StartDate.ToString
            Else
                param.Value = app.StartDate
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@end"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.EndDate.ToString
            Else
                param.Value = app.EndDate
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@des"
            If String.IsNullOrEmpty(app.Notes) Then
                param.Value = ""
            Else
                param.Value = app.Notes
            End If
            Cmd.Parameters.Add(param)



            param = Cmd.CreateParameter
            param.ParameterName = "@resid"
            param.Value = app.Resource.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@idb"
            param.Value = app.Booking.Id
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@btp"
            param.Value = app.BedType.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = app.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto assegnazione." & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Shared Sub InserCheckins(ByVal item As BASEREUSE.AbstractPersistenceObject, MapperCheckin As MapperCheckin)
        Dim assignment As Assignment = DirectCast(item, Assignment)

        If assignment.Checkins.Count > 0 Then
            For Each elem As Checkin In assignment.Checkins
                MapperCheckin.Insert(elem)
            Next
        End If
    End Sub
    Public Overrides Sub PostInsertAction(item As BASEREUSE.AbstractPersistenceObject)
        Dim MapperCheckin As MapperCheckin = PersistenceMapperRegistry.Instance.GetMapperByName("MapperCheckin")
        InserCheckins(item, MapperCheckin)

    End Sub

    Public Overrides Sub PostUpdateAction(item As BASEREUSE.AbstractPersistenceObject)
        Dim assignment As Assignment = DirectCast(item, Assignment)
        Dim MapperCheckin As MapperCheckin = PersistenceMapperRegistry.Instance.GetMapperByName("MapperCheckin")
        MapperCheckin.DeleteCheckin(item.Id)

        InserCheckins(item, MapperCheckin)
       
    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject


        Dim Note As String = IIf(rs.Item("Description") IsNot Nothing, rs.Item("Description"), "")
        
        Dim StartDate As DateTime = IIf(rs.Item("StartDate") IsNot Nothing, rs.Item("StartDate"), DateTime.MinValue)
        Dim EndDate As DateTime = IIf(rs.Item("EndDate") IsNot Nothing, rs.Item("EndDate"), DateTime.MinValue)


        Dim BetTypeID As Int32 = rs.Item("Id_BedType")
        Dim MapperBedType As MapperBedType = PersistenceMapperRegistry.Instance.GetMapperByName("MapperBedType")
        Dim BedType As BedType = Nothing
        If BetTypeID > -1 Then
            BedType = MapperBedType.FindObjectById(BetTypeID)
        End If



        Dim ResourceID As Int32 = rs.Item("Id_Resource")
        Dim MapperResource As MapperBookingResource = PersistenceMapperRegistry.Instance.GetMapperByName("MapperBookingResource")
        Dim Resource1 As BookingResource = Nothing
        If ResourceID > -1 Then
            Resource1 = MapperResource.FindObjectById(ResourceID)
        End If


        Dim BookId As Int32 = rs.Item("Id_Booking")

        

        Dim app As Assignment = New Assignment
        app.Key = Key
        app.SetCustomers(New LazyLoadCheckin(app, PersistenceMapperRegistry.Instance.GetMapperByName("MapperCheckin")))


        app.Notes = Note
        app.StartDate = StartDate
        app.EndDate = EndDate
        app.Booking = New BookingProxy(BookId, PersistenceMapperRegistry.Instance)
        '//Attenzione. Questo campo è mappato con la variabile REsource
        '// ma devo necessariamente valorizzare 
        'questa variabile per il mapping con lo scheduler
        'Questa variabile viene usata solo da devexpress
        app.ResourceId = ResourceID
        app.Resource = Resource1
        app.BedType = BedType





        Return app
    End Function
End Class









