using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int LevelInParentage { get; set; }
        public int LevelInFamily { get; set; }
        public bool IsDead { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDead { get; set; }
        public string BurialGround { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
