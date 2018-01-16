Imports WIN.SECURITY

Public Class JournalingDataLoader
    Public Shared Sub ReadJournalingParameters(ByVal item As AbstractPersistenceObject, ByVal rs As Hashtable)
        Dim creatoDa As String = IIf(rs.Item("CreatedBy") IsNot Nothing, rs.Item("CreatedBy"), "")
        Dim modificatoDa As String = IIf(rs.Item("ModifiedBy") IsNot Nothing, rs.Item("ModifiedBy"), "")
        Dim creatoIl As Date = IIf(rs.Item("CreatedOn") IsNot Nothing, rs.Item("CreatedOn"), DateTime.MinValue)
        Dim modificatoIl As Date = IIf(rs.Item("ModifiedOn") IsNot Nothing, rs.Item("ModifiedOn"), DateTime.MinValue)
        item.CreatoDa = creatoDa
        item.ModificatoDa = modificatoDa
        item.DataCreazione = creatoIl
        item.DataModifica = modificatoIl
    End Sub


    Public Shared Sub LoadJournalingInsertCommandParameters(ByVal item As AbstractPersistenceObject, ByVal cmd As IDbCommand, Optional ByVal AccessDB As Boolean = False)
        If SecurityManager.Instance.CurrentUser IsNot Nothing Then
            item.CreatoDa = SecurityManager.Instance.CurrentUser.Username
        Else
            item.CreatoDa = ""
        End If
        item.DataCreazione = DateTime.Now


        Dim param As IDbDataParameter = cmd.CreateParameter
        param.ParameterName = "@CRby"
        param.Value = item.CreatoDa
        cmd.Parameters.Add(param)

        param = cmd.CreateParameter
        param.ParameterName = "@CRon"
        If AccessDB Then
            param.Value = item.DataCreazione.ToString
        Else
            param.Value = item.DataCreazione
        End If
        cmd.Parameters.Add(param)

    End Sub




    Public Shared Sub LoadJournalingUpdateCommandParameters(ByVal item As AbstractPersistenceObject, ByVal cmd As IDbCommand, Optional ByVal AccessDB As Boolean = False)

        If SecurityManager.Instance.CurrentUser IsNot Nothing Then
            item.ModificatoDa = SecurityManager.Instance.CurrentUser.Username
        Else
            item.ModificatoDa = ""
        End If
        item.DataModifica = DateTime.Now

        Dim param As IDbDataParameter = cmd.CreateParameter
        param.ParameterName = "@MOby"
        param.Value = item.ModificatoDa
        cmd.Parameters.Add(param)

        param = cmd.CreateParameter
        param.ParameterName = "@MOon"
        If AccessDB Then
            param.Value = item.DataModifica.ToString
        Else
            param.Value = item.DataModifica
        End If
        cmd.Parameters.Add(param)

    End Sub



End Class

