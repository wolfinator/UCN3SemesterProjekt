INSERT into CityZip (zipcode, city) VALUES ('9000', 'Aalborg')
INSERT into CityZip (zipcode, city) VALUES ('9220', 'Aalborg Øst')
INSERT into CityZip (zipcode, city) VALUES ('8850', 'Bjerringbro')
INSERT into CityZip (zipcode, city) VALUES ('8000', 'Aarhus')

INSERT into _Address (street, house_no, city_zipcode) 
VALUES ('Nørregade', '3', '9000')
INSERT into _Address (street, house_no, city_zipcode) 
VALUES ('Langagervej', '20', '9220')
INSERT into _Address (street, house_no, city_zipcode) 
VALUES ('Vejen vej', '99', '9220')
INSERT into _Address (street, house_no, city_zipcode) 
VALUES ('Bøgeskov vej', '54', '8850')
INSERT into _Address (street, house_no, city_zipcode) 
VALUES ('Kirsebærvej', '2', '9000')
INSERT into _Address (street, house_no, city_zipcode) 
VALUES ('Østerbro', '4', '8000')

INSERT into Person (f_name, l_name, email, phone_no, _role, address_id) 
VALUES ('Karsten', 'Jensen', 'kj@mail.com','29384726', 'Customer', 1)
INSERT into Person (f_name, l_name, email, phone_no, _role, address_id) 
VALUES ('Gitte', 'Poulsen', 'gp@badminton.com','37485928', 'Customer', 2)
INSERT into Person (f_name, l_name, email, phone_no, _role, address_id) 
VALUES ('Birgit', 'Hansen', 'bh@mail.com','28374950', 'Customer', 3)
INSERT into Person (f_name, l_name, email, phone_no, _role, address_id) 
VALUES ('Mike', 'Wazowski', 'mw@badminton.com','12934365', 'Customer', 4)
INSERT into Person (f_name, l_name, email, phone_no, _role, address_id) 
VALUES ('Piña', 'Co Lada', 'pcl@badminton.com','97548234', 'Customer', 5)
INSERT into Person (f_name, l_name, email, phone_no, _role, address_id) 
VALUES ('Mester', 'Jakob', 'mj@badminton.com','00123405', 'Customer', 6)

INSERT into Court VALUES (1)
INSERT into Court VALUES (2)
INSERT into Court VALUES (3)

insert into TimeSlot values (cast('09:00:00' as time))

INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id, employee_id) 
VALUES                  ('2022-11-20 09:56:32.543', '2022-11-23 10:00:00.000', '2022-11-23 11:00:00.000',
						 1,                2,                 1,              1 ,          NULL)
INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id, employee_id) 
VALUES                  ('2022-11-20 10:21:33.983', '2022-11-23 11:00:00.000', '2022-11-23 12:00:00.000',
						 1,                3,                 1,              2 ,          NULL)
INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id, employee_id) 
VALUES                  ('2022-11-21 19:36:21.256', '2022-11-23 13:00:00.000', '2022-11-23 14:00:00.000',
						 1,                0,                 1,              3 ,          NULL)
INSERT into Reservation (creation_date,               start_time,                   end_time, 
                         shuttle_reserved, number_of_rackets, court_court_no, customer_id, employee_id) 
VALUES                  ('2022-11-03 13:32:11.234', '2022-11-25 13:00:00.000', '2022-11-25 14:00:00.000',
						 0,                4,                 2,              4 ,          NULL)

INSERT into Invoice (total_price, reservation_id) VALUES (200, 1)
INSERT into Invoice (total_price, reservation_id) VALUES (200, 2)
INSERT into Invoice (total_price, reservation_id) VALUES (200, 3)
INSERT into Invoice (total_price, reservation_id) VALUES (150, 4)