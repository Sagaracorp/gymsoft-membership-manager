#TRUNCATE TABLE `gymsoft`.`gym_CustomerSubscription`;#TRUNCATE TABLE `gymsoft`.`gym_Visits`;#TRUNCATE TABLE `gymsoft`.`gym_NextOfKin`;#TRUNCATE TABLE `gymsoft`.`gym_SystemConfiguration`;#TRUNCATE TABLE `gymsoft`.`gym_CustomerMetrics`;#TRUNCATE TABLE `gymsoft`.`gym_AccountNotes`;#TRUNCATE TABLE `gymsoft`.`gym_UserCardMap`;#TRUNCATE TABLE `gymsoft`.`gym_AuditTrail`;#TRUNCATE TABLE `gymsoft`.`gym_Logs`;#TRUNCATE TABLE `gymsoft`.`gym_RoleUserMap`;#TRUNCATE TABLE `gymsoft`.`gym_RoleActionMap`;#TRUNCATE TABLE `gymsoft`.`gym_Actions`;#TRUNCATE TABLE `gymsoft`.`gym_Cards`;#TRUNCATE TABLE `gymsoft`.`gym_Subscriptions`;#TRUNCATE TABLE `gymsoft`.`gym_Customers`;#TRUNCATE TABLE `gymsoft`.`gym_Roles`;#TRUNCATE TABLE `gymsoft`.`gym_Person`;#TRUNCATE TABLE `gymsoft`.`gym_Users`;#TRUNCATE TABLE `gymsoft`.`gym_BusinessUnits`;

DROP TABLE IF EXISTS `gymsoft`.`gym_CustomerSubscription`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Visits`;
DROP TABLE IF EXISTS `gymsoft`.`gym_NextOfKin`;
DROP TABLE IF EXISTS `gymsoft`.`gym_SystemConfiguration`;
DROP TABLE IF EXISTS `gymsoft`.`gym_CustomerMetrics`;
DROP TABLE IF EXISTS `gymsoft`.`gym_AccountNotes`;
DROP TABLE IF EXISTS `gymsoft`.`gym_UserCardMap`;
DROP TABLE IF EXISTS `gymsoft`.`gym_AuditTrail`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Logs`;
DROP TABLE IF EXISTS `gymsoft`.`gym_RoleUserMap`;
DROP TABLE IF EXISTS `gymsoft`.`gym_RoleActionMap`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Actions`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Cards`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Subscriptions`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Roles`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Customers`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Users`;
DROP TABLE IF EXISTS `gymsoft`.`gym_Person`;
DROP TABLE IF EXISTS `gymsoft`.`gym_BusinessUnits`;

CREATE TABLE `gymsoft`.`gym_Users` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `userId` int(11) NOT NULL,
  `userName` varchar(1024) DEFAULT NULL,
  `password` BLOB DEFAULT NULL,
  `status` varchar(1024) DEFAULT NULL,
  `jobTitle` varchar(1024) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Cards` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `cardId` varchar(20) NOT NULL,
  `isActive` ENUM('YES','NO') NOT NULL DEFAULT 'NO',
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`cardId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Subscriptions` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `subscriptionId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(1024) DEFAULT NULL,
  `description` varchar(2048) DEFAULT NULL,
  `period` int(11) DEFAULT NULL,
  `subType` ENUM('GYM ACCESS','PERSONAL TRAINING') NOT NULL DEFAULT 'GYM ACCESS',
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`subscriptionId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Person` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `personId` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(1024) DEFAULT NULL,
  `middleName` varchar(1024) DEFAULT NULL,
  `lastName` varchar(1024) DEFAULT NULL,
  `dateOfBirth` date DEFAULT NULL,
  `emailAddress` varchar(1024) DEFAULT NULL,
  `contactNum1` varchar(20) DEFAULT NULL,
  `contactNum2` varchar(20) DEFAULT NULL,
  `contactNum3` varchar(20) DEFAULT NULL,
  `address1` varchar(1024) DEFAULT NULL,
  `address2` varchar(1024) DEFAULT NULL,
  `address3` varchar(1024) DEFAULT NULL,
  `parish` varchar(1024) DEFAULT NULL,
  `gender` ENUM('MALE','FEMALE') NOT NULL DEFAULT 'MALE',
  `photoPath` varchar(1024) DEFAULT NULL,
  `userType` ENUM('EMPLOYEE','CUSTOMER') NOT NULL DEFAULT 'CUSTOMER',
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`personId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Customers` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `customerId` int(11) NOT NULL,
  `status` varchar(1024) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`customerId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_NextOfKin` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `kinId` int(11) NOT NULL AUTO_INCREMENT,
  `personId` int(11) NOT NULL,
  `firstName` varchar(1024) DEFAULT NULL,
  `lastName` varchar(1024) DEFAULT NULL,
  `relation` varchar(1024) DEFAULT NULL,
  `contactNum1` varchar(20) DEFAULT NULL,
  `contactNum2` varchar(20) DEFAULT NULL,
  `contactNum3` varchar(20) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`kinId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_CustomerSubscription` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customerId` int(11) NOT NULL,
  `subscriptionId` int(11) NOT NULL,
  `isActive` ENUM('YES','NO') NOT NULL DEFAULT 'YES',
  `expiryDate` datetime DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`id`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_SystemConfiguration` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `parameterName` varchar(100) DEFAULT NULL,
  `parameterValue` varchar(2048) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`parameterName`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_CustomerMetrics` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `customerId` int(11) NOT NULL,
  `dateTaken` date DEFAULT NULL,
  `weight` varchar(20) DEFAULT NULL,
  `bmi` varchar(20) DEFAULT NULL,
  `neck` varchar(20) DEFAULT NULL,
  `upperArmLeft` varchar(20) DEFAULT NULL,
  `upperArmRight` varchar(20) DEFAULT NULL,
  `chest_bust` varchar(20) DEFAULT NULL,
  `lowerAbs` varchar(20) DEFAULT NULL,
  `waist` varchar(20) DEFAULT NULL,
  `hips` varchar(20) DEFAULT NULL,
  `thighRight` varchar(20) DEFAULT NULL,
  `thighLeft` varchar(20) DEFAULT NULL,
  `calfRight` varchar(20) DEFAULT NULL,
  `calfLeft` varchar(20) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`customerId`,`dateTaken`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_AccountNotes` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `noteId` int(11) NOT NULL AUTO_INCREMENT,
  `customerId` int(11) NOT NULL,
  `title` varchar(1024) DEFAULT NULL,
  `content` varchar(4096) DEFAULT NULL,
  `noteTime` datetime DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`noteId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_UserCardMap` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `cardId` varchar(20) NOT NULL,
  `personId` int(11) NOT NULL,
  `userType` ENUM('EMPLOYEE','CUSTOMER') NOT NULL DEFAULT 'CUSTOMER',
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`cardId`,`personId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_AuditTrail` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `auditId` int(11) NOT NULL AUTO_INCREMENT,
  `activity` varchar(1024) NOT NULL,
  `description` varchar(4096) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`auditId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_BusinessUnits` (
  `buId` int(11) NOT NULL AUTO_INCREMENT,
  `buName` varchar(1024) DEFAULT NULL,
  `buEmailAddress` varchar(1024) DEFAULT NULL,
  `buContactNum1` varchar(20) DEFAULT NULL,
  `buContactNum2` varchar(20) DEFAULT NULL,
  `buContactNum3` varchar(20) DEFAULT NULL,
  `buAddress1` varchar(1024) DEFAULT NULL,
  `buAddress2` varchar(1024) DEFAULT NULL,
  `buAddress3` varchar(1024) DEFAULT NULL,
  `buParish` varchar(1024) DEFAULT NULL,
  `buCountry` varchar(1024) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Logs` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `logId` int(11) NOT NULL AUTO_INCREMENT,
  `event` varchar(1024) DEFAULT NULL,
  `severity` varchar(1024) DEFAULT NULL,
  `description` varchar(2048) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`logId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_RoleUserMap` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`roleId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Roles` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `roleId` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(2048) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`roleId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_RoleActionMap` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `roleId` int(11) NOT NULL,
  `actionId` int(11) NOT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`actionId`,`roleId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Actions` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `actionId` int(11) NOT NULL AUTO_INCREMENT,
  `entityName` varchar(2048) DEFAULT NULL,
  `allowedActions` varchar(2048) DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`actionId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_Visits` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `personId` int(11) NOT NULL,
  `userType` ENUM('CUSTOMER','EMPLOYEE') NOT NULL DEFAULT 'CUSTOMER',
  `timeIn` datetime DEFAULT NULL,
  `timeOut` datetime DEFAULT NULL,
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`personId`,`userType`,`timeIn`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `gymsoft`.`gym_SubscriptionTypes` (
  `buId` int(11) NOT NULL DEFAULT 1,
  `subType` varchar(1024) NOT NULL,
  
  `subType` ENUM('GYM ACCESS','PERSONAL TRAINING') NOT NULL DEFAULT 'GYM ACCESS',
  `createdAt` datetime DEFAULT NULL,
  `createdBy` int(11) NOT NULL,
  `updatedAt` datetime DEFAULT NULL,
  `updatedBy` int(11) NOT NULL,
  PRIMARY KEY (`subscriptionId`,`buId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


ALTER TABLE gym_NextOfKin ADD CONSTRAINT fk_nokpers FOREIGN KEY (personId,buId) REFERENCES gym_Person (personId,buId);
ALTER TABLE gym_CustomerSubscription ADD CONSTRAINT fk_cscust FOREIGN KEY (customerId,buId) REFERENCES gym_Customers (customerId,buId);
ALTER TABLE gym_CustomerSubscription ADD CONSTRAINT fk_cssub FOREIGN KEY (subscriptionId,buId) REFERENCES gym_Subscriptions (subscriptionId,buId);
ALTER TABLE gym_CustomerMetrics ADD CONSTRAINT fk_cmcust FOREIGN KEY (customerId,buId) REFERENCES gym_Customers (customerId,buId);
ALTER TABLE gym_AccountNotes ADD CONSTRAINT fk_ancust FOREIGN KEY (customerId,buId) REFERENCES gym_Customers (customerId,buId);
ALTER TABLE gym_UserCardMap ADD CONSTRAINT fk_ucmpers FOREIGN KEY (personId,buId) REFERENCES gym_Person (personId,buId);
ALTER TABLE gym_UserCardMap ADD CONSTRAINT fk_ucmcards FOREIGN KEY (cardId,buId) REFERENCES gym_Cards (cardId,buId);
ALTER TABLE gym_Visits ADD CONSTRAINT fk_VisPers FOREIGN KEY (personId,buId) REFERENCES gym_Person (personId,buId);
ALTER TABLE gym_RoleUserMap ADD CONSTRAINT fk_rumroles FOREIGN KEY (roleId,buId) REFERENCES gym_Roles (roleId,buId);
ALTER TABLE gym_RoleUserMap ADD CONSTRAINT fk_rumusers FOREIGN KEY (userId,buId) REFERENCES gym_Users (userId,buId);
ALTER TABLE gym_RoleActionMap ADD CONSTRAINT fk_ramroles FOREIGN KEY (roleId,buId) REFERENCES gym_Roles (roleId,buId);
ALTER TABLE gym_RoleActionMap ADD CONSTRAINT fk_ramact FOREIGN KEY (actionId,buId) REFERENCES gym_Actions (actionId,buId);
ALTER TABLE gym_Customers ADD CONSTRAINT fk_custper FOREIGN KEY (customerId,buId) REFERENCES gym_Person (personId,buId);
ALTER TABLE gym_Users ADD CONSTRAINT fk_userper FOREIGN KEY (userId,buId) REFERENCES gym_Person (personId,buId);

ALTER TABLE gym_CustomerSubscription ADD CONSTRAINT fk_cs FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_NextOfKin ADD CONSTRAINT fk_nokbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_SystemConfiguration ADD CONSTRAINT fk_scbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_CustomerMetrics ADD CONSTRAINT fk_cmbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_AccountNotes ADD CONSTRAINT fk_anbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_UserCardMap ADD CONSTRAINT fk_ucmbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_AuditTrail ADD CONSTRAINT fk_atbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Visits ADD CONSTRAINT fk_visitsbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Logs ADD CONSTRAINT fk_logsbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_RoleUserMap ADD CONSTRAINT fk_rumbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_RoleActionMap ADD CONSTRAINT fk_rambu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Actions ADD CONSTRAINT fk_actbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Users ADD CONSTRAINT fk_usersbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Cards ADD CONSTRAINT fk_cardsbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Subscriptions ADD CONSTRAINT fk_subbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Customers ADD CONSTRAINT fk_custbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Person ADD CONSTRAINT fk_persbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);
ALTER TABLE gym_Roles ADD CONSTRAINT fk_rolesbu FOREIGN KEY (buId) REFERENCES gym_BusinessUnits(buId);

#ALTER TABLE gym_CustomerSubscription ADD CONSTRAINT fk_cbycs FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Visits ADD CONSTRAINT fk_cbyvisits FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_NextOfKin ADD CONSTRAINT fk_cbynok FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_SystemConfiguration ADD CONSTRAINT fk_cbysc FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_CustomerMetrics ADD CONSTRAINT fk_cbycm FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_AccountNotes ADD CONSTRAINT fk_cbyan FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_UserCardMap ADD CONSTRAINT fk_cbyucm FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Logs ADD CONSTRAINT fk_cbylogs FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_RoleUserMap ADD CONSTRAINT fk_cbyrum FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_RoleActionMap ADD CONSTRAINT fk_cbyram FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Actions ADD CONSTRAINT fk_cbyact FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Cards ADD CONSTRAINT fk_cbycards FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Subscriptions ADD CONSTRAINT fk_cbysub FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Customers ADD CONSTRAINT fk_cbycust FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Person ADD CONSTRAINT fk_cbypers FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_Roles ADD CONSTRAINT fk_cbyroles FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_BusinessUnits ADD CONSTRAINT fk_cbybu FOREIGN KEY (createdBy) references gym_Users (userId);#ALTER TABLE gym_CustomerSubscription ADD CONSTRAINT fk_ubycs FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Visits ADD CONSTRAINT fk_ubyvisits FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_NextOfKin ADD CONSTRAINT fk_ubynok FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_SystemConfiguration ADD CONSTRAINT fk_ubysc FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_CustomerMetrics ADD CONSTRAINT fk_ubycm FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_AccountNotes ADD CONSTRAINT fk_ubyan FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_UserCardMap ADD CONSTRAINT fk_ubyucm FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_AuditTrail ADD CONSTRAINT fk_ubyat FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Logs ADD CONSTRAINT fk_ubylogs FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_RoleUserMap ADD CONSTRAINT fk_ubyrum FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_RoleActionMap ADD CONSTRAINT fk_ubyram FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Actions ADD CONSTRAINT fk_ubyact FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Cards ADD CONSTRAINT fk_ubycards FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Subscriptions ADD CONSTRAINT fk_ubysub FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Customers ADD CONSTRAINT fk_ubycust FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Person ADD CONSTRAINT fk_ubypers FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_Roles ADD CONSTRAINT fk_ubyroles FOREIGN KEY (updatedBy) references gym_Users (userId);#ALTER TABLE gym_BusinessUnits ADD CONSTRAINT fk_ubybu FOREIGN KEY (updatedBy) references gym_Users (userId);


DROP PROCEDURE IF EXISTS gym_sp_CreatePerson;

CREATE PROCEDURE gym_sp_CreatePerson(buid int, userid int, fname VARCHAR(1024), mname VARCHAR(1024), lname VARCHAR(1024), dob date,
  email VARCHAR(1024), num1 VARCHAR(20), num2 VARCHAR(20), num3 VARCHAR(20), add1 VARCHAR(1024),
  add2 VARCHAR(1024), add3 VARCHAR(1024), par VARCHAR(1024), sex VARCHAR(1024), photo VARCHAR(1024), usrtyp VARCHAR(1024), OUT personid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    INSERT INTO gymsoft.gym_Person(buId, firstName, middleName, lastName, dateOfBirth, emailAddress, contactNum1, contactNum2, contactNum3,
                  address1, address2, address3, parish, gender, photoPath, userType, createdAt, createdBy,
                  updatedAt, updatedBy)
    VALUES      (buid, fname, mname, lname, dob, email, num1, num2, num3, add1, add2,
                 add3, par, sex, photo, usrtyp, modTime, userid, modTime, userid);

    SET personid = LAST_INSERT_ID();
    SET result = 0;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE PERSON',
                 concat(personid, '|', fname, '|', mname, '|', lname, '|', dob, '|', email, '|', num1, '|',
                        num2, '|', num3, '|', add1, '|', add2, '|', add3, '|',
                        par, '|', sex, '|', photo, '|', usrtyp),
                 modTime,
                 userid);

    COMMIT;
  END;


DROP PROCEDURE IF EXISTS gym_sp_UpdatePerson;

CREATE PROCEDURE gym_sp_UpdatePerson(buid int, userid int, personid int, fname VARCHAR(1024), mname VARCHAR(1024), lname VARCHAR(1024), dob date,
  email VARCHAR(1024), num1 VARCHAR(20), num2 VARCHAR(20), num3 VARCHAR(20), add1 VARCHAR(1024),
  add2 VARCHAR(1024), add3 VARCHAR(1024), par VARCHAR(1024), sex VARCHAR(1024), photo VARCHAR(1024),stat VARCHAR(1024), jt VARCHAR(1024) OUT result int)
  BEGIN
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();


UPDATE gymsoft.gym_Person 
SET firstName = fname, middleName = mname, lastName = lname, dateOfBirth = dob, emailAddress = email, contactNum1 = num1, contactNum2 = num2, 
contactNum3 = num3, address1 = add1, address2 = add2, address3 = add3, parish = par, gender = sex, photoPath = photo, updatedAt = modTime, updatedBy = userid 
WHERE buId = buid and personId = personid;



    UPDATE gymsoft.gym_Users 
SET status = stat, jobTitle = jt, updatedAt = modTime, updatedBy = userid 
WHERE buId = buid and userId = personid;

    
    
    
    
    
    SET result = 0;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'UPDATE PERSON',
                 concat(personid, '|', fname, '|', mname, '|', lname, '|', dob, '|', email, '|', num1, '|',
                        num2, '|', num3, '|', add1, '|', add2, '|', add3, '|',
                        par, '|', sex, '|', photo, '|', stat, '|', jt),
                 modTime,
                 userid);

    COMMIT;
  END;



DROP PROCEDURE IF EXISTS gym_sp_CreateUserFromPerson;

CREATE PROCEDURE gym_sp_CreateUserFromPerson(buid int, userid int, personid int, uname VARCHAR(1024), pwd VARCHAR(1024), status VARCHAR(1024), jt VARCHAR(1024), OUT result1 int)
  BEGIN
    DECLARE modTime DATETIME;
    DECLARE hashkey VARCHAR(1024);

    START TRANSACTION;

    SET modTime = current_timestamp();

    select parameterValue into hashkey from gym_SystemConfiguration where parameterName = 'HASHKEY' and buId = buid LIMIT 1;

    INSERT INTO gymsoft.gym_Users(buId, userId, userName, password, status, jobTitle, createdAt, createdBy, updatedAt, updatedBy)
    VALUES      (buid, personid, uname, AES_ENCRYPT(hashkey,pwd), status, jt, modTime, userid, modTime, userid);

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE USER',
                 concat(personid, '|',uname, '|',
                        pwd, '|', status, '|', jt),
                 modTime,
                 userid);

    SET result1 = 0;

    COMMIT;
  END;

DROP PROCEDURE IF EXISTS gym_sp_CreateNewUser;

CREATE PROCEDURE gym_sp_CreateNewUser(buid int, userid int, fname VARCHAR(1024), mname VARCHAR(1024), lname VARCHAR(1024), dob date,
  email VARCHAR(1024), num1 VARCHAR(20), num2 VARCHAR(20), num3 VARCHAR(20), add1 VARCHAR(1024),
  add2 VARCHAR(1024), add3 VARCHAR(1024), par VARCHAR(1024), sex VARCHAR(1024), photo VARCHAR(1024),
  uname VARCHAR(1024), pwd VARCHAR(1024), status VARCHAR(1024), jt VARCHAR(1024), OUT result int)
  BEGIN
    DECLARE lastID  INT DEFAULT NULL;
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    CALL gym_sp_CreatePerson (buid, userid, fname, mname, lname, dob, email, num1, num2, num3, add1, add2,
                 add3, par, sex, photo, 1, @personid, @res);

    IF @res = 0 THEN
      CALL gym_sp_CreateUserFromPerson(buid, userid, @personid, uname, pwd, status, jt, @resp);
      SET result = @resp;
    ELSE
      SET result = @res;
    END IF;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE NEW USER',
                 concat(@personid, '|', result),
                 modTime,
                 userid);

    COMMIT;
  END;
  
  
  DROP PROCEDURE IF EXISTS gym_sp_UpdateUser;

CREATE PROCEDURE gym_sp_UpdateUser(buid int, userid int, fname VARCHAR(1024), mname VARCHAR(1024), lname VARCHAR(1024), dob date,
  email VARCHAR(1024), num1 VARCHAR(20), num2 VARCHAR(20), num3 VARCHAR(20), add1 VARCHAR(1024),
  add2 VARCHAR(1024), add3 VARCHAR(1024), par VARCHAR(1024), sex VARCHAR(1024), photo VARCHAR(1024),
  uname VARCHAR(1024), pwd VARCHAR(1024), status VARCHAR(1024), jt VARCHAR(1024), OUT result int)
  
  BEGIN
    DECLARE lastID  INT DEFAULT NULL;
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    CALL gym_sp_CreatePerson (buid, userid, fname, mname, lname, dob, email, num1, num2, num3, add1, add2,
                 add3, par, sex, photo, 1, @personid, @res);

    IF @res = 0 THEN
      CALL gym_sp_CreateUserFromPerson(buid, userid, @personid, uname, pwd, status, jt, @resp);
      SET result = @resp;
    ELSE
      SET result = @res;
    END IF;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE NEW USER',
                 concat(@personid, '|', result),
                 modTime,
                 userid);

    COMMIT;
  END;
  
  

DROP PROCEDURE IF EXISTS gym_sp_CreateCustomerFromPerson;

CREATE PROCEDURE gym_sp_CreateCustomerFromPerson(buid int, userid int, personid int, status VARCHAR(1024), OUT result int)
  BEGIN
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    INSERT INTO gymsoft.gym_Customers(buId, customerId, status, createdAt, createdBy, updatedAt, updatedBy)
    VALUES      (buid, personid, status, modTime, userid, modTime, userid);

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE CUSTOMER',
                 concat(personid, '|', status),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;

DROP PROCEDURE IF EXISTS gym_sp_CreateNewCustomer;

CREATE PROCEDURE gym_sp_CreateNewCustomer(buid int, userid int, fname VARCHAR(1024), mname VARCHAR(1024), lname VARCHAR(1024), dob date,
  email VARCHAR(1024), num1 VARCHAR(20), num2 VARCHAR(20), num3 VARCHAR(20), add1 VARCHAR(1024),
  add2 VARCHAR(1024), add3 VARCHAR(1024), par VARCHAR(1024), sex VARCHAR(1024), photo VARCHAR(1024), OUT result int)
  BEGIN
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    CALL gym_sp_CreatePerson (buid, userid, fname, mname, lname, dob, email, num1, num2, num3, add1, add2,
                 add3, par, sex, photo, 2, @personid, @res);

    IF @res = 0 THEN
      CALL gym_sp_CreateCustomerFromPerson(buid, userid, @personid, 'ACTIVE', @resp);
      SET result = @resp;
    ELSE
      SET result = @res;
    END IF;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE NEW CUSTOMER',
                 concat(@personid, '|', result),
                 modTime,
                 userid);

    COMMIT;
  END;

DROP PROCEDURE IF EXISTS gym_sp_CreateBusinessUnit;

CREATE PROCEDURE gym_sp_CreateBusinessUnit(userid int, uname VARCHAR(1024), email VARCHAR(1024), num1 VARCHAR(20),
  num2 VARCHAR(20), num3 VARCHAR(20), add1 VARCHAR(1024), add2 VARCHAR(1024),
  add3 VARCHAR(1024), par VARCHAR(1024), cntry VARCHAR(1024), OUT buid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    INSERT INTO gymsoft.gym_BusinessUnits(buName, buEmailAddress, buContactNum1, buContactNum2, buContactNum3, buAddress1,
                  buAddress2, buAddress3, buParish, buCountry, createdAt, createdBy,
                  updatedAt, updatedBy    )
    VALUES      (uname, email, num1, num2, num3, add1, add2, add3, par, cntry,
                 modTime, userid, modTime, userid);

    SET buid  = LAST_INSERT_ID();

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE BUSINESS UNIT',
                 concat(uname, '|', email, '|', num1, '|', num2, '|', num3, '|',
                        add1, '|', add2, '|', add3, '|', par, '|', cntry),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;

DROP PROCEDURE IF EXISTS gym_sp_CreateSubscription;

CREATE PROCEDURE gym_sp_CreateSubscription(buid int, userid int, sname VARCHAR(1024), descr VARCHAR(1024), days int, type VARCHAR(1024), OUT subid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;

    START TRANSACTION;

    SET modTime = current_timestamp();

    INSERT INTO gymsoft.gym_Subscriptions
    (buId, name, description, period, subType, createdAt, createdBy, updatedAt, updatedBy)
    VALUES (buid, sname, descr, days, type, modTime, userid, modTime, userid);

    SET subid  = LAST_INSERT_ID();

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'CREATE SUBSCRIPTION',
                 concat(subid, '|', sname, '|', descr, '|', days, '|', type),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;


DROP PROCEDURE IF EXISTS gym_sp_PersonCheckIn;

CREATE PROCEDURE gym_sp_PersonCheckIn(buid int, userid int, personid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;
    DECLARE usrtyp CHAR(1);

    START TRANSACTION;

    SET modTime = current_timestamp();

    
    select usertype into usrtyp from gym_Person where buId = buid and personId = personid LIMIT 1;
    
    INSERT INTO gymsoft.gym_Visits
    (buId, personId, userType, timeIn, timeOut, createdAt, createdBy, updatedAt, updatedBy) 
    VALUES (buid, personid, usrtyp, modTime, null, modTime, userid, modTime, userid);

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 concat(usrtyp,' CHECK-IN'),
                 concat(personid, '|', usrtyp, '|', modTime, '|NULL'),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;


DROP PROCEDURE IF EXISTS gym_sp_AuthenticateUser;

CREATE PROCEDURE gym_sp_AuthenticateUser(buid int, uname VARCHAR(1024), pass VARCHAR(1024), OUT uid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;
    DECLARE hashkey VARCHAR(1024);

    START TRANSACTION;

    SET modTime = current_timestamp();

    SELECT parameterValue INTO hashkey FROM gym_SystemConfiguration WHERE parameterName = 'HASHKEY' AND buId = buid LIMIT 1;

    SELECT userId INTO uid FROM gym_Users WHERE userName = uname AND password = AES_ENCRYPT(hashkey,pass) LIMIT 1;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'LOGIN',
                 concat(uname, '|', coalesce(uid,'NULL')),
                 modTime,
                 0);

    SET result = 0;

    COMMIT;
  END;


DROP PROCEDURE IF EXISTS gym_sp_GetAllUsers;

CREATE PROCEDURE gym_sp_GetAllUsers(buid int, userid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;
    
    START TRANSACTION;

    SET modTime = current_timestamp();

    SELECT u.userId, u.userName, u.status, u.jobTitle, p.firstName, p.middleName, p.lastName, p.dateOfBirth, p.emailAddress,
       p.contactNum1, p.contactNum2, p.contactNum3, p.address1, p.address2, p.address3, p.parish, p.gender, p.photoPath
    FROM   gym_Users u INNER JOIN gym_Person p ON p.personId = u.userId AND p.buId = u.buId;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'GET ALL USERS',
                 concat(userid, '|SUCCESS'),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;


DROP PROCEDURE IF EXISTS gym_sp_GetUser;

CREATE PROCEDURE gym_sp_GetUser(buid int, userid int, searchid int, OUT result int)
  BEGIN
    DECLARE modTime DATETIME;
    
    START TRANSACTION;

    SET modTime = current_timestamp();

    SELECT u.userName, u.status, u.jobTitle, p.firstName, p.middleName, p.lastName, p.dateOfBirth, p.emailAddress,
       p.contactNum1, p.contactNum2, p.contactNum3, p.address1, p.address2, p.address3, p.parish, p.gender, p.photoPath
    FROM   gym_Users u INNER JOIN gym_Person p ON p.personId = u.userId AND p.buId = u.buId AND u.userId = searchid;

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'GET USER',
                 concat(userid, '|', searchid, '|SUCCESS'),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;


DROP PROCEDURE IF EXISTS gym_sp_AddSysConfig;

CREATE PROCEDURE gym_sp_AddSysConfig(buid int, userid int, paramName VARCHAR(1024), paramVal VARCHAR(1024), OUT result int)
  BEGIN
    DECLARE modTime DATETIME;
    
    START TRANSACTION;

    SET modTime = current_timestamp();

    INSERT INTO gymsoft.gym_SystemConfiguration
    (buId, parameterName, parameterValue, createdAt, createdBy, updatedAt, updatedBy) 
    VALUES (buid, paramName, paramVal, modTime, userid, modTime, userid);

    INSERT INTO gymsoft.gym_AuditTrail(buId, activity, description, updatedAt, updatedBy)
    VALUES      (buid,
                 'ADD SYSTEM CONFIG',
                 concat(paramName, '|', paramVal),
                 modTime,
                 userid);

    SET result = 0;

    COMMIT;
  END;


#call gym_sp_PersonCheckIn(1,1,19,@result);

#select usertype from gym_Person where buId = 1 and personId = 21 LIMIT 1;








call gym_sp_CreateBusinessUnit(0,'Beast-n-Barbells Fitness Centre','ullamcorper@semPellentesqueut.com','1-279-211-5601','1-591-557-1651','1-784-289-2161','5072 Nunc Av.','Ap #647-5913 Sollicitudin Avenue','P.O. Box 689, 9088 Urna. Ave','TX','Jamaica',@buid,@result);

call gym_sp_AddSysConfig(1,0,'HASHKEY','ENCRYPT KEY STRING',@result);

call gym_sp_AuthenticateUser(1,'vulputate,','Mauris',@userid,@result);

call gym_sp_CreateSubscription(1,0,'1_DAY_ACCESS', '1 Day Gym Access Pass',1,1,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_WEEK_ACCESS', '7 Days (1 Week) Gym Access Pass',7,1,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_MONTH_ACCESS', '30 Days (1 Month) Gym Access Pass',30,1,@subid,@result);
call gym_sp_CreateSubscription(1,0,'3_MONTH_ACCESS', '90 Days (3 Months) Gym Access Pass',90,1,@subid,@result);
call gym_sp_CreateSubscription(1,0,'6_MONTH_ACCESS', '180 Days (6 Months) Gym Access Pass',180,1,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_YEAR_ACCESS', '365 Days (1 Year) Gym Access Pass',365,1,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_DAY_PT', '1 Day Personal Training',1,2,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_WEEK_PT', '7 Days (1 Week) Personal Training',7,2,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_MONTH_PT', '30 Days (1 Month) Personal Training',30,2,@subid,@result);
call gym_sp_CreateSubscription(1,0,'3_MONTH_PT', '90 Days (3 Months) Personal Training',90,2,@subid,@result);
call gym_sp_CreateSubscription(1,0,'6_MONTH_PT', '180 Days (6 Months) Personal Training',180,2,@subid,@result);
call gym_sp_CreateSubscription(1,0,'1_YEAR_PT', '365 Days (1 Year) Personal Training',365,2,@subid,@result);

call gym_sp_CreateNewUser (1,0,'Ruby','India','Norris','1983-10-01','ut.nulla@molestie.org','1-220-942-0767','1-229-134-2347','1-569-416-8569','P.O. Box 266, 8029 Sagittis Av.','3726 Dis Road','Ap #412-5919 Dolor. Rd.','North Pole','2','euismod','Sed','risus','ACTIVE','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Denton','Rebekah','Reid','1986-01-07','venenatis.a.magna@utipsumac.edu','1-166-540-6059','1-727-708-1742','1-444-612-5904','P.O. Box 691, 6839 Eget St.','639-2582 Amet, Ave','998-9773 Eu Street','Methuen','2','Aenean','luctus','lorem','ACTIVE','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Wade','Ryan','Bradford','1973-01-25','at.pede@ligula.com','1-981-344-5785','1-743-876-2420','1-810-790-1734','442-5513 Nonummy. Street','P.O. Box 664, 6620 Convallis Av.','P.O. Box 115, 2290 Venenatis Road','Shelton','2','Mauris molestie','at,','lectus','EXPIRED','PERSONAL TRAINER',@result);
call gym_sp_CreateNewUser (1,0,'Xerxes','Nasim','Steele','1971-01-30','neque.et@lorem.com','1-760-837-4684','1-961-490-7001','1-997-865-3571','9360 Fames Rd.','Ap #752-8936 Sociosqu St.','1701 Eu, St.','Fremont','1','ipsum.','tortor','sem,','EXPIRED','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Ursula','Hilda','Farrell','1976-09-30','sem.ut@velarcu.org','1-328-595-4472','1-613-742-8739','1-128-961-4767','P.O. Box 306, 4573 Vitae, Avenue','4507 Velit Av.','P.O. Box 736, 4730 In St.','Salem','1','nascetur ridiculus mus. Aenean','vulputate,','Mauris','ACTIVE','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Levi','Faith','Richards','1987-11-24','non@fringilla.edu','1-451-245-7564','1-146-704-9642','1-122-750-8610','Ap #943-7350 Nunc. Rd.','Ap #605-1445 Massa Rd.','Ap #657-3381 Amet, Rd.','Nashua','1','consequat nec,','euismod','non,','INACTIVE','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Tallulah','Avye','Blanchard','1987-09-08','libero.Morbi.accumsan@magnased.ca','1-443-804-8604','1-966-281-7195','1-234-145-9314','5106 Blandit Rd.','3023 Aliquet Avenue','5639 Justo. St.','Newport','1','lectus rutrum urna, nec','mauris','vehicula','ACTIVE','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Zelda','Ella','Bond','1982-12-05','augue.eu.tellus@dolor.ca','1-832-232-5922','1-597-342-7078','1-964-994-9573','Ap #656-7388 Sed Rd.','P.O. Box 129, 1832 Odio Avenue','P.O. Box 318, 8277 Dictum Rd.','Las Vegas','2','elit, pretium et,','torquent','nisi','ACTIVE','PERSONAL TRAINER',@result);
call gym_sp_CreateNewUser (1,0,'Jorden','Fletcher','Bowen','1989-04-07','magnis.dis.parturient@Etiamimperdiet.com','1-461-673-1243','1-198-741-1000','1-683-114-9705','P.O. Box 280, 167 Quam, Road','P.O. Box 244, 9554 Vestibulum Rd.','3758 Sed Street','Valdosta','1','malesuada fames ac','Nullam','at,','INACTIVE','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Tasha','Adele','Curry','1979-09-27','sed.turpis.nec@erat.ca','1-536-958-9008','1-491-905-4147','1-651-553-4168','P.O. Box 597, 956 Vulputate, St.','P.O. Box 763, 4593 Tincidunt Road','983-243 Sagittis St.','Lexington','2','Donec consectetuer','elit.','Donec','INACTIVE','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Britanni','Darryl','Gaines','1979-02-04','Donec.feugiat.metus@semut.org','1-580-565-3793','1-748-208-3246','1-952-276-0902','P.O. Box 696, 663 Facilisis, Rd.','468-1445 Dis St.','Ap #686-3225 Tristique St.','Oxnard','2','gravida mauris ut','Vivamus','nec','EXPIRED','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Brooke','Conan','Callahan','1980-12-21','Pellentesque.ut@Crasvehicula.com','1-706-257-9635','1-901-600-8953','1-184-205-5829','P.O. Box 118, 890 Viverra. Avenue','P.O. Box 277, 2095 Nulla Av.','732-7615 Facilisis, St.','Fallon','2','sapien imperdiet ornare.','sit','enim','EXPIRED','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Amal','Aubrey','Brady','1984-01-18','varius.orci.in@gravida.com','1-152-274-7974','1-701-324-1664','1-283-284-1341','Ap #137-6829 Phasellus Rd.','470-2563 In Rd.','107-3556 Feugiat St.','Michigan City','1','dictum cursus.','nec','nec','INACTIVE','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Mallory','Barbara','Bullock','1978-06-02','Nullam.scelerisque.neque@ultriciesligulaNullam.ca','1-404-746-5595','1-840-461-2905','1-582-193-9704','181-1217 Sociis Road','Ap #490-6894 Sit Ave','P.O. Box 429, 6856 Auctor Street','Spartanburg','2','a feugiat tellus lorem','eu','arcu.','EXPIRED','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Eliana','Brennan','Boyer','1980-11-18','Duis.a.mi@temporaugue.ca','1-606-353-5859','1-534-510-0447','1-888-299-8740','P.O. Box 330, 2368 Ullamcorper. Avenue','5448 Ullamcorper, Rd.','P.O. Box 507, 1544 Ipsum Ave','Minot','2','tellus','metus','penatibus','ACTIVE','SUPERVISOR',@result);
call gym_sp_CreateNewUser (1,0,'Colleen','Alma','Briggs','1983-03-04','vulputate.ullamcorper@enimEtiamimperdiet.com','1-989-665-6251','1-517-678-2187','1-401-602-2198','Ap #498-4505 Purus. Av.','P.O. Box 606, 5643 Torquent Avenue','Ap #952-6415 Turpis. St.','Latrobe','2','at, iaculis quis, pede.','dignissim','tempus','INACTIVE','PERSONAL TRAINER',@result);
call gym_sp_CreateNewUser (1,0,'Upton','Uriah','Smith','1977-08-16','Nulla.dignissim.Maecenas@nonbibendumsed.ca','1-267-323-4204','1-952-819-4261','1-931-839-6670','Ap #372-1948 Sit Avenue','Ap #299-7291 A, Rd.','416-9255 Ut St.','Lansing','1','primis in','ut','libero.','INACTIVE','RECEPTIONIST',@result);
call gym_sp_CreateNewUser (1,0,'Beatrice','Erica','Graham','1981-08-30','at@elementum.edu','1-577-204-2175','1-128-497-9606','1-262-296-3891','7063 Ante. Road','P.O. Box 719, 1414 Aliquam, Avenue','P.O. Box 322, 1243 Fusce Street','Newburgh','1','in lobortis tellus justo','Suspendisse','auctor','EXPIRED','PERSONAL TRAINER',@result);
call gym_sp_CreateNewUser (1,0,'Charlotte','Kyra','Joyce','1986-10-19','Suspendisse@Donecfelis.org','1-297-368-3805','1-967-826-8565','1-181-346-3107','Ap #662-5213 Neque St.','1693 Amet Rd.','P.O. Box 259, 1697 Sit Road','Agat','1','eu tempor erat neque','ut','mattis','INACTIVE','PERSONAL TRAINER',@result);
call gym_sp_CreateNewUser (1,0,'Chester','Maia','Bailey','1974-03-01','aliquet@nisimagnased.edu','1-694-185-5177','1-471-251-6910','1-448-608-9583','135-4482 Dui Road','3459 At Rd.','Ap #145-8899 Vel Ave','Slidell','2','luctus','Proin','tempus','ACTIVE','RECEPTIONIST',@result);

call gym_sp_CreateNewCustomer (1,0,'Jackson','Whilemina','Kinney','1974-03-01','ullamcorper@semPellentesqueut.com','1-232-538-3562','1-591-557-1651','1-784-289-2161','5072 Nunc Av.','Ap #647-5913 Sollicitudin Avenue','P.O. Box 689, 9088 Urna. Ave','TX','1','malesuada',@result);
call gym_sp_CreateNewCustomer (1,0,'Bree','Isabelle','Salazar','1987-06-07','Aliquam.rutrum.lorem@est.edu','1-781-668-5319','1-517-214-3722','1-129-277-1082','9425 Nibh. St.','1563 In St.','2716 Consectetuer Street','NH','2','mi pede, nonummy',@result);
call gym_sp_CreateNewCustomer (1,0,'Angela','Ina','Kerr','1980-08-23','ac.facilisis.facilisis@fringilla.org','1-157-243-4975','1-754-589-0250','1-182-137-0996','P.O. Box 577, 6763 Eu Street','P.O. Box 297, 910 Sociis Street','Ap #678-4672 Nulla Avenue','NU','2','leo. Morbi neque tellus, imperdiet',@result);
call gym_sp_CreateNewCustomer (1,0,'Paul','Ray','Foreman','1990-10-24','imperdiet.erat@Sed.com','1-199-443-2799','1-544-298-7468','1-938-711-1935','P.O. Box 146, 5918 Lectus, St.','932-8504 Dignissim Road','489-6706 Magna. Rd.','NC','1','augue. Sed molestie. Sed',@result);
call gym_sp_CreateNewCustomer (1,0,'Brianna','Gavin','Grimes','1972-08-27','penatibus@augue.edu','1-168-224-9770','1-722-294-4313','1-776-800-0526','Ap #106-7301 Dignissim Avenue','6321 Leo. Avenue','996-9704 Ut Ave','YT','2','id, erat. Etiam',@result);
call gym_sp_CreateNewCustomer (1,0,'Deanna','Zahir','Schultz','1976-11-12','Lorem@risusNuncac.com','1-676-500-8405','1-250-254-1944','1-575-773-0729','Ap #417-9269 Turpis Av.','6807 Eu, Road','7448 Malesuada Rd.','BC','1','nec tempus mauris erat',@result);
call gym_sp_CreateNewCustomer (1,0,'Myles','Hedda','Estes','1976-09-06','sem.molestie@eutellus.ca','1-115-959-3872','1-892-768-8900','1-268-800-2276','P.O. Box 257, 2468 Congue Rd.','2377 Odio Rd.','P.O. Box 239, 6441 Eget, Road','New Jersey','2','turpis egestas. Aliquam fringilla cursus',@result);
call gym_sp_CreateNewCustomer (1,0,'Edan','Julian','Norris','1971-07-01','ac.facilisis@euenimEtiam.com','1-878-690-0888','1-730-808-6543','1-212-469-7283','P.O. Box 462, 1005 Montes, Road','5607 Metus. Rd.','868-8762 Tellus. Av.','SK','1','Nam ligula',@result);
call gym_sp_CreateNewCustomer (1,0,'Daphne','Jeanette','Armstrong','1978-11-09','Proin.velit.Sed@Phasellusliberomauris.edu','1-956-696-6717','1-942-824-7921','1-246-497-2352','2183 Commodo Ave','5532 Aliquam Av.','Ap #370-9248 Volutpat Rd.','IL','1','et libero. Proin mi.',@result);
call gym_sp_CreateNewCustomer (1,0,'Evelyn','Zephania','Newton','1977-12-18','Nunc.sollicitudin.commodo@Phasellusnulla.com','1-429-914-8436','1-158-446-5693','1-843-240-8447','5512 Eu Street','Ap #744-6129 Et Av.','Ap #232-8716 Eget St.','NU','2','risus.',@result);
call gym_sp_CreateNewCustomer (1,0,'Yolanda','Hyacinth','Drake','1974-06-14','arcu.Curabitur@malesuada.ca','1-713-672-6815','1-387-578-0253','1-864-706-2470','Ap #515-1667 Nunc Rd.','Ap #456-4252 Rhoncus. Rd.','491-1936 Lorem Ave','IN','2','In',@result);
call gym_sp_CreateNewCustomer (1,0,'Zachary','Shad','Kramer','1972-07-21','quam.quis@Nullatinciduntneque.edu','1-710-479-0471','1-450-870-1929','1-534-529-1295','Ap #222-9998 Neque Street','379-3988 Ullamcorper. Rd.','1000 A Ave','New Hampshire','1','mauris sit amet lorem',@result);
call gym_sp_CreateNewCustomer (1,0,'Quynn','Ariel','Pollard','1987-02-07','dapibus.quam.quis@Classaptenttaciti.edu','1-213-205-6809','1-766-770-3860','1-321-139-0383','7144 Bibendum Road','P.O. Box 146, 1460 Neque Ave','3091 Cursus, St.','OR','2','diam nunc, ullamcorper',@result);
call gym_sp_CreateNewCustomer (1,0,'Deirdre','Naida','Case','1979-05-26','sapien@quis.com','1-570-937-1053','1-617-544-0519','1-559-721-0214','P.O. Box 567, 4269 Aliquam St.','P.O. Box 276, 6070 Aliquet St.','6446 Commodo Ave','Illinois','1','conubia nostra,',@result);
call gym_sp_CreateNewCustomer (1,0,'Rachel','Ciaran','Avery','1979-08-25','Quisque@ipsum.com','1-624-662-6673','1-203-966-1789','1-911-732-7630','P.O. Box 747, 5464 Dui. Av.','1822 Cursus Ave','941-330 Erat, Rd.','NU','1','Cras lorem lorem,',@result);
call gym_sp_CreateNewCustomer (1,0,'Lucius','Lyle','Ward','1987-01-10','metus.In.lorem@justoPraesentluctus.edu','1-894-204-7637','1-119-922-5878','1-311-970-8574','P.O. Box 788, 2850 Blandit Rd.','Ap #612-8911 Donec Road','P.O. Box 197, 5708 Semper Rd.','Newfoundland and Labrador','1','malesuada ut, sem.',@result);
call gym_sp_CreateNewCustomer (1,0,'Charde','Haviva','Vinson','1971-08-20','augue@eratsemper.org','1-685-679-4900','1-633-795-0071','1-113-352-5775','P.O. Box 277, 486 Lectus St.','437-1314 Ac Road','942-7938 Elit St.','Nova Scotia','1','scelerisque neque. Nullam nisl.',@result);
call gym_sp_CreateNewCustomer (1,0,'Hall','Rhonda','Vinson','1989-04-01','velit.Pellentesque@aliquetliberoInteger.ca','1-362-829-0857','1-533-417-9011','1-175-555-1825','8282 Sit Road','5736 Fermentum Road','824-4944 Duis St.','NB','2','egestas ligula. Nullam feugiat placerat',@result);
call gym_sp_CreateNewCustomer (1,0,'Randall','Ignatius','Wheeler','1974-12-04','lectus@rutrumlorem.ca','1-237-658-1255','1-629-477-6438','1-202-941-1365','742-4733 Enim. Road','549-2825 Dui St.','Ap #879-4950 Id St.','SC','2','libero. Proin mi. Aliquam gravida mauris',@result);
call gym_sp_CreateNewCustomer (1,0,'Camden','Scarlett','Hicks','1984-02-02','enim@eueuismodac.org','1-114-682-6216','1-166-919-5375','1-374-459-7576','9247 Semper Rd.','P.O. Box 177, 9153 Adipiscing Ave','3415 Non, St.','OK','2','malesuada id, erat.',@result);
call gym_sp_CreateNewCustomer (1,0,'Basia','Ciara','Kinney','1975-06-06','vel.pede@etultrices.com','1-342-624-4320','1-682-520-4779','1-620-745-1194','795-7848 Dui. St.','8686 Fermentum St.','240-3307 Aptent St.','Northwest Territories','1','faucibus orci luctus',@result);
call gym_sp_CreateNewCustomer (1,0,'Hayfa','Jade','Henderson','1976-03-12','a.arcu.Sed@mollisPhasellus.ca','1-243-808-7112','1-558-798-0222','1-479-813-6196','P.O. Box 927, 2858 Sapien, Avenue','7957 Sed Rd.','756-853 Eros Street','DE','1','molestie pharetra nibh.',@result);
call gym_sp_CreateNewCustomer (1,0,'Suki','Glenna','Bird','1971-01-01','posuere@malesuadautsem.org','1-723-181-3444','1-892-603-2941','1-284-924-0912','346-2011 Malesuada Rd.','346-9513 Sed St.','4414 Ac St.','WY','1','aliquet',@result);
call gym_sp_CreateNewCustomer (1,0,'Allen','Kimberley','Benson','1976-05-26','elementum@vulputate.edu','1-169-422-7750','1-357-294-1641','1-861-912-1233','P.O. Box 346, 4538 Adipiscing Ave','4772 Lorem Street','Ap #210-742 Bibendum Road','AK','1','tincidunt',@result);
call gym_sp_CreateNewCustomer (1,0,'McKenzie','Geraldine','Lee','1971-01-17','amet.nulla.Donec@acurnaUt.ca','1-774-265-0361','1-614-823-8835','1-852-587-3443','1298 Convallis, Road','P.O. Box 864, 6405 Cras Rd.','359-1266 Quisque Rd.','Nunavut','2','arcu. Vestibulum ante ipsum',@result);
call gym_sp_CreateNewCustomer (1,0,'Hall','Paki','Preston','1987-10-02','neque@nunc.ca','1-633-942-1876','1-638-948-4988','1-730-208-4591','812-6418 Est, Road','Ap #332-3747 Est. Rd.','Ap #871-8549 Sed, Avenue','CO','1','Integer vulputate, risus a ultricies adipiscing,',@result);
call gym_sp_CreateNewCustomer (1,0,'Eliana','Alfonso','Watkins','1986-07-23','risus@arcuimperdiet.org','1-383-315-4930','1-684-466-1077','1-366-565-6106','6751 In St.','267-5203 Odio. Avenue','P.O. Box 143, 4690 Et Avenue','NC','2','pharetra sed, hendrerit',@result);
call gym_sp_CreateNewCustomer (1,0,'Libby','Yvonne','Jensen','1976-06-28','placerat@sed.org','1-907-423-9265','1-453-498-1148','1-188-683-9343','Ap #623-8842 Leo. St.','Ap #524-5285 Tristique Avenue','P.O. Box 261, 2598 Nullam Av.','Alberta','1','Nullam lobortis',@result);
call gym_sp_CreateNewCustomer (1,0,'Berk','Timothy','Crosby','1988-10-19','vel.convallis@egetvarius.edu','1-429-824-0327','1-346-567-5099','1-313-405-8916','Ap #970-9057 Mi Ave','P.O. Box 956, 6384 Suspendisse St.','P.O. Box 433, 7845 Ultricies Street','BC','1','at,',@result);
call gym_sp_CreateNewCustomer (1,0,'Maisie','Jelani','Glenn','1976-03-23','arcu@metus.ca','1-955-377-8261','1-722-109-1362','1-674-328-4518','195 Felis Rd.','P.O. Box 708, 9355 Dictum Avenue','Ap #398-828 Sed, Av.','Vermont','2','diam',@result);
call gym_sp_CreateNewCustomer (1,0,'Hillary','Marah','Merritt','1988-09-16','in.molestie@Sed.org','1-362-104-4960','1-792-109-4081','1-795-161-6118','100-8447 At St.','Ap #599-5046 Mi Road','453-2518 Nec, Street','NL','2','sem.',@result);
call gym_sp_CreateNewCustomer (1,0,'Edan','Damon','Sanchez','1981-01-24','felis.adipiscing@facilisismagnatellus.org','1-513-595-9992','1-289-604-9791','1-503-821-1207','178-3084 Imperdiet Rd.','113-7325 Neque St.','Ap #901-7684 Sit St.','NL','2','diam. Duis mi enim, condimentum eget,',@result);
call gym_sp_CreateNewCustomer (1,0,'Bert','Maya','Mcpherson','1977-03-28','cursus@egestasrhoncusProin.org','1-797-425-1087','1-533-409-6739','1-612-688-8761','P.O. Box 535, 4282 Aliquet Rd.','806-7025 Faucibus Rd.','P.O. Box 597, 5934 Arcu. Street','Texas','1','pede. Nunc sed',@result);
call gym_sp_CreateNewCustomer (1,0,'Jaime','Asher','Tillman','1987-01-28','non@atlacus.edu','1-313-514-9536','1-637-298-7265','1-406-815-1112','Ap #332-5468 Est, St.','Ap #193-6778 Nulla Rd.','P.O. Box 162, 9323 Aenean Ave','Delaware','1','tempus, lorem fringilla ornare',@result);
call gym_sp_CreateNewCustomer (1,0,'Risa','Irma','Savage','1984-03-21','vel@Maurisvestibulumneque.ca','1-687-936-5264','1-916-105-9675','1-821-779-9394','7559 Dictum. St.','P.O. Box 366, 6471 Erat. St.','Ap #525-5190 Vivamus Avenue','NS','2','dapibus',@result);
call gym_sp_CreateNewCustomer (1,0,'Barclay','Destiny','Pugh','1974-12-15','taciti.sociosqu.ad@odioPhasellusat.edu','1-543-375-8866','1-573-920-4356','1-267-394-0122','Ap #617-4984 Integer Road','Ap #861-249 Congue St.','7480 Aliquam Road','AB','1','non magna. Nam',@result);
call gym_sp_CreateNewCustomer (1,0,'Zena','Carlos','Sawyer','1975-04-16','dui.augue.eu@eratSednunc.ca','1-697-148-4347','1-266-949-0174','1-510-538-4975','P.O. Box 102, 6103 Fringilla Av.','P.O. Box 329, 226 Accumsan Ave','Ap #992-4687 Risus. Rd.','Kansas','2','convallis in, cursus et, eros.',@result);
call gym_sp_CreateNewCustomer (1,0,'Alec','Galvin','Cross','1982-12-12','Proin.dolor.Nulla@non.com','1-905-608-2519','1-503-555-4081','1-160-102-9745','P.O. Box 424, 3775 Magna Road','P.O. Box 448, 3096 Mauris Ave','239-4426 Suspendisse Avenue','WV','1','primis in faucibus orci luctus et',@result);
call gym_sp_CreateNewCustomer (1,0,'Anjolie','Alfreda','Doyle','1988-03-11','ut@dignissim.org','1-963-381-9796','1-318-457-0466','1-568-671-8615','Ap #872-7336 Nec Street','5713 Fames Ave','1070 Nibh Road','New Brunswick','1','risus odio, auctor vitae,',@result);
call gym_sp_CreateNewCustomer (1,0,'Nolan','Gage','Sherman','1971-08-25','erat@ataugueid.org','1-365-169-9033','1-943-856-0253','1-423-251-4616','328-6572 Penatibus Street','1236 Nulla St.','P.O. Box 977, 1788 Dictum Av.','WI','1','nec, cursus a,',@result);
call gym_sp_CreateNewCustomer (1,0,'Lucian','Nerea','Dyer','1989-10-30','commodo@nonummyultriciesornare.edu','1-824-494-2194','1-955-964-4441','1-873-545-6324','Ap #761-1997 Eleifend. Rd.','Ap #453-4607 Sed Ave','4730 Felis, Road','Ontario','1','feugiat. Lorem ipsum dolor sit amet,',@result);
call gym_sp_CreateNewCustomer (1,0,'Blythe','Diana','Holt','1971-10-16','neque.sed@lacus.edu','1-290-529-5165','1-338-381-9780','1-170-204-7956','P.O. Box 781, 1825 Mollis. St.','P.O. Box 932, 661 Non Rd.','563-4144 Velit St.','Ontario','1','imperdiet ornare. In faucibus. Morbi vehicula.',@result);
call gym_sp_CreateNewCustomer (1,0,'Hedley','Cassady','Garrett','1987-07-31','ac.mattis.ornare@Phasellus.org','1-801-408-3986','1-681-233-7622','1-924-448-2306','P.O. Box 673, 4188 Nec, Road','P.O. Box 747, 1507 Nunc. Road','P.O. Box 127, 4529 Nibh. Street','WV','1','et nunc. Quisque ornare tortor at',@result);
call gym_sp_CreateNewCustomer (1,0,'Uma','Echo','Gomez','1987-12-28','nisi.Cum.sociis@veliteusem.edu','1-468-807-2392','1-619-662-0826','1-315-249-9967','4154 Vivamus Street','Ap #429-2162 Tincidunt Rd.','5595 Nullam Street','Northwest Territories','2','magna a neque. Nullam',@result);
call gym_sp_CreateNewCustomer (1,0,'Courtney','Quon','Moreno','1985-06-01','dictum.eu@arcuNunc.edu','1-811-854-8155','1-657-409-8232','1-393-579-8951','P.O. Box 325, 1895 Pulvinar Ave','500-270 Sed, Av.','Ap #536-4689 Dolor. St.','Virginia','2','lacinia',@result);
call gym_sp_CreateNewCustomer (1,0,'Shaeleigh','Malcolm','Huff','1989-10-04','hendrerit.neque.In@condimentumeget.org','1-745-875-6155','1-331-777-1068','1-685-449-2935','Ap #387-5042 Id Av.','P.O. Box 311, 3781 Erat St.','Ap #762-2099 Pretium Rd.','NS','1','vitae,',@result);
call gym_sp_CreateNewCustomer (1,0,'Myles','Katell','Hinton','1972-10-09','mauris.erat.eget@orciPhasellus.com','1-792-673-4974','1-134-758-2834','1-943-798-3714','901-3532 Cras St.','Ap #180-3710 Orci Rd.','Ap #874-9056 Amet, St.','Prince Edward Island','2','penatibus',@result);
call gym_sp_CreateNewCustomer (1,0,'Zoe','Phelan','Joyce','1980-04-01','dictum.Proin.eget@elit.org','1-255-431-7223','1-676-569-1792','1-407-482-2942','353-8175 Odio Ave','952-3630 Eget, Ave','P.O. Box 212, 482 Vel Rd.','AB','1','nisi. Aenean eget metus. In nec',@result);
call gym_sp_CreateNewCustomer (1,0,'Dylan','Davis','Thomas','1980-07-28','porttitor.interdum@lacusQuisquepurus.org','1-797-375-8464','1-427-534-5596','1-176-305-8448','Ap #218-2534 A, Ave','Ap #189-6147 Ante. Avenue','392 Imperdiet Rd.','New Mexico','1','et tristique',@result);
call gym_sp_CreateNewCustomer (1,0,'Carl','Travis','Buchanan','1975-09-27','sed@necanteblandit.ca','1-934-201-5412','1-561-372-5182','1-600-791-9415','101-4894 Justo St.','P.O. Box 244, 2743 Penatibus Av.','9551 Diam. Rd.','Minnesota','1','a purus. Duis elementum, dui',@result);
call gym_sp_CreateNewCustomer (1,0,'Brynne','Ruby','Conway','1984-05-03','dui@elit.edu','1-937-561-5437','1-241-141-7656','1-731-813-9145','Ap #554-2544 Sed St.','Ap #579-9110 Bibendum St.','497-7832 Augue. Ave','Nunavut','1','risus. Donec',@result);
call gym_sp_CreateNewCustomer (1,0,'Graiden','Amber','Nolan','1975-10-18','nec.urna.et@nonloremvitae.org','1-717-544-0386','1-501-980-4456','1-771-178-7768','P.O. Box 646, 4707 Maecenas Av.','875-9092 Ornare Rd.','P.O. Box 282, 2108 Lobortis Street','Kansas','1','Sed',@result);
call gym_sp_CreateNewCustomer (1,0,'Hoyt','Amelia','Daniel','1974-06-28','luctus@Nullamscelerisqueneque.org','1-880-300-4545','1-563-782-8456','1-750-263-3422','8024 Tincidunt Ave','P.O. Box 221, 4534 Sed St.','1455 Arcu. Rd.','Nunavut','1','eros. Nam consequat dolor vitae',@result);
call gym_sp_CreateNewCustomer (1,0,'Catherine','Fritz','Cook','1980-04-06','sem.elit@Vestibulumante.com','1-739-586-6300','1-497-306-8083','1-564-696-9816','Ap #683-4407 Quis Avenue','Ap #479-2749 Eu Av.','P.O. Box 649, 288 Mauris Ave','New Brunswick','1','ipsum. Suspendisse sagittis. Nullam vitae',@result);
call gym_sp_CreateNewCustomer (1,0,'Nicole','Ivana','Owen','1981-08-01','Phasellus.dolor@dapibusrutrum.edu','1-282-836-3301','1-448-951-2353','1-631-378-7142','944 Nec Street','205-2211 Lorem Ave','Ap #662-5543 Nam Ave','Oregon','1','aliquam',@result);
call gym_sp_CreateNewCustomer (1,0,'Katell','Elliott','Jordan','1990-03-16','mauris@tortor.org','1-189-119-0555','1-446-101-1786','1-908-533-7452','9146 Nunc Avenue','Ap #132-1387 Massa. Av.','Ap #832-8137 Penatibus St.','Ohio','2','nisi. Cum sociis',@result);
call gym_sp_CreateNewCustomer (1,0,'Teegan','Cruz','Wilder','1982-07-17','eleifend@rhoncusDonecest.edu','1-228-176-6407','1-534-419-2077','1-903-832-0897','Ap #902-8524 Erat, Avenue','Ap #468-1797 Felis. St.','122-3232 Tellus Avenue','ND','1','vulputate velit eu sem.',@result);
call gym_sp_CreateNewCustomer (1,0,'Maite','Julie','Calhoun','1984-01-15','eu.enim.Etiam@consequatlectussit.com','1-526-719-4434','1-944-970-9376','1-634-386-1460','7607 Et Rd.','1109 Eu Rd.','P.O. Box 796, 8310 Adipiscing, Road','NH','2','eu arcu.',@result);
call gym_sp_CreateNewCustomer (1,0,'Kiayada','Natalie','Rodgers','1985-10-03','hendrerit.Donec.porttitor@aliquetnec.edu','1-633-634-6401','1-480-275-8314','1-347-815-5695','Ap #665-5093 Vitae Avenue','134-7919 Nulla Street','Ap #328-5799 Placerat, Road','North Dakota','2','ipsum. Donec sollicitudin adipiscing ligula. Aenean',@result);
call gym_sp_CreateNewCustomer (1,0,'Mohammad','Nash','Holmes','1971-07-17','faucibus@nonummy.ca','1-914-812-5865','1-342-505-3422','1-415-189-2104','Ap #477-4413 In, Avenue','P.O. Box 420, 4161 Libero Road','9908 Metus Rd.','Saskatchewan','2','eget tincidunt dui augue',@result);
call gym_sp_CreateNewCustomer (1,0,'Amanda','Chantale','Montoya','1974-06-24','rhoncus.id.mollis@netusetmalesuada.edu','1-618-389-2335','1-353-254-9192','1-158-175-9940','P.O. Box 381, 7576 Rhoncus Ave','P.O. Box 475, 7375 Mauris Avenue','189-8138 Lorem Ave','Nunavut','1','enim',@result);
call gym_sp_CreateNewCustomer (1,0,'Veronica','Bernard','Snyder','1982-09-02','et.malesuada@convallisincursus.edu','1-809-263-6276','1-381-460-9414','1-514-423-8317','664-2728 Donec St.','301-5237 Ipsum. Road','538-8264 Auctor Rd.','MN','1','convallis in, cursus et, eros. Proin',@result);
call gym_sp_CreateNewCustomer (1,0,'Maya','Hedy','Cantrell','1982-09-20','non@mollisnec.edu','1-477-859-0087','1-288-668-2429','1-627-369-2934','Ap #447-8660 Auctor Street','8996 Dolor Rd.','P.O. Box 831, 267 Nonummy St.','Vermont','1','arcu. Sed eu nibh vulputate',@result);
call gym_sp_CreateNewCustomer (1,0,'Heather','Lacey','Robertson','1981-04-16','ipsum@in.ca','1-648-577-3907','1-800-607-1860','1-146-494-4444','536-9431 Non, Avenue','P.O. Box 679, 3522 Consequat Rd.','119-1499 Elementum Rd.','Prince Edward Island','1','eget ipsum. Suspendisse',@result);
call gym_sp_CreateNewCustomer (1,0,'Alika','Randall','Pollard','1973-11-12','lorem.lorem@Curabitur.org','1-588-504-7675','1-792-816-5498','1-836-813-3352','P.O. Box 273, 9891 Eget St.','562-5479 Auctor, St.','Ap #601-648 Ridiculus Street','Manitoba','1','porttitor tellus non magna. Nam ligula',@result);
call gym_sp_CreateNewCustomer (1,0,'Anjolie','Quentin','Pearson','1980-07-11','fames.ac@adipiscing.com','1-312-197-0988','1-784-381-5427','1-813-990-3912','P.O. Box 563, 7179 Sem, Street','P.O. Box 627, 829 Duis Rd.','6186 Ullamcorper Road','PE','2','quis diam. Pellentesque habitant morbi tristique',@result);
call gym_sp_CreateNewCustomer (1,0,'Bryar','Dolan','Wright','1976-03-14','pede@lacus.com','1-743-691-3304','1-479-335-0171','1-262-392-3253','Ap #553-9928 In St.','6432 Tristique St.','P.O. Box 457, 4476 Eu Rd.','Indiana','2','a, scelerisque sed,',@result);
call gym_sp_CreateNewCustomer (1,0,'Jada','Patience','Frederick','1983-01-27','Aliquam.auctor@velitAliquam.org','1-152-902-3890','1-624-967-7606','1-556-929-3260','636-521 Cursus Rd.','2531 Ridiculus Street','2820 Metus Road','Prince Edward Island','2','cursus non, egestas a, dui.',@result);
call gym_sp_CreateNewCustomer (1,0,'Barry','Delilah','Roberson','1984-06-02','turpis.nec.mauris@erosnectellus.ca','1-411-611-4102','1-361-190-8863','1-534-662-6199','P.O. Box 753, 2571 Tincidunt Road','P.O. Box 109, 6400 Diam St.','285-4260 A, Street','CO','2','volutpat ornare, facilisis eget,',@result);
call gym_sp_CreateNewCustomer (1,0,'Aristotle','Demetrius','Webster','1977-06-01','eros@Morbi.ca','1-177-436-5695','1-128-370-5914','1-687-707-9982','7186 Morbi St.','Ap #902-7973 Duis Ave','9272 Cum Rd.','Louisiana','2','tempor augue ac ipsum.',@result);
call gym_sp_CreateNewCustomer (1,0,'Connor','Gage','Wolfe','1988-02-29','augue.ut.lacus@senectusetnetus.com','1-201-491-7396','1-509-492-5662','1-314-554-3912','357-4527 At, Ave','P.O. Box 905, 4761 Ipsum St.','Ap #693-7060 Ante Road','District of Columbia','1','consectetuer adipiscing elit.',@result);
call gym_sp_CreateNewCustomer (1,0,'Stuart','Sybill','Foster','1978-03-30','mollis@elit.com','1-437-599-6317','1-428-193-0156','1-693-586-7091','296-1440 Mattis Road','6999 A, St.','P.O. Box 298, 9977 Sapien, St.','British Columbia','2','Donec elementum, lorem ut aliquam',@result);
call gym_sp_CreateNewCustomer (1,0,'Rhonda','Cara','Fletcher','1973-08-24','sed.sem@amet.ca','1-615-468-0159','1-642-844-9751','1-630-453-0337','3045 Integer Rd.','Ap #602-8087 Habitant Street','311-442 Ut Ave','Ontario','1','eu erat',@result);
call gym_sp_CreateNewCustomer (1,0,'Harlan','Demetria','Hurley','1984-09-17','malesuada.malesuada.Integer@Proinnisl.ca','1-769-809-0729','1-175-386-9273','1-404-728-5838','P.O. Box 236, 7080 Faucibus Rd.','P.O. Box 248, 6836 Libero. Rd.','780-5835 Fusce Street','Northwest Territories','2','diam eu dolor egestas rhoncus. Proin',@result);
call gym_sp_CreateNewCustomer (1,0,'Ginger','Marshall','Lamb','1974-03-18','vitae@erateget.edu','1-463-213-1862','1-260-923-4796','1-788-143-2779','P.O. Box 217, 494 Felis Av.','670 Senectus Street','389-4684 Aliquet Rd.','NS','2','gravida mauris',@result);
call gym_sp_CreateNewCustomer (1,0,'Kieran','Chase','Andrews','1979-05-15','Nunc@dictum.com','1-634-170-9714','1-757-199-6768','1-598-118-0718','256-7089 Semper Road','P.O. Box 314, 4349 Vulputate Road','2900 Dictum St.','Ohio','2','interdum. Curabitur dictum. Phasellus',@result);
call gym_sp_CreateNewCustomer (1,0,'Sarah','Jack','Craig','1974-12-01','sociis.natoque.penatibus@penatibus.com','1-781-772-6708','1-729-650-5772','1-634-586-4191','5085 Libero. St.','P.O. Box 392, 9792 Faucibus Ave','Ap #102-2604 Sed Street','NS','1','ut,',@result);
call gym_sp_CreateNewCustomer (1,0,'Illiana','Lacota','Hughes','1980-11-29','mollis@viverraMaecenasiaculis.edu','1-744-156-3640','1-442-465-8031','1-141-505-7250','P.O. Box 714, 4686 Interdum. Rd.','P.O. Box 247, 6724 Consectetuer, Rd.','P.O. Box 109, 8548 Blandit Rd.','SD','2','aliquet. Proin velit. Sed malesuada augue',@result);
call gym_sp_CreateNewCustomer (1,0,'Alana','Henry','Holmes','1978-12-15','sapien.Aenean@aduiCras.edu','1-904-401-4086','1-951-949-5174','1-168-102-6107','776-343 Vestibulum, St.','840-7344 Sapien, Rd.','607-7912 Elit, Av.','NS','2','commodo ipsum. Suspendisse non leo. Vivamus',@result);
call gym_sp_CreateNewCustomer (1,0,'Martina','Aileen','Adams','1987-05-23','pellentesque.massa.lobortis@Suspendisse.com','1-554-712-9899','1-910-598-0273','1-162-762-6345','Ap #815-4817 Nulla St.','Ap #464-6521 Proin Street','3753 Molestie Road','WA','2','Etiam vestibulum',@result);
call gym_sp_CreateNewCustomer (1,0,'Leonard','Karen','Perkins','1979-01-07','amet@sedpede.com','1-763-279-7152','1-363-191-7117','1-237-784-9686','P.O. Box 335, 4695 Neque Av.','1112 Nibh St.','153-2429 Sed Avenue','AB','2','Maecenas iaculis aliquet diam. Sed diam',@result);
call gym_sp_CreateNewCustomer (1,0,'Tashya','Patricia','Bentley','1989-12-07','sit.amet.diam@dictum.edu','1-252-692-7335','1-227-252-2944','1-548-419-1495','3902 Felis Rd.','Ap #830-2258 Tempor, Rd.','427-437 Iaculis Street','RI','2','lectus justo',@result);
call gym_sp_CreateNewCustomer (1,0,'Camille','Boris','Noble','1985-06-27','ac@velpedeblandit.ca','1-181-553-7416','1-413-829-6465','1-298-404-6024','Ap #748-9986 Ultrices Ave','6416 Orci Av.','P.O. Box 968, 3050 Tellus Avenue','Nevada','2','et,',@result);
call gym_sp_CreateNewCustomer (1,0,'Sierra','Sigourney','Delacruz','1976-08-16','parturient.montes.nascetur@elitCurabitursed.org','1-473-891-6622','1-500-438-5542','1-551-333-2722','660-6530 Ligula. Rd.','7999 Id, Avenue','P.O. Box 190, 9307 Morbi Avenue','ID','1','convallis est, vitae',@result);
call gym_sp_CreateNewCustomer (1,0,'Reese','Leilani','Rollins','1981-04-02','mattis@eros.edu','1-948-107-3717','1-837-924-3063','1-417-275-3661','721-5091 Nibh. Avenue','928-5805 Phasellus St.','6097 Risus, Ave','Manitoba','2','augue eu',@result);
call gym_sp_CreateNewCustomer (1,0,'Veda','Anthony','Rodgers','1977-03-20','lacinia.at.iaculis@ligula.com','1-415-561-8369','1-775-631-7300','1-236-134-7051','476-5192 Tempus Av.','509-9703 Rutrum St.','Ap #716-7249 Dictum St.','ME','1','Curabitur dictum. Phasellus in',@result);
call gym_sp_CreateNewCustomer (1,0,'Breanna','Lavinia','May','1979-02-17','ac.libero@dapibusquam.com','1-107-486-4536','1-980-650-4033','1-595-640-1862','P.O. Box 273, 8445 Duis Rd.','P.O. Box 371, 1201 Gravida Road','5465 Molestie Street','Nova Scotia','2','elit. Curabitur sed tortor. Integer',@result);
call gym_sp_CreateNewCustomer (1,0,'Steel','Clarke','Michael','1978-07-17','mauris.Morbi@sitametlorem.ca','1-821-731-4795','1-301-261-6141','1-211-137-3655','P.O. Box 230, 6464 Non, Rd.','915-578 A, Rd.','P.O. Box 406, 3221 Duis St.','WA','1','tempor',@result);
call gym_sp_CreateNewCustomer (1,0,'Desiree','Avram','Lee','1984-02-17','Sed@enim.edu','1-436-182-1668','1-296-524-9239','1-340-655-6972','184-6259 Aliquam Rd.','P.O. Box 247, 7695 Dictum Avenue','Ap #373-8849 Praesent Road','PE','2','et, rutrum eu,',@result);
call gym_sp_CreateNewCustomer (1,0,'Scarlett','August','Anderson','1978-07-26','nisi.nibh@utmolestiein.ca','1-669-398-9442','1-295-584-2663','1-518-318-7889','954 At Av.','906-7911 Aliquam St.','9827 Quis Ave','ND','1','et netus',@result);
call gym_sp_CreateNewCustomer (1,0,'Tobias','Illana','Suarez','1978-11-16','urna@ipsumnuncid.org','1-224-397-4344','1-697-699-1768','1-299-148-3052','P.O. Box 888, 3749 Curabitur St.','Ap #473-2077 Aliquet, Street','P.O. Box 448, 5935 Non St.','NL','2','arcu',@result);
call gym_sp_CreateNewCustomer (1,0,'Jameson','Carl','Hull','1980-12-08','dui@egetvenenatis.org','1-897-596-8134','1-475-736-1051','1-652-176-3210','6369 Neque St.','3240 Aliquam St.','Ap #277-4885 Et Ave','YT','2','luctus et ultrices posuere',@result);
call gym_sp_CreateNewCustomer (1,0,'Ivana','Brianna','Huber','1978-05-15','tempor.lorem@dui.edu','1-990-929-7131','1-736-989-8699','1-541-956-4472','P.O. Box 641, 5555 Nam St.','P.O. Box 842, 8934 Mattis Street','789-5161 A, Rd.','PA','1','orci. Donec',@result);
call gym_sp_CreateNewCustomer (1,0,'Jayme','Eden','Nichols','1973-04-25','Proin@eleifend.edu','1-554-973-7272','1-747-507-1358','1-789-215-2970','1112 Fringilla, Road','P.O. Box 346, 9496 Semper Road','Ap #649-4443 Consequat Ave','NU','2','lacinia',@result);
call gym_sp_CreateNewCustomer (1,0,'Melinda','Ahmed','Stevens','1975-11-11','magna.Praesent.interdum@nulla.com','1-661-410-0924','1-140-782-2042','1-869-568-3290','Ap #271-3443 Luctus St.','4427 Tellus. Rd.','Ap #710-3873 Sapien Street','MO','1','ac mattis semper, dui lectus',@result);
call gym_sp_CreateNewCustomer (1,0,'Naomi','Ray','Barnes','1984-10-03','pede@idblandit.org','1-413-415-3877','1-136-768-2238','1-413-184-3588','744 Eu, Street','236-8910 Nec St.','6117 At Street','Oklahoma','2','augue,',@result);
call gym_sp_CreateNewCustomer (1,0,'Xander','Cade','Craig','1985-09-11','pede@malesuadaaugue.org','1-122-510-8825','1-245-204-8327','1-926-838-9443','Ap #801-5532 Auctor, Av.','Ap #132-7469 Nunc Rd.','P.O. Box 637, 3241 Gravida St.','Alberta','2','magnis dis parturient',@result);
call gym_sp_CreateNewCustomer (1,0,'Kelly','Derek','Todd','1971-01-19','sem.molestie@nonummy.com','1-181-233-2424','1-906-537-6528','1-464-983-3061','5794 Ridiculus Avenue','755-9188 Ullamcorper. Avenue','3041 Vitae, St.','NT','1','euismod et, commodo at, libero.',@result);
call gym_sp_CreateNewCustomer (1,0,'Leigh','Ingrid','Francis','1988-01-02','Cum.sociis@nonquam.com','1-866-297-7364','1-610-548-9049','1-328-861-3072','P.O. Box 376, 1452 Justo Avenue','687-6564 Nunc. Av.','3327 Faucibus Street','Manitoba','2','dolor. Fusce mi lorem,',@result);
call gym_sp_CreateNewCustomer (1,0,'Vladimir','Ivor','George','1986-09-19','Integer.id@orcilacusvestibulum.com','1-166-318-3066','1-899-627-7450','1-215-158-7154','731-5480 Luctus Rd.','Ap #129-8051 Volutpat St.','Ap #226-4383 Ut, Av.','Saskatchewan','1','id, ante. Nunc mauris',@result);


















