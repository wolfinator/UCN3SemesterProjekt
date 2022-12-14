drop table if exists timeslot
drop table if exists invoice;
drop table if exists reservation;
drop table if exists court;
drop table if exists _address;
drop table if exists customer;
drop table if exists cityzip;

create table CityZip(
zipcode char(4),
city nvarchar(30),
primary key(zipcode)
)

create table Customer(
id int identity(1,1) not null,
f_name nvarchar(30), 
l_name nvarchar(30),
email nvarchar(50),
phone_no char(8),
primary key (id)
)

create table _Address(
id int identity(1,1) not null,
street nvarchar(30),
house_no varchar(5),
city_zipcode char(4) not null foreign key references cityzip(zipcode),
customer_id int not null foreign key references customer(id)
on delete cascade,
primary key (id)
)


create table Court(
court_no int not null,
primary key(court_no)
)

create table Reservation(
id int identity(1,1) not null,
creation_date datetime,
start_time datetime,
end_time datetime,
shuttle_reserved bit,
number_of_rackets int,
court_court_no int not null foreign key references court(court_no),
customer_id int not null foreign key references customer(id) on delete cascade,
primary key(id)
)

create table Invoice(
id int identity(1,1) not null,
total_price decimal,
reservation_id int not null foreign key references reservation(id)
on delete cascade,
primary key(id)
)

create table TimeSlot(
time_slot time not null,
primary key(time_slot)
)