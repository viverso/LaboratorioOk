
Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class ParametrosEstudio
    Dim newRecord As Boolean
    Dim dt As DataTable
    Dim productIDColumn, quantityColumn, descriptionColumn, unitColumn, unitPriceColumn, rowAmountColumn As DataColumn
    Dim connectionProductsCatalog, connectionReceiptHeaders, connectionreceiptRows, connectionEstudios As SqlConnection
    Dim PermanentDB1, companyParameters, clients, invoiceHeaders, invoiceRows, productsKardex, productsCatalog, receiptHeaders, receiptRows As DataSet
    Dim connectionPermanent1, connectionClients, connectionCompanyParameters, connectioninvoiceHeaders, connectionInvoiceRows, connectionproductsKardex As SqlConnection
    Dim queryStringPermanent1, queryStringCompanyParameters, queryStringClients, queryStringInvoiceHeaders, queryStringInvoiceRows, queryStringproductsKardex, queryStringEstudios As String
    Dim querystringProductsCatalog, queryStringReceiptHeaders, queryStringReceiptRows As String
    Dim commandProductsCatalog, commandReceiptHeaders, commandReceiptRows, commandCompanies1 As SqlCommand
    Dim adapterPermanent1, adapterCompanyParameters, adapterClients, adapterInvoiceHeaders, adapterInvoiceRows, adapterproductsKardex, adapterEstudios As SqlDataAdapter
    Dim adapterProductsCatalog, adapterReceiptHeaders, adapterReceiptRows, da As SqlDataAdapter
    Dim commandPermanent1, commandCompanyParameters, commandClients, commandInvoiceHeaders, commandInvoiceRows, commandproductsKardex As SqlCommand
    Dim cmdBuilderPermanent1, cmdBuilderCompanyParameters, cmdBuilderClients, cmdBuilderInvoiceHeaders, cmdBuilderInvoiceRows, cmdBuilderproductsKardex As SqlCommandBuilder
    Dim cmdBuilderProductsCatalog, cmdBuilderReceiptHeaders, cmdBuilderReceiptRows, cmdBuilderCompanies1 As SqlCommandBuilder
    Dim estudios, renglonesRemision As DataSet

    Private Sub ParametrosEstudio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaEstudios()

    End Sub
    Private Sub limpiarCampos()
        txtDescripcion.Text = ""
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

    Private Sub cargaDetalleEStudio(ByVal idEstudio As String)
        Dim seleccion As String = "SELECT idDetalle,idEstudio, DescripcionParametro as DESCRIPCION FROM DetalleEstudio   where  idEstudio='" & idEstudio & "'" & " and companyID='" & currentCompany & "'"
        da = New SqlDataAdapter(seleccion, connectionString)
        dt = New DataTable
        da.Fill(dt)

        Me.DataGridViewDetalleEstudio.DataSource = dt

        ' Si solo quieres mostrar los que empiecen por lo escrito.
        ' Al escribir "s" se buscarán los que empiecen por esa letra.
        'filas = dt.Select("Apellidos LIKE '" & txtApellidos.Text & "%'")

        ' Borrar los elementos anteriores
        If dt.Rows.Count > 0 Then
            'txtcodigo.Text = DataGridViewConceptos.Rows(DataGridViewConceptos.CurrentRow.Index).Cells(0).Value
            'txtDescripcion.Text = DataGridViewConceptos.Rows(DataGridViewConceptos.CurrentRow.Index).Cells(1).Value
            'txtPrecio.Text = DataGridViewConceptos.Rows(DataGridViewConceptos.CurrentRow.Index).Cells(2).Value
            'txtPU.Text = DataGridViewConceptos.Rows(DataGridViewConceptos.CurrentRow.Index).Cells(3).Value
            'Me.DataGridViewConceptos.Columns("idProducto").DefaultCellStyle.Format = "c" 'PONE EL SIGNO DE PESOS
            'Me.DataGridViewDetalleEstudio.Columns("COSTO CONCEPTO").DefaultCellStyle.Format = "c"
            'Me.DataGridViewDetalleEstudio.Columns("COSTO CONCEPTO").DefaultCellStyle.Format = "###,##0.0000"


            Me.DataGridViewDetalleEstudio.BackgroundColor = Color.LemonChiffon
            Me.DataGridViewDetalleEstudio.ForeColor = Color.DarkBlue
            DataGridViewDetalleEstudio.GridColor = Color.Blue
            Me.DataGridViewDetalleEstudio.DefaultCellStyle.WrapMode = DataGridViewTriState.True 'ajusta el texto a la celda

            'Me.DataGridViewConceptos.Columns("EXISTENCIAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'alinea texto a la derecha
            'Me.DataGridViewConceptos.Columns("Costo Unitario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'alinea texto a la derecha
            DataGridViewDetalleEstudio.AutoResizeColumn(0)

            DataGridViewDetalleEstudio.AutoResizeColumn(1)
            'DataGridViewConceptos.AutoResizeColumn(2)
            DataGridViewDetalleEstudio.Columns(2).Width = 500
            Me.DataGridViewDetalleEstudio.Columns.Item(0).Visible = False
            Me.DataGridViewDetalleEstudio.Columns.Item(1).Visible = False


        Else
            Me.DataGridViewDetalleEstudio.Columns.Item(0).Visible = False
            Me.DataGridViewDetalleEstudio.Columns.Item(1).Visible = False
            DataGridViewDetalleEstudio.Columns(2).Width = 500
        End If


        da.Dispose()
    End Sub




    Private Sub ComboEstudios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEstudios.SelectedIndexChanged

        Dim cadena As String
        txtidEstudio.Text = ComboEstudios.Text.Substring(0, 6)
        'cadena = consecitiva(0)
        'txtConsecutiva.Text = cadena
        If (txtidEstudio.Text <> "SELECC") Then
            cargaDetalleEStudio(txtidEstudio.Text)
            'invoiceHeaders = New DataSet()
            'queryStringInvoiceHeaders = "select * from Estudio where IdEstudio='" & cadena & "' and companyID='" & currentCompany & "'"
            'connectioninvoiceHeaders = New SqlConnection(connectionString)
            'connectioninvoiceHeaders.Open()
            'adapterInvoiceHeaders = New SqlDataAdapter
            'commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
            'adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
            'cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
            'cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
            'adapterInvoiceHeaders.Fill(invoiceHeaders, "Estudio")
            'If invoiceHeaders.Tables(0).Rows.Count > 0 Then
            '    'ToolStripStatusLabel1.Text = ""
            '    'ToolStripStatusLabel1.Visible = False
            '    'txtFolio.ReadOnly = True
            '    IDEstudio.Text = invoiceHeaders.Tables(0).Rows(0).Item(0)
            '    TxtDescripcion.Text = invoiceHeaders.Tables(0).Rows(0).Item(1)
            '    txtPrecio.Text = invoiceHeaders.Tables(0).Rows(0).Item(2)
            '    btnDelete.Enabled = True
            '    btnSave.Enabled = True

            'Else
            '    'ToolStripStatusLabel1.Text = "ESTE CONSECUTIVO NO EXISTE INTENTE CON OTRO..."
            '    'ToolStripStatusLabel1.Visible = True
            'End If

        End If
    End Sub



    Private Sub DataGridViewDetalleEstudio_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDetalleEstudio.CellContentClick
        Try
            txtidDetalle.Text = DataGridViewDetalleEstudio.CurrentRow.Cells(0).Value
            txtidEstudio.Text = DataGridViewDetalleEstudio.CurrentRow.Cells(1).Value
            txtDescripcion.Text = DataGridViewDetalleEstudio.CurrentRow.Cells(2).Value
            btnSave.Enabled = True
            btnDelete.Enabled = True
        Catch ex As Exception
            MsgBox("LA COLUMNA SELECCIONADA NO TIENE DATOS...")

            ComboEstudios.SelectedIndex = 0


            ' limpiarCampos()
            DataGridViewDetalleEstudio.DataSource = Nothing


            btnAdd.Enabled = True
            btnDelete.Enabled = False
            newRecord = False
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        newRecord = True
        'clearfields()
        btnSave.Enabled = True
        btnAdd.Enabled = False
        txtDescripcion.Focus()
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
                companyParameters.Tables(0).Rows(0).Item(3) += 1 'folio de la remision
                remisionFolio = CType(companyParameters.Tables(0).Rows(0).Item(3), String)
                adapterCompanyParameters.Update(companyParameters, "companyParameters")
                companyParameters.Clear()
                companyParameters.Dispose()
                connectionCompanyParameters.Close()
                adapterCompanyParameters.Dispose()
                commandCompanyParameters.Dispose()
                cmdBuilderCompanyParameters.Dispose()
                txtidDetalle.Text = remisionFolio.PadLeft(6, "0")
            End If
            invoiceHeaders = New DataSet()
            'SELECT idDetalle,idEstudio, DescripcionParametro as DESCRIPCION FROM DetalleEstudio   where  idEstudio='" & idEstudio & "'" & " and companyID='" & currentCompany & "'"
            queryStringInvoiceHeaders = "select * from DetalleEstudio where companyID='" & currentCompany & "' and idEstudio='" & txtidEstudio.Text & "'" & " and idDetalle='" & txtidDetalle.Text & "'"
            connectioninvoiceHeaders = New SqlConnection(connectionString)
            connectioninvoiceHeaders.Open()
            adapterInvoiceHeaders = New SqlDataAdapter
            commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
            adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
            cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
            cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
            adapterInvoiceHeaders.Fill(invoiceHeaders, "DetalleEstudio")
            'Me.invoiceHeaders.WriteXml("encabezadoremision.xml")
            If newRecord Then
                invoiceHeaders.Tables(0).Rows.Add()
            End If
            invoiceHeaders.Tables(0).Rows(0).Item(0) = txtidDetalle.Text
            invoiceHeaders.Tables(0).Rows(0).Item(1) = txtidEstudio.Text
            invoiceHeaders.Tables(0).Rows(0).Item(2) = txtDescripcion.Text.ToUpper
            'invoiceHeaders.Tables(0).Rows(0).Item(3) = txtObservacion.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(4) = CType(txtCostoModelo.Text, Decimal)
            invoiceHeaders.Tables(0).Rows(0).Item(3) = currentCompany
            'invoiceHeaders.Tables(0).Rows(0).Item(6) = lblClasificacion.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(4) = txtSubtotal.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(5) = TxtDescuento.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(6) = TxtIva.Text
            'invoiceHeaders.Tables(0).Rows(0).Item(7) = txtTotal.Text

            'invoiceHeaders.Tables(0).Rows(0).Item(8) = convertAmountToString(TxtTotal.Text)

            'invoiceHeaders.Tables(0).Rows(0).Item(9) = "1"
            'invoiceHeaders.Tables(0).Rows(0).Item(10) = currentUser

            'invoiceHeaders.Tables(0).Rows(0).Item(11) = TxtDireccion.Text & " " & TxtNumero.Text & " " & TxtColonia.Text
            adapterInvoiceHeaders.Update(invoiceHeaders, "DetalleEstudio")
            ''Me.invoiceHeaders.WriteXml("encabezadoVentas.xml")
            invoiceHeaders.Clear()
            invoiceHeaders.Dispose()
            connectioninvoiceHeaders.Close()
            adapterInvoiceHeaders.Dispose()
            commandInvoiceHeaders.Dispose()
            cmdBuilderInvoiceHeaders.Dispose()
            limpiarCampos()
            DataGridViewDetalleEstudio.DataSource = Nothing


            btnAdd.Enabled = True
            btnDelete.Enabled = False
            newRecord = False
            cargaDetalleEStudio(txtidEstudio.Text)
        Catch ex As Exception
            MessageBox.Show("ERROR AL GUARDAR...")
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        limpiarCampos()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        limpiarCampos()
        Me.Close()
    End Sub
End Class