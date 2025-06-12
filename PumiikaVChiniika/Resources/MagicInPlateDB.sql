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
    Difficulty NVARCHAR(20) CHECK (Difficulty IN ('�����', '������', '������')),
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
values(N'���������')
insert into Categories(Name)
values(N'�������')
insert into Categories(Name)
values(N'������')

--select * from Categories


insert into Ingredients 
values(N'�����')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'������')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'���')
insert into Ingredients 
values(N'�. �����')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'�-���. �����')
insert into Ingredients 
values(N'���')
insert into Ingredients 
values(N'������')
insert into Ingredients 
values(N'�������')
insert into Ingredients 
values(N'����������')
insert into Ingredients 
values(N'�������')
insert into Ingredients 
values(N'���')
insert into Ingredients 
values(N'�����')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'������')
insert into Ingredients 
values(N'��������')
insert into Ingredients 
values(N'�����')
insert into Ingredients 
values(N'����')
insert into Ingredients 
values(N'���')
insert into Ingredients 
values(N'�����')
insert into Ingredients 
values(N'�. �����')
insert into Ingredients 
values(N'�������')
insert into Ingredients 
values(N'������')
INSERT into Ingredients
values(N'���������')
insert into Ingredients
values(N'������')

--select * from Ingredients

--PREDQSTIQ
insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������ ������', N'������', 10, '�����', 1, N'������ 2 ������, 1 ���������� � 1 ������� �����. ������ 100 � ������, �������� �� �������. �������� � 1 �.�. ����, 1 �.�. ����, ��� � ����� ����� �� ����. ��������� ����� � ��������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'�������� ������', N'������', 10, '�����', 1, N'������ 2 ������, 1 ����������, 1 ������� ����� � 1 ����� ����� ���. ������ 100 � ������ � 50 � ������ ���� (�� �����). �������� � ����, ����, ��� � ����� �����. ��������� � ��������!');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������� �������', N'�����', 15, '�����', 1, N'����� 4 ������� � �� ������ �� ����� �������. ������ ���� � ����� � �� ������� �� ��������. ������ �� ���� � ������ ����� �����. ���� �� �� �������� � ����� ��� �������� �� �������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���-���', N'�����', 10, '�����', 1, N'������ ��� � ����� � ����, ������ ������ � ��������� �� �����. ������ ���� � �� ������ ����� �����������. ������, ������ ������ �� �������. �������� ��� ��� � ����� �����. �������� �����!');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'�����', N'�����', 7, '�����', 1, N'����������� ��������� ���, ����� �� �������� �� 500 � ������ �����, 2 �������� �����, ��� �� ���� � ����� ����. ������ �������� �� ������� ����� �� ��������� ���� � �� ������� ��������. ���� �� �� ������� � �����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������', N'����', 180, '������', 1, N'������� 1 �� ������ � ��������� ���� 2-3 ����. ���� ���� ����� ��������� 2 �������� ����� � ������ �����. ��������� ��� �������� � �������� 2 ����, ���� � ���. ������ ��� 10 ������ � ���������� � ��� ������ �����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������� ����', N'����', 90, '������', 1, N'������ 1 ������� ���� � 2 ����� ���� �� 1 ���. �������� 2 �������, ����, ��� � ����� �����. ������ ������ ������, �� �������� � ������� � ������. ���������� � ��������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'�������', N'����', 10, '�����', 1, N'�������� 500 � ������ ����� � 1 ���� ������� ����. �������� 1 �������� �����, ��������, ��� �� ���� � 2 ������ ������ ����. ����������� ����� � ���������� � ������� ����� � ����� ��� �� ��������� �����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���� ����', N'����', 30, '������', 1, N'��������� 1 ����� ��� � 2 ������� � ����� �����. ������� � 1 ����� ���������� ������ � ������ 20 ������. ���� ���� ��������� ������ �� ������ ������������ ������������. �������� 100 �� �������, ��� � �����, � ������ ��� 5 ������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���', N'����', 180, '������', 1, N'������� 500 � ��� � ���� � �� ������ ����� 1 ���, ���� ����� ������� ������. ��������� 1 ����� ���, 2 ������� � 1 ������ �����. �������� ��� ����, ���, ����� ����� � ������� ����. ������ ��� 30 ������. ���������� � ������ ����� � ������.');




--OSNOVNI
INSERT INTO Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
VALUES(N'������� � ��������� ����', N'����� ����� � ���������', 40, '������', 2, N'����� ����� � ���������, ������ ������� � �� �������. ����� 4 �������, �������� � ����� � �����. �������� ��������� � ������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������� ����� � ���� � ����', N'�����', 60, '������', 2, N'����� ���� � �����, ���, ������ � ���������. ������� ����� � �� ���� 40 ���. �� 180�C.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���� � ����', N'�����', 70, '������', 2, N'������ ������� ���� � ��� � ������. ������ ����, ������, ��������� � ���� � ����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'�����', N'����� � ����', 90, '������', 2, N'������ ��������� � ����, �������� � ���� � ������ ��� 1.5 ����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������', N'�����', 80, '������', 2, N'������� ������� � �����, ������ � ����� ��� ���� �� ���� � ������ �����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'��������� �����', N'������ �����', 50, '�����', 2, N'������ ���, ������ �������, ������, ����� � ���������. ���� �� ��������.');

INSERT INTO Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
VALUES (N'���� � ����', N'�����', 120, '������', 2, N'������ ���� � ����, ������ ��������� � ���� �� ���� ���� 2 ����.');

--DESERTI

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���� �������', N'������', 60, '������', 3, N'������ ���� � ����� � �����. ������ � �������������� ����� � ���� �� ����� ����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'��������', N'������', 40, '������', 3, N'������� �������, ���� �� ���������� � ����. ������ � ������ � �����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���������� �����', N'������', 20, '�����', 3, N'������� �������� � ����. ������ � ���������� 2 ����.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'���������', N'������', 30, '�����', 3, N'�������� ����� �� ����, ����� � ������. ������� � �������� ��� ������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'������ ������', N'������', 20, '�����', 3, N'����� ����� ��� ����� � �����, ������ ������� � ���� �� ����������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'����� � ����', N'������', 40, '�����', 3, N'����� ���� � ����� � ����� �� ����������.');

insert into Recipes (Name, Description, PreparationTime, Difficulty, CategoryID, Instructions)
values (N'��������', N'������', 50, '������', 3, N'����� �������� � �����, ������ ���� ��� ������. ������.');




--SELECT RecipeID,Name from Recipes 
--select IngredientID,Name from Ingredients

--PREDQSTIQ
INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values 
(1,12,N'2 ����'),
(1,14,N'1 ����'),
(1,24,N'1 ����'),
(1,19,N'100 �����'),
(1,8,N'1 �.�.'),
(1,9,N'1 �.�.'),
(1,6,N'�� ����'),
(1,7,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(2,12,N'2 ����'),
(2,14,N'1 ����'),
(2,24,N'1 ����'),
(2,16,N'����� �����'),
(2,19,N'100 �����'),
(2,2,N'50 �.'),
(2,8,N'�� ����'),
(2,9,N'�� ����'),
(2,6,N'�� ����'),
(2,7,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(3,13,N'4 ����'),
(3,8,'500 ��.'),
(3,6,N'�� ����'),
(3,7,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(4,16,N'2 ����'),
(4,24,N'1 ����'),
(4,8,'500 ��.'),
(4,5,N'2 ����'),
(4,6,N'�� ����'),
(4,7,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(5,25,N'500 �����'),
(5,17,N'2 ��������'),
(5,6,N'�� ����'),
(5,8,N'50 ��.')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(6,3,N'1 ��.'),
(6,22,N'2 �.'),
(6,17,N'2 ��������'),
(6,10,N'�� ����'),
(6,5,N'2 ����'),
(6,6,N'�� ����'),
(6,9,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(7,2,N'1 ��.'),
(7,22,N'2 �.'),
(7,15,N'2 ��.'),
(7,4,N'1 ����'),
(7,6,N'�� ����'),
(7,7,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(8,25,N'500 ��.'),
(8,22,N'1 ����'),
(8,17,N'1 ��������'),
(8,6,N'�� ����'),
(8,8,N'2 �.�.')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(9,16,N'1 �����'),
(9,13,N'2 ��.'),
(9,8,N'50 ��.'),
(9,27,N'1 �.'),
(9,26,N'100 ��.'),
(9,6,N'�� ����'),
(9,7,N'�� ����')

INSERT INTO RecipeIngredients(RecipeID,IngredientID,Quantity)
values
(10,23,N'500 ��.'),
(10,22,N'2 �.'),
(10,16,N'1 �����'),
(10,15,N'2 ��.'),
(10,24,N'1 ��.'),
(10,6,N'�� ����'),
(10,7,N'�� ����')



--OSNOVNO
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(11, 2, N'300 �'),      
(11, 13, N'4 ��.'),     
(11, 6, N'�� ����'),    
(11, 7, N'�� ����'),    
(11, 8, N'2 �.�.'),     
(11, 1, N'100 ��.'),    
(11, 5, N'1 ��.');      

INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(12, 23, N'4 ��.'),      
(12, 4, N'100 �'),       
(12, 2, N'200 �'),       
(12, 15, N'1 ��.'),      
(12, 16, N'1 ��.'),      
(12, 6, N'�� ����'),     
(12, 7, N'�� ����'),     
(12, 27, N'1 �.�.');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(13, 2, N'300 �'),       
(13, 4, N'150 �'),       
(13, 16, N'1 ��.'),      
(13, 15, N'1 ��.'),      
(13, 27, N'1 �.�.'),     
(13, 21, N'500 ��.'),    
(13, 6, N'�� ����');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(14, 2, N'300 �'),      
(14, 13, N'2 ��.'),     
(14, 15, N'1 ��.'),     
(14, 16, N'1 ��.'),     
(14, 12, N'1 ��.'),     
(14, 6, N'�� ����'),    
(14, 27, N'�� ����');   
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(15, 13, N'4 ��.'),      
(15, 2, N'250 �'),       
(15, 5, N'2 ��.'),       
(15, 24, N'100 ��.'),    
(15, 6, N'�� ����'),     
(15, 7, N'�� ����');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(16, 13, N'3 ��.'),     
(16, 16, N'1 ��.'),     
(16, 15, N'1 ��.'),     
(16, 12, N'1 ��.'),     
(16, 27, N'�� ����'),   
(16, 6, N'�� ����');    
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(17, 2, N'300 �'),      
(17, 18, N'1/2 �����'), 
(17, 6, N'�� ����'),    
(17, 7, N'�� ����'),    
(17, 27, N'�� ����');   
--deserti
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(18, 1, N'500 ��.'),    
(18, 5, N'4 ��.'),      
(18, 6, N'�����'),      
(18, 20, N'100 �');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(19, 19, N'1 �����'),    
(19, 25, N'250 ��.'),    
(19, 1, N'50 ��.'),      
(19, 21, N'100 ��.'),    
(19, 6, N'�� ����'),     
(19, 20, N'2 �.�.'),     
(19, 22, N'1 �.�.');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(20, 19, N'1 �����'),  
(20, 25, N'200 ��.'),  
(20, 1, N'200 ��.'),   
(20, 20, N'2 �.�.');   
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(21, 5, N'2 ��.'),     
(21, 1, N'300 ��.'),   
(21, 19, N'5 �.�.'),   
(21, 8, N'1 �.�.'),    
(21, 20, N'1 �.�.');   
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(22, 1, N'500 ��.'),     
(22, 20, N'3 �.�.'),     
(22, 22, N'2 �.�.'),     
(22, 19, N'1 �.�.');     
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(23, 1, N'500 ��.'),     
(23, 4, N'100 �'),       
(23, 20, N'2 �.�.'),     
(23, 6, N'�����');       
INSERT INTO RecipeIngredients(RecipeID, IngredientID, Quantity)
VALUES
(24, 19, N'1 �����'),   
(24, 8, N'100 �'),      
(24, 25, N'200 ��.'),   
(24, 18, N'100 �'),     
(24, 20, N'2 �.�.');    


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