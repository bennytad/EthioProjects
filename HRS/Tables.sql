ALTER TABLE UserProfile
ADD HotelID VARCHAR(30)

CREATE TABLE RoomTypes
(
	room_type int,
	HotelID VARCHAR(30),
	room_description TEXT
)

CREATE TABLE Hotels
(
	HotelID VARCHAR(30),
	HotelName VARCHAR(100)
)

INSERT INTO Hotels values('TestHotel', 'My Test Hotel')
