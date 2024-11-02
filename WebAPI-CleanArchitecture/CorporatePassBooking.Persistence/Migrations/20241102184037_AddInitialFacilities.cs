using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorporatePassBooking.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialFacilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Temporary table to store facility IDs and names
            migrationBuilder.Sql(@"
            DECLARE @AnimalFeedingId UNIQUEIDENTIFIER;
            DECLARE @SwimWithDolphinId UNIQUEIDENTIFIER;
            DECLARE @NightSafariId UNIQUEIDENTIFIER;
            DECLARE @OpenWorkAreaId UNIQUEIDENTIFIER;
            DECLARE @ElephantRideId UNIQUEIDENTIFIER;

            -- Insert Facilities and capture the IDs
            INSERT INTO Facilities (Id, Name, Type, TotalCapacity, Location, AvailableCapacity, DateCreated, IsDeleted)
            VALUES 
                (NEWID(), 'Animal Feeding', 'Open Stage', 10, 'Building 1, Floor 3', 10, GETDATE(), 0),
                (NEWID(), 'Swim with Dolphin', 'Water Event', 20, 'Building 2, Ground Floor', 20, GETDATE(), 0),
                (NEWID(), 'Night Safari', 'Night Time Animal life', 30, 'Building 3, Main Floor', 30, GETDATE(), 0),
                (NEWID(), 'Open Work Area', 'Co-Working Space', 40, 'Building 1, Floor 2', 40, GETDATE(), 0),
                (NEWID(), 'Elephant Ride', 'Ride with Elephant', 25, 'Building 1, Floor 4', 25, GETDATE(), 0);

            -- Retrieve the generated IDs for the amenities
            SELECT @AnimalFeedingId = Id FROM Facilities WHERE Name = 'Animal Feeding';
            SELECT @SwimWithDolphinId = Id FROM Facilities WHERE Name = 'Swim with Dolphin';
            SELECT @NightSafariId = Id FROM Facilities WHERE Name = 'Night Safari';
            SELECT @OpenWorkAreaId = Id FROM Facilities WHERE Name = 'Open Work Area';
            SELECT @ElephantRideId = Id FROM Facilities WHERE Name = 'Elephant Ride';

            -- Insert Amenities with correct FacilityIds and ensure all columns are filled
            INSERT INTO Amenities (Id, Name, FacilityId, IsDeleted, DateCreated)
            VALUES 
                (NEWID(), 'Projector', @AnimalFeedingId, 0, GETDATE()),
                (NEWID(), 'Animal Dance', @AnimalFeedingId, 0, GETDATE()),
                (NEWID(), 'Wi-Fi', @AnimalFeedingId, 0, GETDATE()),
                (NEWID(), 'Swim Suit', @SwimWithDolphinId, 0, GETDATE()),
                (NEWID(), 'Shower Facilities', @SwimWithDolphinId, 0, GETDATE()),
                (NEWID(), 'Lockers', @SwimWithDolphinId, 0, GETDATE()),
                (NEWID(), 'Van', @NightSafariId, 0, GETDATE()),
                (NEWID(), 'Sound System', @NightSafariId, 0, GETDATE()),
                (NEWID(), 'Lighting', @NightSafariId, 0, GETDATE()),
                (NEWID(), 'Desks', @OpenWorkAreaId, 0, GETDATE()),
                (NEWID(), 'Power Outlets', @OpenWorkAreaId, 0, GETDATE()),
                (NEWID(), 'Coffee Machine', @OpenWorkAreaId, 0, GETDATE()),
                (NEWID(), 'Night Vision Lights', @ElephantRideId, 0, GETDATE()),
                (NEWID(), 'Free Photo', @ElephantRideId, 0, GETDATE()),
                (NEWID(), 'Popcorn', @ElephantRideId, 0, GETDATE());
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            BEGIN TRANSACTION;

            BEGIN TRY
                -- Disable foreign key constraints
                ALTER TABLE Amenities NOCHECK CONSTRAINT ALL;

                -- Delete data from Amenities table
                DELETE FROM Amenities;

                -- Delete data from Facilities table
                DELETE FROM Facilities;

                -- Re-enable foreign key constraints
                ALTER TABLE Amenities CHECK CONSTRAINT ALL;

                COMMIT TRANSACTION;  -- Commit the transaction if all commands succeed
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;  -- Roll back the transaction if an error occurs
                PRINT 'Error occurred while clearing data: ' + ERROR_MESSAGE();
            END CATCH;
        ");
        }
    }
}
