Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class dbDocumentDB
    Public Property P_Review As Integer = 0
    Public Property P_Approve As Integer = 0
    Public Property P_Designer As Integer = 0

    Public Property T_UApproval As Integer = 0
    Public Property T_UIssue As Integer = 0
    Public Property D_Approval As Integer = 0
    Public Property D_AppCrtd As Integer = 0
    Public Property S_Approval As Integer = 0
    Public Property S_Review As Integer = 0
    Public Property I_PreUEvaluation As Integer = 0
    Public Property I_PostUEvaluation As Integer = 0
    Public Property M_EntryForToday As Decimal = 0
    Public Property L_UserGroup As String = ""
    Public Property L_Usercode As String = ""
    Public Property visitorcount As Integer = 0

    Public Shared Function GetDocumentDB() As SIS.DB.dbDocumentDB


      Dim UserID As String = HttpContext.Current.Session("LoginID")

      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try
      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)
      Dim mRet As New SIS.DB.dbDocumentDB
      mRet.L_Usercode = UserID
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        'Sql = "select * from tdmisg001200 where t_stat =1 and t_wfst =4 and t_ausr='" & UserID & "'"
        Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst in(1,2) and t_user in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.P_Designer = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.P_Review = Cmd.ExecuteScalar
        End Using

        'Sql = "select * from tdmisg001200 where t_stat =1 and t_wfst =4 and t_ausr='" & UserID & "'"
        Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =4 and t_ausr in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.P_Approve = Cmd.ExecuteScalar
        End Using


        'Sql = "select count(*) from tdmisg131200 where t_type =2 and t_stat =3 and t_user='" & UserID & "'"
        Sql = "select count(*) from tdmisg131200 where t_type =2 and t_stat =3 and t_user in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.T_UApproval = Cmd.ExecuteScalar
        End Using

        'Sql = "select count(*) from tdmisg131200 where t_type =2 and t_stat =4 and t_user='" & UserID & "'"
        Sql = "select count(*) from tdmisg131200 where t_stat =4 and (t_user in ('" & UserID & "','" & UserIDT & "') or t_apsu in ('" & UserID & "','" & UserIDT & "'))"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.T_UIssue = Cmd.ExecuteScalar
        End Using

        'Sql = "select count(*) from tdmisg114200 where t_stat =2 and t_user='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 where t_stat =2 and t_user in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.D_Approval = Cmd.ExecuteScalar
        End Using

        'Sql = "select count(*) from tdmisg114200 where t_stat =2 and t_crea='" & UserID & "'"
        Sql = "select count(*) from tdmisg114200 where t_stat =2 and t_crea in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.D_AppCrtd = Cmd.ExecuteScalar
        End Using

        'Sql = "Select count(*) from ttpisg074200 where t_stat=2 and t_rper ='" & UserID & "'"
        Sql = "Select count(*) from ttpisg074200 where t_stat=2 and t_rper in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.S_Review = Cmd.ExecuteScalar
        End Using

        'Sql = "Select count(*) from ttpisg074200 where t_stat=3 and t_apby ='" & UserID & "'"
        Sql = "Select count(*) from ttpisg074200 where t_stat=3 and t_apby in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.S_Approval = Cmd.ExecuteScalar
        End Using

        'Sql = "Select count(*) from tdmisg134200 where t_rcno like ('REC%') and t_stat =3"

        Sql = " Select count(*)  "
        Sql &= " from tdmisg134200 as rec"
        Sql &= "  where rec.t_rcno like ('REC%') "
        Sql &= "  and rec.t_stat =3"
        Sql &= "  and 1 = case (select top 1 t_dept from tdmisg130200 where t_logn in ('" & UserID & "')) "
        Sql &= "   when 'MEC' then case when rec.t_sent_1=1 then 1 else 0 end  "
        Sql &= "   when 'STR' then case when rec.t_sent_2=1 then 1 else 0 end  "
        Sql &= "   when 'PIP' then case when rec.t_sent_3=1 then 1 else 0 end "
        Sql &= "   when 'PRC' then case when rec.t_sent_4=1 then 1 else 0 end "
        Sql &= "   when 'C&I' then case when rec.t_sent_5=1 then 1 else 0 end "
        Sql &= "   when 'ELE' then case when rec.t_sent_6=1 then 1 else 0 end "
        Sql &= "   when 'QLY' then case when rec.t_sent_7=1 then 1 else 0 end "
        Sql &= "   end"
        Sql &= "   And t_eunt= (select top 1 t_eunt from tdmisg130200 where t_logn in ('" & UserID & "')) "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.I_PreUEvaluation = Cmd.ExecuteScalar
        End Using


        'Sql = "Select count(*) from tdmisg134200 where t_rcno like ('REC%') and t_stat =3"
        Sql = " Select count(*)   "
        Sql &= " from tdmisg134200 as rec"
        Sql &= "  where rec.t_rcno like ('REP%') "
        Sql &= "  and rec.t_stat =3  "
        Sql &= "  and 1 = case (select top 1 t_dept from tdmisg130200 where t_logn in ('" & UserID & "')) "
        Sql &= "   when 'MEC' then case when rec.t_sent_1=1 then 1 else 0 end  "
        Sql &= "   when 'STR' then case when rec.t_sent_2=1 then 1 else 0 end  "
        Sql &= "   when 'PIP' then case when rec.t_sent_3=1 then 1 else 0 end "
        Sql &= "   when 'PRC' then case when rec.t_sent_4=1 then 1 else 0 end "
        Sql &= "   when 'C&I' then case when rec.t_sent_5=1 then 1 else 0 end "
        Sql &= "   when 'ELE' then case when rec.t_sent_6=1 then 1 else 0 end "
        Sql &= "   when 'QLY' then case when rec.t_sent_7=1 then 1 else 0 end "
        Sql &= "   end"
        Sql &= "   And t_eunt= (select top 1 t_eunt from tdmisg130200 where t_logn in ('" & UserID & "')) "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.I_PostUEvaluation = Cmd.ExecuteScalar
        End Using


        'Sql = "Select count(*) from tdmisg134200 where t_rcno like ('REC%') and t_stat =3"
        Sql = "select t_hhrs from ttiisg910200 where t_tdat ='" & sdate & "' and t_emno in ('" & UserID & "','" & UserIDT & "') "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.M_EntryForToday = Cmd.ExecuteScalar
        End Using

        'Sql = "Select count(*) from tdmisg134200 where t_rcno like ('REC%') and t_stat =3"
        Sql = "select ("
        Sql &= "CASE t_grcd"

        Sql &= " 	When 'COMM001'	 Then  'Commercial'	"
        Sql &= " 	When 'COMM002'	 Then  'Commercial - Logistic'	"
        Sql &= " 	When 'COMM003'	 Then  'Boiler Commercial'	"
        Sql &= " 	When 'CONS001'	 Then  'Boiler Construction'	"
        Sql &= " 	When 'CONS002'   Then  'EPC Construction'	"
        Sql &= " 	When 'CONS003'	 Then  'SMD Construction'	"
        Sql &= " 	When 'CONS004'   Then  'COMMISSIONING & AFTER SALES'	"
        Sql &= " 	When 'CONS005'	 Then  'PC Boiler Construction'	"
        Sql &= " 	When 'DOMLOG1'	 Then  'Domestic Logistics'	"
        Sql &= " 	When 'ENGG001'	 Then  'BOILER - MECHANICAL GROUP'	"
        Sql &= " 	When 'ENGG002'	 Then  'Thermal & Process Group'	"
        Sql &= " 	When 'ENGG003'	 Then  'Design Automation + Standard'	"
        Sql &= " 	When 'ENGG004'	 Then  'PC Boiler Engineering'	"
        Sql &= " 	When 'ENGG005'	 Then  'Boiler Chennai Design centre'	"
        Sql &= " 	When 'ENGG006'	 Then  'Engg. Administration'	"
        Sql &= " 	When 'ENGG007'	 Then  'APCE-Design'	"
        Sql &= " 	When 'ENGG008'	 Then  'Boiler Proposal Chennai'	"
        Sql &= " 	When 'ENGG009'	 Then  'CFBC-Thermal and Process'	"
        Sql &= " 	When 'ENGG010'	 Then  'Project Engineering Function'	"
        Sql &= " 	When 'ENGG011'	 Then  'EPC ENGINEERING MECHANICAL'	"
        Sql &= " 	When 'ENGG012'	 Then  'EPC ENGINEERING ELECTRICAL'	"
        Sql &= " 	When 'ENGG013'	 Then  'EPC ENGINEERING PIPING'	"
        Sql &= " 	When 'ENGG014'	 Then  'EPC ENGINEERING C&I'	"
        Sql &= " 	When 'ENGG015'	 Then  'EPC ENGINEERING CIVIL'	"
        Sql &= " 	When 'ENGG020'	 Then  'FGD ENGINEERING'	"
        Sql &= " 	When 'ENGGA'	   Then  'TG AND DG GROUP'	"
        Sql &= " 	When 'ENGGB'	   Then  'AFBC GROUP'	"
        Sql &= " 	When 'ENGGC'	   Then  'CFBC GROUP'	"
        Sql &= " 	When 'ENGGD'	 Then  'BOILER - PIPING GROUP'	"
        Sql &= " 	When 'ENGGE'	 Then  'STANDARDISATION GROUP'	"
        Sql &= " 	When 'ENGGF'	 Then  'BOILER - STRUCTURAL GROUP'	"
        Sql &= " 	When 'ENGGG'	 Then  'BOILER - ELECTRICAL GROUP'	"
        Sql &= " 	When 'ENGGH'	 Then  'BOILER - C & I GROUP'	"
        Sql &= " 	When 'ENGGI'	 Then  'SMD DESIGN GROUP'	"
        Sql &= " 	When 'ENGGJ'	 Then  'GEBD CHENNAI DESIGN CENTRE'	"
        Sql &= " 	When 'ENGGK'	 Then  'IBD CHENNAI DESIGN CENTRE'	"
        Sql &= " 	When 'ENGGL'	 Then  'OIL & GAS FIRED GROUP'	"
        Sql &= " 	When 'ENGGM'	 Then  'EPC CHENNAI DESIGN CENTRE'	"
        Sql &= " 	When 'ENGGN'	 Then  'SMD - C & I'	"
        Sql &= " 	When 'ENGGO'	 Then  'SMD - ELECTRICAL'	"
        Sql &= " 	When 'ESTM001'	 Then 'Estimation'	"
        Sql &= " 	When 'EXPR001'	 Then  'Export Sales'	"
        Sql &= " 	When 'HRAD001'	 Then  'HR/Admin'	"
        Sql &= " 	When 'MATR001'	 Then  'Boiler Materials'	"
        Sql &= " 	When 'MATR002'	 Then  'EPC Materials'	"
        Sql &= " 	When 'MATR003'	 Then  'SMD Materials	'	"
        Sql &= " 	When 'MATR011'	 Then  'Vendor Development Cell'	"
        Sql &= " 	When 'PROD001'	 Then  'Product Packages Group'	"
        Sql &= " 	When 'PROJ100'	 Then  'Boiler Projects'	"
        Sql &= " 	When 'PROJ200'	 Then  'PC Boiler Projects'	"
        Sql &= " 	When 'PROJ800'	 Then  'SMD Projects'	"
        Sql &= " 	When 'PROJ900'	 Then  'EPC Projects'	"
        Sql &= " 	When 'PROP001'	 Then  'Boiler Proposal'	"
        Sql &= " 	When 'PROP002'	 Then  'SMD Proposal'	"
        Sql &= " 	When 'PUNE001'	 Then  'SMD PUNE DESIGN CENTRE'	"
        Sql &= " 	When 'PUNE002'	 Then  'PUNE OFFICE NON DESIGN STAFF'	"
        Sql &= " 	When 'QUAL001'	 Then  'Quality'	"
        Sql &= " 	When 'RND0001'   Then  'R & D'	"
        Sql &= " 	When 'SALS001'	 Then  'IBD/GEBD Marketting'	"
        Sql &= " 	When 'SALS002'	 Then  'EPC Marketting'	"
        Sql &= " 	When 'SALS003'	 Then  'PC Marketting'	"
        Sql &= " 	When 'SALS004'	 Then  'SMD Marketting'	"
        Sql &= " 	When 'SYS0001'	 Then  'Systems'	"


        Sql &= " End) As u_Department "
        Sql &= " From ttiisg917200 "
        Sql &= " where t_emno in ('" & UserID & "','" & UserIDT & "') "
        Sql &= " And t_srno = (select max(t_srno) from ttiisg917200 where t_emno in ('" & UserID & "','" & UserIDT & "') "
        Sql &= "  )"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.L_UserGroup = Cmd.ExecuteScalar

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
  'Public Class UserRolePLM
  '  Public Property PLMEmployeeDivision As String = ""
  '  Public Property PLMEmployeeGroup As String = ""
  '  Public Property PLMEmployeeRole As String = ""
  '  Public Property PLMEApplication As String = ""

  '  Public Shared Function GetUserRolePLM(ByVal UserID As String) As List(Of SIS.DB.UserRolePLM)

  '    UserID = HttpContext.Current.Session("LoginID")

  '    Dim UserIDT As Integer = 0
  '    Try
  '      UserIDT = Convert.ToInt32(UserID)
  '    Catch ex As Exception

  '    End Try
  '    Dim mRet As New List(Of SIS.DB.UserRolePLM)

  '    Dim Sql As String = ""
  '    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
  '      Con.Open()
  '      Sql = " select (case t_eunt "
  '      Sql &= " when 'EU200' then 'BOILER' "
  '      Sql &= " when 'EU210' then 'EPC' "
  '      Sql &= " when 'EU220' then 'PC' "
  '      Sql &= " when 'EU230' then 'SMD' "
  '      Sql &= " when 'EU240' then 'APC' "
  '      Sql &= " when 'EU250' then 'ISGEC Wet FGD Business' "
  '      Sql &= " When 'EU290' then 'ISGEC R&D' "
  '      Sql &= " when 'EU400' then 'ISGEC HO' "
  '      Sql &= " When 'EU650' then 'Isgec Covema Ltd.' "
  '      Sql &= " end) as PLMEmployeeDivision, (case t_grup "
  '      Sql &= " when 'ELE' then 'Electrical' "
  '      Sql &= " when 'MEC' then 'Mechanical' "
  '      Sql &= " when 'MHE' then 'Material Handling Equipment' "
  '      Sql &= " when 'OTR' then 'Other' "
  '      Sql &= " when 'PEM' then 'Project Engineering Management' "
  '      Sql &= " when 'PIP' then 'Piping' "
  '      Sql &= " When 'PRC' then 'Process' "
  '      Sql &= " when 'PRJ' then 'Projects' "
  '      Sql &= " When 'QLY' then 'Quality' "
  '      Sql &= " When 'STR' then 'Structure' "
  '      Sql &= " When 'WWS' then 'Water & Waste Water Solution' "
  '      Sql &= " end) as PLMEmployeeGroup, (case t_cact  "
  '      Sql &= " When '1' then 'Designer' "
  '      Sql &= " When '2' then 'Reviewer' "
  '      Sql &= " When '3' then 'Approver' "
  '      Sql &= " When '4' then 'Requestor' "
  '      Sql &= " end) as PLMEmployeeRole, (case t_dcrr  "
  '      Sql &= " When '1' then 'DCR' "
  '      Sql &= " When '2' then 'PLM' "
  '      Sql &= " end) as PLMEApplication from tdmisg101200 where t_dcrr=2  and t_emno in ('" & UserID & "','" & UserIDT & "') "
  '      Using Cmd As SqlCommand = Con.CreateCommand()
  '        Cmd.CommandType = CommandType.Text
  '        Cmd.CommandText = Sql
  '        Dim rd As SqlDataReader = Cmd.ExecuteReader
  '        While rd.Read
  '          mRet.Add(New SIS.DB.UserRolePLM(rd))
  '        End While
  '      End Using
  '    End Using

  '    Return mRet
  '  End Function
  '  Public Sub New(ByVal Reader As SqlDataReader)
  '    Try
  '      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
  '        If pi.MemberType = Reflection.MemberTypes.Property Then
  '          Try
  '            Dim Found As Boolean = False
  '            For I As Integer = 0 To Reader.FieldCount - 1
  '              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
  '                Found = True
  '                Exit For
  '              End If
  '            Next
  '            If Found Then
  '              If Convert.IsDBNull(Reader(pi.Name)) Then
  '                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
  '                  Case "Decimal"
  '                    CallByName(Me, pi.Name, CallType.Let, "0.00")
  '                  Case "bit"
  '                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
  '                  Case Else
  '                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
  '                End Select
  '              Else
  '                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
  '              End If
  '            End If
  '          Catch ex As Exception
  '          End Try
  '        End If
  '      Next
  '    Catch ex As Exception
  '    End Try
  '  End Sub
  '  Public Sub New()
  '  End Sub
  'End Class

  'Public Class UserRoleDCR
  '  Public Property DCREmployeeDivision As String = ""
  '  Public Property DCREmployeeGroup As String = ""
  '  Public Property DCREmployeeRole As String = ""
  '  Public Property DCREApplication As String = ""

  '  Public Shared Function GetUserRoleDCR(ByVal UserID As String) As List(Of SIS.DB.UserRoleDCR)

  '    UserID = HttpContext.Current.Session("LoginID")

  '    Dim UserIDT As Integer = 0
  '    Try
  '      UserIDT = Convert.ToInt32(UserID)
  '    Catch ex As Exception

  '    End Try
  '    Dim mRet As New List(Of SIS.DB.UserRoleDCR)
  '    Dim Sql As String = ""
  '    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
  '      Con.Open()
  '      Sql = " Select (Case t_eunt "
  '      Sql &= " When 'EU200' then 'BOILER' "
  '      Sql &= " when 'EU210' then 'EPC' "
  '      Sql &= " when 'EU220' then 'PC' "
  '      Sql &= " when 'EU230' then 'SMD' "
  '      Sql &= " when 'EU240' then 'APC' "
  '      Sql &= " when 'EU250' then 'ISGEC Wet FGD Business' "
  '      Sql &= " When 'EU290' then 'ISGEC R&D' "
  '      Sql &= " when 'EU400' then 'ISGEC HO' "
  '      Sql &= " When 'EU650' then 'Isgec Covema Ltd.' "
  '      Sql &= " end) as DCREmployeeDivision, (case t_grup "
  '      Sql &= " when 'ELE' then 'Electrical' "
  '      Sql &= " when 'MEC' then 'Mechanical' "
  '      Sql &= " when 'MHE' then 'Material Handling Equipment' "
  '      Sql &= " when 'OTR' then 'Other' "
  '      Sql &= " when 'PEM' then 'Project Engineering Management' "
  '      Sql &= " when 'PIP' then 'Piping' "
  '      Sql &= " When 'PRC' then 'Process' "
  '      Sql &= " when 'PRJ' then 'Projects' "
  '      Sql &= " When 'QLY' then 'Quality' "
  '      Sql &= " When 'STR' then 'Structure' "
  '      Sql &= " When 'WWS' then 'Water & Waste Water Solution' "
  '      Sql &= " end) as DCREmployeeGroup, (case t_cact  "
  '      Sql &= " When '1' then 'Designer' "
  '      Sql &= " When '2' then 'Reviewer' "
  '      Sql &= " When '3' then 'Approver' "
  '      Sql &= " When '4' then 'Requestor' "
  '      Sql &= " end) as DCREmployeeRole, (case t_dcrr  "
  '      Sql &= " When '1' then 'DCR' "
  '      Sql &= " When '2' then 'PLM' "
  '      Sql &= " end) as DCREApplication from tdmisg101200 where t_dcrr=1  and t_emno in ('" & UserID & "','" & UserIDT & "') "
  '      Using Cmd As SqlCommand = Con.CreateCommand()
  '        Cmd.CommandType = CommandType.Text
  '        Cmd.CommandText = Sql
  '        Dim rd As SqlDataReader = Cmd.ExecuteReader
  '        While rd.Read
  '          mRet.Add(New SIS.DB.UserRoleDCR(rd))
  '        End While
  '      End Using
  '    End Using

  '    Return mRet
  '  End Function
  '  Public Sub New(ByVal Reader As SqlDataReader)
  '    Try
  '      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
  '        If pi.MemberType = Reflection.MemberTypes.Property Then
  '          Try
  '            Dim Found As Boolean = False
  '            For I As Integer = 0 To Reader.FieldCount - 1
  '              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
  '                Found = True
  '                Exit For
  '              End If
  '            Next
  '            If Found Then
  '              If Convert.IsDBNull(Reader(pi.Name)) Then
  '                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
  '                  Case "decimal"
  '                    CallByName(Me, pi.Name, CallType.Let, "0.00")
  '                  Case "bit"
  '                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
  '                  Case Else
  '                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
  '                End Select
  '              Else
  '                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
  '              End If
  '            End If
  '          Catch ex As Exception
  '          End Try
  '        End If
  '      Next
  '    Catch ex As Exception
  '    End Try
  '  End Sub
  '  Public Sub New()
  '  End Sub
  'End Class

  'Public Class UserRoleIDMS
  '  Public Property EDivision As String = ""
  '  Public Property EDepartment As String = ""

  '  Public Shared Function GetUserRoleIDMS(ByVal UserID As String) As List(Of SIS.DB.UserRoleIDMS)
  '    UserID = HttpContext.Current.Session("LoginID")

  '    Dim UserIDT As Integer = 0
  '    Try
  '      UserIDT = Convert.ToInt32(UserID)
  '    Catch ex As Exception

  '    End Try
  '    Dim mRet As New List(Of SIS.DB.UserRoleIDMS)
  '    Dim Sql As String = ""
  '    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
  '      Con.Open()
  '      Sql = " select (case t_eunt "
  '      Sql &= " when 'EU200' then 'BOILER' "
  '      Sql &= " when 'EU210' then 'EPC' "
  '      Sql &= " when 'EU220' then 'PC' "
  '      Sql &= " when 'EU230' then 'SMD' "
  '      Sql &= " when 'EU240' then 'APC' "
  '      Sql &= " when 'EU250' then 'ISGEC Wet FGD Business' "
  '      Sql &= " When 'EU290' then 'ISGEC R&D' "
  '      Sql &= " when 'EU400' then 'ISGEC HO' "
  '      Sql &= " When 'EU650' then 'Isgec Covema Ltd.' "
  '      Sql &= " end) as EDivision,(case t_dept  "
  '      Sql &= " when 'ELE' then 'Electrical' "
  '      Sql &= " when 'MEC' then 'Mechanical' "
  '      Sql &= " when 'MHE' then 'Material Handling Equipment' "
  '      Sql &= " when 'OTR' then 'Other' "
  '      Sql &= " when 'PEM' then 'Project Engineering Management' "
  '      Sql &= " when 'PIP' then 'Piping' "
  '      Sql &= " When 'PRC' then 'Process' "
  '      Sql &= " when 'PRJ' then 'Projects' "
  '      Sql &= " When 'QLY' then 'Quality' "
  '      Sql &= " When 'STR' then 'Structure' "
  '      Sql &= " When 'WWS' then 'Water & Waste Water Solution' "
  '      Sql &= " end)as EDepartment  from tdmisg130200 where t_logn in ('" & UserID & "','" & UserIDT & "') "



  '      Using Cmd As SqlCommand = Con.CreateCommand()
  '        Cmd.CommandType = CommandType.Text
  '        Cmd.CommandText = Sql
  '        Dim rd As SqlDataReader = Cmd.ExecuteReader
  '        While rd.Read
  '          mRet.Add(New SIS.DB.UserRoleIDMS(rd))
  '        End While
  '      End Using
  '    End Using

  '    Return mRet
  '  End Function
  '  Public Sub New(ByVal Reader As SqlDataReader)
  '    Try
  '      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
  '        If pi.MemberType = Reflection.MemberTypes.Property Then
  '          Try
  '            Dim Found As Boolean = False
  '            For I As Integer = 0 To Reader.FieldCount - 1
  '              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
  '                Found = True
  '                Exit For
  '              End If
  '            Next
  '            If Found Then
  '              If Convert.IsDBNull(Reader(pi.Name)) Then
  '                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
  '                  Case "decimal"
  '                    CallByName(Me, pi.Name, CallType.Let, "0.00")
  '                  Case "bit"
  '                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
  '                  Case Else
  '                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
  '                End Select
  '              Else
  '                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
  '              End If
  '            End If
  '          Catch ex As Exception
  '          End Try
  '        End If
  '      Next
  '    Catch ex As Exception
  '    End Try
  '  End Sub
  '  Public Sub New()
  '  End Sub
  'End Class

  'Public Class UserRoleTRANS
  '  Public Property TRANSEDivision As String = ""
  '  Public Property TRANSProject As String = ""
  '  Public Property TransmittalType As String = ""

  '  Public Shared Function GetUserRoleTRANS(ByVal UserID As String) As List(Of SIS.DB.UserRoleTRANS)
  '    UserID = HttpContext.Current.Session("LoginID")

  '    Dim UserIDT As Integer = 0
  '    Try
  '      UserIDT = Convert.ToInt32(UserID)
  '    Catch ex As Exception

  '    End Try
  '    Dim mRet As New List(Of SIS.DB.UserRoleTRANS)
  '    Dim Sql As String = ""
  '    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
  '      Con.Open()
  '      Sql = " select (case t_eunt "
  '      Sql &= " when 'EU200' then 'BOILER' "
  '      Sql &= " when 'EU210' then 'EPC' "
  '      Sql &= " when 'EU220' then 'PC' "
  '      Sql &= " when 'EU230' then 'SMD' "
  '      Sql &= " when 'EU240' then 'APC' "
  '      Sql &= " when 'EU250' then 'ISGEC Wet FGD Business' "
  '      Sql &= " When 'EU290' then 'ISGEC R&D' "
  '      Sql &= " when 'EU400' then 'ISGEC HO' "
  '      Sql &= " When 'EU650' then 'Isgec Covema Ltd.' "
  '      Sql &= " end) as TRANSEDivision,t_cprj as TRANSProject,(case t_tran "
  '      Sql &= " when 1 then 'Customer' "
  '      Sql &= " when 2 then 'Internal' "
  '      Sql &= " when 3 then 'Site' "
  '      Sql &= " when 4 then 'Vendor' "
  '      Sql &= " end) as TransmittalType from tdmisg129200  "
  '      Sql &= " where t_logn in ('" & UserID & "','" & UserIDT & "') "

  '      Using Cmd As SqlCommand = Con.CreateCommand()
  '        Cmd.CommandType = CommandType.Text
  '        Cmd.CommandText = Sql
  '        Dim rd As SqlDataReader = Cmd.ExecuteReader
  '        While rd.Read
  '          mRet.Add(New SIS.DB.UserRoleTRANS(rd))
  '        End While
  '      End Using
  '    End Using

  '    Return mRet
  '  End Function
  '  Public Sub New(ByVal Reader As SqlDataReader)
  '    Try
  '      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
  '        If pi.MemberType = Reflection.MemberTypes.Property Then
  '          Try
  '            Dim Found As Boolean = False
  '            For I As Integer = 0 To Reader.FieldCount - 1
  '              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
  '                Found = True
  '                Exit For
  '              End If
  '            Next
  '            If Found Then
  '              If Convert.IsDBNull(Reader(pi.Name)) Then
  '                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
  '                  Case "decimal"
  '                    CallByName(Me, pi.Name, CallType.Let, "0.00")
  '                  Case "bit"
  '                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
  '                  Case Else
  '                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
  '                End Select
  '              Else
  '                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
  '              End If
  '            End If
  '          Catch ex As Exception
  '          End Try
  '        End If
  '      Next
  '    Catch ex As Exception
  '    End Try
  '  End Sub
  '  Public Sub New()
  '  End Sub
  'End Class


End Namespace
