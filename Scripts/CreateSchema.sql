drop table if exists Vaccines;

create table Vaccines (
	Id int not null identity(1, 1),
	Name varchar(150),
	DosesRequired int,
	DaysBetween int,
	TotalDoses bigint
);