@echo off
:start 
	@echo off
	cls
	python signaturesurvey.py | sort
	ping -n 5 127.0.0.1 > NUL
goto start

rem LOOOL 