--Instructions
--just create the tables by executing the queries given below
--Note: Execute All the Queries in the Given Order Only

create database sms

use sms

create table tab_Admin(
Emp_Id int primary key,
Emp_Name varchar(50),
F_Name varchar(50),
contact varchar(13),
CNIC varchar(13),
BirthDate date,
Staff_Address varchar(100),
Gender varchar(6),
Email varchar(50),
userName varchar(50),
pass varchar(50),
Designation varchar(50),
Department varchar(50),
Depart_Id int,
Monthly_Pay int,
);

insert into tab_Admin values(786,'Izhan Yameen','Yameen Baig','03328932280','4210184211168','1996-04-25','House no 191, Street 1, block 5, Liaquatabad, karachi','Male','izhan.yameen@gmail.com','admin','apass','Administrater','Administration',000,150000)

select * from tab_Admin

create table Std_Management(
Std_Id int primary key,
name varchar(50),
F_Name varchar(50),
BirthDate date,
Age int,
Gender varchar(6),
H_Contact varchar(13),
H_Address varchar(300),
Class int,
Batch_No varchar(20),
Monthly_Fee int,
Exam_Fee int,
Admit_Year int,
userName varchar(50),
pass varchar(50),
Email varchar(50) 
);

select * from Std_Management where name like '%a%';


create table Staff_Management(
Emp_Id int primary key,
Emp_Name varchar(50),
F_Name varchar(50),
contact varchar(13),
CNIC varchar(13),
BirthDate date,
Staff_Address varchar(100),
Gender varchar(6),
Email varchar(50),
userName varchar(50),
pass varchar(50),
Designation varchar(50),
Department varchar(50),
Depart_Id int,
Monthly_Pay int,
);

select * from Staff_Management

create table Test_Rcard(
Std_Id int ,
Name varchar(50),
Class int,
Batch_No varchar(20),
Test_Month varchar(15),
Sub varchar(15),
Test_Id int,
Total int,
Obtained int,
Percentage int,
Remarks varchar(500),
Teacher varchar(50),
Emp_Id int 
);

select * from Test_Rcard

create table Exam_Rcard(
Std_Id int,
Name varchar(50),
Class int,
Batch_No varchar(20),
Exam varchar(15),
English int,
Urdu int,
Math int,
Science int,
Sst int,
Arts int,
Computer int,
Islamiat int,
Total int,
Obtained int,
Percentage int,
Grade varchar(5),
Remarks varchar(500),
Teacher varchar(50),
Emp_Id int
);


select * from Exam_Rcard
truncate table Exam_Rcard


create table Fee_Management(
Dated date,
Std_Id int,
Name varchar(50),
Class int,
Batch_No varchar(20),
Amount int,
FeeType varchar(10),
FeeMonth varchar(10),
Emp_Id int,
Emp_Name varchar(50)
);

select * from Fee_Management


create table Assign_Class(
Class int,
Batch_No varchar(20),
Sub varchar(20),
Emp_Id int,
Emp_Name varchar(50),
);


select * from Assign_Class




--done Now you can stop executing queries
--end here



--to drop tables use folowing queries

drop table Assign_Class
drop table Exam_Rcard
drop table Fee_Management
drop table Staff_Management
drop table Std_Attendance
drop table Std_Management
drop table Syllabus
drop table Test_Rcard
drop table Time_Table


--Extra Tables

create table Time_Table(
class int,
Batch_No varchar(20),
Monday varchar(200),
Tuesday varchar(200),
Wednesday varchar(200),
Thursday varchar(200),
Friday varchar(200),
Saturday varchar(200),
Sunday varchar(200),
);

select * from Time_Table

create table Std_Attendance(
Std_Id int primary key,
Name varchar(50),
Class int,
Batch_No varchar(20),
A_Month varchar(10),
S_Present int,
S_Absent int,
Total_Days int,
A_Percentage int,
Remarks varchar(500)
);

select * from Std_Attendance

create table Syllabus(
class int,
Batch_No varchar(20),
Syllabus_Type varchar(30),
File_Path varchar(500)
);

select * from Syllabus