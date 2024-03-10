using Travelista.Data;
using Travelista.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Travelista.Helpers
{
	public class SeedData
	{
		public static void Seed()
		{
			using var context = new ApplicationDbContext();
			context.Database.EnsureCreated();

			if(!context.TripTypes.Any())
			{
				context.TripTypes.AddRange(new List<TripType>()
				{
					new TripType(){Name = "Group Trip"}, //id = 1
					new TripType(){Name = "One Day Trip"}, // 2
					new TripType(){Name = "Honey Moon Package"}, //3
				});
			}

			if (!context.Countries.Any())
			{
				context.Countries.AddRange(new List<Country>()
				{
					new Country(){Name = "Egypt"}, // id = 1
					new Country(){Name = "Spain"}, // 2
					new Country(){Name = "Turkey"}, // 3
					new Country(){Name = "Italy"}, //4
					new Country(){Name = "Lebnan"}, //5
				});
			}

			if(!context.Trips.Any())
			{
				context.Trips.AddRange(new List<Trip>()
				{
					new Trip()
					{
						Name = "Nile Cruise From Aswan To Luxor",
						Program = "Sail down one of the world's most famous waterways as you discover top attractions in southern Egypt. During this multi-day cruise from Aswan to Luxor, you'll disembark for guided visits to the region's most iconic sites, including Kom Ombo, the Valley of Kings, and Philae Temple. Tasty onboard meals are included, plus a personalized pickup from the airport, train station, or your Aswan hotel. A multi-day,five-star Nile cruise from Aswan to Luxor Tick off the region's top attractions in just a few days Listen to in-depth histories from your Egyptologist guide during tours Sleep comfortably with onboard luxury accommodation and enjoy VIP meals",
						Description = "3 nights’ accommodation on board 5\r\n* Nile cruise – based on FB basis. Meet and assist by English-speaking representatives. Egyptology English-speaking tour guide. All transfers by A-C vehicles with qualified driver (s) All local taxes and services. Hot Air Balloon Ride Over Luxor Sky Sharing a small group to Abu Simbel with English Speaking tour guide. Dinner (3) Breakfast (3) Lunch (3)",
						Cost =  349.00,
						CountryId = 1,
						TripTypeID = 1,
						Duration = 4,
						Capacity = 100,
						StartDate = new DateTime(12/4/2024).Date,
						Images = new List<Image>()
						{
							new Image()
							{
								ImageURL = "Nile Cruise From Aswan To Luxor "+1+".jpg"
							},
							new Image()
							{
								ImageURL = "Nile Cruise From Aswan To Luxor "+2+".jpg"
							},
							new Image()
							{
								ImageURL = "Nile Cruise From Aswan To Luxor "+3+".jpg"
							}
						}
					},
					new Trip()
					{

						Name = "Day trip from Sharm el Sheikh to Cairo by plane",
						Program = "Experience the largest museum for ancient Egyptian art with its treasures from Egypt's great past such as the gold coffin of King Tutankhamun with all its elaborate and high-quality grave goods. Our tour guide will explain the most important exhibits to you in a humorous two-hour stay and answer your questions. Marvel at the last existing wonder of the world - a fabulous experience! You will find a total of three pyramids here: the Chephren, Cheops and Mykerinos pyramids. You can discover the area on foot, on horseback or by camel. After visiting the pyramids of Giza, you will go to the Great Sphinx, by far the largest and most preserved sphinx. It consists of a human head on a lion's body.The Sphinx was carved from the remainder of a limestone mound that served as a quarry for the Great Pyramid of Cheops.Felucca ride on the Nile.In consultation with the tour group for a fee.",
						Description = "You will be picked up from your hotel around 4 a.m. After your arrival in Cairo, you will be met by your guide, who will accompany you throughout the tour. The excursion begins with a visit to the Egyptian Museum, which, in addition to its 120,000 exhibits, also houses Tutankhamun's golden coffin. Then enjoy your lunch. The further course of the excursion takes you to the great pyramids of Cheops, Chephren and Mykerinus. The tour of the pyramids ends at the Sphinx and the temple in its vicinity. At the end of the day, if time permits, you will have the opportunity to drive to the Cairo bazaar before starting the return journey to Sharm el Sheikh. Upon arrival at the airport, you will be driven to your hotel in an air-conditioned vehicle.",
						Cost =  252.19,
						CountryId = 1,
						TripTypeID = 2,
						Duration = 1,
						Capacity = 50,
						StartDate = new DateTime(20/5/2024).Date,
						Images = new List<Image>()
						{
							new Image()
							{
								ImageURL = "Day trip from Sharm el Sheikh to Cairo by plane "+1+".jpg"
							},
							new Image()
							{
								ImageURL = "Day trip from Sharm el Sheikh to Cairo by plane "+2+".jpg"
							},
							new Image()
							{
								ImageURL = "Day trip from Sharm el Sheikh to Cairo by plane "+3+".jpg"
							}
						}
					},
					new Trip()
					{
						Name = "Siwa Oasis all inclusive 3 days Tour from Cairo or Giza",
						Program = "Start your exclusive journey with a convenient pickup in an air-conditioned vehicle from Cairo. Travel in your own private transportation and relax as you take rest stops, eat snacks, and get to know your guide. Next, hop on a 4-wheel-drive vehicle through the Great Sand Sea. Here you can experience a variety of desert activities, including dune bashing, sandboarding, and viewing the desert sunset. After your day of sand sports, move on and discover the hidden treasures of Siwa. View everything from the salt lakes and ancient ruins to the picturesque Fatnis Island. Take the opportunity to swim in a tranquil lake and spend a night in a desert camp.",
						Description = "The Siwa oasis is one of the Western Desert’s most magical areas, but it’s more than an 8-hour drive from Cairo. Say no to hellish bus journeys and yes to the comfort of your own private vehicle with rest stops, snack breaks, and a guide. Explore the Great Sand Sea by 4WD, with dune bashing, sandboarding, and a desert sunset; see salt lakes, ancient ruins, Fatnis Island, and more. See Siwa and the Great Sand Sea direct from your central Cairo or Giza hotel Great choice for active travelers—includes sandboarding and a lake swim Enjoy a night in a desert camp and another in an oasis lodge Make memories for a lifetime on a private tour just for your group",
						Duration = 3,
						Capacity = 70,
						StartDate = new DateTime(1/4/2024).Date,
						TripTypeID = 1,
						CountryId = 1,
						Cost = 315.00,
						Images = new List<Image>()
						{
							new Image(){ ImageURL = "Siwa Oasis all inclusive 3 days Tour from Cairo or Giza "+1+".jpg"},
							new Image(){ ImageURL = "Siwa Oasis all inclusive 3 days Tour from Cairo or Giza "+2+".jpg"},
							new Image(){ ImageURL = "Siwa Oasis all inclusive 3 days Tour from Cairo or Giza "+3+".jpg"},
						}
					}
				});
			}

		}
	}
}
