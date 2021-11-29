Class Func
    ' Public CountryName As String ' = GetSetupFields.
    ' Public CityName As String
    'Public Mesuar As String
    'Public Commission As String

    Public Function cCurrency() As String

        ' oCom.Connection = oCon
        'oCom.CommandText = "Select * from SettingInfo"
        Dim oCon As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.MerecConnectionString)
        oCon.Open()
        Dim oCom As New OleDb.OleDbCommand("Select * from SettingInfo", oCon)
        Dim da As New OleDb.OleDbDataAdapter(oCom)
        Dim ds As New DataSet

        da.Fill(ds)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        cCurrency = dr("RegionalCurrency")
        da = Nothing
        ds = Nothing
        oCon.Close()
        oCom = Nothing
        Return cCurrency

    End Function

    Public Function CountryName() As String

        ' oCom.Connection = oCon
        'oCom.CommandText = "Select * from SettingInfo"
        Dim oCon As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.MerecConnectionString)
        oCon.Open()
        Dim oCom As New OleDb.OleDbCommand("Select * from SettingInfo", oCon)
        Dim da As New OleDb.OleDbDataAdapter(oCom)
        Dim ds As New DataSet

        da.Fill(ds)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        CountryName = dr("RegionalListedCountry")
        da = Nothing
        ds = Nothing
        oCon.Close()
        oCom = Nothing
        Return CountryName

    End Function
    Public Function CityName() As String
        Dim oCon As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.MerecConnectionString)
        oCon.Open()
        Dim oCom As New OleDb.OleDbCommand("Select * from SettingInfo", oCon)
        Dim da As New OleDb.OleDbDataAdapter(oCom)
        Dim ds As New DataSet


        da.Fill(ds)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        CityName = dr("RegionalListedCity")
        da = Nothing
        ds = Nothing
        oCon.close()
        oCom = Nothing
        Return CityName

    End Function
    Public Function Mesuar() As String
        Dim oCon As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.MerecConnectionString)
        oCon.Open()
        Dim oCom As New OleDb.OleDbCommand("Select * from SettingInfo", oCon)
        Dim da As New OleDb.OleDbDataAdapter(oCom)
        Dim ds As New DataSet


        da.Fill(ds)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        Mesuar = dr("RegionalUnitFormats")
        da = Nothing
        ds = Nothing
        oCon.close()
        oCom = Nothing
        Return Mesuar

    End Function
    Public Function Commission() As String
        Dim oCon As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.MerecConnectionString)
        oCon.Open()
        Dim oCom As New OleDb.OleDbCommand("Select * from SettingInfo", oCon)
        Dim da As New OleDb.OleDbDataAdapter(oCom)
        Dim ds As New DataSet


        da.Fill(ds)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        Commission = dr("ServiceCommission")
        da = Nothing
        ds = Nothing
        oCon.close()
        oCom = Nothing
        Return Commission

    End Function
End Class
