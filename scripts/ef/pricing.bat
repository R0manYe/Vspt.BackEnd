@echo off
call "%~dp0../_internal/run-bash.bat" "%~dp0pg" %* || if /i %0 == "%~0" pause
exit /b %ERRORLEVEL%
