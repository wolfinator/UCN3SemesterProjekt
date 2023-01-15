declare @StartTime as datetime = cast('2022-12-20 12:00:00' as datetime)

--SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
go
BEGIN TRANSACTION
go
select * from reservation
where start_time = cast('2022-12-22 12:00:00' as datetime)
and court_court_no = 1
go
waitfor delay '00:00:05'
insert into reservation values
(
CAST('2022-12-12 12:34:56' as datetime), 
cast('2022-12-22 12:00:00' as datetime),
cast('2022-12-22 12:00:00' as datetime) + CAST('01:00:00' as datetime),
1,
4,
1,
1
)
go
commit transaction
go
