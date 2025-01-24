<h1>PersonDetails: .NET and SPA Project</h1>
<p>
Welcome to the <b>PersonDetails</b> repository! This project combines a .NET Core Web API backend with a simple single-page application (SPA) frontend. The solution is fully containerized for seamless deployment and testing.
</p>

<hr/>

<h2>🔧 Getting Started</h2>

<h3>Clone the Repository</h3>
<p>To pull the solution locally, use the following command:</p>
<pre>
<code>git clone https://github.com/shadyyehia/PersonDetails_-.NET-and-SPA-.git</code>
</pre>

<h3>Prerequisites</h3>
<ul>
  <li>Ensure you have <b>Docker</b> installed on your machine.</li>
  <li>Ensure that Docker Compose is configured correctly.</li>
</ul>

<hr/>

<h2>🚀 Steps to Launch the Project</h2>
<ol>
  <li>
    Open a terminal in the project folder.
  </li>
  <li>
    Run the following command to build the images and start the containers:
    <pre><code>docker-compose up --build</code></pre>
    <p>This command ensures that all images are rebuilt before the containers are started.</p>
  </li>
  <li>
    Access the Backend API Swagger documentation:
    <a href="https://localhost:2222/swagger" target="_blank">https://localhost:2222/swagger</a>
  </li>
  <li>
    Access the Frontend page:
    <a href="http://localhost:4444" target="_blank">http://localhost:4444</a>
  </li>
</ol>

<hr/>

<h2>📂 Solution Structure</h2>
<p>The solution consists of three projects:</p>
<ol>
  <li>
    <b>PersonDetails:</b> The backend API, created using ASP.NET Core Web API.
    <ul>
      <li><b>PersonDetailsController:</b> The main entry point.</li>
      <li><b>Appsettings.json:</b> Contains DB configurations (CSV and MongoDB).</li>
      <li><b>cert.pfx:</b> A self-signed certificate to enable HTTPS in containers.</li>
    </ul>
  </li>
  <li>
    <b>PersonDetails.Tests:</b> An xUnit project to test the backend API.
  </li>
  <li>
    <b>PersonDetailsUI:</b> The frontend project, implemented using the ASP.NET Core Empty template.
    <ul>
      <li>Includes a <code>wwwroot</code> folder hosting a single HTML file.</li>
      <li>The HTML uses simple CSS styling and Fetch API to interact with the backend.</li>
    </ul>
  </li>
</ol>

<hr/>

<h2>📦 Containerization</h2>
<p>
The project is containerized into three containers ( services ):
</p>
<ul>
  <li><b>persondetails:</b> Hosts the backend API.</li>
  <li><b>persondetailsui:</b> Hosts the SPA.</li>
  <li><b>mongo:</b> Hosts mongoDB database. It includes a health check to ensure it is ready to accept connections before the backend API container starts.</li>
</ul>

<hr/>

<h2>🏗️ Design Patterns Used</h2>
<ul>
  <li>Facade</li>
  <li>Repository</li>
  <li>Unit of Work</li>
  <li>Dependency Injection</li>
</ul>

<hr/>

<p>Happy coding! 🎉</p>
