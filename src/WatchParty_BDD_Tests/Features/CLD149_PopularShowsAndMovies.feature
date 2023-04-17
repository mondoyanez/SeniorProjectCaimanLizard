@Nygel_Melchor
Feature: CLD149_PopularShowsAndMovies
**As a user I want to see what shows and movies are popular so that I know what to watch next**

This feature ensures that users who have previously registered can sucessfully login and navigate to their feed where they will be
presented with a carousel that allows them to see the top 20 popular shows and movies.

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

Scenario Outline: Existing user can see carousel of popular shows
	Given I am a user with first name '<FirstName>'
	When I login
	Then I can see the "PopularShowsCarousel"

Scenario Outline: Existing user can see carousel of popular movies
	Given I am a user with first name '<FirstName>'
	When I login
	Then I can see the "PopularMoviesCarousel"

Scenario Outline: Existing user can see additional informaton on mouse hover for popular shows
	Given I am a user with first name '<FirstName>'
		And I login
	When I hover over the "PopularShowsCarousel"
	Then I can see the show description

Scenario Outline: Existing user can see additional informaton on mouse hover for popular movies
	Given I am a user with first name '<FirstName>'
		And I login
	When I hover over the "PopularMoviesCarousel"
	Then I can see the movie description
