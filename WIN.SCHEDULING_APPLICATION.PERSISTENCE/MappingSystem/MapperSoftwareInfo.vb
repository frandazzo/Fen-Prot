Public Class MapperSoftwareInfo
    Inherits AbstractRDBMapper

#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from NOESIS_UPDATE_CENTER"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from NOESIS_UPDATE_CENTER where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "" '"Insert into NOESIS_UPDATE_CENTER (ID, DESCRIZIONE, VALUTA, TIPO_CONTO) values (@Id, @Desc, @Val, @Tip)"
    End Function

    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE NOESIS_UPDATE_CENTER SET SOFTWARE_VERSION = @SwV, DB_VERSION = @DbV, SOFTWARE_UPDATE_PATH = @SwU, DB_UPDATE_PATH = @DbU , LAST_UPDATE = @LU WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "" '"Delete from NOESIS_UPDATE_CENTER where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return "" '"Select Max(Id) from NOESIS_UPDATE_CENTER"
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), SoftwareInfo)


    End Function
    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject
        Try
            Dim info As New SoftwareInfo

            Dim LAST_UPDATE As Date = IIf(rs.Item("LAST_UPDATE") IsNot Nothing, rs.Item("LAST_UPDATE"), New DateTime(1800, 1, 1))
            Dim DB_VERSION As String = IIf(rs.Item("DB_VERSION") IsNot Nothing, rs.Item("DB_VERSION"), "")
            Dim SOFTWARE_VERSION As String = IIf(rs.Item("SOFTWARE_VERSION") IsNot Nothing, rs.Item("SOFTWARE_VERSION"), "")
            Dim DB_UPDATE_PATH As String = IIf(rs.Item("DB_UPDATE_PATH") IsNot Nothing, rs.Item("DB_UPDATE_PATH"), "")
            Dim SOFTWARE_UPDATE_PATH As String = IIf(rs.Item("SOFTWARE_UPDATE_PATH") IsNot Nothing, rs.Item("SOFTWARE_UPDATE_PATH"), "")

            info.LastUpdate = LAST_UPDATE
            info.DBVersion = New Version(DB_VERSION)
            info.SoftwareVersion = New Version(SOFTWARE_VERSION)
            info.DBUpgradePath = DB_UPDATE_PATH
            info.SoftwareUpgratePath = SOFTWARE_UPDATE_PATH

            info.Key = Key

            Return info
        Catch ex As Exception
            Throw New Exception("Impossibile caricare l'oggetto conto con Id = " & Key.LongValue & ". " & vbCrLf & ex.Message)
        End Try
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    'End Function

#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim info As SoftwareInfo = DirectCast(Item, SoftwareInfo)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@SwV"
            param.Value = info.SoftwareVersion.ToString
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@DbV"
            param.Value = info.DBVersion.ToString
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@SwU"
            param.Value = info.SoftwareUpgratePath
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@DbU"
            param.Value = info.DBUpgradePath
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@LU"
            param.Value = info.LastUpdate
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di inserimento dell'oggetto." & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Try
            Dim info As SoftwareInfo = DirectCast(Item, SoftwareInfo)

            Dim param As IDbDataParameter = Cmd.CreateParameter
            param.ParameterName = "@SwV"
            param.Value = info.SoftwareVersion.ToString
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@DbV"
            param.Value = info.DBVersion.ToString
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@SwU"
            param.Value = info.SoftwareUpgratePath
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@DbU"
            param.Value = info.DBUpgradePath
            Cmd.Parameters.Add(param)


            param = Cmd.CreateParameter
            param.ParameterName = "@LU"
            param.Value = info.LastUpdate
            Cmd.Parameters.Add(param)

            param = Cmd.CreateParameter
            param.ParameterName = "@Id"
            param.Value = 1
            Cmd.Parameters.Add(param)

        Catch ex As Exception
            Throw New Exception("Impossibile caricare il comando di aggiornamento dell'oggetto." & vbCrLf & ex.Message)
        End Try
    End Sub



End Class

