using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class AttributeGroup
    {
        public string Value { get; private set; }

        public AttributeGroup()
        {

        }

        private AttributeGroup(string value)
        {
            Value = Value;
        }

        public static AttributeGroup Events = new AttributeGroup("Events");
        public static AttributeGroup Groups = new AttributeGroup("Groups");
        public static AttributeGroup Role = new AttributeGroup("Role");
        public static AttributeGroup Skill = new AttributeGroup("Skill");
        public static AttributeGroup Occupation = new AttributeGroup("Occupation");
        public static AttributeGroup RelationshipStatus = new AttributeGroup("RelationshipStatus");
        public static AttributeGroup Interests = new AttributeGroup("Interests");
        public static AttributeGroup RelationshipInterests = new AttributeGroup("RelationshipInterests");
        public static AttributeGroup Achievements = new AttributeGroup("Achievements");
        public static AttributeGroup Education = new AttributeGroup("Education");
        public static AttributeGroup Age = new AttributeGroup("Age");
        public static AttributeGroup Gender = new AttributeGroup("Gender");
    }
}