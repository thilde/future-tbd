# ![alt text][logo]

## Roster

Name              | Role
----------------- | -------------
Robert Johnson    | Product Owner
Mason Tan         | Scum Master
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
  - The development team committed to these stories during sprint planning
  
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
![alt text](https://github.com/thilde/future-tbd/blob/master/mob_programming_sprint_one.png "Mob Programming")


### Sprint Review
Halfway through our sprint, we conducted our first sprint review. Our stakeholder, Michael Johnson, was able to provide some early feedback on the product and the product design. Here are a couple of key events from sprint review: 
* The Development Team presented the first version of the website.
* Our stakeholder was pleased with the direction the product was headed. He noted that he wanted us to make sure were were focused on both college costs and college outcomes. 
* The Product Owner was satisfied with Development Team's progress on actualizing the user stories. 

## Sprint #2

### Forecast

- **15 story points** to be completed

  - We estimated a 2 story points per team member per week. The sum story points for the first sprint came up to 16 sp but we only loaded the first sprint with 14 sps.
  - The development team committed to these stories during sprint planning
  
### Burndown chart
The burndown chart can be found here https://BurndownForTrello.com/share/ud549bkub6

### Daily Scrums
During this sprint, our team conducted five scrums. Mason, our Scrum Master, began each scrum asking the Development Team members what they had been working on and what impediments they were facing. Here is an example of a daily scrum:

 * **What did you do in the last 24 hours that helped the Development Team meet the Sprint Goal?**
  * Khalid: I implemented API calls from the College Scorecard API. We can now search for a list of colleges in our web app.
  * Tyler: I worked on getting the continuous integration and continuous deployment systems running. 
  * Mason: I assisted Khalid with finding and implementing the proper API calls for our college search. 
  
 * **What will you do in the next 24 hours to help the Development Team meet the Sprint Goal?**
  * Khalid: I will add output pulled from the API for certain data regarding the colleges, such as size and acceptance rates. Additioanlly, I will add more tests to our test suite. 
  * Tyler: I will continue to work on our CI/CD tools. 
  * Mason: In the next 24 hours, I will continue to work with Khalid to implement our API calls. 

* **Do you see any impediment that prevents me or the Development Team from meeting the Sprint Goal?**
  * There was much concern over what CI and CD tools to use for this sprint cycle. Different systems were suggested, and we weighed the pros and cons of each. Certain team members had more experience with various platforms, and time considerations were also discussed. This was by far the biggest impediment that we faced during this sprint, but eventually consensus was reached. 
  
### Mob Programming
Here is a screenshot of one of our team's mob programming sessions.
![alt text](need screenshot here)

### Continuous Integration and Deployment


### Sprint Review
At the end of the sprint, we conducted our second sprint review. Our stakeholder, Michael Johnson, was again able to provide some early feedback on the website. Here are a couple of key events from sprint review: 
* The Development Team presented a new version of the website with searchable colleges. 
* Michael mentioned that he would liek to see either a calculation of college costs and/or a graphical representation on the website.
* The Product Owner was satisfied with Development Team's progress on actualizing the user stories. 

## URL to Product

[logo]: https://github.com/thilde/future-tbd/blob/master/logosmall.png?raw=true "future-tbd"

