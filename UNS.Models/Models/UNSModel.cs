using CodeFirstStoreFunctions;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using UNS.Models.Configuration;
using UNS.Models.Entities;
using UNS.Models.Entities.Address;
using UNS.Models.Entities.Fias;
using UNS.Models.Models.Configuration;

namespace UNS.Models
{
    public class UNSModel : DbContext
    {
        public UNSModel()
            : base(@"data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        { }
        public UNSModel(string connection) : base(connection)
        { }

        public UNSModel(SqlConnection sqlConnection) : base(sqlConnection, false)
        {
        }
        public virtual DbSet<AdmArea> AdmAreas { get; set; }
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
        public virtual DbSet<IntegraDU> IntegraDU { get; set; }
        public virtual DbSet<IntegraDUStages> IntegraDUStages { get; set; }
        public virtual DbSet<Organization_House> Organization_Houses { get; set; }
        public virtual DbSet<PhoneItem> Phones { get; set; }
        public virtual DbSet<FaxItem> FaxItems { get; set; }
        public virtual DbSet<EmailItem> EmailItems { get; set; }
        public virtual DbSet<OwnerRawAddress> OwnerRawAddresses { get; set; }
        public virtual DbSet<RawAddress> RawAddresses { get; set; }
        public virtual DbSet<HouseFull> HouseFulls { get; set; }
        public virtual DbSet<HouseFullBTI> HouseFullBTIs { get; set; }
        public virtual DbSet<AddressBase> AddressBases { get; set; }
        public virtual DbSet<AddressCode> AddressCodes { get; set; }
        public virtual DbSet<AddressStatus> AddressStatuses { get; set; }
        public virtual DbSet<AddressAO> AddressAOs { get; set; }
        public virtual DbSet<AddressStead> AddressSteads { get; set; }
        public virtual DbSet<AddressRoom> AddressRooms { get; set; }
        public virtual DbSet<AddressHouse> AddressHouses { get; set; }
        public virtual DbSet<AddressCached> AddressCacheds { get; set; }
        public virtual DbSet<AddressCachedObject> AddressCachedObjects { get; set; }
        public virtual DbSet<AddressCachedObjectBuilding> AddressCachedObjectBuildings { get; set; }
        public virtual DbSet<AddressCachedObjectStead> AddressCachedObjectSteads { get; set; }
        public virtual DbSet<IntegraDU_work> IntegraDU_Works { get; set; }
        public virtual DbSet<IntegraDU_work_Installation> IntegraDU_Work_Installations { get; set; }
        public virtual DbSet<DUTechnicalCertificate> DUTechnicalCertificates { get; set; }
        public virtual DbSet<SimplifiedLetter> SimplifiedLetters { get; set; }
        public virtual DbSet<InstallationPlace> InstallationPlaces { get; set; }
        public virtual DbSet<InstallationPlaceBuilding> InstallationPlaceBuildings { get; set; }
        public virtual DbSet<ConstructionElement> ConstractionElements { get; set; }
        public virtual DbSet<LightBoxElement> LightBoxElements { get; set; }
        public virtual DbSet<LightBoxTwoFieldElement> LightBoxTwoFieldElements { get; set; }
        public virtual DbSet<TwoFieldElement> TwoFieldElements { get; set; }
        public virtual DbSet<DuU> DuUs { get; set; }
        public virtual DbSet<DuUD> DuUDs { get; set; }
        public virtual DbSet<DuS> DuS { get; set; }
        public virtual DbSet<DuLB_U> DuU { get; set; }
        public virtual DbSet<DuLB_UD> DuLB_UDs { get; set; }
        public virtual DbSet<DuLB_S> DuLB_S { get; set; }
        
        public virtual DbSet<LocationBase> LocationBases { get; set; }
        public virtual DbSet<LocationOneAddress> LocationOneAddresses { get; set; }
        public virtual DbSet<LocationManyAddress> LocationManyAddresses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<TechProject> TechProjects { get; set; }
        public virtual DbSet<AddressCachedObject_UNOM> UNOMs { get; set; }

        #region DBFUNCTIONS
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
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Class1());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());

            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new RawAddresConfiguration());
            modelBuilder.Configurations.Add(new OwnerRawAddressConfiguration());

            #region PositionsTypes CONFIG
            modelBuilder.Configurations.Add(new PersonPositionConfiguration());
            modelBuilder.Configurations.Add(new DirectorPositionConfiguration());
            modelBuilder.Configurations.Add(new AccountantGeneralPositionConfiguration());
            #endregion
            modelBuilder.Configurations.Add(new integraDUConfiguration());
            modelBuilder.Configurations.Add(new integraDUStagesConfiguration());
            modelBuilder.Configurations.Add(new integraDU_workConfiguration());
            #region FIAS CONGIG
            modelBuilder.Configurations.Add(new SteadConfiguration());
            modelBuilder.Configurations.Add(new HouseConfiguration());
            modelBuilder.Configurations.Add(new Del_HouseConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new NormativeDocumentConfiguration());
            modelBuilder.Configurations.Add(new Del_NormativeDocumentConfiguration());

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
            modelBuilder.Entity<HouseStateStatus>()
                .Property(e => e.NAME)
                .IsUnicode(false);
            modelBuilder.Entity<Landmark>()
                .Property(e => e.OKATO)
                .IsUnicode(false);

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
            #endregion
            #region New FIAS CONFIG
            modelBuilder.Configurations.Add(new AddressCodeConfiguration());                       
            modelBuilder.Configurations.Add(new AddressStatusConfiguration());
            modelBuilder.Configurations.Add(new AddressBaseConfiguration());
            modelBuilder.Configurations.Add(new AddressAOConfiguration());
            modelBuilder.Configurations.Add(new AddressSteadConfiguration());
            modelBuilder.Configurations.Add(new AddressHouseConfiguration());
            modelBuilder.Configurations.Add(new AddressRoomConfiguration());
            modelBuilder.Configurations.Add(new SimplifiedLetterConfiguration());
            modelBuilder.Configurations.Add(new LocationBaseConfiguration());
            modelBuilder.Configurations.Add(new LocationOneAddressConfiguration());
            modelBuilder.Configurations.Add(new LocationManyAddressConfiguration());
            #endregion
            #region Address CONFIG
            modelBuilder.Configurations.Add(new AddressCahedConfiguration());
            modelBuilder.Configurations.Add(new AddressCachedObjectConfiguration());
            modelBuilder.Configurations.Add(new AddressCachedObjectBuildingConfiguration());
            modelBuilder.Configurations.Add(new AddressCachedObjectSteadConfiguration());
            modelBuilder.Configurations.Add(new UNOM_ItemConfiguration());
            #endregion
            modelBuilder.Configurations.Add(new DUTechnicalCertificateConfiguration());
            modelBuilder.Conventions.Add(new FunctionsConvention<UNSModel>("dbo"));
            modelBuilder.ComplexType<AddressOwnerFind_Result>();

            modelBuilder.Configurations.Add(new InstallationPlaceConfiguration());
            modelBuilder.Configurations.Add(new InstallationPlaceBuildingConfiguration());
            modelBuilder.Configurations.Add(new LightingEquipmentConfiguration());
        }
    }
}
