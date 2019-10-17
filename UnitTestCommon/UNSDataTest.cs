using AutoMapper;
using bushAddon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models;
using UNS.Models.Entities;
using UNS.Models.Entities.Address;
using UNS.Models.Entities.Fias;
using UNS.Models.Mappers;
using Excel = Microsoft.Office.Interop.Excel;

namespace UnitTestCommon
{
    [TestClass]
    public class UNSDataTest
    {
        [TestMethod]
        public void MapExcelToDU()
        {
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open("C:\\Temp\\Этап 2.xlsx");
            var reestr = workbook.Sheets["Реестр"];
            IMapper mapper = (new MapperConfiguration(cfg => { cfg.AddProfile<DUExcel_Range_MapProfile>(); }).CreateMapper());
            var result = new List<IntegraDU>();
            foreach (Excel.Range row in reestr.Range["A1"].CurrentRegion.Rows)
            {
                var rowres = mapper.Map<Excel.Range, IntegraDU>(row);
                result.Add(rowres);
            }
        }

        [TestMethod]
        public void MapExcelToDU1()
        {
            var counter = 0;
            var counterLength = 100;
            var application = new Excel.Application();
            var e = new ExcelLoader(application);
            Excel.Workbook workbook = application.Workbooks.Open("C:\\Temp\\Этап 2.xlsx");
            Excel.Workbook workbook2 = application.Workbooks.Open("C:\\Temp\\Этап 21.xlsx");
            //application.Visible = false;
            var reestr = workbook.Sheets["Реестр"];
            var result = e.MapRows(reestr);
            var gr = ((IEnumerable<IntegraDU>)result).GroupBy(g => counter++ / counterLength);
            foreach (var g in gr)
            {
                e.MapRows(g.ToList(), workbook2.ActiveSheet);
                workbook2.Save();
            }
            application.Visible = true;
        }

        [TestMethod]
        public void DU_K_UD()
        {
            using (var context = new UNSModel())
            {
                /*var t = new DU_K_UD();
                context.Du_K_UD.Add(t);
                context.SaveChanges();*/
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void InsertPersons()
        {
            using (var context = new UNSModel(@"data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                var y = new Person() { Family = "dfgdfgd", Patronymic = "sdfsdfsdfsdf ", Name = "sfsdfsdf" };
                context.Persons.Add(y);
                context.SaveChanges();
                context.Persons.Remove(y);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertTechProject()
        {
            using (var context = new UNSModel())
            {
                var y = new TechProject()
                {
                    ProjectCode = Guid.NewGuid().ToString(),
                    ProjectDate = DateTime.Parse("2015-01-01"),
                    DocumentName = "Проект домового указателя \"ДУ\"",
                    Content = new List<Document>()
                };
                context.Set<TechProject>().Add(y);
                context.SaveChanges();
                context.Set<TechProject>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertDocument()
        {
            using (var context = new UNSModel())
            {
                var y = new Document() { DocumentName = "sfsdfsdf" };
                context.Set<Document>().Add(y);
                context.SaveChanges();
                context.Set<Document>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertSimpLetters()
        {
            using (var context = new UNSModel())
            {
                var y = new SimplifiedLetter() { DocumentName= "sfsdfsdf",OutgoingDate=DateTime.Now,Recipient="ssdfsdf" };
                context.Set<SimplifiedLetter>().Add(y);
                context.SaveChanges();
                context.Set<SimplifiedLetter>().Remove(y);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertAddressCached()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressCached() { ItemAddress = "sfsdfsdf" ,ItemCategory="xgdfgdfgdF",STARTDATE=DateTime.Now,ENDDATE=DateTime.Now,FullAddress="zdfzfa",ItemType="asdads",AddressGUID=Guid.NewGuid(),AddressPARENTGUID=Guid.NewGuid(),AddressID=Guid.NewGuid()};
                context.Set<AddressCached>().Add(y);
                context.SaveChanges();
                context.Set<AddressCached>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertAddressStatus()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" };
                context.Set<AddressStatus>().Add(y);
                context.SaveChanges();
                context.Set<AddressStatus>().Remove(y);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertAddressCode()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" };
                context.Set<AddressCode>().Add(y);
                context.SaveChanges();
                context.Set<AddressCode>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertAddressBase()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressBase() { ID=Guid.NewGuid(),GUID= Guid.NewGuid() };
                var y1 = new AddressBase()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    PREV =new List<AddressBase>() { y },
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" }
                };
                context.Set<AddressBase>().Add(y);
                context.Set<AddressBase>().Add(y1);
                context.SaveChanges();
                context.Set<AddressBase>().Remove(y);
                context.Set<AddressBase>().Remove(y1);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertAddressRoom()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressRoom() { ID = Guid.NewGuid(), GUID = Guid.NewGuid(),
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    FLATNUMBER = "sfsdfsd",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now,
                    FLATTYPE = 1
                };
                var y1 = new AddressRoom()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    PREV = new List<AddressBase>() { y },
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM="sdfsdfs",
                    FLATNUMBER="sfsdfsd",
                    ENDDATE=DateTime.Now,
                    STARTDATE=DateTime.Now,
                    FLATTYPE=1
                };
                context.Set<AddressRoom>().Add(y);
                context.Set<AddressRoom>().Add(y1);
                context.SaveChanges();
                context.Set<AddressRoom>().Remove(y);
                context.Set<AddressRoom>().Remove(y1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertAddressAOsAll()
        {
            using (var context = new UNSModel())
            {
                var mapper = new MapperConfiguration(cfg => cfg.AddProfile<Fias_MapProfile>()).CreateMapper();               
                var sel = context.AddressObjects.Take(100).ToList().ConvertAll(s => mapper.Map<AddressObject, AddressAO>(s));
                context.AddressAOs.AddRange(sel);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertAddressStead()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressStead()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now,
                    NUMBER ="dfdf"
                };
                var y1 = new AddressStead()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    PREV = new List<AddressBase>() { y },
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    NUMBER = "sfsdfsd",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now
                };
                context.Set<AddressStead>().Add(y);
                context.Set<AddressStead>().Add(y1);
                context.SaveChanges();
                context.Set<AddressStead>().Remove(y);
                context.Set<AddressStead>().Remove(y1);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertAddressHouse()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressHouse()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now,
                    ppp = "dfdf"
                };
                var y1 = new AddressHouse()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    PREV = new List<AddressBase>() { y },
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    ppp = "sfsdfsd",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now
                };
                context.Set<AddressHouse>().Add(y);
                context.Set<AddressHouse>().Add(y1);
                context.SaveChanges();
                context.Set<AddressHouse>().Remove(y);
                context.Set<AddressHouse>().Remove(y1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertInstallationPlace()
        {
            using (var context = new UNSModel())
            {
                var ip = new InstallationPlace()
                {
                    Location = (LocationBase)new LocationOneAddress()
                    {
                        Address = new AddressCached()
                        {
                            AddressID = Guid.NewGuid(),
                            AddressGUID = Guid.NewGuid(),
                            AddressPARENTGUID = Guid.NewGuid(),
                            STARTDATE=DateTime.Now,
                            ENDDATE=DateTime.Now,
                            FullAddress="sssdf",
                            ItemAddress="dhdfhdfgh",
                            ItemCategory="sdfsdfsd",
                            ItemType="sfdsfsdf"
                        },
                        AdministrativeArea = context.AdmAreas.FirstOrDefault(),
                        ClarificationOfLocation = "ddddddddddddddddddddddd"
                    },
                    InstallationPlaceType = "sfsfdsf",
                    RegistrationNumber = "23423423"                    
                };
                context.Set<InstallationPlace>().Add(ip);
                context.SaveChanges();
                context.Set<InstallationPlace>().Remove(ip);
                context.SaveChanges();
            }
            }

        [TestMethod]
        public void InsertInstallationPlaceDU()
        {
            using (var context = new UNSModel())
            {
                var ip = new InstallationPlaceBuilding()
                {
                    TechProject = new TechProject() { },
                    Location = new LocationOneAddress()
                    {
                        Address = new AddressCached()
                        {
                            AddressID = Guid.NewGuid(),
                            AddressGUID = Guid.NewGuid(),
                            AddressPARENTGUID = Guid.NewGuid(),
                            STARTDATE = DateTime.Now,
                            ENDDATE = DateTime.Now,
                            FullAddress = "sssdf",
                            ItemAddress = "dhdfhdfgh",
                            ItemCategory = "sdfsdfsd",
                            ItemType = "sfdsfsdf"
                        },
                        AdministrativeArea = context.AdmAreas.FirstOrDefault(),
                        ClarificationOfLocation = "ddddddddddddddddddddddd",
                    },
                    InstallationPlaceType = "sfsfdsf",
                    RegistrationNumber = "23423423"

                };
                context.Set<InstallationPlaceBuilding>().Add(ip);
                context.SaveChanges();
                context.Set<InstallationPlaceBuilding>().Remove(ip);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertDuD()
        {
            using (var context = new UNSModel())
            {
                var ip = new DuD()
                {
                    TechProject = new TechProject() { },
                    Location = new LocationOneAddress()
                    {
                        Address = new AddressCached()
                        {
                            AddressID = Guid.NewGuid(),
                            AddressGUID = Guid.NewGuid(),
                            AddressPARENTGUID = Guid.NewGuid(),
                            STARTDATE = DateTime.Now,
                            ENDDATE = DateTime.Now,
                            FullAddress = "sssdf",
                            ItemAddress = "dhdfhdfgh",
                            ItemCategory = "sdfsdfsd",
                            ItemType = "sfdsfsdf"
                        },
                        AdministrativeArea = context.AdmAreas.FirstOrDefault(),
                        ClarificationOfLocation = "ddddddddddddddddddddddd",
                    },
                    InstallationPlaceType = "sfsfdsf",
                    RegistrationNumber = "23423423",
                    ContentHouse=new ConstructionElement() { ContentText = "sdfsdfsdfsdf", Width = 100, Height = 666 }
                };
                context.Set<DuD>().Add(ip);
                context.SaveChanges();
                context.Set<DuD>().Remove(ip);
                context.SaveChanges();
            }
        }


        [TestMethod]
        public void InsertDuLB_D()
        {
            using (var context = new UNSModel())
            {
                var ip = new DuLB_UD()
                {
                    TechProject = new TechProject() { },
                    Location = new LocationOneAddress()
                    {
                        Address = new AddressCached()
                        {
                            AddressID = Guid.NewGuid(),
                            AddressGUID = Guid.NewGuid(),
                            AddressPARENTGUID = Guid.NewGuid(),
                            STARTDATE = DateTime.Now,
                            ENDDATE = DateTime.Now,
                            FullAddress = "sssdf",
                            ItemAddress = "dhdfhdfgh",
                            ItemCategory = "sdfsdfsd",
                            ItemType = "sfdsfsdf"
                        },
                        AdministrativeArea = context.AdmAreas.FirstOrDefault(),
                        ClarificationOfLocation = "ddddddddddddddddddddddd",
                    },
                    InstallationPlaceType = "sfsfdsf",
                    RegistrationNumber = "23423423",
                    ContentHouse = new LightBoxElement() { ContentText = "sdfsdfsdfsdf", Width = 100, Height = 666 ,MaxPower=50}
                };
                context.Set<DuLB_UD>().Add(ip);
                context.SaveChanges();
                context.Set<DuLB_UD>().Remove(ip);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertAddressAO()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressAO()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now,
                    FORMALNAME = "dfdf"
                };
                var y1 = new AddressAO()
                {
                    ID = Guid.NewGuid(),
                    GUID = Guid.NewGuid(),
                    PREV = new List<AddressBase>() { y },
                    Code = new AddressCode() { IFNSFL = "s", OKATO = "x", OKTMO = "z" },
                    RootStatus = new AddressStatus() { LIVESTATUS = true, OPERSTATUS = 1, REGIONCODE = "77" },
                    CADNUM = "sdfsdfs",
                    FORMALNAME = "sfsdfsd",
                    ENDDATE = DateTime.Now,
                    STARTDATE = DateTime.Now
                };
                context.Set<AddressAO>().Add(y);
                context.Set<AddressAO>().Add(y1);
                context.SaveChanges();
                context.Set<AddressAO>().Remove(y);
                context.Set<AddressAO>().Remove(y1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertAddressBasePrevNext()
        {
            using (var context = new UNSModel())
            {
                AddressBase prev;
                AddressBase next;
                prev = new AddressBase
                {
                    ID = Guid.NewGuid() ,
                    GUID =Guid.NewGuid(),CADNUM="PREV"
                };
                next = new AddressBase()
                {
                    ID = Guid.NewGuid() ,
                    GUID = Guid.NewGuid(),
                    PREV =new List<AddressBase>() { prev } ,
                    CADNUM ="NEXT"
                };
                prev.NEXT = new List<AddressBase>() { next };
                context.AddressBases.Add(prev);
                context.AddressBases.Add(next);
                context.SaveChanges();
                var t=prev.NEXT.Contains(next);
                var t1 = next.PREV.Contains(prev);
                if (!(t || t1)) throw new Exception("ssfsfsd");
                context.AddressBases.Remove(prev);
                context.AddressBases.Remove(next);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void aaa()
        {
            using (var context = new UNSModel())
            {
                var oo=context.AddressOwnerFind(445588);
            }
        }
        [TestMethod]
        public void ConvertFiasToFIas()
        {
            using (var context = new UNSModel())
            {
                var mapper = new MapperConfiguration(cfg => cfg.AddProfile<Fias_MapProfile>()).CreateMapper();
                var res = context.AddressObjects.Take(100).ToList();
                var sel=res.ConvertAll(s=>mapper.Map<AddressObject, AddressAO>(s)).ToList();
                context.AddressBases.AddRange(sel);
                context.SaveChanges();
                context.AddressBases.RemoveRange(sel);
                context.SaveChanges();
            }
        }

    }
}

