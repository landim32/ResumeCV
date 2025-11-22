--
-- PostgreSQL database dump
--

\restrict KuEKMGVKtytFIlq1VIjAlUQkdq5YjvulOuxDoNKSXWskXmOXWiBqhoitEeBTrBm

-- Dumped from database version 17.6
-- Dumped by pg_dump version 17.6

-- Started on 2025-11-21 10:00:37

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
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4522 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 17459)
-- Name: resume; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume (
    resume_id bigint NOT NULL,
    user_id bigint NOT NULL,
    name character varying(200) NOT NULL,
    phone character varying(30) NOT NULL,
    email character varying(180) NOT NULL,
    status integer DEFAULT 1 NOT NULL,
    address character varying(300),
    resume character varying(3000),
    title character varying(200) NOT NULL
);


ALTER TABLE public.resume OWNER TO doadmin;

--
-- TOC entry 228 (class 1259 OID 17521)
-- Name: resume_course_skills; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_course_skills (
    course_skill_id bigint NOT NULL,
    course_id bigint NOT NULL,
    skill_id bigint NOT NULL
);


ALTER TABLE public.resume_course_skills OWNER TO doadmin;

--
-- TOC entry 227 (class 1259 OID 17520)
-- Name: resume_course_skills_course_skill_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_course_skills_course_skill_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_course_skills_course_skill_id_seq OWNER TO doadmin;

--
-- TOC entry 4523 (class 0 OID 0)
-- Dependencies: 227
-- Name: resume_course_skills_course_skill_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_course_skills_course_skill_id_seq OWNED BY public.resume_course_skills.course_skill_id;


--
-- TOC entry 226 (class 1259 OID 17507)
-- Name: resume_courses; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_courses (
    course_id bigint NOT NULL,
    resume_id bigint NOT NULL,
    course_type integer,
    title character varying(560) NOT NULL,
    location character varying(200),
    institute character varying(300),
    resume character varying(3000),
    start_date timestamp without time zone,
    end_date timestamp without time zone
);


ALTER TABLE public.resume_courses OWNER TO doadmin;

--
-- TOC entry 225 (class 1259 OID 17506)
-- Name: resume_courses_course_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_courses_course_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_courses_course_id_seq OWNER TO doadmin;

--
-- TOC entry 4524 (class 0 OID 0)
-- Dependencies: 225
-- Name: resume_courses_course_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_courses_course_id_seq OWNED BY public.resume_courses.course_id;


--
-- TOC entry 232 (class 1259 OID 17552)
-- Name: resume_info_skills; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_info_skills (
    info_skill_id bigint NOT NULL,
    info_id bigint NOT NULL,
    skill_id bigint NOT NULL
);


ALTER TABLE public.resume_info_skills OWNER TO doadmin;

--
-- TOC entry 231 (class 1259 OID 17551)
-- Name: resume_info_skills_info_skill_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_info_skills_info_skill_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_info_skills_info_skill_id_seq OWNER TO doadmin;

--
-- TOC entry 4525 (class 0 OID 0)
-- Dependencies: 231
-- Name: resume_info_skills_info_skill_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_info_skills_info_skill_id_seq OWNED BY public.resume_info_skills.info_skill_id;


--
-- TOC entry 230 (class 1259 OID 17538)
-- Name: resume_infos; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_infos (
    info_id bigint NOT NULL,
    resume_id bigint NOT NULL,
    title character varying(300) NOT NULL,
    resume character varying(3000),
    url character varying(520)
);


ALTER TABLE public.resume_infos OWNER TO doadmin;

--
-- TOC entry 229 (class 1259 OID 17537)
-- Name: resume_infos_info_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_infos_info_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_infos_info_id_seq OWNER TO doadmin;

--
-- TOC entry 4526 (class 0 OID 0)
-- Dependencies: 229
-- Name: resume_infos_info_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_infos_info_id_seq OWNED BY public.resume_infos.info_id;


--
-- TOC entry 224 (class 1259 OID 17490)
-- Name: resume_job_skills; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_job_skills (
    job_skill_id bigint NOT NULL,
    job_id bigint NOT NULL,
    skill_id bigint NOT NULL
);


ALTER TABLE public.resume_job_skills OWNER TO doadmin;

--
-- TOC entry 223 (class 1259 OID 17489)
-- Name: resume_job_skills_job_skill_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_job_skills_job_skill_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_job_skills_job_skill_id_seq OWNER TO doadmin;

--
-- TOC entry 4527 (class 0 OID 0)
-- Dependencies: 223
-- Name: resume_job_skills_job_skill_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_job_skills_job_skill_id_seq OWNED BY public.resume_job_skills.job_skill_id;


--
-- TOC entry 220 (class 1259 OID 17469)
-- Name: resume_jobs; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_jobs (
    job_id bigint NOT NULL,
    resume_id bigint NOT NULL,
    "position" character varying(120) NOT NULL,
    business1 character varying(120) NOT NULL,
    business2 character varying(120),
    start_date timestamp without time zone NOT NULL,
    end_date timestamp without time zone,
    location character varying(120),
    resume character varying(3000)
);


ALTER TABLE public.resume_jobs OWNER TO doadmin;

--
-- TOC entry 219 (class 1259 OID 17468)
-- Name: resume_jobs_job_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_jobs_job_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_jobs_job_id_seq OWNER TO doadmin;

--
-- TOC entry 4528 (class 0 OID 0)
-- Dependencies: 219
-- Name: resume_jobs_job_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_jobs_job_id_seq OWNED BY public.resume_jobs.job_id;


--
-- TOC entry 234 (class 1259 OID 17569)
-- Name: resume_languages; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_languages (
    language_id bigint NOT NULL,
    resume_id bigint NOT NULL,
    language character varying(180) NOT NULL,
    level integer DEFAULT 1 NOT NULL
);


ALTER TABLE public.resume_languages OWNER TO doadmin;

--
-- TOC entry 233 (class 1259 OID 17568)
-- Name: resume_languages_language_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_languages_language_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_languages_language_id_seq OWNER TO doadmin;

--
-- TOC entry 4529 (class 0 OID 0)
-- Dependencies: 233
-- Name: resume_languages_language_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_languages_language_id_seq OWNED BY public.resume_languages.language_id;


--
-- TOC entry 217 (class 1259 OID 17458)
-- Name: resume_resume_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_resume_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_resume_id_seq OWNER TO doadmin;

--
-- TOC entry 4530 (class 0 OID 0)
-- Dependencies: 217
-- Name: resume_resume_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_resume_id_seq OWNED BY public.resume.resume_id;


--
-- TOC entry 222 (class 1259 OID 17483)
-- Name: resume_skills; Type: TABLE; Schema: public; Owner: doadmin
--

CREATE TABLE public.resume_skills (
    skill_id bigint NOT NULL,
    user_id bigint NOT NULL,
    slug character varying(120) NOT NULL,
    name character varying(120) NOT NULL
);


ALTER TABLE public.resume_skills OWNER TO doadmin;

--
-- TOC entry 221 (class 1259 OID 17482)
-- Name: resume_skills_skill_id_seq; Type: SEQUENCE; Schema: public; Owner: doadmin
--

CREATE SEQUENCE public.resume_skills_skill_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.resume_skills_skill_id_seq OWNER TO doadmin;

--
-- TOC entry 4531 (class 0 OID 0)
-- Dependencies: 221
-- Name: resume_skills_skill_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: doadmin
--

ALTER SEQUENCE public.resume_skills_skill_id_seq OWNED BY public.resume_skills.skill_id;


--
-- TOC entry 4315 (class 2604 OID 17462)
-- Name: resume resume_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume ALTER COLUMN resume_id SET DEFAULT nextval('public.resume_resume_id_seq'::regclass);


--
-- TOC entry 4321 (class 2604 OID 17524)
-- Name: resume_course_skills course_skill_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_course_skills ALTER COLUMN course_skill_id SET DEFAULT nextval('public.resume_course_skills_course_skill_id_seq'::regclass);


--
-- TOC entry 4320 (class 2604 OID 17510)
-- Name: resume_courses course_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_courses ALTER COLUMN course_id SET DEFAULT nextval('public.resume_courses_course_id_seq'::regclass);


--
-- TOC entry 4323 (class 2604 OID 17555)
-- Name: resume_info_skills info_skill_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_info_skills ALTER COLUMN info_skill_id SET DEFAULT nextval('public.resume_info_skills_info_skill_id_seq'::regclass);


--
-- TOC entry 4322 (class 2604 OID 17541)
-- Name: resume_infos info_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_infos ALTER COLUMN info_id SET DEFAULT nextval('public.resume_infos_info_id_seq'::regclass);


--
-- TOC entry 4319 (class 2604 OID 17493)
-- Name: resume_job_skills job_skill_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_job_skills ALTER COLUMN job_skill_id SET DEFAULT nextval('public.resume_job_skills_job_skill_id_seq'::regclass);


--
-- TOC entry 4317 (class 2604 OID 17472)
-- Name: resume_jobs job_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_jobs ALTER COLUMN job_id SET DEFAULT nextval('public.resume_jobs_job_id_seq'::regclass);


--
-- TOC entry 4324 (class 2604 OID 17572)
-- Name: resume_languages language_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_languages ALTER COLUMN language_id SET DEFAULT nextval('public.resume_languages_language_id_seq'::regclass);


--
-- TOC entry 4318 (class 2604 OID 17486)
-- Name: resume_skills skill_id; Type: DEFAULT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_skills ALTER COLUMN skill_id SET DEFAULT nextval('public.resume_skills_skill_id_seq'::regclass);


--
-- TOC entry 4500 (class 0 OID 17459)
-- Dependencies: 218
-- Data for Name: resume; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4510 (class 0 OID 17521)
-- Dependencies: 228
-- Data for Name: resume_course_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4508 (class 0 OID 17507)
-- Dependencies: 226
-- Data for Name: resume_courses; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4514 (class 0 OID 17552)
-- Dependencies: 232
-- Data for Name: resume_info_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4512 (class 0 OID 17538)
-- Dependencies: 230
-- Data for Name: resume_infos; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4506 (class 0 OID 17490)
-- Dependencies: 224
-- Data for Name: resume_job_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4502 (class 0 OID 17469)
-- Dependencies: 220
-- Data for Name: resume_jobs; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4516 (class 0 OID 17569)
-- Dependencies: 234
-- Data for Name: resume_languages; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4504 (class 0 OID 17483)
-- Dependencies: 222
-- Data for Name: resume_skills; Type: TABLE DATA; Schema: public; Owner: doadmin
--



--
-- TOC entry 4532 (class 0 OID 0)
-- Dependencies: 227
-- Name: resume_course_skills_course_skill_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_course_skills_course_skill_id_seq', 1, false);


--
-- TOC entry 4533 (class 0 OID 0)
-- Dependencies: 225
-- Name: resume_courses_course_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_courses_course_id_seq', 1, false);


--
-- TOC entry 4534 (class 0 OID 0)
-- Dependencies: 231
-- Name: resume_info_skills_info_skill_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_info_skills_info_skill_id_seq', 1, false);


--
-- TOC entry 4535 (class 0 OID 0)
-- Dependencies: 229
-- Name: resume_infos_info_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_infos_info_id_seq', 1, false);


--
-- TOC entry 4536 (class 0 OID 0)
-- Dependencies: 223
-- Name: resume_job_skills_job_skill_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_job_skills_job_skill_id_seq', 1, false);


--
-- TOC entry 4537 (class 0 OID 0)
-- Dependencies: 219
-- Name: resume_jobs_job_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_jobs_job_id_seq', 1, false);


--
-- TOC entry 4538 (class 0 OID 0)
-- Dependencies: 233
-- Name: resume_languages_language_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_languages_language_id_seq', 1, false);


--
-- TOC entry 4539 (class 0 OID 0)
-- Dependencies: 217
-- Name: resume_resume_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_resume_id_seq', 1, false);


--
-- TOC entry 4540 (class 0 OID 0)
-- Dependencies: 221
-- Name: resume_skills_skill_id_seq; Type: SEQUENCE SET; Schema: public; Owner: doadmin
--

SELECT pg_catalog.setval('public.resume_skills_skill_id_seq', 1, false);


--
-- TOC entry 4337 (class 2606 OID 17526)
-- Name: resume_course_skills resume_course_skills_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_course_skills
    ADD CONSTRAINT resume_course_skills_pkey PRIMARY KEY (course_skill_id);


--
-- TOC entry 4335 (class 2606 OID 17514)
-- Name: resume_courses resume_courses_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_courses
    ADD CONSTRAINT resume_courses_pkey PRIMARY KEY (course_id);


--
-- TOC entry 4341 (class 2606 OID 17557)
-- Name: resume_info_skills resume_info_skills_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_info_skills
    ADD CONSTRAINT resume_info_skills_pkey PRIMARY KEY (info_skill_id);


--
-- TOC entry 4339 (class 2606 OID 17545)
-- Name: resume_infos resume_infos_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_infos
    ADD CONSTRAINT resume_infos_pkey PRIMARY KEY (info_id);


--
-- TOC entry 4333 (class 2606 OID 17495)
-- Name: resume_job_skills resume_job_skills_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_job_skills
    ADD CONSTRAINT resume_job_skills_pkey PRIMARY KEY (job_skill_id);


--
-- TOC entry 4329 (class 2606 OID 17476)
-- Name: resume_jobs resume_jobs_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_jobs
    ADD CONSTRAINT resume_jobs_pkey PRIMARY KEY (job_id);


--
-- TOC entry 4343 (class 2606 OID 17575)
-- Name: resume_languages resume_languages_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_languages
    ADD CONSTRAINT resume_languages_pkey PRIMARY KEY (language_id);


--
-- TOC entry 4327 (class 2606 OID 17467)
-- Name: resume resume_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume
    ADD CONSTRAINT resume_pkey PRIMARY KEY (resume_id);


--
-- TOC entry 4331 (class 2606 OID 17488)
-- Name: resume_skills resume_skills_pkey; Type: CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_skills
    ADD CONSTRAINT resume_skills_pkey PRIMARY KEY (skill_id);


--
-- TOC entry 4348 (class 2606 OID 17527)
-- Name: resume_course_skills resume_course_skills_course_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_course_skills
    ADD CONSTRAINT resume_course_skills_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.resume_courses(course_id);


--
-- TOC entry 4349 (class 2606 OID 17532)
-- Name: resume_course_skills resume_course_skills_skill_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_course_skills
    ADD CONSTRAINT resume_course_skills_skill_id_fkey FOREIGN KEY (skill_id) REFERENCES public.resume_skills(skill_id);


--
-- TOC entry 4347 (class 2606 OID 17515)
-- Name: resume_courses resume_courses_resume_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_courses
    ADD CONSTRAINT resume_courses_resume_id_fkey FOREIGN KEY (resume_id) REFERENCES public.resume(resume_id);


--
-- TOC entry 4351 (class 2606 OID 17558)
-- Name: resume_info_skills resume_info_skills_info_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_info_skills
    ADD CONSTRAINT resume_info_skills_info_id_fkey FOREIGN KEY (info_id) REFERENCES public.resume_infos(info_id);


--
-- TOC entry 4352 (class 2606 OID 17563)
-- Name: resume_info_skills resume_info_skills_skill_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_info_skills
    ADD CONSTRAINT resume_info_skills_skill_id_fkey FOREIGN KEY (skill_id) REFERENCES public.resume_skills(skill_id);


--
-- TOC entry 4350 (class 2606 OID 17546)
-- Name: resume_infos resume_infos_resume_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_infos
    ADD CONSTRAINT resume_infos_resume_id_fkey FOREIGN KEY (resume_id) REFERENCES public.resume(resume_id);


--
-- TOC entry 4345 (class 2606 OID 17496)
-- Name: resume_job_skills resume_job_skills_job_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_job_skills
    ADD CONSTRAINT resume_job_skills_job_id_fkey FOREIGN KEY (job_id) REFERENCES public.resume_jobs(job_id);


--
-- TOC entry 4346 (class 2606 OID 17501)
-- Name: resume_job_skills resume_job_skills_skill_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_job_skills
    ADD CONSTRAINT resume_job_skills_skill_id_fkey FOREIGN KEY (skill_id) REFERENCES public.resume_skills(skill_id);


--
-- TOC entry 4344 (class 2606 OID 17477)
-- Name: resume_jobs resume_jobs_resume_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_jobs
    ADD CONSTRAINT resume_jobs_resume_id_fkey FOREIGN KEY (resume_id) REFERENCES public.resume(resume_id);


--
-- TOC entry 4353 (class 2606 OID 17576)
-- Name: resume_languages resume_languages_resume_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: doadmin
--

ALTER TABLE ONLY public.resume_languages
    ADD CONSTRAINT resume_languages_resume_id_fkey FOREIGN KEY (resume_id) REFERENCES public.resume(resume_id);


-- Completed on 2025-11-21 10:01:00

--
-- PostgreSQL database dump complete
--

\unrestrict KuEKMGVKtytFIlq1VIjAlUQkdq5YjvulOuxDoNKSXWskXmOXWiBqhoitEeBTrBm

