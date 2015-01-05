/* Copyright (C) 2008-2015 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
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

using System.Diagnostics.CodeAnalysis;

namespace Alphaleonis.Win32.Filesystem
{
   /// <summary>
   ///   Enumeration specifying the different reparse point tags.
   /// </summary>
   /// <remarks>
   ///   <para>Reparse tags, with the exception of IO_REPARSE_TAG_SYMLINK, are processed on the server</para>
   ///   <para>and are not processed by a client after transmission over the wire.</para>
   ///   <para>Clients should treat associated reparse data as opaque data.</para>
   /// </remarks>
   [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
   public enum ReparsePointTag : uint
   {
      /// <summary>(0x00000000) The entry is not a reparse point.</summary>
      None = 0,

      /// <summary>(0xC0000014) IO_REPARSE_APPXSTREAM</summary>
      AppXStream = 3221225492,

      /// <summary>(0x80000009) IO_REPARSE_TAG_CSV</summary>
      Csv = 2147483657,

      /// <summary>(0x80000005) IO_REPARSE_TAG_DRIVER_EXTENDER - Used by Home server drive extender.</summary>
      DriverExtender = 2147483653,

      /// <summary>(0x80000013) IO_REPARSE_TAG_DEDUP</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dedup")]
      Dedup = 2147483667,

      /// <summary>(0x8000000A) IO_REPARSE_TAG_DFS - Used by the DFS filter.</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dfs")]
      Dfs = 2147483658,

      /// <summary>(0x80000012) IO_REPARSE_TAG_DFSR - Used by the DFS filter.</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dfsr")]
      Dfsr = 2147483666,

      /// <summary>(0x8000000B) IO_REPARSE_TAG_FILTER_MANAGER - Used by filter manager test harness.</summary>
      FilterManager = 2147483659,

      /// <summary>(0xC0000004) IO_REPARSE_TAG_HSM - Obsolete. Used by legacy Hierarchical Storage Manager Product.</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hsm")]
      Hsm = 3221225476,

      /// <summary>(0x80000006) IO_REPARSE_TAG_HSM2 - Obsolete. Used by legacy Hierarchical Storage Manager Product.</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hsm")]
      Hsm2 = 2147483654,

      /// <summary>(0x80000014) IO_REPARSE_TAG_NFS - NFS symlinks, Windows 8 / SMB3 and later.</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Nfs")]
      Nfs = 2147483668,
      
      /// <summary>(0xA0000003) IO_REPARSE_TAG_MOUNT_POINT - Used for mount point support.</summary>
      MountPoint = 2684354563,

      /// <summary>(0x80000007) IO_REPARSE_TAG_SIS - Used by single-instance storage (SIS) filter driver.</summary>
      Sis = 2147483655,

      /// <summary>(0xA000000C) IO_REPARSE_TAG_SYMLINK - Used for symbolic link support.</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sym")]
      SymLink = 2684354572,

      /// <summary>(0x80000008) IO_REPARSE_TAG_WIM</summary>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wim")]
      Wim = 2147483656
   }
}