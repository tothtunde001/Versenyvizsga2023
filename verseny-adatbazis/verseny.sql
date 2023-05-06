-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 06, 2023 at 08:47 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `verseny`
--

-- --------------------------------------------------------

--
-- Table structure for table `diakok`
--

CREATE TABLE `diakok` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `username` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fullname` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `school` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `class` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `diakok`
--

INSERT INTO `diakok` (`id`, `username`, `password`, `email`, `fullname`, `school`, `class`, `created_at`, `updated_at`) VALUES
(1, 'Nagy_Béla', '1a2b3c012345', 'nagy.bela@gmail.com', 'Nagy Béla', 'Nemes Nagy Ágnes', '5', NULL, NULL),
(2, 'Kiss_Pista', '4d5e6f012345', 'kiss.pista@gmail.com', 'Kiss Pista', 'Bláthy Otto Titusz Informatikai Szakközép Iskola', '8', NULL, NULL),
(3, 'Apró_Ildikó', '7q8w9e012345', 'apro.ildiko@gmail.com', 'Apró Ildikó', 'Vajda János Gimázium', '3', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `kerdesek`
--

CREATE TABLE `kerdesek` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `competitionId` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `question` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `answer1` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `answer2` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `answer3` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `answer4` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `correctAnswer` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `kerdesek`
--

INSERT INTO `kerdesek` (`id`, `competitionId`, `question`, `answer1`, `answer2`, `answer3`, `answer4`, `correctAnswer`, `created_at`, `updated_at`) VALUES
(2, '2', 'A víznek sok formája van. A természetben folyékony (tavak, folyók), szilárd (jég) és légnemű (pára) alakban fordul elő. Az alábbiak közül melyik még a légnemű alakja?', 'a gőz', 'a jégvirág', 'a zuzmara', 'a dér', 1, NULL, NULL),
(3, '1', 'Hány oldala van egy körnek?', 'valamennyi', '0', 'pont annyi', 'nem tudom', 2, NULL, '2023-05-02 13:55:25'),
(4, '1', 'Hány oldala van egy trapéznak?', '1', '2', '3', '4', 4, NULL, NULL),
(5, '2', 'Hány füle van egy nyúlnak?', 'nincs füle', '1', '2', '2 pár', 3, NULL, NULL),
(6, '3', 'Az alábbiak közül melyik nem C-típusú programozási nyelv?', 'C', 'C++', 'C#', 'Java', 4, NULL, NULL),
(7, '1', 'Hány oldala van egy körnek?', '4', '3', '2', '0', 4, '2023-05-02 13:54:19', '2023-05-02 13:54:19');

-- --------------------------------------------------------

--
-- Table structure for table `kitoltottkerdesek`
--

CREATE TABLE `kitoltottkerdesek` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `submittedCompetitionId` int(11) NOT NULL,
  `questionId` int(11) NOT NULL,
  `studentAnswer` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `kitoltottkerdesek`
--

INSERT INTO `kitoltottkerdesek` (`id`, `submittedCompetitionId`, `questionId`, `studentAnswer`, `created_at`, `updated_at`) VALUES
(1, 1, 2, 1, NULL, NULL),
(2, 1, 5, 4, NULL, NULL),
(3, 2, 2, 4, '2023-05-02 14:06:24', '2023-05-02 14:06:24');

-- --------------------------------------------------------

--
-- Table structure for table `kitoltottversenyek`
--

CREATE TABLE `kitoltottversenyek` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `studentId` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `competitionId` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `kitoltottversenyek`
--

INSERT INTO `kitoltottversenyek` (`id`, `studentId`, `competitionId`, `created_at`, `updated_at`) VALUES
(1, '1', '2', NULL, NULL),
(2, '2', '2', '2023-05-02 14:06:24', '2023-05-02 14:06:24');

-- --------------------------------------------------------

--
-- Table structure for table `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2019_12_14_000001_create_personal_access_tokens_table', 1),
(2, '2023_04_19_171903_create_diakok_table', 1),
(3, '2023_04_20_072501_create_tanarok_table', 1),
(4, '2023_04_20_075604_create_versenyek_table', 1),
(5, '2023_04_20_075628_create_kerdesek_table', 1),
(6, '2023_04_20_075713_create_kitoltottversenyek_table', 1),
(7, '2023_04_20_075734_create_kitoltottkerdesek_table', 1);

-- --------------------------------------------------------

--
-- Table structure for table `personal_access_tokens`
--

CREATE TABLE `personal_access_tokens` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `tokenable_type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tokenable_id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `abilities` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `expires_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tanarok`
--

CREATE TABLE `tanarok` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `username` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fullname` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `subject` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `class` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tanarok`
--

INSERT INTO `tanarok` (`id`, `username`, `password`, `email`, `fullname`, `subject`, `class`, `created_at`, `updated_at`) VALUES
(1, 'Nagy_István', '1p2l3d025795', 'nagy.istvan@gmail.com', 'Nagy István', 'matek', '10.b', NULL, NULL),
(2, 'Kiss_József', '8d3e9f010354', 'kiss.jozsef@gmail.com', 'Kiss József', 'környezet', '10.b', NULL, NULL),
(3, 'Apró_Nárcisz', '3q7w1e016345', 'apro.narcisz@gmail.com', 'Apró Nárcisz', 'informatika', '11.b', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `versenyek`
--

CREATE TABLE `versenyek` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `competition_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `versenyek`
--

INSERT INTO `versenyek` (`id`, `competition_name`, `description`, `created_at`, `updated_at`) VALUES
(2, 'Környezetünk', 'Ez egy környezet verseny', NULL, NULL),
(3, 'Kozma László Országos Informatika verseny', 'Ez egy informatika verseny', NULL, NULL),
(4, 'Matematika Verseny', 'Ez itt a leírás', '2023-05-02 13:59:08', '2023-05-02 13:59:08');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `diakok`
--
ALTER TABLE `diakok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `diakok_username_unique` (`username`);

--
-- Indexes for table `kerdesek`
--
ALTER TABLE `kerdesek`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kitoltottkerdesek`
--
ALTER TABLE `kitoltottkerdesek`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kitoltottversenyek`
--
ALTER TABLE `kitoltottversenyek`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `personal_access_tokens`
--
ALTER TABLE `personal_access_tokens`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  ADD KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`);

--
-- Indexes for table `tanarok`
--
ALTER TABLE `tanarok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `tanarok_username_unique` (`username`);

--
-- Indexes for table `versenyek`
--
ALTER TABLE `versenyek`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `diakok`
--
ALTER TABLE `diakok`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `kerdesek`
--
ALTER TABLE `kerdesek`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `kitoltottkerdesek`
--
ALTER TABLE `kitoltottkerdesek`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `kitoltottversenyek`
--
ALTER TABLE `kitoltottversenyek`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `personal_access_tokens`
--
ALTER TABLE `personal_access_tokens`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tanarok`
--
ALTER TABLE `tanarok`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `versenyek`
--
ALTER TABLE `versenyek`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
