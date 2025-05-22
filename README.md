# RealityTvBracket
The Reality TV Bracket application creates a league for friends to draft new players from their favorite reality television shows to collect points based on how long their draft picks stay in the competition. Think of shows like Survivor, Big Brother, or RuPaul's Drag Race where contestants are eliminated each week with the combination of popular fantasy sports leagues or basketball brackets.

## Overview of Expected Implementation
### Frontend
The application will use React to create a navigation menu with a home dashboard, a search function for the leagues, and a user profile section.
  #### Home Dashboard
  The home dashboard will be the landing page for the user and contains sections of the user's joined leagues or newly created leagues if the user has not joined any leagues.

  #### Search Function
  The search function allows for users to search for a league by the league name or the television show it takes contestants from. When the user clicks on a league, they will be able to see a list of members in the league, contestants drafted to each player, a leaderboard section, adding members to the league, starting drafting or random assignment, and updating results for the league. The scope of the project may also include writing scripts for the leagues to updated based on when season Wikipedia updates eliminations.

  #### User Profiles
  The user profile will give users the ability to edit their own profile and update any settings within the application.

### Backend
The backend for the project will use .NET API layers and connect to a database. The API layers will likely include player data manipulation when user updates their profile, loading and scripting information on each league result, and profile authentication. The database will store information on each league and each player with two different types of tables for each.
