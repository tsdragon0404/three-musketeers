sqlcmd -S TSDRAGON -U sa -P sa123 -d RMSv100 -i "D:\Work\My project\SMS\install_packages\Drop schema.sql"

sqlcmd -S TSDRAGON -U sa -P sa123 -d RMSv100 -i "D:\Work\My project\SMS\install_packages\Db Schema.sql"

sqlcmd -S TSDRAGON -U sa -P sa123 -d RMSv100 -i "D:\Work\My project\SMS\install_packages\data.sql"

sqlcmd -S TSDRAGON -U sa -P sa123 -d RMSv100 -i "D:\Work\My project\SMS\install_packages\data-sample.sql"