API_PROJECT_PATH=./src/Meetopia.Api
INFRASTRUCTURE_PROJECT_PATH=./src/Meetopia.Infrastructure

migrations-add:
	dotnet ef migrations add $(name) -p $(INFRASTRUCTURE_PROJECT_PATH) -s $(API_PROJECT_PATH)

database-update:
	dotnet ef database update -p $(INFRASTRUCTURE_PROJECT_PATH) -s $(API_PROJECT_PATH)

database-drop:
	dotnet ef database drop -p $(INFRASTRUCTURE_PROJECT_PATH) -s $(API_PROJECT_PATH)
