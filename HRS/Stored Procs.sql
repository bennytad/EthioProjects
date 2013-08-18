CREATE PROCEDURE hrs_get_hotel_user
	@user_name VARCHAR(30),
	@hotel_id VARCHAR(30)
AS
BEGIN
	SELECT UserName FROM UserProfile WHERE HotelID = @hotel_id
END
GO
--validates that the hotel_id exists and that there is no roomt_type already defined
CREATE PROCEDURE hrs_validate_new_room_type
	@room_type int,
	@hotel_id VARCHAR(30)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Hotels WHERE HotelID = @hotel_id) AND
		NOT EXISTS(SELECT 1 FROM RoomTypes WHERE room_type = @room_type AND HotelID = @hotel_id)
	BEGIN
		SELECT 1
	END
	ELSE SELECT 0
END
GO
