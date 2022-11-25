declare @current_date as datetime
set @current_date = '2022-11-23'

select c.court_no, t.time_slot from Court c, timeslot t
except(
select c.court_no, t.time_slot from Court c, timeslot t, reservation r 
where @current_date < r.start_time
and r.end_time < @current_date+1
and c.court_no = r.court_court_no
and cast(r.start_time as time) = t.time_slot
)

/*
select @current_date + cast(cast('09:00:00' as time) as datetime) as TimeSlot
union all select @current_date + cast(cast('10:00:00' as time) as datetime)
union all select @current_date + cast(cast('11:00:00' as time) as datetime)
union all select @current_date + cast(cast('12:00:00' as time) as datetime)
union all select @current_date + cast(cast('13:00:00' as time) as datetime)
union all select @current_date + cast(cast('14:00:00' as time) as datetime)
union all select @current_date + cast(cast('15:00:00' as time) as datetime)
union all select @current_date + cast(cast('16:00:00' as time) as datetime)
union all select @current_date + cast(cast('17:00:00' as time) as datetime)
union all select @current_date + cast(cast('18:00:00' as time) as datetime)
except(
select r.start_time from reservation r 
where @current_date < r.start_time
and r.end_time < @current_date+1
)

select c.court_no, TimeSlot from Court c,
(values 
(@current_date + cast(cast('09:00:00' as time) as datetime)), 
(@current_date + cast(cast('10:00:00' as time) as datetime)), 
(@current_date + cast(cast('11:00:00' as time) as datetime)),
(@current_date + cast(cast('12:00:00' as time) as datetime)),
(@current_date + cast(cast('13:00:00' as time) as datetime)),
(@current_date + cast(cast('14:00:00' as time) as datetime)),
(@current_date + cast(cast('15:00:00' as time) as datetime)),
(@current_date + cast(cast('16:00:00' as time) as datetime)),
(@current_date + cast(cast('17:00:00' as time) as datetime)),
(@current_date + cast(cast('18:00:00' as time) as datetime))
) x(TimeSlot)
except(
select r.start_time from reservation r 
where @current_date < r.start_time
and r.end_time < @current_date+1
)
*/