﻿using System;

namespace AuthorProblem
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
            Track track = new Track();
            track.PrintMethodsByAuthor();
        }
    }
}
