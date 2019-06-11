Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.DB
  <DataObject()>
  Public Class RDChart
    Private Class RDData
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

    Public Property Division As String = ""

    Public Property Department As String = ""

    Public Property Subgroup As String = ""
    Public Property Report As String = ""
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

    Public Property CM_Plan As Integer = 0
    Public Property CM1_Plan As Integer = 0
    Public Property CM2_Plan As Integer = 0
    Public Property CM3_Plan As Integer = 0
    Public Property CM4_Plan As Integer = 0
    Public Property CM5_Plan As Integer = 0
    Public Property CM6_Plan As Integer = 0
    Public Property CM7_Plan As Integer = 0
    Public Property CM8_Plan As Integer = 0
    Public Property CM9_Plan As Integer = 0
    Public Property CM10_Plan As Integer = 0
    Public Property CM11_Plan As Integer = 0
    Public Property Total_plan As Integer = 0
    Public Property CM_Release As Integer = 0
    Public Property CM1_Release As Integer = 0
    Public Property CM2_Release As Integer = 0
    Public Property CM3_Release As Integer = 0
    Public Property CM4_Release As Integer = 0
    Public Property CM5_Release As Integer = 0
    Public Property CM6_Release As Integer = 0
    Public Property CM7_Release As Integer = 0
    Public Property CM8_Release As Integer = 0
    Public Property CM9_Release As Integer = 0
    Public Property CM10_Release As Integer = 0
    Public Property CM11_Release As Integer = 0

    Public Property Total_Release As Integer = 0
    Public Property CM_Balance As Integer = 0
    Public Property CM1_Balance As Integer = 0
    Public Property CM2_Balance As Integer = 0
    Public Property CM3_Balance As Integer = 0
    Public Property CM4_Balance As Integer = 0
    Public Property CM5_Balance As Integer = 0
    Public Property CM6_Balance As Integer = 0
    Public Property CM7_Balance As Integer = 0
    Public Property CM8_Balance As Integer = 0
    Public Property CM9_Balance As Integer = 0
    Public Property CM10_Balance As Integer = 0
    Public Property CM11_Balance As Integer = 0
    Public Property Total_Balance As Integer = 0



    Public Shared Function GetReportDB(ByVal ProjectID As String) As RDChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New RDChart
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
          mRet.Total_plan = Cmd.ExecuteScalar
        End Using




      End Using
      Return mRet
    End Function




  End Class
End Namespace
