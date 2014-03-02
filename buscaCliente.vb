Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math
Public Class buscaCliente
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
                "SELECT clientID, firstName +' '+lastName  AS 'CLIENTE', rfc AS 'R F C ',cityName,telephoneNumber,edad,sexo FROM clients " + "where  firstName LIKE '" & temp & "%' ORDER BY firstName"

    ' El adapatador para obtener los datos
    Private da As SqlDataAdapter

    Private Sub BsucaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridViewProductos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)


        da = New SqlDataAdapter(seleccion, connectionString)
        dt = New DataTable
        da.Fill(dt)

        Me.DataGridViewProductos.DataSource = dt

        'iniciando = False

        txtBuscar.Focus()
    End Sub
    Private Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBuscar.TextChanged
        DataGridViewRecibos.Rows.Clear()
        Dim i As Integer
        Dim control As Integer = 0
        Dim temp As Decimal

        Dim seleccion As String = "SELECT clientID, firstName+' '+lastName  AS 'CLIENTE', rfc AS 'R F C ',cityName,telephoneNumber,edad,sexo FROM clients " + "where  firstName LIKE '" & txtBuscar.Text & "%' ORDER BY firstName"
        da = New SqlDataAdapter(seleccion, connectionString)
        dt = New DataTable
        da.Fill(dt)

        Me.DataGridViewProductos.DataSource = dt


        If dt.Rows.Count > 0 Then
            txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
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

            DataGridViewProductos.AutoResizeColumn(2)
            '  DataGridViewProductos.AutoResizeColumn(3)
            DataGridViewProductos.CurrentRow.Selected = True
        Else

        End If
        ' Si hay datos, mostrar los apellidos
        Select Case Asc(13)
            Case Keys.Enter
                If txtBuscar.Text.Length > 0 Then
                    txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
                    txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
                    Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
                    Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(0).Value = txtcodigo.Text
                    Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
                    Recibo.DataGridView1.Focus()
                    Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(1).Selected = True
                    ' txtPU.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value

                    'Form2.DataGridView1.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
                    'ControlDeProceso.txtPrecioTela.Text = txtPU.Text

                    'ControlDeProceso.txtBuscaProductoTela.Focus()
                    Me.Close()

                End If


        End Select

        da.Dispose()
        invoiceHeaders = New DataSet()
        queryStringInvoiceHeaders = "select * from recibo where companyID='" & currentCompany & "' and clientID='" & txtcodigo.Text & "'"
        connectioninvoiceHeaders = New SqlConnection(connectionString)
        connectioninvoiceHeaders.Open()
        adapterInvoiceHeaders = New SqlDataAdapter
        commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
        adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
        cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
        cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
        adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo")

        If invoiceHeaders.Tables(0).Rows.Count > 0 Then
            DataGridViewRecibos.Rows.Add(invoiceHeaders.Tables(0).Rows.Count)
            For i = 0 To invoiceHeaders.Tables(0).Rows.Count - 1
                temp = devuelveAnticipo(invoiceHeaders.Tables(0).Rows(i).Item(0))
                If temp > 0 Then

                    'If temp < invoiceHeaders.Tables(0).Rows(i).Item(8) Then

                    DataGridViewRecibos.Rows(control).Cells("id_recibo").Value = invoiceHeaders.Tables(0).Rows(i).Item(0)  'CODIGO DE PRODUCTO
                    DataGridViewRecibos.Rows(control).Cells("folio").Value = invoiceHeaders.Tables(0).Rows(i).Item(13)  'CODIGO DE PRODUCTO
                    DataGridViewRecibos.Rows(control).Cells("fecha").Value = invoiceHeaders.Tables(0).Rows(i).Item(4)  'CODIGO DE PRODUCTO
                    DataGridViewRecibos.Rows(control).Cells("subtotal").Value = invoiceHeaders.Tables(0).Rows(i).Item(5)  'CANTIDAD
                    DataGridViewRecibos.Rows(control).Cells("descuento").Value = invoiceHeaders.Tables(0).Rows(i).Item(6) 'PESCRIPCION
                    DataGridViewRecibos.Rows(control).Cells("iva").Value = invoiceHeaders.Tables(0).Rows(i).Item(7)  'PRECIO UNITARIO

                    DataGridViewRecibos.Rows(control).Cells("total").Value = invoiceHeaders.Tables(0).Rows(i).Item(8)  'CODIGO DE PRODUCTO
                    DataGridViewRecibos.Rows(control).Cells("anticipo").Value = temp  'CANTIDAD
                    DataGridViewRecibos.Rows(control).Cells("debe").Value = invoiceHeaders.Tables(0).Rows(i).Item(8) - temp
                    DataGridViewRecibos.Rows(control).Cells("debe").Style.BackColor = Color.Red
                    DataGridViewRecibos.Columns("fecha").DefaultCellStyle.Format = "d"
                    control = control + 1
                    'End If



                End If

            Next

        End If
        









        'If invoiceHeaders.Tables(0).Rows(0).Item(9) = False Then
        '    'btnCancelaVenta.Enabled = False
        'Else
        '    ' btnCancelaVenta.Enabled = True
        'End If

        'Dim seleccionRecibo As String = "SELECT recibo.idRecibo, recibo.fecha,recibo.subtotal,recibo.descuento,recibo.iva,recibo.total FROM recibo,anticipos where  clientID= '" & txtcodigo.Text & "'    ORDER BY fecha"
        'dar = New SqlDataAdapter(seleccionRecibo, connectionString)
        'dtr = New DataTable
        'dar.Fill(dtr)

        ' ''If dtr.Rows(0).Item(0)>  aqui checar para cargar solo los que tengan adeudo


        'Me.DataGridViewRecibos.DataSource = dtr


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

                        ' txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
                        Recibo.TxtClienteID.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
                        Recibo.TextBoxNombre.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
                        Recibo.RCF.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
                        Recibo.TxtCiudad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
                        Recibo.TxtEdad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
                        Recibo.TxtTelefono.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value

                        Recibo.txtSexo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(6).Value

                        'Recibo.TxtEdad.Text== DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value
                        'Recibo.TxtEdad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
                        'txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
                        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
                        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(0).Value = txtcodigo.Text
                        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
                        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(1).Selected = True
                        ' txtPU.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value

                        'Form2.DataGridView1.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
                        'ControlDeProceso.txtPrecioTela.Text = txtPU.Text

                        'ControlDeProceso.txtBuscaProductoTela.Focus()
                        Me.Close()





                    Catch ex As Exception

                    End Try


                End If

        End Select

    End Sub

    Private Sub dgdAyuda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridViewProductos.KeyPress

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
    
    Private Sub DataGridViewProductos_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewProductos.CellMouseClick

        Dim temp As Decimal
        Dim control As Integer = 0
        da.Dispose()
        invoiceHeaders = New DataSet()
        queryStringInvoiceHeaders = "select * from recibo where companyID='" & currentCompany & "' and clientID='" & DataGridViewProductos.CurrentRow.Cells(0).Value & "'"
        connectioninvoiceHeaders = New SqlConnection(connectionString)
        connectioninvoiceHeaders.Open()
        adapterInvoiceHeaders = New SqlDataAdapter
        commandInvoiceHeaders = New SqlCommand(queryStringInvoiceHeaders, connectioninvoiceHeaders)
        adapterInvoiceHeaders.SelectCommand = commandInvoiceHeaders
        cmdBuilderInvoiceHeaders = New SqlCommandBuilder(adapterInvoiceHeaders)
        cmdBuilderInvoiceHeaders.ConflictOption = ConflictOption.OverwriteChanges
        adapterInvoiceHeaders.Fill(invoiceHeaders, "recibo")

        DataGridViewRecibos.Rows.Clear()

        If invoiceHeaders.Tables(0).Rows.Count > 0 Then
            DataGridViewRecibos.Rows.Add(invoiceHeaders.Tables(0).Rows.Count)
            For i = 0 To invoiceHeaders.Tables(0).Rows.Count - 1
                temp = devuelveAnticipo(invoiceHeaders.Tables(0).Rows(i).Item(0))
                If temp > 0 Then

                    If temp < invoiceHeaders.Tables(0).Rows(i).Item(8) Then

                        DataGridViewRecibos.Rows(Control).Cells("id_recibo").Value = invoiceHeaders.Tables(0).Rows(i).Item(0)  'CODIGO DE PRODUCTO
                        DataGridViewRecibos.Rows(Control).Cells("fecha").Value = invoiceHeaders.Tables(0).Rows(i).Item(4)  'CODIGO DE PRODUCTO
                        DataGridViewRecibos.Rows(Control).Cells("subtotal").Value = invoiceHeaders.Tables(0).Rows(i).Item(5)  'CANTIDAD
                        DataGridViewRecibos.Rows(Control).Cells("descuento").Value = invoiceHeaders.Tables(0).Rows(i).Item(6) 'PESCRIPCION
                        DataGridViewRecibos.Rows(Control).Cells("iva").Value = invoiceHeaders.Tables(0).Rows(i).Item(7)  'PRECIO UNITARIO

                        DataGridViewRecibos.Rows(Control).Cells("total").Value = invoiceHeaders.Tables(0).Rows(i).Item(8)  'CODIGO DE PRODUCTO
                        DataGridViewRecibos.Rows(Control).Cells("anticipo").Value = temp  'CANTIDAD
                        DataGridViewRecibos.Rows(Control).Cells("debe").Value = invoiceHeaders.Tables(0).Rows(i).Item(8) - temp
                        DataGridViewRecibos.Rows(Control).Cells("debe").Style.BackColor = Color.Red
                        DataGridViewRecibos.Columns("fecha").DefaultCellStyle.Format = "d"
                        Control = Control + 1
                    End If



                End If

            Next


        End If

    End Sub



    Private Sub DataGridViewRecibos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewRecibos.CellContentClick
        Recibo.TxtFolio.Text = DataGridViewRecibos.Rows(DataGridViewRecibos.CurrentRow.Index).Cells(0).Value
        Me.Close()
        Recibo.TxtFolio.Focus()
    End Sub

    Private Sub DataGridViewProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewProductos.CellDoubleClick
        txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
        Recibo.TxtClienteID.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
        Recibo.TextBoxNombre.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
        Recibo.RCF.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
        Recibo.TxtCiudad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
        Recibo.TxtEdad.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(5).Value
        Recibo.TxtTelefono.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value

        Recibo.txtSexo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(6).Value

        'txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(0).Value = txtcodigo.Text
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(1).Selected = True
        ' txtPU.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value

        'Form2.DataGridView1.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
        'ControlDeProceso.txtPrecioTela.Text = txtPU.Text

        'ControlDeProceso.txtBuscaProductoTela.Focus()
        Me.Close()
    End Sub

    Private Sub DataGridViewProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridViewProductos.KeyDown
        Dim renglon As Integer = 0

        'If e.KeyData = Keys.Down Then

        'End If
    End Sub
End Class