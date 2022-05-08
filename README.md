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
- Create a file inside `.vscode` and name it `tasks.json` -> (task.json)[https://github.com/imaun/vscode-mutliple-project/blob/master/.vscode/tasks.json]
- Create another file inside `.vscode` and name it `launch.json` -> (launch.json)[https://github.com/imaun/vscode-mutliple-project/blob/master/.vscode/tasks.json]

For debugging .NET application we must install `omnisharp` plugin on vscode.

## Tasks
```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "build Lib",
            "command": "dotnet",
            "type": "shell",
            "args": [
                "build",
                "${workspaceFolder}/src/SampleProject.Lib"
            ],
            "problemMatcher": [
                "$msCompile"
            ],
            "presentation": {
                "reveal": "always"
            },
            "group": "build"
        },
        {
            "label": "build Api",
            "command": "dotnet",
            "type": "shell",
            "args": [
                "build",
                "${workspaceFolder}/src/SampleProject.Api"
            ],
            "problemMatcher": "$msCompile",
            "presentation": {
                "reveal": "always"
            },
            "group": "build"
        },
        {
            "label": "build Console",
            "command": "dotnet",
            "type": "shell",
            "args": [
                "build",
                "${workspaceFolder}/src/SampleProject.Console"
            ],
            "problemMatcher": "$msCompile",
            "presentation": {
                "reveal": "always"
            },
            "group": "build"
        }
    ]
}

```

## Launch
```json
{
    "configurations": [
    {
        "name": "Api",
        "type": "coreclr",
        "request": "launch",
        "preLaunchTask":  "build Api",
        "program": "${workspaceFolder}/src/SampleProject.Api/bin/Debug/net6.0/SampleProject.Api.dll",
        "args": [],
        "cwd": "${workspaceFolder}/src/SampleProject.Api",
        "stopAtEntry": false,
        "console": "externalTerminal"
    },
    {
        "name": "Console",
        "type": "coreclr",
        "request": "launch",
        "preLaunchTask": "build Console",
        "program": "${workspaceFolder}/src/SampleProject.Console/bin/Debug/net6.0/SampleProject.Console.dll",
        "args": [],
        "cwd": "${workspaceFolder}/src/SampleProject.Console",
        "stopAtEntry": false,
        "console": "integratedTerminal"
    }],
    "compounds": [
        {
            "name": "Debug All",
            "configurations": [
                "Api",
                "Console"
            ]
        }
    ]
}
```

