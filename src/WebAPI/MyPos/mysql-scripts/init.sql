CREATE DATABASE IF NOT EXISTS account;
CREATE DATABASE IF NOT EXISTS catalogs;


use account;
CREATE TABLE credentials (
    UserName varchar(255) NOT NULL,
    Password varchar(255) NOT NULL,
    LastLogin datetime NOT NULL,
    PRIMARY KEY (UserName)
);
INSERT INTO account.credentials VALUES('admin','admin','1998-01-23 12:45:56');

use catalogs;
CREATE TABLE catalog(
	CatalogId int NOT NULL,
    CatalogType varchar(255) NOT NULL,
    PRIMARY KEY (CatalogId),
    FOREIGN KEY (CatalogId) REFERENCES item(CatalogId)
);

INSERT INTO catalogs.catalog VALUES('1','GENERAL');

CREATE TABLE item(
	ItemId int NOT NULL,
    CatalogId int NOT NULL,
    Name varchar(255) NOT NULL,
    BarCode varchar(255) NOT NULL,
    UOM varchar(255) NOT NULL,
    HSNCode varchar(255) ,
    PurchaseRate decimal NOT NULL,
    Profile decimal,
    MRP decimal NOT NULL,
    Discount decimal ,
    Tax varchar(25) NOT NULL ,
    CouponRate decimal ,
    CardRate decimal ,
    PRIMARY KEY (ItemId)
);

INSERT INTO catalogs.item VALUES('1','1',"SOAP","100017","1",NULL,0,NULL,10.0,5.0,"10%",NULL,NULL);
