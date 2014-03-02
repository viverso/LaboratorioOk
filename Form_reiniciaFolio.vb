Imports System.Diagnostics
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class Form_reiniciaFolio
    Dim folioinicializar As DataSet
    Dim connectionfolioinicializar As SqlConnection
    Dim queryStringfolioinicializar As String
    Dim adapterfolioinicializar As SqlDataAdapter
    Dim commandEspecilidad As SqlCommand
    Dim cmdBuilderfolioinicializar As SqlCommandBuilder


    Private Sub cargafolio()
        Dim i As Integer
        folioinicializar = New DataSet()
        connectionfolioinicializar = New SqlConnection(connectionString)
        queryStringfolioinicializar = "select foliorecibo from companyParameters where companyID='" & currentCompany & "'"
        connectionfolioinicializar.Open()
        adapterfolioinicializar = New SqlDataAdapter
        commandEspecilidad = New SqlCommand(queryStringfolioinicializar, connectionfolioinicializar)
        adapterfolioinicializar.SelectCommand = commandEspecilidad
        cmdBuilderfolioinicializar = New SqlCommandBuilder(adapterfolioinicializar)
        cmdBuilderfolioinicializar.ConflictOption = ConflictOption.OverwriteChanges
        adapterfolioinicializar.Fill(folioinicializar, "foliorecibo")
        txtFolio.Text = folioinicializar.Tables(0).Rows(0).Item(0)


    End Sub



    Private Sub Form_reiniciaFolio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargafolio()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtFolio.Text = ""

    End Sub

    Private Sub actualiza_folio(ByVal empresa As String, ByVal folio As Integer)
        Try

            Dim oConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(connectionString)

            Dim oCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand("inicializafolio", oConexion)

            Dim oParameter As SqlClient.SqlParameter


            oParameter = oCommand.Parameters.Add("@folio", SqlDbType.Int)
            oParameter.Value = folio
            oParameter = oCommand.Parameters.Add("@company", SqlDbType.VarChar, 6)
            oParameter.Value = empresa

            oCommand.CommandType = CommandType.StoredProcedure

            oConexion.Open()
            oCommand.ExecuteNonQuery()
            oConexion.Close()
            oCommand.Dispose()
            'Dispose()

            MessageBox.Show("SE ACTUALIZO EL FOLIO CORRECTAMENTE...")
        Catch ex As Exception
            'oCommand.Dispose()
            System.Windows.Forms.MessageBox.Show(ex.Message.ToString + " " + "error")
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        actualiza_folio(currentCompany, txtFolio.Text)
        txtFolio.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class