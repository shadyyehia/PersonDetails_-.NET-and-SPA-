# PersonDetails_-.NET-and-SPA-

To pull the solution locally you can run git clone https://github.com/shadyyehia/PersonDetails_-.NET-and-SPA-.git<br/>

The application was containerized and you will need to have docker on your machine to run it.<br/>
Steps to launch the project:<br/>
1- Open cmd in the project folder location and type the command "docker-compose up --build" to start the containers in docker-compose file but to rebuild their images first.<br/>
2- To check the Backend API swagger https://localhost:2222/swagger<br/>
3- To check the Frontend page http://localhost:4444<br/>


The solution consists of three projects:<br/>
1- PersonDetails: the backend API, was created using ASP.NET Core web API.<br/>
PersonDetailsController is the main entry point.<br/>
Appsettings.json for saving DB configurations.( CSV and MongoDB)<br/>
self-signed certificate cert.pfx to allow HTTPS over containers.<br/>

2- PersonDetails.Tests : this is xUnit project to test the backend API.<br/>

3- PersonDetailsUI: the frontend project, was implemented using ASP.NET Core Empty template, and added wwwroot to host a single HTML.<br/>

The HTML was designed using simple CSS styling and plain HTML using Fetch to pull data from the backend API.<br/>


The project was containerized into 3 containers : Backend , frontend and Mongo.<br/>
Mongo container has a configured healthy check to make sure that it should be able to recieve connections before starting the backendAPI container.<br/>

Design patterns used in Backend API:<br/>
Facade, Repository, UnitOfWork, Dependency Injection<br/>



  
