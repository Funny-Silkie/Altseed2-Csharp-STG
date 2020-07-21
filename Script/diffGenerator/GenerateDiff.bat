chcp 65001

for /f "tokens=1,2" %%a in (ReadFolder.txt) do (

cd ..\..\
cd %%b
mkdir Changed

for %%c in (*.cs) do (

..\Script\diffGenerator\Conv.exe %%c Changed\%%a
..\Script\diffGenerator\Conv.exe ..\%%a\%%c Changed\%%b

fc /U Changed\%%b Changed\%%a > Changed\%%c.txt
del Changed\%%a
del Changed\%%b
)

cd ..\
cd Script\diffGenerator

)
pause