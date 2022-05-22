using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04_Files
{
    internal class Program
    {
        static void Main()
        {

            Dictionary<string, string> fileTypes = new Dictionary<string, string> // file types
            {
                { "image", ".png .webp .jpg .gif .tiff" },
                { "audio", ".ogg .mp3 .m4a" },
                { "video", ".mkv .mp4 .webm" },
                { "document", ".txt .doc .docx .xml .xlmx" }
            };

            // directory to scan
            string rootdir = @"C:\test";

            // creating a dictionary with all the files in the directory
            Dictionary<string, FileInfo> allFiles = new Dictionary<string, FileInfo>();

            string[] filesArray = Directory.GetFiles(rootdir, "*", SearchOption.AllDirectories);

            for (int i = 0; i < filesArray.Length; i++)
            {
                allFiles.Add(filesArray[i], new FileInfo(filesArray[i])); // getting all the files into sorted dictionary, with full file name (including dir) as a key, and FileInfo as a value
            }


            var lol = new Class1(new Dictionary<string, Dictionary<string, FileInfo>>()
            {
                {"images", new Dictionary<string, FileInfo>() },
                {"audios ", new Dictionary<string, FileInfo>()} ,
                {"videos ", new Dictionary<string, FileInfo>()} ,
                {"documents ", new Dictionary<string, FileInfo>() } ,
                {"others" , new Dictionary<string, FileInfo>() }
            });

            Dictionary<string, FileInfo>;
            Dictionary<string, FileInfo>;
            Dictionary<string, FileInfo>;
            Dictionary<string, FileInfo>;

            foreach (var file in allFiles)
            {
                if (fileTypes[" "].Contains(file.Value.Extension))
                {
                    images.Add(file.Key, file.Value);
                }
                else if (fileTypes["audio"].Contains(file.Value.Extension))
                {
                    audios.Add(file.Key, file.Value);
                }
                else if (fileTypes["video"].Contains(file.Value.Extension))
                {
                    videos.Add(file.Key, file.Value);
                }
                else if (fileTypes["document"].Contains(file.Value.Extension))
                {
                    documents.Add(file.Key, file.Value);
                }
                else
                {
                    others.Add(file.Key, file.Value);
                }
            }

            //sorting files by extension
            Dictionary<string, FileInfo> jpgFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> pngFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> gifFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> docFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> txtFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> mp3Files = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> othFiles = new Dictionary<string, FileInfo>();

            foreach (var file in allFiles)
            {
                if (file.Value.Extension == ".jpg")
                {
                    jpgFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Extension == ".png")
                {
                    pngFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Extension == ".gif")
                {
                    gifFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Extension == ".doc")
                {
                    docFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Extension == ".txt")
                {
                    txtFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Extension == ".mp3")
                {
                    mp3Files.Add(file.Key, file.Value);
                }
                else
                {
                    othFiles.Add(file.Key, file.Value);
                }
            }

            //sorting files by size
            Dictionary<string, FileInfo> underKBFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> KBtoMBFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> MBtoGBFiles = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> overGBFiles = new Dictionary<string, FileInfo>();



            foreach (var file in allFiles)
            {

                long KB = 1024;
                long MB = 1048576;
                long GB = 1073741824;

                if (file.Value.Length < KB)
                {
                    underKBFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Length >= KB && file.Value.Length < MB)
                {
                    KBtoMBFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Length >= MB && file.Value.Length < GB)
                {
                    MBtoGBFiles.Add(file.Key, file.Value);
                }
                else if (file.Value.Length >= GB)
                {
                    overGBFiles.Add(file.Key, file.Value);
                }
            }

            // calculates total size of a specific dictionary of files
            double totalSize(Dictionary<string, FileInfo> files)
            {
                long totalSize = 0;
                foreach (var file in files)
                {
                    totalSize += file.Value.Length;
                }
                return totalSize;
            }

            // calculates average size of a specific dictionary of files
            double avgSize(Dictionary<string, FileInfo> files)
            {
                if (files.Count > 0)
                {
                    long avgSize = 0;
                    foreach (var file in files)
                    {
                        avgSize += file.Value.Length;
                    }
                    return avgSize / files.Count;
                }
                else return 0;
            }

            // returns min or max size of a file in directory
            long Size(Dictionary<string, FileInfo> files, byte op)
            {
                if (files.Count > 0)
                {
                    long[] sizes = new long[files.Count];
                    int i = 0;
                    foreach (var file in files)
                    {
                        sizes[i] = file.Value.Length;
                        i++;
                    }
                    Array.Sort(sizes);
                    if (op == 1) // if op == 1 returns max
                        return sizes[files.Count - 1];
                    else return sizes[0]; // if op == 1 returns min
                }
                else return 0;
            }

            //returns formatted string for showing file sizes in the console
            string SizeToString(double size)
            {

                long KB = 1024;
                long MB = 1048576;
                long GB = 1073741824;

                string sizeString = String.Empty;

                if (size < KB)
                {
                    sizeString += $"{size}B";
                }
                else if (size >= KB && size < MB)
                {
                    sizeString += $"{size / KB:F0}KB";
                }
                else if (size >= MB && size < GB)
                {
                    sizeString += $"{size / MB:F1}MB";
                }
                else if (size >= GB)
                {
                    sizeString += $"{size / GB:F1}GB";
                }
                return sizeString;
            }




            GetFilesInfo();


            void GetFilesInfo()
            {
                // getting the number of subdirs
                int subdirsCount = Directory.GetDirectories(rootdir, "*", SearchOption.AllDirectories).Count();

                // calculating total size of all files in rootdir
                double totalSizeAllFiles = 0;
                foreach (var file in allFiles)
                {
                    totalSizeAllFiles += file.Value.Length;
                }

                // calculating total size of all files in subdirs excluding rootdir
                double subDirsSize = 0;
                foreach (var file in allFiles)
                {
                    if (file.Value.DirectoryName != rootdir)
                    {
                        subDirsSize += file.Value.Length;
                    }
                }

                Console.WriteLine("Nodes:");
                Console.WriteLine(String.Format("{0,-24}{1,-10}{2,-10}", String.Empty, "[count]", "[total size]"));
                Console.WriteLine(String.Format("{0,-4}{1,-21}{2,-10}{3,-10}", String.Empty, "Directories:", subdirsCount, $"{SizeToString(subDirsSize)}"));
                Console.WriteLine(String.Format("{0,-4}{1,-21}{2,-10}{3,-10}", String.Empty, "Files", allFiles.Count, $"{SizeToString(totalSizeAllFiles)}"));

                Console.WriteLine();

                Console.WriteLine("Files:");
                Console.WriteLine(String.Format("{0,-4}{1,-20}", String.Empty, "By types:"));
                Console.WriteLine(String.Format("{0,-24}{1,-10}{2,-15}{3,-13}{4,-13}{5,-13}", String.Empty, "[count]", "[total size]", "[avg size]", "[min size]", "[max size]"));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "image", images.Count, SizeToString(totalSize(images)), SizeToString(avgSize(images)), SizeToString(Size(images, 0)), SizeToString(Size(images, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "audio", audios.Count, SizeToString(totalSize(audios)), SizeToString(avgSize(audios)), SizeToString(Size(audios, 0)), SizeToString(Size(audios, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "video", videos.Count, SizeToString(totalSize(videos)), SizeToString(avgSize(videos)), SizeToString(Size(videos, 0)), SizeToString(Size(videos, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "document", documents.Count, SizeToString(totalSize(documents)), SizeToString(avgSize(documents)), SizeToString(Size(documents, 0)), SizeToString(Size(documents, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "[other]", videos.Count, SizeToString(totalSize(others)), SizeToString(avgSize(others)), SizeToString(Size(others, 0)), SizeToString(Size(others, 1))));

                Console.WriteLine();

                Console.WriteLine("By extensions:");
                Console.WriteLine(String.Format("{0,-24}{1,-10}{2,-15}{3,-13}{4,-13}{5,-13}", String.Empty, "[count]", "[total size]", "[avg size]", "[min size]", "[max size]"));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "jpg", jpgFiles.Count, SizeToString(totalSize(jpgFiles)), SizeToString(avgSize(jpgFiles)), SizeToString(Size(jpgFiles, 0)), SizeToString(Size(jpgFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "png", pngFiles.Count, SizeToString(totalSize(pngFiles)), SizeToString(avgSize(pngFiles)), SizeToString(Size(pngFiles, 0)), SizeToString(Size(pngFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "gif", gifFiles.Count, SizeToString(totalSize(gifFiles)), SizeToString(avgSize(gifFiles)), SizeToString(Size(gifFiles, 0)), SizeToString(Size(gifFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "doc", docFiles.Count, SizeToString(totalSize(docFiles)), SizeToString(avgSize(docFiles)), SizeToString(Size(docFiles, 0)), SizeToString(Size(docFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "txt", txtFiles.Count, SizeToString(totalSize(txtFiles)), SizeToString(avgSize(txtFiles)), SizeToString(Size(txtFiles, 0)), SizeToString(Size(txtFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "mp3", mp3Files.Count, SizeToString(totalSize(mp3Files)), SizeToString(avgSize(mp3Files)), SizeToString(Size(mp3Files, 0)), SizeToString(Size(mp3Files, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "[other]", othFiles.Count, SizeToString(totalSize(othFiles)), SizeToString(avgSize(othFiles)), SizeToString(Size(othFiles, 0)), SizeToString(Size(othFiles, 1))));

                Console.WriteLine();

                Console.WriteLine(String.Format("{0,-4}{1,-20}", String.Empty, "By sizes:"));
                Console.WriteLine(String.Format("{0,-24}{1,-10}{2,-15}{3,-13}{4,-13}{5,-13}", String.Empty, "[count]", "[total size]", "[avg size]", "[min size]", "[max size]"));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "      . <= 1KB", underKBFiles.Count, SizeToString(totalSize(underKBFiles)), SizeToString(avgSize(underKBFiles)), SizeToString(Size(underKBFiles, 0)), SizeToString(Size(underKBFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "1KB < . <= 1MB", KBtoMBFiles.Count, SizeToString(totalSize(KBtoMBFiles)), SizeToString(avgSize(KBtoMBFiles)), SizeToString(Size(KBtoMBFiles, 0)), SizeToString(Size(KBtoMBFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "1MB < . <= 1GB", MBtoGBFiles.Count, SizeToString(totalSize(MBtoGBFiles)), SizeToString(avgSize(MBtoGBFiles)), SizeToString(Size(MBtoGBFiles, 0)), SizeToString(Size(MBtoGBFiles, 1))));
                Console.WriteLine(String.Format("{0,-8}{1,-17}{2,-10}{3,-15}{4,-13}{5,-13}{6,-13}", String.Empty, "1GB < .", overGBFiles.Count, SizeToString(totalSize(overGBFiles)), SizeToString(avgSize(overGBFiles)), SizeToString(Size(overGBFiles, 0)), SizeToString(Size(overGBFiles, 1))));

                Console.WriteLine();

                // counting files starting with A C R and 5 3 1 
                int countACR = 0;
                int count531 = 0;

                foreach (var file in allFiles)
                {
                    if (file.Value.Name.StartsWith("A") || file.Value.Name.StartsWith("C") || file.Value.Name.StartsWith("R"))
                    {
                        countACR++;
                    }
                    if (file.Value.Name.StartsWith("5") || file.Value.Name.StartsWith("3") || file.Value.Name.StartsWith("1"))
                    {
                        count531++;
                    }
                }

                Console.WriteLine(String.Format("{0,-4}{1,-20}", String.Empty, "Counts by first letter:"));
                Console.WriteLine(String.Format("{0,-8}{1,-12}{2,-10}", String.Empty, "A  C  R", countACR));
                Console.WriteLine(String.Format("{0,-8}{1,-12}{2,-10}", String.Empty, "5  3  1", count531));

                Console.WriteLine();

                Console.WriteLine(String.Format("{0,-4}{1,-20}", String.Empty, "Ordered by name:"));
                Console.WriteLine(String.Format("{0,-67}{1,-10}{2,-10}", String.Empty, "[size]", "[path]"));

                Dictionary<FileInfo, string> allFilesByName = new Dictionary<FileInfo, string>(); // dictionary to sort files by size, fileinfo as a key to allow files with the same names and/or size

                foreach (var file in allFiles)
                {
                    allFilesByName.Add(file.Value, file.Value.Name);
                }

                var allFilesByNameSorted = from entry in allFilesByName orderby entry.Value ascending select entry; // sorting dictionary by value

                foreach (var file in allFilesByNameSorted)
                {
                    Console.WriteLine(String.Format("{0,-8}{1,-60}{2,-10}{3,-10}", String.Empty, file.Value, SizeToString(file.Key.Length), file.Key.DirectoryName));
                }

                Console.WriteLine();



                Console.WriteLine(String.Format("{0,-4}{1,-20}", String.Empty, "Ordered by sizes (from biggest):"));
                Console.WriteLine(String.Format("{0,-67}{1,-20}", String.Empty, "[size]"));


                Dictionary<FileInfo, long> allFilesBySize = new Dictionary<FileInfo, long>(); // dictionary to sort files by size, fileinfo as a key to allow files with the same names and/or size

                foreach (var file in allFiles)
                {
                    allFilesBySize.Add(file.Value, file.Value.Length);
                }

                var allFilesBySizeSorted = from entry in allFilesBySize orderby entry.Value descending select entry; // sorting dictionary by value

                foreach (var file in allFilesBySizeSorted)
                {
                    Console.WriteLine(String.Format("{0,-8}{1,-60}{2,-10}", String.Empty, file.Key.Name, SizeToString(file.Value)));
                }

            }
        }
    }
}
