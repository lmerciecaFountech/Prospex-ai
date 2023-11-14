using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents an event in the calendar. In the user interface, event and 
    /// task records are collectively referred to as activities.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_event.htm
    /// </remarks>
    public class Event : Base
    {
        /// <summary>
        /// The WhoId represents a human such as a lead or a contact. WhoIds are 
        /// polymorphic. Polymorphic means a WhoId is equivalent to a contact’s 
        /// ID or a lead’s ID.
        /// </summary>
        public string WhoId { get; set; }
        /// <summary>
        /// The WhatId represents nonhuman objects such as accounts, opportunities,
        /// campaigns, cases, or custom objects. WhatIds are polymorphic. Polymorphic
        /// means a WhatId is equivalent to the ID of a related object.
        /// </summary>
        public string WhatId { get; set; }
        /// <summary>
        /// The subject line of the event, such as Call, Email, or Meeting.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Contains the location of the event.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Indicates whether the <see cref="ActivityDate"/> field (true) or the
        /// <see cref="ActivityDateTime"/> field (false) is used to define the date
        /// or time of the event.
        /// </summary>
        public bool? IsAllDayEvent { get; set; }
        /// <summary>
        /// Contains the event’s due date if the <see cref="IsAllDayEvent"/> flag
        /// is set to false. This field is a regular Date/Time field with a relevant
        /// time portion. The time portion is always transferred in the Coordinated 
        /// Universal Time (UTC) time zone.
        /// </summary>
        public DateTime? ActivityDateTime { get; set; }
        /// <summary>
        /// Contains the event’s due date if the <see cref="IsAllDayEvent"/> flag
        /// is set to true. This field is a date field with a timestamp that is always
        /// set to midnight in the Coordinated Universal Time (UTC) time zone.
        /// </summary>
        public DateTime? ActivityDate { get; set; }
        /// <summary>
        /// Contains the event length, in minutes.
        /// </summary>
        public int? DurationInMinutes { get; set; }
        /// <summary>
        /// Indicates the start date and time of the event.
        /// </summary>
        public DateTime? StartDateTime { get; set; }
        /// <summary>
        /// This field is a regular Date/Time field with a relevant time portion.
        /// The time portion is always transferred in the Coordinated Universal 
        /// Time (UTC) time zone.
        /// </summary>
        public DateTime? EndDateTime { get; set; }
        /// <summary>
        /// Contains a text description of the event.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Represents the ID of the related Account.
        /// </summary>
        /// <remarks>
        /// The AccountId is determined as follows.
        /// If the value of WhatId is any of the following objects, then Salesforce
        /// uses that object’s AccountId.
        /// * Account
        /// * Opportunity
        /// * Contract
        /// * Custom object that is a child of Account
        /// If the value of the WhatId field is any other object, and the value of
        /// the WhoId field is a Contact object, then Salesforce uses that contact’s
        /// AccountId. (If your organization uses Shared Activities, Salesforce uses
        /// the AccountId of the primary contact.)
        /// 
        /// Otherwise, Salesforce sets the value of the AccountId field to null.
        /// 
        /// For information on IDs, see ID Field Type.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/field_types.htm#i1435616
        /// </remarks>
        public string AccountId { get; set; }
        /// <summary>
        /// Contains the ID of the user who owns the event.
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// Indicates whether users other than the creator of the event can (false)
        /// or can’t (true) see the event details when viewing the event user’s calendar.
        /// </summary>
        /// <remarks>
        /// However, users with the View All Data or Modify All Data permission can see 
        /// private events in reports and searches, or when viewing other users’ calendars.
        /// Private events can’t be associated with opportunities, accounts, cases, campaigns,
        /// contracts, leads, or contacts. 
        /// </remarks>
        public bool? IsPrivate { get; set; }
        /// <summary>
        /// Indicates how this event appears when another user views the calendar: Busy,
        /// Out of Office, or Free.
        /// </summary>
        public string ShowAs { get; set; }
        /// <summary>
        /// Indicates whether the event is a child of another event (true) or not (false).
        /// </summary>
        public bool? IsChild { get; set; }
        /// <summary>
        /// Indicates whether the event is a group event—that is, whether it has invitees
        /// (true) or not (false).
        /// </summary>
        public bool? IsGroupEvent { get; set; }
        /// <summary>
        /// The possible values are:
        /// * (Non–group event)—An event with no invitees.
        /// * (Group event)—An event with invitees.
        /// * (Proposed event)—An event created when a user requests a meeting with a contact,
        /// lead, or person account using the Salesforce user interface. When the user 
        /// confirms the meeting, the proposed event becomes a group event. You can’t create,
        /// edit, or delete proposed events in the API.
        /// </summary>
        public string GroupEventType { get; set; }
        /// <summary>
        /// Indicates whether the event has been archived.
        /// </summary>
        public bool? IsArchived { get; set; }
        /// <summary>
        /// Contains the ID of the main record of the recurring event. Subsequent occurrences
        /// have the same value in this field.
        /// </summary>
        public string RecurrenceActivityId { get; set; }
        /// <summary>
        /// Indicates whether the event is scheduled to repeat itself (true) or only occurs once (false). 
        /// If this field value is true, then <see cref="RecurrenceEndDateOnly"/>, <see cref="RecurrenceStartDateTime"/>,
        /// <see cref="RecurrenceType"/>, and any recurrence fields associated with the given recurrence
        /// type must be populated.
        /// </summary>
        public bool? IsRecurrence { get; set; }
        /// <summary>
        /// Indicates the date and time when the recurring event begins. The value must precede the 
        /// <see cref="RecurrenceEndDateOnly"/>. This field is a regular Date/Time field with a
        /// relevant time portion. The time portion is always transferred in the Coordinated 
        /// Universal Time (UTC) time zone. 
        /// </summary>
        public DateTime? RecurrenceStartDateTime { get; set; }
        /// <summary>
        /// Indicates the last date on which the event repeats. For multiday recurring events,
        /// this is the day on which the last occurrence starts. This field is a date field 
        /// with a timestamp that is always set to midnight in the Coordinated Universal
        /// Time (UTC) time zone. 
        /// </summary>
        public DateTime? RecurrenceEndDateOnly { get; set; }
        /// <summary>
        /// Indicates the time zone associated with a recurring event. For example, 
        /// “UTC-8:00” for Pacific Standard Time.
        /// </summary>
        public string RecurrenceTimeZoneSidKey { get; set; }
        /// <summary>
        /// Indicates how often the event repeats. For example, daily, weekly, or every nth month
        /// (where “nth” is defined in <see cref="RecurrenceInstance"/>).
        /// </summary>
        public string RecurrenceType { get; set; }
        /// <summary>
        /// Indicates the interval between recurring events.
        /// </summary>
        public int? RecurrenceInterval { get; set; }
        /// <summary>
        /// Indicates the day or days of the week on which the event repeats. This field contains
        /// a bitmask. The values are as follows:
        /// Sunday = 1
        /// Monday = 2
        /// Tuesday = 4
        /// Wednesday = 8
        /// Thursday = 16
        /// Friday = 32
        /// Saturday = 64
        /// Multiple days are represented as the sum of their numerical values.For example,
        /// Tuesday and Thursday = 4 + 16 = 20.
        /// </summary>
        public int? RecurrenceDayOfWeekMask { get; set; }
        /// <summary>
        /// Indicates the day of the month on which the event repeats.
        /// </summary>
        public int? RecurrenceDayOfMonth { get; set; }
        /// <summary>
        /// Indicates the frequency of the event’s recurrence. For example, 2nd or 3rd.
        /// </summary>
        public string RecurrenceInstance { get; set; }
        /// <summary>
        /// ndicates the month in which the event repeats.
        /// </summary>
        public string RecurrenceMonthOfYear { get; set; }
        /// <summary>
        /// Represents the time when the reminder is scheduled to fire, if <see cref="IsReminderSet"/>
        /// is set to true. If IsReminderSet is set to false, then the user may have deselected the
        /// reminder checkbox in the Salesforce user interface, or the reminder has already fired 
        /// at the time indicated by the value.
        /// </summary>
        public DateTime? ReminderDateTime { get; set; }
        /// <summary>
        /// Indicates whether the activity is a reminder (true) or not (false).
        /// </summary>
        public bool? IsReminderSet { get; set; }
        /// <summary>
        /// Provides standard subtypes to facilitate creating and searching for events.
        /// </summary>
        public string EventSubtype { get; set; }
    }
}

