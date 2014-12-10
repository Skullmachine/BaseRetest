<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BT_Importer = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_database = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_port = New System.Windows.Forms.ComboBox()
        Me.CB_username = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CB_password = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_server = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BT_Importer
        '
        Me.BT_Importer.Location = New System.Drawing.Point(127, 187)
        Me.BT_Importer.Name = "BT_Importer"
        Me.BT_Importer.Size = New System.Drawing.Size(129, 23)
        Me.BT_Importer.TabIndex = 0
        Me.BT_Importer.Text = "Traces --> BDD"
        Me.BT_Importer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Database:"
        '
        'CB_database
        '
        Me.CB_database.FormattingEnabled = True
        Me.CB_database.Items.AddRange(New Object() {"postgres"})
        Me.CB_database.Location = New System.Drawing.Point(93, 39)
        Me.CB_database.Name = "CB_database"
        Me.CB_database.Size = New System.Drawing.Size(70, 21)
        Me.CB_database.TabIndex = 3
        Me.CB_database.Text = "postgres"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Port:"
        '
        'CB_port
        '
        Me.CB_port.FormattingEnabled = True
        Me.CB_port.Items.AddRange(New Object() {"5432"})
        Me.CB_port.Location = New System.Drawing.Point(93, 91)
        Me.CB_port.Name = "CB_port"
        Me.CB_port.Size = New System.Drawing.Size(92, 21)
        Me.CB_port.TabIndex = 5
        Me.CB_port.Text = "5432"
        '
        'CB_username
        '
        Me.CB_username.FormattingEnabled = True
        Me.CB_username.Items.AddRange(New Object() {"postgres"})
        Me.CB_username.Location = New System.Drawing.Point(93, 118)
        Me.CB_username.Name = "CB_username"
        Me.CB_username.Size = New System.Drawing.Size(70, 21)
        Me.CB_username.TabIndex = 7
        Me.CB_username.Text = "postgres"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Username:"
        '
        'CB_password
        '
        Me.CB_password.FormattingEnabled = True
        Me.CB_password.Items.AddRange(New Object() {"toor"})
        Me.CB_password.Location = New System.Drawing.Point(93, 145)
        Me.CB_password.Name = "CB_password"
        Me.CB_password.Size = New System.Drawing.Size(70, 21)
        Me.CB_password.TabIndex = 9
        Me.CB_password.Text = "postgres"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Password:"
        '
        'CB_server
        '
        Me.CB_server.FormattingEnabled = True
        Me.CB_server.Items.AddRange(New Object() {"172.16.52.60"})
        Me.CB_server.Location = New System.Drawing.Point(93, 66)
        Me.CB_server.Name = "CB_server"
        Me.CB_server.Size = New System.Drawing.Size(92, 21)
        Me.CB_server.TabIndex = 11
        Me.CB_server.Text = "172.16.52.60"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Serveur:"
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 433)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CB_server)
        Me.Controls.Add(Me.CB_database)
        Me.Controls.Add(Me.CB_password)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CB_username)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CB_port)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_Importer)
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Name = "GUI"
        Me.Text = "GUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_Importer As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_database As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_port As System.Windows.Forms.ComboBox
    Friend WithEvents CB_username As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CB_password As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_server As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
