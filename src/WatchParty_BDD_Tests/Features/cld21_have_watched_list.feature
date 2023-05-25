@Emily
Feature: cld21_have_watched_list

This feature (cld-21) allows a logged in user to have all three watch lists, where they can add and deleted shows and movies.

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
Scenario: A logged in user can navigate to their watchlist page
	Given I am a user with first name '<FirstName>'
	When I login
	And I click on the watchlist button
	Then I should be on my watchlist page
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |

@LoggedIn
Scenario: A user can add a show to their watch lists
	Given I am a user with first name '<FirstName>'
	When I login
	And I search for "The Mandalorian"
	And I add it to my watchlist
	Then I should see the show in my watchlist
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |


@LoggedIn
Scenario: A user can change to display the have watched list
	Given I am a user with first name '<FirstName>'
	When I login
	And I search for "The last of us"
	And I add it to my have watched list
	And I click on the watchlist button
	And I click on the have watched list button
	Then I should see my have watched list
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |
	| Hareem    | Home |
	| Krzysztof | Home |

