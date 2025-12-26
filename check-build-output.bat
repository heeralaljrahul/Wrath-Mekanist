@echo off
echo ========================================
echo Checking Mekanist Build Output
echo ========================================
echo.

set OUTPUT=%APPDATA%\XIVLauncher\devPlugins\Mekanist

echo Build output directory:
echo %OUTPUT%
echo.

if not exist "%OUTPUT%" (
    echo ERROR: Output directory does not exist!
    echo Please rebuild the solution in Visual Studio
    goto :end
)

echo Files in output directory:
dir "%OUTPUT%" /B
echo.

echo ========================================
echo Checking critical files:
echo ========================================

if exist "%OUTPUT%\Mekanist.dll" (
    echo [OK] Mekanist.dll found
) else (
    echo [MISSING] Mekanist.dll NOT FOUND
)

if exist "%OUTPUT%\Mekanist.json" (
    echo [OK] Mekanist.json found
) else (
    echo [MISSING] Mekanist.json NOT FOUND
)

if exist "%OUTPUT%\icon.png" (
    echo [OK] icon.png found
    for %%A in ("%OUTPUT%\icon.png") do echo     Size: %%~zA bytes
) else (
    echo [MISSING] icon.png NOT FOUND
    echo     This is why the icon isn't showing!
)

if exist "%OUTPUT%\images\mekanist.png" (
    echo [WARNING] Old icon path found: images\mekanist.png
    echo     This should be icon.png in the root
)

echo.
echo ========================================
echo Instructions:
echo ========================================
echo 1. Make sure you've pulled the latest changes
echo 2. In Visual Studio: Build -^> Rebuild Solution
echo 3. Check that icon.png appears in the output folder
echo 4. Restart FFXIV and XIVLauncher
echo.

:end
pause
