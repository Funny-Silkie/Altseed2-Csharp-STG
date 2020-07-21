chcp 65001

for /f "tokens=1,2" %%a in (ReadFolder.txt) do (

cd ..\..\
cd %%b
mkdir Changed

for %%c in (*.cs) do (

..\Script\diffGenerator\Conv.exe %%c Changed\%%b
..\Script\diffGenerator\Conv.exe ..\%%a\%%c Changed\%%a

fc /U Changed\%%b Changed\%%a > Changed\%%c.txt
del Changed\%%a
del Changed\%%b
)

cd ..\
cd Script\diffGenerator

)
pause