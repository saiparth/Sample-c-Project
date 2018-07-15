Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@nUnit
Scenario: Validation of messages for invalid input in sign up page
#this statment will browse the url and you can write switch statement based on user role
#admin means logins may change and you can pass admin key for switch statment and use this same method for lets say normal user as well
Given I browse the url for "admin" role
#Check that you have gone to correct page after browse using page title
Then I should be on "Online Lending Made Simple at Cash Central - CashCentral.com" page
When I click on "customer sign in page link" in login page
Then I should be on "Customer Login - Online Loans - Sign in to View or Make Changes to Your Account" page
Then I should be displayed with "Customer Sign In" element in sign in page
When I click on "Not a Customer? Apply Now!" in login page
Then I should be displayed with "CASH CENTRAL APPLICATION" element in sign in page
When I click on "Next button" in login page
Then I should be displayed with "The First Name field is required." error message for "first name" field
#next step validate the employment info element are not available along with validation messages for not filling text boxes
#Use assert IsFalse method to check
#Info to debug
#put debugger pointer in specflow step
#Press f11 ->you will be navigated inside method
#Press f10 to continue in same class
#Press f5 to naviagte to next debugger pointer
#Page factory in c# has been depricated hence i have given a workaround


