-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema institute
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema institute
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `institute` DEFAULT CHARACTER SET utf8 ;
USE `institute` ;

-- -----------------------------------------------------
-- Table `institute`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Students` (
  `idStudents` INT NOT NULL,
  `FIOStudent` VARCHAR(45) NULL,
  `NumGroup` VARCHAR(10) NULL,
  PRIMARY KEY (`idStudents`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `institute`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Departments` (
  `idDepartments` INT NOT NULL,
  `TitleDepartment` VARCHAR(45) NULL,
  `PhoneDepartment` VARCHAR(15) NULL,
  PRIMARY KEY (`idDepartments`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `institute`.`Teachers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Teachers` (
  `idTeachers` INT NOT NULL,
  `FIOTeacher` VARCHAR(45) NULL,
  `StaffTeacher` VARCHAR(15) NULL,
  `Departments_idDepartments` INT NOT NULL,
  PRIMARY KEY (`idTeachers`),
  INDEX `fk_Teachers_Departments1_idx` (`Departments_idDepartments` ASC) VISIBLE,
  CONSTRAINT `fk_Teachers_Departments1`
    FOREIGN KEY (`Departments_idDepartments`)
    REFERENCES `institute`.`Departments` (`idDepartments`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `institute`.`Subjects`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Subjects` (
  `idSubjects` INT NOT NULL,
  `TitleSubject` VARCHAR(45) NULL,
  PRIMARY KEY (`idSubjects`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `institute`.`Results`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Results` (
  `Balls` INT NULL,
  `DateExam` DATETIME NULL,
  `Students_idStudents` INT NOT NULL,
  `idSubject` INT NOT NULL,
  `idTeacher` INT NOT NULL,
  `NumSemestr` INT NOT NULL,
  `Mark` INT NULL,
  PRIMARY KEY (`Students_idStudents`, `NumSemestr`, `idTeacher`, `idSubject`),
  CONSTRAINT `fk_Results_Students1`
    FOREIGN KEY (`Students_idStudents`)
    REFERENCES `institute`.`Students` (`idStudents`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `institute`.`Marks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Marks` (
  `idMarks` INT NOT NULL,
  `LowBalls` INT NULL,
  `HightBall` INT NULL,
  PRIMARY KEY (`idMarks`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `institute`.`Sessions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `institute`.`Sessions` (
  `NumGroup` VARCHAR(10) NOT NULL,
  `NumSemestr` INT NOT NULL,
  `Zach_Ezam` VARCHAR(45) NULL,
  `Subjects_idSubjects` INT NOT NULL,
  `Teachers_idTeachers` INT NOT NULL,
  PRIMARY KEY (`NumGroup`, `NumSemestr`, `Subjects_idSubjects`, `Teachers_idTeachers`),
  INDEX `fk_Sessions_Subjects_idx` (`Subjects_idSubjects` ASC) VISIBLE,
  INDEX `fk_Sessions_Teachers1_idx` (`Teachers_idTeachers` ASC) VISIBLE,
  CONSTRAINT `fk_Sessions_Subjects`
    FOREIGN KEY (`Subjects_idSubjects`)
    REFERENCES `institute`.`Subjects` (`idSubjects`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Sessions_Teachers1`
    FOREIGN KEY (`Teachers_idTeachers`)
    REFERENCES `institute`.`Teachers` (`idTeachers`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
