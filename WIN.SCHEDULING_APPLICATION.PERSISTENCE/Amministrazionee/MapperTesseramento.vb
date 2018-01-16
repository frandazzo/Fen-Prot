Public Class MapperTesseramento
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from Amm_Tesseramento"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from Amm_Tesseramento where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into Amm_Tesseramento (Anno, NumeroTessere, CostoTessere, QuotaUIL) values ( @ann, @num, @cos, @quo)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE Amm_Tesseramento SET Anno = @ann, NumeroTessere = @num, CostoTessere = @cos, QuotaUIL = @quo  WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from Amm_Tesseramento where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento)

    End Function
    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento
        element.Anno = rs.Item("Anno")
        element.TesseraAcquistate = rs.Item("NumeroTessere")
        element.CostoTessera = rs.Item("CostoTessere")
        element.QuotaUIL = rs.Item("QuotaUIL")


        element.Key = Key

        Return element
    End Function


#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@ann"
        param.Value = elemento.Anno
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@num"
        param.Value = elemento.TesseraAcquistate
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@cos"
        param.Value = elemento.CostoTessera
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@quo"
        param.Value = elemento.QuotaUIL
        Cmd.Parameters.Add(param)

    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Tesseramento)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@ann"
        param.Value = elemento.Anno
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@num"
        param.Value = elemento.TesseraAcquistate
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@cos"
        param.Value = elemento.CostoTessera
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@quo"
        param.Value = elemento.QuotaUIL
        Cmd.Parameters.Add(param)

        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub
End Class
