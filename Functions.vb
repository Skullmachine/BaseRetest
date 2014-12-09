Imports System
Imports System.Data
Imports System.Xml
Imports System.Data.Odbc
Imports System.IO



Module Functions

    '*-------------------*Importation des données dans la base*----------------------*
    Public Sub ImportationData(database As String, server As String, port As Integer, user As String, password As String, queryString As String, drive As String, originPathSource As String, computerLogin As String, computerPassword As String, filePathSource As String, filePathDestination As String)

        '*****************Création d'un objet OdbcCommand contenant la requête SQL à exécuter*****************
        Dim command As New OdbcCommand(queryString)

        '*****************Ouverture d'une connexion à la base de donnée*****************
        Using connection As New OdbcConnection("Driver={PostgreSQL ANSI};database=" & database & ";server=" & server & ";port=" & port & ";uid=postgres;sslmode=disable;readonly=0;protocol=7.4;User ID=" & user & ";password=" & password & ";")
            command.Connection = connection
            Try
                'Ouverture de la connexion
                connection.Open()
                Try
                    'Exécution de la requête
                    command.ExecuteNonQuery()

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Using

    End Sub

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

        Dim Copy As Boolean = False
        Dim myProcess As New Process()

        'On donne le nom de l'application
        myProcess.StartInfo.FileName = "cmd.exe"

        'Si le fichier existe alors...
        If (Dir(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv") Then

            'On copie le fichier sur le pc où se situe l'application
            CopyFile(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", filePathDestination)

            'On met Copy égal à True
            Copy = True

        ElseIf (Dir(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", vbNormal) = "Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then
            CopyFile(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", filePathDestination)
            Copy = True
        ElseIf (Dir(drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".csv", vbNormal) = "Résultats00" & DateRun.ToString("yy_MM_dd") & ".csv") Then
            CopyFile(drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".csv", filePathDestination)
            Copy = True
        ElseIf (Dir(drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".bak", vbNormal) = "Résultats00" & DateRun.ToString("yy_MM_dd") & ".bak") Then
            CopyFile(drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".bak", filePathDestination)
            Copy = True
        ElseIf (Dir(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv") Then
            CopyFile(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", filePathDestination)
            Copy = True
        ElseIf (Dir(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", vbNormal) = "Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then
            CopyFile(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak", filePathDestination)
            Copy = True
        End If

        'Si un fichier a été copié
        If Copy = True Then

            'Filtrage de la table pour l'importation
            FilterFile("D:\tracabiliteimport.csv")

            'On copie le fichier avec le protocole ssh avec l'application pscp sur le serveur Linux où se situe la BDD
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ D:\tracabiliteimport.csv ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"

            'Cache l'invite de commande Windows
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

            'Lance le processus
            myProcess.Start()

            'Attend qu'il soit terminé avant d'aller plus loin
            myProcess.WaitForExit()

            'Ferme le processus
            myProcess.Close()

        End If

        ' On retourne la valeur de Copy
        FileName = Copy

    End Function

    Public Sub FilterFile(file As String)

        'Création d'une instance de StreamReader pour permettre la lecture de notre fichier
        Dim myStreamReader As StreamReader = New StreamReader(file)

        'Création d'une chaîne de caractère contenant une ligne
        Dim strLine As String


        Dim myArray(10000) As Object
        Dim i, j As Long

        i = 0

        Try
            'Read the first line of text.
            strLine = myStreamReader.ReadLine

            'Lecture de toutes les lignes
            Do

                Dim myWord As String = ";"
                Dim compteur As Integer = -1
                Dim index As Integer = -1

                Do

                    compteur += 1

                    index = strLine.IndexOf(myWord, index + 1)

                Loop Until index < 0

                If (compteur <> 33) Then
                    strLine = ""
                Else
                    strLine = myStreamReader.ReadLine()
                    i = i + 1
                End If

                myArray(i) = strLine

            Loop Until strLine Is Nothing

            'Fermeture du StreamReader
            myStreamReader.Close()

        Catch ex As Exception

            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(ex.Message)

        End Try

        'Création d'une instance de StreamWriter pour permettre l'écriture de notre fichier
        Dim myStreamWriter As StreamWriter = New StreamWriter(file)

        Try

            'Open the file.
            myStreamWriter = New StreamWriter(file)

            'Write out the numbers 1 through 10 on the same line.
            For j = 0 To i

                myStreamWriter.WriteLine(myArray(j))

            Next j

            'Close the file.
            myStreamWriter.Close()

        Catch ex As Exception

            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be written:")
            Console.WriteLine(ex.Message)
        End Try

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