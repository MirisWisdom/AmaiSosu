<html>
    <p align="center">
        <img src="https://user-images.githubusercontent.com/10241434/48660304-ab069a80-ea9a-11e8-956a-4c817bef6d7d.png">
    <p>
    <h1 align="center">
        HCE.AmaiSosu
    </h1>
    <h3 align="center">
        An Alternative OpenSauce Installer
    </h3>
    <p align="center">
        <img src="https://user-images.githubusercontent.com/10241434/48935599-222caa80-ef43-11e8-8f76-18d0e6308cb9.png">
    <p>
    <p align="center">
        <a href="https://github.com/yumiris/HCE.AmaiSosu/releases/latest">
            Download
        </a>
        •
        <a href="https://www.reddit.com/r/halospv3/comments/9xvnn5/amaisosu_an_opensauce_installer/">
            Support
        </a>
    </p>
</html>

# Introduction

AmaiSosu is an installer for the HCE OpenSauce mod, which seeks to make the installation much more straightforward
and easy. It serves as the successor of SweetSauce, in both its name and in its functionality.

AmaiSosu installs the OpenSauce library data to the given HCE directory path, and it also installs in-game UI for
configuring OpenSauce. If OpenSauce/HAC2 files are present in the given HCE directory path, it will back them up to
a directory named `AmaiSosu.Backup.<GUID>`. HAC2 is incompatible with OS, thus it will be deactivated to ensure that
there is no collision.

## Features

- installation of the OpenSauce libraries, in-game UI and user configurations;
- installation of OpenSauce development tools (`OS_Guerilla`, `OS_Sapien`, `OS_Tool`, etc.);
- installation of the OpenSauce IDE to the HCE directory, for self-containerisation & convenience;
- automatic back-up of existing OpenSauce data in the HCE directory (both files and folders);
- automatic back-up & deactivation of HAC2 if it exists, due to its incompatibility with OpenSauce;
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

### Portable Installations

For users out there with alternative HCE installations in conformist environments, download the installer and extract it
using 7-Zip or WinRAR. Then, run the extracted `AmaiSosu.GUI.exe` executable without admin permissions and install it to
your portable HCE directory.

Note that attempting to install AmaiSosu to HCE in a restricted location (e.g. `Program Files\Microsoft Games\`) without
admin permissions will cause issues!

# Support

Given that the GitHub repository is a public mirror of the upstream code, issues are disabled there.
To report bugs, please rely on the
[official Reddit thread](https://www.reddit.com/r/halospv3/comments/9xvnn5/amaisosu_an_opensauce_installer/), or contact
me on Discord if you know my username!

# Development

## Library

As of `v0.3.4`, AmaiSosu uses a forked version Atarashii Library's OpenSauce module for installing OS to the system.
It also applies its own modifications and enhancements on top, such as backing up existing OpenSauce data, resolving
HAC2 conflicts and installing the OS IDE to the HCE directory.

## Repository

The GitHub repository for AmaiSosu serves a public read-only mirror of the private upstream repository. All commits are
immediately mirrored to GitHub for transparency.

# Contributors

The following invaluable testers have reported/assisted with issues:

- Anton#6293
- [Michelle](https://github.com/gbMichelle)
- [Lionir](https://github.com/lionirdeadman)
- moiler

# Attributions

- [Icon](https://www.flaticon.com/free-icon/bowl-and-chopsticks-of-japan_12775)
- [OpenSauce](https://twitter.com/KornnerStudios)