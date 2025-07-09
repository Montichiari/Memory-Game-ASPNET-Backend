# Memory Game ASP.NET Backend
This is the backend for the Memory Game app, built with ASP.NET Core and Entity Framework Core. It supports user login, saving games played on the Android app, and leaderboard functionality, backed by a MySQL database. Also has endpoints to register dummy users and create games for registered users.

## Setup Instructions
### 1. Clone the Repository
```bash
git clone https://github.com/your-repo/memory-game-backend.git
cd memory-game-backend
```
### 2. Setup MySQL via Docker
```
docker run --name mysql_container_memgame \
  -e MYSQL_ROOT_PASSWORD=rootpass \
  -e MYSQL_DATABASE=memory_game_db \
  -e MYSQL_USER=username \
  -e MYSQL_PASSWORD=password \
  -p 3308:3306 \
  -d mysql:8.0.41
```
### 3. Run from Visual Studio
API will be live on http://localhost:5167
