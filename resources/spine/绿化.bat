reg import spine.reg
xcopy Spine %USERPROFILE%\Spine\ /e /y
Shortcut.exe /f:"%USERPROFILE%\Desktop\Spine.lnk" /a:c /t:"%~dp0\Spine.exe"
