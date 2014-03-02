Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math

Public Class descuentos
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim modi As Boolean = False

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtNombre.Text = ""
        txtporcentaje.Text = ""
        txtNombre.ReadOnly = False
        txtporcentaje.ReadOnly = False
        btnSave.Enabled = True
        modi = False
        txtNombre.Enabled = True
        txtporcentaje.Enabled = True
        txtNombre.Focus()
        txtNombre.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0)
    End Sub
    Private Sub actualiza_tipo_pago(ByVal id_tipo_pago As String, ByVal descripcion As String, ByVal porcentaje As Decimal, ByVal compania As String)

        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("actualiza_tipo_pago", oConexion)

            Dim oParameter As SqlClient.SqlParameter

            oParameter = oCommand.Parameters.Add("@IdTipoPago", SqlDbType.VarChar, 2)
            oParameter.Value = id_tipo_pago
            oParameter = oCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar, 30)
            oParameter.Value = descripcion
            oParameter = oCommand.Parameters.Add("@porcentaje", SqlDbType.Decimal, 6 - 2)
            oParameter.Value = porcentaje
            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = compania



            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()
            txtNombre.Text = ""
            txtporcentaje.Text = ""
            txtNombre.ReadOnly = True
            txtNombre.ReadOnly = True
        Catch ex As Exception
            'Dispose()
            'Finally
            'System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub



    Private Sub guarda_tipo_pago(ByVal id_tipo_pago As String, ByVal descripcion As String, ByVal porcentaje As Decimal, ByVal compania As String)

        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("guarda_tipo_pago", oConexion)

            Dim oParameter As SqlClient.SqlParameter

            oParameter = oCommand.Parameters.Add("@IdTipoPago", SqlDbType.VarChar, 2)
            oParameter.Value = id_tipo_pago
            oParameter = oCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar, 30)
            oParameter.Value = UCase(descripcion)
            oParameter = oCommand.Parameters.Add("@porcentaje", SqlDbType.Decimal, 6 - 2)
            oParameter.Value = porcentaje
            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = compania



            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()
            txtNombre.Text = ""
            txtporcentaje.Text = ""
            txtNombre.ReadOnly = True
            txtNombre.ReadOnly = True
        Catch ex As Exception
            'Dispose()
            'Finally
            'System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub
    Function consecutivo_descuento() As Integer
        Dim consecitivo As Integer
        Dim companyParameters_idtipo_pago As DataSet
        Dim connectioncompanyParameters_idtipo_pago As SqlConnection
        Dim queryStringcompanyParameters_idtipo_pago As String
        Dim adaptercompanyParameters_idtipo_pago As SqlDataAdapter
        Dim commandcompanyParameters_idtipo_pago As SqlCommand
        Dim cmdBuildercompanyParameters_idtipo_pago As SqlCommandBuilder
        companyParameters_idtipo_pago = New DataSet()
        queryStringcompanyParameters_idtipo_pago = "select * from companyParameters where companyID='" & currentCompany & "'"
        connectioncompanyParameters_idtipo_pago = New SqlConnection(connectionString)
        connectioncompanyParameters_idtipo_pago.Open()
        adaptercompanyParameters_idtipo_pago = New SqlDataAdapter
        commandcompanyParameters_idtipo_pago = New SqlCommand(queryStringcompanyParameters_idtipo_pago, connectioncompanyParameters_idtipo_pago)
        adaptercompanyParameters_idtipo_pago.SelectCommand = commandcompanyParameters_idtipo_pago
        cmdBuildercompanyParameters_idtipo_pago = New SqlCommandBuilder(adaptercompanyParameters_idtipo_pago)
        cmdBuildercompanyParameters_idtipo_pago.ConflictOption = ConflictOption.OverwriteChanges
        adaptercompanyParameters_idtipo_pago.Fill(companyParameters_idtipo_pago, "companyParameters")
        companyParameters_idtipo_pago.Tables(0).Rows(0).Item(7) += 1
        consecitivo = companyParameters_idtipo_pago.Tables(0).Rows(0).Item(7)


        adaptercompanyParameters_idtipo_pago.Update(companyParameters_idtipo_pago, "companyParameters")
        connectioncompanyParameters_idtipo_pago.Close()
        companyParameters_idtipo_pago.Clear()
        companyParameters_idtipo_pago.Dispose()
        adaptercompanyParameters_idtipo_pago.Dispose()
        companyParameters_idtipo_pago.Clear()
        companyParameters_idtipo_pago.Dispose()
        commandcompanyParameters_idtipo_pago.Dispose()
        cmdBuildercompanyParameters_idtipo_pago.Dispose()

        Return consecitivo
    End Function
    Function cargaConceptosDatagrid_tipo_apago(ByVal compania As String) As DataTable
        'DataGridViewgastos.Columns(1).DefaultCellStyle.Format = "d"
        Dim seleccion As String = " select * from tipoPago where companyID='" & compania & "' order by IdTipoPago"
        da = New SqlDataAdapter(seleccion, connectionString)
        dt = New DataTable
        da.Fill(dt)

        'Me.DataGridViewConceptos.DataSource = dt


        If dt.Rows.Count > 0 Then


            Return dt
        Else
            Return Nothing
        End If



        da.Dispose()
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim consecutivo_gastos As String
        If txtporcentaje.Text.Length > 0 And txtNombre.Text.Length > 0 Then
            If modi = False Then
                consecutivo_gastos = consecutivo_descuento()

                lblid_gasto.Text = consecutivo_gastos.PadLeft(2, "0")
                guarda_tipo_pago(lblid_gasto.Text, txtNombre.Text, txtporcentaje.Text, currentCompany)
                DataGridViewgastos.DataSource = cargaConceptosDatagrid_tipo_apago(currentCompany)
                DataGridViewgastos.Columns(0).Visible = False
                DataGridViewgastos.Columns(3).Visible = False
                DataGridViewgastos.Columns(1).Width = 300

            Else

                actualiza_tipo_pago(lblid_gasto.Text, txtNombre.Text, txtporcentaje.Text, currentCompany)
                lblid_gasto.Text = ""
                txtNombre.Text = ""
                txtporcentaje.Text = ""
                DataGridViewgastos.DataSource = cargaConceptosDatagrid_tipo_apago(currentCompany)
                DataGridViewgastos.Columns(0).Visible = False
                DataGridViewgastos.Columns(3).Visible = False
                DataGridViewgastos.Columns(1).Width = 300
                modi = False
            End If

        End If

        txtNombre.ReadOnly = True
        txtporcentaje.ReadOnly = True
        btnExit.Focus()
    End Sub

    Private Sub btnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifica.Click
        modi = True

        txtNombre.ReadOnly = False
        txtporcentaje.ReadOnly = False
        btnSave.Enabled = True
        txtNombre.Focus()
    End Sub

    Private Sub descuentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridViewgastos.DataSource = cargaConceptosDatagrid_tipo_apago(currentCompany)
        DataGridViewgastos.Columns(0).Visible = False
        DataGridViewgastos.Columns(3).Visible = False
        DataGridViewgastos.Columns(1).Width = 300
        txtNombre.Enabled = False
        txtporcentaje.Enabled = False


    End Sub

    Private Sub DataGridViewgastos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewgastos.CellClick
        btnSave.Enabled = True
        lblid_gasto.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(0).Value
        txtNombre.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(1).Value
        txtporcentaje.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(2).Value
        btnModifica.Enabled = True
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtNombre.BackColor = System.Drawing.Color.White
            txtporcentaje.Focus()
        End If
    End Sub

    Private Sub txtporcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtporcentaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtNombre.BackColor = System.Drawing.Color.White
            btnSave.Focus()
        End If
    End Sub

   
End Class