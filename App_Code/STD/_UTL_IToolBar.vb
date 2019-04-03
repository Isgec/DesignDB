Imports Microsoft.VisualBasic
Imports System.Web.Script.Serialization
Public MustInherit Class ToolBar0
	Inherits System.Web.UI.UserControl
	Public MustOverride Property CurrentPage() As Integer
	Public MustOverride Property TotalPages() As Integer
	Public MustOverride Property RecordsPerPage() As Integer
	Public MustOverride Property AfterInsertURL() As String
	Public MustOverride Property AfterUpdateURL() As String
	Public MustOverride Property InsertAndStay() As Boolean
	Public MustOverride Property UpdateAndStay() As Boolean
  Public MustOverride Property SearchValidationGroup As String


	Public Event PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
	Public Event SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
	Public Event SaveClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
	Public Event DeleteClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
	Public Event AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
	Public Event CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
	Public Sub RaisePageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
		RaiseEvent PageChanged(NewPageNo, PageSize)
	End Sub
	Public Sub RaiseSearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
		RaiseEvent SearchClicked(SearchText, SearchState)
	End Sub
  Public Sub RaiseSaveClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    RaiseEvent SaveClicked(sender, e)
  End Sub
  Public Sub RaiseDeleteClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		RaiseEvent DeleteClicked(sender, e)
	End Sub
	Public Sub RaiseAddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		RaiseEvent AddClicked(sender, e)
	End Sub
	Public Sub RaiseCancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		RaiseEvent CancelClicked(sender, e)
	End Sub
End Class

Public MustInherit Class IpsBar
  Inherits System.Web.UI.UserControl
  Public MustOverride Property CurrentPage() As Integer
  Public MustOverride Property TotalPages() As Integer
  Public MustOverride Property RecordsPerPage() As Integer


  Public Event PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
  Public Event SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
  Public Sub RaisePageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
    RaiseEvent PageChanged(NewPageNo, PageSize)
  End Sub
  Public Sub RaiseSearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
    RaiseEvent SearchClicked(SearchText, SearchState)
  End Sub
End Class
Public MustInherit Class IattachBar
	Inherits System.Web.UI.UserControl
	Public MustOverride Property CurrentPage() As Integer
	Public MustOverride Property TotalPages() As Integer
	Public MustOverride Property RecordsPerPage() As Integer


	Public Event PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
	Public Event SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
	Public Sub RaisePageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
		RaiseEvent PageChanged(NewPageNo, PageSize)
	End Sub
	Public Sub RaiseSearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
		RaiseEvent SearchClicked(SearchText, SearchState)
	End Sub

End Class
