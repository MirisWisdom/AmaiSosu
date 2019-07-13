# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## v0.4.0
### Added
- A completely new user interface and branding style.

### Removed
- Installation of user XML settings (OpenSauce generates them on start-up).

## v0.3.5
### Added
- Asynchronous invocation of the installation procedure.
- Ability to detect an officially SPV3.2 directory.
- Remove OpenSauce data directory pre-installation.

### Changed
- Changed licence to GPL-3.0.

## v0.3.4
### Added
- Manifest file for reinforcing administrative requirements.

### Fixed
- Eliminate the "This program might not have installed correctly" warning by adding a manifest file.

### Removed
- Atarashii library is no longer used; instead, its OpenSauce installation code has been ported to AmaiSosu.

## v0.3.3
### Changed
- The background image's resolution has been increased in size.
- Distributed SFX compilation method (from WinRAR to 7-Zip).

### Fixed
- False positives from some AVs on VirusTotal, due to the SFX compilation method. Cheers to moiler  & `Anton#6293` for
  informing me about the false positives.
- Graphical glitches on WINE due to previously lower resolution background. Cheers to
  [Lionir](https://github.com/lionirdeadman) for the heads up.

## v0.3.2
### Added
- Outputting of the source version/revision used for compiling the binary.
- Deactivation of the install button until a valid HCE directory is chosen.

## v0.3.1
### Fixed
- Unintentional backing up of default HCE shader files when installing OpenSauce. AmaiSosu now distinguishes betweeen
  OpenSauce shader files and HCE shader files. A thank you to the following invaluable testers for assisting with this
  issue: `Anton#6293`, [Michelle](https://github.com/gbMichelle) and [Lionir](https://github.com/lionirdeadman).

## v0.3.0
### Added
- Introduced support for installing the OpenSauce IDE to a dedicated sub-directory in the HCE directory, rather than to
  the original directory which is pretty obscure and inconvenient to access.

## v0.2.0
### Added
- Introduced support for detecting & backing up HAC2. Because HAC2 is incompatible with OpenSauce, AmaiSosu will back up
   its DLL to disable HCE from loading it.

## v0.1.0
### Added
- Everything! This is the initial release of AmaiSosu.
  Please report issues [here](https://www.reddit.com/r/halospv3/comments/9xvnn5/amaisosu_an_opensauce_installer/)!
