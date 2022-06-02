Feature: ManageListingsFeatureFile

Manage Listings Feature helps Edit, Delete or View all ShareSkill listings

@tag1
Scenario: MLTCS_001_01 Check If the user is able to click on "ManageListing" 
	Given User should be able to Login application
	When  User should be able to Click on Manage Listing
	Then User should be able to navigate ManageListing page
	
@tag1
Scenario Outline:  MLTCS_001_02 Check if the user is able to "View" the share skill 
	Given User should be able to navigate ManageListing page 
	When  User should be able to Click on View Listing icon of <"Rownumber">
	Then User should be able to view all the information of the selected ShareSkill Listing

	Examples: 
	| Rownumber |
	|           |

@tag1
Scenario: MLTCS_001_03 Check if the user is able to "Edit" the shareSkill
	Given User should be able to navigate ManageListing page 
	When  User should be able to Click on Edit Listing icon  of <"Rownumber">
	Then  User should be able to Edit  the information of the selected skill
	Examples: 
	| Rownumber |
	|           |


@tag1
Scenario: MLTCS_001_04 Check if the user is able to "delete" the shareSkill
	Given User should be able to navigate ManageListing page 
	When  User should be able to Click on Delete Listing icon  of <"Rownumber">
	Then User should be able to Delete the selected skill
	Examples: 
	| Rownumber |
	|           |
