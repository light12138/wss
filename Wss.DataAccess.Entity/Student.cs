﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Wss.DataAccess.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public int GradeId { get; set; }
    }
}
