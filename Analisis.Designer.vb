<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Analisis
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
        Me.ComboanalisisEnRecibo = New System.Windows.Forms.ComboBox
        Me.DataGridViewEstudios = New System.Windows.Forms.DataGridView
        CType(Me.DataGridViewEstudios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboanalisisEnRecibo
        '
        Me.ComboanalisisEnRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboanalisisEnRecibo.FormattingEnabled = True
        Me.ComboanalisisEnRecibo.Location = New System.Drawing.Point(203, 29)
        Me.ComboanalisisEnRecibo.Name = "ComboanalisisEnRecibo"
        Me.ComboanalisisEnRecibo.Size = New System.Drawing.Size(661, 28)
        Me.ComboanalisisEnRecibo.TabIndex = 0
        '
        'DataGridViewEstudios
        '
        Me.DataGridViewEstudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEstudios.Location = New System.Drawing.Point(203, 85)
        Me.DataGridViewEstudios.Name = "DataGridViewEstudios"
        Me.DataGridViewEstudios.Size = New System.Drawing.Size(661, 239)
        Me.DataGridViewEstudios.TabIndex = 1
        '
        'Analisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 492)
        Me.Controls.Add(Me.DataGridViewEstudios)
        Me.Controls.Add(Me.ComboanalisisEnRecibo)
        Me.Name = "Analisis"
        Me.Text = "LLENADO DE ESTUDIOS"
        CType(Me.DataGridViewEstudios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboanalisisEnRecibo As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewEstudios As System.Windows.Forms.DataGridView
End Class
