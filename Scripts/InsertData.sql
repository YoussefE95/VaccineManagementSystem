insert into Vaccines (Name, DosesRequired, DaysBetween, TotalDosesLeft, TotalDosesReceived)
	Values('Pfizer/BioNTech', 2, 21, 10000, 0);
insert into Vaccines (Name, DosesRequired, DaysBetween, TotalDosesLeft, TotalDosesReceived)
	Values('Johnson & Johnson', 1, null, 5000, 0);
insert into Vaccines (Name, DosesRequired, DaysBetween, TotalDosesLeft, TotalDosesReceived)
	Values('Moderna', 2, 21, 0, 0);

insert into Patients (Name, VaccineId, FirstDose, SecondDose)
	Values('John Doe', 1, '2021/2/18', '2021/3/11');
insert into Patients (Name, VaccineId, FirstDose, SecondDose)
	Values('Jane Doe', 1, '2021/2/18', null);
insert into Patients (Name, VaccineId, FirstDose, SecondDose)
	Values('Tom Smith', 2, '2021/3/12', null);
insert into Patients (Name, VaccineId, FirstDose, SecondDose)
	Values('Jim Lee', 3, '2021/3/12', null);