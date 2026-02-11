@echo off
echo -------------------------------------------------------
echo [tMPlugger] CLEANING PROJECT...
echo -------------------------------------------------------

:: Use dotnet clean to remove build artifacts
dotnet clean tMPlugger.sln

echo.
echo [OK] Project cleaned.
echo [OK] Temporary build files and binaries removed.
echo -------------------------------------------------------
pause
