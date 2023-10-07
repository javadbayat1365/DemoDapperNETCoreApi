# DemoDapperNETApi

- Since we don’t have any kind of business logic, we are not creating a service layer to wrap up our repository layer. For this type of application, the service layer would just call repository methods and nothing more, adding an unnecessary level of complexity to the article. Of course, we always recommend using the service layer in larger-scale applications(but this is just a demo)
- It is for working with AutoMapper(ProjectTo) to return IQueryable to Controllers, in fact, we never have to send IQueryable to Controllers
