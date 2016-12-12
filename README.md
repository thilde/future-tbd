# ![alt tag](https://github.com/thilde/future-tbd/blob/master/logosmall.png?raw=true)

## Roster

Name              | Role
----------------- | -------------
Robert Johnson    | Product Owner
Mason Tan         | Scum Master / Developer
Khalid Aliweh     | Developer
Tyler Hildebrandt | Developer

## Vision

### Far Term

Future TBD will be an online tool to help prospective students select college choices and career paths with financial concerns in mind. We will allow students to quickly and easily compare dozens of potential educational and career choices.

### Near Term

Our first iteration of the product will be a simple comparison site that will present information about costs of college and earning potentials between differing majors.

## Stakeholders

### Types

- **High School students** preparing to go to college

- **College students** considering transferring or switching majors

- **Post-grads** contemplating further schooling or a career change

### Real-Life Stakeholder

#### Michael Johnson

- **Age:** 21

- **Gender:** Male

- **Occupation:** TV Station Manager/Student

- **Location:** Hudson, NH

- **Goals**

  - Earn a four-year degree
  - Minimize cost incurred
  - Maximizing post-college earnings.

- **Frustrations**

  - Michael is having difficulty finding solid, accurate information on college costs.
  - Unsure which of his prospective majors has the most potential opportunity.

- **Bio:** Michael is a 21 year-old part-time community college student at Nashua Community College residing in Hudson, NH. He is the Assistant Manager for Hudson Public Access TV and hopes to pursue a career in communications or multimedia studies.

## Initial Product Backlog

Trello: [future-tbd](https://trello.com/b/uVkt6NXa/future-tbd)

### Ordering of Backlog Items

First, the backlog items are based on necessity in order to avoid blocking. In order to add functionality to the website, the website must be set up first. Then backlog items are sorted based on priority and functionality. The main functionality of the website is the ability to search and compare colleges.

1. Initial website setup
2. Import college list/data
3. Search
4. Compare
5. Cost and loan estimator
6. Create account (save work)

### Definition of Ready

- [ ] Title
- [ ] User story opening sentence
- [ ] Additional details
- [ ] Estimated in story points
- [ ] The acceptance criteria is clearly defined

### Estimating

The team completed a relative size estimating activity using [PlanITpoker](http://www.planitpoker.com/).

## Sprint #1

### Forecast

- **14 story points** to be completed

  - We estimated a 2 story points per team member per week. The sum story points for the first sprint came up to 16 sp but we only loaded the first sprint with 14 sps.
  - The development team committed to these stories during sprint planning.
  
### Burndown chart
The burndown chart can be found here https://BurndownForTrello.com/share/ud549bkub6

### Daily Scrums
During our first sprint, our team conducted four scrums. Mason, our Scrum Master, began each scrum asking the Development Team members what they had been working on and what impediments they were facing. Here is an example of a daily scrum: 

* **What did you do in the last 24 hours that helped the Development Team meet the Sprint Goal?**
  * Khalid: I committed the initial codebase for the product to github. Also, I created a test suite for the project. 
  * Tyler: I have created a logo for the Future TBD website, subject to the approval of the Product Owner. I also found a suitable API for usage for the project. 

* **What will you do in the next 24 hours to help the Development Team meet the Sprint Goal?**
  * Khalid: I will initiate our first mob programming for our assignment. Tyler and I will finish up the unit tests for the website. We will also add a BDD test to our test suite.
  * Tyler: I will upload the logo to the website. I will also assist Khalid in programming the website and tests. 

* **Do you see any impediment that prevents me or the Development Team from meeting the Sprint Goal?**
  * The biggest impediment expressed by both members of the Development Team was the data source that the team will be using for the project. Multiple ideas were suggested such as creating a back-end database using a .csv file or accessing an API. The team ultimately found an API from data.gov that was deemed suitable for usage in the project. 
  
### Mob Programming
Here is a screenshot of one of our team's mob programming sessions.
![alt text](https://slack-files.com/T26DTMQLE-F36PF1GEL-f3847b7270 "Mob Programming")


### Sprint Review
Halfway through our sprint, we conducted our first sprint review. Our stakeholder, Michael Johnson, was able to provide some early feedback on the product and the product design. Here are a couple of key events from sprint review: 
* The Development Team presented the first version of the website.
* Our stakeholder was pleased with the direction the product was headed. He noted that he wanted us to make sure were were focused on both college costs and college outcomes. 
* The Product Owner was satisfied with Development Team's progress on actualizing the user stories. 

## Sprint #2

### Forecast

- **15 story points** to be completed

  - Again, we estimated a 2 story points per team member per week. The sum story points for the first sprint came up to 16 sp but we only loaded the first sprint with 14 sps. Since we were able to complete 14 sps in the first sprint, we loaded the second sprint with 15 sps. 
  - The development team committed to these stories during sprint planning.
  
### Burndown chart
The burndown chart can be found here https://BurndownForTrello.com/share/ud549bkub6

### Daily Scrums
During this sprint, our team conducted five scrums. Mason, our Scrum Master, began each scrum asking the Development Team members what they had been working on and what impediments they were facing. Here is an example of a daily scrum:

 * **What did you do in the last 24 hours that helped the Development Team meet the Sprint Goal?**
  * Khalid: I implemented API calls from the College Scorecard API. We can now search for a list of colleges in our web app.
  * Tyler: I worked on getting the continuous integration and continuous deployment systems running. 
  * Mason: I assisted Khalid with finding and implementing the proper API calls for our college search. 
  
 * **What will you do in the next 24 hours to help the Development Team meet the Sprint Goal?**
  * Khalid: I will add output pulled from the API for certain data regarding the colleges to the website, such as size and acceptance rates. Additionally, I will add more tests to our test suite. 
  * Tyler: I will continue to configure our CI/CD tools to run a successful build. 
  * Mason: I will continue to work with Khalid to implement our API calls and tests. 

* **Do you see any impediment that prevents me or the Development Team from meeting the Sprint Goal?**
  * There was much concern over what CI and CD tools to use for this sprint cycle. Different systems were suggested, and we weighed the pros and cons of each. Certain team members had more experience with various platforms, and time considerations were also discussed. This was by far the biggest impediment that we faced during this sprint, but eventually consensus was reached. 
  
### Mob Programming
Here is a screenshot of one of our team's mob programming sessions.
![alt text](https://github.com/thilde/future-tbd/blob/master/mob_programming_sprint_two.png "Mob Programming 2")

### Continuous Integration and Deployment
After much research, we decided to use Microsoft's Visual Studio Team Services for our CI/CD implementation for the following reasons:

* Compatibility with Microsoft Azure and Visual Studio.
* Compatibility with Git.
* Agile tools included if needed.

The CI system automatically builds the code every time there is a merge to master and executes the tests upon each build. The 'Build.txt' log file is included in the repo to capture the build process. The CD system deploys the software to a stage environment where additional tests are being run and then deploys the software to a live production environment.

Here is a screenshot that summarizes our CI/CD processs using one of our builds/releases
![alt text](https://github.com/thilde/future-tbd/blob/master/CI:CD%20Summary.png "CICD Summary")

### Sprint Review
At the end of the sprint, we conducted our second sprint review. Our stakeholder, Michael Johnson, was again able to provide some feedback on the website. Here are a couple of key events from sprint review: 
* The Development Team presented a new version of the website with searchable colleges. 
* Michael mentioned that he would now like to see either a calculation of college costs and/or a graphical representation on the website.
* The Product Owner was satisfied with Development Team's progress on actualizing the user stories. 

## Sprint #3

### Forecast

- **21 story points** to be completed

  - For the final sprint, the development team decided that they would be able to handle a slightly larger work load due to availability in these two weeks.
  - Using Yesterday's Weather forecasting pattern, the number of story points completed in the last Sprint is 15. With the additional work load considered, the total story points come up to 21.
  - The development team committed to these stories during sprint planning.
  
### Burndown chart
The burndown chart can be found here https://BurndownForTrello.com/share/ud549bkub6

### Daily Scrums
During out final sprint, our team conducted six scrums. Mason, our Scrum Master, began each scrum asking the Development Team members what they had been working on and what impediments they were facing. Here is an example of a daily scrum:

 * **What did you do in the last 24 hours that helped the Development Team meet the Sprint Goal?**
  * Khalid: We implemented our compare functionality with a new view page on the website.
  * Tyler: I assisted Khalid in working on the comparison functionality.
  * Mason: I worked on adding test cases into our test suite.
  
 * **What will you do in the next 24 hours to help the Development Team meet the Sprint Goal?**
  * Khalid: I will continue to implement our comparison tool.
  * Tyler: I will help Khalid with said implementation.
  * Mason: I will add more test cases for our testing infrastructure.

* **Do you see any impediment that prevents me or the Development Team from meeting the Sprint Goal?**
  * A chief impediment for our website was deciding how exactly our compare functionality would work. We offered up different ideas and suggestions for how to show comparisons between colleges.

### Mob Programming
Here is a screenshot of one of our team's mob programming sessions.
![alt text](https://github.com/thilde/future-tbd/blob/master/mob_programming_sprint_three.png "Mob Programming 3")

### Continuous Integration and Deployment
We continued to use Microsoft's Visual Studio Team Services for this sprint.

The CI system automatically builds the code every time there is a merge to master and executes the tests upon each build. The 'Build 2.txt' log file is included in the repo to capture the build process. The CD system deploys the software to a stage environment where additional tests are being run and then deploys the software to a live production environment.

Here is another screenshot that summarizes our CI/CD processs using one of our builds/releases for this sprint.
![alt text](https://github.com/thilde/future-tbd/blob/master/CICD Summary 2.png "CICD Summary 2")

### Sprint Review
We will be holding our sprint review in our final class, on December 12th. We had a practice session for the sprint review on December 11th.

### Product
URL: http://future-tbd.com/

