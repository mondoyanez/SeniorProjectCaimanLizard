@Armando_Yanez
@LoggedIn
Feature: CLD199_RemoveUserWatchParty
**As a user, I would like the ability to remove users' from my Watch Party Group if I add someone to my group by mistake of
decide I don't want them attending the Watch Party.**

This feature will allow the host to be able to remove a pre-existing user from the already existing watch party from the group,
but host will not be able to remove themselves from the watch party group.

Background:
	Given the following users exist
	  | UserName   | Email                 | FirstName | LastName | Password |
	  | TaliaK     | knott@example.com     | Talia     | Knott    | ScotIs#1 |
	  | ZaydenC    | clark@example.com     | Zayden    | Clark    | ScotIs#1 |
	  | DavilaH    | hareem@example.com    | Hareem    | Davila   | ScotIs#1 |
	  | KrzysztofP | krzysztof@example.com | Krzysztof | Ponce    | ScotIs#1 |

Scenario Outline: Users can navigate to Sandra Hart's Watch Party Details page
	Given I am a user with first name '<FirstName>'
	When I login
		And I navigate to the "ExistingWatchParty" page
	Then The page title contains "Group Details"
	Examples:
	| FirstName |
	| Talia     |
	| Zayden    |
	| Hareem    |
	| Krzysztof |

Scenario Outline: Users cannot remove other users from Sandra Hart's Watch Party
	Given I am a user with first name '<FirstName>'
	When I login
		And I navigate to the "ExistingWatchParty" page
	Then I should not see the group options button
	Examples:
	| FirstName |
	| Talia     |
	| Zayden    |
	| Hareem    |
	| Krzysztof |
