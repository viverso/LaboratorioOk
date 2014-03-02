Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class especialidad
    Dim especialidad, companyParameters, especialidad1, usersesp As DataSet
    Dim connectionespecialidad, connectionCompanyParameters, connectionespecialidad1, connectionusersesp As SqlConnection
    Dim queryStringespecialidad, queryStringCompanyParameters, queryStringespecialidad1, queryStringusersesp As String
    Dim adapterespecialidad, adapterCompanyParameters, adapterespecialidad1, adapterusersesp As SqlDataAdapter
    Dim commandEspecilidad, commandCompanyParameters, commandespecialidad1, commandusersesp As SqlCommand
    Dim cmdBuilderEspecialidad, cmdBuilderCompanyParameters, cmdBuilderespecialidad1, cmdBuilderusersesp As SqlCommandBuilder
    Dim newRecord As Boolean
    Private Sub especialidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        newRecord = False
        cargaespecialidad()
    End Sub

    Private Sub cargaespecialidad()
        Dim i As Integer
        especialidad = New DataSet()
        connectionespecialidad = New SqlConnection(connectionString)
        queryStringespecialidad = "select * from especialidades order by idEsp"
        connectionespecialidad.Open()
        adapterespecialidad = New SqlDataAdapter
        commandEspecilidad = New SqlCommand(queryStringespecialidad, connectionespecialidad)
        adapterespecialidad.SelectCommand = commandEspecilidad
        cmdBuilderEspecialidad = New SqlCommandBuilder(adapterespecialidad)
        cmdBuilderEspecialidad.ConflictOption = ConflictOption.OverwriteChanges
        adapterespecialidad.Fill(especialidad, "especialidades")
        Comboespecialidad.Items.Clear()
        Comboespecialidad.Items.Add("SELECCIONE UNA ESPECIALIDAD...")
        For i = 0 To especialidad.Tables(0).Rows.Count - 1

            Comboespecialidad.Items.Add(especialidad.Tables(0).Rows(i).Item(0) & " - " & especialidad.Tables(0).Rows(i).Item(1))
        Next
        Comboespecialidad.SelectedIndex = 0
    End Sub

    Private Sub Comboespecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Comboespecialidad.SelectedIndexChanged
        Dim cadena As String
        cadena = Comboespecialidad.Text.Substring(0, 2)

        If (cadena <> "SE") Then
            IDEstudio.Text = Comboespecialidad.Text.Substring(0, 2)
            TxtDescripcion.Text = Comboespecialidad.Text.Substring(4, Comboespecialidad.Text.Length - 4)
            newRecord = False
            btnSave.Enabled = True
            btnDelete.Enabled = True
        Else
            btnSave.Enabled = False
            btnDelete.Enabled = False
            IDEstudio.Text = ""
            TxtDescripcion.Text = ""
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim remisionFolio As String
        Try
            If newRecord Then
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
                companyParameters.Tables(0).Rows(0).Item(17) += 1 'Id del estudio
                remisionFolio = CType(companyParameters.Tables(0).Rows(0).Item(17), String)
                adapterCompanyParameters.Update(companyParameters, "companyParameters")
                companyParameters.Clear()
                companyParameters.Dispose()
                connectionCompanyParameters.Close()
                adapterCompanyParameters.Dispose()
                commandCompanyParameters.Dispose()
                cmdBuilderCompanyParameters.Dispose()
                IDEstudio.Text = remisionFolio.PadLeft(2, "0")
            End If
            especialidad1 = New DataSet()
            queryStringespecialidad1 = "select * from especialidades where  idEsp='" & IDEstudio.Text & "'"
            connectionespecialidad1 = New SqlConnection(connectionString)
            connectionespecialidad1.Open()
            adapterespecialidad1 = New SqlDataAdapter
            commandespecialidad1 = New SqlCommand(queryStringespecialidad1, connectionespecialidad1)
            adapterespecialidad1.SelectCommand = commandespecialidad1
            cmdBuilderespecialidad1 = New SqlCommandBuilder(adapterespecialidad1)
            cmdBuilderespecialidad1.ConflictOption = ConflictOption.OverwriteChanges
            adapterespecialidad1.Fill(especialidad1, "especialidades")
            'Me.especialidad1.WriteXml("encabezadoremision.xml")
            If newRecord Then
                especialidad1.Tables(0).Rows.Add()
            End If
            especialidad1.Tables(0).Rows(0).Item(0) = IDEstudio.Text
            especialidad1.Tables(0).Rows(0).Item(1) = TxtDescripcion.Text
            
          

            adapterespecialidad1.Update(especialidad1, "especialidades")

            especialidad1.Clear()
            especialidad1.Dispose()
            connectionespecialidad1.Close()
            adapterespecialidad1.Dispose()
            commandespecialidad1.Dispose()
            cmdBuilderespecialidad1.Dispose()

            newRecord = False
            btnSave.Enabled = False
            TxtDescripcion.Text = ""
            IDEstudio.Text = ""
            cargaespecialidad()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        newRecord = True
        btnSave.Enabled = True
        TxtDescripcion.Text = ""
        IDEstudio.Text = ""
        TxtDescripcion.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        TxtDescripcion.Text = ""
        IDEstudio.Text = ""
        newRecord = False
        btnSave.Enabled = False
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim respuesta As Integer
        respuesta = MsgBox(" ¿Realmente Desea Eliminar esta Especialidad? ", MsgBoxStyle.OkCancel, "ADVERTENCIA")
        If respuesta = 1 Then
            usersesp = New DataSet()
            queryStringusersesp = "delete from especialidades where idEsp= '" & IDEstudio.Text & "' "
            connectionusersesp = New SqlConnection(connectionString)
            connectionusersesp.Open()
            adapterusersesp = New SqlDataAdapter
            commandusersesp = New SqlCommand(queryStringusersesp, connectionusersesp)
            adapterusersesp.SelectCommand = commandusersesp
            cmdBuilderusersesp = New SqlCommandBuilder(adapterusersesp)
            cmdBuilderusersesp.ConflictOption = ConflictOption.OverwriteChanges
            adapterusersesp.Fill(usersesp, "especialidades")
           
            btnDelete.Enabled = False
            btnSave.Enabled = False
            TxtDescripcion.Text = ""
            IDEstudio.Text = ""
            cargaespecialidad()
        End If
    End Sub
End Class