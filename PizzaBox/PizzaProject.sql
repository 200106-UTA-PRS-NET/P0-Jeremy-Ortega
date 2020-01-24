-- create database PizzaProject;


------------- (DDL) Data Definition Language --------------------

use PizzaProject;

 ------- Table for customers -----------
 create table Customer(
 	Id int not null,
	fname varchar(max) not null,
	lname varchar(max) not null,
	email varchar(max) not null,
	UserPass varchar(max) not null,
	phone bigint check (phone>999999999 and phone<100000000000),
	Primary key(Id), 
 )
 ------- Table for Store Locations -------
 create table Store(
	Id int not null,
	storeLocation varchar(max) not null,
	storeName varchar(max) not null,
	Primary key(Id), 
 )
 ----- create table for pizza orders -----
 create table CxOrder(
	OrderID int not null,
	Cust_Id int not null,
	Store_Id int not null,
	Price decimal (5, 2) not null,
	OrderDate DateTime default (getdate()),
	FOREIGN KEY (Store_Id) references Store(Id),
	FOREIGN KEY (Cust_Id) references Customer(Id),
	Primary key (OrderID)
 )
 ------ create table for pizza ------------
 create table Pizza(
	PizzaID int not null,
	OrderID int not null,
	toppings int not null,
	crust varchar(max) not null,
	size int not null,
	Price decimal(5,2) not null,
	FOREIGN KEY (OrderID) references CxOrder(OrderID),
	Primary key (PizzaID)
 )
 ------ 
 

----------- (DML) Data Manipulation Language ---------------------

 ------ CUSTOMER: Insertion [fname:varchar, lname:varchar, phone:int]----------
 insert into Customer(Id, email, UserPass, fname, lname, phone) values (1000000001, 'a@a.com', 1, 'Jimmy', 'Johns', 1777777777);
 insert into Customer(Id, email, UserPass, fname, lname, phone) values (1000000002, 'b@b.com', 1, 'Luke', 'Skywalker', 1333333333);
 insert into Customer(Id, email, UserPass, fname, lname, phone) values (1000000003, 'c@c.com', 1, 'Spongebob', 'Squarepants', 1555555551);---
 insert into Customer(Id, email, UserPass, fname, lname, phone) values (1000000004, 'd@d.com', 1, 'Saul', 'Goodman', 1111111111);
 insert into Customer(Id, email, UserPass, fname, lname, phone) values (1000000005, 'e@e.com', 1,'Radical', 'Ed', 1333333333);
 insert into Customer(Id, email, UserPass, fname, lname, phone) values (1000000006, 'f@f.com', 1, 'Tony', 'Stark', 1555555555);


------- STORE: Insertion [storeLocation:varchar, storeName:varchar] ---------------
 insert into Store(Id, storeLocation, storeName) values (1234567, '123 Mars Street', 'Outa this world Pizza');
 insert into Store(Id, storeLocation, storeName) values (7654321, '321 Nasa Road', 'Blast off Pizza');
 insert into Store(Id, storeLocation, storeName) values (1234321, 'P. Sherman 42 Wallabie Way', 'Pizza By The Sea');

 ------- PIZZA ORDER: Insertion --------------------------------------------------------
 ------- [Crust_Id:int, Top_Id:int, ------------------------------------------
 ------- Size_Id:int, Cust_Id:int, Store_Id:int]-----------------------------------
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111111,1000000001, 1234567, 300.01);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111112,1000000001, 1234567, 56.87);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111113,1000000002, 7654321, 46.99);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111114,1000000001, 1234567, 49.99);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111115,1000000003, 1234567, 34.76);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111116,1000000004, 1234321, 25.65);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111117,1000000004, 1234567, 19.98);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111118,1000000005, 7654321, 34.65);
insert into CxOrder(OrderID, Cust_Id, Store_Id, Price) values (1111111119,1000000006, 1234321, 119.76);

 ------- PIZZA : Insertion -------------------------------------------------------------
insert into Pizza(PizzaID, OrderId, toppings, crust, size, Price)
			values(10101010100, 1111111111, 12, 'thin', 12, 12.99);
			/*
insert into Pizza(PizzaID, OrderID, toppings, crust, size, Price)
			values(10010101000, 1111111111, 16, 'deepdish', 15, 15.75);
insert into Pizza(PizzaID, orderId, toppings, crust, size, Price)
			values(10000100000, 1111111114, 3, 'cheesecrust', 20, 16.32);
insert into Pizza(PizzaID,orderId, toppings, crust, size, Price)
			values(10000100010, 1111111117, 2, 'deepdish', 20, 17.28);
insert into Pizza(PizzaID, orderId, toppings, crust, size, Price)
			values(10000100002, 1111111119, 15, 'cheesecrust', 12, 54.32);
insert into Pizza(PizzaID, orderId, toppings, crust, size, Price)
			values(10000100030, 1111111115, 22, 'thin', 15, 44.46);
insert into Pizza(PizzaID, orderId, toppings, crust, size, Price)
			values(10000100040, 1111111118, 15, 'deepdish', 20, 27.80);
			*/

------------------- (DQL) Data Query Language -----------------------



 select * from Store
 select * from Customer
-- select * from CxOrder
 select * from Pizza

 Select * 
 From CxOrder
 Order By OrderDate desc
 

 select co.OrderDate
 from CxOrder as co, Customer as c, store as s
 where co.Cust_Id = c.Id and s.Id = Store_Id
 order by co.OrderDate desc;


 /*
drop table Pizza;
drop table CxOrder; -- needs to be deleted before trying to delete that which calls to it.
drop table Customer;
drop table Store;
*/
