<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        Me.txbLastName = New System.Windows.Forms.TextBox
        Me.TxbUserName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblTip = New System.Windows.Forms.Label
        Me.UserType = New System.Windows.Forms.ComboBox
        Me.TxtPassConfirm = New System.Windows.Forms.TextBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.TxtPass = New System.Windows.Forms.TextBox
        Me.TxbNombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.LblPassConfirm = New System.Windows.Forms.Label
        Me.LblPass = New System.Windows.Forms.Label
        Me.Lbl1 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.DataGridViewgastos = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridViewgastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txbLastName
        '
        Me.txbLastName.Location = New System.Drawing.Point(474, 124)
        Me.txbLastName.Name = "txbLastName"
        Me.txbLastName.Size = New System.Drawing.Size(130, 20)
        Me.txbLastName.TabIndex = 84
        Me.txbLastName.Visible = False
        '
        'TxbUserName
        '
        Me.TxbUserName.Location = New System.Drawing.Point(201, 121)
        Me.TxbUserName.Name = "TxbUserName"
        Me.TxbUserName.Size = New System.Drawing.Size(267, 20)
        Me.TxbUserName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "USUARIO:"
        '
        'LblTip
        '
        Me.LblTip.AutoSize = True
        Me.LblTip.Location = New System.Drawing.Point(71, 275)
        Me.LblTip.Name = "LblTip"
        Me.LblTip.Size = New System.Drawing.Size(39, 13)
        Me.LblTip.TabIndex = 81
        Me.LblTip.Text = "Label2"
        Me.LblTip.Visible = False
        '
        'UserType
        '
        Me.UserType.FormattingEnabled = True
        Me.UserType.Items.AddRange(New Object() {"0 - ADMINISTRADOR", "1 - USUARIO"})
        Me.UserType.Location = New System.Drawing.Point(201, 241)
        Me.UserType.Name = "UserType"
        Me.UserType.Size = New System.Drawing.Size(145, 21)
        Me.UserType.TabIndex = 5
        '
        'TxtPassConfirm
        '
        Me.TxtPassConfirm.Location = New System.Drawing.Point(200, 205)
        Me.TxtPassConfirm.Name = "TxtPassConfirm"
        Me.TxtPassConfirm.Size = New System.Drawing.Size(257, 20)
        Me.TxtPassConfirm.TabIndex = 4
        Me.TxtPassConfirm.UseSystemPasswordChar = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(422, 1)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(78, 89)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "&Salir"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(200, 170)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.Size = New System.Drawing.Size(257, 20)
        Me.TxtPass.TabIndex = 3
        Me.TxtPass.UseSystemPasswordChar = True
        '
        'TxbNombre
        '
        Me.TxbNombre.Location = New System.Drawing.Point(201, 83)
        Me.TxbNombre.Name = "TxbNombre"
        Me.TxbNombre.Size = New System.Drawing.Size(121, 20)
        Me.TxbNombre.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "TIPO DE USUARIO:"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(4, 1)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 89)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "&Nuevo"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'LblPassConfirm
        '
        Me.LblPassConfirm.AutoSize = True
        Me.LblPassConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPassConfirm.Location = New System.Drawing.Point(6, 206)
        Me.LblPassConfirm.Name = "LblPassConfirm"
        Me.LblPassConfirm.Size = New System.Drawing.Size(188, 16)
        Me.LblPassConfirm.TabIndex = 75
        Me.LblPassConfirm.Text = "CONFIRMAR CONTRASEÑA:"
        '
        'LblPass
        '
        Me.LblPass.AutoSize = True
        Me.LblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPass.Location = New System.Drawing.Point(89, 171)
        Me.LblPass.Name = "LblPass"
        Me.LblPass.Size = New System.Drawing.Size(105, 16)
        Me.LblPass.TabIndex = 74
        Me.LblPass.Text = "CONTRASEÑA:"
        '
        'Lbl1
        '
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl1.Location = New System.Drawing.Point(245, 28)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(128, 25)
        Me.Lbl1.TabIndex = 72
        Me.Lbl1.Text = "USUARIOS"
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.Location = New System.Drawing.Point(38, 122)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(156, 16)
        Me.LblNombre.TabIndex = 73
        Me.LblNombre.Text = "NOMBRE DE USUARIO:"
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(337, 1)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 89)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Location = New System.Drawing.Point(30, 313)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 97)
        Me.Panel1.TabIndex = 71
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(85, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 89)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(169, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 89)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(253, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(78, 89)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "&Eliminar"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(369, 144)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(218, 20)
        Me.TextBox1.TabIndex = 83
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(474, 121)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(130, 20)
        Me.TextBox2.TabIndex = 84
        Me.TextBox2.Visible = False
        '
        'DataGridViewgastos
        '
        Me.DataGridViewgastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewgastos.Location = New System.Drawing.Point(610, 83)
        Me.DataGridViewgastos.Name = "DataGridViewgastos"
        Me.DataGridViewgastos.Size = New System.Drawing.Size(395, 327)
        Me.DataGridViewgastos.TabIndex = 101
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1039, 457)
        Me.Controls.Add(Me.DataGridViewgastos)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txbLastName)
        Me.Controls.Add(Me.TxbUserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblTip)
        Me.Controls.Add(Me.UserType)
        Me.Controls.Add(Me.TxtPassConfirm)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.TxbNombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblPassConfirm)
        Me.Controls.Add(Me.LblPass)
        Me.Controls.Add(Me.Lbl1)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridViewgastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txbLastName As System.Windows.Forms.TextBox
    Friend WithEvents TxbUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTip As System.Windows.Forms.Label
    Friend WithEvents UserType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPassConfirm As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents TxbNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents LblPassConfirm As System.Windows.Forms.Label
    Friend WithEvents LblPass As System.Windows.Forms.Label
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewgastos As System.Windows.Forms.DataGridView
End Class
