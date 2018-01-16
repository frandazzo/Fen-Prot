insert into Book_CalendarDate (CalendarDate)
select [date] from [dbo].[TempDateTable]('19000101', '20501231')