@Emily
Feature: cld103_edit_profile

This feature (cld-103) allows a logged in user to edit their profile information.

Scenario: Home page has title Watch Party
	Given I'm on the "Home" page
	Then the page title contains "Watch"


Scenario: Home page has link to login
	Given I'm on the "Home" page
	Then I should see a link to the Register page


Scenario: Home page contains link to logged in user's profile
	Given I'm on the "Home" page
		And I am logged in
	Then I can see a link to the "Profile" page
#
#Scenario: Profile page should contain button to edit profile
#	Given I'm on the "Profile" page
#		And I am logged in
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
