# vscode-mutliple-project
How to Build and Debug multiple .NET projects in Visual Studio Code (vscode)

Suppose we have mutliple projects with a structure like this :

```
- src
  - SampleProject.Api
    - SampleProject.Api.csproj
  - SampleProject.Console
    - SampleProject.Console.csproj
  - SampleProject.Lib
    - SampleProject.Lib.csproj
```

Note that we don't have a solution file here. But with a solution, it's not very different.

- Create a directory named `.vsocde` in your working directory root.
- Create a file inside `.vscode` and name it `tasks.json`
- Create another file inside `.vscode` and name it `launch.json`

