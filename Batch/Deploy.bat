iisreset /stop
del /s /q C:\inetpub\wwwroot\Calculator\
xcopy /y /e ..\calculator\*.* C:\inetpub\wwwroot\Calculator\
iisreset /start