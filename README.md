# .Net Core Coding Test

## Car workshops

Write an .net core based application which allows to make an appointment in a car workshop. It is
not necessary to create a UI frontend. All Operations should be available over a Rest API. For the data
storage you can use a simple in memory storage (List, Dictionary etc.). But it should be easy to
replace the in-memory storage later with a real database. The following functions should be
available:
* Create a user with the following fields:
	* Username (unique)
	* Email (unique)
	* City
	* Postal code
	* Country
* Delete an existent user
* Create a car workshop with the following fields:
	* Company Name (unique)
	* Car trademarks specializes in (example BMW, VW)
	* City
	* Postal code
	* Country
* Delete an existent car workshop
* Search for all car workshop in a specific city
* Create an appointment between a user and a car workshop. An appointment should have
the following fields:
	* Username
	* Users car trademark
	* Company name
	* Date and time
* Change the date and time of an existent appointment
* Delete an existent appointment

Please use Git as VCS.