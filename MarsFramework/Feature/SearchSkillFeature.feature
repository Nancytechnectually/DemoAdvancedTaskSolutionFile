Feature: SearchSkillFeature

Search Skill Feature helps find listed Searchskill active Listings



@tag1
Scenario Outline: SSTCS_001_01(SelectAllCategory)Check if the user is able to search skill "by all category"
	Given User can click on search icon present on search skills textbox
	When User can  Click on any <Category> present on the left
	Then All skills related to the selected Category are displayed
	Examples: 
	
	| Category |
	|          |



@tag1
Scenario Outline: SSTCS_001_02(ClickBYCategory)Check if the user is able to click on the Skill which has the searched Category
	Given User can click on search icon present on search skills textbox
	When User can  Click on any <Category> present on the left
	When All skills related to the selected Category are displayed
	Then User clicked on the <Skill> and directed to Profile Page which has all the services listed by that user
	Examples: 
	
	| Category | Skill |

	|          |       |


@tag1
Scenario Outline: SSTCS_001_03(ServicesOnProfilePage)Check if the user is able to click on the Services present on his Profile Page
	Given User can click on search icon present on search skills textbox
	When  User clicked on the <Skill> and directed to Profile Page which has all the services listed by that user 
	When User can click on any service
	Then user should be directed to the Service detail page where he can request skill trade
	Examples: 
	| Skill |
	|       |


@tag1
Scenario Outline: SSTCS_001_04(SearchBySubCategory)Check if the user is able to search skill "by all sub-category"
	Given User can click on search icon present on search skills textbox
	When User can  Click on any <SubCategory> present on the left
	Then All skills related to the selected Sub-Category are displayed
	Examples: 
	
	| SubCategory |
	|             |

@tag1
Scenario: SSTCS_001_05(ClickBySubCategory)Check if the user is able to click on the displayed Skill which has the searched Category and Sub-category
	Given User can click on search icon present on search skills textbox
	When User can  Click on any <Sub-Category> present on the left
	When All skills related to the selected Category are displayed
	Then User clicked on the <Skill> and directed to Profile Page which has all the services listed by that user
	Examples: 
	
	| Sub-Category | Skill |
	|              |       |




@tag1
Scenario:SSTCS_002_01(filterRecords) Check if user is able to filter records 

	Given User can click on search icon present on search skills textbox
	When User can  Select by clicking <Filter>  criteria
	Then When filter criteria is applied, the records should be displayed according to the filter criteria selected
	Examples: 
	
	| Filter |
	| Online |
	| Onsite |
	| ShowAll|

	

		
