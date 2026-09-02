USE SkyFlowDB;
GO

-- - TABLE 1: Users 
-- Stores both Admins and Gate Agents
-- Role column = 'Admin' or 'GateAgent'
CREATE TABLE Users (
    UserId       INT           IDENTITY(1,1) PRIMARY KEY,
    Username     NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role         NVARCHAR(20)  NOT NULL,
    Email        NVARCHAR(100) NULL,
    FirstName    NVARCHAR(50)  NOT NULL,
    LastName     NVARCHAR(50)  NOT NULL,
    CreatedAt    DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- - TABLE 2: Flights 
-- GateAgentId links to Users(UserId)
-- Status: Scheduled → Boarding → Departed
CREATE TABLE Flights (
    FlightId         INT           IDENTITY(1,1) PRIMARY KEY,
    FlightNumber     NVARCHAR(10)  NOT NULL UNIQUE,
    Origin           NVARCHAR(50)  NOT NULL,
    Destination      NVARCHAR(50)  NOT NULL,
    DepartureTime    DATETIME      NOT NULL,
    ArrivalTime      DATETIME      NULL,
    Capacity         INT           NOT NULL,
    CurrentOccupancy INT           NOT NULL DEFAULT 0,
    Status           NVARCHAR(20)  NOT NULL DEFAULT 'Scheduled',
    GateAgentId      INT           NULL,
    FOREIGN KEY (GateAgentId) REFERENCES Users(UserId)
);
GO

-- - TABLE 3: Passengers 
-- Links to a User account
CREATE TABLE Passengers (
    PassengerId    INT           IDENTITY(1,1) PRIMARY KEY,
    UserId         INT           NOT NULL,
    PassportNumber NVARCHAR(20)  NOT NULL UNIQUE,
    DateOfBirth    DATE          NOT NULL,
    Nationality    NVARCHAR(50)  NOT NULL,
    ContactNumber  NVARCHAR(20)  NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

-- - TABLE 4: Bookings 
-- Links a Passenger to a Flight
-- BookingStatus: Confirmed → CheckedIn → Boarded
CREATE TABLE Bookings (
    BookingId     INT           IDENTITY(1,1) PRIMARY KEY,
    FlightId      INT           NOT NULL,
    PassengerId   INT           NOT NULL,
    SeatNumber    NVARCHAR(10)  NOT NULL,
    BookingStatus NVARCHAR(20)  NOT NULL DEFAULT 'Confirmed',
    BookingDate   DATETIME      NOT NULL DEFAULT GETDATE(),
    CheckInTime   DATETIME      NULL,
    BoardingTime  DATETIME      NULL,
    FOREIGN KEY (FlightId)    REFERENCES Flights(FlightId),
    FOREIGN KEY (PassengerId) REFERENCES Passengers(PassengerId)
);
GO

-- - TABLE 5: FlightLog 
-- Audit trail of all actions taken on flights
CREATE TABLE FlightLog (
    LogId       INT           IDENTITY(1,1) PRIMARY KEY,
    FlightId    INT           NOT NULL,
    Action      NVARCHAR(50)  NOT NULL,
    PerformedBy INT           NOT NULL,
    PerformedAt DATETIME      NOT NULL DEFAULT GETDATE(),
    Details     NVARCHAR(500) NULL,
    FOREIGN KEY (FlightId)    REFERENCES Flights(FlightId),
    FOREIGN KEY (PerformedBy) REFERENCES Users(UserId)
);
GO


--  Test data 


-- Users: 1 Admin, 2 Gate Agents
INSERT INTO Users (Username, PasswordHash, Role, Email, FirstName, LastName)
VALUES
    ('admin',  'admin123', 'Admin',     'admin@skyflow.com',  'Sipho',  'Nkosi'),
    ('agent1', 'agent123', 'GateAgent', 'agent1@skyflow.com', 'Priya',  'Naidoo'),
    ('agent2', 'agent456', 'GateAgent', 'agent2@skyflow.com', 'Aiden',  'Smith');

-- Flights (GateAgentId 2 = agent1, 3 = agent2)
INSERT INTO Flights (FlightNumber, Origin, Destination, DepartureTime, ArrivalTime, Capacity, Status, GateAgentId)
VALUES
    ('SF102', 'Cape Town',    'Johannesburg', '2026-06-01 08:30', '2026-06-01 10:30', 180, 'Scheduled', 2),
    ('SF221', 'Durban',       'Cape Town',    '2026-06-01 10:15', '2026-06-01 12:15', 150, 'Scheduled', 2),
    ('SF305', 'Johannesburg', 'Durban',       '2026-06-01 13:45', '2026-06-01 15:30', 180, 'Boarding',  3);

-- Passengers (linked to existing UserId 1,2,3)
INSERT INTO Passengers (UserId, PassportNumber, DateOfBirth, Nationality, ContactNumber)
VALUES
    (1, 'PASSPORT12345', '1990-05-15', 'South African', '0831234567'),
    (2, 'PASSPORT67890', '1985-11-22', 'South African', '0849876543'),
    (3, 'PASSPORT11111', '1995-03-10', 'South African', '0761112222');

-- Bookings
INSERT INTO Bookings (FlightId, PassengerId, SeatNumber, BookingStatus)
VALUES
    (1, 1, '12A', 'CheckedIn'),
    (1, 2, '14B', 'Confirmed'),
    (2, 3, '5C',  'Confirmed');

-- - Verify that everything was created correctly 
SELECT * FROM Users;
SELECT * FROM Flights;
SELECT * FROM Passengers;
SELECT * FROM Bookings;