--
-- PostgreSQL database dump
--

\restrict CtlX7ScG63S6yUujHeuziBTstmbDaiof7vJHEqcMkt3GM1VVCoaPpNExYb1r0oG

-- Dumped from database version 17.6
-- Dumped by pg_dump version 17.6

-- Started on 2025-12-04 11:15:12

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4514 (class 0 OID 17459)
-- Dependencies: 218
-- Data for Name: resume; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume (resume_id, user_id, name, phone, email, status, address, resume, title, job_description, photo_url) VALUES (10, 1, 'Rodrigo Landim Carneiro', '(61) 9 9875-2588', 'rodrigo@emagine.com.br', 1, 'Asa Norte, Brasília - DF', 'Sou Desenvolvedor Sênior especializado em **C#.NET**, **Angular**, **React**, **SQL Server** e **Oracle**, atuando no desenvolvimento e evolução de sistemas críticos que processam dezenas de milhares de operações mensais, estruturando processos, equipes e fluxos que aumentam eficiência, confiabilidade e escalabilidade. No Banco **BTG Pactual**, contribuo diretamente para um sistema estratégico de integração e validação de clientes off-shore em toda a América Latina, fortalecendo a conformidade regulatória e a automação operacional; na **Cassi** e na **Caixa** (pela **Benner**), ajudei a modernizar plataformas de gestão de saúde utilizadas por milhares de beneficiários; na **Wimoveis.com**, liderei melhorias que impulsionaram o portal ao domínio de **90%** do mercado, contribuindo para sua venda por mais de **R$ 50 milhões**; e em experiências anteriores gerei aumentos consistentes de produtividade e estabilidade em diversos segmentos corporativos.', 'Dev Senior', 'Desenvolvedor Sênior', 'https://emagine.nyc3.digitaloceanspaces.com/resumecv/Flux_Dev_natural_indoor_photo_bald_no_hair_no_facial_hair_casu_0_8e35c78b-d073-4cde-a8a7-bae97f154f24.jpg');


--
-- TOC entry 4522 (class 0 OID 17521)
-- Dependencies: 226
-- Data for Name: resume_course_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4521 (class 0 OID 17507)
-- Dependencies: 225
-- Data for Name: resume_courses; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (254, 10, 1, 'MBA em Data Center e Computação em Nuvem - Infraestrutura, Arquitetura e Armazenamento de Informação', NULL, 'UNIP', NULL, '2025-03-01 00:00:00', '2026-03-01 00:00:00', 0);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (255, 10, 1, 'Análise e Desenvolvimento de Sistemas', NULL, 'UNIP', NULL, '2019-01-01 00:00:00', '2021-12-01 00:00:00', 0);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (256, 10, 1, 'Engenharia Civil', NULL, 'IESB', NULL, '2000-01-01 00:00:00', '2004-12-01 00:00:00', 0);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (257, 10, 3, 'Introduction to Microsoft Azure Cloud Services', NULL, 'Coursera', NULL, '2024-09-01 00:00:00', '2024-09-30 00:00:00', 9);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (258, 10, 3, 'Certificação Amazon AWS Certified Cloud Practitioner CLF-C02', NULL, 'Andre Lacono, Udemy', NULL, '2024-12-01 00:00:00', '2024-12-31 00:00:00', 22);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (259, 10, 3, 'Design Patterns em C#', NULL, 'Filipe NHimi, Udemy', NULL, '2025-01-01 00:00:00', '2025-01-31 00:00:00', 13);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (260, 10, 3, 'C# - Aplicando Princípios SOLID na prática', NULL, 'Jose Carlos Macoratti, Udemy', NULL, '2025-01-01 00:00:00', '2025-01-31 00:00:00', 9);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (261, 10, 3, 'Clean Architecture Essencial - ASP .NET Core com C#', NULL, 'Jose Carlos Macoratti, Udemy', NULL, '2025-01-01 00:00:00', '2025-01-31 00:00:00', 14);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (262, 10, 3, 'Métodos Ágeis', NULL, 'Alura', 'Introdução, Scrum: Agilidade em seu projeto, Lean Startup: Primeiros passos da sua startup enxuta, Agile na prática: técnicas aplicadas para gestão ágil', '2023-01-01 00:00:00', '2023-01-31 00:00:00', 35);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (263, 10, 3, 'Formação .NET', NULL, 'Alura', 'Primeiros passos; Entendendo a Orientação a Objetos; Entendendo herança e interface; Entendendo exceções; Bibliotecas DLLs, documentação e usando o NuGet; Strings, expressões regulares e a classe Object; Array e tipos genéricos; List, lambda, linq; Entrada e saída (I/O) com streams; Entity Framework Core, banco de dados de forma eficiente; Asp.NET Core, uma webapp usando o padrão MVC; ASP.NET Core, um e-Commerce com MVC e EF Core; e ASP.NET Core parte 2, um e-Commerce com MVC e EF Core', '2023-01-01 00:00:00', '2023-01-31 00:00:00', 118);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (264, 10, 3, 'Formação Oracle SQL e PL/SQL', NULL, 'Alura', 'Oracle I - Aprenda SQL usando esse famoso banco de dados; Oracle II - Consultas Complexas; PL/SQL - Domine a linguagem do banco de dados Oracle; e PL/SQL - Dominando packages', '2023-01-01 00:00:00', '2023-01-31 00:00:00', 40);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (265, 10, 3, 'Programação JAVA', NULL, 'Alura', 'Java JRE e JDK: compile e execute o seu programa; Java OO - entendendo a Orientação a Objetos; Java Polimorfismo - entenda herança e interfaces; Java Exceções - aprenda a criar, lançar e controlar exceções; Java e java.lang - programe com a classe Object e String; Java e java.util - Coleções, Wrappers e Lambda expressions; Java e java.io - Streams, Reader e Writers', '2023-01-01 00:00:00', '2023-01-31 00:00:00', 80);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (266, 10, 3, 'Agilista', NULL, 'Alura', 'Lean Startup - primeiros passos da sua Startup enxuta; Métodos Ágeis - Introdução; Scrum - agilidade em seu projeto; Agile na prática - técnicas aplicadas para Gestão Ágil', '2023-01-01 00:00:00', '2023-01-31 00:00:00', 35);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (267, 10, 3, 'Certificações Microsoft MCP & MCAD', NULL, 'Microsoft', 'Código da credencial B252-4585, expirado em 2009', '2007-01-01 00:00:00', '2007-01-31 00:00:00', 0);
INSERT INTO public.resume_courses (course_id, resume_id, course_type, title, location, institute, resume, start_date, end_date, workload) VALUES (268, 10, 3, 'Gerenciamento de Projetos + MS Project', NULL, 'Hepta', 'Código da credencial B252-4585, expirado em 2009', '2004-01-01 00:00:00', '2004-01-31 00:00:00', 56);


--
-- TOC entry 4525 (class 0 OID 17552)
-- Dependencies: 229
-- Data for Name: resume_info_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4524 (class 0 OID 17538)
-- Dependencies: 228
-- Data for Name: resume_infos; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_infos (info_id, resume_id, title, resume, url, info_type) VALUES (78, 10, 'LinkedIn', NULL, 'https://linkedin.com/in/rodrigolandim', 1);
INSERT INTO public.resume_infos (info_id, resume_id, title, resume, url, info_type) VALUES (79, 10, 'GitHub', NULL, 'https://github.com/landim32', 1);


--
-- TOC entry 4519 (class 0 OID 17490)
-- Dependencies: 223
-- Data for Name: resume_job_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3593);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3594);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3595);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3596);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3597);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3598);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3599);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3600);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3601);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3602);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3603);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3604);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3605);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3606);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3607);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3608);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3609);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3610);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3611);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3612);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3613);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3614);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3615);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3616);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3617);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3618);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3619);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3620);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3621);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3622);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3623);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3624);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3625);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3626);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (273, 3627);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3628);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3629);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3630);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3631);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3632);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3633);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3634);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3635);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3636);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3637);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3638);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3639);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3640);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3641);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3642);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3643);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3644);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3645);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3646);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3647);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3648);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3649);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3650);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3651);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3652);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3653);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3654);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3655);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3656);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3657);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3658);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (274, 3659);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3660);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3661);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3662);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3663);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3664);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3665);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3666);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3667);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3668);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3669);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3670);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3671);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3672);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3673);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3674);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3675);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3676);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3677);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3678);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3679);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3680);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (275, 3681);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3682);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3683);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3684);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3685);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3686);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3687);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3688);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3689);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3690);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3691);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3692);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3693);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3694);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3695);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3696);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3697);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3698);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3699);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3700);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3701);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3702);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3703);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3704);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3705);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3706);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (276, 3707);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3708);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3709);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3710);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3711);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3712);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3713);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3714);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3715);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3716);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3717);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3718);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3719);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3720);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3721);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3722);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3723);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3724);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3725);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3726);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3727);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3728);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3729);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3730);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (277, 3731);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3732);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3733);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3734);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3735);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3736);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3737);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3738);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3739);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3740);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3741);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3742);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3743);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3744);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3745);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3746);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3747);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3748);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3749);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (278, 3750);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3751);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3752);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3753);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3754);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3755);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3756);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3757);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3758);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3759);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3760);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3761);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3762);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (279, 3763);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3764);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3765);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3766);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3767);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3768);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3769);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3770);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3771);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3772);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3773);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3774);
INSERT INTO public.resume_job_skills (job_id, skill_id) VALUES (280, 3775);


--
-- TOC entry 4516 (class 0 OID 17469)
-- Dependencies: 220
-- Data for Name: resume_jobs; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (273, 10, 'Desenvolvedor Sênior', 'BTG Pactual', 'Beyond Soluções (outsourcing)', '2025-08-01 00:00:00', NULL, 'Remoto', '* Atua como Desenvolvedor Sênior outsourcing para o banco **BTG Pactual**, participando do desenvolvimento de integração e validação de clientes off-shore de toda a América Latina, responsável por processar **+100 mil** registros internacionais por mês, garantindo padronização e conformidade regulatória;
* Redução estimada de **40%** no tempo de onboarding ao automatizar fluxos complexos e integração de multiplos serviços com **AWS SNS/SQS**, **AWS EKS**, **.NET Core**, **Angular**, **APIs RESTful**, **Redis** e **SQL Server**.
* Aceleração de entregas em **30%** por meio de **pipelines CI/CD**, **testes automatizados** e aplicação rigorosa de **Clean Code**, **SOLID** e **DDD**.
* Elevação da observabilidade em **80%** com **DataDog**, métricas customizadas e logs estruturados, permitindo resposta mais rápida a incidentes.');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (274, 10, 'Tech Lead/Arquiteto de Software', 'Caixa', 'Benner (outsourcing)', '2023-11-01 00:00:00', '2025-07-01 00:00:00', 'Híbrido (Brasília/DF)', '* Planejei e implementei o sistema de auditoria médica da **Caixa** usando **.NET Core**, **React**, **RabbitMQ** e princípios de **SOLID**, **DDD**, **CQRS** e **Clean Code**, permitindo auditorias externas totalmente rastreáveis;
* Reaproveitei código legado por meio de uma **arquitetura orientada a eventos**, reduzindo retrabalho e acelerando a entrega das integrações;
* Desenvolvi a interface externa de auditoria, otimizando o fluxo de análise e **aumentando a velocidade das auditorias em 30%**;
* **Redução de 40% nos custos operacionais** ao viabilizar a terceirização segura do processo de auditoria por meio de automação e desacoplamento do fluxo interno;');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (275, 10, 'Desenvolvedor Sênior', 'Cassi', 'Benner (outsourcing)', '2019-01-01 00:00:00', '2023-10-01 00:00:00', 'Remoto/Híbrido (Brasília/DF)', '* Atuei na sustentação do sistema de gestão de saúde da **Cassi**, garantindo funcionamento contínuo de uma plataforma usada diariamente por milhares de beneficiários e equipes internas, assegurando **alta disponibilidade** e **operação estável 24/7**;
* Monitorei, diagnostiquei e corrigi incidentes e falhas críticas, aplicando análise de causa raiz e ajustes preventivos, reduzindo recorrência de erros operacionais em mais de **25%**;
* Apoiei squads e áreas de negócio na evolução de demandas estratégicas, garantindo fluidez nos processos e minimizando impactos em períodos de pico, o que manteve **SLA** de atendimento **acima de 95%**;
* Melhorei fluxos internos e estabilidade de integrações legadas, aplicando boas práticas de manutenção e padronização, aumentando a confiabilidade geral do sistema para atender operações de saúde em nível nacional.');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (276, 10, 'Desenvolvedor Sênior', 'Caixa Seguradora', 'Foursys (outsourcing)', '2017-08-01 00:00:00', '2019-01-01 00:00:00', 'Presencial (Barieri - SP)', '* Desenvolvi frontend e backend do app **Odonto & Saúde**, modernizando experiência e fluxo de serviços, o que elevou significativamente a nota do aplicativo nas stores;
* Corrigi falhas críticas e otimizei performance, melhorando usabilidade e estabilidade e reduzindo reclamações e abandono;
* Implementei novas funcionalidades e integrações essenciais, garantindo operação fluida e confiável para milhares de usuários, atualmente se chama **Odonto Empresas**.');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (277, 10, 'Dev. Sênior', 'Club Management Apps', NULL, '2016-08-01 00:00:00', '2017-07-01 00:00:00', 'Brasília - DF', '* Desenvolvi um aplicativo completo de **gestão de obras**, digitalizando processos manuais e centralizando informações operacionais, o que aumentou a eficiência das equipes de campo e reduziu retrabalho em até **40%**;
* Criei um app de rastreamento por **geolocalização**, permitindo monitoramento em tempo real de equipes e ativos, aumentando a precisão das operações e diminuindo falhas de comunicação;
* Atuei no ciclo completo dos produtos - arquitetura, desenvolvimento e melhorias contínuas — garantindo estabilidade, boa experiência do usuário e adoção consistente dos aplicativos;');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (278, 10, 'Tech Lead/Desenv. Sênior', 'Emagine', NULL, '2011-01-01 00:00:00', '2016-08-01 00:00:00', 'Brasília - DF', '* Desenvolvi um **sistema completo** de **gestão imobiliária**, reunindo controle de imóveis, clientes, contratos e fluxos de venda em uma plataforma unificada, aumentando a eficiência operacional das imobiliárias e reduzindo tarefas manuais em até **50%**;
* Implementei integrações com **portais imobiliários**, redes sociais e CRM, automatizando a publicação de anúncios e captação de leads, o que ampliou significativamente o alcance digital e acelerou o ciclo de vendas;
* Atuei no ciclo completo do produto — arquitetura, backend, frontend e integrações externas — garantindo um sistema robusto, escalável e capaz de suportar alto volume de anúncios, acessos e atualizações em tempo real.');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (279, 10, 'Tech Lead/Desenv. Sênior', 'Wimoveis', NULL, '2005-09-01 00:00:00', '2011-11-01 00:00:00', 'Brasília - DF', '* Liderei o desenvolvimento e a evolução técnica do **maior portal** imobiliário do **Distrito Federal**, modernizando arquitetura, integrando novos recursos e otimizando performance, o que impulsionou o portal a dominar **90% do mercado** regional;
* Implementei melhorias estratégicas em usabilidade, SEO, integrações e estabilidade, aumentando tráfego qualificado, engajamento de anunciantes e conversão de leads, contribuindo diretamente para tornar o produto o principal ativo digital do segmento;
* Atuei de ponta a ponta no produto — backend, frontend, integrações e escalabilidade — garantindo alta disponibilidade e suporte ao crescimento acelerado, reforçando a valuation que resultou na **venda do Wimoveis por** mais de **R$ 50 milhões** para o ImovelWeb.');
INSERT INTO public.resume_jobs (job_id, resume_id, "position", business1, business2, start_date, end_date, location, resume) VALUES (280, 10, 'Desenvolvedor Pleno', 'Implanta', NULL, '2003-07-01 00:00:00', '2005-08-01 00:00:00', 'Brasília - DF', '* Contribuí para o desenvolvimento de um sistema robusto voltado a Conselhos Profissionais, melhorando processos administrativos e elevando a confiabilidade das operações;
* Iniciei e conduzi o projeto de migração da plataforma do modelo desktop para uma arquitetura web moderna, abrindo caminho para maior escalabilidade, facilidade de manutenção e expansão tecnológica;
* Implementei melhorias estruturais no código, preparando o terreno para futura adoção de práticas mais modernas e garantindo um ciclo de evolução contínuo do produto.');


--
-- TOC entry 4527 (class 0 OID 17569)
-- Dependencies: 231
-- Data for Name: resume_languages; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_languages (language_id, resume_id, language, level) VALUES (74, 10, 'Português', 5);
INSERT INTO public.resume_languages (language_id, resume_id, language, level) VALUES (75, 10, 'Inglês (B2)', 3);


--
-- TOC entry 4530 (class 0 OID 17617)
-- Dependencies: 234
-- Data for Name: resume_project_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3776);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3777);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3778);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3779);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3780);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3781);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3782);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3783);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3784);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3785);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3786);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3787);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3788);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3789);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (27, 3790);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (28, 3791);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (28, 3792);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (28, 3793);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (28, 3794);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (28, 3795);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (28, 3796);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3797);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3798);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3799);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3800);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3801);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3802);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3803);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3804);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3805);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3806);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3807);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3808);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3809);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3810);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3811);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3812);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3813);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3814);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3815);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3816);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3817);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (29, 3818);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3819);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3820);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3821);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3822);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3823);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3824);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3825);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3826);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3827);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3828);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3829);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3830);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3831);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3832);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3833);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3834);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3835);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3836);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (30, 3837);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3838);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3839);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3840);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3841);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3842);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3843);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3844);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3845);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3846);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3847);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3848);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3849);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3850);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3851);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (31, 3852);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3853);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3854);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3855);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3856);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3857);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3858);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3859);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3860);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3861);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3862);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3863);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3864);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3865);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3866);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (32, 3867);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3868);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3869);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3870);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3871);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3872);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3873);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3874);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3875);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3876);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3877);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3878);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3879);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3880);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3881);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3882);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3883);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3884);
INSERT INTO public.resume_project_skills (project_id, skill_id) VALUES (33, 3885);


--
-- TOC entry 4529 (class 0 OID 17603)
-- Dependencies: 233
-- Data for Name: resume_projects; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (27, 10, 'Consumidor Positivo', '2020-01-01 00:00:00', '* Atuei como desenvolvedor no app **Consumidor Positivo**, contribuindo para a implementação de funcionalidades essenciais e melhorias de usabilidade, ajudando o aplicativo a alcançar mais de **5 milhões de downloads** e **130 mil avaliações**;
* Aprimorei fluxos internos e otimizações de interface, elevando a experiência do usuário e garantindo alta estabilidade do app, refletida na nota **4,8** na **Google Play** — um dos maiores índices da categoria;
* Colaborei com a equipe da **Foursys** de forma ágil e integrada, acelerando o desenvolvimento de novas features e correções, o que contribuiu para manter o ritmo de entregas e a satisfação dos usuários finais.', 'https://www.consumidorpositivo.com.br/', 1);
INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (28, 10, 'LadinoBot', '2017-01-01 00:00:00', '* Em um mercado financeiro carente de automação acessível e confiável, traders buscavam ferramentas melhores;
* Criei o **LadinoBot**, um bot de operações com algoritmos próprios, configuração simples e alta estabilidade;
* O produto foi amplamente **comercializado** em **2018**, tornando-se reconhecido pela eficiência e facilidade de uso entre traders.', 'https://github.com/landim32/LadinoBot', 1);
INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (29, 10, 'Resume CV', '2025-01-01 00:00:00', '* Desenvolvi o ResumoCV, um **micro SaaS** para criação rápida de **currículos** personalizados, usando **.NET Core**, **React**, **PostgreSQL** e **Kubernetes** para entregar uma plataforma leve e escalável, ajudando usuários a gerar currículos profissionais em menos de 5 minutos;
* Implementei templates inteligentes e edição guiada, simplificando a montagem de resumos e experiências e aumentando significativamente a qualidade visual e a clareza do currículo final;
* Criei um **pipeline** enxuto e automatizado, garantindo alta disponibilidade, agilidade de implantação e baixo custo operacional, viabilizando o funcionamento do SaaS com mínima intervenção.', 'https://github.com/landim32/ResumeCV', 2);
INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (30, 10, 'NoChainSwap', '2023-01-01 00:00:00', '* Percebi a necessidade de uma forma segura e descentralizada de converter **criptomoedas** entre **blockchains** diferentes;
* Criei o **NoChainSwap**, uma solução de **Atomic Swap** usando a camada **Stacks**, permitindo trocas automáticas e trustless sem exchanges centralizadas;
* Entreguei uma experiência multichain segura e sem custódia, dando total autonomia ao usuário e eliminando riscos de congelamento ou censura;
* O projeto foi **descontinuado** por causa de uma lei impedindo conversão de criptomoedas sem KYC.', 'https://github.com/landim32/NoChainSwap', 4);
INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (31, 10, 'NTools', '2024-01-01 00:00:00', '* Criei o **NTools**, um **microserviço** de utilidades que centraliza envio de e-mails, tratamento de strings, upload de arquivos e funções comuns, reduzindo em até **40%** a duplicação de código entre sistemas;
* Implementei APIs padronizadas e modulares, facilitando integrações e acelerando entregas em outros serviços, diminuindo o tempo de desenvolvimento em cerca de **30%**.', 'https://github.com/landim32/NTools', 1);
INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (32, 10, 'NAuth', '2024-01-01 00:00:00', '* Criei o **NAuth**, micro serviço de autenticação e autorização com login, CRUD de usuários, permissões e emissão de **tokens JWT**. Padronizou a identidade da plataforma e reduziu falhas de autenticação.', 'https://github.com/landim32/NAuth', 1);
INSERT INTO public.resume_projects (project_id, resume_id, title, start_date, resume, url, status) VALUES (33, 10, 'GoblinWars', '2021-01-01 00:00:00', '* Identifiquei a oportunidade de criar uma experiência gamificada que combinasse NFTs, economia digital e narrativas imersivas;
* Desenvolvi o **Goblin Wars**, um jogo **blockchain** construído sobre a **BNB Chain** (compatível com a estrutura do **Ethereum**), integrando criação, gestão e transações de **NFTs** dentro da mecânica de progressão do jogo;
* O projeto entregou uma economia descentralizada robusta, permitindo que jogadores realmente possuíssem seus ativos digitais e movimentassem itens de forma transparente e auditável on-chain.', 'https://goblinwars.net', 1);


--
-- TOC entry 4518 (class 0 OID 17483)
-- Dependencies: 222
-- Data for Name: resume_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--

INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3593, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3594, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3595, 1, 'angular', 'Angular');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3596, 1, 'typescript', 'TypeScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3597, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3598, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3599, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3600, 1, 'bootstrap', 'Bootstrap');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3601, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3602, 2, 'redis', 'Redis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3603, 2, 'sqlserver', 'Microsoft SQL Server');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3604, 2, 'postgres', 'PostGresSQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3605, 2, 'mysql', 'MySQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3606, 2, 'mongodb', 'MongoDB');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3607, 2, 'dynamodb', 'DynamoDB');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3608, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3609, 14, 'datadog', 'DataDog');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3610, 2, 'sonarqube', 'Sonarqube');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3611, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3612, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3613, 7, 'azure-devops', 'Azure DevOps');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3614, 2, 'graphql', 'GraphQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3615, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3616, 9, 'sns-sqs', 'AWS SNS/SQS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3617, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3618, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3619, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3620, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3621, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3622, 10, 'xunit', 'xUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3623, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3624, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3625, 11, 'scrum', 'Scrum');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3626, 11, 'kanban', 'Kanban');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3627, 11, 'metodologiasagieis', 'Metodologias Ágeis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3628, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3629, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3630, 1, 'delphi', 'Delphi');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3631, 1, 'vbscript', 'VBScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3632, 1, 'react', 'React');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3633, 1, 'typescript', 'TypeScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3634, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3635, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3636, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3637, 1, 'bootstrap', 'Bootstrap');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3638, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3639, 2, 'mongodb', 'MongoDB');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3640, 2, 'oracle', 'Oracle');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3641, 2, 'plsql', 'PL/SQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3642, 9, 'docker', 'Docker');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3643, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3644, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3645, 7, 'githubactions', 'GitHub Actions');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3646, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3647, 9, 'ecs', 'AWS ECS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3648, 9, 'ec2', 'AWS EC2');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3649, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3650, 4, 'rabbitmq', 'RabbitMQ');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3651, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3652, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3653, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3654, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3655, 10, 'xunit', 'xUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3656, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3657, 11, 'scrum', 'Scrum');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3658, 11, 'kanban', 'Kanban');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3659, 11, 'metodologiasagieis', 'Metodologias Ágeis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3660, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3661, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3662, 1, 'delphi', 'Delphi');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3663, 1, 'vbscript', 'VBScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3664, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3665, 3, 'webservices', 'Webservices');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3666, 2, 'oracle', 'Oracle');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3667, 2, 'plsql', 'PL/SQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3668, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3669, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3670, 7, 'githubactions', 'GitHub Actions');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3671, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3672, 9, 'ec2', 'AWS EC2');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3673, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3674, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3675, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3676, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3677, 10, 'xunit', 'xUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3678, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3679, 11, 'scrum', 'Scrum');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3680, 11, 'kanban', 'Kanban');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3681, 11, 'metodologiasagieis', 'Metodologias Ágeis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3682, 1, 'titanium', 'Titanium');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3683, 1, 'appcelerator', 'Appcelerator');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3684, 1, 'reactnative', 'React Native');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3685, 1, 'typescript', 'TypeScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3686, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3687, 1, 'swift', 'Swift');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3688, 1, 'java', 'Java');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3689, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3690, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3691, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3692, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3693, 1, 'bootstrap', 'Bootstrap');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3694, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3695, 3, 'webservices', 'Webservices');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3696, 2, 'mssqlserver', 'Microsoft SQL Server');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3697, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3698, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3699, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3700, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3701, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3702, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3703, 10, 'xunit', 'xUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3704, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3705, 11, 'scrum', 'Scrum');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3706, 11, 'kanban', 'Kanban');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3707, 11, 'metodologiasagieis', 'Metodologias Ágeis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3708, 1, 'titanium', 'Titanium');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3709, 1, 'appcelerator', 'Appcelerator');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3710, 1, 'reactnative', 'React Native');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3711, 1, 'typescript', 'TypeScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3712, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3713, 1, 'swift', 'Swift');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3714, 1, 'java', 'Java');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3715, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3716, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3717, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3718, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3719, 1, 'bootstrap', 'Bootstrap');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3720, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3721, 2, 'mssqlserver', 'Microsoft SQL Server');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3722, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3723, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3724, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3725, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3726, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3727, 10, 'nunit', 'nUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3728, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3729, 11, 'scrum', 'Scrum');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3730, 11, 'kanban', 'Kanban');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3731, 11, 'metodologiasagieis', 'Metodologias Ágeis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3732, 1, 'php', 'PHP');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3733, 1, 'laravel', 'Laravel');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3734, 1, 'ionic', 'Ionic');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3735, 1, 'wordpress', 'Wordpress');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3736, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3737, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3738, 1, 'aspnet', 'ASP.NET');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3739, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3740, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3741, 1, 'bootstrap', 'Bootstrap');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3742, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3743, 2, 'mssqlserver', 'Microsoft SQL Server');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3744, 2, 'mysql', 'MySQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3745, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3746, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3747, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3748, 11, 'scrum', 'Scrum');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3749, 11, 'kanban', 'Kanban');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3750, 11, 'metodologiasagieis', 'Metodologias Ágeis');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3751, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3752, 1, 'aspnet', 'ASP.NET');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3753, 1, 'angular', 'Angular');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3754, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3755, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3756, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3757, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3758, 3, 'webservices', 'Webservices');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3759, 2, 'sqlserver', 'Microsoft SQL Server');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3760, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3761, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3762, 10, 'nunit', 'nUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3763, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3764, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3765, 1, 'aspnet', 'ASP.NET');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3766, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3767, 1, 'jquery', 'jQuery');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3768, 1, 'delphi', 'Delphi');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3769, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3770, 3, 'webservices', 'Webservices');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3771, 2, 'sqlserver', 'Microsoft SQL Server');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3772, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3773, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3774, 10, 'nunit', 'nUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3775, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3776, 1, 'reactnative', 'React Native');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3777, 1, 'nodejs', 'Node.JS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3778, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3779, 2, 'mongodb', 'MongoDB');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3780, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3781, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3782, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3783, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3784, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3785, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3786, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3787, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3788, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3789, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3790, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3791, 1, 'mql5', 'MQL5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3792, 1, 'cplusplus', 'C++');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3793, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3794, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3795, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3796, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3797, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3798, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3799, 1, 'react', 'React');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3800, 1, 'typescript', 'TypeScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3801, 1, 'javascript', 'JavaScript');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3802, 1, 'html5', 'HTML5');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3803, 1, 'css', 'CSS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3804, 1, 'tailwind', 'Tailwind');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3805, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3806, 2, 'postgres', 'PostGresSQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3807, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3808, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3809, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3810, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3811, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3812, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3813, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3814, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3815, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3816, 10, 'xunit', 'xUnit');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3817, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3818, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3819, 1, 'solidity', 'Solidity');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3820, 1, 'claridity', 'Claridity');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3821, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3822, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3823, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3824, 2, 'postgres', 'PostGresSQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3825, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3826, 9, 'web3', 'Web3');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3827, 9, 'blockchain', 'Blockchain');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3828, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3829, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3830, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3831, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3832, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3833, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3834, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3835, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3836, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3837, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3838, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3839, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3840, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3841, 2, 'postgres', 'PostGresSQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3842, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3843, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3844, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3845, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3846, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3847, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3848, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3849, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3850, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3851, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3852, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3853, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3854, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3855, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3856, 2, 'postgres', 'PostGresSQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3857, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3858, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3859, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3860, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3861, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3862, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3863, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3864, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3865, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3866, 10, 'testesunitarios', 'Testes Unitários');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3867, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3868, 1, 'solidity', 'Solidity');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3869, 1, 'csharp', 'C#');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3870, 1, 'netcore', '.NET Core');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3871, 3, 'apiresful', 'Api Restful');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3872, 2, 'postgres', 'PostGresSQL');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3873, 9, 'kubernetes', 'Kubernetes');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3874, 9, 'web3', 'Web3');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3875, 9, 'blockchain', 'Blockchain');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3876, 7, 'github', 'GitHub');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3877, 7, 'cicd', 'CI/CD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3878, 9, 'aws', 'AWS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3879, 9, 'eks', 'AWS EKS');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3880, 9, 'cloudformation', 'Cloudformation');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3881, 6, 'solid', 'SOLID');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3882, 6, 'cleancode', 'Clean Code');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3883, 6, 'ddd', 'DDD');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3884, 6, 'designpatterns', 'Design Patterns');
INSERT INTO public.resume_skills (skill_id, skill_type, slug, name) VALUES (3885, 10, 'testesunitarios', 'Testes Unitários');


--
-- TOC entry 4544 (class 0 OID 0)
-- Dependencies: 224
-- Name: resume_courses_course_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_courses_course_id_seq', 268, true);


--
-- TOC entry 4545 (class 0 OID 0)
-- Dependencies: 227
-- Name: resume_infos_info_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_infos_info_id_seq', 79, true);


--
-- TOC entry 4546 (class 0 OID 0)
-- Dependencies: 219
-- Name: resume_jobs_job_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_jobs_job_id_seq', 280, true);


--
-- TOC entry 4547 (class 0 OID 0)
-- Dependencies: 230
-- Name: resume_languages_language_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_languages_language_id_seq', 75, true);


--
-- TOC entry 4548 (class 0 OID 0)
-- Dependencies: 232
-- Name: resume_projects_project_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_projects_project_id_seq', 33, true);


--
-- TOC entry 4549 (class 0 OID 0)
-- Dependencies: 217
-- Name: resume_resume_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_resume_id_seq', 10, true);


--
-- TOC entry 4550 (class 0 OID 0)
-- Dependencies: 221
-- Name: resume_skills_skill_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_skills_skill_id_seq', 3885, true);


-- Completed on 2025-12-04 11:15:34

--
-- PostgreSQL database dump complete
--

\unrestrict CtlX7ScG63S6yUujHeuziBTstmbDaiof7vJHEqcMkt3GM1VVCoaPpNExYb1r0oG

