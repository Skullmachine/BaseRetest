Imports System
Imports System.Data
Imports System.Xml
Imports System.Data.Odbc
Imports Microsoft.VisualBasic.FileIO



Module Functions

    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    '$                      Script programmable version 1.0.1.9                                                                                                                 $
    '$                            Développé par T.ARTUS                                                                                                                         $
    '$                                le 27/11/14                                                                                                                               $
    '$                                                                                                                                                                          $
    '$                                                                                                                                                                          $
    '$ Fonctions:                                                                                                                                                               $
    '$      ImportationData(database, server, port, user, password, queryString, drive, originPathSource, computerLogin, computerPassword, filePathSource, filePathDestination) $                                                                         $
    '$      ImportationDataTesteur(database, server, port, user, password, queryStringTesteur, computerLogin, computerPassword)                                                 $                                                                                                               $
    '$                                                                                                                                                                          $
    '$                                                                                                                                                                          $
    '$                                                                                                                                                                          $
    '$                                                                                                                                                                          $
    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    Private objFSO As Object

    '*-------------------*Importation des données dans la base*----------------------*
    Public Function ImportationData(database As String, server As String, port As Integer, user As String, password As String, queryString As String, drive As String, originPathSource As String, computerLogin As String, computerPassword As String, filePathSource As String, filePathDestination As String) As Boolean

        '*****************Création d'un objet OdbcCommand contenant la requête SQL à exécuter*****************
        Dim command As New OdbcCommand(queryString)

        '*****************Ouverture d'une connexion à la base de donnée*****************
        Using connection As New OdbcConnection("Driver={PostgreSQL ANSI};database=" & database & ";server=" & server & ";port=" & port & ";uid=postgres;sslmode=disable;readonly=0;protocol=7.4;User ID=" & user & ";password=" & password & ";")
            command.Connection = connection

            'Ouverture de la connexion
            connection.Open()

            'Exécution de la requête
            command.ExecuteNonQuery()

            'Si la connexion est réussie alors affichage du message
            If connection.State = ConnectionState.Open Then
                Console.WriteLine("Les donnees à l'adresse " & originPathSource & " ont ete importe.")
            Else
                ImportationData = False
            End If

            ImportationData = True

        End Using

    End Function

    Public Function ImportationDataTesteur(database As String, server As String, port As Integer, user As String, password As String, queryStringTesteur As String, computerLogin As String, computerPassword As String) As DataSet

        '*****************Création d'un objet OdbcCommand contenant la requête SQL à exécuter*****************
        Dim command As New OdbcCommand(queryStringTesteur)

        '*****************Création d'un objet OdbcDataAdaptater permettant le transfert d'une table dans un DataSet*****************
        Dim adaptater As New OdbcDataAdapter(command)

        '*****************Création d'un objet DataSet contenant une table*****************
        Dim myDataSet As New DataSet


        '*****************Ouverture d'une connexion à la base de donnée*****************
        Using connection As New OdbcConnection("Driver={PostgreSQL ANSI};Server=" & server & ";Port=" & port & ";Database=" & database & ";Uid=" & user & ";Pwd=" & password & ";")
            command.Connection = connection
            Try
                'Ouverture de la connexion à la BDD
                connection.Open()

                Try
                    'Copie de la table listepctesteur dans myDataSet
                    adaptater.Fill(myDataSet, "listepctesteur")

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Using

        'Retourne la table myDataSet
        ImportationDataTesteur = myDataSet

    End Function

    Public Function FileName(drive As String, DateRun As Date, filePathDestination As String) As Boolean

        Dim Copy As Boolean = 0
        Dim strCmdCopy As String

        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = "cmd.exe" 'l'application

        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system

        If (Dir(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv") Then 'Si fichier existe alors copie
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"
            Copy = 1
        ElseIf (Dir(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", vbNormal) = "Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then 'Si fichier existe alors copie
            F_WSH.CopyFile(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", filePathDestination)
            Console.WriteLine(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak a été copié")
            Copy = 1
        ElseIf (Dir(drive & "\Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".csv") Then 'Si fichier existe alors copie
            F_WSH.CopyFile(drive & "\Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".csv", filePathDestination)
            Console.WriteLine(drive & "\Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".csv a été copié")
            Copy = 1
        ElseIf (Dir(drive & "\Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".bak", vbNormal) = "Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then 'Si fichier existe alors copie
            F_WSH.CopyFile(drive & "\Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".bak", filePathDestination)
            Console.WriteLine(drive & "\Résultats00" & DateRun.ToString("yyyy_MM_dd") & ".bak a été copié")
            Copy = 1
        ElseIf (Dir(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv") Then 'Si fichier existe alors copie
            F_WSH.CopyFile(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", filePathDestination)
            Console.WriteLine(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv a été copié")
            Copy = 1
        ElseIf (Dir(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", vbNormal) = "Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then 'Si fichier existe alors copie
            F_WSH.CopyFile(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", filePathDestination)
            Console.WriteLine(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak a été copié")
            Copy = 1
        End If

        myProcess.Start() 'lance le process
        myProcess.WaitForExit() 'attend qu'il soit terminé avant d'aller plus loin
        myProcess.Close() 'ferme le process

        objFSO = Nothing

        FileName = Copy

    End Function

    Public Sub LineFilter()

        Dim nbPVirgule


        ' Do Until MonFichier.EndRea

        'MonFichier = New IO.FileStream("D:\tracabiliteimport.csv", IO.FileMode.Open)

        ' If MonFichier.CanRead() Then
        'Dim Contenu(100000) As Byte
        'MonFichier.Position = 0
        'MonFichier.Read(Contenu, 0, 1000000)


        'End If

    End Sub

    Function SansAccents(strAvecAccents)

        Const ACCENT = "ÀÁÂÃÄÅàáâãäåÒÓÔÕÖØòóôõöøÈÉÊËèéêëÌÍÎÏìíîïÙÚÛÜùúûüÿÑñÇç"
        Const NOACCENT = "AAAAAAaaaaaaOOOOOOooooooEEEEeeeeIIIIiiiiUUUUuuuuyNnCc"

        ' Définition des variables locales
        Dim i
        Dim lettre
        Dim strSansAccents

        strSansAccents = strAvecAccents
        For i = 1 To Len(ACCENT)
            lettre = Mid(ACCENT, i, 1)
            If InStr(strSansAccents, lettre) > 0 Then
                strSansAccents = Replace(strSansAccents, lettre, Mid(NOACCENT, i, 1))
            End If
        Next
        SansAccents = strSansAccents

        ' Libération des variables locales
        i = Nothing
        lettre = Nothing
        strSansAccents = Nothing

    End Function

End Module


'Dim lines As String() = System.IO.File.ReadAllLines("D:\tracabiliteimport.csv")

'    nbPVirgule = 0

'   For Each line In lines
'    If 
'    Next


'     System.IO.File.WriteAllLines("D:\tracabiliteimport.csv", lines)