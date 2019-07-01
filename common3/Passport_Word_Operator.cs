using common.Office;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNSData;
using UNSData.Entities;

namespace common
{
    public class Passport_Word_Operator:Word_Operator,IOutDocument<IntegraDUExcelLayout>
    {
        protected DirectoryInfo _templateDir;
        protected DirectoryInfo _rootdir;
        public Passport_Word_Operator(DirectoryInfo templateDir, DirectoryInfo rootdir)
        {
            _rootdir = rootdir;
            _templateDir = templateDir;
        }

        public Passport_Word_Operator() : this(new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\"), new DirectoryInfo("c:\\Паспорта\\"))
        { }
        public void Create(IEnumerable<IntegraDUExcelLayout> integraDUExcelLayouts)
        {
            foreach (var integraDUExcelLayout in integraDUExcelLayouts)
            {
                Create(integraDUExcelLayout);
            }
        }
        public void Create(IntegraDUExcelLayout integraDUExcelLayout)
        {
            
            var flist = new List<FileInfo>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("UNIU", integraDUExcelLayout.UNIU);
            hashtable.Add("Okrug", integraDUExcelLayout.Okrug);
            hashtable.Add("District", integraDUExcelLayout.District);
            hashtable.Add("Address", string.Join(", ", integraDUExcelLayout.AddressObject, integraDUExcelLayout.AddressHouse));
            hashtable.Add("DUType", integraDUExcelLayout.DUType);
            hashtable.Add("date_of_manufacture", DateTime.Now.ToLongDateString());
            if (integraDUExcelLayout.ContentObjectFullPath != null && integraDUExcelLayout.ContentHouseFullPath != null)
            {
                var contentObjectFullPath = new FileInfo(integraDUExcelLayout.ContentObjectFullPath);
                if (contentObjectFullPath.Exists)
                {
                    hashtable.Add("obj1", new InsertedObject()
                    {
                        FromFile = contentObjectFullPath,
                        Height = 80,
                        Wight = 150
                    });
                }
                var contentHouseFullPath = new FileInfo(integraDUExcelLayout.ContentHouseFullPath);
                hashtable.Add("obj2", new InsertedObject()
                {
                    FromFile = contentHouseFullPath,
                    Height = 80,
                    Wight = 150
                });
            }
            else
                if (integraDUExcelLayout.ContentObjectFullPath != null && integraDUExcelLayout.ContentHouseFullPath == null)
            {
                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = new FileInfo(integraDUExcelLayout.ContentObjectFullPath),
                    Height = 80,
                    Wight = 150
                });
            }
            else
                if (integraDUExcelLayout.ContentObjectFullPath == null && integraDUExcelLayout.ContentHouseFullPath != null)

                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = new FileInfo(Path.ChangeExtension(integraDUExcelLayout.ContentHouseFullPath, "png")),
                    Height = 80,
                    Wight = 150
                });
            var schemeName = Path.Combine(_templateDir.FullName, "Схемы_в_тех_паспорт", integraDUExcelLayout.DUType + "_схема.png");
            hashtable.Add("lightScheme2", new InsertedObject()
            {
                FromFile = new FileInfo(schemeName),
                Height = 80,
                Wight = 150
            });
            hashtable.Add("lightScheme1", new InsertedObject()
            {
                FromFile = new FileInfo(Path.Combine(_templateDir.FullName, "Схемы_в_тех_паспорт", "схема_подключения_световой_арматуры.png")),
                Height = 80,
                Wight = 150
            });
            hashtable.Add("elScheme", new InsertedObject()
            {
                FromFile = new FileInfo(schemeName),
                Height = 80,
                Wight = 150
            });
            CreateFunc rt = (x, y) => DUTypesTable_Creator.Create(x, integraDUExcelLayout.DUType);
            hashtable.Add("tableDU", rt);

            DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(_rootdir.FullName), integraDUExcelLayout.UNIU).LocalPath);
            if (!saveDir.Exists) saveDir.Create();
            var newWordFileName = new FileInfo(Path.Combine(
                                        saveDir.FullName,
                                        Path.ChangeExtension(string.Join("_", integraDUExcelLayout.UNIU, "технический_паспорт", DateTime.Now.ToString("yyyyMMdd")),
                                    "docx")));

            (new Word_Operator()).CreateBookmarkedDocument(newWordFileName,
                _templateDir.GetFiles("Приложение5_Технический_паспорт4.dotx").SingleOrDefault(), hashtable);
            flist.Add(newWordFileName);

        }

        public void Print(IntegraDUExcelLayout integraDUExcelLayout)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<IntegraDUExcelLayout> integraDUExcelLayouts)
        {
            foreach (IntegraDUExcelLayout integraDUExcelLayout in integraDUExcelLayouts)
                Print(integraDUExcelLayout);
        }


    }
    }

