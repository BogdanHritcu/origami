using Microsoft.EntityFrameworkCore.Migrations;

namespace origami_backend.Migrations
{
    public partial class DateUpdatedTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Users_UPDATE] ON [dbo].[Users]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Users
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Profiles_UPDATE] ON [dbo].[Profiles]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Profiles
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Studies_UPDATE] ON [dbo].[Studies]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Studies
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Steps_UPDATE] ON [dbo].[Steps]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Steps
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Origamis_UPDATE] ON [dbo].[Origamis]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Origamis
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[OrigamiComments_UPDATE] ON [dbo].[OrigamiComments]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.OrigamiComments
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[ProfileComments_UPDATE] ON [dbo].[ProfileComments]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.ProfileComments
                    SET DateUpdated = GETDATE()
                    WHERE Id = @auxId
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[Profiles_UPDATE];
            ");

            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[Origamis_UPDATE];
            ");

            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[Users_UPDATE];
            ");

            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[Studies_UPDATE];
            ");

            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[Steps_UPDATE];
            ");

            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[OrigamiComments_UPDATE];
            ");

            migrationBuilder.Sql(
            @"
                DROP TRIGGER [dbo].[ProfileComments_UPDATE];
            ");
        }
    }
}
