

CREATE TABLE Line (
	Id int NOT NULL,
	Name varchar (100),
	PRIMARY KEY (Id)
);

CREATE TABLE Station (
	Id int NOT NULL,
	LineId int,
	Code varchar (100),
	Name varchar (100),
	PRIMARY KEY (Id)
);

CREATE TABLE Route (
	Id int NOT NULL,
	DepartStationId int,
	ArrivedStationId int,
	CardFare float,
	FullFare float,
	Duration int,
	PRIMARY KEY (Id)
);

CREATE TABLE People (
	Id int NOT NULL,
	FullName varchar (100),
	CardNumber varchar (20),
	Balance float,
	PRIMARY KEY (Id)
);

CREATE TABLE Trip (
	Id int NOT NULL,
	PeopleId int,
	LineId int,
	UseCard int,
	ReverseWay int,
	PRIMARY KEY (Id)
);
