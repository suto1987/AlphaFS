/*  Copyright (C) 2008-2018 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
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

namespace AlphaFS.UnitTest
{
   public partial class EnumerationTest
   {
      // Pattern: <class>_<function>_<scenario>_<expected result>

      [TestMethod]
      public void AlphaFS_Host_EnumerateOpenResources_Local_Success()
      {
         var host = UnitTestConstants.LocalHost;

         EnumerateOpenResources(host);
      }
      

      private void EnumerateOpenResources(string host)
      {
         ElevationAssert.IsElevated();
         UnitTestConstants.PrintUnitTestHeader(false);

         Console.WriteLine("\nConnected to Host: [{0}]", host);


         var cnt = 0;
         foreach (var openResourceInfo in Alphaleonis.Win32.Network.Host.EnumerateOpenResources(host, null, null, false))
         {
            if (UnitTestConstants.Dump(openResourceInfo, -11))
            {
               cnt++;

               Console.WriteLine();
            }
         }


         if (cnt == 0)
         {
            const string errorMessage = "Nothing is enumerated, but it is expected.";

            Console.WriteLine(errorMessage);

            Assert.Inconclusive(errorMessage);
         }

         Console.WriteLine();
      }
   }
}
