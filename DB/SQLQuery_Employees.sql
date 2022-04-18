CREATE TABLE Departments
(
	[department_id]	[int]			IDENTITY primary key,
	[title]			[varchar] (50)  NULL,
	[head_id]		[int]			NULL,
	[d_address]	    [varchar] (100)	NULL,
	[phone]			[varchar] (20)  NULL
)

CREATE TABLE Employees
(
	[employee_id]	[int]			IDENTITY primary key,
	[first_name]	[varchar] (20)  NULL,
	[last_name]		[varchar] (20)  NULL,
	[age]			[int]		    NULL,
	[e_address]	    [varchar] (100) NULL,
	[photo_path]	[varchar] (200) NULL
)

CREATE TABLE DepartmentsEmployees
(
	[de_id]			[int] IDENTITY primary key,
    [department_id]	[int] REFERENCES Departments([department_id]),
    [employee_id]	[int] REFERENCES Employees([employee_id])
)


--CREATE TABLE DepartmentsEmployees
--(
--    [department_id]	[int],
--    [employee_id]	[int]

--	CONSTRAINT UPKCL_taind PRIMARY KEY CLUSTERED([department_id], [employee_id])
--)


select * from Departments
select * from Employees
select * from DepartmentsEmployees


delete from Departments
where [department_id] = 13

delete from Employees
where [employee_id] = 26


--Departments
insert into Departments([title], [head_id], [d_address], [phone]) values 
('Universal Music Group', 1111, 'USA, California', '+7-111-111-111')

insert into Departments([title], [head_id], [d_address], [phone]) values 
('Sony Music Entertainment', 2222, 'USA, New York', '+7-222-222-222')

insert into Departments([title], [head_id], [d_address], [phone]) values 
('Warner Music Group', 3333, 'USA, New York', '+7-333-333-333')


--Employees
insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Mariah', 'Carey', 52, 'USA, New York', 'Images\Employees\Mariah_Carey.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Miley', 'Cyrus', 28, 'USA, Tennessee', 'Images\Employees\Miley_Cyrus.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Ariana', 'Grande', 28, 'USA, Florida', 'Images\Employees\Ariana_Grande.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Alan', 'Walker', 24, 'England, Northampton', 'Images\Employees\Alan_Walker.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Avril', 'Lavigne', 37, 'Canada, Ontario', 'Images\Employees\Avril_Lavigne.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Britney', 'Spears', 39, 'USA, Mississippi', 'Images\Employees\Britney_Spears.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Bruno', 'Mars', 36, 'USA, Hawaii', 'Images\Employees\Bruno_Mars.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('Corey', 'Taylor', 47, 'USA, Iowa', 'Images\Employees\Corey_Taylor.jpg')

insert into Employees([first_name], [last_name], [age], [e_address], [photo_path]) values 
('David', 'Guetta', 53, 'France, Paris', 'Images\Employees\David_Guetta.jpg')


--DepartmentsEmployees
insert into DepartmentsEmployees values(1, 1)
insert into DepartmentsEmployees values(1, 2)
insert into DepartmentsEmployees values(1, 3)

insert into DepartmentsEmployees values(2, 4)
insert into DepartmentsEmployees values(2, 5)
insert into DepartmentsEmployees values(2, 6)

insert into DepartmentsEmployees values(3, 7)
insert into DepartmentsEmployees values(3, 8)
insert into DepartmentsEmployees values(3, 9)

--proc 1
create procedure delete_employees(@id int)
as
begin
	delete from employees where employee_id = @id
end

drop proc delete_employees

exec delete_employees '24'

--proc 2
create procedure delete_department(@id int)
as
begin
	delete from departments where department_id = @id
end

drop proc delete_department

exec delete_department '12'