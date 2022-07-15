# Project Overview:
Glasgow Clyde Runners Club would like a program that read from a data file and allows users to view/sort the data. The application should be password protected, robust, and lightweight. 

# Functional Requirements: 
(Any requirement which specifies what the system should do)
user login with password protection
load data from a text file
read and display file contents
sort / search / find data entries
search count for similar entries

# Non-Functional Requirements: 
(Any requirement that specifies how the system performs a certain function)
Use standard algorithms for sort/search/count/min/max etc.
Records should be available individually and as an array. 

# Constraints: 
lightweight / able to run on potatos (old hardware)
to be written with c#


# Project Plan:
see project-plan.png for trello screenshot

## Analysis: 
Get Project Overview
Get Functional Requirements
Get Non-Functional Requirements
Establish Project Constraints
Create Design Document (this) 
Estimate Timescales
Update Timescales (after design finalized)

## Design: (loop until finalized)
Create storyboard/wireframe
Ensure design meets requirements
Validate design with client (pseudo)

## Main Tasks: 
User Validation / Limit:
- Request User Credentials
- Validate Credentials
- Limit Attempts

Main Menu Loop:
- Read & Display File
- Sort & Print Times
- Print Fastest Time
- Print Slowest Time
- Search For Time
- Time Occurrences
- Exit Program
- Loop

## Sub Tasks: 
User Creation:
- Create Class Module
- Make Comparible (for min/max etc)
- Format Print Data

Menu Option Functions: 
- Read Data From File
- Write String/Array To file
- Sort User Array By X
- Min/Max Algorithms
- Search/Find Specific Result
- Count Occurrence of Result

## Testing: 
User Validation
- Check invalid username/password
- Ensure attempt limit exits program

Main Menu Loop
- Invalid Menu Options (numbers/letters)
- Menu Option 1 (Read & Display File)
- Menu Option 2 (Sort & Print Times)
- Menu Option 3 (Find & Print Fastest time)
- Menu Option 4 (Find & Print Slowest Time)
- Menu Option 5 (Search)
- Menu Option 6 (Count Occurrences)
- Menu Option 7 (Exit Program)

## Evaluation:
Project Management
Requirements Report
Design
Code
Testing
Additional

## Timescales && Milestones: 
1 Hour - User Creation
1 Hour - User Validation
1 Hour - Main Menu Loop
3 Hour - Menu Option Functions

# Storyboard / Wireframe: 
Login Page:
|---------------------------------------------|
| Please Enter Username:                      |
| USER_INPUT_USERNAME                         |
| Please Enter Password:                      |
| USER_INPUT_PASSWORD                         |
| Logged in as: USER_INPUT_USERNAME           |
|                                             |
|                                             |
|---------------------------------------------|

Main Menu Page: 
|---------------------------------------------|
| 1- Read & Display file                      |
| 2- Sort & Print Times                       |
| 3- Find & Print Fastest Time                |
| 4- Find & Print Slowest Time                |
| 5- Search                                   |
| 6- Time Occurrences                         |
| 7- Exit Program                             |
|---------------------------------------------|

# Data Dictionary:
|------------------------------------------------------------------------------------|
| Name           | Object/Scope      | Data Type | Definition                        |
|------------------------------------------------------------------------------------|
| username       | NA/Main           | string    | the users username                |
| password       | NA/Main (w/loop)  | string    | the users password                |
|------------------------------------------------------------------------------------|
| known_password | Validator/private | string    | the known password to login       |
|------------------------------------------------------------------------------------|
| first_name     | RaceRunner/public | string    | the first name for race runner    |
| last_name      | RaceRunner/public | string    | the last name for race runner     |
| seconds        | RaceRunner/public | float     | the duration of runners race      |
|------------------------------------------------------------------------------------|
| main_filepath  | MenuFunkz/private | string    | the main result file filepath     |
| main_woutpath  | MenuFunkz/private | string    | the directory to output files     |
|------------------------------------------------------------------------------------|


# Pseudocode: 
Validate User: 
Begin Validation Loop: 
Ask user to input username
Ask user to input password
If username and password valid {
    Show Login Success
    Begin Main Menu
} else {
    Try Again (Return to Begin Validation Loop) - limit 3
    if attempt limit reached {
        Exit Program
    }
}

Begin Main Menu: 
Read file data into memory
Loop Main Menu Options Until Exit

Main Menu Options Loop: 
Ask user to select option
if Selected Option Invalid {
    return To Begin Menu Options Loop
}
Call selected option function
if can continue menu loop {
    return To Begin Menu Options Loop
}

Menu Option - Read & Display File:
Print entries data

Menu Option - Sort & Print Times: 
Sort data entries from slowest->fastest
Print entries data
Save data to file

Menu Option - Find & Print Fastest Time: 
Sort data entries from fastest->slowest
Print fastest entry data
Save data to file

Menu Option - Find & Print Slowest Time: 
Sort data entries from slowest->fastest
Print slowest entry data
Save data to file

Menu Option - Search: 
Ask user to input time (in seconds - float)
Search data entries for results faster or equal to input time
Print entries datas (equal to or faster than input time)
Save data to file

Menu Option - Time Occurences: 
Ask user to input time (in seconds - float)
Search data entries for results equal to input time
Print Number of entries
Save data to file

Menu Option - Exit Program:
Ask user to confirm exit
Stop processing

# Test Plan: 
see test-plan.md
