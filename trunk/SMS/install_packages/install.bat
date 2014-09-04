@echo off
D:
echo executing Drop schema.sql
sqlcmd -S EZITWK160 -U sa -P sa123 -d SMSv100 -i "D:\Son Nguyen\Projects\SMS\install_packages\Drop schema.sql"

echo executing Db Schema.sql
sqlcmd -S EZITWK160 -U sa -P sa123 -d SMSv100 -i "D:\Son Nguyen\Projects\SMS\install_packages\Db Schema.sql"

echo executing data.sql
sqlcmd -S EZITWK160 -U sa -P sa123 -d SMSv100 -i "D:\Son Nguyen\Projects\SMS\install_packages\data.sql"

echo executing data-sample.sql
sqlcmd -S EZITWK160 -U sa -P sa123 -d SMSv100 -i "D:\Son Nguyen\Projects\SMS\install_packages\data-sample.sql"

if errorlevel 1 goto pauseError

echo Install database successfull!

:pauseError
pause