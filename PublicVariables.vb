Imports System.Data.OleDb
Module PublicVariables
    '    Public AccessConnection As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\Database\Employee.mdb;")
    Public ProjectAdd As Boolean
    Public Logas As String
    Public ServerName As String
    Public AttachFrom As String
    Public CurrentDir As String = "C:\PropertyManager\" 'System.Environment.CurrentDirectory
    Public UserPass As String = ""
    Public UserName As String = ""
    Public uName As String = "estabase"
    Public uPass As String = "niazalam"
    Public LoginFrom As String = "Login"
    Public PID_no As Integer
    Public MapUrl As String
    Public OverWriteFrom As Integer
    Public CompanyID As Integer
    Public defaultCountry, defaultCity, defaultCurrency As String
    'Connection
    Public Excelpath As String '= "C:\PropertyManager\Database\Test.xls"
    Public PathUnits As String '= "C:\PropertyManager\Database\Units.xls"
    Public PathLand As String '= "C:\PropertyManager\Database\Land.xls"
    Public PathRent As String '= "C:\PropertyManager\Database\Rent.xls"
    Public PathOther As String ' = "C:\PropertyManager\Database\Other.xls"
    Public Con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= C:\PropertyManager\database\merec.mdb")

    Public ExcelConUnits As String = "provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathUnits & " '; " & "Extended Properties=Excel 8.0;"
    Public ExcelConRent As String = "provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathRent & " '; " & "Extended Properties=Excel 8.0;"
    Public ExcelConLand As String = "provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathLand & " '; " & "Extended Properties=Excel 8.0;"
    Public ExcelConOther As String = "provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathOther & " '; " & "Extended Properties=Excel 8.0;"
    Public AccessCon As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\PropertyManager\database\merec.mdb"

    Public OwM As String = "No"

End Module