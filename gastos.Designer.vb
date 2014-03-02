<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gastos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Datefecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtconcepto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtimporte = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.lblid_gasto = New System.Windows.Forms.Label
        Me.DataGridViewgastos = New System.Windows.Forms.DataGridView
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnModifica = New System.Windows.Forms.Button
        CType(Me.DataGridViewgastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FECHA:"
        '
        'Datefecha
        '
        Me.Datefecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Datefecha.Location = New System.Drawing.Point(112, 44)
        Me.Datefecha.Name = "Datefecha"
        Me.Datefecha.Size = New System.Drawing.Size(99, 20)
        Me.Datefecha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CONCEPTO:"
        '
        'txtconcepto
        '
        Me.txtconcepto.Location = New System.Drawing.Point(112, 78)
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.ReadOnly = True
        Me.txtconcepto.Size = New System.Drawing.Size(682, 20)
        Me.txtconcepto.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "IMPORTE:"
        '
        'txtimporte
        '
        Me.txtimporte.Location = New System.Drawing.Point(112, 113)
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.ReadOnly = True
        Me.txtimporte.Size = New System.Drawing.Size(133, 20)
        Me.txtimporte.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.Location = New System.Drawing.Point(822, 393)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 81)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblid_gasto
        '
        Me.lblid_gasto.AutoSize = True
        Me.lblid_gasto.Location = New System.Drawing.Point(44, 13)
        Me.lblid_gasto.Name = "lblid_gasto"
        Me.lblid_gasto.Size = New System.Drawing.Size(39, 13)
        Me.lblid_gasto.TabIndex = 7
        Me.lblid_gasto.Text = "Label4"
        Me.lblid_gasto.Visible = False
        '
        'DataGridViewgastos
        '
        Me.DataGridViewgastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewgastos.Location = New System.Drawing.Point(28, 139)
        Me.DataGridViewgastos.Name = "DataGridViewgastos"
        Me.DataGridViewgastos.Size = New System.Drawing.Size(766, 417)
        Me.DataGridViewgastos.TabIndex = 8
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.Location = New System.Drawing.Point(822, 477)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 79)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.Location = New System.Drawing.Point(822, 135)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 83)
        Me.btnNuevo.TabIndex = 10
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Location = New System.Drawing.Point(822, 306)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 83)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModifica
        '
        Me.btnModifica.BackgroundImage = CType(resources.GetObject("btnModifica.BackgroundImage"), System.Drawing.Image)
        Me.btnModifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnModifica.Location = New System.Drawing.Point(822, 221)
        Me.btnModifica.Name = "btnModifica"
        Me.btnModifica.Size = New System.Drawing.Size(75, 83)
        Me.btnModifica.TabIndex = 12
        Me.btnModifica.Text = "&Modificar"
        Me.btnModifica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModifica.UseVisualStyleBackColor = True
        '
        'gastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 568)
        Me.Controls.Add(Me.btnModifica)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.DataGridViewgastos)
        Me.Controls.Add(Me.lblid_gasto)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtimporte)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtconcepto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Datefecha)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "gastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gastos"
        CType(Me.DataGridViewgastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Datefecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtconcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtimporte As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblid_gasto As System.Windows.Forms.Label
    Friend WithEvents DataGridViewgastos As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModifica As System.Windows.Forms.Button
End Class
