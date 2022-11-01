# ClockIT
An automated way of clocking into the [Frontline Education Time & Attendance](https://time.frontlineeducation.com/clock) system.

In order to currently use the app, it must be compiled on a per-user basis.

- Open the project in Visual Studio 2022 (Community)
- Under `Program.vb` you must change a few variables first before starting...
1. Change `userID` to your KIOSK ID/PHONE NUMBER 
2. Change `pin` to your KIOSK PIN
3. Change `url` to the specific frontline education url that your organization uses ( May look something like this https://time.frontlineeducation.com/clockOrg=1234567&KID=1234567 )

<br>

Now that the variables are set, we need to publish the program so you get a nice ClockIT.exe file you can run from anywhere.

In Visual Studio 2022 Community:
- Go to `Build` -> `Publish Selection`
- Click `Show all settings` under the `Settings` menu that just popped up

Set the following Profile Settings
1. `Configuration` = `Release | Any CPU`
2. `Target framework` = `net6.0`
3. `Deployment mode` = `Framework-dependent`
4. `Target runtime` = `win-x64`
5. `Target location` = `bin\Release\net6.0\publish\win-x64\`
- Click `File publish options`
6. Check the box that says `Produce single file`

- Now Save your settings.

<br>

After saving, you can now press the `Publish` button.
This will build the project and create a new ClockIT.exe file.

- There will be a green box saying `"Publish succeeded on xx/xx/xxxx at xx:xx"`

Inside the green box, click the text that says `"Open folder"`

<br>

Now you have your clock in automation ready to go. 
