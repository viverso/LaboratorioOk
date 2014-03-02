Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math
Public Class busca_recibo
    Private iniciando As Boolean = True
    Dim temp As Char = "a"
    Dim dar As SqlDataAdapter
    Dim anticipos, invoiceHeaders As DataSet
    Dim connectionanticipos, connectioninvoiceHeaders As SqlConnection
    Dim adapteranticipos, adapterInvoiceHeaders As SqlDataAdapter
    Dim commandanticipos, commandInvoiceHeaders As SqlCommand
    Dim cmdBuilderanticipos, cmdBuilderInvoiceHeaders As SqlCommandBuilder
    ' El DataTable lo necesitamos a nivel del formulario
    Private dt As DataTable

    Private dtr As DataTable
    Dim queryStringInvoiceHeaders As String

    ' El resto de variables no son necesarias a nivel de formulario
    ' y pueden estar definidas en el evento Form_Load

    ' La cadena de conexión


    ' La cadena de selección
    ' los datos que traeremos de la base de datos.
    Private seleccion As String = _
                "SELECT idlaboratorio as 'REGISTRO', nombre_cliente as 'CLIENTE',fecha as 'FECHA',descuento as 'DESCUENTO',total AS 'TOTAL',idRecibo  FROM recibo1 " + "where  nombre_cliente LIKE '" & temp & "%' ORDER BY nombre_cliente"

    ' El adapatador para obtener los datos
    Private da As SqlDataAdapter
    Private Sub BsucaProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub cargarecibo(ByRef folio As String)
        Dim invoiceRows1 As DataSet
        Dim queryStringinvoiceRows As String
        Dim connectioninvoiceRows As SqlConnection
        Dim adapterinvoiceRows As SqlDataAdapter
        Dim commandinvoiceRows As SqlCommand
        Dim cmdBuilderinvoiceRows As SqlCommandBuilder
        Recibo1.txtSuma.Text = 0
        Dim indiceDoctor As Integer = 0
        Dim indiceTipoPago As Integer = 0
        Dim s As String
        Dim i As Integer

        If folio.Length > 0 Then
            'btnImprimir.Enabled = True     CAMBIAR POR BOTON PARA REIMPRIMIR REMISION

            Try
                s = CType(folio, Integer)
                While s.Length < 6
                    s = "0" & s
                End While
                Recibo1.TxtFolio.Text = s
            Catch ex As Exception
            End Try
            Try
                invoiceHeaders = New DataSet()
                queryStringInvoiceHeaders = "select * from recibo1 where companyID='" & currentCompany & "' and idRecibo='" & Recibo1.TxtFolio.Text & "'"
                connectioninvoiceHeaders = New SqlConnection(connectionString)
                connectioninvoiceHeaders.Open()
                adapterInvoiceHeaders = New SqlDataAdapter
                commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
                adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
                cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
                cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
                adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo1")
                If invoiceHeaders.Tables(0).Rows.Count > 0 Then

                    Recibo1.ToolStripStatusLabel1.Text = ""
                    Recibo1.ToolStripStatusLabel1.Visible = False
                    Recibo1.TxtFolio.ReadOnly = True

                    indiceTipoPago = Recibo1.ComboBoxtipoPago.FindString(invoiceHeaders.Tables(0).Rows(0).Item(1))
                    Recibo1.ComboBoxtipoPago.SelectedIndex = indiceTipoPago

                    indiceDoctor = Recibo1.ComboBoxDoctores.FindString(invoiceHeaders.Tables(0).Rows(0).Item(2))
                    Recibo1.ComboBoxDoctores.SelectedIndex = indiceDoctor
                    Recibo1.lbltipopago.Text = invoiceHeaders.Tables(0).Rows(0).Item(1)
                    Recibo1.lblfecha.Text = invoiceHeaders.Tables(0).Rows(0).Item(4)
                    Recibo1.TxtSubtotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(5)
                    Recibo1.TxtDescuento.Text = invoiceHeaders.Tables(0).Rows(0).Item(6)
                    Recibo1.TxtIva.Text = invoiceHeaders.Tables(0).Rows(0).Item(7)
                    Recibo1.TxtTotal.Text = invoiceHeaders.Tables(0).Rows(0).Item(8)

                    Recibo1.txtDocumentAmount.Text = invoiceHeaders.Tables(0).Rows(0).Item(9)
                    Recibo1.txtFolioInterno.Text = invoiceHeaders.Tables(0).Rows(0).Item(13)


                    Recibo1.TxtClienteID.Text = invoiceHeaders.Tables(0).Rows(0).Item(3)
                    Recibo1.TextBoxNombre.Text = invoiceHeaders.Tables(0).Rows(0).Item(14)
                    Recibo1.RCF.Text = invoiceHeaders.Tables(0).Rows(0).Item(19)
                    Recibo1.TxtCiudad.Text = invoiceHeaders.Tables(0).Rows(0).Item(15)

                    Recibo1.TxtEdad.Text = invoiceHeaders.Tables(0).Rows(0).Item(18)


                    Recibo1.TxtTelefono.Text = invoiceHeaders.Tables(0).Rows(0).Item(16)
                    Recibo1.txtSexo.Text = invoiceHeaders.Tables(0).Rows(0).Item(17)
                    indiceDoctor = Recibo1.ComboBoxDoctores.FindString(invoiceHeaders.Tables(0).Rows(0).Item(20))
                    Recibo1.txtObservaciones.Text = invoiceHeaders.Tables(0).Rows(0).Item(21)
                    Recibo1.ComboBoxDoctores.SelectedIndex = indiceDoctor



                    invoiceRows1 = New DataSet()
                    queryStringinvoiceRows = "select * from detalleRecibo1 where companyID='" & currentCompany & "' and idRecibo='" & Recibo1.TxtFolio.Text & "'"
                    connectioninvoiceRows = New SqlConnection(connectionString)
                    connectioninvoiceRows.Open()
                    adapterinvoiceRows = New SqlDataAdapter
                    commandinvoiceRows = New SqlCommand(queryStringinvoiceRows, connectioninvoiceRows)
                    adapterinvoiceRows.SelectCommand = commandinvoiceRows
                    cmdBuilderinvoiceRows = New SqlCommandBuilder(adapterinvoiceRows)
                    cmdBuilderinvoiceRows.ConflictOption = ConflictOption.OverwriteChanges
                    adapterinvoiceRows.Fill(invoiceRows1, "detalleRecibo1")
                    ' cuenta = invoiceRows1.Tables(0).Rows.Count
                    For i = 0 To invoiceRows1.Tables(0).Rows.Count - 1

                        Recibo1.DataGridView1.Rows(i).Cells("clave").Value = invoiceRows1.Tables(0).Rows(i).Item(1)  'CODIGO DE PRODUCTO
                        Recibo1.DataGridView1.Rows(i).Cells("descripcion").Value = invoiceRows1.Tables(0).Rows(i).Item(2)  'CODIGO DE PRODUCTO
                        Recibo1.DataGridView1.Rows(i).Cells("tiempo").Value = invoiceRows1.Tables(0).Rows(i).Item(3)  'CANTIDAD
                        Recibo1.DataGridView1.Rows(i).Cells("proceso").Value = invoiceRows1.Tables(0).Rows(i).Item(4) 'PESCRIPCION
                        Recibo1.DataGridView1.Rows(i).Cells("importe").Value = invoiceRows1.Tables(0).Rows(i).Item(5)  'PRECIO UNITARIO

                        lastUsed1 = i
                        Recibo1.txtSuma.Text = invoiceRows1.Tables(0).Rows(i).Item(5) + Decimal.Parse(Recibo1.txtSuma.Text)
                    Next
                    If Recibo1.lbltipopago.Text = "03" Then


                    Else
                        If checaAnticipo(Recibo1.TxtFolio.Text) Then

                            Recibo1.txtAnticipo.Text = "ANTICIPO : $ " + Format$(Val(Recibo1.txtAdeudo.Text), "##,##0.00")
                            Recibo1.txtAnticipo.Visible = True
                            Recibo1.txtLiquidacion.Text = Recibo1.TxtTotal.Text - Recibo1.txtAdeudo.Text

                            Recibo1.txtAdeudo.Text = Recibo1.TxtTotal.Text - Recibo1.txtAdeudo.Text
                            Recibo1.txtestadorecib.Text = ""
                            Recibo1.txtestadorecib.Visible = False
                            If Decimal.Parse(Recibo1.txtAdeudo.Text) = 0 Then
                                Recibo1.btnLiquidar.Enabled = False

                                Recibo1.txtestadorecib.Text = "LIQUIDADO..." 'AGREGADOS
                                Recibo1.txtestadorecib.Visible = True
                                Recibo1.txtAnticipo.Text = " "
                                Recibo1.txtAnticipo.Visible = False
                                Recibo1.txtAdeudo.Text = " "
                                Recibo1.txtAdeudo.Visible = False
                                Recibo1.txtAdeudo.Text = " "
                            Else
                                Recibo1.btnLiquidar.Enabled = True
                            End If
                            If Recibo1.txtAdeudo.Text = " " Then
                                Recibo1.btnLiquidar.Enabled = False
                            Else
                                Recibo1.btnLiquidar.Enabled = True
                                Recibo1.txtAdeudo.Text = "ADEUDO : $ " + Format$(Val(Recibo1.txtAdeudo.Text), "##,##0.00")
                            End If


                        Else
                            Recibo1.txtAnticipo.Text = " "
                            Recibo1.txtAnticipo.Visible = False
                            Recibo1.txtAdeudo.Text = " "
                            Recibo1.txtAdeudo.Visible = False
                            Recibo1.txtestadorecib.Text = "LIQUIDADO..."
                            Recibo1.txtestadorecib.Visible = True
                        End If
                    End If

                    Recibo1.btnImprimir.Enabled = True
                    connectioninvoiceRows.Close()
                    adapterinvoiceRows.Dispose()
                Else

                    Recibo1.ToolStripStatusLabel1.Text = "Error: El folio no existe!!!"
                    Recibo1.ToolStripStatusLabel1.Visible = True
                    'ToolStripStatusLabel1.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show("ERROR AL BUSCAR EL RECIBO...")
            End Try

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
                Recibo1.txtAdeudo.Text = anticipos.Tables(0).Rows(0).Item(0)
                Recibo1.txtAdeudo.Visible = True

                Return True
            Else
                Recibo1.txtAdeudo.Text = ""
                Recibo1.txtAdeudo.Visible = False
                Return False
            End If


        Catch ex As Exception
            Recibo1.txtAdeudo.Text = 0
            Recibo1.btnLiquidar.Enabled = False
        End Try



        anticipos.Clear()
        anticipos.Dispose()
        connectionanticipos.Close()
        adapteranticipos.Dispose()
        commandanticipos.Dispose()
        cmdBuilderanticipos.Dispose()
    End Function
    Private Sub BsucaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DataGridViewProductos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)
            DataGridViewProductos.AutoResizeColumn(0)
            DataGridViewProductos.AutoResizeColumn(1)
            DataGridViewProductos.AutoResizeColumn(2)
            DataGridViewProductos.AutoResizeColumn(3)
            DataGridViewProductos.Columns(0).Width = 150
            DataGridViewProductos.Columns(1).Width = 330
            DataGridViewProductos.Columns(2).Width = 150
            DataGridViewProductos.Columns(3).Width = 150
            DataGridViewProductos.Columns.Item(5).Visible = False
            da = New SqlDataAdapter(seleccion, connectionString)
            dt = New DataTable
            da.Fill(dt)

            Me.DataGridViewProductos.DataSource = dt

            'iniciando = False

            txtBuscar.Focus()
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBuscar.TextChanged
        'DataGridViewRecibos.Rows.Clear()
        Dim i As Integer
        Dim control As Integer = 0
        Dim temp As Decimal

        Dim seleccion As String = "SELECT idlaboratorio as 'REGISTRO', nombre_cliente as 'CLIENTE',fecha as 'FECHA',descuento as 'DESCUENTO',total AS 'TOTAL',idRecibo  FROM recibo1 " + "where  nombre_cliente LIKE '" & txtBuscar.Text & "%' ORDER BY nombre_cliente"
        da = New SqlDataAdapter(seleccion, connectionString)
        dt = New DataTable
        da.Fill(dt)

        Me.DataGridViewProductos.DataSource = dt


        If dt.Rows.Count > 0 Then
            txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
            txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
            txtPrecio.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
            'txtPU.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
            'Me.DataGridViewProductos.Columns("PRECIO PUBLICO").DefaultCellStyle.Format = "c" 'PONE EL SIGNO DE PESOS
            Me.DataGridViewProductos.BackgroundColor = Color.LemonChiffon
            Me.DataGridViewProductos.ForeColor = Color.DarkBlue
            DataGridViewProductos.GridColor = Color.Blue
            Me.DataGridViewProductos.DefaultCellStyle.WrapMode = DataGridViewTriState.True 'ajusta el texto a la celda

            '  Me.DataGridViewProductos.Columns("EXISTENCIAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'alinea texto a la derecha
            ' Me.DataGridViewProductos.Columns("Costo Unitario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'alinea texto a la derecha
            DataGridViewProductos.AutoResizeColumn(0)
            DataGridViewProductos.AutoResizeColumn(1)
            DataGridViewProductos.AutoResizeColumn(2)
            DataGridViewProductos.AutoResizeColumn(3)
            DataGridViewProductos.Columns(0).Width = 150
            DataGridViewProductos.Columns(1).Width = 350
            DataGridViewProductos.Columns(2).Width = 150
            DataGridViewProductos.Columns(3).Width = 150
            DataGridViewProductos.Columns.Item(5).Visible = False
            '  DataGridViewProductos.AutoResizeColumn(3)
            DataGridViewProductos.CurrentRow.Selected = True
        Else

        End If
        ' Si hay datos, mostrar los apellidos
        Select Case Asc(13)
            Case Keys.Enter
                If txtBuscar.Text.Length > 0 Then
                    txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
                    txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
                  
                    cargarecibo(txtcodigo.Text)
                    Recibo1.btnNuevo.Enabled = True
                    Recibo1.btnBuscar.Enabled = True
                    Recibo1.btncorte.Enabled = True
                    Recibo1.btnSalir.Enabled = True


                    Recibo1.BTNCOBRAR.Enabled = False
                    Recibo1.btnImprimir.Enabled = True
                    Recibo1.btnLiquidar.Enabled = True
                    Recibo1.btnEliminar.Enabled = True
                    Recibo1.ButtonCancelar.Enabled = True
                    Me.Close()

                End If


        End Select

        da.Dispose()

    End Sub


    Function devuelveAnticipo(ByVal folio As String) As Decimal
        Dim temp As Decimal = 0.0

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

            If anticipos.Tables(0).Rows(0).Item(0) > 0 Then

                temp = anticipos.Tables(0).Rows(0).Item(0)


                Return temp
            Else
                Return temp
            End If


        Catch ex As Exception
            Return 0.0
        End Try



        anticipos.Clear()
        anticipos.Dispose()
        connectionanticipos.Close()
        adapteranticipos.Dispose()
        commandanticipos.Dispose()
        cmdBuilderanticipos.Dispose()
    End Function


    Private Sub txtBuscar_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress

        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                If txtBuscar.Text.Length > 0 Then
                    Try


                        txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
                        txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value

                        cargarecibo(txtcodigo.Text)
                        Recibo1.btnNuevo.Enabled = True
                        Recibo1.btnBuscar.Enabled = True
                        Recibo1.btncorte.Enabled = True
                        Recibo1.btnSalir.Enabled = True


                        Recibo1.BTNCOBRAR.Enabled = False
                        Recibo1.btnImprimir.Enabled = True
                        'Recibo1.btnLiquidar.Enabled = True
                        Recibo1.btnEliminar.Enabled = True
                        Recibo1.ButtonCancelar.Enabled = True
                       
                        Me.Close()





                    Catch ex As Exception

                    End Try


                End If

        End Select

    End Sub

    Private Sub dgdAyuda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub DataGridViewProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridViewProductos.KeyPress
        Dim renglones As Integer
        renglones = DataGridViewProductos.Rows.Count '-------------------maximo de renglones de datagrid
        If Me.DataGridViewProductos.CurrentCell.ColumnIndex = 1 Then '--> recuerda que las columas empiezan con 0
            If e.KeyChar = Chr(13) Then
                SendKeys.Send(Chr(Keys.Tab))
                txtBuscar.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index - 1).Cells(1).Value
            End If
            'AQUI SE VA A VALIDAR LA TECLA PARA ABAJO O TECLA ARRIBA


        End If
    End Sub

    Private Sub DataGridViewProductos_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    

    End Sub



    Private Sub DataGridViewRecibos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Recibo.TxtFolio.Text = DataGridViewRecibos.Rows(DataGridViewRecibos.CurrentRow.Index).Cells(0).Value
        'Me.Close()
        'Recibo.TxtFolio.Focus()
    End Sub

    Private Sub DataGridViewProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
        Recibo.TxtClienteID.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
        Recibo.TextBoxNombre.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
        Recibo.RCF.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
        Recibo.TxtCiudad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
        Recibo.TxtEdad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
        Recibo.TxtTelefono.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value

        Recibo.txtSexo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(6).Value

     
        Me.Close()
    End Sub

    Private Sub DataGridViewProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim renglon As Integer = 0

      
    End Sub

    Private Sub DataGridViewProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewProductos.CellContentClick
        txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
        cargarecibo(txtcodigo.Text)
        Recibo1.btnNuevo.Enabled = True
        Recibo1.btnBuscar.Enabled = True
        Recibo1.btncorte.Enabled = True
        Recibo1.btnSalir.Enabled = True


        Recibo1.BTNCOBRAR.Enabled = False
        Recibo1.btnImprimir.Enabled = True
        'Recibo1.btnLiquidar.Enabled = True
        Recibo1.btnEliminar.Enabled = True
        Recibo1.ButtonCancelar.Enabled = True
        Me.Close()

    End Sub
End Class