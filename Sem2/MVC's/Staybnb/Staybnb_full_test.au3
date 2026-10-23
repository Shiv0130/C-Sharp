; Staybnb_Nav_7180.au3
; Asks until app is running, then navigates Admin/Host/Guest
; Esc = stop anytime
#include <MsgBoxConstants.au3>

Global $Base = "https://localhost:7180"
HotKeySet("{ESC}", "_Quit")
Func _Quit()
    MsgBox($MB_ICONWARNING, "Staybnb", "Stopped.")
    Exit
EndFunc

Func Go($path)
    ShellExecute($Base & $path)
    Sleep(2200)
EndFunc

Func Login($email, $pass)
    Go("/Identity/Account/Login")
    Sleep(1000)
    Send("^a")
    Send($email, 1)
    Send("{TAB}")
    Send($pass, 1)
    Send("{ENTER}")
    Sleep(2800)
EndFunc

Func Logout()
    Go("/Identity/Account/Logout")
    Sleep(700)
    Send("{ENTER}")
    Sleep(1200)
EndFunc

;----- Wait until user confirms app is running -----
While 1
    Local $ans = MsgBox($MB_YESNO + $MB_ICONQUESTION, "Staybnb — is the app running?", _
        "Is Visual Studio debugging (F5) on:" & @CRLF & @CRLF & _
        $Base & @CRLF & @CRLF & _
        "YES = start tests" & @CRLF & _
        "NO  = wait 90 seconds and ask again" & @CRLF & @CRLF & _
        "Esc stops the script anytime.")
    If $ans = $IDYES Then ExitLoop
    MsgBox($MB_ICONINFORMATION, "Waiting", "Waiting 90 seconds..." & @CRLF & "Press F5 in VS if you have not." & @CRLF & "Esc = stop", 5)
    Sleep(90000)
WEnd

MsgBox($MB_ICONINFORMATION, "Staybnb", "Starting navigation test in 3 seconds..." & @CRLF & "Esc = stop", 3)
Sleep(3000)

;----- Explore -----
Go("/Properties")

;----- SuperAdmin -----
Login("superadmin@staybnb.local", "SuperAdmin@123")
Go("/Admin")
Go("/Admin/Applications")
Go("/Admin/ActivityLogs")
Go("/Admin/Users")
Logout()

;----- Host -----
Login("host@staybnb.local", "Host@123456")
Go("/HostDashboard")
Go("/HostDashboard/MyProperties")
Go("/HostDashboard/BookingRequests")
Go("/CheckIn/HostQueue")
Go("/Messages/Inbox")
Go("/Notifications")
Logout()

;----- Guest -----
Login("guest@staybnb.local", "Guest@123456")
Go("/Properties")
Go("/Bookings/MyBookings")
Go("/HostApplications/Create")
Go("/HostApplications/Status")
Go("/Messages/Inbox")
Go("/Notifications")
Logout()

MsgBox($MB_ICONINFORMATION, "Done", _
    "Finished Admin + Host + Guest navigation." & @CRLF & @CRLF & _
    "Accounts:" & @CRLF & _
    "superadmin@staybnb.local / SuperAdmin@123" & @CRLF & _
    "host@staybnb.local / Host@123456" & @CRLF & _
    "guest@staybnb.local / Guest@123456")