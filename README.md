# Monona

Monona is a simple inventory system built on ASP.Net Core, Entity Framework Core, and AutoMapper.

## Getting Started

After downloading the project files from Git, these are the steps to get you up and running in Visual Studio:

1. Set **Monona.Web** as the Startup Project
   
2. Make a copy of **appsettings.sample.json** and rename it to **appsettings.json**. The appsettings.json file is explicitly excluded from source control to prevent accidental upload of sensitive data to public repositories.

3. *(optional)* Update **appsettings.json** with any of your preferred settings (e.g. - the database name)

4. Go to the Package Manager Console, select **src\Monona.Data** as the Default project, then enter the command **update-database**. This will use Entity Framework migrations to generate the database.

5. Generated css and js files located in wwwroot are excluded from source control. We initially attached bindings to the configuration files so that they fired when the project was open. However, Node Package Manager (npm) would not complete downloading client dependencies before these tasks fired leading to incomplete css and script files. To manually build the generated for the first time:
   * Right-click on **bundleconfig.json**, select **Bundler & Minifier**, then click **Update Bundles**
   * Right-click on **compilerconfig.json**, select **Web Compiler**, then click **Re-compile all files**

## Project Layout

The Monona project is split up into four assemblies:

1. **Monona.Core**: Contains entities and core functionality such as common extension methods, exception, and pagination.

2. **Monona.Data**: Contains Entity Framework Core application context, configurations, and migrations.

3. **Monona.Services**: Contains services used to read, create, update, and delete entities.

4. **Monona.Web**: The application's user interface.

![Project Layout](data:image/png;base64,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)