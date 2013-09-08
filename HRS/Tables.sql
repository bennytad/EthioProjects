--Add a Hotel ID to the default user profile table
ALTER TABLE UserProfile
ADD HotelID BIGINT

drop table Reservations
drop table rooms
drop table roomtypes
drop table guest
drop table hotels

--Registered hotels
CREATE TABLE Hotels
(
	HotelID BIGINT NOT NULL IDENTITY(1,1),
	HotelName VARCHAR(100) NOT NULL
)

ALTER TABLE Hotels
ADD CONSTRAINT pk_Hotels PRIMARY KEY (HotelID)

--Defined Room Types for a given hotel
CREATE TABLE RoomTypes
(
	room_type_id BIGINT NOT NULL IDENTITY(1,1),
	HotelID BIGINT NOT NULL,
	room_type_name VARCHAR(30) NOT NULL,
	room_description TEXT
)

ALTER TABLE RoomTypes
ADD CONSTRAINT PK_RoomTypes PRIMARY KEY NONCLUSTERED (room_type_id, HotelID)

ALTER TABLE RoomTypes
ADD CONSTRAINT fk_RoomTypes
FOREIGN KEY (HotelID)
REFERENCES Hotels(HotelID)

--Registerd guests
CREATE TABLE Guest
(
	guest_id BIGINT NOT NULL IDENTITY(1,1),
	HotelID BIGINT NOT NULL,
	first_name VARCHAR(30),
	last_name VARCHAR(30),
	street_address VARCHAR(30),
	city VARCHAR(30),
	country VARCHAR(30),
	national_id VARCHAR(30),
	nationality VARCHAR(30)
)

ALTER TABLE Guest
ADD CONSTRAINT PK_Guest PRIMARY KEY NONCLUSTERED (guest_id, HotelID)


ALTER TABLE Guest
ADD CONSTRAINT fk_Guest
FOREIGN KEY (HotelID)
REFERENCES Hotels(HotelID)

--Rooms in a given hotel
CREATE TABLE Rooms
(
	room_id BIGINT IDENTITY(1,1),
	HotelID BIGINT NOT NULL,
	room_number VARCHAR(10) NOT NULL,
	room_type_id BIGINT NOT NULL,
	floor_level INT,
	note TEXT
)

ALTER TABLE Rooms
ADD CONSTRAINT pk_Rooms
PRIMARY KEY NONCLUSTERED(room_id, HotelID)

ALTER TABLE Rooms
ADD CONSTRAINT fk_Rooms_1
FOREIGN KEY (room_type_id, HotelID)
REFERENCES RoomTypes(room_type_id, HotelID)

ALTER TABLE Rooms
ADD CONSTRAINT fk_Rooms_2
FOREIGN KEY (HotelID)
REFERENCES Hotels(HotelID)

--Reservations
CREATE TABLE Reservations
(
	reservation_id BIGINT NOT NULL IDENTITY(1,1),
	start_date DATETIME,
	end_date DATETIME,
	guest_id BIGINT,
	hotelID BIGINT NOT NULL,
	room_id BIGINT,
	reservation_status INT -- 0-checked_out, 1-booked, 2-checked_in
)

ALTER TABLE Reservations
ADD CONSTRAINT pk_Reservations
PRIMARY KEY NONCLUSTERED(reservation_id, HotelID)

ALTER TABLE Reservations
ADD CONSTRAINT fk_Reservations_1
FOREIGN KEY (HotelID)
REFERENCES Hotels(HotelID)

ALTER TABLE Reservations
ADD CONSTRAINT fk_Reservations_2
FOREIGN KEY (room_id, HotelID)
REFERENCES Rooms(room_id, HotelID)

ALTER TABLE Reservations
ADD CONSTRAINT fk_Reservations_3
FOREIGN KEY (guest_id, HotelID)
REFERENCES Guest(guest_id, HotelID)