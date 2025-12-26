@echo off
echo ========================================
echo Cleaning up old WrathCombo plugin data
echo ========================================
echo.

set DEVPLUGINS=%APPDATA%\XIVLauncher\devPlugins
set INSTALLEDPLUGINS=%APPDATA%\XIVLauncher\installedPlugins

echo Checking for old WrathCombo folders...
echo.

if exist "%DEVPLUGINS%\WrathCombo" (
    echo Found: %DEVPLUGINS%\WrathCombo
    echo Deleting...
    rmdir /s /q "%DEVPLUGINS%\WrathCombo"
    echo Deleted old WrathCombo dev plugin folder
) else (
    echo No old WrathCombo dev plugin folder found
)

echo.

if exist "%INSTALLEDPLUGINS%\WrathCombo" (
    echo Found: %INSTALLEDPLUGINS%\WrathCombo
    echo Deleting...
    rmdir /s /q "%INSTALLEDPLUGINS%\WrathCombo"
    echo Deleted old WrathCombo installed plugin folder
) else (
    echo No old WrathCombo installed plugin folder found
)

echo.
echo ========================================
echo Checking Mekanist output...
echo ========================================
echo.

if exist "%DEVPLUGINS%\Mekanist\Mekanist.dll" (
    echo SUCCESS: Mekanist.dll found at:
    echo %DEVPLUGINS%\Mekanist\Mekanist.dll
) else (
    echo WARNING: Mekanist.dll NOT found at expected location
    echo %DEVPLUGINS%\Mekanist\
)

echo.

if exist "%DEVPLUGINS%\Mekanist\Mekanist.json" (
    echo SUCCESS: Mekanist.json found
) else (
    echo WARNING: Mekanist.json NOT found
)

echo.
echo ========================================
echo Cleanup complete!
echo ========================================
echo.
echo Next steps:
echo 1. Close FFXIV completely if running
echo 2. Restart XIVLauncher
echo 3. Enable Mekanist in Plugin Installer
echo.
pause
