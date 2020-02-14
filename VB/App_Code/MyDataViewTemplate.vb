﻿Option Infer On

Imports DevExpress.Web
Imports System.Web.UI

Public Class MyDataViewTemplate
	Implements ITemplate

	Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
		Dim dataViewContainer = TryCast(container, DataViewItemTemplateContainer)
		container.Controls.Add(GetFormLayout(dataViewContainer.DataItem))
	End Sub
	Private Function GetFormLayout(ByVal dataItem As Object) As ASPxFormLayout
		Dim formLayout = New ASPxFormLayout()
		Dim layoutGroup As LayoutGroup = TryCast(formLayout.Items.Add(New LayoutGroup("Item Info")), LayoutGroup)
		Dim layoutItemName = New LayoutItem("Name")
		layoutItemName.Controls.Add(New ASPxLabel() With {.Text = GetData(dataItem, "Name")})
		Dim layoutItemDecsription = New LayoutItem("Description")
		layoutItemDecsription.Controls.Add(New ASPxLabel() With {.Text = GetData(dataItem, "Description")})
		layoutGroup.Items.Add(layoutItemName)
		layoutGroup.Items.Add(layoutItemDecsription)
		Return formLayout
	End Function
	Private Function GetData(ByVal dataObject As Object, ByVal fieldName As String) As String
		Return DataBinder.Eval(dataObject, fieldName).ToString()
	End Function
End Class