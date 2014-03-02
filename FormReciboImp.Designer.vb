<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReciboImp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReciboImp))
        Me.CrystalReportViewerRecibo = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrystalReportViewerRecibo
        '
        Me.CrystalReportViewerRecibo.ActiveViewIndex = -1
        Me.CrystalReportViewerRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewerRecibo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewerRecibo.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewerRecibo.Name = "CrystalReportViewerRecibo"
        Me.CrystalReportViewerRecibo.SelectionFormula = ""
        Me.CrystalReportViewerRecibo.Size = New System.Drawing.Size(640, 494)
        Me.CrystalReportViewerRecibo.TabIndex = 0
        Me.CrystalReportViewerRecibo.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(147, 311)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 58)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(147, 248)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 57)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'FormReciboImp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 494)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.CrystalReportViewerRecibo)
        Me.Name = "FormReciboImp"
        Me.Text = "FormReciboImp"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewerRecibo As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
