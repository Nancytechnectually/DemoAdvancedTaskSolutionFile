Feature: SkillShare

Seller should be able to share his/her skill via "SkillShare" and
to do that he should be able to create, update, view and Delete the listing.


@tag1
Scenario: TCSS_001_01  Check if the user is able to "Add" the New Skill via "Skill Share" tab 
	Given User is able to Navigate to the Login page
	And  user is able to Check Listings already Added on manage Listings page
	And User is able to Click on Share Skill Tab
	When User is able to Add the Details of listing Successfully
	Then User is able to see the added Listing on Manage Listings page

@tag1
Scenario: TCSS_002_01 Check if the user is able to View Share Skill Listing which is Active on Manage Listings Page 
	Given User is able to Navigate to the Login page
	And User is able to Click on Manage Listings Tab
	When User should be able to click on view listing icon if listing is active
	Then User is able to see the Listing details

@tag1
Scenario: TCSS_002_02 Check if the user is able to "update" the Share Skill Listing on Manage Listings Page
	Given User is able to Navigate to the Login page
	And User is able to Click on Manage Listings Tab
	When User is able to click on update listing icon 
	And User should be able to update existing details of listing Successfully.
	Then User is able to see the updated Listing on Manage Listings page


@tag1
Scenario: TCSS_002_03  Check if the user is able to "Delete" the Share Skill Listing on Manage Listings Page
	Given User is able to Navigate to the Login page
	And User is able to Click on Manage Listings Tab
	When  User should be able to click on Delete listing icon
	Then Listing has been Deleted Successfully
	


