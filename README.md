<html>
    <h1 align="center">
        HCE.AmaiSosu
    </h1>
    <h3 align="center">
        An Alternative OpenSauce Installer
    </h3>
    <p align="center">
        <img src="https://user-images.githubusercontent.com/10241434/48660282-52cf9880-ea9a-11e8-9654-caf579a21500.png">
    <p>
    <p align="center">
        <a href="https://github.com/yumiris/HCE.AmaiSosu/releases/latest">
            Download
        </a>
    </p>
</html>

# Introduction

AmaiSosu is an installer for the HCE OpenSauce mod, which seeks to make the installation much more straightforward
and easy. It serves as the sucessor of SweetSauce, in both its name and in its functionality.

AmaiSosu installs the OpenSauce library data to the given HCE directory path, and it also installs in-game UI for
configuring OpenSauce. If OpenSauce files are present in the given HCE directory path, it will back them up to
a directory named `AmaiSosu.Backup.<GUID>`.

## Features

- installation of the OpenSauce libraries, in-game UI and user configurations;
- installation of OpenSauce development tools (`OS_Guerilla`, `OS_Sapien`, `OS_Tool`, etc.);
- automatic back-up of existing OpenSauce data in the HCE directory (both files and folders);
- automatic detection attempt of a legally installed HCE directory for an even easier installation;
- ability to manually specify a HCE directory, for portable/non-standard HCE installations;
- minimum administrative requirements -- they are only needed if HCE is installed a restricted location;
- minimum .NET Framework required is 4.5, which comes built-in as of Windows 8 -- no need for multiple .NET versions;
- dependencies used by OpenSauce (e.g. MSVCR) are all installed to the HCE directory rather than on the system.

## Usage

1. Download the installer and run it with administrative permissions.
2. If HCE is legally installed, its path should be detected. Just click Install, and you're done!
3. However, if the path is not found, please click on browse and look for `haloce.exe` on your computer.
   Then, you can click Install and be done!

# Support

Given that the GitHub repository is a public mirror of the upstream code, issues are disabled there.
To report bugs, please rely on the official Reddit thread.