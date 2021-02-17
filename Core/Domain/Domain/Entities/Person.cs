using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Person : AuditableBaseEntity
    {
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
        public int IdParent { get; set; }
    }
}
