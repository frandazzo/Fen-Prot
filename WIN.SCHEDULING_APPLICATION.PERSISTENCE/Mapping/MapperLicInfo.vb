Imports WIN.TECHNICAL.DEPLOYMENT.CORE
Imports WIN.TECHNICAL.PERSISTENCE

Public Class MapperLicInfo
    Inherits AbstractRDBMapper

    Public Sub New()
        Me.m_IsAutoIncrementID = True
    End Sub
#Region "Istruzioni Sql"

    Protected Overrides Function FindAllStatement() As String
        Return "Select * from InstallationInfo"
    End Function

    Protected Overrides Function FindByKeyStatement() As String
        Return "Select * from InstallationInfo where Id = @Id"
    End Function

    Protected Overrides Function InsertStatement() As String
        Return "Insert into InstallationInfo (ProductVersion, PackagePath, ActivationDate, ActivationCode, CustomerName, TrialDays, Type, Start, Finish, Mail, FirstRunDate,HardwareId) values ( @prv, @pap, @acd, @acc,@cun, @trd, @typ, @sta, @fin, @mai, @frd, @hid)"
    End Function


    Protected Overrides Function UpdateStatement() As String
        Return "UPDATE InstallationInfo SET ProductVersion = @prv, PackagePath = @pap, ActivationDate = @acd, ActivationCode = @acc, CustomerName=@cun, TrialDays = @trd, Type = @typ, Start = @sta, Finish = @fin, Mail = @mai, FirstRunDate = @frd, HardwareId = @hid  WHERE (Id =@Id )"
    End Function

    Protected Overrides Function DeleteStatement() As String
        Return "Delete from InstallationInfo where Id = @Id"
    End Function

    Protected Overrides Function FindNextKeyStatement() As String
        Return ""
    End Function

#End Region


#Region "Metodi per la ricerca dell'oggetto secondo l'id proposto"

    Public Overrides Function FindObjectById(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKey(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo)

    End Function

    Public Overrides Function FindObjectByIdReloadingCache(ByVal Id As Integer) As AbstractPersistenceObject

        Return DirectCast(MyBase.FindByKeyReloadingCache(New Key(Id)), WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo)


    End Function

    Protected Overloads Overrides Function DoLoad(ByVal Key As Key, ByVal rs As System.Collections.Hashtable) As AbstractPersistenceObject


        Dim prodVer As String = IIf(rs.Item("ProductVersion") IsNot Nothing, rs.Item("ProductVersion"), "")
        Dim PackagePath As String = IIf(rs.Item("PackagePath") IsNot Nothing, rs.Item("PackagePath"), "")
        Dim ActivationDate As DateTime = IIf(rs.Item("ActivationDate") IsNot Nothing, rs.Item("ActivationDate"), DateTime.MinValue)
        Dim ActivationCode As String = IIf(rs.Item("ActivationCode") IsNot Nothing, rs.Item("ActivationCode"), "")
        Dim CustomerName As String = IIf(rs.Item("CustomerName") IsNot Nothing, rs.Item("CustomerName"), "")
        Dim TrialDays As Int32 = rs("TrialDays")
        Dim Type As Int32 = rs("Type")
        Dim Start As DateTime = IIf(rs.Item("Start") IsNot Nothing, rs.Item("Start"), DateTime.MinValue)
        Dim Finish As DateTime = IIf(rs.Item("Finish") IsNot Nothing, rs.Item("Finish"), DateTime.MinValue)
        Dim FirstRunDate As DateTime = IIf(rs.Item("FirstRunDate") IsNot Nothing, rs.Item("FirstRunDate"), DateTime.MinValue)
        Dim Mail As String = IIf(rs.Item("Mail") IsNot Nothing, rs.Item("Mail"), "")
        Dim hard As String = IIf(rs.Item("HardwareId") IsNot Nothing, rs.Item("HardwareId"), "")

        Dim info As New InstallationInfo
        info.Buyer = New SoftwareBuyer()
        info.Buyer.CustomerName = CustomerName
        info.Buyer.Mail = Mail
        info.FirstRunDate = FirstRunDate
        info.Id = Key.LongValue()
        info.PackagePath = PackagePath
        info.ProductVersion = prodVer
        info.Licence = New WIN.TECHNICAL.DEPLOYMENT.CORE.LICENCE.Licence()
        info.Licence.ActivationCode = ActivationCode
        info.Licence.ActivationDate = ActivationDate
        If Start <> DateTime.MinValue Then
            info.Licence.Validity = New WIN.TECHNICAL.DEPLOYMENT.TimingClasses.TemporalRange(Start, Finish, TECHNICAL.DEPLOYMENT.TimingClasses.TemporalRange.PrecisionType.Date)
        Else
            info.Licence.Validity = Nothing
        End If

        info.Licence.Type = Type
        info.Licence.TrialDays = TrialDays
        info.Licence.HardwareId = hard


        Dim element As New WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo(info)

        Return element
    End Function
    'Protected Overrides Function GetCommand(ByVal CommandText As String) As System.Data.IDbCommand

    '    'Return New SqlClient1.SqlCommand(CommandText, DBConnectionManager.Instance.GetCurrentConnection)
    '    Return DBTypeUtils.GetCommand(Me.m_PersistentService.ServiceName, CommandText, DBConnectionManager.Instance.GetCurrentConnection)

    'End Function

#End Region




    Protected Overrides Sub LoadInsertCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)



        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@prv"
        If String.IsNullOrEmpty(elemento.InstallationInfo.ProductVersion) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.ProductVersion
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@pap"
        If String.IsNullOrEmpty(elemento.InstallationInfo.PackagePath) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.PackagePath
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@acd"
        If elemento.InstallationInfo.Licence.ActivationDate = DateTime.MinValue Then
            param.Value = DBNull.Value
        Else
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = elemento.InstallationInfo.Licence.ActivationDate.ToString
            Else
                param.Value = elemento.InstallationInfo.Licence.ActivationDate
            End If
        End If
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@acc"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Licence.ActivationCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Licence.ActivationCode
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@cun"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Buyer.CustomerName) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Buyer.CustomerName
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@trd"
        param.Value = elemento.InstallationInfo.Licence.TrialDays
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@typ"
        param.Value = elemento.InstallationInfo.Licence.Type
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@sta"
        If elemento.InstallationInfo.Licence.Validity Is Nothing Then
            param.Value = DBNull.Value
        Else
            If elemento.InstallationInfo.Licence.Validity.Start = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                If Me.m_PersistentService.DBType = DB.DBType.Access Then
                    param.Value = elemento.InstallationInfo.Licence.Validity.Start.ToString
                Else
                    param.Value = elemento.InstallationInfo.Licence.Validity.Start
                End If
            End If
        End If
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@fin"

        If elemento.InstallationInfo.Licence.Validity Is Nothing Then
            param.Value = DBNull.Value
        Else
            If elemento.InstallationInfo.Licence.Validity.Finish = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                If Me.m_PersistentService.DBType = DB.DBType.Access Then
                    param.Value = elemento.InstallationInfo.Licence.Validity.Finish.ToString
                Else
                    param.Value = elemento.InstallationInfo.Licence.Validity.Finish
                End If
            End If
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@mai"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Buyer.Mail) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Buyer.Mail
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@frd"
        If elemento.InstallationInfo.FirstRunDate = DateTime.MinValue Then
            param.Value = DBNull.Value
        Else
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = elemento.InstallationInfo.FirstRunDate.ToString
            Else
                param.Value = elemento.InstallationInfo.FirstRunDate
            End If
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@hid"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Licence.HardwareId) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Licence.HardwareId
        End If
        Cmd.Parameters.Add(param)


    End Sub

    Protected Overrides Sub LoadUpdateCommandParameters(ByVal Item As AbstractPersistenceObject, ByVal Cmd As System.Data.IDbCommand)
        Dim elemento As WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo = DirectCast(Item, WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing.LicInfo)

        Dim param As IDbDataParameter = Cmd.CreateParameter
        param.ParameterName = "@prv"
        If String.IsNullOrEmpty(elemento.InstallationInfo.ProductVersion) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.ProductVersion
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@pap"
        If String.IsNullOrEmpty(elemento.InstallationInfo.PackagePath) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.PackagePath
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@acd"
        If elemento.InstallationInfo.Licence.ActivationDate = DateTime.MinValue Then
            param.Value = DBNull.Value
        Else
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = elemento.InstallationInfo.Licence.ActivationDate.ToString
            Else
                param.Value = elemento.InstallationInfo.Licence.ActivationDate
            End If
        End If
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@acc"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Licence.ActivationCode) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Licence.ActivationCode
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@cun"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Buyer.CustomerName) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Buyer.CustomerName
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@trd"
        param.Value = elemento.InstallationInfo.Licence.TrialDays
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@typ"
        param.Value = elemento.InstallationInfo.Licence.Type
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@sta"
        If elemento.InstallationInfo.Licence.Validity Is Nothing Then
            param.Value = DBNull.Value
        Else
            If elemento.InstallationInfo.Licence.Validity.Start = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                If Me.m_PersistentService.DBType = DB.DBType.Access Then
                    param.Value = elemento.InstallationInfo.Licence.Validity.Start.ToString
                Else
                    param.Value = elemento.InstallationInfo.Licence.Validity.Start
                End If
            End If
        End If
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@fin"

        If elemento.InstallationInfo.Licence.Validity Is Nothing Then
            param.Value = DBNull.Value
        Else
            If elemento.InstallationInfo.Licence.Validity.Finish = DateTime.MinValue Then
                param.Value = DBNull.Value
            Else
                If Me.m_PersistentService.DBType = DB.DBType.Access Then
                    param.Value = elemento.InstallationInfo.Licence.Validity.Finish.ToString
                Else
                    param.Value = elemento.InstallationInfo.Licence.Validity.Finish
                End If
            End If
        End If
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@mai"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Buyer.Mail) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Buyer.Mail
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@frd"
        If elemento.InstallationInfo.FirstRunDate = DateTime.MinValue Then
            param.Value = DBNull.Value
        Else
            If Me.m_PersistentService.DBType = DB.DBType.Access Then
                param.Value = elemento.InstallationInfo.FirstRunDate.ToString
            Else
                param.Value = elemento.InstallationInfo.FirstRunDate
            End If
        End If
        Cmd.Parameters.Add(param)


        param = Cmd.CreateParameter
        param.ParameterName = "@hid"
        If String.IsNullOrEmpty(elemento.InstallationInfo.Licence.HardwareId) Then
            param.Value = DBNull.Value
        Else
            param.Value = elemento.InstallationInfo.Licence.HardwareId
        End If
        Cmd.Parameters.Add(param)



        param = Cmd.CreateParameter
        param.ParameterName = "@Id"
        param.Value = elemento.Id
        Cmd.Parameters.Add(param)

    End Sub

End Class
