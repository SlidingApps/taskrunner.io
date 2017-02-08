-- MySQL dump 10.13  Distrib 5.6.34, for Linux (x86_64)
--
-- Host: pa-taskrunner01.cloudapp.net    Database: TaskRunner_DEV
-- ------------------------------------------------------
-- Server version	5.7.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Temporary view structure for view `Account_Credentials_V`
--

DROP TABLE IF EXISTS `Account_Credentials_V`;
/*!50001 DROP VIEW IF EXISTS `Account_Credentials_V`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `Account_Credentials_V` AS SELECT 
 1 AS `ID`,
 1 AS `TenantID`,
 1 AS `TenantCode`,
 1 AS `EmailAddress`,
 1 AS `UserName`,
 1 AS `Password`,
 1 AS `Salt`,
 1 AS `ValidFrom`,
 1 AS `ValidUntil`,
 1 AS `IsOwner`,
 1 AS `IsMember`,
 1 AS `IsFollower`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Account_H`
--

DROP TABLE IF EXISTS `Account_H`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Account_H` (
  `ID` char(36) NOT NULL,
  `EmailAddress` varchar(200) NOT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Account_H_Emailaddress` (`EmailAddress`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Account_H`
--

LOCK TABLES `Account_H` WRITE;
/*!40000 ALTER TABLE `Account_H` DISABLE KEYS */;
/*!40000 ALTER TABLE `Account_H` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Account_H` BEFORE INSERT ON `Account_H` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `Account_Profile_S`
--

DROP TABLE IF EXISTS `Account_Profile_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Account_Profile_S` (
  `ID` char(36) NOT NULL,
  `AccountID` char(36) NOT NULL,
  `Name` varchar(100) NOT NULL DEFAULT '',
  `Firstname` varchar(100) NOT NULL DEFAULT '',
  `DisplayName` varchar(200) NOT NULL DEFAULT '',
  `CreationTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Info` varchar(5000) NOT NULL DEFAULT '',
  `Status` varchar(50) NOT NULL DEFAULT 'UNCONFIRMED',
  `Link` varchar(200) DEFAULT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Account_Profile_S_PersonID` (`AccountID`),
  KEY `IDX_Account_Profile_S_Name-Firstname` (`Name`,`Firstname`),
  CONSTRAINT `FK_Account_Profile_S_AccountID` FOREIGN KEY (`AccountID`) REFERENCES `Account_H` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Account_Profile_S`
--

LOCK TABLES `Account_Profile_S` WRITE;
/*!40000 ALTER TABLE `Account_Profile_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Account_Profile_S` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Account_Profile_S` BEFORE INSERT ON `Account_Profile_S` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `Account_Profile_V`
--

DROP TABLE IF EXISTS `Account_Profile_V`;
/*!50001 DROP VIEW IF EXISTS `Account_Profile_V`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `Account_Profile_V` AS SELECT 
 1 AS `ID`,
 1 AS `TenantID`,
 1 AS `TenantCode`,
 1 AS `EmailAddress`,
 1 AS `Username`,
 1 AS `Firstname`,
 1 AS `Name`,
 1 AS `Status`,
 1 AS `Link`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Account_User_S`
--

DROP TABLE IF EXISTS `Account_User_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Account_User_S` (
  `ID` char(36) NOT NULL,
  `AccountID` char(36) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Password` varchar(400) NOT NULL DEFAULT '',
  `Salt` varchar(200) NOT NULL,
  `ValidFrom` date NOT NULL DEFAULT '1900-01-01',
  `ValidUntil` date NOT NULL DEFAULT '9999-01-01',
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Account_User_S_Name` (`Name`),
  KEY `FK_Account_User_S_AccountID` (`AccountID`),
  CONSTRAINT `FK_Account_User_S_AccountID` FOREIGN KEY (`AccountID`) REFERENCES `Account_H` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Account_User_S`
--

LOCK TABLES `Account_User_S` WRITE;
/*!40000 ALTER TABLE `Account_User_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Account_User_S` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Account_User_S` BEFORE INSERT ON `Account_User_S` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `Account_V`
--

DROP TABLE IF EXISTS `Account_V`;
/*!50001 DROP VIEW IF EXISTS `Account_V`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `Account_V` AS SELECT 
 1 AS `ID`,
 1 AS `TenantID`,
 1 AS `TenantCode`,
 1 AS `EmailAddress`,
 1 AS `UserName`,
 1 AS `ValidFrom`,
 1 AS `ValidUntil`,
 1 AS `Name`,
 1 AS `Firstname`,
 1 AS `DisplayName`,
 1 AS `Info`,
 1 AS `CreationTime`,
 1 AS `IsOwner`,
 1 AS `IsMember`,
 1 AS `IsFollower`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Communication_H`
--

DROP TABLE IF EXISTS `Communication_H`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Communication_H` (
  `ID` char(36) NOT NULL,
  `Type` varchar(50) NOT NULL DEFAULT 'MAIL',
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Communication_H`
--

LOCK TABLES `Communication_H` WRITE;
/*!40000 ALTER TABLE `Communication_H` DISABLE KEYS */;
/*!40000 ALTER TABLE `Communication_H` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Communication_Mail_S`
--

DROP TABLE IF EXISTS `Communication_Mail_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Communication_Mail_S` (
  `ID` char(36) NOT NULL,
  `CommunicationID` char(36) NOT NULL,
  `ExternalID` varchar(200) DEFAULT NULL,
  `Recipient` varchar(50) NOT NULL,
  `Subject` varchar(200) NOT NULL,
  `TextContent` varchar(2000) DEFAULT 'NO CONTENT',
  `HtmlContent` varchar(2000) NOT NULL DEFAULT 'NO CONTENT',
  `CreationTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `Status` varchar(50) NOT NULL DEFAULT 'NOT_SPECIFIED',
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Communication_Mail_S`
--

LOCK TABLES `Communication_Mail_S` WRITE;
/*!40000 ALTER TABLE `Communication_Mail_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Communication_Mail_S` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `Communication_Mail_V`
--

DROP TABLE IF EXISTS `Communication_Mail_V`;
/*!50001 DROP VIEW IF EXISTS `Communication_Mail_V`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `Communication_Mail_V` AS SELECT 
 1 AS `ID`,
 1 AS `ExternalID`,
 1 AS `Recipient`,
 1 AS `Subject`,
 1 AS `HtmlContent`,
 1 AS `CreationTime`,
 1 AS `Status`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Mail_Template_H`
--

DROP TABLE IF EXISTS `Mail_Template_H`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mail_Template_H` (
  `ID` char(36) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Mail_Template_H_Code` (`Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Mail_Template_H`
--

LOCK TABLES `Mail_Template_H` WRITE;
/*!40000 ALTER TABLE `Mail_Template_H` DISABLE KEYS */;
INSERT INTO `Mail_Template_H` VALUES ('7a3f44b7-4ffc-11e6-b94f-0242ac110003','ACCOUNT_CONFIRMATION_LINK','UNKNOWN','2016-07-22 11:07:28',1),('7a4e4b2a-4ffc-11e6-b94f-0242ac110003','RESET_PASSWORD_LINK','UNKNOWN','2016-07-22 11:07:28',1),('f86dbe21-4ff8-11e6-b94f-0242ac110003','TENANT_CONFIRMATION_LINK','UNKNOWN','2016-07-22 10:42:21',1);
/*!40000 ALTER TABLE `Mail_Template_H` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Mail_Template_H` BEFORE INSERT ON `Mail_Template_H` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `Mail_Template_Info_S`
--

DROP TABLE IF EXISTS `Mail_Template_Info_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mail_Template_Info_S` (
  `ID` char(36) NOT NULL,
  `MailTemplateID` char(36) NOT NULL,
  `Subject` varchar(200) NOT NULL,
  `TextTemplate` varchar(5000) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `HtmlTemplate` varchar(5000) CHARACTER SET utf8 NOT NULL,
  `ValidFrom` date NOT NULL DEFAULT '1900-01-01',
  `ValidUntil` date NOT NULL DEFAULT '9999-01-01',
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Mail_Template_Info_S_MailTemplateID` (`MailTemplateID`),
  KEY `IDX_Mail_Template_Info_S_ValidFrom-ValidUntil` (`ValidFrom`,`ValidUntil`),
  CONSTRAINT `FK_Mail_Template_Info_S_MailTemplateID` FOREIGN KEY (`MailTemplateID`) REFERENCES `Mail_Template_H` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Mail_Template_Info_S`
--

LOCK TABLES `Mail_Template_Info_S` WRITE;
/*!40000 ALTER TABLE `Mail_Template_Info_S` DISABLE KEYS */;
INSERT INTO `Mail_Template_Info_S` VALUES ('0eddc43c-4ffe-11e6-b94f-0242ac110003','7a3f44b7-4ffc-11e6-b94f-0242ac110003','TaskRunner - Confirm account','Hello {Recipient},\n\nPlease copy the following URL into your browser to confirm your account: {ConfirmationUrl}.\n\nThe taskrunner.io team.','<p>Hello {Recipient},</p>\n<p>Please follow this <a href=\"{ConfirmationUrl}\">link</a> to confirm your account or copy the following URL into your browser: {ConfirmationUrl}.</p>\n<p>The taskrunner.io team.</p>','1900-01-01','9999-01-01','UNKNOWN','2016-07-22 11:18:47',1),('0ee26d9c-4ffe-11e6-b94f-0242ac110003','7a4e4b2a-4ffc-11e6-b94f-0242ac110003','TaskRunner - Reset password','Hello {Recipient},\n\nPlease copy the following URL into your browser: {ResetPasswordUrl}.\n\nThe taskrunner.io team.','<p>Hello {Recipient},</p>\n<p>Please follow this <a href=\"{ResetPasswordUrl}\">link</a> to reset your password or copy the following URL into your browser: {ResetPasswordUrl}.</p>\n<p>The taskrunner.io team.</p>','1900-01-01','9999-01-01','UNKNOWN','2016-07-22 11:18:47',1),('f472d548-4ffc-11e6-b94f-0242ac110003','f86dbe21-4ff8-11e6-b94f-0242ac110003','TaskRunner - Confirm tenant','Hello {Recipient},\n\nPlease copy the following URL into your browser to confirm {Code} as organisation: {ConfirmationUrl}.\n\nThe taskrunner.io team.','<p>Hello {Recipient},</p>\n<p>Please follow this <a href=\"{ConfirmationUrl}\">link</a> to confirm {Code} as organisation or copy the following URL into your browser: {ConfirmationUrl}.</p>\n<p>The taskrunner.io team.</p>','1900-01-01','9999-01-01','UNKNOWN','2016-07-22 11:10:53',1);
/*!40000 ALTER TABLE `Mail_Template_Info_S` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Mail_Template_Info_S` BEFORE INSERT ON `Mail_Template_Info_S` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `Mail_Template_V`
--

DROP TABLE IF EXISTS `Mail_Template_V`;
/*!50001 DROP VIEW IF EXISTS `Mail_Template_V`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `Mail_Template_V` AS SELECT 
 1 AS `ID`,
 1 AS `Subject`,
 1 AS `TextTemplate`,
 1 AS `HtmlTemplate`,
 1 AS `ValidFrom`,
 1 AS `ValidUntil`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Tenant_Account_L`
--

DROP TABLE IF EXISTS `Tenant_Account_L`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tenant_Account_L` (
  `ID` char(36) NOT NULL,
  `TenantID` char(36) NOT NULL,
  `AccountID` char(36) NOT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `FK_Tenant_Person_L_TenantID` (`TenantID`),
  KEY `FK_Tenant_Person_L_1_PersonID` (`AccountID`),
  CONSTRAINT `FK_Tenant_Account_L_AccountID` FOREIGN KEY (`AccountID`) REFERENCES `Account_H` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Tenant_Account_L_TenantID` FOREIGN KEY (`TenantID`) REFERENCES `Tenant_H` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tenant_Account_L`
--

LOCK TABLES `Tenant_Account_L` WRITE;
/*!40000 ALTER TABLE `Tenant_Account_L` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tenant_Account_L` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Tenant_Account_L` BEFORE INSERT ON `Tenant_Account_L` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `Tenant_Account_RoleSet_S`
--

DROP TABLE IF EXISTS `Tenant_Account_RoleSet_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tenant_Account_RoleSet_S` (
  `ID` char(36) NOT NULL,
  `TenantAccountID` char(36) NOT NULL,
  `IsOwner` int(11) NOT NULL DEFAULT '0',
  `IsMember` int(11) NOT NULL DEFAULT '0',
  `IsFollower` int(11) NOT NULL DEFAULT '0',
  `_Modifier` varchar(50) DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `FK_Tenant_Account_RoleSet_TenantAccountID` (`TenantAccountID`),
  CONSTRAINT `FK_Tenant_Account_RoleSet_TenantAccountID` FOREIGN KEY (`TenantAccountID`) REFERENCES `Tenant_Account_L` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tenant_Account_RoleSet_S`
--

LOCK TABLES `Tenant_Account_RoleSet_S` WRITE;
/*!40000 ALTER TABLE `Tenant_Account_RoleSet_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tenant_Account_RoleSet_S` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tenant_Domain_Info_S`
--

DROP TABLE IF EXISTS `Tenant_Domain_Info_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tenant_Domain_Info_S` (
  `ID` char(36) NOT NULL,
  `TenantDomainID` char(36) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(5000) NOT NULL,
  `ValidFrom` date NOT NULL DEFAULT '1900-01-01',
  `ValidUntil` date NOT NULL DEFAULT '9999-01-01',
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Tenant_Domain_Info_S_TenantDomainID` (`TenantDomainID`),
  KEY `IDX_Tenanr_Domain_Info_S_ValidFrom-ValidUntil` (`ValidFrom`,`ValidUntil`),
  CONSTRAINT `FK_Tenant_Domain_Info_S_TenantDomainID` FOREIGN KEY (`TenantDomainID`) REFERENCES `Tenant_Domain_S` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tenant_Domain_Info_S`
--

LOCK TABLES `Tenant_Domain_Info_S` WRITE;
/*!40000 ALTER TABLE `Tenant_Domain_Info_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tenant_Domain_Info_S` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tenant_Domain_S`
--

DROP TABLE IF EXISTS `Tenant_Domain_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tenant_Domain_S` (
  `ID` char(36) NOT NULL,
  `TenantID` char(36) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `FK_Tenant_Domain_S_TenantID-Code` (`TenantID`,`Code`),
  CONSTRAINT `FK_Tenant_Domain_L_TenantID` FOREIGN KEY (`TenantID`) REFERENCES `Tenant_H` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tenant_Domain_S`
--

LOCK TABLES `Tenant_Domain_S` WRITE;
/*!40000 ALTER TABLE `Tenant_Domain_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tenant_Domain_S` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tenant_H`
--

DROP TABLE IF EXISTS `Tenant_H`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tenant_H` (
  `ID` char(36) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Tenant_H_Code` (`Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tenant_H`
--

LOCK TABLES `Tenant_H` WRITE;
/*!40000 ALTER TABLE `Tenant_H` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tenant_H` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Tenant_H` BEFORE INSERT ON `Tenant_H` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `Tenant_Info_S`
--

DROP TABLE IF EXISTS `Tenant_Info_S`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tenant_Info_S` (
  `ID` char(36) NOT NULL,
  `TenantID` char(36) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(5000) NOT NULL,
  `CreationTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ValidFrom` date NOT NULL DEFAULT '1900-01-01',
  `ValidUntil` date NOT NULL DEFAULT '9999-01-01',
  `Status` varchar(50) NOT NULL DEFAULT 'UNCONFIRMED',
  `Link` varchar(200) DEFAULT NULL,
  `_Modifier` varchar(50) NOT NULL DEFAULT 'UNKNOWN',
  `_Timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `_Version` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UDX_Tenant_Info_S_TenantID` (`TenantID`),
  KEY `IDX_Tenant_Info_S_ValidFrom-ValidUntil` (`ValidFrom`,`ValidUntil`),
  CONSTRAINT `FK_Tenant_Info_S_TenantID` FOREIGN KEY (`TenantID`) REFERENCES `Tenant_H` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tenant_Info_S`
--

LOCK TABLES `Tenant_Info_S` WRITE;
/*!40000 ALTER TABLE `Tenant_Info_S` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tenant_Info_S` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `TRBI_Tenant_Info_S` BEFORE INSERT ON `Tenant_Info_S` FOR EACH ROW
BEGIN
	IF (NEW.ID IS NULL OR NEW.ID= '') THEN
		SET NEW.ID = UUID();
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `Tenant_V`
--

DROP TABLE IF EXISTS `Tenant_V`;
/*!50001 DROP VIEW IF EXISTS `Tenant_V`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `Tenant_V` AS SELECT 
 1 AS `ID`,
 1 AS `Code`,
 1 AS `Name`,
 1 AS `Description`,
 1 AS `CreationTime`,
 1 AS `ValidFrom`,
 1 AS `ValidUntil`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `Account_Credentials_V`
--

/*!50001 DROP VIEW IF EXISTS `Account_Credentials_V`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Account_Credentials_V` AS select `hub_a`.`ID` AS `ID`,`hub_t`.`ID` AS `TenantID`,`hub_t`.`Code` AS `TenantCode`,`hub_a`.`EmailAddress` AS `EmailAddress`,`sat_u`.`Name` AS `UserName`,`sat_u`.`Password` AS `Password`,`sat_u`.`Salt` AS `Salt`,`sat_u`.`ValidFrom` AS `ValidFrom`,`sat_u`.`ValidUntil` AS `ValidUntil`,`sat_r`.`IsOwner` AS `IsOwner`,`sat_r`.`IsMember` AS `IsMember`,`sat_r`.`IsFollower` AS `IsFollower` from (((((`Account_H` `hub_a` join `Account_User_S` `sat_u` on((`sat_u`.`AccountID` = `hub_a`.`ID`))) join `Account_Profile_S` `sat_p` on((`sat_p`.`AccountID` = `hub_a`.`ID`))) join `Tenant_Account_L` `link` on((`link`.`AccountID` = `hub_a`.`ID`))) join `Tenant_Account_RoleSet_S` `sat_r` on((`sat_r`.`TenantAccountID` = `link`.`ID`))) join `Tenant_H` `hub_t` on((`hub_t`.`ID` = `link`.`TenantID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Account_Profile_V`
--

/*!50001 DROP VIEW IF EXISTS `Account_Profile_V`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Account_Profile_V` AS select `hub_a`.`ID` AS `ID`,`hub_t`.`ID` AS `TenantID`,`hub_t`.`Code` AS `TenantCode`,`hub_a`.`EmailAddress` AS `EmailAddress`,`sat_au`.`Name` AS `Username`,`sat_ap`.`Firstname` AS `Firstname`,`sat_ap`.`Name` AS `Name`,`sat_ap`.`Status` AS `Status`,`sat_ap`.`Link` AS `Link` from (((((`Account_H` `hub_a` join `Account_Profile_S` `sat_ap` on((`sat_ap`.`AccountID` = `hub_a`.`ID`))) join `Account_User_S` `sat_au` on((`sat_au`.`AccountID` = `hub_a`.`ID`))) join `Tenant_Account_L` `link` on((`link`.`AccountID` = `hub_a`.`ID`))) join `Tenant_H` `hub_t` on((`hub_t`.`ID` = `link`.`TenantID`))) join `Tenant_Info_S` `sat_t` on((`sat_t`.`TenantID` = `hub_t`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Account_V`
--

/*!50001 DROP VIEW IF EXISTS `Account_V`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Account_V` AS select `hub_a`.`ID` AS `ID`,`hub_t`.`ID` AS `TenantID`,`hub_t`.`Code` AS `TenantCode`,`hub_a`.`EmailAddress` AS `EmailAddress`,`sat_u`.`Name` AS `UserName`,`sat_u`.`ValidFrom` AS `ValidFrom`,`sat_u`.`ValidUntil` AS `ValidUntil`,`sat_p`.`Name` AS `Name`,`sat_p`.`Firstname` AS `Firstname`,`sat_p`.`DisplayName` AS `DisplayName`,`sat_p`.`Info` AS `Info`,`sat_p`.`CreationTime` AS `CreationTime`,`sat_r`.`IsOwner` AS `IsOwner`,`sat_r`.`IsMember` AS `IsMember`,`sat_r`.`IsFollower` AS `IsFollower` from (((((`Account_H` `hub_a` join `Account_User_S` `sat_u` on((`sat_u`.`AccountID` = `hub_a`.`ID`))) join `Account_Profile_S` `sat_p` on((`sat_p`.`AccountID` = `hub_a`.`ID`))) join `Tenant_Account_L` `link` on((`link`.`AccountID` = `hub_a`.`ID`))) join `Tenant_Account_RoleSet_S` `sat_r` on((`sat_r`.`TenantAccountID` = `link`.`ID`))) join `Tenant_H` `hub_t` on((`hub_t`.`ID` = `link`.`TenantID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Communication_Mail_V`
--

/*!50001 DROP VIEW IF EXISTS `Communication_Mail_V`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Communication_Mail_V` AS select `hub`.`ID` AS `ID`,`sat`.`ExternalID` AS `ExternalID`,`sat`.`Recipient` AS `Recipient`,`sat`.`Subject` AS `Subject`,`sat`.`HtmlContent` AS `HtmlContent`,`sat`.`CreationTime` AS `CreationTime`,`sat`.`Status` AS `Status` from (`Communication_H` `hub` join `Communication_Mail_S` `sat` on((`sat`.`CommunicationID` = `hub`.`ID`))) where (`hub`.`Type` = 'MAIL') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Mail_Template_V`
--

/*!50001 DROP VIEW IF EXISTS `Mail_Template_V`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Mail_Template_V` AS select `hub`.`ID` AS `ID`,`sat`.`Subject` AS `Subject`,`sat`.`TextTemplate` AS `TextTemplate`,`sat`.`HtmlTemplate` AS `HtmlTemplate`,`sat`.`ValidFrom` AS `ValidFrom`,`sat`.`ValidUntil` AS `ValidUntil` from (`Mail_Template_H` `hub` join `Mail_Template_Info_S` `sat` on((`sat`.`MailTemplateID` = `hub`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Tenant_V`
--

/*!50001 DROP VIEW IF EXISTS `Tenant_V`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Tenant_V` AS select `hub`.`ID` AS `ID`,`hub`.`Code` AS `Code`,`sat`.`Name` AS `Name`,`sat`.`Description` AS `Description`,`sat`.`CreationTime` AS `CreationTime`,`sat`.`ValidFrom` AS `ValidFrom`,`sat`.`ValidUntil` AS `ValidUntil` from (`Tenant_H` `hub` join `Tenant_Info_S` `sat` on((`sat`.`TenantID` = `hub`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-24 11:02:04