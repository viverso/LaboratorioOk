﻿Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math
Public Class Recibo
    Dim maxRows As Integer = 15
    Dim clave1, clave2, clave3, clave4, clave5, clave6 As Decimal
    Dim cuenta As Integer
    Dim totalanticipos As Decimal
    Dim currentRow As Integer = 0
    Public lastUsed As Integer = 0
    Dim newDocument As Boolean = True
    Dim modi As Boolean = False
    Dim productIDColumn, quantityColumn, descriptionColumn, unitColumn, unitPriceColumn, rowAmountColumn As DataColumn
    Dim connectionProductsCatalog, connectionReceiptHeaders, connectionreceiptRows, connectionanticipos As SqlConnection
    Dim PermanentDB1, companyParameters, clients, invoiceHeaders, invoiceRows1, productsKardex, productsCatalog, receiptHeaders, receiptRows, doctores, tipoPago, anticipos As DataSet
    Dim connectionPermanent1, connectionClients, connectionCompanyParameters, connectioninvoiceHeaders, connectioninvoiceRows, connectionproductsKardex, connectionDoctores, connectiontipoPago, connectioncorterecibos, connectioncortegastos As SqlConnection
    Dim queryStringPermanent1, queryStringCompanyParameters, queryStringClients, queryStringInvoiceHeaders, queryStringinvoiceRows, queryStringproductsKardex As String
    Dim querystringProductsCatalog, queryStringReceiptHeaders, queryStringReceiptRows, queryStringTipoPago, queryStringcorterecibos, queryStringcortegastos As String
    Dim commandProductsCatalog, commandReceiptHeaders, commandReceiptRows As SqlCommand
    Dim adapterPermanent1, adapterCompanyParameters, adapterClients, adapterInvoiceHeaders, adapterinvoiceRows, adapterproductsKardex, adapterDoctores, adaptercortegastos As SqlDataAdapter
    Dim adapterProductsCatalog, adapterReceiptHeaders, adapterReceiptRows, adaptertipoPago, adapteranticipos, adaptercorterecibos As SqlDataAdapter
    Dim commandPermanent1, commandCompanyParameters, commandClients, commandInvoiceHeaders, commandinvoiceRows, commandproductsKardex, commandDoctores, commandtipoPago, commandanticipos, commandcorterecibos, commandcortegastos As SqlCommand
    Dim cmdBuilderPermanent1, cmdBuilderCompanyParameters, cmdBuilderClients, cmdBuilderInvoiceHeaders, cmdBuilderinvoiceRows, cmdBuilderproductsKardex As SqlCommandBuilder
    Dim cmdBuilderProductsCatalog, cmdBuilderReceiptHeaders, cmdBuilderReceiptRows, cmdBuilderDoctores, cmdBuildertipoPago, cmdBuilderanticipos, cmdBuildercorterecibos, cmdBuildercortegastos As SqlCommandBuilder
    Dim encabezadoRemisiones, renglonesRemision, invoiceRows, corterecibos, cortegastos As DataSet
    Dim corteanticipos, buscaMonto, buscafolio1, guardadosencorte As DataSet
    Dim queryStringcorteanticipos, queryStringBuscaPeriodos, queryStringBuscaFolio As String
    Dim connectioncorteanticipos, connectionBuscaPeriodos, connectionBuscaFolio, connectionguardadosencorte As SqlConnection
    Dim adaptercorteanticipos, adapterBuscaPeriodos, adapterBuscaFolio, adapterguardadosencorte As SqlDataAdapter
    Dim commandcorteanticipos, commandBuscaPeriodos, commandBuscaFolio, commandguardadosencorte As SqlCommand
    Dim cmdBuildercorteanticipos, cmdBuilderBuscaPeriodo, cmdBuilderBuscaFolio, cmdBuilderguardadosencorte As SqlCommandBuilder
    Function checaGuardadosencorte(ByVal folio As String) As Boolean
        Dim exise As Boolean = False
        Try
            guardadosencorte = New DataSet()
            connectionguardadosencorte = New SqlConnection(connectionString)
            queryStringCompanies = "select  idRecibo from cortediario where idRecibo='" & folio & "' and companyID='" & currentCompany & "'"

            connectionguardadosencorte.Open()
            adapterguardadosencorte = New SqlDataAdapter
            commandguardadosencorte = New SqlCommand(queryStringCompanies, connectionguardadosencorte)
            adapterguardadosencorte.SelectCommand = commandguardadosencorte
            cmdBuilderguardadosencorte = New SqlCommandBuilder(adapterguardadosencorte)
            cmdBuilderguardadosencorte.ConflictOption = ConflictOption.OverwriteChanges
            adapterguardadosencorte.Fill(guardadosencorte, "guardadosencorte")

            If guardadosencorte.Tables(0).Rows.Count > 0 Then
                exise = True
                Return exise
            Else

                Return exise
            End If


        Catch ex As Exception
            txtAdeudo.Text = 0
            btnLiquidar.Enabled = False
        End Try



        guardadosencorte.Clear()
        guardadosencorte.Dispose()
        connectionguardadosencorte.Close()
        adapterguardadosencorte.Dispose()
        commandguardadosencorte.Dispose()
        cmdBuilderguardadosencorte.Dispose()
    End Function
    Function buscaimporte(ByVal folio As String) As Decimal
        Dim tempMonto As Decimal = 0.0
        Try
            buscaMonto = New DataSet()
            queryStringBuscaPeriodos = "set DateFormat 'dmy'; select total from recibo where idRecibo='" & folio & "' and companyID='" & currentCompany & "'  and usuario='" & currentUser & "'"
            connectionBuscaPeriodos = New SqlConnection(connectionString)
            connectionBuscaPeriodos.Open()
            adapterBuscaPeriodos = New SqlDataAdapter
            commandBuscaPeriodos = New SqlCommand(queryStringBuscaPeriodos, connectionBuscaPeriodos)
            adapterBuscaPeriodos.SelectCommand = commandBuscaPeriodos
            cmdBuilderBuscaPeriodo = New SqlCommandBuilder(adapterBuscaPeriodos)
            cmdBuilderBuscaPeriodo.ConflictOption = ConflictOption.OverwriteChanges
            adapterBuscaPeriodos.Fill(buscaMonto, "recibo")
            tempMonto = buscaMonto.Tables(0).Rows(0).Item(0).ToString()
            buscaMonto.Clear()
            buscaMonto.Dispose()
            connectionBuscaPeriodos.Close()
            adapterBuscaPeriodos.Dispose()
            commandBuscaPeriodos.Dispose()
            cmdBuilderBuscaPeriodo.Dispose()

            Return tempMonto

        Catch ex As Exception
            Return tempMonto
        End Try

    End Function
    Function buscafolio(ByVal folio As String) As String
        Dim folio1 As String = ""
        Try
            buscafolio1 = New DataSet()
            queryStringBuscaFolio = "set DateFormat 'dmy'; select idlaboratorio from recibo where idRecibo='" & folio & "' and companyID='" & currentCompany & "'  and usuario='" & currentUser & "'"
            connectionBuscaFolio = New SqlConnection(connectionString)
            connectionBuscaFolio.Open()
            adapterBuscaFolio = New SqlDataAdapter
            commandBuscaFolio = New SqlCommand(queryStringBuscaFolio, connectionBuscaFolio)
            adapterBuscaFolio.SelectCommand = commandBuscaFolio
            cmdBuilderBuscaFolio = New SqlCommandBuilder(adapterBuscaFolio)
            cmdBuilderBuscaFolio.ConflictOption = ConflictOption.OverwriteChanges
            adapterBuscaFolio.Fill(buscafolio1, "recibo")
            folio1 = buscafolio1.Tables(0).Rows(0).Item(0).ToString()
            buscafolio1.Clear()
            buscafolio1.Dispose()
            connectionBuscaFolio.Close()
            adapterBuscaFolio.Dispose()
            commandBuscaFolio.Dispose()
            cmdBuilderBuscaFolio.Dispose()

            Return folio1

        Catch ex As Exception
            Return folio1
        End Try

    End Function

    Private Sub eliminacortediario(ByVal compania As String)
        Try

            Dim oConexion As SqlClient.SqlConnection = _
                    New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("eliminatempcortediario", oConexion)

            Dim oParameter As SqlClient.SqlParameter

            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = compania

            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()

            oCommand.Dispose()
            oConexion.Close()
            oConexion.Dispose()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub busca_gastos(ByVal fechas_hoy As Date, ByVal consecutivo As Integer)
        Dim i As Integer
        Dim temp As Integer
        cortegastos = New DataSet()
        queryStringcortegastos = "set DateFormat 'dmy'; select * from gastos where companyID='" & currentCompany & "' and fecha='" & fechas_hoy & "' and usuario='" & currentUser & "'"
        connectioncortegastos = New SqlConnection(connectionString)
        connectioncortegastos.Open()
        adaptercortegastos = New SqlDataAdapter
        commandcortegastos = New SqlCommand(queryStringcortegastos, connectioncortegastos)
        adaptercortegastos.SelectCommand = commandcortegastos
        cmdBuildercortegastos = New SqlCommandBuilder(adaptercortegastos)
        cmdBuildercortegastos.ConflictOption = ConflictOption.OverwriteChanges
        adaptercortegastos.Fill(cortegastos, "gastos")

        For i = 0 To cortegastos.Tables(0).Rows.Count - 1
            guarda_corte(i + consecutivo, cortegastos.Tables(0).Rows(i).Item(0), cortegastos.Tables(0).Rows(i).Item(2), 0, 0, cortegastos.Tables(0).Rows(i).Item(3), cortegastos.Tables(0).Rows(i).Item(1), currentUser, currentCompany)
        Next





        connectioncortegastos.Close()
        cortegastos.Clear()
    End Sub
    Function checaAnticipofechas(ByVal folio As String, ByVal fechas As Date) As Decimal
        totalanticipos = 0
        Try
            anticipos = New DataSet()
            connectionanticipos = New SqlConnection(connectionString)
            queryStringCompanies = "select SUM(importe) from anticipos where idRecibo='" & folio & "' and companyID='" & currentCompany & "'  and fecha='" & fechas & "'"

            connectionanticipos.Open()
            adapteranticipos = New SqlDataAdapter
            commandanticipos = New SqlCommand(queryStringCompanies, connectionanticipos)
            adapteranticipos.SelectCommand = commandanticipos
            cmdBuilderanticipos = New SqlCommandBuilder(adapteranticipos)
            cmdBuilderanticipos.ConflictOption = ConflictOption.OverwriteChanges
            adapteranticipos.Fill(anticipos, "anticipos")

            If anticipos.Tables(0).Rows(0).Item(0) >= 0 Then

                txtAdeudo.Text = anticipos.Tables(0).Rows(0).Item(0)
                totalanticipos = anticipos.Tables(0).Rows(0).Item(0)
                txtAdeudo.Visible = True

                Return totalanticipos
            Else
                txtAdeudo.Text = ""
                txtAdeudo.Visible = False
                Return totalanticipos
            End If


        Catch ex As Exception
            txtAdeudo.Text = 0
            btnLiquidar.Enabled = False
        End Try



        anticipos.Clear()
        anticipos.Dispose()
        connectionanticipos.Close()
        adapteranticipos.Dispose()
        commandanticipos.Dispose()
        cmdBuilderanticipos.Dispose()
    End Function
    Private Sub guarda_corte(ByVal consecutivo As Integer, ByVal idrecibo As String, ByVal concepto As String, ByVal importe As Decimal, ByVal ingresos As Decimal, ByVal egresos As Decimal, ByVal fecha As Date, ByVal usuarios As String, ByVal empresa As String)
        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("cortediario_usuarios", oConexion)

            Dim oParameter As SqlClient.SqlParameter


            oParameter = oCommand.Parameters.Add("@consecutivo", SqlDbType.Int)
            oParameter.Value = consecutivo
            oParameter = oCommand.Parameters.Add("@idRecibo", SqlDbType.VarChar, 6)
            oParameter.Value = idrecibo

            oParameter = oCommand.Parameters.Add("@concepto", SqlDbType.VarChar, 80)
            oParameter.Value = concepto

            oParameter = oCommand.Parameters.Add("@importe", SqlDbType.Decimal, 8 - 2)
            oParameter.Value = importe

            oParameter = oCommand.Parameters.Add("@ingresos", SqlDbType.Decimal, 8 - 2)
            oParameter.Value = ingresos

            oParameter = oCommand.Parameters.Add("@egresos", SqlDbType.Decimal, 8 - 2)
            oParameter.Value = egresos

            oParameter = oCommand.Parameters.Add("@fecha", SqlDbType.Date)
            oParameter.Value = fecha

            oParameter = oCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
            oParameter.Value = usuarios

            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = empresa

            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()


        Catch ex As Exception
            'oCommand.Dispose()
            System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub
    Private Sub busca_anticipos(ByVal fechas_hoy As Date)
        Dim i As Integer
        Dim temp As Integer
        


    End Sub
    Private Sub busca_recibos(ByVal fechas_hoy As Date)
        Dim temprecibos, tempanticipos As Integer
        Dim i As Integer
        Dim temp As Integer
        Dim x As Integer
        Dim a, b As String
        corterecibos = New DataSet()
        queryStringcorterecibos = "set DateFormat 'dmy'; select * from recibo where companyID='" & currentCompany & "' and fecha='" & fechas_hoy & "' and usuario='" & currentUser & "'"
        connectioncorterecibos = New SqlConnection(connectionString)
        connectioncorterecibos.Open()
        adaptercorterecibos = New SqlDataAdapter
        commandcorterecibos = New SqlCommand(queryStringcorterecibos, connectioncorterecibos)
        adaptercorterecibos.SelectCommand = commandcorterecibos
        cmdBuildercorterecibos = New SqlCommandBuilder(adaptercorterecibos)
        cmdBuildercorterecibos.ConflictOption = ConflictOption.OverwriteChanges
        adaptercorterecibos.Fill(corterecibos, "recibo")
        temp = corterecibos.Tables(0).Rows.Count
        corteanticipos = New DataSet()


        queryStringcorteanticipos = "set DateFormat 'dmy'; select * from anticipos  where companyID='" & currentCompany & "' and fecha='" & fechas_hoy & "' and usuario='" & currentUser & "'"
        connectioncorteanticipos = New SqlConnection(connectionString)
        connectioncorteanticipos.Open()
        adaptercorteanticipos = New SqlDataAdapter
        commandcorteanticipos = New SqlCommand(queryStringcorteanticipos, connectioncorteanticipos)
        adaptercorteanticipos.SelectCommand = commandcorteanticipos
        cmdBuildercorteanticipos = New SqlCommandBuilder(adaptercorteanticipos)
        cmdBuildercorteanticipos.ConflictOption = ConflictOption.OverwriteChanges
        adaptercorteanticipos.Fill(corteanticipos, "anticipos")
        temp = corteanticipos.Tables(0).Rows.Count



        For i = 0 To corterecibos.Tables(0).Rows.Count - 1
            temprecibos = corterecibos.Tables(0).Rows(i).Item(8)
            tempanticipos = corterecibos.Tables(0).Rows(i).Item(13).ToString


            If checaAnticipofechas(corterecibos.Tables(0).Rows(i).Item(0), fechas_hoy) > 0 Then
                guarda_corte(i, corterecibos.Tables(0).Rows(i).Item(0), corterecibos.Tables(0).Rows(i).Item(13), corterecibos.Tables(0).Rows(i).Item(8), totalanticipos, 0, Now.Date, currentUser, currentCompany)

            Else

                guarda_corte(i, corterecibos.Tables(0).Rows(i).Item(0), corterecibos.Tables(0).Rows(i).Item(13), corterecibos.Tables(0).Rows(i).Item(8), corterecibos.Tables(0).Rows(i).Item(8), 0, Now.Date, currentUser, currentCompany)

            End If
            temprecibos = i
        Next
        temp = corteanticipos.Tables(0).Rows.Count
        For x = 0 To corteanticipos.Tables(0).Rows.Count - 1

            b = corteanticipos.Tables(0).Rows(x).Item(0)
            'For i = 0 To corterecibos.Tables(0).Rows.Count - 1
            '    a = corterecibos.Tables(0).Rows(i).Item(0)
            If checaGuardadosencorte(b) Then

            Else
                temp = temp + 1
                guarda_corte(temp, b, buscafolio(corteanticipos.Tables(0).Rows(x).Item(0)), buscaimporte(corteanticipos.Tables(0).Rows(x).Item(0)), corteanticipos.Tables(0).Rows(x).Item(3), 0, Now.Date, currentUser, currentCompany)

            End If
            'Next

        Next

        busca_gastos(Now.Date, temp)
        connectioncorteanticipos.Close()
        corteanticipos.Clear()
        connectioncorterecibos.Close()
        corterecibos.Clear()


    End Sub




    Private Sub KeypresTextDESC_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextDESC.KeyPress

        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                If Decimal.Parse(TextDESC.Text) < Decimal.Parse(txtTotalVenta.Text) Then
                    ' txtCambio.Text = Format$(Val(CType(txtPago.Text, Decimal) - CType(txtTotalVenta.Text, Decimal)), "###,##0.00")
                    If CheckBoxporcentaje.Checked = True Then
                        TxtDescuento.Text = (TxtTotal.Text) * (TextDESC.Text / 100)
                        TxtTotal.Text = Format$(TxtTotal.Text - (TxtTotal.Text) * (TextDESC.Text / 100), "###,##0.00")
                    Else
                        TxtDescuento.Text = TextDESC.Text
                        TxtTotal.Text = Format$(TxtTotal.Text - (TxtDescuento.Text), "###,##0.00")
                    End If
                    'TxtDescuento.Text = (TxtTotal.Text) * (TextDESC.Text / 100)

                    'TxtTotal.Text = Format$(TxtTotal.Text - (TxtTotal.Text) * (TextDESC.Text / 100), "###,##0.00")

                    TxtTotal.Text = txtSuma.Text - TxtDescuento.Text
                    TxtTotal.Text = Format$(Decimal.Parse(TxtTotal.Text), "###,##0.00")
                    txtTotalVenta.Text = TxtTotal.Text
                    txtPago.BackColor = System.Drawing.Color.GreenYellow
                    'TxtDescuento.Text = TextDESC.Text
                    txtPago.Focus()
                    'Button4.Enabled = True
                Else
                    Button4.Enabled = False
                    TextDESC.Focus()
                End If

            Case 48 To 58
                e.KeyChar = e.KeyChar

            Case 46
                e.KeyChar = e.KeyChar
            Case 8
                e.KeyChar = e.KeyChar
            Case 127
                e.KeyChar = e.KeyChar
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub
   

    Private Sub KeyprestxtRecibo_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibo.KeyPress

        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                If Decimal.Parse(txtRecibo.Text) >= Decimal.Parse(txtPago.Text) Then
                    txtCambio.Text = txtRecibo.Text - txtPago.Text
                    Button4.Focus()
                Else

                End If

            Case 48 To 58
                e.KeyChar = e.KeyChar

            Case 46
                e.KeyChar = e.KeyChar
            Case 8
                e.KeyChar = e.KeyChar
            Case 127
                e.KeyChar = e.KeyChar
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub
    Private Sub KeyprestxtPago_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPago.KeyPress
        Dim tempSubtotal As Double = 0
        Dim tempDescuento As Double = 0
        Dim count As Integer = 0
        Select Case Asc(e.KeyChar)
            Case Keys.Enter

                If Decimal.Parse(txtPago.Text) <> Decimal.Parse(txtTotalVenta.Text) Or ComboBoxtipoPago.Text.Substring(0, 2) = "03" Or ComboBoxtipoPago.Text.Substring(0, 2) = "01" Then
                    If Decimal.Parse(TextDESC.Text) > 0 Or ComboBoxtipoPago.Text.Substring(0, 2) = "03" Then

                        txtRecibo.Focus()

                        If Decimal.Parse(txtPago.Text) > Decimal.Parse(txtTotalVenta.Text) Then

                            ' txtCambio.Text = Decimal.Parse(txtPago.Text) - Decimal.Parse(TxtTotal.Text)

                        Else

                            ' txtCambio.Text = Decimal.Parse(TxtTotal.Text) - Decimal.Parse(txtPago.Text)
                        End If

                    Else
                        txtRecibo.Focus()
                        ' txtCambio.Text = Decimal.Parse(txtPago.Text) - Decimal.Parse(TxtTotal.Text)
                    End If

                    'txtCambio.BackColor = System.Drawing.Color.GreenYellow
                    'Button4.Focus()
                    'Button4.Enabled = True
                Else
                    'Button4.Enabled = False
                    'txtPago.Focus()
                End If

            Case 48 To 58
                e.KeyChar = e.KeyChar

            Case 46
                e.KeyChar = e.KeyChar
            Case 8
                e.KeyChar = e.KeyChar
            Case 127
                e.KeyChar = e.KeyChar
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub KeyprestxtLRecibo_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLRecibo.KeyPress
        
        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                If Decimal.Parse(txtLRecibo.Text) >= Decimal.Parse(txtLiquidacion.Text) Then
                    txtLCambio.Text = txtLRecibo.Text - txtLiquidacion.Text
                    btnAceptarLiquidacion.Focus()
                Else
                    MessageBox.Show("EL IMPORTE NO PUEDE SER MENOR AL ADEUDO...")
                    txtLRecibo.Focus()
                End If



            Case 48 To 58
                e.KeyChar = e.KeyChar

            Case 46
                e.KeyChar = e.KeyChar
            Case 8
                e.KeyChar = e.KeyChar
            Case 127
                e.KeyChar = e.KeyChar
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub guardaAnticipo(ByVal idAnticipo As String, ByVal contador As Integer, ByVal fecha As Date, ByVal importe As Decimal, ByVal empresa As String, ByVal usuario As String)
        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("guardaAnticipo", oConexion)

            Dim oParameter As SqlClient.SqlParameter


            oParameter = oCommand.Parameters.Add("@idRecibo", SqlDbType.VarChar, 6)
            oParameter.Value = idAnticipo
            oParameter = oCommand.Parameters.Add("@count", SqlDbType.Int)
            oParameter.Value = contador

            oParameter = oCommand.Parameters.Add("@fecha", SqlDbType.Date)
            oParameter.Value = fecha
            oParameter = oCommand.Parameters.Add("@importe", SqlDbType.Decimal)
            oParameter.Value = importe


            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = empresa

            oParameter = oCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
            oParameter.Value = usuario

            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()


        Catch ex As Exception
            'oCommand.Dispose()
            System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub
    Private Sub VENTAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim cont As Integer
        If e.KeyValue = Keys.F2 Then
            cont = DataGridView1.CurrentRow.Index
            'Me.Hide()
            buscaCliente.Show()
            buscaCliente.txtBuscar.Focus()
        End If
        If e.KeyValue = Keys.F3 Then
            cont = DataGridView1.CurrentRow.Index
            'Me.Hide()
            buscaEstudio.Show()
            buscaEstudio.txtBuscar.Focus()
        End If
        'DataGridView1.ClearSelection()
        'DataGridView1.CurrentRow.Cells(1).Selected = True
        'SendKeys.Send("{RIGHT}")
        'DataGridView1.CurrentCell.EndEdit = True
        If e.KeyValue = Keys.F5 Then
            If ComboBoxDoctores.Text.Substring(0, 6) <> "SELECC" Then
                If ComboBoxtipoPago.Text.Substring(0, 2) = "03" Then
                    auxiliaryProceed()
                    'applyProductsToKardex()
                    'frmRemisiones.Show()

                    guardaAnticipo(TxtFolio.Text, consecutivoAnticipo(), Now.Date, TxtTotal.Text, currentCompany, currentUser)

                    limpiaCamposDataGrid()
                    'PanelFinal.Visible = False
                    MessageBox.Show("RECIBO GUARDADO...")


                Else
                    If txtLiquidacion.Text = "0" Then
                        MessageBox.Show("RECIBO LIQUIDADO.......")
                    Else

                        If checaAnticipo(TxtFolio.Text) Then

                            PanelLiquidar.Show()

                        Else

                            descuento(ComboBoxtipoPago.Text.Substring(0, 2))
                            txtTotalVenta.Text = TxtTotal.Text
                            TxtDescuento.Text = 0
                            txtPago.Text = 0.0
                            txtRecibo.Text = 0.0
                            txtCambio.Text = 0.0
                            PanelFinal.Show()
                            TextDESC.Focus()


                        End If
                    End If
                End If
            Else

                MessageBox.Show("DEBE SELECIONAR UN DOCTOR...")
                ComboBoxDoctores.Focus()
            End If

           
        End If
        If e.KeyValue = Keys.F6 Then
            ' auxiliaryProceed()
            Me.Close()
        End If


    End Sub
    Function descuento(ByVal tipopago As String) As Decimal
        Select Case tipopago
            Case "01"
                'Return 0.0
                TextDESC.Text = "0.0"
                TextDESC.ReadOnly = True
            Case "02"
                TextDESC.Text = "0.0"
                TextDESC.ReadOnly = False
            Case "03"
                'Return 100.0
                TextDESC.Text = "100.0"
                TextDESC.ReadOnly = True
        End Select

    End Function

    'Private WithEvents _MiDGView1 As New DgvPlus     'Mi DGV, que traduce el 'Enter' en 'Tab'

    'Private WithEvents _MiDGView2 As New MiDGView    'Mi DGV, que controla la posicion de la celda actual

    ''

    '' al lanzar nuestro form (en el momento de carga)

    Private Sub recibo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim toolTipbtnBUSCAR As New ToolTip()
        Dim toolTipbtnCOBRAR As New ToolTip()
        Dim toolTipbtnIMPRIMIR As New ToolTip()

        Dim toolTipbtnCancelar As New ToolTip()

        Dim toolTipbtnCANLELARVENTA As New ToolTip()
        Dim toolTipButton1 As New ToolTip()
        'Dim toolTipbtnsalir As New ToolTip()
        DateTimePickerFecha.Text = Now()
        DataGridView1.Rows.Add(15)
        TxtClienteID.Text = TxtClienteID.Text.PadLeft(6, "0")
        LoadCliente()
        TxtClienteID.ReadOnly = False
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue
        Me.DataGridView1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)

        TxtSubtotal.Text = "0.0"
        TxtDescuento.Text = "0.0"
        TxtIva.Text = "0.0"
        TxtTotal.Text = "0.0"
        TOTALV.Text = "0.0"
        toolTipbtnBUSCAR.SetToolTip(btnBuscar, "F2 PARA BUSCAR CLIENTE...")
        toolTipbtnCOBRAR.SetToolTip(BTNCOBRAR, "F5 PARA COBRAR...")
        toolTipbtnIMPRIMIR.SetToolTip(btnImprimir, "CLICK PARA REIMPRIMIR RECIBO...")

        toolTipbtnCancelar.SetToolTip(ButtonCancelar, "CLICK PARA CANCELAR...")
        toolTipbtnCANLELARVENTA.SetToolTip(btnalta_Cliente, "CLICK PARA CANCELAR UNA VENTA...")
        'toolTipButton1.SetToolTip(Button1, "F5 PARA SALIR...")
        ' toolTipbtnsalir.SetToolTip(btnsalir, "Click para Salir...")
        CargaDoctores()
        CargatipoPago()
        TextBoxNombre.Focus()
    End Sub
    Function LoadCliente() As Boolean
        PermanentDB1 = New DataSet()
        queryStringPermanent1 = "select firstName,LastName,street, number, colonyName, zipCode,stateID,telephoneNumber,faxNumber,rfc from clients where clientID='" & TxtClienteID.Text & "' and companyID='" & currentCompany & "'"
        connectionPermanent1 = New SqlConnection(connectionString)
        connectionPermanent1.Open()
        adapterPermanent1 = New SqlDataAdapter
        commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
        adapterPermanent1.SelectCommand = commandPermanent1
        cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
        cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
        adapterPermanent1.Fill(PermanentDB1, "clients")

        If PermanentDB1.Tables(0).Rows.Count > 0 Then
            TextBoxNombre.Text = PermanentDB1.Tables(0).Rows(0).Item(0)

            TxtCiudad.Text = PermanentDB1.Tables(0).Rows(0).Item(2)
            '  TxtNumero.Text = PermanentDB1.Tables(0).Rows(0).Item(3)
            TxtEdad.Text = PermanentDB1.Tables(0).Rows(0).Item(4)

            '  TxtApellidos.Text = PermanentDB1.Tables(0).Rows(0).Item(1)
            '  TxtCP.Text = PermanentDB1.Tables(0).Rows(0).Item(5)
            Dim t As String = PermanentDB1.Tables(0).Rows(0).Item(6)
            TxtTelefono.Text = PermanentDB1.Tables(0).Rows(0).Item(7)

            RCF.Text = PermanentDB1.Tables(0).Rows(0).Item(9)


            PermanentDB1 = New DataSet()
            queryStringPermanent1 = "select description from states where stateID='" & t & "'"
            connectionPermanent1 = New SqlConnection(connectionString)
            connectionPermanent1.Open()
            adapterPermanent1 = New SqlDataAdapter
            commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
            adapterPermanent1.SelectCommand = commandPermanent1
            cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
            cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
            adapterPermanent1.Fill(PermanentDB1, "sates")
            ' ComboBoxEstado.Items.Add(t & " - " & PermanentDB1.Tables(0).Rows(0).Item(0))
            ' ComboBoxEstado.SelectedIndex = 0
            closePermanentDB1()
            TextBoxNombre.ReadOnly = True
            ' TxtApellidos.ReadOnly = True
            TxtClienteID.ReadOnly = True
            'rows(0, 0).ReadOnly = False
            Return True
        Else
            closePermanentDB1()
            Return False
        End If

    End Function
    Sub closePermanentDB1()
        connectionPermanent1.Close()
        PermanentDB1.Clear()
        PermanentDB1.Dispose()
        adapterPermanent1.Dispose()
        PermanentDB1.Clear()
        PermanentDB1.Dispose()
        commandPermanent1.Dispose()
        cmdBuilderPermanent1.Dispose()
    End Sub

    Private Sub txtClienteID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClienteID.KeyPress

        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                Try

                    TxtClienteID.Text = TxtClienteID.Text.PadLeft(6, "0")

                Catch ex As Exception

                End Try
                If LoadCliente() Then
                    DataGridView1.Focus()
                Else
                    TxtClienteID.Text = ""
                    TxtClienteID.Focus()
                End If
            Case Keys.A, Asc("a")

        End Select

    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Sub auxiliaryProceed()
        Dim foliosinterno As String
        Dim remisionFolio As String
        Try
            If newDocument Then
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
                companyParameters.Tables(0).Rows(0).Item(5) += 1 'folio de la remision
                companyParameters.Tables(0).Rows(0).Item(13) += 1
                remisionFolio = CType(companyParameters.Tables(0).Rows(0).Item(5), String)
                foliosinterno = CType(companyParameters.Tables(0).Rows(0).Item(13), String)
                adapterCompanyParameters.Update(companyParameters, "companyParameters")
                companyParameters.Clear()
                companyParameters.Dispose()
                connectionCompanyParameters.Close()
                adapterCompanyParameters.Dispose()
                commandCompanyParameters.Dispose()
                cmdBuilderCompanyParameters.Dispose()
                TxtFolio.Text = remisionFolio.PadLeft(6, "0")
                lblfoliorecibo.Text = foliosinterno.PadLeft(6, "0")
            End If
            invoiceHeaders = New DataSet()
            queryStringInvoiceHeaders = "select * from recibo where companyID='" & currentCompany & "' and idRecibo='" & TxtFolio.Text & "'"
            connectioninvoiceHeaders = New SqlConnection(connectionString)
            connectioninvoiceHeaders.Open()
            adapterInvoiceHeaders = New SqlDataAdapter
            commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
            adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
            cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
            cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
            adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo")
            'Me.invoiceHeaders.WriteXml("encabezadoremision.xml")
            If newDocument Then
                invoiceHeaders.Tables(0).Rows.Add()
            End If
            'invoiceHeaders.Tables(0).Rows(0).Item(0) = currentCompany
            invoiceHeaders.Tables(0).Rows(0).Item(0) = TxtFolio.Text
            invoiceHeaders.Tables(0).Rows(0).Item(1) = ComboBoxtipoPago.Text.Substring(0, 2)
            invoiceHeaders.Tables(0).Rows(0).Item(2) = ComboBoxDoctores.Text.Substring(0, 6)
            invoiceHeaders.Tables(0).Rows(0).Item(3) = TxtClienteID.Text

            invoiceHeaders.Tables(0).Rows(0).Item(4) = DateTimePickerFecha.Text


            invoiceHeaders.Tables(0).Rows(0).Item(5) = TxtSubtotal.Text
            invoiceHeaders.Tables(0).Rows(0).Item(6) = TxtDescuento.Text
            invoiceHeaders.Tables(0).Rows(0).Item(7) = TxtIva.Text
            If ComboBoxtipoPago.Text.Substring(0, 2) = "03" Then
                'invoiceHeaders.Tables(0).Rows(0).Item(8) = TxtDescuento.Text
                invoiceHeaders.Tables(0).Rows(0).Item(8) = TxtTotal.Text
            Else
                invoiceHeaders.Tables(0).Rows(0).Item(8) = TxtTotal.Text
            End If


            invoiceHeaders.Tables(0).Rows(0).Item(9) = convertAmountToString(TxtTotal.Text)
            invoiceHeaders.Tables(0).Rows(0).Item(10) = 1
            invoiceHeaders.Tables(0).Rows(0).Item(11) = currentUser
            invoiceHeaders.Tables(0).Rows(0).Item(12) = currentCompany
            invoiceHeaders.Tables(0).Rows(0).Item(13) = lblfoliorecibo.Text
            ' invoiceHeaders.Tables(0).Rows(0).Item(11) = TxtDireccion.Text & " " & TxtNumero.Text & " " & TxtColonia.Text
            adapterInvoiceHeaders.Update(invoiceHeaders, "recibo")
            ''Me.invoiceHeaders.WriteXml("encabezadoVentas.xml")
            invoiceHeaders.Clear()
            invoiceHeaders.Dispose()
            connectioninvoiceHeaders.Close()
            adapterInvoiceHeaders.Dispose()
            commandInvoiceHeaders.Dispose()
            cmdBuilderInvoiceHeaders.Dispose()

            invoiceRows1 = New DataSet()
            queryStringinvoiceRows = "select * from detalleRecibo where companyID='" & currentCompany & "' and idRecibo='" & TxtFolio.Text & "'"
            connectioninvoiceRows = New SqlConnection(connectionString)
            connectioninvoiceRows.Open()
            adapterinvoiceRows = New SqlDataAdapter
            commandinvoiceRows = New SqlCommand(queryStringinvoiceRows, connectioninvoiceRows)
            adapterinvoiceRows.SelectCommand = commandinvoiceRows
            cmdBuilderinvoiceRows = New SqlCommandBuilder(adapterinvoiceRows)
            cmdBuilderinvoiceRows.ConflictOption = ConflictOption.OverwriteChanges
            adapterinvoiceRows.Fill(invoiceRows1, "detalleRecibo")

            Dim i As Integer = 0
            'Dim s As String
            While i < lastUsed1 - 1

                invoiceRows1.Tables(0).Rows.Add()
                'invoiceRows1.Tables(0).Rows(i).Item(0) = currentCompany ' compania
                invoiceRows1.Tables(0).Rows(i).Item(0) = TxtFolio.Text 'folio
                '  invoiceRows1.Tables(0).Rows(i).Item(2) = DateTimePickerFecha.Text 'fecha
                invoiceRows1.Tables(0).Rows(i).Item(1) = DataGridView1.Rows(i).Cells("clave").Value.ToString 'CODIGO DE PRODUCTO
                invoiceRows1.Tables(0).Rows(i).Item(2) = DataGridView1.Rows(i).Cells("descripcion").Value.ToString 'CANTIDAD
                invoiceRows1.Tables(0).Rows(i).Item(3) = DataGridView1.Rows(i).Cells("tiempo").Value.ToString 'PESCRIPCION
                invoiceRows1.Tables(0).Rows(i).Item(4) = DataGridView1.Rows(i).Cells("proceso").Value.ToString 'PRECIO UNITARIO
                invoiceRows1.Tables(0).Rows(i).Item(5) = DataGridView1.Rows(i).Cells("importe").Value.ToString 'IMPORTE

                invoiceRows1.Tables(0).Rows(i).Item(6) = CType(i.ToString, Integer)

                invoiceRows1.Tables(0).Rows(i).Item(7) = currentCompany
                invoiceRows1.Tables(0).Rows(i).Item(8) = currentUser
                'DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value()
                'companiaId	varchar(6)	0
                'folio		varchar(10)	1
                'fecha		date	2
                'codigo		varchar(25)	3
                'cantidad	decimal(18, 2)	4
                'descripcion	varchar(100)	5
                'precioUnitario	decimal(18, 2)	6
                'monto		decimal(18, 2)	7
                'renglon		int	8
                'clave		varchar(2)	9
                'descuento	decimal(8, 2)	10



                's = CType(i, String)
                'While s.Length < 3
                '    s = "0" & s
                'End While
                'invoiceRows.Tables(0).Rows(i).Item(8) = s
                'invoiceRows.Tables(0).Rows(i).Item(9) = ""
                ''invoiceRows.Tables(0).Rows(i).Item(10) = currentCompany & DateTimePickerReceiptDate.Text & txtFolio.Text & s
                i += 1

            End While
            If newDocument Then
                adapterinvoiceRows.Update(invoiceRows1, "detalleRecibo")
                '     Me.invoiceRows.WriteXml("renglonesVenta.xml")
            End If
            invoiceRows1.Clear()
            invoiceRows1.Dispose()
            connectioninvoiceRows.Close()
            adapterinvoiceRows.Dispose()
            commandinvoiceRows.Dispose()
            cmdBuilderinvoiceRows.Dispose()




            ' frmRemisiones.Show() ' la remsion







        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Sub limpiaCamposDataGrid()
        For i = 0 To lastUsed1
            DataGridView1.Rows(i).Cells("clave").Value = "" 'CODIGO DE PRODUCTO
            DataGridView1.Rows(i).Cells("descripcion").Value = "" 'PESCRIPCION
            DataGridView1.Rows(i).Cells("tiempo").Value = "" 'CANTIDAD
            DataGridView1.Rows(i).Cells("proceso").Value = "" 'PRECIO UNITARIO
            DataGridView1.Rows(i).Cells("importe").Value = "" 'IMPORTE
        Next
        TxtSubtotal.Text = "0.0"
        TxtDescuento.Text = "0"
        TxtIva.Text = "0.0"
        TxtTotal.Text = "0.0"
        TOTALV.Text = "0.0"
        '-------------
        txtSuma.Text = 0.0
        TxtDescuento.Text = 0.0
        txtPago.Text = 0.0
        txtRecibo.Text = 0.0
        txtCambio.Text = 0.0
        txtPago.Text = 0.0
        txtTotalVenta.Text = 0.0
        txtCambio.Text = 0.0
        lastUsed = 0
        DataGridView1.Rows(0).Cells(0).Selected() = True
        ' TxtFolio.Text = ""
        txtRecibo.Text = 0.0
        TextBoxNombre.Text = ""
        TxtCiudad.Text = ""
        txtSexo.Text = ""
        TxtEdad.Text = ""
        TxtClienteID.Text = ""
        RCF.Text = ""
        TxtTelefono.Text = ""
        ComboBoxtipoPago.SelectedIndex = 0
        ComboBoxDoctores.SelectedIndex = 1
        txtAdeudo.Text = "0"
        txtAdeudo.Visible = False
        txtAnticipo.Text = "0"
        txtAnticipo.Visible = False

        lastUsed1 = 0
    End Sub
   

    'Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
    '    Dim cnprod As SqlDataAdapter
    '    Dim dsprod As New DataSet
    '    Dim filap As DataRow
    '    Dim clave As String
    '    Dim cant As Double


    '    Select Case e.ColumnIndex

    '        Case 0
    '            clave = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
    '            cnprod = New SqlDataAdapter("select nombre,precioPublico from catalogo where codigo='" & clave & "'", connectionString)
    '            cnprod.Fill(dsprod, "catalogo")
    '            If dsprod.Tables("catalogo").Rows.Count > 0 Then
    '                filap = dsprod.Tables("catalogo").Rows(0)
    '                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value = filap("nombre")
    '                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value = filap("precioPublico")
    '                Me.DataGridView1.Columns("precio").DefaultCellStyle.Format = "c"
    '                Me.DataGridView1.Columns("precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                SendKeys.Send("{Up}")
    '                SendKeys.Send("{Tab}")


    '            Else
    '                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value = ""
    '                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = ""
    '                SendKeys.Send("{LEFT}")
    '                SendKeys.Send("{Up}")

    '            End If
    '            dsprod.Clear()
    '            dsprod.Dispose()

    '        Case 1
    '            cant = Double.Parse(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value)
    '            If cant > 0 Then
    '                SendKeys.Send("{Up}")
    '                SendKeys.Send("{Tab}")
    '                SendKeys.Send("{Tab}")
    '                SendKeys.Send("{Tab}")
    '                SendKeys.Send("{Tab}")
    '                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value = Double.Parse(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value) * Double.Parse(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value)
    '                Me.DataGridView1.Columns("importe").DefaultCellStyle.Format = "c"
    '                Me.DataGridView1.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                Me.DataGridView1.Columns("precio").DefaultCellStyle.Format = "c"
    '                Me.DataGridView1.Columns("precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                'CALCULAR EL SUB TOTAL
    '                Me.DataGridView1.Columns("cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '                '-----------------------calcular total de venta------------------------
    '                calculaTotal()
    '                lastUsed = lastUsed + 1
    '            Else

    '                SendKeys.Send("{Up}")
    '            End If
    '    End Select
    'End Sub
    Private Sub calculaTotal()
        Dim Temp As Double
        Dim TempSubtotal As Double = 0.0
        Dim tempIVa As Double = 0.0

        Temp = 0
        For i = 0 To 10 - 1
            Try
                Temp = Format(Temp + Double.Parse((DataGridView1.Rows(i).Cells(4).Value)), "##,##0.00")

            Catch ex As Exception
                Temp = (Temp + 0.0)

            End Try
        Next
        tempIVa = Temp * iva

        Temp = Format(Temp, "##,##0.00")
        txtSuma.Text = Temp
        ' SubTotal.Text = Temp.ToString()
        TxtSubtotal.Text = Format((Temp - tempIVa), "##,##0.00")
        TempSubtotal = Temp * iva
        ' iva.Text = Format(Temp * 0.16, "##,##0.00")
        TxtDescuento.Text = "0.0"
        TxtIva.Text = Format(tempIVa, "##,##0.00")

        ' total.Text = Format(Double.Parse(SubTotal.Text) + Double.Parse(iva.Text), "##,##0.00")
        TxtTotal.Text = Format((Double.Parse(TxtSubtotal.Text) + Double.Parse(TxtIva.Text)) - Double.Parse(TxtDescuento.Text), "##,##0.00")
        TOTALV.Text = TxtTotal.Text
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim cont As Integer
        'BsucaProducto.Show()
        'ToolStripStatusLabel1.Text = ""
        'ToolStripStatusLabel1.Visible = False
        cont = DataGridView1.CurrentRow.Index
        'Me.Hide()
        buscaCliente.Show()
        buscaCliente.txtBuscar.Focus()

    End Sub
    Sub closeProductsCatalog()
        connectionProductsCatalog.Close()
        productsCatalog.Clear()
        productsCatalog.Dispose()
        adapterProductsCatalog.Dispose()
        productsCatalog.Clear()
        productsCatalog.Dispose()
        commandProductsCatalog.Dispose()
        cmdBuilderProductsCatalog.Dispose()
    End Sub
    Function consecutivoKardex() As Integer
        Dim consecitivo As Integer
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
        companyParameters.Tables(0).Rows(0).Item(15) += 1
        consecitivo = companyParameters.Tables(0).Rows(0).Item(15)


        adapterCompanyParameters.Update(companyParameters, "companyParameters")
        closeCompanyParameters()
        Return consecitivo
    End Function
    Function consecutivoAnticipo() As Integer
        Dim consecitivo As Integer
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
        companyParameters.Tables(0).Rows(0).Item(6) += 1
        consecitivo = companyParameters.Tables(0).Rows(0).Item(6)


        adapterCompanyParameters.Update(companyParameters, "companyParameters")
        connectionCompanyParameters.Close()
        companyParameters.Clear()
        companyParameters.Dispose()
        adapterCompanyParameters.Dispose()
        companyParameters.Clear()
        companyParameters.Dispose()
        commandCompanyParameters.Dispose()
        cmdBuilderCompanyParameters.Dispose()
        Return consecitivo
    End Function
    Sub closeproductskardex()
        connectionproductsKardex.Close()
        productsKardex.Clear()
        productsKardex.Dispose()
        adapterproductsKardex.Dispose()
        productsKardex.Clear()
        productsKardex.Dispose()
        commandproductsKardex.Dispose()
        cmdBuilderproductsKardex.Dispose()
    End Sub
    Sub closeCompanyParameters()
        connectionCompanyParameters.Close()
        companyParameters.Clear()
        companyParameters.Dispose()
        adapterCompanyParameters.Dispose()
        companyParameters.Clear()
        companyParameters.Dispose()
        commandCompanyParameters.Dispose()
        cmdBuilderCompanyParameters.Dispose()
    End Sub
    Private Sub applyProductsToKardex()
        Dim i, j, KardexInidice, tempProducto, indiceKardex, aux As Integer  'iterador sobre los renglones
        Dim tfolioSalida, lc, fc, ac, tc, saldo As Decimal
        Dim caducidad As Date
        Dim s As String = ""
        Dim cnbr As Decimal
        Dim controlnbr As String = ""
        Dim initialBalance As Decimal = 0
        For i = 0 To lastUsed - 1
            productsCatalog = New DataSet()
            querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
            connectionProductsCatalog = New SqlConnection(connectionString)
            connectionProductsCatalog.Open()
            adapterProductsCatalog = New SqlDataAdapter
            commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
            adapterProductsCatalog.SelectCommand = commandProductsCatalog
            cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
            cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
            adapterProductsCatalog.Fill(productsCatalog, "catalogo")

            tc = CType(DataGridView1.Rows(i).Cells("cant").Value.ToString, Decimal) 'cantidad de producto a sacar de almacén
            initialBalance = productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8) - productsCatalog.Tables(0).Rows(0).Item(9)
            saldo = initialBalance - tc
            If productsCatalog.Tables(0).Rows(0).Item(7) > productsCatalog.Tables(0).Rows(0).Item(9) Then
                If (productsCatalog.Tables(0).Rows(0).Item(7) - productsCatalog.Tables(0).Rows(0).Item(9)) > tc Then
                    productsCatalog.Tables(0).Rows(0).Item(9) += tc 'aplico la salida al catalogo

                    adapterProductsCatalog.Update(productsCatalog, "catalogo") 'Actualiza la base de datos
                    closeProductsCatalog()
                    productsKardex = New DataSet()
                    queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'  and tipo='J' "
                    connectionproductsKardex = New SqlConnection(connectionString)
                    connectionproductsKardex.Open()
                    adapterproductsKardex = New SqlDataAdapter
                    commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                    adapterproductsKardex.SelectCommand = commandproductsKardex
                    cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                    cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                    adapterproductsKardex.Fill(productsKardex, "productsKardex")

                    productsKardex.Tables(0).Rows.Add()

                    productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString
                    productsKardex.Tables(0).Rows(0).Item(1) = 0
                    productsKardex.Tables(0).Rows(0).Item(2) = tc
                    productsKardex.Tables(0).Rows(0).Item(3) = 0.0
                    productsKardex.Tables(0).Rows(0).Item(4) = DataGridView1.Rows(i).Cells("precio").Value.ToString
                    productsKardex.Tables(0).Rows(0).Item(5) = DateTimePickerFecha.Text
                    productsKardex.Tables(0).Rows(0).Item(6) = TxtFolio.Text
                    productsKardex.Tables(0).Rows(0).Item(7) = ""
                    productsKardex.Tables(0).Rows(0).Item(8) = ""
                    productsKardex.Tables(0).Rows(0).Item(9) = "O"
                    productsKardex.Tables(0).Rows(0).Item(10) = "V"
                    productsKardex.Tables(0).Rows(0).Item(11) = "SDO. INIC."
                    productsKardex.Tables(0).Rows(0).Item(12) = saldo
                    productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
                    productsKardex.Tables(0).Rows(0).Item(14) = ""
                    productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
                    productsKardex.Tables(0).Rows(0).Item(16) = 0.0
                    adapterproductsKardex.Update(productsKardex, "productsKardex")
                    closeproductskardex()
                Else
                    productsCatalog = New DataSet()
                    querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                    connectionProductsCatalog = New SqlConnection(connectionString)
                    connectionProductsCatalog.Open()
                    adapterProductsCatalog = New SqlDataAdapter
                    commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                    adapterProductsCatalog.SelectCommand = commandProductsCatalog
                    cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                    cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                    adapterProductsCatalog.Fill(productsCatalog, "catalogo")

                    tc = CType(DataGridView1.Rows(i).Cells("cant").Value.ToString, Decimal) 'cantidad de producto a sacar de almacén
                    tempProducto = productsCatalog.Tables(0).Rows(0).Item(7) - productsCatalog.Tables(0).Rows(0).Item(9)
                    tc = tc - (productsCatalog.Tables(0).Rows(0).Item(7) - productsCatalog.Tables(0).Rows(0).Item(9))
                    initialBalance = productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8) - productsCatalog.Tables(0).Rows(0).Item(9)
                    saldo = initialBalance - tempProducto
                    productsCatalog.Tables(0).Rows(0).Item(9) += tempProducto
                    adapterProductsCatalog.Update(productsCatalog, "catalogo") 'Actualiza la base de datos
                    closeProductsCatalog()

                    productsKardex = New DataSet()
                    queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "'   and tipo='J' "
                    connectionproductsKardex = New SqlConnection(connectionString)
                    connectionproductsKardex.Open()
                    adapterproductsKardex = New SqlDataAdapter
                    commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                    adapterproductsKardex.SelectCommand = commandproductsKardex
                    cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                    cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                    adapterproductsKardex.Fill(productsKardex, "productsKardex")
                    'tem = productsKardex.Tables(0).Rows(0).Item(13)
                    productsKardex.Tables(0).Rows.Add()


                    productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString
                    productsKardex.Tables(0).Rows(0).Item(1) = 0
                    productsKardex.Tables(0).Rows(0).Item(2) = tempProducto
                    productsKardex.Tables(0).Rows(0).Item(3) = 0.0
                    productsKardex.Tables(0).Rows(0).Item(4) = DataGridView1.Rows(i).Cells("precio").Value.ToString
                    productsKardex.Tables(0).Rows(0).Item(5) = DateTimePickerFecha.Text
                    productsKardex.Tables(0).Rows(0).Item(6) = TxtFolio.Text
                    productsKardex.Tables(0).Rows(0).Item(7) = ""
                    productsKardex.Tables(0).Rows(0).Item(8) = ""
                    productsKardex.Tables(0).Rows(0).Item(9) = "O"
                    productsKardex.Tables(0).Rows(0).Item(10) = "V"
                    productsKardex.Tables(0).Rows(0).Item(11) = "SDO. INIC."
                    productsKardex.Tables(0).Rows(0).Item(12) = saldo
                    productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
                    productsKardex.Tables(0).Rows(0).Item(14) = ""
                    productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
                    productsKardex.Tables(0).Rows(0).Item(16) = 0.0
                    adapterproductsKardex.Update(productsKardex, "productsKardex")
                    closeproductskardex()
                    '-----------------------------------------------Iterar hasta consumir la venta en este caso tc
                    While tc > 0
                        productsCatalog = New DataSet()
                        querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                        connectionProductsCatalog = New SqlConnection(connectionString)
                        connectionProductsCatalog.Open()
                        adapterProductsCatalog = New SqlDataAdapter
                        commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                        adapterProductsCatalog.SelectCommand = commandProductsCatalog
                        cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                        cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                        adapterProductsCatalog.Fill(productsCatalog, "catalogo")

                        'cantidad de producto a sacar de almacén
                        ' tempProducto = (productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8)) - productsCatalog.Tables(0).Rows(0).Item(9)
                        ' tc = tc - (productsCatalog.Tables(0).Rows(0).Item(7) - productsCatalog.Tables(0).Rows(0).Item(9))
                        initialBalance = productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8) - productsCatalog.Tables(0).Rows(0).Item(9)
                        '  saldo = initialBalance - tempProducto
                        closeProductsCatalog()
                        PermanentDB1 = New DataSet()
                        queryStringPermanent1 = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "' and tipo='I' and cantidad!=salidas order by fechaOperacion  " '"
                        connectionPermanent1 = New SqlConnection(connectionString)
                        connectionPermanent1.Open()
                        adapterPermanent1 = New SqlDataAdapter
                        commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                        adapterPermanent1.SelectCommand = commandPermanent1
                        cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                        cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                        adapterPermanent1.Fill(PermanentDB1, "productsKardex")

                        If (PermanentDB1.Tables(0).Rows(j).Item(1) - PermanentDB1.Tables(0).Rows(j).Item(2)) < tc Then
                            tempProducto = (PermanentDB1.Tables(0).Rows(j).Item(1) - PermanentDB1.Tables(0).Rows(j).Item(2))
                            tc = tc - tempProducto

                            indiceKardex = PermanentDB1.Tables(0).Rows(j).Item(13)
                            closePermanentDB1()

                            ' saldo = saldo - tempProducto
                            'tc = tc - tempProducto
                            saldo = initialBalance - tempProducto
                            productsKardex = New DataSet()
                            queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'  and consecutivoKardex='" & indiceKardex & "'"
                            connectionproductsKardex = New SqlConnection(connectionString)
                            connectionproductsKardex.Open()
                            adapterproductsKardex = New SqlDataAdapter
                            commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                            adapterproductsKardex.SelectCommand = commandproductsKardex
                            cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                            cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                            adapterproductsKardex.Fill(productsKardex, "productsKardex")
                            productsKardex.Tables(0).Rows(0).Item(2) += tempProducto
                            adapterproductsKardex.Update(productsKardex, "productsKardex")
                            closeproductskardex()

                            '--------------------------------------
                            productsKardex = New DataSet()
                            queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "'   and tipo='J' "
                            connectionproductsKardex = New SqlConnection(connectionString)
                            connectionproductsKardex.Open()
                            adapterproductsKardex = New SqlDataAdapter
                            commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                            adapterproductsKardex.SelectCommand = commandproductsKardex
                            cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                            cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                            adapterproductsKardex.Fill(productsKardex, "productsKardex")
                            'tem = productsKardex.Tables(0).Rows(0).Item(13)
                            productsKardex.Tables(0).Rows.Add()

                            productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString
                            productsKardex.Tables(0).Rows(0).Item(1) = 0
                            productsKardex.Tables(0).Rows(0).Item(2) = tempProducto
                            productsKardex.Tables(0).Rows(0).Item(3) = 0.0
                            productsKardex.Tables(0).Rows(0).Item(4) = DataGridView1.Rows(i).Cells("precio").Value.ToString
                            productsKardex.Tables(0).Rows(0).Item(5) = DateTimePickerFecha.Text
                            productsKardex.Tables(0).Rows(0).Item(6) = TxtFolio.Text
                            productsKardex.Tables(0).Rows(0).Item(7) = ""
                            productsKardex.Tables(0).Rows(0).Item(8) = ""
                            productsKardex.Tables(0).Rows(0).Item(9) = "O"
                            productsKardex.Tables(0).Rows(0).Item(10) = "V"
                            productsKardex.Tables(0).Rows(0).Item(11) = indiceKardex
                            productsKardex.Tables(0).Rows(0).Item(12) = saldo
                            productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
                            productsKardex.Tables(0).Rows(0).Item(14) = ""
                            productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
                            productsKardex.Tables(0).Rows(0).Item(16) = 0.0
                            adapterproductsKardex.Update(productsKardex, "productsKardex")
                            closeproductskardex()

                            productsCatalog = New DataSet()
                            querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                            connectionProductsCatalog = New SqlConnection(connectionString)
                            connectionProductsCatalog.Open()
                            adapterProductsCatalog = New SqlDataAdapter
                            commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                            adapterProductsCatalog.SelectCommand = commandProductsCatalog
                            cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                            cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                            adapterProductsCatalog.Fill(productsCatalog, "catalogo")

                            productsCatalog.Tables(0).Rows(0).Item(9) += tempProducto
                            adapterProductsCatalog.Update(productsCatalog, "catalogo") 'Actualiza la base de datos
                            closeProductsCatalog()
                        Else

                            PermanentDB1 = New DataSet()
                            queryStringPermanent1 = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "' and tipo='I' and cantidad!=salidas order by fechaOperacion  " '"
                            connectionPermanent1 = New SqlConnection(connectionString)
                            connectionPermanent1.Open()
                            adapterPermanent1 = New SqlDataAdapter
                            commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                            adapterPermanent1.SelectCommand = commandPermanent1
                            cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                            cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                            adapterPermanent1.Fill(PermanentDB1, "productsKardex")

                            tempProducto = PermanentDB1.Tables(0).Rows(j).Item(1) - PermanentDB1.Tables(0).Rows(j).Item(2)
                            indiceKardex = PermanentDB1.Tables(0).Rows(j).Item(13)
                            closePermanentDB1()
                            'Aqui tengo que afectar el catalogo
                            productsCatalog = New DataSet()
                            querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                            connectionProductsCatalog = New SqlConnection(connectionString)
                            connectionProductsCatalog.Open()
                            adapterProductsCatalog = New SqlDataAdapter
                            commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                            adapterProductsCatalog.SelectCommand = commandProductsCatalog
                            cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                            cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                            adapterProductsCatalog.Fill(productsCatalog, "catalogo")
                            initialBalance = productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8) - productsCatalog.Tables(0).Rows(0).Item(9)
                            saldo = initialBalance - tc
                            productsCatalog.Tables(0).Rows(0).Item(9) += tc
                            adapterProductsCatalog.Update(productsCatalog, "catalogo") 'Actualiza la base de datos
                            closeProductsCatalog()

                            productsKardex = New DataSet()
                            queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'  and consecutivoKardex='" & indiceKardex & "'"
                            connectionproductsKardex = New SqlConnection(connectionString)
                            connectionproductsKardex.Open()
                            adapterproductsKardex = New SqlDataAdapter
                            commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                            adapterproductsKardex.SelectCommand = commandproductsKardex
                            cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                            cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                            adapterproductsKardex.Fill(productsKardex, "productsKardex")
                            productsKardex.Tables(0).Rows(0).Item(2) += tc
                            adapterproductsKardex.Update(productsKardex, "productsKardex")
                            closeproductskardex()
                            productsKardex = New DataSet()
                            queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "'   and tipo='J' "
                            connectionproductsKardex = New SqlConnection(connectionString)
                            connectionproductsKardex.Open()
                            adapterproductsKardex = New SqlDataAdapter
                            commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                            adapterproductsKardex.SelectCommand = commandproductsKardex
                            cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                            cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                            adapterproductsKardex.Fill(productsKardex, "productsKardex")
                            'tem = productsKardex.Tables(0).Rows(0).Item(13)
                            productsKardex.Tables(0).Rows.Add()

                            productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString
                            productsKardex.Tables(0).Rows(0).Item(1) = 0
                            productsKardex.Tables(0).Rows(0).Item(2) = tc
                            productsKardex.Tables(0).Rows(0).Item(3) = 0.0
                            productsKardex.Tables(0).Rows(0).Item(4) = DataGridView1.Rows(i).Cells("precio").Value.ToString
                            productsKardex.Tables(0).Rows(0).Item(5) = DateTimePickerFecha.Text
                            productsKardex.Tables(0).Rows(0).Item(6) = TxtFolio.Text
                            productsKardex.Tables(0).Rows(0).Item(7) = ""
                            productsKardex.Tables(0).Rows(0).Item(8) = ""
                            productsKardex.Tables(0).Rows(0).Item(9) = "O"
                            productsKardex.Tables(0).Rows(0).Item(10) = "V"
                            productsKardex.Tables(0).Rows(0).Item(11) = indiceKardex
                            productsKardex.Tables(0).Rows(0).Item(12) = saldo
                            productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
                            productsKardex.Tables(0).Rows(0).Item(14) = ""
                            productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
                            productsKardex.Tables(0).Rows(0).Item(16) = 0
                            adapterproductsKardex.Update(productsKardex, "productsKardex")
                            closeproductskardex()
                            tc = 0
                        End If

                    End While
                    '------------------------------------------------

                End If
            Else 'Cuando ya no tenemos saldo inicial
                While tc > 0
                    productsCatalog = New DataSet()
                    querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                    connectionProductsCatalog = New SqlConnection(connectionString)
                    connectionProductsCatalog.Open()
                    adapterProductsCatalog = New SqlDataAdapter
                    commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                    adapterProductsCatalog.SelectCommand = commandProductsCatalog
                    cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                    cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                    adapterProductsCatalog.Fill(productsCatalog, "catalogo")

                    'cantidad de producto a sacar de almacén
                    ' tempProducto = (productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8)) - productsCatalog.Tables(0).Rows(0).Item(9)
                    ' tc = tc - (productsCatalog.Tables(0).Rows(0).Item(7) - productsCatalog.Tables(0).Rows(0).Item(9))
                    initialBalance = productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8) - productsCatalog.Tables(0).Rows(0).Item(9)
                    '  saldo = initialBalance - tempProducto
                    closeProductsCatalog()
                    PermanentDB1 = New DataSet()
                    queryStringPermanent1 = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "' and tipo='I' and cantidad!=salidas order by fechaOperacion  " '"
                    connectionPermanent1 = New SqlConnection(connectionString)
                    connectionPermanent1.Open()
                    adapterPermanent1 = New SqlDataAdapter
                    commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                    adapterPermanent1.SelectCommand = commandPermanent1
                    cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                    cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                    adapterPermanent1.Fill(PermanentDB1, "productsKardex")

                    If (PermanentDB1.Tables(0).Rows(j).Item(1) - PermanentDB1.Tables(0).Rows(j).Item(2)) < tc Then
                        tempProducto = (PermanentDB1.Tables(0).Rows(j).Item(1) - PermanentDB1.Tables(0).Rows(j).Item(2))
                        tc = tc - tempProducto

                        indiceKardex = PermanentDB1.Tables(0).Rows(j).Item(13)
                        closePermanentDB1()

                        ' saldo = saldo - tempProducto
                        'tc = tc - tempProducto
                        saldo = initialBalance - tempProducto
                        productsKardex = New DataSet()
                        queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'  and consecutivoKardex='" & indiceKardex & "'"
                        connectionproductsKardex = New SqlConnection(connectionString)
                        connectionproductsKardex.Open()
                        adapterproductsKardex = New SqlDataAdapter
                        commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                        adapterproductsKardex.SelectCommand = commandproductsKardex
                        cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                        cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                        adapterproductsKardex.Fill(productsKardex, "productsKardex")
                        productsKardex.Tables(0).Rows(0).Item(2) += tempProducto
                        adapterproductsKardex.Update(productsKardex, "productsKardex")
                        closeproductskardex()

                        '--------------------------------------
                        productsKardex = New DataSet()
                        queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "'   and tipo='J' "
                        connectionproductsKardex = New SqlConnection(connectionString)
                        connectionproductsKardex.Open()
                        adapterproductsKardex = New SqlDataAdapter
                        commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                        adapterproductsKardex.SelectCommand = commandproductsKardex
                        cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                        cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                        adapterproductsKardex.Fill(productsKardex, "productsKardex")
                        'tem = productsKardex.Tables(0).Rows(0).Item(13)
                        productsKardex.Tables(0).Rows.Add()

                        productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString
                        productsKardex.Tables(0).Rows(0).Item(1) = 0
                        productsKardex.Tables(0).Rows(0).Item(2) = tempProducto
                        productsKardex.Tables(0).Rows(0).Item(3) = 0.0
                        productsKardex.Tables(0).Rows(0).Item(4) = DataGridView1.Rows(i).Cells("precio").Value.ToString
                        productsKardex.Tables(0).Rows(0).Item(5) = DateTimePickerFecha.Text
                        productsKardex.Tables(0).Rows(0).Item(6) = TxtFolio.Text
                        productsKardex.Tables(0).Rows(0).Item(7) = ""
                        productsKardex.Tables(0).Rows(0).Item(8) = ""
                        productsKardex.Tables(0).Rows(0).Item(9) = "O"
                        productsKardex.Tables(0).Rows(0).Item(10) = "V"
                        productsKardex.Tables(0).Rows(0).Item(11) = indiceKardex
                        productsKardex.Tables(0).Rows(0).Item(12) = saldo
                        productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
                        productsKardex.Tables(0).Rows(0).Item(14) = ""
                        productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
                        productsKardex.Tables(0).Rows(0).Item(16) = 0
                        adapterproductsKardex.Update(productsKardex, "productsKardex")
                        closeproductskardex()

                        productsCatalog = New DataSet()
                        querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                        connectionProductsCatalog = New SqlConnection(connectionString)
                        connectionProductsCatalog.Open()
                        adapterProductsCatalog = New SqlDataAdapter
                        commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                        adapterProductsCatalog.SelectCommand = commandProductsCatalog
                        cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                        cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                        adapterProductsCatalog.Fill(productsCatalog, "catalogo")

                        productsCatalog.Tables(0).Rows(0).Item(9) += tempProducto
                        adapterProductsCatalog.Update(productsCatalog, "catalogo") 'Actualiza la base de datos
                        closeProductsCatalog()
                    Else

                        PermanentDB1 = New DataSet()
                        queryStringPermanent1 = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "' and tipo='I' and cantidad!=salidas order by fechaOperacion  " '"
                        connectionPermanent1 = New SqlConnection(connectionString)
                        connectionPermanent1.Open()
                        adapterPermanent1 = New SqlDataAdapter
                        commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                        adapterPermanent1.SelectCommand = commandPermanent1
                        cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                        cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                        adapterPermanent1.Fill(PermanentDB1, "productsKardex")

                        tempProducto = PermanentDB1.Tables(0).Rows(j).Item(1) - PermanentDB1.Tables(0).Rows(j).Item(2)
                        indiceKardex = PermanentDB1.Tables(0).Rows(j).Item(13)
                        closePermanentDB1()
                        'Aqui tengo que afectar el catalogo
                        productsCatalog = New DataSet()
                        querystringProductsCatalog = "select * from catalogo where companiaId='" & currentCompany & "' and codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'"
                        connectionProductsCatalog = New SqlConnection(connectionString)
                        connectionProductsCatalog.Open()
                        adapterProductsCatalog = New SqlDataAdapter
                        commandProductsCatalog = New SqlCommand(querystringProductsCatalog, connectionProductsCatalog)
                        adapterProductsCatalog.SelectCommand = commandProductsCatalog
                        cmdBuilderProductsCatalog = New SqlCommandBuilder(adapterProductsCatalog)
                        cmdBuilderProductsCatalog.ConflictOption = ConflictOption.OverwriteChanges
                        adapterProductsCatalog.Fill(productsCatalog, "catalogo")
                        initialBalance = productsCatalog.Tables(0).Rows(0).Item(7) + productsCatalog.Tables(0).Rows(0).Item(8) - productsCatalog.Tables(0).Rows(0).Item(9)
                        saldo = initialBalance - tc
                        productsCatalog.Tables(0).Rows(0).Item(9) += tc
                        adapterProductsCatalog.Update(productsCatalog, "catalogo") 'Actualiza la base de datos
                        closeProductsCatalog()

                        productsKardex = New DataSet()
                        queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "' and codigoBarras='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "'  and consecutivoKardex='" & indiceKardex & "'"
                        connectionproductsKardex = New SqlConnection(connectionString)
                        connectionproductsKardex.Open()
                        adapterproductsKardex = New SqlDataAdapter
                        commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                        adapterproductsKardex.SelectCommand = commandproductsKardex
                        cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                        cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                        adapterproductsKardex.Fill(productsKardex, "productsKardex")
                        productsKardex.Tables(0).Rows(0).Item(2) += tc
                        adapterproductsKardex.Update(productsKardex, "productsKardex")
                        closeproductskardex()
                        productsKardex = New DataSet()
                        queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "'   and tipo='J' "
                        connectionproductsKardex = New SqlConnection(connectionString)
                        connectionproductsKardex.Open()
                        adapterproductsKardex = New SqlDataAdapter
                        commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
                        adapterproductsKardex.SelectCommand = commandproductsKardex
                        cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
                        cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
                        adapterproductsKardex.Fill(productsKardex, "productsKardex")
                        'tem = productsKardex.Tables(0).Rows(0).Item(13)
                        productsKardex.Tables(0).Rows.Add()

                        productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString
                        productsKardex.Tables(0).Rows(0).Item(1) = 0
                        productsKardex.Tables(0).Rows(0).Item(2) = tc
                        productsKardex.Tables(0).Rows(0).Item(3) = 0.0 ' PONER PRECIO DE COSTO
                        productsKardex.Tables(0).Rows(0).Item(4) = DataGridView1.Rows(i).Cells("precio").Value.ToString
                        productsKardex.Tables(0).Rows(0).Item(5) = DateTimePickerFecha.Text
                        productsKardex.Tables(0).Rows(0).Item(6) = TxtFolio.Text
                        productsKardex.Tables(0).Rows(0).Item(7) = ""
                        productsKardex.Tables(0).Rows(0).Item(8) = ""
                        productsKardex.Tables(0).Rows(0).Item(9) = "O"
                        productsKardex.Tables(0).Rows(0).Item(10) = "V"
                        productsKardex.Tables(0).Rows(0).Item(11) = indiceKardex
                        productsKardex.Tables(0).Rows(0).Item(12) = saldo
                        productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
                        productsKardex.Tables(0).Rows(0).Item(14) = ""
                        productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
                        productsKardex.Tables(0).Rows(0).Item(16) = 0
                        adapterproductsKardex.Update(productsKardex, "productsKardex")
                        closeproductskardex()
                        tc = 0
                    End If

                End While

            End If
        Next


    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Dim i As Integer
        Select Case e.KeyValue
            Case Keys.B
                If DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value <> "" Then
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = ""
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value = ""
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value = ""
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value = ""
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value = ""
                    For i = DataGridView1.CurrentRow.Index To DataGridView1.RowCount - 2
                        DataGridView1.Rows(i).Cells(0).Value = DataGridView1.Rows(i + 1).Cells(0).Value
                        DataGridView1.Rows(i).Cells(1).Value = DataGridView1.Rows(i + 1).Cells(1).Value
                        DataGridView1.Rows(i).Cells(2).Value = DataGridView1.Rows(i + 1).Cells(2).Value
                        DataGridView1.Rows(i).Cells(3).Value = DataGridView1.Rows(i + 1).Cells(3).Value
                        DataGridView1.Rows(i).Cells(4).Value = DataGridView1.Rows(i + 1).Cells(4).Value
                    Next
                    calculaTotal()

                End If
        End Select
    End Sub

    Private Sub BTNCOBRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCOBRAR.Click
        If ComboBoxDoctores.Text.Substring(0, 6) <> "SELECC" Then
            txtTotalVenta.Text = TxtTotal.Text
            TxtDescuento.Text = 0.0
            txtPago.Text = 0.0
            PanelFinal.Show()
            TxtDescuento.Focus()
        Else
            MessageBox.Show("DEBE SELECCIONAR UN DOCTOR...")
            ComboBoxDoctores.Focus()
        End If
      
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        
        auxiliaryProceed()
        'applyProductsToKardex()
        'frmRemisiones.Show()
        If Decimal.Parse(txtPago.Text) < Decimal.Parse(TxtTotal.Text) Then
            guardaAnticipo(TxtFolio.Text, consecutivoAnticipo(), Now.Date, txtPago.Text, currentCompany, currentUser)
        End If
        cargaRecivo(TxtFolio.Text)
        FormReciboImp.Show()
        limpiaCamposDataGrid()
        PanelFinal.Visible = False
    End Sub
    Private Sub cargaRecivo(ByVal FOLIO As String)
        txtSuma.Text = 0
        Dim indiceDoctor As Integer = 0
        Dim indiceTipoPago As Integer = 0
        Dim s As String
        Dim i As Integer

        If TxtFolio.Text.Length > 0 Then
            'btnImprimir.Enabled = True     CAMBIAR POR BOTON PARA REIMPRIMIR REMISION

            Try
                s = CType(TxtFolio.Text, Integer)
                While s.Length < 6
                    s = "0" & s
                End While
                TxtFolio.Text = s
            Catch ex As Exception
            End Try
            Try
                invoiceHeaders = New DataSet()
                queryStringInvoiceHeaders = "select * from recibo where companyID='" & currentCompany & "' and idRecibo='" & FOLIO & "'"
                connectioninvoiceHeaders = New SqlConnection(connectionString)
                connectioninvoiceHeaders.Open()
                adapterInvoiceHeaders = New SqlDataAdapter
                commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
                adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
                cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
                cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
                adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo")
                If invoiceHeaders.Tables(0).Rows.Count > 0 Then

                    ToolStripStatusLabel1.Text = ""
                    ToolStripStatusLabel1.Visible = False
                    TxtFolio.ReadOnly = True

                    indiceTipoPago = ComboBoxtipoPago.FindString(invoiceHeaders.Tables(0).Rows(0).Item(1))
                    ComboBoxtipoPago.SelectedIndex = indiceTipoPago

                    indiceDoctor = ComboBoxDoctores.FindString(invoiceHeaders.Tables(0).Rows(0).Item(2))
                    ComboBoxDoctores.SelectedIndex = indiceDoctor
                    lbltipopago.Text = invoiceHeaders.Tables(0).Rows(0).Item(1)

                    TxtSubtotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(5)
                    TxtDescuento.Text = invoiceHeaders.Tables(0).Rows(0).Item(6)
                    TxtIva.Text = invoiceHeaders.Tables(0).Rows(0).Item(7)
                    TxtTotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(8)

                    txtDocumentAmount.Text = invoiceHeaders.Tables(0).Rows(0).Item(9)
                    txtFolioInterno.Text = invoiceHeaders.Tables(0).Rows(0).Item(13)
                    'If invoiceHeaders.Tables(0).Rows(0).Item(9) = False Then
                    '    'btnCancelaVenta.Enabled = False
                    'Else
                    '    ' btnCancelaVenta.Enabled = True
                    'End If
                    clients = New DataSet()
                    queryStringClients = "select * from clients where companyID='" & currentCompany & "' and clientID='" & invoiceHeaders.Tables(0).Rows(0).Item(3) & "'"
                    connectionClients = New SqlConnection(connectionString)
                    connectionClients.Open()
                    adapterClients = New SqlDataAdapter
                    commandClients = New SqlCommand(queryStringClients, connectionClients)
                    adapterClients.SelectCommand = commandClients
                    cmdBuilderClients = New SqlCommandBuilder(adapterClients)
                    cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
                    adapterClients.Fill(clients, "Clients")
                    TxtClienteID.Text = clients.Tables(0).Rows(0).Item(0)
                    TextBoxNombre.Text = clients.Tables(0).Rows(0).Item(1)
                    RCF.Text = clients.Tables(0).Rows(0).Item(3)
                    TxtCiudad.Text = clients.Tables(0).Rows(0).Item(7)
                    'TxtNumero.Text = clients.Tables(0).Rows(0).Item(5)
                    TxtEdad.Text = clients.Tables(0).Rows(0).Item(19)

                    '  TxtApellidos.Text = clients.Tables(0).Rows(0).Item(2)
                    '  TxtCP.Text = clients.Tables(0).Rows(0).Item(9)
                    TxtTelefono.Text = clients.Tables(0).Rows(0).Item(11)
                    txtSexo.Text = clients.Tables(0).Rows(0).Item(20)



                    PermanentDB1 = New DataSet()
                    queryStringPermanent1 = "select description from states where stateID='" & clients.Tables(0).Rows(0).Item(10) & "'"
                    connectionPermanent1 = New SqlConnection(connectionString)
                    connectionPermanent1.Open()
                    adapterPermanent1 = New SqlDataAdapter
                    commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                    adapterPermanent1.SelectCommand = commandPermanent1
                    cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                    cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                    adapterPermanent1.Fill(PermanentDB1, "states")

                    closePermanentDB1()

                    invoiceRows1 = New DataSet()
                    queryStringinvoiceRows = "select * from detalleRecibo where companyID='" & currentCompany & "' and idRecibo='" & FOLIO & "'"
                    connectioninvoiceRows = New SqlConnection(connectionString)
                    connectioninvoiceRows.Open()
                    adapterinvoiceRows = New SqlDataAdapter
                    commandinvoiceRows = New SqlCommand(queryStringinvoiceRows, connectioninvoiceRows)
                    adapterinvoiceRows.SelectCommand = commandinvoiceRows
                    cmdBuilderinvoiceRows = New SqlCommandBuilder(adapterinvoiceRows)
                    cmdBuilderinvoiceRows.ConflictOption = ConflictOption.OverwriteChanges
                    adapterinvoiceRows.Fill(invoiceRows1, "detalleRecibo")
                    cuenta = invoiceRows1.Tables(0).Rows.Count
                    For i = 0 To invoiceRows1.Tables(0).Rows.Count - 1

                        DataGridView1.Rows(i).Cells("clave").Value = invoiceRows1.Tables(0).Rows(i).Item(1)  'CODIGO DE PRODUCTO
                        DataGridView1.Rows(i).Cells("descripcion").Value = invoiceRows1.Tables(0).Rows(i).Item(2)  'CODIGO DE PRODUCTO
                        DataGridView1.Rows(i).Cells("tiempo").Value = invoiceRows1.Tables(0).Rows(i).Item(3)  'CANTIDAD
                        DataGridView1.Rows(i).Cells("proceso").Value = invoiceRows1.Tables(0).Rows(i).Item(4) 'PESCRIPCION
                        DataGridView1.Rows(i).Cells("importe").Value = invoiceRows1.Tables(0).Rows(i).Item(5)  'PRECIO UNITARIO

                        lastUsed1 = i
                        txtSuma.Text = invoiceRows1.Tables(0).Rows(i).Item(5) + Decimal.Parse(txtSuma.Text)
                    Next
                    If lbltipopago.Text = "03" Then


                    Else
                        If checaAnticipo(TxtFolio.Text) Then

                            txtAnticipo.Text = "ANTICIPO : $ " + Format$(Val(txtAdeudo.Text), "##,##0.00")
                            txtAnticipo.Visible = True
                            txtLiquidacion.Text = TxtTotal.Text - txtAdeudo.Text

                            txtAdeudo.Text = TxtTotal.Text - txtAdeudo.Text
                            txtestadorecib.Text = ""
                            txtestadorecib.Visible = False
                            If Decimal.Parse(txtAdeudo.Text) = 0 Then
                                btnLiquidar.Enabled = False


                            Else
                                btnLiquidar.Enabled = True
                            End If
                            txtAdeudo.Text = "ADEUDO : $ " + Format$(Val(txtAdeudo.Text), "##,##0.00")
                        Else
                            txtAnticipo.Text = " "
                            txtAnticipo.Visible = False
                            txtAdeudo.Text = " "
                            txtAdeudo.Visible = False
                            txtestadorecib.Text = "LIQUIDADO..."
                            txtestadorecib.Visible = True
                        End If
                    End If

                    btnImprimir.Enabled = True
                    connectioninvoiceRows.Close()
                    adapterinvoiceRows.Dispose()
                Else

                    ToolStripStatusLabel1.Text = "Error: El folio no existe!!!"
                    ToolStripStatusLabel1.Visible = True
                    'ToolStripStatusLabel1.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show("ERROR AL BUSCAR EL RECIBO...")
            End Try

        End If


    End Sub
    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress
        txtSuma.Text = 0
        Dim indiceDoctor As Integer = 0
        Dim indiceTipoPago As Integer = 0
        Dim s As String
        Dim i As Integer
        If Asc(e.KeyChar) = Keys.Enter Then
            If TxtFolio.Text.Length > 0 Then
                'btnImprimir.Enabled = True     CAMBIAR POR BOTON PARA REIMPRIMIR REMISION

                Try
                    s = CType(TxtFolio.Text, Integer)
                    While s.Length < 6
                        s = "0" & s
                    End While
                    TxtFolio.Text = s
                Catch ex As Exception
                End Try
                Try
                    invoiceHeaders = New DataSet()
                    queryStringInvoiceHeaders = "select * from recibo where companyID='" & currentCompany & "' and idRecibo='" & TxtFolio.Text & "'"
                    connectioninvoiceHeaders = New SqlConnection(connectionString)
                    connectioninvoiceHeaders.Open()
                    adapterInvoiceHeaders = New SqlDataAdapter
                    commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
                    adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
                    cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
                    cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
                    adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo")
                    If invoiceHeaders.Tables(0).Rows.Count > 0 Then
                       
                        ToolStripStatusLabel1.Text = ""
                        ToolStripStatusLabel1.Visible = False
                        TxtFolio.ReadOnly = True

                        indiceTipoPago = ComboBoxtipoPago.FindString(invoiceHeaders.Tables(0).Rows(0).Item(1))
                        ComboBoxtipoPago.SelectedIndex = indiceTipoPago

                        indiceDoctor = ComboBoxDoctores.FindString(invoiceHeaders.Tables(0).Rows(0).Item(2))
                        ComboBoxDoctores.SelectedIndex = indiceDoctor
                        lbltipopago.Text = invoiceHeaders.Tables(0).Rows(0).Item(1)

                        TxtSubtotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(5)
                        TxtDescuento.Text = invoiceHeaders.Tables(0).Rows(0).Item(6)
                        TxtIva.Text = invoiceHeaders.Tables(0).Rows(0).Item(7)
                        TxtTotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(8)

                        txtDocumentAmount.Text = invoiceHeaders.Tables(0).Rows(0).Item(9)
                        txtFolioInterno.Text = invoiceHeaders.Tables(0).Rows(0).Item(13)
                        'If invoiceHeaders.Tables(0).Rows(0).Item(9) = False Then
                        '    'btnCancelaVenta.Enabled = False
                        'Else
                        '    ' btnCancelaVenta.Enabled = True
                        'End If
                        clients = New DataSet()
                        queryStringClients = "select * from clients where companyID='" & currentCompany & "' and clientID='" & invoiceHeaders.Tables(0).Rows(0).Item(3) & "'"
                        connectionClients = New SqlConnection(connectionString)
                        connectionClients.Open()
                        adapterClients = New SqlDataAdapter
                        commandClients = New SqlCommand(queryStringClients, connectionClients)
                        adapterClients.SelectCommand = commandClients
                        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
                        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
                        adapterClients.Fill(clients, "Clients")
                        TxtClienteID.Text = clients.Tables(0).Rows(0).Item(0)
                        TextBoxNombre.Text = clients.Tables(0).Rows(0).Item(1)
                        RCF.Text = clients.Tables(0).Rows(0).Item(3)
                        TxtCiudad.Text = clients.Tables(0).Rows(0).Item(7)
                        'TxtNumero.Text = clients.Tables(0).Rows(0).Item(5)
                        TxtEdad.Text = clients.Tables(0).Rows(0).Item(19)

                        '  TxtApellidos.Text = clients.Tables(0).Rows(0).Item(2)
                        '  TxtCP.Text = clients.Tables(0).Rows(0).Item(9)
                        TxtTelefono.Text = clients.Tables(0).Rows(0).Item(11)
                        txtSexo.Text = clients.Tables(0).Rows(0).Item(20)



                        PermanentDB1 = New DataSet()
                        queryStringPermanent1 = "select description from states where stateID='" & clients.Tables(0).Rows(0).Item(10) & "'"
                        connectionPermanent1 = New SqlConnection(connectionString)
                        connectionPermanent1.Open()
                        adapterPermanent1 = New SqlDataAdapter
                        commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                        adapterPermanent1.SelectCommand = commandPermanent1
                        cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                        cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                        adapterPermanent1.Fill(PermanentDB1, "states")

                        closePermanentDB1()

                        invoiceRows1 = New DataSet()
                        queryStringinvoiceRows = "select * from detalleRecibo where companyID='" & currentCompany & "' and idRecibo='" & TxtFolio.Text & "'"
                        connectioninvoiceRows = New SqlConnection(connectionString)
                        connectioninvoiceRows.Open()
                        adapterinvoiceRows = New SqlDataAdapter
                        commandinvoiceRows = New SqlCommand(queryStringinvoiceRows, connectioninvoiceRows)
                        adapterinvoiceRows.SelectCommand = commandinvoiceRows
                        cmdBuilderinvoiceRows = New SqlCommandBuilder(adapterinvoiceRows)
                        cmdBuilderinvoiceRows.ConflictOption = ConflictOption.OverwriteChanges
                        adapterinvoiceRows.Fill(invoiceRows1, "detalleRecibo")
                        cuenta = invoiceRows1.Tables(0).Rows.Count
                        For i = 0 To invoiceRows1.Tables(0).Rows.Count - 1

                            DataGridView1.Rows(i).Cells("clave").Value = invoiceRows1.Tables(0).Rows(i).Item(1)  'CODIGO DE PRODUCTO
                            DataGridView1.Rows(i).Cells("descripcion").Value = invoiceRows1.Tables(0).Rows(i).Item(2)  'CODIGO DE PRODUCTO
                            DataGridView1.Rows(i).Cells("tiempo").Value = invoiceRows1.Tables(0).Rows(i).Item(3)  'CANTIDAD
                            DataGridView1.Rows(i).Cells("proceso").Value = invoiceRows1.Tables(0).Rows(i).Item(4) 'PESCRIPCION
                            DataGridView1.Rows(i).Cells("importe").Value = invoiceRows1.Tables(0).Rows(i).Item(5)  'PRECIO UNITARIO
                            
                            lastUsed1 = i
                            txtSuma.Text = invoiceRows1.Tables(0).Rows(i).Item(5) + Decimal.Parse(txtSuma.Text)
                        Next
                        If lbltipopago.Text = "03" Then


                        Else
                            If checaAnticipo(TxtFolio.Text) Then

                                txtAnticipo.Text = "ANTICIPO : $ " + Format$(Val(txtAdeudo.Text), "##,##0.00")
                                txtAnticipo.Visible = True
                                txtLiquidacion.Text = TxtTotal.Text - txtAdeudo.Text

                                txtAdeudo.Text = TxtTotal.Text - txtAdeudo.Text
                                txtestadorecib.Text = ""
                                txtestadorecib.Visible = False
                                If Decimal.Parse(txtAdeudo.Text) = 0 Then
                                    btnLiquidar.Enabled = False
                                    

                                Else
                                    btnLiquidar.Enabled = True
                                End If
                                txtAdeudo.Text = "ADEUDO : $ " + Format$(Val(txtAdeudo.Text), "##,##0.00")
                            Else
                                txtAnticipo.Text = " "
                                txtAnticipo.Visible = False
                                txtAdeudo.Text = " "
                                txtAdeudo.Visible = False
                                txtestadorecib.Text = "LIQUIDADO..."
                                txtestadorecib.Visible = True
                            End If
                        End If
                       
                        btnImprimir.Enabled = True
                        connectioninvoiceRows.Close()
                        adapterinvoiceRows.Dispose()
                    Else

                        ToolStripStatusLabel1.Text = "Error: El folio no existe!!!"
                        ToolStripStatusLabel1.Visible = True
                        'ToolStripStatusLabel1.Focus()
                    End If

                Catch ex As Exception
                    MessageBox.Show("ERROR AL BUSCAR EL RECIBO...")
                End Try

            End If

        End If
    End Sub
    Function checaAnticipo(ByVal folio As String) As Boolean
        Try
            anticipos = New DataSet()
            connectionanticipos = New SqlConnection(connectionString)
            queryStringCompanies = "select SUM(importe) from anticipos where idRecibo='" & folio & "' and companyID='" & currentCompany & "'"
            connectionanticipos.Open()
            adapteranticipos = New SqlDataAdapter
            commandanticipos = New SqlCommand(queryStringCompanies, connectionanticipos)
            adapteranticipos.SelectCommand = commandanticipos
            cmdBuilderanticipos = New SqlCommandBuilder(adapteranticipos)
            cmdBuilderanticipos.ConflictOption = ConflictOption.OverwriteChanges
            adapteranticipos.Fill(anticipos, "anticipos")

            If anticipos.Tables(0).Rows(0).Item(0) >= 0 Then

                txtAdeudo.Text = anticipos.Tables(0).Rows(0).Item(0)
                txtAdeudo.Visible = True

                Return True
            Else
                txtAdeudo.Text = ""
                txtAdeudo.Visible = False
                Return False
            End If


        Catch ex As Exception
            txtAdeudo.Text = 0
            btnLiquidar.Enabled = False
        End Try
        


        anticipos.Clear()
        anticipos.Dispose()
        connectionanticipos.Close()
        adapteranticipos.Dispose()
        commandanticipos.Dispose()
        cmdBuilderanticipos.Dispose()
    End Function
    Private Sub CargaDoctores()
        Dim i As Integer


        doctores = New DataSet()
        connectionDoctores = New SqlConnection(connectionString)
        queryStringCompanies = "select * from doctores where companyID='" & currentCompany & "'"
        connectionDoctores.Open()
        adapterDoctores = New SqlDataAdapter
        commandDoctores = New SqlCommand(queryStringCompanies, connectionDoctores)
        adapterDoctores.SelectCommand = commandDoctores
        cmdBuilderDoctores = New SqlCommandBuilder(adapterDoctores)
        cmdBuilderDoctores.ConflictOption = ConflictOption.OverwriteChanges
        adapterDoctores.Fill(doctores, "trabajadores")
        ComboBoxDoctores.Items.Clear()
        ComboBoxDoctores.Items.Add("SELECCIONE UN DOCTOR")
        'ComboBoxDoctores.DataSource = estados
        'ComboBoxDoctores.DisplayMember = estados("TrabajadorID")
        For i = 0 To doctores.Tables(0).Rows.Count - 1
            'ComboBoxDoctores.ValueMember = estados.Tables(0).Rows(i).Item(0)
            'ComboBoxDoctores.DisplayMember = estados.Tables(0).Rows(i).Item(1)
            'ComboBoxDoctores = DataBindings()
            ComboBoxDoctores.Items.Add(doctores.Tables(0).Rows(i).Item(0) & " " & doctores.Tables(0).Rows(i).Item(1) & " " & doctores.Tables(0).Rows(i).Item(2) & " " & doctores.Tables(0).Rows(i).Item(3))
        Next
        ComboBoxDoctores.SelectedIndex = 1


        doctores.Clear()
        doctores.Dispose()
        connectionDoctores.Close()
        adapterDoctores.Dispose()
        commandDoctores.Dispose()
        cmdBuilderDoctores.Dispose()
    End Sub

    Private Sub CargatipoPago()
        Dim i As Integer


        tipoPago = New DataSet()
        connectiontipoPago = New SqlConnection(connectionString)
        queryStringTipoPago = "select * from tipoPago where companyID='" & currentCompany & "'"
        connectiontipoPago.Open()
        adaptertipoPago = New SqlDataAdapter
        commandtipoPago = New SqlCommand(queryStringTipoPago, connectiontipoPago)
        adaptertipoPago.SelectCommand = commandtipoPago
        cmdBuildertipoPago = New SqlCommandBuilder(adaptertipoPago)
        cmdBuildertipoPago.ConflictOption = ConflictOption.OverwriteChanges
        adaptertipoPago.Fill(tipoPago, "trabajadores")
        ComboBoxtipoPago.Items.Clear()
        'ComboBoxtipoPago.Items.Add("SELECCIONE UN DOCTOR")
        'ComboBoxtipoPago.DataSource = estados
        'ComboBoxtipoPago.DisplayMember = estados("TrabajadorID")
        For i = 0 To tipoPago.Tables(0).Rows.Count - 1
            'ComboBoxtipoPago.ValueMember = estados.Tables(0).Rows(i).Item(0)
            'ComboBoxtipoPago.DisplayMember = estados.Tables(0).Rows(i).Item(1)
            'ComboBoxtipoPago = DataBindings()
            ComboBoxtipoPago.Items.Add(tipoPago.Tables(0).Rows(i).Item(0) & " " & tipoPago.Tables(0).Rows(i).Item(1))
        Next
        ComboBoxtipoPago.SelectedIndex = 0


        tipoPago.Clear()
        tipoPago.Dispose()
        connectiontipoPago.Close()
        adaptertipoPago.Dispose()
        commandtipoPago.Dispose()
        cmdBuildertipoPago.Dispose()
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'frmRemisiones.Show()
        FormReciboImp.Show()
        limpiaCamposDataGrid()
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        TxtFolio.ReadOnly = False
        limpiaCamposDataGrid()
        ToolStripStatusLabel1.Text = ""
        ToolStripStatusLabel1.Visible = False
        txtAdeudo.Text = "0"
        txtAdeudo.Visible = False
        txtAnticipo.Text = "0"
        txtAnticipo.Visible = False


    End Sub

   
    'Private Sub cancelaVenta(ByVal folio As String) '----------------------------
    '    Dim x As Integer
    '    Dim i As Integer
    '    Dim initialBalance As Integer
    '    Dim saldo As Integer
    '    invoiceHeaders = New DataSet()
    '    queryStringInvoiceHeaders = "select * from encabezadoRemision where companiaID='" & currentCompany & "' and folioRemision='" & folio & "'"
    '    connectioninvoiceHeaders = New SqlConnection(connectionString)
    '    connectioninvoiceHeaders.Open()
    '    adapterInvoiceHeaders = New SqlDataAdapter
    '    commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
    '    adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
    '    cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
    '    cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
    '    adapterInvoiceHeaders.Fill(invoiceHeaders, "encabezadoRemision")
    '    invoiceHeaders.Tables(0).Rows(0).Item(9) = "0"
    '    adapterInvoiceHeaders.Update(invoiceHeaders, "encabezadoRemision")

    '    invoiceHeaders.Clear()
    '    invoiceHeaders.Dispose()
    '    connectioninvoiceHeaders.Close()
    '    adapterInvoiceHeaders.Dispose()
    '    commandInvoiceHeaders.Dispose()
    '    cmdBuilderInvoiceHeaders.Dispose()

    '    productsKardex = New DataSet()
    '    queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "' and numeroRemision='" & folio & "'  "
    '    connectionproductsKardex = New SqlConnection(connectionString)
    '    connectionproductsKardex.Open()
    '    adapterproductsKardex = New SqlDataAdapter
    '    commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
    '    adapterproductsKardex.SelectCommand = commandproductsKardex
    '    cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
    '    cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
    '    adapterproductsKardex.Fill(productsKardex, "productsKardex")

    '    For x = 0 To productsKardex.Tables(0).Rows.Count - 1
    '        productsKardex.Tables(0).Rows(x).Item(10) = "B"
    '        adapterproductsKardex.Update(productsKardex, "productsKardex")
    '    Next





    '    For i = 0 To lastUsed

    '        products = New DataSet()
    '        queryStringProducts = "select * from catalogo where codigo='" & DataGridView1.Rows(i).Cells("clave").Value.ToString & "' and companiaId='" & currentCompany & "'"
    '        connectionProducts = New SqlConnection(connectionString)
    '        connectionProducts.Open()
    '        adapterProducts = New SqlDataAdapter
    '        commandProducts = New SqlCommand(queryStringProducts, connectionProducts)
    '        adapterProducts.SelectCommand = commandProducts
    '        cmdBuilderProducts = New SqlCommandBuilder(adapterProducts)
    '        cmdBuilderProducts.ConflictOption = ConflictOption.OverwriteChanges
    '        adapterProducts.Fill(products, "catalogo")
    '        initialBalance = products.Tables(0).Rows(0).Item(7) + products.Tables(0).Rows(0).Item(8) - products.Tables(0).Rows(0).Item(9)
    '        products.Tables(0).Rows(0).Item(8) += DataGridView1.Rows(i).Cells("cant").Value.ToString
    '        saldo = initialBalance + CType(DataGridView1.Rows(i).Cells("cant").Value.ToString, Decimal)
    '        adapterProducts.Update(products, "catalogo")

    '        products.Clear()
    '        products.Dispose()

    '        adapterProducts.Dispose()
    '        commandProducts.Dispose()
    '        cmdBuilderProducts.Dispose()
    '        ' closeProductsCatalog()

    '        productsKardex = New DataSet()
    '        queryStringproductsKardex = "select * from productsKardex where idEmpresa='" & currentCompany & "'   and tipo='J' "
    '        connectionproductsKardex = New SqlConnection(connectionString)
    '        connectionproductsKardex.Open()
    '        adapterproductsKardex = New SqlDataAdapter
    '        commandproductsKardex = New SqlCommand(queryStringproductsKardex, connectionproductsKardex)
    '        adapterproductsKardex.SelectCommand = commandproductsKardex
    '        cmdBuilderproductsKardex = New SqlCommandBuilder(adapterproductsKardex)
    '        cmdBuilderproductsKardex.ConflictOption = ConflictOption.OverwriteChanges
    '        adapterproductsKardex.Fill(productsKardex, "productsKardex")
    '        productsKardex.Tables(0).Rows.Add()

    '        productsKardex.Tables(0).Rows(0).Item(0) = DataGridView1.Rows(i).Cells("clave").Value.ToString 'CODIGO DE PRODUCTO
    '        productsKardex.Tables(0).Rows(0).Item(1) = DataGridView1.Rows(i).Cells("cant").Value.ToString 'CANTIDAD
    '        productsKardex.Tables(0).Rows(0).Item(2) = 0.0
    '        productsKardex.Tables(0).Rows(0).Item(3) = 0.0
    '        productsKardex.Tables(0).Rows(0).Item(4) = 0.0
    '        productsKardex.Tables(0).Rows(0).Item(5) = CType(DateTimePickerFecha.Text, Date)
    '        productsKardex.Tables(0).Rows(0).Item(6) = ""
    '        productsKardex.Tables(0).Rows(0).Item(7) = TxtFolio.Text
    '        productsKardex.Tables(0).Rows(0).Item(8) = TxtFolio.Text
    '        productsKardex.Tables(0).Rows(0).Item(9) = "I"
    '        productsKardex.Tables(0).Rows(0).Item(10) = "C"
    '        productsKardex.Tables(0).Rows(0).Item(11) = "DEVOLUCION"
    '        productsKardex.Tables(0).Rows(0).Item(12) = saldo
    '        productsKardex.Tables(0).Rows(0).Item(13) = consecutivoKardex() ' consecutivo Kaardex
    '        productsKardex.Tables(0).Rows(0).Item(14) = ""
    '        productsKardex.Tables(0).Rows(0).Item(15) = currentCompany
    '        productsKardex.Tables(0).Rows(0).Item(16) = 0
    '        initialBalance = 0
    '        adapterproductsKardex.Update(productsKardex, "productsKardex")

    '        'closeproductskardex()
    '    Next

    '    productsKardex.Clear()
    '    productsKardex.Dispose()
    '    connectionproductsKardex.Close()
    '    adapterproductsKardex.Dispose()
    '    commandproductsKardex.Dispose()
    '    cmdBuilderproductsKardex.Dispose()


    'End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PanelFinal.Visible = False
        txtTotalVenta.Text = "0"
        TextDESC.Text = "0"
        txtPago.Text = "0"
        txtCambio.Text = "0"

    End Sub

    Private Sub ComboBoxDoctores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDoctores.SelectedIndexChanged

    End Sub

    Private Sub btnAceptarLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarLiquidacion.Click
        If txtLiquidacion.Text = "0" Then
            MessageBox.Show("RECIBO LIQUIDADO.......")
        Else
            guardaAnticipo(TxtFolio.Text, consecutivoAnticipo(), Now.Date, txtLiquidacion.Text, currentCompany, currentUser)
            PanelLiquidar.Visible = False
            cargaRecivo(TxtFolio.Text)
            '    FormReciboImp.Show()
            limpiaCamposDataGrid()
            txtLCambio.Text = 0
            txtLiquidacion.Text = 0
            txtLCambio.Text = 0
            btnLiquidar.Enabled = False

        End If
       
    End Sub

    Private Sub btnLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidar.Click
        txtLRecibo.Text = 0
        txtLCambio.Text = 0
        PanelFinal.SendToBack()
        PanelFinal.Visible = False
        PanelLiquidar.Show()

        txtLRecibo.Focus()
    End Sub



   
    Private Sub btnCancelarLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarLiquidacion.Click
        PanelLiquidar.Visible = False
        limpiaCamposDataGrid()
        txtLCambio.Text = 0
        txtLiquidacion.Text = 0
        txtLCambio.Text = 0
        btnLiquidar.Enabled = False
    End Sub

    
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnalta_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnalta_Cliente.Click
        clientsCatalog.Show()
    End Sub

  
    Private Sub btncorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncorte.Click
        eliminacortediario(currentCompany)
        busca_recibos(Now.Date)
        Formcortediario.Show()
    End Sub

    Private Sub btncargarrecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargarrecibo.Click
        txtSuma.Text = 0
        Dim indiceTipoPago As Integer
        Dim indiceDoctor As Integer
        Try
            invoiceHeaders = New DataSet()
            queryStringInvoiceHeaders = "select * from recibo where companyID='" & currentCompany & "' and idRecibo='" & TxtFolio.Text & "'"
            connectioninvoiceHeaders = New SqlConnection(connectionString)
            connectioninvoiceHeaders.Open()
            adapterInvoiceHeaders = New SqlDataAdapter
            commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
            adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
            cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
            cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
            adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo")
            If invoiceHeaders.Tables(0).Rows.Count > 0 Then

                ToolStripStatusLabel1.Text = ""
                ToolStripStatusLabel1.Visible = False
                TxtFolio.ReadOnly = True

                indiceTipoPago = ComboBoxtipoPago.FindString(invoiceHeaders.Tables(0).Rows(0).Item(1))
                ComboBoxtipoPago.SelectedIndex = indiceTipoPago

                indiceDoctor = ComboBoxDoctores.FindString(invoiceHeaders.Tables(0).Rows(0).Item(2))
                ComboBoxDoctores.SelectedIndex = indiceDoctor
                lbltipopago.Text = invoiceHeaders.Tables(0).Rows(0).Item(1)

                TxtSubtotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(5)
                TxtDescuento.Text = invoiceHeaders.Tables(0).Rows(0).Item(6)
                TxtIva.Text = invoiceHeaders.Tables(0).Rows(0).Item(7)
                TxtTotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(8)

                txtDocumentAmount.Text = invoiceHeaders.Tables(0).Rows(0).Item(9)
                txtFolioInterno.Text = invoiceHeaders.Tables(0).Rows(0).Item(13)
                'If invoiceHeaders.Tables(0).Rows(0).Item(9) = False Then
                '    'btnCancelaVenta.Enabled = False
                'Else
                '    ' btnCancelaVenta.Enabled = True
                'End If
                clients = New DataSet()
                queryStringClients = "select * from clients where companyID='" & currentCompany & "' and clientID='" & invoiceHeaders.Tables(0).Rows(0).Item(3) & "'"
                connectionClients = New SqlConnection(connectionString)
                connectionClients.Open()
                adapterClients = New SqlDataAdapter
                commandClients = New SqlCommand(queryStringClients, connectionClients)
                adapterClients.SelectCommand = commandClients
                cmdBuilderClients = New SqlCommandBuilder(adapterClients)
                cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
                adapterClients.Fill(clients, "Clients")
                TxtClienteID.Text = clients.Tables(0).Rows(0).Item(0)
                TextBoxNombre.Text = clients.Tables(0).Rows(0).Item(1)
                RCF.Text = clients.Tables(0).Rows(0).Item(3)
                TxtCiudad.Text = clients.Tables(0).Rows(0).Item(7)
                'TxtNumero.Text = clients.Tables(0).Rows(0).Item(5)
                TxtEdad.Text = clients.Tables(0).Rows(0).Item(19)

                '  TxtApellidos.Text = clients.Tables(0).Rows(0).Item(2)
                '  TxtCP.Text = clients.Tables(0).Rows(0).Item(9)
                TxtTelefono.Text = clients.Tables(0).Rows(0).Item(11)
                txtSexo.Text = clients.Tables(0).Rows(0).Item(20)



                PermanentDB1 = New DataSet()
                queryStringPermanent1 = "select description from states where stateID='" & clients.Tables(0).Rows(0).Item(10) & "'"
                connectionPermanent1 = New SqlConnection(connectionString)
                connectionPermanent1.Open()
                adapterPermanent1 = New SqlDataAdapter
                commandPermanent1 = New SqlCommand(queryStringPermanent1, connectionPermanent1)
                adapterPermanent1.SelectCommand = commandPermanent1
                cmdBuilderPermanent1 = New SqlCommandBuilder(adapterPermanent1)
                cmdBuilderPermanent1.ConflictOption = ConflictOption.OverwriteChanges
                adapterPermanent1.Fill(PermanentDB1, "states")

                closePermanentDB1()

                invoiceRows1 = New DataSet()
                queryStringinvoiceRows = "select * from detalleRecibo where companyID='" & currentCompany & "' and idRecibo='" & TxtFolio.Text & "'"
                connectioninvoiceRows = New SqlConnection(connectionString)
                connectioninvoiceRows.Open()
                adapterinvoiceRows = New SqlDataAdapter
                commandinvoiceRows = New SqlCommand(queryStringinvoiceRows, connectioninvoiceRows)
                adapterinvoiceRows.SelectCommand = commandinvoiceRows
                cmdBuilderinvoiceRows = New SqlCommandBuilder(adapterinvoiceRows)
                cmdBuilderinvoiceRows.ConflictOption = ConflictOption.OverwriteChanges
                adapterinvoiceRows.Fill(invoiceRows1, "detalleRecibo")
                cuenta = invoiceRows1.Tables(0).Rows.Count
                For i = 0 To invoiceRows1.Tables(0).Rows.Count - 1

                    DataGridView1.Rows(i).Cells("clave").Value = invoiceRows1.Tables(0).Rows(i).Item(1)  'CODIGO DE PRODUCTO
                    DataGridView1.Rows(i).Cells("descripcion").Value = invoiceRows1.Tables(0).Rows(i).Item(2)  'CODIGO DE PRODUCTO
                    DataGridView1.Rows(i).Cells("tiempo").Value = invoiceRows1.Tables(0).Rows(i).Item(3)  'CANTIDAD
                    DataGridView1.Rows(i).Cells("proceso").Value = invoiceRows1.Tables(0).Rows(i).Item(4) 'PESCRIPCION
                    DataGridView1.Rows(i).Cells("importe").Value = invoiceRows1.Tables(0).Rows(i).Item(5)  'PRECIO UNITARIO

                    lastUsed1 = i
                    txtSuma.Text = invoiceRows1.Tables(0).Rows(i).Item(5) + Decimal.Parse(txtSuma.Text)
                Next
                If lbltipopago.Text = "03" Then


                Else
                    If checaAnticipo(TxtFolio.Text) Then

                        txtAnticipo.Text = "ANTICIPO : $ " + Format$(Val(txtAdeudo.Text), "##,##0.00")
                        txtAnticipo.Visible = True
                        txtLiquidacion.Text = TxtTotal.Text - txtAdeudo.Text

                        txtAdeudo.Text = TxtTotal.Text - txtAdeudo.Text
                      

                        If Decimal.Parse(txtAdeudo.Text) = 0 Then
                            btnLiquidar.Enabled = False
                            
                          
                        Else
                            
                            btnLiquidar.Enabled = True
                        End If
                        txtAdeudo.Text = "ADEUDO : $ " + Format$(Val(txtAdeudo.Text), "##,##0.00")
                        txtestadorecib.Visible = False
                        txtestadorecib.Text = " "
                    Else
                        txtAnticipo.Text = " "
                        txtAnticipo.Visible = False
                        txtAdeudo.Text = " "
                        txtAdeudo.Visible = False
                        txtestadorecib.Text = "RECIBO LIQUIDADO..."
                        txtestadorecib.Visible = True

                        'txtAnticipo.Text = "RECIBO LIQUIDADO"
                        'txtAnticipo.Visible = True

                    End If
                End If

                btnImprimir.Enabled = True
                connectioninvoiceRows.Close()
                adapterinvoiceRows.Dispose()
            Else

                ToolStripStatusLabel1.Text = "Error: El folio no existe!!!"
                ToolStripStatusLabel1.Visible = True
                'ToolStripStatusLabel1.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR AL BUSCAR EL RECIBO...")
        End Try

    End Sub
End Class


'

' Nuestra personalizacion para MiDGView ---------------------------------------------------------------

'

Public Class MiDGView

    Inherits DataGridView       'Heredar del DataGridView

    '

    'Prepocesar mensajes

    Public Overrides Function PreProcessMessage(ByRef msg As System.Windows.Forms.Message) As Boolean


        If msg.Msg = 257 And msg.WParam.ToInt32 = 13 Then                    'Si es 'KeyDown' y 'Enter'

            Dim MiCol As Integer = 0

            Dim MiFil As Integer = Me.CurrentCell.RowIndex - 1

            If Me.CurrentCell.ColumnIndex < Me.ColumnCount - 1 Then          'Si noSalimos del limite

                MiCol = Me.CurrentCell.ColumnIndex + 1                       'Siguiente columna

            End If

            If MiFil > -1 Then Me.CurrentCell = Me(MiCol, MiFil) 'Posicionar columna

        End If

        Return MyBase.PreProcessMessage(msg)

    End Function

End Class


'

' Nuestra personalizacion para DGVPlus ---------------------------------------------------------------

'

Public Class DgvPlus

    Inherits DataGridView   'Heredar del DataGridView


    '

    'en el 'processDialogKey'... cuando estamos en edicion

    Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If keyData = Keys.Enter Then                'Si es 'enter'

            SendKeys.Send(Chr(Keys.Tab))            'Enviar un 'Tab'

            Return True                             'Marcar como procesado

        Else                                        'en caso contrario

            Return MyBase.ProcessDialogKey(keyData) 'devolver KeyData

        End If

    End Function

    '

    ' en 'OnKeyDown'... cuando no estamos en edicion

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyData = Keys.Enter Then              'Si es 'enter'

            SendKeys.Send(Chr(Keys.Tab))            'Enviar un 'Tab'

        Else

            MyBase.OnKeyDown(e)                     'Devolver el KeyEventArgs

        End If

    End Sub

    Private Sub Form2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown



    End Sub

End Class