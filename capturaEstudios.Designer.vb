<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class capturaEstudios
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPaciente = New System.Windows.Forms.TextBox
        Me.txtRegistro = New System.Windows.Forms.TextBox
        Me.DateTimePickerTecha = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridViewDetalleEstudio = New System.Windows.Forms.DataGridView
        Me.parametros = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.resultados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idEstudio = New System.Windows.Forms.Label
        CType(Me.DataGridViewDetalleEstudio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(197, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EXAMEN PRACTICADO A:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(197, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "REGISTRO:"
        '
        'txtPaciente
        '
        Me.txtPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaciente.Location = New System.Drawing.Point(427, 16)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(379, 26)
        Me.txtPaciente.TabIndex = 2
        '
        'txtRegistro
        '
        Me.txtRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistro.Location = New System.Drawing.Point(427, 56)
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.Size = New System.Drawing.Size(379, 26)
        Me.txtRegistro.TabIndex = 3
        '
        'DateTimePickerTecha
        '
        Me.DateTimePickerTecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerTecha.Location = New System.Drawing.Point(427, 102)
        Me.DateTimePickerTecha.Name = "DateTimePickerTecha"
        Me.DateTimePickerTecha.Size = New System.Drawing.Size(111, 26)
        Me.DateTimePickerTecha.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(197, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "FECHA:"
        '
        'DataGridViewDetalleEstudio
        '
        Me.DataGridViewDetalleEstudio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDetalleEstudio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.parametros, Me.resultados})
        Me.DataGridViewDetalleEstudio.Location = New System.Drawing.Point(12, 144)
        Me.DataGridViewDetalleEstudio.Name = "DataGridViewDetalleEstudio"
        Me.DataGridViewDetalleEstudio.Size = New System.Drawing.Size(1132, 290)
        Me.DataGridViewDetalleEstudio.TabIndex = 6
        '
        'parametros
        '
        Me.parametros.HeaderText = "PARAMETROS"
        Me.parametros.Name = "parametros"
        Me.parametros.Width = 450
        '
        'resultados
        '
        Me.resultados.HeaderText = "RESULTADOS"
        Me.resultados.Name = "resultados"
        Me.resultados.Width = 550
        '
        'idEstudio
        '
        Me.idEstudio.AutoSize = True
        Me.idEstudio.Location = New System.Drawing.Point(910, 35)
        Me.idEstudio.Name = "idEstudio"
        Me.idEstudio.Size = New System.Drawing.Size(39, 13)
        Me.idEstudio.TabIndex = 7
        Me.idEstudio.Text = "Label4"
        '
        'capturaEstudios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 505)
        Me.Controls.Add(Me.idEstudio)
        Me.Controls.Add(Me.DataGridViewDetalleEstudio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePickerTecha)
        Me.Controls.Add(Me.txtRegistro)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "capturaEstudios"
        Me.Text = "capturaEstudios"
        CType(Me.DataGridViewDetalleEstudio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents txtRegistro As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerTecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewDetalleEstudio As System.Windows.Forms.DataGridView
    Friend WithEvents parametros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resultados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idEstudio As System.Windows.Forms.Label
End Class
