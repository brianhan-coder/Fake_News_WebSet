# SystemManage

#### Instructions

Based on. netcore

#### Software Architecture

Interface-oriented programming.

#### Technical Description

1. .NetCore6
2. MySql
3. SqlSugarCore
4. IronPython
5. AutoMapper
6. CsvHelper.Excel.Core
7. Layui

#### Instructions for use
1. Open the project with Visual Studio 2022.
2. Right-click ClronPy, select Publish, select the folder, select the path where you want to publish, and click Finish.
3. Click So Setup, select Deployment Mode as Standalone, deploy the target runtime as Win-64 can run on Windows, Linux-64 can run on Linux, click Save, click Publish.
4. Install the database MySql on the target server and restore the db.sql file in the sql directory.
5. Configure the database link string in appsettings.json in the project root directory.
6. Run ClronPy.exe directly from the published directory under Windows environment, under Linux run . /ClronPy

