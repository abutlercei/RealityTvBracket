# Runs on Windows machine with a cloned copy of GitHub repo open (https://github.com/abutlercei/RealityTvBracket.git)

# Open first terminal for npm (client folder)
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd ./client; npm install; npm run dev;"

# Open second terminal for dotnet (server folder)
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd ./server; dotnet restore; dotnet run;"