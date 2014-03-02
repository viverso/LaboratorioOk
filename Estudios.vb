

Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class Estudios
    Dim newRecord As Boolean
    Dim productIDColumn, quantityColumn, descriptionColumn, unitColumn, unitPriceColumn, rowAmountColumn As DataColumn
    Dim connectionProductsCatalog, connectionReceiptHeaders, connectionreceiptRows, connectionEstudios As SqlConnection
    Dim PermanentDB1, companyParameters, clients, invoiceHeaders, invoiceRows, productsKardex, productsCatalog, receiptHeaders, receiptRows As DataSet
    Dim connectionPermanent1, connectionClients, connectionCompanyParameters, connectioninvoiceHeaders, connectionInvoiceRows, connectionproductsKardex As SqlConnection
    Dim queryStringPermanent1, queryStringCompanyParameters, queryStringClients, queryStringInvoiceHeaders, queryStringInvoiceRows, queryStringproductsKardex, queryStringEstudios As String
    Dim querystringProductsCatalog, queryStringReceiptHeaders, queryStringReceiptRows As String
    Dim commandProductsCatalog, commandReceiptHeaders, commandReceiptRows, commandCompanies1 As SqlCommand
    Dim adapterPermanent1, adapterCompanyParameters, adapterClients, adapterInvoiceHeaders, adapterInvoiceRows, adapterproductsKardex, adapterEstudios As SqlDataAdapter
    Dim adapterProductsCatalog, adapterReceiptHeaders, adapterReceiptRows As SqlDataAdapter
    Dim commandPermanent1, commandCompanyParameters, commandClients, commandInvoiceHeaders, commandInvoiceRows, commandproductsKardex As SqlCommand
    Dim cmdBuilderPermanent1, cmdBuilderCompanyParameters, cmdBuilderClients, cmdBuilderInvoiceHeaders, cmdBuilderInvoiceRows, cmdBuilderproductsKardex As SqlCommandBuilder
    Dim cmdBuilderProductsCatalog, cmdBuilderReceiptHeaders, cmdBuilderReceiptRows, cmdBuilderCompanies1 As SqlCommandBuilder
    Dim estudios, renglonesRemision As DataSet

    Sub InitializeFields()
        newRecord = False
        clearfields()

    End Sub
    Sub clearfields()
        IDEstudio.Text = ""
        TxtDescripcion.Text = ""
        txtTiempo.Text = "0"
        txtProceso.Text = ""
        txtPrecio.Text = "0.0"
        'TxtDescripcion.Text = ""


    End Sub

    Private Sub Estudios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim toolTipbtnAdd As New ToolTip()
        Dim toolTipbtnSave As New ToolTip()
        Dim toolTipbtnCancel As New ToolTip()
        Dim toolTipbtnDelete As New ToolTip()
        Dim toolTipbtnPrint As New ToolTip()
        Dim toolTipbtnExit As New ToolTip()

        toolTipbtnAdd.Active = True
        toolTipbtnSave.Active = True
        toolTipbtnCancel.Active = True
        toolTipbtnDelete.Active = True
        toolTipbtnPrint.Active = True
        toolTipbtnExit.Active = True

        toolTipbtnAdd.SetToolTip(btnAdd, "Click para Agregar...")
        toolTipbtnSave.SetToolTip(btnSave, "Click para Guardar...")
        toolTipbtnCancel.SetToolTip(btnCancel, "Click para Cancelar...")
        toolTipbtnDelete.SetToolTip(btnDelete, "Click para Eliminar...")
        toolTipbtnPrint.SetToolTip(btnPrint, "Click para Imprimir...")
        toolTipbtnExit.SetToolTip(btnExit, "Click para Salir...")
        InitializeFields()
        cargaEstudios()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clearfields()
        btnDelete.Enabled = False
        cargaEstudios()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim respuesta As Integer
        respuesta = MsgBox(" ¿Realmente Desea Eliminar esta Linea? ", MsgBoxStyle.OkCancel, "ADVERTENCIA")
        If respuesta = 1 Then
            users = New DataSet()
            queryStringUsers = "delete from estudio where idEstudio= '" & IDEstudio.Text & "' and companyID = '" & currentCompany & "'"
            connectionUsers = New SqlConnection(connectionString)
            connectionUsers.Open()
            adapterUsers = New SqlDataAdapter
            commandUsers = New SqlCommand(queryStringUsers, connectionUsers)
            adapterUsers.SelectCommand = commandUsers
            cmdBuilderUsers = New SqlCommandBuilder(adapterUsers)
            cmdBuilderUsers.ConflictOption = ConflictOption.OverwriteChanges
            adapterUsers.Fill(users, "estudio")
            clearfields()
            LblTip.Text = "OPERACION REALIZADA EXITOSAMENTE"
            btnDelete.Enabled = False
            btnSave.Enabled = False
            cargaEstudios()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        clearfields()
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        newRecord = True
        clearfields()
        btnSave.Enabled = True
        btnAdd.Enabled = False
        TxtDescripcion.Focus()

    End Sub
    Private Sub cargaEstudios()
        Dim i As Integer
        estudios = New DataSet()
        connectionEstudios = New SqlConnection(connectionString)
        queryStringEstudios = "select * from Estudio where companyID='" & currentCompany & "'" & " order by idEstudio"
        connectionEstudios.Open()
        adapterEstudios = New SqlDataAdapter
        commandCompanies1 = New SqlCommand(queryStringEstudios, connectionEstudios)
        adapterEstudios.SelectCommand = commandCompanies1
        cmdBuilderCompanies1 = New SqlCommandBuilder(adapterEstudios)
        cmdBuilderCompanies1.ConflictOption = ConflictOption.OverwriteChanges
        adapterEstudios.Fill(estudios, "Estudio")
        ComboEstudios.Items.Clear()
        ComboEstudios.Items.Add("SELECCIONE EL ESTUDIO...")
        For i = 0 To estudios.Tables(0).Rows.Count - 1

            ComboEstudios.Items.Add(estudios.Tables(0).Rows(i).Item(0) & " - " & estudios.Tables(0).Rows(i).Item(1))
        Next
        ComboEstudios.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim remisionFolio As String
        Try
            If newRecord Then
                companyParameters = New DataSet()
                queryStringCompanyParameters = "select * from companyParameters where companyID='" & currentCompany & "'"
                connectionCompanyParameters = New SqlConnection(connectionString)
                connectionCompanyParameters.Open()
                adapterCompanyParameters = New SqlDataAdapter
                commandCompanyParameters = New SqlCommand(queryStringCompanyParameters, connectionCompanyParameters)
                adapterCompanyParameters.SelectCommand = commandCompanyParameters
                cmdBuilderCompanyParameters = New SqlCommandBuilder(adapterCompanyParameters)
                cmdBuilderCompanyParameters.ConflictOption = ConflictOption.OverwriteChanges
                adapterCompanyParameters.Fill(companyParameters, "companyParameters")
                companyParameters.Tables(0).Rows(0).Item(2) += 1 'Id del estudio
                remisionFolio = CType(companyParameters.Tables(0).Rows(0).Item(2), String)
                adapterCompanyParameters.Update(companyParameters, "companyParameters")
                companyParameters.Clear()
                companyParameters.Dispose()
                connectionCompanyParameters.Close()
                adapterCompanyParameters.Dispose()
                commandCompanyParameters.Dispose()
                cmdBuilderCompanyParameters.Dispose()
                IDEstudio.Text = remisionFolio.PadLeft(6, "0")
            End If
            invoiceHeaders = New DataSet()
            queryStringInvoiceHeaders = "select * from Estudio where companyID='" & currentCompany & "' and idEstudio='" & IDEstudio.Text & "'"
            connectioninvoiceHeaders = New SqlConnection(connectionString)
            connectioninvoiceHeaders.Open()
            adapterInvoiceHeaders = New SqlDataAdapter
            commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
            adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
            cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
            cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
            adapterInvoiceHeaders.Fill(invoiceHeaders, "Estudio")
            'Me.invoiceHeaders.WriteXml("encabezadoremision.xml")
            If newRecord Then
                invoiceHeaders.Tables(0).Rows.Add()
            End If
            invoiceHeaders.Tables(0).Rows(0).Item(0) = IDEstudio.Text
            invoiceHeaders.Tables(0).Rows(0).Item(1) = TxtDescripcion.Text
            invoiceHeaders.Tables(0).Rows(0).Item(2) = txtTiempo.Text
            invoiceHeaders.Tables(0).Rows(0).Item(3) = txtProceso.Text
            invoiceHeaders.Tables(0).Rows(0).Item(4) = txtPrecio.Text
            invoiceHeaders.Tables(0).Rows(0).Item(5) = currentCompany
            'invoiceHeaders.Tables(0).Rows(0).Item(4) = txtSubtotal.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(5) = TxtDescuento.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(6) = TxtIva.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(7) = txtTotal.Text

            'invoiceHeaders.Tables(0).Rows(0).Item(8) = convertAmountToString(TxtTotal.Text)

            'invoiceHeaders.Tables(0).Rows(0).Item(9) = "1"
            invoiceHeaders.Tables(0).Rows(0).Item(6) = currentUser

            'invoiceHeaders.Tables(0).Rows(0).Item(11) = TxtDireccion.Text & " " & TxtNumero.Text & " " & TxtColonia.Text
            adapterInvoiceHeaders.Update(invoiceHeaders, "Estudio")
            ''Me.invoiceHeaders.WriteXml("encabezadoVentas.xml")
            invoiceHeaders.Clear()
            invoiceHeaders.Dispose()
            connectioninvoiceHeaders.Close()
            adapterInvoiceHeaders.Dispose()
            commandInvoiceHeaders.Dispose()
            cmdBuilderInvoiceHeaders.Dispose()
            clearfields()
            'cargaEstudios()

        Catch ex As Exception

        End Try


    End Sub
    Private Sub IDLInea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IDEstudio.KeyPress
       



    End Sub


    Private Sub ComboUnidades_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEstudios.SelectedIndexChanged
        'Dim consecitiva() As String
        Dim cadena As String
        cadena = ComboEstudios.Text.Substring(0, 6)
        'cadena = consecitiva(0)
        'txtConsecutiva.Text = cadena
        If (cadena <> "SELECC") Then
            invoiceHeaders = New DataSet()
            queryStringInvoiceHeaders = "select * from Estudio where IdEstudio='" & cadena & "' and companyID='" & currentCompany & "'"
            connectioninvoiceHeaders = New SqlConnection(connectionString)
            connectioninvoiceHeaders.Open()
            adapterInvoiceHeaders = New SqlDataAdapter
            commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
            adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
            cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
            cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
            adapterInvoiceHeaders.Fill(invoiceHeaders, "Estudio")
            If invoiceHeaders.Tables(0).Rows.Count > 0 Then
                'ToolStripStatusLabel1.Text = ""
                'ToolStripStatusLabel1.Visible = False
                'txtFolio.ReadOnly = True
                IDEstudio.Text = invoiceHeaders.Tables(0).Rows(0).Item(0)
                TxtDescripcion.Text = invoiceHeaders.Tables(0).Rows(0).Item(1)
                txtPrecio.Text = invoiceHeaders.Tables(0).Rows(0).Item(4)
                txtTiempo.Text = invoiceHeaders.Tables(0).Rows(0).Item(2)
                txtProceso.Text = invoiceHeaders.Tables(0).Rows(0).Item(3)
                btnDelete.Enabled = True
                btnSave.Enabled = True
               
            Else
                'ToolStripStatusLabel1.Text = "ESTE CONSECUTIVO NO EXISTE INTENTE CON OTRO..."
                'ToolStripStatusLabel1.Visible = True
            End If

        End If
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        reporte_estudiosvb.Show()
    End Sub
End Class