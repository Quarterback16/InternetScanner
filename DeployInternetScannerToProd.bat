::  Deploy Internet Scanner to Prod
:: net use X: /DELETE
:: net use X: \\Katla\cdrive\apps

del x:\InternetScanner\backup\*.* /q
xcopy x:\InternetScanner\*.* x:\InternetScanner \backup\

xcopy InternetScanner.exe x:\InternetScanner  /y
xcopy InternetScanner.pdb x:\InternetScanner  /y


:: stable
 ::xcopy Shuttle.*.*.dll x:\InternetScanner  /y
 ::xcopy Shuttle.*.dll x:\InternetScanner  /y
 ::xcopy StructureMap.* x:\InternetScanner /y
 ::xcopy CSharpFunctionalExtensions.dll x:\InternetScanner /y
 ::xcopy Newtonsoft.* x:\InternetScanner /y
 ::xcopy Microsoft*.* x:\InternetScanner /y
 ::xcopy NLog*.* x:\InternetScanner /y
pause