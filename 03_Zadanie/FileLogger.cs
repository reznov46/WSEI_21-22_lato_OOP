﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Zadanie
{
    internal class FileLogger : WritterLogger
    {
        private bool disposed;
        protected FileStream stream;

        public FileLogger(string path)
        {
            stream = new FileStream(path, FileMode.Append);
            writer = new StreamWriter(stream);
        }
        ~FileLogger()
        {
            Dispose(disposing: false);
        }
        public override void Dispose()
        {
            writer.Close();
            writer.Dispose();
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    Dispose();
            disposed = true;
        }
    }
}
