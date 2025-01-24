# PersonDetails_-.NET-and-SPA-

To pull the solution locally you can run git clone https://github.com/shadyyehia/PersonDetails_-.NET-and-SPA-.git

The application was containerized and you will need to have docker on your machine to run it.
Steps to launch the project:
1- Open cmd in the project folder location and type the command "docker-compose up --build" to start the containers in docker-compose file but to rebuild their images first.
2- To check the Backend API swagger https://localhost:2222/swagger
3- To check the Frontend page http://localhost:4444


The solution consists of three projects:
1- PersonDetails: the backend API, was created using ASP.NET Core web API.
PersonDetailsController is the main entry point.
Used appsettings.json for saving DB configurations.( CSV and MongoDB)
Added self-signed certificate cert.pfx to allow HTTPS over containers.

2- PersonDetails.Tests : this is xUnit project to test the backend API.

3- PersonDetailsUI: the frontend project, was implemented using ASP.NET Core Empty template, and added wwwroot to host a single HTML.

The HTML was designed using simple CSS styling and plain HTML using Fetch to pull data from the backend API.


The project was containerized into 3 containers : Backend , frontend and Mongo.
Mongo container has a configured healthy check to make sure that it should be able to recieve connections before starting the backendAPI container.

Design patterns used in Backend API:
Facade, Repository, UnitOfWork, Dependency Injection



  