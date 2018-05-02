@echo off
CD /D "%~dp0\ListViewPerformance\bin\Debug"
set /p qty=Number of windows to open:
	for /l %%x in (1, 1, %qty%) do (
   		start ListViewPerformance.exe
	)