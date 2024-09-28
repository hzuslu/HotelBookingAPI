using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Otel.DataAccessLayer.Concrete;
using Otel.EntityLayer.Concrete;

public static class DataInitializer
{
    public static async Task TestDataAsync(IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        if (context != null)
        {
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            if (!context.Abouts.Any())
            {
                context.Abouts.Add(new About
                {
                    AboutId = 1,
                    Title1 = "Welcome to Our Luxury Resort",
                    Title2 = "Experience Unparalleled Comfort and Service",
                    Content = "Nestled in the heart of the city, our luxury resort offers world-class amenities, exceptional service, and a serene atmosphere. Whether you're here for business or leisure, we promise a memorable stay with our state-of-the-art facilities and warm hospitality.",
                    RoomCount = 250,
                    StaffCount = 150,
                    CustomerCount = 5000
                });
                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new AppRole
                    {
                        Id = 1,
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    new AppRole
                    {
                        Id = 2,
                        Name = "Manager",
                        NormalizedName = "MANAGER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    new AppRole
                    {
                        Id = 3,
                        Name = "Staff",
                        NormalizedName = "STAFF",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    new AppRole
                    {
                        Id = 4,
                        Name = "Customer",
                        NormalizedName = "CUSTOMER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Bookings.Any())
            {
                context.Bookings.AddRange(
                    new Booking
                    {
                        BookingId = 1,
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        CheckInDate = new DateTime(2024, 10, 10),
                        CheckOutDate = new DateTime(2024, 10, 15),
                        AdultCount = 2,
                        ChildCount = 1,
                        Room = "101",
                        SpecialRequest = "Late check-in, ocean view",
                        Status = BookingStatus.Confirmed
                    },
                    new Booking
                    {
                        BookingId = 2,
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        CheckInDate = new DateTime(2024, 10, 12),
                        CheckOutDate = new DateTime(2024, 10, 20),
                        AdultCount = 3,
                        ChildCount = 2,
                        Room = "205",
                        SpecialRequest = "Extra pillows",
                        Status = BookingStatus.Pending
                    },
                    new Booking
                    {
                        BookingId = 3,
                        Name = "Michael Johnson",
                        Email = "michael.johnson@example.com",
                        CheckInDate = new DateTime(2024, 10, 5),
                        CheckOutDate = new DateTime(2024, 10, 10),
                        AdultCount = 1,
                        ChildCount = 0,
                        Room = "302",
                        SpecialRequest = "High floor",
                        Status = BookingStatus.Cancelled
                    },
                    new Booking
                    {
                        BookingId = 4,
                        Name = "Emily Davis",
                        Email = "emily.davis@example.com",
                        CheckInDate = new DateTime(2024, 10, 8),
                        CheckOutDate = new DateTime(2024, 10, 12),
                        AdultCount = 2,
                        ChildCount = 0,
                        Room = "201",
                        SpecialRequest = "No specific requests",
                        Status = BookingStatus.Confirmed
                    },
                    new Booking
                    {
                        BookingId = 5,
                        Name = "David Wilson",
                        Email = "david.wilson@example.com",
                        CheckInDate = new DateTime(2024, 10, 15),
                        CheckOutDate = new DateTime(2024, 10, 20),
                        AdultCount = 2,
                        ChildCount = 1,
                        Room = "105",
                        SpecialRequest = "Adjacent rooms",
                        Status = BookingStatus.Completed
                    },
                    new Booking
                    {
                        BookingId = 6,
                        Name = "Olivia Brown",
                        Email = "olivia.brown@example.com",
                        CheckInDate = new DateTime(2024, 10, 1),
                        CheckOutDate = new DateTime(2024, 10, 5),
                        AdultCount = 1,
                        ChildCount = 0,
                        Room = "107",
                        SpecialRequest = "Vegetarian meals",
                        Status = BookingStatus.Confirmed
                    }
                );
                await context.SaveChangesAsync();
            }

            if (!context.MessageCategories.Any())
            {
                context.MessageCategories.AddRange(
                    new MessageCategory { MessageCategoryId = 1, MessageCategoryName = "General Inquiry" },
                    new MessageCategory { MessageCategoryId = 2, MessageCategoryName = "Booking Request" },
                    new MessageCategory { MessageCategoryId = 3, MessageCategoryName = "Feedback" },
                    new MessageCategory { MessageCategoryId = 4, MessageCategoryName = "Complaint" },
                    new MessageCategory { MessageCategoryId = 5, MessageCategoryName = "Service Request" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Contacts.Any())
            {
                context.Contacts.AddRange(
                    new Contact
                    {
                        Name = "Alice Johnson",
                        Email = "alice.johnson@example.com",
                        Subject = "Inquiry about room availability",
                        Message = "I would like to know if you have any rooms available for the weekend.",
                        Date = DateTime.Now.AddDays(-2),
                        MessageCategoryId = 1
                    },
                    new Contact
                    {
                        Name = "Bob Smith",
                        Email = "bob.smith@example.com",
                        Subject = "Feedback on my stay",
                        Message = "I had a great experience during my last stay. Thank you!",
                        Date = DateTime.Now.AddDays(-5),
                        MessageCategoryId = 2
                    },
                    new Contact
                    {
                        Name = "Charlie Brown",
                        Email = "charlie.brown@example.com",
                        Subject = "Cancellation request",
                        Message = "I need to cancel my reservation for next week.",
                        Date = DateTime.Now.AddDays(-1),
                        MessageCategoryId = 3
                    },
                    new Contact
                    {
                        Name = "Diana Prince",
                        Email = "diana.prince@example.com",
                        Subject = "Room service inquiry",
                        Message = "What are the available options for room service?",
                        Date = DateTime.Now.AddDays(-3),
                        MessageCategoryId = 1
                    },
                    new Contact
                    {
                        Name = "Ethan Hunt",
                        Email = "ethan.hunt@example.com",
                        Subject = "Lost item",
                        Message = "I left my jacket in the room after checkout. Can you help me?",
                        Date = DateTime.Now.AddDays(-4),
                        MessageCategoryId = 4
                    },
                    new Contact
                    {
                        Name = "Fiona Gallagher",
                        Email = "fiona.gallagher@example.com",
                        Subject = "Request for a special arrangement",
                        Message = "I would like to request a birthday surprise for my partner during our stay.",
                        Date = DateTime.Now.AddDays(-1),
                        MessageCategoryId = 5
                    }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Guests.Any())
            {
                context.Guests.AddRange(
                    new Guest { GuestId = 1, Name = "John", Surname = "Doe", City = "New York" },
                    new Guest { GuestId = 2, Name = "Jane", Surname = "Smith", City = "Los Angeles" },
                    new Guest { GuestId = 3, Name = "Michael", Surname = "Johnson", City = "Chicago" },
                    new Guest { GuestId = 4, Name = "Emily", Surname = "Davis", City = "Houston" },
                    new Guest { GuestId = 5, Name = "James", Surname = "Wilson", City = "Phoenix" },
                    new Guest { GuestId = 6, Name = "Mary", Surname = "Garcia", City = "Philadelphia" },
                    new Guest { GuestId = 7, Name = "David", Surname = "Martinez", City = "San Antonio" },
                    new Guest { GuestId = 8, Name = "Sarah", Surname = "Lopez", City = "San Diego" },
                    new Guest { GuestId = 9, Name = "Daniel", Surname = "Hernandez", City = "Dallas" },
                    new Guest { GuestId = 10, Name = "Laura", Surname = "Gonzalez", City = "San Jose" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room { RoomId = 1, RoomNumber = "101", RoomCoverImage = "room-1.jpg", Price = 150, Title = "Standard Room", BedCount = "1", BathCount = "1", Wifi = "true", Description = "A cozy standard room with all essential amenities." },
                    new Room { RoomId = 2, RoomNumber = "102", RoomCoverImage = "room-2.jpg", Price = 200, Title = "Deluxe Room", BedCount = "1", BathCount = "1", Wifi = "true", Description = "A spacious deluxe room with a beautiful view." },
                    new Room { RoomId = 3, RoomNumber = "201", RoomCoverImage = "room-3.jpg", Price = 250, Title = "Suite", BedCount = "2", BathCount = "2", Wifi = "true", Description = "An elegant suite with a separate living area." },
                    new Room { RoomId = 4, RoomNumber = "202", RoomCoverImage = "room-1.jpg", Price = 300, Title = "Family Room", BedCount = "3", BathCount = "1", Wifi = "true", Description = "A large family room with multiple beds." },
                    new Room { RoomId = 5, RoomNumber = "301", RoomCoverImage = "room-2.jpg", Price = 180, Title = "Business Room", BedCount = "1", BathCount = "1", Wifi = "true", Description = "A comfortable room equipped for business travelers." },
                    new Room { RoomId = 6, RoomNumber = "302", RoomCoverImage = "room-3.jpg", Price = 220, Title = "Luxury Room", BedCount = "1", BathCount = "1", Wifi = "true", Description = "A luxurious room with high-end furnishings." },
                    new Room { RoomId = 7, RoomNumber = "401", RoomCoverImage = "room-1.jpg", Price = 270, Title = "Penthouse", BedCount = "2", BathCount = "2", Wifi = "true", Description = "A stunning penthouse suite with panoramic views." }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service { ServiceId = 1, ServiceIcon = "fa fa-wifi fa-2x text-primary", Title = "Free Wi-Fi", Description = "Enjoy complimentary high-speed internet access throughout the property." },
                    new Service { ServiceId = 2, ServiceIcon = "fa fa-bicycle fa-2x text-primary", Title = "Fitness Center", Description = "Stay fit and healthy with our fully-equipped fitness center." },
                    new Service { ServiceId = 3, ServiceIcon = "fa fa-swimming-pool fa-2x text-primary", Title = "Swimming Pool", Description = "Take a refreshing dip in our outdoor swimming pool." },
                    new Service { ServiceId = 4, ServiceIcon = "fa fa-spa fa-2x text-primary", Title = "Spa Services", Description = "Relax and rejuvenate with our luxurious spa treatments." },
                    new Service { ServiceId = 5, ServiceIcon = "fa fa-utensils fa-2x text-primary", Title = "Room Service", Description = "Enjoy delicious meals delivered right to your room." },
                    new Service { ServiceId = 6, ServiceIcon = "fa fa-car fa-2x text-primary", Title = "Car Rental", Description = "Rent a car to explore the city at your convenience." },
                    new Service { ServiceId = 7, ServiceIcon = "fa fa-umbrella-beach fa-2x text-primary", Title = "Beach Access", Description = "Relax at our private beach area with lounge chairs." },
                    new Service { ServiceId = 8, ServiceIcon = "fa fa-concierge-bell fa-2x text-primary", Title = "Concierge Service", Description = "Our concierge is here to assist you with any requests." },
                    new Service { ServiceId = 9, ServiceIcon = "fa fa-parking fa-2x text-primary", Title = "Parking", Description = "Complimentary parking available for all guests." },
                    new Service { ServiceId = 10, ServiceIcon = "fa fa-coffee fa-2x text-primary", Title = "Coffee Shop", Description = "Enjoy a selection of beverages and snacks at our coffee shop." },
                    new Service { ServiceId = 11, ServiceIcon = "fa fa-child fa-2x text-primary", Title = "Kids Club", Description = "Fun activities for children in a safe environment." },
                    new Service { ServiceId = 12, ServiceIcon = "fa fa-shuttle-van fa-2x text-primary", Title = "Airport Shuttle", Description = "Convenient shuttle service to and from the airport." }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Staffs.Any())
            {
                context.Staffs.AddRange(
                    new Staff { StaffId = 1, Name = "John Doe", Title = "General Manager", Link1 = "team-1.jpg", Link2 = "https://www.linkedin.com/in/johndoe", Link3 = "https://www.twitter.com/johndoe" },
                    new Staff { StaffId = 2, Name = "Jane Smith", Title = "Front Desk Manager", Link1 = "team-2.jpg", Link2 = "https://www.linkedin.com/in/janesmith", Link3 = "https://www.twitter.com/janesmith" },
                    new Staff { StaffId = 3, Name = "Michael Brown", Title = "Head Chef", Link1 = "team-3.jpg", Link2 = "https://www.linkedin.com/in/michaelbrown", Link3 = "https://www.twitter.com/michaelbrown" },
                    new Staff { StaffId = 4, Name = "Emily Davis", Title = "Housekeeping Manager", Link1 = "team-4.jpg", Link2 = "https://www.linkedin.com/in/emilydavis", Link3 = "https://www.twitter.com/emilydavis" },
                    new Staff { StaffId = 5, Name = "Chris Johnson", Title = "Sales Manager", Link1 = "team-1.jpg", Link2 = "https://www.linkedin.com/in/chrisjohnson", Link3 = "https://www.twitter.com/chrisjohnson" },
                    new Staff { StaffId = 6, Name = "Sarah Wilson", Title = "Marketing Specialist", Link1 = "team-2.jpg", Link2 = "https://www.linkedin.com/in/sarahwilson", Link3 = "https://www.twitter.com/sarahwilson" },
                    new Staff { StaffId = 7, Name = "David Lee", Title = "Maintenance Supervisor", Link1 = "team-3.jpg", Link2 = "https://www.linkedin.com/in/davidlee", Link3 = "https://www.twitter.com/davidlee" },
                    new Staff { StaffId = 8, Name = "Laura Martinez", Title = "Event Coordinator", Link1 = "team-4.jpg", Link2 = "https://www.linkedin.com/in/lauramartinez", Link3 = "https://www.twitter.com/lauramartinez" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Testimonials.Any())
            {
                context.Testimonials.AddRange(
                    new Testimonial { TestimonialId = 1, Name = "Alice Johnson", Title = "Happy Customer", Description = "This resort exceeded my expectations! The staff was incredible, and the amenities were top-notch.", Image = "testimonial-1.jpg" },
                    new Testimonial { TestimonialId = 2, Name = "Robert Smith", Title = "Business Traveler", Description = "A perfect place for business meetings. The service is exceptional, and the environment is very professional.", Image = "testimonial-2.jpg" },
                    new Testimonial { TestimonialId = 3, Name = "Emma Brown", Title = "Leisure Traveler", Description = "I had a fantastic time here! The spa services were relaxing, and the pool was beautiful.", Image = "testimonial-3.jpg" },
                    new Testimonial { TestimonialId = 4, Name = "James Wilson", Title = "Family Vacationer", Description = "Our family loved every moment. There were activities for everyone, and the rooms were spacious.", Image = "testimonial-4.jpg" },
                    new Testimonial { TestimonialId = 5, Name = "Sophia Taylor", Title = "Wedding Guest", Description = "Attending a wedding here was magical! The location was stunning, and the staff catered to every need.", Image = "testimonial-1.jpg" },
                    new Testimonial { TestimonialId = 6, Name = "Michael Clark", Title = "Frequent Visitor", Description = "I come here every year! Consistently great service and beautiful surroundings.", Image = "testimonial-2.jpg" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.WorkLocations.Any())
            {
                context.WorkLocations.AddRange(
                    new WorkLocation { WorkLocationId = 1, WorkLocationCityName = "New York", WorkLocationCountry = "USA" },
                    new WorkLocation { WorkLocationId = 2, WorkLocationCityName = "London", WorkLocationCountry = "UK" },
                    new WorkLocation { WorkLocationId = 3, WorkLocationCityName = "Tokyo", WorkLocationCountry = "Japan" },
                    new WorkLocation { WorkLocationId = 4, WorkLocationCityName = "Paris", WorkLocationCountry = "France" },
                    new WorkLocation { WorkLocationId = 5, WorkLocationCityName = "Berlin", WorkLocationCountry = "Germany" },
                    new WorkLocation { WorkLocationId = 6, WorkLocationCityName = "Sydney", WorkLocationCountry = "Australia" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                AppUser appUser = new AppUser
                {
                    Name = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@example.com",
                    PhoneNumber = "123-456-7890",
                    City = "Ankara",
                    Department = "IT",
                    WorkLocationId = 1,
                };
                AppUser appUser2 = new AppUser
                {
                    Name = "Elif",
                    LastName = "Kaya",
                    UserName = "elifkaya",
                    Email = "elif.kaya@example.com",
                    PhoneNumber = "234-567-8901",
                    City = "İstanbul",
                    Department = "Marketing",
                    WorkLocationId = 2,
                };
                AppUser appUser3 = new AppUser
                {
                    Name = "Murat",
                    LastName = "Yılmaz",
                    UserName = "muratylmz",
                    Email = "murat.yilmaz@example.com",
                    PhoneNumber = "345-678-9012",
                    City = "İzmir",
                    Department = "Finance",
                    WorkLocationId = 3,
                };
                AppUser appUser4 = new AppUser
                {
                    Name = "Ayşe",
                    LastName = "Demir",
                    UserName = "aysedemir",
                    Email = "ayse.demir@example.com",
                    PhoneNumber = "456-789-0123",
                    City = "Bursa",
                    Department = "HR",
                    WorkLocationId = 4,
                };

                await userManager.CreateAsync(appUser, "Admin123.");
                await userManager.CreateAsync(appUser2, "ElifKaya123.");
                await userManager.CreateAsync(appUser3, "MuratYilmaz123.");
                await userManager.CreateAsync(appUser4, "AyseDemir123.");

                await context.SaveChangesAsync();
            }
        }
    }
}