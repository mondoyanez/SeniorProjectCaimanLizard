@Emily
Feature: cld103_edit_profile

This feature (cld-103) allows a logged in user to edit their profile information.

Background:
	Given the following users exist
	  | UserName   | Email                 | FirstName | LastName | Password  |
	  | TaliaK     | knott@example.com     | Talia     | Knott    | Hello123# |
	And the following users do not exist
	  | UserName | Email               | FirstName | LastName | Password  |
	  | AndreC   | colea@example.com   | Andre     | Cole     | 0a9dfi3.a |
	  | JoannaV  | valdezJ@example.com | Joanna    | Valdez   | d9u(*dsF4 |


Scenario: Home page has title Watch Party
	Given I'm on the "Home" page
	Then the page title contains "Watch"


Scenario: Home page has link to login
	Given I'm on the "Home" page
	Then I should see a link to the Register page


#Scenario: Home page contains link to logged in user's profile
#	Given I'm on the "Home" page
#		And I login
#	Then I can see a link to the "Profile" page
#
#
#Scenario: A non registered user cannot log in
#	Given I am a user with first name "Joanna"
#		And I'm on the "Login" page
#	When I login
#	Then I should see a login error message

#
#Scenario: Profile page should contain button to edit profile
#	Given I login
#		And I am on the "Psrofile" page
#	Then I can see a button to edit my profile
#
#Scenario: Edit button on profile should create a modal
#	Given I'm on the "Profile" page
#	When I click on the "edit" button
#	Then I should see a modal
#
#Scenario: Editing the profile bio should change bio
#	Given I'm on the "Profile" page
#	When I click on the "edit" button
#		And I edit my bio
#		And I click the "update" button
#	Then I should see my bio has changed
