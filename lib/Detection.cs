/**
 * Copyright (c) 2020 Emilian Roman
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System.IO;
using static System.Environment;
using static System.Environment.SpecialFolder;
using static System.IO.File;
using static System.IO.Path;
using Microsoft.Win32;

namespace HXE.Detect
{
  /**
   * HXE Detection static API for inferring the path of the HCE executable on the filesystem.
   */
  public static class Detection
  {
    /**
     * Canonical name of the HCE executable on the filesystem as declared by a typical HCE installation.
     */
    public const string Executable = "haloce.exe";

    /**
     * Wrapper method for inferring the executable path by attempting all of the available methods. This method carries
     * out the detection in the following order:
     *
     * 1.   Look for the executable in the current (working) directory; if nothing is found, then
     * 2.   Look for the executable in the Program Files directories; if nothing is found, then
     * 3.   Look for the executable in the Windows Registry keys; if nothing is found, then return null.
     *
     * In similar fashion to the rest of the public methods, null will be returned if nothing is found at all.
     */
    public static FileInfo Infer()
    {
      return InferFromCurrentDirectory() ??
             InferFromProgramFilesPath() ??
             InferFromRegistryKeyEntry();
    }

    /**
     * Infers the location of the HCE executable by checking if it exists in the current directory.
     *
     * If found on the filesystem, then return a FileInfo instance representing the executable in the current directory,
     * otherwise null.
     */
    public static FileInfo InferFromCurrentDirectory()
    {
      var path = Combine(CurrentDirectory, Executable);

      return Exists(path) ? new FileInfo(path) : null;
    }

    /**
     * Infers the location of the HCE executable by checking if it exists in the Program Files directories (both 32-bit
     * and 64-bit).
     *
     * If found on the filesystem, then return a FileInfo instance representing the executable in the respective Program
     * Files directory, otherwise null.
     */
    public static FileInfo InferFromProgramFilesPath()
    {
      var exePath = Combine("Microsoft Games", "Halo Custom Edition", Executable);

      var pathX64 = Combine(GetFolderPath(ProgramFilesX86), exePath);
      var pathX32 = Combine(GetFolderPath(ProgramFiles),    exePath);

      if (Exists(pathX64))
        return new FileInfo(pathX64);

      if (Exists(pathX32))
        return new FileInfo(pathX32);

      return null;
    }

    /**
     * Infers the location of the HCE executable by checking if it exists in the Windows Registry keys.
     *
     * If found on the filesystem, then return a FileInfo instance representing the executable declared in the Registry.
     *
     * Both the 32-bit and 64-bit paths are handled. If the 64-bit doesn't work, then it will attempt to use the 32-bit
     * one as a fallback. Should that fail, too, then null will ultimately be returned.
     */
    public static FileInfo InferFromRegistryKeyEntry()
    {
      const string keyX64 = @"SOFTWARE\Wow6432Node\Microsoft\Microsoft Games\Halo CE";
      const string keyX32 = @"SOFTWARE\Microsoft\Microsoft Games\Halo CE";

      /**
       * Seeks the HEC executable path at the given registry sub-key, and returns the path if it exists on the fs; else
       * null.
       */
      static FileInfo GetFromSubKey(string subKey)
      {
        const string member = "EXE Path";
        using var    key    = Registry.LocalMachine.OpenSubKey(subKey);
        var          path   = key?.GetValue(member).ToString();

        if (path != null && Exists(path))
          return new FileInfo(path);

        return null;
      }

      return GetFromSubKey(keyX64) ?? GetFromSubKey(keyX32);
    }
  }
}