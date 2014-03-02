Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared

Imports CrystalDecisions.ReportSource



Imports System.Collections


Public Class Formcortediario




    Dim connectionCompanies, connectionProducts, connectionClients, connectionStates, connectionHeaders, connectionRows As SqlConnection
    Dim commandProducts, commandClients, commandStates, commandHeaders, commandRows As SqlCommand
    Dim queryStringProducts, queryStringClients, queryStringStates, queryStringHeaders, queryStringRows As String
    Dim adapterProducts, adapterClients, adapterStates, adapterHeaders, adapterRows As SqlDataAdapter
    Public cmdBuilderProducts, cmdBuilderClients, cmdBuilderStates, cmdBuilderHeaders, cmdBuilderRows As SqlCommandBuilder
    Public products, companies, clients, states, headers, rows As DataSet
    Dim PermanentDB1, invoiceHeaders, invoiceRows, productsKardex, productsCatalog, receiptHeaders, receiptRows, DataSetReceipt As DataSet
    Private receiptForm As CrystalReportCorte
    Private Sub frmRemisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim descripcion1 As New ParameterField()
            'Dim descripcion2 As New ParameterField()
            'Dim descripcion3 As New ParameterField()
            'Dim descripcion4 As New ParameterField()
            'Dim descripcion5 As New ParameterField()
            'Dim descripcion6 As New ParameterField()
            'Dim descripcion7 As New ParameterField()


            'Dim importe1 As New ParameterField()
            'Dim importe2 As New ParameterField()
            'Dim importe3 As New ParameterField()
            'Dim importe4 As New ParameterField()
            'Dim importe5 As New ParameterField()
            'Dim importe6 As New ParameterField()
            'Dim importe7 As New ParameterField()
            'Dim descuento As New ParameterField()
            'Dim anticipo As New ParameterField()
            'Dim adeudo As New ParameterField()








            descripcion1.ParameterFieldName = "usuario"
            'descripcion2.ParameterFieldName = "descripcion2"
            'descripcion3.ParameterFieldName = "descripcion3"
            'descripcion4.ParameterFieldName = "descripcion4"
            'descripcion5.ParameterFieldName = "descripcion5"
            'descripcion6.ParameterFieldName = "descripcion6"
            'descripcion7.ParameterFieldName = "descripcion7"

            'importe1.ParameterFieldName = "importe1"
            'importe2.ParameterFieldName = "importe2"
            'importe3.ParameterFieldName = "importe3"
            'importe4.ParameterFieldName = "importe4"
            'importe5.ParameterFieldName = "importe5"
            'importe6.ParameterFieldName = "importe6"
            'importe7.ParameterFieldName = "importe7"
            'descuento.ParameterFieldName = "descuento"
            'anticipo.ParameterFieldName = "anticipo"
            'adeudo.ParameterFieldName = "adeudo"


            Dim discreteValuedescripcion1 As New ParameterDiscreteValue()
            'Dim discreteValuedescripcion2 As New ParameterDiscreteValue()
            'Dim discreteValuedescripcion3 As New ParameterDiscreteValue()
            'Dim discreteValuedescripcion4 As New ParameterDiscreteValue()
            'Dim discreteValuedescripcion5 As New ParameterDiscreteValue()
            'Dim discreteValuedescripcion6 As New ParameterDiscreteValue()
            'Dim discreteValuedescripcion7 As New ParameterDiscreteValue()


            'Dim discreteValueimporte1 As New ParameterDiscreteValue()
            'Dim discreteValueimporte2 As New ParameterDiscreteValue()
            'Dim discreteValueimporte3 As New ParameterDiscreteValue()
            'Dim discreteValueimporte4 As New ParameterDiscreteValue()
            'Dim discreteValueimporte5 As New ParameterDiscreteValue()
            'Dim discreteValueimporte6 As New ParameterDiscreteValue()
            'Dim discreteValueimporte7 As New ParameterDiscreteValue()
            'Dim discreteValuedescuento As New ParameterDiscreteValue()

            'Dim discreteValueanticipo As New ParameterDiscreteValue()
            'Dim discreteValueadeudo As New ParameterDiscreteValue()







            discreteValuedescripcion1.Value = PRINCIPAL.ToolStripStatusUsuario.Text

           



      



            descripcion1.CurrentValues.Add(discreteValuedescripcion1)
            'descripcion2.CurrentValues.Add(discreteValuedescripcion2)
            'descripcion3.CurrentValues.Add(discreteValuedescripcion3)
            'descripcion4.CurrentValues.Add(discreteValuedescripcion4)
            'descripcion5.CurrentValues.Add(discreteValuedescripcion5)
            'descripcion6.CurrentValues.Add(discreteValuedescripcion6)
            'descripcion7.CurrentValues.Add(discreteValuedescripcion7)




            'importe1.CurrentValues.Add(discreteValueimporte1)
            'importe2.CurrentValues.Add(discreteValueimporte2)
            'importe3.CurrentValues.Add(discreteValueimporte3)
            'importe4.CurrentValues.Add(discreteValueimporte4)
            'importe5.CurrentValues.Add(discreteValueimporte5)
            'importe6.CurrentValues.Add(discreteValueimporte6)
            'importe7.CurrentValues.Add(discreteValueimporte7)
            'descuento.CurrentValues.Add(discreteValuedescuento)
            'anticipo.CurrentValues.Add(discreteValueanticipo)
            'adeudo.CurrentValues.Add(discreteValueadeudo)


            Dim paramFiels As New ParameterFields()

            paramFiels.Add(descripcion1)
            'paramFiels.Add(descripcion2)
            'paramFiels.Add(descripcion3)
            'paramFiels.Add(descripcion4)
            'paramFiels.Add(descripcion5)
            'paramFiels.Add(descripcion6)
            'paramFiels.Add(descripcion7)

            'paramFiels.Add(importe1)
            'paramFiels.Add(importe2)
            'paramFiels.Add(importe3)
            'paramFiels.Add(importe4)
            'paramFiels.Add(importe5)
            'paramFiels.Add(importe6)
            'paramFiels.Add(importe7)
            'paramFiels.Add(descuento)
            'paramFiels.Add(anticipo)
            'paramFiels.Add(adeudo)



            CrystalReportViewercortediario.ParameterFieldInfo = paramFiels

            populateReport()
            CrystalReportViewercortediario.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

    End Sub
    Private Sub ConfigureCrystalReports()
        receiptForm = New CrystalReportCorte()
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = "LAPROVIDENCIA"
        myConnectionInfo.UserID = "sa"
        myConnectionInfo.Password = "$d4m4s0"

        CrystalReportViewercortediario.ReportSource = receiptForm
        SetDBLogonForReport(myConnectionInfo)

        CrystalReportViewercortediario.Visible = True
    End Sub
    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo)
        Dim myTableLogOnInfos As TableLogOnInfos = CrystalReportViewercortediario.LogOnInfo
        For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
            myTableLogOnInfo.ConnectionInfo = myConnectionInfo
        Next
    End Sub
    Private Sub populateReport()
        Dim s, temp, idDoctores As String
        's = Recibo.TxtFolio.Text
        'temp = Recibo.TxtClienteID.Text
        'idDoctores = Recibo.ComboBoxDoctores.Text.Substring(0, 6)
        Dim dsreceipt As New DataSet
        dsreceipt.EnforceConstraints = False
        companies = New DataSet()
        queryStringCompanies = "select * from cortediario where companyID= '" & currentCompany & "'"
        connectionCompanies = New SqlConnection(connectionString)
        connectionCompanies.Open()
        adapterCompanies = New SqlDataAdapter
        commandCompanies = New SqlCommand(queryStringCompanies, connectionCompanies)
        adapterCompanies.SelectCommand = commandCompanies
        cmdBuilderCompanies = New SqlCommandBuilder(adapterCompanies)
        cmdBuilderCompanies.ConflictOption = ConflictOption.OverwriteChanges
        adapterCompanies.Fill(dsreceipt, "cortediario")

       

        Try
            receiptForm = New CrystalReportCorte
            receiptForm.SetDataSource(dsreceipt)
            CrystalReportViewercortediario.ReportSource = receiptForm
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class