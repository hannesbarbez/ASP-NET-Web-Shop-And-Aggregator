create table AggCategories
(
	cat_id int not null identity,
	cat_name varchar(40) not null,
	
	primary key(cat_id)
);

create table AggManufacters
(
	man_id int not null identity,
	man_name varchar(40) not null,
	
	primary key(man_id)
);

create table AggImages
(
	img_id int not null identity,
	img_large Varbinary(max) not null,
	img_medium Varbinary(max) not null,
	img_small Varbinary(max) not null,
	
	primary key (img_id)
);

create table AggProducts
(
	prod_id int not null identity,
	prod_name varchar(50) not null,
	img_id int not null,
	
	cat_id int,
	man_id int,
	
	cp_id int,
	uth_id int,
	xh_id int,
	
	primary key(prod_id),
	foreign key(img_id) references AggImages(img_id),
	foreign key(cat_id) references AggCategories(cat_id),
	foreign key(man_id) references AggManufacters(man_id)	
);