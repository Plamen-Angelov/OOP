// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
	using FestivalManager.Entities;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Performer first;
		private Performer second;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
			first = new Performer("Pesho", "Peshev", 18);
			second = new Performer("Gosho", "Goshev", 37);
		}

		[Test]
	    public void CtorCreateAnInstanceOfPerformers()
	    {
			Assert.That(stage.Performers.Count == 0);
		}

		[TestCase("Pesho", "Peshev", 17)]
		[TestCase("Pesho", "Peshev", 12)]
		[TestCase("Pesho", "Peshev", 0)]
		[TestCase("Pesho", "Peshev", -2)]
		public void AddPerformerThrowsExceptionWhenPerformersAgeIsUnder18(
			string firstName, string lastName, int age)
        {
			Performer performer = new Performer(firstName, lastName, age);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

		[Test]
		public void AddPerformerWorksCorrectly()
        {
			stage.AddPerformer(first);
			stage.AddPerformer(second);

			Assert.That(stage.Performers.Count == 2);
		}

		[Test]
		public void AddSongThrowsExceptionWhenDurationIsLessThan1()
		{
			TimeSpan duration = new TimeSpan(0, 0, 34);
			Song song = new Song("songName", duration);

			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void AddSongToPerformerWorksCorrectly()
        {
			TimeSpan duration = new TimeSpan(0, 1, 0);
			Song song = new Song("first", duration);

			stage.AddSong(song);
			stage.AddPerformer(first);
			stage.AddPerformer(second);

			string output = stage.AddSongToPerformer("first", "Gosho Goshev");

			Assert.That(second.SongList.Count == 1);

			string result = "first (01:00) will be performed by Gosho Goshev";

			Assert.That(output, Is.EqualTo(result));
		}

		[Test]
		public void PlayRetyrnsTheCorrectString()
        {
            TimeSpan duration1 = new TimeSpan(0, 1, 0);
            Song song1 = new Song("first", duration1);
            TimeSpan duration2 = new TimeSpan(0, 3, 34);
            Song song2 = new Song("second", duration2);

			first.SongList.Add(song1);
			first.SongList.Add(song2);
			stage.AddPerformer(first);

			string expectedResult = "1 performers played 2 songs";

			Assert.That(stage.Play, Is.EqualTo(expectedResult));
		}
	}
}