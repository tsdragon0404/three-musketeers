@ECHO OFF

SET SOLUTIONFOLDER=C:\Program Files (x86)\SOLA Solutions

echo setup directory
IF NOT EXIST "%SOLUTIONFOLDER%" MKDIR "%SOLUTIONFOLDER%"

echo grant permission for iis users. MUST BE RUN AS ADMINISTRATOR!!!!
icacls "%SOLUTIONFOLDER%" /grant IIS_IUSRS:(OI)(CI)F

echo complete setting up directory

SET SCRIPT_PATH=D:\Son Nguyen\Projects\SMS\install_packages
SET SQLSERVER=EZITWK160
SET USER=sa
SET PASSWORD=sa123
SET DATABASE=SMSv100

echo executing Drop schema.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\Drop schema.sql" -b

if errorlevel 1 goto pauseError

echo executing Db Schema.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\Db Schema.sql" -b

if errorlevel 1 goto pauseError

echo executing data.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\data.sql" -b

if errorlevel 1 goto pauseError

echo executing data-sample.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\data-sample.sql" -b

if errorlevel 1 goto pauseError

echo executing branding.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\branding.sql" -b

if errorlevel 1 goto pauseError

echo Install database successfull!
exit

:pauseError
pause