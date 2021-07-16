Feature: RestApi
	

@RestApi
Scenario: Perform the CURD opertions
	Given the rest api for post is ready
    When post the record with some details
    Then validate the success status OK
	And get the record with place id
	Then validate the address tweedy road from get response
	And the rest api for put is ready
	And update the address as Morgan road 
	Then validate the message Address successfully updated
	And get the record with place id
	Then validate the address Morgan road from get response
	And the rest api for delete is ready
	And delete the record with place id
	Then validate the delete success status as OK