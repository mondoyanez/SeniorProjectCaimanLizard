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

Scenario Outline: Users creates a watch party and can see the group options button on the details page
	Given I am a user with first name '<FirstName>'
	When I login
		And I go to click on the create new watch party button
		And I enter "Movie night" for the watch party title
		And I enter "Join one join all" for the watch party description
		And I enter the watch party start date
		And I create the watch party
		And I go to the details page of the newly created watch party
	Then I should see the group options button
	Examples:
	| FirstName |
	| Talia     |
	| Zayden    |
	| Hareem    |
	| Krzysztof |

Scenario Outline: Users navigate to watch party details page and adds a user to the group
	Given I am a user with first name '<FirstName>'
	When I login
		And I go to the details page of the newly created watch party
		And I click on the group options button
		And I click on the add users button
		And I add "SandraHart" to the group
		And I close the open invite modal
	Then I should see that "SandraHart" was added to the group
	Examples:
	| FirstName |
	| Talia     |
	| Zayden    |
	| Hareem    |
	| Krzysztof |

Scenario Outline: Users navigate to watch party details page and removes a user from the group
	Given I am a user with first name '<FirstName>'
	When I login
		And I go to the details page of the newly created watch party
		And I click on the group options button
		And I click on the remove users button
		And I remove "SandraHart" from the group
		And I close the open remove modal
	Then I should not see that "SandraHart" is in the group
	Examples:
	| FirstName |
	| Talia     |
	| Zayden    |
	| Hareem    |
	| Krzysztof |