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
	And  user update '<Description>' on existing time and material record
	Then record should have the updated'<Description>'

Examples: 
| Description |
| abc         |
| Pandey      |
| Updated     |
