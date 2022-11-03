create table CityZip(
zipcode char(4),
city nvarchar(30),
primary key(zipcode)
)

create table _Address(
id int identity(1,1) not null,
street nvarchar(30),
house_no varchar(5),
city_zipcode char(4) foreign key references cityzip(zipcode),
primary key (id)
)

create table Person(
id int identity(1,1) not null,
f_name nvarchar(30), 
l_name nvarchar(30),
email nvarchar(50),
phone_no char(8),
person_type char(1),
address_id int not null foreign key references _Address(id),
primary key (id)
)

create table Court(
id int identity(1,1) not null,
is_available bit,
from_time time,
to_time time,
primary key(id)
)

create table Reservation(
id int identity(1,1) not null,
date_time datetime,
is_equipment bit,
court_id int not null foreign key references court(id),
primary key(id)
)

create table Invoice(
id int identity(1,1) not null,
total_price decimal,
reservation_id int not null foreign key references reservation(id),
person_id int not null foreign key references person(id),
primary key(id)
)
