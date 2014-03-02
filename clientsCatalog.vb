Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class clientsCatalog
    Dim companyParameters, estados As DataSet
    Dim queryStringCompanyParameters As String
    Dim connectionCompanyParameters, connectionCompanies As SqlConnection
    Dim adapterCompanyParameters As SqlDataAdapter
    Dim commandCompanyParameters As SqlCommand
    Dim cmdBuilderCompanyParameters As SqlCommandBuilder
    Dim frmFields(16) As TextBox
    Dim i As Integer = 0
    Dim clientsDGV As DataGridView
    Dim statesCB As ComboBox
    Dim newRecord As Boolean = False
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'clearFields()
        closeDatabases()
        Me.Close()
    End Sub
    Private Sub borra_cliente(ByVal id_cliente As String)
        Dim eliminar As String = "select * from clients where clientID= '" & id_cliente & "' and companyID='" & currentCompany & "'"
        Dim miconexion As New SqlConnection(connectionString)
        Dim delete As New SqlCommand(eliminar, miconexion)
        miconexion.Open()
        delete.ExecuteNonQuery()
        miconexion.Close()
        Dim eliminar1 As String = "delete  from clients where clientID= '" & id_cliente & "' and companyID='" & currentCompany & "'"
        Dim miconexion1 As New SqlConnection(connectionString)
        Dim delete1 As New SqlCommand(eliminar1, miconexion1)
        miconexion1.Open()
        delete1.ExecuteNonQuery()
        miconexion1.Close()

    End Sub

    Private Sub clientsCatalog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initializeFields()
        Dim qs As String = "Select estadId, description from states"
        Dim dbs As String = "states"
        'CARGA ESTADOS
        Dim i As Integer = 0
        estados = New DataSet()
        connectionCompanies = New SqlConnection(connectionString)
        queryStringCompanies = "select * from states"
        connectionCompanies.Open()
        adapterCompanies = New SqlDataAdapter
        commandCompanies = New SqlCommand(queryStringCompanies, connectionCompanies)
        adapterCompanies.SelectCommand = commandCompanies
        cmdBuilderCompanies = New SqlCommandBuilder(adapterCompanies)
        cmdBuilderCompanies.ConflictOption = ConflictOption.OverwriteChanges
        adapterCompanies.Fill(estados, "states")
        For i = 0 To estados.Tables(0).Rows.Count - 1
            'ComboBoxEstado.ValueMember = estados.Tables(0).Rows(i).Item(0)
            'ComboBoxEstado.DisplayMember = estados.Tables(0).Rows(i).Item(1)
            ComboBoxEstados.Items.Add(estados.Tables(0).Rows(i).Item(0) & " - " & estados.Tables(0).Rows(i).Item(1))
        Next
        ComboBoxEstados.SelectedIndex = 0
    End Sub
    Sub initializeFields()
        '    For i = 0 To frmFields.Length - 1
        '        frmFields(i) = New TextBox
        '        Select Case i
        '            Case 4, 5, 6, 7, 8, 9, 11, 12, 13
        '                frmFields(i).Parent = GroupBoxAddress
        '            Case 10
        '                frmFields(i).Visible = False
        '            Case 14, 15, 16
        '                frmFields(i).Parent = GroupBoxFigures
        '            Case Else
        '                frmFields(i).Parent = Me
        '        End Select

        '        '   frmFields(i).Visible = True
        '    Next

        '    frmFields(0).Location = New Point(144, 15)
        '    frmFields(0).Size = New Size(120, 26)
        '    frmFields(0).MaxLength = 6

        '    AddHandler frmFields(0).KeyPress, AddressOf Keypress0_Enter
        '    AddHandler frmFields(0).KeyDown, AddressOf frmField0_KeyDown


        '    frmFields(1).Location = New Point(144, 51)
        '    frmFields(1).Size = New Size(361, 26)
        '    frmFields(1).MaxLength = 50
        '    frmFields(2).Location = New Point(144, 89)
        '    frmFields(2).Size = New Size(275, 26)
        '    frmFields(2).MaxLength = 50

        '    frmFields(3).Location = New Point(575, 89)
        '    frmFields(3).Size = New Size(162, 26)
        '    frmFields(3).MaxLength = 13
        '    frmFields(4).Location = New Point(125, 24)
        '    frmFields(4).Size = New Size(261, 26)
        '    frmFields(4).MaxLength = 50
        '    frmFields(5).Location = New Point(536, 24)
        '    frmFields(5).Size = New Size(104, 26)
        '    frmFields(5).MaxLength = 10
        '    frmFields(6).Location = New Point(125, 65)
        '    frmFields(6).Size = New Size(261, 26)
        '    frmFields(6).MaxLength = 50
        '    frmFields(7).Location = New Point(535, 65)
        '    frmFields(7).Size = New Size(208, 26)
        '    frmFields(7).MaxLength = 50
        '    frmFields(8).Location = New Point(125, 102)
        '    frmFields(8).Size = New Size(261, 22)
        '    frmFields(8).MaxLength = 50
        '    frmFields(9).Location = New Point(536, 102)
        '    frmFields(9).Size = New Size(104, 26)
        '    frmFields(9).MaxLength = 5
        '    ' frmFields(10).Location = New Point(194, 287)
        '    'frmFields(10).Size = New Size(103, 20)
        '    frmFields(10).Visible = False

        '    Dim cbSize As New Size(191, 28)
        '    Dim cbLocation As New Point(125, 146)

        '    Dim qs As String = "Select stateID, Description from states"
        '    Dim dbs As String = "states"
        '    LoadGenericComboBox(statesCB, qs, dbs, cbSize, cbLocation, GroupBoxAddress)

        '    frmFields(11).Location = New Point(536, 146)
        '    frmFields(11).Size = New Size(120, 26)
        '    frmFields(11).MaxLength = 10
        '    frmFields(12).Location = New Point(125, 193)
        '    frmFields(12).Size = New Size(120, 26)
        '    frmFields(12).MaxLength = 10
        '    frmFields(13).Location = New Point(536, 193)
        '    frmFields(13).Size = New Size(194, 26)
        '    frmFields(13).MaxLength = 30
        '    frmFields(14).Location = New Point(125, 22)
        '    frmFields(14).Size = New Size(120, 26)
        '    frmFields(15).Location = New Point(125, 57)
        '    frmFields(15).Size = New Size(120, 26)
        '    frmFields(15).Enabled = False
        '    frmFields(16).Location = New Point(125, 90)
        '    frmFields(16).Size = New Size(120, 26)
        '    frmFields(16).Enabled = False



    End Sub

    Private Sub Keypress0_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Dim t As Integer
        'Dim s As String
        'If Asc(e.KeyChar) = Keys.Enter Then
        '    If frmFields(0).Text.Length > 0 Then
        '        Try
        '            t = CType(frmFields(0).Text, Integer)
        '            s = CType(t, String)
        '            While s.Length < 6
        '                s = "0" & s
        '            End While
        '            frmFields(0).Text = s
        '        Catch ex As Exception
        '        End Try
        '        If searchclient(frmFields(0).Text) Then
        '            If newRecord Then
        '                ToolStripStatusError.Text = "Error: La clave de cliente ya existe!!!"
        '                ToolStripStatusError.Visible = True
        '                lblError.Text = " "
        '                lblError.Visible = True
        '                lblError.Focus()
        '            Else
        '                frmFields(0).Enabled = False
        '                ToolStripStatusNewRecord.Text = "Registro existente"
        '                ToolStripStatusNewRecord.Visible = True
        '                For i = 1 To frmFields.Length - 1
        '                    Select Case i
        '                        Case 10
        '                            t = statesCB.FindString(clients.Tables(0).Rows(0).Item(i))
        '                            statesCB.SelectedIndex = t
        '                        Case Else
        '                            frmFields(i).Text = clients.Tables(0).Rows(0).Item(i)
        '                    End Select
        '                Next
        '                btnSave.Enabled = True
        '                btnDelete.Enabled = True
        '            End If
        '        Else
        '            If newRecord Then
        '                frmFields(1).Focus()
        '                btnSave.Enabled = True
        '            Else
        '                ToolStripStatusError.Text = "Error: La clave de cliente no existe!!!"
        '                ToolStripStatusError.Visible = True
        '                lblError.Text = " "
        '                lblError.Visible = True
        '                lblError.Focus()
        '            End If
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub frmField0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.F1 Then

            Dim qS As String = "Select clientID,firstName,lastName from clients where companyID= '" & currentCompany & "' order by lastName"
            Dim sDB As String = "clients"
            Dim dgvsize As New Size(572, 220)
            Dim dgvlocation As New Point(237, 45)
            loadDataGridView(clientsDGV, Me, dgvsize, dgvlocation, sDB, qS, 3)
            AddHandler clientsDGV.CellMouseClick, AddressOf datagridView_CellMouseClick
            clientsDGV.Visible = True

        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Length > 0 Then
            If txtSearch.Text.Length > 0 Then
                Dim qS As String = "Select clientID,firstName,lastName from clients where firstName like '" & txtSearch.Text & "%' and companyID='" & currentCompany & "' order by firstName"
                Dim sDB As String = "clients"
                Dim dgvsize As New Size(572, 220)
                Dim dgvlocation As New Point(237, 45)
                loadDataGridView(clientsDGV, Me, dgvsize, dgvlocation, sDB, qS, 3)
                AddHandler clientsDGV.CellMouseClick, AddressOf datagridView_CellMouseClick
                If permanentDB.Tables(0).Rows.Count > 0 Then
                    txtSearch.Text = ""
                    txtSearch.Enabled = False
                    clientsDGV.Visible = True
                Else
                    clientsDGV.Visible = False
                    clientsDGV.Dispose()
                    ActiveDatabases.Add("permanentDB")
                    ' clearFields()
                    closeDatabases()
                    'frmFields(0).Focus()
                End If

            End If
        End If
    End Sub

    Function searchclient(ByVal goal As String) As Boolean
        clients = New DataSet()
        queryStringClients = "select * from clients where clientID= '" & goal & "' and companyID='" & currentCompany & "'"
        connectionClients = New SqlConnection(connectionString)
        connectionClients.Open()
        adapterClients = New SqlDataAdapter
        commandClients = New SqlCommand(queryStringClients, connectionClients)
        adapterClients.SelectCommand = commandClients
        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
        adapterClients.Fill(clients, "clients")

        ActiveDatabases.Add("clients")
        Return Not clients.Tables(0).Rows.Count = 0
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        closeDatabases()
        limpiacampos()
        newRecord = False
        btnAdd.Enabled = True
    End Sub


    Sub closeDatabases()
        For i = 0 To ActiveDatabases.Count - 1
            Select Case ActiveDatabases(i)
                Case "clients"
                    connectionClients.Close()
                    clients.Clear()
                    clients.Dispose()
                    adapterClients.Dispose()
                    clients.Clear()
                    clients.Dispose()
                    commandClients.Dispose()
                    cmdBuilderClients.Dispose()
                Case "permanentDB"
                    connectionPermanent.Close()
                    permanentDB.Clear()
                    permanentDB.Dispose()
                    adapterPermanent.Dispose()
                    permanentDB.Clear()
                    permanentDB.Dispose()
                    commandPermanent.Dispose()
                    cmdBuilderPermanent.Dispose()
            End Select
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
       
        Dim IdCliente As String
        If newRecord = True Then

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
            companyParameters.Tables(0).Rows(0).Item(4) += 1 'id del cliente
            IdCliente = CType(companyParameters.Tables(0).Rows(0).Item(4), String)
            adapterCompanyParameters.Update(companyParameters, "companyParameters")
            companyParameters.Clear()
            companyParameters.Dispose()
            connectionCompanyParameters.Close()
            adapterCompanyParameters.Dispose()
            commandCompanyParameters.Dispose()
            cmdBuilderCompanyParameters.Dispose()
            txtClienteID.Text = IdCliente.PadLeft(6, "0")
            searchDestinatario(txtClienteID.Text)
            clients.Tables(0).Rows.Add()
            clients.Tables(0).Rows(0).Item(0) = txtClienteID.Text
            'clients.Tables(0).Rows(0).Item(31) = "000001"

            newRecord = False
        End If

        Try


            clients.Tables(0).Rows(0).Item(1) = txtNombre.Text.ToUpper()

            clients.Tables(0).Rows(0).Item(2) = txtApellidos.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(3) = txtRFC.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(4) = txtCalle.Text.ToUpper()

            clients.Tables(0).Rows(0).Item(5) = txtNOExterior.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(6) = txtColonia.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(7) = txtCidudad.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(8) = txtMUnicipio.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(9) = txtCp.Text

            clients.Tables(0).Rows(0).Item(10) = ComboBoxEstados.Text.Substring(0, 2)
            clients.Tables(0).Rows(0).Item(11) = txtTelefono.Text
            clients.Tables(0).Rows(0).Item(12) = txtFax.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(13) = txtEmail.Text.ToUpper()
            clients.Tables(0).Rows(0).Item(14) = txtSaldoInicial.Text

            clients.Tables(0).Rows(0).Item(15) = txtCargos.Text
            clients.Tables(0).Rows(0).Item(16) = txtAbonos.Text
            clients.Tables(0).Rows(0).Item(17) = currentCompany

            clients.Tables(0).Rows(0).Item(18) = txtClienteID.Text + currentCompany
            clients.Tables(0).Rows(0).Item(19) = txtEdad.Text
            clients.Tables(0).Rows(0).Item(20) = cmbsexo.Text

        Catch ex As Exception


        End Try


        Try


            limpiacampos()
        Catch ex As Exception

        End Try
        ' clients.Tables(0).Rows(0).Item(18) = clients.Tables(0).Rows(0).Item(0) & currentCompany
        adapterClients.Update(clients, "clients")
        closeDatabases()
        'clearFields()

        'CargaTrabajadores()
        ComboBoxEstados.SelectedIndex = 0
        btnAdd.Enabled = True
    End Sub
    Function searchDestinatario(ByVal goal As String) As Boolean
        clients = New DataSet()
        queryStringClients = "select * from clients where clientID= '" & goal & "' and companyID='" & currentCompany & "'"
        connectionClients = New SqlConnection(connectionString)
        connectionClients.Open()
        adapterClients = New SqlDataAdapter
        commandClients = New SqlCommand(queryStringClients, connectionClients)
        adapterClients.SelectCommand = commandClients
        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
        adapterClients.Fill(clients, "clients")

        ActiveDatabases.Add("clients")
        Return Not clients.Tables(0).Rows.Count = 0
    End Function
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim respuesta As Integer
        respuesta = MsgBox(" ¿Realmente Desea Eliminar este cliente? ", MsgBoxStyle.OkCancel, "ADVERTENCIA")
        If respuesta = 1 Then
            borra_cliente(txtClienteID.Text)
            limpiacampos()
            newRecord = False
            btnAdd.Enabled = True
        End If

    End Sub

    Private Sub datagridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Dim t As Integer
        Dim indiceEstado As Integer
        Dim indiceSexo As Integer
        txtClienteID.Text = clientsDGV.CurrentRow.Cells(0).Value
        txtSearch.Text = clientsDGV.CurrentRow.Cells(1).Value & " " & clientsDGV.CurrentRow.Cells(2).Value
        clientsDGV.Visible = False
        clientsDGV.Dispose()
        connectionPermanent.Close()
        permanentDB.Clear()
        permanentDB.Dispose()
        adapterPermanent.Dispose()
        permanentDB.Clear()
        permanentDB.Dispose()
        commandPermanent.Dispose()
        cmdBuilderPermanent.Dispose()

        clients = New DataSet()
        queryStringClients = "select * from clients where clientID= '" & txtClienteID.Text & "' and companyID='" & currentCompany & "' order by firstname"
        connectionClients = New SqlConnection(connectionString)
        connectionClients.Open()
        adapterClients = New SqlDataAdapter
        commandClients = New SqlCommand(queryStringClients, connectionClients)
        adapterClients.SelectCommand = commandClients
        cmdBuilderClients = New SqlCommandBuilder(adapterClients)
        cmdBuilderClients.ConflictOption = ConflictOption.OverwriteChanges
        adapterClients.Fill(clients, "clients")
        ActiveDatabases.Add("clients")


        Try

            '   t = statesCB.FindString(clients.Tables(0).Rows(0).Item(i))
            '  statesCB.SelectedIndex = t

            ' txtnombre.Text = clients.Tables(0).Rows(0).Item(1)
            txtNombre.Text = clients.Tables(0).Rows(0).Item(1)
            txtApellidos.Text = clients.Tables(0).Rows(0).Item(2)
            txtRFC.Text = clients.Tables(0).Rows(0).Item(3)
            txtCalle.Text = clients.Tables(0).Rows(0).Item(4)
            txtNOExterior.Text = clients.Tables(0).Rows(0).Item(5)
            txtColonia.Text = clients.Tables(0).Rows(0).Item(6)
            txtCidudad.Text = clients.Tables(0).Rows(0).Item(7)
            txtMUnicipio.Text = clients.Tables(0).Rows(0).Item(8)
            txtCp.Text = clients.Tables(0).Rows(0).Item(9)
            indiceEstado = ComboBoxEstados.FindString(clients.Tables(0).Rows(0).Item(10))

            ComboBoxEstados.SelectedIndex = indiceEstado
            txtTelefono.Text = clients.Tables(0).Rows(0).Item(11)
            txtFax.Text = clients.Tables(0).Rows(0).Item(12)
            txtEmail.Text = clients.Tables(0).Rows(0).Item(13)
            txtSaldoInicial.Text = clients.Tables(0).Rows(0).Item(14)
            txtCargos.Text = clients.Tables(0).Rows(0).Item(15)
            txtAbonos.Text = clients.Tables(0).Rows(0).Item(16)
            txtEdad.Text = clients.Tables(0).Rows(0).Item(19)
            'txtSexo.Text = clients.Tables(0).Rows(0).Item(20)
            indiceSexo = cmbsexo.FindString(clients.Tables(0).Rows(0).Item(20))
            cmbsexo.SelectedIndex = indiceSexo
            'no estoy cargando campo 17
            'no estoy cargando campo 18
        Catch ex As Exception

        End Try
        btnSave.Enabled = True
        btnDelete.Enabled = True
        btnAdd.Enabled = True


    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtSearch.Text.Length > 0 Then
                Dim qS As String = "Select clientID,firstName,lastName from clients where lastName like '" & txtSearch.Text & "%' order by lastName"
                Dim sDB As String = "clients"
                Dim dgvsize As New Size(572, 220)
                Dim dgvlocation As New Point(237, 45)
                loadDataGridView(clientsDGV, Me, dgvsize, dgvlocation, sDB, qS, 3)
                AddHandler clientsDGV.CellMouseClick, AddressOf datagridView_CellMouseClick
                If permanentDB.Tables(0).Rows.Count > 0 Then
                    txtSearch.Text = ""
                    txtSearch.Enabled = False
                    clientsDGV.Visible = True
                Else
                    clientsDGV.Visible = False
                    clientsDGV.Dispose()
                    ActiveDatabases.Add("permanentDB")
                    'clearFields()
                    closeDatabases()
                    frmFields(0).Focus()
                End If
            Else
                frmFields(0).Focus()
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        newRecord = True
        ToolStripStatusNewRecord.Text = "Nuevo registro"
        ToolStripStatusNewRecord.Visible = True
        'clearFields()
        txtNombre.Focus()
        btnSave.Enabled = True
        btnAdd.Enabled = False
        limpiacampos()
    End Sub

    Private Sub lblError_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblError.LostFocus
        lblError.Visible = False
        ToolStripStatusError.Visible = False
        frmFields(0).Focus()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '  FrmPrintClients.Show()

        'Me.Hide()
    End Sub
    Private Sub limpiacampos()
        txtClienteID.Text = ""
        txtNombre.Text = ""
        txtApellidos.Text = ""
        txtRFC.Text = ""
        txtCalle.Text = ""
        txtNOExterior.Text = ""
        txtColonia.Text = ""
        txtCidudad.Text = ""
        txtMUnicipio.Text = ""
        txtCp.Text = ""
        ComboBoxEstados.SelectedIndex = 20
        txtTelefono.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtSaldoInicial.Text = "0.0"
        txtCargos.Text = "0.0"
        txtAbonos.Text = "0.0"
        txtEdad.Text = "0"
        txtSexo.Text = ""
        txtSearch.Text = ""
        txtSearch.ReadOnly = False
        txtSearch.Enabled = True
        cmbsexo.SelectedIndex = 0

    End Sub


    Private Sub cmbsexo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsexo.SelectedIndexChanged
        If cmbsexo.SelectedIndex = 0 Then

            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
            btnSave.Focus()
        End If

    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtApellidos.Focus()
        End If
    End Sub

    Private Sub txtApellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidos.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtRFC.Focus()
        End If
    End Sub

    Private Sub txtRFC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtCalle.Focus()
        End If
    End Sub
    Private Sub txtCalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtNOExterior.Focus()
        End If
    End Sub

    Private Sub txtNOExterior_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNOExterior.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtColonia.Focus()
        End If
    End Sub

End Class