using System;
using System.IO;

namespace Dashboard
{
    public class Fileinfo
    {
        public string FullName { get; internal set; }
        public string Extension { get; internal set; }
        public string Length { get; internal set; }

        internal FileStream OpenRead()
        {
            throw new NotImplementedException();
        }

        internal static FileAttributes GetAttributes(string fullName)
        {
            throw new NotImplementedException();
        }
    }
}