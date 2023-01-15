declare @StartTime as datetime = cast('2022-12-20 10:00:00' as datetime)

--SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
go
BEGIN TRANSACTION
go
select * from reservation
where start_time = cast('2022-12-22 12:00:00' as datetime)
and court_court_no = 1
go
insert into reservation values
(
CAST('2022-12-12 12:34:56' as datetime), 
cast('2022-12-22 12:00:00' as datetime),
cast('2022-12-22 12:00:00' as datetime) + CAST('01:00:00' as datetime),
0,
2,
1,
2
)
go
waitfor delay '00:00:05'
commit transaction
go
