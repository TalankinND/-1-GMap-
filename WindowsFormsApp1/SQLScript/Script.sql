CREATE DATABASE map;

IF OBJECT_ID ('dbo.Coords') is NULL
	CREATE TABLE dbo.Coords(id int IDENTITY(1,1) primary key, cname varchar(20), lat float(53), lon float(53) );

INSERT dbo.Coords (cname, lat, lon)
VALUES ('Negr', 65.256, 63.133);

INSERT dbo.Coords (cname, lat, lon)
VALUES ('Negr2', 58.256, 55.133);

INSERT dbo.Coords (cname, lat, lon)
VALUES ('Negr3', 49.2376, 70.156);