using System;
using System.Collections.Generic;
using System.Linq;
using CodeCampServer.Core;
using CodeCampServer.Core.Domain.Model;
using CodeCampServer.Core.Domain.Model.Enumerations;
using CodeCampServer.Core.Domain.Model.Planning;
using CodeCampServer.Core.Services.Impl;
using CodeCampServer.DependencyResolution;
using CodeCampServer.Infrastructure.DataAccess.Impl;
using CodeCampServer.IntegrationTests.Infrastructure.DataAccess;
using CodeCampServer.UI.Helpers.Mappers;
using CodeCampServer.UI.Models.Forms;
using NUnit.Framework;
using Tarantino.Core.Commons.Model;
using Tarantino.Core.Commons.Model.Enumerations;

namespace CodeCampServer.IntegrationTests.UI.DataLoader
{
	[TestFixture]
	public class ZDataLoader : DataTestBase
	{
		[Test, Category("DataLoader")]
		public void DataLoader()
		{
//			Logger.EnsureInitialized();
			DependencyRegistrar.EnsureDependenciesRegistered();
			DeleteAllObjects();
			LoadData();
		}

		private void LoadData()
		{
			var mapper = new UserMapper(new UserRepository(GetSessionBuilder()), new Cryptographer());
			var user = mapper.Map(new UserForm
			                      	{
			                      		Name = "Joe User",
			                      		Username = "admin",
			                      		EmailAddress = "joe@user.com",
			                      		Password = "password"
			                      	});


			var userGroup = new UserGroup
			                	{
			                		Name = "Austin .Net Users Group",
			                		City = "Austin",
			                		Region = "Texas",
			                		Country = "USA",
			                		Key = "localhost",
			                		HomepageHTML = "Austin .Net Users Group"
			                	};
			userGroup.Add(user);
			var conference = new Conference
			                 	{
			                 		Address = "123 Guadalupe Street",
			                 		City = "Austin",
			                 		Description = "Texas' Premier Software Community Event",
			                 		EndDate = new DateTime(2009, 5, 10),
			                 		StartDate = new DateTime(2009, 5, 9),
			                 		Key = "austincodecamp",
			                 		LocationName = "St. Edward's Professional Education Center",
			                 		Name = "Austin Code Camp",
			                 		PhoneNumber = "(512) 555-1212",
			                 		PostalCode = "78787",
			                 		Region = "Texas",
			                 		UserGroup = userGroup
			                 	};

			conference.AddAttendee(new Attendee
			                       	{
			                       		FirstName = "Jeffrey",
			                       		LastName = "Palermo",
			                       		EmailAddress = "jeffrey@email.com",
			                       		Status = AttendanceStatus.Interested,
			                       		Webpage = "http://jeffreypalermo.com"
			                       	});
			conference.AddAttendee(new Attendee
			                       	{
			                       		FirstName = "Matt",
			                       		LastName = "Hinze",
			                       		EmailAddress = "matt@email.com",
			                       		Status = AttendanceStatus.Attending,
			                       		Webpage = "http://mhinze.com/"
			                       	});
			conference.AddAttendee(new Attendee
			                       	{
			                       		FirstName = "Eric",
			                       		LastName = "Hexter",
			                       		EmailAddress = "eric@email.com",
			                       		Status = AttendanceStatus.Confirmed,
			                       		Webpage = "http://www.lostechies.com/blogs/hex"
			                       	});

			var track = new Track {Conference = conference, Name = "ALT.NET"};
			var track1 = new Track {Conference = conference, Name = "Web"};
			var track2 = new Track {Conference = conference, Name = "Project Management"};
			var track3 = new Track {Conference = conference, Name = "General Development"};
			var tracks = new[] {track, track1, track2, track3};

			var timeslot = new TimeSlot
			               	{
			               		Conference = conference,
			               		StartTime = new DateTime(2009, 5, 9, 9, 0, 0),
			               		EndTime = new DateTime(2009, 5, 9, 10, 30, 0)
			               	};
			var timeslot1 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 9, 11, 0, 0),
			                		EndTime = new DateTime(2009, 5, 9, 12, 30, 0)
			                	};
			var timeslot2 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 9, 14, 0, 0),
			                		EndTime = new DateTime(2009, 5, 9, 15, 30, 0)
			                	};
			var timeslot3 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 9, 16, 0, 0),
			                		EndTime = new DateTime(2009, 5, 9, 17, 30, 0)
			                	};

			var timeslot4 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 10, 9, 0, 0),
			                		EndTime = new DateTime(2009, 5, 10, 10, 30, 0)
			                	};
			var timeslot5 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 10, 11, 0, 0),
			                		EndTime = new DateTime(2009, 5, 10, 12, 30, 0)
			                	};
			var timeslot6 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 10, 14, 0, 0),
			                		EndTime = new DateTime(2009, 5, 10, 15, 30, 0)
			                	};
			var timeslot7 = new TimeSlot
			                	{
			                		Conference = conference,
			                		StartTime = new DateTime(2009, 5, 10, 16, 0, 0),
			                		EndTime = new DateTime(2009, 5, 10, 17, 30, 0)
			                	};
			var timeSlots = new[] {timeslot, timeslot1, timeslot2, timeslot3, timeslot4, timeslot5, timeslot6, timeslot7};

			var speaker = new Speaker
			              	{
			              		Bio = "Web Wizard",
			              		Company = "Software Inc.",
			              		EmailAddress = "wizard@example.com",
			              		FirstName = "Joe",
			              		LastName = "Httpson",
			              		JobTitle = "Sr. Developer",
			              		Key = "httpson",
			              		WebsiteUrl = "http://www.example.com/wizard",
                                Conference = conference
			              	};

			var speaker1 = new Speaker
			               	{
			               		Bio = "Web Design Guru",
			               		Company = "DeZinEs",
			               		EmailAddress = "linda@example.com",
			               		FirstName = "Linda",
			               		LastName = "Ihatetables",
			               		JobTitle = "Web Designer",
			               		Key = "tablehater",
                                WebsiteUrl = "http://www.example.com/linda",
                                Conference = conference
			               	};

			var speaker2 = new Speaker
			               	{
			               		Bio = "Big Executive",
			               		Company = "Micro Tech",
			               		EmailAddress = "ceo@example.com",
			               		FirstName = "Steven",
			               		LastName = "Bossman",
			               		JobTitle = "CEO",
			               		Key = "bossman",
                                WebsiteUrl = "http://www.example.com/bossman",
                                Conference = conference
			               	};

			var speaker3 = new Speaker
			               	{
			               		Bio = "Big Time Geek",
			               		Company = "Planet Soft",
			               		EmailAddress = "foo@example.com",
			               		FirstName = "Susan",
			               		LastName = "Bytecode",
			               		JobTitle = "Software Development Manager",
			               		Key = "Susanbytecode",
                                WebsiteUrl = "http://www.example.com/geek",
                                Conference = conference
			               	};

			var speaker4 = new Speaker
			               	{
			               		Bio = "Programming Genius From Canada",
			               		Company = "ColdCode",
			               		EmailAddress = "eh@example.com",
			               		FirstName = "Peter",
			               		LastName = "Keyboard",
			               		JobTitle = "Techncial Fellow",
			               		Key = "coldcoder",
                                WebsiteUrl = "http://www.example.com/coldcoder",
                                Conference = conference
			               	};

			var speaker5 = new Speaker
			               	{
			               		Bio = "Book Writer",
			               		Company = "",
			               		EmailAddress = "bookwork@example.com",
			               		FirstName = "David",
			               		LastName = "Writesalot",
			               		JobTitle = "Writer",
			               		Key = "davidw",
                                WebsiteUrl = "http://www.example.com/buymybook",
                                Conference = conference
			               	};

			var speaker6 = new Speaker
			               	{
			               		Bio = "Open Source Hacker",
			               		Company = "",
			               		EmailAddress = "oss@example.com",
			               		FirstName = "Mark",
			               		LastName = "Sendmepatch",
			               		JobTitle = "",
			               		Key = "sendmepatch",
                                WebsiteUrl = "http://www.example.com/sendmepatch",
                                Conference = conference
			               	};
			var speakers = new[] {speaker, speaker1, speaker2, speaker3, speaker4, speaker5, speaker6};

            

			var list = new List<PersistentObject>()
			           	{
			           		user,
			           		userGroup,
			           		conference,
			           		track,
			           		track1,
			           		track2,
			           		track3,
			           		timeslot,
			           		timeslot1,
			           		timeslot2,
			           		timeslot3,
			           		timeslot4,
			           		timeslot5,
			           		timeslot6,
			           		timeslot7,
			           		speaker,
			           		speaker1,
			           		speaker2,
			           		speaker3,
			           		speaker4,
			           		speaker5,
			           		speaker6
			           	};

			var conferences = CreateConferences(userGroup);
			list.AddRange(conferences.ToArray());

			User[] users = CreateUsers();
			list.AddRange(users);
			foreach (var user1 in users)
			{
				foreach (var stati in Enumeration.GetAll<ProposalStatus>())
				{
					list.Add(new Proposal
					         	{
					         		Conference = conference,
					         		Level = SessionLevel.L300,
					         		Submitter = user1,
					         		Title = "A great topic from " + user1.Name,
					         		Abstract = "Some great abstract",
					         		CreatedDate = SystemTime.Now(),
					         		Track = track,
					         		Status = stati
					         	});
				}
			}

			foreach (var aTrack in tracks)
			{
				foreach (var aTimeSlot in timeSlots)
				{
					foreach (var level in Enumeration.GetAll<SessionLevel>())
					{
						if (RandomlyDecideWhetherToSkip())
						{
							continue;
						}
						var sessionNumber = list.Count + 1;
						string time = aTimeSlot.StartTime.GetValueOrDefault().ToShortTimeString();
						Speaker selectedSpeaker = GetRandomSpeaker(speakers);
						string title = string.Format("{0} session at {1} in {2} by {3}", level.DisplayName,
						                             time,
						                             aTrack.Name, selectedSpeaker.FirstName);
						var aSession = new Session()
						               	{
						               		Title = title,
						               		Abstract = string.Format("Abstract for session at {0}", time),
						               		Conference = conference,
						               		Key = title.ToLower().Replace(" ", "-").Replace(":", "-") + "-" + sessionNumber,
						               		Level = level,
						               		MaterialsUrl = "http://google.com",
						               		RoomNumber = "24R",
						               		Speaker = selectedSpeaker,
						               		TimeSlot = aTimeSlot,
						               		Track = aTrack
						               	};
						list.Add(aSession);
					}
				}
			}

			PersistEntities(list.ToArray());
//			foreach (var o in list)
//			{
//				Console.WriteLine(o.GetType());
//				PersistEntities(o);
//			}
		}

		private IEnumerable<Conference> CreateConferences(UserGroup userGroup)
		{
			DateTime startDate = DateTime.Now.AddDays(-7*5);
			for (int i = 0; i < 10; i++)
			{
				DateTime conferenceDate = startDate.AddDays(7*i);
				yield return new Conference
				             	{
				             		Address = "123 Guadalupe Street",
				             		City = "Austin",
				             		Description = "Community Event",
				             		EndDate =  conferenceDate.AddDays(1),
				             		StartDate = conferenceDate,
				             		Key = "event"+i,
				             		LocationName = "St. Edward's Professional Education Center",
				             		Name = "User Group Event " + i,
				             		PhoneNumber = "(512) 555-1212",
				             		PostalCode = "78787",
				             		Region = "Texas",
				             		UserGroup = userGroup
				             	};
	            
			}

		}

		private User[] CreateUsers()
		{
			var mapper = new UserMapper(new UserRepository(GetSessionBuilder()), new Cryptographer());
			var user = mapper.Map(new UserForm
			                      	{
			                      		Name = "Joe User",
			                      		Username = "admin",
			                      		EmailAddress = "joe@user.com",
			                      		Password = "password"
			                      	});
			return new[]
			       	{
			       		mapper.Map(new UserForm
			       		           	{
			       		           		Name = "Jeffrey Palermo",
			       		           		EmailAddress = "jeffis@theman.com",
			       		           		Username = "jpalermo",
			       		           		Password = "beer"
			       		           	}),
			       		mapper.Map(new UserForm
			       		           	{
			       		           		Name = "Homer Simpson",
			       		           		EmailAddress = "homer@simpsons.com",
			       		           		Username = "hsimpson",
			       		           		Password = "beer"
			       		           	}),
			       		mapper.Map(new UserForm
			       		           	{
			       		           		Name = "Bart Simpson",
			       		           		EmailAddress = "bart@simpsons.com",
			       		           		Username = "bsimpson",
			       		           		Password = "beer"
			       		           	})
			       	};
		}

		private static int _seed = 0;

		private static bool RandomlyDecideWhetherToSkip()
		{
			int index = new Random(_seed += GetRandomInt()).Next(0, 2);
			if (index == 0) return true;
			return false;
		}

		private static int GetRandomInt()
		{
			return new Random(_seed++).Next(100);
		}

		private static Speaker GetRandomSpeaker(Speaker[] speakers)
		{
			int index = new Random(_seed += GetRandomInt()).Next(0, 4);
			return speakers[index];
		}
	}
}