using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MovieBrowser.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "Title", Namespace = "", IsNullable = false)]
    public partial class MovieDetailXml
    {

        private string localTitleField;

        private string originalTitleField;

        private ushort productionYearField;

        private string addedField;

        private decimal iMDBratingField;

        private string contentRatingField;

        private string mPAARatingField;

        private string iMDBField;

        private string iMDbIdField;

        private uint tMDbIdField;

        private uint budgetField;

        private uint revenueField;

        private string languageField;

        private string languageCodeField;

        private string countryField;

        private byte runningTimeField;

        private string overviewField;

        private string[] genresField;

        private string[] studiosField;

        private TitlePerson[] personsField;

        private string awardsField;

        private string backdropURLField;

        private string directorField;

        private string fullCertificationsField;

        private string formalMPAAField;

        private uint votesField;

        private string synopsisField;

        private string plotField;

        private string outlineField;

        private string shortDescriptionField;

        private string posterURLField;

        private string tagLineField;

        private TitleTagLines tagLinesField;

        private object top250Field;

        private string trailerURLField;

        private string websiteField;

        private System.DateTime releaseDateField;

        private string writersListField;

        private decimal popularityField;

        private ushort voteCountField;

        private string[] tagsField;

        private string[] similarMoviesField;

        private object otherID_RottenTomatoesField;

        private object rottenTomatoesIdField;

        private object criticRatingField;

        private object criticRatingSummaryField;

        private string iMDB_IDField;

        private uint tMDBField;

        private uint tMDB_IDField;

        private decimal ratingField;

        private string certificationField;

        private string trailerField;

        private byte runtimeField;

        private string descriptionField;

        private System.DateTime premiereDateField;

        /// <remarks/>
        public string LocalTitle
        {
            get
            {
                return this.localTitleField;
            }
            set
            {
                this.localTitleField = value;
            }
        }

        /// <remarks/>
        public string OriginalTitle
        {
            get
            {
                return this.originalTitleField;
            }
            set
            {
                this.originalTitleField = value;
            }
        }

        /// <remarks/>
        public ushort ProductionYear
        {
            get
            {
                return this.productionYearField;
            }
            set
            {
                this.productionYearField = value;
            }
        }

        /// <remarks/>
        public string Added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        public decimal IMDBrating
        {
            get
            {
                return this.iMDBratingField;
            }
            set
            {
                this.iMDBratingField = value;
            }
        }

        /// <remarks/>
        public string ContentRating
        {
            get
            {
                return this.contentRatingField;
            }
            set
            {
                this.contentRatingField = value;
            }
        }

        /// <remarks/>
        public string MPAARating
        {
            get
            {
                return this.mPAARatingField;
            }
            set
            {
                this.mPAARatingField = value;
            }
        }

        /// <remarks/>
        public string IMDB
        {
            get
            {
                return this.iMDBField;
            }
            set
            {
                this.iMDBField = value;
            }
        }

        /// <remarks/>
        public string IMDbId
        {
            get
            {
                return this.iMDbIdField;
            }
            set
            {
                this.iMDbIdField = value;
            }
        }

        /// <remarks/>
        public uint TMDbId
        {
            get
            {
                return this.tMDbIdField;
            }
            set
            {
                this.tMDbIdField = value;
            }
        }

        /// <remarks/>
        public uint Budget
        {
            get
            {
                return this.budgetField;
            }
            set
            {
                this.budgetField = value;
            }
        }

        /// <remarks/>
        public uint Revenue
        {
            get
            {
                return this.revenueField;
            }
            set
            {
                this.revenueField = value;
            }
        }

        /// <remarks/>
        public string Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string LanguageCode
        {
            get
            {
                return this.languageCodeField;
            }
            set
            {
                this.languageCodeField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public byte RunningTime
        {
            get
            {
                return this.runningTimeField;
            }
            set
            {
                this.runningTimeField = value;
            }
        }

        /// <remarks/>
        public string Overview
        {
            get
            {
                return this.overviewField;
            }
            set
            {
                this.overviewField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Genre", IsNullable = false)]
        public string[] Genres
        {
            get
            {
                return this.genresField;
            }
            set
            {
                this.genresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Studio", IsNullable = false)]
        public string[] Studios
        {
            get
            {
                return this.studiosField;
            }
            set
            {
                this.studiosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Person", IsNullable = false)]
        public TitlePerson[] Persons
        {
            get
            {
                return this.personsField;
            }
            set
            {
                this.personsField = value;
            }
        }

        /// <remarks/>
        public string Awards
        {
            get
            {
                return this.awardsField;
            }
            set
            {
                this.awardsField = value;
            }
        }

        /// <remarks/>
        public string BackdropURL
        {
            get
            {
                return this.backdropURLField;
            }
            set
            {
                this.backdropURLField = value;
            }
        }

        /// <remarks/>
        public string Director
        {
            get
            {
                return this.directorField;
            }
            set
            {
                this.directorField = value;
            }
        }

        /// <remarks/>
        public string FullCertifications
        {
            get
            {
                return this.fullCertificationsField;
            }
            set
            {
                this.fullCertificationsField = value;
            }
        }

        /// <remarks/>
        public string FormalMPAA
        {
            get
            {
                return this.formalMPAAField;
            }
            set
            {
                this.formalMPAAField = value;
            }
        }

        /// <remarks/>
        public uint Votes
        {
            get
            {
                return this.votesField;
            }
            set
            {
                this.votesField = value;
            }
        }

        /// <remarks/>
        public string Synopsis
        {
            get
            {
                return this.synopsisField;
            }
            set
            {
                this.synopsisField = value;
            }
        }

        /// <remarks/>
        public string Plot
        {
            get
            {
                return this.plotField;
            }
            set
            {
                this.plotField = value;
            }
        }

        /// <remarks/>
        public string Outline
        {
            get
            {
                return this.outlineField;
            }
            set
            {
                this.outlineField = value;
            }
        }

        /// <remarks/>
        public string ShortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }

        /// <remarks/>
        public string PosterURL
        {
            get
            {
                return this.posterURLField;
            }
            set
            {
                this.posterURLField = value;
            }
        }

        /// <remarks/>
        public string TagLine
        {
            get
            {
                return this.tagLineField;
            }
            set
            {
                this.tagLineField = value;
            }
        }

        /// <remarks/>
        public TitleTagLines TagLines
        {
            get
            {
                return this.tagLinesField;
            }
            set
            {
                this.tagLinesField = value;
            }
        }

        /// <remarks/>
        public object Top250
        {
            get
            {
                return this.top250Field;
            }
            set
            {
                this.top250Field = value;
            }
        }

        /// <remarks/>
        public string TrailerURL
        {
            get
            {
                return this.trailerURLField;
            }
            set
            {
                this.trailerURLField = value;
            }
        }

        /// <remarks/>
        public string Website
        {
            get
            {
                return this.websiteField;
            }
            set
            {
                this.websiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ReleaseDate
        {
            get
            {
                return this.releaseDateField;
            }
            set
            {
                this.releaseDateField = value;
            }
        }

        /// <remarks/>
        public string WritersList
        {
            get
            {
                return this.writersListField;
            }
            set
            {
                this.writersListField = value;
            }
        }

        /// <remarks/>
        public decimal Popularity
        {
            get
            {
                return this.popularityField;
            }
            set
            {
                this.popularityField = value;
            }
        }

        /// <remarks/>
        public ushort VoteCount
        {
            get
            {
                return this.voteCountField;
            }
            set
            {
                this.voteCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Tag", IsNullable = false)]
        public string[] Tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("SimilarMovie", IsNullable = false)]
        public string[] SimilarMovies
        {
            get
            {
                return this.similarMoviesField;
            }
            set
            {
                this.similarMoviesField = value;
            }
        }

        /// <remarks/>
        public object OtherID_RottenTomatoes
        {
            get
            {
                return this.otherID_RottenTomatoesField;
            }
            set
            {
                this.otherID_RottenTomatoesField = value;
            }
        }

        /// <remarks/>
        public object RottenTomatoesId
        {
            get
            {
                return this.rottenTomatoesIdField;
            }
            set
            {
                this.rottenTomatoesIdField = value;
            }
        }

        /// <remarks/>
        public object CriticRating
        {
            get
            {
                return this.criticRatingField;
            }
            set
            {
                this.criticRatingField = value;
            }
        }

        /// <remarks/>
        public object CriticRatingSummary
        {
            get
            {
                return this.criticRatingSummaryField;
            }
            set
            {
                this.criticRatingSummaryField = value;
            }
        }

        /// <remarks/>
        public string IMDB_ID
        {
            get
            {
                return this.iMDB_IDField;
            }
            set
            {
                this.iMDB_IDField = value;
            }
        }

        /// <remarks/>
        public uint TMDB
        {
            get
            {
                return this.tMDBField;
            }
            set
            {
                this.tMDBField = value;
            }
        }

        /// <remarks/>
        public uint TMDB_ID
        {
            get
            {
                return this.tMDB_IDField;
            }
            set
            {
                this.tMDB_IDField = value;
            }
        }

        /// <remarks/>
        public decimal Rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }

        /// <remarks/>
        public string certification
        {
            get
            {
                return this.certificationField;
            }
            set
            {
                this.certificationField = value;
            }
        }

        /// <remarks/>
        public string Trailer
        {
            get
            {
                return this.trailerField;
            }
            set
            {
                this.trailerField = value;
            }
        }

        /// <remarks/>
        public byte Runtime
        {
            get
            {
                return this.runtimeField;
            }
            set
            {
                this.runtimeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime PremiereDate
        {
            get
            {
                return this.premiereDateField;
            }
            set
            {
                this.premiereDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TitlePerson
    {

        private string nameField;

        private string typeField;

        private string roleField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TitleTagLines
    {

        private string tagLineField;

        /// <remarks/>
        public string TagLine
        {
            get
            {
                return this.tagLineField;
            }
            set
            {
                this.tagLineField = value;
            }
        }
    }
}
