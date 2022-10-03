@echo off

call C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe *.cs
echo compiled!
pause
cls
call program.exe

pause