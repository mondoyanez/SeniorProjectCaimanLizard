﻿@Armando_Yanez
Feature: Create Posts
**As a user I would like to be able to create a post so that I can review a show**

This feature ensures that users who have previously registered can sucessfully login and navigate to their feed where they will be
presented with a button that allows them to navigate to a page where they can create a post and then review and give their opion on
any given tv show or movie.

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

@CannotCreatePostVisitor
Scenario: Visitor cannot navigate to the create post page
	Given I am a visitor
	When I navigate to the "CreatePost" page
	Then The page title contains "Log in"

@SucessfullyAtPostPage
Scenario Outline: Existing user can navigate to create post page
	Given I am a user with first name '<FirstName>'
	When I login
		And I navigate to the "CreatePost" page
	Then The page title contains "Create Post - WatchParty"
	Examples:
	| FirstName | Page |
	| Talia     | Home |
	| Zayden    | Home |
	| Hareem    | Home |
	| Krzysztof | Home |