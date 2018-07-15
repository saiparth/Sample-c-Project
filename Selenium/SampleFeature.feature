Feature: SampleFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: search text in google page
Given when I browse the "https://www.google.com/" URL
Then I should be on "Google" page
When I type "partha" in searchbox and press enter
Then I should be on "partha - Google Search" page
