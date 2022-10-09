@echo off

call C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe *.cs
echo compiled!
pause
cls
call program.exe

pause