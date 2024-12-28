# Autokauppa API - CarDealership API

Car Dealerhip API is ASP.NET Core API where you can search, add, modify and delete sellers and their cars. Application uses Entity Framework core and Microsoft SQL Server to handle data.

Solution contains:
### Autokauppa API
- This is Swagger API part. There are two controllers: CarController and SellerController. Required endpoints can be found in these files.

### Autokauppa DAL
- This is data access layer. Here you can find two folders: CarRepository and SellerRepository. Inside of these folders are GET, POST, PUT and DELETE files that contains database logic for these operations. DBContext and migration files are also in this project.

### Autokauppa DAO
- Here you can find database objects and query objects. Query objects are simpler versions of database objects. They are used in API part to make API simpler. There is also Methods.cs file that contains shorthand versions of common null/empty list and whitespace string checks.

### Autokauppa Tests
- Here you can find unit tests for API and for data access object constructors.

## How to use
Simple logic is that there are sellers and they have cars they selling.
- Add new seller using Post/NewSeller endpoint.
- After that check with Get/AllSellers what is the id of the seller. You need this id in next step.
- Copy and paste SellerID and fill car information. Car is linked to the seller if data is valid.
- You can modify car and seller information in PUT methods. Data you give there will replace existing data.
- You can delete car or seller with its id. If you delete seller, it will delete cars linked to that seller also.
