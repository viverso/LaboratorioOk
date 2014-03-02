Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class Usuarios

    Dim chexBoxPersonal As CheckBox
    Dim newRecord As Boolean
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    'Dim connectionusers As SqlConnection
    'Dim commandusers As SqlCommand
    'Dim querystringuser As String
    'Dim adapterusers As SqlDataAdapter
    'Dim cmdBuilderusers As SqlCommandBuilder
    'Dim users As DataSet

    Sub InitializeFields()
        newRecord = False
        clearfields()

    End Sub
    Function carga_usuarios() As DataTable
        'DataGridViewgastos.Columns(1).DefaultCellStyle.Format = "d"
        Dim seleccion As String = "select  userID as USUARIO,firstname+' '+lastname AS NOMBRE   from users where companyID='" & currentCompany & "'"
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
    Sub clearfields()
        txbLastName.Text = ""
        TxbUserName.Text = ""
        TxtPass.Text = ""
        TxtPassConfirm.Text = ""
        UserType.Text = ""
        TxbNombre.Text = ""
        TxbNombre.Focus()
        ' LblTip.Text = ""

    End Sub

    Private Sub Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        DataGridViewgastos.DataSource = carga_usuarios()
        ' Me.DataGridViewgastos.Columns(0).Visible = False
        Me.DataGridViewgastos.Columns(0).Width = 100
        Me.DataGridViewgastos.Columns(1).Width = 250
        'Me.DataGridViewgastos.Columns(3).Width = 150
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clearfields()
        newRecord = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim respuesta As Integer
        respuesta = MsgBox(" ¿Realmente Desea Eliminar este Usuario? ", MsgBoxStyle.OkCancel, "ADVERTENCIA")
        If respuesta = 1 Then
            users = New DataSet()
            queryStringUsers = "delete from users where userID= '" & TxbNombre.Text & "' and companyID = '" & currentCompany & "'"
            connectionUsers = New SqlConnection(connectionString)
            connectionUsers.Open()
            adapterUsers = New SqlDataAdapter
            commandUsers = New SqlCommand(queryStringUsers, connectionUsers)
            adapterUsers.SelectCommand = commandUsers
            cmdBuilderUsers = New SqlCommandBuilder(adapterUsers)
            cmdBuilderUsers.ConflictOption = ConflictOption.OverwriteChanges
            adapterUsers.Fill(users, "users")
            clearfields()
            LblTip.Text = "OPERACION REALIZADA EXITOSAMENTE"
            btnDelete.Enabled = False
            btnSave.Enabled = False

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
        UserType.SelectedIndex = 1

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If TxtPass.Text = TxtPassConfirm.Text Then
            'If Not TxtPass.Text.Length < 6 Then
            If TxbNombre.Text.Length > 0 And TxtPass.Text = TxtPassConfirm.Text And Not TxtPass.TextLength < 3 Then

                users = New DataSet()
                queryStringUsers = "select * from users where userID= '" & TxbNombre.Text & "' and companyID = '" & currentCompany & "'"
                connectionUsers = New SqlConnection(connectionString)
                connectionUsers.Open()
                adapterUsers = New SqlDataAdapter
                commandUsers = New SqlCommand(queryStringUsers, connectionUsers)
                adapterUsers.SelectCommand = commandUsers
                cmdBuilderUsers = New SqlCommandBuilder(adapterUsers)
                cmdBuilderUsers.ConflictOption = ConflictOption.OverwriteChanges
                adapterUsers.Fill(users, "users")


                If newRecord Then
                    users.Tables(0).Rows.Add()
                End If
                users.Tables(0).Rows(0).Item(0) = currentCompany
                users.Tables(0).Rows(0).Item(1) = TxbNombre.Text
                users.Tables(0).Rows(0).Item(2) = TxtPass.Text
                users.Tables(0).Rows(0).Item(3) = TxbUserName.Text
                users.Tables(0).Rows(0).Item(4) = txbLastName.Text
                If UserType.SelectedIndex = 0 Then
                    users.Tables(0).Rows(0).Item(5) = 0
                ElseIf UserType.SelectedIndex = 1 Then

                    users.Tables(0).Rows(0).Item(5) = 1
                End If

                Try
                    newRecord = False
                    adapterUsers.Update(users, "users")
                    DataGridViewgastos.DataSource = carga_usuarios()
                    ' Me.DataGridViewgastos.Columns(0).Visible = False
                    Me.DataGridViewgastos.Columns(0).Width = 100
                    Me.DataGridViewgastos.Columns(1).Width = 250
                    'Me.DataGridViewgastos.Columns(3).Width = 150
                    MessageBox.Show("OPERACION REALIZADA CORRECTAMENTE")
                    clearfields()
                    users.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            Else
                MessageBox.Show("FALTAN DATOS NECESARIOS")

            End If
            'Else
            '    LblTip.Text = "LA CONTRASEÑA NO ES VALIDA DEBE CONTENER MINIMO 6 CARACTERES"
            '    TxtPass.Text = ""
            '    TxtPassConfirm.Text = ""
            '    TxtPass.Focus()
            'End If

        Else
            'LblTip.Text = "LA CONFIRMACION DE LA CONTRASEÑA ES INCORRECTA"
            'TxtPass.Text = ""
            'TxtPassConfirm.Text = ""
            MessageBox.Show("LA CONFIRMACION DE LA CONTRASEÑA ES INCORRECTA")
            TxtPass.Focus()
        End If



    End Sub
    Private Sub TxbNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxbNombre.KeyPress
        If newRecord = False Then


            If Asc(e.KeyChar) = Keys.Enter Then
                Try
                    users = New DataSet()
                    queryStringUsers = "select * from users where userID= '" & TxbNombre.Text & "' and companyID = '" & currentCompany & "'"
                    connectionUsers = New SqlConnection(connectionString)
                    connectionUsers.Open()
                    adapterUsers = New SqlDataAdapter
                    commandUsers = New SqlCommand(queryStringUsers, connectionUsers)
                    adapterUsers.SelectCommand = commandUsers
                    cmdBuilderUsers = New SqlCommandBuilder(adapterUsers)
                    cmdBuilderUsers.ConflictOption = ConflictOption.OverwriteChanges
                    adapterUsers.Fill(users, "users")

                    If users.Tables(0).Rows.Count > 0 Then
                        currentCompany = users.Tables(0).Rows(0).Item(0)
                        TxbNombre.Text = users.Tables(0).Rows(0).Item(1)
                        TxtPass.Text = users.Tables(0).Rows(0).Item(2)
                        TxtPassConfirm.Text = users.Tables(0).Rows(0).Item(2)
                        TxbUserName.Text = users.Tables(0).Rows(0).Item(3)
                        txbLastName.Text = users.Tables(0).Rows(0).Item(4)
                        UserType.SelectedIndex = users.Tables(0).Rows(0).Item(5)
                        btnDelete.Enabled = True
                        btnSave.Enabled = True
                        btnAdd.Enabled = True

                    Else
                        LblTip.Text = "El usuario NO existe"
                        clearfields()
                        MessageBox.Show("EL USUARIO NO EXISTE...")
                    End If

                Catch ex As Exception

                End Try
            End If


        Else
            If Asc(e.KeyChar) = Keys.Enter Then
                If TxbNombre.Text.Length = 0 Then
                    TxbNombre.Focus()
                Else
                    TxbUserName.Focus()
                End If


            End If

        End If



    End Sub
    Private Sub TxbUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxbUserName.KeyPress, TextBox1.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then
            If TxbUserName.Text.Length = 0 Then
                TxbUserName.Focus()
            Else
                TxtPass.Focus()
            End If


        End If

    End Sub


    Private Sub TxtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPass.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then
            If TxtPass.Text.Length = 0 Then
                TxtPass.Focus()
            Else
                TxtPassConfirm.Focus()
            End If


        End If

    End Sub



    Private Sub TxtPassConfirm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassConfirm.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then
            If TxtPassConfirm.Text.Length = 0 Then
                TxtPassConfirm.Focus()
            Else
                UserType.Focus()
            End If


        End If

    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'FormReporteUsuarios.Show()
    End Sub

    Private Sub TxbUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxbUserName.TextChanged, TextBox1.TextChanged

    End Sub

    Private Sub DataGridViewgastos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewgastos.CellClick
        TxbNombre.Text = DataGridViewgastos.Rows(DataGridViewgastos.CurrentRow.Index).Cells(0).Value
        Try
            users = New DataSet()
            queryStringUsers = "select * from users where userID= '" & TxbNombre.Text & "' and companyID = '" & currentCompany & "'"
            connectionUsers = New SqlConnection(connectionString)
            connectionUsers.Open()
            adapterUsers = New SqlDataAdapter
            commandUsers = New SqlCommand(queryStringUsers, connectionUsers)
            adapterUsers.SelectCommand = commandUsers
            cmdBuilderUsers = New SqlCommandBuilder(adapterUsers)
            cmdBuilderUsers.ConflictOption = ConflictOption.OverwriteChanges
            adapterUsers.Fill(users, "users")

            If users.Tables(0).Rows.Count > 0 Then
                currentCompany = users.Tables(0).Rows(0).Item(0)
                TxbNombre.Text = users.Tables(0).Rows(0).Item(1)
                TxtPass.Text = users.Tables(0).Rows(0).Item(2)
                TxtPassConfirm.Text = users.Tables(0).Rows(0).Item(2)
                TxbUserName.Text = users.Tables(0).Rows(0).Item(3)
                txbLastName.Text = users.Tables(0).Rows(0).Item(4)
                UserType.SelectedIndex = users.Tables(0).Rows(0).Item(5)
                btnDelete.Enabled = True
                btnSave.Enabled = True
                btnAdd.Enabled = True

            Else
                LblTip.Text = "El usuario NO existe"
                clearfields()
                MessageBox.Show("EL USUARIO NO EXISTE...")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class