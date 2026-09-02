using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleObserver
{
    internal class Observable
    {

        List<string>? _students = new();

        internal string AddToCourse(string name)
        {
            _students.Add(name);
            return $"Hi {name}, you have been added to the course.";
        }


        internal void Update()
        {
            foreach (string student in _students)
            {
               
            }
        }
    }
}
