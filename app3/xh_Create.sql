create table XhCategories
(
	cat_id int not null identity,
	cat_name varchar(40) not null,
	
	primary key(cat_id)
);

create table XhCustomers
(
	cust_id int not null identity,
	cust_name varchar(90) not null,
	cust_streetname varchar(90) not null,
	cust_streetnumber int not null,
	cust_postalcode int not null,
	cust_city varchar(30) not null,
	cust_country_code int not null,
	cust_phone varchar(20),
	cust_mail varchar(100) not null,
	cust_password varchar(20) not null,
	
	primary key(cust_id)
);

create table XhManufacters
(
	man_id int not null identity,
	man_name varchar(40) not null,
	
	primary key(man_id)
);

create table XhImages
(
	img_id int not null identity,
	img_large Varbinary(max) not null,
	img_medium Varbinary(max) not null,
	img_small Varbinary(max) not null,
	
	primary key (img_id)
);

create table XhProducts
(
	prod_id int not null identity,
	prod_name varchar(50) not null,
	prod_desc text not null,
	prod_price float not null,
	prod_stock int not null,
	prod_model varchar(50) not null,
	img_id int not null,
	
	cat_id int,
	man_id int,
	
	primary key(prod_id),
	foreign key(img_id) references XhImages(img_id),
	foreign key(cat_id) references XhCategories(cat_id),
	foreign key(man_id) references XhManufacters(man_id)
);

create table XhOrders
(
	ord_id int not null identity,
	ord_quantity int not null,
	ord_delivered bit not null,
	ord_date date not null,
	ord_code int not null,
	
	cust_id int not null,
	prod_id int not null,
		
	primary key (ord_id),
	foreign key (cust_id) references XhCustomers(cust_id),
	foreign key (prod_id) references XhProducts(prod_id)
);
