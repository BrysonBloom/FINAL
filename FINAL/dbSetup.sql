CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
  -- coverImg varchar(255) COMMENT 'User CoverImg'
) default charset utf8 COMMENT '';

INSERT INTO accountsO(
  coverImg varchar(255) COMMENT 'User CoverImg'
);



DROP Table accounts;
DROP Table Recipes;