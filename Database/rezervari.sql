-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gazdă: 127.0.0.1
-- Timp de generare: iun. 03, 2024 la 01:40 PM
-- Versiune server: 10.4.27-MariaDB
-- Versiune PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Bază de date: `turism`
--

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `rezervari`
--

CREATE TABLE `rezervari` (
  `cod_rezervare` int(11) NOT NULL,
  `data_rezervare` date NOT NULL,
  `pret` int(11) NOT NULL,
  `avans` varchar(50) NOT NULL,
  `cod_contract` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `rezervari`
--

INSERT INTO `rezervari` (`cod_rezervare`, `data_rezervare`, `pret`, `avans`, `cod_contract`) VALUES
(1, '2022-09-24', 10000, '10%', 2),
(2, '2022-09-24', 10000, '10%', 1);

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `rezervari`
--
ALTER TABLE `rezervari`
  ADD PRIMARY KEY (`cod_rezervare`),
  ADD KEY `rezervari_FK_1` (`cod_contract`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `rezervari`
--
ALTER TABLE `rezervari`
  MODIFY `cod_rezervare` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `rezervari`
--
ALTER TABLE `rezervari`
  ADD CONSTRAINT `rezervari_FK_1` FOREIGN KEY (`cod_contract`) REFERENCES `contract` (`cod_contract`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
