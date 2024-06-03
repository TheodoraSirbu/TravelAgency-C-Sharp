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
-- Structură tabel pentru tabel `contract`
--

CREATE TABLE `contract` (
  `cod_contract` int(11) NOT NULL,
  `destinatie` varchar(50) NOT NULL,
  `data_inceput` date NOT NULL,
  `data_sfarsit` date NOT NULL,
  `denumire_hotel` varchar(50) NOT NULL,
  `transport` tinyint(4) NOT NULL,
  `nr_pers` int(11) NOT NULL,
  `numar_nopti_cazare` int(11) NOT NULL,
  `pret_noapte` int(11) NOT NULL,
  `cod_angajat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `contract`
--

INSERT INTO `contract` (`cod_contract`, `destinatie`, `data_inceput`, `data_sfarsit`, `denumire_hotel`, `transport`, `nr_pers`, `numar_nopti_cazare`, `pret_noapte`, `cod_angajat`) VALUES
(1, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(2, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1),
(3, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(4, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1),
(5, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(6, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1),
(7, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(8, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1),
(9, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(10, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1),
(11, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(12, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1),
(13, 'Creta', '2023-06-10', '2023-06-17', 'Madona', 1, 3, 7, 150, 1),
(14, 'Malta', '2023-08-01', '2023-08-08', 'Naruto', 0, 2, 7, 300, 1);

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `contract`
--
ALTER TABLE `contract`
  ADD PRIMARY KEY (`cod_contract`),
  ADD KEY `contract_FK_1` (`cod_angajat`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `contract`
--
ALTER TABLE `contract`
  MODIFY `cod_contract` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `contract`
--
ALTER TABLE `contract`
  ADD CONSTRAINT `contract_FK_1` FOREIGN KEY (`cod_angajat`) REFERENCES `angajat` (`cod_angajat`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
