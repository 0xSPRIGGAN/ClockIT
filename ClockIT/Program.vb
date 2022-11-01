'
' Author: Connor Hudson
' Date: October 31, 2022
'
' This app will launch the Edge browser and automate clocking in using
' the Frontline Time & Attendance service.
' 
' Change userId to your user ID, usually a 5 or 6 digit number, such as '123456'
' Change pin to you login pin, usually a 4-8 digit pin, such as '1234567'
' Change the URL to the URL your organization uses to clock in.
' Change timeBetweenInput (in milliseconds) to however long you would like to wait between inputs.
'
' Build the project after changing the variables and publish to a .exe file for easy use.
'

Imports System.Threading
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Edge
Imports WebDriverManager.DriverConfigs.Impl

Module Program
    Sub Main()

        Dim WDM As New WebDriverManager.DriverManager()

        ' 107.0.1418.28 does not yet exist at https://msedgedriver.azureedge.net (at the time of writing this).
        ' This causes a 404 error when trying to GET req the server for that version,
        ' so we  manually choose 107.0.1418.26 for the time being.
        Try
            WDM.SetUpDriver(New EdgeConfig(), "107.0.1418.26")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        ClockIN()

    End Sub

    Sub ClockIN()

        Dim driver As New EdgeDriver()
        Dim inputUserId, inputPin, loginButton As IWebElement ' These may change if the id value of these elements change
        Dim userId As String = "12345"
        Dim pin As String = "654321"
        Dim url As String = "https://time.frontlineeducation.com/clock"
        Dim timeBetweenInput As Integer = 5000

        driver.Navigate().GoToUrl(url)

        inputUserId = driver.FindElement(By.Id("userId"))
        inputPin = driver.FindElement(By.Id("pin"))
        loginButton = driver.FindElement(By.Id("loginButton"))

        inputUserId.SendKeys(userId)
        Thread.Sleep(timeBetweenInput)
        inputPin.SendKeys(pin)
        Thread.Sleep(timeBetweenInput)
        loginButton.Click()
        Thread.Sleep(timeBetweenInput)

        driver.Quit()

    End Sub

End Module
