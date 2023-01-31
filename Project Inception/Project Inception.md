Project Inception Worksheet
=====================================

## Summary of Our Approach to Software Development
The Team Caiman Lizard Project will be following the architecture style for ASP.NET Core, along with Agile principles. Our use of scrum will mean that we will build our software in a dynamic and iterative approach. We are choosing to work in sprints that will occur every 2 weeks, while having different meetings throughout. At the end of each sprint, our software will be updated and deployed to Azure. We will achieve this by using a few communication resources including Discord and Jira, which will give us the capabilities of working in an Agile environment.

## Initial Vision Discussion with Stakeholders
Our project is for individuals who are looking for an entertaining website to connect with their friends and community over TV shows and movies. The Social Watch Party is an application that allows users to watch shows simultaneously, without having to be in the same place. It also allows users to share what they are watching, their thoughts, and ratings for shows. Users will have a profile, where they can see their past watched shows, upcoming shows, and posts created. This feature benefits the entertainment of users and their ability to find new interesting shows on all streaming platforms. Unlike other movie platforms, Social Watch Party will have a major focus on the social media aspect, making it user friendly and more interactive, allowing the user to easily access information about shows and connect with their friends online, simultaneously. 

### Description of Clients/Users
    Users of our application will persist of... 
    1. People who watch tv shows and movies
    2. Users of streaming services
    3. Users of other social media platforms
    4. People who enjoy watching TV shows/movies with others

### List of Stakeholders and their Positions (if applicable)
    Who are they? Why are they a stakeholder?

## Initial Requirements Elaboration and Elicitation
###### Requirement #1 - Profile
The profile requirements goal is to have a profile page connected to each user. In this profile page there will be a friend list, liked shows and movies, and a list of their currently watching, have watched, and to be watched movies and shows. The profile will show some of the users information including, username, name, and profile picture. This is the main scope of the profile requirements. The limitations to this requirement is the login authentication and account creation. This will need to be manually entered for testing or created before the profile can accurately display information. We will need a database to store profile information. 

###### Requirement #2 - Main Page
The main page requirement will be the main content feed for the application. This page will show posts from friends, recommendations of shows, and a search bar to look for shows and movies in the database. The user will be able to like, comment, and reshare any public post. The user can also create posts on the main page, where they can write a review or rate a certain show. The recommendations of shows will come from friend posts or suggestions of popular shows from the database. The mind map shows the connections between items on the main page. The database of movies and shows will use the TMDB API. This requirement relys on the ability to create posts and profiles. 

###### Requirement #3 - Database Search
The database search requirement is located on the home page. From there a user is able to search for any movie, tv show, platform, or user. The movie and tv show database will be provided through the TMBD API, the user database will be created. Once the user has searched a query, there will be a list of results. The user can then choose a result and perform an action including, go to a profile, make a rating or review, add movie or show to a list, or see movies and shows from a provider. This search will be dependant on the capabilities of a search algorithm as well as our database. The search will also rely on when we create profiles for users.

###### Requirement #4 - Watch Party
The watch party requirement is where users are able to watch a show or movie with their friend, in an online setting at the same time. The functionality for this will be provided through the use of an API or chrome extension, which has yet to be decided. The user will be able to chat with their friends while watching a shared screen. Users will be able to invite their friends to their watch party through a link or invite request through the application. This requirementis still a work in progress.

### Elicitation Questions
    1. 
    2.
    3. ...

### Elicitation Interviews
    Transcript or summary of what was learned

### Other Elicitation Activities?
    As needed

## List of Needs and Features
    1. Recommendations for what shows/movies to watch
    2. Stay updated on latest shows/movies
    3. See what your friends are watching and recommending
    4. Watch shows/movies with friends at the same time in a different place
    5. Lists of watched, currently watching, and watch next movies and shows
    6. Reviewing and rating what you watch
    7. Up to date database of TV shows and movies


## Initial Modeling

### Use Case Diagrams
<img src="WatchPartyUseCase.png">

### Sequence Diagrams

### Other Modeling
<img src="Wireframes.jpg">

## Identify Non-Functional Requirements
    1. Dependencies:
        1. Visual Studio Community 2022 v.17.4.4
        2. Dotnet 7
        3. SQL Server 2022
    2. Website should load pages within 1 second, not including information attained from APIs
    3. Secure login and information storage, following best practices
    4. Compatability for windows, mac, and ios
    5. The system must perform without failure in 95 percent of use cases during a sprint
    6. User-friendly; users are able to learn the application in 5 minutes, users are satisfied with the design
    7. Follows all legal requirements for an application

## Identify Functional Requirements (In User Story Format)

E: Epic  
U: User Story  
T: Task  

7. [E] 
    1. [U]
        a. [T]
        b. [T]
    2. [U]
        a. [T]

## Initial Architecture Envisioning
<img src="ArchitectureDiagram.png">

## Agile Data Modeling
    Diagrams, SQL modeling (dbdiagram.io), UML diagrams

## Timeline and Release Plan
    Milestones have occured during the inception phase of this group project, occurring every Monday since January 16th. The
    first sprint will take place on Monday, February 20th. Sprints will have a duration of 14 days and will repeat until Western
    Oregon University's Academic Excellence Showcase (AES). Initially, releases will be fixed - with a transition to Continuous
    Integration and Continuous Deployment (CI/CD).