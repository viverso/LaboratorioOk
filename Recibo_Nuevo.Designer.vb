<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recibo_Nuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recibo_Nuevo))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBoxtipoPago = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBoxDoctores = New System.Windows.Forms.ComboBox
        Me.BTNCOBRAR = New System.Windows.Forms.Button
        Me.txtSexo = New System.Windows.Forms.TextBox
        Me.TOTALV = New System.Windows.Forms.TextBox
        Me.txtAdeudo = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtDocumentAmount = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RCF = New System.Windows.Forms.TextBox
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtEdad = New System.Windows.Forms.TextBox
        Me.TxtCiudad = New System.Windows.Forms.TextBox
        Me.TextBoxNombre = New System.Windows.Forms.TextBox
        Me.TxtClienteID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.clave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.proceso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbltipopago = New System.Windows.Forms.Label
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnLiquidar = New System.Windows.Forms.Button
        Me.txtAnticipo = New System.Windows.Forms.Label
        Me.txtSuma = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.iva1 = New System.Windows.Forms.Label
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.TxtSubtotal = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtIva = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Controls.Add(Me.TxtFolio)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerFecha)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(960, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 140)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Venta"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Registro:"
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
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1246, 381)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 86)
        Me.Button1.TabIndex = 92
        Me.Button1.Text = "Salir"
        Me.Button1.UseVisualStyleBackColor = True
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
        'BTNCOBRAR
        '
        Me.BTNCOBRAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCOBRAR.Location = New System.Drawing.Point(1246, 23)
        Me.BTNCOBRAR.Name = "BTNCOBRAR"
        Me.BTNCOBRAR.Size = New System.Drawing.Size(77, 82)
        Me.BTNCOBRAR.TabIndex = 91
        Me.BTNCOBRAR.Text = "F5"
        Me.BTNCOBRAR.UseVisualStyleBackColor = True
        '
        'txtSexo
        '
        Me.txtSexo.BackColor = System.Drawing.SystemColors.Info
        Me.txtSexo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSexo.Location = New System.Drawing.Point(70, 102)
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.Size = New System.Drawing.Size(206, 21)
        Me.txtSexo.TabIndex = 33
        '
        'TOTALV
        '
        Me.TOTALV.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TOTALV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TOTALV.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOTALV.Location = New System.Drawing.Point(609, 441)
        Me.TOTALV.Name = "TOTALV"
        Me.TOTALV.Size = New System.Drawing.Size(306, 39)
        Me.TOTALV.TabIndex = 80
        Me.TOTALV.Text = "0.0"
        Me.TOTALV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TOTALV.Visible = False
        '
        'txtAdeudo
        '
        Me.txtAdeudo.AutoSize = True
        Me.txtAdeudo.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdeudo.Location = New System.Drawing.Point(449, 450)
        Me.txtAdeudo.Name = "txtAdeudo"
        Me.txtAdeudo.Size = New System.Drawing.Size(95, 46)
        Me.txtAdeudo.TabIndex = 79
        Me.txtAdeudo.Text = "falta"
        Me.txtAdeudo.Visible = False
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
        'txtDocumentAmount
        '
        Me.txtDocumentAmount.Location = New System.Drawing.Point(45, 551)
        Me.txtDocumentAmount.Name = "txtDocumentAmount"
        Me.txtDocumentAmount.Size = New System.Drawing.Size(245, 20)
        Me.txtDocumentAmount.TabIndex = 95
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(942, 140)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'RCF
        '
        Me.RCF.BackColor = System.Drawing.SystemColors.Info
        Me.RCF.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RCF.Location = New System.Drawing.Point(751, 102)
        Me.RCF.Name = "RCF"
        Me.RCF.Size = New System.Drawing.Size(176, 21)
        Me.RCF.TabIndex = 32
        '
        'TxtTelefono
        '
        Me.TxtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.TxtTelefono.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono.Location = New System.Drawing.Point(421, 61)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(153, 21)
        Me.TxtTelefono.TabIndex = 3
        '
        'TxtEdad
        '
        Me.TxtEdad.BackColor = System.Drawing.SystemColors.Info
        Me.TxtEdad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEdad.Location = New System.Drawing.Point(421, 102)
        Me.TxtEdad.Name = "TxtEdad"
        Me.TxtEdad.Size = New System.Drawing.Size(78, 21)
        Me.TxtEdad.TabIndex = 29
        '
        'TxtCiudad
        '
        Me.TxtCiudad.BackColor = System.Drawing.SystemColors.Info
        Me.TxtCiudad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiudad.Location = New System.Drawing.Point(70, 61)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(271, 21)
        Me.TxtCiudad.TabIndex = 2
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.BackColor = System.Drawing.SystemColors.Info
        Me.TextBoxNombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNombre.Location = New System.Drawing.Point(70, 22)
        Me.TextBoxNombre.Name = "TextBoxNombre"
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clave, Me.descripcion, Me.tiempo, Me.proceso, Me.importe})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 182)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.Size = New System.Drawing.Size(1204, 218)
        Me.DataGridView1.TabIndex = 77
        '
        'clave
        '
        Me.clave.HeaderText = "CLAVE"
        Me.clave.Name = "clave"
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
        'lbltipopago
        '
        Me.lbltipopago.AutoSize = True
        Me.lbltipopago.Location = New System.Drawing.Point(1215, 578)
        Me.lbltipopago.Name = "lbltipopago"
        Me.lbltipopago.Size = New System.Drawing.Size(19, 13)
        Me.lbltipopago.TabIndex = 105
        Me.lbltipopago.Text = "01"
        Me.lbltipopago.Visible = False
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancelar.Location = New System.Drawing.Point(1246, 208)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(77, 92)
        Me.ButtonCancelar.TabIndex = 98
        Me.ButtonCancelar.Text = "Cancelar"
        Me.ButtonCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonCancelar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(1246, 111)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(77, 94)
        Me.btnImprimir.TabIndex = 97
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnLiquidar
        '
        Me.btnLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiquidar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLiquidar.Location = New System.Drawing.Point(1248, 306)
        Me.btnLiquidar.Name = "btnLiquidar"
        Me.btnLiquidar.Size = New System.Drawing.Size(75, 69)
        Me.btnLiquidar.TabIndex = 104
        Me.btnLiquidar.Text = "Liquidar"
        Me.btnLiquidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLiquidar.UseVisualStyleBackColor = True
        '
        'txtAnticipo
        '
        Me.txtAnticipo.AutoSize = True
        Me.txtAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnticipo.Location = New System.Drawing.Point(12, 453)
        Me.txtAnticipo.Name = "txtAnticipo"
        Me.txtAnticipo.Size = New System.Drawing.Size(229, 46)
        Me.txtAnticipo.TabIndex = 101
        Me.txtAnticipo.Text = "ANTICIPO :"
        Me.txtAnticipo.Visible = False
        '
        'txtSuma
        '
        Me.txtSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuma.Location = New System.Drawing.Point(1056, 441)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(160, 26)
        Me.txtSuma.TabIndex = 100
        Me.txtSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(974, 441)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 20)
        Me.Label16.TabIndex = 99
        Me.Label16.Text = "Suma:"
        '
        'iva1
        '
        Me.iva1.AutoSize = True
        Me.iva1.Location = New System.Drawing.Point(17, 554)
        Me.iva1.Name = "iva1"
        Me.iva1.Size = New System.Drawing.Size(22, 13)
        Me.iva1.TabIndex = 96
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
        Me.StatusStrip1.TabIndex = 94
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(1056, 545)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(160, 26)
        Me.TxtTotal.TabIndex = 90
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescuento.Location = New System.Drawing.Point(1056, 473)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(160, 26)
        Me.TxtDescuento.TabIndex = 88
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(1057, 510)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.Size = New System.Drawing.Size(160, 26)
        Me.TxtSubtotal.TabIndex = 87
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(952, 512)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 20)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "Sub Total:"
        '
        'TxtIva
        '
        Me.TxtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIva.Location = New System.Drawing.Point(716, 506)
        Me.TxtIva.Name = "TxtIva"
        Me.TxtIva.Size = New System.Drawing.Size(160, 26)
        Me.TxtIva.TabIndex = 89
        Me.TxtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtIva.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(991, 548)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 20)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Total:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(665, 511)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 20)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "Iva:"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(942, 476)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 20)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "Descuento:"
        '
        'Recibo_Nuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1335, 626)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNCOBRAR)
        Me.Controls.Add(Me.TOTALV)
        Me.Controls.Add(Me.txtAdeudo)
        Me.Controls.Add(Me.txtDocumentAmount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lbltipopago)
        Me.Controls.Add(Me.ButtonCancelar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnLiquidar)
        Me.Controls.Add(Me.txtAnticipo)
        Me.Controls.Add(Me.txtSuma)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.iva1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtIva)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Name = "Recibo_Nuevo"
        Me.Text = "Recibo_Nuevo"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxtipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxDoctores As System.Windows.Forms.ComboBox
    Friend WithEvents BTNCOBRAR As System.Windows.Forms.Button
    Friend WithEvents txtSexo As System.Windows.Forms.TextBox
    Friend WithEvents TOTALV As System.Windows.Forms.TextBox
    Friend WithEvents txtAdeudo As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtDocumentAmount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RCF As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtEdad As System.Windows.Forms.TextBox
    Friend WithEvents TxtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtClienteID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbltipopago As System.Windows.Forms.Label
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnLiquidar As System.Windows.Forms.Button
    Friend WithEvents txtAnticipo As System.Windows.Forms.Label
    Friend WithEvents txtSuma As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents iva1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtIva As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents proceso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
