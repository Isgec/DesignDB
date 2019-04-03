Namespace SIS.SYS
	Public MustInherit Class ReportBase
		Private _Context As HttpContext = Nothing
		Private _RQ As HttpRequest = Nothing
		Private _RS As HttpResponse = Nothing
		MustOverride Sub ProcessReport()
		Private _FlushFrequency As Integer = 10
		Private _Counter As Integer = 1
		Public Property FlushFrequency() As Integer
			Get
				Return _FlushFrequency
			End Get
			Set(ByVal value As Integer)
				_FlushFrequency = value
			End Set
		End Property
		Public Sub Print(ByVal pStr As String)
			_RS.Write(pStr)
			_Counter += 1
			If _Counter >= _FlushFrequency Then
				_RS.Flush()
				_Counter = 1
			End If
		End Sub
		Private Sub StartReport()
			With _RS
				.Clear()
				.Buffer = True
				.BufferOutput = True
				.StatusCode = 206

				.Write("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">")
				.Write("<html  xmlns=""http://www.w3.org/1999/xhtml"">")
				.Write("<head>")
        .Write("<title>EH: Report")
				.Write("</title>")
				.Write("<style>")
				.Write("table")
				.Write("{")
				.Write("border: 0px;")
				.Write("border-right: 0px;")
				.Write("border-left: 0px;")
				.Write("border-top: 0px;")
				.Write("border-bottom: 0px;")
				.Write("border-collapse: collapse;")
				.Write("}")
				.Write("td")
				.Write("{")
				.Write("font-size: 8pt;")
				.Write("padding-left: 2px;")
				.Write("padding-right: 2px;")
				.Write("font-family: Verdana, Arial;")
				.Write("}")
				.Write("</style>")
				.Write("</head>")
				.Write("<body style=""font-family: Verdana"">")

				.Flush()
			End With
		End Sub
		Private Sub StartXLReport()
			With _RS
				.Clear()
				.Buffer = True
				.BufferOutput = True
				.StatusCode = 206
				.ContentType = "application/vnd.ms-excel"
				'.AddHeader("Content-Disposition", "attachment;filename=Report.xls")

				.Write("<?xml version=""1.0"" encoding=""ISO-8859-1""?>")
				.Write("<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">")
				.Write("<xsl:template match=""/"">")
				.Write("<html xmlns:x=""urn:schemas-microsoft-com:office:excel"">")
				.Write("<head>")
        .Write("<title>EH: Report")
				.Write("</title>")
				.Write("<style>")
				.Write("table")
				.Write("{")
				.Write("border: 0px;")
				.Write("border-right: 0px;")
				.Write("border-left: 0px;")
				.Write("border-top: 0px;")
				.Write("border-bottom: 0px;")
				.Write("border-collapse: collapse;")
				.Write("}")
				.Write("td")
				.Write("{")
				.Write("font-size: 8pt;")
				.Write("padding-left: 2px;")
				.Write("padding-right: 2px;")
				.Write("font-family: Verdana, Arial;")
				.Write("}")
				.Write("</style>")
				.Write("</head>")
				.Write("<body style=""font-family: Verdana"">")

				.Flush()
			End With
		End Sub
		Private Sub CloseReport()
			With _RS
				.Flush()
				.Write("<br />")
				.Write("<br />")
				.Write("<input id=""cmdrptprn"" type=""button"" onclick=""this.style.display='none';window.print();"" value=""Print""></input>")
				.Write("</body>")
				.Write("</html>")
				.Flush()
				.End()
			End With
		End Sub
		Private Sub CloseXLReport()
			With _RS
				.Flush()
				.Write("<br />")
				.Write("<br />")
				.Write("</body>")
				.Write("</html>")
				.Flush()
				.End()
			End With
		End Sub
		Sub GenerateReport()
			StartReport()
			ProcessReport()
			CloseReport()
		End Sub
		Sub GenerateReport(ByVal XL As Boolean)
			StartXLReport()
			ProcessReport()
			CloseXLReport()
		End Sub
		Public Property Response() As HttpResponse
			Get
				Return _RS
			End Get
			Set(ByVal value As HttpResponse)
				_RS = value
			End Set
		End Property
		Public Property Request() As HttpRequest
			Get
				Return _RQ
			End Get
			Set(ByVal value As HttpRequest)
				_RQ = value
			End Set
		End Property
		Public Property SetContext() As HttpContext
			Get
				Return _Context
			End Get
			Set(ByVal value As HttpContext)
				_Context = value
				_RQ = value.Request
				_RS = value.Response
			End Set
		End Property
		Public Sub New()
			'Dummy
		End Sub
	End Class
End Namespace
