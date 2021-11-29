Imports System
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Media
Public Class DesktopWork

    'Start - UnitsTable

    Public Function UnitsToExcel(ByVal path As String) As String

        Dim path2 As String
        Try
            Dim excel As New Excel.Application()

            Dim wb As Excel.Workbook
            If UnitsToSell.SFD.ShowDialog() = DialogResult.OK Then
                path2 = (UnitsToSell.SFD.FileName.ToString())

                wb = excel.Application.Workbooks.Add() ' Open(path) ' .Add(True)
            Else
                Return 0
                Exit Function
            End If
            Dim ws As Excel.Worksheet = wb.Sheets("Sheet1")
            ws.Range("A1:AX1").Font.Bold = True
            ws.Range("A1:AX1").Font.Size = 12

            Dim colIndex, rowIndex As Integer
            rowIndex = 0
            Dim col As DataColumn
            For Each col In GetDataUnits.Columns

                colIndex += 1
                ws.Cells(1, colIndex) = col.ColumnName.ToString
            Next col
            ws.Columns.AutoFit()
            Dim row As DataRow
            excel.Visible = False
            ProgressData.ListBox1.Items.Add("Please Wait...")
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = GetDataUnits.Rows.Count
            ProgressData.Label1.Text = " Exporting data to excel..."
            ProgressData.Show()
            rowIndex = 1
            ProgressData.ListBox1.Items.Add("Exporting to Excel File...")
            For Each row In GetDataUnits.Rows
                My.Application.DoEvents()

                colIndex = 0
                ProgressData.ProgressBar1.Value = rowIndex
                rowIndex += 1
                For Each col In GetDataUnits.Columns
                    My.Application.DoEvents()

                    colIndex += 1
                    ws.Cells(rowIndex, colIndex) = row(col.ColumnName).ToString()

                Next col
            Next row
            ProgressData.ListBox1.Items.Add("Finish")
            ProgressData.Close()
            excel.Visible = True
            wb.SaveAs(path2, 56) ' ' & ".xls")

            wb.Close()


            excel = Nothing

            ProgressData.Close()
            excel = Nothing

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Ms Excel could not be detected on your computer. please install MS Excel and try again.", "Excel error", MessageBoxButtons.OK)

        End Try
        Return 0
    End Function


    Private Function GetDataUnits() As System.Data.DataTable
        Dim conn As New OleDbConnection(AccessCon)
        Dim adapter As New OleDbDataAdapter("select * from UnitsTable", conn) '
        Dim myDataSet As New DataSet
        Try
            adapter.Fill(myDataSet, "UnitsTable")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Error: Connection Fail with Access Database!", "Connection Fail", MessageBoxButtons.OK)

            'MessageBox.Show(ex.ToString())
        End Try
        Return myDataSet.Tables(0)
    End Function

    Sub UnitsToAccess(ByVal PrmPathExcelFile As String)
        ' On Error Resume Next
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel


            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathUnits & " '; " & "Extended Properties='Excel 8.0; IMEX=1;'") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "UnitsTable")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet, "UnitsTable")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim SearchMax As New OleDbCommand("select max([property id]) from [Sheet1$]", MyConnection)
            Dim maxID As Integer = SearchMax.ExecuteScalar()
            Dim propID As Integer

            Dim Con As New OleDb.OleDbConnection(AccessCon)
            Con.Open()
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            ' Dim yn As String
            Dim i As Integer
            If OwM = "Over" Then
                SelectCmd.CommandText = "Delete from unitstable"
                SelectCmd.Connection = Con
                SelectCmd.ExecuteNonQuery()
            ElseIf OwM = "Add" Then
                SelectCmd.CommandText = "select max([Property ID]) from unitstable"
                SelectCmd.Connection = Con
                ro = SelectCmd.ExecuteScalar
                If CStr(SelectCmd.ExecuteScalar) = "" Then 'vbNull Then
                    i = 1
                Else
                    i = SelectCmd.ExecuteScalar
                End If

            Else
            Exit Sub
            End If


            Dim newRows As DataRow
            Dim totRows As Integer = DtSet.Tables("UnitsTable").Rows.Count

            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Please Wait...")
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = totRows
            Dim proj As String = "NA"
            Dim ProjId As Integer
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Importing data to Database...")
            For Each newRows In DtSet.Tables("UnitsTable").Rows
                My.Application.DoEvents()
                ro = ro + 1
                ProgressData.ProgressBar1.Value = ro
                If i < 1 Then i = 1

                If newRows("Community/Project").ToString.Length > 0 Then


                    Dim cm As New OleDbCommand("Select [Project ID] from projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)
                    Dim int As Integer = cm.ExecuteScalar + 0
                    If cm.ExecuteScalar > 0 Then
                        ProjId = cm.ExecuteScalar()
                        proj = newRows("Community/Project").ToString
                        cm.Dispose()
                    Else
                        My.Application.DoEvents()
                        Dim cm1 As New OleDbCommand("insert into projects([Project Name], ProjectType) values('" & newRows("Community/Project").ToString.Trim & "','Units')", Con)
                        cm1.ExecuteNonQuery()
                        cm1.Dispose()

                        Dim cm3 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)

                        If cm3.ExecuteScalar > 0 Then
                            ProjId = cm3.ExecuteScalar
                            proj = newRows("Community/Project").ToString

                        End If
                        cm3.Dispose()
                        cm1.Dispose()
                    End If

                ElseIf IsDBNull(newRows("Community/Project")) = True And IsDBNull(newRows("Block/Building")) = False Then

                    Dim cm44 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Block/Building").ToString.Trim & "'", Con)
                    If cm44.ExecuteScalar > 0 Then
                        ProjId = cm44.ExecuteScalar
                        proj = newRows("Block/Building").ToString
                    Else
                        My.Application.DoEvents()
                        Dim cm11 As New OleDbCommand("insert into projects([Project Name], ProjectType) values('" & newRows("Block/Building").ToString.Trim & "','Units')", Con)
                        cm11.ExecuteNonQuery()
                        cm11.Dispose()

                        Dim cm31 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)
                        If cm31.ExecuteScalar > 0 Then
                            ProjId = cm31.ExecuteScalar
                            proj = newRows("Block/Building").ToString

                        End If
                        cm31.Dispose()
                        cm44.Dispose()
                        cm11.Dispose()
                    End If
                Else
                    ProjId = 0
                    proj = ""
                End If

                If newRows("Property ID").ToString.Length > 0 And maxID > 10000000 Then
                    propID = newRows("Property ID")
                Else
                    maxID = 10000000
                    propID = maxID + ro
                End If


                My.Application.DoEvents()
                Dim Sql As String = "insert into UnitsTable ([Project ID],[Property ID], [User ID],[Master Project], [Community/project], [Property Type], [Block/Building] " _
                                & ", [Phase],[Address], [Country], [City], [Unit No], [Unit Type], [No of Bedrooms], [floor],[view], [Area], [Land Area] " _
                                & ", [SqrFt/SqrMt],[Balcony],[Original Price], [Selling Price], [Currency], [Status],[Completion Date],[Entered By]" _
                                & ", [agent/seller], [Name of Source],[Contact No], [Email], [Updated Date],[Entered Date],[Publish Notes],[Hidden Notes], [Main Image] " _
                                & ", [Extra Image1], [Extra Image2], [Extra Image3], [Property Map])  values (" & ProjId & "," & propID & "," & i + ro & ",'" & newRows("Master Project").ToString & "','" & proj & "','" _
                                & newRows("Property Type").ToString & "','" & newRows("Block/Building").ToString & "','" & newRows("Phase").ToString & "','" & newRows("Address").ToString & "','" & newRows("Country").ToString & "','" & newRows("City").ToString & "','" & _
                                 newRows("Unit No").ToString & "','" & newRows("Unit Type").ToString & "','" & newRows("No of bedrooms").ToString & "','" & newRows("Floor").ToString & "','" & newRows("View").ToString & "','" & newRows("Area").ToString & "','" & newRows("Land Area") & "','" & _
                                 newRows("sqrft/sqrmt").ToString & "','" & newRows("Balcony").ToString & "','" & newRows("Original Price").ToString & "','" & newRows("Selling Price").ToString & "','" & newRows("currency").ToString & "','" & _
                                 newRows("status").ToString & "','" & newRows("Completion Date").ToString & "','" & newRows("Entered By").ToString & "','" & newRows("Agent/Seller").ToString & "','" & newRows("Name Of Source").ToString & "','" & _
                                 newRows("Contact No").ToString & "','" & newRows("Email").ToString & "','" & Now.Date.ToShortDateString & "','" & Now.Date.ToShortDateString & "','" & newRows("Publish Notes").ToString & "','" & newRows("Hidden Notes").ToString & "','" & newRows("Main Image").ToString & "','" & _
                                 newRows("Extra Image1") & "','" & newRows("Extra Image2").ToString & "','" & newRows("Extra Image3").ToString & "','" & MapUrl & "')"

                Dim cmd As New OleDbCommand(Sql, Con)
                cmd.ExecuteNonQuery()

            Next
            Con.Close()
            SelectCmd = Nothing
            UnitsToSell.UnitsTableTableAdapter.Fill(UnitsToSell.MerecDataSet.UnitsTable)
            newRows = Nothing

            MyConnection.Close()
            OwM = "No"
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Finish")

        Catch ex As Exception
            MessageBox.Show("The excel sheet you have selected does not have the proper file format, for details click Ok button?", "Format message", MessageBoxButtons.OKCancel)
            'MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Public Function UnitsFormat() As Integer
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        ProgressData.Show()

        Try

            ''''''' Fetch Data from Excel

            My.Application.DoEvents()
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathUnits & " '; " & "Extended Properties=Excel 8.0;") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Units")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim Con As New OleDb.OleDbConnection(AccessCon)
            Con.Open()
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            ' Dim yn As String
            Dim i As Integer
            'yn = System.Windows.Forms.MessageBox.Show("Do you want to over write all property Records?", "MEREC", MessageBoxButtons.YesNo)

            SelectCmd.CommandText = "Select top 2 * from unitsTable"
            SelectCmd.Connection = Con

            Dim adapT As New OleDbDataAdapter
            adapT.SelectCommand = SelectCmd

            Dim ds As New DataSet
            Dim commandBuilder As New OleDb.OleDbCommandBuilder(adapT)
            adapT.Fill(ds)

            Dim newRows As DataRow
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Please Wait...")
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Checking Proper Format of Excel ...")
            newRows = DtSet.Tables(0).Rows(1)
            For ro = 0 To 1
                ro = ro + 1
                If i < 1 Then i = 1
                My.Application.DoEvents()
                newRows("Project ID").ToString()
                newRows("Publish Status").ToString()
                newRows("Master Project").ToString()
                newRows("community/Project").ToString()
                newRows("Property Type").ToString()
                newRows("Block/Building").ToString()
                newRows("Phase").ToString()
                newRows("Address").ToString()
                newRows("Country").ToString()
                newRows("City").ToString()
                newRows("Unit No").ToString()
                newRows("Unit Type").ToString()
                newRows("No of bedrooms").ToString()
                newRows("Floor").ToString()
                newRows("view").ToString()
                newRows("Area").ToString()
                newRows("Land Area").ToString()
                newRows("sqrft/sqrmt").ToString()
                newRows("Balcony").ToString()
                newRows("Original Price").ToString()
                newRows("Selling Price").ToString()
                newRows("Currency").ToString()
                newRows("Status").ToString()
                newRows("Completion Date").ToString()
                newRows("Entered By").ToString()
                newRows("Agent/Seller").ToString()
                newRows("Name Of Source").ToString()
                newRows("Contact No").ToString()
                newRows("Email").ToString()
                newRows("Entered Date").ToString()
                newRows("Publish Notes").ToString()
                newRows("Hidden Notes").ToString()
                newRows("Main Image").ToString()
                newRows("Extra image1").ToString()
                newRows("Extra image2").ToString()
                newRows("Extra image3").ToString()
                newRows("Property Map").ToString()

            Next
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Finish...")
            adapT.Update(ds)
            ds.AcceptChanges()
            Con.Close()
            SelectCmd = Nothing
            adapT = Nothing
            ds = Nothing
            newRows = Nothing

            'UnitsToSell.RecStatus.Text = "Status: " & ro & " Worksheet is in proper format."
            MyConnection.Close()
            OwM = "No"


            Return 1

        Catch ex As Exception
            'System.Windows.Forms.MessageBox.Show(ex.ToString)
            MessageBox.Show("The excel sheet you have selected does not have the proper format, for details click Ok button?", "Format message", MessageBoxButtons.OKCancel)
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Incurrect Format...")
            Return 0
        End Try
    End Function

    'End - UnitsTable




    'Start - Land
    Private Function GetDataLand() As System.Data.DataTable

        Dim conn As New OleDbConnection(AccessCon)
        Dim adapter As New OleDbDataAdapter("select * from LandTable", conn) '
        Dim myDataSet As New DataSet
        Try
            adapter.Fill(myDataSet, "LandTable")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Error: Connection Fail with Access Database!", "Connection Fail", MessageBoxButtons.OK)

            ' MessageBox.Show(ex.ToString())
        End Try
        Return myDataSet.Tables(0)
    End Function
    Public Function LandToExcel(ByVal path As String) As String

        'On Error Resume Next
        Dim path2 As String
        Try
            Dim excel As New Excel.Application()
            Dim wb As Excel.Workbook
            If LandToSell.SFD.ShowDialog() = DialogResult.OK Then

                path2 = (LandToSell.SFD.FileName.ToString())

                wb = excel.Application.Workbooks.Add() ' Open(path) ' .Add(True)
            Else
                Return 0
                Exit Function
            End If
            Dim ws As Excel.Worksheet = wb.Sheets("Sheet1")

            excel.Visible = False
            'remove rows
            ws.Range("A1:A10000").EntireRow.Delete()

            'end remove rows
            ws.Range("A1:AX1").Font.Bold = True
            ws.Range("A1:AX1").Font.Size = 12

            Dim colIndex, rowIndex As Integer
            rowIndex = 0
            Dim col As DataColumn
            For Each col In GetDataLand.Columns
                colIndex += 1
                ws.Cells(1, colIndex) = col.ColumnName.ToString
            Next col
            ws.Columns.AutoFit()
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = GetDataLand.Rows.Count
            ProgressData.Label1.Text = " Exporting data to excel..."
            ProgressData.Show()
            Dim row As DataRow
            rowIndex = 1
            For Each row In GetDataLand.Rows

                colIndex = 0
                ProgressData.ProgressBar1.Value = rowIndex
                rowIndex += 1
                For Each col In GetDataLand.Columns
                    colIndex += 1
                    ws.Cells(rowIndex, colIndex) = row(col.ColumnName).ToString()

                Next col
            Next row
            ProgressData.Close()
            excel.Visible = True
            wb.SaveAs(path2, 56) ' ' & ".xls")

            wb.Close()
            excel = Nothing

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Ms Excel could not be detected on your computer. please install MS Excel and try again.", "Excel error", MessageBoxButtons.OK)
            'MessageBox.Show(ex.ToString)
        End Try

        Return 0
    End Function





    Sub LandToAccess(ByVal PrmPathExcelFile As String)
        'On Error Resume Next
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel

            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathLand & " '; " & "Extended Properties='Excel 8.0; IMEX=1;'") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "LandTable")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim SearchMax As New OleDbCommand("select max([property id]) from [Sheet1$]", MyConnection)
            Dim maxID As Integer = SearchMax.ExecuteScalar()
            Dim propID As Integer
            'ACCESS TO EXCEL

            Dim Con As New OleDb.OleDbConnection(AccessCon)
            Con.Open()
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            ' Dim yn As String
            Dim i As Integer

            If OwM = "Over" Then
                SelectCmd.CommandText = "Delete from landtable"
                SelectCmd.Connection = Con
                SelectCmd.ExecuteNonQuery()
            ElseIf OwM = "Add" Then
                SelectCmd.CommandText = "select max([Property ID]) from landtable"
                SelectCmd.Connection = Con
                'ro = SelectCmd.ExecuteScalar
                If SelectCmd.ExecuteScalar = vbNull Then
                    i = 1
                Else
                    i = SelectCmd.ExecuteScalar
                End If

            Else
                Exit Sub
            End If

            
            SelectCmd.CommandText = "Select * from landTable"
            SelectCmd.Connection = Con

            Dim adapT As New OleDbDataAdapter
            adapT.SelectCommand = SelectCmd

            Dim ds As New DataSet
            'Dim commandBuilder As New OleDb.OleDbCommandBuilder(adapT)
            adapT.Fill(ds)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow = dt.NewRow
            Dim newRows As DataRow
            Dim totRows As Integer = DtSet.Tables(0).Rows.Count
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = totRows

            For Each newRows In DtSet.Tables(0).Rows
                ro = ro + 1
                ProgressData.ProgressBar1.Value = ro
                Dim ProjId As Integer
                Dim proj As String

                If newRows("Community/Project").ToString.Length > 0 Then


                    Dim cm As New OleDbCommand("Select [Project ID] from projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)
                    Dim int As Integer = cm.ExecuteScalar + 0
                    'Checking Projects

                    If cm.ExecuteScalar > 0 Then
                        ProjId = cm.ExecuteScalar()
                        proj = newRows("Community/Project").ToString
                        'End If
                        cm.Dispose()
                    Else
                        My.Application.DoEvents()
                        Dim cm1 As New OleDbCommand("insert into projects([Project Name], ProjectType) values('" & newRows("Community/Project").ToString.Trim & "','Land')", Con)
                        cm1.ExecuteNonQuery()
                        cm1.Dispose()

                        Dim cm3 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)

                        If cm3.ExecuteScalar > 0 Then
                            ProjId = cm3.ExecuteScalar
                            proj = newRows("Community/Project").ToString

                        End If
                        cm3.Dispose()
                        cm1.Dispose()
                    End If

                ElseIf IsDBNull(newRows("Community/Project")) = True Then
                    ProjId = 0
                    proj = ""
                End If
                'End Checking Projects
                If newRows("Property ID").ToString.Length > 0 And maxID > 10000000 Then
                    propID = newRows("Property ID")
                Else
                    maxID = 10000000
                    propID = maxID + ro
                End If

                My.Application.DoEvents()
                Dim Sql As String = "insert into LandTable ([Project ID],[Property ID], [User ID],[Master Project], [Community/project], [Property Type] " _
                                & ", [Phase],[Address], [Country], [City], [Parcel No],  [Land Size], [Allowed Height],[Allowed Builtup Area] " _
                                & ", [SqrFt/SqrMt],[Far],[Original Price], [Selling Price], [Currency],[Entered By]" _
                                & ", [agent/seller], [Name of Source],[Contact No], [Email], [Updated Date],[Entered Date],[Publish Notes],[Hidden Notes], [Main Image] " _
                                & ", [Extra Image1], [Extra Image2], [Extra Image3], [Property Map])  values (" & ProjId & "," & propID & "," & i + ro & ",'" & newRows("Master Project").ToString & "','" & proj & "','" _
                                & newRows("Property Type").ToString & "','" & newRows("Phase").ToString & "','" & newRows("Address").ToString & "','" & newRows("Country").ToString & "','" & newRows("City").ToString & "','" & _
                                 newRows("Parcel No").ToString & "','" & newRows("Land Size").ToString & "','" & newRows("Allowed Height") & "','" & newRows("Allowed Builtup Area") & "','" & _
                                 newRows("sqrft/sqrmt").ToString & "','" & newRows("Far").ToString & "','" & newRows("Original Price").ToString & "','" & newRows("Selling Price").ToString & "','" & newRows("currency").ToString & "','" & _
                                  newRows("Entered By").ToString & "','" & newRows("Agent/Seller").ToString & "','" & newRows("Name Of Source").ToString & "','" & _
                                 newRows("Contact No").ToString & "','" & newRows("Email").ToString & "','" & Now.Date.ToShortDateString & "','" & Now.Date.ToShortDateString & "','" & newRows("Publish Notes").ToString & "','" & newRows("Hidden Notes").ToString & "','" & newRows("Main Image").ToString & "','" & _
                                 newRows("Extra Image1") & "','" & newRows("Extra Image2").ToString & "','" & newRows("Extra Image3").ToString & "','" & MapUrl & "')"

                Dim cmd As New OleDbCommand(Sql, Con)
                cmd.ExecuteNonQuery()

                
                
               
                
            Next

            Con.Close()
            SelectCmd = Nothing
            adapT = Nothing
            dt = Nothing
            ds = Nothing
            'dr = Nothing
            newRows = Nothing
            LandToSell.LandTableTableAdapter.Fill(LandToSell.MerecDataSet.LandTable)

            MyConnection.Close()

        Catch ex As Exception
            MessageBox.Show("The excel sheet you have selected does not have the proper format, for details click Ok button?", "Format message", MessageBoxButtons.OKCancel)
            ' MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function LandFormat() As Integer
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel


            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathLand & " '; " & "Extended Properties=Excel 8.0;") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Land")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'MessageBox.Show(PathLand)
            Dim Con As New OleDb.OleDbConnection(AccessCon)
            Con.Open()
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            ' Dim yn As String
            Dim i As Integer

            SelectCmd.CommandText = "Select * from LandTable"
            SelectCmd.Connection = Con

            Dim adapT As New OleDbDataAdapter
            adapT.SelectCommand = SelectCmd

            Dim ds As New DataSet
            Dim commandBuilder As New OleDb.OleDbCommandBuilder(adapT)
            adapT.Fill(ds)

            Dim dr As DataRow

            dr = DtSet.Tables(0).Rows(0)
            For ro = 0 To 1
                ro = ro + 1
                If i < 1 Then i = 1
                dr("User ID").ToString()
                dr("Property Id").ToString()
                dr("Project ID").ToString()
                dr("Publish Status").ToString()
                dr("Master Project").ToString()
                dr("Community/Project").ToString()
                dr("Property Type").ToString()
                dr("Phase").ToString()
                dr("Address").ToString()
                dr("Country").ToString()
                dr("City").ToString()
                dr("Parcel No").ToString()
                dr("Land Size").ToString()
                dr("Allowed Height").ToString()
                dr("Allowed Builtup Area").ToString()
                dr("SqrFt/sqrmt").ToString()
                dr("Far").ToString()
                dr("Selling Price").ToString()
                dr("Original Price").ToString()
                dr("Currency").ToString()
                dr("Entered By").ToString()
                dr("Agent/Seller").ToString()
                dr("Name Of Source").ToString()
                dr("Contact No").ToString()
                dr("Email").ToString()
                dr("Updated DAte").ToString()
                dr("Entered Date").ToString()
                dr("Publish Notes").ToString()
                dr("Hidden Notes").ToString()
                dr("Main Image").ToString()
                dr("Extra Image1").ToString()
                dr("Extra Image2").ToString()
                dr("Extra Image3").ToString()
                dr("sentEmail").ToString()
                dr("Property Map").ToString()
            Next
            adapT.Update(ds)
            ds.AcceptChanges()
            Con.Close()
            SelectCmd = Nothing
            adapT = Nothing
            ds = Nothing
            dr = Nothing

            MyConnection.Close()
            OwM = "No"


            Return 1

        Catch ex As Exception
            MessageBox.Show("The excel sheet you have selected does not have the proper format, for details click Ok button?", "Format message", MessageBoxButtons.OKCancel)
            MessageBox.Show(ex.ToString)
            Return 0
        End Try
    End Function
    'End - Land





    'Start - OtherTable
    Private Function GetDataOther() As System.Data.DataTable
        Dim conn As New OleDbConnection(AccessCon)
        Dim adapter As New OleDbDataAdapter("select * from othertable", conn) '
        Dim myDataSet As New DataSet
        Try
            adapter.Fill(myDataSet, "OtherTable")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Error: Connection Fail with Access Database!", "Connection Fail", MessageBoxButtons.OK)

            '  MessageBox.Show(ex.ToString())
        End Try
        Return myDataSet.Tables(0)
    End Function
    Public Function OtherToExcel(ByVal path As String) As String
        'On Error Resume Next
        Dim path2 As String
        Dim excel As New Excel.Application()



        Try

            Dim wb As Excel.Workbook
            If OthersToSell.SFD.ShowDialog() = DialogResult.OK Then
                path2 = (OthersToSell.SFD.FileName.ToString())
                wb = excel.Application.Workbooks.Add() ' Open(path) ' .Add(True)
            Else
                Return 0
                Exit Function
            End If
            Dim ws As Excel.Worksheet = wb.Sheets("Sheet1")

            ws.Range("A1:A10000").EntireRow.Delete()

            ws.Range("A1:AX1").Font.Bold = True
            ws.Range("A1:AX1").Font.Size = 12



            Dim colIndex, rowIndex As Integer
            rowIndex = 0
            Dim col As DataColumn
            For Each col In GetDataOther.Columns
                colIndex += 1
                ws.Cells(1, colIndex) = col.ColumnName.ToString

            Next col
            ws.Columns.AutoFit()
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = GetDataOther.Rows.Count
            ProgressData.Label1.Text = " Exporting data to excel..."
            ProgressData.Show()
            Dim row As DataRow
            rowIndex = 1
            For Each row In GetDataOther.Rows

                colIndex = 0
                ProgressData.ProgressBar1.Value = rowIndex
                rowIndex += 1
                For Each col In GetDataOther.Columns
                    colIndex += 1
                    ws.Cells(rowIndex, colIndex) = row(col.ColumnName).ToString()

                Next col
            Next row
            ProgressData.Close()
            excel.Visible = True
            wb.SaveAs(path2, 56) ' ' & ".xls")

            wb.Close()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Ms Excel could not be detected on your computer. please install MS Excel and try again.", "Excel error", MessageBoxButtons.OK)
        End Try
        excel = Nothing
        Return 0
    End Function


    Public Function OtherFormat() As Integer
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel


            Dim DtSet As DataSet
            Dim MyCommand As OleDbDataAdapter
            MyConnection = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathOther & " '; " & "Extended Properties=Excel 8.0;") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Other")
            DtSet = New DataSet
            MyCommand.Fill(DtSet)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim Con As New OleDbConnection(AccessCon)
            Con.Open()
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            Dim i As Integer

            SelectCmd.CommandText = "Select * from OtherTable"
            SelectCmd.Connection = Con

            Dim adapT As New OleDbDataAdapter
            adapT.SelectCommand = SelectCmd

            Dim ds As New DataSet
            'Dim commandBuilder As New OleDb.OleDbCommandBuilder(adapT)
            adapT.Fill(ds)

            Dim dr As DataRow

            dr = DtSet.Tables(0).Rows(0)
            For ro = 0 To 1
                ro = ro + 1
                If i < 1 Then i = 1
                dr("User ID").ToString()
                dr("Property Id").ToString()
                dr("Publish Status").ToString()
                dr("Property Type").ToString()
                dr("Address").ToString()
                dr("Country").ToString()
                dr("City").ToString()
                dr("Entered By").ToString()
                dr("Agent/Seller").ToString()
                dr("Name Of Source").ToString()
                dr("Contact No").ToString()
                dr("Email").ToString()
                dr("Updated DAte").ToString()
                dr("Entered Date").ToString()
                dr("Publish Notes").ToString()
                dr("Hidden Notes").ToString()
                dr("Main Image").ToString()
                dr("Extra Image1").ToString()
                dr("Extra Image2").ToString()
                dr("Extra Image3").ToString()
                dr("sentEmail").ToString()
                dr("Property Map").ToString()

                ' newRows("mapdata").ToString()
            Next
            adapT.Update(ds)
            ds.AcceptChanges()
            Con.Close()
            SelectCmd = Nothing
            adapT = Nothing
            ds = Nothing
            dr = Nothing

            MyConnection.Close()
            OwM = "No"


            Return 1

        Catch ex As Exception
            ' System.Windows.Forms.MessageBox.Show(ex.ToString)
            MessageBox.Show("The excel sheet you have selected does not have the proper file format, do you need help?", "Format message", MessageBoxButtons.YesNo)
            Return 0
        End Try
    End Function


    Sub OtherToAccess(ByVal PrmPathExcelFile As String)

        ' On Error Resume Next
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel

            ProgressData.Show()
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathOther & " '; " & "Extended Properties='Excel 8.0; IMEX=1;'") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "OtherTable")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet, "OtherTable")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim SearchMax As New OleDbCommand("select max([property id]) from [Sheet1$]", MyConnection)
            Dim maxID As Integer = SearchMax.ExecuteScalar()
            Dim propID As Integer

            Dim Con As New OleDb.OleDbConnection(AccessCon)
            Con.Open()
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            ' Dim yn As String
            Dim i As Integer
            'yn = System.Windows.Forms.MessageBox.Show("Do you want to over write all property Records?", "MEREC", MessageBoxButtons.YesNo)
            If OwM = "Over" Then
                SelectCmd.CommandText = "Delete from OtherTable"
                SelectCmd.Connection = Con
                SelectCmd.ExecuteNonQuery()
            ElseIf OwM = "Add" Then
                SelectCmd.CommandText = "select max([Property ID]) from OtherTable"
                SelectCmd.Connection = Con
                'ro = SelectCmd.ExecuteScalar
                If CStr(SelectCmd.ExecuteScalar) = "" Then 'vbNull Then
                    i = 1
                Else
                    i = SelectCmd.ExecuteScalar
                End If
            Else
                Exit Sub
            End If


            Dim newRows As DataRow
            Dim totRows As Integer = DtSet.Tables("OtherTable").Rows.Count

            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Please Wait...")
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = totRows
            Dim proj As String = "NA"
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Importing data to Database...")

            For Each newRows In DtSet.Tables("OtherTable").Rows
                My.Application.DoEvents()
                ro = ro + 1
                ProgressData.ProgressBar1.Value = ro
                If i < 1 Then i = 1

                My.Application.DoEvents()
                If newRows("Property ID").ToString.Length > 0 And maxID > 10000000 Then
                    propID = newRows("Property ID")
                Else
                    maxID = 10000000
                    propID = maxID + ro
                End If
                Dim Sql As String = "insert into OtherTable ( [Property ID], [User ID], [Property Type] " _
                                & ", [Address], [Country], [City]" & ", [Entered By]" _
                                & ", [agent/seller], [Name of Source], [Contact No], [Email], [Updated Date],[Entered Date],[Publish Notes],[Hidden Notes], [Main Image] " _
                                & ", [Extra Image1], [Extra Image2], [Extra Image3], [Property Map])  values (" & PropID & "," & i + ro & ",'" _
                                & newRows("Property Type").ToString & "','" & newRows("Address").ToString & "','" & newRows("Country").ToString & "','" & newRows("City").ToString & "','" & _
                                 newRows("Entered By").ToString & "','" & newRows("Agent/Seller").ToString & "','" & newRows("Name Of Source").ToString & "','" & _
                                 newRows("Contact No").ToString & "','" & newRows("Email").ToString & "','" & Now.Date.ToShortDateString & "','" & Now.Date.ToShortDateString & "','" & newRows("Publish Notes").ToString & "','" & newRows("Hidden Notes").ToString & "','" & newRows("Main Image").ToString & "','" & _
                                 newRows("Extra Image1").ToString & "','" & newRows("Extra Image2").ToString & "','" & newRows("Extra Image3").ToString & "','" & MapUrl & "')"

                SelectCmd.CommandText = Sql
                SelectCmd.ExecuteNonQuery()
            Next
            Con.Close()
            SelectCmd = Nothing
            OthersToSell.OtherTableTableAdapter.Fill(OthersToSell.MerecDataSet.OtherTable)
            newRows = Nothing
            MyConnection.Close()
            OwM = "No"
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Finish")
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
            MessageBox.Show("The excel sheet you have selected does not have the proper format, for details click Ok button?", "Format message", MessageBoxButtons.OKCancel)

        End Try
    End Sub
    'End - BuildingTable




    'Start - Rent Table
    Private Function GetDataRent() As System.Data.DataTable

        Dim conn As New OleDbConnection(AccessCon)
        Dim adapter As New OleDbDataAdapter("select * from RentTable", conn) '
        Dim myDataSet As New DataSet
        Try
            adapter.Fill(myDataSet, "RentTable")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString)

            MessageBox.Show(ex.ToString())
        End Try
        Return myDataSet.Tables(0)
    End Function
    Public Function RentFormat() As Integer
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel


            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathRent & " '; " & "Extended Properties=Excel 8.0;") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Rent")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim Con As New OleDb.OleDbConnection(AccessCon)
            If Con.State = ConnectionState.Open Then
            Else
                Con.Open()
            End If
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            Dim i As Integer

            SelectCmd.CommandText = "Select * from RentTable"
            SelectCmd.Connection = Con

            Dim adapT As New OleDbDataAdapter
            adapT.SelectCommand = SelectCmd

            Dim ds As New DataSet
            Dim commandBuilder As New OleDb.OleDbCommandBuilder(adapT)
            adapT.Fill(ds)

            Dim dr As DataRow

            dr = DtSet.Tables(0).Rows(0)
            For ro = 0 To 1
                ro = ro + 1
                If i < 1 Then i = 1
                My.Application.DoEvents()
                dr("User ID").ToString()
                dr("Property ID").ToString()
                dr("Project ID").ToString()
                dr("Publish Status").ToString()
                dr("Master Project").ToString()
                dr("community/Project").ToString()
                dr("Property Type").ToString()
                dr("Block/Building").ToString()
                dr("Phase").ToString()
                dr("Address").ToString()
                dr("Country").ToString()
                dr("City").ToString()
                dr("Unit Type").ToString()
                dr("No of bedrooms").ToString()
                dr("view").ToString()
                dr("Balcony").ToString()
                dr("Annual Price").ToString()
                dr("Additional Price").ToString()
                dr("Currency").ToString()
                dr("Status").ToString()
                dr("Completion Date").ToString()
                dr("Entered By").ToString()
                dr("Agent/Seller").ToString()
                dr("Name Of Source").ToString()
                dr("Contact No").ToString()
                dr("Email").ToString()
                dr("Updated Date").ToString()
                dr("Entered Date").ToString()
                dr("Publish Notes").ToString()
                dr("Hidden Notes").ToString()
                dr("Main Image").ToString()
                dr("Extra image1").ToString()
                dr("Extra image2").ToString()
                dr("Extra image3").ToString()
                dr("Property Map").ToString()
                ' newRows("mapdata").ToString()
            Next
            'adapT.Update(ds)
            ds.AcceptChanges()
            Con.Close()
            SelectCmd = Nothing
            adapT = Nothing
            ds = Nothing
            dr = Nothing

            MyConnection.Close()
            OwM = "No"


            Return 1

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            MessageBox.Show("The excel sheet you have selected does not have the proper file format, do you need help?", "Format message", MessageBoxButtons.YesNo)
            Return 0
        End Try
    End Function

    Public Function RentToExcel(ByVal path As String) As String
        Dim path2 As String
        Dim excel As New Excel.Application()


        Try

            Dim wb As Excel.Workbook
            If UnitsToRent.SFD.ShowDialog() = DialogResult.OK Then
                path2 = (UnitsToRent.SFD.FileName.ToString())

                wb = excel.Application.Workbooks.Add() ' Open(path) ' .Add(True)
            Else
                Return 0
                Exit Function
            End If
            Dim ws As Excel.Worksheet = wb.Sheets("Sheet1")


            ws.Range("A1:AX1").Font.Bold = True
            ws.Range("A1:AX1").Font.Size = 12

            Dim colIndex, rowIndex As Integer
            rowIndex = 0
            Dim col As DataColumn
            For Each col In GetDataRent.Columns

                colIndex += 1
                ws.Cells(1, colIndex) = col.ColumnName.ToString
            Next col
            ws.Columns.AutoFit()
            Dim row As DataRow
            excel.Visible = False
            ProgressData.ListBox1.Items.Add("Please Wait...")
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = GetDataRent.Rows.Count
            ProgressData.Label1.Text = " Exporting data to excel..."
            ProgressData.Show()
            rowIndex = 1
            ProgressData.ListBox1.Items.Add("Exporting to Excel File...")
            For Each row In GetDataRent.Rows
                My.Application.DoEvents()

                colIndex = 0
                ProgressData.ProgressBar1.Value = rowIndex
                rowIndex += 1
                For Each col In GetDataRent.Columns
                    My.Application.DoEvents()

                    colIndex += 1
                    ws.Cells(rowIndex, colIndex) = row(col.ColumnName).ToString()

                Next col
            Next row
            ProgressData.ListBox1.Items.Add("Finish")
            ProgressData.Close()
            excel.Visible = True
            wb.SaveAs(path2, 56) ' ' & ".xls")

            wb.Close()


            excel = Nothing

            ProgressData.Close()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Ms Excel could not be detected on your computer. please install MS Excel and try again.", "Excel error", MessageBoxButtons.OK)
        End Try
        excel = Nothing
        Return 0
    End Function





    Sub RentToAccess(ByVal PrmPathExcelFile As String)

        Dim MyConnection As System.Data.OleDb.OleDbConnection

        Try

            ''''''' Fetch Data from Excel


            Dim DtSet As DataSet
            Dim MyCommand As OleDbDataAdapter
            MyConnection = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & PathRent & " '; " & "Extended Properties='Excel 8.0; IMEX=1;'") 'ExcelConUnits)
            MyConnection.Open()
            MyCommand = New OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "RentTable")
            DtSet = New DataSet
            MyCommand.Fill(DtSet, "RentTable")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim SearchMax As New OleDbCommand("select max([property id]) from [Sheet1$]", MyConnection)
            Dim maxID As Integer
            If IsDBNull(SearchMax.ExecuteScalar) <> True Then
                maxID = SearchMax.ExecuteScalar()
            Else
                maxID = 10000000
            End If
            Dim propID As Integer

            Dim Con As New OleDbConnection(AccessCon)
            If Con.State = ConnectionState.Open Then
            Else
                Con.Open()
            End If
            Dim SelectCmd As New OleDbCommand
            Dim ro As Integer = 0
            ' Dim yn As String
            Dim i As Integer
            'yn = System.Windows.Forms.MessageBox.Show("Do you want to over write all property Records?", "MEREC", MessageBoxButtons.YesNo)
            If OwM = "Over" Then
                SelectCmd.CommandText = "Delete from RentTable"
                SelectCmd.Connection = Con
                SelectCmd.ExecuteNonQuery()
            ElseIf OwM = "Add" Then
                SelectCmd.CommandText = "select max([Property ID]) from RentTable"
                SelectCmd.Connection = Con
                'ro = SelectCmd.ExecuteScalar
                If CStr(SelectCmd.ExecuteScalar) = "" Then 'vbNull Then
                    i = 1
                Else
                    i = SelectCmd.ExecuteScalar
                End If
            Else
                Exit Sub
            End If


            Dim newRows As DataRow
            Dim totRows As Integer = DtSet.Tables("RentTable").Rows.Count

            'MessageBox.Show(adapT.InsertCommand.ToString)
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Please Wait...")
            ProgressData.ProgressBar1.Minimum = 0
            ProgressData.ProgressBar1.Maximum = totRows
            Dim proj As String = "NA"
            'Dim Img1 As Boolean
            Dim ProjId As Integer
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Importing data to Database...")
            For Each newRows In DtSet.Tables("RentTable").Rows
                My.Application.DoEvents()
                ro = ro + 1
                ProgressData.ProgressBar1.Value = ro
                If i < 1 Then i = 1
                If newRows("Community/Project").ToString.Length > 0 Then


                    Dim cm As New OleDbCommand("Select [Project ID] from projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)
                    Dim int As Integer = cm.ExecuteScalar + 0
                    If cm.ExecuteScalar > 0 Then
                        ProjId = cm.ExecuteScalar()
                        proj = newRows("Community/Project").ToString
                        cm.Dispose()
                    Else
                        My.Application.DoEvents()
                        Dim cm1 As New OleDbCommand("insert into projects([Project Name], ProjectType) values('" & newRows("Community/Project").ToString.Trim & "','Rent')", Con)
                        cm1.ExecuteNonQuery()
                        cm1.Dispose()

                        Dim cm3 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)

                        If cm3.ExecuteScalar > 0 Then
                            ProjId = cm3.ExecuteScalar
                            proj = newRows("Community/Project").ToString

                        End If
                        cm3.Dispose()
                        cm1.Dispose()
                    End If

                ElseIf IsDBNull(newRows("Community/Project")) = True And IsDBNull(newRows("Block/Building")) = False Then

                    Dim cm44 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Block/Building").ToString.Trim & "'", Con)
                    If cm44.ExecuteScalar > 0 Then
                        ProjId = cm44.ExecuteScalar
                        proj = newRows("Block/Building").ToString
                    Else
                        My.Application.DoEvents()
                        Dim cm11 As New OleDbCommand("insert into projects([Project Name], ProjectType) values('" & newRows("Block/Building").ToString.Trim & "','Rent')", Con)
                        cm11.ExecuteNonQuery()
                        cm11.Dispose()

                        Dim cm31 As New OleDbCommand("select [Project ID] from Projects where [Project Name]='" & newRows("Community/Project").ToString.Trim & "'", Con)
                        If cm31.ExecuteScalar > 0 Then
                            ProjId = cm31.ExecuteScalar
                            proj = newRows("Block/Building").ToString

                        End If
                        cm31.Dispose()
                        cm44.Dispose()
                        cm11.Dispose()
                    End If
                Else
                    ProjId = 0
                    proj = ""
                End If

                If newRows("Property ID").ToString.Length > 0 And maxID > 10000000 Then
                    propID = newRows("Property ID")
                Else
                    maxID = 10000000
                    propID = maxID + ro
                End If

                My.Application.DoEvents()
                Dim Sql As String = "insert into RentTable ([Project ID],[Property ID], [User ID],[Master Project], [Community/project], [Property Type], [Block/Building] " _
                                & ", [Phase],[Address], [Country], [City],  [Unit Type], [No of Bedrooms],[view] " _
                                & ", [Balcony],[Annual Price], [Additional Price], [Currency], [Status],[Completion Date],[Entered By]" _
                                & ", [agent/seller], [Name of Source],[Contact No], [Email], [Updated Date],[Entered Date],[Publish Notes],[Hidden Notes], [Main Image] " _
                                & ", [Extra Image1], [Extra Image2], [Extra Image3], [Property Map])  values (" & ProjId & "," & propID & "," & i + ro & ",'" & newRows("Master Project") & "','" & proj & "','" _
                                & newRows("Property Type") & "','" & newRows("Block/Building") & "','" & newRows("Phase") & "','" & newRows("Address") & "','" & newRows("Country") & "','" & newRows("City") & "','" & _
                                  newRows("Unit Type") & "','" & newRows("No of bedrooms") & "','" & newRows("View") & "','" & _
                                  newRows("Balcony") & "','" & newRows("Annual Price") & "','" & newRows("Additional Price") & "','" & newRows("currency") & "','" & _
                                 newRows("status") & "','" & newRows("Completion Date") & "','" & newRows("Entered By") & "','" & newRows("Agent/Seller") & "','" & newRows("Name Of Source") & "','" & _
                                 newRows("Contact No") & "','" & newRows("Email") & "','" & Now.Date.ToShortDateString & "','" & Now.Date.ToShortDateString & "','" & newRows("Publish Notes") & "','" & newRows("Hidden Notes") & "','" & newRows("Main Image") & "','" & _
                                 newRows("Extra Image1") & "','" & newRows("Extra Image2") & "','" & newRows("Extra Image3") & "','" & MapUrl & "')"

                If IsDBNull(newRows("Community/Project")) = True Then
                Else
                    Dim cmd As New OleDbCommand(Sql, Con)
                    cmd.ExecuteNonQuery()
                End If

            Next
            Con.Close()
            SelectCmd = Nothing
            UnitsToRent.RentTableTableAdapter.Fill(UnitsToRent.MerecDataSet.RentTable)
            newRows = Nothing

            MyConnection.Close()
            OwM = "No"
            ProgressData.ListBox1.SelectedIndex = ProgressData.ListBox1.Items.Add("Finish")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            MessageBox.Show("The excel sheet you have selected does not have the proper format, for details click Ok button?", "Format message", MessageBoxButtons.OKCancel)

        End Try
    End Sub
    'End - UnitsTable

End Class
