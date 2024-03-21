using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Xml;
using Travelista.Areas.Identity.Data;
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

			if (!context.TripTypes.Any())
			{
				context.TripTypes.AddRange(new List<TripType>()
				{
					new TripType(){Name = "Group Trip"}, //id = 1
					new TripType(){Name = "One Day Trip"}, //id = 2
					new TripType(){Name = "Honey Moon Package"}, //id = 3
				});
			}

			if (!context.Countries.Any())
			{
				context.Countries.AddRange(new List<Country>()
				{
					new Country(){Name = "Egypt"},           //1
					new Country(){Name = "Spain"},	         //2
					new Country(){Name = "Turkey"},          //3
					new Country(){Name = "Italy"},           //4
					new Country(){Name = "Lebanon"},         //5
				});
			}

			if (!context.Trips.Any())
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
							},
							new Image()
							{
								ImageURL = "Nile Cruise From Aswan To Luxor "+4+".jpg"
							},
							new Image()
							{
								ImageURL = "Nile Cruise From Aswan To Luxor "+5+".jpg"
							},
							new Image()
							{
								ImageURL = "Nile Cruise From Aswan To Luxor "+6+".jpg"
							}
						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "John Wick" , Email = "john@yahoo.com" , Message = "Had an absolutely wonderful trip! The scenic views, friendly locals, and delicious food made it an unforgettable experience. Would definitely recommend it to others."},
							new TripReView() { Username = "Elsa Shite" , Email = "elsa@gmail.com" , Message = "The landscapes on this trip were simply breathtaking. From majestic mountains to serene beaches, every stop was a feast for the eyes. Couldn't have asked for a better getaway."},
							new TripReView() { Username = "Sarah Stones" , Email = "sarah123@email.com" , Message = "Stayed at a charming bed and breakfast during my trip. The cozy atmosphere, friendly hosts, and delicious homemade breakfast added a delightful touch to the overall experience."},
							new TripReView() { Username = "Bruce Wayne" , Email = "WayneBruce@yahoo.com" , Message = "This trip was a cultural delight! Explored museums, historical sites, and local markets. Learning about the rich history of the region was both educational and enjoyable."},
							new TripReView() { Username = "Jenifer Adams" , Email = "jeniferadams@gmail.com" , Message = "For the adventure seekers, this trip is a must! From thrilling hikes to exciting water activities, there's no shortage of adrenaline-pumping experiences."},
							new TripReView() { Username = "Ahmad Khalid" , Email = "khalidahmad@yahoo.com" , Message = "A culinary journey awaits anyone on this trip. Indulged in the local cuisine and discovered new flavors. The variety of food options catered to every palate."},
							new TripReView() { Username = "Mohamed Elsaied" , Email = "elsaied@yahoo.com" , Message = "Found the perfect spot for a relaxing retreat. The tranquil surroundings, soothing spa, and peaceful ambiance provided the ideal escape from the hustle and bustle of daily life."},
							new TripReView() { Username = "Rana Tarek" , Email = "rana@yahoo.com" , Message = "The locals were incredibly friendly and welcoming. Their warmth added a special touch to the trip, making it feel like home away from home."},
							new TripReView() { Username = "Arwa Hassan" , Email = "arwa@gmail.com" , Message = "Kudos to the tour organizers for a well-planned itinerary. Every day was filled with exciting activities, and I felt like I made the most out of my time."},
							new TripReView() { Username = "Aya Waled" , Email = "aya@yahoo.com" , Message = "This trip created memories that will last a lifetime. From sunrise at a scenic lookout to stargazing by the beach, each moment was special and unforgettable. Can't wait to plan the next adventure!"},
							new TripReView() { Username = "Mohamed Ali", Email = "mohamed.ali@gmail.com", Message = "Explored vibrant markets and local stalls. The hustle and bustle of the markets added an exciting flair to the trip. Bargaining for unique finds was a memorable experience."},
							new TripReView() { Username = "Laila Mahmoud", Email = "laila.mahmoud@hotmail.com", Message = "Cruise along picturesque rivers and canals. The serene boat rides through scenic waterways were a peaceful way to appreciate the beauty of the surroundings."},
							new TripReView() { Username = "Amr Hossam", Email = "amr.hossam@yahoo.com", Message = "Stunning architecture and historic landmarks. Visited iconic structures and learned about the rich history behind each monument. The blend of old and new was captivating."},
							new TripReView() { Username = "Yara Samy", Email = "yara.samy@gmail.com", Message = "Camping under the stars in the wilderness. The clear night sky and crackling campfire created a magical atmosphere. Sleeping under the stars was an unforgettable experience."},
							new TripReView() { Username = "Ahmed Tarek", Email = "ahmed.tarek@hotmail.com", Message = "Local music and dance performances. The rhythmic beats and colorful performances added a cultural touch to the trip. Enjoyed every moment of the lively entertainment."},
							new TripReView() { Username = "Fatma Hassan", Email = "fatma.hassan@yahoo.com", Message = "Hot air balloon ride at sunrise. Soaring above the landscapes as the sun painted the sky with warm hues. The panoramic views were simply breathtaking."},
							new TripReView() { Username = "Tamer Hany", Email = "tamer.hany@gmail.com", Message = "Visited artisan workshops and witnessed traditional craftsmanship. Interacted with skilled artisans and appreciated the dedication put into crafting unique handmade items."},
							new TripReView() { Username = "Salma Hesham", Email = "salma.hesham@hotmail.com", Message = "Local folklore and storytelling sessions. Listened to captivating tales and legends passed down through generations. The storytelling added a magical touch to the evenings."},
							new TripReView() { Username = "Kareem Mahmoud", Email = "kareem.mahmoud@yahoo.com", Message = "Scenic train journeys through picturesque landscapes. The rhythmic sound of the train wheels and the changing scenery outside the window made the journey an adventure in itself."},
							new TripReView() { Username = "Nada Salah", Email = "nada.salah@gmail.com", Message = "Attended local festivals and celebrations. Participated in the joyous atmosphere of vibrant festivals. The lively music, colorful decorations, and festive spirit were infectious."},
						}
					},    //1
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
							},
							new Image()
							{
								ImageURL = "Day trip from Sharm el Sheikh to Cairo by plane "+4+".jpg"
							}
						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "John Doe", Email = "john.doe@gmail.com", Message = "Had an amazing time exploring new places. The local culture and cuisine were fantastic. The scenic beauty left me in awe, and I can't wait to plan my next adventure."},
							new TripReView() { Username = "Alice Smith", Email = "alice.smith@hotmail.com", Message = "The natural beauty of the landscapes left me speechless. A perfect getaway for nature lovers. Every moment felt like a dream, and I highly recommend this trip to others."},
							new TripReView() { Username = "Michael Johnson", Email = "michael.johnson@yahoo.com", Message = "Stayed in a charming cottage. The hosts were incredibly hospitable, and the surroundings were peaceful. It was a home away from home."},
							new TripReView() { Username = "Emily Davis", Email = "emily.davis@gmail.com", Message = "Explored historical landmarks and museums. A journey through time and culture. The rich history of the region made the trip both educational and fascinating."},
							new TripReView() { Username = "Robert Brown", Email = "robert.brown@hotmail.com", Message = "Thrilling adventures at every turn! Hiking, water sports, and more. Perfect for adrenaline junkies. The experiences were unforgettable, and I can't wait to share my stories."},
							new TripReView() { Username = "Sophia Miller", Email = "sophia.miller@yahoo.com", Message = "Indulged in local delicacies. The variety of flavors and dishes were a culinary delight. The food journey was a highlight, and I discovered new and delicious dishes."},
							new TripReView() { Username = "Daniel Wilson", Email = "daniel.wilson@gmail.com", Message = "Relaxing retreat in a spa resort. The serene atmosphere and rejuvenating treatments were heavenly. It was a much-needed break, and I returned refreshed and revitalized."},
							new TripReView() { Username = "Olivia Moore", Email = "olivia.moore@hotmail.com", Message = "The locals were friendly and welcoming. Their hospitality made the trip even more memorable. I felt like a part of the community, and the warmth of the people added a special touch."},
							new TripReView() { Username = "William Taylor", Email = "william.taylor@yahoo.com", Message = "Well-planned itinerary with exciting activities every day. Made the most out of every moment. The tour organizers did an excellent job, and I had a blast throughout the trip."},
							new TripReView() { Username = "Ella White", Email = "ella.white@gmail.com", Message = "Created lasting memories. Sunrise views and stargazing by the beach were magical. The breathtaking moments made the trip truly special, and I can't wait to cherish these memories."},
							new TripReView() { Username = "Liam Harris", Email = "liam.harris@gmail.com", Message = "Explored hidden gems and off-the-beaten-path locations. The sense of adventure was invigorating, and I discovered places that are truly hidden treasures."},
							new TripReView() { Username = "Ava Martinez", Email = "ava.martinez@hotmail.com", Message = "Stayed in a luxury villa with breathtaking views. The accommodation was top-notch, and waking up to panoramic scenes made the trip feel like a dream."},
							new TripReView() { Username = "Noah Turner", Email = "noah.turner@yahoo.com", Message = "Immersive cultural experiences with local communities. Shared stories, traditions, and laughter. The connection with the culture was enriching and heartwarming."},
							new TripReView() { Username = "Isabella Hall", Email = "isabella.hall@gmail.com", Message = "A photographer's paradise! Every corner was a picturesque scene. Captured moments that will adorn my photo album for years to come."},
							new TripReView() { Username = "Mason Flores", Email = "mason.flores@hotmail.com", Message = "Gourmet delights at every meal. From street food to fine dining, the culinary journey was a gastronomic adventure. A paradise for food enthusiasts."},
							new TripReView() { Username = "Aria King", Email = "aria.king@yahoo.com", Message = "Adventurous road trips and scenic drives. Explored the beauty of landscapes through winding roads and scenic routes. The journey was as exciting as the destinations."},
							new TripReView() { Username = "Carter Wright", Email = "carter.wright@gmail.com", Message = "Art and architecture tour through vibrant cities. Explored galleries, street art, and iconic landmarks. A treat for art lovers and history enthusiasts alike."},
							new TripReView() { Username = "Scarlett Hill", Email = "scarlett.hill@hotmail.com", Message = "Eco-friendly retreat surrounded by nature. The eco-conscious accommodations and sustainable practices added an eco-friendly touch to the travel experience."},
							new TripReView() { Username = "Lucas Adams", Email = "lucas.adams@yahoo.com", Message = "Sunset cruises and beachfront relaxation. Unwinding by the water with mesmerizing sunsets. The calming sound of waves provided the perfect backdrop for relaxation."},
							new TripReView() { Username = "Zoe Clark", Email = "zoe.clark@gmail.com", Message = "Educational tours with expert guides. Explored historical sites and learned fascinating facts from knowledgeable guides. The educational aspect added depth to the overall journey."},
						}
						},	  //2
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
							new Image(){ ImageURL = "Siwa Oasis all inclusive 3 days Tour from Cairo or Giza "+4+".jpg"},
							new Image(){ ImageURL = "Siwa Oasis all inclusive 3 days Tour from Cairo or Giza "+5+".jpg"},


						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "Ahmed Khalid", Email = "ahmed.khalid@gmail.com", Message = "Had an amazing time exploring new places. The local culture and cuisine were fantastic. The scenic beauty left me in awe, and I can't wait to plan my next adventure."},
							new TripReView() { Username = "Fatima Ibrahim", Email = "fatima.ibrahim@hotmail.com", Message = "The natural beauty of the landscapes left me speechless. A perfect getaway for nature lovers. Every moment felt like a dream, and I highly recommend this trip to others."},
							new TripReView() { Username = "Youssef Mohamed", Email = "youssef.mohamed@yahoo.com", Message = "Stayed in a charming cottage. The hosts were incredibly hospitable, and the surroundings were peaceful. It was a home away from home."},
							new TripReView() { Username = "Lina Ali", Email = "lina.ali@gmail.com", Message = "Explored historical landmarks and museums. A journey through time and culture. The rich history of the region made the trip both educational and fascinating."},
							new TripReView() { Username = "Omar Hassan", Email = "omar.hassan@hotmail.com", Message = "Thrilling adventures at every turn! Hiking, water sports, and more. Perfect for adrenaline junkies. The experiences were unforgettable, and I can't wait to share my stories."},
							new TripReView() { Username = "Nour Ahmed", Email = "nour.ahmed@yahoo.com", Message = "Indulged in local delicacies. The variety of flavors and dishes were a culinary delight. The food journey was a highlight, and I discovered new and delicious dishes."},
							new TripReView() { Username = "Sara Mohamed", Email = "sara.mohamed@gmail.com", Message = "Relaxing retreat in a spa resort. The serene atmosphere and rejuvenating treatments were heavenly. It was a much-needed break, and I returned refreshed and revitalized."},
							new TripReView() { Username = "Khaled Ali", Email = "khaled.ali@hotmail.com", Message = "The locals were friendly and welcoming. Their hospitality made the trip even more memorable. I felt like a part of the community, and the warmth of the people added a special touch." },
							new TripReView() { Username = "Ali Youssef", Email = "ali.youssef@gmail.com", Message = "Explored hidden gems and off-the-beaten-path locations. The sense of adventure was invigorating, and I discovered places that are truly hidden treasures."},
							new TripReView() { Username = "Nour Ahmed", Email = "nour.ahmed@hotmail.com", Message = "Stayed in a luxury villa with breathtaking views. The accommodation was top-notch, and waking up to panoramic scenes made the trip feel like a dream."},
							new TripReView() { Username = "Omar Mohamed", Email = "omar.mohamed@yahoo.com", Message = "Immersive cultural experiences with local communities. Shared stories, traditions, and laughter. The connection with the culture was enriching and heartwarming."},
							new TripReView() { Username = "Sara Ismail", Email = "sara.ismail@gmail.com", Message = "A photographer's paradise! Every corner was a picturesque scene. Captured moments that will adorn my photo album for years to come."},
							new TripReView() { Username = "Hassan Amir", Email = "hassan.amir@hotmail.com", Message = "Gourmet delights at every meal. From street food to fine dining, the culinary journey was a gastronomic adventure. A paradise for food enthusiasts."},
							new TripReView() { Username = "Maya Samir", Email = "maya.samir@yahoo.com", Message = "Adventurous road trips and scenic drives. Explored the beauty of landscapes through winding roads and scenic routes. The journey was as exciting as the destinations."},
							new TripReView() { Username = "Adam Hana", Email = "adam.hana@gmail.com", Message = "Art and architecture tour through vibrant cities. Explored galleries, street art, and iconic landmarks. A treat for art lovers and history enthusiasts alike."},
							new TripReView() { Username = "Lina Ahmed", Email = "lina.ahmed@hotmail.com", Message = "Eco-friendly retreat surrounded by nature. The eco-conscious accommodations and sustainable practices added an eco-friendly touch to the travel experience."},
							new TripReView() { Username = "Khaled Farid", Email = "khaled.farid@yahoo.com", Message = "Sunset cruises and beachfront relaxation. Unwinding by the water with mesmerizing sunsets. The calming sound of waves provided the perfect backdrop for relaxation."},
							new TripReView() { Username = "Yasmine Hossam", Email = "yasmine.hossam@gmail.com", Message = "Educational tours with expert guides. Explored historical sites and learned fascinating facts from knowledgeable guides. The educational aspect added depth to the overall journey."}

						}
					},	  //3
					new Trip()
					{
						Name = "New Guided Semi-Private Tour to Jeita Grotto, Harissa & Byblos",
						Cost = 55.00,
						CountryId =  5,
						TripTypeID = 1,
						Duration = 2 ,
						Capacity = 20,
						StartDate = new DateTime(15/4/2014).Date,
						Description = "This (Semi-Private) Small Group Tour is for 9 Travelers and less. WE DO NOT CANCEL ANY SOLO TRAVELER BOOKING. Save time and money. This group-tour is extremely convenient for any traveler wanting to add it to their itinerary. Taste traditional. Full day-trip to Jeita Grottos, Byblos, Harissa from Beirut. Explore Jeita Grottos site by riding the mini cable-car and the boat inside one of the caves and returning back by the mini train. Explore Virgin Mary Statue in HARISSA by riding the cable-car and the panoramic view of Jounieh bay or by vehicle. Visit the UNESCO World Heritage Site and its fascinating Marina, Souk and the Castle in Byblos. Complimentary pickup and drop off from all Beirut district hotels and apartments. Option to include the entrance fees and lunch at the seaside of Byblos.",
						Program = "Certainly! Here's the provided text in paragraph form:Jeita Grotto NEW (LLT Genuine Product). From your hotel in Beirut, with a smile, you are picked up in the morning at 08:15 am for a drive to your first must-see stop. You will have almost 1.15 hours to explore the famous JEITA GROTTOS, which is a system of two separate but interconnected karstic limestone caves spanning an overall length of nearly 10 kilometers. The admission ticket is not included for this 1 hour 15 minutes exploration.\r\n\r\nNext, you continue to your next important visit, the significant amazing Virgin Mary Statue in HARISSA. By car throughout the mountain, you will explore the panoramic view of JOUNIEH bay and lots of beautiful scenery. This visit takes approximately 30 minutes, and the admission ticket is free.\r\n\r\nFollowing that, you'll enjoy riding the main cable-car from Harissa to Jounieh. The experienced driver will wait for you to continue to your next important visit to Byblos. If the cable car is closed, you will continue by vehicle. This cable-car ride lasts for about 20 minutes, and the admission ticket is not included.\r\n\r\nYour 1.5-hour tour of the significant location at the UNESCO World Heritage Site of the beautiful Phoenician city of BYBLOS starts. This is one of the oldest continuously inhabited cities in the world. You'll enjoy a walk at the Marina side shedding to the castle and the souk. The admission ticket is included for this 15 minutes visit.\r\n\r\nYou'll then have the option to enter the Crusader castle in Byblos, known as the castle of Gibelet, which is adjacent to the Phoenician archaeological site. The castle was built by the Crusaders in the 12th century and has a rich history. This visit takes approximately 45 minutes, and the admission ticket is not included.\r\n\r\nAfter the castle, you'll enter the old souk of Byblos, an old market where you can buy from a lot of local shops, including antiques, souvenirs, local crafts, and various other merchandise. It's one of the best spots in Lebanon for activity. The souk is never empty of people, and there are also cozy bars and cafes along the walk. This part of town is a collection of old walls (some medieval), overlapping properties, and intriguing half-ruins. The admission ticket is included for this 30 minutes visit.\r\n\r\nFinally, you'll head to a traditional restaurant to have your Mediterranean Lebanese food, which will take about 1 hour, and the admission ticket is free. After your lunch, your experienced driver will head to Beirut, where he will drop you off at your location." ,
						Images = new List<Image>()
						{
							new Image(){ ImageURL = "New Guided Semi-Private Tour to Jeita Grotto, Harissa & Byblos "+1+".jpg"},
							new Image(){ ImageURL = "New Guided Semi-Private Tour to Jeita Grotto, Harissa & Byblos "+2+".jpg"},
							new Image(){ ImageURL = "New Guided Semi-Private Tour to Jeita Grotto, Harissa & Byblos "+3+".jpg"},
							new Image(){ ImageURL = "New Guided Semi-Private Tour to Jeita Grotto, Harissa & Byblos "+4+".jpg"},

						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "Hassan Mahmoud", Email = "hassan.mahmoud@gmail.com", Message = "Had an incredible journey exploring new destinations. The local culture and cuisine were beyond expectations. The breathtaking landscapes left a lasting impression, and I'm already looking forward to my next travel adventure."},
							new TripReView() { Username = "Layla Abdullah", Email = "layla.abdullah@hotmail.com", Message = "Nature's beauty left me in awe at every turn. A paradise for nature enthusiasts, every moment felt like stepping into a dream. Highly recommend this trip to fellow travelers."},
							new TripReView() { Username = "Karim Tarek", Email = "karim.tarek@yahoo.com", Message = "Found serenity in a charming countryside cottage. The hospitality of the hosts and the peaceful surroundings made it a home away from home."},
							new TripReView() { Username = "Nadia Kamal", Email = "nadia.kamal@gmail.com", Message = "Embarked on a historical journey exploring landmarks and museums. The rich history of the region provided an educational and fascinating experience."},
							new TripReView() { Username = "Amr Fathy", Email = "amr.fathy@hotmail.com", Message = "Adventures unfolded at every step! Hiking, water sports, and more - a perfect getaway for adrenaline seekers. The memories created are truly unforgettable."},
							new TripReView() { Username = "Rania Nasser", Email = "rania.nasser@yahoo.com", Message = "Indulged in the local culinary delights. The diverse flavors and dishes were a delightful journey for the taste buds. Discovered new and exquisite flavors."},
							new TripReView() { Username = "Tarek Ali", Email = "tarek.ali@gmail.com", Message = "Relaxed in a spa resort surrounded by tranquility. Rejuvenating treatments and a serene atmosphere provided the ideal break, and I returned feeling refreshed."},
							new TripReView() { Username = "Laila Ahmed", Email = "laila.ahmed@hotmail.com", Message = "Warmth and hospitality from the locals made the trip even more special. The sense of community added a unique touch, making it a memorable experience."},
							new TripReView() { Username = "Hoda Farouk", Email = "hoda.farouk@yahoo.com", Message = "Explored hidden gems off the beaten path. The sense of adventure was invigorating, uncovering treasures in places less traveled."},
							new TripReView() { Username = "Karim Tamer", Email = "karim.tamer@hotmail.com", Message = "Luxury villa stay with breathtaking views. Waking up to panoramic scenes made each day feel like a dream."},
							new TripReView() { Username = "Lina Omar", Email = "lina.omar@yahoo.com", Message = "Immersed in cultural experiences with local communities. Shared stories, traditions, and laughter created a heartfelt connection with the culture."},
							new TripReView() { Username = "Youssef Sami", Email = "youssef.sami@gmail.com", Message = "Captivated by the enchanting landscapes and vibrant culture. Every moment felt like a magical adventure, and I can't wait to share the stories."},
							new TripReView() { Username = "Dalia Fawzy", Email = "dalia.fawzy@hotmail.com", Message = "A gastronomic journey through local flavors. From street food to fine dining, the culinary delights were a feast for the senses."},
							new TripReView() { Username = "Ahmed Gamal", Email = "ahmed.gamal@yahoo.com", Message = "Relished the tranquility in an eco-friendly retreat. The sustainable practices and natural surroundings added an eco-conscious touch to the travel experience."},
							new TripReView() { Username = "Laila Wael", Email = "laila.wael@gmail.com", Message = "Magical sunset cruises and beachfront relaxation. The calming waves and mesmerizing sunsets created a perfect backdrop for unwinding."},
							new TripReView() { Username = "Tamer Khaled", Email = "tamer.khaled@hotmail.com", Message = "Art and architecture exploration through vibrant cities. Galleries, street art, and iconic landmarks provided a treat for art enthusiasts."},
							new TripReView() { Username = "Rana Ashraf", Email = "rana.ashraf@yahoo.com", Message = "Educational tours enriched with expert guides. Explored historical sites, gaining fascinating insights that added depth to the overall journey."},
							new TripReView() { Username = "Sara Yehia", Email = "sara.yehia@gmail.com", Message = "Cultural immersion and laughter with local communities. The connections made were heartwarming, and it was an experience filled with shared stories and traditions."},
							new TripReView() { Username = "Hassan Mohamed", Email = "hassan.mohamed@hotmail.com", Message = "Photography paradise with picturesque scenes at every corner. Capturing moments that will adorn my photo album for years to come."},
							new TripReView() { Username = "Noura Tarek", Email = "noura.tarek@yahoo.com", Message = "Adventurous road trips and scenic drives. Exploring the beauty of landscapes through winding roads and scenic routes."},
							new TripReView() { Username = "Aliya Wael", Email = "aliya.wael@gmail.com", Message = "An architectural journey through history. Explored ancient structures and landmarks, uncovering the rich history of the region."},

						}


					},	  //4
					new Trip()
					{
						Name="Baalbek - Anjar - Ksara Trip From Beirut",
						Cost = 45.00,
						StartDate=new DateTime(10/5/2024).Date,
						Description="History and archeology enthusiasts won’t want to miss this exciting full-day tour from Beirut. You’ll visit a number of the most important historic sites in Lebanon. Explore Roman ruins at Baalbek, the palaces and souks of 8th-century Anjar, and taste wine in the Lebanese wine-making center of Ksara. Learn about Lebanon’s diverse and long history while having fun and seeing the sights. Hotel transfers are included Get personalized attention on a small-group tour Cover a lot of ground in a single day An easy trip around Lebanon for travelers staying in Beirut",
						Program = "Beirut (Pass By) Pickup From Beirut Bekaa Valley (Pass By) We will drive through the bekaa valley to all the sites 1 Anjar Citadel Arrive Anjar: 9:30 – Explore The city of Anjar which stands as the single Umayyad site in Lebanon. (1 Hour Duration) Depart Anjar to Baalbek: 10:30 1 hour • Admission Ticket Not Included 2 Temples of Baalbek Arrive Baalbek: 11:30 – Get to explore the 3 temples dedicated to Bacchus, Jupiter, and Venus (2 Hours Duration) Depart Baalbek – Lunch Stop: 13:30 2 hours • Admission Ticket Not Included 3 Douris Arrive to Lunch Stop: 13:45 – Lunch Stop 1 Hour Depart Lunch Stop by: 14:45 1 hour • Admission Ticket Free 4 Chateau Ksara Arrive Chateau Ksara: 15:15 – Explore the oldest winery in lebanon, get to visit the roman caves, and taste local wine. (1 Hour 15 min) Depart Chateau Ksara 16:30 1 hour • Admission Ticket Not Included Beirut (Pass By) Arrive to Beirut: 17:30 – 18:00",
						Capacity = 100,
						CountryId = 5 ,
						TripTypeID = 2 ,
						Duration = 1,
						Images = new List<Image>()
						{
							new Image(){ImageURL = "Baalbek - Anjar - Ksara Trip From Beirut "+1+".jpg"},
							new Image(){ImageURL = "Baalbek - Anjar - Ksara Trip From Beirut "+2+".jpg"},
							new Image(){ImageURL = "Baalbek - Anjar - Ksara Trip From Beirut "+3+".jpg"},
							new Image(){ImageURL = "Baalbek - Anjar - Ksara Trip From Beirut "+4+".jpg"},


						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "SarahAdventures", Email = "sarah.adventures@gmail.com", Message = "Anjar Citadel was a historical gem! The Umayyad site in Lebanon offered a captivating journey through time. A must-visit for history enthusiasts."},
							new TripReView() { Username = "SarahAdventures", Email = "sarah.adventures@gmail.com", Message = "Anjar Citadel was a historical gem! The Umayyad site in Lebanon offered a captivating journey through time. A must-visit for history enthusiasts."},
							new TripReView() { Username = "AlexTraveler", Email = "alex.traveler@hotmail.com", Message = "The Temples of Baalbek were awe-inspiring! Dedicated to Bacchus, Jupiter, and Venus, the intricate architecture and historical significance made it a memorable experience."},
							new TripReView() { Username = "OliviaExplorer", Email = "olivia.explorer@yahoo.com", Message = "Douris provided a delightful lunch stop! The break allowed us to recharge and enjoy local cuisine. A perfect pause in the midst of historical exploration."},
							new TripReView() { Username = "CharlieWineConnoisseur", Email = "charlie.wineconnoisseur@gmail.com", Message = "Chateau Ksara, the oldest winery in Lebanon, was a treat for the senses! The roman caves and local wine tasting added a unique touch to the journey. Highly recommended for wine enthusiasts."},
							new TripReView() { Username = "ZoeHistoricalJourney", Email = "zoe.historicaljourney@hotmail.com", Message = "The journey through the Beqaa Valley was a scenic delight! Exploring Anjar, Baalbek, and Douris showcased the rich history of Lebanon. A perfect blend of culture and nature."},
							new TripReView() { Username = "MaxCulturalExplorer", Email = "max.culturalexplorer@yahoo.com", Message = "Anjar's Umayyad site was a hidden treasure! The historical significance and architecture were fascinating. A journey through Lebanon's cultural heritage."},
							new TripReView() { Username = "MiaNatureEnthusiast", Email = "mia.natureenthusiast@gmail.com", Message = "The Temples of Baalbek offered a glimpse into ancient wonders! Surrounded by nature, the historical journey was complemented by breathtaking views. A trip for both history and nature lovers."},
							new TripReView() { Username = "LeoCulinaryAdventures", Email = "leo.culinaryadventures@hotmail.com", Message = "Lunch Stop at Douris was a culinary delight! The local cuisine was a perfect match for the historical exploration. A satisfying break in the midst of cultural discoveries."},
							new TripReView() { Username = "EllaWineTasting", Email = "ella.winetasting@gmail.com", Message = "Chateau Ksara's wine tasting was a sensory experience! Exploring the roman caves and savoring local wines added a delightful twist to the trip. A must-visit for wine connoisseurs."},
							new TripReView() { Username = "OscarHistoricalWanderer", Email = "oscar.historicalwanderer@yahoo.com", Message = "The journey through Lebanon's historical sites was enriching! Anjar, Baalbek, and Douris provided a comprehensive understanding of the region's cultural heritage. A captivating historical wander."},
							new TripReView() { Username = "AvaScenicDrive", Email = "ava.scenicdrive@gmail.com", Message = "The drive through Beqaa Valley offered picturesque landscapes! Anjar and Baalbek showcased the beauty of Lebanon's historical wonders against the backdrop of nature. A scenic journey through time."},
							new TripReView() { Username = "NoahCulturalExchange", Email = "noah.culturalexchange@yahoo.com", Message = "Lunch Stop at Douris allowed for cultural exchange! Engaging with local cuisine added a personal touch to the historical exploration. A connection with Lebanon's rich culinary traditions."},
							new TripReView() { Username = "EmmaWineAdventure", Email = "emma.wineadventure@gmail.com", Message = "Chateau Ksara's wine adventure was delightful! The oldest winery in Lebanon offered a perfect blend of history and wine tasting. A memorable journey for wine enthusiasts."},
							new TripReView() { Username = "LiamHistoricalDiscovery", Email = "liam.historicaldiscovery@hotmail.com", Message = "Anjar's Umayyad site revealed historical treasures! The exploration of Baalbek and Douris added depth to the historical discovery. A journey filled with intriguing stories."},
							new TripReView() { Username = "AriaNatureEscape", Email = "aria.natureescape@gmail.com", Message = "Nature's escape through Beqaa Valley was refreshing! The temples of Baalbek immersed us in ancient history amidst natural beauty. An ideal escape for those seeking history and tranquility."},
							new TripReView() { Username = "EthanCulinaryJourney", Email = "ethan.culinaryjourney@yahoo.com", Message = "Douris' Lunch Stop was a culinary journey! The flavors of local cuisine were a delightful addition to the historical exploration. A satisfying break with a taste of Lebanon."},
							new TripReView() { Username = "AvaWineAfficionado", Email = "ava.wineafficionado@gmail.com", Message = "Chateau Ksara's wine experience was exquisite! Exploring the oldest winery and tasting local wines provided a unique perspective on Lebanon's cultural heritage. A must-visit for wine aficionados."},
							new TripReView() { Username = "LiamHistoricalWanderlust", Email = "liam.historicalwanderlust@hotmail.com", Message = "Lebanon's historical wonders came to life! Anjar, Baalbek, and Douris offered a journey through time, unraveling the rich tapestry of the region's cultural heritage."},
							new TripReView() { Username = "SophiaScenicAdventures", Email = "sophia.scenicadventures@gmail.com", Message = "The scenic drive through Beqaa Valley was an adventure! Anjar and Baalbek provided glimpses of historical wonders against the backdrop of Lebanon's picturesque landscapes. A perfect blend of adventure and history."},
							new TripReView() { Username = "EthanCulturalDiscovery", Email = "ethan.culturaldiscovery@yahoo.com", Message = "Douris' Lunch Stop allowed for cultural discovery! Engaging with local cuisine added a personal touch to the historical exploration. A connection with Lebanon's rich culinary traditions."},
							new TripReView() { Username = "MiaWineTastingEscape", Email = "mia.winetastingescape@gmail.com", Message = "Chateau Ksara's wine tasting was a delightful escape! The oldest winery in Lebanon provided a perfect setting for exploring history and savoring local wines. A memorable escape for wine lovers."},
						}
					},	  //5
					new Trip()
					{
						Name="Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway",
						Cost = 55.72,
						StartDate=new DateTime().Date,
						Description="Discover top attractions including Leenane Village and Kylemore Abbey on this day trip to Connemara from Galway. Travel to Connemara as your guide sheds light on the region’s rich heritage and spectacular natural scenery. Take in fine views over the Twelve Pins mountain range and enjoy free time to explore Leenane Village at your leisure. Visit attractive landmarks such as Killary Fjord and Kylemore Abbey, and gain insight into Ireland’s heritage. Stop in the Irish-speaking village of Spiddal and perhaps try chatting to the locals, then head back to Galway. Comprehensive tour by bus/coach Excellent value for money Get inside tips from a local Hotel pickup included Led by a local guide Instant Confirmation\r\n\r\nRead more about Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway - https://www.viator.com/tours/Galway/Connemara-Day-Trip-Including-Leenane-Village-and-Kylemore-Abbey-from-Galway/d5156-8625P2?mcid=56757",
						Program = "Oughterard (Pass By) Oughterard is a small town on the banks of the Owenriff River close to the western shore of Lough Corrib in County Galway, Ireland. The population of the town in 2016 was 1,318. It is located about 26 km northwest of Galway on the N59 road. Twelve Bens of Connemara (Pass By) Tallest mountain range in the west of Ireland Maam Cross (Pass By) DescriptionMaam Cross is a crossroads in Connemara, County Galway, Ireland. It lies within the townland of Shindilla, at the junction of the R59 from Galway to Clifden and the R336 from Galway to the Maam Valley which runs from Maum or Maam to Leenaun or Leenane 1 Leenane DescriptionLeenaun, also Leenane, is a village and 1,845 acre townland in northern County Galway, Ireland, on the southern shore of Killary Harbour, on the northern edge of Connemara 30 minutes • Admission Ticket Free 2 Killary Fjord Killary Harbour is a fjord located in the west of Ireland, in northern Connemara, and the border between counties Galway and Mayo runs down its centre 15 minutes • Admission Ticket Free 3 Kylemore Abbey & Victorian Walled Garden Kylemore Abbey is a Benedictine monastery founded in 1920 on the grounds of Kylemore Castle, in Connemara, County Galway, Ireland. The abbey was founded for Benedictine Nuns who fled Belgium in World War I. 2 hours • Admission Ticket Included Connemara National Park & Visitor Centre (Pass By) Connemara National Park is one of six national parks in Ireland that are managed by the National Parks and Wildlife Service of the Department of Culture, Heritage and the Gaeltacht. It is located in the west of Ireland within County Galway. 4 Spiddal Gorgeous seaside village in South Connemara\r\n\r\nRead more about Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway - https://www.viator.com/tours/Galway/Connemara-Day-Trip-Including-Leenane-Village-and-Kylemore-Abbey-from-Galway/d5156-8625P2?mcid=56757",
						Capacity = 30,
						CountryId = 5 ,
						Duration = 1,
						TripTypeID = 2 ,
						Images = new List<Image>()
						{
							new Image(){ ImageURL = "Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway "+1+".jpg"},
							new Image(){ ImageURL = "Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway "+2+".jpg"},
							new Image(){ ImageURL = "Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway "+3+".jpg"},
							new Image(){ ImageURL = "Connemara Day Trip Including Leenane Village and Kylemore Abbey from Galway "+4+".jpg"},

						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "John Traveller", Email = "john.traveller@gmail.com", Message = "Captivating journey through Connemara's enchanting landscapes. The visit to Leenane Village and Kylemore Abbey was a highlight. Breathtaking views and rich heritage make it a must-visit destination." },
							new TripReView() { Username = "Emma Explorer", Email = "emma.explorer@hotmail.com", Message = "Immersive cultural experiences in Connemara. Explored the Irish-speaking village of Spiddal and engaged with locals. The comprehensive tour provided valuable insights into Ireland's heritage." },
							new TripReView() { Username = "Nature Enthusiast", Email = "nature.enthusiast@yahoo.com", Message = "Mesmerizing views of the Twelve Pins mountain range. Killary Fjord and the surrounding natural beauty were awe-inspiring. A perfect day trip for those who appreciate nature's wonders." },
							new TripReView() { Username = "History Buff", Email = "history.buff@gmail.com", Message = "Explored historical landmarks, including Kylemore Abbey. The architectural beauty and historical significance added depth to the journey. A perfect blend of culture, history, and natural beauty." },
							new TripReView() { Username = "Adventure Seeker", Email = "adventure.seeker@hotmail.com", Message = "Thrilling experiences and picturesque landscapes. The adventure-filled day included a visit to Leenane Village, creating memories that will last a lifetime. Highly recommended for adventure seekers." },
							new TripReView() { Username = "Sophie Wanderer", Email = "sophie.wanderer@gmail.com", Message = "Enchanting journey filled with hidden gems. Explored charming villages and embraced the local culture. A delightful experience for those seeking authenticity."},
							new TripReView() { Username = "Alex Nature Lover", Email = "alex.naturelover@hotmail.com", Message = "Nature at its finest! The scenic beauty and diverse landscapes of Connemara left a lasting impression. A must-visit for nature enthusiasts."},
							new TripReView() { Username = "Olivia History Explorer", Email = "olivia.historyexplorer@yahoo.com", Message = "Dive into history with Connemara's historical treasures. Kylemore Abbey's grandeur and the stories behind each landmark made the trip both educational and fascinating."},
							new TripReView() { Username = "Charlie Outdoor Adventurer", Email = "charlie.adventurer@gmail.com", Message = "Outdoor paradise in Connemara. From hiking trails to scenic viewpoints, every moment was an adventure. The trip offered the perfect blend of excitement and relaxation."},
							new TripReView() { Username = "Zoe Culture Enthusiast", Email = "zoe.cultureenthusiast@hotmail.com", Message = "Immersed in local traditions and folklore. The cultural experiences in Spiddal and Leenane Village added a unique touch to the journey. An enriching cultural exploration."},
							new TripReView() { Username = "Max Tranquil Voyager", Email = "max.tranquilvoyager@yahoo.com", Message = "Tranquility amidst stunning landscapes. The serene atmosphere and peaceful surroundings made it a perfect escape from the hustle and bustle of everyday life."},
							new TripReView() { Username = "Mia Scenic Aficionado", Email = "mia.scenicaficionado@gmail.com", Message = "Scenic drives and panoramic views. Connemara's landscapes provided a visual feast. The journey through winding roads and picturesque locations was a photographer's dream."},
							new TripReView() { Username = "Leo Culinary Explorer", Email = "leo.culinaryexplorer@hotmail.com", Message = "Culinary delights at every stop. From local specialties to gourmet treats, the food journey in Connemara was a gastronomic adventure. A paradise for food enthusiasts."},
							new TripReView() { Username = "Ella Sunset Chaser", Email = "ella.sunsetchaser@gmail.com", Message = "Chasing sunsets along Killary Fjord. The breathtaking views and vibrant colors during the evening made it a magical experience. An ideal destination for sunset lovers."},
							new TripReView() { Username = "Oscar Cultural Connector", Email = "oscar.culturalconnector@yahoo.com", Message = "Connected with the local community. Engaging conversations, shared stories, and a warm welcome made the trip feel like a cultural exchange. Connemara's hospitality is unmatched."},

						}
					},	  //6
					new Trip()
					{
						Name="5-Day Lebanon Sightseeing Tour from Beirut",
						Cost = 590.00,
						StartDate=new DateTime(16/5/2024).Date,
						Description="Lebanon has some of the most beautiful sights to offer. Explore the highlights of the Phoenician cities, walk along the forests, discover grottoes and archeological sites and enjoy tasting the Lebanese food and wine. We take our time to marvel around the tourist sites. As we added several stops that show you a bit about Lebanon's cultural and geological history. This tour package is the perfect mixture between adventure and sightseeing.\r\n\r\n",
						Program = "Jeita Grotto, Harissa & Byblos\r\n6 Stops\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nDay 3\r\nBaalbek, Anjar & Ksara\r\n3 Stops\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nDay 4\r\nQadisha valley, Bcharre & Cedars\r\n4 Stops\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nDay 5\r\nThe Departure\r\n2 Stops",
						Capacity = 50,
						CountryId = 5 ,
						TripTypeID = 2 ,
						Duration = 5,
						Images = new List<Image>()
						{
							new Image() { ImageURL = "5-Day Lebanon Sightseeing Tour from Beirut "+1+".jpg"},
							new Image() { ImageURL = "5-Day Lebanon Sightseeing Tour from Beirut "+2+".jpg"},
							new Image() { ImageURL = "5-Day Lebanon Sightseeing Tour from Beirut "+3+".jpg"},
							new Image() { ImageURL = "5-Day Lebanon Sightseeing Tour from Beirut "+4+".jpg"},
							new Image() { ImageURL = "5-Day Lebanon Sightseeing Tour from Beirut "+5+".jpg"},


						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "SophiaAdventures", Email = "sophia.adventures@gmail.com", Message = "Lebanon's beauty revealed! The 5-Day Sightseeing Tour showcased the best of Phoenician cities, enchanting forests, and fascinating archaeological sites. A perfect blend of adventure and cultural exploration."},
							new TripReView() { Username = "AlexTraveler", Email = "alex.traveler@hotmail.com", Message = "A journey through Lebanon's rich history! The tour offered a delightful mix of cultural and geological sites, allowing us to marvel at the country's diverse heritage. A truly immersive experience."},
							new TripReView() { Username = "OliviaExplorer", Email = "olivia.explorer@yahoo.com", Message = "Tasting Lebanon's culinary delights! The tour not only explored the historical sites but also indulged our taste buds in Lebanese food and wine. A complete package of adventure, history, and gastronomy."},
							new TripReView() { Username = "CharlieHistoryBuff", Email = "charlie.historybuff@gmail.com", Message = "Phoenician cities came to life! The tour highlighted the historical significance of Lebanon, offering insights into the rich cultural and archaeological heritage. An educational and fascinating journey."},
							new TripReView() { Username = "ZoeCulturalEnthusiast", Email = "zoe.culturalenthusiast@hotmail.com", Message = "A cultural exploration like no other! Walking along the forests and discovering grottoes provided a unique perspective on Lebanon's natural beauty. The tour seamlessly blended adventure and cultural immersion."},
							new TripReView() { Username = "MaxNatureLover", Email = "max.naturelover@yahoo.com", Message = "Lebanon's natural wonders at every turn! The tour allowed us to appreciate the breathtaking forests and grottoes, creating a perfect harmony between nature and cultural exploration."},
							new TripReView() { Username = "MiaCulinaryExplorer", Email = "mia.culinaryexplorer@gmail.com", Message = "Savoring Lebanese delicacies! The tour not only unveiled historical treasures but also treated us to the culinary delights of Lebanon. An exquisite journey for both history and food enthusiasts."},
							new TripReView() { Username = "LeoWineConnoisseur", Email = "leo.wineconnoisseur@hotmail.com", Message = "A wine lover's paradise! Tasting Lebanese wine added a delightful touch to the tour, enhancing our appreciation for Lebanon's cultural and gastronomic heritage. A journey for wine connoisseurs."},
							new TripReView() { Username = "EllaAdventureSeeker", Email = "ella.adventureseeker@gmail.com", Message = "Adventure and sightseeing in perfect harmony! The 5-Day Lebanon Sightseeing Tour offered a balanced mixture of exploration, adventure, and cultural marvels. A journey filled with excitement and discovery."},
							new TripReView() { Username = "OscarCulturalExplorer", Email = "oscar.culturalexplorer@yahoo.com", Message = "Marvelling at Lebanon's cultural richness! The tour package took us through the highlights, showcasing the country's diverse heritage. A cultural exploration that left a lasting impression."},
							new TripReView() { Username = "AvaScenicBeauty", Email = "ava.scenicbeauty@gmail.com", Message = "Breathtaking scenery unfolds! The tour provided stunning views of Phoenician cities and the mesmerizing landscapes. A visual feast that combined adventure with the beauty of Lebanon."},
							new TripReView() { Username = "NoahHistoricalDiscovery", Email = "noah.historicaldiscovery@yahoo.com", Message = "Discovering Lebanon's historical tapestry! The tour unraveled the stories of Phoenician cities, grottoes, and archaeological sites. A journey through time and heritage."},
							new TripReView() { Username = "EmmaCulinaryJourney", Email = "emma.culinaryjourney@gmail.com", Message = "Culinary delights in Lebanon! The tour not only explored historical wonders but also indulged us in the flavors of Lebanese food and wine. A gastronomic journey with a touch of history."},
							new TripReView() { Username = "LiamNatureEscape", Email = "liam.natureescape@hotmail.com", Message = "Escape into Lebanon's natural wonders! The tour took us through forests and grottoes, offering a serene and refreshing experience. A nature lover's dream journey."},
							new TripReView() { Username = "AriaWineTasting", Email = "aria.winetasting@gmail.com", Message = "Sipping Lebanese wine amidst beauty! The tour seamlessly blended cultural exploration with wine tasting, creating a memorable and delightful experience. A toast to Lebanon's rich heritage."},
							new TripReView() { Username = "EthanCulturalExchange", Email = "ethan.culturalexchange@yahoo.com", Message = "Engaging in Lebanon's cultural exchange! The tour allowed us to walk along forests, discover grottoes, and taste local cuisine. An immersive journey filled with cultural richness."},
							new TripReView() { Username = "AvaHistoricalWanderer", Email = "ava.historicalwanderer@gmail.com", Message = "Wandering through Lebanon's historical wonders! The tour showcased the highlights of Phoenician cities, creating a captivating journey through Lebanon's rich history."},
							new TripReView() { Username = "LiamScenicAdventures", Email = "liam.scenicadventures@hotmail.com", Message = "Adventures in Lebanon's scenic beauty! The tour unfolded picturesque landscapes, offering a perfect blend of adventure and the natural charm of Phoenician cities. A journey to remember."},
							new TripReView() { Username = "SophiaCulturalDiscovery", Email = "sophia.culturaldiscovery@gmail.com", Message = "Discovering Lebanon's cultural gems! The tour package provided a comprehensive exploration of the country's cultural and geological history. A discovery journey filled with insights."},
							new TripReView() { Username = "EthanWineAfficionado", Email = "ethan.wineafficionado@yahoo.com", Message = "A wine lover's dream tour! The journey not only showcased historical sites but also indulged in the flavors of Lebanese wine. A perfect blend of history and wine exploration."},

						}
					},	  //7
					new Trip()
					{
						Name="Best of Istanbul 1 2 or 3-Day Private Guided Istanbul Tour",
						Cost = 150.00,
						StartDate=new DateTime().Date,
						Description="Prepare to be awed by Istanbul’s magnificent architecture, rich history, and eclectic bazaars as you discover the unmissable highlights of the Old City on this 1-, 2-, or 3-day private tour. Marvel over the glorious Hagia Sophia, learn how the Blue Mosque earned its famous nickname, and see the ancient Basilica Cistern. Tour Topkapi Palace to gain an insight into the lavish lifestyles of the Ottoman sultans and their harem, and browse the legendary Grand Bazaar, where you find everything from carpets to Turkish delight. Flexible daily itineraries: Day 1 - Hagia Sophia, Hippodrome Square, German Fountain, Blue Mosque, Basilica Cistern, Topkapi Palace, Grand Bazaar. Day 2 - Bosphorus Cruise by Public Ferry, Dolmabahce Palace, Taksim Square, Istiklal Street, Cicek Passage, Galata Tower (from outside), Spice Market. Day 3 - Suleymaniye Mosque, Fener and Balat Districts, St. Stephen Church (Iron Church), Pierre Lotti Panoramic Hill by Cable Car, Rahmi Koc Museum (or alternative sites). Exclusive Istanbul tour led by a private guide Comprehensive tour of the city over one, two, or three days Explore the local streets on a walking tour of the city Customize the itinerary according to your schedule\r\n\r\nRead more about Best of Istanbul: 1, 2 or 3-Day Private Guided Istanbul Tour ",
						Program = "When booking this immersive, private tour of Istanbul, choose a duration that works best for your schedule. See many of the city’s most important attractions and monuments, all in one day—or extend to a two- or three-day experience for a complete introduction to the city. On the first day, meet your guide directly at your centrally located Istanbul hotel. This experience is tailored to your schedule and interests, and you can pick from numerous departure times and customize your itinerary. Set off on foot to really soak in the city’s ambiance, and visit numerous landmarks in the Historic Areas of Istanbul UNESCO World Heritage Site, including the Hagia Sophia and Blue Mosque or Basilica Cistern. Then, visit the lavish Topkapi Palace (entry own expense) before finishing at the Grand Bazaar. With your guide’s in-depth storytelling, you’ll learn more about the sights than you’d discover on your own. If you choose to extend to the second day, enhance your visit with a Bosphorus cruise by public ferry and a trip to Dolmabahce Palace. Follow your guide through the crowds to see Taksim Square, Istiklal Street, Cicek Passage, and the exterior of the Galata Tower. And if you explore on a third day, more sights await discovery, including the Suleymaniye Mosque, the evocative Fener and Balat neighborhoods and the Bulgarian St. Stephen Church. Cap off your experience with a cable car ride to the Pierre Loti Hill.\r\n\r\nRead more about Best of Istanbul: 1, 2 or 3-Day Private Guided Istanbul Tour - https://www.viator.com/tours/Istanbul/Istanbul-Full-Day-Private-Guided-Old-City-Tour/d585-11522P1?mcid=56757",
						Capacity = 70,
						CountryId = 3 ,
						TripTypeID = 1 ,
						Duration = 3,
						Images = new List<Image>()
						{
							new Image() {ImageURL = "Best of Istanbul 1 2 or 3-Day Private Guided Istanbul Tour "+1+".jpg"},
							new Image() {ImageURL = "Best of Istanbul 1 2 or 3-Day Private Guided Istanbul Tour "+2+".jpg"},
							new Image() {ImageURL = "Best of Istanbul 1 2 or 3-Day Private Guided Istanbul Tour "+3+".jpg"},
							new Image() {ImageURL = "Best of Istanbul 1 2 or 3-Day Private Guided Istanbul Tour "+4+".jpg"},

						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "ExplorerSophie", Email = "sophie.explorer@gmail.com", Message = "An awe-inspiring journey through Istanbul! The private guided tour provided a comprehensive exploration of the city's rich history and architectural wonders. A perfect blend of culture, history, and flexibility."},
							new TripReView() { Username = "TravelerAlex", Email = "alex.traveler@hotmail.com", Message = "Istanbul's gems unveiled! The 3-day tour allowed us to marvel at iconic landmarks like Hagia Sophia and the Blue Mosque. The flexibility of the itinerary ensured a personalized and unforgettable experience."},
							new TripReView() { Username = "HistoryBuffOlivia", Email = "olivia.historybuff@yahoo.com", Message = "A historical feast in Istanbul! Day 1 took us through the grandeur of Hagia Sophia, the Blue Mosque, and the Grand Bazaar. The private guide added depth to the journey with insights into Ottoman history."},
							new TripReView() { Username = "CulturalEnthusiastCharlie", Email = "charlie.culturalenthusiast@gmail.com", Message = "Immersive cultural exploration! Day 2's Bosphorus Cruise and visits to Dolmabahce Palace and the Spice Market provided a perfect balance of history and local experiences. A well-crafted itinerary."},
							new TripReView() { Username = "AdventureSeekerZoe", Email = "zoe.adventureseeker@hotmail.com", Message = "Flexible and adventurous! The 3-day tour's flexibility allowed us to customize our experience. From the iconic landmarks to the hidden gems, Istanbul's charm unfolded at every turn."},
							new TripReView() { Username = "ArchitectureLoverMax", Email = "max.architecturelover@yahoo.com", Message = "Istanbul's architectural marvels at their best! Day 3's exploration of Suleymaniye Mosque and the panoramic views from Pierre Lotti Panoramic Hill were breathtaking. A must for architecture enthusiasts."},
							new TripReView() { Username = "BazaarExplorerMia", Email = "mia.bazaarexplorer@gmail.com", Message = "Browsing the Grand Bazaar was a delight! Day 1's visit to this legendary market offered a sensory experience, from carpets to Turkish delight. The private guide made the journey informative and enjoyable."},
							new TripReView() { Username = "LocalInsiderLeo", Email = "leo.localinsider@hotmail.com", Message = "Insider's perspective on Istanbul! The private guide shared local insights, making each stop, from Topkapi Palace to Taksim Square, even more enriching. A tour that went beyond the usual tourist experience."},
							new TripReView() { Username = "BosphorusAdventuresElla", Email = "ella.bosphorusadventures@gmail.com", Message = "Day 2's Bosphorus Cruise was a highlight! The public ferry offered panoramic views, complemented by visits to Dolmabahce Palace and the Spice Market. A perfect blend of history and scenic beauty."},
							new TripReView() { Username = "FlexibleExplorerOscar", Email = "oscar.flexibleexplorer@yahoo.com", Message = "Flexibility made the journey memorable! The ability to customize the itinerary allowed us to explore Istanbul at our own pace. Day 3's Cable Car ride to Pierre Lotti Hill was a unique experience."},
							new TripReView() { Username = "CulturalDiscoveryAva", Email = "ava.culturaldiscovery@gmail.com", Message = "Discovering Istanbul's hidden gems! Day 3's exploration of Fener and Balat Districts, St. Stephen Church, and Rahmi Koc Museum provided insights into the city's cultural richness. A journey filled with discoveries."},
							new TripReView() { Username = "LocalFlavorsNoah", Email = "noah.localflavors@yahoo.com", Message = "Tasting Istanbul's delights! The culinary experiences, from local markets to Turkish delights, added a flavorful dimension to the tour. Day 1's Grand Bazaar was a gastronomic adventure."},
							new TripReView() { Username = "ScenicWondersEmma", Email = "emma.scenicwonders@gmail.com", Message = "Scenic wonders of Istanbul! The Bosphorus Cruise, Galata Tower, and Cable Car ride to Pierre Lotti Hill provided breathtaking views. A visual treat for those seeking both history and beauty."},
							new TripReView() { Username = "HistoricalJourneyLiam", Email = "liam.historicaljourney@hotmail.com", Message = "Journey through Istanbul's history! The 3-day tour covered iconic sites like Hagia Sophia, Topkapi Palace, and Suleymaniye Mosque. A comprehensive exploration with a knowledgeable private guide."},
							new TripReView() { Username = "FlexibleAdventuresAria", Email = "aria.flexibleadventures@gmail.com", Message = "Adventures at our own pace! The flexibility of the tour allowed us to explore Istanbul's diverse attractions. From historical landmarks to local districts, every day brought new adventures."},
							new TripReView() { Username = "CulinaryExplorerEthan", Email = "ethan.culinaryexplorer@yahoo.com", Message = "Culinary delights in Istanbul! Day 1's visit to the Grand Bazaar and Turkish delight tasting was a sensory journey. The tour's blend of history and gastronomy was a treat for the palate."},
							new TripReView() { Username = "BreathtakingViewsAva", Email = "ava.breathtakingviews@gmail.com", Message = "Breathtaking views of Istanbul! Day 2's Bosphorus Cruise and visits to Dolmabahce Palace and the Spice Market offered scenic wonders. A journey that combined history with the beauty of Istanbul's landscapes."},
							new TripReView() { Username = "CulturalExplorerLiam", Email = "liam.culturalexplorer@hotmail.com", Message = "Exploring Istanbul's cultural richness! Day 3's visits to Fener and Balat Districts, St. Stephen Church, and Rahmi Koc Museum provided a deep dive into the city's cultural tapestry. An enriching and eye-opening tour."},
							new TripReView() { Username = "PrivateTourSophia", Email = "sophia.privatetour@gmail.com", Message = "Private tour, personalized experience! The 3-day journey through Istanbul's highlights was made even more special with a private guide. A personalized and insightful exploration of the city."},
							new TripReView() { Username = "AdventureSeekerAlex", Email = "alex.adventureseeker@hotmail.com", Message = "An adventurous escape in Istanbul! The flexibility of the tour allowed us to discover the city's wonders at our own pace. A journey filled with"},
						}
					},    //8
					new Trip()
					{
						Name= "Best of Istanbul private tour pick up and drop off included",
						Cost = 72.44,
						StartDate= new DateTime().Date,
						Description="Step into the golden ages of the Ottoman, Byzantine and Roman empires with a full-day, private tour through Istanbul’s Old City. See the monuments and historic sites of Hippodrome Square, where Roman charioteers raced in ancient times, then explore St. Sophia's stunning architecture and museum. See the iconic tiles, mosaics and slender minarets of the Blue Mosque and browse traditional handicrafts inside the Grand Bazaar. Learn about the lives of sultans and courtiers at Topkapi Palace, which contains a remarkable collection of Turkey's greatest holy relics, imperial treasures and artwork. Full-day, private tour of Istanbul See the city's most important sites Enjoy the flexibility of a private tour Learn about local history and culture Hotel Pick up and Drop off included What's Included\r\n\r\nRead more about Best of Istanbul private tour pick up and drop off included - https://www.viator.com/tours/Istanbul/Old-City-Private-Day-Tour-From-Istanbul/d585-21011P2?mcid=56757",
						Program = "Blue Mosque interior visit of the Blue Mosque 30 minutes • Admission Ticket Free 2 Kapali Carsi visit the famous grand bazaar the biggest shopping mall of the europe 45 minutes • Admission Ticket Free 3 Hagia Sophia Mosque interior visit with your guide between 45 up to 90 min time 45 minutes • Admission Ticket Not Included 4 Hippodrome walk on the streets of ancient hipoddrome and see the ancient Columns and obelis 30 minutes • Admission Ticket Free 5 Topkapi Palace the largest museum of the city and house of sultans for 300 years Closed on Tuesday replaced with Underground Basilica Cistern 2 hours • Admission Ticket Not Included Sultanahmet District (Pass By) walk on the old streets of the area Blue Mosque (Pass By) Visit the ancient Roman Hippodrome in front of Blue Mosque\r\n\r\nRead more about Best of Istanbul private tour pick up and drop off included - https://www.viator.com/tours/Istanbul/Old-City-Private-Day-Tour-From-Istanbul/d585-21011P2?mcid=56757",
						Capacity = 40,
						Duration = 2,
						CountryId = 3 ,
						TripTypeID = 1,
						Images = new List<Image>()
						{
							new Image(){ ImageURL = "Best of Istanbul private tour pick up and drop off included "+1+".jpg"},
							new Image(){ ImageURL = "Best of Istanbul private tour pick up and drop off included "+2+".jpg"},
							new Image(){ ImageURL = "Best of Istanbul private tour pick up and drop off included "+3+".jpg"},
							new Image(){ ImageURL = "Best of Istanbul private tour pick up and drop off included "+4+".jpg"},
						},
						TripReviews = new List<TripReView>()
						{
							new TripReView { Username = "SophieJohnson", Email = "sophie.johnson@gmail.com", Message = "An immersive journey through Istanbul's historical wonders! The private tour provided a personalized exploration of the Ottoman, Byzantine, and Roman empires. Informative and flexible, it made the day truly unforgettable."},
							new TripReView { Username = "OliviaSmith", Email = "olivia.smith@hotmail.com", Message = "Discovering Istanbul's rich history! From Hippodrome Square to St. Sophia and the Grand Bazaar, each site revealed fascinating stories of ancient civilizations. The private tour added a unique touch to the experience."},
							new TripReView { Username = "CharlieBrown", Email = "charlie.brown@gmail.com", Message = "A cultural odyssey in Istanbul's heart! The Grand Bazaar's traditional handicrafts and Topkapi Palace's imperial treasures offered insights into the lives of sultans. A day filled with cultural richness."},
							new TripReView { Username = "ZoeMiller", Email = "zoe.miller@yahoo.com", Message = "Adventure through history's ages! The private tour seamlessly blended the golden eras of Ottoman, Byzantine, and Roman empires. St. Sophia's beauty and the Blue Mosque's tiles were enchanting highlights."},
							new TripReView { Username = "MaxTurner", Email = "max.turner@gmail.com", Message = "Architectural wonders at every corner! The slender minarets of the Blue Mosque and the timeless beauty of St. Sophia left us amazed. The private tour provided a deep dive into Istanbul's remarkable history."},
							new TripReView { Username = "MiaWilliams", Email = "mia.williams@hotmail.com", Message = "Delights at the Grand Bazaar! Browsing traditional handicrafts and soaking in the vibrant atmosphere made the tour unforgettable. The private guide's insights added cultural depth to this captivating day."},
							new TripReView { Username = "LeoHarrison", Email = "leo.harrison@gmail.com", Message = "Insider's view of Istanbul's treasures! The private tour allowed us to uncover hidden gems and learn about the lives of sultans at Topkapi Palace. A day filled with historical insights and cultural richness."},
							new TripReView { Username = "EmmaScott", Email = "emma.scott@yahoo.com", Message = "Scenic beauty and historical marvels! The private tour not only showcased Istanbul's architectural wonders but also provided breathtaking views. A perfect blend of history and visual delights."},
							new TripReView { Username = "OscarGomez", Email = "oscar.gomez@gmail.com", Message = "Flexibility and personalized experience! The private tour offered the freedom to explore at our own pace. Hotel pick up and drop off added convenience, making it a hassle-free and enjoyable day."},
							new TripReView { Username = "EthanPhillips", Email = "ethan.phillips@hotmail.com", Message = "A feast for the senses! The journey through Istanbul's Old City not only immersed us in history but also introduced us to the vibrant Grand Bazaar. A culinary and cultural adventure wrapped into one."},
						}
					},    //9
					new Trip()
					{
						Name="Faraya Ski Resort Lebanon",
						Cost = 60.00,
						StartDate=new DateTime(20/5/2024).Date,
						Description="Lebanon’s Mzaar Kfardebian offers the largest ski area in the Middle East, with 25 chairlifts, 50 runs, and around 50 miles (80 kilometers) of slopes. There’s no public transport but you can save yourself the expense of a taxi or car hire with this small-group shuttle service. Your driver will collect you from your Beirut hotel or rental in the morning, drive you to the resort, then bring you back. Spend the day at the Mzaar Kfardebian ski resort in Faraya Enjoy lively bars, interesting restaurants, and your choice of ski runs Numbers are capped at 15 travelers, so there won’t be too many stops Picks up and drops direct to hotels, homes, and rentals all over Beirut\r\n\r\nRead more about Faraya Ski Resort Lebanon - https://www.viator.com/tours/Beirut/Faraya-Ski-Resort-Lebanon/d4215-72500P30?mcid=56757",
						Program = "You will be picked up from your Hotel or Airbnb Address in Beirut Between 8:30am - 9:00am, brought to the departing point, and we will head to Mzaar Ski Resort which is widely known as the Middle East’s largest ski resort. With a legacy of ski culture and mountain energy and a spirit of adventure, Mzaar has driven locals and tourists to call it home. Beyond it’s 25 chairlifts, 50 runs and 100km of terrain, Mzaar is home to an entertainment scene with eclectic restaurants, boisterous bars, topping the list of things to do. Everyone will find no shortage of way to create lasting memories during a day, weekend or holiday. By 4:00 PM everyone has to be back in the Bus to head back to beirut.\r\n\r\nRead more about Faraya Ski Resort Lebanon - https://www.viator.com/tours/Beirut/Faraya-Ski-Resort-Lebanon/d4215-72500P30?mcid=56757",
						Capacity = 60,
						CountryId = 5 ,
						TripTypeID = 2 ,
						Duration = 1,
						Images = new List<Image>()
						{
							new Image(){ ImageURL = "Faraya Ski Resort Lebanon " +1+".jpg"},
							new Image(){ ImageURL = "Faraya Ski Resort Lebanon " +2+".jpg"},
							new Image(){ ImageURL = "Faraya Ski Resort Lebanon " +3+".jpg"},
							new Image(){ ImageURL = "Faraya Ski Resort Lebanon " +4+".jpg"},

						},
						TripReviews = new List<TripReView>()
						{
							new TripReView() { Username = "elleSaab" , Email = "ElSab21@gmail.com" , Message = "As an avid ski enthusiast, my experience at Lebanon's Mzaar Kfardebian with this small-group shuttle service was nothing short of exhilarating. The convenience of being picked up directly from my Beirut hotel added a touch of ease to the adventure."},
							new TripReView() { Username = "AlexandraSmith", Email = "alexandra.smith@gmail.com", Message = "Absolutely loved the skiing experience at Mzaar Kfardebian! The small-group shuttle service made the trip so convenient, and the variety of ski runs catered to all skill levels."},
							new TripReView() { Username = "DavidMiller", Email = "david.miller@yahoo.com", Message = "Lebanon's Mzaar Kfardebian is a winter paradise. The slopes, the atmosphere, and the overall vibe were fantastic. The small-group setting allowed for a more intimate and enjoyable experience."},
							new TripReView() { Username = "SophieBrown", Email = "sophie.brown@gmail.com", Message = "Spending the day at Faraya Ski Resort was a blast! The shuttle service was punctual, and I appreciated the direct pickup from my hotel. The après-ski options added an extra layer of fun to the day."},
							new TripReView() { Username = "DanielJohnson", Email = "daniel.johnson@hotmail.com", Message = "Mzaar Kfardebian offers a breathtaking winter landscape. The small-group shuttle was a game-changer, providing a stress-free journey. Highly recommended for fellow mountain enthusiasts!"},
							new TripReView() { Username = "OliviaTaylor", Email = "olivia.taylor@gmail.com", Message = "An unforgettable skiing adventure! The variety of runs kept things exciting, and the shuttle service ensured a smooth and comfortable trip. Can't wait to return for more winter fun."},
							new TripReView() { Username = "GabrielRoberts", Email = "gabriel.roberts@yahoo.com", Message = "Faraya Ski Resort exceeded expectations. The small-group shuttle made transportation a breeze, and the beautiful surroundings made every moment memorable. A perfect winter getaway!"},
							new TripReView() { Username = "EmilyHarrison", Email = "emily.harrison@gmail.com", Message = "Escaping to Mzaar Kfardebian was the highlight of my winter. The small-group shuttle added convenience, and the slopes offered a perfect blend of challenge and enjoyment. Will cherish these snowy memories!"},
							new TripReView() { Username = "IsaacBaker", Email = "isaac.baker@hotmail.com", Message = "Thrilling ski runs and stunning views – Mzaar Kfardebian has it all. The small-group setting allowed for a more personalized experience, making it an ideal destination for ski enthusiasts."},
							new TripReView() { Username = "SophiaCooper", Email = "sophia.cooper@gmail.com", Message = "A snowy retreat like no other! Faraya Ski Resort's charm, combined with the small-group shuttle service, created a delightful experience. The perfect winter escapade."},
							new TripReView() { Username = "EthanKing", Email = "ethan.king@yahoo.com", Message = "Lebanon's winter magic came to life at Mzaar Kfardebian. The small-group shuttle made the journey stress-free, and the variety of slopes ensured an adventure for every snow lover."},
							new TripReView() { Username = "AvaCollins", Email = "ava.collins@gmail.com", Message = "Faraya Ski Resort was a winter wonderland! The small-group shuttle service made transportation effortless, and the snow-covered slopes provided the perfect backdrop for an exhilarating day."},
							new TripReView() { Username = "LeoGomez", Email = "leo.gomez@yahoo.com", Message = "An amazing skiing experience at Mzaar Kfardebian! The small-group setting allowed for a more personalized adventure, and the diverse range of ski runs kept things exciting."},
							new TripReView() { Username = "EmmaBryant", Email = "emma.bryant@hotmail.com", Message = "Lebanon's winter charm was in full display at Faraya Ski Resort. The small-group shuttle was a convenient way to reach the slopes, and the après-ski options added a festive touch."},
							new TripReView() { Username = "MaxineTurner", Email = "maxine.turner@gmail.com", Message = "Mzaar Kfardebian is a snowy paradise! The small-group shuttle service made the journey smooth, and the breathtaking views from the slopes were simply mesmerizing."},
							new TripReView() { Username = "LucasFisher", Email = "lucas.fisher@yahoo.com", Message = "A fantastic day at Faraya Ski Resort! The small-group shuttle made travel hassle-free, and the variety of ski runs provided an adventure for every skill level."},
							new TripReView() { Username = "ZaraWright", Email = "zara.wright@gmail.com", Message = "Skiing bliss at Mzaar Kfardebian! The small-group shuttle service ensured a stress-free journey, and the well-maintained slopes offered a thrilling experience."},
							new TripReView() { Username = "RyanPerez", Email = "ryan.perez@hotmail.com", Message = "Faraya Ski Resort is a snowy haven! The small-group shuttle made transportation convenient, and the lively atmosphere on the slopes added to the overall enjoyment."},
							new TripReView() { Username = "LilyMorgan", Email = "lily.morgan@gmail.com", Message = "Mzaar Kfardebian is a winter gem! The small-group shuttle service was punctual, and the breathtaking scenery made the skiing adventure truly special."},
							new TripReView() { Username = "OwenBailey", Email = "owen.bailey@yahoo.com", Message = "A perfect day at Faraya Ski Resort! The small-group shuttle added ease to the journey, and the diverse ski runs catered to both beginners and experienced skiers."},
							new TripReView() { Username = "IsabelClark", Email = "isabel.clark@gmail.com", Message = "Skiing perfection at Mzaar Kfardebian! The small-group shuttle service and the well-maintained slopes created a memorable winter escape."},
						}
					},    //10

				});



			}
			
			
			context.SaveChanges();
		}

		

	}
}



