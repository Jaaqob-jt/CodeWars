using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    class User
    {
        // User properties that represent his status.
        private string _name = "";
        private int _rank = -8;
        private int _progress = 0;

        // Override to nicely show user stats without implicitly typing all of them separately.
        // Restrictions apply -- Rank up to 8, Progress up to 99
        public override string ToString()
        {
            if (_name.Length > 1)
            {
                return $"{_name} current rank is {_rank}, with progress towards new rank of {_progress} points!";
            }
            else
            {
                return $"This users current rank is {_rank}, with progress towards new rank of {_progress} points!";
            }
        }
        
        // Constructors for the class. Rank and Progress always start with default values, user can have a name.
        public User() { }
        public User(string nm) => _name = nm; 
        
        // Accessors for Rank and Progress stats. You can get them. Setters are private.
        public int rank 
        { 
            get { return _rank; }
            private set
            {
                if (value > 0)
                {
                    _rank += value;
                    if (_rank >= 8) _rank = 8;
                    if (_rank == 0) _rank = 1;
                }
            }
        }
        public int progress 
        { 
            get { return _progress; } 
            private set
            {
                if (value > 0)
                {
                    _progress += value;
                    if (_progress >= 100)
                    {
                        rank = _progress / 100;
                        _progress = _progress % 100;
                    }
                    if (_rank == 8) _progress = 0;
                }
            }
        }

        // Methods to progress in hierarchy. Only way to cahnge rank and progress values.
        public void incProgress(int inc)
        {
            if (inc < -8 || inc > 8 || inc == 0)
            {
                throw new ArgumentException();
            } else { 
            int multiplicator = 0;
                switch (Math.Sign(inc) + Math.Sign(rank))
                {
                    case -2:
                        multiplicator = Math.Abs(rank) + inc;
                        break;
                    case 2:
                        multiplicator = -(rank - inc);
                        break;
                    case 0:
                        if (inc > rank)
                        {
                            multiplicator = inc - rank - 1;
                        }
                        else
                        {
                            multiplicator = -rank + inc + 1;
                        }
                        break;
                    default:
                        break;
                }

                if (multiplicator == -1) progress = 1;
                if (multiplicator == 0) progress = 3;
                if (multiplicator > 0) progress = 10 * multiplicator * multiplicator;
            }
        }

    }
}
