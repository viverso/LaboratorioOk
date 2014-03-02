<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recibo))
        Me.btnalta_Cliente = New System.Windows.Forms.Button
        Me.txtSexo = New System.Windows.Forms.TextBox
        Me.RCF = New System.Windows.Forms.TextBox
        Me.PanelFinal = New System.Windows.Forms.Panel
        Me.txtRecibo = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TextDESC = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.txtCambio = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtPago = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalVenta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelLiquidar = New System.Windows.Forms.Panel
        Me.btnCancelarLiquidacion = New System.Windows.Forms.Button
        Me.btnAceptarLiquidacion = New System.Windows.Forms.Button
        Me.txtLCambio = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtLRecibo = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtLiquidacion = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtIva = New System.Windows.Forms.TextBox
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.TxtSubtotal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtEdad = New System.Windows.Forms.TextBox
        Me.iva1 = New System.Windows.Forms.Label
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TxtCiudad = New System.Windows.Forms.TextBox
        Me.TextBoxNombre = New System.Windows.Forms.TextBox
        Me.TxtClienteID = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTNCOBRAR = New System.Windows.Forms.Button
        Me.TOTALV = New System.Windows.Forms.TextBox
        Me.txtAdeudo = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btncargarrecibo = New System.Windows.Forms.Button
        Me.txtFolioInterno = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDocumentAmount = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBoxtipoPago = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ComboBoxDoctores = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.clave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.proceso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSuma = New System.Windows.Forms.TextBox
        Me.txtAnticipo = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.btnLiquidar = New System.Windows.Forms.Button
        Me.lbltipopago = New System.Windows.Forms.Label
        Me.lblfoliorecibo = New System.Windows.Forms.Label
        Me.btncorte = New System.Windows.Forms.Button
        Me.txtestadorecib = New System.Windows.Forms.Label
        Me.CheckBoxporcentaje = New System.Windows.Forms.CheckBox
        Me.PanelFinal.SuspendLayout()
        Me.PanelLiquidar.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnalta_Cliente
        '
        Me.btnalta_Cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnalta_Cliente.Image = Global.LABORATORIO.My.Resources.Resources.user
        Me.btnalta_Cliente.Location = New System.Drawing.Point(435, 17)
        Me.btnalta_Cliente.Name = "btnalta_Cliente"
        Me.btnalta_Cliente.Size = New System.Drawing.Size(59, 38)
        Me.btnalta_Cliente.TabIndex = 46
        Me.btnalta_Cliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnalta_Cliente.UseVisualStyleBackColor = True
        '
        'txtSexo
        '
        Me.txtSexo.BackColor = System.Drawing.SystemColors.Info
        Me.txtSexo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSexo.Location = New System.Drawing.Point(70, 102)
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.ReadOnly = True
        Me.txtSexo.Size = New System.Drawing.Size(206, 21)
        Me.txtSexo.TabIndex = 33
        '
        'RCF
        '
        Me.RCF.BackColor = System.Drawing.SystemColors.Info
        Me.RCF.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RCF.Location = New System.Drawing.Point(751, 102)
        Me.RCF.Name = "RCF"
        Me.RCF.ReadOnly = True
        Me.RCF.Size = New System.Drawing.Size(176, 21)
        Me.RCF.TabIndex = 32
        '
        'PanelFinal
        '
        Me.PanelFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelFinal.Controls.Add(Me.CheckBoxporcentaje)
        Me.PanelFinal.Controls.Add(Me.txtRecibo)
        Me.PanelFinal.Controls.Add(Me.Label20)
        Me.PanelFinal.Controls.Add(Me.TextDESC)
        Me.PanelFinal.Controls.Add(Me.Label3)
        Me.PanelFinal.Controls.Add(Me.Button5)
        Me.PanelFinal.Controls.Add(Me.Button4)
        Me.PanelFinal.Controls.Add(Me.txtCambio)
        Me.PanelFinal.Controls.Add(Me.Label18)
        Me.PanelFinal.Controls.Add(Me.txtPago)
        Me.PanelFinal.Controls.Add(Me.Label1)
        Me.PanelFinal.Controls.Add(Me.txtTotalVenta)
        Me.PanelFinal.Controls.Add(Me.Label2)
        Me.PanelFinal.Location = New System.Drawing.Point(447, 188)
        Me.PanelFinal.Name = "PanelFinal"
        Me.PanelFinal.Size = New System.Drawing.Size(704, 396)
        Me.PanelFinal.TabIndex = 62
        Me.PanelFinal.Visible = False
        '
        'txtRecibo
        '
        Me.txtRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibo.Location = New System.Drawing.Point(369, 184)
        Me.txtRecibo.Name = "txtRecibo"
        Me.txtRecibo.Size = New System.Drawing.Size(298, 50)
        Me.txtRecibo.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(184, 184)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(170, 42)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "RECIBO:"
        '
        'TextDESC
        '
        Me.TextDESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDESC.Location = New System.Drawing.Point(369, 66)
        Me.TextDESC.Name = "TextDESC"
        Me.TextDESC.Size = New System.Drawing.Size(298, 50)
        Me.TextDESC.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(91, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 42)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "DESCUENTO:"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(504, 295)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 94)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Cancelar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(412, 295)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 94)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Aceptar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtCambio
        '
        Me.txtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.Location = New System.Drawing.Point(367, 242)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.Size = New System.Drawing.Size(298, 50)
        Me.txtCambio.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(180, 242)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(174, 42)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "CAMBIO:"
        '
        'txtPago
        '
        Me.txtPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPago.Location = New System.Drawing.Point(371, 124)
        Me.txtPago.Name = "txtPago"
        Me.txtPago.Size = New System.Drawing.Size(298, 50)
        Me.txtPago.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 42)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "PAGO/ANTICIPO:"
        '
        'txtTotalVenta
        '
        Me.txtTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVenta.Location = New System.Drawing.Point(367, 12)
        Me.txtTotalVenta.Name = "txtTotalVenta"
        Me.txtTotalVenta.Size = New System.Drawing.Size(298, 50)
        Me.txtTotalVenta.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 42)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "TOTAL:"
        '
        'PanelLiquidar
        '
        Me.PanelLiquidar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelLiquidar.Controls.Add(Me.btnCancelarLiquidacion)
        Me.PanelLiquidar.Controls.Add(Me.btnAceptarLiquidacion)
        Me.PanelLiquidar.Controls.Add(Me.txtLCambio)
        Me.PanelLiquidar.Controls.Add(Me.Label26)
        Me.PanelLiquidar.Controls.Add(Me.txtLRecibo)
        Me.PanelLiquidar.Controls.Add(Me.Label25)
        Me.PanelLiquidar.Controls.Add(Me.txtLiquidacion)
        Me.PanelLiquidar.Controls.Add(Me.Label24)
        Me.PanelLiquidar.Location = New System.Drawing.Point(12, 193)
        Me.PanelLiquidar.Name = "PanelLiquidar"
        Me.PanelLiquidar.Size = New System.Drawing.Size(429, 306)
        Me.PanelLiquidar.TabIndex = 14
        Me.PanelLiquidar.Visible = False
        '
        'btnCancelarLiquidacion
        '
        Me.btnCancelarLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarLiquidacion.Image = CType(resources.GetObject("btnCancelarLiquidacion.Image"), System.Drawing.Image)
        Me.btnCancelarLiquidacion.Location = New System.Drawing.Point(216, 195)
        Me.btnCancelarLiquidacion.Name = "btnCancelarLiquidacion"
        Me.btnCancelarLiquidacion.Size = New System.Drawing.Size(86, 94)
        Me.btnCancelarLiquidacion.TabIndex = 4
        Me.btnCancelarLiquidacion.Text = "Cancelar"
        Me.btnCancelarLiquidacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelarLiquidacion.UseVisualStyleBackColor = True
        '
        'btnAceptarLiquidacion
        '
        Me.btnAceptarLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarLiquidacion.Image = CType(resources.GetObject("btnAceptarLiquidacion.Image"), System.Drawing.Image)
        Me.btnAceptarLiquidacion.Location = New System.Drawing.Point(124, 195)
        Me.btnAceptarLiquidacion.Name = "btnAceptarLiquidacion"
        Me.btnAceptarLiquidacion.Size = New System.Drawing.Size(86, 94)
        Me.btnAceptarLiquidacion.TabIndex = 3
        Me.btnAceptarLiquidacion.Text = "Aceptar"
        Me.btnAceptarLiquidacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptarLiquidacion.UseVisualStyleBackColor = True
        '
        'txtLCambio
        '
        Me.txtLCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLCambio.Location = New System.Drawing.Point(202, 128)
        Me.txtLCambio.Name = "txtLCambio"
        Me.txtLCambio.Size = New System.Drawing.Size(217, 50)
        Me.txtLCambio.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 134)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(187, 44)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "CAMBIO:"
        '
        'txtLRecibo
        '
        Me.txtLRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRecibo.Location = New System.Drawing.Point(203, 68)
        Me.txtLRecibo.Name = "txtLRecibo"
        Me.txtLRecibo.Size = New System.Drawing.Size(217, 50)
        Me.txtLRecibo.TabIndex = 1
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(16, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(182, 44)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "RECIBO:"
        '
        'txtLiquidacion
        '
        Me.txtLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLiquidacion.Location = New System.Drawing.Point(203, 6)
        Me.txtLiquidacion.Name = "txtLiquidacion"
        Me.txtLiquidacion.ReadOnly = True
        Me.txtLiquidacion.Size = New System.Drawing.Size(217, 50)
        Me.txtLiquidacion.TabIndex = 0
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(37, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(159, 44)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "TOTAL:"
        '
        'TxtIva
        '
        Me.TxtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIva.Location = New System.Drawing.Point(716, 509)
        Me.TxtIva.Name = "TxtIva"
        Me.TxtIva.Size = New System.Drawing.Size(160, 26)
        Me.TxtIva.TabIndex = 58
        Me.TxtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtIva.Visible = False
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescuento.Location = New System.Drawing.Point(1056, 476)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(160, 26)
        Me.TxtDescuento.TabIndex = 57
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(1057, 513)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.Size = New System.Drawing.Size(160, 26)
        Me.TxtSubtotal.TabIndex = 56
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(991, 551)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 20)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Total:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(665, 514)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 20)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Iva:"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(942, 479)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 20)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Descuento:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(952, 515)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 20)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Sub Total:"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.TxtTelefono.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono.Location = New System.Drawing.Point(421, 61)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.ReadOnly = True
        Me.TxtTelefono.Size = New System.Drawing.Size(153, 21)
        Me.TxtTelefono.TabIndex = 3
        '
        'TxtEdad
        '
        Me.TxtEdad.BackColor = System.Drawing.SystemColors.Info
        Me.TxtEdad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEdad.Location = New System.Drawing.Point(421, 102)
        Me.TxtEdad.Name = "TxtEdad"
        Me.TxtEdad.ReadOnly = True
        Me.TxtEdad.Size = New System.Drawing.Size(78, 21)
        Me.TxtEdad.TabIndex = 29
        '
        'iva1
        '
        Me.iva1.AutoSize = True
        Me.iva1.Location = New System.Drawing.Point(17, 557)
        Me.iva1.Name = "iva1"
        Me.iva1.Size = New System.Drawing.Size(22, 13)
        Me.iva1.TabIndex = 65
        Me.iva1.Text = "0.0"
        Me.iva1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1335, 22)
        Me.StatusStrip1.TabIndex = 63
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TxtCiudad
        '
        Me.TxtCiudad.BackColor = System.Drawing.SystemColors.Info
        Me.TxtCiudad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiudad.Location = New System.Drawing.Point(70, 61)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.ReadOnly = True
        Me.TxtCiudad.Size = New System.Drawing.Size(271, 21)
        Me.TxtCiudad.TabIndex = 2
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.BackColor = System.Drawing.SystemColors.Info
        Me.TextBoxNombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNombre.Location = New System.Drawing.Point(70, 22)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.ReadOnly = True
        Me.TextBoxNombre.Size = New System.Drawing.Size(349, 21)
        Me.TextBoxNombre.TabIndex = 0
        '
        'TxtClienteID
        '
        Me.TxtClienteID.BackColor = System.Drawing.SystemColors.Info
        Me.TxtClienteID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClienteID.Location = New System.Drawing.Point(556, 102)
        Me.TxtClienteID.Name = "TxtClienteID"
        Me.TxtClienteID.Size = New System.Drawing.Size(92, 21)
        Me.TxtClienteID.TabIndex = 25
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(1056, 548)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(160, 26)
        Me.TxtTotal.TabIndex = 59
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(697, 107)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 16)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "R.F.C."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Registro:"
        Me.Label9.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 16)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Fecha:"
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.BackgroundImage = CType(resources.GetObject("ButtonCancelar.BackgroundImage"), System.Drawing.Image)
        Me.ButtonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancelar.Location = New System.Drawing.Point(1246, 211)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(77, 92)
        Me.ButtonCancelar.TabIndex = 67
        Me.ButtonCancelar.Text = "&Cancelar"
        Me.ButtonCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonCancelar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(1246, 114)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(77, 94)
        Me.btnImprimir.TabIndex = 66
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1246, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 81)
        Me.Button1.TabIndex = 61
        Me.Button1.Text = "&Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTNCOBRAR
        '
        Me.BTNCOBRAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCOBRAR.Location = New System.Drawing.Point(1246, 59)
        Me.BTNCOBRAR.Name = "BTNCOBRAR"
        Me.BTNCOBRAR.Size = New System.Drawing.Size(77, 49)
        Me.BTNCOBRAR.TabIndex = 60
        Me.BTNCOBRAR.Text = "F5"
        Me.BTNCOBRAR.UseVisualStyleBackColor = True
        '
        'TOTALV
        '
        Me.TOTALV.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TOTALV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TOTALV.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOTALV.Location = New System.Drawing.Point(609, 444)
        Me.TOTALV.Name = "TOTALV"
        Me.TOTALV.Size = New System.Drawing.Size(306, 39)
        Me.TOTALV.TabIndex = 49
        Me.TOTALV.Text = "0.0"
        Me.TOTALV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TOTALV.Visible = False
        '
        'txtAdeudo
        '
        Me.txtAdeudo.AutoSize = True
        Me.txtAdeudo.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdeudo.Location = New System.Drawing.Point(449, 453)
        Me.txtAdeudo.Name = "txtAdeudo"
        Me.txtAdeudo.Size = New System.Drawing.Size(95, 46)
        Me.txtAdeudo.TabIndex = 48
        Me.txtAdeudo.Text = "falta"
        Me.txtAdeudo.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(1246, 6)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(77, 50)
        Me.btnBuscar.TabIndex = 47
        Me.btnBuscar.Text = "F2     Buscar Cliente"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(348, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Teléfono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Sexo:"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(86, 22)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(157, 21)
        Me.TxtFolio.TabIndex = 9
        '
        'DateTimePickerFecha
        '
        Me.DateTimePickerFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFecha.Location = New System.Drawing.Point(67, 102)
        Me.DateTimePickerFecha.Name = "DateTimePickerFecha"
        Me.DateTimePickerFecha.Size = New System.Drawing.Size(137, 21)
        Me.DateTimePickerFecha.TabIndex = 8
        Me.DateTimePickerFecha.Value = New Date(2011, 4, 21, 21, 44, 43, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Controls.Add(Me.btncargarrecibo)
        Me.GroupBox2.Controls.Add(Me.txtFolioInterno)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.TxtFolio)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerFecha)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(960, 26)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 140)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Venta"
        '
        'btncargarrecibo
        '
        Me.btncargarrecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncargarrecibo.Image = CType(resources.GetObject("btncargarrecibo.Image"), System.Drawing.Image)
        Me.btncargarrecibo.Location = New System.Drawing.Point(210, 54)
        Me.btncargarrecibo.Name = "btncargarrecibo"
        Me.btncargarrecibo.Size = New System.Drawing.Size(40, 47)
        Me.btncargarrecibo.TabIndex = 47
        Me.btncargarrecibo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncargarrecibo.UseVisualStyleBackColor = True
        '
        'txtFolioInterno
        '
        Me.txtFolioInterno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolioInterno.Location = New System.Drawing.Point(70, 65)
        Me.txtFolioInterno.Name = "txtFolioInterno"
        Me.txtFolioInterno.Size = New System.Drawing.Size(134, 21)
        Me.txtFolioInterno.TabIndex = 11
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(13, 70)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(44, 16)
        Me.Label27.TabIndex = 10
        Me.Label27.Text = "Folio:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(523, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "ID:"
        '
        'txtDocumentAmount
        '
        Me.txtDocumentAmount.Location = New System.Drawing.Point(45, 554)
        Me.txtDocumentAmount.Name = "txtDocumentAmount"
        Me.txtDocumentAmount.Size = New System.Drawing.Size(245, 20)
        Me.txtDocumentAmount.TabIndex = 64
        Me.txtDocumentAmount.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ComboBoxtipoPago)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.ComboBoxDoctores)
        Me.GroupBox1.Controls.Add(Me.txtSexo)
        Me.GroupBox1.Controls.Add(Me.RCF)
        Me.GroupBox1.Controls.Add(Me.TxtTelefono)
        Me.GroupBox1.Controls.Add(Me.btnalta_Cliente)
        Me.GroupBox1.Controls.Add(Me.TxtEdad)
        Me.GroupBox1.Controls.Add(Me.TxtCiudad)
        Me.GroupBox1.Controls.Add(Me.TextBoxNombre)
        Me.GroupBox1.Controls.Add(Me.TxtClienteID)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(942, 140)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(590, 66)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 16)
        Me.Label21.TabIndex = 81
        Me.Label21.Text = "Tipo de Pago:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Nombre:"
        '
        'ComboBoxtipoPago
        '
        Me.ComboBoxtipoPago.BackColor = System.Drawing.SystemColors.Info
        Me.ComboBoxtipoPago.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxtipoPago.FormattingEnabled = True
        Me.ComboBoxtipoPago.Location = New System.Drawing.Point(692, 61)
        Me.ComboBoxtipoPago.Name = "ComboBoxtipoPago"
        Me.ComboBoxtipoPago.Size = New System.Drawing.Size(236, 21)
        Me.ComboBoxtipoPago.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(518, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 16)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Doctor:"
        '
        'ComboBoxDoctores
        '
        Me.ComboBoxDoctores.BackColor = System.Drawing.SystemColors.Info
        Me.ComboBoxDoctores.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDoctores.FormattingEnabled = True
        Me.ComboBoxDoctores.Items.AddRange(New Object() {"0 - ADMINISTRADOR", "1 - USUARIO"})
        Me.ComboBoxDoctores.Location = New System.Drawing.Point(577, 22)
        Me.ComboBoxDoctores.Name = "ComboBoxDoctores"
        Me.ComboBoxDoctores.Size = New System.Drawing.Size(359, 21)
        Me.ComboBoxDoctores.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(369, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Edad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Ciudad:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clave, Me.descripcion, Me.tiempo, Me.proceso, Me.importe})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 185)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.Size = New System.Drawing.Size(1204, 250)
        Me.DataGridView1.TabIndex = 45
        '
        'clave
        '
        Me.clave.HeaderText = "CLAVE"
        Me.clave.Name = "clave"
        Me.clave.ReadOnly = True
        '
        'descripcion
        '
        Me.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.descripcion.HeaderText = "DESCRIPCION"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        '
        'tiempo
        '
        Me.tiempo.HeaderText = "TIEMPO"
        Me.tiempo.Name = "tiempo"
        '
        'proceso
        '
        Me.proceso.HeaderText = "PROCESO"
        Me.proceso.Name = "proceso"
        '
        'importe
        '
        Me.importe.HeaderText = "IMPORTE"
        Me.importe.Name = "importe"
        Me.importe.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(974, 444)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 20)
        Me.Label16.TabIndex = 68
        Me.Label16.Text = "Suma:"
        '
        'txtSuma
        '
        Me.txtSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuma.Location = New System.Drawing.Point(1056, 444)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(160, 26)
        Me.txtSuma.TabIndex = 69
        Me.txtSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnticipo
        '
        Me.txtAnticipo.AutoSize = True
        Me.txtAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnticipo.Location = New System.Drawing.Point(12, 456)
        Me.txtAnticipo.Name = "txtAnticipo"
        Me.txtAnticipo.Size = New System.Drawing.Size(229, 46)
        Me.txtAnticipo.TabIndex = 71
        Me.txtAnticipo.Text = "ANTICIPO :"
        Me.txtAnticipo.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.Location = New System.Drawing.Point(17, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 15)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "F2 Para Seleccionar Cliente"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.Location = New System.Drawing.Point(12, 167)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(122, 15)
        Me.Label23.TabIndex = 73
        Me.Label23.Text = "F3 para seleccionar Estudio"
        '
        'btnLiquidar
        '
        Me.btnLiquidar.BackgroundImage = CType(resources.GetObject("btnLiquidar.BackgroundImage"), System.Drawing.Image)
        Me.btnLiquidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiquidar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLiquidar.Location = New System.Drawing.Point(1248, 309)
        Me.btnLiquidar.Name = "btnLiquidar"
        Me.btnLiquidar.Size = New System.Drawing.Size(75, 87)
        Me.btnLiquidar.TabIndex = 74
        Me.btnLiquidar.Text = "&Liquidar"
        Me.btnLiquidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLiquidar.UseVisualStyleBackColor = True
        '
        'lbltipopago
        '
        Me.lbltipopago.AutoSize = True
        Me.lbltipopago.Location = New System.Drawing.Point(1215, 581)
        Me.lbltipopago.Name = "lbltipopago"
        Me.lbltipopago.Size = New System.Drawing.Size(19, 13)
        Me.lbltipopago.TabIndex = 75
        Me.lbltipopago.Text = "01"
        Me.lbltipopago.Visible = False
        '
        'lblfoliorecibo
        '
        Me.lblfoliorecibo.AutoSize = True
        Me.lblfoliorecibo.Location = New System.Drawing.Point(31, 520)
        Me.lblfoliorecibo.Name = "lblfoliorecibo"
        Me.lblfoliorecibo.Size = New System.Drawing.Size(45, 13)
        Me.lblfoliorecibo.TabIndex = 76
        Me.lblfoliorecibo.Text = "Label27"
        Me.lblfoliorecibo.Visible = False
        '
        'btncorte
        '
        Me.btncorte.BackgroundImage = CType(resources.GetObject("btncorte.BackgroundImage"), System.Drawing.Image)
        Me.btncorte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncorte.Location = New System.Drawing.Point(1246, 480)
        Me.btncorte.Name = "btncorte"
        Me.btncorte.Size = New System.Drawing.Size(77, 78)
        Me.btncorte.TabIndex = 77
        Me.btncorte.Text = "C&orte"
        Me.btncorte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncorte.UseVisualStyleBackColor = True
        '
        'txtestadorecib
        '
        Me.txtestadorecib.AutoSize = True
        Me.txtestadorecib.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtestadorecib.Location = New System.Drawing.Point(449, 453)
        Me.txtestadorecib.Name = "txtestadorecib"
        Me.txtestadorecib.Size = New System.Drawing.Size(95, 46)
        Me.txtestadorecib.TabIndex = 78
        Me.txtestadorecib.Text = "falta"
        Me.txtestadorecib.Visible = False
        '
        'CheckBoxporcentaje
        '
        Me.CheckBoxporcentaje.AutoSize = True
        Me.CheckBoxporcentaje.Checked = True
        Me.CheckBoxporcentaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxporcentaje.Location = New System.Drawing.Point(674, 93)
        Me.CheckBoxporcentaje.Name = "CheckBoxporcentaje"
        Me.CheckBoxporcentaje.Size = New System.Drawing.Size(34, 17)
        Me.CheckBoxporcentaje.TabIndex = 13
        Me.CheckBoxporcentaje.Text = "%"
        Me.CheckBoxporcentaje.UseVisualStyleBackColor = True
        '
        'Recibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1335, 626)
        Me.Controls.Add(Me.txtestadorecib)
        Me.Controls.Add(Me.btncorte)
        Me.Controls.Add(Me.lblfoliorecibo)
        Me.Controls.Add(Me.lbltipopago)
        Me.Controls.Add(Me.PanelLiquidar)
        Me.Controls.Add(Me.btnLiquidar)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtAnticipo)
        Me.Controls.Add(Me.txtSuma)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PanelFinal)
        Me.Controls.Add(Me.TxtIva)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.iva1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.ButtonCancelar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNCOBRAR)
        Me.Controls.Add(Me.TOTALV)
        Me.Controls.Add(Me.txtAdeudo)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtDocumentAmount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Recibo"
        Me.Text = "Recibo"
        Me.PanelFinal.ResumeLayout(False)
        Me.PanelFinal.PerformLayout()
        Me.PanelLiquidar.ResumeLayout(False)
        Me.PanelLiquidar.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnalta_Cliente As System.Windows.Forms.Button
    Friend WithEvents txtSexo As System.Windows.Forms.TextBox
    Friend WithEvents RCF As System.Windows.Forms.TextBox
    Friend WithEvents PanelFinal As System.Windows.Forms.Panel
    Friend WithEvents TextDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPago As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtIva As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtEdad As System.Windows.Forms.TextBox
    Friend WithEvents iva1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TxtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtClienteID As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BTNCOBRAR As System.Windows.Forms.Button
    Friend WithEvents TOTALV As System.Windows.Forms.TextBox
    Friend WithEvents txtAdeudo As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDocumentAmount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDoctores As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxtipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents proceso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSuma As System.Windows.Forms.TextBox
    Friend WithEvents txtRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtAnticipo As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PanelLiquidar As System.Windows.Forms.Panel
    Friend WithEvents txtLiquidacion As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnLiquidar As System.Windows.Forms.Button
    Friend WithEvents txtLCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtLRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnCancelarLiquidacion As System.Windows.Forms.Button
    Friend WithEvents btnAceptarLiquidacion As System.Windows.Forms.Button
    Friend WithEvents lbltipopago As System.Windows.Forms.Label
    Friend WithEvents lblfoliorecibo As System.Windows.Forms.Label
    Friend WithEvents btncorte As System.Windows.Forms.Button
    Friend WithEvents txtFolioInterno As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btncargarrecibo As System.Windows.Forms.Button
    Friend WithEvents txtestadorecib As System.Windows.Forms.Label
    Friend WithEvents CheckBoxporcentaje As System.Windows.Forms.CheckBox
End Class
