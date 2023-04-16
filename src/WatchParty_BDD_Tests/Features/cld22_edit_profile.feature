Feature: cld22_edit_profile

This feature (cld-22) allows a logged in user to edit their profile information.

@Emily
Scenario: Home page contains link to logged in user's profile
	Given I'm on the "Home" page
	Then I can see a link to the "Profile" page

Scenario: Profile page should contain button to edit profile
	Given I'm on the "Profile" page
	Then I can see a butotn to edit my profile

Scenario: Edit button on profile should create a modal
	Given I'm on the "Profile" page
	When I click on the "edit" button
	Then I should see a modal

Scenario: Editing the profile bio should change bio
	Given I'm on the "Profile" page
	When I click on the "edit" button
		And I edit my bio
		And I click the "update" button
	Then I should see my bio has changed
