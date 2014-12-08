﻿

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
    Dim filePathDestination As String = "/home/ubuntu/dbfiles/tracabiliteimport.csv"
    Dim drive As String
    Dim originPathSource As String
    Dim computerLogin As String
    Dim computerPassword As String
    Dim filePathSource As String
    Dim date_debut As Date = CDate("01/02/2014")
    Dim date_fin As Date = CDate("01/01/2015")
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

                    '*******************************
                    '       Prévoir filtrage
                    '*******************************

                    'Functions.LineFilter()

                    'Importe dans la BDD le fichier qui a été copié
                    Functions.ImportationData(database, server, port, user, password, queryString, drive, Ligne("path").ToString, Ligne("login").ToString, Ligne("password").ToString, filePathSource, filePathDestination)

                End If

                DateRun = DateAdd("d", 1, DateRun) ' Incrémentation de la date

            Loop

            'Déconnexion du lecteur réseau
            UnMapNetShare(drive)

        Next

    End Sub


End Class