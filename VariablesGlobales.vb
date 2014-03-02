Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math
Module VariablesGlobales
    Public descuento_d As Decimal
    Public maxRows As Integer
    Public lastUsed1 As Integer
    Public ActiveDatabases, details As New ArrayList
    Public connectionString As String = "Data Source=Server\DATABASESERVER;Initial Catalog=LABORATORIO; user=SA; password=roca2421"
    'Public connectionString As String = "Data Source=Server\DATABASESERVER;Initial Catalog=LABORATORIO; user=SA; password=741120"
    Public connectionUsers, connectionOrders, connectionProducts, connectionMarks, connectionLines, connectionDelete, connectionClients, connectionSuppliers, connectionClaves As SqlConnection
    Public connectionPermanent, connectionCompania As SqlConnection
    Public commandUsers, commandOrders, commandProducts, commandMarks, commandLines, commandDelete, commandClients, commandSuppliers, commandClaves As SqlCommand
    Public commandPermanent, commandCompanies As SqlCommand
    Public queryStringUsers, queryStringOrders, queryStringProducts, queryStringMarks, queryStringLines, queryStringDelete, queryStringClients, queryStringSuppliers, queryStringClaves As String
    Public querystringPermanent, queryStringCompanies As String
    Public adapterUsers, adapterOrders, adapterProducts, adapterMarks, adapterLines, adapterDelete, adapterClients, adapterSuppliers, adapterClaves As SqlDataAdapter
    Public adapterPermanent, adapterCompanies As SqlDataAdapter
    Public cmdBuilderUsers, cmdBuilderOrders, cmdBuilderProducts, cmdBuilderMarks, cmdBuilderLines, cmdBuilderDelete, cmdBuilderClients, cmdBuilderSuppliers As SqlCommandBuilder
    Public cmdBuilderPermanent, cmdBuilderCompanies, cmdBuilderClaves As SqlCommandBuilder
    Public claves, users, orders, products, marks, lines, clients, compania, dsdelete, suppliers, permanentDB As DataSet

    Public comboBoxMark, comboBoxLine As ComboBox
    Public currentCompany, currentCompanyName, currentUser, currentUserName As String
    Public iva As Decimal
    Dim units(10) As String      'Unidades
    Dim tens(10) As String      'Decenas
    Dim hundreds(10) As String      'Cientos
    Dim de(20) As String    'Especiales
    Dim segments(5) As String
    Public Sub LoadGenericComboBox(ByRef comboBoxSt As ComboBox, ByVal qs As String, ByVal dbS As String, ByVal cbSize As Size, ByVal CbPosition As Point, ByRef cbParent As System.Windows.Forms.GroupBox)
        Dim i As Integer
        Try
            comboBoxSt.Parent = cbParent
        Catch ex As Exception
            comboBoxSt = New ComboBox
            comboBoxSt.Parent = cbParent
        End Try
        comboBoxSt.Parent = cbParent
        comboBoxSt.Location = CbPosition
        comboBoxSt.Size = cbSize
        dsdelete = New DataSet()
        queryStringDelete = qs
        connectionDelete = New SqlConnection(connectionString)
        connectionDelete.Open()
        adapterDelete = New SqlDataAdapter
        commandDelete = New SqlCommand(queryStringDelete, connectionDelete)
        adapterDelete.SelectCommand = commandDelete
        cmdBuilderDelete = New SqlCommandBuilder(adapterDelete)
        cmdBuilderDelete.ConflictOption = ConflictOption.OverwriteChanges
        adapterDelete.Fill(dsdelete, dbS)
        For i = 0 To dsdelete.Tables(0).Rows.Count - 1
            comboBoxSt.Items.Add(dsdelete.Tables(0).Rows(i).Item(0) & " - " & dsdelete.Tables(0).Rows(i).Item(1))
        Next
        dsdelete.Clear()
        dsdelete.Dispose()
        connectionDelete.Close()
        connectionDelete.Dispose()
        commandDelete.Dispose()
        cmdBuilderDelete.Dispose()
        adapterDelete.Dispose()
        comboBoxSt.SelectedIndex = 0
        comboBoxSt.Visible = True
    End Sub
    Public Function convertAmountToString(ByVal amount As Decimal) As String
        Dim i As Integer = 0
        Dim resultString As String = ""
        If amount <= 0 Then
            Return "CERO PESOS 00/100 M.N."
        End If
        units(1) = "UN"
        units(2) = "DOS"
        units(3) = "TRES"
        units(4) = "CUATRO"
        units(5) = "CINCO"
        units(6) = "SEIS"
        units(7) = "SIETE"
        units(8) = "OCHO"
        units(9) = "NUEVE"

        tens(1) = "DIEZ"
        tens(2) = "VEINTE"
        tens(3) = "TREINTA"
        tens(4) = "CUARENTA"
        tens(5) = "CINCUENTA"
        tens(6) = "SESENTA"
        tens(7) = "SETENTA"
        tens(8) = "OCHENTA"
        tens(9) = "NOVENTA"

        de(1) = "ONCE"
        de(2) = "DOCE"
        de(3) = "TRECE"
        de(4) = "CATORCE"
        de(5) = "QUINCE"
        de(6) = "DIECISEIS"
        de(7) = "DIECISIETE"
        de(8) = "DIECIOCHO"
        de(9) = "DIECINUEVE"
        de(11) = "VEINTIUN"
        de(12) = "VEINTIDOS"
        de(13) = "VEINTITRES"
        de(14) = "VEINTICUATRO"
        de(15) = "VEINTICINCO"
        de(16) = "VEINTISEIS"
        de(17) = "VEINTISIETE"
        de(18) = "VEINTIOCHO"
        de(19) = "VEINTINUEVE"

        hundreds(1) = "CIEN"
        hundreds(2) = "DOSCIENTOS"
        hundreds(3) = "TRESCIENTOS"
        hundreds(4) = "CUATROCIENTOS"
        hundreds(5) = "QUINIENTOS"
        hundreds(6) = "SEISCIENTOS"
        hundreds(7) = "SETECIENTOS"
        hundreds(8) = "OCHOCIENTOS"
        hundreds(9) = "NOVECIENTOS"

        Dim decpart As Decimal = (amount - System.Math.Floor(amount)) * 100
        Dim strOfNum As String = Round(amount - decpart / 100).ToString

        While strOfNum.Length < 15
            strOfNum = "0" & strOfNum
        End While

        For i = 1 To 5
            segments(i) = getGroup(Mid(strOfNum, i * 3 - 2, 3))
        Next

        If segments(1).Length > 0 Then
            resultString = segments(1) & " BILLON" & IIf(CType(Mid(strOfNum, 1, 3), Integer) > 1, "ES ", " ")
        End If
        If segments(2) <> "" Then
            resultString = resultString & segments(1) & " MIL"
        End If
        If segments(3) <> "" Then
            resultString = resultString & segments(3) & " MILLON" & IIf(CType(Mid(strOfNum, 7, 3), Integer) > 1, "ES ", " ")
        End If
        If segments(4) <> "" Then
            resultString = resultString & segments(4) & " MIL "
        End If

        resultString = resultString & segments(5) & IIf((Round(amount) - 1000000 * Round(Round(amount) / 1000000)) = 0, " DE", "") & " PESO" & IIf(amount > 1, "S ", "")

        Dim t As String

        t = decpart.ToString
        t = t.Substring(0, t.IndexOf("."))
        t = t.PadLeft(2, "0")

        t = IIf(Mid(t, 2, 1) = ".", Mid(t, 1, 1) & "0", Mid(t, 1, 2))
        t = t & IIf(t.Length = 1, "0", "")
        resultString = "(" & resultString & t & "/100 M.N.)"

        Return resultString
    End Function
    Public Sub loadDataGridView(ByRef currentDGV As DataGridView, ByRef dgvParent As System.Windows.Forms.Form, ByVal dgvSize As Size, ByVal dgvLocation As Point, ByVal db As String, ByVal queryDGV As String, ByVal fieldsToShow As Integer)
        permanentDB = New DataSet()
        querystringPermanent = queryDGV
        connectionPermanent = New SqlConnection(connectionString)
        connectionPermanent.Open()
        adapterPermanent = New SqlDataAdapter
        commandPermanent = New SqlCommand(querystringPermanent, connectionPermanent)
        adapterPermanent.SelectCommand = commandPermanent
        cmdBuilderPermanent = New SqlCommandBuilder(adapterPermanent)
        cmdBuilderPermanent.ConflictOption = ConflictOption.OverwriteChanges
        adapterPermanent.Fill(permanentDB, db)

        currentDGV = New DataGridView

        currentDGV.Parent = dgvParent
        currentDGV.Location = dgvLocation
        currentDGV.Size = dgvSize
        currentDGV.DataSource = permanentDB
        currentDGV.DataMember = db
        currentDGV.BorderStyle = BorderStyle.Fixed3D
        currentDGV.ReadOnly = True
        currentDGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        currentDGV.AllowUserToAddRows = False
        currentDGV.AllowUserToDeleteRows = False
        currentDGV.AllowUserToOrderColumns = False
        currentDGV.AllowUserToResizeColumns = False
        currentDGV.AllowUserToResizeRows = False
        currentDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        currentDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        currentDGV.MultiSelect = False
        currentDGV.Columns.Item(0).Visible = True
        currentDGV.Columns.Item(0).Width = 250
        currentDGV.Columns.Item(1).Width = 250
        currentDGV.Columns.Item(1).Visible = True
        If fieldsToShow = 3 Then
            currentDGV.Columns.Item(2).Width = 250
            currentDGV.Columns.Item(2).Visible = True
        End If
        Dim i As Integer
        For i = fieldsToShow To currentDGV.Columns.Count - 1
            currentDGV.Columns.Item(2).Visible = False
        Next
        currentDGV.BringToFront()
    End Sub
    Public Sub loadDataGridView1(ByRef currentDGV As DataGridView, ByRef dgvParent As System.Windows.Forms.Form, ByVal dgvSize As Size, ByVal dgvLocation As Point, ByVal db As String, ByVal queryDGV As String, ByVal fieldsToShow As Integer)
        permanentDB = New DataSet()
        querystringPermanent = queryDGV
        connectionPermanent = New SqlConnection(connectionString)
        connectionPermanent.Open()
        adapterPermanent = New SqlDataAdapter
        commandPermanent = New SqlCommand(querystringPermanent, connectionPermanent)
        adapterPermanent.SelectCommand = commandPermanent
        cmdBuilderPermanent = New SqlCommandBuilder(adapterPermanent)
        cmdBuilderPermanent.ConflictOption = ConflictOption.OverwriteChanges
        adapterPermanent.Fill(permanentDB, db)

        currentDGV = New DataGridView

        currentDGV.Parent = dgvParent
        currentDGV.Location = dgvLocation
        currentDGV.Size = dgvSize
        currentDGV.DataSource = permanentDB
        currentDGV.DataMember = db
        currentDGV.BorderStyle = BorderStyle.Fixed3D
        currentDGV.ReadOnly = True
        currentDGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        currentDGV.AllowUserToAddRows = False
        currentDGV.AllowUserToDeleteRows = False
        currentDGV.AllowUserToOrderColumns = False
        currentDGV.AllowUserToResizeColumns = False
        currentDGV.AllowUserToResizeRows = False
        currentDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        currentDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        currentDGV.MultiSelect = False
        currentDGV.Columns.Item(0).Visible = True
        currentDGV.Columns.Item(0).Width = 250
        currentDGV.Columns.Item(1).Width = 250
        currentDGV.Columns.Item(1).Visible = True
        If fieldsToShow = 3 Then
            currentDGV.Columns.Item(2).Width = 250
            currentDGV.Columns.Item(2).Visible = True
        End If
        Dim i As Integer
        For i = fieldsToShow To currentDGV.Columns.Count - 1
            currentDGV.Columns.Item(2).Visible = False
        Next
        currentDGV.BringToFront()
    End Sub

    Private Function getGroup(ByVal s As String) As String
        Dim i As Integer = 0

        If s.Length = 0 Then
            Return ""
        End If
        Dim c1, d1, s1, s2, u1, t, strNumber As String
        c1 = ""
        If Mid(s, 1, 1) <> "0" Then
            c1 = hundreds(CType(Mid(s, 1, 1), Integer)) + IIf(CType(s, Integer) > 100 And CType(s, Integer) < 200, "TO ", " ")
        End If

        d1 = ""
        u1 = ""
        s1 = (Mid(s, 2, 1))
        s2 = Mid(s, 3, 1)
        If (s1 = "1" Or s1 = "2") And s2 <> "0" Then
            t = s1 & s2
            d1 = de(CType(t, Integer) - 10)
        Else
            If s1 <> "0" Then
                d1 = tens(CType(s1, Integer))
            End If
            If s2 <> "0" Then
                u1 = units(CType(s2, Integer))
            End If
        End If
        strNumber = IIf(s1.Length > 0 And s2.Length > 0, c1 & "" & d1, c1 & d1)
        If Not ((s1 = "1" Or s1 = "2") And s2 <> "0") Then
            If ((strNumber.Length > 0 And u1.Length > 0) And Not (s1 = "0" And s2 <> "0")) Then
                strNumber = strNumber & " Y "
            Else
                strNumber = strNumber & ""
            End If
            strNumber = strNumber & u1
        End If
        Return strNumber
    End Function
End Module
