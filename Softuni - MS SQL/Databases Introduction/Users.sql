--08.
CREATE TABLE Users(
   Id INT IDENTITY(1,1) NOT NULL,
   Username VARCHAR(30) NOT NULL,
   [Password] VARCHAR(26) NOT NULL,
   ProfilePicture VARBINARY(max) NULL,
   LastLoginTime DATE NULL,
   IsDeleted VARCHAR(5) NOT NULL
   CHECK (IsDeleted in ('true','false'))
   CONSTRAINT PK PRIMARY KEY(Id)
 );
 INSERT INTO Users (Username,[Password],ProfilePicture,
 LastLoginTime,IsDeleted) 
 VALUES 
 ('Viktor','MYSUPERSECRETPASS',12,'2022-12-12','true'),
 ('Stanka','STANKA123',122,NULL,'false'),
 ('Sasha','chemistryFORTHEwin',222,NULL,'false'),
 ('Stefan','minecraft.1111',NULL,NULL,'true'),
 ('Simon','boredlife.com',100,'2021-11-08','false');
 --09.
 ALTER TABLE Users DROP CONSTRAINT PK;
 ALTER TABLE Users ADD CONSTRAINT pk_id_user PRIMARY KEY (Id,Username);
 --10.
 ALTER TABLE Users ADD CHECK (LEN(Password)>=5);
 --11.
 ALTER TABLE Users ADD CONSTRAINT df_Login DEFAULT GETDATE() FOR LastLoginTime;
 --12.
 ALTER TABLE Users DROP CONSTRAINT pk_id_user;
 ALTER TABLE Users ADD CONSTRAINT pk_id PRIMARY KEY(Id);
 ALTER TABLE Users
 ADD CONSTRAINT uc_username CHECK (LEN(Username) >= 3);