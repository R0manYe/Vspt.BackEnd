@echo off
call "%~dp0_internal/run-bash.bat" "%~dp0show-docker-logs" %* || if /i %0 == "%~0" pause
exit /b %ERRORLEVEL%
