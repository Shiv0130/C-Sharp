; Staybnb_Test_7180.au3  — app must already be running (F5)
#include <MsgBoxConstants.au3>

Global $Base = "https://localhost:7180"
Global $P = 1500

Func Go($path)
    ShellExecute($Base & $path)
    Sleep(2500)
EndFunc

MsgBox($MB_ICONINFORMATION, "Staybnb Test", _
    "Confirm VS is running on " & $Base & @CRLF & _
    "Accept certificate if browser asks." & @CRLF & "OK = start")

; 1 Explore
Go("/Properties")
MsgBox(0, "1 Explore", "Screenshot: gallery + Register/Login top right. OK")

; 2 Register page (no role picker)
Go("/Identity/Account/Register")
MsgBox(0, "2 Register", "Screenshot: Register form with NO role dropdown. OK")

; 3 Login SuperAdmin
Go("/Identity/Account/Login")
MsgBox(0, "3 Login", "MANUAL: login superadmin@staybnb.local / SuperAdmin@123 then OK")

Go("/Admin")
MsgBox(0, "4 Admin", "Screenshot: Admin dashboard stats. OK")

Go("/Admin/Applications")
MsgBox(0, "5 Host requests", "Screenshot: Host Requests list. OK")

Go("/Admin/ActivityLogs")
MsgBox(0, "6 Logs", "Screenshot: Activity logs. OK")

; 4 Host
Go("/Identity/Account/Login")
MsgBox(0, "7 Host login", "MANUAL: logout if needed, login host@staybnb.local / Host@123456 then OK")

Go("/HostDashboard")
MsgBox(0, "8 Host dash", "Screenshot: Welcome + 4 stat cards. OK")

Go("/HostDashboard/MyProperties")
MsgBox(0, "9 My properties", "Screenshot: property list. OK")

Go("/HostDashboard/BookingRequests")
MsgBox(0, "10 Bookings", "Screenshot: booking requests. OK")

; 5 Guest
Go("/Identity/Account/Login")
MsgBox(0, "11 Guest login", "MANUAL: login guest@staybnb.local / Guest@123456 then OK")

Go("/Properties")
MsgBox(0, "12 Guest explore", "Screenshot: Guest nav (Become a Host / My bookings). OK")

Go("/Bookings/MyBookings")
MsgBox(0, "13 My bookings", "Screenshot: bookings page. OK")

Go("/Messages/Inbox")
MsgBox(0, "14 Messages", "Screenshot: inbox. OK")

Go("/Notifications")
MsgBox(0, "15 Notifications", "Screenshot: notifications. OK")

MsgBox($MB_ICONINFORMATION, "Done", _
    "Manual still required for full marks:" & @CRLF & _
    "- Register NEW user (Guest only)" & @CRLF & _
    "- Become a Host + image" & @CRLF & _
    "- SuperAdmin Approve (role swap)" & @CRLF & _
    "- Guest book -> Host approve -> Check-in" & @CRLF & _
    "Filter optional — skip if broken.")