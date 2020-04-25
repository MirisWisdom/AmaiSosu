/**
 * Copyright (C) 2020 Emilian Roman
 * 
 * This file is part of AmaiSosu.
 * 
 * AmaiSosu is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * AmaiSosu is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with AmaiSosu.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using static System.Environment;
using static System.Environment.SpecialFolder;
using static AmaiSosu.Installation.InstallationType;
using static AmaiSosu.Installation.Package.Entry.EntryType;
using static HXE.Detect.Detection;

namespace AmaiSosu
{
  /**
   * AmaiSosu Installation object, which by default instantiates with properties representing a common OpenSauce
   * installation configuration.
   */
  public class Installation
  {
    public string           Name        { get; set; } = "OpenSauce v4";         /* readable name for end-user         */
    public List<Package>    Packages    { get; set; } = new List<Package>();    /* packages to install on the fs      */
    public string           Destination { get; set; } = Infer()?.DirectoryName; /* install target for core os files   */
    public InstallationType Type        { get; set; } = Normal;                 /* controls which packages to install */

    /**
     * AmaisSosu Installation Type enum, which in practice is used to as a general way of controlling which packages to
     * install. For example, a Minimal Installation will result in only the foundational OS files being installed.
     */
    public enum InstallationType
    {
      Normal,  /* install the os library and in-game configuration gui - the most common install people would need */
      Minimal, /* install the os library (used for portability; only the hce folder needs to be accessed)          */
      Complete /* installs the os library, in-game gui, hek modules (access is needed to system and program data)  */
    }

    /**
     * AmaiSosu Package object, which is an abstraction of DEFLATE archives on the filesystem.
     * 
     * AmaiSosu always partitions the OpenSauce installation data into three sections:
     * 
     * -   GUI: resources related to the OpenSauce F7 in-game ui; and
     * -   LIB: main OpenSauce data (dinput8.dll, HEK extensions, etc.) which would be installed to the detected or
     *          specified HCE directory; and
     * -   USR: default user configurations in XML format, which are installed to the user's Documents directory.
     *
     * On the filesystem, each section is contained in its own archive. AmaiSosu extracts the files in the archives to
     * the respective destinations.
     */
    public class Package
    {
      public string      Name        { get; set; } = "OpenSauce GUI";                      /* readable package name   */
      public string      Archive     { get; set; } = "gui.zip";                            /* archive filename on fs  */
      public string      Destination { get; set; } = GetFolderPath(CommonApplicationData); /* fs path to extract to   */
      public List<Entry> Entries     { get; set; } = new List<Entry>();                    /* files in the fs archive */

      /**
       * AmaiSosu Entry object, which represents a file entry within a DEFLATE archive on the filesystem. AmaiSosu keeps
       * track of all files in each archive with:
       *
       * -   determining if they should be installed or not (e.g. install HEK OS modules only if HEK is present); and
       * -   the intent of backing them up and replacing them if they are already present on the filesystem.
       */
      public class Entry
      {
        public string    Name { get; set; } = "Core OpenSauce file"; /* readable entry name for user readability */
        public string    Path { get; set; } = "dinput8.dll";         /* entry filename in the archive & on fs    */
        public EntryType Type { get; set; } = Core;                  /* type of entry for conditional handling   */

        /**
         * AmaiSosu Entry Type enum, which is used as a type of metadata for each archive entry.
         *
         * This is used in some decisions that will be carried out by AmaiSosu when installing OpenSauce. For example:
         * 
         * -   entries with the EntryType.HEK property will only be extracted when HEK is detected on the filesystem;
         * -   entries with the EntryType.GUI property will be conditionally extracted if the user wants to install in
         *     portable mode.
         */
        public enum EntryType
        {
          Core,          /* critical files which would be installed to the user's chosen hce directory            */
          GUI,           /* user interface assets - can be skipped for lightweight/portable installations         */
          Configuration, /* user xml configurations - can be skipped in favour of runtime generation of xml files */
          HEK            /* opensauce hek modules - optionally installed if hek is present on the filesystem      */
        }
      }
    }
  }
}