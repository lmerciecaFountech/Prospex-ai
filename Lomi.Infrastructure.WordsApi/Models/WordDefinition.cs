using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.WordsApi.Models
{
    public class WordDefinition
    {
        public string Definition { get; set; }
        public string PartOfSpeech { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> TypeOf { get; set; }
        public List<string> Also { get; set; }
        public List<string> Antonyms { get; set; }
        public List<string> Examples { get; set; }
        public List<string> InRegion { get; set; }
        public List<string> HasTypes { get; set; }
        public List<string> InstanceOf { get; set; }
        public List<string> HasParts { get; set; }
        public List<string> HasInstances { get; set; }
        public List<string> Derivation { get; set; }
        public List<string> RegionOf { get; set; }
        public List<string> HasMembers { get; set; }
        public List<string> PartOf { get; set; }
        public List<string> UsageOf { get; set; }
        public List<string> SimilarTo { get; set; }
        public List<string> HasUsages { get; set; }
        public List<string> MemberOf { get; set; }
        public List<string> HasSubstances { get; set; }
        public List<string> SubstanceOf { get; set; }
        public List<string> HasCategories { get; set; }
        public List<string> PertainsTo { get; set; }
        public List<string> Entails { get; set; }
        public List<string> InCategory { get; set; }
        public List<string> Cause { get; set; }
        public List<string> VerbGroup { get; set; }
        public List<string> Participle { get; set; }
        public List<string> Attribute { get; set; }
    }
}