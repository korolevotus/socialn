
CREATE DATABASE socnet;


CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE users (
	id uuid NULL DEFAULT uuid_generate_v1(),
	first_name varchar NULL,
	second_name varchar NOT NULL,
	age int4 NULL,
	biography text NULL,
	city varchar NULL,
	"password" varchar NOT NULL,
	salt varchar NOT NULL,
	login varchar NULL
);