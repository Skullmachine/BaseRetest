

Imports System
Imports System.Data
Imports System.Xml
Imports System.Data.Odbc
Imports Microsoft.VisualBasic.FileIO

Public Class GUI

    Dim database As String = "postgres"
    Dim server As String = "172.16.52.60"
    Dim port As Integer = 5432
    Dim user As String = "postgres"
    Dim password As String = "postgres"
    Dim filePathDestination As String = "D:\tracabiliteimport.csv"
    Dim drive As String
    Dim originPathSource As String
    Dim computerLogin As String
    Dim computerPassword As String
    Dim filePathSource As String
    Dim date_debut As Date = CDate("01/02/2014")
    Dim date_fin As Date = CDate("31/12/2014")
    Dim queryString As String = _
   "SELECT dataimport();"

    Dim queryStringTesteur As String = _
   "SELECT path, login, password FROM listepctesteur;"

    Dim myDataSet As New DataSet

    Public Sub BT_Importer_Click(sender As Object, e As EventArgs) Handles BT_Importer.Click

        Dim DateRun As Date
        Dim Copy As Boolean

        'Importation du Path, Login et Password de chaque testeur de la table
        myDataSet = Functions.ImportationDataTesteur(database, server, port, user, password, queryStringTesteur, computerLogin, computerPassword)

        'Pour chaque testeur
        For Each Ligne As DataRow In myDataSet.Tables("listepctesteur").Rows()

            'Selection du Lecteur qui sera utilisé
            drive = F_WSH.DriveSelect()

            'On mappe le lecteur réseau
            MapNetShare(drive, Ligne("path".ToString), Ligne("login").ToString, Ligne("password").ToString)

            'Initialisation de la date de scrutation
            DateRun = date_debut

            Do While DateRun <= date_fin

                'Copie le fichier si la bonne syntaxe a été trouvé
                Copy = Functions.FileName(drive, DateRun, filePathDestination)

                'Si un fichier a été copié alors on...
                If Copy = True Then

                    'Importe dans la BDD le fichier qui a été copié
                    Functions.ImportationData(database, server, port, user, password, queryString, drive, Ligne("path").ToString, Ligne("login").ToString, Ligne("password").ToString, filePathSource, filePathDestination)

                    'Affichage des lignes importées
                    Console.WriteLine("Le fichier " & Ligne("path".ToString) & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv a été importé.")

                End If

                ' Incrémentation de la date
                DateRun = DateAdd("d", 1, DateRun)

            Loop

            'Déconnexion du lecteur réseau
            UnMapNetShare(drive)

        Next

    End Sub

    Private Sub CB_server_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_server.TextChanged

        server = CB_server.Text

    End Sub

    Private Sub CB_database_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_database.TextChanged

        database = CB_database.Text

    End Sub

    Private Sub CB_port_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_port.TextChanged

        port = CB_port.Text

    End Sub

    Private Sub CB_username_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_username.TextChanged

        user = CB_username.Text

    End Sub

    Private Sub CB_password_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_password.SelectedIndexChanged

        password = CB_password.Text

    End Sub

End Class
