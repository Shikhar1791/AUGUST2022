Feature: TMFeature

A short summary of the feature

@tag1
Scenario: Create time and material record
	Given user logged into turnup portal successfully
	When  user navigate to Time and material page
	And   user create time and material record
	Then  record should be created successfully

Scenario Outline: Edit Time and Material record with Valid details
	Given  user logged into turnup portal successfully
	When user navigate to Time and material page 
	And  user update '<Description>','<Code>' and '<Price>' on existing time and material record
	Then record should have the updated'<Description>', '<Code>' and '<Price>'

Examples: 
| Description | Code    | Price	   |
| abc         | Shikhar | $100.00  |
| Pandey      | Life    | $200.00  |
| Updated     | Story   | $300.00  |