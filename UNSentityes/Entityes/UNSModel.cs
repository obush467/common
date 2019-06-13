namespace UNSentityes.Entityes
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UNSModel : DbContext
    {
        public UNSModel()
            : base("name=UNSModel")
        {
        }

        public virtual DbSet<ActualStatus> ActualStatus { get; set; }
        public virtual DbSet<AddressObjectType> AddressObjectType { get; set; }
        public virtual DbSet<CenterStatus> CenterStatus { get; set; }
        public virtual DbSet<CurrentStatus> CurrentStatus { get; set; }
        public virtual DbSet<Del_NormativeDocument> Del_NormativeDocument { get; set; }
        public virtual DbSet<Del_Object> Del_Object { get; set; }
        public virtual DbSet<EstateStatus> EstateStatus { get; set; }
        public virtual DbSet<FlatType> FlatType { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseInterval> HouseInterval { get; set; }
        public virtual DbSet<HouseStateStatus> HouseStateStatus { get; set; }
        public virtual DbSet<IntervalStatus> IntervalStatus { get; set; }
        public virtual DbSet<Landmark> Landmark { get; set; }
        public virtual DbSet<NormativeDocument> NormativeDocument { get; set; }
        public virtual DbSet<NormativeDocumentType> NormativeDocumentType { get; set; }
        public virtual DbSet<Object> Object { get; set; }
        public virtual DbSet<Object_log> Object_log { get; set; }
        public virtual DbSet<OperationStatus> OperationStatus { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Stead> Stead { get; set; }
        public virtual DbSet<StructureStatus> StructureStatus { get; set; }
        public virtual DbSet<Del_House> Del_House { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BTIAdress> BTIAdress { get; set; }
        public virtual DbSet<AllAdress> AllAdress { get; set; }
        public virtual DbSet<IntegraDUExcel> IntegraDUExcel { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Object>()
                .Property(e => e.UPDATEDATE)
                .HasPrecision(3);

            modelBuilder.Entity<Object>()
                .Property(e => e.STARTDATE)
                .HasPrecision(3);

            modelBuilder.Entity<Object>()
                .Property(e => e.ENDDATE)
                .HasPrecision(3);

            modelBuilder.Entity<Object>()
                .Property(e => e.OFFNAME_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<Object>()
                .Property(e => e.OFFNAME_PREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<Object>()
                .Property(e => e.OFFNAME_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Object_log>()
                .Property(e => e.UPDATEDATE)
                .HasPrecision(3);

            modelBuilder.Entity<Object_log>()
                .Property(e => e.STARTDATE)
                .HasPrecision(3);

            modelBuilder.Entity<Object_log>()
                .Property(e => e.ENDDATE)
                .HasPrecision(3);

            modelBuilder.Entity<Object_log>()
                .Property(e => e.OFFNAME_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<Object_log>()
                .Property(e => e.OFFNAME_PREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<Object_log>()
                .Property(e => e.OFFNAME_NAME)
                .IsUnicode(false);

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

            modelBuilder.Entity<Address>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.UNOM)
                .IsUnicode(false);
        }
    }
}
