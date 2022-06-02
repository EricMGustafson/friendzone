CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL PRIMARY KEY,
  name VARCHAR(255),
  picture TEXT,

  FOREIGN KEY (id) REFERENCES accounts(id) ON DELETE CASCADE

) default charset utf8;

CREATE TABLE IF NOT EXISTS follows(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  followerId VARCHAR(255) NOT NULL,
  followingId VARCHAR(255) NOT NULL,

  FOREIGN KEY (followerId)
    REFERENCES profiles(id)
    ON DElETE CASCADE,

  FOREIGN KEY (followingId)
    REFERENCES profiles(id)
    ON DELETE CASCADE
    
) default charset utf8;
