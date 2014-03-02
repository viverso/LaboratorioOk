<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reporte_estudiosvb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reporte_estudiosvb))
        Me.CrystalReportViewerestidios = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrystalReportViewerestidios
        '
        Me.CrystalReportViewerestidios.ActiveViewIndex = -1
        Me.CrystalReportViewerestidios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewerestidios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewerestidios.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewerestidios.Name = "CrystalReportViewerestidios"
        Me.CrystalReportViewerestidios.SelectionFormula = ""
        Me.CrystalReportViewerestidios.Size = New System.Drawing.Size(1099, 595)
        Me.CrystalReportViewerestidios.TabIndex = 0
        Me.CrystalReportViewerestidios.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(145, 293)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 58)
        Me.btnSalir.TabIndex = 10
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(145, 230)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 57)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'reporte_estudiosvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 595)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.CrystalReportViewerestidios)
        Me.Name = "reporte_estudiosvb"
        Me.Text = "reporte_estudiosvb"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewerestidios As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
