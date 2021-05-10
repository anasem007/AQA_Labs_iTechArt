create table users
(
	id serial not null,
	firstname varchar,
	lastname varchar
);

create unique index users_id_uindex
	on users (id);

alter table users
	add constraint users_pk
		primary key (id);

INSERT INTO users ("firstname", "lastname") VALUES ('Шмщк', 'Иванов');
INSERT INTO users ("firstname", "lastname") VALUES ('Иван', 'Иванов');
INSERT INTO users ("firstname", "lastname") VALUES ('Иван', 'Иванов');