@echo off
echo Khoi phuc database...
echo.

REM Dung ung dung neu dang chay
taskkill /f /im SuaNhaMVC.exe 2>nul

REM Copy backup file
copy SuaNhaMVC_backup.db ..\SuaNhaMVC.db
copy SuaNhaMVC.db-shm ..\SuaNhaMVC.db-shm 2>nul
copy SuaNhaMVC.db-wal ..\SuaNhaMVC.db-wal 2>nul

echo Database da duoc khoi phuc thanh cong!
echo.
echo Thong tin dang nhap Admin:
echo Email: admin@admin.com
echo Password: admin@123
echo.
pause