﻿CREATE TABLE `Person_H` (
  `ID` CHAR(36) NOT NULL COMMENT '',
  `TenantID` CHAR(36) NOT NULL COMMENT '',
  `StartDate` DATE NOT NULL DEFAULT '1900-01-01' COMMENT '',
  `EndDate` DATE NOT NULL DEFAULT '9999-01-01' COMMENT '',
  `_Modifier` VARCHAR(50) NOT NULL DEFAULT 'UNKNOWN' COMMENT '',
  `_Timestamp` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '',
  `_Version` INT NOT NULL DEFAULT 1 COMMENT '',
  PRIMARY KEY (`ID`)  COMMENT '',
  INDEX `IDX_Person_H_TenantID` (`TenantID` ASC)  COMMENT '',
  INDEX `IDX_Person_H_StartDate-EndDate` (`StartDate`, `EndDate` ASC)  COMMENT '',
  FOREIGN KEY (`TenantID`) REFERENCES `Tenant_H` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE);