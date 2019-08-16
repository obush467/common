using CodeFirstStoreFunctions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using UNS.Models.Entities;
using UNS.Models.Entities.Address;

namespace UNS.Models
{
    public class UNSModel : DbContext
    {
        private SqlConnection sqlConnection;

        public UNSModel()
            : base(@"data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        { }
        public UNSModel(string connection) : base(connection)
        { }

        public UNSModel(SqlConnection sqlConnection) : base(sqlConnection, false)
        {
            this.sqlConnection = sqlConnection;
        }

        public virtual DbSet<ActualStatus> ActualStatuses { get; set; }
        public virtual DbSet<AddressObjectType> AddressObjectTypes { get; set; }
        public virtual DbSet<CenterStatus> CenterStatuses { get; set; }
        public virtual DbSet<CurrentStatus> CurrentStatuses { get; set; }
        public virtual DbSet<Del_NormativeDocument> Del_NormativeDocument { get; set; }
        public virtual DbSet<Del_Object> Del_Object { get; set; }
        public virtual DbSet<EstateStatus> EstateStatuses { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<HouseInterval> HouseInterval { get; set; }
        public virtual DbSet<HouseStateStatus> HouseStateStatus { get; set; }
        public virtual DbSet<NormativeDocument> NormativeDocument { get; set; }
        public virtual DbSet<NormativeDocumentType> NormativeDocumentType { get; set; }
        public virtual DbSet<OperationStatus> OperationStatus { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Stead> Stead { get; set; }
        public virtual DbSet<StructureStatus> StructureStatuses { get; set; }
        public virtual DbSet<Del_House> Del_House { get; set; }
        public virtual DbSet<BTIAdress> BTIAdress { get; set; }
        public virtual DbSet<AllAdress> AllAdress { get; set; }
        public virtual DbSet<AddressObject> AddressObjects { get; set; }
        public virtual DbSet<AO_Named> AO_Nameds { get; set; }
        public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<PersonPositionType> PersonPositionTypes { get; set; }
        public virtual DbSet<PersonPosition> PersonPositions { get; set; }
        public virtual DbSet<AccountantGeneralPosition> AccountantGeneralPositions { get; set; }
        public virtual DbSet<DirectorPosition> DirectorPositions { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<IntegraDUExcelLayout> IntegraDUExcelLayouts { get; set; }
        public virtual DbSet<IntegraDU> IntegraDU { get; set; }
        public virtual DbSet<Organization_House> Organization_Houses { get; set; }
        public virtual DbSet<FaxItem> FaxItems { get; set; }
        public virtual DbSet<EmailItem> EmailItems { get; set; }
        public virtual DbSet<OwnerRawAddress> ownerRawAddresses { get; set; }
        public virtual DbSet<RawAddress> RawAddresses { get; set; }
        public virtual DbSet<HouseFullBTI> HouseFullBTIs { get; set; }
        //public virtual DbSet<PersonPosition1> PersonPosition1 { get; set; }

        /*[DbFunction("UNS.Models.Entities", "BTI2018_UNOM")]
        public virtual IQueryable<BTI2018_UNOM_Result> BTI2018_UNOM(int? uNOM)
        {
            var uNOMParameter = uNOM.HasValue ?
                new ObjectParameter("UNOM", uNOM) :
                new ObjectParameter("UNOM", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<BTI2018_UNOM_Result>("[dbo].[BTI2018_UNOM](@UNOM)", uNOMParameter);
        }*/

        [DbFunction("UNSModel", "AddressOwnerFind")]
        public virtual IQueryable<AddressOwnerFind_Result> AddressOwnerFind(int? uNOM)
        {
            var uNOMParameter = uNOM.HasValue ?
                new ObjectParameter("UNOM", uNOM) :
                new ObjectParameter("UNOM", typeof(int));
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<AddressOwnerFind_Result>("UNSModel.[AddressOwnerFind](@UNOM)", uNOMParameter);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Organization>().HasKey(p => p.Id)
                .HasMany<PhoneItem>(m => m.PhoneItems).WithMany()
                .Map(m =>
                        {
                            m.ToTable("Organizations_Phones");
                            m.MapLeftKey("Organization_ID");
                            m.MapRightKey("PhoneItem_ID");
                        });
            modelBuilder.Entity<Organization>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Organization>().HasMany<FaxItem>(m => m.FaxItems).WithMany()
                    .Map(m =>
                    {
                        m.ToTable("Organizations_Faxes");
                        m.MapLeftKey("Organization_ID");
                        m.MapRightKey("FaxItem_ID");
                    });
            modelBuilder.Entity<Organization>().HasMany<EmailItem>(m => m.EmailItems).WithMany()
                    .Map(m =>
                        {
                            m.ToTable("Organizations_Emails");
                            m.MapLeftKey("Organization_ID");
                            m.MapRightKey("EmailItem_ID");                           
                        });

            //PersonPosition
            modelBuilder.Entity<PersonPosition>().ToTable("PersonPositions").HasKey(h => h.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PersonPosition>().HasRequired(h => h.Organization).WithRequiredDependent();
            modelBuilder.Entity<PersonPosition>().HasMany<PhoneItem>(m => m.Phones).WithMany()
                .Map(m =>
                        {
                            m.ToTable("PersonPositions_Phones");
                            m.MapLeftKey("PersonPosition_ID");
                            m.MapRightKey("PhoneItem_ID");
                        });
            modelBuilder.Entity<PersonPosition>().HasMany<FaxItem>(m => m.Faxes).WithMany()
                .Map(m =>
                        {
                            m.ToTable("PersonPositions_Faxes");
                            m.MapLeftKey("PersonPosition_ID");
                            m.MapRightKey("FaxItem_ID");
                        });
            modelBuilder.Entity<PersonPosition>().HasMany<EmailItem>(m => m.Emails).WithMany()
                .Map(m =>
                        {
                            m.ToTable("PersonPositions_EmailItems");
                            m.MapLeftKey("PersonPosition_ID");
                            m.MapRightKey("EmailItem_ID");
                        });

            //.Map<DirectorPosition>(m => { m.MapInheritedProperties();m.ToTable("DirectorPositions"); });
            //modelBuilder.Entity<PersonPosition1>().ToTable("PersonPositions1").HasRequired(h => h.Organization).WithMany();
            //.HasRequired(h => h.Organization).WithMany();//.HasForeignKey(r => r.Organization_Id);
            modelBuilder.Entity<DirectorPosition>().ToTable("DirectorPositions");
            //    m.MapInheritedProperties();
            modelBuilder.Entity<AccountantGeneralPosition>().ToTable("AccountantGeneralPositions");
            modelBuilder.Entity<RawAddress>()
                .ToTable("RawAddress")
                .HasKey(p => p.ID)
                .Property(p=>p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<OwnerRawAddress>()
                .ToTable("OwnerRawAddress")
                //.HasKey(p=>p.ID)
                .HasKey(p=>p.ID)
                .HasRequired(t=>t.Organization);
            modelBuilder.Conventions.Add(new FunctionsConvention<UNSModel>("dbo"));
            modelBuilder.ComplexType<AddressOwnerFind_Result>();
            //modelBuilder.Ignore<IntegraDUExcelLayout>();
            //modelBuilder.Ignore<EmailItem>();
            modelBuilder.Entity<AddressObjectType>()
                .Property(e => e.KOD_T_ST)
                .IsUnicode(false);
            modelBuilder.Entity<CenterStatus>()
                .Property(e => e.NAME)
                .IsUnicode(false);
            modelBuilder.Entity<Del_NormativeDocument>()
                .Property(e => e.DOCNAME)
                .IsUnicode(false);
            modelBuilder.Entity<Del_NormativeDocument>()
                .Property(e => e.DOCNUM)
                .IsUnicode(false);
            modelBuilder.Entity<Del_Object>()
                .Property(e => e.OFFNAME_NUMBER)
                .IsUnicode(false);
            modelBuilder.Entity<Del_Object>()
                .Property(e => e.OFFNAME_PREFIX)
                .IsUnicode(false);
            modelBuilder.Entity<Del_Object>()
                .Property(e => e.OFFNAME_NAME)
                .IsUnicode(false);
            modelBuilder.Entity<FlatType>()
                .Property(e => e.NAME)
                .IsUnicode(false);
            modelBuilder.Entity<FlatType>()
                .Property(e => e.SHORTNAME)
                .IsUnicode(false);
            modelBuilder.Entity<House>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);
            modelBuilder.Entity<House>()
                .Property(e => e.IFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.TERRIFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.IFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.TERRIFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.OKTMO)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.HOUSENUM)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.BUILDNUM)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.STRUCNUM)
                .IsUnicode(false);

            modelBuilder.Entity<House>()
                .Property(e => e.CADNUM)
                .IsUnicode(false);

            modelBuilder.Entity<HouseStateStatus>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

            modelBuilder.Entity<NormativeDocument>()
                .Property(e => e.DOCNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NormativeDocument>()
                .Property(e => e.DOCNUM)
                .IsUnicode(false);

            modelBuilder.Entity<NormativeDocument>()
                .HasOptional(e => e.NormativeDocument1)
                .WithRequired(e => e.NormativeDocument2);

            modelBuilder.Entity<NormativeDocumentType>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<NormativeDocumentType>()
                .HasMany(e => e.NormativeDocument)
                .WithRequired(e => e.NormativeDocumentType)
                .HasForeignKey(e => e.DOCTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OperationStatus>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.ROOMGUID)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.FLATNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.ROOMNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.REGIONCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.HOUSEGUID)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.ROOMID)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.PREVID)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.NEXTID)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.NORMDOC)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.CADNUM)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.ROOMCADNUM)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.REGIONCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.IFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.TERRIFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.IFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.TERRIFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.OKTMO)
                .IsUnicode(false);

            modelBuilder.Entity<Stead>()
                .Property(e => e.CADNUM)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.IFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.TERRIFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.IFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.TERRIFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.OKTMO)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.HOUSENUM)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.BUILDNUM)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.STRUCNUM)
                .IsUnicode(false);

            modelBuilder.Entity<Del_House>()
                .Property(e => e.CADNUM)
                .IsUnicode(false);
            modelBuilder.Entity<IntegraDUStages>()
                .HasKey(t => t.ID);
            modelBuilder.Entity<IntegraDU>()
                .HasRequired(t => t.IntegraDUStages);
        }
    }
}
