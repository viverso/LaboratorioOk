Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math
Public Class buscaEstudio
    Private iniciando As Boolean = True
    Dim temp As Char = "a"
    Dim indice As Integer = 0

    ' El DataTable lo necesitamos a nivel del formulario
    Private dt As DataTable

    ' El resto de variables no son necesarias a nivel de formulario
    ' y pueden estar definidas en el evento Form_Load

    ' La cadena de conexión


    ' La cadena de selección
    ' los datos que traeremos de la base de datos.
    Private seleccion As String = _
                "SELECT idEstudio,Descripcion,tiempo,proceso, Precio from estudio " + "where  Descripcion LIKE '" & temp & "%' ORDER BY Descripcion"

    ' El adapatador para obtener los datos
    Private da As SqlDataAdapter
    Private Sub BsucaProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub BsucaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            indice = Recibo.DataGridView1.CurrentRow.Index
            Me.DataGridViewProductos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)


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




        Dim seleccion As String = "SELECT idEstudio,Descripcion,tiempo,proceso, Precio from estudio " + "where  Descripcion LIKE '" & txtBuscar.Text & "%' ORDER BY Descripcion"
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
                    Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(0).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
                    Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(1).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
                    Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(2).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
                    Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
                    Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(4).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value
                    calculaTotal()
                    
                    Me.Close()

                End If


        End Select

        da.Dispose()
    End Sub
    Private Sub txtBuscar_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress

        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                If txtBuscar.Text.Length > 0 Then
                    Try

                        '   txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
                        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(0).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
                        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(1).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
                        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(2).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
                        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
                        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(4).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value
                        calculaTotal()
                        Recibo1.DataGridView1.CurrentCell = Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index + 1).Cells(0)
                        lastUsed1 = lastUsed1 + 1
                       
                        Me.Close()
                    Catch ex As Exception

                    End Try


                End If

        End Select

    End Sub

    Private Sub dgdAyuda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridViewProductos.KeyPress
    End Sub

    Private Sub DataGridViewProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridViewProductos.KeyPress

        If Me.DataGridViewProductos.CurrentCell.ColumnIndex = 1 Then '--> recuerda que las columas empiezan con 0
            If e.KeyChar = Chr(13) Then
                SendKeys.Send(Chr(Keys.Tab))
                txtBuscar.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index - 1).Cells(1).Value
            End If
        End If
    End Sub
    Private Sub calculaTotal()
        Dim Temp As Double
        Dim TempSubtotal As Double = 0.0
        Dim tempIVa As Double = 0.0
        Dim descuento As Double = 0.0

        Temp = 0
        For i = 0 To Recibo1.DataGridView1.RowCount
            Try
                Temp = Format(Temp + Double.Parse((Recibo1.DataGridView1.Rows(i).Cells(4).Value)), "##,##0.00")
                Recibo1.txtSuma.Text = Temp
            Catch ex As Exception
                Temp = (Temp + 0.0)

            End Try
        Next
        tempIVa = Temp * iva

        Temp = Format(Temp, "##,##0.00")
        ' SubTotal.Text = Temp.ToString()
        'Recibo.TxtSubtotal.Text = Format((Temp - tempIVa), "##,##0.00")
        TempSubtotal = Temp * iva
        ' iva.Text = Format(Temp * 0.16, "##,##0.00")
        'descuento = (Decimal.Parse(Recibo.TextDESC.Text) / 100) * Decimal.Parse(Recibo.txtSuma.Text)
        'Recibo.TxtDescuento.Text = ((Decimal.Parse(Recibo.TextDESC.Text) / 100) * Decimal.Parse(Recibo.txtSuma.Text)).ToString()
        'Recibo.TxtDescuento.Text = "0.0"
        'Recibo.TxtIva.Text = Format(tempIVa, "##,##0.00")

        ' total.Text = Format(Double.Parse(SubTotal.Text) + Double.Parse(iva.Text), "##,##0.00")
        Recibo1.TxtTotal.Text = Format(Temp, "##,##0.00")

        'Recibo.TOTALV.Text = Format(Recibo.TxtTotal.Text, "##,##0.00")
    End Sub
    Private Sub DataGridViewProductos_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewProductos.CellMouseClick


        'txtcodigo.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
        'txtDescripcion.Text = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(2).Value = txtDescripcion.Text
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(0).Value = txtcodigo.Text
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
        'Recibo.DataGridView1.Rows(Recibo.DataGridView1.CurrentRow.Index).Cells(1).Selected = True

        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(0).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(0).Value
        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(1).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(1).Value
        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(2).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(2).Value
        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(3).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(3).Value
        Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index).Cells(4).Value = DataGridViewProductos.Rows(DataGridViewProductos.CurrentRow.Index).Cells(4).Value
        calculaTotal()
        Recibo1.DataGridView1.CurrentCell = Recibo1.DataGridView1.Rows(Recibo1.DataGridView1.CurrentRow.Index + 1).Cells(0)
        lastUsed1 = lastUsed1 + 1
        Me.Close()




    End Sub

  
   
End Class