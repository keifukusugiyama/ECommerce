# E-Comerce
E-Commerce website that allows retailers to manage product stock, customers, and orders.

## Technologies used
- C#
- HTML
- CSS
- Bootstrap
- ASP.NET Core
- Entity Framework
- MySQL
- Linq

## Features
- View list of products and its stocks
![main page top](Screenshots/main.PNG)
- Last 3 recent orders
- Last 3 recently added new customers
![main page top](Screenshots/main2.PNG)
- Search/filter by product name
- Create new product data
![main page top](Screenshots/products.PNG)
- List of all customers and ability to delete them
- Search/ filter customer name
- Add new customer
![main page top](Screenshots/customers.PNG)
- Add new order linked to a product and a customer
- Reduce quantity of product stock by the ordered quantity
- List all the orders
- Search/ filter orders with any matching keyword
![main page top](Screenshots/orders.PNG)

## Database:
- Products: one to many with orders
- Customers: one to many with orders
- Orders: links many to many relationship between products and customers