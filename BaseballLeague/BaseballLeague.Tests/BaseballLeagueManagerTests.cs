using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using BaseballLeague.Domain;
using BaseballLeague.DLL;
using BaseballLeague.BLL;
using NUnit.Framework;

namespace BaseballLeague.Tests
{
    [TestFixture]
    public class BaseballLeagueManagerTests
    {
        [Test]
        public void GetAllPlayersByTeam()
        {
            Mock<IBaseballRepository> mockRepo = new Mock<IBaseballRepository>();

            mockRepo.Setup(x => x.GetAllPlayersByTeam(It.IsAny<int>())).Returns(new List<Player>()
            { new Player()
            {
                PlayerID = 1,
                TeamID = 1,
                PlayerName = "Billy Joe",
                JerseyNumber = 44,
                Position = "RF",
                BattingAverage = .225M,
                YearsPlayed = 5,
            }, new Player()
            {
                PlayerID = 2,
                TeamID = 1,
                PlayerName = "Robert Francesco",
                JerseyNumber = 22,
                Position = "1B",
                BattingAverage = .242M,
                YearsPlayed = 3,
            }
            });

            Assert.AreEqual(2, mockRepo.Object.GetAllPlayersByTeam(It.IsAny<int>()).Count());
            Assert.AreEqual("Billy Joe", mockRepo.Object.GetAllPlayersByTeam(It.IsAny<int>()).FirstOrDefault(x => x.PlayerID == 1).PlayerName);
        }

        [Test]
        public void GetAllTeamsByLeagueTest()
        {
            Mock<IBaseballRepository> mockRepo = new Mock<IBaseballRepository>();

            mockRepo.Setup(x => x.GetAllTeamsByLeague(It.IsAny<byte>())).Returns(new List<Team>()
            { new Team()
            {
                TeamID = 1,
                LeagueID = 1,
                TeamName = "Cubs",
                Manager = "George Bob"
            }, new Team()
            {
                TeamID = 2,
                LeagueID = 2,
                TeamName = "Braves",
                Manager = "Barry Jordan"
            }
            });

            Assert.AreEqual(2, mockRepo.Object.GetAllTeamsByLeague(It.IsAny<byte>()).Count());
            Assert.AreEqual("Braves", mockRepo.Object.GetAllTeamsByLeague(It.IsAny<byte>()).FirstOrDefault(x => x.TeamID == 2).TeamName);
        }

        [Test]
        public void GetAllPlayersTest()
        {
            Mock<IBaseballRepository> mockRepo = new Mock<IBaseballRepository>();

            mockRepo.Setup(x => x.GetAllPlayers()).Returns(new List<Player>()
            { new Player()
            {
                PlayerID = 1,
                TeamID = 1,
                PlayerName = "Billy Joe",
                JerseyNumber = 44,
                Position = "RF",
                BattingAverage = .225M,
                YearsPlayed = 5,
            }, new Player()
            {
                PlayerID = 2,
                TeamID = 1,
                PlayerName = "Robert Francesco",
                JerseyNumber = 22,
                Position = "1B",
                BattingAverage = .242M,
                YearsPlayed = 3,
            }
            });

            Assert.AreEqual(2, mockRepo.Object.GetAllPlayers().Count());
            Assert.AreEqual("Robert Francesco", mockRepo.Object.GetAllPlayers().FirstOrDefault(x => x.PlayerName == "Robert Francesco").PlayerName);
        }

        [Test]
        public void GetAllTeamsTest()
        {
            Mock<IBaseballRepository> mockRepo = new Mock<IBaseballRepository>();

            mockRepo.Setup(x => x.GetAllTeams()).Returns(new List<Team>()
            { new Team()
            {
                TeamID = 1,
                LeagueID = 1,
                TeamName = "Cubs",
                Manager = "George Bob"
            }, new Team()
            {
                TeamID = 2,
                LeagueID = 2,
                TeamName = "Braves",
                Manager = "Barry Jordan"
            }
            });

            Assert.AreEqual(2, mockRepo.Object.GetAllTeams().Count());
            Assert.AreEqual("Braves", mockRepo.Object.GetAllTeams().FirstOrDefault(x => x.TeamID == 2).TeamName);
        }

        [Test]
        public void ManagerGetAllPlayersTest()
        {
            Mock<IBaseballRepository> mockRepo = new Mock<IBaseballRepository>();

            mockRepo.Setup(x => x.GetAllPlayersByTeam(It.IsAny<int>())).Returns(new List<Player>()
            { new Player()
            {
                PlayerID = 1,
                TeamID = 1,
                PlayerName = "Billy Joe",
                JerseyNumber = 44,
                Position = "RF",
                BattingAverage = .225M,
                YearsPlayed = 5,
            }, new Player()
            {
                PlayerID = 2,
                TeamID = 1,
                PlayerName = "Robert Francesco",
                JerseyNumber = 22,
                Position = "1B",
                BattingAverage = .242M,
                YearsPlayed = 3,
            }
            });

            var manager = new BaseballLeagueManager(mockRepo.Object);

            var response = manager.GetAllPlayersInTeam(It.IsAny<int>());

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Billy Joe", response.Data.FirstOrDefault(x => x.PlayerID == 1).PlayerName);

        }

        [Test]
        public void ManagerGetAllTeamsTest()
        {
            Mock<IBaseballRepository> mockRepo = new Mock<IBaseballRepository>();

            mockRepo.Setup(x => x.GetAllTeamsByLeague(It.IsAny<byte>())).Returns(new List<Team>()
            { new Team()
            {
                TeamID = 1,
                LeagueID = 1,
                TeamName = "Cubs",
                Manager = "George Bob"
            }, new Team()
            {
                TeamID = 2,
                LeagueID = 2,
                TeamName = "Braves",
                Manager = "Barry Jordan"
            }
            });

            var manager = new BaseballLeagueManager(mockRepo.Object);

            var response = manager.GetAllTeamsInLeague(It.IsAny<byte>());

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Braves", response.Data.FirstOrDefault(x => x.TeamID == 2).TeamName);
        }



    }
}
