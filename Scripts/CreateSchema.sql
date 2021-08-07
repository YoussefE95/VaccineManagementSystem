drop table if exists Patients;
drop table if exists Vaccines;

create table Vaccines (
	Id int identity(1, 1) primary key,
	Name varchar(150),
	DosesRequired int,
	DaysBetween int null,
	TotalDoses bigint
);

create table Patients (
	Id int identity(1, 1) primary key,
	Name varchar(150),
	VaccineId int,
	FirstDose datetime2 not null,
	SecondDose datetime2 null,
	FOREIGN KEY (VaccineId) REFERENCES Vaccines(Id)
);