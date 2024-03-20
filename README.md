# Time Stamp MVC - Documentation

## 1. Tech Stack

- ### .NET Core MVC App
- ### Docker and Docker-Compose
- ### Entity Framework
- ### .NET 8
- ### Bootstrap

<br>

![Web UI Preview](PicturesReadme/WebUI.png)

<br>
## 2. Running with Postgres DB Image in the Container

The solution must be built without errors. Then, the NuGet console should be invoked with this command if there is no existing migration in the source code:

- **Command in PowerShell:** `add-migration <name>` - The migration is now visible in the project.

Then, just start the app with `docker-compose build` and `docker-compose up`. It will apply the migration and sample data via class extension.

<br>

![Docker Desktop View](PicturesReadme/DockerDesktopView.png)

<br>

## 3. Application Function

### MVC API .NET Core: Stamps System

A backend for Arduino that manages the employees and their cards for time

### Time stamp:

#### Api:


#### Method: POST 

#### Route: /stamp/new

#### Body: 
#### {
####	badgeId: 123456
####	stampId: “A2:A3:A4:A5”
#### }

#### Result:
#### {
####	Status: true or false
####	Employeename: “example name”
####	Datetime: datetime
#### }


#### Action Steps:
####    1) on received post, api select from “vw_assignedbadge” the owner of the badge, take first record if exist, if not exist return false.
####    2) If exist select from table “stamper” the name of the stamper based on stampid else return false
####    3) Select on table “stamp” if exist any record for employee based on employeeid return on step 1, if exist check if last one based on timestamp is with status “IN”
####    4) Insert into table “stamp” a new record with the data obtained from previous steps, if step 3 found that last record was “IN” then insert the new record as “OUT” else as “IN”


#### Door open

#### Api
#### 
#### Method: POST
#### Route: /security/opendoor
#### Body: 
#### {
#### 	badgeId: 123456
#### 	stampId: “A2:A3:A4:A5”
#### }
#### Result:
#### {
#### 	Status: true or false
#### 	Employeename: “example name”
#### 	Datetime: datetime
#### }
#### 
#### Action steps:
####     1) on received post, api select from “vw_assignedbadge” the owner of the badge, take first record if exist, if not exist return false.
####     2) If exist select from table “stamper” the name of the stamper based on stampid else return false
####     3) If previous steps ok, call api:
####         a. http://10.0.155.249/relay/0?turn=on with authorization berear "Authorization: Basic YWRtaW46UGFzc3dvcmQwMQ=="
####     4) Return value true

<br>

![](PicturesReadme/ApiView.png)

<br>

## 4. Database Structure

The database is a PostgreSQL image in a Docker container which is created over docker-compose. The connection string is in the config file (appsettings.json) and is set to localhost for Windows and db for Linux servers.

### Employees

CREATE TABLE "Employees" (  
  "Id" INTEGER NOT NULL,  
  "GivenName" TEXT NULL DEFAULT NULL,  
  "Surname" TEXT NULL DEFAULT NULL,  
  "Email" TEXT NULL DEFAULT NULL,  
  PRIMARY KEY ("Id")  
);

### Cards

CREATE TABLE "Cards" (  
  "Id" INTEGER NOT NULL,  
  "EmployeeId" INTEGER NOT NULL,  
  "IssueDate" TIMESTAMPTZ NOT NULL,  
  "ExpiryDate" TIMESTAMPTZ NOT NULL,  
  "ForTime" BOOLEAN NOT NULL,  
  "ForDoor" BOOLEAN NOT NULL,  
  "IsActive" BOOLEAN NOT NULL,  
  "EmployeeId" INTEGER NULL DEFAULT NULL,  
  PRIMARY KEY ("Id"),  
  INDEX "IX_Cards_EmployeeId" ("EmployeeId"),  
  CONSTRAINT "FK_Cards_Employees_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employees" ("Id") ON UPDATE NO ACTION ON DELETE NO ACTION  
);

### Stamps

CREATE TABLE "Stamps" (  
  "Id" INTEGER NOT NULL,  
  "CardId" INTEGER NULL DEFAULT NULL,  
  "TimeStamp" TIMESTAMPTZ NOT NULL,  
  "StampType" INTEGER NOT NULL,  
  "Status" INTEGER NULL DEFAULT NULL,  
  PRIMARY KEY ("Id"),  
  INDEX "IX_Stamps_CardId" ("CardId"),  
  CONSTRAINT "FK_Stamps_Cards_CardId" FOREIGN KEY ("CardId") REFERENCES "Cards" ("Id") ON UPDATE NO ACTION ON DELETE NO ACTION  
);

One employee should have one active card and unlimited old cards. One card has unlimited stamps either as stamp type 0 = time stamp or 1 = door stamp. The stamp is In = 0, out = 1 or null = door stamp.

<br>

![](PicturesReadme/DatabaseView.png)

<br>

## 5. SSL Configuration and Hosting

### Certificates

The app has a dev certificate in its root directory which is for testing in docker-compose. If the app is on the server it overrides with the productive certificate on the volume root of the vps server. The app has http -> https redirection in Program.cs on application level, which forwards the inside docker port 80 to 443. This needs to be removed when using on a server with nginx server management.
