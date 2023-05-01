@Emily
Feature: cld181_notifications

This feature (cld-181) allows a logged in user to have and delete notifications, accessed from the navbar.

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

#Given I am logged in, Then I should see a notification icon in the nav bar.
#
#Given I am logged in, When I click on the notification icon in the nav bar, Then I should be redirected to my notification page.
#
#Given I am a visitor, Then I should not see a notification icon.
#
#Given I am logged in, and I navigate to my notification page, then I should see all my notifications.
#
#Given I am logged in, and I navigate to my notification page, When I delete a notification, Then it should be deleted from the page and the database.

@LoggedIn
Scenario: A logged in user should see a notification icon in the nav bar
	Given I am a user with first name '<FirstName>'
	When I login
	Then I should see a link to the Notification page
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |


@LoggedIn
Scenario: An existing user can navigate to the notification page
	Given I am a user with first name '<FirstName>'
	When I login
	And I click on the notification bell
	Then The page title contains "Notifications"
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |


#Need to automatically add notifications to a user 

#@LoggedIn
#Scenario: A user with notifications can delete a notification
#	Given I am a user with first name '<FirstName>'
#	When I login
#	And I click on the notification bell
#	And I click delete for the first notification
#	Then the notification is deleted
#	Examples:
#	| FirstName | Page |
#	| Talia     | Home |

