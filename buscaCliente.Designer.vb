<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class buscaCliente
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
        Me.txtPU = New System.Windows.Forms.TextBox
        Me.txtPrecio = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.DataGridViewProductos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.DataGridViewRecibos = New System.Windows.Forms.DataGridView
        Me.id_recibo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.anticipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.debe = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPU
        '
        Me.txtPU.Location = New System.Drawing.Point(91, 441)
        Me.txtPU.Name = "txtPU"
        Me.txtPU.Size = New System.Drawing.Size(210, 20)
        Me.txtPU.TabIndex = 45
        Me.txtPU.Visible = False
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(91, 403)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(210, 20)
        Me.txtPrecio.TabIndex = 44
        Me.txtPrecio.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(91, 371)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(640, 20)
        Me.txtDescripcion.TabIndex = 43
        Me.txtDescripcion.Visible = False
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(91, 337)
        Me.txtcodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(210, 20)
        Me.txtcodigo.TabIndex = 42
        '
        'DataGridViewProductos
        '
        Me.DataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridViewProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProductos.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridViewProductos.Location = New System.Drawing.Point(11, 44)
        Me.DataGridViewProductos.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewProductos.Name = "DataGridViewProductos"
        Me.DataGridViewProductos.Size = New System.Drawing.Size(928, 226)
        Me.DataGridViewProductos.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 20)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "NOMBRE DEL CLIENTE"
        '
        'txtBuscar
        '
        Me.txtBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(270, 10)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(669, 26)
        Me.txtBuscar.TabIndex = 40
        '
        'DataGridViewRecibos
        '
        Me.DataGridViewRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewRecibos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridViewRecibos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridViewRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRecibos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_recibo, Me.folio, Me.fecha, Me.subtotal, Me.descuento, Me.iva, Me.total, Me.anticipo, Me.debe})
        Me.DataGridViewRecibos.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridViewRecibos.Location = New System.Drawing.Point(9, 278)
        Me.DataGridViewRecibos.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewRecibos.Name = "DataGridViewRecibos"
        Me.DataGridViewRecibos.Size = New System.Drawing.Size(928, 264)
        Me.DataGridViewRecibos.TabIndex = 47
        '
        'id_recibo
        '
        Me.id_recibo.HeaderText = "NO. RECIBO"
        Me.id_recibo.Name = "id_recibo"
        Me.id_recibo.Visible = False
        '
        'folio
        '
        Me.folio.HeaderText = "REGISTO"
        Me.folio.Name = "folio"
        '
        'fecha
        '
        Me.fecha.HeaderText = "FECHA"
        Me.fecha.Name = "fecha"
        '
        'subtotal
        '
        Me.subtotal.HeaderText = "SUBTOTAL"
        Me.subtotal.Name = "subtotal"
        Me.subtotal.Visible = False
        '
        'descuento
        '
        Me.descuento.HeaderText = "DESCUENTO"
        Me.descuento.Name = "descuento"
        '
        'iva
        '
        Me.iva.HeaderText = "IVA"
        Me.iva.Name = "iva"
        '
        'total
        '
        Me.total.HeaderText = "TOTAL"
        Me.total.Name = "total"
        '
        'anticipo
        '
        Me.anticipo.HeaderText = "ANTICIPO"
        Me.anticipo.Name = "anticipo"
        '
        'debe
        '
        Me.debe.HeaderText = "ADEUDO"
        Me.debe.Name = "debe"
        '
        'buscaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 555)
        Me.Controls.Add(Me.DataGridViewRecibos)
        Me.Controls.Add(Me.txtPU)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.DataGridViewProductos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Name = "buscaCliente"
        Me.Text = "buscaCliente"
        CType(Me.DataGridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPU As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewProductos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents id_recibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents anticipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
