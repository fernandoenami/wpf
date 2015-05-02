@echo off
CD /D "%~dp0\DataGridPerformance\bin\Debug"
Echo =============================================
echo     User input example
Echo =============================================
set /p qty=Number of windows to open:
	for /l %%x in (1, 1, %qty%) do (
   		start "DataGridPerformance.exe"
	)