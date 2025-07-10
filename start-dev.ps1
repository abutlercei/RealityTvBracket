# Runs on Windows machine with a cloned copy of GitHub repo open (https://github.com/abutlercei/RealityTvBracket.git)

# Open first terminal for npm (react-app folder)
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd ./react-app; npm install; npm run dev;"

# Open second terminal for dotnet (DotNet folder)
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd ./DotNet; dotnet restore; dotnet run;"