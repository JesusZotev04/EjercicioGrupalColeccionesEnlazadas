@ECHO OFF 

SETLOCAL ENABLEDELAYEDEXPANSION

:INICIO
CLS
COLOR 07
SET contadorCarpetas=0
SET contadorCarpetaDeberes=0

ECHO - - - CARPETAS - - -
ECHO.
FOR /D %%d IN (*) DO (
        SET /A contadorCarpetas=contadorCarpetas+1
        ECHO ^(!contadorCarpetas!^) -^> %%d
)
ECHO. 
ECHO - - - ARCHIVOS - - -
ECHO. 
FOR %%f IN (*) DO (
        ECHO %%f
)
ECHO.
ECHO ------------------------------
ECHO ^| (0-9) -^> Entrar en carpeta ^|
ECHO ^| G -^> Guardar deberes       ^|
ECHO ^| A -^> Atras                 ^|
ECHO ------------------------------

ECHO.
ECHO - - - - - - - - - - -
SET /P opcion="> Elige una carpeta: "
CLS

IF "%opcion%" == "G" (     
        SET /P nombreCarpeta="> Nombre de la carpeta: "
        IF EXIST "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!" (
                SET /P opcion="¿Quieres sobreescribir el contenido existente? (S/N): "
                IF "!opcion!" == "S" (
                        CLS
                        ECHO Eliminando la carpeta anterior
                        COLOR 0C
                        RD /S /Q "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!"
                ) ELSE IF "!opcion!" == "s" (
                        CLS
                        ECHO Eliminando la carpeta anterior
                        COLOR 0C
                        RD /S /Q "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!"
                ) ELSE (
                        GOTO INICIO
                )
        )
        ECHO Copiando los deberes en el Escritorio
        COLOR 0A
        MD "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!"
        FOR /D %%d IN (*) DO (
                IF "%%d" NEQ ".vscode" (
                        SET /A contadorCarpetaDeberes=contadorCarpetaDeberes+1
                        MD "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!\Ejercicio!contadorCarpetaDeberes!"
                        CD %%d
                        FOR %%f IN (*) DO (
                                ECHO %%f | FIND ".cs" >> resultado_find.txt                             
                                ECHO %%f | FIND ".pdf" >> resultado_find.txt 
                        )
                        FINDSTR /v /c:".csproj" resultado_find.txt > temp.txt
                        DEL resultado_find.txt
                        rename temp.txt resultado_find.txt
                        FOR /F "delims=" %%a IN (resultado_find.txt) DO (
                                XCOPY /S /Y %%a "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!\Ejercicio!contadorCarpetaDeberes!" > NUL
                        )
                        DEL resultado_find.txt
                        CD ..
                ) 
        )
        ECHO ¡Se han copiado los deberes con exito!
        PAUSE 
) ELSE IF "%opcion%" == "g" (
        SET /P nombreCarpeta="> Nombre de la carpeta: "
        IF EXIST "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!" (
                SET /P opcion="¿Quieres sobreescribir el contenido existente? (S/N): "
                IF "!opcion!" == "S" (
                        CLS
                        ECHO Eliminando la carpeta anterior
                        COLOR 0C
                        RD /S /Q "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!"
                ) ELSE IF "!opcion!" == "s" (
                        CLS
                        ECHO Eliminando la carpeta anterior
                        COLOR 0C
                        RD /S /Q "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!"
                ) ELSE (
                        GOTO INICIO
                )
        )
        ECHO Copiando los deberes en el Escritorio
        COLOR 0A
        MD "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!"
        FOR /D %%d IN (*) DO (
                IF "%%d" NEQ ".vscode" (
                        SET /A contadorCarpetaDeberes=contadorCarpetaDeberes+1
                        MD "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!\Ejercicio!contadorCarpetaDeberes!"
                        CD %%d
                        FOR %%f IN (*) DO (
                                ECHO %%f | FIND ".cs" >> resultado_find.txt                             
                                ECHO %%f | FIND ".pdf" >> resultado_find.txt 
                        )
                        FINDSTR /v /c:".csproj" resultado_find.txt > temp.txt
                        DEL resultado_find.txt
                        rename temp.txt resultado_find.txt
                        FOR /F "delims=" %%a IN (resultado_find.txt) DO (
                                XCOPY /S /Y %%a "C:\Users\%USERNAME%\Desktop\!nombreCarpeta!\Ejercicio!contadorCarpetaDeberes!" > NUL
                        )
                        DEL resultado_find.txt
                        CD ..
                ) 
        )
        ECHO ¡Se han copiado los deberes con exito!
        PAUSE 
) ELSE IF "%opcion%" == "A" (
        CD ..
) ELSE IF "%opcion%" == "a" (
        CD ..
) ELSE (
        SET contadorCarpetas=0
        FOR /D %%d IN (*) DO (
                SET /A contadorCarpetas=contadorCarpetas+1
                IF !contadorCarpetas! EQU %opcion% (
                        CD "%%d"
                )
        )
)

GOTO INICIO