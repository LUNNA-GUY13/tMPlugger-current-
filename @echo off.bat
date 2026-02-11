@echo off
echo Generating Project Documentation...

:: Create .gitignore
(
echo [Dd]ebug/
echo [Rr]elease/
echo x64/
echo bin/
echo obj/
echo .vs/
echo *.user
echo tMPlugger_Log.txt
) > .gitignore

echo Done: .gitignore generated.

:: Note: This bat file just confirms the structure is ready for you to paste the MD content.
echo ---------------------------------------------------
echo FILES GENERATED. 
echo 1. Ensure you have pasted the MD content into README.md
echo 2. Ensure your images are in the /assets/ folder.
echo ---------------------------------------------------
pause