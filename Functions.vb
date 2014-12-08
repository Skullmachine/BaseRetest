Imports System
Imports System.Data
Imports System.Xml
Imports System.Data.Odbc
Imports Microsoft.VisualBasic.FileIO



Module Functions

    '*-------------------*Importation des données dans la base*----------------------*
    Public Sub ImportationData(database As String, server As String, port As Integer, user As String, password As String, queryString As String, drive As String, originPathSource As String, computerLogin As String, computerPassword As String, filePathSource As String, filePathDestination As String) As Boolean

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

            'On copie le fichier avec le protocle ssh avec l'application pscp sur le serveur Linux où se situe la BDD
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"

            'On met Copy égal à True
            Copy = True

        ElseIf (Dir(drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Résultats" & DateRun.ToString("yyyy_MM_dd") & ".bak ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"
            Copy = True
        ElseIf (Dir(drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".csv", vbNormal) = "Résultats00" & DateRun.ToString("yy_MM_dd") & ".csv") Then
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".csv ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"
            Copy = True
        ElseIf (Dir(drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".bak", vbNormal) = "Résultats00" & DateRun.ToString("yy_MM_dd") & ".bak") Then
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Résultats00" & DateRun.ToString("yy_MM_dd") & ".bak ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"
            Copy = True
        ElseIf (Dir(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv") Then
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"
            Copy = True
        ElseIf (Dir(drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".csv", vbNormal) = "Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak") Then
            myProcess.StartInfo.Arguments = "/c pscp -pw ubuntu86+ " & drive & "\Resultats" & DateRun.ToString("yyyy_MM_dd") & ".bak ubuntu@172.16.52.60:/home/ubuntu/dbfiles/tracabiliteimport.csv"
            Copy = True
        End If

        If Copy = True Then

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