sleep 15s
/opt/mssql-tools/bin/sqlcmd -S db -U SA -P 'k&VJB3r892a8@' -i /home/argan/create-db.sql

sleep 15s
/opt/mssql-tools/bin/sqlcmd -S db -U SA -P 'k&VJB3r892a8@' -i /home/argan/create-tables.sql