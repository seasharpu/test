
```

# Clone the repository

# Restore dependencies and build
dotnet restore
dotnet build

# Run tests
cd opus
dotnet test

# Run the application
cd opus/task1
dotnet run

cd opus/task2api
dotnet run
Swagger documentation: localhost:port/swagger

# Navigate to the frontend directory
cd opus/task2frontend

# Install dependencies
npm install

# Build the frontend
npm run build

# run dev server
npm run dev


#Test calculator

Examples:
Empty string returns 0
More than 2 numbers gives error: invalid amount of arguments
1.1, 1.5 = 2.6
1, , 1 = error, missing number second position
-1,1,-5 = no negative numbers allowed [-1, -5]
```
