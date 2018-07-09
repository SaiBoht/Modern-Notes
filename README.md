# Modern-Notes
Local project
Install:
Open package Manager Console
Choose project RestfulAPI
Write the following:
	Enable-Migrations
	Add-Migration
	Update-Database 
by doing this the database should be made

As the ClientApplication communicates with the server through URL, 
it would be neccesary to change the URL in Repository.cs line 16 in
the clientApplication project to the URL you wish to run the restfulAPI client on.

Running:
To run the program you'll need to run both the ClientApplication project and the RestfulAPI project.
This is so that the client application can communicate with the RestfulAPI application and transfer data.


Tests:
You'll find all test in the UnitTest1.cs file in the UnitTestProject

Documentation:
you'll find the API documentation done by swagger
by running the restfulAPI client and going to ["insert_your_url"/swagger]
There will also be an PDF file attachment to view this data if you so wish.

