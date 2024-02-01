# Using the Development tools

The Goal of this particular chapter was to understand and get some knowledge
of the different tools that are given to us for ASP.NET Core development.

# Key Learning Points

1. Creating ASP.Net Project using the command line.
   Many templates are available with preset for asp.net development.
   You can list them with:

   ```
       dotnet new --list
   ```

   For creating a new project, the following set of commands is handy:

   ```
       // without the angle brackets
       dotnet new globaljson --sdk-version 6.0.100 --output <projectName>
       dotnet  new web --no-https --output <projectName> --framework net6.0
       dotnet new sln -o <solutionName>
       dotnet sln <solutionName> add <projectName>
   ```

2. Building an running projects.
   You can either run your projects using your IDE interface, or the command line:

   - first in **_launchSettings.json_** in the **Properties** folder, set the http port

   ```
       "applicationUrl": "http://localhost:5000" // Select the port you want to run your application on
   ```

   ```
       // cd to your 'project' folder
       dotnet build // To build the project
       dotnet run // to build and run
       dotnet watch // to use hot relead feature
   ```

3. Managing NuGet packages
   The **_dotnet add package_** is used to manage packages

   ```
       dotnet add package <packageName> --version <packageVersion>
   ```

   To list all the package installed to the current app:

   ```
       dotnet list package
   ```

   To remove a package:

   ```
       dotnet remove package <packageManage>
   ```

4. Managing Tool Packages
   Tool packages install commands that can be used from the command line to perform
   operations on .NET projects.

   ```
       dotnet tool uninstall --global <packageName> // Uninstall any previous version of the same package
       dotnet tool install --global <packageName> --version <packageVersion>
   ```

5. Managing client-side packages
   Client-side packages contain content that is delivered to the client. They are added to ASP.NET Core
   using **Library Manager (LibMan)** tool. To intall LibMan tool package:

   ```
       dotnet tool uninstall --global Microsoft.Web.LibrayManager.Cli
       dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version <packageVersion>
   ```

   Initialize a project using libman:

   ```
       libman init -p cdnjs
   ```

   cdnjs is a package provider or repository from which libman can download packages and is the most widely used.
