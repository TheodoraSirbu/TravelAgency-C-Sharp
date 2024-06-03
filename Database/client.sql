-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gazdă: 127.0.0.1
-- Timp de generare: iun. 03, 2024 la 01:39 PM
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
-- Structură tabel pentru tabel `client`
--

CREATE TABLE `client` (
  `cod_client` int(11) NOT NULL,
  `nume` varchar(50) NOT NULL,
  `prenume` varchar(50) NOT NULL,
  `CNP` bigint(13) NOT NULL,
  `nr_tel` int(11) NOT NULL,
  `adresa` varchar(100) NOT NULL,
  `localitate` varchar(50) NOT NULL,
  `cod_rezervare` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `client`
--

INSERT INTO `client` (`cod_client`, `nume`, `prenume`, `CNP`, `nr_tel`, `adresa`, `localitate`, `cod_rezervare`) VALUES
(2, 'Horia', 'George', 4589548562548, 745112354, 'Str Brailei', 'Galati', 2),
(3, 'Ionel', 'Cristian', 2547869876541, 765985479, 'Str Cosbuc', 'Galati', 2);

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`cod_client`),
  ADD KEY `client_FK_1` (`cod_rezervare`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `client`
--
ALTER TABLE `client`
  MODIFY `cod_client` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_FK_1` FOREIGN KEY (`cod_rezervare`) REFERENCES `rezervari` (`cod_rezervare`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
