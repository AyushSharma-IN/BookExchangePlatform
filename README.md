## BookExchangePlatform
 An Online solution for book lovers who wish to exchange, lend, or borrow books on a larger scale. Traditional book exchanges, being limited to local swaps or personal lending, restrict users’ ability to explore a diverse range of books. This platform aims to create a community-driven, centralized exchange service with easy accessibility and robust functionality. By connecting book enthusiasts, the platform encourages sharing reading material, thereby promoting literacy and fostering a reading culture.

# Technologies Used
ASP.NET Core MVC: ASP.NET Core MVC is a framework for building scalable, maintainable web applications using the Model￾View-Controller (MVC) design pattern.
C#.NET: C# is a modern, object-oriented programming language developed by Microsoft for building a variety of applications.
Entity Framework Core: Entity Framework Core (EF Core) is an ORM (Object-Relational Mapper) that simplifies database interactions in .NET applications.
MS SQL Server: Microsoft SQL Server is a relational database management system (RDBMS) designed to store and retrieve data efficiently.

# How They Work Together
• ASP.NET Core MVC handles the web application’s frontend and backend logic.
• C# serves as the primary programming language.
• Entity Framework Core bridges the application and MS SQL Server, allowing you to manipulate database records using C# objects.
• MS SQL Server stores and manages the application’s data.

## Features
# User Profile and Authentication:
• User can securely register, log in, and manage their account. So that they can access and use the book exchange platform.
• The platform allow users to register with a valid email and password and some details.
• Users are able to log out from their account.
• Passwords is stored securely using encryption.
• Users are able to reset their password via a password recovery system.
• Users are able change their email id with email changing system
• Users are able to manage their profile info like Full Name, Username, Favorite Genre and Phone No.
• Users are able to download their profile data.
• Users are able to delete their account permanently.

# Books:
• User can see list of books that they want to exchange or lend, So that others can browse and request the books I offer.
• Users are able to add a book to their list by providing details such as title, author, genre, condition, and availability status.
• Each book listing have a unique ID associated with a user’s profile.
• Users are able to edit or delete book listings at any time.
• The book listing are displayed in table form and are searchable.
• User can search for books based on criteria such as title, author, genre, availability, and Owner Name. So that I can easily find books that interest them. 
• The platform provide a search bar where users can enter keywords like title, author, or genre.
• The platform allow users to filter search results by availability status, genre, and Owner Name.
• Users are able to view detailed information about a book (title, author, condition, etc.) when clicking the link in row action on a search result table.
• The search results are paginated or load incrementally to handle large datasets.

# Exchange Requests:
• User can send and receive book exchange requests, So that they can initiate a transaction to exchange books with others.
• Users are able to send an exchange request to another user for a specific book.
• The request include the option to negotiate terms, such as delivery method and exchange duration.
• The recipient of the request are able to accept, reject the request.
• Both parties receive update about the status of the exchange request (pending, accepted, rejected).
• The platform track ongoing exchanges in the user's Exchnage Request history.
• User can manage their book exchanges, So that they can track the status of all their exchange transactions.
• Users are able to view a history of their exchange requests, including pending, accepted, and completed exchanges. 
• The transaction management interface allow users to cancel pending exchanges.



