create database publicationmanagement
use publicationmanagement

create table Registartiondata
(
id int primary key identity,
Fullname varchar(50),
MobileNumber varchar(12),
Email varchar(50),
password varchar(50),
Address varchar(50),
)

--creating a sp_registration

create procedure sp_Registration
@Fullname varchar(50),
@MobileNumber varchar(12),
@Email varchar(50),
@password varchar(50),
@Address varchar(50)
as
begin
insert into Registartiondata(Fullname,MobileNumber,Email,password,Address)values(@Fullname,@MobileNumber,@Email,@password,@Address)
end

execute sp_Registration 'varun','8309431669','123@gmail.com','12345','pls'

create Procedure Sp_login
@Email varchar(50),
@Password varchar(50)
as
begin
select * from Registartiondata where Email=@Email and password=@Password
end
execute Sp_login '123@gmail.com','12345'

create table publishing
(
id int primary key identity,
Publicationdetail varchar(50),
Publishername varchar(50),
Dateofpublish date default CURRENT_TIMESTAMP,
PublisherType varchar(50)
)

select * from publishing
alter procedure sp_publishing
@Publicationdetail varchar(50),
@Publishername varchar(50),
@PublisherType varchar(50)
as
begin
insert into publishing(Publicationdetail,Publishername,PublisherType)values(@Publicationdetail,@Publishername,@PublisherType)
insert into CombinedPublish(Publicationdetail,Publishername,PublisherType)values(@Publicationdetail,@Publishername,@PublisherType)

end

select * from publishing


ALTER TABLE publishing ALTER COLUMN Dateofpublish set DEFAULT CURRENT_TIMESTAMP;

create procedure sp_viewdata
as
begin
select * from publishing
end

execute sp_viewdata

create table Facultypublish
(
id int primary key identity,
Publicationdetail varchar(50),
Publishername varchar(50),
Dateofpublish date default CURRENT_TIMESTAMP,
PublisherType varchar(50)
)

alter procedure sp_facultypublishing
@Publicationdetail varchar(50),
@Publishername varchar(50),
@PublisherType varchar(50)
as
begin
insert into Facultypublish(Publicationdetail,Publishername,PublisherType)values(@Publicationdetail,@Publishername,@PublisherType)
insert into CombinedPublish(Publicationdetail,Publishername,PublisherType)values(@Publicationdetail,@Publishername,@PublisherType)

end


create procedure sp_facultyviewdata
as
begin
select * from Facultypublish
end

create procedure alldata
as
begin
select * from publishing unionall select * from Facultypublish
end

execute alldata

select * from publishing unionall select * from Facultypublish

CREATE TABLE CombinedPublish
(
    id INT PRIMARY KEY IDENTITY,
    Publicationdetail VARCHAR(50),
    Publishername VARCHAR(50),
    Dateofpublish DATE DEFAULT CURRENT_TIMESTAMP,
    PublisherType VARCHAR(50),
);


select * from CombinedPublish


create procedure sp_Alldata
as
begin
select * from CombinedPublish
end
execute  sp_Alldata

create procedure sp_countallpublishers
as
begin
select  count(Publicationdetail) as No_Of_Publishers  from CombinedPublish
end

execute sp_countallpublishers

alter procedure sp_countpublishers
as
begin
select  count(Publicationdetail) as No_Of_Publishers  from publishing
end

execute sp_countpublishers

create procedure sp_countfacultypublishers
as
begin
select  count(Publicationdetail) as No_Of_Publishers  from Facultypublish
end

execute sp_countpublishers

delete 