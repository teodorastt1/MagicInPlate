create database MagicInPlate
use MagicInPlate


CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);


CREATE TABLE Recipes (
    RecipeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    PreparationTime INT, 
    Difficulty NVARCHAR(20) CHECK (Difficulty IN ('Лесно', 'Средно', 'Трудно')),
    CategoryID INT,
    Instructions NVARCHAR(250),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);


CREATE TABLE Ingredients (
    IngredientID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);


CREATE TABLE RecipeIngredients (
    RecipeID INT,
    IngredientID INT,
    Quantity NVARCHAR(50), 
    PRIMARY KEY (RecipeID, IngredientID),
    FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID),
    FOREIGN KEY (IngredientID) REFERENCES Ingredients(IngredientID) 
);


--predi vseki string ima "N" zashtoto pri men im aproblem s nvarchar-a i bez nego ne bachka, molq i vie da go dobavqte za moe ulesnenie
insert into Categories(Name)
values(N'Предястие')
insert into Categories(Name)
values(N'Основно')
insert into Categories(Name)
values(N'Десерт')

--select * from Categories


insert into Ingredients 
values(N'Мляко')
insert into Ingredients 
values(N'Месо')
insert into Ingredients 
values(N'Шкембе')
insert into Ingredients 
values(N'Ориз')
insert into Ingredients 
values(N'Яйца')
insert into Ingredients 
values(N'Сол')
insert into Ingredients 
values(N'Ч. Пипер')
insert into Ingredients 
values(N'Олио')
insert into Ingredients 
values(N'Оцет')
insert into Ingredients 
values(N'Ч-вен. Пипер')
insert into Ingredients 
values(N'Сол')
insert into Ingredients 
values(N'Домати')
insert into Ingredients 
values(N'Картофи')
insert into Ingredients 
values(N'Краставици')
insert into Ingredients 
values(N'Моркови')
insert into Ingredients 
values(N'Лук')
insert into Ingredients 
values(N'Чесън')
insert into Ingredients 
values(N'Зеле')
insert into Ingredients 
values(N'Сирене')
insert into Ingredients 
values(N'Бисквити')
insert into Ingredients 
values(N'Какао')
insert into Ingredients 
values(N'Вода')
insert into Ingredients 
values(N'Боб')
insert into Ingredients 
values(N'Чушки')
insert into Ingredients 
values(N'К. Мляко')
insert into Ingredients 
values(N'Сметана')
insert into Ingredients 
values(N'Бульон')
INSERT into Ingredients
values(N'Подправки')
insert into Ingredients
values(N'Брашно')

--select * from Ingredients

--PREDQSTIQ
insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Шопска салата', N'Салата', 10, 'Лесно', 1, N'Нарежи 2 домата, 1 краставица и 1 червена чушка. Добави 100 г сирене, нарязано на кубчета. Подправи с 1 с.л. олио, 1 ч.л. оцет, сол и черен пипер на вкус. Разбъркай добре и сервирай.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Овчарска салата', N'Салата', 10, 'Лесно', 1, N'Нарежи 2 домата, 1 краставица, 1 червена чушка и 1 малка глава лук. Добави 100 г сирене и 50 г варено месо (по избор). Подправи с олио, оцет, сол и черен пипер. Разбъркай и сервирай!');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Пържени картофи', N'Други', 15, 'Лесно', 1, N'Обели 4 картофа и ги нарежи на тънки филийки. Загрей олио в тиган и ги изпържи до златисто. Посоли на вкус и добави черен пипер. Може да ги поднесеш с чесън или магданоз по желание.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Миш-маш', N'Други', 10, 'Лесно', 1, N'Задуши лук и чушки в олио, добави домати и подправки по избор. Разбий яйца и ги изсипи върху зеленчуците. Бъркай, докато яйцата се стегнат. Подправи със сол и черен пипер. Сервирай топло!');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Катък', N'Други', 7, 'Лесно', 1, N'Традиционен български сос, който се приготвя от 500 г кисело мляко, 2 скилидки чесън, сол на вкус и малко олио. Всички съставки се смесват добре до хомогенна смес и се сервира охладено. Може да се гарнира с копър.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Шкембе', N'Супи', 180, 'Трудно', 1, N'Сварете 1 кг шкембе в подсолена вода 2-3 часа. През това време запържете 2 скилидки чесън и червен пипер. Прибавете към шкембето и добавете 2 яйца, оцет и сол. Варете още 10 минути и сервирайте с лют червен пипер.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Пилешка супа', N'Супи', 90, 'Средно', 1, N'Варете 1 пилешко месо в 2 литра вода за 1 час. Добавете 2 моркова, ориз, сол и черен пипер. Когато месото омекне, го нарежете и върнете в супата. Сервирайте с магданоз.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Таратор', N'Супи', 10, 'Лесно', 1, N'Разбийте 500 г кисело мляко с 1 чаша студена вода. Добавете 1 скилидка чесън, пресован, сол на вкус и 2 супени лъжици олио. Разбъркайте добре и сервирайте с нарязан копър и малко лед за освежаващ ефект.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Крем супа', N'Супи', 30, 'Средно', 1, N'Запържете 1 глава лук и 2 картофа в малко масло. Залейте с 1 литър зеленчуков бульон и варете 20 минути. След това пасирайте всичко до гладка кремообразна консистенция. Добавете 100 мл сметана, сол и пипер, и варете още 5 минути.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Боб', N'Супи', 180, 'Трудно', 1, N'Залейте 500 г боб с вода и го варете около 1 час, след което сменете водата. Запържете 1 глава лук, 2 моркова и 1 червен пипер. Добавете към боба, сол, черен пипер и дафинов лист. Варете още 30 минути. Сервирайте с червен пипер и зехтин.');




--OSNOVNI
INSERT INTO Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
VALUES(N'Кюфтета с картофено пюре', N'Месно ястие с гарнитура', 40, 'Средно', 2, N'Омеси кайма с подправки, оформи кюфтета и ги изпържи. Свари 4 картофа, намачкай с масло и мляко. Сервирай кюфтетата с пюрето.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Пълнени чушки с ориз и месо', N'Ястие', 60, 'Средно', 2, N'Смеси ориз с кайма, лук, морков и подправки. Напълни чушки и ги печи 40 мин. на 180°C.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Пиле с ориз', N'Други', 70, 'Средно', 2, N'Задуши пилешко месо с лук и морков. Добави ориз, бульон, подправки и печи в тава.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Гювеч', N'Ястие с месо', 90, 'Трудно', 2, N'Нарежи зеленчуци и месо, подправи и печи в глинен съд 1.5 часа.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Мусака', N'Ястие', 80, 'Средно', 2, N'Редувай картофи и кайма, запечи и залей със смес от яйца и кисело мляко.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Картофена яхния', N'Постно ястие', 50, 'Лесно', 2, N'Задуши лук, добави картофи, морков, домат и подправки. Вари до омекване.');

INSERT INTO Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
VALUES (N'Зеле с месо', N'Ястие', 120, 'Трудно', 2, N'Задуши зеле и месо, добави подправки и вари на слаб огън 2 часа.');

--DESERTI

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Крем карамел', N'Десерт', 60, 'Средно', 3, N'Разбий яйца с мляко и захар. Изсипи в карамелизирани форми и печи на водна баня.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Тирамису', N'Десерт', 40, 'Трудно', 3, N'Редувай бишкоти, крем от маскарпоне и кафе. Охлади и поръси с какао.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Бисквитена торта', N'Десерт', 20, 'Лесно', 3, N'Редувай бисквити и крем. Остави в хладилника 2 часа.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Палачинки', N'Десерт', 30, 'Лесно', 3, N'Приготви тесто от яйца, мляко и брашно. Изпържи и сервирай със сладко.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Какаов пудинг', N'Десерт', 20, 'Лесно', 3, N'Свари мляко със захар и какао, добави нишесте и вари до сгъстяване.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Мляко с ориз', N'Десерт', 40, 'Лесно', 3, N'Свари ориз с мляко и захар до сгъстяване.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'Чийзкейк', N'Десерт', 50, 'Средно', 3, N'Смеси бисквити с масло, отгоре крем със сирене. Охлади.');




--SELECT RecipeID,Name from Recipes 
--select IngredientID,Name from Ingredients

--PREDQSTIQ
INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values 
(1,12,N'2 броя'),
(1,14,N'1 брой'),
(1,24,N'1 брой'),
(1,19,N'100 грама'),
(1,8,N'1 с.л.'),
(1,9,N'1 ч.л.'),
(1,6,N'на вкус'),
(1,7,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(2,12,N'2 броя'),
(2,14,N'1 брой'),
(2,24,N'1 брой'),
(2,16,N'малка глава'),
(2,19,N'100 грама'),
(2,2,N'50 г.'),
(2,8,N'на вкус'),
(2,9,N'на вкус'),
(2,6,N'на вкус'),
(2,7,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(3,13,N'4 броя'),
(3,8,'500 мл.'),
(3,6,N'на вкус'),
(3,7,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(4,16,N'2 броя'),
(4,24,N'1 брой'),
(4,8,'500 мл.'),
(4,5,N'2 броя'),
(4,6,N'на вкус'),
(4,7,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(5,25,N'500 грама'),
(5,17,N'2 скилидки'),
(5,6,N'на вкус'),
(5,8,N'50 мл.')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(6,3,N'1 кг.'),
(6,22,N'2 л.'),
(6,17,N'2 скилидки'),
(6,10,N'на вкус'),
(6,5,N'2 броя'),
(6,6,N'на вкус'),
(6,9,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(7,2,N'1 бр.'),
(7,22,N'2 л.'),
(7,15,N'2 бр.'),
(7,4,N'1 чаша'),
(7,6,N'на вкус'),
(7,7,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(8,25,N'500 гр.'),
(8,22,N'1 чаша'),
(8,17,N'1 скилидка'),
(8,6,N'на вкус'),
(8,8,N'2 с.л.')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(9,16,N'1 глава'),
(9,13,N'2 бр.'),
(9,8,N'50 мл.'),
(9,27,N'1 л.'),
(9,26,N'100 мл.'),
(9,6,N'на вкус'),
(9,7,N'на вкус')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(10,23,N'500 гр.'),
(10,22,N'2 Л.'),
(10,16,N'1 глава'),
(10,15,N'2 бр.'),
(10,24,N'1 бр.'),
(10,6,N'на вкус'),
(10,7,N'на вкус')



--OSNOVNO
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(11, 2, N'300 г'),      
(11, 13, N'4 бр.'),     
(11, 6, N'на вкус'),    
(11, 7, N'на вкус'),    
(11, 8, N'2 с.л.'),     
(11, 1, N'100 мл.'),    
(11, 5, N'1 бр.');      

INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(12, 23, N'4 бр.'),      
(12, 4, N'100 г'),       
(12, 2, N'200 г'),       
(12, 15, N'1 бр.'),      
(12, 16, N'1 бр.'),      
(12, 6, N'на вкус'),     
(12, 7, N'на вкус'),     
(12, 27, N'1 ч.л.');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(13, 2, N'300 г'),       
(13, 4, N'150 г'),       
(13, 16, N'1 бр.'),      
(13, 15, N'1 бр.'),      
(13, 27, N'1 ч.л.'),     
(13, 21, N'500 мл.'),    
(13, 6, N'на вкус');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(14, 2, N'300 г'),      
(14, 13, N'2 бр.'),     
(14, 15, N'1 бр.'),     
(14, 16, N'1 бр.'),     
(14, 12, N'1 бр.'),     
(14, 6, N'на вкус'),    
(14, 27, N'на вкус');   
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(15, 13, N'4 бр.'),      
(15, 2, N'250 г'),       
(15, 5, N'2 бр.'),       
(15, 24, N'100 мл.'),    
(15, 6, N'на вкус'),     
(15, 7, N'на вкус');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(16, 13, N'3 бр.'),     
(16, 16, N'1 бр.'),     
(16, 15, N'1 бр.'),     
(16, 12, N'1 бр.'),     
(16, 27, N'на вкус'),   
(16, 6, N'на вкус');    
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(17, 2, N'300 г'),      
(17, 18, N'1/2 глава'), 
(17, 6, N'на вкус'),    
(17, 7, N'на вкус'),    
(17, 27, N'на вкус');   
--deserti
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(18, 1, N'500 мл.'),    
(18, 5, N'4 бр.'),      
(18, 6, N'щипка'),      
(18, 20, N'100 г');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(19, 19, N'1 пакет'),    
(19, 25, N'250 мл.'),    
(19, 1, N'50 мл.'),      
(19, 21, N'100 мл.'),    
(19, 6, N'на вкус'),     
(19, 20, N'2 с.л.'),     
(19, 22, N'1 с.л.');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(20, 19, N'1 пакет'),  
(20, 25, N'200 мл.'),  
(20, 1, N'200 мл.'),   
(20, 20, N'2 с.л.');   
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(21, 5, N'2 бр.'),     
(21, 1, N'300 мл.'),   
(21, 19, N'5 с.л.'),   
(21, 8, N'1 с.л.'),    
(21, 20, N'1 с.л.');   
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(22, 1, N'500 мл.'),     
(22, 20, N'3 с.л.'),     
(22, 22, N'2 с.л.'),     
(22, 19, N'1 с.л.');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(23, 1, N'500 мл.'),     
(23, 4, N'100 г'),       
(23, 20, N'2 с.л.'),     
(23, 6, N'щипка');       
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(24, 19, N'1 пакет'),   
(24, 8, N'100 г'),      
(24, 25, N'200 мл.'),   
(24, 18, N'100 г'),     
(24, 20, N'2 с.л.');    


select r.Name,r.Description,r.PreparationTime,r.Difficulty,c.Name,r.Instructions,i.Name,ri.Quantity from Recipes as r 
join RecipeIngredients as ri 
on r.RecipeID=ri.RecipeID
join Ingredients as i
on ri.IngredientID=i.IngredientID
join Categories as c
on c.CategoryID=r.CategoryID
order by r.CategoryID



select * from Categories
select * from Recipes
select * from Ingredients
select * from RecipeIngredients