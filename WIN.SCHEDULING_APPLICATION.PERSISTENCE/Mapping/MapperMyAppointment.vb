Imports WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements
Public Class MapperMyAppointment
    Inherits AbstractRDBMapper


    Public Sub New()
        MyBase.Cache = New PersistentObjectCache(True)
        Me.m_IsAutoIncrementID = True
    End Sub


    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_Appointments"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "SELECT * FROM App_Appointments WHERE (ID = @Id)"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into App_Appointments (Type, StartDate, " _
             & "EndDate, AllDay, Subject, Location, Description, Status, Label, " _
             & "Resource, ReminderInfo, RecurrenceInfo, CreatedBy, CreatedOn, " _
             & "LabelID, OperatorID, OutcomeID, CustomerID, OutcomeDate, OutcomeNote, Closed, ResourceID, OutcomeCreated) values (" _
             & "@typ, @std, @end, @ald, @sub, @loc, @des, @sta, @lab, @resid, @remi, " _
             & "@reci, @CRby, @CRon, @lbid, @opid, @ouid, @cuid, @ouda, @ouno, @clo, @rid, @outcr )"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_Appointments SET " _
              & "Type = @typ, " _
              & "StartDate = @std, " _
              & "EndDate = @end, " _
              & "AllDay = @ald, " _
              & "Subject = @sub, " _
              & "Location = @loc, " _
              & "Description = @des, " _
              & "Status = @sta, " _
              & "Label = @lab, " _
              & "Resource = @resid, " _
              & "ReminderInfo = @remi, " _
              & "RecurrenceInfo = @reci, " _
              & "LabelID = @lbid, " _
              & "OperatorID = @opid, " _
              & "OutcomeID = @ouid, " _
              & "CustomerID = @cuid, " _
              & "OutcomeDate = @ouda, " _
              & "OutcomeNote = @ouno, " _
              & "Closed = @clo, " _
              & "ResourceID = @rid, " _
              & "ModifiedBy = @MOby, ModifiedOn = @MOon, OutcomeCreated = @outcr WHERE (Id =@Id) "
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_Appointments where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function



    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), MyAppointment)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), MyAppointment)


    End Function

#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim app As MyAppointment = DirectCast(Item, MyAppointment)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@typ"
            param.Value = app.AppointmentType
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
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
            param.ParameterName = "@ald"
            param.Value = app.AllDay
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@sub"
            If String.IsNullOrEmpty(app.Subject) Then
                param.Value = ""
            Else
                param.Value = app.Subject
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@loc"
            If String.IsNullOrEmpty(app.Location) Then
                param.Value = ""
            Else
                param.Value = app.Location
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@des"
            If String.IsNullOrEmpty(app.Description) Then
                param.Value = ""
            Else
                param.Value = app.Description
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@sta"
            param.Value = app.StatusId
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@lab"
            param.Value = app.LabelId
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@resid"
            param.Value = app.Resource.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@remi"
            If String.IsNullOrEmpty(app.ReminderInfo) Then
                param.Value = ""
            Else
                param.Value = app.ReminderInfo
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@reci"
            If String.IsNullOrEmpty(app.RecurrenceInfo) Then
                param.Value = ""
            Else
                param.Value = app.RecurrenceInfo
            End If
            Cmd.Parameters.Add(param)

            JournalingDataLoader.LoadJournalingInsertCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)


            param = Cmd.CreateParameter
            param.ParameterName = "@lbid"
            If app.Label Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Label.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@opid"
            If app.Operator Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Operator.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ouid"
            If app.Outcome Is Nothing Then
                param.Value = DBNull.Value

            Else
                param.Value = app.Outcome.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@cuid"
            If app.Customer Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Customer.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@ouda"
            If app.OutcomeDate = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                If Me.m_PersistentService.DBType = DB.DBType.Access Then
                    param.Value = app.OutcomeDate.ToString
                Else
                    param.Value = app.OutcomeDate
                End If
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ouno"
            If String.IsNullOrEmpty(app.OutcomeDescription) Then
                param.Value = ""
            Else
                param.Value = app.OutcomeDescription
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@clo"
            param.Value = app.IsClosed
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@rid"
            If (app.Resource Is Nothing) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Resource.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@outcr"
            param.Value = app.OutcomeCreated
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Appuntamento." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try

            Dim app As MyAppointment = DirectCast(Item, MyAppointment)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@typ"
            param.Value = app.AppointmentType
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
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
            param.ParameterName = "@ald"
            param.Value = app.AllDay
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@sub"
            If String.IsNullOrEmpty(app.Subject) Then
                param.Value = ""
            Else
                param.Value = app.Subject
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@loc"
            If String.IsNullOrEmpty(app.Location) Then
                param.Value = ""
            Else
                param.Value = app.Location
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@des"
            If String.IsNullOrEmpty(app.Description) Then
                param.Value = ""
            Else
                param.Value = app.Description
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@sta"
            param.Value = app.StatusId
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@lab"
            param.Value = app.LabelId
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@resid"
            param.Value = app.Resource.Id
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@remi"
            If String.IsNullOrEmpty(app.ReminderInfo) Then
                param.Value = ""
            Else
                param.Value = app.ReminderInfo
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@reci"
            If String.IsNullOrEmpty(app.RecurrenceInfo) Then
                param.Value = ""
            Else
                param.Value = app.RecurrenceInfo
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@lbid"
            If app.Label Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Label.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@opid"
            If app.Operator Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Operator.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@ouid"
            If app.Outcome Is Nothing Then
                param.Value = DBNull.Value

            Else
                param.Value = app.Outcome.Id
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@cuid"
            If app.Customer Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Customer.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ouda"
            If app.OutcomeDate = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                If Me.m_PersistentService.DBType = DB.DBType.Access Then
                    param.Value = app.OutcomeDate.ToString
                Else
                    param.Value = app.OutcomeDate
                End If
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@ouno"
            If String.IsNullOrEmpty(app.OutcomeDescription) Then
                param.Value = ""
            Else
                param.Value = app.OutcomeDescription
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@clo"
            param.Value = app.IsClosed
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@rid"
            If (app.Resource Is Nothing) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Resource.Id
            End If
            Cmd.Parameters.Add(param)

            JournalingDataLoader.LoadJournalingUpdateCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)

            param = Cmd.CreateParameter
            param.ParameterName = "@outcr"
            param.Value = app.OutcomeCreated
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = app.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Appuntamento." & vbCrLf & ex.Message)
        End Try
    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject

        Dim OutcomeNote As String = IIf(rs.Item("OutcomeNote") IsNot Nothing, rs.Item("OutcomeNote"), "")
        Dim Note As String = IIf(rs.Item("Description") IsNot Nothing, rs.Item("Description"), "")
        Dim Subject As String = IIf(rs.Item("Subject") IsNot Nothing, rs.Item("Subject"), "")
        Dim Location As String = IIf(rs.Item("Location") IsNot Nothing, rs.Item("Location"), "")
        Dim ReminderInfo As String = IIf(rs.Item("ReminderInfo") IsNot Nothing, rs.Item("ReminderInfo"), "")
        Dim RecurrenceInfo As String = IIf(rs.Item("RecurrenceInfo") IsNot Nothing, rs.Item("RecurrenceInfo"), "")

        Dim OutcomeCreated As Boolean = IIf(rs.Item("OutcomeCreated") IsNot Nothing, rs.Item("OutcomeCreated"), False)
        Dim AllDay As Boolean = IIf(rs.Item("AllDay") IsNot Nothing, rs.Item("AllDay"), False)
        Dim StartDate As DateTime = IIf(rs.Item("StartDate") IsNot Nothing, rs.Item("StartDate"), DateTime.MinValue)
        Dim EndDate As DateTime = IIf(rs.Item("EndDate") IsNot Nothing, rs.Item("EndDate"), DateTime.MinValue)
        Dim OutcomeDate As DateTime = IIf(rs.Item("OutcomeDate") IsNot Nothing, rs.Item("OutcomeDate"), DateTime.MinValue)

        Dim Closed As Int32 = rs.Item("Closed")
        Dim Type As Int32 = rs.Item("Type")
        Dim StatusId As Int32 = rs.Item("Status")
        Dim LabelID As Int32 = rs.Item("Label")
        Dim Resource As Int32 = rs.Item("Resource")

        Dim LabelID1 As Int32 = IIf(rs.Item("LabelID") IsNot Nothing, rs.Item("LabelID"), -1)
        Dim MapperLabel As MapperLabel = PersistenceMapperRegistry.Instance.GetMapperByName("MapperLabel")
        Dim label1 As Label = Nothing
        If LabelID1 > -1 Then
            label1 = MapperLabel.FindObjectById(LabelID1)
        End If


        Dim OperatorID1 As Int32 = IIf(rs.Item("OperatorID") IsNot Nothing, rs.Item("OperatorID"), -1)
        Dim MapperOperator As MapperOperator = PersistenceMapperRegistry.Instance.GetMapperByName("MapperOperator")
        Dim operator1 As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator = Nothing
        If OperatorID1 > -1 Then
            operator1 = MapperOperator.FindObjectById(OperatorID1)
        End If


        Dim OutcomeID1 As Int32 = IIf(rs.Item("OutcomeID") IsNot Nothing, rs.Item("OutcomeID"), -1)
        Dim MapperOutcome As MapperOutcome = PersistenceMapperRegistry.Instance.GetMapperByName("MapperOutcome")
        Dim Outcome1 As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Outcome = Nothing
        If OutcomeID1 > -1 Then
            Outcome1 = MapperOutcome.FindObjectById(OutcomeID1)
        End If


        Dim CustomerID1 As Int32 = IIf(rs.Item("CustomerID") IsNot Nothing, rs.Item("CustomerID"), -1)
        Dim MapperCustomer As MapperCustomer = PersistenceMapperRegistry.Instance.GetMapperByName("MapperCustomer")
        Dim Customer1 As Customer = Nothing
        If CustomerID1 > -1 Then
            Customer1 = MapperCustomer.FindObjectByIdReloadingCache(CustomerID1)
        End If

        Dim ResourceID As Int32 = IIf(rs.Item("ResourceID") IsNot Nothing, rs.Item("ResourceID"), -1)
        Dim MapperResource As MapperResource = PersistenceMapperRegistry.Instance.GetMapperByName("MapperResource")
        Dim Resource1 As Resource = Nothing
        If ResourceID > -1 Then
            Resource1 = MapperResource.FindObjectById(ResourceID)
        End If



        Dim app As MyAppointment = New MyAppointment
        app.Key = Key

        app.Description = Note
        app.Subject = Subject
        app.Location = Location
        app.ReminderInfo = ReminderInfo
        app.RecurrenceInfo = RecurrenceInfo
        app.OutcomeDescription = OutcomeNote
        app.OutcomeCreated = OutcomeCreated
        app.IsClosed = Closed
        app.AllDay = AllDay
        app.StartDate = StartDate
        app.EndDate = EndDate
        app.OutcomeDate = OutcomeDate
        app.AppointmentType = Type

        app.StatusId = StatusId
        app.LabelId = LabelID
        '//Attenzione. Questo campo è mappato con la variabile REsource
        '// ma devo necessariamente valorizzare 
        'questa variabile per il mapping con lo scheduler
        'Questa variabile viene usata solo da devexpress
        app.ResourceId = ResourceID


        app.Label = label1
        app.Customer = Customer1
        app.Operator = operator1
        app.Outcome = Outcome1
        app.Resource = Resource1

        JournalingDataLoader.ReadJournalingParameters(app, rs)



        Return app
    End Function
End Class








