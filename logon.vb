Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class logon
    Dim datasetTrabajadores1 As DataSet
    Dim connectionTrabajador1 As SqlConnection
    Dim adapterTrabajador1 As SqlDataAdapter
    Dim commandTrabajador1 As SqlCommand
    Dim cmdBuilderTrabajador1 As SqlCommandBuilder
    Dim queryStringCompanies1 As String

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Me.Close()
    End Sub

    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click, PasswordTextBox.AcceptsTabChanged
        connectionUsers = New SqlConnection(connectionString)
        Using connectionUsers
            Try

                users = New DataSet()
                queryStringUsers = "select * from users where userID='" & Me.UseridTextBox.Text & "' and companyID='" & currentCompany & "'"
                connectionUsers.Open()
                adapterUsers = New SqlDataAdapter
                commandUsers = New SqlCommand(queryStringUsers, connectionUsers)
                adapterUsers.SelectCommand = commandUsers
                cmdBuilderUsers = New SqlCommandBuilder(adapterUsers)
                cmdBuilderUsers.ConflictOption = ConflictOption.OverwriteChanges
                adapterUsers.Fill(users, "Users")

                If users.Tables(0).Rows.Count = 0 Or users.Tables(0).Rows(0).Item(1) <> Me.UseridTextBox.Text Or users.Tables(0).Rows(0).Item(2) <> Me.PasswordTextBox.Text Then
                    'LabelError.Show()
                    'LabelError.Focus()

                    'errordeconexion.Visible = False
                    MessageBox.Show("El usuario no existe o la clave es incorrecta...")
                Else
                    currentUser = UseridTextBox.Text
                    currentUserName = users.Tables(0).Rows(0).Item(3) & " " & users.Tables(0).Rows(0).Item(4)
                    'PrivLev = users.Tables(0).Rows(0).Item(5)
                    'usuarioActivo = datasetTrabajadores1.Tables(1).Rows.Count
                    connectionUsers.Close()
                    users.Clear()
                    users.Dispose()
                    adapterUsers.Dispose()
                    commandUsers.Dispose()
                    cmdBuilderUsers.Dispose()

                    marks = New DataSet()
                    queryStringMarks = "select iva from companyParameters where companyID= '" & currentCompany & "'"
                    connectionMarks = New SqlConnection(connectionString)
                    connectionMarks.Open()
                    adapterMarks = New SqlDataAdapter
                    commandMarks = New SqlCommand(queryStringMarks, connectionMarks)
                    adapterMarks.SelectCommand = commandMarks
                    cmdBuilderMarks = New SqlCommandBuilder(adapterMarks)
                    cmdBuilderMarks.ConflictOption = ConflictOption.OverwriteChanges
                    adapterMarks.Fill(marks, "companyParameters")
                    iva = marks.Tables(0).Rows(0).Item(0) / 100               ' Me.prin = marks.Tables(0).Rows(0).Item(16)

                    Me.Hide()
                    'If PrivLev = 0 Then
                    PRINCIPAL.ToolStripStatusLabelEmpresa.Text = currentCompanyName
                    PRINCIPAL.ToolStripStatusUsuario.Text = currentUserName
                    'If UseridTextBox.Text = "reloj" Then
                    '    Checador.Show()
                    'Else
                    PRINCIPAL.Show()
                    'buscaNumeroCargaTrabajadores()
                    'End If



                End If

                'End If
            Catch ex As Exception

                'errordeconexion.Show()
                'errordeconexion.Focus()
            End Try

        End Using
    End Sub

    Private Sub logon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.login1.StartPosition = FormStartPosition.CenterScreen

        'f.ShowDialog()


        Dim i As Integer = 0
        Me.UseridTextBox.Focus()
        compania = New DataSet()
        connectionCompania = New SqlConnection(connectionString)
        queryStringCompanies = "select * from companies"
        connectionCompania.Open()
        adapterCompanies = New SqlDataAdapter
        commandCompanies = New SqlCommand(queryStringCompanies, connectionCompania)
        adapterCompanies.SelectCommand = commandCompanies
        cmdBuilderCompanies = New SqlCommandBuilder(adapterCompanies)
        cmdBuilderCompanies.ConflictOption = ConflictOption.OverwriteChanges
        adapterCompanies.Fill(compania, "companies")
        For i = 0 To compania.Tables(0).Rows.Count - 1
            ComboBoxCompania.Items.Add(compania.Tables(0).Rows(i).Item(0) & " - " & compania.Tables(0).Rows(i).Item(1) & " " & compania.Tables(0).Rows(i).Item(2))
        Next
        ComboBoxCompania.SelectedIndex = 0
        Me.UseridTextBox.Select()
        compania.Clear()
        compania.Dispose()
        adapterCompanies.Dispose()

        connectionCompania.Dispose()
        commandCompanies.Dispose()
        cmdBuilderCompanies.Dispose()
        currentCompany = ComboBoxCompania.Text.Substring(0, 6)
    End Sub
    Private Sub buscaNumeroCargaTrabajadores()
        ' Dim i As Integer
        maxRows = 0

        datasetTrabajadores1 = New DataSet()
        connectionTrabajador1 = New SqlConnection(connectionString)
        queryStringCompanies1 = "select * from trabajadores where companyID='" & currentCompany & "'"
        connectionTrabajador1.Open()
        adapterTrabajador1 = New SqlDataAdapter
        commandTrabajador1 = New SqlCommand(queryStringCompanies1, connectionTrabajador1)
        adapterTrabajador1.SelectCommand = commandTrabajador1
        cmdBuilderTrabajador1 = New SqlCommandBuilder(adapterTrabajador1)
        cmdBuilderTrabajador1.ConflictOption = ConflictOption.OverwriteChanges
        adapterTrabajador1.Fill(datasetTrabajadores1, "trabajadores")

        maxRows = datasetTrabajadores1.Tables(0).Rows.Count

        datasetTrabajadores1.Clear()
        datasetTrabajadores1.Dispose()
        connectionTrabajador1.Close()
        adapterTrabajador1.Dispose()
        commandTrabajador1.Dispose()
        cmdBuilderTrabajador1.Dispose()
    End Sub

    Private Sub ComboBoxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCompania.SelectedIndexChanged
        Dim pos As Integer
        Dim s As String
        s = ComboBoxCompania.SelectedItem()
        pos = InStr(s, "-")
        currentCompany = Mid(s, 1, pos - 2)
        currentCompanyName = Mid(s, pos + 2, s.Length - pos)

    End Sub
    Friend WithEvents LabelErrorConnecting As System.Windows.Forms.Label

    Private Sub PasswordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PasswordTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If PasswordTextBox.Text.Length > 0 Then
                ButtonAceptar.PerformClick()
            Else
                PasswordTextBox.Focus()
            End If
        End If
    End Sub
    Private Sub KeypressUseridTextBox_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UseridTextBox.KeyPress

        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                If UseridTextBox.Text.Length > 0 Then
                    Try
                        PasswordTextBox.Focus()
                    Catch ex As Exception

                    End Try


                End If

        End Select

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class

