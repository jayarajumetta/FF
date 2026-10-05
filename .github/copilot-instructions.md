# Visual Studio synchronization

When a local Visual Studio instance is running, treat the solution currently open in Visual Studio as the source of truth.

- Resolve the active solution's full path through Visual Studio DTE before reading, editing, building, or running tests.
- Work only in the checkout containing that active solution. Never infer the checkout from the repository name, configured project, recent session, or another clone.
- If no solution is open, multiple Visual Studio instances make the target ambiguous, or DTE access fails, stop and ask the user to identify the intended solution.
- Before changing a file, protect unsaved Visual Studio editor content. Do not overwrite an unsaved buffer; ask the user to save it first.
- After changes, build or rebuild through the running Visual Studio instance and require `SolutionBuild.LastBuildInfo` to be `0`.
- Confirm the generated assembly or other requested output exists in the active checkout and that Git status is read from the same checkout.
- For project, solution, package, or generated-file changes, ensure Visual Studio reloads the affected project before considering the work complete.
- If the IDE cannot be synchronized, state that clearly instead of reporting success from only a separate command-line build.
