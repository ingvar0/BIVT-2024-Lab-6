﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            // поля
            private readonly string _name;
            private readonly string _surname;
            public readonly int[] _penaltyTime;

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTime = new int[10];
                for(int i = 0; i < 10; i++)
                {
                    _penaltyTime[i] = 0;
                }
            }

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTime == null) return null;
                    int[] newArray = new int[_penaltyTime.Length];
                    Array.Copy(_penaltyTime, newArray, _penaltyTime.Length);
                    return newArray;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltyTime == null) return 0;
                    int s = 0;
                    for (int i = 0; i < _penaltyTime.Length; i++)
                    {
                        s += _penaltyTime[i];
                    }
                    return s;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTime == null) return false;
                    for (int i = 0; i < _penaltyTime.Length; i++)
                    {
                        if (_penaltyTime[i] == 10) return true;
                    }
                    return false;
                }
            }

            // методы
            public void PlayMatch(int time)
            {
                if (time == null || time < 0) return;

                for (int i = 0; i < 10; i++)
                {
                    if (_penaltyTime[i] == 0)
                    {
                        _penaltyTime[i] = time;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i].TotalTime > array[j].TotalTime)
                        {
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {TotalTime} {IsExpelled}");
            }
        }
    }
}
