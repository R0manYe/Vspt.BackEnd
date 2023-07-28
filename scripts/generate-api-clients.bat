@echo off
call "%~dp0_internal/run-bash.bat" "%~dp0generate-api-clients" %* || if /i %0 == "%~0" pause
exit /b %ERRORLEVEL%
