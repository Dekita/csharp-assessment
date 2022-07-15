# Tests: 

## User Validation:
Function: UserValidator.CheckIfPasswordValid()
Reason: Invalid Data Test
Test Data: username: Dekita, password, askhbdhasbj
Expected Result: Invalid Attempt
Actual Result: As Expected

Function: Program.Main()
Reason: Ensure Attempt Limit Exits Program
Test Data: username: Dekita, password, askhbdhasbj
Expected Result: Invalid Attempt (exit after 3 incorrect)
Actual Result: As Expected

## Main Menu Loop:
Function: Program.RequestUserMenuChoice()
Reason: Invalid Menu Option Test
Test Data: -5, 8, ashdas
Expected Result: Display error, re-ask for option
Actual Result: As Expected

Function: Program.RunDemProgramLewp() && MenuFunkz.PerformReadAndDisplayFile()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 1
Expected Result: Display file data
Actual Result: As Expected

Function: Program.RunDemProgramLewp() && MenuFunkz.PerformSortAndPrintTimes()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 2
Expected Result: Sort data, then save output to file and print
Actual Result: As Expected

Function: Program.RunDemProgramLewp() && MenuFunkz.PerformFindPrintFastest()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 3
Expected Result: Display file data (fastest result only)
Actual Result: As Expected

Function: Program.RunDemProgramLewp() && MenuFunkz.PerformFindPrintSlowest()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 4
Expected Result: Display file data (slowest result only)
Actual Result: As Expected

Function: Program.RunDemProgramLewp() && MenuFunkz.PerformSearchForTimes()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 5
Expected Result: Ask user to input time, then find, print, save results
Actual Result: As Expected

Function: Program.RunDemProgramLewp() && MenuFunkz.PerformTimeOccurence()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 6
Expected Result: Ask user to input time, then find, print, save number of entries
Actual Result: As Expected

Function: Program.RunDemProgramLewp()
Reason: Ensuring Menu Option Functionality
Test Data: menu option 7
Expected Result: Exit program loop
Actual Result: As Expected

## Validator Class: 
Function: Validator.RequestUserCredentials()
Reason: Ensuring Correct Functionality
Expected Result: Request and store user credentials
Actual Result: As Expected

Function: Validator.CheckIfPasswordValid()
Reason: Ensuring Correct Functionality
Test Data: username: dekita, password: clyderunners
Expected Result: Return True
Actual Result: As Expected

Function: Validator.CheckIfPasswordValid()
Reason: Ensuring Correct Functionality
Test Data: username: dekita, password: blahblabh
Expected Result: Return False
Actual Result: As Expected

# Trace Table: (search algorithm)

Array: [1, 2, 3, 4, 5]
Searching for element index with value 4
|-------------------------------|
| index | value == 4 | returned |
|-------------------------------|
| 0     | false      | false    |
| 1     | false      | false    |
| 2     | false      | false    |
| 3     | true       | true     |
| 4     | n/a        | n/a      |
|-------------------------------|


# Trace Table: (min algorithm)

Array: [3, 2, 1, 2, 3]
Searching for element index with smallest value
Min value is set to element index 0's value before iteration
|-----------------------------------|
| index | value | value < min | min |
|-----------------------------------|
| 0     | 3     | false       | 3   |
| 1     | 2     | true        | 2   |
| 2     | 1     | true        | 1   |
| 3     | 2     | false       | 1   |
| 4     | 3     | false       | 1   |
|-----------------------------------|
Value returned is 1


# Trace Table: (max algorithm)

Array: [1, 2, 3, 2, 1, 4, 1]
Searching for element index with smallest value
Max value is set to element index 0's value before iteration
|-----------------------------------|
| index | value | value > max | max |
|-----------------------------------|
| 0     | 1     | false       | 1   |
| 1     | 2     | true        | 2   |
| 2     | 3     | true        | 3   |
| 3     | 2     | false       | 3   |
| 4     | 1     | false       | 3   |
| 5     | 4     | true        | 4   |
| 6     | 1     | false       | 4   |
|-----------------------------------|
Value returned is 4

# Trace Table Notes: 
Linear searches of an array only require the array be iterated over one time. Because of this, there is no repetition or additional loops shown. 