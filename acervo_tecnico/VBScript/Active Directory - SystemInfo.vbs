Option Explicit
On Error Resume Next

Dim objSysInfo
Set objSysInfo = CreateObject("ADSystemInfo")

Dim objUser
Set objUser = GetObject("LDAP://" & objSysInfo.UserName)

Dim Usuario
Dim EmployeeID
Dim Nome
Dim Sobrenome
Dim NomeCompleto
Dim Cidade
Dim Empresa
Dim Setor
Dim Email
Dim Telefone

Usuario = objUser.sAMAccountName
EmployeeID = objUser.EmployeeID
Nome = objUser.givenName
Sobrenome = objUser.sn
NomeCompleto = objUser.displayName
Cidade = objUser.l
Empresa = objUser.company
Setor = objUser.department
Email = objUser.mail
Telefone = objUser.telephoneNumber

' WScript.Echo Usuario
' WScript.Echo EmployeeID
' WScript.Echo Nome
' WScript.Echo Sobrenome
' WScript.Echo NomeCompleto
' WScript.Echo Cidade
' WScript.Echo Empresa
' WScript.Echo Setor
' WScript.Echo Email
' WScript.Echo Telefone

Dim Teste
Teste = objUser.PasswordNeverExpires
WScript.Echo "-> " & Teste & " <-"

' -----------------------------------------------------------------------------

Dim objSysInfo, objUser
Set objSysInfo = CreateObject("ADSystemInfo")

' Currently logged in User
Set objUser = GetObject("LDAP://" & objSysInfo.UserName)
 ' or specific user:
 'Set objUser = GetObject("LDAP://CN=johndoe,OU=Users,DC=ss64,DC=com")

WScript.Echo "DN: " & objUser.distinguishedName

WScript.Echo ""
WScript.Echo "GENERAL"
WScript.Echo "First name: " & objUser.givenName
'WScript.Echo "First name: " & objUser.FirstName
WScript.Echo "Initials: " & objUser.initials
WScript.Echo "Last name: " & objUser.sn
'WScript.Echo "Last name: " & objUser.LastName
WScript.Echo "Display name: " & objUser.displayName
'WScript.Echo "Display name: " & objUser.FullName
WScript.Echo "Description: " & objUser.description
WScript.Echo "Office: " & objUser.physicalDeliveryOfficeName
WScript.Echo "Telephone number: " & objUser.telephoneNumber
WScript.Echo "Other Telephone numbers: " & objUser.otherTelephone
WScript.Echo "Email: " & objUser.mail
' WScript.Echo "Email: " & objUser.EmailAddress
WScript.Echo "Web page: " & objUser.wWWHomePage
WScript.Echo "Other Web pages: " & objUser.url
WScript.Echo ""
WScript.Echo "ADDRESS"
WScript.Echo "Street: " & objUser.streetAddress
WScript.Echo "P.O. Box: " & objUser.postOfficeBox
WScript.Echo "City: " & objUser.l
WScript.Echo "State/province: " & objUser.st
WScript.Echo "Zip/Postal Code: " & objUser.postalCode
WScript.Echo "Country/region: " & objUser.countryCode
'WScript.Echo "Country/region: " & objUser.c    '(ISO 4217)
WScript.Echo ""
WScript.Echo "ACCOUNT"
WScript.Echo "User logon name: " & objUser.userPrincipalName
WScript.Echo "pre-Windows 2000 logon name: " & objUser.sAMAccountName
WScript.Echo "AccountDisabled: " & objUser.AccountDisabled
' WScript.Echo "Account Control #: " & objUser.userAccountControl
WScript.Echo "Logon Hours: " & objUser.logonHours
WScript.Echo "Logon On To (Logon Workstations): " & objUser.userWorkstations
' WScript.Echo "User must change password at next logon: " & objUser.pwdLastSet
WScript.Echo "User cannot change password: " & objUser.userAccountControl
WScript.Echo "Password never expires: " & objUser.userAccountControl
WScript.Echo "Store password using reversible encryption: " & objUser.userAccountControl
' WScript.Echo "Account expires end of (date): " & objUser.accountExpires
WScript.Echo ""
WScript.Echo "PROFILE"
WScript.Echo "Profile path: " & objUser.profilePath
' WScript.Echo "Profile path: " & objUser.Profile
WScript.Echo "Logon script: " & objUser.scriptPath
WScript.Echo "Home folder, local path: " & objUser.homeDirectory
WScript.Echo "Home folder, Connect, Drive: " & objUser.homeDrive
WScript.Echo "Home folder, Connect, To:: " & objUser.homeDirectory
WScript.Echo ""
WScript.Echo "TELEPHONE"
WScript.Echo "Home: " & objUser.homePhone
WScript.Echo "Other Home phone numbers: " & objUser.otherHomePhone
WScript.Echo "Pager: " & objUser.pager
WScript.Echo "Other Pager numbers: " & objUser.otherPager
WScript.Echo "Mobile: " & objUser.mobile
WScript.Echo "Other Mobile numbers: " & objUser.otherMobile
WScript.Echo "Fax: " & objUser.facsimileTelephoneNumber
WScript.Echo "Other Fax numbers: " & objUser.otherFacsimileTelephoneNumber
WScript.Echo "IP phone: " & objUser.ipPhone
WScript.Echo "Other IP phone numbers: " & objUser.otherIpPhone
WScript.Echo "Notes: " & objUser.info
WScript.Echo ""
WScript.Echo "ORGANISATION"
WScript.Echo "Title: " & objUser.title
WScript.Echo "Department: " & objUser.department
WScript.Echo "Company: " & objUser.company
WScript.Echo "Manager: " & objUser.manager
