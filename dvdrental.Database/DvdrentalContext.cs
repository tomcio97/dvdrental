using Microsoft.EntityFrameworkCore;

#nullable disable

namespace dvdrental.Entities
{
    public partial class DvdrentalContext : DbContext
    {
        public DvdrentalContext()
        {
        }

        public DvdrentalContext(DbContextOptions<DvdrentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmActor> FilmActors { get; set; }
        public virtual DbSet<FilmCategory> FilmCategories { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=dvdrental;User Id=postgres;Password=admin123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "mpaa_rating", new[] { "G", "PG", "PG-13", "R", "NC-17" })
                .HasAnnotation("Relational:Collation", "Polish_Poland.1250");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.HasIndex(e => e.LastName, "idx_actor_last_name");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.CityId, "idx_fk_city_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("address2");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("district");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_city");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CountryId, "idx_fk_country_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.City1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_city");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.AddressId, "idx_fk_address_id");

                entity.HasIndex(e => e.StoreId, "idx_fk_store_id");

                entity.HasIndex(e => e.LastName, "idx_last_name");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Activebool)
                    .IsRequired()
                    .HasColumnName("activebool")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("('now'::text)::date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_address_id_fkey");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film");

                entity.HasIndex(e => e.Fulltext, "film_fulltext_idx")
                    .HasMethod("gist");

                entity.HasIndex(e => e.LanguageId, "idx_fk_language_id");

                entity.HasIndex(e => e.Title, "idx_title");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Fulltext)
                    .IsRequired()
                    .HasColumnName("fulltext");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.ReleaseYear).HasColumnName("release_year");

                entity.Property(e => e.RentalDuration)
                    .HasColumnName("rental_duration")
                    .HasDefaultValueSql("3");

                entity.Property(e => e.RentalRate)
                    .HasPrecision(4, 2)
                    .HasColumnName("rental_rate")
                    .HasDefaultValueSql("4.99");

                entity.Property(e => e.ReplacementCost)
                    .HasPrecision(5, 2)
                    .HasColumnName("replacement_cost")
                    .HasDefaultValueSql("19.99");

                entity.Property(e => e.SpecialFeatures).HasColumnName("special_features");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_language_id_fkey");
            });

            modelBuilder.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.FilmId })
                    .HasName("film_actor_pkey");

                entity.ToTable("film_actor");

                entity.HasIndex(e => e.FilmId, "idx_fk_film_id");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.FilmActors)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_actor_actor_id_fkey");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmActors)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_actor_film_id_fkey");
            });

            modelBuilder.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId })
                    .HasName("film_category_pkey");

                entity.ToTable("film_category");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FilmCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_category_category_id_fkey");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmCategories)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_category_film_id_fkey");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.HasIndex(e => new { e.StoreId, e.FilmId }, "idx_store_id_film_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventory_film_id_fkey");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.CustomerId, "idx_fk_customer_id");

                entity.HasIndex(e => e.RentalId, "idx_fk_rental_id");

                entity.HasIndex(e => e.StaffId, "idx_fk_staff_id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasPrecision(5, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.PaymentDate).HasColumnName("payment_date");

                entity.Property(e => e.RentalId).HasColumnName("rental_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_customer_id_fkey");

                entity.HasOne(d => d.Rental)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("payment_rental_id_fkey");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_staff_id_fkey");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("rental");

                entity.HasIndex(e => e.InventoryId, "idx_fk_inventory_id");

                entity.HasIndex(e => new { e.RentalDate, e.InventoryId, e.CustomerId }, "idx_unq_rental_rental_date_inventory_id_customer_id")
                    .IsUnique();

                entity.Property(e => e.RentalId).HasColumnName("rental_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RentalDate).HasColumnName("rental_date");

                entity.Property(e => e.ReturnDate).HasColumnName("return_date");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rental_customer_id_fkey");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rental_inventory_id_fkey");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rental_staff_id_key");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasIndex(e => e.ManagerStaffId, "idx_unq_manager_staff_id")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ManagerStaffId).HasColumnName("manager_staff_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("store_address_id_fkey");

                entity.HasOne(d => d.ManagerStaff)
                    .WithOne(p => p.Store)
                    .HasForeignKey<Store>(d => d.ManagerStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("store_manager_staff_id_fkey");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Password)
                    .HasMaxLength(40)
                    .HasColumnName("password");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("username");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_address_id_fkey");
            });

            modelBuilder.HasSequence("actor_actor_id_seq");

            modelBuilder.HasSequence("address_address_id_seq");

            modelBuilder.HasSequence("category_category_id_seq");

            modelBuilder.HasSequence("city_city_id_seq");

            modelBuilder.HasSequence("country_country_id_seq");

            modelBuilder.HasSequence("customer_customer_id_seq");

            modelBuilder.HasSequence("film_film_id_seq");

            modelBuilder.HasSequence("inventory_inventory_id_seq");

            modelBuilder.HasSequence("language_language_id_seq");

            modelBuilder.HasSequence("payment_payment_id_seq");

            modelBuilder.HasSequence("rental_rental_id_seq");

            modelBuilder.HasSequence("staff_staff_id_seq");

            modelBuilder.HasSequence("store_store_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
