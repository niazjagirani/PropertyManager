<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LandToSell
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LandToSell))
        Me.ExportExcel_Button = New System.Windows.Forms.Button
        Me.ImportExcel_Button = New System.Windows.Forms.Button
        Me.UpdateSheet_button = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGridView
        Me.ChkId = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PropertyIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProjectIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pub = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MasterProjectDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommunityProjectDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PropertyTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PhaseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CountryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ParcelNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LandSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AllowedHeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AllowedBuiltupAreaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SqrftSqrMtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FARDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SellingPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OriginalPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EnteredByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgentsellerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameOfSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EnteredDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PublishNotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HiddenNotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MainImageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtraImage1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtraImage2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtraImage3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SentEmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PropertyMapDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LandTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MerecDataSet = New Merec.MerecDataSet
        Me.FTP_UNITS = New System.Windows.Forms.Button
        Me.SelAll = New System.Windows.Forms.Button
        Me.DelSelected = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PublishSelected = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.EmailSelected = New System.Windows.Forms.Button
        Me.Undo10mnts = New System.Windows.Forms.Button
        Me.SearchCombo = New System.Windows.Forms.ComboBox
        Me.searchText = New System.Windows.Forms.TextBox
        Me.SearchButton = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.SFD = New System.Windows.Forms.SaveFileDialog
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.QSearchText = New System.Windows.Forms.TextBox
        Me.FullList = New System.Windows.Forms.Button
        Me.BackupRet = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProjectsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProjectsTableAdapter = New Merec.MerecDataSetTableAdapters.ProjectsTableAdapter
        Me.FullListButton = New System.Windows.Forms.Button
        Me.LandTableTableAdapter = New Merec.MerecDataSetTableAdapters.LandTableTableAdapter
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LandTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MerecDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ProjectsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExportExcel_Button
        '
        Me.ExportExcel_Button.BackColor = System.Drawing.Color.White
        Me.ExportExcel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportExcel_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ExportExcel_Button.Location = New System.Drawing.Point(11, 52)
        Me.ExportExcel_Button.Name = "ExportExcel_Button"
        Me.ExportExcel_Button.Size = New System.Drawing.Size(128, 23)
        Me.ExportExcel_Button.TabIndex = 144
        Me.ExportExcel_Button.Text = "Export to Excel"
        Me.ToolTip.SetToolTip(Me.ExportExcel_Button, "To transfer property data to excel sheet")
        Me.ExportExcel_Button.UseVisualStyleBackColor = False
        '
        'ImportExcel_Button
        '
        Me.ImportExcel_Button.BackColor = System.Drawing.Color.White
        Me.ImportExcel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportExcel_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ImportExcel_Button.Location = New System.Drawing.Point(11, 27)
        Me.ImportExcel_Button.Name = "ImportExcel_Button"
        Me.ImportExcel_Button.Size = New System.Drawing.Size(128, 23)
        Me.ImportExcel_Button.TabIndex = 143
        Me.ImportExcel_Button.Text = "Import from Excel"
        Me.ToolTip.SetToolTip(Me.ImportExcel_Button, "To get property data from excel sheet")
        Me.ImportExcel_Button.UseVisualStyleBackColor = False
        '
        'UpdateSheet_button
        '
        Me.UpdateSheet_button.BackColor = System.Drawing.Color.White
        Me.UpdateSheet_button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateSheet_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UpdateSheet_button.Location = New System.Drawing.Point(122, 23)
        Me.UpdateSheet_button.Name = "UpdateSheet_button"
        Me.UpdateSheet_button.Size = New System.Drawing.Size(123, 23)
        Me.UpdateSheet_button.TabIndex = 142
        Me.UpdateSheet_button.Text = "Updated Selected"
        Me.ToolTip.SetToolTip(Me.UpdateSheet_button, "To Save property list in sheet (new inserted or updated)")
        Me.UpdateSheet_button.UseVisualStyleBackColor = False
        '
        'DataGrid1
        '
        Me.DataGrid1.AllowDrop = True
        Me.DataGrid1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.DataGrid1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGrid1.AutoGenerateColumns = False
        Me.DataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChkId, Me.UserIDDataGridViewTextBoxColumn, Me.PropertyIDDataGridViewTextBoxColumn, Me.ProjectIDDataGridViewTextBoxColumn, Me.Pub, Me.MasterProjectDataGridViewTextBoxColumn, Me.CommunityProjectDataGridViewTextBoxColumn, Me.PropertyTypeDataGridViewTextBoxColumn, Me.PhaseDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn, Me.CountryDataGridViewTextBoxColumn, Me.CityDataGridViewTextBoxColumn, Me.ParcelNoDataGridViewTextBoxColumn, Me.LandSizeDataGridViewTextBoxColumn, Me.AllowedHeightDataGridViewTextBoxColumn, Me.AllowedBuiltupAreaDataGridViewTextBoxColumn, Me.SqrftSqrMtDataGridViewTextBoxColumn, Me.FARDataGridViewTextBoxColumn, Me.SellingPriceDataGridViewTextBoxColumn, Me.OriginalPriceDataGridViewTextBoxColumn, Me.CurrencyDataGridViewTextBoxColumn, Me.EnteredByDataGridViewTextBoxColumn, Me.AgentsellerDataGridViewTextBoxColumn, Me.NameOfSourceDataGridViewTextBoxColumn, Me.ContactNoDataGridViewTextBoxColumn, Me.EmailDataGridViewTextBoxColumn, Me.UpdatedDateDataGridViewTextBoxColumn, Me.EnteredDateDataGridViewTextBoxColumn, Me.PublishNotesDataGridViewTextBoxColumn, Me.HiddenNotesDataGridViewTextBoxColumn, Me.MainImageDataGridViewTextBoxColumn, Me.ExtraImage1DataGridViewTextBoxColumn, Me.ExtraImage2DataGridViewTextBoxColumn, Me.ExtraImage3DataGridViewTextBoxColumn, Me.SentEmailDataGridViewTextBoxColumn, Me.PropertyMapDataGridViewTextBoxColumn})
        Me.DataGrid1.DataSource = Me.LandTableBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGrid1.Location = New System.Drawing.Point(12, 43)
        Me.DataGrid1.Name = "DataGrid1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGrid1.Size = New System.Drawing.Size(996, 469)
        Me.DataGrid1.TabIndex = 141
        '
        'ChkId
        '
        Me.ChkId.HeaderText = "Select"
        Me.ChkId.Name = "ChkId"
        Me.ChkId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkId.Width = 43
        '
        'UserIDDataGridViewTextBoxColumn
        '
        Me.UserIDDataGridViewTextBoxColumn.DataPropertyName = "User ID"
        Me.UserIDDataGridViewTextBoxColumn.HeaderText = "User ID"
        Me.UserIDDataGridViewTextBoxColumn.Name = "UserIDDataGridViewTextBoxColumn"
        Me.UserIDDataGridViewTextBoxColumn.Width = 68
        '
        'PropertyIDDataGridViewTextBoxColumn
        '
        Me.PropertyIDDataGridViewTextBoxColumn.DataPropertyName = "Property ID"
        Me.PropertyIDDataGridViewTextBoxColumn.HeaderText = "Property ID"
        Me.PropertyIDDataGridViewTextBoxColumn.Name = "PropertyIDDataGridViewTextBoxColumn"
        Me.PropertyIDDataGridViewTextBoxColumn.Width = 85
        '
        'ProjectIDDataGridViewTextBoxColumn
        '
        Me.ProjectIDDataGridViewTextBoxColumn.DataPropertyName = "Project ID"
        Me.ProjectIDDataGridViewTextBoxColumn.HeaderText = "Project ID"
        Me.ProjectIDDataGridViewTextBoxColumn.Name = "ProjectIDDataGridViewTextBoxColumn"
        Me.ProjectIDDataGridViewTextBoxColumn.Width = 79
        '
        'Pub
        '
        Me.Pub.DataPropertyName = "Publish Status"
        Me.Pub.FalseValue = "0"
        Me.Pub.HeaderText = "Publish Status"
        Me.Pub.IndeterminateValue = "0"
        Me.Pub.Name = "Pub"
        Me.Pub.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pub.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Pub.TrueValue = "1"
        Me.Pub.Width = 99
        '
        'MasterProjectDataGridViewTextBoxColumn
        '
        Me.MasterProjectDataGridViewTextBoxColumn.DataPropertyName = "Master Project"
        Me.MasterProjectDataGridViewTextBoxColumn.HeaderText = "Master Project"
        Me.MasterProjectDataGridViewTextBoxColumn.Name = "MasterProjectDataGridViewTextBoxColumn"
        '
        'CommunityProjectDataGridViewTextBoxColumn
        '
        Me.CommunityProjectDataGridViewTextBoxColumn.DataPropertyName = "Community/Project"
        Me.CommunityProjectDataGridViewTextBoxColumn.HeaderText = "Community/Project"
        Me.CommunityProjectDataGridViewTextBoxColumn.Name = "CommunityProjectDataGridViewTextBoxColumn"
        Me.CommunityProjectDataGridViewTextBoxColumn.Width = 121
        '
        'PropertyTypeDataGridViewTextBoxColumn
        '
        Me.PropertyTypeDataGridViewTextBoxColumn.DataPropertyName = "Property Type"
        Me.PropertyTypeDataGridViewTextBoxColumn.HeaderText = "Property Type"
        Me.PropertyTypeDataGridViewTextBoxColumn.Name = "PropertyTypeDataGridViewTextBoxColumn"
        Me.PropertyTypeDataGridViewTextBoxColumn.Width = 98
        '
        'PhaseDataGridViewTextBoxColumn
        '
        Me.PhaseDataGridViewTextBoxColumn.DataPropertyName = "Phase"
        Me.PhaseDataGridViewTextBoxColumn.HeaderText = "Phase"
        Me.PhaseDataGridViewTextBoxColumn.Name = "PhaseDataGridViewTextBoxColumn"
        Me.PhaseDataGridViewTextBoxColumn.Width = 62
        '
        'AddressDataGridViewTextBoxColumn
        '
        Me.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        Me.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        Me.AddressDataGridViewTextBoxColumn.Width = 70
        '
        'CountryDataGridViewTextBoxColumn
        '
        Me.CountryDataGridViewTextBoxColumn.DataPropertyName = "Country"
        Me.CountryDataGridViewTextBoxColumn.HeaderText = "Country"
        Me.CountryDataGridViewTextBoxColumn.Name = "CountryDataGridViewTextBoxColumn"
        Me.CountryDataGridViewTextBoxColumn.Width = 68
        '
        'CityDataGridViewTextBoxColumn
        '
        Me.CityDataGridViewTextBoxColumn.DataPropertyName = "City"
        Me.CityDataGridViewTextBoxColumn.HeaderText = "City"
        Me.CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        Me.CityDataGridViewTextBoxColumn.Width = 49
        '
        'ParcelNoDataGridViewTextBoxColumn
        '
        Me.ParcelNoDataGridViewTextBoxColumn.DataPropertyName = "Parcel No"
        Me.ParcelNoDataGridViewTextBoxColumn.HeaderText = "Parcel No"
        Me.ParcelNoDataGridViewTextBoxColumn.Name = "ParcelNoDataGridViewTextBoxColumn"
        Me.ParcelNoDataGridViewTextBoxColumn.Width = 79
        '
        'LandSizeDataGridViewTextBoxColumn
        '
        Me.LandSizeDataGridViewTextBoxColumn.DataPropertyName = "Land Size"
        Me.LandSizeDataGridViewTextBoxColumn.HeaderText = "Land Size"
        Me.LandSizeDataGridViewTextBoxColumn.Name = "LandSizeDataGridViewTextBoxColumn"
        Me.LandSizeDataGridViewTextBoxColumn.Width = 79
        '
        'AllowedHeightDataGridViewTextBoxColumn
        '
        Me.AllowedHeightDataGridViewTextBoxColumn.DataPropertyName = "Allowed Height"
        Me.AllowedHeightDataGridViewTextBoxColumn.HeaderText = "Allowed Height"
        Me.AllowedHeightDataGridViewTextBoxColumn.Name = "AllowedHeightDataGridViewTextBoxColumn"
        Me.AllowedHeightDataGridViewTextBoxColumn.Width = 103
        '
        'AllowedBuiltupAreaDataGridViewTextBoxColumn
        '
        Me.AllowedBuiltupAreaDataGridViewTextBoxColumn.DataPropertyName = "Allowed Builtup Area"
        Me.AllowedBuiltupAreaDataGridViewTextBoxColumn.HeaderText = "Allowed Builtup Area"
        Me.AllowedBuiltupAreaDataGridViewTextBoxColumn.Name = "AllowedBuiltupAreaDataGridViewTextBoxColumn"
        Me.AllowedBuiltupAreaDataGridViewTextBoxColumn.Width = 129
        '
        'SqrftSqrMtDataGridViewTextBoxColumn
        '
        Me.SqrftSqrMtDataGridViewTextBoxColumn.DataPropertyName = "Sqrft/SqrMt"
        Me.SqrftSqrMtDataGridViewTextBoxColumn.HeaderText = "Sqrft/SqrMt"
        Me.SqrftSqrMtDataGridViewTextBoxColumn.Name = "SqrftSqrMtDataGridViewTextBoxColumn"
        Me.SqrftSqrMtDataGridViewTextBoxColumn.Width = 87
        '
        'FARDataGridViewTextBoxColumn
        '
        Me.FARDataGridViewTextBoxColumn.DataPropertyName = "FAR"
        Me.FARDataGridViewTextBoxColumn.HeaderText = "FAR"
        Me.FARDataGridViewTextBoxColumn.Name = "FARDataGridViewTextBoxColumn"
        Me.FARDataGridViewTextBoxColumn.Width = 53
        '
        'SellingPriceDataGridViewTextBoxColumn
        '
        Me.SellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling Price"
        Me.SellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling Price"
        Me.SellingPriceDataGridViewTextBoxColumn.Name = "SellingPriceDataGridViewTextBoxColumn"
        Me.SellingPriceDataGridViewTextBoxColumn.Width = 90
        '
        'OriginalPriceDataGridViewTextBoxColumn
        '
        Me.OriginalPriceDataGridViewTextBoxColumn.DataPropertyName = "Original Price"
        Me.OriginalPriceDataGridViewTextBoxColumn.HeaderText = "Original Price"
        Me.OriginalPriceDataGridViewTextBoxColumn.Name = "OriginalPriceDataGridViewTextBoxColumn"
        Me.OriginalPriceDataGridViewTextBoxColumn.Width = 94
        '
        'CurrencyDataGridViewTextBoxColumn
        '
        Me.CurrencyDataGridViewTextBoxColumn.DataPropertyName = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.HeaderText = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.Name = "CurrencyDataGridViewTextBoxColumn"
        Me.CurrencyDataGridViewTextBoxColumn.Width = 74
        '
        'EnteredByDataGridViewTextBoxColumn
        '
        Me.EnteredByDataGridViewTextBoxColumn.DataPropertyName = "Entered By"
        Me.EnteredByDataGridViewTextBoxColumn.HeaderText = "Entered By"
        Me.EnteredByDataGridViewTextBoxColumn.Name = "EnteredByDataGridViewTextBoxColumn"
        Me.EnteredByDataGridViewTextBoxColumn.Width = 84
        '
        'AgentsellerDataGridViewTextBoxColumn
        '
        Me.AgentsellerDataGridViewTextBoxColumn.DataPropertyName = "Agent/seller"
        Me.AgentsellerDataGridViewTextBoxColumn.HeaderText = "Agent/seller"
        Me.AgentsellerDataGridViewTextBoxColumn.Name = "AgentsellerDataGridViewTextBoxColumn"
        Me.AgentsellerDataGridViewTextBoxColumn.Width = 89
        '
        'NameOfSourceDataGridViewTextBoxColumn
        '
        Me.NameOfSourceDataGridViewTextBoxColumn.DataPropertyName = "Name Of Source"
        Me.NameOfSourceDataGridViewTextBoxColumn.HeaderText = "Name Of Source"
        Me.NameOfSourceDataGridViewTextBoxColumn.Name = "NameOfSourceDataGridViewTextBoxColumn"
        Me.NameOfSourceDataGridViewTextBoxColumn.Width = 111
        '
        'ContactNoDataGridViewTextBoxColumn
        '
        Me.ContactNoDataGridViewTextBoxColumn.DataPropertyName = "Contact No"
        Me.ContactNoDataGridViewTextBoxColumn.HeaderText = "Contact No"
        Me.ContactNoDataGridViewTextBoxColumn.Name = "ContactNoDataGridViewTextBoxColumn"
        Me.ContactNoDataGridViewTextBoxColumn.Width = 86
        '
        'EmailDataGridViewTextBoxColumn
        '
        Me.EmailDataGridViewTextBoxColumn.DataPropertyName = "Email"
        Me.EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        Me.EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        Me.EmailDataGridViewTextBoxColumn.Width = 57
        '
        'UpdatedDateDataGridViewTextBoxColumn
        '
        Me.UpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "Updated Date"
        Me.UpdatedDateDataGridViewTextBoxColumn.HeaderText = "Updated Date"
        Me.UpdatedDateDataGridViewTextBoxColumn.Name = "UpdatedDateDataGridViewTextBoxColumn"
        Me.UpdatedDateDataGridViewTextBoxColumn.Width = 99
        '
        'EnteredDateDataGridViewTextBoxColumn
        '
        Me.EnteredDateDataGridViewTextBoxColumn.DataPropertyName = "Entered Date"
        Me.EnteredDateDataGridViewTextBoxColumn.HeaderText = "Entered Date"
        Me.EnteredDateDataGridViewTextBoxColumn.Name = "EnteredDateDataGridViewTextBoxColumn"
        Me.EnteredDateDataGridViewTextBoxColumn.Width = 95
        '
        'PublishNotesDataGridViewTextBoxColumn
        '
        Me.PublishNotesDataGridViewTextBoxColumn.DataPropertyName = "Publish Notes"
        Me.PublishNotesDataGridViewTextBoxColumn.HeaderText = "Publish Notes"
        Me.PublishNotesDataGridViewTextBoxColumn.Name = "PublishNotesDataGridViewTextBoxColumn"
        Me.PublishNotesDataGridViewTextBoxColumn.Width = 97
        '
        'HiddenNotesDataGridViewTextBoxColumn
        '
        Me.HiddenNotesDataGridViewTextBoxColumn.DataPropertyName = "Hidden Notes"
        Me.HiddenNotesDataGridViewTextBoxColumn.HeaderText = "Hidden Notes"
        Me.HiddenNotesDataGridViewTextBoxColumn.Name = "HiddenNotesDataGridViewTextBoxColumn"
        Me.HiddenNotesDataGridViewTextBoxColumn.Width = 97
        '
        'MainImageDataGridViewTextBoxColumn
        '
        Me.MainImageDataGridViewTextBoxColumn.DataPropertyName = "Main Image"
        Me.MainImageDataGridViewTextBoxColumn.HeaderText = "Main Image"
        Me.MainImageDataGridViewTextBoxColumn.Name = "MainImageDataGridViewTextBoxColumn"
        Me.MainImageDataGridViewTextBoxColumn.Width = 87
        '
        'ExtraImage1DataGridViewTextBoxColumn
        '
        Me.ExtraImage1DataGridViewTextBoxColumn.DataPropertyName = "Extra Image1"
        Me.ExtraImage1DataGridViewTextBoxColumn.HeaderText = "Extra Image1"
        Me.ExtraImage1DataGridViewTextBoxColumn.Name = "ExtraImage1DataGridViewTextBoxColumn"
        Me.ExtraImage1DataGridViewTextBoxColumn.Width = 94
        '
        'ExtraImage2DataGridViewTextBoxColumn
        '
        Me.ExtraImage2DataGridViewTextBoxColumn.DataPropertyName = "Extra Image2"
        Me.ExtraImage2DataGridViewTextBoxColumn.HeaderText = "Extra Image2"
        Me.ExtraImage2DataGridViewTextBoxColumn.Name = "ExtraImage2DataGridViewTextBoxColumn"
        Me.ExtraImage2DataGridViewTextBoxColumn.Width = 94
        '
        'ExtraImage3DataGridViewTextBoxColumn
        '
        Me.ExtraImage3DataGridViewTextBoxColumn.DataPropertyName = "Extra Image3"
        Me.ExtraImage3DataGridViewTextBoxColumn.HeaderText = "Extra Image3"
        Me.ExtraImage3DataGridViewTextBoxColumn.Name = "ExtraImage3DataGridViewTextBoxColumn"
        Me.ExtraImage3DataGridViewTextBoxColumn.Width = 94
        '
        'SentEmailDataGridViewTextBoxColumn
        '
        Me.SentEmailDataGridViewTextBoxColumn.DataPropertyName = "sentEmail"
        Me.SentEmailDataGridViewTextBoxColumn.HeaderText = "sentEmail"
        Me.SentEmailDataGridViewTextBoxColumn.Name = "SentEmailDataGridViewTextBoxColumn"
        Me.SentEmailDataGridViewTextBoxColumn.Width = 77
        '
        'PropertyMapDataGridViewTextBoxColumn
        '
        Me.PropertyMapDataGridViewTextBoxColumn.DataPropertyName = "Property Map"
        Me.PropertyMapDataGridViewTextBoxColumn.HeaderText = "Property Map"
        Me.PropertyMapDataGridViewTextBoxColumn.Name = "PropertyMapDataGridViewTextBoxColumn"
        Me.PropertyMapDataGridViewTextBoxColumn.Width = 95
        '
        'LandTableBindingSource
        '
        Me.LandTableBindingSource.DataMember = "LandTable"
        Me.LandTableBindingSource.DataSource = Me.MerecDataSet
        '
        'MerecDataSet
        '
        Me.MerecDataSet.DataSetName = "MerecDataSet"
        Me.MerecDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FTP_UNITS
        '
        Me.FTP_UNITS.BackColor = System.Drawing.Color.White
        Me.FTP_UNITS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FTP_UNITS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FTP_UNITS.Location = New System.Drawing.Point(12, 53)
        Me.FTP_UNITS.Name = "FTP_UNITS"
        Me.FTP_UNITS.Size = New System.Drawing.Size(137, 23)
        Me.FTP_UNITS.TabIndex = 147
        Me.FTP_UNITS.Text = "Publish All"
        Me.ToolTip.SetToolTip(Me.FTP_UNITS, "To send selected property list to online")
        Me.FTP_UNITS.UseVisualStyleBackColor = False
        '
        'SelAll
        '
        Me.SelAll.BackColor = System.Drawing.Color.White
        Me.SelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SelAll.Location = New System.Drawing.Point(4, 48)
        Me.SelAll.Name = "SelAll"
        Me.SelAll.Size = New System.Drawing.Size(112, 23)
        Me.SelAll.TabIndex = 148
        Me.SelAll.Text = "Select All"
        Me.ToolTip.SetToolTip(Me.SelAll, "Select all property list")
        Me.SelAll.UseVisualStyleBackColor = False
        '
        'DelSelected
        '
        Me.DelSelected.BackColor = System.Drawing.Color.White
        Me.DelSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DelSelected.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DelSelected.Location = New System.Drawing.Point(4, 72)
        Me.DelSelected.Name = "DelSelected"
        Me.DelSelected.Size = New System.Drawing.Size(241, 23)
        Me.DelSelected.TabIndex = 149
        Me.DelSelected.Text = "Delete Selected"
        Me.ToolTip.SetToolTip(Me.DelSelected, "Remove selected property")
        Me.DelSelected.UseVisualStyleBackColor = False
        '
        'PublishSelected
        '
        Me.PublishSelected.BackColor = System.Drawing.Color.White
        Me.PublishSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PublishSelected.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PublishSelected.Location = New System.Drawing.Point(12, 26)
        Me.PublishSelected.Name = "PublishSelected"
        Me.PublishSelected.Size = New System.Drawing.Size(137, 23)
        Me.PublishSelected.TabIndex = 155
        Me.PublishSelected.Text = "Publish Selected"
        Me.ToolTip.SetToolTip(Me.PublishSelected, "Remove selected property")
        Me.PublishSelected.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(4, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 23)
        Me.Button2.TabIndex = 156
        Me.Button2.Text = "Clear All"
        Me.ToolTip.SetToolTip(Me.Button2, "Select all property list")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'EmailSelected
        '
        Me.EmailSelected.BackColor = System.Drawing.Color.White
        Me.EmailSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailSelected.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.EmailSelected.Location = New System.Drawing.Point(122, 48)
        Me.EmailSelected.Name = "EmailSelected"
        Me.EmailSelected.Size = New System.Drawing.Size(123, 23)
        Me.EmailSelected.TabIndex = 157
        Me.EmailSelected.Text = "Email Selected"
        Me.ToolTip.SetToolTip(Me.EmailSelected, "Remove selected property")
        Me.EmailSelected.UseVisualStyleBackColor = False
        '
        'Undo10mnts
        '
        Me.Undo10mnts.BackColor = System.Drawing.Color.White
        Me.Undo10mnts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Undo10mnts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Undo10mnts.Location = New System.Drawing.Point(9, 53)
        Me.Undo10mnts.Name = "Undo10mnts"
        Me.Undo10mnts.Size = New System.Drawing.Size(161, 23)
        Me.Undo10mnts.TabIndex = 182
        Me.Undo10mnts.Text = "Undo"
        Me.ToolTip.SetToolTip(Me.Undo10mnts, "To send selected property list to online")
        Me.Undo10mnts.UseVisualStyleBackColor = False
        '
        'SearchCombo
        '
        Me.SearchCombo.FormattingEnabled = True
        Me.SearchCombo.Location = New System.Drawing.Point(24, 12)
        Me.SearchCombo.Name = "SearchCombo"
        Me.SearchCombo.Size = New System.Drawing.Size(121, 21)
        Me.SearchCombo.TabIndex = 150
        '
        'searchText
        '
        Me.searchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.searchText.Location = New System.Drawing.Point(151, 12)
        Me.searchText.Name = "searchText"
        Me.searchText.Size = New System.Drawing.Size(125, 20)
        Me.searchText.TabIndex = 151
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(277, 11)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 152
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Silver
        Me.Label27.Location = New System.Drawing.Point(12, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(996, 29)
        Me.Label27.TabIndex = 153
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Silver
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DarkRed
        Me.Label28.Location = New System.Drawing.Point(12, 515)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(996, 113)
        Me.Label28.TabIndex = 146
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'OFD
        '
        Me.OFD.DefaultExt = "*.xls"
        Me.OFD.Filter = "Excel 2003|*.xls"
        Me.OFD.InitialDirectory = "c:\PropertyManager\Database\"
        Me.OFD.Title = "File Open - Excel Format Only"
        '
        'SFD
        '
        Me.SFD.DefaultExt = "*.xls"
        Me.SFD.Filter = "Excel 2003|*.xls"
        Me.SFD.InitialDirectory = "C:\PropertyManager\database\"
        '
        'OpenFile
        '
        Me.OpenFile.DefaultExt = "*.jpg"
        Me.OpenFile.Filter = "JPG Images|*.jpg|GIF Images|*.gif"
        Me.OpenFile.InitialDirectory = "c:\propertymanager\images"
        '
        'QSearchText
        '
        Me.QSearchText.Location = New System.Drawing.Point(754, 13)
        Me.QSearchText.Name = "QSearchText"
        Me.QSearchText.Size = New System.Drawing.Size(148, 20)
        Me.QSearchText.TabIndex = 171
        '
        'FullList
        '
        Me.FullList.Location = New System.Drawing.Point(908, 12)
        Me.FullList.Name = "FullList"
        Me.FullList.Size = New System.Drawing.Size(84, 23)
        Me.FullList.TabIndex = 170
        Me.FullList.Text = "Quick Search"
        Me.FullList.UseVisualStyleBackColor = True
        '
        'BackupRet
        '
        Me.BackupRet.FormattingEnabled = True
        Me.BackupRet.Items.AddRange(New Object() {"Last ten menuts", "Start of session", "24 hours session"})
        Me.BackupRet.Location = New System.Drawing.Point(11, 25)
        Me.BackupRet.Name = "BackupRet"
        Me.BackupRet.Size = New System.Drawing.Size(159, 21)
        Me.BackupRet.TabIndex = 173
        Me.BackupRet.Text = "Last ten menuts"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.EmailSelected)
        Me.Panel1.Controls.Add(Me.UpdateSheet_button)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.SelAll)
        Me.Panel1.Controls.Add(Me.DelSelected)
        Me.Panel1.Location = New System.Drawing.Point(16, 523)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 99)
        Me.Panel1.TabIndex = 174
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Menu
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(0, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(256, 20)
        Me.Label22.TabIndex = 158
        Me.Label22.Text = "Property Selection"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.PublishSelected)
        Me.Panel2.Controls.Add(Me.FTP_UNITS)
        Me.Panel2.Location = New System.Drawing.Point(455, 523)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(180, 99)
        Me.Panel2.TabIndex = 175
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Menu
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 20)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "Publish to Web"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Undo10mnts)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.BackupRet)
        Me.Panel3.Location = New System.Drawing.Point(273, 523)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(180, 99)
        Me.Panel3.TabIndex = 176
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Menu
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 20)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Backup"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 180
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.ImportExcel_Button)
        Me.Panel4.Controls.Add(Me.ExportExcel_Button)
        Me.Panel4.Location = New System.Drawing.Point(821, 523)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(180, 99)
        Me.Panel4.TabIndex = 177
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Menu
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 20)
        Me.Label4.TabIndex = 182
        Me.Label4.Text = "Export and Import"
        '
        'ProjectsBindingSource
        '
        Me.ProjectsBindingSource.DataMember = "Projects"
        Me.ProjectsBindingSource.DataSource = Me.MerecDataSet
        '
        'ProjectsTableAdapter
        '
        Me.ProjectsTableAdapter.ClearBeforeFill = True
        '
        'FullListButton
        '
        Me.FullListButton.Location = New System.Drawing.Point(664, 12)
        Me.FullListButton.Name = "FullListButton"
        Me.FullListButton.Size = New System.Drawing.Size(84, 23)
        Me.FullListButton.TabIndex = 179
        Me.FullListButton.Text = "Full List"
        Me.FullListButton.UseVisualStyleBackColor = True
        '
        'LandTableTableAdapter
        '
        Me.LandTableTableAdapter.ClearBeforeFill = True
        '
        'LandToSell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1011, 650)
        Me.Controls.Add(Me.FullListButton)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.QSearchText)
        Me.Controls.Add(Me.FullList)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.searchText)
        Me.Controls.Add(Me.SearchCombo)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LandToSell"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Land To Sell"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LandTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MerecDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.ProjectsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExportExcel_Button As System.Windows.Forms.Button
    Friend WithEvents ImportExcel_Button As System.Windows.Forms.Button
    Friend WithEvents UpdateSheet_button As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents MerecDataSet As Merec.MerecDataSet
    Friend WithEvents FTP_UNITS As System.Windows.Forms.Button
    Friend WithEvents SelAll As System.Windows.Forms.Button
    Friend WithEvents DelSelected As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents SearchCombo As System.Windows.Forms.ComboBox
    Friend WithEvents searchText As System.Windows.Forms.TextBox
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents PublishSelected As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents EmailSelected As System.Windows.Forms.Button
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents QSearchText As System.Windows.Forms.TextBox
    Friend WithEvents FullList As System.Windows.Forms.Button
    Friend WithEvents BackupRet As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Undo10mnts As System.Windows.Forms.Button
    Friend WithEvents ProjectsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProjectsTableAdapter As Merec.MerecDataSetTableAdapters.ProjectsTableAdapter
    Friend WithEvents FullListButton As System.Windows.Forms.Button
    Friend WithEvents LandTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LandTableTableAdapter As Merec.MerecDataSetTableAdapters.LandTableTableAdapter
    Friend WithEvents ChkId As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProjectIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pub As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MasterProjectDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommunityProjectDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhaseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParcelNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LandSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllowedHeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllowedBuiltupAreaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SqrftSqrMtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FARDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellingPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OriginalPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnteredByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgentsellerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameOfSourceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnteredDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PublishNotesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HiddenNotesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainImageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtraImage1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtraImage2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtraImage3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SentEmailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyMapDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
