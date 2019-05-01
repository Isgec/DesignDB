Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class dbDocumentDB
    Public Property DocumentID As String = ""
    Public Property Document_Rev As String = ""

    Public Property Tittle As String = ""
    Public Property Drawing_File_Name As String = ""


    Public Shared Function GetDocumentDB(ByVal DocumentID As String) As dbDocumentDB
      If DocumentID = "" Then Return Nothing
      Dim mRet As New dbDocumentDB
      mRet.DocumentID = DocumentID



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        Sql = " select t_dttl"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn)from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Tittle = Cmd.ExecuteScalar
        End Using


        Sql = " select t_revn"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Document_Rev = Cmd.ExecuteScalar
        End Using

        Sql = " select t_dsca"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Drawing_File_Name = Cmd.ExecuteScalar
        End Using




      End Using
      Return mRet
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class


End Namespace
