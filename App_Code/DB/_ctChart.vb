Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.CT
  <DataObject()>
  Public Class CTChart
    Private Class ctData
      Public Property ValX As String = ""
      Public Property ValY As Integer = 0
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
    Public Property CountOfXValuesToBeShown As Integer = 30
    Public Property IntervalX As Integer = 1
    Public Property MinimumX As DateTime = Nothing
    Public Property MaximumX As DateTime = Nothing
    Public Property ProjectID As String = ""

    Public Property ProjectDesc As String = ""
    Public Property ActivityType As String = ""
    Public Property PlannedX As String()
    Public Property PlannedY As Integer()
    Public Property ActualX As DateTime()
    Public Property ActualY As Decimal()
    Public Property OutlookX As DateTime()
    Public Property OutlookY As Decimal()
    Public Property LastUpdatedOn As DateTime = Nothing
    Public Property LastUpdatedIndex As Integer = 0
    Public Property LastProcessed As DateTime

    Public Property Process_Total_Count As Integer = 0
    Public Property Mechanical_Total_Count As Integer = 0
    Public Property Structure_Total_Count As Integer = 0
    Public Property Piping_Total_Count As Integer = 0
    Public Property Electrical_Total_Count As Integer = 0
    Public Property CI_Total_Count As Integer = 0
    Public Property Total_Total_Count As Integer = 0

    Public Property Process_Release_Count As Integer = 0
    Public Property Mechanical_Release_Count As Integer = 0
    Public Property Structure_Release_Count As Integer = 0
    Public Property Piping_Release_Count As Integer = 0
    Public Property Electrical_Release_Count As Integer = 0
    Public Property CI_Release_Count As Integer = 0
    Public Property Total_Release_Count As Integer = 0


    Public Property Process_Pending_Count As Integer = 0
    Public Property Mechanical_Pending_Count As Integer = 0
    Public Property Structure_Pending_Count As Integer = 0
    Public Property Piping_Pending_Count As Integer = 0
    Public Property Electrical_Pending_Count As Integer = 0
    Public Property CI_Pending_Count As Integer = 0
    Public Property Total_Pending_Count As Integer = 0


    Public Property Process_Due_Count As Integer = 0
    Public Property Mechanical_Due_Count As Integer = 0
    Public Property Structure_Due_Count As Integer = 0
    Public Property Piping_Due_Count As Integer = 0
    Public Property Electrical_Due_Count As Integer = 0
    Public Property CI_Due_Count As Integer = 0
    Public Property Total_Due_Count As Integer = 0

    Public Property Process_OnTime_Count As Integer = 0
    Public Property Mechanical_OnTime_Count As Integer = 0
    Public Property Structure_OnTime_Count As Integer = 0
    Public Property Piping_OnTime_Count As Integer = 0
    Public Property Electrical_OnTime_Count As Integer = 0
    Public Property CI_OnTime_Count As Integer = 0
    Public Property Total_OnTime_Count As Integer = 0


    Public Property Process_Delayed_Count As Integer = 0
    Public Property Mechanical_Delayed_Count As Integer = 0
    Public Property Structure_Delayed_Count As Integer = 0
    Public Property Piping_Delayed_Count As Integer = 0
    Public Property Electrical_Delayed_Count As Integer = 0
    Public Property CI_Delayed_Count As Integer = 0
    Public Property Total_Delayed_Count As Integer = 0

    '

    Public Property Process_DCR_Total_Count As Integer = 0
    Public Property Process_DCR_Under_Creation As Integer = 0
    Public Property Process_DCR_Under_Approval As Integer = 0
    Public Property Process_DCR_Approved As Integer = 0
    Public Property Mechanical_DCR_Total_Count As Integer = 0
    Public Property Mechanical_DCR_Under_Creation As Integer = 0
    Public Property Mechanical_DCR_Under_Approval As Integer = 0
    Public Property Mechanical_DCR_Approved As Integer = 0
    Public Property Structure_DCR_Total_Count As Integer = 0
    Public Property Structure_DCR_Under_Creation As Integer = 0
    Public Property Structure_DCR_Under_Approval As Integer = 0
    Public Property Structure_DCR_Approved As Integer = 0
    Public Property Piping_DCR_Total_Count As Integer = 0
    Public Property Piping_DCR_Under_Creation As Integer = 0
    Public Property Piping_DCR_Under_Approval As Integer = 0
    Public Property Piping_DCR_Approved As Integer = 0
    Public Property Electrical_DCR_Total_Count As Integer = 0
    Public Property Electrical_DCR_Under_Creation As Integer = 0
    Public Property Electrical_DCR_Under_Approval As Integer = 0
    Public Property Electrical_DCR_Approved As Integer = 0
    Public Property CI_DCR_Total_Count As Integer = 0
    Public Property CI_DCR_Under_Creation As Integer = 0
    Public Property CI_DCR_Under_Approval As Integer = 0
    Public Property CI_DCR_Approved As Integer = 0
    Public Property Others_DCR_Total_Count As Integer = 0
    Public Property Others_DCR_Under_Creation As Integer = 0
    Public Property Others_DCR_Under_Approval As Integer = 0
    Public Property Others_DCR_Approved As Integer = 0
    Public Property Total_DCR_Total_Count As Integer = 0
    Public Property Total_DCR_Under_Creation As Integer = 0
    Public Property Total_DCR_Under_Approval As Integer = 0
    Public Property Total_DCR_Approved As Integer = 0

    'Transmittal
    Public Property Process_Transmittal_Total_Count As Integer = 0
    Public Property Process_Transmittal_Free As Integer = 0
    Public Property Process_Transmittal_Under_Approval As Integer = 0
    Public Property Process_Transmittal_Under_Issue As Integer = 0
    Public Property Process_Transmittal_Issued As Integer = 0
    Public Property Process_Transmittal_Partial_Received As Integer = 0
    Public Property Process_Transmittal_Received As Integer = 0
    Public Property Process_Transmittal_Closed As Integer = 0
    Public Property Process_Transmittal_Returned As Integer = 0

    Public Property Mechanical_Transmittal_Total_Count As Integer = 0
    Public Property Mechanical_Transmittal_Free As Integer = 0
    Public Property Mechanical_Transmittal_Under_Approval As Integer = 0
    Public Property Mechanical_Transmittal_Under_Issue As Integer = 0
    Public Property Mechanical_Transmittal_Issued As Integer = 0
    Public Property Mechanical_Transmittal_Partial_Received As Integer = 0
    Public Property Mechanical_Transmittal_Received As Integer = 0
    Public Property Mechanical_Transmittal_Closed As Integer = 0
    Public Property Mechanical_Transmittal_Returned As Integer = 0

    Public Property Structure_Transmittal_Total_Count As Integer = 0
    Public Property Structure_Transmittal_Free As Integer = 0
    Public Property Structure_Transmittal_Under_Approval As Integer = 0
    Public Property Structure_Transmittal_Under_Issue As Integer = 0
    Public Property Structure_Transmittal_Issued As Integer = 0
    Public Property Structure_Transmittal_Partial_Received As Integer = 0
    Public Property Structure_Transmittal_Received As Integer = 0
    Public Property Structure_Transmittal_Closed As Integer = 0
    Public Property Structure_Transmittal_Returned As Integer = 0

    Public Property Electrical_Transmittal_Total_Count As Integer = 0
    Public Property Electrical_Transmittal_Free As Integer = 0
    Public Property Electrical_Transmittal_Under_Approval As Integer = 0
    Public Property Electrical_Transmittal_Under_Issue As Integer = 0
    Public Property Electrical_Transmittal_Issued As Integer = 0
    Public Property Electrical_Transmittal_Partial_Received As Integer = 0
    Public Property Electrical_Transmittal_Received As Integer = 0
    Public Property Electrical_Transmittal_Closed As Integer = 0
    Public Property Electrical_Transmittal_Returned As Integer = 0

    Public Property Piping_Transmittal_Total_Count As Integer = 0
    Public Property Piping_Transmittal_Free As Integer = 0
    Public Property Piping_Transmittal_Under_Approval As Integer = 0
    Public Property Piping_Transmittal_Under_Issue As Integer = 0
    Public Property Piping_Transmittal_Issued As Integer = 0
    Public Property Piping_Transmittal_Partial_Received As Integer = 0
    Public Property Piping_Transmittal_Received As Integer = 0
    Public Property Piping_Transmittal_Closed As Integer = 0
    Public Property Piping_Transmittal_Returned As Integer = 0

    Public Property CI_Transmittal_Total_Count As Integer = 0
    Public Property CI_Transmittal_Free As Integer = 0
    Public Property CI_Transmittal_Under_Approval As Integer = 0
    Public Property CI_Transmittal_Under_Issue As Integer = 0
    Public Property CI_Transmittal_Issued As Integer = 0
    Public Property CI_Transmittal_Partial_Received As Integer = 0
    Public Property CI_Transmittal_Received As Integer = 0
    Public Property CI_Transmittal_Closed As Integer = 0
    Public Property CI_Transmittal_Returned As Integer = 0

    Public Property Others_Transmittal_Total_Count As Integer = 0
    Public Property Others_Transmittal_Free As Integer = 0
    Public Property Others_Transmittal_Under_Approval As Integer = 0
    Public Property Others_Transmittal_Under_Issue As Integer = 0
    Public Property Others_Transmittal_Issued As Integer = 0
    Public Property Others_Transmittal_Partial_Received As Integer = 0
    Public Property Others_Transmittal_Received As Integer = 0
    Public Property Others_Transmittal_Closed As Integer = 0
    Public Property Others_Transmittal_Returned As Integer = 0

    Public Property Total_Transmittal_Total_Count As Integer = 0
    Public Property Total_Transmittal_Free As Integer = 0
    Public Property Total_Transmittal_Under_Approval As Integer = 0
    Public Property Total_Transmittal_Under_Issue As Integer = 0
    Public Property Total_Transmittal_Issued As Integer = 0
    Public Property Total_Transmittal_Partial_Received As Integer = 0
    Public Property Total_Transmittal_Received As Integer = 0
    Public Property Total_Transmittal_Closed As Integer = 0
    Public Property Total_Transmittal_Returned As Integer = 0

    Public Property Process_PSTransmittal_Total_Count As Integer = 0
    Public Property Mechanical_PSTransmittal_Total_Count As Integer = 0
    Public Property Piping_PSTransmittal_Total_Count As Integer = 0
    Public Property Structure_PSTransmittal_Total_Count As Integer = 0
    Public Property Electrical_PSTransmittal_Total_Count As Integer = 0
    Public Property CI_PSTransmittal_Total_Count As Integer = 0
    Public Property Others_PSTransmittal_Total_Count As Integer = 0
    Public Property Total_PSTransmittal_Total_Count As Integer = 0

    Public Property Process_PSTransmittal_Pending_Count As Integer = 0

    Public Property Mechanical_PSTransmittal_Pending_Count As Integer = 0
    Public Property Piping_PSTransmittal_Pending_Count As Integer = 0
    Public Property Structure_PSTransmittal_Pending_Count As Integer = 0
    Public Property Electrical_PSTransmittal_Pending_Count As Integer = 0
    Public Property CI_PSTransmittal_Pending_Count As Integer = 0
    Public Property Others_PSTransmittal_Pending_Count As Integer = 0
    Public Property Total_PSTransmittal_Pending_Count As Integer = 0

    'SAR
    Public Property Process_SAR_Total_Count As Integer = 0
    Public Property Process_SAR_Under_Creation As Integer = 0
    Public Property Process_SAR_Under_Review As Integer = 0
    Public Property Process_SAR_Under_Approval As Integer = 0
    Public Property Process_SAR_Approved As Integer = 0
    Public Property Process_SAR_Not_Applicable As Integer = 0

    Public Property Mechanical_SAR_Total_Count As Integer = 0
    Public Property Mechanical_SAR_Under_Creation As Integer = 0
    Public Property Mechanical_SAR_Under_Review As Integer = 0
    Public Property Mechanical_SAR_Under_Approval As Integer = 0
    Public Property Mechanical_SAR_Approved As Integer = 0
    Public Property Mechanical_SAR_Not_Applicable As Integer = 0

    Public Property Structure_SAR_Total_Count As Integer = 0
    Public Property Structure_SAR_Under_Creation As Integer = 0
    Public Property Structure_SAR_Under_Review As Integer = 0
    Public Property Structure_SAR_Under_Approval As Integer = 0
    Public Property Structure_SAR_Approved As Integer = 0
    Public Property Structure_SAR_Not_Applicable As Integer = 0

    Public Property Piping_SAR_Total_Count As Integer = 0
    Public Property Piping_SAR_Under_Creation As Integer = 0
    Public Property Piping_SAR_Under_Review As Integer = 0
    Public Property Piping_SAR_Under_Approval As Integer = 0
    Public Property Piping_SAR_Approved As Integer = 0
    Public Property Piping_SAR_Not_Applicable As Integer = 0

    Public Property Electrical_SAR_Total_Count As Integer = 0
    Public Property Electrical_SAR_Under_Creation As Integer = 0
    Public Property Electrical_SAR_Under_Review As Integer = 0
    Public Property Electrical_SAR_Under_Approval As Integer = 0
    Public Property Electrical_SAR_Approved As Integer = 0
    Public Property Electrical_SAR_Not_Applicable As Integer = 0

    Public Property CI_SAR_Total_Count As Integer = 0
    Public Property CI_SAR_Under_Creation As Integer = 0
    Public Property CI_SAR_Under_Review As Integer = 0
    Public Property CI_SAR_Under_Approval As Integer = 0
    Public Property CI_SAR_Approved As Integer = 0
    Public Property CI_SAR_Not_Applicable As Integer = 0

    Public Property Others_SAR_Total_Count As Integer = 0
    Public Property Others_SAR_Under_Creation As Integer = 0
    Public Property Others_SAR_Under_Review As Integer = 0
    Public Property Others_SAR_Under_Approval As Integer = 0
    Public Property Others_SAR_Approved As Integer = 0
    Public Property Others_SAR_Not_Applicable As Integer = 0

    Public Property Total_SAR_Total_Count As Integer = 0
    Public Property Total_SAR_Under_Creation As Integer = 0
    Public Property Total_SAR_Under_Review As Integer = 0
    Public Property Total_SAR_Under_Approval As Integer = 0
    Public Property Total_SAR_Approved As Integer = 0
    Public Property Total_SAR_Not_Applicable As Integer = 0

    'IDMSP
    Public Property Process_IDMSP_Total_Count As Integer = 0
    Public Property Process_IDMSP_Submitted As Integer = 0
    Public Property Process_IDMSP_Document_linked As Integer = 0
    Public Property Process_IDMSP_Under_Evaluation As Integer = 0
    Public Property Process_IDMSP_Comments_Submitted As Integer = 0
    Public Property Process_IDMSP_Technically_Cleared As Integer = 0
    Public Property Process_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Process_IDMSP_Superceded As Integer = 0
    Public Property Process_IDMSP_Closed As Integer = 0

    Public Property Mechanical_IDMSP_Total_Count As Integer = 0
    Public Property Mechanical_IDMSP_Submitted As Integer = 0
    Public Property Mechanical_IDMSP_Document_linked As Integer = 0
    Public Property Mechanical_IDMSP_Under_Evaluation As Integer = 0
    Public Property Mechanical_IDMSP_Comments_Submitted As Integer = 0
    Public Property Mechanical_IDMSP_Technically_Cleared As Integer = 0
    Public Property Mechanical_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Mechanical_IDMSP_Superceded As Integer = 0
    Public Property Mechanical_IDMSP_Closed As Integer = 0

    Public Property Structure_IDMSP_Total_Count As Integer = 0
    Public Property Structure_IDMSP_Submitted As Integer = 0
    Public Property Structure_IDMSP_Document_linked As Integer = 0
    Public Property Structure_IDMSP_Under_Evaluation As Integer = 0
    Public Property Structure_IDMSP_Comments_Submitted As Integer = 0
    Public Property Structure_IDMSP_Technically_Cleared As Integer = 0
    Public Property Structure_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Structure_IDMSP_Superceded As Integer = 0
    Public Property Structure_IDMSP_Closed As Integer = 0

    Public Property Piping_IDMSP_Total_Count As Integer = 0
    Public Property Piping_IDMSP_Submitted As Integer = 0
    Public Property Piping_IDMSP_Document_linked As Integer = 0
    Public Property Piping_IDMSP_Under_Evaluation As Integer = 0
    Public Property Piping_IDMSP_Comments_Submitted As Integer = 0
    Public Property Piping_IDMSP_Technically_Cleared As Integer = 0
    Public Property Piping_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Piping_IDMSP_Superceded As Integer = 0
    Public Property Piping_IDMSP_Closed As Integer = 0

    Public Property Electrical_IDMSP_Total_Count As Integer = 0
    Public Property Electrical_IDMSP_Submitted As Integer = 0
    Public Property Electrical_IDMSP_Document_linked As Integer = 0
    Public Property Electrical_IDMSP_Under_Evaluation As Integer = 0
    Public Property Electrical_IDMSP_Comments_Submitted As Integer = 0
    Public Property Electrical_IDMSP_Technically_Cleared As Integer = 0
    Public Property Electrical_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Electrical_IDMSP_Superceded As Integer = 0
    Public Property Electrical_IDMSP_Closed As Integer = 0

    Public Property CI_IDMSP_Total_Count As Integer = 0
    Public Property CI_IDMSP_Submitted As Integer = 0
    Public Property CI_IDMSP_Document_linked As Integer = 0
    Public Property CI_IDMSP_Under_Evaluation As Integer = 0
    Public Property CI_IDMSP_Comments_Submitted As Integer = 0
    Public Property CI_IDMSP_Technically_Cleared As Integer = 0
    Public Property CI_IDMSP_Transmittal_Issued As Integer = 0
    Public Property CI_IDMSP_Superceded As Integer = 0
    Public Property CI_IDMSP_Closed As Integer = 0

    Public Property Total_IDMSP_Total_Count As Integer = 0
    Public Property Total_IDMSP_Submitted As Integer = 0
    Public Property Total_IDMSP_Document_linked As Integer = 0
    Public Property Total_IDMSP_Under_Evaluation As Integer = 0
    Public Property Total_IDMSP_Comments_Submitted As Integer = 0
    Public Property Total_IDMSP_Technically_Cleared As Integer = 0
    Public Property Total_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Total_IDMSP_Superceded As Integer = 0
    Public Property Total_IDMSP_Closed As Integer = 0


    Public Property Others_IDMSP_Total_Count As Integer = 0
    Public Property Others_IDMSP_Submitted As Integer = 0
    Public Property Others_IDMSP_Document_linked As Integer = 0
    Public Property Others_IDMSP_Under_Evaluation As Integer = 0
    Public Property Others_IDMSP_Comments_Submitted As Integer = 0
    Public Property Others_IDMSP_Technically_Cleared As Integer = 0
    Public Property Others_IDMSP_Transmittal_Issued As Integer = 0
    Public Property Others_IDMSP_Superceded As Integer = 0
    Public Property Others_IDMSP_Closed As Integer = 0

    'IDMSO

    Public Property Process_IDMSO_Total_Count As Integer = 0
    Public Property Process_IDMSO_Submitted As Integer = 0
    Public Property Process_IDMSO_Document_linked As Integer = 0
    Public Property Process_IDMSO_Under_Evaluation As Integer = 0
    Public Property Process_IDMSO_Comments_Submitted As Integer = 0
    Public Property Process_IDMSO_Technically_Cleared As Integer = 0
    Public Property Process_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Process_IDMSO_Superceded As Integer = 0
    Public Property Process_IDMSO_Closed As Integer = 0

    Public Property Mechanical_IDMSO_Total_Count As Integer = 0
    Public Property Mechanical_IDMSO_Submitted As Integer = 0
    Public Property Mechanical_IDMSO_Document_linked As Integer = 0
    Public Property Mechanical_IDMSO_Under_Evaluation As Integer = 0
    Public Property Mechanical_IDMSO_Comments_Submitted As Integer = 0
    Public Property Mechanical_IDMSO_Technically_Cleared As Integer = 0
    Public Property Mechanical_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Mechanical_IDMSO_Superceded As Integer = 0
    Public Property Mechanical_IDMSO_Closed As Integer = 0

    Public Property Structure_IDMSO_Total_Count As Integer = 0
    Public Property Structure_IDMSO_Submitted As Integer = 0
    Public Property Structure_IDMSO_Document_linked As Integer = 0
    Public Property Structure_IDMSO_Under_Evaluation As Integer = 0
    Public Property Structure_IDMSO_Comments_Submitted As Integer = 0
    Public Property Structure_IDMSO_Technically_Cleared As Integer = 0
    Public Property Structure_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Structure_IDMSO_Superceded As Integer = 0
    Public Property Structure_IDMSO_Closed As Integer = 0

    Public Property Piping_IDMSO_Total_Count As Integer = 0
    Public Property Piping_IDMSO_Submitted As Integer = 0
    Public Property Piping_IDMSO_Document_linked As Integer = 0
    Public Property Piping_IDMSO_Under_Evaluation As Integer = 0
    Public Property Piping_IDMSO_Comments_Submitted As Integer = 0
    Public Property Piping_IDMSO_Technically_Cleared As Integer = 0
    Public Property Piping_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Piping_IDMSO_Superceded As Integer = 0
    Public Property Piping_IDMSO_Closed As Integer = 0

    Public Property Electrical_IDMSO_Total_Count As Integer = 0
    Public Property Electrical_IDMSO_Submitted As Integer = 0
    Public Property Electrical_IDMSO_Document_linked As Integer = 0
    Public Property Electrical_IDMSO_Under_Evaluation As Integer = 0
    Public Property Electrical_IDMSO_Comments_Submitted As Integer = 0
    Public Property Electrical_IDMSO_Technically_Cleared As Integer = 0
    Public Property Electrical_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Electrical_IDMSO_Superceded As Integer = 0
    Public Property Electrical_IDMSO_Closed As Integer = 0

    Public Property CI_IDMSO_Total_Count As Integer = 0
    Public Property CI_IDMSO_Submitted As Integer = 0
    Public Property CI_IDMSO_Document_linked As Integer = 0
    Public Property CI_IDMSO_Under_Evaluation As Integer = 0
    Public Property CI_IDMSO_Comments_Submitted As Integer = 0
    Public Property CI_IDMSO_Technically_Cleared As Integer = 0
    Public Property CI_IDMSO_Transmittal_Issued As Integer = 0
    Public Property CI_IDMSO_Superceded As Integer = 0
    Public Property CI_IDMSO_Closed As Integer = 0

    Public Property Total_IDMSO_Total_Count As Integer = 0
    Public Property Total_IDMSO_Submitted As Integer = 0
    Public Property Total_IDMSO_Document_linked As Integer = 0
    Public Property Total_IDMSO_Under_Evaluation As Integer = 0
    Public Property Total_IDMSO_Comments_Submitted As Integer = 0
    Public Property Total_IDMSO_Technically_Cleared As Integer = 0
    Public Property Total_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Total_IDMSO_Superceded As Integer = 0
    Public Property Total_IDMSO_Closed As Integer = 0

    Public Property Others_IDMSO_Total_Count As Integer = 0
    Public Property Others_IDMSO_Submitted As Integer = 0
    Public Property Others_IDMSO_Document_linked As Integer = 0
    Public Property Others_IDMSO_Under_Evaluation As Integer = 0
    Public Property Others_IDMSO_Comments_Submitted As Integer = 0
    Public Property Others_IDMSO_Technically_Cleared As Integer = 0
    Public Property Others_IDMSO_Transmittal_Issued As Integer = 0
    Public Property Others_IDMSO_Superceded As Integer = 0
    Public Property Others_IDMSO_Closed As Integer = 0

    'element
    Public Property Process_Element_Total_Active_Element_Count As Integer = 0
    Public Property Process_Element_Free As Integer = 0
    Public Property Process_Element_Partial As Integer = 0
    Public Property Process_Element_Completed As Integer = 0


    Public Property Mechanical_Element_Total_Active_Element_Count As Integer = 0
    Public Property Mechanical_Element_Free As Integer = 0
    Public Property Mechanical_Element_Partial As Integer = 0
    Public Property Mechanical_Element_Completed As Integer = 0

    Public Property Structure_Element_Total_Active_Element_Count As Integer = 0
    Public Property Structure_Element_Free As Integer = 0
    Public Property Structure_Element_Partial As Integer = 0
    Public Property Structure_Element_Completed As Integer = 0


    Public Property Piping_Element_Total_Active_Element_Count As Integer = 0
    Public Property Piping_Element_Free As Integer = 0
    Public Property Piping_Element_Partial As Integer = 0
    Public Property Piping_Element_Completed As Integer = 0

    Public Property Electrical_Element_Total_Active_Element_Count As Integer = 0
    Public Property Electrical_Element_Free As Integer = 0
    Public Property Electrical_Element_Partial As Integer = 0
    Public Property Electrical_Element_Completed As Integer = 0

    Public Property CI_Element_Total_Active_Element_Count As Integer = 0
    Public Property CI_Element_Free As Integer = 0
    Public Property CI_Element_Partial As Integer = 0
    Public Property CI_Element_Completed As Integer = 0

    Public Property Others_Element_Total_Active_Element_Count As Integer = 0
    Public Property Others_Element_Free As Integer = 0
    Public Property Others_Element_Partial As Integer = 0
    Public Property Others_Element_Completed As Integer = 0

    Public Property Total_Element_Total_Active_Element_Count As Integer = 0
    Public Property Total_Element_Free As Integer = 0
    Public Property Total_Element_Partial As Integer = 0
    Public Property Total_Element_Completed As Integer = 0










    'Public Shared Function GetProjectDB(ByVal ProjectID As String, ByRef ProjectDesc As String) As CTChart
    '  If ProjectID = "" Then Return Nothing
    '  Dim mRet As New CTChart
    '  mRet.ProjectID = ProjectID
    '  Dim Sql As String = ""
    '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '    Con.Open()
    '    ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
    '    Sql = "Select t_cprj,t_dsca FROM ttcmcs052200 where t_cprj ='" & ProjectID & "'"
    '    Using Cmd As SqlCommand = Con.CreateCommand()
    '      Cmd.CommandType = CommandType.Text
    '      Cmd.CommandText = Sql
    '      '     mRet.ProjectDesc = Cmd.ExecuteScalar
    '    End Using
    '  End Using
    '  Return mRet
    'End Function

    'Public ReadOnly Property GetDataTable As String
    '  Get
    '    Dim mStr As String = ""
    '    Try
    '      Dim row1 As String = " < td style='width:100px;background-color:black;color:white;'></td>"
    '      Dim row2 As String = "<td><b>PLANNED %</b></td>"
    '      Dim row3 As String = "<td><b>ACTUAL / OUTLOOK %</b></td>"
    '      Dim row4 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
    '      For I As Integer = 0 To PlannedX.Length - 1
    '        Dim isCurrent As Boolean = False
    '        If PlannedX(I).Date = LastProcessed.Date Then
    '          isCurrent = True
    '        End If
    '        row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & PlannedX(I).ToString("dd-MMM") & "</td>"
    '        Dim actual As Decimal = 0.00
    '        Try
    '          actual = ActualY(I)
    '        Catch ex As Exception
    '          actual = 0
    '        End Try
    '        If PlannedY(I) > 1 And actual > 1 Then
    '          row2 &= "<td style='text-align:center;color:maroon;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Truncate(Math.Round(PlannedY(I), 0)) & "</td>"
    '        Else
    '          row2 &= "<td style='text-align:center;color:maroon;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Round(PlannedY(I), 2) & "</td>"
    '        End If
    '        If I > ActualY.Length - 1 Then
    '          Dim Value As Decimal = 0.00
    '          Try
    '            Value = OutlookY(I - ActualY.Length)
    '          Catch ex As Exception
    '            Value = 0.00
    '          End Try
    '          If Value > 1 Then
    '            row3 &= "<td style='text-align:center;color:orange;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Truncate(Math.Round(Value, 0)) & "</td>"
    '            row4 &= "<td style='text-align:center;background-color:gray;color:white;'>" & Math.Truncate((Math.Round(PlannedY(I), 0) - Math.Round(Value, 0))) & "</td>"
    '          Else
    '            row3 &= "<td style='text-align:center;color:orange;'>" & Math.Round(Value, 2) & "</td>"
    '            row4 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & (Math.Round(PlannedY(I), 2) - Math.Round(Value, 2)) & "</td>"
    '          End If
    '        Else
    '          If ActualY(I) > 1 Then
    '            row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Truncate(Math.Round(ActualY(I), 0)) & "</td>"
    '            row4 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & Math.Truncate((Math.Round(PlannedY(I), 0) - Math.Round(ActualY(I), 0))) & "</td>"
    '          Else
    '            row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Round(ActualY(I), 2) & "</td>"
    '            row4 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & (Math.Round(PlannedY(I), 2) - Math.Round(ActualY(I), 2)) & "</td>"
    '          End If
    '        End If
    '      Next
    '      mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
    '      mStr &= "<tr>" & row1 & "</tr>"
    '      mStr &= "<tr>" & row2 & "</tr>"
    '      mStr &= "<tr>" & row3 & "</tr>"
    '      mStr &= "<tr>" & row4 & "</tr>"
    '      mStr &= "</table>"
    '    Catch ex As Exception
    '      mStr = ex.Message
    '    End Try
    '    Return mStr
    '  End Get
    'End Property
    Public Shared Function RenderChart(ByVal Chart1 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart1.ChartAreas(0)
      With ca
        With .AxisX


          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightBlue
          .MajorGrid.LineWidth = 1


        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1

        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
       ' Chart1.Series(0).Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALX"






        'Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Verdana", 8)

        'Chart1.Legends(0).LegendStyle = LegendStyle.Table
        'Chart1.Legends(0).TableStyle = LegendTableStyle.Wide
        'Chart1.Legends(0).Docking = Docking.Bottom



        'Chart1.Series(0).BorderWidth = 3
        ' Chart1.ChartAreas(0).Area3DStyle.Inclination = 45
        'Chart1.ChartAreas(0).AxisY.TitleFont = New System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold)


        'Chart1.ChartAreas(0).Area3DStyle.PointDepth = 100
        'Chart1.ChartAreas(0).Area3DStyle.PointGapDepth = 1




        'Try
        '{
        '    If (con.State!= ConnectionState.Open) Then con.Open();
        '    SqlCommand cmd = New SqlCommand("select ReadingInstance,Temprature from Readings", con);

        '    SqlDataAdapter da = New SqlDataAdapter(cmd);
        '    da.Fill(ds);
        '}
        'Catch (Exception ex)
        '{
        '}
        'Finally
        '{
        '    If (con.State!= ConnectionState.Closed) Then con.Close();
        '}

        'If (ds.Tables[0].Rows.Count > 0)
        '{
        '    Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
        '    Chart1.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
        '    Chart1.BorderlineWidth = 3;
        '    Chart1.BackColor = Color.NavajoWhite;

        '    Chart1.ChartAreas.Add("chtArea");
        '    Chart1.ChartAreas[0].AxisX.Title = "Category Name";
        '    Chart1.ChartAreas[0].AxisX.TitleFont = New System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
        '    Chart1.ChartAreas[0].AxisY.Title = "UnitPrice";
        '    Chart1.ChartAreas[0].AxisY.TitleFont = New System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
        '    Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
        '    Chart1.ChartAreas[0].BorderWidth = 2;
        '    //Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        '    //Chart1.ChartAreas[0].Area3DStyle.Inclination = 45;
        '    //Chart1.ChartAreas[0].Area3DStyle.Rotation = 45;
        '    //Chart1.ChartAreas[0].Area3DStyle.PointDepth = 100;
        '    //Chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 1;

        '    Chart1.Legends.Add("Temprature");
        '    Chart1.Series.Add("Temprature");
        '    //Chart1.Series[0].Palette = ChartColorPalette.Bright;
        '    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        '    Chart1.Series[0].Points.DataBindXY(ds.Tables[0].DefaultView, "ReadingInstance", ds.Tables[0].DefaultView, "Temprature");

        '    //Chart1.Series[0].IsVisibleInLegend = true;
        '    Chart1.Series[0].IsValueShownAsLabel = True;
        '    Chart1.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";

        '    // Setting Line Width
        '    Chart1.Series[0].BorderWidth = 3;
        '    Chart1.Series[0].Color = Color.Red;

        '    // Setting Line Shadow
        '    //Chart1.Series[0].ShadowOffset = 5;

        '    //Legend Properties
        '    Chart1.Legends[0].LegendStyle = LegendStyle.Table;
        '    Chart1.Legends[0].TableStyle = LegendTableStyle.Wide;
        '    Chart1.Legends[0].Docking = Docking.Bottom;
        '}

        Chart1.Series(0)("PieLabelStyle") = "Outside"
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart1.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart1.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart1.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.Series(0).IsVisibleInLegend = True
        Chart1.Series(0).BorderWidth = 3
        Chart1.Font.Bold = True

      End With
      Return Chart1
    End Function

    Public Shared Function RenderChart2(ByVal Chart2 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart2.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1

        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart2.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea2"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALX"

        Chart2.Series(0)("PieLabelStyle") = "Outside"
        Chart2.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart2.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart2.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart2.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart2.Series(0).IsValueShownAsLabel = True
        Chart2.Series(0).IsVisibleInLegend = True
        Chart2.Series(0).BorderWidth = 3
        Chart2.Font.Bold = True
      End With
      Return Chart2
    End Function


    Public Shared Function RenderChart3(ByVal Chart3 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart3.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart3.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea3"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALX"
        Chart3.Series(0)("PieLabelStyle") = "Outside"
        Chart3.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart3.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart3.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart3.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart3.Series(0).IsValueShownAsLabel = True
        Chart3.Series(0).IsVisibleInLegend = True
        Chart3.Series(0).BorderWidth = 3
        Chart3.Font.Bold = True

      End With
      Return Chart3
    End Function


    Public Shared Function RenderChart4(ByVal Chart4 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart4.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart4.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea4"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALX"

        Chart4.Series(0)("PieLabelStyle") = "Outside"
        Chart4.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart4.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart4.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart4.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart4.Series(0).IsValueShownAsLabel = True
        Chart4.Series(0).IsVisibleInLegend = True
        Chart4.Series(0).BorderWidth = 3
        Chart4.Font.Bold = True
      End With
      Return Chart4
    End Function

    Public Shared Function RenderChart5(ByVal Chart5 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart5.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart5.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea5"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALX"

        Chart5.Series(0)("PieLabelStyle") = "Outside"
        Chart5.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart5.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart5.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart5.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart5.Series(0).IsValueShownAsLabel = True
        Chart5.Series(0).IsVisibleInLegend = True
        Chart5.Series(0).BorderWidth = 3
        Chart5.Font.Bold = True
      End With
      Return Chart5
    End Function
    Public Shared Function RenderChart6(ByVal Chart6 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart6.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart6.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea6"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALX"

        Chart6.Series(0)("PieLabelStyle") = "Outside"
        Chart6.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart6.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart6.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart6.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart6.Series(0).IsValueShownAsLabel = True
        Chart6.Series(0).IsVisibleInLegend = True
        Chart6.Series(0).BorderWidth = 3
        Chart6.Font.Bold = True








      End With
      Return Chart6
    End Function


    Public Shared Function RenderChart7(ByVal Chart7 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart7.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart7.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea7"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALY"

        Chart7.Series(0)("PieLabelStyle") = "Outside"
        Chart7.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart7.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart7.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart7.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart7.Series(0).IsValueShownAsLabel = True
        Chart7.Series(0).IsVisibleInLegend = True
        Chart7.Series(0).BorderWidth = 3
        Chart7.Font.Bold = True
      End With
      Return Chart7
    End Function

    Public Shared Function RenderChart10(ByVal Chart10 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart10.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart10.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea10"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALY"

        Chart10.Series(0)("PieLabelStyle") = "Outside"
        Chart10.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart10.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart10.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart10.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart10.Series(0).IsValueShownAsLabel = True
        Chart10.Series(0).IsVisibleInLegend = True
        Chart10.Series(0).BorderWidth = 3
        Chart10.Font.Bold = True
      End With
      Return Chart10
    End Function

    Public Shared Function RenderChart11(ByVal Chart11 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart11.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = 10
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart11.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Pie
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea11"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALY"

        Chart11.Series(0)("PieLabelStyle") = "Outside"
        Chart11.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart11.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart11.Legends(0).Font = New Font("Comic Sans MS", 10)
        Chart11.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart11.Series(0).IsValueShownAsLabel = True
        Chart11.Series(0).IsVisibleInLegend = True
        Chart11.Series(0).BorderWidth = 3
        Chart11.Font.Bold = True
      End With
      Return Chart11
    End Function


    Public Shared Function RenderChart8(ByVal Chart8 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart8.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
          .LabelStyle.Font = New Font("Comic Sans MS", 10)
        End With
        With .AxisY

          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Issued Transmittals")
      Chart8.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Column
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea8"
        .BorderWidth = Border
        .Color = Drawing.Color.OliveDrab
        .ToolTip = "#VALY"

        Chart8.Series(0)("PieLabelStyle") = "inside"
        Chart8.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart8.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart8.Legends(0).Font = New Font("Comic Sans MS", 10)

        Chart8.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart8.Series(0).IsValueShownAsLabel = False
        Chart8.Series(0).IsVisibleInLegend = True
        Chart8.Series(0).BorderWidth = 3
        Chart8.Font.Bold = True
        Chart8.ChartAreas(0).RecalculateAxesScale()
      End With
      Return Chart8
    End Function

    Public Shared Function RenderChart31(ByVal Chart31 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart31.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
          .LabelStyle.Font = New Font("Comic Sans MS", 6)
        End With
        With .AxisY

          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Customer Transmittals")
      Chart31.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Column
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea31"
        .BorderWidth = Border
        .Color = Drawing.Color.OliveDrab
        .ToolTip = "#VALY"

        Chart31.Series(0)("PieLabelStyle") = "inside"
        Chart31.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart31.Series(0).Font = New Font("Comic Sans MS", 8)
        Chart31.Legends(0).Font = New Font("Comic Sans MS", 10)

        Chart31.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart31.Series(0).IsValueShownAsLabel = False
        Chart31.Series(0).IsVisibleInLegend = True
        Chart31.Series(0).BorderWidth = 3
        Chart31.Font.Bold = True
        Chart31.ChartAreas(0).RecalculateAxesScale()
      End With
      Return Chart31
    End Function

    Public Shared Function RenderChart32(ByVal Chart32 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart32.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
          .LabelStyle.Font = New Font("Comic Sans MS", 10)
        End With
        With .AxisY

          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Internal Transmittals")
      Chart32.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Column
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea32"
        .BorderWidth = Border
        .Color = Drawing.Color.OliveDrab
        .ToolTip = "#VALY"

        Chart32.Series(0)("PieLabelStyle") = "inside"
        Chart32.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart32.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart32.Legends(0).Font = New Font("Comic Sans MS", 10)

        Chart32.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart32.Series(0).IsValueShownAsLabel = False
        Chart32.Series(0).IsVisibleInLegend = True
        Chart32.Series(0).BorderWidth = 3
        Chart32.Font.Bold = True
        Chart32.ChartAreas(0).RecalculateAxesScale()
      End With
      Return Chart32
    End Function

    Public Shared Function RenderChart33(ByVal Chart33 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart33.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
          .LabelStyle.Font = New Font("Comic Sans MS", 10)
        End With
        With .AxisY

          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Site Transmittals")
      Chart33.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Column
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea33"
        .BorderWidth = Border
        .Color = Drawing.Color.OliveDrab
        .ToolTip = "#VALY"

        Chart33.Series(0)("PieLabelStyle") = "inside"
        Chart33.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart33.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart33.Legends(0).Font = New Font("Comic Sans MS", 10)

        Chart33.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart33.Series(0).IsValueShownAsLabel = False
        Chart33.Series(0).IsVisibleInLegend = True
        Chart33.Series(0).BorderWidth = 3
        Chart33.Font.Bold = True
        Chart33.ChartAreas(0).RecalculateAxesScale()
      End With
      Return Chart33
    End Function

    Public Shared Function RenderChart34(ByVal Chart34 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart34.ChartAreas(0)
      With ca
        With .AxisX
          '.Interval = dt.IntervalX
          '.Minimum = dt.MinimumX.ToOADate
          '.Maximum = dt.MaximumX.ToOADate
          '.LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
          .LabelStyle.Font = New Font("Comic Sans MS", 10)
        End With
        With .AxisY

          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Vendor Transmittals")
      Chart34.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Column
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea34"
        .BorderWidth = Border
        .Color = Drawing.Color.OliveDrab
        .ToolTip = "#VALY"

        Chart34.Series(0)("PieLabelStyle") = "inside"
        Chart34.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart34.Series(0).Font = New Font("Comic Sans MS", 15)
        Chart34.Legends(0).Font = New Font("Comic Sans MS", 10)

        Chart34.ChartAreas(0).Area3DStyle.Inclination = 10

        Chart34.Series(0).IsValueShownAsLabel = False
        Chart34.Series(0).IsVisibleInLegend = True
        Chart34.Series(0).BorderWidth = 3
        Chart34.Font.Bold = True
        Chart34.ChartAreas(0).RecalculateAxesScale()
      End With
      Return Chart34
    End Function


    Public Shared Function GetCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= "  Select  "
        Sql &= "  (  case t_wfst   "
        Sql &= "  when 1 then 'Under Design' "
        Sql &= "  when 2 then 'Submitted' "
        Sql &= "  when 3 then 'Under Review' "
        Sql &= "  when 4 then 'Under Approve' "
        Sql &= "  when 5 then 'Released' "
        Sql &= "  when 6 then 'Withdrawn' "
        Sql &= "  when 7 then 'Under Revision' "
        Sql &= "  when 8 then 'Superseded' "
        Sql &= "  when 9 then 'Under DCR' "
        Sql &= "    end  ) as ValX,  ValY from  (select aa.t_wfst, count(*) as ValY  from tdmisg001200 as aa "
        Sql &= "  where aa.t_cprj ='" & ProjectID & "' and aa.t_revn= (select max(bb.t_revn) from tdmisg001200 as bb where bb.t_docn=aa.t_docn) "
        Sql &= "  group by t_wfst) as tmp "

        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function

    Public Shared Function GetDCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Under Creation' "
        Sql &= " when 2 then 'Under Approve' "
        Sql &= " when 3 then 'Approved' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg114200  "
        Sql &= " where t_cprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function
    Public Shared Function GetTCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Returned' "
        Sql &= " when 2 then 'Free' "
        Sql &= " when 3 then 'Under Approval' "
        Sql &= " when 4 then 'Under Issue' "
        Sql &= " when 5 then 'Issued' "
        Sql &= " when 6 then 'Patial Released' "
        Sql &= " when 7 then 'Received' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg131200  "
        Sql &= " where t_dprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function

    Public Shared Function GetT1Chart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Returned' "
        Sql &= " when 2 then 'Free' "
        Sql &= " when 3 then 'Under Approval' "
        Sql &= " when 4 then 'Under Issue' "
        Sql &= " when 5 then 'Issued' "
        Sql &= " when 6 then 'Patial Released' "
        Sql &= " when 7 then 'Received' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg131200  "
        Sql &= " where t_type =1 and t_dprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function
    Public Shared Function GetT2Chart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Returned' "
        Sql &= " when 2 then 'Free' "
        Sql &= " when 3 then 'Under Approval' "
        Sql &= " when 4 then 'Under Issue' "
        Sql &= " when 5 then 'Issued' "
        Sql &= " when 6 then 'Patial Released' "
        Sql &= " when 7 then 'Received' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg131200  "
        Sql &= " where t_type =2 and t_dprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function
    Public Shared Function GetT3Chart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Returned' "
        Sql &= " when 2 then 'Free' "
        Sql &= " when 3 then 'Under Approval' "
        Sql &= " when 4 then 'Under Issue' "
        Sql &= " when 5 then 'Issued' "
        Sql &= " when 6 then 'Patial Released' "
        Sql &= " when 7 then 'Received' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg131200  "
        Sql &= " where t_type =3 and t_dprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function
    Public Shared Function GetT4Chart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Returned' "
        Sql &= " when 2 then 'Free' "
        Sql &= " when 3 then 'Under Approval' "
        Sql &= " when 4 then 'Under Issue' "
        Sql &= " when 5 then 'Issued' "
        Sql &= " when 6 then 'Patial Released' "
        Sql &= " when 7 then 'Received' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg131200  "
        Sql &= " where t_type =4 and t_dprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function
    Public Shared Function GetSCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Created' "
        Sql &= " when 2 then 'Under Review' "
        Sql &= " when 3 then 'Under Approval' "
        Sql &= " when 4 then 'Approved' "
        Sql &= " when 5 then 'Not Applicable' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from ttpisg074200  "
        Sql &= " where t_cprj ='" & ProjectID & "'"
        Sql &= " group by t_stat) as tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function

    Public Shared Function GetPCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document Linked' "
        Sql &= " when 3 then 'Under Evaluated' "
        Sql &= " when 4 then 'Comment Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superseded' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg134200  "
        Sql &= " where t_cprj ='" & ProjectID & "'"
        Sql &= " and t_rcno like('REC%')"
        Sql &= " group by t_stat) As tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function

    Public Shared Function GetOCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document Linked' "
        Sql &= " when 3 then 'Under Evaluated' "
        Sql &= " when 4 then 'Comment Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superseded' "
        Sql &= " when 8 then 'Closed' "
        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_stat, count(*) as ValY  "
        Sql &= " from tdmisg134200  "
        Sql &= " where t_cprj ='" & ProjectID & "'"
        Sql &= " and t_rcno like('REP%')"
        Sql &= " group by t_stat) As tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function

    Public Shared Function GetECTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select ( "
        Sql &= " case t_engs"
        Sql &= " when 1 then 'Free' "
        Sql &= " when 2 then 'Partial' "
        Sql &= " when 3 then 'Complete' "

        Sql &= " end "
        Sql &= " ) as ValX, "
        Sql &= " ValY from "
        Sql &= " (select t_engs, count(*) as ValY  "
        Sql &= " from ttpisg063200  "
        Sql &= " where t_cprj ='" & ProjectID & "' And t_appl = 1"
        Sql &= " group by t_engs) As tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function


    Public Shared Function GetHCTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " SELECT        ResponsibleDept AS ValX, ValY"
        Sql &= " FROM            (SELECT        ResponsibleDept, COUNT(*) AS ValY "
        Sql &= " FROM            [IJTPerks].[dbo].[DWG_HoldList] as aa"
        Sql &= " WHERE        (ProjectID = '" & ProjectID & "') AND (HoldStatus = 1) AND aa.SerialNo =(SELECT MAX(SerialNo) FROM [IJTPerks].[dbo].[DWG_HoldList] AS bb WHERE (bb.DocumentID = aa.DocumentID) ) "

        Sql &= " GROUP BY ResponsibleDept) AS tmp "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function

    Public Shared Function GetHCTChart1(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " SELECT        (CASE HoldStatus WHEN 1 THEN 'HOLD ACTIVE' WHEN 0 THEN 'HOLD LIFTED' END) AS ValX, ValY "
        Sql &= " FROM            (SELECT        HoldStatus, COUNT(*) AS ValY "
        Sql &= " FROM            [IJTPerks].[dbo].[DWG_HoldList] as aa"
        Sql &= " WHERE        (ProjectID = '" & ProjectID & "') AND aa.SerialNo =(SELECT MAX(SerialNo) FROM [IJTPerks].[dbo].[DWG_HoldList] AS bb WHERE (bb.DocumentID = aa.DocumentID) ) "

        Sql &= " GROUP BY HoldStatus) AS tmp  "
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function


    Public Shared Function GetTTTChart(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '2. Get Planned
        Sql = ""
        Sql &= " Select (case t_type  "
        Sql &= " when 1 then 'Customer(TC)'  "
        Sql &= " when 2 then 'Internal(TI)'  "
        Sql &= " when 3 then 'Site(TS)'  "
        Sql &= " when 4 then 'Vendor(TV)'  "
        Sql &= "         "
        Sql &= "        end) as ValX,  "
        Sql &= "        ValY from  "
        Sql &= "         (select t_type, count(*) as ValY   "
        Sql &= "         from tdmisg131200   "
        Sql &= " where t_dprj ='" & ProjectID & "'"
        Sql &= " and t_stat = 5 group by t_type) as tmp "

        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) x.ValY).ToArray
      End Using
      Return mRet
    End Function




    Public Shared Function GetPMDLDB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID



      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='PRC' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Total_Count = Cmd.ExecuteScalar
        End Using

        '----

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select t_dsca from ttcmcs052200 where t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.ProjectDesc = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='MEC' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='STR' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Total_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='PIP' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='ELE' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='C&I' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='PRC' and t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Release_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='MEC' and t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Release_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='STR' and t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Release_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='PIP' and t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Release_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='ELE' and t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Release_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp ='C&I' and t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Release_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where t_acdt <>'1970-01-01 00:00:00.000' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Release_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where  t_resp ='PRC' and t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where  t_resp ='MEC' and t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where  t_resp ='STR' and t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where  t_resp ='PIP' and t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where  t_resp ='ELE' and t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where  t_resp ='C&I' and t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " select count(t_docn) from tdmisg140200 where t_cprj in ('" & ProjectID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Pending_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(t_docn) From tdmisg140200 Where t_resp ='PRC' and t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Due_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "Select count(t_docn) From tdmisg140200 Where t_resp ='MEC' and t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Due_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "Select count(t_docn) From tdmisg140200 Where t_resp ='STR' and t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Due_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "Select count(t_docn) From tdmisg140200 Where t_resp ='PIP' and t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Due_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "Select count(t_docn) From tdmisg140200 Where t_resp ='ELE' and t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Due_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "Select count(t_docn) From tdmisg140200 Where t_resp ='C&I' and t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Due_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "Select count(t_docn) From tdmisg140200 Where t_cprj In ('" & ProjectID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Due_Count = Cmd.ExecuteScalar
        End Using





        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)	"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    And t_resp ='PRC'	and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_OnTime_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "Select count(*) from tdmisg001200 where t_stat =1 And t_wfst =3 And t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    And t_resp ='MEC'	and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_OnTime_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    And t_resp ='STR'	and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_OnTime_Count = Cmd.ExecuteScalar
        End Using



        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    And t_resp ='PIP'	and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_OnTime_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    And t_resp ='ELE'	and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_OnTime_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    And t_resp ='C&I'	and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_OnTime_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)"
        Sql &= "		from tdmisg140200	"
        Sql &= "		where "
        Sql &= "		t_cprj in ('" & ProjectID & "')  "
        Sql &= "    and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_OnTime_Count = Cmd.ExecuteScalar
        End Using


        '--------
        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  And t_resp ='PRC'	and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Delayed_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "Select count(*) from tdmisg001200 where t_stat =1 And t_wfst =3 And t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  And t_resp ='MEC'	and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Delayed_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  And t_resp ='PIP'	and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Delayed_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  And t_resp ='STR'	and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Delayed_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  And t_resp ='ELE'	and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Delayed_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  And t_resp ='C&I'	and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Delayed_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_cprj in ('" & ProjectID & "')  "
        Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Delayed_Count = Cmd.ExecuteScalar
        End Using


      End Using
      Return mRet
    End Function

    Public Shared Function GetDCRDB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID



      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_DCR_Approved = Cmd.ExecuteScalar
        End Using



        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_stat=1 and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_stat=2 and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_stat=3 and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_DCR_Approved = Cmd.ExecuteScalar
        End Using




        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_DCR_Approved = Cmd.ExecuteScalar
        End Using


        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_DCR_Approved = Cmd.ExecuteScalar
        End Using


        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_DCR_Approved = Cmd.ExecuteScalar
        End Using



        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_DCR_Approved = Cmd.ExecuteScalar
        End Using





        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_DCR_Approved = Cmd.ExecuteScalar
        End Using




        ' Sql = "-"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_DCR_Total_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_DCR_Under_Creation = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_DCR_Under_Approval = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa where t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_DCR_Approved = Cmd.ExecuteScalar
        End Using

      End Using
      Return mRet
    End Function


    Public Shared Function GetTRANSMITTALDB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID
      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PRC' and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Transmittal_Returned = Cmd.ExecuteScalar
        End Using


        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='MEC' and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Transmittal_Returned = Cmd.ExecuteScalar
        End Using


        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='STR' and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Transmittal_Returned = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='PIP' and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Transmittal_Returned = Cmd.ExecuteScalar
        End Using


        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='ELE' and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Transmittal_Returned = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept ='C&I' and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Transmittal_Returned = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS')"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS')  and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg130200.t_dept IN ('OTHERS') and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Transmittal_Returned = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Free = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Under_Issue = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =6"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Partial_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =7"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Received = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =8"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) from tdmisg131200 LEFT JOIN tdmisg130200 on tdmisg131200.t_user= tdmisg130200.t_logn where (t_tran LIKE ('SMD%') OR t_tran LIKE ('BOI%') OR t_tran LIKE ('APC%') OR t_tran LIKE ('EPC%') OR t_tran LIKE ('PCD%')) and t_dprj = ('" & ProjectID & "') and tdmisg131200.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Transmittal_Returned = Cmd.ExecuteScalar
        End Using


      End Using
      Return mRet
    End Function

    Public Shared Function GetPSTRANSMITTALDB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID
      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=5000")
        Con.Open()

        'Public Property Process_PSTransmittal_Total_Count As Integer = 0
        'Public Property Mechanical_PSTransmittal_Total_Count As Integer = 0
        'Public Property Piping_PSTransmittal_Total_Count As Integer = 0
        'Public Property Structure_PSTransmittal_Total_Count As Integer = 0
        'Public Property Electrical_PSTransmittal_Total_Count As Integer = 0
        'Public Property CI_PSTransmittal_Total_Count As Integer = 0
        'Public Property Others_PSTransmittal_Total_Count As Integer = 0
        'Public Property Totals_PSTransmittal_Total_Count As Integer = 0

        'Public Property Process_PSTransmittal_Pending_Count As Integer = 0

        'Public Property Mechanical_PSTransmittal_Pending_Count As Integer = 0
        'Public Property Piping_PSTransmittal_Pending_Count As Integer = 0
        'Public Property Structure_PSTransmittal_Pending_Count As Integer = 0
        'Public Property Electrical_PSTransmittal_Pending_Count As Integer = 0
        'Public Property CI_PSTransmittal_Pending_Count As Integer = 0
        'Public Property Others_PSTransmittal_Pending_Count As Integer = 0
        'Public Property Totals_PSTransmittal_Pending_Count As Integer = 0




        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort ='PROCESS'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Process_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort ='MECHANICAL'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Mechanical_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort ='STRUCTURE'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Structure_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort ='PIPING'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Piping_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort ='ELECTRICAL'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Electrical_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort ='C&I'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.CI_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND ttppdm090200.t_sort not in ('C&I','ELECTRICAL','PIPING','STRUCTURE','MECHANICAL','PROCESS')"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Others_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Total_PSTransmittal_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort ='PROCESS'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Process_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort ='MECHANICAL'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Mechanical_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort ='STRUCTURE'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Structure_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select  Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort ='PIPING'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Piping_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort ='ELECTRICAL'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Electrical_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort ='C&I'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.CI_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "') AND ttppdm090200.t_sort not in ('C&I','ELECTRICAL','PIPING','STRUCTURE','MECHANICAL','PROCESS')"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Others_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using


        Sql = "Select Count(*) from tdmisg140200 As aa LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa= aa.t_cspa where aa.t_cprj='" & ProjectID & "' and aa.t_erec=1 AND aa.t_docn+'_'+aa.t_revn not in (select bb.t_docn+'_'+bb.t_revn from tdmisg132200 as bb inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran WHERE cc.t_type=3 and left(bb.t_docn,6)='" & ProjectID & "')"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          mRet.Total_PSTransmittal_Pending_Count = Cmd.ExecuteScalar
        End Using


      End Using
      Return mRet
    End Function


    Public Shared Function GetSARDB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID



      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using


        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE')  and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE')  and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE')  and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where  t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_SAR_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "') AND rec.t_stat =1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_SAR_Under_Creation = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "') AND rec.t_stat =2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_SAR_Under_Review = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_SAR_Under_Approval = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where t_cprj in ('" & ProjectID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_SAR_Not_Applicable = Cmd.ExecuteScalar
        End Using




      End Using
      Return mRet
    End Function

    Public Shared Function GetIDMSPDB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID



      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REC%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSP_Closed = Cmd.ExecuteScalar
        End Using



      End Using
      Return mRet
    End Function

    Public Shared Function GetIDMSODB(ByVal ProjectID As String) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID



      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort='PROCESS' and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('STRUCTURE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort IN ('PIPING') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort in ('CI','INSTRUMENTATION') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE','SERVICE') and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_IDMSO_Closed = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%') and t_cprj in ('" & ProjectID & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Total_Count = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Document_linked = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=4 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=5 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=6 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=7 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "Select count(*) From tdmisg134200 As rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) Where rec.t_rcno Like ('REP%')  and t_cprj in ('" & ProjectID & "')  and rec.t_stat=8 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_IDMSO_Closed = Cmd.ExecuteScalar
        End Using


      End Using
      Return mRet
    End Function


    Public Shared Function GetELEMENTDB(ByVal PrjID As String) As CTChart
      If PrjID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = PrjID



      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using



        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Element_Free = Cmd.ExecuteScalar
        End Using





        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PROCESS' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Process_Element_Completed = Cmd.ExecuteScalar
        End Using



        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_engs=1 and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Element_Free = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_engs=2 and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('MECHANICAL','MECH-SUGAR','PROCESS-STOKER') and rec.t_engs=3 and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Mechanical_Element_Completed = Cmd.ExecuteScalar
        End Using




        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Element_Free = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='STRUCTURE' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Structure_Element_Completed = Cmd.ExecuteScalar
        End Using


        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Element_Free = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort='PIPING' and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Piping_Element_Completed = Cmd.ExecuteScalar
        End Using


        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Element_Free = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('ELECTRICAL','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Electrical_Element_Completed = Cmd.ExecuteScalar
        End Using



        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION','C&I') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION','C&I') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Element_Free = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION','C&I') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort IN ('C & I','INSTRUMENTATION','C&I') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.CI_Element_Completed = Cmd.ExecuteScalar
        End Using





        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Element_Free = Cmd.ExecuteScalar
        End Using




        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort NOT IN ('MECH-SUGAR','MECHANICAL','ELECTRICAL','PROCESS-STOKER','PROCESS','STRUCTURE','PIPING' ,'C & I','INSTRUMENTATION','EPC','C&I','ELE') and rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Others_Element_Completed = Cmd.ExecuteScalar
        End Using


        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Element_Total_Active_Element_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Element_Free = Cmd.ExecuteScalar
        End Using



        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa where rec.t_cprj in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Element_Completed = Cmd.ExecuteScalar
        End Using

      End Using
      Return mRet
    End Function


  End Class
End Namespace
