drop table if exists Patients;
drop table if exists Vaccines;

create table Vaccines (
	Id int auto_increment primary key,
	Name varchar(150),
	DosesRequired int,
	DaysBetween int null,
	TotalDosesLeft bigint,
	TotalDosesReceived bigint
);

create table Patients (
	Id int auto_increment primary key,
	Name varchar(150),
	VaccineId int,
	FirstDose date not null,
	SecondDose date null,
	FOREIGN KEY (VaccineId) REFERENCES Vaccines(Id)
);