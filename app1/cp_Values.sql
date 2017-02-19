insert into CpCategories(cat_name) values('Memory');
insert into CpCategories(cat_name) values('CPUs');
insert into CpCategories(cat_name) values('Harddisks');
insert into CpCategories(cat_name) values('GPUs');
insert into CpCategories(cat_name) values('Motherboards');

insert into CpCustomers(cust_city, cust_country_code, cust_name, cust_postalcode, cust_streetname, cust_streetnumber, cust_mail, cust_phone, cust_password)
values ('Antwerp', 56, 'Nog Een Gast', 8900, 'Random Street', 18, 'firstlastname@domain.com', '0123456789', 'Nog Een Gast')

insert into CpCustomers(cust_city, cust_country_code, cust_name, cust_postalcode, cust_streetname, cust_streetnumber, cust_mail, cust_phone, cust_password)
values ('Brussels', 56, 'Firstname LastName', 1600, 'Great Street', 56, 'firstlastname@mailinator.com', '0472345467', 'firstlastname')

insert into CpCustomers(cust_city, cust_country_code, cust_name, cust_postalcode, cust_streetname, cust_streetnumber, cust_mail, cust_phone, cust_password)
values ('Ghent', 56, 'Deze Kerel', 1500, 'Villalaan', 33, 'dezekerel@mailinator.com', '2313654987', 'dezekerel')

insert into CpCustomers(cust_city, cust_country_code, cust_name, cust_postalcode, cust_streetname, cust_streetnumber, cust_mail, cust_phone, cust_password)
values ('Gent', 56, 'Toffe Peer', 9000, 'Cool Street', 23, 'toffepeer@mailinator.com', '9876543210', 'toffepeer')

insert into CpManufacters(man_name)
values ('Gigabyte');

insert into CpManufacters(man_name)
values ('Sapphire');

insert into CpManufacters(man_name)
values ('Corsair');

insert into CpManufacters(man_name)
values ('AMD');

insert into CpManufacters(man_name)
values ('Intel');

insert into CpManufacters(man_name)
values ('Samsung');

insert into CpManufacters(man_name)
values ('Western Digital');

insert into CpManufacters(man_name)
values ('Asus');

insert into CpManufacters(man_name)
values ('MSI');

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (4, 'Radeon HD4550', 'GV-R455D3-512I HD4550', 'PCI-E 2.0, 512MB DDR3, DVI, HDMI, Passief', 46.90, 1, 46, 1);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (4, 'Radeon HD5850', 'GV-R585OC-1GD HD5850', 'PCI-E 2.0, 1GB DDR3, DVI, HDMI, Passief', 309, 1, 23, 2);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (4, 'Radeon HD4350', '11142-07-20R', 'PCI-E, 512MB DDR2, Dual DVI, HDMI, Passief', 36.90, 2, 0, 3);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (4, 'Radeon HD5550 Ultimate', '11170-14-20R', 'PCI-E 2.1, 1GB DDR2, 1*Dsub, 1*DVI, 1*HDMI, Passief', 70.90, 2, 30, 4);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (1, '2GB Kit XMS3 New Classic (2x1GB)', 'TW3X2G1333C9A', '1333MHz DDR3 PC3-10666 9-9-9-24', 59.9, 3, 0, 5);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (1, '4GB Kit XMS3 New Classic (2x2GB)', 'CMX4GX3M2A1600C9', '1600MHz DDR3 PC3-12800 9-9-9-24', 119.90, 3, 53, 6);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (1, 'TwinX 4GB Kit (2x2GB)', 'TW3X4G1333C9DHX', '1333MHz DDR3 PC3-10066 9-9-9-24 DHX', 109.90, 3, 4, 7);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (2, 'Phenom II X2 555 Black Edition', 'HDZ555WFGMBOX', 'AM3, 3.2Ghz Dual Core, 6MB Cache, 80W, Boxed', 109.90, 4, 23, 8);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (2, 'Phenom II X4 955 Black Edition', 'HDZ955FBGMBOX', 'AM3, 3.2GHz Quad Core, 7MB Cache, 125W, Boxed', 164.90, 4, 65, 9);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (2, 'Core i5-650', 'BX80616I5650', 'LGA1156, 3.2GHz, 4MB Cache, 733Mhz GPU, Boxed', 178.90, 5, 43, 10);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (2, 'Core i7-875K', 'BX80605I7875K', 'LGA1156, 2.93GHz, 8MB Cache, HT, Boxed', 338.90, 5, 23, 11);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (3, 'SpinPoint 320GB', 'HD322HJ', 'HD322HJ, 7200RPM, SATA 3Gb/s, 16MB', 45.90, 6, 32, 12);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (3, 'SpinPoint EcoGreen F2 1.5TB', 'HD154UI', 'HD154UI, 5400RPM, SATA 3Gb/s, 32MB', 76.90, 6, 0, 12);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (3, 'Caviar Black 640GB', 'WD6401AALS', 'WD6401AALS, 7200RPM, SATA 3Gb/s, 32MB', 65.90, 7, 34, 13);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (3, 'FlashSSD 64GB', 'MMCRE64G5MXP-OVB', '2.5", SSD, SATA-II, MLC',  159.90, 6, 12, 14);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (5, 'M4A785TD-V EVO/U3S6', '90-MIBAC5-G0EAY0KZ', 'AM3, AMD 785G, 4*DDR3, 2*PCIe x16, ATI Radeon HD4200, 5*SATA+*2 SATA 6GB/s, 1*eSATA, 2*Firewire, VGA, DVI, HDMI, 8ch Audio, Gigabit LAN, USB 3.0', 102.90, 8, 12, 15);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (5, 'M4A79T Deluxe/U3S6', '90-MIB7E5-G0EAY00Z', 'AM3, AMD 790FX, 2*PCI-E x16, 4*DDR3, 5*SATA+2*SATA 6GB/s, 1*eSATA, 2*Firewire, 8ch Audio, Gigabit LAN, USB 3.0', 196.90, 8, 34, 16);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (5, 'GA-880GM-UD2H', 'GA-880GM-UD2H', 'uATX, AM3, AMD880G+SB710, 4*DDR4, 5*SATA 3GB/s, eSATA, Radeon HD4250, VGA, DVI, HDMI, 8ch Audio, Gigabit LAN, Firewire', 82.90, 1, 20, 17);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (4, 'N470GTX-M2D12', 'V801-835R', 'PCI-E 2.0, 1.25GB GDDR5, 2*DVI, HDMI', 369, 9, 23, 18);

insert into CpProducts(cat_id, prod_name, prod_model, prod_desc, prod_price, man_id, prod_stock, img_id)
values (5, 'P55-CD53', '7586-010R', 'S1156, Intel P55, 4*DDR3, 1*PCI-E x16, 8*SATA, 8ch Audio, Dual Gigabit LAN', 106.9, 9, 12, 19);

insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (3, 6, 2, 1, 1, '2010-07-12');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (3, 7, 2, 1, 1, '2010-07-12');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (3, 8, 2, 1, 1, '2010-07-12');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (3, 9, 2, 1, 1, '2010-07-12');

insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (1, 6, 2, 1, 2, '2010-07-12');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (1, 2, 2, 1, 2, '2010-07-12');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (1, 1, 2, 1, 2, '2010-07-12');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (1, 13, 2, 1, 2, '2010-07-12');

insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (2, 6, 2, 1, 3, '2010-07-13');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (2, 2, 4, 1, 3, '2010-07-13');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (2, 1, 1, 1, 3, '2010-07-13');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (2, 13, 2, 1, 3, '2010-07-13');

insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (4, 4, 2, 1, 4, '2010-07-13');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (4, 6, 2, 1, 4, '2010-07-13');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (4, 13, 1, 1, 4, '2010-07-13');
insert into CpOrders(cust_id, prod_id, ord_quantity, ord_delivered, ord_code, ord_date)
values (4, 17, 2, 1, 4, '2010-07-13');