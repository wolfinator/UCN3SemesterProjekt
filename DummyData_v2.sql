INSERT into CityZip (zipcode, city) VALUES ('9000', 'Aalborg')
INSERT into CityZip (zipcode, city) VALUES ('9220', 'Aalborg Øst')
INSERT into CityZip (zipcode, city) VALUES ('8850', 'Bjerringbro')
INSERT into CityZip (zipcode, city) VALUES ('8000', 'Aarhus')

INSERT into Customer (f_name, l_name, email, phone_no) 
VALUES ('Karsten', 'Jensen', 'kj@mail.com','29384726')
INSERT into Customer (f_name, l_name, email, phone_no) 
VALUES ('Gitte', 'Poulsen', 'gp@badminton.com','37485928')
INSERT into Customer (f_name, l_name, email, phone_no) 
VALUES ('Birgit', 'Hansen', 'bh@mail.com','28374950')
INSERT into Customer (f_name, l_name, email, phone_no) 
VALUES ('Mike', 'Wazowski', 'mw@badminton.com','12934365')
INSERT into Customer (f_name, l_name, email, phone_no) 
VALUES ('Piña', 'Co Lada', 'pcl@badminton.com','97548234')
INSERT into Customer (f_name, l_name, email, phone_no) 
VALUES ('Mester', 'Jakob', 'mj@badminton.com','00123405')

INSERT into _Address (street, house_no, city_zipcode, customer_id) 
VALUES ('Nørregade', '3', '9000', 1)
INSERT into _Address (street, house_no, city_zipcode, customer_id) 
VALUES ('Langagervej', '20', '9220', 2)
INSERT into _Address (street, house_no, city_zipcode, customer_id) 
VALUES ('Vejen vej', '99', '9220', 3)
INSERT into _Address (street, house_no, city_zipcode, customer_id) 
VALUES ('Bøgeskov vej', '54', '8850', 4)
INSERT into _Address (street, house_no, city_zipcode, customer_id) 
VALUES ('Kirsebærvej', '2', '9000', 5)
INSERT into _Address (street, house_no, city_zipcode, customer_id) 
VALUES ('Østerbro', '4', '8000', 6)



INSERT into Court VALUES (1)
INSERT into Court VALUES (2)
INSERT into Court VALUES (3)

insert into TimeSlot values (cast('09:00:00' as time))
insert into TimeSlot values (cast('10:00:00' as time))
insert into TimeSlot values (cast('11:00:00' as time))
insert into TimeSlot values (cast('12:00:00' as time))
insert into TimeSlot values (cast('13:00:00' as time))
insert into TimeSlot values (cast('14:00:00' as time))
insert into TimeSlot values (cast('15:00:00' as time))
insert into TimeSlot values (cast('16:00:00' as time))
insert into TimeSlot values (cast('17:00:00' as time))
insert into TimeSlot values (cast('18:00:00' as time))

INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id) 
VALUES                  ('2022-11-20 09:56:32.543', '2022-11-23 10:00:00.000', '2022-11-23 11:00:00.000',
						 1,                2,                 1,              1)
INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id) 
VALUES                  ('2022-11-20 10:21:33.983', '2022-11-23 11:00:00.000', '2022-11-23 12:00:00.000',
						 1,                3,                 1,              2)
INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id) 
VALUES                  ('2022-11-21 19:36:21.256', '2022-11-23 13:00:00.000', '2022-11-23 14:00:00.000',
						 1,                0,                 1,              3)
INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id) 
VALUES                  ('2022-11-03 13:32:11.234', '2022-11-25 13:00:00.000', '2022-11-25 14:00:00.000',
						 0,                4,                 2,              4)

INSERT into Invoice (total_price, reservation_id) VALUES (200, 1)
INSERT into Invoice (total_price, reservation_id) VALUES (200, 2)
INSERT into Invoice (total_price, reservation_id) VALUES (200, 3)
INSERT into Invoice (total_price, reservation_id) VALUES (150, 4)