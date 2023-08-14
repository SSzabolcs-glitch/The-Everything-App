---
--- drop tables
---

-- DROP TABLE IF EXISTS customers;
-- DROP TABLE IF EXISTS admins;
-- DROP TABLE IF EXISTS orders;
-- DROP TABLE IF EXISTS order_items;
-- DROP TABLE IF EXISTS addresses;
-- DROP TABLE IF EXISTS goods;




CREATE TABLE customers (
                           customer_id INT PRIMARY KEY NOT NULL,
                           username VARCHAR(50) NOT NULL,
                           first_name VARCHAR(50) NOT NULL,
                           last_name VARCHAR(50) NOT NULL,
                           email VARCHAR(100) NOT NULL,
                           passphrase VARCHAR(50)
);

CREATE TABLE admins (
                        admin_id INT PRIMARY KEY NOT NULL,
                        username VARCHAR(50) NOT NULL,
                        first_name VARCHAR(50) NOT NULL,
                        last_name VARCHAR(50) NOT NULL,
                        email VARCHAR(100) NOT NULL,
                        passphrase VARCHAR(50)
);

CREATE TABLE addresses (
                           address_id INT PRIMARY KEY,
                           country VARCHAR(50) NOT NULL,
                           country_state VARCHAR(50),
                           postal_code INT,
                           street VARCHAR(100),
                           house_number INT,
                           others VARCHAR(100)
);

CREATE TABLE goods (
                       item_id INT PRIMARY KEY NOT NULL,
                       product_name VARCHAR(100) NOT NULL,
                       unit_price DECIMAL NOT NULL,
                       inventory DECIMAL
);

CREATE TABLE orders (
                        order_id INT PRIMARY KEY NOT NULL,
                        customer_id INT NOT NULL,
                        total_price DECIMAL NOT NULL,
                        shipping_address_id INT NOT NULL,
                        billing_address_id INT NOT NULL,
                        FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
                        FOREIGN KEY (shipping_address_id) REFERENCES addresses(address_id),
                        FOREIGN KEY (billing_address_id) REFERENCES addresses(address_id)
);

CREATE TABLE order_items (
                             order_item_id INT PRIMARY KEY,
                             order_id INT NOT NULL,
                             item_id INT NOT NULL,
                             quantity DECIMAL NOT NULL,
                             price DECIMAL,
                             total_price DECIMAL,
                             FOREIGN KEY (order_id) REFERENCES orders(order_id),
                             FOREIGN KEY (item_id) REFERENCES goods(item_id)
);

-- INSERT INTO customers (customer_id, username, first_name, last_name, email, passphrase)
-- VALUES
--     (1, 'John', 'John', 'Doe', 'john@example.com', 'john123');

-- INSERT INTO admins (admin_id, username, first_name, last_name, email, passphrase)
-- VALUES
--     (1, 'Admin', 'Admin', 'User', 'admin@example.com', 'admin');


-- INSERT INTO addresses (address_id, country, country_state, postal_code, street, house_number, others)
-- VALUES
--     (1, 'USA', 'California', 12345, 'Main St', 10, NULL),
--     (2, 'Canada', NULL, 54321, 'Maple Ave', 25, NULL);


-- INSERT INTO goods (item_id, product_name, unit_price, inventory)
-- VALUES
--     (1, 'Product A', 10.99, 100),
--     (2, 'Product B', 19.99, 50);

-- INSERT INTO order_items (order_item_id, order_id, item_id, quantity, price, total_price)
-- VALUES
--     (1, 1, 1, 2, 10.99, 21.98),
--     (2, 2, 2, 1, 19.99, 19.99),
--     (3, 3, 3, 3, 5.99, 17.97);

-- INSERT INTO orders (order_id, customer_id, item_id, quantity, price, total_price, shipping_address_id, billing_address_id)
-- VALUES
--     (1, 1, 1, 2, 10.99, 21.98, 1, 1),
--     (2, 2, 2, 1, 19.99, 19.99, 2, 2);
