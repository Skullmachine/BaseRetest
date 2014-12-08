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
        Me.CB_Database = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Port = New System.Windows.Forms.ComboBox()
        Me.CB_Username = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CB_Password = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BT_InfosTesteurs = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BT_Importer
        '
        Me.BT_Importer.Location = New System.Drawing.Point(112, 225)
        Me.BT_Importer.Name = "BT_Importer"
        Me.BT_Importer.Size = New System.Drawing.Size(129, 23)
        Me.BT_Importer.TabIndex = 0
        Me.BT_Importer.Text = "Traces --> BDD"
        Me.BT_Importer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Database:"
        '
        'CB_Database
        '
        Me.CB_Database.FormattingEnabled = True
        Me.CB_Database.Items.AddRange(New Object() {"postgres"})
        Me.CB_Database.Location = New System.Drawing.Point(93, 69)
        Me.CB_Database.Name = "CB_Database"
        Me.CB_Database.Size = New System.Drawing.Size(70, 21)
        Me.CB_Database.TabIndex = 3
        Me.CB_Database.Text = "postgres"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Port:"
        '
        'CB_Port
        '
        Me.CB_Port.FormattingEnabled = True
        Me.CB_Port.Items.AddRange(New Object() {"5432"})
        Me.CB_Port.Location = New System.Drawing.Point(93, 96)
        Me.CB_Port.Name = "CB_Port"
        Me.CB_Port.Size = New System.Drawing.Size(70, 21)
        Me.CB_Port.TabIndex = 5
        Me.CB_Port.Text = "5432"
        '
        'CB_Username
        '
        Me.CB_Username.FormattingEnabled = True
        Me.CB_Username.Items.AddRange(New Object() {"postgres"})
        Me.CB_Username.Location = New System.Drawing.Point(93, 123)
        Me.CB_Username.Name = "CB_Username"
        Me.CB_Username.Size = New System.Drawing.Size(70, 21)
        Me.CB_Username.TabIndex = 7
        Me.CB_Username.Text = "postgres"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Username"
        '
        'CB_Password
        '
        Me.CB_Password.FormattingEnabled = True
        Me.CB_Password.Items.AddRange(New Object() {"toor"})
        Me.CB_Password.Location = New System.Drawing.Point(93, 150)
        Me.CB_Password.Name = "CB_Password"
        Me.CB_Password.Size = New System.Drawing.Size(70, 21)
        Me.CB_Password.TabIndex = 9
        Me.CB_Password.Text = "toor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Password"
        '
        'BT_InfosTesteurs
        '
        Me.BT_InfosTesteurs.Location = New System.Drawing.Point(112, 196)
        Me.BT_InfosTesteurs.Name = "BT_InfosTesteurs"
        Me.BT_InfosTesteurs.Size = New System.Drawing.Size(129, 23)
        Me.BT_InfosTesteurs.TabIndex = 10
        Me.BT_InfosTesteurs.Text = "BDD --> Infos Testeurs"
        Me.BT_InfosTesteurs.UseVisualStyleBackColor = True
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 269)
        Me.Controls.Add(Me.BT_InfosTesteurs)
        Me.Controls.Add(Me.CB_Database)
        Me.Controls.Add(Me.CB_Password)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CB_Username)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CB_Port)
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
    Friend WithEvents CB_Database As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_Port As System.Windows.Forms.ComboBox
    Friend WithEvents CB_Username As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CB_Password As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BT_InfosTesteurs As System.Windows.Forms.Button

End Class
