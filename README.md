# Dapper + .Net Core

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/javadbayat1365/DemoDapperNETCoreApi">
    <img src="Images/fvasp109-svg.svg" alt="Logo" width="80" height="80">
  </a>

  <p align="center">
    <a href="https://github.com/javadbayat1365/DemoDapperNETCoreApi"><strong>Explore the docs »</strong></a>
  </p>
</div>

-  Dapper is an ORM (Object-Relational Mapper) or to be more precise a Micro ORM, which we can use to communicate with the database in our projects
-  Dapper has great performance because it doesn’t translate queries that we write in .NET to SQL. It is important to know that Dapper is SQL Injection safe because we can use parameterized queries, and that’s something we should always do

- Since we don’t have any kind of business logic, we are not creating a service layer to wrap up our repository layer. For this type of application, the service layer would just call repository methods and nothing more, adding an unnecessary level of complexity to the article. Of course, we always recommend using the service layer in larger-scale applications(but this is just a demo)
- It is for working with AutoMapper(ProjectTo) to return IQueryable to Controllers, in fact, we never have to send IQueryable to Controllers


