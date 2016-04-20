iisreset /stop
Remove-Item -Recurse -Force - C:\inetpub\wwwroot\Calculator\
xcopy /y /e ..\calculator\*.* C:\inetpub\wwwroot\Calculator\
iisreset /start