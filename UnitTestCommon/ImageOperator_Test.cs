﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Common.Operators;

namespace UnitTestCommon
{
    [TestClass]
    public class ImageOperator_Test
    {
        [TestMethod]
        public void UpdateImage()
        {
            ImageOperator io = new ImageOperator();
            io.UpdateImage(new FileInfo("C:\\Users\\Bushmakin\\Pictures\\1111.png"),
                new FileInfo("C:\\Users\\Bushmakin\\Pictures\\2222.png"),
                "65456456456465456477777777888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888887777777777777777777777776545645645646546546546545456456465465456465");
        }

        [TestMethod]
        public void CopyTo()
        {

            ImageOperator io = new ImageOperator();
            var inp = new DirectoryInfo("Z:\\DU_files");
            var outp = new DirectoryInfo("c:\\temp\\2019-09-18 87 ДУ");
            var subd = new List<string>() { "Фото_свет" };
            var numbers = new List<string>() { "03100ДУ801063",
"03100ДУ801065",
"03100ДУ801080",
"03100ДУ801149",
"03100ДУ801172",
"03100ДУ801198",
"03110ДУ801280",
"03110ДУ801281",
"03110ДУ801288",
"03110ДУ801290",
"03110ДУ801291",
"03110ДУ801292",
"03110ДУ801293",
"03120ДУ801037",
"03120ДУ801044",
"03120ДУ801088",
"03120ДУ801091",
"03120ДУ801109",
"03120ДУ801116",
"03120ДУ801117",
"03120ДУ801118",
"03120ДУ801119",
"03120ДУ801136",
"03120ДУ801137",
"03120ДУ801150",
"03120ДУ801151",
"03120ДУ801156",
"03120ДУ801174",
"03120ДУ801211",
"03120ДУ801212",
"03120ДУ801215",
"03120ДУ801231",
"03120ДУ801307",
"03130ДУ801128",
"03130ДУ801130",
"03130ДУ801155",
"03130ДУ801183",
"03150ДУ801056",
"03150ДУ801109",
"03150ДУ801112",
"03150ДУ801113",
"03150ДУ801114",
"03150ДУ801238",
"03150ДУ801257",
"03150ДУ801261",
"03150ДУ801272",
"03150ДУ801275",
"03150ДУ801276",
"03150ДУ801277",
"03150ДУ801279",
"03150ДУ801281",
"03150ДУ801282",
"03150ДУ801286",
"03150ДУ801289",
"03150ДУ801290",
"03150ДУ801291",
"03150ДУ801524",
"03150ДУ801525",
"03150ДУ801535",
"03160ДУ801213",
"03160ДУ801215",
"03160ДУ801227",
"03160ДУ801239",
"03160ДУ801242",
"03160ДУ801243",
"03160ДУ801244",
"03160ДУ801297",
"03160ДУ801340",
"03160ДУ801415",
"03160ДУ801416",
"03160ДУ801434",
"03170ДУ801114",
"03170ДУ801146",
"03170ДУ801147",
"03170ДУ801306",
"03170ДУ801312",
"03170ДУ801319",
"03180ДУ801316",
"09140ДУ800012",
"09140ДУ800029",
"09140ДУ800017",
"09140ДУ800037",
"09140ДУ800040",
"09140ДУ800038",
"09140ДУ800047",
"09140ДУ800048",
"09140ДУ800066" };
            io.CopyByNumbers(inp, outp, numbers, subd, false, false, true);
        }

        [TestMethod]
        public void Print()
        {

            ImageOperator io = new ImageOperator();
            var inp = new DirectoryInfo("Z:\\DU_files");
            var outp = new DirectoryInfo("c:\\temp\\2019-09-18 87 ДУ");
            var subd = new List<string>() { "Фото_свет" };
            var numbers = new List<string>() { "03100ДУ801063",
"03100ДУ801065",
"03100ДУ801080",
"03100ДУ801149",
"03100ДУ801172",
"03100ДУ801198",
"03110ДУ801280",
"03110ДУ801281",
"03110ДУ801288",
"03110ДУ801290",
"03110ДУ801291",
"03110ДУ801292",
"03110ДУ801293",
"03120ДУ801037",
"03120ДУ801044",
"03120ДУ801088",
"03120ДУ801091",
"03120ДУ801109",
"03120ДУ801116",
"03120ДУ801117",
"03120ДУ801118",
"03120ДУ801119",
"03120ДУ801136",
"03120ДУ801137",
"03120ДУ801150",
"03120ДУ801151",
"03120ДУ801156",
"03120ДУ801174",
"03120ДУ801211",
"03120ДУ801212",
"03120ДУ801215",
"03120ДУ801231",
"03120ДУ801307",
"03130ДУ801128",
"03130ДУ801130",
"03130ДУ801155",
"03130ДУ801183",
"03150ДУ801056",
"03150ДУ801109",
"03150ДУ801112",
"03150ДУ801113",
"03150ДУ801114",
"03150ДУ801238",
"03150ДУ801257",
"03150ДУ801261",
"03150ДУ801272",
"03150ДУ801275",
"03150ДУ801276",
"03150ДУ801277",
"03150ДУ801279",
"03150ДУ801281",
"03150ДУ801282",
"03150ДУ801286",
"03150ДУ801289",
"03150ДУ801290",
"03150ДУ801291",
"03150ДУ801524",
"03150ДУ801525",
"03150ДУ801535",
"03160ДУ801213",
"03160ДУ801215",
"03160ДУ801227",
"03160ДУ801239",
"03160ДУ801242",
"03160ДУ801243",
"03160ДУ801244",
"03160ДУ801297",
"03160ДУ801340",
"03160ДУ801415",
"03160ДУ801416",
"03160ДУ801434",
"03170ДУ801114",
"03170ДУ801146",
"03170ДУ801147",
"03170ДУ801306",
"03170ДУ801312",
"03170ДУ801319",
"03180ДУ801316",
"09140ДУ800012",
"09140ДУ800029",
"09140ДУ800017",
"09140ДУ800037",
"09140ДУ800040",
"09140ДУ800038",
"09140ДУ800047",
"09140ДУ800048",
"09140ДУ800066"
 };
            var files = io.CopyByNumbers(inp, outp, numbers, subd, false, false, true);
            foreach (var file in files)
            { io.Print(file, new PrinterSettings(), new PageSettings()); }
        }


        [TestMethod]
        public void Uri()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\temp\\pp");
            var uri = new Uri(new Uri(directory.FullName,UriKind.Absolute), new Uri("sdfsdfs",UriKind.Relative));
        }

        [TestMethod]
        public void SelectPhotos()
        {
            var numbers = new List<string>() { "03100ДУ801063",
"03100ДУ801065",
"03100ДУ801080",
"03100ДУ801149",
"03100ДУ801172",
"03100ДУ801198",
"03110ДУ801280",
"03110ДУ801281",
"03110ДУ801288",
"03110ДУ801290",
"03110ДУ801291",
"03110ДУ801292",
"03110ДУ801293",
"03120ДУ801037",
"03120ДУ801044",
"03120ДУ801088",
"03120ДУ801091",
"03120ДУ801109",
"03120ДУ801116",
"03120ДУ801117",
"03120ДУ801118",
"03120ДУ801119",
"03120ДУ801136",
"03120ДУ801137",
"03120ДУ801150",
"03120ДУ801151",
"03120ДУ801156",
"03120ДУ801174",
"03120ДУ801211",
"03120ДУ801212",
"03120ДУ801215",
"03120ДУ801231",
"03120ДУ801307",
"03130ДУ801128",
"03130ДУ801130",
"03130ДУ801155",
"03130ДУ801183",
"03150ДУ801056",
"03150ДУ801109",
"03150ДУ801112",
"03150ДУ801113",
"03150ДУ801114",
"03150ДУ801238",
"03150ДУ801257",
"03150ДУ801261",
"03150ДУ801272",
"03150ДУ801275",
"03150ДУ801276",
"03150ДУ801277",
"03150ДУ801279",
"03150ДУ801281",
"03150ДУ801282",
"03150ДУ801286",
"03150ДУ801289",
"03150ДУ801290",
"03150ДУ801291",
"03150ДУ801524",
"03150ДУ801525",
"03150ДУ801535",
"03160ДУ801213",
"03160ДУ801215",
"03160ДУ801227",
"03160ДУ801239",
"03160ДУ801242",
"03160ДУ801243",
"03160ДУ801244",
"03160ДУ801297",
"03160ДУ801340",
"03160ДУ801415",
"03160ДУ801416",
"03160ДУ801434",
"03170ДУ801114",
"03170ДУ801146",
"03170ДУ801147",
"03170ДУ801306",
"03170ДУ801312",
"03170ДУ801319",
"03180ДУ801316",
"09140ДУ800012",
"09140ДУ800029",
"09140ДУ800017",
"09140ДУ800037",
"09140ДУ800040",
"09140ДУ800038",
"09140ДУ800047",
"09140ДУ800048",
"09140ДУ800066"
 };
            DirectoryInfo directory = new DirectoryInfo("Z:\\DU_files");
            var io1 = new ImageOperator();
            var uri =io1.SelectPhotos(directory, numbers, new List<string>() { "фото_свет" });
            foreach (var file in uri)
            {
               // io1.Print(file, new PrinterSettings(), new PageSettings());
            }
        }
    }
}
