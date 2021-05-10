create table projects
(
    name              varchar,
    announcement      varchar,
    show_announcement boolean,
    suite_mode        varchar,
    id serial not null
);

create unique index projects_id_uindex
    on projects (id);

alter table projects
    add constraint projects_pk
        primary key (id);

INSERT INTO projects ("name", "suite_mode") VALUES ('Test Project', 'suite_mode_single_baseline');
INSERT INTO projects ("name", "suite_mode") VALUES ('Test Project pgSql', 'suite_mode_single_baseline');