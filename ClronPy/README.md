# SystemManage

#### Instructions

Based on. netcore

#### 软件架构

面向接口编程。

#### 技术说明

1. .NetCore6
2. MySql
3. SqlSugarCore
4. IronPython
5. AutoMapper
6. CsvHelper.Excel.Core
7. Layui

#### 使用说明
1. 用Visual Studio 2022打开项目。
2. 右键ClronPy，选择发布，选择文件夹，选择要发布的路径，点击完成。
3. 点击所以设置，选择部署模式为独立，部署目标运行时为win-64可以运行在Windows上、Linux-64可运行在Linux上，点击保存，点击发布。
4. 在目标服务器安装好数据库 MySql，还原sql目录下的db.sql文件。
5. 在项目根目录下appsettings.json配置数据库链接字符串。
6. 在Windows环境下直接运行发布后的目录里的ClronPy.exe，在Linux下运行./ClronPy


