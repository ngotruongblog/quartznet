# Quartz Asp.net Core
## Step 1: Add package EntityFrameworkCore
![image-2](https://user-images.githubusercontent.com/45006046/157156380-110ce04e-de10-4e52-9cbe-714d346f60a3.png)
## Step 2: Add model
![image-1](https://user-images.githubusercontent.com/45006046/157156460-4403afd0-92fd-4d7f-a657-fc1a12da3383.png)
## Step 3: Create DbContext
![image-7](https://user-images.githubusercontent.com/45006046/157156549-25a3eef6-79b8-4bdd-9f74-dcb5fed320db.png)
## Step 4: Add code in Startup.cs
![image-3](https://user-images.githubusercontent.com/45006046/157156634-99c54986-295d-45b0-ae9e-4cb41a424d6f.png)
## Step 5: Open Package Manager Console panel at visual and run command to create database
![image-5](https://user-images.githubusercontent.com/45006046/157156738-2be60cba-1abd-4c7d-9477-0f7ed36c646e.png)
## Step 6: Add package Quartz
![image-6](https://user-images.githubusercontent.com/45006046/157156922-bb87e555-d173-4ceb-a697-a411266a982f.png)
## Step 7: Config appsetting.json
![image-8](https://user-images.githubusercontent.com/45006046/157156974-a9247036-6a93-4bc9-8f20-b9dd30478114.png)
*We are using sql server to save the job. One point to note is quartz.plugin.timeZoneConverter.type, when adding this configuration, when deploying to docker or server systems, you will not worry about Time Zone related problems.*
## Step 8: Go to Quartz's github page to copy the script to create the schema database (here I'm using sql server for demo). Then, run that script at the database as configured in step 7.
![image-9](https://user-images.githubusercontent.com/45006046/157157407-ef465abf-3c9d-4147-9bea-e5a71f366735.png)
*Result after running script:*
![image-10](https://user-images.githubusercontent.com/45006046/157157483-24392810-1b4e-45d9-856b-59f1a01cd22b.png)
## Step 9: Configure Quartz at Startup.cs
![image-11](https://user-images.githubusercontent.com/45006046/157157609-b6be13c2-f731-454d-9565-05455e3a401e.png)
*Here is a point to note that when we configure Quartz with quartz.extensions.dependencyinjection, we will be able to inject the services into the Job.*
## Step 10: Create a service to add, delete and edit data
![image-12](https://user-images.githubusercontent.com/45006046/157157821-e5433cc7-722f-4ece-ac31-550097d7879c.png)
## Step 11: Create job write data
![image-14 (1)](https://user-images.githubusercontent.com/45006046/157157961-e6c5c2e9-0110-4908-8dc3-2ff8e586701e.png)
## Step 12: Create a controller to create endpoints for job creation, start schedule, ...
![image-15](https://user-images.githubusercontent.com/45006046/157158015-170fd08a-1fb8-4f50-b0b4-3b693cbb9442.png)

*The End*
