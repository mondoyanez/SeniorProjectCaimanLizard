@Nygel_Melchor
Feature: CLD82_PostLikes
**As a user I would like to list a post so that I can show my interest in it**

The user story adds another functionality to posts aside from comments. A user should be able to interact with an element
to “like” it and then see it update to reflect that it has been liked, as well as update the number of likes on the post. 

Background:
	Given the following users exist
	  | UserName   | Email                 | FirstName | LastName | Password |
	  | TaliaK     | knott@example.com     | Talia     | Knott    | ScotIs#1 |
	  | ZaydenC    | clark@example.com     | Zayden    | Clark    | ScotIs#1 |
	  | DavilaH    | hareem@example.com    | Hareem    | Davila   | ScotIs#1 |
	  | KrzysztofP | krzysztof@example.com | Krzysztof | Ponce    | ScotIs#1 |
	And the following users do not exist
	  | UserName | Email               | FirstName | LastName | Password  |
	  | AndreC   | colea@example.com   | Andre     | Cole     | 0a9dfi3.a |
	  | JoannaV  | valdezJ@example.com | Joanna    | Valdez   | d9u(*dsF4 |

@LoggedIn
Scenario Outline: Existing user can't like a post more than once
	Given I am a user with first name '<FirstName>'
		And I login
		And I navigate to the "Post" page
		And I like a post
	When I try to like the same post again
	Then the post is unliked
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |
	| Hareem    | Home |
	| Krzysztof | Home |

@LoggedIn
Scenario Outline: Upon liking a post, the user can see the number of likes increase by one
	Given I am a user with first name '<FirstName>'
		And I login
		And I navigate to the "Post" page
	When I like a post
	Then I can see its post likes increase by one
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |
	| Hareem    | Home |
	| Krzysztof | Home |

@LoggedIn
Scenario Outline: Upon liking a post, the user can see the post is liked
	Given I am a user with first name '<FirstName>'
		And I login
		And I navigate to the "Post" page
	When I like a post
	Then I can see the post is liked
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |
	| Hareem    | Home |
	| Krzysztof | Home |