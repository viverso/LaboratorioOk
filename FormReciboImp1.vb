Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared

Imports CrystalDecisions.ReportSource



Imports System.Collections


Public Class FormReciboImp1




    Dim connectionCompanies, connectionProducts, connectionClients, connectionStates, connectionHeaders, connectionRows As SqlConnection
    Dim commandProducts, commandClients, commandStates, commandHeaders, commandRows As SqlCommand
    Dim queryStringProducts, queryStringClients, queryStringStates, queryStringHeaders, queryStringRows As String
    Dim adapterProducts, adapterClients, adapterStates, adapterHeaders, adapterRows As SqlDataAdapter
    Public cmdBuilderProducts, cmdBuilderClients, cmdBuilderStates, cmdBuilderHeaders, cmdBuilderRows As SqlCommandBuilder
    Public products, companies, clients, states, headers, rows As DataSet
    Dim PermanentDB1, invoiceHeaders, invoiceRows, productsKardex, productsCatalog, receiptHeaders, receiptRows, DataSetReceipt As DataSet
    Private receiptForm As CrystalReportRecibo1
    Private Sub frmRemisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estsatemp As String
        Try

            Dim paciente As New ParameterField()
            Dim medico As New ParameterField()
            Dim ciudad As New ParameterField()
            Dim telefono As New ParameterField()
            Dim rfc As New ParameterField()
            Dim registro As New ParameterField()
            Dim edad As New ParameterField()
            Dim fecha As New ParameterField()
            Dim sexo As New ParameterField()

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
            Dim total As New ParameterField()
            Dim observaciones As New ParameterField()

            paciente.ParameterFieldName = "paciente"
            medico.ParameterFieldName = "medico"
            ciudad.ParameterFieldName = "ciudad"
            telefono.ParameterFieldName = "telefono"
            rfc.ParameterFieldName = "rfc"
            registro.ParameterFieldName = "registro"
            edad.ParameterFieldName = "edad"
            fecha.ParameterFieldName = "fecha"
            sexo.ParameterFieldName = "sexo"



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
            total.ParameterFieldName = "total"
            observaciones.ParameterFieldName = "observaciones"

            Dim discreteValuepaciente As New ParameterDiscreteValue()
            Dim discreteValuemedico As New ParameterDiscreteValue()
            Dim discreteValueciudad As New ParameterDiscreteValue()
            Dim discreteValuetelefono As New ParameterDiscreteValue()
            Dim discreteValuerfc As New ParameterDiscreteValue()
            Dim discreteValueregistro As New ParameterDiscreteValue()
            Dim discreteValueedad As New ParameterDiscreteValue()
            Dim discreteValuefecha As New ParameterDiscreteValue()
            Dim discreteValuesexo As New ParameterDiscreteValue()


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
            Dim discreteValuetotal As New ParameterDiscreteValue()
            Dim discreteValueobservaciones As New ParameterDiscreteValue()





            If Recibo1.TextBoxNombre.Text = "" Then
                discreteValuepaciente.Value = " "
            Else
                discreteValuepaciente.Value = Recibo1.TextBoxNombre.Text
            End If

            discreteValuemedico.Value = Recibo1.ComboBoxDoctores.Text.Substring(0, Recibo1.ComboBoxDoctores.Text.Length - 6)
            discreteValueciudad.Value = Recibo1.TxtCiudad.Text
            discreteValuetelefono.Value = Recibo1.TxtTelefono.Text
            discreteValuerfc.Value = Recibo1.RCF.Text
            discreteValueregistro.Value = Recibo1.txtFolioInterno.Text
            discreteValueedad.Value = Recibo1.TxtEdad.Text
            discreteValuefecha.Value = Recibo1.lblfecha.Text
            discreteValuesexo.Value = Recibo1.txtSexo.Text
            '================DESCRIPCION DEL ESTUDIO PARA RECIBO IMPRESO=======================================
            If Recibo1.DataGridView1.Rows(0).Cells(1).Value = Nothing Then
                discreteValuedescripcion1.Value = " "
            Else
                discreteValuedescripcion1.Value = Recibo1.DataGridView1.Rows(0).Cells(1).Value
            End If

            If Recibo1.DataGridView1.Rows(1).Cells(1).Value = Nothing Then
                discreteValuedescripcion2.Value = " "
            Else
                discreteValuedescripcion2.Value = Recibo1.DataGridView1.Rows(1).Cells(1).Value
            End If
            If Recibo1.DataGridView1.Rows(2).Cells(1).Value = Nothing Then
                discreteValuedescripcion3.Value = " "
            Else
                discreteValuedescripcion3.Value = Recibo1.DataGridView1.Rows(2).Cells(1).Value
            End If

            If Recibo1.DataGridView1.Rows(3).Cells(1).Value = Nothing Then
                discreteValuedescripcion4.Value = " "
            Else
                discreteValuedescripcion4.Value = Recibo1.DataGridView1.Rows(3).Cells(1).Value
            End If
            If Recibo1.DataGridView1.Rows(4).Cells(1).Value = Nothing Then
                discreteValuedescripcion5.Value = " "
            Else
                discreteValuedescripcion5.Value = Recibo1.DataGridView1.Rows(4).Cells(1).Value
            End If
            '================IMPORTE DEL ESTUDIO PARA RECIBO IMPRESO=======================================
            If Recibo1.DataGridView1.Rows(0).Cells(4).Value = Nothing Then
                discreteValueimporte1.Value = " "
            Else
                discreteValueimporte1.Value = Recibo1.DataGridView1.Rows(0).Cells(4).Value
            End If

            If Recibo1.DataGridView1.Rows(1).Cells(4).Value = Nothing Then
                discreteValueimporte2.Value = " "
            Else
                discreteValueimporte2.Value = Recibo1.DataGridView1.Rows(1).Cells(4).Value
            End If
            If Recibo1.DataGridView1.Rows(2).Cells(4).Value = Nothing Then
                discreteValueimporte3.Value = " "
            Else
                discreteValueimporte3.Value = Recibo1.DataGridView1.Rows(2).Cells(4).Value
            End If
            If Recibo1.DataGridView1.Rows(3).Cells(4).Value = Nothing Then
                discreteValueimporte4.Value = " "
            Else
                discreteValueimporte4.Value = Recibo1.DataGridView1.Rows(3).Cells(4).Value
            End If

            If Recibo1.DataGridView1.Rows(4).Cells(4).Value = Nothing Then
                discreteValueimporte5.Value = " "
            Else
                discreteValueimporte5.Value = Recibo1.DataGridView1.Rows(4).Cells(4).Value
            End If

            discreteValuedescuento.Value = Recibo1.TxtDescuento.Text
            discreteValueanticipo.Value = Recibo1.txtAnticipo.Text
            discreteValueadeudo.Value = Recibo1.txtAdeudo.Text


            ''AQUI VAMOS A COMPROBAR SI EL RECIBO ESTA PAGADO========================================================
            estsatemp = Recibo1.txtAdeudo.Text
            If Recibo1.txtAdeudo.Text = " " Then

                discreteValueestadorecibo.Value = "RECIBO LIQUIDADO..."
            Else
                discreteValueestadorecibo.Value = " "

            End If
            discreteValuetotal.Value = Recibo1.TxtTotal.Text


            If Recibo1.txtObservaciones.Text = "" Then
                discreteValueobservaciones.Value = " "
                If Recibo1.chkcostos.Checked = False Then
                    discreteValueobservaciones.Value = Recibo1.txtObservaciones.Text + " " + Recibo1.ComboBoxtipoPago.Text.Substring(3, Recibo1.ComboBoxtipoPago.Text.Length - 3)
                End If
            Else
                If Recibo1.chkcostos.Checked = False Then
                    discreteValueobservaciones.Value = Recibo1.txtObservaciones.Text + " " + Recibo1.ComboBoxtipoPago.Text.Substring(3, Recibo1.ComboBoxtipoPago.Text.Length - 3)
                Else
                    discreteValueobservaciones.Value = Recibo1.txtObservaciones.Text
                End If

            End If


            'discreteValuefoliointerno.Value = Recibo1.txtFolioInterno.Text
            If Recibo1.chkcostos.Checked = False Then
                discreteValueimporte1.Value = " "
                discreteValueimporte2.Value = " "
                discreteValueimporte3.Value = " "
                discreteValueimporte4.Value = " "
                discreteValueimporte5.Value = " "
                discreteValueestadorecibo.Value = " "
                discreteValuedescuento.Value = " "
                discreteValuetotal.Value = " "
                discreteValueadeudo.Value = " "
                discreteValueanticipo.Value = " "

            End If


            paciente.CurrentValues.Add(discreteValuepaciente)
            medico.CurrentValues.Add(discreteValuemedico)
            ciudad.CurrentValues.Add(discreteValueciudad)
            telefono.CurrentValues.Add(discreteValuetelefono)
            rfc.CurrentValues.Add(discreteValuerfc)
            registro.CurrentValues.Add(discreteValueregistro)
            edad.CurrentValues.Add(discreteValueedad)
            fecha.CurrentValues.Add(discreteValuefecha)
            sexo.CurrentValues.Add(discreteValuesexo)
            descripcion1.CurrentValues.Add(discreteValuedescripcion1)
            descripcion2.CurrentValues.Add(discreteValuedescripcion2)

            descripcion3.CurrentValues.Add(discreteValuedescripcion3)
            descripcion4.CurrentValues.Add(discreteValuedescripcion4)
            descripcion5.CurrentValues.Add(discreteValuedescripcion5)
            'descripcion6.CurrentValues.Add(discreteValuedescripcion6)
            'descripcion7.CurrentValues.Add(discreteValuedescripcion7)




            importe1.CurrentValues.Add(discreteValueimporte1)
            importe2.CurrentValues.Add(discreteValueimporte2)
            importe3.CurrentValues.Add(discreteValueimporte3)
            importe4.CurrentValues.Add(discreteValueimporte4)
            importe5.CurrentValues.Add(discreteValueimporte5)
            'importe6.CurrentValues.Add(discreteValueimporte6)
            'importe7.CurrentValues.Add(discreteValueimporte7)
            descuento.CurrentValues.Add(discreteValuedescuento)
            anticipo.CurrentValues.Add(discreteValueanticipo)
            adeudo.CurrentValues.Add(discreteValueadeudo)
            'foliointerno.CurrentValues.Add(discreteValuefoliointerno)
            estadorecibo.CurrentValues.Add(discreteValueestadorecibo)
            total.CurrentValues.Add(discreteValuetotal)
            observaciones.CurrentValues.Add(discreteValueobservaciones)
            Dim paramFiels As New ParameterFields()
            paramFiels.Add(paciente)
            paramFiels.Add(medico)
            paramFiels.Add(ciudad)
            paramFiels.Add(telefono)
            paramFiels.Add(rfc)
            paramFiels.Add(registro)
            paramFiels.Add(edad)
            paramFiels.Add(fecha)
            paramFiels.Add(sexo)
            paramFiels.Add(descripcion1)

            paramFiels.Add(descripcion2)
            paramFiels.Add(descripcion3)
            paramFiels.Add(descripcion4)
            paramFiels.Add(descripcion5)
            'paramFiels.Add(descripcion6)
            'paramFiels.Add(descripcion7)

            paramFiels.Add(importe1)
            paramFiels.Add(importe2)
            paramFiels.Add(importe3)
            paramFiels.Add(importe4)
            paramFiels.Add(importe5)
            'paramFiels.Add(importe6)
            'paramFiels.Add(importe7)
            paramFiels.Add(descuento)


            paramFiels.Add(anticipo)
            paramFiels.Add(adeudo)
            'paramFiels.Add(foliointerno)
            paramFiels.Add(estadorecibo)
            paramFiels.Add(total)
            paramFiels.Add(observaciones)
            CrystalReportViewerRecibo1.ParameterFieldInfo = paramFiels

            populateReport()
            CrystalReportViewerRecibo1.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

    End Sub
    Private Sub ConfigureCrystalReports()
        receiptForm = New CrystalReportRecibo1()
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = "LAPROVIDENCIA"
        myConnectionInfo.UserID = "sa"
        myConnectionInfo.Password = "$d4m4s0"

        CrystalReportViewerRecibo1.ReportSource = receiptForm
        SetDBLogonForReport(myConnectionInfo)

        CrystalReportViewerRecibo1.Visible = True
    End Sub
    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo)
        Dim myTableLogOnInfos As TableLogOnInfos = CrystalReportViewerRecibo1.LogOnInfo
        For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
            myTableLogOnInfo.ConnectionInfo = myConnectionInfo
        Next
    End Sub
    Private Sub populateReport()
       
        Try
            'Creo una instancia de mi Reporte
            Dim info As New CrystalReportRecibo1
            'info.SetDataSource(MiDataSetDatos)
            Me.CrystalReportViewerRecibo1.ReportSource = info

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class