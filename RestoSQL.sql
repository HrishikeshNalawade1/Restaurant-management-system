Create Database Restaurant;
use Restaurant 
Create Table RestoName(
rset_id int not null Primary key,
Name varchar (50),
OpenTime int not null,
CloseTime int not null,
Phone Bigint not null,
Addres varchar(200),
Cuisine varchar(50),
)
select *from RestoName;

