
\connect managesiodb

CREATE TABLE todo
(
    id serial PRIMARY KEY,
    title  VARCHAR (50)  NOT NULL,
    note  VARCHAR (100)  NOT NULL
);

ALTER TABLE "todo" OWNER TO managesiouser;

Insert into todo(title,note) values( 'Title 1','Note 1');
Insert into todo(title,note) values( 'Title 2','Note 2');
Insert into todo(title,note) values( 'Title 3','Note 3');
Insert into todo(title,note) values( 'Title 4','Note 4');