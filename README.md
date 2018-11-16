<html>
    <p align="center">
        <img src="./Atarashii.png"/>
    </p>
    <h1 align="center">
        HCE Atarashii
    </h1>
    <p align="center">
        A reliable, reusable and versatile library for the HCE/SPV3 loader.
    </p>
</html>

# Introduction

Atarashii's goal is to cater to both end-users and developers. It accomplishes this using a versatile library and
command line interface (CLI). It is the result of learning from the mistakes of the SPV3 loader and installer.

By design, the library's APIs can be used outside of SPV3. The modules of this library are minimally tied to SPV3,
thereby allowing both SPV3 and HCE projects to rely on the functionality provided by the library and the CLI front-end.

## CLI Usage

The following table shows common tasks with their respective commands. 

| Task                              | Command                                   |
| --------------------------------- | ----------------------------------------- |
| Attempt HCE executable loading.   | `Loader Load "\path\to\haloce.exe"`       |
| Attempt HCE executable detection. | `Loader Detect`                           |
| Attempt HCE profile detection.    | `Profile Resolve "\path\to\lastprof.txt"` |
| Attempt HCE profile parsing.      | `Profile Parse "\path\to\blam.sav"`       |
| Attempt OpenSauce installation.   | `OpenSauce Install "\path\to\hce-dir"`    |

**Exit Codes**

| Code | Description                                                        |
| ---- | ------------------------------------------------------------------ |
| `0`  | Invoked command has been executed successfully.                    |
| `1`  | Not enough arguments have been provided for the specified command. |
| `2`  | Incorrect arguments have been provided to the specified command.   |
| `3`  | An exception has occurred when executing the invoked command.      |

**Notes**

- Due to its non-interactive nature, double clicking the executable will not execute anything meaningful!
  For example: `.\Atarashii.CLI.exe Loader Load "C:\haloce.exe"`.
- To use the CLI, you must run run it from an **existing** console: `\path\to\Atarashii.CLI.exe`!
- The syntax of the commands may change at any time for improved versatility & ease of use!
- The commands are currently CaSe SeNSiTiVE!

# API Usage

An API assembly is provided for convenience, to allow external assemblies to make use of the library's functionality.

The following table shows common tasks with the respective static methods that should be called. All methods are under
the `Atarashii.API` namespace.

| Task                              | Method                                          | Arguments                                                              | Return                                                                                                |
| --------------------------------- | ----------------------------------------------- | ---------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| Attempt HCE executable loading.   | `void Loader.Load(string hceExecutable)`        | `hceExecutable`: Absolute path to a valid HCE executable.              | ~                                                                                                     |
| Attempt HCE executable detection. | `string Loader.Detect()`                        | ~                                                                      | Path to the HCE executable, assuming its installation is legal.                                       |
| Attempt HCE profile detection.    | `string Profile.Detect()`                       | ~                                                                      | Currently used HCE profile, assuming the environment is valid.                                        |
| Attempt HCE profile parsing.      | `Profile.Configuration Parse(string blamPath)`  | `blamPath`: Path to a HCE profile blam.sav binary.                     | Deserialised `Profile.Configuration` object representing the provided blam.sav binary.                |
| Attempt OpenSauce installation.   | `void Install(string hcePath)`                  | `hcePath`: Valid HCE installation directory.                           | ~                                                                                                     |
| Attempt OpenSauce XML parsing.    | `OpenSauce.Configuration Parse(string xmlPath)` | `xmlPath`: Absolute path to the OpenSauce User configuration XML file. | Deserialised `OpenSauce.Configuration` object representing the OpenSauce User configuration XML file. |

# About

Atarashii's design consists of one library that contains the logic for all of the project's features and abilities.
At the moment, the project provides the following features:

- secure loading of the HCE executable, by verifying the executable and loading it if it passes the validation checks;
- detection of a legally installed HCE executable on the filesystem using various fallback detection mechanisms;
- determining the currently used HCE profile, thereby allowing automatic integration with the HCE profile;
- parsing & configuration of the HCE profile, including player name/colour and video/audio/network settings;
- installation and configuration of the OpenSauce mod, with a balance between safety and flexibility.

The architecture balances between maintainability and versatility. The library offers two high level namespaces:
 
| Namespace | Description                                                                                      |
| --------- | ------------------------------------------------------------------------------------------------ |
| `Common`  | Generic core types or abstracts that are either inheritable or merely share reusable code.       |
| `Modules` | APIs that focus on functionality or serving as object representations of HCE/OS binary/XML data. |

The following modules in the `Modules` namespace are currently available:

| Module      | Description                                                                                            |
| ----------- | ------------------------------------------------------------------------------------------------------ |
| `Loader`    | Detection and loading of a legally installed and untampered HCE executable & `initc.txt` management.   |
| `OpenSauce` | Installation of OpenSauce to the filesystem, and object representation of the OpenSauce configuration. |
| `Profile`   | Detection of the HCE profile using `lastprof.txt`, and object representation of the `blam.sav` binary. |

## CLI

All of the library's major components have a Command Line Interface (CLI) front-end. It is cross-platform,
script-friendly and versatile program for developers and calling processes to use.

Interaction is carried out using start-up arguments, with detailed instructions & logs being written to the CLI.
Appropriate exit codes and error messages are used for communication with calling processes and developers.

# Repository

The main repository and issue tracker are hosted privately. A read-only mirror of the Git repository is available on
GitHub, and copies of the latest binaries are available on the SPV3 network.

Code is written mainly in C#, targeting .NET 4.5.2 for a balance between security and compatibility. The library's
features are covered with automated tests to ensure that the core logic fulfils the expected requirements and proposed
specifications.