Imports WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements
Public Class MapperDocument
    Inherits AbstractRDBMapper

    Public Sub New()
        'MyBase.Cache = New PersistentObjectCache(True)
        Me.m_IsAutoIncrementID = True
    End Sub


    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_Documents"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "SELECT * FROM App_Documents WHERE (ID = @Id)"
    End Function
    Protected Overrides Function InsertStatement() As String
        Return "Insert into App_Documents (Subject, DocDate, DocYear, " _
             & "ScopeID, Responsable, OperatorID, DestinationList, AttachmentList, DocVersus, DocTypeID, " _
             & "Priority, DocBody, CreatedBy, CreatedOn, Protocol) values (" _
             & "@sub, @dat, @yea, @scid, @res, @opid, @desl, @attl, @docv, @doct, @pri, " _
             & "@docb, @CRby, @CRon, @pro)"
    End Function
    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_Documents SET " _
              & "Subject = @sub, " _
              & "DocDate = @dat, " _
              & "DocYear = @yea, " _
              & "ScopeID = @scid, " _
              & "Responsable = @res, " _
              & "OperatorID = @opid, " _
              & "DestinationList = @desl, " _
              & "AttachmentList = @attl, " _
              & "DocVersus = @docv, " _
              & "DocTypeID = @doct, " _
              & "Priority = @pri, " _
              & "DocBody = @docb, " _
              & "ModifiedBy = @MOby, ModifiedOn = @MOon, Protocol = @pro WHERE (Id =@Id) "
    End Function
    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_Documents where Id = @Id"
    End Function
    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

    Private Function FindContactsByDocumentId() As String
        Return "Select * from App_Destinations WHERE DocumentID = @Idl"
    End Function

    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), Document)


    End Function



    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), Document)


    End Function

#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            ' MyBase.LoadInsertCommandParameters(Item, Cmd)
            Dim app As Document = DirectCast(Item, Document)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@sub"
            If String.IsNullOrEmpty(app.Subject) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Subject
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@dat"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.Date.ToString
            Else
                param.Value = app.Date
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@yea"
            param.Value = app.Year
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@scid"
            If app.Scope Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Scope.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@res"
            If String.IsNullOrEmpty(app.Responsable) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Responsable
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
            param.ParameterName = "@desl"
            If String.IsNullOrEmpty(app.ContactList) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.ContactList
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@attl"
            If String.IsNullOrEmpty(app.AttachmentList) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.AttachmentList
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@docv"
            param.Value = app.Nature
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@doct"
            If app.Type Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Type.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@pri"
            param.Value = app.Priority
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@docb"
            param.Value = app.Body.Document
            Cmd.Parameters.Add(param)


            

            JournalingDataLoader.LoadJournalingInsertCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)


            param = Cmd.CreateParameter
            param.ParameterName = "@pro"
            If String.IsNullOrEmpty(app.Protocol) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Protocol
            End If
            Cmd.Parameters.Add(param)



        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Documento." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim app As Document = DirectCast(Item, Document)
            



            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@sub"
            If String.IsNullOrEmpty(app.Subject) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Subject
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@dat"
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = app.Date.ToString
            Else
                param.Value = app.Date
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@yea"
            param.Value = app.Year
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@scid"
            If app.Scope Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Scope.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@res"
            If String.IsNullOrEmpty(app.Responsable) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Responsable
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
            param.ParameterName = "@desl"
            If String.IsNullOrEmpty(app.ContactList) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.ContactList
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@attl"
            If String.IsNullOrEmpty(app.AttachmentList) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.AttachmentList
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@docv"
            param.Value = app.Nature
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@doct"
            If app.Type Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Type.Id
            End If
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@pri"
            param.Value = app.Priority
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@docb"
            If app.Body.Document Is Nothing Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Body.Document
            End If
            Cmd.Parameters.Add(param)


            JournalingDataLoader.LoadJournalingUpdateCommandParameters(Item, Cmd, Me.m_PersistentService.DBType = DB.DBType.Access)


            param = Cmd.CreateParameter
            param.ParameterName = "@pro"
            If String.IsNullOrEmpty(app.Protocol) Then
                param.Value = DBNull.Value
            Else
                param.Value = app.Protocol
            End If
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = app.Id
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto Documento." & vbCrLf & ex.Message)
        End Try
    End Sub


    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject





        Dim StartDate As DateTime = IIf(rs.Item("DocDate") IsNot Nothing, rs.Item("DocDate"), DateTime.MinValue)
        Dim Subject As String = IIf(rs.Item("Subject") IsNot Nothing, rs.Item("Subject"), "")


        Dim DocumentScopeID1 As Int32 = IIf(rs.Item("ScopeID") IsNot Nothing, rs.Item("ScopeID"), -1)
        Dim MapperDocScope As MapperDocumentScope = PersistenceMapperRegistry.Instance.GetMapperByName("MapperDocumentScope")
        Dim scope As DocumentScope = Nothing
        If DocumentScopeID1 > -1 Then
            scope = MapperDocScope.FindObjectById(DocumentScopeID1)
        End If

        Dim Responsable As String = IIf(rs.Item("Responsable") IsNot Nothing, rs.Item("Responsable"), "")

        Dim OperatorID1 As Int32 = IIf(rs.Item("OperatorID") IsNot Nothing, rs.Item("OperatorID"), -1)
        Dim MapperOperator As MapperOperator = PersistenceMapperRegistry.Instance.GetMapperByName("MapperOperator")
        Dim operator1 As WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator = Nothing
        If OperatorID1 > -1 Then
            operator1 = MapperOperator.FindObjectById(OperatorID1)
        End If

        Dim DestinationList As String = IIf(rs.Item("DestinationList") IsNot Nothing, rs.Item("DestinationList"), "")
        Dim AttachmentList As String = IIf(rs.Item("AttachmentList") IsNot Nothing, rs.Item("AttachmentList"), "")
        Dim versus As Int32 = rs.Item("DocVersus")


        Dim docTypeID1 As Int32 = IIf(rs.Item("DocTypeID") IsNot Nothing, rs.Item("DocTypeID"), -1)
        Dim MapperDocumentType As MapperDocumentType = PersistenceMapperRegistry.Instance.GetMapperByName("MapperDocumentType")
        Dim doctype As DocumentType = Nothing
        If docTypeID1 > -1 Then
            doctype = MapperDocumentType.FindObjectById(docTypeID1)
        End If

        Dim prior As Int32 = rs.Item("Priority")
        Dim protocol As String = IIf(rs.Item("Protocol") IsNot Nothing, rs.Item("Protocol"), "")


        Dim app As Document = New Document
        app.Key = Key


        app.Subject = Subject
        app.Date = StartDate
        app.Scope = scope
        app.Responsable = Responsable
        app.Operator = operator1
        app.ContactList = DestinationList
        app.AttachmentList = AttachmentList
        app.Nature = versus
        app.Type = doctype
        app.Priority = prior
        app.Protocol = protocol
       
        app.Body = New LazyLoadDocumentBody(Key.LongValue, Me.m_PersistentService)
        app.Contacts = New LazyLoadConctacts(Key.LongValue.ToString, Me)

        Dim m As MapperAttachmentForDocument = PersistenceMapperRegistry.Instance.GetMapperByName("MapperAttachmentForDocument")
        app.Attachments = New LazyLoadAttachments(app, m)

        JournalingDataLoader.ReadJournalingParameters(app, rs)



        Return app
    End Function



    Public Function FindListaUtenti(ByVal documentId As Int32) As IList
        Dim rs As IDataReader = Nothing
        Dim Datalist As IList
        Dim Lista As IList
        Dim connectionExternallyOpened As Boolean = False
        Try
            If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
                connectionExternallyOpened = True
            Else
                m_PersistentService.CurrentConnection.Open()
            End If
            Dim cmd As IDbCommand = GetCommand(FindContactsByDocumentId)
            Dim param As IDataParameter = cmd.CreateParameter
            param.ParameterName = "@Idl"
            param.Value = documentId
            cmd.Parameters.Add(param)
            rs = cmd.ExecuteReader
            Datalist = Me.LoadDataMatrix(rs)
            rs.Close()
            Lista = LoadContacts(Datalist)
            If connectionExternallyOpened = False Then
                m_PersistentService.CurrentConnection.Close()
            End If
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




    Protected Function LoadContacts(ByVal rs As IList) As IList
        Dim registro As PersistenceMapperRegistry = New PersistenceMapperRegistry
        registro.SetPersistentService(m_PersistentService)
        Dim List As New ArrayList
        Dim mapperUtenti As MapperCustomer = registro.GetMapperByName("MapperCustomer")
        For Each elem As Hashtable In rs
            Dim u As Customer = mapperUtenti.FindObjectById(elem.Item("ContactID"))
            If u IsNot Nothing Then
                List.Add(u)
            End If
        Next
        Return List
    End Function



    Public Overrides Sub PostInsertAction(ByVal item As AbstractPersistenceObject)
        InsertAssociatedContacts(item)
        InsertAssociatedAttachments(item)
    End Sub



    Public Overrides Sub PostUpdateAction(ByVal item As AbstractPersistenceObject)
        RemoveAssociatedAttachments(item)

        InsertAssociatedAttachments(item)

        RemoveAssociatedContacts(item)

        InsertAssociatedContacts(item)
    End Sub

    Private Sub InsertAssociatedContacts(ByVal Item As AbstractPersistenceObject)
        For Each elem As Customer In DirectCast(Item, Document).Contacts
            InsertAssociatedContact(Item, elem)
        Next
    End Sub


    Private Sub InsertAssociatedAttachments(ByVal Item As AbstractPersistenceObject)
        For Each elem As AttachmentForDocument In DirectCast(Item, Document).Attachments
            elem.Parent = Item
            InsertAssociatedAttachment(elem)
        Next
    End Sub



    Private Sub InsertAssociatedAttachment(ByVal att As AttachmentForDocument)
        'att.Key = Nothing
        Dim m As MapperAttachmentForDocument = PersistenceMapperRegistry.Instance.GetMapperByName("MapperAttachmentForDocument")
        m.Insert(att)

    End Sub

    Private Sub InsertAssociatedContact(ByVal item As AbstractPersistenceObject, ByVal Utente As Customer)


        m_PersistentService.ExecuteNonQuery(String.Format("Insert into App_Destinations (DocumentID, ContactID) VALUES ({0}, {1})", item.Id.ToString, Utente.Id.ToString))

        'Dim connectionExternallyOpened As Boolean = False
        'Try

        '    If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then
        '        connectionExternallyOpened = True
        '    Else
        '        m_PersistentService.CurrentConnection.Open()
        '    End If


        '    Dim cmd As IDbCommand = GetCommand(String.Format("Insert into App_Destinations (DocumentID, ContactID) VALUES ({0}, {1})", item.Id.ToString, Utente.Id.ToString))
        '    cmd.ExecuteNonQuery()


        '    If connectionExternallyOpened = False Then
        '        m_PersistentService.CurrentConnection.Close()
        '    End If

        'Catch ex As Exception
        '    Throw
        'Finally
        '    If connectionExternallyOpened = False Then
        '        If m_PersistentService.CurrentConnection.State = ConnectionState.Open Then m_PersistentService.CurrentConnection.Close()
        '    End If
        'End Try
    End Sub


    Private Sub RemoveAssociatedContacts(ByVal Item As AbstractPersistenceObject)

        Me.m_PersistentService.ExecuteNonQuery(String.Format("Delete from App_Destinations where DocumentId = {0}", Item.Id.ToString))


    End Sub


    Private Sub RemoveAssociatedAttachments(ByVal Item As AbstractPersistenceObject)

        Me.m_PersistentService.ExecuteNonQuery(String.Format("Delete from App_Attachments where DocumentId = {0}", Item.Id.ToString))


    End Sub


End Class





