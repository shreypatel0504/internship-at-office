-- FoodChow Auth Schema & Stored Procedures
-- Compatible with MySQL 8.0+

CREATE DATABASE IF NOT EXISTS `foodchow_db` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `foodchow_db`;

-- ----------------------------------------------------------------------------
-- Table: tbl_user_master
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `tbl_user_master` (
    `user_id` BIGINT AUTO_INCREMENT PRIMARY KEY,
    `first_name` VARCHAR(100) NULL,
    `last_name` VARCHAR(100) NULL,
    `email` VARCHAR(255) NOT NULL UNIQUE,
    `mobile_no` VARCHAR(20) NULL,
    `password` VARCHAR(255) NOT NULL,
    `role` VARCHAR(50) NOT NULL DEFAULT 'Staff',
    `is_active` TINYINT(1) NOT NULL DEFAULT 1,
    `created_by` BIGINT NOT NULL DEFAULT 0,
    `created_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `updated_by` BIGINT NOT NULL DEFAULT 0,
    `updated_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `device_type` VARCHAR(50) NULL,
    `device_id` VARCHAR(255) NULL,
    `device_token` TEXT NULL,
    INDEX `idx_user_email` (`email`),
    INDEX `idx_user_mobile` (`mobile_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table: tbl_refresh_tokens
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `tbl_refresh_tokens` (
    `id` BIGINT AUTO_INCREMENT PRIMARY KEY,
    `user_id` BIGINT NOT NULL,
    `token` VARCHAR(500) NOT NULL,
    `expires_at` DATETIME NOT NULL,
    `revoked_at` DATETIME NULL,
    `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    INDEX `idx_refresh_tokens_token` (`token`),
    INDEX `idx_refresh_tokens_user_id` (`user_id`),
    CONSTRAINT `fk_refresh_tokens_user` FOREIGN KEY (`user_id`) 
        REFERENCES `tbl_user_master` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_GetUserByEmail
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_GetUserByEmail`;
DELIMITER $$
CREATE PROCEDURE `USP_GetUserByEmail`(
    IN `p_email` VARCHAR(255)
)
BEGIN
    SELECT 
        `user_id`,
        `first_name`,
        `last_name`,
        `email`,
        `mobile_no`,
        `password`,
        `role`,
        `is_active`,
        `created_by`,
        `updated_by`,
        `device_type`,
        `device_id`,
        `device_token`
    FROM `tbl_user_master`
    WHERE `email` = p_email
    LIMIT 1;
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_GetUserById
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_GetUserById`;
DELIMITER $$
CREATE PROCEDURE `USP_GetUserById`(
    IN `p_user_id` BIGINT
)
BEGIN
    SELECT 
        `user_id`,
        `first_name`,
        `last_name`,
        `email`,
        `mobile_no`,
        `password`,
        `role`,
        `is_active`,
        `created_by`,
        `updated_by`,
        `device_type`,
        `device_id`,
        `device_token`
    FROM `tbl_user_master`
    WHERE `user_id` = p_user_id
    LIMIT 1;
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_AddUser
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_AddUser`;
DELIMITER $$
CREATE PROCEDURE `USP_AddUser`(
    IN `p_first_name` VARCHAR(100),
    IN `p_last_name` VARCHAR(100),
    IN `p_email` VARCHAR(255),
    IN `p_mobile_no` VARCHAR(20),
    IN `p_password` VARCHAR(255),
    IN `p_role` VARCHAR(50)
)
BEGIN
    INSERT INTO `tbl_user_master` (
        `first_name`,
        `last_name`,
        `email`,
        `mobile_no`,
        `password`,
        `role`,
        `is_active`
    ) VALUES (
        p_first_name,
        p_last_name,
        p_email,
        p_mobile_no,
        p_password,
        IFNULL(p_role, 'Staff'),
        1
    );
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_SaveRefreshToken
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_SaveRefreshToken`;
DELIMITER $$
CREATE PROCEDURE `USP_SaveRefreshToken`(
    IN `p_user_id` BIGINT,
    IN `p_token` VARCHAR(500),
    IN `p_expires_at` DATETIME
)
BEGIN
    INSERT INTO `tbl_refresh_tokens` (
        `user_id`,
        `token`,
        `expires_at`
    ) VALUES (
        p_user_id,
        p_token,
        p_expires_at
    );
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_GetRefreshToken
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_GetRefreshToken`;
DELIMITER $$
CREATE PROCEDURE `USP_GetRefreshToken`(
    IN `p_token` VARCHAR(500)
)
BEGIN
    SELECT 
        `id`,
        `user_id`,
        `token`,
        `expires_at`,
        `revoked_at`
    FROM `tbl_refresh_tokens`
    WHERE `token` = p_token
    LIMIT 1;
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_RevokeRefreshToken
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_RevokeRefreshToken`;
DELIMITER $$
CREATE PROCEDURE `USP_RevokeRefreshToken`(
    IN `p_token` VARCHAR(500)
)
BEGIN
    UPDATE `tbl_refresh_tokens`
    SET `revoked_at` = UTC_TIMESTAMP()
    WHERE `token` = p_token AND `revoked_at` IS NULL;
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Stored Procedure: USP_RevokeAllUserRefreshTokens
-- ----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `USP_RevokeAllUserRefreshTokens`;
DELIMITER $$
CREATE PROCEDURE `USP_RevokeAllUserRefreshTokens`(
    IN `p_user_id` BIGINT
)
BEGIN
    UPDATE `tbl_refresh_tokens`
    SET `revoked_at` = UTC_TIMESTAMP()
    WHERE `user_id` = p_user_id AND `revoked_at` IS NULL;
END$$
DELIMITER ;

-- ----------------------------------------------------------------------------
-- Seed Data: Admin Account
-- Email: admin@foodchow.com
-- Password: Admin@123 (BCrypt hash work factor 11)
-- ----------------------------------------------------------------------------
INSERT INTO `tbl_user_master` (
    `first_name`,
    `last_name`,
    `email`,
    `mobile_no`,
    `password`,
    `role`,
    `is_active`
) VALUES (
    'Admin',
    'User',
    'admin@foodchow.com',
    '1234567890',
    '$2a$11$CEdhtY9apQfr1/aiqP.9SuTtOkWcPvIRZruvP.qVt4FYzNTDrpFqC',
    'Admin',
    1
)
ON DUPLICATE KEY UPDATE
    `password` = VALUES(`password`),
    `is_active` = 1,
    `role` = 'Admin';
