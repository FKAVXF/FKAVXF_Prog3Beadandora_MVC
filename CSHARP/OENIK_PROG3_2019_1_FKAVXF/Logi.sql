create table Schools
(
School_Id int not null,
Country varchar(50),
City varchar(50),
ZipCode int,
Address varchar(50),
NumberOfChildren int,
constraint school_primary_key primary key(School_Id)
);
insert into Schools values (1, 'Hungary', 'Budapest', 1033, 'Florian ter 1', 258);
insert into Schools values (2, 'Hungary', 'Budapest', 1039, 'Punkosdfurdo utca 48', 54);
insert into Schools values (3, 'Hungary', 'Szentendre', 2000, 'Paprikabiro utca 21-23', 34);
insert into Schools values (4, 'Hungary', 'Szekesfehervar', 8000, 'Szabadsagharcos ut 59', 76);
insert into Schools values (5, 'Hungary', 'Budapest', 1066, 'Terez korut 46', 156);
insert into Schools values (6, 'Hungary', 'Tatabanya', 2800, 'Tatabanya Martirok utca 81/b', 56);
insert into Schools values (7, 'Croatia', 'Split', 21000, 'Kralja Zvonimira 14', 49);
insert into Schools values (8, 'USA', 'Naples', 34119, '6231 Arbor Blvd W', 78);
insert into Schools values (9, 'Slovakia', 'Komarno', 94501, 'Budova Central, 2. posch. č. d. 303-304.', 48);
insert into Schools values (10, 'Switzerland', 'Zurich', 8045, 'Giesshubelstrasse 64', 420);

create table Owners
(
Owner_Id int not null,
Name varchar(50),
City varchar(50),
StartYear int,
HasPaidThisYear bit,
IsReplaceable bit,
constraint owner_primary_key primary key(Owner_Id)
);
insert into Owners values (1, 'Komuves Pal', 'Budapest', 2010, 1, 0);
insert into Owners values (2, 'Kalaszi Zsofia', 'Dunakeszi', 2015, 1, 0);
insert into Owners values (3, 'Kerekes Erno', 'Split', 2016, 1, 1);
insert into Owners values (4, 'Smith Jackson', 'Vanderbilt Beach', 2011, 0, 1);
insert into Owners values (5, 'Chruschiy Benedek', 'Izsa', 2015, 1, 1);
insert into Owners values (6, 'Sara Berna', 'Zurich', 2019, 0, 0);

create table Teachers
(
Teacher_Id int not null,
School_Id int not null,
Name varchar(50),
Salary int,
StartYear int,
WellLiked bit,
CourseNumber int,
HealthCare varchar(50),
constraint teacher_foreign_key foreign key (School_Id) references Schools(School_Id) ON DELETE CASCADE,
constraint teacher_primary_key primary key(Teacher_Id));

insert into Teachers values (1, 1, 'Kiss Pista', 1000, 2010, 1,10,'statefunded');
insert into Teachers values (2, 1, 'Kanyi Sandor', 2500, 2014, 0,21,'statefunded');
insert into Teachers values (3, 1, 'Szellosi Borbala', 1400, 2019, 1,1,'statefunded');
insert into Teachers values (4, 2, 'Lakatos Mark', 1600, 2018, 1,45,'statefunded');
insert into Teachers values (5, 2, 'Szabolcsi Szilard', 3000, 2018, 1,15,'statefunded');
insert into Teachers values (6, 2, 'Szentes Bertalan', 1000, 2018, 1,21,'statefunded');
insert into Teachers values (7, 2, 'Kovacs Melinda', 500, 2011, 0,15,'statefunded');
insert into Teachers values (8, 3, 'Sved Eniko', 10, 2010, 0,1,'statefunded');
insert into Teachers values (9, 3, 'Jozsefi Hajnalka', 1200, 2015, 0,11,'statefunded');
insert into Teachers values (10, 4, 'Baranya Balint', 190, 2016, 0,13,'statefunded');
insert into Teachers values (11, 4, 'Kevero Sara', 2, 2016, 0,19,'statefunded');
insert into Teachers values (12, 5, 'Kandur Daniel', 1000, 2014, 1,16,'statefunded');
insert into Teachers values (13, 6, 'Kendosi Sarolta', 1660, 2014, 1,39,'statefunded');
insert into Teachers values (14, 6, 'Kendosi Agnes', 350, 2017, 1,21,'statefunded');
insert into Teachers values (15, 6, 'Kendosi Barnabas', 700, 2017, 0,17,'statefunded');
insert into Teachers values (16, 7, 'Kopnec Hjutvik', 3100, 2017, 0,16,'statefunded');
insert into Teachers values (17, 8, 'Jason Glover', 700, 2016, 0,15,'fucked');
insert into Teachers values (18, 8, 'Micheal Labrador', 4240, 2016, 1,11,'fucked');
insert into Teachers values (19, 8, 'Shaquila Connor', 4350, 2013, 1,9,'fucked');
insert into Teachers values (20, 9, 'Polimer Gravkij', 300, 2012, 1,7,'statefunded');
insert into Teachers values (21, 9, 'Sztutmak Ahmed', 900, 2018, 0,6,'statefunded');
insert into Teachers values (22, 10, 'Begner Eger', 1000, 2019, 0,34,'statefunded');
insert into Teachers values (23, 10, 'Nagy Laszlo', 1600, 2019, 0,22,'statefunded');
insert into Teachers values (24, 10, 'Ludwig von Schwarzwald', 1800, 20109, 1,12,'statefunded');

create table OwnerSchoolConnector
(
Connection_Id int not null,
Owner_Id int not null,
School_Id int not null,
constraint connectionSchool_foreign_key foreign key (School_Id) references Schools(School_Id) ON DELETE CASCADE,
constraint connectionOwner_foreign_key foreign key (Owner_Id) references Owners(Owner_Id) ON DELETE CASCADE,
constraint connection_primary_key primary key(Connection_Id)
);

insert into OwnerSchoolConnector values(1,1,1);
insert into OwnerSchoolConnector values(2,1,2);
insert into OwnerSchoolConnector values(3,1,3);
insert into OwnerSchoolConnector values(4,2,4);
insert into OwnerSchoolConnector values(5,2,5);
insert into OwnerSchoolConnector values(6,2,6);
insert into OwnerSchoolConnector values(7,3,7);
insert into OwnerSchoolConnector values(8,4,8);
insert into OwnerSchoolConnector values(9,5,9);
insert into OwnerSchoolConnector values(10,6,10);