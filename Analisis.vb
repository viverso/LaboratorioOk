Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Math


Public Class Analisis
    Dim analisisEnRecibo, clientesBusqueda As DataSet
    Dim connectionanalisisEnRecibo, connectionclientesBusqueda As SqlConnection
    Dim queryStringanalisisEnRecibo, queryStringclientesBusqueda As String
    Dim adapteranalisisEnRecibo, adapterclientesBusqueda, da As SqlDataAdapter
    Dim cmdBuilderAnalisis, cmdBuilderclientesBusqueda As SqlCommandBuilder
    Dim dt As DataTable
    Dim commandAnalisis, commandclientesBusqueda As SqlCommand

    Private Sub Analisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridViewEstudios.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular)
        cargaanalisisEnRecibo()
    End Sub


    Private Sub cargaanalisisEnRecibo()
        Dim i As Integer

        Try
            analisisEnRecibo = New DataSet()
            connectionanalisisEnRecibo = New SqlConnection(connectionString)
            queryStringanalisisEnRecibo = "select * from recibo where companyID='" & currentCompany & "'" & " order by idRecibo"
            connectionanalisisEnRecibo.Open()
            adapteranalisisEnRecibo = New SqlDataAdapter
            commandAnalisis = New SqlCommand(queryStringanalisisEnRecibo, connectionanalisisEnRecibo)
            adapteranalisisEnRecibo.SelectCommand = commandAnalisis
            cmdBuilderAnalisis = New SqlCommandBuilder(adapteranalisisEnRecibo)
            cmdBuilderAnalisis.ConflictOption = ConflictOption.OverwriteChanges
            adapteranalisisEnRecibo.Fill(analisisEnRecibo, "recibo")
            ComboanalisisEnRecibo.Items.Clear()
            'ComboanalisisEnRecibo.Items.Add("SELECCIONE EL ESTUDIO...")
            For i = 0 To analisisEnRecibo.Tables(0).Rows.Count - 1

                ComboanalisisEnRecibo.Items.Add(analisisEnRecibo.Tables(0).Rows(i).Item(0) & " - " & buscaCliente(analisisEnRecibo.Tables(0).Rows(i).Item(3)) & "  " & "FECHA: " & analisisEnRecibo.Tables(0).Rows(i).Item(4))
            Next
            ComboanalisisEnRecibo.SelectedIndex = 0
        Catch ex As Exception

        End Try
        
    End Sub

    Function buscaCliente(ByVal idcliente As String) As String
        Try
            clientesBusqueda = New DataSet()
            queryStringclientesBusqueda = "select firstName,lastName from clients where  clientID='" & idcliente & "' "
            connectionclientesBusqueda = New SqlConnection(connectionString)
            connectionclientesBusqueda.Open()
            adapterclientesBusqueda = New SqlDataAdapter
            commandclientesBusqueda = New SqlCommand(queryStringclientesBusqueda, connectionclientesBusqueda)
            adapterclientesBusqueda.SelectCommand = commandclientesBusqueda
            cmdBuilderclientesBusqueda = New SqlCommandBuilder(adapterclientesBusqueda)
            cmdBuilderclientesBusqueda.ConflictOption = ConflictOption.OverwriteChanges
            adapterclientesBusqueda.Fill(clientesBusqueda, "clients")
            'txtPeriodoAnterior.Text = clientesBusqueda.Tables(0).Rows(0).Item(0).ToString()
            'DateTimePickerfecha1.Text = clientesBusqueda.Tables(0).Rows(0).Item(1).ToString()
            'DateTimePickerfecha2.Text = clientesBusqueda.Tables(0).Rows(0).Item(2).ToString()

            'adapterclientesBusqueda.Update(clientesBusqueda, "clientesBusqueda")

        Catch ex As Exception
            MessageBox.Show("NO EXISTEN PERIODOS PARA ESTA FECHA...")
        End Try

        Return clientesBusqueda.Tables(0).Rows(0).Item(0).ToString() & " " & clientesBusqueda.Tables(0).Rows(0).Item(1).ToString()
        closeclientesBusqueda()
    End Function
    Sub closeclientesBusqueda()
        connectionclientesBusqueda.Close()
        clientesBusqueda.Clear()
        clientesBusqueda.Dispose()
        adapterclientesBusqueda.Dispose()
        clientesBusqueda.Clear()
        commandclientesBusqueda.Dispose()
        commandclientesBusqueda.Dispose()
        cmdBuilderclientesBusqueda.Dispose()
    End Sub

    Private Sub ComboanalisisEnRecibo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboanalisisEnRecibo.SelectedIndexChanged
        buscaEstudios(ComboanalisisEnRecibo.Text.Substring(0, 6))

    End Sub

    Private Sub buscaEstudios(ByVal idRecibo As String)
        Try
            Dim seleccion As String = "SELECT idEstudio,Descripcion FROM detalleRecibo where  idRecibo=" & idRecibo  ' "
            da = New SqlDataAdapter(seleccion, connectionString)
            dt = New DataTable
            da.Fill(dt)

            Me.DataGridViewEstudios.DataSource = dt



            da.Dispose()


        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub DataGridViewEstudios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewEstudios.CellDoubleClick


        capturaEstudios.txtPaciente.Text = DataGridViewEstudios.Rows(DataGridViewEstudios.CurrentRow.Index).Cells(1).Value.ToString()
        capturaEstudios.txtRegistro.Text = ComboanalisisEnRecibo.Text.Substring(0, 6)
        capturaEstudios.idEstudio.Text = DataGridViewEstudios.Rows(DataGridViewEstudios.CurrentRow.Index).Cells(0).Value.ToString()
        capturaEstudios.Show()
    End Sub
End Class