# Employee API
This is a backend REST API that allows management of records for employees. 

## How to run locally
The application will run locally on your development machine within Visual Studio. The application has a stand alone SQL Lite database file included in the [Database](https://github.com/mmyo/EmployeeApi/tree/main/EmployeeApi/Database) directory. The database has been preloaded with test data:

<img width="629" alt="image" src="https://github.com/mmyo/EmployeeApi/assets/8795750/c74911a9-05ae-44fb-acfe-0776e2001c72">

Launching the application from Visual Studio will open up the Swagger page with supported endpoints:

<img width="591" alt="image" src="https://github.com/mmyo/EmployeeApi/assets/8795750/c0c1ff09-a0ff-4bcf-8c99-ee14cf217431">

## Data Model
Employee object:

```
{
    "id": 1,
    "firstName": "Homer",
    "lastName": "Simpson",
    "joinDate": "1999-01-01T00:00:00",
    "birthDate": "1956-05-12T00:00:00",
    "salary": 50000,
    "title": "Nuclear Safety Inspector",
    "department": "Springfield Power Plant"
}
```

## Employee Search

Title and Department search support partial matches. For example, searching for employees in "Springfield" department will return:

```
[
  {
    "id": 1,
    "firstName": "Homer",
    "lastName": "Simpson",
    "joinDate": "1999-01-01T00:00:00",
    "birthDate": "1956-05-12T00:00:00",
    "salary": 50000,
    "title": "Nuclear Safety Inspector",
    "department": "Springfield Power Plant"
  },
  {
    "id": 3,
    "firstName": "Bart",
    "lastName": "Simpson",
    "joinDate": "1999-01-03T00:00:00",
    "birthDate": "1979-12-17T00:00:00",
    "salary": 0,
    "title": "Student",
    "department": "Springfield Elementary"
  },
  {
    "id": 4,
    "firstName": "Lisa",
    "lastName": "Simpson",
    "joinDate": "1999-01-04T00:00:00",
    "birthDate": "1981-05-09T00:00:00",
    "salary": 0,
    "title": "Student",
    "department": "Springfield Elementary"
  }
]
```
