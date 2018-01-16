Public Class MapperAttachmentForDocument
    Inherits AbstractRDBMapper

    Public Sub New()
        'MyBase.Cache = New PersistentObjectCache(True)
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from App_Attachments"
    End Function

    Protected Function FindAllByTargetStatement() As String
        Return "Select * from App_Attachments where DocumentId = @docid"
    End Function


    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from App_Attachments where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into  App_Attachments  (DocumentId, Path, Filename, notes) values (@docid, @pat, @fil,  @Not)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE App_Attachments SET DocumentId = @docid,  Path = @pat, Filename = @fil, Notes = @Not WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from App_Attachments where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


    Public Function FindAttachmentsByDocument(ByVal target As AbstractPersistenceObject) As IList
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
            Lista = LoadAll(Datalist, target)

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


    Protected Overloads Function LoadAll(ByVal rs As IList, ByVal target As AbstractPersistenceObject) As IList
        Dim List As New ArrayList
        For Each elem As Hashtable In rs
            List.Add(Load(elem, target))
        Next
        Return List
    End Function

    Protected Overridable Overloads Function Load(ByVal rs As Hashtable, ByVal target As AbstractPersistenceObject, Optional ByVal FindAllForDeletion As Boolean = False) As AbstractPersistenceObject
        Dim key As Key = CreateKey(rs)
        If Cache.GetObjectFromCache(key.ToString) IsNot Nothing Then Return DirectCast(Cache.GetObjectFromCache(key.ToString), AbstractPersistenceObject)
        Dim obj As AbstractPersistenceObject = DoLoad(key, rs, target)
        Cache.AddToCache(obj)
        Return obj
    End Function




    Protected Overloads Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable, ByVal target As AbstractPersistenceObject) As AbstractPersistenceObject
        Dim doc As New AttachmentForDocument(DirectCast(target, Document))

        Dim path As String = IIf(rs("Path") IsNot Nothing, rs("Path"), "")
        Dim FILE_NAME As String = IIf(rs("FileName") IsNot Nothing, rs("FileName"), "")
        Dim note As String = IIf(rs("Notes") IsNot Nothing, rs("Notes"), "")

        doc.Path = path
        doc.AttachmentName = FILE_NAME
        doc.Key = Key
        doc.Note = note
        Return doc
    End Function




#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), AttachmentForDocument)

    End Function



#End Region

    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim doc As AttachmentForDocument = DirectCast(Item, AttachmentForDocument)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@docid"
        param.Value = doc.Parent.Id
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@pat"
        If String.IsNullOrEmpty(doc.Path) Then
            param.Value = DBNull.Value
        Else
            param.Value = doc.Path
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@fil"
        If String.IsNullOrEmpty(doc.AttachmentName) Then
            param.Value = DBNull.Value
        Else
            param.Value = doc.AttachmentName
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@not"
        If String.IsNullOrEmpty(doc.Note) Then
            param.Value = DBNull.Value
        Else
            param.Value = doc.Note
        End If
        Cmd.Parameters.Add(param)
       
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)

        Dim doc As AttachmentForDocument = DirectCast(Item, AttachmentForDocument)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@docid"
        param.Value = doc.Parent.Id
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@pat"
        If String.IsNullOrEmpty(doc.Path) Then
            param.Value = DBNull.Value
        Else
            param.Value = doc.Path
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@fil"
        If String.IsNullOrEmpty(doc.AttachmentName) Then
            param.Value = DBNull.Value
        Else
            param.Value = doc.AttachmentName
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@not"
        If String.IsNullOrEmpty(doc.Note) Then
            param.Value = DBNull.Value
        Else
            param.Value = doc.Note
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = doc.Id
        Cmd.Parameters.Add(param)

    End Sub

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Throw New NotImplementedException
    End Function
End Class

