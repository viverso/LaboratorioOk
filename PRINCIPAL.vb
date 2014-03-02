Public Class PRINCIPAL

    Private Sub submenu0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu0.Click
        formDoctores.Show()
    End Sub

    Private Sub submenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Usuarios.Show()
    End Sub

    Private Sub submenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu1.Click
        Estudios.Show()
    End Sub

    Private Sub RelojChecadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelojChecadorToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub submenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu3.Click
        'Estudios.Show()
        especialidad.Show()
    End Sub

    Private Sub ParametrosEstudioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametrosEstudioToolStripMenuItem.Click
        ParametrosEstudio.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        clientsCatalog.Show()
    End Sub

    Private Sub submenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu5.Click
        Recibo1.Show()
    End Sub

    Private Sub submenu4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu4.Click
        Usuarios.Show()
    End Sub

    Private Sub submenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu6.Click
        'Analisis.Show()
        gastos.Show()
    End Sub

 
    Private Sub ConsultasDeAdeudiClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Adeudo_clientes.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Form_reiniciaFolio.Show()

    End Sub

    Private Sub DescuentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescuentosToolStripMenuItem.Click
        descuentos.Show()
    End Sub
End Class