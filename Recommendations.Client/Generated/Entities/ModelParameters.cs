// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Recommendations.Client.Entities
{
    using System.Linq;

    /// <summary>
    /// Represents the parameters of a model
    /// </summary>
    public partial class ModelParameters
    {
        /// <summary>
        /// Initializes a new instance of the ModelParameters class.
        /// </summary>
        public ModelParameters() { }

        /// <summary>
        /// Initializes a new instance of the ModelParameters class.
        /// </summary>
        /// <param name="usageRelativePath">Usage file\folder path relative to
        /// the container.</param>
        /// <param name="description">Model description.</param>
        /// <param name="blobContainerName">The name of a blob container in
        /// the default storage account used by the service that stores the
        /// modeling files.</param>
        /// <param name="catalogFileRelativePath">Catalog file path relative
        /// to the container.</param>
        /// <param name="evaluationUsageRelativePath">Optional. Evaluation
        /// file\folder path relative to the container.</param>
        /// <param name="supportThreshold">How conservative the model is.
        /// Number of co-occurrences of items to be considered for
        /// modeling.</param>
        /// <param name="cooccurrenceUnit">Indicates how to group usage events
        /// before counting co-occurrences.
        /// A 'User' co-occurrence unit will consider all items purchased by
        /// the same user as occurring together in the same session.
        /// A 'Timestamp' co-occurrence unit will consider all items purchased
        /// by the same user in the same time as occurring together in the
        /// same session. Possible values include: 'User', 'Timestamp'</param>
        /// <param name="similarityFunction">Defines the similarity function
        /// to be used by the model. Lift favors serendipity,
        /// Co-occurrence favors predictability, and Jaccard is a nice
        /// compromise between the two. Possible values include: 'Jaccard',
        /// 'Cooccurrence', 'Lift'</param>
        /// <param name="enableColdItemPlacement">Indicates if the
        /// recommendation should also push cold items via feature
        /// similarity.</param>
        /// <param name="enableColdToColdRecommendations">Indicates whether
        /// the similarity between pairs of cold items (catalog items without
        /// usage) should be computed.
        /// If set to false, only similarity between cold and warm item will
        /// be computed, using catalog item features.
        /// Note that this configuration is only relevant when
        /// enableColdItemPlacement is set to true.</param>
        /// <param name="enableUserAffinity">For user-to-item recommendations,
        /// it defines whether the event type and the time of the event
        /// should be considered as
        /// input into the scoring.</param>
        /// <param name="enableUserToItemRecommendations">Enables user to item
        /// recommendations by storing the usage events per user and using it
        /// for recommendations.
        /// Setting this to true will impact the performance of the training
        /// process.</param>
        /// <param name="allowSeedItemsInRecommendations">Allow seed items
        /// (input items to the recommendation request) to be returned as
        /// part of the recommendation results.</param>
        /// <param name="enableBackfilling">Backfill recommendations with
        /// popular items.</param>
        /// <param name="decayPeriodInDays">The decay period in days. The
        /// strength of the signal for events that are that many days old
        /// will be half that of the most recent events.</param>
        public ModelParameters(string usageRelativePath, string description = default(string), string blobContainerName = default(string), string catalogFileRelativePath = default(string), string evaluationUsageRelativePath = default(string), int? supportThreshold = default(int?), CooccurrenceUnit? cooccurrenceUnit = default(CooccurrenceUnit?), SimilarityFunction? similarityFunction = default(SimilarityFunction?), bool? enableColdItemPlacement = default(bool?), bool? enableColdToColdRecommendations = default(bool?), bool? enableUserAffinity = default(bool?), bool? enableUserToItemRecommendations = default(bool?), bool? allowSeedItemsInRecommendations = default(bool?), bool? enableBackfilling = default(bool?), int? decayPeriodInDays = default(int?))
        {
            Description = description;
            BlobContainerName = blobContainerName;
            CatalogFileRelativePath = catalogFileRelativePath;
            UsageRelativePath = usageRelativePath;
            EvaluationUsageRelativePath = evaluationUsageRelativePath;
            SupportThreshold = supportThreshold;
            CooccurrenceUnit = cooccurrenceUnit;
            SimilarityFunction = similarityFunction;
            EnableColdItemPlacement = enableColdItemPlacement;
            EnableColdToColdRecommendations = enableColdToColdRecommendations;
            EnableUserAffinity = enableUserAffinity;
            EnableUserToItemRecommendations = enableUserToItemRecommendations;
            AllowSeedItemsInRecommendations = allowSeedItemsInRecommendations;
            EnableBackfilling = enableBackfilling;
            DecayPeriodInDays = decayPeriodInDays;
        }

        /// <summary>
        /// Gets or sets model description.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of a blob container in the default storage
        /// account used by the service that stores the modeling files.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "blobContainerName")]
        public string BlobContainerName { get; set; }

        /// <summary>
        /// Gets or sets catalog file path relative to the container.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "catalogFileRelativePath")]
        public string CatalogFileRelativePath { get; set; }

        /// <summary>
        /// Gets or sets usage file\folder path relative to the container.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "usageRelativePath")]
        public string UsageRelativePath { get; set; }

        /// <summary>
        /// Gets or sets optional. Evaluation file\folder path relative to the
        /// container.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "evaluationUsageRelativePath")]
        public string EvaluationUsageRelativePath { get; set; }

        /// <summary>
        /// Gets or sets how conservative the model is. Number of
        /// co-occurrences of items to be considered for modeling.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "supportThreshold")]
        public int? SupportThreshold { get; set; }

        /// <summary>
        /// Gets or sets indicates how to group usage events before counting
        /// co-occurrences.
        /// A 'User' co-occurrence unit will consider all items purchased by
        /// the same user as occurring together in the same session.
        /// A 'Timestamp' co-occurrence unit will consider all items purchased
        /// by the same user in the same time as occurring together in the
        /// same session. Possible values include: 'User', 'Timestamp'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "cooccurrenceUnit")]
        public CooccurrenceUnit? CooccurrenceUnit { get; set; }

        /// <summary>
        /// Gets or sets defines the similarity function to be used by the
        /// model. Lift favors serendipity,
        /// Co-occurrence favors predictability, and Jaccard is a nice
        /// compromise between the two. Possible values include: 'Jaccard',
        /// 'Cooccurrence', 'Lift'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "similarityFunction")]
        public SimilarityFunction? SimilarityFunction { get; set; }

        /// <summary>
        /// Gets or sets indicates if the recommendation should also push cold
        /// items via feature similarity.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableColdItemPlacement")]
        public bool? EnableColdItemPlacement { get; set; }

        /// <summary>
        /// Gets or sets indicates whether the similarity between pairs of
        /// cold items (catalog items without usage) should be computed.
        /// If set to false, only similarity between cold and warm item will
        /// be computed, using catalog item features.
        /// Note that this configuration is only relevant when
        /// enableColdItemPlacement is set to true.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableColdToColdRecommendations")]
        public bool? EnableColdToColdRecommendations { get; set; }

        /// <summary>
        /// Gets or sets for user-to-item recommendations, it defines whether
        /// the event type and the time of the event should be considered as
        /// input into the scoring.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableUserAffinity")]
        public bool? EnableUserAffinity { get; set; }

        /// <summary>
        /// Gets or sets enables user to item recommendations by storing the
        /// usage events per user and using it for recommendations.
        /// Setting this to true will impact the performance of the training
        /// process.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableUserToItemRecommendations")]
        public bool? EnableUserToItemRecommendations { get; set; }

        /// <summary>
        /// Gets or sets allow seed items (input items to the recommendation
        /// request) to be returned as part of the recommendation results.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "allowSeedItemsInRecommendations")]
        public bool? AllowSeedItemsInRecommendations { get; set; }

        /// <summary>
        /// Gets or sets backfill recommendations with popular items.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableBackfilling")]
        public bool? EnableBackfilling { get; set; }

        /// <summary>
        /// Gets or sets the decay period in days. The strength of the signal
        /// for events that are that many days old will be half that of the
        /// most recent events.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "decayPeriodInDays")]
        public int? DecayPeriodInDays { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (UsageRelativePath == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "UsageRelativePath");
            }
            if (this.Description != null)
            {
                if (this.Description.Length > 256)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.MaxLength, "Description", 256);
                }
                if (this.Description.Length < 0)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.MinLength, "Description", 0);
                }
            }
            if (this.SupportThreshold > 50)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMaximum, "SupportThreshold", 50);
            }
            if (this.SupportThreshold < 3)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMinimum, "SupportThreshold", 3);
            }
            if (this.DecayPeriodInDays > 2147483647)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMaximum, "DecayPeriodInDays", 2147483647);
            }
            if (this.DecayPeriodInDays < 1)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMinimum, "DecayPeriodInDays", 1);
            }
        }
    }
}
