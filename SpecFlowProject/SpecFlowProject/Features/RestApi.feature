Feature: RestApi
	

@RestApi
Scenario: Perform the CURD opertions
	Given the rest api for post is ready
    When post the record with some details
    Then validate the success status OK
	And get the record with place id
	Then validate the house name Frontline houses from get response