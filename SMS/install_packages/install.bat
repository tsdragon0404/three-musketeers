@ECHO OFF

SET SOLUTIONFOLDER=C:\Program Files (x86)\SOLA Solutions

echo setup directory
IF NOT EXIST "%SOLUTIONFOLDER%" MKDIR "%SOLUTIONFOLDER%"

echo grant permission for iis users. MUST BE RUN AS ADMINISTRATOR!!!!
icacls "%SOLUTIONFOLDER%" /grant IIS_IUSRS:(OI)(CI)F

echo complete setting up directory

SET SCRIPT_PATH=E:\Work\TM\SMS\install_packages
SET SQLSERVER=.
SET USER=sms
SET PASSWORD=sms
SET DATABASE=SMS

echo executing Drop schema.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\Drop schema.sql"

echo executing Db Schema.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\Db Schema.sql"

echo executing data.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\data.sql"

echo executing data-sample.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\data-sample.sql"

echo executing branding.sql
sqlcmd -S %SQLSERVER% -U %USER% -P %PASSWORD% -d %DATABASE% -i "%SCRIPT_PATH%\branding.sql"

if errorlevel 1 goto pauseError

echo Install database successfull!

:pauseError
pause