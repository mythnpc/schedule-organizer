## ScheduleOrganizer

Tech Stack:
- .Net Core 2.0 Web Api
- Entity Framework (ORM)
- Liquibase for DB Migration 
- SQL Express 2017 

The Api part of ScheduleOrganizer.Ui
The purpose of this project is to create a website for my clan in Kings Raid. This planned features for this project are :-
1. Attendance view of who have finished Hard Mode raids for dragons (Done)
2. View to see heroes available within the game and the hero details (In Progress)
3. Ability for members to register their details 
4. Ability for members to see the heroes they owned and their heroes details


### Set Up 

This project need to be run in conjunction with [ScheduleOrganizer](https://github.com/mythnpc/schedule-organizer)
1. Download and install SQL Express 2017 and Liquibase  
2. Clone the project 
3. Install and set up liquibase https://www.mssqltips.com/sqlservertip/4340/sql-server-database-change-management-with-liquibase/
4. CD to ScheduleOrganizer.Database and run liquibase script 
	liquibase 
	 --driver=com.microsoft.sqlserver.jdbc.SQLServerDriver 
	 --classpath="C:\\Program Files\\Microsoft JDBC Driver 4.0 for SQL Server\\sqljdbc_4.0\\enu\\sqljdbc4.jar" 
	 --url="jdbc:sqlserver://<SQL Server name or IP>:1433;databaseName=liquibase_test;integratedSecurity=false;" 
	 --changeLogFile="<Changelog file location>" 
	 --username=liquibase 
	 --password=liquibase  
	 Update
5. Ready to use! 