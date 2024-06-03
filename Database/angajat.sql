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
-- Structură tabel pentru tabel `angajat`
--

CREATE TABLE `angajat` (
  `cod_angajat` int(11) NOT NULL,
  `nume` varchar(50) NOT NULL,
  `prenume` varchar(50) NOT NULL,
  `CNP` bigint(13) NOT NULL,
  `data_nasterii` date NOT NULL,
  `salariu` int(11) NOT NULL,
  `cod_functie` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `angajat`
--

INSERT INTO `angajat` (`cod_angajat`, `nume`, `prenume`, `CNP`, `data_nasterii`, `salariu`, `cod_functie`) VALUES
(1, 'Sirbu', 'Theodora', 5426845123452, '2023-05-01', 200, 1);

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `angajat`
--
ALTER TABLE `angajat`
  ADD PRIMARY KEY (`cod_angajat`),
  ADD KEY `books_FK_1` (`cod_functie`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `angajat`
--
ALTER TABLE `angajat`
  MODIFY `cod_angajat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `angajat`
--
ALTER TABLE `angajat`
  ADD CONSTRAINT `books_FK_1` FOREIGN KEY (`cod_functie`) REFERENCES `functie` (`cod_functie`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
