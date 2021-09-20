Create Database Restaurant;
use Restaurant 
Create Table resto(
rset_id int not null Primary key,
name varchar (50),
Open_time int not null,
close_time int not null,
Phoneno Bigint not null,
Address varchar(200),
Cuisine varchar(50),
Status varchar(20)
)
select *from resto;
