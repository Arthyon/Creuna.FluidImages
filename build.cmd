@echo off
cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)



IF NOT EXIST bin\*.nupkg (
  .paket\paket.exe restore group build
  if errorlevel 1 (
    exit /b %errorlevel%
  )
  packages\build\FAKE\tools\FAKE.exe init.fsx %*
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

packages\build\FAKE\tools\FAKE.exe build.fsx %*
