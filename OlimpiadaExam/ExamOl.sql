-- Выполнять первым: остальные скрипты (ExamSql.sql) ссылаются на олимпиады по году
INSERT INTO Olympus (Oyear, Otype, HostCountry, City) VALUES
(2020, 'Summer', 'Japan', 'Tokyo'),
(2022, 'Winter', 'China', 'Beijing'),
(2024, 'Summer', 'France', 'Paris'),
(2026, 'Winter', 'Italy', 'Milan');
