  Setting up the back-end application



Follow the steps in order to have a proper way of running the application.

1. Install docker
2. Add your windows account to docker-users group (try one of the options) :  
  
    option1) Run the commands in some admin terminal (CMD or PowerShell): net localgroup docker-users "<my-system-name>" /ADD 
  
    option2) Set up the account from Computer Management [https://icij.gitbook.io/datashare/faq-errors/you-are-not-allowed-to-use-docker-you-must-be-in-the-docker-users-group-.-what-should-i-do]

3. Sign out from your windows account and log in again in order for the docker-user to take effect.
4. Make docker-compose as your start-up project and run it.
5. Run swagger on browser [https://localhost:5001/swagger/index.html]

The application and the database are both running on docker.
----

Setting up the front-end application

Open the folder on CourseRegistration_App/course-register-app

1.npm install

2.npm start
