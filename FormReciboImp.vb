Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared

Imports CrystalDecisions.ReportSource



Imports System.Collections


Public Class FormReciboImp




    Dim connectionCompanies, connectionProducts, connectionClients, connectionStates, connectionHeaders, connectionRows As SqlConnection
    Dim commandProducts, commandClients, commandStates, commandHeaders, commandRows As SqlCommand
    Dim queryStringProducts, queryStringClients, queryStringStates, queryStringHeaders, queryStringRows As String
    Dim adapterProducts, adapterClients, adapterStates, adapterHeaders, adapterRows As SqlDataAdapter
    Public cmdBuilderProducts, cmdBuilderClients, cmdBuilderStates, cmdBuilderHeaders, cmdBuilderRows As SqlCommandBuilder
    Public products, companies, clients, states, headers, rows As DataSet
    Dim PermanentDB1, invoiceHeaders, invoiceRows, productsKardex, productsCatalog, receiptHeaders, receiptRows, DataSetReceipt As DataSet
    Private receiptForm As CrystalReportRecibo
    Private Sub frmRemisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estsatemp As String
        Try

            Dim descripcion1 As New ParameterField()
            Dim descripcion2 As New ParameterField()
            Dim descripcion3 As New ParameterField()
            Dim descripcion4 As New ParameterField()
            Dim descripcion5 As New ParameterField()
            Dim descripcion6 As New ParameterField()
            Dim descripcion7 As New ParameterField()


            Dim importe1 As New ParameterField()
            Dim importe2 As New ParameterField()
            Dim importe3 As New ParameterField()
            Dim importe4 As New ParameterField()
            Dim importe5 As New ParameterField()
            Dim importe6 As New ParameterField()
            Dim importe7 As New ParameterField()
            Dim descuento As New ParameterField()
            Dim anticipo As New ParameterField()
            Dim adeudo As New ParameterField()
            Dim foliointerno As New ParameterField()
            Dim estadorecibo As New ParameterField()








            descripcion1.ParameterFieldName = "descripcion1"
            descripcion2.ParameterFieldName = "descripcion2"
            descripcion3.ParameterFieldName = "descripcion3"
            descripcion4.ParameterFieldName = "descripcion4"
            descripcion5.ParameterFieldName = "descripcion5"
            descripcion6.ParameterFieldName = "descripcion6"
            descripcion7.ParameterFieldName = "descripcion7"

            importe1.ParameterFieldName = "importe1"
            importe2.ParameterFieldName = "importe2"
            importe3.ParameterFieldName = "importe3"
            importe4.ParameterFieldName = "importe4"
            importe5.ParameterFieldName = "importe5"
            importe6.ParameterFieldName = "importe6"
            importe7.ParameterFieldName = "importe7"
            descuento.ParameterFieldName = "descuento"
            anticipo.ParameterFieldName = "anticipo"
            adeudo.ParameterFieldName = "adeudo"
            foliointerno.ParameterFieldName = "foliointerno"
            estadorecibo.ParameterFieldName = "estadorecibo"


            Dim discreteValuedescripcion1 As New ParameterDiscreteValue()
            Dim discreteValuedescripcion2 As New ParameterDiscreteValue()
            Dim discreteValuedescripcion3 As New ParameterDiscreteValue()
            Dim discreteValuedescripcion4 As New ParameterDiscreteValue()
            Dim discreteValuedescripcion5 As New ParameterDiscreteValue()
            Dim discreteValuedescripcion6 As New ParameterDiscreteValue()
            Dim discreteValuedescripcion7 As New ParameterDiscreteValue()


            Dim discreteValueimporte1 As New ParameterDiscreteValue()
            Dim discreteValueimporte2 As New ParameterDiscreteValue()
            Dim discreteValueimporte3 As New ParameterDiscreteValue()
            Dim discreteValueimporte4 As New ParameterDiscreteValue()
            Dim discreteValueimporte5 As New ParameterDiscreteValue()
            Dim discreteValueimporte6 As New ParameterDiscreteValue()
            Dim discreteValueimporte7 As New ParameterDiscreteValue()
            Dim discreteValuedescuento As New ParameterDiscreteValue()

            Dim discreteValueanticipo As New ParameterDiscreteValue()
            Dim discreteValueadeudo As New ParameterDiscreteValue()

            Dim discreteValuefoliointerno As New ParameterDiscreteValue()
            Dim discreteValueestadorecibo As New ParameterDiscreteValue()





            If Recibo.DataGridView1.Rows(0).Cells("descripcion").Value = "" Then
                discreteValuedescripcion1.Value = ""
            Else

                discreteValuedescripcion1.Value = Recibo.DataGridView1.Rows(0).Cells("descripcion").Value
            End If

            If Recibo.DataGridView1.Rows(1).Cells("descripcion").Value = "" Then

                discreteValuedescripcion2.Value = ""
            Else
                discreteValuedescripcion2.Value = Recibo.DataGridView1.Rows(1).Cells("descripcion").Value
            End If

            If Recibo.DataGridView1.Rows(2).Cells("descripcion").Value = "" Then

                discreteValuedescripcion3.Value = ""
            Else
                discreteValuedescripcion3.Value = Recibo.DataGridView1.Rows(2).Cells("descripcion").Value
            End If

            If Recibo.DataGridView1.Rows(3).Cells("descripcion").Value = "" Then

                discreteValuedescripcion4.Value = ""
            Else
                discreteValuedescripcion4.Value = Recibo.DataGridView1.Rows(3).Cells("descripcion").Value
            End If

            If Recibo.DataGridView1.Rows(4).Cells("descripcion").Value = "" Then

                discreteValuedescripcion5.Value = ""
            Else
                discreteValuedescripcion5.Value = Recibo.DataGridView1.Rows(4).Cells("descripcion").Value
            End If

            If Recibo.DataGridView1.Rows(5).Cells("descripcion").Value = "" Then

                discreteValuedescripcion6.Value = ""
            Else
                discreteValuedescripcion6.Value = Recibo.DataGridView1.Rows(5).Cells("descripcion").Value
            End If

            If Recibo.DataGridView1.Rows(6).Cells("descripcion").Value = "" Then

                discreteValuedescripcion7.Value = ""
            Else
                discreteValuedescripcion7.Value = Recibo.DataGridView1.Rows(6).Cells("descripcion").Value
            End If



            'discreteValuedescripcion3.Value = Recibo.DataGridView1.Rows(2).Cells("descripcion").Value
            'discreteValuedescripcion4.Value = Recibo.DataGridView1.Rows(3).Cells("descripcion").Value
            ' discreteValuedescripcion5.Value = Recibo.DataGridView1.Rows(4).Cells("descripcion").Value
            'discreteValuedescripcion6.Value = Recibo.DataGridView1.Rows(5).Cells("descripcion").Value
            '  discreteValuedescripcion7.Value = Recibo.DataGridView1.Rows(6).Cells("descripcion").Value

            If Recibo.DataGridView1.Rows(0).Cells("importe").Value = "" Then
                discreteValueimporte1.Value = ""
            Else
                discreteValueimporte1.Value = Recibo.DataGridView1.Rows(0).Cells("importe").Value
            End If

            If Recibo.DataGridView1.Rows(1).Cells("importe").Value = "" Then
                discreteValueimporte2.Value = ""
            Else
                discreteValueimporte2.Value = Recibo.DataGridView1.Rows(1).Cells("importe").Value
            End If

            If Recibo.DataGridView1.Rows(2).Cells("importe").Value = "" Then
                discreteValueimporte3.Value = ""
            Else
                discreteValueimporte3.Value = Recibo.DataGridView1.Rows(2).Cells("importe").Value
            End If

            If Recibo.DataGridView1.Rows(3).Cells("importe").Value = "" Then
                discreteValueimporte4.Value = ""
            Else
                discreteValueimporte4.Value = Recibo.DataGridView1.Rows(3).Cells("importe").Value
            End If

            If Recibo.DataGridView1.Rows(4).Cells("importe").Value = "" Then
                discreteValueimporte5.Value = ""
            Else
                discreteValueimporte5.Value = Recibo.DataGridView1.Rows(4).Cells("importe").Value
            End If


            If Recibo.DataGridView1.Rows(5).Cells("importe").Value = "" Then
                discreteValueimporte6.Value = ""
            Else
                discreteValueimporte6.Value = Recibo.DataGridView1.Rows(5).Cells("importe").Value
            End If

            If Recibo.DataGridView1.Rows(6).Cells("importe").Value = "" Then
                discreteValueimporte7.Value = ""
            Else
                discreteValueimporte7.Value = Recibo.DataGridView1.Rows(6).Cells("importe").Value
            End If


            discreteValueanticipo.Value = Recibo.txtAdeudo.Text
            discreteValueadeudo.Value = Recibo.txtAnticipo.Text

            'AQUI VAMOS A COMPROBAR SI EL RECIBO ESTA PAGADO========================================================
            estsatemp = Recibo.txtAdeudo.Text
            If Recibo.txtAdeudo.Text = " " Then

                discreteValueestadorecibo.Value = "RECIBO LIQUIDADO..."
            Else
                discreteValueestadorecibo.Value = " "

            End If



            'discreteValueimporte1.Value = Recibo.DataGridView1.Rows(0).Cells("importe").Value


            discreteValuedescuento.Value = Recibo.TxtDescuento.Text
            discreteValuefoliointerno.Value = Recibo.txtFolioInterno.Text


            descripcion1.CurrentValues.Add(discreteValuedescripcion1)
            descripcion2.CurrentValues.Add(discreteValuedescripcion2)
            descripcion3.CurrentValues.Add(discreteValuedescripcion3)
            descripcion4.CurrentValues.Add(discreteValuedescripcion4)
            descripcion5.CurrentValues.Add(discreteValuedescripcion5)
            descripcion6.CurrentValues.Add(discreteValuedescripcion6)
            descripcion7.CurrentValues.Add(discreteValuedescripcion7)




            importe1.CurrentValues.Add(discreteValueimporte1)
            importe2.CurrentValues.Add(discreteValueimporte2)
            importe3.CurrentValues.Add(discreteValueimporte3)
            importe4.CurrentValues.Add(discreteValueimporte4)
            importe5.CurrentValues.Add(discreteValueimporte5)
            importe6.CurrentValues.Add(discreteValueimporte6)
            importe7.CurrentValues.Add(discreteValueimporte7)
            descuento.CurrentValues.Add(discreteValuedescuento)
            anticipo.CurrentValues.Add(discreteValueanticipo)
            adeudo.CurrentValues.Add(discreteValueadeudo)
            foliointerno.CurrentValues.Add(discreteValuefoliointerno)
            estadorecibo.CurrentValues.Add(discreteValueestadorecibo)

            Dim paramFiels As New ParameterFields()

            paramFiels.Add(descripcion1)
            paramFiels.Add(descripcion2)
            paramFiels.Add(descripcion3)
            paramFiels.Add(descripcion4)
            paramFiels.Add(descripcion5)
            paramFiels.Add(descripcion6)
            paramFiels.Add(descripcion7)

            paramFiels.Add(importe1)
            paramFiels.Add(importe2)
            paramFiels.Add(importe3)
            paramFiels.Add(importe4)
            paramFiels.Add(importe5)
            paramFiels.Add(importe6)
            paramFiels.Add(importe7)
            paramFiels.Add(descuento)
            paramFiels.Add(anticipo)
            paramFiels.Add(adeudo)
            paramFiels.Add(foliointerno)
            paramFiels.Add(estadorecibo)

            CrystalReportViewerRecibo.ParameterFieldInfo = paramFiels

            populateReport()
            CrystalReportViewerRecibo.Visible = True
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

    End Sub
    Private Sub ConfigureCrystalReports()
        receiptForm = New CrystalReportRecibo()
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = "LAPROVIDENCIA"
        myConnectionInfo.UserID = "sa"
        myConnectionInfo.Password = "$d4m4s0"

        CrystalReportViewerRecibo.ReportSource = receiptForm
        SetDBLogonForReport(myConnectionInfo)

        CrystalReportViewerRecibo.Visible = True
    End Sub
    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo)
        Dim myTableLogOnInfos As TableLogOnInfos = CrystalReportViewerRecibo.LogOnInfo
        For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
            myTableLogOnInfo.ConnectionInfo = myConnectionInfo
        Next
    End Sub
    Private Sub populateReport()
        Dim s, temp, idDoctores As String
        s = Recibo.TxtFolio.Text
        temp = Recibo.TxtClienteID.Text
        idDoctores = Recibo.ComboBoxDoctores.Text.Substring(0, 6)
        Dim dsreceipt As New DataSet
        dsreceipt.EnforceConstraints = False
        companies = New DataSet()
        queryStringCompanies = "select * from companies where companyID= '" & currentCompany & "'"
        connectionCompanies = New SqlConnection(connectionString)
        connectionCompanies.Open()
        adapterCompanies = New SqlDataAdapter
        commandCompanies = New SqlCommand(queryStringCompanies, connectionCompanies)
        adapterCompanies.SelectCommand = commandCompanies
        cmdBuilderCompanies = New SqlCommandBuilder(adapterCompanies)
        cmdBuilderCompanies.ConflictOption = ConflictOption.OverwriteChanges
        adapterCompanies.Fill(dsreceipt, "companies")

        headers = New DataSet()
        queryStringHeaders = "select * from recibo where idRecibo= '" & s & "' and companyID='" & currentCompany & "'"
        connectionHeaders = New SqlConnection(connectionString)
        connectionHeaders.Open()
        adapterHeaders = New SqlDataAdapter
        commandHeaders = New SqlCommand(queryStringHeaders, connectionHeaders)
        adapterHeaders.SelectCommand = commandHeaders
        cmdBuilderHeaders = New SqlCommandBuilder(adapterHeaders)
        cmdBuilderHeaders.ConflictOption = ConflictOption.OverwriteChanges
        adapterHeaders.Fill(dsreceipt, "recibo")


        states = New DataSet()
        queryStringStates = "select * from doctores where IdDoctor= '" & idDoctores & "'"
        connectionStates = New SqlConnection(connectionString)
        connectionStates.Open()
        adapterStates = New SqlDataAdapter
        commandStates = New SqlCommand(queryStringStates, connectionStates)
        adapterStates.SelectCommand = commandStates
        cmdBuilderStates = New SqlCommandBuilder(adapterStates)
        cmdBuilderStates.ConflictOption = ConflictOption.OverwriteChanges
        adapterStates.Fill(dsreceipt, "doctores")


        clients = New DataSet()

        queryStringClients = "select * from clients where clientID= '" & temp & "' and companyID='" & currentCompany & "'"
        connectionClients = New SqlConnection(connectionString)
        connectionClients.Open()
        adapterClients = New SqlDataAdapter
        commandClients = New SqlCommand(queryStringClients, connectionClients)
        adapterClients.SelectCommand = commandClients
        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
        adapterClients.Fill(dsreceipt, "clients")

      

        'rows = New DataSet()
        'queryStringRows = "select * from renglonesRemision where folio= '" & s & "' and companyID='" & currentCompany & "'"
        'connectionRows = New SqlConnection(connectionString)
        'connectionRows.Open()
        'adapterRows = New SqlDataAdapter
        'commandRows = New SqlCommand(queryStringRows, connectionRows)
        'adapterRows.SelectCommand = commandRows
        'cmdBuilderRows = New SqlCommandBuilder(adapterRows)
        'cmdBuilderRows.ConflictOption = ConflictOption.OverwriteChanges
        'adapterRows.Fill(dsreceipt, "renglonesRemision")


        Try
            receiptForm = New CrystalReportRecibo
            receiptForm.SetDataSource(dsreceipt)
            CrystalReportViewerRecibo.ReportSource = receiptForm
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class