<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRINCIPAL
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRINCIPAL))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabelEmpresa = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusUsuario = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DescuentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu0 = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu1 = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu3 = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametrosEstudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu5 = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TerminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.submenu9 = New System.Windows.Forms.ToolStripMenuItem
        Me.RelojChecadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabelEmpresa, Me.ToolStripStatusLabel3, Me.ToolStripStatusUsuario})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 477)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1047, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel2.Text = "Empresa:"
        '
        'ToolStripStatusLabelEmpresa
        '
        Me.ToolStripStatusLabelEmpresa.Name = "ToolStripStatusLabelEmpresa"
        Me.ToolStripStatusLabelEmpresa.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(52, 17)
        Me.ToolStripStatusLabel3.Text = "Usuario:"
        '
        'ToolStripStatusUsuario
        '
        Me.ToolStripStatusUsuario.Name = "ToolStripStatusUsuario"
        Me.ToolStripStatusUsuario.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Lavender
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EdicionToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.TerminarToolStripMenuItem, Me.RelojChecadorToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1047, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.DescuentosToolStripMenuItem, Me.submenu0, Me.submenu1, Me.submenu3, Me.submenu4, Me.ParametrosEstudioToolStripMenuItem})
        Me.EdicionToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.EdicionToolStripMenuItem.Text = "&Catalogos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ClientesToolStripMenuItem.Text = "&Clientes"
        '
        'DescuentosToolStripMenuItem
        '
        Me.DescuentosToolStripMenuItem.Name = "DescuentosToolStripMenuItem"
        Me.DescuentosToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DescuentosToolStripMenuItem.Text = "&Descuentos"
        '
        'submenu0
        '
        Me.submenu0.Name = "submenu0"
        Me.submenu0.Size = New System.Drawing.Size(167, 22)
        Me.submenu0.Text = "&Doctores"
        '
        'submenu1
        '
        Me.submenu1.Name = "submenu1"
        Me.submenu1.Size = New System.Drawing.Size(167, 22)
        Me.submenu1.Text = "&Estudios"
        '
        'submenu3
        '
        Me.submenu3.Name = "submenu3"
        Me.submenu3.Size = New System.Drawing.Size(167, 22)
        Me.submenu3.Text = "Es&pecialidades"
        '
        'submenu4
        '
        Me.submenu4.Name = "submenu4"
        Me.submenu4.Size = New System.Drawing.Size(167, 22)
        Me.submenu4.Text = "&Usuarios"
        '
        'ParametrosEstudioToolStripMenuItem
        '
        Me.ParametrosEstudioToolStripMenuItem.Name = "ParametrosEstudioToolStripMenuItem"
        Me.ParametrosEstudioToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ParametrosEstudioToolStripMenuItem.Text = "Parametros Estudio"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.submenu5, Me.submenu6, Me.ToolStripMenuItem1})
        Me.ReportesToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ReportesToolStripMenuItem.Text = "&Procesos"
        '
        'submenu5
        '
        Me.submenu5.Name = "submenu5"
        Me.submenu5.Size = New System.Drawing.Size(152, 22)
        Me.submenu5.Text = "&Recibo"
        '
        'submenu6
        '
        Me.submenu6.Name = "submenu6"
        Me.submenu6.Size = New System.Drawing.Size(152, 22)
        Me.submenu6.Text = "&Gastos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "&Inicializa Folio"
        '
        'TerminarToolStripMenuItem
        '
        Me.TerminarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.submenu9})
        Me.TerminarToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TerminarToolStripMenuItem.Name = "TerminarToolStripMenuItem"
        Me.TerminarToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.TerminarToolStripMenuItem.Text = "Configuracion"
        '
        'submenu9
        '
        Me.submenu9.Name = "submenu9"
        Me.submenu9.Size = New System.Drawing.Size(152, 22)
        Me.submenu9.Text = "Config Usuarios"
        '
        'RelojChecadorToolStripMenuItem
        '
        Me.RelojChecadorToolStripMenuItem.Name = "RelojChecadorToolStripMenuItem"
        Me.RelojChecadorToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.RelojChecadorToolStripMenuItem.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Handwriting", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Laboratorio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Handwriting", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(332, 343)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Diagnóstico"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Handwriting", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(404, 397)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Clínico"
        '
        'PRINCIPAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1047, 499)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PRINCIPAL"
        Me.Text = "PRINCIPAL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelEmpresa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents submenu9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelojChecadorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametrosEstudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescuentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
