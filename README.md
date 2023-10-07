# Dapper + .Net Core

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Best-README-Template</h3>

  <p align="center">
    An awesome README template to jumpstart your projects!
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
  </p>
</div>

-  Dapper is an ORM (Object-Relational Mapper) or to be more precise a Micro ORM, which we can use to communicate with the database in our projects
-  Dapper has great performance because it doesn’t translate queries that we write in .NET to SQL. It is important to know that Dapper is SQL Injection safe because we can use parameterized queries, and that’s something we should always do

- Since we don’t have any kind of business logic, we are not creating a service layer to wrap up our repository layer. For this type of application, the service layer would just call repository methods and nothing more, adding an unnecessary level of complexity to the article. Of course, we always recommend using the service layer in larger-scale applications(but this is just a demo)
- It is for working with AutoMapper(ProjectTo) to return IQueryable to Controllers, in fact, we never have to send IQueryable to Controllers


