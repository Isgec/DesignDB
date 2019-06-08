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
    Public Property Tittle_001 As String = ""
    Public Property Drawing_File_Name_001 As String = ""
    Public Property Drawing_State_001 As String = ""
    Public Property Workflow_Status_001 As String = ""
    Public Property Responsible_001 As String = ""
    Public Property Document_Date_001 As String = ""
    Public Property Drawing_Weight_001 As String = ""
    Public Property Drawing_Scale_001 As String = ""
    Public Property Sheet_Size_001 As String = ""
    Public Property Element_001 As String = ""
    Public Property Drawn_By_001 As String = ""
    Public Property Checked_By_001 As String = ""
    Public Property Approved_By_001 As String = ""
    Public Property Document_Type As String = ""
    Public Property Division As String = ""
    Public Property Submitted_Time As String = ""
    Public Property User_Name As String = ""
    Public Property Review_By As String = ""
    Public Property EApproved_BY As String = ""
    Public Property ISGEC_DATA_Source As String = ""
    Public Property For_Erection As String = ""
    Public Property For_Information As String = ""
    Public Property For_Production As String = ""
    Public Property For_Approval As String = ""
    Public Property SoftwareUsed As String = ""
    Public Property MachineName As String = ""
    Public Property ProjectID As String = ""
    Public Property Client As String = ""
    Public Property Consultant As String = ""
    Public Property Year As String = ""
    Public Property IWT As String = ""
    Public Property Project_Service As String = ""
    Public Property IndentNumber As String = ""
    Public Property IndentDate As String = ""
    Public Property IndentRequester As String = ""
    Public Property PONumber As String = ""
    Public Property PODate As String = ""
    Public Property POsupplier As String = ""
    Public Property POsuppliername As String = ""
    Public Property POBuyer As String = ""
    Public Property Transmittalid As String = ""











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
          mRet.Tittle_001 = Cmd.ExecuteScalar
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
          mRet.Drawing_File_Name_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select (case t_stat when 1 then 'Submitted' when 2 then 'Item Released' when 3 then 'Drawing Released' when 4 then 'Expired' end)		as 	Drawing_State"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Drawing_State_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select (case t_wfst when 1 then 'Under Design' when 2 then 'Submitted' when 3 then 'Under Review' when 4 then 'Under Approval' when 5 then 'Released'"
        Sql &= " when 6 then 'Withdrawn' when 7 then 'Under Revision' when 8 then 'Superceded' when 9 then 'under DCR'  end)"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Workflow_Status_001 = Cmd.ExecuteScalar
        End Using



        Sql = " select t_type"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Document_Type = Cmd.ExecuteScalar
        End Using



        Sql = " select t_resp"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Responsible_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_date"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Document_Date_001 = Cmd.ExecuteScalar
        End Using


        Sql = " select t_wght"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Drawing_Weight_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_scal"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Drawing_Scale_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_size"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Sheet_Size_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_cspa"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Element_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_drwb"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Drawn_By_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_chkb"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Checked_By_001 = Cmd.ExecuteScalar
        End Using



        Sql = " select t_appb"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Approved_By_001 = Cmd.ExecuteScalar
        End Using


        Sql = " select t_cspa"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Element_001 = Cmd.ExecuteScalar
        End Using

        Sql = " select t_sdat"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Submitted_Time = Cmd.ExecuteScalar
        End Using

        Sql = " select t_user"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.User_Name = Cmd.ExecuteScalar
        End Using

        Sql = " select t_rusr"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Review_By = Cmd.ExecuteScalar
        End Using

        Sql = " select t_ausr"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.EApproved_BY = Cmd.ExecuteScalar
        End Using

        Sql = " select t_sorc"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.ISGEC_DATA_Source = Cmd.ExecuteScalar
        End Using


        Sql = " select t_grup"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Division = Cmd.ExecuteScalar
        End Using

        Sql = " select (case t_erec when 1 then 'Yes' when 2 then 'No' end)"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.For_Erection = Cmd.ExecuteScalar
        End Using


        Sql = " select (case t_info when 1 then 'Yes' when 2 then 'No' end)"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.For_Information = Cmd.ExecuteScalar
        End Using

        Sql = " select (case t_prod when 1 then 'Yes' when 2 then 'No' end)"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.For_Production = Cmd.ExecuteScalar
        End Using

        Sql = " select (case t_appr when 1 then 'Yes' when 2 then 'No' end)"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.For_Approval = Cmd.ExecuteScalar
        End Using


        Sql = " select t_soft"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SoftwareUsed = Cmd.ExecuteScalar
        End Using

        Sql = " select t_mach"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.MachineName = Cmd.ExecuteScalar
        End Using

        Sql = " select t_cprj"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.ProjectID = Cmd.ExecuteScalar
        End Using

        Sql = " select t_clnt"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Client = Cmd.ExecuteScalar
        End Using

        Sql = " select t_cnsl"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Consultant = Cmd.ExecuteScalar
        End Using

        Sql = " select t_year"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Year = Cmd.ExecuteScalar
        End Using

        Sql = " select t_iwtn"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IWT = Cmd.ExecuteScalar
        End Using

        Sql = " select (t_ser1 + ' ' + t_ser2)	as 	Project_Service"
        Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Project_Service = Cmd.ExecuteScalar
        End Using

        Sql = "  Select distinct t_rqno from ttdisg003200 "
        Sql &= " where t_docn in ('" & DocumentID & "') "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IndentNumber = Cmd.ExecuteScalar
        End Using



        Sql = "  Select t_rdat from ttdpur200200  "
        Sql &= " where t_rqno in ('" & mRet.IndentNumber & "')"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IndentDate = Cmd.ExecuteScalar
        End Using

        Sql = "  Select t_remn from ttdpur200200  "
        Sql &= " where t_rqno in ('" & mRet.IndentNumber & "')"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IndentRequester = Cmd.ExecuteScalar
        End Using

        Sql = "  Select distinct t_orno from ttdisg002200 "
        Sql &= " where t_docn in ('" & DocumentID & "') "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.PONumber = Cmd.ExecuteScalar
        End Using



        Sql = "  Select t_odat from ttdpur400200  "
        Sql &= " where t_orno in ('" & mRet.PONumber & "')"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.PODate = Cmd.ExecuteScalar
        End Using

        Sql = "  Select t_sfbp from ttdpur400200  "
        Sql &= " where t_orno in ('" & mRet.PONumber & "')"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.POsupplier = Cmd.ExecuteScalar
        End Using

        Sql = "  Select t_nama from ttccom100200  "
        Sql &= " where t_bpid in ('" & mRet.POsupplier & "')"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.POsuppliername = Cmd.ExecuteScalar
        End Using


        Sql = "  Select t_ccon from ttdpur400200  "
        Sql &= " where t_orno in ('" & mRet.PONumber & "')"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.POBuyer = Cmd.ExecuteScalar
        End Using

        Sql = "  select t_tran from tdmisg132200  "
        Sql &= " where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg132200 where t_docn in ('" & DocumentID & "')) "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Transmittalid = Cmd.ExecuteScalar
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