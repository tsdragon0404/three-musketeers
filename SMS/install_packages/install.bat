@ECHO OFF

SET SCRIPT_PATH=D:\Projects\TM\SMS\install_packages
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

if errorlevel 1 goto pauseError

echo Install database successfull!

:pauseError
pause