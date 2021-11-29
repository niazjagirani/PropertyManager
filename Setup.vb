Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Net.Mail
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop

Public Class Setup
    Dim img1 As String
    Dim imgtf1 As Boolean
    Dim oCon = New OleDbConnection(My.Settings.MerecConnectionString)
    Dim oCom As New OleDbCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim oCount As Integer
            Dim reminder As Integer
            If Rb2.Checked = True Then
                reminder = 1
            Else
                reminder = 0
            End If

            oCom.Connection = oCon
            oCom.CommandText = "Delete * from SettingInfo"
            oCount = oCom.ExecuteNonQuery
            Dim path As String = UnitImage1.Text
            imageSize2(Pic1, path, img1)
            UnitImage1.Text = img1
            oCom.CommandText = "Insert into settinginfo(PersonalTitle, PersonalFirstName " _
            & ",PersonalMiddleName, PersonalLastName,PersonalTelephoneNo, PersonalAddress " _
            & ", PersonalAddress2, PersonalEmail, CompanyName,CompanyBusinessType,CompanyAddress " _
            & ", CompanyAddress2,CompanyTelephoneNo, CompanyFaxNo, CompanyWebSite " _
            & ", CompanyEmail,CompanyLogo, RegionalCountry, RegionalCity, RegionalLanguage, RegionalCurrency " _
            & ", RegionalUnitFormats,RegionalPostalCode, RegionalListedCountry,RegionalListedCity " _
            & ", ServiceCommission) values('" & PersonalTitle.Text & "','" & PersonalFirstName.Text & "','" & PersonalMiddleName.Text _
            & "','" & PersonalLastName.Text & "','" & PersonalTelephoneNo.Text _
            & "','" & PersonalAddress.Text & "','" & PersonalAddress2.Text & "','" & PersonalEmail.Text _
            & "','" & CompanyName1.Text & "','" & CompanyBusinessType.Text _
            & "','" & CompanyAddress.Text & "','" & CompanyAddress2.Text & "','" & CompanyTelephoneNo.Text _
            & "','" & CompanyFaxNo.Text & "','" & CompanyWebSite.Text _
            & "','" & CompanyEmail.Text & "','" & UnitImage1.Text & "','" & RegionalCountry.Text _
            & "','" & RegionalCity.Text & "','" & RegionalLanguage.Text _
            & "','" & RegionalCurrency.Text & "','" & RegionalUnitFormats.Text _
            & "','" & RegionalPostalCode.Text & "','" & RegionalListedCountry.Text _
            & "','" & RegionalListedCity.Text & "','" & ServiceCommission.Text & "')"

            oCom.ExecuteNonQuery()

            System.Windows.Forms.MessageBox.Show("Company information has been updated.", "Update", MessageBoxButtons.OK)

        Catch es As Exception
            'System.Windows.Forms.MessageBox.Show("Record has not been updated due to Unknown error.", "Error", MessageBoxButtons.OK)
            'System.Windows.Forms.MessageBox.Show(es.ToString)
        End Try
    End Sub

    Public Sub imageSize2(ByVal img As PictureBox, ByVal fileName As String, ByVal OnlyName As String)
        Try
            img.Load(fileName)
            Dim bm As New Bitmap(img.Image) 'img.Image)
            Dim x As Int32 = 100 'variable for new width size
            Dim y As Int32 = 50 'variable for new height size
            Dim h, w, nh, nw As Int32

            h = bm.Height
            w = bm.Width
            If h < 50 Or w < 100 Then
                MessageBox.Show("Logo should be JPG and not less then 100x50", "Image", MessageBoxButtons.OK)
                Exit Sub
            End If
            If h > w Then
                nh = h - 50
                nh = nh * 100 / h

                nw = w - (nh * w / 100)
                nh = 50
            ElseIf w > h Then
                nw = w - 100
                nw = nw * 100 / w

                nh = h - (nw * h / 100)
                nw = 100
            End If
            x = nw
            y = nh
            Dim width As Integer = Val(x) 'image width. 

            Dim height As Integer = Val(y) 'image height

            Dim thumb As New Bitmap(width, height)

            Dim g As Graphics = Graphics.FromImage(thumb)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
    bm.Height), GraphicsUnit.Pixel)

            g.Dispose()


            'image path. better to make this dynamic. I am hardcoding a path just for example sake
            thumb.Save("c:\PropertyManager\images\" & OnlyName, _
    System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

            bm.Dispose()

            thumb.Dispose()
        Catch es As Exception
            'MessageBox.Show(es.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Setup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            oCon.open()
            Call DatainView()
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try

    End Sub



    Private Sub IMGbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMGbutton1.Click
        Try

            If OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                img1 = Path.GetFileName(OpenFile.FileName.ToString)
                UnitImage1.Text = OpenFile.FileName.ToString
                Pic1.Load(OpenFile.FileName.ToString)
                imgtf1 = True
            Else
                img1 = Path.GetFileName(UnitImage1.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DatainView()
        Try
            oCom.Connection = oCon
            oCom.CommandText = "Select * from SettingInfo"

            Dim rd As OleDbDataReader = oCom.ExecuteReader
            While rd.Read()
                PersonalTitle.Text = rd("PersonalTitle").ToString
                PersonalFirstName.Text = rd("PersonalFirstName").ToString
                PersonalMiddleName.Text = rd("PersonalMiddleName").ToString
                PersonalLastName.Text = rd("PersonalLastName").ToString
                PersonalTelephoneNo.Text = rd("PersonalTelephoneNo").ToString
                PersonalEmail.Text = rd("PersonalEmail").ToString
                CompanyName1.Text = rd("CompanyName").ToString
                CompanyBusinessType.Text = rd("companybusinesstype").ToString
                CompanyAddress.Text = rd("CompanyAddress").ToString
                CompanyAddress2.Text = rd("CompanyAddress2").ToString
                CompanyTelephoneNo.Text = rd("CompanyTelephoneNo").ToString
                CompanyFaxNo.Text = rd("CompanyFaxNo").ToString
                CompanyWebSite.Text = rd("Companywebsite").ToString
                CompanyEmail.Text = rd("CompanyEmail").ToString
                If rd("CompanyLogo").ToString.Length > 1 Then
                    Pic1.Load("C:\Propertymanager\Images\" & rd("CompanyLogo").ToString)
                End If
                RegionalCountry.Text = rd("RegionalCountry").ToString
                RegionalCity.Text = rd("RegionalCity").ToString
                RegionalLanguage.Text = rd("RegionalLanguage").ToString
                RegionalCurrency.Text = rd("RegionalCurrency").ToString
                RegionalUnitFormats.Text = rd("RegionalUnitFormats").ToString
                RegionalPostalCode.Text = rd("RegionalPostalCode").ToString
                RegionalListedCountry.Text = rd("RegionalListedCountry").ToString
                RegionalCity.Text = rd("RegionalListedCity").ToString
                ServiceCommission.Text = rd("ServiceCommission").ToString
                'Rb1.Checked = rd("Reminder")
            End While
            rd.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub SendEstabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendEstabase.Click
        Try
            Dim Message As String

            Dim sC As New SmtpClient

            Message = ""
            Message = Message & " <br><br><b> Registration Request  </b><br>"
            Message = Message + " <br> <b> Personal Title: </b>" & PersonalTitle.Text & "<br> "
            Message = Message + " <b>Personal First Name:</b> " & PersonalFirstName.Text & "<br> "
            Message = Message + " <b>Personal Middle Name:</b> " & PersonalMiddleName.Text & "<br> "
            Message = Message + " <b>Personal Last Name:</b> " & PersonalLastName.Text & "<br> "
            Message = Message + " <b> Personal Telephone No: </b>" & PersonalTelephoneNo.Text & "<br> "
            Message = Message + " <b>Personal Address: </b>" & PersonalAddress.Text & "<br>  "
            Message = Message + " <b>Personal Address2: </b>" & PersonalAddress2.Text & "<br>"
            Message = Message + " <b>Personal Email: </b>" & PersonalEmail.Text & "<br> "
            Message = Message + " <b>Company Name: </b> " & CompanyName1.Text & "<br> "
            Message = Message + " <b>Company Business Type: </b>" & CompanyBusinessType.Text & "<br> "
            Message = Message + " <b>Company Address:</b> " & CompanyAddress.Text & "<br> "
            Message = Message + " <b>Company Address2:</b> " & CompanyAddress2.Text & "<br>"
            Message = Message + " <b> Company Telephone No: </b>" & CompanyTelephoneNo.Text & "<br>"
            Message = Message + " <b> Company Fax No: </b>" & CompanyFaxNo.Text & "<br>"
            Message = Message + " <b> Company Website: </b>" & CompanyWebSite.Text & "<br>"
            Message = Message + " <b> Company Email: </b>" & CompanyEmail.Text & "<br>"
            Message = Message + " <b> Regional Country: </b>" & RegionalCountry.Text & "<br>"
            Message = Message + " <b> Regional City: </b>" & RegionalCity.Text & "<br>"
            Message = Message + " <b> Regional Language: </b>" & RegionalLanguage.Text & "<br>"
            Message = Message + " <b> Regional Currency: </b>" & RegionalCurrency.Text & "<br>"
            Message = Message + " <b> Regional Unit Formats: </b>" & RegionalUnitFormats.Text & "<br>"
            Message = Message + " <b> Regional Postal Code: </b>" & RegionalPostalCode.Text & "<br>"
            Message = Message + " <b> Regional Listed Country: </b>" & RegionalListedCountry.Text & "<br>"
            Message = Message + " <b> Regional Listed City: </b>" & RegionalListedCity.Text & "<br>"
            Message = Message + " <b> Service Commission: </b>" & ServiceCommission.Text & "<br>"
            Dim email As String
            If PersonalEmail.Text.Length > 1 Then
                email = PersonalEmail.Text
            Else
                email = CompanyEmail.Text
            End If
            Dim mail As New MailMessage(email, "register@estabase.com")
            If UnitImage1.Text.ToString.Length > 1 Then
                Dim Path As New Attachment("C:\PropertyManager\images\" & UnitImage1.Text)
                mail.Attachments.Add(Path)
            End If
            mail.Subject = "Registration Reguest."
            mail.Body = Message
            mail.IsBodyHtml = True
            Try
                sC.Host = "mail.estabase.com"
            Catch ex As Exception
                sC.Host = "mail.estabase.com"
            End Try
            sC.Send(mail)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub
End Class