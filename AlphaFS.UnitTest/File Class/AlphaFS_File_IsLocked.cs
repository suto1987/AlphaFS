﻿/*  Copyright (C) 2008-2017 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace AlphaFS.UnitTest
{
   partial class FileTest
   {
      // Pattern: <class>_<function>_<scenario>_<expected result>

      [TestMethod]
      public void AlphaFS_File_IsLocked_LocalAndNetwork_Success()
      {
         File_IsLocked(false);
         File_IsLocked(true);
      }


      [TestMethod]
      public void AlphaFS_File_GetProcessesForLockedFile_LocalAndNetwork_Success()
      {
         File_GetProcessesForLockedFile(false);
         File_GetProcessesForLockedFile(true);
      }


      [TestMethod]
      public void AlphaFS_File_GetProcessesForLockedFile_NoFileLocked_LocalAndNetwork_Success()
      {
         File_GetProcessesForLockedFile_NoFileLocked(false);
         File_GetProcessesForLockedFile_NoFileLocked(true);
      }




      private void File_IsLocked(bool isNetwork)
      {
         UnitTestConstants.PrintUnitTestHeader(isNetwork);

         var tempPath = System.IO.Path.GetTempPath();
         if (isNetwork)
            tempPath = Alphaleonis.Win32.Filesystem.Path.LocalToUnc(tempPath);


         using (var rootDir = new TemporaryDirectory(tempPath, MethodBase.GetCurrentMethod().Name))
         {
            var file = rootDir.RandomFileFullPath + ".txt";
            var fi = new System.IO.FileInfo(file);

            Console.WriteLine("\nInput File Path: [{0}]]", file);


            using (fi.CreateText())
               Assert.IsTrue(Alphaleonis.Win32.Filesystem.File.IsLocked(fi.FullName), "The file is not locked, but is expected to be.");

            Assert.IsFalse(Alphaleonis.Win32.Filesystem.File.IsLocked(fi.FullName), "The file is locked, but is expected not to be.");
         }

         Console.WriteLine();
      }


      private void File_GetProcessesForLockedFile(bool isNetwork)
      {
         UnitTestConstants.PrintUnitTestHeader(isNetwork);

         var tempPath = System.IO.Path.GetTempPath();
         if (isNetwork)
            tempPath = Alphaleonis.Win32.Filesystem.Path.LocalToUnc(tempPath);


         using (var rootDir = new TemporaryDirectory(tempPath, MethodBase.GetCurrentMethod().Name))
         {
            var file = rootDir.RandomFileFullPath + ".txt";
            var fi = new System.IO.FileInfo(file);

            Console.WriteLine("\nInput File Path: [{0}]]", file);


            using (fi.CreateText())
            {
               var processes = Alphaleonis.Win32.Filesystem.File.GetProcessesForLockedFile(fi.FullName);

               foreach (var process in processes)
               {
                  // Uncomment to see all properties.
                  //UnitTestConstants.Dump(process, -26);

                  Console.WriteLine("\n\tProcess Name: [{0}] | ID: [{1}]", process.ProcessName, process.Id);


                  // The name of the Visual Studio unit test process.
                  Assert.IsTrue(process.ProcessName.StartsWith("QTAgent", StringComparison.OrdinalIgnoreCase));
               }
            }
         }

         Console.WriteLine();
      }


      private void File_GetProcessesForLockedFile_NoFileLocked(bool isNetwork)
      {
         UnitTestConstants.PrintUnitTestHeader(isNetwork);

         var tempPath = System.IO.Path.GetTempPath();
         if (isNetwork)
            tempPath = Alphaleonis.Win32.Filesystem.Path.LocalToUnc(tempPath);


         using (var rootDir = new TemporaryDirectory(tempPath, MethodBase.GetCurrentMethod().Name))
         {
            var file = rootDir.RandomFileFullPath + ".txt";
            var fi = new System.IO.FileInfo(file);

            Console.WriteLine("\nInput File Path: [{0}]]\n", file);


            using (fi.CreateText()) { }


            Assert.AreEqual(0, Alphaleonis.Win32.Filesystem.File.GetProcessesForLockedFile(fi.FullName).Count());
         }

         Console.WriteLine();
      }
   }
}
