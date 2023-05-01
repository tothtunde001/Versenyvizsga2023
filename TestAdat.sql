DELETE FROM diakok;
DELETE FROM tanarok;
DELETE FROM versenyek;
DELETE FROM kerdesek;

INSERT INTO `tanarok` (`id`, `username`, `password`, `email`, `fullname`, `subject`, `class`) VALUES
(1, 'Nagy_István','1p2l3d025795', 'nagy.istvan@gmail.com', 'Nagy István', 'matek', '10.b'),
(2, 'Kiss_József','8d3e9f010354', 'kiss.jozsef@gmail.com', 'Kiss József', 'környezet', '10.b'),
(3, 'Apró_Nárcisz','3q7w1e016345', 'apro.narcisz@gmail.com', 'Apró Nárcisz', 'informatika', '11.b');

INSERT INTO `diakok` (`id`, `username`, `password`, `email`,`fullname`,`school` ,`class`) VALUES
('1', 'Nagy_Béla','1a2b3c012345', 'nagy.bela@gmail.com','Nagy Béla','Nemes Nagy Ágnes', '5'),
('2', 'Kiss_Pista','4d5e6f012345', 'kiss.pista@gmail.com','Kiss Pista','Bláthy Otto Titusz Informatikai Szakközép Iskola','8'),
('3', 'Apró_Ildikó','7q8w9e012345', 'apro.ildiko@gmail.com','Apró Ildikó', 'Vajda János Gimázium', '3');

INSERT INTO `versenyek` (`id`, `competition_name`,`description`) VALUES
(1, 'Mozaik Matematika verseny','Ez egy matematika verseny'),
(2, 'Környezetünk','Ez egy környezet verseny'),
(3, 'Kozma László Országos Informatika verseny', 'Ez egy informatika verseny');

INSERT INTO kerdesek(`id`, `competitionid`,`question`,`answer1`,`answer2`,`answer3`,`answer4`,`correctAnswer`) VALUES
(1, '1','A piacon 1 retekért és 1 salátáért adnak 1 paprikát, és 2 retek egy salátát ér. Hány retek ára egyenlő egy paprika árával?','1 retek ára', '2 retek ára', '3 retek ára', '5 retek ára', 3),
(2, '2','A víznek sok formája van. A természetben folyékony (tavak, folyók), szilárd (jég) és légnemű (pára) alakban fordul elő. Az alábbiak közül melyik még a légnemű alakja?', 'a gőz', 'a jégvirág', 'a zuzmara', 'a dér', 1),
(3, '3','Mik találhatók az alaplapon?', 'processzor foglalat, órajel generátor, tintapatron', 'processzor foglalat, USB csatlakozó, toner', 'processzor foglalat, memóriahelyek, PCI csatlakozók', 'semmi', 3),
(4, '1','Hány oldala van egy trapéznak?','1', '2', '3', '4', 4),
(5, '2','Hány füle van egy nyúlnak?', 'nincs füle', '1', '2', '2 pár', 3),
(6, '3','Az alábbiak közül melyik nem C-típusú programozási nyelv?', 'C', 'C++', 'C#', 'Java', 4);