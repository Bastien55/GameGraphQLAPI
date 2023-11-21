-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : db:3306
-- Généré le : mar. 21 nov. 2023 à 10:57
-- Version du serveur : 8.1.0
-- Version de PHP : 8.1.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `GamesDB`
--

-- --------------------------------------------------------

--
-- Structure de la table `Editor`
--

CREATE TABLE `Editor` (
  `EditorID` int NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Editor`
--

INSERT INTO `Editor` (`EditorID`, `Name`) VALUES
(1, 'Electronic Arts'),
(2, 'Ubisoft'),
(3, 'Activision'),
(4, 'Square Enix'),
(5, 'Nintendo');

-- --------------------------------------------------------

--
-- Structure de la table `Game`
--

CREATE TABLE `Game` (
  `GameID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `PublicationDate` datetime DEFAULT NULL,
  `Platform` varchar(255) DEFAULT NULL,
  `Genres` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Game`
--

INSERT INTO `Game` (`GameID`, `Name`, `PublicationDate`, `Platform`, `Genres`) VALUES
(1, 'The Witcher 3: Wild Hunt', '2015-05-19 00:00:00', 'PlayStation 4, Xbox One, PC', 'Action RPG'),
(2, 'Red Dead Redemption 2', '2018-10-26 00:00:00', 'PlayStation 4, Xbox One, PC', 'Action Adventure'),
(3, 'The Legend of Zelda: Breath of the Wild', '2017-03-03 00:00:00', 'Nintendo Switch', 'Action Adventure'),
(4, 'Cyberpunk 2077', '2020-12-10 00:00:00', 'PlayStation 4, Xbox One, PC', 'Action RPG'),
(5, 'Grand Theft Auto V', '2013-09-17 00:00:00', 'PlayStation 4, Xbox One, PC', 'Action Adventure'),
(6, 'Assassin\'s Creed Valhalla', '2020-11-10 00:00:00', 'PlayStation 4, Xbox One, PC', 'Action RPG'),
(7, 'Super Mario Odyssey', '2017-10-27 00:00:00', 'Nintendo Switch', 'Platformer'),
(8, 'Fallout 4', '2015-11-10 00:00:00', 'PlayStation 4, Xbox One, PC', 'Action RPG'),
(9, 'Fortnite', '2017-07-25 00:00:00', 'PlayStation 4, Xbox One, PC, Nintendo Switch', 'Battle Royale'),
(10, 'Minecraft', '2011-11-18 00:00:00', 'PlayStation 4, Xbox One, PC, Nintendo Switch', 'Sandbox');

-- --------------------------------------------------------

--
-- Structure de la table `GameEditor`
--

CREATE TABLE `GameEditor` (
  `GameID` int NOT NULL,
  `EditorID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `GameEditor`
--

INSERT INTO `GameEditor` (`GameID`, `EditorID`) VALUES
(1, 1),
(2, 1),
(4, 1),
(5, 1),
(1, 2),
(2, 2),
(4, 2),
(5, 2),
(1, 3),
(2, 3),
(4, 3),
(5, 3),
(3, 4),
(3, 5);

-- --------------------------------------------------------

--
-- Structure de la table `GameStudio`
--

CREATE TABLE `GameStudio` (
  `GameID` int NOT NULL,
  `StudioID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `GameStudio`
--

INSERT INTO `GameStudio` (`GameID`, `StudioID`) VALUES
(1, 1),
(2, 1),
(4, 1),
(5, 1),
(1, 2),
(4, 2),
(5, 2),
(1, 3),
(4, 3),
(5, 3),
(1, 4),
(3, 4),
(3, 5);

-- --------------------------------------------------------

--
-- Structure de la table `Studio`
--

CREATE TABLE `Studio` (
  `StudioID` int NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Studio`
--

INSERT INTO `Studio` (`StudioID`, `Name`) VALUES
(1, 'Rockstar Games'),
(2, 'Naughty Dog'),
(3, 'Bethesda Game Studios'),
(4, 'CD Projekt Red'),
(5, 'Epic Games');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `Editor`
--
ALTER TABLE `Editor`
  ADD PRIMARY KEY (`EditorID`);

--
-- Index pour la table `Game`
--
ALTER TABLE `Game`
  ADD PRIMARY KEY (`GameID`);

--
-- Index pour la table `GameEditor`
--
ALTER TABLE `GameEditor`
  ADD PRIMARY KEY (`GameID`,`EditorID`),
  ADD KEY `EditorID` (`EditorID`);

--
-- Index pour la table `GameStudio`
--
ALTER TABLE `GameStudio`
  ADD PRIMARY KEY (`GameID`,`StudioID`),
  ADD KEY `StudioID` (`StudioID`);

--
-- Index pour la table `Studio`
--
ALTER TABLE `Studio`
  ADD PRIMARY KEY (`StudioID`);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `GameEditor`
--
ALTER TABLE `GameEditor`
  ADD CONSTRAINT `GameEditor_ibfk_1` FOREIGN KEY (`GameID`) REFERENCES `Game` (`GameID`),
  ADD CONSTRAINT `GameEditor_ibfk_2` FOREIGN KEY (`EditorID`) REFERENCES `Editor` (`EditorID`);

--
-- Contraintes pour la table `GameStudio`
--
ALTER TABLE `GameStudio`
  ADD CONSTRAINT `GameStudio_ibfk_1` FOREIGN KEY (`GameID`) REFERENCES `Game` (`GameID`),
  ADD CONSTRAINT `GameStudio_ibfk_2` FOREIGN KEY (`StudioID`) REFERENCES `Studio` (`StudioID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
