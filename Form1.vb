Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class formDoctores
    Dim i As Integer = 0
    Dim companyParameters, estados, estadosTrabajadores As DataSet
    Dim queryStringCompanyParameters As String
    Dim connectionCompanyParameters, connectionCompanies, connectionCompaniesTrabajadores As SqlConnection
    Dim adapterCompanyParameters, adapterCompaniesTrabajadores, da As SqlDataAdapter
    Dim commandCompanyParameters, commandCompaniesTrabajadores As SqlCommand
    Dim cmdBuilderCompanyParameters, cmdBuilderCompaniesTrabajadores As SqlCommandBuilder
    Dim newRecord As Boolean = False
    Dim newDocument As Boolean = False
    Dim modi As Boolean = False
    Dim dt As DataTable
    Function carga_doctores() As DataTable
        'DataGridViewgastos.Columns(1).DefaultCellStyle.Format = "d"
        Dim seleccion As String = "select  IdDoctor ,Nombre+' '+ApellidoPaterno+' '+ApellidoMaterno as NOMBRE,calle+' '+numero+' '+colonia+' '+ciudad as DIRECCION, rfc AS RFC  from doctores where companyID='" & currentCompany & "' ORDER BY ApellidoPaterno"
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
    Private Sub formDoctores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer = 0
        estados = New DataSet()
        connectionCompanies = New SqlConnection(connectionString)
        queryStringCompanies = "select idEsp, Especialidad from especialidades"
        connectionCompanies.Open()
        adapterCompanies = New SqlDataAdapter
        commandCompanies = New SqlCommand(queryStringCompanies, connectionCompanies)
        adapterCompanies.SelectCommand = commandCompanies
        cmdBuilderCompanies = New SqlCommandBuilder(adapterCompanies)
        cmdBuilderCompanies.ConflictOption = ConflictOption.OverwriteChanges
        adapterCompanies.Fill(estados, "especialidades")
        For i = 0 To estados.Tables(0).Rows.Count - 1
            'ComboBoxEstado.ValueMember = estados.Tables(0).Rows(i).Item(0)
            'ComboBoxEstado.DisplayMember = estados.Tables(0).Rows(i).Item(1)
            ComboBoxEspecialidad.Items.Add(estados.Tables(0).Rows(i).Item(0) & " - " & estados.Tables(0).Rows(i).Item(1))
        Next
        ComboBoxEspecialidad.SelectedIndex = 0

        CargaDoctores()
        ComboBoxTrabajador.SelectedIndex = 0
        bloqueaCampos(False)
        DataGridViewgastos.DataSource = carga_doctores()
        Me.DataGridViewgastos.Columns(0).Visible = False
        Me.DataGridViewgastos.Columns(1).Width = 350
        Me.DataGridViewgastos.Columns(2).Width = 350
        Me.DataGridViewgastos.Columns(3).Width = 150
        btnnuevo.Focus()

    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        bloqueaCampos(True)
        newDocument = False
    End Sub
    Private Sub CargaDoctores()
        Dim i As Integer


        estadosTrabajadores = New DataSet()
        connectionCompaniesTrabajadores = New SqlConnection(connectionString)
        queryStringCompanies = "select * from doctores where companyID='" & currentCompany & "'"
        connectionCompaniesTrabajadores.Open()
        adapterCompaniesTrabajadores = New SqlDataAdapter
        commandCompaniesTrabajadores = New SqlCommand(queryStringCompanies, connectionCompaniesTrabajadores)
        adapterCompaniesTrabajadores.SelectCommand = commandCompaniesTrabajadores
        cmdBuilderCompaniesTrabajadores = New SqlCommandBuilder(adapterCompaniesTrabajadores)
        cmdBuilderCompaniesTrabajadores.ConflictOption = ConflictOption.OverwriteChanges
        adapterCompaniesTrabajadores.Fill(estadosTrabajadores, "trabajadores")
        ComboBoxTrabajador.Items.Clear()
        ComboBoxTrabajador.Items.Add("SELECCIONE UN DOCTOR")
        'ComboBoxTrabajador.DataSource = estados
        'ComboBoxTrabajador.DisplayMember = estados("TrabajadorID")
        For i = 0 To estadosTrabajadores.Tables(0).Rows.Count - 1
            'ComboBoxTrabajador.ValueMember = estados.Tables(0).Rows(i).Item(0)
            'ComboBoxTrabajador.DisplayMember = estados.Tables(0).Rows(i).Item(1)
            'ComboBoxTrabajador = DataBindings()
            ComboBoxTrabajador.Items.Add(estadosTrabajadores.Tables(0).Rows(i).Item(0) & " " & estadosTrabajadores.Tables(0).Rows(i).Item(1) & " " & estadosTrabajadores.Tables(0).Rows(i).Item(2) & " " & estadosTrabajadores.Tables(0).Rows(i).Item(3))
        Next
        ComboBoxTrabajador.SelectedIndex = 0


        estadosTrabajadores.Clear()
        estadosTrabajadores.Dispose()
        connectionCompaniesTrabajadores.Close()
        adapterCompaniesTrabajadores.Dispose()
        commandCompaniesTrabajadores.Dispose()
        cmdBuilderCompaniesTrabajadores.Dispose()
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        'Dim s As String
        'Dim pos As Integer
        Dim IdDoctor As String
        If newDocument = True Then

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
            companyParameters.Tables(0).Rows(0).Item(1) += 1 'id del cliente
            IdDoctor = CType(companyParameters.Tables(0).Rows(0).Item(1), String)
            adapterCompanyParameters.Update(companyParameters, "companyParameters")
            companyParameters.Clear()
            companyParameters.Dispose()
            connectionCompanyParameters.Close()
            adapterCompanyParameters.Dispose()
            commandCompanyParameters.Dispose()
            cmdBuilderCompanyParameters.Dispose()
            txtIdDoctor.Text = IdDoctor.PadLeft(6, "0")
            searchDestinatario(txtIdDoctor.Text)
            clients.Tables(0).Rows.Add()
            '  clients.Tables(0).Rows(0).Item(30) = txtIdDoctor.Text
            ' clients.Tables(0).Rows(0).Item(31) = "000001"

            newDocument = False
        End If

        Try


            clients.Tables(0).Rows(0).Item(1) = txtNombre.Text.ToUpper()

            clients.Tables(0).Rows(0).Item(2) = txtPaterno.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(3) = txtMaterno.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(4) = txtRFC.Text.ToUpper()

            clients.Tables(0).Rows(0).Item(5) = txtRegistro.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(6) = txtCalle.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(7) = txtNumero.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(8) = txtCOlonia.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(9) = txtCiudad.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(10) = ComboBoxEspecialidad.Text.Substring(0, 2)

            clients.Tables(0).Rows(0).Item(11) = txtTelefono.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(12) = txtCelular.Text.ToUpper()

            clients.Tables(0).Rows(0).Item(13) = currentCompany
            clients.Tables(0).Rows(0).Item(14) = currentUser


        Catch ex As Exception


        End Try


        Try


            clients.Tables(0).Rows(0).Item(0) = txtIdDoctor.Text
        Catch ex As Exception

        End Try
        ' clients.Tables(0).Rows(0).Item(18) = clients.Tables(0).Rows(0).Item(0) & currentCompany
        adapterClients.Update(clients, "doctores")
        closeDatabases()
        limpiarCampos()

        ' CargaTrabajadores()
        CargaDoctores()
        DataGridViewgastos.DataSource = carga_doctores()
        Me.DataGridViewgastos.Columns(0).Visible = False
        Me.DataGridViewgastos.Columns(1).Width = 350
        Me.DataGridViewgastos.Columns(2).Width = 350
        Me.DataGridViewgastos.Columns(3).Width = 150
        ComboBoxEspecialidad.SelectedIndex = 0
        ComboBoxTrabajador.SelectedIndex = 0
        btnsalir.Focus()
    End Sub
    Function searchDestinatario(ByVal goal As String) As Boolean
        clients = New DataSet()
        queryStringClients = "select * from doctores where IdDoctor= '" & goal & "' and companyID='" & currentCompany & "'"
        connectionClients = New SqlConnection(connectionString)
        connectionClients.Open()
        adapterClients = New SqlDataAdapter
        commandClients = New SqlCommand(queryStringClients, connectionClients)
        adapterClients.SelectCommand = commandClients
        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
        adapterClients.Fill(clients, "doctores")

        ActiveDatabases.Add("doctores")
        Return Not clients.Tables(0).Rows.Count = 0
    End Function
    Sub closeDatabases()
        Dim x As Integer
        For x = 0 To ActiveDatabases.Count - 1
            Select Case ActiveDatabases(i)
                Case "doctores"
                    connectionClients.Close()
                    clients.Clear()
                    clients.Dispose()
                    adapterClients.Dispose()
                    clients.Clear()
                    clients.Dispose()
                    commandClients.Dispose()
                    cmdBuilderClients.Dispose()
                    'Case "permanentDB"
                    '    connectionPermanent.Close()
                    '    permanentDB.Clear()
                    '    permanentDB.Dispose()
                    '    adapterPermanent.Dispose()
                    '    permanentDB.Clear()
                    '    permanentDB.Dispose()
                    '    commandPermanent.Dispose()
                    '    cmdBuilderPermanent.Dispose()
            End Select
        Next
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        newDocument = True
        bloqueaCampos(True)
        limpiarCampos()
        txtNombre.Focus()
        txtNombre.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0)
    End Sub
    Private Sub limpiarCampos()
        txtIdDoctor.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        txtRFC.Text = ""
        txtRegistro.Text = ""
        txtCalle.Text = ""
        txtNumero.Text = ""
        txtCOlonia.Text = ""
        txtCiudad.Text = ""

        ComboBoxEspecialidad.SelectedIndex = 0
        txtTelefono.Text = ""
        txtCelular.Text = ""
        ComboBoxTrabajador.SelectedIndex = 0

    End Sub
    Private Sub bloqueaCampos(ByVal campos As Boolean)
        txtIdDoctor.Enabled = False
        txtNombre.Enabled = campos
        txtPaterno.Enabled = campos
        txtMaterno.Enabled = campos
        txtRFC.Enabled = campos
        txtRegistro.Enabled = campos
        txtCalle.Enabled = campos
        txtNumero.Enabled = campos
        txtCOlonia.Enabled = campos
        txtCiudad.Enabled = campos
        ComboBoxEspecialidad.Enabled = campos
        ComboBoxEspecialidad.SelectedIndex = 0
        'ComboBoxEspecialidad.Enabled = campos
        txtTelefono.Enabled = campos
        txtCelular.Enabled = campos

    End Sub

    Private Sub borratempDestinatario()
        Dim eliminar As String = "select * from doctores where IDDoctor= '" & txtIdDoctor.Text & "' and companyID='" & currentCompany & "'"
        Dim miconexion As New SqlConnection(connectionString)
        Dim delete As New SqlCommand(eliminar, miconexion)
        miconexion.Open()
        delete.ExecuteNonQuery()
        miconexion.Close()
        Dim eliminar1 As String = "delete  from doctores where IDDoctor= '" & txtIdDoctor.Text & "' and companyID='" & currentCompany & "'"
        Dim miconexion1 As New SqlConnection(connectionString)
        Dim delete1 As New SqlCommand(eliminar1, miconexion1)
        miconexion1.Open()
        delete1.ExecuteNonQuery()
        miconexion1.Close()

    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Close()
    End Sub

    Private Sub ComboBoxTrabajador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTrabajador.SelectedIndexChanged
        Dim indice As Integer
        'Dim i As Integer
        'Dim indiceEstados, indiceMunicipios, indiceFuncion As Integer
        If ComboBoxTrabajador.Text.Substring(0, 6) <> "SELECC" Then

            txtIdDoctor.Text = ComboBoxTrabajador.Text.Substring(0, 6)
            clients = New DataSet()
            queryStringClients = "select * from doctores where IdDoctor= '" & txtIdDoctor.Text & "' and companyID='" & currentCompany & "' order by nombre"
            connectionClients = New SqlConnection(connectionString)
            connectionClients.Open()
            adapterClients = New SqlDataAdapter
            commandClients = New SqlCommand(queryStringClients, connectionClients)
            adapterClients.SelectCommand = commandClients
            cmdBuilderClients = New SqlCommandBuilder(adapterClients)
            cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
            adapterClients.Fill(clients, "doctores")
            ActiveDatabases.Add("doctores")


            Try



                txtNombre.Text = clients.Tables(0).Rows(0).Item(1)

                txtPaterno.Text = clients.Tables(0).Rows(0).Item(2)
                txtMaterno.Text = clients.Tables(0).Rows(0).Item(3)
                txtRFC.Text = clients.Tables(0).Rows(0).Item(4)

                txtRegistro.Text = clients.Tables(0).Rows(0).Item(5)
                txtCalle.Text = clients.Tables(0).Rows(0).Item(6)
                txtNumero.Text = clients.Tables(0).Rows(0).Item(7)
                txtCOlonia.Text = clients.Tables(0).Rows(0).Item(8)
                txtCiudad.Text = clients.Tables(0).Rows(0).Item(9)
                indice = ComboBoxEspecialidad.FindString(clients.Tables(0).Rows(0).Item(10))
                ComboBoxEspecialidad.SelectedIndex = indice
                txtTelefono.Text = clients.Tables(0).Rows(0).Item(11)
                txtCelular.Text = clients.Tables(0).Rows(0).Item(12)
                


                '   t = statesCB.FindString(clients.Tables(0).Rows(0).Item(i))
                '  statesCB.SelectedIndex = t

                ' txtnombre.Text = clients.Tables(0).Rows(0).Item(1)
              
            
            Catch ex As Exception

            End Try

            btnguardar.Enabled = True
            btneliminar.Enabled = True
            btnmodificar.Enabled = True
            'btnAdd.Enabled = True

            'frmFields(1).Focus()




        End If
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        limpiarCampos()
        bloqueaCampos(False)
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Dim respuesta As Integer
        respuesta = MsgBox(" ¿Realmente Decea Eliminar al Doctor? ", MsgBoxStyle.OkCancel, "ADVERTENCIA")
        If respuesta = 1 Then
            borratempDestinatario()
            limpiarCampos()
            CargaDoctores()
            ComboBoxTrabajador.SelectedIndex = 0
            DataGridViewgastos.DataSource = carga_doctores()
            Me.DataGridViewgastos.Columns(0).Visible = False
            Me.DataGridViewgastos.Columns(1).Width = 350
            Me.DataGridViewgastos.Columns(2).Width = 350
            Me.DataGridViewgastos.Columns(3).Width = 150
            ComboBoxEspecialidad.SelectedIndex = 0
            ComboBoxTrabajador.SelectedIndex = 0
        End If
    End Sub

    Private Sub DataGridViewgastos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewgastos.CellClick
        Dim indice As Integer
        'Dim i As Integer
        'Dim indiceEstados, indiceMunicipios, indiceFuncion As Integer
        txtIdDoctor.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(0).Value()
        clients = New DataSet()
        queryStringClients = "select * from doctores where IdDoctor= '" & txtIdDoctor.Text & "' and companyID='" & currentCompany & "' order by nombre"
        connectionClients = New SqlConnection(connectionString)
        connectionClients.Open()
        adapterClients = New SqlDataAdapter
        commandClients = New SqlCommand(queryStringClients, connectionClients)
        adapterClients.SelectCommand = commandClients
        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
        adapterClients.Fill(clients, "doctores")
        ActiveDatabases.Add("doctores")


        Try



            txtNombre.Text = clients.Tables(0).Rows(0).Item(1)

            txtPaterno.Text = clients.Tables(0).Rows(0).Item(2)
            txtMaterno.Text = clients.Tables(0).Rows(0).Item(3)
            txtRFC.Text = clients.Tables(0).Rows(0).Item(4)

            txtRegistro.Text = clients.Tables(0).Rows(0).Item(5)
            txtCalle.Text = clients.Tables(0).Rows(0).Item(6)
            txtNumero.Text = clients.Tables(0).Rows(0).Item(7)
            txtCOlonia.Text = clients.Tables(0).Rows(0).Item(8)
            txtCiudad.Text = clients.Tables(0).Rows(0).Item(9)
            indice = ComboBoxEspecialidad.FindString(clients.Tables(0).Rows(0).Item(10))
            ComboBoxEspecialidad.SelectedIndex = indice
            txtTelefono.Text = clients.Tables(0).Rows(0).Item(11)
            txtCelular.Text = clients.Tables(0).Rows(0).Item(12)



         


        Catch ex As Exception

        End Try

        btnguardar.Enabled = True
        btneliminar.Enabled = True
        btnmodificar.Enabled = True
        'btnAdd.Enabled = True

        'frmFields(1).Focus()





    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtNombre.BackColor = System.Drawing.Color.White
            txtPaterno.Focus()
        End If
    End Sub

    Private Sub txtPaterno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaterno.GotFocus
        txtNombre.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub txtPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaterno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtMaterno.Focus()
        End If
    End Sub

    Private Sub txtRFC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtCiudad.Focus()
        End If
    End Sub

    Private Sub txtCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiudad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            ComboBoxEspecialidad.Focus()
        End If
    End Sub

    Private Sub txtMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaterno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRFC.Focus()
        End If
    End Sub

    Private Sub ComboBoxEspecialidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBoxEspecialidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtTelefono.Focus()
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtCelular.Focus()
        End If
    End Sub

    Private Sub txtCelular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtCalle.Focus()
        End If
    End Sub

    Private Sub txtCalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtCOlonia.Focus()
        End If
    End Sub

    Private Sub txtCOlonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOlonia.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus()
        End If
    End Sub

End Class


