using CodeFirstStoreFunctions;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using UNS.Models.Entities;
using UNS.Models.Entities.Address;

namespace UNS.Models
{
    public class UNSModel : DbContext
    {
        private EntityConnection connection;

        public UNSModel()
            : base(@"data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        { }

        public UNSModel(string connection) : base(connection)
        { }

        public UNSModel(EntityConnection connection)
        {
            this.connection = connection;
        }

        public virtual DbSet<ActualStatus> ActualStatuses { get; set; }
        public virtual DbSet<AddressObjectType> AddressObjectTypes { get; set; }
        public virtual DbSet<CenterStatus> CenterStatuses { get; set; }
        public virtual DbSet<CurrentStatus> CurrentStatuses { get; set; }
        public virtual DbSet<Del_NormativeDocument> Del_NormativeDocument { get; set; }
        public virtual DbSet<Del_Object> Del_Object { get; set; }
        public virtual DbSet<EstateStatus> EstateStatuses { get; set; }
        public virtual DbSet<FlatType> FlatTypes { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<HouseInterval> HouseInterval { get; set; }
        public virtual DbSet<HouseStateStatus> HouseStateStatus { get; set; }
        public virtual DbSet<IntervalStatus> IntervalStatuses { get; set; }
        public virtual DbSet<Landmark> Landmark { get; set; }
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
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<IntegraDUExcelLayout> IntegraDUExcelLayouts { get; set; }
        //public virtual DbSet<integraDUExcel> IntegraDUExcels { get; set; }
        public virtual DbSet<Organization_House> Organization_Houses { get; set; }

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
            modelBuilder.Conventions.Add(new FunctionsConvention<UNSModel>("dbo"));
            modelBuilder.ComplexType<AddressOwnerFind_Result>();
            //  modelBuilder.Ignore<IntegraDUExcelLayout>();
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

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.IFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.TERRIFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.IFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.TERRIFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

            modelBuilder.Entity<HouseInterval>()
                .Property(e => e.OKTMO)
                .IsUnicode(false);

            modelBuilder.Entity<HouseStateStatus>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<IntervalStatus>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<IntervalStatus>()
                .HasMany(e => e.HouseInterval)
                .WithOptional(e => e.IntervalStatus)
                .HasForeignKey(e => e.INTSTATUS);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.LOCATION)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.REGIONCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.IFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.TERRIFNSFL)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.IFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.TERRIFNSUL)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.OKTMO)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.LANDID)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.LANDGUID)
                .IsUnicode(false);

            modelBuilder.Entity<Landmark>()
                .Property(e => e.CADNUM)
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
            modelBuilder.Entity<integraDUStages>()
                .HasKey(t => t.ID);
            //modelBuilder.Entity<integraDUExcel>()
            //  .HasRequired(t=> t.IntegraDUStages)
            //.ma
            //;
        }
    }
}
