@echo off
CD /D "%~dp0\XceedDataGridPerformance\bin\Debug"
set /p qty=Number of windows to open:
	for /l %%x in (1, 1, %qty%) do (
   		start XceedDataGridPerformance.exe
	)