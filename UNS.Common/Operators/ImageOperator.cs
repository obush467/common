using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace UNS.Common.Operators
{
    public class ImageOperator
    {
        readonly List<string> Extensions = new List<string>() { ".bmp", ".emf", "exif", ".gif", ".icon", ".jpg", ".jpeg", ".png", ".tif", ".tiff", ".wmf" };
        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        /*public void Copy(FileoryInfo inputDir, DirectoryInfo outputDir, IEnumerable<string> numbers, IEnumerable<string> inputsubdirs, bool renameBySubdirs, bool copyToSubdirs, bool withOverlayText)
        {*/
        public IEnumerable<object> SelectPhotos(DirectoryInfo inputDir, IEnumerable<string> numbers, IEnumerable<string> inputsubdirs)
        {
            var result = new List<object>();
            var directories = inputDir.GetDirectories("*", SearchOption.TopDirectoryOnly).Where(w => numbers.Contains(w.Name)).ToList();
            foreach (var directory in directories)
            {
                var subdirectories = directory.GetDirectories().Where(w => inputsubdirs.Contains(w.Name.ToLower())).ToList();
                foreach (var subdirectory in subdirectories)
                {
                    var files = subdirectory.GetFiles().Where(w => Extensions.Contains(w.Extension)).OrderBy(o => o.CreationTime).ThenBy(o => o.Name).ToList();
                    result.AddRange(files);
                }
            }
            return result;
        }
        public IEnumerable<FileInfo> CopyByNumbers(DirectoryInfo inputDir, DirectoryInfo outputDir, IEnumerable<string> numbers, IEnumerable<string> inputsubdirs, bool renameBySubdirs, bool copyToSubdirs, bool withOverlayText)
        {
            var result = new List<FileInfo>();
            var inputDirUri = inputDir.FullName;
            var outputDirUri = outputDir.FullName;
            foreach (var number in numbers)
            {
                var inputNumberuri = Path.Combine(inputDirUri, number);
                var outputNumberuri = Path.Combine(outputDirUri, number);
                foreach (var subdir in inputsubdirs)
                {
                    var inputSubdiruri = Path.Combine(inputNumberuri, subdir);
                    var outputSubdiruri = copyToSubdirs ? Path.Combine(outputNumberuri, subdir) : outputNumberuri;
                    var findfiles = new DirectoryInfo(inputSubdiruri).GetFiles().Where(w => Extensions.Contains(w.Extension.ToLower()));
                    if (findfiles != null && findfiles.Any())
                    {
                        foreach (var file in findfiles)
                        {
                            var md5 = CalculateMD5(file.FullName);
                            var newFileName = renameBySubdirs
                                ? renameBySubdirs
                                    ? Path.Combine(outputSubdiruri, String.Join("_", number, subdir, md5) + file.Extension)
                                    : Path.Combine(outputSubdiruri, String.Join("_", number, md5) + file.Extension)
                                : renameBySubdirs
                                    ? Path.Combine(outputNumberuri, String.Join("_", number, subdir, md5) + file.Extension)
                                    : Path.Combine(outputNumberuri, String.Join("_", number, md5) + file.Extension);
                            var wdir = (new FileInfo(newFileName)).Directory;
                            if (!wdir.Exists)
                            {
                                wdir.Create();
                            };
                            if (withOverlayText)
                            { UpdateImage(file, new FileInfo(newFileName), number); }
                            else { file.CopyTo(newFileName); }
                            result.Add(new FileInfo(newFileName));
                        }
                    }
                }
            }
            return result;
        }
        public void UpdateImage(FileInfo inputfile, DirectoryInfo outputDir)
        {
            var reg = new Regex("\\d{5}ДУ\\d{6}");
            var nameReg = reg.Match(inputfile.FullName).Value;
            var subdir = outputDir.CreateSubdirectory(nameReg);
            //var subdir2 = subdir.CreateSubdirectory("Фото_свет");
            var newFilePath = Path.Combine(subdir.FullName, inputfile.Name);
            UpdateImage(inputfile, new FileInfo(newFilePath), nameReg);
        }

        public void UpdateImage(FileInfo inputfile, FileInfo outputFile, string text)
        {
            OverlayTextOnImage(
                Bitmap.FromFile(inputfile.FullName), text)
                .Save(outputFile.FullName, System.Drawing.Imaging.ImageFormat.Jpeg); //путь и имя сохранения файла
        }

        public Image OverlayTextOnImage(Image input, string text)
        {
            var image = (Image)input.Clone();
            using (Graphics g = Graphics.FromImage(image))
            {
                RectangleF drawRect = new RectangleF(0, image.Height - image.Height / 10, image.Width, image.Height / 10);
                Font drawFont = new Font("Verdana", image.Height / 30);
                SolidBrush drawBrush = new SolidBrush(Color.White);
                g.DrawString(text, drawFont, drawBrush, drawRect);//текст на картинке, шрифт и его размер        
                return image;
            }
        }

        public void Print(FileInfo file, PrinterSettings printerSettings, PageSettings pageSettings)
        {
            var bmp = Bitmap.FromFile(file.FullName);
            void ppp(object sender, PrintPageEventArgs e)
            {
                var newWidth = bmp.Width * 100 / bmp.HorizontalResolution;
                var newHeight = bmp.Height * 100 / bmp.VerticalResolution;
                var widthFactor = (pageSettings.Landscape)
                    ? newWidth / e.PageSettings.PrintableArea.Height
                    : newWidth / e.PageSettings.PrintableArea.Width;
                var HeightFactor = (pageSettings.Landscape)
                    ? newHeight / e.PageSettings.PrintableArea.Width
                    : newHeight / e.PageSettings.PrintableArea.Height;
                var widthMargin = 0;
                var heightMargin = 0;
                if (widthFactor > 1 || HeightFactor > 1)
                {
                    if (widthFactor > HeightFactor)
                    {
                        newWidth /= widthFactor;
                        newHeight /= widthFactor;
                    }
                    else
                    {
                        newWidth /= HeightFactor;
                        newHeight /= HeightFactor;
                    }
                }
                if (pageSettings.Landscape)
                {
                    heightMargin = (int)((e.PageSettings.PrintableArea.Height - newHeight) / 2) / 2;
                }
                else
                {
                    widthMargin = (int)((e.PageSettings.PrintableArea.Width - newWidth) / 2) / 2;
                }
                var h = e.PageSettings.PrintableArea.Height;
                var m = (e.PageSettings.PrintableArea.Height - h) / 2;
                e.Graphics.DrawImage(bmp,
                    (e.PageSettings.HardMarginX + widthMargin),
                    (e.PageSettings.HardMarginY + heightMargin),
                    newWidth,
                    newHeight);
            }
            using (var printDoc = new PrintDocument
            {
                DefaultPageSettings = pageSettings
            })
            {
                if (!file.Exists) { return; }
                printDoc.PrinterSettings = printerSettings;
                printDoc.PrintPage += ppp;
                printDoc.Print();
                bmp.Dispose();
            }
        }


    }
}
