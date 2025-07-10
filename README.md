# RealityTvBracket
The Reality TV Bracket application creates a league for friends to draft new players from their favorite reality television shows to collect points based on how long their draft picks stay in the competition. Think of shows like Survivor, Big Brother, or RuPaul's Drag Race where contestants are eliminated each week with the combination of popular fantasy sports leagues or basketball brackets.

## Setup and Running
### Requirements for Local Machine
Ensure [Git](https://git-scm.com/downloads), [C# SDK](https://dotnet.microsoft.com/en-us/download), and [npm](https://nodejs.org/en/download) are installed on local machine.

### Setup on Local Machine
Clone repository with `git clone https://github.com/abutlercei/RealityTvBracket.git` command. Navigate to folder within local machine.

### Running on Local Machine
Run on a local host by running `./start-dev.ps1` inside the GitHub repository folder.

## Overview of Expected Implementation
### Frontend
The application will use React to create a navigation menu with a home dashboard, a search function for the leagues, and a user profile section.
  #### Home Dashboard
  The home dashboard will be the landing page for the user and contains the user's total points and all pool and bracket entries made by the user.

  #### Search Function
  The search function allows for users to search for a league by the league name or the television show it takes contestants from. When the user clicks on a league, they will be able to see a list of members in the league and a leaderboard section for the league. The user also can highlight the host name by simply hovering over the hostname listed in the pool details section.

  #### User Profiles
  The user profile will give users the ability to edit their own profile and update any settings within the application. The user can also click on the View Membership button to view the leagues they have entered.

### Backend
The backend for the project will use .NET API layers and connect to a database. The API layers will likely include player data manipulation when user updates their profile, loading and scripting information on each league result, and profile authentication. The database will store information on each league and each player with two different types of tables for each.
