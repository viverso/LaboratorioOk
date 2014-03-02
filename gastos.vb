Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math


Public Class gastos
    Dim modi As Boolean = False
    Dim companyParameters_idGasto, gastos As DataSet
    Dim queryStringcompanyParameters_idGasto, queryStringgastos As String
    Dim connectioncompanyParameters_idGasto, connectiongastos As SqlConnection
    Dim adaptercompanyParameters_idGasto, adapterConceptosPorduccion, da As SqlDataAdapter
    Dim commandcompanyParameters_idGasto, commandgastos As SqlCommand
    Dim cmdBuildercompanyParameters_idGasto, cmdBuilderConcpetosProduccon As SqlCommandBuilder
    Dim dt As DataTable
    Function cargaConceptosDatagridGASTOS(ByVal usuario As String, ByVal fecha As Date) As DataTable
        'DataGridViewgastos.Columns(1).DefaultCellStyle.Format = "d"
        Dim seleccion As String = "set DateFormat dmy; select * from gastos where usuario='" & usuario & "' and fecha='" & fecha & "'"
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
    'Sub cargagastos(ByVal usuario As String, ByVal fecha As Date)

    '    gastos = New DataSet()
    '    queryStringgastos = "select * from gastos where usuario='" & usuario & "' and fecha='" & fecha & "' ORDER BY id_gasto"
    '    connectiongastos = New SqlConnection(connectionString)
    '    connectiongastos.Open()
    '    adapterConceptosPorduccion = New SqlDataAdapter
    '    commandgastos = New SqlCommand(queryStringgastos, connectiongastos)
    '    adapterConceptosPorduccion.SelectCommand = commandgastos
    '    cmdBuilderConcpetosProduccon = New SqlCommandBuilder(adapterConceptosPorduccion)
    '    cmdBuilderConcpetosProduccon.ConflictOption = ConflictOption.OverwriteChanges
    '    adapterConceptosPorduccion.Fill(gastos, "gastos")
    '    DataGridViewgastos.Rows.Clear()
    '    DataGridViewgastos.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
    '    DataGridViewgastos.Rows.Add(gastos.Tables(0).Rows.Count)
    '    DataGridViewgastos.RowHeadersVisible = False

    '    For y = 0 To gastos.Tables(0).Rows.Count - 1

    '        DataGridViewgastos.Rows(y).Cells(0).Value = gastos.Tables(0).Rows(y).Item(0)
    '        DataGridViewgastos.Rows(y).Cells(1).Value = gastos.Tables(0).Rows(y).Item(1)
    '        DataGridViewgastos.Rows(y).Cells(2).Value = gastos.Tables(0).Rows(y).Item(2)
    '        DataGridViewgastos.Rows(y).Cells(3).Value = gastos.Tables(0).Rows(y).Item(3)


    '    Next


    'End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim consecutivo_gastos As String
        If txtimporte.Text.Length > 0 And txtconcepto.Text.Length > 0 Then
            If modi = False Then
                consecutivo_gastos = consecutivo_gasto()

                lblid_gasto.Text = consecutivo_gastos.PadLeft(6, "0")
                guarda_gastos(lblid_gasto.Text, Datefecha.Text, txtconcepto.Text, txtimporte.Text)
                DataGridViewgastos.DataSource = cargaConceptosDatagridGASTOS(currentUser, Now.Date)

            Else

                actualiza_gastos(lblid_gasto.Text, txtconcepto.Text, txtimporte.Text, currentCompany)
                lblid_gasto.Text = ""
                txtconcepto.Text = ""
                txtimporte.Text = ""
                DataGridViewgastos.DataSource = cargaConceptosDatagridGASTOS(currentUser, Now.Date)
                modi = False
            End If
            
        End If

        txtconcepto.ReadOnly = True
        txtimporte.ReadOnly = True

    End Sub

    Function consecutivo_gasto() As Integer
        Dim consecitivo As Integer
        companyParameters_idGasto = New DataSet()
        queryStringcompanyParameters_idGasto = "select * from companyParameters where companyID='" & currentCompany & "'"
        connectioncompanyParameters_idGasto = New SqlConnection(connectionString)
        connectioncompanyParameters_idGasto.Open()
        adaptercompanyParameters_idGasto = New SqlDataAdapter
        commandcompanyParameters_idGasto = New SqlCommand(queryStringcompanyParameters_idGasto, connectioncompanyParameters_idGasto)
        adaptercompanyParameters_idGasto.SelectCommand = commandcompanyParameters_idGasto
        cmdBuildercompanyParameters_idGasto = New SqlCommandBuilder(adaptercompanyParameters_idGasto)
        cmdBuildercompanyParameters_idGasto.ConflictOption = ConflictOption.OverwriteChanges
        adaptercompanyParameters_idGasto.Fill(companyParameters_idGasto, "companyParameters")
        companyParameters_idGasto.Tables(0).Rows(0).Item(12) += 1
        consecitivo = companyParameters_idGasto.Tables(0).Rows(0).Item(12)


        adaptercompanyParameters_idGasto.Update(companyParameters_idGasto, "companyParameters")
        closecompanyParameters_idGasto()
        Return consecitivo
    End Function
    Sub closecompanyParameters_idGasto()
        connectioncompanyParameters_idGasto.Close()
        companyParameters_idGasto.Clear()
        companyParameters_idGasto.Dispose()
        adaptercompanyParameters_idGasto.Dispose()
        companyParameters_idGasto.Clear()
        companyParameters_idGasto.Dispose()
        commandcompanyParameters_idGasto.Dispose()
        cmdBuildercompanyParameters_idGasto.Dispose()
    End Sub

    Private Sub guarda_gastos(ByVal id_gasto As String, ByVal fecha As Date, ByVal concepto As String, ByVal importe As Decimal)

        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("guarda_gastos", oConexion)

            Dim oParameter As SqlClient.SqlParameter

            oParameter = oCommand.Parameters.Add("@id_gasto", SqlDbType.VarChar, 6)
            oParameter.Value = id_gasto
            oParameter = oCommand.Parameters.Add("@fecha", SqlDbType.Date)
            oParameter.Value = fecha
            oParameter = oCommand.Parameters.Add("@concepto", SqlDbType.VarChar, 80)
            oParameter.Value = concepto
            oParameter = oCommand.Parameters.Add("@importe", SqlDbType.Decimal, 8 - 2)
            oParameter.Value = importe
            oParameter = oCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
            oParameter.Value = currentUser
            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = currentCompany


            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()
            txtconcepto.Text = ""
            txtimporte.Text = ""
            txtconcepto.ReadOnly = True
            txtimporte.ReadOnly = True
        Catch ex As Exception
            'Dispose()
            'Finally
            'System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub
    Private Sub elimina_gastos(ByVal id_gasto As String, ByVal compania As String)

        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("elimina_gasto", oConexion)

            Dim oParameter As SqlClient.SqlParameter

            oParameter = oCommand.Parameters.Add("@id_gasto", SqlDbType.VarChar, 6)
            oParameter.Value = id_gasto
            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = compania



            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()

        Catch ex As Exception
            'Dispose()
            'Finally
            'System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub gastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.btnGuardar.Enabled = False
            txtconcepto.Text = ""
            txtimporte.Text = ""
            txtconcepto.ReadOnly = True
            txtimporte.ReadOnly = True
            ''DataGridViewgastos.Rows.Add(1)
            DataGridViewgastos.DataSource = cargaConceptosDatagridGASTOS(currentUser, Now.Date)
            Me.DataGridViewgastos.Columns("0").Visible = False
            Me.DataGridViewgastos.Columns("3").Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        txtconcepto.Text = ""
        txtimporte.Text = ""
        txtconcepto.ReadOnly = False
        txtimporte.ReadOnly = False
        btnGuardar.Enabled = True
        txtconcepto.Focus()
    End Sub


    Private Sub txtconcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcepto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtimporte.Focus()
        End If
    End Sub

    Private Sub txtimporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtimporte.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub DataGridViewgastos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewgastos.CellContentClick
        btnEliminar.Enabled = True
        lblid_gasto.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(0).Value
        txtconcepto.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(2).Value
        txtimporte.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(3).Value
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer

        respuesta = MsgBox(" ¿Realmente Desea Eliminar este Gasto? ", MsgBoxStyle.OkCancel, "ADVERTENCIA")
        If respuesta = 1 Then
            elimina_gastos(lblid_gasto.Text, currentCompany)
            DataGridViewgastos.DataSource = cargaConceptosDatagridGASTOS(currentUser, Now.Date)
            lblid_gasto.Text = ""
            txtconcepto.Text = ""
            txtimporte.Text = ""
        End If
    End Sub

    Private Sub btnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifica.Click
        modi = True

        txtconcepto.ReadOnly = False
        txtimporte.ReadOnly = False
        btnGuardar.Enabled = True
        txtconcepto.Focus()
    End Sub
    Private Sub actualiza_gastos(ByVal id_gasto As String, ByVal concepto As String, ByVal importe As Decimal, ByVal compania_id As String)

        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("actualiza_gastos", oConexion)

            Dim oParameter As SqlClient.SqlParameter

            oParameter = oCommand.Parameters.Add("@id_gasto", SqlDbType.VarChar, 6)
            oParameter.Value = id_gasto
            oParameter = oCommand.Parameters.Add("@concepto", SqlDbType.VarChar, 80)
            oParameter.Value = concepto
            oParameter = oCommand.Parameters.Add("@importe", SqlDbType.Decimal, 8 - 2)
            oParameter.Value = importe
            oParameter = oCommand.Parameters.Add("@companyID", SqlDbType.VarChar, 6)
            oParameter.Value = compania_id

            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()


        Catch ex As Exception
            'Dispose()
            'Finally
            'System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub
End Class