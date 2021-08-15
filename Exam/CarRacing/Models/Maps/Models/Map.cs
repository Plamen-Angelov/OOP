using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Models.Racers.Models;
using CarRacing.Utilities.Messages;
using System;

namespace CarRacing.Models.Maps.Models
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string result = string.Empty;

            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                result = OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == false)
            {
                racerTwo.Race();
                result = string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwo.IsAvailable() == false)
            {
                racerOne.Race();

                result = string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == true)
            {
                double racerOneRacingMultiplyer = default;

                if (racerOne.GetType().Name == nameof(ProfessionalRacer))
                {
                    racerOneRacingMultiplyer = 1.2;
                }
                else if (racerOne.GetType().Name == nameof(StreetRacer))
                {
                    racerOneRacingMultiplyer = 1.1;
                }

                double racerOneWinningChance = racerOne.Car.HorsePower * 
                    racerOne.DrivingExperience * racerOneRacingMultiplyer;

                double racerTwoRacingMultiplyer = default;

                if (racerTwo.GetType().Name == nameof(ProfessionalRacer))
                {
                    racerTwoRacingMultiplyer = 1.2;
                }
                else if (racerOne.GetType().Name == nameof(StreetRacer))
                {
                    racerTwoRacingMultiplyer = 1.1;
                }

                double racerTwoWinningChance = racerTwo.Car.HorsePower * 
                    racerTwo.DrivingExperience * racerTwoRacingMultiplyer;

                racerOne.Race();
                racerTwo.Race();

                if (racerOneWinningChance > racerTwoWinningChance)
                {
                    result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, 
                        racerTwo.Username, racerOne.Username);
                }
                else
                {
                    result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username,
                        racerTwo.Username, racerTwo.Username);
                }
            }

            return result;
        }
    }
}
