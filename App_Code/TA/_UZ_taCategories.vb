Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taCategories
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_taCategoriesInsert(ByVal Record As SIS.TA.taCategories) As SIS.TA.taCategories
      Dim _Result As SIS.TA.taCategories = taCategoriesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taCategoriesUpdate(ByVal Record As SIS.TA.taCategories) As SIS.TA.taCategories
      Dim _Result As SIS.TA.taCategories = taCategoriesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taCategoriesDelete(ByVal Record As SIS.TA.taCategories) As Integer
      Dim _Result as Integer = taCategoriesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_CategoryID"), TextBox).Text = ""
        'CType(.FindControl("F_CategoryCode"), TextBox).Text = ""
        'CType(.FindControl("F_CategoryDescription"), TextBox).Text = ""
        'CType(.FindControl("F_CategorySequence"), TextBox).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
