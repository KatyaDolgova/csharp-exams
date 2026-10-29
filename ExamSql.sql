-- Выполнять после ExamOl.sql (олимпиады). ID олимпиад и участников подбираются подзапросами,
-- поэтому скрипт не зависит от значений IDENTITY.
INSERT INTO TypesOfSports (Title) VALUES
('Athletics'),
('Swimming'),
('Gymnastics'),
('Basketball'),
('Football'),
('Hockey'),
('Skiing'),
('Snowboarding');

INSERT INTO Competitions (IdOlimp, IdTypesSport, NumberPart) VALUES
((SELECT ID FROM Olympus WHERE Oyear = 2020), (SELECT ID FROM TypesOfSports WHERE Title = 'Athletics'), 100),     -- Tokyo 2020
((SELECT ID FROM Olympus WHERE Oyear = 2020), (SELECT ID FROM TypesOfSports WHERE Title = 'Swimming'), 50),
((SELECT ID FROM Olympus WHERE Oyear = 2020), (SELECT ID FROM TypesOfSports WHERE Title = 'Gymnastics'), 30),
((SELECT ID FROM Olympus WHERE Oyear = 2022), (SELECT ID FROM TypesOfSports WHERE Title = 'Basketball'), 20),    -- Beijing 2022
((SELECT ID FROM Olympus WHERE Oyear = 2022), (SELECT ID FROM TypesOfSports WHERE Title = 'Football'), 15),
((SELECT ID FROM Olympus WHERE Oyear = 2024), (SELECT ID FROM TypesOfSports WHERE Title = 'Hockey'), 25),        -- Paris 2024
((SELECT ID FROM Olympus WHERE Oyear = 2026), (SELECT ID FROM TypesOfSports WHERE Title = 'Skiing'), 40),        -- Milan 2026
((SELECT ID FROM Olympus WHERE Oyear = 2026), (SELECT ID FROM TypesOfSports WHERE Title = 'Snowboarding'), 35);

INSERT INTO Participants (FirstName, Surname, LastName, Country, TypeSport, BirthDate, FotoPath) VALUES
('John', 'Doe', 'Smith', 'USA', 'Athletics', '1990-01-15', NULL),
('Jane', 'Doe', 'Johnson', 'USA', 'Swimming', '1992-05-20', NULL),
('Mark', 'Brown', 'Williams', 'UK', 'Gymnastics', '1988-03-12', NULL),
('Emily', 'Davis', 'Jones', 'Canada', 'Basketball', '1995-07-30', NULL),
('Michael', 'Wilson', 'Garcia', 'Spain', 'Football', '1985-11-25', NULL),
('Sarah', 'Miller', 'Martinez', 'Mexico', 'Hockey', '1993-09-10', NULL),
('David', 'Anderson', 'Lopez', 'Italy', 'Skiing', '1987-02-14', NULL),
('Laura', 'Taylor', 'Gonzalez', 'France', 'Snowboarding', '1991-04-22', NULL);

INSERT INTO Results (IdPart, IdOlimp, Place, Medal) VALUES
((SELECT ID FROM Participants WHERE FirstName = 'John'    AND Surname = 'Doe'),      (SELECT ID FROM Olympus WHERE Oyear = 2020), 1, 'Gold'),    -- Athletics
((SELECT ID FROM Participants WHERE FirstName = 'Jane'    AND Surname = 'Doe'),      (SELECT ID FROM Olympus WHERE Oyear = 2020), 2, 'Silver'),  -- Swimming
((SELECT ID FROM Participants WHERE FirstName = 'Mark'    AND Surname = 'Brown'),    (SELECT ID FROM Olympus WHERE Oyear = 2020), 3, 'Bronze'),  -- Gymnastics
((SELECT ID FROM Participants WHERE FirstName = 'Emily'   AND Surname = 'Davis'),    (SELECT ID FROM Olympus WHERE Oyear = 2022), 1, 'Gold'),    -- Basketball
((SELECT ID FROM Participants WHERE FirstName = 'Michael' AND Surname = 'Wilson'),   (SELECT ID FROM Olympus WHERE Oyear = 2022), 2, 'Silver'),  -- Football
((SELECT ID FROM Participants WHERE FirstName = 'Sarah'   AND Surname = 'Miller'),   (SELECT ID FROM Olympus WHERE Oyear = 2024), 3, 'Bronze'),  -- Hockey
((SELECT ID FROM Participants WHERE FirstName = 'David'   AND Surname = 'Anderson'), (SELECT ID FROM Olympus WHERE Oyear = 2026), 1, 'Gold'),    -- Skiing
((SELECT ID FROM Participants WHERE FirstName = 'Laura'   AND Surname = 'Taylor'),   (SELECT ID FROM Olympus WHERE Oyear = 2026), 2, 'Silver');  -- Snowboarding
