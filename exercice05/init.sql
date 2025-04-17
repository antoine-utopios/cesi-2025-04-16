create database testdb;

use testdb;

create table dogs (
    id int auto_increment primary key,
    name varchar(255) not null,
    age int not null,
    breed varchar(255) not null
);  

insert into dogs (name, age, breed) values ('Buddy', 3, 'Golden Retriever');
insert into dogs (name, age, breed) values ('Max', 5, 'Bulldog');