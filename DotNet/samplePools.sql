--
-- File generated with SQLiteStudio v3.4.17 on Fri Jun 13 09:34:26 2025
--
-- Text encoding used: System
--
BEGIN TRANSACTION;

-- Table: UserProfile
DROP TABLE IF EXISTS UserProfile;

CREATE TABLE UserProfile (
    username TEXT PRIMARY KEY,
    name     TEXT,
    password TEXT    DEFAULT ('password') 
);

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'rrosalind',
                            'Rosalind',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'jjeff',
                            'Jeff',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'abutler',
                            'Alex',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'nnina',
                            'Nina',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'ppatrica',
                            'Patrica',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'kkelley',
                            'Kelley',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'jjayden',
                            'Jayden',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'ttaylor',
                            'Taylor',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'pparis',
                            'Paris',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'kkathleen',
                            'Kathleen',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'aadam',
                            'Adam',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'sstephan',
                            'Stephan',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'ffrancis',
                            'Francis',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'aapril',
                            'April',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'llucy',
                            'Lucy',
                            'password'
                        );

INSERT INTO UserProfile (
                            username,
                            name,
                            password
                        )
                        VALUES (
                            'mmorgan',
                            'Morgan',
                            'password'
                        );

-- Table: Pool
DROP TABLE IF EXISTS Pool;

CREATE TABLE Pool (
    name        VARCHAR PRIMARY KEY,
    source_name TEXT,
    source_link TEXT,
    host        VARCHAR,
    bio         TEXT,
    FOREIGN KEY (
        host
    )
    REFERENCES UserProfile (username) ON DELETE CASCADE
                                      ON UPDATE CASCADE
);

INSERT INTO Pool (
                     name,
                     source_name,
                     source_link,
                     host,
                     bio
                 )
                 VALUES (
                     'Lone Survivors',
                     'Survivor Season 1',
                     'https://en.wikipedia.org/wiki/Survivor:_Borneo',
                     'abutler',
                     'Join this test league to see other features within the environment. As Survivor Season 1 aired in 2000, this current league is closed for actual participants. This pool shows a type where participants gain points as their contestant stays in the competition. The other type of pool allows players to guess when contestants get eliminated similar to NCAA brackets.'
                 );

INSERT INTO Pool (
                     name,
                     source_name,
                     source_link,
                     host,
                     bio
                 )
                 VALUES (
                     'Lone Survivors Revival',
                     'Survivor Season 2',
                     'https://en.wikipedia.org/wiki/Survivor:_The_Australian_Outback',
                     'abutler',
                     'Here is another test league to see how data can transition within the application. Survivor Season 2 allows us to see how to use the same host name and participants within a new pool.'
                 );

INSERT INTO Pool (
                     name,
                     source_name,
                     source_link,
                     host,
                     bio
                 )
                 VALUES (
                     'Lone Survivors Final Boss',
                     'Survivor Season 3',
                     'https://en.wikipedia.org/wiki/Survivor:_Africa',
                     'abutler',
                     'We have another Survivor league! Our fake participants hyped up the stakes and did their final season with our league.'
                 );


-- Table: PoolMembers
DROP TABLE IF EXISTS PoolMembers;

CREATE TABLE PoolMembers (
    name       TEXT,
    username   VARCHAR,
    pool_name  VARCHAR,
    rank_num   BIGINT,
    points     BIGINT,
    contestant TEXT,
    PRIMARY KEY (
        username,
        pool_name
    ),
    FOREIGN KEY (
        username
    )
    REFERENCES UserProfile (username) ON DELETE CASCADE
                                      ON UPDATE CASCADE,
    FOREIGN KEY (
        pool_name
    )
    REFERENCES Pool (name) ON DELETE CASCADE
                           ON UPDATE CASCADE
);

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Rosalind',
                            'rrosalind',
                            'Lone Survivors',
                            1,
                            15,
                            'Richard'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Jeff',
                            'jjeff',
                            'Lone Survivors',
                            2,
                            14,
                            'Kelly'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Alex',
                            'abutler',
                            'Lone Survivors',
                            3,
                            13,
                            'Rudy'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Nina',
                            'nnina',
                            'Lone Survivors',
                            4,
                            12,
                            'Susan'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Patrica',
                            'ppatrica',
                            'Lone Survivors',
                            5,
                            11,
                            'Sean'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Kelley',
                            'kkelley',
                            'Lone Survivors',
                            6,
                            10,
                            'Coleen'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Jayden',
                            'jjayden',
                            'Lone Survivors',
                            7,
                            9,
                            'Gervase'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Taylor',
                            'ttaylor',
                            'Lone Survivors',
                            8,
                            8,
                            'Jenna'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Paris',
                            'pparis',
                            'Lone Survivors',
                            9,
                            7,
                            'Greg'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Kathleen',
                            'kkathleen',
                            'Lone Survivors',
                            10,
                            6,
                            'Gretchen'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Adam',
                            'aadam',
                            'Lone Survivors',
                            11,
                            5,
                            'Joel'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Stephan',
                            'sstephan',
                            'Lone Survivors',
                            12,
                            4,
                            'Dirk'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Francis',
                            'ffrancis',
                            'Lone Survivors',
                            13,
                            3,
                            'Ramona'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'April',
                            'aapril',
                            'Lone Survivors',
                            14,
                            2,
                            'Stacey'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Lucy',
                            'llucy',
                            'Lone Survivors',
                            15,
                            1,
                            'BB'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Morgan',
                            'mmorgan',
                            'Lone Survivors',
                            16,
                            0,
                            'Sonja'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Taylor',
                            'ttaylor',
                            'Lone Survivors Revival',
                            1,
                            15,
                            'Tina'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Adam',
                            'aadam',
                            'Lone Survivors Revival',
                            2,
                            14,
                            'Colby'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Morgan',
                            'mmorgan',
                            'Lone Survivors Revival',
                            3,
                            13,
                            'Keith'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Nina',
                            'nnina',
                            'Lone Survivors Revival',
                            4,
                            12,
                            'Elisabeth'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Jayden',
                            'jjayden',
                            'Lone Survivors Revival',
                            5,
                            11,
                            'Rodger'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Kelley',
                            'kkelley',
                            'Lone Survivors Revival',
                            6,
                            10,
                            'Amber'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Kathleen',
                            'kkathleen',
                            'Lone Survivors Revival',
                            7,
                            9,
                            'Nick'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Paris',
                            'pparis',
                            'Lone Survivors Revival',
                            8,
                            8,
                            'Jerri'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Francis',
                            'ffrancis',
                            'Lone Survivors Revival',
                            9,
                            7,
                            'Alicia'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'April',
                            'aapril',
                            'Lone Survivors Revival',
                            10,
                            6,
                            'Jeff'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Lucy',
                            'llucy',
                            'Lone Survivors Revival',
                            11,
                            5,
                            'Michael'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Stephan',
                            'sstephan',
                            'Lone Survivors Revival',
                            12,
                            4,
                            'Kimmi'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Alex',
                            'abutler',
                            'Lone Survivors Revival',
                            13,
                            3,
                            'Mitchell'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Patrica',
                            'ppatrica',
                            'Lone Survivors Revival',
                            14,
                            2,
                            'Maralyn'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Rosalind',
                            'rrosalind',
                            'Lone Survivors Revival',
                            15,
                            1,
                            'Kel'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Jeff',
                            'jjeff',
                            'Lone Survivors Revival',
                            16,
                            0,
                            'Debb'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Paris',
                            'pparis',
                            'Lone Survivors Final Boss',
                            1,
                            15,
                            'Kim J'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Morgan',
                            'mmorgan',
                            'Lone Survivors Final Boss',
                            2,
                            14,
                            'Ethan'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'April',
                            'aapril',
                            'Lone Survivors Final Boss',
                            3,
                            13,
                            'Lex'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Nina',
                            'nnina',
                            'Lone Survivors Final Boss',
                            4,
                            12,
                            'Tom'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Taylor',
                            'ttaylor',
                            'Lone Survivors Final Boss',
                            5,
                            11,
                            'Teresa'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Jeff',
                            'jjeff',
                            'Lone Survivors Final Boss',
                            6,
                            10,
                            'Kim P'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Kathleen',
                            'kkathleen',
                            'Lone Survivors Final Boss',
                            7,
                            9,
                            'Frank'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Patrica',
                            'ppatrica',
                            'Lone Survivors Final Boss',
                            8,
                            8,
                            'Brandon'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Kelley',
                            'kkelley',
                            'Lone Survivors Final Boss',
                            9,
                            7,
                            'Kelly'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Alex',
                            'abutler',
                            'Lone Survivors Final Boss',
                            10,
                            6,
                            'Clarence'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Stephan',
                            'sstephan',
                            'Lone Survivors Final Boss',
                            11,
                            5,
                            'Lindsey'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Francis',
                            'ffrancis',
                            'Lone Survivors Final Boss',
                            12,
                            4,
                            'Silas'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Lucy',
                            'llucy',
                            'Lone Survivors Final Boss',
                            13,
                            3,
                            'Linda'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Adam',
                            'aadam',
                            'Lone Survivors Final Boss',
                            14,
                            2,
                            'Carl'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Rosalind',
                            'rrosalind',
                            'Lone Survivors Final Boss',
                            15,
                            1,
                            'Jessie'
                        );

INSERT INTO PoolMembers (
                            name,
                            username,
                            pool_name,
                            rank_num,
                            points,
                            contestant
                        )
                        VALUES (
                            'Jayden',
                            'jjayden',
                            'Lone Survivors Final Boss',
                            16,
                            0,
                            'Diane'
                        );

COMMIT TRANSACTION;