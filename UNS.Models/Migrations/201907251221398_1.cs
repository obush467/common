namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _1 : DbMigration
    {
        public override void Up()
        {/*
            CreateTable(
                "dbo.PersonPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Organization_Id = c.Guid(nullable: false),
                        Human_Id = c.Guid(),
                        PositionType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.Human_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.PersonPositionTypes", t => t.PositionType_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.Human_Id)
                .Index(t => t.PositionType_Id);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DocumentName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShortName = c.String(maxLength: 300),
                        FullName = c.String(maxLength: 1000),
                        OGRN = c.String(maxLength: 30),
                        INN = c.String(maxLength: 12),
                        KPP = c.String(maxLength: 9),
                        UrAddress = c.String(maxLength: 1000),
                        OKPO = c.String(maxLength: 10),
                        OKATO = c.String(maxLength: 11),
                        OKTMTO = c.String(maxLength: 11),
                        OKOGU = c.String(maxLength: 7),
                        WebSite = c.String(maxLength: 100),
                        OrganizationType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationType_Id)
                .Index(t => t.OrganizationType_Id);
            
            CreateTable(
                "dbo.PersonPositionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PositionType = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShortTypeName = c.String(maxLength: 100),
                        FullTypeName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "fias.ActualStatus",
                c => new
                    {
                        ACTSTATID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ACTSTATID);
            
            CreateTable(
                "fias.AddressObjects",
                c => new
                    {
                        AOID = c.Guid(nullable: false),
                        AOGUID = c.Guid(),
                        FORMALNAME = c.String(maxLength: 120),
                        REGIONCODE = c.String(maxLength: 2),
                        AUTOCODE = c.String(maxLength: 1),
                        AREACODE = c.String(maxLength: 3),
                        CITYCODE = c.String(maxLength: 3),
                        CTARCODE = c.String(maxLength: 3),
                        PLACECODE = c.String(maxLength: 3),
                        STREETCODE = c.String(maxLength: 4),
                        EXTRCODE = c.String(maxLength: 4),
                        SEXTCODE = c.String(maxLength: 3),
                        OFFNAME = c.String(maxLength: 120),
                        POSTALCODE = c.String(maxLength: 6),
                        IFNSFL = c.String(maxLength: 4),
                        TERRIFNSFL = c.String(maxLength: 4),
                        IFNSUL = c.String(maxLength: 4),
                        TERRIFNSUL = c.String(maxLength: 4),
                        OKATO = c.String(maxLength: 11),
                        OKTMO = c.String(maxLength: 11),
                        UPDATEDATE = c.DateTime(precision: 7, storeType: "datetime2"),
                        SHORTNAME = c.String(maxLength: 10),
                        AOLEVEL = c.Int(nullable: false),
                        PARENTGUID = c.Guid(),
                        PREVID = c.Guid(),
                        NEXTID = c.Guid(),
                        CODE = c.String(maxLength: 17),
                        PLAINCODE = c.String(maxLength: 15),
                        ACTSTATUS = c.Int(),
                        CENTSTATUS = c.Int(),
                        OPERSTATUS = c.Int(),
                        CURRSTATUS = c.Int(),
                        STARTDATE = c.DateTime(precision: 7, storeType: "datetime2"),
                        ENDDATE = c.DateTime(precision: 7, storeType: "datetime2"),
                        NORMDOC = c.Guid(),
                        LIVESTATUS = c.Boolean(),
                        CADNUM = c.String(maxLength: 100),
                        DIVTYPE = c.Int(),
                        PLANCODE = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.AOID);
            
            CreateTable(
                "fias.AddressObjectType",
                c => new
                    {
                        LEVEL = c.Int(nullable: false),
                        SCNAME = c.String(maxLength: 10),
                        SOCRNAME = c.String(maxLength: 50),
                        KOD_T_ST = c.String(maxLength: 4, unicode: false),
                    })
                .PrimaryKey(t => t.LEVEL);
            
            CreateTable(
                "fias.AllAdress",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PARENTGUID = c.Guid(),
                        itemAddress = c.String(maxLength: 500),
                        fullAddress = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BTIAdress",
                c => new
                    {
                        UNOM = c.Int(nullable: false),
                        Adress = c.String(maxLength: 300),
                        HOUSEGUID = c.Guid(),
                    })
                .PrimaryKey(t => t.UNOM);
            
            CreateTable(
                "fias.CenterStatus",
                c => new
                    {
                        CENTERSTID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CENTERSTID);
            
            CreateTable(
                "fias.CurrentStatus",
                c => new
                    {
                        CURENTSTID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CURENTSTID);
            
            CreateTable(
                "fias.Del_House",
                c => new
                    {
                        HOUSEID = c.Guid(nullable: false),
                        POSTALCODE = c.String(maxLength: 6, unicode: false),
                        IFNSFL = c.String(maxLength: 4, unicode: false),
                        TERRIFNSFL = c.String(maxLength: 4, unicode: false),
                        IFNSUL = c.String(maxLength: 4, unicode: false),
                        TERRIFNSUL = c.String(maxLength: 4, unicode: false),
                        OKATO = c.String(maxLength: 11, unicode: false),
                        OKTMO = c.String(maxLength: 11, unicode: false),
                        UPDATEDATE = c.DateTime(storeType: "smalldatetime"),
                        HOUSENUM = c.String(maxLength: 20, unicode: false),
                        ESTSTATUS = c.Int(nullable: false),
                        BUILDNUM = c.String(maxLength: 10, unicode: false),
                        STRUCNUM = c.String(maxLength: 10, unicode: false),
                        STRSTATUS = c.Int(),
                        HOUSEGUID = c.Guid(nullable: false),
                        AOGUID = c.Guid(),
                        STARTDATE = c.DateTime(nullable: false),
                        ENDDATE = c.DateTime(nullable: false),
                        STATSTATUS = c.Int(),
                        NORMDOC = c.Guid(),
                        COUNTER = c.Int(),
                        CADNUM = c.String(maxLength: 100, unicode: false),
                        DIVTYPE = c.Int(),
                    })
                .PrimaryKey(t => t.HOUSEID);
            
            CreateTable(
                "fias.Del_NormativeDocument",
                c => new
                    {
                        NORMDOCID = c.Guid(nullable: false),
                        DOCNAME = c.String(maxLength: 500, unicode: false),
                        DOCDATE = c.DateTime(storeType: "smalldatetime"),
                        DOCNUM = c.String(maxLength: 20, unicode: false),
                        DOCTYPE = c.Long(nullable: false),
                        DOCIMGID = c.Guid(),
                    })
                .PrimaryKey(t => t.NORMDOCID);
            
            CreateTable(
                "fias.Del_Object",
                c => new
                    {
                        AOID = c.Guid(nullable: false),
                        AOGUID = c.Guid(),
                        FORMALNAME = c.String(maxLength: 120),
                        REGIONCODE = c.String(maxLength: 2),
                        AUTOCODE = c.String(maxLength: 1),
                        AREACODE = c.String(maxLength: 3),
                        CITYCODE = c.String(maxLength: 3),
                        CTARCODE = c.String(maxLength: 3),
                        PLACECODE = c.String(maxLength: 3),
                        STREETCODE = c.String(maxLength: 4),
                        EXTRCODE = c.String(maxLength: 4),
                        SEXTCODE = c.String(maxLength: 3),
                        OFFNAME = c.String(maxLength: 120),
                        POSTALCODE = c.String(maxLength: 6),
                        IFNSFL = c.String(maxLength: 4),
                        TERRIFNSFL = c.String(maxLength: 4),
                        IFNSUL = c.String(maxLength: 4),
                        TERRIFNSUL = c.String(maxLength: 4),
                        OKATO = c.String(maxLength: 11),
                        OKTMO = c.String(maxLength: 11),
                        UPDATEDATE = c.DateTime(),
                        SHORTNAME = c.String(maxLength: 10),
                        AOLEVEL = c.Int(),
                        PARENTGUID = c.Guid(),
                        PREVID = c.Guid(),
                        NEXTID = c.Guid(),
                        CODE = c.String(maxLength: 17),
                        PLAINCODE = c.String(maxLength: 15),
                        ACTSTATUS = c.Int(),
                        CENTSTATUS = c.Int(),
                        OPERSTATUS = c.Int(),
                        CURRSTATUS = c.Int(),
                        STARTDATE = c.DateTime(),
                        ENDDATE = c.DateTime(),
                        NORMDOC = c.Guid(),
                        LIVESTATUS = c.String(maxLength: 1),
                        CADNUM = c.String(maxLength: 100),
                        DIVTYPE = c.Int(),
                        OFFNAME_NUM_TYPE = c.Int(),
                        OFFNAME_NUM_NUMBER = c.Int(),
                        OFFNAME_NUM_PREFIX = c.Int(),
                        OFFNAME_NUMBER = c.String(maxLength: 20, unicode: false),
                        OFFNAME_PREFIX = c.String(maxLength: 20, unicode: false),
                        OFFNAME_NAME = c.String(maxLength: 80, unicode: false),
                        CONVERTSTREET = c.String(maxLength: 50),
                        PLANCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AOID);
            
            CreateTable(
                "fias.EstateStatus",
                c => new
                    {
                        ESTSTATID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 50),
                        SHORTNAME = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ESTSTATID);
            
            CreateTable(
                "fias.HouseInterval",
                c => new
                    {
                        HOUSEINTID = c.Guid(nullable: false),
                        POSTALCODE = c.String(maxLength: 6),
                        IFNSFL = c.String(maxLength: 4),
                        TERRIFNSFL = c.String(maxLength: 4),
                        IFNSUL = c.String(maxLength: 4),
                        TERRIFNSUL = c.String(maxLength: 4),
                        OKATO = c.String(maxLength: 11),
                        OKTMO = c.String(maxLength: 11),
                        UPDATEDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        INTSTART = c.Int(nullable: false),
                        INTEND = c.Int(nullable: false),
                        INTGUID = c.Guid(),
                        AOGUID = c.Guid(),
                        STARTDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ENDDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        INTSTATUS = c.Int(),
                        NORMDOC = c.Guid(),
                        COUNTER = c.Int(nullable: false),
                        IntervalStatus_INTVSTATID = c.Int(),
                    })
                .PrimaryKey(t => t.HOUSEINTID)
                .ForeignKey("fias.IntervalStatus", t => t.IntervalStatus_INTVSTATID)
                .Index(t => t.IntervalStatus_INTVSTATID);
            
            CreateTable(
                "fias.IntervalStatus",
                c => new
                    {
                        INTVSTATID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.INTVSTATID);
            
            CreateTable(
                "fias.House",
                c => new
                    {
                        HOUSEID = c.Guid(nullable: false),
                        POSTALCODE = c.String(maxLength: 6, unicode: false),
                        IFNSFL = c.String(maxLength: 4, unicode: false),
                        TERRIFNSFL = c.String(maxLength: 4, unicode: false),
                        IFNSUL = c.String(maxLength: 4, unicode: false),
                        TERRIFNSUL = c.String(maxLength: 4, unicode: false),
                        OKATO = c.String(maxLength: 11, unicode: false),
                        OKTMO = c.String(maxLength: 11, unicode: false),
                        UPDATEDATE = c.DateTime(storeType: "smalldatetime"),
                        HOUSENUM = c.String(maxLength: 20, unicode: false),
                        ESTSTATUS = c.Int(nullable: false),
                        BUILDNUM = c.String(maxLength: 10, unicode: false),
                        STRUCNUM = c.String(maxLength: 10, unicode: false),
                        STRSTATUS = c.Int(),
                        HOUSEGUID = c.Guid(nullable: false),
                        AOGUID = c.Guid(),
                        STARTDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ENDDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        STATSTATUS = c.Int(),
                        NORMDOC = c.Guid(),
                        COUNTER = c.Int(),
                        CADNUM = c.String(maxLength: 100, unicode: false),
                        DIVTYPE = c.Int(),
                    })
                .PrimaryKey(t => t.HOUSEID);
            
            CreateTable(
                "address.AdmArea",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ParentId = c.Guid(),
                        FullName = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        AreaType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "fias.HouseStateStatus",
                c => new
                    {
                        HOUSESTID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.HOUSESTID);
            
            CreateTable(
                "fias.NormativeDocument",
                c => new
                    {
                        NORMDOCID = c.Guid(nullable: false),
                        DOCNAME = c.String(maxLength: 500, unicode: false),
                        DOCDATE = c.DateTime(),
                        DOCNUM = c.String(maxLength: 20, unicode: false),
                        DOCTYPE = c.Long(nullable: false),
                        DOCIMGID = c.Guid(),
                        NormativeDocument2_NORMDOCID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.NORMDOCID)
                .ForeignKey("fias.NormativeDocument", t => t.NormativeDocument2_NORMDOCID)
                .ForeignKey("fias.NormativeDocumentType", t => t.DOCTYPE)
                .Index(t => t.DOCTYPE)
                .Index(t => t.NormativeDocument2_NORMDOCID);
            
            CreateTable(
                "fias.NormativeDocumentType",
                c => new
                    {
                        NDTYPEID = c.Long(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.NDTYPEID);
            
            CreateTable(
                "fias.OperationStatus",
                c => new
                    {
                        OPERSTATID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.OPERSTATID);
            
            CreateTable(
                "dbo.Organization_House",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        HouseGUID = c.Guid(nullable: false),
                        Source = c.String(),
                        Contacts = c.String(),
                        TypeRelation = c.String(maxLength: 50),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "fias.Room",
                c => new
                    {
                        ROOMID = c.String(nullable: false, maxLength: 50, unicode: false),
                        ROOMGUID = c.String(maxLength: 50, unicode: false),
                        FLATNUMBER = c.String(nullable: false, maxLength: 50, unicode: false),
                        FLATTYPE = c.Int(nullable: false),
                        ROOMNUMBER = c.String(maxLength: 50, unicode: false),
                        ROOMTYPE = c.Int(),
                        REGIONCODE = c.String(maxLength: 2, unicode: false),
                        POSTALCODE = c.String(maxLength: 6, unicode: false),
                        UPDATEDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        HOUSEGUID = c.String(maxLength: 50, unicode: false),
                        PREVID = c.String(maxLength: 50, unicode: false),
                        NEXTID = c.String(maxLength: 50, unicode: false),
                        STARTDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ENDDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        LIVESTATUS = c.Boolean(nullable: false),
                        NORMDOC = c.String(maxLength: 50, unicode: false),
                        OPERSTATUS = c.Long(nullable: false),
                        CADNUM = c.String(maxLength: 100, unicode: false),
                        ROOMCADNUM = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ROOMID);
            
            CreateTable(
                "fias.Stead",
                c => new
                    {
                        STEADID = c.Guid(nullable: false),
                        STEADGUID = c.Guid(),
                        NUMBER = c.String(maxLength: 120, unicode: false),
                        REGIONCODE = c.String(maxLength: 2, unicode: false),
                        POSTALCODE = c.String(maxLength: 6, unicode: false),
                        IFNSFL = c.String(maxLength: 4, unicode: false),
                        TERRIFNSFL = c.String(maxLength: 4, unicode: false),
                        IFNSUL = c.String(maxLength: 4, unicode: false),
                        TERRIFNSUL = c.String(maxLength: 4, unicode: false),
                        OKATO = c.String(maxLength: 11, unicode: false),
                        OKTMO = c.String(maxLength: 11, unicode: false),
                        UPDATEDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        PARENTGUID = c.Guid(),
                        PREVID = c.Guid(),
                        NEXTID = c.Guid(),
                        OPERSTATUS = c.Long(nullable: false),
                        STARTDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ENDDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        NORMDOC = c.Guid(),
                        LIVESTATUS = c.Int(nullable: false),
                        CADNUM = c.String(maxLength: 100, unicode: false),
                        DIVTYPE = c.Int(nullable: false),
                        COUNTER = c.Int(),
                    })
                .PrimaryKey(t => t.STEADID);
            
            CreateTable(
                "fias.StructureStatus",
                c => new
                    {
                        STRSTATID = c.Int(nullable: false),
                        NAME = c.String(nullable: false, maxLength: 50),
                        SHORTNAME = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.STRSTATID);
            
            CreateTable(
                "fias.FlatType",
                c => new
                    {
                        FLTYPEID = c.Long(nullable: false),
                        NAME = c.String(maxLength: 4000, unicode: false),
                        SHORTNAME = c.String(maxLength: 4000, unicode: false),
                    })
                .PrimaryKey(t => t.FLTYPEID);
            
            CreateTable(
                "fias.Landmark",
                c => new
                    {
                        LANDID = c.String(nullable: false, maxLength: 50),
                        LOCATION = c.String(maxLength: 1000),
                        REGIONCODE = c.String(maxLength: 2),
                        POSTALCODE = c.String(maxLength: 6),
                        IFNSFL = c.String(maxLength: 4),
                        TERRIFNSFL = c.String(maxLength: 4),
                        IFNSUL = c.String(maxLength: 4),
                        TERRIFNSUL = c.String(maxLength: 4),
                        OKATO = c.String(maxLength: 11, unicode: false),
                        OKTMO = c.String(maxLength: 11),
                        UPDATEDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        LANDGUID = c.String(maxLength: 50),
                        AOGUID = c.Guid(),
                        STARTDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ENDDATE = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        NORMDOC = c.Guid(),
                        CADNUM = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.LANDID);
            
            CreateTable(
                "dbo.IntegraDUStages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.Int(),
                        DUType = c.String(nullable: false, maxLength: 10),
                        Okrug = c.String(nullable: false, maxLength: 50),
                        District = c.String(nullable: false, maxLength: 50),
                        AddressObject = c.String(nullable: false, maxLength: 255),
                        AddressHouse = c.String(nullable: false, maxLength: 50),
                        ContentObject = c.String(maxLength: 255),
                        ContentHouse = c.String(maxLength: 50),
                        InstallationStatus = c.String(maxLength: 255),
                        UNOM = c.Int(nullable: false),
                        Stage = c.String(maxLength: 50),
                        UNIU = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccountantGeneralPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstDocument_Id = c.Guid(),
                        AccountantGeneral = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonPositions", t => t.Id)
                .ForeignKey("dbo.Documents", t => t.InstDocument_Id)
                .Index(t => t.Id)
                .Index(t => t.InstDocument_Id);
            
            CreateTable(
                "address.AO_Named",
                c => new
                    {
                        AOID = c.Guid(nullable: false),
                        OFFNAME_NUM_TYPE = c.Int(),
                        OFFNAME_NUM_NUMBER = c.Int(),
                        OFFNAME_NUM_PREFIX = c.Int(),
                        OFFNAME_NUMBER = c.String(maxLength: 20),
                        OFFNAME_PREFIX = c.String(maxLength: 20),
                        OFFNAME_NAME = c.String(maxLength: 80),
                        CONVERTSTREET = c.String(maxLength: 300),
                        OFFNAME_NUM_NAME = c.Int(),
                        OMK_2013 = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.AOID)
                .ForeignKey("fias.AddressObjects", t => t.AOID)
                .Index(t => t.AOID);
            
            CreateTable(
                "dbo.integraDU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IntegraDUStages_ID = c.Guid(nullable: false),
                        Хто = c.String(maxLength: 255),
                        БТИТипстен = c.String(name: "БТИ - Тип стен", maxLength: 255),
                        БТИНазначение = c.String(name: "БТИ - Назначение", maxLength: 255),
                        Заключение = c.String(maxLength: 255),
                        Примечания = c.String(maxLength: 255),
                        Типстен = c.String(name: "Тип стен", maxLength: 255),
                        Принадлежность = c.String(maxLength: 255),
                        Типсъёмки = c.String(name: "Тип съёмки", maxLength: 255),
                        Контактныеданные = c.String(name: "Контактные данные", maxLength: 255),
                        РуководительФИО = c.String(name: "Руководитель ФИО", maxLength: 255),
                        Должностьруководителя = c.String(name: "Должность руководителя", maxLength: 255),
                        номерисхписьма = c.String(name: "номер исх письма", maxLength: 255),
                        Датаисхписьма = c.DateTime(name: "Дата исх письма"),
                        Наличиеответавход = c.String(name: "Наличие ответа вход", maxLength: 255),
                        Датасогласования = c.DateTime(name: "Дата согласования"),
                        Датапередачивпроизводство = c.DateTime(name: "Дата передачи в производство"),
                        ОТКАЗ = c.DateTime(),
                        ХОТЕЛКИнаМОНТАЖА = c.DateTime(name: "ХОТЕЛКИ на МОНТАЖА"),
                        Готовокмонтажу = c.String(name: "Готово к монтажу", maxLength: 255),
                        Датавыдвмонтаж = c.String(name: "Дата выд в монтаж", maxLength: 255),
                        Датамонтажа = c.String(name: "Дата монтажа", maxLength: 255),
                        Датаподключения = c.String(name: "Дата подключения", maxLength: 255),
                        WGS84 = c.String(maxLength: 50),
                        EGKO_X = c.String(maxLength: 50),
                        EGKO_Y = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IntegraDUStages", t => t.ID)
                .ForeignKey("dbo.IntegraDUStages", t => t.IntegraDUStages_ID)
                .Index(t => t.ID)
                .Index(t => t.IntegraDUStages_ID);
            
            CreateTable(
                "dbo.DirectorPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstDocument_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                        Director = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonPositions", t => t.Id)
                .ForeignKey("dbo.Documents", t => t.InstDocument_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Id)
                .Index(t => t.InstDocument_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "address.HouseFull",
                c => new
                    {
                        HOUSEID = c.Guid(nullable: false),
                        Address = c.String(),
                        UNOM = c.Int(),
                        AdmAreaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.HOUSEID)
                .ForeignKey("fias.House", t => t.HOUSEID)
                .ForeignKey("address.AdmArea", t => t.AdmAreaId, cascadeDelete: true)
                .Index(t => t.HOUSEID)
                .Index(t => t.AdmAreaId);
            */
        }

        public override void Down()
        {/*
            DropForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea");
            DropForeignKey("address.HouseFull", "HOUSEID", "fias.House");
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.DirectorPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.integraDU", "IntegraDUStages_ID", "dbo.IntegraDUStages");
            DropForeignKey("dbo.integraDU", "ID", "dbo.IntegraDUStages");
            DropForeignKey("address.AO_Named", "AOID", "fias.AddressObjects");
            DropForeignKey("dbo.AccountantGeneralPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.AccountantGeneralPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropForeignKey("dbo.Organization_House", "Organization_Id", "dbo.Organizations");
            DropForeignKey("fias.NormativeDocument", "DOCTYPE", "fias.NormativeDocumentType");
            DropForeignKey("fias.NormativeDocument", "NormativeDocument2_NORMDOCID", "fias.NormativeDocument");
            DropForeignKey("fias.HouseInterval", "IntervalStatus_INTVSTATID", "fias.IntervalStatus");
            DropForeignKey("dbo.Organizations", "OrganizationType_Id", "dbo.OrganizationTypes");
            DropIndex("address.HouseFull", new[] { "AdmAreaId" });
            DropIndex("address.HouseFull", new[] { "HOUSEID" });
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Id" });
            DropIndex("dbo.integraDU", new[] { "IntegraDUStages_ID" });
            DropIndex("dbo.integraDU", new[] { "ID" });
            DropIndex("address.AO_Named", new[] { "AOID" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "Id" });
            DropIndex("dbo.Organization_House", new[] { "Organization_Id" });
            DropIndex("fias.NormativeDocument", new[] { "NormativeDocument2_NORMDOCID" });
            DropIndex("fias.NormativeDocument", new[] { "DOCTYPE" });
            DropIndex("fias.HouseInterval", new[] { "IntervalStatus_INTVSTATID" });
            DropIndex("dbo.Organizations", new[] { "OrganizationType_Id" });
            DropIndex("dbo.PersonPositions", new[] { "PositionType_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Human_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            DropTable("address.HouseFull");
            DropTable("dbo.DirectorPositions");
            DropTable("dbo.integraDU");
            DropTable("address.AO_Named");
            DropTable("dbo.AccountantGeneralPositions");
            DropTable("dbo.IntegraDUStages");
            DropTable("fias.Landmark");
            DropTable("fias.FlatType");
            DropTable("fias.StructureStatus");
            DropTable("fias.Stead");
            DropTable("fias.Room");
            DropTable("dbo.Organization_House");
            DropTable("fias.OperationStatus");
            DropTable("fias.NormativeDocumentType");
            DropTable("fias.NormativeDocument");
            DropTable("fias.HouseStateStatus");
            DropTable("address.AdmArea");
            DropTable("fias.House");
            DropTable("fias.IntervalStatus");
            DropTable("fias.HouseInterval");
            DropTable("fias.EstateStatus");
            DropTable("fias.Del_Object");
            DropTable("fias.Del_NormativeDocument");
            DropTable("fias.Del_House");
            DropTable("fias.CurrentStatus");
            DropTable("fias.CenterStatus");
            DropTable("dbo.BTIAdress");
            DropTable("fias.AllAdress");
            DropTable("fias.AddressObjectType");
            DropTable("fias.AddressObjects");
            DropTable("fias.ActualStatus");
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.PersonPositionTypes");
            DropTable("dbo.Organizations");
            DropTable("dbo.Documents");
            DropTable("dbo.Persons");
            DropTable("dbo.PersonPositions");*/
        }
    }
}
