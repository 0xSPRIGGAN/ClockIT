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
        WDM.SetUpDriver(New EdgeConfig())

        Dim driver As New EdgeDriver()
        Dim inputUserId, inputPin, loginButton As IWebElement ' These may change if the id value of these elements change
        Dim userId As String = "123456"
        Dim pin As String = "123456"
        Dim url As String = "https://time.frontlineeducation.com/clock"
        Dim timeBetweenInput As Integer = 2000

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
