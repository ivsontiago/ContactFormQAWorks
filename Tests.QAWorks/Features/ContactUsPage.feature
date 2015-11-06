Feature: Contact Us Page
  As an end user
  I want a contact us page
  So that I can find out more about QAWorks exciting services

Background: 
   Given I am on the QAWorks Staging Site

Scenario: Valid Submission
    Then I should be able to contact QAWorks with the following information
	| name     | email                | message                                   |
	| j.Bloggs | j.Bloggs@qaworks.com | please contact me I want to find out more |

# Handling big tables can be complicated. A simpler way of using tables as an input is using Scenario Outline:
Scenario Outline: Valid Submission with message with special characters
	When I enter the name '<name>'
	And I enter the email '<email>'
	And I enter the message '<message>'
    Then I should be able to contact QAWorks
	Examples: 
	| name     | email			      | message								|
	| j.Bloggs | j.Bloggs@qaworks.com | @"$KUH% I*$)OFNlkfn$¹²³£¢¬§ªº°/?°₢" |

# Using the same structure as above, it is possible to have different Scenarios being testes with fewer lines of code.
# It can be useful to add a first column with the title to make the unit tests names easier to read on Test Explorer
Scenario Outline: Submission without mandatory fields
	When I enter the name '<name>'
	And I enter the email '<email>'
	And I enter the message '<message>'
    Then The '<missing field>' should show an '<error message>'
	Examples: 
	| missing field | name     | email                | message    | error message                |
	| name          |          | j.Bloggs@qaworks.com | contact me | Your name is required        |
	| email         | j.Bloggs |                      | contact me | An Email address is required |
	| message       | j.Bloggs | j.Bloggs@qaworks.com |            | Please type your message     |

# Outline can also be used for a single step:
Scenario Outline: Submission with invalid emails
	When I enter the name 'j.Bloggs'
	And I enter the message 'please contact me'
	And I enter the email '<invalidemail>'
	Examples: 
	| invalidemail    |
	| testt@@qaworks.com |
	| testtqaworks.com   |
	| testt@qaworkscom   |
	| @qaworks.com       |
	| testt@qaworks..com |
	| tes tt@qaworks.com |
	| tes(tt@qaworks.com |
    Then I should not be able to contact QAWorks

Scenario: Submit a long message
	When I enter the name 'j.Bloggs'
	And I enter the email 'j.Bloggs@qaworks.com'
	And I enter a message with 5000 characters
    Then I should be able to contact QAWorks

Scenario: Switch between fields after entering a wrong email
	When I click the email field
	And I enter the email 'wrong@@qaworks.com'
	And I click the name field
	Then The form should show the message "Invalid Email Address"