Module F_WSH

    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    '$                     Script programmable version 1.0.1.9                      $
    '$                            Développé par M.NAOUR                             $
    '$                                le 22/01/09                                   $
    '$                            modifié le 28/02/09                               $
    '$                                                                              $
    '$ Fonctions:                                                                   $
    '$      - MapNetShare(Drive, Serveur, Login, PasseWord)                         $
    '$      - UnMapNetShare(Drive)                                                  $
    '$      - DelFile(File)                                                         $
    '$      - CopyFile(FileSource, FileDestination)                                 $
    '$      - DriveSelect() return un non de lecteur (Z:)                           $
    '$                                                                              $
    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    '*-------------------*Déclaration des constantes et variables*--------------*
    Private objFSO, objNET As Object

    '*-------------------*Connexion d'un Lecteur reseaux*----------------------*
    Public Function MapNetShare(Drive As String, Serveur As String, login As String, PasseWord As String) As Boolean

        '****************Attribution des Variables**********************
        objNET = CreateObject("wscript.Network")
        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system


        'Vérification de l'existance du lecteur reseau
        If LecteurExists(Drive) Then
            'Si le Lecteur reseau existe alors on le supprime
            objNET.RemoveNetworkDrive(Drive, True, True)
        End If

        Try
            'Reconnexion du Lecteur resau
            objNET.MapNetworkDrive(Drive, Serveur, , login, PasseWord)

        Catch ex As Exception
            Console.WriteLine(ex.Message & "à l'adresse: " & Serveur)
        End Try


        If (LecteurExists(Drive) = True) Then
            MapNetShare = True
        Else
            MapNetShare = False
        End If


        objFSO = Nothing
        objNET = Nothing

        Exit Function

    End Function

    '*-------------------*déconnection d'un Lecteur reseaux*--------------------*
    Public Function UnMapNetShare(Drive As String)
        '******************Création des Variables**********************

        '****************Attribution des Variables**********************
        objNET = CreateObject("wscript.Network")
        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system

        'Vérification de l'existance du lecteur reseau
        If LecteurExists(Drive) Then
            'Si le Lecteur reseau existe alors on le supprime
            objNET.RemoveNetworkDrive(Drive, True, True)
            UnMapNetShare = True
        Else
            UnMapNetShare = False
        End If


        objFSO = Nothing
        objNET = Nothing
    End Function

    '*-------------------*Suppression d'un fichier*-----------------------------*
    Public Function DelFile(File As String) 'retourne true si supprimé sinon False
        '************** Déclaration des constantes et variables ****************
        Const DeleteReadOnly = True
        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system

        '***********************suppression du fichier**************************
        If (objFSO.FileExists(File) = True) Then
            objFSO.DeleteFile(File, DeleteReadOnly)  'Suppression si fichier existant
            DelFile = True
        Else
            DelFile = False
        End If

        objFSO = Nothing
    End Function

    '*-------------------*Copie d'un fichier*-----------------------------------*
    Public Function CopyFile(FileSource As String, FileDestination As String) As Boolean 'retourne true si Copie sinon False
        '************** Déclaration des constantes et variables ****************
        Const OverWrite = True
        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system

        '***********************Suppression du fichier**************************
        If (objFSO.FileExists(FileSource) = True) Then
            If (objFSO.FolderExists(objFSO.GetParentFolderName(FileDestination)) = True) Then
                objFSO.CopyFile(FileSource, FileDestination, OverWrite) 'Copie si fichier source existant
                CopyFile = True
            Else
                objFSO.CreateFolder(objFSO.GetParentFolderName(FileDestination))
                If (objFSO.FolderExists(objFSO.GetParentFolderName(FileDestination)) = True) Then
                    objFSO.CopyFile(FileSource, FileDestination, OverWrite) 'Copie si fichier source existant
                    CopyFile = True
                Else
                    CopyFile = False
                End If
            End If
        Else
            CopyFile = False
        End If
        objFSO = Nothing
    End Function

    '*-------------------*Récupération d'un nom de lecteur non utilisé*----------------------*
    Public Function DriveSelect() As String
        '******************Création des Variables**********************
        Dim AlfaB As Object

        '****************Attribution des Variables**********************
        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system

        AlfaB = {"Z:", "Y:", "X:", "W:", "V:", "U:", "T:", "S:", "R:", "Q:", "P:", "O:", "N:", "M:", "L:", "K:", "J:", "I:", "H:", "G:", "F:"}

        DriveSelect = ""

        For Each Lecteur In AlfaB
            'Vérification de l'existance du lecteur reseau
            If (LecteurExists(Lecteur) = False) Then
                'Si le Lecteur reseau n'existe pas
                DriveSelect = Lecteur
                Exit For
            End If
        Next Lecteur

        objFSO = Nothing

    End Function

    '*-------------------*Récupération d'un nom de lecteur non utilisé*----------------------*
    Public Function LecteurExists(Lecteur As Object) As Boolean
        '****************Attribution des Variables**********************
        objFSO = CreateObject("Scripting.FileSystemObject")     'Création d'un Object File system

        LecteurExists = False

        'Vérification de l'existance du lecteur reseau
        For Each Drive In objFSO.Drives
            If (Lecteur = Drive.Path) Then
                LecteurExists = True
                Exit For
            End If
        Next Drive


        objFSO = Nothing
    End Function

End Module