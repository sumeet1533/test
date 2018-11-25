@echo off
CALL ..\Ruby\bin\gem update --no-rdoc --no-ri
CALL ..\Ruby\bin\gem cleanup
PAUSE