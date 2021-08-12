use account;
CREATE TABLE credentials (
    UserName varchar(255) NOT NULL,
    Password varchar(255) NOT NULL,
    LastLogin datetime NOT NULL,
    PRIMARY KEY (UserName)
);
insert into account.credentials values('admin','admin','1998-01-23 12:45:56');