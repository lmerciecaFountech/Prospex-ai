using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Mappers
{
    public static class EntityMapper
    {
        public static Func<BaseVertex, Location> GetLocation = (baseVertex) =>
        {
            if (baseVertex == null)
                return null;

            var location = new Location(
                baseVertex.GetProperty<string>(nameof(Location.PlaceId)),
                baseVertex.GetProperty<double>(nameof(Location.Longitude)),
                baseVertex.GetProperty<double>(nameof(Location.Latitude)),
                baseVertex.GetProperty<string>(nameof(Location.LongName)),
                baseVertex.GetProperty<string>(nameof(Location.ShortName)),
                VertexLabel.Location,
                baseVertex.GetProperty<int>(nameof(Location.UtcOffset)),
                baseVertex.GetProperty<string>(nameof(Location.LocationType)).Split(',').ToList(),
                true);

            return location;
        };

        public static Func<BaseVertex, AttributeEntity> GetAttribute = (baseVertex) =>
        {
            if (baseVertex == null)
                return null;

            var attribute = new AttributeEntity(baseVertex.GetProperty<string>(nameof(AttributeEntity.Value)));
            attribute.CreatedAt = baseVertex.GetProperty<long>(nameof(AttributeEntity.CreatedAt));
            attribute.InCatalogue = baseVertex.GetProperty<bool>(nameof(AttributeEntity.InCatalogue));
            //attribute.IsDirty = baseVertex.GetProperty<bool>(nameof(AttributeEntity.IsDirty));
            attribute.IsDisplayable = baseVertex.GetProperty<bool>(nameof(AttributeEntity.IsDisplayable));
            //attribute.IsGroupable = baseVertex.GetProperty<bool>(nameof(AttributeEntity.IsGroupable));
            attribute.IsPrivate = baseVertex.GetProperty<bool>(nameof(AttributeEntity.IsPrivate));
            attribute.Status = baseVertex.GetProperty<string>(nameof(AttributeEntity.Status));
            attribute.UpdatedAt = baseVertex.GetProperty<long>(nameof(AttributeEntity.UpdatedAt));
            attribute.Weight = baseVertex.GetProperty<double>(nameof(AttributeEntity.Weight));

            return attribute;
        };

        public static Func<BaseEdge, AttributeEdge> GetAttributeEdge = baseEdge =>
        {
            if(baseEdge == null)
                return null;

            var source = Source.From(baseEdge.GetProperty<string>(nameof(AttributeEdge.Source)));
            var label = EdgeLabel.From(baseEdge.GetProperty<string>(nameof(AttributeEdge.Label)) ?? baseEdge.Label);

            var attributeEdge =
                new AttributeEdge(label, source, baseEdge.GetProperty<string>(nameof(AttributeEdge.Origin)))
                {
                    IsActive = baseEdge.GetProperty<bool>(nameof(AttributeEdge.IsActive)),
                    Reinforcement = baseEdge.GetProperty<int>(nameof(AttributeEdge.Reinforcement)),
                    IsValid = baseEdge.GetProperty<bool>(nameof(AttributeEdge.IsValid)),
                    UpdatedAt = baseEdge.GetProperty<long>(nameof(AttributeEdge.UpdatedAt)),
                    CreatedAt = baseEdge.GetProperty<long>(nameof(AttributeEdge.CreatedAt)),
                    Confidence = baseEdge.GetProperty<double>(nameof(AttributeEdge.Confidence)),
                    Weight = baseEdge.GetProperty<double>(nameof(AttributeEdge.Weight))
                };


            return attributeEdge;
        };

        public static Func<BaseEdge, StandardEdge> GetStandardEdge = baseEdge =>
        {
            if (baseEdge == null)
                return null;

            var standardEdge = new StandardEdge(
                EdgeLabel.From(baseEdge.Label),
                Source.From(baseEdge.GetProperty<string>(nameof(AttributeEdge.Source)) ?? Source.Unset.Value));

            standardEdge.IsValid = baseEdge.GetProperty<bool>(nameof(AttributeEdge.IsValid));
            //standardEdge.IsDirty = baseEdge.GetProperty<bool>(nameof(AttributeEdge.IsDirty));
            standardEdge.UpdatedAt = baseEdge.GetProperty<long>(nameof(AttributeEdge.UpdatedAt));
            standardEdge.CreatedAt = baseEdge.GetProperty<long>(nameof(AttributeEdge.CreatedAt));

            return standardEdge;
        };

        public static Func<BaseVertex, Person> GetPerson = (baseVertex) =>
        {
            if (baseVertex == null)
                return null;

            Enum.TryParse(baseVertex.GetProperty<string>(nameof(Person.Gender)), out Gender gender);
            Enum.TryParse(baseVertex.GetProperty<string>(nameof(Person.AgeCategory)), out AgeCategory ageCategory);

            var person = new Person(Source.Unset, null, new PersonName(baseVertex.GetProperty<string>(nameof(Person.FullName))),
                Email.From(baseVertex.GetProperty<string>(nameof(Person.Email))),
                gender,
                ageCategory,
                EmploymentHistory.None(),
                PersonLocation.None(),
                Occupations.None(),
                Skills.None(),
                EducationInfoHistory.None(),
                baseVertex.GetProperty<string>(nameof(Person.PictureUrl)),
                new List<string>());

            //person.IsLocked = baseVertex.GetProperty<bool>(nameof(Person.IsLocked));
            //person.ProfileCompletion = baseVertex.GetProperty<int>(nameof(Person.ProfileCompletion));
            //person.UtcOffset = baseVertex.GetProperty<int>(nameof(Person.UtcOffset));
            //person.ProspexId = baseVertex.GetProperty<string>(nameof(Person.ProspexId));

            return person;
        };

        public static Func<BaseVertex, Dna> GetDna = (baseVertex) =>
        {
            if (baseVertex == null)
                return null;

            var dna = new Dna(baseVertex.Id);
            dna.DCF = baseVertex.GetProperty<bool>(nameof(Dna.DCF));
            dna.LastRecommendationUpdateAt = baseVertex.GetProperty<long>(nameof(Dna.LastRecommendationUpdateAt));
            dna.RDL = baseVertex.GetProperty<int>(nameof(Dna.RDL));

            return dna;
        };
    }
}
